// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GetEndpointsRequest
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
public class GetEndpointsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private string m_endpointUrl;
  private StringCollection m_localeIds;
  private StringCollection m_profileUris;

  public GetEndpointsRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_endpointUrl = (string) null;
    this.m_localeIds = new StringCollection();
    this.m_profileUris = new StringCollection();
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

  [DataMember(Name = "EndpointUrl", IsRequired = false, Order = 2)]
  public string EndpointUrl
  {
    get => this.m_endpointUrl;
    set => this.m_endpointUrl = value;
  }

  [DataMember(Name = "LocaleIds", IsRequired = false, Order = 3)]
  public StringCollection LocaleIds
  {
    get => this.m_localeIds;
    set
    {
      this.m_localeIds = value;
      if (value != null)
        return;
      this.m_localeIds = new StringCollection();
    }
  }

  [DataMember(Name = "ProfileUris", IsRequired = false, Order = 4)]
  public StringCollection ProfileUris
  {
    get => this.m_profileUris;
    set
    {
      this.m_profileUris = value;
      if (value != null)
        return;
      this.m_profileUris = new StringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.GetEndpointsRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GetEndpointsRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GetEndpointsRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GetEndpointsRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteString("EndpointUrl", this.EndpointUrl);
    encoder.WriteStringArray("LocaleIds", (IList<string>) this.LocaleIds);
    encoder.WriteStringArray("ProfileUris", (IList<string>) this.ProfileUris);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.EndpointUrl = decoder.ReadString("EndpointUrl");
    this.LocaleIds = decoder.ReadStringArray("LocaleIds");
    this.ProfileUris = decoder.ReadStringArray("ProfileUris");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is GetEndpointsRequest endpointsRequest && Utils.IsEqual((object) this.m_requestHeader, (object) endpointsRequest.m_requestHeader) && Utils.IsEqual((object) this.m_endpointUrl, (object) endpointsRequest.m_endpointUrl) && Utils.IsEqual((object) this.m_localeIds, (object) endpointsRequest.m_localeIds) && Utils.IsEqual((object) this.m_profileUris, (object) endpointsRequest.m_profileUris);
  }

  public virtual object Clone() => (object) (GetEndpointsRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    GetEndpointsRequest endpointsRequest = (GetEndpointsRequest) base.MemberwiseClone();
    endpointsRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    endpointsRequest.m_endpointUrl = (string) Utils.Clone((object) this.m_endpointUrl);
    endpointsRequest.m_localeIds = (StringCollection) Utils.Clone((object) this.m_localeIds);
    endpointsRequest.m_profileUris = (StringCollection) Utils.Clone((object) this.m_profileUris);
    return (object) endpointsRequest;
  }
}
