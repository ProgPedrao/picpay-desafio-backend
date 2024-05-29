using System;
using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Domain.Entities;
using picpay_desafio_backend.Domain.Interfaces;
using picpay_desafio_backend.Infra.Data.Context;

namespace picpay_desafio_backend.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByCpf(string cpf)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.CPF == cpf) ??
                throw new Exception("Usuário não encontrado");
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id) ??
                throw new Exception("Usuário não encontrado");
        }

        public async Task SalvarUsuario(Usuario usuario)
        {
            if (usuario.Id == 0)
                _context.Add(usuario);
            else
                _context.Update(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAll()
        {
            var data = await _context.Usuarios.ToListAsync();
            _context.RemoveRange(data);

            await _context.SaveChangesAsync();
        }
    }
}

