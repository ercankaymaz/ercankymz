// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.XProcessingInstructionWrapper
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
internal class XProcessingInstructionWrapper(XProcessingInstruction processingInstruction) : 
  XObjectWrapper((XObject) processingInstruction)
{
  [Nullable(1)]
  private XProcessingInstruction ProcessingInstruction
  {
    [NullableContext(1)] get => (XProcessingInstruction) this.WrappedNode;
  }

  public override string LocalName => this.ProcessingInstruction.Target;

  public override string Value
  {
    get => this.ProcessingInstruction.Data;
    set => this.ProcessingInstruction.Data = value ?? string.Empty;
  }
}
