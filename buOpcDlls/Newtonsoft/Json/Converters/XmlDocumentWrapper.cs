// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XmlDocumentWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
internal class XmlDocumentWrapper : XmlNodeWrapper, IXmlDocument, IXmlNode
{
  private readonly XmlDocument _document;

  public XmlDocumentWrapper(XmlDocument document)
    : base((XmlNode) document)
  {
    this._document = document;
  }

  public IXmlNode CreateComment([Nullable(2)] string data)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateComment(data));
  }

  public IXmlNode CreateTextNode([Nullable(2)] string text)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateTextNode(text));
  }

  public IXmlNode CreateCDataSection([Nullable(2)] string data)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateCDataSection(data));
  }

  public IXmlNode CreateWhitespace([Nullable(2)] string text)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateWhitespace(text));
  }

  public IXmlNode CreateSignificantWhitespace([Nullable(2)] string text)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateSignificantWhitespace(text));
  }

  public IXmlNode CreateXmlDeclaration(string version, [Nullable(2)] string encoding, [Nullable(2)] string standalone)
  {
    return (IXmlNode) new XmlDeclarationWrapper(this._document.CreateXmlDeclaration(version, encoding, standalone));
  }

  [NullableContext(2)]
  [return: Nullable(1)]
  public IXmlNode CreateXmlDocumentType(
    [Nullable(1)] string name,
    string publicId,
    string systemId,
    string internalSubset)
  {
    return (IXmlNode) new XmlDocumentTypeWrapper(this._document.CreateDocumentType(name, publicId, systemId, (string) null));
  }

  public IXmlNode CreateProcessingInstruction(string target, string data)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateProcessingInstruction(target, data));
  }

  public IXmlElement CreateElement(string elementName)
  {
    return (IXmlElement) new XmlElementWrapper(this._document.CreateElement(elementName));
  }

  public IXmlElement CreateElement(string qualifiedName, string namespaceUri)
  {
    return (IXmlElement) new XmlElementWrapper(this._document.CreateElement(qualifiedName, namespaceUri));
  }

  public IXmlNode CreateAttribute(string name, [Nullable(2)] string value)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateAttribute(name))
    {
      Value = value
    };
  }

  public IXmlNode CreateAttribute(string qualifiedName, [Nullable(2)] string namespaceUri, [Nullable(2)] string value)
  {
    return (IXmlNode) new XmlNodeWrapper((XmlNode) this._document.CreateAttribute(qualifiedName, namespaceUri))
    {
      Value = value
    };
  }

  [Nullable(2)]
  public IXmlElement DocumentElement
  {
    [NullableContext(2)] get
    {
      return this._document.DocumentElement == null ? (IXmlElement) null : (IXmlElement) new XmlElementWrapper(this._document.DocumentElement);
    }
  }
}
