// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubDiagnosticsCounterState
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
public class PubSubDiagnosticsCounterState(NodeState parent) : BaseDataVariableState<uint>(parent)
{
  private const string TimeFirstChange_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFRpbWVGaXJzdENoYW5nZQEAEU0ALgBEEU0AAAAN/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAJAAAAFB1YlN1YkRpYWdub3N0aWNzQ291bnRlclR5cGVJbnN0YW5jZQEADU0BAA1NDU0AAAAH/////wEB/////wQAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEADk0ALgBEDk0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAPTQAuAEQPTQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAQTQAuAEQQTQAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABUaW1lRmlyc3RDaGFuZ2UBABFNAC4ARBFNAAAADf////8BAf////8AAAAA";
  private PropertyState<bool> m_active;
  private PropertyState<PubSubDiagnosticsCounterClassification> m_classification;
  private PropertyState<Opc.Ua.DiagnosticsLevel> m_diagnosticsLevel;
  private PropertyState<DateTime> m_timeFirstChange;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 19725U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 7U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAJAAAAFB1YlN1YkRpYWdub3N0aWNzQ291bnRlclR5cGVJbnN0YW5jZQEADU0BAA1NDU0AAAAH/////wEB/////wQAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEADk0ALgBEDk0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAPTQAuAEQPTQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAQTQAuAEQQTQAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABUaW1lRmlyc3RDaGFuZ2UBABFNAC4ARBFNAAAADf////8BAf////8AAAAA");
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
    if (this.TimeFirstChange == null)
      return;
    this.TimeFirstChange.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFRpbWVGaXJzdENoYW5nZQEAEU0ALgBEEU0AAAAN/////wEB/////wAAAAA=");
  }

  public PropertyState<bool> Active
  {
    get => this.m_active;
    set
    {
      if (this.m_active != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_active = value;
    }
  }

  public PropertyState<PubSubDiagnosticsCounterClassification> Classification
  {
    get => this.m_classification;
    set
    {
      if (this.m_classification != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_classification = value;
    }
  }

  public PropertyState<Opc.Ua.DiagnosticsLevel> DiagnosticsLevel
  {
    get => this.m_diagnosticsLevel;
    set
    {
      if (this.m_diagnosticsLevel != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_diagnosticsLevel = value;
    }
  }

  public PropertyState<DateTime> TimeFirstChange
  {
    get => this.m_timeFirstChange;
    set
    {
      if (this.m_timeFirstChange != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_timeFirstChange = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_active != null)
      children.Add((BaseInstanceState) this.m_active);
    if (this.m_classification != null)
      children.Add((BaseInstanceState) this.m_classification);
    if (this.m_diagnosticsLevel != null)
      children.Add((BaseInstanceState) this.m_diagnosticsLevel);
    if (this.m_timeFirstChange != null)
      children.Add((BaseInstanceState) this.m_timeFirstChange);
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
      case "Active":
        if (createOrReplace && this.Active == null)
          this.Active = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Active;
        break;
      case "Classification":
        if (createOrReplace && this.Classification == null)
          this.Classification = replacement != null ? (PropertyState<PubSubDiagnosticsCounterClassification>) replacement : new PropertyState<PubSubDiagnosticsCounterClassification>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Classification;
        break;
      case "DiagnosticsLevel":
        if (createOrReplace && this.DiagnosticsLevel == null)
          this.DiagnosticsLevel = replacement != null ? (PropertyState<Opc.Ua.DiagnosticsLevel>) replacement : new PropertyState<Opc.Ua.DiagnosticsLevel>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DiagnosticsLevel;
        break;
      case "TimeFirstChange":
        if (createOrReplace && this.TimeFirstChange == null)
          this.TimeFirstChange = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TimeFirstChange;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
