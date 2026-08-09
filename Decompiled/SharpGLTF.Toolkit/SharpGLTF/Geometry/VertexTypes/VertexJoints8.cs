using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry.VertexTypes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexJoints8 : IVertexSkinning, IVertexReflection, IEquatable<VertexJoints8>
{
	public Vector4 Joints0;

	public Vector4 Joints1;

	public Vector4 Weights0;

	public Vector4 Weights1;

	public readonly int MaxBindings => 8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.JointsLow => Joints0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.JointsHigh => Joints1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.WeightsLow => Weights0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	readonly Vector4 IVertexSkinning.WeightsHigh => Weights1;

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexJoints8(int jointIndex)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Joints0 = new Vector4((float)jointIndex, 0f, 0f, 0f);
		Joints1 = Vector4.Zero;
		Weights0 = Vector4.UnitX;
		Weights1 = Vector4.Zero;
	}

	public VertexJoints8(params (int JointIndex, float Weight)[] bindings)
	{
		this = new VertexJoints8(SparseWeight8.Create(bindings));
	}

	public VertexJoints8(in SparseWeight8 weights)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		SparseWeight8 sparseWeight = SparseWeight8.OrderedByWeight(in weights);
		Joints0 = new Vector4((float)sparseWeight.Index0, (float)sparseWeight.Index1, (float)sparseWeight.Index2, (float)sparseWeight.Index3);
		Joints1 = new Vector4((float)sparseWeight.Index4, (float)sparseWeight.Index5, (float)sparseWeight.Index6, (float)sparseWeight.Index7);
		Weights0 = new Vector4(sparseWeight.Weight0, sparseWeight.Weight1, sparseWeight.Weight2, sparseWeight.Weight3);
		Weights1 = new Vector4(sparseWeight.Weight4, sparseWeight.Weight5, sparseWeight.Weight6, sparseWeight.Weight7);
		float num = Vector4.Dot(Weights0, Vector4.One) + Vector4.Dot(Weights1, Vector4.One);
		if (num != 0f && num != 1f)
		{
			Weights0 /= num;
			Weights1 /= num;
		}
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("JOINTS_0", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_SHORT, nrm: false));
		yield return new KeyValuePair<string, AttributeFormat>("JOINTS_1", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_SHORT, nrm: false));
		yield return new KeyValuePair<string, AttributeFormat>("WEIGHTS_0", new AttributeFormat(DimensionType.VEC4));
		yield return new KeyValuePair<string, AttributeFormat>("WEIGHTS_1", new AttributeFormat(DimensionType.VEC4));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Joints0/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexJoints8 b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexJoints8 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexJoints8 a, in VertexJoints8 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexJoints8 a, in VertexJoints8 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexJoints8 a, in VertexJoints8 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (a.Joints0 == b.Joints0 && a.Joints1 == b.Joints1 && a.Weights0 == b.Weights0)
		{
			return a.Weights1 == b.Weights1;
		}
		return false;
	}

	public readonly SparseWeight8 GetBindings()
	{
		return SparseWeight8.CreateUnchecked(in Joints0, in Joints1, in Weights0, in Weights1);
	}

	public void SetBindings(in SparseWeight8 weights)
	{
		this = new VertexJoints8(in weights);
	}

	public void SetBindings(params (int Index, float Weight)[] bindings)
	{
		this = new VertexJoints8(bindings);
	}

	public readonly (int Index, float Weight) GetBinding(int index)
	{
		return index switch
		{
			0 => (Index: (int)Joints0.X, Weight: Weights0.X), 
			1 => (Index: (int)Joints0.Y, Weight: Weights0.Y), 
			2 => (Index: (int)Joints0.Z, Weight: Weights0.Z), 
			3 => (Index: (int)Joints0.W, Weight: Weights0.W), 
			4 => (Index: (int)Joints1.X, Weight: Weights1.X), 
			5 => (Index: (int)Joints1.Y, Weight: Weights1.Y), 
			6 => (Index: (int)Joints1.Z, Weight: Weights1.Z), 
			7 => (Index: (int)Joints1.W, Weight: Weights1.W), 
			_ => throw new ArgumentOutOfRangeException("index"), 
		};
	}

	void IVertexSkinning.SetBindings(in SparseWeight8 bindings)
	{
		SetBindings(in bindings);
	}
}
