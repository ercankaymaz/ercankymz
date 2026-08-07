// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseEventState
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
public class BaseEventState(NodeState parent) : BaseObjectState(parent)
{
  private const string LocalTime_InitializationString = "//////////8VYIkKAgAAAAAACQAAAExvY2FsVGltZQEAdgwALgBEdgwAAAEA0CL/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAFQAAAEJhc2VFdmVudFR5cGVJbnN0YW5jZQEA+QcBAPkH+QcAAP////8JAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQD6BwAuAET6BwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQD7BwAuAET7BwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA/AcALgBE/AcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAP0HAC4ARP0HAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD+BwAuAET+BwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA/wcALgBE/wcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAATG9jYWxUaW1lAQB2DAAuAER2DAAAAQDQIv////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQACCAAuAEQCCAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAMIAC4ARAMIAAAABf////8BAf////8AAAAA";
  private PropertyState<byte[]> m_eventId;
  private PropertyState<NodeId> m_eventType;
  private PropertyState<NodeId> m_sourceNode;
  private PropertyState<string> m_sourceName;
  private PropertyState<DateTime> m_time;
  private PropertyState<DateTime> m_receiveTime;
  private PropertyState<TimeZoneDataType> m_localTime;
  private PropertyState<LocalizedText> m_message;
  private PropertyState<ushort> m_severity;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2041U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFQAAAEJhc2VFdmVudFR5cGVJbnN0YW5jZQEA+QcBAPkH+QcAAP////8JAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQD6BwAuAET6BwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQD7BwAuAET7BwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA/AcALgBE/AcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAP0HAC4ARP0HAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD+BwAuAET+BwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA/wcALgBE/wcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAATG9jYWxUaW1lAQB2DAAuAER2DAAAAQDQIv////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQACCAAuAEQCCAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAMIAC4ARAMIAAAABf////8BAf////8AAAAA");
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
    if (this.LocalTime == null)
      return;
    this.LocalTime.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAExvY2FsVGltZQEAdgwALgBEdgwAAAEA0CL/////AQH/////AAAAAA==");
  }

  public PropertyState<byte[]> EventId
  {
    get => this.m_eventId;
    set
    {
      if (this.m_eventId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_eventId = value;
    }
  }

  public PropertyState<NodeId> EventType
  {
    get => this.m_eventType;
    set
    {
      if (this.m_eventType != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_eventType = value;
    }
  }

  public PropertyState<NodeId> SourceNode
  {
    get => this.m_sourceNode;
    set
    {
      if (this.m_sourceNode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sourceNode = value;
    }
  }

  public PropertyState<string> SourceName
  {
    get => this.m_sourceName;
    set
    {
      if (this.m_sourceName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sourceName = value;
    }
  }

  public PropertyState<DateTime> Time
  {
    get => this.m_time;
    set
    {
      if (this.m_time != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_time = value;
    }
  }

  public PropertyState<DateTime> ReceiveTime
  {
    get => this.m_receiveTime;
    set
    {
      if (this.m_receiveTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_receiveTime = value;
    }
  }

  public PropertyState<TimeZoneDataType> LocalTime
  {
    get => this.m_localTime;
    set
    {
      if (this.m_localTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_localTime = value;
    }
  }

  public PropertyState<LocalizedText> Message
  {
    get => this.m_message;
    set
    {
      if (this.m_message != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_message = value;
    }
  }

  public PropertyState<ushort> Severity
  {
    get => this.m_severity;
    set
    {
      if (this.m_severity != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_severity = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_eventId != null)
      children.Add((BaseInstanceState) this.m_eventId);
    if (this.m_eventType != null)
      children.Add((BaseInstanceState) this.m_eventType);
    if (this.m_sourceNode != null)
      children.Add((BaseInstanceState) this.m_sourceNode);
    if (this.m_sourceName != null)
      children.Add((BaseInstanceState) this.m_sourceName);
    if (this.m_time != null)
      children.Add((BaseInstanceState) this.m_time);
    if (this.m_receiveTime != null)
      children.Add((BaseInstanceState) this.m_receiveTime);
    if (this.m_localTime != null)
      children.Add((BaseInstanceState) this.m_localTime);
    if (this.m_message != null)
      children.Add((BaseInstanceState) this.m_message);
    if (this.m_severity != null)
      children.Add((BaseInstanceState) this.m_severity);
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
        case 4:
          if (name == "Time")
          {
            if (createOrReplace && this.Time == null)
              this.Time = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Time;
            break;
          }
          break;
        case 7:
          switch (name[0])
          {
            case 'E':
              if (name == "EventId")
              {
                if (createOrReplace && this.EventId == null)
                  this.EventId = replacement != null ? (PropertyState<byte[]>) replacement : new PropertyState<byte[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.EventId;
                break;
              }
              break;
            case 'M':
              if (name == "Message")
              {
                if (createOrReplace && this.Message == null)
                  this.Message = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Message;
                break;
              }
              break;
          }
          break;
        case 8:
          if (name == "Severity")
          {
            if (createOrReplace && this.Severity == null)
              this.Severity = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Severity;
            break;
          }
          break;
        case 9:
          switch (name[0])
          {
            case 'E':
              if (name == "EventType")
              {
                if (createOrReplace && this.EventType == null)
                  this.EventType = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.EventType;
                break;
              }
              break;
            case 'L':
              if (name == "LocalTime")
              {
                if (createOrReplace && this.LocalTime == null)
                  this.LocalTime = replacement != null ? (PropertyState<TimeZoneDataType>) replacement : new PropertyState<TimeZoneDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LocalTime;
                break;
              }
              break;
          }
          break;
        case 10:
          switch (name[7])
          {
            case 'a':
              if (name == "SourceName")
              {
                if (createOrReplace && this.SourceName == null)
                  this.SourceName = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SourceName;
                break;
              }
              break;
            case 'o':
              if (name == "SourceNode")
              {
                if (createOrReplace && this.SourceNode == null)
                  this.SourceNode = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SourceNode;
                break;
              }
              break;
          }
          break;
        case 11:
          if (name == "ReceiveTime")
          {
            if (createOrReplace && this.ReceiveTime == null)
              this.ReceiveTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ReceiveTime;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  public virtual void Initialize(
    ISystemContext context,
    NodeState source,
    EventSeverity severity,
    LocalizedText message)
  {
    this.m_eventId = new PropertyState<byte[]>((NodeState) this);
    this.m_eventId.Value = Guid.NewGuid().ToByteArray();
    this.m_eventType = new PropertyState<NodeId>((NodeState) this);
    this.m_eventType.Value = this.GetDefaultTypeDefinitionId(context.NamespaceUris);
    this.TypeDefinitionId = this.m_eventType.Value;
    if (source != null)
    {
      if (!NodeId.IsNull(source.NodeId))
      {
        this.m_sourceNode = new PropertyState<NodeId>((NodeState) this);
        this.m_sourceNode.Value = source.NodeId;
        this.m_sourceNode.RolePermissions = source.RolePermissions;
        this.m_sourceNode.UserRolePermissions = source.UserRolePermissions;
        this.m_sourceNode.NodeId = source.NodeId;
      }
      if (!QualifiedName.IsNull(source.BrowseName))
      {
        this.m_sourceName = new PropertyState<string>((NodeState) this);
        this.m_sourceName.Value = source.BrowseName.Name;
      }
    }
    this.m_time = new PropertyState<DateTime>((NodeState) this);
    this.m_time.Value = DateTime.UtcNow;
    this.m_receiveTime = new PropertyState<DateTime>((NodeState) this);
    this.m_receiveTime.Value = DateTime.UtcNow;
    this.m_severity = new PropertyState<ushort>((NodeState) this);
    this.m_severity.Value = (ushort) severity;
    this.m_message = new PropertyState<LocalizedText>((NodeState) this);
    this.m_message.Value = message;
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType()));
  }
}
