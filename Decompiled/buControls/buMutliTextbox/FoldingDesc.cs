using System.Text.RegularExpressions;

namespace buMutliTextbox;

public class FoldingDesc
{
	public string startMarkerRegex;

	public string finishMarkerRegex;

	public RegexOptions options = RegexOptions.None;
}
