using System;

namespace DevAge;

[Serializable]
public class UnrecognizedCommandLineParametersException : DevAgeApplicationException
{
	public UnrecognizedCommandLineParametersException(string parameter)
		: base("Unrecognized command line parameter " + parameter + ".")
	{
	}

	public UnrecognizedCommandLineParametersException(string parameter, Exception p_InnerException)
		: base("Unrecognized command line parameter " + parameter + ".", p_InnerException)
	{
	}
}
