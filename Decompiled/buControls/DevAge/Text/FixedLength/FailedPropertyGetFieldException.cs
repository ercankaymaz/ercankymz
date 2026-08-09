using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class FailedPropertyGetFieldException : DevAgeApplicationException
{
	public FailedPropertyGetFieldException(string field, Exception innerException)
		: base("Failed to get property for field " + field + " - " + innerException.Message, innerException)
	{
	}

	protected FailedPropertyGetFieldException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
