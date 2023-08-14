using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace Proyeto.datos
{
    public class MateriaImpartidaDatos
    {
        public List<MateriaImpartidaModel> Listar()
        {
            List<MateriaImpartidaModel> Lista = new List<MateriaImpartidaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_MateriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista.Add(new MateriaImpartidaModel
                        {
                            IdMateria = Convert.ToInt32(dr["IdMateria"]),
                            Matricula = Convert.ToInt32(dr["Matricula"]),
                            Carrera = dr["Carrera"].ToString(),
                            Materia = dr["Materia"].ToString(),
                            Grupo = dr["Grupo"].ToString(),
                            FechaCuatri = dr["FechaCuatri"].ToString(),
                            UrlDocumento = dr["UrlDoc"].ToString(),
                            IdAutor1 = Convert.ToInt32(dr["IdAutor1"]),
                        });
                    }
                }
            }
            return Lista;
        }




        public MateriaImpartidaModel Obtener(int IdMateria)
        {
            MateriaImpartidaModel _materia = new MateriaImpartidaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_MateriaObtener", conexion);
                cmd.Parameters.AddWithValue("IdMateria", IdMateria);
                cmd.CommandType = CommandType.StoredProcedure; 

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        _materia.IdMateria = Convert.ToInt32(dr["IdMateria"]);
                        _materia.Matricula = Convert.ToInt32(dr["Matricula"]);
                        _materia.Carrera = dr["Carrera"].ToString();
                        _materia.Materia = dr["Materia"].ToString();
                        _materia.Grupo = dr["Grupo"].ToString();
                        _materia.FechaCuatri = dr["FechaCuatri"].ToString();
                        _materia.UrlDocumento = dr["UrlDoc"].ToString();
                        _materia.IdAutor1 = Convert.ToInt32(dr["IdAutor1"]);
                    }
                }
            }
            return _materia;
        }



        public bool Guardar(MateriaImpartidaModel model)//Procedimiento almacenado Guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_MateriaGuardar", conexion);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("Carrera", model.Carrera);
                    cmd.Parameters.AddWithValue("Materia", model.Materia);
                    cmd.Parameters.AddWithValue("Grupo", model.Grupo);
                    cmd.Parameters.AddWithValue("FechaCuatri", model.FechaCuatri);
                    cmd.Parameters.AddWithValue("UrlDoc", model.UrlDocumento);
                    cmd.Parameters.AddWithValue("IdAutor1", model.IdAutor1);
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


        public bool Editar(MateriaImpartidaModel model) //Procedimiento almacenado Editar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_MateriaEditar", conexion);
                    cmd.Parameters.AddWithValue("@IdMateria", model.IdMateria);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("Carrera", model.Carrera);
                    cmd.Parameters.AddWithValue("Materia", model.Materia);
                    cmd.Parameters.AddWithValue("Grupo", model.Grupo);
                    cmd.Parameters.AddWithValue("FechaCuatri", model.FechaCuatri);
                    cmd.Parameters.AddWithValue("UrlDoc", model.UrlDocumento);
                    cmd.Parameters.AddWithValue("IdAutor1", model.IdAutor1);
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



        public bool Eliminar(int IdMateria)//Procedimiento almacenado Eliminar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_MateriaEliminar", conexion);
                    cmd.Parameters.AddWithValue("IdMateria", IdMateria);
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
    }
}
