using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentColumnCannotBeEncryptedException : EsentUsageException
{
	public EsentColumnCannotBeEncryptedException()
		: base("Only JET_coltypLongText and JET_coltypLongBinary columns without default values can be encrypted", JET_err.ColumnCannotBeEncrypted)
	{
	}

	private EsentColumnCannotBeEncryptedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
