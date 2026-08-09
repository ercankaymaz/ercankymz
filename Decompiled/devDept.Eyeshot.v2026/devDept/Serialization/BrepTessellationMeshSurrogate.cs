using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

internal class BrepTessellationMeshSurrogate : EntitySurrogate
{
	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	public float TextureScaleU;

	public float TextureScaleV;

	public float TextureOffsetU;

	public float TextureOffsetV;

	public BrepTessellationMeshSurrogate(Brep.TessellationMesh mex)
		: base(mex)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (!CheckSurrogateData())
		{
			Vertices = new Point3D[0];
			Triangles = new IndexTriangle[0];
		}
		Brep.TessellationMesh tessellationMesh = new Brep.TessellationMesh(Vertices, Triangles);
		CopyDataToObject(tessellationMesh);
		return tessellationMesh;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Brep.TessellationMesh obj = entity as Brep.TessellationMesh;
		obj.TextureScaleU = TextureScaleU;
		obj.TextureScaleV = TextureScaleV;
		obj.TextureOffsetU = TextureOffsetU;
		obj.TextureOffsetV = TextureOffsetV;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Brep.TessellationMesh tessellationMesh = entity as Brep.TessellationMesh;
		Vertices = tessellationMesh.Vertices;
		Triangles = tessellationMesh.Triangles;
		TextureScaleU = tessellationMesh.TextureScaleU;
		TextureScaleV = tessellationMesh.TextureScaleV;
		TextureOffsetU = tessellationMesh.TextureOffsetU;
		TextureOffsetV = tessellationMesh.TextureOffsetV;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (Vertices == null || Vertices.Length == 0)
		{
			WriteLog((logMessage != null) ? logMessage : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669519));
			return false;
		}
		if (Triangles == null || Triangles.Length == 0)
		{
			WriteLog((logMessage != null) ? logMessage : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669441));
			return false;
		}
		return true;
	}
}
