using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using picpay_desafio_backend.Application.DTOs;
using picpay_desafio_backend.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace picpay_desafio_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TransactionController : Controller
    {

        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> transfer([FromBody]TransactionDTO transsactionDto)
        {
            try
            {

                if (!ModelState.IsValid)
                    throw new Exception("Dados fornecidos incorretamente");

                    await _transactionService.CreateTransactionAsync(transsactionDto);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

