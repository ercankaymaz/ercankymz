// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ICertificateStore
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Security.Certificates;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface ICertificateStore : IDisposable
{
  void Open(string location, bool noPrivateKeys = true);

  void Close();

  string StoreType { get; }

  string StorePath { get; }

  Task<X509Certificate2Collection> Enumerate();

  Task Add(X509Certificate2 certificate, string password = null);

  Task<bool> Delete(string thumbprint);

  Task<X509Certificate2Collection> FindByThumbprint(string thumbprint);

  bool SupportsLoadPrivateKey { get; }

  Task<X509Certificate2> LoadPrivateKey(string thumbprint, string subjectName, string password);

  Task<StatusCode> IsRevoked(X509Certificate2 issuer, X509Certificate2 certificate);

  bool SupportsCRLs { get; }

  Task<X509CRLCollection> EnumerateCRLs();

  Task<X509CRLCollection> EnumerateCRLs(X509Certificate2 issuer, bool validateUpdateTime = true);

  Task AddCRL(X509CRL crl);

  Task<bool> DeleteCRL(X509CRL crl);
}
