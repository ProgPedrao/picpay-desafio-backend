using System;
using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Domain.Entities;
using picpay_desafio_backend.Domain.Interfaces;
using picpay_desafio_backend.Infra.Data.Context;

namespace picpay_desafio_backend.Infra.Data.Repositories
{
	public class TransactionRepository : ITransactionRepository
	{

        private readonly ApplicationDbContext _context;


        public TransactionRepository(ApplicationDbContext context)
		{
            _context = context;
        }

        public async Task SaveTransaction(Transacao transaction)
        {
            _context.Add(transaction);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAll()
        {
            var data = await _context.Transactions.ToListAsync();
            _context.RemoveRange(data);

            await _context.SaveChangesAsync();
        }

    }
}

