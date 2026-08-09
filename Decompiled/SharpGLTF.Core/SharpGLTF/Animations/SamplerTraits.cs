using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Animations;

internal static class SamplerTraits
{
	private sealed class _Scalar : ISamplerTraits<float>
	{
		public float Clone(float value)
		{
			return value;
		}

		public float InterpolateLinear(float left, float right, float amount)
		{
			return left * (1f - amount) + right * amount;
		}

		public float InterpolateCubic(float start, float outgoingTangent, float end, float incomingTangent, float amount)
		{
			return CurveSampler.InterpolateCubic(start, outgoingTangent, end, incomingTangent, amount);
		}
	}

	private sealed class _Vector2 : ISamplerTraits<Vector2>
	{
		public Vector2 Clone(Vector2 value)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return value;
		}

		public Vector2 InterpolateLinear(Vector2 left, Vector2 right, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			return Vector2.Lerp(left, right, amount);
		}

		public Vector2 InterpolateCubic(Vector2 start, Vector2 outgoingTangent, Vector2 end, Vector2 incomingTangent, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return CurveSampler.InterpolateCubic(start, outgoingTangent, end, incomingTangent, amount);
		}
	}

	private sealed class _Vector3 : ISamplerTraits<Vector3>
	{
		public Vector3 Clone(Vector3 value)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return value;
		}

		public Vector3 InterpolateLinear(Vector3 left, Vector3 right, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			return Vector3.Lerp(left, right, amount);
		}

		public Vector3 InterpolateCubic(Vector3 start, Vector3 outgoingTangent, Vector3 end, Vector3 incomingTangent, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return CurveSampler.InterpolateCubic(start, outgoingTangent, end, incomingTangent, amount);
		}
	}

	private sealed class _Vector4 : ISamplerTraits<Vector4>
	{
		public Vector4 Clone(Vector4 value)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return value;
		}

		public Vector4 InterpolateLinear(Vector4 left, Vector4 right, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			return Vector4.Lerp(left, right, amount);
		}

		public Vector4 InterpolateCubic(Vector4 start, Vector4 outgoingTangent, Vector4 end, Vector4 incomingTangent, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return CurveSampler.InterpolateCubic(start, outgoingTangent, end, incomingTangent, amount);
		}
	}

	private sealed class _Quaternion : ISamplerTraits<Quaternion>
	{
		public Quaternion Clone(Quaternion value)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return value;
		}

		public Quaternion InterpolateLinear(Quaternion left, Quaternion right, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			return Quaternion.Slerp(left, right, amount);
		}

		public Quaternion InterpolateCubic(Quaternion start, Quaternion outgoingTangent, Quaternion end, Quaternion incomingTangent, float amount)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return CurveSampler.InterpolateCubic(start, outgoingTangent, end, incomingTangent, amount);
		}
	}

	private sealed class _Array : ISamplerTraits<float[]>
	{
		public float[] Clone(float[] value)
		{
			return (float[])value.Clone();
		}

		public float[] InterpolateLinear(float[] left, float[] right, float amount)
		{
			return CurveSampler.InterpolateLinear(left, right, amount);
		}

		public float[] InterpolateCubic(float[] start, float[] outgoingTangent, float[] end, float[] incomingTangent, float amount)
		{
			return CurveSampler.InterpolateCubic((IReadOnlyList<float>)start, (IReadOnlyList<float>)outgoingTangent, (IReadOnlyList<float>)end, (IReadOnlyList<float>)incomingTangent, amount);
		}
	}

	private sealed class _Segment : ISamplerTraits<ArraySegment<float>>
	{
		public ArraySegment<float> Clone(ArraySegment<float> value)
		{
			return new ArraySegment<float>(Enumerable.ToArray(value));
		}

		public ArraySegment<float> InterpolateLinear(ArraySegment<float> left, ArraySegment<float> right, float amount)
		{
			return new ArraySegment<float>(CurveSampler.InterpolateLinear(left, right, amount));
		}

		public ArraySegment<float> InterpolateCubic(ArraySegment<float> start, ArraySegment<float> outgoingTangent, ArraySegment<float> end, ArraySegment<float> incomingTangent, float amount)
		{
			return new ArraySegment<float>(CurveSampler.InterpolateCubic((IReadOnlyList<float>)start, (IReadOnlyList<float>)outgoingTangent, (IReadOnlyList<float>)end, (IReadOnlyList<float>)incomingTangent, amount));
		}
	}

	private sealed class _Sparse : ISamplerTraits<SparseWeight8>
	{
		public SparseWeight8 Clone(SparseWeight8 value)
		{
			return value;
		}

		public SparseWeight8 InterpolateLinear(SparseWeight8 left, SparseWeight8 right, float amount)
		{
			return SparseWeight8.InterpolateLinear(in left, in right, amount);
		}

		public SparseWeight8 InterpolateCubic(SparseWeight8 start, SparseWeight8 outgoingTangent, SparseWeight8 end, SparseWeight8 incomingTangent, float amount)
		{
			return SparseWeight8.InterpolateCubic(in start, in outgoingTangent, in end, in incomingTangent, amount);
		}
	}

	public static readonly ISamplerTraits<float> Scalar = new _Scalar();

	public static readonly ISamplerTraits<Vector2> Vector2 = new _Vector2();

	public static readonly ISamplerTraits<Vector3> Vector3 = new _Vector3();

	public static readonly ISamplerTraits<Vector4> Vector4 = new _Vector4();

	public static readonly ISamplerTraits<Quaternion> Quaternion = new _Quaternion();

	public static readonly ISamplerTraits<float[]> Array = new _Array();

	public static readonly ISamplerTraits<SparseWeight8> Sparse = new _Sparse();

	public static readonly ISamplerTraits<ArraySegment<float>> Segment = new _Segment();
}
