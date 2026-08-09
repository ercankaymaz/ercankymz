using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentDeviceMisconfiguredException : EsentFatalException
{
	public EsentDeviceMisconfiguredException()
		: base("A required hardware device was misconfigured externally.", JET_err.DeviceMisconfigured)
	{
	}

	private EsentDeviceMisconfiguredException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
