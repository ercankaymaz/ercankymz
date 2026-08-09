using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ExplodeEventVar : buSerilization
{
	public bool PolylineToLine = true;

	public bool CircleToArc = false;

	public bool CircleToPolyline = true;

	public bool ArcToPolyline = true;

	public bool EllipseToPolyline = true;

	public bool ArcEllipseToPolyline = true;

	public bool CurveToPolyline = true;

	public bool CurveToControlPoints = false;

	public bool UnGroup = true;

	public bool CompositeCurveToEntity = false;

	public bool BlockReferanceToEntity = false;

	public static List<string> Captions = new List<string>();

	public ExplodeEventVar()
	{
	}

	public ExplodeEventVar(ExplodeEventVar data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
