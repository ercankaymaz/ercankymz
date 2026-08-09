using System;

internal sealed class _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D
{
	public bool _0023_003Dzz8DDgng_003D(string _0023_003DzNL35Xns_003D, string _0023_003DzXIQcPpk_003D)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		_0023_003DzNL35Xns_003D = _0023_003DzNL35Xns_003D.Substring(0, 1);
		_0023_003DzXIQcPpk_003D = _0023_003DzXIQcPpk_003D.Substring(0, 1);
		flag = _0023_003DzNL35Xns_003D == _0023_003DzXIQcPpk_003D;
		if (flag)
		{
			return flag;
		}
		num3 = Convert.ToInt32('Z');
		num = Convert.ToInt32(Convert.ToChar(_0023_003DzNL35Xns_003D));
		num2 = Convert.ToInt32(Convert.ToChar(_0023_003DzXIQcPpk_003D));
		switch (num3)
		{
		case 90:
		case 122:
			if (num >= 97 && num <= 122)
			{
				num -= 32;
			}
			if (num2 >= 97 && num2 <= 122)
			{
				num2 -= 32;
			}
			break;
		case 169:
		case 233:
			if ((num >= 129 && num <= 137) || (num >= 145 && num <= 153) || (num >= 162 && num <= 169))
			{
				num += 64;
			}
			if ((num2 >= 129 && num2 <= 137) || (num2 >= 145 && num2 <= 153) || (num2 >= 162 && num2 <= 169))
			{
				num2 += 64;
			}
			break;
		case 218:
		case 250:
			if (num >= 225 && num <= 250)
			{
				num -= 32;
			}
			if (num2 >= 225 && num2 <= 250)
			{
				num2 -= 32;
			}
			break;
		}
		return num == num2;
	}
}
