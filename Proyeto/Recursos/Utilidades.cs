using System.Security.Cryptography;
using System.Text;
namespace Proyeto.Recursos
{
    public class Utilidades
    {
        //metodo para cifrar la contraseña
        public static string EncriptarClave(string Contrasena)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc= Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(Contrasena));
                foreach(byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
