// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ContentFilterElementResult
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
public class ContentFilterElementResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private StatusCodeCollection m_operandStatusCodes;
  private DiagnosticInfoCollection m_operandDiagnosticInfos;

  public ContentFilterElementResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_operandStatusCodes = new StatusCodeCollection();
    this.m_operandDiagnosticInfos = new DiagnosticInfoCollection();
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "OperandStatusCodes", IsRequired = false, Order = 2)]
  public StatusCodeCollection OperandStatusCodes
  {
    get => this.m_operandStatusCodes;
    set
    {
      this.m_operandStatusCodes = value;
      if (value != null)
        return;
      this.m_operandStatusCodes = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "OperandDiagnosticInfos", IsRequired = false, Order = 3)]
  public DiagnosticInfoCollection OperandDiagnosticInfos
  {
    get => this.m_operandDiagnosticInfos;
    set
    {
      this.m_operandDiagnosticInfos = value;
      if (value != null)
        return;
      this.m_operandDiagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ContentFilterElementResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterElementResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterElementResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterElementResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteStatusCodeArray("OperandStatusCodes", (IList<StatusCode>) this.OperandStatusCodes);
    encoder.WriteDiagnosticInfoArray("OperandDiagnosticInfos", (IList<DiagnosticInfo>) this.OperandDiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.OperandStatusCodes = decoder.ReadStatusCodeArray("OperandStatusCodes");
    this.OperandDiagnosticInfos = decoder.ReadDiagnosticInfoArray("OperandDiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ContentFilterElementResult filterElementResult && Utils.IsEqual((object) this.m_statusCode, (object) filterElementResult.m_statusCode) && Utils.IsEqual((object) this.m_operandStatusCodes, (object) filterElementResult.m_operandStatusCodes) && Utils.IsEqual((object) this.m_operandDiagnosticInfos, (object) filterElementResult.m_operandDiagnosticInfos);
  }

  public virtual object Clone() => (object) (ContentFilterElementResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ContentFilterElementResult filterElementResult = (ContentFilterElementResult) base.MemberwiseClone();
    filterElementResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    filterElementResult.m_operandStatusCodes = (StatusCodeCollection) Utils.Clone((object) this.m_operandStatusCodes);
    filterElementResult.m_operandDiagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_operandDiagnosticInfos);
    return (object) filterElementResult;
  }
}
