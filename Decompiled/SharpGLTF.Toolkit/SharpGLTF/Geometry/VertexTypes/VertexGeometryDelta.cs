using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexGeometryDelta : IVertexGeometry, IVertexReflection, IEquatable<VertexGeometryDelta>
{
	public Vector3 PositionDelta;

	public Vector3 NormalDelta;

	public Vector3 TangentDelta;

	private readonly string _GetDebuggerDisplay()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		return $"Δ\ud835\udc0f:{PositionDelta} Δ\ud835\udeb4:{NormalDelta} Δ\ud835\udebb:{TangentDelta}";
	}

	public static implicit operator VertexGeometryDelta(in Vector3 position)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return new VertexGeometryDelta(in position, Vector3.Zero, Vector3.Zero);
	}

	public static implicit operator VertexGeometryDelta(in (Vector3 Pos, Vector3 Nrm) tuple)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		return new VertexGeometryDelta(in tuple.Pos, in tuple.Nrm, Vector3.Zero);
	}

	public static implicit operator VertexGeometryDelta(in (Vector3 Pos, Vector3 Nrm, Vector3 tgt) tuple)
	{
		return new VertexGeometryDelta(in tuple.Pos, in tuple.Nrm, in tuple.tgt);
	}

	public VertexGeometryDelta(IVertexGeometry src)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		PositionDelta = src.GetPosition();
		src.TryGetNormal(out NormalDelta);
		src.TryGetTangent(out var tangent);
		TangentDelta = new Vector3(tangent.X, tangent.Y, tangent.Z);
	}

	public VertexGeometryDelta(in Vector3 p, in Vector3 n, in Vector3 t)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		PositionDelta = p;
		NormalDelta = n;
		TangentDelta = t;
	}

	internal VertexGeometryDelta(in VertexPosition rootVal, in VertexPosition morphVal)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		PositionDelta = morphVal.Position - rootVal.Position;
		NormalDelta = Vector3.Zero;
		TangentDelta = Vector3.Zero;
	}

	internal VertexGeometryDelta(in VertexPositionNormal rootVal, in VertexPositionNormal morphVal)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		PositionDelta = morphVal.Position - rootVal.Position;
		NormalDelta = morphVal.Normal - rootVal.Normal;
		TangentDelta = Vector3.Zero;
	}

	internal VertexGeometryDelta(in VertexPositionNormalTangent rootVal, in VertexPositionNormalTangent morphVal)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		PositionDelta = morphVal.Position - rootVal.Position;
		NormalDelta = morphVal.Normal - rootVal.Normal;
		Vector4 val = morphVal.Tangent - rootVal.Tangent;
		TangentDelta = new Vector3(val.X, val.Y, val.Z);
	}

	internal VertexGeometryDelta(in VertexGeometryDelta rootVal, in VertexGeometryDelta morphVal)
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
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		PositionDelta = morphVal.PositionDelta - rootVal.PositionDelta;
		NormalDelta = morphVal.NormalDelta - rootVal.NormalDelta;
		TangentDelta = morphVal.TangentDelta - rootVal.TangentDelta;
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("POSITIONDELTA", new AttributeFormat(DimensionType.VEC3));
		yield return new KeyValuePair<string, AttributeFormat>("NORMALDELTA", new AttributeFormat(DimensionType.VEC3));
		yield return new KeyValuePair<string, AttributeFormat>("TANGENTDELTA", new AttributeFormat(DimensionType.VEC3));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)PositionDelta/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexGeometryDelta b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexGeometryDelta other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexGeometryDelta a, in VertexGeometryDelta b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexGeometryDelta a, in VertexGeometryDelta b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexGeometryDelta a, in VertexGeometryDelta b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (a.PositionDelta == b.PositionDelta && a.NormalDelta == b.NormalDelta)
		{
			return a.TangentDelta == b.TangentDelta;
		}
		return false;
	}

	void IVertexGeometry.SetPosition(in Vector3 position)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		PositionDelta = position;
	}

	void IVertexGeometry.SetNormal(in Vector3 normal)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		NormalDelta = normal;
	}

	void IVertexGeometry.SetTangent(in Vector4 tangent)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		TangentDelta = new Vector3(tangent.X, tangent.Y, tangent.Z);
	}

	public readonly Vector3 GetPosition()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return PositionDelta;
	}

	public readonly bool TryGetNormal(out Vector3 normal)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		normal = NormalDelta;
		return true;
	}

	public readonly bool TryGetTangent(out Vector4 tangent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		tangent = new Vector4(TangentDelta, 0f);
		return true;
	}

	public void ApplyTransform(in Matrix4x4 xform)
	{
		throw new NotSupportedException();
	}

	public readonly VertexGeometryDelta Subtract(IVertexGeometry baseValue)
	{
		return new VertexGeometryDelta((VertexGeometryDelta)(object)baseValue, this);
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
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		PositionDelta += delta.PositionDelta;
		NormalDelta += delta.NormalDelta;
		TangentDelta += delta.TangentDelta;
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
