using System;
using picpay_desafio_backend.Domain.Entities;

namespace picpay_desafio_backend.Domain.Interfaces
{
	public interface IUsuarioRepository
	{
		public Task<Usuario> GetUsuarioByCpf(string cpf);
		public Task<Usuario> GetUsuarioById(int id);
		public Task SalvarUsuario(Usuario usuario);
        public Task RemoveAll();
    }
}

