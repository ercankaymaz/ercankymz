namespace ModuleWorks;

public abstract class BaseReadonlyMeshf
{
	public abstract int TriangleCount { get; }

	public abstract int PointCount { get; }

	public abstract int VertexNormalCount { get; }

	public abstract Unit Units { get; }

	public abstract BoundingBoxf BoundingBox { get; }

	public PointfCollection Points { get; protected set; }

	public TrianglefCollection Triangles { get; protected set; }

	public VertexNormalfCollection VertexNormals { get; protected set; }

	public virtual bool IsReadonly => true;

	public abstract Vectorf GetPoint(int index);

	public abstract Trianglef GetTriangle(int index);

	public abstract Vectorf GetVertexNormal(int index);

	public BaseReadonlyMeshf()
	{
		Points = new PointfCollection(this);
		Triangles = new TrianglefCollection(this);
		VertexNormals = new VertexNormalfCollection(this);
	}
}
