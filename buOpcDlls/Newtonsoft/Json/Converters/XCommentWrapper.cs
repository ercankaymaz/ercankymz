// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XCommentWrapper
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
internal class XCommentWrapper(XComment text) : XObjectWrapper((XObject) text)
{
  [Nullable(1)]
  private XComment Text
  {
    [NullableContext(1)] get => (XComment) this.WrappedNode;
  }

  public override string Value
  {
    get => this.Text.Value;
    set => this.Text.Value = value ?? string.Empty;
  }

  public override IXmlNode ParentNode
  {
    get
    {
      return this.Text.Parent == null ? (IXmlNode) null : XContainerWrapper.WrapNode((XObject) this.Text.Parent);
    }
  }
}
