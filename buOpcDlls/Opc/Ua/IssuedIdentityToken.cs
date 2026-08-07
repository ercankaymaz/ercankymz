// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IssuedIdentityToken
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
public class IssuedIdentityToken : UserIdentityToken
{
  private byte[] m_tokenData;
  private string m_encryptionAlgorithm;
  private byte[] m_decryptedTokenData;

  public IssuedIdentityToken() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_tokenData = (byte[]) null;
    this.m_encryptionAlgorithm = (string) null;
  }

  [DataMember(Name = "TokenData", IsRequired = false, Order = 1)]
  public byte[] TokenData
  {
    get => this.m_tokenData;
    set => this.m_tokenData = value;
  }

  [DataMember(Name = "EncryptionAlgorithm", IsRequired = false, Order = 2)]
  public string EncryptionAlgorithm
  {
    get => this.m_encryptionAlgorithm;
    set => this.m_encryptionAlgorithm = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.IssuedIdentityToken;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.IssuedIdentityToken_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.IssuedIdentityToken_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.IssuedIdentityToken_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByteString("TokenData", this.TokenData);
    encoder.WriteString("EncryptionAlgorithm", this.EncryptionAlgorithm);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.TokenData = decoder.ReadByteString("TokenData");
    this.EncryptionAlgorithm = decoder.ReadString("EncryptionAlgorithm");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is IssuedIdentityToken issuedIdentityToken && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_tokenData, (object) issuedIdentityToken.m_tokenData) && Utils.IsEqual((object) this.m_encryptionAlgorithm, (object) issuedIdentityToken.m_encryptionAlgorithm) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (IssuedIdentityToken) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    IssuedIdentityToken issuedIdentityToken = (IssuedIdentityToken) base.MemberwiseClone();
    issuedIdentityToken.m_tokenData = (byte[]) Utils.Clone((object) this.m_tokenData);
    issuedIdentityToken.m_encryptionAlgorithm = (string) Utils.Clone((object) this.m_encryptionAlgorithm);
    return (object) issuedIdentityToken;
  }

  public IssuedTokenType IssuedTokenType { get; set; }

  public byte[] DecryptedTokenData
  {
    get => this.m_decryptedTokenData;
    set => this.m_decryptedTokenData = value;
  }

  public override void Encrypt(
    X509Certificate2 certificate,
    byte[] senderNonce,
    string securityPolicyUri)
  {
    if (!string.IsNullOrEmpty(securityPolicyUri) && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None"))
    {
      byte[] plainText = Utils.Append(this.m_decryptedTokenData, senderNonce);
      EncryptedData encryptedData = SecurityPolicies.Encrypt(certificate, securityPolicyUri, plainText);
      this.m_tokenData = encryptedData.Data;
      this.m_encryptionAlgorithm = encryptedData.Algorithm;
    }
    else
    {
      this.m_tokenData = this.m_decryptedTokenData;
      this.m_encryptionAlgorithm = string.Empty;
    }
  }

  public override void Decrypt(
    X509Certificate2 certificate,
    byte[] senderNonce,
    string securityPolicyUri)
  {
    if (!string.IsNullOrEmpty(securityPolicyUri) && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None"))
    {
      byte[] sourceArray = SecurityPolicies.Decrypt(certificate, securityPolicyUri, new EncryptedData()
      {
        Data = this.m_tokenData,
        Algorithm = this.m_encryptionAlgorithm
      });
      int length = sourceArray.Length;
      if (senderNonce != null)
      {
        length -= senderNonce.Length;
        for (int index = 0; index < senderNonce.Length; ++index)
        {
          if ((int) senderNonce[index] != (int) sourceArray[index + length])
            throw new ServiceResultException(2149646336U /*0x80210000*/);
        }
      }
      this.m_decryptedTokenData = new byte[length];
      Array.Copy((Array) sourceArray, (Array) this.m_decryptedTokenData, length);
    }
    else
      this.m_decryptedTokenData = this.m_tokenData;
  }

  public override SignatureData Sign(byte[] dataToSign, string securityPolicyUri)
  {
    return (SignatureData) null;
  }

  public override bool Verify(
    byte[] dataToVerify,
    SignatureData signatureData,
    string securityPolicyUri)
  {
    return true;
  }
}
