using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ToolGrindingJob : buSerilization5
{
	public string Name = "Job";

	public buEntity refEntitiy = null;

	public Entity solidEntity = null;

	public ToolGrindingJob()
	{
	}

	public ToolGrindingJob(ToolGrindingJob data)
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

	public static ArrayList ToDef(List<ToolGrindingJob> Items, int Space)
	{
		new string(' ', Space);
		return new ArrayList();
	}

	public static ArrayList ToDef(ToolGrindingJob Item, int Space)
	{
		new string(' ', Space);
		return new ArrayList();
	}

	public static void Decode(List<string> AL, ref ProfileJob Job)
	{
		new List<List<string>>();
	}

	public override string ToString()
	{
		return Name.ToString();
	}
}
