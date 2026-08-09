using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class EntitiesCopySettings : buSerilization5
{
	public bool AddPoint = false;

	public bool AddDimension = false;

	public bool AddCurve = true;

	public bool AddCircular = true;

	public bool AddEllipse = true;

	public bool AddCompositeCurve = true;

	public bool PolylineToLine = false;

	public bool CompositeCurveToEntities = true;

	public bool CurveToPolyLine = true;

	public bool CircleTo4Arc = true;

	public bool ArcToPoyline = false;

	public bool EllipseToPoyline = false;

	public bool CircleToPoyline = false;

	public double MinLength = 0.01;

	public double RegenDev = 0.05;

	public double PolylineToLineMinLength = 100.0;

	public bool ForcePlaneXY = false;

	public EntitiesCopySettings()
	{
	}

	public EntitiesCopySettings(bool addPoint, bool addDimension, bool addCurve, bool addCircular, bool addCompositeCurve, bool addEllipse, bool compositeCurveToEntities, double regen, double minLen)
	{
		AddPoint = addPoint;
		AddDimension = addDimension;
		AddCurve = addCurve;
		AddCircular = addCircular;
		AddEllipse = addEllipse;
		AddCompositeCurve = addCompositeCurve;
		CompositeCurveToEntities = compositeCurveToEntities;
		RegenDev = regen;
		MinLength = minLen;
	}

	public EntitiesCopySettings(EntitiesCopySettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "AddPoint: " + AddPoint + " , CompositeToEntities: " + CompositeCurveToEntities;
	}
}
