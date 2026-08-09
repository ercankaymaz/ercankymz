using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentDatabaseAttachedForRecoveryException : EsentUsageException
{
	public EsentDatabaseAttachedForRecoveryException()
		: base("Database is attached but only for recovery.  It must be explicitly attached before it can be opened. ", JET_err.DatabaseAttachedForRecovery)
	{
	}

	private EsentDatabaseAttachedForRecoveryException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
