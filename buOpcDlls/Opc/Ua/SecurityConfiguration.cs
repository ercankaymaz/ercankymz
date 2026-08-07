// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SecurityConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class SecurityConfiguration
{
  private CertificateIdentifier m_applicationCertificate;
  private CertificateTrustList m_trustedIssuerCertificates;
  private CertificateTrustList m_trustedPeerCertificates;
  private CertificateTrustList m_httpsIssuerCertificates;
  private CertificateTrustList m_trustedHttpsCertificates;
  private CertificateTrustList m_userIssuerCertificates;
  private CertificateTrustList m_trustedUserCertificates;
  private int m_nonceLength;
  private CertificateStoreIdentifier m_rejectedCertificateStore;
  private bool m_autoAcceptUntrustedCertificates;
  private string m_userRoleDirectory;
  private bool m_rejectSHA1SignedCertificates;
  private bool m_rejectUnknownRevocationStatus;
  private ushort m_minCertificateKeySize;
  private bool m_useValidatedCertificates;
  private bool m_addAppCertToTrustedStore;
  private bool m_sendCertificateChain;
  private bool m_suppressNonceValidationErrors;

  public SecurityConfiguration() => this.Initialize();

  private void Initialize()
  {
    this.m_trustedIssuerCertificates = new CertificateTrustList();
    this.m_trustedPeerCertificates = new CertificateTrustList();
    this.m_nonceLength = 32 /*0x20*/;
    this.m_autoAcceptUntrustedCertificates = false;
    this.m_rejectSHA1SignedCertificates = true;
    this.m_rejectUnknownRevocationStatus = false;
    this.m_minCertificateKeySize = CertificateFactory.DefaultKeySize;
    this.m_addAppCertToTrustedStore = true;
    this.m_sendCertificateChain = true;
    this.m_suppressNonceValidationErrors = false;
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 0)]
  public CertificateIdentifier ApplicationCertificate
  {
    get => this.m_applicationCertificate;
    set => this.m_applicationCertificate = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
  public CertificateTrustList TrustedIssuerCertificates
  {
    get => this.m_trustedIssuerCertificates;
    set => this.m_trustedIssuerCertificates = value ?? new CertificateTrustList();
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 4)]
  public CertificateTrustList TrustedPeerCertificates
  {
    get => this.m_trustedPeerCertificates;
    set => this.m_trustedPeerCertificates = value ?? new CertificateTrustList();
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 6)]
  public int NonceLength
  {
    get => this.m_nonceLength;
    set => this.m_nonceLength = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 7)]
  public CertificateStoreIdentifier RejectedCertificateStore
  {
    get => this.m_rejectedCertificateStore;
    set => this.m_rejectedCertificateStore = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 8)]
  public bool AutoAcceptUntrustedCertificates
  {
    get => this.m_autoAcceptUntrustedCertificates;
    set => this.m_autoAcceptUntrustedCertificates = value;
  }

  [DataMember(Order = 9)]
  public string UserRoleDirectory
  {
    get => this.m_userRoleDirectory;
    set => this.m_userRoleDirectory = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 10)]
  public bool RejectSHA1SignedCertificates
  {
    get => this.m_rejectSHA1SignedCertificates;
    set => this.m_rejectSHA1SignedCertificates = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 11)]
  public bool RejectUnknownRevocationStatus
  {
    get => this.m_rejectUnknownRevocationStatus;
    set => this.m_rejectUnknownRevocationStatus = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 12)]
  public ushort MinimumCertificateKeySize
  {
    get => this.m_minCertificateKeySize;
    set => this.m_minCertificateKeySize = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 13)]
  public bool UseValidatedCertificates
  {
    get => this.m_useValidatedCertificates;
    set => this.m_useValidatedCertificates = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 14)]
  public bool AddAppCertToTrustedStore
  {
    get => this.m_addAppCertToTrustedStore;
    set => this.m_addAppCertToTrustedStore = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 15)]
  public bool SendCertificateChain
  {
    get => this.m_sendCertificateChain;
    set => this.m_sendCertificateChain = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 16 /*0x10*/)]
  public CertificateTrustList UserIssuerCertificates
  {
    get => this.m_userIssuerCertificates;
    set
    {
      this.m_userIssuerCertificates = value;
      if (this.m_userIssuerCertificates != null)
        return;
      this.m_userIssuerCertificates = new CertificateTrustList();
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 17)]
  public CertificateTrustList TrustedUserCertificates
  {
    get => this.m_trustedUserCertificates;
    set
    {
      this.m_trustedUserCertificates = value;
      if (this.m_trustedUserCertificates != null)
        return;
      this.m_trustedUserCertificates = new CertificateTrustList();
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 18)]
  public CertificateTrustList HttpsIssuerCertificates
  {
    get => this.m_httpsIssuerCertificates;
    set
    {
      this.m_httpsIssuerCertificates = value;
      if (this.m_httpsIssuerCertificates != null)
        return;
      this.m_httpsIssuerCertificates = new CertificateTrustList();
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 19)]
  public CertificateTrustList TrustedHttpsCertificates
  {
    get => this.m_trustedHttpsCertificates;
    set
    {
      this.m_trustedHttpsCertificates = value;
      if (this.m_trustedHttpsCertificates != null)
        return;
      this.m_trustedHttpsCertificates = new CertificateTrustList();
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 20)]
  public bool SuppressNonceValidationErrors
  {
    get => this.m_suppressNonceValidationErrors;
    set => this.m_suppressNonceValidationErrors = value;
  }

  public void AddTrustedPeer(byte[] certificate)
  {
    this.TrustedPeerCertificates.TrustedCertificates.Add(new CertificateIdentifier(certificate));
  }

  public void Validate()
  {
    if (this.m_applicationCertificate == null)
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, "ApplicationCertificate must be specified.");
    this.TrustedIssuerCertificates = this.CreateDefaultTrustList(this.TrustedIssuerCertificates);
    this.TrustedPeerCertificates = this.CreateDefaultTrustList(this.TrustedPeerCertificates);
    if (this.RejectedCertificateStore == null)
    {
      this.RejectedCertificateStore = new CertificateStoreIdentifier();
      this.RejectedCertificateStore.StoreType = "Directory";
      this.RejectedCertificateStore.StorePath = $"{Utils.DefaultLocalFolder}{Path.DirectorySeparatorChar.ToString()}Rejected";
    }
    this.ApplicationCertificate.SubjectName = Utils.ReplaceDCLocalhost(this.ApplicationCertificate.SubjectName);
  }

  private CertificateTrustList CreateDefaultTrustList(CertificateTrustList trustList)
  {
    return trustList != null && trustList.StorePath != null ? trustList : new CertificateTrustList();
  }

  public ICertificatePasswordProvider CertificatePasswordProvider { get; set; }
}
