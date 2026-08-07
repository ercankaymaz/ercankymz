// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditWriteUpdateEventState
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
public class AuditWriteUpdateEventState(NodeState parent) : AuditUpdateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0V3JpdGVVcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEANAgBADQINAgAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQC+DQAuAES+DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQC/DQAuAES/DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAwA0ALgBEwA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAMENAC4ARMENAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDCDQAuAETCDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAww0ALgBEww0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAxQ0ALgBExQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDGDQAuAETGDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDHDQAuAETHDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAMgNAC4ARMgNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAyQ0ALgBEyQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAyg0ALgBEyg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAyw0ALgBEyw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEF0dHJpYnV0ZUlkAQC+CgAuAES+CgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW5kZXhSYW5nZQEANQgALgBENQgAAAEAIwH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAT2xkVmFsdWUBADYIAC4ARDYIAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABOZXdWYWx1ZQEANwgALgBENwgAAAAY/////wEB/////wAAAAA=";
  private PropertyState<uint> m_attributeId;
  private PropertyState<string> m_indexRange;
  private PropertyState m_oldValue;
  private PropertyState m_newValue;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2100U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0V3JpdGVVcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEANAgBADQINAgAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQC+DQAuAES+DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQC/DQAuAES/DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAwA0ALgBEwA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAMENAC4ARMENAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDCDQAuAETCDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAww0ALgBEww0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAxQ0ALgBExQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDGDQAuAETGDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDHDQAuAETHDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAMgNAC4ARMgNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAyQ0ALgBEyQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAyg0ALgBEyg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAyw0ALgBEyw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEF0dHJpYnV0ZUlkAQC+CgAuAES+CgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW5kZXhSYW5nZQEANQgALgBENQgAAAEAIwH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAT2xkVmFsdWUBADYIAC4ARDYIAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABOZXdWYWx1ZQEANwgALgBENwgAAAAY/////wEB/////wAAAAA=");
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

  public PropertyState<uint> AttributeId
  {
    get => this.m_attributeId;
    set
    {
      if (this.m_attributeId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_attributeId = value;
    }
  }

  public PropertyState<string> IndexRange
  {
    get => this.m_indexRange;
    set
    {
      if (this.m_indexRange != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_indexRange = value;
    }
  }

  public PropertyState OldValue
  {
    get => this.m_oldValue;
    set
    {
      if (this.m_oldValue != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_oldValue = value;
    }
  }

  public PropertyState NewValue
  {
    get => this.m_newValue;
    set
    {
      if (this.m_newValue != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_newValue = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_attributeId != null)
      children.Add((BaseInstanceState) this.m_attributeId);
    if (this.m_indexRange != null)
      children.Add((BaseInstanceState) this.m_indexRange);
    if (this.m_oldValue != null)
      children.Add((BaseInstanceState) this.m_oldValue);
    if (this.m_newValue != null)
      children.Add((BaseInstanceState) this.m_newValue);
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
      case "AttributeId":
        if (createOrReplace && this.AttributeId == null)
          this.AttributeId = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AttributeId;
        break;
      case "IndexRange":
        if (createOrReplace && this.IndexRange == null)
          this.IndexRange = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.IndexRange;
        break;
      case "OldValue":
        if (createOrReplace && this.OldValue == null)
          this.OldValue = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OldValue;
        break;
      case "NewValue":
        if (createOrReplace && this.NewValue == null)
          this.NewValue = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.NewValue;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
