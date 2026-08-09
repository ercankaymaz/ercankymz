using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexPosition : IVertexGeometry, IVertexReflection, IEquatable<VertexPosition>
{
	public Vector3 Position;

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexPosition(in Vector3 position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Position = position;
	}

	public VertexPosition(float px, float py, float pz)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		Position = new Vector3(px, py, pz);
	}

	public VertexPosition(IVertexGeometry src)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		Position = src.GetPosition();
	}

	public static implicit operator VertexPosition(in Vector3 position)
	{
		return new VertexPosition(in position);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("POSITION", new AttributeFormat(DimensionType.VEC3));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Position/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexPosition b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexPosition other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexPosition a, in VertexPosition b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexPosition a, in VertexPosition b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexPosition a, in VertexPosition b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return a.Position == b.Position;
	}

	void IVertexGeometry.SetPosition(in Vector3 position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Position = position;
	}

	readonly void IVertexGeometry.SetNormal(in Vector3 normal)
	{
	}

	readonly void IVertexGeometry.SetTangent(in Vector4 tangent)
	{
	}

	public readonly VertexGeometryDelta Subtract(IVertexGeometry baseValue)
	{
		return new VertexGeometryDelta((VertexPosition)(object)baseValue, this);
	}

	public void Add(in VertexGeometryDelta delta)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Position += delta.PositionDelta;
	}

	public readonly Vector3 GetPosition()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return Position;
	}

	public readonly bool TryGetNormal(out Vector3 normal)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		normal = default(Vector3);
		return false;
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
		Position = Vector3.Transform(Position, xform);
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
