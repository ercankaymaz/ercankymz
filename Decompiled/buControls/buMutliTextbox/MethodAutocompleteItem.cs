using System;

namespace buMutliTextbox;

public class MethodAutocompleteItem : AutocompleteItem
{
	private string string_0;

	private string string_1;

	public MethodAutocompleteItem(string text)
		: base(text)
	{
		string_1 = Text.ToLower();
	}

	public override CompareResult Compare(string fragmentText)
	{
		int num = fragmentText.LastIndexOf('.');
		if (num >= 0)
		{
			string text = fragmentText.Substring(num + 1);
			string_0 = fragmentText.Substring(0, num);
			if (!(text == ""))
			{
				if (!Text.StartsWith(text, StringComparison.InvariantCultureIgnoreCase))
				{
					if (!string_1.Contains(text.ToLower()))
					{
						return CompareResult.Hidden;
					}
					return CompareResult.Visible;
				}
				return CompareResult.VisibleAndSelected;
			}
			return CompareResult.Visible;
		}
		return CompareResult.Hidden;
	}

	public override string GetTextForReplace()
	{
		return string_0 + "." + Text;
	}
}
