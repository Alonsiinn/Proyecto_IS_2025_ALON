using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Servicios.Seguridad
{
    
    public static class Encriptacion
    {
        public static string GenerarMD5(string input)
        {
            try
            {
                UnicodeEncoding UeCodigo = new UnicodeEncoding();
                byte[] bytes = UeCodigo.GetBytes(input);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] hash = md5.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
            catch (CryptographicException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el hash MD5: " + ex.Message);
            }
        }
    }
}
