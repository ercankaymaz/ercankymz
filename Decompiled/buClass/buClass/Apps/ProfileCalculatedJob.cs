using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileCalculatedJob : buSerilization
{
	public string Name = "Job";

	public List<ProfileOperation> Operation = new List<ProfileOperation>();

	public ProfileCalculatedJob()
	{
	}

	public ProfileCalculatedJob(ProfileJob data)
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

	public static ArrayList ToDef(List<ProfileCalculatedJob> Items, int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(ToDef(Items[i], Space).ToArray());
			arrayList.AddRange(arrayList2);
		}
		return arrayList;
	}

	public static ArrayList ToDef(ProfileCalculatedJob Item, int Space)
	{
		string text = new string(' ', Space);
		return new ArrayList();
	}

	public static void Decode(List<string> AL, ref ProfileJob Job)
	{
		Job = new ProfileJob();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<ProfileJob>", "</ProfileJob>", AddStartEndKey: true, AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[0].ToArray());
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, Job);
			List<List<string>> CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<ProfileItem>", "</ProfileItem>", AddStartEndKey: true, arrayList, ref CalcList2);
			ProfileItem.Decode(arrayList, ref Job.Items);
		}
	}

	public override string ToString()
	{
		return Name.ToString();
	}
}
