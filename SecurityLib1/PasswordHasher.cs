using System;
using System.Diagnostics;
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
                string hash = builder.ToString();
                Debug.WriteLine($"Input: {input}, Hash: {hash}");
                return hash;
                //return builder.ToString();

            }

        }

        //validate credentials and return role
        public static (bool isValid, string role) ValidateUserAndGetRole(string username, string password, string userXmlPath, string staffXmlPath) {

            try
            {
                string hashedPassword = HashString(password);
                //debug
                Debug.WriteLine($"Validating user: {username}");
                Debug.WriteLine($"Staff XML path: {staffXmlPath}");
                Debug.WriteLine($"User XML path: {userXmlPath}");
                Debug.WriteLine($"Generated hash: {hashedPassword}");

                //check staff.xml
                if (System.IO.File.Exists(staffXmlPath))
                {

                    XDocument staffDoc = XDocument.Load(staffXmlPath);
                    var staffUser = staffDoc.Descendants("User").FirstOrDefault(u => u.Element("Username")?.Value == username && u.Element("Password")?.Value == hashedPassword);

                    if (staffUser != null)
                    {
                        string storedHash = staffUser.Element("Password")?.Value;
                        Debug.WriteLine($"Found staff user. Stored hash: {storedHash}");
                        if (storedHash == hashedPassword)
                            return (true, "Staff");
                    }

                }
                else { Debug.WriteLine("Staff XML file not found"); }

                //check UserData.xml
                if (System.IO.File.Exists(userXmlPath))
                {
                    XDocument userDoc = XDocument.Load(userXmlPath);

                    var user = userDoc.Descendants("User").FirstOrDefault(u => u.Element("Username")?.Value == username && u.Element("Password")?.Value == hashedPassword);

                    if (user != null)
                    {
                        string storedHash = user.Element("Password")?.Value;
                        Debug.WriteLine($"Found member user. Stored hash: {storedHash}");
                        if (storedHash == hashedPassword)
                            return (true, "Member");
                    }

                }
                else { Debug.WriteLine("User XML file not found"); }

                Debug.WriteLine("No matching user found");
                return (false, null);
            }

            catch (Exception ex) {

                Debug.WriteLine($"Error in validation: {ex.Message}");
                return (false, null); }
        
        }

        public static bool AddUser(string username, string password, string role, string xmlPath) {

            try {

                string hashedPassword = HashString(password);
                XDocument doc;

                if (System.IO.File.Exists(xmlPath))
                    doc = XDocument.Load(xmlPath);
                else
                    doc = new XDocument(new XElement("Users"));

                bool userExists = doc.Descendants("User").Any(u => u.Element("Username")?.Value == username);

                if (userExists)  return false;

                var newUser = new XElement("User",
                    new XElement("Username", username),
                    new XElement("Password", hashedPassword));

                doc.Element("Users").Add(newUser);
                doc.Save(xmlPath);
                return true;

            }
            catch (Exception) { return false; }
        
        
        }

        //validate credentials
        /*public static bool ValidateUser(string username, string password, string xmlPath) {
        
            
            var(isValid, _) = ValidateUserAndGetRole(username, password, xmlPath);
            return isValid;
        }

        //add new user with role
        public static bool AddUser(string username, string role, string password, string xmlPath) {

            try {

                //hash input password
                string hashedPassword = HashString(password);

                //load xml
                XDocument doc;

                if (System.IO.File.Exists(xmlPath)) {

                    doc = XDocument.Load(xmlPath);
                }

                else
                {

                 doc = new XDocument(new XElement("Users"));
                    
                }

                //check if user already exists
                bool userExists = doc.Descendants("User").Any(u => u.Element("Username")?.Value == username);
                if (userExists) { return false; }

                //add new user with role
                XElement newUser = new XElement("User", new XElement("Username", username), new XElement("Password", hashedPassword), new XElement("Role", role ?? "Member"));

                doc.Element("Users")?.Add(newUser);
                doc.Save(xmlPath);
                return true;

            } catch (Exception ex) { 
                
                return false; 
            }
        }

        //overload AddUser that defaults to member role
        public static bool AddUser(string username, string password, string xmlPath) {
        
            
                return AddUser(username, password, "Member", xmlPath);

        }

        //update or add role for a current user
        public static bool UpdateUserRole(string username, string role, string xmlPath) {

            try { 
                
                XDocument doc = XDocument.Load(xmlPath);
                var user = doc.Descendants("User").FirstOrDefault(u => u.Element("Username")?.Value == username);

                if (user != null) {

                    var roleElement = user.Element("Role");

                    if (roleElement != null)
                    {

                        roleElement.Value = role;
                    }

                    else {

                        user.Add(new XElement("Role", role));
                    }
                    doc.Save(xmlPath);
                    return true;
                }
                return false;

            } catch (Exception ex) { return false; }
        
        }



        /*public static (bool isValid, string role) ValidateUserAndGetRole(string username, string password, string xmlPath) {
            

        
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
        
        }*/

    }
}
