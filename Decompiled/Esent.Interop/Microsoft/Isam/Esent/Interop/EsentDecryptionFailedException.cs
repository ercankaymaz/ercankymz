using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentDecryptionFailedException : EsentCorruptionException
{
	public EsentDecryptionFailedException()
		: base("Data could not be decrypted", JET_err.DecryptionFailed)
	{
	}

	private EsentDecryptionFailedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
