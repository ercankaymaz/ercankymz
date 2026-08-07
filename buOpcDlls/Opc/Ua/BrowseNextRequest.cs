// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseNextRequest
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
public class BrowseNextRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private bool m_releaseContinuationPoints;
  private ByteStringCollection m_continuationPoints;

  public BrowseNextRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_releaseContinuationPoints = true;
    this.m_continuationPoints = new ByteStringCollection();
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

  [DataMember(Name = "ReleaseContinuationPoints", IsRequired = false, Order = 2)]
  public bool ReleaseContinuationPoints
  {
    get => this.m_releaseContinuationPoints;
    set => this.m_releaseContinuationPoints = value;
  }

  [DataMember(Name = "ContinuationPoints", IsRequired = false, Order = 3)]
  public ByteStringCollection ContinuationPoints
  {
    get => this.m_continuationPoints;
    set
    {
      this.m_continuationPoints = value;
      if (value != null)
        return;
      this.m_continuationPoints = new ByteStringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowseNextRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseNextRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseNextRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseNextRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteBoolean("ReleaseContinuationPoints", this.ReleaseContinuationPoints);
    encoder.WriteByteStringArray("ContinuationPoints", (IList<byte[]>) this.ContinuationPoints);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.ReleaseContinuationPoints = decoder.ReadBoolean("ReleaseContinuationPoints");
    this.ContinuationPoints = decoder.ReadByteStringArray("ContinuationPoints");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowseNextRequest browseNextRequest && Utils.IsEqual((object) this.m_requestHeader, (object) browseNextRequest.m_requestHeader) && Utils.IsEqual((object) this.m_releaseContinuationPoints, (object) browseNextRequest.m_releaseContinuationPoints) && Utils.IsEqual((object) this.m_continuationPoints, (object) browseNextRequest.m_continuationPoints);
  }

  public virtual object Clone() => (object) (BrowseNextRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowseNextRequest browseNextRequest = (BrowseNextRequest) base.MemberwiseClone();
    browseNextRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    browseNextRequest.m_releaseContinuationPoints = (bool) Utils.Clone((object) this.m_releaseContinuationPoints);
    browseNextRequest.m_continuationPoints = (ByteStringCollection) Utils.Clone((object) this.m_continuationPoints);
    return (object) browseNextRequest;
  }
}
