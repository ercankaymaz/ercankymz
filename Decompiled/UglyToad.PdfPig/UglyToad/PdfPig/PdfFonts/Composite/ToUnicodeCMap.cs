using System;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.PdfFonts.Cmap;

namespace UglyToad.PdfPig.PdfFonts.Composite;

internal sealed class ToUnicodeCMap
{
	private readonly CMap? cMap;

	public bool CanMapToUnicode => cMap != null;

	public bool IsUsingIdentityAsUnicodeMap { get; }

	public ToUnicodeCMap(CMap? cMap)
	{
		this.cMap = cMap;
		if (cMap != null)
		{
			IsUsingIdentityAsUnicodeMap = cMap.Name?.StartsWith("Identity-", StringComparison.InvariantCultureIgnoreCase) ?? false;
		}
	}

	public bool TryGet(int code, [NotNullWhen(true)] out string? value)
	{
		value = null;
		if (cMap == null)
		{
			return false;
		}
		return cMap.TryConvertToUnicode(code, out value);
	}

	public int ReadCode(IInputBytes inputBytes, bool useLenientParsing)
	{
		return cMap.ReadCode(inputBytes, useLenientParsing);
	}
}
