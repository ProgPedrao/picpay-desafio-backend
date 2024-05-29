using System;
namespace picpay_desafio_backend.Application.Interfaces
{
	public interface IAuthorizeService
	{
		public Task<bool> Authorize();
	}
}

