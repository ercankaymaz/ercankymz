using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Diagnostics;

namespace SharpGLTF.Animations;

[DebuggerTypeProxy(typeof(_CurveBuilderDebugProxyQuaternion))]
internal sealed class QuaternionCurveBuilder : CurveBuilder<Quaternion>, ICurveSampler<Quaternion>
{
	public QuaternionCurveBuilder()
	{
	}

	private QuaternionCurveBuilder(QuaternionCurveBuilder other)
		: base((CurveBuilder<Quaternion>)other)
	{
	}

	public override CurveBuilder<Quaternion> Clone()
	{
		return new QuaternionCurveBuilder(this);
	}

	protected override bool AreEqual(Quaternion left, Quaternion right)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return left == right;
	}

	protected override Quaternion CloneValue(Quaternion value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return value;
	}

	protected override Quaternion CreateValue(IReadOnlyList<float> values)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(values, "values");
		SharpGLTF.Guard.IsTrue(values.Count == 4, "values");
		return new Quaternion(values[0], values[1], values[2], values[3]);
	}

	protected override Quaternion GetTangent(Quaternion fromValue, Quaternion toValue)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return CurveSampler.CreateTangent(fromValue, toValue);
	}

	public override Quaternion GetPoint(float offset)
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
		(_CurveNode<Quaternion>, _CurveNode<Quaternion>, float) tuple = FindSample(offset);
		return (Quaternion)(tuple.Item1.Degree switch
		{
			0 => tuple.Item1.Point, 
			1 => Quaternion.Slerp(tuple.Item1.Point, tuple.Item2.Point, tuple.Item3), 
			3 => CurveSampler.InterpolateCubic(tuple.Item1.Point, tuple.Item1.OutgoingTangent, tuple.Item2.Point, tuple.Item2.IncomingTangent, tuple.Item3), 
			_ => throw new NotSupportedException(), 
		});
	}
}
