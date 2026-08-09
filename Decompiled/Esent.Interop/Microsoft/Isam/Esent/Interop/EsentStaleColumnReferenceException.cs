using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentStaleColumnReferenceException : EsentStateException
{
	public EsentStaleColumnReferenceException()
		: base("Column reference is stale", JET_err.StaleColumnReference)
	{
	}

	private EsentStaleColumnReferenceException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
