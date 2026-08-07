// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StateMachineState
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
public class StateMachineState(NodeState parent) : BaseObjectState(parent)
{
  private const string LastTransition_InitializationString = "//////////8VYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQDSCgAvAQDKCtIKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAjA4ALgBEjA4AAAAY/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAGAAAAFN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEA+wgBAPsI+wgAAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANEKAC8BAMMK0QoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCIDgAuAESIDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BANIKAC8BAMoK0goAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCMDgAuAESMDgAAABj/////AQH/////AAAAAA==";
  private StateVariableState m_currentState;
  private TransitionVariableState m_lastTransition;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2299U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGAAAAFN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEA+wgBAPsI+wgAAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBANEKAC8BAMMK0QoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCIDgAuAESIDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BANIKAC8BAMoK0goAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCMDgAuAESMDgAAABj/////AQH/////AAAAAA==");
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
    if (this.LastTransition == null)
      return;
    this.LastTransition.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQDSCgAvAQDKCtIKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAjA4ALgBEjA4AAAAY/////wEB/////wAAAAA=");
  }

  public StateVariableState CurrentState
  {
    get => this.m_currentState;
    set
    {
      if (this.m_currentState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentState = value;
    }
  }

  public TransitionVariableState LastTransition
  {
    get => this.m_lastTransition;
    set
    {
      if (this.m_lastTransition != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastTransition = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_currentState != null)
      children.Add((BaseInstanceState) this.m_currentState);
    if (this.m_lastTransition != null)
      children.Add((BaseInstanceState) this.m_lastTransition);
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
      case "CurrentState":
        if (createOrReplace && this.CurrentState == null)
          this.CurrentState = replacement != null ? (StateVariableState) replacement : new StateVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CurrentState;
        break;
      case "LastTransition":
        if (createOrReplace && this.LastTransition == null)
          this.LastTransition = replacement != null ? (TransitionVariableState) replacement : new TransitionVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.LastTransition;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
