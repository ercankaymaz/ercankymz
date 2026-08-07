// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StatusChangeNotification
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class StatusChangeNotification : NotificationData
{
  private StatusCode m_status;
  private DiagnosticInfo m_diagnosticInfo;

  public StatusChangeNotification() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_status = (StatusCode) 0U;
    this.m_diagnosticInfo = (DiagnosticInfo) null;
  }

  [DataMember(Name = "Status", IsRequired = false, Order = 1)]
  public StatusCode Status
  {
    get => this.m_status;
    set => this.m_status = value;
  }

  [DataMember(Name = "DiagnosticInfo", IsRequired = false, Order = 2)]
  public DiagnosticInfo DiagnosticInfo
  {
    get => this.m_diagnosticInfo;
    set => this.m_diagnosticInfo = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.StatusChangeNotification;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StatusChangeNotification_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StatusChangeNotification_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StatusChangeNotification_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("Status", this.Status);
    encoder.WriteDiagnosticInfo("DiagnosticInfo", this.DiagnosticInfo);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Status = decoder.ReadStatusCode("Status");
    this.DiagnosticInfo = decoder.ReadDiagnosticInfo("DiagnosticInfo");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is StatusChangeNotification changeNotification && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_status, (object) changeNotification.m_status) && Utils.IsEqual((object) this.m_diagnosticInfo, (object) changeNotification.m_diagnosticInfo) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (StatusChangeNotification) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StatusChangeNotification changeNotification = (StatusChangeNotification) base.MemberwiseClone();
    changeNotification.m_status = (StatusCode) Utils.Clone((object) this.m_status);
    changeNotification.m_diagnosticInfo = (DiagnosticInfo) Utils.Clone((object) this.m_diagnosticInfo);
    return (object) changeNotification;
  }
}
