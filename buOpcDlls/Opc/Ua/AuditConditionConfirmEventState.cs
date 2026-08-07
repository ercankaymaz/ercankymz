// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditConditionConfirmEventState
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
public class AuditConditionConfirmEventState(NodeState parent) : AuditConditionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29uZmlybUV2ZW50VHlwZUluc3RhbmNlAQABIwEAASMBIwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAIjAC4ARAIjAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAMjAC4ARAMjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAEIwAuAEQEIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEABSMALgBEBSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAYjAC4ARAYjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAHIwAuAEQHIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAJIwAuAEQJIwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAojAC4ARAojAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAAsjAC4ARAsjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEADCMALgBEDCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQANIwAuAEQNIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAOIwAuAEQOIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAPIwAuAEQPIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBABAjAC4ARBAjAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAESMALgBEESMAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEASEMALgBESEMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAE4uAC4ARE4uAAAAFf////8BAf////8AAAAA";
  private PropertyState<byte[]> m_conditionEventId;
  private PropertyState<LocalizedText> m_comment;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 8961U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29uZmlybUV2ZW50VHlwZUluc3RhbmNlAQABIwEAASMBIwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAAIjAC4ARAIjAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAAMjAC4ARAMjAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQAEIwAuAEQEIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEABSMALgBEBSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAAYjAC4ARAYjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQAHIwAuAEQHIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQAJIwAuAEQJIwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAAojAC4ARAojAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAAsjAC4ARAsjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEADCMALgBEDCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQANIwAuAEQNIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQAOIwAuAEQOIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQAPIwAuAEQPIwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBABAjAC4ARBAjAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAESMALgBEESMAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEASEMALgBESEMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAE4uAC4ARE4uAAAAFf////8BAf////8AAAAA");
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
