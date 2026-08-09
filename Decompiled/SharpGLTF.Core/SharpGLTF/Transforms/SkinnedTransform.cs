using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Transforms;

public class SkinnedTransform : MorphTransform, IGeometryTransform
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Matrix4x4[] _SkinTransforms;

	public bool Visible => true;

	public bool FlipFaces => false;

	public IReadOnlyList<Matrix4x4> SkinMatrices => _SkinTransforms;

	public SkinnedTransform()
	{
	}

	public SkinnedTransform(Matrix4x4[] invBindMatrix, Matrix4x4[] currWorldMatrix, SparseWeight8 morphWeights, bool useAbsoluteMorphTargets)
	{
		Update(in morphWeights, useAbsoluteMorphTargets);
		Update(invBindMatrix, currWorldMatrix);
	}

	public SkinnedTransform(int count, Func<int, Matrix4x4> invBindMatrix, Func<int, Matrix4x4> currWorldMatrix, SparseWeight8 morphWeights, bool useAbsoluteMorphTargets)
	{
		Update(in morphWeights, useAbsoluteMorphTargets);
		Update(count, invBindMatrix, currWorldMatrix);
	}

	public void Update(Matrix4x4[] invBindMatrix, Matrix4x4[] currWorldMatrix)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(invBindMatrix, "invBindMatrix");
		Guard.NotNull(currWorldMatrix, "currWorldMatrix");
		Guard.IsTrue(invBindMatrix.Length == currWorldMatrix.Length, "currWorldMatrix", $"{invBindMatrix} and {currWorldMatrix} length mismatch.");
		if (_SkinTransforms == null || _SkinTransforms.Length != invBindMatrix.Length)
		{
			_SkinTransforms = (Matrix4x4[])(object)new Matrix4x4[invBindMatrix.Length];
		}
		for (int i = 0; i < _SkinTransforms.Length; i++)
		{
			_SkinTransforms[i] = invBindMatrix[i] * currWorldMatrix[i];
		}
	}

	public void Update(int count, Func<int, Matrix4x4> invBindMatrix, Func<int, Matrix4x4> currWorldMatrix)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(invBindMatrix, "invBindMatrix");
		Guard.NotNull(currWorldMatrix, "currWorldMatrix");
		if (_SkinTransforms == null || _SkinTransforms.Length != count)
		{
			_SkinTransforms = (Matrix4x4[])(object)new Matrix4x4[count];
		}
		for (int i = 0; i < _SkinTransforms.Length; i++)
		{
			_SkinTransforms[i] = invBindMatrix(i) * currWorldMatrix(i);
		}
	}

	public Vector3 TransformPosition(Vector3 localPosition, IReadOnlyList<Vector3> positionDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		localPosition = MorphVectors(localPosition, positionDeltas);
		Vector3 val = Vector3.Zero;
		float num = 1f / skinWeights.WeightSum;
		foreach (var nonZeroWeight in skinWeights.GetNonZeroWeights())
		{
			int item = nonZeroWeight.Index;
			float item2 = nonZeroWeight.Weight;
			val += Vector3.Transform(localPosition, _SkinTransforms[item]) * item2 * num;
		}
		return val;
	}

	public Vector3 TransformNormal(Vector3 localNormal, IReadOnlyList<Vector3> normalDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		localNormal = MorphVectors(localNormal, normalDeltas);
		Vector3 val = Vector3.Zero;
		foreach (var nonZeroWeight in skinWeights.GetNonZeroWeights())
		{
			int item = nonZeroWeight.Index;
			float item2 = nonZeroWeight.Weight;
			val += Vector3.TransformNormal(localNormal, _SkinTransforms[item]) * item2;
		}
		return Vector3.Normalize(localNormal);
	}

	public Vector4 TransformTangent(Vector4 tangent, IReadOnlyList<Vector3> tangentDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = MorphVectors(new Vector3(tangent.X, tangent.Y, tangent.Z), tangentDeltas);
		Vector3 val2 = Vector3.Zero;
		foreach (var nonZeroWeight in skinWeights.GetNonZeroWeights())
		{
			int item = nonZeroWeight.Index;
			float item2 = nonZeroWeight.Weight;
			val2 += Vector3.TransformNormal(val, _SkinTransforms[item]) * item2;
		}
		val2 = Vector3.Normalize(val2);
		return new Vector4(val2, tangent.W);
	}

	public static Matrix4x4 CalculateInverseBinding(Matrix4x4 meshWorldTransform, Matrix4x4 jointWorldTransform)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 val = jointWorldTransform.Inverse();
		if (meshWorldTransform == Matrix4x4.Identity)
		{
			return val;
		}
		return meshWorldTransform * val;
	}

	public static Matrix4x4Double CalculateInverseBinding(Matrix4x4Double meshWorldTransform, Matrix4x4Double jointWorldTransform)
	{
		if (!Matrix4x4Double.Invert(jointWorldTransform, out var result))
		{
			Guard.IsTrue(target: false, "jointWorldTransform", "Matrix cannot be inverted.");
		}
		if (jointWorldTransform.M44 == 1.0)
		{
			result.M44 = 1.0;
		}
		if (meshWorldTransform == Matrix4x4Double.Identity)
		{
			return result;
		}
		return meshWorldTransform * result;
	}

	Vector3 IGeometryTransform.TransformPosition(Vector3 localPosition, IReadOnlyList<Vector3> positionDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return TransformPosition(localPosition, positionDeltas, in skinWeights);
	}

	Vector3 IGeometryTransform.TransformNormal(Vector3 localNormal, IReadOnlyList<Vector3> normalDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return TransformNormal(localNormal, normalDeltas, in skinWeights);
	}

	Vector4 IGeometryTransform.TransformTangent(Vector4 tangent, IReadOnlyList<Vector3> tangentDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		return TransformTangent(tangent, tangentDeltas, in skinWeights);
	}
}
