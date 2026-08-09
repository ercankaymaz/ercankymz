using System.ComponentModel;
using System.Runtime.Serialization;

namespace System.DirectoryServices.Protocols;

public class DirectoryOperationException : DirectoryException, ISerializable
{
	public DirectoryResponse Response
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public DirectoryOperationException()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public DirectoryOperationException(DirectoryResponse response)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public DirectoryOperationException(DirectoryResponse response, string message)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public DirectoryOperationException(DirectoryResponse response, string message, Exception inner)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected DirectoryOperationException(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public DirectoryOperationException(string message)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public DirectoryOperationException(string message, Exception inner)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
