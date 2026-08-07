// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CloseSessionRequest
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
public class CloseSessionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private bool m_deleteSubscriptions;

  public CloseSessionRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_deleteSubscriptions = true;
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

  [DataMember(Name = "DeleteSubscriptions", IsRequired = false, Order = 2)]
  public bool DeleteSubscriptions
  {
    get => this.m_deleteSubscriptions;
    set => this.m_deleteSubscriptions = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CloseSessionRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CloseSessionRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CloseSessionRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CloseSessionRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteBoolean("DeleteSubscriptions", this.DeleteSubscriptions);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.DeleteSubscriptions = decoder.ReadBoolean("DeleteSubscriptions");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CloseSessionRequest closeSessionRequest && Utils.IsEqual((object) this.m_requestHeader, (object) closeSessionRequest.m_requestHeader) && Utils.IsEqual((object) this.m_deleteSubscriptions, (object) closeSessionRequest.m_deleteSubscriptions);
  }

  public virtual object Clone() => (object) (CloseSessionRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CloseSessionRequest closeSessionRequest = (CloseSessionRequest) base.MemberwiseClone();
    closeSessionRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    closeSessionRequest.m_deleteSubscriptions = (bool) Utils.Clone((object) this.m_deleteSubscriptions);
    return (object) closeSessionRequest;
  }
}
