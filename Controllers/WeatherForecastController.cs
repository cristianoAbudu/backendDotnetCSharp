using Microsoft.AspNetCore.Mvc;
using backendCSharp.Data;
using Microsoft.AspNetCore.Mvc;
using backendCSharp.Entity;
using backendCSharp.DTO;

namespace backendCSharp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ColaboradorDbContext _colaboradorDbContext;

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
            if (colaborador.IdChefe != null) {
                carregaChefe(colaborador);
            }
        }
        return Ok(colaboradorList);
    }

    private void carregaChefe(Colaborador colaborador)
    {
        try
        {
            colaborador.chefe = (Colaborador)_colaboradorDbContext.Find(typeof(Colaborador), colaborador.IdChefe);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(
        ColaboradorDTO colaborador
       )
    {
        Colaborador colaboradorEntity;

        if (colaborador.Id != null)
        {
            colaboradorEntity = (Colaborador)_colaboradorDbContext.Find(typeof(Colaborador), colaborador.Id);
            colaboradorEntity.Nome = colaborador.Nome;
            colaboradorEntity.Senha = colaborador.Senha;
            colaboradorEntity.IdChefe = colaborador.IdChefe;
        }
        else
        {
            colaboradorEntity = new Colaborador();
            colaboradorEntity.Nome = colaborador.Nome;
            colaboradorEntity.Senha = colaborador.Senha;
            colaboradorEntity.IdChefe = colaborador.IdChefe;
            _colaboradorDbContext.Colaborador.Add(colaboradorEntity);
        }

        _colaboradorDbContext.SaveChanges();
        return Ok(colaboradorEntity);
    }

    [HttpPost("/associaChefe")]
    public async Task<IActionResult> associarChefe(
        AssociaChefeDTO associaChefeDTO
       )
    {
        Colaborador colaboradorEntity = (Colaborador)_colaboradorDbContext.Find(typeof(Colaborador),
            associaChefeDTO.IdSubordinado);

        if (associaChefeDTO.IdChefe != associaChefeDTO.IdSubordinado)
        {
            colaboradorEntity.IdChefe = associaChefeDTO.IdChefe;
            _colaboradorDbContext.SaveChanges();
        }
        return Ok(colaboradorEntity);
    }
}
