using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5;

[Serializable]
public class CharLibrary5 : buSerilization5
{
	public string Char = "";

	public int Index = 0;

	public List<buEntity> CharEntities = new List<buEntity>();

	public CharLibrary5()
	{
	}

	public CharLibrary5(string chars)
	{
		Char = chars;
	}

	public CharLibrary5(CharLibrary5 data)
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
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		buEntity.Copy(data.CharEntities, ref CharEntities);
	}

	public static void Copy(CharLibrary5 Base, ref CharLibrary5 Copied)
	{
		Copied = new CharLibrary5(Base);
	}

	public static void Copy(List<CharLibrary5> Base, ref List<CharLibrary5> Copied)
	{
		Copied.Clear();
		Copied = new List<CharLibrary5>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			CharLibrary5 item = new CharLibrary5(Base[i]);
			Copied.Add(item);
		}
	}

	public static ArrayList ToDef(List<CharLibrary5> Chars, int Space)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Chars.Count - 1; i++)
		{
			arrayList.Add(buString5.SpaceChar(Space) + "<CharacterLibrary>");
			arrayList.AddRange(Chars[i].ToDefAll("", Space + 2, SerilizationMode5.MultiLine));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<CharEntities>");
			for (int j = 0; j <= Chars[i].CharEntities.Count - 1; j++)
			{
				if (Chars[i].CharEntities != null)
				{
					arrayList.AddRange(buEntity.ToDefEntity(Chars[i].CharEntities[j], Space + 4));
				}
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</CharEntities>");
			arrayList.Add(buString5.SpaceChar(Space) + "</CharacterLibrary>");
		}
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<CharLibrary5> Chars)
	{
		Chars.Clear();
		Chars = new List<CharLibrary5>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<CharacterLibrary>", "</CharacterLibrary>", AddStartEndKey: false, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			CharLibrary5 charLibrary = new CharLibrary5();
			buSerilization5.Decode(CalcList[i], "", SerilizationMode5.MultiLine, charLibrary);
			List<List<string>> CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList[i], ref CalcList2);
			for (int j = 0; j <= CalcList2.Count - 1; j++)
			{
				buEntity buEntity2 = buEntity.Decode(CalcList2[j]);
				if (buEntity2 != null)
				{
					charLibrary.CharEntities.Add(buEntity2);
				}
			}
			Chars.Add(charLibrary);
		}
	}

	public override string ToString()
	{
		return Char + " , Ent Count : " + CharEntities.Count;
	}
}
