// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.CertificateIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CertificateIdentifier", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public class CertificateIdentifier : IExtensibleDataObject
{
  private ExtensionDataObject extensionDataField;
  private string StoreTypeField;
  private string StorePathField;
  private string SubjectNameField;
  private string ThumbprintField;
  private byte[] RawDataField;
  private int ValidationOptionsField;
  private byte[] OfflineRevocationListField;
  private string OnlineRevocationListField;

  public ExtensionDataObject ExtensionData
  {
    get => this.extensionDataField;
    set => this.extensionDataField = value;
  }

  [DataMember(EmitDefaultValue = false)]
  public string StoreType
  {
    get => this.StoreTypeField;
    set => this.StoreTypeField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 1)]
  public string StorePath
  {
    get => this.StorePathField;
    set => this.StorePathField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 2)]
  public string SubjectName
  {
    get => this.SubjectNameField;
    set => this.SubjectNameField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 3)]
  public string Thumbprint
  {
    get => this.ThumbprintField;
    set => this.ThumbprintField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 4)]
  public byte[] RawData
  {
    get => this.RawDataField;
    set => this.RawDataField = value;
  }

  [DataMember(Order = 5)]
  public int ValidationOptions
  {
    get => this.ValidationOptionsField;
    set => this.ValidationOptionsField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 6)]
  public byte[] OfflineRevocationList
  {
    get => this.OfflineRevocationListField;
    set => this.OfflineRevocationListField = value;
  }

  [DataMember(EmitDefaultValue = false, Order = 7)]
  public string OnlineRevocationList
  {
    get => this.OnlineRevocationListField;
    set => this.OnlineRevocationListField = value;
  }

  public async Task<X509Certificate2> Find()
  {
    return await SecuredApplication.FromCertificateIdentifier(this).Find(false).ConfigureAwait(false);
  }

  public async Task<X509Certificate2> Find(bool needPrivateKey)
  {
    return await SecuredApplication.FromCertificateIdentifier(this).Find(needPrivateKey).ConfigureAwait(false);
  }

  public ICertificateStore OpenStore()
  {
    return SecuredApplication.FromCertificateIdentifier(this).OpenStore();
  }
}
