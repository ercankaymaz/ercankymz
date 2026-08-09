using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentInvalidSesparamIdException : EsentUsageException
{
	public EsentInvalidSesparamIdException()
		: base("This JET_sesparam* identifier is not known to the ESE engine.", JET_err.InvalidSesparamId)
	{
	}

	private EsentInvalidSesparamIdException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
