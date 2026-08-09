using System;

namespace buClass;

[Serializable]
public class LibraryItemCircle : LibraryItem
{
	public double Radius = 0.0;

	public Pnt3D PointCenter = new Pnt3D();

	public LibraryItemCircle()
	{
	}

	public LibraryItemCircle(LibraryItemCircle data)
	{
		PointCenter = new Pnt3D(data.PointCenter);
		Radius = data.Radius;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemCircle(Pnt3D centerpoint, double rad, WorkPlane plane)
	{
		PointCenter = new Pnt3D(centerpoint);
		Radius = rad;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		return "Circle Center :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , R: " + Radius;
	}
}
