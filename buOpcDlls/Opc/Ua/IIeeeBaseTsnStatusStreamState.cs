// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeBaseTsnStatusStreamState
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
public class IIeeeBaseTsnStatusStreamState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string TalkerStatus_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFRhbGtlclN0YXR1cwEAeF4ALwA/eF4AAAEAnl7/////AQH/////AAAAAA==";
  private const string ListenerStatus_InitializationString = "//////////8VYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAElJZWVlQmFzZVRzblN0YXR1c1N0cmVhbVR5cGVJbnN0YW5jZQEAd14BAHded14AAP////8EAAAAFWCJCgIAAAAAAAwAAABUYWxrZXJTdGF0dXMBAHheAC8AP3heAAABAJ5e/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABGYWlsdXJlQ29kZQEAel4ALwA/el4AAAEAml7/////AQH/////AAAAABdgiQoCAAAAAAAXAAAARmFpbHVyZVN5c3RlbUlkZW50aWZpZXIBAHteAC8AP3teAAAAAwIAAAACAAAAAAAAAAgAAAABAf////8AAAAA";
  private BaseDataVariableState<TsnTalkerStatus> m_talkerStatus;
  private BaseDataVariableState<TsnListenerStatus> m_listenerStatus;
  private BaseDataVariableState<TsnFailureCode> m_failureCode;
  private BaseDataVariableState m_failureSystemIdentifier;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24183U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAElJZWVlQmFzZVRzblN0YXR1c1N0cmVhbVR5cGVJbnN0YW5jZQEAd14BAHded14AAP////8EAAAAFWCJCgIAAAAAAAwAAABUYWxrZXJTdGF0dXMBAHheAC8AP3heAAABAJ5e/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABGYWlsdXJlQ29kZQEAel4ALwA/el4AAAEAml7/////AQH/////AAAAABdgiQoCAAAAAAAXAAAARmFpbHVyZVN5c3RlbUlkZW50aWZpZXIBAHteAC8AP3teAAAAAwIAAAACAAAAAAAAAAgAAAABAf////8AAAAA");
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
    if (this.TalkerStatus != null)
      this.TalkerStatus.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFRhbGtlclN0YXR1cwEAeF4ALwA/eF4AAAEAnl7/////AQH/////AAAAAA==");
    if (this.ListenerStatus == null)
      return;
    this.ListenerStatus.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAExpc3RlbmVyU3RhdHVzAQB5XgAvAD95XgAAAQCgXv////8BAf////8AAAAA");
  }

  public BaseDataVariableState<TsnTalkerStatus> TalkerStatus
  {
    get => this.m_talkerStatus;
    set
    {
      if (this.m_talkerStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_talkerStatus = value;
    }
  }

  public BaseDataVariableState<TsnListenerStatus> ListenerStatus
  {
    get => this.m_listenerStatus;
    set
    {
      if (this.m_listenerStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_listenerStatus = value;
    }
  }

  public BaseDataVariableState<TsnFailureCode> FailureCode
  {
    get => this.m_failureCode;
    set
    {
      if (this.m_failureCode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_failureCode = value;
    }
  }

  public BaseDataVariableState FailureSystemIdentifier
  {
    get => this.m_failureSystemIdentifier;
    set
    {
      if (this.m_failureSystemIdentifier != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_failureSystemIdentifier = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_talkerStatus != null)
      children.Add((BaseInstanceState) this.m_talkerStatus);
    if (this.m_listenerStatus != null)
      children.Add((BaseInstanceState) this.m_listenerStatus);
    if (this.m_failureCode != null)
      children.Add((BaseInstanceState) this.m_failureCode);
    if (this.m_failureSystemIdentifier != null)
      children.Add((BaseInstanceState) this.m_failureSystemIdentifier);
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
      case "TalkerStatus":
        if (createOrReplace && this.TalkerStatus == null)
          this.TalkerStatus = replacement != null ? (BaseDataVariableState<TsnTalkerStatus>) replacement : new BaseDataVariableState<TsnTalkerStatus>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TalkerStatus;
        break;
      case "ListenerStatus":
        if (createOrReplace && this.ListenerStatus == null)
          this.ListenerStatus = replacement != null ? (BaseDataVariableState<TsnListenerStatus>) replacement : new BaseDataVariableState<TsnListenerStatus>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ListenerStatus;
        break;
      case "FailureCode":
        if (createOrReplace && this.FailureCode == null)
          this.FailureCode = replacement != null ? (BaseDataVariableState<TsnFailureCode>) replacement : new BaseDataVariableState<TsnFailureCode>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.FailureCode;
        break;
      case "FailureSystemIdentifier":
        if (createOrReplace && this.FailureSystemIdentifier == null)
          this.FailureSystemIdentifier = replacement != null ? (BaseDataVariableState) replacement : new BaseDataVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.FailureSystemIdentifier;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
