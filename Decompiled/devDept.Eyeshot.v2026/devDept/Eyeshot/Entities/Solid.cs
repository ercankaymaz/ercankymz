using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Diagnostic;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Solid : Entity, IFace, ICloneable, IFaceSelectable, ISelectableSubItems
{
	internal enum _0023_003Dz1IcEX2Y45sL1
	{

	}

	internal enum _0023_003Dz3X7lgKY_003D
	{

	}

	private sealed class _0023_003Dz4_CBGipsMzJ9Z44ugwK7tfTLRUp8 : _0023_003DzHmskY20KXdJOW_00243F6wRpODq1NebVl0P4FDPwKYzjyie7
	{
		private sealed class _0023_003Dz8LLBnzYrBSHX : Point3D
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public int _0023_003Dz2QVVx8s_003D;

			public _0023_003Dz8LLBnzYrBSHX(Point3D _0023_003DzySgeilxprQOK, int _0023_003Dz2QVVx8s_003D)
				: base(_0023_003DzySgeilxprQOK)
			{
				this._0023_003Dz2QVVx8s_003D = _0023_003Dz2QVVx8s_003D;
			}
		}

		public List<Point3D> _0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D;

		public IComparer<Point3D> _0023_003Dz4zn204U_003D;

		public _0023_003Dz4_CBGipsMzJ9Z44ugwK7tfTLRUp8(IComparer<Point3D> _0023_003Dz4zn204U_003D)
			: base(null, null, null)
		{
			_0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D = new List<Point3D>();
			this._0023_003Dz4zn204U_003D = _0023_003Dz4zn204U_003D;
		}

		public void _0023_003DzymeFGXxU0V7FfTQHLw_003D_003D(IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<IndexLine> _0023_003DzU3hosSAzkxO7)
		{
			_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
			_0023_003DzZ4_EMwmky47mEQrs2A_003D_003D = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D;
			_0023_003DzU4XYawo_003D = _0023_003DzU3hosSAzkxO7;
		}

		protected override bool _0023_003Dzos6gs0HqIF2n(int _0023_003Dz77g161c_003D)
		{
			int _0023_003Dz77g161c_003D2 = _0023_003DzBYFHRMc_fmcG(_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[_0023_003Dz77g161c_003D], _0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D, _0023_003Dz4zn204U_003D);
			return base._0023_003Dzos6gs0HqIF2n(_0023_003Dz77g161c_003D2);
		}

		protected override bool _0023_003DzkxOPXCxD16i7(int _0023_003DzFj_0024IqDQ_003D, int _0023_003DzjdeMMkk_003D)
		{
			int _0023_003DzFj_0024IqDQ_003D2 = _0023_003DzBYFHRMc_fmcG(_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[_0023_003DzFj_0024IqDQ_003D], _0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D, _0023_003Dz4zn204U_003D);
			int _0023_003DzjdeMMkk_003D2 = _0023_003DzBYFHRMc_fmcG(_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[_0023_003DzjdeMMkk_003D], _0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D, _0023_003Dz4zn204U_003D);
			return base._0023_003DzkxOPXCxD16i7(_0023_003DzFj_0024IqDQ_003D2, _0023_003DzjdeMMkk_003D2);
		}

		private static int _0023_003DzBYFHRMc_fmcG(Point3D _0023_003Dz77g161c_003D, List<Point3D> _0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D, IComparer<Point3D> _0023_003Dz4zn204U_003D)
		{
			int num = _0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D.BinarySearch(_0023_003Dz77g161c_003D, _0023_003Dz4zn204U_003D);
			if (num >= 0)
			{
				return ((_0023_003Dz8LLBnzYrBSHX)_0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D[num])._0023_003Dz2QVVx8s_003D;
			}
			_0023_003Dz8LLBnzYrBSHX _0023_003Dz8LLBnzYrBSHX2 = new _0023_003Dz8LLBnzYrBSHX(_0023_003Dz77g161c_003D, _0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D.Count);
			_0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D.Add(_0023_003Dz8LLBnzYrBSHX2);
			_0023_003DzDw_0024AuoWwJJfHs44U_0024w_003D_003D.Sort(_0023_003Dz4zn204U_003D);
			return _0023_003Dz8LLBnzYrBSHX2._0023_003Dz2QVVx8s_003D;
		}
	}

	internal enum _0023_003Dz6tkLYNg_003D
	{

	}

	internal sealed class _0023_003DzGl0iL3E_003D
	{
		public bool _0023_003DzjTwYx_xFB7Cw;

		public _0023_003Dz6tkLYNg_003D _0023_003Dzu2kDK40_003D;

		public int _0023_003DzGfYpVMhhz20K;

		public int _0023_003DztptblV0_003D;

		public int _0023_003DziEIjfZA_003D;

		public Solid _0023_003DzKzgG76Y_003D;

		public Solid _0023_003Dz64auudc_003D;

		public Portion _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;

		public Portion _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;

		public bool _0023_003Dz4YMDud0EzJJX;

		public _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003Dz4aj0xv0_003D;

		public _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003DzLM7JUrs_003D;

		public Solid _0023_003DzsBlr79I_003D;

		public List<Segment3D> _0023_003Dz_00241Cm8Ev0duOTkgUXhA_003D_003D;

		public List<Solid> _0023_003DzgWXM4q_HW0Kw;

		public double _0023_003DzkRSfKls1SLfn;
	}

	internal enum _0023_003DzPJiQ_WQVpPyH
	{

	}

	internal enum _0023_003DzW6ac6hndjV3muVqByw_003D_003D
	{

	}

	internal enum _0023_003DzZhsUDUz3mSgC
	{

	}

	private sealed class _0023_003Dza4AJl0DnV9nq : IComparer<Point3D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003Dzm0CYiiE_003D;

		public _0023_003Dza4AJl0DnV9nq(double _0023_003Dzm0CYiiE_003D)
		{
			this._0023_003Dzm0CYiiE_003D = _0023_003Dzm0CYiiE_003D;
		}

		public int Compare(Point3D _0023_003DzffqPLNQ_003D, Point3D _0023_003Dz5Azd7L8_003D)
		{
			if (Math.Abs(_0023_003DzffqPLNQ_003D.X - _0023_003Dz5Azd7L8_003D.X) > _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003DzffqPLNQ_003D.X < _0023_003Dz5Azd7L8_003D.X)
				{
					return -1;
				}
				return 1;
			}
			if (Math.Abs(_0023_003DzffqPLNQ_003D.Y - _0023_003Dz5Azd7L8_003D.Y) > _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003DzffqPLNQ_003D.Y < _0023_003Dz5Azd7L8_003D.Y)
				{
					return -1;
				}
				return 1;
			}
			if (Math.Abs(_0023_003DzffqPLNQ_003D.Z - _0023_003Dz5Azd7L8_003D.Z) > _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003DzffqPLNQ_003D.Z < _0023_003Dz5Azd7L8_003D.Z)
				{
					return -1;
				}
				return 1;
			}
			return 0;
		}
	}

	internal sealed class _0023_003DzaD5_0024bui7AmQbPta7uA_003D_003D
	{
		public enum _0023_003DzPFmVjwc_003D
		{

		}

		public Solid _0023_003DzGvMngiE_003D(IList<Point3D> _0023_003DzrAOtYIs_003D, IList<IList<Point3D>> _0023_003Dztj_00245joP3GSIE, Point3D _0023_003Dz689iTwgBibCe, Point3D _0023_003DzIzngpRDqJiq7, double _0023_003Dz_ZutUfPX8vPU, bool _0023_003DzNK_0024wFLs_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, double _0023_003DzkRSfKls1SLfn)
		{
			return _0023_003DzGvMngiE_003D<Solid>(_0023_003DzrAOtYIs_003D, _0023_003Dztj_00245joP3GSIE, _0023_003Dz689iTwgBibCe, _0023_003DzIzngpRDqJiq7, _0023_003Dz_ZutUfPX8vPU, _0023_003DzNK_0024wFLs_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003DzkRSfKls1SLfn);
		}

		public static T _0023_003DzGvMngiE_003D<T>(IList<Point3D> _0023_003DzrAOtYIs_003D, IList<IList<Point3D>> _0023_003Dztj_00245joP3GSIE, Point3D _0023_003Dz689iTwgBibCe, Point3D _0023_003DzIzngpRDqJiq7, double _0023_003Dz_ZutUfPX8vPU, bool _0023_003DzNK_0024wFLs_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, double _0023_003DzkRSfKls1SLfn) where T : Solid, new()
		{
			if (Math.Abs(_0023_003Dz_ZutUfPX8vPU) < 1E-06)
			{
				return null;
			}
			if (_0023_003Dz_ZutUfPX8vPU > Math.PI * 2.0)
			{
				_0023_003Dz_ZutUfPX8vPU = Math.PI * 2.0;
			}
			if (_0023_003Dz_ZutUfPX8vPU < Math.PI * -2.0)
			{
				_0023_003Dz_ZutUfPX8vPU = Math.PI * -2.0;
			}
			bool flag = false;
			if (_0023_003DzrAOtYIs_003D.Count > 2)
			{
				flag = true;
			}
			Vector3D vector3D = new Vector3D();
			if (flag)
			{
				vector3D = Utility.FitPlane(_0023_003DzrAOtYIs_003D).AxisZ;
			}
			else
			{
				Point3D point3D = new Point3D(_0023_003DzrAOtYIs_003D[0].X, _0023_003DzrAOtYIs_003D[0].Y, _0023_003DzrAOtYIs_003D[0].Z);
				Point3D _0023_003DzjdeMMkk_003D = new Point3D(_0023_003DzrAOtYIs_003D[1].X, _0023_003DzrAOtYIs_003D[1].Y, _0023_003DzrAOtYIs_003D[1].Z);
				if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzQ_0024aXDFOrP7sJ(point3D, _0023_003DzjdeMMkk_003D, _0023_003Dz689iTwgBibCe) && _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzQ_0024aXDFOrP7sJ(point3D, _0023_003DzjdeMMkk_003D, _0023_003DzIzngpRDqJiq7))
				{
					return null;
				}
				vector3D = new Plane(_0023_003Dz689iTwgBibCe, _0023_003DzIzngpRDqJiq7, point3D).AxisZ;
			}
			Point3D point3D2 = new Point3D(_0023_003Dz689iTwgBibCe.X, _0023_003Dz689iTwgBibCe.Y, _0023_003Dz689iTwgBibCe.Z);
			Point3D point3D3 = new Point3D(_0023_003DzIzngpRDqJiq7.X, _0023_003DzIzngpRDqJiq7.Y, _0023_003DzIzngpRDqJiq7.Z);
			Point3D asPoint = vector3D.AsPoint;
			Transformation transformation = new Transformation();
			transformation.Translation(0.0 - point3D2.X, 0.0 - point3D2.Y, 0.0 - point3D2.Z);
			Point3D point3D4 = point3D3 - point3D2;
			transformation = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzRGGde2eEYTPn(transformation, point3D4);
			point3D4.X = (point3D4.Y = (point3D4.Z = 0.0));
			point3D4 = transformation * point3D4;
			Point3D point3D5 = transformation * asPoint - point3D4;
			double num = Math.Atan2(point3D5.Y, point3D5.X);
			transformation = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dzyd5VPwzBzlhM(transformation, -3, Math.PI / 2.0 - num);
			if (!_0023_003DzWoOjy1fl2v7tRf1_Dvprg6E_003D(_0023_003DzrAOtYIs_003D, ref transformation, _0023_003DzNK_0024wFLs_003D, _0023_003DzkRSfKls1SLfn))
			{
				return null;
			}
			if (_0023_003DzAPBIJmvn5i5Q < 3)
			{
				_0023_003DzAPBIJmvn5i5Q = 3;
			}
			Solid solid = new Solid();
			List<brepType> list = new List<brepType>();
			if (!_0023_003Dzgwc8HN9v1Pdt(_0023_003DzrAOtYIs_003D, _0023_003Dztj_00245joP3GSIE, _0023_003Dz_ZutUfPX8vPU, _0023_003DzNK_0024wFLs_003D, 0, transformation, list, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003DzAPBIJmvn5i5Q, solid, _0023_003DzkRSfKls1SLfn))
			{
				return null;
			}
			Transformation transformation2 = new Transformation();
			_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzTbbOqnY_003D(transformation2, transformation.Matrix);
			for (int i = 0; i < solid.portions.Count; i++)
			{
				Portion portion = solid.portions[i];
				for (int j = 0; j < portion.vertexCount; j++)
				{
					portion._vertices[j] = transformation2 * portion._vertices[j];
				}
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion);
			}
			T[] array = new T[list.Count];
			for (int k = 0; k < list.Count; k++)
			{
				brepType _0023_003DzGEIcT40b_0024_0024pyxr5Kxg_003D_003D = list[k];
				T val = new T();
				val._0023_003DzfD12v8o3kSVM(_0023_003DzGEIcT40b_0024_0024pyxr5Kxg_003D_003D);
				val._0023_003DzTvFaOE1Y6EnS(solid, _0023_003Dzu9oxwJ_zKlMt: false);
				array[k] = val;
			}
			return array[0];
		}

		internal static void _0023_003DzVoQS_BVEn1Zl(Portion _0023_003Dz5Tpjxj5wp_0024R8, double _0023_003Dz6pajdGM_003D)
		{
			for (int i = 1; i <= _0023_003Dz5Tpjxj5wp_0024R8.edgeCount; i++)
			{
				if (_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextFace != 0 && _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousFace != 0)
				{
					float num = 0f;
					if (_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextFace < 0)
					{
						num = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[-_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextFace].Angle;
					}
					if (_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousFace < 0)
					{
						num = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[-_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousFace].Angle;
					}
					if (num == 0f)
					{
						int previousFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousFace;
						int nextFace = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextFace;
						num = _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzSLyKdRKkR7Vx(_0023_003Dz5Tpjxj5wp_0024R8, i, _0023_003Dz5Tpjxj5wp_0024R8.planes[nextFace], _0023_003Dz5Tpjxj5wp_0024R8.planes[previousFace]);
					}
					if (Utility.AreEqual(num, Math.PI, Math.PI * 2.0))
					{
						_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].Type = 8;
					}
					else if ((double)num < Math.PI - _0023_003Dz6pajdGM_003D || (double)num > _0023_003Dz6pajdGM_003D + Math.PI)
					{
						_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].Type = 1;
					}
					else
					{
						_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].Type = 4;
					}
				}
			}
		}

		public static Solid _0023_003DzFPVyG4Y9TGyH(IList<Point3D> _0023_003DzrAOtYIs_003D, IList<IList<Point3D>> _0023_003Dztj_00245joP3GSIE, Vector3D _0023_003Dzc7CTO_0024MgFpeW, bool _0023_003DzNK_0024wFLs_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, double _0023_003DzkRSfKls1SLfn)
		{
			if (!new Vector3D(_0023_003Dzc7CTO_0024MgFpeW.X, _0023_003Dzc7CTO_0024MgFpeW.Y, _0023_003Dzc7CTO_0024MgFpeW.Z).Normalize())
			{
				return null;
			}
			List<List<MNODE>> _0023_003DziMFfvnaiZdZU = _0023_003DzmsgMyWjy5z_7(_0023_003DzrAOtYIs_003D, _0023_003Dztj_00245joP3GSIE, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D);
			Transformation transformation = new Transformation();
			transformation.Translation(_0023_003Dzc7CTO_0024MgFpeW.X, _0023_003Dzc7CTO_0024MgFpeW.Y, _0023_003Dzc7CTO_0024MgFpeW.Z);
			Solid solid = new Solid();
			List<brepType> list = new List<brepType>();
			if (!_0023_003DzbVnsBkMm2Dz_00247SYT1A_003D_003D(_0023_003DziMFfvnaiZdZU, 0, transformation, solid, _0023_003DzNK_0024wFLs_003D, list, _0023_003DzkRSfKls1SLfn))
			{
				return null;
			}
			for (int i = 0; i < solid.portions.Count; i++)
			{
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(solid.portions[i]);
			}
			Solid[] array = new Solid[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				Solid solid2 = new Solid(list[j] == brepType.Body);
				solid2._0023_003DzTvFaOE1Y6EnS(solid, _0023_003Dzu9oxwJ_zKlMt: false);
				array[j] = solid2;
			}
			return array[0];
		}

		public static T _0023_003DzFPVyG4Y9TGyH<T>(IList<Point3D> _0023_003DzrAOtYIs_003D, IList<IList<Point3D>> _0023_003Dztj_00245joP3GSIE, Vector3D _0023_003Dzc7CTO_0024MgFpeW, bool _0023_003DzNK_0024wFLs_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, double _0023_003DzkRSfKls1SLfn) where T : Solid, new()
		{
			if (!new Vector3D(_0023_003Dzc7CTO_0024MgFpeW.X, _0023_003Dzc7CTO_0024MgFpeW.Y, _0023_003Dzc7CTO_0024MgFpeW.Z).Normalize())
			{
				return null;
			}
			List<List<MNODE>> _0023_003DziMFfvnaiZdZU = _0023_003DzmsgMyWjy5z_7(_0023_003DzrAOtYIs_003D, _0023_003Dztj_00245joP3GSIE, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D);
			Transformation transformation = new Transformation();
			transformation.Translation(_0023_003Dzc7CTO_0024MgFpeW.X, _0023_003Dzc7CTO_0024MgFpeW.Y, _0023_003Dzc7CTO_0024MgFpeW.Z);
			T val = new T();
			List<brepType> list = new List<brepType>();
			if (!_0023_003DzbVnsBkMm2Dz_00247SYT1A_003D_003D(_0023_003DziMFfvnaiZdZU, 0, transformation, val, _0023_003DzNK_0024wFLs_003D, list, _0023_003DzkRSfKls1SLfn))
			{
				return null;
			}
			for (int i = 0; i < val.portions.Count; i++)
			{
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(val.portions[i]);
			}
			T[] array = new T[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				brepType _0023_003DzGEIcT40b_0024_0024pyxr5Kxg_003D_003D = list[j];
				T val2 = new T();
				val2._0023_003DzfD12v8o3kSVM(_0023_003DzGEIcT40b_0024_0024pyxr5Kxg_003D_003D);
				val2._0023_003DzFiTFoZw_003D(val);
				array[j] = val2;
			}
			return array[0];
		}

		private static List<List<MNODE>> _0023_003DzmsgMyWjy5z_7(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
		{
			List<List<MNODE>> list = new List<List<MNODE>>();
			list.Add(_0023_003DzrBfrm945TRsE(_0023_003Dz_SqBXz8_003D, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D));
			if (_0023_003DzWaFlkhfmYCja != null)
			{
				for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
				{
					list.Add(_0023_003DzrBfrm945TRsE(_0023_003DzWaFlkhfmYCja[i], _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D));
				}
			}
			return list;
		}

		private static List<MNODE> _0023_003DzrBfrm945TRsE(IList<Point3D> _0023_003DzCRq4LBU_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
		{
			if (_0023_003DzCRq4LBU_003D[0] == _0023_003DzCRq4LBU_003D[_0023_003DzCRq4LBU_003D.Count - 1])
			{
				return _0023_003Dz6QKBQMYb2_00244u81IDZQ_003D_003D(_0023_003DzCRq4LBU_003D, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D);
			}
			return _0023_003DzlECqIW5QkBuTxziNZQ_003D_003D(_0023_003DzCRq4LBU_003D, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D);
		}

		private static List<MNODE> _0023_003Dz6QKBQMYb2_00244u81IDZQ_003D_003D(IList<Point3D> _0023_003DzrAOtYIs_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
		{
			List<MNODE> list = new List<MNODE>(_0023_003DzrAOtYIs_003D.Count);
			for (int i = 0; i < _0023_003DzrAOtYIs_003D.Count; i++)
			{
				Point3D _0023_003Dz1BPEjBg_003D = _0023_003DzrAOtYIs_003D[(i > 0) ? (i - 1) : (_0023_003DzrAOtYIs_003D.Count - 2)];
				Point3D _0023_003DzvmFFjUs_003D = _0023_003DzrAOtYIs_003D[(i >= _0023_003DzrAOtYIs_003D.Count - 1) ? 1 : (i + 1)];
				list.Add(_0023_003DzUO3ZY9Q_003D(_0023_003DzrAOtYIs_003D[i], _0023_003Dz1BPEjBg_003D, _0023_003DzvmFFjUs_003D, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D));
			}
			return list;
		}

		private static List<MNODE> _0023_003DzlECqIW5QkBuTxziNZQ_003D_003D(IList<Point3D> _0023_003DzrAOtYIs_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
		{
			List<MNODE> list = new List<MNODE>(_0023_003DzrAOtYIs_003D.Count);
			list.Add(new MNODE(_0023_003DzrAOtYIs_003D[0], 1));
			for (int i = 1; i < _0023_003DzrAOtYIs_003D.Count - 1; i++)
			{
				Point3D _0023_003Dz1BPEjBg_003D = _0023_003DzrAOtYIs_003D[i - 1];
				Point3D _0023_003DzvmFFjUs_003D = _0023_003DzrAOtYIs_003D[i + 1];
				list.Add(_0023_003DzUO3ZY9Q_003D(_0023_003DzrAOtYIs_003D[i], _0023_003Dz1BPEjBg_003D, _0023_003DzvmFFjUs_003D, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D));
			}
			list.Add(new MNODE(_0023_003DzrAOtYIs_003D[_0023_003DzrAOtYIs_003D.Count - 1], 1));
			return list;
		}

		private static MNODE _0023_003DzUO3ZY9Q_003D(Point3D _0023_003DzMlCq3wk_003D, Point3D _0023_003Dz1BPEjBg_003D, Point3D _0023_003DzvmFFjUs_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
		{
			Vector3D vector3D = Vector3D.Subtract(_0023_003DzMlCq3wk_003D, _0023_003Dz1BPEjBg_003D);
			Vector3D vector3D2 = Vector3D.Subtract(_0023_003DzvmFFjUs_003D, _0023_003DzMlCq3wk_003D);
			vector3D.Normalize();
			vector3D2.Normalize();
			int _0023_003DzkXQ_IWk_003D = ((!(Math.Abs(Vector3D.AngleBetween(vector3D, vector3D2)) > _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)) ? 1 : 4);
			return new MNODE(_0023_003DzMlCq3wk_003D, _0023_003DzkXQ_IWk_003D);
		}

		private static bool _0023_003DzbVnsBkMm2Dz_00247SYT1A_003D_003D(List<List<MNODE>> _0023_003DziMFfvnaiZdZU, int _0023_003DzEKSHIVc_003D, Transformation _0023_003DzGXR_0024mdnjxOPn, Solid _0023_003DzcDEsV8s_003D, bool _0023_003DzNK_0024wFLs_003D, List<brepType> _0023_003Dz0SpZWCCz_qrn, double _0023_003DzkRSfKls1SLfn)
		{
			int _0023_003DzSkUy_T8_003D = -32767;
			List<MNODE> list = new List<MNODE>();
			if (_0023_003DzNK_0024wFLs_003D)
			{
				Portion portion = new Portion();
				portion.Id = _0023_003DzSkUy_T8_003D++;
				if (!_0023_003DzIuGGzIw1_x1t(portion, _0023_003DziMFfvnaiZdZU))
				{
					return false;
				}
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion))
				{
					return false;
				}
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003DzcDEsV8s_003D))
				{
					return false;
				}
				portion = (Portion)portion.Clone();
				portion.Id = _0023_003DzSkUy_T8_003D++;
				for (int i = 0; i < portion.vertexCount; i++)
				{
					portion._vertices[i] = _0023_003DzGXR_0024mdnjxOPn * portion._vertices[i];
				}
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion))
				{
					return false;
				}
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003DzcDEsV8s_003D))
				{
					return false;
				}
			}
			for (int j = 0; j < _0023_003DziMFfvnaiZdZU.Count; j++)
			{
				list.Clear();
				List<MNODE> list2 = _0023_003DziMFfvnaiZdZU[j];
				if (!_0023_003DzdbnZmXdZ9YqCK9NP1w_003D_003D(list, list2, _0023_003DzGXR_0024mdnjxOPn))
				{
					return false;
				}
				new _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D(list)._0023_003DzKlS_0024RTSkHohzMAAySQ_003D_003D(_0023_003DzcDEsV8s_003D, ref _0023_003DzSkUy_T8_003D, list2.Count, 2, 0.0, _0023_003DzkRSfKls1SLfn);
			}
			return _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzaiGd92G_0024D4Zt(_0023_003DzcDEsV8s_003D, _0023_003Dz0SpZWCCz_qrn, _0023_003DzkRSfKls1SLfn);
		}

		private static bool _0023_003DzR8fV_0024B0UEJc_0024(List<List<MNODE>> _0023_003Dz0TCUNd74r2Ei, List<List<Point3D>> _0023_003Dz94TuFVjJtURU)
		{
			return true;
		}

		private static bool _0023_003DzIuGGzIw1_x1t(Portion _0023_003Dz5Tpjxj5wp_0024R8, List<List<MNODE>> _0023_003DziMFfvnaiZdZU)
		{
			_0023_003Dz5Tpjxj5wp_0024R8.vertexCount = (_0023_003Dz5Tpjxj5wp_0024R8.edgeCount = (_0023_003Dz5Tpjxj5wp_0024R8.contourCount = (_0023_003Dz5Tpjxj5wp_0024R8.faceCount = 0)));
			for (int i = 0; i < _0023_003DziMFfvnaiZdZU.Count; i++)
			{
				List<MNODE> list = _0023_003DziMFfvnaiZdZU[i];
				int _0023_003Dzz0uHmgQx0Kwi = _0023_003Dz5Tpjxj5wp_0024R8.vertexCount - 1;
				if (_0023_003Dz5Tpjxj5wp_0024R8.vertexCount + list.Count > _0023_003Dz5Tpjxj5wp_0024R8.MaxNov && !_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzyhwfZUNTBTiB(_0023_003Dz5Tpjxj5wp_0024R8, list.Count))
				{
					return false;
				}
				for (int j = 0; j < list.Count - 1; j++)
				{
					MNODE mNODE = list[j];
					_0023_003Dz5Tpjxj5wp_0024R8._vertices[_0023_003Dz5Tpjxj5wp_0024R8.vertexCount++] = new Point3D(mNODE.X, mNODE.Y, mNODE.Z);
				}
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzm0RN0lGJV9LwEZnPqA_003D_003D(_0023_003Dz5Tpjxj5wp_0024R8, list.Count, _0023_003Dzz0uHmgQx0Kwi);
			}
			_0023_003Dz5Tpjxj5wp_0024R8.faces[1].FaceLabel |= 1;
			return true;
		}

		private static bool _0023_003DzdbnZmXdZ9YqCK9NP1w_003D_003D(List<MNODE> _0023_003DzSY5mkEzHFGNyG5lSuw_003D_003D, List<MNODE> _0023_003DzcDEsV8s_003D, Transformation _0023_003DzGXR_0024mdnjxOPn)
		{
			for (int i = 0; i < _0023_003DzcDEsV8s_003D.Count; i++)
			{
				MNODE mNODE = _0023_003DzcDEsV8s_003D[i];
				int _0023_003Dz4Dqaxfw_003D = 0;
				if ((mNODE.num & 1) <= 0)
				{
					_0023_003Dz4Dqaxfw_003D = 32768;
				}
				if (!_0023_003DzXFRGwpJnFeEWFm4l8w_003D_003D(_0023_003DzSY5mkEzHFGNyG5lSuw_003D_003D, mNODE, _0023_003DzGXR_0024mdnjxOPn, _0023_003Dz4Dqaxfw_003D))
				{
					return false;
				}
			}
			return true;
		}

		private static bool _0023_003DzXFRGwpJnFeEWFm4l8w_003D_003D(List<MNODE> _0023_003DzSY5mkEzHFGNyG5lSuw_003D_003D, Point3D _0023_003Dz77g161c_003D, Transformation _0023_003DzGXR_0024mdnjxOPn, int _0023_003Dz4Dqaxfw_003D)
		{
			MNODE item = new MNODE(new Point3D(_0023_003Dz77g161c_003D.X, _0023_003Dz77g161c_003D.Y, _0023_003Dz77g161c_003D.Z), _0023_003Dz4Dqaxfw_003D | 0x4000);
			_0023_003DzSY5mkEzHFGNyG5lSuw_003D_003D.Add(item);
			Point3D point3D = _0023_003DzGXR_0024mdnjxOPn * _0023_003Dz77g161c_003D;
			item = new MNODE(new Point3D(point3D.X, point3D.Y, point3D.Z), _0023_003Dz4Dqaxfw_003D | 0x4000);
			_0023_003DzSY5mkEzHFGNyG5lSuw_003D_003D.Add(item);
			return true;
		}

		private static bool _0023_003Dzgwc8HN9v1Pdt(IList<Point3D> _0023_003Dzfqtprvo_003D, IList<IList<Point3D>> _0023_003Dztj_00245joP3GSIE, double _0023_003DzYPYH4NA_003D, bool _0023_003DzNK_0024wFLs_003D, int _0023_003DzEKSHIVc_003D, Transformation _0023_003DzGXR_0024mdnjxOPn, List<brepType> _0023_003Dz0SpZWCCz_qrn, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, int _0023_003DzAPBIJmvn5i5Q, Solid _0023_003Dz6zsUs9k_003D, double _0023_003DzkRSfKls1SLfn)
		{
			int _0023_003DzSkUy_T8_003D = -32767;
			List<MNODE> list = new List<MNODE>();
			List<List<MNODE>> list2 = _0023_003DzmsgMyWjy5z_7(_0023_003Dzfqtprvo_003D, _0023_003Dztj_00245joP3GSIE, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D);
			for (int i = 0; i < list2.Count; i++)
			{
				List<MNODE> list3 = list2[i];
				for (int j = 0; j < list3.Count; j++)
				{
					Point3D point3D = list3[j];
					point3D = _0023_003DzGXR_0024mdnjxOPn * point3D;
					MNODE mNODE = list3[j];
					mNODE.X = point3D.X;
					mNODE.Y = point3D.Y;
					mNODE.Z = point3D.Z;
				}
			}
			if (_0023_003DzNK_0024wFLs_003D)
			{
				Portion portion = new Portion();
				portion.Id = _0023_003DzSkUy_T8_003D++;
				if (!_0023_003DzIuGGzIw1_x1t(portion, list2))
				{
					return false;
				}
				Transformation transformation = new Transformation();
				transformation.Identity();
				transformation = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dzyd5VPwzBzlhM(transformation, -3, _0023_003DzYPYH4NA_003D);
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion))
				{
					return false;
				}
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003Dz6zsUs9k_003D))
				{
					return false;
				}
				portion = (Portion)portion.Clone();
				portion.Id = _0023_003DzSkUy_T8_003D++;
				for (int k = 0; k < portion.vertexCount; k++)
				{
					portion._vertices[k] = transformation * portion._vertices[k];
				}
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion))
				{
					return false;
				}
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003Dz6zsUs9k_003D))
				{
					return false;
				}
			}
			for (int l = 0; l < list2.Count; l++)
			{
				List<MNODE> list4 = list2[l];
				int _0023_003DzoRwlZ6XMh0PR = 0;
				if (!_0023_003Dzpq_00247ek44cwe38V5_Ig_003D_003D(list, list4, _0023_003DzYPYH4NA_003D, _0023_003DzAPBIJmvn5i5Q, ref _0023_003DzoRwlZ6XMh0PR))
				{
					return false;
				}
				new _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D(list)._0023_003DzKlS_0024RTSkHohzMAAySQ_003D_003D(_0023_003Dz6zsUs9k_003D, ref _0023_003DzSkUy_T8_003D, list4.Count, _0023_003DzoRwlZ6XMh0PR + 1, 0.0, _0023_003DzkRSfKls1SLfn);
			}
			return _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzaiGd92G_0024D4Zt(_0023_003Dz6zsUs9k_003D, _0023_003Dz0SpZWCCz_qrn, _0023_003DzkRSfKls1SLfn);
		}

		private static bool _0023_003Dzpq_00247ek44cwe38V5_Ig_003D_003D(List<MNODE> _0023_003DzOKlEF9YJIfeA, List<MNODE> _0023_003DzhOmIJkrNkF_o, double _0023_003DzYPYH4NA_003D, int _0023_003DzAPBIJmvn5i5Q, ref int _0023_003DzoRwlZ6XMh0PR)
		{
			_0023_003DzOKlEF9YJIfeA.Clear();
			_0023_003DzoRwlZ6XMh0PR = _0023_003DzAPBIJmvn5i5Q;
			if (_0023_003DzoRwlZ6XMh0PR == 0)
			{
				_0023_003DzoRwlZ6XMh0PR = 1;
			}
			for (int i = 0; i < _0023_003DzhOmIJkrNkF_o.Count; i++)
			{
				MNODE mNODE = _0023_003DzhOmIJkrNkF_o[i];
				int _0023_003Dz4Dqaxfw_003D = 0;
				if ((mNODE.num & 1) <= 0)
				{
					_0023_003Dz4Dqaxfw_003D = 32768;
				}
				if (!_0023_003Dz827yNjgKx_gp(_0023_003DzOKlEF9YJIfeA, mNODE, _0023_003DzoRwlZ6XMh0PR, _0023_003DzYPYH4NA_003D, _0023_003Dz4Dqaxfw_003D))
				{
					return false;
				}
			}
			return true;
		}

		private static bool _0023_003Dz827yNjgKx_gp(List<MNODE> _0023_003DzOKlEF9YJIfeA, Point3D _0023_003DzB68dg9Q_003D, int _0023_003DzoRwlZ6XMh0PR, double _0023_003DzAVGomKsvBFKS, int _0023_003Dz4Dqaxfw_003D)
		{
			double num = _0023_003DzAVGomKsvBFKS / (double)_0023_003DzoRwlZ6XMh0PR;
			Math.Sqrt(_0023_003DzB68dg9Q_003D.X * _0023_003DzB68dg9Q_003D.X + _0023_003DzB68dg9Q_003D.Y * _0023_003DzB68dg9Q_003D.Y);
			for (short num2 = 0; num2 <= _0023_003DzoRwlZ6XMh0PR; num2++)
			{
				double _0023_003DzbvIFYko_003D = ((num2 == _0023_003DzoRwlZ6XMh0PR) ? _0023_003DzAVGomKsvBFKS : (num * (double)num2));
				Transformation transformation = new Transformation();
				transformation.Identity();
				MNODE item = new MNODE(_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dzyd5VPwzBzlhM(transformation, -3, _0023_003DzbvIFYko_003D) * _0023_003DzB68dg9Q_003D, _0023_003Dz4Dqaxfw_003D);
				_0023_003DzOKlEF9YJIfeA.Add(item);
			}
			return true;
		}

		private static bool _0023_003DzWoOjy1fl2v7tRf1_Dvprg6E_003D(IList<Point3D> _0023_003Dzfqtprvo_003D, ref Transformation _0023_003DztpPn7bNgaXIp, bool _0023_003Dz8l3HSCIzwifX, double _0023_003DzkRSfKls1SLfn)
		{
			bool flag = false;
			int num = 1;
			int num2 = 0;
			for (int i = 0; i < _0023_003Dzfqtprvo_003D.Count; i++)
			{
				Point3D point3D = _0023_003Dzfqtprvo_003D[i];
				Point3D point3D2 = _0023_003DztpPn7bNgaXIp * point3D;
				if (Math.Abs(point3D2.X) < _0023_003DzkRSfKls1SLfn)
				{
					if (_0023_003Dz8l3HSCIzwifX || (i != 0 && i < _0023_003Dzfqtprvo_003D.Count - 1))
					{
						return false;
					}
					num2++;
				}
				else if (point3D2.X * (double)num < 0.0)
				{
					if (flag || num != 1)
					{
						return false;
					}
					num = -1;
					flag = true;
				}
			}
			if (num == -1)
			{
				_0023_003DztpPn7bNgaXIp = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dzyd5VPwzBzlhM(_0023_003DztpPn7bNgaXIp, -3, Math.PI);
			}
			return true;
		}
	}

	internal enum _0023_003DzcN_0024QFaNptb5t
	{

	}

	internal sealed class _0023_003DzcotKewV4gD8LAT2hHQ_003D_003D : IComparer<Portion>
	{
		public int Compare(Portion _0023_003DzFj_0024IqDQ_003D, Portion _0023_003DzjdeMMkk_003D)
		{
			return Utility.Compare(0.0, _0023_003DzFj_0024IqDQ_003D.Id, _0023_003DzjdeMMkk_003D.Id);
		}
	}

	internal sealed class _0023_003Dzd1_0024NwM3DiRKw
	{
		public _0023_003Dzfile4ZpfGZE6f1uDBw_003D_003D[] _0023_003DzRIfswZZzGQPy;

		public _0023_003Dzd1_0024NwM3DiRKw()
		{
			_0023_003DzRIfswZZzGQPy = null;
		}

		public _0023_003Dzfile4ZpfGZE6f1uDBw_003D_003D _0023_003DzMabsryO_0024HF2_(int _0023_003Dzd9iQ6RyJI3P8)
		{
			return _0023_003DzRIfswZZzGQPy[_0023_003Dzd9iQ6RyJI3P8];
		}

		public int _0023_003DzLSQlrQLYphsl()
		{
			return _0023_003DzRIfswZZzGQPy.Length;
		}
	}

	internal sealed class _0023_003Dzfile4ZpfGZE6f1uDBw_003D_003D
	{
		public Point3D[] _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D;

		public int _0023_003DzkeuNDwc_003D;

		public _0023_003DzO5skTHYyevUSqcd1wpqILIE_003D[] _0023_003DzU4XYawo_003D;

		public int _0023_003DzRnF_0024lvc_003D;

		public Point3D _0023_003DzZqSqKm8_003D;

		public Point3D _0023_003DztvD0Jdc_003D;

		public Point3D[] _0023_003Dz5qFihJK3ui08U0cFuA_003D_003D()
		{
			return _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D;
		}

		public int _0023_003DzsJvIQ0hGMGIl()
		{
			return _0023_003DzkeuNDwc_003D;
		}

		public int _0023_003DzKFQNVxJ92DKD()
		{
			return _0023_003DzRnF_0024lvc_003D;
		}

		public _0023_003DzO5skTHYyevUSqcd1wpqILIE_003D[] _0023_003Dzx_00247mD_0024g_003D()
		{
			return _0023_003DzU4XYawo_003D;
		}
	}

	internal enum _0023_003Dzj54PKAI_003D
	{

	}

	internal enum _0023_003DzmLfCMKgnNVr9
	{

	}

	[Serializable]
	public struct Cycle(int firstEdge, int nextContour)
	{
		public int FirstEdge = firstEdge;

		public int NextContour = nextContour;

		internal CycleSurrogate _0023_003Dz_0024xHo97pGU7zE()
		{
			return new CycleSurrogate(this);
		}
	}

	[Serializable]
	public struct EdgeData
	{
		public int BeginVertex;

		public int EndVertex;

		public int Type;

		public int NextFace;

		public int NextEdge;

		public int PreviousFace;

		public int PreviousEdge;

		public float Angle;

		[Obsolete("Use the constructor that accepts the float as angle.")]
		public EdgeData(int beginVertex, int endVertex, int type, int previousEdge, int nextEdge, int previousFace, int nextFace, int angle)
		{
			BeginVertex = beginVertex;
			EndVertex = endVertex;
			Type = type;
			NextFace = nextFace;
			PreviousFace = previousFace;
			NextEdge = nextEdge;
			PreviousEdge = previousEdge;
			Angle = angle;
		}

		public EdgeData(int beginVertex, int endVertex, int type, int previousEdge, int nextEdge, int previousFace, int nextFace, float angle)
		{
			BeginVertex = beginVertex;
			EndVertex = endVertex;
			Type = type;
			NextFace = nextFace;
			PreviousFace = previousFace;
			NextEdge = nextEdge;
			PreviousEdge = previousEdge;
			Angle = angle;
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977345), BeginVertex, EndVertex, Type, NextFace, PreviousFace, NextEdge, PreviousEdge, Angle);
		}

		internal EdgeDataSurrogate _0023_003Dz_0024xHo97pGU7zE()
		{
			return new EdgeDataSurrogate(this);
		}
	}

	[Serializable]
	public struct EdgeFace(int previousEdge, int nextEdge, int previousFace, int nextFace)
	{
		public int NextFace = nextFace;

		public int NextEdge = nextEdge;

		public int PreviousFace = previousFace;

		public int PreviousEdge = previousEdge;

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977288), PreviousEdge, NextEdge, PreviousFace, NextFace);
		}
	}

	[Serializable]
	public struct Face(int firstContour, int faceLabel)
	{
		public int FirstContour = firstContour;

		public int FaceLabel = faceLabel;

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977515), FirstContour, FaceLabel);
		}

		internal FaceSurrogate _0023_003Dz_0024xHo97pGU7zE()
		{
			return new FaceSurrogate(this);
		}
	}

	[Serializable]
	public class Portion : Mesh
	{
		private sealed class _0023_003DzJX25Vanpz2BZ : _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public int _0023_003DzhNQLY4s_003D;

			public _0023_003DzJX25Vanpz2BZ(int _0023_003DzhNQLY4s_003D, int _0023_003Dzn9evOUnMw8vS, Point2D _0023_003DzMlCq3wk_003D)
				: base(_0023_003Dzn9evOUnMw8vS, _0023_003DzMlCq3wk_003D)
			{
				this._0023_003DzhNQLY4s_003D = _0023_003DzhNQLY4s_003D;
			}

			public static int _0023_003Dzwz6CZyI_003D(_0023_003DzJX25Vanpz2BZ _0023_003DzFj_0024IqDQ_003D, _0023_003DzJX25Vanpz2BZ _0023_003DzjdeMMkk_003D)
			{
				if (_0023_003DzFj_0024IqDQ_003D._0023_003DzIHt45I8_003D.X > _0023_003DzjdeMMkk_003D._0023_003DzIHt45I8_003D.X)
				{
					return 1;
				}
				if (_0023_003DzFj_0024IqDQ_003D._0023_003DzIHt45I8_003D.X < _0023_003DzjdeMMkk_003D._0023_003DzIHt45I8_003D.X)
				{
					return -1;
				}
				if (_0023_003DzFj_0024IqDQ_003D._0023_003DzIHt45I8_003D.Y > _0023_003DzjdeMMkk_003D._0023_003DzIHt45I8_003D.Y)
				{
					return 1;
				}
				if (_0023_003DzFj_0024IqDQ_003D._0023_003DzIHt45I8_003D.Y < _0023_003DzjdeMMkk_003D._0023_003DzIHt45I8_003D.Y)
				{
					return -1;
				}
				return 0;
			}
		}

		private static class _0023_003DzQm9ltrs_003D
		{
			public static Comparison<_0023_003DzJX25Vanpz2BZ> _0023_003DzIjHKqV_bjGx2;
		}

		private int _ident;

		internal int vertexCount;

		internal int edgeCount;

		internal int faceCount;

		internal int contourCount;

		internal int MaxNov;

		internal int MaxNoe;

		internal int MaxNof;

		internal int MaxNoc;

		internal int novTemp;

		internal EdgeData[] edgeDatas;

		internal Face[] faces;

		internal Cycle[] cycles;

		internal PlaneEquation[] planes;

		internal BoolUser[] user;

		internal List<IndexLine> isoCurves;

		public int Id
		{
			get
			{
				return _ident;
			}
			set
			{
				_ident = value;
			}
		}

		public int VertexCount => vertexCount;

		public int FaceCount => faceCount;

		public EdgeData[] EdgeDatas
		{
			get
			{
				int num = edgeCount + 1;
				EdgeData[] array = new EdgeData[num];
				Array.Copy(edgeDatas, array, num);
				return array;
			}
		}

		public new Face[] Faces
		{
			get
			{
				int num = faceCount + 1;
				Face[] array = new Face[num];
				Array.Copy(faces, array, num);
				return array;
			}
		}

		public Cycle[] Cycles
		{
			get
			{
				int num = contourCount + 1;
				Cycle[] array = new Cycle[num];
				Array.Copy(cycles, array, num);
				return array;
			}
		}

		public new Point3D[] Vertices
		{
			get
			{
				int num = vertexCount;
				Point3D[] array = new Point3D[num];
				Array.Copy(_vertices, array, num);
				return array;
			}
		}

		public new IndexLine[] Edges
		{
			get
			{
				List<IndexLine> list = new List<IndexLine>();
				for (int i = 1; i <= edgeCount; i++)
				{
					EdgeData edgeData = edgeDatas[i];
					if ((edgeData.Type & 1) != 0)
					{
						list.Add(new IndexLine(edgeData.BeginVertex, edgeData.EndVertex));
					}
				}
				return list.ToArray();
			}
		}

		internal Portion()
			: this(250, 400, 202, 222)
		{
		}

		internal Portion(int _0023_003DzkzzM_0024xtmV7oJ, int _0023_003DzDKYv6rE8Csvm, int _0023_003DziX_o0jwV1tOe, int _0023_003DzT1XlvL32Kect)
			: base(natureType.Smooth, edgeStyleType.Sharp)
		{
			_0023_003DzMWYnHjivad6tXtcHtA_003D_003D(_0023_003DzkzzM_0024xtmV7oJ, _0023_003DzDKYv6rE8Csvm, _0023_003DziX_o0jwV1tOe, _0023_003DzT1XlvL32Kect);
		}

		protected Portion(Portion another, bool keepTessellation = false)
			: base(another, keepTessellation)
		{
			_vertices = new Point3D[another._vertices.Length];
			edgeDatas = new EdgeData[another.edgeDatas.Length];
			faces = new Face[another.faces.Length];
			user = new BoolUser[another.user.Length];
			cycles = new Cycle[another.cycles.Length];
			planes = new PlaneEquation[another.faces.Length];
			planes[0] = new PlaneEquation();
			_0023_003DzDBrp9S8_003D(another);
			if (!keepTessellation)
			{
				return;
			}
			isoCurves = new List<IndexLine>(another.isoCurves.Count);
			foreach (IndexLine isoCurf in another.isoCurves)
			{
				isoCurves.Add((IndexLine)isoCurf.Clone());
			}
		}

		public Portion(EdgeData[] edgeDatas, Face[] faces, Cycle[] cycles, Point3D[] vertices, int id)
			: this(250, 400, 202, 222)
		{
			Id = id;
			_0023_003DzDBrp9S8_003D(edgeDatas, faces, cycles, null, null, vertices, Id, vertices.Length, 250, edgeDatas.Length - 1, faces.Length - 1, cycles.Length - 1, null, null, 250, 400, 202, 222);
			_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(this);
		}

		protected internal Portion(PortionSurrogate surrogate)
			: this(surrogate.MaxNov, surrogate.MaxNoe, surrogate.MaxNof, surrogate.MaxNoc)
		{
			EdgeData[] _0023_003DzkU17_ynt7LPR_002421QuA_003D_003D = surrogate.GetEdgeDatas();
			Face[] _0023_003DzIUxqWHN_1LWs = surrogate.GetFaces();
			Cycle[] _0023_003DzoRZm5nS2PGzX = surrogate.GetCycles();
			Point3D[] vertices = surrogate.GetVertices();
			int id = surrogate.GetId();
			_0023_003DzDBrp9S8_003D(_0023_003DzkU17_ynt7LPR_002421QuA_003D_003D, _0023_003DzIUxqWHN_1LWs, _0023_003DzoRZm5nS2PGzX, null, null, vertices, id, surrogate.vertexCount, surrogate.novTemp, surrogate.edgeCount, surrogate.faceCount, surrogate.contourCount, null, null, surrogate.MaxNov, surrogate.MaxNoe, surrogate.MaxNof, surrogate.MaxNoc);
			_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(this);
		}

		internal Portion(GSolid.Portion _0023_003DzQwa1qM0_003D)
			: this()
		{
			_meshNature = _0023_003DzQwa1qM0_003D.MeshNature;
			base.EdgeStyle = _0023_003DzQwa1qM0_003D.EdgeStyle;
			_triangles = _0023_003DzQwa1qM0_003D.Triangles;
			_vertices = _0023_003DzQwa1qM0_003D.Vertices;
			base.TextureCoords = _0023_003DzQwa1qM0_003D.TextureCoords;
			base.Normals = _0023_003DzQwa1qM0_003D.Normals;
			_edges = _0023_003DzQwa1qM0_003D.Edges;
			base.SmoothingAngle = _0023_003DzQwa1qM0_003D.SmoothingAngle;
			base.LightWeight = _0023_003DzQwa1qM0_003D.LightWeight;
			vertexCount = _0023_003DzQwa1qM0_003D.VertexCount;
			edgeCount = _0023_003DzQwa1qM0_003D.EdgeCount;
			faceCount = _0023_003DzQwa1qM0_003D.FaceCount;
			contourCount = _0023_003DzQwa1qM0_003D.ContourCount;
			MaxNov = _0023_003DzQwa1qM0_003D.MaxNov;
			MaxNoe = _0023_003DzQwa1qM0_003D.MaxNoe;
			MaxNof = _0023_003DzQwa1qM0_003D.MaxNof;
			MaxNoc = _0023_003DzQwa1qM0_003D.MaxNoc;
			novTemp = _0023_003DzQwa1qM0_003D.NovTemp;
			isoCurves = _0023_003DzQwa1qM0_003D.IsoCurves;
			Id = _0023_003DzQwa1qM0_003D.Id;
			_0023_003DzDBrp9S8_003D(_0023_003DzQwa1qM0_003D.EdgeDatas, _0023_003DzQwa1qM0_003D.Faces, _0023_003DzQwa1qM0_003D.Cycles, null, null, _vertices, Id, vertexCount, 250, edgeCount, faceCount, contourCount, null, null, 250, 400, 202, 222);
			_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(this);
		}

		public Portion(SerializationInfo info, StreamingContext ctxt)
			: base(info, ctxt)
		{
			Id = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977474));
			vertexCount = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977481));
			edgeCount = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977470));
			faceCount = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977453));
			contourCount = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977440));
			edgeDatas = (EdgeData[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977140), typeof(EdgeData[]));
			faces = (Face[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958659), typeof(Face[]));
			cycles = (Cycle[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977124), typeof(Cycle[]));
			planes = (PlaneEquation[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977135), typeof(PlaneEquation[]));
			MaxNov = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977118));
			MaxNoe = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977100));
			MaxNof = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977082));
			MaxNoc = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977064));
			novTemp = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977046));
			isoCurves = (List<IndexLine>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977034), typeof(List<IndexLine>));
			user = new BoolUser[MaxNoe + 1];
		}

		public override object Clone()
		{
			return new Portion(this);
		}

		public override object CloneWithTessellation()
		{
			return new Portion(this, RegenMode != regenType.RegenAndCompile);
		}

		protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
		{
			Utility.ComputeBoundingBox(data?.Transformation, _vertices, vertexCount, out boxMin, out boxMax);
			return true;
		}

		protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
		{
			Entity.ComputeOffsetOnCameraAxes(data, _vertices, vertexCount);
		}

		internal bool _0023_003DzDBrp9S8_003D(Portion _0023_003Dzd9ZyL64_003D)
		{
			return _0023_003DzDBrp9S8_003D(_0023_003Dzd9ZyL64_003D.edgeDatas, _0023_003Dzd9ZyL64_003D.faces, _0023_003Dzd9ZyL64_003D.cycles, _0023_003Dzd9ZyL64_003D.user, _0023_003Dzd9ZyL64_003D.planes, _0023_003Dzd9ZyL64_003D._vertices, _0023_003Dzd9ZyL64_003D.Id, _0023_003Dzd9ZyL64_003D.vertexCount, _0023_003Dzd9ZyL64_003D.novTemp, _0023_003Dzd9ZyL64_003D.edgeCount, _0023_003Dzd9ZyL64_003D.faceCount, _0023_003Dzd9ZyL64_003D.contourCount, _0023_003Dzd9ZyL64_003D.localMin, _0023_003Dzd9ZyL64_003D.localMax, _0023_003Dzd9ZyL64_003D.MaxNov, _0023_003Dzd9ZyL64_003D.MaxNoe, _0023_003Dzd9ZyL64_003D.MaxNof, _0023_003Dzd9ZyL64_003D.MaxNoc);
		}

		internal bool _0023_003DzDBrp9S8_003D(EdgeData[] _0023_003DzkU17_ynt7LPR_002421QuA_003D_003D, Face[] _0023_003DzIUxqWHN_1LWs, Cycle[] _0023_003DzoRZm5nS2PGzX, BoolUser[] _0023_003Dz1nJUG0s_003D, PlaneEquation[] _0023_003DzfXyRqdpWocWT, Point3D[] _0023_003DzRq6VfJckX8nnMxryuw_003D_003D, int _0023_003DzP8fmM7Tg09XX, int _0023_003DzKpIsuXeCRolt, int _0023_003DzhBo_Xdc0MAJd, int _0023_003Dz4hrC5lLJIC3r, int _0023_003DzVMw7gTF6tNbe, int _0023_003DzaIPVXza089yG_eHpJg_003D_003D, Point3D _0023_003DzjQN6_0024iJf_bje, Point3D _0023_003DzR4x6TmF_0024jIPE, int _0023_003DzkzzM_0024xtmV7oJ, int _0023_003DzDKYv6rE8Csvm, int _0023_003DziX_o0jwV1tOe, int _0023_003DzT1XlvL32Kect)
		{
			MaxNov = Math.Max(_0023_003DzkzzM_0024xtmV7oJ, _0023_003DzRq6VfJckX8nnMxryuw_003D_003D.Length - 1);
			MaxNoe = Math.Max(_0023_003DzDKYv6rE8Csvm, _0023_003DzkU17_ynt7LPR_002421QuA_003D_003D.Length - 1);
			MaxNof = Math.Max(_0023_003DziX_o0jwV1tOe, _0023_003DzIUxqWHN_1LWs.Length - 1);
			MaxNoc = Math.Max(_0023_003DzT1XlvL32Kect, _0023_003DzoRZm5nS2PGzX.Length - 1);
			if (_vertices.Length < _0023_003DzKpIsuXeCRolt)
			{
				Array.Resize(ref _vertices, _0023_003DzKpIsuXeCRolt);
			}
			for (int i = vertexCount; i < _0023_003DzKpIsuXeCRolt; i++)
			{
				_vertices[i] = new Point3D();
			}
			for (int j = _0023_003DzhBo_Xdc0MAJd; j < MaxNov; j++)
			{
				_vertices[j] = new Point3D();
			}
			if (planes.Length < _0023_003DzVMw7gTF6tNbe + 1)
			{
				Array.Resize(ref planes, _0023_003DzVMw7gTF6tNbe + 1);
			}
			for (int k = faceCount + 1; k <= _0023_003DzVMw7gTF6tNbe; k++)
			{
				planes[k] = new PlaneEquation();
			}
			Id = _0023_003DzP8fmM7Tg09XX;
			vertexCount = _0023_003DzKpIsuXeCRolt;
			edgeCount = _0023_003Dz4hrC5lLJIC3r;
			faceCount = _0023_003DzVMw7gTF6tNbe;
			contourCount = _0023_003DzaIPVXza089yG_eHpJg_003D_003D;
			novTemp = _0023_003DzhBo_Xdc0MAJd;
			if (edgeDatas.Length < edgeCount + 1)
			{
				Array.Resize(ref edgeDatas, edgeCount + 1);
			}
			if (user.Length < edgeCount + 1)
			{
				Array.Resize(ref user, edgeCount + 1);
			}
			if (faces.Length < faceCount + 1)
			{
				Array.Resize(ref faces, faceCount + 1);
			}
			if (cycles.Length < contourCount + 1)
			{
				Array.Resize(ref cycles, contourCount + 1);
			}
			for (int l = 0; l < _0023_003DzKpIsuXeCRolt; l++)
			{
				Point3D point3D = _0023_003DzRq6VfJckX8nnMxryuw_003D_003D[l];
				Point3D point3D2 = _vertices[l];
				point3D2.X = point3D.X;
				point3D2.Y = point3D.Y;
				point3D2.Z = point3D.Z;
			}
			for (int m = _0023_003DzhBo_Xdc0MAJd; m < MaxNov; m++)
			{
				Point3D point3D3 = _0023_003DzRq6VfJckX8nnMxryuw_003D_003D[m];
				Point3D point3D4 = _vertices[m];
				if (point3D3 != null)
				{
					point3D4.X = point3D3.X;
					point3D4.Y = point3D3.Y;
					point3D4.Z = point3D3.Z;
				}
			}
			if (_0023_003DzfXyRqdpWocWT != null)
			{
				for (int n = 0; n <= _0023_003DzVMw7gTF6tNbe; n++)
				{
					PlaneEquation planeEquation = _0023_003DzfXyRqdpWocWT[n];
					PlaneEquation planeEquation2 = planes[n];
					planeEquation2.X = planeEquation.X;
					planeEquation2.Y = planeEquation.Y;
					planeEquation2.Z = planeEquation.Z;
					planeEquation2.D = planeEquation.D;
				}
			}
			Array.Copy(_0023_003DzkU17_ynt7LPR_002421QuA_003D_003D, edgeDatas, edgeCount + 1);
			if (_0023_003DzIUxqWHN_1LWs != null)
			{
				_0023_003DzuHbAxNSGQE3z(_0023_003DzIUxqWHN_1LWs, _0023_003DzVMw7gTF6tNbe);
			}
			Array.Copy(_0023_003DzoRZm5nS2PGzX, cycles, contourCount + 1);
			if (_0023_003Dz1nJUG0s_003D != null)
			{
				Array.Copy(_0023_003Dz1nJUG0s_003D, user, edgeCount + 1);
			}
			if (_0023_003DzjQN6_0024iJf_bje != null && _0023_003DzR4x6TmF_0024jIPE != null)
			{
				localMin = (Point3D)_0023_003DzjQN6_0024iJf_bje.Clone();
				localMax = (Point3D)_0023_003DzR4x6TmF_0024jIPE.Clone();
			}
			return true;
		}

		private void _0023_003DzuHbAxNSGQE3z(Face[] _0023_003DzHo2EjmoaTUfX, int _0023_003Dzb2O_kchDcG65)
		{
			Array.Copy(_0023_003DzHo2EjmoaTUfX, faces, _0023_003Dzb2O_kchDcG65 + 1);
			for (int i = 0; i < _0023_003Dzb2O_kchDcG65 + 1; i++)
			{
				_0023_003DzoJ2gBqNYvsMA(_0023_003DzHo2EjmoaTUfX, i, faces, i);
			}
		}

		internal static void _0023_003Dz9HpVHgpIe5Kw(Face[] _0023_003DzHo2EjmoaTUfX, int _0023_003DzFe916QTZ8EgG, Face[] _0023_003Dz91YEyfwIMJDg, int _0023_003Dz06CobM7CJhvS)
		{
			_0023_003Dz91YEyfwIMJDg[_0023_003Dz06CobM7CJhvS].FaceLabel = _0023_003DzHo2EjmoaTUfX[_0023_003DzFe916QTZ8EgG].FaceLabel;
			_0023_003DzoJ2gBqNYvsMA(_0023_003DzHo2EjmoaTUfX, _0023_003DzFe916QTZ8EgG, _0023_003Dz91YEyfwIMJDg, _0023_003Dz06CobM7CJhvS);
		}

		private static void _0023_003DzoJ2gBqNYvsMA(Face[] _0023_003DzHo2EjmoaTUfX, int _0023_003DzFe916QTZ8EgG, Face[] _0023_003Dz91YEyfwIMJDg, int _0023_003Dz06CobM7CJhvS)
		{
		}

		internal void _0023_003DzMWYnHjivad6tXtcHtA_003D_003D(int _0023_003DzkzzM_0024xtmV7oJ, int _0023_003DzDKYv6rE8Csvm, int _0023_003DziX_o0jwV1tOe, int _0023_003DzT1XlvL32Kect)
		{
			Id = 0;
			vertexCount = 0;
			edgeCount = 0;
			faceCount = 0;
			contourCount = 0;
			MaxNov = _0023_003DzkzzM_0024xtmV7oJ;
			MaxNoe = _0023_003DzDKYv6rE8Csvm;
			MaxNof = _0023_003DziX_o0jwV1tOe;
			MaxNoc = _0023_003DzT1XlvL32Kect;
			novTemp = MaxNov;
			_vertices = new Point3D[_0023_003DzkzzM_0024xtmV7oJ];
			edgeDatas = new EdgeData[_0023_003DzDKYv6rE8Csvm + 1];
			faces = new Face[_0023_003DziX_o0jwV1tOe + 1];
			cycles = new Cycle[_0023_003DzT1XlvL32Kect + 1];
			planes = new PlaneEquation[_0023_003DziX_o0jwV1tOe + 1];
			planes[0] = new PlaneEquation();
			user = new BoolUser[_0023_003DzDKYv6rE8Csvm + 1];
		}

		public void GetFace(int faceNum, out LinearPath outer, out LinearPath[] inners, double tol)
		{
			PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D;
			IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003Dz_SqBXz8_003D;
			IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzWaFlkhfmYCja;
			Vector3D[] _0023_003DztbKR93i_Z6Zog7BhCw_003D_003D;
			IList<Vector3D[]> _0023_003DzybaJdSayrXwtV332Whv_nwQ_003D;
			List<IList<int>> _0023_003Dzcv8o5nO25OjS;
			int num = _0023_003DzplC_ggYV_Ts5ROsVTA_003D_003D(null, -1, faceNum + 1, out _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, out _0023_003Dz_SqBXz8_003D, out _0023_003DzWaFlkhfmYCja, out _0023_003DztbKR93i_Z6Zog7BhCw_003D_003D, out _0023_003DzybaJdSayrXwtV332Whv_nwQ_003D, out _0023_003Dzcv8o5nO25OjS, _0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D: false, tol);
			IList<int> list = _0023_003Dzcv8o5nO25OjS[num];
			outer = new LinearPath(list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				outer._vertices[i] = _vertices[list[i]];
			}
			if (_0023_003Dzcv8o5nO25OjS.Count > 1)
			{
				inners = new LinearPath[_0023_003Dzcv8o5nO25OjS.Count - 1];
				int num2 = 0;
				for (int j = 0; j < _0023_003Dzcv8o5nO25OjS.Count; j++)
				{
					if (j != num)
					{
						list = _0023_003Dzcv8o5nO25OjS[j];
						inners[num2] = new LinearPath(list.Count);
						for (int k = 0; k < list.Count; k++)
						{
							inners[num2]._vertices[k] = _vertices[list[k]];
						}
						num2++;
					}
				}
			}
			else
			{
				inners = null;
			}
		}

		public void GetFace(int faceNum, out PlaneEquation plane, out Point2D[] outer, out Point2D[][] inners, double tol)
		{
			IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003Dz_SqBXz8_003D;
			IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzWaFlkhfmYCja;
			Vector3D[] _0023_003DztbKR93i_Z6Zog7BhCw_003D_003D;
			IList<Vector3D[]> _0023_003DzybaJdSayrXwtV332Whv_nwQ_003D;
			List<IList<int>> _0023_003Dzcv8o5nO25OjS;
			int num = _0023_003DzplC_ggYV_Ts5ROsVTA_003D_003D(null, -1, faceNum + 1, out plane, out _0023_003Dz_SqBXz8_003D, out _0023_003DzWaFlkhfmYCja, out _0023_003DztbKR93i_Z6Zog7BhCw_003D_003D, out _0023_003DzybaJdSayrXwtV332Whv_nwQ_003D, out _0023_003Dzcv8o5nO25OjS, _0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D: false, tol);
			outer = new Point2D[_0023_003Dz_SqBXz8_003D.Count];
			for (int i = 0; i < _0023_003Dz_SqBXz8_003D.Count; i++)
			{
				outer[i] = _0023_003Dz_SqBXz8_003D[i]._0023_003DzIHt45I8_003D;
			}
			if (_0023_003DzWaFlkhfmYCja != null)
			{
				inners = new Point2D[_0023_003DzWaFlkhfmYCja.Count][];
				int num2 = 0;
				for (int j = 0; j < _0023_003DzWaFlkhfmYCja.Count; j++)
				{
					if (j != num)
					{
						IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> list = _0023_003DzWaFlkhfmYCja[j];
						inners[num2] = new Point2D[list.Count];
						for (int k = 0; k < list.Count; k++)
						{
							inners[num2][k] = list[k]._0023_003DzIHt45I8_003D;
						}
						num2++;
					}
				}
			}
			else
			{
				inners = null;
			}
		}

		public PlaneEquation GetFacePlane(int faceNum)
		{
			return planes[faceNum + 1];
		}

		internal int _0023_003DzplC_ggYV_Ts5ROsVTA_003D_003D(Solid _0023_003DzQUhnjVe9kSO_0024, int _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, int _0023_003Dzfe2zeQMumw_4, out PlaneEquation _0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D, out IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003Dz_SqBXz8_003D, out IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzWaFlkhfmYCja, out Vector3D[] _0023_003DztbKR93i_Z6Zog7BhCw_003D_003D, out IList<Vector3D[]> _0023_003DzybaJdSayrXwtV332Whv_nwQ_003D, out List<IList<int>> _0023_003Dzcv8o5nO25OjS, bool _0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D, double _0023_003DzkRSfKls1SLfn)
		{
			_0023_003Dzcv8o5nO25OjS = new List<IList<int>>();
			int num = faces[_0023_003Dzfe2zeQMumw_4].FirstContour;
			int num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(cycles[num].FirstEdge, this);
			Vector3D _0023_003DzOKWDitw6j6GZ = planes[_0023_003Dzfe2zeQMumw_4];
			Vector3D vector3D = null;
			List<Vector3D[]> list = null;
			int num3 = 0;
			if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
			{
				list = new List<Vector3D[]>();
				num3 = _0023_003DzQaPlK3qJVEsR8De_cQ_003D_003D(this);
			}
			do
			{
				List<int> list2 = new List<int>();
				int num5;
				int num4 = (num5 = cycles[num].FirstEdge);
				num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num5, this);
				list2.Add(num2);
				List<Vector3D> list3 = null;
				if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
				{
					list3 = new List<Vector3D>();
					vector3D = new Vector3D(_0023_003DzhBWZ_0024ug_003D(_0023_003DzQUhnjVe9kSO_0024, _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, num3, num5, _0023_003DzOKWDitw6j6GZ, num2, _0023_003DzkRSfKls1SLfn).ToArray());
					list3.Add(vector3D);
				}
				while (true)
				{
					int num6 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num5, this);
					if ((num5 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num5, this)) == num4)
					{
						break;
					}
					list2.Add(num6);
					if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
					{
						Vector3D item = new Vector3D(_0023_003DzhBWZ_0024ug_003D(_0023_003DzQUhnjVe9kSO_0024, _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, num3, num5, _0023_003DzOKWDitw6j6GZ, num6, _0023_003DzkRSfKls1SLfn).ToArray());
						list3.Add(item);
					}
				}
				list2.Add(num2);
				_0023_003Dzcv8o5nO25OjS.Add(list2);
				if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
				{
					if (num3 == 1)
					{
						Vector3D vector3D2 = list3[list3.Count - 1];
						list3.Insert(0, new Vector3D(vector3D2.X, vector3D2.Y, vector3D2.Z));
					}
					else
					{
						list3.Add(new Vector3D(vector3D.X, vector3D.Y, vector3D.Z));
					}
					list.Add(list3.ToArray());
				}
				num = cycles[num].NextContour;
			}
			while (num > 0);
			double[] e = new double[4]
			{
				planes[_0023_003Dzfe2zeQMumw_4].X,
				planes[_0023_003Dzfe2zeQMumw_4].Y,
				planes[_0023_003Dzfe2zeQMumw_4].Z,
				planes[_0023_003Dzfe2zeQMumw_4].D
			};
			_0023_003DzcpmWXV6_RKAxSjs1rCCcX4E_003D = planes[_0023_003Dzfe2zeQMumw_4];
			Plane _0023_003Dzrgqz890sj_0024X = new Plane(e);
			return _0023_003DznesKDeUDoxNm8OVW3g_003D_003D(_0023_003Dzrgqz890sj_0024X, _0023_003Dzcv8o5nO25OjS, _vertices, out _0023_003Dz_SqBXz8_003D, out _0023_003DzWaFlkhfmYCja, list, out _0023_003DztbKR93i_Z6Zog7BhCw_003D_003D, out _0023_003DzybaJdSayrXwtV332Whv_nwQ_003D);
		}

		private Vector3D _0023_003DzhBWZ_0024ug_003D(Solid _0023_003DzQUhnjVe9kSO_0024, int _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, int _0023_003DzyR_xVytVtCbAdL2X0w_003D_003D, int _0023_003DzTx2aqr8_003D, Vector3D _0023_003DzOKWDitw6j6GZ, int _0023_003DzcJpaJQAcgoDn, double _0023_003DzkRSfKls1SLfn)
		{
			Vector3D _0023_003Dz7hp7a0EFUobk;
			if (_0023_003DzyR_xVytVtCbAdL2X0w_003D_003D != 2)
			{
				int _0023_003DzTx2aqr8_003D2 = ((_0023_003DzyR_xVytVtCbAdL2X0w_003D_003D == 1) ? _0023_003DzTx2aqr8_003D : (-_0023_003DzTx2aqr8_003D));
				_0023_003Dz7hp7a0EFUobk = new Vector3D();
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzcQt9lrVLzd3R(_0023_003DzQUhnjVe9kSO_0024, _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, _0023_003DzTx2aqr8_003D2, ref _0023_003Dz7hp7a0EFUobk, _0023_003DzcJpaJQAcgoDn, _0023_003DzkRSfKls1SLfn))
				{
					_0023_003Dz7hp7a0EFUobk = _0023_003DzOKWDitw6j6GZ;
				}
			}
			else
			{
				_0023_003Dz7hp7a0EFUobk = _0023_003DzOKWDitw6j6GZ;
			}
			return _0023_003Dz7hp7a0EFUobk;
		}

		private int _0023_003DznesKDeUDoxNm8OVW3g_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, List<IList<int>> _0023_003Dzcv8o5nO25OjS, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003Dz_SqBXz8_003D, out IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzWaFlkhfmYCja, IList<Vector3D[]> _0023_003DzztJY0_0024dXEFMk, out Vector3D[] _0023_003DztbKR93i_Z6Zog7BhCw_003D_003D, out IList<Vector3D[]> _0023_003DzgXRy34DEbaJbGsIjlw_003D_003D)
		{
			Plane xY = Plane.XY;
			Transformation transformation = new Transformation();
			transformation.Rotation(_0023_003Dzrgqz890sj_0024X9.Origin, _0023_003Dzrgqz890sj_0024X9.AxisX, _0023_003Dzrgqz890sj_0024X9.AxisY, _0023_003Dzrgqz890sj_0024X9.AxisZ, xY.Origin, xY.AxisX, xY.AxisY, xY.AxisZ);
			int num = 0;
			for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
			{
				num += _0023_003Dzcv8o5nO25OjS[i].Count;
			}
			List<_0023_003DzJX25Vanpz2BZ> list = new List<_0023_003DzJX25Vanpz2BZ>(num);
			List<IList<_0023_003DzJX25Vanpz2BZ>> list2 = new List<IList<_0023_003DzJX25Vanpz2BZ>>(_0023_003Dzcv8o5nO25OjS.Count);
			for (int j = 0; j < _0023_003Dzcv8o5nO25OjS.Count; j++)
			{
				list2.Add(new List<_0023_003DzJX25Vanpz2BZ>(_0023_003Dzcv8o5nO25OjS[j].Count));
				for (int k = 0; k < _0023_003Dzcv8o5nO25OjS[j].Count; k++)
				{
					Point3D _0023_003DzMlCq3wk_003D = transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dzcv8o5nO25OjS[j][k]];
					_0023_003DzJX25Vanpz2BZ item = new _0023_003DzJX25Vanpz2BZ(j, _0023_003Dzcv8o5nO25OjS[j][k], _0023_003DzMlCq3wk_003D);
					list.Add(item);
					list2[j].Add(item);
				}
			}
			int num2 = 0;
			IList<IList<_0023_003DzJX25Vanpz2BZ>> _0023_003DzxZtQCI37epAc = null;
			if (_0023_003Dzcv8o5nO25OjS.Count > 1)
			{
				list.Sort(_0023_003DzJX25Vanpz2BZ._0023_003Dzwz6CZyI_003D);
				num2 = list[0]._0023_003DzhNQLY4s_003D;
				_0023_003DzxZtQCI37epAc = list2;
			}
			_0023_003DzHUXM66d_9jq7(list2[num2], _0023_003DzxZtQCI37epAc, num2, out _0023_003Dz_SqBXz8_003D, out _0023_003DzWaFlkhfmYCja);
			_0023_003DztbKR93i_Z6Zog7BhCw_003D_003D = null;
			_0023_003DzgXRy34DEbaJbGsIjlw_003D_003D = null;
			if (_0023_003DzztJY0_0024dXEFMk != null)
			{
				_0023_003DztbKR93i_Z6Zog7BhCw_003D_003D = _0023_003DzztJY0_0024dXEFMk[num2];
				if (_0023_003DzztJY0_0024dXEFMk.Count > 1)
				{
					_0023_003DzgXRy34DEbaJbGsIjlw_003D_003D = new List<Vector3D[]>(_0023_003DzztJY0_0024dXEFMk.Count - 1);
					for (int l = 0; l < _0023_003DzztJY0_0024dXEFMk.Count; l++)
					{
						if (l != num2)
						{
							_0023_003DzgXRy34DEbaJbGsIjlw_003D_003D.Add(_0023_003DzztJY0_0024dXEFMk[l]);
						}
					}
				}
			}
			return num2;
		}

		private void _0023_003DzHUXM66d_9jq7<T>(IList<T> _0023_003DzBZc7VVG5asYu, IList<IList<T>> _0023_003DzxZtQCI37epAc, int _0023_003DzOjd4mV4YtYKL, out IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003Dz_SqBXz8_003D, out IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzWaFlkhfmYCja) where T : _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D
		{
			_0023_003Dz_SqBXz8_003D = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzBZc7VVG5asYu.Count];
			for (int i = 0; i < _0023_003Dz_SqBXz8_003D.Count; i++)
			{
				_0023_003Dz_SqBXz8_003D[i] = _0023_003DzBZc7VVG5asYu[i];
			}
			if (_0023_003DzxZtQCI37epAc != null)
			{
				int num = _0023_003DzxZtQCI37epAc.Count;
				if (_0023_003DzOjd4mV4YtYKL != -1)
				{
					num--;
				}
				_0023_003DzWaFlkhfmYCja = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[num][];
				int num2 = 0;
				for (int j = 0; j < _0023_003DzxZtQCI37epAc.Count; j++)
				{
					if (j != _0023_003DzOjd4mV4YtYKL)
					{
						_0023_003DzWaFlkhfmYCja[num2] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzxZtQCI37epAc[j].Count];
						for (int k = 0; k < _0023_003DzxZtQCI37epAc[j].Count; k++)
						{
							_0023_003DzWaFlkhfmYCja[num2][k] = _0023_003DzxZtQCI37epAc[j][k];
						}
						num2++;
					}
				}
			}
			else
			{
				_0023_003DzWaFlkhfmYCja = null;
			}
		}

		internal override void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
		{
			FindClosestVertices(_0023_003DzELu0Pss_003D, _vertices, vertexCount, _0023_003Dz7xzxLVk_003D);
		}

		internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
		{
			return FindClosestVertex(_0023_003DzELu0Pss_003D, _vertices, vertexCount, _0023_003Dz7xzxLVk_003D);
		}

		protected internal override void DrawVertices(DrawParams data)
		{
			_0023_003DzfytGakPJH0VOucX17g_003D_003D(data.RenderContext, _vertices, vertexCount);
		}

		protected internal override bool AllVerticesInFrustum(FrustumParams data)
		{
			return Utility.AllVerticesInFrustum(data, _vertices, vertexCount);
		}

		internal override bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
		{
			Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
			if (transformation == null)
			{
				IndexLine[] edges = Edges;
				foreach (IndexLine indexLine in edges)
				{
					if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, new Segment3D(_vertices[indexLine.V1], _vertices[indexLine.V2])))
					{
						return true;
					}
				}
				if (_0023_003DzXKLW0uVVgJjBaoieP_TQers_003D(_0023_003DzELu0Pss_003D))
				{
					foreach (IndexLine isoCurf in isoCurves)
					{
						if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, new Segment3D(_vertices[isoCurf.V1], _vertices[isoCurf.V2])))
						{
							return true;
						}
					}
				}
			}
			else
			{
				IndexLine[] edges = Edges;
				foreach (IndexLine indexLine2 in edges)
				{
					if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, new Segment3D(transformation * _vertices[indexLine2.V1], transformation * _vertices[indexLine2.V2])))
					{
						return true;
					}
				}
				if (_0023_003DzXKLW0uVVgJjBaoieP_TQers_003D(_0023_003DzELu0Pss_003D))
				{
					foreach (IndexLine isoCurf2 in isoCurves)
					{
						if (Utility.IsSegmentInsideOrCrossing(_0023_003DzELu0Pss_003D.Frustum, new Segment3D(transformation * _vertices[isoCurf2.V1], transformation * _vertices[isoCurf2.V2])))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		private bool _0023_003DzXKLW0uVVgJjBaoieP_TQers_003D(FrustumParams _0023_003DzELu0Pss_003D)
		{
			return _0023_003DzELu0Pss_003D.workspaceInternal.Wireframe.ShowInternalWires;
		}

		internal override bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
		{
			Transformation transformation = _0023_003DzELu0Pss_003D.Transformation;
			if (transformation == null)
			{
				IndexLine[] edges = Edges;
				foreach (IndexLine indexLine in edges)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(_vertices[indexLine.V1], _vertices[indexLine.V2], _0023_003DzELu0Pss_003D))
					{
						return true;
					}
				}
				if (_0023_003DzXKLW0uVVgJjBaoieP_TQers_003D(_0023_003DzELu0Pss_003D))
				{
					foreach (IndexLine isoCurf in isoCurves)
					{
						if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(_vertices[isoCurf.V1], _vertices[isoCurf.V2], _0023_003DzELu0Pss_003D))
						{
							return true;
						}
					}
				}
			}
			else
			{
				IndexLine[] edges = Edges;
				foreach (IndexLine indexLine2 in edges)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(transformation * _vertices[indexLine2.V1], transformation * _vertices[indexLine2.V2], _0023_003DzELu0Pss_003D))
					{
						return true;
					}
				}
				if (_0023_003DzXKLW0uVVgJjBaoieP_TQers_003D(_0023_003DzELu0Pss_003D))
				{
					foreach (IndexLine isoCurf2 in isoCurves)
					{
						if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(transformation * _vertices[isoCurf2.V1], transformation * _vertices[isoCurf2.V2], _0023_003DzELu0Pss_003D))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
		{
			return Utility.AllVerticesInScreenPolygon(data, _vertices, vertexCount);
		}

		public Point3D[] PackVertices()
		{
			Point3D[] vertices = _vertices;
			if (vertexCount < _vertices.Length)
			{
				Point3D[] array = new Point3D[vertexCount];
				Array.Copy(_vertices, array, array.Length);
				_vertices = array;
			}
			return vertices;
		}

		public override Mesh[] GetTessellation()
		{
			Point3D[] array = new Point3D[vertexCount];
			Array.Copy(_vertices, array, vertexCount);
			return new Mesh[1]
			{
				new Mesh(array, _triangles)
			};
		}

		public override EntitySurrogate ConvertToSurrogate()
		{
			return new PortionSurrogate(this);
		}

		[SpecialName]
		internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
		{
			if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
			{
				return isoCurves != null;
			}
			return false;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977474), Id);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977481), vertexCount);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977470), edgeCount);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977453), faceCount);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977440), contourCount);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977140), edgeDatas);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958659), faces);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977124), cycles);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977135), planes);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977118), MaxNov);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977100), MaxNoe);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977082), MaxNof);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977064), MaxNoc);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977046), novTemp);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977034), isoCurves);
		}
	}

	internal enum brepType : byte
	{
		Body,
		Shell
	}

	internal TextureMappingData textureMapping;

	internal bool UseInnerColors;

	internal double smoothingAngle = Math.PI / 6.0;

	internal List<Portion> portions;

	internal List<int> NbList;

	internal List<NpStr> NpStrList;

	internal Dictionary<int, NpStr> NpStrDict;

	internal brepType _brepMode;

	internal List<MNODE> NodeList;

	private Mesh meshForFaceSelection;

	private Mesh.FaceCollection _faces;

	private selectionFilterType _selectionMode = selectionFilterType.Entity;

	private EntityGraphicsData drawIsocurve;

	public TextureMappingData TextureMapping => textureMapping;

	public double SmoothingAngle
	{
		get
		{
			return smoothingAngle;
		}
		set
		{
			smoothingAngle = value;
			for (int i = 0; i < portions.Count; i++)
			{
				_0023_003DzaD5_0024bui7AmQbPta7uA_003D_003D._0023_003DzVoQS_BVEn1Zl(portions[i], smoothingAngle);
			}
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public List<Portion> Portions => portions;

	public bool IsClosed => _brepMode == brepType.Body;

	public Mesh.FaceCollection Faces
	{
		get
		{
			return _faces;
		}
		set
		{
			_faces = value;
			FacesSelectionInfo.Clear();
		}
	}

	internal List<SelectionInfoSubItems> FacesSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	public Mesh MeshForFaceSelection => meshForFaceSelection;

	public selectionFilterType SelectionMode
	{
		get
		{
			return _selectionMode;
		}
		set
		{
			_selectionMode = value;
		}
	}

	public Solid()
		: base(entityNatureType.Polygon)
	{
		_0023_003DzSMdl97OuFfBX();
	}

	internal Solid(bool _0023_003DzbErHvVw_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
		: this(_0023_003DzbErHvVw_003D)
	{
		smoothingAngle = _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D;
	}

	internal Solid(bool _0023_003DzbErHvVw_003D)
		: this()
	{
		_brepMode = ((!_0023_003DzbErHvVw_003D) ? brepType.Shell : brepType.Body);
		localMin = Point3D.Origin;
		localMax = Point3D.Origin;
		UpdateBoundingBox(null);
		NodeList = new List<MNODE>();
	}

	protected Solid(Solid another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_0023_003Dz_00246_6laMMoobS(another, keepTessellation);
	}

	public Solid(bool closed, TextureMappingData textureMapping, IList<Portion> portions)
		: this(portions)
	{
		_brepMode = ((!closed) ? brepType.Shell : brepType.Body);
		localMin = Point3D.Origin;
		localMax = Point3D.Origin;
		UpdateBoundingBox(null);
		_0023_003DzEtMRntRxbTsa(textureMapping);
	}

	protected internal Solid(SolidSurrogate surrogate)
		: this(surrogate._0023_003DzavTT22ksPV_0024U() == brepType.Body)
	{
		if (surrogate.Content == contentType.Geometry)
		{
			_0023_003Dz37_0024EFwOzwZ7g0Tiw_0024A_003D_003D(surrogate._0023_003DzZIEWoy_6KiDwkpoZBg_003D_003D());
			_0023_003DzEtMRntRxbTsa(surrogate.GetTextureMapping());
		}
	}

	protected internal Solid(IList<Portion> portions)
		: this()
	{
		_0023_003Dz37_0024EFwOzwZ7g0Tiw_0024A_003D_003D(portions);
	}

	public Solid(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_brepMode = (brepType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977273), typeof(brepType));
		localMin = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977261), typeof(Point3D));
		localMax = (Point3D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977246), typeof(Point3D));
		if (localMin != null && localMax != null)
		{
			UpdateBoundingBoxSphere();
			RegenMode = regenType.CompileOnly;
		}
		portions = (List<Portion>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977227), typeof(List<Portion>));
		textureMapping = (TextureMappingData)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977216), typeof(TextureMappingData));
	}

	public static T[] Difference<T>(T a, T b, double tol = 0.0) where T : Solid, new()
	{
		return Difference(a, b, keepOriginalColors: false, tol);
	}

	public static T[] Difference<T>(T a, T b, bool keepOriginalColors, double tol = 0.0) where T : Solid, new()
	{
		return _0023_003Dzms3EXGM0kMEE((_0023_003Dz6tkLYNg_003D)2, a, b, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: true, keepOriginalColors, tol, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: true);
	}

	public booleanFailureType CutBy(Surface surf, double tolerance, bool flipSide)
	{
		return CutBy(surf, tolerance, flipSide, keepOriginalColors: false);
	}

	public booleanFailureType CutBy(Surface surf, double tolerance, bool flipSide, out Solid[] leftOvers)
	{
		return CutBy(surf, tolerance, flipSide, keepOriginalColors: false, out leftOvers);
	}

	public booleanFailureType CutBy(Surface surf, double tolerance, bool flipSide, bool keepOriginalColors)
	{
		Solid[] leftOvers;
		return CutBy(surf, tolerance, flipSide, keepOriginalColors, out leftOvers);
	}

	public booleanFailureType CutBy(Surface surf, double tolerance, bool flipSide, bool keepOriginalColors, out Solid[] leftOvers)
	{
		Solid solid = surf.ConvertToSolid(tolerance);
		leftOvers = null;
		if (solid != null)
		{
			if (!flipSide)
			{
				solid.FlipNormal();
			}
			Solid[] array = _0023_003Dzms3EXGM0kMEE((_0023_003Dz6tkLYNg_003D)2, this, solid, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: true, keepOriginalColors, 0.0, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: true);
			if (array == null || array.Length == 0)
			{
				return booleanFailureType.Failed;
			}
			Solid solid2 = array[0];
			leftOvers = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			if (solid2 != null)
			{
				_0023_003Dz_00246_6laMMoobS(solid2, _0023_003Dzu9oxwJ_zKlMt: false);
				return booleanFailureType.Success;
			}
		}
		return booleanFailureType.Failed;
	}

	public void SplitBy(Surface surf, double tolerance, out Solid[] splitF, out Solid[] splitG)
	{
		splitF = null;
		splitG = null;
		Solid solid = surf.ConvertToSolid(tolerance);
		if (solid != null)
		{
			Solid[] array = _0023_003Dzms3EXGM0kMEE((_0023_003Dz6tkLYNg_003D)2, this, solid, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: true, _0023_003DzfjRqwoISk3lB: false, 0.0, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: true);
			solid.FlipNormal();
			Solid[] array2 = _0023_003Dzms3EXGM0kMEE((_0023_003Dz6tkLYNg_003D)2, this, solid, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: true, _0023_003DzfjRqwoISk3lB: false, 0.0, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: true);
			splitF = array;
			splitG = array2;
		}
	}

	public static T[] Union<T>(T a, T b, double tol = 0.0) where T : Solid, new()
	{
		return Union(a, b, keepOriginalColors: false, tol);
	}

	public static T[] Union<T>(T a, T b, bool keepOriginalColors, double tol = 0.0) where T : Solid, new()
	{
		return _0023_003Dzms3EXGM0kMEE((_0023_003Dz6tkLYNg_003D)0, a, b, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: true, keepOriginalColors, tol, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: true);
	}

	public static T[] Intersection<T>(T a, T b, double tol = 0.0) where T : Solid, new()
	{
		return Intersection(a, b, keepOriginalColors: false, tol);
	}

	public static T[] Intersection<T>(T a, T b, bool keepOriginalColors, double tol = 0.0) where T : Solid, new()
	{
		return _0023_003Dzms3EXGM0kMEE((_0023_003Dz6tkLYNg_003D)1, a, b, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: true, keepOriginalColors, tol, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: true);
	}

	internal static T[] _0023_003Dzms3EXGM0kMEE<T>(_0023_003Dz6tkLYNg_003D _0023_003DzwY9ClXw_003D, T _0023_003DzjbqS1qE_003D, T _0023_003Dz1v6oPQk_003D, bool _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D, bool _0023_003DzfjRqwoISk3lB, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D) where T : Solid, new()
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		List<brepType> list = new List<brepType>();
		if (_0023_003DzfjRqwoISk3lB)
		{
			if (!_0023_003DzjbqS1qE_003D.UseInnerColors)
			{
				_0023_003DzjbqS1qE_003D._0023_003DziEydE74SPwngSJCfZdwPef8_003D();
			}
			if (!_0023_003Dz1v6oPQk_003D.UseInnerColors)
			{
				_0023_003Dz1v6oPQk_003D._0023_003DziEydE74SPwngSJCfZdwPef8_003D();
			}
		}
		Point3D point3D = Point3D.MidPoint(_0023_003DzjbqS1qE_003D.BoxMin, _0023_003DzjbqS1qE_003D.BoxMax);
		regenType regenType2 = _0023_003DzjbqS1qE_003D.RegenMode;
		regenType regenType3 = _0023_003Dz1v6oPQk_003D.RegenMode;
		if (_0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D)
		{
			_0023_003DzjbqS1qE_003D.Translate(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
			_0023_003Dz1v6oPQk_003D.Translate(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
		}
		_0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D;
		try
		{
			if (!_0023_003DzNC7p9G80lhFN(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D, _0023_003DzwY9ClXw_003D, list, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D, _0023_003Dzm0CYiiE_003D, out _0023_003DzvuKzWCk_003D))
			{
				return null;
			}
		}
		catch (Exception)
		{
			return null;
		}
		finally
		{
			if (_0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D)
			{
				_0023_003DzjbqS1qE_003D.Translate(point3D.X, point3D.Y, point3D.Z);
				_0023_003DzjbqS1qE_003D.RegenMode = regenType2;
				_0023_003Dz1v6oPQk_003D.Translate(point3D.X, point3D.Y, point3D.Z);
				_0023_003Dz1v6oPQk_003D.RegenMode = regenType3;
			}
		}
		if (list.Count < 1)
		{
			return new T[0];
		}
		bool flag2 = _0023_003DzjbqS1qE_003D.IsClosed && _0023_003DzwY9ClXw_003D == (_0023_003Dz6tkLYNg_003D)2;
		List<T> list2 = new List<T>();
		for (int i = 0; i < list.Count; i++)
		{
			T val = new T();
			val._0023_003DzfD12v8o3kSVM(list[i]);
			val.portions = _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw[i].Portions;
			val.UpdateBoundingBox(null);
			_0023_003DzMnctNNI_003D(_0023_003DzjbqS1qE_003D, val);
			val.UseInnerColors = _0023_003DzfjRqwoISk3lB;
			if (_0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D)
			{
				val.Translate(point3D.X, point3D.Y, point3D.Z);
			}
			if (!flag2 || _0023_003Dzbv_0024EQyRyuvq7(val))
			{
				list2.Add(val);
			}
		}
		if (list2.Count == 0)
		{
			return null;
		}
		for (int j = 0; j < list2[0].portions.Count && list2[0].portions[j].MaxNov <= 250; j++)
		{
		}
		for (int k = 0; k < _0023_003DzjbqS1qE_003D.portions.Count && _0023_003DzjbqS1qE_003D.portions[k].MaxNov <= 250; k++)
		{
		}
		for (int l = 0; l < _0023_003Dz1v6oPQk_003D.portions.Count && _0023_003Dz1v6oPQk_003D.portions[l].MaxNov <= 250; l++)
		{
		}
		return list2.ToArray();
	}

	private static bool _0023_003Dzbv_0024EQyRyuvq7(Solid _0023_003DzQUhnjVe9kSO_0024)
	{
		for (int i = 0; i < _0023_003DzQUhnjVe9kSO_0024.Portions.Count; i++)
		{
			Portion portion = _0023_003DzQUhnjVe9kSO_0024.Portions[i];
			for (int j = 1; j <= portion.edgeCount; j++)
			{
				if (portion.edgeDatas[j].NextFace == 0 || portion.edgeDatas[j].PreviousFace == 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	private void _0023_003DziEydE74SPwngSJCfZdwPef8_003D()
	{
		foreach (Portion portion in portions)
		{
			_0023_003DzMnctNNI_003D(this, portion);
		}
	}

	private static void _0023_003DzMnctNNI_003D(Solid _0023_003Dzb7SPTpc_003D, Solid _0023_003DzaoQTclc_003D)
	{
		_0023_003DzaoQTclc_003D.Color = _0023_003Dzb7SPTpc_003D.Color;
		_0023_003DzaoQTclc_003D.ColorMethod = _0023_003Dzb7SPTpc_003D.ColorMethod;
		_0023_003DzaoQTclc_003D.MaterialName = _0023_003Dzb7SPTpc_003D.MaterialName;
		if (_0023_003Dzb7SPTpc_003D.textureMapping != null)
		{
			_0023_003DzaoQTclc_003D.textureMapping = (TextureMappingData)_0023_003Dzb7SPTpc_003D.textureMapping.Clone();
		}
	}

	private static void _0023_003DzMnctNNI_003D(Solid _0023_003Dzb7SPTpc_003D, Mesh _0023_003DzaoQTclc_003D)
	{
		_0023_003DzaoQTclc_003D.Color = _0023_003Dzb7SPTpc_003D.Color;
		_0023_003DzaoQTclc_003D.ColorMethod = _0023_003Dzb7SPTpc_003D.ColorMethod;
		_0023_003DzaoQTclc_003D.MaterialName = _0023_003Dzb7SPTpc_003D.MaterialName;
		if (_0023_003Dzb7SPTpc_003D.textureMapping != null)
		{
			_0023_003DzaoQTclc_003D._0023_003DzUWlvoYKIdqVL((TextureMappingData)_0023_003Dzb7SPTpc_003D.textureMapping.Clone());
		}
	}

	private static bool _0023_003DzNC7p9G80lhFN(Solid _0023_003DzJnCUD94_003D, Solid _0023_003Dz2xg_00247eo_003D, _0023_003Dz6tkLYNg_003D _0023_003DzR7LjAtYImXuc, List<brepType> _0023_003DzsJ4FZAuM3q3E, bool _0023_003DzEf3RSN8gQWvMtXrHyw_003D_003D, double _0023_003Dzm0CYiiE_003D, out _0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D)
	{
		Telemetry.Instance.AddUsage(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977178), Telemetry.moduleType.Booleans);
		if (_0023_003DzR7LjAtYImXuc == (_0023_003Dz6tkLYNg_003D)1 && _0023_003DzJnCUD94_003D.IsClosed && !_0023_003Dz2xg_00247eo_003D.IsClosed)
		{
			Solid solid = _0023_003DzJnCUD94_003D;
			_0023_003DzJnCUD94_003D = _0023_003Dz2xg_00247eo_003D;
			_0023_003Dz2xg_00247eo_003D = solid;
		}
		_0023_003DzvuKzWCk_003D = new _0023_003DzGl0iL3E_003D();
		_0023_003DzvuKzWCk_003D._0023_003DzjTwYx_xFB7Cw = true;
		bool flag = false;
		brepType brepMode = _0023_003DzJnCUD94_003D._brepMode;
		brepType brepMode2 = _0023_003Dz2xg_00247eo_003D._brepMode;
		_0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D = new Solid();
		_0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D = new Solid();
		Region3D region3D = new Region3D(Point3D.MaxValue, Point3D.MinValue);
		Region3D region3D2 = new Region3D(Point3D.MaxValue, Point3D.MinValue);
		if (_0023_003DzR7LjAtYImXuc < (_0023_003Dz6tkLYNg_003D)0 || _0023_003DzR7LjAtYImXuc > (_0023_003Dz6tkLYNg_003D)3)
		{
			return false;
		}
		_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX = true;
		if (brepMode == brepType.Shell)
		{
			_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX = false;
		}
		switch (_0023_003DzR7LjAtYImXuc)
		{
		case (_0023_003Dz6tkLYNg_003D)0:
			if (brepMode == brepType.Shell || brepMode2 == brepType.Shell)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977158));
			}
			break;
		case (_0023_003Dz6tkLYNg_003D)1:
			if (brepMode == brepType.Shell && brepMode2 == brepType.Shell)
			{
				return false;
			}
			break;
		}
		region3D.min.X = _0023_003DzJnCUD94_003D.localMin.X;
		region3D.min.Y = _0023_003DzJnCUD94_003D.localMin.Y;
		region3D.min.Z = _0023_003DzJnCUD94_003D.localMin.Z;
		region3D.max.X = _0023_003DzJnCUD94_003D.localMax.X;
		region3D.max.Y = _0023_003DzJnCUD94_003D.localMax.Y;
		region3D.max.Z = _0023_003DzJnCUD94_003D.localMax.Z;
		region3D2.min.X = _0023_003Dz2xg_00247eo_003D.localMin.X;
		region3D2.min.Y = _0023_003Dz2xg_00247eo_003D.localMin.Y;
		region3D2.min.Z = _0023_003Dz2xg_00247eo_003D.localMin.Z;
		region3D2.max.X = _0023_003Dz2xg_00247eo_003D.localMax.X;
		region3D2.max.Y = _0023_003Dz2xg_00247eo_003D.localMax.Y;
		region3D2.max.Z = _0023_003Dz2xg_00247eo_003D.localMax.Z;
		Region3D _0023_003Dz_XAFw2I_003D = new Region3D(Point3D.MaxValue, Point3D.MinValue);
		_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzgdSKwlxtRL1Q(region3D, region3D2, _0023_003Dz_XAFw2I_003D);
		if (Utility.DoOverlapOrTouch(region3D.min, region3D.max, region3D2.min, region3D2.max))
		{
			Utility.IntersectionBox(_0023_003DzJnCUD94_003D.localMin, _0023_003DzJnCUD94_003D.localMax, _0023_003Dz2xg_00247eo_003D.localMin, _0023_003Dz2xg_00247eo_003D.localMax, out var intersMin, out var intersMax);
			if (_0023_003Dzm0CYiiE_003D == 0.0)
			{
				_0023_003Dzm0CYiiE_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(intersMin, intersMax);
			}
			_0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn = _0023_003Dzm0CYiiE_003D;
			_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D = _0023_003DzR7LjAtYImXuc;
			int num = _0023_003DzYAADtuo_003D(_0023_003Dz2xg_00247eo_003D) + 32767;
			int num2 = _0023_003DzYAADtuo_003D(_0023_003DzJnCUD94_003D);
			_0023_003DzvuKzWCk_003D._0023_003DzGfYpVMhhz20K = 32767 - num2;
			_0023_003DzvuKzWCk_003D._0023_003DzGfYpVMhhz20K = num2 + 32767;
			_0023_003DzvuKzWCk_003D._0023_003DztptblV0_003D = num2 + num;
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
			for (int i = 0; i < _0023_003DzJnCUD94_003D.portions.Count; i++)
			{
				Portion portion = null;
				portion = ((!_0023_003DzEf3RSN8gQWvMtXrHyw_003D_003D) ? _0023_003DzJnCUD94_003D.portions[i] : ((Portion)_0023_003DzJnCUD94_003D.portions[i].Clone()));
				Array.Clear(portion.user, 0, portion.user.Length);
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion))
				{
					return false;
				}
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D);
			}
			_0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D = _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzwq_iPXTmH2y7(_0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, region3D2);
			if (_0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D.Length == 0)
			{
				return false;
			}
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
			for (int j = 0; j < _0023_003Dz2xg_00247eo_003D.portions.Count; j++)
			{
				Portion portion2 = (Portion)_0023_003Dz2xg_00247eo_003D.portions[j].Clone();
				Array.Clear(portion2.user, 0, portion2.user.Length);
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion2))
				{
					return false;
				}
				portion2.Id += _0023_003DzvuKzWCk_003D._0023_003DzGfYpVMhhz20K;
				for (int k = 1; k <= portion2.edgeCount; k++)
				{
					if (portion2.edgeDatas[k].NextFace < 0)
					{
						portion2.edgeDatas[k].NextEdge += _0023_003DzvuKzWCk_003D._0023_003DzGfYpVMhhz20K;
					}
					else if (portion2.edgeDatas[k].PreviousFace < 0)
					{
						portion2.edgeDatas[k].PreviousEdge += _0023_003DzvuKzWCk_003D._0023_003DzGfYpVMhhz20K;
					}
				}
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion2, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D);
			}
			_0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D = _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzwq_iPXTmH2y7(_0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, region3D);
			if (_0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D.Length == 0)
			{
				return false;
			}
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzWOimfCEgaa7X(_0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D))
			{
				return false;
			}
			int num3 = 0;
			_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = null;
			_0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = null;
			_0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D = new _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D
			{
				_0023_003DzkRSfKls1SLfn = _0023_003Dzm0CYiiE_003D
			};
			for (int l = 0; l < _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count; l++)
			{
				NpStr npStr = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.NpStrList[l];
				if (npStr.len == 0 || Math.Abs(npStr.lab) == 1)
				{
					continue;
				}
				_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions[npStr.hnp - 1];
				num3 = npStr.b;
				for (int m = 0; m < npStr.len; m++)
				{
					int index = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.NbList[num3++];
					NpStr npStr2 = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.NpStrList[index];
					_0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions[npStr2.hnp - 1];
					if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzv7vrvDXssqtt(npStr, npStr2, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
					{
						return false;
					}
					if (npStr2.lab == 2)
					{
						flag = true;
					}
				}
				if (npStr.lab == 2)
				{
					flag = true;
				}
			}
			if (_0023_003DzR7LjAtYImXuc == (_0023_003Dz6tkLYNg_003D)3)
			{
				_0023_003DzvuKzWCk_003D._0023_003Dz_00241Cm8Ev0duOTkgUXhA_003D_003D = _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzdv4W6TqXsv_PKbpd6A_003D_003D(_0023_003DzHC7AYP4_003D);
				return true;
			}
			if (flag)
			{
				_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzSXX9agsLRhhl(_0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, _0023_003DzJnCUD94_003D, _0023_003Dz2xg_00247eo_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
				{
					return false;
				}
				if (_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX)
				{
					_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
					if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzSXX9agsLRhhl(_0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, _0023_003Dz2xg_00247eo_003D, _0023_003DzJnCUD94_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
					{
						return false;
					}
				}
				_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
				for (int n = 0; n < _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count; n++)
				{
					NpStr npStr3 = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.NpStrList[n];
					if ((npStr3.ort & 1) > 0 || (npStr3.ort & 2) > 0)
					{
						if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz1Z59Znx_0024wwab(_0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, npStr3, _0023_003DzJnCUD94_003D.smoothingAngle, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
						{
							return false;
						}
						npStr3.ort = 0;
					}
				}
				if (_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX)
				{
					_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
					for (int num4 = 0; num4 < _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count; num4++)
					{
						NpStr npStr4 = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.NpStrList[num4];
						if ((npStr4.ort & 1) > 0 || (npStr4.ort & 2) > 0)
						{
							if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz1Z59Znx_0024wwab(_0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, npStr4, _0023_003DzJnCUD94_003D.smoothingAngle, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
							{
								return false;
							}
							npStr4.ort = 0;
						}
					}
				}
				_0023_003DzewCvTx8eDaKN(_0023_003DzsJ4FZAuM3q3E, _0023_003DzvuKzWCk_003D, _0023_003DzR7LjAtYImXuc);
				return true;
			}
		}
		else
		{
			switch (_0023_003DzR7LjAtYImXuc)
			{
			case (_0023_003Dz6tkLYNg_003D)3:
				_0023_003DzvuKzWCk_003D._0023_003Dz_00241Cm8Ev0duOTkgUXhA_003D_003D = new List<Segment3D>();
				return true;
			case (_0023_003Dz6tkLYNg_003D)1:
				return true;
			}
		}
		_0023_003DzZhsUDUz3mSgC _0023_003DzqunuPEk_003D = (_0023_003DzZhsUDUz3mSgC)0;
		if (_0023_003DzR7LjAtYImXuc == (_0023_003Dz6tkLYNg_003D)0)
		{
			brepType item;
			if (_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzkdnrtE4uzPF8(_0023_003DzJnCUD94_003D.localMin, _0023_003DzJnCUD94_003D.localMax, _0023_003Dz2xg_00247eo_003D.localMin, _0023_003Dz2xg_00247eo_003D.localMax, ref _0023_003DzqunuPEk_003D))
			{
				if (_0023_003DzJnCUD94_003D.RegenMode == regenType.RegenAndCompile)
				{
					_0023_003DzJnCUD94_003D.Regen(_0023_003Dzm0CYiiE_003D);
				}
				if (_0023_003DzJnCUD94_003D.IsPointInside(_0023_003Dz2xg_00247eo_003D.Portions[0].Vertices[0]))
				{
					item = brepMode;
					_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw = new List<Solid>();
					Solid solid2 = new Solid();
					for (int num5 = 0; num5 < _0023_003DzJnCUD94_003D.portions.Count; num5++)
					{
						Portion item2 = (Portion)_0023_003DzJnCUD94_003D.portions[num5].Clone();
						solid2.portions.Add(item2);
					}
					_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Add(solid2);
					_0023_003DzsJ4FZAuM3q3E.Add(item);
					return true;
				}
				if (_0023_003Dz2xg_00247eo_003D.RegenMode == regenType.RegenAndCompile)
				{
					_0023_003Dz2xg_00247eo_003D.Regen(_0023_003Dzm0CYiiE_003D);
				}
				if (_0023_003Dz2xg_00247eo_003D.IsPointInside(_0023_003DzJnCUD94_003D.Portions[0].Vertices[0]))
				{
					item = brepMode2;
					_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw = new List<Solid>();
					Solid solid3 = new Solid();
					for (int num6 = 0; num6 < _0023_003Dz2xg_00247eo_003D.portions.Count; num6++)
					{
						Portion item3 = (Portion)_0023_003Dz2xg_00247eo_003D.portions[num6].Clone();
						solid3.portions.Add(item3);
					}
					_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Add(solid3);
					_0023_003DzsJ4FZAuM3q3E.Add(item);
					return true;
				}
			}
			_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw = new List<Solid>();
			item = brepMode;
			Solid solid4 = new Solid();
			for (int num7 = 0; num7 < _0023_003DzJnCUD94_003D.portions.Count; num7++)
			{
				Portion item4 = (Portion)_0023_003DzJnCUD94_003D.portions[num7].Clone();
				solid4.portions.Add(item4);
			}
			_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Add(solid4);
			_0023_003DzsJ4FZAuM3q3E.Add(item);
			item = brepMode2;
			Solid solid5 = new Solid();
			for (int num8 = 0; num8 < _0023_003Dz2xg_00247eo_003D.portions.Count; num8++)
			{
				Portion item5 = (Portion)_0023_003Dz2xg_00247eo_003D.portions[num8].Clone();
				solid5.portions.Add(item5);
			}
			_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Add(solid5);
			_0023_003DzsJ4FZAuM3q3E.Add(item);
			return true;
		}
		if (_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzkdnrtE4uzPF8(_0023_003DzJnCUD94_003D.localMin, _0023_003DzJnCUD94_003D.localMax, _0023_003Dz2xg_00247eo_003D.localMin, _0023_003Dz2xg_00247eo_003D.localMax, ref _0023_003DzqunuPEk_003D))
		{
			if (_0023_003DzJnCUD94_003D.RegenMode == regenType.RegenAndCompile)
			{
				_0023_003DzJnCUD94_003D.Regen(_0023_003Dzm0CYiiE_003D);
			}
			if (_0023_003DzJnCUD94_003D.IsPointInside(_0023_003Dz2xg_00247eo_003D.Portions[0].Vertices[0]))
			{
				return _0023_003DzlIJaSTdbqGdASY5NAA_003D_003D(_0023_003DzJnCUD94_003D, _0023_003Dz2xg_00247eo_003D, _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, _0023_003DzR7LjAtYImXuc, _0023_003DzsJ4FZAuM3q3E, _0023_003DzvuKzWCk_003D);
			}
			if (_0023_003Dz2xg_00247eo_003D.RegenMode == regenType.RegenAndCompile)
			{
				_0023_003Dz2xg_00247eo_003D.Regen(_0023_003Dzm0CYiiE_003D);
			}
			if (_0023_003Dz2xg_00247eo_003D.IsPointInside(_0023_003DzJnCUD94_003D.Portions[0].Vertices[0]))
			{
				if (_0023_003DzR7LjAtYImXuc == (_0023_003Dz6tkLYNg_003D)2)
				{
					return true;
				}
				return _0023_003DzlIJaSTdbqGdASY5NAA_003D_003D(_0023_003Dz2xg_00247eo_003D, _0023_003DzJnCUD94_003D, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, _0023_003DzR7LjAtYImXuc, _0023_003DzsJ4FZAuM3q3E, _0023_003DzvuKzWCk_003D);
			}
		}
		if (_0023_003DzR7LjAtYImXuc == (_0023_003Dz6tkLYNg_003D)2)
		{
			_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw = new List<Solid>();
			brepType item = brepMode;
			Solid solid6 = new Solid();
			for (int num9 = 0; num9 < _0023_003DzJnCUD94_003D.portions.Count; num9++)
			{
				Portion item6 = (Portion)_0023_003DzJnCUD94_003D.portions[num9].Clone();
				solid6.portions.Add(item6);
			}
			_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Add(solid6);
			_0023_003DzsJ4FZAuM3q3E.Add(item);
			return true;
		}
		return true;
	}

	private static bool _0023_003DzlIJaSTdbqGdASY5NAA_003D_003D(Solid _0023_003DzJnCUD94_003D, Solid _0023_003Dz2xg_00247eo_003D, Solid _0023_003Dz8aK45ug_003D, Solid _0023_003DzpYHoq8Q_003D, _0023_003Dz6tkLYNg_003D _0023_003DzR7LjAtYImXuc, List<brepType> _0023_003DzsJ4FZAuM3q3E, _0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D)
	{
		if (!_0023_003Dz2xg_00247eo_003D.IsClosed)
		{
			return false;
		}
		if (_0023_003DzR7LjAtYImXuc == (_0023_003Dz6tkLYNg_003D)2)
		{
			foreach (Portion portion3 in _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.Portions)
			{
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzG037o6MQFwqV(portion3, (_0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: false);
			}
		}
		_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw = new List<Solid>();
		Solid solid = new Solid();
		switch (_0023_003DzR7LjAtYImXuc)
		{
		case (_0023_003Dz6tkLYNg_003D)2:
		{
			for (int j = 0; j < _0023_003Dz8aK45ug_003D.Portions.Count; j++)
			{
				Portion portion2 = (Portion)_0023_003Dz8aK45ug_003D.Portions[j].Clone();
				if (_0023_003Dz2xg_00247eo_003D.RegenMode == regenType.RegenAndCompile)
				{
					_0023_003Dz2xg_00247eo_003D.Regen(_0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn);
				}
				if (!_0023_003Dz2xg_00247eo_003D.IsPointInside(portion2.Vertices[0]))
				{
					solid.portions.Add(portion2);
				}
			}
			break;
		}
		case (_0023_003Dz6tkLYNg_003D)1:
		{
			for (int i = 0; i < _0023_003Dz8aK45ug_003D.Portions.Count; i++)
			{
				Portion portion = _0023_003Dz8aK45ug_003D.Portions[i];
				if (_0023_003Dz2xg_00247eo_003D.RegenMode == regenType.RegenAndCompile)
				{
					_0023_003Dz2xg_00247eo_003D.Regen(_0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn);
				}
				if (_0023_003Dz2xg_00247eo_003D.IsPointInside(portion.Vertices[0]))
				{
					solid.portions.Add(portion);
				}
			}
			break;
		}
		}
		for (int k = 0; k < _0023_003DzpYHoq8Q_003D.Portions.Count; k++)
		{
			Portion item = (Portion)_0023_003DzpYHoq8Q_003D.Portions[k].Clone();
			solid.portions.Add(item);
		}
		_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Add(solid);
		if (_0023_003DzR7LjAtYImXuc == (_0023_003Dz6tkLYNg_003D)1 && (!_0023_003DzJnCUD94_003D.IsClosed || !_0023_003Dz2xg_00247eo_003D.IsClosed))
		{
			_0023_003DzsJ4FZAuM3q3E.Add(brepType.Shell);
		}
		else
		{
			_0023_003DzsJ4FZAuM3q3E.Add(brepType.Body);
		}
		return true;
	}

	private static int _0023_003DzYAADtuo_003D(Solid _0023_003DzQUhnjVe9kSO_0024)
	{
		int num = -32767;
		for (int i = 0; i < _0023_003DzQUhnjVe9kSO_0024.portions.Count; i++)
		{
			if (_0023_003DzQUhnjVe9kSO_0024.portions[i].Id > num)
			{
				num = _0023_003DzQUhnjVe9kSO_0024.portions[i].Id;
			}
		}
		return num + 1;
	}

	private static bool _0023_003Dz7mr_4Z4_003D(Solid _0023_003DzCX9Hbao_003D, PlaneEquation _0023_003Dzrgqz890sj_0024X9, bool _0023_003DzjMikPdqXh_0024DX, out List<ICurve> _0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D)
	{
		_0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D = new List<ICurve>();
		Portion _0023_003DzyZZx2zHPARUh = new Portion(500, 500, 202, 222);
		_ = _0023_003DzCX9Hbao_003D._brepMode;
		Region3D region3D = new Region3D(_0023_003DzCX9Hbao_003D.localMin, _0023_003DzCX9Hbao_003D.localMax);
		_0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D2 = new _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D();
		_0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D2._0023_003DzkRSfKls1SLfn = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(region3D.min, region3D.max);
		bool _0023_003DzavRLjnVSS3pZ = false;
		int count = _0023_003DzCX9Hbao_003D.portions.Count;
		for (int i = 0; i < count; i++)
		{
			Portion _0023_003DzTKYiqJDMa59O = (Portion)_0023_003DzCX9Hbao_003D.portions[i].Clone();
			if (i == count - 1)
			{
				_0023_003DzavRLjnVSS3pZ = true;
			}
			_0023_003Dz_dbM69lbzOGi(_0023_003DzyZZx2zHPARUh, _0023_003Dzrgqz890sj_0024X9, _0023_003DzTKYiqJDMa59O, ref _0023_003DzavRLjnVSS3pZ, _0023_003DzjMikPdqXh_0024DX, out _0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D2);
			_0023_003DzavRLjnVSS3pZ = false;
		}
		return true;
	}

	private static bool _0023_003Dz_dbM69lbzOGi(Portion _0023_003DzyZZx2zHPARUh, PlaneEquation _0023_003Dzrgqz890sj_0024X9, Portion _0023_003DzTKYiqJDMa59O, ref bool _0023_003DzavRLjnVSS3pZ, bool _0023_003DzjMikPdqXh_0024DX, out List<ICurve> _0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		_0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D = new List<ICurve>();
		_0023_003DzTKYiqJDMa59O.UpdateBoundingBox(null);
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzq9H_u3Dp5eSRXEAAxJLRmGA_003D(_0023_003DzTKYiqJDMa59O.localMin, _0023_003DzTKYiqJDMa59O.localMax, _0023_003Dzrgqz890sj_0024X9, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
		{
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(_0023_003DzTKYiqJDMa59O))
			{
				return false;
			}
			if (!_0023_003Dz59OjAf21dO0G(_0023_003DzTKYiqJDMa59O, _0023_003Dzrgqz890sj_0024X9, _0023_003DzyZZx2zHPARUh, _0023_003DzjMikPdqXh_0024DX, _0023_003DzHC7AYP4_003D))
			{
				return false;
			}
		}
		if (_0023_003DzavRLjnVSS3pZ && _0023_003DzyZZx2zHPARUh.vertexCount > 0)
		{
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DztWzwn4n4VFgh(_0023_003DzyZZx2zHPARUh))
			{
				return false;
			}
			int num = 1;
			do
			{
				int num3;
				int num2 = (num3 = _0023_003DzyZZx2zHPARUh.cycles[num].FirstEdge);
				int num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num3, _0023_003DzyZZx2zHPARUh);
				Point3D point3D = new Point3D(_0023_003DzyZZx2zHPARUh._vertices[num4].X, _0023_003DzyZZx2zHPARUh._vertices[num4].Y, _0023_003DzyZZx2zHPARUh._vertices[num4].Z);
				do
				{
					num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num3, _0023_003DzyZZx2zHPARUh);
					Point3D point3D2 = new Point3D(_0023_003DzyZZx2zHPARUh._vertices[num4].X, _0023_003DzyZZx2zHPARUh._vertices[num4].Y, _0023_003DzyZZx2zHPARUh._vertices[num4].Z);
					if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(point3D, point3D2, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
					{
						_0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D.Add(new Line(new Point3D(point3D.X, point3D.Y, point3D.Z), new Point3D(point3D2.X, point3D2.Y, point3D2.Z)));
						point3D.X = point3D2.X;
						point3D.Y = point3D2.Y;
						point3D.Z = point3D2.Z;
					}
					num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003DzyZZx2zHPARUh);
				}
				while (num3 != num2 && num3 != 0);
				num = _0023_003DzyZZx2zHPARUh.cycles[num].NextContour;
			}
			while (num != 0);
		}
		return true;
	}

	private static bool _0023_003Dz59OjAf21dO0G(Portion _0023_003DzTKYiqJDMa59O, PlaneEquation _0023_003Dzrgqz890sj_0024X9, Portion _0023_003DzyZZx2zHPARUh, bool _0023_003DzjMikPdqXh_0024DX, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> list = new List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D>();
		for (int i = 1; i <= _0023_003DzTKYiqJDMa59O.faceCount; i++)
		{
			Vector3D vector3D = _0023_003DzTKYiqJDMa59O.planes[i];
			if ((Math.Abs(vector3D.X - _0023_003Dzrgqz890sj_0024X9.X) <= 1E-06 && Math.Abs(vector3D.Y - _0023_003Dzrgqz890sj_0024X9.Y) <= 1E-06 && Math.Abs(vector3D.Z - _0023_003Dzrgqz890sj_0024X9.Z) <= 1E-06) || (Math.Abs(vector3D.X + _0023_003Dzrgqz890sj_0024X9.X) <= 1E-06 && Math.Abs(vector3D.Y + _0023_003Dzrgqz890sj_0024X9.Y) <= 1E-06 && Math.Abs(vector3D.Z + _0023_003Dzrgqz890sj_0024X9.Z) <= 1E-06))
			{
				continue;
			}
			list.Clear();
			_0023_003DzTKYiqJDMa59O.novTemp = _0023_003DzTKYiqJDMa59O.MaxNov;
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzvbTb47elbjLr(_0023_003DzTKYiqJDMa59O, i, list, _0023_003Dzrgqz890sj_0024X9, _0023_003DzHC7AYP4_003D))
			{
				return false;
			}
			if (list.Count != 0)
			{
				int _0023_003DzvQElbssTl3_h = _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_0024LYVLiAhnEq9(_0023_003DzTKYiqJDMa59O.planes[i], _0023_003Dzrgqz890sj_0024X9);
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzCgqNlbtmU44p(_0023_003DzTKYiqJDMa59O._vertices, list, _0023_003DzvQElbssTl3_h);
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzLbivDhTyQLaA(_0023_003DzTKYiqJDMa59O, list, _0023_003Dzrgqz890sj_0024X9, _0023_003DzyZZx2zHPARUh, _0023_003DzjMikPdqXh_0024DX, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
				{
					return false;
				}
			}
		}
		return true;
	}

	private static bool _0023_003DzewCvTx8eDaKN(List<brepType> _0023_003DzSVQ0RoeOw_0024J2, _0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003Dz6tkLYNg_003D _0023_003DzR7LjAtYImXuc)
	{
		_0023_003DzvuKzWCk_003D._0023_003DzsBlr79I_003D = new Solid();
		Solid solid = null;
		for (int i = 0; i < _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count; i++)
		{
			NpStr npStr = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.NpStrList[i];
			if (npStr.lab == 1 && npStr.hnp > 0 && npStr.hnp <= _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count)
			{
				Portion _0023_003Dzd9ZyL64_003D = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions[npStr.hnp - 1];
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(_0023_003Dzd9ZyL64_003D))
				{
					return false;
				}
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz25b412zrrUM6(_0023_003Dzd9ZyL64_003D, _0023_003DzvuKzWCk_003D._0023_003DzsBlr79I_003D);
			}
		}
		if (_0023_003DzR7LjAtYImXuc != (_0023_003Dz6tkLYNg_003D)1)
		{
			solid = new Solid();
			for (int j = 0; j < _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count; j++)
			{
				NpStr npStr2 = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.NpStrList[j];
				if (npStr2.lab == 0 && npStr2.hnp > 0 && npStr2.hnp <= _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count)
				{
					Portion _0023_003Dzd9ZyL64_003D2 = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions[npStr2.hnp - 1];
					if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(_0023_003Dzd9ZyL64_003D2))
					{
						return false;
					}
					_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz25b412zrrUM6(_0023_003Dzd9ZyL64_003D2, solid);
				}
			}
			if (solid.Portions.Count == 0)
			{
				solid = null;
			}
		}
		if (_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX && _0023_003DzvuKzWCk_003D._0023_003DzjTwYx_xFB7Cw)
		{
			for (int k = 0; k < _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count; k++)
			{
				NpStr npStr3 = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.NpStrList[k];
				if (npStr3.lab == 1 && npStr3.hnp > 0 && npStr3.hnp <= _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count)
				{
					Portion _0023_003Dzd9ZyL64_003D3 = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions[npStr3.hnp - 1];
					if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(_0023_003Dzd9ZyL64_003D3))
					{
						return false;
					}
					_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz25b412zrrUM6(_0023_003Dzd9ZyL64_003D3, _0023_003DzvuKzWCk_003D._0023_003DzsBlr79I_003D);
				}
			}
		}
		if (_0023_003DzvuKzWCk_003D._0023_003DzsBlr79I_003D.portions.Count == 0)
		{
			return true;
		}
		if (!_0023_003DzGjH3EgU_003D(_0023_003DzvuKzWCk_003D._0023_003DzsBlr79I_003D, _0023_003DzSVQ0RoeOw_0024J2, _0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX, ref _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw))
		{
			return false;
		}
		if (solid != null)
		{
			_0023_003DzZhsUDUz3mSgC _0023_003DzqunuPEk_003D = (_0023_003DzZhsUDUz3mSgC)0;
			solid.Regen(_0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn);
			for (int l = 0; l < _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Count; l++)
			{
				Solid solid2 = _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw[l];
				solid2.UpdateBoundingBox(null);
				if (_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzkdnrtE4uzPF8(solid.localMin, solid.localMax, solid2.localMin, solid2.localMax, ref _0023_003DzqunuPEk_003D) && solid.IsPointInside(solid2.Portions[0].Vertices[0]))
				{
					for (int m = 0; m < solid2.Portions.Count; m++)
					{
						_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz25b412zrrUM6(solid2.Portions[m], solid);
					}
					_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.RemoveAt(l);
					l--;
				}
			}
			_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Add(solid);
		}
		_0023_003DzZhsUDUz3mSgC _0023_003DzqunuPEk_003D2 = (_0023_003DzZhsUDUz3mSgC)0;
		for (int num = _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Count - 1; num >= 0; num--)
		{
			Solid solid3 = _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw[num];
			solid3.UpdateBoundingBox(null);
			for (int n = 0; n < _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.Count; n++)
			{
				if (n == num)
				{
					continue;
				}
				Solid solid4 = _0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw[n];
				solid4.UpdateBoundingBox(null);
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzkdnrtE4uzPF8(solid4.localMin, solid4.localMax, solid3.localMin, solid3.localMax, ref _0023_003DzqunuPEk_003D2))
				{
					continue;
				}
				if (solid4.RegenMode == regenType.RegenAndCompile)
				{
					solid4.Regen(_0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn);
				}
				if (solid4.IsPointInside(solid3.Portions[0].Vertices[0]))
				{
					for (int num2 = 0; num2 < solid3.Portions.Count; num2++)
					{
						_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz25b412zrrUM6(solid3.Portions[num2], solid4);
					}
					_0023_003DzvuKzWCk_003D._0023_003DzgWXM4q_HW0Kw.RemoveAt(num);
					_0023_003DzSVQ0RoeOw_0024J2.RemoveAt(num);
					break;
				}
			}
		}
		return true;
	}

	private static bool _0023_003DzGjH3EgU_003D(Solid _0023_003DzcDEsV8s_003D, List<brepType> _0023_003DzSVQ0RoeOw_0024J2, bool _0023_003DzxQA1_xTLS9Wb, ref List<Solid> _0023_003Dz6NQ8Tl97Q_m9)
	{
		_0023_003Dz6NQ8Tl97Q_m9 = new List<Solid>();
		NpStr npStr = new NpStr();
		int count;
		do
		{
			Solid solid = new Solid();
			count = _0023_003DzcDEsV8s_003D.portions.Count;
			int num = 0;
			int num2 = 0;
			NpStr npStr2;
			while (true)
			{
				npStr2 = _0023_003DzcDEsV8s_003D.NpStrList[num++];
				if (npStr2.lab == 0)
				{
					break;
				}
				num2++;
			}
			npStr2.lab = 1;
			int num3 = -32767;
			int num4 = 0;
			int num5;
			do
			{
				num5 = num4;
				num4 = 0;
				for (int i = num2; i < _0023_003DzcDEsV8s_003D.portions.Count; i++)
				{
					NpStr npStr3 = _0023_003DzcDEsV8s_003D.NpStrList[i];
					if (npStr3.lab == 2 || npStr3.lab == 0)
					{
						continue;
					}
					num4++;
					if (npStr3.ort == 1)
					{
						continue;
					}
					npStr3.ort = 1;
					if (npStr3.len == 0)
					{
						goto end_IL_005d;
					}
					int b = npStr3.b;
					int _0023_003DzSkUy_T8_003D;
					for (int j = 0; j < npStr3.len; j++)
					{
						_0023_003DzSkUy_T8_003D = _0023_003DzcDEsV8s_003D.NbList[b++];
						if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzqZtmF1Q1XoHn(_0023_003DzcDEsV8s_003D, _0023_003DzSkUy_T8_003D, npStr, out var _0023_003Dz_0024n2nrac_003D))
						{
							return false;
						}
						if (npStr.lab != 1)
						{
							npStr.lab = 1;
							npStr.ort = 0;
							_0023_003Dz_0024n2nrac_003D._0023_003DzbByTzLTAlIM7(npStr);
						}
					}
					_0023_003DzSkUy_T8_003D = 0;
				}
				continue;
				end_IL_005d:
				break;
			}
			while (num4 != count && num4 != num5);
			count = 0;
			Region3D region3D = new Region3D(Point3D.MaxValue, Point3D.MinValue);
			for (int k = 0; k < _0023_003DzcDEsV8s_003D.portions.Count; k++)
			{
				NpStr npStr4 = _0023_003DzcDEsV8s_003D.NpStrList[k];
				if (npStr4.lab == 2)
				{
					continue;
				}
				if (npStr4.lab == 0)
				{
					count++;
					continue;
				}
				if (num3 <= npStr4.ident)
				{
					num3 = npStr4.ident;
				}
				Portion portion = _0023_003DzcDEsV8s_003D.portions[npStr4.hnp - 1];
				portion.UpdateBoundingBox(null);
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzgdSKwlxtRL1Q(region3D, new Region3D(portion.localMin, portion.localMax), region3D);
				npStr4.lab = 2;
				solid.portions.Add(portion);
				solid.NpStrList.Add(npStr4);
				solid.NpStrDict.Add(npStr4.ident, npStr4);
			}
			brepType item = ((!_0023_003DzxQA1_xTLS9Wb) ? brepType.Shell : brepType.Body);
			_0023_003DzSVQ0RoeOw_0024J2.Add(item);
			_0023_003Dz6NQ8Tl97Q_m9.Add(solid);
		}
		while (count != 0);
		return true;
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		return Section(pln.Equation);
	}

	public ICurve[] Section(PlaneEquation planeEquation)
	{
		_0023_003Dz7mr_4Z4_003D(this, planeEquation, _0023_003DzjMikPdqXh_0024DX: true, out var _0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D);
		if (_0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D.Count == 0)
		{
			return _0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D.ToArray();
		}
		List<List<ICurve>> list = Utility._0023_003Dzx1_VB8cQKrRRV2_0024w7g_003D_003D(_0023_003Dzfzkdwrx2qhlGqS0DhA_003D_003D, 1E-12, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: false, _0023_003Dzp9LPrpP9wSDR: false);
		ICurve[] array = new ICurve[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			List<Point3D> list2 = new List<Point3D>();
			list2.Add(((Line)list[i][0]).StartPoint);
			foreach (Line item in list[i])
			{
				list2.Add(item.EndPoint);
			}
			array[i] = new LinearPath(list2);
		}
		return array;
	}

	public static Segment3D[] IntersectionLoops(Solid a, Solid b, double tol = 0.0)
	{
		return _0023_003Dz61n4LZlPE9DOUt4jAA_003D_003D(a, b, _0023_003DzEf3RSN8gQWvMtXrHyw_003D_003D: true, tol);
	}

	private static Segment3D[] _0023_003Dz61n4LZlPE9DOUt4jAA_003D_003D(Solid _0023_003DzJnCUD94_003D, Solid _0023_003Dz2xg_00247eo_003D, bool _0023_003DzEf3RSN8gQWvMtXrHyw_003D_003D, double _0023_003Dzm0CYiiE_003D)
	{
		if (!_0023_003DzNC7p9G80lhFN(_0023_003DzJnCUD94_003D, _0023_003Dz2xg_00247eo_003D, (_0023_003Dz6tkLYNg_003D)3, null, _0023_003DzEf3RSN8gQWvMtXrHyw_003D_003D, _0023_003Dzm0CYiiE_003D, out var _0023_003DzvuKzWCk_003D))
		{
			return null;
		}
		return _0023_003DzvuKzWCk_003D._0023_003Dz_00241Cm8Ev0duOTkgUXhA_003D_003D.ToArray();
	}

	public booleanFailureType CutBy(Plane plane)
	{
		Solid[] leftOvers;
		return CutBy(plane, out leftOvers);
	}

	public booleanFailureType CutBy(Plane plane, out Solid[] leftOvers)
	{
		return CutBy(plane, keepOriginalColors: false, out leftOvers);
	}

	public booleanFailureType CutBy(Plane plane, bool keepOriginalColors)
	{
		Solid[] leftOvers;
		return CutBy(plane, keepOriginalColors, out leftOvers);
	}

	public booleanFailureType CutBy(Plane plane, bool keepOriginalColors, out Solid[] leftOvers)
	{
		bool _0023_003DzWUbV5AMmMjEtrqcxag_003D_003D;
		List<Point3D> _0023_003Dz_SqBXz8_003D = _0023_003DzFpmmSOKJozUUP_qWVg_003D_003D(plane, this, out _0023_003DzWUbV5AMmMjEtrqcxag_003D_003D);
		leftOvers = null;
		if (_0023_003DzWUbV5AMmMjEtrqcxag_003D_003D)
		{
			return booleanFailureType.NotIntersecting;
		}
		Point3D boxMin = base.BoxMin;
		Point3D boxMax = base.BoxMax;
		Vector3D vector3D = new Vector3D(boxMax.X - boxMin.X, boxMax.Y - boxMin.Y, boxMax.Z - boxMin.Z);
		if (!_0023_003DzcX4pmfTQmEh2nNCz3A_003D_003D(_0023_003Dz_SqBXz8_003D, vector3D.Length * 1.05 * plane.AxisZ, _0023_003Dz5q1w0P79Gecn: true, keepOriginalColors, out leftOvers))
		{
			if (_0023_003Dz07AstpQ_003D(plane))
			{
				return booleanFailureType.Failed;
			}
			return booleanFailureType.NotIntersecting;
		}
		return booleanFailureType.Success;
	}

	private bool _0023_003Dz07AstpQ_003D(Plane _0023_003Dzrgqz890sj_0024X9)
	{
		int num = 0;
		bool flag = true;
		for (int i = 0; i < portions.Count; i++)
		{
			Point3D[] vertices = portions[i].Vertices;
			for (int j = 0; j < portions[i].VertexCount; j++)
			{
				int num2 = Math.Sign(_0023_003Dzrgqz890sj_0024X9.DistanceTo(vertices[j]));
				if (num2 != 0)
				{
					if (flag)
					{
						flag = false;
						num = num2;
					}
					else if (num2 != num)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void _0023_003Dz_00246_6laMMoobS(Solid _0023_003DzySgeilxprQOK, bool _0023_003Dzu9oxwJ_zKlMt)
	{
		EntityGraphicsData[,] array = null;
		if (portions != null)
		{
			array = new EntityGraphicsData[portions.Count, 3];
			for (int i = 0; i < portions.Count; i++)
			{
				array[i, 0] = portions[i].drawData;
				array[i, 1] = portions[i].drawEdgesData;
				array[i, 2] = portions[i].drawSelectedData;
			}
		}
		_brepMode = _0023_003DzySgeilxprQOK._brepMode;
		localMin = (Point3D)_0023_003DzySgeilxprQOK.localMin.Clone();
		localMax = (Point3D)_0023_003DzySgeilxprQOK.localMax.Clone();
		NodeList = new List<MNODE>();
		_0023_003DzFiTFoZw_003D(_0023_003DzySgeilxprQOK, _0023_003Dz6DPkFnsSJEJc: false, _0023_003Dzu9oxwJ_zKlMt);
		if (array != null)
		{
			int num = Math.Min(array.GetLength(0), portions.Count);
			for (int j = 0; j < num; j++)
			{
				portions[j].drawData = array[j, 0];
				portions[j].drawEdgesData = array[j, 1];
				portions[j].drawSelectedData = array[j, 2];
			}
			if (num < portions.Count)
			{
				for (int k = num; k < portions.Count; k++)
				{
					portions[k].drawData = array[0, 0];
					portions[k].drawEdgesData = array[0, 1];
					portions[k].drawSelectedData = array[0, 2];
				}
			}
		}
		UseInnerColors = _0023_003DzySgeilxprQOK.UseInnerColors;
		if (!_0023_003Dzu9oxwJ_zKlMt)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		if (_0023_003DzySgeilxprQOK.textureMapping == null)
		{
			textureMapping = null;
		}
		else
		{
			textureMapping = (TextureMappingData)_0023_003DzySgeilxprQOK.textureMapping.Clone();
		}
	}

	private static List<Point3D> _0023_003DzFpmmSOKJozUUP_qWVg_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Solid _0023_003DzQUhnjVe9kSO_0024, out bool _0023_003DzWUbV5AMmMjEtrqcxag_003D_003D)
	{
		return Utility.GetPlanarIntersectionProfile(_0023_003Dzrgqz890sj_0024X9, _0023_003DzQUhnjVe9kSO_0024.BoxMin, _0023_003DzQUhnjVe9kSO_0024.BoxMax, out _0023_003DzWUbV5AMmMjEtrqcxag_003D_003D);
	}

	public bool SplitBy(Plane plane, out Solid[] splitF, out Solid[] splitG)
	{
		splitF = null;
		splitG = null;
		bool _0023_003DzWUbV5AMmMjEtrqcxag_003D_003D;
		List<Point3D> list = _0023_003DzFpmmSOKJozUUP_qWVg_003D_003D(plane, this, out _0023_003DzWUbV5AMmMjEtrqcxag_003D_003D);
		if (list == null)
		{
			return false;
		}
		Point3D boxMin = base.BoxMin;
		Point3D boxMax = base.BoxMax;
		double num = new Vector3D(boxMax.X - boxMin.X, boxMax.Y - boxMin.Y, boxMax.Z - boxMin.Z).Length * 1.05;
		Solid b = _0023_003DzFPVyG4Y9TGyH(list, null, num * plane.AxisZ, _0023_003Dz5q1w0P79Gecn: true);
		Solid b2 = _0023_003DzFPVyG4Y9TGyH(list, null, (0.0 - num) * plane.AxisZ, _0023_003Dz5q1w0P79Gecn: true);
		splitF = Difference(this, b);
		splitG = Difference(this, b2);
		return true;
	}

	public static Solid CreateBox(double width, double depth, double height)
	{
		return CreateBox<Solid>(width, depth, height);
	}

	public static T CreateBox<T>(double width, double depth, double height) where T : Solid, new()
	{
		if (width < Utility._0023_003DzheSR8QM7q9ya || depth < Utility._0023_003DzheSR8QM7q9ya || height < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		T val = new T();
		val.NodeList = new List<MNODE>();
		val._0023_003DzOh3vvRwzYwP4(width, depth, height);
		val.UpdateBoundingBox(null);
		return val;
	}

	private bool _0023_003DzOh3vvRwzYwP4(double _0023_003Dz8Qvu0ng_003D, double _0023_003DzGtl_00242eA_003D, double _0023_003DzrkNyH_00248_003D)
	{
		double num = _0023_003Dz8Qvu0ng_003D;
		double num2 = _0023_003DzGtl_00242eA_003D;
		double num3 = _0023_003DzrkNyH_00248_003D;
		int num4 = 8;
		int num5 = 12;
		int num6 = 6;
		int contourCount = 6;
		Portion portion = new Portion();
		int[] array = new int[12]
		{
			0, 0, 0, 1, 1, 2, 2, 3, 4, 4,
			5, 6
		};
		int[] array2 = new int[12]
		{
			1, 3, 4, 2, 5, 3, 6, 7, 5, 7,
			6, 7
		};
		int[] array3 = new int[13]
		{
			0, 1, 3, 2, 1, 4, 1, 5, 3, 2,
			6, 4, 5
		};
		int[] array4 = new int[13]
		{
			0, 4, 8, 9, 6, 11, -2, 12, -10, -5,
			-12, -7, -8
		};
		int[] array5 = new int[13]
		{
			0, 2, 1, 3, 4, 2, 5, 4, 5, 6,
			3, 6, 6
		};
		int[] array6 = new int[13]
		{
			0, 3, 1, 2, 5, -1, 7, -4, -6, 10,
			-3, -9, -11
		};
		int[] array7 = new int[7] { 0, 1, -1, 2, 5, 7, 10 };
		if (Math.Abs(num) <= 1E-06)
		{
			num += 10.0 * Utility._0023_003DzheSR8QM7q9ya;
		}
		if (Math.Abs(num2) <= 1E-06)
		{
			num2 += 10.0 * Utility._0023_003DzheSR8QM7q9ya;
		}
		if (Math.Abs(num3) <= 1E-06)
		{
			num3 += 10.0 * Utility._0023_003DzheSR8QM7q9ya;
		}
		portion._vertices[0] = new Point3D(0.0, 0.0, 0.0);
		portion._vertices[1] = new Point3D(0.0, 0.0, num3);
		portion._vertices[2] = new Point3D(0.0, num2, num3);
		portion._vertices[3] = new Point3D(0.0, num2, 0.0);
		int num7 = num4 / 2;
		for (int i = 0; i < num4 / 2; i++)
		{
			portion._vertices[num7++] = new Point3D(num, portion._vertices[i].Y, portion._vertices[i].Z);
		}
		portion.vertexCount = num4;
		for (int j = 1; j <= num5; j++)
		{
			portion.edgeDatas[j].BeginVertex = array[j - 1];
			portion.edgeDatas[j].EndVertex = array2[j - 1];
			portion.edgeDatas[j].NextFace = array3[j];
			portion.edgeDatas[j].NextEdge = array4[j];
			portion.edgeDatas[j].PreviousFace = array5[j];
			portion.edgeDatas[j].PreviousEdge = array6[j];
			portion.edgeDatas[j].Type = 1;
		}
		portion.edgeCount = num5;
		for (int k = 1; k <= num6; k++)
		{
			portion.faces[k].FirstContour = k;
			portion.faces[k].FaceLabel = 1;
			portion.cycles[k].FirstEdge = array7[k];
			portion.cycles[k].NextContour = 0;
		}
		portion.faceCount = num6;
		portion.contourCount = contourCount;
		portion.Id = -32767;
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzfn6hhMMnY_jS(portion))
		{
			return false;
		}
		portions.Add(portion);
		return true;
	}

	public static Solid CreateCone(double bottomRadius, double topRadius, double height, int slices)
	{
		return CreateCone<Solid>(bottomRadius, topRadius, height, slices);
	}

	public static T CreateCone<T>(double bottomRadius, double topRadius, double height, int slices) where T : Solid, new()
	{
		if ((bottomRadius < Utility._0023_003DzheSR8QM7q9ya && topRadius < Utility._0023_003DzheSR8QM7q9ya) || height < Utility._0023_003DzheSR8QM7q9ya || slices < 2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		T val = new T();
		Point3D _0023_003DzF7v9r2A_003D = new Point3D(0.0 - Math.Max(bottomRadius, topRadius), 0.0 - Math.Max(bottomRadius, topRadius), 0.0);
		Point3D _0023_003Dz8dK2uhU_003D = new Point3D(Math.Max(bottomRadius, topRadius), Math.Max(bottomRadius, topRadius), height);
		double _0023_003DzkRSfKls1SLfn = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		val.NodeList = new List<MNODE>();
		if (val._0023_003DzDmLRxrTZn4dW(bottomRadius, topRadius, height, slices, _0023_003DzkRSfKls1SLfn) == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		val.UpdateBoundingBox(null);
		return val;
	}

	public static Solid CreateCone(double bottomRadius, double topRadius, Point3D point1, Point3D point2, int slices)
	{
		return CreateCone<Solid>(bottomRadius, topRadius, point1, point2, slices);
	}

	public static T CreateCone<T>(double bottomRadius, double topRadius, Point3D point1, Point3D point2, int slices) where T : Solid, new()
	{
		Vector3D vector3D = Vector3D.Subtract(point2, point1);
		if ((bottomRadius < Utility._0023_003DzheSR8QM7q9ya && topRadius < Utility._0023_003DzheSR8QM7q9ya) || vector3D.Length < Utility._0023_003DzheSR8QM7q9ya || slices < 2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		T val = new T();
		Point3D _0023_003DzF7v9r2A_003D = new Point3D(0.0 - Math.Max(bottomRadius, topRadius), 0.0 - Math.Max(bottomRadius, topRadius), 0.0);
		Point3D _0023_003Dz8dK2uhU_003D = new Point3D(Math.Max(bottomRadius, topRadius), Math.Max(bottomRadius, topRadius), vector3D.Length);
		double _0023_003DzkRSfKls1SLfn = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		val.NodeList = new List<MNODE>();
		if (val._0023_003DzDmLRxrTZn4dW(bottomRadius, topRadius, vector3D.Length, slices, _0023_003DzkRSfKls1SLfn) == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		val.TransformBy(Utility.GetOrientationTransformation(point1, vector3D) * new Rotation(Math.PI / 2.0, Vector3D.AxisY));
		val.UpdateBoundingBox(null);
		return val;
	}

	private int _0023_003DzDmLRxrTZn4dW(double _0023_003DzerTCYakiui4_0024, double _0023_003DzEuBWN00Nyfof, double _0023_003DzvAxV_0024Ic_003D, int _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, double _0023_003DzkRSfKls1SLfn)
	{
		int _0023_003DzSkUy_T8_003D = -32767;
		double num = Math.PI * 2.0 / (double)_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D;
		_ = (double)_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D / 4.0;
		double num2 = _0023_003DzerTCYakiui4_0024;
		double z = 0.0;
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j <= _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D; j++)
			{
				double num3 = ((j == _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D) ? (Math.PI * 2.0) : (num * (double)j));
				MNODE item = new MNODE(new Point3D
				{
					X = num2 * Math.Cos(num3),
					Y = num2 * Math.Sin(num3),
					Z = z
				}, 32768);
				NodeList.Add(item);
			}
			num2 = _0023_003DzEuBWN00Nyfof;
			z = _0023_003DzvAxV_0024Ic_003D;
		}
		new _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D(NodeList)._0023_003DzKlS_0024RTSkHohzMAAySQ_003D_003D(this, ref _0023_003DzSkUy_T8_003D, 2, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D + 1, 0.0, _0023_003DzkRSfKls1SLfn);
		Portion _0023_003Dzd9ZyL64_003D = null;
		if (_0023_003DzerTCYakiui4_0024 > Utility._0023_003DzheSR8QM7q9ya)
		{
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz37UDgYerq6IE(out _0023_003Dzd9ZyL64_003D, _0023_003DzerTCYakiui4_0024, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, 0.0, ref _0023_003DzSkUy_T8_003D))
			{
				return 0;
			}
			_0023_003Dzd9ZyL64_003D.faces[1].FaceLabel = 1;
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(_0023_003Dzd9ZyL64_003D, this))
			{
				return 0;
			}
		}
		if (_0023_003DzEuBWN00Nyfof > Utility._0023_003DzheSR8QM7q9ya)
		{
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz37UDgYerq6IE(out _0023_003Dzd9ZyL64_003D, _0023_003DzEuBWN00Nyfof, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, _0023_003DzvAxV_0024Ic_003D, ref _0023_003DzSkUy_T8_003D))
			{
				return 0;
			}
			_0023_003Dzd9ZyL64_003D.faces[1].FaceLabel = 1;
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(_0023_003Dzd9ZyL64_003D, this))
			{
				return 0;
			}
		}
		return _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzFipFikVW1CJj(this, (_0023_003Dz1IcEX2Y45sL1)0, 30f, null, _0023_003DzkRSfKls1SLfn);
	}

	public static Solid CreatePlanar(Plane sketchPlane, IList<Point2D> outer)
	{
		return CreatePlanar<Solid>(sketchPlane, outer, null);
	}

	public static T CreatePlanar<T>(Plane sketchPlane, IList<Point2D> outer) where T : Solid, new()
	{
		return CreatePlanar<T>(sketchPlane, outer, null);
	}

	public static Solid CreatePlanar(Plane sketchPlane, IList<Point2D> outer, IList<IList<Point2D>> inners)
	{
		return CreatePlanar<Solid>(sketchPlane, outer, inners);
	}

	public static T CreatePlanar<T>(Plane sketchPlane, IList<Point2D> outer, IList<IList<Point2D>> inners) where T : Solid, new()
	{
		return _0023_003DzrXbqquWbOFtc<Point2D, T>(sketchPlane, outer, inners);
	}

	[Obsolete("Use Region.ConvertToSolid() instead.")]
	public static Solid CreatePlanar(IList<Point3D> outer)
	{
		return _0023_003DzranJPDlPiZC7<Solid>(outer, null);
	}

	internal static T _0023_003DzranJPDlPiZC7<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja) where T : Solid, new()
	{
		return _0023_003DzrXbqquWbOFtc<Point3D, T>(null, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja);
	}

	internal static T _0023_003DzranJPDlPiZC7<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D) where T : Solid, new()
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		return _0023_003DzranJPDlPiZC7<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
	}

	private static S _0023_003DzrXbqquWbOFtc<T, S>(Plane _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, IList<T> _0023_003Dz_SqBXz8_003D, IList<IList<T>> _0023_003DzWaFlkhfmYCja) where T : Point2D where S : Solid, new()
	{
		Mesh mesh = Mesh._0023_003DzrXbqquWbOFtc<T, Mesh>(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, Mesh.natureType.Plain);
		return FromTriangles<S>(mesh._vertices, mesh._triangles);
	}

	public static Solid CreateCylinder(double radius, double height, int slices)
	{
		return CreateCylinder<Solid>(radius, height, slices);
	}

	public static T CreateCylinder<T>(double radius, double height, int slices) where T : Solid, new()
	{
		if (radius < Utility._0023_003DzheSR8QM7q9ya || height < Utility._0023_003DzheSR8QM7q9ya || slices < 2)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		T val = new T();
		Point3D _0023_003DzF7v9r2A_003D = new Point3D(0.0 - radius, 0.0 - radius, 0.0);
		Point3D _0023_003Dz8dK2uhU_003D = new Point3D(radius, radius, height);
		double _0023_003DzkRSfKls1SLfn = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		val.NodeList = new List<MNODE>();
		if (val._0023_003DzemGI3UmCyMTBvKk8Pw_003D_003D(radius, height, slices, _0023_003DzkRSfKls1SLfn) == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		val.UpdateBoundingBox(null);
		return val;
	}

	public static Solid CreateCylinder(double radius, Point3D point1, Point3D point2, int slices)
	{
		return CreateCylinder<Solid>(radius, point1, point2, slices);
	}

	public static T CreateCylinder<T>(double radius, Point3D point1, Point3D point2, int slices) where T : Solid, new()
	{
		Vector3D vector3D = Vector3D.Subtract(point2, point1);
		T val = CreateCylinder<T>(radius, vector3D.Length, slices);
		val.TransformBy(Utility.GetOrientationTransformation(point1, vector3D) * new Rotation(Math.PI / 2.0, Vector3D.AxisY));
		return val;
	}

	private int _0023_003DzemGI3UmCyMTBvKk8Pw_003D_003D(double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzvAxV_0024Ic_003D, int _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, double _0023_003DzkRSfKls1SLfn)
	{
		int _0023_003DzSkUy_T8_003D = -32767;
		double num = Math.PI * 2.0 / (double)_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D;
		for (int i = 0; i < _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D + 1; i++)
		{
			double num2 = ((i == _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D) ? (Math.PI * 2.0) : (num * (double)i));
			MNODE item = new MNODE(new Point3D
			{
				X = _0023_003DzEGKj_0024SNUUihi * Math.Cos(num2),
				Y = _0023_003DzEGKj_0024SNUUihi * Math.Sin(num2),
				Z = 0.0
			}, 32768);
			NodeList.Add(item);
		}
		for (short num3 = 0; num3 < _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D + 1; num3++)
		{
			double num2 = ((num3 == _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D) ? (Math.PI * 2.0) : (num * (double)num3));
			MNODE item2 = new MNODE(new Point3D
			{
				X = _0023_003DzEGKj_0024SNUUihi * Math.Cos(num2),
				Y = _0023_003DzEGKj_0024SNUUihi * Math.Sin(num2),
				Z = _0023_003DzvAxV_0024Ic_003D
			}, 32768);
			NodeList.Add(item2);
		}
		if (new _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D(NodeList)._0023_003DzKlS_0024RTSkHohzMAAySQ_003D_003D(this, ref _0023_003DzSkUy_T8_003D, 2, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D + 1, 0.0, _0023_003DzkRSfKls1SLfn) == 1)
		{
			Portion portion = portions[0];
			_0023_003DzjcNO1euYZqkh(portion);
			_vertices = new Point3D[portion.vertexCount];
			Array.Copy(portion._vertices, 0, _vertices, 0, portion.vertexCount);
			Portion _0023_003Dzd9ZyL64_003D = null;
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz37UDgYerq6IE(out _0023_003Dzd9ZyL64_003D, _0023_003DzEGKj_0024SNUUihi, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, 0.0, ref _0023_003DzSkUy_T8_003D))
			{
				return 0;
			}
			for (int j = 1; j <= _0023_003Dzd9ZyL64_003D.edgeCount; j++)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[j].PreviousFace = -j;
				_0023_003Dzd9ZyL64_003D.edgeDatas[j].PreviousEdge = -32767;
				_0023_003Dzd9ZyL64_003D.edgeDatas[j].Angle = (float)Math.PI / 2f;
			}
			_0023_003Dzd9ZyL64_003D.faces[1].FaceLabel = 1;
			_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzG037o6MQFwqV(_0023_003Dzd9ZyL64_003D, (_0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: false);
			portions.Add(_0023_003Dzd9ZyL64_003D);
			Portion _0023_003Dzd9ZyL64_003D2 = null;
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz37UDgYerq6IE(out _0023_003Dzd9ZyL64_003D2, _0023_003DzEGKj_0024SNUUihi, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, _0023_003DzvAxV_0024Ic_003D, ref _0023_003DzSkUy_T8_003D))
			{
				return 0;
			}
			for (int k = 1; k <= _0023_003Dzd9ZyL64_003D2.edgeCount; k++)
			{
				_0023_003Dzd9ZyL64_003D2.edgeDatas[k].PreviousFace = -k;
				_0023_003Dzd9ZyL64_003D2.edgeDatas[k].PreviousEdge = -32767;
				_0023_003Dzd9ZyL64_003D2.edgeDatas[k].Angle = 4.712389f;
			}
			_0023_003Dzd9ZyL64_003D2.faces[1].FaceLabel = 1;
			portions.Add(_0023_003Dzd9ZyL64_003D2);
			return 3;
		}
		Portion _0023_003Dzd9ZyL64_003D3 = null;
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz37UDgYerq6IE(out _0023_003Dzd9ZyL64_003D3, _0023_003DzEGKj_0024SNUUihi, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, 0.0, ref _0023_003DzSkUy_T8_003D))
		{
			return 0;
		}
		_0023_003Dzd9ZyL64_003D3.faces[1].FaceLabel = 1;
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(_0023_003Dzd9ZyL64_003D3, this))
		{
			return 0;
		}
		Portion _0023_003Dzd9ZyL64_003D4 = null;
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz37UDgYerq6IE(out _0023_003Dzd9ZyL64_003D4, _0023_003DzEGKj_0024SNUUihi, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, _0023_003DzvAxV_0024Ic_003D, ref _0023_003DzSkUy_T8_003D))
		{
			return 0;
		}
		_0023_003Dzd9ZyL64_003D4.faces[1].FaceLabel = 1;
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(_0023_003Dzd9ZyL64_003D4, this))
		{
			return 0;
		}
		return _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzFipFikVW1CJj(this, (_0023_003Dz1IcEX2Y45sL1)0, 30f, null, _0023_003DzkRSfKls1SLfn);
	}

	private bool _0023_003DzjcNO1euYZqkh(Portion _0023_003Dzd9ZyL64_003D)
	{
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge != 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge != 0)
			{
				continue;
			}
			_0023_003Dzd9ZyL64_003D.edgeDatas[i].Angle = 4.712389f;
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge == 0)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace = -i;
				if (_0023_003Dzd9ZyL64_003D._vertices[_0023_003Dzd9ZyL64_003D.edgeDatas[i].BeginVertex].Z == 0.0)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge = -32766;
				}
				else
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge = -32765;
				}
			}
			else
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace = -i;
				if (_0023_003Dzd9ZyL64_003D._vertices[_0023_003Dzd9ZyL64_003D.edgeDatas[i].BeginVertex].Z == 0.0)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge = -32766;
				}
				else
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge = -32765;
				}
			}
		}
		return true;
	}

	public override void Regen(RegenParams data)
	{
		_0023_003DzcotKewV4gD8LAT2hHQ_003D_003D comparer = new _0023_003DzcotKewV4gD8LAT2hHQ_003D_003D();
		portions.Sort(comparer);
		bool flag = false;
		UpdateBoundingBox(data);
		for (int i = 0; i < portions.Count; i++)
		{
			Portion portion = portions[i];
			int num = 0;
			Mesh.natureType meshNature = portion._meshNature;
			int _0023_003DzhX7K0dc_003D = _0023_003DzQaPlK3qJVEsR8De_cQ_003D_003D(portion);
			flag = false;
			if (portion.TextureCoords != null && portion.TextureCoords.Length != 0 && portion.Triangles != null && portion.Triangles.Length != 0)
			{
				flag = true;
			}
			int num2 = 0;
			List<Vector3D> list = new List<Vector3D>();
			List<IndexTriangle> list2 = new List<IndexTriangle>();
			for (int j = 1; j <= portion.faceCount; j++)
			{
				_0023_003DzYm_0024NZRCNgy0n(i, j, _0023_003DzhX7K0dc_003D, out var _0023_003Dzcv8o5nO25OjS, out var _0023_003DzztJY0_0024dXEFMk, _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(localMin, localMax));
				if (_0023_003Dzcv8o5nO25OjS.Count == 1 && _0023_003Dzcv8o5nO25OjS[0].Length == 4)
				{
					list.AddRange(_0023_003DzztJY0_0024dXEFMk[0]);
					int[] array = _0023_003Dzcv8o5nO25OjS[0];
					if (!flag)
					{
						list2.Add(Utility.CreateTriangle(meshNature, array[0], array[1], array[2], num2, num2 + 1, num2 + 2));
					}
					else
					{
						if (num >= portion.Triangles.Length)
						{
							num = portion.Triangles.Length - 1;
						}
						list2.Add(new RichSmoothTriangle(array[0], array[1], array[2], num2, num2 + 1, num2 + 2, ((RichSmoothTriangle)portion.Triangles[num]).T1, ((RichSmoothTriangle)portion.Triangles[num]).T2, ((RichSmoothTriangle)portion.Triangles[num]).T3));
					}
					num2 += _0023_003DzztJY0_0024dXEFMk[0].Length;
					num++;
					continue;
				}
				if (_0023_003Dzcv8o5nO25OjS.Count == 1 && _0023_003Dzcv8o5nO25OjS[0].Length == 5)
				{
					list.AddRange(_0023_003DzztJY0_0024dXEFMk[0]);
					int[] array2 = _0023_003Dzcv8o5nO25OjS[0];
					Point3D[] vertices = portion.Vertices;
					Point3D[] array3 = new Point3D[4]
					{
						vertices[array2[0]],
						vertices[array2[1]],
						vertices[array2[2]],
						vertices[array2[3]]
					};
					Vector3D vector3D = Vector3D.Cross(Vector3D.Subtract(array3[1], array3[0]), Vector3D.Subtract(array3[2], array3[0]));
					Vector3D vector3D2 = Vector3D.Cross(Vector3D.Subtract(array3[2], array3[0]), Vector3D.Subtract(array3[3], array3[0]));
					double num3 = Vector3D.Dot(vector3D, vector3D2);
					bool flag2 = false;
					if (Math.Abs(num3) < Utility._0023_003DzxhnLabVjXjPg)
					{
						num3 = 0.0;
						if (vector3D.LengthSquared < vector3D2.LengthSquared)
						{
							flag2 = true;
						}
					}
					if (flag2 || num3 < 0.0)
					{
						if (!flag)
						{
							list2.Add(Utility.CreateTriangle(meshNature, array2[0], array2[1], array2[3], num2, num2 + 1, num2 + 2));
							list2.Add(Utility.CreateTriangle(meshNature, array2[1], array2[2], array2[3], num2, num2 + 2, num2 + 3));
						}
						else
						{
							if (num >= portion.Triangles.Length)
							{
								num = portion.Triangles.Length - 2;
							}
							list2.Add(new RichSmoothTriangle(array2[0], array2[1], array2[3], num2, num2 + 1, num2 + 2, ((RichSmoothTriangle)portion.Triangles[num]).T1, ((RichSmoothTriangle)portion.Triangles[num]).T2, ((RichSmoothTriangle)portion.Triangles[num]).T3));
							list2.Add(new RichSmoothTriangle(array2[1], array2[2], array2[3], num2, num2 + 2, num2 + 3, ((RichSmoothTriangle)portion.Triangles[num + 1]).T1, ((RichSmoothTriangle)portion.Triangles[num + 1]).T2, ((RichSmoothTriangle)portion.Triangles[num + 1]).T3));
						}
					}
					else if (!flag)
					{
						list2.Add(Utility.CreateTriangle(meshNature, array2[0], array2[1], array2[2], num2, num2 + 1, num2 + 2));
						list2.Add(Utility.CreateTriangle(meshNature, array2[0], array2[2], array2[3], num2, num2 + 2, num2 + 3));
					}
					else
					{
						if (num >= portion.Triangles.Length)
						{
							num = portion.Triangles.Length - 2;
						}
						list2.Add(new RichSmoothTriangle(array2[0], array2[1], array2[2], num2, num2 + 1, num2 + 2, ((RichSmoothTriangle)portion.Triangles[num]).T1, ((RichSmoothTriangle)portion.Triangles[num]).T2, ((RichSmoothTriangle)portion.Triangles[num]).T3));
						list2.Add(new RichSmoothTriangle(array2[0], array2[2], array2[3], num2, num2 + 2, num2 + 3, ((RichSmoothTriangle)portion.Triangles[num + 1]).T1, ((RichSmoothTriangle)portion.Triangles[num + 1]).T2, ((RichSmoothTriangle)portion.Triangles[num + 1]).T3));
					}
					num2 += _0023_003DzztJY0_0024dXEFMk[0].Length;
					num += 2;
					continue;
				}
				PlaneEquation planeEquation = portion.planes[j];
				Plane pln = new Plane(new double[4] { planeEquation.X, planeEquation.Y, planeEquation.Z, planeEquation.D });
				int[][] array4 = _0023_003Dzcv8o5nO25OjS.ToArray();
				try
				{
					IndexTriangle[] array5 = Utility.MakeFace(pln, array4, portion._vertices, checkForOuter: true);
					foreach (Vector3D[] item in _0023_003DzztJY0_0024dXEFMk)
					{
						list.AddRange(item);
					}
					IndexTriangle[] array6 = Mesh._0023_003DzeVELJPX06XqphX1Zqg_003D_003D(meshNature, array5.Length);
					for (int k = 0; k < array5.Length; k++)
					{
						IndexTriangle indexTriangle = array5[k];
						int num4 = 0;
						int n = 0;
						int n2 = 0;
						int n3 = 0;
						for (int l = 0; l < array4.Length; l++)
						{
							for (int m = 0; m < array4[l].Length; m++)
							{
								int num5 = array4[l][m];
								if (num5 == indexTriangle.V1)
								{
									n = num2 + num4 + m;
								}
								else if (num5 == indexTriangle.V2)
								{
									n2 = num2 + num4 + m;
								}
								else if (num5 == indexTriangle.V3)
								{
									n3 = num2 + num4 + m;
								}
							}
							num4 += array4[l].Length;
						}
						if (!flag)
						{
							array6[k] = Utility.CreateTriangle(meshNature, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, n, n2, n3);
						}
						else
						{
							if (num >= portion.Triangles.Length)
							{
								num = portion.Triangles.Length - 1;
							}
							array6[k] = new RichSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, n, n2, n3, ((RichSmoothTriangle)portion.Triangles[num]).T1, ((RichSmoothTriangle)portion.Triangles[num]).T2, ((RichSmoothTriangle)portion.Triangles[num]).T3);
						}
						num++;
					}
					list2.AddRange(array6);
					foreach (Vector3D[] item2 in _0023_003DzztJY0_0024dXEFMk)
					{
						num2 += item2.Length;
					}
				}
				catch (Exception)
				{
				}
			}
			portion._triangles = list2.ToArray();
			portion.Normals = list.ToArray();
			List<IndexLine> list3 = new List<IndexLine>();
			portion.isoCurves = new List<IndexLine>();
			for (int num6 = 1; num6 <= portion.edgeCount; num6++)
			{
				EdgeData edgeData = portion.edgeDatas[num6];
				if ((edgeData.Type & 1) != 0)
				{
					list3.Add(new IndexLine(edgeData.BeginVertex, edgeData.EndVertex));
				}
				else if ((edgeData.Type & 4) != 0)
				{
					portion.isoCurves.Add(new IndexLine(edgeData.BeginVertex, edgeData.EndVertex));
				}
			}
			((Mesh)portion).Edges = list3.ToArray();
			portion.regenMode = regenType.CompileOnly;
		}
		meshForFaceSelection = null;
		if (Faces != null)
		{
			Faces.ClearIfNotSelected(FacesSelectionInfo);
		}
		RegenMode = regenType.CompileOnly;
	}

	private void _0023_003DzHxjXLTZ3QouXQOSSLQ_003D_003D(SmoothTriangle _0023_003DzEzv5_0024vo_003D, ref int[] _0023_003DzCRq4LBU_003D, int _0023_003DzfBEBL_o_003D, int _0023_003DzmEpdBKQTjk3e4Um0jw_003D_003D)
	{
		int num = 0;
		for (int i = 0; i < _0023_003DzCRq4LBU_003D.Length; i++)
		{
			int num2 = _0023_003DzCRq4LBU_003D[i];
			if (num2 == _0023_003DzEzv5_0024vo_003D.V1)
			{
				_0023_003DzEzv5_0024vo_003D.N1 = _0023_003DzmEpdBKQTjk3e4Um0jw_003D_003D + _0023_003DzfBEBL_o_003D + i;
				num++;
			}
			else if (num2 == _0023_003DzEzv5_0024vo_003D.V2)
			{
				_0023_003DzEzv5_0024vo_003D.N2 = _0023_003DzmEpdBKQTjk3e4Um0jw_003D_003D + _0023_003DzfBEBL_o_003D + i;
				num++;
			}
			else if (num2 == _0023_003DzEzv5_0024vo_003D.V3)
			{
				_0023_003DzEzv5_0024vo_003D.N3 = _0023_003DzmEpdBKQTjk3e4Um0jw_003D_003D + _0023_003DzfBEBL_o_003D + i;
				num++;
			}
			if (num == 3)
			{
				break;
			}
		}
	}

	private int _0023_003Dz3pAp4uv1gfPY(Portion _0023_003Dz5Tpjxj5wp_0024R8)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 1; i <= _0023_003Dz5Tpjxj5wp_0024R8.edgeCount; i++)
		{
			if ((_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[Math.Abs(i)].Type & 1) > 0)
			{
				num2++;
			}
		}
		if (num2 == 0)
		{
			return 0;
		}
		if (num2 == _0023_003Dz5Tpjxj5wp_0024R8.edgeCount)
		{
			return 2;
		}
		return 1;
	}

	internal static Solid _0023_003DzFPVyG4Y9TGyH(IList<Point3D> _0023_003Dz_SqBXz8_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn)
	{
		return _0023_003DzFPVyG4Y9TGyH<Solid>(_0023_003Dz_SqBXz8_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzFPVyG4Y9TGyH<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		return _0023_003DzFPVyG4Y9TGyH<T>(_0023_003Dz_SqBXz8_003D, null, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static Solid _0023_003DzFPVyG4Y9TGyH(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn)
	{
		return _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<Solid>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzFPVyG4Y9TGyH<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		return _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static Solid _0023_003DzFPVyG4Y9TGyH(ICurve _0023_003Dz_SqBXz8_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn)
	{
		return _0023_003DzFPVyG4Y9TGyH<Solid>(_0023_003Dz_SqBXz8_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzFPVyG4Y9TGyH<T>(ICurve _0023_003Dz_SqBXz8_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		return _0023_003DzFPVyG4Y9TGyH<T>(_0023_003Dz_SqBXz8_003D, null, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static Solid _0023_003DzFPVyG4Y9TGyH(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn)
	{
		return _0023_003DzFPVyG4Y9TGyH<Solid>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzFPVyG4Y9TGyH<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		return _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzFPVyG4Y9TGyH<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, RegenParams _0023_003DzELu0Pss_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		Utility._0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzELu0Pss_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		return _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(Region _0023_003Dz7revxoQ_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Vector3D _0023_003DzYNjcavt9guh2) where T : Solid, new()
	{
		_0023_003Dz7revxoQ_003D._0023_003DzWFzsryZTA1I_JcqmPg_mY3Wl4l5L(out var _0023_003Dz_SqBXz8_003D, out var _0023_003DzWaFlkhfmYCja);
		T val = _0023_003DzFPVyG4Y9TGyH<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn: true);
		val.CopyAttributes(_0023_003Dz7revxoQ_003D);
		return val;
	}

	internal static T _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(Region _0023_003Dz7revxoQ_003D, RegenParams _0023_003DzELu0Pss_003D, Vector3D _0023_003DzYNjcavt9guh2) where T : Solid, new()
	{
		_0023_003Dz7revxoQ_003D._0023_003DzWFzsryZTA1I_JcqmPg_mY3Wl4l5L(out var _0023_003Dz_SqBXz8_003D, out var _0023_003DzWaFlkhfmYCja);
		T val = _0023_003DzFPVyG4Y9TGyH<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzELu0Pss_003D, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn: true);
		val.CopyAttributes(_0023_003Dz7revxoQ_003D);
		return val;
	}

	private static T _0023_003DzfMf8mEeGF_Z4ri7PeA_003D_003D<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		if (_0023_003Dz_SqBXz8_003D.Count == 2 && (_0023_003DzWaFlkhfmYCja == null || _0023_003DzWaFlkhfmYCja.Count == 0))
		{
			return new Line(_0023_003Dz_SqBXz8_003D[0].X, _0023_003Dz_SqBXz8_003D[0].Y, _0023_003Dz_SqBXz8_003D[0].Z, _0023_003Dz_SqBXz8_003D[1].X, _0023_003Dz_SqBXz8_003D[1].Y, _0023_003Dz_SqBXz8_003D[1].Z).ExtrudeAsMesh(_0023_003DzYNjcavt9guh2, 0.0, Mesh.natureType.Smooth).ConvertToSolid<T>();
		}
		Utility.ComputeBoundingBox(_0023_003Dz_SqBXz8_003D, out var boxMin, out var boxMax);
		double num = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (!new LinearPath(_0023_003Dz_SqBXz8_003D).IsPlanar(num, out var _))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977879));
		}
		if (!_0023_003Dz5q1w0P79Gecn)
		{
			if (_0023_003Dz_SqBXz8_003D.Count > 2)
			{
				Solid solid = _0023_003DzranJPDlPiZC7<Solid>(_0023_003Dz_SqBXz8_003D, null);
				solid.Regen(num);
				if (Utility._0023_003DzORMVE0Xmd0DtzbF76UFKV_0024E_00240xze8ka1xgCJQIc_003D(solid.GetTessellation()[0]._triangles, solid.GetTessellation()[0]._vertices, _0023_003DzYNjcavt9guh2))
				{
					_0023_003Dzo8EWaQGUdDTi<T>(ref _0023_003Dz_SqBXz8_003D, ref _0023_003DzWaFlkhfmYCja);
				}
			}
		}
		else if (!Utility.IsClosedProfile(_0023_003Dz_SqBXz8_003D))
		{
			throw new EyeshotException(Mesh._0023_003DzCRupKJbhwyN62YPt8Q_003D_003D);
		}
		return _0023_003DzaD5_0024bui7AmQbPta7uA_003D_003D._0023_003DzFPVyG4Y9TGyH<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn, Math.PI / 6.0, num);
	}

	public bool ExtrudeAdd(Region region, double amount, double tolerance)
	{
		Solid[] leftOvers;
		return ExtrudeAdd(region, amount, tolerance, out leftOvers);
	}

	public bool ExtrudeAdd(Region region, Interval amount, double tolerance)
	{
		Solid[] leftOvers;
		return ExtrudeAdd(region, amount.Max - amount.Min, tolerance, out leftOvers);
	}

	public bool ExtrudeAdd(Region region, double amount, double tolerance, out Solid[] leftOvers)
	{
		return ExtrudeAdd(region, amount * region.Plane.AxisZ, tolerance, out leftOvers);
	}

	public bool ExtrudeAdd(Region region, Vector3D amount, double tolerance, out Solid[] leftOvers)
	{
		Solid b = region.ExtrudeAsSolid(amount, tolerance);
		Solid[] array = Union(this, b);
		if (array != null && array.Length != 0)
		{
			_0023_003Dz_00246_6laMMoobS(array[0], _0023_003Dzu9oxwJ_zKlMt: false);
			leftOvers = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			UpdateBoundingBox(null);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		leftOvers = null;
		return false;
	}

	public bool ExtrudeAdd(Region region, Vector3D amount, double tolerance)
	{
		Solid[] leftOvers;
		return ExtrudeAdd(region, amount, tolerance, out leftOvers);
	}

	public bool ExtrudeAdd(Region region, double x, double y, double z, double tolerance)
	{
		Solid[] leftOvers;
		return ExtrudeAdd(region, x, y, z, tolerance, out leftOvers);
	}

	public bool ExtrudeAdd(Region region, double x, double y, double z, double tolerance, out Solid[] leftOvers)
	{
		return ExtrudeAdd(region, new Vector3D(x, y, z), tolerance, out leftOvers);
	}

	public bool ExtrudeRemove(Region region, double amount, double tolerance, out Solid[] leftOvers)
	{
		return ExtrudeRemove(region, amount * region.Plane.AxisZ, tolerance, out leftOvers);
	}

	public bool ExtrudeRemove(Region region, double amount, double tolerance)
	{
		Solid[] leftOvers;
		return ExtrudeRemove(region, amount, tolerance, out leftOvers);
	}

	public bool ExtrudeRemove(Region region, Interval amount, double tolerance)
	{
		Solid[] leftOvers;
		return ExtrudeRemove(region, amount.Max - amount.Min, tolerance, out leftOvers);
	}

	public bool ExtrudeRemove(Region region, double amount, double tolerance, out Solid[] leftOvers, bool keepOriginalColors = false)
	{
		return ExtrudeRemove(region, amount * region.Plane.AxisZ, tolerance, out leftOvers, keepOriginalColors);
	}

	public bool ExtrudeRemove(Region region, Vector3D amount, double tolerance, bool keepOriginalColors = false)
	{
		Solid[] leftOvers;
		return ExtrudeRemove(region, amount, tolerance, out leftOvers, keepOriginalColors);
	}

	public bool ExtrudeRemove(Region region, double x, double y, double z, double tolerance, out Solid[] leftOvers, bool keepOriginalColors = false)
	{
		return ExtrudeRemove(region, new Vector3D(x, y, z), tolerance, out leftOvers, keepOriginalColors);
	}

	public bool ExtrudeRemove(Region region, double x, double y, double z, double tolerance, bool keepOriginalColors = false)
	{
		Solid[] leftOvers;
		return ExtrudeRemove(region, x, y, z, tolerance, out leftOvers, keepOriginalColors);
	}

	public bool ExtrudeRemove(Region region, Vector3D amount, double tolerance, out Solid[] leftOvers, bool keepOriginalColors = false)
	{
		Solid b = region.ExtrudeAsSolid(amount, tolerance);
		Solid[] array = Difference(this, b, keepOriginalColors);
		if (array != null && array.Length != 0)
		{
			_0023_003Dz_00246_6laMMoobS(array[0], _0023_003Dzu9oxwJ_zKlMt: false);
			leftOvers = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			UpdateBoundingBox(null);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		leftOvers = null;
		return false;
	}

	private void _0023_003DzTB8QJamRWmyth73nkw_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, out double _0023_003Dzkvk88KaXCcAi, out double _0023_003Dzj_0024c4yo8Y8jLt)
	{
		Point3D boxMin;
		Point3D boxMax;
		if (localMin != Point3D.MaxValue && localMin != Point3D.MinValue && localMax != Point3D.MaxValue && localMax != Point3D.MinValue && localMin != null && localMax != null && RegenMode == regenType.NotNeeded)
		{
			boxMin = base.BoxMin;
			boxMax = base.BoxMax;
		}
		else
		{
			ComputeBoundingBox(new TraversalParams(), out boxMin, out boxMax);
		}
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(boxMin, boxMax);
		_0023_003Dzkvk88KaXCcAi = double.MaxValue;
		_0023_003Dzj_0024c4yo8Y8jLt = double.MinValue;
		Point3D[] array = boundingBoxCorners;
		foreach (Point3D point in array)
		{
			double num = _0023_003Dzrgqz890sj_0024X9.DistanceTo(point);
			if (num > _0023_003Dzj_0024c4yo8Y8jLt)
			{
				_0023_003Dzj_0024c4yo8Y8jLt = num;
			}
			if (num < _0023_003Dzkvk88KaXCcAi)
			{
				_0023_003Dzkvk88KaXCcAi = num;
			}
		}
	}

	private Interval _0023_003Dz3EXuhAJaDV8Rbd21EGCzNGM_003D(Region _0023_003DzFDwqpgU_003D)
	{
		_0023_003DzTB8QJamRWmyth73nkw_003D_003D(_0023_003DzFDwqpgU_003D.Plane, out var _0023_003Dzkvk88KaXCcAi, out var _0023_003Dzj_0024c4yo8Y8jLt);
		double num = Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D * (_0023_003Dzj_0024c4yo8Y8jLt - _0023_003Dzkvk88KaXCcAi);
		return new Interval(_0023_003Dzkvk88KaXCcAi - num, _0023_003Dzj_0024c4yo8Y8jLt + num);
	}

	public bool ExtrudeRemoveThrough(Region reg, double tolerance)
	{
		Interval interval = _0023_003Dz3EXuhAJaDV8Rbd21EGCzNGM_003D(reg);
		Region region = (Region)reg.Clone();
		region.TransformBy(new Translation(region.Plane.AxisZ * interval.Min));
		return ExtrudeRemove(region, interval.Max - interval.Min, tolerance);
	}

	internal bool _0023_003DzgtO6nuZYTlV0BbsgPB9Yvy0_003D(Region _0023_003DzFDwqpgU_003D, Interval _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		Region region = (Region)_0023_003DzFDwqpgU_003D.Clone();
		region.TransformBy(new Translation(region.Plane.AxisZ * _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D.Min));
		return ExtrudeRemove(region, _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D.Max - _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D.Min, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
	}

	public bool ExtrudeRemoveThrough(Sketch sketch, double tolerance)
	{
		Region reg = sketch.ConvertToRegions()[0];
		return ExtrudeRemoveThrough(reg, tolerance);
	}

	public bool ExtrudeRemoveThrough(SketchEntity sketchEnt, double tolerance)
	{
		Region reg = sketchEnt.ConvertToRegions()[0];
		return ExtrudeRemoveThrough(reg, tolerance);
	}

	public bool ExtrudeRemoveThroughPattern(Region region, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY, double tolerance)
	{
		Region[] array = _0023_003DzgmGD9qiE7y_zhCN1JWRFrC3qQeny(region, patternPln, spacingX, numberX, spacingY, numberY);
		Interval _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D = _0023_003Dz3EXuhAJaDV8Rbd21EGCzNGM_003D(region);
		bool flag = true;
		for (int i = 0; i < array.Length && flag; i++)
		{
			flag &= _0023_003DzgtO6nuZYTlV0BbsgPB9Yvy0_003D(array[i], _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D, tolerance);
		}
		return flag;
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY, double tolerance)
	{
		Region region = sketch.ConvertToRegions()[0];
		return ExtrudeRemoveThroughPattern(region, patternPln, spacingX, numberX, spacingY, numberY, tolerance);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketchEnt, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY, double tolerance)
	{
		Region region = sketchEnt.ConvertToRegions()[0];
		return ExtrudeRemoveThroughPattern(region, patternPln, spacingX, numberX, spacingY, numberY, tolerance);
	}

	public bool ExtrudeRemoveThroughPattern(Region region, Vector3D axis, Point3D center, double angleInRadians, int number, double tolerance)
	{
		Region[] array = _0023_003DzUSZdG7OcZV_fwbFbhA_003D_003D(region, axis, center, angleInRadians, number, tolerance);
		Interval _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D = _0023_003Dz3EXuhAJaDV8Rbd21EGCzNGM_003D(region);
		bool flag = true;
		for (int i = 0; i < array.Length && flag; i++)
		{
			flag &= _0023_003DzgtO6nuZYTlV0BbsgPB9Yvy0_003D(array[i], _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D, tolerance);
		}
		return flag;
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, Vector3D axis, Point3D center, double angleInRadians, int number, double tolerance)
	{
		Region region = sketch.ConvertToRegions()[0];
		return ExtrudeRemoveThroughPattern(region, axis, center, angleInRadians, number, tolerance);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketchEnt, Vector3D axis, Point3D center, double angleInRadians, int number, double tolerance)
	{
		Region region = sketchEnt.ConvertToRegions()[0];
		return ExtrudeRemoveThroughPattern(region, axis, center, angleInRadians, number, tolerance);
	}

	internal Region[] _0023_003DzUSZdG7OcZV_fwbFbhA_003D_003D(Region _0023_003Dz7revxoQ_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003Dz96zZozU1V2X4, double _0023_003DznPBtD_0024qc7LrUv9BA9Ct5vlA_003D, int _0023_003DzgefeDRfyiwPd2pfJ8w_003D_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		Region[] array = new Region[_0023_003DzgefeDRfyiwPd2pfJ8w_003D_003D];
		array[0] = (Region)_0023_003Dz7revxoQ_003D.Clone();
		int num = 0;
		for (int i = 1; i < _0023_003DzgefeDRfyiwPd2pfJ8w_003D_003D; i++)
		{
			num++;
			Region region = (Region)_0023_003Dz7revxoQ_003D.Clone();
			region.Rotate(_0023_003DznPBtD_0024qc7LrUv9BA9Ct5vlA_003D * (double)i, _0023_003DzxuJqjrs_003D, _0023_003Dz96zZozU1V2X4);
			array[num] = region;
		}
		return array;
	}

	internal Region[] _0023_003DzgmGD9qiE7y_zhCN1JWRFrC3qQeny(Region _0023_003Dz7revxoQ_003D, Plane _0023_003DzloJJEdKMR47X, double _0023_003DzlBA2KcQ_003D, int _0023_003DzM2i6yTg_003D, double _0023_003DzmszIVng_003D, int _0023_003Dzz6Xw76k_003D)
	{
		Region[] array = new Region[_0023_003DzM2i6yTg_003D * _0023_003Dzz6Xw76k_003D];
		array[0] = (Region)_0023_003Dz7revxoQ_003D.Clone();
		Vector3D axisX = _0023_003DzloJJEdKMR47X.AxisX;
		Vector3D axisY = _0023_003DzloJJEdKMR47X.AxisY;
		int num = 0;
		for (int i = 0; i < _0023_003DzM2i6yTg_003D; i++)
		{
			for (int j = 0; j < _0023_003Dzz6Xw76k_003D; j++)
			{
				if (i != 0 || j != 0)
				{
					num++;
					Region region = (Region)_0023_003Dz7revxoQ_003D.Clone();
					region.Translate(_0023_003DzlBA2KcQ_003D * (double)i * axisX);
					region.Translate(_0023_003DzmszIVng_003D * (double)j * axisY);
					array[num] = region;
				}
			}
		}
		return array;
	}

	private Solid[] _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(Solid[] _0023_003Dz_0024BYl5czoug3X)
	{
		if (_0023_003Dz_0024BYl5czoug3X != null && _0023_003Dz_0024BYl5czoug3X.Length > 1)
		{
			List<Solid> list = new List<Solid>(_0023_003Dz_0024BYl5czoug3X.Length - 1);
			for (int i = 1; i < _0023_003Dz_0024BYl5czoug3X.Length; i++)
			{
				list.Add(_0023_003Dz_0024BYl5czoug3X[i]);
			}
			return list.ToArray();
		}
		return null;
	}

	public bool ExtrudeRemove(Region region, double x, double y, double z, double tolerance, out Solid[] leftOvers)
	{
		return ExtrudeRemove(region, new Vector3D(x, y, z), tolerance, out leftOvers);
	}

	public bool ExtrudeRemove(Region region, double x, double y, double z, double tolerance)
	{
		Solid[] leftOvers;
		return ExtrudeRemove(region, x, y, z, tolerance, out leftOvers);
	}

	internal bool _0023_003DzcX4pmfTQmEh2nNCz3A_003D_003D(IList<Point3D> _0023_003Dz_SqBXz8_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn, bool _0023_003DzfjRqwoISk3lB, out Solid[] _0023_003DzACJ8of7_00247mab)
	{
		return _0023_003DzcX4pmfTQmEh2nNCz3A_003D_003D(_0023_003Dz_SqBXz8_003D, null, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn, _0023_003DzfjRqwoISk3lB, out _0023_003DzACJ8of7_00247mab);
	}

	internal bool _0023_003DzcX4pmfTQmEh2nNCz3A_003D_003D(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dz5q1w0P79Gecn, bool _0023_003DzfjRqwoISk3lB, out Solid[] _0023_003DzACJ8of7_00247mab)
	{
		Solid b = _0023_003DzFPVyG4Y9TGyH(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003Dz5q1w0P79Gecn);
		Solid[] array = Difference(this, b, _0023_003DzfjRqwoISk3lB);
		if (array != null && array.Length != 0)
		{
			_0023_003Dz_00246_6laMMoobS(array[0], _0023_003Dzu9oxwJ_zKlMt: false);
			_0023_003DzACJ8of7_00247mab = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			return true;
		}
		_0023_003DzACJ8of7_00247mab = null;
		return false;
	}

	internal static Solid _0023_003DzZsKpvYbXHCDE(IList<Point3D> _0023_003Dz_SqBXz8_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn)
	{
		return _0023_003DzZsKpvYbXHCDE<Solid>(_0023_003Dz_SqBXz8_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		return _0023_003DzZsKpvYbXHCDE<T>(_0023_003Dz_SqBXz8_003D, null, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		bool _0023_003DzJlv_CuAUfJRQ = Utility._0023_003DzSOQm2JeuhlBjZ46sDLoENc_0024rSbvZ(_0023_003Dz_SqBXz8_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003Dz5q1w0P79Gecn);
		return _0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzJlv_CuAUfJRQ);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn) where T : Solid, new()
	{
		Utility._0023_003Dz0U2l9p_0024wMUWMI2xPGxvwVTCSGwVr(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, out var _0023_003DzJlv_CuAUfJRQ, _0023_003Dz5q1w0P79Gecn);
		return _0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<T>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzJlv_CuAUfJRQ);
	}

	internal static T _0023_003DzZsKpvYbXHCDE<T>(Region _0023_003Dz7revxoQ_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q) where T : Solid, new()
	{
		_0023_003Dz7revxoQ_003D._0023_003DzWFzsryZTA1I_JcqmPg_mY3Wl4l5L(out var _0023_003Dz_SqBXz8_003D, out var _0023_003DzWaFlkhfmYCja);
		ICurve[] individualCurves = _0023_003Dz_SqBXz8_003D.GetIndividualCurves();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			if (individualCurves[i] is Line)
			{
				Line line = (Line)individualCurves[i];
				if (new Segment3D(line.StartPoint, line.EndPoint).IsOnAxis(_0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D))
				{
					T val = Mesh._0023_003DzZsKpvYbXHCDE(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn: true, Mesh.natureType.Smooth).ConvertToSolid<T>();
					val.CopyAttributes(_0023_003Dz7revxoQ_003D);
					return val;
				}
			}
		}
		T val2 = _0023_003DzZsKpvYbXHCDE<T>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn: true);
		val2.CopyAttributes(_0023_003Dz7revxoQ_003D);
		return val2;
	}

	private static T _0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<T>(IList<Point3D> _0023_003Dz_SqBXz8_003D, IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, bool _0023_003Dz5q1w0P79Gecn, bool _0023_003DzJlv_CuAUfJRQ) where T : Solid, new()
	{
		Utility.ComputeBoundingBox(_0023_003Dz_SqBXz8_003D, out var boxMin, out var boxMax);
		double tol = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (!new LinearPath(_0023_003Dz_SqBXz8_003D).IsPlanar(tol, out var _))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977879));
		}
		if (!_0023_003Dz5q1w0P79Gecn && _0023_003DzWaFlkhfmYCja != null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977850));
		}
		Mesh mesh = Mesh._0023_003Dz_zLhQ7UUHrThF4tt5A_003D_003D<Mesh>(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAPBIJmvn5i5Q, _0023_003Dz5q1w0P79Gecn, _0023_003DzJlv_CuAUfJRQ: true, _0023_003Dz5q1w0P79Gecn, Mesh.natureType.Plain);
		return FromTriangles<T>(mesh._vertices, mesh._triangles);
	}

	private static void _0023_003Dzo8EWaQGUdDTi<T>(ref IList<Point3D> _0023_003Dz_SqBXz8_003D, ref IList<IList<Point3D>> _0023_003DzWaFlkhfmYCja) where T : Solid, new()
	{
		List<Point3D> list = new List<Point3D>(_0023_003Dz_SqBXz8_003D);
		list.Reverse();
		_0023_003Dz_SqBXz8_003D = list;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			List<IList<Point3D>> list2 = new List<IList<Point3D>>(_0023_003DzWaFlkhfmYCja.Count);
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				list = new List<Point3D>(_0023_003DzWaFlkhfmYCja[i]);
				list.Reverse();
				list2.Add(list);
			}
			_0023_003DzWaFlkhfmYCja = list2;
		}
	}

	public bool RevolveAdd(Region region, double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		Solid[] leftOvers;
		return RevolveAdd(region, startAngle, deltaAngle, axisStart, axisEnd, slices, tolerance, out leftOvers);
	}

	public bool RevolveAdd(Region region, Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		Solid[] leftOvers;
		return RevolveAdd(region, intervalAngle, axisStart, axisEnd, slices, tolerance, out leftOvers);
	}

	public bool RevolveAdd(Region region, double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, out Solid[] leftOvers)
	{
		return RevolveAdd(region, startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, out leftOvers);
	}

	public bool RevolveAdd(Region region, Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, out Solid[] leftOvers)
	{
		return RevolveAdd(region, intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, out leftOvers);
	}

	public bool RevolveAdd(Region region, double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		Solid[] leftOvers;
		return RevolveAdd(region, startAngle, deltaAngle, axis, center, slices, tolerance, out leftOvers);
	}

	public bool RevolveAdd(Region region, Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		Solid[] leftOvers;
		return RevolveAdd(region, intervalAngle, axis, center, slices, tolerance, out leftOvers);
	}

	public bool RevolveAdd(Region region, double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, out Solid[] leftOvers)
	{
		Solid b = region.RevolveAsSolid(startAngle, deltaAngle, axis, center, slices, tolerance);
		Solid[] array = Union(this, b);
		if (array != null && array.Length != 0)
		{
			_0023_003Dz_00246_6laMMoobS(array[0], _0023_003Dzu9oxwJ_zKlMt: false);
			leftOvers = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			return true;
		}
		leftOvers = null;
		return false;
	}

	public bool RevolveAdd(Region region, Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance, out Solid[] leftOvers)
	{
		Solid b = region.RevolveAsSolid(intervalAngle, axis, center, slices, tolerance);
		Solid[] array = Union(this, b);
		if (array != null && array.Length != 0)
		{
			_0023_003Dz_00246_6laMMoobS(array[0], _0023_003Dzu9oxwJ_zKlMt: false);
			leftOvers = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			return true;
		}
		leftOvers = null;
		return false;
	}

	public bool RevolveRemove(Region region, Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		Solid[] leftOvers;
		return RevolveRemove(region, intervalAngle, axisStart, axisEnd, slices, tolerance, out leftOvers);
	}

	public bool RevolveRemove(Region region, double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		Solid[] leftOvers;
		return RevolveRemove(region, startAngle, deltaAngle, axisStart, axisEnd, slices, tolerance, out leftOvers);
	}

	public bool RevolveRemove(Region region, double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, out Solid[] leftOvers)
	{
		return RevolveRemove(region, startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, out leftOvers);
	}

	public bool RevolveRemove(Region region, Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, out Solid[] leftOvers)
	{
		return RevolveRemove(region, intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, out leftOvers);
	}

	public bool RevolveRemove(Region region, double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		Solid[] leftOvers;
		return RevolveRemove(region, startAngle, deltaAngle, axis, center, slices, tolerance, out leftOvers);
	}

	public bool RevolveRemove(Region region, double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, out Solid[] leftOvers)
	{
		Solid b = region.RevolveAsSolid(startAngle, deltaAngle, axis, center, slices, tolerance);
		Solid[] array = Difference(this, b);
		if (array != null && array.Length != 0)
		{
			_0023_003Dz_00246_6laMMoobS(array[0], _0023_003Dzu9oxwJ_zKlMt: false);
			leftOvers = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			return true;
		}
		leftOvers = null;
		return false;
	}

	public bool RevolveRemove(Region region, Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance, out Solid[] leftOvers)
	{
		Solid b = region.RevolveAsSolid(intervalAngle, axis, center, slices, tolerance);
		Solid[] array = Difference(this, b);
		if (array != null && array.Length != 0)
		{
			_0023_003Dz_00246_6laMMoobS(array[0], _0023_003Dzu9oxwJ_zKlMt: false);
			leftOvers = _0023_003DzgGW8P_zSvXlNsz6tLQ_003D_003D(array);
			return true;
		}
		leftOvers = null;
		return false;
	}

	public static Solid CreateSphere(double radius, int slices, int stacks)
	{
		return CreateSphere<Solid>(radius, slices, stacks);
	}

	public static T CreateSphere<T>(double radius, int slices, int stacks) where T : Solid, new()
	{
		if (radius < Utility._0023_003DzheSR8QM7q9ya || stacks < 2 || slices < 2)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974298));
		}
		T val = new T();
		Point3D _0023_003DzF7v9r2A_003D = new Point3D(0.0 - radius, 0.0 - radius, 0.0 - radius);
		Point3D _0023_003Dz8dK2uhU_003D = new Point3D(radius, radius, radius);
		double _0023_003DzkRSfKls1SLfn = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		val.NodeList = new List<MNODE>();
		if (val._0023_003DzZ9vctZDA5P7qIc3D8g_003D_003D(radius, slices, stacks, _0023_003DzkRSfKls1SLfn) == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302978043));
		}
		val.UpdateBoundingBox(null);
		return val;
	}

	private int _0023_003DzZ9vctZDA5P7qIc3D8g_003D_003D(double _0023_003DzEGKj_0024SNUUihi, int _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D, int _0023_003Dzcnlc0W9082xJ, double _0023_003DzkRSfKls1SLfn)
	{
		_0023_003Dzcnlc0W9082xJ += 2;
		double num = Math.PI * 2.0 / (double)_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D;
		double num2 = Math.PI / (double)(_0023_003Dzcnlc0W9082xJ - 1);
		double[] array = new double[_0023_003Dzcnlc0W9082xJ];
		double[] array2 = new double[_0023_003Dzcnlc0W9082xJ];
		double num3 = 0.0;
		for (int i = 0; i < _0023_003Dzcnlc0W9082xJ - 1; i++)
		{
			array[i] = Math.Sin(num3);
			array2[i] = Math.Cos(num3);
			num3 += num2;
		}
		array[_0023_003Dzcnlc0W9082xJ - 1] = 0.0;
		array2[_0023_003Dzcnlc0W9082xJ - 1] = -1.0;
		double[] array3 = new double[_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D + 1];
		double[] array4 = new double[_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D + 1];
		array3[0] = 0.0;
		array4[0] = 1.0;
		double num4 = Math.PI * 2.0;
		for (int j = 1; j < _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D; j++)
		{
			num4 -= num;
			array3[j] = Math.Sin(num4);
			array4[j] = Math.Cos(num4);
		}
		array3[_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D] = 0.0;
		array4[_0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D] = 1.0;
		for (int k = 0; k < _0023_003Dzcnlc0W9082xJ; k++)
		{
			for (int l = 0; l <= _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D; l++)
			{
				MNODE item = new MNODE(new Point3D
				{
					X = _0023_003DzEGKj_0024SNUUihi * array[k] * array4[l],
					Y = _0023_003DzEGKj_0024SNUUihi * array[k] * array3[l],
					Z = _0023_003DzEGKj_0024SNUUihi * array2[k]
				}, 0);
				NodeList.Add(item);
			}
		}
		int _0023_003DzSkUy_T8_003D = -32767;
		new _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D(NodeList)._0023_003DzKlS_0024RTSkHohzMAAySQ_003D_003D(this, ref _0023_003DzSkUy_T8_003D, _0023_003Dzcnlc0W9082xJ, _0023_003DzaPwg_0024QqjLl_P07R7uQ_003D_003D + 1, 0.0, _0023_003DzkRSfKls1SLfn);
		return _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzFipFikVW1CJj(this, (_0023_003Dz1IcEX2Y45sL1)0, 100f, null, _0023_003DzkRSfKls1SLfn);
	}

	internal static Solid[] _0023_003DzZHGcnP0_003D(ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003Dz_SqBXz8_003D, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL, bool _0023_003DzjepEGXc_003D)
	{
		return _0023_003DzZHGcnP0_003D<Solid>(_0023_003DzHgrHIfhYCh4p, _0023_003Dz_SqBXz8_003D, _0023_003Dzm0CYiiE_003D, _0023_003Dz0h7AakEIaVwL, _0023_003DzjepEGXc_003D);
	}

	internal static T[] _0023_003DzZHGcnP0_003D<T>(ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003Dz_SqBXz8_003D, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL, bool _0023_003DzjepEGXc_003D) where T : Solid, new()
	{
		return _0023_003Dz1A9iP9WIToC5<T>(_0023_003DzHgrHIfhYCh4p, _0023_003Dz_SqBXz8_003D, null, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: false, _0023_003Dz0h7AakEIaVwL, _0023_003DzjepEGXc_003D: true);
	}

	public static Solid Sweep(ICurve rail, Region region, double tol, sweepMethodType sweepMethod, bool merge = true)
	{
		return Sweep<Solid>(rail, region, tol, sweepMethod);
	}

	public static T Sweep<T>(ICurve rail, Region region, double tol, sweepMethodType sweepMethod, bool merge = true) where T : Solid, new()
	{
		IList<ICurve> list = new List<ICurve>();
		for (int i = 1; i < region.ContourList.Count; i++)
		{
			list.Add(region.ContourList[i]);
		}
		if (list.Count == 0)
		{
			list = null;
		}
		return _0023_003Dz1A9iP9WIToC5<T>(rail, region.ContourList[0], list, tol, _0023_003DzbErHvVw_003D: true, sweepMethod, _0023_003DzjepEGXc_003D: true)[0];
	}

	private static T[] _0023_003Dz1A9iP9WIToC5<T>(ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzbErHvVw_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL, bool _0023_003DzjepEGXc_003D) where T : Solid, new()
	{
		bool isClosed = _0023_003DzHgrHIfhYCh4p.IsClosed;
		_0023_003DzbErHvVw_003D = _0023_003DzbErHvVw_003D || (isClosed && _0023_003Dz_SqBXz8_003D.IsClosed);
		if (!_0023_003DzbErHvVw_003D)
		{
			Mesh mesh = Mesh._0023_003Dz1A9iP9WIToC5<Mesh>(_0023_003DzHgrHIfhYCh4p, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: false, _0023_003Dz0h7AakEIaVwL, Mesh.natureType.Plain, _0023_003DzjepEGXc_003D: true)[0];
			if (mesh == null)
			{
				return null;
			}
			return new T[1] { FromTriangles<T>(mesh._vertices, mesh._triangles) };
		}
		Utility._0023_003DzDE7mL_712NEZeE5wpw_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzHgrHIfhYCh4p, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: true, _0023_003DzGb8kdyZ1x5nj: false);
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			if (isClosed)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302978006));
			}
			foreach (ICurve item in _0023_003DzWaFlkhfmYCja)
			{
				Utility._0023_003DzDE7mL_712NEZeE5wpw_003D_003D(item, _0023_003DzHgrHIfhYCh4p, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D, _0023_003DzGb8kdyZ1x5nj: false);
			}
		}
		Utility._0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dzm0CYiiE_003D, _0023_003DzFSLBkBecx_0024NX: true, out var _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003Dz6SBnzmNnw6lO: false);
		T[] array = new T[_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length];
		double _0023_003DzC5YR9r5C06bj = Utility._0023_003DzgP4qC37WNH1g(_0023_003Dz_SqBXz8_003D);
		ICurve curve = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		ICurve[] array2 = null;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			array2 = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				array2[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
			}
		}
		Plane _0023_003DzStUznlUnGSG = null;
		for (int j = 0; j < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length; j++)
		{
			ICurve curve2 = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j];
			T val = null;
			if (curve2 is Line)
			{
				val = _0023_003DzdncxQYEu8hc00O7aiw_003D_003D<T>(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array2, _0023_003DzC5YR9r5C06bj, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: true, isClosed);
			}
			else if (curve2 is Circle)
			{
				val = _0023_003DzRLbt9uDCT0W7yo59pg_003D_003D<T>(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array2, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: true, isClosed);
			}
			else if (curve2 is Curve)
			{
				val = _0023_003DzriHaSLBwtW75<T>(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array2, _0023_003DzC5YR9r5C06bj, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D: true, isClosed, _0023_003Dz0h7AakEIaVwL);
			}
			ICurve _0023_003DzHXbzvx8ZY9nt = null;
			if (j + 1 < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length)
			{
				_0023_003DzHXbzvx8ZY9nt = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j + 1];
			}
			if (array2 != null)
			{
				for (int k = 0; k < array2.Length; k++)
				{
					Utility._0023_003DzUF5dE52DL3PQ(array2[k], curve2, _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dz0h7AakEIaVwL, _0023_003Dz3fpuiiI_003D: false);
				}
			}
			Utility._0023_003DzUF5dE52DL3PQ(curve, curve2, _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dz0h7AakEIaVwL, _0023_003Dz3fpuiiI_003D: true);
			if (val != null)
			{
				array[j] = val;
			}
		}
		if (_0023_003DzjepEGXc_003D)
		{
			return _0023_003DzrIsIvtI_003D(array);
		}
		return array;
	}

	private static T _0023_003DzriHaSLBwtW75<T>(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003DzHqLWCbnjp331, ICurve[] _0023_003Dz3GJiJDPU46hO, double _0023_003DzC5YR9r5C06bj, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq, sweepMethodType _0023_003Dz0h7AakEIaVwL) where T : Solid, new()
	{
		Transformation[] array = new Transformation[2];
		Plane[] array2 = new Plane[2];
		Utility._0023_003Dz7b9TFrXd9rCVnRQEGAbz5MKjvMEiSWk3Sg_003D_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003DzC5YR9r5C06bj / 2.0, _0023_003DzHbb9s4FIaFfq, out array2[0], out array2[1], out array[0], out array[1]);
		Mesh mesh = Mesh._0023_003DzFXb0cTg_003D<Mesh>(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003DzHqLWCbnjp331, _0023_003Dz3GJiJDPU46hO, array, _0023_003Dzm0CYiiE_003D, _0023_003DzbErHvVw_003D, _0023_003DzbErHvVw_003D && (!_0023_003DzHbb9s4FIaFfq || _0023_003DzHgrHIfhYCh4p.Length > 1), _0023_003Dz0h7AakEIaVwL, Mesh.natureType.Smooth);
		T val = FromTriangles<T>(mesh._vertices, mesh._triangles);
		_0023_003Dz7mr_4Z4_003D(val, array2);
		val.Regen(_0023_003Dzm0CYiiE_003D);
		return val;
	}

	public static Solid[] Union(IList<Solid> solids)
	{
		return _0023_003DzrIsIvtI_003D(solids);
	}

	private static T[] _0023_003DzrIsIvtI_003D<T>(IList<T> _0023_003DzH6GDaaq_lIr4) where T : Solid, new()
	{
		List<T> list = new List<T>();
		foreach (T item in _0023_003DzH6GDaaq_lIr4)
		{
			if (item == null)
			{
				continue;
			}
			T val = item;
			if (list.Count == 0)
			{
				list.Add(val);
				continue;
			}
			for (int num = list.Count - 1; num >= 0; num--)
			{
				T val2 = list[num];
				T[] array = Union(val2, val);
				list.Remove(val);
				list.Remove(val2);
				if (array == null)
				{
					list.Add(val);
				}
				else if (array.Length == 2)
				{
					list.Add(val);
					list.Add(val2);
				}
				else
				{
					list.Add(array[0]);
				}
			}
		}
		return list.ToArray();
	}

	private static double _0023_003DzgP4qC37WNH1g(ICurve _0023_003DzCRq4LBU_003D)
	{
		return _0023_003DzCRq4LBU_003D.Length() * 4.0;
	}

	private static T _0023_003DzdncxQYEu8hc00O7aiw_003D_003D<T>(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzC5YR9r5C06bj, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq) where T : Solid, new()
	{
		Plane[] array = new Plane[2];
		Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzC5YR9r5C06bj, out var _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D, out var _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D, out array[0], out array[1], out var _0023_003Dzx5RboRHsRXS, out var _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzHbb9s4FIaFfq);
		Vector3D _0023_003DzYNjcavt9guh = new Vector3D(_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D.StartPoint, _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D.EndPoint);
		T val = _0023_003DzFPVyG4Y9TGyH<T>(_0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003DzYNjcavt9guh, _0023_003DzbErHvVw_003D);
		_0023_003Dz7mr_4Z4_003D(val, array);
		return val;
	}

	private static T _0023_003DzRLbt9uDCT0W7yo59pg_003D_003D<T>(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq) where T : Solid, new()
	{
		Plane[] array = new Plane[2];
		Utility._0023_003Dzi_uJo1YauacTvNQ2CLEP2dc_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D, out var _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D, out array[0], out array[1], out var _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out var _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzHbb9s4FIaFfq, _0023_003DzqZLpJx9EBl4E2J4o3A9hYdM_003D: false);
		T val = _0023_003DzckMvsK9P4Br2SeVfrm3XM54_003D<T>(_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D, array[0], (_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D == null) ? array[1] : null, _0023_003DzbErHvVw_003D);
		if (_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D == null)
		{
			return val;
		}
		T val2 = _0023_003DzckMvsK9P4Br2SeVfrm3XM54_003D<T>(_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D, array[1], null, _0023_003DzbErHvVw_003D);
		if (val2 != null)
		{
			T[] array2 = Union(val, val2);
			if (array2 == null || array2.Length != 1)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977654));
			}
			val = array2[0];
		}
		return val;
	}

	private static T _0023_003DzckMvsK9P4Br2SeVfrm3XM54_003D<T>(ICurve _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, IList<ICurve> _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, Arc _0023_003DzN4MDZ_0024c_003D, Plane _0023_003Dz1UOOIRi32zbc, Plane _0023_003Dz0mRtGxd84ek0, bool _0023_003DzbErHvVw_003D) where T : Solid, new()
	{
		int _0023_003DzAPBIJmvn5i5Q = Utility.NumberOfSegments(_0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.AngleInRadians, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D);
		T val = _0023_003DzZsKpvYbXHCDE<T>(_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, 0.0, _0023_003DzN4MDZ_0024c_003D.AngleInRadians, _0023_003DzN4MDZ_0024c_003D.Plane.AxisZ, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzAPBIJmvn5i5Q, _0023_003DzbErHvVw_003D);
		if (val == null)
		{
			throw new ArithmeticException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972521) + _0023_003DzN4MDZ_0024c_003D.Radius);
		}
		Plane[] _0023_003DzO846Fq5qmPew = new Plane[2] { _0023_003Dz1UOOIRi32zbc, _0023_003Dz0mRtGxd84ek0 };
		_0023_003Dz7mr_4Z4_003D(val, _0023_003DzO846Fq5qmPew);
		return val;
	}

	private static void _0023_003Dz7mr_4Z4_003D(Solid _0023_003Dz2zoRYrk_003D, Plane[] _0023_003DzO846Fq5qmPew)
	{
		foreach (Plane plane in _0023_003DzO846Fq5qmPew)
		{
			if (!(plane == null) && _0023_003Dz2zoRYrk_003D.CutBy(plane) != booleanFailureType.Success)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977617));
			}
		}
	}

	public static Solid CreateSpring(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist)
	{
		return CreateSpring<Solid>(radius, wireRadius, sides, rings, pitch, turns, reverseTwist);
	}

	public static T CreateSpring<T>(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist) where T : Solid, new()
	{
		return CreateSpring<T>(radius, wireRadius, sides, rings, pitch, turns, reverseTwist, closed: true);
	}

	public static Solid CreateSpring(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist, bool closed)
	{
		return CreateSpring<Solid>(radius, wireRadius, sides, rings, pitch, turns, reverseTwist, closed);
	}

	public static T CreateSpring<T>(double radius, double wireRadius, int sides, int rings, double pitch, double turns, bool reverseTwist, bool closed) where T : Solid, new()
	{
		return Mesh.CreateSpring(radius, wireRadius, sides, rings, pitch, turns, reverseTwist, closed, Mesh.natureType.Smooth).ConvertToSolid<T>();
	}

	public static Solid CreateTorus(double majorRadius, double minorRadius, int sides, int rings)
	{
		return CreateTorus<Solid>(majorRadius, minorRadius, sides, rings);
	}

	public static T CreateTorus<T>(double majorRadius, double minorRadius, int sides, int rings) where T : Solid, new()
	{
		T val = new T();
		Point3D _0023_003DzF7v9r2A_003D = new Point3D(0.0 - (majorRadius + minorRadius), 0.0 - (majorRadius + minorRadius), 0.0 - minorRadius);
		Point3D _0023_003Dz8dK2uhU_003D = new Point3D(majorRadius + minorRadius, majorRadius + minorRadius, minorRadius);
		double _0023_003DzkRSfKls1SLfn = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		val.NodeList = new List<MNODE>();
		if (val._0023_003Dz0e6XvKBKfdAqlySJKQ_003D_003D(majorRadius, minorRadius, sides, rings, _0023_003DzkRSfKls1SLfn) == 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977614));
		}
		val.UpdateBoundingBox(null);
		return val;
	}

	private int _0023_003Dz0e6XvKBKfdAqlySJKQ_003D_003D(double _0023_003DzA_8ilLvuROi4, double _0023_003DzZonw8nQGtIca, int _0023_003Dz_C5M_0024TZrmoaK, int _0023_003DzhPRb7hlqAZjf, double _0023_003DzkRSfKls1SLfn)
	{
		if (_0023_003DzA_8ilLvuROi4 < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzZonw8nQGtIca < Utility._0023_003DzheSR8QM7q9ya || _0023_003DzhPRb7hlqAZjf < 3 || _0023_003Dz_C5M_0024TZrmoaK < 2)
		{
			return 0;
		}
		double num = ((!(_0023_003DzA_8ilLvuROi4 > _0023_003DzZonw8nQGtIca)) ? Math.Acos(_0023_003DzA_8ilLvuROi4 / _0023_003DzZonw8nQGtIca) : 0.0);
		double num2 = Math.PI * 2.0 / (double)_0023_003DzhPRb7hlqAZjf;
		double num3 = 2.0 * (Math.PI - num) / (double)_0023_003Dz_C5M_0024TZrmoaK;
		for (int i = 0; i < _0023_003Dz_C5M_0024TZrmoaK + 1; i++)
		{
			double num4 = ((i != _0023_003Dz_C5M_0024TZrmoaK) ? (Math.PI - num - num3 * (double)i) : (Math.PI + num));
			for (int j = 0; j < _0023_003DzhPRb7hlqAZjf + 1; j++)
			{
				double num5 = ((j != _0023_003DzhPRb7hlqAZjf) ? (Math.PI * 2.0 - num2 * (double)j) : 0.0);
				MNODE item = new MNODE(new Point3D
				{
					X = (_0023_003DzA_8ilLvuROi4 + _0023_003DzZonw8nQGtIca * Math.Cos(num4)) * Math.Cos(num5),
					Y = (_0023_003DzA_8ilLvuROi4 + _0023_003DzZonw8nQGtIca * Math.Cos(num4)) * Math.Sin(num5),
					Z = _0023_003DzZonw8nQGtIca * Math.Sin(num4)
				}, 0);
				NodeList.Add(item);
			}
		}
		int _0023_003DzSkUy_T8_003D = -32767;
		new _0023_003DzXQq8WHZ8tUI2qZau9P5Pb_0024Fr3XpEu8sp4A_003D_003D(NodeList)._0023_003DzKlS_0024RTSkHohzMAAySQ_003D_003D(this, ref _0023_003DzSkUy_T8_003D, _0023_003Dz_C5M_0024TZrmoaK + 1, _0023_003DzhPRb7hlqAZjf + 1, 0.0, _0023_003DzkRSfKls1SLfn);
		return _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzFipFikVW1CJj(this, (_0023_003Dz1IcEX2Y45sL1)0, 100f, null, _0023_003DzkRSfKls1SLfn);
	}

	internal void _0023_003DzSMdl97OuFfBX()
	{
		portions = new List<Portion>();
		NbList = new List<int>();
		NpStrList = new List<NpStr>();
		NpStrDict = new Dictionary<int, NpStr>();
	}

	private void _0023_003DzTvFaOE1Y6EnS(Solid _0023_003DzySgeilxprQOK, bool _0023_003Dzu9oxwJ_zKlMt)
	{
		_0023_003DzSMdl97OuFfBX();
		for (int i = 0; i < _0023_003DzySgeilxprQOK.portions.Count; i++)
		{
			Portion item = (Portion)(_0023_003Dzu9oxwJ_zKlMt ? _0023_003DzySgeilxprQOK.portions[i].CloneWithTessellation() : _0023_003DzySgeilxprQOK.portions[i].Clone());
			portions.Add(item);
		}
	}

	private void _0023_003DzQzWeAZDZuWNX()
	{
		portions.Clear();
		NbList.Clear();
		NpStrList.Clear();
		NpStrDict.Clear();
	}

	internal void _0023_003DzfD12v8o3kSVM(brepType _0023_003DzGEIcT40b_0024_0024pyxr5Kxg_003D_003D)
	{
		_brepMode = _0023_003DzGEIcT40b_0024_0024pyxr5Kxg_003D_003D;
	}

	private void _0023_003DzEtMRntRxbTsa(TextureMappingData _0023_003Dzy361DgUIT50_0024)
	{
		if (_0023_003Dzy361DgUIT50_0024 != null)
		{
			Regen(1E-12);
			_0023_003DzVx8fW68EDLgG(_0023_003Dzy361DgUIT50_0024);
			RegenMode = regenType.CompileOnly;
		}
	}

	public override object Clone()
	{
		return new Solid(this);
	}

	public override object CloneWithTessellation()
	{
		return new Solid(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void Dispose()
	{
		_0023_003DzBv5MGLg_003D();
	}

	private void _0023_003DzBv5MGLg_003D()
	{
		foreach (Portion portion in portions)
		{
			portion.Dispose();
			portion.drawData = null;
			portion.drawEdgesData = null;
			portion.drawSelectedData = null;
		}
		drawIsocurve?.Dispose();
		if (Faces != null)
		{
			Faces.Clear();
		}
		base.Dispose();
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977573) + IsClosed);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977559) + portions.Count);
		int num = 0;
		int num2 = 0;
		double _0023_003DzXWCF4rA_003D = double.NaN;
		Point3D centroid = null;
		double _0023_003DzhKcriekaIolc = double.NaN;
		Point3D centroid2 = null;
		double _0023_003DzZZ1x4JqOx = double.NaN;
		double convertedDensity = double.NaN;
		if (regenMode == regenType.RegenAndCompile)
		{
			foreach (Portion portion in portions)
			{
				num += portion.vertexCount;
			}
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302971351));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		}
		else
		{
			_0023_003DzXWCF4rA_003D = GetArea(out centroid);
			_0023_003DzhKcriekaIolc = GetVolume(out centroid2);
			_0023_003DzZZ1x4JqOx = GetMass(GetMaterial(materials, layers), linearUnits, massUnits, out convertedDensity);
			foreach (Portion portion2 in portions)
			{
				num += portion2.vertexCount;
				num2 += portion2._triangles.Length;
			}
		}
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977779) + num);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977749) + num2);
		stringBuilder = _0023_003DzJ7t6sHqYVrbZ(stringBuilder, _0023_003DzXWCF4rA_003D, centroid, _0023_003DzhKcriekaIolc, centroid2, _0023_003DzZZ1x4JqOx, convertedDensity, linearUnits, massUnits, materials, layers);
		return stringBuilder.ToString();
	}

	public double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(GetTessellation());
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		Point3D centroid;
		return Utility._0023_003DzaWhFDDP5nQ_0024L(material, MaterialName, massUnits, linearUnits, GetVolume(out centroid), out convertedDensity);
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		List<Point3D> list = new List<Point3D>();
		foreach (Portion portion in portions)
		{
			list.AddRange(portion.Vertices);
		}
		Utility._0023_003Dzyx35VoBSR6flPmM7uA_003D_003D(list, out var _0023_003DzTbDlaOM_003D);
		verticesCoords = _0023_003DzTbDlaOM_003D;
		return true;
	}

	public bool IsPointInside(Point3D point)
	{
		if (base.BoxMin != null && !point.IsInside(base.BoxMin, base.BoxMax))
		{
			return false;
		}
		_0023_003Dza4AJl0DnV9nq _0023_003Dz4zn204U_003D = new _0023_003Dza4AJl0DnV9nq(new Size3D(base.BoxMin, base.BoxMax).Diagonal * 1E-09);
		int num = _0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)0, _0023_003Dz4zn204U_003D);
		if (num != -1)
		{
			return num == 1;
		}
		int num2 = _0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)2, _0023_003Dz4zn204U_003D);
		if (num2 != -1)
		{
			return num2 == 1;
		}
		return _0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)1, _0023_003Dz4zn204U_003D) == 1;
	}

	private int _0023_003DzVb4wZyDw8mgJ(Point3D _0023_003DzlY77YgY_003D, Utility._0023_003DzwhtOFTk_003D _0023_003DzxuJqjrs_003D, _0023_003Dza4AJl0DnV9nq _0023_003Dz4zn204U_003D)
	{
		int result = 0;
		Segment3D[] array = new Segment3D[4];
		Segment3D segment3D = Utility._0023_003DzDoIUcjWkjZQJ(_0023_003DzlY77YgY_003D, _0023_003DzxuJqjrs_003D, _0023_003DzlY77YgY_003D, _0023_003DzlY77YgY_003D, 0.0);
		Segment3D segment3D2 = Utility._0023_003DzDoIUcjWkjZQJ(_0023_003DzlY77YgY_003D, _0023_003DzxuJqjrs_003D, _0023_003DzlY77YgY_003D, _0023_003DzlY77YgY_003D, Utility.DegToRad(10.0));
		array[0] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D.P1);
		array[1] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D.P0);
		array[2] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D2.P1);
		array[3] = new Segment3D(_0023_003DzlY77YgY_003D, segment3D2.P0);
		int num = -1;
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003Dz4_CBGipsMzJ9Z44ugwK7tfTLRUp8 _0023_003Dz4_CBGipsMzJ9Z44ugwK7tfTLRUp9 = new _0023_003Dz4_CBGipsMzJ9Z44ugwK7tfTLRUp8(_0023_003Dz4zn204U_003D);
			for (int j = 0; j < Portions.Count; j++)
			{
				Portion portion = Portions[j];
				if (i >= 2 || _0023_003DzxuJqjrs_003D switch
				{
					(Utility._0023_003DzwhtOFTk_003D)0 => (portion.BoxMin.Z > _0023_003DzlY77YgY_003D.Z || portion.BoxMin.Y > _0023_003DzlY77YgY_003D.Y || portion.BoxMax.Z < _0023_003DzlY77YgY_003D.Z || portion.BoxMax.Y < _0023_003DzlY77YgY_003D.Y) ? 1 : 0, 
					(Utility._0023_003DzwhtOFTk_003D)1 => (portion.BoxMin.Z > _0023_003DzlY77YgY_003D.Z || portion.BoxMin.X > _0023_003DzlY77YgY_003D.X || portion.BoxMax.Z < _0023_003DzlY77YgY_003D.Z || portion.BoxMax.X < _0023_003DzlY77YgY_003D.X) ? 1 : 0, 
					(Utility._0023_003DzwhtOFTk_003D)2 => (portion.BoxMin.Y > _0023_003DzlY77YgY_003D.Y || portion.BoxMin.X > _0023_003DzlY77YgY_003D.X || portion.BoxMax.Y < _0023_003DzlY77YgY_003D.Y || portion.BoxMax.X < _0023_003DzlY77YgY_003D.X) ? 1 : 0, 
					_ => (portion.BoxMin.Y > _0023_003DzlY77YgY_003D.Y || portion.BoxMin.X > _0023_003DzlY77YgY_003D.X || portion.BoxMax.Y < _0023_003DzlY77YgY_003D.Y || portion.BoxMax.X < _0023_003DzlY77YgY_003D.X) ? 1 : 0, 
				} == 0)
				{
					_0023_003Dz4_CBGipsMzJ9Z44ugwK7tfTLRUp9._0023_003DzymeFGXxU0V7FfTQHLw_003D_003D(portion.Vertices, portion.Triangles, portion.Edges);
					int num2 = _0023_003Dz4_CBGipsMzJ9Z44ugwK7tfTLRUp9._0023_003Dz3WVjyBfqduu95gCh_0024A_003D_003D(array[i], _0023_003DzlY77YgY_003D, (i < 2) ? _0023_003DzxuJqjrs_003D : ((Utility._0023_003DzwhtOFTk_003D)3));
					if (num2 == -1)
					{
						num = -1;
						break;
					}
					num = ((num != -1) ? (num + num2) : num2);
				}
			}
			if (num != -1)
			{
				break;
			}
		}
		if (num == -1)
		{
			return -1;
		}
		if (num % 2 != 0)
		{
			result = 1;
		}
		return result;
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Smooth, bool weld = true)
	{
		if (portions.Count == 0)
		{
			return null;
		}
		if (regenMode == regenType.RegenAndCompile)
		{
			Regen(0.0);
		}
		int num = 0;
		foreach (Portion portion in portions)
		{
			num += portion.vertexCount;
		}
		if (num == 0)
		{
			return null;
		}
		Mesh mesh = _0023_003Dzy2VmYyDMwahtQBn5_g_003D_003D(portions[0]);
		for (int i = 1; i < portions.Count; i++)
		{
			mesh.MergeWith(portions[i], weldNow: false);
		}
		if (weld)
		{
			mesh.Weld();
		}
		mesh.CopyAttributes(this);
		return mesh;
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		return ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain).ConvertToBrep(mergeFaces, mergeEdges);
	}

	private Mesh _0023_003Dzy2VmYyDMwahtQBn5_g_003D_003D(Portion _0023_003Dz5Tpjxj5wp_0024R8)
	{
		Point3D[] array = new Point3D[_0023_003Dz5Tpjxj5wp_0024R8.vertexCount];
		for (int i = 0; i < _0023_003Dz5Tpjxj5wp_0024R8.vertexCount; i++)
		{
			array[i] = (Point3D)_0023_003Dz5Tpjxj5wp_0024R8._vertices[i].Clone();
		}
		IndexTriangle[] array2 = new IndexTriangle[_0023_003Dz5Tpjxj5wp_0024R8._triangles.Length];
		for (int j = 0; j < _0023_003Dz5Tpjxj5wp_0024R8._triangles.Length; j++)
		{
			array2[j] = (IndexTriangle)_0023_003Dz5Tpjxj5wp_0024R8._triangles[j].Clone();
		}
		Mesh mesh = new Mesh(array, array2);
		if (_0023_003Dz5Tpjxj5wp_0024R8.TextureCoords != null)
		{
			mesh.TextureCoords = new PointF[_0023_003Dz5Tpjxj5wp_0024R8.TextureCoords.Length];
			_0023_003Dz5Tpjxj5wp_0024R8.TextureCoords.CopyTo(mesh.TextureCoords, 0);
		}
		return mesh;
	}

	internal _0023_003Dzd1_0024NwM3DiRKw _0023_003DzqbdRBuHK_0024_0024vQ()
	{
		_0023_003Dzd1_0024NwM3DiRKw _0023_003Dzd1_0024NwM3DiRKw2 = new _0023_003Dzd1_0024NwM3DiRKw();
		int count = portions.Count;
		if (count <= 0)
		{
			return _0023_003Dzd1_0024NwM3DiRKw2;
		}
		_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy = new _0023_003Dzfile4ZpfGZE6f1uDBw_003D_003D[count];
		for (int i = 0; i < count; i++)
		{
			_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[i] = new _0023_003Dzfile4ZpfGZE6f1uDBw_003D_003D();
		}
		for (int j = 0; j < count; j++)
		{
			Portion portion = portions[j];
			portion.UpdateBoundingBox(null);
			if (_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j] == null)
			{
				return _0023_003Dzd1_0024NwM3DiRKw2;
			}
			_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DzZqSqKm8_003D = (Point3D)portion.localMin.Clone();
			_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DztvD0Jdc_003D = (Point3D)portion.localMax.Clone();
			_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DzkeuNDwc_003D = portion.vertexCount;
			_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D = new Point3D[portion.vertexCount];
			for (int k = 0; k < portion.vertexCount; k++)
			{
				_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[k] = new Point3D(portion._vertices[k].X, portion._vertices[k].Y, portion._vertices[k].Z);
			}
			_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DzRnF_0024lvc_003D = portion.edgeCount;
			_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DzU4XYawo_003D = new _0023_003DzO5skTHYyevUSqcd1wpqILIE_003D[portion.edgeCount];
			for (int l = 0; l < portion.edgeCount; l++)
			{
				_0023_003Dzd1_0024NwM3DiRKw2._0023_003DzRIfswZZzGQPy[j]._0023_003DzU4XYawo_003D[l] = new _0023_003DzO5skTHYyevUSqcd1wpqILIE_003D(portion.edgeDatas[l + 1].BeginVertex, portion.edgeDatas[l + 1].EndVertex, portion.edgeDatas[l + 1].Type);
			}
		}
		return _0023_003Dzd1_0024NwM3DiRKw2;
	}

	internal void _0023_003DzFiTFoZw_003D(Solid _0023_003DzySgeilxprQOK)
	{
		_0023_003DzFiTFoZw_003D(_0023_003DzySgeilxprQOK, _0023_003Dz6DPkFnsSJEJc: true, _0023_003Dzu9oxwJ_zKlMt: false);
	}

	private void _0023_003DzFiTFoZw_003D(Solid _0023_003DzySgeilxprQOK, bool _0023_003Dz6DPkFnsSJEJc, bool _0023_003Dzu9oxwJ_zKlMt)
	{
		_0023_003DzTvFaOE1Y6EnS(_0023_003DzySgeilxprQOK, _0023_003Dzu9oxwJ_zKlMt);
		if (_0023_003Dz6DPkFnsSJEJc)
		{
			UpdateBoundingBox(null);
		}
	}

	public override void TransformBy(Transformation xform)
	{
		foreach (Portion portion in portions)
		{
			for (int i = 0; i < portion.vertexCount; i++)
			{
				Point3D point3D = xform * portion._vertices[i];
				portion._vertices[i] = point3D;
			}
			if (portion.Normals != null)
			{
				Utility.TransformNormals(xform, portion.Normals);
			}
			for (int j = 1; j <= portion.faceCount; j++)
			{
				Plane plane = new Plane(new double[4]
				{
					portion.planes[j].X,
					portion.planes[j].Y,
					portion.planes[j].Z,
					portion.planes[j].D
				});
				plane.TransformBy(xform);
				portion.planes[j] = plane.Equation;
			}
		}
		if (_brepMode == brepType.Body)
		{
			double _0023_003DzhKcriekaIolc = 0.0;
			for (int k = 0; k < portions.Count; k++)
			{
				_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzEQxK9Wi6z58v(portions[k], ref _0023_003DzhKcriekaIolc);
			}
			if (_0023_003DzhKcriekaIolc < 0.0)
			{
				FlipNormal();
			}
		}
		if (textureMapping != null)
		{
			Transformation transformation = (Transformation)xform.Clone();
			if (textureMapping.Transformation == null)
			{
				textureMapping.Transformation = transformation;
			}
			else
			{
				textureMapping.Transformation *= transformation;
			}
		}
		if (xform.HasScaling)
		{
			UpdateAngles();
		}
		base.TransformBy(xform);
		if (localMin == null || localMax == null)
		{
			UpdateBoundingBox(null);
		}
	}

	private protected override void _0023_003Dzl_SRSHmkyuNv(Transformation _0023_003DzLS0sR0pzioXc)
	{
		if (!_0023_003DzLS0sR0pzioXc.HasRotation && !_0023_003DzLS0sR0pzioXc.HasReflection)
		{
			foreach (Portion portion in Portions)
			{
				portion.localMin.TransformBy(_0023_003DzLS0sR0pzioXc);
				portion.localMax.TransformBy(_0023_003DzLS0sR0pzioXc);
				portion.UpdateBoundingBoxSphere();
			}
		}
		base._0023_003Dzl_SRSHmkyuNv(_0023_003DzLS0sR0pzioXc);
	}

	protected void UpdateAngles()
	{
		for (int i = 0; i < portions.Count; i++)
		{
			if (i >= NpStrList.Count)
			{
				continue;
			}
			NpStr npStr = NpStrList[i];
			Portion portion = portions[npStr.hnp - 1];
			int b = npStr.b;
			for (int j = 0; j < npStr.len; j++)
			{
				int index = NbList[b++];
				NpStr npStr2 = NpStrList[index];
				Portion portion2 = portions[npStr2.hnp - 1];
				for (int k = 0; k <= portion.edgeCount; k++)
				{
					int beginVertex = portion.edgeDatas[k].BeginVertex;
					int endVertex = portion.edgeDatas[k].EndVertex;
					for (int l = 1; l <= portion2.edgeCount; l++)
					{
						int beginVertex2 = portion2.edgeDatas[l].BeginVertex;
						int endVertex2 = portion2.edgeDatas[l].EndVertex;
						if ((_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[beginVertex], portion2._vertices[beginVertex2], Utility._0023_003DzxhnLabVjXjPg) && _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[endVertex], portion2._vertices[endVertex2], Utility._0023_003DzxhnLabVjXjPg)) || (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[endVertex], portion2._vertices[beginVertex2], Utility._0023_003DzxhnLabVjXjPg) && _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[beginVertex], portion2._vertices[endVertex2], Utility._0023_003DzxhnLabVjXjPg)))
						{
							int num = ((portion2.edgeDatas[l].NextFace > 0) ? portion2.edgeDatas[l].NextFace : portion2.edgeDatas[l].PreviousFace);
							int _0023_003DzRpXgovo_003D;
							int num2;
							if (portion.edgeDatas[k].NextFace <= 0)
							{
								_0023_003DzRpXgovo_003D = -k;
								num2 = portion.edgeDatas[k].PreviousFace;
							}
							else
							{
								_0023_003DzRpXgovo_003D = k;
								num2 = portion.edgeDatas[k].NextFace;
							}
							float angle = _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzSLyKdRKkR7Vx(portion, _0023_003DzRpXgovo_003D, portion.planes[num2], portion2.planes[num]);
							portion.edgeDatas[k].Angle = (portion2.edgeDatas[l].Angle = angle);
							break;
						}
					}
				}
			}
		}
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			if (!portions[i].AllVerticesInScreenPolygon(data))
			{
				return false;
			}
		}
		AddSelectedItemLeaf(data);
		return true;
	}

	internal void _0023_003DzYm_0024NZRCNgy0n(int _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, int _0023_003Dzfe2zeQMumw_4, int _0023_003DzhX7K0dc_003D, out List<int[]> _0023_003Dzcv8o5nO25OjS, out List<Vector3D[]> _0023_003DzztJY0_0024dXEFMk, double _0023_003DzkRSfKls1SLfn)
	{
		_0023_003Dzcv8o5nO25OjS = new List<int[]>();
		_0023_003DzztJY0_0024dXEFMk = new List<Vector3D[]>();
		Portion portion = portions[_0023_003DzcJGGbLLieXH3SbfWuw_003D_003D];
		int num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(portion.cycles[portion.faces[_0023_003Dzfe2zeQMumw_4].FirstContour].FirstEdge, portion);
		Vector3D vector3D = portion.planes[_0023_003Dzfe2zeQMumw_4];
		int num2 = portion.faces[_0023_003Dzfe2zeQMumw_4].FirstContour;
		do
		{
			List<int> list = new List<int>();
			List<Vector3D> list2 = new List<Vector3D>();
			int num4;
			int num3 = (num4 = portion.cycles[num2].FirstEdge);
			num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num4, portion);
			Vector3D _0023_003Dz7hp7a0EFUobk;
			if (_0023_003DzhX7K0dc_003D != 2)
			{
				int _0023_003DzTx2aqr8_003D = ((_0023_003DzhX7K0dc_003D == 1) ? num4 : (-num4));
				_0023_003Dz7hp7a0EFUobk = new Vector3D();
				if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzcQt9lrVLzd3R(this, _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, _0023_003DzTx2aqr8_003D, ref _0023_003Dz7hp7a0EFUobk, num, _0023_003DzkRSfKls1SLfn))
				{
					_0023_003Dz7hp7a0EFUobk = vector3D;
				}
			}
			else
			{
				_0023_003Dz7hp7a0EFUobk = vector3D;
			}
			list2.Add(new Vector3D(_0023_003Dz7hp7a0EFUobk.X, _0023_003Dz7hp7a0EFUobk.Y, _0023_003Dz7hp7a0EFUobk.Z));
			list.Add(num);
			while (true)
			{
				int num5 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num4, portion);
				if ((num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num4, portion)) == num3)
				{
					break;
				}
				Vector3D _0023_003Dz7hp7a0EFUobk2;
				if (_0023_003DzhX7K0dc_003D != 2)
				{
					int _0023_003DzTx2aqr8_003D2 = ((_0023_003DzhX7K0dc_003D == 1) ? num4 : (-num4));
					_0023_003Dz7hp7a0EFUobk2 = new Vector3D();
					if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzcQt9lrVLzd3R(this, _0023_003DzcJGGbLLieXH3SbfWuw_003D_003D, _0023_003DzTx2aqr8_003D2, ref _0023_003Dz7hp7a0EFUobk2, num5, _0023_003DzkRSfKls1SLfn))
					{
						_0023_003Dz7hp7a0EFUobk2 = vector3D;
					}
				}
				else
				{
					_0023_003Dz7hp7a0EFUobk2 = vector3D;
				}
				list2.Add(new Vector3D(_0023_003Dz7hp7a0EFUobk2.X, _0023_003Dz7hp7a0EFUobk2.Y, _0023_003Dz7hp7a0EFUobk2.Z));
				list.Add(num5);
			}
			if (_0023_003DzhX7K0dc_003D == 1)
			{
				Vector3D vector3D2 = list2[list2.Count - 1];
				list2.Insert(0, new Vector3D(vector3D2.X, vector3D2.Y, vector3D2.Z));
			}
			else
			{
				list2.Add(new Vector3D(_0023_003Dz7hp7a0EFUobk.X, _0023_003Dz7hp7a0EFUobk.Y, _0023_003Dz7hp7a0EFUobk.Z));
			}
			list.Add(num);
			_0023_003Dzcv8o5nO25OjS.Add(list.ToArray());
			_0023_003DzztJY0_0024dXEFMk.Add(list2.ToArray());
			num2 = portion.cycles[num2].NextContour;
		}
		while (num2 > 0);
	}

	internal static int _0023_003DzQaPlK3qJVEsR8De_cQ_003D_003D(Portion _0023_003Dz5Tpjxj5wp_0024R8)
	{
		int num = 0;
		for (int i = 1; i <= _0023_003Dz5Tpjxj5wp_0024R8.edgeCount; i++)
		{
			if ((_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[Math.Abs(i)].Type & 1) > 0)
			{
				num++;
			}
		}
		if (num == 0)
		{
			return 0;
		}
		if (num == _0023_003Dz5Tpjxj5wp_0024R8.edgeCount)
		{
			return 2;
		}
		return 1;
	}

	public static Solid FromTriangles(IList<Point3D> vList, IList<IndexTriangle> tList)
	{
		return FromTriangles(vList, tList, Math.PI / 6.0, check: false);
	}

	public static T FromTriangles<T>(IList<Point3D> vList, IList<IndexTriangle> tList) where T : Solid, new()
	{
		return FromTriangles<T>(vList, tList, Math.PI / 6.0, check: false);
	}

	internal static T _0023_003DzPOf5fTBvzWMKZihEmQ_003D_003D<T>(Mesh _0023_003DzGGJSiQk_003D) where T : Solid, new()
	{
		double tol;
		if (_0023_003DzGGJSiQk_003D.BoxMin == null)
		{
			Utility.BoundingBox(_0023_003DzGGJSiQk_003D.Vertices, out var min, out var max);
			tol = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(min, max);
		}
		else
		{
			tol = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(_0023_003DzGGJSiQk_003D.BoxMin, _0023_003DzGGJSiQk_003D.BoxMax);
		}
		T val = FromTriangles<T>(_0023_003DzGGJSiQk_003D.Vertices, _0023_003DzGGJSiQk_003D.Triangles, Math.PI / 6.0, check: false, tol);
		val.CopyAttributes(_0023_003DzGGJSiQk_003D);
		return val;
	}

	public static Solid FromTriangles(IList<Point3D> vList, IList<IndexTriangle> tList, double smoothingAngle, bool check, double tol = 0.0)
	{
		if (tol == 0.0)
		{
			Utility.BoundingBox(vList, out var min, out var max);
			tol = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(min, max);
		}
		bool _0023_003DzgEJSOA0obF6h = false;
		if (vList.Count == 0 || tList.Count == 0)
		{
			return null;
		}
		_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj6 _0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7 = new _0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj6();
		_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D _0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2 = new _0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D();
		for (int i = 0; i < tList.Count; i++)
		{
			_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2._0023_003Dz77g161c_003D[0] = vList[tList[i].V1];
			_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2._0023_003Dz77g161c_003D[1] = vList[tList[i].V2];
			_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2._0023_003Dz77g161c_003D[2] = vList[tList[i].V3];
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzXkTom4kvjiup(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7, _0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2, check, ref _0023_003DzgEJSOA0obF6h, smoothingAngle, tol))
			{
				return null;
			}
		}
		List<brepType> list = new List<brepType>();
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzn3HP6_BOu55X(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7, list, smoothingAngle, tol))
		{
			return null;
		}
		Solid solid = new Solid(list[0] == brepType.Body);
		solid._0023_003DzFiTFoZw_003D(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7._0023_003DzNyH7pRAFnWHa);
		return solid;
	}

	public static T FromTriangles<T>(IList<Point3D> vList, IList<IndexTriangle> tList, double smoothingAngle, bool check, double tol = 0.0) where T : Solid, new()
	{
		if (tol == 0.0)
		{
			Utility.BoundingBox(vList, out var min, out var max);
			tol = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz3tcNmVFEsR5K(min, max);
		}
		bool _0023_003DzgEJSOA0obF6h = false;
		if (vList.Count == 0 || tList.Count == 0)
		{
			return null;
		}
		_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj6 _0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7 = new _0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj6();
		_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D _0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2 = new _0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D();
		for (int i = 0; i < tList.Count; i++)
		{
			_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2._0023_003Dz77g161c_003D[0] = vList[tList[i].V1];
			_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2._0023_003Dz77g161c_003D[1] = vList[tList[i].V2];
			_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2._0023_003Dz77g161c_003D[2] = vList[tList[i].V3];
			if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzXkTom4kvjiup(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7, _0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D2, check, ref _0023_003DzgEJSOA0obF6h, smoothingAngle, tol))
			{
				return null;
			}
		}
		List<brepType> list = new List<brepType>();
		if (!_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003Dzn3HP6_BOu55X(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7, list, smoothingAngle, tol))
		{
			return null;
		}
		T val = new T();
		val._0023_003DzfD12v8o3kSVM(list[0]);
		val._0023_003DzFiTFoZw_003D(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj7._0023_003DzNyH7pRAFnWHa);
		return val;
	}

	public void FlipNormal()
	{
		for (int i = 0; i < portions.Count; i++)
		{
			_0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39._0023_003DzG037o6MQFwqV(portions[i], (_0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: false);
		}
	}

	public Mesh[] GetTessellation()
	{
		List<Mesh> list = new List<Mesh>();
		foreach (Portion portion in portions)
		{
			list.AddRange(portion.GetTessellation());
		}
		return list.ToArray();
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (!EvaluateIntersectTriangles(data))
		{
			return false;
		}
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].InsideOrCrossingFrustum(data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (!EvaluateIntersectTriangles(data))
		{
			return false;
		}
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].InsideOrCrossingScreenPolygon(data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		for (int i = 0; i < Portions.Count; i++)
		{
			if (!portions[i].AllVerticesInFrustum(data))
			{
				return false;
			}
		}
		AddSelectedItemLeaf(data);
		return true;
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].ThroughTriangle(data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].ThroughTriangleScreenPolygon(data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		SortedList<double, HitTriangle> sortedList = new SortedList<double, HitTriangle>();
		for (int i = 0; i < portions.Count; i++)
		{
			Mesh mesh = portions[i];
			foreach (KeyValuePair<double, HitTriangle> item in Utility.FindClosestTriangle(transf, seg, mesh._vertices, mesh._triangles))
			{
				sortedList.Add(item.Key, new HitTriangle(item.Value.IntersectionPoint, item.Value.TriangleIndex, i, -1));
			}
		}
		return sortedList.Values;
	}

	internal override void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			int count = _0023_003DzELu0Pss_003D.ClosestVertices.Count;
			portions[i].FindClosestVertices(_0023_003DzELu0Pss_003D, _0023_003Dz7xzxLVk_003D);
			for (int j = count; j < _0023_003DzELu0Pss_003D.ClosestVertices.Count; j++)
			{
				_0023_003DzELu0Pss_003D.ClosestVertices[j].FaceIndex = i;
			}
		}
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		bool result = false;
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].FindClosestVertex(_0023_003DzELu0Pss_003D, _0023_003Dz7xzxLVk_003D))
			{
				_0023_003DzELu0Pss_003D.ClosestVertex.FaceIndex = i;
				result = true;
			}
		}
		return result;
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			portions[i].DrawVertices(data);
		}
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = _0023_003DzuAMveDQA6vvk();
		for (int i = 0; i < array.Length; i += 2)
		{
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = array[i];
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = array[i + 1];
			int _0023_003DzWuk5xhU5RfkzNR16ug_003D_003D = _0023_003DzyzK8swU_003D;
			obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
			obj._0023_003DznXwBXUw4u1qB(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974921));
			_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D obj2 = (_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D)_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2;
			obj2._0023_003DzWuk5xhU5RfkzNR16ug_003D_003D = _0023_003DzWuk5xhU5RfkzNR16ug_003D_003D;
			obj2._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
			obj2._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			obj2._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		}
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> list = new List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D>(portions.Count);
		for (int i = 0; i < portions.Count; i++)
		{
			Portion portion = portions[i];
			int _0023_003DzhX7K0dc_003D = _0023_003DzQaPlK3qJVEsR8De_cQ_003D_003D(portion);
			for (int j = 1; j <= portion.faceCount; j++)
			{
				_0023_003DzYm_0024NZRCNgy0n(i, j, _0023_003DzhX7K0dc_003D, out var _0023_003Dzcv8o5nO25OjS, out var _, 1E-12);
				PlaneEquation planeEquation = portion.planes[j];
				Plane _0023_003Dzpyw2kZk_003D = new Plane(new double[4] { planeEquation.X, planeEquation.Y, planeEquation.Z, planeEquation.D });
				CompositeCurve _0023_003Dz_SqBXz8_003D = _0023_003Dz72Tp8eo_003D(portion, _0023_003Dzcv8o5nO25OjS, 0);
				ICurve[] array = new ICurve[_0023_003Dzcv8o5nO25OjS.Count - 1];
				for (int k = 1; k < _0023_003Dzcv8o5nO25OjS.Count; k++)
				{
					array[k - 1] = _0023_003Dz72Tp8eo_003D(portion, _0023_003Dzcv8o5nO25OjS, k);
				}
				Surface surface = Surface._0023_003Dz7Bh67pM_003D(_0023_003Dzpyw2kZk_003D, _0023_003Dz_SqBXz8_003D, array, _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D: true);
				if (surface != null)
				{
					surface.CopyAttributes(this);
					list.AddRange(surface._0023_003DzuAMveDQA6vvk());
				}
			}
		}
		return list.ToArray();
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2 = new _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D();
		int count = portions.Count;
		for (int i = 0; i < count; i++)
		{
			Portion portion = portions[i];
			int _0023_003DzhX7K0dc_003D = _0023_003DzQaPlK3qJVEsR8De_cQ_003D_003D(portion);
			for (int j = 1; j <= portion.faceCount; j++)
			{
				_0023_003DzYm_0024NZRCNgy0n(i, j, _0023_003DzhX7K0dc_003D, out var _0023_003Dzcv8o5nO25OjS, out var _, 1E-12);
				PlaneEquation planeEquation = portion.planes[j];
				Plane plane = new Plane(new double[4]
				{
					0.0 - planeEquation.X,
					0.0 - planeEquation.Y,
					0.0 - planeEquation.Z,
					0.0 - planeEquation.D
				});
				List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>> list = new List<List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>>();
				list.Add(_0023_003DzfHSvFLY_003D(portion, _0023_003Dzcv8o5nO25OjS, 0));
				for (int k = 1; k < _0023_003Dzcv8o5nO25OjS.Count; k++)
				{
					list.Add(_0023_003DzfHSvFLY_003D(portion, _0023_003Dzcv8o5nO25OjS, k));
				}
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DznMfYYu4y2pvS(plane.Origin.ToArray(), plane.AxisZ.ToArray());
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzzFhuPAt59wzG(list);
				_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2._0023_003DzJ9shYljglKVu.Add(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
			}
		}
		_0023_003DzYe_6EnQecc8d(_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D2 };
	}

	private CompositeCurve _0023_003Dz72Tp8eo_003D(Portion _0023_003Dz5Tpjxj5wp_0024R8, List<int[]> _0023_003Dzcv8o5nO25OjS, int _0023_003DzyzK8swU_003D)
	{
		Line[] array = new Line[_0023_003Dzcv8o5nO25OjS[_0023_003DzyzK8swU_003D].Length - 1];
		Point3D[] vertices = _0023_003Dz5Tpjxj5wp_0024R8.Vertices;
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS[_0023_003DzyzK8swU_003D].Length - 1; i++)
		{
			Point3D start = vertices[_0023_003Dzcv8o5nO25OjS[_0023_003DzyzK8swU_003D][i]];
			Point3D end = vertices[_0023_003Dzcv8o5nO25OjS[_0023_003DzyzK8swU_003D][i + 1]];
			array[i] = new Line(start, end);
		}
		ICurve[] curveList = array;
		return new CompositeCurve(curveList);
	}

	private List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu> _0023_003DzfHSvFLY_003D(Portion _0023_003Dz5Tpjxj5wp_0024R8, List<int[]> _0023_003Dzcv8o5nO25OjS, int _0023_003DzyzK8swU_003D)
	{
		_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu[] array = new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu[_0023_003Dzcv8o5nO25OjS[_0023_003DzyzK8swU_003D].Length - 1];
		Point3D[] vertices = _0023_003Dz5Tpjxj5wp_0024R8.Vertices;
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS[_0023_003DzyzK8swU_003D].Length - 1; i++)
		{
			_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2 = new _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(vertices[_0023_003Dzcv8o5nO25OjS[_0023_003DzyzK8swU_003D][i]].ToArray());
			array[i] = _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu2;
		}
		return new List<_0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu>(array);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			return new Point3D[2] { localMin, localMax };
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	private void _0023_003Dz37_0024EFwOzwZ7g0Tiw_0024A_003D_003D(IList<Portion> _0023_003DzsFaa4UmaTRnio1htuA_003D_003D)
	{
		for (int i = 0; i < _0023_003DzsFaa4UmaTRnio1htuA_003D_003D.Count; i++)
		{
			portions.Add(_0023_003DzsFaa4UmaTRnio1htuA_003D_003D[i]);
		}
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new SolidSurrogate(this);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (Portions == null)
		{
			return false;
		}
		foreach (Portion portion in Portions)
		{
			if (!portion._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
			{
				return false;
			}
		}
		return true;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977273), _brepMode);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977261), localMin);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977246), localMax);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977227), portions);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977216), textureMapping);
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		return HiddenLinesView._0023_003Dzd6UfXbAV5XrdEzghYg_003D_003D(this, _0023_003DzELu0Pss_003D.Parents);
	}

	public bool IsAnyFaceSelected()
	{
		return SelectionInfoSubItems.IsAnySelected(FacesSelectionInfo);
	}

	internal override List<SelectionInfoSubItems> _0023_003Dz4NlMyrooY_aHAHG2Ag_003D_003D()
	{
		return FacesSelectionInfo;
	}

	internal override int _0023_003Dz5RPGbcVkdZb3()
	{
		if (Faces == null)
		{
			return base._0023_003Dz5RPGbcVkdZb3();
		}
		return Faces.Count;
	}

	public bool GetFaceSelection(int faceIndex, Stack<BlockReference> parents = null)
	{
		return SelectionInfoItemBase._0023_003Dz4SMVPY0ZDXX8(this, Faces, FacesSelectionInfo, faceIndex, parents);
	}

	public bool GetFaceSelection(int shellIndex, int faceIndex, Stack<BlockReference> parents = null)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972621));
	}

	public void SetFaceSelection(int shellIndex, int faceIndex, bool status, Stack<BlockReference> parents = null)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302972621));
	}

	public void SetFaceSelection(int faceIndex, bool status, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, faceIndex, status, this, Faces, FacesSelectionInfo, parents);
	}

	public void ClearFacesSelection(Stack<BlockReference> parents = null)
	{
		int num = SelectedItemBase._0023_003DzAdoyA7k_003D(new SelectionInfoSubItems(parents, this), FacesSelectionInfo);
		if (num >= 0)
		{
			FacesSelectionInfo.RemoveAt(num);
		}
	}

	public void ClearFacesSelectionForAllInstances()
	{
		FacesSelectionInfo.Clear();
	}

	internal override bool IsSelected(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		switch (SelectionMode)
		{
		case selectionFilterType.Entity:
			return base.IsSelected(_0023_003Dzq5nwX2I_003D, _0023_003DzLEq8mIc_003D);
		case selectionFilterType.Face:
		{
			if (FacesSelectionInfo.Count > 0 && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, FacesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH))
			{
				return SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH.SubItems, _0023_003DzLEq8mIc_003D);
			}
			break;
		}
		}
		return false;
	}

	public void ResetSelectionMode()
	{
		if (!IsAnyFaceSelected())
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	internal override void ClearSelectionFaces(selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(_0023_003DzCYtX6jC7ppkE, this, FacesSelectionInfo);
		if (_0023_003DzCYtX6jC7ppkE == selectionStatusType.Permanent)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	[Obsolete("Use SetFaceSelection()")]
	public void SelectFace(int faceIndex, bool selectionState, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, faceIndex, selectionState, this, Faces, FacesSelectionInfo, parents);
	}

	internal override List<SelectedSubItem> ClearSelectionFaces(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		return Mesh._0023_003DzGU9q9iKyIDN73whuiw_003D_003D(_0023_003Dzq5nwX2I_003D, this, FacesSelectionInfo, _0023_003DzCYtX6jC7ppkE, (Faces != null) ? Faces.Count : 0);
	}

	public List<int> GetFaceTriangles(int triangleIndex, double adjacentNormalAngle)
	{
		return meshForFaceSelection.GetFaceTriangles(triangleIndex, adjacentNormalAngle);
	}

	protected internal override bool SelectedInternal()
	{
		return SelectionMode != selectionFilterType.Entity;
	}

	protected internal override void DrawForSelectionFaces(DrawForSelectionParams data)
	{
		if (meshForFaceSelection == null)
		{
			meshForFaceSelection = new Mesh(Portions[0]._meshNature)
			{
				Vertices = new Point3D[0],
				Triangles = new IndexTriangle[0]
			};
			for (int i = 0; i < Portions.Count; i++)
			{
				meshForFaceSelection.MergeWith(Portions[i], weldNow: false);
			}
			meshForFaceSelection.Weld();
			meshForFaceSelection.UpdateNormals();
		}
		meshForFaceSelection.DrawForSelectionFaces(data);
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		ComputeBoundingBox(null, out boxMin, out boxMax);
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (drawIsocurve == null)
		{
			drawIsocurve = renderContext.CreateEntityGraphicsData(this);
		}
	}

	protected override bool EvaluateIntersectEdges(FrustumParams data)
	{
		return data.DisplayMode == displayType.Wireframe;
	}

	protected override bool EvaluateIntersectTriangles(FrustumParams data)
	{
		return data.DisplayMode != displayType.Wireframe;
	}

	internal override bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
	{
		if (!EvaluateIntersectEdges(_0023_003DzELu0Pss_003D))
		{
			return false;
		}
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].IntersectEdgeOrIsoline(_0023_003DzELu0Pss_003D))
			{
				AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
				return true;
			}
		}
		return false;
	}

	internal override bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		if (!EvaluateIntersectEdges(_0023_003DzELu0Pss_003D))
		{
			return false;
		}
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].IntersectEdgeOrIsolineScreenPolygon(_0023_003DzELu0Pss_003D))
			{
				AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
				return true;
			}
		}
		return false;
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003DzBv5MGLg_003D();
		for (int i = 0; i < portions.Count; i++)
		{
			portions[i].Compile(data);
		}
		_0023_003DzMfE8qMRQmewluOZmeA_003D_003D(data);
		meshForFaceSelection = null;
		regenMode = regenType.NotNeeded;
	}

	private void _0023_003DzMfE8qMRQmewluOZmeA_003D_003D(CompileParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzELu0Pss_003D.RenderContext.Compile(drawIsocurve, _0023_003DzjuehFingRpb3Mk_6aPEthw87uUIVQkqDNg_003D_003D, null);
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		if (Mesh._0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			Mesh._0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
			return;
		}
		for (int i = 0; i < portions.Count; i++)
		{
			Portion portion = portions[i];
			if (ColorMethod == colorMethodType.byEntity && UseInnerColors)
			{
				data.RenderContext.SetColorWireframe(portion.Color);
			}
			portion.DrawFlat(data);
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		IViewportInternal viewportInternal = data.viewportInternal;
		for (int i = 0; i < portions.Count; i++)
		{
			Portion portion = portions[i];
			if (ColorMethod == colorMethodType.byEntity && UseInnerColors)
			{
				data.RenderContext.SetColorShadedInternal(base.entityNature, portion.Color, base.Selected, viewportInternal.parent.Backface);
			}
			portion.Draw(data);
		}
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		if (data.Selected)
		{
			DrawSelected(data);
		}
		else
		{
			base.DrawHiddenLines(data);
		}
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		if (Mesh._0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			Mesh._0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
		}
		else
		{
			_0023_003DzXpDbwQkKXyuT(data);
		}
	}

	public void CompileSelectedFace(RenderContextBase renderContext, Mesh.FaceElement faceData)
	{
		if (faceData._0023_003Dzgv_pSOc_003D == null)
		{
			faceData._0023_003Dzgv_pSOc_003D = renderContext.CreateEntityGraphicsData(faceData);
		}
		renderContext.Compile(faceData._0023_003Dzgv_pSOc_003D, DrawFace, faceData.Triangles);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DrawFace(RenderContextBase renderContext, object data)
	{
		List<int> list = (List<int>)data;
		if (list.Count == 0)
		{
			return;
		}
		Point3D[] array = new Point3D[list.Count * 3];
		Vector3D[] array2 = new Vector3D[array.Length];
		if (meshForFaceSelection.Triangles[0] is ITriangleSupportsNormals)
		{
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				int num2 = list[i];
				Portion portion = null;
				for (int j = 0; j < Portions.Count; j++)
				{
					portion = Portions[j];
					if (num2 < portion.Triangles.Length)
					{
						break;
					}
					num2 -= portion.Triangles.Length;
				}
				IndexTriangle indexTriangle = portion.Triangles[num2];
				Point3D[] vertices = portion.Vertices;
				array[num] = vertices[indexTriangle.V1];
				array[num + 1] = vertices[indexTriangle.V2];
				array[num + 2] = vertices[indexTriangle.V3];
				ITriangleSupportsNormals triangleSupportsNormals = (ITriangleSupportsNormals)indexTriangle;
				array2[num++] = portion.Normals[triangleSupportsNormals.N1];
				array2[num++] = portion.Normals[triangleSupportsNormals.N2];
				array2[num++] = portion.Normals[triangleSupportsNormals.N3];
			}
		}
		else
		{
			int num3 = 0;
			for (int k = 0; k < list.Count; k++)
			{
				int num4 = list[k];
				Portion portion2 = null;
				for (int l = 0; l < Portions.Count; l++)
				{
					portion2 = Portions[l];
					if (num4 < portion2.Triangles.Length)
					{
						break;
					}
					num4 -= portion2.Triangles.Length;
				}
				IndexTriangle indexTriangle2 = portion2.Triangles[num4];
				array[num3] = Vertices[indexTriangle2.V1];
				array[num3 + 1] = Vertices[indexTriangle2.V2];
				array[num3 + 2] = Vertices[indexTriangle2.V3];
				array2[num3++] = portion2.Normals[num4];
				array2[num3++] = portion2.Normals[num4];
				array2[num3++] = portion2.Normals[num4];
			}
		}
		renderContext.DrawTriangles(array, array2);
	}

	private Vector3D[] _0023_003Dza5J1X7tYUFs8abQmHhym9u_0024PX6n3(int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D)
	{
		for (int i = 0; i < Portions.Count; i++)
		{
			Portion portion = Portions[i];
			if (_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D >= portion.Triangles.Length)
			{
				_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D -= portion.Triangles.Length;
				continue;
			}
			ITriangleSupportsNormals triangleSupportsNormals = (ITriangleSupportsNormals)portion.Triangles[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D];
			return new Vector3D[3]
			{
				portion.Normals[triangleSupportsNormals.N1],
				portion.Normals[triangleSupportsNormals.N2],
				portion.Normals[triangleSupportsNormals.N3]
			};
		}
		return null;
	}

	private Vector3D _0023_003DzgA0CS2soxXMXOmHZ5W4wnJA_003D(int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D)
	{
		for (int i = 0; i < Portions.Count; i++)
		{
			Portion portion = Portions[i];
			if (_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D >= portion.Triangles.Length)
			{
				_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D -= portion.Triangles.Length;
				continue;
			}
			return portion.Normals[_0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D];
		}
		return null;
	}

	private void _0023_003DzXpDbwQkKXyuT(DrawParams _0023_003DzELu0Pss_003D)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			portions[i].Draw(_0023_003DzELu0Pss_003D);
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			portions[i].DrawForSelection(data);
		}
	}

	protected internal override void DrawForSelectionWireframe(DrawForSelectionParams data)
	{
		DrawWireframe(data);
		DrawIsocurves(data);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			portions[i].DrawForShadow(data);
		}
	}

	public void ApplyMaterial(string matName, textureMappingType mappingMode, double scaleX, double scaleY)
	{
		ApplyMaterial(matName, mappingMode, scaleX, scaleY, localMin, localMax);
	}

	public void ApplyMaterial(string matName, textureMappingType mappingMode, double scaleX, double scaleY, Point3D boxMin, Point3D boxMax)
	{
		MaterialName = matName;
		if (RegenMode == regenType.RegenAndCompile)
		{
			Regen(1E-12);
			RegenMode = regenType.CompileOnly;
		}
		ColorMethod = colorMethodType.byEntity;
		_0023_003DzVx8fW68EDLgG(new TextureMappingData(mappingMode, scaleX, scaleY, (Point3D)boxMin.Clone(), (Point3D)boxMax.Clone()));
	}

	public void ApplyTextureMapping(textureMappingType mappingMode, double scaleX, double scaleY)
	{
		ApplyTextureMapping(mappingMode, scaleX, scaleY, localMin, localMax);
	}

	public void ApplyTextureMapping(textureMappingType mappingMode, double scaleX, double scaleY, Point3D boxMin, Point3D boxMax)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			Regen(1E-12);
			RegenMode = regenType.CompileOnly;
		}
		_0023_003DzVx8fW68EDLgG(new TextureMappingData(mappingMode, scaleX, scaleY, (Point3D)boxMin.Clone(), (Point3D)boxMax.Clone()));
	}

	private void _0023_003DzVx8fW68EDLgG(TextureMappingData _0023_003DzCS02Bu0_003D)
	{
		textureMapping = _0023_003DzCS02Bu0_003D;
		for (int i = 0; i < portions.Count; i++)
		{
			portions[i].ApplyTextureMapping(textureMapping);
		}
		base.entityNature = entityNatureType.RichPolygon;
		if (RegenMode == regenType.NotNeeded)
		{
			RegenMode = regenType.CompileOnly;
		}
	}

	public void RemoveTextureMapping()
	{
		if (textureMapping != null)
		{
			textureMapping = null;
			for (int i = 0; i < portions.Count; i++)
			{
				portions[i].RemoveTextureMapping();
			}
			Regen(1E-12);
			RegenMode = regenType.CompileOnly;
		}
	}

	public void RemoveMaterial()
	{
		MaterialName = null;
		RemoveTextureMapping();
	}

	protected internal override void SetLineWeightForSilhouettes(DrawSilhouettesParams data)
	{
		float num = data.SilhoThickness;
		if (data.Selected && !FlagsHelper.IsSet(SelectionMode, selectionFilterType.Face))
		{
			num *= data.SelectionLineWeightScaleFactor;
		}
		_0023_003Dzw7EU_3iuNJBd(data, num);
	}

	protected internal override void SetLineWeightForEdges(DrawParams data)
	{
		float num = data.EdgeThickness;
		if (data.Selected && !FlagsHelper.IsSet(SelectionMode, selectionFilterType.Face))
		{
			num *= data.SelectionLineWeightScaleFactor;
		}
		_0023_003Dzw7EU_3iuNJBd(data, num);
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (!Mesh._0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(data, SelectionMode))
		{
			for (int i = 0; i < portions.Count; i++)
			{
				portions[i].DrawEdges(data);
			}
		}
	}

	protected internal override void Render(RenderParams data)
	{
		if (Mesh._0023_003DzxsZqpH64pLwL(data, SelectionMode))
		{
			Mesh._0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, this, Faces, FacesSelectionInfo, _0023_003DzXpDbwQkKXyuT);
			return;
		}
		IViewportInternal viewportInternal = data.viewportInternal;
		for (int i = 0; i < portions.Count; i++)
		{
			Portion portion = portions[i];
			if (ColorMethod == colorMethodType.byEntity && UseInnerColors)
			{
				if (string.IsNullOrEmpty(portion.MaterialName))
				{
					data.RenderContext.SetColorDiffuse(portion.Color, RenderContextBase._0023_003DzG_0024lkZE0vy9Tc(portion.Color, viewportInternal.parent.Backface, base.Selected));
				}
				else
				{
					data.RenderContext.SetColorRenderedInternal(portion.entityNature, data.materials[portion.MaterialName], _0023_003DzNGLWIVQ_003D: false, data);
					portion.SetShader(data);
				}
			}
			portion.Render(data);
		}
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		for (int i = 0; i < portions.Count; i++)
		{
			portions[i]._0023_003DzUvUzTv6XO92zTU6hSQ_003D_003D(data, normalLength);
		}
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		DrawEdges(data);
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		if (!Mesh._0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(data, SelectionMode))
		{
			data.RenderContext.Draw(drawIsocurve);
		}
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		if (!Mesh._0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(data, SelectionMode))
		{
			HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, data);
		}
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		boxMin = Point3D.MaxValue;
		boxMax = Point3D.MinValue;
		bool flag = data == null || data.Transformation == null || data.Transformation.IsIdentity();
		for (int i = 0; i < portions.Count; i++)
		{
			Portion portion = portions[i];
			portion.ComputeBoundingBox(data, out var boxMin2, out var boxMax2);
			if (flag)
			{
				portion.localMin = boxMin2;
				portion.localMax = boxMax2;
			}
			if (i == 0)
			{
				Utility.InitializeMinMax(boxMin2, out boxMin, out boxMax);
				Utility.UpdateMinMaxQuick(boxMax2, boxMin, boxMax);
			}
			else
			{
				Utility.UpdateMinMaxQuick(boxMin2, boxMin, boxMax);
				Utility.UpdateMinMaxQuick(boxMax2, boxMin, boxMax);
			}
		}
		return true;
	}

	internal override bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		_0023_003DzHhJEwwk_003D = 1;
		Point2D[] array = new Point3D[0];
		_0023_003DzrdSL0CI_003D = array;
		_0023_003DzD5Gs7jmmc9uK = false;
		if (portions != null)
		{
			List<Point3D> list = new List<Point3D>();
			for (int i = 0; i < portions.Count; i++)
			{
				if (portions[i].Vertices != null)
				{
					list.AddRange(portions[i].Vertices);
				}
			}
			array = list.ToArray();
			_0023_003DzrdSL0CI_003D = array;
		}
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			return true;
		}
		if (_0023_003DzrdSL0CI_003D.Length != 0)
		{
			_localOB = new OrientedBoundingBox(_0023_003DzrdSL0CI_003D);
			_0023_003DzD5Gs7jmmc9uK = true;
			return true;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968689));
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		foreach (Portion portion in Portions)
		{
			portion.ComputeOffsetOnCameraAxes(data);
		}
	}

	protected internal override void DrawOnScreen(DrawOnScreenParams drawOnScreenParams)
	{
		for (int i = 0; i < Portions.Count; i++)
		{
			Portions[i].DrawOnScreen(drawOnScreenParams, Portions[i].VertexCount);
		}
	}

	protected internal override void DrawOnScreenWireframe(DrawOnScreenWireframeParams myParams)
	{
		for (int i = 0; i < Portions.Count; i++)
		{
			Portions[i].DrawOnScreenWireframe(myParams, Portions[i].VertexCount);
		}
	}

	private void _0023_003DzjuehFingRpb3Mk_6aPEthw87uUIVQkqDNg_003D_003D(RenderContextBase _0023_003DzQdnFby4_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		for (int i = 0; i < portions.Count; i++)
		{
			if (portions[i].isoCurves.Count > 0)
			{
				_0023_003DzQdnFby4_003D.DrawIndexLines(portions[i].isoCurves, portions[i]._vertices);
			}
		}
	}
}
