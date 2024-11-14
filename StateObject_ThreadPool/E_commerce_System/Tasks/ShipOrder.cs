namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool.E_commerce_System;

public class ShipOrder : IOrderTask
{
    public void Process(OrderState orderState)
    {
        orderState.Status = "Shipping"; 
        Console.WriteLine($"{orderState.OrderId} : {orderState.Description}");
        Thread.Sleep(1000); // Simulate the processing delay for shipping.
        orderState.Status = "Shipped"; 
        Console.WriteLine($"{orderState.OrderId} completed shipping.");
    }
}