using System;

namespace buClass;

[Serializable]
public class LibraryItemEllipse : LibraryItem
{
	public double MajorRadius = 0.0;

	public double MinorRadius = 0.0;

	public Pnt3D PointCenter = new Pnt3D();

	public LibraryItemEllipse()
	{
	}

	public LibraryItemEllipse(LibraryItemEllipse data)
	{
		PointCenter = new Pnt3D(data.PointCenter);
		MajorRadius = data.MajorRadius;
		MinorRadius = data.MinorRadius;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemEllipse(Pnt3D centerpoint, double majorrad, double minorrad, double rotation, WorkPlane plane)
	{
		PointCenter = new Pnt3D(centerpoint);
		MajorRadius = majorrad;
		MinorRadius = minorrad;
		Rotation = rotation;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		return "Ellipse Center :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , Major R: " + MajorRadius + " , Minor R: " + MinorRadius;
	}
}
