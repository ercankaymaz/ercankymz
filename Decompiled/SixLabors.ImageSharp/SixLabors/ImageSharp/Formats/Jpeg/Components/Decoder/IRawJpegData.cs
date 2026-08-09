using System;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal interface IRawJpegData : IDisposable
{
	JpegColorSpace ColorSpace { get; }

	JpegComponent[] Components { get; }

	Block8x8F[] QuantizationTables { get; }
}
