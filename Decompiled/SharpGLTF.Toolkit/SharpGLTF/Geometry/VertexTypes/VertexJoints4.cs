using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry.VertexTypes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexJoints4 : IVertexSkinning, IVertexReflection, IEquatable<VertexJoints4>
{
	public Vector4 Joints;

	public Vector4 Weights;

	public readonly int MaxBindings => 4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.JointsLow => Joints;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.JointsHigh => Vector4.Zero;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.WeightsLow => Weights;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.WeightsHigh => Vector4.Zero;

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexJoints4(int jointIndex)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		Joints = new Vector4((float)jointIndex, 0f, 0f, 0f);
		Weights = Vector4.UnitX;
	}

	public VertexJoints4(params (int JointIndex, float Weight)[] bindings)
	{
		this = new VertexJoints4(SparseWeight8.Create(bindings));
	}

	public VertexJoints4(in SparseWeight8 weights)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		SparseWeight8 sparseWeight = SparseWeight8.OrderedByWeight(in weights);
		Joints = new Vector4((float)sparseWeight.Index0, (float)sparseWeight.Index1, (float)sparseWeight.Index2, (float)sparseWeight.Index3);
		Weights = new Vector4(sparseWeight.Weight0, sparseWeight.Weight1, sparseWeight.Weight2, sparseWeight.Weight3);
		float num = Vector4.Dot(Weights, Vector4.One);
		if (num != 0f && num != 1f)
		{
			Weights /= num;
		}
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("JOINTS_0", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_SHORT, nrm: false));
		yield return new KeyValuePair<string, AttributeFormat>("WEIGHTS_0", new AttributeFormat(DimensionType.VEC4));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Joints/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexJoints4 b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexJoints4 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexJoints4 a, in VertexJoints4 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexJoints4 a, in VertexJoints4 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexJoints4 a, in VertexJoints4 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (a.Joints == b.Joints)
		{
			return a.Weights == b.Weights;
		}
		return false;
	}

	public readonly SparseWeight8 GetBindings()
	{
		return SparseWeight8.Create(in Joints, in Weights);
	}

	public void SetBindings(in SparseWeight8 bindings)
	{
		this = new VertexJoints4(in bindings);
	}

	public void SetBindings(params (int Index, float Weight)[] bindings)
	{
		this = new VertexJoints4(bindings);
	}

	public readonly (int Index, float Weight) GetBinding(int index)
	{
		return index switch
		{
			0 => (Index: (int)Joints.X, Weight: Weights.X), 
			1 => (Index: (int)Joints.Y, Weight: Weights.Y), 
			2 => (Index: (int)Joints.Z, Weight: Weights.Z), 
			3 => (Index: (int)Joints.W, Weight: Weights.W), 
			_ => throw new ArgumentOutOfRangeException("index"), 
		};
	}

	void IVertexSkinning.SetBindings(in SparseWeight8 bindings)
	{
		SetBindings(in bindings);
	}
}
