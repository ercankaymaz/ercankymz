using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class InfoType : buSerilization
{
	public string InfoName = "";

	public string Message = "";

	public string Axis = "";

	public int Code = 0;

	public double Value = 0.0;

	public bool ShowLabel = true;

	public DateTime Time = DateTime.Now;

	public Color ColorInfo = Color.Gold;

	public InfoTypeMode Mode = InfoTypeMode.None;

	public InfoTypeCodes CodeType = InfoTypeCodes.None;

	public InfoType()
	{
	}

	public InfoType(InfoType data)
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

	public InfoType(string name, string message, int code, double value, DateTime time)
	{
		InfoName = name;
		Message = message;
		Code = code;
		Value = value;
		Time = time;
	}

	public InfoType(string name, string message, int code, double value, DateTime time, InfoTypeMode mode, Color color)
	{
		InfoName = name;
		Message = message;
		Code = code;
		Value = value;
		Time = time;
		Mode = mode;
		ColorInfo = color;
	}

	public InfoType(string name, string message, int code, double value, DateTime time, InfoTypeMode mode, InfoTypeCodes codetype, string axis, Color color)
	{
		InfoName = name;
		Message = message;
		Code = code;
		Value = value;
		Time = time;
		Mode = mode;
		ColorInfo = color;
		CodeType = codetype;
		Axis = axis;
	}

	public static void Copy(List<InfoType> baseList, ref List<InfoType> copyList)
	{
		for (int i = 0; i <= baseList.Count - 1; i++)
		{
			copyList.Add(new InfoType(baseList[i]));
		}
	}

	public override string ToString()
	{
		return Mode.ToString() + " : " + Message + " - Code: " + Code;
	}
}
