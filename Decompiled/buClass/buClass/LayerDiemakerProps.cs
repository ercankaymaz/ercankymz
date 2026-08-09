using System.Reflection;

namespace buClass;

public class LayerDiemakerProps : buSerilization
{
	public double Pt = 2.0;

	public DiemakerType Type = DiemakerType.Cutting;

	public LayerDiemakerProps()
	{
	}

	public LayerDiemakerProps(LayerDiemakerProps data)
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
		return "Pt: " + Pt + "  " + Type;
	}
}
