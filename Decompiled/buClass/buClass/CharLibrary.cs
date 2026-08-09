using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CharLibrary : buSerilization
{
	public string Char = "";

	public List<geoEntity> CharEntities = new List<geoEntity>();

	public CharLibrary()
	{
	}

	public CharLibrary(CharLibrary data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		CharEntities = new List<geoEntity>();
		geoEntity.Copy(data.CharEntities, ref CharEntities);
	}

	public static void Copy(CharLibrary Base, ref CharLibrary Copied)
	{
		Copied = new CharLibrary(Base);
	}

	public static void Copy(List<CharLibrary> Base, ref List<CharLibrary> Copied)
	{
		Copied.Clear();
		Copied = new List<CharLibrary>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			CharLibrary item = new CharLibrary(Base[i]);
			Copied.Add(item);
		}
	}

	public static ArrayList ToDef(List<CharLibrary> Chars, int Space)
	{
		string text = new string(' ', Space);
		string text2 = new string(' ', Space + 2);
		string text3 = new string(' ', Space + 6);
		string text4 = new string(' ', Space + 8);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(text + "<CharacterLibrary>");
		for (int i = 0; i <= Chars.Count - 1; i++)
		{
			string text5 = "";
			arrayList.AddRange(Chars[i].ToDefAll("", 4 + Space, SerilizationMode.MultiLine));
			text5 = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			arrayList.Add(text3 + "<CharEntities>");
			for (int j = 0; j <= Chars[i].CharEntities.Count - 1; j++)
			{
				if (Chars[i].CharEntities != null)
				{
					arrayList.AddRange(Chars[i].CharEntities[j].ToDefAll(8 + Space));
				}
			}
			arrayList.Add(text3 + "</CharEntities>");
			arrayList.Add(text5);
		}
		arrayList.Add(text + "</CharacterLibrary>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<CharLibrary> Chars)
	{
		List<List<string>> list = new List<List<string>>();
		Chars.Clear();
		Chars = new List<CharLibrary>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<CharLibrary>", "</CharLibrary>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			CharLibrary charLibrary = new CharLibrary();
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, charLibrary);
			List<string> CalcList2 = new List<string>();
			buStatics.ListToSpecificList("<CharEntities>", "</CharEntities>", AddStartEndKey: true, arrayList, ref CalcList2);
			list = new List<List<string>>();
			buStatics.ListToSpecificList("<geoEntity>", "</geoEntity>", AddStartEndKey: false, CalcList2, ref list);
			for (int j = 0; j <= list.Count - 1; j++)
			{
				geoEntity geoEntity2 = new geoEntity();
				geoEntity2 = geoEntity.Decode(list[j], "", SerilizationMode.MultiLine);
				charLibrary.CharEntities.Add(geoEntity2);
			}
			Chars.Add(charLibrary);
		}
	}

	public override string ToString()
	{
		return Char + " , Ent Count : " + CharEntities.Count;
	}
}
