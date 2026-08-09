using System;

namespace UglyToad.PdfPig.Images.Png;

internal sealed class Palette
{
	public bool HasAlphaValues { get; private set; }

	public byte[] Data { get; }

	public Palette(ReadOnlySpan<byte> data)
	{
		Data = new byte[data.Length * 4 / 3];
		int num = 0;
		for (int i = 0; i < data.Length; i += 3)
		{
			Data[num++] = data[i];
			Data[num++] = data[i + 1];
			Data[num++] = data[i + 2];
			Data[num++] = byte.MaxValue;
		}
	}

	public void SetAlphaValues(ReadOnlySpan<byte> bytes)
	{
		HasAlphaValues = true;
		for (int i = 0; i < bytes.Length; i++)
		{
			Data[i * 4 + 3] = bytes[i];
		}
	}

	public Pixel GetPixel(int index)
	{
		int num = index * 4;
		return new Pixel(Data[num], Data[num + 1], Data[num + 2], Data[num + 3], isGrayscale: false);
	}
}
