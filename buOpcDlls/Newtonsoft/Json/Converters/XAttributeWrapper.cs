// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XAttributeWrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Xml.Linq;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(2)]
[Nullable(0)]
[method: NullableContext(1)]
internal class XAttributeWrapper(XAttribute attribute) : XObjectWrapper((XObject) attribute)
{
  [Nullable(1)]
  private XAttribute Attribute
  {
    [NullableContext(1)] get => (XAttribute) this.WrappedNode;
  }

  public override string Value
  {
    get => this.Attribute.Value;
    set => this.Attribute.Value = value ?? string.Empty;
  }

  public override string LocalName => this.Attribute.Name.LocalName;

  public override string NamespaceUri => this.Attribute.Name.NamespaceName;

  public override IXmlNode ParentNode
  {
    get
    {
      return this.Attribute.Parent == null ? (IXmlNode) null : XContainerWrapper.WrapNode((XObject) this.Attribute.Parent);
    }
  }
}
