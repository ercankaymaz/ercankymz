using System;
using System.Runtime.Serialization;

namespace DevAge.Text.FixedLength;

[Serializable]
public class FieldNotDefinedException : DevAgeApplicationException
{
	public FieldNotDefinedException(int fieldIndex)
		: base("Field " + fieldIndex + " not defined.")
	{
	}

	protected FieldNotDefinedException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
