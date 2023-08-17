using System.Data.SqlClient;
using System.Data;
using Proyeto.Models;

namespace Proyeto.datos
{
    public List<RolModel> Listar()
    {
        List<RolModel> Lista = new List<RolModel>();
        var cn = new Conexion();
        using (var conexion = new SqlConnection(cn.getCadenaSql()))
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("sp_ListarRol", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Lista.Add(new RolModel
                    {
                        IdRol = Convert.ToInt32(dr["IdRol"]),
                        NombreRol = dr["NombreRol"].ToString(),
                    });
                }
            }
        }
        return Lista;
    }


}
