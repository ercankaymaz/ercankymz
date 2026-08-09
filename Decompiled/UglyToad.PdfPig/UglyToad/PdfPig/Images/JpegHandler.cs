using System;
using System.IO;

namespace UglyToad.PdfPig.Images;

internal static class JpegHandler
{
	private const byte MarkerStart = byte.MaxValue;

	private const byte StartOfImage = 216;

	public static JpegInformation GetInformation(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (!HasRecognizedHeader(stream))
		{
			throw new InvalidOperationException("The input stream did not start with the expected JPEG header [ 255 216 ]");
		}
		JpegMarker jpegMarker = JpegMarker.StartOfImage;
		byte[] buffer = new byte[2];
		while (true)
		{
			switch (jpegMarker)
			{
			case JpegMarker.StartOfBaselineDctFrame:
			case JpegMarker.StartOfProgressiveDctFrame:
			{
				ReadShort(stream, buffer);
				int bitsPerComponent = stream.ReadByte();
				ushort height = ReadShort(stream, buffer);
				ushort width = ReadShort(stream, buffer);
				int numberOfComponents = stream.ReadByte();
				return new JpegInformation(width, height, bitsPerComponent, numberOfComponents);
			}
			default:
			{
				ushort num = ReadShort(stream, buffer);
				stream.Seek(num - 2, SeekOrigin.Current);
				break;
			}
			case JpegMarker.Restart0:
			case JpegMarker.Restart1:
			case JpegMarker.Restart2:
			case JpegMarker.Restart3:
			case JpegMarker.Restart4:
			case JpegMarker.Restart5:
			case JpegMarker.Restart6:
			case JpegMarker.Restart7:
			case JpegMarker.StartOfImage:
				break;
			case JpegMarker.EndOfImage:
				throw new InvalidOperationException("File was a valid JPEG but the width and height could not be determined.");
			}
			jpegMarker = (JpegMarker)ReadSegmentMarker(stream, skipData: true);
		}
	}

	private static bool HasRecognizedHeader(Stream stream)
	{
		byte[] array = new byte[2];
		if (stream.Read(array, 0, 2) != 2)
		{
			return false;
		}
		if (array[0] == byte.MaxValue)
		{
			return array[1] == 216;
		}
		return false;
	}

	private static byte ReadSegmentMarker(Stream stream, bool skipData = false)
	{
		byte? b = null;
		int num;
		while ((num = stream.ReadByte()) != -1)
		{
			byte b2 = (byte)num;
			if (!skipData)
			{
				if (!b.HasValue && b2 != byte.MaxValue)
				{
					throw new InvalidOperationException();
				}
				if (b2 != byte.MaxValue)
				{
					return b2;
				}
			}
			if (b.HasValue && b.Value == byte.MaxValue && b2 != byte.MaxValue)
			{
				return b2;
			}
			b = b2;
		}
		throw new InvalidOperationException();
	}

	private static ushort ReadShort(Stream stream, byte[] buffer)
	{
		if (stream.Read(buffer, 0, 2) != 2)
		{
			throw new InvalidOperationException("Failed to read a short where expected in the JPEG stream.");
		}
		return (ushort)((buffer[0] << 8) + buffer[1]);
	}
}
