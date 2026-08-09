using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentInvalidColumnReferenceException : EsentStateException
{
	public EsentInvalidColumnReferenceException()
		: base("Column reference is invalid", JET_err.InvalidColumnReference)
	{
	}

	private EsentInvalidColumnReferenceException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
