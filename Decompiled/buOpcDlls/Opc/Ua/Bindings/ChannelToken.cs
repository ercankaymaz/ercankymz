using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ChannelToken
{
	private uint m_channelId;

	private uint m_tokenId;

	private DateTime m_createdAt;

	private int m_lifetime;

	private byte[] m_clientNonce;

	private byte[] m_serverNonce;

	private byte[] m_clientSigningKey;

	private byte[] m_clientEncryptingKey;

	private byte[] m_clientInitializationVector;

	private byte[] m_serverSigningKey;

	private byte[] m_serverEncryptingKey;

	private byte[] m_serverInitializationVector;

	private HMAC m_clientHmac;

	private HMAC m_serverHmac;

	private SymmetricAlgorithm m_clientEncryptor;

	private SymmetricAlgorithm m_serverEncryptor;

	public uint ChannelId
	{
		get
		{
			return m_channelId;
		}
		set
		{
			m_channelId = value;
		}
	}

	public uint TokenId
	{
		get
		{
			return m_tokenId;
		}
		set
		{
			m_tokenId = value;
		}
	}

	public DateTime CreatedAt
	{
		get
		{
			return m_createdAt;
		}
		set
		{
			m_createdAt = value;
		}
	}

	public int Lifetime
	{
		get
		{
			return m_lifetime;
		}
		set
		{
			m_lifetime = value;
		}
	}

	public bool Expired
	{
		get
		{
			if (DateTime.UtcNow > m_createdAt.AddMilliseconds(m_lifetime))
			{
				return true;
			}
			return false;
		}
	}

	public bool ActivationRequired
	{
		get
		{
			if (DateTime.UtcNow > m_createdAt.AddMilliseconds((double)m_lifetime * 0.95))
			{
				return true;
			}
			return false;
		}
	}

	public byte[] ClientNonce
	{
		get
		{
			return m_clientNonce;
		}
		set
		{
			m_clientNonce = value;
		}
	}

	public byte[] ServerNonce
	{
		get
		{
			return m_serverNonce;
		}
		set
		{
			m_serverNonce = value;
		}
	}

	public byte[] ClientSigningKey
	{
		get
		{
			return m_clientSigningKey;
		}
		set
		{
			m_clientSigningKey = value;
		}
	}

	public byte[] ClientEncryptingKey
	{
		get
		{
			return m_clientEncryptingKey;
		}
		set
		{
			m_clientEncryptingKey = value;
		}
	}

	public byte[] ClientInitializationVector
	{
		get
		{
			return m_clientInitializationVector;
		}
		set
		{
			m_clientInitializationVector = value;
		}
	}

	public byte[] ServerSigningKey
	{
		get
		{
			return m_serverSigningKey;
		}
		set
		{
			m_serverSigningKey = value;
		}
	}

	public byte[] ServerEncryptingKey
	{
		get
		{
			return m_serverEncryptingKey;
		}
		set
		{
			m_serverEncryptingKey = value;
		}
	}

	public byte[] ServerInitializationVector
	{
		get
		{
			return m_serverInitializationVector;
		}
		set
		{
			m_serverInitializationVector = value;
		}
	}

	public SymmetricAlgorithm ClientEncryptor
	{
		get
		{
			return m_clientEncryptor;
		}
		set
		{
			m_clientEncryptor = value;
		}
	}

	public SymmetricAlgorithm ServerEncryptor
	{
		get
		{
			return m_serverEncryptor;
		}
		set
		{
			m_serverEncryptor = value;
		}
	}

	public HMAC ClientHmac
	{
		get
		{
			return m_clientHmac;
		}
		set
		{
			m_clientHmac = value;
		}
	}

	public HMAC ServerHmac
	{
		get
		{
			return m_serverHmac;
		}
		set
		{
			m_serverHmac = value;
		}
	}
}
