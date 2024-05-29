using System;
using picpay_desafio_backend.Domain.Entities;

namespace picpay_desafio_backend.Application.Interfaces
{
	public interface INotificacaoService
	{
		public Task<bool> Enviar(Usuario usuario);
	}
}

