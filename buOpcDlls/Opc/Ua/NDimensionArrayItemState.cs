// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NDimensionArrayItemState
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
public class NDimensionArrayItemState(NodeState parent) : ArrayItemState(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAHwAAAE5EaW1lbnNpb25BcnJheUl0ZW1UeXBlSW5zdGFuY2UBACQvAQAkLyQvAAAAGAAAAAABAf////8FAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQAoLwAuAEQoLwAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQApLwAuAEQpLwAAAQB3A/////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABUaXRsZQEAKi8ALgBEKi8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEF4aXNTY2FsZVR5cGUBACsvAC4ARCsvAAABAC0v/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAEF4aXNEZWZpbml0aW9uAQAsLwAuAEQsLwAAAQAvLwEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<AxisInformation[]> m_axisDefinition;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12068U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => 0;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAHwAAAE5EaW1lbnNpb25BcnJheUl0ZW1UeXBlSW5zdGFuY2UBACQvAQAkLyQvAAAAGAAAAAABAf////8FAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQAoLwAuAEQoLwAAAQB0A/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQApLwAuAEQpLwAAAQB3A/////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABUaXRsZQEAKi8ALgBEKi8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEF4aXNTY2FsZVR5cGUBACsvAC4ARCsvAAABAC0v/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAEF4aXNEZWZpbml0aW9uAQAsLwAuAEQsLwAAAQAvLwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<AxisInformation[]> AxisDefinition
  {
    get => this.m_axisDefinition;
    set
    {
      if (this.m_axisDefinition != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_axisDefinition = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_axisDefinition != null)
      children.Add((BaseInstanceState) this.m_axisDefinition);
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
    if (browseName.Name == "AxisDefinition")
    {
      if (createOrReplace && this.AxisDefinition == null)
        this.AxisDefinition = replacement != null ? (PropertyState<AxisInformation[]>) replacement : new PropertyState<AxisInformation[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.AxisDefinition;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
