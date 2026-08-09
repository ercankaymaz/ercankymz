using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.Composition.Primitives;

[Serializable]
internal sealed class SerializableCompositionElement : ICompositionElement
{
	private readonly string _displayName;

	private readonly ICompositionElement _origin;

	public string DisplayName => _displayName;

	public ICompositionElement? Origin => _origin;

	public SerializableCompositionElement(string displayName, ICompositionElement? origin)
	{
		_displayName = displayName;
		_origin = origin;
	}

	public override string ToString()
	{
		return _displayName;
	}

	[return: NotNullIfNotNull("element")]
	public static ICompositionElement? FromICompositionElement(ICompositionElement? element)
	{
		if (element == null)
		{
			return null;
		}
		ICompositionElement origin = FromICompositionElement(element.Origin);
		return new SerializableCompositionElement(element.DisplayName, origin);
	}
}
