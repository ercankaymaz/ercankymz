using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class RollerJob : buSerilization5
{
	public string Name = "Job";

	public string Explanation = "";

	public double SheetWidth = 1000.0;

	public double TotalBendingLength = 0.0;

	public double Thickness = 6.0;

	public double LeftAngle = 0.0;

	public buEntity refEntitiy = null;

	public Entity solidEntity = null;

	public List<Point3D> matPoints = null;

	public List<RollerBendMove> Moves = new List<RollerBendMove>();

	public List<RollerBendMove> SimulationMoves = new List<RollerBendMove>();

	public RollerJob()
	{
	}

	public RollerJob(RollerJob data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		if (data.refEntitiy != null)
		{
			buEntity.Copy(data.refEntitiy, ref refEntitiy);
		}
		if (data.solidEntity != null)
		{
			buEntity.Copy(data.solidEntity, ref solidEntity);
		}
	}

	public static ArrayList ToDef(List<ProfileJob> Items, int Space)
	{
		new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(ToDef(Items[i], Space).ToArray());
			arrayList.AddRange(arrayList2);
		}
		return arrayList;
	}

	public static ArrayList ToDef(ProfileJob Item, int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(Item.ToDefAll("", 2, SerilizationMode5.MultiLine).ToArray());
		arrayList.RemoveAt(arrayList.Count - 1);
		arrayList.AddRange(ProfileItem.ToDef(Item.Items, Space + 2));
		arrayList.Add(text + "</ProfileJob>");
		return arrayList;
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
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, Job);
			new List<List<string>>();
			ProfileItem.Decode(arrayList, ref Job.Items);
		}
	}

	public override string ToString()
	{
		return Name.ToString();
	}
}
