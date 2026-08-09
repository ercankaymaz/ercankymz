using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendingJob : buSerilization
{
	public List<eEntities> EntityList = new List<eEntities>();

	public List<eEntities> ExtractEntityList = new List<eEntities>();

	public List<eEntities> MirrorEntityList = new List<eEntities>();

	public List<eEntities> SameEntityList = new List<eEntities>();

	public List<eEntities> SelectedEntityList = new List<eEntities>();

	public List<Pnt3D> SortedPoints = new List<Pnt3D>();

	public List<int> MainEntityIndex = new List<int>();

	public List<BridgeItem> Bridges = new List<BridgeItem>();

	public List<BendMarkItem> BendMarks = new List<BendMarkItem>();

	public List<NickItem> Nicks = new List<NickItem>();

	public List<BendItem> Bends = new List<BendItem>();

	public List<BroachItem> Broachs = new List<BroachItem>();

	public List<PerfoCombiItem> PerfoCombiList = new List<PerfoCombiItem>();

	public CreasingCornerItem CreasingCorner = new CreasingCornerItem(LeftEnable_: false, 2.0, 5.0, new Pnt3D(), RightEnable_: false, 2.0, 5.0, new Pnt3D());

	public HalfBridgeItem HalfBridge = new HalfBridgeItem(LeftEnable_: false, 2.0, 5.0, new Pnt3D(), RightEnable_: false, 2.0, 5.0, new Pnt3D());

	public StartCutItem StartCut = new StartCutItem();

	public EndCutItem EndCut = new EndCutItem();

	public Lipping LippingProperties = new Lipping();

	public BendingJobInformation Information = new BendingJobInformation();

	public bool HasSent;

	public bool ErrorJob = false;

	public string ErrorExplanation = "";

	public bool isClosed;

	public bool Selected = false;

	public double OffsetRight;

	public double OffsetLeft;

	public DiemakerType MaterialType = DiemakerType.None;

	public bool ReverseBending = false;

	public bool TrimCutPress = true;

	public bool DownTrimCut = false;

	public bool UpTrimCut = false;

	public DiemakerOperationType OperationType = DiemakerOperationType.Cutting;

	public BendingJob()
	{
	}

	public BendingJob(BendingJob data)
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
		CreasingCorner = new CreasingCornerItem(data.CreasingCorner);
		HalfBridge = new HalfBridgeItem(data.HalfBridge);
		Bridges = new List<BridgeItem>();
		for (int j = 0; j <= data.Bridges.Count - 1; j++)
		{
			BridgeItem item = new BridgeItem(data.Bridges[j]);
			Bridges.Add(item);
		}
		Bends = new List<BendItem>();
		for (int k = 0; k <= data.Bends.Count - 1; k++)
		{
			BendItem item2 = new BendItem(data.Bends[k]);
			Bends.Add(item2);
		}
		Nicks = new List<NickItem>();
		for (int l = 0; l <= data.Nicks.Count - 1; l++)
		{
			NickItem item3 = new NickItem(data.Nicks[l]);
			Nicks.Add(item3);
		}
		Broachs = new List<BroachItem>();
		for (int m = 0; m <= data.Broachs.Count - 1; m++)
		{
			BroachItem item4 = new BroachItem(data.Broachs[m]);
			Broachs.Add(item4);
		}
		BendMarks = new List<BendMarkItem>();
		for (int n = 0; n <= data.BendMarks.Count - 1; n++)
		{
			BendMarkItem item5 = new BendMarkItem(data.BendMarks[n]);
			BendMarks.Add(item5);
		}
		PerfoCombiList = new List<PerfoCombiItem>();
		for (int num = 0; num <= data.PerfoCombiList.Count - 1; num++)
		{
			PerfoCombiItem item6 = new PerfoCombiItem(data.PerfoCombiList[num]);
			PerfoCombiList.Add(item6);
		}
		EntityList = new List<eEntities>();
		for (int num2 = 0; num2 <= data.EntityList.Count - 1; num2++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(data.EntityList[num2], ref copiedEnt);
			EntityList.Add(copiedEnt);
		}
		ExtractEntityList = new List<eEntities>();
		for (int num3 = 0; num3 <= data.ExtractEntityList.Count - 1; num3++)
		{
			eEntities copiedEnt2 = new eEntities();
			eEntities.CopyEntity(data.ExtractEntityList[num3], ref copiedEnt2);
			ExtractEntityList.Add(copiedEnt2);
		}
		MirrorEntityList = new List<eEntities>();
		for (int num4 = 0; num4 <= data.MirrorEntityList.Count - 1; num4++)
		{
			eEntities copiedEnt3 = new eEntities();
			eEntities.CopyEntity(data.MirrorEntityList[num4], ref copiedEnt3);
			MirrorEntityList.Add(copiedEnt3);
		}
		SameEntityList = new List<eEntities>();
		for (int num5 = 0; num5 <= data.SameEntityList.Count - 1; num5++)
		{
			eEntities copiedEnt4 = new eEntities();
			eEntities.CopyEntity(data.SameEntityList[num5], ref copiedEnt4);
			SameEntityList.Add(copiedEnt4);
		}
		SelectedEntityList = new List<eEntities>();
		for (int num6 = 0; num6 <= data.SelectedEntityList.Count - 1; num6++)
		{
			eEntities copiedEnt5 = new eEntities();
			eEntities.CopyEntity(data.SelectedEntityList[num6], ref copiedEnt5);
			SelectedEntityList.Add(copiedEnt5);
		}
	}

	public override string ToString()
	{
		return "Type : " + OperationType.ToString() + " , Calc Len: " + Information.CalculatedLength.ToString("f2");
	}

	public static ArrayList ToDef(BendingJob Job, int Space)
	{
		ArrayList arrayList = new ArrayList();
		string text = "";
		arrayList.AddRange(Job.ToDefAll("", 2 + Space, SerilizationMode.MultiLine));
		text = arrayList[arrayList.Count - 1].ToString();
		arrayList.RemoveAt(arrayList.Count - 1);
		arrayList.Add(buSystem.strSpace8 + "<BridgeItems>");
		for (int i = 0; i <= Job.Bridges.Count - 1; i++)
		{
			arrayList.AddRange(Job.Bridges[i].ToDefAll("", 10, SerilizationMode.MultiLine));
		}
		arrayList.Add(buSystem.strSpace8 + "</BridgeItems>");
		arrayList.Add(buSystem.strSpace8 + "<BendMarkItems>");
		for (int j = 0; j <= Job.BendMarks.Count - 1; j++)
		{
			arrayList.AddRange(Job.BendMarks[j].ToDefAll("", 10, SerilizationMode.MultiLine));
		}
		arrayList.Add(buSystem.strSpace8 + "</BendMarkItems>");
		arrayList.Add(buSystem.strSpace8 + "<NickItems>");
		for (int k = 0; k <= Job.Nicks.Count - 1; k++)
		{
			arrayList.AddRange(Job.Nicks[k].ToDefAll("", 10, SerilizationMode.MultiLine));
		}
		arrayList.Add(buSystem.strSpace8 + "</NickItems>");
		arrayList.Add(buSystem.strSpace8 + "<BendingItems>");
		for (int l = 0; l <= Job.Bends.Count - 1; l++)
		{
			arrayList.AddRange(Job.Bends[l].ToDefAll("", 10, SerilizationMode.MultiLine));
		}
		arrayList.Add(buSystem.strSpace8 + "</BendingItems>");
		arrayList.Add(buSystem.strSpace8 + "<BroachItems>");
		for (int m = 0; m <= Job.Broachs.Count - 1; m++)
		{
			arrayList.AddRange(Job.Broachs[m].ToDefAll("", 10, SerilizationMode.MultiLine));
		}
		arrayList.Add(buSystem.strSpace8 + "</BroachItems>");
		arrayList.Add(buSystem.strSpace8 + "<PerfoCombiListItems>");
		for (int n = 0; n <= Job.PerfoCombiList.Count - 1; n++)
		{
			arrayList.AddRange(Job.PerfoCombiList[n].ToDefAll("", 10, SerilizationMode.MultiLine));
		}
		arrayList.Add(buSystem.strSpace8 + "</PerfoCombiListItems>");
		arrayList.Add(buSystem.strSpace8 + "<EntityList>");
		for (int num = 0; num <= Job.EntityList.Count - 1; num++)
		{
			arrayList.AddRange(Job.EntityList[num].ToDefAll(10));
		}
		arrayList.Add(buSystem.strSpace8 + "</EntityList>");
		arrayList.Add(buSystem.strSpace8 + "<ExtractEntityList>");
		for (int num2 = 0; num2 <= Job.ExtractEntityList.Count - 1; num2++)
		{
			arrayList.AddRange(Job.ExtractEntityList[num2].ToDefAll(10));
		}
		arrayList.Add(buSystem.strSpace8 + "</ExtractEntityList>");
		arrayList.Add(buSystem.strSpace8 + "<MirrorEntityList>");
		for (int num3 = 0; num3 <= Job.MirrorEntityList.Count - 1; num3++)
		{
			arrayList.AddRange(Job.MirrorEntityList[num3].ToDefAll(10));
		}
		arrayList.Add(buSystem.strSpace8 + "</MirrorEntityList>");
		arrayList.Add(buSystem.strSpace8 + "<SameEntityList>");
		for (int num4 = 0; num4 <= Job.SameEntityList.Count - 1; num4++)
		{
			arrayList.AddRange(Job.SameEntityList[num4].ToDefAll(10));
		}
		arrayList.Add(buSystem.strSpace8 + "</SameEntityList>");
		arrayList.Add(buSystem.strSpace8 + "<SelectedEntityList>");
		for (int num5 = 0; num5 <= Job.SelectedEntityList.Count - 1; num5++)
		{
			arrayList.AddRange(Job.SelectedEntityList[num5].ToDefAll(10));
		}
		arrayList.Add(buSystem.strSpace8 + "</SelectedEntityList>");
		arrayList.Add(text);
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref BendingJob Job)
	{
		Job = new BendingJob();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", AddStartEndKey: true, AL, ref CalcList);
		if (CalcList.Count <= 0)
		{
			return;
		}
		List<List<string>> list = new List<List<string>>();
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(CalcList[0].ToArray());
		buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, Job);
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<BridgeItem>", "</BridgeItem>", AddStartEndKey: true, arrayList, ref list);
		for (int i = 0; i <= list.Count - 1; i++)
		{
			object obj = new BridgeItem();
			buSerilization.Decode(list[i], "", SerilizationMode.MultiLine, obj);
			Job.Bridges.Add((BridgeItem)obj);
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<BendMarkItem>", "</BendMarkItem>", AddStartEndKey: true, arrayList, ref list);
		for (int j = 0; j <= list.Count - 1; j++)
		{
			object obj2 = new BendMarkItem();
			buSerilization.Decode(list[j], "", SerilizationMode.MultiLine, obj2);
			Job.BendMarks.Add((BendMarkItem)obj2);
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<NickItem>", "</NickItem>", AddStartEndKey: true, arrayList, ref list);
		for (int k = 0; k <= list.Count - 1; k++)
		{
			object obj3 = new NickItem();
			buSerilization.Decode(list[k], "", SerilizationMode.MultiLine, obj3);
			Job.Nicks.Add((NickItem)obj3);
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<BendItem>", "</BendItem>", AddStartEndKey: true, arrayList, ref list);
		for (int l = 0; l <= list.Count - 1; l++)
		{
			object obj4 = new BendItem();
			buSerilization.Decode(list[l], "", SerilizationMode.MultiLine, obj4);
			Job.Bends.Add((BendItem)obj4);
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<BroachItem>", "</BroachItem>", AddStartEndKey: true, arrayList, ref list);
		for (int m = 0; m <= list.Count - 1; m++)
		{
			object obj5 = new BroachItem();
			buSerilization.Decode(list[m], "", SerilizationMode.MultiLine, obj5);
			Job.Broachs.Add((BroachItem)obj5);
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<PerfoCombiItem>", "</PerfoCombiItem>", AddStartEndKey: true, arrayList, ref list);
		for (int n = 0; n <= list.Count - 1; n++)
		{
			object obj6 = new PerfoCombiItem();
			buSerilization.Decode(list[n], "", SerilizationMode.MultiLine, obj6);
			Job.PerfoCombiList.Add((PerfoCombiItem)obj6);
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<EntityList>", "</EntityList>", AddStartEndKey: true, arrayList, ref list);
		for (int num = 0; num <= list.Count - 1; num++)
		{
			List<List<string>> CalcList2 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list[num], ref CalcList2);
			for (int num2 = 0; num2 <= CalcList2.Count - 1; num2++)
			{
				eEntities eEntities2 = new eEntities();
				eEntities2 = eEntities.Decode(CalcList2[num2], "", SerilizationMode.MultiLine);
				Job.EntityList.Add(eEntities2);
			}
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<ExtractEntityList>", "</ExtractEntityList>", AddStartEndKey: true, arrayList, ref list);
		for (int num3 = 0; num3 <= list.Count - 1; num3++)
		{
			List<List<string>> CalcList3 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list[num3], ref CalcList3);
			for (int num4 = 0; num4 <= CalcList3.Count - 1; num4++)
			{
				eEntities eEntities3 = new eEntities();
				eEntities3 = eEntities.Decode(CalcList3[num4], "", SerilizationMode.MultiLine);
				Job.ExtractEntityList.Add(eEntities3);
			}
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<MirrorEntityList>", "</MirrorEntityList>", AddStartEndKey: true, arrayList, ref list);
		for (int num5 = 0; num5 <= list.Count - 1; num5++)
		{
			List<List<string>> CalcList4 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list[num5], ref CalcList4);
			for (int num6 = 0; num6 <= CalcList4.Count - 1; num6++)
			{
				eEntities eEntities4 = new eEntities();
				eEntities4 = eEntities.Decode(CalcList4[num6], "", SerilizationMode.MultiLine);
				Job.MirrorEntityList.Add(eEntities4);
			}
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<SameEntityList>", "</SameEntityList>", AddStartEndKey: true, arrayList, ref list);
		for (int num7 = 0; num7 <= list.Count - 1; num7++)
		{
			List<List<string>> CalcList5 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list[num7], ref CalcList5);
			for (int num8 = 0; num8 <= CalcList5.Count - 1; num8++)
			{
				eEntities eEntities5 = new eEntities();
				eEntities5 = eEntities.Decode(CalcList5[num8], "", SerilizationMode.MultiLine);
				Job.SameEntityList.Add(eEntities5);
			}
		}
		list = new List<List<string>>();
		buStatics.ListToSpecificList("<SelectedEntityList>", "</SelectedEntityList>", AddStartEndKey: true, arrayList, ref list);
		for (int num9 = 0; num9 <= list.Count - 1; num9++)
		{
			List<List<string>> CalcList6 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list[num9], ref CalcList6);
			for (int num10 = 0; num10 <= CalcList6.Count - 1; num10++)
			{
				eEntities eEntities6 = new eEntities();
				eEntities6 = eEntities.Decode(CalcList6[num10], "", SerilizationMode.MultiLine);
				Job.SelectedEntityList.Add(eEntities6);
			}
		}
	}
}
