using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentEngineFormatVersionSpecifiedTooLowForLogVersionException : EsentStateException
{
	public EsentEngineFormatVersionSpecifiedTooLowForLogVersionException()
		: base("The specified JET_ENGINEFORMATVERSION is set too low for this log stream, the log files have already been upgraded to a higher version.  A higher JET_ENGINEFORMATVERSION value must be set in the param.", JET_err.EngineFormatVersionSpecifiedTooLowForLogVersion)
	{
	}

	private EsentEngineFormatVersionSpecifiedTooLowForLogVersionException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
