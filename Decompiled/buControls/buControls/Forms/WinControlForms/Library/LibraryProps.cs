using System;
using System.Reflection;
using buClass;

namespace buControls.Forms.WinControlForms.Library;

[Serializable]
public class LibraryProps : buSerilization
{
	public string Char = "";

	public string Explanation = "";

	public double Angle = 0.0;

	public LibraryProps()
	{
	}

	public LibraryProps(string chars, string explanation, double angle)
	{
		Angle = angle;
		Char = chars;
		Explanation = explanation;
	}

	public LibraryProps(LibraryProps Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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
}
