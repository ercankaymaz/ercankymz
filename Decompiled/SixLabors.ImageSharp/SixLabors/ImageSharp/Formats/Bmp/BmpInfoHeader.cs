using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.Formats.Bmp;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct BmpInfoHeader(int headerSize, int width, int height, short planes, ushort bitsPerPixel, BmpCompression compression = BmpCompression.RGB, int imageSize = 0, int xPelsPerMeter = 0, int yPelsPerMeter = 0, int clrUsed = 0, int clrImportant = 0, int redMask = 0, int greenMask = 0, int blueMask = 0, int alphaMask = 0, BmpColorSpace csType = BmpColorSpace.LCS_CALIBRATED_RGB, int redX = 0, int redY = 0, int redZ = 0, int greenX = 0, int greenY = 0, int greenZ = 0, int blueX = 0, int blueY = 0, int blueZ = 0, int gammeRed = 0, int gammeGreen = 0, int gammeBlue = 0, BmpRenderingIntent intent = BmpRenderingIntent.Invalid, int profileData = 0, int profileSize = 0, int reserved = 0)
{
	public const int CoreSize = 12;

	public const int Os22ShortSize = 16;

	public const int SizeV3 = 40;

	public const int AdobeV3Size = 52;

	public const int AdobeV3WithAlphaSize = 56;

	public const int Os2v2Size = 64;

	public const int SizeV4 = 108;

	public const int SizeV5 = 124;

	public const int MaxHeaderSize = 124;

	public const int HeaderSizeSize = 4;

	public int HeaderSize { get; set; } = headerSize;

	public int Width { get; set; } = width;

	public int Height { get; set; } = height;

	public short Planes { get; set; } = planes;

	public ushort BitsPerPixel { get; set; } = bitsPerPixel;

	public BmpCompression Compression { get; set; } = compression;

	public int ImageSize { get; set; } = imageSize;

	public int XPelsPerMeter { get; set; } = xPelsPerMeter;

	public int YPelsPerMeter { get; set; } = yPelsPerMeter;

	public int ClrUsed { get; set; } = clrUsed;

	public int ClrImportant { get; set; } = clrImportant;

	public int RedMask { get; set; } = redMask;

	public int GreenMask { get; set; } = greenMask;

	public int BlueMask { get; set; } = blueMask;

	public int AlphaMask { get; set; } = alphaMask;

	public BmpColorSpace CsType { get; set; } = csType;

	public int RedX { get; set; } = redX;

	public int RedY { get; set; } = redY;

	public int RedZ { get; set; } = redZ;

	public int GreenX { get; set; } = greenX;

	public int GreenY { get; set; } = greenY;

	public int GreenZ { get; set; } = greenZ;

	public int BlueX { get; set; } = blueX;

	public int BlueY { get; set; } = blueY;

	public int BlueZ { get; set; } = blueZ;

	public int GammaRed { get; set; } = gammeRed;

	public int GammaGreen { get; set; } = gammeGreen;

	public int GammaBlue { get; set; } = gammeBlue;

	public BmpRenderingIntent Intent { get; set; } = intent;

	public int ProfileData { get; set; } = profileData;

	public int ProfileSize { get; set; } = profileSize;

	public int Reserved { get; set; } = reserved;

	public static BmpInfoHeader ParseCore(ReadOnlySpan<byte> data)
	{
		return new BmpInfoHeader(BinaryPrimitives.ReadInt32LittleEndian(data.Slice(0, 4)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(4, 2)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(6, 2)), BinaryPrimitives.ReadInt16LittleEndian(data.Slice(8, 2)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(10, 2)));
	}

	public static BmpInfoHeader ParseOs22Short(ReadOnlySpan<byte> data)
	{
		return new BmpInfoHeader(BinaryPrimitives.ReadInt32LittleEndian(data.Slice(0, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(4, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(8, 4)), BinaryPrimitives.ReadInt16LittleEndian(data.Slice(12, 2)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(14, 2)));
	}

	public static BmpInfoHeader ParseV3(ReadOnlySpan<byte> data)
	{
		return new BmpInfoHeader(BinaryPrimitives.ReadInt32LittleEndian(data.Slice(0, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(4, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(8, 4)), BinaryPrimitives.ReadInt16LittleEndian(data.Slice(12, 2)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(14, 2)), (BmpCompression)BinaryPrimitives.ReadInt32LittleEndian(data.Slice(16, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(20, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(24, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(28, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(32, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(36, 4)));
	}

	public static BmpInfoHeader ParseAdobeV3(ReadOnlySpan<byte> data, bool withAlpha = true)
	{
		return new BmpInfoHeader(BinaryPrimitives.ReadInt32LittleEndian(data.Slice(0, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(4, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(8, 4)), BinaryPrimitives.ReadInt16LittleEndian(data.Slice(12, 2)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(14, 2)), (BmpCompression)BinaryPrimitives.ReadInt32LittleEndian(data.Slice(16, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(20, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(24, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(28, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(32, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(36, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(40, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(44, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(48, 4)), withAlpha ? BinaryPrimitives.ReadInt32LittleEndian(data.Slice(52, 4)) : 0);
	}

	public static BmpInfoHeader ParseOs2Version2(ReadOnlySpan<byte> data)
	{
		BmpInfoHeader result = new BmpInfoHeader(BinaryPrimitives.ReadInt32LittleEndian(data.Slice(0, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(4, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(8, 4)), BinaryPrimitives.ReadInt16LittleEndian(data.Slice(12, 2)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(14, 2)));
		switch (BinaryPrimitives.ReadInt32LittleEndian(data.Slice(16, 4)))
		{
		case 0:
			result.Compression = BmpCompression.RGB;
			break;
		case 1:
			result.Compression = BmpCompression.RLE8;
			break;
		case 2:
			result.Compression = BmpCompression.RLE4;
			break;
		case 4:
			result.Compression = BmpCompression.RLE24;
			break;
		default:
			BmpThrowHelper.ThrowInvalidImageContentException("Compression type is not supported. ImageSharp only supports uncompressed, RLE4, RLE8 and RLE24.");
			break;
		}
		result.ImageSize = BinaryPrimitives.ReadInt32LittleEndian(data.Slice(20, 4));
		result.XPelsPerMeter = BinaryPrimitives.ReadInt32LittleEndian(data.Slice(24, 4));
		result.YPelsPerMeter = BinaryPrimitives.ReadInt32LittleEndian(data.Slice(28, 4));
		result.ClrUsed = BinaryPrimitives.ReadInt32LittleEndian(data.Slice(32, 4));
		result.ClrImportant = BinaryPrimitives.ReadInt32LittleEndian(data.Slice(36, 4));
		return result;
	}

	public static BmpInfoHeader ParseV4(ReadOnlySpan<byte> data)
	{
		return new BmpInfoHeader(BinaryPrimitives.ReadInt32LittleEndian(data.Slice(0, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(4, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(8, 4)), BinaryPrimitives.ReadInt16LittleEndian(data.Slice(12, 2)), BinaryPrimitives.ReadUInt16LittleEndian(data.Slice(14, 2)), (BmpCompression)BinaryPrimitives.ReadInt32LittleEndian(data.Slice(16, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(20, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(24, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(28, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(32, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(36, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(40, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(44, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(48, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(52, 4)), (BmpColorSpace)BinaryPrimitives.ReadInt32LittleEndian(data.Slice(56, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(60, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(64, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(68, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(72, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(76, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(80, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(84, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(88, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(92, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(96, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(100, 4)), BinaryPrimitives.ReadInt32LittleEndian(data.Slice(104, 4)));
	}

	public static BmpInfoHeader ParseV5(ReadOnlySpan<byte> data)
	{
		if (data.Length < 124)
		{
			throw new ArgumentException($"Must be {124} bytes. Was {data.Length} bytes.", "data");
		}
		return MemoryMarshal.Cast<byte, BmpInfoHeader>(data)[0];
	}

	public void WriteV3Header(Span<byte> buffer)
	{
		buffer.Clear();
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(0, 4), 40);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(4, 4), Width);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(8, 4), Height);
		BinaryPrimitives.WriteInt16LittleEndian(buffer.Slice(12, 2), Planes);
		BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(14, 2), BitsPerPixel);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(16, 4), (int)Compression);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(20, 4), ImageSize);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(24, 4), XPelsPerMeter);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(28, 4), YPelsPerMeter);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(32, 4), ClrUsed);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(36, 4), ClrImportant);
	}

	public void WriteV4Header(Span<byte> buffer)
	{
		buffer.Clear();
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(0, 4), 108);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(4, 4), Width);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(8, 4), Height);
		BinaryPrimitives.WriteInt16LittleEndian(buffer.Slice(12, 2), Planes);
		BinaryPrimitives.WriteUInt16LittleEndian(buffer.Slice(14, 2), BitsPerPixel);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(16, 4), (int)Compression);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(20, 4), ImageSize);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(24, 4), XPelsPerMeter);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(28, 4), YPelsPerMeter);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(32, 4), ClrUsed);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(36, 4), ClrImportant);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(40, 4), RedMask);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(44, 4), GreenMask);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(48, 4), BlueMask);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(52, 4), AlphaMask);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(56, 4), (int)CsType);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(60, 4), RedX);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(64, 4), RedY);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(68, 4), RedZ);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(72, 4), GreenX);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(76, 4), GreenY);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(80, 4), GreenZ);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(84, 4), BlueX);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(88, 4), BlueY);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(92, 4), BlueZ);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(96, 4), GammaRed);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(100, 4), GammaGreen);
		BinaryPrimitives.WriteInt32LittleEndian(buffer.Slice(104, 4), GammaBlue);
	}

	public void WriteV5Header(Span<byte> buffer)
	{
		Unsafe.As<byte, BmpInfoHeader>(ref MemoryMarshal.GetReference<byte>(buffer)) = this;
	}
}
