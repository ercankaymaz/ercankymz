using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleJob : buSerilization5
{
	public List<MarbleItem> Items = new List<MarbleItem>();

	public List<MarbleVacuumCut> VacuumCuts = null;

	public List<MaterialBase5> VacuumMaterials = null;

	public List<List<MaterialBase5>> SimMaterials = null;

	public buEntitiesGroup SheetGroup = null;

	public List<MarbleItemOperations> Operations = new List<MarbleItemOperations>();

	public List<Entity> SheetSolidEntities = null;

	public List<camTp> Cams = new List<camTp>();

	public camTp Cam = null;

	public MaterialBase5 Material = new MaterialBase5();

	public BoxSize5 SizeOfOperations = new BoxSize5();

	public bool CamCalculated = false;

	public bool isSimulationDone = false;

	public bool isGCodeCreated = false;

	public bool isFileSend = false;

	public bool isSawAvailable = true;

	public bool isMillingAvailable = true;

	public bool isMillingHeadAvailable = true;

	public bool isCommonPathDone = false;

	public bool isWaterJetAvailable = true;

	public int VacuumSelectedIndex = -1;

	public string Name = "";

	public string GCode = "";

	public List<InfoType> TotalMessages = new List<InfoType>();

	public MarbleJob()
	{
	}

	public MarbleJob(MarbleJob data)
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
		if (data.TotalMessages.Count > 0)
		{
			InfoType.Copy(data.TotalMessages, ref TotalMessages);
		}
		if (data.Material != null)
		{
			Material = new MaterialBase5(data.Material);
		}
		if (data.SheetGroup != null)
		{
			SheetGroup = new buEntitiesGroup(data.SheetGroup);
		}
		if (data.SheetSolidEntities != null)
		{
			SheetSolidEntities = new List<Entity>();
			buEntity.Copy(data.SheetSolidEntities, ref SheetSolidEntities);
		}
		if (data.VacuumCuts != null && data.VacuumCuts.Count > 0)
		{
			MarbleVacuumCut.Copy(data.VacuumCuts, ref VacuumCuts);
		}
		if (data.VacuumMaterials != null && data.VacuumMaterials.Count > 0)
		{
			VacuumMaterials.Clear();
			for (int j = 0; j <= data.VacuumMaterials.Count - 1; j++)
			{
				MaterialBase5 item = new MaterialBase5(data.VacuumMaterials[j]);
				VacuumMaterials.Add(item);
			}
		}
		if (data.Cams != null)
		{
			Cams = new List<camTp>();
			camTp.CopyCam(data.Cams, ref Cams);
		}
		if (data.Cam != null)
		{
			Cam = new camTp(data.Cam);
		}
		for (int k = 0; k <= data.Items.Count - 1; k++)
		{
			Items.Add(new MarbleItem(data.Items[k]));
		}
	}

	public override string ToString()
	{
		return "Items: " + Items.Count;
	}

	public static ArrayList ToDef(MarbleJob refJob, int Space)
	{
		string text = "";
		buSerilization5.ExceptionalVariables.Clear();
		buSerilization5.ExceptionalVariables.Add("GCode");
		buSerilization5.ExceptionalVariables.Add("TotalErrorMessages");
		buSerilization5.ExceptionalVariables.Add("TotalWarningMessages");
		buSerilization5.ExceptionalVariables.Add("Messages");
		buSerilization5.ExceptionalVariables.Add("SheetSolidEntities");
		buSerilization5.ExceptionalVariables.Add("Cams");
		buSerilization5.ExceptionalVariables.Add("SheetGroup");
		buSerilization5.ExceptionalVariables.Add("Cam");
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		arrayList2.AddRange(refJob.ToDefAll("", Space, SerilizationMode5.MultiLine));
		if (arrayList2.Count > 0)
		{
			text = arrayList2[arrayList2.Count - 1].ToString();
			arrayList2.RemoveAt(arrayList2.Count - 1);
			arrayList.Add(arrayList2[0]);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<MarbleJobBase>");
			for (int i = 1; i <= arrayList2.Count - 1; i++)
			{
				arrayList.Add(buString5.SpaceChar(2) + arrayList2[i]);
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</MarbleJobBase>");
			if (refJob.SheetGroup != null)
			{
				arrayList.AddRange(buEntitiesGroup.ToDefGroup(refJob.SheetGroup, Space + 2));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<MarbleOperations>");
			for (int j = 0; j <= refJob.Items.Count - 1; j++)
			{
				arrayList.AddRange(MarbleItem.ToDef(refJob.Items[j], Space + 4));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</MarbleOperations>");
			arrayList.Add(text);
		}
		buSerilization5.ExceptionalVariables.Clear();
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref MarbleJob refJob)
	{
		try
		{
			refJob = new MarbleJob();
			List<string> CalcList = new List<string>();
			buStatics.ListToSpecificList("<MarbleJobBase>", "</MarbleJobBase>", AddStartEndKey: false, AL, ref CalcList);
			buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, refJob);
			new List<List<string>>();
			CalcList.Clear();
			buStatics.ListToSpecificList("<MarbleOperations>", "</MarbleOperations>", AddStartEndKey: false, AL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refJob.Items = new List<MarbleItem>();
				MarbleItem.Decode(CalcList, ref refJob.Items);
			}
			CalcList.Clear();
		}
		catch (Exception)
		{
		}
	}
}
