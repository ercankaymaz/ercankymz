using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.XObjects;

namespace UglyToad.PdfPig.Graphics;

public sealed class InlineImageBuilder
{
	public IReadOnlyDictionary<NameToken, IToken>? Properties { get; internal set; }

	public Memory<byte> Bytes { get; internal set; }

	internal InlineImage CreateInlineImage(in TransformationMatrix transformationMatrix, ILookupFilterProvider filterProvider, IPdfTokenScanner tokenScanner, RenderingIntent defaultRenderingIntent, IResourceStore resourceStore)
	{
		if (Properties == null)
		{
			throw new InvalidOperationException("Inline image builder not completely defined before calling CreateInlineImage.");
		}
		PdfRectangle bounds = transformationMatrix.Transform(new PdfRectangle(new PdfPoint(1, 1), new PdfPoint(0, 0)));
		int widthInSamples = GetByKeys<NumericToken>(NameToken.Width, NameToken.W, required: true).Int;
		int heightInSamples = GetByKeys<NumericToken>(NameToken.Height, NameToken.H, required: true).Int;
		bool flag = GetByKeys<BooleanToken>(NameToken.ImageMask, NameToken.Im, required: false)?.Data ?? false;
		int bitsPerComponent = GetByKeys<NumericToken>(NameToken.BitsPerComponent, NameToken.Bpc, !flag)?.Int ?? 1;
		NameToken nameToken = null;
		DictionaryToken dictionaryToken = new DictionaryToken(Properties ?? new Dictionary<NameToken, IToken>()).Resolve(tokenScanner);
		XObjectImage softMaskImage = null;
		if (dictionaryToken.TryGet<StreamToken>(NameToken.Smask, tokenScanner, out StreamToken token))
		{
			if (!token.StreamDictionary.TryGet(NameToken.Subtype, out NameToken token2) || !token2.Equals(NameToken.Image))
			{
				throw new Exception("The SMask dictionary does not contain a 'Subtype' entry, or its value is not 'Image'.");
			}
			if (!token.StreamDictionary.TryGet(NameToken.ColorSpace, out NameToken token3) || !token3.Equals(NameToken.Devicegray))
			{
				throw new Exception("The SMask dictionary does not contain a 'ColorSpace' entry, or its value is not 'Devicegray'.");
			}
			if (token.StreamDictionary.ContainsKey(NameToken.Mask) || token.StreamDictionary.ContainsKey(NameToken.Smask))
			{
				throw new Exception("The SMask dictionary contains a 'Mask' or 'Smask' entry.");
			}
			softMaskImage = XObjectFactory.ReadImage(new XObjectContentRecord(XObjectType.Image, token, TransformationMatrix.Identity, defaultRenderingIntent, DeviceGrayColorSpaceDetails.Instance), tokenScanner, filterProvider, resourceStore);
		}
		if (!flag)
		{
			nameToken = GetByKeys<NameToken>(NameToken.ColorSpace, NameToken.Cs, required: false);
			if ((object)nameToken == null)
			{
				ArrayToken byKeys = GetByKeys<ArrayToken>(NameToken.ColorSpace, NameToken.Cs, required: true);
				if (byKeys.Length == 0)
				{
					throw new PdfDocumentFormatException("Empty ColorSpace array defined for inline image.");
				}
				nameToken = (byKeys.Data[0] as NameToken) ?? throw new PdfDocumentFormatException($"Invalid ColorSpace array defined for inline image: {byKeys}.");
			}
		}
		ColorSpaceDetails colorSpaceDetails = resourceStore.GetColorSpaceDetails(nameToken, dictionaryToken);
		RenderingIntent renderingIntent = GetByKeys<NameToken>(NameToken.Intent, null, required: false)?.Data?.ToRenderingIntent() ?? defaultRenderingIntent;
		List<NameToken> list = new List<NameToken>();
		NameToken byKeys2 = GetByKeys<NameToken>(NameToken.Filter, NameToken.F, required: false);
		if ((object)byKeys2 == null)
		{
			ArrayToken byKeys3 = GetByKeys<ArrayToken>(NameToken.Filter, NameToken.F, required: false);
			if (byKeys3 != null)
			{
				list.AddRange(byKeys3.Data.OfType<NameToken>());
			}
		}
		else
		{
			list.Add(byKeys2);
		}
		double[] decode = (from x in (GetByKeys<ArrayToken>(NameToken.Decode, NameToken.D, required: false) ?? new ArrayToken(Array.Empty<IToken>())).Data.OfType<NumericToken>()
			select x.Double).ToArray();
		bool interpolate = GetByKeys<BooleanToken>(NameToken.Interpolate, NameToken.I, required: false)?.Data ?? false;
		return new InlineImage(bounds, widthInSamples, heightInSamples, bitsPerComponent, flag, renderingIntent, interpolate, decode, Bytes, filterProvider, list, dictionaryToken, colorSpaceDetails, softMaskImage);
	}

	private T GetByKeys<T>(NameToken name1, NameToken name2, bool required) where T : class, IToken
	{
		if (Properties.TryGetValue(name1, out IToken value) && value is T result)
		{
			return result;
		}
		if (name2 != null && Properties.TryGetValue(name2, out value) && value is T result2)
		{
			return result2;
		}
		if (required)
		{
			throw new PdfDocumentFormatException($"Inline image dictionary missing required entry {name1}/{name2}.");
		}
		return null;
	}
}
