// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class CertificateIdentifier : IFormattable
{
  private string m_storeType;
  private string m_storePath;
  private string m_storeLocation;
  private string m_storeName;
  private string m_subjectName;
  private string m_thumbprint;
  private X509Certificate2 m_certificate;
  private CertificateValidationOptions m_validationOptions;

  public CertificateIdentifier() => this.Initialize();

  public CertificateIdentifier(X509Certificate2 certificate)
  {
    this.Initialize();
    this.m_certificate = certificate;
  }

  public CertificateIdentifier(
    X509Certificate2 certificate,
    CertificateValidationOptions validationOptions)
  {
    this.Initialize();
    this.m_certificate = certificate;
    this.m_validationOptions = validationOptions;
  }

  public CertificateIdentifier(byte[] rawData)
  {
    this.Initialize();
    this.m_certificate = CertificateFactory.Create(rawData, true);
  }

  private void Initialize()
  {
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

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
      return string.IsNullOrEmpty(this.m_storeLocation) ? Utils.Format("LocalMachine\\{0}", (object) this.m_storeName) : Utils.Format("{0}\\{1}", (object) this.m_storeLocation, (object) this.m_storeName);
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

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 4)]
  public string SubjectName
  {
    get => this.m_certificate == null ? this.m_subjectName : this.m_certificate.Subject;
    set
    {
      if (this.m_certificate != null && !string.IsNullOrEmpty(value) && this.m_certificate.Subject != value)
        throw new ArgumentException("SubjectName does not match the SubjectName of the current certificate.");
      this.m_subjectName = value;
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 5)]
  public string Thumbprint
  {
    get => this.m_certificate == null ? this.m_thumbprint : this.m_certificate.Thumbprint;
    set
    {
      if (this.m_certificate != null && !string.IsNullOrEmpty(value) && this.m_certificate.Thumbprint != value)
        throw new ArgumentException("Thumbprint does not match the thumbprint of the current certificate.");
      this.m_thumbprint = value;
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 6)]
  public byte[] RawData
  {
    get => this.m_certificate == null ? (byte[]) null : this.m_certificate.RawData;
    set
    {
      if (value != null && value.Length != 0)
      {
        this.m_certificate = CertificateFactory.Create(value, true);
        this.m_subjectName = this.m_certificate.Subject;
        this.m_thumbprint = this.m_certificate.Thumbprint;
      }
      else
        this.m_certificate = (X509Certificate2) null;
    }
  }

  [DataMember(Name = "ValidationOptions", IsRequired = false, EmitDefaultValue = false, Order = 7)]
  private int XmlEncodedValidationOptions
  {
    get => (int) this.m_validationOptions;
    set => this.m_validationOptions = (CertificateValidationOptions) value;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (!string.IsNullOrEmpty(format))
      throw new FormatException();
    return this.ToString();
  }

  public override string ToString()
  {
    if (this.m_certificate != null)
      return CertificateIdentifier.GetDisplayName(this.m_certificate);
    return this.m_subjectName != null ? this.m_subjectName : this.m_thumbprint;
  }

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    if (!(obj is CertificateIdentifier certificateIdentifier))
      return false;
    if (this.m_certificate != null && certificateIdentifier.m_certificate != null)
      return this.m_certificate.Thumbprint == certificateIdentifier.m_certificate.Thumbprint;
    return this.Thumbprint == certificateIdentifier.Thumbprint || !(this.m_storeLocation != certificateIdentifier.m_storeLocation) && !(this.m_storeName != certificateIdentifier.m_storeName) && !(this.SubjectName != certificateIdentifier.SubjectName);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<string, string, string, string>(this.Thumbprint, this.m_storeLocation, this.m_storeName, this.SubjectName);
  }

  public CertificateValidationOptions ValidationOptions
  {
    get => this.m_validationOptions;
    set => this.m_validationOptions = value;
  }

  public X509Certificate2 Certificate
  {
    get => this.m_certificate;
    set => this.m_certificate = value;
  }

  public Task<X509Certificate2> Find() => this.Find(false);

  public Task<X509Certificate2> LoadPrivateKey(string password)
  {
    return this.LoadPrivateKeyEx(password != null ? (ICertificatePasswordProvider) new CertificatePasswordProvider(password) : (ICertificatePasswordProvider) null);
  }

  public async Task<X509Certificate2> LoadPrivateKeyEx(ICertificatePasswordProvider passwordProvider)
  {
    CertificateIdentifier certificateIdentifier = this;
    if (certificateIdentifier.StoreType != "X509Store")
    {
      using (ICertificateStore store = CertificateStoreIdentifier.CreateStore(certificateIdentifier.StoreType))
      {
        if (store.SupportsLoadPrivateKey)
        {
          store.Open(certificateIdentifier.StorePath, false);
          string password = passwordProvider?.GetPassword(certificateIdentifier);
          X509Certificate2 x509Certificate2 = await store.LoadPrivateKey(certificateIdentifier.Thumbprint, certificateIdentifier.SubjectName, password).ConfigureAwait(false);
          certificateIdentifier.m_certificate = x509Certificate2;
          return certificateIdentifier.m_certificate;
        }
      }
    }
    return await certificateIdentifier.Find(true).ConfigureAwait(false);
  }

  public async Task<X509Certificate2> Find(bool needPrivateKey)
  {
    X509Certificate2 certificate = (X509Certificate2) null;
    if (this.m_certificate != null && (!needPrivateKey || this.m_certificate.HasPrivateKey))
    {
      certificate = this.m_certificate;
    }
    else
    {
      using (ICertificateStore store = CertificateStoreIdentifier.CreateStore(this.StoreType))
      {
        store.Open(this.StorePath, false);
        certificate = CertificateIdentifier.Find(await store.Enumerate().ConfigureAwait(false), this.m_thumbprint, this.m_subjectName, needPrivateKey);
        if (certificate != null)
        {
          if (needPrivateKey && store.SupportsLoadPrivateKey)
          {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Loaded a certificate with private key from store {0}.");
            stringBuilder.AppendLine("Ensure to call LoadPrivateKeyEx with password provider before calling Find(true).");
            Utils.LogWarning(stringBuilder.ToString(), (object) this.StoreType);
          }
          this.m_certificate = certificate;
        }
      }
    }
    if (needPrivateKey)
      certificate = this.m_certificate = CertificateFactory.Load(certificate, true);
    return certificate;
  }

  private void Paste(CertificateIdentifier certificate)
  {
    this.SubjectName = certificate.SubjectName;
    this.Thumbprint = certificate.Thumbprint;
    this.RawData = certificate.RawData;
    this.ValidationOptions = certificate.ValidationOptions;
    this.Certificate = certificate.Certificate;
  }

  private static string GetDisplayName(X509Certificate2 certificate)
  {
    if (!string.IsNullOrEmpty(certificate.FriendlyName))
      return certificate.FriendlyName;
    string subject = certificate.Subject;
    int num = subject.IndexOf("CN", StringComparison.Ordinal);
    if (num == -1)
      return subject;
    StringBuilder stringBuilder = new StringBuilder(subject.Length);
    for (int index = num + 2; index < subject.Length; ++index)
    {
      if (subject[index] == '=')
      {
        num = index + 1;
        break;
      }
    }
    for (int index = num; index < subject.Length; ++index)
    {
      if (!char.IsWhiteSpace(subject[index]))
      {
        num = index;
        break;
      }
    }
    for (int index = num; index < subject.Length && subject[index] != ','; ++index)
      stringBuilder.Append(subject[index]);
    return stringBuilder.ToString();
  }

  public static X509Certificate2 Find(
    X509Certificate2Collection collection,
    string thumbprint,
    string subjectName,
    bool needPrivateKey)
  {
    if (!string.IsNullOrEmpty(thumbprint))
    {
      collection = collection.Find(X509FindType.FindByThumbprint, (object) thumbprint, false);
      foreach (X509Certificate2 certificate in collection)
      {
        if (!needPrivateKey || certificate.HasPrivateKey)
        {
          if (string.IsNullOrEmpty(subjectName))
            return certificate;
          List<string> distinguishedName = X509Utils.ParseDistinguishedName(subjectName);
          if (X509Utils.CompareDistinguishedName(certificate, distinguishedName))
            return certificate;
        }
      }
      return (X509Certificate2) null;
    }
    if (!string.IsNullOrEmpty(subjectName))
    {
      List<string> distinguishedName = X509Utils.ParseDistinguishedName(subjectName);
      foreach (X509Certificate2 certificate in collection)
      {
        if (X509Utils.CompareDistinguishedName(certificate, distinguishedName) && (!needPrivateKey || certificate.HasPrivateKey) && X509Utils.GetRSAPublicKeySize(certificate) >= 0)
          return certificate;
      }
      collection = collection.Find(X509FindType.FindBySubjectName, (object) subjectName, false);
      foreach (X509Certificate2 certificate in collection)
      {
        if ((!needPrivateKey || certificate.HasPrivateKey) && X509Utils.GetRSAPublicKeySize(certificate) >= 0)
          return certificate;
      }
    }
    return (X509Certificate2) null;
  }

  public static byte[] CreateBlob(IList<X509Certificate2> certificates)
  {
    byte[] sourceArray1 = certificates != null && certificates.Count != 0 ? certificates[0].RawData : throw new CryptographicException("Primary certificate has not been provided.");
    if (certificates.Count > 1)
    {
      List<byte[]> numArrayList = new List<byte[]>(certificates.Count - 1);
      int length1 = sourceArray1.Length;
      for (int index = 1; index < certificates.Count; ++index)
      {
        byte[] rawData = certificates[index].RawData;
        length1 += rawData.Length;
        numArrayList.Add(rawData);
      }
      byte[] destinationArray = new byte[length1];
      Array.Copy((Array) sourceArray1, (Array) destinationArray, sourceArray1.Length);
      int length2 = sourceArray1.Length;
      for (int index = 0; index < numArrayList.Count; ++index)
      {
        byte[] sourceArray2 = numArrayList[index];
        Array.Copy((Array) sourceArray2, 0, (Array) destinationArray, length2, sourceArray2.Length);
        length2 += sourceArray2.Length;
      }
      sourceArray1 = destinationArray;
    }
    return sourceArray1;
  }

  public static X509Certificate2Collection ParseBlob(byte[] encodedData)
  {
    if (!CertificateIdentifier.IsValidCertificateBlob(encodedData))
      throw new CryptographicException("Primary certificate in blob is not valid.");
    X509Certificate2Collection blob = new X509Certificate2Collection();
    X509Certificate2 certificate1 = CertificateFactory.Create(encodedData, true);
    blob.Add(certificate1);
    int length = certificate1.RawData.Length;
    if (encodedData.Length < length)
    {
      byte[] numArray = new byte[encodedData.Length - length];
      do
      {
        Array.Copy((Array) encodedData, length, (Array) numArray, 0, encodedData.Length - length);
        if (CertificateIdentifier.IsValidCertificateBlob(numArray))
        {
          X509Certificate2 certificate2 = CertificateFactory.Create(numArray, true);
          blob.Add(certificate2);
          byte[] rawData = certificate2.RawData;
          length += rawData.Length;
        }
        else
          goto label_6;
      }
      while (length < encodedData.Length);
      goto label_7;
label_6:
      throw new CryptographicException("Supporting certificate in blob is not valid.");
    }
label_7:
    return blob;
  }

  public ICertificateStore OpenStore()
  {
    ICertificateStore store = CertificateStoreIdentifier.CreateStore(this.StoreType);
    store.Open(this.StorePath, false);
    return store;
  }

  private static bool IsValidCertificateBlob(byte[] rawData)
  {
    if (rawData == null || rawData.Length < 4 || rawData[0] != (byte) 48 /*0x30*/)
      return false;
    byte num1 = rawData[1];
    if (((int) num1 & 128 /*0x80*/) == 0)
      return 2 + ((int) num1 & (int) sbyte.MaxValue) >= rawData.Length;
    int num2 = (int) num1 & (int) sbyte.MaxValue;
    if (rawData.Length <= 2 + num2 || ((int) rawData[2] & 128 /*0x80*/) != 0)
      return false;
    int num3 = (int) rawData[2];
    for (int index = 0; index < num2 - 1; ++index)
      num3 = num3 << 8 | (int) rawData[index + 3];
    return 2 + num2 + num3 <= rawData.Length;
  }
}
