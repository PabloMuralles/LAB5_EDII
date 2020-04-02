﻿using Microsoft.AspNetCore.Mvc;

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
                        Cifrados.Cesar.Instance.Ingresar(Info.path);
                        break;
                    case "ZigZag":
                        Cifrados.ZigZag.Instance.Ingresar(Info.path, Info.Carriles);
                        break;
                    case "Vertical":
                        Cifrados.Ruta_Espiral.Instance.Ingresar(Info.path, Info.filas, Info.fileName);
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
        // decifrar
        [HttpPost]
        [Route("decipher/{nombre}")]
        public ActionResult Decifrar([FromBody] Datos_C Info, string nombre)
        {
            if (ModelState.IsValid)
            {
                switch ($"{nombre}")
                {
                    case "Cesar":
                        Cifrados.Cesar.Instance.IngresoDecidrado();
                        break;
                    case "Zig-Zag":
                        Cifrados.ZigZag.Instance.DecifrarIngresar();
                        break;
                    case "Vertical":
                        Cifrados.Ruta_Espiral.Instance.IngresoDecidrado( );
                        break;
                    case "espiral":
                        Cifrados.Ruta_Espiral.Instance.IngresoDecidrado( );
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