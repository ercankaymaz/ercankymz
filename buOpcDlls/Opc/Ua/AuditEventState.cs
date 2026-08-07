// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditEventState
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
public class AuditEventState(NodeState parent) : BaseEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAFgAAAEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAAQIAQAECAQIAAD/////DQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAgAwALgBEgAwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAgQwALgBEgQwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAIIMAC4ARIIMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCDDAAuAESDDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAhAwALgBEhAwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAIUMAC4ARIUMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAIcMAC4ARIcMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAiAwALgBEiAwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEABQgALgBEBQgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAGCAAuAEQGCAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAAcIAC4ARAcIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAAgIAC4ARAgIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAkIAC4ARAkIAAAADP////8BAf////8AAAAA";
  private PropertyState<DateTime> m_actionTimeStamp;
  private PropertyState<bool> m_status;
  private PropertyState<string> m_serverId;
  private PropertyState<string> m_clientAuditEntryId;
  private PropertyState<string> m_clientUserId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2052U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFgAAAEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAAQIAQAECAQIAAD/////DQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAgAwALgBEgAwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAgQwALgBEgQwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAIIMAC4ARIIMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCDDAAuAESDDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAhAwALgBEhAwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAIUMAC4ARIUMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAIcMAC4ARIcMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAiAwALgBEiAwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEABQgALgBEBQgAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAGCAAuAEQGCAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAAcIAC4ARAcIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAAgIAC4ARAgIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAkIAC4ARAkIAAAADP////8BAf////8AAAAA");
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

  public PropertyState<DateTime> ActionTimeStamp
  {
    get => this.m_actionTimeStamp;
    set
    {
      if (this.m_actionTimeStamp != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_actionTimeStamp = value;
    }
  }

  public PropertyState<bool> Status
  {
    get => this.m_status;
    set
    {
      if (this.m_status != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_status = value;
    }
  }

  public PropertyState<string> ServerId
  {
    get => this.m_serverId;
    set
    {
      if (this.m_serverId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverId = value;
    }
  }

  public PropertyState<string> ClientAuditEntryId
  {
    get => this.m_clientAuditEntryId;
    set
    {
      if (this.m_clientAuditEntryId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientAuditEntryId = value;
    }
  }

  public PropertyState<string> ClientUserId
  {
    get => this.m_clientUserId;
    set
    {
      if (this.m_clientUserId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientUserId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_actionTimeStamp != null)
      children.Add((BaseInstanceState) this.m_actionTimeStamp);
    if (this.m_status != null)
      children.Add((BaseInstanceState) this.m_status);
    if (this.m_serverId != null)
      children.Add((BaseInstanceState) this.m_serverId);
    if (this.m_clientAuditEntryId != null)
      children.Add((BaseInstanceState) this.m_clientAuditEntryId);
    if (this.m_clientUserId != null)
      children.Add((BaseInstanceState) this.m_clientUserId);
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
      case "ActionTimeStamp":
        if (createOrReplace && this.ActionTimeStamp == null)
          this.ActionTimeStamp = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ActionTimeStamp;
        break;
      case "Status":
        if (createOrReplace && this.Status == null)
          this.Status = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Status;
        break;
      case "ServerId":
        if (createOrReplace && this.ServerId == null)
          this.ServerId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ServerId;
        break;
      case "ClientAuditEntryId":
        if (createOrReplace && this.ClientAuditEntryId == null)
          this.ClientAuditEntryId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ClientAuditEntryId;
        break;
      case "ClientUserId":
        if (createOrReplace && this.ClientUserId == null)
          this.ClientUserId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ClientUserId;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  public virtual void Initialize(
    ISystemContext context,
    NodeState source,
    EventSeverity severity,
    LocalizedText message,
    bool status,
    DateTime actionTimestamp)
  {
    this.Initialize(context, source, severity, message);
    this.m_status = new PropertyState<bool>((NodeState) this);
    this.m_status.Value = status;
    if (actionTimestamp != DateTime.MinValue)
    {
      this.m_actionTimeStamp = new PropertyState<DateTime>((NodeState) this);
      this.m_actionTimeStamp.Value = actionTimestamp;
    }
    if (context.NamespaceUris != null)
    {
      this.m_serverId = new PropertyState<string>((NodeState) this);
      this.m_serverId.Value = context.NamespaceUris.GetString(1U);
    }
    if (context.AuditEntryId != null)
    {
      this.m_clientAuditEntryId = new PropertyState<string>((NodeState) this);
      this.m_clientAuditEntryId.Value = context.AuditEntryId;
    }
    if (context.UserIdentity == null)
      return;
    this.m_clientUserId = new PropertyState<string>((NodeState) this);
    this.m_clientUserId.Value = context.UserIdentity.DisplayName;
  }
}
