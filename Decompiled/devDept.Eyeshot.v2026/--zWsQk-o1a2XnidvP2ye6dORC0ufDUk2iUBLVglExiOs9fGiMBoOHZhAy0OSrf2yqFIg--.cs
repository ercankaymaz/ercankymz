using System;

internal sealed class _0023_003DzWsQk_0024o1a2XnidvP2ye6dORC0ufDUk2iUBLVglExiOs9fGiMBoOHZhAy0OSrf2yqFIg_003D_003D
{
	public static void _0023_003DzPFoRtzBj_00248aX(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzXrexKjY_003D, double _0023_003DzpJT4iI0_Zryp, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, ref double _0023_003Dz_eY3Y4c_003D, ref double _0023_003Dz77g161c_003D, uint _0023_003Dz1EqrzvY5sanPAYe84A_003D_003D)
	{
		_0023_003Dz_eY3Y4c_003D = (_0023_003DzXrexKjY_003D * _0023_003DzBJFJHwk_003D - _0023_003Dzt_m8zV0_003D * _0023_003Dz40R7bAU_003D) * _0023_003DzpJT4iI0_Zryp;
		_0023_003Dz77g161c_003D = (_0023_003DzjbqS1qE_003D * _0023_003Dz40R7bAU_003D - _0023_003Dz1v6oPQk_003D * _0023_003DzBJFJHwk_003D) * _0023_003DzpJT4iI0_Zryp;
		while (_0023_003Dz1EqrzvY5sanPAYe84A_003D_003D-- != 0)
		{
			double num = _0023_003DzBJFJHwk_003D - (_0023_003DzjbqS1qE_003D * _0023_003Dz_eY3Y4c_003D + _0023_003Dzt_m8zV0_003D * _0023_003Dz77g161c_003D);
			double num2 = _0023_003Dz40R7bAU_003D - (_0023_003Dz1v6oPQk_003D * _0023_003Dz_eY3Y4c_003D + _0023_003DzXrexKjY_003D * _0023_003Dz77g161c_003D);
			double num3 = (_0023_003DzXrexKjY_003D * num - _0023_003Dzt_m8zV0_003D * num2) * _0023_003DzpJT4iI0_Zryp;
			double num4 = (_0023_003DzjbqS1qE_003D * num2 - _0023_003Dz1v6oPQk_003D * num) * _0023_003DzpJT4iI0_Zryp;
			_0023_003Dz_eY3Y4c_003D += num3;
			_0023_003Dz77g161c_003D += num4;
			if (Math.Abs(num3) <= 1E-12 * Math.Abs(_0023_003Dz_eY3Y4c_003D) && Math.Abs(num4) <= 1E-12 * Math.Abs(_0023_003Dz77g161c_003D))
			{
				break;
			}
		}
	}

	public static double _0023_003DzPFoRtzBj_00248aX(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzXrexKjY_003D, double _0023_003DzbfrNXYE_003D, double _0023_003DzhidJeNw_003D, double _0023_003Dz5rQzobg_003D, double _0023_003DzfJFRO2o_003D, double _0023_003Dz437_00244ak_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, ref double _0023_003Dz_eY3Y4c_003D, ref double _0023_003Dz77g161c_003D, ref double _0023_003DzAvn2b38_003D, uint _0023_003Dz1EqrzvY5sanPAYe84A_003D_003D)
	{
		double num = _0023_003DzbfrNXYE_003D * _0023_003Dz437_00244ak_003D - _0023_003DzhidJeNw_003D * _0023_003DzfJFRO2o_003D;
		double num2 = _0023_003Dzt_m8zV0_003D * _0023_003DzfJFRO2o_003D - _0023_003Dz1v6oPQk_003D * _0023_003Dz437_00244ak_003D;
		double num3 = _0023_003Dz1v6oPQk_003D * _0023_003DzhidJeNw_003D - _0023_003Dzt_m8zV0_003D * _0023_003DzbfrNXYE_003D;
		double num4 = _0023_003DzhidJeNw_003D * _0023_003Dz5rQzobg_003D - _0023_003DzXrexKjY_003D * _0023_003Dz437_00244ak_003D;
		double num5 = _0023_003DzjbqS1qE_003D * _0023_003Dz437_00244ak_003D - _0023_003Dzt_m8zV0_003D * _0023_003Dz5rQzobg_003D;
		double num6 = _0023_003Dzt_m8zV0_003D * _0023_003DzXrexKjY_003D - _0023_003DzjbqS1qE_003D * _0023_003DzhidJeNw_003D;
		double num7 = _0023_003DzXrexKjY_003D * _0023_003DzfJFRO2o_003D - _0023_003DzbfrNXYE_003D * _0023_003Dz5rQzobg_003D;
		double num8 = _0023_003Dz1v6oPQk_003D * _0023_003Dz5rQzobg_003D - _0023_003DzjbqS1qE_003D * _0023_003DzfJFRO2o_003D;
		double num9 = _0023_003DzjbqS1qE_003D * _0023_003DzbfrNXYE_003D - _0023_003Dz1v6oPQk_003D * _0023_003DzXrexKjY_003D;
		double num10 = 0.0;
		double num11 = _0023_003DzjbqS1qE_003D * num + _0023_003DzXrexKjY_003D * num2 + _0023_003Dz5rQzobg_003D * num3;
		num11 += _0023_003Dz1v6oPQk_003D * num4 + _0023_003DzbfrNXYE_003D * num5 + _0023_003DzfJFRO2o_003D * num6;
		num11 += _0023_003Dzt_m8zV0_003D * num7 + _0023_003DzhidJeNw_003D * num8 + _0023_003Dz437_00244ak_003D * num9;
		num11 *= 1.0 / 3.0;
		if (num11 != 0.0)
		{
			num10 = 1.0 / num11;
		}
		_0023_003Dz_eY3Y4c_003D = (num * _0023_003DzBJFJHwk_003D + num4 * _0023_003Dz40R7bAU_003D + num7 * _0023_003DzId5C3LA_003D) * num10;
		_0023_003Dz77g161c_003D = (num2 * _0023_003DzBJFJHwk_003D + num5 * _0023_003Dz40R7bAU_003D + num8 * _0023_003DzId5C3LA_003D) * num10;
		_0023_003DzAvn2b38_003D = (num3 * _0023_003DzBJFJHwk_003D + num6 * _0023_003Dz40R7bAU_003D + num9 * _0023_003DzId5C3LA_003D) * num10;
		while (_0023_003Dz1EqrzvY5sanPAYe84A_003D_003D-- != 0)
		{
			double num12 = _0023_003DzBJFJHwk_003D - (_0023_003DzjbqS1qE_003D * _0023_003Dz_eY3Y4c_003D + _0023_003DzXrexKjY_003D * _0023_003Dz77g161c_003D + _0023_003Dz5rQzobg_003D * _0023_003DzAvn2b38_003D);
			double num13 = _0023_003Dz40R7bAU_003D - (_0023_003Dz1v6oPQk_003D * _0023_003Dz_eY3Y4c_003D + _0023_003DzbfrNXYE_003D * _0023_003Dz77g161c_003D + _0023_003DzfJFRO2o_003D * _0023_003DzAvn2b38_003D);
			double num14 = _0023_003DzId5C3LA_003D - (_0023_003Dzt_m8zV0_003D * _0023_003Dz_eY3Y4c_003D + _0023_003DzhidJeNw_003D * _0023_003Dz77g161c_003D + _0023_003Dz437_00244ak_003D * _0023_003DzAvn2b38_003D);
			double num15 = (num * num12 + num4 * num13 + num7 * num14) * num10;
			double num16 = (num2 * num12 + num5 * num13 + num8 * num14) * num10;
			double num17 = (num3 * num12 + num6 * num13 + num9 * num14) * num10;
			_0023_003Dz_eY3Y4c_003D += num15;
			_0023_003Dz77g161c_003D += num16;
			_0023_003DzAvn2b38_003D += num17;
			if (Math.Abs(num15) <= 1E-12 * Math.Abs(_0023_003Dz_eY3Y4c_003D) && Math.Abs(num16) <= 1E-12 * Math.Abs(_0023_003Dz77g161c_003D) && Math.Abs(num17) <= 1E-12 * Math.Abs(_0023_003DzAvn2b38_003D))
			{
				break;
			}
		}
		return num11;
	}

