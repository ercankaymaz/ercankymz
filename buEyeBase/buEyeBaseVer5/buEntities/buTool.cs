// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buTool
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.ClassViewer;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buTool : BlockReference
{
  public List<Control> ControlList;
  private Label \u0001;
  private Button \u0001;
  private Button \u0002;
  private setColorComboControl \u0001;
  private setDateTimeControl \u0001;
  internal setLabelControl \u0001;
  private setCheckBoxControl \u0001;
  private setLabelControl \u0002;
  private setLabelControl \u0003;
  private setNumericUpDownControl \u0001;
  private setComboBoxControl \u0001;
  private setTextBoxControl \u0001;
  private PictureBox \u0001;
  private IContainer \u0001;
  internal Panel \u0001;
  public static byte f0037C9;

  public static string buShapeTypeToString(buShape shape)
  {
    string str = "None";
    try
    {
      if (AppLanguage.CadCamDynamic.Count > 0)
      {
        if (shape.GetType() == typeof (buShapeCircle))
          str = AppLanguage.CadCamDynamic[51];
        else if (shape.GetType() == typeof (buShapeEllipse))
          str = AppLanguage.CadCamDynamic[54];
        else if (shape.GetType() == typeof (buShapeFreeDraw))
          str = AppLanguage.CadCamDynamic[77];
        else if (shape.GetType() == typeof (buShapeKeyHole))
          str = AppLanguage.CadCamDynamic[60];
        else if (shape.GetType() == typeof (buShapePolygon))
          str = AppLanguage.CadCamDynamic[70];
        else if (shape.GetType() == typeof (buShapeRectangle))
          str = AppLanguage.CadCamDynamic[62];
        else if (shape.GetType() == typeof (buShapeSlot))
          str = AppLanguage.CadCamDynamic[59];
      }
      else if (shape.GetType() == typeof (buShapeCircle))
        str = "Circle";
      else if (shape.GetType() == typeof (buShapeEllipse))
        str = "Ellipse";
      else if (shape.GetType() == typeof (buShapeFreeDraw))
        str = "Free Draw";
      else if (shape.GetType() == typeof (buShapeKeyHole))
        str = "KeyHole";
      else if (shape.GetType() == typeof (buShapePolygon))
        str = "Poylgon";
      else if (shape.GetType() == typeof (buShapeRectangle))
        str = "Rectangle";
      else if (shape.GetType() == typeof (buShapeSlot))
        str = "Slot";
      return str;
    }
    catch (Exception ex)
    {
      return str;
    }
  }

  public static bool isSame(buShape firstShape, buShape secondShape)
  {
    bool flag;
    if (((buClipperBase) firstShape).ShapeGroup != ((buClipperBase) secondShape).ShapeGroup | ((buClipperBase) firstShape).planeName != ((buClipperBase) secondShape).planeName | ((\u0012.\u0002) firstShape).Depth != ((\u0012.\u0002) secondShape).Depth)
      flag = false;
    else if (((buClipperBase) firstShape).ShapeGroup == ShapeGroup.Drill)
    {
      buShapeHole buShapeHole1 = firstShape as buShapeHole;
      buShapeHole buShapeHole2 = secondShape as buShapeHole;
      flag = ((DiemakerGrindingShapeSettings) buShapeHole1).DrillType == ((DiemakerGrindingShapeSettings) buShapeHole2).DrillType & buConversion5.EQ(((DiemakerGrindingShapeSettings) buShapeHole1).Diameter, ((DiemakerGrindingShapeSettings) buShapeHole2).Diameter) & ((buClipperBase) buShapeHole1).planeName == ((buClipperBase) buShapeHole2).planeName & buConversion5.EQ(((\u0012.\u0002) buShapeHole1).Depth, ((\u0012.\u0002) buShapeHole2).Depth) && buConversion5.EQ(((buClipper) buShapeHole1).CalculatedPoint, ((buClipper) buShapeHole2).CalculatedPoint);
    }
    else
      flag = ((buClipperBase) firstShape).ShapeGroup == ShapeGroup.Shape && ((buClipperBase) firstShape).ShapeType == ((buClipperBase) secondShape).ShapeType & ((buClipperBase) firstShape).planeName == ((buClipperBase) secondShape).planeName & buConversion5.EQ(((\u0012.\u0002) firstShape).Depth, ((\u0012.\u0002) secondShape).Depth) && buConversion5.EQ(((ShapeRuntimeData) ((buClipperBase) firstShape).ItemSize).MinBox, ((ShapeRuntimeData) ((buClipperBase) secondShape).ItemSize).MinBox) & buConversion5.EQ(((ShapeRuntimeData) ((buClipperBase) firstShape).ItemSize).MaxBox, ((ShapeRuntimeData) ((buClipperBase) secondShape).ItemSize).MaxBox) && !buConversion5.EQ(((ShapeRuntimeData) ((buClipperBase) firstShape).ItemSize).MinBox, new Point3D()) & !buConversion5.EQ(((ShapeRuntimeData) ((buClipperBase) firstShape).ItemSize).MaxBox, new Point3D());
    return flag;
  }

  public override string ToString()
  {
    string str = "";
    if (this.GetType() == typeof (buShapeRectangle))
      str = ((buShapeRectangle) this).ToString();
    else if (this.GetType() == typeof (buShapeCircle))
      str = ((buShapeCircle) this).ToString();
    else if (this.GetType() == typeof (buShapeEllipse))
      str = ((buShapeEllipse) this).ToString();
    else if (this.GetType() == typeof (buShapeKeyHole))
      str = ((buShapeKeyHole) this).ToString();
    else if (this.GetType() == typeof (buShapePolygon))
      str = ((buShapePolygon) this).ToString();
    else if (this.GetType() == typeof (buShapeSlot))
      str = ((buShapeSlot) this).ToString();
    else if (this.GetType() == typeof (buShapeFreeDraw))
      str = ((buShapeFreeDraw) this).ToString();
    else if (this.GetType() == typeof (buShapeHole))
      str = ((buShapeHole) this).ToString();
    else if (this.GetType() == typeof (buShapeHoleMulti))
      str = ((buShapeHoleMulti) this).ToString();
    else if (this.GetType() == typeof (buShapeHole3))
      str = ((buShapeHole3) this).ToString();
    else if (this.GetType() == typeof (buShapeCut))
      str = ((buShapeCut) this).ToString();
    else if (this.GetType() == typeof (buShapeProfiling))
      str = ((buShapeProfiling) this).ToString();
    else if (this.GetType() == typeof (buShapeJunction))
      str = ((buShapeJunction) this).ToString();
    else if (this.GetType() == typeof (buShapeEngrave))
      str = ((buShapeEngrave) this).ToString();
    else if (this.GetType() == typeof (buShapeText))
      str = ((buShapeText) this).ToString();
    return str.Length <= 0 ? base.ToString() : str;
  }

  public static void Decode(List<string> SL, ref buShape refShape, string Char = "")
  {
    try
    {
      if (SL.Count < 2)
        return;
      if (SL[0].Trim() == "buShapeRectangle")
      {
        double width = buSerilization5.DecoderFromDouble(SL[1]);
        double height = buSerilization5.DecoderFromDouble(SL[2]);
        double angle = buSerilization5.DecoderFromDouble(SL[3]);
        double radius = buSerilization5.DecoderFromDouble(SL[4]);
        double chamfer = buSerilization5.DecoderFromDouble(SL[5]);
        if (width > 0.0 & height > 0.0)
          refShape = (buShape) new buUpperLineEnt(width, height, radius, chamfer, 0.0, angle);
      }
      if (SL[0].Trim() == "buShapeCircle")
      {
        double radius = buSerilization5.DecoderFromDouble(SL[1]);
        if (radius > 0.0)
          refShape = (buShape) new buUpperLineEnt(radius, 0.0);
      }
      if (SL[0].Trim() == "buShapeEllipse")
      {
        double radiusx = buSerilization5.DecoderFromDouble(SL[1]);
        double radiusy = buSerilization5.DecoderFromDouble(SL[2]);
        double angle = buSerilization5.DecoderFromDouble(SL[3]);
        if (radiusx > 0.0 & radiusy > 0.0)
          refShape = (buShape) new buUpperLineEnt(radiusx, radiusy, 0.0, angle);
      }
      if (SL[0].Trim() == "buShapePolygon")
      {
        double radius = buSerilization5.DecoderFromDouble(SL[1]);
        int side = buSerilization5.DecoderFromInt(SL[2]);
        double angle = buSerilization5.DecoderFromDouble(SL[3]);
        if (radius > 0.0 & side > 2)
          refShape = (buShape) new buUpperLineEnt(radius, side, 0.0, angle);
      }
      if (SL[0].Trim() == "buShapeSlot")
      {
        double diameter = buSerilization5.DecoderFromDouble(SL[1]);
        double length = buSerilization5.DecoderFromDouble(SL[2]);
        double angle = buSerilization5.DecoderFromDouble(SL[3]);
        if (diameter > 0.0 & length > 0.0)
          refShape = (buShape) new buUpperLineEnt(diameter, length, 0.0, angle);
      }
      if (SL[0].Trim() == "buShapeKeyHole")
      {
        double headdiameter = buSerilization5.DecoderFromDouble(SL[1]);
        double diameter = buSerilization5.DecoderFromDouble(SL[2]);
        double length = buSerilization5.DecoderFromDouble(SL[3]);
        double angle = buSerilization5.DecoderFromDouble(SL[4]);
        if (diameter > 0.0 & length > 0.0 & headdiameter > 0.0)
          refShape = (buShape) new buLinearPathArrow(headdiameter, diameter, length, 0.0, angle);
      }
      if (SL[0].Trim() == "buShapeFreeDraw")
      {
        double width = buSerilization5.DecoderFromDouble(SL[1]);
        double height = buSerilization5.DecoderFromDouble(SL[2]);
        double angle = buSerilization5.DecoderFromDouble(SL[3]);
        if (width > 0.0 & height > 0.0)
          refShape = (buShape) new buLinearPathArrow(width, height, 0.0, angle);
      }
      if (SL[0].Trim() == "buShapeFreeLines")
      {
        double width = buSerilization5.DecoderFromDouble(SL[1]);
        double height = buSerilization5.DecoderFromDouble(SL[2]);
        if (width > 0.0 & height > 0.0)
          refShape = (buShape) new buLinearPathArrow(width, height, 0.0);
      }
      if (SL[0].Trim() == "buShapeHole")
      {
        double diameter = buSerilization5.DecoderFromDouble(SL[1]);
        drillTypes drillTypes = buSerilization5.DecoderFromDrillType(SL[2]);
        bool flag = buSerilization5.DecoderFromBool(SL[3]);
        if (diameter > 0.0)
        {
          refShape = (buShape) new buLinearPathArrow(diameter, 0.0);
          ((DiemakerGrindingShapeSettings) refShape).isMilling = flag;
          ((DiemakerGrindingShapeSettings) refShape).DrillType = drillTypes;
        }
      }
      if (SL[0].Trim() == "buShapeHoleMulti")
      {
        double diameter = buSerilization5.DecoderFromDouble(SL[1]);
        drillTypes type = buSerilization5.DecoderFromDrillType(SL[2]);
        bool flag = buSerilization5.DecoderFromBool(SL[3]);
        int count = buSerilization5.DecoderFromInt(SL[4]);
        double distance = buSerilization5.DecoderFromDouble(SL[5]);
        double startdistance = buSerilization5.DecoderFromDouble(SL[6]);
        double enddistance = buSerilization5.DecoderFromDouble(SL[7]);
        double Angle = buSerilization5.DecoderFromDouble(SL[8]);
        if (diameter > 0.0)
        {
          refShape = (buShape) new buLinearPathArrow(type, diameter, count, distance, startdistance, enddistance, 0.0, Angle);
          ((DiemakerGrindingShapeSettings) refShape).isMilling = flag;
        }
      }
      if (SL[0].Trim() == "buShapeHole3")
      {
        double diameter = buSerilization5.DecoderFromDouble(SL[1]);
        int num = (int) buSerilization5.DecoderFromDrillType(SL[2]);
        bool flag = buSerilization5.DecoderFromBool(SL[3]);
        double diameteroutside = buSerilization5.DecoderFromDouble(SL[4]);
        double angle = buSerilization5.DecoderFromDouble(SL[5]);
        double distancex = buSerilization5.DecoderFromDouble(SL[6]);
        double distancey = buSerilization5.DecoderFromDouble(SL[7]);
        if (diameter > 0.0)
        {
          refShape = (buShape) new buSelectionPoint(diameter, 0.0, diameteroutside, distancex, distancey, angle);
          ((DiemakerGrindingShapeSettings) refShape).isMilling = flag;
        }
      }
      if (SL[0].Trim() == "buShapeCut")
      {
        double diameter = buSerilization5.DecoderFromDouble(SL[1]);
        double length = buSerilization5.DecoderFromDouble(SL[2]);
        double angle = buSerilization5.DecoderFromDouble(SL[3]);
        double startdistance = buSerilization5.DecoderFromDouble(SL[4]);
        double enddistance = buSerilization5.DecoderFromDouble(SL[5]);
        CutTypes slotType = buSerilization5.DecoderFromCutType(SL[6]);
        bool flag = buSerilization5.DecoderFromBool(SL[7]);
        if (diameter > 0.0)
        {
          refShape = (buShape) new buSelectionPoint(slotType, diameter, 0.0, length, startdistance, enddistance, angle);
          ((DiemakerGrindingShapeSettings) refShape).isMilling = flag;
        }
      }
      if (SL[0].Trim() == "buShapeProfiling")
      {
        double radius = buSerilization5.DecoderFromDouble(SL[1]);
        double length = buSerilization5.DecoderFromDouble(SL[2]);
        double width = buSerilization5.DecoderFromDouble(SL[3]);
        double height = buSerilization5.DecoderFromDouble(SL[4]);
        ProfilingTypes profilingType = buSerilization5.DecoderFromProfilingType(SL[5]);
        if (radius > 0.0 | length > 0.0 | width > 0.0 | height > 0.0)
          refShape = (buShape) new buSelectionPoint(profilingType, radius, 0.0, length, width, height);
      }
      if (SL[0].Trim() == "buShapeJunction")
      {
        double diameter = buSerilization5.DecoderFromDouble(SL[1]);
        double diameteroutside = buSerilization5.DecoderFromDouble(SL[2]);
        double distance = buSerilization5.DecoderFromDouble(SL[3]);
        JunctionTypes junctionType = buSerilization5.DecoderFromJunctionType(SL[4]);
        bool ismilling = buSerilization5.DecoderFromBool(SL[5]);
        if (diameter > 0.0 | diameteroutside > 0.0)
          refShape = (buShape) new buSelectionPoint(junctionType, diameter, 0.0, diameteroutside, distance, ismilling);
      }
      if (SL[0].Trim() == "buShapeText")
      {
        double width = buSerilization5.DecoderFromDouble(SL[1]);
        double height = buSerilization5.DecoderFromDouble(SL[2]);
        double angle = buSerilization5.DecoderFromDouble(SL[3]);
        string textString = SL[4].Trim();
        string familyName = SL[5].Trim();
        float emSize = buSerilization5.DecoderFromFloat(SL[6]);
        string str1 = SL[7].Trim();
        if (width > 0.0 & height > 0.0)
        {
          string str2 = str1;
          EnumConverter enumConverter = new EnumConverter(typeof (FontStyle));
          Font font = new Font(familyName, emSize, (FontStyle) enumConverter.ConvertFromString(str2.ToString()));
          refShape = (buShape) new buMaterial(width, height, 0.0, textString, font, angle);
        }
      }
      if (SL[0].Trim() == "buShapeNotch")
      {
        double width = buSerilization5.DecoderFromDouble(SL[1]);
        double height = buSerilization5.DecoderFromDouble(SL[2]);
        double startheight = buSerilization5.DecoderFromDouble(SL[3]);
        buSerilization5.DecoderFromDouble(SL[4]);
        UpDownLocationType updown = buSerilization5.DecoderFromUpDownLocationType(SL[5]);
        FrontBackType frontback = buSerilization5.DecoderFromFrontBackType(SL[6]);
        ProfileNotchLocationType location = buSerilization5.DecoderFromProfileNotchLocationType(SL[7]);
        ProfileNotchOperationType NotchOpType = buSerilization5.DecoderFromProfileNotchOperationType(SL[8]);
        if (width > 0.0 | height > 0.0)
          refShape = (buShape) new CustomData(width, height, startheight, 0.0, updown, location, NotchOpType, frontback);
      }
      List<string> CalcList = new List<string>();
      buImage5.ListToSpecificList("<CommonShape>", "</CommonShape>", false, SL, ref CalcList);
      buMachinePart.DecodeCommon(CalcList, ref refShape);
    }
    catch (Exception ex)
    {
    }
  }

  public static buShape Decode(List<string> SL)
  {
    try
    {
      buShape refShape = (buShape) null;
      buTool.Decode(SL, ref refShape);
      return refShape;
    }
    catch (Exception ex)
    {
      return (buShape) null;
    }
  }
}
