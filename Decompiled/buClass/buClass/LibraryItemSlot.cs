using System;

namespace buClass;

[Serializable]
public class LibraryItemSlot : LibraryItem
{
	public double Width = 0.0;

	public double Height = 0.0;

	public Pnt3D PointBase = new Pnt3D();

	public LibraryItemSlot()
	{
	}

	public LibraryItemSlot(LibraryItemSlot data)
	{
		PointBase = new Pnt3D(data.PointBase);
		Width = data.Width;
		Height = data.Height;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemSlot(Pnt3D basepoint, double width, double height, double rotation, WorkPlane plane)
	{
		PointBase = new Pnt3D(basepoint);
		Width = width;
		Height = height;
		Rotation = rotation;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		return "Slot :  [X:" + PointBase.X.ToString("f3") + " Y:" + PointBase.Y.ToString("f3") + " Z:" + PointBase.Z.ToString("f3") + "] , W: " + Width + " , H: " + Height;
	}
}
