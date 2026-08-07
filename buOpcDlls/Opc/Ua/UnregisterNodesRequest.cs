// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UnregisterNodesRequest
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
public class UnregisterNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private NodeIdCollection m_nodesToUnregister;

  public UnregisterNodesRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_nodesToUnregister = new NodeIdCollection();
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

  [DataMember(Name = "NodesToUnregister", IsRequired = false, Order = 2)]
  public NodeIdCollection NodesToUnregister
  {
    get => this.m_nodesToUnregister;
    set
    {
      this.m_nodesToUnregister = value;
      if (value != null)
        return;
      this.m_nodesToUnregister = new NodeIdCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UnregisterNodesRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UnregisterNodesRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UnregisterNodesRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UnregisterNodesRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteNodeIdArray("NodesToUnregister", (IList<NodeId>) this.NodesToUnregister);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.NodesToUnregister = decoder.ReadNodeIdArray("NodesToUnregister");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is UnregisterNodesRequest unregisterNodesRequest && Utils.IsEqual((object) this.m_requestHeader, (object) unregisterNodesRequest.m_requestHeader) && Utils.IsEqual((object) this.m_nodesToUnregister, (object) unregisterNodesRequest.m_nodesToUnregister);
  }

  public virtual object Clone() => (object) (UnregisterNodesRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UnregisterNodesRequest unregisterNodesRequest = (UnregisterNodesRequest) base.MemberwiseClone();
    unregisterNodesRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    unregisterNodesRequest.m_nodesToUnregister = (NodeIdCollection) Utils.Clone((object) this.m_nodesToUnregister);
    return (object) unregisterNodesRequest;
  }
}
