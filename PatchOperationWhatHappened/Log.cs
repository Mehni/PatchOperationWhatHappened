
namespace PatchOperationWhatHappened
{
    using System;
    using System.Xml;
    using Verse;

    public class Log : PatchOperationPathed
    {
        protected override bool ApplyWorker(XmlDocument xml)
        {
            try
            {
                foreach (var current in xml.SelectNodes(xpath))
                {
                    XmlNode xmlNode = current as XmlNode;
                    Verse.Log.Message(xmlNode?.OuterXml);
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
