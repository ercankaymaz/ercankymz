using System.Numerics;
using SharpGLTF.Animations;

namespace SharpGLTF.Diagnostics;

internal sealed class _CurveBuilderDebugProxyQuaternion : _CurveBuilderDebugProxy<Quaternion>
{
	public _CurveBuilderDebugProxyQuaternion(CurveBuilder<Quaternion> curve)
		: base(curve)
	{
	}

	protected override Quaternion GetTangent(Quaternion a, Quaternion b)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return CurveSampler.CreateTangent(a, b);
	}
}
