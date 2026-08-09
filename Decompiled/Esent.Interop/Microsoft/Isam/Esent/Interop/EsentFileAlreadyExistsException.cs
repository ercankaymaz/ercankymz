using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentFileAlreadyExistsException : EsentInconsistentException
{
	public EsentFileAlreadyExistsException()
		: base("File already exists", JET_err.FileAlreadyExists)
	{
	}

	private EsentFileAlreadyExistsException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
