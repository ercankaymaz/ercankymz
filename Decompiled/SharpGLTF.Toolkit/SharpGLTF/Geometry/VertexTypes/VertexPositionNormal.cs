using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexPositionNormal : IVertexGeometry, IVertexReflection, IEquatable<VertexPositionNormal>
{
	public Vector3 Position;

	public Vector3 Normal;

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexPositionNormal(in Vector3 p, in Vector3 n)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		Position = p;
		Normal = n;
	}

	public VertexPositionNormal(float px, float py, float pz, float nx, float ny, float nz)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Position = new Vector3(px, py, pz);
		Normal = new Vector3(nx, ny, nz);
	}

	public VertexPositionNormal(IVertexGeometry src)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		Position = src.GetPosition();
		src.TryGetNormal(out Normal);
	}

	public static implicit operator VertexPositionNormal(in (Vector3 Pos, Vector3 Nrm) tuple)
	{
		return new VertexPositionNormal(in tuple.Pos, in tuple.Nrm);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("POSITION", new AttributeFormat(DimensionType.VEC3));
		yield return new KeyValuePair<string, AttributeFormat>("NORMAL", new AttributeFormat(DimensionType.VEC3));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Position/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexPositionNormal b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexPositionNormal other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexPositionNormal a, in VertexPositionNormal b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexPositionNormal a, in VertexPositionNormal b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexPositionNormal a, in VertexPositionNormal b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (a.Position == b.Position)
		{
			return a.Normal == b.Normal;
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

	readonly void IVertexGeometry.SetTangent(in Vector4 tangent)
	{
	}

	public readonly VertexGeometryDelta Subtract(IVertexGeometry baseValue)
	{
		return new VertexGeometryDelta((VertexPositionNormal)(object)baseValue, this);
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
		Position += delta.PositionDelta;
		Normal += delta.NormalDelta;
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		tangent = default(Vector4);
		return false;
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
		Position = Vector3.Transform(Position, xform);
		Normal = Vector3.Normalize(Vector3.TransformNormal(Normal, xform));
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
