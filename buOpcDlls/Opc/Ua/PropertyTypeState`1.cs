// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PropertyTypeState`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class PropertyTypeState<T> : PropertyTypeState
{
  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Value = default (T);
    this.DataType = TypeInfo.GetDataTypeId(typeof (T));
    this.ValueRank = TypeInfo.GetValueRank(typeof (T));
  }

  protected override object ExtractValueFromVariant(
    ISystemContext context,
    object value,
    bool throwOnError)
  {
    return BaseVariableState.ExtractValueFromVariant<T>(context, value, throwOnError);
  }

  public T Value
  {
    get => BaseVariableState.CheckTypeBeforeCast<T>(base.Value, true);
    set => this.Value = (object) value;
  }
}
