using System;
using picpay_desafio_backend.Domain.Interfaces;
using picpay_desafio_backend.Infra.Data.Repositories;

namespace picpay_desafio_backend.Infra.Data.Seed
{
	public class SeedTransactions : ISeedTransactions
    {
        private readonly ITransactionRepository _transactionRepository;


        public SeedTransactions(ITransactionRepository transactionRepository)
		{
            _transactionRepository = transactionRepository;
        }

        public void removeTransactions()
        {
            _transactionRepository.RemoveAll().Wait();
        }

    }
}

