using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiDigitalGamesMx.Helpers
{
    public class Functions
    {    
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string Md5Hash(string input)
        {
            // Creamos una nueva instancias
            MD5 md5Hasher = MD5.Create();

            // le sacamos los byte a la cadea
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            //Creamos un string builder para aterrizar la cadena
            StringBuilder sBuilder = new StringBuilder();

            // recorremos byte por byte hasta que se transforme toda en una cadena hex
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // la regresamos
            return sBuilder.ToString();
        }

        public static string RandomCodigo()
        {
            int maxSize = 25;
            int minSize = 5;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString().ToUpper();
        }

       

    }
}
