using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using picpay_desafio_backend.Domain.Entities;

namespace picpay_desafio_backend.Infra.Data.EntitiesConfiguration
{
	public class TransactionsConfiguration : BaseEntityConfiguration<Transacao>
	{

        public override void ConfigureEntity(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("TRANSACTIONS");

            builder.Property(a => a.Remetente)
               .IsRequired();

            builder.Property(a => a.Receptor)
               .HasMaxLength(14)
               .IsRequired();

            builder.Property(a => a.Data)
               .HasMaxLength(70)
               .IsRequired();

            builder.Property(a => a.Valor)
               .HasPrecision(18, 2)
               .IsRequired();
        }
    }
}

