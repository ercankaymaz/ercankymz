// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateStoreIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class CertificateStoreIdentifier : IFormattable, ICloneable
{
  private string m_storeType;
  private string m_storePath;
  private string m_storeLocation;
  private string m_storeName;
  private CertificateValidationOptions m_validationOptions;
  public static readonly string DefaultPKIRoot = Path.Combine("%CommonApplicationData%", "OPC Foundation", "pki");
  public static readonly string CurrentUser = "CurrentUser\\";
  public static readonly string LocalMachine = "LocalMachine\\";

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 0)]
  public string StoreType
  {
    get => !string.IsNullOrEmpty(this.m_storeName) ? "X509Store" : this.m_storeType;
    set => this.m_storeType = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
  public string StorePath
  {
    get
    {
      if (string.IsNullOrEmpty(this.m_storeName))
        return this.m_storePath;
      if (string.IsNullOrEmpty(this.m_storeLocation))
        return CertificateStoreIdentifier.CurrentUser + this.m_storeName;
      return Utils.Format("{0}\\{1}", (object) this.m_storeLocation, (object) this.m_storeName);
    }
    set
    {
      this.m_storePath = value;
      if (string.IsNullOrEmpty(this.m_storePath) || !string.IsNullOrEmpty(this.m_storeType))
        return;
      this.m_storeType = CertificateStoreIdentifier.DetermineStoreType(this.m_storePath);
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
  [Obsolete("Use StoreType/StorePath instead")]
  public string StoreName
  {
    get => this.m_storeName;
    set => this.m_storeName = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 3)]
  [Obsolete("Use StoreType/StorePath instead")]
  public string StoreLocation
  {
    get => this.m_storeLocation;
    set => this.m_storeLocation = value;
  }

  [DataMember(Name = "ValidationOptions", IsRequired = false, EmitDefaultValue = false, Order = 4)]
  private int XmlEncodedValidationOptions
  {
    get => (int) this.m_validationOptions;
    set => this.m_validationOptions = (CertificateValidationOptions) value;
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => base.MemberwiseClone();

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (!string.IsNullOrEmpty(format))
      throw new FormatException();
    return this.ToString();
  }

  public override string ToString()
  {
    return string.IsNullOrEmpty(this.StoreType) ? Utils.Format("{0}", (object) this.StorePath) : Utils.Format("[{0}]{1}", (object) this.StoreType, (object) this.StorePath);
  }

  public CertificateValidationOptions ValidationOptions
  {
    get => this.m_validationOptions;
    set => this.m_validationOptions = value;
  }

  public static string DetermineStoreType(string storePath)
  {
    if (string.IsNullOrEmpty(storePath))
      return "Directory";
    if (storePath.StartsWith(CertificateStoreIdentifier.LocalMachine, StringComparison.OrdinalIgnoreCase) || storePath.StartsWith(CertificateStoreIdentifier.CurrentUser, StringComparison.OrdinalIgnoreCase))
      return "X509Store";
    foreach (string registeredStoreTypeName in (IEnumerable<string>) CertificateStoreType.RegisteredStoreTypeNames)
    {
      if (CertificateStoreType.GetCertificateStoreTypeByName(registeredStoreTypeName).SupportsStorePath(storePath))
        return registeredStoreTypeName;
    }
    return "Directory";
  }

  public static ICertificateStore CreateStore(string storeTypeName)
  {
    if (string.IsNullOrEmpty(storeTypeName))
      return (ICertificateStore) new CertificateIdentifierCollection();
    ICertificateStore store;
    switch (storeTypeName)
    {
      case "X509Store":
        store = (ICertificateStore) new X509CertificateStore();
        break;
      case "Directory":
        store = (ICertificateStore) new DirectoryCertificateStore();
        break;
      default:
        store = (CertificateStoreType.GetCertificateStoreTypeByName(storeTypeName) ?? throw new ArgumentException("Invalid store type name: " + storeTypeName)).CreateStore();
        break;
    }
    return store;
  }

  public virtual ICertificateStore OpenStore()
  {
    ICertificateStore store = CertificateStoreIdentifier.CreateStore(this.StoreType);
    store.Open(this.StorePath);
    return store;
  }

  public static ICertificateStore OpenStore(string path)
  {
    ICertificateStore store = CertificateStoreIdentifier.CreateStore(CertificateStoreIdentifier.DetermineStoreType(path));
    store.Open(path);
    return store;
  }
}
