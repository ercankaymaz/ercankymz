using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentEngineFormatVersionNoLongerSupportedTooLowException : EsentUsageException
{
	public EsentEngineFormatVersionNoLongerSupportedTooLowException()
		: base("The specified JET_ENGINEFORMATVERSION value is too low to be supported by this version of ESE.", JET_err.EngineFormatVersionNoLongerSupportedTooLow)
	{
	}

	private EsentEngineFormatVersionNoLongerSupportedTooLowException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
