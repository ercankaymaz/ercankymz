using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendDiskBlocks : buSerilization5
{
	public double BlockPipeDiameter = 60.0;

	public double DiskDiameter = 200.0;

	public double DiskHeight = 80.0;

	public double DiskThickness = 10.0;

	public double DiskBlockWidth = 50.0;

	public double DiskBlockLength = 50.0;

	public double BlockWidth = 200.0;

	public double BlockHeight = 80.0;

	public double BlockDepth = 150.0;

	public Entity entityDisk = null;

	public Entity entityBlock = null;

	public PipeBendDiskBlocks()
	{
	}

	public PipeBendDiskBlocks(PipeBendDiskBlocks data)
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
		if (data.entityDisk != null)
		{
			buEntity.Copy(data.entityDisk, ref entityDisk);
		}
		if (data.entityBlock != null)
		{
			buEntity.Copy(data.entityBlock, ref entityBlock);
		}
	}

	public static void Copy(PipeBendDiskBlocks Source, ref PipeBendDiskBlocks Target)
	{
		Target = new PipeBendDiskBlocks(Source);
	}

	public static ArrayList ToDef(List<PipeBendDiskBlocks> Items, string Char, int Space)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			arrayList.AddRange(ToDef(Items[i], Char, Space + 2));
		}
		return arrayList;
	}

	public static ArrayList ToDef(PipeBendDiskBlocks Item, string Char, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<DiskBlocks>");
		string value = buString5.SpaceChar(Space + 2) + buSerilization5.ClassToString(Item);
		arrayList.Add(value);
		arrayList.Add(buString5.SpaceChar(Space) + "</DiskBlocks>");
		return arrayList;
	}

	public static void Decode(List<string> Lines, ref List<PipeBendDiskBlocks> Items)
	{
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<DiskBlocks>", "</DiskBlocks>", AddStartEndKey: false, Lines, ref CalcList);
		if (Items == null)
		{
			Items = new List<PipeBendDiskBlocks>();
		}
		if (CalcList.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			PipeBendDiskBlocks pipeBendDiskBlocks = new PipeBendDiskBlocks();
			object ObjPar = pipeBendDiskBlocks;
			buSerilization5.StringToClass(ref ObjPar, CalcList[i][0]);
			if (ObjPar != null)
			{
				Items.Add((PipeBendDiskBlocks)ObjPar);
			}
		}
	}

	public static void Decode(List<string> Lines, ref PipeBendDiskBlocks Item)
	{
		List<string> CalcList = new List<string>();
		buStatics.ListToSpecificList("<DiskBlocks>", "</DiskBlocks>", AddStartEndKey: false, Lines, ref CalcList);
		if (CalcList.Count > 0)
		{
			object ObjPar = Item;
			buSerilization5.StringToClass(ref ObjPar, CalcList[0]);
		}
	}

	public override string ToString()
	{
		return "Pipe Diameter:" + BlockPipeDiameter.ToString("f1") + " - DiskDiameter: " + DiskDiameter.ToString("f1");
	}
}
