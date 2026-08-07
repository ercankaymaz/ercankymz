// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerStatusState
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
public class ServerStatusState(NodeState parent) : BaseDataVariableState<ServerStatusDataType>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAGAAAAFNlcnZlclN0YXR1c1R5cGVJbnN0YW5jZQEAWggBAFoIWggAAAEAXgP/////AQH/////BgAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBbCAAvAD9bCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDdXJyZW50VGltZQEAXAgALwA/XAgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAF0IAC8AP10IAAABAFQD/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJ1aWxkSW5mbwEAXggALwEA6wteCAAAAQBSAf////8BAf////8GAAAAFXCJCgIAAAAAAAoAAABQcm9kdWN0VXJpAQByDgAvAD9yDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAABAAAABNYW51ZmFjdHVyZXJOYW1lAQBzDgAvAD9zDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABQcm9kdWN0TmFtZQEAdA4ALwA/dA4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAPAAAAU29mdHdhcmVWZXJzaW9uAQB1DgAvAD91DgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABCdWlsZE51bWJlcgEAdg4ALwA/dg4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAAQnVpbGREYXRlAQB3DgAvAD93DgAAAQAmAf////8BAQAAAAAAQI9A/////wAAAAAVYIkKAgAAAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24BAMAKAC8AP8AKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABTaHV0ZG93blJlYXNvbgEAwQoALwA/wQoAAAAV/////wEB/////wAAAAA=";
  private BaseDataVariableState<DateTime> m_startTime;
  private BaseDataVariableState<DateTime> m_currentTime;
  private BaseDataVariableState<ServerState> m_state;
  private BuildInfoVariableState m_buildInfo;
  private BaseDataVariableState<uint> m_secondsTillShutdown;
  private BaseDataVariableState<LocalizedText> m_shutdownReason;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2138U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 862U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAGAAAAFNlcnZlclN0YXR1c1R5cGVJbnN0YW5jZQEAWggBAFoIWggAAAEAXgP/////AQH/////BgAAABVgiQoCAAAAAAAJAAAAU3RhcnRUaW1lAQBbCAAvAD9bCAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDdXJyZW50VGltZQEAXAgALwA/XAgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAF0IAC8AP10IAAABAFQD/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJ1aWxkSW5mbwEAXggALwEA6wteCAAAAQBSAf////8BAf////8GAAAAFXCJCgIAAAAAAAoAAABQcm9kdWN0VXJpAQByDgAvAD9yDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAABAAAABNYW51ZmFjdHVyZXJOYW1lAQBzDgAvAD9zDgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABQcm9kdWN0TmFtZQEAdA4ALwA/dA4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAPAAAAU29mdHdhcmVWZXJzaW9uAQB1DgAvAD91DgAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABCdWlsZE51bWJlcgEAdg4ALwA/dg4AAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAAQnVpbGREYXRlAQB3DgAvAD93DgAAAQAmAf////8BAQAAAAAAQI9A/////wAAAAAVYIkKAgAAAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24BAMAKAC8AP8AKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABTaHV0ZG93blJlYXNvbgEAwQoALwA/wQoAAAAV/////wEB/////wAAAAA=");
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

  public BaseDataVariableState<DateTime> StartTime
  {
    get => this.m_startTime;
    set
    {
      if (this.m_startTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_startTime = value;
    }
  }

  public BaseDataVariableState<DateTime> CurrentTime
  {
    get => this.m_currentTime;
    set
    {
      if (this.m_currentTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_currentTime = value;
    }
  }

  public BaseDataVariableState<ServerState> State
  {
    get => this.m_state;
    set
    {
      if (this.m_state != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_state = value;
    }
  }

  public BuildInfoVariableState BuildInfo
  {
    get => this.m_buildInfo;
    set
    {
      if (this.m_buildInfo != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_buildInfo = value;
    }
  }

  public BaseDataVariableState<uint> SecondsTillShutdown
  {
    get => this.m_secondsTillShutdown;
    set
    {
      if (this.m_secondsTillShutdown != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_secondsTillShutdown = value;
    }
  }

  public BaseDataVariableState<LocalizedText> ShutdownReason
  {
    get => this.m_shutdownReason;
    set
    {
      if (this.m_shutdownReason != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_shutdownReason = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_startTime != null)
      children.Add((BaseInstanceState) this.m_startTime);
    if (this.m_currentTime != null)
      children.Add((BaseInstanceState) this.m_currentTime);
    if (this.m_state != null)
      children.Add((BaseInstanceState) this.m_state);
    if (this.m_buildInfo != null)
      children.Add((BaseInstanceState) this.m_buildInfo);
    if (this.m_secondsTillShutdown != null)
      children.Add((BaseInstanceState) this.m_secondsTillShutdown);
    if (this.m_shutdownReason != null)
      children.Add((BaseInstanceState) this.m_shutdownReason);
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
      case "StartTime":
        if (createOrReplace && this.StartTime == null)
          this.StartTime = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.StartTime;
        break;
      case "CurrentTime":
        if (createOrReplace && this.CurrentTime == null)
          this.CurrentTime = replacement != null ? (BaseDataVariableState<DateTime>) replacement : new BaseDataVariableState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CurrentTime;
        break;
      case "State":
        if (createOrReplace && this.State == null)
          this.State = replacement != null ? (BaseDataVariableState<ServerState>) replacement : new BaseDataVariableState<ServerState>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.State;
        break;
      case "BuildInfo":
        if (createOrReplace && this.BuildInfo == null)
          this.BuildInfo = replacement != null ? (BuildInfoVariableState) replacement : new BuildInfoVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.BuildInfo;
        break;
      case "SecondsTillShutdown":
        if (createOrReplace && this.SecondsTillShutdown == null)
          this.SecondsTillShutdown = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecondsTillShutdown;
        break;
      case "ShutdownReason":
        if (createOrReplace && this.ShutdownReason == null)
          this.ShutdownReason = replacement != null ? (BaseDataVariableState<LocalizedText>) replacement : new BaseDataVariableState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ShutdownReason;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
