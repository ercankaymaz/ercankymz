// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConditionVariableState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ConditionVariableState(NodeState parent) : BaseDataVariableState(parent)
{
  private const string InitializationString = "//////////8VYIECAgAAAAAAHQAAAENvbmRpdGlvblZhcmlhYmxlVHlwZUluc3RhbmNlAQAqIwEAKiMqIwAAABgBAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABACsjAC4ARCsjAAABACYB/////wEB/////wAAAAA=";
  private PropertyState<DateTime> m_sourceTimestamp;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 9002U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAHQAAAENvbmRpdGlvblZhcmlhYmxlVHlwZUluc3RhbmNlAQAqIwEAKiMqIwAAABgBAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABACsjAC4ARCsjAAABACYB/////wEB/////wAAAAA=");
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

  public PropertyState<DateTime> SourceTimestamp
  {
    get => this.m_sourceTimestamp;
    set
    {
      if (this.m_sourceTimestamp != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sourceTimestamp = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_sourceTimestamp != null)
      children.Add((BaseInstanceState) this.m_sourceTimestamp);
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
    if (browseName.Name == "SourceTimestamp")
    {
      if (createOrReplace && this.SourceTimestamp == null)
        this.SourceTimestamp = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.SourceTimestamp;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
