//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;
/*
namespace Proyeto.datos
{ 
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
        catch(Exception ex)
        {
            string error = ex.Message;
            respuesta = false;
        }
        return respuesta;
    }
}
*/