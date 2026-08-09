using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentBackupDirectoryNotEmptyException : EsentUsageException
{
	public EsentBackupDirectoryNotEmptyException()
		: base("The backup directory is not empty", JET_err.BackupDirectoryNotEmpty)
	{
	}

	private EsentBackupDirectoryNotEmptyException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
