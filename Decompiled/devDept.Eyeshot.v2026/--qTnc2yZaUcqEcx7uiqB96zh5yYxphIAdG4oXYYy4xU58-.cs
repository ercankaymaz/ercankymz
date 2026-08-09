using System;

internal sealed class _0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D
{
	private byte[] _0023_003DziDLVpbY_003D;

	private int _0023_003Dz5rQzobg_003D;

	private long _0023_003DzAvn2b38_003D;

	private uint _0023_003DzR58imxw_003D;

	private uint _0023_003DzmQTFaQA_003D;

	private uint _0023_003DzWYPqg2E_003D;

	private uint _0023_003DzEWLeis8_003D;

	private uint _0023_003DzbfrNXYE_003D;

	private uint[] _0023_003DzkKfJheA_003D = new uint[80];

	private int _0023_003DzId5C3LA_003D;

	public _0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D()
	{
		_0023_003DziDLVpbY_003D = new byte[4];
		_0023_003DzrfgP5mkfEC4V69cbQEZyxhsOCIgFIAbcUA_003D_003D();
	}

	public _0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D(_0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DzDx2cUCqDb_0024d58niVHqDPLrwGAnsH(_0023_003DziDLVpbY_003D);
	}

	public void _0023_003DzCZyZ2u1_0024_0024Vp8HOQNSO_0024y0Oc_003D(byte _0023_003DziDLVpbY_003D)
	{
		this._0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D++] = _0023_003DziDLVpbY_003D;
		if (_0023_003Dz5rQzobg_003D == this._0023_003DziDLVpbY_003D.Length)
		{
			_0023_003DzaKDPx0H5I3AkY9Cy_0024_00249yFJU_003D(this._0023_003DziDLVpbY_003D, 0);
			_0023_003Dz5rQzobg_003D = 0;
		}
		_0023_003DzAvn2b38_003D++;
	}

	public void _0023_003Dz4N_0024bfWyxnhkMLpdZ1SH1dwwdLF_lc9o_2X4a7WM_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		_0023_003DzAvn2b38_003D = Math.Max(0, _0023_003DzAvn2b38_003D);
		int i = 0;
		if (this._0023_003Dz5rQzobg_003D != 0)
		{
			while (i < _0023_003DzAvn2b38_003D)
			{
				this._0023_003DziDLVpbY_003D[this._0023_003Dz5rQzobg_003D++] = _0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + i++];
				if (this._0023_003Dz5rQzobg_003D == 4)
				{
					_0023_003DzaKDPx0H5I3AkY9Cy_0024_00249yFJU_003D(this._0023_003DziDLVpbY_003D, 0);
					this._0023_003Dz5rQzobg_003D = 0;
					break;
				}
			}
		}
		for (int num = ((_0023_003DzAvn2b38_003D - i) & -4) + i; i < num; i += 4)
		{
			_0023_003DzaKDPx0H5I3AkY9Cy_0024_00249yFJU_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D + i);
		}
		while (i < _0023_003DzAvn2b38_003D)
		{
			this._0023_003DziDLVpbY_003D[this._0023_003Dz5rQzobg_003D++] = _0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + i++];
		}
		this._0023_003DzAvn2b38_003D += _0023_003DzAvn2b38_003D;
	}

	public void _0023_003DzGc71CfIB9xwhcV29hhrbP3CEML3pA3k_0024uWV2u6g_003D()
	{
		long num = _0023_003DzAvn2b38_003D << 3;
		_0023_003DzCZyZ2u1_0024_0024Vp8HOQNSO_0024y0Oc_003D(128);
		while (_0023_003Dz5rQzobg_003D != 0)
		{
			_0023_003DzCZyZ2u1_0024_0024Vp8HOQNSO_0024y0Oc_003D(0);
		}
		_0023_003Dz5Z7pYZTptNwHe3n7_g_003D_003D(num);
		_0023_003DzKj2eQ5ijH7lrNuGIDeJ3Z1GpXLSssSHh7jEgXN4_003D();
	}

	public int _0023_003DzynILTSm40qrU3jFSC4DnwSY_003D()
	{
		return 64;
	}

	private void _0023_003DzDx2cUCqDb_0024d58niVHqDPLrwGAnsH(_0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D _0023_003DziDLVpbY_003D)
	{
		this._0023_003DziDLVpbY_003D = new byte[_0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D.Length];
		Buffer.BlockCopy(_0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D, 0, this._0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D.Length);
		_0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D._0023_003Dz5rQzobg_003D;
		_0023_003DzAvn2b38_003D = _0023_003DziDLVpbY_003D._0023_003DzAvn2b38_003D;
		_0023_003DzR58imxw_003D = _0023_003DziDLVpbY_003D._0023_003DzR58imxw_003D;
		_0023_003DzmQTFaQA_003D = _0023_003DziDLVpbY_003D._0023_003DzmQTFaQA_003D;
		_0023_003DzWYPqg2E_003D = _0023_003DziDLVpbY_003D._0023_003DzWYPqg2E_003D;
		_0023_003DzEWLeis8_003D = _0023_003DziDLVpbY_003D._0023_003DzEWLeis8_003D;
		_0023_003DzbfrNXYE_003D = _0023_003DziDLVpbY_003D._0023_003DzbfrNXYE_003D;
		Array.Copy(_0023_003DziDLVpbY_003D._0023_003DzkKfJheA_003D, 0, _0023_003DzkKfJheA_003D, 0, _0023_003DziDLVpbY_003D._0023_003DzkKfJheA_003D.Length);
		_0023_003DzId5C3LA_003D = _0023_003DziDLVpbY_003D._0023_003DzId5C3LA_003D;
	}

	public int _0023_003Dz_0024fPeVwA3Gw_DbQDQtJCt9F0_003D()
	{
		return 20;
	}

	public void _0023_003DzaKDPx0H5I3AkY9Cy_0024_00249yFJU_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		_0023_003DzkKfJheA_003D[_0023_003DzId5C3LA_003D] = _0023_003DzDzdfWyoE7FNObkOj8QVKkH_vWOvy(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		if (++_0023_003DzId5C3LA_003D == 16)
		{
			_0023_003DzKj2eQ5ijH7lrNuGIDeJ3Z1GpXLSssSHh7jEgXN4_003D();
		}
	}

	public void _0023_003Dz5Z7pYZTptNwHe3n7_g_003D_003D(long _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DzId5C3LA_003D > 14)
		{
			_0023_003DzKj2eQ5ijH7lrNuGIDeJ3Z1GpXLSssSHh7jEgXN4_003D();
		}
		_0023_003DzkKfJheA_003D[14] = (uint)((ulong)_0023_003DziDLVpbY_003D >> 32);
		_0023_003DzkKfJheA_003D[15] = (uint)_0023_003DziDLVpbY_003D;
	}

	public int _0023_003DzRKqewGHP9pYk9bCU1jUHJIKE_zaqQEPAMRI_lyLRaVEl(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		_0023_003DzGc71CfIB9xwhcV29hhrbP3CEML3pA3k_0024uWV2u6g_003D();
		_0023_003DzrXk24WQSiW07BrA_00249OSfOH6jEIC6AjHbc4udUD2v9MAO(_0023_003DzR58imxw_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		_0023_003DzrXk24WQSiW07BrA_00249OSfOH6jEIC6AjHbc4udUD2v9MAO(_0023_003DzmQTFaQA_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D + 4);
		_0023_003DzrXk24WQSiW07BrA_00249OSfOH6jEIC6AjHbc4udUD2v9MAO(_0023_003DzWYPqg2E_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D + 8);
		_0023_003DzrXk24WQSiW07BrA_00249OSfOH6jEIC6AjHbc4udUD2v9MAO(_0023_003DzEWLeis8_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D + 12);
		_0023_003DzrXk24WQSiW07BrA_00249OSfOH6jEIC6AjHbc4udUD2v9MAO(_0023_003DzbfrNXYE_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D + 16);
		_0023_003DzrfgP5mkfEC4V69cbQEZyxhsOCIgFIAbcUA_003D_003D();
		return 20;
	}

	public void _0023_003DzrfgP5mkfEC4V69cbQEZyxhsOCIgFIAbcUA_003D_003D()
	{
		_0023_003DzAvn2b38_003D = 0L;
		_0023_003Dz5rQzobg_003D = 0;
		Array.Clear(_0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D.Length);
		_0023_003DzR58imxw_003D = 1732584193u;
		_0023_003DzmQTFaQA_003D = 4023233417u;
		_0023_003DzWYPqg2E_003D = 2562383102u;
		_0023_003DzEWLeis8_003D = 271733878u;
		_0023_003DzbfrNXYE_003D = 3285377520u;
		_0023_003DzId5C3LA_003D = 0;
		Array.Clear(_0023_003DzkKfJheA_003D, 0, _0023_003DzkKfJheA_003D.Length);
	}

	private static uint _0023_003Dzm65XnmekTQlVOUGjKXxFiWzbFi6Z(uint _0023_003DziDLVpbY_003D, uint _0023_003Dz5rQzobg_003D, uint _0023_003DzAvn2b38_003D)
	{
		return (_0023_003DziDLVpbY_003D & _0023_003Dz5rQzobg_003D) | (~_0023_003DziDLVpbY_003D & _0023_003DzAvn2b38_003D);
	}

	private static uint _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(uint _0023_003DziDLVpbY_003D, uint _0023_003Dz5rQzobg_003D, uint _0023_003DzAvn2b38_003D)
	{
		return _0023_003DziDLVpbY_003D ^ _0023_003Dz5rQzobg_003D ^ _0023_003DzAvn2b38_003D;
	}

	private static uint _0023_003Dzc5dqDUrSLCjJnyWzeZsFM1OZOhHVc3bCl2bd0NM_003D(uint _0023_003DziDLVpbY_003D, uint _0023_003Dz5rQzobg_003D, uint _0023_003DzAvn2b38_003D)
	{
		return (_0023_003DziDLVpbY_003D & _0023_003Dz5rQzobg_003D) | (_0023_003DziDLVpbY_003D & _0023_003DzAvn2b38_003D) | (_0023_003Dz5rQzobg_003D & _0023_003DzAvn2b38_003D);
	}

	private void _0023_003DzKj2eQ5ijH7lrNuGIDeJ3Z1GpXLSssSHh7jEgXN4_003D()
	{
		for (int i = 16; i < 80; i++)
		{
			uint num = _0023_003DzkKfJheA_003D[i - 3] ^ _0023_003DzkKfJheA_003D[i - 8] ^ _0023_003DzkKfJheA_003D[i - 14] ^ _0023_003DzkKfJheA_003D[i - 16];
			_0023_003DzkKfJheA_003D[i] = (num << 1) | (num >> 31);
		}
		uint num2 = _0023_003DzR58imxw_003D;
		uint num3 = _0023_003DzmQTFaQA_003D;
		uint num4 = _0023_003DzWYPqg2E_003D;
		uint num5 = _0023_003DzEWLeis8_003D;
		uint num6 = _0023_003DzbfrNXYE_003D;
		int num7 = 0;
		for (int j = 0; j < 4; j++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003Dzm65XnmekTQlVOUGjKXxFiWzbFi6Z(num3, num4, num5) + _0023_003DzkKfJheA_003D[num7++] + 1518500249;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003Dzm65XnmekTQlVOUGjKXxFiWzbFi6Z(num2, num3, num4) + _0023_003DzkKfJheA_003D[num7++] + 1518500249;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003Dzm65XnmekTQlVOUGjKXxFiWzbFi6Z(num6, num2, num3) + _0023_003DzkKfJheA_003D[num7++] + 1518500249;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003Dzm65XnmekTQlVOUGjKXxFiWzbFi6Z(num5, num6, num2) + _0023_003DzkKfJheA_003D[num7++] + 1518500249;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003Dzm65XnmekTQlVOUGjKXxFiWzbFi6Z(num4, num5, num6) + _0023_003DzkKfJheA_003D[num7++] + 1518500249;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int k = 0; k < 4; k++)
		{
			num6 += ((num2 << 5) | (num2 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num3, num4, num5) + _0023_003DzkKfJheA_003D[num7++] + 1859775393;
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += ((num6 << 5) | (num6 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num2, num3, num4) + _0023_003DzkKfJheA_003D[num7++] + 1859775393;
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += ((num5 << 5) | (num5 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num6, num2, num3) + _0023_003DzkKfJheA_003D[num7++] + 1859775393;
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += ((num4 << 5) | (num4 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num5, num6, num2) + _0023_003DzkKfJheA_003D[num7++] + 1859775393;
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += ((num3 << 5) | (num3 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num4, num5, num6) + _0023_003DzkKfJheA_003D[num7++] + 1859775393;
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int l = 0; l < 4; l++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003Dzc5dqDUrSLCjJnyWzeZsFM1OZOhHVc3bCl2bd0NM_003D(num3, num4, num5) + _0023_003DzkKfJheA_003D[num7++]) + -1894007588);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003Dzc5dqDUrSLCjJnyWzeZsFM1OZOhHVc3bCl2bd0NM_003D(num2, num3, num4) + _0023_003DzkKfJheA_003D[num7++]) + -1894007588);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003Dzc5dqDUrSLCjJnyWzeZsFM1OZOhHVc3bCl2bd0NM_003D(num6, num2, num3) + _0023_003DzkKfJheA_003D[num7++]) + -1894007588);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003Dzc5dqDUrSLCjJnyWzeZsFM1OZOhHVc3bCl2bd0NM_003D(num5, num6, num2) + _0023_003DzkKfJheA_003D[num7++]) + -1894007588);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003Dzc5dqDUrSLCjJnyWzeZsFM1OZOhHVc3bCl2bd0NM_003D(num4, num5, num6) + _0023_003DzkKfJheA_003D[num7++]) + -1894007588);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		for (int m = 0; m < 4; m++)
		{
			num6 += (uint)((int)(((num2 << 5) | (num2 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num3, num4, num5) + _0023_003DzkKfJheA_003D[num7++]) + -899497514);
			num3 = (num3 << 30) | (num3 >> 2);
			num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num2, num3, num4) + _0023_003DzkKfJheA_003D[num7++]) + -899497514);
			num2 = (num2 << 30) | (num2 >> 2);
			num4 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num6, num2, num3) + _0023_003DzkKfJheA_003D[num7++]) + -899497514);
			num6 = (num6 << 30) | (num6 >> 2);
			num3 += (uint)((int)(((num4 << 5) | (num4 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num5, num6, num2) + _0023_003DzkKfJheA_003D[num7++]) + -899497514);
			num5 = (num5 << 30) | (num5 >> 2);
			num2 += (uint)((int)(((num3 << 5) | (num3 >> 27)) + _0023_003Dz3RdTBNZbs7cS9ss_0024Xv8aztXUZCYz1NPW54L2_UMvo21x(num4, num5, num6) + _0023_003DzkKfJheA_003D[num7++]) + -899497514);
			num4 = (num4 << 30) | (num4 >> 2);
		}
		_0023_003DzR58imxw_003D += num2;
		_0023_003DzmQTFaQA_003D += num3;
		_0023_003DzWYPqg2E_003D += num4;
		_0023_003DzEWLeis8_003D += num5;
		_0023_003DzbfrNXYE_003D += num6;
		_0023_003DzId5C3LA_003D = 0;
		Array.Clear(_0023_003DzkKfJheA_003D, 0, 16);
	}

	private static void _0023_003DzrXk24WQSiW07BrA_00249OSfOH6jEIC6AjHbc4udUD2v9MAO(uint _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D] = (byte)(_0023_003DziDLVpbY_003D >> 24);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 1] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 2] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 3] = (byte)_0023_003DziDLVpbY_003D;
	}

	private static uint _0023_003DzDzdfWyoE7FNObkOj8QVKkH_vWOvy(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		return (uint)((_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D] << 24) | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 1] << 16) | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 2] << 8) | _0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 3]);
	}

	public _0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D _0023_003DzhCTbn3BoRq4MlnXkqsdpIZT0_0024BTuFkuYkA_003D_003D()
	{
		return new _0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D(this);
	}

	public void _0023_003DzBq1AB6d0_4uQF3Bvgy8YKqnn_vt5fWTUpw_003D_003D(_0023_003DqTnc2yZaUcqEcx7uiqB96zh5yYxphIAdG4oXYYy4xU58_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DzDx2cUCqDb_0024d58niVHqDPLrwGAnsH(_0023_003DziDLVpbY_003D);
	}
}
