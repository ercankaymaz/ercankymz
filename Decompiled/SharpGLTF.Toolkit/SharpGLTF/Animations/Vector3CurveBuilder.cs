using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Diagnostics;

namespace SharpGLTF.Animations;

[DebuggerTypeProxy(typeof(_CurveBuilderDebugProxyVector3))]
internal sealed class Vector3CurveBuilder : CurveBuilder<Vector3>, ICurveSampler<Vector3>
{
	public Vector3CurveBuilder()
	{
	}

	private Vector3CurveBuilder(Vector3CurveBuilder other)
		: base((CurveBuilder<Vector3>)other)
	{
	}

	public override CurveBuilder<Vector3> Clone()
	{
		return new Vector3CurveBuilder(this);
	}

	protected override bool AreEqual(Vector3 left, Vector3 right)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return left == right;
	}

	protected override Vector3 CloneValue(Vector3 value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return value;
	}

	protected override Vector3 CreateValue(IReadOnlyList<float> values)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(values, "values");
		SharpGLTF.Guard.IsTrue(values.Count == 3, "values");
		return new Vector3(values[0], values[1], values[2]);
	}

	protected override Vector3 GetTangent(Vector3 fromValue, Vector3 toValue)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return CurveSampler.CreateTangent(fromValue, toValue);
	}

	public override Vector3 GetPoint(float offset)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		(_CurveNode<Vector3>, _CurveNode<Vector3>, float) tuple = FindSample(offset);
		return (Vector3)(tuple.Item1.Degree switch
		{
			0 => tuple.Item1.Point, 
			1 => Vector3.Lerp(tuple.Item1.Point, tuple.Item2.Point, tuple.Item3), 
			3 => CurveSampler.InterpolateCubic(tuple.Item1.Point, tuple.Item1.OutgoingTangent, tuple.Item2.Point, tuple.Item2.IncomingTangent, tuple.Item3), 
			_ => throw new NotSupportedException(), 
		});
	}
}
