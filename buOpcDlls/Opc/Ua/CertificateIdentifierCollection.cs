// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateIdentifierCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfCertificateIdentifier", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "CertificateIdentifier")]
[ComVisible(true)]
public class CertificateIdentifierCollection : 
  List<CertificateIdentifier>,
  ICertificateStore,
  IDisposable,
  ICloneable
{
  public CertificateIdentifierCollection()
  {
  }

  public CertificateIdentifierCollection(IEnumerable<CertificateIdentifier> collection)
    : base(collection)
  {
  }

  public CertificateIdentifierCollection(int capacity)
    : base(capacity)
  {
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CertificateIdentifierCollection identifierCollection = new CertificateIdentifierCollection();
    for (int index = 0; index < this.Count; ++index)
      identifierCollection.Add((CertificateIdentifier) Utils.Clone((object) this[index]));
    return (object) identifierCollection;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
  }

  public void Open(string location, bool noPrivateKeys)
  {
  }

  public void Close()
  {
  }

  public string StoreType => string.Empty;

  public string StorePath => string.Empty;

  public async Task<X509Certificate2Collection> Enumerate()
  {
    CertificateIdentifierCollection identifierCollection = this;
    X509Certificate2Collection collection = new X509Certificate2Collection();
    // ISSUE: explicit non-virtual call
    for (int ii = 0; ii < __nonvirtual (identifierCollection.Count); ++ii)
    {
      // ISSUE: explicit non-virtual call
      X509Certificate2 certificate = await __nonvirtual (identifierCollection[ii]).Find(false).ConfigureAwait(false);
      if (certificate == null)
        continue;
      collection.Add(certificate);
    }
    X509Certificate2Collection certificate2Collection = collection;
    collection = (X509Certificate2Collection) null;
    return certificate2Collection;
  }

  public async Task Add(X509Certificate2 certificate, string password = null)
  {
    CertificateIdentifierCollection identifierCollection = this;
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    // ISSUE: explicit non-virtual call
    for (int ii = 0; ii < __nonvirtual (identifierCollection.Count); ++ii)
    {
      // ISSUE: explicit non-virtual call
      X509Certificate2 x509Certificate2 = await __nonvirtual (identifierCollection[ii]).Find(false).ConfigureAwait(false);
      if (x509Certificate2 != null && x509Certificate2.Thumbprint == certificate.Thumbprint)
        throw ServiceResultException.Create(2157903872U /*0x809F0000*/, "A certificate with the specified thumbprint already exists. Subject={0}, Thumbprint={1}", (object) certificate.SubjectName, (object) certificate.Thumbprint);
    }
    // ISSUE: explicit non-virtual call
    __nonvirtual (identifierCollection.Add(new CertificateIdentifier(certificate)));
  }

  public async Task<bool> Delete(string thumbprint)
  {
    CertificateIdentifierCollection identifierCollection = this;
    if (string.IsNullOrEmpty(thumbprint))
      return false;
    // ISSUE: explicit non-virtual call
    for (int ii = 0; ii < __nonvirtual (identifierCollection.Count); ++ii)
    {
      // ISSUE: explicit non-virtual call
      X509Certificate2 x509Certificate2 = await __nonvirtual (identifierCollection[ii]).Find(false).ConfigureAwait(false);
      if (x509Certificate2 != null && x509Certificate2.Thumbprint == thumbprint)
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (identifierCollection.RemoveAt(ii));
        return true;
      }
    }
    return false;
  }

  public async Task<X509Certificate2Collection> FindByThumbprint(string thumbprint)
  {
    CertificateIdentifierCollection identifierCollection = this;
    if (string.IsNullOrEmpty(thumbprint))
      return (X509Certificate2Collection) null;
    // ISSUE: explicit non-virtual call
    for (int ii = 0; ii < __nonvirtual (identifierCollection.Count); ++ii)
    {
      // ISSUE: explicit non-virtual call
      X509Certificate2 x509Certificate2 = await __nonvirtual (identifierCollection[ii]).Find(false).ConfigureAwait(false);
      if (x509Certificate2 != null && x509Certificate2.Thumbprint == thumbprint)
        return new X509Certificate2Collection()
        {
          x509Certificate2
        };
    }
    return new X509Certificate2Collection();
  }

  public bool SupportsLoadPrivateKey => false;

  public Task<X509Certificate2> LoadPrivateKey(
    string thumbprint,
    string subjectName,
    string password)
  {
    return Task.FromResult<X509Certificate2>((X509Certificate2) null);
  }

  public bool SupportsCRLs => false;

  public Task<StatusCode> IsRevoked(X509Certificate2 issuer, X509Certificate2 certificate)
  {
    return Task.FromResult<StatusCode>((StatusCode) 2151481344U /*0x803D0000*/);
  }

  public Task<X509CRLCollection> EnumerateCRLs()
  {
    return Task.FromResult<X509CRLCollection>(new X509CRLCollection());
  }

  public Task<X509CRLCollection> EnumerateCRLs(X509Certificate2 issuer, bool validateUpdateTime = true)
  {
    return Task.FromResult<X509CRLCollection>(new X509CRLCollection());
  }

  public Task AddCRL(X509CRL crl) => throw new ServiceResultException(2151481344U /*0x803D0000*/);

  public Task<bool> DeleteCRL(X509CRL crl)
  {
    throw new ServiceResultException(2151481344U /*0x803D0000*/);
  }
}
