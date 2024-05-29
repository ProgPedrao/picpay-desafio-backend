using System;
using System.Transactions;
using AutoMapper;
using picpay_desafio_backend.Application.DTOs;
using picpay_desafio_backend.Application.Interfaces;
using picpay_desafio_backend.Domain.Entities;
using picpay_desafio_backend.Domain.Entities.Enums;
using picpay_desafio_backend.Domain.Exceptions;
using picpay_desafio_backend.Domain.Interfaces;

namespace picpay_desafio_backend.Application.Services
{
	public class TransactionService : ITransactionService
	{

        private readonly IUsuarioService _usuarioService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizeService _authorizeService;
        private readonly INotificacaoService _notificacaoService;

        public TransactionService(IUsuarioService usuarioService, ITransactionRepository transactionRepository, IMapper mapper, IAuthorizeService authorizeService, INotificacaoService notificacaoService)
		{
            _usuarioService = usuarioService;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _authorizeService = authorizeService;
            _notificacaoService = notificacaoService;
        }

        public async Task CreateTransactionAsync(TransactionDTO transactionDto)
        {

            Transacao transaction = _mapper.Map<Transacao>(transactionDto);

            Usuario remetente = await _usuarioService.GetUsuarioByCpf(transaction.Remetente);
            Usuario recebedor = await _usuarioService.GetUsuarioByCpf(transaction.Receptor);

            ValidarTransacao(remetente, transaction.Valor);

            remetente.debitar(transaction.Valor);
            recebedor.creditar(transaction.Valor);

            bool isAuthorize = await _authorizeService.Authorize();

            if (!isAuthorize)
                throw new UnauthorizedAccessException("Sem autorização para processar a transferência.");


            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _usuarioService.SalvarUsuario(remetente);
                    await _usuarioService.SalvarUsuario(recebedor);
                    await _transactionRepository.SaveTransaction(transaction);

                    transactionScope.Complete();
                }
                catch
                {
                    throw;
                }
            }


            _notificacaoService.Enviar(recebedor); //TODO: Implementar um serviço de messageria (instabilidade em notificação não deve ocorrer rollback nas transações)
        }

        private void ValidarTransacao(Usuario remetente, decimal valor)
        {
            if (remetente.TipoConta is TipoContaEnum.Lojista)
                throw new TransacaoExceptionValidation("Lojistas não estão autorizados a realizar transação");

            if (valor > remetente.Saldo)
                throw new TransacaoExceptionValidation("Valor da transação superior ao saldo");

        }

    }
}

