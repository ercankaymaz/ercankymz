using System.Reflection;

namespace buClass.Apps;

public class jewelSideOperation : buSerilization
{
	public bool Enable = false;

	public double Thickness = 2.0;

	public double DiameterInner = 10.0;

	public double Angle = 90.0;

	public double XOffset = 0.0;

	public double ZOffset = 0.0;

	public jewelSideOperation()
	{
	}

	public jewelSideOperation(jewelSideOperation data)
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
