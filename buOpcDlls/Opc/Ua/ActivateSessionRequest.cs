// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ActivateSessionRequest
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
public class ActivateSessionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private SignatureData m_clientSignature;
  private SignedSoftwareCertificateCollection m_clientSoftwareCertificates;
  private StringCollection m_localeIds;
  private ExtensionObject m_userIdentityToken;
  private SignatureData m_userTokenSignature;

  public ActivateSessionRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_clientSignature = new SignatureData();
    this.m_clientSoftwareCertificates = new SignedSoftwareCertificateCollection();
    this.m_localeIds = new StringCollection();
    this.m_userIdentityToken = (ExtensionObject) null;
    this.m_userTokenSignature = new SignatureData();
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

  [DataMember(Name = "ClientSignature", IsRequired = false, Order = 2)]
  public SignatureData ClientSignature
  {
    get => this.m_clientSignature;
    set
    {
      this.m_clientSignature = value;
      if (value != null)
        return;
      this.m_clientSignature = new SignatureData();
    }
  }

  [DataMember(Name = "ClientSoftwareCertificates", IsRequired = false, Order = 3)]
  public SignedSoftwareCertificateCollection ClientSoftwareCertificates
  {
    get => this.m_clientSoftwareCertificates;
    set
    {
      this.m_clientSoftwareCertificates = value;
      if (value != null)
        return;
      this.m_clientSoftwareCertificates = new SignedSoftwareCertificateCollection();
    }
  }

  [DataMember(Name = "LocaleIds", IsRequired = false, Order = 4)]
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

  [DataMember(Name = "UserIdentityToken", IsRequired = false, Order = 5)]
  public ExtensionObject UserIdentityToken
  {
    get => this.m_userIdentityToken;
    set => this.m_userIdentityToken = value;
  }

  [DataMember(Name = "UserTokenSignature", IsRequired = false, Order = 6)]
  public SignatureData UserTokenSignature
  {
    get => this.m_userTokenSignature;
    set
    {
      this.m_userTokenSignature = value;
      if (value != null)
        return;
      this.m_userTokenSignature = new SignatureData();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ActivateSessionRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ActivateSessionRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ActivateSessionRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ActivateSessionRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeable("ClientSignature", (IEncodeable) this.ClientSignature, typeof (SignatureData));
    encoder.WriteEncodeableArray("ClientSoftwareCertificates", (IList<IEncodeable>) this.ClientSoftwareCertificates.ToArray(), typeof (SignedSoftwareCertificate));
    encoder.WriteStringArray("LocaleIds", (IList<string>) this.LocaleIds);
    encoder.WriteExtensionObject("UserIdentityToken", this.UserIdentityToken);
    encoder.WriteEncodeable("UserTokenSignature", (IEncodeable) this.UserTokenSignature, typeof (SignatureData));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.ClientSignature = (SignatureData) decoder.ReadEncodeable("ClientSignature", typeof (SignatureData));
    this.ClientSoftwareCertificates = (SignedSoftwareCertificateCollection) (SignedSoftwareCertificate[]) decoder.ReadEncodeableArray("ClientSoftwareCertificates", typeof (SignedSoftwareCertificate));
    this.LocaleIds = decoder.ReadStringArray("LocaleIds");
    this.UserIdentityToken = decoder.ReadExtensionObject("UserIdentityToken");
    this.UserTokenSignature = (SignatureData) decoder.ReadEncodeable("UserTokenSignature", typeof (SignatureData));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ActivateSessionRequest activateSessionRequest && Utils.IsEqual((object) this.m_requestHeader, (object) activateSessionRequest.m_requestHeader) && Utils.IsEqual((object) this.m_clientSignature, (object) activateSessionRequest.m_clientSignature) && Utils.IsEqual((object) this.m_clientSoftwareCertificates, (object) activateSessionRequest.m_clientSoftwareCertificates) && Utils.IsEqual((object) this.m_localeIds, (object) activateSessionRequest.m_localeIds) && Utils.IsEqual((object) this.m_userIdentityToken, (object) activateSessionRequest.m_userIdentityToken) && Utils.IsEqual((object) this.m_userTokenSignature, (object) activateSessionRequest.m_userTokenSignature);
  }

  public virtual object Clone() => (object) (ActivateSessionRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ActivateSessionRequest activateSessionRequest = (ActivateSessionRequest) base.MemberwiseClone();
    activateSessionRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    activateSessionRequest.m_clientSignature = (SignatureData) Utils.Clone((object) this.m_clientSignature);
    activateSessionRequest.m_clientSoftwareCertificates = (SignedSoftwareCertificateCollection) Utils.Clone((object) this.m_clientSoftwareCertificates);
    activateSessionRequest.m_localeIds = (StringCollection) Utils.Clone((object) this.m_localeIds);
    activateSessionRequest.m_userIdentityToken = (ExtensionObject) Utils.Clone((object) this.m_userIdentityToken);
    activateSessionRequest.m_userTokenSignature = (SignatureData) Utils.Clone((object) this.m_userTokenSignature);
    return (object) activateSessionRequest;
  }
}
