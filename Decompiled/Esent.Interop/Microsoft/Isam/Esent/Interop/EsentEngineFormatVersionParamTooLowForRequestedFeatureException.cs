using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentEngineFormatVersionParamTooLowForRequestedFeatureException : EsentUsageException
{
	public EsentEngineFormatVersionParamTooLowForRequestedFeatureException()
		: base("Thrown by a format feature (not at JetSetSystemParameter) if the client requests a feature that requires a version higher than that set for the JET_paramEngineFormatVersion.", JET_err.EngineFormatVersionParamTooLowForRequestedFeature)
	{
	}

	private EsentEngineFormatVersionParamTooLowForRequestedFeatureException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
