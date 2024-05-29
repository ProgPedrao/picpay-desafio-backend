using System;
using picpay_desafio_backend.Domain.Entities;
using picpay_desafio_backend.Domain.Interfaces;
using picpay_desafio_backend.Infra.Data.Repositories;

namespace picpay_desafio_backend.Infra.Data.Seed
{
	public class SeedUsers : ISeedUsers
    {

		private readonly IUsuarioRepository _usuarioRepository;

		public SeedUsers(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public void removeUsers()
		{
			_usuarioRepository.RemoveAll().Wait();
        }

		public void seedUsers()
		{
			Usuario usuario = new Usuario(
				"Pedro",
                "620.132.290-62",
				"pedro@gmail.com",
				"123456",
				Domain.Entities.Enums.TipoContaEnum.Usuario,
				1000
			);

            Usuario usuario2 = new Usuario(
                "Lojista",
                "030.645.690-74",
                "lojista@gmail.com",
                "123456",
                Domain.Entities.Enums.TipoContaEnum.Lojista,
                1000
            );

            _usuarioRepository.SalvarUsuario(usuario).Wait();
            _usuarioRepository.SalvarUsuario(usuario2).Wait();

        }

	}
}

