using Amazon.Lambda.Core;
using System.Collections;
using Amazon.Lambda.APIGatewayEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
        public ArrayList getTasks(APIGatewayProxyRequest request)
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

            return tasks;
        }
    }

    public class Task
    {
        public string TaskId { get; }
        public string Description { get; }

        public bool Completed { get; }

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
