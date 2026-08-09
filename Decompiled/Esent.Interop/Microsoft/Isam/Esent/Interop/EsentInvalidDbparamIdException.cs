using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentInvalidDbparamIdException : EsentUsageException
{
	public EsentInvalidDbparamIdException()
		: base("This JET_dbparam* identifier is not known to the ESE engine.", JET_err.InvalidDbparamId)
	{
	}

	private EsentInvalidDbparamIdException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
