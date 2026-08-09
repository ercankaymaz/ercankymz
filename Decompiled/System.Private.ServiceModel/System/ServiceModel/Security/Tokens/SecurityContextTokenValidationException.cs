using System.IdentityModel.Tokens;
using System.Runtime.Serialization;

namespace System.ServiceModel.Security.Tokens;

[Serializable]
internal class SecurityContextTokenValidationException : SecurityTokenValidationException
{
	public SecurityContextTokenValidationException()
	{
	}

	public SecurityContextTokenValidationException(string message)
		: base(message)
	{
	}

	public SecurityContextTokenValidationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected SecurityContextTokenValidationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
