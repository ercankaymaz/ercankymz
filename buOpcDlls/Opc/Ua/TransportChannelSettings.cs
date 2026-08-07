// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransportChannelSettings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class TransportChannelSettings
{
  private EndpointDescription m_description;
  private EndpointConfiguration m_configuration;
  private X509Certificate2 m_clientCertificate;
  private X509Certificate2Collection m_clientCertificateChain;
  private X509Certificate2 m_serverCertificate;
  private ICertificateValidator m_certificateValidator;
  private NamespaceTable m_namespaceUris;
  private IEncodeableFactory m_channelFactory;

  public EndpointDescription Description
  {
    get => this.m_description;
    set => this.m_description = value;
  }

  public EndpointConfiguration Configuration
  {
    get => this.m_configuration;
    set => this.m_configuration = value;
  }

  public X509Certificate2 ClientCertificate
  {
    get => this.m_clientCertificate;
    set => this.m_clientCertificate = value;
  }

  public X509Certificate2Collection ClientCertificateChain
  {
    get => this.m_clientCertificateChain;
    set => this.m_clientCertificateChain = value;
  }

  public X509Certificate2 ServerCertificate
  {
    get => this.m_serverCertificate;
    set => this.m_serverCertificate = value;
  }

  public ICertificateValidator CertificateValidator
  {
    get => this.m_certificateValidator;
    set => this.m_certificateValidator = value;
  }

  public NamespaceTable NamespaceUris
  {
    get => this.m_namespaceUris;
    set => this.m_namespaceUris = value;
  }

  public IEncodeableFactory Factory
  {
    get => this.m_channelFactory;
    set => this.m_channelFactory = value;
  }
}
