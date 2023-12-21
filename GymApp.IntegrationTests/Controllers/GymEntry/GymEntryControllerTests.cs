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

namespace GymApp.IntegrationTests.Controllers.GymEntry
{
    public class GymEntryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public GymEntryControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetRank_UnauthorizedUser_ReturnsUnauthorized()
        {
            var response = await _client.GetAsync("/api/GymEntry/get-rank");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task GetRank_CorrectData_ReturnsOK()
        {
            var token = await IntegrationTestingHelper.Login(_client);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync("/api/GymEntry/get-rank");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }
    }
}
