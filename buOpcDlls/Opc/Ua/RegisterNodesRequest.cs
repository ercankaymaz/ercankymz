// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterNodesRequest
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
public class RegisterNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private NodeIdCollection m_nodesToRegister;

  public RegisterNodesRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_nodesToRegister = new NodeIdCollection();
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

  [DataMember(Name = "NodesToRegister", IsRequired = false, Order = 2)]
  public NodeIdCollection NodesToRegister
  {
    get => this.m_nodesToRegister;
    set
    {
      this.m_nodesToRegister = value;
      if (value != null)
        return;
      this.m_nodesToRegister = new NodeIdCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RegisterNodesRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterNodesRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterNodesRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterNodesRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteNodeIdArray("NodesToRegister", (IList<NodeId>) this.NodesToRegister);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.NodesToRegister = decoder.ReadNodeIdArray("NodesToRegister");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RegisterNodesRequest registerNodesRequest && Utils.IsEqual((object) this.m_requestHeader, (object) registerNodesRequest.m_requestHeader) && Utils.IsEqual((object) this.m_nodesToRegister, (object) registerNodesRequest.m_nodesToRegister);
  }

  public virtual object Clone() => (object) (RegisterNodesRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RegisterNodesRequest registerNodesRequest = (RegisterNodesRequest) base.MemberwiseClone();
    registerNodesRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    registerNodesRequest.m_nodesToRegister = (NodeIdCollection) Utils.Clone((object) this.m_nodesToRegister);
    return (object) registerNodesRequest;
  }
}
