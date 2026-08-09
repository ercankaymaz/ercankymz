using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.IO;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal struct JpegBitReader(BufferedReadStream stream)
{
	private readonly BufferedReadStream stream = stream;

	private ulong data = 0uL;

	private int remainingBits = 0;

	private bool badData = false;

	private int eofHitCount = 0;

	public byte Marker { get; private set; } = byte.MaxValue;

	public long MarkerPosition { get; private set; } = 0L;

	public bool NoData { get; private set; } = false;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CheckBits()
	{
		if (remainingBits < 16)
		{
			FillBuffer();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		data = 0uL;
		remainingBits = 0;
		Marker = byte.MaxValue;
		MarkerPosition = 0L;
		badData = false;
		NoData = false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool HasRestartMarker()
	{
		return HasRestart(Marker);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool HasBadMarker()
	{
		if (Marker != byte.MaxValue)
		{
			return !HasRestartMarker();
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FillBuffer()
	{
		remainingBits += 48;
		data = (data << 48) | GetBytes();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe int DecodeHuffman(ref HuffmanTable h)
	{
		CheckBits();
		int num = PeekBits(8);
		int i = h.LookaheadSize[num];
		if (i < 9)
		{
			remainingBits -= i;
			return h.LookaheadValue[num];
		}
		ulong num2;
		for (num2 = data << 64 - remainingBits; num2 > h.MaxCode[i]; i++)
		{
		}
		remainingBits -= i;
		return h.Values[(h.ValOffset[i] + (int)(num2 >> 64 - i)) & 0xFF];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int Receive(int nbits)
	{
		CheckBits();
		return Extend(GetBits(nbits), nbits);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool HasRestart(byte marker)
	{
		if (marker >= 208)
		{
			return marker <= 215;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int GetBits(int nbits)
	{
		return (int)ExtractBits(data, remainingBits -= nbits, nbits);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int PeekBits(int nbits)
	{
		return (int)ExtractBits(data, remainingBits - nbits, nbits);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static ulong ExtractBits(ulong value, int offset, int size)
	{
		return (value >> offset) & (ulong)((1 << size) - 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Extend(int v, int nbits)
	{
		return v - (((v + v >> nbits) - 1) & ((1 << nbits) - 1));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private ulong GetBytes()
	{
		ulong num = 0uL;
		for (int i = 0; i < 6; i++)
		{
			int num2 = ReadStream();
			if (num2 == 255)
			{
				int num3 = ReadStream();
				while (true)
				{
					switch (num3)
					{
					case 255:
						goto IL_001f;
					default:
						badData = true;
						Marker = (byte)num3;
						MarkerPosition = stream.Position - 2;
						break;
					case 0:
						break;
					}
					break;
					IL_001f:
					num3 = ReadStream();
				}
			}
			num = (num << 8) | (ulong)num2;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool FindNextMarker()
	{
		while (true)
		{
			int num = stream.ReadByte();
			switch (num)
			{
			default:
				continue;
			case -1:
				return false;
			case 255:
				break;
			}
			while (true)
			{
				switch (num)
				{
				case 0:
					break;
				case 255:
					goto IL_001c;
				default:
					Marker = (byte)num;
					MarkerPosition = stream.Position - 2;
					return true;
				}
				break;
				IL_001c:
				num = stream.ReadByte();
				if (num == -1)
				{
					return false;
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private int ReadStream()
	{
		int num = ((!badData) ? stream.ReadByte() : 0);
		if (num == -1 || (badData && data == 0L && stream.Position >= stream.Length))
		{
			if (eofHitCount > 6)
			{
				badData = true;
				NoData = true;
				num = 0;
			}
			eofHitCount++;
		}
		return num;
	}
}
