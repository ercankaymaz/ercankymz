using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentFlushMapDatabaseMismatchException : EsentUsageException
{
	public EsentFlushMapDatabaseMismatchException()
		: base("The persisted flush map and the database do not match.", JET_err.FlushMapDatabaseMismatch)
	{
	}

	private EsentFlushMapDatabaseMismatchException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
