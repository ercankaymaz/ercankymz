using System;
using System.IO;

internal static class _0023_003Dq_002409jZTsA_p6xzZccRASR_00240zgSm6qIo_00247ugx9QOWjsQA_003D
{
	public static void _0023_003DzLGvndnWwJb3CP0er6w_003D_003D(int _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D] = (byte)_0023_003DziDLVpbY_003D;
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 1] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 2] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 3] = (byte)(_0023_003DziDLVpbY_003D >> 24);
	}

	public static void _0023_003Dz5vIKo4yKV5g8lIthPGyb1ZjBGBd2xTvf2zJmyQK3sfL8(long _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D] = (byte)_0023_003DziDLVpbY_003D;
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 1] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 2] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 3] = (byte)(_0023_003DziDLVpbY_003D >> 24);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 4] = (byte)(_0023_003DziDLVpbY_003D >> 32);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 5] = (byte)(_0023_003DziDLVpbY_003D >> 40);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 6] = (byte)(_0023_003DziDLVpbY_003D >> 48);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 7] = (byte)(_0023_003DziDLVpbY_003D >> 56);
	}

	public static byte[] _0023_003Dzb6nG36T4dVuPIUSSPyAhaGQk3E4JBt15sfmbmMk_003D(int _0023_003DziDLVpbY_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(_0023_003DziDLVpbY_003D);
		}
		byte[] array = new byte[4];
		_0023_003DzLGvndnWwJb3CP0er6w_003D_003D(_0023_003DziDLVpbY_003D, array, 0);
		return array;
	}

	public static byte[] _0023_003DztmlE1S7thb5IGC7pZnbhAcsnvh1QCtfC0MszC6k_003D(long _0023_003DziDLVpbY_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.GetBytes(_0023_003DziDLVpbY_003D);
		}
		byte[] array = new byte[8];
		_0023_003Dz5vIKo4yKV5g8lIthPGyb1ZjBGBd2xTvf2zJmyQK3sfL8(_0023_003DziDLVpbY_003D, array, 0);
		return array;
	}

	public static int _0023_003Dzdmr3ulD800U42xZUUNfxw5s_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt32(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		}
		return _0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D] | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 1] << 8) | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 2] << 16) | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 3] << 24);
	}

	public static long _0023_003DzOCQjw4pWLcTYS1urUXgvAGuNgAgV19dZPw_003D_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		if (BitConverter.IsLittleEndian)
		{
			return BitConverter.ToInt64(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		}
		return (long)(_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D] | ((ulong)_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 1] << 8) | ((ulong)_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 2] << 16) | ((ulong)_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 3] << 24) | ((ulong)_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 4] << 32) | ((ulong)_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 5] << 40) | ((ulong)_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 6] << 48) | ((ulong)_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 7] << 56));
	}

	public static float _0023_003DzV0iv8Q9KOWeQbFeld4Ijr5RweOxnDgHv5UPRKwY_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		if (BitConverter.IsLittleEndian && _0023_003DqN_Lzrpin_XrYR283pJ4HqqcXzCRu1rfgIXw2K5eUV6A_003D._0023_003DziDLVpbY_003D)
		{
			return BitConverter.ToSingle(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, 4, writable: false));
		float result = binaryReader.ReadSingle();
		binaryReader.Close();
		return result;
	}

	public static double _0023_003Dz40KZulNImcDT8fkUqtaFuA8YdKEH(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		if (BitConverter.IsLittleEndian && _0023_003Dq4h0qvju5ScNHjkj2BP6NZr1TOuSr08WpSAKIbEYPcow_003D._0023_003DziDLVpbY_003D)
		{
			return BitConverter.ToDouble(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, 8, writable: false));
		double result = binaryReader.ReadDouble();
		binaryReader.Close();
		return result;
	}
}
