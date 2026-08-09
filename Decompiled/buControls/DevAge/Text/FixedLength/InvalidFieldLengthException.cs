using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class InvalidFieldLengthException : DevAgeApplicationException
{
	public InvalidFieldLengthException(int length)
		: base("Invalid field length " + length + " must be a positive number.")
	{
	}

	protected InvalidFieldLengthException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
