internal sealed class _0023_003DzSMw6iIVfuTYi5lA96zYCum0_003D
{
	private _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzP5EG5JF6QJpl;

	private _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003DzRKxBhzpH2B27;

	private int[] _0023_003Dzs1KS2Vc_003D = new int[64];

	public _0023_003DzSMw6iIVfuTYi5lA96zYCum0_003D(_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzpZ9im0izpG3k, _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003Dzt2EQ2fGeANKe)
	{
		_0023_003DzP5EG5JF6QJpl = _0023_003DzpZ9im0izpG3k;
		_0023_003DzRKxBhzpH2B27 = _0023_003Dzt2EQ2fGeANKe;
	}

	public _0023_003DzSMw6iIVfuTYi5lA96zYCum0_003D()
	{
		_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2 = new _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D();
		_0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D2 = new _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D();
		_0023_003DzP5EG5JF6QJpl = _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2;
		_0023_003DzRKxBhzpH2B27 = _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(string _0023_003DzoiYtBx0_003D, int _0023_003DzpGjKR04_003D, ref double[] _0023_003DzK_0024fbiW0_003D, int _0023_003Dzx0hyf0lftOUh, ref int _0023_003DzhEXKXIU_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		int num12 = -3;
		int num13 = -1 + _0023_003Dzx0hyf0lftOUh;
		_0023_003DzoiYtBx0_003D = _0023_003DzoiYtBx0_003D.Substring(0, 1);
		_0023_003DzhEXKXIU_003D = 0;
		num = -1;
		if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzoiYtBx0_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912811)))
		{
			num = 0;
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzoiYtBx0_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911423)))
		{
			num = 1;
		}
		if (num == -1)
		{
			_0023_003DzhEXKXIU_003D = -1;
		}
		else if (_0023_003DzpGjKR04_003D < 0)
		{
			_0023_003DzhEXKXIU_003D = -2;
		}
		if (_0023_003DzhEXKXIU_003D != 0)
		{
			_0023_003DzRKxBhzpH2B27._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912536), -_0023_003DzhEXKXIU_003D);
		}
		else
		{
			if (_0023_003DzpGjKR04_003D <= 1)
			{
				return;
			}
			num6 = 1;
			_0023_003Dzs1KS2Vc_003D[3 + num12] = 1;
			_0023_003Dzs1KS2Vc_003D[4 + num12] = _0023_003DzpGjKR04_003D;
			do
			{
				num5 = _0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12];
				num2 = _0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12];
				num6--;
				if (num2 - num5 <= 20 && num2 - num5 > 0)
				{
					if (num == 0)
					{
						for (num3 = num5 + 1; num3 <= num2; num3++)
						{
							for (num4 = num3; num4 >= num5 + 1 && _0023_003DzK_0024fbiW0_003D[num4 + num13] > _0023_003DzK_0024fbiW0_003D[num4 - 1 + num13]; num4 += -1)
							{
								num10 = _0023_003DzK_0024fbiW0_003D[num4 + num13];
								_0023_003DzK_0024fbiW0_003D[num4 + num13] = _0023_003DzK_0024fbiW0_003D[num4 - 1 + num13];
								_0023_003DzK_0024fbiW0_003D[num4 - 1 + num13] = num10;
							}
						}
						continue;
					}
					for (num3 = num5 + 1; num3 <= num2; num3++)
					{
						for (num4 = num3; num4 >= num5 + 1 && _0023_003DzK_0024fbiW0_003D[num4 + num13] < _0023_003DzK_0024fbiW0_003D[num4 - 1 + num13]; num4 += -1)
						{
							num10 = _0023_003DzK_0024fbiW0_003D[num4 + num13];
							_0023_003DzK_0024fbiW0_003D[num4 + num13] = _0023_003DzK_0024fbiW0_003D[num4 - 1 + num13];
							_0023_003DzK_0024fbiW0_003D[num4 - 1 + num13] = num10;
						}
					}
				}
				else
				{
					if (num2 - num5 <= 20)
					{
						continue;
					}
					num7 = _0023_003DzK_0024fbiW0_003D[num5 + num13];
					num8 = _0023_003DzK_0024fbiW0_003D[num2 + num13];
					num3 = (num5 + num2) / 2;
					num9 = _0023_003DzK_0024fbiW0_003D[num3 + num13];
					num10 = ((num7 < num8) ? ((num9 < num7) ? num7 : ((!(num9 < num8)) ? num8 : num9)) : ((num9 < num8) ? num8 : ((!(num9 < num7)) ? num7 : num9)));
					if (num == 0)
					{
						num3 = num5 - 1;
						num4 = num2 + 1;
						while (true)
						{
							num4--;
							if (!(_0023_003DzK_0024fbiW0_003D[num4 + num13] < num10))
							{
								do
								{
									num3++;
								}
								while (_0023_003DzK_0024fbiW0_003D[num3 + num13] > num10);
								if (num3 >= num4)
								{
									break;
								}
								num11 = _0023_003DzK_0024fbiW0_003D[num3 + num13];
								_0023_003DzK_0024fbiW0_003D[num3 + num13] = _0023_003DzK_0024fbiW0_003D[num4 + num13];
								_0023_003DzK_0024fbiW0_003D[num4 + num13] = num11;
							}
						}
						if (num4 - num5 > num2 - num4 - 1)
						{
							num6++;
							_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num5;
							_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num4;
							num6++;
							_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num4 + 1;
							_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num2;
						}
						else
						{
							num6++;
							_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num4 + 1;
							_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num2;
							num6++;
							_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num5;
							_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num4;
						}
						continue;
					}
					num3 = num5 - 1;
					num4 = num2 + 1;
					while (true)
					{
						num4--;
						if (!(_0023_003DzK_0024fbiW0_003D[num4 + num13] > num10))
						{
							do
							{
								num3++;
							}
							while (_0023_003DzK_0024fbiW0_003D[num3 + num13] < num10);
							if (num3 >= num4)
							{
								break;
							}
							num11 = _0023_003DzK_0024fbiW0_003D[num3 + num13];
							_0023_003DzK_0024fbiW0_003D[num3 + num13] = _0023_003DzK_0024fbiW0_003D[num4 + num13];
							_0023_003DzK_0024fbiW0_003D[num4 + num13] = num11;
						}
					}
					if (num4 - num5 > num2 - num4 - 1)
					{
						num6++;
						_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num5;
						_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num4;
						num6++;
						_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num4 + 1;
						_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num2;
					}
					else
					{
						num6++;
						_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num4 + 1;
						_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num2;
						num6++;
						_0023_003Dzs1KS2Vc_003D[1 + num6 * 2 + num12] = num5;
						_0023_003Dzs1KS2Vc_003D[2 + num6 * 2 + num12] = num4;
					}
				}
			}
			while (num6 > 0);
		}
	}
}
