// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubStatusState
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
public class PubSubStatusState(NodeState parent) : BaseObjectState(parent)
{
  private const string Enable_InitializationString = "//////////8EYYIKBAAAAAAABgAAAEVuYWJsZQEANTkALwEANTk1OQAAAQH/////AAAAAA==";
  private const string Disable_InitializationString = "//////////8EYYIKBAAAAAAABwAAAERpc2FibGUBADY5AC8BADY5NjkAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAGAAAAFB1YlN1YlN0YXR1c1R5cGVJbnN0YW5jZQEAMzkBADM5MzkAAP////8DAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEANDkALwA/NDkAAAEANzn/////AQH/////AAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQA1OQAvAQA1OTU5AAABAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQA2OQAvAQA2OTY5AAABAf////8AAAAA";
  private BaseDataVariableState<PubSubState> m_state;
  private MethodState m_enableMethod;
  private MethodState m_disableMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 14643U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGAAAAFB1YlN1YlN0YXR1c1R5cGVJbnN0YW5jZQEAMzkBADM5MzkAAP////8DAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEANDkALwA/NDkAAAEANzn/////AQH/////AAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQA1OQAvAQA1OTU5AAABAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQA2OQAvAQA2OTY5AAABAf////8AAAAA");
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
    if (this.Enable != null)
      this.Enable.Initialize(context, "//////////8EYYIKBAAAAAAABgAAAEVuYWJsZQEANTkALwEANTk1OQAAAQH/////AAAAAA==");
    if (this.Disable == null)
      return;
    this.Disable.Initialize(context, "//////////8EYYIKBAAAAAAABwAAAERpc2FibGUBADY5AC8BADY5NjkAAAEB/////wAAAAA=");
  }

  public BaseDataVariableState<PubSubState> State
  {
    get => this.m_state;
    set
    {
      if (this.m_state != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_state = value;
    }
  }

  public MethodState Enable
  {
    get => this.m_enableMethod;
    set
    {
      if (this.m_enableMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enableMethod = value;
    }
  }

  public MethodState Disable
  {
    get => this.m_disableMethod;
    set
    {
      if (this.m_disableMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_disableMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_state != null)
      children.Add((BaseInstanceState) this.m_state);
    if (this.m_enableMethod != null)
      children.Add((BaseInstanceState) this.m_enableMethod);
    if (this.m_disableMethod != null)
      children.Add((BaseInstanceState) this.m_disableMethod);
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
      case "State":
        if (createOrReplace && this.State == null)
          this.State = replacement != null ? (BaseDataVariableState<PubSubState>) replacement : new BaseDataVariableState<PubSubState>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.State;
        break;
      case "Enable":
        if (createOrReplace && this.Enable == null)
          this.Enable = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Enable;
        break;
      case "Disable":
        if (createOrReplace && this.Disable == null)
          this.Disable = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Disable;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
