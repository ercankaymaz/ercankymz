using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class JogSettings : buSerilization
{
	public bool Enable = true;

	public bool VelocityControlEnable = true;

	public bool AbsoluteMoveControlEnable = true;

	public bool RelativeMoveControlEnable = true;

	public bool JogFromDigitalInputsEnable = false;

	public static List<string> Captions = new List<string>();

	public JogSettings()
	{
	}

	public JogSettings(JogSettings data)
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
		return "Enable: " + Enable + " , Vel: " + VelocityControlEnable + " , Rel : " + RelativeMoveControlEnable + " , Abs : " + AbsoluteMoveControlEnable;
	}
}
