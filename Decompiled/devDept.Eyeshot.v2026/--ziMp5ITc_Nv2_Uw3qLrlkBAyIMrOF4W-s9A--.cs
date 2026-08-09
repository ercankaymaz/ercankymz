using System;

internal class _0023_003DziMp5ITc_Nv2_Uw3qLrlkBAyIMrOF4W_0024s9A_003D_003D
{
	protected enum _0023_003DzCp025oNguDa9
	{
		N = 624
	}

	protected enum _0023_003DznLcGlpnwFvnn
	{

	}

	public uint[] _0023_003DzOurSKYw_003D = new uint[624];

	protected uint _0023_003Dzj6HvpTk_003D;

	protected int _0023_003DzeMBeuAQ_003D;

	public _0023_003DziMp5ITc_Nv2_Uw3qLrlkBAyIMrOF4W_0024s9A_003D_003D(uint _0023_003Dz2ZqR0IX0iu3E)
	{
		_0023_003Dz_0024D8vcl0_003D(_0023_003Dz2ZqR0IX0iu3E);
	}

	public _0023_003DziMp5ITc_Nv2_Uw3qLrlkBAyIMrOF4W_0024s9A_003D_003D(_0023_003DziMp5ITc_Nv2_Uw3qLrlkBAyIMrOF4W_0024s9A_003D_003D _0023_003Dz0yNzT9M_003D)
	{
		uint[] array = _0023_003Dz0yNzT9M_003D._0023_003DzOurSKYw_003D;
		uint[] array2 = _0023_003DzOurSKYw_003D;
		for (int i = 0; i < 624; i++)
		{
			array2[i] = array[i];
		}
		_0023_003DzeMBeuAQ_003D = _0023_003Dz0yNzT9M_003D._0023_003DzeMBeuAQ_003D;
		_0023_003Dzj6HvpTk_003D = Convert.ToUInt32((_0023_003DzCp025oNguDa9)(624 - _0023_003DzeMBeuAQ_003D));
	}

	public static uint _0023_003DzvczacRTq0tM7()
	{
		return 0u;
	}

	public uint _0023_003DzGGFoUmczjHbF()
	{
		if (_0023_003DzeMBeuAQ_003D == 0)
		{
			_0023_003Dz8JPeLWI_003D();
		}
		_0023_003DzeMBeuAQ_003D--;
		uint num = _0023_003DzOurSKYw_003D[_0023_003Dzj6HvpTk_003D];
		_0023_003Dzj6HvpTk_003D++;
		uint num2 = num ^ (num >> 11);
		uint num3 = num2 ^ ((num2 << 7) & 0x9D2C5680u);
		uint num4 = num3 ^ ((num3 << 15) & 0xEFC60000u);
		return num4 ^ (num4 >> 18);
	}

	public void _0023_003Dz_0024D8vcl0_003D(uint _0023_003Dz2ZqR0IX0iu3E)
	{
		_0023_003Dzo6KAXJQ_003D(_0023_003Dz2ZqR0IX0iu3E);
		_0023_003Dz8JPeLWI_003D();
	}

	protected void _0023_003Dzo6KAXJQ_003D(uint _0023_003Dz_0024D8vcl0_003D)
	{
		uint[] array = _0023_003DzOurSKYw_003D;
		uint[] array2 = _0023_003DzOurSKYw_003D;
		int i = 1;
		array[0] = _0023_003Dz_0024D8vcl0_003D & 0xFFFFFFFFu;
		for (; i < 624; i++)
		{
			array[i] = Convert.ToUInt32(1812433253 * (array2[i - 1] ^ (array2[i - 1] >> 30)) + i) & 0xFFFFFFFFu;
		}
		_0023_003DzOurSKYw_003D = array;
	}

	protected void _0023_003Dz8JPeLWI_003D()
	{
		int num = -227;
		uint[] array = _0023_003DzOurSKYw_003D;
		int num2 = 0;
		int num3 = 227;
		while (num3 > 0)
		{
			array[num2] = _0023_003DzM7sYd_0024tsPTwq(array[397 + num2], array[num2], array[num2 + 1]);
			num3--;
			num2++;
		}
		num3 = 396;
		while (num3 > 0)
		{
			array[num2] = _0023_003DzM7sYd_0024tsPTwq(array[num2 + num], array[num2], array[num2 + 1]);
			num3--;
			num2++;
		}
		array[num2] = _0023_003DzM7sYd_0024tsPTwq(array[num2 + num], array[num2], _0023_003DzOurSKYw_003D[0]);
		_0023_003DzeMBeuAQ_003D = 624;
		_0023_003Dzj6HvpTk_003D = 0u;
	}

	protected uint _0023_003DzPBhs3pea4AnJ(uint _0023_003Dz_eY3Y4c_003D)
	{
		return _0023_003Dz_eY3Y4c_003D & 0x80000000u;
	}

	protected uint _0023_003DzducmlGESn6yB(uint _0023_003Dz_eY3Y4c_003D)
	{
		return _0023_003Dz_eY3Y4c_003D & 1;
	}

	protected uint _0023_003Dz67_G2uz_AhVj(uint _0023_003Dz_eY3Y4c_003D)
	{
		return _0023_003Dz_eY3Y4c_003D & 0x7FFFFFFF;
	}

	protected uint _0023_003DzpucyTUKoEVmU(uint _0023_003Dz_eY3Y4c_003D, uint _0023_003Dz77g161c_003D)
	{
		return _0023_003DzPBhs3pea4AnJ(_0023_003Dz_eY3Y4c_003D) | _0023_003Dz67_G2uz_AhVj(_0023_003Dz77g161c_003D);
	}

	protected uint _0023_003Dz32cspWE_003D(uint _0023_003Dz_eY3Y4c_003D)
	{
		if (_0023_003DzducmlGESn6yB(_0023_003Dz_eY3Y4c_003D) == 0)
		{
			return 0u;
		}
		return 2567483615u;
	}

	protected uint _0023_003DzM7sYd_0024tsPTwq(uint _0023_003DzkKfJheA_003D, uint _0023_003DzHnO_9qw_003D, uint _0023_003DzgPsOl1A_003D)
	{
		return _0023_003DzkKfJheA_003D ^ (_0023_003DzpucyTUKoEVmU(_0023_003DzHnO_9qw_003D, _0023_003DzgPsOl1A_003D) >> 1) ^ _0023_003Dz32cspWE_003D(_0023_003DzgPsOl1A_003D);
	}
}
