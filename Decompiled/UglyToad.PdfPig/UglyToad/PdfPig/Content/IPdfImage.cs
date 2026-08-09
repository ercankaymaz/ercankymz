using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public interface IPdfImage
{
	PdfRectangle Bounds { get; }

	int WidthInSamples { get; }

	int HeightInSamples { get; }

	int BitsPerComponent { get; }

	Memory<byte> RawMemory { get; }

	Span<byte> RawBytes { get; }

	RenderingIntent RenderingIntent { get; }

	bool IsImageMask { get; }

	IReadOnlyList<double> Decode { get; }

	bool Interpolate { get; }

	bool IsInlineImage { get; }

	DictionaryToken ImageDictionary { get; }

	ColorSpaceDetails? ColorSpaceDetails { get; }

	IPdfImage? MaskImage { get; }

	bool TryGetBytesAsMemory(out Memory<byte> memory);

	bool TryGetPng([NotNullWhen(true)] out byte[]? bytes);
}
