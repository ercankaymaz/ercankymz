using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using devDept.Geometry;

internal class _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<string, int> _0023_003DzUdr4O3AsaCYJAKzjhQ_003D_003D;

		internal int _0023_003DzJy4tSrfcPTb8KYjAhw_003D_003D(string _0023_003Dz_cIPm7NyAAnw6dxr2w_003D_003D)
		{
			return int.Parse(_0023_003Dz_cIPm7NyAAnw6dxr2w_003D_003D, CultureInfo.InvariantCulture);
		}
	}

	private Point3D[] _0023_003DzzoB9KyE_003D;

	private List<IndexTriangle> _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D;

	protected int _0023_003DzDw8fylj6pfwMQgg2Y_0024eh1GL_FWJc;

	internal _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
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

	public List<IndexTriangle> _0023_003DzPvyA_tju2mOECWmhiQ_003D_003D()
	{
		return _0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D;
	}

	public void _0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(List<IndexTriangle> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzcT2oqdtGxzpc_lAdIg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			string s = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzklfmT0QmYoqW(ref _0023_003DziHtkvmE_003D).Trim('#');
			_0023_003DzDw8fylj6pfwMQgg2Y_0024eh1GL_FWJc = int.Parse(s, CultureInfo.InvariantCulture);
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
		{
			(Point3D[], List<IndexTriangle>) tuple = _0023_003DzY15vWMs_003D(_0023_003Dz9UNAzE0_003D);
			_0023_003Dz5RQq8yC7ya4H(tuple.Item1);
			_0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(tuple.Item2);
			_0023_003DzpXqcGaz7sKJt = true;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
			break;
		}
		}
	}

	public virtual (Point3D[], List<IndexTriangle>) _0023_003DzY15vWMs_003D(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D)
	{
		_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D2 = (_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D)_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzDw8fylj6pfwMQgg2Y_0024eh1GL_FWJc, _0023_003Dz9UNAzE0_003D);
		_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzklfmT0QmYoqW(ref _0023_003DziHtkvmE_003D);
		_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D);
		_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzklfmT0QmYoqW(ref _0023_003DziHtkvmE_003D);
		string text = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D);
		int[] array = null;
		if (text != string.Empty)
		{
			array = text.Split(',').Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzJy4tSrfcPTb8KYjAhw_003D_003D).ToArray();
		}
		string _0023_003DzcDEsV8s_003D = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D);
		List<IndexTriangle> list = new List<IndexTriangle>();
		string[] array2 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzpMnrDprxQnds(_0023_003DzcDEsV8s_003D);
		for (int i = 0; i < array2.Length; i++)
		{
			string[] array3 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzQywL4rn4wxIe(array2[i]);
			int num = int.Parse(array3[0], CultureInfo.InvariantCulture) - 1;
			int num2 = int.Parse(array3[1], CultureInfo.InvariantCulture) - 1;
			int num3 = int.Parse(array3[2], CultureInfo.InvariantCulture) - 1;
			if (array == null || array.Length == 0)
			{
				list.Add(new IndexTriangle(num, num2, num3));
			}
			else
			{
				list.Add(new IndexTriangle(array[num] - 1, array[num2] - 1, array[num3] - 1));
			}
		}
		return (_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D2._0023_003DzYNux6PWoz6TL(), list);
	}
}
