// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Nesting.clsNesting
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Cutter;
using buCadCamResVer5.PanelCut;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using Opaline2Cs;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PowerNest2Cs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Nesting;

public class clsNesting
{
  public static List<buNestingSheet> Sheets = new List<buNestingSheet>();
  public static List<buNestingPart> Parts = new List<buNestingPart>();
  public List<buNestedResult> DoneResults = new List<buNestedResult>();
  public static List<buNestingMaterials> Materials = new List<buNestingMaterials>();
  public static buNestingVar ParNest = new buNestingVar();
  public static buNestingTempVars varTemps = new buNestingTempVars();
  public buNestedResult NestedResult = new buNestedResult();
  public List<buNestedResult> TempResults1 = new List<buNestedResult>();
  public List<Entity> AnalyseEntities = new List<Entity>();
  public static int BestNestCount = 0;

  public clsNesting(string Code = "")
  {
    if (!(Code == "DontCheckLicKeyBro") && !clsSystem.smethod_0(nameof (clsNesting)))
      throw new RegisterException(nameof (clsNesting));
  }

  public bool Init()
  {
    try
    {
      clsInit.appNestingPower = new clsPowerNest();
      if (clsVar.appModes_0.NestingMode.PanelMode)
        clsInit.appNestingPanel = new clsNestOpaline();
      clsItem.FrmNestSheetPart = new F_NestSheetPartList();
      clsItem.FrmNestPartAdd = new F_NestPartAdd();
      clsItem.FrmNestPartAddV2 = new F_NestPartAddV2();
      clsItem.FrmNestRectPartAdd = new F_NestRectPartAdd();
      clsItem.FrmNestSheetAdd = new F_NestSheetAdd();
      clsItem.FrmNestSheetShapeAdd = new F_NestSheetShapeAdd();
      clsItem.FrmNestExecute = new F_NestExecute();
      clsItem.FrmNestOnlineCalc = new F_NestOnlineCalc();
      clsItem.FrmNestedResult = new F_NestedResults();
      clsItem.FrmOldNestedResult = new F_NestOldResult();
      clsItem.FrmNestOnlineCalc.PreviewPressed += new OkCommandWithDataEventHandler(this.cmdPreviewPressed);
      clsItem.FrmNestOnlineCalc.StopPressed += new OkCommandEventHandler(this.cmdStopNestingPressed);
      clsItem.FrmNestOnlineCalc.SendPressed += new OkCommandWithDataEventHandler(this.cmdNestResultSendPressed);
      clsItem.FrmNestOnlineCalc.Applied += new OkCommandWithDataEventHandler(this.cmdNestResultApplied);
      clsItem.FrmNestOnlineCalc.ClosedPressed += new OkCommandEventHandler(this.cmdNesitngPageClosed);
      clsItem.FrmNestedResult.DrawResult += new OkCommandWithDataEventHandler(this.cmdResultDraw);
      clsItem.FrmNestedResult.Creat += new CreatbuNestedResultEventHandler(this.doCreate);
      clsItem.FrmNestedResult.Updated += new OkCommandWithDataEventHandler(this.cmdResultUpdate);
      clsItem.FrmNestedResult.Command += new ClickSenderDataEventHandler(this.cmdResultCommand);
      clsItem.FrmOldNestedResult.PreviewPressed += new OkCommandWithDataEventHandler(this.cmdOldNestingPreviewPressed);
      string path = Path.Combine(Application.StartupPath, "anpn2key.dll");
      int num = string.IsNullOrEmpty(path) ? 0 : (File.Exists(path) ? 1 : 0);
      if (clsVar.appModes_0.NestingMode.PanelMode)
      {
        if ((string.IsNullOrEmpty(clsInit.appNestingPanel.DllName) ? 0 : (File.Exists(clsInit.appNestingPanel.DllName) ? 1 : 0)) == 0)
        {
          buString5.MessageBoxError(buLangTranslate.preSentencesNesting.NoPartWillWeNested);
        }
        else
        {
          LicenseType licenseType = clsInit.appNestingPanel.CheckLicense();
          if (licenseType != LicenseType.License2D)
            buString5.MessageBoxError($"{buLangTranslate.preSentencesNesting.PanelCutNestingDllMode} {licenseType.ToString()}");
        }
      }
      return false;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public void cmdShowSheetPage(bool SheetVisible)
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        if (clsItem.FrmNestSheetPart == null)
          return;
        if (!clsItem.FrmNestSheetPart.Visible)
        {
          clsItem.FrmNestSheetPart.Sheets.Clear();
          clsItem.FrmNestSheetPart.Sheets = new List<buNestingSheet>();
          int tickCount = Environment.TickCount;
          for (int index = 0; index <= clsNesting.Sheets.Count - 1; ++index)
          {
            buNestingSheet Copied = new buNestingSheet();
            buNestingSheet.Copy(clsNesting.Sheets[index], ref Copied);
            if (Copied.ID <= 0)
            {
              clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref Copied.ID);
              clsNesting.Sheets[index].ID = Copied.ID;
            }
            clsItem.FrmNestSheetPart.Sheets.Add(Copied);
          }
          clsItem.FrmNestSheetPart.Parts.Clear();
          clsItem.FrmNestSheetPart.Parts = new List<buNestingPart>();
          for (int index = 0; index <= clsNesting.Parts.Count - 1; ++index)
          {
            buNestingPart Copied = new buNestingPart();
            buNestingPart.Copy(clsNesting.Parts[index], ref Copied);
            if (Copied.ID <= 0)
            {
              clsInit.cNesting.GetAvailableNestingPartID(clsNesting.Parts, ref Copied.ID);
              clsNesting.Parts[index].ID = Copied.ID;
            }
            clsItem.FrmNestSheetPart.Parts.Add(Copied);
          }
          int num1 = Environment.TickCount - tickCount;
          clsItem.FrmNestSheetPart.AddPartFromFileExtenderAsCsvType = clsNesting.ParNest.Runtime.AddCsvTypeToAddPartFromFile;
          clsItem.FrmNestSheetPart.CsvOpenTypeForAddNestingFromFile = clsNesting.ParNest.Runtime.NestingCsvTypeOpenModeForAddPart;
          clsItem.FrmNestSheetPart.AddPartFromFileFolder = clsVar.varInterface.pathNestingAddPart;
          clsItem.FrmNestSheetPart.AddPartFromFileExtensionIndex = clsVar.varInterface.NestingAddPartFromFileExtensionIndex;
          clsItem.FrmNestSheetPart.Settings = new buNestingVar(clsNesting.ParNest);
          clsItem.FrmNestSheetPart.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
          clsItem.FrmNestSheetPart.activeTool = new ToolBase5(ccVars.toolActive);
          clsItem.FrmNestSheetPart.activeLayer = new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex]);
          if (SheetVisible)
            clsItem.FrmNestSheetPart.Init(0);
          else
            clsItem.FrmNestSheetPart.Init(1);
          int num2 = (int) clsItem.FrmNestSheetPart.ShowDialog();
          if (clsItem.FrmNestSheetPart.PropertiesForm.Result != DialogResult.OK)
            return;
          clsNesting.ParNest = new buNestingVar(clsItem.FrmNestSheetPart.Settings);
          this.SheetPartUpdate();
          ccVars.tempEntities.Clear();
          if (clsItem.FrmNestSheetPart.SelectedRowPart >= 0 & clsItem.FrmNestSheetPart.DrawPart)
          {
            ccVars.tempEntities.Clear();
            buEntity.Copy(clsItem.FrmNestSheetPart.Parts[clsItem.FrmNestSheetPart.SelectedRowPart].EntitiesGroup, ref ccVars.tempEntities, Text: true);
            for (int index1 = 0; index1 <= ccVars.tempEntities.Count - 1; ++index1)
            {
              Entity tempEntity = ccVars.tempEntities[index1];
              bool flag = false;
              for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index2)
              {
                if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index2].Name == tempEntity.LayerName)
                {
                  flag = true;
                  tempEntity.ColorMethod = colorMethodType.byLayer;
                  tempEntity.LineWeightMethod = colorMethodType.byLayer;
                }
              }
              if (!flag)
              {
                tempEntity.ColorMethod = colorMethodType.byEntity;
                tempEntity.LineWeightMethod = colorMethodType.byEntity;
                tempEntity.LayerName = "Default";
              }
            }
            clsInit.cVector5.BoxSizeCalculate(ccVars.tempEntities, ref ccVars.pntMin, ref ccVars.pntMid, ref ccVars.pntMax);
            for (int index = 0; index <= ccVars.tempEntities.Count - 1; ++index)
            {
              ccVars.tempEntities[index].Translate(-ccVars.pntMid.X, -ccVars.pntMid.Y, -ccVars.pntMid.Z);
              ccVars.tempEntities[index].Regen(new RegenParams(clsVar.varEntities.RegenDeviation, (IWorkspace) clsItem.ModelOpenInsert));
            }
            clsInit.cVector5.BoxSizeCalculate(ccVars.tempEntities, ref ccVars.pntMin, ref ccVars.pntMid, ref ccVars.pntMax);
            ccVars.stpDrawing = 2;
            ccVars.selectionProcess = false;
            ccVars.Action = actionTypeBU.drawInsertFromFile;
          }
          else
          {
            if (!clsItem.FrmNestSheetPart.SendToCad)
              return;
            clsInit.appCommand.undoBuffer();
            for (int index = 0; index <= clsItem.FrmNestSheetPart.SendToCadEntities.Count - 1; ++index)
            {
              ccVars.UndoDont = true;
              clsItem.FrmNestSheetPart.SendToCadEntities[index].LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
              clsInit.appCommand.AddEntity(clsItem.FrmNestSheetPart.SendToCadEntities[index]);
            }
          }
        }
        else
          clsItem.FrmNestSheetPart.Visible = false;
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdShowAddSheet()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        if (clsItem.FrmNestSheetAdd == null)
          return;
        if (clsItem.FrmNestSheetAdd.IsDisposed)
          clsItem.FrmNestSheetAdd = new F_NestSheetAdd();
        if (!clsItem.FrmNestSheetAdd.Visible)
        {
          clsItem.FrmNestSheetAdd.ShowItemNo = clsNesting.ParNest.Runtime.ShowSheetAddItemNoParameter;
          clsItem.FrmNestSheetAdd.Sheet.MaterialData.Width = clsNesting.ParNest.AddMaterial.LastSheetWidth;
          clsItem.FrmNestSheetAdd.Sheet.MaterialData.Height = clsNesting.ParNest.AddMaterial.LastSheetHeight;
          clsItem.FrmNestSheetAdd.Sheet.MaterialData.Quantity = clsNesting.ParNest.AddMaterial.LastSheetQuantity;
          clsItem.FrmNestSheetAdd.Init();
          clsItem.FrmNestSheetAdd.StartPosition = FormStartPosition.CenterScreen;
          int num = (int) clsItem.FrmNestSheetAdd.ShowDialog();
          if (clsItem.FrmNestSheetAdd.Result != DialogResult.OK)
            return;
          clsNesting.ParNest.AddMaterial.LastSheetWidth = clsItem.FrmNestSheetAdd.Sheet.MaterialData.Width;
          clsNesting.ParNest.AddMaterial.LastSheetHeight = clsItem.FrmNestSheetAdd.Sheet.MaterialData.Height;
          clsNesting.ParNest.AddMaterial.LastSheetQuantity = clsItem.FrmNestSheetAdd.Sheet.MaterialData.Quantity;
          buNestingSheet buNestingSheet = new buNestingSheet(clsItem.FrmNestSheetAdd.Sheet);
          clsInit.cVector5.SetColorEntity(clsNesting.ParNest.Draw.SheetEntityColor, ref buNestingSheet.EntitiesGroup.Outside.Entities);
          clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref buNestingSheet.ID);
          clsNesting.Sheets.Add(buNestingSheet);
          clsInit.appCommand.ShowInformation(AppLanguage.CadCamInfo[0], 1000);
          clsFiles.SaveParameter();
        }
        else
          clsItem.FrmNestSheetAdd.Visible = false;
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdShowAddShapeSheet()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        clsInit.appCommand.Reset(false);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
        ccVars.Action = actionTypeBU.nestingAddMaterialShapeFromSelection;
        dynamicInfo.Command = AppLanguage.CadCamCommand[88];
        ccVars.selectionProcess = true;
        if (ccVars.SelectionOP.Selections.Count == 0)
        {
          ccVars.stpDrawing = 2;
          clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
        }
        else
          this.doAddShapePartAndSheet(new Point3D(), true, new List<Entity>());
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdShowAddRectPart()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        if (clsItem.FrmNestRectPartAdd == null)
          return;
        if (clsItem.FrmNestRectPartAdd.IsDisposed)
          clsItem.FrmNestRectPartAdd = new F_NestRectPartAdd();
        if (!clsItem.FrmNestRectPartAdd.Visible)
        {
          clsItem.FrmNestRectPartAdd.Settings = new buNestingVar(clsNesting.ParNest);
          clsItem.FrmNestRectPartAdd.ShowItemNo = clsNesting.ParNest.Runtime.ShowPartAddItemNoParameter;
          clsItem.FrmNestRectPartAdd.Init();
          clsItem.FrmNestRectPartAdd.StartPosition = FormStartPosition.CenterScreen;
          int num = (int) clsItem.FrmNestRectPartAdd.ShowDialog();
          if (clsItem.FrmNestRectPartAdd.Result != DialogResult.OK)
            return;
          clsNesting.ParNest = new buNestingVar(clsItem.FrmNestRectPartAdd.Settings);
          buNestingPart buNestingPart = new buNestingPart(clsItem.FrmNestRectPartAdd.Part);
          Entity entSurface = (Entity) null;
          if (clsNesting.ParNest.ProgramSettings.View3D)
            clsInit.cVector5.surfaceFromOutterInner(buNestingPart.EntitiesGroup, 0.2, ref entSurface);
          if (entSurface != null)
          {
            buNestingPart.EntitiesGroup.Solid = new buEntityList();
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(entSurface, ref copiedEntity);
            if (copiedEntity != null)
              buNestingPart.EntitiesGroup.Solid.Entities.Add(copiedEntity);
          }
          clsInit.cVector5.SetLayerNameEntity(ccVars.Pages[ccVars.PageIndex].LayerName, ref buNestingPart.EntitiesGroup.Outside.Entities);
          clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref buNestingPart.EntitiesGroup.Outside.Entities);
          if (buNestingPart.EntitiesGroup.Outside.Entities.Count > 0)
            clsInit.cVector5.SetToolNameEntity(ccVars.toolActive.Data.Name, ref buNestingPart.EntitiesGroup.Outside.Entities);
          clsInit.cNesting.GetAvailableNestingPartID(clsNesting.Parts, ref buNestingPart.ID);
          clsNesting.Parts.Add(buNestingPart);
          clsInit.appCommand.ShowInformation(AppLanguage.CadCamInfo[1], 1000);
          clsFiles.SaveParameter();
        }
        else
          clsItem.FrmNestRectPartAdd.Visible = false;
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdShowAddShapePart()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        clsInit.appCommand.Reset(false);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
        ccVars.Action = actionTypeBU.nestingAddPartFromSelection;
        if (clsVar.appModes_0.CutterMode.Enable)
          ccVars.Action = actionTypeBU.cutterAddPartFromSelection;
        dynamicInfo.Command = AppLanguage.CadCamCommand[88];
        ccVars.selectionProcess = true;
        clsInit.cVector5.SetNameIfNoName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities);
        if (clsVar.appModes_0.CutterMode.Enable)
          clsNesting.ParNest.AddPart.OutterContourLayerName = clsCutter.varCutterSettings.ContourLayerName;
        if (ccVars.SelectionOP.Selections.Count == 0)
        {
          ccVars.stpDrawing = 2;
          clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
        }
        else
          this.doAddShapePartAndSheet(new Point3D(), false, new List<Entity>());
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdShowAddShapePartAll()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      else
        this.doAddPartAll();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdShowPartSettings()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
        classViewerDialog.FormCaption = "Part";
        classViewerDialog.Value = (object) clsNesting.ParNest.PartSettings;
        classViewerDialog.StartPosition = FormStartPosition.CenterParent;
        classViewerDialog.Width = 500;
        classViewerDialog.Height = 600;
        classViewerDialog.ValuePersentage = 35.0;
        classViewerDialog.ParCaptions.AddRange((IEnumerable<string>) buNestingPartSettings.Captions);
        classViewerDialog.Init();
        int num = (int) classViewerDialog.ShowDialog();
        if (classViewerDialog.Result != DialogResult.OK)
          return;
        clsNesting.ParNest.PartSettings = new buNestingPartSettings((buNestingPartSettings) classViewerDialog.Value);
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdShowSheetSettings()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
        classViewerDialog.FormCaption = "Sheet";
        classViewerDialog.Value = (object) clsNesting.ParNest.MaterailSettings;
        classViewerDialog.StartPosition = FormStartPosition.CenterParent;
        classViewerDialog.Width = 500;
        classViewerDialog.Height = 750;
        classViewerDialog.ValuePersentage = 35.0;
        classViewerDialog.ParCaptions.AddRange((IEnumerable<string>) buNestingSheetSettings.Captions);
        classViewerDialog.Init();
        int num = (int) classViewerDialog.ShowDialog();
        if (classViewerDialog.Result != DialogResult.OK)
          return;
        clsNesting.ParNest.MaterailSettings = new buNestingSheetSettings((buNestingSheetSettings) classViewerDialog.Value);
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdShowResultSettings()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
        classViewerDialog.Text = "Result";
        classViewerDialog.Value = (object) clsNesting.ParNest.ResultSettings;
        classViewerDialog.StartPosition = FormStartPosition.CenterParent;
        classViewerDialog.Width = 500;
        classViewerDialog.Height = 750;
        classViewerDialog.ValuePersentage = 35.0;
        classViewerDialog.Init();
        int num = (int) classViewerDialog.ShowDialog();
        if (classViewerDialog.Result != DialogResult.OK)
          return;
        clsNesting.ParNest.ResultSettings = new buNestingResultSettings((buNestingResultSettings) classViewerDialog.Value);
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdShowNestingSettings()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
        classViewerDialog.Text = "Nesting";
        classViewerDialog.Value = (object) clsNesting.ParNest.Settings;
        classViewerDialog.StartPosition = FormStartPosition.CenterParent;
        classViewerDialog.Width = 500;
        classViewerDialog.Height = 350;
        classViewerDialog.ValuePersentage = 35.0;
        classViewerDialog.Init();
        int num = (int) classViewerDialog.ShowDialog();
        if (classViewerDialog.Result != DialogResult.OK)
          return;
        clsNesting.ParNest.Settings = new buNestingSettings((buNestingSettings) classViewerDialog.Value);
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdShowProgramSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Text = "Program";
      classViewerDialog.Value = (object) clsNesting.ParNest.ProgramSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 350;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      clsNesting.ParNest.ProgramSettings = new buNestingProgramSettings((buNestingProgramSettings) classViewerDialog.Value);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdExecute()
  {
    if (clsVar.appModes_0.NestingMode.PanelMode)
      this.cmdExecutePanel();
    else
      this.cmdExecuteTrueShape();
  }

  public void cmdExecuteTrueShape()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        clsItem.FrmNestExecute.Settings = new buNestingSettings(clsNesting.ParNest.Settings);
        clsItem.FrmNestExecute.RunTimeSettings = new buNestingRuntime(clsNesting.ParNest.Runtime);
        clsItem.FrmNestExecute.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsItem.FrmNestExecute.StartPosition = FormStartPosition.CenterScreen;
        clsItem.FrmNestExecute.Init();
        int num1 = (int) clsItem.FrmNestExecute.ShowDialog();
        if (clsItem.FrmNestExecute.PropertiesForm.Result != DialogResult.OK)
          return;
        clsNesting.ParNest.Settings = new buNestingSettings(clsItem.FrmNestExecute.Settings);
        clsNesting.ParNest.Runtime = new buNestingRuntime(clsItem.FrmNestExecute.RunTimeSettings);
        clsFiles.SaveParameter();
        int num2 = 0;
        int num3 = 0;
        for (int index = 0; index <= clsNesting.Parts.Count - 1; ++index)
        {
          if (clsNesting.Parts[index].Enable)
            num2 += clsNesting.Parts[index].Remain;
        }
        if (num2 == 0)
        {
          buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoPartWillWeNested);
        }
        else
        {
          for (int index = 0; index <= clsNesting.Sheets.Count - 1; ++index)
          {
            if (clsNesting.Sheets[index].Enable)
              num3 += clsNesting.Sheets[index].Remain;
          }
          if (num3 == 0)
          {
            buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoMaterialWillBeUsedForNesting);
          }
          else
          {
            PowerNest2.LogFunctionCalls(AppPath.Base + "\\NestingExecution.log");
            clsInit.appNestingPower.tempPowerNest = new PowerNest2();
            if (!clsInit.appNestingPower.AddPart(clsNesting.Parts))
              return;
            clsInit.appNestingPower.AddSheet(clsNesting.Sheets);
            this.NestedResult = new buNestedResult();
            GC.Collect();
            if (!clsInit.appNestingPower.Execute((double) clsNesting.ParNest.Runtime.MaxNestingTimeSec))
              return;
            if (clsItem.FrmNestOnlineCalc.IsDisposed)
              clsItem.FrmNestOnlineCalc = new F_NestOnlineCalc();
            if (clsNesting.ParNest.Settings.NestExecutionByThread)
            {
              clsItem.FrmNestOnlineCalc.btn_send.Enabled = false;
              clsItem.FrmNestOnlineCalc.btn_preview.Enabled = false;
              clsItem.FrmNestOnlineCalc.progress_execution.Maximum = 100;
              clsItem.FrmNestOnlineCalc.SettingsPar = new buNestingVar(clsNesting.ParNest);
              clsItem.FrmNestOnlineCalc.Init();
              int num4 = (int) clsItem.FrmNestOnlineCalc.ShowDialog();
              clsNesting.ParNest = new buNestingVar(clsItem.FrmNestOnlineCalc.SettingsPar);
              clsFiles.SaveParameter();
            }
            else
            {
              clsItem.FrmNestOnlineCalc.SettingsPar = new buNestingVar(clsNesting.ParNest);
              clsItem.FrmNestOnlineCalc.Init(false);
              int num5 = (int) clsItem.FrmNestOnlineCalc.ShowDialog();
              clsNesting.ParNest = new buNestingVar(clsItem.FrmNestOnlineCalc.SettingsPar);
              clsFiles.SaveParameter();
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdExecutePanel()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      else
        clsInit.appPanelCut.cmdNestingExecute();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdFinishPartAdd()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        for (int Index = ccVars.Pages.Count - 1; Index >= 0; --Index)
          clsInit.appCommand.PageClose(Index);
        clsInit.appCommand.cmdFileNewPage();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdGetOldNestedResult()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        List<string> Files = new List<string>();
        buFile5.GetFilesInDirectory(AppPath.Base + "\\NestingTemps", "bunesting", ref Files);
        clsItem.FrmOldNestedResult.Settings = new buNestingVar(clsNesting.ParNest);
        clsItem.FrmOldNestedResult.NestedResultList.Clear();
        for (int index = 0; index <= Files.Count - 1; ++index)
        {
          string withoutExtension = buFile5.getFileNameWithoutExtension(Files[index]);
          clsItem.FrmOldNestedResult.NestedResultList.Add(withoutExtension);
        }
        clsItem.FrmOldNestedResult.FileExtension = "bunesting";
        clsItem.FrmOldNestedResult.JobFolder = AppPath.Base + "\\NestingTemps";
        clsItem.FrmOldNestedResult.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsItem.FrmOldNestedResult.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsItem.FrmOldNestedResult.Init();
        int num = (int) clsItem.FrmOldNestedResult.ShowDialog();
        if (clsItem.FrmOldNestedResult.PropertiesForm.Result != DialogResult.OK)
          return;
        clsNesting.ParNest.Runtime = new buNestingRuntime(clsItem.FrmOldNestedResult.Settings.Runtime);
        string FileName = $"{AppPath.Base}\\NestingTemps\\{clsItem.FrmOldNestedResult.selectedItem}.bunesting";
        buFile5.bunesting bunesting = new buFile5.bunesting();
        buNestedResult Result = new buNestedResult();
        List<buNestingPart> Parts = new List<buNestingPart>();
        List<buNestingSheet> Sheets = new List<buNestingSheet>();
        bunesting.OpenNesting(FileName, ref Parts, ref Sheets, ref Result);
        if (clsNesting.ParNest.Runtime.OldResultImportNestingParts & clsNesting.ParNest.Runtime.OldResultImportNestingClearParts && Parts.Count > 0)
          clsNesting.Parts.Clear();
        if (clsNesting.ParNest.Runtime.OldResultImportNestingSheets & clsNesting.ParNest.Runtime.OldResultImportNestingClearSheets && Sheets.Count > 0)
          clsNesting.Sheets.Clear();
        if (clsNesting.ParNest.Runtime.OldResultImportNestingParts)
        {
          for (int index = 0; index <= Parts.Count - 1; ++index)
            clsNesting.Parts.Add(new buNestingPart(Parts[index]));
        }
        if (clsNesting.ParNest.Runtime.OldResultImportNestingSheets)
        {
          for (int index = 0; index <= Sheets.Count - 1; ++index)
            clsNesting.Sheets.Add(new buNestingSheet(Sheets[index]));
        }
        if (clsNesting.ParNest.Runtime.OldResultLocation == nestOldResultPosition.ToJob)
          this.doAddToAllNestedResult(Result);
        else
          this.doDrawAllNesting(Result, -1, -1, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, true, false);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdPreviewPressed(object Result)
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    }
    else
    {
      if (clsItem.FrmPreview == null)
      {
        clsItem.FrmPreview = new F_Preview();
        clsInit.cVector5.CreateModelControl(ref clsItem.FrmPreview.viewportLayout, clsVar.UnlockKey, new CreateModelProperties()
        {
          CoordinateSystemIconVisible = false,
          ViewCubeIconVisible = false,
          OrigineCaptionVisible = false,
          ToolBorVisible = false
        });
      }
      clsItem.FrmPreview.viewportLayout.Entities.Clear();
      int index = 0;
      int SheetIndex = -1;
      int PartIndex = -1;
      if (Result.GetType() == typeof (string))
      {
        string[] strArray = Result.ToString().Split('-');
        if (strArray != null)
        {
          if (strArray.Length == 1 && buNumeric5.IsNumeric(strArray[0]))
            index = Convert.ToInt32(strArray[0]);
          if (strArray.Length == 2)
          {
            if (buNumeric5.IsNumeric(strArray[0]))
              index = Convert.ToInt32(strArray[0]);
            if (buNumeric5.IsNumeric(strArray[1]))
              SheetIndex = Convert.ToInt32(strArray[1]);
          }
          if (strArray.Length == 3)
          {
            index = Convert.ToInt32(strArray[0]);
            SheetIndex = Convert.ToInt32(strArray[1]);
            PartIndex = Convert.ToInt32(strArray[2]);
          }
        }
        if (index >= 0 & index <= clsPowerNest.storedNestedResult.Count - 1)
        {
          buNestedResult Result1 = new buNestedResult();
          clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[index], ref Result1);
          this.doDrawAllNesting(Result1, SheetIndex, PartIndex, clsItem.FrmPreview.viewportLayout, true, true);
        }
      }
      else if (Result.GetType() == typeof (buNestedResult))
        this.doDrawAllNesting((buNestedResult) Result, SheetIndex, PartIndex, clsItem.FrmPreview.viewportLayout, true, true);
      clsItem.FrmPreview.Init(viewType.Top, true, false, false, false, false, false);
      clsItem.FrmPreview.Show();
    }
  }

  public void cmdOldNestingPreviewPressed(object Result)
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    }
    else
    {
      if (clsItem.FrmPreview == null)
      {
        clsItem.FrmPreview = new F_Preview();
        clsInit.cVector5.CreateModelControl(ref clsItem.FrmPreview.viewportLayout, clsVar.UnlockKey, new CreateModelProperties()
        {
          CoordinateSystemIconVisible = false,
          ViewCubeIconVisible = false,
          OrigineCaptionVisible = false,
          ToolBorVisible = false
        });
      }
      clsItem.FrmPreview.viewportLayout.Entities.Clear();
      buFile5.bunesting bunesting = new buFile5.bunesting();
      buNestedResult Result1 = new buNestedResult();
      List<buNestingPart> Parts = new List<buNestingPart>();
      List<buNestingSheet> Sheets = new List<buNestingSheet>();
      if (!new FileInfo((string) Result).Exists)
        return;
      bunesting.OpenNesting((string) Result, ref Parts, ref Sheets, ref Result1);
      this.doDrawAllNesting(Result1, -1, -1, clsItem.FrmPreview.viewportLayout, true, true);
      clsItem.FrmPreview.Init(viewType.Top, true, false, false, false, false, false);
      clsItem.FrmPreview.Show();
    }
  }

  public void cmdStopNestingPressed()
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    else
      clsPowerNest.bStop = true;
  }

  public void cmdNesitngPageClosed() => clsInit.appNestingPower.DisposeNesting();

  public void cmdNestResultSendPressed(object Result)
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    }
    else
    {
      if (Result != null)
      {
        if (((buNestedResultSentEventArg) Result).SendToDraw == nestResultSendType.Draw)
        {
          if (((buNestedResultSentEventArg) Result).IndexResult >= 0 & ((buNestedResultSentEventArg) Result).IndexResult <= clsPowerNest.storedNestedResult.Count - 1)
          {
            buNestedResult Result1 = new buNestedResult();
            clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[((buNestedResultSentEventArg) Result).IndexResult], ref Result1);
            this.doDrawAllNesting(Result1, ((buNestedResultSentEventArg) Result).IndexSheet, ((buNestedResultSentEventArg) Result).IndexPart, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, true, true);
            if (clsNesting.ParNest.Settings.DeleteNestedPartAfterNesting)
            {
              for (int index1 = 0; index1 <= Result1.NestedResultSheets.Count - 1; ++index1)
              {
                for (int index2 = 0; index2 <= Result1.NestedResultSheets[index1].Parts.Count - 1; ++index2)
                {
                  for (int index3 = 0; index3 <= clsNesting.Parts.Count - 1; ++index3)
                  {
                    if (clsNesting.Parts[index3].ID == Result1.NestedResultSheets[index1].Parts[index2].ID)
                    {
                      clsNesting.Parts[index3].Selected = true;
                      index3 = clsNesting.Parts.Count;
                    }
                  }
                }
              }
              for (int index = clsNesting.Parts.Count - 1; index >= 0; --index)
              {
                if (clsNesting.Parts[index].Selected)
                  clsNesting.Parts.RemoveAt(index);
              }
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\NestingTemps");
            if (!directoryInfo.Exists)
              Directory.CreateDirectory(AppPath.Base + "\\NestingTemps");
            clsNesting.ParNest.Runtime.LastNestedProject = $"{directoryInfo.FullName}\\{Result1.JobName}.bunesting";
            new buFile5.bunesting().SaveNesting(clsNesting.ParNest.Runtime.LastNestedProject, clsNesting.Parts, clsNesting.Sheets, Result1, clsNesting.ParNest);
          }
        }
        else if (((buNestedResultSentEventArg) Result).SendToDraw == nestResultSendType.Job)
        {
          if (((buNestedResultSentEventArg) Result).IndexResult >= 0 & ((buNestedResultSentEventArg) Result).IndexResult <= clsPowerNest.storedNestedResult.Count - 1)
          {
            buNestedResult Result2 = new buNestedResult();
            clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[((buNestedResultSentEventArg) Result).IndexResult], ref Result2);
            this.doAddToAllNestedResult(Result2);
            if (clsNesting.ParNest.Settings.DeleteNestedPartAfterNesting)
            {
              for (int index4 = 0; index4 <= Result2.NestedResultSheets.Count - 1; ++index4)
              {
                for (int index5 = 0; index5 <= Result2.NestedResultSheets[index4].Parts.Count - 1; ++index5)
                {
                  for (int index6 = 0; index6 <= clsNesting.Parts.Count - 1; ++index6)
                  {
                    if (clsNesting.Parts[index6].ID == Result2.NestedResultSheets[index4].Parts[index5].ID)
                    {
                      clsNesting.Parts[index6].Selected = true;
                      index6 = clsNesting.Parts.Count;
                    }
                  }
                }
              }
              for (int index = clsNesting.Parts.Count - 1; index >= 0; --index)
              {
                if (clsNesting.Parts[index].Selected)
                  clsNesting.Parts.RemoveAt(index);
              }
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\NestingTemps");
            if (!directoryInfo.Exists)
              Directory.CreateDirectory(AppPath.Base + "\\NestingTemps");
            clsNesting.ParNest.Runtime.LastNestedProject = $"{directoryInfo.FullName}\\{Result2.JobName}.bunesting";
            new buFile5.bunesting().SaveNesting(clsNesting.ParNest.Runtime.LastNestedProject, clsNesting.Parts, clsNesting.Sheets, Result2, clsNesting.ParNest);
          }
        }
        else if (((buNestedResultSentEventArg) Result).SendToDraw == nestResultSendType.File && ((buNestedResultSentEventArg) Result).IndexResult >= 0 & ((buNestedResultSentEventArg) Result).IndexResult <= clsPowerNest.storedNestedResult.Count - 1)
        {
          buNestedResult Result3 = new buNestedResult();
          clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[((buNestedResultSentEventArg) Result).IndexResult], ref Result3);
          this.doSaveAllNesting(Result3, ((buNestedResultSentEventArg) Result).IndexSheet, ((buNestedResultSentEventArg) Result).IndexPart, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, true);
          if (clsNesting.ParNest.Settings.DeleteNestedPartAfterNesting)
          {
            for (int index7 = 0; index7 <= Result3.NestedResultSheets.Count - 1; ++index7)
            {
              for (int index8 = 0; index8 <= Result3.NestedResultSheets[index7].Parts.Count - 1; ++index8)
              {
                for (int index9 = 0; index9 <= clsNesting.Parts.Count - 1; ++index9)
                {
                  if (clsNesting.Parts[index9].ID == Result3.NestedResultSheets[index7].Parts[index8].ID)
                  {
                    clsNesting.Parts[index9].Selected = true;
                    index9 = clsNesting.Parts.Count;
                  }
                }
              }
            }
            for (int index = clsNesting.Parts.Count - 1; index >= 0; --index)
            {
              if (clsNesting.Parts[index].Selected)
                clsNesting.Parts.RemoveAt(index);
            }
          }
          DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\NestingTemps");
          if (!directoryInfo.Exists)
            Directory.CreateDirectory(AppPath.Base + "\\NestingTemps");
          clsNesting.ParNest.Runtime.LastNestedProject = $"{directoryInfo.FullName}\\{Result3.JobName}.bunesting";
          new buFile5.bunesting().SaveNesting(clsNesting.ParNest.Runtime.LastNestedProject, clsNesting.Parts, clsNesting.Sheets, Result3, clsNesting.ParNest);
        }
        clsNesting.ParNest.Settings = new buNestingSettings(clsItem.FrmNestOnlineCalc.SettingsPar.Settings);
        clsFiles.SaveParameter();
      }
      clsInit.appNestingPower.DisposeNesting();
    }
  }

  public void cmdResultCommand(object Data, object Command)
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    }
    else
    {
      if (Command.ToString() == "ShowFolder")
        Process.Start(clsVar.varInterface.pathNestingOutputs);
      if (Command.ToString() == "ShowSheetPart")
        this.cmdShowSheetPage(false);
      if (Command.ToString() == "SendParts")
      {
        List<buNestingPart> buNestingPartList1 = new List<buNestingPart>();
        List<buNestingPart> buNestingPartList2 = (List<buNestingPart>) Data;
        for (int index = 0; index <= buNestingPartList2.Count - 1; ++index)
          clsNesting.Parts.Add(new buNestingPart(buNestingPartList2[index]));
        this.cmdShowSheetPage(false);
      }
      if (Command.ToString() == "SendSheets")
      {
        List<buNestingSheet> buNestingSheetList1 = new List<buNestingSheet>();
        List<buNestingSheet> buNestingSheetList2 = (List<buNestingSheet>) Data;
        for (int index = 0; index <= buNestingSheetList2.Count - 1; ++index)
          clsNesting.Sheets.Add(new buNestingSheet(buNestingSheetList2[index]));
        this.cmdShowSheetPage(true);
      }
      if (!(Command.ToString() == "CreateRemnant"))
        return;
      List<buNestedSheet> buNestedSheetList = Data as List<buNestedSheet>;
      for (int index1 = 0; index1 <= buNestedSheetList.Count - 1; ++index1)
      {
        if ((buNestedSheetList[index1].RemnantSheets == null ? 0 : (buNestedSheetList[index1].RemnantSheets.Count > 0 ? 1 : 0)) != 0)
        {
          for (int index2 = 0; index2 <= buNestedSheetList[index1].RemnantSheets.Count - 1; ++index2)
          {
            buNestingSheet Sheet = new buNestingSheet();
            clsInit.cNesting.SheetRectangle(buNestedSheetList[index1].RemnantSheets[index2].Width, buNestedSheetList[index1].RemnantSheets[index2].Height, ref Sheet);
            clsInit.cVector5.SetColorEntity(clsNesting.ParNest.Draw.SheetEntityColor, ref Sheet.EntitiesGroup.Outside.Entities);
            clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref Sheet.ID);
            Sheet.MaterialData.Width = buNestedSheetList[index1].RemnantSheets[index2].Width;
            Sheet.MaterialData.Height = buNestedSheetList[index1].RemnantSheets[index2].Height;
            Sheet.MaterialData.Quantity = 1;
            Sheet.Remain = 1;
            Sheet.Used = 0;
            Sheet.MaterialData.Name = $"{buLangTranslate.preDef.Remnant}_{buNestedSheetList[index1].Name}";
            clsNesting.Sheets.Add(Sheet);
          }
        }
      }
      this.cmdShowSheetPage(true);
    }
  }

  public void cmdResultDraw(object Result)
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    }
    else
    {
      if (Result == null)
        return;
      clsItem.FrmNestedResult.viewport.Entities.Clear();
      this.doDrawAllNesting(((buNestedResultSentEventArg) Result).NestResult, ((buNestedResultSentEventArg) Result).IndexSheet, ((buNestedResultSentEventArg) Result).IndexPart, clsItem.FrmNestedResult.viewport, true, true);
    }
  }

  public void cmdResultUpdate(object RuntimePar)
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    }
    else
    {
      if (RuntimePar == null)
        return;
      clsNesting.ParNest.Runtime = new buNestingRuntime((buNestingRuntime) RuntimePar);
      this.SaveNestingFile();
    }
  }

  public void cmdNestResultApplied(object Setting)
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    }
    else
    {
      if (Setting == null)
        return;
      clsNesting.ParNest.Settings = new buNestingSettings((buNestingSettings) Setting);
      clsFiles.SaveParameter();
    }
  }

  public void cmdShowNestedPage()
  {
    if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
    else if (buNestingCalc.NestedAllResults.Count >= 0)
    {
      clsItem.FrmNestedResult.NestingResultSettings = new buNestingResultSettings(clsNesting.ParNest.ResultSettings);
      clsItem.FrmNestedResult.RunParameter = new buNestingRuntime(clsNesting.ParNest.Runtime);
      clsItem.FrmNestedResult.NestParameters = new buNestingVar(clsNesting.ParNest);
      if (clsNesting.ParNest.Runtime.ShowNestResultPageAsFullScreen)
        clsItem.FrmNestedResult.WindowState = FormWindowState.Maximized;
      clsItem.FrmNestedResult.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmNestedResult.Init();
      clsItem.FrmNestedResult.Show();
      clsItem.FrmNestedResult.Focus();
    }
    else
      buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoNestedResultToShow);
  }

  public void cmdFindFixDrawings()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        F_AnalyseSettings fAnalyseSettings = new F_AnalyseSettings();
        fAnalyseSettings.Settings = new AnalyseEntitiesSetting(clsNesting.ParNest.AnalyseSettings);
        fAnalyseSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
        fAnalyseSettings.Properties.FormPosition = FormStartPosition.CenterScreen;
        fAnalyseSettings.Init();
        int num = (int) fAnalyseSettings.ShowDialog();
        if (fAnalyseSettings.Properties.Result != DialogResult.OK)
          return;
        clsNesting.ParNest.AnalyseSettings = new AnalyseEntitiesSetting(fAnalyseSettings.Settings);
        this.doFindAndFixParts();
        this.SaveNestingFile();
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void LoadLanguage()
  {
    List<string> stringList = new List<string>();
    FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buNesting.lng") : new FileInfo(AppPath.Language + "\\buNesting.lng");
    if (fileInfo.Exists)
    {
      List<string> StringList = new List<string>();
      buFile.OpenFromFile(fileInfo.FullName, ref StringList);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddPart>", "</F_AddPart>", StringList), clsVar.varRuntime.Language, ref F_NestPartAdd.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddRectPart>", "</F_AddRectPart>", StringList), clsVar.varRuntime.Language, ref F_NestRectPartAdd.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddSheet>", "</F_AddSheet>", StringList), clsVar.varRuntime.Language, ref F_NestSheetAdd.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddSheetShape>", "</F_AddSheetShape>", StringList), clsVar.varRuntime.Language, ref F_NestSheetShapeAdd.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SheetParts>", "</F_SheetParts>", StringList), clsVar.varRuntime.Language, ref F_NestSheetPartList.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestExecute>", "</F_NestExecute>", StringList), clsVar.varRuntime.Language, ref F_NestExecute.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestedResult>", "</F_NestedResult>", StringList), clsVar.varRuntime.Language, ref F_NestedResults.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestingCalculation>", "</F_NestingCalculation>", StringList), clsVar.varRuntime.Language, ref F_NestOnlineCalc.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestOldResult>", "</F_NestOldResult>", StringList), clsVar.varRuntime.Language, ref F_NestOldResult.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Main>", "</F_Main>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingCaptions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingPartSettings>", "</nestingPartSettings>", StringList), clsVar.varRuntime.Language, ref buNestingPartSettings.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingSheetSettings>", "</nestingSheetSettings>", StringList), clsVar.varRuntime.Language, ref buNestingSheetSettings.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingResultSettings>", "</nestingResultSettings>", StringList), clsVar.varRuntime.Language, ref buNestingResultSettings.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingSettings>", "</nestingSettings>", StringList), clsVar.varRuntime.Language, ref buNestingSettings.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingStatus);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingMessage);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingCaptions);
      StringList.Clear();
    }
    else
    {
      buLog.addLog("Nesting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Nesting Language File Missing");
    }
  }

  public void SaveNestingFile()
  {
    string str = AppPath.Settings + "\\Nesting";
    if (AppBool.MachineMode)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Nesting");
      if (directoryInfo.Exists)
        str = directoryInfo.FullName;
    }
    string FileName = str + "\\NestingSet.prm";
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "   Nesting Settings");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "<NestingSettings>");
    StringList.AddRange((ICollection) clsNesting.ParNest.AddMaterial.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.AddPart.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.MaterailSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.PartSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.ResultSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.Settings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.Draw.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.ProgramSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.Runtime.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.AddRange((ICollection) clsNesting.ParNest.AnalyseSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.Add((object) "</NestingSettings>");
    StringList.Add((object) " ");
    StringList.Add((object) "<NestingPartsAndSheets>");
    StringList.AddRange((ICollection) buNestingSheet.ToDef(clsNesting.Sheets, 2).ToArray());
    StringList.Add((object) " ");
    StringList.AddRange((ICollection) buNestingPart.ToDef(clsNesting.Parts, 2).ToArray());
    StringList.Add((object) "</NestingPartsAndSheets>");
    buFile.SaveToFile(StringList, FileName);
    buLog.addLog("Nesting Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
  }

  public void OpenNestingFile()
  {
    string str = AppPath.Settings + "\\Nesting";
    if (AppBool.MachineMode)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Nesting");
      if (directoryInfo.Exists)
        str = directoryInfo.FullName;
    }
    FileInfo fileInfo = new FileInfo(str + "\\NestingSet.prm");
    if (fileInfo.Exists)
    {
      ArrayList StringList = new ArrayList();
      buFile.OpenFromFile(fileInfo.FullName, ref StringList);
      try
      {
        ArrayList CalcList1 = new ArrayList();
        buString.ListToSpecificList("<NestingSettings>", "</NestingSettings>", true, StringList, ref CalcList1);
        if (CalcList1.Count > 0)
        {
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.AddMaterial);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.AddPart);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.MaterailSettings);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.PartSettings);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.ResultSettings);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.Settings);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.Draw);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.ProgramSettings);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.Runtime);
          buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsNesting.ParNest.AnalyseSettings);
          buLog.addLog("Nesting Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          buLog.addLog("Profile Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        }
        else
        {
          buLog.addLog("<NestingSettings> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buString.MessageBoxError("<NestingSettings> Line Missing");
        }
        CalcList1.Clear();
        ArrayList CalcList2 = new ArrayList();
        buString.ListToSpecificList("<NestingSheets>", "</NestingSheets>", true, StringList, ref CalcList2);
        buNestingSheet.Decode(CalcList2, ref clsNesting.Sheets);
        CalcList2.Clear();
        ArrayList CalcList3 = new ArrayList();
        buString.ListToSpecificList("<NestingParts>", "</NestingParts>", true, StringList, ref CalcList3);
        buNestingPart.Decode(StringList, ref clsNesting.Parts);
        CalcList3.Clear();
        ArrayList CalcList4 = new ArrayList();
        buString.ListToSpecificList("<NestingMaterals>", "</NestingMaterals>", true, StringList, ref CalcList4);
        buNestingMaterials.Decode(StringList, ref clsNesting.Materials);
        CalcList4.Clear();
        StringList.Clear();
        if (!clsVar.appModes_0.CutterMode.Enable)
          return;
        clsNesting.ParNest.ProgramSettings.isCutter = true;
      }
      catch (Exception ex)
      {
        buLog.addLog("Nesting Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Nesting Settings Decoder Error");
      }
    }
    else
    {
      if (!clsVar.appModes_0.NestingMode.Enable)
        return;
      buLog.addLog("Nesting Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Nesting Settings File Missing");
    }
  }

  public bool AddPartFromEntities(buEntitiesGroup entGroup, bool isSheet, bool ShowDialog = true)
  {
    List<int> intList = new List<int>();
    ccVars.UndoDont = true;
    bool flag;
    if (!clsInit.cVector5.isEntitiesClosed(entGroup.Outside.Entities))
    {
      flag = false;
    }
    else
    {
      if (clsVar.appModes_0.CutterMode.Enable & clsCutter.varCutterSettings.NotchOnContour)
      {
        List<Entity> entityList = new List<Entity>();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
          {
            CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
            if (entityData.typeDefination == entityTypeDefination.Notch && entityData.infoString == "VNotch")
            {
              intList.Add(index);
              entityList.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]));
            }
          }
        }
        List<List<Entity>> entityListList = new List<List<Entity>>();
      }
      Point3D MinPoint1 = new Point3D();
      Point3D point3D1 = new Point3D();
      Point3D MaxPoint1 = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(entGroup, ref MinPoint1, ref MaxPoint1);
      clsInit.cVector5.Move(-MinPoint1.X, -MinPoint1.Y, 0.0, ref entGroup, clsVar.varEntities.RegenDeviation);
      if (!isSheet)
      {
        buNestingPart data = new buNestingPart();
        buNestingPart buNestingPart1 = new buNestingPart();
        data.PartData.Width = MaxPoint1.X - MinPoint1.X;
        data.PartData.Height = MaxPoint1.Y - MinPoint1.Y;
        clsNesting.ParNest.AddPart.Quantity = 1;
        if (clsNesting.ParNest.PartSettings.AddAutoPartQuantityIfAvailable && (entGroup.Text == null ? 0 : (entGroup.Text.Entities.Count > 0 ? 1 : 0)) != 0)
          clsInit.cNesting.GetPartNameAndQuantity(entGroup.Text.Entities, clsNesting.ParNest, ref clsNesting.ParNest.AddPart.Quantity, ref clsNesting.ParNest.AddPart.Name);
        Entity entSurface = (Entity) null;
        if (clsNesting.ParNest.ProgramSettings.View3D)
          clsInit.cVector5.surfaceFromOutterInner(entGroup, 0.2, ref entSurface);
        if (entSurface != null)
        {
          entGroup.Solid = new buEntityList();
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(entSurface, ref copiedEntity);
          if (copiedEntity != null)
            entGroup.Solid.Entities.Add(copiedEntity);
        }
        data.EntitiesGroup = new buEntitiesGroup(entGroup);
        if (clsVar.UserMode.CompositeMode.Enable)
        {
          if (ShowDialog)
          {
            clsItem.FrmNestPartAddV2.Part = new buNestingPart(data);
            clsItem.FrmNestPartAddV2.Settings = new buNestingVar(clsNesting.ParNest);
            clsItem.FrmNestPartAddV2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
            clsItem.FrmNestPartAddV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
            clsItem.FrmNestPartAddV2.Init();
            int num = (int) clsItem.FrmNestPartAddV2.ShowDialog();
          }
          if (clsItem.FrmNestPartAddV2.PropertiesForm.Result == DialogResult.OK | !ShowDialog)
          {
            for (int index = 0; index <= intList.Count - 1; ++index)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(intList[index]);
            if (ShowDialog)
              clsNesting.ParNest = new buNestingVar(clsItem.FrmNestPartAddV2.Settings);
            Point3D MinPoint2 = new Point3D();
            Point3D MaxPoint2 = new Point3D();
            clsInit.cVector5.BoxSizeCalculate(data.EntitiesGroup, ref MinPoint2, ref MaxPoint2);
            data.UseInnersAsHolePartInPart = false;
            data.PartData.Thickness = clsNesting.ParNest.AddPart.Thickness;
            data.PartData.Quantity = clsNesting.ParNest.AddPart.Quantity;
            data.Remain = clsNesting.ParNest.AddPart.Quantity;
            data.PartData.Priority = clsNesting.ParNest.AddPart.Priority;
            data.PartData.Mirror = clsNesting.ParNest.AddPart.MirrorEnable;
            if (ShowDialog)
              data.PartData.Name = clsItem.FrmNestPartAddV2.txt_name.Text;
            data.PartData.Rotation = clsNesting.ParNest.AddPart.Rotation;
            data.Type = nestMaterialType.Irregular;
            clsInit.cNesting.GetAvailableNestingPartID(clsNesting.Parts, ref data.ID);
            clsNesting.Parts.Add(data);
          }
          else
          {
            flag = false;
            goto label_65;
          }
        }
        else
        {
          if (ShowDialog)
          {
            clsItem.FrmNestPartAdd.Part = new buNestingPart(data);
            clsItem.FrmNestPartAdd.Settings = new buNestingVar(clsNesting.ParNest);
            clsItem.FrmNestPartAdd.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
            clsItem.FrmNestPartAdd.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
            clsItem.FrmNestPartAdd.Init();
            int num = (int) clsItem.FrmNestPartAdd.ShowDialog();
          }
          if (clsItem.FrmNestPartAdd.PropertiesForm.Result == DialogResult.OK | !ShowDialog)
          {
            for (int index = 0; index <= intList.Count - 1; ++index)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(intList[index]);
            if (ShowDialog)
              clsNesting.ParNest = new buNestingVar(clsItem.FrmNestPartAdd.Settings);
            Point3D MinPoint3 = new Point3D();
            Point3D MaxPoint3 = new Point3D();
            clsInit.cVector5.BoxSizeCalculate(data.EntitiesGroup, ref MinPoint3, ref MaxPoint3);
            data.PartData.Thickness = clsNesting.ParNest.AddPart.Thickness;
            data.PartData.Quantity = clsNesting.ParNest.AddPart.Quantity;
            data.Remain = clsNesting.ParNest.AddPart.Quantity;
            data.PartData.Priority = clsNesting.ParNest.AddPart.Priority;
            if (ShowDialog)
              data.PartData.Name = clsItem.FrmNestPartAdd.txt_name.Text;
            data.PartData.Rotation = clsNesting.ParNest.AddPart.Rotation;
            data.Type = nestMaterialType.Irregular;
            data.UseInnersAsHolePartInPart = clsNesting.ParNest.PartSettings.PartInPart;
            if (entGroup.Text != null)
            {
              Point3D point3D2 = new Point3D();
              Point3D point3D3 = new Point3D();
            }
            clsInit.cNesting.GetAvailableNestingPartID(clsNesting.Parts, ref data.ID);
            clsNesting.Parts.Add(data);
            if (clsNesting.ParNest.AddPart.MirrorQuantity > 0)
            {
              buNestingPart buNestingPart2 = new buNestingPart(data)
              {
                PartData = {
                  Quantity = clsNesting.ParNest.AddPart.MirrorQuantity
                },
                Remain = clsNesting.ParNest.AddPart.MirrorQuantity
              };
              buNestingPart2.PartData.Name = $"{data.PartData.Name}- [{buLangTranslate.preDef.Mirror}]";
              Point3D MirrorPoint = new Point3D(1.0, 0.0, 0.0);
              if (clsNesting.ParNest.AddPart.MirrorAxis == DirectionXandY.YDirection)
                MirrorPoint = new Point3D(0.0, 1.0, 0.0);
              clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buNestingPart2.EntitiesGroup.Outside.Entities);
              clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buNestingPart2.EntitiesGroup.Outside.Points);
              for (int index = 0; index <= buNestingPart2.EntitiesGroup.Inside.Count - 1; ++index)
              {
                buEntityList buEntityList = buNestingPart2.EntitiesGroup.Inside[index];
                clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buEntityList.Entities);
                clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buEntityList.Points);
              }
              for (int index = 0; index <= buNestingPart2.EntitiesGroup.OpenEntities.Count - 1; ++index)
              {
                buEntityList openEntity = buNestingPart2.EntitiesGroup.OpenEntities[index];
                clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref openEntity.Entities);
                clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref openEntity.Points);
              }
              clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buNestingPart2.EntitiesGroup.Text.Entities);
              clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buNestingPart2.EntitiesGroup.Text.Points);
              clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buNestingPart2.EntitiesGroup.Solid.Entities);
              clsInit.cVector5.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref buNestingPart2.EntitiesGroup.Solid.Points);
              clsInit.cNesting.GetAvailableNestingPartID(clsNesting.Parts, ref buNestingPart2.ID);
              clsNesting.Parts.Add(buNestingPart2);
            }
          }
          else
          {
            flag = false;
            goto label_65;
          }
        }
      }
      else
      {
        buNestingSheet data = new buNestingSheet();
        data.MaterialData.Width = MaxPoint1.X - MinPoint1.X;
        data.MaterialData.Height = MaxPoint1.Y - MinPoint1.Y;
        Entity entSurface = (Entity) null;
        if (clsNesting.ParNest.ProgramSettings.View3D)
          clsInit.cVector5.surfaceFromOutterInner(entGroup, 0.2, ref entSurface);
        if (entSurface != null)
        {
          entGroup.Solid = new buEntityList();
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(entSurface, ref copiedEntity);
          if (copiedEntity != null)
            entGroup.Solid.Entities.Add(copiedEntity);
        }
        data.EntitiesGroup = new buEntitiesGroup(entGroup);
        clsItem.FrmNestSheetShapeAdd.Sheet = new buNestingSheet(data);
        clsItem.FrmNestSheetShapeAdd.Settings = new buNestingVar(clsNesting.ParNest);
        if (clsNesting.ParNest.PartSettings.AddAutoPartQuantityIfAvailable && (entGroup.Text == null ? 0 : (entGroup.Text.Entities.Count > 0 ? 1 : 0)) != 0)
          clsInit.cNesting.GetPartNameAndQuantity(entGroup.Text.Entities, clsNesting.ParNest, ref clsNesting.ParNest.AddMaterial.Quantity, ref clsNesting.ParNest.AddMaterial.Name);
        clsItem.FrmNestSheetShapeAdd.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        clsItem.FrmNestSheetShapeAdd.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsItem.FrmNestSheetShapeAdd.Init();
        int num = (int) clsItem.FrmNestSheetShapeAdd.ShowDialog();
        if (clsItem.FrmNestSheetShapeAdd.PropertiesForm.Result == DialogResult.OK)
        {
          clsNesting.ParNest = new buNestingVar(clsItem.FrmNestSheetShapeAdd.Settings);
          data.MaterialData.Thickness = clsNesting.ParNest.AddMaterial.Thickness;
          data.MaterialData.Quantity = clsNesting.ParNest.AddMaterial.Quantity;
          data.Remain = clsNesting.ParNest.AddMaterial.Quantity;
          data.MaterialData.Name = clsItem.FrmNestSheetShapeAdd.txt_name.Text;
          data.Type = nestMaterialType.Irregular;
          clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref data.ID);
          clsNesting.Sheets.Add(data);
        }
        else
        {
          flag = false;
          goto label_65;
        }
      }
      flag = true;
    }
