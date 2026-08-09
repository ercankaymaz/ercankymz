using System;

internal sealed class _0023_003DzGZvqXkTftxbHBfKYOdC1yFavTDiq : _0023_003DzmjMRzsbwPsPuWB2CorgBfVc_003D
{
	public _0023_003DzGZvqXkTftxbHBfKYOdC1yFavTDiq()
	{
	}

	public _0023_003DzGZvqXkTftxbHBfKYOdC1yFavTDiq(double _0023_003DzGCRALDaSBdu6, double _0023_003DzT2rcMwdKyFst, double _0023_003Dz6pajdGM_003D)
	{
		_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D = new _0023_003DzJA0CTAQQStwjoW3h5BJ2j2I_003D(_0023_003DzGCRALDaSBdu6, 1.0);
		_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D2 = new _0023_003Dz4boGaYB3EvPdMPKMl0SZetA_003D(_0023_003DzT2rcMwdKyFst, _0023_003Dz6pajdGM_003D);
		_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D3 = new _0023_003DzIllBES2_0024wdU5qrD4Q_0024wUWMk_003D(_0023_003DzT2rcMwdKyFst, 20.0);
		double num = _0023_003DzGCRALDaSBdu6 / 2.0;
		double num2 = _0023_003DzT2rcMwdKyFst / 2.0;
		double num3 = num * Math.Cos(_0023_003Dz6pajdGM_003D);
		double num4 = num - Math.Sqrt(num * num - num3 * num3);
		double num5 = 0.0 - (num3 / Math.Tan(_0023_003Dz6pajdGM_003D) - num4);
		double num6 = num2 / Math.Tan(_0023_003Dz6pajdGM_003D) + num5;
		double _0023_003DzqbBqndMXPkub = num6;
		_0023_003DzWWRVX5jMsRRX(_0023_003Dzt_m8zV0_003D, num3, num4, 0.0);
		_0023_003DzWWRVX5jMsRRX(_0023_003Dzt_m8zV0_003D2, _0023_003DzT2rcMwdKyFst / 2.0, num6, num5);
		_0023_003DzWWRVX5jMsRRX(_0023_003Dzt_m8zV0_003D3, _0023_003DzT2rcMwdKyFst / 2.0, num6 + 20.0, _0023_003DzqbBqndMXPkub);
		_0023_003Dz736ekIs_003D = 30.0;
	}
}
