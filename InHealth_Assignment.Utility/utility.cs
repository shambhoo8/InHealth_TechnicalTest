using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InHealth_Assignment.Utilities
{
    public class utility
    {
        public static string Encryptpassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
            return hashedPassword;
        }
        public static bool ValidatePassword(string enteredPassword, string hashedPassword)
        {
            bool pwdHash = BCrypt.Net.BCrypt.CheckPassword(enteredPassword, hashedPassword);
            return pwdHash;
        }
    }
}
