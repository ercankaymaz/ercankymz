// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditHistoryEventDeleteEventState
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
public class AuditHistoryEventDeleteEventState(NodeState parent) : AuditHistoryDeleteEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50RGVsZXRlRXZlbnRUeXBlSW5zdGFuY2UBAM4LAQDOC84LAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAJw4ALgBEJw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAKA4ALgBEKA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBACkOAC4ARCkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAqDgAuAEQqDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAKw4ALgBEKw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBACwOAC4ARCwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAC4OAC4ARC4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEALw4ALgBELw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAMA4ALgBEMA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAxDgAuAEQxDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBADIOAC4ARDIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBADMOAC4ARDMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBADQOAC4ARDQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQA1DgAuAEQ1DgAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBADYOAC4ARDYOAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAAgAAABFdmVudElkcwEAzwsALgBEzwsAAAAPAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDQCwAuAETQCwAAAQCYA/////8BAf////8AAAAA";
  private PropertyState<byte[][]> m_eventIds;
  private PropertyState<HistoryEventFieldList> m_oldValues;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 3022U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50RGVsZXRlRXZlbnRUeXBlSW5zdGFuY2UBAM4LAQDOC84LAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAJw4ALgBEJw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAKA4ALgBEKA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBACkOAC4ARCkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAqDgAuAEQqDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAKw4ALgBEKw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBACwOAC4ARCwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAC4OAC4ARC4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEALw4ALgBELw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAMA4ALgBEMA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQAxDgAuAEQxDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBADIOAC4ARDIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBADMOAC4ARDMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBADQOAC4ARDQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQA1DgAuAEQ1DgAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBADYOAC4ARDYOAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAAgAAABFdmVudElkcwEAzwsALgBEzwsAAAAPAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDQCwAuAETQCwAAAQCYA/////8BAf////8AAAAA");
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

  public PropertyState<byte[][]> EventIds
  {
    get => this.m_eventIds;
    set
    {
      if (this.m_eventIds != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_eventIds = value;
    }
  }

  public PropertyState<HistoryEventFieldList> OldValues
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
    if (this.m_eventIds != null)
      children.Add((BaseInstanceState) this.m_eventIds);
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
      case "EventIds":
        if (createOrReplace && this.EventIds == null)
          this.EventIds = replacement != null ? (PropertyState<byte[][]>) replacement : new PropertyState<byte[][]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EventIds;
        break;
      case "OldValues":
        if (createOrReplace && this.OldValues == null)
          this.OldValues = replacement != null ? (PropertyState<HistoryEventFieldList>) replacement : new PropertyState<HistoryEventFieldList>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OldValues;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
