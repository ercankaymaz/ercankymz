// Decompiled with JetBrains decompiler
// Type: Opc.Ua.YArrayItemState
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
public class YArrayItemState(NodeState parent) : ArrayItemState(parent)
{
  private const string InitializationString = "//////////8XYIkCAgAAAAAAFgAAAFlBcnJheUl0ZW1UeXBlSW5zdGFuY2UBAP0uAQD9Lv0uAAAAGAEAAAABAAAAAAAAAAEB/////wUAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAAEvAC4ARAEvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAAIvAC4ARAIvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQADLwAuAEQDLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEABC8ALgBEBC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAFLwAuAEQFLwAAAQAvL/////8BAf////8AAAAA";
  private PropertyState<AxisInformation> m_xAxisDefinition;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12029U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => 2;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8XYIkCAgAAAAAAFgAAAFlBcnJheUl0ZW1UeXBlSW5zdGFuY2UBAP0uAQD9Lv0uAAAAGAEAAAABAAAAAAAAAAEB/////wUAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAAEvAC4ARAEvAAABAHQD/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAAIvAC4ARAIvAAABAHcD/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFRpdGxlAQADLwAuAEQDLwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQXhpc1NjYWxlVHlwZQEABC8ALgBEBC8AAAEALS//////AQH/////AAAAABVgiQoCAAAAAAAPAAAAWEF4aXNEZWZpbml0aW9uAQAFLwAuAEQFLwAAAQAvL/////8BAf////8AAAAA");
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

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_xAxisDefinition != null)
      children.Add((BaseInstanceState) this.m_xAxisDefinition);
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
    if (browseName.Name == "XAxisDefinition")
    {
      if (createOrReplace && this.XAxisDefinition == null)
        this.XAxisDefinition = replacement != null ? (PropertyState<AxisInformation>) replacement : new PropertyState<AxisInformation>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.XAxisDefinition;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
