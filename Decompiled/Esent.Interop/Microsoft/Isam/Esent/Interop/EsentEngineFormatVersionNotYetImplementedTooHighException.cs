using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentEngineFormatVersionNotYetImplementedTooHighException : EsentUsageException
{
	public EsentEngineFormatVersionNotYetImplementedTooHighException()
		: base("The specified JET_ENGINEFORMATVERSION value is too high, higher than this version of ESE knows about.", JET_err.EngineFormatVersionNotYetImplementedTooHigh)
	{
	}

	private EsentEngineFormatVersionNotYetImplementedTooHighException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
