using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class pageInfo
{
	public Point3D EntitiesBoxSize = new Point3D();

	public pageInfo()
	{
	}

	public pageInfo(pageInfo Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
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
