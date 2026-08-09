using System;
using System.Collections;
using System.Collections.Generic;

namespace buClass.Apps;

[Serializable]
public class DiemakerPageProp : buSerilization
{
	public List<BendingJob> Cutting = new List<BendingJob>();

	public List<BendingJob> Creasing = new List<BendingJob>();

	public List<BendingJob> Perfo = new List<BendingJob>();

	public List<BendingJob> CutCrease = new List<BendingJob>();

	public List<eEntities> BridgeEntities = new List<eEntities>();

	public List<eEntities> NickEntities = new List<eEntities>();

	public List<eEntities> BroachEntities = new List<eEntities>();

	public List<Pnt3D> BreakPoints = new List<Pnt3D>();

	public DiemakerPageCommonProps CommonCuttingProps = new DiemakerPageCommonProps();

	public DiemakerPageCommonProps CommonCreasingProps = new DiemakerPageCommonProps();

	public DiemakerPageCommonProps CommonPerfoProps = new DiemakerPageCommonProps();

	public DiemakerPageCommonProps CommonCutCreaseProps = new DiemakerPageCommonProps();

	public DiemakerPageProp()
	{
	}

	public DiemakerPageProp(DiemakerPageProp data)
	{
		Cutting.Clear();
		Cutting = new List<BendingJob>();
		for (int i = 0; i <= data.Cutting.Count - 1; i++)
		{
			BendingJob item = new BendingJob(data.Cutting[i]);
			Cutting.Add(item);
		}
		Creasing.Clear();
		Creasing = new List<BendingJob>();
		for (int j = 0; j <= data.Creasing.Count - 1; j++)
		{
			BendingJob item2 = new BendingJob(data.Creasing[j]);
			Creasing.Add(item2);
		}
		Perfo.Clear();
		Perfo = new List<BendingJob>();
		for (int k = 0; k <= data.Perfo.Count - 1; k++)
		{
			BendingJob item3 = new BendingJob(data.Perfo[k]);
			Perfo.Add(item3);
		}
		CutCrease.Clear();
		CutCrease = new List<BendingJob>();
		for (int l = 0; l <= data.CutCrease.Count - 1; l++)
		{
			BendingJob item4 = new BendingJob(data.CutCrease[l]);
			CutCrease.Add(item4);
		}
		BridgeEntities.Clear();
		BridgeEntities = new List<eEntities>();
		for (int m = 0; m <= data.BridgeEntities.Count - 1; m++)
		{
			eEntities item5 = new eEntities();
			eEntities.CopyEntity(data.BridgeEntities[m]);
			BridgeEntities.Add(item5);
		}
		NickEntities.Clear();
		NickEntities = new List<eEntities>();
		for (int n = 0; n <= data.NickEntities.Count - 1; n++)
		{
			eEntities item6 = new eEntities();
			eEntities.CopyEntity(data.NickEntities[n]);
			NickEntities.Add(item6);
		}
		BroachEntities.Clear();
		BroachEntities = new List<eEntities>();
		for (int num = 0; num <= data.BroachEntities.Count - 1; num++)
		{
			eEntities item7 = new eEntities();
			eEntities.CopyEntity(data.BroachEntities[num]);
			BroachEntities.Add(item7);
		}
		CommonCuttingProps = new DiemakerPageCommonProps(data.CommonCuttingProps);
		CommonCreasingProps = new DiemakerPageCommonProps(data.CommonCreasingProps);
		CommonPerfoProps = new DiemakerPageCommonProps(data.CommonPerfoProps);
		CommonCutCreaseProps = new DiemakerPageCommonProps(data.CommonCutCreaseProps);
	}

