using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemExtend : buSerilization5
{
	public Point3D ExtendPoint = new Point3D();

	public double ExtendLength = 0.0;

	public int CamID = -1;

	public int indexCam = -1;

	public int indexWire = -1;

	public int indexWireSub = -1;

	public StartEndType Direction = StartEndType.Start;

	public buEntity entityExtend = null;

	public MarbleItemExtend()
	{
	}

	public MarbleItemExtend(MarbleItemExtend data)
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
		if (data.entityExtend != null)
		{
			buEntity.Copy(data.entityExtend, ref entityExtend);
		}
	}

	public static void Add(MarbleItemExtend E, ref List<MarbleItemExtend> refList)
	{
		try
		{
			bool flag = false;
			int num = -1;
			for (int i = 0; i <= refList.Count - 1; i++)
			{
				if (buCompare5.EQ(refList[i].ExtendPoint, E.ExtendPoint))
				{
					flag = true;
				}
				if ((refList[i].indexCam == E.indexCam) & (refList[i].CamID == E.CamID) & (refList[i].indexWireSub == E.indexWireSub) & (refList[i].indexWire == E.indexWire) & (refList[i].Direction == E.Direction))
				{
					flag = true;
					num = i;
				}
			}
			if (flag)
			{
				if ((num >= 0) & (num <= refList.Count - 1))
				{
					refList[num] = new MarbleItemExtend(E);
				}
			}
			else
			{
				refList.Add(E);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Copy(List<MarbleItemExtend> Items, ref List<MarbleItemExtend> CopyItems)
	{
		CopyItems = new List<MarbleItemExtend>();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			CopyItems.Add(new MarbleItemExtend(Items[i]));
		}
	}

	public static ArrayList ToDef(MarbleItemExtend refItem, int Space)
	{
		ArrayList arrayList = new ArrayList();
		buSerilization5.ExceptionalVariables.Clear();
		buSerilization5.ClassToString(refItem);
		arrayList.AddRange(refItem.ToDefAll("", Space, SerilizationMode5.MultiLine));
		return arrayList;
	}

	public static void Decode(List<string> SL, ref MarbleItemExtend refItem)
	{
		try
		{
			refItem = new MarbleItemExtend();
			buSerilization5.Decode(SL, "", SerilizationMode5.MultiLine, refItem);
			new List<List<string>>();
			new List<string>();
		}
		catch (Exception)
		{
		}
	}

	public static void Decode(List<string> SL, ref List<MarbleItemExtend> refItes)
	{
		try
		{
			refItes = new List<MarbleItemExtend>();
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
					MarbleItemExtend refItem = new MarbleItemExtend();
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
		return "Point: " + ExtendPoint.ToString() + " , Len: " + ExtendLength;
	}
}
