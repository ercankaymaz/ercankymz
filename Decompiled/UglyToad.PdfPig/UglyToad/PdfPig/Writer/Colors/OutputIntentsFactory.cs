using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer.Colors;

internal static class OutputIntentsFactory
{
	private const string SrgbIec61966OutputCondition = "sRGB IEC61966-2.1";

	private const string RegistryName = "http://www.color.org";

	public static ArrayToken GetOutputIntentsArray(Func<IToken, IndirectReferenceToken> objectWriter)
	{
		StringToken value = new StringToken("sRGB IEC61966-2.1");
		byte[] array = DataCompresser.CompressBytes(ProfileStreamReader.GetSRgb2014());
		StreamToken arg = new StreamToken(new DictionaryToken(new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Length,
				new NumericToken(array.Length)
			},
			{
				NameToken.N,
				new NumericToken(3)
			},
			{
				NameToken.Filter,
				NameToken.FlateDecode
			}
		}), array);
		IndirectReferenceToken value2 = objectWriter(arg);
		return new ArrayToken(new IToken[1]
		{
			new DictionaryToken(new Dictionary<NameToken, IToken>
			{
				{
					NameToken.Type,
					NameToken.OutputIntent
				},
				{
					NameToken.S,
					NameToken.GtsPdfa1
				},
				{
					NameToken.OutputCondition,
					value
				},
				{
					NameToken.OutputConditionIdentifier,
					value
				},
				{
					NameToken.RegistryName,
					new StringToken("http://www.color.org")
				},
				{
					NameToken.Info,
					value
				},
				{
					NameToken.DestOutputProfile,
					value2
				}
			})
		});
	}
}
