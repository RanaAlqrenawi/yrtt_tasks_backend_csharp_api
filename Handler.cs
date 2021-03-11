using Amazon.Lambda.Core;
using System.Collections;
using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
        public APIGatewayProxyResponse getTasks(APIGatewayProxyRequest request)
        {
            string userId = request.PathParameters["userId"];
            LambdaLogger.Log("Getting tasks for:" + userId);

            ArrayList tasks = new ArrayList();

            if (userId == "1234")
            {
                Task t1 = new Task("1234", " Make milk!", false);
                tasks.Add(t1);
            }
            else
            {
                Task t2 = new Task("5678", " Change the nappy!", true);
                Task t3 = new Task("9101", " Clean the kitchen!", false);

                tasks.Add(t2);
                tasks.Add(t3);
            }

            return new APIGatewayProxyResponse
            {
                Body = JsonSerializer.Serialize(tasks),
                Headers = new Dictionary<string, string>
        {
            { "Content-Type", "application/json" },
            { "Access-Control-Allow-Origin", "*" },
        },
                StatusCode = 200,

            };
        }


        public APIGatewayProxyResponse saveTasks(APIGatewayProxyRequest request)
        {

            string requestBody = request.Body;
            Task t = JsonSerializer.Deserialize<Task>(request.Body);
            LambdaLogger.Log("Tasks saved:" + t.Description);

            return new APIGatewayProxyResponse
            {
                Body = "Task Saved",
                Headers = new Dictionary<string, string>
        {
            { "Content-Type", "application/json" },
            { "Access-Control-Allow-Origin", "*" },
        },
                StatusCode = 200,

            };
        }


    }

    public class Task
    {
        public string TaskId { get; set; }
        public string Description { get; set; }

        public bool Completed { get; set; }

        public Task() { }

        public Task(string taskId, string description, bool completed)
        {
            TaskId = taskId;
            Description = description;
            Completed = completed;
        }
    }

    public class Request
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
    }
}
