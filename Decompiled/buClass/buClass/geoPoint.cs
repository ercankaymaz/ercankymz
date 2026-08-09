using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoPoint : geoEntity
{
	public Pnt3D StartPoint = new Pnt3D();

	public geoPoint()
	{
	}

	public geoPoint(geoPoint Pnt)
	{
		StartPoint = new Pnt3D(Pnt.StartPoint);
		Layer = Pnt.Layer;
		Mode = Pnt.Mode;
		ToolNo = Pnt.ToolNo;
		Tag = Pnt.Tag;
		Color = Pnt.Color;
		Thickness = Pnt.Thickness;
		Index = Pnt.Index;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(StartPoint));
		TypeDefination = Pnt.TypeDefination;
		isText = Pnt.isText;
	}

	public geoPoint(double X1, double Y1)
	{
		StartPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = 0.0
		};
		Vertice.Add(new Pnt3D(StartPoint));
	}

	public geoPoint(double X1, double Y1, double Z1)
	{
		StartPoint = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = Z1
		};
		Vertice.Add(new Pnt3D(StartPoint));
	}

	public geoPoint(Pnt3D First)
	{
		StartPoint = new Pnt3D(First);
		Vertice.Add(new Pnt3D(StartPoint));
	}

	public geoPoint(Pnt3D First, Color color, double thickness)
	{
		StartPoint = new Pnt3D(First);
		Color = color;
		Vertice.Add(new Pnt3D(StartPoint));
	}

	public geoPoint(Pnt3D First, int layer)
	{
		StartPoint = new Pnt3D(First);
		Layer = layer;
		Vertice.Add(new Pnt3D(StartPoint));
	}

	public geoPoint(PointF First)
	{
		StartPoint = new Pnt3D
		{
			X = First.X,
			Y = First.Y,
			Z = 0.0
		};
		Vertice.Add(new Pnt3D(StartPoint));
	}

	public override string ToString()
	{
		return "[X:" + StartPoint.X.ToString("f3") + " Y:" + StartPoint.Y.ToString("f3") + " Z:" + StartPoint.Z.ToString("f3") + "]";
	}
}
