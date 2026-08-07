// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Jewel.clsJewel
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buClass.Apps;
using buControls.Forms.WinControlForms.Errors;
using buControls.Forms.WinControlForms.Events;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Marble;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Jewel;

public class clsJewel
{
  public static List<JewelMode> JewelModes = (List<JewelMode>) null;
  public F_JewelModes frmModes = (F_JewelModes) null;
  public F_JewelModeSelection frmModesSelection = (F_JewelModeSelection) null;
  public static JewelProgramSettings varJewelSettings = new JewelProgramSettings();
  public static JewelRuntimeSettings varJewelRuntimeSettings = new JewelRuntimeSettings();

  public void Init()
  {
    clsJewel.JewelModes = new List<JewelMode>();
    this.frmModesSelection = new F_JewelModeSelection();
    this.frmModes = new F_JewelModes();
    buMWJewelVars.Init();
    FileInfo fileInfo = new FileInfo(AppPath.Base + "\\Misc\\JewelModes.bujewelmode");
    if (!fileInfo.Exists)
      return;
    clsJewel.JewelModeOpen(fileInfo.FullName);
  }

  public void cmdCamCreatGCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;
        clsVar.varInterface.pathGCode = buFile.GetPath(saveFileDialog.FileName);
        string Lines = "";
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
        buFile.SaveToFile(Lines, saveFileDialog.FileName);
        clsFiles.SaveParameter();
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamShowGCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        string Lines = "";
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(Lines);
        fNotepad.Show();
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdModes()
  {
    try
    {
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdZHeight()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num1 = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        if (ccVars.SelectionOP.Selections.Count == 0)
          return;
        clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, true, ref MinPoint, ref MidPoint, ref MaxPoint);
        F_MoveXYZHeights fMoveXyzHeights = new F_MoveXYZHeights();
        fMoveXyzHeights.Settings = new MoveHeightEventVar(clsVar.varInterface.MoveHeightVar);
        fMoveXyzHeights.txt_ztop.Text = "Max Z : " + MaxPoint.Z.ToString();
        fMoveXyzHeights.txt_zbottom.Text = "Min Z : " + MinPoint.Z.ToString();
        fMoveXyzHeights.txt_xrightpos.Text = "Max Y : " + MaxPoint.X.ToString();
        fMoveXyzHeights.txt_xfleftpos.Text = "Min Y : " + MinPoint.X.ToString();
        fMoveXyzHeights.txt_ybackpos.Text = "Max X : " + MaxPoint.Y.ToString();
        fMoveXyzHeights.txt_yfrontpos.Text = "Min Y : " + MinPoint.Y.ToString();
        fMoveXyzHeights.Init();
        int num2 = (int) fMoveXyzHeights.ShowDialog();
        if (fMoveXyzHeights.PropertiesForm.Result != DialogResult.OK)
          return;
        clsVar.varInterface.MoveHeightVar = new MoveHeightEventVar(fMoveXyzHeights.Settings);
        if (clsVar.varInterface.MoveHeightVar.Axis == AxesXYZ.Z)
        {
          if (clsVar.varInterface.MoveHeightVar.ZType == TopBottomType.Top)
            clsInit.appCommand.Move(new Point3D(0.0, 0.0, MaxPoint.Z), new Point3D(0.0, 0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition));
          if (clsVar.varInterface.MoveHeightVar.ZType == TopBottomType.Bottom)
            clsInit.appCommand.Move(new Point3D(0.0, 0.0, MinPoint.Z), new Point3D(0.0, 0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition));
        }
        if (clsVar.varInterface.MoveHeightVar.Axis == AxesXYZ.X)
        {
          if (clsVar.varInterface.MoveHeightVar.XType == LeftRightType.Left)
            clsInit.appCommand.Move(new Point3D(MinPoint.X, 0.0, 0.0), new Point3D(clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0, 0.0));
          if (clsVar.varInterface.MoveHeightVar.XType == LeftRightType.Right)
            clsInit.appCommand.Move(new Point3D(MaxPoint.X, 0.0, 0.0), new Point3D(clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0, 0.0));
        }
        if (clsVar.varInterface.MoveHeightVar.Axis == AxesXYZ.Y)
        {
          if (clsVar.varInterface.MoveHeightVar.YType == FrontBackType.Front)
            clsInit.appCommand.Move(new Point3D(0.0, MinPoint.Y, 0.0), new Point3D(0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0));
          if (clsVar.varInterface.MoveHeightVar.YType == FrontBackType.Back)
            clsInit.appCommand.Move(new Point3D(0.0, MaxPoint.Y, 0.0), new Point3D(0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0));
        }
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void JewelModesToParameter(JewelMode Mode)
  {
  }

  public static void JewelModeOpen(string FileName)
  {
  }

  public static void JewelModeSave(string FileName, bool CheckExist)
  {
  }

  public void SaveJewelFile()
  {
    string FileName1 = AppPath.Settings + "\\Jewel\\Jewel.prm";
    ArrayList StringList1 = new ArrayList();
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "   Jewel Settings");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "<JewelSettings>");
    StringList1.AddRange((ICollection) clsJewel.varJewelSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</JewelSettings>");
    StringList1.Add((object) "<JewelRuntimeSettings>");
    StringList1.AddRange((ICollection) clsJewel.varJewelRuntimeSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</JewelRuntimeSettings>");
    buFile.SaveToFile(StringList1, FileName1);
    buLog.addLog("Jewel Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    buMWJewelVars.varCamMeshRough.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelMeshRough.bin");
    buMWJewelVars.varCamMeshParelelCut.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelMeshParalel.bin");
    buMWJewelVars.varCamMeshConstantZ.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelMeshContantZ.bin");
    buMWJewelVars.varCamWireDrill4X.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelDrill4X.bin");
    buMWJewelVars.varCamWireDrill.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelDrill.bin");
    buMWJewelVars.varCamWireSpin.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelSpin.bin");
    buMWJewelVars.varCamWireContour.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelWFContour4X.bin");
    buMWJewelVars.varCamWireContour4X.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelWFContour.bin");
    buMWJewelVars.varCamWirePocket.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelWFPocket.bin");
    string FileName2 = AppPath.Settings + "\\Jewel\\JewelCam.bucamset";
    ArrayList StringList2 = new ArrayList();
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "   Cam Settings");
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "<BuCamSettings>");
    StringList2.AddRange((ICollection) buMWJewelVars.varCamMeshRough.buPar.ToDefAll("_varbuCamMeshRoughPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamMeshParelelCut.buPar.ToDefAll("_varbuCamMeshParallelPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamMeshConstantZ.buPar.ToDefAll("_varbuCamMeshConstantZPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamWireDrill4X.buPar.ToDefAll("_varbuCamDrill4XPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamWireDrill.buPar.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamWireSpin.buPar.ToDefAll("_varbuCamSpinPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamWireContour4X.buPar.ToDefAll("_varbuCamWFContour4XPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamWireContour.buPar.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWJewelVars.varCamWirePocket.buPar.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
    StringList2.Add((object) "</BuCamSettings>");
    buFile.SaveToFile(StringList2, FileName2);
  }

  public void OpenJewelFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Jewel\\Jewel.prm");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<JewelSettings>", "</JewelSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsJewel.varJewelSettings);
            buLog.addLog("Jewel Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<JewelRuntimeSettings>", "</JewelRuntimeSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsJewel.varJewelRuntimeSettings);
            buLog.addLog("Jewel RuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Jewel Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Jewel Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Jewel Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Jewel Settings File Missing");
      }
      buLog.addLog("Jewel Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelMeshRough.bin");
      if (fileInfo2.Exists)
        buMWJewelVars.varCamMeshRough.mwPar.Deserialize(fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelMeshParalel.bin");
      if (fileInfo3.Exists)
        buMWJewelVars.varCamMeshParelelCut.mwPar.Deserialize(fileInfo3.FullName);
      FileInfo fileInfo4 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelMeshContantZ.bin");
      if (fileInfo4.Exists)
        buMWJewelVars.varCamMeshConstantZ.mwPar.Deserialize(fileInfo4.FullName);
      FileInfo fileInfo5 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelDrill4X.bin");
      if (fileInfo5.Exists)
        buMWJewelVars.varCamWireDrill4X.mwPar.Deserialize(fileInfo5.FullName);
      FileInfo fileInfo6 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelDrill.bin");
      if (fileInfo6.Exists)
        buMWJewelVars.varCamWireDrill.mwPar.Deserialize(fileInfo6.FullName);
      FileInfo fileInfo7 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelSpin.bin");
      if (fileInfo7.Exists)
        buMWJewelVars.varCamWireSpin.mwPar.Deserialize(fileInfo7.FullName);
      FileInfo fileInfo8 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelWFContour4X.bin");
      if (fileInfo8.Exists)
        buMWJewelVars.varCamWireContour4X.mwPar.Deserialize(fileInfo8.FullName);
      FileInfo fileInfo9 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelWFContour.bin");
      if (fileInfo9.Exists)
        buMWJewelVars.varCamWireContour.mwPar.Deserialize(fileInfo9.FullName);
      FileInfo fileInfo10 = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelWFPocket.bin");
      if (fileInfo10.Exists)
        buMWJewelVars.varCamWirePocket.mwPar.Deserialize(fileInfo10.FullName);
      string str = AppPath.Settings + "\\Jewel\\JewelCam.bucamset";
      if (new FileInfo(str).Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(str, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<BuCamSettings>", "</BuCamSettings>", true, StringList, ref CalcList);
          if (CalcList.Count <= 0)
            return;
          buSerilization.Decode(StringList, "_varbuCamMeshRoughPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamMeshRough.buPar);
          buSerilization.Decode(StringList, "_varbuCamMeshParallelPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamMeshParelelCut.buPar);
          buSerilization.Decode(StringList, "_varbuCamMeshConstantZPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamMeshConstantZ.buPar);
          buSerilization.Decode(StringList, "_varbuCamDrill4XPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamWireDrill4X.buPar);
          buSerilization.Decode(StringList, "_varbuCamDrillPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamWireDrill.buPar);
          buSerilization.Decode(StringList, "_varbuCamSpinPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamWireSpin.buPar);
          buSerilization.Decode(StringList, "_varbuCamWFContour4XPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamWireContour4X.buPar);
          buSerilization.Decode(StringList, "_varbuCamWFContourPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamWireContour.buPar);
          buSerilization.Decode(StringList, "_varbuCamWFPocketPars", SerilizationMode.MultiLine, (object) buMWJewelVars.varCamWirePocket.buPar);
        }
        catch (Exception ex)
        {
          buLog.addLog("bu Jeel Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Jewel Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Jewel Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Jewel Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("Jewel Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Jewel Settings Decoder Error");
    }
  }

  public void cmdCamContour(actionTypeBU Action)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = Action;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        switch (Action)
        {
          case actionTypeBU.camJewel3AXContour:
            camTp Cam1 = new camTp();
            this.doWireframeContour(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamWireframeType = CamWireFrameType.Contour,
              Mode = CamMode.WireFrame,
              DontApplyReset = true,
              isBuWireframeCalculation = true,
              AddToCamListInLocalCalculation = true,
              ShowLeadInOutPage = false
            }, ccVars.toolActive, ccVars.Action, ref Cam1);
            break;
          case actionTypeBU.camJewel3AXPocket:
            camTp Cam2 = new camTp();
            this.doWireframeContour(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamWireframeType = CamWireFrameType.Pocket,
              Mode = CamMode.WireFrame,
              isRough = true,
              DontApplyReset = true,
              AddToCamListInLocalCalculation = true,
              ShowLeadInOutPage = false
            }, ccVars.toolActive, ccVars.Action, ref Cam2);
            break;
          case actionTypeBU.camJewel4AXContour:
            camTp Cam3 = new camTp();
            this.doWireframeContour(new MWCalculationOptions()
            {
              NumberofAxis = 4,
              CamWireframeType = CamWireFrameType.Contour,
              Mode = CamMode.WireFrame,
              DontApplyReset = true,
              isBuWireframeCalculation = true,
              AddToCamListInLocalCalculation = true,
              ShowLeadInOutPage = false
            }, ccVars.toolActive, ccVars.Action, ref Cam3);
            break;
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public int cmdCamContourReCalculate(camTp OldCam, ref camTp NewCam)
  {
    try
    {
      MWCalculationOptions MWCalcoptions = new MWCalculationOptions(OldCam.MWCalcOptions);
      clsMW.CamEntities.Clear();
      if (OldCam.Action == actionTypeBU.camJewel3AXContour)
      {
        buMWJewelVars.varCamWireContour.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireContour.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doWireframeContour(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel3AXPocket)
      {
        buMWJewelVars.varCamWirePocket.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireContour.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doWireframeContour(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel4AXContour)
      {
        buMWJewelVars.varCamWireContour4X.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireContour4X.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doWireframeContour(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel3AXSpinConstant)
      {
        buMWJewelVars.varCamWireSpin.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireSpin.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doWireframeContour(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel4AXSpinRamp)
      {
        buMWJewelVars.varCamWireSpin.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireSpin.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doWireframeContour(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel3AXPunch)
      {
        buMWJewelVars.varCamWireDrill.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireDrill.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doDrill(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel4AXPunch)
      {
        buMWJewelVars.varCamWireDrill4X.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireDrill4X.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doDrill(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel4AXPointRotation)
      {
        buMWJewelVars.varCamWireDrill4X.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamWireDrill4X.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doDrill(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel3AXTriMeshRough)
      {
        buMWJewelVars.varCamMeshRough.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamMeshRough.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doTriangleMesh(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action == actionTypeBU.camJewel3AXTriMeshParalelCut)
      {
        buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
        buMWJewelVars.varCamMeshParelelCut.buPar = new camParameters5(OldCam.Parameter);
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
        MWCalcoptions.AddToCamListInLocalCalculation = false;
        NewCam = new camTp();
        return this.doTriangleMesh(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
      }
      if (OldCam.Action != actionTypeBU.camJewel3AXTriMeshConstantZ)
        return -1;
      buMWJewelVars.varCamMeshConstantZ.mwPar.MachParam = new MachiningParams((MachiningParams) OldCam.mwParameter);
      buMWJewelVars.varCamMeshConstantZ.buPar = new camParameters5(OldCam.Parameter);
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
      MWCalcoptions.AddToCamListInLocalCalculation = false;
      NewCam = new camTp();
      return this.doTriangleMesh(MWCalcoptions, ccVars.toolActive, OldCam.Action, ref NewCam);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return -1;
    }
  }

  public void cmdCamLathe(actionTypeBU Action)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = Action;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp Cam = new camTp();
        this.doLathe(new MWCalculationOptions()
        {
          NumberofAxis = 3,
          CamWireframeType = CamWireFrameType.Contour,
          Mode = CamMode.WireFrame,
          DontApplyReset = true,
          isBuWireframeCalculation = true,
          AddToCamListInLocalCalculation = true,
          ShowLeadInOutPage = false
        }, ccVars.toolActive, ccVars.Action, ref Cam);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamSpin(actionTypeBU Action)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = Action;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp Cam = new camTp();
        MWCalculationOptions MWCalcoptions = new MWCalculationOptions();
        MWCalcoptions.Action = ccVars.Action;
        MWCalcoptions.NumberofAxis = 3;
        MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
        MWCalcoptions.Mode = CamMode.WireFrame;
        MWCalcoptions.DontApplyReset = true;
        MWCalcoptions.AddToCamListInLocalCalculation = true;
        MWCalcoptions.ShowLeadInOutPage = false;
        switch (Action)
        {
          case actionTypeBU.camJewel4AXSpinRamp:
            MWCalcoptions.NumberofAxis = 4;
            MWCalcoptions.isSpinCalculation = true;
            break;
          case actionTypeBU.camJewel3AXSpinConstant:
            MWCalcoptions.isSpinConstantCalculation = true;
            break;
        }
        this.doWireframeContour(MWCalcoptions, ccVars.toolActive, ccVars.Action, ref Cam);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamTriangleMesh(actionTypeBU Action)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = Action;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        switch (Action)
        {
          case actionTypeBU.camJewel3AXTriMeshRough:
            camTp Cam1 = new camTp();
            this.doTriangleMesh(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamTriMeshType = CamTriangularMeshType.Rough,
              Mode = CamMode.TriangularMesh,
              isRough = true,
              DontApplyReset = true,
              AddToCamListInLocalCalculation = true
            }, ccVars.toolActive, Action, ref Cam1);
            break;
          case actionTypeBU.camJewel3AXTriMeshParalelCut:
            camTp Cam2 = new camTp();
            this.doTriangleMesh(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamTriMeshType = CamTriangularMeshType.ParallelCuts,
              Mode = CamMode.TriangularMesh,
              DontApplyReset = true,
              AddToCamListInLocalCalculation = true
            }, ccVars.toolActive, Action, ref Cam2);
            break;
          case actionTypeBU.camJewel3AXTriMeshConstantZ:
            camTp Cam3 = new camTp();
            this.doTriangleMesh(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamTriMeshType = CamTriangularMeshType.ConstantZ,
              Mode = CamMode.TriangularMesh,
              DontApplyReset = true,
              AddToCamListInLocalCalculation = true
            }, ccVars.toolActive, Action, ref Cam3);
            break;
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamDrill(actionTypeBU Action)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = Action;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        switch (Action)
        {
          case actionTypeBU.camJewel3AXPunch:
            camTp Cam1 = new camTp();
            this.doDrill(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamDrillType = CamDrillType.Line,
              CamDrillMode = CamDrillMode.Point,
              Mode = CamMode.Drill,
              DontApplyReset = true,
              AddToCamListInLocalCalculation = true
            }, ccVars.toolActive, Action, ref Cam1);
            break;
          case actionTypeBU.camJewel4AXPunch:
            camTp Cam2 = new camTp();
            this.doDrill(new MWCalculationOptions()
            {
              NumberofAxis = 4,
              CamDrillType = CamDrillType.Line,
              CamDrillMode = CamDrillMode.Tangent,
              Mode = CamMode.Drill,
              DontApplyReset = true,
              AddToCamListInLocalCalculation = true
            }, ccVars.toolActive, Action, ref Cam2);
            break;
          case actionTypeBU.camJewel4AXPointRotation:
            camTp Cam3 = new camTp();
            this.doDrill(new MWCalculationOptions()
            {
              NumberofAxis = 4,
              CamDrillType = CamDrillType.Line,
              CamDrillMode = CamDrillMode.Rotation,
              Mode = CamMode.Drill,
              DontApplyReset = true,
              AddToCamListInLocalCalculation = true
            }, ccVars.toolActive, Action, ref Cam3);
            break;
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public int doWireframeContour(
    MWCalculationOptions MWCalcoptions,
    ToolBase5 Tool,
    actionTypeBU Action,
    ref camTp Cam)
  {
    Cam = new camTp();
    double planeIncremental1 = buMWJewelVars.varCamWireContour.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    double planeIncremental2 = buMWJewelVars.varCamWireContour4X.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    if (Action == actionTypeBU.camJewel3AXContour)
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireContour.mwPar, buMWJewelVars.varCamWireContour.buPar, out clsMW.varbuCamWFContourPars);
    if (Action == actionTypeBU.camJewel4AXContour)
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireContour4X.mwPar, buMWJewelVars.varCamWireContour4X.buPar, out clsMW.varbuCamWFContourPars);
    if (Action == actionTypeBU.camJewel3AXPocket)
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWirePocket.mwPar, buMWJewelVars.varCamWirePocket.buPar, out clsMW.varbuCamWFContourPars);
    if (Action == actionTypeBU.camJewel3AXSpinConstant)
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireSpin.mwPar, buMWJewelVars.varCamWireSpin.buPar, out clsMW.varbuCamWFContourPars);
    if (Action == actionTypeBU.camJewel4AXSpinRamp)
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireSpin.mwPar, buMWJewelVars.varCamWireSpin.buPar, out clsMW.varbuCamWFContourPars);
    if (ccVars.MaterialList.Count > 0 && ccVars.MaterialList[clsVar.varInterface.MaterialIndex].Enable)
    {
      MWCalcoptions.CheckBoxBounding = true;
      MWCalcoptions.BoxBoundingMin.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.X;
      MWCalcoptions.BoxBoundingMin.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.Y;
      MWCalcoptions.BoxBoundingMin.Z = 0.0;
      MWCalcoptions.BoxBoundingMax.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.X;
      MWCalcoptions.BoxBoundingMax.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.Y;
      MWCalcoptions.BoxBoundingMax.Z = 0.0;
    }
    camResult Result = (camResult) null;
    int num1 = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    int num2;
    if (Result.Errors.Count > 0)
    {
      F_ErrorList fErrorList = new F_ErrorList();
      fErrorList.Init(Result.Errors);
      int num3 = (int) fErrorList.ShowDialog();
      clsInit.appCommand.Reset();
      num2 = -2;
    }
    else
    {
      if (Action == actionTypeBU.camJewel3AXContour)
        buMWJewelVars.varCamWireContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireContour.buPar);
      if (Action == actionTypeBU.camJewel4AXContour)
        buMWJewelVars.varCamWireContour4X.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireContour4X.buPar);
      if (Action == actionTypeBU.camJewel3AXPocket)
        buMWJewelVars.varCamWirePocket.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWirePocket.buPar);
      if (Action == actionTypeBU.camJewel3AXSpinConstant)
        buMWJewelVars.varCamWireSpin.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireSpin.buPar);
      if (Action == actionTypeBU.camJewel4AXSpinRamp)
        buMWJewelVars.varCamWireSpin.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireSpin.buPar);
      if (num1 < 1)
      {
        clsInit.appCommand.Reset();
        num2 = num1;
      }
      else
      {
        Cam.Mode = MWCalcoptions.Mode;
        Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
        Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
        Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
        Cam.Action = Action;
        if (MWCalcoptions.Mode == CamMode.WireFrame)
        {
          if (Tool.Geometry.GeometryType == ToolType.Saw)
          {
            Cam.PreCodes.Add((object) "G0 Z100");
            Cam.PreCodes.Add((object) "M40");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) ("M33 K" + Tool.CamData.SpindleSpeed.ToString()));
          }
          else
          {
            Cam.PreCodes.Add((object) "M41");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) ("M6 T" + Tool.Data.No.ToString()));
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) ("M3 K" + Tool.CamData.SpindleSpeed.ToString()));
          }
          if (MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
          {
            if (MWCalcoptions.NumberofAxis == 4)
            {
              buString5.AddToArrayList(ccVars.PostActive.JewellaryContour4AXPreCodes, ref Cam.PreCodes);
              for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
              {
                if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                  Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
              }
              buString5.AddToArrayList(ccVars.PostActive.JewellaryContour4AXAfterCodes, ref Cam.AfterCodes);
              for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
              {
                if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                  Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
              }
              if (MWCalcoptions.AddToCamListInLocalCalculation)
                clsInit.appCommand.CamAdd(Cam);
            }
            else if (MWCalcoptions.NumberofAxis == 3 & !MWCalcoptions.isSpinConstantCalculation)
            {
              buString5.AddToArrayList(ccVars.PostActive.JewellaryContour3AXPreCodes, ref Cam.PreCodes);
              for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
              {
                if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                  Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
              }
              buString5.AddToArrayList(ccVars.PostActive.JewellaryContour3AXAfterCodes, ref Cam.AfterCodes);
              for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
              {
                if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                  Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
              }
              if (MWCalcoptions.AddToCamListInLocalCalculation)
                clsInit.appCommand.CamAdd(Cam);
            }
            else if (MWCalcoptions.NumberofAxis == 3 & MWCalcoptions.isSpinConstantCalculation)
            {
              buString5.AddToArrayList(ccVars.PostActive.JewellarySpinConstant3AXPreCodes, ref Cam.PreCodes);
              for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
              {
                if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                  Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
              }
              buString5.AddToArrayList(ccVars.PostActive.JewellarySpinConstant3AXAfterCodes, ref Cam.AfterCodes);
              for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
              {
                if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                  Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
              }
              Cam.CamPoints[0].PreCodes.Add((object) ("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed.ToString()));
              if (MWCalcoptions.AddToCamListInLocalCalculation)
                clsInit.appCommand.CamAdd(Cam);
            }
          }
          if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
          {
            buString5.AddToArrayList(ccVars.PostActive.JewellaryPocket3AXPreCodes, ref Cam.PreCodes);
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            buString5.AddToArrayList(ccVars.PostActive.JewellaryPocket3AXAfterCodes, ref Cam.AfterCodes);
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            if (MWCalcoptions.AddToCamListInLocalCalculation)
              clsInit.appCommand.CamAdd(Cam);
          }
        }
        clsInit.appCommand.Reset();
        clsFiles.SaveParameter();
        num2 = 1;
      }
    }
    return num2;
  }

  public int doTriangleMesh(
    MWCalculationOptions MWCalcoptions,
    ToolBase5 Tool,
    actionTypeBU Action,
    ref camTp Cam)
  {
    Cam = new camTp();
    if (Action == actionTypeBU.camJewel3AXTriMeshRough)
      clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamMeshRough.mwPar, buMWJewelVars.varCamMeshRough.buPar, out clsMW.varbuCamMeshRoughPars);
    if (Action == actionTypeBU.camJewel3AXTriMeshParalelCut)
      clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamMeshParelelCut.mwPar, buMWJewelVars.varCamMeshParelelCut.buPar, out clsMW.varbuCamMeshParallelPars);
    if (Action == actionTypeBU.camJewel3AXTriMeshConstantZ)
      clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamMeshConstantZ.mwPar, buMWJewelVars.varCamMeshConstantZ.buPar, out clsMW.varbuCamMeshConstantZPars);
    if (ccVars.MaterialList.Count > 0 && ccVars.MaterialList[clsVar.varInterface.MaterialIndex].Enable)
    {
      MWCalcoptions.CheckBoxBounding = true;
      MWCalcoptions.BoxBoundingMin.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.X;
      MWCalcoptions.BoxBoundingMin.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.Y;
      MWCalcoptions.BoxBoundingMin.Z = 0.0;
      MWCalcoptions.BoxBoundingMax.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.X;
      MWCalcoptions.BoxBoundingMax.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.Y;
      MWCalcoptions.BoxBoundingMax.Z = 0.0;
    }
    camResult Result = (camResult) null;
    int num1 = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, Tool, ref Cam, ref Result);
    int num2;
    if (Result.Errors.Count > 0)
    {
      F_ErrorList fErrorList = new F_ErrorList();
      fErrorList.Init(Result.Errors);
      int num3 = (int) fErrorList.ShowDialog();
      clsInit.appCommand.Reset();
      num2 = -2;
    }
    else
    {
      if (Action == actionTypeBU.camJewel3AXTriMeshRough)
        buMWJewelVars.varCamMeshRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWJewelVars.varCamMeshRough.buPar);
      if (Action == actionTypeBU.camJewel3AXTriMeshParalelCut)
        buMWJewelVars.varCamMeshParelelCut.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWJewelVars.varCamMeshParelelCut.buPar);
      if (Action == actionTypeBU.camJewel3AXTriMeshConstantZ)
        buMWJewelVars.varCamMeshConstantZ.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWJewelVars.varCamMeshConstantZ.buPar);
      if (num1 < 1)
      {
        clsInit.appCommand.Reset();
        num2 = num1;
      }
      else
      {
        Cam.Mode = MWCalcoptions.Mode;
        Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
        Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
        Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
        Cam.Action = Action;
        if (MWCalcoptions.Mode == CamMode.TriangularMesh)
        {
          buString5.AddToArrayList(ccVars.PostActive.JewellaryTriangleMesh3AXPreCodes, ref Cam.PreCodes);
          for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
          {
            if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
              Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
          }
          buString5.AddToArrayList(ccVars.PostActive.JewellaryTriangleMesh3AXAfterCodes, ref Cam.AfterCodes);
          for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
          {
            if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
              Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
          }
          if (MWCalcoptions.AddToCamListInLocalCalculation)
            clsInit.appCommand.CamAdd(Cam);
        }
        clsInit.appCommand.Reset();
        clsFiles.SaveParameter();
        num2 = 1;
      }
    }
    return num2;
  }

