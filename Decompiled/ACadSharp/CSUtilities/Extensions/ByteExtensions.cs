using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSUtilities.Extensions;

internal static class ByteExtensions
{
	public static string ToHexString(this IEnumerable<byte> array)
	{
		StringBuilder stringBuilder = new StringBuilder(array.Count() * 2);
		foreach (byte item in array)
		{
			stringBuilder.AppendFormat("{0:x2}", item);
		}
		return stringBuilder.ToString().ToUpper();
	}
}