label_65:
    return flag;
  }

  public void AddSheetFromEntities(buEntitiesGroup EntGroup, ref buNestingSheet Sheet)
  {
    Sheet.EntitiesGroup = new buEntitiesGroup(EntGroup);
    if (Sheet.EntitiesGroup.Outside.Entities.Count > 0 && Sheet.EntitiesGroup.Outside.Points == null)
    {
      Sheet.EntitiesGroup.Outside.Points = new List<Point3D>();
      clsInit.cVector5.EntitiesToPointsWithCamDirection(Sheet.EntitiesGroup.Outside.Entities, ref Sheet.EntitiesGroup.Outside.Points);
    }
    if (Sheet.EntitiesGroup.Inside != null)
    {
      for (int index = 0; index <= Sheet.EntitiesGroup.Inside.Count - 1; ++index)
      {
        if (Sheet.EntitiesGroup.Inside[index].Points == null)
        {
          Sheet.EntitiesGroup.Inside[index].Points = new List<Point3D>();
          if (Sheet.EntitiesGroup.Inside[index].Entities.Count > 0)
            clsInit.cVector5.EntitiesToPointsWithCamDirection(Sheet.EntitiesGroup.Inside[index].Entities, ref Sheet.EntitiesGroup.Inside[index].Points);
        }
      }
    }
    Entity entSurface = (Entity) null;
    if (clsNesting.ParNest.ProgramSettings.View3D)
      clsInit.cVector5.surfaceFromOutterInner(Sheet.EntitiesGroup, 0.2, ref entSurface);
    if (entSurface == null)
      return;
    Sheet.EntitiesGroup.Solid = new buEntityList();
    buEntity copiedEntity = (buEntity) null;
    buEntity.Copy(entSurface, ref copiedEntity);
    if (copiedEntity == null)
      return;
    Sheet.EntitiesGroup.Solid.Entities.Add(copiedEntity);
  }

  public void CreatePdf(buNestedResultEventArg NestResult, bool DoubleSheet = false)
  {
    XFont font1 = new XFont("Verdana", 20.0, XFontStyle.Bold);
    XFont font2 = new XFont("Verdana", 12.0);
    Design viewport = (Design) null;
    clsInit.cVector5.CreateModelControl(ref viewport, clsVar.UnlockKey, new CreateModelProperties()
    {
      BottomColor = Color.White,
      MiddleColor = Color.White,
      TopColor = Color.White,
      CoordinateSystemIconVisible = false,
      ViewCubeIconVisible = false,
      OrigineCaptionVisible = false,
      ToolBorVisible = false,
      Width = clsItem.FrmNestedResult.viewport.Width,
      Height = clsItem.FrmNestedResult.viewport.Height
    });
    viewport.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    PdfDocument pdfDocument = new PdfDocument();
    double num1 = 0.0;
    if (NestResult.SelectedSheet == -1)
    {
      PdfPage page1 = pdfDocument.AddPage();
      XGraphics xgraphics1 = XGraphics.FromPdfPage(page1);
      xgraphics1.DrawString(NestResult.nestedResult.JobName, font1, (XBrush) XBrushes.Black, new XRect(0.0, 10.0, page1.Width.Point, 20.0), XStringFormats.Center);
      viewport.Entities.Clear();
      this.doDrawAllNesting(NestResult.nestedResult, -1, -1, viewport, clsNesting.ParNest.ProgramSettings.View3D, true);
      viewport.SetView(viewType.Top, true, false);
      viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), true);
      Image image1 = Clipboard.GetImage();
      if (image1 != null)
      {
        double num2 = (double) image1.Width / (double) image1.Height;
        MemoryStream memoryStream = new MemoryStream();
        image1.Save((Stream) memoryStream, ImageFormat.Png);
        XImage image2 = XImage.FromStream((Stream) memoryStream);
        double width = page1.Width.Point - 40.0;
        double height = width / num2;
        xgraphics1.DrawImage(image2, new XRect(20.0, 40.0, width, height));
        num1 = 40.0 + height;
      }
      string RefString1 = buNestingCalc.NestedResultInfo(NestResult.nestedResult, clsNesting.ParNest.ProgramSettings);
      ArrayList Lines1 = new ArrayList();
      buString5.StringToArrayListByNewLine(RefString1, ref Lines1);
      for (int index = 0; index <= Lines1.Count - 1; ++index)
      {
        xgraphics1.DrawString(Lines1[index].ToString(), font2, (XBrush) XBrushes.Black, new XPoint(20.0, num1 + 20.0));
        num1 += 20.0;
      }
      if (DoubleSheet)
      {
        XFont font3 = new XFont("Verdana", 10.0);
        for (int index1 = 0; index1 <= NestResult.nestedResult.NestedResultSheets.Count - 1; index1 += 2)
        {
          PdfPage page2 = pdfDocument.AddPage();
          XGraphics xgraphics2 = XGraphics.FromPdfPage(page2);
          double num3 = 0.0;
          viewport.Entities.Clear();
          this.doDrawAllNesting(NestResult.nestedResult, index1, -1, viewport, clsNesting.ParNest.ProgramSettings.View3D, true);
          viewport.SetView(viewType.Top, true, false);
          Application.DoEvents();
          Thread.Sleep(20);
          viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), true);
          Image image3 = Clipboard.GetImage();
          Application.DoEvents();
          Thread.Sleep(20);
          if (image3 != null)
          {
            double num4 = (double) viewport.Width / (double) viewport.Height;
            MemoryStream memoryStream = new MemoryStream();
            image3.Save((Stream) memoryStream, ImageFormat.Png);
            XImage image4 = XImage.FromStream((Stream) memoryStream);
            double width = page2.Width.Point - 40.0;
            double height = width / num4;
            xgraphics2.DrawImage(image4, new XRect(20.0, -20.0, width, height));
            num3 = 40.0 + height;
          }
          string text1 = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], index1);
          xgraphics2.DrawString(text1, font1, (XBrush) XBrushes.Black, new XRect(0.0, 5.0, page2.Width.Point, 20.0), XStringFormats.Center);
          string RefString2 = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, index1, clsNesting.ParNest.ProgramSettings, 2);
          ArrayList Lines2 = new ArrayList();
          buString5.StringToArrayListByNewLine(RefString2, ref Lines2);
          for (int index2 = 0; index2 <= Lines2.Count - 1; ++index2)
            xgraphics2.DrawString(Lines2[index2].ToString(), font3, (XBrush) XBrushes.Black, new XPoint(20.0, (double) (310 + index2 * 20)));
          if (index1 + 1 <= NestResult.nestedResult.NestedResultSheets.Count - 1)
          {
            double num5 = 400.0;
            viewport.Entities.Clear();
            this.doDrawAllNesting(NestResult.nestedResult, index1 + 1, -1, viewport, true, true);
            viewport.SetView(viewType.Top, true, false);
            Application.DoEvents();
            Thread.Sleep(20);
            viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), true);
            Image image5 = Clipboard.GetImage();
            Application.DoEvents();
            Thread.Sleep(20);
            if (image5 != null)
            {
              double num6 = (double) viewport.Width / (double) viewport.Height;
              MemoryStream memoryStream = new MemoryStream();
              image5.Save((Stream) memoryStream, ImageFormat.Png);
              XImage image6 = XImage.FromStream((Stream) memoryStream);
              double width = page2.Width.Point - 40.0;
              double height = width / num6;
              xgraphics2.DrawImage(image6, new XRect(20.0, 380.0, width, height));
              num5 = 40.0 + height;
            }
            string text2 = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], index1 + 1);
            xgraphics2.DrawString(text2, font1, (XBrush) XBrushes.Black, new XRect(0.0, 405.0, page2.Width.Point, 20.0), XStringFormats.Center);
            string RefString3 = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, index1 + 1, clsNesting.ParNest.ProgramSettings, 2);
            Lines2 = new ArrayList();
            buString5.StringToArrayListByNewLine(RefString3, ref Lines2);
            for (int index3 = 0; index3 <= Lines2.Count - 1; ++index3)
            {
              xgraphics2.DrawString(Lines2[index3].ToString(), font3, (XBrush) XBrushes.Black, new XPoint(20.0, (double) (710 + index3 * 20)));
              num5 += 20.0;
            }
          }
        }
      }
      else
      {
        for (int index4 = 0; index4 <= NestResult.nestedResult.NestedResultSheets.Count - 1; ++index4)
        {
          double num7 = 0.0;
          viewport.Entities.Clear();
          this.doDrawAllNesting(NestResult.nestedResult, index4, -1, viewport, true, true);
          viewport.SetView(viewType.Top, true, false);
          viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), true);
          Image image7 = Clipboard.GetImage();
          PdfPage page3 = pdfDocument.AddPage();
          XGraphics xgraphics3 = XGraphics.FromPdfPage(page3);
          string str = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], index4);
          XGraphics xgraphics4 = xgraphics3;
          string text = str;
          XFont font4 = font1;
          XSolidBrush black = XBrushes.Black;
          XUnit width1 = page3.Width;
          XRect layoutRectangle = new XRect(0.0, 10.0, width1.Point, 20.0);
          XStringFormat center = XStringFormats.Center;
          xgraphics4.DrawString(text, font4, (XBrush) black, layoutRectangle, center);
          if (image7 != null)
          {
            double num8 = (double) viewport.Width / (double) viewport.Height;
            MemoryStream memoryStream = new MemoryStream();
            image7.Save((Stream) memoryStream, ImageFormat.Png);
            XImage image8 = XImage.FromStream((Stream) memoryStream);
            width1 = page3.Width;
            double width2 = width1.Point - 40.0;
            double height = width2 / num8;
            xgraphics3.DrawImage(image8, new XRect(20.0, 40.0, width2, height));
            num7 = 40.0 + height;
          }
          string RefString4 = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, index4, clsNesting.ParNest.ProgramSettings);
          ArrayList Lines3 = new ArrayList();
          buString5.StringToArrayListByNewLine(RefString4, ref Lines3);
          for (int index5 = 0; index5 <= Lines3.Count - 1; ++index5)
          {
            xgraphics3.DrawString(Lines3[index5].ToString(), font2, (XBrush) XBrushes.Black, new XPoint(20.0, num7 + 20.0));
            num7 += 20.0;
          }
        }
      }
    }
    else if (NestResult.SelectedSheet <= NestResult.nestedResult.NestedResultSheets.Count - 1)
    {
      double num9 = 0.0;
      viewport.Entities.Clear();
      this.doDrawAllNesting(NestResult.nestedResult, NestResult.SelectedSheet, -1, viewport, true, true);
      viewport.SetView(viewType.Top, true, false);
      viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), true);
      Image image9 = Clipboard.GetImage();
      PdfPage page = pdfDocument.AddPage();
      XGraphics xgraphics5 = XGraphics.FromPdfPage(page);
      string str = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], NestResult.SelectedSheet);
      XGraphics xgraphics6 = xgraphics5;
      string text = str;
      XFont font5 = font1;
      XSolidBrush black = XBrushes.Black;
      XUnit width3 = page.Width;
      XRect layoutRectangle = new XRect(0.0, 10.0, width3.Point, 20.0);
      XStringFormat center = XStringFormats.Center;
      xgraphics6.DrawString(text, font5, (XBrush) black, layoutRectangle, center);
      if (image9 != null)
      {
        double num10 = (double) viewport.Width / (double) viewport.Height;
        MemoryStream memoryStream = new MemoryStream();
        image9.Save((Stream) memoryStream, ImageFormat.Png);
        XImage image10 = XImage.FromStream((Stream) memoryStream);
        width3 = page.Width;
        double width4 = width3.Point - 40.0;
        double height = width4 / num10;
        xgraphics5.DrawImage(image10, new XRect(20.0, 40.0, width4, height));
        num9 = 40.0 + height;
      }
      string RefString = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, NestResult.SelectedSheet, clsNesting.ParNest.ProgramSettings);
      ArrayList Lines = new ArrayList();
      buString5.StringToArrayListByNewLine(RefString, ref Lines);
      for (int index = 0; index <= Lines.Count - 1; ++index)
      {
        xgraphics5.DrawString(Lines[index].ToString(), font2, (XBrush) XBrushes.Black, new XPoint(20.0, num9 + 20.0));
        num9 += 20.0;
      }
    }
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
    saveFileDialog.Filter = "Pdf File (*.pdf)|*.pdf";
    saveFileDialog.FilterIndex = 1;
    if (pdfDocument.PageCount <= 0 || saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    clsNesting.ParNest.Runtime.NestingResultPdfFile = NestResult.PdfFile;
    clsNesting.ParNest.Runtime.NestingResultDoCam = NestResult.DoCam;
    clsNesting.ParNest.Runtime.nestedResultCreateType = NestResult.ResultCreateType;
    clsNesting.ParNest.Runtime.nestedResultSheetType = NestResult.ResultSheetType;
    clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
    pdfDocument.Save(saveFileDialog.FileName);
    clsFiles.SaveParameter();
  }

  public void CreateDxf(buNestedResultEventArg NestResult, bool Draw = true)
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    if (Draw)
      this.doDrawAllNesting(NestResult.nestedResult, -1, -1, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, false, false);
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
    saveFileDialog.Filter = "Autocad Dxf File (*.dxf)|*.dxf";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
      clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
      clsInit.cVector5.SaveDxfFile(saveFileDialog.FileName, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad);
    }
    clsInit.appCommand.Reset();
  }

  public void CreateHpgl(buNestedResultEventArg NestResult)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
    saveFileDialog.Filter = "HPGL File (*.hpgl)|*.hpgl";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
      clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
      buFile5.HPGLFile hpglFile = new buFile5.HPGLFile();
      if (NestResult.SelectedSheet >= 0)
      {
        if (NestResult.SelectedSheet <= NestResult.nestedResult.NestedResultSheets.Count - 1)
        {
          List<List<Entity>> partEntities = new List<List<Entity>>();
          List<List<Entity>> innerEntities = new List<List<Entity>>();
          List<List<Entity>> auxEntities = new List<List<Entity>>();
          List<List<Entity>> copiedEnt = new List<List<Entity>>();
          string str = $"{$"{$"{$"{NestResult.nestedResult.JobName} - Width {NestResult.nestedResult.MaxYPosition.ToString("f2")}"} - Length {NestResult.nestedResult.MaxXPosition.ToString("f2")}"} - %{NestResult.nestedResult.NestedResultSheets[NestResult.SelectedSheet].UsingPersentageFromMaxX.ToString("f2")}"} - Part Count {NestResult.nestedResult.NestedResultSheets[NestResult.SelectedSheet].Parts.Count.ToString("")}";
          List<ContourPoints5> contourPoints5List = new List<ContourPoints5>();
          clsInit.cNesting.GetAllNestedPartFromSheet(NestResult.nestedResult.NestedResultSheets[NestResult.SelectedSheet], true, ref partEntities, ref innerEntities, ref auxEntities);
          buVector5.AddEntities(innerEntities, ref copiedEnt);
          buVector5.AddEntities(auxEntities, ref copiedEnt);
          buVector5.AddEntities(partEntities, ref copiedEnt);
          hpglFile.WriteHPGL(saveFileDialog.FileName, clsVar.varFile.HPGLFileProperties, copiedEnt);
        }
      }
      else
      {
        for (int index = 0; index <= NestResult.nestedResult.NestedResultSheets.Count - 1; ++index)
        {
          string fileExtension = buFile5.getFileExtension(saveFileDialog.FileName);
          string withoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
          string Name = $"{buFile5.GetPath(saveFileDialog.FileName)}\\{withoutExtension}_{(index + 1).ToString("D3")}{fileExtension}";
          List<List<Entity>> partEntities = new List<List<Entity>>();
          List<List<Entity>> innerEntities = new List<List<Entity>>();
          List<List<Entity>> auxEntities = new List<List<Entity>>();
          List<List<Entity>> copiedEnt = new List<List<Entity>>();
          clsInit.cNesting.GetAllNestedPartFromSheet(NestResult.nestedResult.NestedResultSheets[index], true, ref partEntities, ref innerEntities, ref auxEntities);
          buVector5.AddEntities(innerEntities, ref copiedEnt);
          buVector5.AddEntities(auxEntities, ref copiedEnt);
          buVector5.AddEntities(partEntities, ref copiedEnt);
          hpglFile.WriteHPGL(Name, clsVar.varFile.HPGLFileProperties, copiedEnt);
        }
      }
    }
    clsInit.appCommand.Reset();
  }

  public void CreateCsv(buNestedResultEventArg NestResult)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
    saveFileDialog.Filter = "Csv File (*.csv)|*.csv";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
    List<string> StringList = new List<string>();
    StringList.Add("Name ; Index ; Width ; Height ; Area ; Sheet Persentage ; Part Count; Max X; Pastal Persentage");
    for (int index = 0; index <= NestResult.nestedResult.NestedResultSheets.Count - 1; ++index)
    {
      buNestedSheet nestedResultSheet = NestResult.nestedResult.NestedResultSheets[index];
      string[] strArray = new string[17];
      strArray[0] = nestedResultSheet.Name;
      strArray[1] = " ; ";
      int num = index + 1;
      strArray[2] = num.ToString();
      strArray[3] = " ; ";
      strArray[4] = nestedResultSheet.MaterialWidth.ToString("f3");
      strArray[5] = " ; ";
      strArray[6] = nestedResultSheet.MaterialHeight.ToString("f3");
      strArray[7] = " ; ";
      strArray[8] = nestedResultSheet.MaterialArea.ToString("f3");
      strArray[9] = " ; ";
      strArray[10] = nestedResultSheet.UsingPersentage.ToString("f3");
      strArray[11] = " ; ";
      num = nestedResultSheet.Parts.Count;
      strArray[12] = num.ToString();
      strArray[13] = " ; ";
      strArray[14] = nestedResultSheet.SheetMaxXPosition.ToString("f3");
      strArray[15] = " ; ";
      strArray[16 /*0x10*/] = nestedResultSheet.UsingPersentageFromMaxX.ToString("f3");
      string str = string.Concat(strArray);
      StringList.Add(str);
    }
    buFile5.SaveToFile(StringList, saveFileDialog.FileName);
  }

  public void CreateIsoCutter(buNestedResultEventArg NestResult, bool Draw = true)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
    saveFileDialog.Filter = "Iso File (*.iso)|*.iso";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
      List<List<Entity>> DrawEntities = new List<List<Entity>>();
      clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
      if (NestResult.SelectedSheet >= 0)
      {
        if (NestResult.SelectedSheet <= NestResult.nestedResult.NestedResultSheets.Count - 1)
          clsInit.cCutter.WriteIsoFile(saveFileDialog.FileName, NestResult.SelectedSheet, new CutterIsoFileSettings()
          {
            XScaleFactor = clsCutter.varCutterSettings.XScaleFactor,
            YScaleFactor = clsCutter.varCutterSettings.YScaleFactor,
            NotchOnContour = clsCutter.varCutterSettings.NotchOnContour
          }, NestResult.nestedResult, clsCutter.varCutterSettings, ref DrawEntities);
      }
      else
      {
        for (int Index = 0; Index <= NestResult.nestedResult.NestedResultSheets.Count - 1; ++Index)
        {
          string fileExtension = buFile5.getFileExtension(saveFileDialog.FileName);
          string withoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
          string FileName = $"{buFile5.GetPath(saveFileDialog.FileName)}\\{withoutExtension}_{(Index + 1).ToString("D3")}{fileExtension}";
          clsInit.cCutter.WriteIsoFile(FileName, Index, new CutterIsoFileSettings()
          {
            XScaleFactor = clsCutter.varCutterSettings.XScaleFactor,
            YScaleFactor = clsCutter.varCutterSettings.YScaleFactor,
            NotchOnContour = clsCutter.varCutterSettings.NotchOnContour
          }, NestResult.nestedResult, clsCutter.varCutterSettings, ref DrawEntities);
        }
      }
      if (Draw && DrawEntities.Count > 0)
      {
        clsInit.appCommand.undoBuffer();
        for (int index1 = 0; index1 <= DrawEntities.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= DrawEntities[index1].Count - 1; ++index2)
          {
            ccVars.UndoDont = true;
            clsInit.appCommand.AddEntity(DrawEntities[index1][index2]);
          }
        }
      }
    }
    clsInit.appCommand.Reset();
  }

  public void doCreate(buNestedResultEventArg NestResult)
  {
    clsNesting.ParNest.Runtime.NestingResultPdfFile = NestResult.PdfFile;
    clsNesting.ParNest.Runtime.nestedResultCreateType = NestResult.ResultCreateType;
    clsNesting.ParNest.Runtime.nestedResultSheetType = NestResult.ResultSheetType;
    clsNesting.ParNest.Runtime.NestingResultDoCam = NestResult.DoCam;
    clsFiles.SaveParameter();
    if (NestResult.ResultCreateType == nestedCreateType.Dxf)
      this.CreateDxf(NestResult);
    else if (NestResult.ResultCreateType == nestedCreateType.Hpgl)
      this.CreateHpgl(NestResult);
    else if (NestResult.ResultCreateType == nestedCreateType.Iso)
    {
      if (!clsVar.appModes_0.CutterMode.Enable)
        return;
      this.CreateIsoCutter(NestResult);
    }
    else
    {
      if (NestResult.CsvFile)
        this.CreateCsv(NestResult);
      if (NestResult.ResultCreateType == nestedCreateType.Draw)
      {
        ccVars.UndoDont = false;
        clsInit.appCommand.undoBuffer();
        if (NestResult.ResultSettings != null)
          clsNesting.ParNest.ResultSettings = new buNestingResultSettings(NestResult.ResultSettings);
        if (clsNesting.ParNest.ResultSettings.DrawAddClearAll)
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
        if (clsVar.appModes_0.FoamCuttingMode.Enable)
          clsInit.appFoamCutting.doGetNestResult(NestResult.nestedResult, NestResult.SelectedSheet, -1);
        else if (clsVar.appModes_0.MarbleMode.Enable)
        {
          if (clsInit.appMarble != null)
            clsInit.appMarble.doNestingResult(NestResult);
        }
        else if (clsVar.appModes_0.CompositeMode.Enable)
        {
          int SheetIndex = NestResult.SelectedSheet;
          if (NestResult.ResultSheetType == nestedCreateSheetType.All)
            SheetIndex = -1;
          if (!NestResult.DoCam)
            this.doDrawAllNesting(NestResult.nestedResult, SheetIndex, -1, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, true, false);
          else
            clsInit.appRouter3AX.doCamFromNesting(NestResult);
        }
        else
          this.doDrawAllNesting(NestResult.nestedResult, NestResult.SelectedSheet, -1, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, true, false);
      }
      if (NestResult.ResultCreateType == nestedCreateType.SaveFile)
      {
        if (clsVar.appModes_0.CompositeMode.Enable)
          clsInit.appRouter3AX.doCamFromNesting(NestResult);
        else
          this.doDrawAllNesting(NestResult.nestedResult, NestResult.SelectedSheet, -1, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, true, false);
      }
      if (NestResult.PdfFile)
        this.CreatePdf(NestResult, clsNesting.ParNest.ProgramSettings.DoubleSheetAtPdf);
      if (NestResult.SelectedResult >= 0 & NestResult.SelectedResult <= buNestingCalc.NestedAllResults.Count - 1 && NestResult.nestedResult != null)
      {
        for (int index = 0; index <= NestResult.nestedResult.NestedResultSheets.Count - 1; ++index)
        {
          if (NestResult.nestedResult.NestedResultSheets[index].GCodeResult != null && index <= buNestingCalc.NestedAllResults[NestResult.SelectedResult].NestedResultSheets.Count - 1)
            buNestingCalc.NestedAllResults[NestResult.SelectedResult].NestedResultSheets[index].GCodeResult = new MachineGCodeExecutionResult(NestResult.nestedResult.NestedResultSheets[index].GCodeResult);
        }
      }
      clsNesting.ParNest.Runtime = new buNestingRuntime(clsItem.FrmNestedResult.RunParameter);
      clsFiles.SaveParameter();
    }
  }

  public void doAddPartAll()
  {
    List<buEntity> buEntityList1 = new List<buEntity>();
    List<buEntity> refEntities1 = new List<buEntity>();
    int tickCount = Environment.TickCount;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
      {
        buEntity copiedEntity = (buEntity) null;
        buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
        copiedEntity.Info.OriginalEntityIndex = index;
        buEntityList1.Add(copiedEntity);
      }
    }
    if (buEntityList1.Count == 0)
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
          {
            buEntity copiedEntity = (buEntity) null;
            buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
            copiedEntity.Info.OriginalEntityIndex = index;
            buEntityList1.Add(copiedEntity);
          }
        }
        else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].Visible & (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve | ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Text))
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
          copiedEntity.Info.OriginalEntityIndex = index;
          refEntities1.Add(copiedEntity);
        }
      }
    }
    else
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName != ccVars.Pages[ccVars.PageIndex].LayerName && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].Visible & (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve | ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Text))
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
          copiedEntity.Info.OriginalEntityIndex = index;
          refEntities1.Add(copiedEntity);
        }
      }
    }
    if (buEntityList1.Count <= 0)
      return;
    clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref buEntityList1);
    clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref refEntities1);
    clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref buEntityList1);
    clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref refEntities1);
    List<buEntity> SortedEntities1 = new List<buEntity>();
    List<List<buEntity>> buEntityListList1 = new List<List<buEntity>>();
    clsInit.cVector5.SortEntitiesByRefPoint(buEntityList1[0].Vertices[0], ref buEntityList1, new SortbuSettings()
    {
      Option = {
        NextGroupRules = SortingNextGroupFindRulesType.ClosestLength,
        Resolution = 0.02
      }
    }, ref SortedEntities1);
    clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities1, ref buEntityListList1);
    if (buEntityListList1.Count > 0)
    {
      List<List<buEntity>> refEntities2 = new List<List<buEntity>>();
      List<List<buEntity>> buEntityListList2 = new List<List<buEntity>>();
      Point3D MinPoint1 = new Point3D();
      Point3D MaxPoint1 = new Point3D();
      Point3D MinPoint2 = new Point3D();
      Point3D MaxPoint2 = new Point3D();
      Point3D MidPoint = new Point3D();
      for (int index1 = 0; index1 <= buEntityListList1.Count - 1; ++index1)
      {
        clsInit.cVector5.BoxSizeCalculate(buEntityListList1[index1], ref MinPoint2, ref MidPoint, ref MaxPoint2);
        List<Point3D> Points1 = new List<Point3D>();
        bool flag1 = false;
        for (int index2 = 0; index2 <= buEntityListList1.Count - 1; ++index2)
        {
          if (index1 != index2)
          {
            clsInit.cVector5.BoxSizeCalculate(buEntityListList1[index2], ref MinPoint1, ref MaxPoint1);
            clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntityListList1[index2], 0.05, ref Points1);
            bool flag2 = clsInit.cVector5.isBoxSizeInsideBoxSize(MinPoint1, MaxPoint1, MinPoint2, MaxPoint2, Plane.XY);
            bool flag3 = clsInit.cVector5.IsPointInsidePolygon(Points1, MidPoint, Plane.XY, false);
            if (flag1 = flag2 & flag3)
              index2 = buEntityListList1.Count;
          }
        }
        if (!flag1 && !clsInit.cVector5.isEntitiesClosed(buEntityListList1[index1]))
        {
          if ((buEntityListList1[index1].Count != 1 ? 0 : (buEntityListList1[index1][0] is buLinearPath ? 1 : 0)) != 0)
          {
            buEntity refLinearPath = (buEntity) (buEntityListList1[index1][0] as buLinearPath);
            if (refLinearPath.Vertices.Count > 4)
            {
              int GoBackCount = 0;
              if (buCompare5.EQ(refLinearPath.Vertices[0], refLinearPath.Vertices[refLinearPath.Vertices.Count - 2]))
                GoBackCount = 2;
              else if (buCompare5.EQ(refLinearPath.Vertices[0], refLinearPath.Vertices[refLinearPath.Vertices.Count - 3]))
                GoBackCount = 3;
              else if (buCompare5.EQ(refLinearPath.Vertices[0], refLinearPath.Vertices[refLinearPath.Vertices.Count - 4]))
                GoBackCount = 4;
              if (GoBackCount >= 2 & GoBackCount <= 4)
              {
                buEntity trimedEntity = (buEntity) null;
                clsInit.cVector5.MakeIsClosedEntityWithTrim(GoBackCount, ref refLinearPath, ref trimedEntity);
                buEntityListList1[index1][0] = refLinearPath;
                if (trimedEntity != null)
                  buEntityListList2.Add(new List<buEntity>()
                  {
                    trimedEntity
                  });
              }
            }
            else
              flag1 = true;
          }
          else
            flag1 = true;
        }
        if (!flag1)
        {
          List<Point3D> Points2 = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntityListList1[index1], 0.05, ref Points2);
          if (Points2.Count >= 3)
            refEntities2.Add(buEntityListList1[index1]);
        }
        else
        {
          List<Point3D> Points3 = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntityListList1[index1], 0.05, ref Points3);
          if (Points3.Count >= 2)
            buEntityListList2.Add(buEntityListList1[index1]);
        }
      }
      buEntityListList1.Clear();
      buEntityListList1 = new List<List<buEntity>>();
      buEntity.Copy(refEntities2, ref buEntityListList1);
      for (int index3 = 0; index3 <= buEntityListList2.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= buEntityListList2[index3].Count - 1; ++index4)
          refEntities1.Add(buEntity.Copy(buEntityListList2[index3][index4]));
      }
    }
    if (buEntityListList1.Count <= 0)
      return;
    List<buEntity> buEntityList2 = new List<buEntity>();
    List<buEntity> buEntityList3 = new List<buEntity>();
    for (int index = 0; index <= refEntities1.Count - 1; ++index)
    {
      buEntity refEntities3 = refEntities1[index];
      if (refEntities1[index] is buText | refEntities1[index] is buMultilineText)
      {
        clsInit.cVector5.Move(0.0, 0.0, -refEntities3.BoxMin.Z, ref refEntities3);
        buEntityList2.Add(refEntities3);
      }
      else
      {
        clsInit.cVector5.Move(0.0, 0.0, -refEntities3.BoxMin.Z, ref refEntities3);
        buEntityList3.Add(refEntities3);
      }
    }
    if (clsItem.FrmProgress != null)
      clsItem.FrmProgress.Visible = true;
    CalculationEventArg e = new CalculationEventArg();
    for (int index5 = 0; index5 <= buEntityListList1.Count - 1; ++index5)
    {
      if (clsInit.cVector5.isEntitiesClosed(buEntityListList1[index5]))
      {
        for (int index6 = 0; index6 <= buEntityListList1[index5].Count - 1; ++index6)
        {
          if (buEntityListList1[index5][index6].Info.OriginalEntityIndex >= 0)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[buEntityListList1[index5][index6].Info.OriginalEntityIndex].Selected = true;
        }
        buEntitiesGroup entGroup = new buEntitiesGroup();
        entGroup.Text = new buEntityList();
        entGroup.Outside.Points = new List<Point3D>();
        buEntity.Copy(buEntityListList1[index5], ref entGroup.Outside.Entities);
        clsInit.cVector5.EntitiesToPointsWithCamDirection(entGroup.Outside.Entities, ref entGroup.Outside.Points);
        List<Point3D> list = entGroup.Outside.Points.ToList<Point3D>();
        if (clsNesting.ParNest.PartSettings.MultiplePArtAddOusideFilterLength > 0.0)
          clsInit.cVector5.RemoveSmallLengthFromPoints(clsNesting.ParNest.PartSettings.MultiplePArtAddOusideFilterLength, ref list);
        for (int index7 = buEntityList2.Count - 1; index7 >= 0; --index7)
        {
          bool flag;
          if (flag = clsInit.cVector5.IsPointInsidePolygon(entGroup.Outside.Points, buEntityList2[index7].BoxMin))
            entGroup.Text.Entities.Add(buEntityList2[index7]);
          else if (flag = clsInit.cVector5.IsPointInsidePolygon(entGroup.Outside.Points, buEntityList2[index7].BoxMax))
          {
            entGroup.Text.Entities.Add(buEntityList2[index7]);
          }
          else
          {
            Point3D RefPoint = clsInit.cVector5.MiddlePointOfLine(buEntityList2[index7].BoxMin, buEntityList2[index7].BoxMax);
            flag = clsInit.cVector5.IsPointInsidePolygon(entGroup.Outside.Points, RefPoint);
          }
          if (flag)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[buEntityList2[index7].Info.OriginalEntityIndex].Selected = true;
            buEntityList2.RemoveAt(index7);
          }
          else
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[buEntityList2[index7].Info.OriginalEntityIndex].Selected = false;
        }
        List<buEntity> BaseRefEntities = new List<buEntity>();
        for (int index8 = buEntityList3.Count - 1; index8 >= 0; --index8)
        {
          bool flag = false;
          int num = buEntityList3[index8].Vertices.Count / 10;
          if (num <= 0)
            num = 1;
          for (int index9 = 0; index9 <= buEntityList3[index8].Vertices.Count - 1; index9 += num)
          {
            if (flag = clsInit.cVector5.IsPointInsidePolygon(list, buEntityList3[index8].Vertices[index9]))
              index9 = buEntityList3[index8].Vertices.Count;
          }
          if (flag)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[buEntityList3[index8].Info.OriginalEntityIndex].Selected = true;
            BaseRefEntities.Add(buEntityList3[index8]);
            buEntityList3.RemoveAt(index8);
          }
          else
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[buEntityList3[index8].Info.OriginalEntityIndex].Selected = false;
        }
        if (BaseRefEntities.Count > 0)
        {
          List<buEntity> SortedEntities2 = new List<buEntity>();
          List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
          clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].Vertices[0], ref BaseRefEntities, new SortbuSettings()
          {
            Option = {
              NextGroupRules = SortingNextGroupFindRulesType.ClosestLength
            }
          }, ref SortedEntities2);
          clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities2, ref SplitedEntitites);
          if (SplitedEntitites.Count > 0)
          {
            for (int index10 = 0; index10 <= SplitedEntitites.Count - 1; ++index10)
            {
              if (clsInit.cVector5.isEntitiesClosed(SplitedEntitites[index10]))
              {
                if (entGroup.Inside == null)
                  entGroup.Inside = new List<buEntityList>();
                buEntityList buEntityList4 = new buEntityList();
                buEntity.Copy(SplitedEntitites[index10], ref buEntityList4.Entities);
                if (buEntityList4.Entities.Count > 0)
                {
                  buEntityList4.Points = new List<Point3D>();
                  clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntityList4.Entities, ref buEntityList4.Points);
                }
                entGroup.Inside.Add(buEntityList4);
              }
              else
              {
                if (entGroup.OpenEntities == null)
                  entGroup.OpenEntities = new List<buEntityList>();
                buEntityList buEntityList5 = new buEntityList();
                buEntity.Copy(SplitedEntitites[index10], ref buEntityList5.Entities);
                if (buEntityList5.Entities.Count > 0)
                {
                  buEntityList5.Points = new List<Point3D>();
                  clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntityList5.Entities, ref buEntityList5.Points);
                }
                entGroup.OpenEntities.Add(buEntityList5);
              }
            }
          }
        }
        this.AddPartFromEntities(entGroup, false, false);
      }
      if (index5 % 20 == 0)
        Application.DoEvents();
      e.Job = $"{buLangTranslate.preDef.Part} {buLangTranslate.preDef.Added} {(index5 + 1).ToString()} / {buEntityListList1.Count.ToString()}";
      double num1 = (double) (index5 + 1) / (double) buEntityListList1.Count;
      e.OverallProgressPercentage = num1 > 0.25 ? (!(num1 > 0.25 & num1 <= 0.5) ? (!(num1 > 0.5 & num1 <= 0.75) ? 100.0 : 50.0) : 50.0) : 25.0;
      double num2 = (double) (index5 + 1) / (double) buEntityListList1.Count * 100.0;
      if (num2 > 100.0)
        num2 = 100.0;
      e.ActiveProgressPercentage = num2;
      clsInit.appCommand.CalculationInProgressCmd(e);
    }
    if (clsNesting.ParNest.AddPart.DeleteSelectedAuxEntities | clsNesting.ParNest.AddPart.DeleteSelectedEntities)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    if (clsItem.FrmProgress != null)
      clsItem.FrmProgress.Visible = false;
    int num3 = Environment.TickCount - tickCount;
    clsFiles.SaveParameter();
    this.SaveNestingFile();
    GC.Collect();
  }

  public void doFindAndFixParts()
  {
    this.AnalyseEntities.Clear();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
        {
          buEntity copiedEntity1 = (buEntity) null;
          Entity copiedEntity2 = (Entity) null;
          buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity1);
          copiedEntity1.Info.OriginalEntityIndex = index;
          buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity2);
          copiedEntity2.EntityData = (object) new CustomData()
          {
            OriginalEntityIndex = index
          };
          this.AnalyseEntities.Add(copiedEntity2);
        }
      }
      else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName].Visible & (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve | ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Text))
      {
        buEntity copiedEntity = (buEntity) null;
        buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
        copiedEntity.Info.OriginalEntityIndex = index;
      }
    }
    AnalyseEntitiesResult Result = new AnalyseEntitiesResult();
    clsInit.cVector5.AnalyseEntities(this.AnalyseEntities, clsNesting.ParNest.AnalyseSettings, ref Result);
    if (Result.isError)
    {
      for (int index = 0; index <= this.AnalyseEntities.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = this.AnalyseEntities[index].Selected;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      clsItem.FrmDrawingAnalayseResult.TopMost = true;
      clsItem.FrmDrawingAnalayseResult.PropertiesForm.TopMost = true;
      clsItem.FrmDrawingAnalayseResult.Result = new AnalyseEntitiesResult(Result);
      clsItem.FrmDrawingAnalayseResult.Init();
      clsItem.FrmDrawingAnalayseResult.Show();
    }
    else
      buString5.MessageBoxInfo(AppLanguage.CadCamMessages[89]);
  }

  public void doAnalyzeFindZoom(object data1, object data2)
  {
    if ((data1 == null ? 0 : (data2 != null ? 1 : 0)) == 0 || !(data2 is AnalyseEntitiesResultError))
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
    AnalyseEntitiesResultError entitiesResultError = data2 as AnalyseEntitiesResultError;
    if (entitiesResultError.IndexEntity >= 0 & entitiesResultError.IndexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entitiesResultError.IndexEntity].Selected = true;
    if (entitiesResultError.IndexEntityList.Count > 0)
    {
      for (int index = 0; index <= entitiesResultError.IndexEntityList.Count - 1; ++index)
      {
        int indexEntity = entitiesResultError.IndexEntityList[index];
        if (indexEntity >= 0 & indexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity].Selected = true;
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit(true);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doAnalyzeResult(object data1, object data2)
  {
    if ((data1 == null ? 0 : (data2 != null ? 1 : 0)) == 0 || !(data2 is AnalyseEntitiesResultError))
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
    AnalyseEntitiesResultError entitiesResultError = data2 as AnalyseEntitiesResultError;
    if (entitiesResultError.IndexEntity >= 0 & entitiesResultError.IndexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entitiesResultError.IndexEntity].Selected = true;
    if (entitiesResultError.IndexEntityList.Count > 0)
    {
      for (int index = 0; index <= entitiesResultError.IndexEntityList.Count - 1; ++index)
      {
        int indexEntity = entitiesResultError.IndexEntityList[index];
        if (indexEntity >= 0 & indexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity].Selected = true;
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doAnalyzeFix(object data1, object data2)
  {
    try
    {
      for (int index = 0; index <= this.AnalyseEntities.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = false;
      if (clsItem.FrmDrawingAnalayseResult.Result.ErrorList.Count > 0)
        clsInit.appCommand.undoBuffer();
      for (int index1 = 0; index1 <= clsItem.FrmDrawingAnalayseResult.Result.ErrorList.Count - 1; ++index1)
      {
        AnalyseEntitiesResultError error = clsItem.FrmDrawingAnalayseResult.Result.ErrorList[index1];
        int indexEntity1 = error.IndexEntity;
        if (indexEntity1 >= 0 & indexEntity1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
        {
          if (error.Action == AnalyseEntitiesActionType.Delete & error.Enable)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity1].Selected = true;
          if (error.Action == AnalyseEntitiesActionType.Fix & error.Enable)
            ;
        }
        if (error.IndexEntityList.Count > 0)
        {
          for (int index2 = 0; index2 <= error.IndexEntityList.Count - 1; ++index2)
          {
            int indexEntity2 = error.IndexEntityList[index2];
            if (indexEntity2 >= 0 & indexEntity2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
            {
              if (error.Action == AnalyseEntitiesActionType.Delete & error.Enable)
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity2].Selected = true;
              if (error.Action == AnalyseEntitiesActionType.Fix & error.Enable && error.ErrorType == AnalyseEntitiesResultErrorType.NotClosedEntities)
              {
                Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity2];
                if (entity is LinearPath)
                {
                  Line C1 = new Line(buVector5.ToPoint3D(entity.Vertices[1]), buVector5.ToPoint3D(entity.Vertices[0]));
                  Line C2 = new Line(buVector5.ToPoint3D(entity.Vertices[entity.Vertices.Length - 1]), buVector5.ToPoint3D(entity.Vertices[entity.Vertices.Length - 2]));
                  C1.StartPoint -= C1.StartTangent * 100.0;
                  C1.EndPoint += C1.EndTangent * 100.0;
                  C1.Regen(0.1);
                  C2.StartPoint -= C2.StartTangent * 100.0;
                  C2.EndPoint += C2.EndTangent * 100.0;
                  C2.Regen(0.1);
                  entity.Selected = false;
                  Point3D[] point3DArray = Utility.Intersection((ICurve) C1, (ICurve) C2, 100.0, false);
                  if ((point3DArray == null ? 0 : (point3DArray.Length != 0 ? 1 : 0)) != 0)
                  {
                    entity.Vertices[0] = buVector5.ToPoint3D(point3DArray[0]);
                    entity.Vertices[entity.Vertices.Length - 1] = buVector5.ToPoint3D(point3DArray[0]);
                    entity.Regen(0.01);
                  }
                }
              }
            }
          }
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      this.AnalyseEntities.Clear();
      GC.Collect();
    }
    catch (Exception ex)
    {
    }
  }

  public void doAnalyzeCancel(object data1, object data2)
  {
    this.AnalyseEntities.Clear();
    GC.Collect();
  }

  public bool doAddShapePartAndSheet(
    Point3D RefPnt,
    bool isSheet,
    List<Entity> RefEntities,
    List<buEntity> RefBuEntities = null)
  {
    buEntitiesGroup entGroup = new buEntitiesGroup();
    List<buEntity> buEntityList1 = new List<buEntity>();
    bool flag1 = false;
    SortbuSettings Settings1 = new SortbuSettings();
    SortbuResult Result1 = new SortbuResult();
    SelectionOption selectionOption = new SelectionOption()
    {
      CircleToArc = true,
      SplitArcIfGreatThen180 = true,
      Point = false,
      Text = false
    };
    SelectionEntityTypes Entities = new SelectionEntityTypes();
    if (RefEntities.Count == 0)
    {
      clsInit.appCommand.SelectionToEntities(ref Entities);
      clsInit.cVector5.EntitiesPlaneCheck(ref Entities.entitiesCurve);
    }
    else
    {
      clsInit.cVector5.EntitiesToEntitiesGroup(ref Entities, RefEntities);
      clsInit.cVector5.EntitiesPlaneCheck(ref Entities.entitiesCurve);
    }
    if (RefBuEntities != null && RefBuEntities.Count > 0)
    {
      clsInit.cVector5.EntitiesToEntitiesGroup(ref Entities, RefBuEntities);
      clsInit.cVector5.EntitiesPlaneCheck(ref Entities.entitiesCurve);
    }
    bool flag2;
    if (Entities.entitiesCurve.Count > 0)
    {
      string LayerName = "";
      List<buEntity> AllEntities = new List<buEntity>();
      List<buEntity> buEntityList2 = new List<buEntity>();
      if (!isSheet)
      {
        if (clsNesting.ParNest.PartSettings.PartMainAddType == nestingPartMainDrawAddModes.Color)
        {
          clsInit.appCommand.GetLayerNameFromColor(clsNesting.ParNest.AddPart.SelectionColor, ref LayerName);
          if (LayerName.Length > 0)
            clsInit.cVector5.GetEntitiesByLayerName(ref Entities.entitiesCurve, LayerName, ref AllEntities, true);
        }
        else if (clsNesting.ParNest.PartSettings.PartMainAddType == nestingPartMainDrawAddModes.Layer)
          clsInit.cVector5.GetEntitiesByLayerName(ref Entities.entitiesCurve, ccVars.Pages[ccVars.PageIndex].LayerName, ref AllEntities, true);
        else
          buEntity.Copy(Entities.entitiesCurve, ref AllEntities);
        clsInit.cVector5.DeleteSelectedEntities(ref Entities.entitiesCurve);
        buEntity.Copy(Entities.entitiesCurve, ref buEntityList2);
      }
      else
      {
        List<buEntitiesGroup> Groups = new List<buEntitiesGroup>();
        clsInit.cVector5.FindEntitiesGroupFromEntities(Entities.entitiesCurve[0].StartPoint, Entities.entitiesCurve, Plane.XY, ref Groups, GoBackToFindClosedEntity: clsNesting.ParNest.PartSettings.CheckLinearPathToBackwardToFindClosed);
        if (Groups.Count > 0)
        {
          if (clsInit.cVector5.isEntitiesClosed(Groups[0].Outside.Entities))
          {
            if (Groups[0].Outside.Entities.Count > 0)
            {
              entGroup = new buEntitiesGroup(Groups[0]);
              clsInit.cVector5.SetColorEntity(clsNesting.ParNest.Draw.SheetEntityColor, ref entGroup.Outside.Entities);
              entGroup.Outside.Points = new List<Point3D>();
              clsInit.cVector5.EntitiesToPointsWithCamDirection(entGroup.Outside.Entities, ref entGroup.Outside.Points);
              for (int index = 0; index <= entGroup.Inside.Count - 1; ++index)
              {
                clsInit.cVector5.SetColorEntity(clsNesting.ParNest.Draw.SheetInnerColor, ref entGroup.Inside[index].Entities);
                entGroup.Inside[index].Points = new List<Point3D>();
                clsInit.cVector5.EntitiesToPointsWithCamDirection(entGroup.Inside[index].Entities, ref entGroup.Inside[index].Points);
              }
              if (entGroup.OpenEntities != null)
              {
                for (int index = 0; index <= entGroup.OpenEntities.Count - 1; ++index)
                {
                  clsInit.cVector5.SetColorEntity(clsNesting.ParNest.Draw.SheetInnerColor, ref entGroup.OpenEntities[index].Entities);
                  entGroup.OpenEntities[index].Points = new List<Point3D>();
                  clsInit.cVector5.EntitiesToPointsWithCamDirection(entGroup.OpenEntities[index].Entities, ref entGroup.OpenEntities[index].Points);
                }
              }
            }
            else
            {
              buString5.MessageBoxWarning($"{buLangTranslate.preSentencesNesting.NoSuitableEntitiesAvailable} - {buLangTranslate.preDef.Sheet}");
              flag2 = false;
              goto label_79;
            }
          }
          else
          {
            buString5.MessageBoxWarning($"{buLangTranslate.preSentencesNesting.EntitiesAreNotClosedPath} - {buLangTranslate.preDef.Sheet}");
            flag2 = false;
            goto label_79;
          }
        }
        else
        {
          buString5.MessageBoxWarning($"{buLangTranslate.preSentencesNesting.NoSuitableEntitiesAvailable} - {buLangTranslate.preDef.Sheet}");
          flag2 = false;
          goto label_79;
        }
      }
      if (!isSheet)
      {
        clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref AllEntities);
        clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref buEntityList2);
        clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref AllEntities);
        clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref buEntityList2);
        if ((Entities.entitiesText == null ? 0 : (Entities.entitiesText.Count > 0 ? 1 : 0)) != 0)
        {
          clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref Entities.entitiesText);
          if (Entities.entitiesText.Count > 0)
          {
            for (int index = 0; index <= Entities.entitiesText.Count - 1; ++index)
            {
              if (Entities.entitiesText[index].BoxMin == (Point3D) null)
                Entities.entitiesText[index].Regen();
              buEntity refEntities = Entities.entitiesText[index];
              clsInit.cVector5.Move(0.0, 0.0, -Entities.entitiesText[index].BoxMin.Z, ref refEntities);
            }
          }
          clsInit.appCommand.SetTextEntityStyleAsDefault(ref Entities.entitiesText);
          entGroup.Text = new buEntityList();
          entGroup.Text.GroupType = entityGroupType.Text;
          buEntity.Copy(Entities.entitiesText, ref entGroup.Text.Entities);
          clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref entGroup.Text.Entities);
          clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref entGroup.Text.Entities);
        }
        if (AllEntities.Count > 0)
        {
          for (int index = 0; index <= AllEntities.Count - 1; ++index)
          {
            if (AllEntities[index].BoxMin == (Point3D) null)
              AllEntities[index].Regen();
            buEntity refEntities = AllEntities[index];
            clsInit.cVector5.Move(0.0, 0.0, -AllEntities[index].BoxMin.Z, ref refEntities);
          }
        }
        if (buEntityList2.Count > 0)
        {
          for (int index = 0; index <= buEntityList2.Count - 1; ++index)
          {
            if (buEntityList2[index].BoxMin == (Point3D) null)
              buEntityList2[index].Regen();
            buEntity refEntities = buEntityList2[index];
            clsInit.cVector5.Move(0.0, 0.0, -buEntityList2[index].BoxMin.Z, ref refEntities);
          }
        }
        List<List<buEntity>> SplitedEntitites1 = new List<List<buEntity>>();
        if (AllEntities.Count > 0)
        {
          SortbuSettings Settings2 = new SortbuSettings();
          SortbuResult Result2 = new SortbuResult();
          Settings2.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
          Settings2.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
          Settings2.Option.Resolution = 0.05;
          List<buEntity> SortedEntities = new List<buEntity>();
          clsInit.cVector5.SortEntitiesByRefPoint(AllEntities[0].StartPoint, ref AllEntities, Settings2, ref SortedEntities, ref Result2);
          clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites1);
        }
        if (SplitedEntitites1.Count == 1)
        {
          Settings1.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
          Settings1.Option.WhenFoundClosedCurveThenFinish = true;
          List<buEntity> SortedEntities;
          for (int index = 0; index <= AllEntities.Count - 1; ++index)
          {
            SortedEntities = new List<buEntity>();
            clsInit.cVector5.SortEntitiesByRefPoint(AllEntities[index].StartPoint, ref AllEntities, Settings1, ref SortedEntities, ref Result1);
            if (clsInit.cVector5.isEntitiesClosed(SortedEntities))
            {
              buEntity.Copy(SortedEntities, ref entGroup.Outside.Entities);
              if (clsInit.cVector5.EntitiesClockDirection(entGroup.Outside.Entities) == ClockDirectionType.CCW)
                clsInit.cVector5.ChangeEntitiesDirection(ref entGroup.Outside.Entities);
              entGroup.Outside.Points = new List<Point3D>();
              clsInit.cVector5.EntitiesToPointsWithCamDirection(entGroup.Outside.Entities, ref entGroup.Outside.Points);
              entGroup.Outside.Points[0].X = Math.Round(entGroup.Outside.Points[0].X);
              entGroup.Outside.Points[0].Y = Math.Round(entGroup.Outside.Points[0].Y);
              entGroup.Outside.Points[0].Z = Math.Round(entGroup.Outside.Points[0].Z);
              entGroup.Outside.Points[entGroup.Outside.Points.Count - 1].X = Math.Round(entGroup.Outside.Points[entGroup.Outside.Points.Count - 1].X);
              entGroup.Outside.Points[entGroup.Outside.Points.Count - 1].Y = Math.Round(entGroup.Outside.Points[entGroup.Outside.Points.Count - 1].Y);
              entGroup.Outside.Points[entGroup.Outside.Points.Count - 1].Z = Math.Round(entGroup.Outside.Points[entGroup.Outside.Points.Count - 1].Z);
              entGroup.Outside.GroupType = entityGroupType.Cutting;
              break;
            }
          }
          if (entGroup.Outside.Entities.Count == 0)
          {
            buString5.MessageBoxWarning($"{buLangTranslate.preSentencesNesting.NoSuitableEntitiesAvailable} - {buLangTranslate.preDef.Part}");
            flag2 = false;
            goto label_79;
          }
          if (entGroup.Outside.Entities.Count > 0 & buEntityList2.Count > 0)
          {
            Settings1.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
            Settings1.Option.WhenFoundClosedCurveThenFinish = false;
            SortedEntities = new List<buEntity>();
            clsInit.cVector5.SortEntitiesByRefPoint(buEntityList2[0].StartPoint, ref buEntityList2, Settings1, ref SortedEntities, ref Result1);
            if (SortedEntities.Count > 0)
            {
              List<List<buEntity>> SplitedEntitites2 = new List<List<buEntity>>();
              clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites2);
              for (int index = 0; index <= SplitedEntitites2.Count - 1; ++index)
              {
                if (clsInit.cVector5.isEntitiesClosed(SplitedEntitites2[index]))
                {
                  buEntityList buEntityList3 = new buEntityList(SplitedEntitites2[index]);
                  if (clsInit.cVector5.EntitiesClockDirection(SplitedEntitites2[index]) == ClockDirectionType.CCW)
                    clsInit.cVector5.ChangeEntitiesDirection(ref buEntityList3.Entities);
                  clsInit.appCommand.GetLayerToolFromName(SplitedEntitites2[index][0].LayerName, ref buEntityList3.Tool);
                  clsInit.cVector5.LayerGetByName(ccVars.Pages[ccVars.PageIndex].Layers, SplitedEntitites2[index][0].LayerName, ref buEntityList3.Layer);
                  buEntityList3.Points = new List<Point3D>();
                  clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites2[index], ref buEntityList3.Points);
                  buEntityList3.Points[0].X = Math.Round(buEntityList3.Points[0].X);
                  buEntityList3.Points[0].Y = Math.Round(buEntityList3.Points[0].Y);
                  buEntityList3.Points[0].Z = Math.Round(buEntityList3.Points[0].Z);
                  buEntityList3.Points[buEntityList3.Points.Count - 1].X = Math.Round(buEntityList3.Points[buEntityList3.Points.Count - 1].X);
                  buEntityList3.Points[buEntityList3.Points.Count - 1].Y = Math.Round(buEntityList3.Points[buEntityList3.Points.Count - 1].Y);
                  buEntityList3.Points[buEntityList3.Points.Count - 1].Z = Math.Round(buEntityList3.Points[buEntityList3.Points.Count - 1].Z);
                  buEntityList3.GroupType = entityGroupType.InsideClosed;
                  entGroup.Inside.Add(buEntityList3);
                }
                else
                {
                  buEntityList buEntityList4 = new buEntityList(SplitedEntitites2[index]);
                  clsInit.appCommand.GetLayerToolFromName(SplitedEntitites2[index][0].LayerName, ref buEntityList4.Tool);
                  clsInit.cVector5.LayerGetByName(ccVars.Pages[ccVars.PageIndex].Layers, SplitedEntitites2[index][0].LayerName, ref buEntityList4.Layer);
                  buEntityList4.Points = new List<Point3D>();
                  clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites2[index], ref buEntityList4.Points);
                  buEntityList4.GroupType = entityGroupType.InsideOpen;
                  if (entGroup.OpenEntities == null)
                    entGroup.OpenEntities = new List<buEntityList>();
                  entGroup.OpenEntities.Add(buEntityList4);
                }
              }
            }
          }
        }
        else if (SplitedEntitites1.Count > 1)
        {
          List<buEntitiesGroup> Groups = new List<buEntitiesGroup>();
          clsInit.cVector5.FindEntitiesGroupFromEntities(AllEntities[0].StartPoint, AllEntities, Plane.XY, ref Groups);
          if (Groups.Count > 0)
            entGroup = new buEntitiesGroup(Groups[0]);
        }
      }
      if (entGroup.Outside.Entities.Count > 0)
      {
        flag1 = this.AddPartFromEntities(entGroup, isSheet);
        if (clsNesting.ParNest.AddPart.DeleteSelectedAuxEntities | clsNesting.ParNest.AddPart.DeleteSelectedEntities && flag1)
        {
          clsInit.appCommand.Delete(false);
          clsInit.appCommand.ClearEntitiesSelection();
        }
      }
    }
    flag2 = flag1;
