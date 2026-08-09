using System;

internal sealed class _0023_003DqTnc2yZaUcqEcx7uiqB96ztHLdTV124OG9zwPJteCwqI_003D : _0023_003Dqvi_sCcIBS5ZQ2maHsWbnIPT2fUD2t99YlrSvhgf_0024tP8_003D
{
	private readonly byte[] _0023_003DziDLVpbY_003D;

	public _0023_003DqTnc2yZaUcqEcx7uiqB96ztHLdTV124OG9zwPJteCwqI_003D(byte[] _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909980));
		}
		this._0023_003DziDLVpbY_003D = (byte[])_0023_003DziDLVpbY_003D.Clone();
	}

	public _0023_003DqTnc2yZaUcqEcx7uiqB96ztHLdTV124OG9zwPJteCwqI_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909957));
		}
		if (_0023_003Dz5rQzobg_003D < 0 || _0023_003Dz5rQzobg_003D > _0023_003DziDLVpbY_003D.Length)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910194));
		}
		if (_0023_003DzAvn2b38_003D < 0 || _0023_003Dz5rQzobg_003D + _0023_003DzAvn2b38_003D > _0023_003DziDLVpbY_003D.Length)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910203));
		}
		this._0023_003DziDLVpbY_003D = new byte[_0023_003DzAvn2b38_003D];
		Array.Copy(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, this._0023_003DziDLVpbY_003D, 0, _0023_003DzAvn2b38_003D);
	}

	public byte[] _0023_003Dzg3bMKvLXFekHD2uXgNBKxe_NyI6a()
	{
		return (byte[])_0023_003DziDLVpbY_003D.Clone();
	}
}
