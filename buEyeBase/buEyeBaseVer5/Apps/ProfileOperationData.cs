// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationData : buSerilization5
{
  public int ID;
  public string Material;
  public string Explanation;
  public bool Enable;
  public static List<string> Captions;
  public static byte f0042B5;
  public string JobName;
  public string JobColor;
  public string JobExplanation;
  public double ExecutionTime;
  public double PastalWidth;
  public double MaxXPosition;
  public double MaxYPosition;
  public double PartGap;
  public DateTime ExecutionDate;
  public int Licanse;
  public int NestedSheetCount;
  public int OrderedTotalPartCount;
  public int NestedTotalPartCount;
  public double TotalUsingPersentage;
  public bool NotNestedAll;
  public string ItemNo;
  public string SalesNo;
  public string Other;
  public string Aux;
  public double UserData;
  public buNestingVar Parameters;
  public List<buNestedSheet> NestedResultSheets;
  public List<buNestingPart> NestingPartsList;
  public List<buNestingSheet> NestingSheetList;
  public static byte f0042CE;
  public int Count;
  public int ID;
  public string MaterialName;
  public double MaterialWidth;
  public double MaterialHeight;
  public double MaterialArea;
  public double MaterialAreaFromMaxX;
  public double MaterialThickness;
  public double NestedArea;
  public double TotalOutsideLength;
  public double TotalInsideLength;
  public double TotalNoneCuttingLength;
  public double TotalLength;

  public ProfileOperationData(buNestedResult data)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    this.NestedResultSheets.Clear();
    for (int index = 0; index <= ((ProfileOperationData) data).NestedResultSheets.Count - 1; ++index)
      this.NestedResultSheets.Add((buNestedSheet) new ProfileOperationData(((ProfileOperationData) data).NestedResultSheets[index]));
    for (int index = 0; index <= ((ProfileOperationData) data).NestingPartsList.Count - 1; ++index)
      this.NestingPartsList.Add((buNestingPart) new ProfileOperationBarrel(((ProfileOperationData) data).NestingPartsList[index]));
    for (int index = 0; index <= ((ProfileOperationData) data).NestingSheetList.Count - 1; ++index)
      this.NestingSheetList.Add((buNestingSheet) new ProfileOperation(((ProfileOperationData) data).NestingSheetList[index]));
  }

  public static void Copy(buNestedResult data, ref buNestedResult copied)
  {
    copied = (buNestedResult) new ProfileOperationData(data);
  }

  public static void Copy(List<buNestedResult> data, ref List<buNestedResult> copied)
  {
    copied.Clear();
    copied = new List<buNestedResult>();
    for (int index = 0; index <= data.Count - 1; ++index)
    {
      buNestedResult buNestedResult = (buNestedResult) new ProfileOperationData(data[index]);
      copied.Add(buNestedResult);
    }
  }

  public static List<buNestedResult> Copy(List<buNestedResult> data)
  {
    List<buNestedResult> buNestedResultList = new List<buNestedResult>();
    for (int index = 0; index <= data.Count - 1; ++index)
    {
      buNestedResult buNestedResult = (buNestedResult) new ProfileOperationData(data[index]);
      buNestedResultList.Add(buNestedResult);
    }
    return buNestedResultList;
  }

  public static ArrayList ToDef(buNestedResult Result, int Space)
  {
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Result.ToDefAll("", 2 + Space, (SerilizationMode5) 1));
    string str = def[def.Count - 1].ToString();
    def.RemoveAt(def.Count - 1);
    def.AddRange((ICollection) ProfileOperationEllipse.ToDef(((ProfileOperationData) Result).NestingPartsList, Space + 4).ToArray());
    def.AddRange((ICollection) ProfileOperationCircle.ToDef(((ProfileOperationData) Result).NestingSheetList, Space + 4).ToArray());
    def.AddRange((ICollection) ProfileOperationDataCircle.ToDef(((ProfileOperationData) Result).NestedResultSheets, Space + 4).ToArray());
    def.Add((object) str);
    return def;
  }

  public static void Decode(ArrayList AL, ref buNestedResult Result)
  {
    Result = (buNestedResult) new ProfileOperationPolygon();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<buNestedResult>", "</buNestedResult>", true, AL, ref CalcList1);
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<buNestingPart>", "</buNestingPart>", true, AL, ref CalcList2);
    List<List<string>> CalcList3 = new List<List<string>>();
    buStatics.ListToSpecificList("<buNestingSheet>", "</buNestingSheet>", true, AL, ref CalcList3);
    List<List<string>> stringListList = new List<List<string>>();
    if (CalcList1.Count > 0)
    {
      ArrayList AL1 = new ArrayList();
      AL1.AddRange((ICollection) CalcList1[0].ToArray());
      buSerilization5.Decode(AL1, "", (SerilizationMode5) 1, (object) Result);
      ProfileOperationDataCircle.Decode(AL1, ref ((ProfileOperationData) Result).NestedResultSheets);
      AL1.Clear();
    }
    if (CalcList2.Count > 0)
      ProfileOperationHole.Decode(AL, ref ((ProfileOperationData) Result).NestingPartsList);
    if (CalcList3.Count > 0)
      ProfileOperationCircle.Decode(AL, ref ((ProfileOperationData) Result).NestingSheetList);
    CalcList2.Clear();
    CalcList3.Clear();
    CalcList1.Clear();
  }

  public abstract void m001D00();

  public ProfileOperationData()
  {
    ((ProfileOperationDataCircle) this).TotalUpMove = 0;
    ((ProfileOperationDataCircle) this).TotalDownMove = 0;
    ((ProfileOperationDataCircle) this).TotalTextCount = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecutionTimeSec = 0.0;
    ((ProfileOperationDataPolygon) this).ApproxExecution0UpDownCnt = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecution1UpDownCnt = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecution2UpDownCnt = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecution3UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution4UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution5UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution6UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution7UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution8UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution9UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution0Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution1Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution2Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution3Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution4Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution5Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution6Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution7Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution8Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution9Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution0TimeSec = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution1TimeSec = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution2TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution3TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution4TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution5TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution6TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution7TimeSec = 0.0;
    ((ProfileOperationDataCut) this).ApproxExecution8TimeSec = 0.0;
    ((ProfileOperationDataCut) this).ApproxExecution9TimeSec = 0.0;
    ((ProfileOperationDataCut) this).MaterialID = 0;
    ((ProfileOperationDataCut) this).Name = "Sheet";
    ((ProfileOperationDataCut) this).UsingPersentage = 0.0;
    ((ProfileOperationDataCut) this).UsingPersentageFromMaxX = 0.0;
    ((ProfileOperationDataEllipse) this).DontUse = false;
    ((ProfileOperationDataEllipse) this).CalculationError = false;
    ((ProfileOperationDataEllipse) this).PartsTotalWidth = 0.0;
    ((ProfileOperationDataEllipse) this).PartsTotalHeight = 0.0;
    ((ProfileOperationDataEllipse) this).ItemNo = "";
    ((ProfileOperationDataNotch) this).SalesNo = "";
    ((ProfileOperationDataNotch) this).Other = "";
    ((ProfileOperationDataNotch) this).Aux = "";
    ((ProfileOperationDataNotch) this).UserData = 0.0;
    ((ProfileOperationDataNotch) this).WarningText = "";
    ((ProfileOperationDataNotch) this).SheetMaxXPosition = 0.0;
    ((ProfileOperationDataNotch) this).SheetMaxYPosition = 0.0;
    ((ProfileOperationDataNotch) this).Type = nestMaterialType.Rectangle;
    ((ProfileOperationDataNotch) this).EntitiesGroup = new buEntitiesGroup();
    ((ProfileOperationDataNotch) this).UselessEntities = new List<List<buEntity>>();
    ((ProfileOperationDataNotch) this).Parts = new List<buNestedPart>();
    ((ProfileOperationDataHole) this).RemnantSheets = new List<Rectangle2D>();
    ((ProfileOperationDataHole) this).Cams = new List<camTp>();
    ((ProfileOperationDataHole) this).GCodeResult = (MachineGCodeExecutionResult) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationData(buNestedSheet data)
  {
    ((ProfileOperationDataCircle) this).TotalUpMove = 0;
    ((ProfileOperationDataCircle) this).TotalDownMove = 0;
    ((ProfileOperationDataCircle) this).TotalTextCount = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecutionTimeSec = 0.0;
    ((ProfileOperationDataPolygon) this).ApproxExecution0UpDownCnt = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecution1UpDownCnt = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecution2UpDownCnt = 0;
    ((ProfileOperationDataPolygon) this).ApproxExecution3UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution4UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution5UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution6UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution7UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution8UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution9UpDownCnt = 0;
    ((ProfileOperationDataRectangle) this).ApproxExecution0Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution1Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution2Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution3Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution4Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution5Len = 0.0;
    ((ProfileOperationDataRectangleRound) this).ApproxExecution6Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution7Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution8Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution9Len = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution0TimeSec = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution1TimeSec = 0.0;
    ((ProfileOperationDataBarel) this).ApproxExecution2TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution3TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution4TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution5TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution6TimeSec = 0.0;
    ((ProfileOperationDataSlot) this).ApproxExecution7TimeSec = 0.0;
    ((ProfileOperationDataCut) this).ApproxExecution8TimeSec = 0.0;
    ((ProfileOperationDataCut) this).ApproxExecution9TimeSec = 0.0;
    ((ProfileOperationDataCut) this).MaterialID = 0;
    ((ProfileOperationDataCut) this).Name = "Sheet";
    ((ProfileOperationDataCut) this).UsingPersentage = 0.0;
    ((ProfileOperationDataCut) this).UsingPersentageFromMaxX = 0.0;
    ((ProfileOperationDataEllipse) this).DontUse = false;
    ((ProfileOperationDataEllipse) this).CalculationError = false;
    ((ProfileOperationDataEllipse) this).PartsTotalWidth = 0.0;
    ((ProfileOperationDataEllipse) this).PartsTotalHeight = 0.0;
    ((ProfileOperationDataEllipse) this).ItemNo = "";
    ((ProfileOperationDataNotch) this).SalesNo = "";
    ((ProfileOperationDataNotch) this).Other = "";
    ((ProfileOperationDataNotch) this).Aux = "";
    ((ProfileOperationDataNotch) this).UserData = 0.0;
    ((ProfileOperationDataNotch) this).WarningText = "";
    ((ProfileOperationDataNotch) this).SheetMaxXPosition = 0.0;
    ((ProfileOperationDataNotch) this).SheetMaxYPosition = 0.0;
    ((ProfileOperationDataNotch) this).Type = nestMaterialType.Rectangle;
    ((ProfileOperationDataNotch) this).EntitiesGroup = new buEntitiesGroup();
    ((ProfileOperationDataNotch) this).UselessEntities = new List<List<buEntity>>();
    ((ProfileOperationDataNotch) this).Parts = new List<buNestedPart>();
    ((ProfileOperationDataHole) this).RemnantSheets = new List<Rectangle2D>();
    ((ProfileOperationDataHole) this).Cams = new List<camTp>();
    ((ProfileOperationDataHole) this).GCodeResult = (MachineGCodeExecutionResult) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    ((ProfileOperationDataNotch) this).Parts.Clear();
    for (int index = 0; index <= ((ProfileOperationDataNotch) data).Parts.Count - 1; ++index)
      ((ProfileOperationDataNotch) this).Parts.Add((buNestedPart) new ProfileOperationDataPolygon(((ProfileOperationDataNotch) data).Parts[index]));
    ((ProfileOperationDataHole) this).RemnantSheets.Clear();
    for (int index = 0; index <= ((ProfileOperationDataHole) data).RemnantSheets.Count - 1; ++index)
      ((ProfileOperationDataHole) this).RemnantSheets.Add((Rectangle2D) new AnalyseEntitiesResultError(((ProfileOperationDataHole) data).RemnantSheets[index]));
    ((ProfileOperationDataNotch) this).UselessEntities.Clear();
    for (int index1 = 0; index1 <= ((ProfileOperationDataNotch) data).UselessEntities.Count - 1; ++index1)
    {
      List<buEntity> buEntityList = new List<buEntity>();
      for (int index2 = 0; index2 <= ((ProfileOperationDataNotch) data).UselessEntities[index1].Count - 1; ++index2)
      {
        buEntity copiedEntity = (buEntity) new buMultilineText();
        buDiametricDim.Copy(((ProfileOperationDataNotch) data).UselessEntities[index1][index2], ref copiedEntity);
        buEntityList.Add(copiedEntity);
      }
      ((ProfileOperationDataNotch) this).UselessEntities.Add(buEntityList);
    }
    if ((((ProfileOperationDataHole) data).Cams == null ? 0 : (((ProfileOperationDataHole) data).Cams.Count > 0 ? 1 : 0)) != 0)
    {
      ((ProfileOperationDataHole) this).Cams = new List<camTp>();
      camTpPoint.CopyCam(((ProfileOperationDataHole) data).Cams, ref ((ProfileOperationDataHole) this).Cams);
    }
    if (((ProfileOperationDataHole) data).GCodeResult == null)
      return;
    ((ProfileOperationDataHole) this).GCodeResult = (MachineGCodeExecutionResult) new F_Scale(((ProfileOperationDataHole) data).GCodeResult);
  }
}
