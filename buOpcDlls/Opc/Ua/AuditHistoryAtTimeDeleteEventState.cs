// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditHistoryAtTimeDeleteEventState
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
public class AuditHistoryAtTimeDeleteEventState(NodeState parent) : AuditHistoryDeleteEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKQAAAEF1ZGl0SGlzdG9yeUF0VGltZURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDLCwEAywvLCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBABcOAC4ARBcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBABgOAC4ARBgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAZDgAuAEQZDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAGg4ALgBEGg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBABsOAC4ARBsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAcDgAuAEQcDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAeDgAuAEQeDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAB8OAC4ARB8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABACAOAC4ARCAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAIQ4ALgBEIQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQAiDgAuAEQiDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAjDgAuAEQjDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAkDgAuAEQkDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAJQ4ALgBEJQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAmDgAuAEQmDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAIAAAAUmVxVGltZXMBAMwLAC4ARMwLAAABACYBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDNCwAuAETNCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA";
  private PropertyState<DateTime[]> m_reqTimes;
  private PropertyState<DataValue[]> m_oldValues;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 3019U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKQAAAEF1ZGl0SGlzdG9yeUF0VGltZURlbGV0ZUV2ZW50VHlwZUluc3RhbmNlAQDLCwEAywvLCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBABcOAC4ARBcOAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBABgOAC4ARBgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAZDgAuAEQZDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAGg4ALgBEGg4AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBABsOAC4ARBsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAcDgAuAEQcDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAeDgAuAEQeDgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAB8OAC4ARB8OAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABACAOAC4ARCAOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAIQ4ALgBEIQ4AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQAiDgAuAEQiDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAjDgAuAEQjDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAkDgAuAEQkDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAJQ4ALgBEJQ4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFVwZGF0ZWROb2RlAQAmDgAuAEQmDgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAIAAAAUmVxVGltZXMBAMwLAC4ARMwLAAABACYBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDNCwAuAETNCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAA");
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

  public PropertyState<DateTime[]> ReqTimes
  {
    get => this.m_reqTimes;
    set
    {
      if (this.m_reqTimes != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_reqTimes = value;
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
    if (this.m_reqTimes != null)
      children.Add((BaseInstanceState) this.m_reqTimes);
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
      case "ReqTimes":
        if (createOrReplace && this.ReqTimes == null)
          this.ReqTimes = replacement != null ? (PropertyState<DateTime[]>) replacement : new PropertyState<DateTime[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ReqTimes;
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
