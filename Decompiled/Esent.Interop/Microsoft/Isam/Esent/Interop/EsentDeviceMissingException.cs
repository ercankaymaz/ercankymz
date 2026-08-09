using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentDeviceMissingException : EsentFatalException
{
	public EsentDeviceMissingException()
		: base("A required hardware device or functionality was missing.", JET_err.DeviceMissing)
	{
	}

	private EsentDeviceMissingException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
