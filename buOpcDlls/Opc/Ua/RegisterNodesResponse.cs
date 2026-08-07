// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterNodesResponse
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
public class RegisterNodesResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private NodeIdCollection m_registeredNodeIds;

  public RegisterNodesResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_registeredNodeIds = new NodeIdCollection();
  }

  [DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
  public ResponseHeader ResponseHeader
  {
    get => this.m_responseHeader;
    set
    {
      this.m_responseHeader = value;
      if (value != null)
        return;
      this.m_responseHeader = new ResponseHeader();
    }
  }

  [DataMember(Name = "RegisteredNodeIds", IsRequired = false, Order = 2)]
  public NodeIdCollection RegisteredNodeIds
  {
    get => this.m_registeredNodeIds;
    set
    {
      this.m_registeredNodeIds = value;
      if (value != null)
        return;
      this.m_registeredNodeIds = new NodeIdCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RegisterNodesResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterNodesResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterNodesResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterNodesResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteNodeIdArray("RegisteredNodeIds", (IList<NodeId>) this.RegisteredNodeIds);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.RegisteredNodeIds = decoder.ReadNodeIdArray("RegisteredNodeIds");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RegisterNodesResponse registerNodesResponse && Utils.IsEqual((object) this.m_responseHeader, (object) registerNodesResponse.m_responseHeader) && Utils.IsEqual((object) this.m_registeredNodeIds, (object) registerNodesResponse.m_registeredNodeIds);
  }

  public virtual object Clone() => (object) (RegisterNodesResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RegisterNodesResponse registerNodesResponse = (RegisterNodesResponse) base.MemberwiseClone();
    registerNodesResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    registerNodesResponse.m_registeredNodeIds = (NodeIdCollection) Utils.Clone((object) this.m_registeredNodeIds);
    return (object) registerNodesResponse;
  }
}
