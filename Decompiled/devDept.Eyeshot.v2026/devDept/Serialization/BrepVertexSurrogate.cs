using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class BrepVertexSurrogate : Point3DSurrogate
{
	public int[] Parents;

	public BrepVertexSurrogate(Brep.Vertex vertex)
		: base(vertex)
	{
	}

	protected override Point2D ConvertToObject()
	{
		Brep.Vertex vertex = new Brep.Vertex(X, Y, Z);
		CopyDataToObject(vertex);
		return vertex;
	}

	protected override void CopyDataToObject(Point2D p)
	{
		(p as Brep.Vertex).Parents = Parents;
		base.CopyDataToObject(p);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		Brep.Vertex vertex = p as Brep.Vertex;
		Parents = vertex.Parents;
		base.CopyDataFromObject(p);
	}
}
