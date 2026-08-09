using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Images.Png;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public class InlineImage : IPdfImage
{
	private readonly Lazy<Memory<byte>>? memoryFactory;

	public PdfRectangle Bounds { get; }

	public int WidthInSamples { get; }

	public int HeightInSamples { get; }

	public int BitsPerComponent { get; }

	public bool IsImageMask { get; }

	public IReadOnlyList<double> Decode { get; }

	public bool IsInlineImage { get; } = true;

	public DictionaryToken ImageDictionary { get; }

	public RenderingIntent RenderingIntent { get; }

	public bool Interpolate { get; }

	public Memory<byte> RawMemory { get; }

	public Span<byte> RawBytes => RawMemory.Span;

	public ColorSpaceDetails ColorSpaceDetails { get; }

	public IPdfImage? MaskImage { get; }

	internal InlineImage(PdfRectangle bounds, int widthInSamples, int heightInSamples, int bitsPerComponent, bool isImageMask, RenderingIntent renderingIntent, bool interpolate, IReadOnlyList<double> decode, Memory<byte> rawMemory, ILookupFilterProvider filterProvider, IReadOnlyList<NameToken> filterNames, DictionaryToken streamDictionary, ColorSpaceDetails colorSpaceDetails, IPdfImage? softMaskImage)
	{
		InlineImage inlineImage = this;
		IsInlineImage = true;
		Bounds = bounds;
		WidthInSamples = widthInSamples;
		HeightInSamples = heightInSamples;
		Decode = decode;
		BitsPerComponent = bitsPerComponent;
		IsImageMask = isImageMask;
		RenderingIntent = renderingIntent;
		Interpolate = interpolate;
		ImageDictionary = streamDictionary;
		RawMemory = rawMemory;
		ColorSpaceDetails = colorSpaceDetails;
		IReadOnlyList<IFilter> filters = filterProvider.GetNamedFilters(filterNames);
		bool flag = true;
		foreach (IFilter item in filters)
		{
			if (!item.IsSupported)
			{
				flag = false;
				break;
			}
		}
		memoryFactory = (flag ? new Lazy<Memory<byte>>(delegate
		{
			Memory<byte> memory = inlineImage.RawMemory;
			for (int i = 0; i < filters.Count; i++)
			{
				memory = filters[i].Decode(memory, streamDictionary, filterProvider, i);
			}
			return memory;
		}) : null);
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
		return $"Inline Image (w {Bounds.Width}, h {Bounds.Height})";
	}
}
