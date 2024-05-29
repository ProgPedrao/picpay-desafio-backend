using System;
using System.ComponentModel.DataAnnotations;

namespace picpay_desafio_backend.Application.DTOs
{
	public record TransactionDTO
	{
        [Required(ErrorMessage = "Valor is Required")]
        [DataType(DataType.Currency)]
        public required decimal Valor { get; init; }

        [Required(ErrorMessage = "Remetente is Required")]
        public required string Remetente { get; init; }

        [Required(ErrorMessage = "Recebedor is Required")]
        public required string Receptor { get; init; }
	}
}

