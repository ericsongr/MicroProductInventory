var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Ericson", "Ramos", "Gonzaga", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/me-weather", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapGet("/family", () =>
{
    var family = new List<MyFamily> { 
        new MyFamily{
            Id = 1,
            FirstName = "Eldric",
            SecondName = "Gesua",
            Age = 13
        },
        new MyFamily{
            Id = 2,
            FirstName = "Gidion",
            SecondName = "Neal",
            Age = 6
        },
        new MyFamily{
            Id = 3,
            FirstName = "Garet",
            SecondName = "Glaiza",
            Age = 2
        },
        new MyFamily{
            Id = 4,
            FirstName = "Eric",
            SecondName = "Son",
            Age = 38
        },
        new MyFamily{
            Id = 5,
            FirstName = "Sherine",
            SecondName = "Grace",
            Age = 35
        },

    };

    return family;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class MyFamily {
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public int Age { get; set; }
}
