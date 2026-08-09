using System;

namespace buClass;

[Serializable]
public class LibraryItemBarrel : LibraryItem
{
	public Pnt3D HeadPoint = new Pnt3D();

	public double HeadRadius = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public LibraryItemBarrel()
	{
	}

	public LibraryItemBarrel(LibraryItemBarrel data)
	{
		HeadPoint = new Pnt3D(data.HeadPoint);
		HeadRadius = data.HeadRadius;
		Width = data.Width;
		Height = data.Height;
		Rotation = data.Rotation;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemBarrel(Pnt3D headpoint, double headradius, double width, double height, double rotation, WorkPlane plane)
	{
		HeadPoint = new Pnt3D(headpoint);
		HeadRadius = headradius;
		Width = width;
		Height = height;
		Rotation = rotation;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		return "Barrel :  [X:" + HeadPoint.X.ToString("f3") + " Y:" + HeadPoint.Y.ToString("f3") + " Z:" + HeadPoint.Z.ToString("f3") + "] , Head R: " + HeadRadius + " , W: " + Width + " , H: " + Height;
	}
}
