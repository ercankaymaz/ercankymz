// Decompiled with JetBrains decompiler
// Type: Opc.Ua.XmlElementCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfXmlElement", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "XmlElement")]
[ComVisible(true)]
public class XmlElementCollection : List<XmlElement>, ICloneable
{
  public XmlElementCollection()
  {
  }

  public XmlElementCollection(int capacity)
    : base(capacity)
  {
  }

  public XmlElementCollection(IEnumerable<XmlElement> collection)
    : base(collection)
  {
  }

  public static XmlElementCollection ToXmlElementCollection(XmlElement[] values)
  {
    return values != null ? new XmlElementCollection((IEnumerable<XmlElement>) values) : new XmlElementCollection();
  }

  public static implicit operator XmlElementCollection(XmlElement[] values)
  {
    return XmlElementCollection.ToXmlElementCollection(values);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    XmlElementCollection elementCollection = new XmlElementCollection(this.Count);
    foreach (XmlElement xmlElement in (List<XmlElement>) this)
      elementCollection.Add((XmlElement) Utils.Clone((object) xmlElement));
    return (object) elementCollection;
  }
}
