using System;
using picpay_desafio_backend.Application.DTOs;

namespace picpay_desafio_backend.Application.Interfaces
{
	public interface ITransactionService
	{
        public Task CreateTransactionAsync(TransactionDTO transactionDto);
    }
}

