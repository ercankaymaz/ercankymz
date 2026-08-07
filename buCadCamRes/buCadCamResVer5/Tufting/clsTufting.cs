// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Tufting.clsTufting
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buClass.Apps;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Tufting;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Tufting;

public class clsTufting
{
  public static TuftingSettings varTuftingSettings = new TuftingSettings();
  public static TuftingRuntimeSettings varTuftingRunSettings = new TuftingRuntimeSettings();
  public static TuftingTempVars varTufting = new TuftingTempVars();
  public List<TuftingYarn> Yarns = new List<TuftingYarn>();
  public int TuftCounter = 1;
  public SortResult tuftingSortResult = new SortResult();
  public List<List<Entity>> refSortEntitiesLL = new List<List<Entity>>();
  public List<Entity> refSortEntities = new List<Entity>();
  public SortSettings tuftingSortSettings = new SortSettings();
  public List<string> cmdExceptionID = new List<string>();

  public void Init()
  {
    buMWTuftingVars.Init();
    buTuftingCalc.Sorted = new List<TuftingSequenceItem>();
    this.cmdExceptionID.Add("clsTufting - ID = 101-00100");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00101");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00102");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00103");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00104");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00105");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00106");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00107");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00108");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00109");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00110");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00111");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00112");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00113");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00114");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00115");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00116");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00117");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00118");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00119");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00120");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00121");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00122");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00123");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00124");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00125");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00126");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00127");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00128");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00129");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00130");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00131");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00132");
    this.cmdExceptionID.Add("clsTufting - ID = 101-00133");
  }

  public void cmdShowGCode()
  {
    if (clsVar.appModes_0.DemoMode)
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[94]);
    else if (buTuftingCalc.Sorted.Count == 0)
    {
      buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
    }
    else
    {
      string name = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
      for (int index = 0; index <= buTuftingCalc.Sorted.Count - 1; ++index)
      {
        if (clsInit.cTuft.isSameLayerTuftOrOutline(buTuftingCalc.Sorted[index].LayerName, name))
        {
          List<string> GCodes = new List<string>();
          this.CreateCodeFromSorted(buTuftingCalc.Sorted[index], ref GCodes);
          string text = buString5.StringListToString(GCodes, true);
          F_Notepad fNotepad = new F_Notepad();
          fNotepad.Init(text);
          fNotepad.Show();
        }
      }
    }
  }

  public void cmdCreateGCode()
  {
    if (clsVar.appModes_0.DemoMode)
    {
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[94]);
    }
    else
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsTufting.varTuftingRunSettings.pathGCode;
      saveFileDialog.Filter = "Tuftinf CNC File (*.inf)|*.inf";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsTufting.varTuftingRunSettings.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
      string withoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
      string path = $"{clsTufting.varTuftingRunSettings.pathGCode}\\{buFile5.getFileNameWithoutExtension(saveFileDialog.FileName)}";
      DirectoryInfo directoryInfo = new DirectoryInfo(path);
      if (directoryInfo.Exists)
      {
        buString5.MessageBoxWarning(buTufting.LangTuftingMessage[5]);
      }
      else
      {
        directoryInfo.Create();
        buFile5.SaveToFile(" ", $"{path}\\{withoutExtension}.inf");
        for (int index = 0; index <= buTuftingCalc.Sorted.Count - 1; ++index)
        {
          LayerBase5 Layer = new LayerBase5();
          clsInit.cVector5.GetLayerFromName(ccVars.Pages[ccVars.PageIndex].Layers, buTuftingCalc.Sorted[index].LayerName, ref Layer);
          string str = $"{(index + 1).ToString("D2")}_{Layer.Name}";
          if (Layer.Defination.Length > 0)
            str = $"{str}_{Layer.Defination}";
          List<string> GCodes = new List<string>();
          this.CreateCodeFromSorted(buTuftingCalc.Sorted[index], ref GCodes);
          buFile5.SaveToFile(buString5.StringListToString(GCodes, true), $"{path}\\{str}.hit");
        }
      }
    }
  }

  public void cmdYarnSettings()
  {
    try
    {
      F_YarnSettings fYarnSettings = new F_YarnSettings();
      TuftingYarn.Copy(this.Yarns, ref fYarnSettings.Yarns);
      fYarnSettings.Init();
      fYarnSettings.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fYarnSettings.ShowDialog();
      if (fYarnSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      TuftingYarn.Copy(fYarnSettings.Yarns, ref this.Yarns);
      this.SaveTuftingFile();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[0];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSimStart()
  {
    try
    {
      if (buTuftingCalc.Sorted.Count == 0)
      {
        buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Cams.Clear();
        camTp camTp = new camTp() { Tool = new ToolBase5() };
        camTp.Tool.Geometry.GeometryType = buClass.ToolType.Flat;
        camTp.Tool.Geometry.Diameter = 2.0;
        for (int index1 = 0; index1 <= buTuftingCalc.Sorted.Count - 1; ++index1)
        {
          List<Point3D> Points = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(buTuftingCalc.Sorted[index1].SortedEntities, buSystem.RegenDeviation, ref Points);
          List<Pnt6DSimMove> pnt6DsimMoveList = new List<Pnt6DSimMove>();
          for (int index2 = 0; index2 <= Points.Count - 1; ++index2)
          {
            Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(Points[index2].X, Points[index2].Y, Points[index2].Z);
            camTp.SimilationPoint.SimMove.Add(pnt6DsimMove);
          }
        }
        ccVars.Pages[ccVars.PageIndex].Cams.Add(camTp);
        clsItem.timSim.Interval = clsVar.varSimulation.SimulationInterval;
        clsInit.appCommand.simStart();
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[0];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSimStop()
  {
    try
    {
      clsInit.appCommand.simStop();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[0];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdFill()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        ccVars.Action = actionTypeBU.tuftingFill;
        dynamicInfo.Command = buTufting.LangTuftingCommands[0];
        clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[0]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doFill();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdRandomPattern()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        ccVars.Action = actionTypeBU.tuftingRandomPatternDraw;
        dynamicInfo.Command = buTufting.LangTuftingCommands[0];
        clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[0]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doRandomPattern();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdGetClosedArea()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.tuftingGetClosedPath;
      dynamicInfo.Command = AppLanguage.CadCamCommand[13];
      ccVars.selectionProcess = false;
      ccVars.stpDrawing = 1;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[2];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdChangePatternDirection()
  {
    try
    {
      if (buTuftingCalc.Sorted.Count == 0)
      {
        buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
      }
      else
      {
        clsInit.appCommand.Reset(false);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
        ccVars.Action = actionTypeBU.tuftingChangeSelectedDirection;
        dynamicInfo.Command = AppLanguage.CadCamCommand[1];
        clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[1]} [ {dynamicInfo.Command} ]");
        ccVars.selectionProcess = false;
        ccVars.stpDrawing = 1;
        if (ccVars.SelectionOP.Selections.Count == 0)
          ccVars.selectionProcess = true;
        else
          this.doChangeDirection();
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[3];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSetDefinationProps()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        ccVars.Action = actionTypeBU.tuftingSetProperties;
        dynamicInfo.Command = buTufting.LangTuftingCommands[0];
        clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[0]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doSetProps();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSpeciftDefinationArea()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.selectAndBreakByFreeSelection;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = false;
      dynamicInfo.Command = AppLanguage.CadCamCommand[9] + " ";
      clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
      clsInit.appCommand.SpinPropsSet(1, ContentAlignment.MiddleCenter, false, true, true, "Len");
      ccVars.enableViewportCross = true;
      ccVars.enableViewPortCurrentLineArrow = true;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[15];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDefinationFromSelection()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        ccVars.Action = actionTypeBU.tuftingDefinationFromSelection;
        dynamicInfo.Command = buTufting.LangTuftingCommands[0];
        clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[0]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doSelectAndBrakeBySelection();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDefinationAllReset()
  {
    try
    {
      if (buString5.MessageBoxQuestion(buTufting.LangTuftingMessage[2]) != DialogResult.Yes)
        return;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        CustomData customData = (CustomData) null;
        if (entity.EntityData != null && entity.EntityData is CustomData)
          customData = new CustomData((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData);
        if (customData != null)
        {
          customData.tuftingMode = tuftingStitchModeType.None;
          customData.tuftingPileHeight = 0.0;
          customData.tuftingStitchLength = 0.0;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData = (object) customData;
        }
        Color black = Color.Black;
        double LayerThickness = 1.0;
        clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref black, ref LayerThickness);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].ColorMethod = colorMethodType.byLayer;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeightMethod = colorMethodType.byEntity;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Color = black;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeight = (float) LayerThickness;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDefinationLayerReset()
  {
    try
    {
      if (buString5.MessageBoxQuestion($"{buTufting.LangTuftingMessage[3]} - [ {ccVars.Pages[ccVars.PageIndex].LayerName} ]") != DialogResult.Yes)
        return;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if (entity.LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
        {
          CustomData customData = (CustomData) null;
          if (entity.EntityData != null && entity.EntityData is CustomData)
            customData = new CustomData((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData);
          if (customData != null)
          {
            customData.tuftingMode = tuftingStitchModeType.None;
            customData.tuftingPileHeight = 0.0;
            customData.tuftingStitchLength = 0.0;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData = (object) customData;
          }
          Color black = Color.Black;
          double LayerThickness = 1.0;
          clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref black, ref LayerThickness);
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].ColorMethod = colorMethodType.byLayer;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeightMethod = colorMethodType.byEntity;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Color = black;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeight = (float) LayerThickness;
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdExchangePattern()
  {
    try
    {
      if (buTuftingCalc.Sorted.Count == 0)
        buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
      else if (buTuftingCalc.Sorted.Count > 0)
      {
        int index1 = -1;
        F_TuftingExchange fTuftingExchange = new F_TuftingExchange();
        for (int index2 = 0; index2 <= buTuftingCalc.Sorted.Count - 1; ++index2)
        {
          if (buTuftingCalc.Sorted[index2].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
          {
            fTuftingExchange.TuftSequence = new TuftingSequenceItem(buTuftingCalc.Sorted[index2]);
            index1 = index2;
            index2 = buTuftingCalc.Sorted.Count;
          }
        }
        if (index1 >= 0)
        {
          fTuftingExchange.layerSelected = new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex]);
          fTuftingExchange.AllEntities = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities);
          fTuftingExchange.Init();
          int num = (int) fTuftingExchange.ShowDialog();
          if (fTuftingExchange.PropertiesForm.Result != DialogResult.OK)
            return;
          buTuftingCalc.Sorted[index1] = new TuftingSequenceItem(fTuftingExchange.TuftSequence);
        }
        else
          buString5.MessageBoxWarning(buTufting.LangTuftingMessage[4]);
      }
      else
        buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[4];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDeletePattern()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count <= 0)
        return;
      this.doDeletePattern();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[5];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDeleteAllPattern()
  {
    try
    {
      this.doDeleteAllPattern();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[6];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDeleteSorted()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count <= 0)
        return;
      this.doDeleteSorted();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[7];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDeleteAllSorted()
  {
    try
    {
      this.doDeleteAllSorted();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[8];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdLockTuftEntities()
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if (entity.GetType() == typeof (LinearPath) && ((CustomData) entity.EntityData).ActionName.ToLower().IndexOf("tuft") >= 0)
          entity.Selectable = false;
      }
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name.ToLower().IndexOf("t_") >= 0 | ccVars.Pages[ccVars.PageIndex].Layers[index].Name.ToLower().IndexOf("o_") >= 0)
          ccVars.Pages[ccVars.PageIndex].Layers[index].Lock = true;
      }
      clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, false, -1);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[9];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdUnLockTuftEntities()
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if (entity.GetType() == typeof (LinearPath) && ((CustomData) entity.EntityData).ActionName.ToLower().IndexOf("tuft") >= 0)
          entity.Selectable = true;
      }
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name.ToLower().IndexOf("t_") >= 0 | ccVars.Pages[ccVars.PageIndex].Layers[index].Name.ToLower().IndexOf("o_") >= 0)
          ccVars.Pages[ccVars.PageIndex].Layers[index].Lock = false;
      }
      clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, false, -1);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[10];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdAddPoint()
  {
    try
    {
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = false;
      ccVars.Action = actionTypeBU.tuftingAddPoint;
      dynamicInfo.Command = buTufting.LangTuftingCommands[0];
      clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[0]} [ {dynamicInfo.Command} ]");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdRemovePoint()
  {
    try
    {
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = false;
      ccVars.Action = actionTypeBU.tuftingRemovePoint;
      dynamicInfo.Command = buTufting.LangTuftingCommands[0];
      clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[0]} [ {dynamicInfo.Command} ]");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdBreakAllIntersect()
  {
    try
    {
      clsTufting.varTuftingRunSettings.ThisIsTuftingOperation = true;
      this.doBreakAllIntersection();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[11];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdBreak()
  {
    try
    {
      clsTufting.varTuftingRunSettings.ThisIsTuftingOperation = true;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if (entity.GetType() == typeof (LinearPath) && ((CustomData) entity.EntityData).EntityName.ToLower().IndexOf("tuft") >= 0)
          entity.Selectable = true;
      }
      clsTufting.varTuftingRunSettings.BreakTuftCurve = true;
      clsInit.appCommand.cmdEventBreak();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[11];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdJoin()
  {
    try
    {
      clsTufting.varTuftingRunSettings.ThisIsTuftingOperation = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        ccVars.Action = actionTypeBU.tuftingJoin;
        dynamicInfo.Command = buTufting.LangTuftingCommands[0];
        clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[0]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doJoin();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[11];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDrawManuel()
  {
    try
    {
      clsTufting.varTuftingRunSettings.ThisIsTuftingOperation = true;
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.drawPolyline;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = false;
      dynamicInfo.Command = AppLanguage.CadCamCommand[9] + " ";
      clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
      clsInit.appCommand.SpinPropsSet(1, ContentAlignment.MiddleCenter, false, true, true, "Len");
      ccVars.enableViewportCross = true;
      ccVars.enableViewPortCurrentLineArrow = true;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[15];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDrawText()
  {
    try
    {
      clsTufting.varTuftingRunSettings.ThisIsTuftingOperation = true;
      clsInit.appCommand.cmdDrawVectorText();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[33];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdPartOffset()
  {
    try
    {
      clsTufting.varTuftingRunSettings.ThisIsTuftingOperation = true;
      clsInit.appCommand.cmdEventOffset();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[33];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdBorderLine()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      clsTufting.varTuftingRunSettings.LineAsBorderLine = true;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.drawLine;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = false;
      dynamicInfo.Command = AppLanguage.CadCamCommand[9] + " ";
      clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
      clsInit.appCommand.SpinPropsSet(1, ContentAlignment.MiddleCenter, false, true, true, "Len");
      ccVars.enableViewportCross = true;
      ccVars.enableViewPortCurrentLineArrow = true;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[15];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdAddImage() => clsInit.appCommand.cmdDrawImage();

  public void cmdImageList()
  {
    F_TuftingImageList tuftingImageList = new F_TuftingImageList();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Picture)
      {
        Entity entity = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]);
        tuftingImageList.Images.Add((Picture) entity);
        tuftingImageList.ImageIndex.Add(index);
      }
    }
    if (tuftingImageList.Images.Count <= 0)
      return;
    tuftingImageList.Init();
    tuftingImageList.StartPosition = FormStartPosition.CenterParent;
    int num = (int) tuftingImageList.ShowDialog();
    if (tuftingImageList.PropertiesForm.Result != DialogResult.OK)
      return;
    for (int index1 = 0; index1 <= tuftingImageList.ImageIndex.Count - 1; ++index1)
    {
      Entity entity = buVector5.CopyEntities((Entity) tuftingImageList.Images[index1]);
      int index2 = tuftingImageList.ImageIndex[index1];
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] = entity;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdImageHideAll()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Picture)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Visible = false;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdImageShowAll()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Picture)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Visible = true;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdSortSequence()
  {
    try
    {
      F_TuftingSort fTuftingSort = new F_TuftingSort();
      fTuftingSort.Settings = new TuftingSettings(clsTufting.varTuftingSettings);
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name.ToUpper().IndexOf("T_") >= 0)
          fTuftingSort.Layers.Add(new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[index]));
      }
      fTuftingSort.SelectedLayerIndex = clsTufting.varTuftingRunSettings.SelectedLayerIndex;
      fTuftingSort.SelectedLayerName = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      fTuftingSort.Init();
      int num = (int) fTuftingSort.ShowDialog();
      if (fTuftingSort.PropertiesForm.Result != DialogResult.OK)
        return;
      clsTufting.varTuftingSettings = new TuftingSettings(fTuftingSort.Settings);
      if (clsTufting.varTuftingSettings.SortType == tuftingSelectionModeType.Manuel)
      {
        this.SaveTuftingFile();
        this.refSortEntitiesLL.Clear();
        ccVars.SortedEntities.Clear();
        ccVars.SortedEntities = new List<Entity>();
        this.refSortEntitiesLL = new List<List<Entity>>();
        this.refSortEntities = new List<Entity>();
        ccVars.pntMark.Clear();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve && ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name == entity.LayerName)
          {
            CustomData entityCustomData = clsInit.cVector5.GetEntityCustomData(entity);
            if (entityCustomData.ActionName == "TuftFill" & !entityCustomData.CamSelected)
            {
              this.refSortEntities.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]));
              List<PointRGB> pntMark1 = ccVars.pntMark;
              double x1 = ((ICurve) entity).StartPoint.X;
              double y1 = ((ICurve) entity).StartPoint.Y;
              double z1 = ((ICurve) entity).StartPoint.Z;
              Color color = Color.Lime;
              int r1 = (int) color.R;
              color = Color.Lime;
              int g1 = (int) color.G;
              color = Color.Lime;
              int b1 = (int) color.B;
              PointRGB pointRgb1 = new PointRGB(x1, y1, z1, (byte) r1, (byte) g1, (byte) b1);
              pntMark1.Add(pointRgb1);
              List<PointRGB> pntMark2 = ccVars.pntMark;
              double x2 = ((ICurve) entity).EndPoint.X;
              double y2 = ((ICurve) entity).EndPoint.Y;
              double z2 = ((ICurve) entity).EndPoint.Z;
              color = Color.Red;
              int r2 = (int) color.R;
              color = Color.Red;
              int g2 = (int) color.G;
              color = Color.Red;
              int b2 = (int) color.B;
              PointRGB pointRgb2 = new PointRGB(x2, y2, z2, (byte) r2, (byte) g2, (byte) b2);
              pntMark2.Add(pointRgb2);
            }
          }
        }
        if (this.refSortEntities.Count > 0)
        {
          clsInit.appCommand.ShowViewportButtons(true, true, false);
          this.tuftingSortSettings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
          this.tuftingSortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.AskMe;
          ccVars.stpDrawing = 1;
          ccVars.selectionProcess = false;
          ccVars.Action = actionTypeBU.tuftingSelectPatternManuel;
          dynamicInfo.Command = buTufting.LangTuftingCommands[2];
          clsInit.appCommand.cmdMainFormStatusUpdate($"{buTufting.LangTuftingStatus[2]} [ {dynamicInfo.Command} ]");
        }
        else
          buString5.MessageBoxWarning(buTufting.LangTuftingMessage[4]);
      }
      else
      {
        clsTufting.varTuftingRunSettings.SelectedLayerIndex = fTuftingSort.SelectedLayerIndex;
        clsTufting.varTuftingRunSettings.SelectedLayerName = fTuftingSort.SelectedLayerName;
        this.SaveTuftingFile();
        this.doSortPattern();
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[12];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSortAll()
  {
    try
    {
      this.doSortAll();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[12];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdRealViewMode()
  {
    try
    {
      for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index1)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1];
        if (entity.LayerName.ToLower().IndexOf("t_") >= 0)
        {
          for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index2)
          {
            if (ccVars.Pages[ccVars.PageIndex].Layers[index2].Name == entity.LayerName && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1].GetType() == typeof (LinearPath))
              ((LinearPath) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1]).GlobalWidth = ccVars.Pages[ccVars.PageIndex].Layers[index2].Tufting.TuftingThickness;
          }
        }
      }
      clsInit.appCommand.eventGeneralCommand(new GeneralCommandEventArg("tuftingRealView"));
      ccVars.RealDrawMode = true;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.DrawingPropertiesUpdate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[13];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdDrawViewMode()
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (LinearPath))
          ((LinearPath) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]).GlobalWidth = 0.0;
      }
      clsInit.appCommand.eventGeneralCommand(new GeneralCommandEventArg("tuftingDrawView"));
      ccVars.RealDrawMode = false;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.DrawingPropertiesUpdate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[14];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void ShowSortedAllLayers(bool Show)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        CustomData entityData = entity.EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Tufting & entityData.CamSelected)
        {
          if (Show)
          {
            entity.ColorMethod = colorMethodType.byEntity;
            entity.LineWeightMethod = colorMethodType.byEntity;
            entity.Color = clsTufting.varTuftingSettings.ShowSortedEntitiesColor;
            entity.LineWeight = (float) clsTufting.varTuftingSettings.ShowSortedEntitiesThickness;
          }
          else
          {
            Color color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].Color;
            float lineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].LineWeight;
            entity.Color = color;
            entity.LineWeight = lineWeight + 1f;
          }
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[33];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void ShowSortedSelectedLayers(bool Show)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        CustomData entityData = entity.EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Tufting & entityData.CamSelected & ccVars.Pages[ccVars.PageIndex].LayerName == entity.LayerName)
        {
          if (Show)
          {
            entity.ColorMethod = colorMethodType.byEntity;
            entity.LineWeightMethod = colorMethodType.byEntity;
            entity.Color = clsTufting.varTuftingSettings.ShowSortedEntitiesColor;
            entity.LineWeight = (float) clsTufting.varTuftingSettings.ShowSortedEntitiesThickness;
          }
          else
          {
            Color color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].Color;
            float lineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].LineWeight;
            entity.Color = color;
            entity.LineWeight = lineWeight + 1f;
          }
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[33];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void ShowSortedReset()
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        CustomData entityData = entity.EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Tufting & entityData.CamSelected)
        {
          Color color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].Color;
          float lineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].LineWeight;
          entity.Color = color;
          entity.LineWeight = lineWeight + 1f;
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[33];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void ShowDirectionArrowSelectedLayers(bool Show)
  {
    try
    {
      if (ccVars.Pages[ccVars.PageIndex].LayerIndex >= 0)
      {
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
          if (ccVars.Pages[ccVars.PageIndex].LayerName == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName && entityData.typeDefination == entityTypeDefination.DirectionArrow)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Visible = Show;
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[33];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void ShowDirectionArrowAllLayers(bool Show)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        if ((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData).typeDefination == entityTypeDefination.DirectionArrow)
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Visible = Show;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[33];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void NewPageTuftingExtension() => buTuftingCalc.Sorted.Clear();

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buTufting.lng") : new FileInfo(AppPath.Language + "\\buTufting.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingCommands);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Tufting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Tufting Language File Missing");
      }
      if (stringList.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[16 /*0x10*/];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void SaveTuftingFile()
  {
    try
    {
      string FileName1 = AppPath.Settings + "\\Tufting\\Tufting.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "<TuftYarns>");
      for (int index = 0; index <= this.Yarns.Count - 1; ++index)
        StringList1.AddRange((ICollection) this.Yarns[index].ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "</TuftYarns>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Tufting Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "<TuftingSettings>");
      StringList1.AddRange((ICollection) clsTufting.varTuftingSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "</TuftingSettings>");
      StringList1.Add((object) "<TuftingRuntimeSettings>");
      StringList1.AddRange((ICollection) clsTufting.varTuftingRunSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "</TuftingRuntimeSettings>");
      buFile.SaveToFile(StringList1, FileName1);
      buLog.addLog("Tufting Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      buMWTuftingVars.varCamContour.mwPar.Serialize(AppPath.Settings + "\\Tufting\\mwTuftingContour.bin");
      buMWTuftingVars.varCamRough.mwPar.Serialize(AppPath.Settings + "\\Tufting\\mwTuftingRough.bin");
      string FileName2 = AppPath.Settings + "\\Tufting\\TuftingCam.bucamset";
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "   MW Cam Settings");
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "<MwCamSettings>");
      StringList2.AddRange((ICollection) buMWTuftingVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
      StringList2.AddRange((ICollection) buMWTuftingVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
      StringList2.Add((object) "</MwCamSettings>");
      buFile.SaveToFile(StringList2, FileName2);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[17];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenTuftingFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Tufting\\Tufting.prm");
      this.Yarns = new List<TuftingYarn>();
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList1 = new ArrayList();
          buString.ListToSpecificList("<TuftingSettings>", "</TuftingSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsTufting.varTuftingSettings);
            buLog.addLog("Tufting Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList1 = new ArrayList();
          buString.ListToSpecificList("<TuftingRuntimeSettings>", "</TuftingRuntimeSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsTufting.varTuftingRunSettings);
            buLog.addLog("TuftingRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          List<List<string>> stringListList = new List<List<string>>();
          ArrayList CalcList2 = new ArrayList();
          List<List<string>> CalcList3 = new List<List<string>>();
          this.Yarns = new List<TuftingYarn>();
          buString.ListToSpecificList("<TuftYarns>", "</TuftYarns>", true, StringList, ref CalcList2);
          buString.ListToSpecificList("<TuftingYarn>", "</TuftingYarn>", true, CalcList2, ref CalcList3);
          if (CalcList3.Count > 0)
          {
            for (int index = 0; index <= CalcList3.Count - 1; ++index)
            {
              TuftingYarn tuftingYarn = new TuftingYarn();
              buSerilization.Decode(CalcList3[index], "", SerilizationMode.MultiLine, (object) tuftingYarn);
              this.Yarns.Add(tuftingYarn);
            }
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Tufting Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Tufting Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Tufting Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Tufting Settings File Missing");
      }
      buLog.addLog("Tufting Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Tufting\\mwTuftingContour.bin");
      if (fileInfo2.Exists)
        buMWTuftingVars.varCamContour.mwPar.Deserialize(fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Tufting\\mwTuftingRough.bin");
      if (fileInfo3.Exists)
        buMWTuftingVars.varCamRough.mwPar.Deserialize(fileInfo3.FullName);
      string str = AppPath.Settings + "\\Tufting\\TuftingCam.bucamset";
      if (new FileInfo(str).Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(str, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", true, StringList, ref CalcList);
          if (CalcList.Count <= 0)
            return;
          buSerilization.Decode(StringList, "_varCamContour", SerilizationMode.MultiLine, (object) buMWTuftingVars.varCamContour);
          buSerilization.Decode(StringList, "_varCamRough", SerilizationMode.MultiLine, (object) buMWTuftingVars.varCamRough);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Tufting Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Tufting Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Tufting Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Tufting Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void CreateTuftEntityOutline(Entity refEntity, string LayerName)
  {
    try
    {
      string EntityName = "Tufting" + this.TuftCounter.ToString();
      this.CreateTuftEntity(refEntity, LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftOutline", -1, -1);
      ++this.TuftCounter;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[19];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void CreateTuftEntity(Entity refEntity, string LayerName)
  {
    try
    {
      string EntityName = "Tufting" + this.TuftCounter.ToString();
      this.CreateTuftEntity(refEntity, LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftFill", -1, -1);
      ++this.TuftCounter;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[19];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void CreateTuftEntity(
    Entity refEntity,
    string LayerName,
    string SceneName,
    string EntityName,
    string ActionName,
    int SeqID,
    int GroupID)
  {
    try
    {
      ((CustomData) refEntity.EntityData).GroupIdIndex = GroupID;
      ((CustomData) refEntity.EntityData).EntityName = EntityName;
      ((CustomData) refEntity.EntityData).SceneName = SceneName;
      ((CustomData) refEntity.EntityData).ActionName = ActionName;
      ((CustomData) refEntity.EntityData).Sequence = SeqID;
      ((CustomData) refEntity.EntityData).typeDefination = entityTypeDefination.Tufting;
      refEntity.Selectable = clsTufting.varTuftingSettings.LockTuftEntitiesWhenCreated;
      refEntity.LayerName = LayerName;
      if (ccVars.RealDrawMode && refEntity is LinearPath)
        ((LinearPath) refEntity).GlobalWidth = clsVar.varInterface.FatWireframeDistance;
      clsInit.appCommand.AddEntity(refEntity);
      ++this.TuftCounter;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[19];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteArrowByEntityIndex(int Index)
  {
    try
    {
      if (!(Index >= 0 & Index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
        return;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (buLinearPathArrow) && (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] as buLinearPathArrow).RefEntity == Index)
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[20];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteArrowByReleatedEntityName(string Name)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (buLinearPathArrow) && (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData).EntityName == Name)
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[20];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteArrowAndMarkerByReleatedEntityName(string Name)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
        CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
        if (entityData.EntityName == Name & (entityData.typeDefination == entityTypeDefination.DirectionArrow | entityData.typeDefination == entityTypeDefination.EndMarker | entityData.typeDefination == entityTypeDefination.StartMarker))
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[20];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteArrowByReleatedEntityName(List<string> Names)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
      for (int index1 = 0; index1 <= Names.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].GetType() == typeof (buLinearPathArrow) && (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData as CustomData).EntityName == Names[index1])
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[20];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteArrowAndMarkerByReleatedEntityName(List<string> Names)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
      for (int index1 = 0; index1 <= Names.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
        {
          CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData as CustomData;
          if (entityData.EntityName == Names[index1] & (entityData.typeDefination == entityTypeDefination.DirectionArrow | entityData.typeDefination == entityTypeDefination.EndMarker | entityData.typeDefination == entityTypeDefination.StartMarker))
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[20];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void GetTuftingPropertiesFromLayer(
    string LayerName,
    ref double PileHeight,
    ref double StitchLen,
    ref tuftingStitchModeType Type)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (LayerName == ccVars.Pages[ccVars.PageIndex].Layers[index].Name)
      {
        PileHeight = ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.PileHeight;
        StitchLen = ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.StitchLength;
        Type = ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.StitchMode;
      }
    }
  }

  public void AddArrowByEntity(Entity refEntity, int RefIndex, string ArrowLayerName)
  {
    try
    {
      if (!clsVar.varInterface5.DirectionArrowSettings.Enable)
        return;
      List<buLinearPathArrow> DirArrows = new List<buLinearPathArrow>();
      clsInit.cVector5.DirectionArrowFromEntities(refEntity, clsVar.varInterface5.DirectionArrowSettings, ref DirArrows);
      if (DirArrows.Count <= 0)
        return;
      ccVars.OsnapDont = true;
      for (int index = 0; index <= DirArrows.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        DirArrows[index].EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.DirectionArrow,
          EntityName = ((CustomData) refEntity.EntityData).EntityName,
          ActionName = "directionarrow",
          RefIndex = RefIndex
        };
        DirArrows[index].LayerName = ArrowLayerName;
        DirArrows[index].Selectable = false;
        DirArrows[index].RefEntity = RefIndex;
        clsInit.appCommand.AddEntity((Entity) DirArrows[index]);
      }
      ccVars.OsnapDont = false;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[21];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void AddAllMarkers()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
      if (entityData.typeDefination == entityTypeDefination.Tufting)
      {
        ICurve entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] as ICurve;
        int RefIndex = index;
        if (!entity.IsClosed)
        {
          this.AddStartMarkerPoint(entity.StartPoint, entityData.EntityName, RefIndex, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName);
          this.AddEndMarkerPoint(entity.EndPoint, entityData.EntityName, RefIndex, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName);
        }
        else
          this.AddStartMarkerPoint(entity.StartPoint, entityData.EntityName, RefIndex, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName);
      }
    }
  }

  public void AddStartMarkerPoint(
    Point3D pntStart,
    string EntName,
    int RefIndex,
    string LayerName)
  {
    try
    {
      ccVars.OsnapDont = true;
      Circle Ent = new Circle(pntStart, clsTufting.varTuftingSettings.StartMarkerCircleDiameter / 2.0);
      Ent.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.StartMarker,
        EntityName = EntName,
        ActionName = "startmarker",
        RefIndex = RefIndex
      };
      Ent.LayerName = LayerName;
      Ent.Selectable = false;
      clsInit.appCommand.AddEntity((Entity) Ent);
      ccVars.OsnapDont = false;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[21];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void AddEndMarkerPoint(Point3D pntEnd, string EntName, int RefIndex, string LayerName)
  {
    try
    {
      ccVars.OsnapDont = true;
      CompositeCurve rectangle = CompositeCurve.CreateRectangle(clsTufting.varTuftingSettings.EndMarkerSquareWidth, clsTufting.varTuftingSettings.EndMarkerSquareWidth, true);
      rectangle.Translate(pntEnd.X, pntEnd.Y);
      rectangle.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.EndMarker,
        EntityName = EntName,
        ActionName = "endmarker",
        RefIndex = RefIndex
      };
      rectangle.LayerName = LayerName;
      rectangle.Selectable = false;
      clsInit.appCommand.AddEntity((Entity) rectangle);
      ccVars.OsnapDont = false;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[21];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void AddStartEndMarkerPoint(
    Point3D pntStart,
    Point3D pntEnd,
    string EntName,
    int RefIndex,
    string LayerName)
  {
    try
    {
      ccVars.OsnapDont = true;
      Circle Ent = new Circle(pntStart, clsTufting.varTuftingSettings.StartMarkerCircleDiameter / 2.0);
      Ent.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.StartMarker,
        EntityName = EntName,
        ActionName = "startmarker",
        RefIndex = RefIndex
      };
      Ent.LayerName = LayerName;
      Ent.Selectable = false;
      clsInit.appCommand.AddEntity((Entity) Ent);
      CompositeCurve rectangle = CompositeCurve.CreateRectangle(clsTufting.varTuftingSettings.EndMarkerSquareWidth, clsTufting.varTuftingSettings.EndMarkerSquareWidth, true);
      rectangle.Translate(pntEnd.X, pntEnd.Y);
      rectangle.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.EndMarker,
        EntityName = EntName,
        ActionName = "endmarker",
        RefIndex = RefIndex
      };
      rectangle.LayerName = LayerName;
      rectangle.Selectable = false;
      clsInit.appCommand.AddEntity((Entity) rectangle);
      ccVars.OsnapDont = false;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[21];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteMarkerByReleatedEntityName(string Name)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
        CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
        if (entityData.EntityName == Name & (entityData.typeDefination == entityTypeDefination.EndMarker | entityData.typeDefination == entityTypeDefination.StartMarker))
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[20];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteMarkerByReleatedEntityName(List<string> Names)
  {
    try
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
      for (int index1 = 0; index1 <= Names.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
        {
          CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData as CustomData;
          if (entityData.EntityName == Names[index1] & (entityData.typeDefination == entityTypeDefination.EndMarker | entityData.typeDefination == entityTypeDefination.StartMarker))
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[20];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DeleteMarkerPoint(int RefIndex)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
      if (entityData.RefIndex == RefIndex & (entityData.typeDefination == entityTypeDefination.EndMarker | entityData.typeDefination == entityTypeDefination.StartMarker))
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
  }

  public void DeleteAllMarkerPoint()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData is CustomData entityData && entityData.typeDefination == entityTypeDefination.EndMarker | entityData.typeDefination == entityTypeDefination.StartMarker)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
  }

  public void AddArrowAndMarkerEntitiesFromName(bool ReverseDir, List<string> EntityNameList)
  {
    for (int index1 = 0; index1 <= EntityNameList.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
      {
        CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData as CustomData;
        if (entityData.EntityName == EntityNameList[index1] & entityData.typeDefination == entityTypeDefination.Tufting & entityData.CamSelected)
        {
          LinearPath entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] as LinearPath;
          if (ReverseDir)
            entity.Reverse();
          this.AddStartEndMarkerPoint(entity.StartPoint, entity.EndPoint, ((CustomData) entity.EntityData).EntityName, index2, entity.LayerName);
          if (clsVar.varInterface5.DirectionArrowSettings.Enable)
            this.AddArrowByEntity((Entity) entity, index2, entity.LayerName);
        }
      }
    }
  }

  public void GetLayerNameFRomActiveColor(int ActiveColor, ref string LayerName)
  {
    switch (ActiveColor)
    {
      case 1:
        LayerName = "T_A";
        break;
      case 2:
        LayerName = "T_B";
        break;
      case 3:
        LayerName = "T_C";
        break;
      case 4:
        LayerName = "T_D";
        break;
      case 5:
        LayerName = "T_E";
        break;
      case 6:
        LayerName = "T_F";
        break;
      case 7:
        LayerName = "T_G";
        break;
      case 8:
        LayerName = "T_H";
        break;
    }
  }

  public void ContourOperation(
    bool AddTuftingEntity,
    double Offset,
    int ContourCount,
    CamClosedContourType Type,
    ClockDirectionType ClockDir,
    tuftingBorderOffsetType OffsetType,
    bool BorderConnect,
    string LayerName,
    List<Entity> contourEntities,
    ref List<Entity> LastCalcEntities)
  {
    List<List<Entity>> entityListList = new List<List<Entity>>();
    for (int index = 1; index <= ContourCount; ++index)
    {
      double Offset1 = Offset * (double) index;
      if (Type == CamClosedContourType.Inner)
        Offset1 = -Offset1;
      List<Point3D> Points = new List<Point3D>();
      clsInit.cVector5.EntitiesToPointsWithCamDirection(contourEntities, buSystem.RegenDeviation, ref Points);
      List<List<Point3D>> OffsetedPoints = new List<List<Point3D>>();
      clsInit.cVector5.OffsetContour(Points, Offset1, OffsetCornerType.Line, CamOpenContourType2.Center, Plane.XY, 0.0, ref OffsetedPoints);
      if (OffsetedPoints.Count > 0)
      {
        Points.Clear();
        Points = new List<Point3D>();
        Points.AddRange((IEnumerable<Point3D>) OffsetedPoints[0]);
      }
      LinearPath linearPath1 = new LinearPath((ICollection<Point3D>) Points);
      linearPath1.EntityData = (object) new CustomData();
      if (clsInit.cVector5.GetClockDirection(Points) != ClockDir)
        Points.Reverse();
      if (clsTufting.varTuftingSettings.StraightOutBorderCount > 1)
      {
        if (OffsetType == tuftingBorderOffsetType.Contour)
        {
          LinearPath linearPath2 = new LinearPath((ICollection<Point3D>) Points);
          linearPath2.EntityData = (object) new CustomData();
          entityListList.Add(new List<Entity>()
          {
            (Entity) linearPath2
          });
        }
        if (OffsetType == tuftingBorderOffsetType.Spiral)
        {
          List<Entity> entityList = new List<Entity>();
          if (index == 1)
          {
            ICurve refCurve = (ICurve) new LinearPath((ICollection<Point3D>) Points);
            if (Type == CamClosedContourType.Inner)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, 0.0, Offset);
              entityList.Add((Entity) refCurve);
            }
            if (Type == CamClosedContourType.Outter)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, 0.0);
              entityList.Add((Entity) refCurve);
            }
          }
          else if (index > 1)
          {
            ICurve refCurve = (ICurve) new LinearPath((ICollection<Point3D>) Points);
            if (Type == CamClosedContourType.Inner)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, Offset);
              entityList.Add((Entity) refCurve);
            }
            if (Type == CamClosedContourType.Outter)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, 0.0);
              entityList.Add((Entity) refCurve);
            }
          }
          entityListList.Add(entityList);
        }
      }
      else
        entityListList.Add(buVector5.CopyEntities(new List<Entity>()
        {
          (Entity) linearPath1
        }));
      LastCalcEntities.Clear();
      LastCalcEntities = new List<Entity>();
      LastCalcEntities.Add((Entity) linearPath1);
    }
    if (!(entityListList.Count > 0 & AddTuftingEntity))
      return;
    List<Point3D> Points1 = new List<Point3D>();
    for (int index1 = 0; index1 <= entityListList.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= entityListList[index1].Count - 1; ++index2)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(entityListList[index1][index2], ref copiedEnt);
        List<Point3D> Points2 = new List<Point3D>();
        clsInit.cVector5.EntityToPointWithCamDirection(copiedEnt, buSystem.RegenDeviation, ref Points2);
        Points1.AddRange((IEnumerable<Point3D>) Points2);
      }
      if (!BorderConnect)
      {
        clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points1);
        LinearPath refEntity = new LinearPath((ICollection<Point3D>) Points1);
        refEntity.EntityData = (object) new CustomData();
        this.CreateTuftEntityOutline((Entity) refEntity, LayerName);
        Points1.Clear();
      }
    }
    if (Points1.Count <= 2)
      return;
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points1);
    LinearPath refEntity1 = new LinearPath((ICollection<Point3D>) Points1);
    refEntity1.EntityData = (object) new CustomData();
    this.CreateTuftEntityOutline((Entity) refEntity1, LayerName);
  }

  public void ContourOperation11(
    double Offset,
    CamClosedContourType Type,
    ClockDirectionType ClockDir,
    tuftingBorderOffsetType OffsetType,
    bool BorderConnect,
    MWCalculationOptions MWCalcoptions,
    string LayerName,
    List<Entity> contourEntities,
    ref List<Entity> LastCalcEntities)
  {
    buMWTuftingVars.varCamContour.buPar.Offsets.ClosedContour = Type;
    buMWTuftingVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TwoAxisPatternStartFromPosition = WireframeBasedTpCalcParamsStartFromPosition.SfpUserDefinedStartPoint;
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamContour.mwPar, buMWTuftingVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
    List<List<Entity>> entityListList = new List<List<Entity>>();
    for (int index1 = 1; index1 <= clsTufting.varTuftingSettings.StraightOutBorderCount; ++index1)
    {
      ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
      ccVars.toolActive.Geometry.Diameter = clsTufting.varTuftingSettings.StraightOutterOffset * 2.0 * (double) index1;
      List<Point3D> Points = new List<Point3D>();
      clsMW.CamEntities.Clear();
      clsInit.cVector5.EntitiesToPointsWithCamDirection(contourEntities, buSystem.RegenDeviation, ref Points);
      LinearPath linearPath1 = new LinearPath((ICollection<Point3D>) Points);
      clsMW.CamEntities.Add((Entity) linearPath1);
      camTp camTp = new camTp();
      MWCalcoptions.UseConstantStartPoint = true;
      MWCalcoptions.UseStartPoint = true;
      MWCalcoptions.StartPointX = contourEntities[0].Vertices[0].X;
      MWCalcoptions.StartPointY = contourEntities[0].Vertices[0].Y;
      List<List<Point3D>> OffsetedPoints = new List<List<Point3D>>();
      clsInit.cVector5.OffsetContour(Points, ccVars.toolActive.Geometry.Diameter / 2.0, OffsetCornerType.Line, CamOpenContourType2.Center, Plane.XY, 0.0, ref OffsetedPoints);
      if (OffsetedPoints.Count > 0)
      {
        LinearPath linearPath2 = new LinearPath((ICollection<Point3D>) OffsetedPoints[0]);
        linearPath2.EntityData = (object) new CustomData();
        camTp.EntitiesG1.Add((Entity) linearPath2);
      }
      buMWTuftingVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamContour.buPar);
      if (clsInit.cVector5.GetClockDirection(OffsetedPoints[0]) != ClockDir)
        clsInit.cVector5.ChangeEntitiesDirection(ref camTp.EntitiesG1);
      if (clsTufting.varTuftingSettings.StraightOutBorderCount > 1)
      {
        if (OffsetType == tuftingBorderOffsetType.Contour)
          entityListList.Add(buVector5.CopyEntities(camTp.EntitiesG1));
        if (OffsetType == tuftingBorderOffsetType.Spiral)
        {
          List<Entity> entityList = new List<Entity>();
          if (index1 == 1)
          {
            for (int index2 = 0; index2 <= camTp.EntitiesG1.Count - 2; ++index2)
              entityList.Add(buVector5.CopyEntities(camTp.EntitiesG1[index2]));
            ICurve refCurve = camTp.EntitiesG1[camTp.EntitiesG1.Count - 1] as ICurve;
            if (Type == CamClosedContourType.Inner)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, 0.0, Offset);
              entityList.Add((Entity) refCurve);
            }
            if (Type == CamClosedContourType.Outter)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, 0.0);
              entityList.Add((Entity) refCurve);
            }
          }
          else if (index1 > 1)
          {
            ICurve refCurve = camTp.EntitiesG1[0] as ICurve;
            if (Type == CamClosedContourType.Inner)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, Offset);
              entityList.Add((Entity) refCurve);
            }
            if (Type == CamClosedContourType.Outter)
            {
              clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, 0.0);
              entityList.Add((Entity) refCurve);
            }
            for (int index3 = 1; index3 <= camTp.EntitiesG1.Count - 2; ++index3)
              entityList.Add(buVector5.CopyEntities(camTp.EntitiesG1[index3]));
          }
          entityListList.Add(entityList);
        }
      }
      else
        entityListList.Add(buVector5.CopyEntities(camTp.EntitiesG1));
      LastCalcEntities.Clear();
      LastCalcEntities = new List<Entity>();
      buVector5.CopyEntities(camTp.EntitiesG1, ref LastCalcEntities);
    }
    if (entityListList.Count <= 0)
      return;
    List<Point3D> Points1 = new List<Point3D>();
    for (int index4 = 0; index4 <= entityListList.Count - 1; ++index4)
    {
      for (int index5 = 0; index5 <= entityListList[index4].Count - 1; ++index5)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(entityListList[index4][index5], ref copiedEnt);
        List<Point3D> Points2 = new List<Point3D>();
        clsInit.cVector5.EntityToPointWithCamDirection(copiedEnt, buSystem.RegenDeviation, ref Points2);
        Points1.AddRange((IEnumerable<Point3D>) Points2);
      }
      if (!BorderConnect)
      {
        clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points1);
        LinearPath refEntity = new LinearPath((ICollection<Point3D>) Points1);
        refEntity.EntityData = (object) new CustomData();
        this.CreateTuftEntity((Entity) refEntity, LayerName);
        Points1.Clear();
      }
    }
    if (Points1.Count <= 2)
      return;
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points1);
    LinearPath refEntity1 = new LinearPath((ICollection<Point3D>) Points1);
    refEntity1.EntityData = (object) new CustomData();
    this.CreateTuftEntity((Entity) refEntity1, LayerName);
  }

  public void ApplySetProperties(
    List<int> IndexList,
    tuftingStitchModeType TuftingMode,
    double PileHeight,
    double StitchLenght)
  {
    List<int> intList = new List<int>();
    if (IndexList.Count > 0)
    {
      intList.AddRange((IEnumerable<int>) IndexList);
    }
    else
    {
      for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
      {
        int index2 = ccVars.SelectionOP.Selections[index1].Index;
        intList.Add(index2);
      }
    }
    float level = 1f;
    if (TuftingMode != tuftingStitchModeType.None)
      level += 0.15f;
    if (PileHeight != 0.0)
      level += 0.15f;
    if (StitchLenght != 0.0)
      level += 0.15f;
    for (int index3 = 0; index3 <= intList.Count - 1; ++index3)
    {
      int index4 = intList[index3];
      Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4];
      CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].EntityData as CustomData;
      if (entityData.tuftingMode != tuftingStitchModeType.None | entityData.tuftingPileHeight > 0.0 | entityData.tuftingStitchLength > 0.0)
      {
        Color white = Color.White;
        Color black = Color.Black;
        double LayerThickness = 1.0;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].ColorMethod = colorMethodType.byEntity;
        clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref white, ref LayerThickness);
        Color color = buImage5.Darken(white, level);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].ColorMethod = colorMethodType.byEntity;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Color = color;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineWeightMethod = colorMethodType.byEntity;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineWeight = (float) clsTufting.varTuftingSettings.DefinationEntityThickness;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Regen(buSystem.RegenDeviation);
      }
      else
      {
        Color white = Color.White;
        Color black = Color.Black;
        double LayerThickness = 1.0;
        clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref white, ref LayerThickness);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].ColorMethod = colorMethodType.byLayer;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineWeightMethod = colorMethodType.byEntity;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Color = white;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineWeight = (float) LayerThickness;
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void SortEntities(
    ref List<Entity> sortingEntities,
    Color layerColor,
    double LayerThickness,
    string LayerName,
    List<Entity> AlreadySortedEntities)
  {
    SortSettings Settings = new SortSettings();
    SortResult Result = new SortResult();
    List<Entity> RefEntities = new List<Entity>();
    Point3D RefPoint = new Point3D();
    Settings.Option.NextGroupRules = clsTufting.varTuftingSettings.SortAutoNextGroupRules;
    Settings.Option.UseBoxBoundingForMinMax = clsTufting.varTuftingSettings.SortBoxBounding;
    double PileHeight = 0.0;
    double StitchLen = 0.0;
    tuftingStitchModeType Type = tuftingStitchModeType.None;
    this.GetTuftingPropertiesFromLayer(LayerName, ref PileHeight, ref StitchLen, ref Type);
    if (!(sortingEntities.Count > 0 | sortingEntities.Count == 0 & AlreadySortedEntities.Count > 0))
      return;
    for (int index = 0; index <= sortingEntities.Count - 1; ++index)
      sortingEntities[index].Selectable = true;
    if (sortingEntities.Count > 0)
      RefPoint = buVector5.ToPoint3D(sortingEntities[0].Vertices[0]);
    if (AlreadySortedEntities.Count == 0)
      clsInit.cVector5.SortEntitiesByRefPoint(RefPoint, ref sortingEntities, Settings, ref RefEntities, ref Result);
    else
      buVector5.CopyEntities(AlreadySortedEntities, ref RefEntities);
    if (RefEntities.Count > 0)
    {
      List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(RefEntities, ref SplitedEntitites);
      int count = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count;
      for (int index1 = 0; index1 <= count - 1; ++index1)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1];
        CustomData entityData1 = entity.EntityData as CustomData;
        for (int index2 = 0; index2 <= SplitedEntitites.Count - 1; ++index2)
        {
          int RefIndex = -1;
          for (int index3 = 0; index3 <= SplitedEntitites[index2].Count - 1; ++index3)
          {
            if (((CustomData) entity.EntityData).EntityName == ((CustomData) SplitedEntitites[index2][index3].EntityData).EntityName & ((CustomData) entity.EntityData).typeDefination == entityTypeDefination.Tufting)
            {
              ((CustomData) entity.EntityData).CamSelected = true;
              entity.ColorMethod = colorMethodType.byEntity;
              entity.LineWeightMethod = colorMethodType.byEntity;
              if (entityData1.tuftingMode == tuftingStitchModeType.None & entityData1.tuftingPileHeight == 0.0 & entityData1.tuftingStitchLength == 0.0)
              {
                entity.Color = layerColor;
                entity.LineWeight = (float) LayerThickness + 1f;
                entityData1.tuftingMode = Type;
                entityData1.tuftingPileHeight = PileHeight;
                entityData1.tuftingStitchLength = StitchLen;
                ((CustomData) SplitedEntitites[index2][index3].EntityData).tuftingMode = Type;
                ((CustomData) SplitedEntitites[index2][index3].EntityData).tuftingPileHeight = PileHeight;
                ((CustomData) SplitedEntitites[index2][index3].EntityData).tuftingStitchLength = StitchLen;
              }
              else
              {
                if (entityData1.tuftingMode == tuftingStitchModeType.None | entityData1.tuftingMode == tuftingStitchModeType.Auto)
                {
                  entityData1.tuftingMode = Type;
                  ((CustomData) SplitedEntitites[index2][index3].EntityData).tuftingMode = Type;
                }
                if (entityData1.tuftingPileHeight == 0.0)
                {
                  entityData1.tuftingPileHeight = PileHeight;
                  ((CustomData) SplitedEntitites[index2][index3].EntityData).tuftingPileHeight = PileHeight;
                }
                if (entityData1.tuftingStitchLength == 0.0)
                {
                  entityData1.tuftingStitchLength = StitchLen;
                  ((CustomData) SplitedEntitites[index2][index3].EntityData).tuftingStitchLength = StitchLen;
                }
                entity.LineWeight += 2f;
              }
              this.AddArrowByEntity(entity, index1, entity.LayerName);
              RefIndex = index1;
            }
          }
          if (SplitedEntitites[index2].Count > 0 & RefIndex >= 0)
          {
            ICurve curve = SplitedEntitites[index2][0] as ICurve;
            CustomData entityData2 = SplitedEntitites[index2][0].EntityData as CustomData;
            if (!curve.IsClosed)
            {
              if (entityData2.sortDirection == entitySortDirection.Normal)
              {
                this.AddStartMarkerPoint(curve.StartPoint, ((CustomData) SplitedEntitites[index2][0].EntityData).EntityName, RefIndex, SplitedEntitites[index2][0].LayerName);
                this.AddEndMarkerPoint(curve.EndPoint, ((CustomData) SplitedEntitites[index2][0].EntityData).EntityName, RefIndex, SplitedEntitites[index2][0].LayerName);
              }
              else
              {
                this.AddStartMarkerPoint(curve.EndPoint, ((CustomData) SplitedEntitites[index2][0].EntityData).EntityName, RefIndex, SplitedEntitites[index2][0].LayerName);
                this.AddEndMarkerPoint(curve.StartPoint, ((CustomData) SplitedEntitites[index2][0].EntityData).EntityName, RefIndex, SplitedEntitites[index2][0].LayerName);
              }
            }
            else
              this.AddStartMarkerPoint(curve.StartPoint, ((CustomData) SplitedEntitites[index2][0].EntityData).EntityName, RefIndex, SplitedEntitites[index2][0].LayerName);
          }
        }
      }
      if (SplitedEntitites.Count > 0)
      {
        if (buTuftingCalc.Sorted.Count == 0)
        {
          TuftingSequenceItem tuftingSequenceItem = new TuftingSequenceItem();
          tuftingSequenceItem.LayerName = LayerName;
          for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
          {
            List<Entity> copiedEnt = new List<Entity>();
            buVector5.CopyEntities(SplitedEntitites[index], ref copiedEnt);
            tuftingSequenceItem.SortedEntities.AddRange((IEnumerable<Entity>) copiedEnt);
          }
          buTuftingCalc.Sorted.Add(tuftingSequenceItem);
        }
        else
        {
          int index4 = -1;
          for (int index5 = 0; index5 <= buTuftingCalc.Sorted.Count - 1; ++index5)
          {
            if (buTuftingCalc.Sorted[index5].LayerName == LayerName)
              index4 = index5;
          }
          if (index4 >= 0)
          {
            for (int index6 = 0; index6 <= SplitedEntitites.Count - 1; ++index6)
            {
              List<Entity> copiedEnt = new List<Entity>();
              buVector5.CopyEntities(SplitedEntitites[index6], ref copiedEnt);
              buTuftingCalc.Sorted[index4].SortedEntities.AddRange((IEnumerable<Entity>) copiedEnt);
            }
          }
          else
          {
            TuftingSequenceItem tuftingSequenceItem = new TuftingSequenceItem();
            tuftingSequenceItem.LayerName = LayerName;
            for (int index7 = 0; index7 <= SplitedEntitites.Count - 1; ++index7)
            {
              List<Entity> copiedEnt = new List<Entity>();
              buVector5.CopyEntities(SplitedEntitites[index7], ref copiedEnt);
              tuftingSequenceItem.SortedEntities.AddRange((IEnumerable<Entity>) copiedEnt);
            }
            buTuftingCalc.Sorted.Add(tuftingSequenceItem);
          }
        }
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public bool isTuftingLayer(string Name) => Name.IndexOf("T_") >= 0;

  public bool GetDefinationFromEntity(
    Entity refEntity,
    ref double StitchLen,
    ref double PileHeight,
    ref tuftingStitchModeType TuftMode)
  {
    bool definationFromEntity;
    if (refEntity.EntityData != null)
    {
      if (refEntity.EntityData is CustomData)
      {
        CustomData entityData = refEntity.EntityData as CustomData;
        if (entityData.tuftingMode == tuftingStitchModeType.Cut)
          TuftMode = tuftingStitchModeType.Cut;
        else if (entityData.tuftingMode == tuftingStitchModeType.Loop)
        {
          TuftMode = tuftingStitchModeType.Loop;
        }
        else
        {
          double PileHeight1 = 0.0;
          double StitchLen1 = 0.0;
          this.GetTuftingPropertiesFromLayer(refEntity.LayerName, ref PileHeight1, ref StitchLen1, ref TuftMode);
        }
        if (entityData.tuftingPileHeight != 0.0)
        {
          PileHeight = entityData.tuftingPileHeight;
        }
        else
        {
          double StitchLen2 = 0.0;
          tuftingStitchModeType Type = tuftingStitchModeType.None;
          this.GetTuftingPropertiesFromLayer(refEntity.LayerName, ref PileHeight, ref StitchLen2, ref Type);
        }
        if (entityData.tuftingStitchLength != 0.0)
        {
          StitchLen = entityData.tuftingStitchLength;
        }
        else
        {
          double PileHeight2 = 0.0;
          tuftingStitchModeType Type = tuftingStitchModeType.None;
          this.GetTuftingPropertiesFromLayer(refEntity.LayerName, ref PileHeight2, ref StitchLen, ref Type);
        }
        definationFromEntity = true;
      }
      else
        definationFromEntity = false;
    }
    else
      definationFromEntity = false;
    return definationFromEntity;
  }

  public void doFill()
  {
    try
    {
      F_TuftingFill fTuftingFill = new F_TuftingFill();
      fTuftingFill.Settings = new TuftingSettings(clsTufting.varTuftingSettings);
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
        fTuftingFill.LayerNames.Add(ccVars.Pages[ccVars.PageIndex].Layers[index].Name);
      fTuftingFill.SelectedLayerIndex = clsTufting.varTuftingRunSettings.SelectedLayerIndex;
      fTuftingFill.Init();
      int num = (int) fTuftingFill.ShowDialog();
      if (fTuftingFill.PropertiesForm.Result != DialogResult.OK)
        return;
      clsTufting.varTuftingSettings = new TuftingSettings(fTuftingFill.Settings);
      clsTufting.varTuftingRunSettings.SelectedLayerIndex = fTuftingFill.SelectedLayerIndex;
      if (clsTufting.varTuftingSettings.FillType == tuftingFillOffsetType.Spiral)
        this.doWireframeSpiral();
      else if (clsTufting.varTuftingSettings.FillType == tuftingFillOffsetType.Straight)
        this.doWireframeStraight();
      else if (clsTufting.varTuftingSettings.FillType == tuftingFillOffsetType.Contour)
        this.doWireframeCounter();
      else if (clsTufting.varTuftingSettings.FillType == tuftingFillOffsetType.Trace)
        this.doWireframeTrace();
      this.SaveTuftingFile();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[22];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doWireframeStraight()
  {
    try
    {
      int GroupID = -1;
      int SequenceID = -1;
      clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      string name = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.isDirectionArrow)
          clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
      }
      SelectionOption Option1 = new SelectionOption(true, false, false, false, false, false, true, true, true);
      Option1.OnlyClosedShapes = clsVar.varSelection.OnlyClosedShapes;
      Option1.MinVerticeCount = clsVar.varSelection.MinVeeticeCount;
      Option1.MinSingleEntityLength = clsVar.varSelection.MinSingleEntityLength;
      List<Entity> AllEntities = new List<Entity>();
      clsInit.appCommand.SelectionToEntities(ref AllEntities, Option1);
      clsInit.cVector5.EntitiesPlaneCheck(ref AllEntities);
      if (clsVar.varEntities.MinVerticesDistance > 0.0)
        clsInit.cVector5.RemoveSmallLengthFromEntitiesPoints(ref AllEntities, clsVar.varEntities.MinVerticesDistance);
      Point3D RefPoint = new Point3D();
      if (AllEntities[0] is ICurve)
        RefPoint = buVector5.ToPoint3D(((ICurve) AllEntities[0]).StartPoint);
      List<EntitiesGroup> Groups = new List<EntitiesGroup>();
      clsInit.cVector5.FindEntitiesGroupFromEntities(RefPoint, AllEntities, Plane.XY, ref Groups);
      for (int index1 = 0; index1 <= Groups.Count - 1; ++index1)
      {
        List<Entity> copiedEnt1 = new List<Entity>();
        List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
        buVector5.CopyEntities(Groups[index1].Outside, ref copiedEnt1);
        buVector5.CopyEntities(Groups[index1].Inside, ref copiedEnt2);
        clsInit.appCommand.undoBuffer();
        if (clsTufting.varTuftingSettings.StraightOutBorderEnable)
        {
          List<Entity> LastCalcEntities = new List<Entity>();
          this.ContourOperation(true, clsTufting.varTuftingSettings.StraightOutterOffset, clsTufting.varTuftingSettings.StraightOutBorderCount, CamClosedContourType.Inner, clsTufting.varTuftingSettings.StraightOutBorderFillDirection, clsTufting.varTuftingSettings.StraightOutBorderType, clsTufting.varTuftingSettings.StraightOutBorderConnect, name, copiedEnt1, ref LastCalcEntities);
          copiedEnt1.Clear();
          buVector5.CopyEntities(LastCalcEntities, ref copiedEnt1);
          LastCalcEntities.Clear();
        }
        if (clsTufting.varTuftingSettings.StraightInBorderEnable & copiedEnt2.Count > 0)
        {
          List<List<Entity>> refEnt = new List<List<Entity>>();
          for (int index2 = 0; index2 <= copiedEnt2.Count - 1; ++index2)
          {
            List<Entity> LastCalcEntities = new List<Entity>();
            this.ContourOperation(true, clsTufting.varTuftingSettings.StraightInnerOffset, clsTufting.varTuftingSettings.StraightInBorderCount, CamClosedContourType.Outter, clsTufting.varTuftingSettings.StraightInBorderFillDirection, clsTufting.varTuftingSettings.StraightInBorderType, clsTufting.varTuftingSettings.StraightInBorderConenct, name, copiedEnt2[index2], ref LastCalcEntities);
            refEnt.Add(LastCalcEntities);
          }
          copiedEnt2.Clear();
          buVector5.CopyEntities(refEnt, ref copiedEnt2);
          refEnt.Clear();
        }
        camTp camTp = new camTp();
        MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
        ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
        ccVars.toolActive.Geometry.Diameter = clsTufting.varTuftingSettings.StraightRowSpace * 2.0;
        MWCalcOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
        MWCalcOptions.NumberofAxis = 3;
        MWCalcOptions.CamWireframeType = CamWireFrameType.Pocket;
        MWCalcOptions.Mode = CamMode.WireFrame;
        MWCalcOptions.DontApplyReset = true;
        MWCalcOptions.isBuWireframeCalculation = false;
        MWCalcOptions.AddToCamListInMWCalculation = false;
        MWCalcOptions.DontShowDialogBox = true;
        MWCalcOptions.isBuSort = false;
        MWCalcOptions.UseStartPoint = false;
        MWCalcOptions.UseConstantStartPoint = true;
        MWCalcOptions.StartPointX = 0.0;
        MWCalcOptions.StartPointY = 0.0;
        MWCalcOptions.HeightFromEntities = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
        if (!clsTufting.varTuftingSettings.StraightRowLink)
          buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeOneway;
        buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = clsTufting.varTuftingSettings.StraightRowSpace;
        buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = clsTufting.varTuftingSettings.StraightAngle;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtParallel;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = clsTufting.varTuftingSettings.CutTolerance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
        buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = true;
        buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = clsTufting.varTuftingSettings.MaxDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = true;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = clsTufting.varTuftingSettings.MinDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = clsTufting.varTuftingSettings.SharpCorner;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = new PercentOrValueParameter(Unit.Metric, true)
        {
          Percent = 50.0
        };
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        if (clsTufting.varTuftingSettings.LinkAsSpline)
        {
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
        }
        if (!clsTufting.varTuftingSettings.StraightRowLink)
        {
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        }
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
        clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
        List<Entity> refEntities = new List<Entity>();
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false, true, true, true);
        SortResult sortResult = new SortResult();
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.appCommand.SelectionToEntities(ref refEntities, Option2);
        clsInit.cVector5.EntitiesPlaneCheck(ref refEntities);
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
        ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
        ccVars.toolActive.Geometry.Diameter = clsTufting.varTuftingSettings.StraightRowSpace * 2.0;
        double num1 = MaxPoint.Y - MinPoint.Y - ccVars.toolActive.Geometry.Diameter;
        double num2 = Math.Round(num1 / clsTufting.varTuftingSettings.StraightRowSpace, 0);
        MWCalcOptions.WireframeRoughtStepOverParaelelOverride = num1 / (num2 - 1.0);
        camTp Cam = new camTp();
        camResult Result = (camResult) null;
        clsMW.CamEntities.Clear();
        clsMW.CamEntitiesGroup.Clear();
        MWCalcOptions.UseSortedAndSplitedEntities = false;
        if (copiedEnt1.Count > 0 & copiedEnt2.Count > 0)
        {
          MWCalcOptions.UseSortedAndSplitedEntities = true;
          clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt1));
          for (int index3 = 0; index3 <= copiedEnt2.Count - 1; ++index3)
            clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt2[index3]));
        }
        else
          buVector5.CopyEntities(copiedEnt1, ref clsMW.CamEntities);
        clsInit.appMW.doWireframeContour(MWCalcOptions, ccVars.toolActive, ref Cam, ref Result);
        buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
        for (int index4 = 0; index4 <= Cam.EntitiesG1.Count - 1; ++index4)
        {
          if ((Cam.EntitiesG1[index4] as ICurve).StartPoint.Z == 0.0)
          {
            clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
            ccVars.UndoDont = true;
            Entity EyeEntity = (Entity) null;
            buConversion5.EyeCamEntityToEyeEntity(Cam.EntitiesG1[index4], ref EyeEntity);
            if (EyeEntity != null)
            {
              string EntityName = "Tufting" + this.TuftCounter.ToString();
              if (clsTufting.varTuftingSettings.StraightRowLink)
                this.CreateTuftEntity(EyeEntity, name, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftFill", SequenceID, GroupID);
              else if (!((buLinearPathCam) Cam.EntitiesG1[index4]).isLink)
                this.CreateTuftEntity(EyeEntity, name, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftFill", SequenceID, GroupID);
            }
          }
        }
      }
      clsInit.appCommand.Reset();
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[23];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doWireframeSpiral()
  {
    try
    {
      int GroupIndex = -1;
      int SequenceID = -1;
      clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      string name = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.isDirectionArrow)
          clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
      }
      SelectionOption Option1 = new SelectionOption(true, false, false, false, false, false, true, true, true);
      List<Entity> AllEntities = new List<Entity>();
      clsInit.appCommand.SelectionToEntities(ref AllEntities, Option1);
      clsInit.cVector5.EntitiesPlaneCheck(ref AllEntities);
      Point3D RefPoint = new Point3D();
      if (AllEntities[0] is ICurve)
        RefPoint = buVector5.ToPoint3D(((ICurve) AllEntities[0]).StartPoint);
      List<EntitiesGroup> Groups = new List<EntitiesGroup>();
      clsInit.cVector5.FindEntitiesGroupFromEntities(RefPoint, AllEntities, Plane.XY, ref Groups);
      for (int index1 = 0; index1 <= Groups.Count - 1; ++index1)
      {
        List<Entity> copiedEnt1 = new List<Entity>();
        List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
        buVector5.CopyEntities(Groups[index1].Outside, ref copiedEnt1);
        buVector5.CopyEntities(Groups[index1].Inside, ref copiedEnt2);
        clsInit.appCommand.undoBuffer();
        if (clsTufting.varTuftingSettings.SpiralOutterEnable)
        {
          List<Entity> LastCalcEntities = new List<Entity>();
          this.ContourOperation(true, clsTufting.varTuftingSettings.SpiralOutterOffset, 1, CamClosedContourType.Inner, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, false, name, copiedEnt1, ref LastCalcEntities);
          copiedEnt1.Clear();
          buVector5.CopyEntities(LastCalcEntities, ref copiedEnt1);
          LastCalcEntities.Clear();
        }
        if (clsTufting.varTuftingSettings.SpiralInnerEnable & copiedEnt2.Count > 0)
        {
          List<List<Entity>> refEnt = new List<List<Entity>>();
          for (int index2 = 0; index2 <= copiedEnt2.Count - 1; ++index2)
          {
            List<Entity> LastCalcEntities = new List<Entity>();
            this.ContourOperation(true, clsTufting.varTuftingSettings.SpiralInnerOffset, 1, CamClosedContourType.Outter, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, false, name, copiedEnt2[index2], ref LastCalcEntities);
            refEnt.Add(LastCalcEntities);
          }
          copiedEnt2.Clear();
          buVector5.CopyEntities(refEnt, ref copiedEnt2);
          refEnt.Clear();
        }
        camTp camTp = new camTp();
        MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
        ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
        ccVars.toolActive.Geometry.Diameter = clsTufting.varTuftingSettings.StraightRowSpace * 2.0;
        MWCalcOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
        MWCalcOptions.NumberofAxis = 3;
        MWCalcOptions.CamWireframeType = CamWireFrameType.Pocket;
        MWCalcOptions.Mode = CamMode.WireFrame;
        MWCalcOptions.DontApplyReset = true;
        MWCalcOptions.isBuWireframeCalculation = false;
        MWCalcOptions.AddToCamListInMWCalculation = false;
        MWCalcOptions.DontShowDialogBox = true;
        MWCalcOptions.isBuSort = false;
        MWCalcOptions.UseStartPoint = false;
        MWCalcOptions.UseConstantStartPoint = true;
        MWCalcOptions.StartPointX = 0.0;
        MWCalcOptions.StartPointY = 0.0;
        MWCalcOptions.HeightFromEntities = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
        buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = clsTufting.varTuftingSettings.StraightAngle;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtOffset;
        buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = clsTufting.varTuftingSettings.SpiralRowSpace;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ReverseCuttingOrderFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = clsTufting.varTuftingSettings.CutTolerance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
        buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = true;
        buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = clsTufting.varTuftingSettings.MaxDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = true;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = clsTufting.varTuftingSettings.MinDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = clsTufting.varTuftingSettings.SharpCorner;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = new PercentOrValueParameter(Unit.Metric, true)
        {
          Percent = 50.0
        };
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        if (clsTufting.varTuftingSettings.LinkAsSpline)
        {
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
        }
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
        clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
        List<Entity> refEntities = new List<Entity>();
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false, true, true, true);
        SortResult sortResult = new SortResult();
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.appCommand.SelectionToEntities(ref refEntities, Option2);
        clsInit.cVector5.EntitiesPlaneCheck(ref refEntities);
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
        double num1 = MaxPoint.Y - MinPoint.Y - ccVars.toolActive.Geometry.Diameter;
        double num2 = Math.Round(num1 / clsTufting.varTuftingSettings.StraightRowSpace, 0);
        MWCalcOptions.WireframeRoughtStepOverParaelelOverride = num1 / (num2 - 1.0);
        camTp Cam = new camTp();
        camResult Result = (camResult) null;
        clsMW.CamEntities.Clear();
        clsMW.CamEntitiesGroup.Clear();
        MWCalcOptions.UseSortedAndSplitedEntities = false;
        if (copiedEnt1.Count > 0 & copiedEnt2.Count > 0)
        {
          MWCalcOptions.UseSortedAndSplitedEntities = true;
          clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt1));
          for (int index3 = 0; index3 <= copiedEnt2.Count - 1; ++index3)
            clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt2[index3]));
        }
        else
          buVector5.CopyEntities(copiedEnt1, ref clsMW.CamEntities);
        clsInit.appMW.doWireframeContour(MWCalcOptions, ccVars.toolActive, ref Cam, ref Result);
        buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
        ccVars.toolActive.Geometry.Diameter = !clsTufting.varTuftingSettings.SpiralInnerEnable ? clsTufting.varTuftingSettings.SpiralInnerOffset * 2.0 : clsTufting.varTuftingSettings.SpiralInnerOffset * 2.0 * 2.0;
        clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
        List<List<Point3D>> point3DListList = new List<List<Point3D>>();
        List<Point3D> Points = new List<Point3D>();
        bool flag1 = false;
        Point3D pt = new Point3D();
        for (int index4 = 0; index4 <= Cam.EntitiesG1.Count - 1; ++index4)
        {
          if (index4 == 14)
            ;
          List<Point3D> point3DList = new List<Point3D>();
          List<Point3D> List = new List<Point3D>();
          Point3D point3D = new Point3D();
          bool flag2 = false;
          for (int index5 = 0; index5 <= Cam.EntitiesG1[index4].Vertices.Length - 1; ++index5)
            List.Add(buVector5.ToPoint3D(Cam.EntitiesG1[index4].Vertices[index5]));
          int num3 = -1;
          for (int index6 = 1; index6 <= List.Count - 2; ++index6)
          {
            if (clsInit.cVector5.AngleOfTwoLines(List[index6 - 1], List[index6], List[index6], List[index6 + 1], Plane.XY) < 160.0 & num3 == -1)
            {
              num3 = index6;
              index6 = List.Count;
            }
          }
          if (num3 >= 0)
            clsInit.cVector5.ShiftPointList(ref List, -num3);
          if (index4 < Cam.EntitiesG1.Count - 1 && Point3D.Distance(Cam.EntitiesG1[index4].Vertices[Cam.EntitiesG1[index4].Vertices.Length - 1], Cam.EntitiesG1[index4 + 1].Vertices[0]) < clsTufting.varTuftingSettings.SpiralRowSpace * 1.3)
          {
            Point3D EndPnt = new Point3D();
            double Angle = clsInit.cVector5.PointAngle(List[List.Count - 1], List[List.Count - 2], Plane.XY);
            clsInit.cVector5.LineWithLengthAndAngle(List[List.Count - 2], 10000.0, Angle, ref EndPnt);
            Point3D[] point3DArray = new Line(List[List.Count - 2], EndPnt).IntersectWith((ICurve) Cam.EntitiesG1[index4 + 1], 0.0, true);
            if (point3DArray != null && point3DArray.Length != 0)
            {
              point3D = buVector5.ToPoint3D(point3DArray[0]);
              List[List.Count - 1] = new Point3D(point3DArray[0].X, point3DArray[0].Y);
              flag2 = true;
            }
          }
          if (index4 > 0 && Point3D.Distance(Cam.EntitiesG1[index4 - 1].Vertices[Cam.EntitiesG1[index4 - 1].Vertices.Length - 1], Cam.EntitiesG1[index4].Vertices[0]) < clsTufting.varTuftingSettings.SpiralRowSpace * 1.2 && flag1)
          {
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) List);
            ICurve lower = (ICurve) new LinearPath(Array.Empty<Point3D>());
            ICurve upper = (ICurve) new LinearPath(Array.Empty<Point3D>());
            linearPath.SplitBy(pt, out lower, out upper);
            if (lower != null)
            {
              List = new List<Point3D>();
              if (((Entity) lower).Vertices.Length > ((Entity) upper).Vertices.Length)
                List.AddRange((IEnumerable<Point3D>) ((Entity) lower).Vertices);
              else
                List.AddRange((IEnumerable<Point3D>) ((Entity) upper).Vertices);
            }
          }
          ccVars.UndoDont = true;
          if (List.Count > 0)
            Points.AddRange((IEnumerable<Point3D>) List);
          if (!flag2)
          {
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
            point3DListList.Add(Points);
            Points = new List<Point3D>();
          }
          flag1 = flag2;
          pt = new Point3D(point3D.X, point3D.Y, point3D.Z);
        }
        if (point3DListList.Count > 0)
        {
          if (clsTufting.varTuftingSettings.SpiralInOutDirection == InOutDirection.OutsideToInside)
          {
            for (int index7 = 0; index7 <= point3DListList.Count - 1; ++index7)
              point3DListList[index7].Reverse();
            point3DListList.Reverse();
          }
          for (int index8 = 0; index8 <= point3DListList.Count - 1; ++index8)
          {
            ccVars.UndoDont = true;
            clsInit.cVector5.GetAvailableGroupIndex(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref GroupIndex);
            clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
            LinearPath refEntity = new LinearPath((ICollection<Point3D>) point3DListList[index8]);
            refEntity.EntityData = (object) new CustomData();
            string EntityName = "Tufting" + this.TuftCounter.ToString();
            this.CreateTuftEntity((Entity) refEntity, name, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftFill", SequenceID, GroupIndex);
          }
        }
      }
      clsInit.appCommand.Reset();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[24];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doWireframeTrace()
  {
    try
    {
      int GroupID = -1;
      int SequenceID = -1;
      clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      string name = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.isDirectionArrow)
          clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
      }
      SelectionOption Option1 = new SelectionOption(true, false, false, false, false, false, true, true, true);
      List<Entity> AllEntities = new List<Entity>();
      clsInit.appCommand.SelectionToEntities(ref AllEntities, Option1);
      clsInit.cVector5.EntitiesPlaneCheck(ref AllEntities);
      Point3D RefPoint = new Point3D();
      if (AllEntities[0] is ICurve)
        RefPoint = buVector5.ToPoint3D(((ICurve) AllEntities[0]).StartPoint);
      List<EntitiesGroup> Groups = new List<EntitiesGroup>();
      clsInit.cVector5.FindEntitiesGroupFromEntities(RefPoint, AllEntities, Plane.XY, ref Groups);
      for (int index1 = 0; index1 <= Groups.Count - 1; ++index1)
      {
        List<Entity> copiedEnt1 = new List<Entity>();
        List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
        buVector5.CopyEntities(Groups[index1].Outside, ref copiedEnt1);
        buVector5.CopyEntities(Groups[index1].Inside, ref copiedEnt2);
        clsInit.appCommand.undoBuffer();
        if (clsTufting.varTuftingSettings.TraceOutterEnable)
        {
          List<Entity> LastCalcEntities = new List<Entity>();
          this.ContourOperation(true, clsTufting.varTuftingSettings.TraceOutterOffset, 1, CamClosedContourType.Inner, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, false, name, copiedEnt1, ref LastCalcEntities);
          copiedEnt1.Clear();
          buVector5.CopyEntities(LastCalcEntities, ref copiedEnt1);
          LastCalcEntities.Clear();
        }
        if (clsTufting.varTuftingSettings.TraceInnerEnable & copiedEnt2.Count > 0)
        {
          List<List<Entity>> refEnt = new List<List<Entity>>();
          for (int index2 = 0; index2 <= copiedEnt2.Count - 1; ++index2)
          {
            List<Entity> LastCalcEntities = new List<Entity>();
            this.ContourOperation(true, clsTufting.varTuftingSettings.TraceInnerOffset, 1, CamClosedContourType.Outter, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, false, name, copiedEnt2[index2], ref LastCalcEntities);
            refEnt.Add(LastCalcEntities);
          }
          copiedEnt2.Clear();
          buVector5.CopyEntities(refEnt, ref copiedEnt2);
          refEnt.Clear();
        }
        camTp camTp = new camTp();
        MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
        ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
        ccVars.toolActive.Geometry.Diameter = clsTufting.varTuftingSettings.TraceRowSpace;
        MWCalcOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
        MWCalcOptions.NumberofAxis = 3;
        MWCalcOptions.CamWireframeType = CamWireFrameType.Pocket;
        MWCalcOptions.Mode = CamMode.WireFrame;
        MWCalcOptions.DontApplyReset = true;
        MWCalcOptions.isBuWireframeCalculation = false;
        MWCalcOptions.AddToCamListInMWCalculation = false;
        MWCalcOptions.DontShowDialogBox = true;
        MWCalcOptions.isBuSort = false;
        MWCalcOptions.UseStartPoint = false;
        MWCalcOptions.UseConstantStartPoint = true;
        MWCalcOptions.StartPointX = 0.0;
        MWCalcOptions.StartPointY = 0.0;
        MWCalcOptions.HeightFromEntities = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
        buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = clsTufting.varTuftingSettings.StraightRowSpace;
        buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = clsTufting.varTuftingSettings.StraightAngle;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtOffset;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = clsTufting.varTuftingSettings.CutTolerance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
        buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = true;
        buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = clsTufting.varTuftingSettings.MaxDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = true;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = clsTufting.varTuftingSettings.MinDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = clsTufting.varTuftingSettings.SharpCorner;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = new PercentOrValueParameter(Unit.Metric, true)
        {
          Percent = 50.0
        };
        if (clsTufting.varTuftingSettings.TraceConnection)
        {
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
          if (clsTufting.varTuftingSettings.TraceSplineConnection & !clsTufting.varTuftingSettings.TraceConnectOneBefore)
          {
            buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
            buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
          }
        }
        else
        {
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        }
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
        clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
        List<Entity> refEntities = new List<Entity>();
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false, true, true, true);
        SortResult sortResult = new SortResult();
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.appCommand.SelectionToEntities(ref refEntities, Option2);
        clsInit.cVector5.EntitiesPlaneCheck(ref refEntities);
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
        ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
        ccVars.toolActive.Geometry.Diameter = clsTufting.varTuftingSettings.TraceRowSpace * 2.0;
        double num1 = MaxPoint.Y - MinPoint.Y - ccVars.toolActive.Geometry.Diameter;
        double num2 = Math.Round(num1 / clsTufting.varTuftingSettings.TraceRowSpace, 0);
        MWCalcOptions.WireframeRoughtStepOverParaelelOverride = num1 / (num2 - 1.0);
        camTp Cam = new camTp();
        camResult Result = (camResult) null;
        clsMW.CamEntities.Clear();
        clsMW.CamEntitiesGroup.Clear();
        MWCalcOptions.UseSortedAndSplitedEntities = false;
        if (copiedEnt1.Count > 0 & copiedEnt2.Count > 0)
        {
          MWCalcOptions.UseSortedAndSplitedEntities = true;
          clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt1));
          for (int index3 = 0; index3 <= copiedEnt2.Count - 1; ++index3)
            clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt2[index3]));
        }
        else
          buVector5.CopyEntities(copiedEnt1, ref clsMW.CamEntities);
        clsInit.appMW.doWireframeContour(MWCalcOptions, ccVars.toolActive, ref Cam, ref Result);
        buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
        List<Point3D> points = new List<Point3D>();
        for (int index4 = 0; index4 <= Cam.EntitiesG1.Count - 1; ++index4)
        {
          if ((Cam.EntitiesG1[index4] as ICurve).StartPoint.Z == 0.0)
          {
            if (clsTufting.varTuftingSettings.TraceConnectOneBefore & clsTufting.varTuftingSettings.TraceConnection && Cam.EntitiesG1[index4] is buLinearPathCam & index4 < Cam.EntitiesG1.Count - 1)
            {
              buLinearPathCam buLinearPathCam1 = Cam.EntitiesG1[index4] as buLinearPathCam;
              buLinearPathCam buLinearPathCam2 = (buLinearPathCam) null;
              if (Cam.EntitiesG1[index4 + 1] is buLinearPathCam)
              {
                buLinearPathCam2 = Cam.EntitiesG1[index4 + 1] as buLinearPathCam;
                if (buLinearPathCam2.isLink & buLinearPathCam2.LinkType == CamLinkType.ConnectionNotClearanceArea & buLinearPathCam1.Vertices[0].Z == 0.0 & buLinearPathCam2.Vertices[0].Z == 0.0)
                {
                  ICurve curve = (ICurve) buLinearPathCam1;
                  ICurve lower = (ICurve) null;
                  ICurve upper = (ICurve) null;
                  curve.SplitAt(curve.Length() - clsTufting.varTuftingSettings.TraceRowSpace, out lower, out upper);
                  if (lower != null & upper != null)
                  {
                    if (buCompare5.EQ(lower.Length(), clsTufting.varTuftingSettings.TraceRowSpace))
                    {
                      Cam.EntitiesG1[index4] = (Entity) new buLinearPathCam((LinearPath) upper.Clone());
                      Cam.EntitiesG1[index4 + 1].Vertices[0] = buVector5.ToPoint3D(upper.EndPoint);
                    }
                    if (buCompare5.EQ(upper.Length(), clsTufting.varTuftingSettings.TraceRowSpace))
                    {
                      Cam.EntitiesG1[index4] = (Entity) new buLinearPathCam((LinearPath) lower.Clone());
                      Cam.EntitiesG1[index4 + 1].Vertices[0] = buVector5.ToPoint3D(lower.EndPoint);
                      Cam.EntitiesG1[index4 + 1].Regen(buSystem.RegenDeviation);
                    }
                  }
                }
              }
              if (buLinearPathCam1.isLink & buLinearPathCam1.LinkType == CamLinkType.ConnectionNotClearanceArea && buLinearPathCam2 != null)
              {
                double num3 = Point3D.Distance(Cam.EntitiesG1[index4].Vertices[0], Cam.EntitiesG1[index4].Vertices[Cam.EntitiesG1[index4].Vertices.Length - 1]);
                buLinearPathCam buLinearPathCam3 = new buLinearPathCam((LinearPath) Cam.EntitiesG1[index4 - 1]);
                Point3D EndPnt1 = new Point3D();
                Point3D EndPnt2 = new Point3D();
                double num4 = clsInit.cVector5.PointAngle(buLinearPathCam2.Vertices[1], buLinearPathCam2.Vertices[0], Plane.XY);
                clsInit.cVector5.LineWithLengthAndAngle(buLinearPathCam2.Vertices[0], num3 * 0.2, num4 + 180.0, ref EndPnt1);
                double num5 = clsInit.cVector5.PointAngle(buLinearPathCam3.Vertices[buLinearPathCam3.Vertices.Length - 2], buLinearPathCam3.Vertices[buLinearPathCam3.Vertices.Length - 1], Plane.XY);
                clsInit.cVector5.LineWithLengthAndAngle(buLinearPathCam3.Vertices[buLinearPathCam3.Vertices.Length - 1], num3 * 0.2, num5 + 180.0, ref EndPnt2);
                List<Point3D> ctrlPoints = new List<Point3D>();
                Point3D Pnt = clsInit.cVector5.MiddlePointOfLine(Cam.EntitiesG1[index4].Vertices[0], Cam.EntitiesG1[index4].Vertices[Cam.EntitiesG1[index4].Vertices.Length - 1]);
                ctrlPoints.Add(buVector5.ToPoint3D(Cam.EntitiesG1[index4].Vertices[0]));
                ctrlPoints.Add(buVector5.ToPoint3D(EndPnt2));
                ctrlPoints.Add(buVector5.ToPoint3D(Pnt));
                ctrlPoints.Add(buVector5.ToPoint3D(EndPnt1));
                ctrlPoints.Add(buVector5.ToPoint3D(Cam.EntitiesG1[index4].Vertices[Cam.EntitiesG1[index4].Vertices.Length - 1]));
                devDept.Eyeshot.Entities.Curve curve = new devDept.Eyeshot.Entities.Curve(2, (IList<Point3D>) ctrlPoints);
                curve.Regen(0.01);
                Cam.EntitiesG1[index4] = (Entity) new buLinearPathCam(curve.Vertices);
              }
            }
            if (points.Count == 0)
              buVector5.VerticeToPointsListAdd(Cam.EntitiesG1[index4].Vertices, ref points);
            else if (buCompare5.EQ(points[points.Count - 1], Cam.EntitiesG1[index4].Vertices[0], buSystem.resolutionCompare))
            {
              buVector5.VerticeToPointsListAdd(Cam.EntitiesG1[index4].Vertices, ref points);
            }
            else
            {
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref points);
              clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
              ccVars.UndoDont = true;
              Entity refEntity = (Entity) new LinearPath((ICollection<Point3D>) points);
              refEntity.EntityData = (object) new CustomData();
              if (refEntity != null)
              {
                string EntityName = "Tufting" + this.TuftCounter.ToString();
                this.CreateTuftEntity(refEntity, name, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftFill", SequenceID, GroupID);
                points.Clear();
                points = new List<Point3D>();
                buVector5.VerticeToPointsListAdd(Cam.EntitiesG1[index4].Vertices, ref points);
              }
            }
          }
        }
        if (points.Count > 0)
        {
          clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref points);
          clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
          ccVars.UndoDont = true;
          Entity refEntity = (Entity) new LinearPath((ICollection<Point3D>) points);
          refEntity.EntityData = (object) new CustomData();
          if (refEntity != null)
          {
            string EntityName = "Tufting" + this.TuftCounter.ToString();
            this.CreateTuftEntity(refEntity, name, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftFill", SequenceID, GroupID);
          }
        }
      }
      clsInit.appCommand.Reset();
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[23];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doWireframeCounter()
  {
    try
    {
      clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      string name = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.isDirectionArrow)
          clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
      }
      SelectionOption Option = new SelectionOption(true, false, false, false, false, false, true, true, true);
      List<Entity> AllEntities = new List<Entity>();
      clsInit.appCommand.SelectionToEntities(ref AllEntities, Option);
      clsInit.cVector5.EntitiesPlaneCheck(ref AllEntities);
      Point3D RefPoint = new Point3D();
      if (AllEntities[0] is ICurve)
        RefPoint = buVector5.ToPoint3D(((ICurve) AllEntities[0]).StartPoint);
      List<EntitiesGroup> Groups = new List<EntitiesGroup>();
      clsInit.cVector5.FindEntitiesGroupFromEntities(RefPoint, AllEntities, Plane.XY, ref Groups);
      for (int index1 = 0; index1 <= Groups.Count - 1; ++index1)
      {
        List<Entity> copiedEnt1 = new List<Entity>();
        List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
        buVector5.CopyEntities(Groups[index1].Outside, ref copiedEnt1);
        buVector5.CopyEntities(Groups[index1].Inside, ref copiedEnt2);
        clsInit.appCommand.undoBuffer();
        if (clsTufting.varTuftingSettings.ContourOutBorderEnable)
        {
          List<Entity> LastCalcEntities = new List<Entity>();
          this.ContourOperation(true, clsTufting.varTuftingSettings.ContourOutterOffset, clsTufting.varTuftingSettings.ContourOutBorderCount, CamClosedContourType.Inner, clsTufting.varTuftingSettings.ContourOutBorderFillDirection, clsTufting.varTuftingSettings.ContourOutBorderType, clsTufting.varTuftingSettings.ContourOutBorderConnect, name, copiedEnt1, ref LastCalcEntities);
          copiedEnt1.Clear();
          buVector5.CopyEntities(LastCalcEntities, ref copiedEnt1);
          LastCalcEntities.Clear();
        }
        if (clsTufting.varTuftingSettings.ContourInBorderEnable & copiedEnt2.Count > 0)
        {
          List<List<Entity>> refEnt = new List<List<Entity>>();
          for (int index2 = 0; index2 <= copiedEnt2.Count - 1; ++index2)
          {
            List<Entity> LastCalcEntities = new List<Entity>();
            this.ContourOperation(true, clsTufting.varTuftingSettings.ContourInnerOffset, clsTufting.varTuftingSettings.ContourInBorderCount, CamClosedContourType.Outter, clsTufting.varTuftingSettings.ContourInBorderFillDirection, clsTufting.varTuftingSettings.ContourInBorderType, clsTufting.varTuftingSettings.ContourInBorderConenct, name, copiedEnt2[index2], ref LastCalcEntities);
            refEnt.Add(LastCalcEntities);
          }
          copiedEnt2.Clear();
          buVector5.CopyEntities(refEnt, ref copiedEnt2);
          refEnt.Clear();
        }
      }
      clsInit.appCommand.Reset();
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[23];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doRandomPattern()
  {
    try
    {
      List<Entity> entityList1 = new List<Entity>();
      F_TuftingRandomPattern tuftingRandomPattern = new F_TuftingRandomPattern();
      tuftingRandomPattern.Settings = new TuftingSettings(clsTufting.varTuftingSettings);
      tuftingRandomPattern.Init();
      int num1 = (int) tuftingRandomPattern.ShowDialog();
      if (tuftingRandomPattern.PropertiesForm.Result != DialogResult.OK)
        return;
      clsTufting.varTuftingSettings = new TuftingSettings(tuftingRandomPattern.Settings);
      int num2 = 0;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name.IndexOf("T_") >= 0)
          ++num2;
      }
      if (num2 < clsTufting.varTuftingSettings.RandomPatternColorNumber)
      {
        buString5.MessageBoxWarning(buTufting.LangTuftingMessage[6]);
        clsInit.appCommand.Reset();
      }
      else
      {
        int SequenceID = -1;
        clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
        string name = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.isDirectionArrow)
            clsTufting.varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
        }
        SelectionOption Option1 = new SelectionOption(true, false, false, false, false, false, true, true, true);
        List<Entity> AllEntities = new List<Entity>();
        clsInit.appCommand.SelectionToEntities(ref AllEntities, Option1);
        clsInit.cVector5.EntitiesPlaneCheck(ref AllEntities);
        Point3D RefPoint = new Point3D();
        if (AllEntities[0] is ICurve)
          RefPoint = buVector5.ToPoint3D(((ICurve) AllEntities[0]).StartPoint);
        List<Entity> entityList2 = new List<Entity>();
        List<List<Entity>> entityListList = new List<List<Entity>>();
        List<List<Entity>> NotInsideEntities = new List<List<Entity>>();
        clsInit.cVector5.FindOutsideAndInsidentitiesFromEntities(RefPoint, AllEntities, Plane.XY, ref entityList2, ref entityListList, ref NotInsideEntities);
        clsInit.appCommand.undoBuffer();
        if (clsTufting.varTuftingSettings.StraightOutBorderEnable)
        {
          List<Entity> LastCalcEntities = new List<Entity>();
          this.ContourOperation(true, clsTufting.varTuftingSettings.StraightOutterOffset, clsTufting.varTuftingSettings.StraightOutBorderCount, CamClosedContourType.Inner, clsTufting.varTuftingSettings.StraightOutBorderFillDirection, clsTufting.varTuftingSettings.StraightOutBorderType, clsTufting.varTuftingSettings.StraightOutBorderConnect, name, entityList2, ref LastCalcEntities);
          entityList2.Clear();
          buVector5.CopyEntities(LastCalcEntities, ref entityList2);
          LastCalcEntities.Clear();
        }
        if (clsTufting.varTuftingSettings.StraightInBorderEnable & entityListList.Count > 0)
        {
          List<List<Entity>> refEnt = new List<List<Entity>>();
          for (int index = 0; index <= entityListList.Count - 1; ++index)
          {
            List<Entity> LastCalcEntities = new List<Entity>();
            this.ContourOperation(true, clsTufting.varTuftingSettings.StraightInnerOffset, clsTufting.varTuftingSettings.StraightInBorderCount, CamClosedContourType.Outter, clsTufting.varTuftingSettings.StraightInBorderFillDirection, clsTufting.varTuftingSettings.StraightInBorderType, clsTufting.varTuftingSettings.StraightInBorderConenct, name, entityListList[index], ref LastCalcEntities);
            refEnt.Add(LastCalcEntities);
          }
          entityListList.Clear();
          buVector5.CopyEntities(refEnt, ref entityListList);
          refEnt.Clear();
        }
        camTp camTp = new camTp();
        MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
        ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
        ccVars.toolActive.Geometry.Diameter = clsTufting.varTuftingSettings.StraightRowSpace * 2.0;
        MWCalcOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
        MWCalcOptions.NumberofAxis = 3;
        MWCalcOptions.CamWireframeType = CamWireFrameType.Pocket;
        MWCalcOptions.Mode = CamMode.WireFrame;
        MWCalcOptions.DontApplyReset = true;
        MWCalcOptions.isBuWireframeCalculation = false;
        MWCalcOptions.AddToCamListInMWCalculation = false;
        MWCalcOptions.DontShowDialogBox = true;
        MWCalcOptions.isBuSort = false;
        MWCalcOptions.UseStartPoint = false;
        MWCalcOptions.UseConstantStartPoint = true;
        MWCalcOptions.StartPointX = 0.0;
        MWCalcOptions.StartPointY = 0.0;
        MWCalcOptions.HeightFromEntities = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
        if (!clsTufting.varTuftingSettings.StraightRowLink)
          buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeOneway;
        buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = clsTufting.varTuftingSettings.StraightRowSpace;
        buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = clsTufting.varTuftingSettings.StraightAngle;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtParallel;
        buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = clsTufting.varTuftingSettings.CutTolerance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
        buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = clsTufting.varTuftingSettings.MaxDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = clsTufting.varTuftingSettings.MinDistance;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = clsTufting.varTuftingSettings.SharpCorner;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = new PercentOrValueParameter(Unit.Metric, true)
        {
          Percent = 50.0
        };
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
        if (clsTufting.varTuftingSettings.LinkAsSpline)
        {
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
        }
        if (!clsTufting.varTuftingSettings.StraightRowLink)
        {
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
          buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        }
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
        buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
        clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
        List<Entity> refEntities = new List<Entity>();
        SelectionOption Option2 = new SelectionOption(true, false, false, false, false, false, true, true, true);
        SortResult sortResult = new SortResult();
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.appCommand.SelectionToEntities(ref refEntities, Option2);
        clsInit.cVector5.EntitiesPlaneCheck(ref refEntities);
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
        double num3 = MaxPoint.Y - MinPoint.Y - ccVars.toolActive.Geometry.Diameter;
        double num4 = Math.Round(num3 / clsTufting.varTuftingSettings.StraightRowSpace, 0);
        MWCalcOptions.WireframeRoughtStepOverParaelelOverride = num3 / (num4 - 1.0);
        camTp Cam = new camTp();
        camResult Result = (camResult) null;
        clsMW.CamEntities.Clear();
        clsMW.CamEntitiesGroup.Clear();
        MWCalcOptions.UseSortedAndSplitedEntities = false;
        if (entityList2.Count > 0 & entityListList.Count > 0)
        {
          MWCalcOptions.UseSortedAndSplitedEntities = true;
          clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(entityList2));
          for (int index = 0; index <= entityListList.Count - 1; ++index)
            clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(entityListList[index]));
        }
        else
          buVector5.CopyEntities(entityList2, ref clsMW.CamEntities);
        clsInit.appMW.doWireframeContour(MWCalcOptions, ccVars.toolActive, ref Cam, ref Result);
        buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
        for (int index1 = 0; index1 <= Cam.EntitiesG1.Count - 1; ++index1)
        {
          if ((Cam.EntitiesG1[index1] as ICurve).StartPoint.Z == 0.0)
          {
            clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
            ccVars.UndoDont = true;
            Entity EyeEntity = (Entity) null;
            buConversion5.EyeCamEntityToEyeEntity(Cam.EntitiesG1[index1], ref EyeEntity);
            if (EyeEntity != null)
            {
              for (int index2 = 1; index2 <= EyeEntity.Vertices.Length - 1; ++index2)
              {
                if (buCompare5.EQ(EyeEntity.Vertices[index2 - 1].Y, EyeEntity.Vertices[index2].Y, 0.01))
                {
                  Line line = new Line(EyeEntity.Vertices[index2 - 1], EyeEntity.Vertices[index2]);
                  line.EntityData = (object) new CustomData();
                  entityList1.Add((Entity) line);
                }
              }
            }
          }
        }
        if (entityList1.Count > 0)
        {
          int num5 = 0;
          int ActiveColor = 0;
          string LayerName1 = "";
          this.GetLayerNameFRomActiveColor(clsTufting.varTuftingSettings.RandomPatternColorNumber + 1, ref LayerName1);
          Random random = new Random();
          for (int index = 0; index <= entityList1.Count - 1; ++index)
          {
            string LayerName2 = "";
            ICurve curve = entityList1[index] as ICurve;
            if (num5 % clsTufting.varTuftingSettings.RandomPatternColorLineNumber == 0)
            {
              ++ActiveColor;
              if (ActiveColor > clsTufting.varTuftingSettings.RandomPatternColorNumber)
                ActiveColor = 1;
            }
            double num6 = random.NextDouble();
            if (num6 < 0.1)
              num6 = 0.1;
            if (num6 > 0.9)
              num6 = 0.9;
            this.GetLayerNameFRomActiveColor(ActiveColor, ref LayerName2);
            double num7 = Point3D.Distance(curve.StartPoint, curve.EndPoint);
            double num8 = 1.0 - num6;
            double x1 = curve.StartPoint.X;
            double x2 = curve.EndPoint.X;
            if (curve.EndPoint.X < x1)
            {
              x1 = curve.EndPoint.X;
              x2 = curve.StartPoint.X;
            }
            Point3D Pnt1 = new Point3D(x1, curve.StartPoint.Y, 0.0);
            Point3D Pnt2 = new Point3D(x1 + num7 * (num8 / 2.0), curve.StartPoint.Y, 0.0);
            Point3D Pnt3 = new Point3D(x1 + num7 - num7 * (num8 / 2.0), curve.StartPoint.Y, 0.0);
            Point3D Pnt4 = new Point3D(x2, curve.StartPoint.Y, 0.0);
            LinearPath refEntity1 = new LinearPath((ICollection<Point3D>) new List<Point3D>()
            {
              buVector5.ToPoint3D(Pnt2),
              buVector5.ToPoint3D(Pnt3)
            });
            CustomData customData1 = new CustomData((CustomData) entityList1[index].EntityData);
            refEntity1.EntityData = (object) customData1;
            this.CreateTuftEntity((Entity) refEntity1, LayerName2);
            LinearPath refEntity2 = new LinearPath((ICollection<Point3D>) new List<Point3D>()
            {
              buVector5.ToPoint3D(Pnt1),
              buVector5.ToPoint3D(Pnt2)
            });
            CustomData customData2 = new CustomData((CustomData) entityList1[index].EntityData);
            refEntity2.EntityData = (object) customData2;
            this.CreateTuftEntity((Entity) refEntity2, LayerName1);
            LinearPath refEntity3 = new LinearPath((ICollection<Point3D>) new List<Point3D>()
            {
              buVector5.ToPoint3D(Pnt3),
              buVector5.ToPoint3D(Pnt4)
            });
            CustomData customData3 = new CustomData((CustomData) entityList1[index].EntityData);
            refEntity3.EntityData = (object) customData3;
            this.CreateTuftEntity((Entity) refEntity3, LayerName1);
            ++num5;
          }
        }
        clsInit.appCommand.Reset();
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[23];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doDeletePattern()
  {
    try
    {
      if (buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[88]) != DialogResult.Yes)
        return;
      List<string> Names = new List<string>();
      for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
      {
        int index2 = ccVars.SelectionOP.Selections[index1].Index;
        Names.Add(((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData).EntityName);
      }
      this.DeleteArrowAndMarkerByReleatedEntityName(Names);
      for (int index3 = 0; index3 <= Names.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index4)
        {
          CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].EntityData as CustomData;
          if (entityData.EntityName == Names[index3] & entityData.typeDefination == entityTypeDefination.Tufting)
          {
            clsInit.appCommand.OsnapDeleteByEntityName(entityData.EntityName);
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
          }
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.Reset();
      clsInit.appCommand.PagesUpdate(true, "");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[28];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doDeleteSorted()
  {
    try
    {
      if (buString5.MessageBoxQuestion(buTufting.LangTuftingMessage[0]) != DialogResult.Yes)
        return;
      List<string> Names = new List<string>();
      for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
      {
        int index2 = ccVars.SelectionOP.Selections[index1].Index;
        Names.Add(((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData).EntityName);
      }
      this.DeleteArrowAndMarkerByReleatedEntityName(Names);
      for (int index3 = 0; index3 <= Names.Count - 1; ++index3)
      {
        for (int index4 = buTuftingCalc.Sorted.Count - 1; index4 >= 0; --index4)
        {
          for (int index5 = buTuftingCalc.Sorted[index4].SortedEntities.Count - 1; index5 >= 0; --index5)
          {
            if ((buTuftingCalc.Sorted[index4].SortedEntities[index5].EntityData as CustomData).EntityName == Names[index3])
            {
              buTuftingCalc.Sorted[index4].SortedEntities.RemoveAt(index5);
              index5 = 0;
            }
          }
          if (buTuftingCalc.Sorted[index4].SortedEntities.Count == 0)
            buTuftingCalc.Sorted.RemoveAt(index4);
        }
      }
      for (int index6 = 0; index6 <= Names.Count - 1; ++index6)
      {
        for (int index7 = 0; index7 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index7)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index7].ColorMethod == colorMethodType.byEntity)
          {
            CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index7].EntityData as CustomData;
            if (entityData.typeDefination == entityTypeDefination.Tufting & entityData.CamSelected & Names[index6] == entityData.EntityName)
            {
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index7].ColorMethod = colorMethodType.byLayer;
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index7].LineWeightMethod = colorMethodType.byLayer;
              ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index7].EntityData).CamSelected = false;
            }
          }
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.PagesUpdate(true, "");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[29];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doDeleteAllPattern()
  {
    try
    {
      if (buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[88]) != DialogResult.Yes)
        return;
      List<string> Names = new List<string>();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Tufting)
          Names.Add(entityData.EntityName);
      }
      this.DeleteArrowAndMarkerByReleatedEntityName(Names);
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Tufting)
        {
          clsInit.appCommand.OsnapDeleteByEntityName(entityData.EntityName);
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.PagesUpdate(true, "");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[30];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doDeleteAllSorted()
  {
    try
    {
      if (buString5.MessageBoxQuestion(buTufting.LangTuftingMessage[0]) != DialogResult.Yes)
        return;
      buTuftingCalc.Sorted.Clear();
      List<string> stringList = new List<string>();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.DirectionArrow | entityData.typeDefination == entityTypeDefination.EndMarker | entityData.typeDefination == entityTypeDefination.StartMarker)
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].ColorMethod == colorMethodType.byEntity)
        {
          CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
          if (entityData.typeDefination == entityTypeDefination.Tufting & entityData.CamSelected)
          {
            if (entityData.tuftingMode == tuftingStitchModeType.None & entityData.tuftingPileHeight == 0.0 & entityData.tuftingStitchLength == 0.0)
            {
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].ColorMethod = colorMethodType.byLayer;
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeightMethod = colorMethodType.byLayer;
            }
            else
            {
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeight = (float) clsTufting.varTuftingSettings.DefinationEntityThickness;
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].ColorMethod = colorMethodType.byEntity;
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LineWeightMethod = colorMethodType.byEntity;
            }
            ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData).CamSelected = false;
          }
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.PagesUpdate(true, "");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[31 /*0x1F*/];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doSortAll()
  {
    Color white = Color.White;
    double LayerThickness = 1.0;
    for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index1)
    {
      List<Entity> sortingEntities = new List<Entity>();
      if (ccVars.Pages[ccVars.PageIndex].Layers[index1].Name.IndexOf("T_") >= 0)
      {
        clsInit.cVector5.GetLayerColorAndThicknessByLayerName(ccVars.Pages[ccVars.PageIndex].Layers[index1].Name, ccVars.Pages[ccVars.PageIndex].Layers, ref white, ref LayerThickness);
        if (LayerThickness < 1.0)
          LayerThickness = 1.0;
        for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
        {
          Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2];
          clsInit.cVector5.GetEntityCustomData(entity1);
          if (entity1.LayerName.Trim() == ccVars.Pages[ccVars.PageIndex].Layers[index1].Name.Trim())
          {
            Entity entity2 = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2]);
            sortingEntities.Add(entity2);
          }
        }
        if (sortingEntities.Count > 0)
        {
          clsTufting.varTuftingSettings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
          this.SortEntities(ref sortingEntities, white, LayerThickness, ccVars.Pages[ccVars.PageIndex].Layers[index1].Name, new List<Entity>());
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        }
      }
    }
  }

  public void doSortPattern()
  {
    try
    {
      List<Entity> sortingEntities1 = new List<Entity>();
      List<Entity> sortingEntities2 = new List<Entity>();
      Color white = Color.White;
      double LayerThickness = 1.0;
      clsInit.cVector5.GetLayerColorAndThicknessByLayerName(clsTufting.varTuftingRunSettings.SelectedLayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref white, ref LayerThickness);
      if (LayerThickness < 1.0)
        LayerThickness = 1.0;
      if (clsTufting.varTuftingSettings.SortType != tuftingSelectionModeType.Auto)
        return;
      if (clsTufting.varTuftingSettings.SortOutlineFirst)
      {
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
          CustomData entityCustomData = clsInit.cVector5.GetEntityCustomData(entity1);
          if (entity1.LayerName.Trim() == clsTufting.varTuftingRunSettings.SelectedLayerName.Trim() && entityCustomData.ActionName == "TuftOutline" & clsInit.cTuft.isSameLayerTuftOrOutline(clsTufting.varTuftingRunSettings.SelectedLayerName, entity1.LayerName))
          {
            Entity entity2 = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]);
            sortingEntities1.Add(entity2);
          }
        }
        if (sortingEntities1.Count > 0)
          this.SortEntities(ref sortingEntities1, white, LayerThickness, clsTufting.varTuftingRunSettings.SelectedLayerName, new List<Entity>());
      }
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        CustomData entityCustomData = clsInit.cVector5.GetEntityCustomData(entity3);
        if (entity3.LayerName.Trim() == clsTufting.varTuftingRunSettings.SelectedLayerName.Trim() && entityCustomData.ActionName == "TuftFill" & clsInit.cTuft.isSameLayerTuftOrOutline(clsTufting.varTuftingRunSettings.SelectedLayerName, entity3.LayerName))
        {
          Entity entity4 = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]);
          sortingEntities2.Add(entity4);
        }
      }
      if (sortingEntities2.Count <= 0)
        return;
      this.SortEntities(ref sortingEntities2, white, LayerThickness, clsTufting.varTuftingRunSettings.SelectedLayerName, new List<Entity>());
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[32 /*0x20*/];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doSortManuel()
  {
    Color white = Color.White;
    double LayerThickness = 1.0;
    if (ccVars.SortedEntities.Count == 0)
      return;
    clsTufting.varTuftingRunSettings.SelectedLayerName = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
    if (clsTufting.varTuftingRunSettings.SelectedLayerName != ccVars.SortedEntities[0].LayerName)
    {
      if (ccVars.SortedEntities[0] is buUpperLineEnt)
      {
        if (ccVars.SortedEntities.Count >= 2)
          clsTufting.varTuftingRunSettings.SelectedLayerName = ccVars.SortedEntities[1].LayerName;
      }
      else
        clsTufting.varTuftingRunSettings.SelectedLayerName = ccVars.SortedEntities[0].LayerName;
    }
    clsInit.cVector5.GetLayerColorAndThicknessByLayerName(clsTufting.varTuftingRunSettings.SelectedLayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref white, ref LayerThickness);
    if (LayerThickness < 1.0)
      LayerThickness = 1.0;
    if (ccVars.SortedEntities.Count <= 0)
      return;
    List<Entity> sortingEntities = new List<Entity>();
    this.SortEntities(ref sortingEntities, white, LayerThickness, clsTufting.varTuftingRunSettings.SelectedLayerName, ccVars.SortedEntities);
    clsInit.appCommand.Reset();
  }

  public void doChangeDirection()
  {
    try
    {
      List<string> stringList = new List<string>();
      for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
      {
        int index2 = ccVars.SelectionOP.Selections[index1].Index;
        stringList.Add(((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData).EntityName);
      }
      this.DeleteArrowAndMarkerByReleatedEntityName(stringList);
      this.AddArrowAndMarkerEntitiesFromName(true, stringList);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.Reset();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[26];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doExchangeSelection()
  {
    try
    {
      List<string> Names = new List<string>();
      for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
      {
        int index2 = ccVars.SelectionOP.Selections[index1].Index;
        Names.Add(((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData).EntityName);
      }
      this.DeleteArrowAndMarkerByReleatedEntityName(Names);
      string name = ccVars.Pages[ccVars.PageIndex].Layers[clsTufting.varTuftingRunSettings.SelectedLayerIndex].Name;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Layers[index].Tufting.isDirectionArrow)
          name = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
      }
      for (int index3 = 0; index3 <= Names.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index4)
        {
          if (((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].EntityData).EntityName == Names[index3])
          {
            LinearPath entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4] as LinearPath;
            entity.Reverse();
            int num = index4;
            if (clsVar.varInterface5.DirectionArrowSettings.Enable)
            {
              List<buLinearPathArrow> DirArrows = new List<buLinearPathArrow>();
              clsInit.cVector5.DirectionArrowFromEntities((Entity) entity, clsVar.varInterface5.DirectionArrowSettings, ref DirArrows);
              if (DirArrows.Count > 0)
              {
                for (int index5 = 0; index5 <= DirArrows.Count - 1; ++index5)
                {
                  ccVars.UndoDont = true;
                  DirArrows[index5].EntityData = (object) new CustomData();
                  DirArrows[index5].LayerName = name;
                  DirArrows[index5].Selectable = false;
                  DirArrows[index5].RefEntity = num;
                  clsInit.appCommand.AddEntity((Entity) DirArrows[index5]);
                }
              }
            }
          }
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.Reset();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[27];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doGetClosedArea(Point3D refPoint)
  {
    try
    {
      List<Entity> EntityList = new List<Entity>();
      List<Entity> entityList = new List<Entity>();
      bool flag = false;
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
        copiedEntity.EntityData = (object) new CustomData((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData);
        EntityList.Add(copiedEntity);
      }
      List<PointAndAngleRange> pointAndAngleRangeList1 = new List<PointAndAngleRange>();
      List<int> List = new List<int>();
      List<PointAndIndex> touchDomainPoints = new List<PointAndIndex>();
      for (double Angle = 0.0; Angle <= 360.0; Angle += 20.0)
      {
        Point3D EndPnt = new Point3D();
        clsInit.cVector5.LineWithLengthAndAngle(refPoint, 10000.0, Angle, ref EndPnt);
        Line entityIntersect = new Line(refPoint, EndPnt);
        List<Point3D> pntIntersect = new List<Point3D>();
        List<int> intList = new List<int>();
        PointAndAngleRange pntRange = new PointAndAngleRange();
        int EntityIndex = -1;
        if (clsInit.cVector5.GetClosestIntersectPointsFromEntities(EntityList, (Entity) entityIntersect, refPoint, Angle, ref pntIntersect, ref pntRange, ref EntityIndex, ref touchDomainPoints) & pntRange.AngleMin != pntRange.AngleMax)
        {
          if (EntityIndex >= 0)
            buNumeric5.AddValueToList(EntityIndex, ref List);
          pointAndAngleRangeList1.Add(pntRange);
          Line line = new Line(refPoint, pntRange.refPoint);
          entityList.Add((Entity) line);
        }
      }
      List<int> Added = new List<int>();
      if (List.Count > 0)
      {
        List<Entity> BaseRefEntities = new List<Entity>();
        for (int index = 0; index <= List.Count - 1; ++index)
        {
          Entity entity = (Entity) null;
          buEntity.Copy(EntityList[List[index]], ref entity);
          if (entity.Vertices == null)
            clsInit.cVector5.RegenEntity(buSystem.RegenDeviation, ref entity);
          BaseRefEntities.Add(entity);
        }
        SortSettings Settings = new SortSettings();
        SortResult Result = new SortResult();
        List<Entity> SortedEntities = new List<Entity>();
        Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
        Settings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
        clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].Vertices[0], ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
        if (clsInit.cVector5.isEntitiesClosed(SortedEntities))
        {
          for (int index = 0; index <= List.Count - 1; ++index)
            Added.Add(List[index]);
          flag = true;
        }
      }
      if (!flag)
      {
        for (int index1 = 1; index1 <= 20; ++index1)
        {
          List<PointAndAngleRange> lst = new List<PointAndAngleRange>();
          for (int index2 = 0; index2 <= pointAndAngleRangeList1.Count - 1; ++index2)
          {
            double num = (pointAndAngleRangeList1[index2].AngleMax - 5.0 - (pointAndAngleRangeList1[index2].AngleMin + 5.0)) / 10.0;
            for (double Angle = pointAndAngleRangeList1[index2].AngleMin + 5.0; Angle <= pointAndAngleRangeList1[index2].AngleMax - 5.0; Angle += num)
            {
              Point3D EndPnt = new Point3D();
              clsInit.cVector5.LineWithLengthAndAngle(pointAndAngleRangeList1[index2].refPoint, 100000.0, Angle, ref EndPnt);
              Line entityIntersect = new Line(pointAndAngleRangeList1[index2].refPoint, EndPnt);
              List<Point3D> pntIntersect = new List<Point3D>();
              List<int> intList = new List<int>();
              PointAndAngleRange pntRange = new PointAndAngleRange();
              int EntityIndex = -1;
              if (clsInit.cVector5.GetClosestIntersectPointsFromEntities(EntityList, (Entity) entityIntersect, pointAndAngleRangeList1[index2].refPoint, Angle, ref pntIntersect, ref pntRange, ref EntityIndex, ref touchDomainPoints) & pntRange.AngleMax != pntRange.AngleMin)
              {
                if (EntityIndex >= 0)
                  buNumeric5.AddValueToList(EntityIndex, ref List);
                Line line = new Line(pointAndAngleRangeList1[index2].refPoint, pntRange.refPoint);
                entityList.Add((Entity) line);
                lst.Add(pntRange);
              }
            }
          }
          pointAndAngleRangeList1.Clear();
          pointAndAngleRangeList1 = new List<PointAndAngleRange>();
          if (lst.Count > 0)
          {
            List<PointAndAngleRange> pointAndAngleRangeList2 = clsInit.cVector5.SortByDistance(lst, new PointAndAngleRange());
            for (int index3 = 0; index3 <= pointAndAngleRangeList2.Count - 1; ++index3)
            {
              if (index3 == 0)
                pointAndAngleRangeList1.Add(new PointAndAngleRange(pointAndAngleRangeList2[index3]));
              else if (Point3D.Distance(pointAndAngleRangeList1[pointAndAngleRangeList1.Count - 1].refPoint, pointAndAngleRangeList2[index3].refPoint) > 50.0)
                pointAndAngleRangeList1.Add(new PointAndAngleRange(pointAndAngleRangeList2[index3]));
            }
          }
          if (index1 == 1 | index1 % 2 == 0 && List.Count > 0)
          {
            List<Entity> BaseRefEntities = new List<Entity>();
            for (int index4 = 0; index4 <= List.Count - 1; ++index4)
            {
              Entity entity = (Entity) null;
              buEntity.Copy(EntityList[List[index4]], ref entity);
              if (entity.Vertices == null)
                clsInit.cVector5.RegenEntity(buSystem.RegenDeviation, ref entity);
              BaseRefEntities.Add(entity);
            }
            SortSettings Settings = new SortSettings();
            SortResult Result = new SortResult();
            List<Entity> SortedEntities = new List<Entity>();
            Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
            Settings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
            clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].Vertices[0], ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
            if (clsInit.cVector5.isEntitiesClosed(SortedEntities))
            {
              for (int index5 = 0; index5 <= List.Count - 1; ++index5)
                Added.Add(List[index5]);
              index1 = 100000;
            }
          }
        }
      }
      if (clsTufting.varTuftingSettings.ShowClosedPathCalculationEntities)
      {
        clsInit.appCommand.undoBuffer();
        for (int index = 0; index <= entityList.Count - 1; ++index)
        {
          ccVars.UndoDont = true;
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(entityList[index], ref copiedEntity);
          copiedEntity.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
          copiedEntity.Regen(0.01);
          clsInit.appCommand.AddEntity(copiedEntity);
        }
      }
      entityList.Clear();
      clsInit.appCommand.SelectedToSelectionAdd(Added);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[25];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doAnalyseImportEntities()
  {
    ccVars.Pages[ccVars.PageIndex].OsnapPoints.Clear();
    int index1 = 0;
    for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index2)
    {
      for (int index3 = 0; index3 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index3)
      {
        if (index2 != index3 && buImage5.isColorSame(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index2].Color, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index3].Color) & (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index2].Name.ToLower().IndexOf("t_") >= 0 | ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index2].Name.ToLower().IndexOf("o_") >= 0) && index1 >= 0 & index1 <= clsVar.ColorList.Count - 1)
        {
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index2].Color = clsVar.ColorList[index1];
          ccVars.Pages[ccVars.PageIndex].Layers[index2].LayerColor = clsVar.ColorList[index1];
          ++index1;
        }
      }
    }
    for (int index4 = 0; index4 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index4)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].ColorMethod = colorMethodType.byLayer;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineWeightMethod = colorMethodType.byLayer;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineTypeMethod = colorMethodType.byLayer;
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].GetType() == typeof (LinearPathEx))
      {
        LinearPath linearPath = new LinearPath(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Vertices);
        linearPath.LayerName = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LayerName;
        linearPath.Color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Color;
        linearPath.ColorMethod = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].ColorMethod;
        linearPath.LineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineWeight;
        linearPath.LineWeightMethod = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].LineWeightMethod;
        linearPath.EntityData = (object) new CustomData((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].EntityData);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4] = (Entity) linearPath;
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    ccVars.Pages[ccVars.PageIndex].OsnapPoints.Clear();
    clsInit.appCommand.OsnapCalculationAll();
  }

  public void doBreakAllIntersection()
  {
    List<Entity> entityList1 = new List<Entity>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      string name = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName != name && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
        entityList1.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]));
    }
    List<Entity> entityList2 = new List<Entity>();
    for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index1)
    {
      string name = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1].LayerName == name)
      {
        ICurve entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1] as ICurve;
        List<Point3D> points = new List<Point3D>();
        for (int index2 = 0; index2 <= entityList1.Count - 1; ++index2)
        {
          Point3D[] collection = entity1.IntersectWith((ICurve) entityList1[index2]);
          if (collection != null & collection.Length != 0)
            points.AddRange((IEnumerable<Point3D>) collection);
        }
        if (points.Count > 0)
        {
          clsInit.cVector5.SortPointByDistance(new Point3D(), SortDirectionType.Lower, ref points);
          ICurve[] segments = (ICurve[]) null;
          clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref points);
          entity1.SplitBy((IList<Point3D>) points, out segments);
          if (segments != null & segments.Length != 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1].Selected = true;
            for (int index3 = 0; index3 <= segments.Length - 1; ++index3)
            {
              Entity entity2 = (Entity) segments[index3];
              entity2.EntityData = (object) new CustomData((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1].EntityData);
              entityList2.Add(entity2);
            }
          }
        }
      }
    }
    if (entityList2.Count <= 0)
      return;
    clsInit.appCommand.undoBuffer();
    clsInit.appCommand.Delete(true);
    for (int index = 0; index <= entityList2.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      clsInit.appCommand.AddEntity(entityList2[index]);
    }
  }

  public void doEntitiesEdited(List<Entity> entitiesEdited)
  {
    List<string> stringList = new List<string>();
    for (int index = 0; index <= entitiesEdited.Count - 1; ++index)
    {
      CustomData entityData = entitiesEdited[index].EntityData as CustomData;
      if (entityData.typeDefination == entityTypeDefination.Tufting & entityData.CamSelected)
        stringList.Add(entityData.EntityName);
    }
    this.DeleteArrowAndMarkerByReleatedEntityName(stringList);
    this.AddArrowAndMarkerEntitiesFromName(false, stringList);
  }

  public void doAddManuelEntities(Entity Ent)
  {
    if (ccVars.Pages[ccVars.PageIndex].LayerName.ToLower().IndexOf("t_") >= 0)
    {
      string EntityName = "Tufting" + this.TuftCounter.ToString();
      this.CreateTuftEntity(Ent, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftManuel", -1, -1);
      ++this.TuftCounter;
    }
    else
    {
      bool realDrawMode = ccVars.RealDrawMode;
      ccVars.RealDrawMode = false;
      if (Ent is LinearPath)
        clsInit.appCommand.AddPolyline((LinearPath) Ent);
      else
        clsInit.appCommand.AddEntity(Ent);
      ccVars.RealDrawMode = realDrawMode;
    }
  }

  public void doAddBorderLine(Entity Ent)
  {
    List<Point3D> lst = new List<Point3D>();
    List<Entity> entityList = new List<Entity>();
    for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index1)
    {
      Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1];
      ICurve entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1] as ICurve;
      CustomData Data = new CustomData((CustomData) entity1.EntityData);
      Point3D[] point3DArray = entity2.IntersectWith((ICurve) Ent);
      if (point3DArray != null)
      {
        ICurve[] segments = (ICurve[]) null;
        List<Point3D> points = new List<Point3D>();
        for (int index2 = 0; index2 <= point3DArray.Length - 1; ++index2)
        {
          points.Add(buVector5.ToPoint3D(point3DArray[index2]));
          lst.Add(buVector5.ToPoint3D(point3DArray[index2]));
        }
        entity2.SplitBy((IList<Point3D>) points, out segments);
        if (segments != null && segments.Length != 0)
        {
          for (int index3 = 0; index3 <= segments.Length - 1; ++index3)
          {
            Entity entity3 = (Entity) segments[index3];
            Data.EntityName = "Tufting" + this.TuftCounter.ToString();
            ++this.TuftCounter;
            entity3.EntityData = (object) new CustomData(Data);
            entity3.LayerName = entity1.LayerName;
            entity3.Color = entity1.Color;
            entity3.ColorMethod = entity1.ColorMethod;
            entity3.LineWeight = entity1.LineWeight;
            entity3.LineWeightMethod = entity1.LineWeightMethod;
            entityList.Add(entity3);
          }
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1].Selected = true;
        }
      }
    }
    if (entityList.Count > 0)
    {
      clsInit.appCommand.undoBuffer();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      for (int index = 0; index <= entityList.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        clsInit.appCommand.AddEntity(entityList[index]);
      }
      List<Point3D> points = clsInit.cVector5.SortByDistance(lst);
      ICurve[] segments = (ICurve[]) null;
      ((ICurve) Ent).SplitBy((IList<Point3D>) points, out segments);
      if (segments != null && segments.Length != 0)
      {
        for (int index = 0; index <= segments.Length - 1; ++index)
        {
          Entity Ent1 = (Entity) segments[index];
          CustomData customData = new CustomData((CustomData) entityList[0].EntityData);
          customData.EntityName = "Tufting" + this.TuftCounter.ToString();
          ++this.TuftCounter;
          Ent1.EntityData = (object) customData;
          Ent1.LayerName = entityList[0].LayerName;
          Ent1.Color = entityList[0].Color;
          Ent1.ColorMethod = entityList[0].ColorMethod;
          Ent1.LineWeight = entityList[0].LineWeight;
          Ent1.LineWeightMethod = entityList[0].LineWeightMethod;
          ccVars.UndoDont = true;
          clsInit.appCommand.AddEntity(Ent1);
        }
      }
    }
    clsInit.appCommand.Reset();
  }

  public void doAddOutlineEntities(Entity Ent)
  {
    string EntityName = "Tufting" + this.TuftCounter.ToString();
    this.CreateTuftEntity(Ent, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, EntityName, "TuftOutline", -1, -1);
    ++this.TuftCounter;
  }

  public void doAddImage()
  {
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count <= 0 || !(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Picture))
      return;
    string str = "";
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name.ToLower().IndexOf("image") >= 0)
        str = ccVars.Pages[ccVars.PageIndex].Layers[index].Name;
    }
    if (str.Length > 0)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].LayerName = str;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doJoin()
  {
    try
    {
      SortSettings Settings = new SortSettings();
      SortResult Result = new SortResult();
      List<Entity> SortedEntities = new List<Entity>();
      Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
      List<Entity> entityList = new List<Entity>();
      clsInit.appCommand.SelectionToEntities(ref entityList, new SelectionOption()
      {
        CircleToArc = true,
        CircleTo4Arc = true,
        SplitArcIfGreatThen180 = true,
        Point = false
      });
      if (entityList.Count <= 0)
        return;
      string layerName = entityList[0].LayerName;
      clsInit.cVector5.SortEntitiesByRefPoint(entityList[0].Vertices[0], ref entityList, Settings, ref SortedEntities, ref Result);
      List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      if (SplitedEntitites.Count > 1)
      {
        for (int index = 0; index <= entityList.Count - 1; ++index)
          ((CustomData) entityList[index].EntityData).CamSelected = false;
        clsInit.cVector5.SortEntitiesByRefPoint(entityList[0].Vertices[entityList[0].Vertices.Length - 1], ref entityList, Settings, ref SortedEntities, ref Result);
        SplitedEntitites = new List<List<Entity>>();
        clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
      {
        List<Point3D> Points = new List<Point3D>();
        clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index], buSystem.RegenDeviation, ref Points);
        LinearPath refEntity = new LinearPath((ICollection<Point3D>) Points);
        refEntity.EntityData = (object) new CustomData();
        this.CreateTuftEntity((Entity) refEntity, layerName);
      }
      clsInit.appCommand.PagesUpdate(true, "");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[32 /*0x20*/];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doAddPoint(Point3D PntAdd, System.Drawing.Point mousePoint)
  {
    try
    {
      int underMouseCursor = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.GetEntityUnderMouseCursor(mousePoint);
      if (underMouseCursor >= 0 & underMouseCursor <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1 && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor] is ICurve)
      {
        Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor];
        ICurve entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor] as ICurve;
        double t = 0.0;
        entity2.ClosestPointTo(PntAdd, out t);
        Point3D point3D = entity2.PointAt(t);
        List<Point3D> points = new List<Point3D>();
        points.Add(buVector5.ToPoint3D(entity1.Vertices[0]));
        for (int index = 1; index <= entity1.Vertices.Length - 1; ++index)
        {
          if (clsInit.cVector5.IsPointInsideLine(entity1.Vertices[index - 1], entity1.Vertices[index], point3D, new WorkPlane()))
          {
            points.Add(buVector5.ToPoint3D(point3D));
            points.Add(buVector5.ToPoint3D(entity1.Vertices[index]));
          }
          else
            points.Add(buVector5.ToPoint3D(entity1.Vertices[index]));
        }
        if (points.Count > 0)
        {
          CustomData Data = new CustomData((CustomData) entity1.EntityData);
          Entity entity3 = buVector5.CopyEntities(entity1);
          clsInit.appCommand.OsnapDeleteByEntityName(Data.EntityName);
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
          linearPath.EntityData = (object) new CustomData(Data);
          linearPath.LayerName = entity3.LayerName;
          linearPath.Color = entity3.Color;
          linearPath.ColorMethod = entity3.ColorMethod;
          linearPath.LineWeight = entity3.LineWeight;
          linearPath.LineWeightMethod = entity3.LineWeightMethod;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor] = (Entity) linearPath;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor].Regen(buSystem.RegenDeviation);
          clsInit.appCommand.OsnapCalculation(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor]);
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.Reset();
      this.cmdAddPoint();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[22];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doRemovePoint(Point3D PntRemove, System.Drawing.Point mousePoint)
  {
    try
    {
      int underMouseCursor = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.GetEntityUnderMouseCursor(mousePoint);
      if (underMouseCursor >= 0 & underMouseCursor <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1 && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor] is ICurve)
      {
        Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor];
        List<Point3D> points = new List<Point3D>();
        for (int index = 0; index <= entity1.Vertices.Length - 1; ++index)
        {
          if (!buCompare5.EQ(entity1.Vertices[index], PntRemove, buSystem.resolutionCompare))
            points.Add(buVector5.ToPoint3D(entity1.Vertices[index]));
        }
        if (points.Count > 0)
        {
          CustomData Data = new CustomData((CustomData) entity1.EntityData);
          Entity entity2 = buVector5.CopyEntities(entity1);
          clsInit.appCommand.OsnapDeleteByEntityName(Data.EntityName);
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
          linearPath.EntityData = (object) new CustomData(Data);
          linearPath.LayerName = entity2.LayerName;
          linearPath.Color = entity2.Color;
          linearPath.ColorMethod = entity2.ColorMethod;
          linearPath.LineWeight = entity2.LineWeight;
          linearPath.LineWeightMethod = entity2.LineWeightMethod;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor] = (Entity) linearPath;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor].Regen(buSystem.RegenDeviation);
          clsInit.appCommand.OsnapCalculation(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[underMouseCursor]);
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsInit.appCommand.Reset();
      this.cmdRemovePoint();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[22];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doSelectAndBrakeBySelection()
  {
    List<Entity> entityList = new List<Entity>();
    List<int> IndexList = new List<int>();
    List<string> stringList = new List<string>();
    SelectionOption Option = new SelectionOption(true, false, false, false, false, false, true, true, true);
    clsInit.appCommand.SelectionToEntities(ref entityList, Option);
    if (entityList.Count == 0)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      LayerBase5 Layer = new LayerBase5();
      clsInit.cVector5.GetLayerFromName(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name, ref Layer);
      double num1 = 0.0;
      double num2 = 0.0;
      tuftingStitchModeType tuftingStitchModeType = tuftingStitchModeType.None;
      if (Layer.Tufting != null)
      {
        num1 = Layer.Tufting.StitchLength;
        num2 = Layer.Tufting.PileHeight;
        tuftingStitchModeType = Layer.Tufting.StitchMode;
      }
      if (((CustomData) entityList[0].EntityData).tuftingPileHeight > 0.0)
        num2 = ((CustomData) entityList[0].EntityData).tuftingPileHeight;
      if (((CustomData) entityList[0].EntityData).tuftingStitchLength > 0.0)
        num1 = ((CustomData) entityList[0].EntityData).tuftingStitchLength;
      if (((CustomData) entityList[0].EntityData).tuftingMode != tuftingStitchModeType.None)
        tuftingStitchModeType = ((CustomData) entityList[0].EntityData).tuftingMode;
      F_TuftingSetProps fTuftingSetProps = new F_TuftingSetProps();
      fTuftingSetProps.StitchLen = num1;
      fTuftingSetProps.TuftingMode = tuftingStitchModeType;
      fTuftingSetProps.PileHeight = num2;
      fTuftingSetProps.Init();
      int num3 = (int) fTuftingSetProps.ShowDialog();
      if (fTuftingSetProps.PropertiesForm.Result != DialogResult.OK)
      {
        clsInit.appCommand.Reset();
      }
      else
      {
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected)
            ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData).DontUseForCalculation = true;
        }
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        if (entityList.Count > 0)
        {
          clsInit.appCommand.undoBuffer();
          bool flag = false;
          List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
          List<Entity> SortedEntities = new List<Entity>();
          SortSettings Settings = new SortSettings();
          SortResult Result = new SortResult();
          Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
          Settings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
          clsInit.cVector5.SortEntitiesByRefPoint(entityList[0].Vertices[0], ref entityList, Settings, ref SortedEntities, ref Result);
          clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
          for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
          {
            List<Point3D> Points = new List<Point3D>();
            clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index1], buSystem.RegenDeviation, ref Points);
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
            if (clsInit.cVector5.IsClosed(Points))
            {
              List<Entity> entSplited = new List<Entity>();
              clsInit.appCommand.SplitEntitiesByClosedPointList(true, Points, ref entSplited);
              if (entSplited.Count > 0)
              {
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
                for (int index2 = 0; index2 <= entSplited.Count - 1; ++index2)
                {
                  ccVars.UndoDont = true;
                  clsInit.appTufting.CreateTuftEntity(entSplited[index2], entSplited[index2].LayerName);
                  Point3D RefPoint = clsInit.cVector5.MiddlePointOfLine(entSplited[index2].BoxMin, entSplited[index2].BoxMax);
                  if (clsInit.cVector5.IsPointInsidePolygon(Points, RefPoint))
                  {
                    flag = true;
                    CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].EntityData as CustomData;
                    stringList.Add(entityData.EntityName);
                  }
                }
              }
            }
          }
          if (flag)
          {
            for (int index = 0; index <= stringList.Count - 1; ++index)
              IndexList.Add(clsInit.cVector5.GetEntityIndexByEntityName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, stringList[index]));
            for (int index = 0; index <= IndexList.Count - 1; ++index)
            {
              CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[IndexList[index]].EntityData as CustomData;
              entityData.tuftingMode = fTuftingSetProps.TuftingMode;
              entityData.tuftingStitchLength = fTuftingSetProps.StitchLen;
              entityData.tuftingPileHeight = fTuftingSetProps.PileHeight;
            }
            this.ApplySetProperties(IndexList, fTuftingSetProps.TuftingMode, fTuftingSetProps.PileHeight, fTuftingSetProps.StitchLen);
          }
          else
          {
            for (int index = 0; index <= ccVars.SelectionOP.Selections.Count - 1; ++index)
            {
              IndexList.Add(ccVars.SelectionOP.Selections[index].Index);
              ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.SelectionOP.Selections[index].Index].EntityData).tuftingMode = fTuftingSetProps.TuftingMode;
              ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.SelectionOP.Selections[index].Index].EntityData).tuftingStitchLength = fTuftingSetProps.StitchLen;
              ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.SelectionOP.Selections[index].Index].EntityData).tuftingPileHeight = fTuftingSetProps.PileHeight;
            }
            this.ApplySetProperties(IndexList, fTuftingSetProps.TuftingMode, fTuftingSetProps.PileHeight, fTuftingSetProps.StitchLen);
          }
        }
        clsInit.appCommand.SetDontUseForCalculation(false);
        clsInit.appCommand.Reset();
      }
    }
  }

  public void doSelectAndBrakeByFreeSelection(List<Entity> Entities, List<Point3D> refPoints)
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    List<int> Added = new List<int>();
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      clsInit.appTufting.CreateTuftEntity(Entities[index], Entities[index].LayerName);
      Point3D RefPoint = clsInit.cVector5.MiddlePointOfLine(Entities[index].BoxMin, Entities[index].BoxMax);
      if (clsInit.cVector5.IsPointInsidePolygon(refPoints, RefPoint))
        Added.Add(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    clsInit.appCommand.SelectedToSelectionAdd(Added);
    this.doSetProps();
    clsInit.appCommand.Reset();
  }

  public void doSetProps()
  {
    List<string> stringList = new List<string>();
    List<int> intList = new List<int>();
    for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
    {
      int index2 = ccVars.SelectionOP.Selections[index1].Index;
      stringList.Add(((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData).EntityName);
      intList.Add(index2);
    }
    if (intList.Count <= 0)
      return;
    CustomData entityData1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[intList[0]].EntityData as CustomData;
    F_TuftingSetProps fTuftingSetProps = new F_TuftingSetProps();
    fTuftingSetProps.StitchLen = entityData1.tuftingStitchLength;
    fTuftingSetProps.TuftingMode = entityData1.tuftingMode;
    fTuftingSetProps.PileHeight = entityData1.tuftingPileHeight;
    fTuftingSetProps.Init();
    int num = (int) fTuftingSetProps.ShowDialog();
    if (fTuftingSetProps.PropertiesForm.Result != DialogResult.OK)
      return;
    clsInit.appCommand.undoBuffer();
    for (int index = 0; index <= intList.Count - 1; ++index)
    {
      CustomData entityData2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[intList[index]].EntityData as CustomData;
      entityData2.tuftingMode = fTuftingSetProps.TuftingMode;
      entityData2.tuftingStitchLength = fTuftingSetProps.StitchLen;
      entityData2.tuftingPileHeight = fTuftingSetProps.PileHeight;
    }
    this.ApplySetProperties(new List<int>(), fTuftingSetProps.TuftingMode, fTuftingSetProps.PileHeight, fTuftingSetProps.StitchLen);
  }

  public void CreateCodeFromSorted(TuftingSequenceItem Sorted, ref List<string> GCodes)
  {
    LayerBase5 Layer = new LayerBase5();
    clsInit.cVector5.GetLayerFromName(ccVars.Pages[ccVars.PageIndex].Layers, Sorted.LayerName, ref Layer);
    double pileHeight = Layer.Tufting.PileHeight;
    double stitchLength = Layer.Tufting.StitchLength;
    tuftingStitchModeType stitchMode = Layer.Tufting.StitchMode;
    Point3D point3D = new Point3D();
    tuftingStitchModeType tuftingStitchModeType = tuftingStitchModeType.None;
    for (int index1 = 0; index1 <= Sorted.SortedEntities.Count - 1; ++index1)
    {
      double PileHeight = 0.0;
      double StitchLen = 0.0;
      tuftingStitchModeType TuftMode = tuftingStitchModeType.None;
      string str1 = "";
      if (Sorted.SortedEntities[index1].Vertices.Length >= 2)
      {
        if (!this.GetDefinationFromEntity(Sorted.SortedEntities[index1], ref StitchLen, ref PileHeight, ref TuftMode))
        {
          PileHeight = pileHeight;
          StitchLen = stitchLength;
          TuftMode = stitchMode;
        }
        if (index1 == 0)
        {
          string str2 = $"{$"G0 X{Sorted.SortedEntities[index1].Vertices[0].X.ToString("f3")} Y{Sorted.SortedEntities[index1].Vertices[0].Y.ToString("f3")}"} Z{PileHeight.ToString("f1")} S{StitchLen.ToString("f1")}{str1}";
          GCodes.Add("M2");
          GCodes.Add(str2);
          GCodes.Add("M1");
          if (TuftMode == tuftingStitchModeType.Cut)
            GCodes.Add("M3");
          if (TuftMode == tuftingStitchModeType.Loop)
            GCodes.Add("M4");
        }
        else if (!buCompare5.EQ(Sorted.SortedEntities[index1].Vertices[0], point3D, 0.1))
        {
          string str3 = $"{$"G0 X{Sorted.SortedEntities[index1].Vertices[0].X.ToString("f3")} Y{Sorted.SortedEntities[index1].Vertices[0].Y.ToString("f3")}"} Z{PileHeight.ToString("f1")} S{StitchLen.ToString("f1")}{str1}";
          GCodes.Add("M2");
          GCodes.Add(str3);
          GCodes.Add("M1");
          if (TuftMode == tuftingStitchModeType.Cut)
            GCodes.Add("M3");
          if (TuftMode == tuftingStitchModeType.Loop)
            GCodes.Add("M4");
        }
        else if (TuftMode != tuftingStitchModeType)
        {
          if (TuftMode == tuftingStitchModeType.Cut)
            GCodes.Add("M3");
          if (TuftMode == tuftingStitchModeType.Loop)
            GCodes.Add("M4");
        }
        tuftingStitchModeType = TuftMode;
        for (int index2 = 1; index2 <= Sorted.SortedEntities[index1].Vertices.Length - 1; ++index2)
        {
          string str4 = $"{$"G1 X{Sorted.SortedEntities[index1].Vertices[index2].X.ToString("f3")} Y{Sorted.SortedEntities[index1].Vertices[index2].Y.ToString("f3")}"} Z{PileHeight.ToString("f1")} S{StitchLen.ToString("f1")}";
          if (index2 == 1)
            str4 += str1;
          GCodes.Add(str4);
          if (index2 == Sorted.SortedEntities[index1].Vertices.Length - 1)
            point3D = buVector5.ToPoint3D(Sorted.SortedEntities[index1].Vertices[index2]);
        }
      }
    }
    GCodes.Add("M2");
  }

  public void doConvertToTuftingLayer()
  {
    int layerIndex = ccVars.Pages[ccVars.PageIndex].LayerIndex;
    if (layerIndex < 0)
      return;
    string name = ccVars.Pages[ccVars.PageIndex].Layers[layerIndex].Name;
    Color color = Color.Transparent;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
      if (entity.LayerName == name && entity.ColorMethod == colorMethodType.byEntity)
        color = entity.Color;
    }
    if (color == Color.Transparent)
      color = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].LayerColor;
    if (color == Color.Transparent)
      color = Color.Blue;
    F_LayerConvertToTufting convertToTufting = new F_LayerConvertToTufting()
    {
      layer = new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex])
    };
    convertToTufting.layer.LayerColor = color;
    for (int index = 0; index <= this.Yarns.Count - 1; ++index)
      convertToTufting.Yarns.Add(new TuftingYarn(this.Yarns[index]));
    if (convertToTufting.layer.Name.IndexOf("T_") < 0)
      convertToTufting.layer.Name = "T_" + convertToTufting.layer.Name;
    convertToTufting.Init();
    int num = (int) convertToTufting.ShowDialog();
    if (convertToTufting.PropertiesForm.Result != DialogResult.OK)
      return;
    ccVars.Pages[ccVars.PageIndex].Layers[layerIndex] = new LayerBase5(convertToTufting.layer);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[layerIndex].Color = convertToTufting.layer.LayerColor;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[layerIndex].Name = convertToTufting.layer.Name;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
      if (entity.LayerName == name)
      {
        entity.LayerName = convertToTufting.layer.Name;
        entity.ColorMethod = colorMethodType.byLayer;
      }
      ((CustomData) entity.EntityData).typeDefination = entityTypeDefination.Tufting;
      ((CustomData) entity.EntityData).ActionName = "TuftFill";
      clsInit.appCommand.OsnapDeleteByEntityName(((CustomData) entity.EntityData).EntityName);
      clsInit.appCommand.OsnapCalculation(entity);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
    clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, true, 0);
  }
}
