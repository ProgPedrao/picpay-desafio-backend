using System;
namespace picpay_desafio_backend.Domain.Exceptions
{
	public class TransacaoExceptionValidation : Exception
	{
		public TransacaoExceptionValidation(string error) : base(error)
		{

		}
	}
}

