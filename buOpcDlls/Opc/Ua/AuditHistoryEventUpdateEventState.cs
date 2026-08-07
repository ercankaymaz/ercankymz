// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditHistoryEventUpdateEventState
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
public class AuditHistoryEventUpdateEventState(NodeState parent) : AuditHistoryUpdateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50VXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBALcLAQC3C7cLAAD/////EwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA2g0ALgBE2g0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA2w0ALgBE2w0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBANwNAC4ARNwNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDdDQAuAETdDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA3g0ALgBE3g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAN8NAC4ARN8NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOENAC4AROENAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA4g0ALgBE4g0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA4w0ALgBE4w0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDkDQAuAETkDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAOUNAC4AROUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAOYNAC4AROYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAOcNAC4AROcNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQDoDQAuAEToDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANELAC4ARNELAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1AsALgBE1AsAAAEAHSz/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARmlsdGVyAQC7CwAuAES7CwAAAQDVAv////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABOZXdWYWx1ZXMBANULAC4ARNULAAABAJgDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDWCwAuAETWCwAAAQCYAwEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<NodeId> m_updatedNode;
  private PropertyState<PerformUpdateType> m_performInsertReplace;
  private PropertyState<EventFilter> m_filter;
  private PropertyState<HistoryEventFieldList[]> m_newValues;
  private PropertyState<HistoryEventFieldList[]> m_oldValues;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2999U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0SGlzdG9yeUV2ZW50VXBkYXRlRXZlbnRUeXBlSW5zdGFuY2UBALcLAQC3C7cLAAD/////EwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA2g0ALgBE2g0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA2w0ALgBE2w0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBANwNAC4ARNwNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDdDQAuAETdDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA3g0ALgBE3g0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAN8NAC4ARN8NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOENAC4AROENAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA4g0ALgBE4g0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA4w0ALgBE4w0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDkDQAuAETkDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAOUNAC4AROUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAOYNAC4AROYNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAOcNAC4AROcNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABQYXJhbWV0ZXJEYXRhVHlwZUlkAQDoDQAuAEToDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAVXBkYXRlZE5vZGUBANELAC4ARNELAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEA1AsALgBE1AsAAAEAHSz/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARmlsdGVyAQC7CwAuAES7CwAAAQDVAv////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABOZXdWYWx1ZXMBANULAC4ARNULAAABAJgDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAJAAAAT2xkVmFsdWVzAQDWCwAuAETWCwAAAQCYAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<EventFilter> Filter
  {
    get => this.m_filter;
    set
    {
      if (this.m_filter != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_filter = value;
    }
  }

  public PropertyState<HistoryEventFieldList[]> NewValues
  {
    get => this.m_newValues;
    set
    {
      if (this.m_newValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_newValues = value;
    }
  }

  public PropertyState<HistoryEventFieldList[]> OldValues
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
    if (this.m_filter != null)
      children.Add((BaseInstanceState) this.m_filter);
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
      case "Filter":
        if (createOrReplace && this.Filter == null)
          this.Filter = replacement != null ? (PropertyState<EventFilter>) replacement : new PropertyState<EventFilter>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Filter;
        break;
      case "NewValues":
        if (createOrReplace && this.NewValues == null)
          this.NewValues = replacement != null ? (PropertyState<HistoryEventFieldList[]>) replacement : new PropertyState<HistoryEventFieldList[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.NewValues;
        break;
      case "OldValues":
        if (createOrReplace && this.OldValues == null)
          this.OldValues = replacement != null ? (PropertyState<HistoryEventFieldList[]>) replacement : new PropertyState<HistoryEventFieldList[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OldValues;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
