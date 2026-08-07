// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExpressionGuardVariableState
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
public class ExpressionGuardVariableState(NodeState parent) : GuardVariableState(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAIwAAAEV4cHJlc3Npb25HdWFyZFZhcmlhYmxlVHlwZUluc3RhbmNlAQAYOwEAGDsYOwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAKAAAARXhwcmVzc2lvbgEAGTsALgBEGTsAAAEASgL/////AQH/////AAAAAA==";
  private PropertyState<ContentFilter> m_expression;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15128U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAIwAAAEV4cHJlc3Npb25HdWFyZFZhcmlhYmxlVHlwZUluc3RhbmNlAQAYOwEAGDsYOwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAKAAAARXhwcmVzc2lvbgEAGTsALgBEGTsAAAEASgL/////AQH/////AAAAAA==");
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

  public PropertyState<ContentFilter> Expression
  {
    get => this.m_expression;
    set
    {
      if (this.m_expression != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_expression = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_expression != null)
      children.Add((BaseInstanceState) this.m_expression);
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
    if (browseName.Name == "Expression")
    {
      if (createOrReplace && this.Expression == null)
        this.Expression = replacement != null ? (PropertyState<ContentFilter>) replacement : new PropertyState<ContentFilter>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Expression;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
