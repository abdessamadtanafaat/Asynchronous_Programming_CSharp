namespace Asynchronous_Programming_CSharp.StateObject_ThreadPool.E_commerce_System;

public interface IOrderTask
{
    // Method to precess the order.
    void Process(OrderState orderState); 
}