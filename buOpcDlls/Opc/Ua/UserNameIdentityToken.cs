// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UserNameIdentityToken
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UserNameIdentityToken : UserIdentityToken
{
  private string m_userName;
  private byte[] m_password;
  private string m_encryptionAlgorithm;
  private string m_decryptedPassword;

  public UserNameIdentityToken() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_userName = (string) null;
    this.m_password = (byte[]) null;
    this.m_encryptionAlgorithm = (string) null;
  }

  [DataMember(Name = "UserName", IsRequired = false, Order = 1)]
  public string UserName
  {
    get => this.m_userName;
    set => this.m_userName = value;
  }

  [DataMember(Name = "Password", IsRequired = false, Order = 2)]
  public byte[] Password
  {
    get => this.m_password;
    set => this.m_password = value;
  }

  [DataMember(Name = "EncryptionAlgorithm", IsRequired = false, Order = 3)]
  public string EncryptionAlgorithm
  {
    get => this.m_encryptionAlgorithm;
    set => this.m_encryptionAlgorithm = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UserNameIdentityToken;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserNameIdentityToken_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserNameIdentityToken_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserNameIdentityToken_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("UserName", this.UserName);
    encoder.WriteByteString("Password", this.Password);
    encoder.WriteString("EncryptionAlgorithm", this.EncryptionAlgorithm);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.UserName = decoder.ReadString("UserName");
    this.Password = decoder.ReadByteString("Password");
    this.EncryptionAlgorithm = decoder.ReadString("EncryptionAlgorithm");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is UserNameIdentityToken nameIdentityToken && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_userName, (object) nameIdentityToken.m_userName) && Utils.IsEqual((object) this.m_password, (object) nameIdentityToken.m_password) && Utils.IsEqual((object) this.m_encryptionAlgorithm, (object) nameIdentityToken.m_encryptionAlgorithm) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (UserNameIdentityToken) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UserNameIdentityToken nameIdentityToken = (UserNameIdentityToken) base.MemberwiseClone();
    nameIdentityToken.m_userName = (string) Utils.Clone((object) this.m_userName);
    nameIdentityToken.m_password = (byte[]) Utils.Clone((object) this.m_password);
    nameIdentityToken.m_encryptionAlgorithm = (string) Utils.Clone((object) this.m_encryptionAlgorithm);
    return (object) nameIdentityToken;
  }

  public string DecryptedPassword
  {
    get => this.m_decryptedPassword;
    set => this.m_decryptedPassword = value;
  }

  public override void Encrypt(
    X509Certificate2 certificate,
    byte[] senderNonce,
    string securityPolicyUri)
  {
    if (this.m_decryptedPassword == null)
      this.m_password = (byte[]) null;
    else if (!string.IsNullOrEmpty(securityPolicyUri) && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None"))
    {
      byte[] plainText = Utils.Append(Encoding.UTF8.GetBytes(this.m_decryptedPassword), senderNonce);
      EncryptedData encryptedData = SecurityPolicies.Encrypt(certificate, securityPolicyUri, plainText);
      this.m_password = encryptedData.Data;
      this.m_encryptionAlgorithm = encryptedData.Algorithm;
    }
    else
    {
      this.m_password = Encoding.UTF8.GetBytes(this.m_decryptedPassword);
      this.m_encryptionAlgorithm = (string) null;
    }
  }

  public override void Decrypt(
    X509Certificate2 certificate,
    byte[] senderNonce,
    string securityPolicyUri)
  {
    if (!string.IsNullOrEmpty(securityPolicyUri) && !(securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None"))
    {
      byte[] bytes = SecurityPolicies.Decrypt(certificate, securityPolicyUri, new EncryptedData()
      {
        Data = this.m_password,
        Algorithm = this.m_encryptionAlgorithm
      });
      if (bytes == null)
      {
        this.m_decryptedPassword = (string) null;
      }
      else
      {
        int length = bytes.Length;
        if (senderNonce != null)
        {
          length -= senderNonce.Length;
          int num = 0;
          for (int index = 0; index < senderNonce.Length; ++index)
            num |= (int) senderNonce[index] ^ (int) bytes[index + length];
          if (num != 0)
            throw new ServiceResultException(2149646336U /*0x80210000*/);
        }
        this.m_decryptedPassword = Encoding.UTF8.GetString(bytes, 0, length);
      }
    }
    else
      this.m_decryptedPassword = Encoding.UTF8.GetString(this.m_password, 0, this.m_password.Length);
  }
}
