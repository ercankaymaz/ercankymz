using System;
using System.Runtime.Serialization;
using ns27;

namespace DevAge.Text.FixedLength;

[Serializable]
public class FieldStringConvertException : DevAgeApplicationException
{
	public FieldStringConvertException(string name, object value, Exception innerException)
		: base("Failed to convert to string field " + name + " '" + Class76.smethod_765(value) + "' - " + innerException.Message, innerException)
	{
	}

	protected FieldStringConvertException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
