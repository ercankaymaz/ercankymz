using System;

internal static class _0023_003Dq83txtBmFlxymCNA_sU7I_0024dGG2o5r1_0024iekY4LWIcGipg_003D
{
	private static uint _0023_003DzsooCtzMpxEh6dd6pNWlIBAY_003D(uint _0023_003DziDLVpbY_003D, uint _0023_003Dz5rQzobg_003D, uint _0023_003DzAvn2b38_003D, int _0023_003DzR58imxw_003D, uint _0023_003DzmQTFaQA_003D, uint[] _0023_003DzWYPqg2E_003D)
	{
		return (((_0023_003DzAvn2b38_003D >> 5) ^ (_0023_003Dz5rQzobg_003D << 2)) + ((_0023_003Dz5rQzobg_003D >> 3) ^ (_0023_003DzAvn2b38_003D << 4))) ^ ((_0023_003DziDLVpbY_003D ^ _0023_003Dz5rQzobg_003D) + (_0023_003DzWYPqg2E_003D[(_0023_003DzR58imxw_003D & 3) ^ _0023_003DzmQTFaQA_003D] ^ _0023_003DzAvn2b38_003D));
	}

	public static void _0023_003Dzb_PcqFOYBcXHDo3Hh2cmxoigNyH9J8_FuQ_003D_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D)
	{
		if (_0023_003DziDLVpbY_003D.Length != 0 && _0023_003DziDLVpbY_003D.Length != 0)
		{
			if (_0023_003Dz5rQzobg_003D + _0023_003DzAvn2b38_003D > _0023_003DziDLVpbY_003D.Length || _0023_003DzAvn2b38_003D % 4 != 0 || _0023_003DzAvn2b38_003D < 8)
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907884));
			}
			if (_0023_003DzR58imxw_003D == null || _0023_003DzR58imxw_003D.Length > 16)
			{
				throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907861));
			}
			uint[] array = new uint[_0023_003DzAvn2b38_003D / 4];
			_0023_003DzbBlmB0ceCNgt7D4AcAr41s0_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, array, 0);
			uint[] array2 = new uint[4];
			_0023_003DzbBlmB0ceCNgt7D4AcAr41s0_003D(_0023_003DzR58imxw_003D, 0, _0023_003DzR58imxw_003D.Length, array2, 0);
			_0023_003DzP7EBdpFCJVCcXi_i8sdbl23l3gjg(array, array2);
			_0023_003DzLutrZX_WC171pHv1ffw3ARxkAklbdsQRSFza_0024YM_003D(array, 0, array.Length, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		}
	}

	private static void _0023_003DzP7EBdpFCJVCcXi_i8sdbl23l3gjg(uint[] _0023_003DziDLVpbY_003D, uint[] _0023_003Dz5rQzobg_003D)
	{
		int num = _0023_003DziDLVpbY_003D.Length - 1;
		if (num < 1)
		{
			return;
		}
		uint _0023_003DzAvn2b38_003D = _0023_003DziDLVpbY_003D[num];
		uint num2 = 0u;
		int num3 = 6 + 52 / (num + 1);
		while (0 < num3--)
		{
			num2 += 2654435769u;
			uint _0023_003DzmQTFaQA_003D = (num2 >> 2) & 3;
			int i;
			uint _0023_003Dz5rQzobg_003D2;
			for (i = 0; i < num; i++)
			{
				_0023_003Dz5rQzobg_003D2 = _0023_003DziDLVpbY_003D[i + 1];
				_0023_003DzAvn2b38_003D = (_0023_003DziDLVpbY_003D[i] += _0023_003DzsooCtzMpxEh6dd6pNWlIBAY_003D(num2, _0023_003Dz5rQzobg_003D2, _0023_003DzAvn2b38_003D, i, _0023_003DzmQTFaQA_003D, _0023_003Dz5rQzobg_003D));
			}
			_0023_003Dz5rQzobg_003D2 = _0023_003DziDLVpbY_003D[0];
			_0023_003DzAvn2b38_003D = (_0023_003DziDLVpbY_003D[num] += _0023_003DzsooCtzMpxEh6dd6pNWlIBAY_003D(num2, _0023_003Dz5rQzobg_003D2, _0023_003DzAvn2b38_003D, i, _0023_003DzmQTFaQA_003D, _0023_003Dz5rQzobg_003D));
		}
	}

	private static uint[] _0023_003DzbBlmB0ceCNgt7D4AcAr41s0_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, uint[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D)
	{
		if (_0023_003Dz5rQzobg_003D + _0023_003DzAvn2b38_003D > _0023_003DziDLVpbY_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzAvn2b38_003D / 4;
		if (_0023_003DzmQTFaQA_003D + num > _0023_003DzR58imxw_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003Dz5rQzobg_003D + _0023_003DzAvn2b38_003D;
		for (int i = _0023_003Dz5rQzobg_003D; i < num2; i += 4)
		{
			_0023_003DzR58imxw_003D[_0023_003DzmQTFaQA_003D + (i - _0023_003Dz5rQzobg_003D) / 4] = (uint)(_0023_003DziDLVpbY_003D[i] | (_0023_003DziDLVpbY_003D[i + 1] << 8) | (_0023_003DziDLVpbY_003D[i + 2] << 16) | (_0023_003DziDLVpbY_003D[i + 3] << 24));
		}
		return _0023_003DzR58imxw_003D;
	}

	private static void _0023_003DzLutrZX_WC171pHv1ffw3ARxkAklbdsQRSFza_0024YM_003D(uint[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D)
	{
		if (_0023_003Dz5rQzobg_003D + _0023_003DzAvn2b38_003D > _0023_003DziDLVpbY_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzAvn2b38_003D * 4;
		if (_0023_003DzmQTFaQA_003D + num > _0023_003DzR58imxw_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzmQTFaQA_003D + num;
		for (int i = _0023_003DzmQTFaQA_003D; i < num2; i += 4)
		{
			uint num3 = _0023_003DziDLVpbY_003D[(i - _0023_003DzmQTFaQA_003D) / 4 + _0023_003Dz5rQzobg_003D];
			_0023_003DzR58imxw_003D[i] = (byte)num3;
			_0023_003DzR58imxw_003D[i + 1] = (byte)(num3 >> 8);
			_0023_003DzR58imxw_003D[i + 2] = (byte)(num3 >> 16);
			_0023_003DzR58imxw_003D[i + 3] = (byte)(num3 >> 24);
		}
	}
}
