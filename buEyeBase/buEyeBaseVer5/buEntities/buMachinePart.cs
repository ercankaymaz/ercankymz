// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buMachinePart
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.ClassViewer;
using devDept.Eyeshot.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buMachinePart : BlockReference
{
  public int RowHeight;
  public int RowSpace;
  public int DecimalPlace;
  public Font FontCaptions;
  public Font FontValues;
  public int ValueWidth;
  public bool ShowOkButton;
  public bool ShowCancelButton;
  public string OkButtonText;
  public string CancelButtonText;
  public object ClassObject;
  public Form OwnerForm;
  public TouchPadType TouchPayStyle;
  public List<string> ParCaptions;
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
  public static byte f0037EB;
  public string OkCaption;
  public string CancelCaption;
  public string FormCaption;

  public static void DecodeCommon(List<string> SL, ref buShape refEntity)
  {
    try
    {
      if (!(refEntity != null & SL.Count >= 4))
        return;
      ((\u0080.\u0001) refEntity).ShapeName = buSerilization5.DecoderFromString(SL[0]);
      ((\u0080.\u0001) refEntity).Defination = buSerilization5.DecoderFromString(SL[1]);
      ((\u0080.\u0001) refEntity).Aux = buSerilization5.DecoderFromString(SL[2]);
      ((\u0080.\u0001) refEntity).ID = buSerilization5.DecoderFromInt(SL[3]);
      ((\u0080.\u0001) refEntity).Index = buSerilization5.DecoderFromInt(SL[4]);
      ((\u0080.\u0001) refEntity).Zone = buSerilization5.DecoderFromInt(SL[5]);
      ((\u0012.\u0002) refEntity).Depth = buSerilization5.DecoderFromDouble(SL[6]);
      ((\u0012.\u0002) refEntity).DepthExtra = buSerilization5.DecoderFromDouble(SL[7]);
      ((\u0012.\u0002) refEntity).OffsetDistance = buSerilization5.DecoderFromDouble(SL[8]);
      ((\u0081.\u0001) refEntity).feedCutting = buSerilization5.DecoderFromDouble(SL[9]);
      ((\u0081.\u0001) refEntity).feedPlunge = buSerilization5.DecoderFromDouble(SL[10]);
      ((\u0081.\u0001) refEntity).SpindleSpeed = buSerilization5.DecoderFromDouble(SL[11]);
      ((buClipperBase) refEntity).Enable = buSerilization5.DecoderFromBool(SL[12]);
      ((buClipperBase) refEntity).isEngraving = buSerilization5.DecoderFromBool(SL[13]);
      ((buClipperBase) refEntity).isPocket = buSerilization5.DecoderFromBool(SL[14]);
      ((buClipperBase) refEntity).planeName = buSerilization5.DecoderFromPlaneBoxNames(SL[15]);
      ((buClipperBase) refEntity).ShapeGroup = buSerilization5.DecoderFromShapeGroup(SL[16 /*0x10*/]);
      ((buClipperBase) refEntity).Corner = buSerilization5.DecoderFromCornerLocation(SL[17]);
      ((buClipperBase) refEntity).Alignment = buSerilization5.DecoderFromObjectAlignment(SL[18]);
      ((buClipperBase) refEntity).ShapeType = buSerilization5.DecoderFromShapeTypes(SL[19]);
      ((ClipperOffset) refEntity).OperationColor = buFile5.StringToColor(SL[20], ColorConvertType.String);
      ((buClipper) refEntity).CornerPoint = buSerilization5.DecoderFromPoint3D(SL[21]);
      ((buClipper) refEntity).BasePoint = buSerilization5.DecoderFromPoint3D(SL[22]);
      ((buClipper) refEntity).Offset = buSerilization5.DecoderFromPoint3D(SL[23]);
      ((buClipper) refEntity).CalculatedPoint = buSerilization5.DecoderFromPoint3D(SL[24]);
      ((buClipper) refEntity).CornerDirection = buSerilization5.DecoderFromVector3D(SL[25]);
      ((buClipper) refEntity).planeOperation = buSerilization5.DecoderFromPlane(SL[26]);
      string str = buSerilization5.DecoderFromString(SL[27]);
      if (str.Trim().Length > 0)
      {
        if (ClipperOffset.ToolList.Count == 0)
        {
          ((buClipper.\u0001) refEntity).Tool = (ToolBase5) new ToolGeometry5();
          ((ToolCamData5) ((ToolGeometry5) ((buClipper.\u0001) refEntity).Tool).Data).Name = str;
        }
        else
        {
          for (int index = 0; index <= ClipperOffset.ToolList.Count - 1; ++index)
          {
            if (((ToolCamData5) ((ToolGeometry5) ClipperOffset.ToolList[index]).Data).Name.Trim() == str.Trim())
              ((buClipper.\u0001) refEntity).Tool = (ToolBase5) new ToolGeometry5(ClipperOffset.ToolList[index]);
          }
        }
      }
      object edit = (object) ((buClipperBase) refEntity).Edit;
      buSerilization5.StringToClass(ref edit, SL[28]);
      object arrayData = (object) ((ShapeRuntimeData) ((buClipperBase) refEntity).Edit).ArrayData;
      buSerilization5.StringToClass(ref arrayData, SL[29]);
      object mirrorData = (object) ((ShapeRuntimeData) ((buClipperBase) refEntity).Edit).MirrorData;
      buSerilization5.StringToClass(ref mirrorData, SL[30]);
      object itemSize = (object) ((buClipperBase) refEntity).ItemSize;
      buSerilization5.StringToClass(ref itemSize, SL[31 /*0x1F*/]);
      object leadInOut = (object) ((buClipper) refEntity).LeadInOut;
      buSerilization5.StringToClass(ref leadInOut, SL[32 /*0x20*/]);
      if (SL[33].IndexOf("SecondToolName") >= 0)
        ((\u0080.\u0001) refEntity).SecondToolName = buSerilization5.DecoderFromString(SL[33]);
      List<string> CalcList1 = new List<string>();
      buStatics.ListToSpecificList("<DepthLevel>", "</DepthLevel>", false, SL, ref CalcList1);
      if (CalcList1.Count > 0)
      {
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          double result = 0.0;
          if (double.TryParse(CalcList1[index], out result))
            ((buClipperBase) refEntity).DepthLevel.Add(result);
        }
      }
      List<string> CalcList2 = new List<string>();
      buStatics.ListToSpecificList("<CamParametersAll>", "</CamParametersAll>", false, SL, ref CalcList2);
      if (CalcList2.Count > 0)
        camOffset5.DecodeSingleLine(CalcList2, "", ref ((buClipper) refEntity).CamPar);
      List<string> CalcList3 = new List<string>();
      List<List<string>> CalcList4 = new List<List<string>>();
      buStatics.ListToSpecificList("<entitiesShape>", "</entitiesShape>", false, SL, ref CalcList3);
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList3, ref CalcList4);
      ((buClipper) refEntity).entitiesShape = new List<buEntity>();
      for (int index = 0; index <= CalcList4.Count - 1; ++index)
      {
        buEntity buEntity = buText.Decode(CalcList4[index]);
        if (buEntity != null)
          ((buClipper) refEntity).entitiesShape.Add(buEntity);
      }
      CalcList3.Clear();
      CalcList4.Clear();
      CalcList3 = new List<string>();
      List<List<string>> CalcList5 = new List<List<string>>();
      buStatics.ListToSpecificList("<entitiesCam>", "</entitiesCam>", false, SL, ref CalcList3);
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList3, ref CalcList5);
      ((buClipper) refEntity).entitiesCam = new List<buEntity>();
      for (int index = 0; index <= CalcList5.Count - 1; ++index)
      {
        buEntity buEntity = buText.Decode(CalcList5[index]);
        if (buEntity != null)
          ((buClipper) refEntity).entitiesCam.Add(buEntity);
      }
      CalcList3.Clear();
      CalcList5.Clear();
      CalcList3 = new List<string>();
      List<List<string>> CalcList6 = new List<List<string>>();
      buStatics.ListToSpecificList("<entitiesRef>", "</entitiesRef>", false, SL, ref CalcList3);
      if (CalcList3.Count <= 0)
        return;
      buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList3, ref CalcList6);
      ((buClipper) refEntity).entitiesRef = new List<buEntity>();
      for (int index = 0; index <= CalcList6.Count - 1; ++index)
      {
        buEntity buEntity = buText.Decode(CalcList6[index]);
        if (buEntity != null)
          ((buClipper) refEntity).entitiesRef.Add(buEntity);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static ArrayList ToDefShape(buShape refEntity, int Space)
  {
    ArrayList AL = new ArrayList();
    buMachinePart.ToDefShape(refEntity, Space, ref AL);
    return AL;
  }

  public static void ToDefShape(buShape refEntity, int Space, ref ArrayList AL)
  {
    AL.Clear();
    AL = new ArrayList();
    AL.AddRange((ICollection) ((buMaterialMoveable) refEntity).ToDef(Space));
  }

  public static void ToDefShape(List<buShape> refEntities, int Space, ref ArrayList AL)
  {
    AL.Clear();
    AL = new ArrayList();
    for (int index = 0; index <= refEntities.Count - 1; ++index)
      AL.AddRange((ICollection) ((buMaterialMoveable) refEntities[index]).ToDef(Space));
  }

  public static ArrayList ToDefShape(List<buShape> refEntities, int Space)
  {
    ArrayList AL = new ArrayList();
    buMachinePart.ToDefShape(refEntities, Space, ref AL);
    return AL;
  }
}
