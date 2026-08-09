using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentColumnNoEncryptionKeyException : EsentUsageException
{
	public EsentColumnNoEncryptionKeyException()
		: base("Cannot retrieve/set encrypted column without an encryption key", JET_err.ColumnNoEncryptionKey)
	{
	}

	private EsentColumnNoEncryptionKeyException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
