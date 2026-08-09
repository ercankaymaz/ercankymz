using System;
using System.Text.RegularExpressions;
using DSTV.Net.Contracts;

namespace DSTV.Net.Implementations;

internal class RoughSplitter : ISplitter
{
	internal static Lazy<RoughSplitter> Instance = new Lazy<RoughSplitter>(() => new RoughSplitter());

	public string[] Split(string input)
	{
		Match match = Regex.Match(input, "(?<!\\s|\\D)[a-z]+(?!\\s+|\\D)|\\s+", RegexOptions.None, TimeSpan.FromSeconds(1.0));
		if (!match.Success)
		{
			return new string[1] { input };
		}
		return match.Value.Split(new string[1] { match.Value }, StringSplitOptions.None);
	}
}
