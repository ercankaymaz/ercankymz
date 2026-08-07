// Decompiled with JetBrains decompiler
// Type: Opc.Ua.X509CertificateStore
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Security.Certificates;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class X509CertificateStore : ICertificateStore, IDisposable
{
  private bool m_noPrivateKeys;
  private string m_storeName;
  private string m_storePath;
  private StoreLocation m_storeLocation;

  public X509CertificateStore()
  {
    this.m_storeName = "My";
    this.m_storeLocation = StoreLocation.CurrentUser;
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.Close();
  }

  public void Open(string location, bool noPrivateKeys = true)
  {
    this.m_storePath = location != null ? location : throw new ArgumentNullException(nameof (location));
    this.m_noPrivateKeys = noPrivateKeys;
    location = location.Trim();
    int length = !string.IsNullOrEmpty(location) ? location.IndexOf('\\') : throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Store Location cannot be empty.");
    string str = length != -1 ? location.Substring(0, length) : throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Path does not specify a store name. Path={0}", (object) location);
    bool flag = false;
    foreach (StoreLocation storeLocation in (StoreLocation[]) Enum.GetValues(typeof (StoreLocation)))
    {
      if (storeLocation.ToString().Equals(str, StringComparison.OrdinalIgnoreCase))
      {
        this.m_storeLocation = storeLocation;
        flag = true;
      }
    }
    if (!flag)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("Store location specified not available.");
      stringBuilder.AppendLine("Store location={0}");
      throw ServiceResultException.Create(2147549184U /*0x80010000*/, stringBuilder.ToString(), (object) str);
    }
    this.m_storeName = location.Substring(length + 1);
  }

  public void Close()
  {
  }

  public string StoreType => "X509Store";

  public string StorePath => this.m_storePath;

  public Task<X509Certificate2Collection> Enumerate()
  {
    using (X509Store x509Store = new X509Store(this.m_storeName, this.m_storeLocation))
    {
      x509Store.Open(OpenFlags.ReadOnly);
      return Task.FromResult<X509Certificate2Collection>(new X509Certificate2Collection(x509Store.Certificates));
    }
  }

  public Task Add(X509Certificate2 certificate, string password = null)
  {
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    using (X509Store x509Store = new X509Store(this.m_storeName, this.m_storeLocation))
    {
      x509Store.Open(OpenFlags.ReadWrite);
      if (!x509Store.Certificates.Contains(certificate))
      {
        if (certificate.HasPrivateKey && !this.m_noPrivateKeys && Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
          string passcode = X509Utils.GeneratePasscode();
          using (X509Certificate2 certificate1 = new X509Certificate2(certificate.Export(X509ContentType.Pfx, passcode), passcode, X509KeyStorageFlags.PersistKeySet))
            x509Store.Add(certificate1);
        }
        else if (certificate.HasPrivateKey && this.m_noPrivateKeys)
          x509Store.Add(new X509Certificate2(certificate.RawData));
        else
          x509Store.Add(certificate);
        Utils.LogCertificate("Added certificate to X509Store {0}.", certificate, (object) x509Store.Name);
      }
    }
    return Task.CompletedTask;
  }

  public Task<bool> Delete(string thumbprint)
  {
    using (X509Store x509Store = new X509Store(this.m_storeName, this.m_storeLocation))
    {
      x509Store.Open(OpenFlags.ReadWrite);
      X509Certificate2Enumerator enumerator = x509Store.Certificates.GetEnumerator();
      while (enumerator.MoveNext())
      {
        X509Certificate2 current = enumerator.Current;
        if (current.Thumbprint == thumbprint)
          x509Store.Remove(current);
      }
    }
    return Task.FromResult<bool>(true);
  }

  public Task<X509Certificate2Collection> FindByThumbprint(string thumbprint)
  {
    using (X509Store x509Store = new X509Store(this.m_storeName, this.m_storeLocation))
    {
      x509Store.Open(OpenFlags.ReadOnly);
      X509Certificate2Collection result = new X509Certificate2Collection();
      X509Certificate2Enumerator enumerator = x509Store.Certificates.GetEnumerator();
      while (enumerator.MoveNext())
      {
        X509Certificate2 current = enumerator.Current;
        if (current.Thumbprint == thumbprint)
          result.Add(current);
      }
      return Task.FromResult<X509Certificate2Collection>(result);
    }
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
    throw new ServiceResultException(2151481344U /*0x803D0000*/);
  }

  public Task<X509CRLCollection> EnumerateCRLs(X509Certificate2 issuer, bool validateUpdateTime = true)
  {
    throw new ServiceResultException(2151481344U /*0x803D0000*/);
  }

  public Task AddCRL(X509CRL crl) => throw new ServiceResultException(2151481344U /*0x803D0000*/);

  public Task<bool> DeleteCRL(X509CRL crl)
  {
    throw new ServiceResultException(2151481344U /*0x803D0000*/);
  }
}
