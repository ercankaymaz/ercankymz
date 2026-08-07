// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CloseSecureChannelRequest
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
public class CloseSecureChannelRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;

  public CloseSecureChannelRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_requestHeader = new RequestHeader();

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

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CloseSecureChannelRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CloseSecureChannelRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CloseSecureChannelRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CloseSecureChannelRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CloseSecureChannelRequest secureChannelRequest && Utils.IsEqual((object) this.m_requestHeader, (object) secureChannelRequest.m_requestHeader);
  }

  public virtual object Clone() => (object) (CloseSecureChannelRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CloseSecureChannelRequest secureChannelRequest = (CloseSecureChannelRequest) base.MemberwiseClone();
    secureChannelRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    return (object) secureChannelRequest;
  }
}
