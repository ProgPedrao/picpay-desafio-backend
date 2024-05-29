using System;
using picpay_desafio_backend.Domain.Entities.Enums;
using picpay_desafio_backend.Domain.Exceptions;

namespace picpay_desafio_backend.Domain.Entities
{
	public sealed class Transacao : BaseEntity
	{

        public decimal Valor { get; private set; }
        public string Remetente { get; private set; }
        public string Receptor { get; private set; }
        public DateTime Data { get; private set; }

        public Transacao(decimal valor, string remetente, string receptor)
        {
            Validar(valor, remetente, receptor);
            Salvar(valor, remetente, receptor);
        }

        private void Validar(decimal valor, string remetente, string receptor)
        {
            DomainExceptionValidation.When(valor <= 0, "Valor inválido. campo não pode ser negativo");

            DomainExceptionValidation.When(string.IsNullOrEmpty(remetente), "Remetente inválido. campo obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(receptor), "Receptor inválido. campo obrigatório");
        }

        private void Salvar(decimal valor, string remetente, string receptor)
        {
            Valor = valor;
            Remetente = remetente;
            Receptor = receptor;
            Data = DateTime.Now;
        }

    }
}

