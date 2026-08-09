using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentTooManyRecordsException : EsentStateException
{
	public EsentTooManyRecordsException()
		: base("There are too many records to enumerate, switch to an API that handles 64-bit numbers", JET_err.TooManyRecords)
	{
	}

	private EsentTooManyRecordsException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
