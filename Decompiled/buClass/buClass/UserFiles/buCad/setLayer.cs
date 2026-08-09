using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setLayer : buSerilization
{
	public LayerDoubleClickType LayerDoubleClick = LayerDoubleClickType.LayerFull;

	public setLayer()
	{
	}

	public setLayer(setLayer data)
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
