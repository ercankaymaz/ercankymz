// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryReadResult
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
public class HistoryReadResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private byte[] m_continuationPoint;
  private ExtensionObject m_historyData;

  public HistoryReadResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_continuationPoint = (byte[]) null;
    this.m_historyData = (ExtensionObject) null;
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 2)]
  public byte[] ContinuationPoint
  {
    get => this.m_continuationPoint;
    set => this.m_continuationPoint = value;
  }

  [DataMember(Name = "HistoryData", IsRequired = false, Order = 3)]
  public ExtensionObject HistoryData
  {
    get => this.m_historyData;
    set => this.m_historyData = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryReadResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteByteString("ContinuationPoint", this.ContinuationPoint);
    encoder.WriteExtensionObject("HistoryData", this.HistoryData);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
    this.HistoryData = decoder.ReadExtensionObject("HistoryData");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryReadResult historyReadResult && Utils.IsEqual((object) this.m_statusCode, (object) historyReadResult.m_statusCode) && Utils.IsEqual((object) this.m_continuationPoint, (object) historyReadResult.m_continuationPoint) && Utils.IsEqual((object) this.m_historyData, (object) historyReadResult.m_historyData);
  }

  public virtual object Clone() => (object) (HistoryReadResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryReadResult historyReadResult = (HistoryReadResult) base.MemberwiseClone();
    historyReadResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    historyReadResult.m_continuationPoint = (byte[]) Utils.Clone((object) this.m_continuationPoint);
    historyReadResult.m_historyData = (ExtensionObject) Utils.Clone((object) this.m_historyData);
    return (object) historyReadResult;
  }
}
