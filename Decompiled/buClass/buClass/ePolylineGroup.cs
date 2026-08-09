using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class ePolylineGroup : eEntities
{
	public List<List<Pnt3D>> GroupVertices = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> InternalVertices = new List<List<Pnt3D>>();

	public ePolylineGroup()
	{
	}

	public ePolylineGroup(List<List<Pnt3D>> groupVertices)
	{
		GroupVertices.Clear();
		InternalVertices.Clear();
		Pnt3D.Copy(groupVertices, ref GroupVertices);
		Update();
	}

	public ePolylineGroup(List<List<Pnt3D>> groupVertices, List<List<Pnt3D>> internalVertices)
	{
		GroupVertices.Clear();
		InternalVertices.Clear();
		Pnt3D.Copy(groupVertices, ref GroupVertices);
		Pnt3D.Copy(internalVertices, ref InternalVertices);
		Update();
	}

	public ePolylineGroup(float Thickness, Color Color)
	{
		GroupVertices.Clear();
		InternalVertices.Clear();
		dispThickness = Thickness;
		dispColor = Color;
		Update();
	}

	public ePolylineGroup(List<List<Pnt3D>> groupVertices, float Thickness, Color Color)
	{
		GroupVertices.Clear();
		InternalVertices.Clear();
		Pnt3D.Copy(groupVertices, ref GroupVertices);
		dispThickness = Thickness;
		dispColor = Color;
		Update();
	}

	public ePolylineGroup(List<List<Pnt3D>> groupVertices, List<List<Pnt3D>> internalVertices, float Thickness, Color Color)
	{
		GroupVertices.Clear();
		InternalVertices.Clear();
		Pnt3D.Copy(groupVertices, ref GroupVertices);
		Pnt3D.Copy(internalVertices, ref InternalVertices);
		dispThickness = Thickness;
		dispColor = Color;
		Update();
	}

	public ePolylineGroup(eEntities ent)
	{
		if (ent.GetType() == typeof(ePolylineGroup))
		{
			GroupVertices.Clear();
			InternalVertices.Clear();
			Pnt3D.Copy(((ePolylineGroup)ent).GroupVertices, ref GroupVertices);
			Pnt3D.Copy(((ePolylineGroup)ent).InternalVertices, ref InternalVertices);
			eEntities.CopyBase(ent, this);
			Update();
		}
	}

	public static ePolylineGroup DecodePolyline(List<string> Codes)
	{
		ePolylineGroup ePolylineGroup2 = new ePolylineGroup();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, ePolylineGroup2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = ePolylineGroup2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		ePolylineGroup2.Update();
		return ePolylineGroup2;
	}

	public override string ToString()
	{
		return "ePolylineGroup -  Group Count : " + GroupVertices.Count + " InternalCount : " + InternalVertices.Count;
	}
}
