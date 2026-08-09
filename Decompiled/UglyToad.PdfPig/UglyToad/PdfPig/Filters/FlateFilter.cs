using System;
using System.Buffers.Binary;
using System.IO;
using System.IO.Compression;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Filters;

public sealed class FlateFilter : IFilter
{
	private const int DefaultColors = 1;

	private const int DefaultBitsPerComponent = 8;

	private const int DefaultColumns = 1;

	private const byte Deflate32KbWindow = 120;

	private const byte ChecksumBits = 1;

	public bool IsSupported { get; } = true;

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		DictionaryToken filterParameters = DecodeParameterResolver.GetFilterParameters(streamDictionary, filterIndex);
		int intOrDefault = filterParameters.GetIntOrDefault(NameToken.Predictor, -1);
		try
		{
			int colors = Math.Min(filterParameters.GetIntOrDefault(NameToken.Colors, 1), 32);
			int intOrDefault2 = filterParameters.GetIntOrDefault(NameToken.BitsPerComponent, 8);
			int intOrDefault3 = filterParameters.GetIntOrDefault(NameToken.Columns, 1);
			return Decompress(input, intOrDefault, colors, intOrDefault2, intOrDefault3);
		}
		catch
		{
			return input;
		}
	}

	private static Memory<byte> Decompress(Memory<byte> input, int predictor, int colors, int bitsPerComponent, int columns)
	{
		using MemoryStream stream = MemoryHelper.AsReadOnlyMemoryStream(input.Slice(2, input.Length - 2 - 4));
		Memory<byte> result = input.Slice(input.Length - 4, 4);
		Span<byte> span = result.Span;
		uint num = BinaryPrimitives.ReadUInt32BigEndian(span);
		uint num2 = num;
		if (span[3] == 10 || span[3] == 13)
		{
			if (span[3] == 10 && span[2] == 13)
			{
				result = input.Slice(input.Length - 6, 4);
				span = result.Span;
			}
			else
			{
				result = input.Slice(input.Length - 5, 4);
				span = result.Span;
			}
			num2 = BinaryPrimitives.ReadUInt32BigEndian(span);
		}
		try
		{
			using DeflateStream writeStream = new DeflateStream(stream, CompressionMode.Decompress);
			using Adler32ChecksumStream adler32ChecksumStream = new Adler32ChecksumStream(writeStream);
			using MemoryStream memoryStream = new MemoryStream((int)((double)input.Length * 1.5));
			using Stream stream2 = PngPredictor.WrapPredictor(memoryStream, predictor, colors, bitsPerComponent, columns);
			adler32ChecksumStream.CopyTo(stream2);
			stream2.Flush();
			uint checksum = adler32ChecksumStream.Checksum;
			if (num != checksum && num2 != checksum)
			{
				throw new CorruptCompressedDataException("Flate stream has invalid checksum");
			}
			result = memoryStream.AsMemory();
			return result;
		}
		catch (InvalidDataException inner)
		{
			throw new CorruptCompressedDataException("Invalid Flate compressed stream encountered", inner);
		}
	}

	public byte[] Encode(Stream input, DictionaryToken streamDictionary, int index)
	{
		byte[] array;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			input.CopyTo(memoryStream);
			array = memoryStream.ToArray();
		}
		using MemoryStream memoryStream2 = new MemoryStream();
		using DeflateStream writeStream = new DeflateStream(memoryStream2, CompressionLevel.Fastest);
		using Adler32ChecksumStream adler32ChecksumStream = new Adler32ChecksumStream(writeStream);
		adler32ChecksumStream.Write(array, 0, array.Length);
		adler32ChecksumStream.Close();
		byte[] array2 = memoryStream2.ToArray();
		byte[] array3 = new byte[2 + array2.Length + 4];
		array3[0] = 120;
		array3[1] = 1;
		Array.Copy(array2, 0, array3, 2, array2.Length);
		uint checksum = adler32ChecksumStream.Checksum;
		int num = 2 + array2.Length;
		array3[num++] = (byte)(checksum >> 24);
		array3[num++] = (byte)(checksum >> 16);
		array3[num++] = (byte)(checksum >> 8);
		array3[num] = (byte)checksum;
		return array3;
	}
}
