using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TuftingYarn : buSerilization
{
	public string Name = "";

	public double HundredMeterPerGram = 10.0;

	public double Kat = 1.0;

	public static List<string> Captions = new List<string>();

	public TuftingYarn()
	{
	}

	public TuftingYarn(TuftingYarn data)
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

	public static void Copy(TuftingYarn Base, ref TuftingYarn Copied)
	{
		Copied = new TuftingYarn(Base);
	}

	public static void Copy(List<TuftingYarn> Base, ref List<TuftingYarn> Copied)
	{
		Copied.Clear();
		Copied = new List<TuftingYarn>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new TuftingYarn(Base[i]));
		}
	}

	public static List<TuftingYarn> Copy(List<TuftingYarn> Base)
	{
		List<TuftingYarn> list = new List<TuftingYarn>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			list.Add(new TuftingYarn(Base[i]));
		}
		return list;
	}

	public override string ToString()
	{
		return Name + " ; Gram : " + HundredMeterPerGram + " ; Kat: " + Kat;
	}
}
