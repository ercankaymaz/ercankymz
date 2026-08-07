// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditOpenSecureChannelEventState
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
public class AuditOpenSecureChannelEventState(NodeState parent) : AuditChannelEventState(parent)
{
  private const string CertificateErrorEventId_InitializationString = "//////////8VYIkKAgAAAAAAFwAAAENlcnRpZmljYXRlRXJyb3JFdmVudElkAQBHXgAuAERHXgAAAAz/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0T3BlblNlY3VyZUNoYW5uZWxFdmVudFR5cGVJbnN0YW5jZQEADAgBAAwIDAgAAP////8VAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQClDAAuAESlDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCmDAAuAESmDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEApwwALgBEpwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAKgMAC4ARKgMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCpDAAuAESpDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAqgwALgBEqgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEArAwALgBErAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCtDAAuAEStDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCuDAAuAESuDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAK8MAC4ARK8MAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAsAwALgBEsAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAsQwALgBEsQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAsgwALgBEsgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEAswwALgBEswwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQANCAAuAEQNCAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQC6CgAuAES6CgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVxdWVzdFR5cGUBAA4IAC4ARA4IAAABADsB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQAPCAAuAEQPCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQARCAAuAEQRCAAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABSZXF1ZXN0ZWRMaWZldGltZQEAEggALgBEEggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ2VydGlmaWNhdGVFcnJvckV2ZW50SWQBAEdeAC4AREdeAAAADP////8BAf////8AAAAA";
  private PropertyState<byte[]> m_clientCertificate;
  private PropertyState<string> m_clientCertificateThumbprint;
  private PropertyState<SecurityTokenRequestType> m_requestType;
  private PropertyState<string> m_securityPolicyUri;
  private PropertyState<MessageSecurityMode> m_securityMode;
  private PropertyState<double> m_requestedLifetime;
  private PropertyState<string> m_certificateErrorEventId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2060U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0T3BlblNlY3VyZUNoYW5uZWxFdmVudFR5cGVJbnN0YW5jZQEADAgBAAwIDAgAAP////8VAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQClDAAuAESlDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCmDAAuAESmDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEApwwALgBEpwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAKgMAC4ARKgMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCpDAAuAESpDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAqgwALgBEqgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEArAwALgBErAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCtDAAuAEStDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCuDAAuAESuDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAK8MAC4ARK8MAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAsAwALgBEsAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAsQwALgBEsQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAsgwALgBEsgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEAswwALgBEswwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQANCAAuAEQNCAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQC6CgAuAES6CgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVxdWVzdFR5cGUBAA4IAC4ARA4IAAABADsB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQAPCAAuAEQPCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQARCAAuAEQRCAAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABSZXF1ZXN0ZWRMaWZldGltZQEAEggALgBEEggAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAXAAAAQ2VydGlmaWNhdGVFcnJvckV2ZW50SWQBAEdeAC4AREdeAAAADP////8BAf////8AAAAA");
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
    if (this.CertificateErrorEventId == null)
      return;
    this.CertificateErrorEventId.Initialize(context, "//////////8VYIkKAgAAAAAAFwAAAENlcnRpZmljYXRlRXJyb3JFdmVudElkAQBHXgAuAERHXgAAAAz/////AQH/////AAAAAA==");
  }

  public PropertyState<byte[]> ClientCertificate
  {
    get => this.m_clientCertificate;
    set
    {
      if (this.m_clientCertificate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientCertificate = value;
    }
  }

  public PropertyState<string> ClientCertificateThumbprint
  {
    get => this.m_clientCertificateThumbprint;
    set
    {
      if (this.m_clientCertificateThumbprint != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientCertificateThumbprint = value;
    }
  }

  public PropertyState<SecurityTokenRequestType> RequestType
  {
    get => this.m_requestType;
    set
    {
      if (this.m_requestType != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_requestType = value;
    }
  }

  public PropertyState<string> SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set
    {
      if (this.m_securityPolicyUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityPolicyUri = value;
    }
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

  public PropertyState<double> RequestedLifetime
  {
    get => this.m_requestedLifetime;
    set
    {
      if (this.m_requestedLifetime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_requestedLifetime = value;
    }
  }

  public PropertyState<string> CertificateErrorEventId
  {
    get => this.m_certificateErrorEventId;
    set
    {
      if (this.m_certificateErrorEventId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_certificateErrorEventId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_clientCertificate != null)
      children.Add((BaseInstanceState) this.m_clientCertificate);
    if (this.m_clientCertificateThumbprint != null)
      children.Add((BaseInstanceState) this.m_clientCertificateThumbprint);
    if (this.m_requestType != null)
      children.Add((BaseInstanceState) this.m_requestType);
    if (this.m_securityPolicyUri != null)
      children.Add((BaseInstanceState) this.m_securityPolicyUri);
    if (this.m_securityMode != null)
      children.Add((BaseInstanceState) this.m_securityMode);
    if (this.m_requestedLifetime != null)
      children.Add((BaseInstanceState) this.m_requestedLifetime);
    if (this.m_certificateErrorEventId != null)
      children.Add((BaseInstanceState) this.m_certificateErrorEventId);
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
        case 11:
          if (name == "RequestType")
          {
            if (createOrReplace && this.RequestType == null)
              this.RequestType = replacement != null ? (PropertyState<SecurityTokenRequestType>) replacement : new PropertyState<SecurityTokenRequestType>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RequestType;
            break;
          }
          break;
        case 12:
          if (name == "SecurityMode")
          {
            if (createOrReplace && this.SecurityMode == null)
              this.SecurityMode = replacement != null ? (PropertyState<MessageSecurityMode>) replacement : new PropertyState<MessageSecurityMode>((NodeState) this);
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
                  this.ClientCertificate = replacement != null ? (PropertyState<byte[]>) replacement : new PropertyState<byte[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ClientCertificate;
                break;
              }
              break;
            case 'R':
              if (name == "RequestedLifetime")
              {
                if (createOrReplace && this.RequestedLifetime == null)
                  this.RequestedLifetime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RequestedLifetime;
                break;
              }
              break;
            case 'S':
              if (name == "SecurityPolicyUri")
              {
                if (createOrReplace && this.SecurityPolicyUri == null)
                  this.SecurityPolicyUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SecurityPolicyUri;
                break;
              }
              break;
          }
          break;
        case 23:
          if (name == "CertificateErrorEventId")
          {
            if (createOrReplace && this.CertificateErrorEventId == null)
              this.CertificateErrorEventId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CertificateErrorEventId;
            break;
          }
          break;
        case 27:
          if (name == "ClientCertificateThumbprint")
          {
            if (createOrReplace && this.ClientCertificateThumbprint == null)
              this.ClientCertificateThumbprint = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ClientCertificateThumbprint;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
