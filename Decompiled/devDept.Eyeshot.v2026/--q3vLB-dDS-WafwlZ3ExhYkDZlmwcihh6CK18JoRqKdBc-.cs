using System.Runtime.CompilerServices;

internal sealed class _0023_003Dq3vLB_0024dDS_0024WafwlZ3ExhYkDZlmwcihh6CK18JoRqKdBc_003D : _0023_003DqJTjaQmhkW8F60LVdPhnyD28suQYp1eKJDTElj4I43ME_003D
{
	public void _0023_003DzRAIkE0osYsUnX_00247YozrpIirxucaiN3Ny0Gz7SaQDp_mdx_zer8lOpDqtrJoDTSCAYxO11_9F1D3_0024()
	{
	}

	[SpecialName]
	public string _0023_003DzFRzKNFlLu9vX7F3gxdL1XD6XUC0jbstxJ3z_00245WN7Dg1L86LELwhxF8Uq7fq6LFZ7o4kEwctQp78tJozBPP7s0geU1TPo()
	{
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910184);
	}

	public int _0023_003Dzb1TcsNiD_0024RHpM1n1Uv6pm5g1B6z0Q197cs4cubwPKp4eDbEkJZegqGq7ImOa3h6k1YHiupg_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		byte b = (byte)(_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D);
		while (_0023_003Dz5rQzobg_003D < _0023_003DziDLVpbY_003D.Length)
		{
			_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D] = b;
			_0023_003Dz5rQzobg_003D++;
		}
		return b;
	}

	public int _0023_003DzicebEmxcMfAPXXfUJqUEtIqluwFRB30SvuNd_00246btE4qQk77nnnAG09isYvdBOSSRGKSqS2C3Hp2m(byte[] _0023_003DziDLVpbY_003D)
	{
		int num = _0023_003DziDLVpbY_003D[^1];
		if (num < 1 || num > _0023_003DziDLVpbY_003D.Length)
		{
			throw new _0023_003DqZOgqBgNtgFzdL0x3JA7Lx22HNhefmJcRGlsnCj5h5Y4_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910164));
		}
		for (int i = 1; i <= num; i++)
		{
			if (_0023_003DziDLVpbY_003D[^i] != num)
			{
				throw new _0023_003DqZOgqBgNtgFzdL0x3JA7Lx22HNhefmJcRGlsnCj5h5Y4_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910164));
			}
		}
		return num;
	}
}
