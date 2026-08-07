// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XObjectWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(2)]
[Nullable(0)]
internal class XObjectWrapper : IXmlNode
{
  private readonly XObject _xmlObject;

  public XObjectWrapper(XObject xmlObject) => this._xmlObject = xmlObject;

  public object WrappedNode => (object) this._xmlObject;

  public virtual XmlNodeType NodeType
  {
    get
    {
      XObject xmlObject = this._xmlObject;
      return xmlObject == null ? XmlNodeType.None : xmlObject.NodeType;
    }
  }

  public virtual string LocalName => (string) null;

  [Nullable(1)]
  public virtual List<IXmlNode> ChildNodes
  {
    [NullableContext(1)] get => XmlNodeConverter.EmptyChildNodes;
  }

  [Nullable(1)]
  public virtual List<IXmlNode> Attributes
  {
    [NullableContext(1)] get => XmlNodeConverter.EmptyChildNodes;
  }

  public virtual IXmlNode ParentNode => (IXmlNode) null;

  public virtual string Value
  {
    get => (string) null;
    set => throw new InvalidOperationException();
  }

  [NullableContext(1)]
  public virtual IXmlNode AppendChild(IXmlNode newChild) => throw new InvalidOperationException();

  public virtual string NamespaceUri => (string) null;
}
