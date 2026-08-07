// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionSecurityDiagnosticsState
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
public class SessionSecurityDiagnosticsState(NodeState parent) : 
  BaseDataVariableState<SessionSecurityDiagnosticsDataType>(parent)
{
  private const string InitializationString = "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDECAEAxAjECAAAAQBkA/////8BAf////8JAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAMUIAC8AP8UIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRVc2VySWRPZlNlc3Npb24BAMYIAC8AP8YIAAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABDbGllbnRVc2VySWRIaXN0b3J5AQDHCAAvAD/HCAAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABcAAABBdXRoZW50aWNhdGlvbk1lY2hhbmlzbQEAyAgALwA/yAgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEVuY29kaW5nAQDJCAAvAD/JCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVHJhbnNwb3J0UHJvdG9jb2wBAMoIAC8AP8oIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABTZWN1cml0eU1vZGUBAMsIAC8AP8sIAAABAC4B/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDMCAAvAD/MCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBAPILAC8AP/ILAAAAD/////8BAf////8AAAAA";
  private BaseDataVariableState<NodeId> m_sessionId;
  private BaseDataVariableState<string> m_clientUserIdOfSession;
  private BaseDataVariableState<string[]> m_clientUserIdHistory;
  private BaseDataVariableState<string> m_authenticationMechanism;
  private BaseDataVariableState<string> m_encoding;
  private BaseDataVariableState<string> m_transportProtocol;
  private BaseDataVariableState<MessageSecurityMode> m_securityMode;
  private BaseDataVariableState<string> m_securityPolicyUri;
  private BaseDataVariableState<byte[]> m_clientCertificate;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2244U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 868U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAJgAAAFNlc3Npb25TZWN1cml0eURpYWdub3N0aWNzVHlwZUluc3RhbmNlAQDECAEAxAjECAAAAQBkA/////8BAf////8JAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAMUIAC8AP8UIAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABDbGllbnRVc2VySWRPZlNlc3Npb24BAMYIAC8AP8YIAAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABDbGllbnRVc2VySWRIaXN0b3J5AQDHCAAvAD/HCAAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABcAAABBdXRoZW50aWNhdGlvbk1lY2hhbmlzbQEAyAgALwA/yAgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEVuY29kaW5nAQDJCAAvAD/JCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAVHJhbnNwb3J0UHJvdG9jb2wBAMoIAC8AP8oIAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABTZWN1cml0eU1vZGUBAMsIAC8AP8sIAAABAC4B/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDMCAAvAD/MCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBAPILAC8AP/ILAAAAD/////8BAf////8AAAAA");
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

  public BaseDataVariableState<NodeId> SessionId
  {
    get => this.m_sessionId;
    set
    {
      if (this.m_sessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionId = value;
    }
  }

  public BaseDataVariableState<string> ClientUserIdOfSession
  {
    get => this.m_clientUserIdOfSession;
    set
    {
      if (this.m_clientUserIdOfSession != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientUserIdOfSession = value;
    }
  }

  public BaseDataVariableState<string[]> ClientUserIdHistory
  {
    get => this.m_clientUserIdHistory;
    set
    {
      if (this.m_clientUserIdHistory != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientUserIdHistory = value;
    }
  }

  public BaseDataVariableState<string> AuthenticationMechanism
  {
    get => this.m_authenticationMechanism;
    set
    {
      if (this.m_authenticationMechanism != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_authenticationMechanism = value;
    }
  }

  public BaseDataVariableState<string> Encoding
  {
    get => this.m_encoding;
    set
    {
      if (this.m_encoding != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_encoding = value;
    }
  }

  public BaseDataVariableState<string> TransportProtocol
  {
    get => this.m_transportProtocol;
    set
    {
      if (this.m_transportProtocol != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transportProtocol = value;
    }
  }

  public BaseDataVariableState<MessageSecurityMode> SecurityMode
  {
    get => this.m_securityMode;
    set
    {
      if (this.m_securityMode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityMode = value;
    }
  }

  public BaseDataVariableState<string> SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set
    {
      if (this.m_securityPolicyUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityPolicyUri = value;
    }
  }

  public BaseDataVariableState<byte[]> ClientCertificate
  {
    get => this.m_clientCertificate;
    set
    {
      if (this.m_clientCertificate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientCertificate = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_sessionId != null)
      children.Add((BaseInstanceState) this.m_sessionId);
    if (this.m_clientUserIdOfSession != null)
      children.Add((BaseInstanceState) this.m_clientUserIdOfSession);
    if (this.m_clientUserIdHistory != null)
      children.Add((BaseInstanceState) this.m_clientUserIdHistory);
    if (this.m_authenticationMechanism != null)
      children.Add((BaseInstanceState) this.m_authenticationMechanism);
    if (this.m_encoding != null)
      children.Add((BaseInstanceState) this.m_encoding);
    if (this.m_transportProtocol != null)
      children.Add((BaseInstanceState) this.m_transportProtocol);
    if (this.m_securityMode != null)
      children.Add((BaseInstanceState) this.m_securityMode);
    if (this.m_securityPolicyUri != null)
      children.Add((BaseInstanceState) this.m_securityPolicyUri);
    if (this.m_clientCertificate != null)
      children.Add((BaseInstanceState) this.m_clientCertificate);
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
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 8:
          if (name == "Encoding")
          {
            if (createOrReplace && this.Encoding == null)
              this.Encoding = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Encoding;
            break;
          }
          break;
        case 9:
          if (name == "SessionId")
          {
            if (createOrReplace && this.SessionId == null)
              this.SessionId = replacement != null ? (BaseDataVariableState<NodeId>) replacement : new BaseDataVariableState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SessionId;
            break;
          }
          break;
        case 12:
          if (name == "SecurityMode")
          {
            if (createOrReplace && this.SecurityMode == null)
              this.SecurityMode = replacement != null ? (BaseDataVariableState<MessageSecurityMode>) replacement : new BaseDataVariableState<MessageSecurityMode>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SecurityMode;
            break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'C':
              if (name == "ClientCertificate")
              {
                if (createOrReplace && this.ClientCertificate == null)
                  this.ClientCertificate = replacement != null ? (BaseDataVariableState<byte[]>) replacement : new BaseDataVariableState<byte[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ClientCertificate;
                break;
              }
              break;
            case 'S':
              if (name == "SecurityPolicyUri")
              {
                if (createOrReplace && this.SecurityPolicyUri == null)
                  this.SecurityPolicyUri = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SecurityPolicyUri;
                break;
              }
              break;
            case 'T':
              if (name == "TransportProtocol")
              {
                if (createOrReplace && this.TransportProtocol == null)
                  this.TransportProtocol = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TransportProtocol;
                break;
              }
              break;
          }
          break;
        case 19:
          if (name == "ClientUserIdHistory")
          {
            if (createOrReplace && this.ClientUserIdHistory == null)
              this.ClientUserIdHistory = replacement != null ? (BaseDataVariableState<string[]>) replacement : new BaseDataVariableState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ClientUserIdHistory;
            break;
          }
          break;
        case 21:
          if (name == "ClientUserIdOfSession")
          {
            if (createOrReplace && this.ClientUserIdOfSession == null)
              this.ClientUserIdOfSession = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ClientUserIdOfSession;
            break;
          }
          break;
        case 23:
          if (name == "AuthenticationMechanism")
          {
            if (createOrReplace && this.AuthenticationMechanism == null)
              this.AuthenticationMechanism = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AuthenticationMechanism;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
