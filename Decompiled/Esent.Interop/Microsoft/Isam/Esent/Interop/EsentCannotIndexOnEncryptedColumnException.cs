using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentCannotIndexOnEncryptedColumnException : EsentUsageException
{
	public EsentCannotIndexOnEncryptedColumnException()
		: base("Cannot index encrypted column", JET_err.CannotIndexOnEncryptedColumn)
	{
	}

	private EsentCannotIndexOnEncryptedColumnException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
