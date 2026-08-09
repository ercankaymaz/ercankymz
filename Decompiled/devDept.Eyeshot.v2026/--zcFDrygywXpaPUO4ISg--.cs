using System.Collections.Generic;
using devDept.Geometry;

internal sealed class _0023_003DzcFDrygywXpaPUO4ISg_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	public double[] _0023_003DzqdOG1COev7La;

	internal _0023_003DzcFDrygywXpaPUO4ISg_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzqdOG1COev7La = new double[3];
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	internal _0023_003DzcFDrygywXpaPUO4ISg_003D_003D(double[] _0023_003Dz6u3psoE_003D)
	{
		_0023_003DzqdOG1COev7La = _0023_003Dz6u3psoE_003D;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			_0023_003DziHtkvmE_003D = _0023_003DziHtkvmE_003D.Trim('(', ' ', ')');
			string[] array = _0023_003DziHtkvmE_003D.Split(',');
			double num = Utility.DoubleParse(array[0]);
			double num2 = Utility.DoubleParse(array[1]);
			double num3 = 0.0;
			if (array.Length > 2)
			{
				num3 = Utility.DoubleParse(array[2]);
			}
			_0023_003DzqdOG1COev7La = new double[3] { num, num2, num3 };
			_0023_003DzpXqcGaz7sKJt = true;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2:
			break;
		}
	}
}
