﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityServer.Client1.Models;
using IdentityServer.Client1.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;

namespace IdentityServer.Client1.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiResourceHttpClient _apiResourceHttpClient;

        public ProductController(IConfiguration configuration, IApiResourceHttpClient apiResourceHttpClient)
        {
            _configuration = configuration;
            _apiResourceHttpClient = apiResourceHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = await _apiResourceHttpClient.GetHttpClient();
            List<Product> products = new List<Product>();
            

            //HttpClient httpClient = new HttpClient();

            //var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            //var discovery = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");
            //if(discovery.IsError)
            //{
            //    // loglama yap
            //}

            //ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();

            //clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];
            //clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            //clientCredentialsTokenRequest.Address = discovery.TokenEndpoint;

            //var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);

            //if (token.IsError)
            //{
            //    // loglama yap
            //}

            //httpClient.SetBearerToken(token.AccessToken);

            //httpClient.SetBearerToken(accessToken);

            var response = await client.GetAsync("https://localhost:5007/api/product/getproducts");


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            else
            {

            }

            return View(products);
        }
    }
}
