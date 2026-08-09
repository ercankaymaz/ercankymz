using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerSecurityPolicy
{
	private MessageSecurityMode m_securityMode;

	private string m_securityPolicyUri;

	[DataMember(IsRequired = false, Order = 1)]
	public MessageSecurityMode SecurityMode
	{
		get
		{
			return m_securityMode;
		}
		set
		{
			m_securityMode = value;
		}
	}

	[DataMember(IsRequired = false, Order = 2)]
	public string SecurityPolicyUri
	{
		get
		{
			return m_securityPolicyUri;
		}
		set
		{
			m_securityPolicyUri = value;
		}
	}

	public ServerSecurityPolicy()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_securityMode = MessageSecurityMode.SignAndEncrypt;
		m_securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public static byte CalculateSecurityLevel(MessageSecurityMode mode, string policyUri)
	{
		if (mode == MessageSecurityMode.Invalid || mode == MessageSecurityMode.None)
		{
			return 0;
		}
		byte b = 0;
		switch (policyUri)
		{
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
			b = 2;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
			b = 4;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			b = 6;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
			b = 8;
			break;
		case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
			b = 10;
			break;
		default:
			return 0;
		}
		if (mode == MessageSecurityMode.SignAndEncrypt)
		{
			b += 100;
		}
		return b;
	}
}
