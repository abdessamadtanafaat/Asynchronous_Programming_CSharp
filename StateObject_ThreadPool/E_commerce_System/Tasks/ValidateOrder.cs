namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool.E_commerce_System;


//step 1 from the preocess customer orders : validation . 
public class ValidateOrder : IOrderTask
{
    public void Process(OrderState orderState)
    {
        orderState.Status = "Validating"; 
        Console.WriteLine($"{orderState.OrderId} : {orderState.Description}");
        Thread.Sleep(1000); // simulate processing delay (metier)
        Console.WriteLine($"{orderState.OrderId} completed validation.");
    }
}