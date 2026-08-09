using System;
using System.Runtime.Serialization;

namespace DevAge.IO;

[Serializable]
public class TypeNotSupportedException : DevAgeApplicationException
{
	public TypeNotSupportedException(Type pType)
		: base("Type not supported: " + pType.ToString())
	{
	}

	public TypeNotSupportedException(string p_strErrDescription)
		: base(p_strErrDescription)
	{
	}

	public TypeNotSupportedException(string p_strErrDescription, Exception p_InnerException)
		: base(p_strErrDescription, p_InnerException)
	{
	}

	protected TypeNotSupportedException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
