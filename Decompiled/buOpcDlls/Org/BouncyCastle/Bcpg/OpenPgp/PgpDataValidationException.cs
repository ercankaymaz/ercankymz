using System;
using System.Runtime.Serialization;

namespace Org.BouncyCastle.Bcpg.OpenPgp;

[Serializable]
public class PgpDataValidationException : PgpException
{
	public PgpDataValidationException()
	{
	}

	public PgpDataValidationException(string message)
		: base(message)
	{
	}

	public PgpDataValidationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected PgpDataValidationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
