// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AlarmRateVariableState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AlarmRateVariableState(NodeState parent) : BaseDataVariableState<double>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAHQAAAEFsYXJtUmF0ZVZhcmlhYmxlVHlwZUluc3RhbmNlAQB9QwEAfUN9QwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAfkMALgBEfkMAAAAF/////wEB/////wAAAAA=";
  private PropertyState<ushort> m_rate;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17277U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAHQAAAEFsYXJtUmF0ZVZhcmlhYmxlVHlwZUluc3RhbmNlAQB9QwEAfUN9QwAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAEAAAAUmF0ZQEAfkMALgBEfkMAAAAF/////wEB/////wAAAAA=");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
  }

  public PropertyState<ushort> Rate
  {
    get => this.m_rate;
    set
    {
      if (this.m_rate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_rate = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_rate != null)
      children.Add((BaseInstanceState) this.m_rate);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    if (browseName.Name == "Rate")
    {
      if (createOrReplace && this.Rate == null)
        this.Rate = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Rate;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
