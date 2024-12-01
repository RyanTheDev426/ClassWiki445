using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

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

        //validate credentials
        public static bool ValidateUser(string username, string password, string xmlPath) {

            try
            {

                //hash input password
                string hashedPassword = HashString(password);

                //load xml file
                XDocument doc = XDocument.Load(xmlPath);

                //ifn duser with matching username/password combination
                var user = doc.Descendants("User").FirstOrDefault(u => u.Element("Username")?.Value == username && u.Element("Password")?.Value == hashedPassword);

                return user != null;

            }

            catch (Exception ex) {

                return false;
            }
        }

        //add new user
        public static bool AddUser(string username, string password, string xmlPath) {

            try
            {

                //hash input password
                string hashedPassword = HashString(password);

                //load xml
                XDocument doc;

                if (System.IO.File.Exists(xmlPath))
                {

                    doc = XDocument.Load(xmlPath);
                }

                else
                {
                    doc = new XDocument(new XElement("Users"));
                }

                //checkl if username already exists
                bool userExists = doc.Descendants("User").Any(u => u.Element("Username")?.Value == username);

                if (userExists) { return false; }

                //add new user element
                XElement newUser = new XElement("User", new XElement("Username, username"), new XElement("Password", hashedPassword));

                doc.Element("Users")?.Add(newUser);
                doc.Save(xmlPath);

                return true;
            }

            catch (Exception ex) {

                return false;
            }
        
        }

    }
}
