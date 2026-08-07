// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RepublishResponse
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
public class RepublishResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private NotificationMessage m_notificationMessage;

  public RepublishResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_notificationMessage = new NotificationMessage();
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

  [DataMember(Name = "NotificationMessage", IsRequired = false, Order = 2)]
  public NotificationMessage NotificationMessage
  {
    get => this.m_notificationMessage;
    set
    {
      this.m_notificationMessage = value;
      if (value != null)
        return;
      this.m_notificationMessage = new NotificationMessage();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RepublishResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RepublishResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RepublishResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RepublishResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteEncodeable("NotificationMessage", (IEncodeable) this.NotificationMessage, typeof (NotificationMessage));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.NotificationMessage = (NotificationMessage) decoder.ReadEncodeable("NotificationMessage", typeof (NotificationMessage));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RepublishResponse republishResponse && Utils.IsEqual((object) this.m_responseHeader, (object) republishResponse.m_responseHeader) && Utils.IsEqual((object) this.m_notificationMessage, (object) republishResponse.m_notificationMessage);
  }

  public virtual object Clone() => (object) (RepublishResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RepublishResponse republishResponse = (RepublishResponse) base.MemberwiseClone();
    republishResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    republishResponse.m_notificationMessage = (NotificationMessage) Utils.Clone((object) this.m_notificationMessage);
    return (object) republishResponse;
  }
}
