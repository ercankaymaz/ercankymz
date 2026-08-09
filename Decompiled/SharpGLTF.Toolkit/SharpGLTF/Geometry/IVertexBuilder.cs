using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

public interface IVertexBuilder
{
	IVertexGeometry GetGeometry();

	IVertexMaterial GetMaterial();

	IVertexSkinning GetSkinning();

	void SetGeometry(IVertexGeometry geometry);

	void SetMaterial(IVertexMaterial material);

	void SetSkinning(IVertexSkinning skinning);

	IMeshBuilder<TMaterial> CreateCompatibleMesh<TMaterial>(string name = null);
}
