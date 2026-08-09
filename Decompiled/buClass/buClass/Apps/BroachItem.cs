using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BroachItem : buSerilization
{
	public double ExtractXPosition = 0.0;

	public bool Enable;

	public int BendIndex = -1;

	public double Offset;

	public double Depth = 0.0;

	public double Width = 0.0;

	public DiemakerBroachDirection Direction = DiemakerBroachDirection.Top;

	public BroachItem()
	{
	}

	public BroachItem(BroachItem data)
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
		return "Extract X : " + ExtractXPosition.ToString("f2") + " ; Dir: " + Direction;
	}
}
