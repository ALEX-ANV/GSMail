using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using MailUI.Utils;

namespace MailUI.Helpers
{
    public class SerializeHelper
    {
        /// <summary>
        /// Serialize model to xml file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XElement SerializeModel<T>(T value)
        {
            try
            {
                var xsSubmit = new XmlSerializer(typeof(T));
                StringWriter xml = new StringWriter();
                xsSubmit.Serialize(xml, value);
                var elem = XElement.Parse(xml.ToString());
                xml.Close();
                return elem;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Deserialize xml file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool DeserializeModel<T>(string xml, ref T value)
        {
            try
            {
                var xsSubmit = new XmlSerializer(typeof(T));
                StringReader streamXml = new StringReader(xml);
                value = (T)xsSubmit.Deserialize(streamXml);
                return true;
            }
            catch (Exception e)
            {
                Logging.Exception(e);
                return false;
            }
        }
    }
}
