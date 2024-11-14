namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool.E_commerce_System;

public class Program
{
    public static void Main()
    {
        
        // creating tasks 
        IOrderTask[] tasks = { new ValidateOrder(), new PackOrder(), new ShipOrder() }; 
        
        // creating order states 
        var orders = new[]
        {
            new OrderState { OrderId = 1, Description = "Order 1" },
            new OrderState { OrderId = 2, Description = "Order 2" },
            new OrderState { OrderId = 3, Description = "Order 3" }
        };

        var orderProcessor = new OrderProcessor(orders.Length * tasks.Length, tasks);
        Console.WriteLine("Starting order processing ... ");
        
        // process each order in parallel
        foreach (var order in orders)
        {
            orderProcessor.ProcessOrder(order);
        }
        // wait for all tasks to complete.
        
        orderProcessor.WaitForCompletion();
        Console.WriteLine("Press Any key to exit.");
        Console.ReadKey(); 
    }
}