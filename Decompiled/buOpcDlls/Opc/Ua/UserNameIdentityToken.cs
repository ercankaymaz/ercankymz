using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

	[DataMember(Name = "UserName", IsRequired = false, Order = 1)]
	public string UserName
	{
		get
		{
			return m_userName;
		}
		set
		{
			m_userName = value;
		}
	}

	[DataMember(Name = "Password", IsRequired = false, Order = 2)]
	public byte[] Password
	{
		get
		{
			return m_password;
		}
		set
		{
			m_password = value;
		}
	}

	[DataMember(Name = "EncryptionAlgorithm", IsRequired = false, Order = 3)]
	public string EncryptionAlgorithm
	{
		get
		{
			return m_encryptionAlgorithm;
		}
		set
		{
			m_encryptionAlgorithm = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.UserNameIdentityToken;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.UserNameIdentityToken_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.UserNameIdentityToken_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.UserNameIdentityToken_Encoding_DefaultJson;

	public string DecryptedPassword
	{
		get
		{
			return m_decryptedPassword;
		}
		set
		{
			m_decryptedPassword = value;
		}
	}

	public UserNameIdentityToken()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_userName = null;
		m_password = null;
		m_encryptionAlgorithm = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("UserName", UserName);
		encoder.WriteByteString("Password", Password);
		encoder.WriteString("EncryptionAlgorithm", EncryptionAlgorithm);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		UserName = decoder.ReadString("UserName");
		Password = decoder.ReadByteString("Password");
		EncryptionAlgorithm = decoder.ReadString("EncryptionAlgorithm");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UserNameIdentityToken userNameIdentityToken))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userName, userNameIdentityToken.m_userName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_password, userNameIdentityToken.m_password))
		{
			return false;
		}
		if (!Utils.IsEqual(m_encryptionAlgorithm, userNameIdentityToken.m_encryptionAlgorithm))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (UserNameIdentityToken)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UserNameIdentityToken obj = (UserNameIdentityToken)base.MemberwiseClone();
		obj.m_userName = (string)Utils.Clone(m_userName);
		obj.m_password = (byte[])Utils.Clone(m_password);
		obj.m_encryptionAlgorithm = (string)Utils.Clone(m_encryptionAlgorithm);
		return obj;
	}

	public override void Encrypt(X509Certificate2 certificate, byte[] senderNonce, string securityPolicyUri)
	{
		if (m_decryptedPassword == null)
		{
			m_password = null;
			return;
		}
		if (string.IsNullOrEmpty(securityPolicyUri) || securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			m_password = Encoding.UTF8.GetBytes(m_decryptedPassword);
			m_encryptionAlgorithm = null;
			return;
		}
		byte[] plainText = Utils.Append(Encoding.UTF8.GetBytes(m_decryptedPassword), senderNonce);
		EncryptedData encryptedData = SecurityPolicies.Encrypt(certificate, securityPolicyUri, plainText);
		m_password = encryptedData.Data;
		m_encryptionAlgorithm = encryptedData.Algorithm;
	}

	public override void Decrypt(X509Certificate2 certificate, byte[] senderNonce, string securityPolicyUri)
	{
		if (string.IsNullOrEmpty(securityPolicyUri) || securityPolicyUri == "http://opcfoundation.org/UA/SecurityPolicy#None")
		{
			m_decryptedPassword = Encoding.UTF8.GetString(m_password, 0, m_password.Length);
			return;
		}
		EncryptedData encryptedData = new EncryptedData();
		encryptedData.Data = m_password;
		encryptedData.Algorithm = m_encryptionAlgorithm;
		byte[] array = SecurityPolicies.Decrypt(certificate, securityPolicyUri, encryptedData);
		if (array == null)
		{
			m_decryptedPassword = null;
			return;
		}
		int num = array.Length;
		if (senderNonce != null)
		{
			num -= senderNonce.Length;
			int num2 = 0;
			for (int i = 0; i < senderNonce.Length; i++)
			{
				num2 |= senderNonce[i] ^ array[i + num];
			}
			if (num2 != 0)
			{
				throw new ServiceResultException(2149646336u);
			}
		}
		m_decryptedPassword = Encoding.UTF8.GetString(array, 0, num);
	}
}
