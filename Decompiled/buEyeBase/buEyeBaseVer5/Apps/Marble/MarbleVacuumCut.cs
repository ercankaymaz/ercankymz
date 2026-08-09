using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleVacuumCut : buSerilization5
{
	public Point3D StartPoint = new Point3D();

	public Point3D EndPoint = new Point3D();

	public Entity VacuumCutDrawEntity = null;

	public buEntity VacuumCutEntity = null;

	public double OffsetX = 0.0;

	public double OffsetY = 0.0;

	public double MoveX = 0.0;

	public double MoveY = 0.0;

	public double RotateC = 0.0;

	public int VacuumID = -1;

	public bool Selected = false;

	public HorizontalVertical Direction = HorizontalVertical.Horizontal;

	public MarbleVacuumCut()
	{
	}

	public MarbleVacuumCut(MarbleVacuumCut data)
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
		if (data.VacuumCutEntity != null)
		{
			buEntity.Copy(data.VacuumCutEntity, ref VacuumCutEntity);
		}
		if (data.VacuumCutDrawEntity != null)
		{
			buEntity.Copy(data.VacuumCutDrawEntity, ref VacuumCutDrawEntity);
		}
	}

	public static void Copy(List<MarbleVacuumCut> Items, ref List<MarbleVacuumCut> CopyItems)
	{
		CopyItems = new List<MarbleVacuumCut>();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			CopyItems.Add(new MarbleVacuumCut(Items[i]));
		}
	}

	public static ArrayList ToDef(MarbleVacuumCut refItem, int Space)
	{
		ArrayList arrayList = new ArrayList();
		buSerilization5.ExceptionalVariables.Clear();
		buSerilization5.ClassToString(refItem);
		arrayList.AddRange(refItem.ToDefAll("", Space, SerilizationMode5.MultiLine));
		return arrayList;
	}

	public static void Decode(List<string> SL, ref MarbleVacuumCut refItem)
	{
		try
		{
			refItem = new MarbleVacuumCut();
			buSerilization5.Decode(SL, "", SerilizationMode5.MultiLine, refItem);
			new List<List<string>>();
			new List<string>();
		}
		catch (Exception)
		{
		}
	}

	public static void Decode(List<string> SL, ref List<MarbleVacuumCut> refItes)
	{
		try
		{
			refItes = new List<MarbleVacuumCut>();
			if (SL.Count <= 0)
			{
				return;
			}
			List<List<string>> CalcList = new List<List<string>>();
			buStatics.ListToSpecificList("<MarbleVacuumCut>", "</MarbleVacuumCut>", AddStartEndKey: true, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				for (int i = 0; i <= CalcList.Count - 1; i++)
				{
					MarbleVacuumCut refItem = new MarbleVacuumCut();
					Decode(CalcList[i], ref refItem);
					refItes.Add(refItem);
					CalcList[i].Clear();
				}
				CalcList.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		return "Start: " + StartPoint.ToString() + " , End: " + EndPoint.ToString();
	}
}
