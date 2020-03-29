using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                        Cesar.Cesar.Instance.Ingresar(Info.path);
                        break;
                    case "zigzag":
                        Zig_Zag.Zig_Zag.Instance.Ingresar(Info.path,Info.Carriles,nombre);
                        break;
                    case"vertical" :
                        //vertical_espiral.vertical_espiral.Instance.Ingresar(Info.path, Info.filas);
                        break;
                    case "espiral":
                        //vertical_espiral.vertical_espiral.Instance.Ingresar(Info.path, Info.filas);
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