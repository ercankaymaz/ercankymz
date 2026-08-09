using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SharpGLTF.Memory;

[DebuggerDisplay("{PixelWidth}x{PixelHeight}x{PixelDepth}")]
internal readonly struct Ktx2Header
{
	public readonly ulong Header0;

	public readonly uint Header1;

	public readonly uint VkFormat;

	public readonly uint TypeSize;

	public readonly uint PixelWidth;

	public readonly uint PixelHeight;

	public readonly uint PixelDepth;

	public readonly uint LayerCount;

	public readonly uint FaceCount;

	public readonly uint LevelCount;

	public readonly uint SupercompressionScheme;

	public bool IsValidHeader
	{
		get
		{
			if (Header0 != 13488335998476897195uL)
			{
				return false;
			}
			if (Header1 != 169478669)
			{
				return false;
			}
			return true;
		}
	}

	public unsafe static bool TryGetHeader(IReadOnlyList<byte> data, out Ktx2Header header)
	{
		byte[] array = data as byte[];
		if (array == null)
		{
			array = data?.ToArray() ?? Array.Empty<byte>();
		}
		if (array.Length < sizeof(Ktx2Header))
		{
			header = default(Ktx2Header);
			return false;
		}
		header = MemoryMarshal.Cast<byte, Ktx2Header>((Span<byte>)array)[0];
		return true;
	}

	public static void Verify(IReadOnlyList<byte> data, string paramName)
	{
		Guard.IsTrue(TryGetHeader(data, out var header), paramName);
		Guard.IsTrue(header.IsValidHeader, paramName + ".Header");
		Guard.MustBePositiveAndMultipleOf((int)header.PixelWidth, 4, paramName + ".PixelWidth");
		Guard.MustBePositiveAndMultipleOf((int)header.PixelHeight, 4, paramName + ".PixelHeight");
		Guard.MustBeEqualTo((int)header.PixelDepth, 0, paramName + ".PixelDepth");
		Guard.MustBeLessThan((int)header.SupercompressionScheme, 3, paramName + ".SupercompressionScheme");
	}
}
