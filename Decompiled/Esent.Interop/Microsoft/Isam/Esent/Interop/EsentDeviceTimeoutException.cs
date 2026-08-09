using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentDeviceTimeoutException : EsentOperationException
{
	public EsentDeviceTimeoutException()
		: base("Timeout occurred while waiting for a hardware device to respond.", JET_err.DeviceTimeout)
	{
	}

	private EsentDeviceTimeoutException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
