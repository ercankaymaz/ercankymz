using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleStepAnsFeedForCircular : buSerilization5
{
	public double MinRadius = 0.0;

	public double MaxRadius = 0.0;

	public double Step = 0.0;

	public double Feed = 0.0;

	public static List<string> Captions = new List<string>();

	public marbleStepAnsFeedForCircular()
	{
	}

	public marbleStepAnsFeedForCircular(marbleStepAnsFeedForCircular data)
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

	public static void Copy(marbleStepAnsFeedForCircular Source, ref marbleStepAnsFeedForCircular Target)
	{
		Target = new marbleStepAnsFeedForCircular(Source);
	}

	public override string ToString()
	{
		return "MinRadius : " + MinRadius + " , MaxRadius : " + MaxRadius + " , Step : " + Step + " , Feed : " + Feed;
	}
}
