// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TranslateBrowsePathsToNodeIdsRequest
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
public class TranslateBrowsePathsToNodeIdsRequest : 
  IEncodeable,
  ICloneable,
  IJsonEncodeable,
  IServiceRequest
{
  private RequestHeader m_requestHeader;
  private BrowsePathCollection m_browsePaths;

  public TranslateBrowsePathsToNodeIdsRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_browsePaths = new BrowsePathCollection();
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

  [DataMember(Name = "BrowsePaths", IsRequired = false, Order = 2)]
  public BrowsePathCollection BrowsePaths
  {
    get => this.m_browsePaths;
    set
    {
      this.m_browsePaths = value;
      if (value != null)
        return;
      this.m_browsePaths = new BrowsePathCollection();
    }
  }

  public virtual ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.TranslateBrowsePathsToNodeIdsRequest;
  }

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeableArray("BrowsePaths", (IList<IEncodeable>) this.BrowsePaths.ToArray(), typeof (BrowsePath));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.BrowsePaths = (BrowsePathCollection) (BrowsePath[]) decoder.ReadEncodeableArray("BrowsePaths", typeof (BrowsePath));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is TranslateBrowsePathsToNodeIdsRequest toNodeIdsRequest && Utils.IsEqual((object) this.m_requestHeader, (object) toNodeIdsRequest.m_requestHeader) && Utils.IsEqual((object) this.m_browsePaths, (object) toNodeIdsRequest.m_browsePaths);
  }

  public virtual object Clone()
  {
    return (object) (TranslateBrowsePathsToNodeIdsRequest) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    TranslateBrowsePathsToNodeIdsRequest toNodeIdsRequest = (TranslateBrowsePathsToNodeIdsRequest) base.MemberwiseClone();
    toNodeIdsRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    toNodeIdsRequest.m_browsePaths = (BrowsePathCollection) Utils.Clone((object) this.m_browsePaths);
    return (object) toNodeIdsRequest;
  }
}
