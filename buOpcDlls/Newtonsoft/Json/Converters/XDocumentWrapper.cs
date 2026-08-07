// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XDocumentWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
internal class XDocumentWrapper(XDocument document) : XContainerWrapper((XContainer) document), IXmlDocument, IXmlNode
{
  private XDocument Document => (XDocument) this.WrappedNode;

  public override List<IXmlNode> ChildNodes
  {
    get
    {
      List<IXmlNode> childNodes = base.ChildNodes;
      if (this.Document.Declaration != null && (childNodes.Count == 0 || childNodes[0].NodeType != XmlNodeType.XmlDeclaration))
        childNodes.Insert(0, (IXmlNode) new XDeclarationWrapper(this.Document.Declaration));
      return childNodes;
    }
  }

  protected override bool HasChildNodes => base.HasChildNodes || this.Document.Declaration != null;

  public IXmlNode CreateComment([Nullable(2)] string text)
  {
    return (IXmlNode) new XObjectWrapper((XObject) new XComment(text));
  }

  public IXmlNode CreateTextNode([Nullable(2)] string text)
  {
    return (IXmlNode) new XObjectWrapper((XObject) new XText(text));
  }

  public IXmlNode CreateCDataSection([Nullable(2)] string data)
  {
    return (IXmlNode) new XObjectWrapper((XObject) new XCData(data));
  }

  public IXmlNode CreateWhitespace([Nullable(2)] string text)
  {
    return (IXmlNode) new XObjectWrapper((XObject) new XText(text));
  }

  public IXmlNode CreateSignificantWhitespace([Nullable(2)] string text)
  {
    return (IXmlNode) new XObjectWrapper((XObject) new XText(text));
  }

  public IXmlNode CreateXmlDeclaration(string version, [Nullable(2)] string encoding, [Nullable(2)] string standalone)
  {
    return (IXmlNode) new XDeclarationWrapper(new XDeclaration(version, encoding, standalone));
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  public IXmlNode CreateXmlDocumentType(
    [Nullable(1)] string name,
    string publicId,
    string systemId,
    string internalSubset)
  {
    return (IXmlNode) new XDocumentTypeWrapper(new XDocumentType(name, publicId, systemId, internalSubset));
  }

  public IXmlNode CreateProcessingInstruction(string target, string data)
  {
    return (IXmlNode) new XProcessingInstructionWrapper(new XProcessingInstruction(target, data));
  }

  public IXmlElement CreateElement(string elementName)
  {
    return (IXmlElement) new XElementWrapper(new XElement((XName) elementName));
  }

  public IXmlElement CreateElement(string qualifiedName, string namespaceUri)
  {
    return (IXmlElement) new XElementWrapper(new XElement(XName.Get(MiscellaneousUtils.GetLocalName(qualifiedName), namespaceUri)));
  }

  public IXmlNode CreateAttribute(string name, string value)
  {
    return (IXmlNode) new XAttributeWrapper(new XAttribute((XName) name, (object) value));
  }

  public IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, string value)
  {
    return (IXmlNode) new XAttributeWrapper(new XAttribute(XName.Get(MiscellaneousUtils.GetLocalName(qualifiedName), namespaceUri), (object) value));
  }

  [Nullable(2)]
  public IXmlElement DocumentElement
  {
    [NullableContext(2)] get
    {
      return this.Document.Root == null ? (IXmlElement) null : (IXmlElement) new XElementWrapper(this.Document.Root);
    }
  }

  public override IXmlNode AppendChild(IXmlNode newChild)
  {
    if (!(newChild is XDeclarationWrapper xdeclarationWrapper))
      return base.AppendChild(newChild);
    this.Document.Declaration = xdeclarationWrapper.Declaration;
    return (IXmlNode) xdeclarationWrapper;
  }
}
