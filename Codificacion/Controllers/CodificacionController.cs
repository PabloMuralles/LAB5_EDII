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
                        Cesar.Cesar.Instance.Ingresar(Info.path);
                        break;
                    case "zigzag":
                        Zig_Zag.Zig_Zag.Instance.Ingresar(Info.path,Info.Carriles,Info.fileName);
                        break;
                    case"vertical" :
                        //vertical_espiral.vertical_espiral.Instance.Ingresar(Info.path, Info.filas);
                        break;
                    case "espiral":
                        //vertical_espiral.vertical_espiral.Instance.Ingresar(Info.path, Info.filas);


                    case "cesar":
                        Cesar.Cesar.Instance.Ingresar(Info.path);
                        break;
                    case "Zig-Zag":
                        Zig_Zag.Zig_Zag.Instance.Ingresar(Info.path, Info.Carriles);
                        break;
                    case "Vertical":
                        vertical_espiral.Ruta_Espiral.Instance.Ingresar(Info.path, Info.filas);
                        break;
                    case "espiral":
                        vertical_espiral.Ruta_Espiral.Instance.Ingresar(Info.path, Info.filas);

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
        [Route("cipher/{nombre}")]
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
                        Zig_Zag.Zig_Zag.Instance.IngresoDe();
                        break;
                    case "Vertical":
                        vertical_espiral.Ruta_Espiral.Instance.IngresoDecidrado(Info.path, Info.filas);
                        break;
                    case "espiral":
                        vertical_espiral.Ruta_Espiral.Instance.IngresoDecidrado(Info.path, Info.filas);
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