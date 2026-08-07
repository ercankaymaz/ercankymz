// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FindServersOnNetworkRequest
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
public class FindServersOnNetworkRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_startingRecordId;
  private uint m_maxRecordsToReturn;
  private StringCollection m_serverCapabilityFilter;

  public FindServersOnNetworkRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_startingRecordId = 0U;
    this.m_maxRecordsToReturn = 0U;
    this.m_serverCapabilityFilter = new StringCollection();
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

  [DataMember(Name = "StartingRecordId", IsRequired = false, Order = 2)]
  public uint StartingRecordId
  {
    get => this.m_startingRecordId;
    set => this.m_startingRecordId = value;
  }

  [DataMember(Name = "MaxRecordsToReturn", IsRequired = false, Order = 3)]
  public uint MaxRecordsToReturn
  {
    get => this.m_maxRecordsToReturn;
    set => this.m_maxRecordsToReturn = value;
  }

  [DataMember(Name = "ServerCapabilityFilter", IsRequired = false, Order = 4)]
  public StringCollection ServerCapabilityFilter
  {
    get => this.m_serverCapabilityFilter;
    set
    {
      this.m_serverCapabilityFilter = value;
      if (value != null)
        return;
      this.m_serverCapabilityFilter = new StringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.FindServersOnNetworkRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersOnNetworkRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("StartingRecordId", this.StartingRecordId);
    encoder.WriteUInt32("MaxRecordsToReturn", this.MaxRecordsToReturn);
    encoder.WriteStringArray("ServerCapabilityFilter", (IList<string>) this.ServerCapabilityFilter);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.StartingRecordId = decoder.ReadUInt32("StartingRecordId");
    this.MaxRecordsToReturn = decoder.ReadUInt32("MaxRecordsToReturn");
    this.ServerCapabilityFilter = decoder.ReadStringArray("ServerCapabilityFilter");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is FindServersOnNetworkRequest onNetworkRequest && Utils.IsEqual((object) this.m_requestHeader, (object) onNetworkRequest.m_requestHeader) && Utils.IsEqual((object) this.m_startingRecordId, (object) onNetworkRequest.m_startingRecordId) && Utils.IsEqual((object) this.m_maxRecordsToReturn, (object) onNetworkRequest.m_maxRecordsToReturn) && Utils.IsEqual((object) this.m_serverCapabilityFilter, (object) onNetworkRequest.m_serverCapabilityFilter);
  }

  public virtual object Clone() => (object) (FindServersOnNetworkRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FindServersOnNetworkRequest onNetworkRequest = (FindServersOnNetworkRequest) base.MemberwiseClone();
    onNetworkRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    onNetworkRequest.m_startingRecordId = (uint) Utils.Clone((object) this.m_startingRecordId);
    onNetworkRequest.m_maxRecordsToReturn = (uint) Utils.Clone((object) this.m_maxRecordsToReturn);
    onNetworkRequest.m_serverCapabilityFilter = (StringCollection) Utils.Clone((object) this.m_serverCapabilityFilter);
    return (object) onNetworkRequest;
  }
}
