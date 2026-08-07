// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditConditionAcknowledgeEventState
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
public class AuditConditionAcknowledgeEventState(NodeState parent) : AuditConditionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKgAAAEF1ZGl0Q29uZGl0aW9uQWNrbm93bGVkZ2VFdmVudFR5cGVJbnN0YW5jZQEA8CIBAPAi8CIAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDxIgAuAETxIgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDyIgAuAETyIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA8yIALgBE8yIAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAPQiAC4ARPQiAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD1IgAuAET1IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA9iIALgBE9iIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA+CIALgBE+CIAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQD5IgAuAET5IgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQD6IgAuAET6IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAPsiAC4ARPsiAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA/CIALgBE/CIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA/SIALgBE/SIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA/iIALgBE/iIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQD/IgAuAET/IgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAAjAC4ARAAjAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkV2ZW50SWQBAEdDAC4AREdDAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQBNLgAuAERNLgAAABX/////AQH/////AAAAAA==";
  private PropertyState<byte[]> m_conditionEventId;
  private PropertyState<LocalizedText> m_comment;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 8944U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKgAAAEF1ZGl0Q29uZGl0aW9uQWNrbm93bGVkZ2VFdmVudFR5cGVJbnN0YW5jZQEA8CIBAPAi8CIAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDxIgAuAETxIgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDyIgAuAETyIgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA8yIALgBE8yIAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAPQiAC4ARPQiAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQD1IgAuAET1IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA9iIALgBE9iIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA+CIALgBE+CIAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQD5IgAuAET5IgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQD6IgAuAET6IgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAPsiAC4ARPsiAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA/CIALgBE/CIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA/SIALgBE/SIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA/iIALgBE/iIAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQD/IgAuAET/IgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAAjAC4ARAAjAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkV2ZW50SWQBAEdDAC4AREdDAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABDb21tZW50AQBNLgAuAERNLgAAABX/////AQH/////AAAAAA==");
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

  public PropertyState<byte[]> ConditionEventId
  {
    get => this.m_conditionEventId;
    set
    {
      if (this.m_conditionEventId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_conditionEventId = value;
    }
  }

  public PropertyState<LocalizedText> Comment
  {
    get => this.m_comment;
    set
    {
      if (this.m_comment != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_comment = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_conditionEventId != null)
      children.Add((BaseInstanceState) this.m_conditionEventId);
    if (this.m_comment != null)
      children.Add((BaseInstanceState) this.m_comment);
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
      case "ConditionEventId":
        if (createOrReplace && this.ConditionEventId == null)
          this.ConditionEventId = replacement != null ? (PropertyState<byte[]>) replacement : new PropertyState<byte[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ConditionEventId;
        break;
      case "Comment":
        if (createOrReplace && this.Comment == null)
          this.Comment = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Comment;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
