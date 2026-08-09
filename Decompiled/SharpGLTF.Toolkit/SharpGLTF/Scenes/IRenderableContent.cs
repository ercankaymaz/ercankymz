using SharpGLTF.Geometry;
using SharpGLTF.Materials;

namespace SharpGLTF.Scenes;

internal interface IRenderableContent
{
	IMeshBuilder<MaterialBuilder> GetGeometryAsset();
}
