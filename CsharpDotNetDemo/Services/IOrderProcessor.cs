using CsharpDotNetDemo.Models;

namespace CsharpDotNetDemo.Services;

public interface IOrderProcessor
{
    string Process(Order order);
}