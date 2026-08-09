using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileItem : buSerilization
{
	public string ItemName = "";

	public bool IsSorted = false;

	public bool IsClamperDone = false;

	public double Length = 1000.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double SupportBlockZWidth = 0.0;

	public double SupportBlockZHeight = 0.0;

	public double SupportBlockZLength = 0.0;

	public double SupportBlockY1Width = 0.0;

	public double SupportBlockY1Height = 0.0;

	public double SupportBlockY1Length = 0.0;

	public double SupportBlockY2Width = 0.0;

	public double SupportBlockY2Height = 0.0;

	public double SupportBlockY2Length = 0.0;

	public double Thickness = 1.0;

	public int MaxClamperNumber = 4;

	public MaterialSkin Skin = new MaterialSkin();

	public Vec3D Direction = new Vec3D(1.0, 0.0, 0.0);

	public Color Color = Color.DarkGray;

	public int Transparency = 120;

	public List<ProfileOperation> Operations = new List<ProfileOperation>();

	public List<eEntities> SolidEntities = new List<eEntities>();

	public List<eEntities> AuxEntities = new List<eEntities>();

	public List<eEntities> SupportBlockEntities = new List<eEntities>();

	public List<Triangle3D> Triangles = new List<Triangle3D>();

	public List<Pnt3D> OutterPoints = new List<Pnt3D>();

	public List<List<Pnt3D>> InnerPoints = new List<List<Pnt3D>>();

	public List<eEntities> OutterEntitites = new List<eEntities>();

	public List<List<eEntities>> InnerEntities = new List<List<eEntities>>();

	public List<ProfileClamper> Clampers = new List<ProfileClamper>();

	public ProfileClamperSettings ClamperSettings = new ProfileClamperSettings();

	public ProfileItem()
	{
	}

	public ProfileItem(ProfileItem data)
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
		Clampers.Clear();
		Clampers = new List<ProfileClamper>();
		for (int j = 0; j <= data.Clampers.Count - 1; j++)
		{
			Clampers.Add(new ProfileClamper(data.Clampers[j]));
		}
		ClamperSettings = new ProfileClamperSettings(data.ClamperSettings);
		SolidEntities.Clear();
		eEntities.CopyEntities(data.SolidEntities, ref SolidEntities);
		AuxEntities.Clear();
		eEntities.CopyEntities(data.AuxEntities, ref AuxEntities);
		SupportBlockEntities.Clear();
		SupportBlockEntities = new List<eEntities>();
		eEntities.CopyEntities(data.SupportBlockEntities, ref SupportBlockEntities);
		Triangles.Clear();
		Triangles = new List<Triangle3D>();
		Triangle3D.Copy(data.Triangles, ref Triangles);
		OutterPoints.Clear();
		OutterPoints = new List<Pnt3D>();
		Pnt3D.Copy(data.OutterPoints, ref OutterPoints);
		InnerPoints.Clear();
		InnerPoints = new List<List<Pnt3D>>();
		Pnt3D.Copy(data.InnerPoints, ref InnerPoints);
		OutterEntitites.Clear();
		OutterEntitites = new List<eEntities>();
		eEntities.CopyEntities(data.OutterEntitites, ref OutterEntitites);
		InnerEntities.Clear();
		InnerEntities = new List<List<eEntities>>();
		eEntities.CopyEntities(data.InnerEntities, ref InnerEntities);
		Operations = new List<ProfileOperation>();
		ProfileOperation.Copy(data.Operations, ref Operations);
	}

	public static ArrayList ToDef(List<ProfileItem> Items, int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(ToDef(Items[i], Space).ToArray());
			arrayList.AddRange(arrayList2.ToArray());
		}
		return arrayList;
	}

	public static ArrayList ToDef(ProfileItem Item, int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(Item.ToDefAll("", Space + 2, SerilizationMode.MultiLine));
		arrayList.RemoveAt(arrayList.Count - 1);
		arrayList.AddRange(ProfileOperation.ToDef(Item.Operations, "", Space + 2));
		arrayList.Add(text + "</ProfileItem>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<ProfileItem> Items)
	{
		Items.Clear();
		Items = new List<ProfileItem>();
		List<List<string>> list = new List<List<string>>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<ProfileItem>", "</ProfileItem>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			ProfileItem Item = new ProfileItem();
			Decode(arrayList, ref Item);
			Items.Add(Item);
		}
	}

	public static void Decode(ArrayList AL, ref ProfileItem Item)
	{
		Item = new ProfileItem();
		buSerilization.Decode(AL, "", SerilizationMode.MultiLine, Item);
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<ProfileOperation>", "</ProfileOperation>", AddStartEndKey: false, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			ProfileOperation OP = new ProfileOperation();
			ProfileOperation.Decode(arrayList, ref OP);
			Item.Operations.Add(OP);
		}
	}

	public override string ToString()
	{
		return ItemName.ToString() + "- Len: " + Length.ToString("f3");
	}
}
