using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;

namespace buCadCamResVer5.Library;

[Serializable]
public class LibraryManager : buSerilization5
{
	public List<LibraryConstraints> ConstraintList = new List<LibraryConstraints>();

	public List<buEntity> Entities = new List<buEntity>();

	public LibraryManager()
	{
	}

	public LibraryManager(LibraryManager data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
		for (int j = 0; j <= data.ConstraintList.Count - 1; j++)
		{
			ConstraintList.Add(new LibraryConstraints(data.ConstraintList[j]));
		}
	}

	public static ArrayList ToDef(LibraryManager LibManager)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= LibManager.ConstraintList.Count - 1; i++)
		{
			arrayList.AddRange(LibManager.ConstraintList[i].ToDefAll("", 4, SerilizationMode5.MultiLine));
		}
		return arrayList;
	}

	public static void Decode(List<string> SL, ref LibraryManager LibManager)
	{
		List<List<string>> CalcList = new List<List<string>>();
		buString5.ListToSpecificList("<LibraryConstraints>", "</LibraryConstraints>", AddStartEndKey: true, SL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			LibraryConstraints libraryConstraints = new LibraryConstraints();
			buSerilization5.Decode(CalcList[i], "", SerilizationMode5.MultiLine, libraryConstraints);
			LibManager.ConstraintList.Add(libraryConstraints);
		}
	}

	public override string ToString()
	{
		return "Constraint : " + ConstraintList.Count + " - Entities : " + Entities.Count;
	}
}
