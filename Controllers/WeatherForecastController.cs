using Microsoft.AspNetCore.Mvc;
using backendCSharp.Data;
using Microsoft.AspNetCore.Mvc;
using backendCSharp.Entity;

namespace backendCSharp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ColaboradorDbContext _colaboradorDbContext;


    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        ColaboradorDbContext colaboradorDbContext
    )
    {
        _logger = logger;
        _colaboradorDbContext = colaboradorDbContext;
    }

   
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var colaboradorList =  _colaboradorDbContext.Colaborador;
        foreach (var colaborador in colaboradorList)
        {
            //_colaboradorDbContext.Colaborador(0);
        }
        return Ok(colaboradorList);
    }
}
