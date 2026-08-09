using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentDatabaseNotReadyException : EsentUsageException
{
	public EsentDatabaseNotReadyException()
		: base("Recovery on this database has not yet completed enough to permit access.", JET_err.DatabaseNotReady)
	{
	}

	private EsentDatabaseNotReadyException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
