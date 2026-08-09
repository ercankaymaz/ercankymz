using System;

internal sealed class _0023_003DquMh_RbFIfA6Odscsrwq4H4t9WpiGpsywUz8UYTg9PQw_003D : _0023_003Dqvi_sCcIBS5ZQ2maHsWbnIPT2fUD2t99YlrSvhgf_0024tP8_003D
{
	private readonly _0023_003Dqvi_sCcIBS5ZQ2maHsWbnIPT2fUD2t99YlrSvhgf_0024tP8_003D _0023_003DziDLVpbY_003D;

	private readonly byte[] _0023_003Dz5rQzobg_003D;

	public _0023_003DquMh_RbFIfA6Odscsrwq4H4t9WpiGpsywUz8UYTg9PQw_003D(_0023_003Dqvi_sCcIBS5ZQ2maHsWbnIPT2fUD2t99YlrSvhgf_0024tP8_003D _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D)
		: this(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, 0, _0023_003Dz5rQzobg_003D.Length)
	{
	}

	public _0023_003DquMh_RbFIfA6Odscsrwq4H4t9WpiGpsywUz8UYTg9PQw_003D(_0023_003Dqvi_sCcIBS5ZQ2maHsWbnIPT2fUD2t99YlrSvhgf_0024tP8_003D _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, int _0023_003DzR58imxw_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907827));
		}
		if (_0023_003Dz5rQzobg_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910761));
		}
		this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		this._0023_003Dz5rQzobg_003D = new byte[_0023_003DzR58imxw_003D];
		Array.Copy(_0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, this._0023_003Dz5rQzobg_003D, 0, _0023_003DzR58imxw_003D);
	}

	public byte[] _0023_003DzzkJgoXnU3jigR9FfEGBY2crtIGNx()
	{
		return (byte[])_0023_003Dz5rQzobg_003D.Clone();
	}

	public _0023_003Dqvi_sCcIBS5ZQ2maHsWbnIPT2fUD2t99YlrSvhgf_0024tP8_003D _0023_003Dz_1IXjya1kcoZaSRLw66DpxZFdEIA()
	{
		return _0023_003DziDLVpbY_003D;
	}
}
