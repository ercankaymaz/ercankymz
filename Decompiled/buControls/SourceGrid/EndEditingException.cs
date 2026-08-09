using System;
using System.Runtime.Serialization;

namespace SourceGrid;

[Serializable]
public class EndEditingException : SourceGridException
{
	public EndEditingException(Exception innerException)
		: base(innerException.Message, innerException)
	{
	}

	protected EndEditingException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
