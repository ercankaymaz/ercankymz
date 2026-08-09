using System;
using System.Globalization;

namespace Microsoft.Windows.Design.PropertyEditing;

public class PropertyFilterPredicate
{
	private string _matchText;

	protected string MatchText => _matchText;

	public PropertyFilterPredicate(string matchText)
	{
		if (matchText == null)
		{
			throw new ArgumentNullException("matchText");
		}
		_matchText = matchText.ToUpper(CultureInfo.InvariantCulture);
	}

	public virtual bool Match(string target)
	{
		return target?.ToUpper(CultureInfo.InvariantCulture).Contains(_matchText) ?? false;
	}
}
