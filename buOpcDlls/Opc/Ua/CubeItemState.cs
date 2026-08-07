// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CubeItemState
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
public class CubeItemState(NodeState parent) : ArrayItemState(parent)
{
  private const string InitializationString = "//////////8XYIkCAgAAAAAAFAAAAEN1YmVJdGVtVHlwZUluc3RhbmNlAQAZLwEAGS8ZLwAAABgDAAAAAwAAAAAAAAAAAAAAAAAAAAEB/////wcAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAB0vAC4ARB0vAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAB4vAC4ARB4vAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAfLwAuAEQfLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAIC8ALgBEIC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAhLwAuAEQhLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BACIvAC4ARCIvAAABAC8v/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFpBeGlzRGVmaW5pdGlvbgEAIy8ALgBEIy8AAAEALy//////AQH/////AAAAAA==";
  private PropertyState<AxisInformation> m_xAxisDefinition;
  private PropertyState<AxisInformation> m_yAxisDefinition;
  private PropertyState<AxisInformation> m_zAxisDefinition;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12057U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => 4;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8XYIkCAgAAAAAAFAAAAEN1YmVJdGVtVHlwZUluc3RhbmNlAQAZLwEAGS8ZLwAAABgDAAAAAwAAAAAAAAAAAAAAAAAAAAEB/////wcAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAB0vAC4ARB0vAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAB4vAC4ARB4vAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQAfLwAuAEQfLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEAIC8ALgBEIC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAhLwAuAEQhLwAAAQAvL/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABZQXhpc0RlZmluaXRpb24BACIvAC4ARCIvAAABAC8v/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFpBeGlzRGVmaW5pdGlvbgEAIy8ALgBEIy8AAAEALy//////AQH/////AAAAAA==");
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

  public PropertyState<AxisInformation> ZAxisDefinition
  {
    get => this.m_zAxisDefinition;
    set
    {
      if (this.m_zAxisDefinition != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_zAxisDefinition = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_xAxisDefinition != null)
      children.Add((BaseInstanceState) this.m_xAxisDefinition);
    if (this.m_yAxisDefinition != null)
      children.Add((BaseInstanceState) this.m_yAxisDefinition);
    if (this.m_zAxisDefinition != null)
      children.Add((BaseInstanceState) this.m_zAxisDefinition);
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
      case "ZAxisDefinition":
        if (createOrReplace && this.ZAxisDefinition == null)
          this.ZAxisDefinition = replacement != null ? (PropertyState<AxisInformation>) replacement : new PropertyState<AxisInformation>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ZAxisDefinition;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
