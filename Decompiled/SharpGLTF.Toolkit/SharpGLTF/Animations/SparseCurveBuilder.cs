using System;
using System.Collections.Generic;
using System.Diagnostics;
using SharpGLTF.Diagnostics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Animations;

[DebuggerTypeProxy(typeof(_CurveBuilderDebugProxySparse))]
internal sealed class SparseCurveBuilder : CurveBuilder<SparseWeight8>, ICurveSampler<SparseWeight8>
{
	public SparseCurveBuilder()
	{
	}

	private SparseCurveBuilder(SparseCurveBuilder other)
		: base((CurveBuilder<SparseWeight8>)other)
	{
	}

	public override CurveBuilder<SparseWeight8> Clone()
	{
		return new SparseCurveBuilder(this);
	}

	protected override bool AreEqual(SparseWeight8 left, SparseWeight8 right)
	{
		return left.Equals(right);
	}

	protected override SparseWeight8 CloneValue(SparseWeight8 value)
	{
		return value;
	}

	protected override SparseWeight8 CreateValue(IReadOnlyList<float> values)
	{
		return SparseWeight8.Create(values);
	}

	protected override SparseWeight8 GetTangent(SparseWeight8 fromValue, SparseWeight8 toValue)
	{
		return SparseWeight8.Subtract(in toValue, in fromValue);
	}

	public override SparseWeight8 GetPoint(float offset)
	{
		(_CurveNode<SparseWeight8>, _CurveNode<SparseWeight8>, float) tuple = FindSample(offset);
		return tuple.Item1.Degree switch
		{
			0 => tuple.Item1.Point, 
			1 => SparseWeight8.InterpolateLinear(in tuple.Item1.Point, in tuple.Item2.Point, tuple.Item3), 
			3 => SparseWeight8.InterpolateCubic(in tuple.Item1.Point, in tuple.Item1.OutgoingTangent, in tuple.Item2.Point, in tuple.Item2.IncomingTangent, tuple.Item3), 
			_ => throw new NotSupportedException(), 
		};
	}
}
