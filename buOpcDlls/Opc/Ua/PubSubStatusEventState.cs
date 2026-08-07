// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubStatusEventState
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
public class PubSubStatusEventState(NodeState parent) : SystemEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YlN0YXR1c0V2ZW50VHlwZUluc3RhbmNlAQCvPAEArzyvPAAA/////wsAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALA8AC4ARLA8AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALE8AC4ARLE8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCyPAAuAESyPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAszwALgBEszwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALQ8AC4ARLQ8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC1PAAuAES1PAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC3PAAuAES3PAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALg8AC4ARLg8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBALk8AC4ARLk8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQC6PAAuAES6PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBALs8AC4ARLs8AAABADc5/////wEB/////wAAAAA=";
  private PropertyState<NodeId> m_connectionId;
  private PropertyState<NodeId> m_groupId;
  private PropertyState<PubSubState> m_state;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15535U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAFB1YlN1YlN0YXR1c0V2ZW50VHlwZUluc3RhbmNlAQCvPAEArzyvPAAA/////wsAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALA8AC4ARLA8AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALE8AC4ARLE8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCyPAAuAESyPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAszwALgBEszwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALQ8AC4ARLQ8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC1PAAuAES1PAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC3PAAuAES3PAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALg8AC4ARLg8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBALk8AC4ARLk8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQC6PAAuAES6PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBALs8AC4ARLs8AAABADc5/////wEB/////wAAAAA=");
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

  public PropertyState<NodeId> ConnectionId
  {
    get => this.m_connectionId;
    set
    {
      if (this.m_connectionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_connectionId = value;
    }
  }

  public PropertyState<NodeId> GroupId
  {
    get => this.m_groupId;
    set
    {
      if (this.m_groupId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_groupId = value;
    }
  }

  public PropertyState<PubSubState> State
  {
    get => this.m_state;
    set
    {
      if (this.m_state != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_state = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_connectionId != null)
      children.Add((BaseInstanceState) this.m_connectionId);
    if (this.m_groupId != null)
      children.Add((BaseInstanceState) this.m_groupId);
    if (this.m_state != null)
      children.Add((BaseInstanceState) this.m_state);
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
      case "ConnectionId":
        if (createOrReplace && this.ConnectionId == null)
          this.ConnectionId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ConnectionId;
        break;
      case "GroupId":
        if (createOrReplace && this.GroupId == null)
          this.GroupId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.GroupId;
        break;
      case "State":
        if (createOrReplace && this.State == null)
          this.State = replacement != null ? (PropertyState<PubSubState>) replacement : new PropertyState<PubSubState>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.State;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
