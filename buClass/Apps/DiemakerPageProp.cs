// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerPageProp
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
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
    this.Cutting.Clear();
    this.Cutting = new List<BendingJob>();
    for (int index = 0; index <= data.Cutting.Count - 1; ++index)
      this.Cutting.Add(new BendingJob(data.Cutting[index]));
    this.Creasing.Clear();
    this.Creasing = new List<BendingJob>();
    for (int index = 0; index <= data.Creasing.Count - 1; ++index)
      this.Creasing.Add(new BendingJob(data.Creasing[index]));
    this.Perfo.Clear();
    this.Perfo = new List<BendingJob>();
    for (int index = 0; index <= data.Perfo.Count - 1; ++index)
      this.Perfo.Add(new BendingJob(data.Perfo[index]));
    this.CutCrease.Clear();
    this.CutCrease = new List<BendingJob>();
    for (int index = 0; index <= data.CutCrease.Count - 1; ++index)
      this.CutCrease.Add(new BendingJob(data.CutCrease[index]));
    this.BridgeEntities.Clear();
    this.BridgeEntities = new List<eEntities>();
    for (int index = 0; index <= data.BridgeEntities.Count - 1; ++index)
    {
      eEntities eEntities = new eEntities();
      eEntities.CopyEntity(data.BridgeEntities[index]);
      this.BridgeEntities.Add(eEntities);
    }
    this.NickEntities.Clear();
    this.NickEntities = new List<eEntities>();
    for (int index = 0; index <= data.NickEntities.Count - 1; ++index)
    {
      eEntities eEntities = new eEntities();
      eEntities.CopyEntity(data.NickEntities[index]);
      this.NickEntities.Add(eEntities);
    }
    this.BroachEntities.Clear();
    this.BroachEntities = new List<eEntities>();
    for (int index = 0; index <= data.BroachEntities.Count - 1; ++index)
    {
      eEntities eEntities = new eEntities();
      eEntities.CopyEntity(data.BroachEntities[index]);
      this.BroachEntities.Add(eEntities);
    }
    this.CommonCuttingProps = new DiemakerPageCommonProps(data.CommonCuttingProps);
    this.CommonCreasingProps = new DiemakerPageCommonProps(data.CommonCreasingProps);
    this.CommonPerfoProps = new DiemakerPageCommonProps(data.CommonPerfoProps);
    this.CommonCutCreaseProps = new DiemakerPageCommonProps(data.CommonCutCreaseProps);
  }

  public ArrayList ToDef(int Space)
  {
    ArrayList def = new ArrayList();
    def.Add((object) (buSystem.strSpace2 + "<DiemakerProps>"));
    def.Add((object) (buSystem.strSpace4 + "<CuttingProps>"));
    for (int index = 0; index <= this.Cutting.Count - 1; ++index)
      def.AddRange((ICollection) BendingJob.ToDef(this.Cutting[index], 4));
    def.Add((object) (buSystem.strSpace4 + "</CuttingProps>"));
    def.Add((object) (buSystem.strSpace4 + "<CreasingProps>"));
    for (int index = 0; index <= this.Creasing.Count - 1; ++index)
      def.AddRange((ICollection) BendingJob.ToDef(this.Creasing[index], 4));
    def.Add((object) (buSystem.strSpace4 + "</CreasingProps>"));
    def.Add((object) (buSystem.strSpace4 + "<PerfoProps>"));
    for (int index = 0; index <= this.Perfo.Count - 1; ++index)
      def.AddRange((ICollection) BendingJob.ToDef(this.Perfo[index], 4));
    def.Add((object) (buSystem.strSpace4 + "</PerfoProps>"));
    def.Add((object) (buSystem.strSpace4 + "<CutCreaseProps>"));
    for (int index = 0; index <= this.CutCrease.Count - 1; ++index)
      def.AddRange((ICollection) BendingJob.ToDef(this.CutCrease[index], 4));
    def.Add((object) (buSystem.strSpace4 + "</CutCreaseProps>"));
    def.Add((object) (buSystem.strSpace4 + "<BridgeEntities>"));
    for (int index = 0; index <= this.BridgeEntities.Count - 1; ++index)
      def.AddRange((ICollection) this.BridgeEntities[index].ToDefAll(6));
    def.Add((object) (buSystem.strSpace4 + "</BridgeEntities>"));
    def.Add((object) (buSystem.strSpace4 + "<NickEntities>"));
    for (int index = 0; index <= this.NickEntities.Count - 1; ++index)
      def.AddRange((ICollection) this.NickEntities[index].ToDefAll(6));
    def.Add((object) (buSystem.strSpace4 + "</NickEntities>"));
    def.Add((object) (buSystem.strSpace4 + "<BroachEntities>"));
    for (int index = 0; index <= this.BroachEntities.Count - 1; ++index)
      def.AddRange((ICollection) this.BroachEntities[index].ToDefAll(6));
    def.Add((object) (buSystem.strSpace4 + "</BroachEntities>"));
    def.AddRange((ICollection) this.CommonCuttingProps.ToDefAll("CommonCutting", 4, SerilizationMode.MultiLine).ToArray());
    def.AddRange((ICollection) this.CommonCreasingProps.ToDefAll("CommonCreasing", 4, SerilizationMode.MultiLine).ToArray());
    def.AddRange((ICollection) this.CommonPerfoProps.ToDefAll("CommonPerfo", 4, SerilizationMode.MultiLine).ToArray());
    def.AddRange((ICollection) this.CommonCutCreaseProps.ToDefAll("CommonCutCrease", 4, SerilizationMode.MultiLine).ToArray());
    def.Add((object) (buSystem.strSpace2 + "</DiemakerProps>"));
    return def;
  }

  public static void Decode(ArrayList AL, ref DiemakerPageProp Diemaker)
  {
    List<List<string>> CalcList1 = new List<List<string>>();
    List<List<string>> CalcList2 = new List<List<string>>();
    List<List<string>> CalcList3 = new List<List<string>>();
    List<List<string>> CalcList4 = new List<List<string>>();
    List<List<string>> stringListList1 = new List<List<string>>();
    List<List<string>> stringListList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<DiemakerProps>", "</DiemakerProps>", true, AL, ref CalcList1);
    if (CalcList1.Count <= 0)
      return;
    Diemaker = new DiemakerPageProp();
    buStatics.ListToSpecificList("<CuttingProps>", "</CuttingProps>", true, CalcList1[0], ref CalcList2);
    if (CalcList2.Count > 0)
    {
      List<List<string>> CalcList5 = new List<List<string>>();
      buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", true, CalcList2[0], ref CalcList5);
      for (int index = 0; index <= CalcList5.Count - 1; ++index)
      {
        BendingJob Job = new BendingJob();
        ArrayList AL1 = new ArrayList();
        AL1.AddRange((ICollection) CalcList5[index].ToArray());
        BendingJob.Decode(AL1, ref Job);
        Diemaker.Cutting.Add(Job);
      }
    }
    buStatics.ListToSpecificList("<CreasingProps>", "</CreasingProps>", true, CalcList1[0], ref CalcList3);
    if (CalcList3.Count > 0)
    {
      List<List<string>> CalcList6 = new List<List<string>>();
      buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", true, CalcList3[0], ref CalcList6);
      for (int index = 0; index <= CalcList6.Count - 1; ++index)
      {
        BendingJob Job = new BendingJob();
        ArrayList AL2 = new ArrayList();
        AL2.AddRange((ICollection) CalcList6[index].ToArray());
        BendingJob.Decode(AL2, ref Job);
        Diemaker.Creasing.Add(Job);
      }
    }
    buStatics.ListToSpecificList("<PerfoProps>", "</PerfoProps>", true, CalcList1[0], ref CalcList4);
    if (CalcList4.Count > 0)
    {
      List<List<string>> CalcList7 = new List<List<string>>();
      buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", true, CalcList4[0], ref CalcList7);
      for (int index = 0; index <= CalcList7.Count - 1; ++index)
      {
        BendingJob Job = new BendingJob();
        ArrayList AL3 = new ArrayList();
        AL3.AddRange((ICollection) CalcList7[index].ToArray());
        BendingJob.Decode(AL3, ref Job);
        Diemaker.Perfo.Add(Job);
      }
    }
    buStatics.ListToSpecificList("<CutCreaseProps>", "</CutCreaseProps>", true, CalcList1[0], ref CalcList4);
    if (CalcList4.Count > 0)
    {
      List<List<string>> CalcList8 = new List<List<string>>();
      buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", true, CalcList4[0], ref CalcList8);
      for (int index = 0; index <= CalcList8.Count - 1; ++index)
      {
        BendingJob Job = new BendingJob();
        ArrayList AL4 = new ArrayList();
        AL4.AddRange((ICollection) CalcList8[index].ToArray());
        BendingJob.Decode(AL4, ref Job);
        Diemaker.Perfo.Add(Job);
      }
    }
    List<List<string>> CalcList9 = new List<List<string>>();
    buStatics.ListToSpecificList("<BridgeEntities>", "</BridgeEntities>", true, CalcList1[0], ref CalcList9);
    for (int index1 = 0; index1 <= CalcList9.Count - 1; ++index1)
    {
      List<List<string>> CalcList10 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList9[index1], ref CalcList10);
      for (int index2 = 0; index2 <= CalcList10.Count - 1; ++index2)
      {
        eEntities eEntities1 = new eEntities();
        eEntities eEntities2 = eEntities.Decode(CalcList10[index2], "", SerilizationMode.MultiLine);
        Diemaker.BridgeEntities.Add(eEntities2);
      }
    }
    CalcList9 = new List<List<string>>();
    buStatics.ListToSpecificList("<NickEntities>", "</NickEntities>", true, CalcList1[0], ref CalcList9);
    for (int index3 = 0; index3 <= CalcList9.Count - 1; ++index3)
    {
      List<List<string>> CalcList11 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList9[index3], ref CalcList11);
      for (int index4 = 0; index4 <= CalcList11.Count - 1; ++index4)
      {
        eEntities eEntities3 = new eEntities();
        eEntities eEntities4 = eEntities.Decode(CalcList11[index4], "", SerilizationMode.MultiLine);
        Diemaker.NickEntities.Add(eEntities4);
      }
    }
    CalcList9 = new List<List<string>>();
    buStatics.ListToSpecificList("<BroachEntities>", "</BroachEntities>", true, CalcList1[0], ref CalcList9);
    for (int index5 = 0; index5 <= CalcList9.Count - 1; ++index5)
    {
      List<List<string>> CalcList12 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList9[index5], ref CalcList12);
      for (int index6 = 0; index6 <= CalcList12.Count - 1; ++index6)
      {
        eEntities eEntities5 = new eEntities();
        eEntities eEntities6 = eEntities.Decode(CalcList12[index6], "", SerilizationMode.MultiLine);
        Diemaker.BroachEntities.Add(eEntities6);
      }
    }
  }
}
