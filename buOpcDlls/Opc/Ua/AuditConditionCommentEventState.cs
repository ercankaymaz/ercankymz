// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditConditionCommentEventState
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
public class AuditConditionCommentEventState(NodeState parent) : AuditConditionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29tbWVudEV2ZW50VHlwZUluc3RhbmNlAQANCwEADQsNCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAEoQAC4AREoQAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAEsQAC4AREsQAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBMEAAuAERMEAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEATRAALgBETRAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAE4QAC4ARE4QAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBPEAAuAERPEAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBREAAuAERREAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAFIQAC4ARFIQAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAFMQAC4ARFMQAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAVBAALgBEVBAAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBVEAAuAERVEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBWEAAuAERWEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBXEAAuAERXEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAFgQAC4ARFgQAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWRAALgBEWRAAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEARkMALgBERkMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAEsuAC4AREsuAAAAFf////8BAf////8AAAAA";
  private PropertyState<byte[]> m_conditionEventId;
  private PropertyState<LocalizedText> m_comment;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2829U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEF1ZGl0Q29uZGl0aW9uQ29tbWVudEV2ZW50VHlwZUluc3RhbmNlAQANCwEADQsNCwAA/////xEAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAEoQAC4AREoQAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAEsQAC4AREsQAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBMEAAuAERMEAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEATRAALgBETRAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAE4QAC4ARE4QAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBPEAAuAERPEAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBREAAuAERREAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAFIQAC4ARFIQAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAFMQAC4ARFMQAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAVBAALgBEVBAAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBVEAAuAERVEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBWEAAuAERWEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBXEAAuAERXEAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAFgQAC4ARFgQAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAWRAALgBEWRAAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uRXZlbnRJZAEARkMALgBERkMAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAEsuAC4AREsuAAAAFf////8BAf////8AAAAA");
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
