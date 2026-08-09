using System;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal sealed class JpegFrame : IDisposable
{
	public bool IsExtended { get; private set; }

	public bool Progressive { get; private set; }

	public bool Interleaved { get; set; }

	public byte Precision { get; private set; }

	public float MaxColorChannelValue { get; private set; }

	public int PixelHeight { get; private set; }

	public int PixelWidth { get; private set; }

	public Size PixelSize => new Size(PixelWidth, PixelHeight);

	public byte ComponentCount { get; private set; }

	public byte[] ComponentIds { get; set; }

	public byte[] ComponentOrder { get; set; }

	public JpegComponent[] Components { get; set; }

	public int McusPerLine { get; set; }

	public int McusPerColumn { get; set; }

	public Size McuSize => new Size(McusPerLine, McusPerColumn);

	public int BitsPerPixel => ComponentCount * Precision;

	public JpegFrame(JpegFileMarker sofMarker, byte precision, int width, int height, byte componentCount)
	{
		byte marker = sofMarker.Marker;
		IsExtended = ((marker == 193 || marker == 201) ? true : false);
		marker = sofMarker.Marker;
		Progressive = ((marker == 194 || marker == 202) ? true : false);
		Precision = precision;
		MaxColorChannelValue = MathF.Pow(2f, (int)precision) - 1f;
		PixelWidth = width;
		PixelHeight = height;
		ComponentCount = componentCount;
	}

	public void Dispose()
	{
		if (Components != null)
		{
			for (int i = 0; i < Components.Length; i++)
			{
				Components[i]?.Dispose();
			}
			Components = null;
		}
	}

	public void Init(int maxSubFactorH, int maxSubFactorV)
	{
		McusPerLine = (int)Numerics.DivideCeil((uint)PixelWidth, (uint)(maxSubFactorH * 8));
		McusPerColumn = (int)Numerics.DivideCeil((uint)PixelHeight, (uint)(maxSubFactorV * 8));
		for (int i = 0; i < ComponentCount; i++)
		{
			((IJpegComponent)Components[i]).Init(maxSubFactorH, maxSubFactorV);
		}
	}

	public void AllocateComponents()
	{
		bool fullScan = Progressive || !Interleaved;
		for (int i = 0; i < ComponentCount; i++)
		{
			((IJpegComponent)Components[i]).AllocateSpectral(fullScan);
		}
	}
}
