// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buFunctions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class buFunctions
{
  public override string ToString()
  {
    return $"{buFile5.ColorToString(((hmiUIDataGridView) this).Color, ColorConvertType.Html)} - Thickness : {((hmiUIDataGridView) this).Thickess.ToString()} - Transperancy : {((hmiUIDataGridView) this).Transperancy.ToString()}";
  }

  public abstract void m000360();

  public buFunctions()
  {
    ((hmiUIDataGridView) this).XOffset = 0.0;
    ((hmiUIDataGridView) this).YOffset = 0.0;
    ((hmiUIDataGridView) this).ZOffset = 0.0;
    ((hmiUIDataGridView) this).AOffset = 0.0;
    ((hmiUIDataGridView) this).BOffset = 0.0;
    ((UCSObjectData) this).COffset = 0.0;
    ((UCSObjectData) this).FOffset = 0.0;
    ((UCSObjectData) this).SOffset = 0.0;
    ((UCSObjectData) this).XMultiply = 1.0;
    ((UCSObjectData) this).YMultiply = 1.0;
    ((UCSObjectData) this).ZMultiply = 1.0;
    ((UCSObjectData) this).AMultiply = 1.0;
    ((UCSObjectData) this).BMultiply = 1.0;
    ((UCSObjectData) this).CMultiply = 1.0;
    ((MacroItem) this).FMultiply = 1.0;
    ((MacroItem) this).SMultiply = 1.0;
    ((MacroItem) this).FilterLength = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buFunctions(GCodeConverter distance)
  {
    ((hmiUIDataGridView) this).XOffset = 0.0;
    ((hmiUIDataGridView) this).YOffset = 0.0;
    ((hmiUIDataGridView) this).ZOffset = 0.0;
    ((hmiUIDataGridView) this).AOffset = 0.0;
    ((hmiUIDataGridView) this).BOffset = 0.0;
    ((UCSObjectData) this).COffset = 0.0;
    ((UCSObjectData) this).FOffset = 0.0;
    ((UCSObjectData) this).SOffset = 0.0;
    ((UCSObjectData) this).XMultiply = 1.0;
    ((UCSObjectData) this).YMultiply = 1.0;
    ((UCSObjectData) this).ZMultiply = 1.0;
    ((UCSObjectData) this).AMultiply = 1.0;
    ((UCSObjectData) this).BMultiply = 1.0;
    ((UCSObjectData) this).CMultiply = 1.0;
    ((MacroItem) this).FMultiply = 1.0;
    ((MacroItem) this).SMultiply = 1.0;
    ((MacroItem) this).FilterLength = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) distance, ref CopiedClass);
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
    return $"XOffset: {((hmiUIDataGridView) this).XOffset.ToString()} , YOffset: {((hmiUIDataGridView) this).YOffset.ToString()}";
  }

  static buFunctions() => MacroItem.Captions = new List<string>();

  public buFunctions()
  {
    ((MacroItem) this).Offset = new Pnt9D();
    ((MacroItem) this).Positions = new Pnt9D();
    ((MacroItem) this).CodeType = 0;
    ((MacroItem) this).isMCode = false;
    ((MacroItem) this).isGCode = false;
    ((MacroItem) this).isTCode = false;
    ((MacroItem) this).isG0Move = false;
    ((MacroItem) this).Tool = (ToolBase5) new ToolGeometry5();
    ((MacroItem) this).IJKValue = new IJK();
    ((MacroItem) this).SpindleSpeed = 0.0;
    ((MacroItem) this).Feed = 0.0;
    ((MacroItem) this).R = 0.0;
    ((MacroItem) this).MValue = 0.0;
    ((MacroItem) this).GValue = 0.0;
    ((MacroItem) this).TValue = 0.0;
    ((MacroItem) this).CodeString = "";
    ((MacroItem) this).Aux = "";
    ((FindEntitiesGroupSettings) this).Entity = (buEntity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buFunctions(GCodePoint5 data)
  {
    ((MacroItem) this).Offset = new Pnt9D();
    ((MacroItem) this).Positions = new Pnt9D();
    ((MacroItem) this).CodeType = 0;
    ((MacroItem) this).isMCode = false;
    ((MacroItem) this).isGCode = false;
    ((MacroItem) this).isTCode = false;
    ((MacroItem) this).isG0Move = false;
    ((MacroItem) this).Tool = (ToolBase5) new ToolGeometry5();
    ((MacroItem) this).IJKValue = new IJK();
    ((MacroItem) this).SpindleSpeed = 0.0;
    ((MacroItem) this).Feed = 0.0;
    ((MacroItem) this).R = 0.0;
    ((MacroItem) this).MValue = 0.0;
    ((MacroItem) this).GValue = 0.0;
    ((MacroItem) this).TValue = 0.0;
    ((MacroItem) this).CodeString = "";
    ((MacroItem) this).Aux = "";
    ((FindEntitiesGroupSettings) this).Entity = (buEntity) null;
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
    ((MacroItem) this).Tool = (ToolBase5) new ToolGeometry5(((MacroItem) data).Tool);
    buDiametricDim.Copy(((FindEntitiesGroupSettings) data).Entity, ref ((FindEntitiesGroupSettings) this).Entity);
    ((MacroItem) this).IJKValue = new IJK(((MacroItem) data).IJKValue);
  }

  public override string ToString()
  {
    string str;
    if (((MacroItem) this).isMCode)
      str = $"M{((MacroItem) this).CodeType.ToString()} X{((MacroItem) this).Positions.X.ToString("f2")}";
    else if (((MacroItem) this).isTCode)
      str = "T" + ((MacroItem) this).CodeType.ToString();
    else if (((MacroItem) this).isGCode)
      str = $"G{((MacroItem) this).CodeType.ToString()} X{((MacroItem) this).Positions.X.ToString("f2")} Y{((MacroItem) this).Positions.Y.ToString("f2")} Z{((MacroItem) this).Positions.Z.ToString("f2")} A{((MacroItem) this).Positions.A.ToString("f2")} B{((MacroItem) this).Positions.B.ToString("f2")} C{((MacroItem) this).Positions.C.ToString("f2")}";
    else
      str = ((MacroItem) this).CodeString;
    return str;
  }

  public abstract void m000368();

  public buFunctions()
  {
    ((FindEntitiesGroupSettings) this).X = "X";
    ((FindEntitiesGroupSettings) this).Y = "Y";
    ((FindEntitiesGroupSettings) this).Z = "Z";
    ((GeometryTableItem) this).A = "A";
    ((GeometryTableItem) this).B = "B";
    ((GeometryTableItem) this).C = "C";
    ((GeometryTableItem) this).U = "U";
    ((CircularSpeedReduction) this).V = "V";
    ((CircularSpeedReduction) this).W = "W";
    ((CircularSpeedReduction) this).T = "T";
    ((EdgeFoundArgs) this).M = "M";
    ((EdgeFoundArgs) this).S = "S";
    ((EdgeFoundArgs) this).R = "R";
    ((eyeSurfaceType) this).I = "I";
    ((eyeSurfaceType) this).J = "J";
    ((eyeSurfaceType) this).K = "K";
    ((eyeSurfaceType) this).F = "F";
    ((eyeSurfaceType) this).G = "G";
    ((buPipeBending) this).E = "E";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public abstract void m00036A();

  public buFunctions()
  {
    ((buCompare5) this).Positions = new Pnt9D();
    ((buCompare5) this).Radius = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((buConversion5.\u003C\u003Ec) this).IJKValues = new IJK();
    // ISSUE: reference to a compiler-generated field
    ((buConversion5.\u003C\u003Ec) this).CodeType = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buFunctions(GCodeGraphPoint5 data)
  {
    ((buCompare5) this).Positions = new Pnt9D();
    ((buCompare5) this).Radius = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((buConversion5.\u003C\u003Ec) this).IJKValues = new IJK();
    // ISSUE: reference to a compiler-generated field
    ((buConversion5.\u003C\u003Ec) this).CodeType = 0;
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
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ((buConversion5.\u003C\u003Ec) this).IJKValues = new IJK(((buConversion5.\u003C\u003Ec) data).IJKValues);
  }

  public static GCodeGraphPoint5 Copy(GCodeGraphPoint5 P)
  {
    GCodeGraphPoint5 gcodeGraphPoint5 = (GCodeGraphPoint5) new buFunctions();
    ((buCompare5) gcodeGraphPoint5).Positions = new Pnt9D(((buCompare5) P).Positions);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ((buConversion5.\u003C\u003Ec) gcodeGraphPoint5).CodeType = ((buConversion5.\u003C\u003Ec) P).CodeType;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ((buConversion5.\u003C\u003Ec) gcodeGraphPoint5).IJKValues = new IJK(((buConversion5.\u003C\u003Ec) P).IJKValues);
    ((buCompare5) gcodeGraphPoint5).Radius = ((buCompare5) P).Radius;
    return gcodeGraphPoint5;
  }

  public static void Copy(List<GCodeGraphPoint5> pts, ref List<GCodeGraphPoint5> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add((GCodeGraphPoint5) new buFunctions(buFunctions.Copy(pts[index])));
  }

  public override string ToString()
  {
    // ISSUE: reference to a compiler-generated field
    return $"X{((buCompare5) this).Positions.X.ToString("f3")} , Y{((buCompare5) this).Positions.Y.ToString("f3")} , Z{((buCompare5) this).Positions.Z.ToString("f3")} , Type{((buConversion5.\u003C\u003Ec) this).CodeType.ToString()} , R{((buCompare5) this).Radius.ToString("f3")}";
  }

  public abstract void m000370();

  public buFunctions()
  {
    ((buImage5) this).OriginalGCodeLineCount = 0;
    ((LockBitmap) this).ConvertedGCodeLineCount = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buFunctions()
  {
    ((LockBitmap) this).FilterLength = 0.0;
    ((LockBitmap) this).CheckComma = true;
    ((LockBitmap) this).TrimLines = true;
    ((LockBitmap) this).UseMCode = true;
    ((LockBitmap) this).UseTCode = true;
    ((LockBitmap) this).UseSCode = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public static buLabel hmiToBuLabel(hmiUISettings data, buLabel Lbl)
  {
    try
    {
      Lbl.Geometry.ArcDiameter = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryArcDiameer;
      Lbl.Geometry.ShapeMode = ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType;
      Lbl.Display = buControlDisplay.Copy(((buFile5.PLYToSchematic.\u0001) data).Display, Lbl.Display);
      if (((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) data).Parameters).GeometryType != 0)
        Lbl.BackColor = Color.Transparent;
      return Lbl;
    }
    catch (Exception ex)
    {
      return Lbl;
    }
  }
}
