using System.Numerics;

namespace SharpGLTF.Geometry.VertexTypes;

public interface IVertexGeometry : IVertexReflection
{
	Vector3 GetPosition();

	bool TryGetNormal(out Vector3 normal);

	bool TryGetTangent(out Vector4 tangent);

	void SetPosition(in Vector3 position);

	void SetNormal(in Vector3 normal);

	void SetTangent(in Vector4 tangent);

	void ApplyTransform(in Matrix4x4 xform);

	VertexGeometryDelta Subtract(IVertexGeometry baseValue);

	void Add(in VertexGeometryDelta delta);
}
