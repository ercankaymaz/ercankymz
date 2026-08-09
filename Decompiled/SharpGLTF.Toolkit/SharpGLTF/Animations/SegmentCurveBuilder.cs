using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Diagnostics;

namespace SharpGLTF.Animations;

[DebuggerTypeProxy(typeof(_CurveBuilderDebugProxySparse))]
internal sealed class SegmentCurveBuilder : CurveBuilder<ArraySegment<float>>, ICurveSampler<ArraySegment<float>>
{
	public SegmentCurveBuilder()
	{
	}

	private SegmentCurveBuilder(SegmentCurveBuilder other)
		: base((CurveBuilder<ArraySegment<float>>)other)
	{
	}

	public override CurveBuilder<ArraySegment<float>> Clone()
	{
		return new SegmentCurveBuilder(this);
	}

	protected override bool AreEqual(ArraySegment<float> left, ArraySegment<float> right)
	{
		return MemoryExtensions.AsSpan(left).SequenceEqual(right);
	}

	protected override ArraySegment<float> CloneValue(ArraySegment<float> value)
	{
		SharpGLTF.Guard.IsTrue(value.Count > 0, "value");
		return new ArraySegment<float>(Enumerable.ToArray(value));
	}

	protected override ArraySegment<float> CreateValue(IReadOnlyList<float> values)
	{
		SharpGLTF.Guard.NotNull(values, "values");
		SharpGLTF.Guard.IsTrue(values.Count > 0, "values");
		return new ArraySegment<float>(values.ToArray());
	}

	protected override ArraySegment<float> GetTangent(ArraySegment<float> fromValue, ArraySegment<float> toValue)
	{
		return new ArraySegment<float>(CurveSampler.Subtract(toValue, fromValue));
	}

	public override ArraySegment<float> GetPoint(float offset)
	{
		(_CurveNode<ArraySegment<float>>, _CurveNode<ArraySegment<float>>, float) tuple = FindSample(offset);
		return tuple.Item1.Degree switch
		{
			0 => tuple.Item1.Point, 
			1 => new ArraySegment<float>(CurveSampler.InterpolateLinear(tuple.Item1.Point, tuple.Item2.Point, tuple.Item3)), 
			3 => new ArraySegment<float>(CurveSampler.InterpolateCubic((IReadOnlyList<float>)tuple.Item1.Point, (IReadOnlyList<float>)tuple.Item1.OutgoingTangent, (IReadOnlyList<float>)tuple.Item2.Point, (IReadOnlyList<float>)tuple.Item2.IncomingTangent, tuple.Item3)), 
			_ => throw new NotSupportedException(), 
		};
	}
}
