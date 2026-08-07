// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeTsnVlanTagState
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
public class IIeeeTsnVlanTagState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAElJZWVlVHNuVmxhblRhZ1R5cGVJbnN0YW5jZQEAil4BAIpeil4AAP////8CAAAAFWCJCgIAAAAAAAYAAABWbGFuSWQBAIteAC8AP4teAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABQcmlvcml0eUNvZGVQb2ludAEAjF4ALwA/jF4AAAAD/////wEB/////wAAAAA=";
  private BaseDataVariableState<ushort> m_vlanId;
  private BaseDataVariableState<byte> m_priorityCodePoint;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24202U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAElJZWVlVHNuVmxhblRhZ1R5cGVJbnN0YW5jZQEAil4BAIpeil4AAP////8CAAAAFWCJCgIAAAAAAAYAAABWbGFuSWQBAIteAC8AP4teAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABQcmlvcml0eUNvZGVQb2ludAEAjF4ALwA/jF4AAAAD/////wEB/////wAAAAA=");
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

  public BaseDataVariableState<ushort> VlanId
  {
    get => this.m_vlanId;
    set
    {
      if (this.m_vlanId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_vlanId = value;
    }
  }

  public BaseDataVariableState<byte> PriorityCodePoint
  {
    get => this.m_priorityCodePoint;
    set
    {
      if (this.m_priorityCodePoint != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_priorityCodePoint = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_vlanId != null)
      children.Add((BaseInstanceState) this.m_vlanId);
    if (this.m_priorityCodePoint != null)
      children.Add((BaseInstanceState) this.m_priorityCodePoint);
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
    switch (browseName.Name)
    {
      case "VlanId":
        if (createOrReplace && this.VlanId == null)
          this.VlanId = replacement != null ? (BaseDataVariableState<ushort>) replacement : new BaseDataVariableState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.VlanId;
        break;
      case "PriorityCodePoint":
        if (createOrReplace && this.PriorityCodePoint == null)
          this.PriorityCodePoint = replacement != null ? (BaseDataVariableState<byte>) replacement : new BaseDataVariableState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PriorityCodePoint;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
