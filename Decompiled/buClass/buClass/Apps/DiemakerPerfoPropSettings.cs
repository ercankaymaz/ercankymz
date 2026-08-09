using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerPerfoPropSettings : buSerilization
{
	public DiemakerPerfoType PerfoType = DiemakerPerfoType.MaleMale;

	public double MaleWidth = 2.0;

	public double FamaleWidth = 2.0;

	public double PerfoHeight = 2.0;

	public double StartOffset = 0.0;

	public double EndOffset = 0.0;

	public double StartPosition = 0.0;

	public double EndPosition = 0.0;

	public bool MultiPerfo = true;

	public static List<string> Captions = new List<string>();

	public DiemakerPerfoPropSettings()
	{
	}

	public DiemakerPerfoPropSettings(DiemakerPerfoPropSettings data)
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

	public static void Copy(DiemakerPerfoPropSettings Source, ref DiemakerPerfoPropSettings Target)
	{
		Target = new DiemakerPerfoPropSettings(Source);
	}

	public override string ToString()
	{
		return "PerfoType : " + PerfoType.ToString() + " - MaleWidth : " + MaleWidth + " - FamaleWidth : " + FamaleWidth + " - Height : " + PerfoHeight;
	}
}
