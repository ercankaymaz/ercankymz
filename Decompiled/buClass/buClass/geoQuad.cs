using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoQuad : geoEntity
{
	public Pnt3D FirstPoint = new Pnt3D();

	public Pnt3D SecondPoint = new Pnt3D();

	public Pnt3D ThirdPoint = new Pnt3D();

	public Pnt3D FourthPoint = new Pnt3D();

	public geoQuad()
	{
	}

	public geoQuad(geoQuad quad)
	{
		FirstPoint = new Pnt3D(quad.FirstPoint);
		SecondPoint = new Pnt3D(quad.SecondPoint);
		ThirdPoint = new Pnt3D(quad.ThirdPoint);
		FourthPoint = new Pnt3D(quad.FourthPoint);
		Layer = quad.Layer;
		Mode = quad.Mode;
		ToolNo = quad.ToolNo;
		Tag = quad.Tag;
		Color = quad.Color;
		Index = quad.Index;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
		Vertice.Add(new Pnt3D(FourthPoint));
		TypeDefination = quad.TypeDefination;
		isText = quad.isText;
	}

	public geoQuad(double X1, double Y1, double X2, double Y2, double X3, double Y3, double X4, double Y4)
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
		pnt3D.X = X4;
		pnt3D.Y = Y4;
		pnt3D.Z = 0.0;
		FourthPoint = pnt3D;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
		Vertice.Add(new Pnt3D(FourthPoint));
	}

	public geoQuad(double X1, double Y1, double Z1, double X2, double Y2, double Z2, double X3, double Y3, double Z3, double X4, double Y4, double Z4)
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
		pnt3D.X = X4;
		pnt3D.Y = Y4;
		pnt3D.Z = Z4;
		FourthPoint = pnt3D;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
		Vertice.Add(new Pnt3D(FourthPoint));
	}

	public geoQuad(Pnt3D First, Pnt3D Second, Pnt3D Third, Pnt3D Fourth)
	{
		FirstPoint = First;
		SecondPoint = Second;
		ThirdPoint = Third;
		FourthPoint = Fourth;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
		Vertice.Add(new Pnt3D(FourthPoint));
	}

	public geoQuad(Pnt3D First, Pnt3D Second, Pnt3D Third, Pnt3D Fourth, int layer)
	{
		FirstPoint = First;
		SecondPoint = Second;
		ThirdPoint = Third;
		FourthPoint = Fourth;
		Layer = layer;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
		Vertice.Add(new Pnt3D(FourthPoint));
	}

	public geoQuad(PointF First, PointF Second, PointF Third, PointF Fourth)
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
		pnt3D.X = Fourth.X;
		pnt3D.Y = Fourth.Y;
		pnt3D.Z = 0.0;
		FourthPoint = pnt3D;
		Vertice.Clear();
		Vertice.Add(new Pnt3D(FirstPoint));
		Vertice.Add(new Pnt3D(SecondPoint));
		Vertice.Add(new Pnt3D(ThirdPoint));
		Vertice.Add(new Pnt3D(FourthPoint));
	}

	public override string ToString()
	{
		return "(" + FirstPoint.X.ToString("f3") + " , " + FirstPoint.Y.ToString("f3") + " , " + FirstPoint.Z.ToString("f3") + ") - (" + SecondPoint.X.ToString("f3") + " , " + SecondPoint.Y.ToString("f3") + " , " + SecondPoint.Z.ToString("f3") + ") - (" + ThirdPoint.X.ToString("f3") + " , " + ThirdPoint.Y.ToString("f3") + " , " + ThirdPoint.Z.ToString("f3") + ") - (" + FourthPoint.X.ToString("f3") + " , " + FourthPoint.Y.ToString("f3") + " , " + FourthPoint.Z.ToString("f3") + ")";
	}
}
