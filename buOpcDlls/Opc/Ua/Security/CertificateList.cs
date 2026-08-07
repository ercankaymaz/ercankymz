// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.CertificateList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "CertificateList", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public class CertificateList : IExtensibleDataObject
{
  private ExtensionDataObject extensionDataField;
  private ListOfCertificateIdentifier CertificatesField;
  private int ValidationOptionsField;

  public ExtensionDataObject ExtensionData
  {
    get => this.extensionDataField;
    set => this.extensionDataField = value;
  }

  [DataMember(EmitDefaultValue = false)]
  public ListOfCertificateIdentifier Certificates
  {
    get => this.CertificatesField;
    set => this.CertificatesField = value;
  }

  [DataMember]
  public int ValidationOptions
  {
    get => this.ValidationOptionsField;
    set => this.ValidationOptionsField = value;
  }
}
