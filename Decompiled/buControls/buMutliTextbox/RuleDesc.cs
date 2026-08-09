using System.Text.RegularExpressions;

namespace buMutliTextbox;

public class RuleDesc
{
	private Regex regex_0;

	public string pattern;

	public RegexOptions options = RegexOptions.None;

	public Style style;

	public Regex Regex
	{
		get
		{
			if (regex_0 == null)
			{
				regex_0 = new Regex(pattern, SyntaxHighlighter.RegexCompiledOption | options);
			}
			return regex_0;
		}
	}
}
