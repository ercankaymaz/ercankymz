using System;
using System.Runtime.Serialization;

namespace DevAge.IO;

[Serializable]
public class InvalidDataException : DevAgeApplicationException
{
	public InvalidDataException()
		: base("Invalid data exception")
	{
	}

	public InvalidDataException(string p_strErrDescription)
		: base(p_strErrDescription)
	{
	}

	public InvalidDataException(string p_strErrDescription, Exception p_InnerException)
		: base(p_strErrDescription, p_InnerException)
	{
	}

	protected InvalidDataException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
