using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class SortFoundItems : buSerilization5
{
	public int Index = -1;

	public camPathDirectionType Direction = camPathDirectionType.Normal;

	public Point3D RefPoint = new Point3D();

	public Point3D StartPoint = new Point3D();

	public Point3D NextPoint = new Point3D();

	public Entity Entity = null;

	public SortFoundItems()
	{
	}

	public SortFoundItems(SortFoundItems data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		buVector5.CopyEntities(data.Entity, ref Entity);
	}

	public override string ToString()
	{
		return Index + " - " + Direction.ToString() + " - " + Entity.ToString();
	}
}
