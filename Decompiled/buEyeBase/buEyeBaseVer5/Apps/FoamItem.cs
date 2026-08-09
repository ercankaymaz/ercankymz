using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamItem : buSerilization5
{
	public string ItemName = "";

	public string FileName = "";

	public string FileNameFull = "";

	public bool isError = false;

	public bool isGCodeCreated = false;

	public bool CreatedFromDrawing = false;

	public MaterialBase5 Material = new MaterialBase5();

	public string TextureName = "";

	public Color colorFoam = Color.DarkGray;

	public int Transparency = 120;

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public Entity SolidEntity = null;

	public List<FoamBlock> BlockXZ = new List<FoamBlock>();

	public List<FoamBlock> BlockYZ = new List<FoamBlock>();

	public camTp CamXZ = new camTp();

	public camTp CamYZ = new camTp();

	public List<buEntity> sortedEntitiesYZ = new List<buEntity>();

	public List<buEntity> sortedEntitiesXZ = new List<buEntity>();

	public FoamItem()
	{
	}

	public FoamItem(FoamItem data)
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
		for (int j = 0; j <= data.BlockXZ.Count - 1; j++)
		{
			BlockXZ.Add(new FoamBlock(data.BlockXZ[j]));
		}
		for (int k = 0; k <= data.BlockYZ.Count - 1; k++)
		{
			BlockYZ.Add(new FoamBlock(data.BlockYZ[k]));
		}
		if (data.SolidEntity != null)
		{
			SolidEntity = buVector5.CopyEntities(data.SolidEntity);
		}
		CamXZ = new camTp(data.CamXZ);
		CamYZ = new camTp(data.CamYZ);
		buEntity.Copy(data.sortedEntitiesXZ, ref sortedEntitiesXZ);
		buEntity.Copy(data.sortedEntitiesYZ, ref sortedEntitiesYZ);
	}

	public static ArrayList ToDef(FoamItem refItem, int Space)
	{
		string text = "";
		ArrayList arrayList = new ArrayList();
		buSerilization5.ExceptionalVariables.Add("CamXZ");
		buSerilization5.ExceptionalVariables.Add("CamYZ");
		arrayList.AddRange(refItem.ToDefAll("", Space, SerilizationMode5.MultiLine));
		buSerilization5.ExceptionalVariables.Clear();
		if (arrayList.Count > 0)
		{
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			if (refItem.BlockXZ.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<BlocksXZ>");
				for (int i = 0; i <= refItem.BlockXZ.Count - 1; i++)
				{
					arrayList.AddRange(FoamBlock.ToDef(refItem.BlockXZ[i], Space + 4));
				}
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</BlocksXZ>");
			}
			if (refItem.BlockYZ.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<BlocksYZ>");
				for (int j = 0; j <= refItem.BlockYZ.Count - 1; j++)
				{
					arrayList.AddRange(FoamBlock.ToDef(refItem.BlockYZ[j], Space + 4));
				}
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</BlocksYZ>");
			}
			if (refItem.sortedEntitiesXZ.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<sortedEntitiesXZ>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.sortedEntitiesXZ, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</sortedEntitiesXZ>");
			}
			if (refItem.sortedEntitiesYZ.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<sortedEntitiesYZ>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.sortedEntitiesYZ, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</sortedEntitiesYZ>");
			}
			arrayList.Add(text);
		}
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref FoamItem Item)
	{
		Item = new FoamItem();
		buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, Item);
		List<List<string>> CalcList = new List<List<string>>();
		List<string> CalcList2 = new List<string>();
		List<string> CalcList3 = new List<string>();
		List<string> CalcList4 = new List<string>();
		List<List<string>> CalcList5 = new List<List<string>>();
		List<List<string>> CalcList6 = new List<List<string>>();
		buStatics.ListToSpecificList("<BlocksXZ>", "</BlocksXZ>", AddStartEndKey: false, AL, ref CalcList3);
		buStatics.ListToSpecificList("<BlocksYZ>", "</BlocksYZ>", AddStartEndKey: false, AL, ref CalcList4);
		buStatics.ListToSpecificList("<FoamBlock>", "</FoamBlock>", AddStartEndKey: true, CalcList3, ref CalcList5);
		buStatics.ListToSpecificList("<FoamBlock>", "</FoamBlock>", AddStartEndKey: true, CalcList4, ref CalcList6);
		for (int i = 0; i <= CalcList5.Count - 1; i++)
		{
			FoamBlock Item2 = new FoamBlock();
			FoamBlock.Decode(CalcList5[i], ref Item2);
			Item.BlockXZ.Add(Item2);
		}
		for (int j = 0; j <= CalcList6.Count - 1; j++)
		{
			FoamBlock Item3 = new FoamBlock();
			FoamBlock.Decode(CalcList6[j], ref Item3);
			Item.BlockYZ.Add(Item3);
		}
		CalcList2.Clear();
		CalcList.Clear();
		buStatics.ListToSpecificList("<sortedEntitiesXZ>", "</sortedEntitiesXZ>", AddStartEndKey: false, AL, ref CalcList2);
		buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList2, ref CalcList);
		for (int k = 0; k <= CalcList.Count - 1; k++)
		{
			buEntity buEntity2 = buEntity.Decode(CalcList[k]);
			if (buEntity2 != null)
			{
				Item.sortedEntitiesXZ.Add(buEntity2);
			}
		}
		CalcList2.Clear();
		CalcList.Clear();
		buStatics.ListToSpecificList("<sortedEntitiesYZ>", "</sortedEntitiesYZ>", AddStartEndKey: false, AL, ref CalcList2);
		buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList2, ref CalcList);
		for (int l = 0; l <= CalcList.Count - 1; l++)
		{
			buEntity buEntity3 = buEntity.Decode(CalcList[l]);
			if (buEntity3 != null)
			{
				Item.sortedEntitiesYZ.Add(buEntity3);
			}
		}
		CalcList2.Clear();
		CalcList3.Clear();
		CalcList4.Clear();
		CalcList5.Clear();
		CalcList6.Clear();
		AL.Clear();
		CalcList.Clear();
	}

	public override string ToString()
	{
		return ItemName.ToString();
	}
}
