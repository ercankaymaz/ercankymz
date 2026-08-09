using System.Diagnostics;
using System.Runtime.Serialization;

namespace System.ComponentModel.Composition.Primitives;

[Serializable]
[DebuggerTypeProxy(typeof(ComposablePartExceptionDebuggerProxy))]
[DebuggerDisplay("{Message}")]
public class ComposablePartException : Exception
{
	private readonly ICompositionElement _element;

	public ICompositionElement? Element => _element;

	public ComposablePartException()
		: this(null, null, null)
	{
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected ComposablePartException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_element = (ICompositionElement)info.GetValue("Element", typeof(ICompositionElement));
	}

	public ComposablePartException(string? message)
		: this(message, null, null)
	{
	}

	public ComposablePartException(string? message, ICompositionElement? element)
		: this(message, element, null)
	{
	}

	public ComposablePartException(string? message, Exception? innerException)
		: this(message, null, innerException)
	{
	}

	public ComposablePartException(string? message, ICompositionElement? element, Exception? innerException)
		: base(message, innerException)
	{
		_element = element;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("Element", _element.ToSerializableElement());
	}
}
