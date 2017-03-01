using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MailUI.Helpers
{
    public class FileHelper
    {
        public static void Write(XElement xml, string name, string pathDirectory)
        {
            if (!Directory.Exists(pathDirectory))
            {
                Directory.CreateDirectory(pathDirectory);
            }
            var pathFile = $"{pathDirectory}\\{name}";
            File.WriteAllText(pathFile, xml.ToString());
        }
    }
}
