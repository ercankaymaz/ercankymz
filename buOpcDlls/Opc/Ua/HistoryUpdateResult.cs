// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryUpdateResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryUpdateResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private StatusCodeCollection m_operationResults;
  private DiagnosticInfoCollection m_diagnosticInfos;

  public HistoryUpdateResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_operationResults = new StatusCodeCollection();
    this.m_diagnosticInfos = new DiagnosticInfoCollection();
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "OperationResults", IsRequired = false, Order = 2)]
  public StatusCodeCollection OperationResults
  {
    get => this.m_operationResults;
    set
    {
      this.m_operationResults = value;
      if (value != null)
        return;
      this.m_operationResults = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 3)]
  public DiagnosticInfoCollection DiagnosticInfos
  {
    get => this.m_diagnosticInfos;
    set
    {
      this.m_diagnosticInfos = value;
      if (value != null)
        return;
      this.m_diagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryUpdateResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryUpdateResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteStatusCodeArray("OperationResults", (IList<StatusCode>) this.OperationResults);
    encoder.WriteDiagnosticInfoArray("DiagnosticInfos", (IList<DiagnosticInfo>) this.DiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.OperationResults = decoder.ReadStatusCodeArray("OperationResults");
    this.DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryUpdateResult historyUpdateResult && Utils.IsEqual((object) this.m_statusCode, (object) historyUpdateResult.m_statusCode) && Utils.IsEqual((object) this.m_operationResults, (object) historyUpdateResult.m_operationResults) && Utils.IsEqual((object) this.m_diagnosticInfos, (object) historyUpdateResult.m_diagnosticInfos);
  }

  public virtual object Clone() => (object) (HistoryUpdateResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryUpdateResult historyUpdateResult = (HistoryUpdateResult) base.MemberwiseClone();
    historyUpdateResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    historyUpdateResult.m_operationResults = (StatusCodeCollection) Utils.Clone((object) this.m_operationResults);
    historyUpdateResult.m_diagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_diagnosticInfos);
    return (object) historyUpdateResult;
  }
}
