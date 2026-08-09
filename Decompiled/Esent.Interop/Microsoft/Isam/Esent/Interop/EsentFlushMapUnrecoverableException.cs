using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentFlushMapUnrecoverableException : EsentStateException
{
	public EsentFlushMapUnrecoverableException()
		: base("The persisted flush map cannot be reconstructed.", JET_err.FlushMapUnrecoverable)
	{
	}

	private EsentFlushMapUnrecoverableException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
