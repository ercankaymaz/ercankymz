using System.Diagnostics;

namespace System.ComponentModel.Composition.Primitives;

[DebuggerTypeProxy(typeof(CompositionElementDebuggerProxy))]
internal sealed class CompositionElement : ICompositionElement
{
	private readonly string _displayName;

	private readonly ICompositionElement _origin;

	private readonly object _underlyingObject;

	private static readonly ICompositionElement UnknownOrigin = new CompositionElement(System.SR.CompositionElement_UnknownOrigin, null);

	public string DisplayName => _displayName;

	public ICompositionElement? Origin => _origin;

	public object? UnderlyingObject => _underlyingObject;

	public CompositionElement(object underlyingObject)
		: this(underlyingObject.ToString(), UnknownOrigin)
	{
		_underlyingObject = underlyingObject;
	}

	public CompositionElement(string? displayName, ICompositionElement? origin)
	{
		_displayName = displayName ?? string.Empty;
		_origin = origin;
	}

	public override string ToString()
	{
		return DisplayName;
	}
}
