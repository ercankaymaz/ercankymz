using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentEncryptionBadItagException : EsentUsageException
{
	public EsentEncryptionBadItagException()
		: base("Cannot encrypt tagged columns with itag>1", JET_err.EncryptionBadItag)
	{
	}

	private EsentEncryptionBadItagException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
