using System.Runtime.Serialization;

namespace System.ComponentModel.Composition;

[Serializable]
public class CompositionContractMismatchException : Exception
{
	public CompositionContractMismatchException()
		: this(null, null)
	{
	}

	public CompositionContractMismatchException(string? message)
		: this(message, null)
	{
	}

	public CompositionContractMismatchException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected CompositionContractMismatchException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
