using System;
using System.Collections.Generic;
using System.IO;

namespace MailUI.Model
{
    public class Templates
    {
        public static IDictionary<string, string[]> TemplateFiles { get; set; }

        private static string _path = $"{Environment.CurrentDirectory}\\Templates\\";

        static Templates()
        {
            if (TemplateFiles == null)
            {
                TemplateFiles = new Dictionary<string, string[]>();
            }
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            var gstf = new DirectoryInfo(_path).GetFiles("*.gstf");
            foreach (var fileInfo in gstf)
            {
                var stringFile = File.ReadAllLines(fileInfo.FullName);
                TemplateFiles.Add(fileInfo.Name.Remove(fileInfo.Name.Length - 5),stringFile);
            }
        }
    }
}
