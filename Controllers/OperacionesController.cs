using Microsoft.AspNetCore.Mvc;

namespace Parcial1_P4_Stiven.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacionesController : ControllerBase
{
    [HttpGet("sumar/{numero}")]
    public IActionResult SumarDoble(double numero)
    {
        double resultado = numero + numero;

        return Ok(new 
        { 
            NumeroIngresado = numero,
            Operacion = $"{numero} + {numero}",
            Resultado = resultado 
        });
    }
}