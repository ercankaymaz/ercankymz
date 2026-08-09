using System.ComponentModel;
using System.Runtime.Serialization;

namespace System.DirectoryServices.AccountManagement;

public class NoMatchingPrincipalException : PrincipalException
{
	public NoMatchingPrincipalException()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected NoMatchingPrincipalException(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public NoMatchingPrincipalException(string message)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public NoMatchingPrincipalException(string message, Exception innerException)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
