using CsharpDotNetDemo.Models;

namespace CsharpDotNetDemo.Services;

public class StandardProcessor : IOrderProcessor
{
    public string Process(Order order)
        => $"Standard Order Processed: {order.Amount}";
}