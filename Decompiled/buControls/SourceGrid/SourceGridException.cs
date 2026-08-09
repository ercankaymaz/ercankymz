using System;
using System.Runtime.Serialization;

namespace SourceGrid;

[Serializable]
public class SourceGridException : ApplicationException
{
	public SourceGridException(string p_strErrDescription)
		: base(p_strErrDescription)
	{
	}

	public SourceGridException(string p_strErrDescription, Exception p_InnerException)
		: base(p_strErrDescription, p_InnerException)
	{
	}

	protected SourceGridException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
