using SharpGLTF.Animations;
using SharpGLTF.Transforms;

namespace SharpGLTF.Diagnostics;

internal sealed class _CurveBuilderDebugProxySparse : _CurveBuilderDebugProxy<SparseWeight8>
{
	public _CurveBuilderDebugProxySparse(CurveBuilder<SparseWeight8> curve)
		: base(curve)
	{
	}

	protected override SparseWeight8 GetTangent(SparseWeight8 a, SparseWeight8 b)
	{
		return SparseWeight8.Subtract(in b, in a);
	}
}
