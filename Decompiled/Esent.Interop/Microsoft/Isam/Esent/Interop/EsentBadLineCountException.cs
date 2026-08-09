using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class EsentBadLineCountException : EsentCorruptionException
{
	public EsentBadLineCountException()
		: base("Number of lines on the page is too few compared to the line being operated on", JET_err.BadLineCount)
	{
	}

	private EsentBadLineCountException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
