using System;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Images;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.XObjects;

public static class XObjectFactory
{
	public static XObjectImage ReadImage(XObjectContentRecord xObject, IPdfTokenScanner pdfScanner, ILookupFilterProvider filterProvider, IResourceStore resourceStore)
	{
		if (xObject == null)
		{
			throw new ArgumentNullException("xObject");
		}
		if (xObject.Type != XObjectType.Image)
		{
			throw new InvalidOperationException($"Cannot create an image from an XObject with type: {xObject.Type}.");
		}
		DictionaryToken dictionaryToken = xObject.Stream.StreamDictionary.Resolve(pdfScanner);
		PdfRectangle bounds = xObject.AppliedTransformation.Transform(new PdfRectangle(new PdfPoint(0, 0), new PdfPoint(1, 1)));
		int widthInSamples = dictionaryToken.GetInt(NameToken.Width);
		int heightInSamples = dictionaryToken.GetInt(NameToken.Height);
		BooleanToken token;
		bool flag = dictionaryToken.TryGet(NameToken.ImageMask, out token) && token.Data;
		XObjectImage softMaskImage = null;
		StreamToken token5;
		if (dictionaryToken.TryGet<StreamToken>(NameToken.Smask, pdfScanner, out StreamToken token2))
		{
			if (!token2.StreamDictionary.TryGet(NameToken.Subtype, out NameToken token3) || !token3.Equals(NameToken.Image))
			{
				throw new Exception("The SMask dictionary does not contain a 'Subtype' entry, or its value is not 'Image'.");
			}
			if (!token2.StreamDictionary.TryGet(NameToken.ColorSpace, out NameToken token4) || !token4.Equals(NameToken.Devicegray))
			{
				throw new Exception("The SMask dictionary does not contain a 'ColorSpace' entry, or its value is not 'Devicegray'.");
			}
			if (token2.StreamDictionary.ContainsKey(NameToken.Mask) || token2.StreamDictionary.ContainsKey(NameToken.Smask))
			{
				throw new Exception("The SMask dictionary contains a 'Mask' or 'Smask' entry.");
			}
			softMaskImage = ReadImage(new XObjectContentRecord(XObjectType.Image, token2, TransformationMatrix.Identity, xObject.DefaultRenderingIntent, DeviceGrayColorSpaceDetails.Instance), pdfScanner, filterProvider, resourceStore);
		}
		else if (dictionaryToken.TryGet(NameToken.Mask, out token5))
		{
			softMaskImage = ReadImage(new XObjectContentRecord(XObjectType.Image, token5, TransformationMatrix.Identity, xObject.DefaultRenderingIntent, null), pdfScanner, filterProvider, resourceStore);
		}
		NameToken token6;
		bool flag2 = dictionaryToken.TryGet(NameToken.Filter, out token6) && token6.Equals(NameToken.JpxDecode);
		int bitsPerComponent;
		if (flag)
		{
			bitsPerComponent = 1;
		}
		else if (flag2)
		{
			bitsPerComponent = ((!dictionaryToken.TryGet(NameToken.BitsPerComponent, out NumericToken token7)) ? Jpeg2000Helper.GetBitsPerComponent(xObject.Stream.Data.Span) : token7.Int);
		}
		else
		{
			if (!dictionaryToken.TryGet(NameToken.BitsPerComponent, out NumericToken token8))
			{
				throw new PdfDocumentFormatException($"No bits per component defined for image: {dictionaryToken}.");
			}
			bitsPerComponent = token8.Int;
		}
		RenderingIntent renderingIntent = xObject.DefaultRenderingIntent;
		if (dictionaryToken.TryGet(NameToken.Intent, out NameToken token9))
		{
			renderingIntent = token9.Data.ToRenderingIntent();
		}
		BooleanToken token10;
		bool interpolate = dictionaryToken.TryGet(NameToken.Interpolate, out token10) && token10.Data;
		bool flag3 = true;
		foreach (IFilter filter in filterProvider.GetFilters(dictionaryToken, pdfScanner))
		{
			if (!filter.IsSupported)
			{
				flag3 = false;
				break;
			}
		}
		StreamToken streamToken = new StreamToken(dictionaryToken, xObject.Stream.Data);
		Lazy<Memory<byte>> bytes = (flag3 ? new Lazy<Memory<byte>>(() => streamToken.Decode(filterProvider, pdfScanner)) : null);
		double[] decode = Array.Empty<double>();
		if (dictionaryToken.TryGet(NameToken.Decode, out ArrayToken token11))
		{
			decode = (from x in token11.Data.OfType<NumericToken>()
				select x.Double).ToArray();
		}
		ColorSpaceDetails colorSpaceDetails = null;
		if (!flag)
		{
			ArrayToken token13;
			if (dictionaryToken.TryGet(NameToken.ColorSpace, out NameToken token12))
			{
				colorSpaceDetails = resourceStore.GetColorSpaceDetails(token12, dictionaryToken);
			}
			else if (dictionaryToken.TryGet(NameToken.ColorSpace, out token13) && token13.Length > 0 && token13.Data[0] is NameToken name)
			{
				colorSpaceDetails = resourceStore.GetColorSpaceDetails(name, dictionaryToken);
			}
			else if (!flag2)
			{
				colorSpaceDetails = xObject.DefaultColorSpace;
			}
		}
		else
		{
			colorSpaceDetails = resourceStore.GetColorSpaceDetails(null, dictionaryToken);
		}
		return new XObjectImage(bounds, widthInSamples, heightInSamples, bitsPerComponent, flag2, flag, renderingIntent, interpolate, decode, dictionaryToken, xObject.Stream.Data, bytes, colorSpaceDetails, softMaskImage);
	}
}
