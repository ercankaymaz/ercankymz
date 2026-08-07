// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditHistoryRawModifyDeleteEventState
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
public class AuditHistoryRawModifyDeleteEventState(NodeState parent) : AuditHistoryDeleteEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAEF1ZGl0SGlzdG9yeVJhd01vZGlmeURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDGCwEAxgvGCwAA/////xMAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAcOAC4ARAcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAgOAC4ARAgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAJDgAuAEQJDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEACg4ALgBECg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAsOAC4ARAsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAMDgAuAEQMDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAODgAuAEQODgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAA8OAC4ARA8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABABAOAC4ARBAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAEQ4ALgBEEQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQASDgAuAEQSDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQATDgAuAEQTDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAUDgAuAEQUDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAFQ4ALgBEFQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAWDgAuAEQWDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASXNEZWxldGVNb2RpZmllZAEAxwsALgBExwsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFN0YXJ0VGltZQEAyAsALgBEyAsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARW5kVGltZQEAyQsALgBEyQsAAAEAJgH/////AQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDaCwAuAETaCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA";
  private PropertyState<bool> m_isDeleteModified;
  private PropertyState<DateTime> m_startTime;
  private PropertyState<DateTime> m_endTime;
  private PropertyState<DataValue[]> m_oldValues;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 3014U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALAAAAEF1ZGl0SGlzdG9yeVJhd01vZGlmeURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDGCwEAxgvGCwAA/////xMAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAcOAC4ARAcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAgOAC4ARAgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAJDgAuAEQJDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEACg4ALgBECg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAsOAC4ARAsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAMDgAuAEQMDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAODgAuAEQODgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAA8OAC4ARA8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABABAOAC4ARBAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAEQ4ALgBEEQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQASDgAuAEQSDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQATDgAuAEQTDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAUDgAuAEQUDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAFQ4ALgBEFQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAWDgAuAEQWDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAASXNEZWxldGVNb2RpZmllZAEAxwsALgBExwsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFN0YXJ0VGltZQEAyAsALgBEyAsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAARW5kVGltZQEAyQsALgBEyQsAAAEAJgH/////AQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDaCwAuAETaCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA");
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

  public PropertyState<bool> IsDeleteModified
  {
    get => this.m_isDeleteModified;
    set
    {
      if (this.m_isDeleteModified != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_isDeleteModified = value;
    }
  }

  public PropertyState<DateTime> StartTime
  {
    get => this.m_startTime;
    set
    {
      if (this.m_startTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_startTime = value;
    }
  }

  public PropertyState<DateTime> EndTime
  {
    get => this.m_endTime;
    set
    {
      if (this.m_endTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_endTime = value;
    }
  }

  public PropertyState<DataValue[]> OldValues
  {
    get => this.m_oldValues;
    set
    {
      if (this.m_oldValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_oldValues = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_isDeleteModified != null)
      children.Add((BaseInstanceState) this.m_isDeleteModified);
    if (this.m_startTime != null)
      children.Add((BaseInstanceState) this.m_startTime);
    if (this.m_endTime != null)
      children.Add((BaseInstanceState) this.m_endTime);
    if (this.m_oldValues != null)
      children.Add((BaseInstanceState) this.m_oldValues);
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
      case "IsDeleteModified":
        if (createOrReplace && this.IsDeleteModified == null)
          this.IsDeleteModified = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.IsDeleteModified;
        break;
      case "StartTime":
        if (createOrReplace && this.StartTime == null)
          this.StartTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.StartTime;
        break;
      case "EndTime":
        if (createOrReplace && this.EndTime == null)
          this.EndTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EndTime;
        break;
      case "OldValues":
        if (createOrReplace && this.OldValues == null)
          this.OldValues = replacement != null ? (PropertyState<DataValue[]>) replacement : new PropertyState<DataValue[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OldValues;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
