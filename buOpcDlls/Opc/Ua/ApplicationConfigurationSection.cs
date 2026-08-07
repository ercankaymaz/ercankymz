// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ApplicationConfigurationSection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ApplicationConfigurationSection
{
  public object Create(object parent, object configContext, XmlNode section)
  {
    XmlNode xmlNode = section != null ? section.FirstChild : throw new ArgumentNullException(nameof (section));
    while (xmlNode != null && typeof (XmlElement) != xmlNode.GetType())
      xmlNode = xmlNode.NextSibling;
    using (XmlReader reader = XmlReader.Create((TextReader) new StringReader(xmlNode.OuterXml), Utils.DefaultXmlReaderSettings()))
      return (object) (new DataContractSerializer(typeof (ConfigurationLocation)).ReadObject(reader) as ConfigurationLocation);
  }
}
