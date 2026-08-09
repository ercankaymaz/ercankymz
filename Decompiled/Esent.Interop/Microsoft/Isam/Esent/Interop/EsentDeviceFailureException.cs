using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentDeviceFailureException : EsentOperationException
{
	public EsentDeviceFailureException()
		: base("A required hardware device didn't function as expected.", JET_err.DeviceFailure)
	{
	}

	private EsentDeviceFailureException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
