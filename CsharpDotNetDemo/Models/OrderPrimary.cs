namespace CsharpDotNetDemo.Models;

// C# 14 Primary Constructor (class)
public class OrderPrimary(string customer, decimal amount)
{
    public  string Customer { get; } = customer;
    public decimal Amount { get; } = amount;
}

/*
OLD WAY:

public class Order
{
    public string Customer { get; }
    public decimal Amount { get; }

    public Order(string customer, decimal amount)
    {
        Customer = customer;
        Amount = amount;
    }
}
*/