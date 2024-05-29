using System;
using picpay_desafio_backend.Domain.Interfaces;

namespace picpay_desafio_backend.Infra.Data.Seed
{
	public interface ISeedTransactions
	{
        public void removeTransactions();
    }
}

