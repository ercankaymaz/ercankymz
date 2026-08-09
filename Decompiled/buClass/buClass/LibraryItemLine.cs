using System;

namespace buClass;

[Serializable]
public class LibraryItemLine : LibraryItem
{
	public double Length = 0.0;

	public double Angle = 0.0;

	public Pnt3D PointStart = new Pnt3D();

	public Pnt3D PointEnd = new Pnt3D();

	public LibraryItemLine()
	{
	}

	public LibraryItemLine(LibraryItemLine data)
	{
		PointStart = new Pnt3D(data.PointStart);
		PointEnd = new Pnt3D(data.PointEnd);
		Length = data.Length;
		Angle = data.Angle;
	}

	public LibraryItemLine(Pnt3D startpoint, Pnt3D endpoint, double length, double angle)
	{
		PointStart = new Pnt3D(startpoint);
		PointEnd = new Pnt3D(endpoint);
		Length = length;
		Angle = angle;
	}

	public override string ToString()
	{
		string text = "";
		return "Line :  [X:" + PointStart.X.ToString("f3") + " Y:" + PointStart.Y.ToString("f3") + " Z:" + PointStart.Z.ToString("f3") + "] -  [X:" + PointEnd.X.ToString("f3") + " Y:" + PointEnd.Y.ToString("f3") + " Z:" + PointEnd.Z.ToString("f3") + "]";
	}
}
