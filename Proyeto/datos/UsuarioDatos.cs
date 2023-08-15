﻿using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Proyeto.datos
{
    public class UsuarioDatos
    {
        public List<UsuarioModel> Listar()
        {
            List<UsuarioModel> Lista = new List<UsuarioModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_UsuarioListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new UsuarioModel
                        {
                           NombreUsuario = dr["NombreUsuario"].ToString(),
                           Correo = dr["Correo"].ToString(),
                           Contrasena = dr["Contrasena"].ToString(),
                           IdAutor1 = Convert.ToInt32(dr["IdAutor1"])
                        });
                    }
                }
            }
            return Lista;
        }

        public UsuarioModel Obtener(string NombreUsuario)
        {
            UsuarioModel _usuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_UsuarioObtener", conexion);
                cmd.Parameters.AddWithValue("NombreUsuario", NombreUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                        _usuario.Correo = dr["Correo"].ToString();
                        _usuario.Contrasena = dr["Contrasena"].ToString();
                        _usuario.IdAutor1 = Convert.ToInt32(dr["IdAutor1"]);
                    }
                }
            }
            return _usuario;
        }


        public UsuarioModel ObtenerByAutor(int idAutor)
        {
            UsuarioModel _usuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_UsuarioObtenerByAutor", conexion);
                cmd.Parameters.AddWithValue("IdAutor", idAutor);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                        _usuario.Correo = dr["Correo"].ToString();
                        _usuario.Contrasena = dr["Contrasena"].ToString();
                        _usuario.IdAutor1 = Convert.ToInt32(dr["IdAutor1"]);
                    }
                }
            }
            return _usuario;
        }



        public UsuarioModel Login(string NombreUsuario, string Contrasena)
        {
            UsuarioModel _usuario = new UsuarioModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_UsuarioLogin", conexion);
                cmd.Parameters.AddWithValue("NombreUsuario", NombreUsuario);
                cmd.Parameters.AddWithValue("Contrasena", Contrasena);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                        _usuario.Correo = dr["Correo"].ToString();
                        _usuario.Contrasena = dr["Contrasena"].ToString();
                        _usuario.IdAutor1 = Convert.ToInt32(dr["IdAutor1"]);
                        _usuario.EsAdmin = dr["EsAdmin"]!=DBNull.Value? Convert.ToInt32(dr["EsAdmin"]) : 0  ;
                    }
                }
            }
            return _usuario;
        }


        public bool GuardarUsuario(UsuarioModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_UsuarioGuardar", conexion);
                    cmd.Parameters.AddWithValue("NombreUsuario", model.NombreUsuario);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Contrasena", model.Contrasena);
                    cmd.Parameters.AddWithValue("IdAutor", model.IdAutor1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Editar(UsuarioModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_UsuarioEditar", conexion);
                    cmd.Parameters.AddWithValue("NombreUsuario", model.NombreUsuario);                 
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Contrasena", model.Contrasena);
                    cmd.Parameters.AddWithValue("IdAutor", model.IdAutor1);         
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }


        public bool Eliminar(string NombreUsuario)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_UsuarioEliminar", conexion);
                    cmd.Parameters.AddWithValue("NombreUsuario", NombreUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }


        //cambiar contraseña
        public bool CambiarContrasena(string Correo, string Contrasena)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CambiarContrasena", conexion);
                    cmd.Parameters.AddWithValue("Correo", Correo);
                    cmd.Parameters.AddWithValue("Contrasena", Contrasena);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

        //existe correo 
        public class LoginRegistrer
        {
            public bool existeCorreo(string Correo)
            {
                string eCorreo = "";
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ValidarCorreo", conexion);
                    cmd.Parameters.AddWithValue("Correo", Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr=cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            eCorreo = dr["Correo"].ToString();
                        }

                    }
                }
                if(eCorreo == "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }


}
