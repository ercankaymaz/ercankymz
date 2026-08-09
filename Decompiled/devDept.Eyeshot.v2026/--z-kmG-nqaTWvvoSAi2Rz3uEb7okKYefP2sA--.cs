using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using devDept.Geometry;

internal sealed class _0023_003Dz_0024kmG_0024nqaTWvvoSAi2Rz3uEb7okKYefP2sA_003D_003D : _0023_003DzXXz8MxLlH6VTOkBvU1LuwkJY_0024oPJow3nGg_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<string, int> _0023_003DzcG_VsRmXvrzsC6CeBw_003D_003D;

		public static Func<string, string> _0023_003Dz7QTL4jkx0Ek3bG0y9Q_003D_003D;

		public static Func<string, string> _0023_003DzWH5uejRM4z_0024_0024KQ5K9A_003D_003D;

		internal int _0023_003DzDUXPwpaT4_IclKngOw_003D_003D(string _0023_003DzuwH5j5s_003D)
		{
			return int.Parse(_0023_003DzuwH5j5s_003D.Trim(), CultureInfo.InvariantCulture);
		}

		internal string _0023_003DztvXdWJSrqo93oP_0024zxw_003D_003D(string _0023_003DzNDQ_E88_003D)
		{
			return _0023_003DzNDQ_E88_003D.Trim();
		}

		internal string _0023_003Dzv7rrPA1_wEg0j5eWBQ_003D_003D(string _0023_003DzNDQ_E88_003D)
		{
			return _0023_003DzNDQ_E88_003D.Trim();
		}
	}

	private sealed class _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D
	{
		public int[] _0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D;

		internal int _0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(string _0023_003Dz0jxzq30_003D)
		{
			int num = int.Parse(_0023_003Dz0jxzq30_003D.Trim(), CultureInfo.InvariantCulture);
			if (_0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D == null || _0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D.Length == 0)
			{
				return num - 1;
			}
			return _0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D[num - 1] - 1;
		}
	}

	private int _0023_003DzFmdz4TekHTP_0024i6_qECYul3QIbtTe = -1;

	private Vector3D[] _0023_003DzqaPyYd4prI7pCzFaiw_003D_003D;

	private int[] _0023_003DzGfONLKY8Mte4;

	private int _0023_003Dz1SuzYW4jiuWW;

	internal _0023_003Dz_0024kmG_0024nqaTWvvoSAi2Rz3uEb7okKYefP2sA_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
	}

	public Vector3D[] _0023_003Dz5QHZY0DF_kW6hpithA_003D_003D()
	{
		return _0023_003DzqaPyYd4prI7pCzFaiw_003D_003D;
	}

	public void _0023_003DzGCLU9Ejbtici1iGNzQ_003D_003D(Vector3D[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzqaPyYd4prI7pCzFaiw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public int[] _0023_003DzTzoM_0024xoPFepL()
	{
		return _0023_003DzGfONLKY8Mte4;
	}

	public void _0023_003Dz_0024cFVil3t1uFL(int[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzGfONLKY8Mte4 = _0023_003DzPzO_0024GUk_003D;
	}

	public int _0023_003Dzr61X42yyrTLE()
	{
		return _0023_003Dz1SuzYW4jiuWW;
	}

	public void _0023_003DzsRwgD9aWMZ6L(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz1SuzYW4jiuWW = _0023_003DzPzO_0024GUk_003D;
	}

	public int _0023_003Dzluc7808oSzWClIA57RzKS8k_003D()
	{
		return _0023_003DzFmdz4TekHTP_0024i6_qECYul3QIbtTe;
	}

	private void _0023_003Dzguvfnk134kV7hqEr_0024I7yrgQ_003D(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzFmdz4TekHTP_0024i6_qECYul3QIbtTe = _0023_003DzPzO_0024GUk_003D;
	}

	public override (Point3D[], List<IndexTriangle>) _0023_003DzY15vWMs_003D(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D)
	{
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D CS_0024_003C_003E8__locals15 = new _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D();
		_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D2 = (_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D)_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzDw8fylj6pfwMQgg2Y_0024eh1GL_FWJc, _0023_003Dz9UNAzE0_003D);
		int.TryParse(_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzklfmT0QmYoqW(ref _0023_003DziHtkvmE_003D), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result);
		_0023_003DzsRwgD9aWMZ6L(result);
		string text = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D);
		Vector3D[] array = null;
		if (!string.IsNullOrWhiteSpace(text))
		{
			string[] array2 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzpMnrDprxQnds(text);
			array = new Vector3D[array2.Length];
			int num = 0;
			string[] array3 = array2;
			for (int i = 0; i < array3.Length; i++)
			{
				string[] array4 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzQywL4rn4wxIe(array3[i]);
				double x = double.Parse(array4[0], CultureInfo.InvariantCulture);
				double y = double.Parse(array4[1], CultureInfo.InvariantCulture);
				double z = double.Parse(array4[2], CultureInfo.InvariantCulture);
				array[num++] = new Vector3D(x, y, z);
			}
		}
		_0023_003DzGCLU9Ejbtici1iGNzQ_003D_003D(array);
		string text2 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzklfmT0QmYoqW(ref _0023_003DziHtkvmE_003D).Trim();
		if (!string.IsNullOrEmpty(text2) && text2 != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772))
		{
			if (text2.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027)))
			{
				if (int.TryParse(text2.TrimStart('#'), out var result2))
				{
					_0023_003Dzguvfnk134kV7hqEr_0024I7yrgQ_003D(result2);
				}
			}
			else
			{
				_0023_003Dzguvfnk134kV7hqEr_0024I7yrgQ_003D(-1);
			}
		}
		string text3 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D);
		CS_0024_003C_003E8__locals15._0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D = null;
		if (!string.IsNullOrWhiteSpace(text3))
		{
			string text4 = text3.Trim();
			if (text4.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083)) && text4.EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091)))
			{
				text4 = text4.Substring(1, text4.Length - 2).Trim();
			}
			if (!string.IsNullOrEmpty(text4))
			{
				string[] source = text4.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				CS_0024_003C_003E8__locals15._0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D = source.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzDUXPwpaT4_IclKngOw_003D_003D).ToArray();
			}
		}
		_0023_003Dz_0024cFVil3t1uFL(CS_0024_003C_003E8__locals15._0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D);
		string text5 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D);
		string text6 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003Dz7VkGdaDHMh8A(ref _0023_003DziHtkvmE_003D);
		List<IndexTriangle> list = new List<IndexTriangle>();
		if (!string.IsNullOrWhiteSpace(text5))
		{
			string[] array3 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzpMnrDprxQnds(text5);
			for (int i = 0; i < array3.Length; i++)
			{
				string[] array5 = (from _0023_003DzNDQ_E88_003D in array3[i].Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
					select _0023_003DzNDQ_E88_003D.Trim()).ToArray();
				if (array5.Length == 3)
				{
					int v = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array5[0]);
					int v2 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array5[1]);
					int v3 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array5[2]);
					list.Add(new IndexTriangle(v, v2, v3));
				}
				else
				{
					if (array5.Length <= 3)
					{
						continue;
					}
					int[] array6 = array5.Select(delegate(string _0023_003Dz0jxzq30_003D)
					{
						int num4 = int.Parse(_0023_003Dz0jxzq30_003D.Trim(), CultureInfo.InvariantCulture);
						return (CS_0024_003C_003E8__locals15._0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D == null || CS_0024_003C_003E8__locals15._0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D.Length == 0) ? (num4 - 1) : (CS_0024_003C_003E8__locals15._0023_003DzL_0024FNktm_0024XIe77kks2A_003D_003D[num4 - 1] - 1);
					}).ToArray();
					for (int num2 = 0; num2 < array6.Length - 2; num2++)
					{
						if (num2 % 2 == 0)
						{
							list.Add(new IndexTriangle(array6[num2], array6[num2 + 1], array6[num2 + 2]));
						}
						else
						{
							list.Add(new IndexTriangle(array6[num2 + 1], array6[num2], array6[num2 + 2]));
						}
					}
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(text6))
		{
			string[] array3 = _0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D._0023_003DzpMnrDprxQnds(text6);
			for (int i = 0; i < array3.Length; i++)
			{
				string[] array7 = array3[i].Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzv7rrPA1_wEg0j5eWBQ_003D_003D).ToArray();
				if (array7.Length == 3)
				{
					int v4 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array7[0]);
					int v5 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array7[1]);
					int v6 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array7[2]);
					list.Add(new IndexTriangle(v4, v5, v6));
				}
				else if (array7.Length > 3)
				{
					int v7 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array7[0]);
					for (int num3 = 1; num3 < array7.Length - 1; num3++)
					{
						int v8 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array7[num3]);
						int v9 = CS_0024_003C_003E8__locals15._0023_003DqxS0swu7uvoeWwOP_0024mi_MoXV6L3fCQMS3VPD5PE8KTuFkzzkoPDG_jE2G83n_qE3C(array7[num3 + 1]);
						list.Add(new IndexTriangle(v7, v8, v9));
					}
				}
			}
		}
		return (_0023_003DzWhaoSY_Ae2TPPl_dOg_003D_003D2._0023_003DzYNux6PWoz6TL(), list);
	}
}
