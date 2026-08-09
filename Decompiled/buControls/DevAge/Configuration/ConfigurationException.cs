using System;
using System.Runtime.Serialization;

namespace DevAge.Configuration;

[Serializable]
public class ConfigurationException : DevAgeApplicationException
{
	public ConfigurationException(string p_strErrDescription)
		: base(p_strErrDescription)
	{
	}

	public ConfigurationException(string p_strErrDescription, Exception p_InnerException)
		: base(p_strErrDescription, p_InnerException)
	{
	}

	protected ConfigurationException(SerializationInfo p_Info, StreamingContext p_StreamingContext)
		: base(p_Info, p_StreamingContext)
	{
	}
}
