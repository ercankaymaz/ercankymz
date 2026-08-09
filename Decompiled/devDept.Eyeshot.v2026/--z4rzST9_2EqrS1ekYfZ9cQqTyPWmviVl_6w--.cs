using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003Dz4rzST9_2EqrS1ekYfZ9cQqTyPWmviVl_6w_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Segment3D, Line> _0023_003DzzXfVjLO8QehtBZRX_0024A_003D_003D;

		public static Func<Solid, Entity> _0023_003DziswhuOY90sa2r1Ll9w_003D_003D;

		public static Func<Region, Entity> _0023_003Dz7_WZ05dEvqdpEzItLA_003D_003D;

		public static Func<ICurve, Entity> _0023_003DzBtYz2bWpuyvI_0024WAcBg_003D_003D;

		public static Func<Point3D, Point> _0023_003DzUdr4O3AsaCYJAKzjhQ_003D_003D;

		public static Func<ICurve, Entity> _0023_003DzT0n0tuMhzBZxhJay7A_003D_003D;

		public static Func<Region, Entity> _0023_003DzW6VNWCUPEKb1Yg8DZQ_003D_003D;

		internal Line _0023_003DzX2ddHZ1AWWiZGWjTCU1GFNs_003D(Segment3D _0023_003DzFDJdA7A_003D)
		{
			return new Line(_0023_003DzFDJdA7A_003D.P0, _0023_003DzFDJdA7A_003D.P1);
		}

		internal Entity _0023_003DzB2Wqm0OxvlWWvdTTbtVWKcY_003D(Solid _0023_003Dz9Bu_NNI_003D)
		{
			return _0023_003Dz9Bu_NNI_003D;
		}

		internal Entity _0023_003DzAq9OBMvqTiqAP05rNTLaqwU_003D(Region _0023_003DzJUia4DY_003D)
		{
			return _0023_003DzJUia4DY_003D;
		}

		internal Entity _0023_003DzM08uhW4L5z__HHUTGyx8dco_0024F6i9XBbDmA_003D_003D(ICurve _0023_003Dz9Bu_NNI_003D)
		{
			return (Entity)_0023_003Dz9Bu_NNI_003D;
		}

		internal Point _0023_003DzfupOTX4YW1JP3jUMntbu_FQopg6Kjo3Jjw_003D_003D(Point3D _0023_003DzqoHxF0k_003D)
		{
			return new Point(_0023_003DzqoHxF0k_003D);
		}

		internal Entity _0023_003Dz5sY8uYCtfzWgC3wGqBSRUi8a9NvKfTJ13w_003D_003D(ICurve _0023_003Dz9Bu_NNI_003D)
		{
			return (Entity)_0023_003Dz9Bu_NNI_003D;
		}

		internal Entity _0023_003Dzu__0024HaVgvIQP8iZoS_k5GdbJ_0024ik1pypt7xA_003D_003D(Region _0023_003DzuwH5j5s_003D)
		{
			return _0023_003DzuwH5j5s_003D;
		}
	}

	private static bool _0023_003DzAZggff4kxugG(Solid _0023_003DzI8UlO9I_003D, Solid _0023_003DzgeexDaNfJK2F, bool _0023_003Dz459_0024dvasvvb3, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzqmF8XJ0_003D = string.Empty;
		if (_0023_003Dz459_0024dvasvvb3)
		{
			Segment3D[] array = Solid.IntersectionLoops(_0023_003DzI8UlO9I_003D, _0023_003DzgeexDaNfJK2F);
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = ((IEnumerable<Entity>)array?.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzX2ddHZ1AWWiZGWjTCU1GFNs_003D)).ToList();
			if (array != null)
			{
				return array.Length != 0;
			}
			return false;
		}
		Solid[] array2 = Solid.Intersection(_0023_003DzI8UlO9I_003D, _0023_003DzgeexDaNfJK2F);
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = array2?.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzB2Wqm0OxvlWWvdTTbtVWKcY_003D).ToList();
		if (array2 != null)
		{
			return array2.Length != 0;
		}
		return false;
	}

	private static bool _0023_003DzOSZN_0024Rdf7ywn(Brep _0023_003DzhO3dz9j4TBVd, Brep _0023_003DzYMSy51y_0024ooah, bool _0023_003Dz459_0024dvasvvb3, bool _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzqmF8XJ0_003D = string.Empty;
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		Point3D[] intersectionPoints = null;
		ICurve[] _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D = null;
		bool flag = Brep.Intersect(_0023_003DzhO3dz9j4TBVd, _0023_003DzYMSy51y_0024ooah, _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out intersectionPoints);
		if (_0023_003Dz459_0024dvasvvb3)
		{
			if (flag && intersectionPoints != null && intersectionPoints.Length != 0)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(intersectionPoints.Length);
				for (int i = 0; i < intersectionPoints.Length; i++)
				{
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Point(intersectionPoints[i]));
				}
			}
			return flag;
		}
		try
		{
			bool _0023_003DztLD2a19GFACn;
			Brep[] array = Brep._0023_003DzzDn32WHo_7Y_0024(_0023_003DzhO3dz9j4TBVd, _0023_003DzYMSy51y_0024ooah, (Brep._0023_003Dz4Hw_002424_0024xhqb8)1, out _0023_003DztLD2a19GFACn, out intersectionPoints, out _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D);
			if (array != null)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array);
				return _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0;
			}
		}
		catch
		{
		}
		flag = false;
		_0023_003DzqmF8XJ0_003D = _0023_003DzqmF8XJ0_003D + Environment.NewLine + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654023);
		if (_0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D != null && _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D.Length != 0)
		{
			ICurve[] array2 = _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D;
			for (int j = 0; j < array2.Length; j++)
			{
				ICurve[] individualCurves = array2[j].GetIndividualCurves();
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(individualCurves.Length);
				for (int k = 0; k < individualCurves.Length; k++)
				{
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add((Entity)individualCurves[k]);
				}
			}
		}
		else if (intersectionPoints != null && intersectionPoints.Length != 0)
		{
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(intersectionPoints.Length);
			for (int l = 0; l < intersectionPoints.Length; l++)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Point(intersectionPoints[l]));
			}
		}
		if (_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D != null && _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0)
		{
			_0023_003DzqmF8XJ0_003D = _0023_003DzqmF8XJ0_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953365) + ((_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D[0] is ICurve) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953086) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953348)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653960);
			flag = true;
		}
		else
		{
			_0023_003DzqmF8XJ0_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953020);
		}
		return flag;
	}

	private static bool _0023_003Dz_ddd7Ii6YWma(Surface _0023_003Dz2nJ01kNkPhJv, Surface _0023_003DzW1glaHBo58qN, bool _0023_003Dz459_0024dvasvvb3, bool _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzqmF8XJ0_003D = string.Empty;
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		if (!_0023_003Dz459_0024dvasvvb3)
		{
			_0023_003DzqmF8XJ0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654161);
		}
		return Surface.Intersect(new List<Surface> { _0023_003DzW1glaHBo58qN }, new List<Surface> { _0023_003Dz2nJ01kNkPhJv }, Math.Min(_0023_003Dz2nJ01kNkPhJv._0023_003DzVx1luJEZaaC7().Diagonal, _0023_003DzW1glaHBo58qN._0023_003DzVx1luJEZaaC7().Diagonal) / 1000.0, _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D);
	}

	private static bool _0023_003Dz8dyYcX3ZtQCc(Mesh _0023_003DzBlNmjoc_003D, Mesh _0023_003Dz948_aeQ_003D, bool _0023_003Dz459_0024dvasvvb3, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		_0023_003DzqmF8XJ0_003D = string.Empty;
		if (_0023_003DzBlNmjoc_003D.Triangles.Length == 0 || _0023_003DzBlNmjoc_003D.Vertices.Length == 0 || _0023_003Dz948_aeQ_003D.Triangles.Length == 0 || _0023_003Dz948_aeQ_003D.Vertices.Length == 0)
		{
			return false;
		}
		List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D = new List<Point3D>();
		bool result = ((!_0023_003DzBlNmjoc_003D.IsClosed && !_0023_003Dz948_aeQ_003D.IsClosed) ? Utility._0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(_0023_003DzBlNmjoc_003D.Vertices, _0023_003Dz948_aeQ_003D.Vertices, _0023_003DzBlNmjoc_003D.Triangles, _0023_003Dz948_aeQ_003D.Triangles, _0023_003Dz459_0024dvasvvb3, ref _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D) : Utility._0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(_0023_003DzBlNmjoc_003D, _0023_003Dz948_aeQ_003D, _0023_003Dz459_0024dvasvvb3, out _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D));
		if (_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Count > 0)
		{
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Count);
			for (int i = 0; i < _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Count; i++)
			{
				Entity item = new Point(_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D[i]);
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(item);
			}
		}
		return result;
	}

	private static bool _0023_003DzUMjcZmpBKT2_(ICurve _0023_003Dz8EhW_0024omtFk2M, Entity _0023_003Dz_0024ozI2Ww_003D, bool _0023_003Dz459_0024dvasvvb3, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzqmF8XJ0_003D = string.Empty;
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		if (_0023_003Dz_0024ozI2Ww_003D is ICurve)
		{
			Point3D[] array = _0023_003Dz8EhW_0024omtFk2M.IntersectWith((ICurve)_0023_003Dz_0024ozI2Ww_003D);
			if (array.Length != 0)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Point(array[i]));
				}
				return true;
			}
		}
		if (_0023_003Dz_0024ozI2Ww_003D is Region)
		{
			Region region = (Region)_0023_003Dz_0024ozI2Ww_003D;
			for (int j = 0; j < region.contourList.Count; j++)
			{
				Point3D[] array2 = region.contourList[j].IntersectWith(_0023_003Dz8EhW_0024omtFk2M);
				if (array2.Length != 0)
				{
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array2.Length);
					for (int k = 0; k < array2.Length; k++)
					{
						_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Point(array2[k]));
					}
					return true;
				}
			}
			if (region.IsPointInside(_0023_003Dz8EhW_0024omtFk2M.StartPoint))
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity> { (Entity)_0023_003Dz8EhW_0024omtFk2M };
				return true;
			}
		}
		_0023_003DzqmF8XJ0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654772), _0023_003Dz8EhW_0024omtFk2M.GetType(), _0023_003Dz_0024ozI2Ww_003D.GetType());
		return false;
	}

	private static bool _0023_003DzjtG6qP7OeQYF(Region _0023_003DzwHmY3w4_003D, Entity _0023_003Dz_0024ozI2Ww_003D, bool _0023_003Dz459_0024dvasvvb3, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzqmF8XJ0_003D = string.Empty;
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		if (_0023_003Dz_0024ozI2Ww_003D is ICurve)
		{
			return _0023_003DzUMjcZmpBKT2_((ICurve)_0023_003Dz_0024ozI2Ww_003D, _0023_003DzwHmY3w4_003D, _0023_003Dz459_0024dvasvvb3, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		}
		if (_0023_003Dz_0024ozI2Ww_003D is Region)
		{
			Region b = (Region)_0023_003Dz_0024ozI2Ww_003D;
			Region[] array = Region.Intersection(_0023_003DzwHmY3w4_003D, b);
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = array?.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzAq9OBMvqTiqAP05rNTLaqwU_003D).ToList();
			if (array != null)
			{
				return array.Length != 0;
			}
			return false;
		}
		_0023_003DzqmF8XJ0_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654772), _0023_003DzwHmY3w4_003D.GetType(), _0023_003Dz_0024ozI2Ww_003D.GetType());
		return false;
	}

	public static bool _0023_003Dz9h5MY_A_003D(Entity _0023_003DzRVoDPs0_003D, Entity _0023_003Dz_0024ozI2Ww_003D, bool _0023_003Dz459_0024dvasvvb3, bool _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>();
		_0023_003DzqmF8XJ0_003D = string.Empty;
		if (_0023_003DzRVoDPs0_003D is Mesh && _0023_003Dz_0024ozI2Ww_003D is Mesh)
		{
			return _0023_003Dz8dyYcX3ZtQCc((Mesh)_0023_003DzRVoDPs0_003D, (Mesh)_0023_003Dz_0024ozI2Ww_003D, _0023_003Dz459_0024dvasvvb3, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		}
		if (_0023_003DzRVoDPs0_003D is Solid && _0023_003Dz_0024ozI2Ww_003D is Solid)
		{
			return _0023_003DzAZggff4kxugG((Solid)_0023_003DzRVoDPs0_003D, (Solid)_0023_003Dz_0024ozI2Ww_003D, _0023_003Dz459_0024dvasvvb3, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		}
		if (_0023_003DzRVoDPs0_003D is Brep && _0023_003Dz_0024ozI2Ww_003D is Brep)
		{
			return _0023_003DzOSZN_0024Rdf7ywn((Brep)_0023_003DzRVoDPs0_003D, (Brep)_0023_003Dz_0024ozI2Ww_003D, _0023_003Dz459_0024dvasvvb3, _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		}
		if (_0023_003DzRVoDPs0_003D is Surface && _0023_003Dz_0024ozI2Ww_003D is Surface)
		{
			return _0023_003Dz_ddd7Ii6YWma((Surface)_0023_003DzRVoDPs0_003D, (Surface)_0023_003Dz_0024ozI2Ww_003D, _0023_003Dz459_0024dvasvvb3, _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		}
		_0023_003DzqmF8XJ0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654963) + _0023_003DzRVoDPs0_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654930) + _0023_003Dz_0024ozI2Ww_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654941);
		return false;
	}

	public static bool _0023_003Dzaoe8pVvD0ufk(Entity _0023_003DzRVoDPs0_003D, Entity _0023_003Dz_0024ozI2Ww_003D, bool _0023_003Dz459_0024dvasvvb3, bool _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		if (_0023_003DzRVoDPs0_003D is ICurve)
		{
			return _0023_003DzUMjcZmpBKT2_((ICurve)_0023_003DzRVoDPs0_003D, _0023_003Dz_0024ozI2Ww_003D, _0023_003Dz459_0024dvasvvb3, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		}
		if (_0023_003DzRVoDPs0_003D is Region)
		{
			return _0023_003DzjtG6qP7OeQYF((Region)_0023_003DzRVoDPs0_003D, _0023_003Dz_0024ozI2Ww_003D, _0023_003Dz459_0024dvasvvb3, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		}
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		_0023_003DzqmF8XJ0_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654963) + _0023_003DzRVoDPs0_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654930) + _0023_003Dz_0024ozI2Ww_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654941);
		return false;
	}

	public static bool _0023_003DzFkni6LgPtREc2cQDDplKBiw_003D(Entity _0023_003Dz_EvC0ok_003D, Entity _0023_003Dzoo_0024NTgQ_003D, ref List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		bool flag = true;
		if (_0023_003Dz_EvC0ok_003D is Brep)
		{
			Point3D[] _0023_003Dzwf2OU4pUJmjk = null;
			ICurve[] intCurves = null;
			if (_0023_003Dz_EvC0ok_003D is Brep && _0023_003Dzoo_0024NTgQ_003D is Brep)
			{
				if (_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D != null && _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0 && _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D[0] is Brep)
				{
					return true;
				}
				try
				{
					bool _0023_003DztLD2a19GFACn;
					Brep[] array = Brep._0023_003DzzDn32WHo_7Y_0024((Brep)_0023_003Dz_EvC0ok_003D, (Brep)_0023_003Dzoo_0024NTgQ_003D, (Brep._0023_003Dz4Hw_002424_0024xhqb8)1, out _0023_003DztLD2a19GFACn, out _0023_003Dzwf2OU4pUJmjk, out intCurves);
					if (array != null && array.Length != 0)
					{
						_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array.ToList());
						return true;
					}
				}
				catch
				{
					flag = false;
				}
			}
			else
			{
				Brep.IntersectionLoops((Brep)_0023_003Dz_EvC0ok_003D, (Brep)_0023_003Dzoo_0024NTgQ_003D, out intCurves);
			}
			if (intCurves != null && intCurves.Length != 0)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>();
				ICurve[] array2 = intCurves;
				foreach (ICurve curve in array2)
				{
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.AddRange(from _0023_003Dz9Bu_NNI_003D in curve.GetIndividualCurves()
						select (Entity)_0023_003Dz9Bu_NNI_003D);
				}
			}
			else if (_0023_003Dzwf2OU4pUJmjk != null && _0023_003Dzwf2OU4pUJmjk.Length != 0)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(_0023_003Dzwf2OU4pUJmjk.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzfupOTX4YW1JP3jUMntbu_FQopg6Kjo3Jjw_003D_003D));
			}
		}
		else if (_0023_003Dz_EvC0ok_003D is Surface surface)
		{
			ICurve[] curves;
			ssiFailureType num = surface.IntersectWith((Surface)_0023_003Dzoo_0024NTgQ_003D, ((Surface)_0023_003Dzoo_0024NTgQ_003D)._0023_003DzVx1luJEZaaC7().Diagonal / 1000.0, out curves);
			if (curves != null)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = curves.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz5sY8uYCtfzWgC3wGqBSRUi8a9NvKfTJ13w_003D_003D).ToList();
			}
			flag = num == ssiFailureType.Success;
		}
		else if (_0023_003Dz_EvC0ok_003D is Solid a)
		{
			if (_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D != null && _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0 && _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D[0] is Solid)
			{
				return true;
			}
			Solid[] array3 = Solid.Intersection(a, (Solid)_0023_003Dzoo_0024NTgQ_003D);
			if (array3 != null && array3.Length != 0)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array3.ToList());
				return true;
			}
			flag = false;
			if (_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D == null)
			{
				Segment3D[] array4 = Solid.IntersectionLoops(a, (Solid)_0023_003Dzoo_0024NTgQ_003D);
				if (array4 != null && array4.Length != 0)
				{
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array4.Length);
					Segment3D[] array5 = array4;
					foreach (Segment3D seg in array5)
					{
						_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Line(seg));
					}
				}
			}
		}
		if (_0023_003Dz_EvC0ok_003D is Mesh mesh)
		{
			Mesh mesh2 = (Mesh)_0023_003Dzoo_0024NTgQ_003D;
			List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D = new List<Point3D>();
			bool flag2 = ((!mesh.IsClosed && !mesh2.IsClosed) ? Utility._0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(mesh.Vertices, mesh2.Vertices, mesh.Triangles, mesh2.Triangles, _0023_003DzTfxE2Y3M0gXu: true, ref _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D) : Utility._0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(mesh, mesh2, _0023_003Dz459_0024dvasvvb3: true, out _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D));
			if (_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Count > 0)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Count);
				for (int num2 = 0; num2 < _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Count; num2++)
				{
					Entity item = new Point(_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D[num2]);
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(item);
				}
			}
			flag = flag2;
		}
		if (flag)
		{
			flag = _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0;
		}
		return flag;
	}

	public static bool _0023_003Dz9G2giCoGN204cuhAG4_0024LVzE_003D(Entity _0023_003Dz_EvC0ok_003D, Entity _0023_003Dzoo_0024NTgQ_003D, ref List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		bool flag = true;
		if (_0023_003Dz_EvC0ok_003D is Region && _0023_003Dzoo_0024NTgQ_003D is Region)
		{
			Region[] array = Region.Intersection((Region)_0023_003Dz_EvC0ok_003D, (Region)_0023_003Dzoo_0024NTgQ_003D);
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = array?.Select((Func<Region, Entity>)((Region _0023_003DzuwH5j5s_003D) => _0023_003DzuwH5j5s_003D)).ToList();
			if (array != null && array.Length != 0)
			{
				return flag;
			}
			flag = false;
		}
		ICurve[] array2 = ((!(_0023_003Dz_EvC0ok_003D is ICurve curve)) ? ((Region)_0023_003Dz_EvC0ok_003D).ContourList.ToArray() : new ICurve[1] { curve });
		ICurve[] array3 = ((!(_0023_003Dzoo_0024NTgQ_003D is ICurve curve2)) ? ((Region)_0023_003Dzoo_0024NTgQ_003D).ContourList.ToArray() : new ICurve[1] { curve2 });
		List<Point3D> list = new List<Point3D>();
		for (int num = 0; num < array2.Length; num++)
		{
			for (int num2 = 0; num2 < array3.Length; num2++)
			{
				list.AddRange(array2[num].IntersectWith(array3[num2]));
			}
		}
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(list.Count);
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Point(list[num3]));
		}
		if (list.Count == 0)
		{
			if (_0023_003Dz_EvC0ok_003D is Region region && region.IsPointInside(array3[0].StartPoint))
			{
				ICurve[] array4 = array3;
				for (int num4 = 0; num4 < array4.Length; num4++)
				{
					Entity item = (Entity)array4[num4];
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(item);
				}
			}
			else if (_0023_003Dzoo_0024NTgQ_003D is Region region2 && region2.IsPointInside(array2[0].StartPoint))
			{
				ICurve[] array4 = array2;
				for (int num4 = 0; num4 < array4.Length; num4++)
				{
					Entity item2 = (Entity)array4[num4];
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(item2);
				}
			}
		}
		if (flag)
		{
			flag = _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0;
		}
		return flag;
	}
}
