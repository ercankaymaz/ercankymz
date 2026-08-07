// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubGroupState
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
public class PubSubGroupState(NodeState parent) : BaseObjectState(parent)
{
  private const string SecurityGroupId_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEANz4ALgBENz4AAAAM/////wEB/////wAAAAA=";
  private const string SecurityKeyServices_InitializationString = "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBADg+AC4ARDg+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAFwAAAFB1YlN1Ykdyb3VwVHlwZUluc3RhbmNlAQCYNwEAmDeYNwAA/////wYAAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEANj4ALgBENj4AAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQA3PgAuAEQ3PgAAAAz/////AQH/////AAAAABdgiQoCAAAAAAATAAAAU2VjdXJpdHlLZXlTZXJ2aWNlcwEAOD4ALgBEOD4AAAEAOAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABUAAABNYXhOZXR3b3JrTWVzc2FnZVNpemUBADxFAC4ARDxFAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAAA8AAABHcm91cFByb3BlcnRpZXMBAFBEAC4ARFBEAAABAMU4AQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQChOwAvAQAzOaE7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAKI7AC8AP6I7AAABADc5/////wEB/////wAAAAA=";
  private PropertyState<MessageSecurityMode> m_securityMode;
  private PropertyState<string> m_securityGroupId;
  private PropertyState<EndpointDescription[]> m_securityKeyServices;
  private PropertyState<uint> m_maxNetworkMessageSize;
  private PropertyState<KeyValuePair[]> m_groupProperties;
  private PubSubStatusState m_status;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 14232U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFwAAAFB1YlN1Ykdyb3VwVHlwZUluc3RhbmNlAQCYNwEAmDeYNwAA/////wYAAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEANj4ALgBENj4AAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQA3PgAuAEQ3PgAAAAz/////AQH/////AAAAABdgiQoCAAAAAAATAAAAU2VjdXJpdHlLZXlTZXJ2aWNlcwEAOD4ALgBEOD4AAAEAOAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABUAAABNYXhOZXR3b3JrTWVzc2FnZVNpemUBADxFAC4ARDxFAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAAA8AAABHcm91cFByb3BlcnRpZXMBAFBEAC4ARFBEAAABAMU4AQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQChOwAvAQAzOaE7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAKI7AC8AP6I7AAABADc5/////wEB/////wAAAAA=");
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
    if (this.SecurityGroupId != null)
      this.SecurityGroupId.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEANz4ALgBENz4AAAAM/////wEB/////wAAAAA=");
    if (this.SecurityKeyServices == null)
      return;
    this.SecurityKeyServices.Initialize(context, "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBADg+AC4ARDg+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
  }

  public PropertyState<MessageSecurityMode> SecurityMode
  {
    get => this.m_securityMode;
    set
    {
      if (this.m_securityMode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityMode = value;
    }
  }

  public PropertyState<string> SecurityGroupId
  {
    get => this.m_securityGroupId;
    set
    {
      if (this.m_securityGroupId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityGroupId = value;
    }
  }

  public PropertyState<EndpointDescription[]> SecurityKeyServices
  {
    get => this.m_securityKeyServices;
    set
    {
      if (this.m_securityKeyServices != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityKeyServices = value;
    }
  }

  public PropertyState<uint> MaxNetworkMessageSize
  {
    get => this.m_maxNetworkMessageSize;
    set
    {
      if (this.m_maxNetworkMessageSize != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNetworkMessageSize = value;
    }
  }

  public PropertyState<KeyValuePair[]> GroupProperties
  {
    get => this.m_groupProperties;
    set
    {
      if (this.m_groupProperties != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_groupProperties = value;
    }
  }

  public PubSubStatusState Status
  {
    get => this.m_status;
    set
    {
      if (this.m_status != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_status = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_securityMode != null)
      children.Add((BaseInstanceState) this.m_securityMode);
    if (this.m_securityGroupId != null)
      children.Add((BaseInstanceState) this.m_securityGroupId);
    if (this.m_securityKeyServices != null)
      children.Add((BaseInstanceState) this.m_securityKeyServices);
    if (this.m_maxNetworkMessageSize != null)
      children.Add((BaseInstanceState) this.m_maxNetworkMessageSize);
    if (this.m_groupProperties != null)
      children.Add((BaseInstanceState) this.m_groupProperties);
    if (this.m_status != null)
      children.Add((BaseInstanceState) this.m_status);
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
      case "SecurityMode":
        if (createOrReplace && this.SecurityMode == null)
          this.SecurityMode = replacement != null ? (PropertyState<MessageSecurityMode>) replacement : new PropertyState<MessageSecurityMode>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecurityMode;
        break;
      case "SecurityGroupId":
        if (createOrReplace && this.SecurityGroupId == null)
          this.SecurityGroupId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecurityGroupId;
        break;
      case "SecurityKeyServices":
        if (createOrReplace && this.SecurityKeyServices == null)
          this.SecurityKeyServices = replacement != null ? (PropertyState<EndpointDescription[]>) replacement : new PropertyState<EndpointDescription[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecurityKeyServices;
        break;
      case "MaxNetworkMessageSize":
        if (createOrReplace && this.MaxNetworkMessageSize == null)
          this.MaxNetworkMessageSize = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MaxNetworkMessageSize;
        break;
      case "GroupProperties":
        if (createOrReplace && this.GroupProperties == null)
          this.GroupProperties = replacement != null ? (PropertyState<KeyValuePair[]>) replacement : new PropertyState<KeyValuePair[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.GroupProperties;
        break;
      case "Status":
        if (createOrReplace && this.Status == null)
          this.Status = replacement != null ? (PubSubStatusState) replacement : new PubSubStatusState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Status;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
