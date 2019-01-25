﻿/// <summary>
/// Integration test using XUnit and FluentAssertions
/// </summary>
namespace XUnitIntegrationTest
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;
    using FluentAssertions;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Text;
    using ModelClasses;
    using System;

    /// <summary>Integration test on the web api</summary>
    public class IntegrationTestModelClassAPI
    {
        /// <summary>Testing for response type</summary>
        /// <param name="httpStatusCode"></param>
        [Theory]
        [InlineData(HttpStatusCode.OK)]
        public async Task TestForResponseType(HttpStatusCode httpStatusCode)
        {
            //Arrange
            using (var client = new TestClientProvider().Client)
            {
                //Act
                var response = await client.GetAsync("/api/calc");
                response.EnsureSuccessStatusCode();
                //Assert
                response.StatusCode.Should().Be(httpStatusCode);
            }      
        }

        /// <summary>Testing for HttpStatusCode = "Not Found"</summary>
        //[Fact]
        //public async Task TestForNotFound()
        //{
        //    //Arrange
        //    using (var client = new TestClientProvider().Client)
        //    {
        //        //Act
        //        var response = await client.GetAsync("/api/calc");
        //        response.EnsureSuccessStatusCode();

        //        //Assert
        //        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //    }
        //}

        //[Fact]

        //[Theory]
        //[InlineData("GET")]
        //[InlineData("POST")]
        //public async Task TestPost(string method)
        //{
        //    //Arrange
        //    using (var client = new TestClientProvider().Client)
        //    {
        //        //Act
        //        //var Initial = DateTime.UtcNow;
        //        //var response = await client.PostAsync("/api/calc/add", new StringContent(
        //        //    JsonConvert.SerializeObject(new Calculator()), 
        //        //    Encoding.UTF8, "application/json"));
        //        //var dif = DateTime.UtcNow - Initial;

        //        //if (dif.TotalMilliseconds < 100)
        //        //{
        //        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //        //}

        //        //Assert
        //        //response.StatusCode.Should().Be(HttpStatusCode.OK);

        //        //var request = new HttpRequestMessage(new HttpMethod(method), "/");

        //        //var response = await client.SendAsync(request);

        //        //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //        //var content = await response.Content.ReadAsStringAsync();
        //        //Assert.Equal("", content);
        //        //Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        //    }
        //}
    }
}
