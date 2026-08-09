using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Util;

internal static class ColorSpaceDetailsParser
{
	public static ColorSpaceDetails GetColorSpaceDetails(ColorSpace? colorSpace, DictionaryToken imageDictionary, IPdfTokenScanner scanner, IResourceStore resourceStore, ILookupFilterProvider filterProvider, bool cannotRecurse = false)
	{
		if ((imageDictionary.TryGet<BooleanToken>(NameToken.ImageMask, scanner, out BooleanToken token) && token.Data) || (imageDictionary.TryGet<BooleanToken>(NameToken.Im, scanner, out BooleanToken token2) && token2.Data) || filterProvider.GetFilters(imageDictionary, scanner).OfType<CcittFaxDecodeFilter>().Any())
		{
			if (cannotRecurse)
			{
				return DeviceGrayColorSpaceDetails.Instance;
			}
			return IndexedColorSpaceDetails.Stencil(GetColorSpaceDetails(colorSpace, imageDictionary.Without(NameToken.Filter).Without(NameToken.F), scanner, resourceStore, filterProvider, cannotRecurse: true));
		}
		if (!colorSpace.HasValue)
		{
			return UnsupportedColorSpaceDetails.Instance;
		}
		switch (colorSpace.Value)
		{
		case ColorSpace.DeviceGray:
			return DeviceGrayColorSpaceDetails.Instance;
		case ColorSpace.DeviceRGB:
			return DeviceRgbColorSpaceDetails.Instance;
		case ColorSpace.DeviceCMYK:
			return DeviceCmykColorSpaceDetails.Instance;
		case ColorSpace.CalGray:
		{
			if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray8) || colorSpaceArray8.Length != 2)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!(colorSpaceArray8[0] is NameToken name8) || !ColorSpaceMapper.TryMap(name8, resourceStore, out var colorSpaceResult13) || colorSpaceResult13 != ColorSpace.CalGray)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<DictionaryToken>(colorSpaceArray8[1], scanner, out DictionaryToken tokenResult23) || !tokenResult23.TryGet<ArrayToken>(NameToken.WhitePoint, scanner, out ArrayToken token17))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			double[] whitePoint3 = (from x in token17.Data.OfType<NumericToken>()
				select x.Double).ToArray();
			double[] blackPoint3 = null;
			if (tokenResult23.TryGet<ArrayToken>(NameToken.BlackPoint, scanner, out ArrayToken token18))
			{
				blackPoint3 = (from x in token18.Data.OfType<NumericToken>()
					select x.Double).ToArray();
			}
			double? gamma2 = null;
			if (tokenResult23.TryGet<NumericToken>(NameToken.Gamma, scanner, out NumericToken token19))
			{
				gamma2 = token19.Double;
			}
			return new CalGrayColorSpaceDetails(whitePoint3, blackPoint3, gamma2);
		}
		case ColorSpace.CalRGB:
		{
			if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray6) || colorSpaceArray6.Length != 2)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!(colorSpaceArray6[0] is NameToken name7) || !ColorSpaceMapper.TryMap(name7, resourceStore, out var colorSpaceResult11) || colorSpaceResult11 != ColorSpace.CalRGB)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<DictionaryToken>(colorSpaceArray6[1], scanner, out DictionaryToken tokenResult20) || !tokenResult20.TryGet<ArrayToken>(NameToken.WhitePoint, scanner, out ArrayToken token13))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			double[] whitePoint2 = (from x in token13.Data.OfType<NumericToken>()
				select x.Double).ToArray();
			double[] blackPoint2 = null;
			if (tokenResult20.TryGet<ArrayToken>(NameToken.BlackPoint, scanner, out ArrayToken token14))
			{
				blackPoint2 = (from x in token14.Data.OfType<NumericToken>()
					select x.Double).ToArray();
			}
			double[] gamma = null;
			if (tokenResult20.TryGet<ArrayToken>(NameToken.Gamma, scanner, out ArrayToken token15))
			{
				gamma = (from x in token15.Data.OfType<NumericToken>()
					select x.Double).ToArray();
			}
			double[] matrix2 = null;
			if (tokenResult20.TryGet<ArrayToken>(NameToken.Matrix, scanner, out ArrayToken token16))
			{
				matrix2 = (from x in token16.Data.OfType<NumericToken>()
					select x.Double).ToArray();
			}
			return new CalRGBColorSpaceDetails(whitePoint2, blackPoint2, gamma, matrix2);
		}
		case ColorSpace.Lab:
		{
			if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray2) || colorSpaceArray2.Length != 2)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!(colorSpaceArray2[0] is NameToken name2) || !ColorSpaceMapper.TryMap(name2, resourceStore, out var colorSpaceResult3) || colorSpaceResult3 != ColorSpace.Lab)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<DictionaryToken>(colorSpaceArray2[1], scanner, out DictionaryToken tokenResult6) || !tokenResult6.TryGet<ArrayToken>(NameToken.WhitePoint, scanner, out ArrayToken token3))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			double[] whitePoint = (from x in token3.Data.OfType<NumericToken>()
				select x.Double).ToArray();
			double[] blackPoint = null;
			if (tokenResult6.TryGet<ArrayToken>(NameToken.BlackPoint, scanner, out ArrayToken token4))
			{
				blackPoint = (from x in token4.Data.OfType<NumericToken>()
					select x.Double).ToArray();
			}
			double[] matrix = null;
			if (tokenResult6.TryGet<ArrayToken>(NameToken.Matrix, scanner, out ArrayToken token5))
			{
				matrix = (from x in token5.Data.OfType<NumericToken>()
					select x.Double).ToArray();
			}
			return new LabColorSpaceDetails(whitePoint, blackPoint, matrix);
		}
		case ColorSpace.ICCBased:
		{
			if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray5) || colorSpaceArray5.Length != 2)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!(colorSpaceArray5[0] is NameToken name6) || !ColorSpaceMapper.TryMap(name6, resourceStore, out var colorSpaceResult9) || colorSpaceResult9 != ColorSpace.ICCBased)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<StreamToken>(colorSpaceArray5[1], scanner, out StreamToken tokenResult19) || !tokenResult19.StreamDictionary.TryGet<NumericToken>(NameToken.N, scanner, out NumericToken token9))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			ColorSpaceDetails alternateColorSpaceDetails = null;
			if (tokenResult19.StreamDictionary.TryGet(NameToken.Alternate, out NameToken token10) && ColorSpaceMapper.TryMap(token10, resourceStore, out var colorSpaceResult10))
			{
				alternateColorSpaceDetails = GetColorSpaceDetails(colorSpaceResult10, imageDictionary, scanner, resourceStore, filterProvider, cannotRecurse: true);
			}
			double[] range = null;
			if (tokenResult19.StreamDictionary.TryGet<ArrayToken>(NameToken.Range, scanner, out ArrayToken token11))
			{
				range = (from x in token11.Data.OfType<NumericToken>()
					select x.Double).ToArray();
			}
			XmpMetadata metadata = null;
			if (tokenResult19.StreamDictionary.TryGet<StreamToken>(NameToken.Metadata, scanner, out StreamToken token12))
			{
				metadata = new XmpMetadata(token12, filterProvider, scanner);
			}
			return new ICCBasedColorSpaceDetails(token9.Int, alternateColorSpaceDetails, range, metadata);
		}
		case ColorSpace.Indexed:
		{
			if (cannotRecurse)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray3) || colorSpaceArray3.Length != 4)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!(colorSpaceArray3[0] is NameToken name3) || !ColorSpaceMapper.TryMap(name3, resourceStore, out var colorSpaceResult4) || colorSpaceResult4 != ColorSpace.Indexed)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			IToken token6 = colorSpaceArray3[1];
			ColorSpaceDetails colorSpaceDetails2;
			if (DirectObjectFinder.TryGet<NameToken>(token6, scanner, out NameToken tokenResult7) && ColorSpaceMapper.TryMap(tokenResult7, resourceStore, out var colorSpaceResult5))
			{
				colorSpaceDetails2 = GetColorSpaceDetails(colorSpaceResult5, imageDictionary, scanner, resourceStore, filterProvider, cannotRecurse: true);
			}
			else
			{
				if (!DirectObjectFinder.TryGet<ArrayToken>(token6, scanner, out ArrayToken tokenResult8) || tokenResult8.Length <= 0 || !(tokenResult8[0] is NameToken name4) || !ColorSpaceMapper.TryMap(name4, resourceStore, out var colorSpaceResult6))
				{
					return UnsupportedColorSpaceDetails.Instance;
				}
				DictionaryToken imageDictionary3 = new DictionaryToken(new Dictionary<NameToken, IToken> { 
				{
					NameToken.ColorSpace,
					tokenResult8
				} });
				colorSpaceDetails2 = GetColorSpaceDetails(colorSpaceResult6, imageDictionary3, scanner, resourceStore, filterProvider, cannotRecurse: true);
			}
			if (colorSpaceDetails2 is UnsupportedColorSpaceDetails)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<NumericToken>(colorSpaceArray3[2], scanner, out NumericToken tokenResult9))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			int num = tokenResult9.Int;
			IToken token7 = colorSpaceArray3[3];
			byte[] colorTable;
			StreamToken tokenResult11;
			if (DirectObjectFinder.TryGet<HexToken>(token7, scanner, out HexToken tokenResult10))
			{
				colorTable = tokenResult10.Bytes.ToArray();
			}
			else if (DirectObjectFinder.TryGet<StreamToken>(token7, scanner, out tokenResult11))
			{
				colorTable = tokenResult11.Decode(filterProvider, scanner).Span.ToArray();
			}
			else
			{
				if (!DirectObjectFinder.TryGet<StringToken>(token7, scanner, out StringToken tokenResult12))
				{
					return UnsupportedColorSpaceDetails.Instance;
				}
				colorTable = tokenResult12.GetBytes();
			}
			return new IndexedColorSpaceDetails(colorSpaceDetails2, (byte)num, colorTable);
		}
		case ColorSpace.Pattern:
		{
			if (cannotRecurse)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			ColorSpaceDetails underlyingColourSpace = UnsupportedColorSpaceDetails.Instance;
			if (imageDictionary.Data.Count > 0)
			{
				if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray7) || (colorSpaceArray7.Length != 1 && colorSpaceArray7.Length != 2))
				{
					return UnsupportedColorSpaceDetails.Instance;
				}
				if (!DirectObjectFinder.TryGet<NameToken>(colorSpaceArray7[0], scanner, out NameToken tokenResult21) || !tokenResult21.Equals(NameToken.Pattern))
				{
					return UnsupportedColorSpaceDetails.Instance;
				}
				if (colorSpaceArray7.Length > 1 && DirectObjectFinder.TryGet<NameToken>(colorSpaceArray7[1], scanner, out NameToken tokenResult22) && ColorSpaceMapper.TryMap(tokenResult22, resourceStore, out var colorSpaceResult12))
				{
					underlyingColourSpace = GetColorSpaceDetails(colorSpaceResult12, imageDictionary, scanner, resourceStore, filterProvider, cannotRecurse: true);
				}
			}
			return new PatternColorSpaceDetails(resourceStore.GetPatterns(), underlyingColourSpace);
		}
		case ColorSpace.Separation:
		{
			if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray4) || colorSpaceArray4.Length != 4)
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<NameToken>(colorSpaceArray4[0], scanner, out NameToken tokenResult13) || !tokenResult13.Equals(NameToken.Separation))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<NameToken>(colorSpaceArray4[1], scanner, out NameToken tokenResult14))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			ColorSpaceDetails colorSpaceDetails3;
			if (DirectObjectFinder.TryGet<NameToken>(colorSpaceArray4[2], scanner, out NameToken tokenResult15) && ColorSpaceMapper.TryMap(tokenResult15, resourceStore, out var colorSpaceResult7))
			{
				colorSpaceDetails3 = GetColorSpaceDetails(colorSpaceResult7, imageDictionary, scanner, resourceStore, filterProvider, cannotRecurse: true);
			}
			else
			{
				if (!DirectObjectFinder.TryGet<ArrayToken>(colorSpaceArray4[2], scanner, out ArrayToken tokenResult16) || tokenResult16.Length <= 0 || !(tokenResult16[0] is NameToken name5) || !ColorSpaceMapper.TryMap(name5, resourceStore, out var colorSpaceResult8))
				{
					return UnsupportedColorSpaceDetails.Instance;
				}
				DictionaryToken imageDictionary4 = new DictionaryToken(new Dictionary<NameToken, IToken> { 
				{
					NameToken.ColorSpace,
					tokenResult16
				} });
				colorSpaceDetails3 = GetColorSpaceDetails(colorSpaceResult8, imageDictionary4, scanner, resourceStore, filterProvider, cannotRecurse: true);
			}
			IToken token8 = colorSpaceArray4[3];
			PdfFunction tintFunction2;
			if (DirectObjectFinder.TryGet<DictionaryToken>(token8, scanner, out DictionaryToken tokenResult17))
			{
				tintFunction2 = PdfFunctionParser.Create(tokenResult17, scanner, filterProvider);
			}
			else
			{
				if (!DirectObjectFinder.TryGet<StreamToken>(token8, scanner, out StreamToken tokenResult18))
				{
					return UnsupportedColorSpaceDetails.Instance;
				}
				tintFunction2 = PdfFunctionParser.Create(tokenResult18, scanner, filterProvider);
			}
			return new SeparationColorSpaceDetails(tokenResult14, colorSpaceDetails3, tintFunction2);
		}
		case ColorSpace.DeviceN:
		{
			if (!TryGetColorSpaceArray(imageDictionary, resourceStore, scanner, out ArrayToken colorSpaceArray) || (colorSpaceArray.Length != 4 && colorSpaceArray.Length != 5))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<NameToken>(colorSpaceArray[0], scanner, out NameToken tokenResult) || !tokenResult.Equals(NameToken.Devicen))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			if (!DirectObjectFinder.TryGet<ArrayToken>(colorSpaceArray[1], scanner, out ArrayToken tokenResult2))
			{
				return UnsupportedColorSpaceDetails.Instance;
			}
			ColorSpaceDetails colorSpaceDetails;
			if (DirectObjectFinder.TryGet<NameToken>(colorSpaceArray[2], scanner, out NameToken tokenResult3) && ColorSpaceMapper.TryMap(tokenResult3, resourceStore, out var colorSpaceResult))
			{
				colorSpaceDetails = GetColorSpaceDetails(colorSpaceResult, imageDictionary, scanner, resourceStore, filterProvider, cannotRecurse: true);
			}
			else
			{
				if (!DirectObjectFinder.TryGet<ArrayToken>(colorSpaceArray[2], scanner, out ArrayToken tokenResult4) || tokenResult4.Length <= 0 || !(tokenResult4[0] is NameToken name) || !ColorSpaceMapper.TryMap(name, resourceStore, out var colorSpaceResult2))
				{
					return UnsupportedColorSpaceDetails.Instance;
				}
				DictionaryToken imageDictionary2 = new DictionaryToken(new Dictionary<NameToken, IToken> { 
				{
					NameToken.ColorSpace,
					tokenResult4
				} });
				colorSpaceDetails = GetColorSpaceDetails(colorSpaceResult2, imageDictionary2, scanner, resourceStore, filterProvider, cannotRecurse: true);
			}
			PdfFunction tintFunction = PdfFunctionParser.Create(colorSpaceArray[3], scanner, filterProvider);
			if (colorSpaceArray.Length > 4 && DirectObjectFinder.TryGet<DictionaryToken>(colorSpaceArray[4], scanner, out DictionaryToken tokenResult5))
			{
				NameToken subtype = NameToken.Devicen;
				if (tokenResult5.ContainsKey(NameToken.Subtype))
				{
					subtype = tokenResult5.Get<NameToken>(NameToken.Subtype, scanner);
				}
				DictionaryToken colorants = null;
				if (tokenResult5.ContainsKey(NameToken.Colorants))
				{
					colorants = tokenResult5.Get<DictionaryToken>(NameToken.Colorants, scanner);
				}
				DictionaryToken process = null;
				if (tokenResult5.ContainsKey(NameToken.Process))
				{
					process = tokenResult5.Get<DictionaryToken>(NameToken.Process, scanner);
				}
				DictionaryToken mixingHints = null;
				if (tokenResult5.ContainsKey(NameToken.MixingHints))
				{
					mixingHints = tokenResult5.Get<DictionaryToken>(NameToken.MixingHints, scanner);
				}
				return new DeviceNColorSpaceDetails(attributes: new DeviceNColorSpaceDetails.DeviceNColorSpaceAttributes(subtype, colorants, process, mixingHints), names: tokenResult2.Data.OfType<NameToken>().ToArray(), alternateColorSpaceDetails: colorSpaceDetails, tintFunction: tintFunction);
			}
			return new DeviceNColorSpaceDetails(tokenResult2.Data.OfType<NameToken>().ToArray(), colorSpaceDetails, tintFunction);
		}
		default:
			return UnsupportedColorSpaceDetails.Instance;
		}
	}

	private static bool TryGetColorSpaceArray(DictionaryToken imageDictionary, IResourceStore resourceStore, IPdfTokenScanner scanner, [NotNullWhen(true)] out ArrayToken? colorSpaceArray)
	{
		IToken objectOrDefault = imageDictionary.GetObjectOrDefault(NameToken.ColorSpace, NameToken.Cs);
		if (!DirectObjectFinder.TryGet<ArrayToken>(objectOrDefault, scanner, out colorSpaceArray) && DirectObjectFinder.TryGet<NameToken>(objectOrDefault, scanner, out NameToken tokenResult) && resourceStore.TryGetNamedColorSpace(tokenResult, out var namedColorSpace))
		{
			colorSpaceArray = namedColorSpace.Data as ArrayToken;
		}
		return colorSpaceArray != null;
	}
}
