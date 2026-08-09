using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileBase : buSerilization5
{
	public string Name = "Job";

	public bool isSimulationDone = false;

	public ProfileItem FirstItem = null;

	public ProfileItem SecondItem = null;

	public ProfileItem ThirdItem = null;

	public ProfileItem FourthItem = null;

	public ArrayList GCodes = null;

	public ProfileBase()
	{
	}

	public ProfileBase(ProfileBase data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		if (data.FirstItem != null)
		{
			FirstItem = new ProfileItem(data.FirstItem);
		}
		if (data.SecondItem != null)
		{
			SecondItem = new ProfileItem(data.SecondItem);
		}
	}

	public static ArrayList ToDef(ProfileBase Item, int Space)
	{
		string text = new string(' ', Space);
		string text2 = new string(' ', Space + 2);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(text + "<ProfileBase>");
		if (Item.FirstItem != null)
		{
			arrayList.Add(text2 + "<FirstItem>");
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(ProfileItem.ToDef(Item.FirstItem, Space + 4));
			arrayList.AddRange(arrayList2);
			arrayList.Add(text2 + "</FirstItem>");
		}
		if (Item.SecondItem != null)
		{
			arrayList.Add(text2 + "<SecondItem>");
			ArrayList arrayList3 = new ArrayList();
			arrayList3.AddRange(ProfileItem.ToDef(Item.SecondItem, Space + 4));
			arrayList.AddRange(arrayList3);
			arrayList.Add(text2 + "<SecondItem>");
		}
		arrayList.Add(text + "</ProfileBase>");
		return arrayList;
	}

	public static void Decode(List<string> AL, ref ProfileBase Job)
	{
		Job = new ProfileBase();
		List<string> CalcList = new List<string>();
		buStatics.ListToSpecificList("<ProfileBase>", "</ProfileBase>", AddStartEndKey: true, AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			ArrayList CalcList2 = new ArrayList();
			buStatics.ListToSpecificList("<FirstItem>", "</FirstItem>", AddStartEndKey: false, CalcList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				Job.FirstItem = new ProfileItem();
				ProfileItem.Decode(CalcList2, ref Job.FirstItem);
			}
			ArrayList CalcList3 = new ArrayList();
			buStatics.ListToSpecificList("<SecondItem>", "</SecondItem>", AddStartEndKey: false, CalcList, ref CalcList3);
			if (CalcList3.Count > 0)
			{
				Job.SecondItem = new ProfileItem();
				ProfileItem.Decode(CalcList3, ref Job.SecondItem);
			}
		}
	}

	public override string ToString()
	{
		return Name.ToString();
	}
}
