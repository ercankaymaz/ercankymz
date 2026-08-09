using System;

namespace buClass;

[Serializable]
public class LibraryItemPolygon : LibraryItem
{
	public double Radius = 0.0;

	public int Sides = 5;

	public Pnt3D PointCenter = new Pnt3D();

	public LibraryItemPolygon()
	{
	}

	public LibraryItemPolygon(LibraryItemPolygon data)
	{
		PointCenter = new Pnt3D(data.PointCenter);
		Radius = data.Radius;
		Sides = data.Sides;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemPolygon(Pnt3D centerpoint, double rad, int sides, WorkPlane plane)
	{
		PointCenter = new Pnt3D(centerpoint);
		Radius = rad;
		Sides = sides;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		return "Polygon Center :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , R: " + Radius + " , Sides: " + Sides;
	}
}
