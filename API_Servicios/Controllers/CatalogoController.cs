using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {

        [HttpGet]
        [Route("getDepartamento")]
        [Authorize]
        public ActionResult<object> getDepartamento()
        {
            List<DataLayer.EntityModel.DepartamentoEntity> Depto = new List<DataLayer.EntityModel.DepartamentoEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo();

            if (Cat.getDepartamento(ref Depto))
            {
                return Ok(new
                {
                    ok = true,
                    Response = Depto
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = Depto
                });
            }

        }


        [HttpGet]
        [Route("getMunicipioXDepartamento")]
        [Authorize]
        public ActionResult<object> getMunicipioXDepartamento(int IdDepartamento)
        {
            List<DataLayer.EntityModel.MunicipioEntity> Mun = new List<DataLayer.EntityModel.MunicipioEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo(IdDepartamento);

            if (Cat.getMunicipioXDepartamento(ref Mun))
            {
                return Ok(new
                {
                    ok = true,
                    Response = Mun
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = Mun
                });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getRolPersona")]
        public ActionResult<object> getRolPersona()
        {
            List<DataLayer.EntityModel.RolPersonaEntity> Rolp = new List<DataLayer.EntityModel.RolPersonaEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo();

            if (Cat.getRolPersona(ref Rolp))
            {
                return Ok(new
                {
                    ok = true,
                    Response = Rolp
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = Rolp
                });
            }

        }



        [HttpGet]
        [Authorize]
        [Route("getSucursal")]
        public ActionResult<object> getSucursal()
        {
            List<DataLayer.EntityModel.SucursalEntity> SL = new List<DataLayer.EntityModel.SucursalEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo();

            if (Cat.getSucursal(ref SL))
            {
                return Ok(new
                {
                    ok = true,
                    Response = SL
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = SL
                });
            }

        }


        [HttpGet]
        [Authorize]
        [Route("getRolUsuario")]
        public ActionResult<object> getRolUsuario()
        {
            List<DataLayer.EntityModel.RolUsuarioEntity> Rolusu = new List<DataLayer.EntityModel.RolUsuarioEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo();

            if (Cat.getRolUsuario(ref Rolusu))
            {
                return Ok(new
                {
                    ok = true,
                    Response = Rolusu
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = Rolusu
                });
            }

        }

        [HttpGet]
        [Authorize]
        [Route("getGenero")]
        public ActionResult<object> getGenero()
        {
            List<DataLayer.EntityModel.GeneroEntity> Genero = new List<DataLayer.EntityModel.GeneroEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo();

            if (Cat.getGenero(ref Genero))
            {
                return Ok(new
                {
                    ok = true,
                    Response = Genero
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = Genero
                });
            }

        }


        [HttpGet]
        [Authorize]
        [Route("getEstadoCuenta")]
        public ActionResult<object> getEstadoCuenta()
        {
            List<DataLayer.EntityModel.EstadoCuentaEntity> EstadoC = new List<DataLayer.EntityModel.EstadoCuentaEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo();

            if (Cat.getEstadoCuenta(ref EstadoC))
            {
                return Ok(new
                {
                    ok = true,
                    Response = EstadoC
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = EstadoC
                });
            }

        }


        [HttpGet]
       [Authorize]
        [Route("getTipoCuenta")]
        public ActionResult<object> getTipoCuenta()
        {
            List<DataLayer.EntityModel.TipoCuentaEntity> TipoC = new List<DataLayer.EntityModel.TipoCuentaEntity>();
            LogicLayer.Catalogos.Catalogo Cat = new LogicLayer.Catalogos.Catalogo();

            if (Cat.getTipoCuenta(ref TipoC))
            {
                return Ok(new
                {
                    ok = true,
                    Response = TipoC
                });

            }
            else
            {
                return Ok(new
                {
                    ok = false,
                    Response = TipoC
                });
            }

        }

    }
}
