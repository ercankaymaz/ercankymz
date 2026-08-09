using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Images.Png;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.XObjects;

public class XObjectImage : IPdfImage
{
	private readonly Lazy<Memory<byte>>? memoryFactory;

	public PdfRectangle Bounds { get; }

	public int WidthInSamples { get; }

	public int HeightInSamples { get; }

	public int BitsPerComponent { get; }

	public bool IsJpxEncoded { get; }

	public RenderingIntent RenderingIntent { get; }

	public bool IsImageMask { get; }

	public IReadOnlyList<double> Decode { get; }

	public bool Interpolate { get; }

	public bool IsInlineImage { get; }

	public DictionaryToken ImageDictionary { get; }

	public Memory<byte> RawMemory { get; }

	public Span<byte> RawBytes => RawMemory.Span;

	public ColorSpaceDetails? ColorSpaceDetails { get; }

	public IPdfImage? MaskImage { get; }

	internal XObjectImage(PdfRectangle bounds, int widthInSamples, int heightInSamples, int bitsPerComponent, bool isJpxEncoded, bool isImageMask, RenderingIntent renderingIntent, bool interpolate, IReadOnlyList<double> decode, DictionaryToken imageDictionary, Memory<byte> rawMemory, Lazy<Memory<byte>>? bytes, ColorSpaceDetails? colorSpaceDetails, IPdfImage? softMaskImage)
	{
		Bounds = bounds;
		WidthInSamples = widthInSamples;
		HeightInSamples = heightInSamples;
		BitsPerComponent = bitsPerComponent;
		IsJpxEncoded = isJpxEncoded;
		IsImageMask = isImageMask;
		RenderingIntent = renderingIntent;
		Interpolate = interpolate;
		Decode = decode;
		ImageDictionary = imageDictionary ?? throw new ArgumentNullException("imageDictionary");
		RawMemory = rawMemory;
		ColorSpaceDetails = colorSpaceDetails;
		memoryFactory = bytes;
		MaskImage = softMaskImage;
	}

	public bool TryGetBytesAsMemory(out Memory<byte> bytes)
	{
		bytes = null;
		if (memoryFactory == null)
		{
			return false;
		}
		bytes = memoryFactory.Value;
		return true;
	}

	public bool TryGetPng([NotNullWhen(true)] out byte[]? bytes)
	{
		return PngFromPdfImageFactory.TryGenerate(this, out bytes);
	}

	public override string ToString()
	{
		return $"XObject Image (w {Bounds.Width}, h {Bounds.Height}): {ImageDictionary}";
	}
}
