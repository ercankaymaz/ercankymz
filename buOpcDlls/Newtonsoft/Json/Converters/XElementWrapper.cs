// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XElementWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml.Linq;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
internal class XElementWrapper(XElement element) : XContainerWrapper((XContainer) element), IXmlElement, IXmlNode
{
  [Nullable(new byte[] {2, 1})]
  private List<IXmlNode> _attributes;

  private XElement Element => (XElement) this.WrappedNode;

  public void SetAttributeNode(IXmlNode attribute)
  {
    this.Element.Add(((XObjectWrapper) attribute).WrappedNode);
    this._attributes = (List<IXmlNode>) null;
  }

  public override List<IXmlNode> Attributes
  {
    get
    {
      if (this._attributes == null)
      {
        if (!this.Element.HasAttributes && !this.HasImplicitNamespaceAttribute(this.NamespaceUri))
        {
          this._attributes = XmlNodeConverter.EmptyChildNodes;
        }
        else
        {
          this._attributes = new List<IXmlNode>();
          foreach (XAttribute attribute in this.Element.Attributes())
            this._attributes.Add((IXmlNode) new XAttributeWrapper(attribute));
          string namespaceUri = this.NamespaceUri;
          if (this.HasImplicitNamespaceAttribute(namespaceUri))
            this._attributes.Insert(0, (IXmlNode) new XAttributeWrapper(new XAttribute((XName) "xmlns", (object) namespaceUri)));
        }
      }
      return this._attributes;
    }
  }

  private bool HasImplicitNamespaceAttribute(string namespaceUri)
  {
    if (!StringUtils.IsNullOrEmpty(namespaceUri) && namespaceUri != this.ParentNode?.NamespaceUri && StringUtils.IsNullOrEmpty(this.GetPrefixOfNamespace(namespaceUri)))
    {
      bool flag = false;
      if (this.Element.HasAttributes)
      {
        foreach (XAttribute attribute in this.Element.Attributes())
        {
          if (attribute.Name.LocalName == "xmlns" && StringUtils.IsNullOrEmpty(attribute.Name.NamespaceName) && attribute.Value == namespaceUri)
            flag = true;
        }
      }
      if (!flag)
        return true;
    }
    return false;
  }

  public override IXmlNode AppendChild(IXmlNode newChild)
  {
    IXmlNode xmlNode = base.AppendChild(newChild);
    this._attributes = (List<IXmlNode>) null;
    return xmlNode;
  }

  [Nullable(2)]
  public override string Value
  {
    [NullableContext(2)] get => this.Element.Value;
    [NullableContext(2)] set => this.Element.Value = value ?? string.Empty;
  }

  [Nullable(2)]
  public override string LocalName
  {
    [NullableContext(2)] get => this.Element.Name.LocalName;
  }

  [Nullable(2)]
  public override string NamespaceUri
  {
    [NullableContext(2)] get => this.Element.Name.NamespaceName;
  }

  [return: Nullable(2)]
  public string GetPrefixOfNamespace(string namespaceUri)
  {
    return this.Element.GetPrefixOfNamespace((XNamespace) namespaceUri);
  }

  public bool IsEmpty => this.Element.IsEmpty;
}
