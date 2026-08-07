// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataCircle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataCircle : buSerilization5
{
  public int TotalUpMove;
  public int TotalDownMove;
  public int TotalTextCount;

  public ProfileOperationDataCircle(buNestingSheet data)
  {
    ((ProfileOperationData) this).Count = 0;
    ((ProfileOperationData) this).ID = 0;
    ((ProfileOperationData) this).MaterialName = "";
    ((ProfileOperationData) this).MaterialWidth = 0.0;
    ((ProfileOperationData) this).MaterialHeight = 0.0;
    ((ProfileOperationData) this).MaterialArea = 0.0;
    ((ProfileOperationData) this).MaterialAreaFromMaxX = 0.0;
    ((ProfileOperationData) this).MaterialThickness = 5.0;
    ((ProfileOperationData) this).NestedArea = 0.0;
    ((ProfileOperationData) this).TotalOutsideLength = 0.0;
    ((ProfileOperationData) this).TotalInsideLength = 0.0;
    ((ProfileOperationData) this).TotalNoneCuttingLength = 0.0;
    ((ProfileOperationData) this).TotalLength = 0.0;
    this.TotalUpMove = 0;
    this.TotalDownMove = 0;
    this.TotalTextCount = 0;
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
    ((ProfileOperationData) this).Count = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).Quantity;
    ((ProfileOperationData) this).MaterialName = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).Name;
    ((ProfileOperationData) this).MaterialWidth = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).Width;
    ((ProfileOperationData) this).MaterialHeight = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).Height;
    ((ProfileOperationData) this).MaterialThickness = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).Thickness;
    ((ProfileOperationDataCut) this).MaterialID = ((ProfileItemCalc) data).ID;
    ((ProfileOperationDataNotch) this).Type = ((ProfileItemCalc) data).Type;
    ((ProfileOperationDataEllipse) this).ItemNo = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).ItemNo;
    ((ProfileOperationDataNotch) this).SalesNo = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).SalesNo;
    ((ProfileOperationDataNotch) this).Other = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).Other;
    ((ProfileOperationDataNotch) this).Aux = ((ProfileItem) ((ProfileItemCalc) data).MaterialData).Aux;
    ((ProfileOperationDataNotch) this).UserData = ((ProfileItemCalc) ((ProfileItemCalc) data).MaterialData).UserData;
    ((ProfileOperationDataCut) this).MaterialID = ((ProfileItemCalc) data).ID;
    ((ProfileOperationDataNotch) this).EntitiesGroup = new buEntitiesGroup(((ProfileItemCalc) data).EntitiesGroup);
  }

  public static ArrayList ToDef(List<buNestedSheet> NestedSheets, int Space)
  {
    ArrayList def = new ArrayList();
    def.Add((object) (buImage5.SpaceChar(Space) + "<buNestedSheets>"));
    for (int index = 0; index <= NestedSheets.Count - 1; ++index)
    {
      def.AddRange((ICollection) NestedSheets[index].ToDefAll("", 2 + Space, (SerilizationMode5) 1));
      string str = def[def.Count - 1].ToString();
      def.RemoveAt(def.Count - 1);
      if (((\u0084.\u0001) ((ProfileOperationDataNotch) NestedSheets[index]).EntitiesGroup.Outside).Entities.Count > 0)
        def.AddRange((ICollection) DimensionGroup.ToDefGroup(((ProfileOperationDataNotch) NestedSheets[index]).EntitiesGroup, Space + 4, "NestedSheet"));
      if (((ProfileOperationDataNotch) NestedSheets[index]).Parts.Count > 0)
        def.AddRange((ICollection) ProfileOperationDataPolygon.ToDef(((ProfileOperationDataNotch) NestedSheets[index]).Parts, Space + 4));
      def.Add((object) str);
    }
    def.Add((object) (buImage5.SpaceChar(Space) + "</buNestedSheets>"));
    return def;
  }

  public static void Decode(ArrayList AL, ref List<buNestedSheet> Sheets)
  {
    Sheets.Clear();
    Sheets = new List<buNestedSheet>();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<buNestedSheet>", "</buNestedSheet>", true, AL, ref CalcList1);
    for (int index = 0; index <= CalcList1.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      ArrayList CalcList2 = new ArrayList();
      List<string> CalcList3 = new List<string>();
      arrayList.AddRange((ICollection) CalcList1[index].ToArray());
      buNestedSheet buNestedSheet = (buNestedSheet) new ProfileOperationData();
      buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) buNestedSheet);
      buStatics.ListToSpecificList("<buEntitiesGroupDataNestedSheet>", "</buEntitiesGroupDataNestedSheet>", true, arrayList, ref CalcList3);
      DimensionGroup.Decode(CalcList3, ref ((ProfileOperationDataNotch) buNestedSheet).EntitiesGroup);
      ((GProfileOperationGroup) buCall.\u0001).CreatePointAndSolidFromEntityGroup(ref ((ProfileOperationDataNotch) buNestedSheet).EntitiesGroup);
      buStatics.ListToSpecificList("<buNestedParts>", "</buNestedParts>", false, arrayList, ref CalcList2);
      if (CalcList2.Count > 0)
        ProfileOperationDataPolygon.Decode(CalcList2, ref ((ProfileOperationDataNotch) buNestedSheet).Parts);
      Sheets.Add(buNestedSheet);
      arrayList.Clear();
      CalcList3.Clear();
      CalcList2.Clear();
    }
    CalcList1.Clear();
  }

  public static void Copy(buNestedSheet Base, ref buNestedSheet Copied)
  {
    Copied = (buNestedSheet) new ProfileOperationData(Base);
  }

  public static void Copy(List<buNestedSheet> Base, ref List<buNestedSheet> Copied)
  {
    Copied.Clear();
    Copied = new List<buNestedSheet>();
    for (int index = 0; index <= Base.Count - 1; ++index)
    {
      buNestedSheet buNestedSheet = (buNestedSheet) new ProfileOperationData(Base[index]);
      Copied.Add(buNestedSheet);
    }
  }

  public abstract void m001D08();
}
