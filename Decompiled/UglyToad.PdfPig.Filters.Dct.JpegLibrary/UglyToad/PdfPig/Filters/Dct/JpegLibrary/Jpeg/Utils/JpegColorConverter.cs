using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.Utils;

internal sealed class JpegColorConverter
{
	public static readonly JpegColorConverter Shared = new JpegColorConverter();

	private const int ClampTableOffset = 256;

	private const int Shift = 16;

	private const int OneHalf = 32768;

	private readonly byte[] _clampTable;

	private readonly int[] _crRTable;

	private readonly int[] _cbBTable;

	private readonly int[] _crGTable;

	private readonly int[] _cbGTable;

	private readonly int[] _yTable;

	public JpegColorConverter()
	{
		_clampTable = new byte[1024];
		_crRTable = new int[256];
		_cbBTable = new int[256];
		_crGTable = new int[256];
		_cbGTable = new int[256];
		_yTable = new int[256];
		Span<float> luma = stackalloc float[3];
		luma[0] = 0.299f;
		luma[1] = 0.587f;
		luma[2] = 0.114f;
		Span<float> referenceBlackWhite = stackalloc float[6];
		referenceBlackWhite[0] = 0f;
		referenceBlackWhite[1] = 255f;
		referenceBlackWhite[2] = 128f;
		referenceBlackWhite[3] = 255f;
		referenceBlackWhite[4] = 128f;
		referenceBlackWhite[5] = 255f;
		Init(luma, referenceBlackWhite);
	}

	private void Init(Span<float> luma, Span<float> referenceBlackWhite)
	{
		byte[] clampTable = _clampTable;
		for (int i = 0; i < 256; i++)
		{
			clampTable[256 + i] = (byte)i;
		}
		int num = 512 + 512;
		for (int j = 512; j < num; j++)
		{
			clampTable[j] = byte.MaxValue;
		}
		float num2 = luma[0];
		float num3 = luma[1];
		float num4 = luma[2];
		float num5 = 2f - 2f * num2;
		int num6 = Fix(num5);
		int num7 = -Fix(num2 * num5 / num3);
		float num8 = 2f - 2f * num4;
		int num9 = Fix(num8);
		int num10 = -Fix(num4 * num8 / num3);
		int num11 = 0;
		int num12 = -128;
		while (num11 < 256)
		{
			int num13 = Code2V(num12, referenceBlackWhite[4] - 128f, referenceBlackWhite[5] - 128f, 127f);
			int num14 = Code2V(num12, referenceBlackWhite[2] - 128f, referenceBlackWhite[3] - 128f, 127f);
			_crRTable[num11] = num6 * num13 + 32768 >> 16;
			_cbBTable[num11] = num9 * num14 + 32768 >> 16;
			_crGTable[num11] = num7 * num13;
			_cbGTable[num11] = num10 * num14 + 32768;
			_yTable[num11] = Code2V(num12 + 128, referenceBlackWhite[0], referenceBlackWhite[1], 255f);
			num11++;
			num12++;
		}
	}

	private static int Fix(float x)
	{
		return (int)((double)(x * 65536f) + 0.5);
	}

	private static int Code2V(int c, float RB, float RW, float CR)
	{
		return (int)((float)(c - (int)RB) * CR / (((int)(RW - RB) != 0) ? (RW - RB) : 1f));
	}

	public void ConvertYCbCr8ToRgba32(ReadOnlySpan<byte> ycbcr, Span<byte> rgba, int count)
	{
		if (ycbcr.Length < 3 * count)
		{
			throw new ArgumentException("YCbCr buffer is too small.", "ycbcr");
		}
		if (rgba.Length < 4 * count)
		{
			throw new ArgumentException("RGBA buffer is too small.", "rgba");
		}
		byte[] clampTable = _clampTable;
		int[] yTable = _yTable;
		ref byte reference = ref MemoryMarshal.GetReference(ycbcr);
		ref byte reference2 = ref MemoryMarshal.GetReference(rgba);
		for (int i = 0; i < count; i++)
		{
			byte b = reference;
			byte b2 = Unsafe.Add(ref reference, 1);
			byte b3 = Unsafe.Add(ref reference, 2);
			int num = yTable[b];
			reference2 = clampTable[256 + num + _crRTable[b3]];
			Unsafe.Add(ref reference2, 1) = clampTable[256 + num + (_cbGTable[b2] + _crGTable[b3] >> 16)];
			Unsafe.Add(ref reference2, 2) = clampTable[256 + num + _cbBTable[b2]];
			Unsafe.Add(ref reference2, 3) = byte.MaxValue;
			reference = ref Unsafe.Add(ref reference, 3);
			reference2 = ref Unsafe.Add(ref reference2, 4);
		}
	}

