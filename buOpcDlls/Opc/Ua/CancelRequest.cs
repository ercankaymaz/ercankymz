// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CancelRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CancelRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_requestHandle;

  public CancelRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_requestHandle = 0U;
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

  [DataMember(Name = "RequestHandle", IsRequired = false, Order = 2)]
  public uint RequestHandle
  {
    get => this.m_requestHandle;
    set => this.m_requestHandle = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CancelRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CancelRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CancelRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CancelRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("RequestHandle", this.RequestHandle);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.RequestHandle = decoder.ReadUInt32("RequestHandle");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CancelRequest cancelRequest && Utils.IsEqual((object) this.m_requestHeader, (object) cancelRequest.m_requestHeader) && Utils.IsEqual((object) this.m_requestHandle, (object) cancelRequest.m_requestHandle);
  }

  public virtual object Clone() => (object) (CancelRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CancelRequest cancelRequest = (CancelRequest) base.MemberwiseClone();
    cancelRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    cancelRequest.m_requestHandle = (uint) Utils.Clone((object) this.m_requestHandle);
    return (object) cancelRequest;
  }
}
