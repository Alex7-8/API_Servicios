using LogicLayer.Seguridad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LogicLayer;
using LogicLayer.Persona;

namespace API_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        [Route("echoping")]
        public ActionResult<object> EchoPing()
        {
            return Ok(true);
        }




        [HttpPost]
        [Route("setEmpleadosA")]
       // [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<object>> setEmpleadosA([FromBody] DataLayer.EntityModel.PersonaEntity Persona)
        {
            

            string bImg = Persona.C_Img_Base, nombre = Persona.C_Primer_Nombre;



            if (Persona.C_Fecha_Nacimiento < DateTime.Today.AddYears(-100) || Persona.C_Fecha_Nacimiento > DateTime.Today.AddYears(-18))
            {
                return Ok(new
                {
                    ok = false,
                    Transaccion_Estado = 24,
                    Transaccion_Mensaje = "Rango de Fechas no es correcto solo se admite edades mayores de 18 y menores de 100 años",
                });
            }
            else
            {
                LogicLayer.Logica.Metodos metodos = new LogicLayer.Logica.Metodos();



                if (!bImg.Equals("0"))
                {
                    Persona.C_Url_Img = await metodos.SubirIMGAsync(bImg, nombre);
                }
                else
                {
                    Persona.C_Url_Img = "https://img.srvcentral.com/Sistema/ImagenPorDefecto/Registro.png";
                }



                if (!Persona.C_Url_Img.Equals("0") || !Persona.C_Url_Img.StartsWith("Error"))
                {
                    Persona persona = new Persona(Persona.C_Url_Img);

                    if (persona.setEmpleadosA(ref Persona))
                    {
                        return Ok(new
                        {
                            ok = true,
                            Transaccion_Estado = Persona.C_Transaccion_Estado,
                            Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            ok = false,
                            Transaccion_Estado = Persona.C_Transaccion_Estado,
                            Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        Transaccion_Estado = 25,
                        Transaccion_Mensaje = Persona.C_Url_Img,
                    });
                }
            }
         
        }


        [HttpPost]
        [Route("CambiarEstadoEmpleado")]
        public ActionResult<object> CambiarEstadoEmpleado(int IdP, string IdU, string IdUM)
        {
            DataLayer.EntityModel.PersonaEntity Persona = new DataLayer.EntityModel.PersonaEntity();
            Persona persona = new Persona(IdP, IdU, IdUM);

            string fechaStr = "2023-08-28"; // Formato: "yyyy-MM-dd"
            DateTime fechaConvertida = DateTime.Parse(fechaStr);

            Persona.C_Fecha_Nacimiento = fechaConvertida;

            if (persona.CambiarEstadoEmpleado(ref Persona))
            {
                return Ok(new
                {
                    ok = true,
                    Transaccion_Estado = Persona.C_Transaccion_Estado,
                    Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,

                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Transaccion_Estado = Persona.C_Transaccion_Estado,
                    Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                });
            }

        }


        [HttpPost]
        [Route("putActualizarEmpleadosA")]
        // [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<object>> putActualizarEmpleadosA([FromBody] DataLayer.EntityModel.PersonaEntity Persona)
        {


            string bImg = Persona.C_Img_Base, nombre = Persona.C_Primer_Nombre;



            if (Persona.C_Fecha_Nacimiento < DateTime.Today.AddYears(-100) || Persona.C_Fecha_Nacimiento > DateTime.Today.AddYears(-18))
            {
                return Ok(new
                {
                    ok = false,
                    Transaccion_Estado = 24,
                    Transaccion_Mensaje = "Rango de Fechas no es correcto solo se admite edades mayores de 18 y menores de 100 años",
                });
            }
            else
            {
                LogicLayer.Logica.Metodos metodos = new LogicLayer.Logica.Metodos();



                if (!bImg.Equals("0") && !(bImg.StartsWith("http://") || bImg.StartsWith("https://")))
                {
                    
                    Persona.C_Url_Img = await metodos.SubirIMGAsync(bImg, nombre);
                }
               



                    Persona persona = new Persona(Persona.C_Url_Img);

                    if (persona.putActualizarEmpleadosA(ref Persona))
                    {
                        return Ok(new
                        {
                            ok = true,
                            Transaccion_Estado = Persona.C_Transaccion_Estado,
                            Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            ok = false,
                            Transaccion_Estado = Persona.C_Transaccion_Estado,
                            Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                        });
                    }
            }

        }




        [HttpPost]
        [Route("setEmpleadosG")]
        //[Authorize(Roles = "Gerente")]
        public async Task<ActionResult<object>> setEmpleadosG([FromBody] DataLayer.EntityModel.PersonaEntity Persona)
        {


            string bImg = Persona.C_Img_Base, nombre = Persona.C_Primer_Nombre;

            if (Persona.C_Fecha_Nacimiento < DateTime.Today.AddYears(-100) || Persona.C_Fecha_Nacimiento > DateTime.Today.AddYears(-18))
            {
                return BadRequest("La fecha de nacimiento no es válida.");
            }
            else 
            {

                LogicLayer.Logica.Metodos metodos = new LogicLayer.Logica.Metodos();



                if (!bImg.Equals("0"))
                {
                    Persona.C_Url_Img = await metodos.SubirIMGAsync(bImg, nombre);
                }




                if (!Persona.C_Url_Img.Equals("0") || !Persona.C_Url_Img.StartsWith("Error"))
                {
                    Persona persona = new Persona(Persona.C_Url_Img);

                    if (persona.SetEmpleadoG(ref Persona))
                    {
                        return Ok(new
                        {
                            ok = true,
                            Transaccion_Estado = Persona.C_Transaccion_Estado,
                            Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            ok = false,
                            Transaccion_Estado = Persona.C_Transaccion_Estado,
                            Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        Transaccion_Estado = 25,
                        Transaccion_Mensaje = Persona.C_Url_Img,
                    });
                }

            }



           


        }



        [HttpGet]
        [Route("GetEmpleados")]
        public ActionResult<object> GetEmpleados()
        {
            List<DataLayer.EntityModel.PersonaEntity> PersonaList = new List<DataLayer.EntityModel.PersonaEntity>();
            Persona persona = new Persona();



            if (persona.GetEmpleados(ref PersonaList))
            {
                return Ok(new
                {
                    ok = true,
                    Response = PersonaList
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = PersonaList
                });
            }

        }



        [HttpGet]
        [Route("GetEmpleadoXIdUA")]
        public ActionResult<object> GetEmpleadosXIdUA(int IdPersona)
        {
            DataLayer.EntityModel.PersonaEntity Persona = new DataLayer.EntityModel.PersonaEntity();
            Persona persona = new Persona(IdPersona);

            if (persona.GetEmpleadosXId(ref Persona))
            {
                return Ok(new
                {
                    ok = true,
                    Response = Persona
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = Persona
                });
            }

        }


        [HttpPost]
        [Route("setPersona")]
        // [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<object>> setPersona([FromBody] DataLayer.EntityModel.PersonaEntity Persona)
        {


            string bImg = Persona.C_Img_Base, nombre = Persona.C_Primer_Nombre;

           

            if (Persona.C_Id_Rol_Persona == 3 && (Persona.C_Fecha_Nacimiento < DateTime.Today.AddYears(-100) || Persona.C_Fecha_Nacimiento > DateTime.Today.AddYears(-18)) )
            {
                return Ok(new
                {
                    ok = false,
                    Transaccion_Estado = 24,
                    Transaccion_Mensaje = "Rango de Fechas no es correcto solo se admite edades mayores de 18 y menores de 100 años",
                });
            }
            else
            {
                if (Persona.C_Id_Rol_Persona == 2 && (Persona.C_Fecha_Nacimiento < DateTime.Today.AddYears(-100) || Persona.C_Fecha_Nacimiento > DateTime.Today.AddYears(-18)))
                {

                    return Ok(new
                    {
                        ok = false,
                        Transaccion_Estado = 24,
                        Transaccion_Mensaje = "Rango de Fechas no es correcto solo se admite edades mayores de 6 y menores de 100 años",
                    });

                }
                else 
                {
                    LogicLayer.Logica.Metodos metodos = new LogicLayer.Logica.Metodos();



                    if (!bImg.Equals("0"))
                    {
                        Persona.C_Url_Img = await metodos.SubirIMGAsync(bImg, nombre);
                    }
                    else
                    {
                        Persona.C_Url_Img = "https://img.srvcentral.com/Sistema/ImagenPorDefecto/Registro.png";
                    }



                    if (!Persona.C_Url_Img.Equals("0") || !Persona.C_Url_Img.StartsWith("Error"))
                    {
                        Persona persona = new Persona(Persona.C_Url_Img);

                        if (persona.setPersona(ref Persona))
                        {
                            return Ok(new
                            {
                                ok = true,
                                Transaccion_Estado = Persona.C_Transaccion_Estado,
                                Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                ok = false,
                                Transaccion_Estado = Persona.C_Transaccion_Estado,
                                Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                            });
                        }
                    }
                    else
                    {
                        return Ok(new
                        {
                            ok = false,
                            Transaccion_Estado = 25,
                            Transaccion_Mensaje = Persona.C_Url_Img,
                        });
                    }

                }
                
            }

        }






        [HttpGet]
        [Route("GetPersona")]
        public ActionResult<object> GetPersona()
        {
            List<DataLayer.EntityModel.PersonaEntity> PersonaList = new List<DataLayer.EntityModel.PersonaEntity>();
            Persona persona = new Persona();



            if (persona.GetPersona(ref PersonaList))
            {
                return Ok(new
                {
                    ok = true,
                    Response = PersonaList
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = PersonaList
                });
            }

        }

        [HttpGet]
        [Route("GetPersonaById")]
        public ActionResult<object> GetPersonaById(int IdPersona)
        {
            DataLayer.EntityModel.PersonaEntity Persona = new DataLayer.EntityModel.PersonaEntity();
            Persona persona = new Persona(IdPersona);

            if (persona.GetPersonaById(ref Persona))
            {
                return Ok(new
                {
                    ok = true,
                    Response = Persona
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = Persona
                });
            }

        }

        [HttpPost]
        [Route("putActualizarPersona")]
        // [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<object>> putActualizarPersona([FromBody] DataLayer.EntityModel.PersonaEntity Persona)
        {


            string bImg = Persona.C_Img_Base, nombre = Persona.C_Primer_Nombre;



            if (Persona.C_Fecha_Nacimiento < DateTime.Today.AddYears(-100) || Persona.C_Fecha_Nacimiento > DateTime.Today.AddYears(-18))
            {
                return Ok(new
                {
                    ok = false,
                    Transaccion_Estado = 24,
                    Transaccion_Mensaje = "Rango de Fechas no es correcto solo se admite edades mayores de 18 y menores de 100 años",
                });
            }
            else
            {
                LogicLayer.Logica.Metodos metodos = new LogicLayer.Logica.Metodos();



                if (!bImg.Equals("0") && !(bImg.StartsWith("http://") || bImg.StartsWith("https://")))
                {

                    Persona.C_Url_Img = await metodos.SubirIMGAsync(bImg, nombre);
                }




                Persona persona = new Persona(Persona.C_Url_Img);

                if (persona.putActualizarPersona(ref Persona))
                {
                    return Ok(new
                    {
                        ok = true,
                        Transaccion_Estado = Persona.C_Transaccion_Estado,
                        Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                    });
                }
                else
                {
                    return Ok(new
                    {
                        ok = false,
                        Transaccion_Estado = Persona.C_Transaccion_Estado,
                        Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                    });
                }
            }

        }

        [HttpPost]
        [Route("CambiarEstadoPersona")]
        public ActionResult<object> CambiarEstadoPersona(int IdP, string IdUM)
        {
            DataLayer.EntityModel.PersonaEntity Persona = new DataLayer.EntityModel.PersonaEntity();
            Persona persona = new Persona(IdP, IdUM);

            string fechaStr = "2023-08-28"; // Formato: "yyyy-MM-dd"
            DateTime fechaConvertida = DateTime.Parse(fechaStr);

            Persona.C_Fecha_Nacimiento = fechaConvertida;

            if (persona.CambiarEstadoPersona(ref Persona))
            {
                return Ok(new
                {
                    ok = true,
                    Transaccion_Estado = Persona.C_Transaccion_Estado,
                    Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,

                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Transaccion_Estado = Persona.C_Transaccion_Estado,
                    Transaccion_Mensaje = Persona.C_Transaccion_Mensaje,
                });
            }

        }




    }

}