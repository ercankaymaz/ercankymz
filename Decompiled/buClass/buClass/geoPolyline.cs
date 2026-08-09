using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class geoPolyline : geoEntity
{
	public geoPolyline()
	{
	}

	public geoPolyline(geoPolyline pline)
	{
		Vertice.Clear();
		for (int i = 0; i <= pline.Vertice.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(pline.Vertice[i]));
		}
		Layer = pline.Layer;
		Mode = pline.Mode;
		ToolNo = pline.ToolNo;
		Tag = pline.Tag;
		Color = pline.Color;
		Index = pline.Index;
		Thickness = pline.Thickness;
		Direction = pline.Direction;
		TypeDefination = pline.TypeDefination;
		isText = pline.isText;
	}

	public geoPolyline(List<Pnt3D> vertice)
	{
		Vertice.Clear();
		for (int i = 0; i <= vertice.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(vertice[i]));
		}
	}

	public geoPolyline(List<Pnt3D> vertice, Color color)
	{
		Vertice.Clear();
		Color = color;
		for (int i = 0; i <= vertice.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(vertice[i]));
		}
	}

	public geoPolyline(List<Pnt3D> vertice, Color color, double thickness)
	{
		Vertice.Clear();
		Color = color;
		Thickness = thickness;
		for (int i = 0; i <= vertice.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(vertice[i]));
		}
	}

	public geoPolyline(List<Pnt3D> vertice, int Layer)
	{
		Vertice.Clear();
		for (int i = 0; i <= vertice.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(vertice[i]));
		}
		base.Layer = Layer;
	}

	public override string ToString()
	{
		if (Vertice.Count == 0)
		{
			return "PLine - Count: " + Vertice.Count;
		}
		return "PLine - Count: " + Vertice.Count + " Start: " + Vertice[0].ToString() + " End: " + Vertice[Vertice.Count - 1].ToString();
	}
}