label_79:
    return flag2;
  }

  public bool doAddShapePart(List<buEntitiesGroup> EntGroup)
  {
    bool flag = false;
    for (int index = 0; index <= EntGroup.Count - 1; ++index)
    {
      if (EntGroup[index].Outside.Entities.Count > 0)
        flag = this.AddPartFromEntities(EntGroup[index], false);
    }
    return flag;
  }

  public bool doAddShapeSheet(List<buEntitiesGroup> EntGroup)
  {
    bool flag = false;
    for (int index = 0; index <= EntGroup.Count - 1; ++index)
    {
      if (EntGroup[index].Outside.Entities.Count > 0)
        flag = this.AddPartFromEntities(EntGroup[index], true);
    }
    return flag;
  }

  public bool doAddShapeSheet(buEntitiesGroup EntGroup)
  {
    bool flag = false;
    if (EntGroup.Outside.Entities.Count > 0)
      flag = this.AddPartFromEntities(EntGroup, true);
    return flag;
  }

  public void doAddToTempCalculatedNesting(buNestedResult Result, bool isLast)
  {
    try
    {
      buNestedResult buNestedResult = new buNestedResult(Result);
      ccVars.UndoDont = true;
      buNestedResult.Parameters = new buNestingVar(clsNesting.ParNest);
      if (clsItem.FrmNestOnlineCalc == null)
        return;
      int num = 0;
      clsNesting.BestNestCount = 1;
      TreeNode node1 = new TreeNode();
      node1.Tag = (object) (clsPowerNest.storedNestedResult.Count - 1).ToString();
      node1.Text = $"Temp_{clsPowerNest.storedNestedResult.Count.ToString()} = {buNestedResult.NestedResultSheets.Count.ToString()} {AppLanguage.CadCamDynamic[33]}";
      if (buNestedResult.NotNestedAll)
        node1.Text = $"{node1.Text} - {AppLanguage.CadCamDynamic[94]} - [{buNestedResult.NestedTotalPartCount.ToString()} / {buNestedResult.OrderedTotalPartCount.ToString()}]";
      for (int index1 = 0; index1 <= buNestedResult.NestedResultSheets.Count - 1; ++index1)
      {
        num += buNestedResult.NestedResultSheets[index1].Parts.Count;
        TreeNode node2 = new TreeNode();
        node2.Tag = (object) $"{(clsNesting.BestNestCount - 1).ToString()}-{index1.ToString()}";
        node2.Text = $"{(index1 + 1).ToString()} - {AppLanguage.CadCamDynamic[33]} - ( {buNestedResult.NestedResultSheets[index1].MaterialWidth.ToString()} , {buNestedResult.NestedResultSheets[index1].MaterialHeight.ToString()} ) - {buNestedResult.NestedResultSheets[index1].Parts.Count.ToString()} {AppLanguage.CadCamDynamic[34]}";
        node2.ForeColor = Color.Black;
        for (int index2 = 0; index2 <= buNestedResult.NestedResultSheets[index1].Parts.Count - 1; ++index2)
        {
          TreeNode node3 = new TreeNode();
          node3.Tag = (object) $"{(clsNesting.BestNestCount - 1).ToString()}-{index1.ToString()}-{index2.ToString()}";
          node3.Text = $"{(index2 + 1).ToString()} - {AppLanguage.CadCamDynamic[34]} - ( {buNestedResult.NestedResultSheets[index1].Parts[index2].Width.ToString()} , {buNestedResult.NestedResultSheets[index1].Parts[index2].Height.ToString()} ) - R: {buNestedResult.NestedResultSheets[index1].Parts[index2].RotateValue.ToString("f3")}";
          if (buNestedResult.NestedResultSheets[index1].Parts[index2].Name.Trim().Length > 0)
            node3.Text = $"{node3.Text} - {buNestedResult.NestedResultSheets[index1].Parts[index2].Name.Trim()}";
          node3.ForeColor = Color.Black;
          node2.Nodes.Add(node3);
        }
        if (buNestedResult.NestedResultSheets[index1].WarningText.Length > 0)
        {
          node2.Text += buNestedResult.NestedResultSheets[index1].WarningText;
          node2.ForeColor = Color.Red;
          node1.ForeColor = Color.Red;
          node1.Text += buNestedResult.NestedResultSheets[index1].WarningText;
        }
        if (buNestedResult.NotNestedAll)
        {
          node1.ForeColor = Color.Red;
          node2.ForeColor = Color.Red;
          node2.Text = $"{node2.Text} - {AppLanguage.CadCamDynamic[94]}";
        }
        node1.Nodes.Add(node2);
      }
      if (!buNestedResult.NotNestedAll)
        node1.Text = $"{node1.Text} - {num.ToString()} {AppLanguage.CadCamDynamic[34]}";
      clsItem.FrmNestOnlineCalc.treeView1.Nodes.Add(node1);
      if (clsNesting.ParNest.ProgramSettings.CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
        node1.Text = $"{node1.Text} - X {AppLanguage.CadCamDynamic[46]} =  {buNestedResult.MaxXPosition.ToString("f3")} - % {buNestedResult.NestedResultSheets[0].UsingPersentageFromMaxX.ToString("f2")}";
      if (!(clsNesting.ParNest.Settings.ShowResultPreviewAfterFinish & isLast))
        return;
      this.cmdPreviewPressed((object) Result);
    }
    catch (Exception ex)
    {
    }
  }

  public void doAddToAllNestedResult(buNestedResult Result)
  {
    buNestingCalc.NestedAllResults.Add(Result);
    for (int index1 = 0; index1 <= Result.NestedResultSheets.Count - 1; ++index1)
    {
      clsInit.cNesting.IncreaseSheetUsedCountByID(ref clsNesting.Sheets, Result.NestedResultSheets[index1].MaterialID);
      for (int index2 = 0; index2 <= Result.NestedResultSheets[index1].Parts.Count - 1; ++index2)
        clsInit.cNesting.IncreasePartUsedCountByID(ref clsNesting.Parts, Result.NestedResultSheets[index1].Parts[index2].ID);
    }
  }

  public void doDrawAllNesting(
    buNestedResult Result,
    int SheetIndex,
    int PartIndex,
    Design Viewport,
    bool isSolid,
    bool isPreview)
  {
    for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index1)
    {
      Layer layer = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index1];
      for (int index2 = 0; index2 <= Viewport.Layers.Count - 1; ++index2)
      {
        if (layer.Name != Viewport.Layers[index2].Name)
          Viewport.Layers.AddOrReplace(new Layer(layer.Name, layer.Color, layer.LineTypeName, layer.LineWeight, layer.Visible));
        else if (layer.Color != Viewport.Layers[index2].Color)
          Viewport.Layers[index2].Color = layer.Color;
      }
    }
    int num1 = 0;
    int num2 = Result.NestedResultSheets.Count - 1;
    if (SheetIndex >= 0)
    {
      num1 = SheetIndex;
      num2 = SheetIndex;
    }
    Point3D MinPoint1 = new Point3D();
    Point3D point3D = new Point3D();
    Point3D MaxPoint1 = new Point3D();
    if (Result.NestedResultSheets.Count > 0)
    {
      if (clsNesting.ParNest.ResultSettings.DrawAddClearAll | !clsNesting.ParNest.ResultSettings.DrawAddToEnd)
      {
        for (int index = 0; index <= Viewport.Entities.Count - 1; ++index)
        {
          if ((Viewport.Entities[index].EntityData == null ? 0 : (Viewport.Entities[index].EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) Viewport.Entities[index].EntityData).typeDefination == entityTypeDefination.Nesting)
            Viewport.Entities[index].Selected = true;
        }
        Viewport.Entities.DeleteSelected();
        if (clsNesting.ParNest.ResultSettings.DrawAddToEnd)
        {
          Viewport.Entities.RegenAllCurved();
          Viewport.Invalidate();
        }
      }
      double dx = 0.0;
      double dy = 0.0;
      if (clsNesting.ParNest.ResultSettings.DrawAddToEnd)
      {
        Viewport.Entities.RegenAllCurved();
        List<Entity> refEntities = new List<Entity>();
        for (int index = 0; index <= Viewport.Entities.Count - 1; ++index)
        {
          if (Viewport.Entities[index] is ICurve)
            refEntities.Add(Viewport.Entities[index]);
        }
        if (refEntities.Count > 0)
        {
          Point3D MinPoint2 = new Point3D();
          Point3D MaxPoint2 = new Point3D();
          clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint2, ref MaxPoint2);
          if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
            dx = MaxPoint2.X + clsNesting.ParNest.ResultSettings.DrawAddToEndOffset;
          if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
            dy = MaxPoint2.Y + clsNesting.ParNest.ResultSettings.DrawAddToEndOffset;
        }
        else
        {
          if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
            dx = clsNesting.ParNest.ResultSettings.DrawAddToEndOffset;
          if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
            dy = clsNesting.ParNest.ResultSettings.DrawAddToEndOffset;
        }
      }
      if (!clsNesting.ParNest.ResultSettings.DrawAddToEnd)
        ;
      if (isPreview)
      {
        dx = 0.0;
        dy = 0.0;
      }
      for (int index3 = num1; index3 <= num2; ++index3)
      {
        List<Entity> calcEntities1 = new List<Entity>();
        List<Entity> UselessEntities = new List<Entity>();
        ccVars.UndoDont = true;
        if (clsNesting.ParNest.ResultSettings.DrawSheets && (!clsNesting.ParNest.ResultSettings.DrawSheetOnlyPreview || isPreview))
        {
          clsInit.cNesting.NestedSheetToEntity(Result.NestedResultSheets[index3], clsNesting.ParNest.ResultSettings.DrawPartAsSolid & isSolid, clsNesting.ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities1, ref UselessEntities);
          if (calcEntities1 != null)
          {
            string LayerName = clsNesting.varTemps.layerSheet;
            if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, LayerName))
              LayerName = "Default";
            clsInit.cVector5.BoxSizeCalculate(calcEntities1, ref MinPoint1, ref MaxPoint1);
            for (int index4 = 0; index4 <= calcEntities1.Count - 1; ++index4)
            {
              Entity refEntity = calcEntities1[index4];
              clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity);
              calcEntities1[index4].Translate(dx, dy, -MaxPoint1.Z - 0.05);
              calcEntities1[index4].ColorMethod = colorMethodType.byEntity;
              calcEntities1[index4].LayerName = LayerName;
              if (calcEntities1[index4] is Mesh && calcEntities1[index4].Color == Color.Black)
                calcEntities1[index4].Color = clsNesting.ParNest.Draw.SheetSolidColor;
              Viewport.Entities.Add(calcEntities1[index4]);
            }
          }
        }
        if ((Result.NestedResultSheets[index3].RemnantSheets == null ? 0 : (Result.NestedResultSheets[index3].RemnantSheets.Count > 0 ? 1 : 0)) != 0)
        {
          string LayerName = clsNesting.varTemps.layerSheet;
          if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, LayerName))
            LayerName = "Default";
          for (int index5 = 0; index5 <= Result.NestedResultSheets[index3].RemnantSheets.Count - 1; ++index5)
          {
            Rectangle2D remnantSheet = Result.NestedResultSheets[index3].RemnantSheets[index5];
            CompositeCurve rectangle = CompositeCurve.CreateRectangle(Plane.XY, remnantSheet.StartPoint.X, remnantSheet.StartPoint.Y, remnantSheet.Width, remnantSheet.Height);
            rectangle.Translate(dx, dy, 0.25);
            rectangle.Color = Color.Red;
            rectangle.ColorMethod = colorMethodType.byEntity;
            rectangle.LayerName = LayerName;
            rectangle.LineWeight = 2f;
            rectangle.LineWeightMethod = colorMethodType.byEntity;
            if (!clsNesting.ParNest.ResultSettings.DrawPartAsSolid)
            {
              Viewport.Entities.Add((Entity) rectangle);
            }
            else
            {
              Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) rectangle).ExtrudeAsMesh(0.1, 0.1, Mesh.natureType.RichSmooth);
              mesh.Color = Color.Red;
              mesh.ColorMethod = colorMethodType.byEntity;
              mesh.LayerName = LayerName;
              Viewport.Entities.Add((Entity) mesh);
            }
            Entity refEntity = (Entity) new Text(Plane.XY, buLangTranslate.preDef.Remnant, Result.NestedResultSheets[index3].MaterialHeight * 0.05, Text.alignmentType.MiddleCenter);
            refEntity.Translate(remnantSheet.StartPoint.X + remnantSheet.Width / 2.0 + dx, remnantSheet.StartPoint.Y + remnantSheet.Height / 2.0 + dy, 0.5);
            clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity);
            Viewport.Entities.Add(refEntity);
          }
        }
        List<Entity> refEntities = new List<Entity>();
        double num3 = 0.0;
        int num4 = 0;
        int num5 = Result.NestedResultSheets[index3].Parts.Count - 1;
        if (PartIndex >= 0)
        {
          num4 = PartIndex;
          num5 = PartIndex;
        }
        double num6 = Result.NestedResultSheets[index3].MaterialWidth + Result.NestedResultSheets[index3].MaterialWidth * 0.1;
        double num7 = Result.NestedResultSheets[index3].MaterialHeight / 2.0;
        if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
        {
          num6 = Result.NestedResultSheets[index3].MaterialWidth / 3.0;
          num7 = -Result.NestedResultSheets[index3].MaterialHeight * 0.1;
          if (num6 > Result.NestedResultSheets[index3].SheetMaxXPosition + 20.0)
            num6 = Result.NestedResultSheets[index3].SheetMaxXPosition + 20.0;
        }
        string textString = "";
        string str1 = "";
        if (clsNesting.ParNest.ResultSettings.ShowSheetPersentageOnDisplay)
        {
          textString = $"{textString}%{Result.NestedResultSheets[index3].UsingPersentage.ToString("f3")}";
          str1 = " - ";
        }
        if (clsNesting.ParNest.ResultSettings.ShowSheetNameOnDisplay)
        {
          if (Result.NestedResultSheets[index3].Name.Length > 0)
            textString = textString + str1 + Result.NestedResultSheets[index3].Name;
          str1 = " - ";
        }
        if (clsNesting.ParNest.ResultSettings.ShowSheetSizeOnDisplay)
          textString = $"{textString}{str1}{Result.NestedResultSheets[index3].MaterialWidth.ToString("f1")} X {Result.NestedResultSheets[index3].MaterialHeight.ToString("f1")}";
        if (textString.Length > 0)
        {
          Entity refEntity = (Entity) new Text(Plane.XY, textString, Result.NestedResultSheets[index3].MaterialHeight * 0.05);
          refEntity.Translate(num6 + dx, num7 + dy);
          clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity);
          Viewport.Entities.Add(refEntity);
        }
        Entity refEntity1 = (Entity) new Text(Plane.XY, $"{(index3 + 1).ToString()} - {buLangTranslate.preDef.Sheet}", Result.NestedResultSheets[index3].MaterialHeight * 0.05);
        if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
          refEntity1.Translate(num6 + dx, num7 + dy + Result.NestedResultSheets[index3].MaterialHeight * 0.05 + 30.0);
        if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
          refEntity1.Translate(num6 + dx, num7 - Result.NestedResultSheets[index3].MaterialHeight * 0.05 - 30.0);
        clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity1);
        if (clsNesting.ParNest.ResultSettings.ShowSheetCountOnDisplay)
          Viewport.Entities.Add(refEntity1);
        for (int index6 = num4; index6 <= num5; ++index6)
        {
          ccVars.UndoDont = true;
          List<Entity> calcEntities2 = new List<Entity>();
          clsInit.cNesting.NestedPartToEntity(Result.NestedResultSheets[index3].Parts[index6], isSolid & clsNesting.ParNest.ResultSettings.DrawPartAsSolid, clsNesting.ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities2);
          List<Point3D> point3DList = new List<Point3D>();
          double num8 = clsInit.cVector5.PolygonArea(Result.NestedResultSheets[index3].Parts[index6].EntitiesGroup.Outside.Points, Plane.XY);
          num3 += num8;
          for (int index7 = 0; index7 <= calcEntities2.Count - 1; ++index7)
          {
            double dz = 0.0;
            if (calcEntities2[index7].GetType() != typeof (Brep) & calcEntities2[index7].GetType() != typeof (Mesh) && clsNesting.ParNest.ResultSettings.DrawPartAsSolid)
              dz = 0.25;
            Entity refEntity2 = calcEntities2[index7];
            refEntity2.Translate(dx, dy, dz);
            refEntity2.ColorMethod = colorMethodType.byEntity;
            Color color1 = refEntity2.Color;
            int num9 = color1.A == byte.MaxValue ? 1 : 0;
            color1 = refEntity2.Color;
            int num10 = color1.R == byte.MaxValue ? 1 : 0;
            int num11 = num9 & num10;
            Color color2 = refEntity2.Color;
            int num12 = color2.G == byte.MaxValue ? 1 : 0;
            int num13 = num11 & num12;
            color2 = refEntity2.Color;
            int num14 = color2.B == byte.MaxValue ? 1 : 0;
            if ((num13 & num14) != 0)
              refEntity2.Color = Color.Black;
            string str2 = refEntity2.LayerName;
            if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, refEntity2.LayerName))
            {
              if (clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, refEntity2.LayerName.Trim()))
              {
                refEntity2.LayerName = refEntity2.LayerName.Trim();
                str2 = refEntity2.LayerName;
              }
              else
                str2 = "Default";
            }
            refEntity2.LayerName = str2;
            if (refEntity2 is Mesh && refEntity2.Color == Color.Black)
              refEntity2.Color = Color.WhiteSmoke;
            if (refEntity2 is ICurve)
            {
              refEntity2.LineWeight = 2f;
              refEntity2.LineWeightMethod = colorMethodType.byEntity;
            }
            if (refEntity2 is Text)
              ((Text) refEntity2).StyleName = Viewport.TextStyles[0].Name;
            clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity2);
            Viewport.Entities.Add(refEntity2);
            refEntities.Add(refEntity2);
          }
        }
        MinPoint1 = new Point3D();
        Point3D MidPoint = new Point3D();
        MaxPoint1 = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint1, ref MidPoint, ref MaxPoint1);
        double num15 = MaxPoint1.X * Result.NestedResultSheets[index3].MaterialHeight;
        if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
          dx = dx + Result.NestedResultSheets[index3].MaterialWidth + clsNesting.ParNest.ResultSettings.DrawNestingResultSpace;
        if (clsNesting.ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
          dy = dy + Result.NestedResultSheets[index3].MaterialHeight + clsNesting.ParNest.ResultSettings.DrawNestingResultSpace;
        if (num1 == num2)
          dy = 0.0;
      }
    }
    Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public void doSaveAllNesting(
    buNestedResult Result,
    int SheetIndex,
    int PartIndex,
    Design Viewport,
    bool isSolid)
  {
    for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index1)
    {
      Layer layer = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index1];
      for (int index2 = 0; index2 <= Viewport.Layers.Count - 1; ++index2)
      {
        if (layer.Name != Viewport.Layers[index2].Name)
          Viewport.Layers.AddOrReplace(new Layer(layer.Name, layer.Color, layer.LineTypeName, layer.LineWeight, layer.Visible));
        else if (layer.Color != Viewport.Layers[index2].Color)
          Viewport.Layers[index2].Color = layer.Color;
      }
    }
    int num1 = 0;
    int num2 = Result.NestedResultSheets.Count - 1;
    if (SheetIndex >= 0)
    {
      num1 = SheetIndex;
      num2 = SheetIndex;
    }
    if (Result.NestedResultSheets.Count > 0)
    {
      double dy = 0.0;
      for (int index3 = num1; index3 <= num2; ++index3)
      {
        Viewport.Entities.Clear();
        List<Entity> calcEntities1 = new List<Entity>();
        List<Entity> UselessEntities = new List<Entity>();
        ccVars.UndoDont = true;
        if (clsNesting.ParNest.ResultSettings.DrawSheets)
        {
          clsInit.cNesting.NestedSheetToEntity(Result.NestedResultSheets[index3], clsNesting.ParNest.ResultSettings.DrawPartAsSolid & isSolid, clsNesting.ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities1, ref UselessEntities);
          if (calcEntities1 != null)
          {
            for (int index4 = 0; index4 <= calcEntities1.Count - 1; ++index4)
            {
              calcEntities1[index4].Translate(0.0, dy);
              Viewport.Entities.Add(calcEntities1[index4]);
              if (UselessEntities != null)
              {
                for (int index5 = 0; index5 <= UselessEntities.Count - 1; ++index5)
                {
                  ccVars.UndoDont = true;
                  UselessEntities[index5].Translate(0.0, dy);
                  Viewport.Entities.Add(UselessEntities[index5]);
                }
              }
            }
          }
        }
        List<Entity> refEntities = new List<Entity>();
        double num3 = 0.0;
        int num4 = 0;
        int num5 = Result.NestedResultSheets[index3].Parts.Count - 1;
        if (PartIndex >= 0)
        {
          num4 = PartIndex;
          num5 = PartIndex;
        }
        for (int index6 = num4; index6 <= num5; ++index6)
        {
          ccVars.UndoDont = true;
          List<Entity> calcEntities2 = new List<Entity>();
          clsInit.cNesting.NestedPartToEntity(Result.NestedResultSheets[index3].Parts[index6], isSolid & clsNesting.ParNest.ResultSettings.DrawPartAsSolid, clsNesting.ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities2);
          List<Point3D> Points = new List<Point3D>();
          List<buEntity> copiedEntities = new List<buEntity>();
          buEntity.Copy(Result.NestedResultSheets[index3].Parts[index6].EntitiesGroup.Outside.Entities, ref copiedEntities);
          EntitiesResolution entitiesResolution = new EntitiesResolution();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(copiedEntities, 0.01, ref Points);
          double num6 = clsInit.cVector5.PolygonArea(Points, Plane.XY);
          num3 += num6;
          for (int index7 = 0; index7 <= calcEntities2.Count - 1; ++index7)
          {
            double dz = 0.0;
            if (calcEntities2[index7].GetType() != typeof (Brep) && clsNesting.ParNest.ResultSettings.DrawPartAsSolid)
              dz = Result.NestedResultSheets[index3].Parts[index6].Thickness + 0.01;
            Entity entity = calcEntities2[index7];
            if (!clsInit.cVector5.IsLayerNameAvailable(Viewport.Layers, entity.LayerName))
              ;
            entity.Translate(0.0, dy, dz);
            Viewport.Entities.Add(entity);
            refEntities.Add(entity);
          }
        }
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
        double num7 = MaxPoint.X * Result.NestedResultSheets[index3].MaterialHeight;
        Viewport.Entities.RegenAllCurved();
        Viewport.Invalidate();
        buFile5.SaveDxfDwg(Viewport, $"{AppPath.Base}\\D_{index3.ToString()}.dxf");
      }
    }
    Viewport.ZoomFit();
    Viewport.Invalidate();
  }

  public void SheetPartUpdate()
  {
    clsNesting.Sheets.Clear();
    clsNesting.Parts.Clear();
    for (int index = 0; index <= clsItem.FrmNestSheetPart.Sheets.Count - 1; ++index)
      clsNesting.Sheets.Add(new buNestingSheet(clsItem.FrmNestSheetPart.Sheets[index]));
    for (int index = 0; index <= clsItem.FrmNestSheetPart.Parts.Count - 1; ++index)
      clsNesting.Parts.Add(new buNestingPart(clsItem.FrmNestSheetPart.Parts[index]));
    clsVar.varInterface.NestingAddPartFromFileExtensionIndex = clsItem.FrmNestSheetPart.AddPartFromFileExtensionIndex;
    clsVar.varInterface.pathNestingAddPart = clsItem.FrmNestSheetPart.AddPartFromFileFolder;
    clsVar.varInterface.pathNestingFiles = clsItem.FrmNestSheetPart.SaveFileFolder;
    clsFiles.SaveParameter();
  }
}
