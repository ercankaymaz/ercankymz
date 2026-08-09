using System;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D
{
	public Point3D[] _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D;

	public _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzZSnvfVF8Y5Qg;

	public IndexLine[] _0023_003DzU4XYawo_003D;

	public _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D()
	{
		_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D = new Point3D[0];
		_0023_003DzZSnvfVF8Y5Qg = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[0];
		_0023_003DzU4XYawo_003D = new IndexLine[0];
	}

	public _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(Mesh _0023_003DzkKfJheA_003D)
	{
		_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D = _0023_003DzkKfJheA_003D._vertices;
		IndexTriangle[] triangles = _0023_003DzkKfJheA_003D.Triangles;
		_0023_003DzZSnvfVF8Y5Qg = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[triangles.Length];
		for (int i = 0; i < triangles.Length; i++)
		{
			_0023_003DzZSnvfVF8Y5Qg[i] = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(triangles[i]);
		}
		_0023_003DzU4XYawo_003D = _0023_003DzkKfJheA_003D.Edges;
	}

	public _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int[][] _0023_003Dzf5ywTHlO2gM5)
	{
		_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		_0023_003DzZSnvfVF8Y5Qg = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[1]
		{
			new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(_0023_003Dzf5ywTHlO2gM5)
		};
	}

	public _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzpPOEJqcAh7Lr)
	{
		_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		_0023_003DzZSnvfVF8Y5Qg = _0023_003DzpPOEJqcAh7Lr;
	}

	public void _0023_003DzSnbFaS0_003D(_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003DzaFq_jmPhTjg_0024, bool _0023_003DzEuQ72GKNmfZl, bool _0023_003DzFD2DkC_4lrYUT6xPuw_003D_003D, Size3D _0023_003DzVfzh0tc_003D)
	{
		int num = _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D.Length;
		int num2 = _0023_003DzaFq_jmPhTjg_0024._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D.Length;
		Array.Resize(ref _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D, num + num2);
		for (int i = 0; i < num2; i++)
		{
			_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[i + num] = (Point3D)_0023_003DzaFq_jmPhTjg_0024._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[i].Clone();
		}
		int num3 = _0023_003DzZSnvfVF8Y5Qg.Length;
		Array.Resize(ref _0023_003DzZSnvfVF8Y5Qg, num3 + _0023_003DzaFq_jmPhTjg_0024._0023_003DzZSnvfVF8Y5Qg.Length);
		if (_0023_003DzZSnvfVF8Y5Qg.Length != 0 && _0023_003DzZSnvfVF8Y5Qg[0] == null)
		{
			_0023_003DzZSnvfVF8Y5Qg[0] = _0023_003DzaFq_jmPhTjg_0024._0023_003DzZSnvfVF8Y5Qg[0];
		}
		if (_0023_003DzZSnvfVF8Y5Qg.Length != 0)
		{
			for (int j = 0; j < _0023_003DzaFq_jmPhTjg_0024._0023_003DzZSnvfVF8Y5Qg.Length; j++)
			{
				_0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D2 = (_0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D)_0023_003DzaFq_jmPhTjg_0024._0023_003DzZSnvfVF8Y5Qg[j].Clone();
				_0023_003DzZSnvfVF8Y5Qg[j + num3] = _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D2;
				int[][] _0023_003DzhMDfC7g_003D = _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D2._0023_003DzhMDfC7g_003D;
				for (int k = 0; k < _0023_003DzhMDfC7g_003D.Length; k++)
				{
					int num4 = _0023_003DzhMDfC7g_003D[k].Length;
					for (int l = 0; l < num4; l++)
					{
						_0023_003DzhMDfC7g_003D[k][l] += num;
					}
				}
			}
		}
		if (!_0023_003DzFD2DkC_4lrYUT6xPuw_003D_003D && _0023_003DzU4XYawo_003D != null && _0023_003DzaFq_jmPhTjg_0024._0023_003DzU4XYawo_003D != null)
		{
			int num5 = _0023_003DzU4XYawo_003D.Length;
			Array.Resize(ref _0023_003DzU4XYawo_003D, num5 + _0023_003DzaFq_jmPhTjg_0024._0023_003DzU4XYawo_003D.Length);
			for (int m = 0; m < _0023_003DzaFq_jmPhTjg_0024._0023_003DzU4XYawo_003D.Length; m++)
			{
				_0023_003DzU4XYawo_003D[m + num5] = (IndexLine)_0023_003DzaFq_jmPhTjg_0024._0023_003DzU4XYawo_003D[m].Clone();
				_0023_003DzU4XYawo_003D[m + num5].V1 += num;
				_0023_003DzU4XYawo_003D[m + num5].V2 += num;
			}
		}
		if (_0023_003DzEuQ72GKNmfZl)
		{
			_0023_003Dz6tNTbj2n_0024gTT(ref _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D, ref _0023_003DzZSnvfVF8Y5Qg, null, Utility._0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(_0023_003DzVfzh0tc_003D.Diagonal));
		}
		if (_0023_003DzFD2DkC_4lrYUT6xPuw_003D_003D)
		{
			_0023_003DzU4XYawo_003D = null;
		}
	}

	internal static void _0023_003Dz6tNTbj2n_0024gTT(ref Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzD_4yRKeiIPD1, IndexLine[] _0023_003DzU3hosSAzkxO7, double _0023_003DzX0qX_IwWxysi)
	{
		Utility._0023_003DzepEAzpTGgC_4(ref _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003DzD_4yRKeiIPD1, _0023_003DzU3hosSAzkxO7, _0023_003DzX0qX_IwWxysi, out var _0023_003DzabSzpyKrzcO8xP7ZnA_003D_003D, out var _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D);
		_0023_003DzD_4yRKeiIPD1 = _0023_003DzabSzpyKrzcO8xP7ZnA_003D_003D;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D;
	}
}
