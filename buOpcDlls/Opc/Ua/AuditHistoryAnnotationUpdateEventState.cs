// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditHistoryAnnotationUpdateEventState
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
public class AuditHistoryAnnotationUpdateEventState(NodeState parent) : AuditHistoryUpdateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAALQAAAEF1ZGl0SGlzdG9yeUFubm90YXRpb25VcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEAl0oBAJdKl0oAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCYSgAuAESYSgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCZSgAuAESZSgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmkoALgBEmkoAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJtKAC4ARJtKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCcSgAuAEScSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAnUoALgBEnUoAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAn0oALgBEn0oAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCgSgAuAESgSgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQChSgAuAEShSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAKJKAC4ARKJKAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAWUsALgBEWUsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAWksALgBEWksAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAW0sALgBEW0sAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFBhcmFtZXRlckRhdGFUeXBlSWQBAFxLAC4ARFxLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEAXUsALgBEXUsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQBeSwAuAEReSwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBAF9LAC4ARF9LAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<PerformUpdateType> m_performInsertReplace;
  private PropertyState<DataValue[]> m_newValues;
  private PropertyState<DataValue[]> m_oldValues;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 19095U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALQAAAEF1ZGl0SGlzdG9yeUFubm90YXRpb25VcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEAl0oBAJdKl0oAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCYSgAuAESYSgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCZSgAuAESZSgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmkoALgBEmkoAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJtKAC4ARJtKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCcSgAuAEScSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAnUoALgBEnUoAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAn0oALgBEn0oAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCgSgAuAESgSgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQChSgAuAEShSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAKJKAC4ARKJKAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAWUsALgBEWUsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAWksALgBEWksAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAW0sALgBEW0sAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFBhcmFtZXRlckRhdGFUeXBlSWQBAFxLAC4ARFxLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEAXUsALgBEXUsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQBeSwAuAEReSwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBAF9LAC4ARF9LAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
