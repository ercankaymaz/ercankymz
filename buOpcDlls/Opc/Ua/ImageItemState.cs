// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ImageItemState
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
public class ImageItemState(NodeState parent) : ArrayItemState(parent)
{
  private const string InitializationString = "//////////8XYIkCAgAAAAAAFQAAAEltYWdlSXRlbVR5cGVJbnN0YW5jZQEADy8BAA8vDy8AAAAYAgAAAAIAAAAAAAAAAAAAAAEB/////wYAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBABMvAC4ARBMvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBABQvAC4ARBQvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAVLwAuAEQVLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAFi8ALgBEFi8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAXLwAuAEQXLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BABgvAC4ARBgvAAABAC8v/////wEB/////wAAAAA=";
  private PropertyState<AxisInformation> m_xAxisDefinition;
  private PropertyState<AxisInformation> m_yAxisDefinition;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12047U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => 3;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8XYIkCAgAAAAAAFQAAAEltYWdlSXRlbVR5cGVJbnN0YW5jZQEADy8BAA8vDy8AAAAYAgAAAAIAAAAAAAAAAAAAAAEB/////wYAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBABMvAC4ARBMvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBABQvAC4ARBQvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAVLwAuAEQVLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAFi8ALgBEFi8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAXLwAuAEQXLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BABgvAC4ARBgvAAABAC8v/////wEB/////wAAAAA=");
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

  public PropertyState<AxisInformation> XAxisDefinition
  {
    get => this.m_xAxisDefinition;
    set
    {
      if (this.m_xAxisDefinition != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_xAxisDefinition = value;
    }
  }

  public PropertyState<AxisInformation> YAxisDefinition
  {
    get => this.m_yAxisDefinition;
    set
    {
      if (this.m_yAxisDefinition != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_yAxisDefinition = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_xAxisDefinition != null)
      children.Add((BaseInstanceState) this.m_xAxisDefinition);
    if (this.m_yAxisDefinition != null)
      children.Add((BaseInstanceState) this.m_yAxisDefinition);
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
      case "XAxisDefinition":
        if (createOrReplace && this.XAxisDefinition == null)
          this.XAxisDefinition = replacement != null ? (PropertyState<AxisInformation>) replacement : new PropertyState<AxisInformation>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.XAxisDefinition;
        break;
      case "YAxisDefinition":
        if (createOrReplace && this.YAxisDefinition == null)
          this.YAxisDefinition = replacement != null ? (PropertyState<AxisInformation>) replacement : new PropertyState<AxisInformation>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.YAxisDefinition;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
