﻿using DataLayer.Conexion;
using DataLayer.EntityModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Catalogos
{
    public class Catalogo
    {
        private int idDepartamento;

        public Catalogo()
        {
        }

        public Catalogo(int IdDepartamento)
        {
            idDepartamento = IdDepartamento;
        }

        public bool getDepartamento(ref List<DepartamentoEntity> depto)
        {
            DataLayer.EntityModel.DepartamentoEntity departamento = new DataLayer.EntityModel.DepartamentoEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_DEPARTAMENTO", "", "");

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            departamento = new DataLayer.EntityModel.DepartamentoEntity();
                            departamento.C_Id_Depto = Convert.ToInt32(row["ID_DEPTO"]);
                            departamento.C_Nombre = row["NOMBRE"].ToString();
                            departamento.C_Url_IMG = row["URL_IMG"].ToString();

                            depto.Add(departamento);

                        }

                        res = true;

                    }
                    else
                    {
                        departamento.C_Transaccion_Estado = 33;
                        departamento.C_Transaccion_Mensaje = "No hay registros";
                        depto.Add(departamento);
                        res = false;
                    }

                }
                else
                {

                    departamento.C_Transaccion_Estado = 32;
                    departamento.C_Transaccion_Mensaje = msgResEjecucion;
                    depto.Add(departamento);
                    res = false;
                }
            }
            catch (Exception e)
            {
                departamento.C_Transaccion_Estado = 35;
                departamento.C_Transaccion_Mensaje = e.Message;
                depto.Add(departamento);
                res = false;
            }
            return res;
        }

        public bool getEstadoCuenta(ref List<EstadoCuentaEntity> estadoC)
        {
            DataLayer.EntityModel.EstadoCuentaEntity EstadoC = new DataLayer.EntityModel.EstadoCuentaEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_ESTADO_CUENTA", "", "");

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            EstadoC = new DataLayer.EntityModel.EstadoCuentaEntity();
                            EstadoC.C_Id_Estado_Cuenta = Convert.ToInt32(row["ID_ESTADO_CUENTA"]);
                            EstadoC.C_Descripcion = row["DESCRIPCION"].ToString();


                            estadoC.Add(EstadoC);

                        }

                        res = true;

                    }
                    else
                    {
                        EstadoC.C_Transaccion_Estado = 33;
                        EstadoC.C_Transaccion_Mensaje = "No hay registros";
                        estadoC.Add(EstadoC);
                        res = false;
                    }

                }
                else
                {

                    EstadoC.C_Transaccion_Estado = 32;
                    EstadoC.C_Transaccion_Mensaje = msgResEjecucion;
                    estadoC.Add(EstadoC);
                    res = false;
                }
            }
            catch (Exception e)
            {
                EstadoC.C_Transaccion_Estado = 35;
                EstadoC.C_Transaccion_Mensaje = e.Message;
                estadoC.Add(EstadoC);
                res = false;
            }
            return res;
        }

        public bool getGenero(ref List<GeneroEntity> genero)
        {
            DataLayer.EntityModel.GeneroEntity Genero = new DataLayer.EntityModel.GeneroEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_GENERO", "", "");

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            Genero = new DataLayer.EntityModel.GeneroEntity();
                            Genero.C_Id_Genero = Convert.ToInt32(row["ID_GENERO"]);
                            Genero.C_Descripcion = row["DESCRIPCION"].ToString();


                            genero.Add(Genero);

                        }

                        res = true;

                    }
                    else
                    {
                        Genero.C_Transaccion_Estado = 33;
                        Genero.C_Transaccion_Mensaje = "No hay registros";
                        genero.Add(Genero);
                        res = false;
                    }

                }
                else
                {

                    Genero.C_Transaccion_Estado = 32;
                    Genero.C_Transaccion_Mensaje = msgResEjecucion;
                    genero.Add(Genero);
                    res = false;
                }
            }
            catch (Exception e)
            {
                Genero.C_Transaccion_Estado = 35;
                Genero.C_Transaccion_Mensaje = e.Message;
                genero.Add(Genero);
                res = false;
            }
            return res;
        }

        public bool getMunicipioXDepartamento(ref List<MunicipioEntity> mun)
        {
            DataLayer.EntityModel.MunicipioEntity Mun = new DataLayer.EntityModel.MunicipioEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_MUNICIPIO_X_DEPARTAMENTO", "", "");
                objStoreProc.Add_Par_Int_Input("@ID_DEPARTAMENTO", idDepartamento);

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            Mun = new DataLayer.EntityModel.MunicipioEntity();
                            Mun.C_Id_Municipio = Convert.ToInt32(row["ID_MUN"]);
                            Mun.C_Id_Depto = Convert.ToInt32(row["ID_DEPTO"]);
                            Mun.C_Nombre = row["NOMBRE"].ToString();
                            Mun.C_Url_IMG = row["URL_IMG"].ToString();

                            mun.Add(Mun);

                        }

                        res = true;

                    }
                    else
                    {
                        Mun.C_Transaccion_Estado = 33;
                        Mun.C_Transaccion_Mensaje = "No hay registros";
                        mun.Add(Mun);
                        res = false;
                    }

                }
                else
                {

                    Mun.C_Transaccion_Estado = 32;
                    Mun.C_Transaccion_Mensaje = msgResEjecucion;
                    mun.Add(Mun);
                    res = false;
                }
            }
            catch (Exception e)
            {
                Mun.C_Transaccion_Estado = 35;
                Mun.C_Transaccion_Mensaje = e.Message;
                mun.Add(Mun);
                res = false;
            }
            return res;
        }

        public bool getRolPersona(ref List<RolPersonaEntity> rolp)
        {
            DataLayer.EntityModel.RolPersonaEntity Rolp = new DataLayer.EntityModel.RolPersonaEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_ROL_PERSONA", "", "");

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            Rolp = new DataLayer.EntityModel.RolPersonaEntity();
                            Rolp.C_Id_Rol_Persona = Convert.ToInt32(row["ID_ROL_PERSONA"]);
                            Rolp.C_Descripcion = row["DESCRIPCION"].ToString();


                            rolp.Add(Rolp);

                        }

                        res = true;

                    }
                    else
                    {
                        Rolp.C_Transaccion_Estado = 33;
                        Rolp.C_Transaccion_Mensaje = "No hay registros";
                        rolp.Add(Rolp);
                        res = false;
                    }

                }
                else
                {

                    Rolp.C_Transaccion_Estado = 32;
                    Rolp.C_Transaccion_Mensaje = msgResEjecucion;
                    rolp.Add(Rolp);
                    res = false;
                }
            }
            catch (Exception e)
            {
                Rolp.C_Transaccion_Estado = 35;
                Rolp.C_Transaccion_Mensaje = e.Message;
                rolp.Add(Rolp);
                res = false;
            }
            return res;
        }

        public bool getRolUsuario(ref List<RolUsuarioEntity> rolusu)
        {
            DataLayer.EntityModel.RolUsuarioEntity Rolusu = new DataLayer.EntityModel.RolUsuarioEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_ROL_USUARIO", "", "");

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            Rolusu = new DataLayer.EntityModel.RolUsuarioEntity();
                            Rolusu.C_Id_Rol = Convert.ToInt32(row["ID_ROL"]);
                            Rolusu.C_Nombre = row["NOMBRE"].ToString();


                            rolusu.Add(Rolusu);

                        }

                        res = true;

                    }
                    else
                    {
                        Rolusu.C_Transaccion_Estado = 33;
                        Rolusu.C_Transaccion_Mensaje = "No hay registros";
                        rolusu.Add(Rolusu);
                        res = false;
                    }

                }
                else
                {

                    Rolusu.C_Transaccion_Estado = 32;
                    Rolusu.C_Transaccion_Mensaje = msgResEjecucion;
                    rolusu.Add(Rolusu);
                    res = false;
                }
            }
            catch (Exception e)
            {
                Rolusu.C_Transaccion_Estado = 35;
                Rolusu.C_Transaccion_Mensaje = e.Message;
                rolusu.Add(Rolusu);
                res = false;
            }
            return res;
        }

        public bool getSucursal(ref List<SucursalEntity> sL)
        {
            DataLayer.EntityModel.SucursalEntity SL = new DataLayer.EntityModel.SucursalEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_SUCURSAL", "", "");

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            SL = new DataLayer.EntityModel.SucursalEntity();
                            SL.C_Id_Sucursal = Convert.ToInt32(row["ID_SL"]);
                            SL.C_Nombre = row["NOMBRE"].ToString();
                            SL.C_Url_Img = row["URL_IMG"].ToString();


                            sL.Add(SL);

                        }

                        res = true;

                    }
                    else
                    {
                        SL.C_Transaccion_Estado = 33;
                        SL.C_Transaccion_Mensaje = "No hay registros";
                        sL.Add(SL);
                        res = false;
                    }

                }
                else
                {

                    SL.C_Transaccion_Estado = 32;
                    SL.C_Transaccion_Mensaje = msgResEjecucion;
                    sL.Add(SL);
                    res = false;
                }
            }
            catch (Exception e)
            {
               SL.C_Transaccion_Estado = 35;
                SL.C_Transaccion_Mensaje = e.Message;
                sL.Add(SL);
                res = false;
            }
            return res;
        }

        public bool getTipoCuenta(ref List<TipoCuentaEntity> tipoC)
        {
            DataLayer.EntityModel.TipoCuentaEntity TipoC = new DataLayer.EntityModel.TipoCuentaEntity();
            bool res = false;
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                /*Validar usuario en BD*/
                EjectProcAlm objStoreProc = new EjectProcAlm("SP_GET_TIPO_CUENTA", "", "");

                DataTable data = new DataTable();
                string msgResEjecucion = objStoreProc.Ejecutar_proc_alm_datatable_parametros(ref data);

                DataRow rows = data.Rows[0];


                if (string.IsNullOrEmpty(msgResEjecucion))
                {

                    if (data.Rows.Count > 0)
                    {

                        foreach (DataRow row in data.Rows)
                        {
                            TipoC = new DataLayer.EntityModel.TipoCuentaEntity();
                            TipoC.C_Id_Tipo_Cuenta = Convert.ToInt32(row["ID_TIPO_CUENTA"]);
                            TipoC.C_Descripcion = row["DESCRIPCION"].ToString();


                            tipoC.Add(TipoC);

                        }

                        res = true;

                    }
                    else
                    {
                        TipoC.C_Transaccion_Estado = 33;
                        TipoC.C_Transaccion_Mensaje = "No hay registros";
                        tipoC.Add(TipoC);
                        res = false;
                    }

                }
                else
                {

                    TipoC.C_Transaccion_Estado = 32;
                    TipoC.C_Transaccion_Mensaje = msgResEjecucion;
                    tipoC.Add(TipoC);
                    res = false;
                }
            }
            catch (Exception e)
            {
                TipoC.C_Transaccion_Estado = 35;
                TipoC.C_Transaccion_Mensaje = e.Message;
                tipoC.Add(TipoC);
                res = false;
            }
            return res;
        }
    }
}
