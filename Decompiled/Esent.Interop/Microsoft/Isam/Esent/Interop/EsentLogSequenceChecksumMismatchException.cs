using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentLogSequenceChecksumMismatchException : EsentCorruptionException
{
	public EsentLogSequenceChecksumMismatchException()
		: base("The previous log's accumulated segment checksum doesn't match the next log", JET_err.LogSequenceChecksumMismatch)
	{
	}

	private EsentLogSequenceChecksumMismatchException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
