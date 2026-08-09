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
public class FoamPattern : buSerilization5
{
	public string PatternName = "";

	public int ID = -1;

	public Point3D BoxMinItem = new Point3D();

	public Point3D BoxMaxItem = new Point3D();

	public List<buEntity> sortEntities = new List<buEntity>();

	public List<FoamEntities> foamEntities = new List<FoamEntities>();

	public FoamPatternInfo Info = new FoamPatternInfo();

	public Color Color = Color.Lime;

	public int Transparency = 120;

	public List<Entity> SolidEntities = null;

	public Plane planeOperation = new Plane();

	public FoamPlaneType planeName = FoamPlaneType.XZ;

	public FoamType Type = FoamType.Shape;

	public FoamOperationType GroupType = FoamOperationType.Wave;

	public int HorizontalIndex = -1;

	public int VerticalIndex = -1;

	public bool isError = false;

	public bool Calculated = false;

	public bool Enable = true;

	public bool isReverse = false;

	public double Width = 0.0;

	public double Height = 0.0;

	public Point3D Offset = new Point3D();

	public FoamPattern()
	{
	}

	public FoamPattern(FoamPattern data)
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
		if (data.SolidEntities != null)
		{
			SolidEntities = buVector5.CopyEntities(data.SolidEntities);
		}
		buEntity.Copy(data.sortEntities, ref sortEntities);
		Offset = buVector5.ToPoint3D(data.Offset);
		if (data.foamEntities != null)
		{
			foamEntities = new List<FoamEntities>();
			for (int j = 0; j <= data.foamEntities.Count - 1; j++)
			{
				foamEntities.Add(new FoamEntities(data.foamEntities[j]));
			}
		}
		BoxMinItem = buVector5.ToPoint3D(data.BoxMinItem);
		BoxMaxItem = buVector5.ToPoint3D(data.BoxMaxItem);
		planeOperation = (Plane)data.planeOperation.Clone();
	}

	public static ArrayList ToDef(FoamPattern refItem, int Space)
	{
		string text = "";
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(refItem.ToDefAll("", Space, SerilizationMode5.MultiLine));
		if (arrayList.Count > 0)
		{
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<sortEntities>");
			arrayList.AddRange(buEntity.ToDefEntity(refItem.sortEntities, Space + 4));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</sortEntities>");
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<foamEntitiesAll>");
			for (int i = 0; i <= refItem.foamEntities.Count - 1; i++)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<foamEntities>");
				arrayList.Add(buString5.SpaceChar(Space + 6) + "<foamEntitiesOutsideEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.foamEntities[i].GroupEntity.Outside.Entities, Space + 8));
				arrayList.Add(buString5.SpaceChar(Space + 6) + "</foamEntitiesOutsideEntities>");
				arrayList.Add(buString5.SpaceChar(Space + 6) + "<foamEntitiesInsideEntities>");
				for (int j = 0; j <= refItem.foamEntities[i].GroupEntity.Inside.Count - 1; j++)
				{
					arrayList.Add(buString5.SpaceChar(Space + 8) + "<foamEntitiesInsideEntitiesItem>");
					arrayList.AddRange(buEntityList.ToDefEntity(refItem.foamEntities[i].GroupEntity.Inside, Space + 10));
					arrayList.Add(buString5.SpaceChar(Space + 8) + "</foamEntitiesInsideEntitiesItem>");
				}
				arrayList.Add(buString5.SpaceChar(Space + 6) + "</foamEntitiesInsideEntities>");
				arrayList.Add(buString5.SpaceChar(Space + 6) + "</foamEntities>");
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</foamEntitiesAll>");
			arrayList.Add(text);
		}
		return arrayList;
	}

	public static void Decode(List<string> AL, ref FoamPattern Item)
	{
		Item = new FoamPattern();
		buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, Item);
		List<List<string>> CalcList = new List<List<string>>();
		List<string> CalcList2 = new List<string>();
		buStatics.ListToSpecificList("<sortEntities>", "</sortEntities>", AddStartEndKey: false, AL, ref CalcList2);
		buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList2, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			buEntity buEntity2 = buEntity.Decode(CalcList[i]);
			if (buEntity2 != null)
			{
				Item.sortEntities.Add(buEntity2);
			}
		}
		CalcList2 = new List<string>();
		List<List<string>> CalcList3 = new List<List<string>>();
		buStatics.ListToSpecificList("<foamEntitiesAll>", "</foamEntitiesAll>", AddStartEndKey: false, AL, ref CalcList2);
		buStatics.ListToSpecificList("<foamEntities>", "</foamEntities>", AddStartEndKey: false, CalcList2, ref CalcList3);
		for (int j = 0; j <= CalcList3.Count - 1; j++)
		{
			FoamEntities foamEntities = new FoamEntities();
			List<List<string>> list = new List<List<string>>();
			CalcList2.Clear();
			CalcList.Clear();
			buStatics.ListToSpecificList("<foamEntitiesOutsideEntities>", "</foamEntitiesOutsideEntities>", AddStartEndKey: false, CalcList3[j], ref CalcList2);
			buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList2, ref CalcList);
			for (int k = 0; k <= CalcList.Count - 1; k++)
			{
				buEntity buEntity3 = buEntity.Decode(CalcList[k]);
				if (buEntity3 != null)
				{
					foamEntities.GroupEntity.Outside.Entities.Add(buEntity3);
				}
			}
			CalcList2.Clear();
			buStatics.ListToSpecificList("<foamEntitiesInsideEntitiesItem>", "</foamEntitiesInsideEntitiesItem>", AddStartEndKey: false, CalcList3[j], ref CalcList2);
			for (int l = 0; l <= list.Count - 1; l++)
			{
				CalcList.Clear();
				CalcList = new List<List<string>>();
				buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, list[l], ref CalcList);
				List<buEntity> list2 = new List<buEntity>();
				for (int m = 0; m <= CalcList.Count - 1; m++)
				{
					buEntity buEntity4 = buEntity.Decode(CalcList[m]);
					if (buEntity4 != null)
					{
						list2.Add(buEntity4);
					}
				}
				if (list2.Count <= 0)
				{
				}
			}
			Item.foamEntities.Add(foamEntities);
		}
	}
}
