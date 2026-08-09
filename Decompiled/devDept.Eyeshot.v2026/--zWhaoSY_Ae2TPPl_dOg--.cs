using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using devDept.Geometry;

internal sealed class _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Match, string> _0023_003DzUdr4O3AsaCYJAKzjhQ_003D_003D;

		internal string _0023_003DzhRQR1fNzGxAfX8C9FlzlcE0_003D(Match _0023_003Dz4LflhCk_003D)
		{
			return _0023_003Dz4LflhCk_003D.Value;
		}
	}

	private Point3D[] _0023_003DzzoB9KyE_003D;

	internal _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public Point3D[] _0023_003DzYNux6PWoz6TL()
	{
		return _0023_003DzzoB9KyE_003D;
	}

	public void _0023_003Dz5RQq8yC7ya4H(Point3D[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzzoB9KyE_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		if (!_0023_003DzpXqcGaz7sKJt)
		{
			_0023_003Dz5RQq8yC7ya4H(_0023_003DzY15vWMs_003D());
			_0023_003DzpXqcGaz7sKJt = true;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
		}
	}

	public Point3D[] _0023_003DzY15vWMs_003D()
	{
		Point3D[] array = new Point3D[int.Parse(_0023_003DzklfmT0QmYoqW(ref _0023_003DziHtkvmE_003D), CultureInfo.InvariantCulture)];
		string[] array2 = _0023_003DzpMnrDprxQnds(_0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D));
		int num = 0;
		string[] array3 = array2;
		for (int i = 0; i < array3.Length; i++)
		{
			string[] array4 = _0023_003DzQywL4rn4wxIe(array3[i]);
			array[num++] = new Point3D(double.Parse(array4[0], CultureInfo.InvariantCulture), double.Parse(array4[1], CultureInfo.InvariantCulture), double.Parse(array4[2], CultureInfo.InvariantCulture));
		}
		return array;
	}

	public static string _0023_003DzklfmT0QmYoqW(ref string _0023_003DziHtkvmE_003D)
	{
		int num = _0023_003DziHtkvmE_003D.IndexOf(',');
		if (num < 0)
		{
			string result = _0023_003DziHtkvmE_003D.Trim();
			_0023_003DziHtkvmE_003D = string.Empty;
			return result;
		}
		string result2 = _0023_003DziHtkvmE_003D.Substring(0, num).Trim();
		_0023_003DziHtkvmE_003D = _0023_003DziHtkvmE_003D.Substring(num + 1);
		return result2;
	}

	public static string _0023_003Dz7VkGdaDHMh8A(ref string _0023_003DziHtkvmE_003D)
	{
		int num = 1;
		int num2 = _0023_003DziHtkvmE_003D.IndexOf('(');
		if (num2 == -1)
		{
			return string.Empty;
		}
		int i;
		for (i = num2 + 1; i < _0023_003DziHtkvmE_003D.Length; i++)
		{
			if (num == 0)
			{
				break;
			}
			if (_0023_003DziHtkvmE_003D[i] == '(')
			{
				num++;
			}
			else if (_0023_003DziHtkvmE_003D[i] == ')')
			{
				num--;
			}
		}
		i--;
		string result = _0023_003DziHtkvmE_003D.Substring(num2 + 1, i - num2 - 1).Trim();
		int num3 = _0023_003DziHtkvmE_003D.IndexOf(',', i);
		if (num3 != -1 && num3 > i && num3 + 1 < _0023_003DziHtkvmE_003D.Length)
		{
			_0023_003DziHtkvmE_003D = _0023_003DziHtkvmE_003D.Substring(num3 + 1);
		}
		return result;
	}

	public static string[] _0023_003DzpMnrDprxQnds(string _0023_003DzcDEsV8s_003D)
	{
		return Regex.Matches(_0023_003DzcDEsV8s_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926729)).OfType<Match>().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzhRQR1fNzGxAfX8C9FlzlcE0_003D)
			.ToArray();
	}

	public static string[] _0023_003DzQywL4rn4wxIe(string _0023_003DzDVfrOi0_003D)
	{
		return _0023_003DzDVfrOi0_003D.Split(',');
	}
}
