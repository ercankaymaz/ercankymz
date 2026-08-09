using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class TypeNotSupportedException : DevAgeApplicationException
{
	public TypeNotSupportedException(Type type)
		: base("Type " + type.ToString() + " not supported")
	{
	}

	protected TypeNotSupportedException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
