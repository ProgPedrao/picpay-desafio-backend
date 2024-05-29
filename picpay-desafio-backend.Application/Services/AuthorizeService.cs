using System;
using System.Net.Http.Json;
using picpay_desafio_backend.Application.DTOs;
using picpay_desafio_backend.Application.Interfaces;

namespace picpay_desafio_backend.Application.Services
{
	public class AuthorizeService : IAuthorizeService
	{

        private readonly HttpClient _httpClient;


        public AuthorizeService()
		{
            _httpClient = new HttpClient();
        }

        public async Task<bool> Authorize()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://util.devi.tools/api/v2/authorize");

                if (response.IsSuccessStatusCode)
                {
                    var authorizationResult = await response.Content.ReadFromJsonAsync<AuthorizationResponse>();
                    if (authorizationResult.data.authorization)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

