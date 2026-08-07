// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PropertyState`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PropertyState<T> : PropertyState
{
  public PropertyState(NodeState parent)
    : base(parent)
  {
    this.Value = default (T);
    this.IsValueType = !typeof (T).GetTypeInfo().IsValueType;
  }

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
