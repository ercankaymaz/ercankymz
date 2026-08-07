// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.Forms.PanelCut;
using devDept;
using devDept.Eyeshot.Translators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

#nullable disable
namespace \u0001;

internal class \u0002
{
  public const MarbleCommandsEntity Operation = ; // Unable to render the field
  public const MarbleCommandsEntity Slat = ; // Unable to render the field

  static object[] \u0001(
    [In] int obj0,
    [In] Image obj1,
    [In] F_PanelCutSheetList obj2,
    [In] int obj3,
    [In] double obj4,
    [In] double obj5,
    [In] int obj6,
    [In] string obj7,
    [In] double obj8,
    [In] double obj9,
    [In] double obj10,
    [In] string obj11,
    [In] int obj12,
    [In] bool obj13)
  {
    return new object[14]
    {
      (object) obj3,
      (object) obj13,
      (object) obj7,
      (object) obj1,
      (object) Math.Round(obj10, 2),
      (object) Math.Round(obj9, 2),
      (object) Math.Round(obj4, 2),
      (object) obj6,
      (object) obj0,
      (object) obj12,
      (object) Math.Round(obj8, 2),
      (object) Math.Round(obj5, 2),
      (object) obj11,
      null
    };
  }

  static void \u0001([In] string obj0, [In] F_SketchLibrary obj1)
  {
    try
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\L");
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      buVector5.ExtractToFolder(directoryInfo.FullName, obj0);
      List<string> Files = new List<string>();
      buFile5.bunesting.getFiles(AppPath.Base + "\\L", ref Files);
      string filePath = "";
      ((F_RotatePanel) obj1).OpenCustomData = new List<EditorCustomData>();
      for (int index = 0; index <= Files.Count - 1; ++index)
      {
        FileInfo fileInfo = new FileInfo(Files[index]);
        if (fileInfo.Exists)
        {
          if (fileInfo.Extension == ".buLibEye")
            filePath = fileInfo.FullName;
          if (fileInfo.Extension == ".buLibSet")
            ;
        }
      }
      if (filePath.Length <= 0)
        return;
      ReadFile readFile = new ReadFile(filePath);
      ((F_RotatePanel) obj1).viewport.Clear();
      ((F_RotatePanel) obj1).viewport.StartWork((WorkUnit) readFile);
    }
    catch (Exception ex)
    {
    }
  }

  static void \u0001([In] int obj0, [In] F_LaserMaterial obj1)
  {
    ((F_NestRectPartAdd) obj1).\u0002.Items.Clear();
    if (obj0 < 0)
      return;
    for (int index = 0; index <= ((F_NestPartAdd) obj1).Materials[obj0].Orders.Count - 1; ++index)
      ((F_NestRectPartAdd) obj1).\u0002.Items.Add((object) ((F_NestPartAdd) obj1).Materials[obj0].Orders[index].DefineationName);
  }

  static void \u0001([In] F_CamRough4XSettings obj0)
  {
    string callMethod = "F_CamRough4XSettings";
    try
    {
      ((buShapeEllipse) obj0).buGround1.Text = $"{buLangTranslate.preDef.Rough} 4 {buLangTranslate.preDef.Axes} {buLangTranslate.preDef.Settings}";
      ((buShapePolygon) obj0).spn_topoffet.Caption.Caption = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Offset}";
      ((buShapeSlot) obj0).spn_bottomoffst.Caption.Caption = $"{buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Offset}";
      ((buShapeFreeLines) obj0).spn_leftoffset.Caption.Caption = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Offset}";
      ((buShapeHole) obj0).spn_rightoffset.Caption.Caption = $"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.Offset}";
      ((buShapeKeyHole) obj0).spn_depthstartoffset.Caption.Caption = $"{buLangTranslate.preDef.Depth} {buLangTranslate.preDef.Start} {buLangTranslate.preDef.Offset}";
      ((buShapeKeyHole) obj0).spn_depthendoffset.Caption.Caption = $"{buLangTranslate.preDef.Depth} {buLangTranslate.preDef.End} {buLangTranslate.preDef.Offset}";
      ((buShapeSlot) obj0).spn_depthstep.Caption.Caption = $"{buLangTranslate.preDef.Depth} {buLangTranslate.preDef.Step}";
      ((buShapeKeyHole) obj0).spn_toolstepover.Caption.Caption = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Stepover}";
      ((buShapeKeyHole) obj0).spn_plungespeed.Caption.Caption = $"{buLangTranslate.preDef.Plunge} {buLangTranslate.preDef.Feed}";
      ((buShapeFreeDraw) obj0).spn_cuttingspeed.Caption.Caption = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Feed}";
      ((buShapeFreeDraw) obj0).spn_safedistance.Caption.Caption = buLangTranslate.preDef.SafeDistance;
      ((buShapeFreeDraw) obj0).spn_rapiddistance.Caption.Caption = buLangTranslate.preDef.RapidDistance;
      ((buShapeFreeLines) obj0).chk_showadvancedsettings.Text = $"{buLangTranslate.preDef.Advanced} {buLangTranslate.preDef.Settings} {buLangTranslate.preDef.Show}";
      ((buShapePolygon) obj0).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((buShapeSlot) obj0).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }
}
