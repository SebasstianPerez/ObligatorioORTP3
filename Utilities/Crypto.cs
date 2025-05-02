using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Crypto
    {
        public static string HashPasswordConBcrypt(string password, int workFactor)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
        }

        public static bool VerifyPasswordConBcrypt(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
