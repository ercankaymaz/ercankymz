// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UserIdentityToken
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UserIdentityToken : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_policyId;

  public UserIdentityToken() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_policyId = (string) null;

  [DataMember(Name = "PolicyId", IsRequired = false, Order = 1)]
  public string PolicyId
  {
    get => this.m_policyId;
    set => this.m_policyId = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UserIdentityToken;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserIdentityToken_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserIdentityToken_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserIdentityToken_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("PolicyId", this.PolicyId);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PolicyId = decoder.ReadString("PolicyId");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is UserIdentityToken userIdentityToken && Utils.IsEqual((object) this.m_policyId, (object) userIdentityToken.m_policyId);
  }

  public virtual object Clone() => (object) (UserIdentityToken) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UserIdentityToken userIdentityToken = (UserIdentityToken) base.MemberwiseClone();
    userIdentityToken.m_policyId = (string) Utils.Clone((object) this.m_policyId);
    return (object) userIdentityToken;
  }

  public virtual void Encrypt(
    X509Certificate2 certificate,
    byte[] receiverNonce,
    string securityPolicyUri)
  {
  }

  public virtual void Decrypt(
    X509Certificate2 certificate,
    byte[] receiverNonce,
    string securityPolicyUri)
  {
  }

  public virtual SignatureData Sign(byte[] dataToSign, string securityPolicyUri)
  {
    return new SignatureData();
  }

  public virtual bool Verify(
    byte[] dataToVerify,
    SignatureData signatureData,
    string securityPolicyUri)
  {
    return true;
  }
}
