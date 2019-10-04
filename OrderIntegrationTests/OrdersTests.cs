using Newtonsoft.Json;
using OrdersAPI;
using OrdersModel.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderIntegrationTests
{
    public class OrdersTests : IClassFixture<TestSetting<Startup>>
    {

        private HttpClient Client;

        public OrdersTests(TestSetting<Startup> fixture)
        {
            Client = fixture.Client;
           
        }
        private async Task Login()
        {
            var user = new
            {
                Password = "admin",
                Username = "admin"
            };
         
            var request = "api/v1/Authorization/token";
            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(user));
            if (response.Content != null)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                var token = "";
                if (result.ContainsKey("access_token"))
                {
                    token = result["access_token"];
                }
                if (!string.IsNullOrEmpty(token))
                {
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
        }

        [Fact]
        public async Task TestGetOrdersAsync()
        {
           await Login();
            // Arrange
            var request = "api/v1/Order";
            //Act
            var responseGet = await Client.GetAsync(request);
            //Asset
            responseGet.EnsureSuccessStatusCode();



        }
        [Fact]
        public async Task TestGetOrderByIDAsync()
        {
            await Login();
            // Arrange
            var request = "api/v1/Order/1";
            //Act
            var responseGet = await Client.GetAsync(request);
            //Asset
            responseGet.EnsureSuccessStatusCode();


        }

        [Fact]
        public async Task TestPostOrderAsync()
        {
            await Login();
            // Arrange
            var request = "api/v1/Order/";
            var order = new 
            {
                DeliveryAddress = "test 5",
                OrderItems = new List<Object>() {
                   new {
                       ProductID =123,
                       Qty=3 ,
                       UnitPrice= 10
                   },
                   new {
                         ProductID =33,
                       Qty= 1 ,
                       UnitPrice=15.5M
                   }
                   ,
                   new {
                         ProductID =1233,
                       Qty= 2 ,
                       UnitPrice=10
                   }
               }

            };
            //Act
            var responseGet = await Client.PostAsync(request, ContentHelper.GetStringContent(order));
            //Asset
            responseGet.EnsureSuccessStatusCode();


        }

        [Fact]
        public async Task TestPostInvalidOrderQtyAsync()
        {
            await Login();
            // Arrange
            var request = "api/v1/Order/";
            var order = new
            {
                DeliveryAddress = "test 5",
                OrderItems = new List<Object>() {
                   new {
                       ProductID =123,
                       Qty=11 ,
                       UnitPrice= 1
                   },
                   new {
                         ProductID =33,
                       Qty= 1 ,
                       UnitPrice=1
                   }
                   ,
                   new {
                         ProductID =1233,
                       Qty= 2 ,
                       UnitPrice=1
                   }
               }

            };
            //Act
            var responseGet = await Client.PostAsync(request, ContentHelper.GetStringContent(order));
            //Asset
            Assert.Equal(responseGet.StatusCode.ToString(), HttpStatusCode.BadRequest.ToString());


        }

        [Fact]
        public async Task TestPostInvalidOrderUnitPriceAsync()
        {
            await Login();
            // Arrange
            var request = "api/v1/Order/";
            var order = new
            {
                DeliveryAddress = "test 5",
                OrderItems = new List<Object>() {
                   new {
                       ProductID =123,
                       Qty=4 ,
                       UnitPrice= 10
                   },
                   new {
                         ProductID =33,
                       Qty= 1 ,
                       UnitPrice=50
                   }
                   ,
                   new {
                         ProductID =1233,
                       Qty= 2 ,
                       UnitPrice=10
                   }
               }

            };
            //Act
            var responseGet = await Client.PostAsync(request, ContentHelper.GetStringContent(order));
            //Asset
            Assert.Equal(responseGet.StatusCode.ToString(), HttpStatusCode.BadRequest.ToString());


        }






    }
}
