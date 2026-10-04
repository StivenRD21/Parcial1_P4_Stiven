using Microsoft.AspNetCore.Mvc;
using Parcial1_P4_Stiven.Models;
using Parcial1_P4_Stiven.Services;

namespace Parcial1_P4_Stiven.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacionesController(NumbersService numbersService) : ControllerBase
{
    [HttpGet("sumar/{numero}")]
    public async Task<IActionResult> SumarDoble(double numero)
    {
        double resultado = numero + numero;
        
        var record = new NumberRecord(0, DateTime.Now, numero, resultado);

        await numbersService.SaveAsync(record);

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
        var historial = await numbersService.GetListAsync();
        return Ok(historial);
    }
}