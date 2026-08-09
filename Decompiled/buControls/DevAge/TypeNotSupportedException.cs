using System;

namespace DevAge;

[Serializable]
public class TypeNotSupportedException : DevAgeApplicationException
{
	public TypeNotSupportedException(Type pType)
		: base("Type " + pType.ToString() + " not supported exception")
	{
	}

	public TypeNotSupportedException(Type pType, Exception p_InnerException)
		: base("Type " + pType.ToString() + " not supported exception", p_InnerException)
	{
	}
}
