// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XmlDeclarationWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(2)]
[Nullable(0)]
internal class XmlDeclarationWrapper : XmlNodeWrapper, IXmlDeclaration, IXmlNode
{
  [Nullable(1)]
  private readonly XmlDeclaration _declaration;

  [NullableContext(1)]
  public XmlDeclarationWrapper(XmlDeclaration declaration)
    : base((XmlNode) declaration)
  {
    this._declaration = declaration;
  }

  public string Version => this._declaration.Version;

  public string Encoding
  {
    get => this._declaration.Encoding;
    set => this._declaration.Encoding = value;
  }

  public string Standalone
  {
    get => this._declaration.Standalone;
    set => this._declaration.Standalone = value;
  }
}
