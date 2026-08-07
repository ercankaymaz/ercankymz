// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryNextRequest
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
public class QueryNextRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private bool m_releaseContinuationPoint;
  private byte[] m_continuationPoint;

  public QueryNextRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_releaseContinuationPoint = true;
    this.m_continuationPoint = (byte[]) null;
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

  [DataMember(Name = "ReleaseContinuationPoint", IsRequired = false, Order = 2)]
  public bool ReleaseContinuationPoint
  {
    get => this.m_releaseContinuationPoint;
    set => this.m_releaseContinuationPoint = value;
  }

  [DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 3)]
  public byte[] ContinuationPoint
  {
    get => this.m_continuationPoint;
    set => this.m_continuationPoint = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.QueryNextRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryNextRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryNextRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryNextRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteBoolean("ReleaseContinuationPoint", this.ReleaseContinuationPoint);
    encoder.WriteByteString("ContinuationPoint", this.ContinuationPoint);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.ReleaseContinuationPoint = decoder.ReadBoolean("ReleaseContinuationPoint");
    this.ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is QueryNextRequest queryNextRequest && Utils.IsEqual((object) this.m_requestHeader, (object) queryNextRequest.m_requestHeader) && Utils.IsEqual((object) this.m_releaseContinuationPoint, (object) queryNextRequest.m_releaseContinuationPoint) && Utils.IsEqual((object) this.m_continuationPoint, (object) queryNextRequest.m_continuationPoint);
  }

  public virtual object Clone() => (object) (QueryNextRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryNextRequest queryNextRequest = (QueryNextRequest) base.MemberwiseClone();
    queryNextRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    queryNextRequest.m_releaseContinuationPoint = (bool) Utils.Clone((object) this.m_releaseContinuationPoint);
    queryNextRequest.m_continuationPoint = (byte[]) Utils.Clone((object) this.m_continuationPoint);
    return (object) queryNextRequest;
  }
}
