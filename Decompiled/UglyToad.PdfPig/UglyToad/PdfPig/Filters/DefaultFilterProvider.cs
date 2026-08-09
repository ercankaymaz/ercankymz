using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public sealed class DefaultFilterProvider : BaseFilterProvider
{
	public static readonly IFilterProvider Instance = new DefaultFilterProvider();

	private DefaultFilterProvider()
		: base(GetDictionary())
	{
	}

	private static Dictionary<string, IFilter> GetDictionary()
	{
		Ascii85Filter value = new Ascii85Filter();
		AsciiHexDecodeFilter value2 = new AsciiHexDecodeFilter();
		CcittFaxDecodeFilter value3 = new CcittFaxDecodeFilter();
		DctDecodeFilter value4 = new DctDecodeFilter();
		FlateFilter value5 = new FlateFilter();
		Jbig2DecodeFilter value6 = new Jbig2DecodeFilter();
		JpxDecodeFilter value7 = new JpxDecodeFilter();
		RunLengthFilter value8 = new RunLengthFilter();
		LzwFilter value9 = new LzwFilter();
		return new Dictionary<string, IFilter>
		{
			{
				NameToken.Ascii85Decode.Data,
				value
			},
			{
				NameToken.Ascii85DecodeAbbreviation.Data,
				value
			},
			{
				NameToken.AsciiHexDecode.Data,
				value2
			},
			{
				NameToken.AsciiHexDecodeAbbreviation.Data,
				value2
			},
			{
				NameToken.CcittfaxDecode.Data,
				value3
			},
			{
				NameToken.CcittfaxDecodeAbbreviation.Data,
				value3
			},
			{
				NameToken.DctDecode.Data,
				value4
			},
			{
				NameToken.DctDecodeAbbreviation.Data,
				value4
			},
			{
				NameToken.FlateDecode.Data,
				value5
			},
			{
				NameToken.FlateDecodeAbbreviation.Data,
				value5
			},
			{
				NameToken.Jbig2Decode.Data,
				value6
			},
			{
				NameToken.JpxDecode.Data,
				value7
			},
			{
				NameToken.RunLengthDecode.Data,
				value8
			},
			{
				NameToken.RunLengthDecodeAbbreviation.Data,
				value8
			},
			{
				NameToken.LzwDecode.Data,
				value9
			},
			{
				NameToken.LzwDecodeAbbreviation.Data,
				value9
			}
		};
	}
}
