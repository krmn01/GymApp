using GymApp.Api;
using GymApp.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.IntegrationTests.Controllers.Authentication
{
    public class AuthenticationControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public AuthenticationControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }


        [Fact]
        public async Task Login_CorrectData_ReturnsOK()
        {
            var content = IntegrationTestingHelper.PrepareContent(new { email = "adm@adm.pl", password = "Password1!" });
            var response = await _client.PostAsync("/api/Authentication/login", content);
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login_CorrectData_ReturnsInternalError()
        {
            var content = IntegrationTestingHelper.PrepareContent(new { email = "adm@adm.pl", password = "incorrect" });
            var response = await _client.PostAsync("/api/Authentication/login", content);
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
