using System;

namespace buClass;

[Serializable]
public class LibraryItemPoint : LibraryItem
{
	public Pnt3D PointStart = new Pnt3D();

	public LibraryItemPoint()
	{
	}

	public LibraryItemPoint(LibraryItemPoint data)
	{
		PointStart = new Pnt3D(data.PointStart);
	}

	public LibraryItemPoint(Pnt3D startpoint)
	{
		PointStart = new Pnt3D(startpoint);
	}

	public override string ToString()
	{
		string text = "";
		return "Point :  [X:" + PointStart.X.ToString("f3") + " Y:" + PointStart.Y.ToString("f3") + " Z:" + PointStart.Z.ToString("f3") + "]";
	}
}
