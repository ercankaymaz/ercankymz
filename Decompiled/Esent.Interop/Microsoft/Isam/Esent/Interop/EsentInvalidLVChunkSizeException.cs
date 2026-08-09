using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentInvalidLVChunkSizeException : EsentUsageException
{
	public EsentInvalidLVChunkSizeException()
		: base("Specified LV chunk size is not supported", JET_err.InvalidLVChunkSize)
	{
	}

	private EsentInvalidLVChunkSizeException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
