using System;
using System.Security.Cryptography;
using System.Text;


namespace SecurityLib1
{
    public class PasswordHasher
    {

        public static string HashString(string input)
        {

            using (SHA256 sha256 = SHA256.Create())
            {

                //convert input string to bytes and compute hash
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                //create string builder for hex string
                StringBuilder builder = new StringBuilder();

                //convert each byte to hex
                for (int i = 0; i < data.Length; i++)
                {

                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();

            }

        }

    }
}
