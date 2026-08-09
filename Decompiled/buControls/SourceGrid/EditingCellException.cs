using System;
using System.Runtime.Serialization;

namespace SourceGrid;

[Serializable]
public class EditingCellException : SourceGridException
{
	public EditingCellException(Exception innerException)
		: base(innerException.Message, innerException)
	{
	}

	protected EditingCellException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
