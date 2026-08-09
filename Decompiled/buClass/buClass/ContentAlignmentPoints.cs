using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class ContentAlignmentPoints : buSerilization
{
	public Pnt3D TopLeftPoint = new Pnt3D();

	public Pnt3D TopCenterPoint = new Pnt3D();

	public Pnt3D TopRightPoint = new Pnt3D();

	public Pnt3D MiddleLeftPoint = new Pnt3D();

	public Pnt3D MiddleCenterPoint = new Pnt3D();

	public Pnt3D MiddleRightPoint = new Pnt3D();

	public Pnt3D BottomLeftPoint = new Pnt3D();

	public Pnt3D BottomCenterPoint = new Pnt3D();

	public Pnt3D BottomRightPoint = new Pnt3D();

	public static List<string> Captions = new List<string>();

	public ContentAlignmentPoints()
	{
	}

	public ContentAlignmentPoints(ContentAlignmentPoints data)
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

	public override string ToString()
	{
		return "MiddleCenterPoint : " + MiddleCenterPoint.ToString();
	}
}
