using CsharpDotNetDemo.Models;

namespace CsharpDotNetDemo.Services;

public class PremiumProcessor : IOrderProcessor
{
    public string Process(Order order)
        => $"Premium Order Processed: {order.Amount}";
}