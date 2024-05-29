using System;
using picpay_desafio_backend.Application.DTOs;
using System.Net.Http.Json;
using picpay_desafio_backend.Application.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using System.Text.Json.Serialization;
using picpay_desafio_backend.Domain.Entities;
using Newtonsoft.Json;

namespace picpay_desafio_backend.Application.Services
{
	public class NotificacaoService : INotificacaoService
	{

        private readonly HttpClient _httpClient;

        public NotificacaoService()
		{
            _httpClient = new HttpClient();
        }

        public async Task<bool> Enviar(Usuario usuario)
        {
            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://util.devi.tools/api/v1/notify", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

