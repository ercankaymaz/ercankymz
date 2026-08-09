using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendPart : buSerilization
{
	public int Count = 0;

	public int CountDone = 0;

	public int Closed = 0;

	public int Index = 0;

	public bool Done = false;

	public string FileName = "";

	public string RefFileName = "";

	public string FullPath = "";

	public string Path = "";

	public int PartID = 0;

	public bool TransferRamp = false;

	public int BlueBenderCutMode = 0;

	public double Heigth = 0.0;

	public double BridgeHeight = 0.0;

	public double Thickness = 0.0;

	public double Width = 0.0;

	public double Length = 0.0;

	public bool TrimcutPress = false;

	public int PartMaterialType = 0;

	public double ShapedModeOverride = 100.0;

	public bool BendCut = false;

	public double Offset = 0.0;

	public List<BendingItem> BendingItems = new List<BendingItem>();

	public List<eEntities> Entities = new List<eEntities>();

	public BendPart()
	{
	}

	public BendPart(BendPart data)
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
		Entities.Clear();
		eEntities.CopyEntities(data.Entities, ref Entities);
		BendingItems = new List<BendingItem>();
		for (int j = 0; j <= data.BendingItems.Count - 1; j++)
		{
			if (data.BendingItems[j].GetType() == typeof(BendingBendPoint))
			{
				BendingBendPoint item = new BendingBendPoint((BendingBendPoint)data.BendingItems[j]);
				BendingItems.Add(item);
			}
			if (data.BendingItems[j].GetType() == typeof(BendingBridgePoint))
			{
				BendingBridgePoint item2 = new BendingBridgePoint((BendingBridgePoint)data.BendingItems[j]);
				BendingItems.Add(item2);
			}
			if (data.BendingItems[j].GetType() == typeof(BendingBroachPoint))
			{
				BendingBroachPoint item3 = new BendingBroachPoint((BendingBroachPoint)data.BendingItems[j]);
				BendingItems.Add(item3);
			}
			if (data.BendingItems[j].GetType() == typeof(BendingNickPoint))
			{
				BendingNickPoint item4 = new BendingNickPoint((BendingNickPoint)data.BendingItems[j]);
				BendingItems.Add(item4);
			}
			if (data.BendingItems[j].GetType() == typeof(BendingTrimcutPoint))
			{
				BendingTrimcutPoint item5 = new BendingTrimcutPoint((BendingTrimcutPoint)data.BendingItems[j]);
				BendingItems.Add(item5);
			}
			if (data.BendingItems[j].GetType() == typeof(BendingPunchPoint))
			{
				BendingPunchPoint item6 = new BendingPunchPoint((BendingPunchPoint)data.BendingItems[j]);
				BendingItems.Add(item6);
			}
			if (data.BendingItems[j].GetType() == typeof(BendingScissorsPoint))
			{
				BendingScissorsPoint item7 = new BendingScissorsPoint((BendingScissorsPoint)data.BendingItems[j]);
				BendingItems.Add(item7);
			}
			if (data.BendingItems[j].GetType() == typeof(BendingBendCut))
			{
				BendingBendCut item8 = new BendingBendCut((BendingBendCut)data.BendingItems[j]);
				BendingItems.Add(item8);
			}
		}
	}

	public override string ToString()
	{
		return "Count: " + Count + " ; Length: " + Length + "  ; Thickness: " + Thickness + "  - File: " + FileName.ToString();
	}
}
