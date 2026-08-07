// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointType
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
public class EndpointType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_endpointUrl;
  private MessageSecurityMode m_securityMode;
  private string m_securityPolicyUri;
  private string m_transportProfileUri;

  public EndpointType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_endpointUrl = (string) null;
    this.m_securityMode = MessageSecurityMode.Invalid;
    this.m_securityPolicyUri = (string) null;
    this.m_transportProfileUri = (string) null;
  }

  [DataMember(Name = "EndpointUrl", IsRequired = false, Order = 1)]
  public string EndpointUrl
  {
    get => this.m_endpointUrl;
    set => this.m_endpointUrl = value;
  }

  [DataMember(Name = "SecurityMode", IsRequired = false, Order = 2)]
  public MessageSecurityMode SecurityMode
  {
    get => this.m_securityMode;
    set => this.m_securityMode = value;
  }

  [DataMember(Name = "SecurityPolicyUri", IsRequired = false, Order = 3)]
  public string SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set => this.m_securityPolicyUri = value;
  }

  [DataMember(Name = "TransportProfileUri", IsRequired = false, Order = 4)]
  public string TransportProfileUri
  {
    get => this.m_transportProfileUri;
    set => this.m_transportProfileUri = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EndpointType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("EndpointUrl", this.EndpointUrl);
    encoder.WriteEnumerated("SecurityMode", (Enum) this.SecurityMode);
    encoder.WriteString("SecurityPolicyUri", this.SecurityPolicyUri);
    encoder.WriteString("TransportProfileUri", this.TransportProfileUri);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EndpointUrl = decoder.ReadString("EndpointUrl");
    this.SecurityMode = (MessageSecurityMode) decoder.ReadEnumerated("SecurityMode", typeof (MessageSecurityMode));
    this.SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
    this.TransportProfileUri = decoder.ReadString("TransportProfileUri");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EndpointType endpointType && Utils.IsEqual((object) this.m_endpointUrl, (object) endpointType.m_endpointUrl) && Utils.IsEqual((object) this.m_securityMode, (object) endpointType.m_securityMode) && Utils.IsEqual((object) this.m_securityPolicyUri, (object) endpointType.m_securityPolicyUri) && Utils.IsEqual((object) this.m_transportProfileUri, (object) endpointType.m_transportProfileUri);
  }

  public virtual object Clone() => (object) (EndpointType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointType endpointType = (EndpointType) base.MemberwiseClone();
    endpointType.m_endpointUrl = (string) Utils.Clone((object) this.m_endpointUrl);
    endpointType.m_securityMode = (MessageSecurityMode) Utils.Clone((object) this.m_securityMode);
    endpointType.m_securityPolicyUri = (string) Utils.Clone((object) this.m_securityPolicyUri);
    endpointType.m_transportProfileUri = (string) Utils.Clone((object) this.m_transportProfileUri);
    return (object) endpointType;
  }
}
