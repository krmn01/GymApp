using GymApp.Api;
using GymApp.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace GymApp.IntegrationTests.Controllers.Class
{
    public class ClassControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public ClassControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetUserClasses_UnauthorizedUser_ReturnsUnauthorized()
        {
            var response = await _client.GetAsync("/api/Class/users-classes");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task GetUserClasses_CorrectData_ReturnsOK()
        {
            var token = await IntegrationTestingHelper.Login(_client);
           _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync("/api/Class/users-classes");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }
    }
}
