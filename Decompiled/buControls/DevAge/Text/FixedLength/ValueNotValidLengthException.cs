using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class ValueNotValidLengthException : DevAgeApplicationException
{
	public ValueNotValidLengthException(string value, int expectedLength)
		: base("Value " + value + " not valid, length must be " + expectedLength)
	{
	}

	protected ValueNotValidLengthException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
