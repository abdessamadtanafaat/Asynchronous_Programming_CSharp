namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool;

public class Program
{
    public static void Main()
    {
        int taskCount = 5;

        using (CountdownEvent countdownEvent = new CountdownEvent(taskCount))
        {
        Console.WriteLine("Starting tasks...");
        
        // Queue multiple tasks with different state information
        for (int i = 1; i <= taskCount; i++)
        {
            var taskState = new TaskState
            {
                TaskId = i,
                TaskDescription = $"Task number {i} - processing data."
            }; 
            
            // Queue the task with its state object and countdown event.
            ThreadPool.QueueUserWorkItem(state =>
            {
                TaskWorker.ProcessTask(state);
                countdownEvent.Signal(); // Decrement the countdown once the task is complete.
            }, taskState);
            
        }

        // wait until all tasks have finished. 
        countdownEvent.Wait(); 
        
        }
        Console.ReadKey(); 

    }
}