	public static double _0023_003DzomsydD53dfyH(_0023_003DzN3jMdHq6L7CCpD_PKdtVivJXLHOclz_0024KBQ_003D_003D _0023_003DzE8QrneA_003D, double[] _0023_003DziP9fFuA_003D, uint _0023_003Dz1EqrzvY5sanPAYe84A_003D_003D)
	{
		uint num = 0u;
		double _0023_003Dz_eY3Y4c_003D = _0023_003DziP9fFuA_003D[0];
		double _0023_003DzBJFJHwk_003D = _0023_003Dz_eY3Y4c_003D;
		double _0023_003Dz77g161c_003D = _0023_003DziP9fFuA_003D[1];
		double _0023_003Dz40R7bAU_003D = _0023_003Dz77g161c_003D;
		double _0023_003DzAvn2b38_003D = _0023_003DziP9fFuA_003D[2];
		double _0023_003DzId5C3LA_003D = _0023_003DzAvn2b38_003D;
		double _0023_003DzjbqS1qE_003D = _0023_003DzE8QrneA_003D[num];
		double _0023_003Dz1v6oPQk_003D = _0023_003DzE8QrneA_003D[num + 1];
		double _0023_003Dzt_m8zV0_003D = _0023_003DzE8QrneA_003D[num + 2];
		double _0023_003DzXrexKjY_003D = _0023_003DzE8QrneA_003D[num + 3];
		double _0023_003DzbfrNXYE_003D = _0023_003DzE8QrneA_003D[num + 4];
		double _0023_003DzhidJeNw_003D = _0023_003DzE8QrneA_003D[num + 5];
		double _0023_003Dz5rQzobg_003D = _0023_003DzE8QrneA_003D[num + 6];
		double _0023_003DzfJFRO2o_003D = _0023_003DzE8QrneA_003D[num + 7];
		double _0023_003Dz437_00244ak_003D = _0023_003DzE8QrneA_003D[num + 8];
		double result = _0023_003DzPFoRtzBj_00248aX(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzXrexKjY_003D, _0023_003DzbfrNXYE_003D, _0023_003DzhidJeNw_003D, _0023_003Dz5rQzobg_003D, _0023_003DzfJFRO2o_003D, _0023_003Dz437_00244ak_003D, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D, ref _0023_003Dz_eY3Y4c_003D, ref _0023_003Dz77g161c_003D, ref _0023_003DzAvn2b38_003D, _0023_003Dz1EqrzvY5sanPAYe84A_003D_003D);
		_0023_003DziP9fFuA_003D[0] = _0023_003Dz_eY3Y4c_003D;
		_0023_003DziP9fFuA_003D[1] = _0023_003Dz77g161c_003D;
		_0023_003DziP9fFuA_003D[2] = _0023_003DzAvn2b38_003D;
		return result;
	}
}
