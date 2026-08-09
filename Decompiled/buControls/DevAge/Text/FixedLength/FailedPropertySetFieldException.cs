using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class FailedPropertySetFieldException : DevAgeApplicationException
{
	public FailedPropertySetFieldException(string field, Exception innerException)
		: base("Failed to set property for field " + field + " - " + innerException.Message, innerException)
	{
	}

	protected FailedPropertySetFieldException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
