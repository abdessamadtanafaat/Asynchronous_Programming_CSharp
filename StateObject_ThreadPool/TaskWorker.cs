namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool;

public class TaskWorker
{
    public static void ProcessTask(object state)
    {
        if (state is TaskState taskState)
        {
            Console.WriteLine($"Processing Task ID: {taskState.TaskId}");
            Console.WriteLine($"Description: {taskState.TaskDescription}");
            // Simulate task work
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Task ID {taskState.TaskId} completed.\n");
        }
        else
        {
            Console.WriteLine("Invalid task state.");
        }
    }
}