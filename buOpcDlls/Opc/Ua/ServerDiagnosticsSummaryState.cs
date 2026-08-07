// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerDiagnosticsSummaryState
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
public class ServerDiagnosticsSummaryState(NodeState parent) : 
  BaseDataVariableState<ServerDiagnosticsSummaryDataType>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAJAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeVR5cGVJbnN0YW5jZQEAZggBAGYIZggAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQBnCAAvAD9nCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAaAgALwA/aAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAaQgALwA/aQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBAGoIAC8AP2oIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAawgALwA/awgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAGwIAC8AP2wIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAbQgALwA/bQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQBvCAAvAD9vCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQBwCAAvAD9wCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBAHEIAC8AP3EIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVkUmVxdWVzdHNDb3VudAEAcggALwA/cggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlamVjdGVkUmVxdWVzdHNDb3VudAEAcwgALwA/cwgAAAAH/////wEB/////wAAAAA=";
  private BaseDataVariableState<uint> m_serverViewCount;
  private BaseDataVariableState<uint> m_currentSessionCount;
  private BaseDataVariableState<uint> m_cumulatedSessionCount;
  private BaseDataVariableState<uint> m_securityRejectedSessionCount;
  private BaseDataVariableState<uint> m_rejectedSessionCount;
  private BaseDataVariableState<uint> m_sessionTimeoutCount;
  private BaseDataVariableState<uint> m_sessionAbortCount;
  private BaseDataVariableState<uint> m_publishingIntervalCount;
  private BaseDataVariableState<uint> m_currentSubscriptionCount;
  private BaseDataVariableState<uint> m_cumulatedSubscriptionCount;
  private BaseDataVariableState<uint> m_securityRejectedRequestsCount;
  private BaseDataVariableState<uint> m_rejectedRequestsCount;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2150U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 859U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAJAAAAFNlcnZlckRpYWdub3N0aWNzU3VtbWFyeVR5cGVJbnN0YW5jZQEAZggBAGYIZggAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQBnCAAvAD9nCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAaAgALwA/aAgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAaQgALwA/aQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBAGoIAC8AP2oIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAawgALwA/awgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAGwIAC8AP2wIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAbQgALwA/bQgAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQBvCAAvAD9vCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQBwCAAvAD9wCAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBAHEIAC8AP3EIAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVkUmVxdWVzdHNDb3VudAEAcggALwA/cggAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlamVjdGVkUmVxdWVzdHNDb3VudAEAcwgALwA/cwgAAAAH/////wEB/////wAAAAA=");
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

  public BaseDataVariableState<uint> ServerViewCount
  {
    get => this.m_serverViewCount;
    set
    {
      if (this.m_serverViewCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverViewCount = value;
    }
  }

  public BaseDataVariableState<uint> CurrentSessionCount
  {
    get => this.m_currentSessionCount;
    set
    {
      if (this.m_currentSessionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentSessionCount = value;
    }
  }

  public BaseDataVariableState<uint> CumulatedSessionCount
  {
    get => this.m_cumulatedSessionCount;
    set
    {
      if (this.m_cumulatedSessionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_cumulatedSessionCount = value;
    }
  }

  public BaseDataVariableState<uint> SecurityRejectedSessionCount
  {
    get => this.m_securityRejectedSessionCount;
    set
    {
      if (this.m_securityRejectedSessionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityRejectedSessionCount = value;
    }
  }

  public BaseDataVariableState<uint> RejectedSessionCount
  {
    get => this.m_rejectedSessionCount;
    set
    {
      if (this.m_rejectedSessionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_rejectedSessionCount = value;
    }
  }

  public BaseDataVariableState<uint> SessionTimeoutCount
  {
    get => this.m_sessionTimeoutCount;
    set
    {
      if (this.m_sessionTimeoutCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionTimeoutCount = value;
    }
  }

  public BaseDataVariableState<uint> SessionAbortCount
  {
    get => this.m_sessionAbortCount;
    set
    {
      if (this.m_sessionAbortCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionAbortCount = value;
    }
  }

  public BaseDataVariableState<uint> PublishingIntervalCount
  {
    get => this.m_publishingIntervalCount;
    set
    {
      if (this.m_publishingIntervalCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishingIntervalCount = value;
    }
  }

  public BaseDataVariableState<uint> CurrentSubscriptionCount
  {
    get => this.m_currentSubscriptionCount;
    set
    {
      if (this.m_currentSubscriptionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentSubscriptionCount = value;
    }
  }

  public BaseDataVariableState<uint> CumulatedSubscriptionCount
  {
    get => this.m_cumulatedSubscriptionCount;
    set
    {
      if (this.m_cumulatedSubscriptionCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_cumulatedSubscriptionCount = value;
    }
  }

  public BaseDataVariableState<uint> SecurityRejectedRequestsCount
  {
    get => this.m_securityRejectedRequestsCount;
    set
    {
      if (this.m_securityRejectedRequestsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityRejectedRequestsCount = value;
    }
  }

  public BaseDataVariableState<uint> RejectedRequestsCount
  {
    get => this.m_rejectedRequestsCount;
    set
    {
      if (this.m_rejectedRequestsCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_rejectedRequestsCount = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_serverViewCount != null)
      children.Add((BaseInstanceState) this.m_serverViewCount);
    if (this.m_currentSessionCount != null)
      children.Add((BaseInstanceState) this.m_currentSessionCount);
    if (this.m_cumulatedSessionCount != null)
      children.Add((BaseInstanceState) this.m_cumulatedSessionCount);
    if (this.m_securityRejectedSessionCount != null)
      children.Add((BaseInstanceState) this.m_securityRejectedSessionCount);
    if (this.m_rejectedSessionCount != null)
      children.Add((BaseInstanceState) this.m_rejectedSessionCount);
    if (this.m_sessionTimeoutCount != null)
      children.Add((BaseInstanceState) this.m_sessionTimeoutCount);
    if (this.m_sessionAbortCount != null)
      children.Add((BaseInstanceState) this.m_sessionAbortCount);
    if (this.m_publishingIntervalCount != null)
      children.Add((BaseInstanceState) this.m_publishingIntervalCount);
    if (this.m_currentSubscriptionCount != null)
      children.Add((BaseInstanceState) this.m_currentSubscriptionCount);
    if (this.m_cumulatedSubscriptionCount != null)
      children.Add((BaseInstanceState) this.m_cumulatedSubscriptionCount);
    if (this.m_securityRejectedRequestsCount != null)
      children.Add((BaseInstanceState) this.m_securityRejectedRequestsCount);
    if (this.m_rejectedRequestsCount != null)
      children.Add((BaseInstanceState) this.m_rejectedRequestsCount);
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
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 15:
          if (name == "ServerViewCount")
          {
            if (createOrReplace && this.ServerViewCount == null)
              this.ServerViewCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ServerViewCount;
            break;
          }
          break;
        case 17:
          if (name == "SessionAbortCount")
          {
            if (createOrReplace && this.SessionAbortCount == null)
              this.SessionAbortCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SessionAbortCount;
            break;
          }
          break;
        case 19:
          switch (name[0])
          {
            case 'C':
              if (name == "CurrentSessionCount")
              {
                if (createOrReplace && this.CurrentSessionCount == null)
                  this.CurrentSessionCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CurrentSessionCount;
                break;
              }
              break;
            case 'S':
              if (name == "SessionTimeoutCount")
              {
                if (createOrReplace && this.SessionTimeoutCount == null)
                  this.SessionTimeoutCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SessionTimeoutCount;
                break;
              }
              break;
          }
          break;
        case 20:
          if (name == "RejectedSessionCount")
          {
            if (createOrReplace && this.RejectedSessionCount == null)
              this.RejectedSessionCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RejectedSessionCount;
            break;
          }
          break;
        case 21:
          switch (name[0])
          {
            case 'C':
              if (name == "CumulatedSessionCount")
              {
                if (createOrReplace && this.CumulatedSessionCount == null)
                  this.CumulatedSessionCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CumulatedSessionCount;
                break;
              }
              break;
            case 'R':
              if (name == "RejectedRequestsCount")
              {
                if (createOrReplace && this.RejectedRequestsCount == null)
                  this.RejectedRequestsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RejectedRequestsCount;
                break;
              }
              break;
          }
          break;
        case 23:
          if (name == "PublishingIntervalCount")
          {
            if (createOrReplace && this.PublishingIntervalCount == null)
              this.PublishingIntervalCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.PublishingIntervalCount;
            break;
          }
          break;
        case 24:
          if (name == "CurrentSubscriptionCount")
          {
            if (createOrReplace && this.CurrentSubscriptionCount == null)
              this.CurrentSubscriptionCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CurrentSubscriptionCount;
            break;
          }
          break;
        case 26:
          if (name == "CumulatedSubscriptionCount")
          {
            if (createOrReplace && this.CumulatedSubscriptionCount == null)
              this.CumulatedSubscriptionCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CumulatedSubscriptionCount;
            break;
          }
          break;
        case 28:
          if (name == "SecurityRejectedSessionCount")
          {
            if (createOrReplace && this.SecurityRejectedSessionCount == null)
              this.SecurityRejectedSessionCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SecurityRejectedSessionCount;
            break;
          }
          break;
        case 29:
          if (name == "SecurityRejectedRequestsCount")
          {
            if (createOrReplace && this.SecurityRejectedRequestsCount == null)
              this.SecurityRejectedRequestsCount = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SecurityRejectedRequestsCount;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
