namespace ModuleWorks;

public abstract class BaseReadonlyMeshd
{
	public abstract int TriangleCount { get; }

	public abstract int PointCount { get; }

	public abstract int VertexNormalCount { get; }

	public abstract Unit Units { get; }

	public abstract BoundingBoxd BoundingBox { get; }

	public PointdCollection Points { get; protected set; }

	public TriangledCollection Triangles { get; protected set; }

	public VertexNormaldCollection VertexNormals { get; protected set; }

	public virtual bool IsReadonly => true;

	public abstract Vectord GetPoint(int index);

	public abstract Triangled GetTriangle(int index);

	public abstract Vectord GetVertexNormal(int index);

	public BaseReadonlyMeshd()
	{
		Points = new PointdCollection(this);
		Triangles = new TriangledCollection(this);
		VertexNormals = new VertexNormaldCollection(this);
	}
}
