using System.Reflection;

namespace buClass;

public class EntityDerivatedData : buSerilization
{
	public double Offset = 0.0;

	public bool ApplyAllEntityData = true;

	public EntityDerivatedData()
	{
	}

	public EntityDerivatedData(EntityDerivatedData data)
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
