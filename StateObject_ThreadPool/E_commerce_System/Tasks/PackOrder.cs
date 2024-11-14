namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool.E_commerce_System;

// step 2 : 
public class PackOrder : IOrderTask
{
    public void Process(OrderState orderState)
    {
        orderState.Status = "Packing";
        Console.WriteLine($"{orderState.OrderId} : {orderState.Description}"); 
        Thread.Sleep(1000); // simulate processing delay for packaging 
        Console.WriteLine($"{orderState.OrderId} completed packing.");
    }
}