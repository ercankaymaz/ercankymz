using System;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public sealed class Ascii85Filter : IFilter
{
	private const byte EmptyBlock = 122;

	private const byte Offset = 33;

	private const byte EmptyCharacterPadding = 117;

	private static readonly int[] PowerByIndex = new int[5] { 1, 85, 7225, 614125, 52200625 };

	private static ReadOnlySpan<byte> EndOfDataBytes => "~>"u8;

	public bool IsSupported { get; } = true;

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		Span<byte> ascii = stackalloc byte[5];
		Span<byte> span = input.Span;
		int num = 0;
		using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>();
		for (int i = 0; i < span.Length; i++)
		{
			byte b = span[i];
			if (IsWhiteSpace(b))
			{
				continue;
			}
			if (b == EndOfDataBytes[0] && (i == span.Length - 1 || span[i + 1] == EndOfDataBytes[1]))
			{
				if (num > 0)
				{
					WriteData(ascii, num, arrayPoolBufferWriter, isAtEnd: true);
				}
				num = 0;
				break;
			}
			if (b == 122)
			{
				if (num > 0)
				{
					throw new InvalidOperationException("Encountered z within a 5 character block");
				}
				for (int j = 0; j < 4; j++)
				{
					arrayPoolBufferWriter.Write(0);
				}
				num = 0;
			}
			else
			{
				ascii[num] = (byte)(b - 33);
				num++;
			}
			if (num == 5)
			{
				WriteData(ascii, num, arrayPoolBufferWriter, isAtEnd: false);
				num = 0;
			}
		}
		if (num > 0)
		{
			WriteData(ascii, num, arrayPoolBufferWriter, isAtEnd: true);
		}
		return arrayPoolBufferWriter.WrittenMemory.ToArray();
	}

	private static void WriteData(Span<byte> ascii, int index, ArrayPoolBufferWriter<byte> writer, bool isAtEnd)
	{
		if (index < 2)
		{
			if (!isAtEnd)
			{
				string text = Encoding.ASCII.GetString(ascii);
				string text2 = Encoding.ASCII.GetString(writer.GetSpan());
				throw new ArgumentOutOfRangeException("index", "Cannot convert a this block because we're not at the end of the stream. Chunk: '" + text + "'. Content: '" + text2 + "'");
			}
			return;
		}
		for (int i = index; i < 5; i++)
		{
			ascii[i] = 84;
		}
		int num = 0;
		num += ascii[0] * PowerByIndex[4];
		num += ascii[1] * PowerByIndex[3];
		num += ascii[2] * PowerByIndex[2];
		num += ascii[3] * PowerByIndex[1];
		num += ascii[4] * PowerByIndex[0];
		writer.Write((byte)(num >> 24));
		if (index > 2)
		{
			writer.Write((byte)(num >> 16));
		}
		if (index > 3)
		{
			writer.Write((byte)(num >> 8));
		}
		if (index > 4)
		{
			writer.Write((byte)num);
		}
	}

	private static bool IsWhiteSpace(byte b)
	{
		if (b != 13 && b != 10)
		{
			return b == 32;
		}
		return true;
	}
}
