using System;

namespace buClass;

[Serializable]
public class LibraryItemRectangle : LibraryItem
{
	public double Width = 0.0;

	public double Height = 0.0;

	public Pnt3D PointCenter = new Pnt3D();

	public RectangleDrawMode Mode = RectangleDrawMode.Normal;

	public RectangleType Type = RectangleType.Corner;

	public double Chamfer = 0.0;

	public double Radius = 0.0;

	public LibraryItemRectangle()
	{
	}

	public LibraryItemRectangle(LibraryItemRectangle data)
	{
		PointCenter = new Pnt3D(data.PointCenter);
		Width = data.Width;
		Height = data.Height;
		Rotation = data.Rotation;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemRectangle(Pnt3D centerpoint, double width, double height, double rotation, RectangleDrawMode drawmode, RectangleType type, double chamfer, double radius, WorkPlane plane)
	{
		PointCenter = new Pnt3D(centerpoint);
		Width = width;
		Height = height;
		Rotation = rotation;
		Mode = drawmode;
		Type = type;
		Chamfer = chamfer;
		Radius = radius;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		string result = "";
		if (Mode == RectangleDrawMode.Normal)
		{
			result = "Rect :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , W: " + Width + " , H: " + Height;
		}
		if (Mode == RectangleDrawMode.Round)
		{
			result = "Rect :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , W: " + Width + " , H: " + Height + " , R: " + Radius;
		}
		if (Mode == RectangleDrawMode.Chamfer)
		{
			result = "Rect :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , W: " + Width + " , H: " + Height + " , Dis: " + Chamfer;
		}
		return result;
	}
}
