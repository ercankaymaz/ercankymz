// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FindServersResponse
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
public class FindServersResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private ApplicationDescriptionCollection m_servers;

  public FindServersResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_servers = new ApplicationDescriptionCollection();
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

  [DataMember(Name = "Servers", IsRequired = false, Order = 2)]
  public ApplicationDescriptionCollection Servers
  {
    get => this.m_servers;
    set
    {
      this.m_servers = value;
      if (value != null)
        return;
      this.m_servers = new ApplicationDescriptionCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.FindServersResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FindServersResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteEncodeableArray("Servers", (IList<IEncodeable>) this.Servers.ToArray(), typeof (ApplicationDescription));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.Servers = (ApplicationDescriptionCollection) (ApplicationDescription[]) decoder.ReadEncodeableArray("Servers", typeof (ApplicationDescription));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is FindServersResponse findServersResponse && Utils.IsEqual((object) this.m_responseHeader, (object) findServersResponse.m_responseHeader) && Utils.IsEqual((object) this.m_servers, (object) findServersResponse.m_servers);
  }

  public virtual object Clone() => (object) (FindServersResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FindServersResponse findServersResponse = (FindServersResponse) base.MemberwiseClone();
    findServersResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    findServersResponse.m_servers = (ApplicationDescriptionCollection) Utils.Clone((object) this.m_servers);
    return (object) findServersResponse;
  }
}
