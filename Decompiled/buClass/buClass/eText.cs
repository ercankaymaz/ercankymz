using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class eText : ePlaneEntities
{
	public Pnt3D StartPoint = new Pnt3D();

	public double Height = 0.0;

	public double Angle = 0.0;

	public string TextString = "";

	public Font TextFont = new Font("Arial", 12f);

	public eText()
	{
	}

	public eText(Pnt3D Pnt, string TextString_, double Height_, WorkPlane Plane_)
	{
		StartPoint = new Pnt3D(Pnt);
		TextString = TextString_;
		Height = Height_;
		Plane = Plane_;
		Update();
	}

	public eText(Pnt3D Pnt, string TextString_, double Height_, Color EntColor, WorkPlane Plane_)
	{
		StartPoint = new Pnt3D(Pnt);
		TextString = TextString_;
		Height = Height_;
		dispColor = EntColor;
		Plane = Plane_;
		Update();
	}

	public eText(eEntities Ent)
	{
		if (Ent.GetType() == typeof(eText))
		{
			TextString = ((eText)Ent).TextString;
			Angle = ((eText)Ent).Angle;
			Height = ((eText)Ent).Height;
			Plane = WorkPlane.Copy(((eText)Ent).Plane);
			StartPoint = Pnt3D.Copy(((eText)Ent).StartPoint);
			eEntities.CopyBase(Ent, this);
			Update();
		}
	}

	public static eEntities DecodeText(List<string> Codes)
	{
		eText eText2 = new eText();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eText2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eText2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eText2.Update();
		return eText2;
	}

	public override string ToString()
	{
		return "eText - SP : " + StartPoint.ToString(3) + " - Text : " + TextString + " - Height : " + Height.ToString("f3");
	}
}
