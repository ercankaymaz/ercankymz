using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buControls.Controls;
using buCore;

namespace buEyeBaseVer5;

[Serializable]
public class hmiUISettings : buSerilization5
{
	public buControlDisplay ButtonNormal = new buControlDisplay();

	public buControlDisplay ButtonOver = new buControlDisplay();

	public buControlDisplay ButtonDown = new buControlDisplay();

	public buControlDisplay Display = new buControlDisplay();

	public buControlDisplay Caption = new buControlDisplay();

	public buControlDisplay Done = new buControlDisplay();

	public buControlDisplay Shape = new buControlDisplay();

	public hmiUIPars Parameters = new hmiUIPars();

	public hmiUISettings()
	{
	}

	public hmiUISettings(hmiUISettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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

	public static hmiUISettings DecodeHMI(List<string> SL, string Title, hmiUISettings Obj)
	{
		List<string> CalcList = new List<string>();
		buString.ListToSpecificList("<" + Title + ">", "</" + Title + ">", AddStartEndKey: false, SL, ref CalcList);
		buSerilization.DecodeProperty(CalcList, "_ButtonNormal", SerilizationMode.MultiLine, Obj.ButtonNormal);
		buSerilization.DecodeProperty(CalcList, "_ButtonOver", SerilizationMode.MultiLine, Obj.ButtonOver);
		buSerilization.DecodeProperty(CalcList, "_ButtonDown", SerilizationMode.MultiLine, Obj.ButtonDown);
		buSerilization.DecodeProperty(CalcList, "_Display", SerilizationMode.MultiLine, Obj.Display);
		buSerilization.DecodeProperty(CalcList, "_Caption", SerilizationMode.MultiLine, Obj.Caption);
		buSerilization.DecodeProperty(CalcList, "_Done", SerilizationMode.MultiLine, Obj.Done);
		buSerilization.DecodeProperty(CalcList, "_Shape", SerilizationMode.MultiLine, Obj.Shape);
		buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, Obj.Parameters);
		return Obj;
	}

	public ArrayList ToDefHMI(string Title, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(new string(' ', Space) + "<" + Title + ">");
		arrayList.Add(new string(' ', Space + 2) + "<buControlDisplayVar>");
		if (ButtonNormal != null)
		{
			arrayList.AddRange(ButtonNormal.ToDefAll("_ButtonNormal", Space + 4, SerilizationMode.MultiLine));
		}
		if (ButtonOver != null)
		{
			arrayList.AddRange(ButtonOver.ToDefAll("_ButtonOver", Space + 4, SerilizationMode.MultiLine));
		}
		if (ButtonDown != null)
		{
			arrayList.AddRange(ButtonDown.ToDefAll("_ButtonDown", Space + 4, SerilizationMode.MultiLine));
		}
		if (Display != null)
		{
			arrayList.AddRange(Display.ToDefAll("_Display", Space + 4, SerilizationMode.MultiLine));
		}
		if (Caption != null)
		{
			arrayList.AddRange(Caption.ToDefAll("_Caption", Space + 4, SerilizationMode.MultiLine));
		}
		if (Done != null)
		{
			arrayList.AddRange(Done.ToDefAll("_Done", Space + 4, SerilizationMode.MultiLine));
		}
		if (Shape != null)
		{
			arrayList.AddRange(Shape.ToDefAll("_Shape", Space + 4, SerilizationMode.MultiLine));
		}
		arrayList.AddRange(Parameters.ToDefAll("", Space + 4, SerilizationMode.MultiLine));
		arrayList.Add(new string(' ', Space + 2) + "</buControlDisplayVar>");
		arrayList.Add(new string(' ', Space) + "</" + Title + ">");
		return arrayList;
	}

	public override string ToString()
	{
		return "";
	}
}
