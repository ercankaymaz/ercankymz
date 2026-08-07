// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadRequest
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
public class ReadRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private double m_maxAge;
  private TimestampsToReturn m_timestampsToReturn;
  private ReadValueIdCollection m_nodesToRead;

  public ReadRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_maxAge = 0.0;
    this.m_timestampsToReturn = TimestampsToReturn.Source;
    this.m_nodesToRead = new ReadValueIdCollection();
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

  [DataMember(Name = "MaxAge", IsRequired = false, Order = 2)]
  public double MaxAge
  {
    get => this.m_maxAge;
    set => this.m_maxAge = value;
  }

  [DataMember(Name = "TimestampsToReturn", IsRequired = false, Order = 3)]
  public TimestampsToReturn TimestampsToReturn
  {
    get => this.m_timestampsToReturn;
    set => this.m_timestampsToReturn = value;
  }

  [DataMember(Name = "NodesToRead", IsRequired = false, Order = 4)]
  public ReadValueIdCollection NodesToRead
  {
    get => this.m_nodesToRead;
    set
    {
      this.m_nodesToRead = value;
      if (value != null)
        return;
      this.m_nodesToRead = new ReadValueIdCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReadRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteDouble("MaxAge", this.MaxAge);
    encoder.WriteEnumerated("TimestampsToReturn", (Enum) this.TimestampsToReturn);
    encoder.WriteEncodeableArray("NodesToRead", (IList<IEncodeable>) this.NodesToRead.ToArray(), typeof (ReadValueId));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.MaxAge = decoder.ReadDouble("MaxAge");
    this.TimestampsToReturn = (TimestampsToReturn) decoder.ReadEnumerated("TimestampsToReturn", typeof (TimestampsToReturn));
    this.NodesToRead = (ReadValueIdCollection) (ReadValueId[]) decoder.ReadEncodeableArray("NodesToRead", typeof (ReadValueId));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ReadRequest readRequest && Utils.IsEqual((object) this.m_requestHeader, (object) readRequest.m_requestHeader) && Utils.IsEqual((object) this.m_maxAge, (object) readRequest.m_maxAge) && Utils.IsEqual((object) this.m_timestampsToReturn, (object) readRequest.m_timestampsToReturn) && Utils.IsEqual((object) this.m_nodesToRead, (object) readRequest.m_nodesToRead);
  }

  public virtual object Clone() => (object) (ReadRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadRequest readRequest = (ReadRequest) base.MemberwiseClone();
    readRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    readRequest.m_maxAge = (double) Utils.Clone((object) this.m_maxAge);
    readRequest.m_timestampsToReturn = (TimestampsToReturn) Utils.Clone((object) this.m_timestampsToReturn);
    readRequest.m_nodesToRead = (ReadValueIdCollection) Utils.Clone((object) this.m_nodesToRead);
    return (object) readRequest;
  }
}
