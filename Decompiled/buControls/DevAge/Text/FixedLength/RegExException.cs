using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class RegExException : DevAgeApplicationException
{
	public RegExException(string group)
		: base("Regular expression group " + group + " not valid")
	{
	}

	protected RegExException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
