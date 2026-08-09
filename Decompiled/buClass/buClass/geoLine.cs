using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoLine : geoEntity
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public geoLine()
	{
	}

	public geoLine(geoLine Line)
	{
		StartPoint = new Pnt3D(Line.StartPoint);
		EndPoint = new Pnt3D(Line.EndPoint);
		Layer = Line.Layer;
		Mode = Line.Mode;
		ToolNo = Line.ToolNo;
		Tag = Line.Tag;
		Color = Line.Color;
		Thickness = Line.Thickness;
		Index = Line.Index;
		Direction = Line.Direction;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
		TypeDefination = Line.TypeDefination;
		isText = Line.isText;
	}

	public geoLine(double X1, double Y1, double X2, double Y2)
	{
		Pnt3D pnt3D = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = 0.0
		};
		StartPoint = pnt3D;
		pnt3D.X = X2;
		pnt3D.Y = Y2;
		pnt3D.Z = 0.0;
		EndPoint = pnt3D;
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
	}

	public geoLine(double X1, double Y1, double Z1, double X2, double Y2, double Z2)
	{
		Pnt3D pnt3D = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = Z1
		};
		StartPoint = pnt3D;
		pnt3D.X = X2;
		pnt3D.Y = Y2;
		pnt3D.Z = Z2;
		EndPoint = pnt3D;
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
	}

	public geoLine(Pnt3D First, Pnt3D Second)
	{
		StartPoint = new Pnt3D(First);
		EndPoint = new Pnt3D(Second);
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
	}

	public geoLine(Pnt3D First, Pnt3D Second, Color color, double thickness)
	{
		StartPoint = new Pnt3D(First);
		EndPoint = new Pnt3D(Second);
		Color = color;
		Thickness = thickness;
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
	}

	public geoLine(Pnt3D First, Pnt3D Second, Color color)
	{
		StartPoint = new Pnt3D(First);
		EndPoint = new Pnt3D(Second);
		Color = color;
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
	}

	public geoLine(PointF First, PointF Second)
	{
		Pnt3D pnt3D = new Pnt3D
		{
			X = First.X,
			Y = First.Y,
			Z = 0.0
		};
		StartPoint = pnt3D;
		pnt3D.X = Second.X;
		pnt3D.Y = Second.Y;
		pnt3D.Z = 0.0;
		EndPoint = pnt3D;
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
	}

	public geoLine(Pnt3D First, Pnt3D Second, int layer)
	{
		StartPoint = new Pnt3D(First);
		EndPoint = new Pnt3D(Second);
		Layer = layer;
		Vertice.Add(new Pnt3D(StartPoint));
		Vertice.Add(new Pnt3D(EndPoint));
	}

	public override string ToString()
	{
		return "[X:" + StartPoint.X.ToString("f3") + " Y:" + StartPoint.Y.ToString("f3") + " Z:" + StartPoint.Z.ToString("f3") + "] ; [X:" + EndPoint.X.ToString("f3") + " Y:" + EndPoint.Y.ToString("f3") + " Z:" + EndPoint.Z.ToString("f3") + "]";
	}
}
