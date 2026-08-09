using System;
using System.ComponentModel;
using System.Reflection;

namespace devDept.Eyeshot.Control;

public class EnumDescription
{
	protected Type myType;

	public static string GetDescription(Enum value)
	{
		DescriptionAttribute[] array = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
		if (array.Length == 0)
		{
			return value.ToString();
		}
		return array[0].Description;
	}

	public static string GetDescription(Type value, string name)
	{
		DescriptionAttribute[] array = (DescriptionAttribute[])value.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
		if (array.Length == 0)
		{
			return name;
		}
		return array[0].Description;
	}

	public static object GetValue(Type value, string description)
	{
		FieldInfo[] fields = value.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			DescriptionAttribute[] array = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
			if (array.Length != 0 && array[0].Description == description)
			{
				return fieldInfo.GetValue(fieldInfo.Name);
			}
			if (fieldInfo.Name == description)
			{
				return fieldInfo.GetValue(fieldInfo.Name);
			}
		}
		return description;
	}
}
