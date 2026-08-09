using System;

namespace DevAge;

[Serializable]
public class ConversionErrorException : DevAgeApplicationException
{
	public ConversionErrorException(string destinationType, string value, string extendedMessage)
		: base(extendedMessage + ", cannot convert " + value + " to " + destinationType + ".")
	{
	}

	public ConversionErrorException(string destinationType, string value)
		: base("Cannot convert " + value + " to " + destinationType + ".")
	{
	}

	public ConversionErrorException(string destinationType, string value, Exception p_InnerException)
		: base("Cannot convert " + value + " to " + destinationType + ".", p_InnerException)
	{
	}
}
