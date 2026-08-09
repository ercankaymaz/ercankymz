using System.Collections.Generic;

namespace buClass;

public class ePicture : ePlaneEntities
{
	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public string PicturePath = "";

	public ePicture()
	{
	}

	public ePicture(Pnt3D Start, Pnt3D End, string Name)
	{
		StartPoint = new Pnt3D(Start);
		EndPoint = new Pnt3D(End);
		PicturePath = Name;
		Plane = new WorkPlane();
		Update();
	}

	public ePicture(Pnt3D Start, Pnt3D End, string Name, WorkPlane Plane_)
	{
		StartPoint = new Pnt3D(Start);
		EndPoint = new Pnt3D(End);
		PicturePath = Name;
		Plane = Plane_;
		Update();
	}

	public ePicture(eEntities Ent)
	{
		if (Ent.GetType() == typeof(ePicture))
		{
			PicturePath = ((ePicture)Ent).PicturePath;
			Plane = WorkPlane.Copy(((ePicture)Ent).Plane);
			StartPoint = Pnt3D.Copy(((ePicture)Ent).StartPoint);
			EndPoint = Pnt3D.Copy(((ePicture)Ent).EndPoint);
			eEntities.CopyBase(Ent, this);
			Update();
		}
	}

	public static eEntities DecodePicture(List<string> Codes)
	{
		ePicture ePicture2 = new ePicture();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, ePicture2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = ePicture2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		ePicture2.Update();
		return ePicture2;
	}

	public override string ToString()
	{
		return "ePicture - SP : " + StartPoint.ToString(3) + " - EP : " + EndPoint.ToString(3);
	}
}
