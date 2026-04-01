using CsharpDotNetDemo.Models;
using System.Text.Json;

namespace CsharpDotNetDemo.Services;

public class OrderService
{
    // --------------------------------------------
    // PRIMARY CONSTRUCTOR
    // --------------------------------------------
    public OrderPrimary GetPrimaryOrder()
    {
        return new OrderPrimary("Ankit", 1500);
    }
    public List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order("Ankit", 1200),
            new Order("Raj", 500),
            new Order("John", 2000)
        };
    }
    public int[] MergeNumbers()
    {
        int[] first = [1, 2, 3];
        int[] second = [4, 5, 6];

        // Spread operator → merges arrays
        return [.. first, .. second];
    }
    public List<Order> MergeOrders()
    {
        var baseOrders = new List<Order>
        {
            new Order("A", 100),
            new Order("B", 200)
        };

        var extraOrders = new List<Order>
        {
            new Order("C", 300)
        };
        return baseOrders.Concat(extraOrders).ToList();
    }

    public int[] GetNumbers() => [1, 2, 3, 4];

    public ReadOnlySpan<int> GetSpanData() => [10, 20, 30];

    // --------------------------------------------
    // PATTERN MATCHING
    // --------------------------------------------
    public string GetCategory(Order o) =>
        o switch
        {
            { Amount: > 1500 } => "VIP",
            { Amount: > 1000 } => "Premium",
            _ => "Standard"
        };

    public string GetDetailedCategory(Order o) =>
        o switch
        {
            { Amount: > 2000, Customer: "John" } => "Special VIP",
            { Amount: > 1500 } => "VIP",
            _ => "Standard"
        };

    public string CheckObject(object obj) =>
        obj switch
        {
            Order { Amount: > 1000 } => "High Value Order",
            Order => "Normal Order",
            string s when s.Length > 5 => "Long String",
            null => "Null Value",
            _ => "Unknown"
        };
    public string CheckNumbers(int[] numbers) =>
    numbers switch
    {
        [1, 2, 3] => "Exact Match",
        [1, ..] => "Starts with 1",
        _ => "Other"
    };
    // --------------------------------------------
    // WITH EXPRESSION
    // --------------------------------------------
    public Order ApplyDiscount(Order order) =>
        order with { Amount = order.Amount - 100 };

    // --------------------------------------------
    // SPAN (PERFORMANCE)
    // --------------------------------------------
    public decimal CalculateTotal()
    {
        ReadOnlySpan<decimal> amounts = [1200, 500, 2000];

        decimal total = 0;
        foreach (var a in amounts)
            total += a;

        return total;
    }

    // --------------------------------------------
    // JSON
    // --------------------------------------------
    public string GetJson() =>
        JsonSerializer.Serialize(GetOrders());

    public string GetPrettyJson()
    {
        return JsonSerializer.Serialize(GetOrders(),
            new JsonSerializerOptions { WriteIndented = true });
    }
}