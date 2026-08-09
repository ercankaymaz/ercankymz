using devDept.Geometry;

internal sealed class _0023_003Dz4JWJhUdiiYBW1cgvj6FgpaoCdsQrQA2wFiZdc9fgXP3Zlm2uskACXaNFJ6v8
{
	private long _0023_003DzxudyJ5EQxHRY;

	private static _0023_003Dzpr_w0QlKsexS_0024zdh6K62GRMaGwgyaNObeuG6FaKkAuuSoB8phwNiQshGOrId _0023_003Dzge9dEqSmlicPCgMAbwJaDns_003D;

	public _0023_003Dz4JWJhUdiiYBW1cgvj6FgpaoCdsQrQA2wFiZdc9fgXP3Zlm2uskACXaNFJ6v8(long _0023_003DzhrsBtr04uLWE)
	{
		if (_0023_003Dzge9dEqSmlicPCgMAbwJaDns_003D == null)
		{
			_0023_003Dzge9dEqSmlicPCgMAbwJaDns_003D = new _0023_003Dzpr_w0QlKsexS_0024zdh6K62GRMaGwgyaNObeuG6FaKkAuuSoB8phwNiQshGOrId();
		}
		_0023_003DzxudyJ5EQxHRY = _0023_003DzhrsBtr04uLWE;
	}

	public virtual Point3D _0023_003DzUnuxPJoBVNcf(long _0023_003Dzwjf_0024BwjLSEKT, long _0023_003DzbUgHk7sxFxKe, long _0023_003DzpjSkdJn4nx2K, long _0023_003DzWkUPZLg_003D)
	{
		_0023_003DzpjSkdJn4nx2K += _0023_003Dzwjf_0024BwjLSEKT & 1;
		_0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT00 _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT1 = _0023_003Dzge9dEqSmlicPCgMAbwJaDns_003D._0023_003DzImB_002423SZpolPix34Yw_003D_003D(_0023_003DzpjSkdJn4nx2K, _0023_003DzWkUPZLg_003D, _0023_003DzxudyJ5EQxHRY);
		double num2;
		double num = (num2 = _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT1._0023_003DzBxiZG9jrM_GW52cveA_003D_003D() * _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT1._0023_003DzE_a6zn9erwpfTF73Vw_003D_003D());
		double num4;
		double num3 = (num4 = _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT1._0023_003DzKqKI_ajNMujGFAaV5w_003D_003D());
		double num6;
		double num5 = (num6 = _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT1._0023_003Dz6lVD8wp_00248L3fqtAzcQ_003D_003D() * _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT1._0023_003DzE_a6zn9erwpfTF73Vw_003D_003D());
		switch ((int)_0023_003Dzwjf_0024BwjLSEKT)
		{
		case 1:
			num6 = num;
			num2 = num5;
			break;
		case 2:
			num6 = num;
			num2 = num3;
			num4 = num5;
			break;
		case 3:
			num4 = num;
			num2 = num3;
			break;
		case 4:
			num4 = num;
			num6 = num3;
			num2 = num5;
			break;
		case 5:
			num6 = num3;
			num4 = num5;
			break;
		}
		if ((_0023_003DzbUgHk7sxFxKe & 4) == 0L)
		{
			num2 = 0.0 - num2;
		}
		if ((_0023_003DzbUgHk7sxFxKe & 2) == 0L)
		{
			num4 = 0.0 - num4;
		}
		if ((_0023_003DzbUgHk7sxFxKe & 1) == 0L)
		{
			num6 = 0.0 - num6;
		}
		return new Point3D(num2, num4, num6);
	}
}
