using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

internal sealed class _0023_003DqEcE_dnDzdNcmr1ilrWUcQ35iPZIdo42JfXemhiP9Cdw_003D : _0023_003DqX0L7PWJ_0024pi7E1lZI88eAO5sAobDJ0hDC4y368rHz_0024nU_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqG2j0vYyDwMuB3UfmWnsmaZPncCP2WP_0024zx9YLL4cnscs_003D _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzR58imxw_003D;

	public _0023_003DqEcE_dnDzdNcmr1ilrWUcQ35iPZIdo42JfXemhiP9Cdw_003D(_0023_003DqG2j0vYyDwMuB3UfmWnsmaZPncCP2WP_0024zx9YLL4cnscs_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dzv4birLx7y6Rnc3vF49ctZVQRSQPFFGpqrqulNLwvDfDN())
		{
			throw new NotSupportedException();
		}
		this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		_0023_003Dz5rQzobg_003D = new byte[_0023_003DziDLVpbY_003D._0023_003DzcJxPFSkFIEp1XZypJBtY4vG5ohxdNaobWJmZoq6ZkMadWP0_DLYtYqeZaotjUp7DgMiWHac_003D()];
		_0023_003DzAvn2b38_003D = _0023_003DzNWSZEnJIPR94Qf5hHyAHMkXiuK05PhGglA_003D_003D();
		_0023_003DzR58imxw_003D = _0023_003DzCxUa2c2HUjinb0NT2SpA__7oSN5xFqEjBiJnECU_003D();
	}

	private int _0023_003DzNWSZEnJIPR94Qf5hHyAHMkXiuK05PhGglA_003D_003D()
	{
		return _0023_003DziDLVpbY_003D._0023_003Dz0tAR8yUFkU2jUm3AVFRoKtDLjDSmTKVAJNq86eLtMcXspFPCn0S4gvshDBjTY247PBKXdzvFQ6fsojO_0024Ag_003D_003D();
	}

	private int _0023_003DzCxUa2c2HUjinb0NT2SpA__7oSN5xFqEjBiJnECU_003D()
	{
		return _0023_003DziDLVpbY_003D._0023_003DzcJxPFSkFIEp1XZypJBtY4vG5ohxdNaobWJmZoq6ZkMadWP0_DLYtYqeZaotjUp7DgMiWHac_003D() - 10;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0023_003DzcJxPFSkFIEp1XZypJBtY4vG5ohxdNaobWJmZoq6ZkMadWP0_DLYtYqeZaotjUp7DgMiWHac_003D()
	{
		return _0023_003DzR58imxw_003D;
	}

	public int _0023_003DzLwoZv45Pa4_0024jy1VJmhNsdx9TWiqb9GD1vXh6snfFDPWJagI3PaOJZtlcbubGf3aChPH5hztl2z13_hbHC_00243_coA_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D, RandomNumberGenerator _0023_003DzWYPqg2E_003D)
	{
		return _0023_003Dzokv_0024DHo5tho_0USjwfmsRPkvG_m4hGu4taLpobxU8zlt(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D);
	}

	private int _0023_003Dzokv_0024DHo5tho_0USjwfmsRPkvG_m4hGu4taLpobxU8zlt(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D, RandomNumberGenerator _0023_003DzWYPqg2E_003D)
	{
		int num = this._0023_003DziDLVpbY_003D._0023_003DzcJxPFSkFIEp1XZypJBtY4vG5ohxdNaobWJmZoq6ZkMadWP0_DLYtYqeZaotjUp7DgMiWHac_003D();
		byte[] array = this._0023_003Dz5rQzobg_003D;
		this._0023_003DziDLVpbY_003D._0023_003DzLwoZv45Pa4_0024jy1VJmhNsdx9TWiqb9GD1vXh6snfFDPWJagI3PaOJZtlcbubGf3aChPH5hztl2z13_hbHC_00243_coA_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, array, 0, _0023_003DzWYPqg2E_003D);
		byte num2 = array[0];
		bool flag = num2 != 2;
		int num3 = _0023_003DzjQFGrAjEDj60lWBMqqlWwMzVY8je(num2, array, 0, num);
		num3++;
		if (flag || num3 < 10)
		{
			throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909641));
		}
		int num4 = num - num3;
		Buffer.BlockCopy(array, num3, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, num4);
		return num4;
	}

	private static int _0023_003DzjQFGrAjEDj60lWBMqqlWwMzVY8je(byte _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, int _0023_003DzR58imxw_003D)
	{
		for (int i = _0023_003DzAvn2b38_003D + 1; i != _0023_003DzAvn2b38_003D + _0023_003DzR58imxw_003D; i++)
		{
			if (_0023_003Dz5rQzobg_003D[i] == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public void Dispose()
	{
		if (_0023_003DziDLVpbY_003D != null)
		{
			_0023_003DziDLVpbY_003D.Dispose();
			_0023_003DziDLVpbY_003D = null;
		}
	}
}