  public int doDrill(
    MWCalculationOptions MWCalcoptions,
    ToolBase5 Tool,
    actionTypeBU Action,
    ref camTp Cam)
  {
    Cam = new camTp();
    if (Action == actionTypeBU.camJewel3AXPunch)
      clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireDrill.mwPar, buMWJewelVars.varCamWireDrill.buPar, out clsMW.varbuCamDrillPars);
    if (Action == actionTypeBU.camJewel4AXPunch)
      clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireDrill4X.mwPar, buMWJewelVars.varCamWireDrill4X.buPar, out clsMW.varbuCamDrillPars);
    if (Action == actionTypeBU.camJewel4AXPointRotation)
      clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireDrill4X.mwPar, buMWJewelVars.varCamWireDrill4X.buPar, out clsMW.varbuCamDrillPars);
    if (ccVars.MaterialList.Count > 0 && ccVars.MaterialList[clsVar.varInterface.MaterialIndex].Enable)
    {
      MWCalcoptions.CheckBoxBounding = true;
      MWCalcoptions.BoxBoundingMin.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.X;
      MWCalcoptions.BoxBoundingMin.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.Y;
      MWCalcoptions.BoxBoundingMin.Z = 0.0;
      MWCalcoptions.BoxBoundingMax.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.X;
      MWCalcoptions.BoxBoundingMax.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.Y;
      MWCalcoptions.BoxBoundingMax.Z = 0.0;
    }
    camResult Result = (camResult) null;
    int num1 = clsInit.appMW.doDrill(MWCalcoptions, Tool, ref Cam, ref Result);
    int num2;
    if (Result.Errors.Count > 0)
    {
      F_ErrorList fErrorList = new F_ErrorList();
      fErrorList.Init(Result.Errors);
      int num3 = (int) fErrorList.ShowDialog();
      clsInit.appCommand.Reset();
      num2 = -2;
    }
    else
    {
      if (Action == actionTypeBU.camJewel3AXPunch)
        buMWJewelVars.varCamWireDrill.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWJewelVars.varCamWireDrill.buPar);
      if (Action == actionTypeBU.camJewel4AXPunch)
        buMWJewelVars.varCamWireDrill4X.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWJewelVars.varCamWireDrill4X.buPar);
      if (Action == actionTypeBU.camJewel4AXPointRotation)
        buMWJewelVars.varCamWireDrill4X.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWJewelVars.varCamWireDrill4X.buPar);
      if (num1 < 1)
      {
        clsInit.appCommand.Reset();
        num2 = num1;
      }
      else
      {
        Cam.Mode = MWCalcoptions.Mode;
        Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
        Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
        Cam.CamDrillType = MWCalcoptions.CamDrillType;
        Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
        Cam.Action = Action;
        if (MWCalcoptions.Mode == CamMode.Drill)
        {
          if (MWCalcoptions.NumberofAxis == 4)
          {
            buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill4AXPreCodes, ref Cam.PreCodes);
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill4AXAfterCodes, ref Cam.AfterCodes);
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            clsInit.appCommand.CamAdd(Cam);
          }
          if (MWCalcoptions.NumberofAxis == 3)
          {
            buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill3AXPreCodes, ref Cam.PreCodes);
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill3AXAfterCodes, ref Cam.AfterCodes);
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            if (MWCalcoptions.AddToCamListInLocalCalculation)
              clsInit.appCommand.CamAdd(Cam);
          }
        }
        clsInit.appCommand.Reset();
        clsFiles.SaveParameter();
        num2 = 1;
      }
    }
    return num2;
  }

  public int doLathe(
    MWCalculationOptions MWCalcoptions,
    ToolBase5 Tool,
    actionTypeBU Action,
    ref camTp Cam)
  {
    Cam = new camTp();
    List<Entity> selectedEntities = new List<Entity>();
    SelectionOption Option = new SelectionOption();
    clsInit.appCommand.SelectionToEntities(ref selectedEntities, Option);
    Point3D MinPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    Point3D point3D = new Point3D();
    SortbuSettings Settings = new SortbuSettings();
    SortbuResult Result = new SortbuResult();
    Settings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
    Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
    List<Entity> entityList1 = new List<Entity>();
    List<buEntity> refEntities = new List<buEntity>();
    List<buEntity> SortedEntities = new List<buEntity>();
    buEntity.Copy(selectedEntities, ref refEntities);
    clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
    Point3D RefPoint = new Point3D();
    double minValue = double.MinValue;
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      if (refEntities[index].StartPoint.X > refEntities[index].EndPoint.X)
      {
        if (refEntities[index].StartPoint.X > minValue)
          RefPoint = buVector5.ToPoint3D(refEntities[index].StartPoint);
      }
      else if (refEntities[index].EndPoint.X > minValue)
        RefPoint = buVector5.ToPoint3D(refEntities[index].EndPoint);
    }
    clsInit.cVector5.SortEntitiesByRefPoint(RefPoint, ref refEntities, Settings, ref SortedEntities, ref Result);
    MarbleItemSettings marbleItemSettings = new MarbleItemSettings();
    F_MarbleLathe fMarbleLathe = new F_MarbleLathe();
    fMarbleLathe.varSettings = marbleItemSettings;
    fMarbleLathe.Init();
    int num1 = (int) fMarbleLathe.ShowDialog();
    int num2;
    if (fMarbleLathe.Properties.Result != DialogResult.OK)
    {
      num2 = -1;
    }
    else
    {
      MarbleItemSettings varSettings = fMarbleLathe.varSettings;
      Entity entSureface = (Entity) null;
      List<Point3D> refPoints = new List<Point3D>();
      for (int index = 0; index <= SortedEntities.Count - 1; ++index)
      {
        List<Point3D> pntDevided = new List<Point3D>();
        clsInit.cVector5.EntityDevideByCamDir(SortedEntities[index], 1.0, ref pntDevided);
        refPoints.AddRange((IEnumerable<Point3D>) pntDevided);
      }
      clsInit.cVector5.SurfaceExturudeByPoints(refPoints, Vector3D.AxisY, 2.0, ref entSureface);
      Cam = new camTp();
      MWCalcoptions = new MWCalculationOptions();
      MWCalcoptions.NumberofAxis = 3;
      MWCalcoptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
      MWCalcoptions.Mode = CamMode.TriangularMesh;
      MWCalcoptions.isRough = true;
      MWCalcoptions.DontApplyReset = true;
      MWCalcoptions.AddToCamListInLocalCalculation = false;
      MWCalcoptions.AddToCamListInMWCalculation = false;
      MWCalcoptions.DontShowbuDialogBox = true;
      ToolBase5 Tool1 = new ToolBase5();
      Tool1.Geometry.Diameter = ccVars.toolActive.Geometry.Thickness;
      Tool1.Geometry.Length = 500.0;
      Tool1.Geometry.GeometryType = ToolType.Flat;
      buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.ParallelMachAngleInYX = 90.0;
      buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = 0.0;
      buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.FeedPlaneIncremental = 0.0;
      buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.RetractPlaneIncremental = 0.0;
      buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.ClearancePlaneHeight = 100.0;
      buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;
      clsMW.CamEntities.Add(entSureface);
      entSureface.Regen(0.01);
      entSureface.Translate(0.0, 0.0, -entSureface.BoxMax.Z);
      camTpPoint camTpPoint = new camTpPoint();
      List<Point3D> points = new List<Point3D>();
      MWCalcoptions.DontShowDialogBox = true;
      Cam = new camTp();
      this.doTriangleMesh(MWCalcoptions, Tool1, actionTypeBU.camJewel3AXTriMeshParalelCut, ref Cam);
      List<Point3D> Points = new List<Point3D>();
      if (Cam.EntitiesG1Orj.Count > 0)
      {
        for (int index1 = 0; index1 <= Cam.EntitiesG1Orj.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= Cam.EntitiesG1Orj[index1].Vertices.Length - 1; ++index2)
            Points.Add(buVector5.ToPoint3D(Cam.EntitiesG1Orj[index1].Vertices[index2]));
        }
      }
      if (Points.Count >= 2)
      {
        Points[0] = new Point3D(Points[0].X, Points[0].Y, entSureface.BoxMax.Z + varSettings.settingLatheCut.LatheSafeDistance);
        Points[Points.Count - 1] = new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, entSureface.BoxMax.Z + varSettings.settingLatheCut.LatheSafeDistance);
        if (varSettings.settingLatheCut.LatheDirection == MarbleLatheDirection.MaxToMin)
          Points.Reverse();
        clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
        if (Points.Count >= 2)
        {
          for (int index = 0; index <= Points.Count - 1; ++index)
          {
            int type = 1;
            if (index == 0)
              type = 0;
            if (index == Points.Count - 1)
              type = 0;
            TpPnt9D tpPnt9D = new TpPnt9D(new Pnt6D(Points[index].X, 0.0, Points[index].Z), varSettings.settingLatheCut.LatheCutFeed, type);
            camTpPoint.Points.Add(tpPnt9D);
          }
          points.AddRange((IEnumerable<Point3D>) Points);
        }
      }
      double z = entSureface.BoxMax.Z;
      while (z >= entSureface.BoxMin.Z)
        z -= 2.0;
      List<Entity> entityList2 = new List<Entity>();
      Cam.EntitiesG1.Clear();
      Cam.EntitiesG1.Add((Entity) new LinearPath((ICollection<Point3D>) points));
      Cam.CamPoints.Clear();
      Cam.CamPoints.Add(camTpPoint);
      Cam.SimilationPoint.SimMove.Clear();
      clsInit.cCam5.SimPointCreatForDetailedPoints(camTpPoint.Points, 0.25, 0.1, 3.0, 30.0, ref Cam.SimilationPoint);
      Cam.Mode = CamMode.WireFrame;
      Cam.CamWireframeType = CamWireFrameType.Contour;
      Cam.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
      Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
      Cam.Action = Action;
      clsInit.appCommand.CamAdd(Cam);
      int count = ccVars.Pages[ccVars.PageIndex].Cams.Count;
      clsInit.appCommand.Reset();
      clsFiles.SaveParameter();
      num2 = 1;
    }
    return num2;
  }
}
