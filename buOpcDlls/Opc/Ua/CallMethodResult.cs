// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CallMethodResult
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
public class CallMethodResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private StatusCodeCollection m_inputArgumentResults;
  private DiagnosticInfoCollection m_inputArgumentDiagnosticInfos;
  private VariantCollection m_outputArguments;

  public CallMethodResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_inputArgumentResults = new StatusCodeCollection();
    this.m_inputArgumentDiagnosticInfos = new DiagnosticInfoCollection();
    this.m_outputArguments = new VariantCollection();
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "InputArgumentResults", IsRequired = false, Order = 2)]
  public StatusCodeCollection InputArgumentResults
  {
    get => this.m_inputArgumentResults;
    set
    {
      this.m_inputArgumentResults = value;
      if (value != null)
        return;
      this.m_inputArgumentResults = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "InputArgumentDiagnosticInfos", IsRequired = false, Order = 3)]
  public DiagnosticInfoCollection InputArgumentDiagnosticInfos
  {
    get => this.m_inputArgumentDiagnosticInfos;
    set
    {
      this.m_inputArgumentDiagnosticInfos = value;
      if (value != null)
        return;
      this.m_inputArgumentDiagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  [DataMember(Name = "OutputArguments", IsRequired = false, Order = 4)]
  public VariantCollection OutputArguments
  {
    get => this.m_outputArguments;
    set
    {
      this.m_outputArguments = value;
      if (value != null)
        return;
      this.m_outputArguments = new VariantCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CallMethodResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallMethodResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallMethodResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CallMethodResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteStatusCodeArray("InputArgumentResults", (IList<StatusCode>) this.InputArgumentResults);
    encoder.WriteDiagnosticInfoArray("InputArgumentDiagnosticInfos", (IList<DiagnosticInfo>) this.InputArgumentDiagnosticInfos);
    encoder.WriteVariantArray("OutputArguments", (IList<Variant>) this.OutputArguments);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.InputArgumentResults = decoder.ReadStatusCodeArray("InputArgumentResults");
    this.InputArgumentDiagnosticInfos = decoder.ReadDiagnosticInfoArray("InputArgumentDiagnosticInfos");
    this.OutputArguments = decoder.ReadVariantArray("OutputArguments");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CallMethodResult callMethodResult && Utils.IsEqual((object) this.m_statusCode, (object) callMethodResult.m_statusCode) && Utils.IsEqual((object) this.m_inputArgumentResults, (object) callMethodResult.m_inputArgumentResults) && Utils.IsEqual((object) this.m_inputArgumentDiagnosticInfos, (object) callMethodResult.m_inputArgumentDiagnosticInfos) && Utils.IsEqual((object) this.m_outputArguments, (object) callMethodResult.m_outputArguments);
  }

  public virtual object Clone() => (object) (CallMethodResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CallMethodResult callMethodResult = (CallMethodResult) base.MemberwiseClone();
    callMethodResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    callMethodResult.m_inputArgumentResults = (StatusCodeCollection) Utils.Clone((object) this.m_inputArgumentResults);
    callMethodResult.m_inputArgumentDiagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_inputArgumentDiagnosticInfos);
    callMethodResult.m_outputArguments = (VariantCollection) Utils.Clone((object) this.m_outputArguments);
    return (object) callMethodResult;
  }
}
