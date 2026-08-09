using System.Collections.Generic;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Entities;

public class FemMeshSlice : Mesh
{
	public FemMeshSlice(natureType meshNature)
		: base(meshNature)
	{
	}

	public FemMeshSlice(IList<Point3D> vertices, IList<IndexTriangle> triangles)
		: base(vertices, triangles)
	{
	}

	public FemMeshSlice(FemMeshSlice another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
	}

	public override object Clone()
	{
		return new FemMeshSlice(this);
	}

	public override object CloneWithTessellation()
	{
		return new FemMeshSlice(this, RegenMode != regenType.RegenAndCompile);
	}

	protected internal override void Draw(DrawParams data)
	{
		data.RenderContext.PushRasterizerState();
		data.RenderContext.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.None);
		base.Draw(data);
		data.RenderContext.PopRasterizerState();
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		data.RenderContext.PushRasterizerState();
		data.RenderContext.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.None);
		base.DrawFlat(data);
		data.RenderContext.PopRasterizerState();
	}
}
