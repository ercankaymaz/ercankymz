using System;

namespace buClass;

[Serializable]
public class LibraryItemTriangleTwin : LibraryItem
{
	public double Width = 0.0;

	public double Height = 5.0;

	public Pnt3D PointCenter = new Pnt3D();

	public LibraryItemTriangleTwin()
	{
	}

	public LibraryItemTriangleTwin(LibraryItemTriangleTwin data)
	{
		PointCenter = new Pnt3D(data.PointCenter);
		Width = data.Width;
		Height = data.Height;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemTriangleTwin(Pnt3D centerpoint, double width, double height, WorkPlane plane)
	{
		PointCenter = new Pnt3D(centerpoint);
		Width = width;
		Height = height;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		return "Triangle Twin :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , W: " + Width + " , H: " + Height;
	}
}
