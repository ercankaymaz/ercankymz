using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

internal interface IEntityInternal : IEntity
{
	void DrawSilhouettes(DrawSilhouettesParams data);

	void Render(RenderParams data);

	void RenderFast(RenderParams data);

	void DrawForShadow(RenderParams data);

	void DrawFast(DrawParams data);

	void Draw(DrawParams data);

	void DrawEdges(DrawParams data);

	void DrawIsocurves(DrawParams data);

	void DrawHiddenLines(DrawParams data);

	void DrawFlat(DrawParams data);

	void DrawWireframe(DrawParams data);

	void DrawNormals(DrawParams data);

	void DrawSelected(DrawParams data);

	void DrawFlatSelected(DrawParams drawParams);

	void DrawWireframeSelected(DrawParams data);

	void DrawVertices(DrawParams drawParams);

	void SetShader(DrawParams data);

	void DrawForDepthPass(DrawParams data);

	void DrawForSelection(DrawForSelectionParams data);

	bool IsCrossing(FrustumParams data);

	bool AllVerticesInFrustum(FrustumParams data);

	bool IsCrossingScreenPolygon(ScreenPolygonParams data);

	bool AllVerticesInScreenPolygon(ScreenPolygonParams data);

	void Animate(int frameNumber);

	bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax);
}
