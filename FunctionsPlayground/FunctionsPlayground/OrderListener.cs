using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionsPlayground.Models;

namespace FunctionsPlayground
{
    public static class OrderListener
    {
        [FunctionName(Constants.OrderListenerFunctionName)]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [OrchestrationClient] DurableOrchestrationClientBase starter,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // To test out code deployment from github
            return new OkObjectResult("Hello!");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            FoodOrderRequest foodOrderRequest;
            try
            {
                foodOrderRequest = JsonConvert.DeserializeObject<FoodOrderRequest>(requestBody);
            }
            catch(Exception ex)
            {
                log.LogWarning(ex, $"Bad request body: {requestBody}");
                return new BadRequestResult();
            }

            var order = new FoodOrder(foodOrderRequest);
            order.OrderId = Guid.NewGuid();
            string instanceId = await starter.StartNewAsync(Constants.RoboChefsOrchestratorFunctionName, order);

            return new OkObjectResult($"{order.OrderId}");
        }
    }
}