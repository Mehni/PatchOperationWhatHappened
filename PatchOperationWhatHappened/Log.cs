
namespace PatchOperationWhatHappened
{
    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using Verse;

    public class Log : PatchOperationPathed
    {
        protected override bool ApplyWorker(XmlDocument xml)
        {
            try
            {
                foreach (var current in xml.SelectNodes(xpath))
                {
                    XElement element = XElement.Parse((current as XmlNode) .OuterXml);
                    StringBuilder sb = new StringBuilder();
                    using (XmlWriter writer = XmlWriter.Create(sb, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true }))
                        element.Save(writer);
                    sb.Insert(0, $"{xpath}\n\n");
                    Verse.Log.Message(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                Verse.Log.Message($" FAIL: {xpath} + {ex}");
            }
            return true;
        }
    }
}
