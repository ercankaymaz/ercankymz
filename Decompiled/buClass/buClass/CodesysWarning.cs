using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysWarning : buSerilization
{
	public bool Occured = false;

	public string Text = "";

	public int ID = -1;

	public string AX = "";

	public CodesysWarning()
	{
	}

	public CodesysWarning(CodesysWarning data)
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
		return "Occur: " + Occured + " , Axis: " + AX.ToString() + " , Text: " + Text.ToString() + " , ID: " + ID;
	}
}
