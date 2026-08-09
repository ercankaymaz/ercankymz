using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eBezeir : eCurveEntities
{
	public eBezeir()
	{
	}

	public eBezeir(List<Pnt3D> Points)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		Update();
	}

	public eBezeir(List<Pnt3D> Points, float Thickness, Color EntColor)
	{
		ControlPoints.Clear();
		for (int i = 0; i <= Points.Count - 1; i++)
		{
			ControlPoints.Add(new Pnt3D(Points[i]));
		}
		dispThickness = Thickness;
		dispColor = EntColor;
		Update();
	}

	public eBezeir(eEntities Ent)
	{
		if (Ent.GetType() == typeof(eBezeir))
		{
			for (int i = 0; i <= ((eBezeir)Ent).ControlPoints.Count - 1; i++)
			{
				ControlPoints.Add(new Pnt3D(((eBezeir)Ent).ControlPoints[i]));
			}
			StartPoint = Pnt3D.Copy(((eBezeir)Ent).StartPoint);
			EndPoint = Pnt3D.Copy(((eBezeir)Ent).EndPoint);
			eEntities.CopyBase(Ent, this);
			Update();
		}
	}

	public static eEntities DecodeBezeir(List<string> Codes)
	{
		eBezeir eBezeir2 = new eBezeir();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eBezeir2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eBezeir2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eBezeir2.Update();
		return eBezeir2;
	}

	public override string ToString()
	{
		return "eBezeir - Count : " + ControlPoints.Count;
	}
}
