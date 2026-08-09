using System;

internal sealed class _0023_003Dz66L1Id_0024pDM1gZwyaZu2Ubl4u_dBdQ1KHLg_003D_003D
{
	public static void _0023_003DzPFoRtzBj_00248aX(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzpJT4iI0_Zryp, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, ref double _0023_003Dz_eY3Y4c_003D, ref double _0023_003Dz77g161c_003D, uint _0023_003Dz1EqrzvY5sanPAYe84A_003D_003D)
	{
		_0023_003Dz_eY3Y4c_003D = (_0023_003Dzt_m8zV0_003D * _0023_003DzBJFJHwk_003D - _0023_003Dz1v6oPQk_003D * _0023_003Dz40R7bAU_003D) * _0023_003DzpJT4iI0_Zryp;
		_0023_003Dz77g161c_003D = (_0023_003DzjbqS1qE_003D * _0023_003Dz40R7bAU_003D - _0023_003Dz1v6oPQk_003D * _0023_003DzBJFJHwk_003D) * _0023_003DzpJT4iI0_Zryp;
		while (_0023_003Dz1EqrzvY5sanPAYe84A_003D_003D-- != 0)
		{
			double num = _0023_003DzBJFJHwk_003D - (_0023_003DzjbqS1qE_003D * _0023_003Dz_eY3Y4c_003D + _0023_003Dz1v6oPQk_003D * _0023_003Dz77g161c_003D);
			double num2 = _0023_003Dz40R7bAU_003D - (_0023_003Dz1v6oPQk_003D * _0023_003Dz_eY3Y4c_003D + _0023_003Dzt_m8zV0_003D * _0023_003Dz77g161c_003D);
			double num3 = (_0023_003Dzt_m8zV0_003D * num - _0023_003Dz1v6oPQk_003D * num2) * _0023_003DzpJT4iI0_Zryp;
			double num4 = (_0023_003DzjbqS1qE_003D * num2 - _0023_003Dz1v6oPQk_003D * num) * _0023_003DzpJT4iI0_Zryp;
			_0023_003Dz_eY3Y4c_003D += num3;
			_0023_003Dz77g161c_003D += num4;
			if (Math.Abs(num3) <= 1E-12 * Math.Abs(_0023_003Dz_eY3Y4c_003D) && Math.Abs(num4) <= 1E-12 * Math.Abs(_0023_003Dz77g161c_003D))
			{
				break;
			}
		}
	}
}
