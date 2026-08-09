using System;
using System.Buffers.Binary;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace UglyToad.PdfPig.Images.Png;

internal static class PngOpener
{
	public static Png Open(Stream stream, IChunkVisitor? chunkVisitor = null)
	{
		return Open(stream, new PngOpenerSettings
		{
			ChunkVisitor = chunkVisitor
		});
	}

	public static Png Open(Stream stream, PngOpenerSettings settings)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (!stream.CanRead)
		{
			throw new ArgumentException("The provided stream of type " + stream.GetType().FullName + " was not readable.");
		}
		HeaderValidationResult headerValidationResult = HasValidHeader(stream);
		if (!headerValidationResult.IsValid)
		{
			throw new ArgumentException($"The provided stream did not start with the PNG header. Got {headerValidationResult}.");
		}
		byte[] array = new byte[4];
		ImageHeader imageHeader = ReadImageHeader(stream, array);
		bool flag = false;
		Palette palette = null;
		using MemoryStream memoryStream = new MemoryStream();
		using (MemoryStream memoryStream2 = new MemoryStream())
		{
			ChunkHeader chunkHeader;
			while (TryReadChunkHeader(stream, out chunkHeader))
			{
				if (flag)
				{
					if (settings == null || !settings.DisallowTrailingData)
					{
						break;
					}
					throw new InvalidOperationException($"Found another chunk {chunkHeader} after already reading the IEND chunk.");
				}
				byte[] array2 = new byte[chunkHeader.Length];
				int num = stream.Read(array2, 0, array2.Length);
				if (num != array2.Length)
				{
					throw new InvalidOperationException($"Did not read {chunkHeader.Length} bytes for the {chunkHeader} header, only found: {num}.");
				}
				if (chunkHeader.IsCritical)
				{
					switch (chunkHeader.Name)
					{
					case "PLTE":
						if (chunkHeader.Length % 3 != 0)
						{
							throw new InvalidOperationException($"Palette data must be multiple of 3, got {chunkHeader.Length}.");
						}
						if (imageHeader.ColorType.HasFlag(ColorType.PaletteUsed))
						{
							palette = new Palette(array2);
						}
						break;
					case "IDAT":
						memoryStream2.Write(array2, 0, array2.Length);
						break;
					case "IEND":
						flag = true;
						break;
					default:
						throw new NotSupportedException($"Encountered critical header {chunkHeader} which was not recognised.");
					}
				}
				else if (chunkHeader.Name == "tRNS")
				{
					palette?.SetAlphaValues(array2);
				}
				num = stream.Read(array, 0, array.Length);
				if (num != 4)
				{
					throw new InvalidOperationException($"Did not read 4 bytes for the CRC, only found: {num}.");
				}
				int num2 = (int)Crc32.Calculate(Encoding.ASCII.GetBytes(chunkHeader.Name), array2);
				int num3 = (array[0] << 24) + (array[1] << 16) + (array[2] << 8) + array[3];
				if (num2 != num3)
				{
					throw new InvalidOperationException($"CRC calculated {num2} did not match file {num3} for chunk: {chunkHeader.Name}.");
				}
				settings?.ChunkVisitor?.Visit(stream, imageHeader, chunkHeader, array2, array);
			}
			memoryStream2.Flush();
			memoryStream2.Seek(2L, SeekOrigin.Begin);
			using DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Decompress);
			deflateStream.CopyTo(memoryStream);
			deflateStream.Close();
		}
		byte[] decompressedData = memoryStream.ToArray();
		(byte bytesPerPixel, byte samplesPerPixel) bytesAndSamplesPerPixel = Decoder.GetBytesAndSamplesPerPixel(imageHeader);
		byte item = bytesAndSamplesPerPixel.bytesPerPixel;
		byte item2 = bytesAndSamplesPerPixel.samplesPerPixel;
		decompressedData = Decoder.Decode(decompressedData, imageHeader, item, item2);
		return new Png(imageHeader, new RawPngData(decompressedData, item, palette, imageHeader), palette?.HasAlphaValues ?? false);
	}

	private static HeaderValidationResult HasValidHeader(Stream stream)
	{
		return new HeaderValidationResult(stream.ReadByte(), stream.ReadByte(), stream.ReadByte(), stream.ReadByte(), stream.ReadByte(), stream.ReadByte(), stream.ReadByte(), stream.ReadByte());
	}

	private static bool TryReadChunkHeader(Stream stream, out ChunkHeader chunkHeader)
	{
		chunkHeader = default(ChunkHeader);
		long position = stream.Position;
		if (!StreamHelper.TryReadHeaderBytes(stream, out byte[] bytes))
		{
			return false;
		}
		int length = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(0, 4));
		string name = Encoding.ASCII.GetString(bytes, 4, 4);
		chunkHeader = new ChunkHeader(position, length, name);
		return true;
	}

	private static ImageHeader ReadImageHeader(Stream stream, byte[] crc)
	{
		if (!TryReadChunkHeader(stream, out var chunkHeader))
		{
			throw new ArgumentException("The provided stream did not contain a single chunk.");
		}
		if (chunkHeader.Name != "IHDR")
		{
			throw new ArgumentException($"The first chunk was not the IHDR chunk: {chunkHeader}.");
		}
		if (chunkHeader.Length != 13)
		{
			throw new ArgumentException($"The first chunk did not have a length of 13 bytes: {chunkHeader}.");
		}
		byte[] array = new byte[13];
		int num = stream.Read(array, 0, array.Length);
		if (num != 13)
		{
			throw new InvalidOperationException($"Did not read 13 bytes for the IHDR, only found: {num}.");
		}
		num = stream.Read(crc, 0, crc.Length);
		if (num != 4)
		{
			throw new InvalidOperationException($"Did not read 4 bytes for the CRC, only found: {num}.");
		}
		int width = BinaryPrimitives.ReadInt32BigEndian(array.AsSpan(0, 4));
		int height = BinaryPrimitives.ReadInt32BigEndian(array.AsSpan(4, 4));
		byte bitDepth = array[8];
		byte colorType = array[9];
		byte compressionMethod = array[10];
		byte filterMethod = array[11];
		byte interlaceMethod = array[12];
		return new ImageHeader(width, height, bitDepth, (ColorType)colorType, (CompressionMethod)compressionMethod, (FilterMethod)filterMethod, (InterlaceMethod)interlaceMethod);
	}
}