	public ArrayList ToDef(int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buSystem.strSpace2 + "<DiemakerProps>");
		arrayList.Add(buSystem.strSpace4 + "<CuttingProps>");
		for (int i = 0; i <= Cutting.Count - 1; i++)
		{
			arrayList.AddRange(BendingJob.ToDef(Cutting[i], 4));
		}
		arrayList.Add(buSystem.strSpace4 + "</CuttingProps>");
		arrayList.Add(buSystem.strSpace4 + "<CreasingProps>");
		for (int j = 0; j <= Creasing.Count - 1; j++)
		{
			arrayList.AddRange(BendingJob.ToDef(Creasing[j], 4));
		}
		arrayList.Add(buSystem.strSpace4 + "</CreasingProps>");
		arrayList.Add(buSystem.strSpace4 + "<PerfoProps>");
		for (int k = 0; k <= Perfo.Count - 1; k++)
		{
			arrayList.AddRange(BendingJob.ToDef(Perfo[k], 4));
		}
		arrayList.Add(buSystem.strSpace4 + "</PerfoProps>");
		arrayList.Add(buSystem.strSpace4 + "<CutCreaseProps>");
		for (int l = 0; l <= CutCrease.Count - 1; l++)
		{
			arrayList.AddRange(BendingJob.ToDef(CutCrease[l], 4));
		}
		arrayList.Add(buSystem.strSpace4 + "</CutCreaseProps>");
		arrayList.Add(buSystem.strSpace4 + "<BridgeEntities>");
		for (int m = 0; m <= BridgeEntities.Count - 1; m++)
		{
			arrayList.AddRange(BridgeEntities[m].ToDefAll(6));
		}
		arrayList.Add(buSystem.strSpace4 + "</BridgeEntities>");
		arrayList.Add(buSystem.strSpace4 + "<NickEntities>");
		for (int n = 0; n <= NickEntities.Count - 1; n++)
		{
			arrayList.AddRange(NickEntities[n].ToDefAll(6));
		}
		arrayList.Add(buSystem.strSpace4 + "</NickEntities>");
		arrayList.Add(buSystem.strSpace4 + "<BroachEntities>");
		for (int num = 0; num <= BroachEntities.Count - 1; num++)
		{
			arrayList.AddRange(BroachEntities[num].ToDefAll(6));
		}
		arrayList.Add(buSystem.strSpace4 + "</BroachEntities>");
		arrayList.AddRange(CommonCuttingProps.ToDefAll("CommonCutting", 4, SerilizationMode.MultiLine).ToArray());
		arrayList.AddRange(CommonCreasingProps.ToDefAll("CommonCreasing", 4, SerilizationMode.MultiLine).ToArray());
		arrayList.AddRange(CommonPerfoProps.ToDefAll("CommonPerfo", 4, SerilizationMode.MultiLine).ToArray());
		arrayList.AddRange(CommonCutCreaseProps.ToDefAll("CommonCutCrease", 4, SerilizationMode.MultiLine).ToArray());
		arrayList.Add(buSystem.strSpace2 + "</DiemakerProps>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref DiemakerPageProp Diemaker)
	{
		List<List<string>> CalcList = new List<List<string>>();
		List<List<string>> CalcList2 = new List<List<string>>();
		List<List<string>> CalcList3 = new List<List<string>>();
		List<List<string>> CalcList4 = new List<List<string>>();
		List<List<string>> list = new List<List<string>>();
		List<List<string>> list2 = new List<List<string>>();
		buStatics.ListToSpecificList("<DiemakerProps>", "</DiemakerProps>", AddStartEndKey: true, AL, ref CalcList);
		if (CalcList.Count <= 0)
		{
			return;
		}
		Diemaker = new DiemakerPageProp();
		buStatics.ListToSpecificList("<CuttingProps>", "</CuttingProps>", AddStartEndKey: true, CalcList[0], ref CalcList2);
		if (CalcList2.Count > 0)
		{
			List<List<string>> CalcList5 = new List<List<string>>();
			buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", AddStartEndKey: true, CalcList2[0], ref CalcList5);
			for (int i = 0; i <= CalcList5.Count - 1; i++)
			{
				BendingJob Job = new BendingJob();
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(CalcList5[i].ToArray());
				BendingJob.Decode(arrayList, ref Job);
				Diemaker.Cutting.Add(Job);
			}
		}
		buStatics.ListToSpecificList("<CreasingProps>", "</CreasingProps>", AddStartEndKey: true, CalcList[0], ref CalcList3);
		if (CalcList3.Count > 0)
		{
			List<List<string>> CalcList6 = new List<List<string>>();
			buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", AddStartEndKey: true, CalcList3[0], ref CalcList6);
			for (int j = 0; j <= CalcList6.Count - 1; j++)
			{
				BendingJob Job2 = new BendingJob();
				ArrayList arrayList2 = new ArrayList();
				arrayList2.AddRange(CalcList6[j].ToArray());
				BendingJob.Decode(arrayList2, ref Job2);
				Diemaker.Creasing.Add(Job2);
			}
		}
		buStatics.ListToSpecificList("<PerfoProps>", "</PerfoProps>", AddStartEndKey: true, CalcList[0], ref CalcList4);
		if (CalcList4.Count > 0)
		{
			List<List<string>> CalcList7 = new List<List<string>>();
			buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", AddStartEndKey: true, CalcList4[0], ref CalcList7);
			for (int k = 0; k <= CalcList7.Count - 1; k++)
			{
				BendingJob Job3 = new BendingJob();
				ArrayList arrayList3 = new ArrayList();
				arrayList3.AddRange(CalcList7[k].ToArray());
				BendingJob.Decode(arrayList3, ref Job3);
				Diemaker.Perfo.Add(Job3);
			}
		}
		buStatics.ListToSpecificList("<CutCreaseProps>", "</CutCreaseProps>", AddStartEndKey: true, CalcList[0], ref CalcList4);
		if (CalcList4.Count > 0)
		{
			List<List<string>> CalcList8 = new List<List<string>>();
			buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", AddStartEndKey: true, CalcList4[0], ref CalcList8);
			for (int l = 0; l <= CalcList8.Count - 1; l++)
			{
				BendingJob Job4 = new BendingJob();
				ArrayList arrayList4 = new ArrayList();
				arrayList4.AddRange(CalcList8[l].ToArray());
				BendingJob.Decode(arrayList4, ref Job4);
				Diemaker.Perfo.Add(Job4);
			}
		}
		list2 = new List<List<string>>();
		buStatics.ListToSpecificList("<BridgeEntities>", "</BridgeEntities>", AddStartEndKey: true, CalcList[0], ref list2);
		for (int m = 0; m <= list2.Count - 1; m++)
		{
			List<List<string>> CalcList9 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list2[m], ref CalcList9);
			for (int n = 0; n <= CalcList9.Count - 1; n++)
			{
				eEntities eEntities2 = new eEntities();
				eEntities2 = eEntities.Decode(CalcList9[n], "", SerilizationMode.MultiLine);
				Diemaker.BridgeEntities.Add(eEntities2);
			}
		}
		list2 = new List<List<string>>();
		buStatics.ListToSpecificList("<NickEntities>", "</NickEntities>", AddStartEndKey: true, CalcList[0], ref list2);
		for (int num = 0; num <= list2.Count - 1; num++)
		{
			List<List<string>> CalcList10 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list2[num], ref CalcList10);
			for (int num2 = 0; num2 <= CalcList10.Count - 1; num2++)
			{
				eEntities eEntities3 = new eEntities();
				eEntities3 = eEntities.Decode(CalcList10[num2], "", SerilizationMode.MultiLine);
				Diemaker.NickEntities.Add(eEntities3);
			}
		}
		list2 = new List<List<string>>();
		buStatics.ListToSpecificList("<BroachEntities>", "</BroachEntities>", AddStartEndKey: true, CalcList[0], ref list2);
		for (int num3 = 0; num3 <= list2.Count - 1; num3++)
		{
			List<List<string>> CalcList11 = new List<List<string>>();
			buStatics.ListToSpecificList("<eEntities>", "</eEntities>", AddStartEndKey: true, list2[num3], ref CalcList11);
			for (int num4 = 0; num4 <= CalcList11.Count - 1; num4++)
			{
				eEntities eEntities4 = new eEntities();
				eEntities4 = eEntities.Decode(CalcList11[num4], "", SerilizationMode.MultiLine);
				Diemaker.BroachEntities.Add(eEntities4);
			}
		}
	}
}
