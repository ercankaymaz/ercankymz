using System;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationSortItem : buSerilization5
{
	public BoxSize5 SizePoint = new BoxSize5();

	public bool Used = false;

	public string ID = "";

	public planeNames Plane = planeNames.Top;

	public int ToolNo = -1;

	public ProfileOperationSortItem()
	{
	}

	public ProfileOperationSortItem(Point3D MinPoint, Point3D MaxPoint)
	{
		SizePoint = new BoxSize5(MinPoint, MaxPoint);
	}

	public ProfileOperationSortItem(Point3D MinPoint, Point3D MaxPoint, string ID)
	{
		SizePoint = new BoxSize5(MinPoint, MaxPoint);
		this.ID = ID;
	}

	public ProfileOperationSortItem(ProfileOperationSortItem data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		SizePoint = new BoxSize5(data.SizePoint);
	}

	public override string ToString()
	{
		return SizePoint.ToString() + " - Used: " + Used;
	}
}
