using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Transforms;

public abstract class MorphTransform : IMaterialTransform
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SparseWeight8 _Weights;

	public const int COMPLEMENT_INDEX = 65536;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _AbsoluteMorphTargets;

	public SparseWeight8 MorphWeights => _Weights;

	public bool AbsoluteMorphTargets => _AbsoluteMorphTargets;

	protected MorphTransform()
	{
		Update(default(SparseWeight8));
	}

	protected MorphTransform(SparseWeight8 morphWeights, bool useAbsoluteMorphTargets)
	{
		Update(in morphWeights, useAbsoluteMorphTargets);
	}

	public void Update(in SparseWeight8 morphWeights, bool useAbsoluteMorphTargets = false)
	{
		_AbsoluteMorphTargets = useAbsoluteMorphTargets;
		if (morphWeights.IsWeightless)
		{
			_Weights = SparseWeight8.Create((65536, 1f));
		}
		else
		{
			_Weights = morphWeights.GetNormalizedWithComplement(65536);
		}
	}

	protected Vector2 MorphVectors(Vector2 value, IReadOnlyList<Vector2> morphTargets)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		if (morphTargets == null || morphTargets.Count == 0)
		{
			return value;
		}
		if (_Weights.Index0 == 65536 && _Weights.Weight0 == 1f)
		{
			return value;
		}
		Vector2 val = Vector2.Zero;
		if (_AbsoluteMorphTargets)
		{
			foreach (var nonZeroWeight in _Weights.GetNonZeroWeights())
			{
				int item = nonZeroWeight.Index;
				float item2 = nonZeroWeight.Weight;
				Vector2 val2 = ((item == 65536) ? value : morphTargets[item]);
				val += val2 * item2;
			}
		}
		else
		{
			foreach (var nonZeroWeight2 in _Weights.GetNonZeroWeights())
			{
				int item3 = nonZeroWeight2.Index;
				float item4 = nonZeroWeight2.Weight;
				Vector2 val3 = ((item3 == 65536) ? value : (value + morphTargets[item3]));
				val += val3 * item4;
			}
		}
		return val;
	}

	protected Vector3 MorphVectors(Vector3 value, IReadOnlyList<Vector3> morphTargets)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		if (morphTargets == null || morphTargets.Count == 0)
		{
			return value;
		}
		if (_Weights.Index0 == 65536 && _Weights.Weight0 == 1f)
		{
			return value;
		}
		Vector3 val = Vector3.Zero;
		if (_AbsoluteMorphTargets)
		{
			foreach (var nonZeroWeight in _Weights.GetNonZeroWeights())
			{
				int item = nonZeroWeight.Index;
				float item2 = nonZeroWeight.Weight;
				Vector3 val2 = ((item == 65536) ? value : morphTargets[item]);
				val += val2 * item2;
			}
		}
		else
		{
			foreach (var nonZeroWeight2 in _Weights.GetNonZeroWeights())
			{
				int item3 = nonZeroWeight2.Index;
				float item4 = nonZeroWeight2.Weight;
				Vector3 val3 = ((item3 == 65536) ? value : (value + morphTargets[item3]));
				val += val3 * item4;
			}
		}
		return val;
	}

	protected Vector4 MorphVectors(Vector4 value, IReadOnlyList<Vector4> morphTargets)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		if (morphTargets == null || morphTargets.Count == 0)
		{
			return value;
		}
		if (_Weights.Index0 == 65536 && _Weights.Weight0 == 1f)
		{
			return value;
		}
		Vector4 val = Vector4.Zero;
		if (_AbsoluteMorphTargets)
		{
			foreach (var nonZeroWeight in _Weights.GetNonZeroWeights())
			{
				int item = nonZeroWeight.Index;
				float item2 = nonZeroWeight.Weight;
				Vector4 val2 = ((item == 65536) ? value : morphTargets[item]);
				val += val2 * item2;
			}
		}
		else
		{
			foreach (var nonZeroWeight2 in _Weights.GetNonZeroWeights())
			{
				int item3 = nonZeroWeight2.Index;
				float item4 = nonZeroWeight2.Weight;
				Vector4 val3 = ((item3 == 65536) ? value : (value + morphTargets[item3]));
				val += val3 * item4;
			}
		}
		return val;
	}

	public Vector4 MorphColors(Vector4 color, IReadOnlyList<Vector4> morphTargets)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return MorphVectors(color, morphTargets);
	}

	public Vector2 MorphTexCoord(Vector2 texCoord, IReadOnlyList<Vector2> morphTargets)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return MorphVectors(texCoord, morphTargets);
	}
}
