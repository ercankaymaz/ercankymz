using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal static class Crc32
{
	public const uint SeedValue = 0u;

	private const int MinBufferSize = 64;

	private const int ChunksizeMask = 15;

	private static readonly ulong[] K05Poly = new ulong[8] { 5708721108uL, 7631803798uL, 6259578832uL, 3433693342uL, 5969371428uL, 0uL, 7976584769uL, 8439010881uL };

	private static readonly uint[] CrcTable = new uint[256]
	{
		0u, 1996959894u, 3993919788u, 2567524794u, 124634137u, 1886057615u, 3915621685u, 2657392035u, 249268274u, 2044508324u,
		3772115230u, 2547177864u, 162941995u, 2125561021u, 3887607047u, 2428444049u, 498536548u, 1789927666u, 4089016648u, 2227061214u,
		450548861u, 1843258603u, 4107580753u, 2211677639u, 325883990u, 1684777152u, 4251122042u, 2321926636u, 335633487u, 1661365465u,
		4195302755u, 2366115317u, 997073096u, 1281953886u, 3579855332u, 2724688242u, 1006888145u, 1258607687u, 3524101629u, 2768942443u,
		901097722u, 1119000684u, 3686517206u, 2898065728u, 853044451u, 1172266101u, 3705015759u, 2882616665u, 651767980u, 1373503546u,
		3369554304u, 3218104598u, 565507253u, 1454621731u, 3485111705u, 3099436303u, 671266974u, 1594198024u, 3322730930u, 2970347812u,
		795835527u, 1483230225u, 3244367275u, 3060149565u, 1994146192u, 31158534u, 2563907772u, 4023717930u, 1907459465u, 112637215u,
		2680153253u, 3904427059u, 2013776290u, 251722036u, 2517215374u, 3775830040u, 2137656763u, 141376813u, 2439277719u, 3865271297u,
		1802195444u, 476864866u, 2238001368u, 4066508878u, 1812370925u, 453092731u, 2181625025u, 4111451223u, 1706088902u, 314042704u,
		2344532202u, 4240017532u, 1658658271u, 366619977u, 2362670323u, 4224994405u, 1303535960u, 984961486u, 2747007092u, 3569037538u,
		1256170817u, 1037604311u, 2765210733u, 3554079995u, 1131014506u, 879679996u, 2909243462u, 3663771856u, 1141124467u, 855842277u,
		2852801631u, 3708648649u, 1342533948u, 654459306u, 3188396048u, 3373015174u, 1466479909u, 544179635u, 3110523913u, 3462522015u,
		1591671054u, 702138776u, 2966460450u, 3352799412u, 1504918807u, 783551873u, 3082640443u, 3233442989u, 3988292384u, 2596254646u,
		62317068u, 1957810842u, 3939845945u, 2647816111u, 81470997u, 1943803523u, 3814918930u, 2489596804u, 225274430u, 2053790376u,
		3826175755u, 2466906013u, 167816743u, 2097651377u, 4027552580u, 2265490386u, 503444072u, 1762050814u, 4150417245u, 2154129355u,
		426522225u, 1852507879u, 4275313526u, 2312317920u, 282753626u, 1742555852u, 4189708143u, 2394877945u, 397917763u, 1622183637u,
		3604390888u, 2714866558u, 953729732u, 1340076626u, 3518719985u, 2797360999u, 1068828381u, 1219638859u, 3624741850u, 2936675148u,
		906185462u, 1090812512u, 3747672003u, 2825379669u, 829329135u, 1181335161u, 3412177804u, 3160834842u, 628085408u, 1382605366u,
		3423369109u, 3138078467u, 570562233u, 1426400815u, 3317316542u, 2998733608u, 733239954u, 1555261956u, 3268935591u, 3050360625u,
		752459403u, 1541320221u, 2607071920u, 3965973030u, 1969922972u, 40735498u, 2617837225u, 3943577151u, 1913087877u, 83908371u,
		2512341634u, 3803740692u, 2075208622u, 213261112u, 2463272603u, 3855990285u, 2094854071u, 198958881u, 2262029012u, 4057260610u,
		1759359992u, 534414190u, 2176718541u, 4139329115u, 1873836001u, 414664567u, 2282248934u, 4279200368u, 1711684554u, 285281116u,
		2405801727u, 4167216745u, 1634467795u, 376229701u, 2685067896u, 3608007406u, 1308918612u, 956543938u, 2808555105u, 3495958263u,
		1231636301u, 1047427035u, 2932959818u, 3654703836u, 1088359270u, 936918000u, 2847714899u, 3736837829u, 1202900863u, 817233897u,
		3183342108u, 3401237130u, 1404277552u, 615818150u, 3134207493u, 3453421203u, 1423857449u, 601450431u, 3009837614u, 3294710456u,
		1567103746u, 711928724u, 3020668471u, 3272380065u, 1510334235u, 755167117u
	};

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Calculate(ReadOnlySpan<byte> buffer)
	{
		return Calculate(0u, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Calculate(uint crc, ReadOnlySpan<byte> buffer)
	{
		if (buffer.IsEmpty)
		{
			return crc;
		}
		if (Sse41.IsSupported && Pclmulqdq.IsSupported && buffer.Length >= 64)
		{
			return ~CalculateSse(~crc, buffer);
		}
		if (System.Runtime.Intrinsics.Arm.Crc32.Arm64.IsSupported)
		{
			return ~CalculateArm64(~crc, buffer);
		}
		if (System.Runtime.Intrinsics.Arm.Crc32.IsSupported)
		{
			return ~CalculateArm(~crc, buffer);
		}
		return ~CalculateScalar(~crc, buffer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private unsafe static uint CalculateSse(uint crc, ReadOnlySpan<byte> buffer)
	{
		int num = buffer.Length & -16;
		int num2 = num;
		fixed (byte* ptr = buffer)
		{
			fixed (ulong* k05Poly = K05Poly)
			{
				byte* ptr2 = ptr;
				ulong* ptr3 = k05Poly;
				Vector128<ulong> left = Sse2.LoadVector128((ulong*)ptr2);
				Vector128<ulong> vector = Sse2.LoadVector128((ulong*)ptr2 + 2);
				Vector128<ulong> vector2 = Sse2.LoadVector128((ulong*)ptr2 + 4);
				Vector128<ulong> vector3 = Sse2.LoadVector128((ulong*)ptr2 + 6);
				left = Sse2.Xor(left, Sse2.ConvertScalarToVector128UInt32(crc).AsUInt64());
				Vector128<ulong> right = Sse2.LoadVector128(ptr3);
				ptr2 += 64;
				Vector128<ulong> right2;
				for (num2 -= 64; num2 >= 64; num2 -= 64)
				{
					right2 = Pclmulqdq.CarrylessMultiply(left, right, 0);
					Vector128<ulong> right3 = Pclmulqdq.CarrylessMultiply(vector, right, 0);
					Vector128<ulong> right4 = Pclmulqdq.CarrylessMultiply(vector2, right, 0);
					Vector128<ulong> right5 = Pclmulqdq.CarrylessMultiply(vector3, right, 0);
					left = Pclmulqdq.CarrylessMultiply(left, right, 17);
					vector = Pclmulqdq.CarrylessMultiply(vector, right, 17);
					vector2 = Pclmulqdq.CarrylessMultiply(vector2, right, 17);
					vector3 = Pclmulqdq.CarrylessMultiply(vector3, right, 17);
					Vector128<ulong> right6 = Sse2.LoadVector128((ulong*)ptr2);
					Vector128<ulong> right7 = Sse2.LoadVector128((ulong*)ptr2 + 2);
					Vector128<ulong> right8 = Sse2.LoadVector128((ulong*)ptr2 + 4);
					Vector128<ulong> right9 = Sse2.LoadVector128((ulong*)ptr2 + 6);
					left = Sse2.Xor(left, right2);
					vector = Sse2.Xor(vector, right3);
					vector2 = Sse2.Xor(vector2, right4);
					vector3 = Sse2.Xor(vector3, right5);
					left = Sse2.Xor(left, right6);
					vector = Sse2.Xor(vector, right7);
					vector2 = Sse2.Xor(vector2, right8);
					vector3 = Sse2.Xor(vector3, right9);
					ptr2 += 64;
				}
				right = Sse2.LoadVector128(k05Poly + 2);
				right2 = Pclmulqdq.CarrylessMultiply(left, right, 0);
				left = Pclmulqdq.CarrylessMultiply(left, right, 17);
				left = Sse2.Xor(left, vector);
				left = Sse2.Xor(left, right2);
				right2 = Pclmulqdq.CarrylessMultiply(left, right, 0);
				left = Pclmulqdq.CarrylessMultiply(left, right, 17);
				left = Sse2.Xor(left, vector2);
				left = Sse2.Xor(left, right2);
				right2 = Pclmulqdq.CarrylessMultiply(left, right, 0);
				left = Pclmulqdq.CarrylessMultiply(left, right, 17);
				left = Sse2.Xor(left, vector3);
				left = Sse2.Xor(left, right2);
				while (num2 >= 16)
				{
					vector = Sse2.LoadVector128((ulong*)ptr2);
					right2 = Pclmulqdq.CarrylessMultiply(left, right, 0);
					left = Pclmulqdq.CarrylessMultiply(left, right, 17);
					left = Sse2.Xor(left, vector);
					left = Sse2.Xor(left, right2);
					ptr2 += 16;
					num2 -= 16;
				}
				vector = Pclmulqdq.CarrylessMultiply(left, right, 16);
				vector2 = Vector128.Create(-1, 0, -1, 0).AsUInt64();
				left = Sse2.ShiftRightLogical128BitLane(left, 8);
				left = Sse2.Xor(left, vector);
				right = Sse2.LoadScalarVector128(ptr3 + 4);
				vector = Sse2.ShiftRightLogical128BitLane(left, 4);
				left = Sse2.And(left, vector2);
				left = Pclmulqdq.CarrylessMultiply(left, right, 0);
				left = Sse2.Xor(left, vector);
				right = Sse2.LoadVector128(ptr3 + 6);
				vector = Sse2.And(left, vector2);
				vector = Pclmulqdq.CarrylessMultiply(vector, right, 16);
				vector = Sse2.And(vector, vector2);
				vector = Pclmulqdq.CarrylessMultiply(vector, right, 0);
				left = Sse2.Xor(left, vector);
				crc = (uint)Sse41.Extract(left.AsInt32(), 1);
				if (buffer.Length - num != 0)
				{
					uint crc2 = crc;
					int num3 = num;
					return CalculateScalar(crc2, buffer.Slice(num3, buffer.Length - num3));
				}
				return crc;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private unsafe static uint CalculateArm(uint crc, ReadOnlySpan<byte> buffer)
	{
		fixed (byte* ptr = buffer)
		{
			byte* ptr2 = ptr;
			int num = buffer.Length;
			while (num > 0 && ((ulong)ptr2 & 3uL) != 0L)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr2++));
				num--;
			}
			uint* ptr3 = (uint*)ptr2;
			while (num >= 32)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				num -= 32;
			}
			while (num >= 4)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr3++));
				num -= 4;
			}
			ptr2 = (byte*)ptr3;
			while (num > 0)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr2++));
				num--;
			}
			return crc;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private unsafe static uint CalculateArm64(uint crc, ReadOnlySpan<byte> buffer)
	{
		fixed (byte* ptr = buffer)
		{
			byte* ptr2 = ptr;
			int num = buffer.Length;
			while (num > 0 && ((ulong)ptr2 & 7uL) != 0L)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr2++));
				num--;
			}
			ulong* ptr3 = (ulong*)ptr2;
			while (num >= 64)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				num -= 64;
			}
			while (num >= 8)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.Arm64.ComputeCrc32(crc, *(ptr3++));
				num -= 8;
			}
			ptr2 = (byte*)ptr3;
			while (num > 0)
			{
				crc = System.Runtime.Intrinsics.Arm.Crc32.ComputeCrc32(crc, *(ptr2++));
				num--;
			}
			return crc;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private static uint CalculateScalar(uint crc, ReadOnlySpan<byte> buffer)
	{
		ref uint reference = ref MemoryMarshal.GetReference<uint>(MemoryExtensions.AsSpan<uint>(CrcTable));
		ref byte reference2 = ref MemoryMarshal.GetReference<byte>(buffer);
		for (int i = 0; i < buffer.Length; i++)
		{
			crc = Unsafe.Add(ref reference, (crc ^ Unsafe.Add(ref reference2, i)) & 0xFF) ^ (crc >> 8);
		}
		return crc;
	}
}
