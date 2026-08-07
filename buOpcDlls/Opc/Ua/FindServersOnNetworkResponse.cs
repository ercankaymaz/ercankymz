// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FindServersOnNetworkResponse
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
public class FindServersOnNetworkResponse : 
  IEncodeable,
  ICloneable,
  IJsonEncodeable,
  IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private DateTime m_lastCounterResetTime;
  private ServerOnNetworkCollection m_servers;

  public FindServersOnNetworkResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_lastCounterResetTime = DateTime.MinValue;
    this.m_servers = new ServerOnNetworkCollection();
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

  [DataMember(Name = "LastCounterResetTime", IsRequired = false, Order = 2)]
  public DateTime LastCounterResetTime
  {
    get => this.m_lastCounterResetTime;
    set => this.m_lastCounterResetTime = value;
  }

  [DataMember(Name = "Servers", IsRequired = false, Order = 3)]
  public ServerOnNetworkCollection Servers
  {
    get => this.m_servers;
    set
    {
      this.m_servers = value;
      if (value != null)
        return;
      this.m_servers = new ServerOnNetworkCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.FindServersOnNetworkResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersOnNetworkResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersOnNetworkResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersOnNetworkResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteDateTime("LastCounterResetTime", this.LastCounterResetTime);
    encoder.WriteEncodeableArray("Servers", (IList<IEncodeable>) this.Servers.ToArray(), typeof (ServerOnNetwork));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.LastCounterResetTime = decoder.ReadDateTime("LastCounterResetTime");
    this.Servers = (ServerOnNetworkCollection) (ServerOnNetwork[]) decoder.ReadEncodeableArray("Servers", typeof (ServerOnNetwork));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is FindServersOnNetworkResponse onNetworkResponse && Utils.IsEqual((object) this.m_responseHeader, (object) onNetworkResponse.m_responseHeader) && Utils.IsEqual(this.m_lastCounterResetTime, onNetworkResponse.m_lastCounterResetTime) && Utils.IsEqual((object) this.m_servers, (object) onNetworkResponse.m_servers);
  }

  public virtual object Clone() => (object) (FindServersOnNetworkResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FindServersOnNetworkResponse onNetworkResponse = (FindServersOnNetworkResponse) base.MemberwiseClone();
    onNetworkResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    onNetworkResponse.m_lastCounterResetTime = (DateTime) Utils.Clone((object) this.m_lastCounterResetTime);
    onNetworkResponse.m_servers = (ServerOnNetworkCollection) Utils.Clone((object) this.m_servers);
    return (object) onNetworkResponse;
  }
}
