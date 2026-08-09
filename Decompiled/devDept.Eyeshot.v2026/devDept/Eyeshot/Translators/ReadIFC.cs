using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.IO;
using Xbim.Ifc;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.GeometricModelResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadIFC : ReadFileAsync
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<devDept.Eyeshot.Entities.Region, Tuple<devDept.Eyeshot.Entities.Region, double[]>> _0023_003DzsW0uNWm4_0024_6PMNLiCQ_003D_003D;

		internal Tuple<devDept.Eyeshot.Entities.Region, double[]> _0023_003Dz7Y8e2Iq5yq7qjYEC6iVifwewGuV6yxkgV0rpUgk_003D(devDept.Eyeshot.Entities.Region _0023_003DzRpXgovo_003D)
		{
			_0023_003DzRpXgovo_003D.Regen(0.001);
			Point2D point2D = _0023_003DzRpXgovo_003D.Plane.Project(_0023_003DzRpXgovo_003D.BoxMin);
			Point2D point2D2 = _0023_003DzRpXgovo_003D.Plane.Project(_0023_003DzRpXgovo_003D.BoxMax);
			return new Tuple<devDept.Eyeshot.Entities.Region, double[]>(_0023_003DzRpXgovo_003D, new double[4] { point2D.X, point2D.Y, point2D2.X, point2D2.Y });
		}
	}

	private sealed class _0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D
	{
		public ReadIFC _0023_003DzopRx0_MBcTQs;

		public Dictionary<int, (int, Brep.Edge)> _0023_003DzU3hosSAzkxO7;

		public int _0023_003Dzp5tEBWE_003D;

		public Dictionary<int, (int, Point3D)> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;

		public Func<IIfcOrientedEdge, Brep.OrientedEdge> _0023_003DzkqbsCVPMJ_0024g6;

		internal Brep.OrientedEdge _0023_003DzUGjUYbMTecpisDx_7xp589r5j_vdgeAC_A_003D_003D(IIfcOrientedEdge _0023_003Dz0kpOgcNotSHdBpfYtK5RuC0_003D)
		{
			return new Brep.OrientedEdge(_0023_003DzopRx0_MBcTQs._0023_003DzAVw6u5Y_003D(_0023_003Dz0kpOgcNotSHdBpfYtK5RuC0_003D.EdgeElement, _0023_003DzU3hosSAzkxO7, ref _0023_003Dzp5tEBWE_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D).Item1, _0023_003Dz0kpOgcNotSHdBpfYtK5RuC0_003D.Orientation);
		}
	}

	private sealed class _0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D
	{
		public IIfcBSplineSurfaceWithKnots _0023_003DzufKfca1jyE6LOmWG6g_003D_003D;

		internal IEnumerable<double> _0023_003DzYF0NZ8Bb_0024k7xjjq7_CqSu80jSmWUEke5IJscmZk_003D(double _0023_003DzbfrNXYE_003D, int _0023_003Dz437_00244ak_003D)
		{
			return Enumerable.Repeat(_0023_003DzbfrNXYE_003D, (int)(long)_0023_003DzufKfca1jyE6LOmWG6g_003D_003D.UMultiplicities[_0023_003Dz437_00244ak_003D]);
		}

		internal IEnumerable<double> _0023_003DzgFq5MinbwAL4b9f802NLpbZzuY5JXEBc2dhkJpg_003D(double _0023_003DzbfrNXYE_003D, int _0023_003Dz437_00244ak_003D)
		{
			return Enumerable.Repeat(_0023_003DzbfrNXYE_003D, (int)(long)_0023_003DzufKfca1jyE6LOmWG6g_003D_003D.VMultiplicities[_0023_003Dz437_00244ak_003D]);
		}

		internal Point4D[] _0023_003DzAKoM7qDTGDzwsU9xwQl3hsZBi1_00243JlHNMLnRS2U_003D(IItemSet<IIfcCartesianPoint> _0023_003DzGcl_0024E9o_003D, int _0023_003Dz437_00244ak_003D)
		{
			_0023_003DzzkPoxwb_0024Xqj0ZHNaKIf8FuY_003D CS_0024_003C_003E8__locals4 = new _0023_003DzzkPoxwb_0024Xqj0ZHNaKIf8FuY_003D();
			CS_0024_003C_003E8__locals4._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D = this;
			CS_0024_003C_003E8__locals4._0023_003Dz437_00244ak_003D = _0023_003Dz437_00244ak_003D;
			return _0023_003DzGcl_0024E9o_003D.Select((IIfcCartesianPoint _0023_003DzBJFJHwk_003D, int _0023_003DzTSeNR8Q_003D) => new Point4D(_0023_003DzBJFJHwk_003D.X, _0023_003DzBJFJHwk_003D.Y, _0023_003DzBJFJHwk_003D.Z, (CS_0024_003C_003E8__locals4._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzufKfca1jyE6LOmWG6g_003D_003D is IIfcRationalBSplineSurfaceWithKnots ifcRationalBSplineSurfaceWithKnots) ? ifcRationalBSplineSurfaceWithKnots.WeightsData[CS_0024_003C_003E8__locals4._0023_003Dz437_00244ak_003D][_0023_003DzTSeNR8Q_003D] : ((Xbim.Ifc4.MeasureResource.IfcReal)1.0))).ToArray();
		}
	}

	private enum _0023_003DzZKByqt9RvKDq
	{

	}

	internal sealed class _0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D : PlanarEntity, ICurve, ICloneable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003DzhJ0Kgk4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interval _0023_003DznB2g_0024pk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzQaWEWP8UInciG_0024Z3oQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003DzW_0024nkGD2TctPJXNnkG68UQU0_003D;

		public Interval Domain => _0023_003DznB2g_0024pk_003D;

		public Point3D EndPoint => PointAt(Domain.High);

		public Point3D StartPoint => PointAt(Domain.Low);

		public bool IsClosed => false;

		public bool IsPoint => Domain.Length <= 1E-12;

		public Vector3D StartTangent => TangentAt(Domain.Low);

		public Vector3D EndTangent => TangentAt(Domain.High);

		public int EdgeIndex
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzQaWEWP8UInciG_0024Z3oQ_003D_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzQaWEWP8UInciG_0024Z3oQ_003D_003D = value;
			}
		}

		public bool FromBooleanIntersection
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzW_0024nkGD2TctPJXNnkG68UQU0_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzW_0024nkGD2TctPJXNnkG68UQU0_003D = value;
			}
		}

		public _0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003Dzvnro79w_003D)
			: base(_0023_003Dzrgqz890sj_0024X9)
		{
			_0023_003DzscFQcNw_003D(_0023_003Dzvnro79w_003D);
			_0023_003DzIumdvTEyzj98(new Interval(double.NegativeInfinity, double.PositiveInfinity));
		}

		protected _0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D(_0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D _0023_003DzySgeilxprQOK)
			: base(_0023_003DzySgeilxprQOK)
		{
			_0023_003DzscFQcNw_003D(_0023_003DzySgeilxprQOK._0023_003DzyyvtvnY_003D());
			_0023_003DzIumdvTEyzj98(_0023_003DzySgeilxprQOK.Domain);
		}

		public double _0023_003DzyyvtvnY_003D()
		{
			return _0023_003DzhJ0Kgk4_003D;
		}

		public void _0023_003DzscFQcNw_003D(double _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzhJ0Kgk4_003D = _0023_003DzPzO_0024GUk_003D;
			RegenMode = regenType.RegenAndCompile;
		}

		public void _0023_003DzIumdvTEyzj98(Interval _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DznB2g_0024pk_003D = _0023_003DzPzO_0024GUk_003D;
			RegenMode = regenType.RegenAndCompile;
		}

		public override object Clone()
		{
			return new _0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D(this);
		}

		public override void Regen(RegenParams _0023_003DzELu0Pss_003D)
		{
			double num = Length();
			int num2 = ((num == double.PositiveInfinity) ? 500 : ((int)(num / 10.0)));
			Vertices = new Point3D[num2 + 1];
			double num3 = Domain.Left;
			double num4 = Domain.Right;
			if (num3 == double.NegativeInfinity)
			{
				num3 = -10.0;
			}
			if (num4 == double.PositiveInfinity)
			{
				num4 = 10.0;
			}
			for (int i = 0; i < num2 + 1; i++)
			{
				double _0023_003DzNDQ_E88_003D = num3 + (double)i * (num4 - num3) / (double)num2;
				Vertices[i] = PointAt(_0023_003DzNDQ_E88_003D);
			}
			UpdateBoundingBox(_0023_003DzELu0Pss_003D);
			RegenMode = regenType.CompileOnly;
		}

		public override void Compile(CompileParams _0023_003DzELu0Pss_003D)
		{
			InitGraphicsData(_0023_003DzELu0Pss_003D.RenderContext);
			CompileWire(_0023_003DzELu0Pss_003D);
			RegenMode = regenType.NotNeeded;
		}

		protected internal override void Draw(DrawParams _0023_003DzELu0Pss_003D)
		{
			DrawWire(_0023_003DzELu0Pss_003D);
		}

		protected internal override void DrawForSelection(DrawForSelectionParams _0023_003DzELu0Pss_003D)
		{
			Draw(_0023_003DzELu0Pss_003D);
		}

		protected internal override void DrawDirection(DrawParams _0023_003DzELu0Pss_003D)
		{
			if (Domain.High == double.PositiveInfinity)
			{
				Utility.DrawArrowOnView(_0023_003DzELu0Pss_003D, TangentAt(0.0), PointAt(0.0));
			}
			else
			{
				Utility.DrawArrowOnView(_0023_003DzELu0Pss_003D, EndTangent, EndPoint);
			}
		}

		public double Length()
		{
			if (double.IsInfinity(Domain.Low) || double.IsInfinity(Domain.High))
			{
				return double.PositiveInfinity;
			}
			GetLengthFromParam(Domain.Low, out var _0023_003Dz736ekIs_003D);
			GetLengthFromParam(Domain.High, out var _0023_003Dz736ekIs_003D2);
			if (!(Domain.Low * Domain.High < 0.0))
			{
				return Math.Abs(_0023_003Dz736ekIs_003D - _0023_003Dz736ekIs_003D2);
			}
			return _0023_003Dz736ekIs_003D + _0023_003Dz736ekIs_003D2;
		}

		public void Reverse()
		{
			Vector3D axisY = base.Plane.AxisY;
			axisY.Negate();
			base.Plane = new Plane(base.Plane.Origin, base.Plane.AxisX, axisY);
			_0023_003DzscFQcNw_003D(0.0 - _0023_003DzyyvtvnY_003D());
			RegenMode = regenType.RegenAndCompile;
		}

		public bool SubCurve(double _0023_003Dzn0aVmvZLboNe, double _0023_003Dz7TKSLXO92c0A, out ICurve _0023_003DzPCgfXmU_003D)
		{
			_0023_003DzPCgfXmU_003D = (_0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D)Clone();
			((_0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D)_0023_003DzPCgfXmU_003D)._0023_003DzIumdvTEyzj98(new Interval(_0023_003Dzn0aVmvZLboNe, _0023_003Dz7TKSLXO92c0A));
			return true;
		}

		public bool SubCurve(Point3D _0023_003DzstAn7cw2vRC7, Point3D _0023_003DzA5kmIQrPan7q, out ICurve _0023_003DzPCgfXmU_003D)
		{
			throw new NotImplementedException();
		}

		public bool SplitAt(double _0023_003DzNDQ_E88_003D, out ICurve _0023_003Dz6V_0024QadA_003D, out ICurve _0023_003DzCskoEKg_003D)
		{
			throw new NotImplementedException();
		}

		public bool SplitBy(Point3D _0023_003DzMlCq3wk_003D, out ICurve _0023_003Dz6V_0024QadA_003D, out ICurve _0023_003DzCskoEKg_003D)
		{
			throw new NotImplementedException();
		}

		public bool SplitBy(IList<Point3D> _0023_003DzrdSL0CI_003D, out ICurve[] _0023_003DzKTAIrow_003D)
		{
			throw new NotImplementedException();
		}

		public bool TrimAt(double _0023_003DzNDQ_E88_003D, bool _0023_003DzaFEehOi8mwIq)
		{
			throw new NotImplementedException();
		}

		public bool TrimBy(Point3D _0023_003DzMlCq3wk_003D, bool _0023_003DzaFEehOi8mwIq)
		{
			throw new NotImplementedException();
		}

		public bool ExtendAt(double _0023_003DzNDQ_E88_003D)
		{
			throw new NotImplementedException();
		}

		public bool ExtendBy(Point3D _0023_003DzMlCq3wk_003D, bool _0023_003DzEzNDn4VgDhuo = true)
		{
			throw new NotImplementedException();
		}

		public bool GetParamFromLength(double _0023_003Dz736ekIs_003D, out double _0023_003DzNDQ_E88_003D)
		{
			_0023_003DzNDQ_E88_003D = _0023_003Dz736ekIs_003D / (_0023_003DzyyvtvnY_003D() * Math.Sqrt(Utility._0023_003DzSNemwQo_003D));
			return true;
		}

		public bool GetParamFromLength(double _0023_003Dz736ekIs_003D, double _0023_003DzaUF77KfxjxOo, out double _0023_003DzNDQ_E88_003D)
		{
			return GetParamFromLength(_0023_003Dz736ekIs_003D, out _0023_003DzNDQ_E88_003D);
		}

		public bool GetLengthFromParam(double _0023_003DzNDQ_E88_003D, out double _0023_003Dz736ekIs_003D)
		{
			_0023_003Dz736ekIs_003D = Math.Abs(_0023_003DzyyvtvnY_003D() * _0023_003DzNDQ_E88_003D * Math.Sqrt(Utility._0023_003DzSNemwQo_003D));
			return true;
		}

		public Point3D[] IntersectWith(ICurve _0023_003Dzn8t0_00249E_003D, double _0023_003DzX0qX_IwWxysi = 0.0, bool _0023_003Dzr9Kx_zv09bH0 = true)
		{
			throw new NotImplementedException();
		}

		public void ClosestPointTo(Point3D _0023_003DzlY77YgY_003D, out double _0023_003DzNDQ_E88_003D)
		{
			throw new NotImplementedException();
		}

		public bool Project(Point3D _0023_003DzlY77YgY_003D, out double _0023_003DzNDQ_E88_003D)
		{
			throw new NotImplementedException();
		}

		public ICurve[] GetIndividualCurves()
		{
			throw new NotImplementedException();
		}

		public bool IsPlanar(double _0023_003Dzm0CYiiE_003D, out Plane _0023_003Dzrgqz890sj_0024X9)
		{
			_0023_003Dzrgqz890sj_0024X9 = (Plane)base.Plane.Clone();
			return true;
		}

		public bool IsInPlane(Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003Dzm0CYiiE_003D)
		{
			throw new NotImplementedException();
		}

		public bool IsLinear(double _0023_003Dzm0CYiiE_003D, out Segment3D _0023_003DzQ9zpGF0_003D)
		{
			_0023_003DzQ9zpGF0_003D = null;
			return false;
		}

		public Point3D PointAt(double _0023_003DzNDQ_E88_003D)
		{
			Func<double, double> _0023_003DzhidJeNw_003D = _0023_003DzC1ufabgPaCgrnb04XWmY2KI_003D;
			Func<double, double> _0023_003DzhidJeNw_003D2 = _0023_003DzUpI2DQvbP4DpM15jDerLVC4_003D;
			double num = Utility._0023_003Dz8s608KleYwNYvOtWkA_003D_003D(_0023_003DzhidJeNw_003D, 0.0, _0023_003DzNDQ_E88_003D, 1E-12);
			double num2 = Utility._0023_003Dz8s608KleYwNYvOtWkA_003D_003D(_0023_003DzhidJeNw_003D2, 0.0, _0023_003DzNDQ_E88_003D, 1E-12);
			return base.Plane.Origin + _0023_003DzyyvtvnY_003D() * Math.Sqrt(Math.PI) * (num * base.Plane.AxisX + num2 * base.Plane.AxisY);
		}

		public Vector3D _0023_003DzdFU9wBOMSWBbJonbBP8KBQ0_003D(double _0023_003DzNDQ_E88_003D)
		{
			Func<double, double> func = _0023_003Dz1wqgit4FuM1HcyIZDNolGplSaNYJpAIqQQ_003D_003D;
			Func<double, double> func2 = _0023_003Dzffri3Md9FbcW3dUr8udKZ4usjXogU1dtCg_003D_003D;
			return _0023_003DzyyvtvnY_003D() * Math.Sqrt(Math.PI) * (func(_0023_003DzNDQ_E88_003D) * base.Plane.AxisX + func2(_0023_003DzNDQ_E88_003D) * base.Plane.AxisY);
		}

		public Vector3D TangentAt(double _0023_003DzNDQ_E88_003D)
		{
			Vector3D vector3D = _0023_003DzdFU9wBOMSWBbJonbBP8KBQ0_003D(_0023_003DzNDQ_E88_003D);
			if (!vector3D.Normalize())
			{
				return null;
			}
			return vector3D;
		}

		public Vector3D NormalAt(double _0023_003DzNDQ_E88_003D)
		{
			throw new NotImplementedException();
		}

		public ICurve[] Offset(double _0023_003DzYNjcavt9guh2, Vector3D _0023_003Dz2ouPUQ9dmipO, bool _0023_003DzalFofRO0Igsv = false)
		{
			throw new NotImplementedException();
		}

		public devDept.Eyeshot.Entities.Region OffsetToRegion(double _0023_003DzYNjcavt9guh2, bool _0023_003DzalFofRO0Igsv)
		{
			throw new NotImplementedException();
		}

		public Point3D[] GetPointsByLength(double _0023_003Dz736ekIs_003D)
		{
			throw new NotImplementedException();
		}

		public Point3D[] GetPointsByLengthPerSegment(double _0023_003Dz736ekIs_003D)
		{
			throw new NotImplementedException();
		}

		public void GetTightBBox(out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
		{
			throw new NotImplementedException();
		}

		public void GetApproximatedBoundingBox(out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
		{
			throw new NotImplementedException();
		}

		public LinearPath ConvertToLinearPath(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D)
		{
			throw new NotImplementedException();
		}

		public Mesh ExtrudeAsMesh(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Mesh ExtrudeAsMesh(double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzLpcnctI_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
			throw new NotImplementedException();
		}

		public T ExtrudeAsMesh<T>(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
		{
			throw new NotImplementedException();
		}

		public T ExtrudeAsMesh<T>(double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzLpcnctI_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
		{
			throw new NotImplementedException();
		}

		public Mesh RevolveAsMesh(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Point3D _0023_003Dz_0024VVTRic_003D, Point3D _0023_003DzwLzFYgk_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Mesh RevolveAsMesh(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
			throw new NotImplementedException();
		}

		public T RevolveAsMesh<T>(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Point3D _0023_003Dz_0024VVTRic_003D, Point3D _0023_003DzwLzFYgk_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
		{
			throw new NotImplementedException();
		}

		public T RevolveAsMesh<T>(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D) where T : Mesh, new()
		{
			throw new NotImplementedException();
		}

		public Mesh SweepAsMesh(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D = sweepMethodType.RotationMinimizingFrames, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D = Mesh.natureType.Smooth)
		{
			throw new NotImplementedException();
		}

		public T SweepAsMesh<T>(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D = sweepMethodType.RotationMinimizingFrames, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D = Mesh.natureType.Smooth) where T : Mesh, new()
		{
			throw new NotImplementedException();
		}

		public Mesh[] SweepAsMesh(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D = sweepMethodType.RotationMinimizingFrames, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D = Mesh.natureType.Smooth)
		{
			throw new NotImplementedException();
		}

		public T[] SweepAsMesh<T>(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D = sweepMethodType.RotationMinimizingFrames, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D = Mesh.natureType.Smooth) where T : Mesh, new()
		{
			throw new NotImplementedException();
		}

		public Curve GetNurbsForm()
		{
			throw new NotImplementedException();
		}

		public Surface[] ExtrudeAsSurface(Line _0023_003DzQ9zpGF0_003D)
		{
			throw new NotImplementedException();
		}

		public Surface[] ExtrudeAsSurface(double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzLpcnctI_003D)
		{
			throw new NotImplementedException();
		}

		public Surface[] ExtrudeAsSurface(Vector3D _0023_003DzYNjcavt9guh2)
		{
			throw new NotImplementedException();
		}

		public Surface[] ExtrudeAsSurface(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003Dz_0024aVYvhy3eQHaT_cO8_0024kF4Yo_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Brep ExtrudeAsBrep(Line _0023_003DzQ9zpGF0_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Brep ExtrudeAsBrep(double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzLpcnctI_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Brep ExtrudeAsBrep(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003Dz_0024aVYvhy3eQHaT_cO8_0024kF4Yo_003D = 0.0, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Surface[] RevolveAsSurface(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
		{
			throw new NotImplementedException();
		}

		public Surface[] RevolveAsSurface(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Point3D _0023_003Dz_0024VVTRic_003D, Point3D _0023_003DzwLzFYgk_003D)
		{
			throw new NotImplementedException();
		}

		public Surface[] RevolveAsSurface(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Line _0023_003DzxuJqjrs_003D)
		{
			throw new NotImplementedException();
		}

		public Brep RevolveAsBrep(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Brep RevolveAsBrep(Interval _0023_003DzJh6qrM9vQQk7, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Brep RevolveAsBrep(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Point3D _0023_003Dz_0024VVTRic_003D, Point3D _0023_003DzwLzFYgk_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Brep RevolveAsBrep(Interval _0023_003DzJh6qrM9vQQk7, Point3D _0023_003Dz_0024VVTRic_003D, Point3D _0023_003DzwLzFYgk_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Brep RevolveAsBrep(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Line _0023_003DzxuJqjrs_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Brep RevolveAsBrep(Interval _0023_003DzJh6qrM9vQQk7, Line _0023_003DzxuJqjrs_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.0)
		{
			throw new NotImplementedException();
		}

		public Surface[] SweepAsSurface(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D = sweepMethodType.RotationMinimizingFrames)
		{
			throw new NotImplementedException();
		}

		public Brep SweepAsBrep(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D = sweepMethodType.RotationMinimizingFrames)
		{
			throw new NotImplementedException();
		}

		public Brep[] SweepAsBrep(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D = sweepMethodType.RotationMinimizingFrames)
		{
			throw new NotImplementedException();
		}

		public Solid ExtrudeAsSolid(Vector3D _0023_003DzYNjcavt9guh2, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Solid ExtrudeAsSolid(double _0023_003DzaQ_y9PQ_003D, double _0023_003DzD47R4_0_003D, double _0023_003DzLpcnctI_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Solid RevolveAsSolid(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Solid RevolveAsSolid(Interval _0023_003DzJh6qrM9vQQk7, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Solid RevolveAsSolid(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Point3D _0023_003Dz_0024VVTRic_003D, Point3D _0023_003DzwLzFYgk_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Solid RevolveAsSolid(Interval _0023_003DzJh6qrM9vQQk7, Point3D _0023_003Dz_0024VVTRic_003D, Point3D _0023_003DzwLzFYgk_003D, int _0023_003DzAPBIJmvn5i5Q, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			throw new NotImplementedException();
		}

		public Solid SweepAsSolid(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL)
		{
			throw new NotImplementedException();
		}

		public Solid[] SweepAsSolid(ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL)
		{
			throw new NotImplementedException();
		}

		public double DistanceTo(ICurve _0023_003Dz8fpRyMu9aKjE, out Point3D[] _0023_003DzC3IElXxE_0024pIU, out Point3D[] _0023_003Dze74J_0024SDPEuxX)
		{
			throw new NotImplementedException();
		}

		private double _0023_003DzC1ufabgPaCgrnb04XWmY2KI_003D(double _0023_003DzNDQ_E88_003D)
		{
			return Math.Cos(Math.PI * (double)Math.Sign(_0023_003DzyyvtvnY_003D()) * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D / 2.0);
		}

		private double _0023_003DzUpI2DQvbP4DpM15jDerLVC4_003D(double _0023_003DzNDQ_E88_003D)
		{
			return Math.Sin(Math.PI * (double)Math.Sign(_0023_003DzyyvtvnY_003D()) * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D / 2.0);
		}

		private double _0023_003Dz1wqgit4FuM1HcyIZDNolGplSaNYJpAIqQQ_003D_003D(double _0023_003DzNDQ_E88_003D)
		{
			return Math.Cos(Math.PI * (double)Math.Sign(_0023_003DzyyvtvnY_003D()) * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D / 2.0);
		}

		private double _0023_003Dzffri3Md9FbcW3dUr8udKZ4usjXogU1dtCg_003D_003D(double _0023_003DzNDQ_E88_003D)
		{
			return Math.Sin(Math.PI * (double)Math.Sign(_0023_003DzyyvtvnY_003D()) * _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D / 2.0);
		}
	}

	private sealed class _0023_003DzcntdzPM_003D
	{
		public devDept.Eyeshot.Entities.Region _0023_003DzncyYYSlCYRMY;

		public Vector3D _0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D;

		public List<ICurve> _0023_003DzVFJEgOr2cL2N = new List<ICurve>();

		public bool _0023_003DzUCYe4mP3BECb;

		public _0023_003DzcntdzPM_003D()
		{
		}

		private _0023_003DzcntdzPM_003D(_0023_003DzcntdzPM_003D _0023_003DzySgeilxprQOK)
		{
			_0023_003DzncyYYSlCYRMY = (devDept.Eyeshot.Entities.Region)(_0023_003DzySgeilxprQOK._0023_003DzncyYYSlCYRMY?.Clone());
			_0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D = (Vector3D)(_0023_003DzySgeilxprQOK._0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D?.Clone());
			foreach (ICurve item in _0023_003DzySgeilxprQOK._0023_003DzVFJEgOr2cL2N)
			{
				_0023_003DzVFJEgOr2cL2N.Add((ICurve)item.Clone());
			}
			_0023_003DzUCYe4mP3BECb = _0023_003DzySgeilxprQOK._0023_003DzUCYe4mP3BECb;
		}

		public object _0023_003Dzx9P_oXY_003D()
		{
			return new _0023_003DzcntdzPM_003D(this);
		}
	}

	[Serializable]
	private sealed class _0023_003DzozyIKwp_pBUqqxvkCg_003D_003D<_0023_003DzWWgGxds_003D>
	{
		public static readonly _0023_003DzozyIKwp_pBUqqxvkCg_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzozyIKwp_pBUqqxvkCg_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<List<(int, _0023_003DzWWgGxds_003D)>, IEnumerable<(int, _0023_003DzWWgGxds_003D)>> _0023_003Dz_flk8Dd8dzuAveOTIg_003D_003D;

		internal IEnumerable<(int, _0023_003DzWWgGxds_003D)> _0023_003DzQzQwhnn00taTHhSxwdGfjEs_003D(List<(int, _0023_003DzWWgGxds_003D)> _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D;
		}
	}

	private sealed class _0023_003DzvKKZp3E_003D
	{
		public readonly bool _0023_003DzIOT86Pw_003D;

		public readonly bool _0023_003DzOCtIgAXUYs4uR_hvBg_003D_003D;

		public Solid _0023_003Dz_GDhuLDHzFup;

		public devDept.Eyeshot.Entities.Region _0023_003DzjwwTdlk_003D;

		public Vector3D _0023_003DzOrvwLqwuFjhymoEUbA_003D_003D;

		public double _0023_003DzBBxiIYOTA9ilC6t1CQ_003D_003D;

		public double _0023_003DzzwJZRoc_003D;

		public _0023_003DzvKKZp3E_003D(bool _0023_003DzXfg_H7A_003D, bool _0023_003Dzp0yyV5KNKGJ6AHhLrA_003D_003D)
		{
			_0023_003DzIOT86Pw_003D = _0023_003DzXfg_H7A_003D;
			_0023_003DzOCtIgAXUYs4uR_hvBg_003D_003D = _0023_003Dzp0yyV5KNKGJ6AHhLrA_003D_003D;
		}
	}

	private sealed class _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D
	{
		public int? _0023_003DzlKP95AsKNRhVeKTJ7Q_003D_003D;

		internal bool _0023_003DzjY_YNB9osCWQeTDM0VO0NAQ_003D(IIfcRelVoidsElement _0023_003DzVlqgr54_003D)
		{
			if (_0023_003DzVlqgr54_003D.RelatedOpeningElement != null)
			{
				return _0023_003DzlKP95AsKNRhVeKTJ7Q_003D_003D != ((IIfcLocalPlacement)_0023_003DzVlqgr54_003D.RelatedOpeningElement.ObjectPlacement)?.PlacementRelTo?.EntityLabel;
			}
			return false;
		}
	}

	private sealed class _0023_003DzwnfWwa_00244Iat6vA8kRCjiHGE_003D
	{
		public ReadIFC _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		internal void _0023_003DqMtVZoJWeGZfvngEWOyzdT2ADrnVOb8NoxRRkHqy2eSaY9S7Is33_0024cEjBzmcdpsXs(int _0023_003Dz_7P0FDT12WXe, object _0023_003Dzz1OXOoQ_003D)
		{
			_0023_003DzopRx0_MBcTQs.UpdateProgress(_0023_003Dz_7P0FDT12WXe, 100.0, _0023_003DzopRx0_MBcTQs.ReadingText, _0023_003DzmHS7frs_003D);
		}
	}

	private sealed class _0023_003DzzkPoxwb_0024Xqj0ZHNaKIf8FuY_003D
	{
		public int _0023_003Dz437_00244ak_003D;

		public _0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D _0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D;

		internal Point4D _0023_003DzOfOYnKiuiFQHaEVxc1GTxk2_0024y3390RvggDIHR5g_003D(IIfcCartesianPoint _0023_003DzBJFJHwk_003D, int _0023_003DzTSeNR8Q_003D)
		{
			return new Point4D(_0023_003DzBJFJHwk_003D.X, _0023_003DzBJFJHwk_003D.Y, _0023_003DzBJFJHwk_003D.Z, (_0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzufKfca1jyE6LOmWG6g_003D_003D is IIfcRationalBSplineSurfaceWithKnots ifcRationalBSplineSurfaceWithKnots) ? ifcRationalBSplineSurfaceWithKnots.WeightsData[_0023_003Dz437_00244ak_003D][_0023_003DzTSeNR8Q_003D] : ((Xbim.Ifc4.MeasureResource.IfcReal)1.0));
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private XbimSchemaVersion _0023_003Dz9h8DwgM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Entity> _0023_003DzfT1LlfmL1u0t = new List<Entity>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzZKByqt9RvKDq _0023_003Dz54yRp_1nJ0Tq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, Color> _0023_003DzmykODqdsEmGb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Dictionary<string, int> _0023_003DzC9hu7B7ZCy4A;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IfcStore _0023_003DzRZUby85ponFJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzCdN9XeyRAFx_0024c_MxWA_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzwYO9yMKu2gUgMxzgogDUe4A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<int, Tuple<Entity, _0023_003DzcntdzPM_003D>> _0023_003DzJbrxuN7FfKk4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<(double, ICurve, int)> _0023_003DztTBUgMmHdpZ80d15og_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IfcContainer _0023_003Dz5gmbTIQAcsocTe6hTA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, IfcContainer> _0023_003DzWqUvS2YwfwH7tzIwxQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, string> _0023_003Dz6B5bxIQ7ryK0jTxGIA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzCSk_kiP18lUSdwpjorbX8U10velL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzafRExX_0024QNP1WihyLQiJ5Df8_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzIsAy_74fFAWY3qhq6K17Zqg_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DzRR1BxUogkP_xno_0024dFsYrvaWwDPlO3BxXbA_003D_003D _0023_003DzmSzWzPAybebR = new _0023_003DzRR1BxUogkP_xno_0024dFsYrvaWwDPlO3BxXbA_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DzRR1BxUogkP_xno_0024dFsYrvaWwDPlO3BxXbA_003D_003D _0023_003Dzm2BXCjT0VKl7EUwY9w_003D_003D = new _0023_003DzRR1BxUogkP_xno_0024dFsYrvaWwDPlO3BxXbA_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzArzy6r81Qpb6;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Inches | supportedLinearUnitsType.Feet | supportedLinearUnitsType.Miles | supportedLinearUnitsType.Millimeters | supportedLinearUnitsType.Meters | supportedLinearUnitsType.Kilometers | supportedLinearUnitsType.Yards | supportedLinearUnitsType.Nanometers | supportedLinearUnitsType.Decimeters | supportedLinearUnitsType.Decameters | supportedLinearUnitsType.Hectometers | supportedLinearUnitsType.Gigameters;

	public Dictionary<string, Color> DefaultColors => _0023_003DzmykODqdsEmGb;

	public IfcContainer Project
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5gmbTIQAcsocTe6hTA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5gmbTIQAcsocTe6hTA_003D_003D = value;
		}
	}

	public Dictionary<string, IfcContainer> Containers
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWqUvS2YwfwH7tzIwxQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWqUvS2YwfwH7tzIwxQ_003D_003D = value;
		}
	}

	public Dictionary<string, string> Systems
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6B5bxIQ7ryK0jTxGIA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz6B5bxIQ7ryK0jTxGIA_003D_003D = value;
		}
	}

	public double Deviation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3tDeP0XPI5JdYrADlw_003D_003D = value;
		}
	}

	public double OpeningsDeviation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCSk_kiP18lUSdwpjorbX8U10velL;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCSk_kiP18lUSdwpjorbX8U10velL = value;
		}
	}

	public bool ImportGrids
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzafRExX_0024QNP1WihyLQiJ5Df8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzafRExX_0024QNP1WihyLQiJ5Df8_003D = value;
		}
	}

	public bool ImportAnnotations
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzIsAy_74fFAWY3qhq6K17Zqg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzIsAy_74fFAWY3qhq6K17Zqg_003D = value;
		}
	}

	public ReadIFC(string filePath, double deviation = 0.0)
		: base(filePath)
	{
		_0023_003Dzuiqqh1Y_003D(deviation);
	}

	public ReadIFC(Stream stream, double deviation = 0.0)
		: base(stream)
	{
		_0023_003Dzuiqqh1Y_003D(deviation);
	}

	public ReadIFC(IfcStore ifcStore, double deviation = 0.0)
	{
		_0023_003DzRZUby85ponFJ = ifcStore;
		_0023_003DzCdN9XeyRAFx_0024c_MxWA_003D_003D = false;
		base.Blocks._0023_003Dz2tUjc04_003D();
		_0023_003Dzuiqqh1Y_003D(deviation);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzUCCDEqcIS5_00246(progress, ct);
	}

	private void _0023_003Dzuiqqh1Y_003D(double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		Deviation = _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;
		Containers = new Dictionary<string, IfcContainer>();
		Systems = new Dictionary<string, string>();
		_0023_003DzC9hu7B7ZCy4A = new Dictionary<string, int>();
		_0023_003DzmykODqdsEmGb = new Dictionary<string, Color>
		{
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005435),
				Color.FromArgb(255, 150, 150, 150)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005401),
				Color.FromArgb(255, 246, 233, 186)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005383),
				Color.FromArgb(255, 246, 233, 186)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005345),
				Color.FromArgb(255, 204, 255, 255)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005359),
				Color.FromArgb(255, 80, 80, 100)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005343),
				Color.FromArgb(65, 204, 204, 255)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006066),
				Color.FromArgb(255, 80, 80, 100)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006080),
				Color.FromArgb(65, 204, 204, 255)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006035),
				Color.FromArgb(255, 200, 200, 200)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006017),
				Color.FromArgb(255, 150, 150, 150)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006001),
				Color.FromArgb(65, 204, 204, 255)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005985),
				Color.FromArgb(50, 153, 204, 0)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005970),
				Color.FromArgb(255, 86, 170, 198)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005983),
				Color.FromArgb(255, 153, 155, 255)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005965),
				Color.FromArgb(255, 255, 100, 0)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006180),
				Color.FromArgb(255, 255, 100, 0)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006167),
				Color.FromArgb(255, 255, 50, 150)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006134),
				Color.FromArgb(255, 80, 80, 100)
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006127),
				Color.FromArgb(255, 80, 80, 100)
			}
		};
		_0023_003DzJbrxuN7FfKk4 = new Dictionary<int, Tuple<Entity, _0023_003DzcntdzPM_003D>>();
		_0023_003DztTBUgMmHdpZ80d15og_003D_003D = new List<(double, ICurve, int)>();
	}

	private void _0023_003DzUCCDEqcIS5_00246(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			if (_0023_003DzRZUby85ponFJ == null)
			{
				_0023_003DzRZUby85ponFJ = _0023_003Dz4oHjx8Q_003D(_0023_003DzmHS7frs_003D);
				_0023_003DzCdN9XeyRAFx_0024c_MxWA_003D_003D = true;
			}
			IIfcProject ifcProject = _0023_003DzRZUby85ponFJ.Instances.OfType<IIfcProject>().First();
			IStepFileName fileName = _0023_003DzRZUby85ponFJ.Header.FileName;
			base.Author = fileName.AuthorName.FirstOrDefault();
			base.Organization = fileName.Organization.FirstOrDefault();
			base.OriginatingSystem = fileName.OriginatingSystem;
			base.FileName = System.IO.Path.GetFileName(fileName.Name);
			if (DateTime.TryParse(fileName.TimeStamp, out var result))
			{
				base.Timestamp = result;
			}
			else
			{
				log.AppendLine(ReadFileAsync._0023_003DzZEKtB5M1I4vABrH53Opsgm4_003D);
			}
			base.PreProcessor = fileName.PreprocessorVersion;
			_0023_003Dz9h8DwgM_003D = _0023_003DzRZUby85ponFJ.SchemaVersion;
			base.Layers._0023_003DzPGvXmLk_003D(null);
			Project = new IfcContainer();
			_0023_003Dzm_2oKiw_003D(Project, ifcProject, null, null);
			_0023_003Dzm9fe7k8rBtC9(Project, ifcProject);
			_0023_003DzYWg9t1AOcxVe(ifcProject);
			_0023_003DzzEgsOqwML_0024c4yoqjIA_003D_003D();
			_0023_003Dz7e8BZgRPZ_0024yp();
			IIfcProduct[] array = _0023_003DzRZUby85ponFJ.Instances.OfType<IIfcProduct>().ToArray();
			int num = array.Length;
			using (_0023_003DzRZUby85ponFJ.BeginInverseCaching())
			{
				for (int i = 0; i < num; i++)
				{
					try
					{
						IIfcProduct ifcProduct = array[i];
						if ((ifcProduct is IIfcElement || ifcProduct is IIfcProxy || ifcProduct is IIfcStructuralItem) && !(ifcProduct is IIfcOpeningElement))
						{
							IIfcRelAggregates[] array2 = ifcProduct.Decomposes.ToArray();
							if (array2.Length == 0 || !(array2[0].RelatingObject is IIfcElement))
							{
								Entity entity = _0023_003DzJhImNRGbnkk2Tk5l2g_003D_003D(ifcProduct, _0023_003Dz3Lip_W0_003D: false);
								if (entity != null)
								{
									_0023_003DzfT1LlfmL1u0t.Add(entity);
									if (ifcProduct is IIfcElement { IsContainedIn: { } isContainedIn })
									{
										string text = isContainedIn.GlobalId;
										entity.IfcProperties.Parent = text;
										if (Containers.TryGetValue(text, out var value))
										{
											value.ContainedElements.Add(entity.IfcProperties.GUID);
										}
									}
									foreach (IIfcRelAssigns hasAssignment in ifcProduct.HasAssignments)
									{
										if (hasAssignment is IIfcRelAssignsToGroup { RelatingGroup: IIfcSystem relatingGroup })
										{
											entity.IfcProperties.Systems.Add(relatingGroup.GlobalId);
										}
									}
								}
								else
								{
									log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006111) + ifcProduct.ExpressType.ExpressName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990142) + ifcProduct.EntityLabel);
									log.AppendLine();
								}
							}
						}
					}
					catch (Exception ex)
					{
						log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005815), array[i].ExpressType.ExpressName, array[i].EntityLabel, ex.Message));
						log.AppendLine();
					}
					if (!UpdateProgressAndCheckCancelled(i, num, base.ParsingEntitiesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						return;
					}
				}
			}
			_0023_003DqiES4wcMZAEpyaeJmGu0WfzZnj7l_0024mT8PPE3EiFF2j5QBbc_0024n2ZJGxcrm470rfBuw(_0023_003DzfT1LlfmL1u0t);
			foreach (Block block in base.Blocks)
			{
				_0023_003DqiES4wcMZAEpyaeJmGu0WfzZnj7l_0024mT8PPE3EiFF2j5QBbc_0024n2ZJGxcrm470rfBuw(block.Entities);
			}
			UpdateProgressTo100(base.ParsingEntitiesText, _0023_003DzmHS7frs_003D);
			base.Entities.AddRange(_0023_003DzfT1LlfmL1u0t);
			base.Result = true;
		}
		catch (Exception ex2)
		{
			log.AppendLine(ex2.Message);
			log.AppendLine();
		}
		finally
		{
			if (_0023_003DzCdN9XeyRAFx_0024c_MxWA_003D_003D)
			{
				_0023_003DzRZUby85ponFJ?.Dispose();
			}
			CloseStream();
		}
	}

	private IfcStore _0023_003Dz4oHjx8Q_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		_0023_003DzwnfWwa_00244Iat6vA8kRCjiHGE_003D CS_0024_003C_003E8__locals5 = new _0023_003DzwnfWwa_00244Iat6vA8kRCjiHGE_003D();
		CS_0024_003C_003E8__locals5._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals5._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		Stream stream = base.Stream;
		bool flag = false;
		byte[] array = new byte[2];
		base.Stream.Read(array, 0, 2);
		base.Stream.Seek(0L, SeekOrigin.Begin);
		if (BitConverter.ToInt16(array, 0) == 19280)
		{
			ZipArchive val = new ZipArchive(base.Stream, (ZipArchiveMode)0);
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005763));
			if (val.Entries.Count != 1)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005737));
			}
			stream = new MemoryStream();
			flag = true;
			using Stream stream2 = val.Entries[0].Open();
			stream2.CopyTo(stream);
			stream.Seek(0L, SeekOrigin.Begin);
		}
		IfcStore result = IfcStore.Open(stream, StorageType.Ifc, XbimModelType.MemoryModel, null, XbimDBAccess.Read, delegate(int _0023_003Dz_7P0FDT12WXe, object _0023_003Dzz1OXOoQ_003D)
		{
			CS_0024_003C_003E8__locals5._0023_003DzopRx0_MBcTQs.UpdateProgress(_0023_003Dz_7P0FDT12WXe, 100.0, CS_0024_003C_003E8__locals5._0023_003DzopRx0_MBcTQs.ReadingText, CS_0024_003C_003E8__locals5._0023_003DzmHS7frs_003D);
		});
		if (flag)
		{
			stream.Close();
		}
		return result;
	}

	private void _0023_003DzYWg9t1AOcxVe(IIfcProject _0023_003DzN3sEO5ntl7fr)
	{
		foreach (IIfcRelAggregates item in _0023_003DzN3sEO5ntl7fr.IsDecomposedBy)
		{
			foreach (IIfcObjectDefinition relatedObject in item.RelatedObjects)
			{
				if (relatedObject is IIfcSpatialElement ifcSpatialElement)
				{
					try
					{
						IfcContainer ifcContainer = _0023_003DztvHhs7hpJmYvEQOFYc3592o_003D(ifcSpatialElement);
						ifcContainer.Parent = Project.GUID;
						Containers.Add(ifcContainer.GUID, ifcContainer);
						Project.Childs.Add(ifcContainer.GUID);
					}
					catch (Exception ex)
					{
						log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005815), ifcSpatialElement.ExpressType.ExpressName, ifcSpatialElement.EntityLabel, ex.Message));
						log.AppendLine();
					}
				}
			}
		}
	}

	private void _0023_003Dzm9fe7k8rBtC9(IfcContainer _0023_003Dz7BJPdsOL6qiw, IIfcProject _0023_003DzN3sEO5ntl7fr)
	{
		_0023_003Dz54yRp_1nJ0Tq = (_0023_003DzZKByqt9RvKDq)0;
		if (_0023_003DzN3sEO5ntl7fr.UnitsInContext == null)
		{
			return;
		}
		IItemSet<IIfcUnit> units = _0023_003DzN3sEO5ntl7fr.UnitsInContext.Units;
		Dictionary<string, object> dictionary = new Dictionary<string, object>(units.Count);
		_0023_003Dz7BJPdsOL6qiw.Properties.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951311), dictionary);
		foreach (IIfcUnit item in units)
		{
			if (!(item is IIfcNamedUnit ifcNamedUnit))
			{
				continue;
			}
			if (ifcNamedUnit.UnitType == Xbim.Ifc4.Interfaces.IfcUnitEnum.LENGTHUNIT)
			{
				if (!(ifcNamedUnit is IIfcSIUnit { Prefix: var prefix }))
				{
					if (ifcNamedUnit is IIfcConversionBasedUnit { Name: var name })
					{
						string text = name.ToString().ToLower();
						if (!(text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005908)))
						{
							if (!(text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005917)))
							{
								if (!(text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005898)))
								{
									if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005875))
									{
										base.Units = linearUnitsType.Miles;
									}
									else
									{
										base.Units = linearUnitsType.NotSupported;
									}
								}
								else
								{
									base.Units = linearUnitsType.Yards;
								}
							}
							else
							{
								base.Units = linearUnitsType.Inches;
							}
						}
						else
						{
							base.Units = linearUnitsType.Feet;
						}
					}
					else
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005888));
					}
				}
				else
				{
					switch (prefix)
					{
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.NANO:
						base.Units = linearUnitsType.Nanometers;
						break;
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.MILLI:
						base.Units = linearUnitsType.Millimeters;
						break;
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.CENTI:
						base.Units = linearUnitsType.Centimeters;
						break;
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.DECI:
						base.Units = linearUnitsType.Decimeters;
						break;
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.DECA:
						base.Units = linearUnitsType.Decameters;
						break;
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.HECTO:
						base.Units = linearUnitsType.Hectometers;
						break;
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.KILO:
						base.Units = linearUnitsType.Kilometers;
						break;
					case Xbim.Ifc4.Interfaces.IfcSIPrefix.GIGA:
						base.Units = linearUnitsType.Gigameters;
						break;
					case null:
						base.Units = linearUnitsType.Meters;
						break;
					default:
						base.Units = linearUnitsType.NotSupported;
						break;
					}
				}
			}
			else if (ifcNamedUnit.UnitType == Xbim.Ifc4.Interfaces.IfcUnitEnum.PLANEANGLEUNIT && ifcNamedUnit is IIfcConversionBasedUnit)
			{
				_0023_003Dz54yRp_1nJ0Tq = (_0023_003DzZKByqt9RvKDq)1;
			}
			if (dictionary.ContainsKey(ifcNamedUnit.UnitType.ToString()))
			{
				continue;
			}
			string value = string.Empty;
			if (!(ifcNamedUnit is IIfcSIUnit { Prefix: var prefix2 } ifcSIUnit2))
			{
				if (ifcNamedUnit is IIfcConversionBasedUnit ifcConversionBasedUnit2)
				{
					value = ifcConversionBasedUnit2.Name;
				}
			}
			else
			{
				value = prefix2.ToString();
				value += string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + ifcSIUnit2.Name);
			}
			dictionary.Add(ifcNamedUnit.UnitType.ToString(), value);
		}
	}

	private void _0023_003DzzEgsOqwML_0024c4yoqjIA_003D_003D()
	{
		if (!ImportGrids)
		{
			return;
		}
		foreach (IIfcGrid item in _0023_003DzRZUby85ponFJ.Instances.OfType<IIfcGrid>())
		{
			Transformation _0023_003Dzh_yiJh5c8f5N = new Identity();
			Transformation _0023_003DzBNjqNCJEWknf = new Identity();
			if (item.ObjectPlacement != null)
			{
				_0023_003DzBNjqNCJEWknf = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(item.ObjectPlacement, out _0023_003Dzh_yiJh5c8f5N, out var _);
			}
			Block block = new Block(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005826) + item.EntityLabel);
			_0023_003DzRhRUJm59MpIe_00246VVBg_003D_003D(item.UAxes, _0023_003DzBNjqNCJEWknf, block);
			_0023_003DzRhRUJm59MpIe_00246VVBg_003D_003D(item.VAxes, _0023_003DzBNjqNCJEWknf, block);
			_0023_003DzRhRUJm59MpIe_00246VVBg_003D_003D(item.WAxes, _0023_003DzBNjqNCJEWknf, block);
			base.Blocks.Add(block);
			BlockReference blockReference = new BlockReference(block.Name);
			_0023_003Dzm_2oKiw_003D(blockReference, item, _0023_003Dzh_yiJh5c8f5N, _0023_003DzBNjqNCJEWknf, null);
			IIfcRelContainedInSpatialStructure[] array = item.ContainedInStructure.ToArray();
			if (array.Length != 0)
			{
				string text = array[0].RelatingStructure.GlobalId;
				if (Containers.TryGetValue(text, out var value))
				{
					blockReference.IfcProperties.Parent = text;
					value.ContainedElements.Add(blockReference.IfcProperties.GUID);
				}
			}
			if (!base.Layers.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578)))
			{
				base.Layers.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578));
			}
			blockReference.LayerName = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578);
			_0023_003DzfT1LlfmL1u0t.Add(blockReference);
		}
	}

	private void _0023_003DzRhRUJm59MpIe_00246VVBg_003D_003D(IItemSet<IIfcGridAxis> _0023_003DzFClaSH_0024qVrtW_0024mDadg_003D_003D, Transformation _0023_003DzBNjqNCJEWknf, Block _0023_003DzNd36O4UUXSkF)
	{
		foreach (IIfcGridAxis item in _0023_003DzFClaSH_0024qVrtW_0024mDadg_003D_003D)
		{
			Entity entity = (Entity)_0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(item.AxisCurve, _0023_003DzXSrUO6ixqq8l: false, null, null);
			if (entity != null)
			{
				entity.TransformBy(_0023_003DzBNjqNCJEWknf);
				int entityLabel = item.EntityLabel;
				Xbim.Ifc4.MeasureResource.IfcLabel? axisTag = item.AxisTag;
				entity.TranslationID = new TranslationIdentifier(entityLabel, axisTag.HasValue ? ((string)axisTag.GetValueOrDefault()) : null);
				_0023_003DzNd36O4UUXSkF.Entities.Add(entity);
			}
			else
			{
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006591), item.AxisCurve.ExpressType.ExpressName, item.AxisCurve.EntityLabel));
			}
		}
	}

	private void _0023_003Dz7e8BZgRPZ_0024yp()
	{
		if (!ImportAnnotations)
		{
			return;
		}
		foreach (IIfcAnnotation item in _0023_003DzRZUby85ponFJ.Instances.OfType<IIfcAnnotation>())
		{
			Transformation _0023_003Dzh_yiJh5c8f5N = new Identity();
			Transformation transformation = new Identity();
			if (item.ObjectPlacement != null)
			{
				transformation = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(item.ObjectPlacement, out _0023_003Dzh_yiJh5c8f5N, out var _);
			}
			if (item.Representation == null)
			{
				continue;
			}
			Block block = new Block(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006559) + item.EntityLabel);
			IIfcRepresentationItem ifcRepresentationItem = item.Representation.Representations[0].Items.First();
			if (ifcRepresentationItem is IIfcGeometricCurveSet ifcGeometricCurveSet)
			{
				foreach (IIfcGeometricSetSelect element in ifcGeometricCurveSet.Elements)
				{
					if (!(element is IIfcPoint) && element is IIfcCurve)
					{
						Entity entity = (Entity)_0023_003DzNxFOIS2YIfeIx76DDg_003D_003D((IIfcCurve)element, _0023_003DzXSrUO6ixqq8l: false, null, null);
						entity.TransformBy(transformation);
						block.Entities.Add(entity);
					}
				}
			}
			else if (ifcRepresentationItem is IIfcCurve _0023_003DzYbZQw3SBCmck)
			{
				Entity entity2 = (Entity)_0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(_0023_003DzYbZQw3SBCmck, _0023_003DzXSrUO6ixqq8l: false, null, null);
				if (entity2 != null)
				{
					entity2.TransformBy(transformation);
					block.Entities.Add(entity2);
				}
			}
			else
			{
				if (!(ifcRepresentationItem is IIfcTextLiteralWithExtent ifcTextLiteralWithExtent))
				{
					log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006517), item.ExpressType.ExpressName, item.EntityLabel, ifcRepresentationItem.ExpressType.ExpressName));
					log.AppendLine();
					continue;
				}
				Plane textPlane = Plane.XY;
				if (ifcTextLiteralWithExtent.Placement is IIfcAxis2Placement2D _0023_003DzpdeSbFA_003D)
				{
					textPlane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(_0023_003DzpdeSbFA_003D);
				}
				else if (ifcTextLiteralWithExtent.Placement is IIfcAxis2Placement3D _0023_003DzpdeSbFA_003D2)
				{
					textPlane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(_0023_003DzpdeSbFA_003D2);
				}
				Text.alignmentType alignment = _0023_003DzrQ8OxemQ5HRL(ifcTextLiteralWithExtent.BoxAlignment);
				Text text = new Text(textPlane, ifcTextLiteralWithExtent.Literal, 1.0, alignment);
				text.TransformBy(transformation);
				block.Entities.Add(text);
			}
			base.Blocks.Add(block);
			BlockReference blockReference = new BlockReference(block.Name);
			_0023_003Dzm_2oKiw_003D(blockReference, item, _0023_003Dzh_yiJh5c8f5N, transformation, null);
			IIfcRelContainedInSpatialStructure ifcRelContainedInSpatialStructure = item.ContainedInStructure.FirstOrDefault();
			if (ifcRelContainedInSpatialStructure != null)
			{
				string text2 = ifcRelContainedInSpatialStructure.RelatingStructure.GlobalId;
				blockReference.IfcProperties.Parent = text2;
				if (Containers.TryGetValue(text2, out var value))
				{
					value.ContainedElements.Add(blockReference.IfcProperties.GUID);
				}
			}
			IIfcPresentationLayerAssignment[] array = ifcRepresentationItem.LayerAssignment.ToArray();
			if (array.Length != 0)
			{
				_0023_003DzvoVaxJKxgc_0024O(blockReference, array[0]);
			}
			else
			{
				if (!base.Layers.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578)))
				{
					base.Layers.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578));
				}
				blockReference.LayerName = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578);
			}
			_0023_003DzfT1LlfmL1u0t.Add(blockReference);
		}
	}

	private static Text.alignmentType _0023_003DzrQ8OxemQ5HRL(string _0023_003DzUaFNob6Ul0_B)
	{
		if (_0023_003DzUaFNob6Ul0_B != null)
		{
			switch (_0023_003DzUaFNob6Ul0_B.Length)
			{
			case 11:
				switch (_0023_003DzUaFNob6Ul0_B[0])
				{
				case 'm':
					if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006681)))
					{
						break;
					}
					return Text.alignmentType.MiddleLeft;
				case 'b':
					if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006667)))
					{
						break;
					}
					return Text.alignmentType.BottomLeft;
				}
				break;
			case 12:
				switch (_0023_003DzUaFNob6Ul0_B[0])
				{
				case 'm':
					if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006636)))
					{
						break;
					}
					return Text.alignmentType.MiddleRight;
				case 'b':
					if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006621)))
					{
						break;
					}
					return Text.alignmentType.BottomRight;
				}
				break;
			case 8:
				if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006473)))
				{
					break;
				}
				return Text.alignmentType.TopLeft;
			case 10:
				if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006714)))
				{
					break;
				}
				return Text.alignmentType.TopCenter;
			case 9:
				if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006697)))
				{
					break;
				}
				return Text.alignmentType.TopRight;
			case 6:
				if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006653)))
				{
					break;
				}
				return Text.alignmentType.MiddleCenter;
			case 13:
				if (!(_0023_003DzUaFNob6Ul0_B == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006322)))
				{
					break;
				}
				return Text.alignmentType.BottomCenter;
			}
		}
		return Text.alignmentType.BottomLeft;
	}

	private void _0023_003DzPpGEt1mu8wZyktTDBA_003D_003D(Solid _0023_003DzQUhnjVe9kSO_0024, List<_0023_003DzvKKZp3E_003D> _0023_003DznxqgXxLAPFrc)
	{
		foreach (_0023_003DzvKKZp3E_003D item in _0023_003DznxqgXxLAPFrc)
		{
			if (!item._0023_003DzOCtIgAXUYs4uR_hvBg_003D_003D)
			{
				continue;
			}
			bool flag = item._0023_003DzIOT86Pw_003D;
			devDept.Eyeshot.Entities.Region region = (devDept.Eyeshot.Entities.Region)item._0023_003DzjwwTdlk_003D.Clone();
			if (item._0023_003DzIOT86Pw_003D)
			{
				bool flag2 = false;
				region.Regen(item._0023_003DzzwJZRoc_003D);
				Utility.ComputeBoundingBox(region.EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
				double num = new Size3D(boxMin, boxMax).Diagonal / 1000.0;
				foreach (Solid.Portion portion in _0023_003DzQUhnjVe9kSO_0024.Portions)
				{
					for (int i = 1; i <= portion.FaceCount; i++)
					{
						Plane plane = new Plane(portion.planes[i].ToArray());
						if (Vector3D.AreParallel(region.Plane.AxisZ, plane.AxisZ) && Math.Abs(plane.DistanceTo(region.Vertices[0])) < num && Vector3D.Dot(item._0023_003DzOrvwLqwuFjhymoEUbA_003D_003D, plane.AxisZ) < 0.0)
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						break;
					}
				}
				flag = flag2;
			}
			double num2 = item._0023_003DzBBxiIYOTA9ilC6t1CQ_003D_003D;
			if (flag)
			{
				region.Translate(item._0023_003DzOrvwLqwuFjhymoEUbA_003D_003D * (0.0 - num2));
				num2 *= 3.0;
			}
			item._0023_003Dz_GDhuLDHzFup = region.ExtrudeAsSolid(item._0023_003DzOrvwLqwuFjhymoEUbA_003D_003D * num2, new RegenParams(item._0023_003DzzwJZRoc_003D, 0.0));
		}
	}

	private Entity _0023_003DzuXO8ip3szjRO(Solid[] _0023_003DzPx6ksywTXg5_0024)
	{
		if (_0023_003DzPx6ksywTXg5_0024.Length <= 1)
		{
			return _0023_003DzPx6ksywTXg5_0024[0];
		}
		Mesh mesh = _0023_003DzPx6ksywTXg5_0024[0].ConvertToMesh();
		for (int i = 1; i < _0023_003DzPx6ksywTXg5_0024.Length; i++)
		{
			mesh.MergeWith(_0023_003DzPx6ksywTXg5_0024[i].ConvertToMesh());
		}
		return mesh;
	}

	private bool _0023_003Dzv_bL_00248Fwl8H8(Solid[] _0023_003DztO_U0dxM_RWC, Solid[] _0023_003DzzywZ_kklAh1c, string _0023_003DzQRegcNE_003D, out Solid[] _0023_003DzOLHnb2M_003D)
	{
		bool flag = false;
		foreach (Solid _0023_003Dzoo79dcQ_003D in _0023_003DzzywZ_kklAh1c)
		{
			List<Solid> list = new List<Solid>();
			Solid[] array = _0023_003DztO_U0dxM_RWC;
			foreach (Solid _0023_003Dz2tz8rIE_003D in array)
			{
				Solid[] _0023_003DzOLHnb2M_003D2;
				bool flag2 = _0023_003DzsJsLvOqkgsKa(_0023_003Dz2tz8rIE_003D, _0023_003Dzoo79dcQ_003D, _0023_003DzQRegcNE_003D, out _0023_003DzOLHnb2M_003D2);
				flag = flag || flag2;
				list.AddRange(_0023_003DzOLHnb2M_003D2);
			}
			_0023_003DztO_U0dxM_RWC = list.ToArray();
		}
		_0023_003DzOLHnb2M_003D = _0023_003DztO_U0dxM_RWC;
		return flag;
	}

	private bool _0023_003DzYAKlj_rB2j8J(Solid[] _0023_003DztO_U0dxM_RWC, Solid[] _0023_003DzzywZ_kklAh1c, string _0023_003DzQRegcNE_003D, out Solid[] _0023_003DzOLHnb2M_003D)
	{
		bool result = false;
		foreach (Solid b in _0023_003DzzywZ_kklAh1c)
		{
			List<Solid> list = new List<Solid>();
			Solid[] array = _0023_003DztO_U0dxM_RWC;
			foreach (Solid solid in array)
			{
				Solid[] array2 = Solid.Intersection(solid, b);
				if (array2 != null)
				{
					list.AddRange(array2);
					result = true;
				}
				else
				{
					list.Add(solid);
				}
			}
			_0023_003DztO_U0dxM_RWC = list.ToArray();
		}
		_0023_003DzOLHnb2M_003D = _0023_003DztO_U0dxM_RWC;
		return result;
	}

	private bool _0023_003DzKnTn5v99TpUJ(Solid[] _0023_003DztO_U0dxM_RWC, Solid[] _0023_003DzzywZ_kklAh1c, string _0023_003DzQRegcNE_003D, out Solid[] _0023_003DzOLHnb2M_003D)
	{
		bool result = false;
		foreach (Solid b in _0023_003DzzywZ_kklAh1c)
		{
			List<Solid> list = new List<Solid>();
			Solid[] array = _0023_003DztO_U0dxM_RWC;
			foreach (Solid solid in array)
			{
				Solid[] array2 = Solid.Union(solid, b);
				if (array2 != null)
				{
					list.AddRange(array2);
					result = true;
				}
				else
				{
					list.Add(solid);
				}
			}
			_0023_003DztO_U0dxM_RWC = list.ToArray();
		}
		_0023_003DzOLHnb2M_003D = _0023_003DztO_U0dxM_RWC;
		return result;
	}

	public static double DefineEps(Point3D min, Point3D max)
	{
		Size3D size3D = new Size3D(min, max);
		double[] array = new double[3] { size3D.X, size3D.Y, size3D.Z };
		Array.Sort(array);
		double num = double.MaxValue;
		for (int i = 0; i < 3; i++)
		{
			if (!(array[i] < Utility._0023_003DzheSR8QM7q9ya))
			{
				num = array[i];
				break;
			}
		}
		return num * Utility._0023_003DzxhnLabVjXjPg;
	}

	private bool _0023_003DzduYS0DQZstiQ53UTYw_003D_003D(Solid[] _0023_003DzPx6ksywTXg5_0024, double _0023_003Dzm0CYiiE_003D)
	{
		foreach (Solid solid in _0023_003DzPx6ksywTXg5_0024)
		{
			for (int j = 0; j < solid.Portions.Count; j++)
			{
				Solid.Portion portion = solid.Portions[j];
				Point3D[] vertices = portion.Vertices;
				int _0023_003DzhX7K0dc_003D = Solid._0023_003DzQaPlK3qJVEsR8De_cQ_003D_003D(portion);
				for (int k = 1; k <= portion.FaceCount; k++)
				{
					solid._0023_003DzYm_0024NZRCNgy0n(j, k, _0023_003DzhX7K0dc_003D, out var _0023_003Dzcv8o5nO25OjS, out var _, _0023_003Dzm0CYiiE_003D);
					PlaneEquation planeEquation = portion.planes[k];
					Plane plane = new Plane(new double[4] { planeEquation.X, planeEquation.Y, planeEquation.Z, planeEquation.D });
					Point2D[] array = new Point2D[_0023_003Dzcv8o5nO25OjS[0].Length];
					for (int l = 0; l < _0023_003Dzcv8o5nO25OjS[0].Length; l++)
					{
						array[l] = plane.Project(vertices[_0023_003Dzcv8o5nO25OjS[0][l]]);
					}
					if (Utility.IsPolygonSelfIntersecting(array))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private bool _0023_003DzsJsLvOqkgsKa(Solid _0023_003Dz2tz8rIE_003D, Solid _0023_003Dzoo79dcQ_003D, string _0023_003DzQRegcNE_003D, out Solid[] _0023_003DzOLHnb2M_003D)
	{
		_0023_003Dz2tz8rIE_003D.UpdateBoundingBox(null);
		_0023_003Dzoo79dcQ_003D.UpdateBoundingBox(null);
		double _0023_003Dzm0CYiiE_003D = ((_0023_003Dz2tz8rIE_003D.BoxSize.Diagonal < _0023_003Dzoo79dcQ_003D.BoxSize.Diagonal) ? DefineEps(_0023_003Dz2tz8rIE_003D.BoxMin, _0023_003Dz2tz8rIE_003D.BoxMax) : DefineEps(_0023_003Dzoo79dcQ_003D.BoxMin, _0023_003Dzoo79dcQ_003D.BoxMax));
		_0023_003DzmSzWzPAybebR._0023_003DzbBhhBAU_003D(_0023_003Dz2tz8rIE_003D);
		_0023_003DzOLHnb2M_003D = Solid._0023_003Dzms3EXGM0kMEE((Solid._0023_003Dz6tkLYNg_003D)2, _0023_003Dz2tz8rIE_003D, _0023_003Dzoo79dcQ_003D, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: false, _0023_003DzfjRqwoISk3lB: false, _0023_003Dzm0CYiiE_003D, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: false);
		if (_0023_003DzOLHnb2M_003D != null && _0023_003DzOLHnb2M_003D.Length != 0)
		{
			return true;
		}
		_0023_003DzmSzWzPAybebR._0023_003DzJvr5DC0_003D(_0023_003Dz2tz8rIE_003D);
		Utility.ComputeBoundingBox(new Point3D[4] { _0023_003Dz2tz8rIE_003D.localMin, _0023_003Dz2tz8rIE_003D.localMax, _0023_003Dzoo79dcQ_003D.localMin, _0023_003Dzoo79dcQ_003D.localMax }, out var boxMin, out var boxMax);
		_0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D _0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D2 = new _0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D(524288, boxMin, boxMax);
		Solid solid = (Solid)_0023_003Dz2tz8rIE_003D.Clone();
		Solid solid2 = (Solid)_0023_003Dzoo79dcQ_003D.Clone();
		_0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D2._0023_003DzP0_vBrSco8N8(solid);
		_0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D2._0023_003DzP0_vBrSco8N8(solid2);
		_0023_003Dzm0CYiiE_003D = 0.5;
		_0023_003DzOLHnb2M_003D = Solid._0023_003Dzms3EXGM0kMEE((Solid._0023_003Dz6tkLYNg_003D)2, solid, solid2, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: false, _0023_003DzfjRqwoISk3lB: false, _0023_003Dzm0CYiiE_003D, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: false);
		if (_0023_003DzOLHnb2M_003D != null && _0023_003DzOLHnb2M_003D.Length != 0)
		{
			Solid[] array = _0023_003DzOLHnb2M_003D;
			foreach (Solid _0023_003DzuwH5j5s_003D in array)
			{
				_0023_003Dzivz4YSuJqYmFhVFeMkAURNPIfZYjrTrm_0024Q_003D_003D2._0023_003DzaFoDiP4Kjs_5(_0023_003DzuwH5j5s_003D);
			}
			return true;
		}
		Utility.IntersectionBox(_0023_003Dz2tz8rIE_003D.BoxMin, _0023_003Dz2tz8rIE_003D.BoxMax, _0023_003Dzoo79dcQ_003D.BoxMin, _0023_003Dzoo79dcQ_003D.BoxMax, out var intersMin, out var intersMax);
		_0023_003Dzm0CYiiE_003D = new Size3D(intersMin, intersMax).Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
		for (int j = 0; j < 5; j++)
		{
			_0023_003DzOLHnb2M_003D = Solid._0023_003Dzms3EXGM0kMEE((Solid._0023_003Dz6tkLYNg_003D)2, _0023_003Dz2tz8rIE_003D, _0023_003Dzoo79dcQ_003D, _0023_003Dzu47uBDPk_00245Nm228fCg_003D_003D: false, _0023_003DzfjRqwoISk3lB: false, _0023_003Dzm0CYiiE_003D, _0023_003DzzsgyCZBIOljniVpz1GYTX_0024M_003D: false);
			if (_0023_003DzOLHnb2M_003D != null && _0023_003DzOLHnb2M_003D.Length != 0)
			{
				return true;
			}
			_0023_003DzmSzWzPAybebR._0023_003DzJvr5DC0_003D(_0023_003Dz2tz8rIE_003D);
			_0023_003Dzm0CYiiE_003D *= 0.1;
		}
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006310) + _0023_003DzQRegcNE_003D);
		_0023_003DzOLHnb2M_003D = new Solid[1] { _0023_003Dz2tz8rIE_003D };
		return false;
	}

	private Entity _0023_003DzwHiRxkxT20ku8q6D3w_003D_003D(Entity _0023_003DzHkoUX5RiCcTr, IIfcElement _0023_003Dzf5YWCJFyb2WE, bool _0023_003Dz55f9J0JIXjQHa_Xsbw_003D_003D, out List<Entity> _0023_003DzMvFiRUUx9XO5q71hqA_003D_003D)
	{
		Entity result = _0023_003DzHkoUX5RiCcTr;
		_0023_003DzMvFiRUUx9XO5q71hqA_003D_003D = new List<Entity>();
		List<_0023_003DzvKKZp3E_003D> list = new List<_0023_003DzvKKZp3E_003D>();
		foreach (IIfcRelVoidsElement hasOpening in _0023_003Dzf5YWCJFyb2WE.HasOpenings)
		{
			if (hasOpening.RelatedOpeningElement != null)
			{
				if (_0023_003DzMVE7FzyWxbkQXGZkYg_003D_003D((IIfcOpeningElement)hasOpening.RelatedOpeningElement, _0023_003Dz55f9J0JIXjQHa_Xsbw_003D_003D, out var _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D, out var _0023_003DzInI7ln34nx45Ys0iLQ_003D_003D))
				{
					list.AddRange(_0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D);
					_0023_003DzMvFiRUUx9XO5q71hqA_003D_003D.AddRange(_0023_003DzInI7ln34nx45Ys0iLQ_003D_003D);
				}
			}
			else
			{
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006279), _0023_003Dzf5YWCJFyb2WE.ExpressType.ExpressName, _0023_003Dzf5YWCJFyb2WE.EntityLabel));
			}
		}
		if (list.Count > 0)
		{
			result = _0023_003DzrliCLSiP2C1fQ2jryw_003D_003D(_0023_003DzHkoUX5RiCcTr, list, _0023_003Dzf5YWCJFyb2WE.GlobalId);
		}
		else
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006254), _0023_003Dzf5YWCJFyb2WE.EntityLabel));
		}
		return result;
	}

	private Entity _0023_003DzrliCLSiP2C1fQ2jryw_003D_003D(Entity _0023_003DzHkoUX5RiCcTr, List<_0023_003DzvKKZp3E_003D> _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D, string _0023_003DzA66o8_0024g_003D)
	{
		Entity entity = _0023_003DzHkoUX5RiCcTr;
		Mesh mesh = new Mesh();
		mesh.CopyAttributes(_0023_003DzHkoUX5RiCcTr);
		mesh.IfcProperties = _0023_003DzHkoUX5RiCcTr.IfcProperties;
		mesh.TranslationID = _0023_003DzHkoUX5RiCcTr.TranslationID;
		if (_0023_003DzHkoUX5RiCcTr is Solid _0023_003DzQUhnjVe9kSO_0024)
		{
			entity = _0023_003DzCuIWRlp9HDot(_0023_003DzQUhnjVe9kSO_0024, _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D, _0023_003DzA66o8_0024g_003D);
		}
		else if (_0023_003DzHkoUX5RiCcTr is Mesh mesh2)
		{
			Mesh[] array = mesh2.SplitDisjoint();
			for (int i = 0; i < array.Length; i++)
			{
				Entity entity2 = _0023_003DzCuIWRlp9HDot(array[i].ConvertToSolid(), _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D, _0023_003DzA66o8_0024g_003D);
				if (entity2 is Solid solid)
				{
					array[i] = solid.ConvertToMesh();
				}
				else
				{
					array[i] = (Mesh)entity2;
				}
				array[i].ColorMethod = colorMethodType.byParent;
			}
			entity = array[0];
			for (int j = 1; j < array.Length; j++)
			{
				((Mesh)entity).MergeWith(array[j]);
			}
		}
		else if (_0023_003DzHkoUX5RiCcTr is BlockReference blockReference)
		{
			Transformation transformation = (Transformation)blockReference.Transformation.Clone();
			transformation.Invert();
			Block block = base.Blocks[blockReference.BlockName];
			for (int k = 0; k < block.Entities.Count; k++)
			{
				Entity entity3 = block.Entities[k];
				entity3.TransformBy(blockReference.Transformation);
				entity3 = _0023_003DzrliCLSiP2C1fQ2jryw_003D_003D(entity3, _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D, _0023_003DzA66o8_0024g_003D);
				entity3.TransformBy(transformation);
				block.Entities[k] = entity3;
			}
			entity = _0023_003DzHkoUX5RiCcTr;
		}
		entity.CopyAttributes(mesh);
		entity.IfcProperties = mesh.IfcProperties;
		entity.TranslationID = mesh.TranslationID;
		return entity;
	}

	private Entity _0023_003DzCuIWRlp9HDot(Solid _0023_003DzQUhnjVe9kSO_0024, List<_0023_003DzvKKZp3E_003D> _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D, string _0023_003DzA66o8_0024g_003D)
	{
		_0023_003Dzm2BXCjT0VKl7EUwY9w_003D_003D._0023_003DzbBhhBAU_003D(_0023_003DzQUhnjVe9kSO_0024);
		_0023_003DzPpGEt1mu8wZyktTDBA_003D_003D(_0023_003DzQUhnjVe9kSO_0024, _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D);
		Solid[] array = new Solid[_0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D.Count];
		for (int i = 0; i < _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D.Count; i++)
		{
			array[i] = _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D[i]._0023_003Dz_GDhuLDHzFup;
		}
		if (!_0023_003Dzv_bL_00248Fwl8H8(new Solid[1] { _0023_003DzQUhnjVe9kSO_0024 }, array, _0023_003DzA66o8_0024g_003D, out var _0023_003DzOLHnb2M_003D) || !_0023_003DzduYS0DQZstiQ53UTYw_003D_003D(_0023_003DzOLHnb2M_003D, DefineEps(_0023_003DzQUhnjVe9kSO_0024.BoxMin, _0023_003DzQUhnjVe9kSO_0024.BoxMax)))
		{
			_0023_003Dzm2BXCjT0VKl7EUwY9w_003D_003D._0023_003DzJvr5DC0_003D(_0023_003DzQUhnjVe9kSO_0024);
			return _0023_003DzQUhnjVe9kSO_0024;
		}
		return _0023_003DzuXO8ip3szjRO(_0023_003DzOLHnb2M_003D);
	}

	private bool _0023_003DzMVE7FzyWxbkQXGZkYg_003D_003D(IIfcOpeningElement _0023_003Dz6WqznVKBiUxe, bool _0023_003Dz55f9J0JIXjQHa_Xsbw_003D_003D, out List<_0023_003DzvKKZp3E_003D> _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D, out List<Mesh> _0023_003DzInI7ln34nx45Ys0iLQ_003D_003D)
	{
		_0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D = new List<_0023_003DzvKKZp3E_003D>();
		_0023_003DzInI7ln34nx45Ys0iLQ_003D_003D = new List<Mesh>();
		Transformation _0023_003Dzh_yiJh5c8f5N = new Identity();
		Transformation _0023_003DzWCq3uvYlfUGo = new Identity();
		Transformation transformation = new Identity();
		Transformation xform = new Identity();
		_0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D = new _0023_003DzcntdzPM_003D
		{
			_0023_003DzUCYe4mP3BECb = true
		};
		bool _0023_003DzXfg_H7A_003D = ((_0023_003Dz9h8DwgM_003D != XbimSchemaVersion.Ifc2X3) ? (_0023_003Dz6WqznVKBiUxe.PredefinedType == IfcOpeningElementTypeEnum.OPENING) : (!_0023_003Dz6WqznVKBiUxe.ObjectType.HasValue || !_0023_003Dz6WqznVKBiUxe.ObjectType.Value.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006434))));
		if (_0023_003Dz6WqznVKBiUxe.ObjectPlacement != null)
		{
			transformation = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(_0023_003Dz6WqznVKBiUxe.ObjectPlacement, out _0023_003Dzh_yiJh5c8f5N, out _0023_003DzWCq3uvYlfUGo);
			xform = (_0023_003Dz55f9J0JIXjQHa_Xsbw_003D_003D ? transformation : _0023_003Dzh_yiJh5c8f5N);
		}
		if (_0023_003Dz6WqznVKBiUxe.Representation != null)
		{
			foreach (IIfcRepresentation representation in _0023_003Dz6WqznVKBiUxe.Representation.Representations)
			{
				string text = representation.RepresentationIdentifier ?? ((Xbim.Ifc4.MeasureResource.IfcLabel)string.Empty);
				if ((!text.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006445)) && !text.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006426))) || representation.Items.Count == 0)
				{
					continue;
				}
				IIfcRepresentationItem ifcRepresentationItem = representation.Items.First();
				if (!(ifcRepresentationItem is IIfcExtrudedAreaSolid))
				{
					if (!(ifcRepresentationItem is IIfcFacetedBrep))
					{
						if (ifcRepresentationItem is IIfcMappedItem)
						{
							foreach (IIfcRepresentationItem item in representation.Items)
							{
								_0023_003DzvKKZp3E_003D _0023_003DzvKKZp3E_003D2 = new _0023_003DzvKKZp3E_003D(_0023_003DzXfg_H7A_003D, _0023_003Dzp0yyV5KNKGJ6AHhLrA_003D_003D: false);
								IIfcMappedItem ifcMappedItem = (IIfcMappedItem)item;
								IIfcRepresentationMap mappingSource = ifcMappedItem.MappingSource;
								Entity[] array = _0023_003DzC4gSMQjGqwdAPi7nMQ_003D_003D(mappingSource.MappedRepresentation, ref _0023_003DzELu0Pss_003D);
								if (array.Length != 0)
								{
									Entity entity = array[0];
									Plane to = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D((IIfcPlacement)mappingSource.MappingOrigin);
									Transformation xform2 = Transformation.CreateAlignment(Plane.XY, to);
									entity.TransformBy(xform2);
									Transformation xform3 = _0023_003Dzd1SOyu_9fyOH(ifcMappedItem);
									entity.TransformBy(xform3);
									Solid _0023_003Dz_GDhuLDHzFup;
									Mesh mesh;
									if (entity is Solid solid)
									{
										_0023_003Dz_GDhuLDHzFup = solid;
										mesh = solid.ConvertToMesh();
									}
									else
									{
										if (!(entity is Mesh mesh2))
										{
											log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006410), item.ExpressType.ExpressName, item.EntityLabel, _0023_003Dz6WqznVKBiUxe.EntityLabel));
											continue;
										}
										_0023_003Dz_GDhuLDHzFup = mesh2.ConvertToSolid();
										mesh = mesh2;
									}
									_0023_003DzvKKZp3E_003D2._0023_003Dz_GDhuLDHzFup = _0023_003Dz_GDhuLDHzFup;
									_0023_003DzvKKZp3E_003D2._0023_003Dz_GDhuLDHzFup.TransformBy(xform);
									mesh.TransformBy(transformation);
									_0023_003DzEmS3qUErVFPU(mesh, item, _0023_003DzELu0Pss_003D);
									_0023_003DzInI7ln34nx45Ys0iLQ_003D_003D.Add(mesh);
									_0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D.Add(_0023_003DzvKKZp3E_003D2);
								}
								else
								{
									log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006410), item.ExpressType.ExpressName, item.EntityLabel, _0023_003Dz6WqznVKBiUxe.EntityLabel));
								}
							}
							continue;
						}
						foreach (IIfcRepresentationItem item2 in representation.Items)
						{
							_0023_003DzvKKZp3E_003D _0023_003DzvKKZp3E_003D3 = new _0023_003DzvKKZp3E_003D(_0023_003DzXfg_H7A_003D, _0023_003Dzp0yyV5KNKGJ6AHhLrA_003D_003D: false);
							if (_0023_003DzVYn8KqEjagTAVbuOCQ_003D_003D(item2, ref _0023_003DzELu0Pss_003D) is Mesh mesh3)
							{
								_0023_003DzvKKZp3E_003D3._0023_003Dz_GDhuLDHzFup = mesh3.ConvertToSolid();
								_0023_003DzvKKZp3E_003D3._0023_003Dz_GDhuLDHzFup.TransformBy(xform);
								mesh3.TransformBy(transformation);
								_0023_003DzEmS3qUErVFPU(mesh3, item2, _0023_003DzELu0Pss_003D);
								_0023_003DzInI7ln34nx45Ys0iLQ_003D_003D.Add(mesh3);
								_0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D.Add(_0023_003DzvKKZp3E_003D3);
							}
							else
							{
								log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006410), item2.ExpressType.ExpressName, item2.EntityLabel, _0023_003Dz6WqznVKBiUxe.EntityLabel));
							}
						}
						continue;
					}
					foreach (IIfcRepresentationItem item3 in representation.Items)
					{
						_0023_003DzvKKZp3E_003D _0023_003DzvKKZp3E_003D4 = new _0023_003DzvKKZp3E_003D(_0023_003DzXfg_H7A_003D, _0023_003Dzp0yyV5KNKGJ6AHhLrA_003D_003D: false);
						IIfcFacetedBrep ifcFacetedBrep = (IIfcFacetedBrep)item3;
						Mesh mesh4 = _0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(_0023_003DzvsmK3IZVxuY3p9OlBt0VVtS1X57X(ifcFacetedBrep.Outer).ToArray(), 0, Mesh.natureType.Smooth);
						mesh4.Weld(_0023_003Dz3SYTYmqUDCDS(mesh4));
						_0023_003DzvKKZp3E_003D4._0023_003Dz_GDhuLDHzFup = mesh4.ConvertToSolid();
						_0023_003DzvKKZp3E_003D4._0023_003Dz_GDhuLDHzFup.TransformBy(xform);
						mesh4.TransformBy(transformation);
						_0023_003DzEmS3qUErVFPU(mesh4, item3, _0023_003DzELu0Pss_003D);
						if (mesh4.LayerName.Equals(Layer.DefaultLayerName))
						{
							IIfcPresentationLayerAssignment[] array2 = ifcFacetedBrep.LayerAssignment.ToArray();
							if (array2.Length != 0)
							{
								_0023_003DzvoVaxJKxgc_0024O(mesh4, array2[0]);
							}
						}
						_0023_003DzInI7ln34nx45Ys0iLQ_003D_003D.Add(mesh4);
						_0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D.Add(_0023_003DzvKKZp3E_003D4);
					}
					continue;
				}
				foreach (IIfcRepresentationItem item4 in representation.Items)
				{
					_0023_003DzvKKZp3E_003D _0023_003DzvKKZp3E_003D5 = new _0023_003DzvKKZp3E_003D(_0023_003DzXfg_H7A_003D, _0023_003Dzp0yyV5KNKGJ6AHhLrA_003D_003D: true);
					IIfcExtrudedAreaSolid ifcExtrudedAreaSolid = (IIfcExtrudedAreaSolid)item4;
					Transformation xform4 = ((ifcExtrudedAreaSolid.Position != null) ? ((Transformation)new Align3D(Plane.XY, _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcExtrudedAreaSolid.Position))) : ((Transformation)new Identity()));
					Point3D _0023_003DzbUvT9Pc_003D;
					devDept.Eyeshot.Entities.Region region = _0023_003DzhikIXWXUjVB78a7HKQ_003D_003D(ifcExtrudedAreaSolid.SweptArea, out _0023_003DzbUvT9Pc_003D, _0023_003DzELu0Pss_003D._0023_003DzUCYe4mP3BECb);
					if (region == null)
					{
						continue;
					}
					region.TransformBy(xform4);
					_0023_003DzELu0Pss_003D._0023_003DzncyYYSlCYRMY = (devDept.Eyeshot.Entities.Region)region.Clone();
					region.TransformBy(xform);
					_0023_003DzvKKZp3E_003D5._0023_003DzjwwTdlk_003D = region;
					Vector3D vector3D = ifcExtrudedAreaSolid.ExtrudedDirection._0023_003DzdVv0tHg0zCjX();
					vector3D.TransformBy(xform4);
					_0023_003DzELu0Pss_003D._0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D = vector3D * ifcExtrudedAreaSolid.Depth;
					vector3D.TransformBy(xform);
					_0023_003DzvKKZp3E_003D5._0023_003DzOrvwLqwuFjhymoEUbA_003D_003D = vector3D;
					_0023_003DzvKKZp3E_003D5._0023_003DzBBxiIYOTA9ilC6t1CQ_003D_003D = ifcExtrudedAreaSolid.Depth;
					_0023_003DzvKKZp3E_003D5._0023_003DzzwJZRoc_003D = _0023_003DzHA1826c_003D(region, _0023_003Dzyeosjja2eCus: true);
					Mesh mesh5 = region.ExtrudeAsMesh(vector3D * _0023_003DzvKKZp3E_003D5._0023_003DzBBxiIYOTA9ilC6t1CQ_003D_003D, _0023_003DzvKKZp3E_003D5._0023_003DzzwJZRoc_003D, 0.0, Mesh.natureType.Smooth);
					if (!_0023_003Dz55f9J0JIXjQHa_Xsbw_003D_003D)
					{
						mesh5.TransformBy(_0023_003DzWCq3uvYlfUGo);
					}
					_0023_003DzEmS3qUErVFPU(mesh5, item4, _0023_003DzELu0Pss_003D);
					if (mesh5.LayerName.Equals(Layer.DefaultLayerName))
					{
						IIfcPresentationLayerAssignment[] array3 = ifcExtrudedAreaSolid.LayerAssignment.ToArray();
						if (array3.Length != 0)
						{
							_0023_003DzvoVaxJKxgc_0024O(mesh5, array3[0]);
						}
					}
					_0023_003DzInI7ln34nx45Ys0iLQ_003D_003D.Add(mesh5);
					_0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D.Add(_0023_003DzvKKZp3E_003D5);
				}
			}
		}
		foreach (Mesh item5 in _0023_003DzInI7ln34nx45Ys0iLQ_003D_003D)
		{
			_0023_003Dzm_2oKiw_003D(item5, _0023_003Dz6WqznVKBiUxe, _0023_003Dzh_yiJh5c8f5N, transformation, _0023_003DzELu0Pss_003D);
		}
		return _0023_003DzDS9_0024pgG94mZ9CqvdsA_003D_003D.Count > 0;
	}

	private Transformation _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(IIfcObjectPlacement _0023_003DzcV2NSR7fQAUh, out Transformation _0023_003Dzh_yiJh5c8f5N, out Transformation _0023_003DzWCq3uvYlfUGo)
	{
		_0023_003Dzh_yiJh5c8f5N = new Identity();
		_0023_003DzWCq3uvYlfUGo = new Identity();
		Transformation _0023_003DzWCq3uvYlfUGo2;
		Transformation _0023_003Dzh_yiJh5c8f5N2;
		if (_0023_003DzcV2NSR7fQAUh is IIfcLocalPlacement ifcLocalPlacement)
		{
			try
			{
				Plane to = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D((IIfcPlacement)ifcLocalPlacement.RelativePlacement);
				_0023_003Dzh_yiJh5c8f5N = Transformation.CreateAlignment(Plane.XY, to);
				if (ifcLocalPlacement.PlacementRelTo == null)
				{
					return _0023_003Dzh_yiJh5c8f5N;
				}
				_0023_003DzWCq3uvYlfUGo = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(ifcLocalPlacement.PlacementRelTo, out _0023_003DzWCq3uvYlfUGo2, out _0023_003Dzh_yiJh5c8f5N2);
				return _0023_003DzWCq3uvYlfUGo * _0023_003Dzh_yiJh5c8f5N;
			}
			catch (Exception)
			{
				return Transformation.CreateIdentity();
			}
		}
		if (_0023_003DzcV2NSR7fQAUh is IIfcGridPlacement)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006340));
		}
		if (_0023_003DzcV2NSR7fQAUh is IfcLinearPlacement ifcLinearPlacement)
		{
			Plane to2 = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcLinearPlacement.RelativePlacement);
			_0023_003Dzh_yiJh5c8f5N = Transformation.CreateAlignment(Plane.XY, to2);
			if (ifcLinearPlacement.PlacementRelTo == null)
			{
				return _0023_003Dzh_yiJh5c8f5N;
			}
			_0023_003DzWCq3uvYlfUGo = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(ifcLinearPlacement.PlacementRelTo, out _0023_003Dzh_yiJh5c8f5N2, out _0023_003DzWCq3uvYlfUGo2);
			return _0023_003DzWCq3uvYlfUGo * _0023_003Dzh_yiJh5c8f5N;
		}
		return Transformation.CreateIdentity();
	}

	private Plane _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(IIfcPlacement _0023_003DzpdeSbFA_003D)
	{
		Point3D point3D = Point3D.Origin;
		Vector3D x = null;
		Vector3D vector3D = null;
		if (!(_0023_003DzpdeSbFA_003D is IfcAxis2PlacementLinear ifcAxis2PlacementLinear))
		{
			if (_0023_003DzpdeSbFA_003D is IIfcAxis1Placement ifcAxis1Placement)
			{
				point3D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(ifcAxis1Placement.Location);
				Vector3D n = ifcAxis1Placement.Z._0023_003DzdVv0tHg0zCjX();
				return new Plane(point3D, n);
			}
			if (!(_0023_003DzpdeSbFA_003D is IIfcAxis2Placement2D ifcAxis2Placement2D))
			{
				if (_0023_003DzpdeSbFA_003D is IIfcAxis2Placement3D ifcAxis2Placement3D)
				{
					point3D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(ifcAxis2Placement3D.Location);
					x = ifcAxis2Placement3D.P[0]._0023_003DzdVv0tHg0zCjX();
					if (x.IsZero)
					{
						x = Vector3D.AxisX;
					}
					Vector3D vector3D2 = ifcAxis2Placement3D.P[2]._0023_003DzdVv0tHg0zCjX();
					vector3D = Vector3D.Cross(vector3D2, x);
					x = Vector3D.Cross(vector3D, vector3D2);
				}
			}
			else
			{
				point3D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(ifcAxis2Placement2D.Location);
				x = ifcAxis2Placement2D.P[0]._0023_003DzdVv0tHg0zCjX();
				vector3D = ifcAxis2Placement2D.P[1]._0023_003DzdVv0tHg0zCjX();
			}
		}
		else
		{
			IfcPointByDistanceExpression ifcPointByDistanceExpression = ifcAxis2PlacementLinear.Location as IfcPointByDistanceExpression;
			if (ifcPointByDistanceExpression != null)
			{
				ICurve curve = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcPointByDistanceExpression.BasisCurve, _0023_003DzXSrUO6ixqq8l: false, null, null);
				double num = ifcPointByDistanceExpression.OffsetLateral ?? ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)0.0);
				double num2 = ifcPointByDistanceExpression.OffsetVertical ?? ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)0.0);
				double num3 = ifcPointByDistanceExpression.OffsetLongitudinal ?? ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)0.0);
				Vector3D vector3D3 = new Vector3D(0.0, 0.0, 0.0);
				if (ifcPointByDistanceExpression.DistanceAlong is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure ifcLengthMeasure)
				{
					curve.GetParamFromLength(ifcLengthMeasure, out var t);
					point3D = curve.PointAt(t);
					vector3D3 = curve.TangentAt(t);
				}
				else if (ifcPointByDistanceExpression.DistanceAlong is Xbim.Ifc4x3.MeasureResource.IfcParameterValue ifcParameterValue)
				{
					point3D = curve.PointAt(ifcParameterValue);
					vector3D3 = curve.TangentAt(ifcParameterValue);
					vector3D3.Normalize();
				}
				if (vector3D3.IsZero)
				{
					vector3D3 = Vector3D.AxisX;
				}
				Vector3D a = ifcAxis2PlacementLinear.Axis?._0023_003DzdVv0tHg0zCjX() ?? Vector3D.AxisZ;
				x = ifcAxis2PlacementLinear.RefDirection?._0023_003DzdVv0tHg0zCjX() ?? vector3D3;
				if (Vector3D.Cross(a, x).IsZero)
				{
					a = Vector3D.AxisZ;
				}
				vector3D = Vector3D.Cross(a, x);
				vector3D.Normalize();
				Vector3D vector3D4 = Vector3D.Cross(new Vector3D(0.0, 0.0, 1.0), vector3D3);
				vector3D4.Normalize();
				Vector3D vector3D5 = Vector3D.Cross(vector3D3, vector3D4);
				vector3D5.Normalize();
				return new Plane(point3D + num * vector3D4 + num2 * vector3D5 + num3 * vector3D3, x, vector3D);
			}
		}
		return new Plane(point3D, x, vector3D);
	}

	private CylindricalSurf _0023_003Dz90G3o8Uyrw_uF_0024pkTixQ9HLsGjOOB5ROfi95b4I_003D(IIfcCylindricalSurface _0023_003Dzn3usivtnLmKDg999jw_003D_003D)
	{
		Plane plane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(_0023_003Dzn3usivtnLmKDg999jw_003D_003D.Position);
		return new CylindricalSurf(plane.Origin, plane.AxisZ, plane.AxisX, _0023_003Dzn3usivtnLmKDg999jw_003D_003D.Radius);
	}

	private IfcContainer _0023_003DztvHhs7hpJmYvEQOFYc3592o_003D(IIfcSpatialElement _0023_003Dzc9HglY5Q_ldJ)
	{
		IfcContainer ifcContainer = new IfcContainer();
		try
		{
			Transformation _0023_003Dzh_yiJh5c8f5N = new Identity();
			Transformation transformation = new Identity();
			if (_0023_003Dzc9HglY5Q_ldJ.ObjectPlacement != null)
			{
				transformation = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(_0023_003Dzc9HglY5Q_ldJ.ObjectPlacement, out _0023_003Dzh_yiJh5c8f5N, out var _);
			}
			_0023_003Dzm_2oKiw_003D(ifcContainer, _0023_003Dzc9HglY5Q_ldJ, _0023_003Dzh_yiJh5c8f5N, transformation);
			if (_0023_003Dzc9HglY5Q_ldJ.Representation != null)
			{
				try
				{
					_0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D = new _0023_003DzcntdzPM_003D();
					Entity entity = _0023_003DzwbGwnpc3qQYQ99uang_003D_003D(_0023_003Dzc9HglY5Q_ldJ.Representation, ref _0023_003DzELu0Pss_003D);
					if (entity != null)
					{
						entity.TransformBy(transformation);
						foreach (Entity item in _0023_003DzELu0Pss_003D._0023_003DzVFJEgOr2cL2N)
						{
							item.TransformBy(transformation);
						}
						_0023_003Dzm_2oKiw_003D(entity, _0023_003Dzc9HglY5Q_ldJ, _0023_003Dzh_yiJh5c8f5N, transformation, _0023_003DzELu0Pss_003D);
						entity.IfcProperties.Parent = ifcContainer.GUID;
						_0023_003DzfT1LlfmL1u0t.Add(entity);
						ifcContainer.ContainedElements.Add(entity.IfcProperties.GUID);
					}
					else
					{
						log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007057), _0023_003Dzc9HglY5Q_ldJ.ExpressType.ExpressName, _0023_003Dzc9HglY5Q_ldJ.EntityLabel));
						log.AppendLine();
					}
				}
				catch (Exception ex)
				{
					log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007011), _0023_003Dzc9HglY5Q_ldJ.ExpressType.ExpressName, _0023_003Dzc9HglY5Q_ldJ.EntityLabel, ex.Message));
					log.AppendLine();
				}
			}
			foreach (IIfcRelServicesBuildings servicedBySystem in _0023_003Dzc9HglY5Q_ldJ.ServicedBySystems)
			{
				Dictionary<string, string> systems = Systems;
				string key = servicedBySystem.RelatingSystem.GlobalId;
				Xbim.Ifc4.MeasureResource.IfcLabel? name = servicedBySystem.RelatingSystem.Name;
				systems[key] = (name.HasValue ? ((string)name.GetValueOrDefault()) : null);
				ifcContainer.Systems.Add(servicedBySystem.RelatingSystem.GlobalId);
			}
			foreach (IIfcRelAggregates item2 in _0023_003Dzc9HglY5Q_ldJ.IsDecomposedBy)
			{
				foreach (IIfcObjectDefinition relatedObject in item2.RelatedObjects)
				{
					if (relatedObject is IIfcSpatialElement _0023_003Dzc9HglY5Q_ldJ2)
					{
						IfcContainer ifcContainer2 = _0023_003DztvHhs7hpJmYvEQOFYc3592o_003D(_0023_003Dzc9HglY5Q_ldJ2);
						ifcContainer2.Parent = ifcContainer.GUID;
						Containers.Add(ifcContainer2.GUID, ifcContainer2);
						ifcContainer.Childs.Add(ifcContainer2.GUID);
					}
				}
			}
			foreach (IIfcRelContainedInSpatialStructure containsElement in _0023_003Dzc9HglY5Q_ldJ.ContainsElements)
			{
				foreach (IIfcProduct relatedElement in containsElement.RelatedElements)
				{
					if (relatedElement is IIfcSpatialElement _0023_003Dzc9HglY5Q_ldJ3)
					{
						IfcContainer ifcContainer3 = _0023_003DztvHhs7hpJmYvEQOFYc3592o_003D(_0023_003Dzc9HglY5Q_ldJ3);
						ifcContainer3.Parent = ifcContainer.GUID;
						Containers.Add(ifcContainer3.GUID, ifcContainer3);
						ifcContainer.Childs.Add(ifcContainer3.GUID);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303005815), _0023_003Dzc9HglY5Q_ldJ.ExpressType.ExpressName, _0023_003Dzc9HglY5Q_ldJ.EntityLabel, ex2.Message));
			log.AppendLine();
		}
		return ifcContainer;
	}

	private Entity _0023_003DzJhImNRGbnkk2Tk5l2g_003D_003D(IIfcProduct _0023_003Dzj4aaFEXnJbfi, bool _0023_003Dz3Lip_W0_003D)
	{
		Entity entity = null;
		Transformation _0023_003Dzh_yiJh5c8f5N = new Identity();
		Transformation _0023_003DzWCq3uvYlfUGo = new Identity();
		Transformation transformation = new Identity();
		bool flag = false;
		_0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D = new _0023_003DzcntdzPM_003D();
		if (_0023_003Dzj4aaFEXnJbfi.ObjectPlacement != null)
		{
			transformation = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(_0023_003Dzj4aaFEXnJbfi.ObjectPlacement, out _0023_003Dzh_yiJh5c8f5N, out _0023_003DzWCq3uvYlfUGo);
		}
		if (_0023_003Dzj4aaFEXnJbfi.Representation != null)
		{
			_0023_003DzwYO9yMKu2gUgMxzgogDUe4A_003D = _0023_003Dzj4aaFEXnJbfi.ExpressType.ExpressName.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007201));
			entity = _0023_003DzwbGwnpc3qQYQ99uang_003D_003D(_0023_003Dzj4aaFEXnJbfi.Representation, ref _0023_003DzELu0Pss_003D);
			foreach (Entity item in _0023_003DzELu0Pss_003D._0023_003DzVFJEgOr2cL2N)
			{
				item.TransformBy(transformation);
			}
		}
		IIfcRelAggregates[] array = _0023_003Dzj4aaFEXnJbfi.IsDecomposedBy.ToArray();
		if (_0023_003Dz3Lip_W0_003D || array.Length != 0)
		{
			entity?.TransformBy(transformation);
			flag = true;
		}
		if (array.Length != 0)
		{
			Xbim.Ifc4.MeasureResource.IfcLabel? name = _0023_003Dzj4aaFEXnJbfi.Name;
			object obj;
			if (!string.IsNullOrEmpty(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
			{
				name = _0023_003Dzj4aaFEXnJbfi.Name;
				obj = (name.HasValue ? ((string)name.GetValueOrDefault()) : null);
			}
			else
			{
				obj = _0023_003Dzj4aaFEXnJbfi.ExpressType.ExpressName;
			}
			Block block = new Block((string)obj + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990142) + _0023_003Dzj4aaFEXnJbfi.EntityLabel);
			if (entity != null)
			{
				entity.TranslationID = new TranslationIdentifier(_0023_003Dzj4aaFEXnJbfi.Representation.EntityLabel);
				block.Entities.Add(entity);
			}
			IIfcRelAggregates[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				foreach (IIfcObjectDefinition relatedObject in array2[i].RelatedObjects)
				{
					if (relatedObject is IIfcProduct _0023_003Dzj4aaFEXnJbfi2)
					{
						Entity entity2 = _0023_003DzJhImNRGbnkk2Tk5l2g_003D_003D(_0023_003Dzj4aaFEXnJbfi2, _0023_003Dz3Lip_W0_003D: true);
						if (entity2 != null)
						{
							block.Entities.Add(entity2);
							entity2.IfcProperties.Parent = _0023_003Dzj4aaFEXnJbfi.GlobalId;
						}
					}
				}
			}
			base.Blocks.Add(block);
			entity = new BlockReference(block.Name);
		}
		IIfcElement ifcElement = _0023_003Dzj4aaFEXnJbfi as IIfcElement;
		if (entity != null)
		{
			List<Entity> _0023_003DzMvFiRUUx9XO5q71hqA_003D_003D = null;
			if (ifcElement != null)
			{
				IIfcRelVoidsElement[] array3 = ifcElement.HasOpenings.ToArray();
				if (array3.Length != 0)
				{
					if (entity is Brep)
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007193));
					}
					if (!flag)
					{
						_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2 = new _0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D();
						_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzlKP95AsKNRhVeKTJ7Q_003D_003D = _0023_003Dzj4aaFEXnJbfi.ObjectPlacement?.EntityLabel;
						if (array3.Any(_0023_003DzvlXWrN9Rs4Six7P3F6bLHiw_003D2._0023_003DzjY_YNB9osCWQeTDM0VO0NAQ_003D))
						{
							entity.TransformBy(transformation);
							flag = true;
						}
					}
					entity = _0023_003DzwHiRxkxT20ku8q6D3w_003D_003D(entity, ifcElement, flag, out _0023_003DzMvFiRUUx9XO5q71hqA_003D_003D);
				}
			}
			if (!flag)
			{
				entity.TransformBy(transformation);
			}
			_0023_003Dzm_2oKiw_003D(entity, _0023_003Dzj4aaFEXnJbfi, _0023_003Dzh_yiJh5c8f5N, transformation, _0023_003DzELu0Pss_003D);
			entity.IfcProperties.Openings = _0023_003DzMvFiRUUx9XO5q71hqA_003D_003D;
			return entity;
		}
		if (ifcElement == null)
		{
			return null;
		}
		IIfcRelFillsElement[] array4 = ifcElement.FillsVoids.ToArray();
		if (array4.Length != 0)
		{
			IIfcOpeningElement relatingOpeningElement = array4[0].RelatingOpeningElement;
			if (relatingOpeningElement.Representation != null)
			{
				Transformation xform = new Identity();
				if (relatingOpeningElement.ObjectPlacement != null)
				{
					xform = _0023_003DzTrxd5VppjIPt1Pad_A_003D_003D(relatingOpeningElement.ObjectPlacement, out var _, out var _);
				}
				entity = _0023_003DzwbGwnpc3qQYQ99uang_003D_003D(relatingOpeningElement.Representation, ref _0023_003DzELu0Pss_003D);
				entity?.TransformBy(xform);
				_0023_003Dzm_2oKiw_003D(entity, _0023_003Dzj4aaFEXnJbfi, _0023_003Dzh_yiJh5c8f5N, transformation, _0023_003DzELu0Pss_003D);
				return entity;
			}
		}
		return null;
	}

	private Entity _0023_003DzwbGwnpc3qQYQ99uang_003D_003D(IIfcProductRepresentation _0023_003DzhvQqzqfrM2tZ, ref _0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (IIfcRepresentation representation in _0023_003DzhvQqzqfrM2tZ.Representations)
		{
			string text = representation.RepresentationIdentifier ?? ((Xbim.Ifc4.MeasureResource.IfcLabel)string.Empty);
			if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006445)) || text.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007106)) || text.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006426)))
			{
				Entity[] collection = _0023_003DzC4gSMQjGqwdAPi7nMQ_003D_003D(representation, ref _0023_003DzELu0Pss_003D);
				list.AddRange(collection);
			}
			else if (text.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006833)))
			{
				foreach (IIfcRepresentationItem item in representation.Items)
				{
					if (item is IIfcCurve _0023_003DzYbZQw3SBCmck)
					{
						ICurve curve = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(_0023_003DzYbZQw3SBCmck, _0023_003DzXSrUO6ixqq8l: false, null, null);
						if (curve != null)
						{
							_0023_003DzELu0Pss_003D._0023_003DzVFJEgOr2cL2N.Add(curve);
						}
					}
				}
			}
			else
			{
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006846), text, _0023_003DzhvQqzqfrM2tZ.ExpressType.ExpressName, _0023_003DzhvQqzqfrM2tZ.EntityLabel));
			}
		}
		if (list.Count > 1)
		{
			Block block = new Block(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006764) + _0023_003DzhvQqzqfrM2tZ.EntityLabel);
			block.Entities.AddRange(list);
			base.Blocks.Add(block);
			return new BlockReference(block.Name);
		}
		if (list.Count != 0)
		{
			return list[0];
		}
		return null;
	}

	private Entity[] _0023_003DzC4gSMQjGqwdAPi7nMQ_003D_003D(IIfcRepresentation _0023_003DzPeT2qoI_003D, ref _0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (IIfcRepresentationItem item in _0023_003DzPeT2qoI_003D.Items)
		{
			Entity entity = _0023_003DzVYn8KqEjagTAVbuOCQ_003D_003D(item, ref _0023_003DzELu0Pss_003D);
			if (entity == null)
			{
				continue;
			}
			_0023_003DzEmS3qUErVFPU(entity, item, _0023_003DzELu0Pss_003D);
			if (entity.LayerName.Equals(Layer.DefaultLayerName))
			{
				IIfcPresentationLayerAssignment[] array = _0023_003DzPeT2qoI_003D.LayerAssignments.ToArray();
				if (array.Length != 0)
				{
					_0023_003DzvoVaxJKxgc_0024O(entity, array[0]);
				}
				else
				{
					if (!base.Layers.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578)))
					{
						base.Layers.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578));
					}
					entity.LayerName = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006578);
				}
			}
			list.Add(entity);
		}
		return list.ToArray();
	}

	private bool _0023_003DzMAxShrbxTEQp(ICurve _0023_003Dzv_7IeQibaTXs, ICurve _0023_003DzNpfDgu2nb0Hr, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		if (_0023_003Dzv_7IeQibaTXs.GetType() != _0023_003DzNpfDgu2nb0Hr.GetType())
		{
			return false;
		}
		double num = _0023_003DzuMKQhOieejyEvhtVOw_003D_003D * _0023_003DzuMKQhOieejyEvhtVOw_003D_003D;
		double _0023_003DzxhnLabVjXjPg = Utility._0023_003DzxhnLabVjXjPg;
		double num2 = Math.PI * 2.0 * _0023_003DzxhnLabVjXjPg;
		if (_0023_003Dzv_7IeQibaTXs is CompositeCurve compositeCurve && _0023_003DzNpfDgu2nb0Hr is CompositeCurve compositeCurve2)
		{
			if (compositeCurve.CurveList.Count != compositeCurve2.CurveList.Count)
			{
				return false;
			}
			int count = compositeCurve.CurveList.Count;
			for (int i = 0; i < count; i++)
			{
				bool flag = false;
				for (int j = 0; j < count; j++)
				{
					int index = (i + j) % count;
					if (_0023_003DzMAxShrbxTEQp(compositeCurve.CurveList[i], compositeCurve2.CurveList[index], _0023_003DzuMKQhOieejyEvhtVOw_003D_003D))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}
		if (_0023_003Dzv_7IeQibaTXs is LinearPath linearPath && _0023_003DzNpfDgu2nb0Hr is LinearPath linearPath2)
		{
			if (linearPath.Vertices.Length != linearPath2.Vertices.Length)
			{
				return false;
			}
			for (int k = 0; k < linearPath.Vertices.Length; k++)
			{
				if (Point3D.DistanceSquared(linearPath.Vertices[k], linearPath2.Vertices[k]) > num)
				{
					return false;
				}
			}
			return true;
		}
		if (_0023_003Dzv_7IeQibaTXs is PlanarEntity planarEntity && _0023_003DzNpfDgu2nb0Hr is PlanarEntity planarEntity2)
		{
			if (!Vector3D.AreCoincident(planarEntity.Plane.AxisZ, planarEntity2.Plane.AxisZ, num2) || !Vector3D.AreCoincident(planarEntity.Plane.AxisX, planarEntity2.Plane.AxisX, num2))
			{
				return false;
			}
			if (_0023_003Dzv_7IeQibaTXs is Arc arc && _0023_003DzNpfDgu2nb0Hr is Arc arc2)
			{
				if (Math.Abs(arc.Radius - arc2.Radius) <= _0023_003DzuMKQhOieejyEvhtVOw_003D_003D && Math.Abs(arc.Domain.Min - arc2.Domain.Min) <= num2 && Math.Abs(arc.Domain.Max - arc2.Domain.Max) <= num2)
				{
					return Point3D.DistanceSquared(arc.Center, arc2.Center) <= num;
				}
				return false;
			}
			if (_0023_003Dzv_7IeQibaTXs is Circle circle && _0023_003DzNpfDgu2nb0Hr is Circle circle2)
			{
				if (Math.Abs(circle.Radius - circle2.Radius) <= _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
				{
					return Point3D.DistanceSquared(circle.Center, circle2.Center) <= num;
				}
				return false;
			}
			if (_0023_003Dzv_7IeQibaTXs is EllipticalArc ellipticalArc && _0023_003DzNpfDgu2nb0Hr is EllipticalArc ellipticalArc2)
			{
				if (Math.Abs(ellipticalArc.RadiusX - ellipticalArc2.RadiusX) <= _0023_003DzuMKQhOieejyEvhtVOw_003D_003D && Math.Abs(ellipticalArc.RadiusY - ellipticalArc2.RadiusY) <= _0023_003DzuMKQhOieejyEvhtVOw_003D_003D && Math.Abs(ellipticalArc.Domain.Min - ellipticalArc2.Domain.Min) <= num2 && Math.Abs(ellipticalArc.Domain.Max - ellipticalArc2.Domain.Max) <= num2)
				{
					return Point3D.DistanceSquared(ellipticalArc.Center, ellipticalArc2.Center) <= num;
				}
				return false;
			}
			if (_0023_003Dzv_7IeQibaTXs is Ellipse ellipse && _0023_003DzNpfDgu2nb0Hr is Ellipse ellipse2)
			{
				if (Math.Abs(ellipse.RadiusX - ellipse2.RadiusX) <= _0023_003DzuMKQhOieejyEvhtVOw_003D_003D && Math.Abs(ellipse.RadiusY - ellipse2.RadiusY) <= _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
				{
					return Point3D.DistanceSquared(ellipse.Center, ellipse2.Center) <= num;
				}
				return false;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006731) + _0023_003Dzv_7IeQibaTXs.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006967));
		}
		if (_0023_003Dzv_7IeQibaTXs is Line line && _0023_003DzNpfDgu2nb0Hr is Line line2)
		{
			if (Point3D.DistanceSquared(line.StartPoint, line2.StartPoint) <= num)
			{
				return Point3D.DistanceSquared(line.EndPoint, line2.EndPoint) <= num;
			}
			return false;
		}
		if (_0023_003Dzv_7IeQibaTXs is Curve curve && _0023_003DzNpfDgu2nb0Hr is Curve curve2)
		{
			if (curve.Degree != curve2.Degree || curve.KnotVector.Length != curve2.KnotVector.Length || curve.ControlPoints.Length != curve2.ControlPoints.Length)
			{
				return false;
			}
			for (int l = 0; l < curve.ControlPoints.Length; l++)
			{
				if (Point3D.DistanceSquared(curve.ControlPoints[l].Euclid, curve2.ControlPoints[l].Euclid) > num)
				{
					return false;
				}
			}
			double num3 = ((curve.Domain.Length < curve2.Domain.Length) ? (curve.Domain.Length * _0023_003DzxhnLabVjXjPg) : (curve2.Domain.Length * _0023_003DzxhnLabVjXjPg));
			if (Math.Abs(curve.Domain.Length - curve2.Domain.Length) > num3)
			{
				return false;
			}
			for (int m = 0; m < curve.KnotVector.Length; m++)
			{
				if (Math.Abs(curve.KnotVector[m] - curve2.KnotVector[m]) > num3)
				{
					return false;
				}
			}
			return true;
		}
		throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006731) + _0023_003Dzv_7IeQibaTXs.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006967));
	}

	private Entity _0023_003DzVYn8KqEjagTAVbuOCQ_003D_003D(IIfcRepresentationItem _0023_003DzMqRbkVw_003D, ref _0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D)
	{
		Entity entity = null;
		if (_0023_003DzJbrxuN7FfKk4.TryGetValue(_0023_003DzMqRbkVw_003D.EntityLabel, out var value))
		{
			entity = (Entity)value.Item1.Clone();
			_0023_003DzELu0Pss_003D = (_0023_003DzcntdzPM_003D)value.Item2._0023_003Dzx9P_oXY_003D();
		}
		else
		{
			try
			{
				if (!(_0023_003DzMqRbkVw_003D is IIfcBooleanResult _0023_003Dz5I3b_GM_003D))
				{
					if (!(_0023_003DzMqRbkVw_003D is IIfcVertexPoint ifcVertexPoint))
					{
						if (!(_0023_003DzMqRbkVw_003D is IIfcEdge ifcEdge))
						{
							if (!(_0023_003DzMqRbkVw_003D is IIfcCurve _0023_003DzYbZQw3SBCmck))
							{
								if (!(_0023_003DzMqRbkVw_003D is IIfcSweptAreaSolid ifcSweptAreaSolid))
								{
									if (!(_0023_003DzMqRbkVw_003D is IIfcSweptDiskSolid ifcSweptDiskSolid))
									{
										if (!(_0023_003DzMqRbkVw_003D is IfcSectionedSolidHorizontal ifcSectionedSolidHorizontal))
										{
											if (!(_0023_003DzMqRbkVw_003D is IIfcFaceBasedSurfaceModel ifcFaceBasedSurfaceModel))
											{
												if (!(_0023_003DzMqRbkVw_003D is IIfcFacetedBrep ifcFacetedBrep))
												{
													if (!(_0023_003DzMqRbkVw_003D is IIfcAdvancedBrep _0023_003DzrWf8wilNJTcF))
													{
														if (!(_0023_003DzMqRbkVw_003D is IIfcMappedItem ifcMappedItem))
														{
															if (!(_0023_003DzMqRbkVw_003D is IIfcShellBasedSurfaceModel ifcShellBasedSurfaceModel))
															{
																if (_0023_003DzMqRbkVw_003D is IIfcTessellatedFaceSet ifcTessellatedFaceSet)
																{
																	if (ifcTessellatedFaceSet.Coordinates.CoordList.Count == 0)
																	{
																		log.AppendLine(_0023_003DzMqRbkVw_003D.ExpressType.ExpressName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007697));
																	}
																	else
																	{
																		IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure>> coordList = ifcTessellatedFaceSet.Coordinates.CoordList;
																		Point3D[] array = new Point3D[coordList.Count];
																		for (int i = 0; i < coordList.Count; i++)
																		{
																			IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure> itemSet = coordList[i];
																			array[i] = new Point3D(itemSet[0], itemSet[1], itemSet[2]);
																		}
																		if (_0023_003DzMqRbkVw_003D is IIfcTriangulatedFaceSet ifcTriangulatedFaceSet)
																		{
																			if (ifcTriangulatedFaceSet.NumberOfTriangles == 0L)
																			{
																				log.AppendLine(_0023_003DzMqRbkVw_003D.ExpressType.ExpressName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007691));
																			}
																			else
																			{
																				IndexTriangle[] array2 = new IndexTriangle[ifcTriangulatedFaceSet.CoordIndex.Count];
																				for (int j = 0; j < ifcTriangulatedFaceSet.CoordIndex.Count; j++)
																				{
																					IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> itemSet2 = ifcTriangulatedFaceSet.CoordIndex[j];
																					array2[j] = new SmoothTriangle((int)(long)itemSet2[0] - 1, (int)(long)itemSet2[1] - 1, (int)(long)itemSet2[2] - 1);
																				}
																				entity = new Mesh(array.ToList(), array2.ToList());
																			}
																		}
																		else
																		{
																			IItemSet<IIfcIndexedPolygonalFace> faces = (_0023_003DzMqRbkVw_003D as IIfcPolygonalFaceSet).Faces;
																			List<Mesh> list = new List<Mesh>(faces.Count);
																			foreach (IIfcIndexedPolygonalFace item in faces)
																			{
																				Point3D[] array3 = new Point3D[item.CoordIndex.Count + 1];
																				Point3D[][] array4 = new Point3D[0][];
																				for (int k = 0; k < item.CoordIndex.Count; k++)
																				{
																					array3[k] = (Point3D)array[(long)item.CoordIndex[k] - 1].Clone();
																				}
																				array3[item.CoordIndex.Count] = (Point3D)array3[0].Clone();
																				if (item is IIfcIndexedPolygonalFaceWithVoids { InnerCoordIndices: var innerCoordIndices })
																				{
																					array4 = new Point3D[innerCoordIndices.Count][];
																					for (int l = 0; l < innerCoordIndices.Count; l++)
																					{
																						IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> itemSet3 = innerCoordIndices[l];
																						array4[l] = new Point3D[itemSet3.Count + 1];
																						for (int m = 0; m < itemSet3.Count; m++)
																						{
																							array4[l][m] = (Point3D)array[(long)itemSet3[m] - 1].Clone();
																						}
																						array4[l][itemSet3.Count] = (Point3D)array4[l][0].Clone();
																					}
																				}
																				list.Add(Mesh.CreatePlanar(array3.ToList(), array4, Mesh.natureType.Smooth));
																			}
																			Mesh mesh = _0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(list.ToArray(), 0, Mesh.natureType.Smooth);
																			mesh.Weld();
																			entity = mesh;
																		}
																	}
																}
															}
															else
															{
																IItemSet<IIfcShell> sbsmBoundary = ifcShellBasedSurfaceModel.SbsmBoundary;
																List<Mesh> list2 = new List<Mesh>();
																foreach (IIfcConnectedFaceSet item2 in sbsmBoundary)
																{
																	list2.AddRange(_0023_003DzvsmK3IZVxuY3p9OlBt0VVtS1X57X(item2));
																}
																if (list2.Count > 0)
																{
																	entity = _0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(list2.ToArray(), 0, Mesh.natureType.Smooth);
																	((Mesh)entity).Weld(_0023_003Dz3SYTYmqUDCDS(entity));
																}
																else
																{
																	entity = null;
																	log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007551) + ifcShellBasedSurfaceModel.EntityLabel);
																}
															}
														}
														else
														{
															string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007588) + ifcMappedItem.MappingSource.EntityLabel;
															if (!base.Blocks.Contains(text))
															{
																IIfcRepresentationMap mappingSource = ifcMappedItem.MappingSource;
																Entity[] array5 = _0023_003DzC4gSMQjGqwdAPi7nMQ_003D_003D(mappingSource.MappedRepresentation, ref _0023_003DzELu0Pss_003D);
																Block block = new Block(text);
																if (array5.Length == 0)
																{
																	log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007578) + ifcMappedItem.MappingSource.EntityLabel);
																	return null;
																}
																Plane to = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D((IIfcPlacement)mappingSource.MappingOrigin);
																Transformation xform = Transformation.CreateAlignment(Plane.XY, to);
																Entity[] array6 = array5;
																foreach (Entity entity2 in array6)
																{
																	entity2.LayerName = Layer.DefaultLayerName;
																	entity2.TransformBy(xform);
																}
																block.Entities.AddRange(array5);
																base.Blocks.Add(block);
															}
															entity = new BlockReference(_0023_003Dzd1SOyu_9fyOH(ifcMappedItem), text);
														}
													}
													else
													{
														using (new _0023_003DzspExml1j72mr_FI04NKW780_003D())
														{
															entity = _0023_003DzPWY9kKNoXBrmVCwPBDzN2bY_003D(_0023_003DzrWf8wilNJTcF);
														}
													}
												}
												else
												{
													entity = _0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(_0023_003DzvsmK3IZVxuY3p9OlBt0VVtS1X57X(ifcFacetedBrep.Outer).ToArray(), 0, Mesh.natureType.Smooth);
													((Mesh)entity)?.Weld(_0023_003Dz3SYTYmqUDCDS(entity));
												}
											}
											else
											{
												IItemSet<IIfcConnectedFaceSet> fbsmFaces = ifcFaceBasedSurfaceModel.FbsmFaces;
												List<Mesh> list3 = new List<Mesh>();
												foreach (IIfcConnectedFaceSet item3 in fbsmFaces)
												{
													list3.AddRange(_0023_003DzvsmK3IZVxuY3p9OlBt0VVtS1X57X(item3));
												}
												if (list3.Count > 0)
												{
													entity = _0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(list3.ToArray(), 0, Mesh.natureType.Smooth);
													((Mesh)entity).Weld(_0023_003Dz3SYTYmqUDCDS(entity));
												}
												else
												{
													entity = null;
													log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006928) + ifcFaceBasedSurfaceModel.EntityLabel);
												}
											}
										}
										else
										{
											ICurve rail = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcSectionedSolidHorizontal.Directrix, _0023_003DzXSrUO6ixqq8l: false, null, null);
											int count = ifcSectionedSolidHorizontal.CrossSections.Count;
											ICurve[] array7 = new ICurve[count];
											for (int num = 0; num < count; num++)
											{
												array7[num] = _0023_003DzhikIXWXUjVB78a7HKQ_003D_003D(ifcSectionedSolidHorizontal.CrossSections[num], out var _, _0023_003DzELu0Pss_003D._0023_003DzUCYe4mP3BECb).ContourList[0];
											}
											for (int num2 = 0; num2 < count; num2++)
											{
												Plane plane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcSectionedSolidHorizontal.CrossSectionPositions[num2]);
												plane = new Plane(plane.Origin, plane.AxisY, plane.AxisZ);
												((Entity)array7[num2]).TransformBy(Transformation.CreateAlignment(Plane.XY, plane));
											}
											entity = Brep.Sweep(array7, rail).ConvertToMesh(_0023_003DzHA1826c_003D((Entity)array7[0], _0023_003DzELu0Pss_003D._0023_003DzUCYe4mP3BECb));
										}
									}
									else
									{
										ICurve curve = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcSweptDiskSolid.Directrix, _0023_003DzXSrUO6ixqq8l: false, null, null);
										if (ifcSweptDiskSolid.EndParam.HasValue)
										{
											curve.TrimAt(curve.Domain.Low + curve.Domain.Length * (double)ifcSweptDiskSolid.EndParam.Value, flipSide: false);
										}
										if (ifcSweptDiskSolid.StartParam.HasValue)
										{
											curve.TrimAt(curve.Domain.Low + curve.Domain.Length * (double)ifcSweptDiskSolid.StartParam.Value, flipSide: true);
										}
										Plane plane2 = new Plane(curve.StartPoint, curve.StartTangent);
										devDept.Eyeshot.Entities.Region region;
										if (!ifcSweptDiskSolid.InnerRadius.HasValue)
										{
											region = devDept.Eyeshot.Entities.Region.CreateCircle(plane2, ifcSweptDiskSolid.Radius);
										}
										else
										{
											Circle circle = new Circle(plane2, ifcSweptDiskSolid.Radius);
											Circle circle2 = new Circle(plane2, ifcSweptDiskSolid.InnerRadius.Value);
											region = new devDept.Eyeshot.Entities.Region(circle, circle2);
										}
										double num3 = _0023_003DzHA1826c_003D(region, _0023_003DzELu0Pss_003D._0023_003DzUCYe4mP3BECb);
										if (_0023_003DzwYO9yMKu2gUgMxzgogDUe4A_003D)
										{
											double num4 = num3 / 100.0;
											double num5 = _0023_003Dzqc5bga3nl8Op(curve);
											if (num5 < num4)
											{
												num4 = num5;
											}
											if (!ifcSweptDiskSolid.InnerRadius.HasValue)
											{
												for (int num6 = _0023_003DztTBUgMmHdpZ80d15og_003D_003D.Count - 1; num6 >= 0; num6--)
												{
													(double, ICurve, int) tuple = _0023_003DztTBUgMmHdpZ80d15og_003D_003D[num6];
													if (Math.Abs(tuple.Item1 - (double)ifcSweptDiskSolid.Radius) < num4 && _0023_003DzMAxShrbxTEQp(curve, tuple.Item2, num4))
													{
														Tuple<Entity, _0023_003DzcntdzPM_003D> tuple2 = _0023_003DzJbrxuN7FfKk4[tuple.Item3];
														entity = (Entity)tuple2.Item1.Clone();
														_0023_003DzELu0Pss_003D = (_0023_003DzcntdzPM_003D)tuple2.Item2._0023_003Dzx9P_oXY_003D();
														break;
													}
												}
											}
											if (entity == null)
											{
												entity = region.SweepAsMesh(curve, num3);
												if (!ifcSweptDiskSolid.InnerRadius.HasValue)
												{
													_0023_003DztTBUgMmHdpZ80d15og_003D_003D.Add((ifcSweptDiskSolid.Radius, curve, ifcSweptDiskSolid.EntityLabel));
												}
											}
										}
										else
										{
											entity = region.SweepAsSolid(curve, num3);
											if (_0023_003DzwYO9yMKu2gUgMxzgogDUe4A_003D)
											{
												((Solid)entity).SmoothingAngle = 0.8;
											}
										}
									}
								}
								else
								{
									Transformation xform2 = ((ifcSweptAreaSolid.Position != null) ? ((Transformation)new Align3D(Plane.XY, _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcSweptAreaSolid.Position))) : ((Transformation)new Identity()));
									Point3D _0023_003DzbUvT9Pc_003D2;
									devDept.Eyeshot.Entities.Region region2 = _0023_003DzhikIXWXUjVB78a7HKQ_003D_003D(ifcSweptAreaSolid.SweptArea, out _0023_003DzbUvT9Pc_003D2, _0023_003DzELu0Pss_003D._0023_003DzUCYe4mP3BECb);
									if (region2 != null)
									{
										region2.TransformBy(xform2);
										_0023_003DzELu0Pss_003D._0023_003DzncyYYSlCYRMY = region2;
										double num7 = _0023_003DzHA1826c_003D(region2, _0023_003DzELu0Pss_003D._0023_003DzUCYe4mP3BECb);
										if (!(ifcSweptAreaSolid is IIfcExtrudedAreaSolid ifcExtrudedAreaSolid))
										{
											if (!(ifcSweptAreaSolid is IIfcRevolvedAreaSolid { Axis: var axis } ifcRevolvedAreaSolid))
											{
												if (!(ifcSweptAreaSolid is IIfcSurfaceCurveSweptAreaSolid ifcSurfaceCurveSweptAreaSolid))
												{
													if (ifcSweptAreaSolid is IIfcFixedReferenceSweptAreaSolid)
													{
														log.AppendLine(ifcSweptAreaSolid.ExpressType.ExpressName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006959));
													}
												}
												else
												{
													ICurve curve2 = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcSurfaceCurveSweptAreaSolid.Directrix, _0023_003DzXSrUO6ixqq8l: false, null, null);
													((Entity)curve2).TransformBy(xform2);
													entity = region2.SweepAsSolid(curve2, num7, merge: true);
												}
											}
											else
											{
												Point3D point3D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(axis.Location);
												point3D.TransformBy(xform2);
												Vector3D vector3D = axis.Axis._0023_003DzdVv0tHg0zCjX();
												vector3D.TransformBy(xform2);
												double num8 = ((_0023_003Dz54yRp_1nJ0Tq != (_0023_003DzZKByqt9RvKDq)1) ? ((double)ifcRevolvedAreaSolid.Angle) : Utility.DegToRad(ifcRevolvedAreaSolid.Angle));
												entity = region2.RevolveAsSolid(0.0, num8, vector3D, point3D, Utility.NumberOfSegments(_0023_003DzbUvT9Pc_003D2.DistanceTo(point3D), num8, num7), num7);
											}
										}
										else
										{
											Vector3D vector3D2 = ifcExtrudedAreaSolid.ExtrudedDirection._0023_003DzdVv0tHg0zCjX();
											vector3D2.TransformBy(xform2);
											if ((double)ifcExtrudedAreaSolid.Depth > 0.0)
											{
												RegenParams data = ((!_0023_003DzELu0Pss_003D._0023_003DzUCYe4mP3BECb || !(OpeningsDeviation > 0.0)) ? new RegenParams(num7) : new RegenParams(num7, 0.0));
												Vector3D vector3D3 = vector3D2 * ifcExtrudedAreaSolid.Depth;
												_0023_003DzELu0Pss_003D._0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D = vector3D3;
												entity = region2.ExtrudeAsSolid(vector3D3, data);
											}
											else
											{
												entity = region2.ConvertToSolid(num7);
											}
										}
										if (_0023_003DzwYO9yMKu2gUgMxzgogDUe4A_003D)
										{
											((Solid)entity).SmoothingAngle = 0.8;
										}
									}
								}
							}
							else
							{
								entity = (Entity)_0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(_0023_003DzYbZQw3SBCmck, _0023_003DzXSrUO6ixqq8l: false, null, null);
							}
						}
						else
						{
							Point3D _0023_003DzAqOpw0w_003D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D((IIfcCartesianPoint)((IIfcVertexPoint)ifcEdge.EdgeStart).VertexGeometry);
							Point3D _0023_003Dzk64JNOo_003D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D((IIfcCartesianPoint)((IIfcVertexPoint)ifcEdge.EdgeEnd).VertexGeometry);
							entity = (Entity)_0023_003DzJ2HuHglxmxynWz1wrg_003D_003D(ifcEdge, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D);
						}
					}
					else if (ifcVertexPoint.VertexGeometry is IIfcCartesianPoint _0023_003DzDxh801w_003D)
					{
						entity = new devDept.Eyeshot.Entities.Point(_0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003DzDxh801w_003D), 4f);
					}
				}
				else
				{
					Solid _0023_003Dzw0lyEoKIRK4H;
					Solid[] array8 = _0023_003Dz3XBPPRl3ZGBUfUwCNwB9QQk_003D(_0023_003Dz5I3b_GM_003D, ref _0023_003DzELu0Pss_003D, _0023_003Dz139q_0024ZKLQnlc: true, out _0023_003Dzw0lyEoKIRK4H);
					if (array8 != null)
					{
						entity = _0023_003DzuXO8ip3szjRO(array8);
					}
				}
			}
			catch (Exception ex)
			{
				log.AppendLine(ex.Message);
			}
			if (entity != null && !(entity is BlockReference) && !_0023_003DzJbrxuN7FfKk4.ContainsKey(_0023_003DzMqRbkVw_003D.EntityLabel))
			{
				_0023_003DzJbrxuN7FfKk4.Add(_0023_003DzMqRbkVw_003D.EntityLabel, new Tuple<Entity, _0023_003DzcntdzPM_003D>((Entity)entity.Clone(), (_0023_003DzcntdzPM_003D)_0023_003DzELu0Pss_003D._0023_003Dzx9P_oXY_003D()));
			}
		}
		if (entity != null)
		{
			if (_0023_003DzyABDc6eJxOBL_00241KwYA_003D_003D(_0023_003DzMqRbkVw_003D, out var _0023_003Dz1MMYB1g_003D))
			{
				entity.ColorMethod = colorMethodType.byEntity;
				entity.Color = _0023_003Dz1MMYB1g_003D;
			}
			else if (entity.ColorMethod == colorMethodType.byLayer)
			{
				entity.ColorMethod = colorMethodType.byParent;
			}
			IIfcPresentationLayerAssignment[] array9 = _0023_003DzMqRbkVw_003D.LayerAssignment.ToArray();
			if (array9.Length != 0)
			{
				_0023_003DzvoVaxJKxgc_0024O(entity, array9[0]);
			}
		}
		else
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006111) + _0023_003DzMqRbkVw_003D.ExpressType.ExpressName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990142) + _0023_003DzMqRbkVw_003D.EntityLabel);
		}
		return entity;
	}

	private static Mesh _0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(Mesh[] _0023_003DzIIuKCj1NK1q5, int _0023_003DzM4J109Ny6kylYoeT1A_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		return Mesh._0023_003Dz_0024QJlr0pItQh7PH05vQ_003D_003D(_0023_003DzIIuKCj1NK1q5, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzgM38qBg_003D: false);
	}

	private (int, Point3D) _0023_003DzAVw6u5Y_003D(IIfcVertex _0023_003DzpnGgBd_niOts, IDictionary<int, (int, Point3D)> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		if (!_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.TryGetValue(_0023_003DzpnGgBd_niOts.EntityLabel, out var value))
		{
			if (((IIfcVertexPoint)_0023_003DzpnGgBd_niOts).VertexGeometry is IIfcCartesianPoint _0023_003DzDxh801w_003D)
			{
				return _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzpnGgBd_niOts.EntityLabel] = (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count, new Brep.Vertex(_0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003DzDxh801w_003D).ToArray()));
			}
			throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007656));
		}
		return value;
	}

	private (int, Point3D) _0023_003DzAVw6u5Y_003D(IIfcCartesianPoint _0023_003Dz1cdkDps_003D, IDictionary<int, (int, Point3D)> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		if (!_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.TryGetValue(_0023_003Dz1cdkDps_003D.EntityLabel, out var value))
		{
			return _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz1cdkDps_003D.EntityLabel] = (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count, new Brep.Vertex(_0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003Dz1cdkDps_003D).ToArray()));
		}
		return value;
	}

	private (int, Brep.Edge) _0023_003DzAVw6u5Y_003D(IIfcEdge _0023_003Dz4yVd9NCoe9mm, IDictionary<int, (int, Brep.Edge)> _0023_003DzU3hosSAzkxO7, ref int _0023_003Dzp5tEBWE_003D, IDictionary<int, (int, Point3D)> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		if (_0023_003DzU3hosSAzkxO7.TryGetValue(_0023_003Dz4yVd9NCoe9mm.EntityLabel, out var value))
		{
			return value;
		}
		if (_0023_003Dz4yVd9NCoe9mm is IIfcOrientedEdge ifcOrientedEdge)
		{
			_0023_003Dz4yVd9NCoe9mm = ifcOrientedEdge.EdgeElement;
		}
		return _0023_003DzU3hosSAzkxO7[_0023_003Dz4yVd9NCoe9mm.EntityLabel] = (_0023_003Dzp5tEBWE_003D++, _0023_003DzRAvbpr_0024uxBAjX8IbYg_003D_003D(_0023_003Dz4yVd9NCoe9mm, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D));
	}

	private static T[] _0023_003DzLtQa3eFgtD_4<T>(Dictionary<int, (int, T)> _0023_003DzXrexKjY_003D)
	{
		T[] array = new T[_0023_003DzXrexKjY_003D.Count];
		foreach (var value in _0023_003DzXrexKjY_003D.Values)
		{
			array[value.Item1] = value.Item2;
		}
		return array;
	}

	private static T[] _0023_003DzLtQa3eFgtD_4<T>(Dictionary<int, (int, T)> _0023_003Dzt38nTwk_003D, Dictionary<int, List<(int, T)>> _0023_003DzRZmqfkw_003D, int _0023_003DzoMNiNRw_003D)
	{
		T[] array = new T[_0023_003DzoMNiNRw_003D];
		T[] array2 = _0023_003DzLtQa3eFgtD_4(_0023_003Dzt38nTwk_003D);
		int num = array2.Length;
		for (int i = 0; i < num; i++)
		{
			array[i] = array2[i];
		}
		foreach (var item in _0023_003DzRZmqfkw_003D.Values.SelectMany(_0023_003DzozyIKwp_pBUqqxvkCg_003D_003D<T>._0023_003DzJ5g3Rwo_003D._0023_003DzQzQwhnn00taTHhSxwdGfjEs_003D))
		{
			array[item.Item1] = item.Item2;
		}
		return array;
	}

	private Entity _0023_003DzPWY9kKNoXBrmVCwPBDzN2bY_003D(IIfcAdvancedBrep _0023_003DzrWf8wilNJTcF)
	{
		_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D _0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2 = new _0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D();
		_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003DzopRx0_MBcTQs = this;
		List<Brep.Face> list = new List<Brep.Face>();
		_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Dictionary<int, (int, Point3D)>();
		_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003DzU3hosSAzkxO7 = new Dictionary<int, (int, Brep.Edge)>();
		Dictionary<int, List<(int, Brep.Edge)>> dictionary = new Dictionary<int, List<(int, Brep.Edge)>>();
		_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzp5tEBWE_003D = 0;
		foreach (IIfcFace cfsFace in _0023_003DzrWf8wilNJTcF.Outer.CfsFaces)
		{
			if (cfsFace is IIfcAdvancedFace ifcAdvancedFace)
			{
				Brep.Loop[] array = new Brep.Loop[ifcAdvancedFace.Bounds.Count];
				int num = 0;
				foreach (IIfcFaceBound bound2 in ifcAdvancedFace.Bounds)
				{
					List<Brep.OrientedEdge> list2 = new List<Brep.OrientedEdge>();
					IIfcLoop bound = bound2.Bound;
					if (!(bound is IIfcEdgeLoop ifcEdgeLoop))
					{
						if (!(bound is IIfcPolyLoop { Polygon: var polygon } ifcPolyLoop))
						{
							if (bound is IIfcVertexLoop)
							{
								throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007308));
							}
							throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007256));
						}
						int count = polygon.Count;
						List<(int, Brep.Edge)> list3 = new List<(int, Brep.Edge)>();
						for (int i = 0; i < count; i++)
						{
							(int, Point3D) tuple = _0023_003DzAVw6u5Y_003D(polygon[i], _0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
							(int, Point3D) tuple2 = _0023_003DzAVw6u5Y_003D(polygon[(i + 1) % count], _0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
							list3.Add((_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzp5tEBWE_003D, new Brep.Edge(new Line((Point3D)tuple.Item2.Clone(), (Point3D)tuple2.Item2.Clone()), tuple.Item1, tuple2.Item1)));
							list2.Add(new Brep.OrientedEdge(_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzp5tEBWE_003D++));
						}
						dictionary[ifcPolyLoop.EntityLabel] = list3;
					}
					else
					{
						list2 = ifcEdgeLoop.EdgeList.Select(_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003DzUGjUYbMTecpisDx_7xp589r5j_vdgeAC_A_003D_003D).ToList();
					}
					array[num++] = new Brep.Loop(list2.ToArray(), bound2.Orientation);
				}
				AnalyticSurf analyticSurf = _0023_003DzJAcFJbAfs6bzZiEb8Ts3uHFl1VNL(ifcAdvancedFace.FaceSurface);
				if (analyticSurf != null)
				{
					analyticSurf.TranslationID = new TranslationIdentifier(ifcAdvancedFace.FaceSurface.EntityLabel);
					list.Add(new Brep.Face(analyticSurf, array, ifcAdvancedFace.SameSense));
				}
				continue;
			}
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007467));
		}
		Brep brep = new Brep(_0023_003DzLtQa3eFgtD_4(_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D), _0023_003DzLtQa3eFgtD_4(_0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003DzU3hosSAzkxO7, dictionary, _0023_003Dz6QIQpAd2vRcMp_0024MbZR6Pa1A_003D2._0023_003Dzp5tEBWE_003D), list.ToArray());
		double deviation = _0023_003DzHA1826c_003D(brep, _0023_003Dzyeosjja2eCus: false);
		return brep.ConvertToMesh(deviation);
	}

	private List<Mesh> _0023_003DzvsmK3IZVxuY3p9OlBt0VVtS1X57X(IIfcTopologicalRepresentationItem _0023_003DzTuhdV_ghGDve)
	{
		if (_0023_003DzTuhdV_ghGDve is IIfcConnectedFaceSet ifcConnectedFaceSet)
		{
			IItemSet<IIfcFace> cfsFaces = ifcConnectedFaceSet.CfsFaces;
			List<Mesh> list = new List<Mesh>(cfsFaces.Count);
			{
				foreach (IIfcFace item in cfsFaces)
				{
					List<IList<Point3D>> list2 = new List<IList<Point3D>>();
					List<Point3D[]> list3 = new List<Point3D[]>();
					if (item.Bounds.Count == 1)
					{
						Point3D[] array = _0023_003Dzo5D3UX840Bu6(item.Bounds.First().Bound);
						if (array != null)
						{
							if (!item.Bounds.First().Orientation)
							{
								Array.Reverse(array);
							}
							list3.Add(array);
						}
					}
					else
					{
						foreach (IIfcFaceBound bound in item.Bounds)
						{
							if (bound is IIfcFaceOuterBound)
							{
								Point3D[] array2 = _0023_003Dzo5D3UX840Bu6(bound.Bound);
								if (array2 != null)
								{
									if (!bound.Orientation)
									{
										Array.Reverse(array2);
									}
									list3.Add(array2);
								}
								continue;
							}
							Point3D[] array3 = _0023_003Dzo5D3UX840Bu6(bound.Bound);
							if (array3 != null)
							{
								if (!bound.Orientation)
								{
									Array.Reverse(array3);
								}
								list2.Add(array3.ToList());
							}
						}
					}
					for (int i = 0; i < list3.Count; i++)
					{
						Point3D[] array4 = list3[i];
						Plane contourPlane = Utility.GetContourPlane(array4);
						Point2D[] array5 = new Point2D[array4.Length];
						for (int j = 0; j < array4.Length; j++)
						{
							array5[j] = contourPlane.Project(array4[j]);
						}
						if (Utility.IsPolygonSelfIntersecting(array5))
						{
							if (list3.Count != 1 || list2.Count != 0)
							{
								continue;
							}
							List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list4 = new List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>(array5.Length);
							Utility.BoundingRect(array5, out var min, out var max);
							IntegerGrid integerGrid = new IntegerGrid(524288, min, max);
							Point2D[] array6 = array5;
							foreach (Point2D point2D in array6)
							{
								integerGrid.ScaleToGrid(point2D.X, point2D.Y, out long gridX, out long gridY);
								list4.Add(new _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D(gridX, gridY));
							}
							List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> list5 = _0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC27._0023_003DzBaxJxVyp71Fj(list4, (_0023_003Dzwk8BC5_rOrgX0A_mTL9gdmA_003D)1);
							if (list5.Count <= 1 || !_0023_003Dz9T1lhuzLI4KcREQH4w_003D_003D(list5, out var _0023_003DzY9mTrFA_003D))
							{
								continue;
							}
							Point2D[][] array7 = new Point2D[list5.Count][];
							for (int l = 0; l < list5.Count; l++)
							{
								List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> list6 = list5[l];
								Point2D[] array8 = new Point2D[list6.Count + 1];
								for (int m = 0; m < list6.Count; m++)
								{
									_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2 = list6[m];
									integerGrid.ScaleToWorld(_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003Dzyk2fsPo_003D, _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D2._0023_003DzvXOLtKg_003D, out var x, out var y);
									array8[m] = new Point2D(x, y);
								}
								array8[^1] = (Point2D)array8[0].Clone();
								array7[l] = array8;
							}
							Point3D[][] array9 = new Point3D[list5.Count][];
							bool flag = false;
							for (int n = 0; n < list5.Count; n++)
							{
								Point2D[] array10 = array7[n];
								Point3D[] array11 = new Point3D[array10.Length];
								for (int num = 0; num < array10.Length; num++)
								{
									int num2 = -1;
									for (int num3 = 0; num3 < array5.Length; num3++)
									{
										if (Point2D.DistanceSquared(array5[num3], array10[num]) < 1E-12)
										{
											num2 = num3;
											break;
										}
									}
									if (num2 == -1)
									{
										flag = true;
										break;
									}
									array11[num] = (Point3D)array4[num2].Clone();
								}
								if (flag)
								{
									break;
								}
								array9[n] = array11;
							}
							if (flag)
							{
								continue;
							}
							array4 = array9[_0023_003DzY9mTrFA_003D];
							list2 = new List<IList<Point3D>>();
							for (int num4 = 0; num4 < array9.Length; num4++)
							{
								if (num4 != _0023_003DzY9mTrFA_003D)
								{
									list2.Add(array9[num4]);
								}
							}
						}
						double num5 = _0023_003Dzqc5bga3nl8Op(array4);
						for (int num6 = list2.Count - 1; num6 >= 0; num6--)
						{
							Plane contourPlane2 = Utility.GetContourPlane(list2[num6]);
							contourPlane2.Flip();
							Vector3D vector3D = Vector3D.Cross(contourPlane.AxisZ, contourPlane2.AxisZ);
							double num7 = ((vector3D.X >= 0.0) ? vector3D.X : (0.0 - vector3D.X));
							double num8 = ((vector3D.Y >= 0.0) ? vector3D.Y : (0.0 - vector3D.Y));
							double num9 = ((vector3D.Z >= 0.0) ? vector3D.Z : (0.0 - vector3D.Z));
							if (num7 + num8 + num9 < num5)
							{
								Vector3D vector3D2 = Vector3D.Subtract(contourPlane2.Origin, contourPlane.Origin);
								if (Utility.Compare(num5, contourPlane.AxisZ * vector3D2, 0.0) == 0)
								{
									IList<Point3D> list7 = list2[num6];
									array5 = new Point2D[list7.Count];
									for (int num10 = 0; num10 < list7.Count; num10++)
									{
										array5[num10] = contourPlane.Project(list7[num10]);
									}
									if (!Utility.IsPolygonSelfIntersecting(array5))
									{
										continue;
									}
								}
							}
							list2.RemoveAt(num6);
						}
						list.Add(Mesh.CreatePlanar<Mesh>(array4, list2, Mesh.natureType.Smooth));
					}
				}
				return list;
			}
		}
		return null;
	}

	private bool _0023_003Dz9T1lhuzLI4KcREQH4w_003D_003D(List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, out int _0023_003DzY9mTrFA_003D)
	{
		_0023_003DzY9mTrFA_003D = -1;
		for (int i = 0; i < _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Count; i++)
		{
			bool flag = true;
			for (int j = 0; j < _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Count; j++)
			{
				if (i == j)
				{
					continue;
				}
				foreach (_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D item in _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D[j])
				{
					if (_0023_003DzkqwHVv7avdc_GvWMGqjtS5mGOC27._0023_003DzlgkUJVvf16gK(item, _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D[i]) != 1)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			if (flag)
			{
				_0023_003DzY9mTrFA_003D = i;
				return true;
			}
		}
		return false;
	}

	private Point3D[] _0023_003Dzo5D3UX840Bu6(IIfcLoop _0023_003DzdEvMFOw_003D)
	{
		IList<IIfcCartesianPoint> polygon = ((IIfcPolyLoop)_0023_003DzdEvMFOw_003D).Polygon;
		int count = polygon.Count;
		if (count < 3)
		{
			return null;
		}
		List<Point3D> list = new List<Point3D>(count);
		list.Add(_0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(polygon[0]));
		for (int i = 1; i < count; i++)
		{
			Point3D point3D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(polygon[i]);
			if (!point3D.Equals(list.Last()))
			{
				list.Add(point3D);
			}
		}
		int num = list.Count - 1;
		if (!list[0].Equals(list[num]) && list.Count > 3)
		{
			Segment3D segment3D = new Segment3D(list[0], list[1]);
			Segment3D segment3D2 = new Segment3D(list[num], list[num - 1]);
			if (Segment3D.Intersection(segment3D, segment3D2, infinite: false, out var pointOnA, out var pointOnB))
			{
				double num2 = ((segment3D.Length < segment3D2.Length) ? segment3D.Length : segment3D2.Length);
				if (Point3D.Distance(pointOnA, pointOnB) < num2 * Utility._0023_003DzxhnLabVjXjPg)
				{
					list[num] = (Point3D)list[0].Clone();
				}
			}
		}
		if (!list[0].Equals(list[num]))
		{
			list.Add((Point3D)list[0].Clone());
		}
		if (list.Count <= 3)
		{
			return null;
		}
		return list.ToArray();
	}

	private ICurve _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(IIfcCurve _0023_003DzYbZQw3SBCmck, bool _0023_003DzXSrUO6ixqq8l, IList<Point3D> _0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D, List<double> _0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D)
	{
		ICurve curve = null;
		if (!_0023_003DzJbrxuN7FfKk4.TryGetValue(_0023_003DzYbZQw3SBCmck.EntityLabel, out var value))
		{
			if (!(_0023_003DzYbZQw3SBCmck is IfcClothoid ifcClothoid))
			{
				if (!(_0023_003DzYbZQw3SBCmck is IIfcConic ifcConic))
				{
					if (!(_0023_003DzYbZQw3SBCmck is IIfcLine ifcLine))
					{
						if (!(_0023_003DzYbZQw3SBCmck is IIfcPolyline ifcPolyline))
						{
							if (!(_0023_003DzYbZQw3SBCmck is Xbim.Ifc4x3.GeometryResource.IfcCompositeCurve ifcCompositeCurve))
							{
								if (!(_0023_003DzYbZQw3SBCmck is IIfcCompositeCurve _0023_003DzlKuWXaiTwzXe))
								{
									if (!(_0023_003DzYbZQw3SBCmck is IIfcTrimmedCurve ifcTrimmedCurve))
									{
										if (!(_0023_003DzYbZQw3SBCmck is IIfcIndexedPolyCurve ifcIndexedPolyCurve))
										{
											if (_0023_003DzYbZQw3SBCmck is IIfcBSplineCurveWithKnots ifcBSplineCurveWithKnots)
											{
												double[] array = ifcBSplineCurveWithKnots.Knots._0023_003DzxmkascJ__U8n();
												IItemSet<IIfcCartesianPoint> controlPointsList = ifcBSplineCurveWithKnots.ControlPointsList;
												int num = (int)(long)ifcBSplineCurveWithKnots.Degree;
												Point4D[] array2 = new Point4D[controlPointsList.Count];
												double[] array3 = new double[controlPointsList.Count];
												if (ifcBSplineCurveWithKnots is IIfcRationalBSplineCurveWithKnots ifcRationalBSplineCurveWithKnots)
												{
													for (int i = 0; i < array3.Length; i++)
													{
														array3[i] = ifcRationalBSplineCurveWithKnots.WeightsData[i];
													}
												}
												else
												{
													for (int j = 0; j < array3.Length; j++)
													{
														array3[j] = 1.0;
													}
												}
												for (int k = 0; k < array2.Length; k++)
												{
													array2[k] = new Point4D(controlPointsList[k].X, controlPointsList[k].Y, double.IsNaN(controlPointsList[k].Z) ? 0.0 : controlPointsList[k].Z, array3[k]);
												}
												_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
												try
												{
													curve = new Curve(num, (array.Length == num + controlPointsList.Count + 1) ? array : NurbsBase.UniformKnotVector(num, controlPointsList.Count), array2);
												}
												finally
												{
													((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
												}
											}
										}
										else
										{
											Point3D[] array4;
											if (ifcIndexedPolyCurve.Points is IIfcCartesianPointList2D { CoordList: var coordList })
											{
												array4 = new Point3D[coordList.Count];
												for (int l = 0; l < coordList.Count; l++)
												{
													array4[l] = new Point3D(coordList[l][0], coordList[l][1]);
												}
											}
											else
											{
												IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure>> coordList2 = (ifcIndexedPolyCurve.Points as IIfcCartesianPointList3D).CoordList;
												array4 = new Point3D[coordList2.Count];
												for (int m = 0; m < coordList2.Count; m++)
												{
													IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure> itemSet = coordList2[m];
													array4[m] = new Point3D(itemSet[0], itemSet[1], itemSet[2]);
												}
											}
											if (ifcIndexedPolyCurve.Segments != null && ifcIndexedPolyCurve.Segments.Count > 0)
											{
												IList<IIfcSegmentIndexSelect> segments = ifcIndexedPolyCurve.Segments;
												List<ICurve> list = new List<ICurve>(segments.Count);
												for (int n = 0; n < segments.Count; n++)
												{
													IIfcSegmentIndexSelect ifcSegmentIndexSelect = segments[n];
													if (ifcSegmentIndexSelect is Xbim.Ifc4.GeometryResource.IfcLineIndex ifcLineIndex)
													{
														List<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> list2 = (List<Xbim.Ifc4.MeasureResource.IfcPositiveInteger>)ifcLineIndex.Value;
														Point3D[] array5 = new Point3D[list2.Count];
														for (int num2 = 0; num2 < list2.Count; num2++)
														{
															array5[num2] = array4[(long)list2[num2] - 1];
														}
														if (array5.Length == 2)
														{
															list.Add(new Line(array5[0], array5[1]));
														}
														else if (array5.Length > 1)
														{
															LinearPath item = new LinearPath(Utility.RemoveDuplicates(array5));
															list.Add(item);
														}
													}
													else
													{
														List<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> list3 = (List<Xbim.Ifc4.MeasureResource.IfcPositiveInteger>)((Xbim.Ifc4.GeometryResource.IfcArcIndex)(object)ifcSegmentIndexSelect).Value;
														list.Add(new Arc(array4[(long)list3[0] - 1], array4[(long)list3[1] - 1], array4[(long)list3[2] - 1]));
													}
												}
												ICurve curve2;
												if (list.Count <= 1)
												{
													curve2 = list[0];
												}
												else
												{
													ICurve curve3 = new CompositeCurve(list);
													curve2 = curve3;
												}
												curve = curve2;
											}
											else if (array4.Length > 1)
											{
												curve = new LinearPath(Utility.RemoveDuplicates(array4));
											}
										}
									}
									else
									{
										ICurve curve4 = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcTrimmedCurve.BasisCurve, _0023_003DzXSrUO6ixqq8l: false, null, null);
										if (curve4 != null)
										{
											_0023_003DqxEbyZAnqUyyQhpRDdHoiwZ46KDdjuTAZEhpf9rdXhXHn4Mf_002487EvYAyayFvoaMiIWO0c6JTP54rvQkS4Y5clTw_003D_003D(ifcTrimmedCurve.Trim1, out var _0023_003Dzmk06LTk_003D, out var _0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D);
											_0023_003DqxEbyZAnqUyyQhpRDdHoiwZ46KDdjuTAZEhpf9rdXhXHn4Mf_002487EvYAyayFvoaMiIWO0c6JTP54rvQkS4Y5clTw_003D_003D(ifcTrimmedCurve.Trim2, out var _0023_003Dzmk06LTk_003D2, out var _0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D2);
											ICurve sub;
											if (ifcTrimmedCurve.MasterRepresentation != Xbim.Ifc4.Interfaces.IfcTrimmingPreference.CARTESIAN && _0023_003Dzmk06LTk_003D > -1.0)
											{
												double num3 = _0023_003DzIEXole_Fgi1xKqjqkMi52R8_003D(curve4, _0023_003Dzmk06LTk_003D);
												double num4 = _0023_003DzIEXole_Fgi1xKqjqkMi52R8_003D(curve4, _0023_003Dzmk06LTk_003D2);
												if ((bool)ifcTrimmedCurve.SenseAgreement)
												{
													curve4.SubCurve(num3, num4, out sub);
													if (sub == null && num3 > num4 && (curve4 is Circle || curve4 is Ellipse))
													{
														num3 -= Math.PI * 2.0;
														curve4.SubCurve(num3, num4, out sub);
													}
												}
												else
												{
													curve4.SubCurve(num4, num3, out sub);
													if (sub == null && num4 > num3 && (curve4 is Circle || curve4 is Ellipse))
													{
														num4 -= Math.PI * 2.0;
														curve4.SubCurve(num4, num3, out sub);
													}
													sub.Reverse();
												}
											}
											else
											{
												Point3D point3D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D);
												Point3D point3D2 = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D2);
												if ((bool)ifcTrimmedCurve.SenseAgreement)
												{
													curve4.SubCurve(point3D, point3D2, out sub);
												}
												else
												{
													if (curve4.IsClosed)
													{
														curve4.SubCurve(point3D2, point3D, out sub);
													}
													else
													{
														curve4.SubCurve(point3D, point3D2, out sub);
													}
													sub.Reverse();
												}
												if (curve4 is Line && sub.Length() < 1E-12)
												{
													curve4.Project(point3D, out var t);
													curve4.Project(point3D2, out var t2);
													sub = new Line(curve4.PointAt(t), curve4.PointAt(t2));
												}
											}
											curve = sub;
										}
									}
								}
								else
								{
									curve = _0023_003DzDqtuN6GAyONX(_0023_003DzlKuWXaiTwzXe);
								}
							}
							else
							{
								if (ifcCompositeCurve.Segments[0] is IfcCurveSegment)
								{
									CompositeCurve compositeCurve = new CompositeCurve();
									foreach (IfcCurveSegment segment in ifcCompositeCurve.Segments)
									{
										ICurve curve5 = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(segment.ParentCurve, _0023_003DzXSrUO6ixqq8l: false, null, null);
										if (curve5 != null)
										{
											double num5 = _0023_003DzKvixUAU_003D(curve5, segment.SegmentStart);
											double num6 = _0023_003DzKvixUAU_003D(curve5, segment.SegmentLength);
											if (num6 < 0.0)
											{
												curve5.Reverse();
												num5 = ((curve5.Domain.Length != double.PositiveInfinity) ? (curve5.Domain.Length - num5) : (0.0 - num5));
												num6 = 0.0 - num6;
											}
											curve5.SubCurve(num5, num5 + num6, out var sub2);
											Plane plane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(segment.Placement);
											((Entity)sub2).Rotate(Vector3D.AngleBetween(plane.AxisX, sub2.StartTangent), Vector3D.Cross(sub2.StartTangent, plane.AxisX), sub2.StartPoint);
											((Entity)sub2).Translate(plane.Origin.X - sub2.StartPoint.X, plane.Origin.Y - sub2.StartPoint.Y, plane.Origin.Z - sub2.StartPoint.Z);
											compositeCurve.CurveList.Add(sub2);
										}
									}
									curve = compositeCurve;
								}
								else
								{
									curve = _0023_003DzDqtuN6GAyONX(ifcCompositeCurve);
								}
								if (ifcCompositeCurve is IfcGradientCurve ifcGradientCurve)
								{
									ICurve curve6 = curve;
									ICurve curve7 = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcGradientCurve.BaseCurve, _0023_003DzXSrUO6ixqq8l: false, null, null);
									_0023_003DzFZibxtsmvLt7(curve7, out var _0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D2, out var _0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D2);
									double num7 = curve7.Length();
									double num8 = curve6.Length();
									int num9 = _0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D2.Count();
									for (int num10 = 0; num10 < num9; num10++)
									{
										double length = _0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D2[num10] * (num8 / num7);
										curve6.GetParamFromLength(length, out var t3);
										Point3D point3D3 = curve6.PointAt(t3);
										_0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D2[num10].Z += point3D3.Y;
									}
									ICurve curve8 = curve6.GetIndividualCurves()[curve6.GetIndividualCurves().Count() - 1];
									ICurve curve9 = curve7.GetIndividualCurves()[curve7.GetIndividualCurves().Count() - 1];
									_0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D2.Add(curve9.PointAt(curve9.Domain.High) + new Point3D(0.0, 0.0, curve8.PointAt(curve8.Domain.High).Y));
									curve = Curve.GlobalInterpolation(_0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D2, 3);
								}
							}
						}
						else
						{
							curve = _0023_003Dz5yHC1rl_2GYvyvOZ9w_003D_003D(ifcPolyline.Points, _0023_003DzXSrUO6ixqq8l);
						}
					}
					else
					{
						Point3D point3D4 = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(ifcLine.Pnt);
						Vector3D vector3D = ifcLine.Dir._0023_003DzdVv0tHg0zCjX();
						Point3D end = point3D4 + vector3D;
						curve = new Line(point3D4, end);
					}
				}
				else
				{
					Plane plane2 = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D((IIfcPlacement)ifcConic.Position);
					if (ifcConic is IIfcCircle ifcCircle)
					{
						curve = new Circle(plane2, ifcCircle.Radius);
					}
					else
					{
						IIfcEllipse ifcEllipse = (IIfcEllipse)ifcConic;
						curve = new Ellipse(plane2, plane2.Origin, ifcEllipse.SemiAxis1, ifcEllipse.SemiAxis2);
					}
				}
			}
			else
			{
				curve = new _0023_003Dz_BA0vjyBcrnMXNzamw_003D_003D(_0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D((IIfcPlacement)ifcClothoid.Position), ifcClothoid.ClothoidConstant);
			}
			if (curve != null)
			{
				_0023_003DzJbrxuN7FfKk4.Add(_0023_003DzYbZQw3SBCmck.EntityLabel, new Tuple<Entity, _0023_003DzcntdzPM_003D>((Entity)curve.Clone(), null));
			}
		}
		else
		{
			curve = (ICurve)value.Item1.Clone();
		}
		if (curve == null)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006591), _0023_003DzYbZQw3SBCmck.ExpressType.ExpressName, _0023_003DzYbZQw3SBCmck.EntityLabel));
		}
		return curve;
	}

	private static void _0023_003DzFZibxtsmvLt7(ICurve _0023_003Dz8fpRyMu9aKjE, out IList<Point3D> _0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D, out List<double> _0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D)
	{
		List<double> _0023_003DzCzKVJHo1PSre = new List<double>();
		_0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D = new List<Point3D>();
		_0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D = new List<double>();
		ICurve[] individualCurves = _0023_003Dz8fpRyMu9aKjE.GetIndividualCurves();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			_0023_003DqaejkSjaYKShwdB7EHcWWBylxxn_00242XuPnfSugcPa_0024EA7pRi_00244cJ0ZZmKP9gQnorCy8lkfJGphmyDsouy_0024ABgNeg_003D_003D(_0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D, _0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D, i, _0023_003DzCzKVJHo1PSre, individualCurves[i]);
		}
	}

	private CompositeCurve _0023_003DzDqtuN6GAyONX(IIfcCompositeCurve _0023_003DzlKuWXaiTwzXe)
	{
		CompositeCurve compositeCurve = new CompositeCurve();
		foreach (IIfcCompositeCurveSegment segment in _0023_003DzlKuWXaiTwzXe.Segments)
		{
			ICurve curve = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(segment.ParentCurve, _0023_003DzXSrUO6ixqq8l: false, null, null);
			if (curve != null)
			{
				if (!segment.SameSense)
				{
					curve.Reverse();
				}
				compositeCurve.CurveList.Add(curve);
			}
		}
		return compositeCurve;
	}

	private double _0023_003DzKvixUAU_003D(ICurve _0023_003Dz8fpRyMu9aKjE, IfcCurveMeasureSelect _0023_003DzX_0024MEm9yX97Fs)
	{
		if (!(_0023_003DzX_0024MEm9yX97Fs is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure ifcLengthMeasure))
		{
			if (_0023_003DzX_0024MEm9yX97Fs is Xbim.Ifc4x3.MeasureResource.IfcParameterValue ifcParameterValue)
			{
				return ifcParameterValue;
			}
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007408));
		}
		return _0023_003DzvWnyemjmd4sV(_0023_003Dz8fpRyMu9aKjE, ifcLengthMeasure);
	}

	private double _0023_003DzvWnyemjmd4sV(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz736ekIs_003D)
	{
		if (!(_0023_003Dz8fpRyMu9aKjE is Circle { Domain: var domain } circle))
		{
			if (_0023_003Dz8fpRyMu9aKjE is Line)
			{
				return _0023_003Dz736ekIs_003D;
			}
			_0023_003Dz8fpRyMu9aKjE.GetParamFromLength(_0023_003Dz736ekIs_003D, out var t);
			return t;
		}
		return domain.Low + _0023_003Dz736ekIs_003D / circle.Radius;
	}

	private Brep.Edge _0023_003DzRAvbpr_0024uxBAjX8IbYg_003D_003D(IIfcEdge _0023_003Dz4yVd9NCoe9mm, IDictionary<int, (int, Point3D)> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		(int, Point3D) tuple = _0023_003DzAVw6u5Y_003D(_0023_003Dz4yVd9NCoe9mm.EdgeStart, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		(int, Point3D) tuple2 = _0023_003DzAVw6u5Y_003D(_0023_003Dz4yVd9NCoe9mm.EdgeEnd, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		return new Brep.Edge(_0023_003DzJ2HuHglxmxynWz1wrg_003D_003D(_0023_003Dz4yVd9NCoe9mm, tuple.Item2, tuple2.Item2), tuple.Item1, tuple2.Item1);
	}

	private ICurve _0023_003DzJ2HuHglxmxynWz1wrg_003D_003D(IIfcEdge _0023_003Dz4yVd9NCoe9mm, Point3D _0023_003DzAqOpw0w_003D, Point3D _0023_003Dzk64JNOo_003D)
	{
		ICurve curve;
		if (_0023_003Dz4yVd9NCoe9mm is IIfcEdgeCurve ifcEdgeCurve)
		{
			curve = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcEdgeCurve.EdgeGeometry, _0023_003DzXSrUO6ixqq8l: false, null, null);
			curve.ClosestPointTo(_0023_003DzAqOpw0w_003D, out var t);
			curve.ClosestPointTo(_0023_003Dzk64JNOo_003D, out var t2);
			if (curve.StartPoint != _0023_003DzAqOpw0w_003D || curve.EndPoint != _0023_003Dzk64JNOo_003D)
			{
				if (!(curve is Line))
				{
					ICurve sub2;
					if (curve is Circle circle)
					{
						Vector3D axisZ = circle.Plane.AxisZ;
						ICurve sub;
						if (t > t2)
						{
							double num = Math.PI * 2.0 - t;
							Arc arc = new Arc(circle.Plane, Point2D.Origin, circle.Radius, 0.0, t2 + num);
							arc.Rotate(0.0 - num, axisZ, circle.Center);
							curve = arc;
						}
						else if (circle.SubCurve(t, t2, out sub))
						{
							curve = sub;
						}
					}
					else if (curve.SubCurve(t, t2, out sub2))
					{
						curve = sub2;
					}
				}
				else
				{
					curve = new Line((Point3D)_0023_003DzAqOpw0w_003D.Clone(), (Point3D)_0023_003Dzk64JNOo_003D.Clone());
				}
			}
		}
		else
		{
			curve = new Line((Point3D)_0023_003DzAqOpw0w_003D.Clone(), (Point3D)_0023_003Dzk64JNOo_003D.Clone());
		}
		return curve;
	}

	private ICurve _0023_003DzNTvYmuukkdyuktJKOeR2hWM_003D(IIfcProfileDef _0023_003DzI1pipBQVwKPg)
	{
		if (_0023_003DzI1pipBQVwKPg != null)
		{
			if (!(_0023_003DzI1pipBQVwKPg is IIfcArbitraryClosedProfileDef ifcArbitraryClosedProfileDef))
			{
				if (!(_0023_003DzI1pipBQVwKPg is IIfcArbitraryOpenProfileDef ifcArbitraryOpenProfileDef))
				{
					if (_0023_003DzI1pipBQVwKPg is IIfcCompositeProfileDef ifcCompositeProfileDef)
					{
						return new CompositeCurve(ifcCompositeProfileDef.Profiles.Select(_0023_003DzNTvYmuukkdyuktJKOeR2hWM_003D));
					}
					throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007385));
				}
				return _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcArbitraryOpenProfileDef.Curve, _0023_003DzXSrUO6ixqq8l: false, null, null);
			}
			return _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcArbitraryClosedProfileDef.OuterCurve, _0023_003DzXSrUO6ixqq8l: true, null, null);
		}
		return null;
	}

	private AnalyticSurf _0023_003DzJAcFJbAfs6bzZiEb8Ts3uHFl1VNL(IIfcSurface _0023_003DzYa587OSsiPzY)
	{
		_0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D CS_0024_003C_003E8__locals12 = new _0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D();
		CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D = _0023_003DzYa587OSsiPzY as IIfcBSplineSurfaceWithKnots;
		AnalyticSurf analyticSurf;
		if (CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D == null)
		{
			if (!(_0023_003DzYa587OSsiPzY is IIfcBSplineSurface) && !(_0023_003DzYa587OSsiPzY is IIfcCurveBoundedPlane) && !(_0023_003DzYa587OSsiPzY is IIfcCurveBoundedSurface))
			{
				if (!(_0023_003DzYa587OSsiPzY is IIfcCylindricalSurface _0023_003Dzn3usivtnLmKDg999jw_003D_003D))
				{
					if (!(_0023_003DzYa587OSsiPzY is IIfcRectangularTrimmedSurface))
					{
						if (!(_0023_003DzYa587OSsiPzY is IIfcSphericalSurface ifcSphericalSurface))
						{
							if (!(_0023_003DzYa587OSsiPzY is IIfcSurfaceOfLinearExtrusion ifcSurfaceOfLinearExtrusion))
							{
								if (!(_0023_003DzYa587OSsiPzY is IIfcSurfaceOfRevolution ifcSurfaceOfRevolution))
								{
									if (!(_0023_003DzYa587OSsiPzY is IIfcToroidalSurface ifcToroidalSurface))
									{
										if (!(_0023_003DzYa587OSsiPzY is IIfcBoundedSurface))
										{
											if (_0023_003DzYa587OSsiPzY is IIfcPlane ifcPlane)
											{
												Plane plane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcPlane.Position);
												analyticSurf = new PlanarSurf(plane.Origin, plane.AxisZ, plane.AxisX);
											}
											else
											{
												analyticSurf = null;
											}
										}
										else
										{
											analyticSurf = null;
										}
									}
									else
									{
										analyticSurf = new ToroidalSurf(_0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcToroidalSurface.Position), ifcToroidalSurface.MajorRadius, ifcToroidalSurface.MinorRadius);
									}
								}
								else
								{
									Plane plane2 = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcSurfaceOfRevolution.AxisPosition);
									analyticSurf = new RevolvedSurf(plane2.Origin, plane2.AxisZ, plane2.AxisX, _0023_003DzNTvYmuukkdyuktJKOeR2hWM_003D(ifcSurfaceOfRevolution.SweptCurve));
									if (ifcSurfaceOfRevolution.Position != null)
									{
										analyticSurf.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcSurfaceOfRevolution.Position)));
									}
								}
							}
							else
							{
								analyticSurf = new TabulatedSurf(_0023_003DzNTvYmuukkdyuktJKOeR2hWM_003D(ifcSurfaceOfLinearExtrusion.SweptCurve), ifcSurfaceOfLinearExtrusion.Depth * ifcSurfaceOfLinearExtrusion.ExtrudedDirection._0023_003DzdVv0tHg0zCjX());
								if (ifcSurfaceOfLinearExtrusion.Position != null)
								{
									analyticSurf.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcSurfaceOfLinearExtrusion.Position)));
								}
							}
						}
						else
						{
							analyticSurf = new SphericalSurf(_0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcSphericalSurface.Position), ifcSphericalSurface.Radius);
						}
					}
					else
					{
						analyticSurf = null;
					}
				}
				else
				{
					analyticSurf = _0023_003Dz90G3o8Uyrw_uF_0024pkTixQ9HLsGjOOB5ROfi95b4I_003D(_0023_003Dzn3usivtnLmKDg999jw_003D_003D);
				}
			}
			else
			{
				analyticSurf = null;
			}
		}
		else
		{
			int num = (int)(long)CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D.UDegree;
			int num2 = (int)(long)CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D.VDegree;
			double[] array = CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D.UKnots._0023_003DzxmkascJ__U8n().SelectMany((double _0023_003DzbfrNXYE_003D, int _0023_003Dz437_00244ak_003D) => Enumerable.Repeat(_0023_003DzbfrNXYE_003D, (int)(long)CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D.UMultiplicities[_0023_003Dz437_00244ak_003D])).ToArray();
			double[] array2 = CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D.VKnots._0023_003DzxmkascJ__U8n().SelectMany(CS_0024_003C_003E8__locals12._0023_003DzgFq5MinbwAL4b9f802NLpbZzuY5JXEBc2dhkJpg_003D).ToArray();
			Point4D[][] array3 = CS_0024_003C_003E8__locals12._0023_003DzufKfca1jyE6LOmWG6g_003D_003D.ControlPointsList.Select(delegate(IItemSet<IIfcCartesianPoint> _0023_003DzGcl_0024E9o_003D, int _0023_003Dz437_00244ak_003D)
			{
				_0023_003DzzkPoxwb_0024Xqj0ZHNaKIf8FuY_003D CS_0024_003C_003E8__locals15 = new _0023_003DzzkPoxwb_0024Xqj0ZHNaKIf8FuY_003D();
				CS_0024_003C_003E8__locals15._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D = CS_0024_003C_003E8__locals12;
				CS_0024_003C_003E8__locals15._0023_003Dz437_00244ak_003D = _0023_003Dz437_00244ak_003D;
				return _0023_003DzGcl_0024E9o_003D.Select((IIfcCartesianPoint _0023_003DzBJFJHwk_003D, int _0023_003DzTSeNR8Q_003D) => new Point4D(_0023_003DzBJFJHwk_003D.X, _0023_003DzBJFJHwk_003D.Y, _0023_003DzBJFJHwk_003D.Z, (CS_0024_003C_003E8__locals15._0023_003DqPJLnaCaaRlOu1mRID_0024lekWTCjTcfhdwtBB1ogq5_0024WkY_003D._0023_003DzufKfca1jyE6LOmWG6g_003D_003D is IIfcRationalBSplineSurfaceWithKnots ifcRationalBSplineSurfaceWithKnots) ? ifcRationalBSplineSurfaceWithKnots.WeightsData[CS_0024_003C_003E8__locals15._0023_003Dz437_00244ak_003D][_0023_003DzTSeNR8Q_003D] : ((Xbim.Ifc4.MeasureResource.IfcReal)1.0))).ToArray();
			}).ToArray();
			Point4D[,] array4 = new Point4D[array3.Length, array3[0].Length];
			for (int num3 = 0; num3 < array3.Length; num3++)
			{
				for (int num4 = 0; num4 < array3[0].Length; num4++)
				{
					array4[num3, num4] = array3[num3][num4];
				}
			}
			Surface surface = new Surface(num, (array.Length == num + array3.Length + 1) ? array : NurbsBase.UniformKnotVector(num, array3.Length), num2, (array2.Length == num2 + array3[0].Length + 1) ? array2 : NurbsBase.UniformKnotVector(num2, array3[0].Length), array4);
			analyticSurf = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints);
		}
		if (analyticSurf == null)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006591), _0023_003DzYa587OSsiPzY.ExpressType.ExpressName, _0023_003DzYa587OSsiPzY.EntityLabel));
		}
		return analyticSurf;
	}

	private ICurve _0023_003Dz5yHC1rl_2GYvyvOZ9w_003D_003D(IList<IIfcCartesianPoint> _0023_003DzCyNAU5Ra8mqU, bool _0023_003DzXSrUO6ixqq8l)
	{
		int count = _0023_003DzCyNAU5Ra8mqU.Count;
		List<Point3D> list = new List<Point3D>(count);
		list.Add(_0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003DzCyNAU5Ra8mqU[0]));
		for (int i = 1; i < count; i++)
		{
			Point3D point3D = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003DzCyNAU5Ra8mqU[i]);
			if (!list[list.Count - 1].Equals(point3D))
			{
				list.Add(point3D);
			}
		}
		if (_0023_003DzXSrUO6ixqq8l && list.Count > 2 && Point3D.Distance(list[0], list.Last()) > 1E-12)
		{
			list.Add((Point3D)list[0].Clone());
		}
		if (list.Count <= 1)
		{
			return null;
		}
		return new LinearPath(list);
	}

	private Solid[] _0023_003Dz3XBPPRl3ZGBUfUwCNwB9QQk_003D(IIfcBooleanResult _0023_003Dz5I3b_GM_003D, ref _0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D, bool _0023_003Dz139q_0024ZKLQnlc, out Solid _0023_003Dzw0lyEoKIRK4H)
	{
		Solid[] _0023_003DzH6GDaaq_lIr = null;
		if (!_0023_003Dz7tnLUCh4KvaCM5mKGrn3OA0_003D(_0023_003Dz5I3b_GM_003D.FirstOperand, ref _0023_003DzELu0Pss_003D, _0023_003DzitRY1aRoWH5N: true, out var _0023_003DzH6GDaaq_lIr2, out _0023_003Dzw0lyEoKIRK4H))
		{
			return null;
		}
		Point3D _0023_003DzDPcjoBJLcqli;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC;
		Size3D size3D = _0023_003DzeWAzeU2mSVqA(_0023_003DzH6GDaaq_lIr2, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
		if (_0023_003Dz5I3b_GM_003D.SecondOperand is IIfcPolygonalBoundedHalfSpace ifcPolygonalBoundedHalfSpace)
		{
			IIfcPlane ifcPlane = (IIfcPlane)ifcPolygonalBoundedHalfSpace.BaseSurface;
			Plane plane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcPlane.Position);
			Plane plane2 = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcPolygonalBoundedHalfSpace.Position);
			Align3D xform = new Align3D(Plane.XY, plane2);
			ICurve curve = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcPolygonalBoundedHalfSpace.PolygonalBoundary, _0023_003DzXSrUO6ixqq8l: true, null, null);
			if (curve != null && curve.IsClosed)
			{
				devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(curve);
				region.TransformBy(xform);
				Vector3D axisZ = plane2.AxisZ;
				double num = size3D.Max * 1.5;
				region.Translate(axisZ * (0.0 - num));
				Solid solid = region.ExtrudeAsSolid(axisZ * num * 2.0, new RegenParams(_0023_003DzHA1826c_003D(region, _0023_003Dzyeosjja2eCus: true)));
				if (!ifcPolygonalBoundedHalfSpace.AgreementFlag)
				{
					plane.Flip();
				}
				booleanFailureType booleanFailureType2 = solid.CutBy(plane);
				_0023_003DzH6GDaaq_lIr = new Solid[1] { solid };
				if (booleanFailureType2 == booleanFailureType.Failed)
				{
					log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007366) + _0023_003Dz5I3b_GM_003D.SecondOperand.EntityLabel);
				}
			}
		}
		else if (_0023_003Dz5I3b_GM_003D.SecondOperand is IIfcBoxedHalfSpace)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008050));
		}
		else
		{
			if (_0023_003Dz5I3b_GM_003D.SecondOperand is IIfcHalfSpaceSolid ifcHalfSpaceSolid)
			{
				IIfcPlane ifcPlane2 = (IIfcPlane)ifcHalfSpaceSolid.BaseSurface;
				Plane plane3 = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcPlane2.Position);
				if ((bool)ifcHalfSpaceSolid.AgreementFlag)
				{
					plane3.Flip();
				}
				Solid[] array = _0023_003DzH6GDaaq_lIr2;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].CutBy(plane3) == booleanFailureType.Failed)
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008026) + _0023_003Dz5I3b_GM_003D.SecondOperand.EntityLabel);
					}
				}
				return _0023_003DzH6GDaaq_lIr2;
			}
			_0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D2 = new _0023_003DzcntdzPM_003D();
			_0023_003Dz7tnLUCh4KvaCM5mKGrn3OA0_003D(_0023_003Dz5I3b_GM_003D.SecondOperand, ref _0023_003DzELu0Pss_003D2, _0023_003DzitRY1aRoWH5N: false, out _0023_003DzH6GDaaq_lIr, out var _);
		}
		if (_0023_003DzH6GDaaq_lIr == null)
		{
			return _0023_003DzH6GDaaq_lIr2;
		}
		Solid[] _0023_003DzOLHnb2M_003D = null;
		switch (_0023_003Dz5I3b_GM_003D.Operator)
		{
		case Xbim.Ifc4.Interfaces.IfcBooleanOperator.DIFFERENCE:
		{
			bool flag = _0023_003Dzv_bL_00248Fwl8H8(_0023_003DzH6GDaaq_lIr2, _0023_003DzH6GDaaq_lIr, _0023_003Dz5I3b_GM_003D.EntityLabel.ToString(), out _0023_003DzOLHnb2M_003D);
			if (_0023_003Dz139q_0024ZKLQnlc && flag && !_0023_003DzduYS0DQZstiQ53UTYw_003D_003D(_0023_003DzOLHnb2M_003D, DefineEps(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC)))
			{
				_0023_003Dzm2BXCjT0VKl7EUwY9w_003D_003D._0023_003DzJvr5DC0_003D(_0023_003Dzw0lyEoKIRK4H);
				return new Solid[1] { _0023_003Dzw0lyEoKIRK4H };
			}
			break;
		}
		case Xbim.Ifc4.Interfaces.IfcBooleanOperator.INTERSECTION:
			_0023_003DzYAKlj_rB2j8J(_0023_003DzH6GDaaq_lIr2, _0023_003DzH6GDaaq_lIr, _0023_003Dz5I3b_GM_003D.EntityLabel.ToString(), out _0023_003DzOLHnb2M_003D);
			break;
		case Xbim.Ifc4.Interfaces.IfcBooleanOperator.UNION:
			_0023_003DzKnTn5v99TpUJ(_0023_003DzH6GDaaq_lIr2, _0023_003DzH6GDaaq_lIr, _0023_003Dz5I3b_GM_003D.EntityLabel.ToString(), out _0023_003DzOLHnb2M_003D);
			break;
		}
		return _0023_003DzOLHnb2M_003D;
	}

	private bool _0023_003Dz7tnLUCh4KvaCM5mKGrn3OA0_003D(IIfcBooleanOperand _0023_003DzKoxHHcLkGbUx, ref _0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D, bool _0023_003DzitRY1aRoWH5N, out Solid[] _0023_003DzH6GDaaq_lIr4, out Solid _0023_003Dzw0lyEoKIRK4H)
	{
		_0023_003DzH6GDaaq_lIr4 = null;
		_0023_003Dzw0lyEoKIRK4H = null;
		if (_0023_003DzKoxHHcLkGbUx is IIfcBooleanResult _0023_003Dz5I3b_GM_003D)
		{
			_0023_003DzH6GDaaq_lIr4 = _0023_003Dz3XBPPRl3ZGBUfUwCNwB9QQk_003D(_0023_003Dz5I3b_GM_003D, ref _0023_003DzELu0Pss_003D, _0023_003Dz139q_0024ZKLQnlc: false, out _0023_003Dzw0lyEoKIRK4H);
		}
		else
		{
			Entity entity = _0023_003DzVYn8KqEjagTAVbuOCQ_003D_003D((IIfcRepresentationItem)_0023_003DzKoxHHcLkGbUx, ref _0023_003DzELu0Pss_003D);
			if (entity != null)
			{
				_0023_003DzH6GDaaq_lIr4 = new Solid[1];
				if (entity is Mesh)
				{
					_0023_003DzH6GDaaq_lIr4[0] = ((Mesh)entity).ConvertToSolid();
					_0023_003DzH6GDaaq_lIr4[0].ColorMethod = entity.ColorMethod;
					_0023_003DzH6GDaaq_lIr4[0].Color = entity.Color;
				}
				else
				{
					_0023_003DzH6GDaaq_lIr4[0] = (Solid)entity;
				}
				_0023_003Dzw0lyEoKIRK4H = _0023_003DzH6GDaaq_lIr4[0];
				if (_0023_003DzitRY1aRoWH5N)
				{
					_0023_003Dzm2BXCjT0VKl7EUwY9w_003D_003D._0023_003DzbBhhBAU_003D(_0023_003DzH6GDaaq_lIr4[0]);
				}
			}
		}
		_0023_003DzELu0Pss_003D._0023_003DzncyYYSlCYRMY = null;
		_0023_003DzELu0Pss_003D._0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D = null;
		return _0023_003DzH6GDaaq_lIr4 != null;
	}

	private Size3D _0023_003DzeWAzeU2mSVqA(IReadOnlyList<Entity> _0023_003Dzv7xH9gk_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		List<Point3D> list = new List<Point3D>(_0023_003Dzv7xH9gk_003D.Count * 2);
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			list.Add(item.BoxMin);
			list.Add(item.BoxMax);
		}
		Utility.BoundingBox(list, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
		Point3D point3D = _0023_003Dz_0024N_0024yKptW9BoC - _0023_003DzDPcjoBJLcqli;
		return new Size3D(point3D.X, point3D.Y, point3D.Z);
	}

	private double _0023_003DzHA1826c_003D(Entity _0023_003Dz9j7EUB0_003D, bool _0023_003Dzyeosjja2eCus)
	{
		if (_0023_003Dzyeosjja2eCus && OpeningsDeviation > 0.0)
		{
			return OpeningsDeviation;
		}
		if (Deviation > 0.0)
		{
			return Deviation;
		}
		double num = _0023_003Dzqc5bga3nl8Op(_0023_003Dz9j7EUB0_003D.EstimateBoundingBox(null, null));
		if (!_0023_003DzwYO9yMKu2gUgMxzgogDUe4A_003D)
		{
			return num;
		}
		return num * 10.0;
	}

	private static double _0023_003Dzqc5bga3nl8Op(IList<Point3D> _0023_003DzrdSL0CI_003D)
	{
		Utility.ComputeBoundingBox(_0023_003DzrdSL0CI_003D, out var boxMin, out var boxMax);
		return new Size3D(boxMin, boxMax).Diagonal / 100.0;
	}

	private static double _0023_003Dzqc5bga3nl8Op(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		return _0023_003Dzqc5bga3nl8Op(((Entity)_0023_003Dz8fpRyMu9aKjE).EstimateBoundingBox(null, null));
	}

	private double _0023_003Dz3SYTYmqUDCDS(Entity _0023_003DzGGJSiQk_003D)
	{
		Utility.ComputeBoundingBox(_0023_003DzGGJSiQk_003D.Vertices, out var boxMin, out var boxMax);
		return new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003DzxhnLabVjXjPg;
	}

	private bool _0023_003DzCe2ixK4DTvDPzdAwBg_003D_003D(Line _0023_003Dzb6QRI3w_003D, Line _0023_003DzR9km_CY_003D, double _0023_003DzEGKj_0024SNUUihi, bool _0023_003DztMfmrg831haV, bool _0023_003DzJ3tTnH9nlIDz, bool _0023_003DzR7z_0024HyI_003D, bool _0023_003DzHBg2_aY_003D, out Arc _0023_003Dzxt7paKBusKOo, out bool _0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D, out bool _0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D)
	{
		_0023_003Dzxt7paKBusKOo = null;
		_0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D = false;
		_0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D = false;
		_0023_003Dzb6QRI3w_003D.GetTightBBox(out var boxMin, out var boxMax);
		_0023_003DzR9km_CY_003D.GetTightBBox(out var boxMin2, out var boxMax2);
		Size3D size3D = new Size3D(boxMin, boxMax);
		Size3D size3D2 = new Size3D(boxMin2, boxMax2);
		double diagonal = size3D.Diagonal;
		double diagonal2 = size3D2.Diagonal;
		double tol = Math.Min(diagonal, diagonal2) * 0.001;
		Vector3D vector3D = Vector3D.Cross(_0023_003Dzb6QRI3w_003D.StartTangent, _0023_003DzR9km_CY_003D.StartTangent);
		if (vector3D == null)
		{
			return false;
		}
		Plane plane = new Plane(_0023_003Dzb6QRI3w_003D.StartPoint, vector3D);
		if (!_0023_003Dzb6QRI3w_003D.IsInPlane(plane, tol) || !_0023_003DzR9km_CY_003D.IsInPlane(plane, tol))
		{
			return false;
		}
		ICurve curve = _0023_003Dzb6QRI3w_003D.Offset(_0023_003DzEGKj_0024SNUUihi, _0023_003DztMfmrg831haV ? vector3D : (-1.0 * vector3D))[0];
		ICurve c = _0023_003DzR9km_CY_003D.Offset(_0023_003DzEGKj_0024SNUUihi, _0023_003DzJ3tTnH9nlIDz ? vector3D : (-1.0 * vector3D))[0];
		Point3D[] array = curve.IntersectWith(c);
		if (array.Length == 1 && !Vector3D.AreParallel(_0023_003Dzb6QRI3w_003D.Tangent, _0023_003DzR9km_CY_003D.Tangent))
		{
			Point3D point3D = array[0];
			_0023_003Dzb6QRI3w_003D.ClosestPointTo(point3D, out var t);
			_0023_003DzR9km_CY_003D.ClosestPointTo(point3D, out var t2);
			Point3D point3D2 = _0023_003Dzb6QRI3w_003D.PointAt(t);
			Point3D point3D3 = _0023_003DzR9km_CY_003D.PointAt(t2);
			if (point3D2 == point3D3)
			{
				return false;
			}
			_0023_003Dzxt7paKBusKOo = new Arc(plane, point3D, _0023_003DzEGKj_0024SNUUihi, point3D2, point3D3, flip: false);
			if (_0023_003Dzxt7paKBusKOo.AngleInRadians > Utility._0023_003DzSNemwQo_003D)
			{
				_0023_003Dzxt7paKBusKOo = new Arc(plane, point3D, _0023_003DzEGKj_0024SNUUihi, point3D2, point3D3, flip: true);
			}
			Vector3D vector3D2 = _0023_003Dzb6QRI3w_003D.TangentAt(t);
			Vector3D vector3D3 = _0023_003DzR9km_CY_003D.TangentAt(t2);
			if (vector3D2 * _0023_003Dzxt7paKBusKOo.StartTangent >= 0.0)
			{
				if (_0023_003DzR7z_0024HyI_003D)
				{
					_0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D = !_0023_003Dzb6QRI3w_003D.TrimBy(point3D2, flipSide: false);
				}
				if (_0023_003DzHBg2_aY_003D)
				{
					if (vector3D3 * _0023_003Dzxt7paKBusKOo.EndTangent >= 0.0)
					{
						_0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D = !_0023_003DzR9km_CY_003D.TrimBy(point3D3, flipSide: true);
					}
					else
					{
						_0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D = !_0023_003DzR9km_CY_003D.TrimBy(point3D3, flipSide: false);
					}
				}
			}
			else
			{
				_0023_003Dzxt7paKBusKOo.Reverse();
				if (_0023_003DzR7z_0024HyI_003D)
				{
					_0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D = !_0023_003Dzb6QRI3w_003D.TrimBy(point3D2, flipSide: true);
				}
				if (_0023_003DzHBg2_aY_003D)
				{
					if (vector3D3 * _0023_003Dzxt7paKBusKOo.StartTangent >= 0.0)
					{
						_0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D = !_0023_003DzR9km_CY_003D.TrimBy(point3D3, flipSide: false);
					}
					else
					{
						_0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D = !_0023_003DzR9km_CY_003D.TrimBy(point3D3, flipSide: true);
					}
				}
			}
			return true;
		}
		return false;
	}

	private bool _0023_003Dzc8KEJIfxqeHXO4f6fA_003D_003D(Line _0023_003DziMjqlCo_003D, Line _0023_003DzI4dRPW0_003D, double? _0023_003DzRpXgovo_003D, out Arc _0023_003Dzt95BJD8_003D, out bool _0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D, out bool _0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D)
	{
		_0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D = false;
		_0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D = false;
		_0023_003Dzt95BJD8_003D = null;
		if (_0023_003DzRpXgovo_003D > 0.0)
		{
			_0023_003DzCe2ixK4DTvDPzdAwBg_003D_003D(_0023_003DziMjqlCo_003D, _0023_003DzI4dRPW0_003D, _0023_003DzRpXgovo_003D.Value, _0023_003DztMfmrg831haV: false, _0023_003DzJ3tTnH9nlIDz: false, _0023_003DzR7z_0024HyI_003D: true, _0023_003DzHBg2_aY_003D: true, out _0023_003Dzt95BJD8_003D, out _0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D, out _0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D);
			if (_0023_003Dzt95BJD8_003D != null)
			{
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzLIfXJjwY9lEIN_Tddw_003D_003D(Line[] _0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D, int _0023_003DzlYuo0pI_003D, int _0023_003DzDMVqodM_003D, double _0023_003DzccAR5G0_003D)
	{
		if (Segment3D.Intersection(new Segment3D(_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[_0023_003DzlYuo0pI_003D].StartPoint, _0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[_0023_003DzlYuo0pI_003D].EndPoint), new Segment3D(_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[_0023_003DzDMVqodM_003D].StartPoint, _0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[_0023_003DzDMVqodM_003D].EndPoint), infinite: true, out var pointOnA, out var pointOnB) && Point3D.AreEqual(pointOnA, pointOnB, _0023_003DzccAR5G0_003D))
		{
			_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[_0023_003DzlYuo0pI_003D].EndPoint = pointOnA;
			_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[_0023_003DzDMVqodM_003D].StartPoint = pointOnB;
		}
	}

	private List<ICurve> _0023_003DzPpwHTKpPyp5fU5nslQLVJWqOoc_h(Line[] _0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D, int[] _0023_003Dzue7OCqJstHoCp_0024_0024dlA_003D_003D, double?[] _0023_003Dzy4bDlehDDZNnJ2uWhA_003D_003D)
	{
		if (_0023_003Dzue7OCqJstHoCp_0024_0024dlA_003D_003D.Length != _0023_003Dzy4bDlehDDZNnJ2uWhA_003D_003D.Length)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008217));
		}
		List<ICurve> list = new List<ICurve>(_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D.Length + _0023_003Dzue7OCqJstHoCp_0024_0024dlA_003D_003D.Length);
		int num = 0;
		bool flag = _0023_003Dzue7OCqJstHoCp_0024_0024dlA_003D_003D.Length != 0;
		bool flag2 = false;
		for (int i = 0; i < _0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D.Length; i++)
		{
			if (flag && num < _0023_003Dzue7OCqJstHoCp_0024_0024dlA_003D_003D.Length && i == _0023_003Dzue7OCqJstHoCp_0024_0024dlA_003D_003D[num])
			{
				if (_0023_003Dzc8KEJIfxqeHXO4f6fA_003D_003D(_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[i], _0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[i + 1], _0023_003Dzy4bDlehDDZNnJ2uWhA_003D_003D[num], out var _0023_003Dzt95BJD8_003D, out var _0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D, out var _0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D))
				{
					if (!_0023_003DzsfI8ebx4XdA1zVo0Bg_003D_003D && !flag2)
					{
						list.Add(_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[i]);
					}
					list.Add(_0023_003Dzt95BJD8_003D);
					flag2 = flag2 || _0023_003Dz7DDB_0024MJecGwgk_Ibmg_003D_003D;
				}
				else
				{
					list.Add(_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[i]);
				}
				num++;
			}
			else
			{
				if (!flag2)
				{
					list.Add(_0023_003DzNRHaYyhMRE7bjxXxJQ_003D_003D[i]);
				}
				flag2 = false;
			}
		}
		return list;
	}

	private devDept.Eyeshot.Entities.Region _0023_003DzhikIXWXUjVB78a7HKQ_003D_003D(IIfcProfileDef _0023_003DzI1pipBQVwKPg, out Point3D _0023_003DzbUvT9Pc_003D, bool _0023_003Dzyeosjja2eCus)
	{
		if (_0023_003DzJbrxuN7FfKk4.TryGetValue(_0023_003DzI1pipBQVwKPg.EntityLabel, out var value))
		{
			devDept.Eyeshot.Entities.Region region = (devDept.Eyeshot.Entities.Region)value.Item1.Clone();
			_0023_003DzbUvT9Pc_003D = region.Plane.Origin;
			return region;
		}
		devDept.Eyeshot.Entities.Region region2 = null;
		_0023_003DzbUvT9Pc_003D = Point3D.Origin;
		Point3D _0023_003DzbUvT9Pc_003D2;
		if (_0023_003DzI1pipBQVwKPg is IIfcParameterizedProfileDef ifcParameterizedProfileDef)
		{
			if (!(_0023_003DzI1pipBQVwKPg is IIfcCircleHollowProfileDef ifcCircleHollowProfileDef))
			{
				if (!(_0023_003DzI1pipBQVwKPg is IIfcCircleProfileDef ifcCircleProfileDef))
				{
					if (!(_0023_003DzI1pipBQVwKPg is IIfcCShapeProfileDef ifcCShapeProfileDef))
					{
						if (!(_0023_003DzI1pipBQVwKPg is IIfcIShapeProfileDef ifcIShapeProfileDef))
						{
							if (!(_0023_003DzI1pipBQVwKPg is IIfcLShapeProfileDef ifcLShapeProfileDef))
							{
								if (!(_0023_003DzI1pipBQVwKPg is IIfcTShapeProfileDef ifcTShapeProfileDef))
								{
									if (!(_0023_003DzI1pipBQVwKPg is IIfcUShapeProfileDef ifcUShapeProfileDef))
									{
										if (!(_0023_003DzI1pipBQVwKPg is IIfcRectangleHollowProfileDef { OuterFilletRadius: var outerFilletRadius } ifcRectangleHollowProfileDef))
										{
											if (!(_0023_003DzI1pipBQVwKPg is IIfcRoundedRectangleProfileDef ifcRoundedRectangleProfileDef))
											{
												if (_0023_003DzI1pipBQVwKPg is IIfcRectangleProfileDef ifcRectangleProfileDef)
												{
													region2 = devDept.Eyeshot.Entities.Region.CreateRectangle(ifcRectangleProfileDef.XDim, ifcRectangleProfileDef.YDim, centered: true);
												}
												else
												{
													log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008148) + _0023_003DzI1pipBQVwKPg.ExpressType.ExpressName);
												}
											}
											else
											{
												double num = ifcRoundedRectangleProfileDef.XDim;
												double num2 = ifcRoundedRectangleProfileDef.YDim;
												double num3 = ifcRoundedRectangleProfileDef.RoundingRadius;
												if (num == num2 && num <= num3 * 2.0)
												{
													region2 = devDept.Eyeshot.Entities.Region.CreateCircle(ifcRoundedRectangleProfileDef.RoundingRadius);
												}
												else if (num3 == 0.0)
												{
													region2 = devDept.Eyeshot.Entities.Region.CreateRectangle(ifcRoundedRectangleProfileDef.XDim, ifcRoundedRectangleProfileDef.YDim, centered: true);
												}
												else
												{
													List<ICurve> list = new List<ICurve>();
													if (num / 2.0 > num3)
													{
														list.Add(new Line((0.0 - num) / 2.0 + num3, (0.0 - num2) / 2.0, num / 2.0 - num3, (0.0 - num2) / 2.0));
													}
													list.Add(new Arc(num / 2.0 - num3, (0.0 - num2) / 2.0 + num3, 0.0, num3, Utility.DegToRad(270.0), Utility.DegToRad(360.0)));
													if (num2 / 2.0 > num3)
													{
														list.Add(new Line(num / 2.0, (0.0 - num2) / 2.0 + num3, num / 2.0, num2 / 2.0 - num3));
													}
													list.Add(new Arc(num / 2.0 - num3, num2 / 2.0 - num3, 0.0, num3, Utility.DegToRad(0.0), Utility.DegToRad(90.0)));
													if (num / 2.0 > num3)
													{
														list.Add(new Line(num / 2.0 - num3, num2 / 2.0, (0.0 - num) / 2.0 + num3, num2 / 2.0));
													}
													list.Add(new Arc((0.0 - num) / 2.0 + num3, num2 / 2.0 - num3, 0.0, num3, Utility.DegToRad(90.0), Utility.DegToRad(180.0)));
													if (num2 / 2.0 > num3)
													{
														list.Add(new Line((0.0 - num) / 2.0, num2 / 2.0 - num3, (0.0 - num) / 2.0, (0.0 - num2) / 2.0 + num3));
													}
													list.Add(new Arc((0.0 - num) / 2.0 + num3, (0.0 - num2) / 2.0 + num3, 0.0, num3, Utility.DegToRad(180.0), Utility.DegToRad(270.0)));
													region2 = new devDept.Eyeshot.Entities.Region(new CompositeCurve(list));
												}
											}
										}
										else
										{
											CompositeCurve compositeCurve = ((!((double?)outerFilletRadius > 0.0)) ? CompositeCurve.CreateRectangle(ifcRectangleHollowProfileDef.XDim, ifcRectangleHollowProfileDef.YDim, centered: true) : CompositeCurve.CreateRoundedRectangle(ifcRectangleHollowProfileDef.XDim, ifcRectangleHollowProfileDef.YDim, ifcRectangleHollowProfileDef.OuterFilletRadius.Value, centered: true));
											CompositeCurve compositeCurve2 = ((!((double?)ifcRectangleHollowProfileDef.InnerFilletRadius > 0.0)) ? CompositeCurve.CreateRectangle((double)ifcRectangleHollowProfileDef.XDim - (double)ifcRectangleHollowProfileDef.WallThickness * 2.0, (double)ifcRectangleHollowProfileDef.YDim - (double)ifcRectangleHollowProfileDef.WallThickness * 2.0, centered: true) : CompositeCurve.CreateRoundedRectangle((double)ifcRectangleHollowProfileDef.XDim - (double)ifcRectangleHollowProfileDef.WallThickness * 2.0, (double)ifcRectangleHollowProfileDef.YDim - (double)ifcRectangleHollowProfileDef.WallThickness * 2.0, ifcRectangleHollowProfileDef.InnerFilletRadius.Value, centered: true));
											region2 = new devDept.Eyeshot.Entities.Region(compositeCurve, compositeCurve2);
										}
									}
									else
									{
										double num4 = (double)ifcUShapeProfileDef.Depth / 2.0;
										double num5 = (double)ifcUShapeProfileDef.FlangeWidth / 2.0;
										Point2D[] array = new Point2D[9]
										{
											new Point2D(0.0 - num5, 0.0 - num4),
											new Point2D(num5, 0.0 - num4),
											new Point2D(num5, 0.0 - num4 + (double)ifcUShapeProfileDef.FlangeThickness),
											new Point2D(0.0 - num5 + (double)ifcUShapeProfileDef.WebThickness, 0.0 - num4 + (double)ifcUShapeProfileDef.FlangeThickness),
											new Point2D(0.0 - num5 + (double)ifcUShapeProfileDef.WebThickness, num4 - (double)ifcUShapeProfileDef.FlangeThickness),
											new Point2D(num5, num4 - (double)ifcUShapeProfileDef.FlangeThickness),
											new Point2D(num5, num4),
											new Point2D(0.0 - num5, num4),
											new Point2D(0.0 - num5, 0.0 - num4)
										};
										Line[] array2 = new Line[8];
										for (int i = 0; i < array2.Length; i++)
										{
											array2[i] = new Line(Plane.XY, array[i], array[i + 1]);
										}
										if ((double?)ifcUShapeProfileDef.FlangeSlope > 0.0)
										{
											double num6 = ((_0023_003Dz54yRp_1nJ0Tq == (_0023_003DzZKByqt9RvKDq)1) ? Utility.DegToRad(ifcUShapeProfileDef.FlangeSlope.Value) : ((double)ifcUShapeProfileDef.FlangeSlope.Value));
											if (num6 < Math.PI / 2.0)
											{
												array2[2].Rotate(0.0 - num6, Vector3D.AxisZ, new Point3D(0.0, 0.0 - num4 + (double)ifcUShapeProfileDef.FlangeThickness));
												array2[4].Rotate(num6, Vector3D.AxisZ, new Point3D(0.0, num4 - (double)ifcUShapeProfileDef.FlangeThickness));
												_0023_003DzLIfXJjwY9lEIN_Tddw_003D_003D(array2, 1, 2, ifcUShapeProfileDef.FlangeWidth);
												_0023_003DzLIfXJjwY9lEIN_Tddw_003D_003D(array2, 2, 3, ifcUShapeProfileDef.FlangeWidth);
												_0023_003DzLIfXJjwY9lEIN_Tddw_003D_003D(array2, 3, 4, ifcUShapeProfileDef.FlangeWidth);
												_0023_003DzLIfXJjwY9lEIN_Tddw_003D_003D(array2, 4, 5, ifcUShapeProfileDef.FlangeWidth);
											}
										}
										region2 = new devDept.Eyeshot.Entities.Region(new CompositeCurve(_0023_003DzPpwHTKpPyp5fU5nslQLVJWqOoc_h(array2, new int[4] { 1, 2, 3, 4 }, new double?[4] { ifcUShapeProfileDef.EdgeRadius, ifcUShapeProfileDef.FilletRadius, ifcUShapeProfileDef.FilletRadius, ifcUShapeProfileDef.EdgeRadius }), 0.1));
									}
								}
								else
								{
									region2 = new devDept.Eyeshot.Entities.Region(new LinearPath(points: new Point2D[9]
									{
										new Point2D((double)ifcTShapeProfileDef.FlangeWidth / 2.0, (double)ifcTShapeProfileDef.Depth / 2.0),
										new Point2D((0.0 - (double)ifcTShapeProfileDef.FlangeWidth) / 2.0, (double)ifcTShapeProfileDef.Depth / 2.0),
										new Point2D((0.0 - (double)ifcTShapeProfileDef.FlangeWidth) / 2.0, (double)ifcTShapeProfileDef.Depth / 2.0 - (double)ifcTShapeProfileDef.FlangeThickness),
										new Point2D((0.0 - (double)ifcTShapeProfileDef.WebThickness) / 2.0, (double)ifcTShapeProfileDef.Depth / 2.0 - (double)ifcTShapeProfileDef.FlangeThickness),
										new Point2D((0.0 - (double)ifcTShapeProfileDef.WebThickness) / 2.0, (0.0 - (double)ifcTShapeProfileDef.Depth) / 2.0),
										new Point2D((double)ifcTShapeProfileDef.WebThickness / 2.0, (0.0 - (double)ifcTShapeProfileDef.Depth) / 2.0),
										new Point2D((double)ifcTShapeProfileDef.WebThickness / 2.0, (double)ifcTShapeProfileDef.Depth / 2.0 - (double)ifcTShapeProfileDef.FlangeThickness),
										new Point2D((double)ifcTShapeProfileDef.FlangeWidth / 2.0, (double)ifcTShapeProfileDef.Depth / 2.0 - (double)ifcTShapeProfileDef.FlangeThickness),
										new Point2D((double)ifcTShapeProfileDef.FlangeWidth / 2.0, (double)ifcTShapeProfileDef.Depth / 2.0)
									}, sketchPlane: Plane.XY));
								}
							}
							else
							{
								double num7 = (double)ifcLShapeProfileDef.Depth / 2.0;
								double num8 = (ifcLShapeProfileDef.Width.HasValue ? ((double)ifcLShapeProfileDef.Width.Value / 2.0) : num7);
								double num9 = ifcLShapeProfileDef.Thickness;
								Point2D[] array3 = new Point2D[7]
								{
									new Point2D(0.0 - num8, 0.0 - num7),
									new Point2D(num8, 0.0 - num7),
									new Point2D(num8, 0.0 - num7 + num9),
									new Point2D(0.0 - num8 + num9, 0.0 - num7 + num9),
									new Point2D(0.0 - num8 + num9, num7),
									new Point2D(0.0 - num8, num7),
									new Point2D(0.0 - num8, 0.0 - num7)
								};
								Line[] array4 = new Line[6]
								{
									new Line(Plane.XY, array3[0], array3[1]),
									new Line(Plane.XY, array3[1], array3[2]),
									new Line(Plane.XY, array3[2], array3[3]),
									new Line(Plane.XY, array3[3], array3[4]),
									new Line(Plane.XY, array3[4], array3[5]),
									new Line(Plane.XY, array3[5], array3[6])
								};
								if ((double?)ifcLShapeProfileDef.LegSlope > 0.0)
								{
									double num10 = ((_0023_003Dz54yRp_1nJ0Tq == (_0023_003DzZKByqt9RvKDq)1) ? Utility.DegToRad(ifcLShapeProfileDef.LegSlope.Value) : ((double)ifcLShapeProfileDef.LegSlope.Value));
									if (num10 < Math.PI / 2.0)
									{
										array4[2].Rotate(0.0 - num10, Vector3D.AxisZ, array4[2].StartPoint);
										array4[3].Rotate(num10, Vector3D.AxisZ, array4[3].EndPoint);
										_0023_003DzLIfXJjwY9lEIN_Tddw_003D_003D(array4, 2, 3, num8 * 2.0);
									}
								}
								region2 = new devDept.Eyeshot.Entities.Region(new CompositeCurve(_0023_003DzPpwHTKpPyp5fU5nslQLVJWqOoc_h(array4, new int[3] { 1, 2, 3 }, new double?[3] { ifcLShapeProfileDef.EdgeRadius, ifcLShapeProfileDef.FilletRadius, ifcLShapeProfileDef.EdgeRadius }), 0.1));
							}
						}
						else
						{
							double num11 = (double)ifcIShapeProfileDef.OverallWidth / 2.0;
							double num12 = (double)ifcIShapeProfileDef.OverallDepth / 2.0;
							Point2D[] array5 = new Point2D[13]
							{
								new Point2D(0.0 - num11, 0.0 - num12),
								new Point2D(num11, 0.0 - num12),
								new Point2D(num11, 0.0 - num12 + (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D((double)ifcIShapeProfileDef.WebThickness / 2.0, 0.0 - num12 + (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D((double)ifcIShapeProfileDef.WebThickness / 2.0, num12 - (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D(num11, num12 - (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D(num11, num12),
								new Point2D(0.0 - num11, num12),
								new Point2D(0.0 - num11, num12 - (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D((0.0 - (double)ifcIShapeProfileDef.WebThickness) / 2.0, num12 - (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D((0.0 - (double)ifcIShapeProfileDef.WebThickness) / 2.0, 0.0 - num12 + (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D(0.0 - num11, 0.0 - num12 + (double)ifcIShapeProfileDef.FlangeThickness),
								new Point2D(0.0 - num11, 0.0 - num12)
							};
							if ((double?)ifcIShapeProfileDef.FilletRadius > 0.0)
							{
								Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure value2 = ifcIShapeProfileDef.FilletRadius.Value;
								Arc arc = new Arc(Plane.XY, array5[3] + new Vector2D(value2, value2), value2, Math.PI, 4.71238898038469);
								arc.Reverse();
								Arc arc2 = new Arc(Plane.XY, array5[4] + new Vector2D(value2, 0.0 - (double)value2), value2, Math.PI / 2.0, Math.PI);
								arc2.Reverse();
								Arc arc3 = new Arc(Plane.XY, array5[9] + new Vector2D(0.0 - (double)value2, 0.0 - (double)value2), value2, 0.0, Math.PI / 2.0);
								arc3.Reverse();
								Arc arc4 = new Arc(Plane.XY, array5[10] + new Vector2D(0.0 - (double)value2, value2), value2, 4.71238898038469, Math.PI * 2.0);
								arc4.Reverse();
								LinearPath item = new LinearPath(Plane.XY, array5[10] + new Vector2D(0.0 - (double)value2, 0.0), array5[11], array5[0], array5[1], array5[2], array5[3] + new Vector2D(value2, 0.0));
								Line item2 = new Line(new Point3D(array5[3].X, array5[3].Y + (double)value2), new Point3D(array5[4].X, array5[4].Y - (double)value2));
								LinearPath item3 = new LinearPath(Plane.XY, array5[4] + new Vector2D(value2, 0.0), array5[5], array5[6], array5[7], array5[8], array5[9] + new Vector2D(0.0 - (double)value2, 0.0));
								Line item4 = new Line(new Point3D(array5[9].X, array5[9].Y - (double)value2), new Point3D(array5[10].X, array5[10].Y + (double)value2));
								region2 = new devDept.Eyeshot.Entities.Region(new CompositeCurve(new List<ICurve> { item, arc, item2, arc2, item3, arc3, item4, arc4 }));
							}
							else
							{
								region2 = new devDept.Eyeshot.Entities.Region(new LinearPath(Plane.XY, array5));
							}
						}
					}
					else
					{
						double num13 = ifcCShapeProfileDef.Width;
						double num14 = ifcCShapeProfileDef.Depth;
						double num15 = ifcCShapeProfileDef.WallThickness;
						double num16 = ifcCShapeProfileDef.Girth;
						double? num17 = ifcCShapeProfileDef.InternalFilletRadius;
						List<Point3D> list2 = new List<Point3D>(6);
						bool flag = num15 < num16;
						if (flag)
						{
							list2.Add(new Point3D(num13 - num15, num14 - num16));
						}
						list2.Add(new Point3D(num13 - num15, num14 - num15));
						list2.Add(new Point3D(num15, num14 - num15));
						list2.Add(new Point3D(num15, num15));
						list2.Add(new Point3D(num13 - num15, num15));
						if (flag)
						{
							list2.Add(new Point3D(num13 - num15, num16));
						}
						if (!num17.HasValue)
						{
							Plane xY = Plane.XY;
							Point2D[] points = list2.ToArray();
							region2 = new LinearPath(xY, points).OffsetToRegion(num15, sharp: true);
						}
						else
						{
							List<ICurve> list3 = null;
							Line[] array6 = new Line[flag ? 5 : 3];
							array6[0] = new Line(Plane.XY, list2[0], list2[1]);
							array6[1] = new Line(Plane.XY, list2[1], list2[2]);
							array6[2] = new Line(Plane.XY, list2[2], list2[3]);
							if (flag)
							{
								array6[3] = new Line(Plane.XY, list2[3], list2[4]);
								array6[4] = new Line(Plane.XY, list2[4], list2[5]);
								list3 = _0023_003DzPpwHTKpPyp5fU5nslQLVJWqOoc_h(array6, new int[4] { 0, 1, 2, 3 }, new double?[4] { num17, num17, num17, num17 });
							}
							else
							{
								list3 = _0023_003DzPpwHTKpPyp5fU5nslQLVJWqOoc_h(array6, new int[2] { 0, 1 }, new double?[2] { num17, num17 });
							}
							region2 = new CompositeCurve(list3).OffsetToRegion(num15, sharp: true);
						}
						region2.Translate((0.0 - num13) / 2.0, (0.0 - num14) / 2.0);
					}
				}
				else if ((double)ifcCircleProfileDef.Radius > 0.0)
				{
					region2 = devDept.Eyeshot.Entities.Region.CreateCircle(ifcCircleProfileDef.Radius);
				}
			}
			else
			{
				region2 = new Circle(0.0, 0.0, 0.0, ifcCircleHollowProfileDef.Radius).OffsetToRegion(0.0 - (double)ifcCircleHollowProfileDef.WallThickness, sharp: false);
			}
			if (ifcParameterizedProfileDef.Position != null && region2 != null)
			{
				Plane plane = _0023_003DzBKvzc_JDbZ_0y_b7_0024Q0rMC8_003D(ifcParameterizedProfileDef.Position);
				_0023_003DzbUvT9Pc_003D = plane.Origin;
				Align3D xform = new Align3D(Plane.XY, plane);
				region2.TransformBy(xform);
			}
		}
		else if (_0023_003DzI1pipBQVwKPg is IIfcArbitraryClosedProfileDef ifcArbitraryClosedProfileDef)
		{
			List<ICurve> list4 = new List<ICurve>();
			ICurve _0023_003Dz06A5WivSSyUp = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcArbitraryClosedProfileDef.OuterCurve, _0023_003DzXSrUO6ixqq8l: true, null, null);
			if (_0023_003Dz06A5WivSSyUp != null)
			{
				Utility.ComputeBoundingBox(((Entity)_0023_003Dz06A5WivSSyUp).EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
				_0023_003DzbUvT9Pc_003D = Point3D.MidPoint(boxMin, boxMax);
				double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D = _0023_003DzHA1826c_003D((Entity)_0023_003Dz06A5WivSSyUp, _0023_003Dzyeosjja2eCus);
				_0023_003Dz4amkCTkgcTWPQCcwiw_003D_003D(ref _0023_003Dz06A5WivSSyUp, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
				if (((LinearPath)_0023_003Dz06A5WivSSyUp).Vertices.Length < 4)
				{
					log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007862), ifcArbitraryClosedProfileDef.ExpressType.ExpressName, _0023_003DzI1pipBQVwKPg.EntityLabel));
					return null;
				}
				list4.Add(_0023_003Dz06A5WivSSyUp);
				if (ifcArbitraryClosedProfileDef is IIfcArbitraryProfileDefWithVoids ifcArbitraryProfileDefWithVoids)
				{
					foreach (IIfcCurve innerCurf in ifcArbitraryProfileDefWithVoids.InnerCurves)
					{
						ICurve _0023_003Dz06A5WivSSyUp2 = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(innerCurf, _0023_003DzXSrUO6ixqq8l: true, null, null);
						if (_0023_003Dz06A5WivSSyUp2 != null)
						{
							_0023_003Dz4amkCTkgcTWPQCcwiw_003D_003D(ref _0023_003Dz06A5WivSSyUp2, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
							list4.Add(_0023_003Dz06A5WivSSyUp2);
						}
					}
				}
				region2 = new devDept.Eyeshot.Entities.Region(list4);
			}
		}
		else if (_0023_003DzI1pipBQVwKPg is IIfcCenterLineProfileDef ifcCenterLineProfileDef)
		{
			ICurve curve = _0023_003DzNxFOIS2YIfeIx76DDg_003D_003D(ifcCenterLineProfileDef.Curve, _0023_003DzXSrUO6ixqq8l: false, null, null);
			double num18 = ifcCenterLineProfileDef.Thickness;
			_0023_003Dzqc5bga3nl8Op(curve);
			ICurve[] array7 = curve.Offset((0.0 - num18) / 2.0, Vector3D.AxisZ, sharp: true);
			if (array7.Length > 1)
			{
				AppendToLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007805));
			}
			region2 = array7[0].OffsetToRegion(num18, sharp: true);
		}
		else if (_0023_003DzI1pipBQVwKPg is IIfcDerivedProfileDef ifcDerivedProfileDef)
		{
			region2 = _0023_003DzhikIXWXUjVB78a7HKQ_003D_003D(ifcDerivedProfileDef.ParentProfile, out _0023_003DzbUvT9Pc_003D2, _0023_003Dzyeosjja2eCus);
			region2.TransformBy(_0023_003DzhtfsWblAbRNzbCKR7Z2omJbvxaHg(ifcDerivedProfileDef.Operator));
		}
		else if (_0023_003DzI1pipBQVwKPg is IIfcCompositeProfileDef ifcCompositeProfileDef)
		{
			Queue<devDept.Eyeshot.Entities.Region> queue = new Queue<devDept.Eyeshot.Entities.Region>(ifcCompositeProfileDef.Profiles.Count);
			foreach (IIfcProfileDef profile in ifcCompositeProfileDef.Profiles)
			{
				queue.Enqueue(_0023_003DzhikIXWXUjVB78a7HKQ_003D_003D(profile, out _0023_003DzbUvT9Pc_003D2, _0023_003Dzyeosjja2eCus));
			}
			queue = _0023_003DzlnWhOSAK6jFeoJzv0I66CicbTZIJ(queue, out var _0023_003DzHmeW5F62Tn8hrBMYAw_003D_003D);
			if (_0023_003DzHmeW5F62Tn8hrBMYAw_003D_003D)
			{
				int num19 = queue.Count * queue.Count;
				int num20 = 0;
				region2 = queue.Dequeue();
				while (queue.Count > 0)
				{
					devDept.Eyeshot.Entities.Region[] array8 = devDept.Eyeshot.Entities.Region.Union(region2, queue.Dequeue());
					if (array8 == null)
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007963));
						region2 = null;
						break;
					}
					region2 = array8[0];
					for (int j = 1; j < array8.Length; j++)
					{
						queue.Enqueue(array8[j]);
					}
					num20++;
					if (num20 == num19)
					{
						region2 = null;
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007895));
						break;
					}
				}
			}
			else
			{
				log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303007895));
			}
		}
		if (region2 == null)
		{
			log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303006591), _0023_003DzI1pipBQVwKPg.ExpressType.ExpressName, _0023_003DzI1pipBQVwKPg.EntityLabel));
		}
		else
		{
			IfcProperties ifcProperties = new IfcProperties();
			ifcProperties.Identification.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008602), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027) + _0023_003DzI1pipBQVwKPg.EntityLabel);
			Dictionary<string, string> identification = ifcProperties.Identification;
			string key = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008582);
			Xbim.Ifc4.MeasureResource.IfcLabel? profileName = _0023_003DzI1pipBQVwKPg.ProfileName;
			identification.Add(key, profileName.HasValue ? ((string)profileName.GetValueOrDefault()) : null);
			ifcProperties.Identification.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008568), _0023_003DzI1pipBQVwKPg.ProfileType.ToString());
			region2.IfcProperties = ifcProperties;
			_0023_003DzJbrxuN7FfKk4.Add(_0023_003DzI1pipBQVwKPg.EntityLabel, new Tuple<Entity, _0023_003DzcntdzPM_003D>((Entity)region2.Clone(), null));
		}
		return region2;
	}

	private static Queue<devDept.Eyeshot.Entities.Region> _0023_003DzlnWhOSAK6jFeoJzv0I66CicbTZIJ(Queue<devDept.Eyeshot.Entities.Region> _0023_003Dz2C3D9QY_003D, out bool _0023_003DzHmeW5F62Tn8hrBMYAw_003D_003D)
	{
		Tuple<devDept.Eyeshot.Entities.Region, double[]>[] array = _0023_003Dz2C3D9QY_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz7Y8e2Iq5yq7qjYEC6iVifwewGuV6yxkgV0rpUgk_003D).ToArray();
		bool[] array2 = new bool[array.Length];
		_0023_003DzHmeW5F62Tn8hrBMYAw_003D_003D = false;
		for (int i = 0; i < array.Length; i++)
		{
			double num = array[i].Item2[0];
			double num2 = array[i].Item2[1];
			double num3 = array[i].Item2[2];
			double num4 = array[i].Item2[3];
			for (int j = i + 1; j < array.Length; j++)
			{
				double num5 = array[j].Item2[0];
				double num6 = array[j].Item2[1];
				double num7 = array[j].Item2[2];
				double num8 = array[j].Item2[3];
				if (num != num3 && num4 != num2 && num7 != num5 && num8 != num6 && !(num > num7) && !(num5 > num3) && !(num2 > num8) && !(num6 > num4))
				{
					array2[i] = true;
					array2[j] = true;
					_0023_003DzHmeW5F62Tn8hrBMYAw_003D_003D = true;
				}
			}
		}
		Queue<devDept.Eyeshot.Entities.Region> queue = new Queue<devDept.Eyeshot.Entities.Region>(_0023_003Dz2C3D9QY_003D.Count);
		for (int num9 = array.Length - 1; num9 >= 0; num9--)
		{
			if (array2[num9])
			{
				queue.Enqueue(array[num9].Item1);
			}
		}
		return queue;
	}

	private static void _0023_003Dz4amkCTkgcTWPQCcwiw_003D_003D(ref ICurve _0023_003Dz06A5WivSSyUp, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		if (_0023_003Dz06A5WivSSyUp is LinearPath linearPath)
		{
			linearPath.Vertices[linearPath.Vertices.Length - 1] = (Point3D)linearPath.Vertices[0].Clone();
			return;
		}
		((Entity)_0023_003Dz06A5WivSSyUp).Regen(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D);
		((Entity)_0023_003Dz06A5WivSSyUp).Vertices[((Entity)_0023_003Dz06A5WivSSyUp).Vertices.Length - 1] = (Point3D)((Entity)_0023_003Dz06A5WivSSyUp).Vertices[0].Clone();
		_0023_003Dz06A5WivSSyUp = new LinearPath(((Entity)_0023_003Dz06A5WivSSyUp).Vertices);
	}

	private Transformation _0023_003DzhtfsWblAbRNzbCKR7Z2omJbvxaHg(IIfcCartesianTransformationOperator2D _0023_003DzLw1yzfyTBA8t)
	{
		Point3D p = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(_0023_003DzLw1yzfyTBA8t.LocalOrigin);
		Vector3D x = ((_0023_003DzLw1yzfyTBA8t.Axis1 == null) ? new Vector3D(1.0, 0.0, 0.0) : _0023_003DzLw1yzfyTBA8t.Axis1._0023_003DzdVv0tHg0zCjX());
		Vector3D y = ((_0023_003DzLw1yzfyTBA8t.Axis2 == null) ? new Vector3D(0.0, 1.0, 0.0) : _0023_003DzLw1yzfyTBA8t.Axis2._0023_003DzdVv0tHg0zCjX());
		if (_0023_003DzLw1yzfyTBA8t is IIfcCartesianTransformationOperator2DnonUniform ifcCartesianTransformationOperator2DnonUniform)
		{
			x *= (double)ifcCartesianTransformationOperator2DnonUniform.Scl;
			y *= (double)ifcCartesianTransformationOperator2DnonUniform.Scl2;
			return new Transformation(p, x, y, Vector3D.AxisZ);
		}
		return new Transformation(p, x, y, Vector3D.AxisZ) * new Scaling(_0023_003DzLw1yzfyTBA8t.Scl);
	}

	private Transformation _0023_003Dzd1SOyu_9fyOH(IIfcMappedItem _0023_003DzKJTrD_A_003D)
	{
		IIfcCartesianTransformationOperator3D ifcCartesianTransformationOperator3D = (IIfcCartesianTransformationOperator3D)_0023_003DzKJTrD_A_003D.MappingTarget;
		Point3D p = _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(ifcCartesianTransformationOperator3D.LocalOrigin);
		Vector3D vector3D;
		if (ifcCartesianTransformationOperator3D.Axis1 != null)
		{
			vector3D = ifcCartesianTransformationOperator3D.Axis1._0023_003DzdVv0tHg0zCjX();
			vector3D.Normalize();
		}
		else
		{
			vector3D = new Vector3D(1.0, 0.0, 0.0);
		}
		Vector3D vector3D2;
		if (ifcCartesianTransformationOperator3D.Axis2 != null)
		{
			vector3D2 = ifcCartesianTransformationOperator3D.Axis2._0023_003DzdVv0tHg0zCjX();
			vector3D2.Normalize();
		}
		else
		{
			vector3D2 = new Vector3D(0.0, 1.0, 0.0);
		}
		Vector3D vector3D3;
		if (ifcCartesianTransformationOperator3D.Axis3 != null)
		{
			vector3D3 = ifcCartesianTransformationOperator3D.Axis3._0023_003DzdVv0tHg0zCjX();
			vector3D3.Normalize();
		}
		else
		{
			vector3D3 = new Vector3D(0.0, 0.0, 1.0);
		}
		if (ifcCartesianTransformationOperator3D is IIfcCartesianTransformationOperator3DnonUniform ifcCartesianTransformationOperator3DnonUniform)
		{
			vector3D *= (double)ifcCartesianTransformationOperator3DnonUniform.Scl;
			vector3D2 *= (double)ifcCartesianTransformationOperator3DnonUniform.Scl2;
			vector3D3 *= (double)ifcCartesianTransformationOperator3DnonUniform.Scl3;
			return new Transformation(p, vector3D, vector3D2, vector3D3);
		}
		return new Transformation(p, vector3D, vector3D2, vector3D3) * new Scaling(ifcCartesianTransformationOperator3D.Scl);
	}

	private Point3D _0023_003DzNb1A8jmu820SAlU1P0Yq2CdW_s0aDLJcYg_003D_003D(IIfcCartesianPoint _0023_003DzDxh801w_003D)
	{
		return new Point3D(_0023_003DzDxh801w_003D.X, double.IsNaN(_0023_003DzDxh801w_003D.Y) ? 0.0 : _0023_003DzDxh801w_003D.Y, double.IsNaN(_0023_003DzDxh801w_003D.Z) ? 0.0 : _0023_003DzDxh801w_003D.Z);
	}

	private double _0023_003DzIEXole_Fgi1xKqjqkMi52R8_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzysvDCm5Liblu)
	{
		if (_0023_003Dz8fpRyMu9aKjE is Circle || _0023_003Dz8fpRyMu9aKjE is Ellipse)
		{
			if (_0023_003Dz54yRp_1nJ0Tq != (_0023_003DzZKByqt9RvKDq)1)
			{
				return _0023_003DzysvDCm5Liblu;
			}
			return Utility.DegToRad(_0023_003DzysvDCm5Liblu);
		}
		if (_0023_003Dz8fpRyMu9aKjE is LinearPath linearPath)
		{
			int num = (int)_0023_003DzysvDCm5Liblu;
			double num2 = _0023_003DzysvDCm5Liblu - (double)num;
			double num3 = 0.0;
			int i;
			for (i = 0; i < num; i++)
			{
				num3 += Point3D.Distance(linearPath.Vertices[i], linearPath.Vertices[i + 1]);
			}
			if (num2 > 0.0)
			{
				double num4 = Point3D.Distance(linearPath.Vertices[i], linearPath.Vertices[i + 1]);
				num3 += num4 * num2;
			}
			return num3;
		}
		if (_0023_003Dz8fpRyMu9aKjE is Line { Domain: var domain })
		{
			return domain.Length * _0023_003DzysvDCm5Liblu;
		}
		if (_0023_003Dz8fpRyMu9aKjE is CompositeCurve compositeCurve)
		{
			double num5 = 0.0;
			{
				foreach (ICurve curve in compositeCurve.CurveList)
				{
					double num6 = _0023_003DzJTJA6BmkZR5c6nhEVUx0F7A_003D(curve, curve.Domain.Length);
					if (num6 >= _0023_003DzysvDCm5Liblu)
					{
						return num5 + _0023_003DzIEXole_Fgi1xKqjqkMi52R8_003D((ICurve)(Entity)curve, _0023_003DzysvDCm5Liblu);
					}
					num5 += curve.Domain.Length;
					_0023_003DzysvDCm5Liblu -= num6;
				}
				return num5;
			}
		}
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008554));
		return _0023_003DzysvDCm5Liblu;
	}

	private double _0023_003DzJTJA6BmkZR5c6nhEVUx0F7A_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzQU6ZJrU5LRlt)
	{
		if (_0023_003Dz8fpRyMu9aKjE is Circle || _0023_003Dz8fpRyMu9aKjE is Ellipse)
		{
			if (_0023_003Dz54yRp_1nJ0Tq != (_0023_003DzZKByqt9RvKDq)1)
			{
				return _0023_003DzQU6ZJrU5LRlt;
			}
			return Utility.RadToDeg(_0023_003DzQU6ZJrU5LRlt);
		}
		if (_0023_003Dz8fpRyMu9aKjE is LinearPath linearPath)
		{
			return linearPath.Vertices.Length - 1;
		}
		if (_0023_003Dz8fpRyMu9aKjE is CompositeCurve compositeCurve)
		{
			double num = 0.0;
			foreach (ICurve curve in compositeCurve.CurveList)
			{
				if (curve.Domain.Length >= _0023_003DzQU6ZJrU5LRlt)
				{
					return num + _0023_003DzJTJA6BmkZR5c6nhEVUx0F7A_003D(curve, _0023_003DzQU6ZJrU5LRlt);
				}
				num += _0023_003DzJTJA6BmkZR5c6nhEVUx0F7A_003D(curve, curve.Domain.Length);
				_0023_003DzQU6ZJrU5LRlt -= curve.Domain.Length;
			}
		}
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008689));
		return _0023_003DzQU6ZJrU5LRlt;
	}

	private bool _0023_003DzyABDc6eJxOBL_00241KwYA_003D_003D(IIfcRepresentationItem _0023_003DzMqRbkVw_003D, out Color _0023_003Dz1MMYB1g_003D)
	{
		_0023_003Dz1MMYB1g_003D = Color.Black;
		IIfcStyledItem[] array = _0023_003DzMqRbkVw_003D.StyledByItem.ToArray();
		if (array.Length != 0)
		{
			IIfcStyleAssignmentSelect ifcStyleAssignmentSelect = array[0].Styles.First();
			if (!(ifcStyleAssignmentSelect is IIfcPresentationStyleAssignment ifcPresentationStyleAssignment))
			{
				IIfcPresentationStyle _0023_003DzHretY75ZrHPT = ifcStyleAssignmentSelect as IIfcPresentationStyle;
				return _0023_003DzodmA4RvxHDiW(_0023_003DzHretY75ZrHPT, out _0023_003Dz1MMYB1g_003D);
			}
			foreach (IIfcPresentationStyleSelect style in ifcPresentationStyleAssignment.Styles)
			{
				if (_0023_003DzodmA4RvxHDiW((IIfcPresentationStyle)style, out _0023_003Dz1MMYB1g_003D))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool _0023_003DzodmA4RvxHDiW(IIfcPresentationStyle _0023_003DzHretY75ZrHPT, out Color _0023_003Dz1MMYB1g_003D)
	{
		_0023_003Dz1MMYB1g_003D = Color.Black;
		if (_0023_003DzHretY75ZrHPT is IIfcSurfaceStyle ifcSurfaceStyle && ifcSurfaceStyle.Styles.Count > 0)
		{
			IIfcSurfaceStyleElementSelect ifcSurfaceStyleElementSelect = ifcSurfaceStyle.Styles.First();
			int alpha = 255;
			if (!(ifcSurfaceStyleElementSelect is IIfcSurfaceStyleRendering { Transparency: var transparency } ifcSurfaceStyleRendering))
			{
				if (ifcSurfaceStyleElementSelect is IIfcSurfaceStyleShading ifcSurfaceStyleShading)
				{
					_0023_003Dz1MMYB1g_003D = Color.FromArgb(alpha, Utility.DoubleArrayToColor(new double[3]
					{
						ifcSurfaceStyleShading.SurfaceColour.Red,
						ifcSurfaceStyleShading.SurfaceColour.Green,
						ifcSurfaceStyleShading.SurfaceColour.Blue
					}));
					return true;
				}
				return false;
			}
			if (transparency.HasValue)
			{
				alpha = Convert.ToInt32((1.0 - (double?)ifcSurfaceStyleRendering.Transparency) * 255.0);
			}
			_0023_003Dz1MMYB1g_003D = Color.FromArgb(alpha, Utility.DoubleArrayToColor(new double[3]
			{
				ifcSurfaceStyleRendering.SurfaceColour.Red,
				ifcSurfaceStyleRendering.SurfaceColour.Green,
				ifcSurfaceStyleRendering.SurfaceColour.Blue
			}));
			return true;
		}
		return false;
	}

	private void _0023_003DzEmS3qUErVFPU(Entity _0023_003Dz9j7EUB0_003D, IIfcRepresentationItem _0023_003DzUBZd570_003D, _0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D)
	{
		_0023_003Dz9j7EUB0_003D.TranslationID = new TranslationIdentifier(_0023_003DzUBZd570_003D.EntityLabel);
		IfcProperties ifcProperties = new IfcProperties();
		ifcProperties.Identification.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008348), _0023_003DzUBZd570_003D.ExpressType.ExpressName);
		ifcProperties.Identification.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008602), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027) + _0023_003DzUBZd570_003D.EntityLabel);
		if (_0023_003DzELu0Pss_003D != null)
		{
			ifcProperties.ProfileDef = _0023_003DzELu0Pss_003D._0023_003DzncyYYSlCYRMY;
			ifcProperties.ExtrusionAmount = _0023_003DzELu0Pss_003D._0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D;
			_0023_003DzELu0Pss_003D._0023_003DzncyYYSlCYRMY = null;
			_0023_003DzELu0Pss_003D._0023_003Dz6_0024eM2NIWno1LoVTZnQ_003D_003D = null;
		}
		_0023_003Dz9j7EUB0_003D.IfcProperties = ifcProperties;
	}

	private void _0023_003Dzm_2oKiw_003D(Entity _0023_003Dz9j7EUB0_003D, IIfcObjectDefinition _0023_003DzSnlcGG6QPlo5, Transformation _0023_003Dzvmr_0024W_0024awLIXo, Transformation _0023_003DzBNjqNCJEWknf, _0023_003DzcntdzPM_003D _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzwYO9yMKu2gUgMxzgogDUe4A_003D && _0023_003Dz9j7EUB0_003D is Mesh mesh)
		{
			mesh.SmoothingAngle = 0.8;
		}
		_0023_003Dz9j7EUB0_003D.TranslationID = new TranslationIdentifier(_0023_003DzSnlcGG6QPlo5.EntityLabel);
		if (_0023_003Dz9j7EUB0_003D.IfcProperties == null)
		{
			_0023_003Dz9j7EUB0_003D.IfcProperties = new IfcProperties();
		}
		IfcProperties ifcProperties = _0023_003Dz9j7EUB0_003D.IfcProperties;
		_0023_003Dzm_2oKiw_003D(ifcProperties, _0023_003DzSnlcGG6QPlo5, _0023_003Dzvmr_0024W_0024awLIXo, _0023_003DzBNjqNCJEWknf);
		if (_0023_003DzSnlcGG6QPlo5 is IIfcElement ifcElement)
		{
			ifcProperties.Identification.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008330), ifcElement.Tag.ToString());
			IIfcMaterialSelect material = ifcElement.Material;
			if (material != null)
			{
				if (!(material is IIfcMaterialLayerSetUsage ifcMaterialLayerSetUsage))
				{
					if (!(material is IIfcMaterialList ifcMaterialList))
					{
						if (material is IIfcMaterial ifcMaterial)
						{
							ifcProperties.Materials.Add(ifcMaterial.Name.ToString(), double.NaN);
							_0023_003DzapSnswsNFqLT(_0023_003Dz9j7EUB0_003D, ifcMaterial.HasRepresentation.ToArray());
						}
					}
					else
					{
						IIfcMaterial ifcMaterial2 = ifcMaterialList.Materials[0];
						ifcProperties.Materials.Add(ifcMaterial2.Name.ToString(), double.NaN);
						_0023_003DzapSnswsNFqLT(_0023_003Dz9j7EUB0_003D, ifcMaterial2.HasRepresentation.ToArray());
					}
				}
				else
				{
					IItemSet<IIfcMaterialLayer> materialLayers = ifcMaterialLayerSetUsage.ForLayerSet.MaterialLayers;
					for (int i = 0; i < materialLayers.Count; i++)
					{
						IIfcMaterial material2 = materialLayers[i].Material;
						if (material2 != null)
						{
							ifcProperties.Materials.Add(i + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + material2.Name, materialLayers[i].LayerThickness);
							_0023_003DzapSnswsNFqLT(_0023_003Dz9j7EUB0_003D, material2.HasRepresentation.ToArray());
						}
					}
				}
			}
		}
		if (_0023_003Dz9j7EUB0_003D.ColorMethod != colorMethodType.byEntity)
		{
			_0023_003Dz9j7EUB0_003D.ColorMethod = colorMethodType.byEntity;
			if (DefaultColors.TryGetValue(_0023_003DzSnlcGG6QPlo5.ExpressType.ExpressName, out var value))
			{
				_0023_003Dz9j7EUB0_003D.Color = value;
			}
			else
			{
				_0023_003Dz9j7EUB0_003D.Color = ReadFileAsync.DEFAULT_COLOR;
			}
		}
		if (_0023_003DzELu0Pss_003D != null)
		{
			List<ICurve> _0023_003DzVFJEgOr2cL2N = _0023_003DzELu0Pss_003D._0023_003DzVFJEgOr2cL2N;
			if (_0023_003DzVFJEgOr2cL2N != null && _0023_003DzVFJEgOr2cL2N.Count > 0)
			{
				ifcProperties.Axes = _0023_003DzELu0Pss_003D._0023_003DzVFJEgOr2cL2N;
			}
			ifcProperties.ProfileDef?.TransformBy(_0023_003DzBNjqNCJEWknf);
			ifcProperties.ExtrusionAmount?.TransformBy(_0023_003DzBNjqNCJEWknf);
		}
	}

	private void _0023_003Dzm_2oKiw_003D(IEyeIfcObject _0023_003Dz5PT5XlDHTDM4, IIfcObjectDefinition _0023_003DzSnlcGG6QPlo5, Transformation _0023_003Dzvmr_0024W_0024awLIXo, Transformation _0023_003DzBNjqNCJEWknf)
	{
		_0023_003Dz5PT5XlDHTDM4.LocalTransformation = _0023_003Dzvmr_0024W_0024awLIXo;
		_0023_003Dz5PT5XlDHTDM4.GlobalTransformation = _0023_003DzBNjqNCJEWknf;
		_0023_003Dz5PT5XlDHTDM4.GUID = _0023_003DzSnlcGG6QPlo5.GlobalId;
		Dictionary<string, string> identification = _0023_003Dz5PT5XlDHTDM4.Identification;
		string key = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333);
		Xbim.Ifc4.MeasureResource.IfcLabel? name = _0023_003DzSnlcGG6QPlo5.Name;
		identification[key] = (name.HasValue ? ((string)name.GetValueOrDefault()) : null);
		_0023_003Dz5PT5XlDHTDM4.Identification[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008348)] = _0023_003DzSnlcGG6QPlo5.ExpressType.ExpressName;
		_0023_003Dz5PT5XlDHTDM4.Identification[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008602)] = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027) + _0023_003DzSnlcGG6QPlo5.EntityLabel;
		Dictionary<string, string> identification2 = _0023_003Dz5PT5XlDHTDM4.Identification;
		string key2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019);
		Xbim.Ifc4.MeasureResource.IfcText? description = _0023_003DzSnlcGG6QPlo5.Description;
		identification2[key2] = (description.HasValue ? ((string)description.GetValueOrDefault()) : null);
		if (_0023_003Dz5PT5XlDHTDM4 is IfcProperties ifcProperties)
		{
			ifcProperties.ElementType = (Enum.TryParse<ifcElementType>(_0023_003DzSnlcGG6QPlo5.ExpressType.ExpressName, out var result) ? result : ifcElementType.Undefined);
		}
		IEnumerable<IIfcRelDefinesByProperties> isDefinedBy;
		if (_0023_003DzSnlcGG6QPlo5 is IIfcProject ifcProject)
		{
			isDefinedBy = ifcProject.IsDefinedBy;
		}
		else
		{
			if (!(_0023_003DzSnlcGG6QPlo5 is IIfcObject ifcObject))
			{
				return;
			}
			isDefinedBy = ifcObject.IsDefinedBy;
		}
		foreach (IIfcRelDefinesByProperties item in isDefinedBy)
		{
			foreach (IIfcPropertySetDefinition propertySetDefinition in item.RelatingPropertyDefinition.PropertySetDefinitions)
			{
				_0023_003DzzCzWjv3qs75t(propertySetDefinition, _0023_003Dz5PT5XlDHTDM4.Properties, _0023_003DzSnlcGG6QPlo5.GlobalId);
			}
		}
		if (!(_0023_003DzSnlcGG6QPlo5 is IIfcObject ifcObject2))
		{
			return;
		}
		IIfcRelDefinesByType[] array = ifcObject2.IsTypedBy.ToArray();
		if (array.Length == 0 || array[0].RelatingType == null)
		{
			return;
		}
		foreach (IIfcPropertySetDefinition hasPropertySet in array[0].RelatingType.HasPropertySets)
		{
			if (hasPropertySet != null)
			{
				_0023_003DzzCzWjv3qs75t(hasPropertySet, _0023_003Dz5PT5XlDHTDM4.Properties, _0023_003DzSnlcGG6QPlo5.GlobalId);
			}
		}
	}

	private void _0023_003DzzCzWjv3qs75t(IIfcPropertySetDefinition _0023_003DzH72gQ91xpbKB, Dictionary<string, Dictionary<string, object>> _0023_003DzaraapZA_003D, string _0023_003DzA66o8_0024g_003D)
	{
		string key = _0023_003DzH72gQ91xpbKB.Name ?? ((Xbim.Ifc4.MeasureResource.IfcLabel)string.Empty);
		if (!_0023_003DzaraapZA_003D.TryGetValue(key, out var value))
		{
			value = new Dictionary<string, object>();
			_0023_003DzaraapZA_003D.Add(key, value);
		}
		if (!(_0023_003DzH72gQ91xpbKB is IIfcPropertySet ifcPropertySet))
		{
			if (!(_0023_003DzH72gQ91xpbKB is IIfcElementQuantity ifcElementQuantity))
			{
				return;
			}
			{
				foreach (IIfcPhysicalQuantity quantity in ifcElementQuantity.Quantities)
				{
					if (quantity == null)
					{
						continue;
					}
					string key2 = quantity.Name;
					double item = 0.0;
					if (!(quantity is IIfcQuantityArea ifcQuantityArea))
					{
						if (!(quantity is IIfcQuantityLength ifcQuantityLength))
						{
							if (!(quantity is IIfcQuantityVolume ifcQuantityVolume))
							{
								if (!(quantity is IIfcQuantityWeight ifcQuantityWeight))
								{
									if (quantity is IIfcQuantityCount ifcQuantityCount)
									{
										item = ifcQuantityCount.CountValue;
									}
								}
								else
								{
									item = ifcQuantityWeight.WeightValue;
								}
							}
							else
							{
								item = ifcQuantityVolume.VolumeValue;
							}
						}
						else
						{
							item = ifcQuantityLength.LengthValue;
						}
					}
					else
					{
						item = ifcQuantityArea.AreaValue;
					}
					object value2 = new Tuple<string, double>(quantity.ExpressType.ExpressName, item);
					if (!value.ContainsKey(key2))
					{
						value.Add(key2, value2);
					}
				}
				return;
			}
		}
		foreach (IIfcProperty hasProperty in ifcPropertySet.HasProperties)
		{
			_0023_003DzN6SqCNw_003D(hasProperty.Name, hasProperty, value);
		}
	}

	private void _0023_003DzN6SqCNw_003D(string _0023_003DzaE4ynZQ_003D, IIfcProperty _0023_003DzPhYK7FlEK24J, Dictionary<string, object> _0023_003Dz3QVhy_0024N9gWIJ)
	{
		if (_0023_003Dz3QVhy_0024N9gWIJ.ContainsKey(_0023_003DzaE4ynZQ_003D))
		{
			return;
		}
		object value = null;
		if (!(_0023_003DzPhYK7FlEK24J is IIfcPropertySingleValue ifcPropertySingleValue))
		{
			if (!(_0023_003DzPhYK7FlEK24J is IIfcPropertyEnumeratedValue ifcPropertyEnumeratedValue))
			{
				if (!(_0023_003DzPhYK7FlEK24J is IIfcPropertyListValue ifcPropertyListValue))
				{
					if (_0023_003DzPhYK7FlEK24J is IIfcComplexProperty ifcComplexProperty)
					{
						foreach (IIfcProperty hasProperty in ifcComplexProperty.HasProperties)
						{
							_0023_003DzN6SqCNw_003D(hasProperty.Name, hasProperty, _0023_003Dz3QVhy_0024N9gWIJ);
						}
					}
				}
				else if (ifcPropertyListValue.ListValues.Count > 0)
				{
					Type type = ifcPropertyListValue.ListValues[0].Value.GetType();
					IList list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
					foreach (IIfcValue listValue in ifcPropertyListValue.ListValues)
					{
						list.Add(listValue.Value);
					}
					value = list;
				}
			}
			else if (ifcPropertyEnumeratedValue.EnumerationValues.Count > 0)
			{
				Type type2 = ifcPropertyEnumeratedValue.EnumerationValues[0].Value.GetType();
				IList list2 = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type2));
				foreach (IIfcValue enumerationValue in ifcPropertyEnumeratedValue.EnumerationValues)
				{
					list2.Add(enumerationValue.Value);
				}
				value = list2;
			}
		}
		else if (ifcPropertySingleValue.NominalValue != null)
		{
			value = ((!(ifcPropertySingleValue.NominalValue is IExpressRealType expressRealType)) ? ifcPropertySingleValue.NominalValue.Value : new Tuple<string, double>(ifcPropertySingleValue.NominalValue.GetType().Name, expressRealType.Value));
		}
		_0023_003Dz3QVhy_0024N9gWIJ.Add(_0023_003DzaE4ynZQ_003D, value);
	}

	private void _0023_003DzapSnswsNFqLT(Entity _0023_003Dz9j7EUB0_003D, IReadOnlyList<IIfcMaterialDefinitionRepresentation> _0023_003DzunWRJdpSGL4hFZ55kg_003D_003D)
	{
		if (_0023_003DzunWRJdpSGL4hFZ55kg_003D_003D.Count == 0 || _0023_003Dz9j7EUB0_003D.ColorMethod == colorMethodType.byEntity)
		{
			return;
		}
		foreach (IIfcStyledRepresentation representation in _0023_003DzunWRJdpSGL4hFZ55kg_003D_003D[0].Representations)
		{
			foreach (IIfcStyledItem item in representation.Items)
			{
				foreach (IIfcStyleAssignmentSelect style in item.Styles)
				{
					if (!(style is IIfcPresentationStyleAssignment ifcPresentationStyleAssignment))
					{
						if (!(style is IIfcFillAreaStyle) && !(style is IIfcCurveStyle) && !(style is IIfcSurfaceStyle) && !(style is IIfcTextStyle) && style is IIfcPresentationStyle)
						{
						}
						continue;
					}
					foreach (IIfcPresentationStyleSelect style2 in ifcPresentationStyleAssignment.Styles)
					{
						if (!(style2 is IIfcSurfaceStyle ifcSurfaceStyle))
						{
							if (!(style2 is IIfcTextStyle) && style2 is IIfcCurveStyle)
							{
							}
							continue;
						}
						foreach (IIfcSurfaceStyleElementSelect style3 in ifcSurfaceStyle.Styles)
						{
							if (style3 is IIfcSurfaceStyleRendering { Transparency: var transparency } ifcSurfaceStyleRendering)
							{
								int alpha = (transparency.HasValue ? Convert.ToInt32((1.0 - (double?)ifcSurfaceStyleRendering.Transparency) * 255.0) : 255);
								_0023_003Dz9j7EUB0_003D.Color = Color.FromArgb(alpha, Utility.DoubleArrayToColor(new double[3]
								{
									ifcSurfaceStyleRendering.SurfaceColour.Red,
									ifcSurfaceStyleRendering.SurfaceColour.Green,
									ifcSurfaceStyleRendering.SurfaceColour.Blue
								}));
								_0023_003Dz9j7EUB0_003D.ColorMethod = colorMethodType.byEntity;
							}
						}
					}
				}
			}
		}
	}

	private string _0023_003DzAfiQe1xD7a07(string _0023_003DzWeBGgJjdR617)
	{
		int value = 0;
		if (_0023_003DzC9hu7B7ZCy4A.TryGetValue(_0023_003DzWeBGgJjdR617, out value))
		{
			value++;
			_0023_003DzC9hu7B7ZCy4A[_0023_003DzWeBGgJjdR617] = value;
		}
		else
		{
			_0023_003DzC9hu7B7ZCy4A.Add(_0023_003DzWeBGgJjdR617, value);
		}
		return _0023_003DzWeBGgJjdR617 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + value;
	}

	private void _0023_003DzvoVaxJKxgc_0024O(Entity _0023_003Dzs_0024uS8LA_003D, IIfcPresentationLayerAssignment _0023_003DzC2js0c63VjIBp5vu8w_003D_003D)
	{
		string text = (_0023_003Dzs_0024uS8LA_003D.LayerName = _0023_003DzC2js0c63VjIBp5vu8w_003D_003D.Name);
		if (base.Layers.Contains(text))
		{
			return;
		}
		Layer layer = new Layer(text);
		Xbim.Ifc4.MeasureResource.IfcText? description = _0023_003DzC2js0c63VjIBp5vu8w_003D_003D.Description;
		layer.Description = (description.HasValue ? ((string)description.GetValueOrDefault()) : null);
		Xbim.Ifc4.MeasureResource.IfcIdentifier? identifier = _0023_003DzC2js0c63VjIBp5vu8w_003D_003D.Identifier;
		layer.Identifier = (identifier.HasValue ? ((string)identifier.GetValueOrDefault()) : null);
		if (_0023_003DzC2js0c63VjIBp5vu8w_003D_003D is IIfcPresentationLayerWithStyle ifcPresentationLayerWithStyle)
		{
			foreach (IIfcPresentationStyle layerStyle in ifcPresentationLayerWithStyle.LayerStyles)
			{
				if (layerStyle is IIfcSurfaceStyle ifcSurfaceStyle)
				{
					foreach (IIfcSurfaceStyleElementSelect style in ifcSurfaceStyle.Styles)
					{
						if (style is IIfcSurfaceStyleRendering ifcSurfaceStyleRendering)
						{
							int alpha = Convert.ToInt32((1.0 - (double?)ifcSurfaceStyleRendering.Transparency) * 255.0);
							layer.Color = Color.FromArgb(alpha, Utility.DoubleArrayToColor(new double[3]
							{
								ifcSurfaceStyleRendering.SurfaceColour.Red,
								ifcSurfaceStyleRendering.SurfaceColour.Green,
								ifcSurfaceStyleRendering.SurfaceColour.Blue
							}));
						}
					}
				}
				else if (layerStyle is IIfcCurveStyle ifcCurveStyle)
				{
					if (ifcCurveStyle.CurveColour is IIfcColourRgb ifcColourRgb)
					{
						layer.Color = Utility.DoubleArrayToColor(new double[3] { ifcColourRgb.Red, ifcColourRgb.Green, ifcColourRgb.Blue });
					}
					else
					{
						layer.Color = Color.Empty;
					}
				}
			}
		}
		base.Layers.Add(layer);
	}

	internal static void _0023_003DqiES4wcMZAEpyaeJmGu0WfzZnj7l_0024mT8PPE3EiFF2j5QBbc_0024n2ZJGxcrm470rfBuw(IList<Entity> _0023_003Dzv7xH9gk_003D)
	{
		for (int i = 0; i < _0023_003Dzv7xH9gk_003D.Count; i++)
		{
			if (_0023_003Dzv7xH9gk_003D[i] is Solid solid)
			{
				_0023_003Dzv7xH9gk_003D[i] = solid.ConvertToMesh();
				_0023_003Dzv7xH9gk_003D[i].TranslationID = solid.TranslationID;
				_0023_003Dzv7xH9gk_003D[i].IfcProperties = solid.IfcProperties;
			}
		}
	}

	internal static void _0023_003DqxEbyZAnqUyyQhpRDdHoiwZ46KDdjuTAZEhpf9rdXhXHn4Mf_002487EvYAyayFvoaMiIWO0c6JTP54rvQkS4Y5clTw_003D_003D(IList<IIfcTrimmingSelect> _0023_003DzE36Q47s_003D, out double _0023_003Dzmk06LTk_003D, out IIfcCartesianPoint _0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D)
	{
		_0023_003Dzmk06LTk_003D = -1.0;
		_0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D = null;
		if (_0023_003DzE36Q47s_003D[0] is IIfcCartesianPoint ifcCartesianPoint)
		{
			_0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D = ifcCartesianPoint;
			if (_0023_003DzE36Q47s_003D.Count > 1)
			{
				_0023_003Dzmk06LTk_003D = (Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)_0023_003DzE36Q47s_003D[1];
			}
		}
		else
		{
			_0023_003Dzmk06LTk_003D = (Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)_0023_003DzE36Q47s_003D[0];
			if (_0023_003DzE36Q47s_003D.Count > 1)
			{
				_0023_003Dz23Yv7FpZdQApA9_0024bTQ_003D_003D = (IIfcCartesianPoint)_0023_003DzE36Q47s_003D[1];
			}
		}
	}

	internal static void _0023_003DqaejkSjaYKShwdB7EHcWWBylxxn_00242XuPnfSugcPa_0024EA7pRi_00244cJ0ZZmKP9gQnorCy8lkfJGphmyDsouy_0024ABgNeg_003D_003D(IList<Point3D> _0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D, List<double> _0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D, int _0023_003DzyzK8swU_003D, List<double> _0023_003DzCzKVJHo1PSre, ICurve _0023_003DzSwfghCo_003D)
	{
		if (_0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D == null || _0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D == null)
		{
			return;
		}
		if (_0023_003DzyzK8swU_003D == 0)
		{
			_0023_003DzCzKVJHo1PSre.Add(_0023_003DzSwfghCo_003D.Length());
		}
		else
		{
			double num = _0023_003DzCzKVJHo1PSre[_0023_003DzCzKVJHo1PSre.Count - 1];
			_0023_003DzCzKVJHo1PSre.Add(num + _0023_003DzSwfghCo_003D.Length());
		}
		double low = _0023_003DzSwfghCo_003D.Domain.Low;
		double num2 = _0023_003DzSwfghCo_003D.Domain.High;
		if (num2 < 0.0)
		{
			num2 *= -1.0;
		}
		int num3 = (int)_0023_003DzSwfghCo_003D.Length() / 15;
		for (int i = 0; i < num3; i++)
		{
			double num4 = ((num3 == 1) ? low : (low + (double)i * (num2 - low) / (double)(num3 - 1)));
			if (num4 != num2)
			{
				_0023_003DzOIWWj3BSuX2DDWOlkA_003D_003D.Add(_0023_003DzSwfghCo_003D.PointAt(num4));
				_0023_003DzSwfghCo_003D.GetLengthFromParam(num4, out var length);
				if (_0023_003DzCzKVJHo1PSre.Count == 1)
				{
					_0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D.Add(length);
				}
				else
				{
					_0023_003DzBaI6ZrpzTPLXMK0AVw_003D_003D.Add(_0023_003DzCzKVJHo1PSre[_0023_003DzCzKVJHo1PSre.Count - 2] + length);
				}
			}
		}
	}
}
