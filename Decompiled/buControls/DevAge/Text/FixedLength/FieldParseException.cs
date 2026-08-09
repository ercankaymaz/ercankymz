using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class FieldParseException : DevAgeApplicationException
{
	public FieldParseException(string name, string valToParse, Exception innerException)
		: base("Failed to parse field " + name + " '" + valToParse + "' - " + innerException.Message, innerException)
	{
	}

	protected FieldParseException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
