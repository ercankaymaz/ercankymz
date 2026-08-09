using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Animations;

public static class CurveSampler
{
	internal const string StepCurveError = "This is a step curve (MaxDegree = 0), use ToStepCurve(); instead.";

	internal const string LinearCurveError = "This is a linear curve (MaxDegree = 1), use ToLinearCurve(); instead.";

	internal const string SplineCurveError = "This is a spline curve (MaxDegree = 3), use ToSplineCurve(); instead.";

	internal static string CurveError(int maxDegree)
	{
		return maxDegree switch
		{
			0 => "This is a step curve (MaxDegree = 0), use ToStepCurve(); instead.", 
			1 => "This is a linear curve (MaxDegree = 1), use ToLinearCurve(); instead.", 
			3 => "This is a spline curve (MaxDegree = 3), use ToSplineCurve(); instead.", 
			_ => "Invalid curve degree", 
		};
	}

	public static Vector3 CreateTangent(Vector3 fromValue, Vector3 toValue, float scale = 1f)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return (toValue - fromValue) * scale;
	}

	public static Quaternion CreateTangent(Quaternion fromValue, Quaternion toValue, float scale = 1f)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		Quaternion val = Quaternion.Concatenate(toValue, Quaternion.Inverse(fromValue));
		if (scale == 1f)
		{
			return val;
		}
		Vector3 val2 = Vector3.Normalize(new Vector3(val.X, val.Y, val.Z));
		double num = Math.Acos(val.W) * 2.0;
		return Quaternion.CreateFromAxisAngle(val2, scale * (float)num);
	}

	public static float[] CreateTangent(float[] fromValue, float[] toValue, float scale = 1f)
	{
		Guard.NotNull(fromValue, "fromValue");
		Guard.NotNull(toValue, "toValue");
		Guard.IsTrue(fromValue.Length == toValue.Length, "toValue");
		float[] array = new float[fromValue.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (toValue[i] - fromValue[i]) * scale;
		}
		return array;
	}

	public static (float StartPosition, float EndPosition, float StartTangent, float EndTangent) CreateHermitePointWeights(float amount)
	{
		float num = amount * amount;
		float num2 = amount * num;
		float num3 = 3f * num - 2f * num2;
		float item = 1f - num3;
		float num4 = num2 - num;
		float item2 = num4 - num + amount;
		return (StartPosition: item, EndPosition: num3, StartTangent: item2, EndTangent: num4);
	}

	public static (float StartPosition, float EndPosition, float StartTangent, float EndTangent) CreateHermiteTangentWeights(float amount)
	{
		float num = amount * amount;
		float num2 = 6f * num - 6f * amount;
		float item = 0f - num2;
		float item2 = 3f * num - 4f * amount + 1f;
		float item3 = 3f * num - 2f * amount;
		return (StartPosition: num2, EndPosition: item, StartTangent: item2, EndTangent: item3);
	}

	public static (T A, T B, float Amount) FindRangeContainingOffset<T>(this IEnumerable<(float Key, T Value)> sequence, float offset)
	{
		Guard.NotNull(sequence, "sequence");
		sequence = sequence.EnsureList();
		if (!sequence.Any())
		{
			return (A: default(T), B: default(T), Amount: 0f);
		}
		(float, T)? tuple = null;
		(float, T)? tuple2 = null;
		(float, T)? tuple3 = null;
		float item = sequence.First().Key;
		if (offset < item)
		{
			offset = item;
		}
		foreach (var item3 in sequence)
		{
			if (item3.Key == offset)
			{
				tuple = item3;
				continue;
			}
			if (item3.Key > offset)
			{
				(float, T)? tuple4 = tuple;
				if (!tuple4.HasValue)
				{
					tuple = tuple3;
				}
				tuple2 = item3;
				break;
			}
			tuple3 = item3;
		}
		if (!tuple.HasValue && !tuple2.HasValue)
		{
			if (tuple3.HasValue)
			{
				return (A: tuple3.Value.Item2, B: tuple3.Value.Item2, Amount: 0f);
			}
			return (A: default(T), B: default(T), Amount: 0f);
		}
		if (!tuple.HasValue)
		{
			return (A: tuple2.Value.Item2, B: tuple2.Value.Item2, Amount: 0f);
		}
		if (!tuple2.HasValue)
		{
			return (A: tuple.Value.Item2, B: tuple.Value.Item2, Amount: 0f);
		}
		float num = tuple2.Value.Item1 - tuple.Value.Item1;
		float item2 = (offset - tuple.Value.Item1) / num;
		return (A: tuple.Value.Item2, B: tuple2.Value.Item2, Amount: item2);
	}

	public static (float A, float B, float Amount) FindRangeContainingOffset(IEnumerable<float> sequence, float offset)
	{
		Guard.NotNull(sequence, "sequence");
		sequence = sequence.EnsureList();
		if (!sequence.Any())
		{
			return (A: 0f, B: 0f, Amount: 0f);
		}
		float? num = null;
		float? num2 = null;
		float? num3 = null;
		float num4 = sequence.First();
		if (offset < num4)
		{
			offset = num4;
		}
		foreach (float item2 in sequence)
		{
			if (item2 == offset)
			{
				num = item2;
				continue;
			}
			if (item2 > offset)
			{
				float? num5 = num;
				if (!num5.HasValue)
				{
					num = num3;
				}
				num2 = item2;
				break;
			}
			num3 = item2;
		}
		if (!num.HasValue && !num2.HasValue)
		{
			if (num3.HasValue)
			{
				return (A: num3.Value, B: num3.Value, Amount: 0f);
			}
			return (A: 0f, B: 0f, Amount: 0f);
		}
		if (!num.HasValue)
		{
			return (A: num2.Value, B: num2.Value, Amount: 0f);
		}
		if (!num2.HasValue)
		{
			return (A: num.Value, B: num.Value, Amount: 0f);
		}
		float num6 = num2.Value - num.Value;
		float item = (offset - num.Value) / num6;
		return (A: num.Value, B: num2.Value, Amount: item);
	}

	internal static IEnumerable<(float, T)[]> SplitByTime<T>(this IEnumerable<(float Time, T Value)> sequence)
	{
		List<(float, T)> segment = null;
		int time = 0;
		(float Time, T Value) last = default((float, T));
		bool isFirst = true;
		foreach (var item in sequence)
		{
			if (isFirst)
			{
				last = item;
				if (segment == null)
				{
					segment = new List<(float, T)>();
				}
				isFirst = false;
			}
			int t = (int)item.Time;
			if (time > t)
			{
				throw new InvalidOperationException("unexpected data encountered.");
			}
			while (time < t)
			{
				if (segment.Count == 0 && item.Time > last.Time)
				{
					segment.Add(last);
				}
				segment.Add(item);
				yield return segment.ToArray();
				segment.Clear();
				int num = time + 1;
				time = num;
			}
			if (time == t)
			{
				if (segment.Count == 0 && time > (int)last.Time && (float)time < item.Time)
				{
					segment.Add(last);
				}
				segment.Add(item);
			}
			last = item;
		}
		if (segment != null && segment.Count > 0)
		{
			yield return segment.ToArray();
		}
	}

	public static float[] Subtract(IReadOnlyList<float> left, IReadOnlyList<float> right)
	{
		Guard.NotNull(left, "left");
		Guard.NotNull(right, "right");
		Guard.MustBeEqualTo(right.Count, left.Count, "right");
		float[] array = new float[left.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = left[i] - right[i];
		}
		return array;
	}

	public static float[] InterpolateLinear(IReadOnlyList<float> start, IReadOnlyList<float> end, float amount)
	{
		Guard.NotNull(start, "start");
		Guard.NotNull(end, "end");
		float num = 1f - amount;
		float[] array = new float[start.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = start[i] * num + end[i] * amount;
		}
		return array;
	}

	public static float InterpolateCubic(float start, float outgoingTangent, float end, float incomingTangent, float amount)
	{
		(float, float, float, float) tuple = CreateHermitePointWeights(amount);
		return start * tuple.Item1 + end * tuple.Item2 + outgoingTangent * tuple.Item3 + incomingTangent * tuple.Item4;
	}

	public static Vector2 InterpolateCubic(Vector2 start, Vector2 outgoingTangent, Vector2 end, Vector2 incomingTangent, float amount)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		(float, float, float, float) tuple = CreateHermitePointWeights(amount);
		return start * tuple.Item1 + end * tuple.Item2 + outgoingTangent * tuple.Item3 + incomingTangent * tuple.Item4;
	}

	public static Vector3 InterpolateCubic(Vector3 start, Vector3 outgoingTangent, Vector3 end, Vector3 incomingTangent, float amount)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		(float, float, float, float) tuple = CreateHermitePointWeights(amount);
		return start * tuple.Item1 + end * tuple.Item2 + outgoingTangent * tuple.Item3 + incomingTangent * tuple.Item4;
	}

	public static Vector4 InterpolateCubic(Vector4 start, Vector4 outgoingTangent, Vector4 end, Vector4 incomingTangent, float amount)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		(float, float, float, float) tuple = CreateHermitePointWeights(amount);
		return start * tuple.Item1 + end * tuple.Item2 + outgoingTangent * tuple.Item3 + incomingTangent * tuple.Item4;
	}

	public static Quaternion InterpolateCubic(Quaternion start, Quaternion outgoingTangent, Quaternion end, Quaternion incomingTangent, float amount)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		(float, float, float, float) tuple = CreateHermitePointWeights(amount);
		return Quaternion.Normalize(start * tuple.Item1 + end * tuple.Item2 + outgoingTangent * tuple.Item3 + incomingTangent * tuple.Item4);
	}

	public static float[] InterpolateCubic(IReadOnlyList<float> start, IReadOnlyList<float> outgoingTangent, IReadOnlyList<float> end, IReadOnlyList<float> incomingTangent, float amount)
	{
		Guard.NotNull(start, "start");
		Guard.NotNull(outgoingTangent, "outgoingTangent");
		Guard.NotNull(end, "end");
		Guard.NotNull(incomingTangent, "incomingTangent");
		(float, float, float, float) tuple = CreateHermitePointWeights(amount);
		float[] array = new float[start.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = start[i] * tuple.Item1 + end[i] * tuple.Item2 + outgoingTangent[i] * tuple.Item3 + incomingTangent[i] * tuple.Item4;
		}
		return array;
	}

	private static bool _HasZero<T>(this IEnumerable<T> collection)
	{
		if (collection != null)
		{
			return !collection.Any();
		}
		return true;
	}

	private static bool _HasOne<T>(this IEnumerable<T> collection)
	{
		return !collection.Skip(1).Any();
	}

	public static ICurveSampler<float> CreateSampler(this IEnumerable<(float, float)> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<float>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<float> linearSampler = new LinearSampler<float>(collection, SamplerTraits.Scalar);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<float> stepSampler = new StepSampler<float>(collection, SamplerTraits.Scalar);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<Vector2> CreateSampler(this IEnumerable<(float, Vector2)> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Vector2>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<Vector2> linearSampler = new LinearSampler<Vector2>(collection, SamplerTraits.Vector2);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<Vector2> stepSampler = new StepSampler<Vector2>(collection, SamplerTraits.Vector2);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<Vector3> CreateSampler(this IEnumerable<(float, Vector3)> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Vector3>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<Vector3> linearSampler = new LinearSampler<Vector3>(collection, SamplerTraits.Vector3);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<Vector3> stepSampler = new StepSampler<Vector3>(collection, SamplerTraits.Vector3);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<Vector4> CreateSampler(this IEnumerable<(float, Vector4)> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Vector4>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<Vector4> linearSampler = new LinearSampler<Vector4>(collection, SamplerTraits.Vector4);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<Vector4> stepSampler = new StepSampler<Vector4>(collection, SamplerTraits.Vector4);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<Quaternion> CreateSampler(this IEnumerable<(float, Quaternion)> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Quaternion>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<Quaternion> linearSampler = new LinearSampler<Quaternion>(collection, SamplerTraits.Quaternion);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<Quaternion> stepSampler = new StepSampler<Quaternion>(collection, SamplerTraits.Quaternion);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<float[]> CreateSampler(this IEnumerable<(float, float[])> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<float[]>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<float[]> linearSampler = new LinearSampler<float[]>(collection, SamplerTraits.Array);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<float[]> stepSampler = new StepSampler<float[]>(collection, SamplerTraits.Array);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<ArraySegment<float>> CreateSampler(this IEnumerable<(float, ArraySegment<float>)> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<ArraySegment<float>>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<ArraySegment<float>> linearSampler = new LinearSampler<ArraySegment<float>>(collection, SamplerTraits.Segment);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<ArraySegment<float>> stepSampler = new StepSampler<ArraySegment<float>>(collection, SamplerTraits.Segment);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<SparseWeight8> CreateSampler(this IEnumerable<(float, SparseWeight8)> collection, bool isLinear = true, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<SparseWeight8>.Create(collection);
		}
		if (isLinear)
		{
			LinearSampler<SparseWeight8> linearSampler = new LinearSampler<SparseWeight8>(collection, SamplerTraits.Sparse);
			if (!optimize)
			{
				return linearSampler;
			}
			return linearSampler.ToFastSampler();
		}
		StepSampler<SparseWeight8> stepSampler = new StepSampler<SparseWeight8>(collection, SamplerTraits.Sparse);
		if (!optimize)
		{
			return stepSampler;
		}
		return stepSampler.ToFastSampler();
	}

	public static ICurveSampler<float> CreateSampler(this IEnumerable<(float, (float, float, float))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<float>.Create(collection);
		}
		CubicSampler<float> cubicSampler = new CubicSampler<float>(collection, SamplerTraits.Scalar);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}

	public static ICurveSampler<Vector2> CreateSampler(this IEnumerable<(float, (Vector2, Vector2, Vector2))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Vector2>.Create(collection);
		}
		CubicSampler<Vector2> cubicSampler = new CubicSampler<Vector2>(collection, SamplerTraits.Vector2);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}

	public static ICurveSampler<Vector3> CreateSampler(this IEnumerable<(float, (Vector3, Vector3, Vector3))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Vector3>.Create(collection);
		}
		CubicSampler<Vector3> cubicSampler = new CubicSampler<Vector3>(collection, SamplerTraits.Vector3);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}

	public static ICurveSampler<Vector4> CreateSampler(this IEnumerable<(float, (Vector4, Vector4, Vector4))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Vector4>.Create(collection);
		}
		CubicSampler<Vector4> cubicSampler = new CubicSampler<Vector4>(collection, SamplerTraits.Vector4);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}

	public static ICurveSampler<Quaternion> CreateSampler(this IEnumerable<(float, (Quaternion, Quaternion, Quaternion))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<Quaternion>.Create(collection);
		}
		CubicSampler<Quaternion> cubicSampler = new CubicSampler<Quaternion>(collection, SamplerTraits.Quaternion);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}

	public static ICurveSampler<float[]> CreateSampler(this IEnumerable<(float, (float[], float[], float[]))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<float[]>.Create(collection);
		}
		CubicSampler<float[]> cubicSampler = new CubicSampler<float[]>(collection, SamplerTraits.Array);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}

	public static ICurveSampler<ArraySegment<float>> CreateSampler(this IEnumerable<(float, (ArraySegment<float>, ArraySegment<float>, ArraySegment<float>))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<ArraySegment<float>>.Create(collection);
		}
		CubicSampler<ArraySegment<float>> cubicSampler = new CubicSampler<ArraySegment<float>>(collection, SamplerTraits.Segment);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}

	public static ICurveSampler<SparseWeight8> CreateSampler(this IEnumerable<(float, (SparseWeight8, SparseWeight8, SparseWeight8))> collection, bool optimize = false)
	{
		if (collection._HasZero())
		{
			return null;
		}
		if (collection._HasOne())
		{
			return FixedSampler<SparseWeight8>.Create(collection);
		}
		CubicSampler<SparseWeight8> cubicSampler = new CubicSampler<SparseWeight8>(collection, SamplerTraits.Sparse);
		if (!optimize)
		{
			return cubicSampler;
		}
		return cubicSampler.ToFastSampler();
	}
}
