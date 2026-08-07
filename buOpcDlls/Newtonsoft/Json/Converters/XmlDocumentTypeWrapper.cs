// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XmlDocumentTypeWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(2)]
[Nullable(0)]
internal class XmlDocumentTypeWrapper : XmlNodeWrapper, IXmlDocumentType, IXmlNode
{
  [Nullable(1)]
  private readonly XmlDocumentType _documentType;

  [NullableContext(1)]
  public XmlDocumentTypeWrapper(XmlDocumentType documentType)
    : base((XmlNode) documentType)
  {
    this._documentType = documentType;
  }

  [Nullable(1)]
  public string Name
  {
    [NullableContext(1)] get => this._documentType.Name;
  }

  public string System => this._documentType.SystemId;

  public string Public => this._documentType.PublicId;

  public string InternalSubset => this._documentType.InternalSubset;

  public override string LocalName => "DOCTYPE";
}
