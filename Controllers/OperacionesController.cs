using Microsoft.AspNetCore.Mvc;
using Parcial1_P4_Stiven.Models;
using Parcial1_P4_Stiven.Services;

namespace Parcial1_P4_Stiven.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacionesController : ControllerBase
{
    private readonly NumbersService _numbersService;

    public OperacionesController(NumbersService numbersService)
    {
        _numbersService = numbersService;
    }

    [HttpGet("sumar/{numero}")]
    public async Task<IActionResult> SumarDoble(double numero)
    {
        double resultado = numero + numero;
        
        var record = new NumberRecord 
        {
            Fecha = DateTime.Now,
            Numero = numero,
            Resultado = resultado
        };

        // Guardar en SQLite
        await _numbersService.SaveAsync(record);

        return Ok(new 
        { 
            Operacion = $"{numero} + {numero}",
            Resultado = resultado,
            Mensaje = "El cálculo se ha guardado en el historial"
        });
    }

    [HttpGet("historial")]
    public async Task<IActionResult> ObtenerHistorial()
    {
        var historial = await _numbersService.GetListAsync();
        return Ok(historial);
    }
}