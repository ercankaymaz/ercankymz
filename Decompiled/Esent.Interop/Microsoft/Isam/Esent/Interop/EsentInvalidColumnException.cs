using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class EsentInvalidColumnException : EsentException
{
	public override string Message => "Column is not valid for this operation";

	public EsentInvalidColumnException()
	{
	}

	protected EsentInvalidColumnException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
