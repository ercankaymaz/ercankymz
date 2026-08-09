using System;
using System.Runtime.Serialization;

namespace DevAge;

[Serializable]
public class DevAgeApplicationException : ApplicationException
{
	public DevAgeApplicationException(string p_strErrDescription)
		: base(p_strErrDescription)
	{
	}

	public DevAgeApplicationException(string p_strErrDescription, Exception p_InnerException)
		: base(p_strErrDescription, p_InnerException)
	{
	}

	protected DevAgeApplicationException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
