// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateTrustList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class CertificateTrustList : CertificateStoreIdentifier
{
  private CertificateIdentifierCollection m_trustedCertificates;
  private object m_lock = new object();
  private ICertificateStore m_store;

  public CertificateTrustList() => this.Initialize();

  private void Initialize()
  {
    this.m_lock = new object();
    this.m_trustedCertificates = new CertificateIdentifierCollection();
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 3)]
  public CertificateIdentifierCollection TrustedCertificates
  {
    get => this.m_trustedCertificates;
    set
    {
      this.m_trustedCertificates = value;
      if (this.m_trustedCertificates != null)
        return;
      this.m_trustedCertificates = new CertificateIdentifierCollection();
    }
  }

  public override ICertificateStore OpenStore()
  {
    lock (this.m_lock)
    {
      if (this.m_store == null || this.m_store.StoreType != this.StoreType || this.m_store.StorePath != this.StorePath)
        this.m_store = CertificateStoreIdentifier.CreateStore(this.StoreType);
      this.m_store.Open(this.StorePath);
      return this.m_store;
    }
  }

  public async Task<X509Certificate2Collection> GetCertificates()
  {
    CertificateTrustList certificateTrustList = this;
    X509Certificate2Collection collection = new X509Certificate2Collection();
    if (!string.IsNullOrEmpty(certificateTrustList.StorePath))
    {
      ICertificateStore store = (ICertificateStore) null;
      try
      {
        store = certificateTrustList.OpenStore();
        collection = await store.Enumerate().ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        Utils.LogError("Could not load certificates from store: {0}.", (object) certificateTrustList.StorePath);
      }
      finally
      {
        store?.Close();
      }
      store = (ICertificateStore) null;
    }
    foreach (CertificateIdentifier trustedCertificate in (List<CertificateIdentifier>) certificateTrustList.TrustedCertificates)
    {
      X509Certificate2 certificate = await trustedCertificate.Find().ConfigureAwait(false);
      if (certificate != null)
        collection.Add(certificate);
    }
    X509Certificate2Collection certificates = collection;
    collection = (X509Certificate2Collection) null;
    return certificates;
  }
}
