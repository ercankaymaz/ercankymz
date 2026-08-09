using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ns54;

namespace buPop3.Mime.Decode;

public static class EncodingFinder
{
	public delegate Encoding FallbackDecoderDelegate(string characterSet);

	[CompilerGenerated]
	private static FallbackDecoderDelegate fallbackDecoderDelegate_0;

	[CompilerGenerated]
	private static Dictionary<string, Encoding> dictionary_0;

	public static FallbackDecoderDelegate FallbackDecoder
	{
		[CompilerGenerated]
		internal get
		{
			return fallbackDecoderDelegate_0;
		}
		[CompilerGenerated]
		set
		{
			fallbackDecoderDelegate_0 = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal static Dictionary<string, Encoding> smethod_0()
	{
		return dictionary_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal static void smethod_1(Dictionary<string, Encoding> dictionary_1)
	{
		dictionary_0 = dictionary_1;
	}

	static EncodingFinder()
	{
		Class156.smethod_283();
	}

	public static void AddMapping(string characterSet, Encoding encoding)
	{
		if (characterSet != null)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			smethod_0().Add(characterSet.ToUpperInvariant(), encoding);
			return;
		}
		throw new ArgumentNullException("characterSet");
	}
}
