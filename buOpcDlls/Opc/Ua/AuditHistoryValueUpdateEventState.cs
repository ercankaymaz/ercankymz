// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditHistoryValueUpdateEventState
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
public class AuditHistoryValueUpdateEventState(NodeState parent) : AuditHistoryUpdateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeVZhbHVlVXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBAL4LAQC+C74LAAD/////EgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA6Q0ALgBE6Q0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA6g0ALgBE6g0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOsNAC4AROsNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDsDQAuAETsDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA7Q0ALgBE7Q0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAO4NAC4ARO4NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPANAC4ARPANAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA8Q0ALgBE8Q0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA8g0ALgBE8g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDzDQAuAETzDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAPQNAC4ARPQNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPUNAC4ARPUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPYNAC4ARPYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQD3DQAuAET3DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANILAC4ARNILAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1wsALgBE1wsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQDYCwAuAETYCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBANkLAC4ARNkLAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<NodeId> m_updatedNode;
  private PropertyState<PerformUpdateType> m_performInsertReplace;
  private PropertyState<DataValue[]> m_newValues;
  private PropertyState<DataValue[]> m_oldValues;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 3006U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeVZhbHVlVXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBAL4LAQC+C74LAAD/////EgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA6Q0ALgBE6Q0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA6g0ALgBE6g0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOsNAC4AROsNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDsDQAuAETsDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA7Q0ALgBE7Q0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAO4NAC4ARO4NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPANAC4ARPANAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA8Q0ALgBE8Q0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA8g0ALgBE8g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDzDQAuAETzDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAPQNAC4ARPQNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPUNAC4ARPUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPYNAC4ARPYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQD3DQAuAET3DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANILAC4ARNILAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1wsALgBE1wsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQDYCwAuAETYCwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBANkLAC4ARNkLAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<NodeId> UpdatedNode
  {
    get => this.m_updatedNode;
    set
    {
      if (this.m_updatedNode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_updatedNode = value;
    }
  }

  public PropertyState<PerformUpdateType> PerformInsertReplace
  {
    get => this.m_performInsertReplace;
    set
    {
      if (this.m_performInsertReplace != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_performInsertReplace = value;
    }
  }

  public PropertyState<DataValue[]> NewValues
  {
    get => this.m_newValues;
    set
    {
      if (this.m_newValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_newValues = value;
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
    if (this.m_updatedNode != null)
      children.Add((BaseInstanceState) this.m_updatedNode);
    if (this.m_performInsertReplace != null)
      children.Add((BaseInstanceState) this.m_performInsertReplace);
    if (this.m_newValues != null)
      children.Add((BaseInstanceState) this.m_newValues);
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
      case "UpdatedNode":
        if (createOrReplace && this.UpdatedNode == null)
          this.UpdatedNode = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.UpdatedNode;
        break;
      case "PerformInsertReplace":
        if (createOrReplace && this.PerformInsertReplace == null)
          this.PerformInsertReplace = replacement != null ? (PropertyState<PerformUpdateType>) replacement : new PropertyState<PerformUpdateType>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PerformInsertReplace;
        break;
      case "NewValues":
        if (createOrReplace && this.NewValues == null)
          this.NewValues = replacement != null ? (PropertyState<DataValue[]>) replacement : new PropertyState<DataValue[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.NewValues;
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
