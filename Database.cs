using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace pt2022 {
    internal class Database {

        public static object GetUser(string name) {
            if (!Directory.Exists("./users")) {
                Directory.CreateDirectory("./users");
                return false;
            }
            if (!File.Exists($"./users/{name}.xml")) {
                return false;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load($"./users/{name}.xml");
            return doc;
        }

        public static bool LogIn(string username, string password) {
            object ret = GetUser(username);
            if (!(ret is XmlDocument)) {
                return false;
            }

            XmlDocument user = (XmlDocument)ret;
            return user.DocumentElement.GetElementsByTagName("Password")[0].InnerText == password;
        }

        public static bool Register(string username, string password) {
            if (!Directory.Exists("./users")) {
                Directory.CreateDirectory("./users");
            } else if (Directory.GetFiles("./users").Contains(username)) {
                return false;
            }

            using (XmlWriter writer = XmlWriter.Create($"./users/{username}.xml")) {
                writer.WriteStartElement("User");
                writer.WriteElementString("Username", username);
                writer.WriteElementString("Password", password);
                writer.WriteEndElement();
                writer.Flush();
            }
            return true;
        }
    }
}
