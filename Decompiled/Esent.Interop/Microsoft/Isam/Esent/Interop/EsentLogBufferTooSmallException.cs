using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentLogBufferTooSmallException : EsentObsoleteException
{
	public EsentLogBufferTooSmallException()
		: base("An operation generated a log record which was too large to fit in the log buffer or in a single log file", JET_err.LogBufferTooSmall)
	{
	}

	private EsentLogBufferTooSmallException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
