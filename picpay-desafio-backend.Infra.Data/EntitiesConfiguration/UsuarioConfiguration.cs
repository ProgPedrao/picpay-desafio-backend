using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using picpay_desafio_backend.Domain.Entities;
using picpay_desafio_backend.Domain.Entities.Enums;

namespace picpay_desafio_backend.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : BaseEntityConfiguration<Usuario>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.Property(a => a.Nome)
               .HasMaxLength(70)
               .IsRequired();

            builder.Property(a => a.CPF)
               .HasMaxLength(14)
               .IsRequired();

            builder.Property(a => a.Email)
               .HasMaxLength(70)
               .IsRequired();

            builder.Property(a => a.Senha)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(a => a.TipoConta)
               .HasConversion(
                v => v.ToString(),
                v => (TipoContaEnum)Enum.Parse(typeof(TipoContaEnum), v))
               .IsRequired();

            builder.Property(a => a.Saldo)
               .HasPrecision(18, 2)
               .IsRequired();

        }
    }
}

