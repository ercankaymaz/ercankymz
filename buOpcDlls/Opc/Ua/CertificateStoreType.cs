// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateStoreType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class CertificateStoreType
{
  public const string X509Store = "X509Store";
  public const string Directory = "Directory";
  private static readonly Dictionary<string, ICertificateStoreType> s_registeredStoreTypes = new Dictionary<string, ICertificateStoreType>();

  public static void RegisterCertificateStoreType(
    string storeTypeName,
    ICertificateStoreType storeType)
  {
    CertificateStoreType.s_registeredStoreTypes.Add(storeTypeName, storeType);
  }

  public static ICertificateStoreType GetCertificateStoreTypeByName(string storeTypeName)
  {
    ICertificateStoreType certificateStoreTypeByName;
    CertificateStoreType.s_registeredStoreTypes.TryGetValue(storeTypeName, out certificateStoreTypeByName);
    return certificateStoreTypeByName;
  }

  public static IReadOnlyCollection<string> RegisteredStoreTypeNames
  {
    get => (IReadOnlyCollection<string>) CertificateStoreType.s_registeredStoreTypes.Keys;
  }
}
