using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Editor;

public class UClick
{
	public Point2D Position;

	public Point3D Pnt3D;

	public Entity Entity;

	public bool Snapped;

	public UClick(Point2D position, Entity entity = null, bool snapped = false)
	{
		Position = position;
		Entity = entity;
		Snapped = snapped;
	}

	public UClick(Point2D position, Point3D pnt, Entity entity = null, bool snapped = false)
	{
		Position = position;
		Pnt3D = pnt;
		Entity = entity;
		Snapped = snapped;
	}

	public UClick(double x, double y)
	{
		Position = new Point2D(x, y);
		Entity = null;
		Snapped = false;
	}
}
