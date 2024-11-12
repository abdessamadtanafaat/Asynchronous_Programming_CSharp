using System.Diagnostics;

namespace Asynchronous_Programming_CSharp;

public class Program
{
    private static readonly WeatherService _weatherService = new WeatherService();

    static void Main(String[] args)
    {
        int threadCount = 10; // number of concurrent requests. 
        
        Console.WriteLine("Using Thread:");
        MeasurePerformanceUsingThreads(threadCount); 
        
        Console.WriteLine("\n Using ThreadPool: ");
        MeasurePerformanceUsingThreadsPool(threadCount); 
    }

    private static void MeasurePerformanceUsingThreads(int threadCount)
    {
        Thread[] threads = new Thread[threadCount];
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            threads[i] = new Thread(FetchData); 
            threads[i].Start();
        }
        
        foreach (Thread thread in threads) {
            thread.Join(); 
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Total Time (Thread): {stopwatch.ElapsedMilliseconds} ms");
    }

    private static void MeasurePerformanceUsingThreadsPool(int threadCount)
    {
        CountdownEvent countdown = new CountdownEvent(threadCount);
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                FetchData();
                countdown.Signal();
            });
        }

        countdown.Wait();
        stopwatch.Stop(); 
        Console.WriteLine($"Total Time (ThreadPool): {stopwatch.ElapsedMilliseconds} ms");
    }

    private static void FetchData()
    {
        var data = _weatherService.FetchWeatherData(); 
        Console.WriteLine("Data fetched successfully.");
    }
}