using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentPageInitializedMismatchException : EsentCorruptionException
{
	public EsentPageInitializedMismatchException()
		: base("Database divergence mismatch. Page was uninitialized on remote node, but initialized on local node.", JET_err.PageInitializedMismatch)
	{
	}

	private EsentPageInitializedMismatchException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
