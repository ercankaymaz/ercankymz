using System;
using System.Runtime.Serialization;

namespace Org.BouncyCastle.Tls.Crypto;

[Serializable]
public class TlsCryptoException : TlsException
{
	public TlsCryptoException()
	{
	}

	public TlsCryptoException(string message)
		: base(message)
	{
	}

	public TlsCryptoException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected TlsCryptoException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
