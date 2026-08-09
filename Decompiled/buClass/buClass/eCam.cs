using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eCam : eEntities
{
	public CamMoveType MoveType = CamMoveType.G1;

	public int BaseEntityIndex = -1;

	public eCam()
	{
	}

	public eCam(List<Pnt3D> Vertices)
	{
		Vertice.Clear();
		for (int i = 0; i <= Vertices.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(Vertices[i]));
		}
		Update();
	}

	public eCam(List<Pnt3D> Vertices, float Thickness, Color Color)
	{
		Vertice.Clear();
		for (int i = 0; i <= Vertices.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(Vertices[i]));
		}
		dispThickness = Thickness;
		dispColor = Color;
		Update();
	}

	public eCam(List<Pnt3D> Vertices, float Thickness, Color Color, CamMoveType move)
	{
		Vertice.Clear();
		for (int i = 0; i <= Vertices.Count - 1; i++)
		{
			Vertice.Add(new Pnt3D(Vertices[i]));
		}
		dispThickness = Thickness;
		dispColor = Color;
		MoveType = move;
		Update();
	}

	public eCam(eEntities ent)
	{
		if (ent.GetType() == typeof(eCam))
		{
			Pnt3D.Copy(ent.Vertice, ref Vertice);
			BaseEntityIndex = ((eCam)ent).BaseEntityIndex;
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static eEntities DecodePolyline(List<string> Codes)
	{
		eCam eCam2 = new eCam();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eCam2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eCam2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eCam2.Update();
		return eCam2;
	}

	public override string ToString()
	{
		string text = "";
		if (Vertice.Count > 0)
		{
			text = "SP: " + Vertice[0].ToString(3) + " EP: " + Vertice[Vertice.Count - 1].ToString(3);
		}
		return "eCam - " + text + " Count : " + Vertice.Count;
	}
}
