using System;
using System.Text.RegularExpressions;
using DSTV.Net.Contracts;
using DSTV.Net.Exceptions;
using DSTV.Net.Implementations;

namespace DSTV.Net.Data;

public record DstvElement
{
	protected static string[] GetDataVector(string dstvElementLine, ISplitter splitter)
	{
		if (splitter == null)
		{
			throw new ArgumentNullException("splitter");
		}
		if (Regex.IsMatch(dstvElementLine, "^\\*\\*.*", RegexOptions.None, TimeSpan.FromSeconds(1.0)))
		{
			throw new DstvParseException("Attempt to get data from quote-line detected");
		}
		if (!Regex.IsMatch(dstvElementLine, "^\\s+.*", RegexOptions.None, TimeSpan.FromSeconds(1.0)))
		{
			throw new DstvParseException("Illegal start sequence in data line (must starts with \\\"  \\\")");
		}
		return splitter.Split(dstvElementLine);
	}

	protected static bool ValidateFlange(string flDependMark)
	{
		return Regex.IsMatch(flDependMark, "[ovuh]", RegexOptions.None, TimeSpan.FromSeconds(1.0));
	}

	protected static string[] CorrectSplits(string[] separated, bool skipFirst = false, bool skipLast = false)
	{
		if (separated == null)
		{
			throw new ArgumentNullException("separated");
		}
		for (int i = (skipFirst ? 1 : 0); i < separated.Length - (skipLast ? 1 : 0); i++)
		{
			foreach (Match item in Regex.Matches(separated[i], "([^.\\d-]+)", RegexOptions.ExplicitCapture, TimeSpan.FromSeconds(1.0)))
			{
				separated[i] = PolyfillExtensions.Replace(separated[i], item.Value, string.Empty, StringComparison.Ordinal);
			}
		}
		return BodyReader.RemoveVoids(separated);
	}

	public virtual string ToSvg()
	{
		return string.Empty;
	}
}
