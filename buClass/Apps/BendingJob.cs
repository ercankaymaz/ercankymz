// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingJob
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
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
  public CreasingCornerItem CreasingCorner = new CreasingCornerItem(false, 2.0, 5.0, new Pnt3D(), false, 2.0, 5.0, new Pnt3D());
  public HalfBridgeItem HalfBridge = new HalfBridgeItem(false, 2.0, 5.0, new Pnt3D(), false, 2.0, 5.0, new Pnt3D());
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
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.CreasingCorner = new CreasingCornerItem(data.CreasingCorner);
    this.HalfBridge = new HalfBridgeItem(data.HalfBridge);
    this.Bridges = new List<BridgeItem>();
    for (int index = 0; index <= data.Bridges.Count - 1; ++index)
      this.Bridges.Add(new BridgeItem(data.Bridges[index]));
    this.Bends = new List<BendItem>();
    for (int index = 0; index <= data.Bends.Count - 1; ++index)
      this.Bends.Add(new BendItem(data.Bends[index]));
    this.Nicks = new List<NickItem>();
    for (int index = 0; index <= data.Nicks.Count - 1; ++index)
      this.Nicks.Add(new NickItem(data.Nicks[index]));
    this.Broachs = new List<BroachItem>();
    for (int index = 0; index <= data.Broachs.Count - 1; ++index)
      this.Broachs.Add(new BroachItem(data.Broachs[index]));
    this.BendMarks = new List<BendMarkItem>();
    for (int index = 0; index <= data.BendMarks.Count - 1; ++index)
      this.BendMarks.Add(new BendMarkItem(data.BendMarks[index]));
    this.PerfoCombiList = new List<PerfoCombiItem>();
    for (int index = 0; index <= data.PerfoCombiList.Count - 1; ++index)
      this.PerfoCombiList.Add(new PerfoCombiItem(data.PerfoCombiList[index]));
    this.EntityList = new List<eEntities>();
    for (int index = 0; index <= data.EntityList.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.EntityList[index], ref copiedEnt);
      this.EntityList.Add(copiedEnt);
    }
    this.ExtractEntityList = new List<eEntities>();
    for (int index = 0; index <= data.ExtractEntityList.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.ExtractEntityList[index], ref copiedEnt);
      this.ExtractEntityList.Add(copiedEnt);
    }
    this.MirrorEntityList = new List<eEntities>();
    for (int index = 0; index <= data.MirrorEntityList.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.MirrorEntityList[index], ref copiedEnt);
      this.MirrorEntityList.Add(copiedEnt);
    }
    this.SameEntityList = new List<eEntities>();
    for (int index = 0; index <= data.SameEntityList.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.SameEntityList[index], ref copiedEnt);
      this.SameEntityList.Add(copiedEnt);
    }
    this.SelectedEntityList = new List<eEntities>();
    for (int index = 0; index <= data.SelectedEntityList.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(data.SelectedEntityList[index], ref copiedEnt);
      this.SelectedEntityList.Add(copiedEnt);
    }
  }

  public override string ToString()
  {
    return $"Type : {this.OperationType.ToString()} , Calc Len: {this.Information.CalculatedLength.ToString("f2")}";
  }

  public static ArrayList ToDef(BendingJob Job, int Space)
  {
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Job.ToDefAll("", 2 + Space, SerilizationMode.MultiLine));
    string str = def[def.Count - 1].ToString();
    def.RemoveAt(def.Count - 1);
    def.Add((object) (buSystem.strSpace8 + "<BridgeItems>"));
    for (int index = 0; index <= Job.Bridges.Count - 1; ++index)
      def.AddRange((ICollection) Job.Bridges[index].ToDefAll("", 10, SerilizationMode.MultiLine));
    def.Add((object) (buSystem.strSpace8 + "</BridgeItems>"));
    def.Add((object) (buSystem.strSpace8 + "<BendMarkItems>"));
    for (int index = 0; index <= Job.BendMarks.Count - 1; ++index)
      def.AddRange((ICollection) Job.BendMarks[index].ToDefAll("", 10, SerilizationMode.MultiLine));
    def.Add((object) (buSystem.strSpace8 + "</BendMarkItems>"));
    def.Add((object) (buSystem.strSpace8 + "<NickItems>"));
    for (int index = 0; index <= Job.Nicks.Count - 1; ++index)
      def.AddRange((ICollection) Job.Nicks[index].ToDefAll("", 10, SerilizationMode.MultiLine));
    def.Add((object) (buSystem.strSpace8 + "</NickItems>"));
    def.Add((object) (buSystem.strSpace8 + "<BendingItems>"));
    for (int index = 0; index <= Job.Bends.Count - 1; ++index)
      def.AddRange((ICollection) Job.Bends[index].ToDefAll("", 10, SerilizationMode.MultiLine));
    def.Add((object) (buSystem.strSpace8 + "</BendingItems>"));
    def.Add((object) (buSystem.strSpace8 + "<BroachItems>"));
    for (int index = 0; index <= Job.Broachs.Count - 1; ++index)
      def.AddRange((ICollection) Job.Broachs[index].ToDefAll("", 10, SerilizationMode.MultiLine));
    def.Add((object) (buSystem.strSpace8 + "</BroachItems>"));
    def.Add((object) (buSystem.strSpace8 + "<PerfoCombiListItems>"));
    for (int index = 0; index <= Job.PerfoCombiList.Count - 1; ++index)
      def.AddRange((ICollection) Job.PerfoCombiList[index].ToDefAll("", 10, SerilizationMode.MultiLine));
    def.Add((object) (buSystem.strSpace8 + "</PerfoCombiListItems>"));
    def.Add((object) (buSystem.strSpace8 + "<EntityList>"));
    for (int index = 0; index <= Job.EntityList.Count - 1; ++index)
      def.AddRange((ICollection) Job.EntityList[index].ToDefAll(10));
    def.Add((object) (buSystem.strSpace8 + "</EntityList>"));
    def.Add((object) (buSystem.strSpace8 + "<ExtractEntityList>"));
    for (int index = 0; index <= Job.ExtractEntityList.Count - 1; ++index)
      def.AddRange((ICollection) Job.ExtractEntityList[index].ToDefAll(10));
    def.Add((object) (buSystem.strSpace8 + "</ExtractEntityList>"));
    def.Add((object) (buSystem.strSpace8 + "<MirrorEntityList>"));
    for (int index = 0; index <= Job.MirrorEntityList.Count - 1; ++index)
      def.AddRange((ICollection) Job.MirrorEntityList[index].ToDefAll(10));
    def.Add((object) (buSystem.strSpace8 + "</MirrorEntityList>"));
    def.Add((object) (buSystem.strSpace8 + "<SameEntityList>"));
    for (int index = 0; index <= Job.SameEntityList.Count - 1; ++index)
      def.AddRange((ICollection) Job.SameEntityList[index].ToDefAll(10));
    def.Add((object) (buSystem.strSpace8 + "</SameEntityList>"));
    def.Add((object) (buSystem.strSpace8 + "<SelectedEntityList>"));
    for (int index = 0; index <= Job.SelectedEntityList.Count - 1; ++index)
      def.AddRange((ICollection) Job.SelectedEntityList[index].ToDefAll(10));
    def.Add((object) (buSystem.strSpace8 + "</SelectedEntityList>"));
    def.Add((object) str);
    return def;
  }

  public static void Decode(ArrayList AL, ref BendingJob Job)
  {
    Job = new BendingJob();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<BendingJob>", "</BendingJob>", true, AL, ref CalcList1);
    if (CalcList1.Count <= 0)
      return;
    List<List<string>> stringListList = new List<List<string>>();
    ArrayList arrayList = new ArrayList();
    arrayList.AddRange((ICollection) CalcList1[0].ToArray());
    buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, (object) Job);
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<BridgeItem>", "</BridgeItem>", true, arrayList, ref CalcList2);
    for (int index = 0; index <= CalcList2.Count - 1; ++index)
    {
      object obj = (object) new BridgeItem();
      buSerilization.Decode(CalcList2[index], "", SerilizationMode.MultiLine, obj);
      Job.Bridges.Add((BridgeItem) obj);
    }
    List<List<string>> CalcList3 = new List<List<string>>();
    buStatics.ListToSpecificList("<BendMarkItem>", "</BendMarkItem>", true, arrayList, ref CalcList3);
    for (int index = 0; index <= CalcList3.Count - 1; ++index)
    {
      object obj = (object) new BendMarkItem();
      buSerilization.Decode(CalcList3[index], "", SerilizationMode.MultiLine, obj);
      Job.BendMarks.Add((BendMarkItem) obj);
    }
    List<List<string>> CalcList4 = new List<List<string>>();
    buStatics.ListToSpecificList("<NickItem>", "</NickItem>", true, arrayList, ref CalcList4);
    for (int index = 0; index <= CalcList4.Count - 1; ++index)
    {
      object obj = (object) new NickItem();
      buSerilization.Decode(CalcList4[index], "", SerilizationMode.MultiLine, obj);
      Job.Nicks.Add((NickItem) obj);
    }
    List<List<string>> CalcList5 = new List<List<string>>();
    buStatics.ListToSpecificList("<BendItem>", "</BendItem>", true, arrayList, ref CalcList5);
    for (int index = 0; index <= CalcList5.Count - 1; ++index)
    {
      object obj = (object) new BendItem();
      buSerilization.Decode(CalcList5[index], "", SerilizationMode.MultiLine, obj);
      Job.Bends.Add((BendItem) obj);
    }
    List<List<string>> CalcList6 = new List<List<string>>();
    buStatics.ListToSpecificList("<BroachItem>", "</BroachItem>", true, arrayList, ref CalcList6);
    for (int index = 0; index <= CalcList6.Count - 1; ++index)
    {
      object obj = (object) new BroachItem();
      buSerilization.Decode(CalcList6[index], "", SerilizationMode.MultiLine, obj);
      Job.Broachs.Add((BroachItem) obj);
    }
    List<List<string>> CalcList7 = new List<List<string>>();
    buStatics.ListToSpecificList("<PerfoCombiItem>", "</PerfoCombiItem>", true, arrayList, ref CalcList7);
    for (int index = 0; index <= CalcList7.Count - 1; ++index)
    {
      object obj = (object) new PerfoCombiItem();
      buSerilization.Decode(CalcList7[index], "", SerilizationMode.MultiLine, obj);
      Job.PerfoCombiList.Add((PerfoCombiItem) obj);
    }
    List<List<string>> CalcList8 = new List<List<string>>();
    buStatics.ListToSpecificList("<EntityList>", "</EntityList>", true, arrayList, ref CalcList8);
    for (int index1 = 0; index1 <= CalcList8.Count - 1; ++index1)
    {
      List<List<string>> CalcList9 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList8[index1], ref CalcList9);
      for (int index2 = 0; index2 <= CalcList9.Count - 1; ++index2)
      {
        eEntities eEntities1 = new eEntities();
        eEntities eEntities2 = eEntities.Decode(CalcList9[index2], "", SerilizationMode.MultiLine);
        Job.EntityList.Add(eEntities2);
      }
    }
    List<List<string>> CalcList10 = new List<List<string>>();
    buStatics.ListToSpecificList("<ExtractEntityList>", "</ExtractEntityList>", true, arrayList, ref CalcList10);
    for (int index3 = 0; index3 <= CalcList10.Count - 1; ++index3)
    {
      List<List<string>> CalcList11 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList10[index3], ref CalcList11);
      for (int index4 = 0; index4 <= CalcList11.Count - 1; ++index4)
      {
        eEntities eEntities3 = new eEntities();
        eEntities eEntities4 = eEntities.Decode(CalcList11[index4], "", SerilizationMode.MultiLine);
        Job.ExtractEntityList.Add(eEntities4);
      }
    }
    List<List<string>> CalcList12 = new List<List<string>>();
    buStatics.ListToSpecificList("<MirrorEntityList>", "</MirrorEntityList>", true, arrayList, ref CalcList12);
    for (int index5 = 0; index5 <= CalcList12.Count - 1; ++index5)
    {
      List<List<string>> CalcList13 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList12[index5], ref CalcList13);
      for (int index6 = 0; index6 <= CalcList13.Count - 1; ++index6)
      {
        eEntities eEntities5 = new eEntities();
        eEntities eEntities6 = eEntities.Decode(CalcList13[index6], "", SerilizationMode.MultiLine);
        Job.MirrorEntityList.Add(eEntities6);
      }
    }
    List<List<string>> CalcList14 = new List<List<string>>();
    buStatics.ListToSpecificList("<SameEntityList>", "</SameEntityList>", true, arrayList, ref CalcList14);
    for (int index7 = 0; index7 <= CalcList14.Count - 1; ++index7)
    {
      List<List<string>> CalcList15 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList14[index7], ref CalcList15);
      for (int index8 = 0; index8 <= CalcList15.Count - 1; ++index8)
      {
        eEntities eEntities7 = new eEntities();
        eEntities eEntities8 = eEntities.Decode(CalcList15[index8], "", SerilizationMode.MultiLine);
        Job.SameEntityList.Add(eEntities8);
      }
    }
    List<List<string>> CalcList16 = new List<List<string>>();
    buStatics.ListToSpecificList("<SelectedEntityList>", "</SelectedEntityList>", true, arrayList, ref CalcList16);
    for (int index9 = 0; index9 <= CalcList16.Count - 1; ++index9)
    {
      List<List<string>> CalcList17 = new List<List<string>>();
      buStatics.ListToSpecificList("<eEntities>", "</eEntities>", true, CalcList16[index9], ref CalcList17);
      for (int index10 = 0; index10 <= CalcList17.Count - 1; ++index10)
      {
        eEntities eEntities9 = new eEntities();
        eEntities eEntities10 = eEntities.Decode(CalcList17[index10], "", SerilizationMode.MultiLine);
        Job.SelectedEntityList.Add(eEntities10);
      }
    }
  }
}
