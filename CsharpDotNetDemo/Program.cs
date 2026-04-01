using CsharpDotNetDemo.Models;
using CsharpDotNetDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Keyed DI
builder.Services.AddKeyedScoped<IOrderProcessor, PremiumProcessor>("premium");
builder.Services.AddKeyedScoped<IOrderProcessor, StandardProcessor>("standard");

builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Base
app.MapGet("/", () => "Modern .NET Demo Running");

// Primary Constructor
app.MapGet("/primary", (OrderService s) => s.GetPrimaryOrder());

// Pattern Matching
app.MapGet("/orders", (OrderService s) =>
    s.GetOrders().Select(o => new
    {
        o.Customer,
        Category = s.GetCategory(o)
    }));

// Merge
app.MapGet("/merge", (OrderService s) => s.MergeOrders());

// Pattern advanced
app.MapGet("/check", (OrderService s) =>
    s.CheckObject(new Order("A", 1500)));

// List Pattern Matching
app.MapGet("/list-pattern", (OrderService s) =>
    s.CheckNumbers([1, 2, 3]));

// With
app.MapGet("/discount", (OrderService s) =>
    s.ApplyDiscount(new Order("Ankit", 1200)));

// Spread operator
app.MapGet("/spread", (OrderService s) => s.MergeNumbers());

// Span
app.MapGet("/total", (OrderService s) => s.CalculateTotal());

// Collection expression demo
app.MapGet("/numbers", (OrderService s) => s.GetNumbers());

// Keyed DI
app.MapGet("/process/{type}", (string type, IServiceProvider sp) =>
{
    var processor = sp.GetRequiredKeyedService<IOrderProcessor>(type);
    return processor.Process(new Order("Demo", 1500));
});

// JSON
app.MapGet("/json", (OrderService s) => s.GetPrettyJson());

app.Run();