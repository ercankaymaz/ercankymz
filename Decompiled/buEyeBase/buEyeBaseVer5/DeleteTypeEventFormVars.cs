using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class DeleteTypeEventFormVars : buSerilization5
{
	public bool PointDelete = false;

	public bool PolylinDelete = false;

	public bool LineDelete = false;

	public bool CircleDelete = false;

	public bool ArcDelete = false;

	public bool EllipseDelete = false;

	public bool EllipseArcDelete = false;

	public bool CompositeCurveDelete = false;

	public bool CurveDelete = false;

	public bool DimensionDelete = false;

	public bool RegionDelete = false;

	public bool PictureDelete = false;

	public bool TextDelete = false;

	public bool MeshDelete = false;

	public bool BrepDelete = false;

	public bool SurfaceDelete = false;

	public bool SolidDelete = false;

	public bool HatchDelete = false;

	public DeleteTypeEventFormVars()
	{
	}

	public DeleteTypeEventFormVars(DeleteTypeEventFormVars data)
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
}
