using System;

namespace DevAge.Data;

[Serializable]
public class BinaryDataSetVersionException : DevAgeApplicationException
{
	public BinaryDataSetVersionException()
		: base("Binary data version not valid")
	{
	}

	public BinaryDataSetVersionException(Exception p_InnerException)
		: base("Binary data version not valid", p_InnerException)
	{
	}
}
