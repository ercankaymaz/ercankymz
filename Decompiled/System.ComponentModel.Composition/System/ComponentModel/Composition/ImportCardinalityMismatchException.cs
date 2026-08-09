using System.Diagnostics;
using System.Runtime.Serialization;

namespace System.ComponentModel.Composition;

[Serializable]
[DebuggerTypeProxy(typeof(ImportCardinalityMismatchExceptionDebuggerProxy))]
[DebuggerDisplay("{Message}")]
public class ImportCardinalityMismatchException : Exception
{
	public ImportCardinalityMismatchException()
		: this(null, null)
	{
	}

	public ImportCardinalityMismatchException(string? message)
		: this(message, null)
	{
	}

	public ImportCardinalityMismatchException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected ImportCardinalityMismatchException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
