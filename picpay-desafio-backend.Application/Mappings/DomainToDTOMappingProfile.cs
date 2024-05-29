using System;
using AutoMapper;
using picpay_desafio_backend.Application.DTOs;
using picpay_desafio_backend.Domain.Entities;

namespace picpay_desafio_backend.Application.Mappings
{
	public class DomainToDTOMappingProfile : Profile
	{
		public DomainToDTOMappingProfile()
		{
            CreateMap<TransactionDTO, Transacao>()
				.ConstructUsing(dto => new Transacao(dto.Valor, dto.Remetente, dto.Receptor)).ReverseMap();
        }
	}
}

