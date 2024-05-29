using System;
using picpay_desafio_backend.Application.Interfaces;
using picpay_desafio_backend.Domain.Entities;
using picpay_desafio_backend.Domain.Entities.Enums;
using picpay_desafio_backend.Domain.Interfaces;

namespace picpay_desafio_backend.Application.Services
{
	public class UsuarioService : IUsuarioService
	{

		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioService(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            Usuario usuario = await _usuarioRepository.GetUsuarioById(id);
            return usuario;
        }

        public async Task<Usuario> GetUsuarioByCpf(string cpf)
        {
            Usuario usuario = await _usuarioRepository.GetUsuarioByCpf(cpf);
            return usuario;
        }

        public async Task SalvarUsuario(Usuario usuario)
        {
            await _usuarioRepository.SalvarUsuario(usuario);
        }
    }
}

