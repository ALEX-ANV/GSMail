using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MailUI.Model
{
    public class Templates
    {
        public IDictionary<string, TemplateModel> TemplateFiles { get; set; }

        private string _path = $"{Environment.CurrentDirectory}\\Templates\\";

        public Templates()
        {
            if (TemplateFiles == null)
            {
                TemplateFiles = new Dictionary<string, TemplateModel>();
            }
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            var gstf = Directory.GetDirectories(_path, "*", SearchOption.AllDirectories).
                SelectMany(t => new DirectoryInfo(t).GetFiles("*.gstf"));
            foreach (var fileInfo in gstf)
            {
                var stringFile = File.ReadAllLines(fileInfo.FullName);
                TemplateFiles.Add(fileInfo.Name.Remove(fileInfo.Name.Length - 5),ParseTemplate(stringFile));
            }
        }

        private TemplateModel ParseTemplate(string[] stringFile)
        {
            var list = new Dictionary<string, ItemPattern>();
            foreach (var s in stringFile)
            {
                var index = s.IndexOf("list", StringComparison.Ordinal);
                if (index > -1)
                {
                    var indexS = s.IndexOf("{", StringComparison.Ordinal);
                    var nameListStart = s.IndexOf('"', index);
                    var nameListEnd = s.IndexOf('"', nameListStart + 1);
                    var nameList = s.Substring(nameListStart + 1, nameListEnd - nameListStart - 1).ToLower();
                    if (s.ToLower().Contains("item:"))
                    {
                        var itemTemplateStart = s.IndexOf('"', nameListEnd + 1);
                        var itemTemplateEnd = s.IndexOf('"', itemTemplateStart + 1);
                        var itemPattern = s.Substring(itemTemplateStart + 1,
                            itemTemplateEnd - itemTemplateStart - 1);
                        list.Add(nameList, new ItemPattern(indexS, stringFile.ToList().IndexOf(s), itemPattern));
                    }
                }
            }
            return new TemplateModel(list, stringFile.ToList());
        }
    }

    public class TemplateModel
    {
        public Dictionary<string, ItemPattern> ListPatterns { get; set; }

        public List<string> Content { get; set; }

        public TemplateModel(Dictionary<string, ItemPattern> listPatterns, List<string> content)
        {
            ListPatterns = listPatterns;
            Content = content;
        }
    }

    public class ItemPattern
    {
        public int Index { get; set; }

        public int Line { get; set; }

        public string Pattern { get; set; }

        public ItemPattern(int index, int line,  string pattern)
        {
            Index = index;
            Pattern = pattern;
            Line = line;
        }
    }
}
