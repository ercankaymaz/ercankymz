using System.Numerics;
using SharpGLTF.Animations;

namespace SharpGLTF.Diagnostics;

internal sealed class _CurveBuilderDebugProxyVector3 : _CurveBuilderDebugProxy<Vector3>
{
	public _CurveBuilderDebugProxyVector3(CurveBuilder<Vector3> curve)
		: base(curve)
	{
	}

	protected override Vector3 GetTangent(Vector3 a, Vector3 b)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return b - a;
	}
}
