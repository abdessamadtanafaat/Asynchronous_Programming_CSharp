namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool.E_commerce_System;

// handle the execution of tasks for each order.
// coordinating the execution of order tasks in parallel. 
public class OrderProcessor
{
    private readonly CountdownEvent _countdownEvent; // used for synchronizing tasks , ensure all tasks ends before the app exit.
    private readonly IOrderTask[] _tasks; // array of task : validation , packing , shipping  . 

    public OrderProcessor(int taskCount, IOrderTask[] tasks)
    {
        _countdownEvent = new CountdownEvent(taskCount); // initialise the countdown with the number of tasks. 
        _tasks = tasks; // initialise task array .
    }

    // take  orderState and processes it by executing each task (validation , pack , ship) in parallel. 
    public void ProcessOrder(OrderState orderState)
    {
        // itereate over each task (validation , pack , ship) and queue them for execution in parallel.
        foreach (var task in _tasks)
        {
            // Queue each task to be executed by a thread from the threadPool, passing the orderState along with the task to the executeTask method
            ThreadPool.QueueUserWorkItem(ExecuteTask, new Tuple<IOrderTask, OrderState>(task, orderState)); 
            
        }
    }

    // executeTask method processes the order task and signals the completion of the task
    public void ExecuteTask(object state)
    {
        //extract the task and the orderState from the tuple.
        var tuple = (Tuple<IOrderTask, OrderState>)state;
        var task = tuple.Item1;
        var orderState = tuple.Item2; 
        
        task.Process(orderState); // execute the task (validation , pack or ship.)
        _countdownEvent.Signal(); // signal when a task is completed. (decrement the countdown)
    }

    public void WaitForCompletion()
    {
        _countdownEvent.Wait(); // WAIT until all tasks are completed. reaches zero . 
        Console.WriteLine("All orders processed.");
    }
}