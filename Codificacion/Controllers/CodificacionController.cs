using Microsoft.AspNetCore.Mvc;

namespace Codificacion.Controllers
{
    public class CodificacionController : Controller
    {
        // cifrar
        [HttpPost]
        [Route("cipher/{nombre}")]
        public ActionResult Insertar([FromBody] Datos_C Info, string nombre)
        {
            if (ModelState.IsValid)
            {
                switch ($"{nombre}")
                { 
 
                    case "cesar":
                        Cifrados.Cesar.Instance.Ingresar(Info.path, Info.fileName);
                        break;
 
                    case "zigzag":
                        Cifrados.ZigZag.Instance.Ingresar(Info.path, Info.carriles,Info.fileName);
                        break;
                    case "vertical":
 
                        Cifrados.Ruta_Vertical.Instance.Ingresar(Info.path, Info.filas, Info.fileName);
                        break;
                    case "espiral":
                        Cifrados.Ruta_Espiral.Instance.Ingresar(Info.path, Info.filas, Info.fileName);
 
                        break;
                    default:
                        //Error                     
                        break;
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }
 
        [HttpPost]
        [Route("decipher/{nombre}")]
        public ActionResult Decifrar([FromBody] Datos_C Info, string nombre)
        {
            if (ModelState.IsValid)
            {
                switch ($"{nombre}")
                {
 
                    case "cesar":
 
                        Cifrados.Cesar.Instance.IngresoDescifrado(Info.path,Info.fileName);
                        break;
                    case "zigzag":
                        Cifrados.ZigZag.Instance.IngresarDecifrado(Info.path,Info.carriles,Info.fileName);
                        break;
                    case "vertical":
 
                        Cifrados.Ruta_Vertical.Instance.IngresoDecidrado(Info.path, Info.filas, Info.fileName);
                        break;
              
                    case "espiral":
                        Cifrados.Ruta_Espiral.Instance.IngresoDecidrado(Info.path, Info.filas, Info.fileName);
 
                        break; 
                    default:
                        //Error                     
                        break;
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }
 

    }
}