using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class BarSurrogate : EntitySurrogate
{
	public Point3D StartPoint;

	public Point3D EndPoint;

	public double Radius;

	public int Slices;

	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	public BarSurrogate(Bar bar)
		: base(bar)
	{
	}

	protected override Entity ConvertToObject()
	{
		Bar bar = new Bar(this);
		CopyDataToObject(bar);
		return bar;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Bar obj = entity as Bar;
		obj.Vertices = Vertices;
		obj.Triangles = Triangles;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Bar bar = entity as Bar;
		StartPoint = bar.StartPoint;
		EndPoint = bar.EndPoint;
		Radius = bar.Radius;
		Slices = bar.Slices;
		Vertices = bar.Vertices;
		Triangles = bar.Triangles;
		base.CopyDataFromObject(entity);
	}
}
