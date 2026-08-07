// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StatusResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class StatusResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private DiagnosticInfo m_diagnosticInfo;
  private ServiceResult m_result;

  public StatusResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_diagnosticInfo = (DiagnosticInfo) null;
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "DiagnosticInfo", IsRequired = false, Order = 2)]
  public DiagnosticInfo DiagnosticInfo
  {
    get => this.m_diagnosticInfo;
    set => this.m_diagnosticInfo = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.StatusResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StatusResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StatusResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StatusResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteDiagnosticInfo("DiagnosticInfo", this.DiagnosticInfo);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.DiagnosticInfo = decoder.ReadDiagnosticInfo("DiagnosticInfo");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is StatusResult statusResult && Utils.IsEqual((object) this.m_statusCode, (object) statusResult.m_statusCode) && Utils.IsEqual((object) this.m_diagnosticInfo, (object) statusResult.m_diagnosticInfo);
  }

  public virtual object Clone() => (object) (StatusResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StatusResult statusResult = (StatusResult) base.MemberwiseClone();
    statusResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    statusResult.m_diagnosticInfo = (DiagnosticInfo) Utils.Clone((object) this.m_diagnosticInfo);
    return (object) statusResult;
  }

  public StatusResult(ServiceResult result)
  {
    this.Initialize();
    this.m_result = result;
    if (result == null)
      return;
    this.m_statusCode = result.StatusCode;
  }

  public void ApplyDiagnosticMasks(DiagnosticsMasks diagnosticMasks, StringTable stringTable)
  {
    if (this.m_result == null)
      return;
    this.m_statusCode = this.m_result.StatusCode;
    this.m_diagnosticInfo = new DiagnosticInfo(this.m_result, diagnosticMasks, false, stringTable);
  }
}
