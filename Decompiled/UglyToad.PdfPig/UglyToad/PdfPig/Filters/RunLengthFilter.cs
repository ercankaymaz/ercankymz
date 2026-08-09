using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public sealed class RunLengthFilter : IFilter
{
	private const byte EndOfDataLength = 128;

	public bool IsSupported { get; } = true;

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>(input.Length);
		Span<byte> span = input.Span;
		int num = 0;
		while (num < input.Length)
		{
			byte b = span[num];
			if (b == 128)
			{
				break;
			}
			if (b <= 127)
			{
				for (int num2 = b + 1; num2 > 0; num2--)
				{
					num++;
					arrayPoolBufferWriter.Write(span[num]);
				}
				num++;
			}
			else
			{
				int num3 = 257 - b;
				byte value = span[num + 1];
				arrayPoolBufferWriter.GetSpan(num3).Slice(0, num3).Fill(value);
				arrayPoolBufferWriter.Advance(num3);
				num += 2;
			}
		}
		return arrayPoolBufferWriter.WrittenMemory.ToArray();
	}
}
