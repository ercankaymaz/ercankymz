using System;

internal sealed class _0023_003Dzmcyp2sPw3mmALYwv_0024rCHPqCw5QnE : _0023_003DzmjMRzsbwPsPuWB2CorgBfVc_003D
{
	public _0023_003Dzmcyp2sPw3mmALYwv_0024rCHPqCw5QnE()
	{
	}

	public _0023_003Dzmcyp2sPw3mmALYwv_0024rCHPqCw5QnE(double _0023_003DzGCRALDaSBdu6, double _0023_003DzerTCYakiui4_0024, double _0023_003DzT2rcMwdKyFst, double _0023_003Dz6pajdGM_003D)
	{
		_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D = new _0023_003Dz0t5Y4F98h5VKXTV0f5KBl_0024o_003D(_0023_003DzGCRALDaSBdu6, _0023_003DzerTCYakiui4_0024, 1.0);
		_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D2 = new _0023_003Dz4boGaYB3EvPdMPKMl0SZetA_003D(_0023_003DzT2rcMwdKyFst, _0023_003Dz6pajdGM_003D);
		_0023_003Dzjcj2XsoMWHv_UUmRAiHH5HOLQ3w7 _0023_003Dzt_m8zV0_003D3 = new _0023_003DzIllBES2_0024wdU5qrD4Q_0024wUWMk_003D(_0023_003DzT2rcMwdKyFst, 20.0);
		double num = _0023_003DzerTCYakiui4_0024 * Math.Sin(_0023_003Dz6pajdGM_003D);
		double num2 = Math.Sqrt(_0023_003DzerTCYakiui4_0024 * _0023_003DzerTCYakiui4_0024 - num * num);
		double num3 = _0023_003DzGCRALDaSBdu6 / 2.0 - _0023_003DzerTCYakiui4_0024 + num2;
		double num4 = 0.0 - (num3 / Math.Tan(_0023_003Dz6pajdGM_003D) - (_0023_003DzerTCYakiui4_0024 - num));
		double _0023_003DzfJFRO2o_003D = _0023_003DzerTCYakiui4_0024 - num;
		double num5 = _0023_003DzT2rcMwdKyFst / 2.0 / Math.Tan(_0023_003Dz6pajdGM_003D) + num4;
		double _0023_003DzqbBqndMXPkub = num5;
		_0023_003DzWWRVX5jMsRRX(_0023_003Dzt_m8zV0_003D, num3, _0023_003DzfJFRO2o_003D, 0.0);
		_0023_003DzWWRVX5jMsRRX(_0023_003Dzt_m8zV0_003D2, _0023_003DzT2rcMwdKyFst / 2.0, num5, num4);
		_0023_003DzWWRVX5jMsRRX(_0023_003Dzt_m8zV0_003D3, _0023_003DzT2rcMwdKyFst / 2.0, num5 + 20.0, _0023_003DzqbBqndMXPkub);
		_0023_003Dz736ekIs_003D = 30.0;
	}
}
