using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamBlock : buSerilization5
{
	public string BlockName = "Block";

	public double TopZ = 100.0;

	public double BottomZ = 100.0;

	public double LeftMin = 0.0;

	public double LeftMax = 0.0;

	public bool isError = false;

	public bool isVertical = false;

	public SizeObject SizeObj = new SizeObject();

	public string TextureName = "";

	public Color colorFoam = Color.DarkGray;

	public int Transparency = 120;

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public FoamPlaneType planeName = FoamPlaneType.XZ;

	public FoamSpeeds Speeds = new FoamSpeeds();

	public FoamRuntimeSettings Settings = new FoamRuntimeSettings();

	public FoamPattern basePattern = null;

	public FoamType BlockFoamType = FoamType.SlicesVertical;

	public bool isWaveOperation = false;

	public List<FoamPattern> Pattern = new List<FoamPattern>();

	public FoamBlock()
	{
	}

	public FoamBlock(FoamBlock data)
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
		if (data.basePattern != null)
		{
			basePattern = new FoamPattern(data.basePattern);
		}
		Settings = new FoamRuntimeSettings(data.Settings);
		Speeds = new FoamSpeeds(data.Speeds);
		for (int j = 0; j <= data.Pattern.Count - 1; j++)
		{
			Pattern.Add(new FoamPattern(data.Pattern[j]));
		}
		SizeObj = new SizeObject(data.SizeObj);
	}

	public static void Decode(List<string> AL, ref FoamBlock Item)
	{
		Item = new FoamBlock();
		buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, Item);
		List<List<string>> list = new List<List<string>>();
		List<string> CalcList = new List<string>();
		List<List<string>> CalcList2 = new List<List<string>>();
		buStatics.ListToSpecificList("<Patterns>", "</Patterns>", AddStartEndKey: false, AL, ref CalcList);
		buStatics.ListToSpecificList("<FoamPattern>", "</FoamPattern>", AddStartEndKey: true, CalcList, ref CalcList2);
		for (int i = 0; i <= CalcList2.Count - 1; i++)
		{
			FoamPattern Item2 = new FoamPattern();
			FoamPattern.Decode(CalcList2[i], ref Item2);
			Item.Pattern.Add(Item2);
		}
		CalcList.Clear();
		CalcList2.Clear();
		AL.Clear();
		list.Clear();
	}

	public static ArrayList ToDef(FoamBlock refItem, int Space)
	{
		string text = "";
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(refItem.ToDefAll("", Space, SerilizationMode5.MultiLine));
		if (arrayList.Count > 0)
		{
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<Patterns>");
			for (int i = 0; i <= refItem.Pattern.Count - 1; i++)
			{
				arrayList.AddRange(FoamPattern.ToDef(refItem.Pattern[i], Space + 4));
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</Patterns>");
			arrayList.Add(text);
		}
		return arrayList;
	}

	public override string ToString()
	{
		return BlockName.ToString() + " - TopZ: " + TopZ + " - BottomZ: " + BottomZ;
	}
}
