using System.Reflection;

namespace buClass;

public class LayerRouter3XProps : buSerilization
{
	public Router3AXLayerPurpose Purpose = Router3AXLayerPurpose.Cutting;

	public LayerRouter3XProps()
	{
	}

	public LayerRouter3XProps(LayerRouter3XProps data)
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
		return "Purpose: " + Purpose;
	}
}
