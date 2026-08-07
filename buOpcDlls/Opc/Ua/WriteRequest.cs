// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriteRequest
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
public class WriteRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private WriteValueCollection m_nodesToWrite;

  public WriteRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_nodesToWrite = new WriteValueCollection();
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

  [DataMember(Name = "NodesToWrite", IsRequired = false, Order = 2)]
  public WriteValueCollection NodesToWrite
  {
    get => this.m_nodesToWrite;
    set
    {
      this.m_nodesToWrite = value;
      if (value != null)
        return;
      this.m_nodesToWrite = new WriteValueCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.WriteRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriteRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriteRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriteRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeableArray("NodesToWrite", (IList<IEncodeable>) this.NodesToWrite.ToArray(), typeof (WriteValue));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.NodesToWrite = (WriteValueCollection) (WriteValue[]) decoder.ReadEncodeableArray("NodesToWrite", typeof (WriteValue));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is WriteRequest writeRequest && Utils.IsEqual((object) this.m_requestHeader, (object) writeRequest.m_requestHeader) && Utils.IsEqual((object) this.m_nodesToWrite, (object) writeRequest.m_nodesToWrite);
  }

  public virtual object Clone() => (object) (WriteRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    WriteRequest writeRequest = (WriteRequest) base.MemberwiseClone();
    writeRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    writeRequest.m_nodesToWrite = (WriteValueCollection) Utils.Clone((object) this.m_nodesToWrite);
    return (object) writeRequest;
  }
}
