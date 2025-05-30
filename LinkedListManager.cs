using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class LinkedListManager
    {
        public TaskNode ToDoHead = null;
        public TaskNode InProgressTop = null;
        public TaskNode CompletedFront = null, CompletedRear = null;

        public void AddToDo(TaskNode newTask)
        {
            if (ToDoHead == null || newTask.Date < ToDoHead.Date)
            {
                newTask.Next = ToDoHead;
                ToDoHead = newTask;
            }
            else
            {
                TaskNode current = ToDoHead;
                while (current.Next != null && current.Next.Date < newTask.Date)
                {
                    current = current.Next;
                }
                newTask.Next = current.Next;
                current.Next = newTask;
            }
        }

        public void MoveToInProgress(int id)
        {
            TaskNode prev = null, current = ToDoHead;

            while (current != null && current.ID != id)
            {
                prev = current;
                current = current.Next;
            }

            if (current == null)
            {
                Console.WriteLine("Task not found in To Do list.");
                return;
            }

            if (prev == null)
                ToDoHead = current.Next;
            else
                prev.Next = current.Next;

            current.Status = "In Progress";
            current.Next = InProgressTop;
            InProgressTop = current;
        }

        public void MoveToCompleted()
        {
            if (InProgressTop == null)
            {
                Console.WriteLine("No task in In Progress list.");
                return;
            }

            TaskNode task = InProgressTop;
            InProgressTop = InProgressTop.Next;

            task.Status = "Completed";
            task.Next = null;

            if (CompletedFront == null)
            {
                CompletedFront = CompletedRear = task;
            }
            else
            {
                CompletedRear.Next = task;
                CompletedRear = task;
            }
        }

        public void DisplayList(TaskNode head, string listName)
        {
            Console.WriteLine($"\n{listName} Tasks:");
            if (head == null)
            {
                Console.WriteLine("  (Empty)");
                return;
            }

            TaskNode current = head;
            while (current != null)
            {
                Console.WriteLine($"ID: {current.ID}, Name: {current.TaskName}, Date: {current.Date.ToShortDateString()}, Status: {current.Status}");
                current = current.Next;
            }
        }
    }

}

