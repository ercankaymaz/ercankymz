using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class MachineGCodeConfigrasyon : buSerilization5
{
	public List<MachineAxisInfo> AxesList = new List<MachineAxisInfo>();

	public List<MachineMCodeInfo> MCodeList = new List<MachineMCodeInfo>();

	public List<MachineOtherCodeInfo> OtherCodeList = new List<MachineOtherCodeInfo>();

	public double ExstraTime = 0.0;

	public LengthUnit LengthType = LengthUnit.mm;

	public SpeedUnit SpeedType = SpeedUnit.mmPerMin;

	public MachineGCodeConfigrasyon()
	{
	}

	public MachineGCodeConfigrasyon(MachineGCodeConfigrasyon data)
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
		for (int j = 0; j <= data.AxesList.Count - 1; j++)
		{
			AxesList.Add(new MachineAxisInfo(data.AxesList[j]));
		}
		for (int k = 0; k <= data.MCodeList.Count - 1; k++)
		{
			MCodeList.Add(new MachineMCodeInfo(data.MCodeList[k]));
		}
		for (int l = 0; l <= data.OtherCodeList.Count - 1; l++)
		{
			OtherCodeList.Add(new MachineOtherCodeInfo(data.OtherCodeList[l]));
		}
	}

	public override string ToString()
	{
		return "Axis : " + AxesList.Count.ToString("") + " - MCode: " + MCodeList.Count.ToString("");
	}

	public static ArrayList ToDef(MachineGCodeConfigrasyon GCodeConfig, int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		GCodeConfig.ToDefAll("", Space, SerilizationMode5.MultiLine);
		arrayList.Add(text + "<MachineGCodeConfigrasyonMain>");
		string value = buString5.SpaceChar(Space + 2) + buSerilization5.ClassToString(GCodeConfig);
		arrayList.Add(value);
		arrayList.Add(text + "</MachineGCodeConfigrasyonMain>");
		arrayList.Add(text + "<MachineAxisInfoMain>");
		for (int i = 0; i <= GCodeConfig.AxesList.Count - 1; i++)
		{
			arrayList.AddRange(GCodeConfig.AxesList[i].ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
		}
		arrayList.Add(text + "</MachineAxisInfoMain>");
		arrayList.Add(text + "<MachineMCodeInfoMain>");
		for (int j = 0; j <= GCodeConfig.MCodeList.Count - 1; j++)
		{
			arrayList.AddRange(GCodeConfig.MCodeList[j].ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
		}
		arrayList.Add(text + "</MachineMCodeInfoMain>");
		arrayList.Add(text + "<MachineOtherCodeInfoMain>");
		for (int k = 0; k <= GCodeConfig.OtherCodeList.Count - 1; k++)
		{
			arrayList.AddRange(GCodeConfig.OtherCodeList[k].ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
		}
		arrayList.Add(text + "</MachineOtherCodeInfoMain>");
		return arrayList;
	}

	public static void Decode(List<string> Lines, ref MachineGCodeConfigrasyon GCodeConfig)
	{
		List<string> CalcList = new List<string>();
		buStatics.ListToSpecificList("<MachineGCodeConfigrasyonMain>", "</MachineGCodeConfigrasyonMain>", AddStartEndKey: false, Lines, ref CalcList);
		if (CalcList.Count > 0)
		{
			object ObjPar = GCodeConfig;
			buSerilization5.StringToClass(ref ObjPar, CalcList[0]);
		}
		CalcList.Clear();
		List<List<string>> CalcList2 = new List<List<string>>();
		buStatics.ListToSpecificList("<MachineAxisInfo>", "</MachineAxisInfo>", AddStartEndKey: true, Lines, ref CalcList2);
		if (CalcList2.Count > 0)
		{
			for (int i = 0; i <= CalcList2.Count - 1; i++)
			{
				MachineAxisInfo machineAxisInfo = new MachineAxisInfo();
				buSerilization5.Decode(CalcList2[i], "", SerilizationMode5.MultiLine, machineAxisInfo);
				GCodeConfig.AxesList.Add(machineAxisInfo);
				CalcList2[i].Clear();
			}
			CalcList2.Clear();
		}
		CalcList2 = new List<List<string>>();
		buStatics.ListToSpecificList("<MachineMCodeInfo>", "</MachineMCodeInfo>", AddStartEndKey: true, Lines, ref CalcList2);
		if (CalcList2.Count > 0)
		{
			for (int j = 0; j <= CalcList2.Count - 1; j++)
			{
				MachineMCodeInfo machineMCodeInfo = new MachineMCodeInfo();
				buSerilization5.Decode(CalcList2[j], "", SerilizationMode5.MultiLine, machineMCodeInfo);
				GCodeConfig.MCodeList.Add(machineMCodeInfo);
				CalcList2[j].Clear();
			}
			CalcList2.Clear();
		}
		CalcList2 = new List<List<string>>();
		buStatics.ListToSpecificList("<MachineOtherCodeInfo>", "</MachineOtherCodeInfo>", AddStartEndKey: true, Lines, ref CalcList2);
		if (CalcList2.Count > 0)
		{
			for (int k = 0; k <= CalcList2.Count - 1; k++)
			{
				MachineOtherCodeInfo machineOtherCodeInfo = new MachineOtherCodeInfo();
				buSerilization5.Decode(CalcList2[k], "", SerilizationMode5.MultiLine, machineOtherCodeInfo);
				GCodeConfig.OtherCodeList.Add(machineOtherCodeInfo);
				CalcList2[k].Clear();
			}
			CalcList2.Clear();
		}
	}
}
