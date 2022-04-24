using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using NUnit.Framework;
using Places.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Places.Steps
{
    [Binding]
    public class CreateAPlaceSteps
    {
        HttpClient httpClient;
        Task<HttpResponseMessage> httpResponse;
        string url = "https://rahulshettyacademy.com/maps/api/place/add/json";
        private ScenarioContext _scenarioContext;

        public CreateAPlaceSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"the place details")]
        public void GivenThePlaceDetails(Createplace createplace)
        {
            _scenarioContext["createplace"] = createplace;
        }

        [Given(@"the location details")]
        public void GivenTheLocationDetails(Location location)
        {
            Createplace createplace = _scenarioContext.Get<Createplace>("createplace");
            createplace.location = location;
        }

        [When(@"the location details are passed")]
        public void WhenTheLocationDetailsArePassed()
        {
            httpClient = new HttpClient();
            string postContent = JsonConvert.SerializeObject(_scenarioContext.Get<Createplace>("createplace"));
            var sc = new StringContent(postContent);
            sc.Headers.Clear();
            sc.Headers.Add("content-type", "application/json");
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("key", "qaclick123");
            httpResponse = httpClient.PostAsync(QueryHelpers.AddQueryString(url, query), sc);
            Console.WriteLine(httpResponse.Result.Content.ReadAsStringAsync().Result);
        }

        [Then(@"the status should be (.*)")]
        public void ThenTheStatusShouldBe(int expectedStatusCode)
        {
            int actualStatusCode = (int)httpResponse.Result.StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }
    }
}
