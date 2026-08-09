using System;
using UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;
using UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.Utils;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary;

public sealed class JpegLibraryDctDecodeFilter : IFilter
{
	public bool IsSupported => true;

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		JpegDecoder jpegDecoder = new JpegDecoder();
		jpegDecoder.SetInput(input);
		jpegDecoder.Identify();
		int width = jpegDecoder.Width;
		int height = jpegDecoder.Height;
		Memory<byte> memory = new byte[width * height * jpegDecoder.NumberOfComponents];
		if (jpegDecoder.Precision == 8)
		{
			jpegDecoder.SetOutputWriter(new JpegBufferOutputWriter8Bit(width, height, jpegDecoder.NumberOfComponents, memory));
		}
		else
		{
			_ = jpegDecoder.Precision;
			_ = 8;
		}
		jpegDecoder.Decode();
		bool flag = false;
		IToken token;
		if (jpegDecoder.AdobeApplicationSpecific.HasValue)
		{
			flag = jpegDecoder.AdobeApplicationSpecific.Value.ColorTransformCode > 0;
		}
		else if (!streamDictionary.TryGet(NameToken.Create("ColorTransform"), out token))
		{
			flag = jpegDecoder.NumberOfComponents == 3;
		}
		if (!flag)
		{
			return memory;
		}
		if (jpegDecoder.NumberOfComponents == 3)
		{
			for (int i = 0; i < height; i++)
			{
				JpegColorConverter.Shared.ConvertYCbCr8ToRgb24(memory.Span.Slice(i * width * 3, width * 3), memory.Span.Slice(i * width * 3, width * 3), width);
			}
		}
		else if (jpegDecoder.NumberOfComponents == 4)
		{
			for (int j = 0; j < height; j++)
			{
				JpegColorConverter.Shared.ConvertYCbCrK8ToCmyk24(memory.Span.Slice(j * width * 4, width * 4), memory.Span.Slice(j * width * 4, width * 4), width);
			}
		}
		return memory;
	}
}
