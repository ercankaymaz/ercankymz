using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class CompositeCurve : Entity, ICurve, ICloneable, IMateable, ISelectableSubItems
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Point3D, double> _0023_003DzCGlXcj2dTSAkCOvvBg_003D_003D;

		public static Func<ICurve, ICurve[]> _0023_003DzgjK9Ot9I02XenZacBg_003D_003D;

		public static Func<ICurve, bool> _0023_003DzMVGnQFBqFcN5k0oRIg_003D_003D;

		internal double _0023_003DzFF69AYUnqoYvyVMhMQ_003D_003D(Point3D _0023_003Dz437_00244ak_003D)
		{
			return ((PointTangentU)_0023_003Dz437_00244ak_003D).U;
		}

		internal ICurve[] _0023_003DzRXjcYOSP9cNHgE7NFkXsI6hYR0ISJcN_Jg_003D_003D(ICurve _0023_003DzYatz0sc_003D)
		{
			return _0023_003DzYatz0sc_003D.GetIndividualCurves();
		}

		internal bool _0023_003DzBA_VpJExH85e4mjmxHYpXHjyj33o(ICurve _0023_003DzBJFJHwk_003D)
		{
			return ((Entity)_0023_003DzBJFJHwk_003D)._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D();
		}
	}

	private int _edgeIndex = -1;

	private bool _fromBooleanIntersection;

	private List<ICurve> _curveList;

	public int EdgeIndex
	{
		get
		{
			return _edgeIndex;
		}
		set
		{
			_edgeIndex = value;
		}
	}

	public bool FromBooleanIntersection
	{
		get
		{
			return _fromBooleanIntersection;
		}
		set
		{
			_fromBooleanIntersection = value;
		}
	}

	public List<ICurve> CurveList
	{
		get
		{
			return _curveList;
		}
		set
		{
			_curveList = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool IsPoint
	{
		get
		{
			foreach (ICurve curve in _curveList)
			{
				if (!curve.IsPoint)
				{
					return false;
				}
			}
			return true;
		}
	}

	public Vector3D StartTangent => _curveList[0].StartTangent;

	public Vector3D EndTangent => _curveList[_curveList.Count - 1].EndTangent;

	public Interval Domain
	{
		get
		{
			double num = 0.0;
			foreach (ICurve curve in _curveList)
			{
				num += curve.Domain.Length;
			}
			return new Interval(0.0, num);
		}
	}

	public Point3D EndPoint => _curveList[_curveList.Count - 1].EndPoint;

	public Point3D StartPoint => _curveList[0].StartPoint;

	public bool IsClosed
	{
		get
		{
			switch (_curveList.Count)
			{
			case 0:
				return false;
			case 1:
				return _curveList[0].IsClosed;
			default:
				if (localMin == null)
				{
					return StartPoint.Equals(EndPoint);
				}
				return Point3D.AreEqual(StartPoint, EndPoint, base.BoxSize.Diagonal);
			}
		}
	}

	internal List<SelectionInfoSubItems> SubCurvesSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	public selectionFilterType SelectionMode { get; set; } = selectionFilterType.Entity;

	internal CompositeCurve()
		: base(entityNatureType.Wire)
	{
		_curveList = new List<ICurve>();
	}

	public CompositeCurve(IEnumerable<ICurve> curveList)
		: base(entityNatureType.Wire)
	{
		_curveList = new List<ICurve>(curveList);
		SortAndOrient();
	}

	public CompositeCurve(IEnumerable<ICurve> curveList, bool sortAndOrient)
		: base(entityNatureType.Wire)
	{
		_curveList = new List<ICurve>(curveList);
		if (sortAndOrient)
		{
			SortAndOrient();
		}
	}

	public CompositeCurve(IEnumerable<ICurve> curveList, double closureTol)
		: base(entityNatureType.Wire)
	{
		_curveList = new List<ICurve>(curveList);
		SortAndOrient(closureTol);
	}

	public CompositeCurve(IEnumerable<ICurve> curveList, double closureTol, bool sortAndOrient)
		: base(entityNatureType.Wire)
	{
		_curveList = new List<ICurve>(curveList);
		if (sortAndOrient)
		{
			SortAndOrient(closureTol);
		}
	}

	public CompositeCurve(params ICurve[] curveList)
		: base(entityNatureType.Wire)
	{
		_curveList = new List<ICurve>(curveList);
		SortAndOrient();
	}

	public CompositeCurve(ICurve curve)
		: base(entityNatureType.Wire)
	{
		_curveList = new List<ICurve>();
		_0023_003Dzk_1OX5z_d_0024zS(curve);
		_curveList.Add(curve);
	}

	protected CompositeCurve(CompositeCurve another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_curveList = new List<ICurve>(another._curveList.Count);
		for (int i = 0; i < another._curveList.Count; i++)
		{
			_curveList.Add((ICurve)(keepTessellation ? ((Entity)another._curveList[i]).CloneWithTessellation() : ((Entity)another._curveList[i]).Clone()));
		}
		if (keepTessellation)
		{
			_0023_003DzZTx6Or_0024_0024RWbzeZoJBQ_003D_003D();
		}
	}

	protected internal CompositeCurve(CompositeCurveSurrogate surrogate)
		: this(surrogate.GetCurveList().Cast<ICurve>().ToList(), sortAndOrient: false)
	{
	}

	internal CompositeCurve(GCompositeCurve _0023_003DzQwa1qM0_003D)
		: this(GEntity.CreateEntitiesFromPrimitives(_0023_003DzQwa1qM0_003D.CurveList)?.Cast<ICurve>().ToList(), sortAndOrient: false)
	{
	}

	protected CompositeCurve(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_curveList = (List<ICurve>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963230), typeof(List<ICurve>));
	}

	public override object Clone()
	{
		return new CompositeCurve(this);
	}

	public override object CloneWithTessellation()
	{
		return new CompositeCurve(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public Entity[] Explode()
	{
		Entity[] array = new Entity[_curveList.Count];
		for (int i = 0; i < _curveList.Count; i++)
		{
			array[i] = (Entity)_curveList[i].Clone();
			array[i].CopyAttributes(this);
		}
		return array;
	}

	internal ICurve[] _0023_003DzpoMoKemHyOl4()
	{
		List<ICurve> list = new List<ICurve>(_curveList.Count);
		foreach (ICurve curve in _curveList)
		{
			if (curve is LinearPath linearPath)
			{
				list.AddRange(linearPath.ConvertToLines());
			}
			else
			{
				list.Add(curve);
			}
		}
		return list.ToArray();
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		List<Point3D> list = new List<Point3D>(_curveList.Count);
		foreach (Entity curve in _curveList)
		{
			list.AddRange(curve.EstimateBoundingBox(blocks, layers));
		}
		return list.ToArray();
	}

	public Region OffsetToRegion(double amount, bool sharp)
	{
		if (IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane))
		{
			ICurve[] array = Offset(amount, plane.AxisZ, sharp);
			ICurve curve = ((array != null) ? array[0] : null);
			ICurve curve2 = (ICurve)Clone();
			if (amount > 0.0)
			{
				curve2.Reverse();
			}
			else
			{
				curve.Reverse();
			}
			if (IsClosed)
			{
				return new Region(new ICurve[2] { curve2, curve }, plane);
			}
			Line item = new Line(curve.EndPoint, curve2.StartPoint);
			Line item2 = new Line(curve2.EndPoint, curve.StartPoint);
			List<ICurve> list = new List<ICurve>(CurveList.Count * 2 + 2);
			list.Add(item);
			list.AddRange(((CompositeCurve)curve2).CurveList);
			list.Add(item2);
			if (curve is CompositeCurve compositeCurve)
			{
				list.AddRange(compositeCurve.CurveList);
			}
			else
			{
				list.Add(curve);
			}
			return new Region(new CompositeCurve(list, sortAndOrient: false), plane, sortAndOrient: false);
		}
		return null;
	}

	public Point3D[] GetPointsByLength(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		return Curve._0023_003DzDGV7AEB1_5Oo486HnA_003D_003D(this, length);
	}

	public Point3D[] GetPointsByLengthPerSegment(double length)
	{
		if (length < 1E-12)
		{
			return new Point3D[0];
		}
		List<Point3D> list = new List<Point3D>();
		int count = _curveList.Count;
		for (int i = 0; i < count; i++)
		{
			ICurve curve = _curveList[i];
			list.AddRange(curve.GetPointsByLength(length));
			if (i < count - 1)
			{
				list.RemoveAt(list.Count - 1);
			}
		}
		return list.ToArray();
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		List<Point3D> list = new List<Point3D>();
		foreach (ICurve curve in CurveList)
		{
			curve.GetTightBBox(out var boxMin2, out var boxMax2);
			list.Add(boxMin2);
			list.Add(boxMax2);
		}
		Utility.ComputeBoundingBox(list, out boxMin, out boxMax);
	}

	public bool GetParamFromLength(double length, out double t)
	{
		double curveLength = Length();
		return GetParamFromLength(length, curveLength, out t);
	}

	public bool GetParamFromLength(double length, double curveLength, out double t)
	{
		t = 0.0;
		if (Utility.AreEqual(length, 0.0, curveLength))
		{
			t = Domain.Low;
			return true;
		}
		if (Utility.AreEqual(length, curveLength, curveLength))
		{
			t = Domain.High;
			return true;
		}
		if (length < 0.0 || length > curveLength)
		{
			t = Domain.Low;
			return false;
		}
		double num = length;
		double num2 = Domain.Low;
		for (int i = 0; i < CurveList.Count; i++)
		{
			ICurve curve = CurveList[i];
			double num3 = curve.Length();
			if (num <= num3)
			{
				if (curve.GetParamFromLength(num, num3, out t))
				{
					t -= curve.Domain.Low;
					t += num2;
					return true;
				}
				t -= curve.Domain.Low;
				t += num2;
				return false;
			}
			num -= num3;
			num2 += curve.Domain.Length;
		}
		return false;
	}

	public bool GetLengthFromParam(double t, out double length)
	{
		if (Utility.AreEqual(t, Domain.Low, Domain.Length))
		{
			length = 0.0;
			return true;
		}
		if (Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			length = Length();
			return true;
		}
		if (t < Domain.Low || t > Domain.High)
		{
			length = 0.0;
			return false;
		}
		if (SplitAt(t, out var lower, out var _))
		{
			length = lower.Length();
			return true;
		}
		length = 0.0;
		return false;
	}

	public Point3D[] IntersectWith(ICurve C2, double maxGap = 0.0, bool computeParameters = true)
	{
		double _0023_003DzccAR5G0_003D = Utility._0023_003Dz_0024lZxMnYFa_0024OQDkZzoQ_003D_003D(this, C2);
		return _0023_003DzGKZuR_4q838u(C2, _0023_003DzccAR5G0_003D, maxGap, computeParameters);
	}

	internal Point3D[] _0023_003DzGKZuR_4q838u(ICurve _0023_003Dzn8t0_00249E_003D, double _0023_003DzccAR5G0_003D, double _0023_003DzX0qX_IwWxysi, bool _0023_003Dzr9Kx_zv09bH0)
	{
		ICurve[] array = _0023_003DzpoMoKemHyOl4();
		List<ICurve> list = new List<ICurve>();
		if (_0023_003Dzn8t0_00249E_003D is LinearPath)
		{
			list.AddRange(((LinearPath)_0023_003Dzn8t0_00249E_003D).ConvertToLines());
		}
		else if (_0023_003Dzn8t0_00249E_003D is CompositeCurve)
		{
			list.AddRange(((CompositeCurve)_0023_003Dzn8t0_00249E_003D)._0023_003DzpoMoKemHyOl4());
		}
		else
		{
			list.Add(_0023_003Dzn8t0_00249E_003D);
		}
		List<Point3D> list2 = new List<Point3D>();
		double num = 0.0;
		ICurve[] array2 = array;
		foreach (ICurve curve in array2)
		{
			double num2 = 0.0;
			foreach (ICurve item in list)
			{
				Point3D[] array3 = curve.IntersectWith(item, _0023_003DzX0qX_IwWxysi, _0023_003Dzr9Kx_zv09bH0);
				foreach (Point3D point3D in array3)
				{
					if (_0023_003Dzr9Kx_zv09bH0)
					{
						((InterPoint)point3D).u += num - curve.Domain.Low;
						((InterPoint)point3D).s += num2 - item.Domain.Low;
					}
					Utility._0023_003DzbIDY9BOTPqfc(point3D, list2, _0023_003DzccAR5G0_003D);
				}
				num2 += item.Domain.Length;
			}
			num += curve.Domain.Length;
		}
		return list2.ToArray();
	}

	public bool SubCurve(double startParam, double endParam, out ICurve sub)
	{
		sub = null;
		if (!Circle._0023_003DzJUU5L0s5zlzq(IsClosed, Domain.Low, Domain.High, Domain.Length, ref startParam, ref endParam))
		{
			return false;
		}
		List<ICurve> list = new List<ICurve>();
		double num = Domain.Low;
		bool flag = false;
		foreach (ICurve curve in CurveList)
		{
			double length = curve.Domain.Length;
			bool flag2 = startParam < num + length;
			bool flag3 = endParam <= num + length;
			if (!flag && flag2 && flag3)
			{
				if (curve.SubCurve(curve.Domain.Low + startParam - num, curve.Domain.Low + endParam - num, out sub))
				{
					return true;
				}
				return false;
			}
			if (!flag && flag2)
			{
				if (Utility._0023_003DzuW42NHK3HaLL(curve.Domain.High, curve.Domain.Low + startParam - num, length))
				{
					flag = true;
				}
				else
				{
					if (!curve.SubCurve(curve.Domain.Low + startParam - num, curve.Domain.High, out var sub2))
					{
						return false;
					}
					list.Add(sub2);
					flag = true;
				}
			}
			else
			{
				if (flag3)
				{
					if (Utility._0023_003DzuW42NHK3HaLL(curve.Domain.Low, curve.Domain.Low + endParam - num, length))
					{
						sub = new CompositeCurve(list, sortAndOrient: false);
						((Entity)sub).CopyAttributes(this);
						return true;
					}
					if (curve.SubCurve(curve.Domain.Low, curve.Domain.Low + endParam - num, out var sub3))
					{
						list.Add(sub3);
						sub = new CompositeCurve(list, sortAndOrient: false);
						((Entity)sub).CopyAttributes(this);
						return true;
					}
					return false;
				}
				if (flag)
				{
					list.Add((ICurve)curve.Clone());
				}
			}
			num += curve.Domain.Length;
		}
		return false;
	}

	public bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		sub = null;
		ClosestPointTo(startPt, out var t);
		ClosestPointTo(endPt, out var t2);
		if (SubCurve(t, t2, out var sub2))
		{
			sub = sub2;
			return true;
		}
		return false;
	}

	internal bool _0023_003DzWSYOty9Seo2Q(double _0023_003Dzm0CYiiE_003D)
	{
		for (int i = 0; i < _curveList.Count; i++)
		{
			Point3D endPoint = _curveList[i].EndPoint;
			Point3D startPoint = _curveList[(i + 1) % _curveList.Count].StartPoint;
			if (Point3D.Distance(endPoint, startPoint) > _0023_003Dzm0CYiiE_003D)
			{
				return true;
			}
		}
		return false;
	}

	public double Length()
	{
		double num = 0.0;
		foreach (ICurve curve in _curveList)
		{
			num += curve.Length();
		}
		return num;
	}

	public void Reverse()
	{
		_curveList.Reverse();
		foreach (ICurve curve in _curveList)
		{
			curve.Reverse();
		}
		RegenMode = regenType.RegenAndCompile;
	}

	public ICurve[] SplitAtDiscontinuities(bool speedChange)
	{
		List<ICurve> list = new List<ICurve>();
		foreach (ICurve curve5 in _curveList)
		{
			if (curve5 is LinearPath)
			{
				ICurve[] collection = ((LinearPath)curve5).SplitAtDiscontinuities();
				list.AddRange(collection);
			}
			else if (curve5 is Curve)
			{
				ICurve[] array = ((Curve)curve5).SplitAtDiscontinuities(speedChange);
				ICurve[] collection2 = array;
				list.AddRange(collection2);
			}
			else
			{
				list.Add((ICurve)curve5.Clone());
			}
		}
		List<ICurve> list2 = new List<ICurve>();
		List<ICurve> list3 = new List<ICurve>();
		list3.Add(list[0]);
		if (speedChange)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				ICurve curve = list[i];
				ICurve curve2 = list[i + 1];
				Curve nurbsForm = curve.GetNurbsForm();
				Curve nurbsForm2 = curve2.GetNurbsForm();
				double length = nurbsForm.Evaluate(nurbsForm.Domain.High, 1)[1].Length;
				double length2 = nurbsForm2.Evaluate(nurbsForm2.Domain.Low, 1)[1].Length;
				if (Vector3D.AreCoincident(curve.EndTangent, curve2.StartTangent, 1E-06) && Math.Max(length, length2) / Math.Min(length, length2) < 1.1)
				{
					list3.Add(curve2);
					continue;
				}
				list2.Add(_0023_003DzykJZ2c8_003D(list3));
				list3.Clear();
				list3.Add(curve2);
			}
		}
		else
		{
			for (int j = 0; j < list.Count - 1; j++)
			{
				ICurve curve3 = list[j];
				ICurve curve4 = list[j + 1];
				if (Vector3D.AreCoincident(curve3.EndTangent, curve4.StartTangent, 1E-06))
				{
					list3.Add(curve4);
					continue;
				}
				list2.Add(_0023_003DzykJZ2c8_003D(list3));
				list3.Clear();
				list3.Add(curve4);
			}
		}
		if (list3.Count > 0)
		{
			list2.Add(_0023_003DzykJZ2c8_003D(list3));
		}
		foreach (Entity item in list2)
		{
			item.CopyAttributes(this);
		}
		return list2.ToArray();
	}

	private static ICurve _0023_003DzykJZ2c8_003D(IList<ICurve> _0023_003Dz4HmPMoha6dew)
	{
		if (_0023_003Dz4HmPMoha6dew.Count > 1)
		{
			CompositeCurve compositeCurve = new CompositeCurve();
			compositeCurve.CurveList.AddRange(_0023_003Dz4HmPMoha6dew);
			return compositeCurve;
		}
		return _0023_003Dz4HmPMoha6dew[0];
	}

	public bool IsPlanar(double tol, out Plane plane)
	{
		return _0023_003Dz2rx0bYXAv_0024aP(tol, _curveList.ToArray(), out plane);
	}

	private bool _0023_003Dz2rx0bYXAv_0024aP(double _0023_003Dzm0CYiiE_003D, ICurve[] _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D, out Plane _0023_003Dzrgqz890sj_0024X9)
	{
		_0023_003Dzrgqz890sj_0024X9 = null;
		if (_0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D.Length == 1)
		{
			return _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D[0].IsPlanar(_0023_003Dzm0CYiiE_003D, out _0023_003Dzrgqz890sj_0024X9);
		}
		ICurve[] array = _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D;
		for (int i = 0; i < array.Length; i++)
		{
			Entity entity = (Entity)array[i];
			if (entity is PlanarEntity)
			{
				PlanarEntity planarEntity = (PlanarEntity)entity;
				_0023_003Dzrgqz890sj_0024X9 = (Plane)planarEntity.Plane.Clone();
				break;
			}
			if (entity is Curve)
			{
				Curve curve = (Curve)entity;
				if (!curve.IsLine && !curve.IsLinear(_0023_003Dzm0CYiiE_003D, out var _))
				{
					curve.IsPlanar(_0023_003Dzm0CYiiE_003D, out _0023_003Dzrgqz890sj_0024X9);
					break;
				}
			}
		}
		if (_0023_003Dzrgqz890sj_0024X9 != null)
		{
			array = _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsInPlane(_0023_003Dzrgqz890sj_0024X9, _0023_003Dzm0CYiiE_003D))
				{
					_0023_003Dzrgqz890sj_0024X9 = null;
					return false;
				}
			}
			if (IsClosed && Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(this, _0023_003Dzrgqz890sj_0024X9))
			{
				_0023_003Dzrgqz890sj_0024X9.Flip();
			}
			return true;
		}
		_0023_003Dzrgqz890sj_0024X9 = Utility.FitPlane(Utility._0023_003Dzm2WwrkTQN7Q4HSrEZQ_003D_003D(_0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D));
		array = _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].IsInPlane(_0023_003Dzrgqz890sj_0024X9, _0023_003Dzm0CYiiE_003D))
			{
				_0023_003Dzrgqz890sj_0024X9 = null;
				return false;
			}
		}
		if (IsClosed && Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(this, _0023_003Dzrgqz890sj_0024X9))
		{
			_0023_003Dzrgqz890sj_0024X9.Flip();
		}
		return true;
	}

	public bool IsInPlane(Plane plane, double tol)
	{
		if (!IsValid())
		{
			return false;
		}
		foreach (ICurve curve in _curveList)
		{
			if (!curve.IsInPlane(plane, tol))
			{
				return false;
			}
		}
		return true;
	}

	public Point3D PointAt(double t)
	{
		double _0023_003DzvGprkFLYK8ip;
		int index = _0023_003DzwTrzxq4lzEFtf_0zYg_003D_003D(t, out _0023_003DzvGprkFLYK8ip);
		return CurveList[index].PointAt(_0023_003DzvGprkFLYK8ip);
	}

	internal int _0023_003DzwTrzxq4lzEFtf_0zYg_003D_003D(double _0023_003DzNDQ_E88_003D, out double _0023_003DzvGprkFLYK8ip)
	{
		double num = 0.0;
		foreach (ICurve curve2 in CurveList)
		{
			num += curve2.Domain.Length;
		}
		double num2 = 1.0;
		if (!Utility.AreEqual(num, Domain.Length, Domain.Length))
		{
			num2 = Domain.Length / num;
		}
		num = 0.0;
		ICurve curve;
		for (int i = 0; i < CurveList.Count - 1; i++)
		{
			curve = _curveList[i];
			double length = curve.Domain.Length;
			if ((num + length) * num2 >= _0023_003DzNDQ_E88_003D)
			{
				if (i == 0 && _0023_003DzNDQ_E88_003D < Domain.t0)
				{
					_0023_003DzvGprkFLYK8ip = (curve.Domain.t0 - Math.Abs(_0023_003DzNDQ_E88_003D)) / num2;
					return i;
				}
				_0023_003DzvGprkFLYK8ip = (_0023_003DzNDQ_E88_003D - num + curve.Domain.t0) / num2;
				return i;
			}
			num += length;
		}
		curve = _curveList[CurveList.Count - 1];
		_0023_003DzvGprkFLYK8ip = (_0023_003DzNDQ_E88_003D - num + curve.Domain.t0) / num2;
		return CurveList.Count - 1;
	}

	public bool TrimAt(double t, bool flipSide)
	{
		if (SplitAt(t, out var lower, out var upper))
		{
			if (flipSide)
			{
				CurveList = ((CompositeCurve)upper).CurveList;
				RegenMode = regenType.RegenAndCompile;
				return true;
			}
			CurveList = ((CompositeCurve)lower).CurveList;
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool TrimBy(Point3D pt, bool flipSide)
	{
		if (SplitBy(pt, out var lower, out var upper))
		{
			if (flipSide)
			{
				CurveList = ((CompositeCurve)upper).CurveList;
				return true;
			}
			CurveList = ((CompositeCurve)lower).CurveList;
			return true;
		}
		return false;
	}

	public bool ExtendAt(double t)
	{
		if (IsClosed && Vector3D.AreCoincident(StartTangent, EndTangent))
		{
			return false;
		}
		if (t > Domain.High && !Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			ICurve curve = CurveList[CurveList.Count - 1];
			double t2 = t - Domain.High + curve.Domain.High;
			RegenMode = regenType.RegenAndCompile;
			return curve.ExtendAt(t2);
		}
		if (t < Domain.Low && !Utility.AreEqual(t, Domain.Low, Domain.Length))
		{
			RegenMode = regenType.RegenAndCompile;
			return CurveList[0].ExtendAt(t);
		}
		return false;
	}

	public bool ExtendBy(Point3D pt, bool curveEnd = true)
	{
		if (IsClosed && Vector3D.AreCoincident(StartTangent, EndTangent))
		{
			return false;
		}
		RegenMode = regenType.RegenAndCompile;
		if (curveEnd)
		{
			return CurveList[CurveList.Count - 1].ExtendBy(pt, curveEnd);
		}
		return CurveList[0].ExtendBy(pt, curveEnd);
	}

	public double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond)
	{
		double num = double.MaxValue;
		closestPointOnFirst = null;
		closestPointOnSecond = null;
		ICurve[] individualCurves = GetIndividualCurves();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			Curve[] array = individualCurves[i].GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
			for (int j = 0; j < array.Length; j++)
			{
				Curve a = array[j];
				if (curve is CompositeCurve)
				{
					ICurve[] individualCurves2 = curve.GetIndividualCurves();
					for (int k = 0; k < individualCurves2.Length; k++)
					{
						Curve[] array2 = individualCurves2[k].GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
						for (int l = 0; l < array.Length; l++)
						{
							Curve b = array2[j];
							MinimumDistance minimumDistance = new MinimumDistance(a, b);
							minimumDistance.DoWork();
							if (minimumDistance.Result.Length < num)
							{
								num = minimumDistance.Result.Length;
								closestPointOnFirst = new Point3D[1] { minimumDistance.Result.P0 };
								closestPointOnSecond = new Point3D[1] { minimumDistance.Result.P1 };
							}
						}
					}
					continue;
				}
				Curve[] array3 = curve.GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
				foreach (Curve b2 in array3)
				{
					MinimumDistance minimumDistance2 = new MinimumDistance(a, b2);
					minimumDistance2.DoWork();
					if (minimumDistance2.Result.Length < num)
					{
						num = minimumDistance2.Result.Length;
						closestPointOnFirst = new Point3D[1] { minimumDistance2.Result.P0 };
						closestPointOnSecond = new Point3D[1] { minimumDistance2.Result.P1 };
					}
				}
			}
		}
		return num;
	}

	public bool Project(Point3D point, out double t)
	{
		double _0023_003DzIPFgWVnZ6O9r;
		int num = _0023_003DzMFcb8juiYhuQ(point, _0023_003Dz3P41GFRPL8iZ: false, out _0023_003DzIPFgWVnZ6O9r);
		if (num == -1)
		{
			ICurve curve = _curveList[0];
			curve.Project(point, out var t2);
			bool flag = t2 < curve.Domain.t0 || curve is Circle || curve is Ellipse;
			if (flag && t2 > curve.Domain.t0)
			{
				while (t2 > curve.Domain.t0)
				{
					t2 -= Math.PI * 2.0;
				}
			}
			ICurve curve2 = CurveList[CurveList.Count - 1];
			curve2.Project(point, out var t3);
			bool flag2 = t3 > curve2.Domain.t1 || curve2 is Circle || curve2 is Ellipse;
			if (flag2 && t3 < curve2.Domain.t1)
			{
				for (; t3 < curve2.Domain.t1; t3 += Math.PI * 2.0)
				{
				}
			}
			if (flag && flag2)
			{
				if (Point3D.DistanceSquared(point, curve.PointAt(t2)) <= Point3D.DistanceSquared(point, curve2.PointAt(t3)))
				{
					t = Domain.t0 + t2 - curve.Domain.t0;
					return true;
				}
				t = Domain.t0 + Domain.Length + t3 - curve2.Domain.t0 - curve2.Domain.Length;
				return true;
			}
			if (flag)
			{
				t = Domain.t0 + t2 - curve.Domain.t0;
				return true;
			}
			if (flag2)
			{
				t = Domain.t0 + Domain.Length + t3 - curve2.Domain.t0 - curve2.Domain.Length;
				return true;
			}
			t = Domain.Low;
			return false;
		}
		double num2 = 0.0;
		for (int i = 0; i < num; i++)
		{
			num2 += CurveList[i].Domain.Length;
		}
		num2 += _0023_003DzIPFgWVnZ6O9r;
		t = num2;
		return true;
	}

	public void ClosestPointTo(Point3D point, out double t)
	{
		double _0023_003DzIPFgWVnZ6O9r;
		int num = _0023_003DzMFcb8juiYhuQ(point, _0023_003Dz3P41GFRPL8iZ: true, out _0023_003DzIPFgWVnZ6O9r);
		t = 0.0;
		if (num != -1)
		{
			double num2 = 0.0;
			for (int i = 0; i < num; i++)
			{
				num2 += CurveList[i].Domain.Length;
			}
			num2 += _0023_003DzIPFgWVnZ6O9r;
			t = num2;
		}
	}

	private int _0023_003DzMFcb8juiYhuQ(Point3D _0023_003DzlY77YgY_003D, bool _0023_003Dz3P41GFRPL8iZ, out double _0023_003DzIPFgWVnZ6O9r)
	{
		int result = -1;
		_0023_003DzIPFgWVnZ6O9r = 0.0;
		double num = double.MaxValue;
		for (int i = 0; i < CurveList.Count; i++)
		{
			ICurve curve = CurveList[i];
			bool flag = false;
			double t;
			if (_0023_003Dz3P41GFRPL8iZ)
			{
				curve.ClosestPointTo(_0023_003DzlY77YgY_003D, out t);
			}
			else
			{
				flag = curve.Project(_0023_003DzlY77YgY_003D, out t);
			}
			if (!(_0023_003Dz3P41GFRPL8iZ || flag))
			{
				continue;
			}
			if (curve is Line)
			{
				if ((t > curve.Domain.Low || Utility.AreEqual(t, curve.Domain.Low, curve.Domain.Length)) && (t < curve.Domain.High || Utility.AreEqual(t, curve.Domain.High, curve.Domain.Length)))
				{
					double num2 = Point3D.DistanceSquared(curve.PointAt(t), _0023_003DzlY77YgY_003D);
					if (num2 < num)
					{
						num = num2;
						result = i;
						_0023_003DzIPFgWVnZ6O9r = t;
					}
				}
			}
			else if (curve is Arc)
			{
				Arc arc = (Arc)curve;
				if (Utility.AreEqual(t, arc.angle.t0, arc.angle.Length))
				{
					double num3 = Point3D.DistanceSquared(arc.StartPoint, _0023_003DzlY77YgY_003D);
					if (num3 < num)
					{
						num = num3;
						result = i;
						_0023_003DzIPFgWVnZ6O9r = 0.0;
					}
				}
				else if (t > arc.angle.t0 && (t < arc.angle.t1 || Utility.AreEqual(t, arc.angle.t1, arc.angle.Length)))
				{
					double num4 = Point3D.DistanceSquared(curve.PointAt(t), _0023_003DzlY77YgY_003D);
					if (num4 < num)
					{
						num = num4;
						result = i;
						_0023_003DzIPFgWVnZ6O9r = t - arc.angle.t0;
					}
				}
			}
			else if (curve is Circle)
			{
				double num5 = Point3D.DistanceSquared(curve.PointAt(t), _0023_003DzlY77YgY_003D);
				if (num5 < num)
				{
					num = num5;
					result = i;
					_0023_003DzIPFgWVnZ6O9r = t;
				}
			}
			else if (curve is EllipticalArc)
			{
				EllipticalArc ellipticalArc = (EllipticalArc)curve;
				if (Utility.AreEqual(t, ellipticalArc.angle.t0, ellipticalArc.angle.Length))
				{
					double num6 = Point3D.DistanceSquared(ellipticalArc.StartPoint, _0023_003DzlY77YgY_003D);
					if (num6 < num)
					{
						num = num6;
						result = i;
						_0023_003DzIPFgWVnZ6O9r = 0.0;
					}
				}
				else if (t > ellipticalArc.angle.t0 && (t < ellipticalArc.angle.t1 || Utility.AreEqual(t, ellipticalArc.angle.t1, ellipticalArc.angle.Length)))
				{
					double num7 = Point3D.DistanceSquared(curve.PointAt(t), _0023_003DzlY77YgY_003D);
					if (num7 < num)
					{
						num = num7;
						result = i;
						_0023_003DzIPFgWVnZ6O9r = t - ellipticalArc.angle.t0;
					}
				}
			}
			else if (curve is Ellipse)
			{
				Ellipse ellipse = (Ellipse)curve;
				if (Utility.AreEqual(t, 0.0, Math.PI * 2.0))
				{
					double num8 = Point3D.DistanceSquared(ellipse.StartPoint, _0023_003DzlY77YgY_003D);
					if (num8 < num)
					{
						num = num8;
						result = i;
						_0023_003DzIPFgWVnZ6O9r = 0.0;
					}
				}
				else
				{
					double num9 = Point3D.DistanceSquared(curve.PointAt(t), _0023_003DzlY77YgY_003D);
					if (num9 < num)
					{
						num = num9;
						result = i;
						_0023_003DzIPFgWVnZ6O9r = t;
					}
				}
			}
			else if ((t > curve.Domain.t0 || Utility.AreEqual(t, curve.Domain.t0, curve.Domain.Length)) && (t < curve.Domain.t1 || Utility.AreEqual(t, curve.Domain.t1, curve.Domain.Length)))
			{
				double num10 = Point3D.DistanceSquared(curve.PointAt(t), _0023_003DzlY77YgY_003D);
				if (num10 < num)
				{
					num = num10;
					result = i;
					_0023_003DzIPFgWVnZ6O9r = t - curve.Domain.Low;
				}
			}
		}
		return result;
	}

	public Vector3D TangentAt(double t)
	{
		double _0023_003DzvGprkFLYK8ip;
		int index = _0023_003DzwTrzxq4lzEFtf_0zYg_003D_003D(t, out _0023_003DzvGprkFLYK8ip);
		return CurveList[index].TangentAt(_0023_003DzvGprkFLYK8ip);
	}

	public Vector3D NormalAt(double t)
	{
		double _0023_003DzvGprkFLYK8ip;
		int index = _0023_003DzwTrzxq4lzEFtf_0zYg_003D_003D(t, out _0023_003DzvGprkFLYK8ip);
		return CurveList[index].NormalAt(_0023_003DzvGprkFLYK8ip);
	}

	public ICurve[] Offset(double amount, bool sharp)
	{
		return Offset(amount, null, sharp);
	}

	public ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp)
	{
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		Curve nurbsForm;
		try
		{
			nurbsForm = GetNurbsForm();
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
		Plane plane2;
		Segment3D line;
		Curve _0023_003Dz6nnnQo75Qjsf;
		if (planeNormal == null)
		{
			if (!IsPlanar(Utility._0023_003DzxhnLabVjXjPg, out var plane))
			{
				return Array.Empty<ICurve>();
			}
			planeNormal = plane.AxisZ;
		}
		else if ((!IsPlanar(Utility._0023_003DzxhnLabVjXjPg, out plane2) || !Vector3D.AreParallel(plane2.AxisZ, planeNormal / planeNormal.Length)) && !IsLinear(Utility._0023_003DzxhnLabVjXjPg, out line))
		{
			return new ICurve[1] { nurbsForm._0023_003Dz3JJdLbUPbfbS(amount, planeNormal, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: false, out _0023_003Dz6nnnQo75Qjsf) };
		}
		List<List<ICurve>> list = new List<List<ICurve>>();
		GetApproximatedBoundingBox(out var boxMin, out var boxMax);
		double num = new Size3D(boxMin, boxMax).Diagonal * 1E-05;
		if (num < 1E-12)
		{
			num = 1E-12;
		}
		List<List<ICurve>> list2 = new List<List<ICurve>>();
		ICurve[] individualCurves = GetIndividualCurves();
		foreach (ICurve curve in individualCurves)
		{
			if (curve is Arc || curve is Line)
			{
				list2.Add(new List<ICurve>(1) { curve });
			}
			else if (curve is LinearPath linearPath)
			{
				list2.Add(linearPath.GetIndividualCurves().ToList());
			}
			else
			{
				Curve nurbsForm2 = curve.GetNurbsForm();
				list2.Add(nurbsForm2.SplitAtDiscontinuities().Cast<ICurve>().ToList());
			}
		}
		List<List<ICurve>> list3 = new List<List<ICurve>>();
		double num2 = 0.0;
		for (int j = 0; j < list2.Count; j++)
		{
			List<ICurve> list4 = new List<ICurve>();
			for (int k = 0; k < list2[j].Count; k++)
			{
				ICurve curve2 = list2[j][k];
				if (curve2 is Arc arc)
				{
					Arc arc2 = null;
					if (Vector3D.AreOpposite(arc.Plane.AxisZ, planeNormal / planeNormal.Length))
					{
						if (arc.Radius - amount > 0.0)
						{
							arc2 = new Arc(arc.Plane, arc.Center, arc.Radius - amount, arc.Angle.Low, arc.Angle.High);
						}
					}
					else if (arc.Radius + amount > 0.0)
					{
						arc2 = new Arc(arc.Plane, arc.Center, arc.Radius + amount, arc.Angle.Low, arc.Angle.High);
					}
					if (arc2 != null)
					{
						list4.Add(arc2);
					}
					else
					{
						Vector3D vector3D = Vector3D.Cross(arc.StartTangent, planeNormal / planeNormal.Length);
						Vector3D vector3D2 = Vector3D.Cross(arc.EndTangent, planeNormal / planeNormal.Length);
						if (Point3D.Distance(arc.Center, arc.StartPoint + amount * vector3D) > 1E-12 && Point3D.Distance(arc.Center, arc.StartPoint + amount * vector3D2) > 1E-12)
						{
							arc2 = new Arc(arc.Plane, arc.Plane.Project(arc.Center), arc.Plane.Project(arc.StartPoint + amount * vector3D), arc.Plane.Project(arc.EndPoint + amount * vector3D2));
						}
						if (arc2 != null)
						{
							list4.Add(arc2);
						}
					}
				}
				else if (curve2 is Line line2)
				{
					Point3D start = line2.StartPoint + amount * Vector3D.Cross(line2.StartTangent, planeNormal / planeNormal.Length);
					Point3D end = line2.EndPoint + amount * Vector3D.Cross(line2.EndTangent, planeNormal / planeNormal.Length);
					Line item = new Line(start, end);
					list4.Add(item);
				}
				else
				{
					double low = ((Curve)curve2).Domain.Low;
					for (int l = 0; l < ((Curve)curve2).KnotVector.Length; l++)
					{
						((Curve)curve2).KnotVector[l] += num2 - low;
					}
					list4.Add(((Curve)curve2)._0023_003Dz3JJdLbUPbfbS(amount, planeNormal, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: false, out _0023_003Dz6nnnQo75Qjsf));
				}
				num2 += curve2.Domain.Length;
			}
			if (list4.Count > 0)
			{
				list3.Add(list4);
			}
		}
		List<List<ICurve>> list5 = new List<List<ICurve>>();
		List<Region> list6 = new List<Region>();
		for (int m = 0; m < list3.Count; m++)
		{
			List<ICurve> list7 = new List<ICurve>();
			if (m == 0)
			{
				if (IsClosed)
				{
					list7.AddRange(nurbsForm._0023_003DzAQ_0024W3wX7BPlkX4gX2g_003D_003D(list3.Last().Last(), list3[0][0], list2[0][0].StartPoint, amount, planeNormal, sharp, num, list6));
				}
			}
			else
			{
				list7.AddRange(nurbsForm._0023_003DzAQ_0024W3wX7BPlkX4gX2g_003D_003D(list3[m - 1].Last(), list3[m][0], list2[m][0].StartPoint, amount, planeNormal, sharp, num, list6));
			}
			foreach (ICurve item3 in list7)
			{
				list5.Add(new List<ICurve>(1) { item3 });
			}
			List<ICurve> list8 = new List<ICurve>();
			for (int n = 0; n < list3[m].Count; n++)
			{
				if (n != 0)
				{
					list8.AddRange(nurbsForm._0023_003DzAQ_0024W3wX7BPlkX4gX2g_003D_003D(list3[m][n - 1], list3[m][n], list2[m][n].StartPoint, amount, planeNormal, sharp, num, list6));
				}
				if (list3[m][n] is Line || list3[m][n] is Arc)
				{
					list8.Add(list3[m][n]);
					continue;
				}
				Point3D[] source = _0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX._0023_003DzvKjleDzBEPeHTOWneerYzYE_003D(list3[m][n].GetNurbsForm(), 0.0, Math.PI / 2.0);
				nurbsForm._0023_003DzpMCmhFs8nshmeFe5OQ_003D_003D(amount, num, source.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzFF69AYUnqoYvyVMhMQ_003D_003D).ToArray(), list3[m][n], list8, planeNormal, Array.Empty<Region>(), nurbsForm._0023_003DzQhzLqGmR4kjmOmQDvoMDSKg_003D);
			}
			if (list8.Count > 0)
			{
				list5.Add(list8);
			}
		}
		if (list5.Count > 0 && ((Entity)list5[0][0]).EntityData != null && (int)((Entity)list5[0][0]).EntityData == 0)
		{
			ICurve item2 = list5[0][0];
			list5.Add(new List<ICurve>(1) { item2 });
			list5.RemoveAt(0);
		}
		List<double>[][] array = new List<double>[list5.Count][];
		for (int num3 = 0; num3 < list5.Count; num3++)
		{
			array[num3] = new List<double>[list5[num3].Count];
			for (int num4 = 0; num4 < list5[num3].Count; num4++)
			{
				array[num3][num4] = new List<double>();
			}
		}
		for (int num5 = 0; num5 < list5.Count; num5++)
		{
			for (int num6 = 0; num6 < list5[num5].Count; num6++)
			{
				ICurve curve3 = list5[num5][num6];
				for (int num7 = num5; num7 < list5.Count; num7++)
				{
					for (int num8 = 0; num8 < list5[num7].Count; num8++)
					{
						if (num7 == num5 && num8 <= num6)
						{
							continue;
						}
						ICurve curve4 = list5[num7][num8];
						foreach (InterPoint item4 in curve3.IntersectWith(curve4).Cast<InterPoint>().ToList())
						{
							if (item4.u > curve3.Domain.Left && item4.u < curve3.Domain.Right)
							{
								array[num5][num6].Add(item4.u);
							}
							if (item4.s > curve4.Domain.Left && item4.s < curve4.Domain.Right)
							{
								array[num7][num8].Add(item4.s);
							}
						}
					}
				}
			}
		}
		if (!IsClosed)
		{
			Circle circle = new Circle(new Plane(planeNormal), StartPoint, Math.Abs(amount));
			Circle circle2 = new Circle(new Plane(planeNormal), EndPoint, Math.Abs(amount));
			Curve curve5 = nurbsForm._0023_003Dz3JJdLbUPbfbS(0.0 - amount, planeNormal, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: false, out _0023_003Dz6nnnQo75Qjsf);
			for (int num9 = 0; num9 < list5.Count; num9++)
			{
				for (int num10 = 0; num10 < list5[num9].Count; num10++)
				{
					ICurve curve6 = list5[num9][num10];
					foreach (InterPoint item5 in circle.IntersectWith(curve6).Cast<InterPoint>().ToList())
					{
						if (item5.s > curve6.Domain.Left && item5.s < curve6.Domain.Right)
						{
							array[num9][num10].Add(item5.s);
						}
					}
					foreach (InterPoint item6 in circle2.IntersectWith(curve6).Cast<InterPoint>().ToList())
					{
						if (item6.s > curve6.Domain.Left && item6.s < curve6.Domain.Right)
						{
							array[num9][num10].Add(item6.s);
						}
					}
					foreach (InterPoint item7 in curve5.IntersectWith(curve6).Cast<InterPoint>().ToList())
					{
						if (item7.s > curve6.Domain.Left && item7.s < curve6.Domain.Right)
						{
							array[num9][num10].Add(item7.s);
						}
					}
				}
			}
		}
		using (new _0023_003DzspExml1j72mr_FI04NKW780_003D())
		{
			for (int num11 = 0; num11 < array.Length; num11++)
			{
				List<ICurve> list9 = new List<ICurve>();
				for (int num12 = 0; num12 < array[num11].Length; num12++)
				{
					ICurve _0023_003DzVZvuR8GIx2bc = list5[num11][num12];
					array[num11][num12].Sort();
					nurbsForm._0023_003DzpMCmhFs8nshmeFe5OQ_003D_003D(amount, num, array[num11][num12].ToArray(), _0023_003DzVZvuR8GIx2bc, list9, planeNormal, list6.ToArray(), nurbsForm._0023_003DzNWrznGBi9wJN);
				}
				if (list9.Count > 0)
				{
					list.Add(list9);
				}
			}
		}
		if (list.Count > 0)
		{
			List<ICurve> list10 = new List<ICurve>();
			foreach (List<ICurve> item8 in list)
			{
				for (int num13 = 0; num13 < item8.Count; num13++)
				{
					ICurve curve7 = item8[num13];
					if (((Entity)curve7).EntityData != null)
					{
						((Entity)curve7).EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743);
					}
					if (num13 == 0)
					{
						list10.Add(curve7);
					}
					else if (list10.Count > 0 && Point3D.DistanceSquared(list10.Last().EndPoint, curve7.StartPoint) < num * num)
					{
						if (curve7 is Curve && list10.Last() is Curve)
						{
							list10[list10.Count - 1] = Curve.Merge(new List<ICurve>
							{
								list10.Last(),
								curve7
							}, clean: true, resetDomain: false);
						}
						else if (sharp && curve7 is Line && list10.Last() is Line && ((Entity)curve7).EntityData == null && ((Entity)list10.Last()).EntityData == null && Vector3D.AreCoincident(list10.Last().EndTangent, curve7.StartTangent))
						{
							list10[list10.Count - 1] = new Line(list10.Last().StartPoint, curve7.EndPoint);
						}
						else
						{
							list10.Add(curve7);
						}
					}
					else
					{
						list10.Add(curve7);
					}
				}
			}
			list10 = Utility.CleanDuplicates(list10).ToList();
			List<List<ICurve>> list11 = new List<List<ICurve>>();
			while (list10.Count > 0)
			{
				int num14 = -1;
				foreach (List<ICurve> item9 in list11)
				{
					for (int num15 = 0; num15 < list10.Count; num15++)
					{
						if (Point3D.DistanceSquared(item9.Last().EndPoint, list10[num15].StartPoint) < num * num)
						{
							if (sharp && list10[num15] is Line && item9.Last() is Line && (((Entity)list10[num15]).EntityData != null || ((Entity)item9.Last()).EntityData != null) && Vector3D.AreCoincident(list10[num15].EndTangent, item9.Last().StartTangent))
							{
								item9[item9.Count - 1] = new Line(item9.Last().StartPoint, list10[num15].EndPoint);
							}
							else
							{
								item9.Add(list10[num15]);
							}
							num14 = num15;
							break;
						}
					}
					if (num14 != -1)
					{
						list10.RemoveAt(num14);
						break;
					}
				}
				if (num14 == -1)
				{
					list11.Add(new List<ICurve> { list10[0] });
					list10.RemoveAt(0);
				}
			}
			ICurve[] array2 = new ICurve[list11.Count];
			for (int num16 = 0; num16 < array2.Length; num16++)
			{
				array2[num16] = Utility.SmartAdd(list11[num16]);
			}
			return array2.ToArray();
		}
		return Array.Empty<ICurve>();
	}

	private double _0023_003DzFFV6rq25mYEi(out double _0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D)
	{
		if (localMin == null)
		{
			Utility.ComputeBoundingBox(EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
			_0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D = new Size3D(boxMin, boxMax).Diagonal;
		}
		else
		{
			_0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D = base.BoxSize.Diagonal;
		}
		return _0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D * 0.0001;
	}

	public bool IsLinear(double tolerance, out Segment3D line)
	{
		int count = _curveList.Count;
		line = null;
		if (IsClosed || _curveList.Count < 1)
		{
			return false;
		}
		if (tolerance <= 0.0)
		{
			tolerance = 1E-12;
		}
		double num = double.MinValue;
		Segment3D segment3D = null;
		for (int i = 0; i < count; i++)
		{
			ICurve curve = _curveList[i];
			Segment3D line2;
			if (curve is Line)
			{
				((Line)curve).IsLinear(tolerance, out line2);
			}
			else if (curve is Curve)
			{
				((Curve)curve).IsLinear(tolerance, out line2);
			}
			else
			{
				if (!(curve is LinearPath))
				{
					return false;
				}
				((LinearPath)curve).IsLinear(tolerance, out line2);
			}
			if (line2 == null)
			{
				return false;
			}
			Segment3D segment3D2 = new Segment3D(line2.P0, line2.P1);
			double lengthSquared = segment3D2.LengthSquared;
			if (lengthSquared > num)
			{
				segment3D = segment3D2;
				num = lengthSquared;
			}
		}
		bool flag = false;
		if (segment3D != null)
		{
			flag = true;
			for (int j = 0; j < CurveList.Count; j++)
			{
				ICurve curve2 = CurveList[j];
				if (curve2.IsLinear(tolerance, out var _))
				{
					Point3D endPoint = curve2.EndPoint;
					double t = segment3D.Project(endPoint);
					if (endPoint.DistanceTo(segment3D.PointAt(t)) > tolerance)
					{
						flag = false;
						break;
					}
					continue;
				}
				flag = false;
				break;
			}
		}
		if (flag)
		{
			line = segment3D;
		}
		return flag;
	}

	private void _0023_003Dz8Yo227Ly3Bza(ref int _0023_003DzyzK8swU_003D, double _0023_003DzYNjcavt9guh2, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzalFofRO0Igsv, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dzfq1D_iZsyyNd)
	{
		ICurve curve = _curveList[_0023_003DzyzK8swU_003D];
		ICurve curve2 = ((_0023_003DzyzK8swU_003D != _curveList.Count - 1) ? _curveList[_0023_003DzyzK8swU_003D + 1] : _curveList[0]);
		if (curve is Line && curve2 is Line)
		{
			_0023_003DzL7GAL8HKn0l4(ref _0023_003DzyzK8swU_003D, curve, curve2, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv);
		}
		else if (curve is Line && curve2 is Circle)
		{
			_0023_003DzuuI025m0e2psLwR01w_003D_003D(ref _0023_003DzyzK8swU_003D, curve, curve2, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
		}
		else if (curve is Circle && curve2 is Line)
		{
			_0023_003DzPTUWXguXUfE53_0024VHbQ_003D_003D(ref _0023_003DzyzK8swU_003D, curve, curve2, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
		}
		else if (curve is Circle && curve2 is Circle)
		{
			_0023_003DzNY6_6G0Lnzi51RMwTqgk880_003D(ref _0023_003DzyzK8swU_003D, curve, curve2, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
		}
		else
		{
			_0023_003Dz_luP1aIc6rvSUGDdiK7Zm_0024o_003D(ref _0023_003DzyzK8swU_003D, curve, curve2, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dzfq1D_iZsyyNd);
		}
	}

	private void _0023_003Dz_luP1aIc6rvSUGDdiK7Zm_0024o_003D(ref int _0023_003DzyzK8swU_003D, ICurve _0023_003Dz1BPEjBg_003D, ICurve _0023_003Dziidc4_0024c_003D, double _0023_003DzYNjcavt9guh2, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzalFofRO0Igsv, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dzfq1D_iZsyyNd)
	{
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			Curve nurbsForm = _0023_003Dz1BPEjBg_003D.GetNurbsForm();
			Curve nurbsForm2 = _0023_003Dziidc4_0024c_003D.GetNurbsForm();
			Point3D[] array = Utility.Intersection(nurbsForm, nurbsForm2, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D * 10.0);
			_0023_003DzASylw1urpKM0LGQ6Pw_003D_003D(ref _0023_003DzyzK8swU_003D, (array.Length != 0) ? array[0] : null, array.Length != 0, _0023_003Dz1BPEjBg_003D, _0023_003Dziidc4_0024c_003D, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
	}

	private void _0023_003DzNY6_6G0Lnzi51RMwTqgk880_003D(ref int _0023_003DzyzK8swU_003D, ICurve _0023_003Dz1BPEjBg_003D, ICurve _0023_003Dziidc4_0024c_003D, double _0023_003DzYNjcavt9guh2, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzalFofRO0Igsv, double _0023_003Dzfq1D_iZsyyNd)
	{
		Point3D i;
		Point3D i2;
		bool _0023_003DzfxRH11yqtER41XYo5w_003D_003D = Utility.IntersectionCircleCircle((Circle)_0023_003Dz1BPEjBg_003D, (Circle)_0023_003Dziidc4_0024c_003D, _0023_003Dzpyw2kZk_003D, out i, out i2);
		_0023_003DzASylw1urpKM0LGQ6Pw_003D_003D(ref _0023_003DzyzK8swU_003D, i, _0023_003DzfxRH11yqtER41XYo5w_003D_003D, _0023_003Dz1BPEjBg_003D, _0023_003Dziidc4_0024c_003D, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
	}

	private void _0023_003DzPTUWXguXUfE53_0024VHbQ_003D_003D(ref int _0023_003DzyzK8swU_003D, ICurve _0023_003Dz1BPEjBg_003D, ICurve _0023_003Dziidc4_0024c_003D, double _0023_003DzYNjcavt9guh2, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzalFofRO0Igsv, double _0023_003Dzfq1D_iZsyyNd)
	{
		Point3D i;
		Point3D i2;
		bool _0023_003DzfxRH11yqtER41XYo5w_003D_003D = Utility.IntersectionLineCircle((Line)_0023_003Dziidc4_0024c_003D, (Circle)_0023_003Dz1BPEjBg_003D, _0023_003Dzpyw2kZk_003D, out i, out i2);
		_0023_003DzASylw1urpKM0LGQ6Pw_003D_003D(ref _0023_003DzyzK8swU_003D, i, _0023_003DzfxRH11yqtER41XYo5w_003D_003D, _0023_003Dz1BPEjBg_003D, _0023_003Dziidc4_0024c_003D, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
	}

	private void _0023_003DzuuI025m0e2psLwR01w_003D_003D(ref int _0023_003DzyzK8swU_003D, ICurve _0023_003Dz1BPEjBg_003D, ICurve _0023_003Dziidc4_0024c_003D, double _0023_003DzYNjcavt9guh2, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzalFofRO0Igsv, double _0023_003Dzfq1D_iZsyyNd)
	{
		Point3D i;
		Point3D i2;
		bool _0023_003DzfxRH11yqtER41XYo5w_003D_003D = Utility.IntersectionLineCircle((Line)_0023_003Dz1BPEjBg_003D, (Circle)_0023_003Dziidc4_0024c_003D, _0023_003Dzpyw2kZk_003D, out i, out i2);
		_0023_003DzASylw1urpKM0LGQ6Pw_003D_003D(ref _0023_003DzyzK8swU_003D, i, _0023_003DzfxRH11yqtER41XYo5w_003D_003D, _0023_003Dz1BPEjBg_003D, _0023_003Dziidc4_0024c_003D, _0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
	}

	private void _0023_003DzASylw1urpKM0LGQ6Pw_003D_003D(ref int _0023_003DzyzK8swU_003D, Point3D _0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D, bool _0023_003DzfxRH11yqtER41XYo5w_003D_003D, ICurve _0023_003Dz1BPEjBg_003D, ICurve _0023_003Dziidc4_0024c_003D, double _0023_003DzYNjcavt9guh2, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzalFofRO0Igsv, double _0023_003Dzfq1D_iZsyyNd)
	{
		if (_0023_003DzfxRH11yqtER41XYo5w_003D_003D)
		{
			_0023_003DzjSexx6BgBjUv(_0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D, _0023_003Dz1BPEjBg_003D, _0023_003DzaFEehOi8mwIq: false);
			_0023_003DzjSexx6BgBjUv(_0023_003DzLos_0024H_dHfIKMMA5CKrpAhoU_003D, _0023_003Dziidc4_0024c_003D, _0023_003DzaFEehOi8mwIq: true);
			return;
		}
		List<ICurve> list = _0023_003DzK_0024_00244Vwc_0024Mvgd(_0023_003Dz1BPEjBg_003D, _0023_003Dziidc4_0024c_003D, _0023_003Dzpyw2kZk_003D, _0023_003DzYNjcavt9guh2, _0023_003DzalFofRO0Igsv, _0023_003Dzfq1D_iZsyyNd);
		if (list.Count > 1)
		{
			list.Reverse();
		}
		foreach (ICurve item in list)
		{
			((Entity)item).EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743);
			_curveList.Insert(++_0023_003DzyzK8swU_003D, item);
		}
	}

	private void _0023_003DzL7GAL8HKn0l4(ref int _0023_003DzyzK8swU_003D, ICurve _0023_003Dz1BPEjBg_003D, ICurve _0023_003Dziidc4_0024c_003D, double _0023_003DzYNjcavt9guh2, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzalFofRO0Igsv)
	{
		Segment2D segment2D = new Segment2D(_0023_003Dzpyw2kZk_003D.Project(_0023_003Dz1BPEjBg_003D.StartPoint), _0023_003Dzpyw2kZk_003D.Project(_0023_003Dz1BPEjBg_003D.EndPoint));
		Segment2D segment2D2 = new Segment2D(_0023_003Dzpyw2kZk_003D.Project(_0023_003Dziidc4_0024c_003D.StartPoint), _0023_003Dzpyw2kZk_003D.Project(_0023_003Dziidc4_0024c_003D.EndPoint));
		if (!Segment2D.IntersectionLine(segment2D, segment2D2, out var i))
		{
			i = segment2D.P1;
		}
		double num = segment2D.Project(i);
		double num2 = segment2D2.Project(i);
		if ((num < 0.0 || num > 1.0) && (num2 < 0.0 || num2 > 1.0) && !_0023_003DzalFofRO0Igsv)
		{
			Vector3D _0023_003DzJQRMHqZ1AZoA = _0023_003Dz1BPEjBg_003D.TangentAt(1.0);
			Vector3D _0023_003DzaZocGShtUZNl = _0023_003Dziidc4_0024c_003D.TangentAt(0.0);
			Arc item = _0023_003Dz6r6bAtppa3Zc(_0023_003DzYNjcavt9guh2, _0023_003Dzpyw2kZk_003D, _0023_003DzJQRMHqZ1AZoA, _0023_003DzaZocGShtUZNl, _0023_003Dz1BPEjBg_003D.EndPoint);
			_0023_003DzyzK8swU_003D++;
			_curveList.Insert(_0023_003DzyzK8swU_003D, item);
			return;
		}
		int num3 = _0023_003DzyzK8swU_003D + 1;
		if (num3 == _curveList.Count)
		{
			num3 = 0;
		}
		_curveList[_0023_003DzyzK8swU_003D] = new Line(_0023_003Dz1BPEjBg_003D.StartPoint, _0023_003Dzpyw2kZk_003D.PointAt(i));
		_curveList[num3] = new Line(_0023_003Dzpyw2kZk_003D.PointAt(i), _curveList[num3].EndPoint);
	}

	private static Arc _0023_003Dz6r6bAtppa3Zc(double _0023_003DzfBEBL_o_003D, Plane _0023_003Dzpyw2kZk_003D, Vector3D _0023_003DzJQRMHqZ1AZoA, Vector3D _0023_003DzaZocGShtUZNl, Point3D _0023_003DzMEwtr_A_003D)
	{
		Point3D p = new Point3D(_0023_003DzJQRMHqZ1AZoA.X, _0023_003DzJQRMHqZ1AZoA.Y, _0023_003DzJQRMHqZ1AZoA.Z);
		Point3D p2 = new Point3D(_0023_003DzaZocGShtUZNl.X, _0023_003DzaZocGShtUZNl.Y, _0023_003DzaZocGShtUZNl.Z);
		Vector3D vector3D = Vector3D.Cross(_0023_003DzJQRMHqZ1AZoA, _0023_003Dzpyw2kZk_003D.AxisZ);
		vector3D.Normalize();
		Vector3D vector3D2 = vector3D * _0023_003DzfBEBL_o_003D;
		Point3D point3D = _0023_003DzMEwtr_A_003D - vector3D2;
		Point2D a = _0023_003Dzpyw2kZk_003D.Project(_0023_003DzMEwtr_A_003D);
		Point2D b = _0023_003Dzpyw2kZk_003D.Project(point3D);
		double angle = Vector2D.Subtract(a, b).Angle;
		Point2D a2 = _0023_003Dzpyw2kZk_003D.Project(p);
		Point2D a3 = _0023_003Dzpyw2kZk_003D.Project(p2);
		Point2D b2 = _0023_003Dzpyw2kZk_003D.Project(Point3D.Origin);
		Vector2D u = Vector2D.Subtract(a2, b2);
		Vector2D v = Vector2D.Subtract(a3, b2);
		double num = Vector2D.SignedAngleBetween(u, v);
		Arc arc = new Arc(_0023_003Dzpyw2kZk_003D, point3D, Math.Abs(_0023_003DzfBEBL_o_003D), angle, angle + num);
		if (Vector3D.Dot(arc.TangentAt(arc.Domain.t0), _0023_003DzJQRMHqZ1AZoA) < 0.0)
		{
			arc = new Arc(_0023_003Dzpyw2kZk_003D, point3D, Math.Abs(_0023_003DzfBEBL_o_003D), angle, angle - num);
		}
		return arc;
	}

	private static List<ICurve> _0023_003DzK_0024_00244Vwc_0024Mvgd(ICurve _0023_003DzMyTGSO0_003D, ICurve _0023_003DzmpbFMfw_003D, Plane _0023_003Dzpyw2kZk_003D, double _0023_003DzfBEBL_o_003D, bool _0023_003DzalFofRO0Igsv, double _0023_003Dzfq1D_iZsyyNd)
	{
		List<ICurve> list = new List<ICurve>();
		Point3D point3D = (Point3D)_0023_003DzMyTGSO0_003D.EndPoint.Clone();
		_0023_003DzMyTGSO0_003D.Project(point3D, out var t);
		Vector3D vector3D = _0023_003DzMyTGSO0_003D.TangentAt(t);
		Point3D point3D2 = (Point3D)_0023_003DzmpbFMfw_003D.StartPoint.Clone();
		_0023_003DzmpbFMfw_003D.Project(point3D2, out t);
		Vector3D vector3D2 = _0023_003DzmpbFMfw_003D.TangentAt(t);
		if (Point3D.Distance(point3D, point3D2) < _0023_003Dzfq1D_iZsyyNd * 1E-08)
		{
			return list;
		}
		if (_0023_003DzalFofRO0Igsv)
		{
			Segment2D s = new Segment2D(_0023_003Dzpyw2kZk_003D.Project(point3D), _0023_003Dzpyw2kZk_003D.Project(point3D + _0023_003DzfBEBL_o_003D * vector3D));
			Segment2D s2 = new Segment2D(_0023_003Dzpyw2kZk_003D.Project(point3D2), _0023_003Dzpyw2kZk_003D.Project(point3D2 - _0023_003DzfBEBL_o_003D * vector3D2));
			if (!Segment2D.IntersectionLine(s, s2, out var i))
			{
				Arc item = _0023_003Dz6r6bAtppa3Zc(_0023_003DzfBEBL_o_003D, _0023_003Dzpyw2kZk_003D, vector3D, vector3D2, point3D);
				list.Add(item);
			}
			else
			{
				list.Add(new Line(_0023_003Dzpyw2kZk_003D.PointAt(i), point3D2));
				list.Add(new Line(point3D, _0023_003Dzpyw2kZk_003D.PointAt(i)));
			}
		}
		else
		{
			Arc item2 = _0023_003Dz6r6bAtppa3Zc(_0023_003DzfBEBL_o_003D, _0023_003Dzpyw2kZk_003D, vector3D, vector3D2, point3D);
			list.Add(item2);
		}
		return list;
	}

	private static void _0023_003DzjSexx6BgBjUv(Point3D _0023_003DzMlCq3wk_003D, ICurve _0023_003DzYqa83Us_003D, bool _0023_003DzaFEehOi8mwIq)
	{
		if (_0023_003DzYqa83Us_003D is Line)
		{
			((Line)_0023_003DzYqa83Us_003D).TrimBy(_0023_003DzMlCq3wk_003D, _0023_003DzaFEehOi8mwIq);
		}
		else if (_0023_003DzYqa83Us_003D is Arc)
		{
			((Arc)_0023_003DzYqa83Us_003D).TrimBy(_0023_003DzMlCq3wk_003D, _0023_003DzaFEehOi8mwIq);
		}
		else if (_0023_003DzYqa83Us_003D is EllipticalArc)
		{
			((EllipticalArc)_0023_003DzYqa83Us_003D).TrimBy(_0023_003DzMlCq3wk_003D, _0023_003DzaFEehOi8mwIq);
		}
		else
		{
			((Curve)_0023_003DzYqa83Us_003D).TrimBy(_0023_003DzMlCq3wk_003D, _0023_003DzaFEehOi8mwIq);
		}
	}

	public Curve GetNurbsForm()
	{
		Curve curve = Curve.Merge(_curveList, clean: false);
		curve.CopyAttributes(this);
		return curve;
	}

	internal Curve _0023_003Dz_AymzZtTeFcznZcRKzWCAYE_003D()
	{
		int count = _curveList.Count;
		ICurve[] array = new ICurve[count];
		for (int i = 0; i < count; i++)
		{
			Curve nurbsForm = _curveList[i].GetNurbsForm();
			double num = _curveList[i].Length();
			if (nurbsForm.Domain.Length != num)
			{
				nurbsForm._0023_003DziP9fFuA_003D.Offset(0.0 - nurbsForm.Domain.Low);
				nurbsForm._0023_003DziP9fFuA_003D.Scale(num / nurbsForm.Domain.High);
			}
			array[i] = nurbsForm;
		}
		return Curve.Merge(array);
	}

	public bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		double _0023_003DzvGprkFLYK8ip;
		int num = _0023_003DzwTrzxq4lzEFtf_0zYg_003D_003D(t, out _0023_003DzvGprkFLYK8ip);
		if (num != -1)
		{
			ICurve curve = CurveList[num];
			int count = CurveList.Count;
			bool flag = Utility.AreEqual(_0023_003DzvGprkFLYK8ip, curve.Domain.Low, curve.Domain.Length * 1000.0);
			if (num == 0 && (flag || _0023_003DzvGprkFLYK8ip < curve.Domain.Low))
			{
				lower = null;
				upper = null;
				return false;
			}
			bool flag2 = Utility.AreEqual(_0023_003DzvGprkFLYK8ip, curve.Domain.High, curve.Domain.Length * 1000.0);
			if (num == count - 1 && (flag2 || _0023_003DzvGprkFLYK8ip > curve.Domain.High))
			{
				lower = null;
				upper = null;
				return false;
			}
			CompositeCurve compositeCurve = new CompositeCurve();
			for (int i = 0; i < num; i++)
			{
				compositeCurve.CurveList.Add(CurveList[i]);
			}
			CompositeCurve compositeCurve2 = new CompositeCurve();
			for (int j = num + 1; j < CurveList.Count; j++)
			{
				compositeCurve2.CurveList.Add(CurveList[j]);
			}
			if (_0023_003DzvGprkFLYK8ip > curve.Domain.Low && _0023_003DzvGprkFLYK8ip < curve.Domain.High)
			{
				if (curve.SplitAt(_0023_003DzvGprkFLYK8ip, out var lower2, out var upper2))
				{
					compositeCurve.CurveList.Add(lower2);
					compositeCurve2.CurveList.Insert(0, upper2);
				}
				else if (_0023_003DzvGprkFLYK8ip > curve.Domain.Mid)
				{
					compositeCurve.CurveList.Add(curve);
				}
				else
				{
					compositeCurve2.CurveList.Insert(0, curve);
				}
			}
			else if (flag)
			{
				compositeCurve2.CurveList.Insert(0, CurveList[num]);
			}
			else if (flag2)
			{
				compositeCurve.CurveList.Add(CurveList[num]);
			}
			lower = compositeCurve;
			upper = compositeCurve2;
			((Entity)lower).CopyAttributes(this);
			((Entity)upper).CopyAttributes(this);
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	public bool SplitBy(Point3D pt, out ICurve lower, out ICurve upper)
	{
		double _0023_003DzIPFgWVnZ6O9r;
		int num = _0023_003DzMFcb8juiYhuQ(pt, _0023_003Dz3P41GFRPL8iZ: true, out _0023_003DzIPFgWVnZ6O9r);
		if (num != -1)
		{
			ICurve curve = CurveList[num];
			int count = CurveList.Count;
			bool flag = Utility.AreEqual(_0023_003DzIPFgWVnZ6O9r, 0.0, curve.Domain.Length * 1000.0);
			if (flag && num == 0)
			{
				lower = null;
				upper = null;
				return false;
			}
			bool flag2 = Utility.AreEqual(_0023_003DzIPFgWVnZ6O9r, curve.Domain.Length, curve.Domain.Length * 1000.0);
			if (flag2 && num == count - 1)
			{
				lower = null;
				upper = null;
				return false;
			}
			CompositeCurve compositeCurve = new CompositeCurve();
			for (int i = 0; i < num; i++)
			{
				compositeCurve.CurveList.Add(CurveList[i]);
			}
			CompositeCurve compositeCurve2 = new CompositeCurve();
			for (int j = num + 1; j < CurveList.Count; j++)
			{
				compositeCurve2.CurveList.Add(CurveList[j]);
			}
			if (_0023_003DzIPFgWVnZ6O9r > 0.0 && _0023_003DzIPFgWVnZ6O9r < curve.Domain.Length)
			{
				if (curve.SplitBy(pt, out var lower2, out var upper2))
				{
					compositeCurve.CurveList.Add(lower2);
					compositeCurve2.CurveList.Insert(0, upper2);
				}
				else if (_0023_003DzIPFgWVnZ6O9r > curve.Domain.Length / 2.0)
				{
					compositeCurve.CurveList.Add(curve);
				}
				else
				{
					compositeCurve2.CurveList.Insert(0, curve);
				}
			}
			else if (flag)
			{
				compositeCurve2.CurveList.Insert(0, CurveList[num]);
			}
			else if (flag2)
			{
				compositeCurve.CurveList.Add(CurveList[num]);
			}
			lower = compositeCurve;
			upper = compositeCurve2;
			((Entity)lower).CopyAttributes(this);
			((Entity)upper).CopyAttributes(this);
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	public bool SplitBy(IList<Point3D> points, out ICurve[] segments)
	{
		bool result = Utility._0023_003Dz01EVtoUdEn9B(this, points, out segments);
		ICurve[] array = segments;
		for (int i = 0; i < array.Length; i++)
		{
			((Entity)array[i]).CopyAttributes(this);
		}
		return result;
	}

	public ICurve[] GetIndividualCurves()
	{
		return _curveList.ToArray();
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (CurveList.Count == 0)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963213));
			return false;
		}
		for (int i = 0; i < _curveList.Count; i++)
		{
			if (!((Entity)_curveList[i]).IsValid(log))
			{
				return false;
			}
		}
		for (int j = 0; j < _curveList.Count - 1; j++)
		{
			ICurve curve = _curveList[j];
			ICurve curve2 = _curveList[j + 1];
			if (curve.EndPoint != curve2.StartPoint)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963433), j));
				return false;
			}
		}
		return base.IsValid(log);
	}

	public override void Regen(RegenParams data)
	{
		int num = 0;
		Point3D[][] array = new Point3D[_curveList.Count][];
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			Point3D[] array2;
			if (data._0023_003DzKm6RxpjBoSEs)
			{
				array2 = entity._0023_003DzDphw2mIGq8srlxP4lA_003D_003D(data);
			}
			else
			{
				entity.Regen(data);
				array2 = entity._vertices;
			}
			num += array2.Length - 1;
			array[i] = array2;
		}
		_vertices = _0023_003DzZTx6Or_0024_0024RWbzeZoJBQ_003D_003D(num, array);
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	internal static Point3D[] _0023_003DzZTx6Or_0024_0024RWbzeZoJBQ_003D_003D(int _0023_003DzmyaSc6kY9NXE, Point3D[][] _0023_003DzKZ72GEoBTfh_0024YqapUbZcwtQ_003D)
	{
		Point3D[] array = new Point3D[_0023_003DzmyaSc6kY9NXE + 1];
		int num = 0;
		for (int i = 0; i < _0023_003DzKZ72GEoBTfh_0024YqapUbZcwtQ_003D.Length; i++)
		{
			Point3D[] array2 = _0023_003DzKZ72GEoBTfh_0024YqapUbZcwtQ_003D[i];
			Array.Copy(array2, 0, array, num, array2.Length - 1);
			num += array2.Length - 1;
			if (i == _0023_003DzKZ72GEoBTfh_0024YqapUbZcwtQ_003D.Length - 1)
			{
				array[num] = array2[^1];
			}
		}
		return array;
	}

	private void _0023_003DzZTx6Or_0024_0024RWbzeZoJBQ_003D_003D()
	{
		int num = 0;
		Point3D[][] array = new Point3D[_curveList.Count][];
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			num += entity.Vertices.Length - 1;
			array[i] = entity.Vertices;
		}
		_vertices = _0023_003DzZTx6Or_0024_0024RWbzeZoJBQ_003D_003D(num, array);
	}

	public void SortAndOrient()
	{
		List<Point3D> list = new List<Point3D>(_curveList.Count * 2);
		foreach (Entity curve in _curveList)
		{
			_0023_003Dzk_1OX5z_d_0024zS((ICurve)curve);
			list.AddRange(curve.EstimateBoundingBox(null, null));
		}
		Utility.ComputeBoundingBox(list, out var boxMin, out var boxMax);
		double closureTol = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003DzheSR8QM7q9ya;
		Utility.SortAndOrient(_curveList, closureTol);
	}

	public void SortAndOrient(double closureTol)
	{
		foreach (ICurve curve in _curveList)
		{
			_0023_003Dzk_1OX5z_d_0024zS(curve);
		}
		Utility.SortAndOrient(_curveList, closureTol);
	}

	private void _0023_003Dzk_1OX5z_d_0024zS(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		if (_0023_003Dz8fpRyMu9aKjE is CompositeCurve)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963384) + _0023_003Dz8fpRyMu9aKjE.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963345) + _curveList.Count);
		stringBuilder.AppendLine(string.Concat(str3: IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var _) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964049) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964069), str0: _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963339), str1: Utility._0023_003DzheSR8QM7q9ya.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425)), str2: _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964092)));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962751) + (IsClosed ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964049) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964069)));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964062) + Utility.GetMaxGap(CurveList, closed: false));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956065) + StartPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956056) + EndPoint);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964024) + Domain.ToString());
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963264) + Length().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public bool IsOrientedClockwise(Plane plane)
	{
		return Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(this, plane);
	}

	public override void TransformBy(Transformation xform)
	{
		foreach (Entity curve in _curveList)
		{
			curve.TransformBy(xform);
		}
		base.TransformBy(xform);
	}

	private protected override void _0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(Transformation _0023_003DzLS0sR0pzioXc, bool _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D)
	{
	}

	public LinearPath ConvertToLinearPath(double deviation = 0.0, double angle = 0.0)
	{
		if (deviation == 0.0)
		{
			if (_vertices == null)
			{
				if (IsCurved())
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964005));
				}
				Regen(new RegenParams(0.0, 0.0));
			}
			return _0023_003DztgI92lDISTaw0QRVK9fD0NM_003D();
		}
		CompositeCurve obj = (CompositeCurve)Clone();
		obj.Regen(new RegenParams(deviation, angle));
		return obj.ConvertToLinearPath();
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(amount, tolerance, meshNature);
	}

	public Mesh ExtrudeAsMesh(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(amount, tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		Mesh[] array = _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		T[] array = _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		return _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, merge);
	}

	public T[] SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, merge);
	}

	public Surface[] ExtrudeAsSurface(Line line)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(line.Direction);
	}

	public Surface[] ExtrudeAsSurface(double dx, double dy, double dz)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(new Vector3D(dx, dy, dz));
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
		}
		Vector3D obj = (Vector3D)amount.Clone();
		obj.Normalize();
		if (!IsPlanar(tolerance, out var plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964222));
		}
		double offsetDistance = Entity.GetOffsetDistance(obj, amount, draftAngleInRadians);
		ICurve[] individualCurves = GetIndividualCurves();
		ICurve[][] array;
		if (Vector3D.AreParallel(obj, plane.AxisZ))
		{
			array = Offset(offsetDistance, amount, sharp: true).Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzRXjcYOSP9cNHgE7NFkXsI6hYR0ISJcN_Jg_003D_003D).ToArray();
		}
		else
		{
			array = new ICurve[individualCurves.Length][];
			for (int i = 0; i < individualCurves.Length; i++)
			{
				array[i] = individualCurves[i].Offset(offsetDistance, amount, sharp: true);
			}
		}
		List<Surface> list = new List<Surface>();
		for (int j = 0; j < array.Length; j++)
		{
			int num = 0;
			for (int k = 0; k < array[j].Length; k++)
			{
				Entity entity = (Entity)array[j][k].Clone();
				entity.Translate(amount);
				if (entity.EntityData == null || entity.EntityData.ToString() != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941743))
				{
					Surface surface = Surface.Ruled(individualCurves[num], (ICurve)entity);
					surface.ReverseU();
					surface.CopyAttributes(this);
					list.Add(surface);
					num++;
				}
			}
		}
		return list.ToArray();
	}

	public Brep ExtrudeAsBrep(Line line, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, line.Direction, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, new Vector3D(dx, dy, dz), _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, amount, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		if (!IsPlanar(tolerance, out var plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964222));
		}
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		List<ICurve> list = new List<ICurve>();
		ICurve[] individualCurves = GetIndividualCurves();
		foreach (ICurve curve in individualCurves)
		{
			list.AddRange(curve.GetIndividualCurves());
		}
		ICurve[] array3;
		if (!Vector3D.AreParallel(vector3D, plane.AxisZ))
		{
			Curve nurbsForm = GetNurbsForm();
			individualCurves = nurbsForm.SplitAtDiscontinuities(speedChange: false);
			ICurve[] array = individualCurves;
			bool flag = true;
			if (IsClosed)
			{
				Vector3D[] array2 = new Vector3D[2]
				{
					(Vector3D)nurbsForm.StartTangent.Clone(),
					(Vector3D)nurbsForm.EndTangent.Clone()
				};
				flag = Vector3D.AreCoincident(array2[0], array2[1]);
			}
			if (array.Length > 1 || !flag)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964190));
			}
			array3 = new ICurve[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				ICurve[] array4 = array3;
				int num = j;
				ICurve[] array5 = list[j].Offset(offsetDistance, amount, sharp: true);
				array4[num] = ((array5 != null) ? array5[0] : null);
				((Entity)array3[j]).Translate(amount);
			}
		}
		else
		{
			ICurve[] array6 = Offset(offsetDistance, amount, sharp: true);
			ICurve obj = ((array6 != null) ? array6[0] : null);
			((Entity)obj).Translate(amount);
			array3 = obj.GetIndividualCurves();
			if (array3.Length != list.Count)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964128));
			}
		}
		int count = list.Count;
		Point3D[] array8;
		Brep.Edge[] array9;
		Brep.Face[] array10;
		Brep.OrientedEdge[][] array11;
		NurbsSurf[] array12;
		if (IsClosed)
		{
			Point3D[] array7 = new Brep.Vertex[count * 2];
			array8 = array7;
			array9 = new Brep.Edge[count * 3];
			array10 = new Brep.Face[count];
			array11 = new Brep.OrientedEdge[count][];
			array12 = new NurbsSurf[count];
		}
		else
		{
			Point3D[] array7 = new Brep.Vertex[count * 2 + 2];
			array8 = array7;
			array9 = new Brep.Edge[count * 3 + 1];
			array11 = new Brep.OrientedEdge[count][];
			array12 = new NurbsSurf[count];
			array10 = new Brep.Face[count];
		}
		int num2 = array8.Length / 2;
		for (int k = 0; k < count; k++)
		{
			array8[k] = new Brep.Vertex(list[k].StartPoint.X, list[k].StartPoint.Y, list[k].StartPoint.Z);
			array8[num2 + k] = new Brep.Vertex(array3[k].StartPoint.X, array3[k].StartPoint.Y, array3[k].StartPoint.Z);
			if (!IsClosed && k == count - 1)
			{
				array8[k + 1] = new Brep.Vertex(list[k].EndPoint.X, list[k].EndPoint.Y, list[k].EndPoint.Z);
				array8[num2 + k + 1] = new Brep.Vertex(array3[k].EndPoint.X, array3[k].EndPoint.Y, array3[k].EndPoint.Z);
			}
			int num3 = k + 1;
			if (IsClosed)
			{
				num3 = (k + 1) % num2;
			}
			array9[k] = new Brep.Edge((ICurve)list[k].Clone(), k, num3);
			array9[count + k] = new Brep.Edge((ICurve)array3[k].Clone(), num2 + k, num2 + num3);
			array9[count * 2 + k] = new Brep.Edge(new Line((Point3D)array8[k].Clone(), (Point3D)array8[num2 + k].Clone()), k, num2 + k);
			if (!IsClosed && k == count - 1)
			{
				array9[count * 2 + num3] = new Brep.Edge(new Line((Point3D)array8[num3].Clone(), (Point3D)array8[num2 + num3].Clone()), num3, num2 + num3);
			}
			array11[k] = new Brep.OrientedEdge[4];
			array11[k][0] = new Brep.OrientedEdge(k);
			array11[k][1] = new Brep.OrientedEdge(count * 2 + num3);
			array11[k][2] = new Brep.OrientedEdge(count + k, sense: false);
			array11[k][3] = new Brep.OrientedEdge(count * 2 + k, sense: false);
			Surface surface = Surface.Ruled(list[k], array3[k]);
			array12[k] = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints, k);
			array10[k] = new Brep.Face(array12[k], new Brep.Loop(array11[k]));
		}
		Brep brep = new Brep(array8, array9, array10, null, tolerance);
		brep.CopyAttributes(this);
		return brep;
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis.Direction, axis.StartPoint);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, startAngle, deltaAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, intervalAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Line axis, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Line axis, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003Dz789GXCk_003D(rail, tol, methodType);
	}

	public Brep SweepAsBrep(ICurve rail, double tolerance, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep[] array = Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, _0023_003DzjepEGXc_003D: true, methodType);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Brep[] SweepAsBrep(ICurve rail, double tolerance, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, merge, methodType);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount, tolerance);
	}

	public Solid ExtrudeAsSolid(double dx, double dy, double dz, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(new Vector3D(dx, dy, dz), tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(intervalAngle.Low, intervalAngle.Length, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(intervalAngle.Low, intervalAngle.Length, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid SweepAsSolid(ICurve rail, double tol, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		Solid[] array = _0023_003DzggPwIWi3oqtM(rail, tol, _0023_003DzjepEGXc_003D: true, sweepMethod);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Solid[] SweepAsSolid(ICurve rail, double tol, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003DzggPwIWi3oqtM(rail, tol, merge, sweepMethod);
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D())
		{
			return CurveList.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzBA_VpJExH85e4mjmxHYpXHjyj33o);
		}
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new CompositeCurveSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963230), _curveList);
	}

	public void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax)
	{
		GetTightBBox(out boxMin, out boxMax);
	}

	public bool MoreOfTwoSegmentsIncidentOnTheSameEndpoint(double equalTol = 1E-06)
	{
		Dictionary<Point3D, int> dictionary = new Dictionary<Point3D, int>();
		foreach (ICurve curve in _curveList)
		{
			if (!_0023_003DzUwwMDZY_003D(dictionary, curve.StartPoint, equalTol, out var _0023_003DzcB8c8dw_003D))
			{
				dictionary.Add(curve.StartPoint, 1);
			}
			else
			{
				dictionary[_0023_003DzcB8c8dw_003D]++;
				if (dictionary[_0023_003DzcB8c8dw_003D] > 2)
				{
					return true;
				}
			}
			if (!_0023_003DzUwwMDZY_003D(dictionary, curve.EndPoint, equalTol, out _0023_003DzcB8c8dw_003D))
			{
				dictionary.Add(curve.EndPoint, 1);
				continue;
			}
			dictionary[_0023_003DzcB8c8dw_003D]++;
			if (dictionary[_0023_003DzcB8c8dw_003D] <= 2)
			{
				continue;
			}
			return true;
		}
		return false;
	}

	private bool _0023_003DzUwwMDZY_003D(Dictionary<Point3D, int> _0023_003Dzd7nry7g_003D, Point3D _0023_003DzMlCq3wk_003D, double _0023_003Dz3SduW_0024w_003D, out Point3D _0023_003DzcB8c8dw_003D)
	{
		foreach (Point3D key in _0023_003Dzd7nry7g_003D.Keys)
		{
			if (Point3D.Distance(key, _0023_003DzMlCq3wk_003D) < _0023_003Dz3SduW_0024w_003D)
			{
				_0023_003DzcB8c8dw_003D = key;
				return true;
			}
		}
		_0023_003DzcB8c8dw_003D = null;
		return false;
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromICurve(this, parents);
	}

	public static CompositeCurve CreateRectangle(double width, double height, bool centered = false)
	{
		List<ICurve> list = new List<ICurve>();
		if (centered)
		{
			list.Add(new Line((0.0 - width) / 2.0, (0.0 - height) / 2.0, width / 2.0, (0.0 - height) / 2.0));
			list.Add(new Line(width / 2.0, (0.0 - height) / 2.0, width / 2.0, height / 2.0));
			list.Add(new Line(width / 2.0, height / 2.0, (0.0 - width) / 2.0, height / 2.0));
			list.Add(new Line((0.0 - width) / 2.0, height / 2.0, (0.0 - width) / 2.0, (0.0 - height) / 2.0));
		}
		else
		{
			list.Add(new Line(0.0, 0.0, width, 0.0));
			list.Add(new Line(width, 0.0, width, height));
			list.Add(new Line(width, height, 0.0, height));
			list.Add(new Line(0.0, height, 0.0, 0.0));
		}
		return new CompositeCurve(list, sortAndOrient: false);
	}

	public static CompositeCurve CreateRectangle(double x, double y, double width, double height, double angle = 0.0, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateRectangle(width, height, centered);
		if (angle != 0.0)
		{
			compositeCurve.Rotate(angle, Vector3D.AxisZ);
		}
		compositeCurve.Translate(x, y);
		return compositeCurve;
	}

	public static CompositeCurve CreateRectangle(Plane sketchPlane, double width, double height, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateRectangle(width, height, centered);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreateRectangle(Plane sketchPlane, double x, double y, double width, double height, double angle = 0.0, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateRectangle(x, y, width, height, angle, centered);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreateRoundedRectangle(double width, double height, double radius, bool centered = false)
	{
		List<ICurve> list = new List<ICurve>();
		if (centered)
		{
			list.Add(new Line((0.0 - width) / 2.0 + radius, (0.0 - height) / 2.0, width / 2.0 - radius, (0.0 - height) / 2.0));
			list.Add(new Arc(width / 2.0 - radius, (0.0 - height) / 2.0 + radius, 0.0, radius, Utility.DegToRad(270.0), Utility.DegToRad(360.0)));
			list.Add(new Line(width / 2.0, (0.0 - height) / 2.0 + radius, width / 2.0, height / 2.0 - radius));
			list.Add(new Arc(width / 2.0 - radius, height / 2.0 - radius, 0.0, radius, Utility.DegToRad(0.0), Utility.DegToRad(90.0)));
			list.Add(new Line(width / 2.0 - radius, height / 2.0, (0.0 - width) / 2.0 + radius, height / 2.0));
			list.Add(new Arc((0.0 - width) / 2.0 + radius, height / 2.0 - radius, 0.0, radius, Utility.DegToRad(90.0), Utility.DegToRad(180.0)));
			list.Add(new Line((0.0 - width) / 2.0, height / 2.0 - radius, (0.0 - width) / 2.0, (0.0 - height) / 2.0 + radius));
			list.Add(new Arc((0.0 - width) / 2.0 + radius, (0.0 - height) / 2.0 + radius, 0.0, radius, Utility.DegToRad(180.0), Utility.DegToRad(270.0)));
		}
		else
		{
			list.Add(new Line(radius, 0.0, width - radius, 0.0));
			list.Add(new Arc(width - radius, radius, 0.0, radius, Utility.DegToRad(270.0), Utility.DegToRad(360.0)));
			list.Add(new Line(width, radius, width, height - radius));
			list.Add(new Arc(width - radius, height - radius, 0.0, radius, Utility.DegToRad(0.0), Utility.DegToRad(90.0)));
			list.Add(new Line(width - radius, height, radius, height));
			list.Add(new Arc(radius, height - radius, 0.0, radius, Utility.DegToRad(90.0), Utility.DegToRad(180.0)));
			list.Add(new Line(0.0, height - radius, 0.0, radius));
			list.Add(new Arc(radius, radius, 0.0, radius, Utility.DegToRad(180.0), Utility.DegToRad(270.0)));
		}
		return new CompositeCurve(list, sortAndOrient: false);
	}

	public static CompositeCurve CreateRoundedRectangle(double x, double y, double width, double height, double radius, double angle = 0.0, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateRoundedRectangle(width, height, radius, centered);
		if (angle != 0.0)
		{
			compositeCurve.Rotate(angle, Vector3D.AxisZ);
		}
		compositeCurve.Translate(x, y);
		return compositeCurve;
	}

	public static CompositeCurve CreateRoundedRectangle(Plane sketchPlane, double width, double height, double radius, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateRoundedRectangle(width, height, radius, centered);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreateRoundedRectangle(Plane sketchPlane, double x, double y, double width, double height, double radius, double angle = 0.0, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateRoundedRectangle(x, y, width, height, radius, angle, centered);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreateSlot(double length, double radius, bool centered = false)
	{
		List<ICurve> list = new List<ICurve>();
		if (centered)
		{
			list.Add(new Line((0.0 - length) / 2.0, 0.0 - radius, length / 2.0, 0.0 - radius));
			list.Add(new Arc(length / 2.0, 0.0, 0.0, radius, 4.71238898038469, 7.853981633974483));
			list.Add(new Line(length / 2.0, radius, (0.0 - length) / 2.0, radius));
			list.Add(new Arc((0.0 - length) / 2.0, 0.0, 0.0, radius, Math.PI / 2.0, 4.71238898038469));
		}
		else
		{
			list.Add(new Line(0.0, 0.0 - radius, length, 0.0 - radius));
			list.Add(new Arc(length, 0.0, 0.0, radius, 4.71238898038469, 7.853981633974483));
			list.Add(new Line(length, radius, 0.0, radius));
			list.Add(new Arc(0.0, 0.0, 0.0, radius, Math.PI / 2.0, 4.71238898038469));
		}
		return new CompositeCurve(list, sortAndOrient: false);
	}

	public static CompositeCurve CreateSlot(double x, double y, double length, double radius, double angle = 0.0, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateSlot(length, radius, centered);
		if (angle != 0.0)
		{
			compositeCurve.Rotate(angle, Vector3D.AxisZ);
		}
		compositeCurve.Translate(x, y);
		return compositeCurve;
	}

	public static CompositeCurve CreateSlot(Plane sketchPlane, double length, double radius, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateSlot(length, radius, centered);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreateSlot(Plane sketchPlane, double x, double y, double length, double radius, double angle = 0.0, bool centered = false)
	{
		CompositeCurve compositeCurve = CreateSlot(x, y, length, radius, angle, centered);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreateCircularSlot(double angle, double radius, double slotRadius)
	{
		return CreateCircularSlot(0.0, angle, radius, slotRadius);
	}

	public static CompositeCurve CreateCircularSlot(double x, double y, double angle, double radius, double slotRadius)
	{
		return CreateCircularSlot(x, y, 0.0, angle, radius, slotRadius);
	}

	public static CompositeCurve CreateCircularSlot(Plane sketchPlane, double angle, double radius, double slotRadius)
	{
		return CreateCircularSlot(sketchPlane, 0.0, 0.0, 0.0, angle, radius, slotRadius);
	}

	public static CompositeCurve CreateCircularSlot(Plane sketchPlane, double x, double y, double angle, double radius, double slotRadius)
	{
		return CreateCircularSlot(sketchPlane, x, y, 0.0, angle, radius, slotRadius);
	}

	public static CompositeCurve CreateCircularSlot(Plane sketchPlane, double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		return CreateCircularSlot(sketchPlane, 0.0, 0.0, startAngle, deltaAngle, radius, slotRadius);
	}

	public static CompositeCurve CreateCircularSlot(double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		List<ICurve> obj = new List<ICurve>
		{
			new Arc(0.0, 0.0, 0.0, radius + slotRadius, 0.0, deltaAngle)
		};
		Arc arc = new Arc(radius, 0.0, 0.0, slotRadius, 0.0, Math.PI);
		arc.Rotate(deltaAngle, Vector3D.AxisZ);
		obj.Add(arc);
		obj.Add(new Arc(0.0, 0.0, 0.0, radius - slotRadius, deltaAngle, 0.0));
		obj.Add(new Arc(radius, 0.0, 0.0, slotRadius, Math.PI, Math.PI * 2.0));
		CompositeCurve compositeCurve = new CompositeCurve(obj, sortAndOrient: false);
		if (startAngle != 0.0)
		{
			compositeCurve.Rotate(startAngle, Vector3D.AxisZ);
		}
		return compositeCurve;
	}

	public static CompositeCurve CreateCircularSlot(double x, double y, double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		CompositeCurve compositeCurve = CreateCircularSlot(startAngle, deltaAngle, radius, slotRadius);
		compositeCurve.Translate(x, y);
		return compositeCurve;
	}

	public static CompositeCurve CreateCircularSlot(Plane sketchPlane, double x, double y, double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		CompositeCurve compositeCurve = CreateCircularSlot(x, y, startAngle, deltaAngle, radius, slotRadius);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreateHexagon(double radius, bool inscribed = false)
	{
		List<ICurve> list = new List<ICurve>();
		double num = radius;
		if (inscribed)
		{
			num = radius / Math.Cos(Math.PI / 6.0);
		}
		double x = num;
		double y = 0.0;
		for (int i = 1; i < 7; i++)
		{
			double num2 = (double)i * (Math.PI * 2.0) / 6.0;
			double num3 = num * Math.Cos(num2);
			double num4 = num * Math.Sin(num2);
			list.Add(new Line(x, y, num3, num4));
			x = num3;
			y = num4;
		}
		return new CompositeCurve(list, sortAndOrient: false);
	}

	public static CompositeCurve CreateHexagon(double x, double y, double radius, double angle = 0.0, bool inscribed = false)
	{
		CompositeCurve compositeCurve = CreateHexagon(radius, inscribed);
		if (angle != 0.0)
		{
			compositeCurve.Rotate(angle, Vector3D.AxisZ);
		}
		compositeCurve.Translate(x, y);
		return compositeCurve;
	}

	public static CompositeCurve CreateHexagon(Plane sketchPlane, double x, double y, double radius, double angle = 0.0, bool inscribed = false)
	{
		CompositeCurve compositeCurve = CreateHexagon(x, y, radius, angle, inscribed);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public static CompositeCurve CreatePolygon(int sides, double radius, double angle, bool inscribed = false)
	{
		double num = radius;
		if (inscribed)
		{
			num = radius / Math.Cos(Math.PI / (double)sides);
		}
		double num2 = 0.0 / (double)sides + angle;
		double x = num * Math.Cos(num2);
		double y = num * Math.Sin(num2);
		ICurve[] array = new ICurve[sides];
		for (int i = 1; i < sides + 1; i++)
		{
			num2 = (double)i * (Math.PI * 2.0) / (double)sides + angle;
			double num3 = num * Math.Cos(num2);
			double num4 = num * Math.Sin(num2);
			array[i - 1] = new Line(x, y, num3, num4);
			x = num3;
			y = num4;
		}
		return new CompositeCurve(array, sortAndOrient: false);
	}

	public static CompositeCurve CreatePolygon(double x, double y, int sides, double radius, double angle = 0.0, bool inscribed = false)
	{
		CompositeCurve compositeCurve = CreatePolygon(sides, radius, angle, inscribed);
		if (angle != 0.0)
		{
			compositeCurve.Rotate(angle, Vector3D.AxisZ);
		}
		compositeCurve.Translate(x, y);
		return compositeCurve;
	}

	public static CompositeCurve CreatePolygon(Plane sketchPlane, double x, double y, int sides, double radius, double angle = 0.0, bool inscribed = false)
	{
		CompositeCurve compositeCurve = CreatePolygon(x, y, sides, radius, angle, inscribed);
		Transformation xform = Transformation.CreateAlignment(Plane.XY, sketchPlane);
		compositeCurve.TransformBy(xform);
		return compositeCurve;
	}

	public void ResetSelectionMode()
	{
		if (!IsAnySubCurveSelected())
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	protected internal override bool SelectedInternal()
	{
		return SelectionMode != selectionFilterType.Entity;
	}

	internal override bool IsSelected(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		if (SelectionMode == selectionFilterType.Entity)
		{
			return base.IsSelected(_0023_003Dzq5nwX2I_003D, _0023_003DzLEq8mIc_003D);
		}
		bool flag = false;
		if (SelectionMode == selectionFilterType.SubCurve && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, SubCurvesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH))
		{
			flag |= SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH.SubItems, _0023_003DzLEq8mIc_003D);
		}
		return flag;
	}

	internal void ClearSubCurvesSelection(selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(_0023_003DzCYtX6jC7ppkE, this, SubCurvesSelectionInfo);
		if (_0023_003DzCYtX6jC7ppkE == selectionStatusType.Permanent && SelectionMode == selectionFilterType.SubCurve)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	public override void Dispose()
	{
		foreach (Entity curve in _curveList)
		{
			curve.Dispose();
		}
		base.Dispose();
	}

	public bool IsAnySubCurveSelected()
	{
		if (SelectionInfoSubItems.IsAnySelected(SubCurvesSelectionInfo))
		{
			return true;
		}
		return false;
	}

	public void ClearSubCurvesSelectionForAllInstances()
	{
		if (IsAnySubCurveSelected())
		{
			isDirtyForFlattenTree = true;
		}
		SubCurvesSelectionInfo.Clear();
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		bool flag = data.Selected;
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(data.Parents, this, null, SubCurvesSelectionInfo);
		if (selectionInfoSubItems != null)
		{
			float currentLineWidth = data.RenderContext.CurrentLineWidth;
			for (int i = 0; i < SubCurvesSelectionInfo[0].SubItems.Length; i++)
			{
				if (selectionInfoSubItems.SubItems[i].IsFlagSet(data.SelectionStatus))
				{
					if (!flag)
					{
						data.RenderContext.SetLineSize(data.EdgeThickness * data.SelectionLineWeightScaleFactor);
						data.RenderContext.SetColorWireframe(data.WireSelectionColor);
						flag = true;
					}
				}
				else
				{
					if (data.SelectionStatus == selectionStatusType.Temporary)
					{
						continue;
					}
					if (flag)
					{
						data.RenderContext.SetColorWireframe(data.InsideColor);
						data.RenderContext.SetLineSize(data.EdgeThickness);
						flag = false;
					}
				}
				Utility.DrawArrowOnView(data, CurveList[i].EndTangent, CurveList[i].EndPoint);
			}
			data.RenderContext.SetLineSize(currentLineWidth);
			return;
		}
		foreach (ICurve curve in CurveList)
		{
			Utility.DrawArrowOnView(data, curve.EndTangent, curve.EndPoint);
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		CompileWire(data);
		foreach (Entity curve in CurveList)
		{
			curve.Compile(data);
		}
		RegenMode = regenType.NotNeeded;
	}

	protected internal override void Draw(DrawParams data)
	{
		if (!data.ForceGray && !data.ParentSelected && data.Selected && SelectionMode != selectionFilterType.Entity)
		{
			_0023_003DzojcD8G_L_0024Y6IGX_9Mu2wbKw_003D(data);
		}
		else
		{
			DrawWire(data);
		}
	}

	private void _0023_003DzojcD8G_L_0024Y6IGX_9Mu2wbKw_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		bool flag = _0023_003DzELu0Pss_003D.Selected;
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(_0023_003DzELu0Pss_003D.Parents, this, null, SubCurvesSelectionInfo);
		if (selectionInfoSubItems != null)
		{
			float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
			for (int i = 0; i < _curveList.Count; i++)
			{
				if (selectionInfoSubItems.SubItems[i].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus))
				{
					if (!flag)
					{
						_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness * _0023_003DzELu0Pss_003D.SelectionLineWeightScaleFactor);
						_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.WireSelectionColor);
						flag = true;
					}
				}
				else
				{
					if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary || _0023_003DzELu0Pss_003D.IsDrawingForHalo)
					{
						continue;
					}
					if (flag)
					{
						_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.InsideColor);
						_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness);
						flag = false;
					}
				}
				((Entity)_curveList[i]).Draw(_0023_003DzELu0Pss_003D);
			}
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth);
		}
		else
		{
			if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary)
			{
				return;
			}
			Entity.SetEntityColorForSelection(_0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness);
			foreach (Entity curve in _curveList)
			{
				curve.Draw(_0023_003DzELu0Pss_003D);
			}
		}
	}

	protected internal override void DrawForSelectionSubCurves(DrawForSelectionParams data)
	{
		if (data.RenderContext.IsDirect3D)
		{
			_0023_003DznU_vrwh_jW03IxtLGKgIJA8caBCM(data);
			_0023_003DzSG0c9m_Nz7IW_00242dbPxVvixU_003D(data);
			_0023_003DzFftHeIHwHl5t9Ibv3Ydy5uzLs2hj(data);
		}
		else
		{
			_0023_003DzSG0c9m_Nz7IW_00242dbPxVvixU_003D(data);
		}
	}

	private void _0023_003DznU_vrwh_jW03IxtLGKgIJA8caBCM(DrawForSelectionParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzELu0Pss_003D.RenderContext.PushShader();
		_0023_003DzELu0Pss_003D.RenderContext.EnableThickLines();
	}

	private void _0023_003DzFftHeIHwHl5t9Ibv3Ydy5uzLs2hj(DrawForSelectionParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzELu0Pss_003D.RenderContext.PopShader();
	}

	private void _0023_003DzSG0c9m_Nz7IW_00242dbPxVvixU_003D(DrawForSelectionParams _0023_003DzELu0Pss_003D)
	{
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity obj = (Entity)_curveList[i];
			_0023_003DzELu0Pss_003D.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedSubCurve>(_0023_003DzELu0Pss_003D, this, i);
			obj.Draw(_0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.FalseColorIndex++;
		}
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[CurveList.Count];
		for (int i = 0; i < CurveList.Count; i++)
		{
			array[i] = ((Entity)CurveList[i])._0023_003DzuAMveDQA6vvk()[0];
		}
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003Dzz6JIJ4xNe1_0024dIMT88uFZydqQ_0024upBYSTqB05jKFc_003D(array, ColorMethod == colorMethodType.byEntity, LayerName, Color, _0023_003Dz_KjZG5vEM9v9: false)
		};
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D[] array = new _0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D[CurveList.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new _0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D(((Entity)CurveList[i])._0023_003DzAKDLnmImamFN(_0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ, _0023_003DzsAi4oSk_003D)[0]);
		}
		_0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D2 = new _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D(new List<_0023_003Dz0PtOsx4SvG1pVHiJnQ_003D_003D>(array), _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D: false);
		_0023_003DzYe_6EnQecc8d(_0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzNZxQKnVfs5Wq6nrJpw_003D_003D2 };
	}
}
