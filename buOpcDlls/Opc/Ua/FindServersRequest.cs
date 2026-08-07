// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FindServersRequest
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
public class FindServersRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private string m_endpointUrl;
  private StringCollection m_localeIds;
  private StringCollection m_serverUris;

  public FindServersRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_endpointUrl = (string) null;
    this.m_localeIds = new StringCollection();
    this.m_serverUris = new StringCollection();
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

  [DataMember(Name = "ServerUris", IsRequired = false, Order = 4)]
  public StringCollection ServerUris
  {
    get => this.m_serverUris;
    set
    {
      this.m_serverUris = value;
      if (value != null)
        return;
      this.m_serverUris = new StringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.FindServersRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteString("EndpointUrl", this.EndpointUrl);
    encoder.WriteStringArray("LocaleIds", (IList<string>) this.LocaleIds);
    encoder.WriteStringArray("ServerUris", (IList<string>) this.ServerUris);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.EndpointUrl = decoder.ReadString("EndpointUrl");
    this.LocaleIds = decoder.ReadStringArray("LocaleIds");
    this.ServerUris = decoder.ReadStringArray("ServerUris");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is FindServersRequest findServersRequest && Utils.IsEqual((object) this.m_requestHeader, (object) findServersRequest.m_requestHeader) && Utils.IsEqual((object) this.m_endpointUrl, (object) findServersRequest.m_endpointUrl) && Utils.IsEqual((object) this.m_localeIds, (object) findServersRequest.m_localeIds) && Utils.IsEqual((object) this.m_serverUris, (object) findServersRequest.m_serverUris);
  }

  public virtual object Clone() => (object) (FindServersRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FindServersRequest findServersRequest = (FindServersRequest) base.MemberwiseClone();
    findServersRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    findServersRequest.m_endpointUrl = (string) Utils.Clone((object) this.m_endpointUrl);
    findServersRequest.m_localeIds = (StringCollection) Utils.Clone((object) this.m_localeIds);
    findServersRequest.m_serverUris = (StringCollection) Utils.Clone((object) this.m_serverUris);
    return (object) findServersRequest;
  }
}
