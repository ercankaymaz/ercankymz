using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillJob : buSerilization5
{
	public string Name = "Job";

	public List<buShape> Items = new List<buShape>();

	public List<DrillItemBase> baseItems = new List<DrillItemBase>();

	public List<DrillCalcItem> ItemCalc = new List<DrillCalcItem>();

	public List<DrillItem> ItemShape = new List<DrillItem>();

	public List<DrillMove> Moves = new List<DrillMove>();

	public List<DrillMove> SimulationMoves = new List<DrillMove>();

	public List<string> Codes = new List<string>();

	public List<camTp> Cams = new List<camTp>();

	public List<DrillItem> NoCalculatedItems = new List<DrillItem>();

	public List<string> ErrorCodes = new List<string>();

	public MaterialBase5 Material = new MaterialBase5();

	public int TotalCount = 1;

	public int Used = 0;

	public double FirstClamperX = 0.0;

	public double SecondClamperX = 0.0;

	public double TotalSec = 0.0;

	public bool isError = false;

	public bool isLesSafe = false;

	public bool isSingleClamper = false;

	public bool isSorted = false;

	public bool isClamperSideDrillOpAvailable = false;

	public bool isClamperSideMillingOpAvailable = false;

	public bool isClamperSideSlotOpAvailable = false;

	public bool MakeContour = false;

	public bool ClampesSetByManuelly = false;

	public double ContourOffset = 0.0;

	public Entity panelEntity = null;

	public Entity FirstClamperEntity = null;

	public Entity SecondClamperEntity = null;

	public List<Entity> otherEntities = null;

	public DrillJob()
	{
	}

	public DrillJob(DrillJob data)
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
		if (data.FirstClamperEntity != null)
		{
			buVector5.CopyEntities(data.FirstClamperEntity, ref FirstClamperEntity);
		}
		if (data.SecondClamperEntity != null)
		{
			buVector5.CopyEntities(data.SecondClamperEntity, ref SecondClamperEntity);
		}
		if (data.otherEntities != null)
		{
			otherEntities = new List<Entity>();
			for (int j = 0; j <= data.otherEntities.Count - 1; j++)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(data.otherEntities[j], ref copiedEnt);
				otherEntities.Add(copiedEnt);
			}
		}
		DrillItemBase.Copy(data.baseItems, ref baseItems);
		for (int k = 0; k <= data.Items.Count - 1; k++)
		{
			Items.Add(buShape.Copy(data.Items[k]));
		}
		for (int l = 0; l <= data.NoCalculatedItems.Count - 1; l++)
		{
			DrillItem item = new DrillItem(data.NoCalculatedItems[l]);
			NoCalculatedItems.Add(item);
		}
		for (int m = 0; m <= data.ItemShape.Count - 1; m++)
		{
			DrillItem item2 = new DrillItem(data.ItemShape[m]);
			ItemShape.Add(item2);
		}
		for (int n = 0; n <= data.ErrorCodes.Count - 1; n++)
		{
			ErrorCodes.Add(ErrorCodes[n]);
		}
		for (int num = 0; num <= data.ItemCalc.Count - 1; num++)
		{
			ItemCalc.Add(data.ItemCalc[num]);
		}
		for (int num2 = 0; num2 <= data.Cams.Count - 1; num2++)
		{
			camTp item3 = new camTp(data.Cams[num2]);
			Cams.Add(item3);
		}
	}

	public override string ToString()
	{
		return Name.ToString();
	}
}
