// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buProfileCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buProfileCalc
{
  public const DrillMoveCommand GCodeList = ; // Unable to render the field
  public const DrillMoveCommand Empty = ; // Unable to render the field
  public const DrillMoveCommand None = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const DrillMachineView CrossLeft = ; // Unable to render the field
  public const DrillMachineView Left = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const DrillProfilingType CornerRectangle = ; // Unable to render the field

  public buProfileCalc()
  {
    ((DrillMachineSettings) this).Name = "Job";
    ((DrillMachineSettings) this).Items = new List<buShape>();
    ((DrillMachineSettings) this).baseItems = new List<DrillItemBase>();
    ((DrillMachineSettings) this).ItemCalc = new List<DrillCalcItem>();
    ((DrillSettings) this).ItemShape = new List<DrillItem>();
    ((DrillSettings) this).Moves = new List<DrillMove>();
    ((DrillSettings) this).SimulationMoves = new List<DrillMove>();
    ((DrillSettings) this).Codes = new List<string>();
    ((DrillSettings) this).Cams = new List<camTp>();
    ((DrillSettings) this).NoCalculatedItems = new List<DrillItem>();
    ((DrillSettings) this).ErrorCodes = new List<string>();
    ((DrillSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((DrillSettings) this).TotalCount = 1;
    ((DrillSettings) this).Used = 0;
    ((DrillSettings) this).FirstClamperX = 0.0;
    ((DrillSettings) this).SecondClamperX = 0.0;
    ((DrillSettings) this).TotalSec = 0.0;
    ((DrillSettings) this).isError = false;
    ((DrillSettings) this).isLesSafe = false;
    ((DrillSettings) this).isSingleClamper = false;
    ((DrillSettings) this).isSorted = false;
    ((DrillSettings) this).isClamperSideDrillOpAvailable = false;
    ((DrillSettings) this).isClamperSideMillingOpAvailable = false;
    ((DrillSettings) this).isClamperSideSlotOpAvailable = false;
    ((DrillSettings) this).MakeContour = false;
    ((DrillRuntimeSettings) this).ClampesSetByManuelly = false;
    ((DrillRuntimeSettings) this).ContourOffset = 0.0;
    ((DrillRuntimeSettings) this).panelEntity = (Entity) null;
    ((DrillRuntimeSettings) this).FirstClamperEntity = (Entity) null;
    ((DrillRuntimeSettings) this).SecondClamperEntity = (Entity) null;
    ((DrillRuntimeSettings) this).otherEntities = (List<Entity>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(DrillJob data)
  {
    ((DrillMachineSettings) this).Name = "Job";
    ((DrillMachineSettings) this).Items = new List<buShape>();
    ((DrillMachineSettings) this).baseItems = new List<DrillItemBase>();
    ((DrillMachineSettings) this).ItemCalc = new List<DrillCalcItem>();
    ((DrillSettings) this).ItemShape = new List<DrillItem>();
    ((DrillSettings) this).Moves = new List<DrillMove>();
    ((DrillSettings) this).SimulationMoves = new List<DrillMove>();
    ((DrillSettings) this).Codes = new List<string>();
    ((DrillSettings) this).Cams = new List<camTp>();
    ((DrillSettings) this).NoCalculatedItems = new List<DrillItem>();
    ((DrillSettings) this).ErrorCodes = new List<string>();
    ((DrillSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((DrillSettings) this).TotalCount = 1;
    ((DrillSettings) this).Used = 0;
    ((DrillSettings) this).FirstClamperX = 0.0;
    ((DrillSettings) this).SecondClamperX = 0.0;
    ((DrillSettings) this).TotalSec = 0.0;
    ((DrillSettings) this).isError = false;
    ((DrillSettings) this).isLesSafe = false;
    ((DrillSettings) this).isSingleClamper = false;
    ((DrillSettings) this).isSorted = false;
    ((DrillSettings) this).isClamperSideDrillOpAvailable = false;
    ((DrillSettings) this).isClamperSideMillingOpAvailable = false;
    ((DrillSettings) this).isClamperSideSlotOpAvailable = false;
    ((DrillSettings) this).MakeContour = false;
    ((DrillRuntimeSettings) this).ClampesSetByManuelly = false;
    ((DrillRuntimeSettings) this).ContourOffset = 0.0;
    ((DrillRuntimeSettings) this).panelEntity = (Entity) null;
    ((DrillRuntimeSettings) this).FirstClamperEntity = (Entity) null;
    ((DrillRuntimeSettings) this).SecondClamperEntity = (Entity) null;
    ((DrillRuntimeSettings) this).otherEntities = (List<Entity>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    ((DrillSettings) this).Material = (MaterialBase5) new ShapeMultiCenterData(((DrillSettings) data).Material);
    if (((DrillRuntimeSettings) data).panelEntity != null)
      buVector5.CopyEntities(((DrillRuntimeSettings) data).panelEntity, ref ((DrillRuntimeSettings) this).panelEntity);
    if (((DrillRuntimeSettings) data).FirstClamperEntity != null)
      buVector5.CopyEntities(((DrillRuntimeSettings) data).FirstClamperEntity, ref ((DrillRuntimeSettings) this).FirstClamperEntity);
    if (((DrillRuntimeSettings) data).SecondClamperEntity != null)
      buVector5.CopyEntities(((DrillRuntimeSettings) data).SecondClamperEntity, ref ((DrillRuntimeSettings) this).SecondClamperEntity);
    if (((DrillRuntimeSettings) data).otherEntities != null)
    {
      ((DrillRuntimeSettings) this).otherEntities = new List<Entity>();
      for (int index = 0; index <= ((DrillRuntimeSettings) data).otherEntities.Count - 1; ++index)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(((DrillRuntimeSettings) data).otherEntities[index], ref copiedEnt);
        ((DrillRuntimeSettings) this).otherEntities.Add(copiedEnt);
      }
    }
    buProfileCalc.Copy(((DrillMachineSettings) data).baseItems, ref ((DrillMachineSettings) this).baseItems);
    for (int index = 0; index <= ((DrillMachineSettings) data).Items.Count - 1; ++index)
      ((DrillMachineSettings) this).Items.Add(buLineCam.Copy(((DrillMachineSettings) data).Items[index]));
    for (int index = 0; index <= ((DrillSettings) data).NoCalculatedItems.Count - 1; ++index)
      ((DrillSettings) this).NoCalculatedItems.Add((DrillItem) new buProfileCalc(((DrillSettings) data).NoCalculatedItems[index]));
    for (int index = 0; index <= ((DrillSettings) data).ItemShape.Count - 1; ++index)
      ((DrillSettings) this).ItemShape.Add((DrillItem) new buProfileCalc(((DrillSettings) data).ItemShape[index]));
    for (int index = 0; index <= ((DrillSettings) data).ErrorCodes.Count - 1; ++index)
      ((DrillSettings) this).ErrorCodes.Add(((DrillSettings) this).ErrorCodes[index]);
    for (int index = 0; index <= ((DrillMachineSettings) data).ItemCalc.Count - 1; ++index)
      ((DrillMachineSettings) this).ItemCalc.Add(((DrillMachineSettings) data).ItemCalc[index]);
    for (int index = 0; index <= ((DrillSettings) data).Cams.Count - 1; ++index)
      ((DrillSettings) this).Cams.Add(new camTp(((DrillSettings) data).Cams[index]));
  }

  public override string ToString() => ((DrillMachineSettings) this).Name.ToString();

  public abstract void m001C2C();

  public buProfileCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(Point3D center)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillItem Item)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(buShapeHole Item)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(buShapeCut Item)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillCalcItem data)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(List<DrillCalcItem> RefItem, ref List<DrillCalcItem> CopiedItem)
  {
    CopiedItem.Clear();
    CopiedItem = new List<DrillCalcItem>();
    for (int index = 0; index <= RefItem.Count - 1; ++index)
    {
      DrillCalcItem CopiedItem1 = (DrillCalcItem) new buProfileCalc();
      buProfileCalc.Copy(RefItem[index], ref CopiedItem1);
      CopiedItem.Add(CopiedItem1);
    }
  }

  public static void Copy(DrillCalcItem RefItem, ref DrillCalcItem CopiedItem)
  {
    CopiedItem = (DrillCalcItem) new buProfileCalc(RefItem);
  }

  public override string ToString()
  {
    string str = $"{((DrillRuntimeSettings) this).planeName.ToString()} Center : {((DrillRuntimeSettings) this).Center.ToString()} - Dia: {((DrillRuntimeSettings) this).Diameter.ToString("f3")} - Dpth: {((DrillRuntimeSettings) this).Depth.ToString("f3")} - Calc: {((DrillRuntimeSettings) this).Calculated.ToString()}";
    if (((DrillRuntimeSettings) this).Tool > 0)
      str = $"{str} T:{((DrillRuntimeSettings) this).Tool.ToString()}";
    if (((DrillRuntimeSettings) this).HeadNo >= 1)
      str = $"{str} Head: {((DrillRuntimeSettings) this).HeadNo.ToString()}";
    return str;
  }

  public abstract void m001C36();

  public buProfileCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillItemBase data)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(List<DrillItemBase> refItem, ref List<DrillItemBase> copyItem)
  {
    copyItem = new List<DrillItemBase>();
    for (int index = 0; index <= refItem.Count - 1; ++index)
      copyItem.Add((DrillItemBase) new buProfileCalc(refItem[index]));
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001C3B();

  public buProfileCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(Point3D center)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillItem data)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(buShapeCut Item)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(buShapeHole Item)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(buShapeProfiling Item)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(buShapeEngrave Item)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(buShape Item, bool Contour = false)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void Copy(List<DrillItem> RefItem, ref List<DrillItem> CopiedItem)
  {
    CopiedItem.Clear();
    CopiedItem = new List<DrillItem>();
    for (int index = 0; index <= RefItem.Count - 1; ++index)
    {
      DrillItem CopiedItem1 = (DrillItem) new buProfileCalc();
      buProfileCalc.Copy(RefItem[index], ref CopiedItem1);
      CopiedItem.Add(CopiedItem1);
    }
  }

  public static void Copy(DrillItem RefItem, ref DrillItem CopiedItem)
  {
    CopiedItem = (DrillItem) new buProfileCalc(RefItem);
  }

  public static ArrayList ToDefPars(DrillItem P, string Char, int Space)
  {
    string str = "DrillItemPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + buProfileCalc.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static List<string> ToDefPars(DrillItem P, int Space)
  {
    return new List<string>()
    {
      buImage5.SpaceChar(Space) + "<DrillItemPars>",
      buImage5.SpaceChar(Space + 2) + buProfileCalc.ToDefPars(P),
      buImage5.SpaceChar(Space) + "</DrillItemPars>"
    };
  }

  public static string ToDefPars(DrillItem P) => buSerilization5.ClassToString((object) P);

  public static ArrayList ToDef(List<DrillItem> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList arrayList = new ArrayList();
      def.AddRange((ICollection) arrayList.ToArray());
    }
    return def;
  }

  public static ArrayList ToDef(DrillItem Item, string Char, int Space)
  {
    buSerilization5.ClassToString((object) Item);
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Item.ToDefAll("", Space + 2, (SerilizationMode5) 1));
    def.RemoveAt(def.Count - 1);
    def.Add((object) (str + "</DrillItem>"));
    return def;
  }

  public static void Decode(ArrayList AL, ref List<DrillItem> Items)
  {
    Items.Clear();
    Items = new List<DrillItem>();
    List<List<string>> stringListList = new List<List<string>>();
    List<List<string>> CalcList = new List<List<string>>();
    buStatics.ListToSpecificList("<DrillItem>", "</DrillItem>", true, AL, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      ArrayList AL1 = new ArrayList();
      AL1.AddRange((ICollection) CalcList[index].ToArray());
      DrillItem drillItem = (DrillItem) new buProfileCalc();
      buProfileCalc.Decode(AL1, ref drillItem);
      Items.Add(drillItem);
    }
  }

  public static void Decode(ArrayList AL, ref DrillItem Item)
  {
    Item = (DrillItem) new buProfileCalc();
    buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) Item);
    List<List<string>> stringListList = new List<List<string>>();
  }

  public override string ToString()
  {
    string str = $"{((DrillRuntimeSettings) this).planeName.ToString()} Center : {((DrillRuntimeSettings) this).Center.ToString()} - Dia: {((DrillCNCMode) ((DrillRuntimeSettings) this).ShapeData).Diameter.ToString("f3")} - Dpth: {((DrillCNCMode) ((DrillRuntimeSettings) this).ShapeData).Depth.ToString("f3")} - Calc: {((DrillRuntimeSettings) this).Calculated.ToString()}";
    if (((DrillRuntimeSettings) this).Tool > 0)
      str = $"{str} T:{((DrillRuntimeSettings) this).Tool.ToString()}";
    return str;
  }

  public abstract void m001C4E();

  public buProfileCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillMove data)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(
    double X1,
    double X2,
    double Y1,
    double Y2,
    double Y3,
    double Z1,
    double Z2,
    double Z3,
    DrillMoveCommand Cmd,
    double XPos)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(
    double X1,
    double X2,
    double Y1,
    double Z1,
    DrillMoveCommand Cmd,
    double XPos)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(
    double X1,
    double X2,
    double Y1,
    double Y2,
    double Y3,
    double Z1,
    double Z2,
    double Z3,
    DrillMoveCommand Cmd,
    double XPos,
    DrillCNCMode Mode,
    drillPlaneNames Plane,
    int T1,
    int T2,
    int T3,
    int T4,
    int T5,
    int T6,
    int T7,
    int T8,
    int T9,
    int T10,
    int T11,
    int T12)
  {
    // ISSUE: unable to decompile the method.
  }

  public static ArrayList ToDef(List<DrillMove> Items, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) buProfileCalc.ToDef(Items[index], Space).ToArray());
      def.AddRange((ICollection) c);
    }
    return def;
  }

  public static ArrayList ToDef(DrillMove Item, int Space)
  {
    string str = new string(' ', Space);
    ArrayList def = new ArrayList();
    def.AddRange((ICollection) Item.ToDefAll("", 2, (SerilizationMode5) 1).ToArray());
    def.RemoveAt(def.Count - 1);
    def.Add((object) (str + "</DrillJob>"));
    return def;
  }

  public static void Decode(List<string> AL, ref DrillMove Job)
  {
    Job = (DrillMove) new buProfileCalc();
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<DrillJob>", "</DrillJob>", true, AL, ref CalcList1);
    if (CalcList1.Count <= 0)
      return;
    ArrayList arrayList = new ArrayList();
    arrayList.AddRange((ICollection) CalcList1[0].ToArray());
    buSerilization5.Decode(arrayList, "", (SerilizationMode5) 1, (object) Job);
    List<List<string>> CalcList2 = new List<List<string>>();
    buStatics.ListToSpecificList("<DrillItem>", "</DrillItem>", true, arrayList, ref CalcList2);
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001C58();

  public buProfileCalc()
  {
    ((DrillItemType) this).Items = new List<DrillCalcItem>();
    ((DrillItemType) this).OriginalIndexList = new List<int>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(DrillFound data)
  {
    ((DrillItemType) this).Items = new List<DrillCalcItem>();
    ((DrillItemType) this).OriginalIndexList = new List<int>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    buProfileCalc.Copy(((DrillItemType) data).Items, ref ((DrillItemType) this).Items);
  }

  public static void Add(DrillCalcItem Item, int ToolNo, ref DrillFound Found)
  {
    DrillCalcItem drillCalcItem = (DrillCalcItem) new buProfileCalc(Item);
    ((DrillRuntimeSettings) drillCalcItem).Calculated = true;
    ((DrillRuntimeSettings) drillCalcItem).Tool = ToolNo;
    ((DrillItemType) Found).Items.Add(drillCalcItem);
  }

  public override string ToString()
  {
    string str = "Items: " + ((DrillItemType) this).Items.Count.ToString();
    if (((DrillItemType) this).Items.Count > 0)
    {
      str = $"{str} , {((DrillRuntimeSettings) ((DrillItemType) this).Items[0]).planeName.ToString()}";
      if (((DrillRuntimeSettings) ((DrillItemType) this).Items[0]).OffsetedPoint.X != 0.0)
        str = $"{str} , XOff: {((DrillRuntimeSettings) ((DrillItemType) this).Items[0]).OffsetedPoint.X.ToString("f1")}";
    }
    return str;
  }

  public abstract void m001C5D();

  public buProfileCalc()
  {
    ((DrillItemType) this).TNo1 = 0;
    ((DrillItemType) this).TNo2 = 0;
    ((DrillItemType) this).TNo3 = 0;
    ((DrillCNCMode) this).TNo4 = 0;
    ((DrillCNCMode) this).TNo5 = 0;
    ((DrillCNCMode) this).TNo6 = 0;
    ((DrillCNCMode) this).TNo7 = 0;
    ((DrillCNCMode) this).TNo8 = 0;
    ((DrillCNCMode) this).TNo9 = 0;
    ((DrillCNCMode) this).TNo10 = 0;
    ((DrillCNCMode) this).TNo11 = 0;
    ((DrillCNCMode) this).TNo12 = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(DrillFindTool data)
  {
    ((DrillItemType) this).TNo1 = 0;
    ((DrillItemType) this).TNo2 = 0;
    ((DrillItemType) this).TNo3 = 0;
    ((DrillCNCMode) this).TNo4 = 0;
    ((DrillCNCMode) this).TNo5 = 0;
    ((DrillCNCMode) this).TNo6 = 0;
    ((DrillCNCMode) this).TNo7 = 0;
    ((DrillCNCMode) this).TNo8 = 0;
    ((DrillCNCMode) this).TNo9 = 0;
    ((DrillCNCMode) this).TNo10 = 0;
    ((DrillCNCMode) this).TNo11 = 0;
    ((DrillCNCMode) this).TNo12 = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public buProfileCalc()
  {
    ((DrillCNCMode) this).Diameter = 0.0;
    ((DrillCNCMode) this).Depth = 0.0;
    ((DrillCNCMode) this).Length = 0.0;
    ((DrillCNCMode) this).Width = 0.0;
    ((DrillCNCMode) this).Height = 0.0;
    ((DrillCNCMode) this).Angle = 0.0;
    ((DrillCNCMode) this).Sides = 0;
    ((DrillCNCMode) this).isCenter = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(
    double diameter,
    double depth,
    double length,
    double width,
    double height,
    double angle,
    int sides,
    bool iscenter)
  {
    ((DrillCNCMode) this).Diameter = 0.0;
    ((DrillCNCMode) this).Depth = 0.0;
    ((DrillCNCMode) this).Length = 0.0;
    ((DrillCNCMode) this).Width = 0.0;
    ((DrillCNCMode) this).Height = 0.0;
    ((DrillCNCMode) this).Angle = 0.0;
    ((DrillCNCMode) this).Sides = 0;
    ((DrillCNCMode) this).isCenter = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DrillCNCMode) this).Angle = angle;
    ((DrillCNCMode) this).Depth = depth;
    ((DrillCNCMode) this).Diameter = diameter;
    ((DrillCNCMode) this).Height = height;
    ((DrillCNCMode) this).Length = length;
    ((DrillCNCMode) this).Sides = sides;
    ((DrillCNCMode) this).Width = width;
    ((DrillCNCMode) this).isCenter = iscenter;
  }

  public buProfileCalc(DrillShapeData data)
  {
    ((DrillCNCMode) this).Diameter = 0.0;
    ((DrillCNCMode) this).Depth = 0.0;
    ((DrillCNCMode) this).Length = 0.0;
    ((DrillCNCMode) this).Width = 0.0;
    ((DrillCNCMode) this).Height = 0.0;
    ((DrillCNCMode) this).Angle = 0.0;
    ((DrillCNCMode) this).Sides = 0;
    ((DrillCNCMode) this).isCenter = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    string str1 = "";
    if (((DrillCNCMode) this).Depth > 0.0)
      str1 = $"{str1}Depth: {((DrillCNCMode) this).Depth.ToString("f2")}";
    if (((DrillCNCMode) this).Diameter > 0.0)
      str1 = $"{str1} - Dia: {((DrillCNCMode) this).Diameter.ToString("f2")}";
    if (((DrillCNCMode) this).Width > 0.0)
      str1 = $"{str1} - Width: {((DrillCNCMode) this).Width.ToString("f2")}";
    if (((DrillCNCMode) this).Height > 0.0)
      str1 = $"{str1} - Height: {((DrillCNCMode) this).Height.ToString("f2")}";
    if (((DrillCNCMode) this).Length > 0.0)
      str1 = $"{str1} - Length: {((DrillCNCMode) this).Length.ToString("f2")}";
    if (((DrillCNCMode) this).Angle > 0.0)
      str1 = $"{str1} - Angle: {((DrillCNCMode) this).Angle.ToString("f2")}";
    if (((DrillCNCMode) this).Sides > 0)
    {
      string str2 = $"{str1} - Sides: {((DrillCNCMode) this).Sides.ToString("f2")}";
    }
    return base.ToString();
  }

  public abstract void m001C64();

  public buProfileCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(drillPlaneNames plane, DrillCNCMode mode)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(drillPlaneNames plane, DrillCNCMode mode, DrillMoveAddType addType)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(drillPlaneNames plane, DrillCNCMode mode, int t1)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(drillPlaneNames plane, DrillCNCMode mode, int t1, int t2)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(drillPlaneNames plane, DrillCNCMode mode, int t1, int t2, int t3, int t4)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(
    drillPlaneNames plane,
    DrillCNCMode mode,
    DrillMoveAddType addType,
    int t1,
    int t2,
    int t3,
    int t4,
    int t5,
    int t6)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(
    drillPlaneNames plane,
    DrillCNCMode mode,
    DrillMoveAddType addType,
    int t1,
    int t2,
    int t3,
    int t4,
    int t5,
    int t6,
    DrillMoveCommand Cmd2,
    DrillMoveCommand Cmd3)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(
    drillPlaneNames plane,
    DrillCNCMode mode,
    DrillMoveAddType addType,
    int t1,
    int t2,
    int t3,
    int t4,
    int t5,
    int t6,
    int t7,
    int t8,
    int t9,
    int t10,
    int t11,
    int t12)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(
    drillPlaneNames plane,
    DrillCNCMode mode,
    DrillMoveAddType addType,
    int t1,
    int t2,
    int t3,
    int t4,
    int t5,
    int t6,
    int t7,
    int t8,
    int t9,
    int t10,
    int t11,
    int t12,
    DrillMoveCommand Cmd2,
    DrillMoveCommand Cmd3)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillMoveOptions data)
  {
    // ISSUE: unable to decompile the method.
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001C71();

  public buProfileCalc()
  {
    ((TuftingSequenceItem) this).ClamperCatchWidth = 30.0;
    ((TuftingSequenceItem) this).ClamperSlotCatchWidth = 25.0;
    ((TuftingSequenceItem) this).ClamperCatchWidthForBottom = 30.0;
    ((buNestingCalc) this).ClamperBetweenMinDistance = 50.0;
    ((buNestingCalc) this).ClamperLength = 180.0;
    ((buNestingCalc) this).ClamperOperationMinDistance = 30.0;
    ((buNestingCalc) this).ClamperSafeXDistance = 50.0;
    ((buNestingCalc) this).ClamperMinCatchXDistance = 40.0;
    ((buNestingCalc) this).ClamperCatchDistanceInsideFromMaterial = 30.0;
    ((buNestingCalc) this).ClamperFirstPositionOffset = 20.0;
    ((buNestingSheetData) this).ClamperMillingFirstPositionOffset = 80.0;
    ((buNestingSheetData) this).ClamperNextDrillExtraMoveDistance = 2.0;
    ((buNestingSheetData) this).ClamperSingleLimit = 400.0;
    ((buNestingSheetData) this).ClamperSingleMustLimit = 100.0;
    ((buNestingSheetData) this).ClamperDualClamperMinLimit = 120.0;
    ((buNestingSheetData) this).ClamperNextLookOperationDistance = 70.0;
    ((buNestingSheetData) this).ClamperSmallMaterialCLampMinLengthPersc = 25.0;
    ((buNestingSheetData) this).ClamperMediumMaterialCLampMinLengthPersc = 50.0;
    ((buNestingSheetData) this).ClamperBigMaterialCLampMinLengthPersc = 100.0;
    ((buNestingSheetData) this).ClamperThickness = 15.0;
    ((buNestingSheetData) this).MaterialSmallLimit = 500.0;
    ((buNestingSheetData) this).MaterialMediumLimit = 750.0;
    ((buNestingSheet) this).MaterialBigLimit = 1000.0;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForTop = false;
    ((buNestingSheet) this).ResetDrillPistonWhileMoveSafeAfterDrill = true;
    ((buNestingSheet) this).SearchVerToolEvenMultiHorDrillAvailableForTop = false;
    ((buNestingSheet) this).SearchVerToolEvenMultiHorDrillAvailableForBottom = false;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForFront = false;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForBack = false;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForLeftRight = false;
    ((buNestingSheet) this).MoveY3AxisToSafeIfOperationAtClamperSideFroBottom = true;
    ((buNestingSheet) this).MirrorCalculationForFront = true;
    ((buNestingSheet) this).MirrorCalculationForBack = true;
    ((buNestingSheet) this).MirrorCalculationForTop = true;
    ((buNestingSheet) this).MoveXYSameTimeForBottom = true;
    ((buNestingSheet) this).LeaveClamperSideWhileClamperChangeForBottom = true;
    ((buNestingSheet) this).LeaveYDistanceWhileClamperChangeForBottom = 300.0;
    ((buNestingSheet) this).BackOperationsAlwaysWillLastOperation = true;
    ((buNestingSheetSettings) this).SlotClamperSideClamperMoveMinLength = 850.0;
    ((buNestingSheetSettings) this).FindFastestPattern = true;
    ((buNestingSheetSettings) this).DoubleHeadWorkTogetherLimit = 200.0;
    ((buNestingSheetSettings) this).DrillPlungeFeed = 4000.0;
    ((buNestingSheetSettings) this).MillingFeed = 30.0;
    ((buNestingSheetSettings) this).MillingPlungeFeed = 15.0;
    ((buNestingSheetSettings) this).TopSpindleSpeed = 15000.0;
    ((buNestingSheetSettings) this).BottomSpindleSpeed = 15000.0;
    ((buNestingSheetSettings) this).distanceSafe = 50.0;
    ((buNestingSheetSettings) this).distanceSmallSafe = 15.0;
    ((buNestingSheetSettings) this).SlotSawPlungeSpeed = 1000.0;
    ((buNestingSheetSettings) this).SlotSawCuttingSpeed = 4000.0;
    ((buNestingSheetSettings) this).SlotSawReverseDirection = false;
    ((buNestingSheetSettings) this).SlotSawSafeDistance = 50.0;
    ((buNestingSheetSettings) this).SlotSawRapidDistance = 30.0;
    ((buNestingSheetSettings) this).ContourMinLimit = 300.0;
    ((buNestingSheetSettings) this).ContourMidLimit = 600.0;
    ((buNestingSheetSettings) this).MaterialZeroYMinPosition = 200.0;
    ((buNestingSheetSettings) this).MaterialZeroYMaxPosition = 400.0;
    ((buNestingSheetAddData) this).HorizontalTableTopSurfaceZLimit = 2.0;
    ((buNestingSheetAddData) this).MaterialFeedMaxDistance = 1300.0;
    ((buNestingSheetAddData) this).ProfilingLeadInDistance = 20.0;
    ((buNestingSheetAddData) this).ProfilingLeadOutDistance = 20.0;
    ((buNestingSheetAddData) this).ReclineDiameter = 24.0;
    ((buNestingSheetAddData) this).ToolPistonVerticalDistance = 60.0;
    ((buNestingSheetAddData) this).ToolPistonHorizontalDistance = 75.0;
    ((buNestingSheetAddData) this).HorizontalToolHolderWidth = 40.0;
    ((buNestingSheetAddData) this).ToolPistonSawDistance = 62.0;
    ((buNestingSheetAddData) this).ToolTopSpindlePistonDistance = 85.0;
    ((buNestingSheetAddData) this).ToolBottomSpindlePistonDistance = 85.0;
    ((buNestingPartData) this).ToolRepeatDistance = 32.0;
    ((buNestingPartData) this).SimulationDevideEnable = true;
    ((buNestingPartData) this).SimulationDevideG0Length = 50.0;
    ((buNestingPartData) this).SimulationDevideG1Length = 20.0;
    ((buNestingPartData) this).SlotMinLengthForBottomSpindleAtClamperArea = 500.0;
    ((buNestingPartData) this).SlotMinLengthForTopSpindleAtClamperArea = 350.0;
    ((buNestingPartData) this).ContourMinLengthForBottomSpindleAtClamperArea = 500.0;
    ((buNestingPartData) this).ContourMinLengthForTopSpindleAtClamperArea = 350.0;
    ((buNestingPartData) this).ContourLimitLenForTopSpindleOneMove = 600.0;
    ((buNestingPartData) this).ContourLimitLenForBottomSpindleOneMove = 900.0;
    ((buNestingPartData) this).ContourTopDirection = ClockDirectionType.CCW;
    ((buNestingPartData) this).ContourBottomDirection = ClockDirectionType.CCW;
    ((buNestingPartData) this).ParkX1 = -1000.0;
    ((buNestingPartData) this).ParkX2 = -100.0;
    ((buNestingPartData) this).ParkY1 = 1400.0;
    ((buNestingPart) this).ParkY2 = 100.0;
    ((buNestingPart) this).ParkY3 = 500.0;
    ((buNestingPart) this).ParkZ1 = 100.0;
    ((buNestingPart) this).ParkZ2 = 100.0;
    ((buNestingPart) this).ParkZ3 = 90.0;
    ((buNestingPart) this).BottimPressZ1Position = 20.0;
    ((buNestingPart) this).BottimPressZ2Position = 20.0;
    ((buNestingPart) this).X1SafeDistance = 20.0;
    ((buNestingPart) this).X1SmallSafeDistance = 10.0;
    ((buNestingPart) this).X2SafeDistance = 20.0;
    ((buNestingPart) this).X2SmallSafeDistance = 10.0;
    ((buNestingPart) this).Y1SafeDistance = 20.0;
    ((buNestingPart) this).Y1SmallSafeDistance = 10.0;
    ((buNestingPart) this).Y2SafeDistance = 20.0;
    ((buNestingPart) this).Y2SmallSafeDistance = 10.0;
    ((buNestingPart) this).Z1SafeDistance = 140.0;
    ((buNestingPart) this).Z1SmallSafeDistance = 20.0;
    ((buNestingPart) this).Z2SafeDistance = 140.0;
    ((buNestingPart) this).Z2SmallSafeDistance = 20.0;
    ((buNestingPart) this).Z2SupportDistance = 10.0;
    ((buNestingPart) this).Z3SafeDistance = 100.0;
    ((buNestingPart) this).Z3SmallSafeDistance = 20.0;
    ((buNestingPart) this).XSafeDistance = 40.0;
    ((buNestingPart) this).XSmallSafeDistance = 20.0;
    ((buNestingPart) this).YSafeDistance = 40.0;
    ((buNestingPart) this).YSmallSafeDistance = 20.0;
    ((buNestingPart) this).Y1MaxPosition = 1100.0;
    ((buNestingPart) this).Y2MinPosition = -700.0;
    ((buNestingPart) this).BottomDrillPressLimitForEndMaterial = 80.0;
    ((buNestingPart) this).BottomDrillPressDisForY1AndY2FromMatTop = -2.0;
    ((buNestingPart) this).BottomDrillBothY1AndY2PressLimit = 400.0;
    ((buNestingPartSettings) this).BottomDrillPressMinLimit = 100.0;
    ((buNestingPartSettings) this).BottomKorukXMinusDistance = 65.0;
    ((buNestingPartSettings) this).BottomKorukXPlusDistance = 65.0;
    ((buNestingPartSettings) this).BottomKorukYMinusDistance = 100.0;
    ((buNestingPartSettings) this).BottomKorukYPlusDistance = 100.0;
    ((buNestingPartSettings) this).SpindlePensDiameter = 80.0;
    ((buNestingPartSettings) this).TopSpindleYOffsetForBottomOperation = 25.0;
    ((buNestingPartSettings) this).Press61_65YDistanceFromY1Center = -204.0;
    ((buNestingPartSettings) this).Press66_71YDistanceFromY1Center = -284.0;
    ((buNestingPartSettings) this).Press72_74YDistanceFromY1Center = -290.0;
    ((buNestingPartSettings) this).Press77_79YDistanceFromY1Center = -220.0;
    ((buNestingPartSettings) this).Press161_165YDistanceFromY2Center = 204.0;
    ((buNestingPartSettings) this).Press166_171YDistanceFromY2Center = 284.0;
    ((buNestingPartSettings) this).Press172_174YDistanceFromY2Center = 290.0;
    ((buNestingPartSettings) this).Press177_179YDistanceFromY2Center = 220.0;
    ((buNestingPartSettings) this).Y1AndY2MinDistance = 100.0;
    ((buNestingPartSettings) this).Y1AndY2HorizontalToolMinDistance = 150.0;
    ((buNestingPartSettings) this).Y1GroupToolVerticalXOffset = 467.85;
    ((buNestingPartSettings) this).Y1GroupToolVerticalYOffset = 1769.5;
    ((buNestingPartSettings) this).Y1GroupToolVerticalZOffset = 265.1;
    ((buNestingPartAddData) this).Y1GroupToolHorizontalXOffset = 467.85;
    ((buNestingPartAddData) this).Y1GroupToolHorizontalYOffset = 1769.5;
    ((buNestingPartAddData) this).Y1GroupToolHorizontalZOffset = 226.0;
    ((buNestingPartAddData) this).Y1GroupToolMillingZOffset = 265.1;
    ((buNestingPartAddData) this).Y1GroupToolSawZOffset = 265.1;
    ((buNestingPartAddData) this).Y1GroupXOffset = 0.0;
    ((buNestingPartAddData) this).Y1GroupYOffset = 0.0;
    ((buNestingPartAddData) this).Y1GroupZOffset = 0.0;
    ((buNestingPartAddData) this).Y1MinLimit = 400.0;
    ((buNestingPartAddData) this).Y1ToolBlockWidth = 425.0;
    ((buNestingPartAddData) this).Y2GroupToolVerticalXOffset = 12.35;
    ((buNestingPartAddData) this).Y2GroupToolVerticalYOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupToolVerticalZOffset = 179.13;
    ((buNestingPartAddData) this).Y2GroupToolHorizontalXOffset = 12.35;
    ((buNestingPartAddData) this).Y2GroupToolHorizontalYOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupToolHorizontalZOffset = 138.13;
    ((buNestingPartAddData) this).Y2GroupToolSawZOffset = 179.13;
    ((buNestingPartAddData) this).Y2GroupXOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupYOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupZOffset = 0.0;
    ((buNestingPartAddData) this).Y2MaxLimit = 800.0;
    ((buNestingPartAddData) this).Y2ToolBlockWidth = 350.0;
    ((buNestingPartAddData) this).Y3GroupToolVerticalXOffset = 466.85;
    ((buNestingPartAddData) this).Y3GroupToolVerticalYOffset = 0.0;
    ((buNestingPartAddData) this).Y3GroupToolVerticalZOffset = -70.64;
    ((buNestingMaterials) this).Y3GroupToolMillingZOffset = -14.64;
    ((buNestingMaterials) this).Y3GroupXOffset = 0.0;
    ((buNestingMaterials) this).Y3GroupYOffset = 0.0;
    ((buNestingMaterials) this).Y3GroupZOffset = 0.0;
    ((buNestingMaterials) this).Tool61XZeroOffset = 422.0;
    ((buNestingMaterials) this).Tool62XZeroOffset = 422.0;
    ((buNestingMaterials) this).Tool63XZeroOffset = 422.0;
    ((buNestedResult) this).Tool64XZeroOffset = 422.0;
    ((buNestedResult) this).Tool65XZeroOffset = 422.0;
    ((buNestedResult) this).Tool66XZeroOffset = 422.0;
    ((buNestedResult) this).Tool67XZeroOffset = 390.01;
    ((buNestedResult) this).Tool68XZeroOffset = 358.02;
    ((buNestedResult) this).Tool69XZeroOffset = 294.05;
    ((buNestedResult) this).Tool70XZeroOffset = 262.06;
    ((buNestedResult) this).Tool71XZeroOffset = 230.07;
    ((buNestedResult) this).Tool72XZeroOffset = 485.97;
    ((buNestedResult) this).Tool73XZeroOffset = 485.97;
    ((buNestedResult) this).Tool74XZeroOffset = 453.98;
    ((buNestedResult) this).Tool75XZeroOffset = 453.98;
    ((buNestedResult) this).Tool76XZeroOffset = 285.07;
    ((buNestedResult) this).Tool77XZeroOffset = 175.07;
    ((buNestedResult) this).Tool78XZeroOffset = 285.07;
    ((buNestedResult) this).Tool79XZeroOffset = 175.07;
    ((buNestedResult) this).Tool80XZeroOffset = 175.07;
    ((buNestedResult) this).Tool85XZeroOffset = 175.07;
    ((buNestedResult) this).Tool270XZeroOffset = 400.0;
    ((buNestedResult) this).Tool61YZeroOffset = 0.0;
    ((buNestedResult) this).Tool62YZeroOffset = 0.0;
    ((buNestedResult) this).Tool63YZeroOffset = 0.0;
    ((buNestedResult) this).Tool64YZeroOffset = 0.0;
    ((buNestedResult) this).Tool65YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool66YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool67YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool68YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool69YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool70YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool71YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool72YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool73YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool74YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool75YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool76YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool77YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool78YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool79YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool80YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool85YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool161YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool162YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool163YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool164YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool165YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool166YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool167YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool168YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool169YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool170YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool171YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool172YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool173YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool174YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool175YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool176YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool177YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool178YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool179YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool185YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool261YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool262YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool263YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool264YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool265YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool266YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool267YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool268YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool269YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool270YZeroOffset = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(DrillCNCSettings data)
  {
    ((TuftingSequenceItem) this).ClamperCatchWidth = 30.0;
    ((TuftingSequenceItem) this).ClamperSlotCatchWidth = 25.0;
    ((TuftingSequenceItem) this).ClamperCatchWidthForBottom = 30.0;
    ((buNestingCalc) this).ClamperBetweenMinDistance = 50.0;
    ((buNestingCalc) this).ClamperLength = 180.0;
    ((buNestingCalc) this).ClamperOperationMinDistance = 30.0;
    ((buNestingCalc) this).ClamperSafeXDistance = 50.0;
    ((buNestingCalc) this).ClamperMinCatchXDistance = 40.0;
    ((buNestingCalc) this).ClamperCatchDistanceInsideFromMaterial = 30.0;
    ((buNestingCalc) this).ClamperFirstPositionOffset = 20.0;
    ((buNestingSheetData) this).ClamperMillingFirstPositionOffset = 80.0;
    ((buNestingSheetData) this).ClamperNextDrillExtraMoveDistance = 2.0;
    ((buNestingSheetData) this).ClamperSingleLimit = 400.0;
    ((buNestingSheetData) this).ClamperSingleMustLimit = 100.0;
    ((buNestingSheetData) this).ClamperDualClamperMinLimit = 120.0;
    ((buNestingSheetData) this).ClamperNextLookOperationDistance = 70.0;
    ((buNestingSheetData) this).ClamperSmallMaterialCLampMinLengthPersc = 25.0;
    ((buNestingSheetData) this).ClamperMediumMaterialCLampMinLengthPersc = 50.0;
    ((buNestingSheetData) this).ClamperBigMaterialCLampMinLengthPersc = 100.0;
    ((buNestingSheetData) this).ClamperThickness = 15.0;
    ((buNestingSheetData) this).MaterialSmallLimit = 500.0;
    ((buNestingSheetData) this).MaterialMediumLimit = 750.0;
    ((buNestingSheet) this).MaterialBigLimit = 1000.0;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForTop = false;
    ((buNestingSheet) this).ResetDrillPistonWhileMoveSafeAfterDrill = true;
    ((buNestingSheet) this).SearchVerToolEvenMultiHorDrillAvailableForTop = false;
    ((buNestingSheet) this).SearchVerToolEvenMultiHorDrillAvailableForBottom = false;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForFront = false;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForBack = false;
    ((buNestingSheet) this).MoveSafeDistanceAtClamperSideForLeftRight = false;
    ((buNestingSheet) this).MoveY3AxisToSafeIfOperationAtClamperSideFroBottom = true;
    ((buNestingSheet) this).MirrorCalculationForFront = true;
    ((buNestingSheet) this).MirrorCalculationForBack = true;
    ((buNestingSheet) this).MirrorCalculationForTop = true;
    ((buNestingSheet) this).MoveXYSameTimeForBottom = true;
    ((buNestingSheet) this).LeaveClamperSideWhileClamperChangeForBottom = true;
    ((buNestingSheet) this).LeaveYDistanceWhileClamperChangeForBottom = 300.0;
    ((buNestingSheet) this).BackOperationsAlwaysWillLastOperation = true;
    ((buNestingSheetSettings) this).SlotClamperSideClamperMoveMinLength = 850.0;
    ((buNestingSheetSettings) this).FindFastestPattern = true;
    ((buNestingSheetSettings) this).DoubleHeadWorkTogetherLimit = 200.0;
    ((buNestingSheetSettings) this).DrillPlungeFeed = 4000.0;
    ((buNestingSheetSettings) this).MillingFeed = 30.0;
    ((buNestingSheetSettings) this).MillingPlungeFeed = 15.0;
    ((buNestingSheetSettings) this).TopSpindleSpeed = 15000.0;
    ((buNestingSheetSettings) this).BottomSpindleSpeed = 15000.0;
    ((buNestingSheetSettings) this).distanceSafe = 50.0;
    ((buNestingSheetSettings) this).distanceSmallSafe = 15.0;
    ((buNestingSheetSettings) this).SlotSawPlungeSpeed = 1000.0;
    ((buNestingSheetSettings) this).SlotSawCuttingSpeed = 4000.0;
    ((buNestingSheetSettings) this).SlotSawReverseDirection = false;
    ((buNestingSheetSettings) this).SlotSawSafeDistance = 50.0;
    ((buNestingSheetSettings) this).SlotSawRapidDistance = 30.0;
    ((buNestingSheetSettings) this).ContourMinLimit = 300.0;
    ((buNestingSheetSettings) this).ContourMidLimit = 600.0;
    ((buNestingSheetSettings) this).MaterialZeroYMinPosition = 200.0;
    ((buNestingSheetSettings) this).MaterialZeroYMaxPosition = 400.0;
    ((buNestingSheetAddData) this).HorizontalTableTopSurfaceZLimit = 2.0;
    ((buNestingSheetAddData) this).MaterialFeedMaxDistance = 1300.0;
    ((buNestingSheetAddData) this).ProfilingLeadInDistance = 20.0;
    ((buNestingSheetAddData) this).ProfilingLeadOutDistance = 20.0;
    ((buNestingSheetAddData) this).ReclineDiameter = 24.0;
    ((buNestingSheetAddData) this).ToolPistonVerticalDistance = 60.0;
    ((buNestingSheetAddData) this).ToolPistonHorizontalDistance = 75.0;
    ((buNestingSheetAddData) this).HorizontalToolHolderWidth = 40.0;
    ((buNestingSheetAddData) this).ToolPistonSawDistance = 62.0;
    ((buNestingSheetAddData) this).ToolTopSpindlePistonDistance = 85.0;
    ((buNestingSheetAddData) this).ToolBottomSpindlePistonDistance = 85.0;
    ((buNestingPartData) this).ToolRepeatDistance = 32.0;
    ((buNestingPartData) this).SimulationDevideEnable = true;
    ((buNestingPartData) this).SimulationDevideG0Length = 50.0;
    ((buNestingPartData) this).SimulationDevideG1Length = 20.0;
    ((buNestingPartData) this).SlotMinLengthForBottomSpindleAtClamperArea = 500.0;
    ((buNestingPartData) this).SlotMinLengthForTopSpindleAtClamperArea = 350.0;
    ((buNestingPartData) this).ContourMinLengthForBottomSpindleAtClamperArea = 500.0;
    ((buNestingPartData) this).ContourMinLengthForTopSpindleAtClamperArea = 350.0;
    ((buNestingPartData) this).ContourLimitLenForTopSpindleOneMove = 600.0;
    ((buNestingPartData) this).ContourLimitLenForBottomSpindleOneMove = 900.0;
    ((buNestingPartData) this).ContourTopDirection = ClockDirectionType.CCW;
    ((buNestingPartData) this).ContourBottomDirection = ClockDirectionType.CCW;
    ((buNestingPartData) this).ParkX1 = -1000.0;
    ((buNestingPartData) this).ParkX2 = -100.0;
    ((buNestingPartData) this).ParkY1 = 1400.0;
    ((buNestingPart) this).ParkY2 = 100.0;
    ((buNestingPart) this).ParkY3 = 500.0;
    ((buNestingPart) this).ParkZ1 = 100.0;
    ((buNestingPart) this).ParkZ2 = 100.0;
    ((buNestingPart) this).ParkZ3 = 90.0;
    ((buNestingPart) this).BottimPressZ1Position = 20.0;
    ((buNestingPart) this).BottimPressZ2Position = 20.0;
    ((buNestingPart) this).X1SafeDistance = 20.0;
    ((buNestingPart) this).X1SmallSafeDistance = 10.0;
    ((buNestingPart) this).X2SafeDistance = 20.0;
    ((buNestingPart) this).X2SmallSafeDistance = 10.0;
    ((buNestingPart) this).Y1SafeDistance = 20.0;
    ((buNestingPart) this).Y1SmallSafeDistance = 10.0;
    ((buNestingPart) this).Y2SafeDistance = 20.0;
    ((buNestingPart) this).Y2SmallSafeDistance = 10.0;
    ((buNestingPart) this).Z1SafeDistance = 140.0;
    ((buNestingPart) this).Z1SmallSafeDistance = 20.0;
    ((buNestingPart) this).Z2SafeDistance = 140.0;
    ((buNestingPart) this).Z2SmallSafeDistance = 20.0;
    ((buNestingPart) this).Z2SupportDistance = 10.0;
    ((buNestingPart) this).Z3SafeDistance = 100.0;
    ((buNestingPart) this).Z3SmallSafeDistance = 20.0;
    ((buNestingPart) this).XSafeDistance = 40.0;
    ((buNestingPart) this).XSmallSafeDistance = 20.0;
    ((buNestingPart) this).YSafeDistance = 40.0;
    ((buNestingPart) this).YSmallSafeDistance = 20.0;
    ((buNestingPart) this).Y1MaxPosition = 1100.0;
    ((buNestingPart) this).Y2MinPosition = -700.0;
    ((buNestingPart) this).BottomDrillPressLimitForEndMaterial = 80.0;
    ((buNestingPart) this).BottomDrillPressDisForY1AndY2FromMatTop = -2.0;
    ((buNestingPart) this).BottomDrillBothY1AndY2PressLimit = 400.0;
    ((buNestingPartSettings) this).BottomDrillPressMinLimit = 100.0;
    ((buNestingPartSettings) this).BottomKorukXMinusDistance = 65.0;
    ((buNestingPartSettings) this).BottomKorukXPlusDistance = 65.0;
    ((buNestingPartSettings) this).BottomKorukYMinusDistance = 100.0;
    ((buNestingPartSettings) this).BottomKorukYPlusDistance = 100.0;
    ((buNestingPartSettings) this).SpindlePensDiameter = 80.0;
    ((buNestingPartSettings) this).TopSpindleYOffsetForBottomOperation = 25.0;
    ((buNestingPartSettings) this).Press61_65YDistanceFromY1Center = -204.0;
    ((buNestingPartSettings) this).Press66_71YDistanceFromY1Center = -284.0;
    ((buNestingPartSettings) this).Press72_74YDistanceFromY1Center = -290.0;
    ((buNestingPartSettings) this).Press77_79YDistanceFromY1Center = -220.0;
    ((buNestingPartSettings) this).Press161_165YDistanceFromY2Center = 204.0;
    ((buNestingPartSettings) this).Press166_171YDistanceFromY2Center = 284.0;
    ((buNestingPartSettings) this).Press172_174YDistanceFromY2Center = 290.0;
    ((buNestingPartSettings) this).Press177_179YDistanceFromY2Center = 220.0;
    ((buNestingPartSettings) this).Y1AndY2MinDistance = 100.0;
    ((buNestingPartSettings) this).Y1AndY2HorizontalToolMinDistance = 150.0;
    ((buNestingPartSettings) this).Y1GroupToolVerticalXOffset = 467.85;
    ((buNestingPartSettings) this).Y1GroupToolVerticalYOffset = 1769.5;
    ((buNestingPartSettings) this).Y1GroupToolVerticalZOffset = 265.1;
    ((buNestingPartAddData) this).Y1GroupToolHorizontalXOffset = 467.85;
    ((buNestingPartAddData) this).Y1GroupToolHorizontalYOffset = 1769.5;
    ((buNestingPartAddData) this).Y1GroupToolHorizontalZOffset = 226.0;
    ((buNestingPartAddData) this).Y1GroupToolMillingZOffset = 265.1;
    ((buNestingPartAddData) this).Y1GroupToolSawZOffset = 265.1;
    ((buNestingPartAddData) this).Y1GroupXOffset = 0.0;
    ((buNestingPartAddData) this).Y1GroupYOffset = 0.0;
    ((buNestingPartAddData) this).Y1GroupZOffset = 0.0;
    ((buNestingPartAddData) this).Y1MinLimit = 400.0;
    ((buNestingPartAddData) this).Y1ToolBlockWidth = 425.0;
    ((buNestingPartAddData) this).Y2GroupToolVerticalXOffset = 12.35;
    ((buNestingPartAddData) this).Y2GroupToolVerticalYOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupToolVerticalZOffset = 179.13;
    ((buNestingPartAddData) this).Y2GroupToolHorizontalXOffset = 12.35;
    ((buNestingPartAddData) this).Y2GroupToolHorizontalYOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupToolHorizontalZOffset = 138.13;
    ((buNestingPartAddData) this).Y2GroupToolSawZOffset = 179.13;
    ((buNestingPartAddData) this).Y2GroupXOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupYOffset = 0.0;
    ((buNestingPartAddData) this).Y2GroupZOffset = 0.0;
    ((buNestingPartAddData) this).Y2MaxLimit = 800.0;
    ((buNestingPartAddData) this).Y2ToolBlockWidth = 350.0;
    ((buNestingPartAddData) this).Y3GroupToolVerticalXOffset = 466.85;
    ((buNestingPartAddData) this).Y3GroupToolVerticalYOffset = 0.0;
    ((buNestingPartAddData) this).Y3GroupToolVerticalZOffset = -70.64;
    ((buNestingMaterials) this).Y3GroupToolMillingZOffset = -14.64;
    ((buNestingMaterials) this).Y3GroupXOffset = 0.0;
    ((buNestingMaterials) this).Y3GroupYOffset = 0.0;
    ((buNestingMaterials) this).Y3GroupZOffset = 0.0;
    ((buNestingMaterials) this).Tool61XZeroOffset = 422.0;
    ((buNestingMaterials) this).Tool62XZeroOffset = 422.0;
    ((buNestingMaterials) this).Tool63XZeroOffset = 422.0;
    ((buNestedResult) this).Tool64XZeroOffset = 422.0;
    ((buNestedResult) this).Tool65XZeroOffset = 422.0;
    ((buNestedResult) this).Tool66XZeroOffset = 422.0;
    ((buNestedResult) this).Tool67XZeroOffset = 390.01;
    ((buNestedResult) this).Tool68XZeroOffset = 358.02;
    ((buNestedResult) this).Tool69XZeroOffset = 294.05;
    ((buNestedResult) this).Tool70XZeroOffset = 262.06;
    ((buNestedResult) this).Tool71XZeroOffset = 230.07;
    ((buNestedResult) this).Tool72XZeroOffset = 485.97;
    ((buNestedResult) this).Tool73XZeroOffset = 485.97;
    ((buNestedResult) this).Tool74XZeroOffset = 453.98;
    ((buNestedResult) this).Tool75XZeroOffset = 453.98;
    ((buNestedResult) this).Tool76XZeroOffset = 285.07;
    ((buNestedResult) this).Tool77XZeroOffset = 175.07;
    ((buNestedResult) this).Tool78XZeroOffset = 285.07;
    ((buNestedResult) this).Tool79XZeroOffset = 175.07;
    ((buNestedResult) this).Tool80XZeroOffset = 175.07;
    ((buNestedResult) this).Tool85XZeroOffset = 175.07;
    ((buNestedResult) this).Tool270XZeroOffset = 400.0;
    ((buNestedResult) this).Tool61YZeroOffset = 0.0;
    ((buNestedResult) this).Tool62YZeroOffset = 0.0;
    ((buNestedResult) this).Tool63YZeroOffset = 0.0;
    ((buNestedResult) this).Tool64YZeroOffset = 0.0;
    ((buNestedResult) this).Tool65YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool66YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool67YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool68YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool69YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool70YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool71YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool72YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool73YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool74YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool75YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool76YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool77YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool78YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool79YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool80YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool85YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool161YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool162YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool163YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool164YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool165YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool166YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool167YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool168YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool169YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool170YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool171YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool172YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool173YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool174YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool175YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool176YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool177YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool178YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool179YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool185YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool261YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool262YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool263YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool264YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool265YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool266YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool267YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool268YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool269YZeroOffset = 0.0;
    ((buNestedSheet) this).Tool270YZeroOffset = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public buProfileCalc()
  {
    ((buNestedSheet) this).X1Velocity = 2075.0;
    ((buNestedSheet) this).X1AccDec = 50000.0;
    ((buNestedSheet) this).X2Velocity = 2075.0;
    ((buNestedSheet) this).X2AccDec = 50000.0;
    ((buNestedSheet) this).Y1Velocity = 1100.0;
    ((buNestedSheet) this).Y1AccDec = 40000.0;
    ((buNestedSheet) this).Y2Velocity = 1100.0;
    ((buNestedSheet) this).Y2AccDec = 40000.0;
    ((buNestedSheet) this).Y3Velocity = 1100.0;
    ((buNestedSheet) this).Y3AccDec = 40000.0;
    ((buNestedSheet) this).Z1Velocity = 450.0;
    ((buNestedSheet) this).Z1AccDec = 60000.0;
    ((buNestedSheet) this).Z2Velocity = 450.0;
    ((buNestedSheet) this).Z2AccDec = 60000.0;
    ((buNestedSheet) this).Z3Velocity = 450.0;
    ((buNestedSheet) this).Z3AccDec = 60000.0;
    ((buNestedSheet) this).ClamperUpTime = 1.0;
    ((buNestedSheet) this).ClamperDownTime = 1.0;
    ((buNestedSheet) this).ToolResetTime = 0.15;
    ((buNestedSheet) this).ToolSetTime = 0.06;
    ((buNestedSheet) this).MachineMaxXStroke = 2800.0;
    ((buNestedSheet) this).MachineMinXStroke = -1300.0;
    ((buNestedSheet) this).MachineMillingStandartXStroke = 2400.0;
    ((buNestedSheet) this).MachineMillingStandartXMaxLimit = 3400.0;
    ((buNestedPart) this).ClamperVersion = "V1";
    ((buNestedPart) this).MillingHolderOffset = 0.0;
    ((buNestedPart) this).SimulationIntervalMs = 30;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(DrillMachineSettings data)
  {
    ((buNestedSheet) this).X1Velocity = 2075.0;
    ((buNestedSheet) this).X1AccDec = 50000.0;
    ((buNestedSheet) this).X2Velocity = 2075.0;
    ((buNestedSheet) this).X2AccDec = 50000.0;
    ((buNestedSheet) this).Y1Velocity = 1100.0;
    ((buNestedSheet) this).Y1AccDec = 40000.0;
    ((buNestedSheet) this).Y2Velocity = 1100.0;
    ((buNestedSheet) this).Y2AccDec = 40000.0;
    ((buNestedSheet) this).Y3Velocity = 1100.0;
    ((buNestedSheet) this).Y3AccDec = 40000.0;
    ((buNestedSheet) this).Z1Velocity = 450.0;
    ((buNestedSheet) this).Z1AccDec = 60000.0;
    ((buNestedSheet) this).Z2Velocity = 450.0;
    ((buNestedSheet) this).Z2AccDec = 60000.0;
    ((buNestedSheet) this).Z3Velocity = 450.0;
    ((buNestedSheet) this).Z3AccDec = 60000.0;
    ((buNestedSheet) this).ClamperUpTime = 1.0;
    ((buNestedSheet) this).ClamperDownTime = 1.0;
    ((buNestedSheet) this).ToolResetTime = 0.15;
    ((buNestedSheet) this).ToolSetTime = 0.06;
    ((buNestedSheet) this).MachineMaxXStroke = 2800.0;
    ((buNestedSheet) this).MachineMinXStroke = -1300.0;
    ((buNestedSheet) this).MachineMillingStandartXStroke = 2400.0;
    ((buNestedSheet) this).MachineMillingStandartXMaxLimit = 3400.0;
    ((buNestedPart) this).ClamperVersion = "V1";
    ((buNestedPart) this).MillingHolderOffset = 0.0;
    ((buNestedPart) this).SimulationIntervalMs = 30;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m001C76();

  public buProfileCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillSettings data)
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc()
  {
    // ISSUE: unable to decompile the method.
  }

  public buProfileCalc(DrillRuntimeSettings data)
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001C7B();

  public buProfileCalc()
  {
    ((buNestingRuntime) this).simRelease = false;
    ((buNestingRuntime) this).activeMove = (DrillMove) new buProfileCalc();
    ((buNestingRuntime) this).acliveLine = -1;
    ((buNestingRuntime) this).layerPanel = "Panel";
    ((buNestingRuntime) this).layerOperation = "Operation";
    ((buNestingRuntime) this).layerGeneral = "General";
    ((buNestingRuntime) this).layerSelected = "Selected";
    ((buNestingRuntime) this).layerCam = "Cam";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buProfileCalc(DrillTempVars data)
  {
    ((buNestingRuntime) this).simRelease = false;
    ((buNestingRuntime) this).activeMove = (DrillMove) new buProfileCalc();
    ((buNestingRuntime) this).acliveLine = -1;
    ((buNestingRuntime) this).layerPanel = "Panel";
    ((buNestingRuntime) this).layerOperation = "Operation";
    ((buNestingRuntime) this).layerGeneral = "General";
    ((buNestingRuntime) this).layerSelected = "Selected";
    ((buNestingRuntime) this).layerCam = "Cam";
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public abstract void m001C7E();

  public buProfileCalc()
  {
    ((buNestingRuntime) this).Y1Y2ZoneSelectionLimit = 500.0;
    ((buNestingRuntime) this).Plane = planeBoxNames.Top;
    ((buNestingRuntime) this).SetAsUsed = false;
    ((buNestingTempVars) this).IgnoreUsedInfo = false;
    ((buNestingTempVars) this).SelectVerticalTools = false;
    ((buNestingTempVars) this).SelectHorizontalTools = false;
    ((buNestedResultSentEventArg) this).StartToolIndex = -1;
    ((buNestedResultSentEventArg) this).MaxVerticalToolCount = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buProfileCalc(FindToolSettings data)
  {
    ((buNestingRuntime) this).Y1Y2ZoneSelectionLimit = 500.0;
    ((buNestingRuntime) this).Plane = planeBoxNames.Top;
    ((buNestingRuntime) this).SetAsUsed = false;
    ((buNestingTempVars) this).IgnoreUsedInfo = false;
    ((buNestingTempVars) this).SelectVerticalTools = false;
    ((buNestingTempVars) this).SelectHorizontalTools = false;
    ((buNestedResultSentEventArg) this).StartToolIndex = -1;
    ((buNestedResultSentEventArg) this).MaxVerticalToolCount = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public buProfileCalc()
  {
    ((buNestedResultSentEventArg) this).UpdateRuntime = false;
    ((buNestedResultSentEventArg) this).Finished = false;
    ((buNestedResultSentEventArg) this).ErrorAvailable = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(DrillUpdateArg data)
  {
    ((buNestedResultSentEventArg) this).UpdateRuntime = false;
    ((buNestedResultSentEventArg) this).Finished = false;
    ((buNestedResultSentEventArg) this).ErrorAvailable = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return "Finished :" + ((buNestedResultSentEventArg) this).Finished.ToString();
  }

  public abstract void m001C84();

  public buProfileCalc()
  {
    ((buNestedResultEventArg) this).minXClamper = 0.0;
    ((buNestedResultEventArg) this).maxXClamper = 0.0;
    ((buNestedResultEventArg) this).minXClamperLessSafe = 0.0;
    ((buNestedResultEventArg) this).maxXClamperLessSafe = 0.0;
    ((buNestedResultEventArg) this).XMovePlus = 0.0;
    ((buNestedResultEventArg) this).XMoveMinus = 0.0;
    ((buNestedResultEventArg) this).XMovePlusLessSafe = 0.0;
    ((buNestedResultEventArg) this).XMoveMinusLessSafe = 0.0;
    ((buNestedResultEventArg) this).DrillInClamper = false;
    ((buNestedResultEventArg) this).DrillInClamperLassSafe = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buProfileCalc(ClamperInsideCalc data)
  {
    ((buNestedResultEventArg) this).minXClamper = 0.0;
    ((buNestedResultEventArg) this).maxXClamper = 0.0;
    ((buNestedResultEventArg) this).minXClamperLessSafe = 0.0;
    ((buNestedResultEventArg) this).maxXClamperLessSafe = 0.0;
    ((buNestedResultEventArg) this).XMovePlus = 0.0;
    ((buNestedResultEventArg) this).XMoveMinus = 0.0;
    ((buNestedResultEventArg) this).XMovePlusLessSafe = 0.0;
    ((buNestedResultEventArg) this).XMoveMinusLessSafe = 0.0;
    ((buNestedResultEventArg) this).DrillInClamper = false;
    ((buNestedResultEventArg) this).DrillInClamperLassSafe = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"DrillInClamper: {((buNestedResultEventArg) this).DrillInClamper.ToString()}minXClamper: {((buNestedResultEventArg) this).minXClamper.ToString("f2")} - maxXClamper: {((buNestedResultEventArg) this).maxXClamper.ToString("f2")} - XMoveMinus: {((buNestedResultEventArg) this).XMoveMinus.ToString("f2")} - XMovePlus: {((buNestedResultEventArg) this).XMovePlus.ToString("f2")}";
  }

  public abstract void m001C88();

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public extern buProfileCalc(object @object, IntPtr method);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke();

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  public buProfileCalc()
  {
    ((ProfileItem) this).Job = (DrillJob) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buProfileCalc(DrillJob data)
  {
    ((ProfileItem) this).Job = (DrillJob) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((ProfileItem) this).Job = (DrillJob) new buProfileCalc(data);
  }

  public override string ToString()
  {
    return ((DrillMachineSettings) ((ProfileItem) this).Job).baseItems.Count.ToString();
  }

  public void GetAvailableSequenceID(EntityList refEntities, ref int SequenceID)
  {
    try
    {
      List<int> intList = new List<int>();
      int num = -1;
      for (int index = 0; index <= refEntities.Count - 1; ++index)
      {
        if (refEntities[index].EntityData != null && refEntities[index].EntityData.GetType() == typeof (CustomData))
        {
          CustomData entityData = (CustomData) refEntities[index].EntityData;
          if (((RollerJob) entityData).get_Sequence() > num)
            num = ((RollerJob) entityData).get_Sequence();
        }
      }
      SequenceID = num + 1;
    }
    catch (Exception ex)
    {
      string str = "buTuftingCalc - ID = 101-00001";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public bool isSameLayerTuftOrOutline(string refLayerName, string checkLayerName)
  {
    string[] strArray1 = refLayerName.Split('_');
    string[] strArray2 = checkLayerName.Split('_');
    return strArray1.Length >= 2 & strArray2.Length >= 2 && strArray1[1] == strArray2[1];
  }

  public buProfileCalc()
  {
  }

  public abstract void m001C93();

  public buProfileCalc()
  {
    ((ProfileItem) this).LayerName = "";
    ((ProfileItem) this).Enable = true;
    ((ProfileItem) this).SortedEntities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public buProfileCalc(TuftingSequenceItem data)
  {
    ((ProfileItem) this).LayerName = "";
    ((ProfileItem) this).Enable = true;
    ((ProfileItem) this).SortedEntities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((ProfileItem) this).SortedEntities.Clear();
    buVector5.CopyEntities(((ProfileItem) data).SortedEntities, ref ((ProfileItem) this).SortedEntities);
  }

  public abstract void m001C96();

  [CompilerGenerated]
  [SpecialName]
  public void add_CalculationInProgress(CalculationEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CalculationEventHandler calculationEventHandler = ((ProfileItem) this).\u0001;
    CalculationEventHandler comparand;
    do
    {
      comparand = calculationEventHandler;
      // ISSUE: reference to a compiler-generated field
      calculationEventHandler = Interlocked.CompareExchange<CalculationEventHandler>(ref ((ProfileItem) this).\u0001, comparand + value, comparand);
    }
    while (calculationEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CalculationInProgress(CalculationEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CalculationEventHandler calculationEventHandler = ((ProfileItem) this).\u0001;
    CalculationEventHandler comparand;
    do
    {
      comparand = calculationEventHandler;
      // ISSUE: reference to a compiler-generated field
      calculationEventHandler = Interlocked.CompareExchange<CalculationEventHandler>(ref ((ProfileItem) this).\u0001, comparand - value, comparand);
    }
    while (calculationEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CalculationStarted(CalculationEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CalculationEventHandler calculationEventHandler = ((ProfileItem) this).\u0002;
    CalculationEventHandler comparand;
    do
    {
      comparand = calculationEventHandler;
      // ISSUE: reference to a compiler-generated field
      calculationEventHandler = Interlocked.CompareExchange<CalculationEventHandler>(ref ((ProfileItem) this).\u0002, comparand + value, comparand);
    }
    while (calculationEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CalculationStarted(CalculationEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    CalculationEventHandler calculationEventHandler = ((ProfileItem) this).\u0002;
    CalculationEventHandler comparand;
    do
    {
      comparand = calculationEventHandler;
      // ISSUE: reference to a compiler-generated field
      calculationEventHandler = Interlocked.CompareExchange<CalculationEventHandler>(ref ((ProfileItem) this).\u0002, comparand - value, comparand);
    }
    while (calculationEventHandler != comparand);
  }
}
