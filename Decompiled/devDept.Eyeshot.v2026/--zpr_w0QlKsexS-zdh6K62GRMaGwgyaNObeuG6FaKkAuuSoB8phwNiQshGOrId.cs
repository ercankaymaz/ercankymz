using System;

internal sealed class _0023_003Dzpr_w0QlKsexS_0024zdh6K62GRMaGwgyaNObeuG6FaKkAuuSoB8phwNiQshGOrId
{
	private double[] _0023_003DzlcDZXjuTFP3voWfKuw_003D_003D;

	private double[] _0023_003DzTHVSGQsR306JEwJj_0024w_003D_003D;

	private double[] _0023_003DzjzYTBOYoO3gL;

	private double[] _0023_003DzaKxjTZdAJyLQ;

	public _0023_003Dzpr_w0QlKsexS_0024zdh6K62GRMaGwgyaNObeuG6FaKkAuuSoB8phwNiQshGOrId()
	{
		int num = 256;
		_0023_003DzlcDZXjuTFP3voWfKuw_003D_003D = new double[num + 1];
		_0023_003DzTHVSGQsR306JEwJj_0024w_003D_003D = new double[num + 1];
		_0023_003DzjzYTBOYoO3gL = new double[num + 1];
		_0023_003DzaKxjTZdAJyLQ = new double[num + 1];
		double num2 = 0.615479709;
		for (int i = 0; i <= num; i++)
		{
			double num3 = Math.Asin(Math.Tan(num2 * (double)(num - i) / (double)num));
			double num4 = num2 * (double)(i / num);
			_0023_003DzlcDZXjuTFP3voWfKuw_003D_003D[i] = Math.Cos(num3);
			_0023_003DzTHVSGQsR306JEwJj_0024w_003D_003D[i] = Math.Sin(num3);
			_0023_003DzjzYTBOYoO3gL[i] = Math.Cos(num4);
			_0023_003DzaKxjTZdAJyLQ[i] = Math.Sin(num4);
		}
	}

	public virtual _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT00 _0023_003DzImB_002423SZpolPix34Yw_003D_003D(long _0023_003DzpjSkdJn4nx2K, long _0023_003DzWkUPZLg_003D, long _0023_003DzhrsBtr04uLWE)
	{
		long num = 8 - _0023_003DzhrsBtr04uLWE;
		long num2 = ((int)_0023_003DzpjSkdJn4nx2K << (int)num) & 0xFFFFFFFFu;
		long num3 = ((int)_0023_003DzWkUPZLg_003D << (int)num) & 0xFFFFFFFFu;
		return new _0023_003Dziaksd7045OR6Vo_xuPm6u21eG_0024LIf_0024Mjmu2NzrFhLqbkYe5i_Tb_PvHMVT00(_0023_003DzlcDZXjuTFP3voWfKuw_003D_003D[(int)num2], _0023_003DzTHVSGQsR306JEwJj_0024w_003D_003D[(int)num2], _0023_003DzjzYTBOYoO3gL[(int)num3], _0023_003DzaKxjTZdAJyLQ[(int)num3]);
	}
}
