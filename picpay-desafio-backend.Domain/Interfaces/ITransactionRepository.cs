using System;
using picpay_desafio_backend.Domain.Entities;

namespace picpay_desafio_backend.Domain.Interfaces
{
	public interface ITransactionRepository
	{
		public Task SaveTransaction(Transacao transaction);
		public Task RemoveAll();
    }
}

