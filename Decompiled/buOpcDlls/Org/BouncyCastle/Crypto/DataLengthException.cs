using System;
using System.Runtime.Serialization;

namespace Org.BouncyCastle.Crypto;

[Serializable]
public class DataLengthException : CryptoException
{
	public DataLengthException()
	{
	}

	public DataLengthException(string message)
		: base(message)
	{
	}

	public DataLengthException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected DataLengthException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
