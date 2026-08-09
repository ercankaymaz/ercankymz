using System;
using System.Buffers.Binary;

namespace UglyToad.PdfPig.Util;

internal static class MurmurHash3
{
	public static byte[] Compute_x86_128(ReadOnlySpan<byte> data)
	{
		return Compute_x86_128(data, data.Length, 0u);
	}

	public static byte[] Compute_x86_128(ReadOnlySpan<byte> data, int len, uint seed)
	{
		Span<uint> outHash = stackalloc uint[4];
		Compute_x86_128(data, len, seed, outHash);
		byte[] array = new byte[16];
		Span<byte> span = array.AsSpan();
		Span<byte> buffer = stackalloc byte[4];
		GetBytes(buffer, outHash[0]);
		buffer.CopyTo(span.Slice(0, 4));
		GetBytes(buffer, outHash[1]);
		buffer.CopyTo(span.Slice(4, 4));
		GetBytes(buffer, outHash[2]);
		buffer.CopyTo(span.Slice(8, 4));
		GetBytes(buffer, outHash[3]);
		buffer.CopyTo(span.Slice(12, 4));
		return array;
	}

	public static byte[] Compute_x64_128(ReadOnlySpan<byte> data)
	{
		return Compute_x64_128(data, data.Length, 0u);
	}

	public static byte[] Compute_x64_128(ReadOnlySpan<byte> data, int len, uint seed)
	{
		Span<ulong> outHash = stackalloc ulong[2];
		Compute_x64_128(data, len, seed, outHash);
		byte[] array = new byte[16];
		Span<byte> span = array.AsSpan();
		Span<byte> buffer = stackalloc byte[8];
		GetBytes(buffer, outHash[0]);
		buffer.CopyTo(span.Slice(0, 8));
		GetBytes(buffer, outHash[1]);
		buffer.CopyTo(span.Slice(8, 8));
		return array;
	}

	private static void Compute_x86_128(ReadOnlySpan<byte> data, int len, uint seed, Span<uint> outHash)
	{
		uint num = seed;
		uint num2 = seed;
		uint num3 = seed;
		uint num4 = seed;
		int num5 = len / 16;
		for (int i = 0; i < num5; i++)
		{
			int num6 = i * 16;
			uint num7 = BinaryPrimitives.ReadUInt32LittleEndian(data.Slice(num6));
			uint num8 = BinaryPrimitives.ReadUInt32LittleEndian(data.Slice(num6 + 4));
			uint num9 = BinaryPrimitives.ReadUInt32LittleEndian(data.Slice(num6 + 8));
			uint num10 = BinaryPrimitives.ReadUInt32LittleEndian(data.Slice(num6 + 12));
			num7 *= 597399067;
			num7 = Rotl32(num7, 15);
			num7 *= 2869860233u;
			num ^= num7;
			num = Rotl32(num, 19);
			num += num2;
			num = num * 5 + 1444728091;
			num8 *= 2869860233u;
			num8 = Rotl32(num8, 16);
			num8 *= 951274213;
			num2 ^= num8;
			num2 = Rotl32(num2, 17);
			num2 += num3;
			num2 = num2 * 5 + 197830471;
			num9 *= 951274213;
			num9 = Rotl32(num9, 17);
			num9 *= 2716044179u;
			num3 ^= num9;
			num3 = Rotl32(num3, 15);
			num3 += num4;
			num3 = num3 * 5 + 2530024501u;
			num10 *= 2716044179u;
			num10 = Rotl32(num10, 18);
			num10 *= 597399067;
			num4 ^= num10;
			num4 = Rotl32(num4, 13);
			num4 += num;
			num4 = num4 * 5 + 850148119;
		}
		int num11 = num5 * 16;
		uint num12 = 0u;
		uint num13 = 0u;
		uint num14 = 0u;
		uint num15 = 0u;
		switch (len & 0xF)
		{
		case 15:
			num15 ^= (uint)(data[num11 + 14] << 16);
			goto case 14;
		case 14:
			num15 ^= (uint)(data[num11 + 13] << 8);
			goto case 13;
		case 13:
			num15 ^= data[num11 + 12];
			num15 *= 2716044179u;
			num15 = Rotl32(num15, 18);
			num15 *= 597399067;
			num4 ^= num15;
			goto case 12;
		case 12:
			num14 ^= (uint)(data[num11 + 11] << 24);
			goto case 11;
		case 11:
			num14 ^= (uint)(data[num11 + 10] << 16);
			goto case 10;
		case 10:
			num14 ^= (uint)(data[num11 + 9] << 8);
			goto case 9;
		case 9:
			num14 ^= data[num11 + 8];
			num14 *= 951274213;
			num14 = Rotl32(num14, 17);
			num14 *= 2716044179u;
			num3 ^= num14;
			goto case 8;
		case 8:
			num13 ^= (uint)(data[num11 + 7] << 24);
			goto case 7;
		case 7:
			num13 ^= (uint)(data[num11 + 6] << 16);
			goto case 6;
		case 6:
			num13 ^= (uint)(data[num11 + 5] << 8);
			goto case 5;
		case 5:
			num13 ^= data[num11 + 4];
			num13 *= 2869860233u;
			num13 = Rotl32(num13, 16);
			num13 *= 951274213;
			num2 ^= num13;
			goto case 4;
		case 4:
			num12 ^= (uint)(data[num11 + 3] << 24);
			goto case 3;
		case 3:
			num12 ^= (uint)(data[num11 + 2] << 16);
			goto case 2;
		case 2:
			num12 ^= (uint)(data[num11 + 1] << 8);
			goto case 1;
		case 1:
			num12 ^= data[num11];
			num12 *= 597399067;
			num12 = Rotl32(num12, 15);
			num12 *= 2869860233u;
			num ^= num12;
			break;
		}
		num ^= (uint)len;
		num2 ^= (uint)len;
		num3 ^= (uint)len;
		num4 ^= (uint)len;
		num += num2;
		num += num3;
		num += num4;
		num2 += num;
		num3 += num;
		num4 += num;
		num = Fmix32(num);
		num2 = Fmix32(num2);
		num3 = Fmix32(num3);
		num4 = Fmix32(num4);
		num += num2;
		num += num3;
		num += num4;
		num2 += num;
		num3 += num;
		num4 += num;
		outHash[0] = num;
		outHash[1] = num2;
		outHash[2] = num3;
		outHash[3] = num4;
	}

