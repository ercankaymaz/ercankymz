// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryReadRequest
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
public class HistoryReadRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private ExtensionObject m_historyReadDetails;
  private TimestampsToReturn m_timestampsToReturn;
  private bool m_releaseContinuationPoints;
  private HistoryReadValueIdCollection m_nodesToRead;

  public HistoryReadRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_historyReadDetails = (ExtensionObject) null;
    this.m_timestampsToReturn = TimestampsToReturn.Source;
    this.m_releaseContinuationPoints = true;
    this.m_nodesToRead = new HistoryReadValueIdCollection();
  }

  [DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
  public RequestHeader RequestHeader
  {
    get => this.m_requestHeader;
    set
    {
      this.m_requestHeader = value;
      if (value != null)
        return;
      this.m_requestHeader = new RequestHeader();
    }
  }

  [DataMember(Name = "HistoryReadDetails", IsRequired = false, Order = 2)]
  public ExtensionObject HistoryReadDetails
  {
    get => this.m_historyReadDetails;
    set => this.m_historyReadDetails = value;
  }

  [DataMember(Name = "TimestampsToReturn", IsRequired = false, Order = 3)]
  public TimestampsToReturn TimestampsToReturn
  {
    get => this.m_timestampsToReturn;
    set => this.m_timestampsToReturn = value;
  }

  [DataMember(Name = "ReleaseContinuationPoints", IsRequired = false, Order = 4)]
  public bool ReleaseContinuationPoints
  {
    get => this.m_releaseContinuationPoints;
    set => this.m_releaseContinuationPoints = value;
  }

  [DataMember(Name = "NodesToRead", IsRequired = false, Order = 5)]
  public HistoryReadValueIdCollection NodesToRead
  {
    get => this.m_nodesToRead;
    set
    {
      this.m_nodesToRead = value;
      if (value != null)
        return;
      this.m_nodesToRead = new HistoryReadValueIdCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryReadRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryReadRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteExtensionObject("HistoryReadDetails", this.HistoryReadDetails);
    encoder.WriteEnumerated("TimestampsToReturn", (Enum) this.TimestampsToReturn);
    encoder.WriteBoolean("ReleaseContinuationPoints", this.ReleaseContinuationPoints);
    encoder.WriteEncodeableArray("NodesToRead", (IList<IEncodeable>) this.NodesToRead.ToArray(), typeof (HistoryReadValueId));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.HistoryReadDetails = decoder.ReadExtensionObject("HistoryReadDetails");
    this.TimestampsToReturn = (TimestampsToReturn) decoder.ReadEnumerated("TimestampsToReturn", typeof (TimestampsToReturn));
    this.ReleaseContinuationPoints = decoder.ReadBoolean("ReleaseContinuationPoints");
    this.NodesToRead = (HistoryReadValueIdCollection) (HistoryReadValueId[]) decoder.ReadEncodeableArray("NodesToRead", typeof (HistoryReadValueId));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryReadRequest historyReadRequest && Utils.IsEqual((object) this.m_requestHeader, (object) historyReadRequest.m_requestHeader) && Utils.IsEqual((object) this.m_historyReadDetails, (object) historyReadRequest.m_historyReadDetails) && Utils.IsEqual((object) this.m_timestampsToReturn, (object) historyReadRequest.m_timestampsToReturn) && Utils.IsEqual((object) this.m_releaseContinuationPoints, (object) historyReadRequest.m_releaseContinuationPoints) && Utils.IsEqual((object) this.m_nodesToRead, (object) historyReadRequest.m_nodesToRead);
  }

  public virtual object Clone() => (object) (HistoryReadRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryReadRequest historyReadRequest = (HistoryReadRequest) base.MemberwiseClone();
    historyReadRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    historyReadRequest.m_historyReadDetails = (ExtensionObject) Utils.Clone((object) this.m_historyReadDetails);
    historyReadRequest.m_timestampsToReturn = (TimestampsToReturn) Utils.Clone((object) this.m_timestampsToReturn);
    historyReadRequest.m_releaseContinuationPoints = (bool) Utils.Clone((object) this.m_releaseContinuationPoints);
    historyReadRequest.m_nodesToRead = (HistoryReadValueIdCollection) Utils.Clone((object) this.m_nodesToRead);
    return (object) historyReadRequest;
  }
}
