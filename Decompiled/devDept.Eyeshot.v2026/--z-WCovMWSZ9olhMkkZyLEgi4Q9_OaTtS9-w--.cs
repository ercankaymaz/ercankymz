using System.Collections.Generic;
using System.Globalization;

internal sealed class _0023_003Dz_0024WCovMWSZ9olhMkkZyLEgi4Q9_OaTtS9_0024w_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private int[] _0023_003DzUaztVa0WOfOVfK1zxcOmGMIpooPXEZS9gw_003D_003D;

	internal _0023_003Dz_0024WCovMWSZ9olhMkkZyLEgi4Q9_OaTtS9_0024w_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public int[] _0023_003DzAfnjxX09FyggFhskMAQe50TkKYbh1C0boQ_003D_003D()
	{
		return _0023_003DzUaztVa0WOfOVfK1zxcOmGMIpooPXEZS9gw_003D_003D;
	}

	public void _0023_003Dz40cj68LQdv_0024SpqeomPibh98TmH583w3raw_003D_003D(int[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzUaztVa0WOfOVfK1zxcOmGMIpooPXEZS9gw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		if (!_0023_003DzpXqcGaz7sKJt)
		{
			_0023_003DzUaztVa0WOfOVfK1zxcOmGMIpooPXEZS9gw_003D_003D = _0023_003DzY15vWMs_003D(_0023_003Dz9UNAzE0_003D);
			_0023_003DzpXqcGaz7sKJt = true;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
		}
	}

	public int[] _0023_003DzY15vWMs_003D(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D)
	{
		string[] array = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D).Split(',');
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			array2[i] = int.Parse(text.Trim('#'), CultureInfo.InvariantCulture);
		}
		return array2;
	}
}
