using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class ValueNotSupportedException : DevAgeApplicationException
{
	public ValueNotSupportedException(string value, Type type)
		: base("Value " + value + " not supported, type is " + type.Name)
	{
	}

	protected ValueNotSupportedException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
