using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentCompressionIntegrityCheckFailedException : EsentCorruptionException
{
	public EsentCompressionIntegrityCheckFailedException()
		: base("A compression integrity check failed. Decompressing data failed the integrity checksum indicating a data corruption in the compress/decompress pipeline.", JET_err.CompressionIntegrityCheckFailed)
	{
	}

	private EsentCompressionIntegrityCheckFailedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
