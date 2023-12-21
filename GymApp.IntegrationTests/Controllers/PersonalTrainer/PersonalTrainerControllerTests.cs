using GymApp.Api;
using GymApp.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.IntegrationTests.Controllers.PersonalTrainer
{
    public class PersonalTrainerControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public PersonalTrainerControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetTrainers_UnauthorizedUser_ReturnsUnauthorized()
        {
            var response = await _client.GetAsync("/api/PersonalTrainer/get-all");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task GetTrainers_CorrectData_ReturnsOK()
        {
            var token = await IntegrationTestingHelper.Login(_client);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync("/api/GymPass/prices");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }
    }
}
