using System;
using picpay_desafio_backend.Domain.Entities;

namespace picpay_desafio_backend.Application.Interfaces
{
	public interface IUsuarioService
	{
        public Task<Usuario> GetUsuarioByCpf(string cpf);
        public Task<Usuario> GetUsuarioById(int id);
        public Task SalvarUsuario(Usuario usuario);
    }
}

