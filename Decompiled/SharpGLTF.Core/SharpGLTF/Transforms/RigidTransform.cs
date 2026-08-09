using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Transforms;

public class RigidTransform : MorphTransform, IGeometryTransform
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Matrix4x4 _WorldMatrix;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _Visible;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _FlipFaces;

	public bool Visible => _Visible;

	public bool FlipFaces => _FlipFaces;

	public Matrix4x4 WorldMatrix => _WorldMatrix;

	public RigidTransform()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Update(Matrix4x4.Identity);
	}

	public RigidTransform(Matrix4x4 worldMatrix)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		Update(default(SparseWeight8), false);
		Update(worldMatrix);
	}

	public RigidTransform(Matrix4x4 worldMatrix, SparseWeight8 morphWeights, bool useAbsoluteMorphs)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Update(in morphWeights, useAbsoluteMorphs);
		Update(worldMatrix);
	}

	public void Update(Matrix4x4 worldMatrix)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		_WorldMatrix = worldMatrix;
		float num = worldMatrix.M13 * worldMatrix.M21 * worldMatrix.M32 + worldMatrix.M11 * worldMatrix.M22 * worldMatrix.M33 + worldMatrix.M12 * worldMatrix.M23 * worldMatrix.M31 - worldMatrix.M12 * worldMatrix.M21 * worldMatrix.M33 - worldMatrix.M13 * worldMatrix.M22 * worldMatrix.M31 - worldMatrix.M11 * worldMatrix.M23 * worldMatrix.M32;
		_Visible = Math.Abs(num) > float.Epsilon;
		_FlipFaces = num < 0f;
	}

	public Vector3 TransformPosition(Vector3 localPosition, IReadOnlyList<Vector3> positionDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		localPosition = MorphVectors(localPosition, positionDeltas);
		return Vector3.Transform(localPosition, _WorldMatrix);
	}

	public Vector3 TransformNormal(Vector3 localNormal, IReadOnlyList<Vector3> normalDeltas, in SparseWeight8 skinWeights)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		localNormal = MorphVectors(localNormal, normalDeltas);
		return Vector3.Normalize(Vector3.TransformNormal(localNormal, _WorldMatrix));
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
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = MorphVectors(new Vector3(tangent.X, tangent.Y, tangent.Z), tangentDeltas);
		val = Vector3.Normalize(Vector3.TransformNormal(val, _WorldMatrix));
		return new Vector4(val, tangent.W);
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
