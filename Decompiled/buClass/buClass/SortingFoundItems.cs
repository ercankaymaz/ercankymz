using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SortingFoundItems : buSerilization
{
	public int Index = -1;

	public camPathDirectionType Direction = camPathDirectionType.Normal;

	public Pnt3D RefPoint = new Pnt3D();

	public Pnt3D NextPoint = new Pnt3D();

	public eEntities Entity = new eEntities();

	public SortingFoundItems()
	{
	}

	public SortingFoundItems(SortingFoundItems data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		Entity = new eEntities();
		Entity = eEntities.CopyEntity(data.Entity);
	}

	public override string ToString()
	{
		return Index + " - " + Direction.ToString() + " - " + Entity.ToString();
	}
}
