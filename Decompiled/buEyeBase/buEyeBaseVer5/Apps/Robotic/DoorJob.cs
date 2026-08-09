using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class DoorJob : buSerilization5
{
	public string Name = "Job";

	public string GCode = "";

	public List<buShape> Items = new List<buShape>();

	public List<string> Codes = new List<string>();

	public List<camTp> Cams = new List<camTp>();

	public List<string> ErrorCodes = new List<string>();

	public MaterialBase5 Material = new MaterialBase5();

	public int TotalCount = 1;

	public int Used = 0;

	public bool isSorted = false;

	public Entity panelEntity = null;

	public DoorJob()
	{
	}

	public DoorJob(DoorJob data)
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
		Material = new MaterialBase5(data.Material);
		if (data.panelEntity != null)
		{
			buVector5.CopyEntities(data.panelEntity, ref panelEntity);
		}
		buShape.Copy(data.Items, ref Items);
		for (int j = 0; j <= data.ErrorCodes.Count - 1; j++)
		{
			ErrorCodes.Add(ErrorCodes[j]);
		}
		for (int k = 0; k <= data.Cams.Count - 1; k++)
		{
			camTp item = new camTp(data.Cams[k]);
			Cams.Add(item);
		}
	}

	public override string ToString()
	{
		return Name.ToString();
	}
}
