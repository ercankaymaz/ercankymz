using System;
using System.Collections.Generic;
using System.Linq;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal static class _0023_003DzNXGCQkhQtRkNL5Wfh_0024VyMFYjbHwY_0024emHzlK8LSB2_0024jeLSLMuCLFLfYU_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<ICurve, bool> _0023_003DzY8Uv_M2imvzS6Z9OgQ_003D_003D;

		public static Func<ICurve, bool> _0023_003Dzva0mm4tTW6Ab8HpH_0024w_003D_003D;

		internal bool _0023_003Dzwbp5TECULIBxX5__0024Ue0c6EgzSwRE_0024TreTg_003D_003D(ICurve _0023_003DzBJFJHwk_003D)
		{
			if (!(_0023_003DzBJFJHwk_003D is Point))
			{
				return !_0023_003DzBJFJHwk_003D.IsPoint;
			}
			return false;
		}

		internal bool _0023_003DzedyPmkEnkFnNMvrD0ibZfTG0qi5l(ICurve _0023_003Dzs_0024uS8LA_003D)
		{
			return _0023_003Dzs_0024uS8LA_003D.Length() > 0.0;
		}
	}

	private sealed class _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D
	{
		public Region _0023_003Dz2T4sy2I_003D;

		public ICurve[] _0023_003DzO91j_0024fQ_003D;

		public Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D;

		public Func<ICurve, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzJjT3dOU3oUsg;

		public Func<ICurve, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzzaljjvyD9N9t;

		internal void _0023_003Dzf7FIIPF8ogN5bJbZLgaD5jI_003D(out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003DznzaFsjg_003D, out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003Dz9gcA7tQ_003D, out Transformation _0023_003Dz2HI4YY_0024WuJj9, out Plane _0023_003DzlqZnaxrmezyK)
		{
			_0023_003DzlqZnaxrmezyK = _0023_003Dz0Tgl96xVQO6jMMtG8WP0Vb0_003D(_0023_003Dz2T4sy2I_003D);
			_0023_003Dz2HI4YY_0024WuJj9 = new Align3D(_0023_003DzlqZnaxrmezyK, Plane.XY);
			_0023_003Dz2HI4YY_0024WuJj9 = _0023_003Dzr_l2K5gwh_0024bxuYxCig_003D_003D(_0023_003Dz2T4sy2I_003D.contourList, _0023_003DzO91j_0024fQ_003D) * _0023_003Dz2HI4YY_0024WuJj9;
			ICurve[] source = _0023_003DzJXAtzVj3Q7GwObg7srI969E_003D(_0023_003Dz2T4sy2I_003D.ContourList.ToArray(), _0023_003Dz2HI4YY_0024WuJj9);
			ICurve[] source2 = _0023_003DzJXAtzVj3Q7GwObg7srI969E_003D(_0023_003DzO91j_0024fQ_003D, _0023_003Dz2HI4YY_0024WuJj9);
			_0023_003DznzaFsjg_003D = source.Select((ICurve _0023_003DzdCP541Q_003D) => _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(_0023_003DzdCP541Q_003D, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D)).ToArray();
			_0023_003Dz9gcA7tQ_003D = source2.Select(_0023_003Dz9ZoBkfGFrdbDG9R8VNv23wU_003D).ToArray();
		}

		internal _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzPIti0HJrQUQANkFCOfOsu_00240_003D(ICurve _0023_003DzdCP541Q_003D)
		{
			return _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(_0023_003DzdCP541Q_003D, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
		}

		internal _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz9ZoBkfGFrdbDG9R8VNv23wU_003D(ICurve _0023_003DzdCP541Q_003D)
		{
			return _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(_0023_003DzdCP541Q_003D, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
		}
	}

	private sealed class _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D
	{
		public Transformation _0023_003DzfX4euWM_003D;

		internal void _0023_003DzDTCX_gi_Zpvud3XsRUuEReo_003D(ICurve _0023_003DzbfrNXYE_003D)
		{
			((Entity)_0023_003DzbfrNXYE_003D).TransformBy(_0023_003DzfX4euWM_003D);
		}

		internal void _0023_003DzwRqnRW3Z7VT6TI41_0024YHeEWs_003D(ICurve _0023_003DzbfrNXYE_003D)
		{
			((Entity)_0023_003DzbfrNXYE_003D).TransformBy(_0023_003DzfX4euWM_003D);
		}

		internal void _0023_003DzItrRd3jq7eMAHAwGrZ09Z5I_003D(Region _0023_003DzbfrNXYE_003D)
		{
			_0023_003DzbfrNXYE_003D.TransformBy(_0023_003DzfX4euWM_003D);
		}
	}

	private static class _0023_003DzQm9ltrs_003D
	{
		public static _0023_003DzTcLuDkQBH_0024fJ _0023_003DzZY4_0024HN1IdjiKUytf9w_003D_003D;

		public static _0023_003DzTcLuDkQBH_0024fJ _0023_003DzmBtFdIdgEIxUWzXFtA_003D_003D;

		public static _0023_003DzTcLuDkQBH_0024fJ _0023_003DzXK9CuMCuNuTm1crE2A_003D_003D;

		public static _0023_003DzTcLuDkQBH_0024fJ _0023_003DzLIFjIBa62_HQJlNfig_003D_003D;
	}

	private delegate List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> _0023_003DzTcLuDkQBH_0024fJ(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzBA0uIi0_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzeM_NgoQ_003D, out bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D);

	private sealed class _0023_003DzaY_Y43Wls7kQynbyL1t9LF0_003D
	{
		public Transformation _0023_003DzfX4euWM_003D;

		internal ICurve _0023_003DzsmBDhw1dvfW5gEWrXx4MQ_0024m9tDOm2PR_00240Q_003D_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			ICurve obj = (ICurve)_0023_003Dzt_m8zV0_003D.Clone();
			((Entity)obj).TransformBy(_0023_003DzfX4euWM_003D);
			return obj;
		}
	}

	private sealed class _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D
	{
		public Region _0023_003Dz2T4sy2I_003D;

		public Entity _0023_003DzO91j_0024fQ_003D;

		public Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D;

		public Func<ICurve, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzJjT3dOU3oUsg;

		public Func<ICurve, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzzaljjvyD9N9t;

		internal void _0023_003DzgZD_0024O6RfbF5XpJ47gXQsnGk_003D(out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003DznzaFsjg_003D, out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003Dz9gcA7tQ_003D, out Transformation _0023_003Dz2HI4YY_0024WuJj9, out Plane _0023_003DzlqZnaxrmezyK)
		{
			_0023_003DzlqZnaxrmezyK = _0023_003Dz0Tgl96xVQO6jMMtG8WP0Vb0_003D(_0023_003Dz2T4sy2I_003D);
			_0023_003Dz2HI4YY_0024WuJj9 = new Align3D(_0023_003DzlqZnaxrmezyK, Plane.XY);
			Region obj = (Region)_0023_003Dz2T4sy2I_003D.Clone();
			Entity entity = (Entity)_0023_003DzO91j_0024fQ_003D.Clone();
			List<ICurve> contourList = obj.ContourList;
			List<ICurve> list = ((entity is Region) ? ((Region)entity).ContourList : new List<ICurve> { (ICurve)entity });
			_0023_003Dz2HI4YY_0024WuJj9 = _0023_003Dzr_l2K5gwh_0024bxuYxCig_003D_003D(contourList, list) * _0023_003Dz2HI4YY_0024WuJj9;
			obj.TransformBy(_0023_003Dz2HI4YY_0024WuJj9);
			entity.TransformBy(_0023_003Dz2HI4YY_0024WuJj9);
			_0023_003DzRtV9ofrD1_YpiuR4sA_003D_003D(obj);
			_0023_003DzRtV9ofrD1_YpiuR4sA_003D_003D(entity);
			_0023_003DznzaFsjg_003D = contourList.Select(_0023_003Dz6rNyCCmVHzHbpSDFTmJJZYE_003D).ToArray();
			_0023_003Dz9gcA7tQ_003D = list.Select((ICurve _0023_003DzdCP541Q_003D) => _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(_0023_003DzdCP541Q_003D, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D)).ToArray();
		}

		internal _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz6rNyCCmVHzHbpSDFTmJJZYE_003D(ICurve _0023_003DzdCP541Q_003D)
		{
			return _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(_0023_003DzdCP541Q_003D, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
		}

		internal _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzqNElWAjLgvnw_0024ptb4PhTxyA_003D(ICurve _0023_003DzdCP541Q_003D)
		{
			return _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(_0023_003DzdCP541Q_003D, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
		}
	}

	private delegate void _0023_003Dzg9xoOGYOrztd(out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003DznzaFsjg_003D, out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003Dz9gcA7tQ_003D, out Transformation _0023_003DzfX4euWM_003D, out Plane _0023_003DzlqZnaxrmezyK);

	private static List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003Dzj1JfKmFIvV8qDLqE_A_003D_003D(IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzWaFlkhfmYCja, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_SqBXz8_003D, out bool _0023_003DzAqruXRs80EIF)
	{
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>();
		_0023_003DzAqruXRs80EIF = false;
		for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
		{
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2 = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzWaFlkhfmYCja[i], _0023_003Dz_SqBXz8_003D, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1);
			list.AddRange(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzNBFv6Go_003D);
			_0023_003DzAqruXRs80EIF |= _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.Count > 0;
		}
		return list;
	}

	private static List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> _0023_003DzS_0024pM1o19RjjX(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzBA0uIi0_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzeM_NgoQ_003D, out bool _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D)
	{
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(1 + _0023_003DzBA0uIi0_003D.Count);
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(1 + _0023_003DzeM_NgoQ_003D.Count);
		_0023_003Dz4PhBM2GEoXooEhbWDQ_003D_003D(list, _0023_003Dz0TQuX2w_003D, _0023_003DzBA0uIi0_003D, _0023_003Dzbu8BV15Qqzan: true);
		_0023_003Dz4PhBM2GEoXooEhbWDQ_003D_003D(list2, _0023_003DzCM7y44E_003D, _0023_003DzeM_NgoQ_003D, _0023_003Dzbu8BV15Qqzan: false);
		return _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(list, list2, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)4, out _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D);
	}

	private static void _0023_003Dz4PhBM2GEoXooEhbWDQ_003D_003D(List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_SqBXz8_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzWaFlkhfmYCja, bool _0023_003Dzbu8BV15Qqzan)
	{
		_0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D.Add(_0023_003Dz_SqBXz8_003D);
		foreach (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item in _0023_003DzWaFlkhfmYCja)
		{
			if (_0023_003Dzbu8BV15Qqzan && _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D._0023_003DzyvZg648_003D(item) > 0.0)
			{
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D._0023_003DzDLr6MhnInIOlL7ghbQ_003D_003D(item);
			}
			_0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D.Add(item);
		}
	}

	internal static Region[] _0023_003Dz6PsRlFc_003D(Region _0023_003DzbfrNXYE_003D, ICurve[] _0023_003Dzt_m8zV0_003D, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D, out ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, out bool _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D)
	{
		return _0023_003DzlJtvZyYpPAuc(_0023_003DzbfrNXYE_003D, _0023_003Dzt_m8zV0_003D, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, delegate(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzBA0uIi0_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzeM_NgoQ_003D, out bool _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D2)
		{
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(1 + _0023_003DzBA0uIi0_003D.Count);
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(1 + _0023_003DzeM_NgoQ_003D.Count);
			_0023_003Dz4PhBM2GEoXooEhbWDQ_003D_003D(list, _0023_003Dz0TQuX2w_003D, _0023_003DzBA0uIi0_003D, _0023_003Dzbu8BV15Qqzan: true);
			_0023_003Dz4PhBM2GEoXooEhbWDQ_003D_003D(list2, _0023_003DzCM7y44E_003D, _0023_003DzeM_NgoQ_003D, _0023_003Dzbu8BV15Qqzan: false);
			return _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(list, list2, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)4, out _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D2);
		}, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D, out _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D);
	}

	private static List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> _0023_003DzpTY3Aqknu1EJ(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzsewiT4KvG0KH, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzXdgEf8t8nB_0024S, out bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D)
	{
		_0023_003DzzNA19d60VlSnNazKfA_003D_003D = true;
		List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> list = new List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D>();
		_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2 = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)0);
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzNBFv6Go_003D);
		if (list2.Count > 1)
		{
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzNBFv6Go_003D.Add(_0023_003Dz0TQuX2w_003D);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(_0023_003DzsewiT4KvG0KH);
			list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D4 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D4._0023_003DzNBFv6Go_003D.Add(_0023_003DzCM7y44E_003D);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D4._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(_0023_003DzXdgEf8t8nB_0024S);
			list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D4);
			return list;
		}
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> collection = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D);
		bool _0023_003DzAqruXRs80EIF;
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list3 = _0023_003Dzj1JfKmFIvV8qDLqE_A_003D_003D(_0023_003DzsewiT4KvG0KH, _0023_003DzCM7y44E_003D, out _0023_003DzAqruXRs80EIF);
		if (_0023_003DzAqruXRs80EIF)
		{
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D5 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D5._0023_003DzNBFv6Go_003D.Add(_0023_003DzCM7y44E_003D);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D5._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(_0023_003DzXdgEf8t8nB_0024S);
			list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D5);
		}
		list3.AddRange(_0023_003Dzj1JfKmFIvV8qDLqE_A_003D_003D(_0023_003DzXdgEf8t8nB_0024S, _0023_003Dz0TQuX2w_003D, out _0023_003DzAqruXRs80EIF));
		if (_0023_003DzAqruXRs80EIF)
		{
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D6 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D6._0023_003DzNBFv6Go_003D.Add(_0023_003Dz0TQuX2w_003D);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D6._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(_0023_003DzsewiT4KvG0KH);
			list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D6);
		}
		for (int i = 0; i < list2.Count; i++)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item = list2[i];
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D7 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list4 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>();
			for (int j = 0; j < _0023_003DzsewiT4KvG0KH.Count; j++)
			{
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzX8x2b1synnmh = _0023_003DzsewiT4KvG0KH[j];
				for (int k = 0; k < _0023_003DzXdgEf8t8nB_0024S.Count; k++)
				{
					_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzuiKPngFDQW1J = _0023_003DzXdgEf8t8nB_0024S[k];
					List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzNBFv6Go_003D = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzX8x2b1synnmh, _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2)._0023_003DzNBFv6Go_003D;
					if (_0023_003DzNBFv6Go_003D.Count > 0)
					{
						list4.AddRange(_0023_003DzNBFv6Go_003D);
					}
				}
			}
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D7._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(list3);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D7._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(list4);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D7._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(collection);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D7._0023_003DzNBFv6Go_003D.Add(item);
			list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D7);
		}
		return list;
	}

	public static Region[] _0023_003DzrIsIvtI_003D(Region _0023_003Dz2T4sy2I_003D, Region _0023_003DzO91j_0024fQ_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D)
	{
		return _0023_003Dzy1P90ibGNi6olYlEqg_003D_003D(_0023_003Dz2T4sy2I_003D, _0023_003DzO91j_0024fQ_003D, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, _0023_003DzpTY3Aqknu1EJ, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, null);
	}

	private static IEnumerable<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzqbtBmDykfiyYWgGP1A_003D_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_SqBXz8_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzWaFlkhfmYCja)
	{
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>();
		foreach (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item in _0023_003DzWaFlkhfmYCja)
		{
			list.AddRange(_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz_SqBXz8_003D, item, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2)._0023_003DzNBFv6Go_003D);
		}
		return list;
	}

	private static IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzoNwOCtUNC10XVFawHcwxKJ4_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzsewiT4KvG0KH, List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003Dzq9GqFE4_003D, Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool> _0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D)
	{
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> { _0023_003DzCM7y44E_003D };
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>();
		for (int num = _0023_003DzsewiT4KvG0KH.Count - 1; num >= 0; num--)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzsewiT4KvG0KH[num];
			bool flag = false;
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzuiKPngFDQW1J = list[num2];
				IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzNBFv6Go_003D = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2, _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)0)._0023_003DzNBFv6Go_003D;
				if (_0023_003DzNBFv6Go_003D.Count == 1)
				{
					flag = true;
					list.RemoveAt(num2);
					list.AddRange(_0023_003DzNBFv6Go_003D);
				}
			}
			if (!flag)
			{
				list2.Add(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzX8x2b1synnmh = list[i];
			for (int j = 0; j < list.Count; j++)
			{
				if (i == j)
				{
					continue;
				}
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3 = list[j];
				if (_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzX8x2b1synnmh, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1)._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.Count > 0)
				{
					_0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D[_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3] = true;
					_0023_003Dzq9GqFE4_003D.Add(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3);
					list.RemoveAt(j);
					j--;
					if (i > j)
					{
						i--;
					}
				}
			}
		}
		list.AddRange(list2);
		return list;
	}

	private static List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003Dzq9GqFE4_003D, int _0023_003DzASLweDvCKaT4, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzWaFlkhfmYCja, Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool> _0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D, Dictionary<int, int> _0023_003Dz3uafwEHGtXFIG2gC_0024A_003D_003D, out bool _0023_003Dzxh9_ujyaVFe4)
	{
		_0023_003Dzxh9_ujyaVFe4 = false;
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>();
		if (!_0023_003Dz3uafwEHGtXFIG2gC_0024A_003D_003D.TryGetValue(_0023_003DzASLweDvCKaT4, out var value))
		{
			value = _0023_003DzWaFlkhfmYCja.Count - 1;
		}
		for (int num = value; num >= 0; num--)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzuiKPngFDQW1J = _0023_003DzWaFlkhfmYCja[num];
			if (_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dzq9GqFE4_003D[_0023_003DzASLweDvCKaT4], _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2)._0023_003DzNBFv6Go_003D.Count > 0)
			{
				List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzNBFv6Go_003D = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dzq9GqFE4_003D[_0023_003DzASLweDvCKaT4], _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1)._0023_003DzNBFv6Go_003D;
				foreach (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item in _0023_003DzNBFv6Go_003D)
				{
					_0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D[item] = _0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D.TryGetValue(_0023_003Dzq9GqFE4_003D[_0023_003DzASLweDvCKaT4], out var value2) && value2;
				}
				if (_0023_003DzNBFv6Go_003D.Count <= 0)
				{
					_0023_003Dzq9GqFE4_003D.RemoveAt(_0023_003DzASLweDvCKaT4);
					_0023_003Dzxh9_ujyaVFe4 = true;
					return list;
				}
				_0023_003Dzq9GqFE4_003D[_0023_003DzASLweDvCKaT4] = _0023_003DzNBFv6Go_003D[0];
				int num2 = _0023_003Dzq9GqFE4_003D.Count;
				int value3 = num - 1;
				for (int i = 1; i < _0023_003DzNBFv6Go_003D.Count; i++)
				{
					_0023_003Dzq9GqFE4_003D.Add(_0023_003DzNBFv6Go_003D[i]);
					_0023_003Dz3uafwEHGtXFIG2gC_0024A_003D_003D[num2] = value3;
					num2++;
				}
			}
		}
		for (int num3 = _0023_003DzWaFlkhfmYCja.Count - 1; num3 >= 0; num3--)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzWaFlkhfmYCja[num3];
			if (_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dzq9GqFE4_003D[_0023_003DzASLweDvCKaT4], _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1)._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.Count > 0)
			{
				list.Add(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2);
			}
		}
		return list;
	}

	private static List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> _0023_003DzEd0_0024gXHsiY8i(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzsewiT4KvG0KH, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzXdgEf8t8nB_0024S, out bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D)
	{
		_0023_003DzzNA19d60VlSnNazKfA_003D_003D = true;
		List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> list = new List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D>();
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>();
		list2.AddRange(_0023_003DzqbtBmDykfiyYWgGP1A_003D_003D(_0023_003Dz0TQuX2w_003D, _0023_003DzXdgEf8t8nB_0024S));
		Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool> dictionary = new Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool>(list2.Count);
		foreach (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item2 in list2)
		{
			dictionary[item2] = true;
		}
		IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzWaFlkhfmYCja = _0023_003DzsewiT4KvG0KH;
		_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2 = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1);
		list2.AddRange(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzNBFv6Go_003D);
		if (_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.Count > 0)
		{
			_0023_003DzWaFlkhfmYCja = _0023_003DzoNwOCtUNC10XVFawHcwxKJ4_003D(_0023_003DzCM7y44E_003D, _0023_003DzsewiT4KvG0KH, list2, dictionary);
		}
		for (int i = 0; i < list2.Count; i++)
		{
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
			bool value;
			bool _0023_003Dzxh9_ujyaVFe;
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> collection = ((!(dictionary.TryGetValue(list2[i], out value) && value)) ? _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, i, _0023_003DzWaFlkhfmYCja, dictionary, new Dictionary<int, int>(), out _0023_003Dzxh9_ujyaVFe) : _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, i, _0023_003DzsewiT4KvG0KH, dictionary, new Dictionary<int, int>(), out _0023_003Dzxh9_ujyaVFe));
			if (_0023_003Dzxh9_ujyaVFe)
			{
				i--;
				continue;
			}
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item = list2[i];
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(collection);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzNBFv6Go_003D.Add(item);
			list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3);
		}
		return list;
	}

	public static Region[] _0023_003DzoTH8BDg_003D(Region _0023_003Dz2T4sy2I_003D, Region _0023_003DzO91j_0024fQ_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D)
	{
		return _0023_003Dzy1P90ibGNi6olYlEqg_003D_003D(_0023_003Dz2T4sy2I_003D, _0023_003DzO91j_0024fQ_003D, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, delegate(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzsewiT4KvG0KH, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzXdgEf8t8nB_0024S, out bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D)
		{
			_0023_003DzzNA19d60VlSnNazKfA_003D_003D = true;
			List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> list = new List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D>();
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>();
			list2.AddRange(_0023_003DzqbtBmDykfiyYWgGP1A_003D_003D(_0023_003Dz0TQuX2w_003D, _0023_003DzXdgEf8t8nB_0024S));
			Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool> dictionary = new Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool>(list2.Count);
			foreach (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item2 in list2)
			{
				dictionary[item2] = true;
			}
			IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzWaFlkhfmYCja = _0023_003DzsewiT4KvG0KH;
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2 = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1);
			list2.AddRange(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzNBFv6Go_003D);
			if (_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.Count > 0)
			{
				_0023_003DzWaFlkhfmYCja = _0023_003DzoNwOCtUNC10XVFawHcwxKJ4_003D(_0023_003DzCM7y44E_003D, _0023_003DzsewiT4KvG0KH, list2, dictionary);
			}
			for (int i = 0; i < list2.Count; i++)
			{
				_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
				bool value;
				bool _0023_003Dzxh9_ujyaVFe;
				List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> collection = ((!(dictionary.TryGetValue(list2[i], out value) && value)) ? _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, i, _0023_003DzWaFlkhfmYCja, dictionary, new Dictionary<int, int>(), out _0023_003Dzxh9_ujyaVFe) : _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, i, _0023_003DzsewiT4KvG0KH, dictionary, new Dictionary<int, int>(), out _0023_003Dzxh9_ujyaVFe));
				if (_0023_003Dzxh9_ujyaVFe)
				{
					i--;
				}
				else
				{
					_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item = list2[i];
					_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(collection);
					_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzNBFv6Go_003D.Add(item);
					list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3);
				}
			}
			return list;
		}, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, null);
	}

	private static List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> _0023_003DzKK3pUYhqE_002427(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzsewiT4KvG0KH, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzXdgEf8t8nB_0024S, out bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D)
	{
		_0023_003DzzNA19d60VlSnNazKfA_003D_003D = true;
		List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> list = new List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D>();
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2)._0023_003DzNBFv6Go_003D);
		List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list3 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(_0023_003DzsewiT4KvG0KH);
		list3.AddRange(_0023_003DzXdgEf8t8nB_0024S);
		for (int i = 0; i < list3.Count; i++)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzX8x2b1synnmh = list3[i];
			for (int num = list3.Count - 1; num >= 0; num--)
			{
				if (i != num)
				{
					_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzuiKPngFDQW1J = list3[num];
					if (_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzX8x2b1synnmh, _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2)._0023_003DzNBFv6Go_003D.Count > 0)
					{
						IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzNBFv6Go_003D = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzX8x2b1synnmh, _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)0)._0023_003DzNBFv6Go_003D;
						for (int j = 0; j < _0023_003DzNBFv6Go_003D.Count; j++)
						{
							for (int k = 0; k < _0023_003DzNBFv6Go_003D.Count; k++)
							{
								if (j != k && _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzNBFv6Go_003D[k], _0023_003DzNBFv6Go_003D[j], (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1)._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.Count > 0)
								{
									_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
									_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzNBFv6Go_003D.Add(_0023_003DzNBFv6Go_003D[j]);
									list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2);
									_0023_003DzNBFv6Go_003D.RemoveAt(j);
									j--;
									break;
								}
							}
						}
						_0023_003DzX8x2b1synnmh = (list3[i] = _0023_003DzNBFv6Go_003D[0]);
						if (_0023_003DzNBFv6Go_003D.Count > 1)
						{
							list3[num] = _0023_003DzNBFv6Go_003D[1];
							for (int l = 2; l < _0023_003DzNBFv6Go_003D.Count; l++)
							{
								list3.Add(_0023_003DzNBFv6Go_003D[l]);
							}
						}
						else
						{
							if (i > num)
							{
								i--;
							}
							list3.RemoveAt(num);
						}
					}
				}
			}
		}
		Dictionary<int, int> _0023_003Dz3uafwEHGtXFIG2gC_0024A_003D_003D = new Dictionary<int, int>();
		for (int m = 0; m < list2.Count; m++)
		{
			bool _0023_003Dzxh9_ujyaVFe;
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> collection = _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, m, list3, new Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool>(), _0023_003Dz3uafwEHGtXFIG2gC_0024A_003D_003D, out _0023_003Dzxh9_ujyaVFe);
			if (_0023_003Dzxh9_ujyaVFe)
			{
				m--;
				continue;
			}
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(collection);
			_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzNBFv6Go_003D.Add(list2[m]);
			list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3);
		}
		return list;
	}

	public static Region[] _0023_003DzQ7usAag_003D(Region _0023_003Dz2T4sy2I_003D, Region _0023_003DzO91j_0024fQ_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D)
	{
		return _0023_003Dzy1P90ibGNi6olYlEqg_003D_003D(_0023_003Dz2T4sy2I_003D, _0023_003DzO91j_0024fQ_003D, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, delegate(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzsewiT4KvG0KH, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzXdgEf8t8nB_0024S, out bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D)
		{
			_0023_003DzzNA19d60VlSnNazKfA_003D_003D = true;
			List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> list = new List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D>();
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list2 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003Dz0TQuX2w_003D, _0023_003DzCM7y44E_003D, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2)._0023_003DzNBFv6Go_003D);
			List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list3 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(_0023_003DzsewiT4KvG0KH);
			list3.AddRange(_0023_003DzXdgEf8t8nB_0024S);
			for (int i = 0; i < list3.Count; i++)
			{
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzX8x2b1synnmh = list3[i];
				for (int num = list3.Count - 1; num >= 0; num--)
				{
					if (i != num)
					{
						_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzuiKPngFDQW1J = list3[num];
						if (_0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzX8x2b1synnmh, _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)2)._0023_003DzNBFv6Go_003D.Count > 0)
						{
							IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzNBFv6Go_003D = _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzX8x2b1synnmh, _0023_003DzuiKPngFDQW1J, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)0)._0023_003DzNBFv6Go_003D;
							for (int j = 0; j < _0023_003DzNBFv6Go_003D.Count; j++)
							{
								for (int k = 0; k < _0023_003DzNBFv6Go_003D.Count; k++)
								{
									if (j != k && _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(_0023_003DzNBFv6Go_003D[k], _0023_003DzNBFv6Go_003D[j], (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)1)._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.Count > 0)
									{
										_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
										_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2._0023_003DzNBFv6Go_003D.Add(_0023_003DzNBFv6Go_003D[j]);
										list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D2);
										_0023_003DzNBFv6Go_003D.RemoveAt(j);
										j--;
										break;
									}
								}
							}
							_0023_003DzX8x2b1synnmh = (list3[i] = _0023_003DzNBFv6Go_003D[0]);
							if (_0023_003DzNBFv6Go_003D.Count > 1)
							{
								list3[num] = _0023_003DzNBFv6Go_003D[1];
								for (int l = 2; l < _0023_003DzNBFv6Go_003D.Count; l++)
								{
									list3.Add(_0023_003DzNBFv6Go_003D[l]);
								}
							}
							else
							{
								if (i > num)
								{
									i--;
								}
								list3.RemoveAt(num);
							}
						}
					}
				}
			}
			Dictionary<int, int> _0023_003Dz3uafwEHGtXFIG2gC_0024A_003D_003D = new Dictionary<int, int>();
			for (int m = 0; m < list2.Count; m++)
			{
				bool _0023_003Dzxh9_ujyaVFe;
				List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> collection = _0023_003DzWTIaXM1nmMBVPSjxKQ_003D_003D(list2, m, list3, new Dictionary<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D, bool>(), _0023_003Dz3uafwEHGtXFIG2gC_0024A_003D_003D, out _0023_003Dzxh9_ujyaVFe);
				if (_0023_003Dzxh9_ujyaVFe)
				{
					m--;
				}
				else
				{
					_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3 = new _0023_003DzpBYltGcoQ_wc84r8lw_003D_003D();
					_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D.AddRange(collection);
					_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3._0023_003DzNBFv6Go_003D.Add(list2[m]);
					list.Add(_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D3);
				}
			}
			return list;
		}, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, null);
	}

	private static void _0023_003DzRtV9ofrD1_YpiuR4sA_003D_003D(Entity _0023_003Dz9j7EUB0_003D)
	{
		if (_0023_003Dz9j7EUB0_003D is Region region)
		{
			for (int i = 1; i < region.ContourList.Count; i++)
			{
				region.ContourList[i].Reverse();
			}
		}
	}

	private static void _0023_003DzRtV9ofrD1_YpiuR4sA_003D_003D(ICurve[] _0023_003DzTj1oJWREOpXS)
	{
		for (int i = 1; i < _0023_003DzTj1oJWREOpXS.Length; i++)
		{
			_0023_003DzTj1oJWREOpXS[i].Reverse();
		}
	}

	private static ICurve[] _0023_003DzJXAtzVj3Q7GwObg7srI969E_003D(ICurve[] _0023_003Dz2T4sy2I_003D, Transformation _0023_003DzfX4euWM_003D)
	{
		_0023_003DzaY_Y43Wls7kQynbyL1t9LF0_003D CS_0024_003C_003E8__locals2 = new _0023_003DzaY_Y43Wls7kQynbyL1t9LF0_003D();
		CS_0024_003C_003E8__locals2._0023_003DzfX4euWM_003D = _0023_003DzfX4euWM_003D;
		return _0023_003Dz2T4sy2I_003D.Select(delegate(ICurve _0023_003Dzt_m8zV0_003D)
		{
			ICurve obj = (ICurve)_0023_003Dzt_m8zV0_003D.Clone();
			((Entity)obj).TransformBy(CS_0024_003C_003E8__locals2._0023_003DzfX4euWM_003D);
			return obj;
		}).ToArray();
	}

	private static Region[] _0023_003DzZqdXOX_0024NoLQK(_0023_003Dzg9xoOGYOrztd _0023_003DznuAkcrU2bIzf, out ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, _0023_003DzTcLuDkQBH_0024fJ _0023_003DzZXZX5g2USjmU, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003DzR9RyDfqCRcpZ, out bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D)
	{
		_0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D CS_0024_003C_003E8__locals5 = new _0023_003DzC893JwZiqiuBif2_0024Ur9oYVc_003D();
		List<ICurve> list = new List<ICurve>();
		List<ICurve> list2 = new List<ICurve>();
		_0023_003DznuAkcrU2bIzf(out var _0023_003DznzaFsjg_003D, out var _0023_003Dz9gcA7tQ_003D, out CS_0024_003C_003E8__locals5._0023_003DzfX4euWM_003D, out var _);
		List<_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D> list3 = _0023_003DzZXZX5g2USjmU(_0023_003DznzaFsjg_003D[0], _0023_003Dz9gcA7tQ_003D[0], _0023_003DznzaFsjg_003D.Skip(1).ToArray(), _0023_003Dz9gcA7tQ_003D.Skip(1).ToArray(), out _0023_003DzzNA19d60VlSnNazKfA_003D_003D);
		List<Region> list4 = new List<Region>();
		foreach (_0023_003DzpBYltGcoQ_wc84r8lw_003D_003D item2 in list3)
		{
			ICurve[] array = _0023_003DzRGOg1mSsKvJGrLajgQ_003D_003D(item2._0023_003DzNBFv6Go_003D, _0023_003DzR9RyDfqCRcpZ);
			ICurve[] array2 = _0023_003DzRGOg1mSsKvJGrLajgQ_003D_003D(item2._0023_003DzslHCx6X9tvhJ5TFuSw_003D_003D, _0023_003DzR9RyDfqCRcpZ);
			int destinationIndex = array.Length;
			Array.Resize(ref array, array.Length + array2.Length);
			Array.Copy(array2, 0, array, destinationIndex, array2.Length);
			if (array.Length != 0)
			{
				if (_0023_003DzZXZX5g2USjmU == (_0023_003DzTcLuDkQBH_0024fJ)delegate(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz0TQuX2w_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzCM7y44E_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzBA0uIi0_003D, IList<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzeM_NgoQ_003D, out bool _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D)
				{
					List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list5 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(1 + _0023_003DzBA0uIi0_003D.Count);
					List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> list6 = new List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D>(1 + _0023_003DzeM_NgoQ_003D.Count);
					_0023_003Dz4PhBM2GEoXooEhbWDQ_003D_003D(list5, _0023_003Dz0TQuX2w_003D, _0023_003DzBA0uIi0_003D, _0023_003Dzbu8BV15Qqzan: true);
					_0023_003Dz4PhBM2GEoXooEhbWDQ_003D_003D(list6, _0023_003DzCM7y44E_003D, _0023_003DzeM_NgoQ_003D, _0023_003Dzbu8BV15Qqzan: false);
					return _0023_003DzvAVJCQIu9UY7mJKm6zdBnSw_003D._0023_003DzciezbBDiJBjaaOSnftb27LKLmj_Q(list5, list6, (_0023_003Dz5pxcFLVSAkKf7rJrYh0NeWI_003D)4, out _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D);
				})
				{
					Region[] collection = Utility.DetectRegionsFromContours(array, Plane.XY);
					list4.AddRange(collection);
				}
				else
				{
					Region item = new Region(array, Plane.XY);
					list4.Add(item);
				}
			}
		}
		CS_0024_003C_003E8__locals5._0023_003DzfX4euWM_003D.Invert();
		list.ForEach(CS_0024_003C_003E8__locals5._0023_003DzDTCX_gi_Zpvud3XsRUuEReo_003D);
		list2.ForEach(delegate(ICurve _0023_003DzbfrNXYE_003D)
		{
			((Entity)_0023_003DzbfrNXYE_003D).TransformBy(CS_0024_003C_003E8__locals5._0023_003DzfX4euWM_003D);
		});
		_0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D = list.ToArray();
		_0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D = list2.ToArray();
		list4.ForEach(CS_0024_003C_003E8__locals5._0023_003DzItrRd3jq7eMAHAwGrZ09Z5I_003D);
		return list4.ToArray();
	}

	private static Transformation _0023_003Dzr_l2K5gwh_0024bxuYxCig_003D_003D(IList<ICurve> _0023_003DzXpSQPCI_003D, IList<ICurve> _0023_003DzMH3yuIE_003D)
	{
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		foreach (ICurve item in _0023_003DzXpSQPCI_003D)
		{
			item.GetApproximatedBoundingBox(out var boxMin, out var boxMax);
			Utility.UpdateMinMaxQuick(boxMin, maxValue, minValue);
			Utility.UpdateMinMaxQuick(boxMax, maxValue, minValue);
		}
		Point3D maxValue2 = Point3D.MaxValue;
		Point3D minValue2 = Point3D.MinValue;
		foreach (ICurve item2 in _0023_003DzMH3yuIE_003D)
		{
			item2.GetApproximatedBoundingBox(out var boxMin2, out var boxMax2);
			Utility.UpdateMinMaxQuick(boxMin2, maxValue2, minValue2);
			Utility.UpdateMinMaxQuick(boxMax2, maxValue2, minValue2);
		}
		Point3D intersMin;
		Point3D intersMax;
		double diagonal = Utility.IntersectionBox(maxValue, minValue, maxValue2, minValue2, out intersMin, out intersMax).Diagonal;
		if (diagonal > Utility._0023_003DzheSR8QM7q9ya && diagonal < 10.0)
		{
			return new Scaling(10.0 / diagonal);
		}
		return new Identity();
	}

	private static Region[] _0023_003Dzy1P90ibGNi6olYlEqg_003D_003D(Region _0023_003Dz2T4sy2I_003D, Entity _0023_003DzO91j_0024fQ_003D, out ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, _0023_003DzTcLuDkQBH_0024fJ _0023_003DzZXZX5g2USjmU, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D)
	{
		_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D CS_0024_003C_003E8__locals9 = new _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D();
		CS_0024_003C_003E8__locals9._0023_003Dz2T4sy2I_003D = _0023_003Dz2T4sy2I_003D;
		CS_0024_003C_003E8__locals9._0023_003DzO91j_0024fQ_003D = _0023_003DzO91j_0024fQ_003D;
		CS_0024_003C_003E8__locals9._0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D = _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D;
		bool _0023_003DzzNA19d60VlSnNazKfA_003D_003D;
		return _0023_003DzZqdXOX_0024NoLQK(delegate(out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003DznzaFsjg_003D, out _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D[] _0023_003Dz9gcA7tQ_003D, out Transformation _0023_003Dz2HI4YY_0024WuJj9, out Plane _0023_003DzlqZnaxrmezyK)
		{
			_0023_003DzlqZnaxrmezyK = _0023_003Dz0Tgl96xVQO6jMMtG8WP0Vb0_003D(CS_0024_003C_003E8__locals9._0023_003Dz2T4sy2I_003D);
			_0023_003Dz2HI4YY_0024WuJj9 = new Align3D(_0023_003DzlqZnaxrmezyK, Plane.XY);
			Region obj = (Region)CS_0024_003C_003E8__locals9._0023_003Dz2T4sy2I_003D.Clone();
			Entity entity = (Entity)CS_0024_003C_003E8__locals9._0023_003DzO91j_0024fQ_003D.Clone();
			List<ICurve> contourList = obj.ContourList;
			List<ICurve> list = ((entity is Region) ? ((Region)entity).ContourList : new List<ICurve> { (ICurve)entity });
			_0023_003Dz2HI4YY_0024WuJj9 = _0023_003Dzr_l2K5gwh_0024bxuYxCig_003D_003D(contourList, list) * _0023_003Dz2HI4YY_0024WuJj9;
			obj.TransformBy(_0023_003Dz2HI4YY_0024WuJj9);
			entity.TransformBy(_0023_003Dz2HI4YY_0024WuJj9);
			_0023_003DzRtV9ofrD1_YpiuR4sA_003D_003D(obj);
			_0023_003DzRtV9ofrD1_YpiuR4sA_003D_003D(entity);
			_0023_003DznzaFsjg_003D = contourList.Select(CS_0024_003C_003E8__locals9._0023_003Dz6rNyCCmVHzHbpSDFTmJJZYE_003D).ToArray();
			_0023_003Dz9gcA7tQ_003D = list.Select((ICurve _0023_003DzdCP541Q_003D) => _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(_0023_003DzdCP541Q_003D, CS_0024_003C_003E8__locals9._0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D)).ToArray();
		}, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, _0023_003DzZXZX5g2USjmU, CS_0024_003C_003E8__locals9._0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D, out _0023_003DzzNA19d60VlSnNazKfA_003D_003D);
	}

	private static Region[] _0023_003DzlJtvZyYpPAuc(Region _0023_003Dz2T4sy2I_003D, ICurve[] _0023_003DzO91j_0024fQ_003D, out ICurve[] _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out ICurve[] _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, _0023_003DzTcLuDkQBH_0024fJ _0023_003DzZXZX5g2USjmU, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D, out bool _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D)
	{
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2 = new _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D();
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz2T4sy2I_003D = _0023_003Dz2T4sy2I_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzO91j_0024fQ_003D = _0023_003DzO91j_0024fQ_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D = _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D;
		return _0023_003DzZqdXOX_0024NoLQK(_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzf7FIIPF8ogN5bJbZLgaD5jI_003D, out _0023_003DzsVwjgTQ2k9M1lx2O0Q_003D_003D, out _0023_003DzDsud6tRm7lKkA2KUlo7EsOo_003D, _0023_003DzZXZX5g2USjmU, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D, out _0023_003DzNUpEGj_00245PWplySHUdxWuNio_003D);
	}

	private static ICurve[] _0023_003DzRGOg1mSsKvJGrLajgQ_003D_003D(List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003DzR9RyDfqCRcpZ)
	{
		List<ICurve> list = new List<ICurve>();
		List<ICurve> list2 = new List<ICurve>();
		foreach (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D item in _0023_003Dz0_y2MGuBseHDNXdEcQ_003D_003D)
		{
			ICurve[] array = _0023_003Dzz3C28ATMf0VAqtoQYg_003D_003D(item, _0023_003DzR9RyDfqCRcpZ, _0023_003Dzc8Rx2Vw_003D: false, _0023_003DzxdxYNptf_0024nYRA7IiQ70djeg_003D: true, _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D: false);
			if (item._0023_003Dz73g2ov8e6Mnc())
			{
				if (array != null && array.Length != 0)
				{
					list.Add(new CompositeCurve(array));
				}
			}
			else
			{
				list2.AddRange(array);
			}
		}
		if (list2.Count > 0)
		{
			list.AddRange(Utility.GetConnectedCurves(list2, 0.01));
		}
		return list.ToArray();
	}

	private static Plane _0023_003Dz0Tgl96xVQO6jMMtG8WP0Vb0_003D(Entity _0023_003DzbfrNXYE_003D)
	{
		if (_0023_003DzbfrNXYE_003D is ICurve curve)
		{
			if (curve.IsPlanar(0.1, out var plane))
			{
				return plane;
			}
		}
		else
		{
			if (_0023_003DzbfrNXYE_003D is Region region)
			{
				return region.Plane;
			}
			if (_0023_003DzbfrNXYE_003D == null)
			{
				return null;
			}
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942110));
	}

	internal static _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(ICurve _0023_003Dzs_0024uS8LA_003D, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D)
	{
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = null;
		if (_0023_003Dzs_0024uS8LA_003D is Arc _0023_003DzN4MDZ_0024c_003D)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzmWuilg94iymX48oilA_003D_003D(_0023_003DzN4MDZ_0024c_003D);
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Circle _0023_003Dzt_m8zV0_003D)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzRp9mtFmkU6NbhuVm59eXtWs_003D(_0023_003Dzt_m8zV0_003D);
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Line _0023_003DzGcl_0024E9o_003D)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzU4ljaYzv53xqttygBg_003D_003D(_0023_003DzGcl_0024E9o_003D);
		}
		else if (_0023_003Dzs_0024uS8LA_003D is LinearPath _0023_003DzHPC6WX8_003D)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003Dzx7YXEKRqvsTslZjiUOa95YQ_003D(_0023_003DzHPC6WX8_003D);
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Curve _0023_003DzzmfUkNI_003D)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzbM8F2vpl7Hqr_002488JpEkPUsQ_003D(_0023_003DzzmfUkNI_003D, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
		}
		else if (_0023_003Dzs_0024uS8LA_003D is EllipticalArc _0023_003DzzmfUkNI_003D2)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzbM8F2vpl7Hqr_002488JpEkPUsQ_003D(_0023_003DzzmfUkNI_003D2, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Ellipse _0023_003DzzmfUkNI_003D3)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzbM8F2vpl7Hqr_002488JpEkPUsQ_003D(_0023_003DzzmfUkNI_003D3, _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
		}
		else
		{
			if (!(_0023_003Dzs_0024uS8LA_003D is CompositeCurve compositeCurve))
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941818));
			}
			List<ICurve> list = compositeCurve.CurveList.Where((ICurve _0023_003DzBJFJHwk_003D) => !(_0023_003DzBJFJHwk_003D is Point) && !_0023_003DzBJFJHwk_003D.IsPoint).ToList();
			if (list.Count == 1)
			{
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(list[0], _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
			}
			else
			{
				_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D[][] array = new _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D[list.Count][];
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3 = null;
				for (int num = 0; num < list.Count; num++)
				{
					_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3 = _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D(list[num], _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D);
					array[num] = new _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D[_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count - 1];
					for (int num2 = 0; num2 < array[num].Length; num2++)
					{
						array[num][num2] = _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[num2];
						array[num][num2]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[num2 + 1]._0023_003DzM6vr2rcGU7dfzP8eVg_003D_003D());
					}
					if (list[num] is PlanarEntity planarEntity)
					{
						_ = planarEntity.Plane;
					}
				}
				_ = array.LongLength;
				bool flag = Math.Abs(array[0][0]._0023_003DzR216mFc_003D() - _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count - 1]._0023_003DzR216mFc_003D()) <= Utility._0023_003DzxhnLabVjXjPg && Math.Abs(array[0][0]._0023_003DzqJqZpJk_003D() - _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count - 1]._0023_003DzqJqZpJk_003D()) <= Utility._0023_003DzxhnLabVjXjPg;
				List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> list2 = new List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D>(array.Length * 2);
				for (int num3 = 0; num3 < array.Length; num3++)
				{
					list2.AddRange(array[num3]);
				}
				if (!flag)
				{
					list2.Add(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count - 1]);
				}
				else
				{
					int index = list2.Count - 1;
					if (_0023_003DzcQiRB3Mv_00246WF._0023_003Dzgr6OWgJnCIU5(list2[0]._0023_003DzIIL2q6XkW9OP(), list2[index]._0023_003DzIIL2q6XkW9OP(), _0023_003Dz4bQB7f9e8mCtX_ivosmY4ynvt_I_0024VHY6ew_003D_003D._0023_003Dzia9b_Y_HjeB9))
					{
						list2.RemoveAt(index);
					}
				}
				_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D(flag, list2);
				for (int num4 = 1; num4 < _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count; num4++)
				{
					_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[num4]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[num4 - 1]._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D());
				}
				if (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz73g2ov8e6Mnc())
				{
					_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count - 1]._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D());
				}
			}
		}
		return _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2;
	}

	private static _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dzx7YXEKRqvsTslZjiUOa95YQ_003D(LinearPath _0023_003DzHPC6WX8_003D)
	{
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D();
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003DzsMdAaCgjZnbt(_0023_003DzHPC6WX8_003D.IsClosed);
		int num = (_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz73g2ov8e6Mnc() ? (_0023_003DzHPC6WX8_003D.Vertices.Length - 1) : _0023_003DzHPC6WX8_003D.Vertices.Length);
		for (int i = 0; i < num; i++)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003DzXWeKxuA_003D(_0023_003DzHPC6WX8_003D.Vertices[i].X, _0023_003DzHPC6WX8_003D.Vertices[i].Y, 0.0, null, _0023_003Dz9NRsIJI_003D: false, null, null);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[i]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzHPC6WX8_003D);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[i]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzHPC6WX8_003D);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[i]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzHPC6WX8_003D);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[i]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzHPC6WX8_003D);
		}
		return _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2;
	}

	private static _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzU4ljaYzv53xqttygBg_003D_003D(Line _0023_003DzGcl_0024E9o_003D)
	{
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D obj = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D();
		obj._0023_003DzXWeKxuA_003D(_0023_003DzGcl_0024E9o_003D.StartPoint.X, _0023_003DzGcl_0024E9o_003D.StartPoint.Y, 0.0, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		obj._0023_003DzXWeKxuA_003D(_0023_003DzGcl_0024E9o_003D.EndPoint.X, _0023_003DzGcl_0024E9o_003D.EndPoint.Y, 0.0, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		obj._0023_003DzsMdAaCgjZnbt(_0023_003DzPzO_0024GUk_003D: false);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzGcl_0024E9o_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzGcl_0024E9o_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzGcl_0024E9o_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzGcl_0024E9o_003D);
		return obj;
	}

	private static _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzJa9ukfiKS165(Curve _0023_003DzzmfUkNI_003D)
	{
		_0023_003DzzmfUkNI_003D._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D();
		if (_0023_003DzzmfUkNI_003D.IsClosed)
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003DzXWeKxuA_003D(_0023_003DzzmfUkNI_003D.ControlPoints[0].Euclid.X, _0023_003DzzmfUkNI_003D.ControlPoints[0].Euclid.Y, 0.0, _0023_003DzzmfUkNI_003D, _0023_003Dz9NRsIJI_003D: false, null, null);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003DzsMdAaCgjZnbt(_0023_003DzzmfUkNI_003D.IsClosed);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzzmfUkNI_003D);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzzmfUkNI_003D);
		}
		else
		{
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003DzXWeKxuA_003D(_0023_003DzzmfUkNI_003D.ControlPoints[0].Euclid.X, _0023_003DzzmfUkNI_003D.ControlPoints[0].Euclid.Y, 0.0, _0023_003DzzmfUkNI_003D, _0023_003Dz9NRsIJI_003D: false, null, null);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003DzXWeKxuA_003D(_0023_003DzzmfUkNI_003D.ControlPoints.Last().Euclid.X, _0023_003DzzmfUkNI_003D.ControlPoints.Last().Euclid.Y, 0.0, null, _0023_003Dz9NRsIJI_003D: false, null, null);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003DzsMdAaCgjZnbt(_0023_003DzzmfUkNI_003D.IsClosed);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzzmfUkNI_003D);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzzmfUkNI_003D);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzzmfUkNI_003D);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzzmfUkNI_003D);
		}
		return _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2;
	}

	private static _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzRp9mtFmkU6NbhuVm59eXtWs_003D(Circle _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D obj = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D();
		double _0023_003Dzo9ajQUuoihC = ((!Vector3D.AreOpposite(_0023_003Dzt_m8zV0_003D.Plane.AxisZ, Vector3D.AxisZ)) ? 1 : (-1));
		Point3D point3D = _0023_003Dzt_m8zV0_003D.PointAt(_0023_003Dzt_m8zV0_003D.Domain.Mid);
		obj._0023_003DzXWeKxuA_003D(_0023_003Dzt_m8zV0_003D.StartPoint.X, _0023_003Dzt_m8zV0_003D.StartPoint.Y, _0023_003Dzo9ajQUuoihC, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		obj._0023_003DzXWeKxuA_003D(point3D.X, point3D.Y, _0023_003Dzo9ajQUuoihC, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		obj._0023_003DzsMdAaCgjZnbt(_0023_003DzPzO_0024GUk_003D: true);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003Dzt_m8zV0_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003Dzt_m8zV0_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003Dzt_m8zV0_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003Dzt_m8zV0_003D);
		return obj;
	}

	private static _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzmWuilg94iymX48oilA_003D_003D(Arc _0023_003DzN4MDZ_0024c_003D)
	{
		if (_0023_003DzN4MDZ_0024c_003D.AngleInRadians > Math.PI)
		{
			_0023_003DzN4MDZ_0024c_003D.SubCurve(_0023_003DzN4MDZ_0024c_003D.Domain.Min, _0023_003DzN4MDZ_0024c_003D.Domain.Mid, out var sub);
			_0023_003DzN4MDZ_0024c_003D.SubCurve(_0023_003DzN4MDZ_0024c_003D.Domain.Mid, _0023_003DzN4MDZ_0024c_003D.Domain.Max, out var sub2);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2 = _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D((Arc)sub, null);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3 = _0023_003DzdvC2Gt5s8nP7teFR5A_003D_003D((Arc)sub2, null);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D4 = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D();
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D4._0023_003DzXWeKxuA_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D2._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D4._0023_003DzXWeKxuA_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]);
			_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D4._0023_003DzXWeKxuA_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D3._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]);
			{
				foreach (_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D item in _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D4._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D())
				{
					item._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
					item._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
				}
				return _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D4;
			}
		}
		_0023_003DzcQiRB3Mv_00246WF _0023_003DzbUvT9Pc_003D = new _0023_003DzacTVonkOQhg3t0mLePYxRak_003D(_0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzljsymAf8o3ZuZQoUDg_003D_003D(_0023_003DzN4MDZ_0024c_003D.Center.AsVector))._0023_003DzbUvT9Pc_003D;
		double num = Math.Abs(Math.Tan(_0023_003Dz4bQB7f9e8mCtX_ivosmY4ynvt_I_0024VHY6ew_003D_003D._0023_003DzFINJ6s3Z_0024n8G(_0023_003Dzsn5xe1wHVZz8._0023_003Dz6pajdGM_003D(_0023_003DzbUvT9Pc_003D, _0023_003DzljsymAf8o3ZuZQoUDg_003D_003D(_0023_003DzN4MDZ_0024c_003D.EndPoint.AsVector)), _0023_003Dzsn5xe1wHVZz8._0023_003Dz6pajdGM_003D(_0023_003DzbUvT9Pc_003D, _0023_003DzljsymAf8o3ZuZQoUDg_003D_003D(_0023_003DzN4MDZ_0024c_003D.StartPoint.AsVector))) / 4.0));
		if (num < 1E-05)
		{
			num = 0.0;
		}
		else if (Vector3D.AreOpposite(_0023_003DzN4MDZ_0024c_003D.Plane.AxisZ, Plane.XY.AxisZ))
		{
			num *= -1.0;
		}
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D obj = new _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D();
		obj._0023_003DzXWeKxuA_003D(_0023_003DzN4MDZ_0024c_003D.StartPoint.X, _0023_003DzN4MDZ_0024c_003D.StartPoint.Y, num, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		obj._0023_003DzXWeKxuA_003D(_0023_003DzN4MDZ_0024c_003D.EndPoint.X, _0023_003DzN4MDZ_0024c_003D.EndPoint.Y, 0.0, null, _0023_003Dz9NRsIJI_003D: false, null, null);
		obj._0023_003DzsMdAaCgjZnbt(_0023_003DzPzO_0024GUk_003D: false);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
		obj._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[1]._0023_003Dzwhgm_3LZg36QKEzbSw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
		return obj;
	}

	private static _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzbM8F2vpl7Hqr_002488JpEkPUsQ_003D(ICurve _0023_003DzzmfUkNI_003D, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003Dz_0024PajAqDXN8ONV4FMaQ_003D_003D)
	{
		return _0023_003DzJa9ukfiKS165(_0023_003DzzmfUkNI_003D.GetNurbsForm());
	}

	internal static Point3D _0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(object _0023_003Dz77g161c_003D)
	{
		if (_0023_003Dz77g161c_003D is _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2)
		{
			return new Point3D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzR216mFc_003D(), _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzqJqZpJk_003D());
		}
		if (_0023_003Dz77g161c_003D is _0023_003DzcQiRB3Mv_00246WF _0023_003DzcQiRB3Mv_00246WF2)
		{
			return new Point3D(_0023_003DzcQiRB3Mv_00246WF2._0023_003DzR216mFc_003D(), _0023_003DzcQiRB3Mv_00246WF2._0023_003DzqJqZpJk_003D());
		}
		return null;
	}

	internal static _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003Dzl4NivtMMZsnU8_tBSQ_003D_003D(Point3D _0023_003Dz77g161c_003D, double _0023_003Dzo9ajQUuoihC2)
	{
		return new _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D(_0023_003Dz77g161c_003D.X, _0023_003Dz77g161c_003D.Y, _0023_003Dzo9ajQUuoihC2);
	}

	internal static _0023_003DzcQiRB3Mv_00246WF _0023_003DzljsymAf8o3ZuZQoUDg_003D_003D(Vector3D _0023_003Dz77g161c_003D)
	{
		return new _0023_003DzcQiRB3Mv_00246WF(_0023_003Dz77g161c_003D.X, _0023_003Dz77g161c_003D.Y);
	}

	internal static ICurve[] _0023_003Dzz3C28ATMf0VAqtoQYg_003D_003D(_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzRStSB1rsoNKYaya4kg_003D_003D, Dictionary<int, _0023_003DziteIHo6WGnf7l0LAadTNIaVU72803fuRLGDZT9cSkmdZ> _0023_003DzR9RyDfqCRcpZ, bool _0023_003Dzc8Rx2Vw_003D, bool _0023_003DzxdxYNptf_0024nYRA7IiQ70djeg_003D, bool _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D)
	{
		List<ICurve> list = new List<ICurve>();
		double _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D = 0.0;
		double _0023_003DzMCmqPM4nfp8i = 0.0;
		if (_0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count == 0 || (_0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count == 1 && _0023_003DzRStSB1rsoNKYaya4kg_003D_003D[0]._0023_003DzE653m9eTRcRN() == null))
		{
			return null;
		}
		double num = 1E-10;
		Entity _0023_003DzgIP_K_6f363i = null;
		_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2 = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0];
		_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3 = null;
		for (int i = 1; i < _0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count; i++)
		{
			_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3 = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[i];
			double num2 = Point3D.DistanceSquared(_0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2), _0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3));
			if (num2 < num)
			{
				_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D());
				_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003Dz8HyFb6YKNSgq(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3._0023_003DzE653m9eTRcRN());
			}
			else if (num2 < 1E-08 && _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzcWf0kr6NGk3H() == 0 && _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D() is TrimCurve && _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzM6vr2rcGU7dfzP8eVg_003D_003D() == _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3._0023_003DzM6vr2rcGU7dfzP8eVg_003D_003D())
			{
				_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzwVZUlRKG3ATAUzmrpw_003D_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D());
			}
			else
			{
				_0023_003DzezQIzQPEWazmqML1GA_003D_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3, list, ref _0023_003DzgIP_K_6f363i, _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D, ref _0023_003DzMCmqPM4nfp8i, _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D, _0023_003DzR9RyDfqCRcpZ != null, _0023_003Dzc8Rx2Vw_003D);
				_0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D = _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003Dz9YAI8AkJqBvo();
				_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2 = _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3;
			}
		}
		if (_0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz73g2ov8e6Mnc())
		{
			_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2 = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[_0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D().Count - 1];
			_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3 = _0023_003DzRStSB1rsoNKYaya4kg_003D_003D._0023_003Dz36_0024eCzTYCSBOyS3ZkA_003D_003D()[0];
			if (Point3D.DistanceSquared(_0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2), _0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3)) >= num || _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2._0023_003DzcWf0kr6NGk3H() == 2)
			{
				_0023_003DzezQIzQPEWazmqML1GA_003D_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D2, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D3, list, ref _0023_003DzgIP_K_6f363i, _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D, ref _0023_003DzMCmqPM4nfp8i, _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D, _0023_003DzR9RyDfqCRcpZ != null, _0023_003Dzc8Rx2Vw_003D);
				ICurve _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D = ((_0023_003DzgIP_K_6f363i == null || _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D() == null) ? null : _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D().Item1);
				list._0023_003Dz_0024XNRUoU_003D((ICurve)_0023_003DzgIP_K_6f363i, _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D, _0023_003Dzc8Rx2Vw_003D);
			}
			else if (list.Count == 0)
			{
				if (_0023_003DzgIP_K_6f363i == null)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941792));
				}
				ICurve _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D2 = ((_0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D() == null) ? null : _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D().Item1);
				list._0023_003Dz_0024XNRUoU_003D((ICurve)_0023_003DzgIP_K_6f363i, _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D2, _0023_003Dzc8Rx2Vw_003D);
			}
		}
		else if (_0023_003DzgIP_K_6f363i != null)
		{
			ICurve _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D3 = ((_0023_003DzgIP_K_6f363i == null || _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D() == null) ? null : _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D().Item1);
			list._0023_003Dz_0024XNRUoU_003D((ICurve)_0023_003DzgIP_K_6f363i, _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D3, _0023_003Dzc8Rx2Vw_003D);
		}
		List<ICurve> list2 = list.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzedyPmkEnkFnNMvrD0ibZfTG0qi5l).ToList();
		ICurve[] array = new ICurve[0];
		if (list2.Count > 0)
		{
			if (list2.Count == 2)
			{
				ICurve curve = ((Entity)list2[0])._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D()?.Item1;
				ICurve curve2 = ((Entity)list2[1])._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D()?.Item1;
				if (curve != null && curve == curve2)
				{
					list2.Clear();
					ICurve curve3 = (ICurve)curve2.Clone();
					if (curve3 is TrimCurve)
					{
						curve3.EdgeIndex = curve.EdgeIndex;
						curve3.FromBooleanIntersection = curve.FromBooleanIntersection;
					}
					list2.Add(curve3);
				}
				else
				{
					curve = ((Entity)list2[0]).EntityData as ICurve;
					curve2 = ((Entity)list2[1]).EntityData as ICurve;
					if (curve != null && curve == curve2 && curve is LinearPath)
					{
						list2.Clear();
						ICurve item = (ICurve)curve2.Clone();
						list2.Add(item);
					}
				}
			}
			array = new ICurve[list2.Count];
			for (int j = 0; j < list2.Count; j++)
			{
				array[j] = list2[j];
				if (!(((Entity)array[j]).EntityData is string text) || !(text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743)))
				{
					((Entity)array[j]).EntityData = null;
				}
			}
		}
		return array;
	}

	private static void _0023_003Dz_0024XNRUoU_003D(this List<ICurve> _0023_003DzyIjeB1Bf2138, ICurve _0023_003DzgIP_K_6f363i, ICurve _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D, bool _0023_003Dzc8Rx2Vw_003D)
	{
		if (!_0023_003Dzc8Rx2Vw_003D && _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D is TrimCurve && _0023_003DzgIP_K_6f363i is Line line)
		{
			ICurve edge = ((TrimCurve)_0023_003DzjxpIiljMd3XbGov3Sg_003D_003D).Edge;
			TrimCurve trimCurve = line.GetNurbsForm()._0023_003DzmGgqdRaHiXdg((ICurve)edge.Clone());
			trimCurve.EdgeIndex = _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D.EdgeIndex;
			trimCurve.FromBooleanIntersection = _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D.FromBooleanIntersection;
			trimCurve.EntityData = _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D;
			_0023_003DzyIjeB1Bf2138.Add(trimCurve);
		}
		else if (!_0023_003Dzc8Rx2Vw_003D && _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D != null && _0023_003DzgIP_K_6f363i.GetType() != _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D.GetType() && _0023_003DzgIP_K_6f363i.GetType() != typeof(Arc))
		{
			ICurve sub = null;
			if (_0023_003DzjxpIiljMd3XbGov3Sg_003D_003D.GetType() == typeof(LinearPath))
			{
				sub = new LinearPath(_0023_003DzgIP_K_6f363i.StartPoint, _0023_003DzgIP_K_6f363i.EndPoint);
			}
			else if (!_0023_003DzjxpIiljMd3XbGov3Sg_003D_003D.SubCurve(_0023_003DzgIP_K_6f363i.StartPoint, _0023_003DzgIP_K_6f363i.EndPoint, out sub))
			{
				if (!_0023_003DzjxpIiljMd3XbGov3Sg_003D_003D.SubCurve(_0023_003DzgIP_K_6f363i.EndPoint, _0023_003DzgIP_K_6f363i.StartPoint, out sub))
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941728));
				}
				sub.Reverse();
			}
			if (sub == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941930));
			}
			((Entity)sub).EntityData = _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D;
			_0023_003DzyIjeB1Bf2138.Add(sub);
		}
		else
		{
			Entity entity = (Entity)_0023_003DzgIP_K_6f363i;
			if (entity.EntityData as string == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743))
			{
				entity.EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743);
			}
			else
			{
				entity.EntityData = _0023_003DzjxpIiljMd3XbGov3Sg_003D_003D;
			}
			_0023_003DzyIjeB1Bf2138.Add(_0023_003DzgIP_K_6f363i);
		}
	}

	private static void _0023_003DzezQIzQPEWazmqML1GA_003D_003D(_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzVM927CxqZF6h, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003Dz9BIUkGZ4F0aQ, List<ICurve> _0023_003DzyIjeB1Bf2138, ref Entity _0023_003DzgIP_K_6f363i, double _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D, ref double _0023_003DzMCmqPM4nfp8i, bool _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D, bool _0023_003DzO5agqV0_003D, bool _0023_003Dzc8Rx2Vw_003D)
	{
		if (_0023_003DzgIP_K_6f363i != null && _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D() != null)
		{
			_0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D();
		}
		if (_0023_003DznjSYcNZ8QQsi(_0023_003DzyIjeB1Bf2138, _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D, ref _0023_003DzgIP_K_6f363i, _0023_003Dzc8Rx2Vw_003D, _0023_003DzVM927CxqZF6h, _0023_003Dz9BIUkGZ4F0aQ, _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D, ref _0023_003DzMCmqPM4nfp8i, out var _0023_003DzjepEGXc_003D, out var _0023_003DzE8QrneA_003D, out var _0023_003DzH9VU2k0_003D, out var _0023_003DzV7f9D2MyPvLe))
		{
			if (_0023_003DzVM927CxqZF6h._0023_003DzE653m9eTRcRN() != null)
			{
				_0023_003DzgIP_K_6f363i = _0023_003DzSdmAO_0024eHoFihHEKyrPUx_y0_003D(ref _0023_003DzgIP_K_6f363i, _0023_003DzE8QrneA_003D, _0023_003DzH9VU2k0_003D, _0023_003DzVM927CxqZF6h, _0023_003Dz9BIUkGZ4F0aQ, _0023_003DzjepEGXc_003D, _0023_003DzO5agqV0_003D, _0023_003DzyIjeB1Bf2138);
			}
			else
			{
				_0023_003DzgIP_K_6f363i = _0023_003DzzOFLJHss74e8818yRhVdJcU_003D(ref _0023_003DzgIP_K_6f363i, _0023_003DzE8QrneA_003D, _0023_003DzH9VU2k0_003D, _0023_003DzVM927CxqZF6h, _0023_003Dz9BIUkGZ4F0aQ, _0023_003DzjepEGXc_003D, _0023_003DzO5agqV0_003D, _0023_003Dzc8Rx2Vw_003D);
			}
		}
		else
		{
			_0023_003DzgIP_K_6f363i = _0023_003Dzx1CwPLYbqcTM_xzLxLZqsuw_003D(_0023_003DzgIP_K_6f363i as Arc, _0023_003DzE8QrneA_003D, _0023_003DzH9VU2k0_003D, _0023_003DzV7f9D2MyPvLe, _0023_003DzjepEGXc_003D, _0023_003DzO5agqV0_003D, _0023_003DzVM927CxqZF6h._0023_003Dz9YAI8AkJqBvo(), _0023_003DzVM927CxqZF6h._0023_003Dz_GDjFAu_0024umcGdgvfxA_003D_003D(), _0023_003DzVM927CxqZF6h, _0023_003Dz9BIUkGZ4F0aQ, _0023_003Dzc8Rx2Vw_003D);
		}
	}

	private static void _0023_003Dz_0024G8bcyGBwq_1(ICurve _0023_003DznUQhNjH2yai6, ICurve _0023_003Dz9d_3yYQ_003D, ICurve _0023_003DzEUkR9fk_003D, bool _0023_003DzO5agqV0_003D, bool _0023_003Dzc8Rx2Vw_003D)
	{
		if (_0023_003Dzc8Rx2Vw_003D || _0023_003Dz9d_3yYQ_003D == null || _0023_003DzEUkR9fk_003D == null)
		{
			if (_0023_003Dz9d_3yYQ_003D != null)
			{
				((Entity)_0023_003DznUQhNjH2yai6)._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D((_0023_003DznUQhNjH2yai6 == _0023_003Dz9d_3yYQ_003D) ? null : new Tuple<ICurve, bool>(_0023_003Dz9d_3yYQ_003D, item2: false));
			}
			else if (_0023_003DzEUkR9fk_003D != null)
			{
				((Entity)_0023_003DznUQhNjH2yai6)._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D((_0023_003DznUQhNjH2yai6 == _0023_003Dz9d_3yYQ_003D) ? null : new Tuple<ICurve, bool>(_0023_003DzEUkR9fk_003D, item2: false));
			}
			return;
		}
		if (_0023_003DzO5agqV0_003D)
		{
			((Entity)_0023_003DznUQhNjH2yai6)._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D((_0023_003DznUQhNjH2yai6 == _0023_003Dz9d_3yYQ_003D) ? null : new Tuple<ICurve, bool>(_0023_003Dz9d_3yYQ_003D, item2: false));
			return;
		}
		double num = _0023_003DznUQhNjH2yai6.Domain.Length * 0.001;
		Point3D[] array = new Point3D[3];
		Vector3D[] array2 = new Vector3D[3];
		double mid = _0023_003DznUQhNjH2yai6.Domain.Mid;
		if (_0023_003DznUQhNjH2yai6 is Curve curve)
		{
			curve.EvaluateTangent(mid, out array[0], out array2[0]);
			curve.EvaluateTangent(mid - num, out array[1], out array2[1]);
			curve.EvaluateTangent(mid + num, out array[2], out array2[2]);
		}
		else
		{
			array[0] = _0023_003DznUQhNjH2yai6.PointAt(mid);
			array[1] = _0023_003DznUQhNjH2yai6.PointAt(mid - num);
			array[2] = _0023_003DznUQhNjH2yai6.PointAt(mid + num);
			array2[0] = _0023_003DznUQhNjH2yai6.TangentAt(mid);
			array2[1] = _0023_003DznUQhNjH2yai6.TangentAt(mid - num);
			array2[2] = _0023_003DznUQhNjH2yai6.TangentAt(mid + num);
		}
		double[] array3 = Enumerable.Repeat(double.NaN, 3).ToArray();
		double[] array4 = Enumerable.Repeat(double.NaN, 3).ToArray();
		_0023_003Dz9d_3yYQ_003D.Project(array[0], out array3[0]);
		_0023_003DzEUkR9fk_003D.Project(array[0], out array4[0]);
		if (!_0023_003Dz9d_3yYQ_003D.Domain.Includes(array3[0], 1E-08))
		{
			bool item = _0023_003DzV047uwYQJTN2kP1eIA_003D_003D(_0023_003DzEUkR9fk_003D, array, array2, array4);
			((Entity)_0023_003DznUQhNjH2yai6)._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D((_0023_003DznUQhNjH2yai6 == _0023_003DzEUkR9fk_003D) ? null : new Tuple<ICurve, bool>(_0023_003DzEUkR9fk_003D, item));
			return;
		}
		if (!_0023_003DzEUkR9fk_003D.Domain.Includes(array4[0], 1E-08))
		{
			bool item = _0023_003DzV047uwYQJTN2kP1eIA_003D_003D(_0023_003Dz9d_3yYQ_003D, array, array2, array3);
			((Entity)_0023_003DznUQhNjH2yai6)._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D((_0023_003DznUQhNjH2yai6 == _0023_003Dz9d_3yYQ_003D) ? null : new Tuple<ICurve, bool>(_0023_003Dz9d_3yYQ_003D, item));
			return;
		}
		double num2 = Point3D.DistanceSquared(_0023_003Dz9d_3yYQ_003D.PointAt(array3[0]), array[0]);
		double num3 = Point3D.DistanceSquared(_0023_003DzEUkR9fk_003D.PointAt(array4[0]), array[0]);
		if (num2 <= num3 || Math.Abs(num2 - num3) < 1E-08)
		{
			bool item = _0023_003DzV047uwYQJTN2kP1eIA_003D_003D(_0023_003Dz9d_3yYQ_003D, array, array2, array3);
			((Entity)_0023_003DznUQhNjH2yai6)._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D((_0023_003DznUQhNjH2yai6 == _0023_003Dz9d_3yYQ_003D) ? null : new Tuple<ICurve, bool>(_0023_003Dz9d_3yYQ_003D, item));
		}
		else
		{
			bool item = _0023_003DzV047uwYQJTN2kP1eIA_003D_003D(_0023_003DzEUkR9fk_003D, array, array2, array4);
			((Entity)_0023_003DznUQhNjH2yai6)._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D((_0023_003DznUQhNjH2yai6 == _0023_003DzEUkR9fk_003D) ? null : new Tuple<ICurve, bool>(_0023_003DzEUkR9fk_003D, item));
		}
	}

	private static bool _0023_003DzV047uwYQJTN2kP1eIA_003D_003D(ICurve _0023_003DzEUkR9fk_003D, Point3D[] _0023_003Dzn_3hPUVaUJEE, Vector3D[] _0023_003DzNQVFly7qtcwh, double[] _0023_003DzoUqOM9M_003D)
	{
		int num = 0;
		for (int i = 0; i < _0023_003Dzn_3hPUVaUJEE.Length; i++)
		{
			if (_0023_003Dz7mFTssbrKNhz_0024hvhXg_003D_003D(_0023_003DzEUkR9fk_003D, _0023_003Dzn_3hPUVaUJEE[i], _0023_003DzNQVFly7qtcwh[i], ref _0023_003DzoUqOM9M_003D[i]))
			{
				num++;
			}
		}
		return num > _0023_003Dzn_3hPUVaUJEE.Length / 2;
	}

	private static bool _0023_003Dz7mFTssbrKNhz_0024hvhXg_003D_003D(ICurve _0023_003DzMW_0024k_Ek_003D, Point3D _0023_003DzlY77YgY_003D, Vector3D _0023_003Dzz7zVJqX8WjgyOAxMqA_003D_003D, ref double _0023_003DzNDQ_E88_003D)
	{
		if (double.IsNaN(_0023_003DzNDQ_E88_003D))
		{
			_0023_003DzMW_0024k_Ek_003D.Project(_0023_003DzlY77YgY_003D, out _0023_003DzNDQ_E88_003D);
		}
		return Vector3D.Dot(_0023_003DzMW_0024k_Ek_003D.TangentAt(_0023_003DzNDQ_E88_003D), _0023_003Dzz7zVJqX8WjgyOAxMqA_003D_003D) < 0.0;
	}

	private static bool _0023_003DznjSYcNZ8QQsi(List<ICurve> _0023_003DzyIjeB1Bf2138, bool _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D, ref Entity _0023_003DzgIP_K_6f363i, bool _0023_003Dzc8Rx2Vw_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzVM927CxqZF6h, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003Dz9BIUkGZ4F0aQ, double _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D, ref double _0023_003DzMCmqPM4nfp8i, out bool _0023_003DzjepEGXc_003D, out Point3D _0023_003DzE8QrneA_003D, out Point3D _0023_003DzH9VU2k0_003D, out Point3D _0023_003DzV7f9D2MyPvLe)
	{
		_0023_003DzjepEGXc_003D = true;
		_0023_003DzE8QrneA_003D = _0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003DzVM927CxqZF6h);
		_0023_003DzH9VU2k0_003D = _0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003Dz9BIUkGZ4F0aQ);
		_0023_003DzV7f9D2MyPvLe = null;
		if (!_0023_003DzVM927CxqZF6h._0023_003DzHl7KN72_0024Z7oAUBvzVw_003D_003D())
		{
			_0023_003DzacTVonkOQhg3t0mLePYxRak_003D _0023_003DzacTVonkOQhg3t0mLePYxRak_003D2 = _0023_003DzuQp_0024TS7Rtgb0DN_iRkbiVpKqQs5B._0023_003DzSGGUqv0OJfVKPte3SQ_003D_003D(_0023_003DzVM927CxqZF6h, _0023_003Dz9BIUkGZ4F0aQ);
			_0023_003DzV7f9D2MyPvLe = _0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003DzacTVonkOQhg3t0mLePYxRak_003D2._0023_003DzbUvT9Pc_003D);
			if (_0023_003DzgIP_K_6f363i is Arc arc)
			{
				_0023_003DzjepEGXc_003D = Math.Abs(Point3D.DistanceSquared(arc.Center, _0023_003DzV7f9D2MyPvLe)) < Utility._0023_003DzheSR8QM7q9ya;
			}
			_0023_003DzjepEGXc_003D &= _0023_003DzgIP_K_6f363i is Arc && (Math.Abs(_0023_003DzMCmqPM4nfp8i - _0023_003DzacTVonkOQhg3t0mLePYxRak_003D2._0023_003DzEGKj_0024SNUUihi) < 1E-08 || _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D()?.Item1 == _0023_003DzVM927CxqZF6h._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D()) && Math.Sign(_0023_003DzVM927CxqZF6h._0023_003Dz9YAI8AkJqBvo()) == Math.Sign(_0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D);
			_0023_003DzMCmqPM4nfp8i = _0023_003DzacTVonkOQhg3t0mLePYxRak_003D2._0023_003DzEGKj_0024SNUUihi;
		}
		else
		{
			_0023_003DzMCmqPM4nfp8i = 0.0;
			_0023_003DzjepEGXc_003D &= _0023_003DzVM927CxqZF6h._0023_003DzE653m9eTRcRN() == null && _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D == _0023_003DzVM927CxqZF6h._0023_003Dz9YAI8AkJqBvo() && _0023_003DzrqcyZg9iQKWO_QRjHw_003D_003D == 0.0;
		}
		ICurve curve = ((_0023_003DzgIP_K_6f363i == null || _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D() == null) ? null : _0023_003DzgIP_K_6f363i._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D().Item1);
		_0023_003DzjepEGXc_003D &= (_0023_003DzgIP_K_6f363i != null && _0023_003DzgIP_K_6f363i is Arc && (curve == null || _0023_003Dzc8Rx2Vw_003D)) || (!_0023_003Dzc8Rx2Vw_003D && curve != null && curve == _0023_003DzVM927CxqZF6h._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D() && curve.EndPoint != _0023_003DzE8QrneA_003D);
		if (!_0023_003DzjepEGXc_003D && _0023_003DzgIP_K_6f363i != null)
		{
			_0023_003DzyIjeB1Bf2138._0023_003Dz_0024XNRUoU_003D((ICurve)_0023_003DzgIP_K_6f363i, curve, _0023_003Dzc8Rx2Vw_003D);
			_0023_003DzgIP_K_6f363i = null;
		}
		_0023_003DzjepEGXc_003D &= _0023_003DzgIP_K_6f363i != null;
		return _0023_003DzVM927CxqZF6h._0023_003DzHl7KN72_0024Z7oAUBvzVw_003D_003D() || _0023_003DzHUFlK5mpbaTJRVyA_0024Q_0024eAyI_003D;
	}

	private static Entity _0023_003Dzx1CwPLYbqcTM_xzLxLZqsuw_003D(Arc _0023_003Dzm9DavWVAxnjk, Point3D _0023_003DzAKYsX_Y_003D, Point3D _0023_003DzRiQFiu0_003D, Point3D _0023_003DzV7f9D2MyPvLe, bool _0023_003DzjepEGXc_003D, bool _0023_003DzO5agqV0_003D, double _0023_003Dzo9ajQUuoihC2, bool _0023_003DzD8Jpw_0024zrmdLYn2nQiQ_003D_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzsbMwqtw_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzIi4YDh4_003D, bool _0023_003Dzc8Rx2Vw_003D)
	{
		Entity entity = null;
		if (_0023_003DzjepEGXc_003D)
		{
			if (Point3D.DistanceSquared(_0023_003Dzm9DavWVAxnjk.StartPoint, _0023_003DzRiQFiu0_003D) < Utility._0023_003DzheSR8QM7q9ya)
			{
				if (_0023_003DzsbMwqtw_003D._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D() == null || _0023_003Dzc8Rx2Vw_003D)
				{
					Plane plane = (Plane)_0023_003Dzm9DavWVAxnjk.Plane.Clone();
					if (Math.Abs(_0023_003Dzm9DavWVAxnjk.Domain.Low) > Utility._0023_003DzheSR8QM7q9ya)
					{
						plane.Rotate(_0023_003Dzm9DavWVAxnjk.Domain.Low, _0023_003Dzm9DavWVAxnjk.Plane.AxisZ, _0023_003Dzm9DavWVAxnjk.Center);
					}
					entity = new Circle(plane, _0023_003Dzm9DavWVAxnjk.Center, _0023_003Dzm9DavWVAxnjk.Radius);
				}
				else
				{
					entity = (Entity)((Entity)_0023_003DzsbMwqtw_003D._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D()).Clone();
				}
			}
			else
			{
				entity = new Arc(_0023_003Dzm9DavWVAxnjk.StartPoint, _0023_003Dzm9DavWVAxnjk.EndPoint, _0023_003DzRiQFiu0_003D, flip: false);
			}
			entity._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D(_0023_003Dzm9DavWVAxnjk._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D());
			return entity;
		}
		List<Circle> list = new List<Circle>(2 + _0023_003DzsbMwqtw_003D._0023_003DzTLFnnT8cbMNJ__9ZQ86Ic_a0Clib.Count);
		List<Circle> list2 = new List<Circle>(2 + _0023_003DzIi4YDh4_003D._0023_003DzTLFnnT8cbMNJ__9ZQ86Ic_a0Clib.Count);
		_0023_003DzJn2c83iuGt5WnuBT0g_003D_003D(list, new object[2]
		{
			_0023_003DzsbMwqtw_003D._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D(),
			_0023_003DzsbMwqtw_003D._0023_003DzM6vr2rcGU7dfzP8eVg_003D_003D()
		});
		_0023_003DzJn2c83iuGt5WnuBT0g_003D_003D(list2, new object[2]
		{
			_0023_003DzIi4YDh4_003D._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D(),
			_0023_003DzIi4YDh4_003D._0023_003DzM6vr2rcGU7dfzP8eVg_003D_003D()
		});
		_0023_003DzJn2c83iuGt5WnuBT0g_003D_003D(list, _0023_003DzsbMwqtw_003D._0023_003DzTLFnnT8cbMNJ__9ZQ86Ic_a0Clib.Values);
		_0023_003DzJn2c83iuGt5WnuBT0g_003D_003D(list2, _0023_003DzIi4YDh4_003D._0023_003DzTLFnnT8cbMNJ__9ZQ86Ic_a0Clib.Values);
		List<Circle> list3 = new List<Circle>(list.Count * list2.Count);
		foreach (Circle item in list)
		{
			foreach (Circle item2 in list2)
			{
				if (item == item2)
				{
					list3.Add(item);
				}
			}
		}
		Arc arc = _0023_003DzwCDXMKbLhSUz_00245_0024YYV140TI_003D(_0023_003DzuQp_0024TS7Rtgb0DN_iRkbiVpKqQs5B._0023_003DzSGGUqv0OJfVKPte3SQ_003D_003D(_0023_003DzsbMwqtw_003D, _0023_003DzIi4YDh4_003D), _0023_003DzAKYsX_Y_003D, _0023_003DzRiQFiu0_003D, _0023_003DzsbMwqtw_003D);
		_0023_003Dz_0024G8bcyGBwq_1(arc, (ICurve)_0023_003DzsbMwqtw_003D._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D(), (ICurve)_0023_003DzsbMwqtw_003D._0023_003DzM6vr2rcGU7dfzP8eVg_003D_003D(), _0023_003DzO5agqV0_003D, _0023_003Dzc8Rx2Vw_003D);
		if (!_0023_003DzsbMwqtw_003D._0023_003DzzA5NpRLikjEF() && _0023_003Dzc8Rx2Vw_003D)
		{
			Tuple<ICurve, bool> tuple = arc._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D();
			if (tuple.Item1 != null && tuple.Item1 is Circle { Plane: var plane2 } circle)
			{
				Arc arc2 = new Arc(plane2, plane2.Project(arc.StartPoint), plane2.Project(arc.MidPoint), plane2.Project(arc.EndPoint), flip: false);
				arc2._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D(tuple);
				arc = arc2;
				Utility._0023_003Dz6kYhc4pAp6ud(arc);
				if (circle is Arc arc3)
				{
					double low = arc.Domain.Low;
					double high = arc.Domain.High;
					if (Utility.AreEqual(low, arc3.Domain.Low, Math.PI * 2.0))
					{
						low = circle.Domain.Low;
					}
					if (Utility.AreEqual(high, arc3.Domain.High, Math.PI * 2.0))
					{
						high = circle.Domain.High;
					}
					arc.Domain = new Interval(low, high);
				}
			}
		}
		return arc;
	}

	internal static Arc _0023_003DzwCDXMKbLhSUz_00245_0024YYV140TI_003D(_0023_003DzacTVonkOQhg3t0mLePYxRak_003D _0023_003Dz6SqRBY8_003D, Point3D _0023_003DzAKYsX_Y_003D, Point3D _0023_003DzRiQFiu0_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzsbMwqtw_003D)
	{
		Point3D point3D = _0023_003DzOAqAAbR1TmCAoCHbNm3BhKw_003D(_0023_003Dz6SqRBY8_003D._0023_003DzbUvT9Pc_003D);
		Plane plane = new Plane(point3D, _0023_003DzAKYsX_Y_003D, _0023_003DzRiQFiu0_003D);
		if (!plane.IsValid())
		{
			plane = (_0023_003DzsbMwqtw_003D._0023_003Dz_GDjFAu_0024umcGdgvfxA_003D_003D() ? Plane.XY : Plane.YX);
		}
		else if (_0023_003DzsbMwqtw_003D._0023_003Dz_GDjFAu_0024umcGdgvfxA_003D_003D())
		{
			if (plane.AxisZ.Z < 0.0)
			{
				plane.Flip();
			}
		}
		else if (plane.AxisZ.Z > 0.0)
		{
			plane.Flip();
		}
		Transformation xform = new Align3D(plane, Plane.XY);
		Point3D point3D2 = (Point3D)point3D.Clone();
		Point3D point3D3 = (Point3D)_0023_003DzAKYsX_Y_003D.Clone();
		Point3D point3D4 = (Point3D)_0023_003DzRiQFiu0_003D.Clone();
		point3D2.TransformBy(xform);
		point3D3.TransformBy(xform);
		point3D4.TransformBy(xform);
		Arc arc = new Arc(plane, point3D2, point3D3, point3D4);
		if (_0023_003DzsbMwqtw_003D._0023_003DzzA5NpRLikjEF())
		{
			arc.EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743);
		}
		return arc;
	}

	private static void _0023_003DzJn2c83iuGt5WnuBT0g_003D_003D(List<Circle> _0023_003DzHryErAY_003D, ICollection<object> _0023_003DzUpy8_Ws_003D)
	{
		foreach (object item2 in _0023_003DzUpy8_Ws_003D)
		{
			if (item2 is Circle item)
			{
				_0023_003DzHryErAY_003D.Add(item);
			}
		}
	}

	private static Entity _0023_003DzzOFLJHss74e8818yRhVdJcU_003D(ref Entity _0023_003DzNwMlg4sTZhDS, Point3D _0023_003DzAKYsX_Y_003D, Point3D _0023_003DzRiQFiu0_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzsbMwqtw_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzIi4YDh4_003D, bool _0023_003DzjepEGXc_003D, bool _0023_003DzO5agqV0_003D, bool _0023_003Dzc8Rx2Vw_003D)
	{
		if (_0023_003DzjepEGXc_003D)
		{
			if (_0023_003DzNwMlg4sTZhDS is Line line)
			{
				LinearPath linearPath = new LinearPath(line.StartPoint, line.EndPoint);
				linearPath._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D(_0023_003DzNwMlg4sTZhDS._0023_003DzFnbr4pmoDNFqmGXufZV4Jpc_003D());
				_0023_003DzNwMlg4sTZhDS = linearPath;
			}
			Point3D[] array = ((LinearPath)_0023_003DzNwMlg4sTZhDS).Vertices;
			Array.Resize(ref array, array.Length + 1);
			array[^1] = _0023_003DzRiQFiu0_003D;
			((LinearPath)_0023_003DzNwMlg4sTZhDS).Vertices = array;
			return _0023_003DzNwMlg4sTZhDS;
		}
		Line line2 = new Line(_0023_003DzAKYsX_Y_003D, _0023_003DzRiQFiu0_003D);
		_0023_003Dz_0024G8bcyGBwq_1(line2, (ICurve)_0023_003DzsbMwqtw_003D._0023_003DzZ3rr9nwvIMpn_0024Owhqg_003D_003D(), (ICurve)_0023_003DzsbMwqtw_003D._0023_003DzM6vr2rcGU7dfzP8eVg_003D_003D(), _0023_003DzO5agqV0_003D, _0023_003Dzc8Rx2Vw_003D);
		if (_0023_003DzsbMwqtw_003D._0023_003DzzA5NpRLikjEF())
		{
			line2.EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743);
		}
		return line2;
	}

	private static Entity _0023_003DzSdmAO_0024eHoFihHEKyrPUx_y0_003D(ref Entity _0023_003DzgIP_K_6f363i, Point3D _0023_003DzAKYsX_Y_003D, Point3D _0023_003DzRiQFiu0_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzsbMwqtw_003D, _0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D _0023_003DzIi4YDh4_003D, bool _0023_003DzjepEGXc_003D, bool _0023_003DzO5agqV0_003D, List<ICurve> _0023_003DzyIjeB1Bf2138)
	{
		if (_0023_003DzjepEGXc_003D)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941904));
		}
		Curve obj = (Curve)_0023_003DzsbMwqtw_003D._0023_003DzE653m9eTRcRN().Clone();
		Curve curve = (Curve)_0023_003DzsbMwqtw_003D._0023_003DzE653m9eTRcRN().Clone();
		curve._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D(null);
		obj._0023_003Dz9Yyot_0024Cnnz1iBXor_0024PoKeoQ_003D(new Tuple<ICurve, bool>(curve, item2: false));
		return obj;
	}

	internal static bool _0023_003DzfdnzkLyIzI5pb4XhobnPbfS_0024Y9CKa8mgkg_003D_003D(ICurve _0023_003DzEZ_0024X0WU_003D, Vector3D _0023_003Dz2ouPUQ9dmipO, double _0023_003Dzm0CYiiE_003D, bool? _0023_003Dz8lnTiVYSXWrE, Plane _0023_003Dzf0cOXUPO7ISoEDoJ_0024g_003D_003D, bool? _0023_003DzsAW3chlXydHJwZfRkdR06e4q_0024hhg)
	{
		Plane plane = null;
		bool flag;
		if (!_0023_003Dz8lnTiVYSXWrE.HasValue)
		{
			flag = _0023_003DzEZ_0024X0WU_003D.IsPlanar(_0023_003Dzm0CYiiE_003D, out plane);
		}
		else
		{
			if (_0023_003Dzf0cOXUPO7ISoEDoJ_0024g_003D_003D == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941845));
			}
			flag = _0023_003Dz8lnTiVYSXWrE.Value;
			plane = _0023_003Dzf0cOXUPO7ISoEDoJ_0024g_003D_003D;
		}
		if (!flag || _0023_003DzsAW3chlXydHJwZfRkdR06e4q_0024hhg == false)
		{
			return false;
		}
		if (_0023_003DzEZ_0024X0WU_003D is Circle circle)
		{
			if (_0023_003DzsAW3chlXydHJwZfRkdR06e4q_0024hhg != true)
			{
				return Vector3D.AreParallel(circle.Plane.AxisZ, _0023_003Dz2ouPUQ9dmipO, _0023_003Dzm0CYiiE_003D);
			}
			return true;
		}
		if (_0023_003DzEZ_0024X0WU_003D is CompositeCurve)
		{
			if (_0023_003DzsAW3chlXydHJwZfRkdR06e4q_0024hhg != true)
			{
				return Vector3D.AreParallel(plane.AxisZ, _0023_003Dz2ouPUQ9dmipO, _0023_003Dzm0CYiiE_003D);
			}
			return true;
		}
		if (_0023_003DzEZ_0024X0WU_003D is Line)
		{
			return true;
		}
		return false;
	}
}
