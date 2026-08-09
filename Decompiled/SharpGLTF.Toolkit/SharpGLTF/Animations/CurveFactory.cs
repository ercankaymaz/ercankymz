using System;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Animations;

internal static class CurveFactory
{
	public static CurveBuilder<T> CreateCurveBuilder<T>() where T : struct
	{
		if (typeof(T) == typeof(Vector3))
		{
			return new Vector3CurveBuilder() as CurveBuilder<T>;
		}
		if (typeof(T) == typeof(Quaternion))
		{
			return new QuaternionCurveBuilder() as CurveBuilder<T>;
		}
		if (typeof(T) == typeof(SparseWeight8))
		{
			return new SparseCurveBuilder() as CurveBuilder<T>;
		}
		if (typeof(T) == typeof(ArraySegment<float>))
		{
			return new SegmentCurveBuilder() as CurveBuilder<T>;
		}
		throw new InvalidOperationException(typeof(T).Name + " not supported.");
	}

	public static CurveBuilder<T> CreateCurveBuilder<T>(ICurveSampler<T> curve) where T : struct
	{
		if (curve is Vector3CurveBuilder vector3CurveBuilder)
		{
			return vector3CurveBuilder.Clone() as CurveBuilder<T>;
		}
		if (curve is QuaternionCurveBuilder quaternionCurveBuilder)
		{
			return quaternionCurveBuilder.Clone() as CurveBuilder<T>;
		}
		if (curve is SparseCurveBuilder sparseCurveBuilder)
		{
			return sparseCurveBuilder.Clone() as CurveBuilder<T>;
		}
		if (curve is SegmentCurveBuilder segmentCurveBuilder)
		{
			return segmentCurveBuilder.Clone() as CurveBuilder<T>;
		}
		if (typeof(T) == typeof(Vector3))
		{
			Vector3CurveBuilder vector3CurveBuilder2 = new Vector3CurveBuilder();
			vector3CurveBuilder2.SetCurve(curve as ICurveSampler<Vector3>);
			return vector3CurveBuilder2 as CurveBuilder<T>;
		}
		if (typeof(T) == typeof(Quaternion))
		{
			QuaternionCurveBuilder quaternionCurveBuilder2 = new QuaternionCurveBuilder();
			quaternionCurveBuilder2.SetCurve(curve as ICurveSampler<Quaternion>);
			return quaternionCurveBuilder2 as CurveBuilder<T>;
		}
		if (typeof(T) == typeof(ArraySegment<float>))
		{
			SegmentCurveBuilder segmentCurveBuilder2 = new SegmentCurveBuilder();
			segmentCurveBuilder2.SetCurve(curve as ICurveSampler<ArraySegment<float>>);
			return segmentCurveBuilder2 as CurveBuilder<T>;
		}
		if (typeof(T) == typeof(SparseWeight8))
		{
			SparseCurveBuilder sparseCurveBuilder2 = new SparseCurveBuilder();
			sparseCurveBuilder2.SetCurve(curve as ICurveSampler<SparseWeight8>);
			return sparseCurveBuilder2 as CurveBuilder<T>;
		}
		throw new InvalidOperationException(typeof(T).Name + " not supported.");
	}
}
