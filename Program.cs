using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListManager manager = new LinkedListManager();

            
            manager.AddToDo(new TaskNode("Task A", 101, "Read Book", new DateTime(2024, 6, 5)));
            manager.AddToDo(new TaskNode("Task B", 102, "Write Report", new DateTime(2024, 6, 2)));
            manager.AddToDo(new TaskNode("Task C", 103, "Prepare Slides", new DateTime(2024, 6, 10)));

            
            manager.DisplayList(manager.ToDoHead, "To Do");

            manager.MoveToInProgress(102);
            manager.DisplayList(manager.ToDoHead, "To Do");
            manager.DisplayList(manager.InProgressTop, "In Progress");

            
            manager.MoveToCompleted();
            manager.DisplayList(manager.InProgressTop, "In Progress");
            manager.DisplayList(manager.CompletedFront, "Completed");
        }
    }
}
