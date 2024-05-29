using System;
namespace picpay_desafio_backend.Domain.Entities
{
	public abstract class BaseEntity
	{

        public int Id { get; protected set; }

        public BaseEntity()
		{
		}
	}
}

