using System;

internal sealed class _0023_003DzF3moo4OTZQr_fhl5WFe9Jb0_003D
{
	public double _0023_003Dzz8DDgng_003D(double _0023_003Dzyk2fsPo_003D, double _0023_003DzvXOLtKg_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double val = Math.Abs(_0023_003Dzyk2fsPo_003D);
		num3 = Math.Abs(_0023_003DzvXOLtKg_003D);
		num2 = Math.Max(val, num3);
		num4 = Math.Min(val, num3);
		if (num4 == 0.0)
		{
			return num2;
		}
		return num2 * Math.Sqrt(1.0 + Math.Pow(num4 / num2, 2.0));
	}
}
