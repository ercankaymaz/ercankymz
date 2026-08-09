using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Meshing;
using devDept.Geometry;

internal sealed class _0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ
{
	private sealed class _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D
	{
		public _0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D;

		public List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzosI445g_003D;

		public List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzG_0024K4wWM_003D;

		public double _0023_003Dz5Tpjxj5wp_0024R8;

		public double[][] _0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D;

		public double[][] _0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D;

		public bool[] _0023_003DzqNi_7SI_003D;

		internal void _0023_003DzX8suYC4dhS6C6J1yiV_vxS4_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			if (_0023_003DzNc0NCcKw5PwBrSGwLeOQwdI_003D(_0023_003DzoY1J37Y_003D, _0023_003DzosI445g_003D[_0023_003Dz437_00244ak_003D], _0023_003DzG_0024K4wWM_003D[_0023_003Dz437_00244ak_003D], _0023_003Dz5Tpjxj5wp_0024R8, ref _0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D, ref _0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D))
			{
				_0023_003DzqNi_7SI_003D[_0023_003Dz437_00244ak_003D] = !_0023_003DzoY1J37Y_003D._0023_003DzRLsLFGNa6Q6m();
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	private sealed class _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D
	{
		public Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzUU5ugfo_003D;

		public _0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D;

		public Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D;

		public List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>[] _0023_003Dzv3y8B0VOsOPb;

		public List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>[] _0023_003DzmthKoigHg_PX;

		internal void _0023_003DzuzryJa5GkcSQzbPdPw_003D_003D(int _0023_003DzHDyvLPM_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			QuadEntityDataNode quadEntityDataNode = _0023_003DzUU5ugfo_003D.Item1.Children[_0023_003DzHDyvLPM_003D];
			quadEntityDataNode.GetBoudingBox(out var boxMin, out var boxMax);
			OrientedBoundingRect orientedBoundingRect;
			if (quadEntityDataNode is Octant)
			{
				Size3D size3D = new Size3D((Point3D)boxMin, (Point3D)boxMax);
				orientedBoundingRect = new OrientedBoundingBox((Point3D)boxMin, size3D.X, size3D.Y, size3D.Z);
			}
			else
			{
				Size2D size2D = new Size2D(boxMin, boxMax);
				orientedBoundingRect = new OrientedBoundingRect(boxMin, size2D.X, size2D.Y);
			}
			orientedBoundingRect.AccumulateTransformation(_0023_003DzUU5ugfo_003D.Item2.AccumulatedTransformation);
			Tuple<QuadEntityDataNode, OrientedBoundingRect> tuple = new Tuple<QuadEntityDataNode, OrientedBoundingRect>(quadEntityDataNode, orientedBoundingRect);
			_0023_003Dzv3y8B0VOsOPb[_0023_003DzHDyvLPM_003D] = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>();
			_0023_003DzmthKoigHg_PX[_0023_003DzHDyvLPM_003D] = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>();
			_0023_003Dz8HapxvWgQxK_(_0023_003DzoY1J37Y_003D, tuple, _0023_003DzRR5uIYU_003D, ref _0023_003Dzv3y8B0VOsOPb[_0023_003DzHDyvLPM_003D], ref _0023_003DzmthKoigHg_PX[_0023_003DzHDyvLPM_003D]);
		}
	}

	internal delegate bool _0023_003DzCtLKLJ8KXO5x(Entity _0023_003DzRVoDPs0_003D, Entity _0023_003Dz_0024ozI2Ww_003D, bool _0023_003Dz459_0024dvasvvb3, bool _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D);

	private sealed class _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D
	{
		public _0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D;

		public List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzosI445g_003D;

		public List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzG_0024K4wWM_003D;

		public bool[] _0023_003DzqNi_7SI_003D;

		internal void _0023_003DzbJ1X0hHD5XZB75aNfvmnheM_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			if (_0023_003DzCanGsW_BWpge(_0023_003DzoY1J37Y_003D, _0023_003DzosI445g_003D[_0023_003Dz437_00244ak_003D], _0023_003DzG_0024K4wWM_003D[_0023_003Dz437_00244ak_003D]))
			{
				_0023_003DzqNi_7SI_003D[_0023_003Dz437_00244ak_003D] = !_0023_003DzoY1J37Y_003D._0023_003DzRLsLFGNa6Q6m();
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	internal static Mesh _0023_003DziM1_zFafFij_0024(Entity _0023_003Dz9j7EUB0_003D, int _0023_003DzzyOOX2sMweEuE553Lg_003D_003D)
	{
		if (_0023_003DzzyOOX2sMweEuE553Lg_003D_003D > 0 && _0023_003Dz9j7EUB0_003D is Brep brep)
		{
			brep._0023_003Dz1td33yCcgI1ZRbAOew_003D_003D(Enumerable.Repeat(new SizesOnCurve(_0023_003DzzyOOX2sMweEuE553Lg_003D_003D), brep.Edges.Length).ToArray(), null, string.Empty, new StringBuilder(), out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, out var _, null, default(CancellationToken));
			return new Mesh(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
		}
		Mesh[] tessellation = ((IFace)_0023_003Dz9j7EUB0_003D).GetTessellation();
		Mesh mesh = tessellation[0];
		for (int i = 1; i < tessellation.Length; i++)
		{
			mesh.MergeWith(tessellation[i], weldNow: false, recomputeEdges: false);
		}
		return mesh.ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain);
	}

	internal static void _0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref Entity _0023_003Dzv_7IeQibaTXs, ref Entity _0023_003DzNpfDgu2nb0Hr, bool _0023_003DzWFJfb_0_003D)
	{
		if (_0023_003Dzv_7IeQibaTXs is Brep)
		{
			if (!(_0023_003DzNpfDgu2nb0Hr is Brep))
			{
				if (_0023_003DzNpfDgu2nb0Hr is Surface)
				{
					_0023_003DzNpfDgu2nb0Hr = ((Surface)_0023_003DzNpfDgu2nb0Hr)._0023_003DzNKgo41WGofib(((Brep)_0023_003Dzv_7IeQibaTXs).RebuildTolerance, _0023_003DzE48epYcubkX6: true);
				}
				else if (_0023_003DzNpfDgu2nb0Hr is Region)
				{
					_0023_003DzNpfDgu2nb0Hr = ((Region)_0023_003DzNpfDgu2nb0Hr).ConvertToSurface()._0023_003DzNKgo41WGofib(((Brep)_0023_003Dzv_7IeQibaTXs).RebuildTolerance, _0023_003DzE48epYcubkX6: true);
				}
				_0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref _0023_003DzNpfDgu2nb0Hr, ref _0023_003Dzv_7IeQibaTXs, _0023_003DzWFJfb_0_003D);
			}
		}
		else if (_0023_003Dzv_7IeQibaTXs is Surface)
		{
			if (!(_0023_003DzNpfDgu2nb0Hr is Surface))
			{
				if (_0023_003DzNpfDgu2nb0Hr is Region)
				{
					_0023_003DzNpfDgu2nb0Hr = ((Region)_0023_003DzNpfDgu2nb0Hr).ConvertToSurface();
				}
				_0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref _0023_003DzNpfDgu2nb0Hr, ref _0023_003Dzv_7IeQibaTXs, _0023_003DzWFJfb_0_003D);
			}
		}
		else if (_0023_003Dzv_7IeQibaTXs is Solid)
		{
			if (_0023_003DzNpfDgu2nb0Hr is Solid)
			{
				return;
			}
			if (_0023_003DzNpfDgu2nb0Hr is Brep)
			{
				_0023_003DzNpfDgu2nb0Hr = ((Brep)_0023_003DzNpfDgu2nb0Hr).ConvertToSolid();
			}
			else if (_0023_003DzNpfDgu2nb0Hr is Surface)
			{
				_0023_003DzNpfDgu2nb0Hr = ((Surface)_0023_003DzNpfDgu2nb0Hr).ConvertToSolid();
			}
			else if (_0023_003DzNpfDgu2nb0Hr is Region)
			{
				_0023_003DzNpfDgu2nb0Hr = ((Region)_0023_003DzNpfDgu2nb0Hr).ConvertToSolid();
			}
			else if (_0023_003DzNpfDgu2nb0Hr is Mesh)
			{
				_0023_003DzNpfDgu2nb0Hr = _0023_003DziM1_zFafFij_0024(_0023_003DzNpfDgu2nb0Hr, 0);
				if (_0023_003DzWFJfb_0_003D)
				{
					_0023_003DzNpfDgu2nb0Hr = ((Mesh)_0023_003DzNpfDgu2nb0Hr).ConvertToSolid();
					_0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref _0023_003DzNpfDgu2nb0Hr, ref _0023_003Dzv_7IeQibaTXs, _0023_003DzWFJfb_0_003D: true);
				}
				else
				{
					_0023_003Dzv_7IeQibaTXs = _0023_003DziM1_zFafFij_0024(_0023_003Dzv_7IeQibaTXs, 0);
				}
			}
		}
		else if (_0023_003Dzv_7IeQibaTXs is Region)
		{
			if (_0023_003DzNpfDgu2nb0Hr is Region)
			{
				if (_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzwAfFvoy42C6h())
				{
					_0023_003Dzv_7IeQibaTXs = ((Region)_0023_003Dzv_7IeQibaTXs).ConvertToSurface();
					_0023_003DzNpfDgu2nb0Hr = ((Region)_0023_003DzNpfDgu2nb0Hr).ConvertToSurface();
				}
				else
				{
					_0023_003Dzv_7IeQibaTXs = _0023_003DziM1_zFafFij_0024(_0023_003Dzv_7IeQibaTXs, 0);
					_0023_003DzNpfDgu2nb0Hr = _0023_003DziM1_zFafFij_0024(_0023_003DzNpfDgu2nb0Hr, 0);
				}
			}
			else
			{
				_0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref _0023_003DzNpfDgu2nb0Hr, ref _0023_003Dzv_7IeQibaTXs, _0023_003DzWFJfb_0_003D);
			}
		}
		else if (_0023_003Dzv_7IeQibaTXs is IFace)
		{
			if (_0023_003DzWFJfb_0_003D)
			{
				_0023_003Dzv_7IeQibaTXs = ((Mesh)_0023_003Dzv_7IeQibaTXs).ConvertToSolid();
				_0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref _0023_003Dzv_7IeQibaTXs, ref _0023_003DzNpfDgu2nb0Hr, _0023_003DzWFJfb_0_003D: true);
			}
			else
			{
				_0023_003DzNpfDgu2nb0Hr = _0023_003DziM1_zFafFij_0024(_0023_003DzNpfDgu2nb0Hr, 0);
			}
		}
	}

	internal static bool _0023_003Dz9h5MY_A_003D(_0023_003DzCtLKLJ8KXO5x _0023_003Dzv2_iycXmH4vT8I1ZiUJ9pNo_003D, Entity _0023_003DzRVoDPs0_003D, Entity _0023_003Dz_0024ozI2Ww_003D, bool _0023_003Dz459_0024dvasvvb3, bool _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out string _0023_003DzqmF8XJ0_003D)
	{
		return _0023_003Dzv2_iycXmH4vT8I1ZiUJ9pNo_003D(_0023_003DzRVoDPs0_003D, _0023_003Dz_0024ozI2Ww_003D, _0023_003Dz459_0024dvasvvb3, _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
	}

	private static void _0023_003DzKcrN81wvjso0(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzUU5ugfo_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D, ref List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzosI445g_003D, ref List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzG_0024K4wWM_003D)
	{
		if (!((!(_0023_003DzUU5ugfo_003D.Item1 is Octant)) ? ((_0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() && OrientedBoundingRect.DoOverlapOrTouch(_0023_003DzUU5ugfo_003D.Item2, _0023_003DzRR5uIYU_003D.Item2)) || OrientedBoundingRect.DoOverlap(_0023_003DzUU5ugfo_003D.Item2, _0023_003DzRR5uIYU_003D.Item2)) : ((_0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() && OrientedBoundingBox.DoOverlapOrTouch((OrientedBoundingBox)_0023_003DzUU5ugfo_003D.Item2, (OrientedBoundingBox)_0023_003DzRR5uIYU_003D.Item2)) || OrientedBoundingBox.DoOverlap((OrientedBoundingBox)_0023_003DzUU5ugfo_003D.Item2, (OrientedBoundingBox)_0023_003DzRR5uIYU_003D.Item2))))
		{
			return;
		}
		_0023_003DzosI445g_003D.Add(_0023_003DzUU5ugfo_003D);
		_0023_003DzG_0024K4wWM_003D.Add(_0023_003DzRR5uIYU_003D);
		if (!_0023_003DzRR5uIYU_003D.Item1.HasChildren)
		{
			return;
		}
		for (int i = 0; i < _0023_003DzRR5uIYU_003D.Item1.Children.Length; i++)
		{
			QuadEntityDataNode quadEntityDataNode = _0023_003DzRR5uIYU_003D.Item1.Children[i];
			quadEntityDataNode.GetBoudingBox(out var boxMin, out var boxMax);
			OrientedBoundingRect orientedBoundingRect;
			if (quadEntityDataNode is Octant)
			{
				Size3D size3D = new Size3D((Point3D)boxMin, (Point3D)boxMax);
				orientedBoundingRect = new OrientedBoundingBox((Point3D)boxMin, size3D.X, size3D.Y, size3D.Z);
			}
			else
			{
				Size2D size2D = new Size2D(boxMin, boxMax);
				orientedBoundingRect = new OrientedBoundingRect(boxMin, size2D.X, size2D.Y);
			}
			orientedBoundingRect.AccumulateTransformation(_0023_003DzRR5uIYU_003D.Item2.AccumulatedTransformation);
			Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D2 = new Tuple<QuadEntityDataNode, OrientedBoundingRect>(quadEntityDataNode, orientedBoundingRect);
			_0023_003DzKcrN81wvjso0(_0023_003DzoY1J37Y_003D, _0023_003DzUU5ugfo_003D, _0023_003DzRR5uIYU_003D2, ref _0023_003DzosI445g_003D, ref _0023_003DzG_0024K4wWM_003D);
		}
	}

	private static void _0023_003Dz8HapxvWgQxK_(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzUU5ugfo_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D, ref List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzosI445g_003D, ref List<Tuple<QuadEntityDataNode, OrientedBoundingRect>> _0023_003DzG_0024K4wWM_003D)
	{
		_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2 = new _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D();
		_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D = _0023_003DzUU5ugfo_003D;
		_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzoY1J37Y_003D = _0023_003DzoY1J37Y_003D;
		_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzRR5uIYU_003D = _0023_003DzRR5uIYU_003D;
		if (!((!(_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D.Item1 is Octant)) ? ((_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() && OrientedBoundingRect.DoOverlapOrTouch(_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D.Item2, _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzRR5uIYU_003D.Item2)) || OrientedBoundingRect.DoOverlap(_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D.Item2, _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzRR5uIYU_003D.Item2)) : ((_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() && OrientedBoundingBox.DoOverlapOrTouch((OrientedBoundingBox)_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D.Item2, (OrientedBoundingBox)_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzRR5uIYU_003D.Item2)) || OrientedBoundingBox.DoOverlap((OrientedBoundingBox)_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D.Item2, (OrientedBoundingBox)_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzRR5uIYU_003D.Item2))))
		{
			return;
		}
		_0023_003DzKcrN81wvjso0(_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzoY1J37Y_003D, _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D, _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzRR5uIYU_003D, ref _0023_003DzosI445g_003D, ref _0023_003DzG_0024K4wWM_003D);
		if (_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D.Item1.HasChildren)
		{
			int num = _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzUU5ugfo_003D.Item1.Children.Length;
			_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003Dzv3y8B0VOsOPb = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>[num];
			_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzmthKoigHg_PX = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>[num];
			Parallel.For(0, num, new ParallelOptions
			{
				MaxDegreeOfParallelism = num
			}, _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzuzryJa5GkcSQzbPdPw_003D_003D);
			for (int i = 0; i < _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003Dzv3y8B0VOsOPb.Length; i++)
			{
				_0023_003DzosI445g_003D.AddRange(_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003Dzv3y8B0VOsOPb[i]);
				_0023_003DzG_0024K4wWM_003D.AddRange(_0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D2._0023_003DzmthKoigHg_PX[i]);
			}
		}
	}

	internal static bool _0023_003DzGBcHaJW_L4SQ(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D)
	{
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2 = new _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D();
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D = _0023_003DzoY1J37Y_003D;
		if (_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().TreeSource == null || _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().TreeSource == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953196));
		}
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003Dz5Tpjxj5wp_0024R8 = 100.0 / (double)((CollisionDetection)_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003DznZ3kF7cXs_JJ())._0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D;
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzosI445g_003D = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>();
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzG_0024K4wWM_003D = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>();
		Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzUU5ugfo_003D = new Tuple<QuadEntityDataNode, OrientedBoundingRect>((Octant)_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy(), (OrientedBoundingBox)_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dz_5uW98OSDXnF());
		Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D = new Tuple<QuadEntityDataNode, OrientedBoundingRect>((Octant)_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg(), (OrientedBoundingBox)_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003DzLFBM2_wUTbia());
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D = new double[((Mesh)_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().TreeSource.OriginalDataSource).Vertices.Length][];
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D = new double[((Mesh)_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().TreeSource.OriginalDataSource).Vertices.Length][];
		_0023_003Dz8HapxvWgQxK_(_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D, _0023_003DzUU5ugfo_003D, _0023_003DzRR5uIYU_003D, ref _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzosI445g_003D, ref _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzG_0024K4wWM_003D);
		if (_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzosI445g_003D.Count == 0)
		{
			return false;
		}
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzqNi_7SI_003D = new bool[_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzosI445g_003D.Count];
		ParallelLoopResult parallelLoopResult = Parallel.For(0, _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzosI445g_003D.Count, _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzX8suYC4dhS6C6J1yiV_vxS4_003D);
		_0023_003DzxJ4jK6774hOq(_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzoY1J37Y_003D);
		if (!parallelLoopResult.IsCompleted)
		{
			bool[] _0023_003DzqNi_7SI_003D = _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzqNi_7SI_003D;
			for (int i = 0; i < _0023_003DzqNi_7SI_003D.Length; i++)
			{
				if (_0023_003DzqNi_7SI_003D[i])
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool _0023_003DzNc0NCcKw5PwBrSGwLeOQwdI_003D(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzUU5ugfo_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D, double _0023_003Dz5Tpjxj5wp_0024R8, ref double[][] _0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D, ref double[][] _0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D)
	{
		int[] elementsIndices = _0023_003DzUU5ugfo_003D.Item1.ElementsIndices;
		int[] elementsIndices2 = _0023_003DzRR5uIYU_003D.Item1.ElementsIndices;
		if (elementsIndices.Length != 0 && elementsIndices2.Length != 0)
		{
			int num = 0;
			Transformation obj = (Transformation)_0023_003DzUU5ugfo_003D.Item2.AccumulatedTransformation.Clone();
			obj.Invert();
			Transformation xform = obj * _0023_003DzRR5uIYU_003D.Item2.AccumulatedTransformation;
			int[] array = elementsIndices;
			foreach (int num2 in array)
			{
				num++;
				Point3D[] vertices = ((Mesh)_0023_003DzUU5ugfo_003D.Item1.TreeSource.OriginalDataSource).Vertices;
				IndexTriangle indexTriangle = ((Mesh)_0023_003DzUU5ugfo_003D.Item1.TreeSource.OriginalDataSource).Triangles[num2];
				if (_0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V1] == null)
				{
					_0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V1] = vertices[indexTriangle.V1].ToArray();
				}
				if (_0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V2] == null)
				{
					_0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V2] = vertices[indexTriangle.V2].ToArray();
				}
				if (_0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V3] == null)
				{
					_0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V3] = vertices[indexTriangle.V3].ToArray();
				}
				double[] p = _0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V1];
				double[] q = _0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V2];
				double[] r = _0023_003DzjFY0m9w1NcLPVXrB9w_003D_003D[indexTriangle.V3];
				int[] array2 = elementsIndices2;
				foreach (int num3 in array2)
				{
					if (_0023_003DzxJ4jK6774hOq(_0023_003DzoY1J37Y_003D))
					{
						return true;
					}
					Point3D[] vertices2 = ((Mesh)_0023_003DzRR5uIYU_003D.Item1.TreeSource.OriginalDataSource).Vertices;
					IndexTriangle indexTriangle2 = ((Mesh)_0023_003DzRR5uIYU_003D.Item1.TreeSource.OriginalDataSource).Triangles[num3];
					if (_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V1] == null)
					{
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V1] = vertices2[indexTriangle2.V1].ToArray();
					}
					if (_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V2] == null)
					{
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V2] = vertices2[indexTriangle2.V2].ToArray();
					}
					if (_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V3] == null)
					{
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V3] = vertices2[indexTriangle2.V3].ToArray();
					}
					double[] v = new double[3]
					{
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V1][0],
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V1][1],
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V1][2]
					};
					double[] v2 = new double[3]
					{
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V2][0],
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V2][1],
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V2][2]
					};
					double[] v3 = new double[3]
					{
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V3][0],
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V3][1],
						_0023_003DzvtZOLqPIRb_SqUaWuA_003D_003D[indexTriangle2.V3][2]
					};
					UtilityMacros.TRANSFORM(ref v, xform);
					UtilityMacros.TRANSFORM(ref v2, xform);
					UtilityMacros.TRANSFORM(ref v3, xform);
					if (Utility.TriangleTriangleIntersection(p, q, r, v, v2, v3, out var touch) && (_0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() || !touch))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	internal static bool _0023_003Dz6aWRRHKmoB3YQ1RduA_003D_003D(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D)
	{
		_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2 = new _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D();
		_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzoY1J37Y_003D = _0023_003DzoY1J37Y_003D;
		_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzosI445g_003D = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>();
		_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzG_0024K4wWM_003D = new List<Tuple<QuadEntityDataNode, OrientedBoundingRect>>();
		Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzUU5ugfo_003D = new Tuple<QuadEntityDataNode, OrientedBoundingRect>(_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy(), _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dz_5uW98OSDXnF());
		Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D = new Tuple<QuadEntityDataNode, OrientedBoundingRect>(_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg(), _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzoY1J37Y_003D._0023_003DzLFBM2_wUTbia());
		_0023_003Dz8HapxvWgQxK_(_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzoY1J37Y_003D, _0023_003DzUU5ugfo_003D, _0023_003DzRR5uIYU_003D, ref _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzosI445g_003D, ref _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzG_0024K4wWM_003D);
		if (_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzosI445g_003D.Count == 0)
		{
			return false;
		}
		_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzqNi_7SI_003D = new bool[_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzosI445g_003D.Count];
		ParallelLoopResult parallelLoopResult = Parallel.For(0, _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzosI445g_003D.Count, _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzbJ1X0hHD5XZB75aNfvmnheM_003D);
		_0023_003DzxJ4jK6774hOq(_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzoY1J37Y_003D);
		if (!parallelLoopResult.IsCompleted)
		{
			bool[] _0023_003DzqNi_7SI_003D = _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzqNi_7SI_003D;
			for (int i = 0; i < _0023_003DzqNi_7SI_003D.Length; i++)
			{
				if (_0023_003DzqNi_7SI_003D[i])
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool _0023_003DzCanGsW_BWpge(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzUU5ugfo_003D, Tuple<QuadEntityDataNode, OrientedBoundingRect> _0023_003DzRR5uIYU_003D)
	{
		int[] elementsIndices = _0023_003DzUU5ugfo_003D.Item1.ElementsIndices;
		int[] elementsIndices2 = _0023_003DzRR5uIYU_003D.Item1.ElementsIndices;
		if (elementsIndices.Length != 0 && elementsIndices2.Length != 0)
		{
			_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3 = new _0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2(_0023_003DzUU5ugfo_003D.Item2, _0023_003DzUU5ugfo_003D.Item1, _0023_003DzRR5uIYU_003D.Item2, _0023_003DzRR5uIYU_003D.Item1, _0023_003DzoY1J37Y_003D._0023_003Dzstco_0024OinoxBK(), _0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G(), _0023_003DzoY1J37Y_003D._0023_003DznZ3kF7cXs_JJ(), _0023_003DzoY1J37Y_003D._0023_003DzyYzK9S5noNSe(), _0023_003DzoY1J37Y_003D._0023_003Dza02mGc0BbcbE(), _0023_003DzoY1J37Y_003D._0023_003Dzar7oXo7awQnN());
			_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003Dzx687hn7J2HIi(_0023_003DzUU5ugfo_003D.Item1);
			_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzYh2jlAyEo7OK(_0023_003DzUU5ugfo_003D.Item2);
			_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzNhDORzbn82Lo(_0023_003DzRR5uIYU_003D.Item1);
			_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzQb3G89e4I_Ek(_0023_003DzRR5uIYU_003D.Item2);
			bool flag = _0023_003DzUU5ugfo_003D.Item1.TreeSource.OriginalDataSource is Mesh;
			bool flag2 = _0023_003DzRR5uIYU_003D.Item1.TreeSource.OriginalDataSource is Mesh;
			if (flag && flag2)
			{
				if (_0023_003Dz6emfGVUBTVbQslpfcbnXsm8msKD1WP_00241ng_003D_003D(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3))
				{
					_0023_003DzoY1J37Y_003D._0023_003DzXugFTsUi_0024soE(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzRLsLFGNa6Q6m());
					return true;
				}
			}
			else if (!flag && flag2)
			{
				_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzNhDORzbn82Lo(_0023_003DzUU5ugfo_003D.Item1);
				_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzQb3G89e4I_Ek(_0023_003DzUU5ugfo_003D.Item2);
				_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003Dzx687hn7J2HIi(_0023_003DzRR5uIYU_003D.Item1);
				_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzYh2jlAyEo7OK(_0023_003DzRR5uIYU_003D.Item2);
				if (_0023_003DzW024oSPdcc3aOMxvjsw28Zn9MNIa(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3))
				{
					_0023_003DzoY1J37Y_003D._0023_003DzXugFTsUi_0024soE(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzRLsLFGNa6Q6m());
					return true;
				}
			}
			else if (flag)
			{
				if (_0023_003DzW024oSPdcc3aOMxvjsw28Zn9MNIa(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3))
				{
					_0023_003DzoY1J37Y_003D._0023_003DzXugFTsUi_0024soE(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzRLsLFGNa6Q6m());
					return true;
				}
			}
			else if (_0023_003Dzvcu5ak9Bgrn9tc9kzQ_003D_003D(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3))
			{
				_0023_003DzoY1J37Y_003D._0023_003DzXugFTsUi_0024soE(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ3._0023_003DzRLsLFGNa6Q6m());
				return true;
			}
		}
		return false;
	}

	private static bool _0023_003Dz6emfGVUBTVbQslpfcbnXsm8msKD1WP_00241ng_003D_003D(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D)
	{
		int num = 0;
		Transformation obj = (Transformation)_0023_003DzoY1J37Y_003D._0023_003Dz_5uW98OSDXnF().AccumulatedTransformation.Clone();
		obj.Invert();
		Transformation xform = obj * _0023_003DzoY1J37Y_003D._0023_003DzLFBM2_wUTbia().AccumulatedTransformation;
		int[] elementsIndices = _0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().ElementsIndices;
		foreach (int num2 in elementsIndices)
		{
			num++;
			Point2D[] vertices = ((Mesh)_0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().TreeSource.OriginalDataSource).Vertices;
			Point2D[] array = vertices;
			IndexTriangle indexTriangle = ((Mesh)_0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().TreeSource.OriginalDataSource).Triangles[num2];
			Point2D[] _0023_003DzfikFABeXzzpL = new Point2D[4]
			{
				(Point3D)array[indexTriangle.V1],
				(Point3D)array[indexTriangle.V2],
				(Point3D)array[indexTriangle.V3],
				(Point3D)array[indexTriangle.V1]
			};
			int[] elementsIndices2 = _0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().ElementsIndices;
			foreach (int num3 in elementsIndices2)
			{
				vertices = ((Mesh)_0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().TreeSource.OriginalDataSource).Vertices;
				Point2D[] array2 = vertices;
				IndexTriangle indexTriangle2 = ((Mesh)_0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().TreeSource.OriginalDataSource).Triangles[num3];
				Point2D[] array3 = new Point2D[4]
				{
					(Point3D)array2[indexTriangle2.V1].Clone(),
					(Point3D)array2[indexTriangle2.V2].Clone(),
					(Point3D)array2[indexTriangle2.V3].Clone(),
					(Point3D)array2[indexTriangle2.V1].Clone()
				};
				array3[0].TransformBy(xform);
				array3[1].TransformBy(xform);
				array3[2].TransformBy(xform);
				array3[3].TransformBy(xform);
				if (_0023_003DzxJ4jK6774hOq(_0023_003DzoY1J37Y_003D))
				{
					return true;
				}
				if (_0023_003Dz0PAnW21I8Z33K7kg7DHR8uo_003D(_0023_003DzfikFABeXzzpL, array3, out var _0023_003Dzd7CB2Wfuctoq) && (_0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() || !_0023_003Dzd7CB2Wfuctoq))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool _0023_003DzW024oSPdcc3aOMxvjsw28Zn9MNIa(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D)
	{
		int num = 0;
		Transformation obj = (Transformation)_0023_003DzoY1J37Y_003D._0023_003Dz_5uW98OSDXnF().AccumulatedTransformation.Clone();
		obj.Invert();
		Transformation xform = obj * _0023_003DzoY1J37Y_003D._0023_003DzLFBM2_wUTbia().AccumulatedTransformation;
		int[] elementsIndices = _0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().ElementsIndices;
		foreach (int num2 in elementsIndices)
		{
			num++;
			Point2D[] vertices = ((Mesh)_0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().TreeSource.OriginalDataSource).Vertices;
			Point2D[] array = vertices;
			IndexTriangle indexTriangle = ((Mesh)_0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().TreeSource.OriginalDataSource).Triangles[num2];
			Point2D[] _0023_003DzfikFABeXzzpL = new Point2D[4]
			{
				(Point3D)array[indexTriangle.V1],
				(Point3D)array[indexTriangle.V2],
				(Point3D)array[indexTriangle.V3],
				(Point3D)array[indexTriangle.V1]
			};
			int[] elementsIndices2 = _0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().ElementsIndices;
			foreach (int num3 in elementsIndices2)
			{
				vertices = ((LinearPath)_0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().TreeSource.OriginalDataSource).Vertices;
				Point2D[] array2 = vertices;
				int num4 = num3 + 1;
				Point2D[] array3 = new Point2D[2]
				{
					(Point3D)array2[num3].Clone(),
					(Point3D)array2[num4].Clone()
				};
				array3[0].TransformBy(xform);
				array3[1].TransformBy(xform);
				if (_0023_003DzxJ4jK6774hOq(_0023_003DzoY1J37Y_003D))
				{
					return true;
				}
				if (_0023_003DzPnrE1LsLxkzqYI0QsA_003D_003D(_0023_003DzfikFABeXzzpL, array3, out var _0023_003Dzd7CB2Wfuctoq) && (_0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() || !_0023_003Dzd7CB2Wfuctoq))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool _0023_003Dzvcu5ak9Bgrn9tc9kzQ_003D_003D(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D)
	{
		int num = 0;
		Transformation obj = (Transformation)_0023_003DzoY1J37Y_003D._0023_003Dz_5uW98OSDXnF().AccumulatedTransformation.Clone();
		obj.Invert();
		Transformation xform = obj * _0023_003DzoY1J37Y_003D._0023_003DzLFBM2_wUTbia().AccumulatedTransformation;
		int[] elementsIndices = _0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().ElementsIndices;
		foreach (int num2 in elementsIndices)
		{
			num++;
			Point2D[] vertices = ((LinearPath)_0023_003DzoY1J37Y_003D._0023_003Dzvp2puBYJswwy().TreeSource.OriginalDataSource).Vertices;
			Point2D[] array = vertices;
			int num3 = num2 + 1;
			Point2D[] _0023_003Dzx58ryKYXEQlSsH52kHOD_0024F0_003D = new Point2D[2]
			{
				(Point3D)array[num2],
				(Point3D)array[num3]
			};
			int[] elementsIndices2 = _0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().ElementsIndices;
			foreach (int num4 in elementsIndices2)
			{
				vertices = ((LinearPath)_0023_003DzoY1J37Y_003D._0023_003Dz_JJJ3HZ_0024BpVg().TreeSource.OriginalDataSource).Vertices;
				Point2D[] array2 = vertices;
				int num5 = num4 + 1;
				Point2D[] array3 = new Point2D[2]
				{
					(Point3D)array2[num4].Clone(),
					(Point3D)array2[num5].Clone()
				};
				array3[0].TransformBy(xform);
				array3[1].TransformBy(xform);
				if (_0023_003DzxJ4jK6774hOq(_0023_003DzoY1J37Y_003D))
				{
					return true;
				}
				if (_0023_003DzGebtGuzXG3vUW4hHoQ_003D_003D(_0023_003Dzx58ryKYXEQlSsH52kHOD_0024F0_003D, array3, out var _0023_003Dzd7CB2Wfuctoq) && (_0023_003DzoY1J37Y_003D._0023_003DzGZHiKIN0513G() || !_0023_003Dzd7CB2Wfuctoq))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool _0023_003Dz0PAnW21I8Z33K7kg7DHR8uo_003D(Point2D[] _0023_003DzfikFABeXzzpL, Point2D[] _0023_003DzQ8e3Lm5t_Y5r, out bool _0023_003Dzd7CB2Wfuctoq)
	{
		_0023_003Dzd7CB2Wfuctoq = false;
		Polygon2D polygon2D = new Polygon2D(_0023_003DzfikFABeXzzpL);
		Polygon2D polygon2D2 = new Polygon2D(_0023_003DzQ8e3Lm5t_Y5r);
		polygon2D.UpdateBoundingRect();
		polygon2D2.UpdateBoundingRect();
		if (polygon2D.IsPolygonInside(polygon2D2, polygon2D.Size.Diagonal) != polygonStatusType.Out)
		{
			return true;
		}
		if (polygon2D.IsPointInside(_0023_003DzQ8e3Lm5t_Y5r[0], polygon2D.Size.Diagonal) == pointStatusType.Onto || polygon2D.IsPointInside(_0023_003DzQ8e3Lm5t_Y5r[1], polygon2D.Size.Diagonal) == pointStatusType.Onto || polygon2D.IsPointInside(_0023_003DzQ8e3Lm5t_Y5r[2], polygon2D.Size.Diagonal) == pointStatusType.Onto || polygon2D2.IsPointInside(_0023_003DzfikFABeXzzpL[0], polygon2D.Size.Diagonal) == pointStatusType.Onto || polygon2D2.IsPointInside(_0023_003DzfikFABeXzzpL[1], polygon2D.Size.Diagonal) == pointStatusType.Onto || polygon2D2.IsPointInside(_0023_003DzfikFABeXzzpL[2], polygon2D.Size.Diagonal) == pointStatusType.Onto)
		{
			_0023_003Dzd7CB2Wfuctoq = true;
			return true;
		}
		return false;
	}

	private static bool _0023_003DzPnrE1LsLxkzqYI0QsA_003D_003D(Point2D[] _0023_003DzfikFABeXzzpL, Point2D[] _0023_003DzmlUhJiMiX2Fc, out bool _0023_003Dzd7CB2Wfuctoq)
	{
		_0023_003Dzd7CB2Wfuctoq = false;
		Polygon2D polygon2D = new Polygon2D(_0023_003DzfikFABeXzzpL);
		polygon2D.UpdateBoundingRect();
		if (polygon2D.Intersect(new Segment2D(_0023_003DzmlUhJiMiX2Fc[0], _0023_003DzmlUhJiMiX2Fc[1])))
		{
			return true;
		}
		pointStatusType num = polygon2D.IsPointInside(_0023_003DzmlUhJiMiX2Fc[0], polygon2D.Size.Diagonal);
		pointStatusType pointStatusType2 = polygon2D.IsPointInside(_0023_003DzmlUhJiMiX2Fc[1], polygon2D.Size.Diagonal);
		if (num == pointStatusType.Onto || pointStatusType2 == pointStatusType.Onto)
		{
			_0023_003Dzd7CB2Wfuctoq = true;
			return true;
		}
		return false;
	}

	private static bool _0023_003DzGebtGuzXG3vUW4hHoQ_003D_003D(Point2D[] _0023_003Dzx58ryKYXEQlSsH52kHOD_0024F0_003D, Point2D[] _0023_003DzY_0024ezGRuGOzuCW2pZ0O5DYEk_003D, out bool _0023_003Dzd7CB2Wfuctoq)
	{
		_0023_003Dzd7CB2Wfuctoq = false;
		Segment2D segment2D = new Segment2D(_0023_003Dzx58ryKYXEQlSsH52kHOD_0024F0_003D[0], _0023_003Dzx58ryKYXEQlSsH52kHOD_0024F0_003D[1]);
		Segment2D segment2D2 = new Segment2D(_0023_003DzY_0024ezGRuGOzuCW2pZ0O5DYEk_003D[0], _0023_003DzY_0024ezGRuGOzuCW2pZ0O5DYEk_003D[1]);
		if (Segment2D.IntersectionAndT(segment2D, segment2D2, out var i))
		{
			if (Point2D.AreEqual(i, segment2D.P0, segment2D.Length) || Point2D.AreEqual(i, segment2D.P1, segment2D.Length) || Point2D.AreEqual(i, segment2D2.P0, segment2D.Length) || Point2D.AreEqual(i, segment2D2.P1, segment2D.Length))
			{
				_0023_003Dzd7CB2Wfuctoq = true;
			}
			return true;
		}
		return false;
	}

	internal static void _0023_003DzcvJlnzpoDjQU_0024cSTzg_003D_003D(int _0023_003DzVau_0024qG4Zb0XN, ref int _0023_003DzvlWrVP7DHEnO)
	{
		if (_0023_003DzVau_0024qG4Zb0XN >= _0023_003DzvlWrVP7DHEnO)
		{
			_0023_003DzvlWrVP7DHEnO = (int)Math.Ceiling((double)(_0023_003DzVau_0024qG4Zb0XN * 100) / 99.0);
		}
	}

	protected static bool _0023_003DzxJ4jK6774hOq(_0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2 _0023_003DzoY1J37Y_003D)
	{
		if (!_0023_003DzoY1J37Y_003D._0023_003DznZ3kF7cXs_JJ().UpdateProgressAndCheckCancelled(0.0, 0.0, _0023_003DzoY1J37Y_003D._0023_003Dzar7oXo7awQnN(), _0023_003DzoY1J37Y_003D._0023_003DzyYzK9S5noNSe(), _0023_003DzoY1J37Y_003D._0023_003Dza02mGc0BbcbE()))
		{
			_0023_003DzoY1J37Y_003D._0023_003DzXugFTsUi_0024soE(_0023_003DzPzO_0024GUk_003D: true);
			return true;
		}
		return false;
	}
}
