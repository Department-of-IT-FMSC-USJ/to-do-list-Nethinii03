using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class TaskNode
    {
        public string TaskName { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public TaskNode Next { get; set; }

        public TaskNode(string taskName, int id, string description, DateTime date)
        {
            TaskName = taskName;
            ID = id;
            Description = description;
            Date = date;
            Status = "To Do";
            Next = null;
        }
    }

}
