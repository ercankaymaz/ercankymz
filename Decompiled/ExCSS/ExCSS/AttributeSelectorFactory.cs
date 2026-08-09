using System;
using System.Collections.Generic;

namespace ExCSS;

public sealed class AttributeSelectorFactory
{
	private static readonly Lazy<AttributeSelectorFactory> Lazy = new Lazy<AttributeSelectorFactory>(() => new AttributeSelectorFactory());

	private readonly Dictionary<string, Type> _types = new Dictionary<string, Type>
	{
		{
			Combinators.Exactly,
			typeof(AttrMatchSelector)
		},
		{
			Combinators.InList,
			typeof(AttrListSelector)
		},
		{
			Combinators.InToken,
			typeof(AttrHyphenSelector)
		},
		{
			Combinators.Begins,
			typeof(AttrBeginsSelector)
		},
		{
			Combinators.Ends,
			typeof(AttrEndsSelector)
		},
		{
			Combinators.InText,
			typeof(AttrContainsSelector)
		},
		{
			Combinators.Unlike,
			typeof(AttrNotMatchSelector)
		}
	};

	internal static AttributeSelectorFactory Instance => Lazy.Value;

	private AttributeSelectorFactory()
	{
	}

	public IAttrSelector Create(string combinator, string match, string value, string prefix)
	{
		string text = match;
		if (!string.IsNullOrEmpty(prefix))
		{
			text = FormFront(prefix, match);
			FormMatch(prefix, match);
		}
		if (!_types.TryGetValue(combinator, out var value2))
		{
			return new AttrAvailableSelector(text, value);
		}
		return (IAttrSelector)Activator.CreateInstance(value2, text, value);
	}

	private string FormFront(string prefix, string match)
	{
		return prefix + Combinators.Pipe + match;
	}

	private string FormMatch(string prefix, string match)
	{
		if (!prefix.Is(Keywords.Asterisk))
		{
			return prefix + PseudoClassNames.Separator + match;
		}
		return match;
	}
}
