using System.Collections.Generic;

namespace SharpGLTF.Geometry.VertexTypes;

public interface IVertexCustom : IVertexMaterial, IVertexReflection
{
	IEnumerable<string> CustomAttributes { get; }

	void Validate();

	bool TryGetCustomAttribute(string attributeName, out object value);

	void SetCustomAttribute(string attributeName, object value);
}
