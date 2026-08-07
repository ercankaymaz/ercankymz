// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DirectoryCertificateStore
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using Opc.Ua.Security.Certificates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class DirectoryCertificateStore : ICertificateStore, IDisposable
{
  private const string kCertsPath = "certs";
  private const string kPrivateKeyPath = "private";
  private const string kCrlPath = "crl";
  private const string kCertExtension = ".der";
  private const string kCrlExtension = ".crl";
  private const string kPemExtension = ".pem";
  private const string kPfxExtension = ".pfx";
  private readonly object m_lock = new object();
  private bool m_noSubDirs;
  private DirectoryInfo m_directory;
  private DirectoryInfo m_certificateSubdir;
  private DirectoryInfo m_crlSubdir;
  private DirectoryInfo m_privateKeySubdir;
  private Dictionary<string, DirectoryCertificateStore.Entry> m_certificates;
  private DateTime m_lastDirectoryCheck;

  public DirectoryCertificateStore()
    : this(false)
  {
  }

  public DirectoryCertificateStore(bool noSubDirs)
  {
    this.m_noSubDirs = noSubDirs;
    this.m_certificates = new Dictionary<string, DirectoryCertificateStore.Entry>();
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    if (disposing)
    {
      lock (this.m_lock)
      {
        this.m_certificates.Clear();
        this.m_directory = (DirectoryInfo) null;
        this.m_certificateSubdir = (DirectoryInfo) null;
        this.m_privateKeySubdir = (DirectoryInfo) null;
        this.m_crlSubdir = (DirectoryInfo) null;
        this.m_lastDirectoryCheck = DateTime.MinValue;
      }
    }
    this.Close();
  }

  public DirectoryInfo Directory => this.m_directory;

  public void Open(string location, bool noPrivateKeys = false)
  {
    lock (this.m_lock)
    {
      string path = Utils.ReplaceSpecialFolderNames(location);
      DirectoryInfo directory = this.m_directory;
      if ((directory != null ? (!directory.FullName.Equals(path, StringComparison.Ordinal) ? 1 : 0) : 1) == 0 && this.NoPrivateKeys == noPrivateKeys)
        return;
      this.NoPrivateKeys = noPrivateKeys;
      this.StorePath = location;
      this.m_directory = new DirectoryInfo(path);
      if (this.m_noSubDirs)
      {
        this.m_certificateSubdir = this.m_directory;
        this.m_crlSubdir = this.m_directory;
        this.m_privateKeySubdir = !noPrivateKeys ? this.m_directory : (DirectoryInfo) null;
      }
      else
      {
        this.m_certificateSubdir = new DirectoryInfo(Path.Combine(this.m_directory.FullName, "certs"));
        this.m_crlSubdir = new DirectoryInfo(Path.Combine(this.m_directory.FullName, "crl"));
        this.m_privateKeySubdir = !noPrivateKeys ? new DirectoryInfo(Path.Combine(this.m_directory.FullName, "private")) : (DirectoryInfo) null;
      }
      this.m_certificates.Clear();
      this.m_lastDirectoryCheck = DateTime.MinValue;
    }
  }

  public void Close()
  {
  }

  public string StoreType => "Directory";

  public string StorePath { get; private set; }

  public Task<X509Certificate2Collection> Enumerate()
  {
    lock (this.m_lock)
    {
      IDictionary<string, DirectoryCertificateStore.Entry> dictionary = this.Load((string) null);
      X509Certificate2Collection result = new X509Certificate2Collection();
      foreach (DirectoryCertificateStore.Entry entry in (IEnumerable<DirectoryCertificateStore.Entry>) dictionary.Values)
      {
        if (entry.CertificateWithPrivateKey != null)
          result.Add(entry.CertificateWithPrivateKey);
        else if (entry.Certificate != null)
          result.Add(entry.Certificate);
      }
      return Task.FromResult<X509Certificate2Collection>(result);
    }
  }

  public Task Add(X509Certificate2 certificate, string password = null)
  {
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    lock (this.m_lock)
    {
      if (this.Find(certificate.Thumbprint) != null)
        throw new ArgumentException("A certificate with the same thumbprint is already in the store.");
      bool includePrivateKey;
      byte[] data;
      if (includePrivateKey = !this.NoPrivateKeys && certificate.HasPrivateKey)
      {
        string password1 = password ?? string.Empty;
        data = certificate.Export(X509ContentType.Pfx, password1);
      }
      else
        data = certificate.RawData;
      string fileName = this.GetFileName(certificate);
      this.WriteFile(data, fileName, includePrivateKey);
      if (includePrivateKey)
        this.WriteFile(certificate.RawData, fileName, false);
      this.m_lastDirectoryCheck = DateTime.MinValue;
    }
    return Task.CompletedTask;
  }

  public async Task<bool> Delete(string thumbprint)
  {
    int retry = 5;
    bool found = false;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
    do
    {
      lock (this.m_lock)
      {
        DirectoryCertificateStore.Entry entry = this.Find(thumbprint);
        try
        {
          if (entry != null)
          {
            if (entry.PrivateKeyFile != null && entry.PrivateKeyFile.Exists)
            {
              entry.PrivateKeyFile.Delete();
              found = true;
            }
            if (entry.CertificateFile != null && entry.CertificateFile.Exists)
            {
              entry.CertificateFile.Delete();
              found = true;
            }
          }
          retry = 0;
        }
        catch (IOException ex)
        {
          Utils.LogWarning("Failed to delete cert [{0}], retry.", (object) thumbprint);
          --retry;
        }
        if (found)
          this.m_lastDirectoryCheck = DateTime.MinValue;
      }
      if (retry > 0)
        goto label_17;
label_16:
      continue;
label_17:
      awaiter = Task.Delay(100).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        awaiter.GetResult();
        goto label_16;
      }
      goto label_20;
    }
    while (retry > 0);
    return found;
label_20:
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003E1__state = 0;
    ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, DirectoryCertificateStore.\u003CDelete\u003Ed__23>(ref awaiter, this);
  }

  public Task<X509Certificate2Collection> FindByThumbprint(string thumbprint)
  {
    X509Certificate2Collection result = new X509Certificate2Collection();
    lock (this.m_lock)
    {
      DirectoryCertificateStore.Entry entry = this.Find(thumbprint);
      if (entry != null)
      {
        if (entry.CertificateWithPrivateKey != null)
          result.Add(entry.CertificateWithPrivateKey);
        else
          result.Add(entry.Certificate);
      }
      return Task.FromResult<X509Certificate2Collection>(result);
    }
  }

  public string GetPublicKeyFilePath(string thumbprint)
  {
    DirectoryCertificateStore.Entry entry = this.Find(thumbprint);
    if (entry == null)
      return (string) null;
    return entry.CertificateFile != null && entry.CertificateFile.Exists ? entry.CertificateFile.FullName : (string) null;
  }

  public string GetPrivateKeyFilePath(string thumbprint)
  {
    DirectoryCertificateStore.Entry entry = this.Find(thumbprint);
    if (entry == null)
      return (string) null;
    return entry.PrivateKeyFile != null && entry.PrivateKeyFile.Exists ? entry.PrivateKeyFile.FullName : (string) null;
  }

  public bool SupportsLoadPrivateKey => true;

  public async Task<X509Certificate2> LoadPrivateKey(
    string thumbprint,
    string subjectName,
    string password)
  {
    if (this.NoPrivateKeys || this.m_privateKeySubdir == null || this.m_certificateSubdir == null || !this.m_certificateSubdir.Exists || string.IsNullOrEmpty(thumbprint) && string.IsNullOrEmpty(subjectName))
      return (X509Certificate2) null;
    int retryCounter = 3;
    while (retryCounter-- > 0)
    {
      bool flag = false;
      Exception exception = (Exception) null;
      foreach (FileInfo file in this.m_certificateSubdir.GetFiles("*.der"))
      {
        try
        {
          X509Certificate2 x509Certificate2 = new X509Certificate2(file.FullName);
          if (!string.IsNullOrEmpty(thumbprint))
          {
            if (!string.Equals(x509Certificate2.Thumbprint, thumbprint, StringComparison.OrdinalIgnoreCase))
              continue;
          }
          if (!string.IsNullOrEmpty(subjectName) && !X509Utils.CompareDistinguishedName(subjectName, x509Certificate2.Subject))
          {
            if (!subjectName.Contains<char>('='))
            {
              if (!X509Utils.ParseDistinguishedName(x509Certificate2.Subject).Any<string>((Func<string, bool>) (s => s.Equals("CN=" + subjectName, StringComparison.Ordinal))))
                continue;
            }
            else
              continue;
          }
          if (X509Utils.GetRSAPublicKeySize(x509Certificate2) >= 0)
          {
            string str = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
            StringBuilder stringBuilder = new StringBuilder().Append(this.m_privateKeySubdir.FullName).Append(Path.DirectorySeparatorChar).Append(str);
            X509KeyStorageFlags[] x509KeyStorageFlagsArray = new X509KeyStorageFlags[2]
            {
              X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable,
              X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable
            };
            FileInfo fileInfo1 = new FileInfo(stringBuilder?.ToString() + ".pfx");
            FileInfo fileInfo2 = new FileInfo(stringBuilder?.ToString() + ".pem");
            password = password ?? string.Empty;
            if (fileInfo1.Exists)
            {
              flag = true;
              foreach (X509KeyStorageFlags keyStorageFlags in x509KeyStorageFlagsArray)
              {
                try
                {
                  x509Certificate2 = new X509Certificate2(fileInfo1.FullName, password, keyStorageFlags);
                  if (X509Utils.VerifyRSAKeyPair(x509Certificate2, x509Certificate2, true))
                  {
                    Utils.LogInfo((EventId) 512 /*0x0200*/, "Imported the PFX private key for [{0}].", (object) x509Certificate2.Thumbprint);
                    return x509Certificate2;
                  }
                }
                catch (Exception ex)
                {
                  exception = ex;
                  x509Certificate2?.Dispose();
                }
              }
            }
            else if (fileInfo2.Exists)
            {
              flag = true;
              try
              {
                byte[] pemDataBlob = File.ReadAllBytes(fileInfo2.FullName);
                x509Certificate2 = CertificateFactory.CreateCertificateWithPEMPrivateKey(x509Certificate2, pemDataBlob, password);
                if (X509Utils.VerifyRSAKeyPair(x509Certificate2, x509Certificate2, true))
                {
                  Utils.LogInfo((EventId) 512 /*0x0200*/, "Imported the PEM private key for [{0}].", (object) x509Certificate2.Thumbprint);
                  return x509Certificate2;
                }
              }
              catch (Exception ex)
              {
                x509Certificate2?.Dispose();
                exception = ex;
              }
            }
            else
              Utils.LogError((EventId) 512 /*0x0200*/, "A private key for the certificate with thumbprint [{0}] does not exist.", (object) x509Certificate2.Thumbprint);
          }
        }
        catch (Exception ex)
        {
          object[] objArray = new object[1]
          {
            (object) subjectName
          };
          Utils.LogError(ex, "Could not load private key for certificate {0}", objArray);
        }
      }
      if (flag)
      {
        Utils.LogError((EventId) 512 /*0x0200*/, "The private key for the certificate with subject {0} failed to import.", (object) subjectName);
        if (exception != null)
          Utils.LogError(exception, "Certificate import failed.");
        if (retryCounter > 0)
        {
          Utils.LogInfo((EventId) 512 /*0x0200*/, "Retry to import private key after {0} ms.", (object) 100);
          await Task.Delay(100).ConfigureAwait(false);
        }
      }
      else
      {
        if (!string.IsNullOrEmpty(thumbprint))
        {
          Utils.LogError((EventId) 512 /*0x0200*/, "A Private key for the certificate with thumbpint {0} was not found.", (object) thumbprint);
          break;
        }
        break;
      }
    }
    return (X509Certificate2) null;
  }

  public Task<StatusCode> IsRevoked(X509Certificate2 issuer, X509Certificate2 certificate)
  {
    if (issuer == null)
      throw new ArgumentNullException(nameof (issuer));
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    if (this.m_crlSubdir.Exists)
    {
      bool flag = true;
      foreach (FileInfo file in this.m_crlSubdir.GetFiles("*.crl"))
      {
        X509CRL x509Crl;
        try
        {
          x509Crl = new X509CRL(file.FullName);
        }
        catch (Exception ex)
        {
          object[] objArray = Array.Empty<object>();
          Utils.LogError(ex, "Could not parse CRL file.", objArray);
          continue;
        }
        if (X509Utils.CompareDistinguishedName(x509Crl.IssuerName, issuer.SubjectName) && x509Crl.VerifySignature(issuer, false))
        {
          if (x509Crl.IsRevoked(certificate))
            return Task.FromResult<StatusCode>((StatusCode) 2149384192U /*0x801D0000*/);
          if (x509Crl.ThisUpdate <= DateTime.UtcNow && (x509Crl.NextUpdate == DateTime.MinValue || x509Crl.NextUpdate >= DateTime.UtcNow))
            flag = false;
        }
      }
      if (!flag)
        return Task.FromResult<StatusCode>((StatusCode) 0U);
    }
    return Task.FromResult<StatusCode>((StatusCode) 2149253120U /*0x801B0000*/);
  }

  public bool SupportsCRLs => true;

  public Task<X509CRLCollection> EnumerateCRLs()
  {
    X509CRLCollection result = new X509CRLCollection();
    if (this.m_crlSubdir.Exists)
    {
      foreach (FileSystemInfo file in this.m_crlSubdir.GetFiles("*.crl"))
      {
        X509CRL x509Crl = new X509CRL(file.FullName);
        result.Add(x509Crl);
      }
    }
    return Task.FromResult<X509CRLCollection>(result);
  }

  public async Task<X509CRLCollection> EnumerateCRLs(
    X509Certificate2 issuer,
    bool validateUpdateTime = true)
  {
    if (issuer == null)
      throw new ArgumentNullException(nameof (issuer));
    X509CRLCollection crls = new X509CRLCollection();
    foreach (X509CRL x509Crl in (List<X509CRL>) await this.EnumerateCRLs().ConfigureAwait(false))
    {
      if (X509Utils.CompareDistinguishedName(x509Crl.IssuerName, issuer.SubjectName) && x509Crl.VerifySignature(issuer, false) && (!validateUpdateTime || x509Crl.ThisUpdate <= DateTime.UtcNow && (x509Crl.NextUpdate == DateTime.MinValue || x509Crl.NextUpdate >= DateTime.UtcNow)))
        crls.Add(x509Crl);
    }
    X509CRLCollection x509CrlCollection = crls;
    crls = (X509CRLCollection) null;
    return x509CrlCollection;
  }

  public async Task AddCRL(X509CRL crl)
  {
    if (crl == null)
      throw new ArgumentNullException(nameof (crl));
    X509Certificate2 issuer = (X509Certificate2) null;
    foreach (X509Certificate2 issuer1 in await this.Enumerate().ConfigureAwait(false))
    {
      if (X509Utils.CompareDistinguishedName(issuer1.SubjectName, crl.IssuerName) && crl.VerifySignature(issuer1, false))
      {
        issuer = issuer1;
        break;
      }
    }
    if (issuer == null)
      throw new ServiceResultException(2148663296U /*0x80120000*/, "Could not find issuer of the CRL.");
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(this.m_crlSubdir.FullName).Append(Path.DirectorySeparatorChar);
    stringBuilder.Append(this.GetFileName(issuer)).Append(".crl");
    FileInfo fileInfo = new FileInfo(stringBuilder.ToString());
    if (!fileInfo.Directory.Exists)
      fileInfo.Directory.Create();
    File.WriteAllBytes(fileInfo.FullName, crl.RawData);
    issuer = (X509Certificate2) null;
  }

  public Task<bool> DeleteCRL(X509CRL crl)
  {
    if (crl == null)
      throw new ArgumentNullException(nameof (crl));
    if (this.m_crlSubdir.Exists)
    {
      foreach (FileInfo file in this.m_crlSubdir.GetFiles("*.crl"))
      {
        if (file.Length == (long) crl.RawData.Length && Utils.IsEqual((object) File.ReadAllBytes(file.FullName), (object) crl.RawData))
        {
          file.Delete();
          return Task.FromResult<bool>(true);
        }
      }
    }
    return Task.FromResult<bool>(false);
  }

  private bool NoPrivateKeys { get; set; }

  private IDictionary<string, DirectoryCertificateStore.Entry> Load(string thumbprint)
  {
    lock (this.m_lock)
    {
      DateTime utcNow = DateTime.UtcNow;
      if (this.m_certificateSubdir != null)
        this.m_certificateSubdir.Refresh();
      if (!this.NoPrivateKeys && this.m_privateKeySubdir != null)
        this.m_privateKeySubdir.Refresh();
      if (!this.m_certificateSubdir.Exists)
      {
        this.m_certificates.Clear();
        return (IDictionary<string, DirectoryCertificateStore.Entry>) this.m_certificates;
      }
      if (this.m_certificateSubdir.LastWriteTimeUtc < this.m_lastDirectoryCheck && (this.NoPrivateKeys || this.m_privateKeySubdir == null || !this.m_privateKeySubdir.Exists || this.m_privateKeySubdir.LastWriteTimeUtc < this.m_lastDirectoryCheck))
        return (IDictionary<string, DirectoryCertificateStore.Entry>) this.m_certificates;
      this.m_certificates.Clear();
      this.m_lastDirectoryCheck = utcNow;
      bool flag = false;
      foreach (FileInfo file in this.m_certificateSubdir.GetFiles("*.der"))
      {
        try
        {
          DirectoryCertificateStore.Entry entry = new DirectoryCertificateStore.Entry()
          {
            Certificate = new X509Certificate2(file.FullName),
            CertificateFile = file,
            PrivateKeyFile = (FileInfo) null,
            CertificateWithPrivateKey = (X509Certificate2) null
          };
          if (!this.NoPrivateKeys)
          {
            string str = file.Name.Substring(0, entry.CertificateFile.Name.Length - entry.CertificateFile.Extension.Length);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.m_privateKeySubdir.FullName);
            stringBuilder.Append(Path.DirectorySeparatorChar);
            stringBuilder.Append(str);
            entry.PrivateKeyFile = new FileInfo(stringBuilder.ToString() + ".pfx");
            if (!entry.PrivateKeyFile.Exists)
            {
              entry.PrivateKeyFile = new FileInfo(stringBuilder.ToString() + ".pem");
              if (!entry.PrivateKeyFile.Exists)
                entry.PrivateKeyFile = (FileInfo) null;
            }
          }
          this.m_certificates[entry.Certificate.Thumbprint] = entry;
          if (!string.IsNullOrEmpty(thumbprint))
          {
            if (thumbprint.Equals(entry.Certificate.Thumbprint, StringComparison.OrdinalIgnoreCase))
            {
              flag = true;
              break;
            }
          }
        }
        catch (Exception ex)
        {
          object[] objArray = new object[1]
          {
            (object) file.FullName
          };
          Utils.LogError(ex, "Could not load certificate from file: {0}", objArray);
        }
      }
      if (flag)
        this.m_lastDirectoryCheck = DateTime.MinValue;
      return (IDictionary<string, DirectoryCertificateStore.Entry>) this.m_certificates;
    }
  }

  private DirectoryCertificateStore.Entry Find(string thumbprint)
  {
    IDictionary<string, DirectoryCertificateStore.Entry> dictionary = this.Load(thumbprint);
    DirectoryCertificateStore.Entry entry = (DirectoryCertificateStore.Entry) null;
    return !string.IsNullOrEmpty(thumbprint) && !dictionary.TryGetValue(thumbprint, out entry) ? (DirectoryCertificateStore.Entry) null : entry;
  }

  private string GetFileName(X509Certificate2 certificate)
  {
    string str = certificate.FriendlyName;
    List<string> distinguishedName = X509Utils.ParseDistinguishedName(certificate.Subject);
    for (int index = 0; index < distinguishedName.Count; ++index)
    {
      if (distinguishedName[index].StartsWith("CN=", StringComparison.Ordinal))
      {
        str = distinguishedName[index].Substring(3).Trim();
        break;
      }
    }
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < str.Length; ++index)
    {
      char ch = str[index];
      if ("<>:\"/\\|?*".IndexOf(ch) != -1)
        ch = '+';
      stringBuilder.Append(ch);
    }
    stringBuilder.Append(" [");
    stringBuilder.Append(certificate.Thumbprint);
    stringBuilder.Append(']');
    return stringBuilder.ToString();
  }

  private void WriteFile(byte[] data, string fileName, bool includePrivateKey)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (!this.m_directory.Exists)
      this.m_directory.Create();
    if (includePrivateKey)
    {
      if (this.m_privateKeySubdir == null)
        return;
      stringBuilder.Append(this.m_privateKeySubdir.FullName);
    }
    else
      stringBuilder.Append(this.m_certificateSubdir.FullName);
    stringBuilder.Append(Path.DirectorySeparatorChar);
    stringBuilder.Append(fileName);
    if (includePrivateKey)
      stringBuilder.Append(".pfx");
    else
      stringBuilder.Append(".der");
    FileInfo fileInfo = new FileInfo(stringBuilder.ToString());
    if (!fileInfo.Directory.Exists)
      fileInfo.Directory.Create();
    BinaryWriter binaryWriter = new BinaryWriter((Stream) fileInfo.Open(FileMode.Create));
    try
    {
      binaryWriter.Write(data);
    }
    finally
    {
      binaryWriter.Flush();
      binaryWriter.Dispose();
    }
    this.m_certificateSubdir.Refresh();
    this.m_privateKeySubdir?.Refresh();
  }

  private class Entry
  {
    public FileInfo CertificateFile;
    public X509Certificate2 Certificate;
    public FileInfo PrivateKeyFile;
    public X509Certificate2 CertificateWithPrivateKey;
  }
}
