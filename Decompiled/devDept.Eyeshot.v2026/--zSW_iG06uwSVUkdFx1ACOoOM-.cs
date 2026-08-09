internal sealed class _0023_003DzSW_iG06uwSVUkdFx1ACOoOM_003D
{
	private _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D _0023_003Dz7xnyX74MWj2D;

	public _0023_003DzSW_iG06uwSVUkdFx1ACOoOM_003D(_0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D _0023_003Dzm528LhE7YyFj)
	{
		_0023_003Dz7xnyX74MWj2D = _0023_003Dzm528LhE7YyFj;
	}

	public _0023_003DzSW_iG06uwSVUkdFx1ACOoOM_003D()
	{
		_0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D2 = new _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D();
		_0023_003Dz7xnyX74MWj2D = _0023_003DzyVHXjb_0024HNNqhLu4TICUiEIc_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(ref int _0023_003DzuDXXVQ_rsLSa, double _0023_003Dzo398Yq4_003D, int _0023_003Dz_XaFQag_003D)
	{
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		num2 = _0023_003Dzo398Yq4_003D;
		num9 = 1.0 / (double)_0023_003Dz_XaFQag_003D;
		num10 = 0.0;
		_0023_003DzuDXXVQ_rsLSa = 1;
		num3 = _0023_003Dz7xnyX74MWj2D._0023_003Dzz8DDgng_003D(num2 * num9, num10);
		num5 = num2;
		num6 = num2;
		num7 = num2;
		num8 = num2;
		while (num5 == num2 && num6 == num2 && num7 == num2 && num8 == num2)
		{
			_0023_003DzuDXXVQ_rsLSa--;
			num2 = num3;
			num3 = _0023_003Dz7xnyX74MWj2D._0023_003Dzz8DDgng_003D(num2 / (double)_0023_003Dz_XaFQag_003D, num10);
			num5 = _0023_003Dz7xnyX74MWj2D._0023_003Dzz8DDgng_003D(num3 * (double)_0023_003Dz_XaFQag_003D, num10);
			num7 = num10;
			for (num = 1; num <= _0023_003Dz_XaFQag_003D; num++)
			{
				num7 += num3;
			}
			num4 = _0023_003Dz7xnyX74MWj2D._0023_003Dzz8DDgng_003D(num2 * num9, num10);
			num6 = _0023_003Dz7xnyX74MWj2D._0023_003Dzz8DDgng_003D(num4 / num9, num10);
			num8 = num10;
			for (num = 1; num <= _0023_003Dz_XaFQag_003D; num++)
			{
				num8 += num4;
			}
		}
	}
}
