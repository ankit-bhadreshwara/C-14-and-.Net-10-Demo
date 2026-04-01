namespace CsharpDotNetDemo.Models;

// Record → required for "with" expression
public record Order(string Customer, decimal Amount);