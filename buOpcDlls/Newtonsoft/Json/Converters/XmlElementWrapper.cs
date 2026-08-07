// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XmlElementWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
internal class XmlElementWrapper : XmlNodeWrapper, IXmlElement, IXmlNode
{
  private readonly XmlElement _element;

  public XmlElementWrapper(XmlElement element)
    : base((XmlNode) element)
  {
    this._element = element;
  }

  public void SetAttributeNode(IXmlNode attribute)
  {
    this._element.SetAttributeNode((XmlAttribute) ((XmlNodeWrapper) attribute).WrappedNode);
  }

  [return: Nullable(2)]
  public string GetPrefixOfNamespace(string namespaceUri)
  {
    return this._element.GetPrefixOfNamespace(namespaceUri);
  }

  public bool IsEmpty => this._element.IsEmpty;
}