	public void ConvertYCbCr8ToRgb24(ReadOnlySpan<byte> ycbcr, Span<byte> rgb, int count)
	{
		if (ycbcr.Length < 3 * count)
		{
			throw new ArgumentException("YCbCr buffer is too small.", "ycbcr");
		}
		if (rgb.Length < 3 * count)
		{
			throw new ArgumentException("RGB buffer is too small.", "rgb");
		}
		byte[] clampTable = _clampTable;
		int[] yTable = _yTable;
		ref byte reference = ref MemoryMarshal.GetReference(ycbcr);
		ref byte reference2 = ref MemoryMarshal.GetReference(rgb);
		for (int i = 0; i < count; i++)
		{
			byte b = reference;
			byte b2 = Unsafe.Add(ref reference, 1);
			byte b3 = Unsafe.Add(ref reference, 2);
			int num = yTable[b];
			reference2 = clampTable[256 + num + _crRTable[b3]];
			Unsafe.Add(ref reference2, 1) = clampTable[256 + num + (_cbGTable[b2] + _crGTable[b3] >> 16)];
			Unsafe.Add(ref reference2, 2) = clampTable[256 + num + _cbBTable[b2]];
			reference = ref Unsafe.Add(ref reference, 3);
			reference2 = ref Unsafe.Add(ref reference2, 3);
		}
	}

	public void ConvertYCbCrK8ToCmyk24(ReadOnlySpan<byte> ycbcr, Span<byte> rgb, int count)
	{
		if (ycbcr.Length < 4 * count)
		{
			throw new ArgumentException("YCbCr buffer is too small.", "ycbcr");
		}
		if (rgb.Length < 4 * count)
		{
			throw new ArgumentException("RGB buffer is too small.", "rgb");
		}
		byte[] clampTable = _clampTable;
		int[] yTable = _yTable;
		ref byte reference = ref MemoryMarshal.GetReference(ycbcr);
		ref byte reference2 = ref MemoryMarshal.GetReference(rgb);
		for (int i = 0; i < count; i++)
		{
			byte b = reference;
			byte b2 = Unsafe.Add(ref reference, 1);
			byte b3 = Unsafe.Add(ref reference, 2);
			byte b4 = Unsafe.Add(ref reference, 3);
			int num = yTable[b];
			reference2 = (byte)(255 - clampTable[256 + num + _crRTable[b3]]);
			Unsafe.Add(ref reference2, 1) = (byte)(255 - clampTable[256 + num + (_cbGTable[b2] + _crGTable[b3] >> 16)]);
			Unsafe.Add(ref reference2, 2) = (byte)(255 - clampTable[256 + num + _cbBTable[b2]]);
			Unsafe.Add(ref reference2, 3) = b4;
			reference = ref Unsafe.Add(ref reference, 4);
			reference2 = ref Unsafe.Add(ref reference2, 4);
		}
	}

	public void ConvertCmykToRgb(ReadOnlySpan<byte> cmyk, Span<byte> rgb, int count)
	{
		if (cmyk.Length / 4 != rgb.Length / 3)
		{
			throw new ArgumentException("RGB buffer is too small.", "rgb");
		}
		ref byte reference = ref MemoryMarshal.GetReference(cmyk);
		ref byte reference2 = ref MemoryMarshal.GetReference(rgb);
		for (int i = 0; i < count; i++)
		{
			byte b = reference;
			byte b2 = Unsafe.Add(ref reference, 1);
			byte b3 = Unsafe.Add(ref reference, 2);
			byte b4 = Unsafe.Add(ref reference, 3);
			double num = 1.0 - (double)(int)b4 / 255.0;
			reference2 = Convert.ToByte(255.0 * (1.0 - (double)(int)b / 255.0) * num);
			Unsafe.Add(ref reference2, 1) = Convert.ToByte(255.0 * (1.0 - (double)(int)b2 / 255.0) * num);
			Unsafe.Add(ref reference2, 2) = Convert.ToByte(255.0 * (1.0 - (double)(int)b3 / 255.0) * num);
			reference = ref Unsafe.Add(ref reference, 4);
			reference2 = ref Unsafe.Add(ref reference2, 3);
		}
	}
}
