using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SelectedPointOfEntity : buSerilization
{
	public Pnt3D PointOfEntity = new Pnt3D();

	public int EntityIndex = -1;

	public int VerticeIndex = -1;

	public int ControlIndex = -1;

	public bool Clicked = false;

	public SelectedPointOfEntity()
	{
	}

	public SelectedPointOfEntity(SelectedPointOfEntity data)
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
		return "Point: " + PointOfEntity.ToString() + " , Entitiy Index: " + EntityIndex;
	}
}
