using System;
namespace picpay_desafio_backend.Application.DTOs
{
	public class AuthorizationResponse
	{
		public string status { get; set; }
		public Data data { get; set; }
	}

    public class Data
	{
		public bool authorization { get; set; }
	}
}

