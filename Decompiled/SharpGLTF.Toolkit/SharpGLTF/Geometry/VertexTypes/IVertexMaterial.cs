using System.Numerics;

namespace SharpGLTF.Geometry.VertexTypes;

public interface IVertexMaterial : IVertexReflection
{
	int MaxColors { get; }

	int MaxTextCoords { get; }

	Vector4 GetColor(int index);

	Vector2 GetTexCoord(int index);

	void SetColor(int setIndex, Vector4 color);

	void SetTexCoord(int setIndex, Vector2 coord);

	VertexMaterialDelta Subtract(IVertexMaterial baseValue);

	void Add(in VertexMaterialDelta delta);
}
