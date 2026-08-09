using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentFlushMapVersionUnsupportedException : EsentUsageException
{
	public EsentFlushMapVersionUnsupportedException()
		: base("The version of the persisted flush map is not supported by this version of the engine.", JET_err.FlushMapVersionUnsupported)
	{
	}

	private EsentFlushMapVersionUnsupportedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
