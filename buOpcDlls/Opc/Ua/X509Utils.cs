// Decompiled with JetBrains decompiler
// Type: Opc.Ua.X509Utils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class X509Utils
{
  public static IList<string> GetDomainsFromCertficate(X509Certificate2 certificate)
  {
    List<string> domainsFromCertficate = new List<string>();
    List<string> distinguishedName = X509Utils.ParseDistinguishedName(certificate.Subject);
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < distinguishedName.Count; ++index)
    {
      if (distinguishedName[index].StartsWith("DC="))
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append('.');
        stringBuilder.Append(distinguishedName[index].Substring(3));
      }
    }
    if (stringBuilder.Length > 0)
      domainsFromCertficate.Add(stringBuilder.ToString().ToUpperInvariant());
    X509SubjectAltNameExtension extension = certificate.FindExtension<X509SubjectAltNameExtension>();
    if (extension != null)
    {
      for (int index1 = 0; index1 < extension.DomainNames.Count; ++index1)
      {
        string domainName = extension.DomainNames[index1];
        bool flag = false;
        for (int index2 = 0; index2 < domainsFromCertficate.Count; ++index2)
        {
          if (string.Equals(domainsFromCertficate[index2], domainName, StringComparison.OrdinalIgnoreCase))
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          domainsFromCertficate.Add(domainName.ToUpperInvariant());
      }
      for (int index = 0; index < extension.IPAddresses.Count; ++index)
      {
        string ipAddress = extension.IPAddresses[index];
        if (!domainsFromCertficate.Contains(ipAddress))
          domainsFromCertficate.Add(ipAddress);
      }
    }
    return (IList<string>) domainsFromCertficate;
  }

  public static int GetRSAPublicKeySize(X509Certificate2 certificate)
  {
    using (RSA rsaPublicKey = RSACertificateExtensions.GetRSAPublicKey(certificate))
      return rsaPublicKey != null ? rsaPublicKey.KeySize : -1;
  }

  public static string GetApplicationUriFromCertificate(X509Certificate2 certificate)
  {
    X509SubjectAltNameExtension extension = certificate.FindExtension<X509SubjectAltNameExtension>();
    return extension != null && extension.Uris.Count > 0 ? extension.Uris[0] : string.Empty;
  }

  public static bool HasApplicationURN(X509Certificate2 certificate)
  {
    X509SubjectAltNameExtension extension = certificate.FindExtension<X509SubjectAltNameExtension>();
    if (extension != null && extension.Uris.Count > 0)
    {
      string strB = "urn:";
      for (int index = 0; index < extension.Uris.Count; ++index)
      {
        if (string.Compare(extension.Uris[index], 0, strB, 0, strB.Length, StringComparison.OrdinalIgnoreCase) == 0)
          return true;
      }
    }
    return false;
  }

  public static bool DoesUrlMatchCertificate(X509Certificate2 certificate, Uri endpointUrl)
  {
    if (endpointUrl == (Uri) null || certificate == null)
      return false;
    IList<string> domainsFromCertficate = X509Utils.GetDomainsFromCertficate(certificate);
    for (int index = 0; index < domainsFromCertficate.Count; ++index)
    {
      if (string.Equals(domainsFromCertficate[index], endpointUrl.DnsSafeHost, StringComparison.OrdinalIgnoreCase))
        return true;
    }
    return false;
  }

  public static bool IsIssuerAllowed(X509Certificate2 certificate)
  {
    X509BasicConstraintsExtension extension = certificate.FindExtension<X509BasicConstraintsExtension>();
    return extension != null && extension.CertificateAuthority;
  }

  public static bool IsCertificateAuthority(X509Certificate2 certificate)
  {
    X509BasicConstraintsExtension extension = certificate.FindExtension<X509BasicConstraintsExtension>();
    return extension != null && extension.CertificateAuthority;
  }

  public static X509KeyUsageFlags GetKeyUsage(X509Certificate2 cert)
  {
    X509KeyUsageFlags keyUsage = X509KeyUsageFlags.None;
    foreach (X509KeyUsageExtension keyUsageExtension in cert.Extensions.OfType<X509KeyUsageExtension>())
      keyUsage |= keyUsageExtension.KeyUsages;
    return keyUsage;
  }

  public static bool IsSelfSigned(X509Certificate2 certificate)
  {
    return X509Utils.CompareDistinguishedName(certificate.SubjectName, certificate.IssuerName);
  }

  public static bool CompareDistinguishedName(
    X500DistinguishedName name1,
    X500DistinguishedName name2)
  {
    return Utils.IsEqual((object) name1.RawData, (object) name2.RawData);
  }

  public static bool CompareDistinguishedName(string name1, string name2)
  {
    if (string.Equals(name1, name2, StringComparison.Ordinal))
      return true;
    List<string> distinguishedName1 = X509Utils.ParseDistinguishedName(name1);
    List<string> distinguishedName2 = X509Utils.ParseDistinguishedName(name2);
    return distinguishedName1.Count == distinguishedName2.Count && X509Utils.CompareDistinguishedNameFields((IList<string>) distinguishedName1, (IList<string>) distinguishedName2);
  }

  private static bool CompareDistinguishedNameFields(IList<string> fields1, IList<string> fields2)
  {
    for (int index = 0; index < fields1.Count; ++index)
    {
      StringComparison comparisonType = StringComparison.Ordinal;
      if (fields1[index].StartsWith("DC=", StringComparison.OrdinalIgnoreCase))
        comparisonType = StringComparison.OrdinalIgnoreCase;
      if (!string.Equals(fields1[index], fields2[index], comparisonType))
        return false;
    }
    return true;
  }

  public static bool CompareDistinguishedName(X509Certificate2 certificate, List<string> parsedName)
  {
    if (parsedName.Count == 0)
      return false;
    List<string> distinguishedName = X509Utils.ParseDistinguishedName(certificate.Subject);
    return parsedName.Count == distinguishedName.Count && X509Utils.CompareDistinguishedNameFields((IList<string>) parsedName, (IList<string>) distinguishedName);
  }

  public static List<string> ParseDistinguishedName(string name)
  {
    List<string> distinguishedName = new List<string>();
    if (string.IsNullOrEmpty(name))
      return distinguishedName;
    char ch1 = ',';
    bool flag1 = false;
    for (int index1 = name.Length - 1; index1 >= 0; --index1)
    {
      char ch2 = name[index1];
      if (ch2 == '"')
        flag1 = !flag1;
      else if (!flag1 && ch2 == '=')
      {
        int index2 = index1 - 1;
        while (index2 >= 0 && char.IsWhiteSpace(name[index2]))
          --index2;
        while (index2 >= 0 && (char.IsLetterOrDigit(name[index2]) || name[index2] == '.'))
          --index2;
        while (index2 >= 0 && char.IsWhiteSpace(name[index2]))
          --index2;
        if (index2 >= 0)
        {
          ch1 = name[index2];
          break;
        }
        break;
      }
    }
    StringBuilder stringBuilder = new StringBuilder();
    string str1 = (string) null;
    bool flag2 = false;
    for (int index = 0; index < name.Length; ++index)
    {
      while (index < name.Length && char.IsWhiteSpace(name[index]))
        ++index;
      if (index < name.Length)
      {
        char ch3 = name[index];
        if (flag2)
        {
          char ch4 = ch1;
          if (index < name.Length && name[index] == '"')
          {
            ++index;
            ch4 = '"';
          }
          for (; index < name.Length; ++index)
          {
            char ch5 = name[index];
            if ((int) ch5 != (int) ch4)
            {
              stringBuilder.Append(ch5);
            }
            else
            {
              while (index < name.Length && (int) name[index] != (int) ch1)
                ++index;
              break;
            }
          }
          string str2 = stringBuilder.ToString().TrimEnd();
          flag2 = false;
          stringBuilder.Length = 0;
          stringBuilder.Append(str1);
          stringBuilder.Append('=');
          if (str2.IndexOfAny(new char[3]{ '/', ',', '=' }) != -1)
          {
            if (str2.Length > 0 && str2[0] != '"')
              stringBuilder.Append('"');
            stringBuilder.Append(str2);
            if (str2.Length > 0 && str2[str2.Length - 1] != '"')
              stringBuilder.Append('"');
          }
          else
            stringBuilder.Append(str2);
          distinguishedName.Add(stringBuilder.ToString());
          stringBuilder.Length = 0;
        }
        else
        {
          for (; index < name.Length; ++index)
          {
            char ch6 = name[index];
            if (ch6 != '=')
              stringBuilder.Append(ch6);
            else
              break;
          }
          str1 = stringBuilder.ToString().TrimEnd().ToUpperInvariant();
          stringBuilder.Length = 0;
          flag2 = true;
        }
      }
      else
        break;
    }
    return distinguishedName;
  }

  public static bool VerifyRSAKeyPair(
    X509Certificate2 certWithPublicKey,
    X509Certificate2 certWithPrivateKey,
    bool throwOnError = false)
  {
    return X509PfxUtils.VerifyRSAKeyPair(certWithPublicKey, certWithPrivateKey, throwOnError);
  }

  public static bool VerifySelfSigned(X509Certificate2 cert)
  {
    try
    {
      return new X509Signature(cert.RawData).Verify(cert);
    }
    catch
    {
      return false;
    }
  }

  public static X509Certificate2 CreateCertificateFromPKCS12(byte[] rawData, string password)
  {
    return X509PfxUtils.CreateCertificateFromPKCS12(rawData, password);
  }

  public static async Task<X509Certificate2> FindIssuerCABySerialNumberAsync(
    ICertificateStore store,
    X500DistinguishedName issuer,
    string serialnumber)
  {
    foreach (X509Certificate2 serialNumberAsync in await store.Enumerate().ConfigureAwait(false))
    {
      if (X509Utils.CompareDistinguishedName(serialNumberAsync.SubjectName, issuer) && Utils.IsEqual((object) serialNumberAsync.SerialNumber, (object) serialnumber))
        return serialNumberAsync;
    }
    return (X509Certificate2) null;
  }

  public static X509Certificate2 AddToStore(
    this X509Certificate2 certificate,
    string storeType,
    string storePath,
    string password = null)
  {
    if (!string.IsNullOrEmpty(storePath) && !string.IsNullOrEmpty(storeType))
    {
      using (ICertificateStore store = CertificateStoreIdentifier.CreateStore(storeType))
      {
        if (store == null)
          throw new ArgumentException("Invalid store type");
        store.Open(storePath, false);
        store.Add(certificate, password).Wait();
        store.Close();
      }
    }
    return certificate;
  }

  public static async Task<X509Certificate2> AddToStoreAsync(
    this X509Certificate2 certificate,
    string storeType,
    string storePath,
    string password = null,
    CancellationToken ct = default (CancellationToken))
  {
    if (!string.IsNullOrEmpty(storePath) && !string.IsNullOrEmpty(storeType))
    {
      using (ICertificateStore store = CertificateStoreIdentifier.CreateStore(storeType))
      {
        if (store == null)
          throw new ArgumentException("Invalid store type");
        store.Open(storePath, false);
        await store.Add(certificate, password).ConfigureAwait(false);
        store.Close();
      }
    }
    return certificate;
  }

  public static HashAlgorithmName GetRSAHashAlgorithmName(uint hashSizeInBits)
  {
    if (hashSizeInBits <= 160U /*0xA0*/)
      return HashAlgorithmName.SHA1;
    if (hashSizeInBits <= 256U /*0x0100*/)
      return HashAlgorithmName.SHA256;
    return hashSizeInBits <= 384U ? HashAlgorithmName.SHA384 : HashAlgorithmName.SHA512;
  }

  internal static string GeneratePasscode() => Convert.ToBase64String(Utils.Nonce.CreateNonce(18U));
}
