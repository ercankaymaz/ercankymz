using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSUtilities.Extensions;

internal static class StringBuilderExtensions
{
	public static StringBuilder AppendJoin<T>(this StringBuilder sb, string? separator, IEnumerable<T> values)
	{
		if (separator == null)
		{
			separator = string.Empty;
		}
		for (int i = 0; i < values.Count(); i++)
		{
			if (i > 0)
			{
				sb.Append(separator);
			}
			sb.Append(values.ElementAt(i));
		}
		return sb;
	}
}
