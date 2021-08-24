using System;
using System.Collections.Generic;
using System.Text;

namespace api_azure.common.Models
{
    public class Todo
    {
        public DateTime CreateTime { get; set; }

        public string TaskDescription { get; set; }

        public bool IsCompleted { get; set; }
    }
}
