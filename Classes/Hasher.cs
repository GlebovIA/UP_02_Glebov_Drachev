using System.Security.Cryptography;
using System.Text;

namespace UP_02_Glebov_Drachev.Classes
{
    public class Hasher
    {
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }
    }
}