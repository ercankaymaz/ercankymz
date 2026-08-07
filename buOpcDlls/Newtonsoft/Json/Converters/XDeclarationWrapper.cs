// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XDeclarationWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(2)]
[Nullable(0)]
internal class XDeclarationWrapper : XObjectWrapper, IXmlDeclaration, IXmlNode
{
  [field: Nullable(1)]
  [Nullable(1)]
  internal XDeclaration Declaration { [NullableContext(1)] get; }

  [NullableContext(1)]
  public XDeclarationWrapper(XDeclaration declaration)
    : base((XObject) null)
  {
    this.Declaration = declaration;
  }

  public override XmlNodeType NodeType => XmlNodeType.XmlDeclaration;

  public string Version => this.Declaration.Version;

  public string Encoding
  {
    get => this.Declaration.Encoding;
    set => this.Declaration.Encoding = value;
  }

  public string Standalone
  {
    get => this.Declaration.Standalone;
    set => this.Declaration.Standalone = value;
  }
}
