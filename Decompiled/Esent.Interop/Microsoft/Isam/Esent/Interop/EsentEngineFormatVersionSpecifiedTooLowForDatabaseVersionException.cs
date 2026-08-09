using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentEngineFormatVersionSpecifiedTooLowForDatabaseVersionException : EsentStateException
{
	public EsentEngineFormatVersionSpecifiedTooLowForDatabaseVersionException()
		: base("The specified JET_ENGINEFORMATVERSION is set too low for this database file, the database file has already been upgraded to a higher version.  A higher JET_ENGINEFORMATVERSION value must be set in the param.", JET_err.EngineFormatVersionSpecifiedTooLowForDatabaseVersion)
	{
	}

	private EsentEngineFormatVersionSpecifiedTooLowForDatabaseVersionException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
