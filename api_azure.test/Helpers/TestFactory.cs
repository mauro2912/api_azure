using api_azure.common.Models;
using api_azure.functions.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace api_azure.test.Helpers
{
    public class TestFactory
    {
        public static TodoEntity GetTodoEntity()
        {
            return new TodoEntity
            {
                ETag = "*",
                PartitionKey = "TODO",
                RowKey = Guid.NewGuid().ToString(),
                CreateTime = DateTime.UtcNow,
                IsCompleted = false,
                TaskDescription = "kill the humans"
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Guid TodoId, Todo todoRequest)
        {
            string request = JsonConvert.SerializeObject(todoRequest);
            return new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamfromstring(request),
                Path = $"/{TodoId}"
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Guid TodoId)
        {
            return new DefaultHttpRequest(new DefaultHttpContext())
            {
                Path = $"/{TodoId}"
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Todo todoRequest)
        {
            string request = JsonConvert.SerializeObject(todoRequest);
            return new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamfromstring(request),
            };
        }

        public static DefaultHttpRequest CreateHttpRequest()
        {
            return new DefaultHttpRequest(new DefaultHttpContext());
        }

        public static Todo GetTodoRequest()
        {
            return new Todo
            {
                CreateTime = DateTime.UtcNow,
                IsCompleted = false,
                TaskDescription = "Try to conquer the world"
            };
        }

        public static Stream GenerateStreamfromstring(string string2Convert)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(string2Convert);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;
            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null logger");
            }

            return logger;
        }
    }
}
