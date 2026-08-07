// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ParsingResult
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
public class ParsingResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private StatusCodeCollection m_dataStatusCodes;
  private DiagnosticInfoCollection m_dataDiagnosticInfos;

  public ParsingResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_dataStatusCodes = new StatusCodeCollection();
    this.m_dataDiagnosticInfos = new DiagnosticInfoCollection();
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "DataStatusCodes", IsRequired = false, Order = 2)]
  public StatusCodeCollection DataStatusCodes
  {
    get => this.m_dataStatusCodes;
    set
    {
      this.m_dataStatusCodes = value;
      if (value != null)
        return;
      this.m_dataStatusCodes = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "DataDiagnosticInfos", IsRequired = false, Order = 3)]
  public DiagnosticInfoCollection DataDiagnosticInfos
  {
    get => this.m_dataDiagnosticInfos;
    set
    {
      this.m_dataDiagnosticInfos = value;
      if (value != null)
        return;
      this.m_dataDiagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ParsingResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ParsingResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ParsingResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ParsingResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteStatusCodeArray("DataStatusCodes", (IList<StatusCode>) this.DataStatusCodes);
    encoder.WriteDiagnosticInfoArray("DataDiagnosticInfos", (IList<DiagnosticInfo>) this.DataDiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.DataStatusCodes = decoder.ReadStatusCodeArray("DataStatusCodes");
    this.DataDiagnosticInfos = decoder.ReadDiagnosticInfoArray("DataDiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ParsingResult parsingResult && Utils.IsEqual((object) this.m_statusCode, (object) parsingResult.m_statusCode) && Utils.IsEqual((object) this.m_dataStatusCodes, (object) parsingResult.m_dataStatusCodes) && Utils.IsEqual((object) this.m_dataDiagnosticInfos, (object) parsingResult.m_dataDiagnosticInfos);
  }

  public virtual object Clone() => (object) (ParsingResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ParsingResult parsingResult = (ParsingResult) base.MemberwiseClone();
    parsingResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    parsingResult.m_dataStatusCodes = (StatusCodeCollection) Utils.Clone((object) this.m_dataStatusCodes);
    parsingResult.m_dataDiagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_dataDiagnosticInfos);
    return (object) parsingResult;
  }
}
