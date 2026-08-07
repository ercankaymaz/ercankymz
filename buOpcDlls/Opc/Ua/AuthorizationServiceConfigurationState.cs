// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuthorizationServiceConfigurationState
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
public class AuthorizationServiceConfigurationState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAALQAAAEF1dGhvcml6YXRpb25TZXJ2aWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAvEUBALxFvEUAAP////8DAAAAFWCJCgIAAAAAAAoAAABTZXJ2aWNlVXJpAQCYRgAuAESYRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAU2VydmljZUNlcnRpZmljYXRlAQDERQAuAETERQAAAA//////AQH/////AAAAABVgiQoCAAAAAAARAAAASXNzdWVyRW5kcG9pbnRVcmwBAJlGAC4ARJlGAAAADP////8BAf////8AAAAA";
  private PropertyState<string> m_serviceUri;
  private PropertyState<byte[]> m_serviceCertificate;
  private PropertyState<string> m_issuerEndpointUrl;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17852U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALQAAAEF1dGhvcml6YXRpb25TZXJ2aWNlQ29uZmlndXJhdGlvblR5cGVJbnN0YW5jZQEAvEUBALxFvEUAAP////8DAAAAFWCJCgIAAAAAAAoAAABTZXJ2aWNlVXJpAQCYRgAuAESYRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAU2VydmljZUNlcnRpZmljYXRlAQDERQAuAETERQAAAA//////AQH/////AAAAABVgiQoCAAAAAAARAAAASXNzdWVyRW5kcG9pbnRVcmwBAJlGAC4ARJlGAAAADP////8BAf////8AAAAA");
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

  public PropertyState<string> ServiceUri
  {
    get => this.m_serviceUri;
    set
    {
      if (this.m_serviceUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serviceUri = value;
    }
  }

  public PropertyState<byte[]> ServiceCertificate
  {
    get => this.m_serviceCertificate;
    set
    {
      if (this.m_serviceCertificate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serviceCertificate = value;
    }
  }

  public PropertyState<string> IssuerEndpointUrl
  {
    get => this.m_issuerEndpointUrl;
    set
    {
      if (this.m_issuerEndpointUrl != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_issuerEndpointUrl = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_serviceUri != null)
      children.Add((BaseInstanceState) this.m_serviceUri);
    if (this.m_serviceCertificate != null)
      children.Add((BaseInstanceState) this.m_serviceCertificate);
    if (this.m_issuerEndpointUrl != null)
      children.Add((BaseInstanceState) this.m_issuerEndpointUrl);
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
      case "ServiceUri":
        if (createOrReplace && this.ServiceUri == null)
          this.ServiceUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ServiceUri;
        break;
      case "ServiceCertificate":
        if (createOrReplace && this.ServiceCertificate == null)
          this.ServiceCertificate = replacement != null ? (PropertyState<byte[]>) replacement : new PropertyState<byte[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ServiceCertificate;
        break;
      case "IssuerEndpointUrl":
        if (createOrReplace && this.IssuerEndpointUrl == null)
          this.IssuerEndpointUrl = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.IssuerEndpointUrl;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