	private static void Compute_x64_128(ReadOnlySpan<byte> data, int len, uint seed, Span<ulong> outHash)
	{
		ulong num = seed;
		ulong num2 = seed;
		int num3 = len / 16;
		for (int i = 0; i < num3; i++)
		{
			int num4 = i * 16;
			ulong num5 = BinaryPrimitives.ReadUInt64LittleEndian(data.Slice(num4));
			ulong num6 = BinaryPrimitives.ReadUInt64LittleEndian(data.Slice(num4 + 8));
			num5 *= 9782798678568883157uL;
			num5 = Rotl64(num5, 31);
			num5 *= 5545529020109919103L;
			num ^= num5;
			num = Rotl64(num, 27);
			num += num2;
			num = num * 5 + 1390208809;
			num6 *= 5545529020109919103L;
			num6 = Rotl64(num6, 33);
			num6 *= 9782798678568883157uL;
			num2 ^= num6;
			num2 = Rotl64(num2, 31);
			num2 += num;
			num2 = num2 * 5 + 944331445;
		}
		int num7 = num3 * 16;
		ulong num8 = 0uL;
		ulong num9 = 0uL;
		switch (len & 0xF)
		{
		case 15:
			num9 ^= (ulong)data[num7 + 14] << 48;
			goto case 14;
		case 14:
			num9 ^= (ulong)data[num7 + 13] << 40;
			goto case 13;
		case 13:
			num9 ^= (ulong)data[num7 + 12] << 32;
			goto case 12;
		case 12:
			num9 ^= (ulong)data[num7 + 11] << 24;
			goto case 11;
		case 11:
			num9 ^= (ulong)data[num7 + 10] << 16;
			goto case 10;
		case 10:
			num9 ^= (ulong)data[num7 + 9] << 8;
			goto case 9;
		case 9:
			num9 ^= data[num7 + 8];
			num9 *= 5545529020109919103L;
			num9 = Rotl64(num9, 33);
			num9 *= 9782798678568883157uL;
			num2 ^= num9;
			goto case 8;
		case 8:
			num8 ^= (ulong)data[num7 + 7] << 56;
			goto case 7;
		case 7:
			num8 ^= (ulong)data[num7 + 6] << 48;
			goto case 6;
		case 6:
			num8 ^= (ulong)data[num7 + 5] << 40;
			goto case 5;
		case 5:
			num8 ^= (ulong)data[num7 + 4] << 32;
			goto case 4;
		case 4:
			num8 ^= (ulong)data[num7 + 3] << 24;
			goto case 3;
		case 3:
			num8 ^= (ulong)data[num7 + 2] << 16;
			goto case 2;
		case 2:
			num8 ^= (ulong)data[num7 + 1] << 8;
			goto case 1;
		case 1:
			num8 ^= data[num7];
			num8 *= 9782798678568883157uL;
			num8 = Rotl64(num8, 31);
			num8 *= 5545529020109919103L;
			num ^= num8;
			break;
		}
		num ^= (ulong)len;
		num2 ^= (ulong)len;
		num += num2;
		num2 += num;
		num = Fmix64(num);
		num2 = Fmix64(num2);
		num += num2;
		num2 += num;
		outHash[0] = num;
		outHash[1] = num2;
	}

	private static uint Rotl32(uint x, int r)
	{
		return (x << r) | (x >> 32 - r);
	}

	private static ulong Rotl64(ulong x, int r)
	{
		return (x << r) | (x >> 64 - r);
	}

	private static uint Fmix32(uint h)
	{
		h ^= h >> 16;
		h *= 2246822507u;
		h ^= h >> 13;
		h *= 3266489909u;
		h ^= h >> 16;
		return h;
	}

	private static ulong Fmix64(ulong k)
	{
		k ^= k >> 33;
		k *= 18397679294719823053uL;
		k ^= k >> 33;
		k *= 14181476777654086739uL;
		k ^= k >> 33;
		return k;
	}

	private static void GetBytes(Span<byte> buffer, ulong v)
	{
		if (BitConverter.IsLittleEndian)
		{
			v = BinaryPrimitives.ReverseEndianness(v);
		}
		BinaryPrimitives.WriteUInt64LittleEndian(buffer, v);
	}

	private static void GetBytes(Span<byte> buffer, uint v)
	{
		if (BitConverter.IsLittleEndian)
		{
			v = BinaryPrimitives.ReverseEndianness(v);
		}
		BinaryPrimitives.WriteUInt32LittleEndian(buffer, v);
	}
}
