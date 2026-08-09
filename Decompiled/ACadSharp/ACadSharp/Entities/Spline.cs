using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfName("SPLINE")]
[DxfSubClass("AcDbSpline")]
public class Spline : Entity
{
	public const short MaxDegree = 10;

	private SplineFlags _flags;

	private SplineFlags1 _flags1;

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 73 })]
	[DxfCollectionCodeValue(new int[] { 10, 20, 30 })]
	public List<XYZ> ControlPoints { get; private set; } = new List<XYZ>();

	[DxfCodeValue(new int[] { 43 })]
	public double ControlPointTolerance { get; set; } = 1E-07;

	[DxfCodeValue(new int[] { 71 })]
	public int Degree { get; set; } = 3;

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ EndTangent { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 74 })]
	[DxfCollectionCodeValue(new int[] { 11, 21, 31 })]
	public List<XYZ> FitPoints { get; private set; } = new List<XYZ>();

	[DxfCodeValue(new int[] { 44 })]
	public double FitTolerance { get; set; } = 1E-10;

	[DxfCodeValue(new int[] { 70 })]
	public SplineFlags Flags
	{
		get
		{
			return _flags;
		}
		set
		{
			_flags = value;
		}
	}

	public SplineFlags1 Flags1
	{
		get
		{
			return _flags1;
		}
		set
		{
			_flags1 = value;
		}
	}

	public bool HasValidKnotCount
	{
		get
		{
			int num = ControlPoints.Count + ((!IsClosed) ? 1 : 2) * Degree + 1;
			return Knots.Count == num;
		}
	}

	public bool IsClosed
	{
		get
		{
			return Flags.HasFlag(SplineFlags.Closed);
		}
		set
		{
			if (value)
			{
				_flags.AddFlag(SplineFlags.Closed);
				_flags1.AddFlag(SplineFlags1.Closed);
			}
			else
			{
				_flags.RemoveFlag(SplineFlags.Closed);
				_flags1.RemoveFlag(SplineFlags1.Closed);
			}
		}
	}

	public bool IsPeriodic
	{
		get
		{
			return Flags.HasFlag(SplineFlags.Periodic);
		}
		set
		{
			if (value)
			{
				_flags.AddFlag(SplineFlags.Periodic);
			}
			else
			{
				_flags.RemoveFlag(SplineFlags.Periodic);
			}
		}
	}

	public KnotParametrization KnotParametrization { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 72 })]
	[DxfCollectionCodeValue(new int[] { 40 })]
	public List<double> Knots { get; private set; } = new List<double>();

	[DxfCodeValue(new int[] { 42 })]
	public double KnotTolerance { get; set; } = 1E-07;

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "SPLINE";

	public override ObjectType ObjectType => ObjectType.SPLINE;

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ StartTangent { get; set; }

	public override string SubclassMarker => "AcDbSpline";

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 41 })]
	public List<double> Weights { get; private set; } = new List<double>();

	public override void ApplyTransform(Transform transform)
	{
		Normal = transformNormal(transform, Normal);
		StartTangent = transform.ApplyTransform(StartTangent);
		EndTangent = transform.ApplyTransform(EndTangent);
		for (int i = 0; i < ControlPoints.Count; i++)
		{
			ControlPoints[i] = transform.ApplyTransform(ControlPoints[i]);
		}
		for (int j = 0; j < FitPoints.Count; j++)
		{
			FitPoints[j] = transform.ApplyTransform(FitPoints[j]);
		}
	}

	public override CadObject Clone()
	{
		Spline obj = (Spline)base.Clone();
		obj.ControlPoints = new List<XYZ>(ControlPoints);
		obj.FitPoints = new List<XYZ>(FitPoints);
		obj.Weights = new List<double>(Weights);
		obj.Knots = new List<double>(Knots);
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		if (!TryPolygonalVertexes(256, out var points))
		{
			points = new List<XYZ>(FitPoints);
		}
		return BoundingBox.FromPoints(points);
	}

	public XYZ PointOnSpline(double t)
	{
		if (t < 0.0 || t > 1.0)
		{
			throw new ArgumentOutOfRangeException("t", t, "The parametric position must be a value between 0 and 1.");
		}
		if (t == 1.0)
		{
			t -= double.Epsilon;
		}
		prepare(out var controlPts, out var weights, out var knots);
		getStartAndEndKnots(knots, out var uStart, out var uEnd);
		double num = (uEnd - uStart) * t;
		double u = uStart + num;
		return c(controlPts, weights, knots, Degree, u);
	}

	public List<XYZ> PolygonalVertexes(int precision)
	{
		if (precision < 2)
		{
			throw new ArgumentOutOfRangeException("precision", precision, "The precision must be equal or greater than two.");
		}
		List<XYZ> list = new List<XYZ>();
		prepare(out var controlPts, out var weights, out var knots);
		getStartAndEndKnots(knots, out var uStart, out var uEnd);
		if (!IsClosed && !IsPeriodic)
		{
			precision--;
		}
		double num = (uEnd - uStart) / (double)precision;
		for (int i = 0; i < precision; i++)
		{
			double u = uStart + num * (double)i;
			list.Add(c(controlPts, weights, knots, Degree, u));
		}
		if (!IsClosed && !IsPeriodic)
		{
			list.Add(controlPts[controlPts.Length - 1]);
		}
		return list;
	}

	public bool TryPointOnSpline(double t, out XYZ point)
	{
		point = XYZ.NaN;
		try
		{
			point = PointOnSpline(t);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool TryPolygonalVertexes(int precision, out List<XYZ> points)
	{
		points = new List<XYZ>();
		try
		{
			points = PolygonalVertexes(precision);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool UpdateFromFitPoints(uint iterationLimit = 255u)
	{
		if (Degree != 3 || FitPoints.Count < 2 || KnotParametrization == KnotParametrization.Custom)
		{
			return false;
		}
		if (FitPoints.Count == 2)
		{
			straightLine();
			return true;
		}
		Knots.Clear();
		ControlPoints.Clear();
		Weights.Clear();
		XYZ[] array = FitPoints.ToArray();
		double[] array2 = generateKnotValues(KnotParametrization, array);
		Knots = addSideKnots(Degree, array2);
		if (StartTangent.IsEqual(XYZ.Zero) || EndTangent.IsEqual(XYZ.Zero))
		{
			take3(array2, reverse: false, out var pt, out var pt2, out var pt3);
			take3(array2, reverse: true, out var pt4, out var pt5, out var pt6);
			double num = 3.0 / (pt2 - pt);
			double num2 = 3.0 / (pt4 - pt5);
			take3(array, reverse: false, out var pt7, out var pt8, out var pt9);
			XYZ xYZ = num * (pt8 - pt7 - 0.5 * (pt9 - pt8));
			take3(array, reverse: true, out pt7, out pt8, out pt9);
			XYZ xYZ2 = num2 * (pt7 - pt8 - 0.5 * (pt8 - pt9));
			double num3 = 1.0 / xYZ.ToEnumerable().Sum((double v) => v * v);
			double num4 = 1.0 / xYZ2.ToEnumerable().Sum((double v) => v * v);
			if (double.IsInfinity(num3) || double.IsInfinity(num4))
			{
				return false;
			}
			double num5 = (pt2 + pt3 - 2.0 * pt) / (pt2 - pt);
			double num6 = (2.0 * pt4 - pt5 - pt6) / (pt4 - pt5);
			double num7 = double.MaxValue;
			double num8 = double.MaxValue;
			XYZ[] array3 = null;
			double[] knots = Knots.ToArray();
			do
			{
				XYZ xYZ3 = xYZ;
				XYZ xYZ4 = xYZ2;
				array3 = computeControlPoints(Degree, knots, array, xYZ, xYZ2);
				take3(array3, reverse: false, out var pt10, out var pt11, out var pt12);
				xYZ = 0.5 * (pt11 - pt10 + (pt12 - pt10) / num5) * num;
				double num9 = num7;
				num7 = num3 * (xYZ - xYZ3).ToEnumerable().Sum((double v) => v * v);
				take3(array3, reverse: true, out pt10, out pt11, out pt12);
				xYZ2 = 0.5 * (pt10 - pt11 + (pt10 - pt12) / num6) * num2;
				double num10 = num8;
				num8 = num4 * (xYZ2 - xYZ4).ToEnumerable().Sum((double v) => v * v);
				if ((num7 >= num9 && num8 >= num10) || --iterationLimit == 0)
				{
					return false;
				}
			}
			while (num7 + num8 > 1E-12);
			ControlPoints.AddRange(array3);
		}
		else
		{
			ControlPoints.AddRange(computeControlPoints(Degree, Knots.ToArray(), array, StartTangent, EndTangent));
		}
		Weights = Enumerable.Repeat(1.0, ControlPoints.Count).ToList();
		return true;
	}

	private static List<double> addSideKnots(int degree, double[] knots)
	{
		List<double> list = new List<double>();
		for (int i = 0; i < degree; i++)
		{
			list.Add(knots[0]);
		}
		list.AddRange(knots);
		double item = list[list.Count - 1];
		for (int j = 0; j < degree; j++)
		{
			list.Add(item);
		}
		return list;
	}

	private static XYZ c(XYZ[] ctrlPoints, double[] weights, double[] knots, int degree, double u)
	{
		XYZ zero = XYZ.Zero;
		double num = 0.0;
		for (int i = 0; i < ctrlPoints.Length; i++)
		{
			double num2 = computeNurb(knots, i, degree, u);
			num += num2 * weights[i];
			zero += weights[i] * num2 * ctrlPoints[i];
		}
		if (Math.Abs(num) < double.Epsilon)
		{
			return XYZ.Zero;
		}
		return 1.0 / num * zero;
	}

	private static XYZ[] computeControlPoints(int degree, double[] knots, IList<XYZ> fitPoints, XYZ startTangent, XYZ endTangent)
	{
		XYZ[] array = new XYZ[fitPoints.Count - 1 + degree];
		array[0] = fitPoints[0];
		array[1] = fitPoints[0] + startTangent * ((knots[4] - knots[3]) / 3.0);
		array[fitPoints.Count + 1] = fitPoints[fitPoints.Count - 1];
		array[fitPoints.Count] = fitPoints[fitPoints.Count - 1] - endTangent * ((knots[fitPoints.Count + 2] - knots[fitPoints.Count + 1]) / 3.0);
		if (fitPoints.Count - 1 > 1)
		{
			double[] array2 = new double[4];
			double[] array3 = new double[fitPoints.Count];
			evaluateBasisFunctions(degree, knots, 4, knots[4], array2);
			double num = array2[1];
			array[2] = (fitPoints[1] - array2[0] * array[1]) / num;
			for (int i = 3; i < fitPoints.Count - 1; i++)
			{
				array3[i] = array2[2] / num;
				evaluateBasisFunctions(degree, knots, i + 2, knots[i + 2], array2);
				num = array2[1] - array2[0] * array3[i];
				array[i] = (fitPoints[i - 1] - array2[0] * array[i - 1]) / num;
			}
			array3[fitPoints.Count - 1] = array2[2] / num;
			evaluateBasisFunctions(degree, knots, fitPoints.Count + 1, knots[fitPoints.Count + 1], array2);
			double num2 = array2[1];
			double num3 = array2[0];
			double num4 = array3[fitPoints.Count - 1];
			array[fitPoints.Count - 1] = (fitPoints[fitPoints.Count - 2] - array2[2] * array[fitPoints.Count] - num3 * array[fitPoints.Count - 2]) / (num2 - num3 * num4);
			if (fitPoints.Count - 1 <= 2)
			{
				array[fitPoints.Count - 1] *= 0.75;
			}
			else
			{
				for (int num5 = fitPoints.Count - 2; num5 >= 2; num5--)
				{
					array[num5] -= array3[num5 + 1] * array[num5 + 1];
				}
			}
		}
		return array;
	}

	private static double computeNurb(double[] knots, int i, int p, double u)
	{
		if (p <= 0)
		{
			if (knots[i] <= u && u < knots[i + 1])
			{
				return 1.0;
			}
			return 0.0;
		}
		double num = 0.0;
		if (!(Math.Abs(knots[i + p] - knots[i]) < double.Epsilon))
		{
			num = (u - knots[i]) / (knots[i + p] - knots[i]);
		}
		double num2 = 0.0;
		if (!(Math.Abs(knots[i + p + 1] - knots[i + 1]) < double.Epsilon))
		{
			num2 = (knots[i + p + 1] - u) / (knots[i + p + 1] - knots[i + 1]);
		}
		return num * computeNurb(knots, i, p - 1, u) + num2 * computeNurb(knots, i + 1, p - 1, u);
	}

	private static double[] createKnotVector(int numControlPoints, int degree, bool isPeriodic)
	{
		double[] array;
		if (!isPeriodic)
		{
			int num = numControlPoints + degree + 1;
			array = new double[num];
			int i;
			for (i = 0; i <= degree; i++)
			{
				array[i] = 0.0;
			}
			for (; i < numControlPoints; i++)
			{
				array[i] = i - degree;
			}
			for (; i < num; i++)
			{
				array[i] = numControlPoints - degree;
			}
		}
		else
		{
			int num = numControlPoints + 2 * degree + 1;
			array = new double[num];
			double num2 = 1.0 / (double)(numControlPoints - degree);
			for (int j = 0; j < num; j++)
			{
				array[j] = (double)(j - degree) * num2;
			}
		}
		return array;
	}

	private static void evaluateBasisFunctions(int degree, double[] knots, int knotIndex, double u, double[] result)
	{
		double[] array = new double[degree + 1];
		double[] array2 = new double[degree + 1];
		result[0] = 1.0;
		for (int i = 0; i < degree; i++)
		{
			array[i] = u - knots[knotIndex - i];
			array2[i] = knots[knotIndex + i + 1] - u;
			double num = 0.0;
			for (int j = 0; j <= i; j++)
			{
				double num2 = result[j] / (array2[j] + array[i - j]);
				result[j] = num + array2[j] * num2;
				num = array[i - j] * num2;
			}
			result[i + 1] = num;
		}
	}

	private static double[] generateKnots(XYZ[] fitPoints, bool applySqrt)
	{
		double[] array = new double[fitPoints.Length];
		double num = 0.0;
		XYZ xYZ = XYZ.NaN;
		for (int i = 0; i < fitPoints.Length; i++)
		{
			XYZ xYZ2 = fitPoints[i];
			if (!xYZ.IsNaN())
			{
				num = ((!applySqrt) ? (num + (xYZ2 - xYZ).GetLength()) : (num + Math.Sqrt((xYZ2 - xYZ).GetLength())));
			}
			array[i] = num;
			xYZ = xYZ2;
		}
		return array;
	}

	private static double[] generateKnotsUniform(int fitPoints)
	{
		double[] array = new double[fitPoints];
		for (int i = 0; i < fitPoints; i++)
		{
			array[i] = i;
		}
		return array;
	}

	private static double[] generateKnotValues(KnotParametrization parametrization, XYZ[] fitPoints)
	{
		return parametrization switch
		{
			KnotParametrization.Chord => generateKnots(fitPoints, applySqrt: false), 
			KnotParametrization.SquareRoot => generateKnots(fitPoints, applySqrt: true), 
			KnotParametrization.Uniform => generateKnotsUniform(fitPoints.Length), 
			_ => Array.Empty<double>(), 
		};
	}

	private static void take3<T>(T[] pts, bool reverse, out T pt1, out T pt2, out T pt3) where T : struct
	{
		if (reverse)
		{
			pt1 = pts[pts.Length - 1];
			pt2 = pts[pts.Length - 2];
			pt3 = pts[pts.Length - 3];
		}
		else
		{
			pt1 = pts[0];
			pt2 = pts[1];
			pt3 = pts[2];
		}
	}

	private void getStartAndEndKnots(double[] knots, out double uStart, out double uEnd)
	{
		if (IsClosed)
		{
			uStart = knots[0];
			uEnd = knots[knots.Length - 1];
		}
		else if (IsPeriodic)
		{
			uStart = knots[Degree];
			uEnd = knots[knots.Length - Degree - 1];
		}
		else
		{
			uStart = knots[0];
			uEnd = knots[knots.Length - 1];
		}
	}

	private void prepare(out XYZ[] controlPts, out double[] weights, out double[] knots)
	{
		XYZ[] array = ControlPoints.ToArray();
		double[] array2 = Weights.ToArray();
		knots = Knots.ToArray();
		int num = array.Length;
		if (num == 0)
		{
			throw new ArgumentException("A spline entity with control points is required.", "c");
		}
		if (array2.Length == 0 || array2.Length != num)
		{
			array2 = Enumerable.Repeat(1.0, ControlPoints.Count).ToArray();
		}
		if (knots.Length == 0 || !HasValidKnotCount)
		{
			knots = createKnotVector(num, Degree, IsPeriodic);
		}
		if (IsPeriodic)
		{
			controlPts = new XYZ[num + Degree];
			weights = new double[num + Degree];
			for (int i = 0; i < Degree; i++)
			{
				int num2 = num - Degree + i;
				controlPts[i] = array[num2];
				weights[i] = array2[num2];
			}
			array.CopyTo(controlPts, Degree);
			array2.CopyTo(weights, Degree);
		}
		else
		{
			controlPts = array;
			weights = array2;
		}
		new List<XYZ>();
		if (IsClosed)
		{
			_ = knots[0];
			_ = knots[knots.Length - 1];
		}
		else if (IsPeriodic)
		{
			_ = knots[Degree];
			_ = knots[knots.Length - Degree - 1];
		}
		else
		{
			_ = knots[0];
			_ = knots[knots.Length - 1];
		}
	}

	private void straightLine()
	{
		XYZ[] array = FitPoints.ToArray();
		Knots.Clear();
		Knots.AddRange(addSideKnots(Degree, generateKnotValues(KnotParametrization, array)));
		ControlPoints.Clear();
		XYZ xYZ = (array[1] - array[0]) / 3.0;
		ControlPoints.Add(array[0]);
		ControlPoints.Add(array[0] + xYZ);
		ControlPoints.Add(array[1] - xYZ);
		ControlPoints.Add(array[1]);
		Weights.Clear();
		Weights.AddRange(new _003C_003Ez__ReadOnlyArray<double>(new double[4] { 1.0, 1.0, 1.0, 1.0 }));
	}
}
