// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GetEndpointsResponse
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
public class GetEndpointsResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private EndpointDescriptionCollection m_endpoints;

  public GetEndpointsResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_endpoints = new EndpointDescriptionCollection();
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

  [DataMember(Name = "Endpoints", IsRequired = false, Order = 2)]
  public EndpointDescriptionCollection Endpoints
  {
    get => this.m_endpoints;
    set
    {
      this.m_endpoints = value;
      if (value != null)
        return;
      this.m_endpoints = new EndpointDescriptionCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.GetEndpointsResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GetEndpointsResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GetEndpointsResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GetEndpointsResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteEncodeableArray("Endpoints", (IList<IEncodeable>) this.Endpoints.ToArray(), typeof (EndpointDescription));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.Endpoints = (EndpointDescriptionCollection) (EndpointDescription[]) decoder.ReadEncodeableArray("Endpoints", typeof (EndpointDescription));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is GetEndpointsResponse endpointsResponse && Utils.IsEqual((object) this.m_responseHeader, (object) endpointsResponse.m_responseHeader) && Utils.IsEqual((object) this.m_endpoints, (object) endpointsResponse.m_endpoints);
  }

  public virtual object Clone() => (object) (GetEndpointsResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    GetEndpointsResponse endpointsResponse = (GetEndpointsResponse) base.MemberwiseClone();
    endpointsResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    endpointsResponse.m_endpoints = (EndpointDescriptionCollection) Utils.Clone((object) this.m_endpoints);
    return (object) endpointsResponse;
  }
}
