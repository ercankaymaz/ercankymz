using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestedPart : buSerilization5
{
	public Vec3D MovedDistance = new Vec3D();

	public double RotateValue = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Thickness = 2.0;

	public double PartArea = 0.0;

	public double TotalOutSideLength = 0.0;

	public double TotalInsideLength = 0.0;

	public double TotalLength = 0.0;

	public string Name = "";

	public int GroupCount = 1;

	public int ID = -1;

	public string ItemNo = "";

	public string SalesNo = "";

	public string Other = "";

	public string Aux = "";

	public double UserData = 0.0;

	public string SequenceChar = "";

	public bool isMirror = false;

	public Color Color = Color.Linen;

	public nestPartRotateType Rotation = nestPartRotateType.Increment90;

	public buEntitiesGroup EntitiesGroup = new buEntitiesGroup();

	public buNestedPart()
	{
	}

	public buNestedPart(buNestedPart data)
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
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		MovedDistance = new Vec3D(data.MovedDistance);
		if (data.EntitiesGroup != null)
		{
			EntitiesGroup = new buEntitiesGroup(data.EntitiesGroup);
		}
	}

	public static buNestedPart FromNestingPart(buNestingPart data)
	{
		buNestedPart buNestedPart2 = new buNestedPart();
		buNestedPart2.Aux = data.PartData.Aux;
		buNestedPart2.Width = data.PartData.Width;
		buNestedPart2.Height = data.PartData.Height;
		buNestedPart2.SalesNo = data.PartData.SalesNo;
		buNestedPart2.ItemNo = data.PartData.ItemNo;
		buNestedPart2.Other = data.PartData.Other;
		buNestedPart2.UserData = data.PartData.UserData;
		buNestedPart2.Thickness = data.PartData.Thickness;
		buNestedPart2.Name = data.PartData.Name;
		buNestedPart2.Rotation = data.PartData.Rotation;
		buNestedPart2.ID = data.ID;
		buNestedPart2.EntitiesGroup = new buEntitiesGroup(data.EntitiesGroup);
		return buNestedPart2;
	}

	public override string ToString()
	{
		return "DX: " + MovedDistance.X + " , DY: " + MovedDistance.Y + " , Rotate: " + Rotation;
	}

	public static ArrayList ToDef(List<buNestedPart> NestedParts, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<buNestedParts>");
		for (int i = 0; i <= NestedParts.Count - 1; i++)
		{
			string text = "";
			arrayList.AddRange(NestedParts[i].ToDefAll("", 2 + Space, SerilizationMode5.MultiLine));
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			if (NestedParts[i].EntitiesGroup.Outside.Entities.Count > 0)
			{
				arrayList.AddRange(buEntitiesGroup.ToDefGroup(NestedParts[i].EntitiesGroup, Space + 4, "NestedPart"));
			}
			arrayList.Add(text);
		}
		arrayList.Add(buString5.SpaceChar(Space) + "</buNestedParts>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<buNestedPart> Parts)
	{
		Parts.Clear();
		Parts = new List<buNestedPart>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<buNestedPart>", "</buNestedPart>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			List<string> CalcList2 = new List<string>();
			arrayList.AddRange(CalcList[i].ToArray());
			buNestedPart buNestedPart2 = new buNestedPart();
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buNestedPart2);
			buStatics.ListToSpecificList("<buEntitiesGroupDataNestedPart>", "</buEntitiesGroupDataNestedPart>", AddStartEndKey: true, arrayList, ref CalcList2);
			buEntitiesGroup.Decode(CalcList2, ref buNestedPart2.EntitiesGroup);
			buCall.buNestingCalc_0.CreatePointAndSolidFromEntityGroup(ref buNestedPart2.EntitiesGroup);
			Parts.Add(buNestedPart2);
			arrayList.Clear();
			CalcList2.Clear();
		}
		CalcList.Clear();
	}
}
