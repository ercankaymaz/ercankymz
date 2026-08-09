using System;

internal sealed class _0023_003Dz5xDgxNPUlReYxr2vla3r2p0_003D
{
	public int _0023_003Dzz8DDgng_003D(int _0023_003DzrU0LFPqRU8m5, string _0023_003Dz8ICVv00_003D, string _0023_003DzplPw37tSWsyA, int _0023_003DzpGjKR04_003D, int _0023_003DzGFg1QS4_003D, int _0023_003Dz3viujxQ_003D, int _0023_003Dz139ASF_0024iP127)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (_0023_003DzrU0LFPqRU8m5 == 15 || _0023_003DzrU0LFPqRU8m5 == 13 || _0023_003DzrU0LFPqRU8m5 == 16)
		{
			num2 = _0023_003Dz3viujxQ_003D - _0023_003DzGFg1QS4_003D + 1;
			num3 = 2;
			if (num2 >= 30)
			{
				num3 = 4;
			}
			if (num2 >= 60)
			{
				num3 = 10;
			}
			if (num2 >= 150)
			{
				num3 = (int)Math.Max(10.0, (double)num2 / Math.Round(Math.Log(Convert.ToSingle(num2)) / Math.Log(2.0)));
			}
			if (num2 >= 590)
			{
				num3 = 64;
			}
			if (num2 >= 3000)
			{
				num3 = 128;
			}
			if (num2 >= 6000)
			{
				num3 = 256;
			}
			num3 = Math.Max(2, num3 - _0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003Dz4vcHOP8_003D(num3, 2));
		}
		switch (_0023_003DzrU0LFPqRU8m5)
		{
		case 12:
			num = 75;
			break;
		case 14:
			num = 14;
			break;
		case 15:
			num = num3;
			break;
		case 13:
			num = ((num2 > 500) ? (3 * num3 / 2) : num3);
			break;
		case 16:
			num = 0;
			if (num3 >= 14)
			{
				num = 1;
			}
			if (num3 >= 14)
			{
				num = 2;
			}
			break;
		default:
			num = -1;
			break;
		}
		return num;
	}
}
