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
        public static string GenerarSHA256(string input)
        {
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(input);
                    byte[] hash = sha256Hash.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
                }
            }
            catch(CryptographicUnexpectedOperationException)
            {
                throw new Exception ("Error al generar el hash: Algoritmo no soportado o error en la operación criptográfica.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el hash: " + ex.Message);
            }
        }
    }

}
