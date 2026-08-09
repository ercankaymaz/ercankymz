using System;
using System.Collections.Generic;
using System.Linq;

namespace ExCSS;

public sealed class PseudoElementSelectorFactory
{
	private static readonly Lazy<PseudoElementSelectorFactory> Lazy = new Lazy<PseudoElementSelectorFactory>(() => new PseudoElementSelectorFactory());

	private readonly Dictionary<string, ISelector> _selectors = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		PseudoElementNames.Before,
		PseudoElementNames.After,
		PseudoElementNames.Selection,
		PseudoElementNames.FirstLine,
		PseudoElementNames.FirstLetter,
		PseudoElementNames.Content
	}.ToDictionary((string x) => x, PseudoElementSelector.Create);

	internal static PseudoElementSelectorFactory Instance => Lazy.Value;

	private PseudoElementSelectorFactory()
	{
	}

	public ISelector Create(string name)
	{
		if (!_selectors.TryGetValue(name, out var value))
		{
			return null;
		}
		return value;
	}
}
