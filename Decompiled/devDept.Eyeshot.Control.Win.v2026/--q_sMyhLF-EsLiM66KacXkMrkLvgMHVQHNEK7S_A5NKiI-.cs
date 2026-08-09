using System;
using System.IO;

internal static class _0023_003Dq_sMyhLF_0024EsLiM66KacXkMrkLvgMHVQHNEK7S_A5NKiI_003D
{
	public static void _0023_003Dz37uAAqsa1rgkz3kjgA_003D_003D(int _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D] = (byte)_0023_003DzjYYAPCA_003D;
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 1] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 2] = (byte)(_0023_003DzjYYAPCA_003D >> 16);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 3] = (byte)(_0023_003DzjYYAPCA_003D >> 24);
	}

	public static void _0023_003DzN_3EqI_00247SUokfYR2ijL3sl9NzxrN6x9mcuGJyDqGjI6M(long _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D] = (byte)_0023_003DzjYYAPCA_003D;
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 1] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 2] = (byte)(_0023_003DzjYYAPCA_003D >> 16);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 3] = (byte)(_0023_003DzjYYAPCA_003D >> 24);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 4] = (byte)(_0023_003DzjYYAPCA_003D >> 32);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 5] = (byte)(_0023_003DzjYYAPCA_003D >> 40);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 6] = (byte)(_0023_003DzjYYAPCA_003D >> 48);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 7] = (byte)(_0023_003DzjYYAPCA_003D >> 56);
	}

	public static byte[] _0023_003DzIeumcXurDRtPABwJalGOqgYsTA8KHtJrjRaUmSY_003D(int _0023_003DzjYYAPCA_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(_0023_003DzjYYAPCA_003D);
		}
		byte[] array = new byte[4];
		_0023_003Dz37uAAqsa1rgkz3kjgA_003D_003D(_0023_003DzjYYAPCA_003D, array, 0);
		return array;
	}

	public static byte[] _0023_003DzkcYZ87JvUuMGBoNkOF5udJJjyk28cVaqnlztJgo_003D(long _0023_003DzjYYAPCA_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(_0023_003DzjYYAPCA_003D);
		}
		byte[] array = new byte[8];
		_0023_003DzN_3EqI_00247SUokfYR2ijL3sl9NzxrN6x9mcuGJyDqGjI6M(_0023_003DzjYYAPCA_003D, array, 0);
		return array;
	}

	public static int _0023_003DzsxSqB6_VoZhb2pr_8QXoxoo_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt32(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		}
		return _0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D] | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 1] << 8) | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 2] << 16) | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 3] << 24);
	}

	public static long _0023_003Dzs1wnmGiRbhfKUWYrmBy_0024_00243pKX4HQGMkKLA_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt64(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		}
		return (long)(_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D] | ((ulong)_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 1] << 8) | ((ulong)_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 2] << 16) | ((ulong)_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 3] << 24) | ((ulong)_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 4] << 32) | ((ulong)_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 5] << 40) | ((ulong)_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 6] << 48) | ((ulong)_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 7] << 56));
	}

	public static float _0023_003DzbwqGM_T9wDYA3VBmZbuUw_Jfm88y4ktyYSQ6_rQ_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		if (BitConverter.IsLittleEndian && _0023_003Dq8wn4fhr6W1hR_0024MRZU5d91uRhfytZDXouOBRSV6UdKgo_003D._0023_003DzjYYAPCA_003D)
		{
			return BitConverter.ToSingle(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, 4, writable: false));
		float result = binaryReader.ReadSingle();
		binaryReader.Close();
		return result;
	}

	public static double _0023_003DzTgNAuTXywmWixhTv_00242OU8nhNSsC2(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		if (BitConverter.IsLittleEndian && _0023_003DqAApRutk_0024_0024_r10xpZwFNxeIa28jeEjz21V8VWwEZr0I8_003D._0023_003DzjYYAPCA_003D)
		{
			return BitConverter.ToDouble(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, 8, writable: false));
		double result = binaryReader.ReadDouble();
		binaryReader.Close();
		return result;
	}
}
