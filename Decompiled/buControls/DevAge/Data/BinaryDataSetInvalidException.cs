using System;

namespace DevAge.Data;

[Serializable]
public class BinaryDataSetInvalidException : DevAgeApplicationException
{
	public BinaryDataSetInvalidException()
		: base("Binary data not valid")
	{
	}

	public BinaryDataSetInvalidException(Exception p_InnerException)
		: base("Binary data not valid", p_InnerException)
	{
	}
}
