// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TwoStateVariableState
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
public class TwoStateVariableState(NodeState parent) : StateVariableState(parent)
{
  private const string TransitionTime_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAA";
  private const string EffectiveTransitionTime_InitializationString = "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQApIwAuAEQpIwAAAQAmAf////8BAf////8AAAAA";
  private const string TrueState_InitializationString = "//////////8VYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEAZisALgBEZisAAAAV/////wEB/////wAAAAA=";
  private const string FalseState_InitializationString = "//////////8VYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAGcrAC4ARGcrAAAAFf////8BAf////8AAAAA";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAHAAAAFR3b1N0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBACMjAQAjIyMjAAAAFf////8BAf////8FAAAAFWCJCgIAAAAAAAIAAABJZAEAJCMALgBEJCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAKSMALgBEKSMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQBmKwAuAERmKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAZysALgBEZysAAAAV/////wEB/////wAAAAA=";
  private PropertyState<DateTime> m_transitionTime;
  private PropertyState<DateTime> m_effectiveTransitionTime;
  private PropertyState<LocalizedText> m_trueState;
  private PropertyState<LocalizedText> m_falseState;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 8995U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAHAAAAFR3b1N0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBACMjAQAjIyMjAAAAFf////8BAf////8FAAAAFWCJCgIAAAAAAAIAAABJZAEAJCMALgBEJCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAKSMALgBEKSMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQBmKwAuAERmKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAZysALgBEZysAAAAV/////wEB/////wAAAAA=");
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
    if (this.TransitionTime != null)
      this.TransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQAoIwAuAEQoIwAAAQAmAf////8BAf////8AAAAA");
    if (this.EffectiveTransitionTime != null)
      this.EffectiveTransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQApIwAuAEQpIwAAAQAmAf////8BAf////8AAAAA");
    if (this.TrueState != null)
      this.TrueState.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEAZisALgBEZisAAAAV/////wEB/////wAAAAA=");
    if (this.FalseState == null)
      return;
    this.FalseState.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAGcrAC4ARGcrAAAAFf////8BAf////8AAAAA");
  }

  public PropertyState<bool> Id
  {
    get => (PropertyState<bool>) base.Id;
    set => this.Id = (PropertyState) value;
  }

  public PropertyState<DateTime> TransitionTime
  {
    get => this.m_transitionTime;
    set
    {
      if (this.m_transitionTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transitionTime = value;
    }
  }

  public PropertyState<DateTime> EffectiveTransitionTime
  {
    get => this.m_effectiveTransitionTime;
    set
    {
      if (this.m_effectiveTransitionTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_effectiveTransitionTime = value;
    }
  }

  public PropertyState<LocalizedText> TrueState
  {
    get => this.m_trueState;
    set
    {
      if (this.m_trueState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_trueState = value;
    }
  }

  public PropertyState<LocalizedText> FalseState
  {
    get => this.m_falseState;
    set
    {
      if (this.m_falseState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_falseState = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_transitionTime != null)
      children.Add((BaseInstanceState) this.m_transitionTime);
    if (this.m_effectiveTransitionTime != null)
      children.Add((BaseInstanceState) this.m_effectiveTransitionTime);
    if (this.m_trueState != null)
      children.Add((BaseInstanceState) this.m_trueState);
    if (this.m_falseState != null)
      children.Add((BaseInstanceState) this.m_falseState);
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
      case "Id":
        if (createOrReplace && this.Id == null)
          this.Id = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Id;
        break;
      case "TransitionTime":
        if (createOrReplace && this.TransitionTime == null)
          this.TransitionTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TransitionTime;
        break;
      case "EffectiveTransitionTime":
        if (createOrReplace && this.EffectiveTransitionTime == null)
          this.EffectiveTransitionTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EffectiveTransitionTime;
        break;
      case "TrueState":
        if (createOrReplace && this.TrueState == null)
          this.TrueState = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TrueState;
        break;
      case "FalseState":
        if (createOrReplace && this.FalseState == null)
          this.FalseState = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.FalseState;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
