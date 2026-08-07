// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CubeItemState`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CubeItemState<T> : CubeItemState
{
  public CubeItemState(NodeState parent)
    : base(parent)
  {
    this.Value = default (T);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Value = default (T);
    this.DataType = TypeInfo.GetDataTypeId(typeof (T));
    this.ValueRank = TypeInfo.GetValueRank(typeof (T));
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  public T Value
  {
    get => BaseVariableState.CheckTypeBeforeCast<T>(base.Value, true);
    set => this.Value = (object) value;
  }
}
