using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoTriangle : geoEntity
{
	public Pnt3D FirstPoint = new Pnt3D();

	public Pnt3D SecondPoint = new Pnt3D();

	public Pnt3D ThirdPoint = new Pnt3D();

	public geoTriangle()
	{
	}

	public geoTriangle(geoTriangle Tri)
	{
		FirstPoint = new Pnt3D(Tri.FirstPoint);
		SecondPoint = new Pnt3D(Tri.SecondPoint);
		ThirdPoint = new Pnt3D(Tri.ThirdPoint);
		Layer = Tri.Layer;
		Mode = Tri.Mode;
		ToolNo = Tri.ToolNo;
		Tag = Tri.Tag;
		Color = Tri.Color;
		Index = Tri.Index;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
		TypeDefination = Tri.TypeDefination;
		isText = Tri.isText;
	}

	public geoTriangle(double X1, double Y1, double X2, double Y2, double X3, double Y3)
	{
		Pnt3D pnt3D = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = 0.0
		};
		FirstPoint = pnt3D;
		pnt3D.X = X2;
		pnt3D.Y = Y2;
		pnt3D.Z = 0.0;
		SecondPoint = pnt3D;
		pnt3D.X = X3;
		pnt3D.Y = Y3;
		pnt3D.Z = 0.0;
		ThirdPoint = pnt3D;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
	}

	public geoTriangle(double X1, double Y1, double Z1, double X2, double Y2, double Z2, double X3, double Y3, double Z3)
	{
		Pnt3D pnt3D = new Pnt3D
		{
			X = X1,
			Y = Y1,
			Z = Z1
		};
		FirstPoint = pnt3D;
		pnt3D.X = X2;
		pnt3D.Y = Y2;
		pnt3D.Z = Z2;
		SecondPoint = pnt3D;
		pnt3D.X = X3;
		pnt3D.Y = Y3;
		pnt3D.Z = Z3;
		ThirdPoint = pnt3D;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
	}

	public geoTriangle(Pnt3D First, Pnt3D Second, Pnt3D Third)
	{
		FirstPoint = First;
		SecondPoint = Second;
		ThirdPoint = Third;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
	}

	public geoTriangle(Pnt3D First, Pnt3D Second, Pnt3D Third, int layer)
	{
		FirstPoint = First;
		SecondPoint = Second;
		ThirdPoint = Third;
		Layer = layer;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
	}

	public geoTriangle(PointF First, PointF Second, PointF Third)
	{
		Pnt3D pnt3D = new Pnt3D
		{
			X = First.X,
			Y = First.Y,
			Z = 0.0
		};
		FirstPoint = pnt3D;
		pnt3D.X = Second.X;
		pnt3D.Y = Second.Y;
		pnt3D.Z = 0.0;
		SecondPoint = pnt3D;
		pnt3D.X = Third.X;
		pnt3D.Y = Third.Y;
		pnt3D.Z = 0.0;
		ThirdPoint = pnt3D;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
	}

	public override string ToString()
	{
		return "[X:" + FirstPoint.X.ToString("f3") + " Y:" + FirstPoint.Y.ToString("f3") + " Z:" + FirstPoint.Z.ToString("f3") + "] ; [X:" + SecondPoint.X.ToString("f3") + " Y:" + SecondPoint.Y.ToString("f3") + " Z:" + SecondPoint.Z.ToString("f3") + "] ; [X:" + ThirdPoint.X.ToString("f3") + " Y:" + ThirdPoint.Y.ToString("f3") + " Z:" + ThirdPoint.Z.ToString("f3") + "]";
	}
}
