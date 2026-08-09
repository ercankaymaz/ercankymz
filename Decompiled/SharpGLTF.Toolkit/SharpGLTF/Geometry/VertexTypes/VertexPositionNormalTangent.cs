using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexPositionNormalTangent : IVertexGeometry, IVertexReflection, IEquatable<VertexPositionNormalTangent>
{
	public Vector3 Position;

	public Vector3 Normal;

	public Vector4 Tangent;

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexPositionNormalTangent(in Vector3 p, in Vector3 n, in Vector4 t)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		Position = p;
		Normal = n;
		Tangent = t;
	}

	public VertexPositionNormalTangent(IVertexGeometry src)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		Position = src.GetPosition();
		src.TryGetNormal(out Normal);
		src.TryGetTangent(out Tangent);
	}

	public static implicit operator VertexPositionNormalTangent(in (Vector3 Pos, Vector3 Nrm, Vector4 Tgt) tuple)
	{
		return new VertexPositionNormalTangent(in tuple.Pos, in tuple.Nrm, in tuple.Tgt);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("POSITION", new AttributeFormat(DimensionType.VEC3));
		yield return new KeyValuePair<string, AttributeFormat>("NORMAL", new AttributeFormat(DimensionType.VEC3));
		yield return new KeyValuePair<string, AttributeFormat>("TANGENT", new AttributeFormat(DimensionType.VEC4));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Position/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexPositionNormalTangent b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexPositionNormalTangent other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexPositionNormalTangent a, in VertexPositionNormalTangent b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexPositionNormalTangent a, in VertexPositionNormalTangent b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexPositionNormalTangent a, in VertexPositionNormalTangent b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (a.Position == b.Position && a.Normal == b.Normal)
		{
			return a.Tangent == b.Tangent;
		}
		return false;
	}

	void IVertexGeometry.SetPosition(in Vector3 position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Position = position;
	}

	void IVertexGeometry.SetNormal(in Vector3 normal)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Normal = normal;
	}

	void IVertexGeometry.SetTangent(in Vector4 tangent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Tangent = tangent;
	}

	public readonly VertexGeometryDelta Subtract(IVertexGeometry baseValue)
	{
		return new VertexGeometryDelta((VertexPositionNormalTangent)(object)baseValue, this);
	}

	public void Add(in VertexGeometryDelta delta)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		Position += delta.PositionDelta;
		Normal += delta.NormalDelta;
		Tangent += new Vector4(delta.TangentDelta, 0f);
	}

	public readonly Vector3 GetPosition()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return Position;
	}

	public readonly bool TryGetNormal(out Vector3 normal)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		normal = Normal;
		return true;
	}

	public readonly bool TryGetTangent(out Vector4 tangent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		tangent = Tangent;
		return true;
	}

	public void ApplyTransform(in Matrix4x4 xform)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		Position = Vector3.Transform(Position, xform);
		Normal = Vector3.Normalize(Vector3.TransformNormal(Normal, xform));
		Vector3 val = Vector3.Normalize(Vector3.TransformNormal(new Vector3(Tangent.X, Tangent.Y, Tangent.Z), xform));
		Tangent = new Vector4(val, Tangent.W);
	}

	void IVertexGeometry.ApplyTransform(in Matrix4x4 xform)
	{
		ApplyTransform(in xform);
	}

	void IVertexGeometry.Add(in VertexGeometryDelta delta)
	{
		Add(in delta);
	}
}
