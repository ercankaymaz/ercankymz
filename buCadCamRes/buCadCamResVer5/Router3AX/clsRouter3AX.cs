// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Router3AX.clsRouter3AX
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Nesting;
using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Materials;
using buMW;
using buMW.CamForms;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Router3AX;

public class clsRouter3AX
{
  public static Router3AXTempVars varTemps = new Router3AXTempVars();
  public static Router3AXSettings varRouter3AXSettings = new Router3AXSettings();
  public static Router3AXDisplaySettings varRouter3AXDisplaySettings = new Router3AXDisplaySettings();
  public static Router3AXRuntimeSettings varRouter3AXRunSettings = new Router3AXRuntimeSettings();
  public Timer timGeneral = (Timer) null;
  public int countGeneral = 0;
  public int SelectedCamIndex = -1;
  public static List<Router3AXItem> JobList = (List<Router3AXItem>) null;
  public Router3AXItem activeJob = (Router3AXItem) null;
  public MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
  public F_CamSequence frmSequence = (F_CamSequence) null;
  public F_CamTable frmTableSelection = (F_CamTable) null;
  public clsYilmazCPM cModeYilmaz = (clsYilmazCPM) null;
  public clsCMD cModeCMD = (clsCMD) null;
  public clsInfinite cModeInfinite = (clsInfinite) null;
  private string string_0 = nameof (clsRouter3AX);
  private string string_1 = "Microsoft Sans Serif";

  public void Init()
  {
    buMWRouter3XVars.Init();
    this.timGeneral = new Timer();
    this.timGeneral.Tick += new EventHandler(this.General_Tick);
    this.timGeneral.Interval = 100;
    this.timGeneral.Enabled = true;
    this.OpenRouter3Xile();
    this.LoadLanguage();
    this.frmSequence = new F_CamSequence();
    this.frmTableSelection = new F_CamTable();
    if (clsVar.appDefination.CustomerID == AppCustomerID.Yilmaz)
      this.cModeYilmaz = new clsYilmazCPM();
    if (clsVar.appDefination.CustomerID == AppCustomerID.CMD)
      this.cModeCMD = new clsCMD();
    if (clsVar.appDefination.CustomerID != AppCustomerID.Infinite)
      return;
    this.cModeInfinite = new clsInfinite();
  }

  public void InitSimulation()
  {
  }

  public void cmdNewJob()
  {
    this.activeJob = new Router3AXItem();
    this.JobUpdate();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    this.DrawJob(new DrawOptions(true), -1);
  }

  public void cmdNewMaterial(CamStock Stock, bool SkipForm = false)
  {
    if (clsItem.FrmMaterial3D == null)
    {
      clsItem.FrmMaterial3D = new F_Material3D();
      CreateModelProperties Properties = new CreateModelProperties();
      clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
      Properties.CoordinateSystemIconVisible = false;
      Properties.ViewCubeIconVisible = false;
      Properties.OrigineCaptionVisible = false;
      Properties.ToolBorVisible = false;
      clsInit.cVector5.CreateModelControl(ref clsItem.FrmMaterial3D.viewportLayout, clsVar.UnlockKey, Properties);
    }
    clsItem.FrmMaterial3D.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmMaterial3D.viewportLayout);
    clsItem.FrmMaterial3D.viewportLayout.Entities.Clear();
    clsItem.FrmMaterial3D.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    if (Stock == null)
    {
      clsItem.FrmMaterial3D.Material = new MaterialBase5(clsRouter3AX.varRouter3AXSettings.SizeStock);
      clsItem.FrmMaterial3D.Init((MaterialBase5) null);
    }
    else
      clsItem.FrmMaterial3D.Init(new MaterialBase5(Stock.SizeStock));
    clsItem.FrmMaterial3D.StartPosition = FormStartPosition.CenterParent;
    if (!SkipForm)
    {
      int num = (int) clsItem.FrmMaterial3D.ShowDialog();
    }
    if (clsItem.FrmMaterial3D.PropertiesForm.Result == DialogResult.OK | SkipForm)
    {
      clsRouter3AX.varRouter3AXSettings.SizeStock = new SizeObject(clsItem.FrmMaterial3D.Material.Size);
      this.activeJob.Stock = new CamStock();
      this.activeJob.Stock.SizeStock = new SizeObject(clsItem.FrmMaterial3D.Material.Size);
      Brep box = Brep.CreateBox(this.activeJob.Stock.SizeStock.Width, this.activeJob.Stock.SizeStock.Height, this.activeJob.Stock.SizeStock.Depth);
      box.Translate(0.0, 0.0);
      box.Regen(0.01);
      box.Rebuild(0.1);
      buMesh buMesh = new buMesh(box.ConvertToMesh(0.01));
      buMesh.typeDefination = entityTypeDefination.Stock;
      this.activeJob.Stock.StockEntities.Add((buEntity) buMesh);
      this.activeJob.Stock.colorStock = new ColorType(clsRouter3AX.varRouter3AXDisplaySettings.colorStock);
      this.activeJob.Stock.MinPoint = new Point3D(box.BoxMin.X, box.BoxMin.Y, box.BoxMin.Z);
      this.activeJob.Stock.MaxPoint = new Point3D(box.BoxMax.X, box.BoxMax.Y, box.BoxMax.Z);
      this.activeJob.Stock.StockName = buLangTranslate.preDef.Stock;
    }
    clsItem.ModelMainPreview.ActiveViewport.DisplayMode = displayType.Flat;
    clsItem.ModelMainPreview.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    clsItem.ModelMainPreview.SetView(viewType.Trimetric);
    clsItem.ModelMainPreview.ZoomFit();
    clsItem.ModelMainPreview.Invalidate();
    this.DrawJob(new DrawOptions(true), -1);
    AppBool.Save = true;
    clsInit.appCommand.cmdViewZoomFit();
  }

  public void cmdCamDrillCommand(CamDrillType Cmd)
  {
    string str = nameof (cmdCamDrillCommand);
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = clsInit.cRouter3AX.CamDrillTypeToAction(Cmd);
      this.MWCalcOptions.NumberofAxis = 3;
      this.MWCalcOptions.CamDrillType = Cmd;
      this.MWCalcOptions.CamDrillMode = CamDrillMode.Point;
      this.MWCalcOptions.AddToCamListInMWCalculation = false;
      this.MWCalcOptions.AddToCamListInLocalCalculation = true;
      this.MWCalcOptions.Mode = CamMode.Drill;
      this.MWCalcOptions.DontShowbuDialogBox = false;
      this.MWCalcOptions.DontApplyReset = true;
      this.MWCalcOptions.ShowProgressForm = true;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsInit.cMwCalc.Settings.ShowProgressForm = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
      }
      else
      {
        ccVars.selectionProcess = false;
        if (Cmd != CamDrillType.Point)
          return;
        this.doDrill(Router3AXLayerPurpose.None, ccVars.toolActive);
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", "", 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void cmdCamWireCommand(CamWireFrameType Cmd)
  {
    string str = nameof (cmdCamWireCommand);
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = clsInit.cRouter3AX.CamWireframeTypeToAction(Cmd);
      this.MWCalcOptions.NumberofAxis = 3;
      this.MWCalcOptions.CamWireframeType = Cmd;
      this.MWCalcOptions.AddToCamListInMWCalculation = false;
      this.MWCalcOptions.AddToCamListInLocalCalculation = true;
      this.MWCalcOptions.Mode = CamMode.WireFrame;
      this.MWCalcOptions.DontShowbuDialogBox = false;
      this.MWCalcOptions.DontApplyReset = true;
      this.MWCalcOptions.ShowProgressForm = true;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsInit.cMwCalc.Settings.ShowProgressForm = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
      }
      else
      {
        ccVars.selectionProcess = false;
        if (Cmd == CamWireFrameType.Contour)
          this.doWireframeContour(Router3AXLayerPurpose.None, ccVars.toolActive);
        if (Cmd == CamWireFrameType.Pocket)
          this.doWireframePocket(Router3AXLayerPurpose.None, ccVars.toolActive);
        if (Cmd != CamWireFrameType.CenterPath)
          return;
        this.doWireframeCenterPath(Router3AXLayerPurpose.None, ccVars.toolActive);
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", "", 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void cmdCamMeshCommand(CamTriangularMeshType Cmd)
  {
    string str = nameof (cmdCamMeshCommand);
    try
    {
      if (!clsVar.appModes_0.CompositeMode.MeshEnabled)
      {
        buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
      }
      else
      {
        if (!clsVar.appModes_0.CompositeMode.MeshAdvanced)
        {
          if (Cmd == CamTriangularMeshType.Flatlands)
          {
            buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
            return;
          }
          if (Cmd == CamTriangularMeshType.Pencil)
          {
            buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
            return;
          }
        }
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
        ccVars.Action = clsInit.cRouter3AX.CamMeshTypeToAction(Cmd);
        this.MWCalcOptions.NumberofAxis = 3;
        this.MWCalcOptions.CamTriMeshType = Cmd;
        this.MWCalcOptions.AddToCamListInMWCalculation = false;
        this.MWCalcOptions.AddToCamListInLocalCalculation = true;
        this.MWCalcOptions.Mode = CamMode.TriangularMesh;
        this.MWCalcOptions.DontShowbuDialogBox = false;
        this.MWCalcOptions.DontApplyReset = true;
        this.MWCalcOptions.ShowProgressForm = true;
        dynamicInfo.Command = AppLanguage.CadCamCommand[36];
        ccVars.selectionProcess = true;
        clsInit.cMwCalc.Settings.ShowProgressForm = true;
        if (ccVars.SelectionOP.Selections.Count == 0)
        {
          ccVars.stpDrawing = 2;
        }
        else
        {
          ccVars.selectionProcess = false;
          this.doTriangularMesh3AX(Cmd, ccVars.toolActive);
        }
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", "", 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void cmdCamMesh5AXCommand(CamTriangularMesh5AxType Cmd)
  {
    string str = nameof (cmdCamMesh5AXCommand);
    try
    {
      if (!clsVar.appModes_0.CompositeMode.MeshEnabled)
        buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
      else if (!clsVar.appModes_0.CompositeMode.Surface5Axis)
      {
        buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
        ccVars.Action = clsInit.cRouter3AX.CamMeshTypeToAction(Cmd);
        this.MWCalcOptions.NumberofAxis = 5;
        this.MWCalcOptions.CamTriMesh5AXType = Cmd;
        this.MWCalcOptions.AddToCamListInMWCalculation = false;
        this.MWCalcOptions.AddToCamListInLocalCalculation = true;
        this.MWCalcOptions.Mode = CamMode.TriangularMesh;
        this.MWCalcOptions.DontShowbuDialogBox = false;
        this.MWCalcOptions.DontApplyReset = true;
        this.MWCalcOptions.ShowProgressForm = true;
        dynamicInfo.Command = AppLanguage.CadCamCommand[36];
        ccVars.selectionProcess = true;
        clsInit.cMwCalc.Settings.ShowProgressForm = true;
        if (ccVars.SelectionOP.Selections.Count == 0)
        {
          ccVars.stpDrawing = 2;
        }
        else
        {
          ccVars.selectionProcess = false;
          this.doTriangularMesh5AX(Cmd, ccVars.toolActive);
        }
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", "", 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void cmdCamSurfaceCommand(CamSurfaceType Cmd)
  {
    string str = nameof (cmdCamSurfaceCommand);
    try
    {
      if (!clsVar.appModes_0.CompositeMode.Surface5Axis)
        ;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Action = clsInit.cRouter3AX.CamSurfaceTypeToAction(Cmd);
      this.MWCalcOptions.NumberofAxis = 3;
      this.MWCalcOptions.CamSurfType = Cmd;
      this.MWCalcOptions.AddToCamListInMWCalculation = false;
      this.MWCalcOptions.AddToCamListInLocalCalculation = true;
      this.MWCalcOptions.Mode = CamMode.Surface;
      this.MWCalcOptions.DontShowbuDialogBox = false;
      this.MWCalcOptions.DontApplyReset = true;
      this.MWCalcOptions.ShowProgressForm = true;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsInit.cMwCalc.Settings.ShowProgressForm = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
      }
      else
      {
        ccVars.selectionProcess = false;
        this.doSurface5AX(Cmd, ccVars.toolActive);
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", "", 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void cmdMenuCommand(object sender, EventArgs e)
  {
    string str = "";
    if (sender is System.Windows.Forms.Control)
      str = (sender as System.Windows.Forms.Control).Name;
    else if (sender is ToolStripMenuItem)
      str = (sender as ToolStripMenuItem).Name;
    if (str == clsItem.FrmRouter3AXJob.mnu_camdelete.Name)
      this.doCamDelete();
    if (str == clsItem.FrmRouter3AXJob.mnu_camdeleteall.Name)
      this.doCamDeleteAll();
    if (str == clsItem.FrmRouter3AXJob.mnu_camedit.Name)
      this.doCamEdit();
    if (str == clsItem.FrmRouter3AXJob.mnu_camedittool.Name)
      this.doCamToolEdit();
    if (str == clsItem.FrmRouter3AXJob.mnu_camenabledisable.Name)
      this.doCamEnableDisable();
    if (str == clsItem.FrmRouter3AXJob.mnu_camrename.Name)
      this.doCamRename();
    if (str == clsItem.FrmRouter3AXJob.mnu_down.Name)
      this.doCamMoveDown();
    if (str == clsItem.FrmRouter3AXJob.mnu_up.Name)
      this.doCamMoveUp();
    if (!(str == clsItem.FrmRouter3AXJob.mnu_redraw.Name))
      return;
    this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
    this.UpdateDrawJob(this.SelectedCamIndex);
  }

  public void cmdSimStart() => clsInit.appCommand.simStart();

  public void cmdSimStop() => clsInit.appCommand.simStop();

  public void cmdSimNext() => clsInit.appCommand.simNext();

  public void cmdSimPre() => clsInit.appCommand.simPre();

  public void cmdSettings()
  {
    F_ClassViewerDialog5 classViewerDialog5 = new F_ClassViewerDialog5();
    classViewerDialog5.FormCaption = buLangTranslate.preDef.Setting;
    classViewerDialog5.Value = (object) clsRouter3AX.varRouter3AXSettings;
    classViewerDialog5.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog5.Width = 500;
    classViewerDialog5.Height = 750;
    classViewerDialog5.ValuePersentage = 35.0;
    classViewerDialog5.Init();
    int num = (int) classViewerDialog5.ShowDialog();
    if (classViewerDialog5.Result != DialogResult.OK)
      return;
    clsRouter3AX.varRouter3AXSettings = new Router3AXSettings((Router3AXSettings) classViewerDialog5.Value);
    this.SaveRouter3XFile();
  }

  public void cmdSettingsDisplay()
  {
    F_ClassViewerDialog5 classViewerDialog5 = new F_ClassViewerDialog5();
    classViewerDialog5.FormCaption = $"{buLangTranslate.preDef.Setting} {buLangTranslate.preDef.Display}";
    classViewerDialog5.Value = (object) clsRouter3AX.varRouter3AXDisplaySettings;
    classViewerDialog5.StartPosition = FormStartPosition.CenterParent;
    classViewerDialog5.Width = 500;
    classViewerDialog5.Height = 750;
    classViewerDialog5.ValuePersentage = 35.0;
    classViewerDialog5.Init();
    int num = (int) classViewerDialog5.ShowDialog();
    if (classViewerDialog5.Result != DialogResult.OK)
      return;
    clsRouter3AX.varRouter3AXDisplaySettings = new Router3AXDisplaySettings((Router3AXDisplaySettings) classViewerDialog5.Value);
    this.SaveRouter3XFile();
    this.DrawJob(new DrawOptions(true, true, true), this.SelectedCamIndex);
  }

  public void cmdSettingsMilling2D(CamType CamType)
  {
    if (CamType == CamType.PocketCircular | CamType == CamType.PocketFlat)
    {
      F_WFRough fWfRough = new F_WFRough();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfRough.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeRough.mwPar.Units, 0);
      fWfRough.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeRough.mwPar, fWfRough.mwCamParameter);
      fWfRough.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeRough.buPar);
      fWfRough.Text = buLangTranslate.preDef.Contour;
      fWfRough.Configration = new MWCalculationOptions(data);
      fWfRough.Init();
      int num = (int) fWfRough.ShowDialog();
      if (fWfRough.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam = new MachiningParams(fWfRough.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfRough.mwCamParameter, buMWRouter3XVars.varCamWireframeRough.mwPar);
        buMWRouter3XVars.varCamWireframeRough.buPar = new camParameters5(fWfRough.buCamParameter);
      }
    }
    if (CamType == CamType.Center)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCenterPath.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCenterPath.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCenterPath.buPar);
      fWfContour.Text = buLangTranslate.preDef.Contour;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCenterPath.mwPar);
        buMWRouter3XVars.varCamWireframeCenterPath.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.Contour)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeContour.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeContour.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeContour.buPar);
      fWfContour.Text = buLangTranslate.preDef.Contour;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeContour.mwPar);
        buMWRouter3XVars.varCamWireframeContour.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.Chamfer)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeChamfer.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeChamfer.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeChamfer.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeChamfer.buPar);
      fWfContour.Text = buLangTranslate.preDef.Chamfer;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeChamfer.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeChamfer.mwPar);
        buMWRouter3XVars.varCamWireframeChamfer.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.Engrave)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeEngrave.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeEngrave.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeEngrave.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeEngrave.buPar);
      fWfContour.Text = buLangTranslate.preDef.Engrave;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeEngrave.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeEngrave.mwPar);
        buMWRouter3XVars.varCamWireframeEngrave.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.Face)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeFace.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeFace.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeFace.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeFace.buPar);
      fWfContour.Text = buLangTranslate.preDef.Face;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeFace.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeFace.mwPar);
        buMWRouter3XVars.varCamWireframeFace.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.FloorFinishing)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeFloorFinish.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeFloorFinish.buPar);
      fWfContour.Text = buLangTranslate.preDef.FloorFinish;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeFloorFinish.mwPar);
        buMWRouter3XVars.varCamWireframeFloorFinish.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.TextEngrave)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeTextEngrave.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeTextEngrave.buPar);
      fWfContour.Text = buLangTranslate.preDef.TextEngrave;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeTextEngrave.mwPar);
        buMWRouter3XVars.varCamWireframeTextEngrave.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.Trochoidal)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeTrochoidial.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeTrochoidial.buPar);
      fWfContour.Text = buLangTranslate.preDef.Trochoidal;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeTrochoidial.mwPar);
        buMWRouter3XVars.varCamWireframeTrochoidial.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (CamType == CamType.Drill)
    {
      F_DrillLine fDrillLine = new F_DrillLine();
      MWCalculationOptions data = new MWCalculationOptions();
      fDrillLine.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeDrill.mwPar.Units, 0);
      fDrillLine.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeDrill.mwPar, fDrillLine.mwCamParameter);
      fDrillLine.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeDrill.buPar);
      fDrillLine.Text = buLangTranslate.preDef.Trochoidal;
      fDrillLine.Configration = new MWCalculationOptions(data);
      fDrillLine.Init();
      int num = (int) fDrillLine.ShowDialog();
      if (fDrillLine.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam = new MachiningParams(fDrillLine.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fDrillLine.mwCamParameter, buMWRouter3XVars.varCamWireframeDrill.mwPar);
        buMWRouter3XVars.varCamWireframeDrill.buPar = new camParameters5(fDrillLine.buCamParameter);
      }
    }
    this.SaveRouter3XFile();
  }

  public void cmdSettingsMilling3D(CamTriangularMeshType CamType)
  {
    if (CamType == CamTriangularMeshType.Rough)
    {
      F_TriMeshRough fTriMeshRough = new F_TriMeshRough();
      MWCalculationOptions data = new MWCalculationOptions();
      fTriMeshRough.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshRough.mwPar.Units, 0);
      fTriMeshRough.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshRough.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshRough.mwPar, fTriMeshRough.mwCamParameter);
      fTriMeshRough.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshRough.buPar);
      fTriMeshRough.Text = buLangTranslate.preDef.Rough;
      fTriMeshRough.Configration = new MWCalculationOptions(data);
      fTriMeshRough.Init();
      int num = (int) fTriMeshRough.ShowDialog();
      if (fTriMeshRough.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamMeshRough.mwPar.MachParam = new MachiningParams(fTriMeshRough.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fTriMeshRough.mwCamParameter, buMWRouter3XVars.varCamMeshRough.mwPar);
        buMWRouter3XVars.varCamMeshRough.buPar = new camParameters5(fTriMeshRough.buCamParameter);
      }
    }
    if (CamType == CamTriangularMeshType.ParallelCuts)
    {
      F_TriMeshParallelCut triMeshParallelCut = new F_TriMeshParallelCut();
      MWCalculationOptions data = new MWCalculationOptions();
      triMeshParallelCut.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshParallel.mwPar.Units, 0);
      triMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshParallel.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshParallel.mwPar, triMeshParallelCut.mwCamParameter);
      triMeshParallelCut.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshParallel.buPar);
      triMeshParallelCut.Text = buLangTranslate.preDef.ParalelCuts;
      triMeshParallelCut.Configration = new MWCalculationOptions(data);
      triMeshParallelCut.Init();
      int num = (int) triMeshParallelCut.ShowDialog();
      if (triMeshParallelCut.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamMeshParallel.mwPar.MachParam = new MachiningParams(triMeshParallelCut.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(triMeshParallelCut.mwCamParameter, buMWRouter3XVars.varCamMeshParallel.mwPar);
        buMWRouter3XVars.varCamMeshParallel.buPar = new camParameters5(triMeshParallelCut.buCamParameter);
      }
    }
    if (CamType == CamTriangularMeshType.ConstantZ)
    {
      F_TriMeshConstantZ triMeshConstantZ = new F_TriMeshConstantZ();
      MWCalculationOptions data = new MWCalculationOptions();
      triMeshConstantZ.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshConstantZ.mwPar.Units, 0);
      triMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshConstantZ.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshConstantZ.mwPar, triMeshConstantZ.mwCamParameter);
      triMeshConstantZ.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshConstantZ.buPar);
      triMeshConstantZ.Text = buLangTranslate.preDef.ConstantZ;
      triMeshConstantZ.Configration = new MWCalculationOptions(data);
      triMeshConstantZ.Init();
      int num = (int) triMeshConstantZ.ShowDialog();
      if (triMeshConstantZ.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamMeshConstantZ.mwPar.MachParam = new MachiningParams(triMeshConstantZ.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(triMeshConstantZ.mwCamParameter, buMWRouter3XVars.varCamMeshConstantZ.mwPar);
        buMWRouter3XVars.varCamMeshConstantZ.buPar = new camParameters5(triMeshConstantZ.buCamParameter);
      }
    }
    if (CamType == CamTriangularMeshType.Flatlands)
    {
      F_TriMeshConstantZ triMeshConstantZ = new F_TriMeshConstantZ();
      MWCalculationOptions data = new MWCalculationOptions();
      triMeshConstantZ.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshFlatLand.mwPar.Units, 0);
      triMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshFlatLand.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshFlatLand.mwPar, triMeshConstantZ.mwCamParameter);
      triMeshConstantZ.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshFlatLand.buPar);
      triMeshConstantZ.Text = buLangTranslate.preDef.Flatlands;
      triMeshConstantZ.Configration = new MWCalculationOptions(data);
      triMeshConstantZ.Init();
      int num = (int) triMeshConstantZ.ShowDialog();
      if (triMeshConstantZ.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamMeshFlatLand.mwPar.MachParam = new MachiningParams(triMeshConstantZ.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(triMeshConstantZ.mwCamParameter, buMWRouter3XVars.varCamMeshFlatLand.mwPar);
        buMWRouter3XVars.varCamMeshFlatLand.buPar = new camParameters5(triMeshConstantZ.buCamParameter);
      }
    }
    if (CamType == CamTriangularMeshType.Pencil)
    {
      F_TriMeshConstantZ triMeshConstantZ = new F_TriMeshConstantZ();
      MWCalculationOptions data = new MWCalculationOptions();
      triMeshConstantZ.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshPencil.mwPar.Units, 0);
      triMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshPencil.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshPencil.mwPar, triMeshConstantZ.mwCamParameter);
      triMeshConstantZ.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshPencil.buPar);
      triMeshConstantZ.Text = buLangTranslate.preDef.Pencil;
      triMeshConstantZ.Configration = new MWCalculationOptions(data);
      triMeshConstantZ.Init();
      int num = (int) triMeshConstantZ.ShowDialog();
      if (triMeshConstantZ.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamMeshPencil.mwPar.MachParam = new MachiningParams(triMeshConstantZ.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(triMeshConstantZ.mwCamParameter, buMWRouter3XVars.varCamMeshPencil.mwPar);
        buMWRouter3XVars.varCamMeshPencil.buPar = new camParameters5(triMeshConstantZ.buCamParameter);
      }
    }
    this.SaveRouter3XFile();
  }

  public void cmdSettingsComposite(ToolPurpose Tool)
  {
    if (Tool == ToolPurpose.Cutting)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      buMWRouter3XVars.varCamWireframeCompCutting.buPar.Operations.isClosed = true;
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutting.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutting.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutting.buPar);
      fWfContour.Text = buLangTranslate.preDef.Cutting;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutting.mwPar);
        buMWRouter3XVars.varCamWireframeCompCutting.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (Tool == ToolPurpose.Derz)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      buMWRouter3XVars.varCamWireframeCompGrove.buPar.Operations.isClosed = false;
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompGrove.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompGrove.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompGrove.buPar);
      fWfContour.Text = buLangTranslate.preDef.Center;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCompGrove.mwPar);
        buMWRouter3XVars.varCamWireframeCompGrove.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (Tool == ToolPurpose.CutCenter)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Operations.isClosed = false;
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutCenter.buPar);
      fWfContour.Text = buLangTranslate.preDef.Center;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar);
        buMWRouter3XVars.varCamWireframeCompCutCenter.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (Tool == ToolPurpose.CutIn)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Operations.isClosed = true;
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutInside.buPar);
      fWfContour.Text = buLangTranslate.preDef.Inside;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutInside.mwPar);
        buMWRouter3XVars.varCamWireframeCompCutInside.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (Tool == ToolPurpose.CutOut)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Operations.isClosed = true;
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutOutside.buPar);
      fWfContour.Text = buLangTranslate.preDef.Outside;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar);
        buMWRouter3XVars.varCamWireframeCompCutOutside.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    if (Tool == ToolPurpose.PocketCircular | Tool == ToolPurpose.PocketFlat)
    {
      F_WFRough fWfRough = new F_WFRough();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfRough.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompPocket.mwPar.Units, 0);
      fWfRough.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompPocket.mwPar, fWfRough.mwCamParameter);
      fWfRough.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompPocket.buPar);
      fWfRough.Text = buLangTranslate.preDef.Pocket;
      fWfRough.Configration = new MWCalculationOptions(data);
      fWfRough.Init();
      int num = (int) fWfRough.ShowDialog();
      if (fWfRough.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam = new MachiningParams(fWfRough.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfRough.mwCamParameter, buMWRouter3XVars.varCamWireframeCompPocket.mwPar);
        buMWRouter3XVars.varCamWireframeCompPocket.buPar = new camParameters5(fWfRough.buCamParameter);
      }
    }
    if (Tool == ToolPurpose.Text)
    {
      F_WFContour fWfContour = new F_WFContour();
      MWCalculationOptions data = new MWCalculationOptions();
      fWfContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompText.mwPar.Units, 0);
      fWfContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam);
      buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompText.mwPar, fWfContour.mwCamParameter);
      fWfContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompText.buPar);
      fWfContour.Text = buLangTranslate.preDef.Text;
      fWfContour.Configration = new MWCalculationOptions(data);
      fWfContour.Init();
      int num = (int) fWfContour.ShowDialog();
      if (fWfContour.PropertiesForm.Result == DialogResult.OK)
      {
        buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam = new MachiningParams(fWfContour.mwCamParameter.MachParam);
        buMWCalcs.CopyGeoLibProperties(fWfContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCompText.mwPar);
        buMWRouter3XVars.varCamWireframeCompText.buPar = new camParameters5(fWfContour.buCamParameter);
      }
    }
    this.SaveRouter3XFile();
  }

  public void cmdSequence()
  {
    this.frmSequence.Properties.FormCloseMode = FormCloseModeType.Invisible;
    this.frmSequence.Properties.FormPosition = FormStartPosition.CenterParent;
    this.frmSequence.SourceList.Clear();
    this.frmSequence.SourceList.AddRange((IEnumerable<string>) buConversion5.EnumToString(typeof (Router3AXLayerPurpose)));
    this.frmSequence.TargetList.Clear();
    this.frmSequence.TargetList.AddRange((IEnumerable<string>) buString5.Copy(clsRouter3AX.varRouter3AXRunSettings.SequenceList));
    this.frmSequence.Init();
    int num = (int) this.frmSequence.ShowDialog();
    if (this.frmSequence.Properties.Result != DialogResult.OK)
      return;
    clsRouter3AX.varRouter3AXRunSettings.SequenceList.Clear();
    clsRouter3AX.varRouter3AXRunSettings.SequenceList.AddRange((IEnumerable<string>) buString5.Copy(this.frmSequence.TargetList));
    this.SaveRouter3XFile();
  }

  public void cmdShowCode(bool SaveFile)
  {
    if (clsVar.appModes_0.DemoMode)
      buString5.MessageBoxWarning(buLangTranslate.preSentences.NotAvailableDemoMode);
    else if (ccVars.Pages.Count <= 0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentences.NoPageOpened);
    }
    else
    {
      if (clsVar.appDefination.CustomerID == AppCustomerID.Yilmaz && this.cModeYilmaz != null)
        this.cModeYilmaz.cmdShowCode(SaveFile);
      if (clsVar.appDefination.CustomerID == AppCustomerID.CMD && this.cModeCMD != null)
        this.cModeCMD.cmdShowCode(SaveFile);
      if (clsVar.appDefination.CustomerID != AppCustomerID.Infinite || this.cModeInfinite == null)
        return;
      this.cModeInfinite.cmdShowCode(SaveFile);
    }
  }

  public void UpdateDrawJob(int selectedCam)
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
      if (entity.EntityData != null && entity.EntityData is CustomData)
      {
        CustomData entityData = entity.EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Plane)
        {
          entity.Visible = entityData.RefIndex == selectedCam;
          if (!this.activeJob.CamList[entityData.RefIndex].Enable)
            entity.Visible = false;
        }
        if (clsInit.cVector5.isEntityCamEntity(entity))
        {
          entity.Visible = entityData.RefIndex == selectedCam | selectedCam == -1;
          if (!this.activeJob.CamList[entityData.RefIndex].Enable)
            entity.Visible = false;
        }
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void DrawJob(DrawOptions Options, int selectedCam)
  {
    if (Options.DrawAll)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if (clsInit.cVector5.isEntityCamEntity(entity))
          entity.Selected = true;
        if (clsInit.cVector5.isEntityToolEntity(entity))
          entity.Selected = true;
        if (clsInit.cVector5.isEntityStockEntity(entity))
          entity.Selected = true;
        if (clsInit.cVector5.isEntityPlaneEntity(entity))
          entity.Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      if (this.activeJob.Stock != null)
      {
        for (int index = 0; index <= this.activeJob.Stock.StockEntities.Count - 1; ++index)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(this.activeJob.Stock.StockEntities[index], ref copiedEntity);
          copiedEntity.Color = Color.FromArgb(this.activeJob.Stock.colorStock.Transperancy, this.activeJob.Stock.colorStock.Color);
          copiedEntity.ColorMethod = colorMethodType.byEntity;
          copiedEntity.LineTypeMethod = colorMethodType.byEntity;
          copiedEntity.Selectable = false;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
        }
      }
      for (int index1 = 0; index1 <= this.activeJob.CamList.Count - 1; ++index1)
      {
        Router3AXCAM cam = this.activeJob.CamList[index1];
        string LayerName1 = clsRouter3AX.varTemps.layerCamPlane;
        if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, LayerName1))
          LayerName1 = "Default";
        if (cam.entitiesPlane != null)
        {
          Entity entPlane = (Entity) null;
          Entity entText = (Entity) null;
          clsInit.cRouter3AX.CreatePlaneEntities(cam.entitiesPlane.entityPlaneBottom, cam.entitiesPlane.entityPlaneBottomText, CamPlaneHeightType.Bottom, index1, clsRouter3AX.varRouter3AXDisplaySettings, ref entPlane, ref entText);
          if (index1 != selectedCam)
          {
            if (entPlane != null)
              entPlane.Visible = false;
            if (entText != null)
              entText.Visible = false;
          }
          if (entPlane != null)
          {
            entPlane.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
          }
          if (entText != null)
          {
            entText.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
          }
          entPlane = (Entity) null;
          entText = (Entity) null;
          clsInit.cRouter3AX.CreatePlaneEntities(cam.entitiesPlane.entityPlaneTop, cam.entitiesPlane.entityPlaneTopText, CamPlaneHeightType.Top, index1, clsRouter3AX.varRouter3AXDisplaySettings, ref entPlane, ref entText);
          if (index1 != selectedCam)
          {
            if (entPlane != null)
              entPlane.Visible = false;
            if (entText != null)
              entText.Visible = false;
          }
          if (entPlane != null)
          {
            entPlane.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
          }
          if (entText != null)
          {
            entText.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
          }
          entPlane = (Entity) null;
          entText = (Entity) null;
          clsInit.cRouter3AX.CreatePlaneEntities(cam.entitiesPlane.entityPlaneRetract, cam.entitiesPlane.entityPlaneRetractText, CamPlaneHeightType.Retract, index1, clsRouter3AX.varRouter3AXDisplaySettings, ref entPlane, ref entText);
          if (index1 != selectedCam)
          {
            if (entPlane != null)
              entPlane.Visible = false;
            if (entText != null)
              entText.Visible = false;
          }
          if (entPlane != null)
          {
            entPlane.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
          }
          if (entText != null)
          {
            entText.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
          }
          entPlane = (Entity) null;
          entText = (Entity) null;
          clsInit.cRouter3AX.CreatePlaneEntities(cam.entitiesPlane.entityPlaneClearance, cam.entitiesPlane.entityPlaneClearanceText, CamPlaneHeightType.Clearance, index1, clsRouter3AX.varRouter3AXDisplaySettings, ref entPlane, ref entText);
          if (index1 != selectedCam)
          {
            if (entPlane != null)
              entPlane.Visible = false;
            if (entText != null)
              entText.Visible = false;
          }
          if (entPlane != null)
          {
            entPlane.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
          }
          if (entText != null)
          {
            entText.LayerName = LayerName1;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
          }
        }
        string LayerName2 = clsRouter3AX.varTemps.layerWireframe;
        if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, LayerName2))
          LayerName2 = "Default";
        for (int index2 = 0; index2 <= cam.CamEntities.Count - 1; ++index2)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(cam.CamEntities[index2], ref copiedEntity);
          ((CustomData) copiedEntity.EntityData).typeDefination = entityTypeDefination.Cam;
          ((CustomData) copiedEntity.EntityData).RefIndex = index1;
          copiedEntity.Color = clsRouter3AX.varRouter3AXDisplaySettings.colorCamBase.Color;
          copiedEntity.LineWeight = (float) clsRouter3AX.varRouter3AXDisplaySettings.colorCamBase.Thickess;
          copiedEntity.ColorMethod = colorMethodType.byEntity;
          copiedEntity.LineWeightMethod = colorMethodType.byEntity;
          copiedEntity.Selectable = false;
          copiedEntity.LayerName = LayerName2;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
        }
        string LayerName3 = clsRouter3AX.varTemps.layerCam;
        if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, LayerName3))
          LayerName3 = "Default";
        if (clsVar.varCam.ShowCamG0Drawings)
        {
          for (int index3 = 0; index3 <= cam.CamData.EntitiesG0.Count - 1; ++index3)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(cam.CamData.EntitiesG0[index3], ref copiedEntity);
            ((CustomData) copiedEntity.EntityData).typeDefination = entityTypeDefination.CamG0;
            ((CustomData) copiedEntity.EntityData).RefIndex = index1;
            copiedEntity.Color = clsRouter3AX.varRouter3AXDisplaySettings.colorCamG0.Color;
            copiedEntity.LineWeight = (float) clsRouter3AX.varRouter3AXDisplaySettings.colorCamG0.Thickess;
            copiedEntity.ColorMethod = colorMethodType.byEntity;
            copiedEntity.LineWeightMethod = colorMethodType.byEntity;
            copiedEntity.Selectable = false;
            copiedEntity.LayerName = LayerName3;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
          }
        }
        if (clsVar.varCam.ShowCamG1Drawings)
        {
          for (int index4 = 0; index4 <= cam.CamData.EntitiesG1.Count - 1; ++index4)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(cam.CamData.EntitiesG1[index4], ref copiedEntity);
            ((CustomData) copiedEntity.EntityData).typeDefination = entityTypeDefination.CamG1;
            ((CustomData) copiedEntity.EntityData).RefIndex = index1;
            copiedEntity.Color = clsRouter3AX.varRouter3AXDisplaySettings.colorCamG1.Color;
            copiedEntity.LineWeight = (float) clsRouter3AX.varRouter3AXDisplaySettings.colorCamG1.Thickess;
            copiedEntity.ColorMethod = colorMethodType.byEntity;
            copiedEntity.LineWeightMethod = colorMethodType.byEntity;
            copiedEntity.Selectable = false;
            copiedEntity.LayerName = LayerName3;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
          }
        }
        if (clsVar.varCam.ShowCamLeaveDrawings)
        {
          for (int index5 = 0; index5 <= cam.CamData.EntitiesLeave.Count - 1; ++index5)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(cam.CamData.EntitiesLeave[index5], ref copiedEntity);
            ((CustomData) copiedEntity.EntityData).typeDefination = entityTypeDefination.CamLeave;
            ((CustomData) copiedEntity.EntityData).RefIndex = index1;
            copiedEntity.Color = clsRouter3AX.varRouter3AXDisplaySettings.colorCamLeave.Color;
            copiedEntity.LineWeight = (float) clsRouter3AX.varRouter3AXDisplaySettings.colorCamLeave.Thickess;
            copiedEntity.ColorMethod = colorMethodType.byEntity;
            copiedEntity.LineWeightMethod = colorMethodType.byEntity;
            copiedEntity.Selectable = false;
            copiedEntity.LayerName = LayerName3;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
          }
        }
        if (clsVar.varCam.ShowCamPlungeDrawings)
        {
          for (int index6 = 0; index6 <= cam.CamData.EntitiesPlunge.Count - 1; ++index6)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(cam.CamData.EntitiesPlunge[index6], ref copiedEntity);
            ((CustomData) copiedEntity.EntityData).typeDefination = entityTypeDefination.CamPlunge;
            ((CustomData) copiedEntity.EntityData).RefIndex = index1;
            copiedEntity.Color = clsRouter3AX.varRouter3AXDisplaySettings.colorCamPlunge.Color;
            copiedEntity.LineWeight = (float) clsRouter3AX.varRouter3AXDisplaySettings.colorCamPlunge.Thickess;
            copiedEntity.ColorMethod = colorMethodType.byEntity;
            copiedEntity.LineWeightMethod = colorMethodType.byEntity;
            copiedEntity.Selectable = false;
            copiedEntity.LayerName = LayerName3;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
          }
        }
        if (clsVar.varCam.ShowCamLeadinDrawings)
        {
          for (int index7 = 0; index7 <= cam.CamData.EntitiesLeadIn.Count - 1; ++index7)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(cam.CamData.EntitiesLeadIn[index7], ref copiedEntity);
            ((CustomData) copiedEntity.EntityData).typeDefination = entityTypeDefination.CamLeadin;
            ((CustomData) copiedEntity.EntityData).RefIndex = index1;
            copiedEntity.Color = clsRouter3AX.varRouter3AXDisplaySettings.colorCamLeadIn.Color;
            copiedEntity.LineWeight = (float) clsRouter3AX.varRouter3AXDisplaySettings.colorCamLeadIn.Thickess;
            copiedEntity.ColorMethod = colorMethodType.byEntity;
            copiedEntity.LineWeightMethod = colorMethodType.byEntity;
            copiedEntity.Selectable = false;
            copiedEntity.LayerName = LayerName3;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
          }
        }
        if (clsVar.varCam.ShowCamLeadOutDrawings)
        {
          for (int index8 = 0; index8 <= cam.CamData.EntitiesLeadOut.Count - 1; ++index8)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(cam.CamData.EntitiesLeadOut[index8], ref copiedEntity);
            ((CustomData) copiedEntity.EntityData).typeDefination = entityTypeDefination.CamLeadOut;
            ((CustomData) copiedEntity.EntityData).RefIndex = index1;
            copiedEntity.Color = clsRouter3AX.varRouter3AXDisplaySettings.colorCamLeadOut.Color;
            copiedEntity.LineWeight = (float) clsRouter3AX.varRouter3AXDisplaySettings.colorCamLeadOut.Thickess;
            copiedEntity.ColorMethod = colorMethodType.byEntity;
            copiedEntity.LineWeightMethod = colorMethodType.byEntity;
            copiedEntity.Selectable = false;
            copiedEntity.LayerName = LayerName3;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
          }
        }
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
    TreeNodeSettings selectedNode = (TreeNodeSettings) ((TreeView) sender).SelectedNode;
    switch (selectedNode.Command)
    {
      case "Base":
        if (selectedNode.ClassIndex >= 0)
        {
          this.SelectedCamIndex = -1;
          break;
        }
        break;
      case "Stock":
        if (selectedNode.ClassIndex >= 0)
        {
          this.SelectedCamIndex = -1;
          break;
        }
        break;
      case "Cam":
        if (selectedNode.ClassIndex >= 0)
        {
          this.SelectedCamIndex = selectedNode.ClassSubIndex;
          break;
        }
        break;
      case "Tool":
        if (selectedNode.ClassIndex >= 0)
        {
          this.SelectedCamIndex = selectedNode.ClassSubIndex;
          break;
        }
        break;
      case "Info":
        if (selectedNode.ClassIndex >= 0)
        {
          this.SelectedCamIndex = selectedNode.ClassSubIndex;
          break;
        }
        break;
    }
    this.UpdateDrawJob(this.SelectedCamIndex);
  }

  public void JobUpdate()
  {
    try
    {
      if (clsItem.FrmRouter3AXJob == null)
        return;
      string str1 = AppLanguage.CadCamDynamic[114];
      string str2 = AppLanguage.CadCamDynamic[108];
      string str3 = AppLanguage.CadCamDynamic[107] + " - ";
      string str4 = AppLanguage.CadCamDynamic[106];
      string str5 = AppLanguage.CadCamDynamic[112 /*0x70*/];
      clsItem.FrmRouter3AXJob.tree_jobs.Nodes.Clear();
      TreeNodeSettings treeNodeSettings1 = new TreeNodeSettings(clsInit.cRouter3AX.JobToString(this.activeJob));
      treeNodeSettings1.ImageIndex = 0;
      treeNodeSettings1.SelectedImageIndex = 0;
      treeNodeSettings1.Tag = (object) "0";
      treeNodeSettings1.ClassIndex = 0;
      treeNodeSettings1.ClassSubIndex = -1;
      treeNodeSettings1.ClassSubSubIndex = -1;
      treeNodeSettings1.Command = "Base";
      treeNodeSettings1.Info = "";
      treeNodeSettings1.Checked = true;
      TreeNodeSettings node1 = treeNodeSettings1;
      node1.NodeFont = new Font(this.string_1, 10f, FontStyle.Regular);
      node1.ForeColor = Color.Black;
      TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings(clsInit.cRouter3AX.JobStockToString(this.activeJob));
      treeNodeSettings2.ImageIndex = 1;
      treeNodeSettings2.SelectedImageIndex = 1;
      treeNodeSettings2.Tag = (object) "";
      treeNodeSettings2.ClassIndex = 0;
      treeNodeSettings2.ClassSubIndex = 0;
      treeNodeSettings2.ClassSubSubIndex = -1;
      treeNodeSettings2.Command = "Stock";
      treeNodeSettings2.Info = "Stock";
      treeNodeSettings2.Checked = true;
      TreeNodeSettings node2 = treeNodeSettings2;
      node2.NodeFont = new Font(this.string_1, 8f, FontStyle.Regular);
      node2.ForeColor = Color.Black;
      node1.Nodes.Add((TreeNode) node2);
      for (int index = 0; index <= this.activeJob.CamList.Count - 1; ++index)
      {
        TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings(clsInit.cRouter3AX.JobCamToString(this.activeJob.CamList[index]));
        treeNodeSettings3.ImageIndex = clsInit.cRouter3AX.JobCamToIndex(this.activeJob.CamList[index]);
        treeNodeSettings3.SelectedImageIndex = clsInit.cRouter3AX.JobCamToIndex(this.activeJob.CamList[index]);
        treeNodeSettings3.Tag = (object) "";
        treeNodeSettings3.ClassIndex = 0;
        treeNodeSettings3.ClassSubIndex = index;
        treeNodeSettings3.ClassSubSubIndex = -1;
        treeNodeSettings3.Command = "Cam";
        treeNodeSettings3.Info = "Cam";
        treeNodeSettings3.Checked = true;
        TreeNodeSettings node3 = treeNodeSettings3;
        if (this.activeJob.CamList[index].Enable)
        {
          node3.NodeFont = new Font(this.string_1, 8f, FontStyle.Regular);
          node3.ForeColor = Color.Black;
        }
        else
        {
          node3.NodeFont = new Font(this.string_1, 8f, FontStyle.Strikeout);
          node3.ForeColor = Color.Red;
        }
        TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings(clsInit.cRouter3AX.JobCamToolToString(this.activeJob.CamList[index].Tool));
        treeNodeSettings4.ImageIndex = clsInit.cRouter3AX.JobCamToolToIndex(this.activeJob.CamList[index].Tool);
        treeNodeSettings4.SelectedImageIndex = clsInit.cRouter3AX.JobCamToolToIndex(this.activeJob.CamList[index].Tool);
        treeNodeSettings4.Tag = (object) "";
        treeNodeSettings4.ClassIndex = 0;
        treeNodeSettings4.ClassSubIndex = index;
        treeNodeSettings4.ClassSubSubIndex = -1;
        treeNodeSettings4.Command = "Tool";
        treeNodeSettings4.Info = "Tool";
        treeNodeSettings4.Checked = true;
        TreeNodeSettings node4 = treeNodeSettings4;
        TreeNodeSettings treeNodeSettings5 = new TreeNodeSettings(clsInit.cRouter3AX.JobCamInfoToString(this.activeJob.CamList[index].CamPars));
        treeNodeSettings5.ImageIndex = clsInit.cRouter3AX.JobCamInfoToIndex();
        treeNodeSettings5.SelectedImageIndex = clsInit.cRouter3AX.JobCamInfoToIndex();
        treeNodeSettings5.Tag = (object) "";
        treeNodeSettings5.ClassIndex = 0;
        treeNodeSettings5.ClassSubIndex = index;
        treeNodeSettings5.ClassSubSubIndex = -1;
        treeNodeSettings5.Command = "Info";
        treeNodeSettings5.Info = "Info";
        treeNodeSettings5.Checked = true;
        TreeNodeSettings node5 = treeNodeSettings5;
        if (this.activeJob.CamList[index].Enable)
        {
          node4.NodeFont = new Font(this.string_1, 8f, FontStyle.Regular);
          node4.ForeColor = Color.Black;
        }
        else
        {
          node4.NodeFont = new Font(this.string_1, 8f, FontStyle.Strikeout);
          node4.ForeColor = Color.Red;
        }
        node3.Nodes.Add((TreeNode) node4);
        node3.Nodes.Add((TreeNode) node5);
        node1.Nodes.Add((TreeNode) node3);
      }
      clsItem.FrmRouter3AXJob.tree_jobs.Nodes.Add((TreeNode) node1);
      node1.Expand();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void JobCamEnableDisabe()
  {
    if (!(this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1))
      return;
    if (this.activeJob.CamList[this.SelectedCamIndex].Enable)
    {
      clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].NodeFont = new Font(this.string_1, 8f, FontStyle.Regular);
      clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].ForeColor = Color.Black;
      for (int index = 0; index <= clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].Nodes.Count - 1; ++index)
      {
        clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].Nodes[index].NodeFont = new Font(this.string_1, 8f, FontStyle.Regular);
        clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].Nodes[index].ForeColor = Color.Black;
      }
    }
    else
    {
      clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].NodeFont = new Font(this.string_1, 8f, FontStyle.Strikeout);
      clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].ForeColor = Color.Red;
      for (int index = 0; index <= clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].Nodes.Count - 1; ++index)
      {
        clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].Nodes[index].NodeFont = new Font(this.string_1, 8f, FontStyle.Strikeout);
        clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].Nodes[index].ForeColor = Color.Red;
      }
    }
    this.UpdateDrawJob(this.SelectedCamIndex);
  }

  public void JobCamName()
  {
    if (!(this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1))
      return;
    clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[this.SelectedCamIndex + 1].Text = clsInit.cRouter3AX.JobCamToString(this.activeJob.CamList[this.SelectedCamIndex]);
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buRouter3Ax.lng") : new FileInfo(AppPath.Language + "\\buRouter3Ax.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterCommands);
        buLogVer5.addToLog(nameof (clsRouter3AX), nameof (LoadLanguage), "End");
        StringList.Clear();
      }
      else
      {
        buLogVer5.addToLog(nameof (clsRouter3AX), nameof (LoadLanguage), "Error", "File Missing");
        buString5.MessageBoxError("Router Language File Missing");
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (LoadLanguage), "Error", ex.Message);
      buException.throwException(ex, nameof (LoadLanguage), true, "");
    }
  }

  public void SaveRouter3XFile()
  {
    string FileName1 = AppPath.Settings + "\\Router\\Router3X.prm";
    ArrayList StringList1 = new ArrayList();
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "  Router 3X Settings");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "<varRouter3AXSettings>");
    StringList1.AddRange((ICollection) clsRouter3AX.varRouter3AXSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList1.Add((object) "</varRouter3AXSettings>");
    StringList1.Add((object) "<varRouter3AXRunSettings>");
    StringList1.AddRange((ICollection) clsRouter3AX.varRouter3AXRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList1.Add((object) "</varRouter3AXRunSettings>");
    StringList1.Add((object) "<varRouter3AXDisplaySettings>");
    StringList1.AddRange((ICollection) clsRouter3AX.varRouter3AXDisplaySettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList1.Add((object) "</varRouter3AXDisplaySettings>");
    buFile5.SaveToFile(StringList1, FileName1);
    buLogVer5.addToLog(nameof (clsRouter3AX), "SavePipeBendingFile", "End");
    buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutCenter.bin");
    buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutInside.bin");
    buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutOutside.bin");
    buMWRouter3XVars.varCamWireframeCompCutting.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutting.bin");
    buMWRouter3XVars.varCamWireframeCompGrove.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompGrove.bin");
    buMWRouter3XVars.varCamWireframeCompPocket.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompPocket.bin");
    buMWRouter3XVars.varCamWireframeCompText.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompText.bin");
    buMWRouter3XVars.varCamWireframeCenterPath.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCenterPath.bin");
    buMWRouter3XVars.varCamWireframeChamfer.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeChamfer.bin");
    buMWRouter3XVars.varCamWireframeContour.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeContour.bin");
    buMWRouter3XVars.varCamWireframeDrill.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeDrill.bin");
    buMWRouter3XVars.varCamWireframeEngrave.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeEngrave.bin");
    buMWRouter3XVars.varCamWireframeFace.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeFace.bin");
    buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeFloorFinish.bin");
    buMWRouter3XVars.varCamWireframeRough.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeRough.bin");
    buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeTextEngrave.bin");
    buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeTrochoidial.bin");
    buMWRouter3XVars.varCamMeshConstantCusp.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshConstantCusp.bin");
    buMWRouter3XVars.varCamMeshConstantZ.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshConstantZ.bin");
    buMWRouter3XVars.varCamMeshFlatLand.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshFlatLand.bin");
    buMWRouter3XVars.varCamMeshParallel.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshParallel.bin");
    buMWRouter3XVars.varCamMeshPencil.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshPencil.bin");
    buMWRouter3XVars.varCamMeshProjectCurves.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshProjectCurves.bin");
    buMWRouter3XVars.varCamMeshProjection.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshProjection.bin");
    buMWRouter3XVars.varCamMeshRotary.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshRotary.bin");
    buMWRouter3XVars.varCamMeshRough.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshRough.bin");
    buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshConstantZ5AX.bin");
    buMWRouter3XVars.varCamMeshParallel5AX.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshParallel5AX.bin");
    buMWRouter3XVars.varCamMeshRough5AX.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshRough5AX.bin");
    buMWRouter3XVars.varCamSurfaceParallel.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshSurface5AX.bin");
    string FileName2 = AppPath.Settings + "\\Router\\Router3XCam.bucamset";
    ArrayList StringList2 = new ArrayList();
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "   Cam Settings");
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "<BuCamSettings>");
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.ToDefAll("_varCamWireframeCompCutCenter", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCompCutInside.buPar.ToDefAll("_varCamWireframeCompCutInside", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.ToDefAll("_varCamWireframeCompCutOutside", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCompCutting.buPar.ToDefAll("_varCamWireframeCompCutting", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCompGrove.buPar.ToDefAll("_varCamWireframeCompGrove", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCompPocket.buPar.ToDefAll("_varCamWireframeCompPocket", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCompText.buPar.ToDefAll("_varCamWireframeCompText", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeCenterPath.buPar.ToDefAll("_varCamWireframeCenterPath", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeChamfer.buPar.ToDefAll("_varCamWireframeChamfer", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeContour.buPar.ToDefAll("_varCamWireframeContour", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeDrill.buPar.ToDefAll("_varCamWireframeDrill", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeEngrave.buPar.ToDefAll("_varCamWireframeEngrave", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeFace.buPar.ToDefAll("_varCamWireframeFace", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeFloorFinish.buPar.ToDefAll("_varCamWireframeFloorFinish", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeRough.buPar.ToDefAll("_varCamWireframeRough", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeTextEngrave.buPar.ToDefAll("_varCamWireframeTextEngrave", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamWireframeTrochoidial.buPar.ToDefAll("_varCamWireframeTrochoidial", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshConstantCusp.buPar.ToDefAll("_varCamMeshConstantCusp", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshConstantZ.buPar.ToDefAll("_varCamMeshConstantZ", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshFlatLand.buPar.ToDefAll("_varCamMeshFlatLand", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshParallel.buPar.ToDefAll("_varCamMeshParallel", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshPencil.buPar.ToDefAll("_varCamMeshPencil", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshProjectCurves.buPar.ToDefAll("_varCamMeshProjectCurves", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshProjection.buPar.ToDefAll("_varCamMeshProjection", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshRotary.buPar.ToDefAll("_varCamMeshRotary", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshRough.buPar.ToDefAll("_varCamMeshRough", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshParallel5AX.buPar.ToDefAll("_varCamMeshParallel5AX", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshConstantZ5AX.buPar.ToDefAll("_varCamMeshConstantZ5AX", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamMeshRough5AX.buPar.ToDefAll("_varCamMeshRough5AX", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRouter3XVars.varCamSurfaceParallel.buPar.ToDefAll("_varCamSurfaceParallel5AX", 2, SerilizationMode5.MultiLine));
    StringList2.Add((object) "</BuCamSettings>");
    buFile5.SaveToFile(StringList2, FileName2);
  }

  public void OpenRouter3Xile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Router\\Router3X.prm");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile5.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<varRouter3AXSettings>", "</varRouter3AXSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsRouter3AX.varRouter3AXSettings);
            buLogVer5.addToLog(nameof (clsRouter3AX), "OpenPipeBendingFile", "Ok", "varRouter3AXSettings");
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<varRouter3AXRunSettings>", "</varRouter3AXRunSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsRouter3AX.varRouter3AXRunSettings);
            buLogVer5.addToLog(nameof (clsRouter3AX), "OpenPipeBendingFile", "Ok", "varRouter3AXRunSettings");
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<varRouter3AXDisplaySettings>", "</varRouter3AXDisplaySettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsRouter3AX.varRouter3AXDisplaySettings);
            buLogVer5.addToLog(nameof (clsRouter3AX), "OpenPipeBendingFile", "Ok", "varRouter3AXDisplaySettings");
          }
        }
        catch (Exception ex)
        {
          buLogVer5.addToLog(nameof (clsRouter3AX), "OpenPipeBendingFile", "Error", "Router 3AX Settings Decoder Error");
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Laser Settings Decoder Error");
        }
      }
      else
      {
        buLogVer5.addToLog(nameof (clsRouter3AX), "OpenPipeBendingFile", "Error", "Router 3AX Settings File Mising");
        buString.MessageBoxError("Router 3AX  Settings File Missing");
      }
      buLogVer5.addToLog(nameof (clsRouter3AX), "OpenPipeBendingFile", "End");
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "Setting File Decoded");
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutCenter.bin");
      if (fileInfo2.Exists)
        buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.Deserialize(fileInfo2.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCompCutCenter Decoded");
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutInside.bin");
      if (fileInfo3.Exists)
        buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.Deserialize(fileInfo3.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCompCutInside Decoded");
      FileInfo fileInfo4 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutOutside.bin");
      if (fileInfo4.Exists)
        buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.Deserialize(fileInfo4.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCompCutOutside Decoded");
      FileInfo fileInfo5 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutting.bin");
      if (fileInfo5.Exists)
        buMWRouter3XVars.varCamWireframeCompCutting.mwPar.Deserialize(fileInfo5.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCompCutting Decoded");
      FileInfo fileInfo6 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompGrove.bin");
      if (fileInfo6.Exists)
        buMWRouter3XVars.varCamWireframeCompGrove.mwPar.Deserialize(fileInfo6.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCompGrove Decoded");
      FileInfo fileInfo7 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompPocket.bin");
      if (fileInfo7.Exists)
        buMWRouter3XVars.varCamWireframeCompPocket.mwPar.Deserialize(fileInfo7.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCompPocket Decoded");
      FileInfo fileInfo8 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompText.bin");
      if (fileInfo8.Exists)
        buMWRouter3XVars.varCamWireframeCompText.mwPar.Deserialize(fileInfo8.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCompText Decoded");
      FileInfo fileInfo9 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCenterPath.bin");
      if (fileInfo9.Exists)
        buMWRouter3XVars.varCamWireframeCenterPath.mwPar.Deserialize(fileInfo9.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeCenterPath Decoded");
      FileInfo fileInfo10 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeChamfer.bin");
      if (fileInfo10.Exists)
        buMWRouter3XVars.varCamWireframeChamfer.mwPar.Deserialize(fileInfo10.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeChamfer Decoded");
      FileInfo fileInfo11 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeContour.bin");
      if (fileInfo11.Exists)
        buMWRouter3XVars.varCamWireframeContour.mwPar.Deserialize(fileInfo11.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeContour Decoded");
      FileInfo fileInfo12 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeDrill.bin");
      if (fileInfo12.Exists)
        buMWRouter3XVars.varCamWireframeDrill.mwPar.Deserialize(fileInfo12.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeDrill Decoded");
      FileInfo fileInfo13 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeEngrave.bin");
      if (fileInfo13.Exists)
        buMWRouter3XVars.varCamWireframeEngrave.mwPar.Deserialize(fileInfo13.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeEngrave Decoded");
      FileInfo fileInfo14 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeFace.bin");
      if (fileInfo14.Exists)
        buMWRouter3XVars.varCamWireframeFace.mwPar.Deserialize(fileInfo14.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeFace Decoded");
      FileInfo fileInfo15 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeFloorFinish.bin");
      if (fileInfo15.Exists)
        buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.Deserialize(fileInfo15.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeFloorFinish Decoded");
      FileInfo fileInfo16 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeRough.bin");
      if (fileInfo16.Exists)
        buMWRouter3XVars.varCamWireframeRough.mwPar.Deserialize(fileInfo16.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeRough Decoded");
      FileInfo fileInfo17 = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeTrochoidial.bin");
      if (fileInfo17.Exists)
        buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.Deserialize(fileInfo17.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwWireframeTrochoidial Decoded");
      FileInfo fileInfo18 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshConstantCusp.bin");
      if (fileInfo18.Exists)
        buMWRouter3XVars.varCamMeshConstantCusp.mwPar.Deserialize(fileInfo18.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshConstantCusp Decoded");
      FileInfo fileInfo19 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshConstantZ.bin");
      if (fileInfo19.Exists)
        buMWRouter3XVars.varCamMeshConstantZ.mwPar.Deserialize(fileInfo19.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshConstantZ Decoded");
      FileInfo fileInfo20 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshFlatLand.bin");
      if (fileInfo20.Exists)
        buMWRouter3XVars.varCamMeshFlatLand.mwPar.Deserialize(fileInfo20.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshFlatLand Decoded");
      FileInfo fileInfo21 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshParallel.bin");
      if (fileInfo21.Exists)
        buMWRouter3XVars.varCamMeshParallel.mwPar.Deserialize(fileInfo21.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshParallel Decoded");
      FileInfo fileInfo22 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshPencil.bin");
      if (fileInfo22.Exists)
        buMWRouter3XVars.varCamMeshPencil.mwPar.Deserialize(fileInfo22.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshPencil Decoded");
      FileInfo fileInfo23 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshProjectCurves.bin");
      if (fileInfo23.Exists)
        buMWRouter3XVars.varCamMeshProjectCurves.mwPar.Deserialize(fileInfo23.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshProjectCurves Decoded");
      FileInfo fileInfo24 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshProjection.bin");
      if (fileInfo24.Exists)
        buMWRouter3XVars.varCamMeshProjection.mwPar.Deserialize(fileInfo24.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshProjection Decoded");
      FileInfo fileInfo25 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshRotary.bin");
      if (fileInfo25.Exists)
        buMWRouter3XVars.varCamMeshRotary.mwPar.Deserialize(fileInfo25.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshRotary Decoded");
      FileInfo fileInfo26 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshRough.bin");
      if (fileInfo26.Exists)
        buMWRouter3XVars.varCamMeshRough.mwPar.Deserialize(fileInfo26.FullName);
      FileInfo fileInfo27 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshConstantZ5AX.bin");
      if (fileInfo27.Exists)
        buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar.Deserialize(fileInfo27.FullName);
      FileInfo fileInfo28 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshParallel5AX.bin");
      if (fileInfo28.Exists)
        buMWRouter3XVars.varCamMeshParallel5AX.mwPar.Deserialize(fileInfo28.FullName);
      FileInfo fileInfo29 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshRough5AX.bin");
      if (fileInfo29.Exists)
        buMWRouter3XVars.varCamMeshRough5AX.mwPar.Deserialize(fileInfo29.FullName);
      FileInfo fileInfo30 = new FileInfo(AppPath.Settings + "\\Router\\mwMeshSurface5AX.bin");
      if (fileInfo30.Exists)
        buMWRouter3XVars.varCamSurfaceParallel.mwPar.Deserialize(fileInfo30.FullName);
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Ok", "MW Bin mwMeshRough Decoded");
      string str = AppPath.Settings + "\\Router\\Router3XCam.bucamset";
      if (new FileInfo(str).Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile5.OpenFromFile(str, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<BuCamSettings>", "</BuCamSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "_varCamWireframeCompCutCenter", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCompCutCenter.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeCompCutInside", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCompCutInside.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeCompCutOutside", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCompCutOutside.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeCompCutting", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCompCutting.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeCompGrove", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCompGrove.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeCompPocket", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCompPocket.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeCompText", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCompText.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeCenterPath", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeCenterPath.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeChamfer", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeChamfer.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeContour", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeContour.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeDrill", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeDrill.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeEngrave", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeEngrave.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeFace", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeFace.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeFloorFinish", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeFloorFinish.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeRough", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeRough.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeTextEngrave", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeTextEngrave.buPar);
            buSerilization5.Decode(StringList, "_varCamWireframeTrochoidial", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamWireframeTrochoidial.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshConstantCusp", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshConstantCusp.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshConstantZ", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshConstantZ.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshFlatLand", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshFlatLand.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshParallel", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshParallel.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshPencil", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshPencil.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshProjectCurves", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshProjectCurves.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshProjection", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshProjection.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshRotary", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshRotary.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshRough", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshRough.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshParallel5AX", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshParallel5AX.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshConstantZ5AX", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshConstantZ5AX.buPar);
            buSerilization5.Decode(StringList, "_varCamMeshRough5AX", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamMeshRough5AX.buPar);
            buSerilization5.Decode(StringList, "_varCamSurfaceParallel5AX", SerilizationMode5.MultiLine, (object) buMWRouter3XVars.varCamSurfaceParallel.buPar);
          }
        }
        catch (Exception ex)
        {
          buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Error", "MW Router Cam Settings Decoder Error");
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Router Settings Decoder Error");
        }
      }
      else
      {
        buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "Error", "MW Router Cam Settings File Missing");
        buString.MessageBoxError("Router Cam Settings File Missing");
      }
      buLogVer5.addToLog(nameof (clsRouter3AX), nameof (OpenRouter3Xile), "End");
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(nameof (clsRouter3AX), "OpenPipeBendingFile", "Error", "Router 3AX Settings Decoder Error");
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Router 3AX  Settings Decoder Error");
    }
  }

  public void General_Tick(object sender, EventArgs e)
  {
    ++this.countGeneral;
    if (AppBool.Save && this.countGeneral % 100 == 0)
    {
      this.SaveRouter3XFile();
      clsFiles.SaveParameter();
      AppBool.Save = false;
    }
    if (this.countGeneral <= 10000000)
      return;
    this.countGeneral = 0;
  }

  public void doNewPage()
  {
    this.cmdNewJob();
    clsNesting.varTemps.layerPart = clsRouter3AX.varTemps.layerPart;
    clsNesting.varTemps.layerSheet = clsRouter3AX.varTemps.layerSheet;
    clsNesting.varTemps.layerWireframe = clsRouter3AX.varTemps.layerWireframe;
  }

  public void doReset() => this.MWCalcOptions.Editing = false;

  public void doOpenPage()
  {
  }

  public void doCamFromNesting(buNestedResultEventArg NestResult)
  {
    int num1 = NestResult.SelectedSheet;
    if (NestResult.ResultSheetType == nestedCreateSheetType.All)
      num1 = -1;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
    if (NestResult.ResultCreateType == nestedCreateType.Draw)
      clsInit.appNesting.doDrawAllNesting(NestResult.nestedResult, num1, -1, (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, true, false);
    if (!NestResult.DoCam)
      return;
    if (this.activeJob != null)
      this.activeJob.CamList.Clear();
    if (num1 == -1)
    {
      if (NestResult.ResultCreateType == nestedCreateType.SaveFile)
      {
        bool flag = true;
        if (clsRouter3AX.varRouter3AXSettings.DualTable)
        {
          flag = false;
          this.frmTableSelection.Properties.FormCloseMode = FormCloseModeType.Invisible;
          this.frmTableSelection.Properties.FormPosition = FormStartPosition.CenterScreen;
          this.frmTableSelection.CamTable = clsRouter3AX.varRouter3AXSettings.TableType;
          this.frmTableSelection.Init();
          int num2 = (int) this.frmTableSelection.ShowDialog();
          if (this.frmTableSelection.Properties.Result == DialogResult.OK)
          {
            clsRouter3AX.varRouter3AXSettings.TableType = this.frmTableSelection.CamTable;
            flag = true;
          }
        }
        if (flag)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
          saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
          saveFileDialog.FilterIndex = 1;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            clsRouter3AX.JobList = new List<Router3AXItem>();
            for (int index = 0; index <= NestResult.nestedResult.NestedResultSheets.Count - 1; ++index)
            {
              this.activeJob = new Router3AXItem();
              this.CreateSheetCam(NestResult.nestedResult.NestedResultSheets[index]);
              clsRouter3AX.JobList.Add(this.activeJob);
            }
            clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
            clsFiles.SaveParameter();
            if (clsVar.appDefination.CustomerID == AppCustomerID.Yilmaz && this.cModeYilmaz != null)
              this.cModeYilmaz.CodeFromList(clsRouter3AX.JobList, saveFileDialog.FileName);
            if (clsVar.appDefination.CustomerID == AppCustomerID.CMD && this.cModeCMD != null)
              this.cModeCMD.CodeFromList(clsRouter3AX.JobList, saveFileDialog.FileName);
            if (clsVar.appDefination.CustomerID == AppCustomerID.Infinite && this.cModeInfinite != null)
              this.cModeInfinite.CodeFromList(clsRouter3AX.JobList, saveFileDialog.FileName);
            for (int index = 0; index <= clsRouter3AX.JobList.Count - 1; ++index)
            {
              if (index <= NestResult.nestedResult.NestedResultSheets.Count - 1 && clsRouter3AX.JobList[index].GCodeResult != null)
                NestResult.nestedResult.NestedResultSheets[index].GCodeResult = new MachineGCodeExecutionResult(clsRouter3AX.JobList[index].GCodeResult);
            }
          }
        }
      }
      if (clsItem.FrmProgress == null)
        return;
      clsItem.FrmProgress.Visible = false;
    }
    else
    {
      if (!(num1 >= 0 & num1 <= NestResult.nestedResult.NestedResultSheets.Count - 1))
        return;
      this.CreateSheetCam(NestResult.nestedResult.NestedResultSheets[num1]);
    }
  }

  public void CreateSheetCam(buNestedSheet Sheet)
  {
    if (this.activeJob == null || Sheet.Parts.Count <= 0)
      return;
    this.activeJob.Stock = new CamStock();
    this.activeJob.Stock.SizeStock = new SizeObject(Sheet.MaterialWidth, Sheet.MaterialHeight, Sheet.MaterialThickness);
    this.activeJob.Stock.StockName = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Sheet}";
    this.activeJob.Stock.MinPoint = new Point3D();
    this.activeJob.Stock.MaxPoint = new Point3D(Sheet.MaterialWidth, Sheet.MaterialHeight, Sheet.MaterialThickness);
    for (int index1 = 0; index1 <= clsRouter3AX.varRouter3AXRunSettings.SequenceList.Count - 1; ++index1)
    {
      List<buEntitiesGroup> Entities = new List<buEntitiesGroup>();
      Router3AXLayerPurpose router3AxLayerPurpose = (Router3AXLayerPurpose) new EnumConverter(typeof (Router3AXLayerPurpose)).ConvertFromString(clsRouter3AX.varRouter3AXRunSettings.SequenceList[index1]);
      List<ToolBase5> Tools = new List<ToolBase5>();
      this.FindToolsFromPurpose(router3AxLayerPurpose, ref Tools);
      if (Tools.Count > 0)
      {
        for (int index2 = 0; index2 <= Tools.Count - 1; ++index2)
        {
          this.FindEntitiesFromSequenceType(Tools[index2], Sheet, ref Entities);
          if (Entities.Count > 0)
          {
            List<EntitiesList> EntGroup = new List<EntitiesList>();
            for (int index3 = 0; index3 <= Entities.Count - 1; ++index3)
            {
              if ((Entities[index3].Outside == null ? 0 : (Entities[index3].Outside.Entities.Count > 0 ? 1 : 0)) != 0)
              {
                EntitiesList entitiesList = new EntitiesList();
                buEntity.Add(Entities[index3].Outside.Entities, ref entitiesList.Entities);
                EntGroup.Add(entitiesList);
              }
              if ((Entities[index3].Inside == null ? 0 : (Entities[index3].Inside.Count > 0 ? 1 : 0)) != 0)
              {
                for (int index4 = 0; index4 <= Entities[index3].Inside.Count - 1; ++index4)
                {
                  EntitiesList entitiesList = new EntitiesList();
                  buEntity.Add(Entities[index3].Inside[index4].Entities, ref entitiesList.Entities);
                  EntGroup.Add(entitiesList);
                }
              }
              if ((Entities[index3].OpenEntities == null ? 0 : (Entities[index3].OpenEntities.Count > 0 ? 1 : 0)) != 0)
              {
                EntitiesList entitiesList = new EntitiesList();
                for (int index5 = 0; index5 <= Entities[index3].OpenEntities.Count - 1; ++index5)
                  buEntity.Add(Entities[index3].OpenEntities[index5].Entities, ref entitiesList.Entities);
                EntGroup.Add(entitiesList);
              }
            }
            if (EntGroup.Count > 0)
            {
              if (router3AxLayerPurpose == Router3AXLayerPurpose.Derz | router3AxLayerPurpose == Router3AXLayerPurpose.CenterCut | router3AxLayerPurpose == Router3AXLayerPurpose.Text)
                this.doWireframeCenterPath(router3AxLayerPurpose, Tools[index2], EntGroup, router3AxLayerPurpose.ToString());
              if (router3AxLayerPurpose == Router3AXLayerPurpose.Cutting | router3AxLayerPurpose == Router3AXLayerPurpose.OutsideCut)
                this.doWireframeContour(router3AxLayerPurpose, Tools[index2], EntGroup, router3AxLayerPurpose.ToString());
              if (router3AxLayerPurpose == Router3AXLayerPurpose.InsideCut)
                this.doWireframeContour(router3AxLayerPurpose, Tools[index2], EntGroup, router3AxLayerPurpose.ToString());
              if (router3AxLayerPurpose == Router3AXLayerPurpose.PocketOffset)
                this.doWireframePocket(router3AxLayerPurpose, Tools[index2], EntGroup, router3AxLayerPurpose.ToString());
              if (router3AxLayerPurpose == Router3AXLayerPurpose.PocketParalel)
                this.doWireframePocket(router3AxLayerPurpose, Tools[index2], EntGroup, router3AxLayerPurpose.ToString());
              if (router3AxLayerPurpose == Router3AXLayerPurpose.Drill)
                this.doDrill(router3AxLayerPurpose, Tools[index2], EntGroup, router3AxLayerPurpose.ToString());
            }
          }
        }
      }
    }
  }

  public void FindEntitiesFromSequenceType(
    ToolBase5 Tool,
    buNestedSheet Sheet,
    ref List<buEntitiesGroup> Entities)
  {
    if (Tool == null)
      return;
    Entities = new List<buEntitiesGroup>();
    for (int index1 = 0; index1 <= Sheet.Parts.Count - 1; ++index1)
    {
      buEntitiesGroup buEntitiesGroup = new buEntitiesGroup();
      bool flag = false;
      if ((Sheet.Parts[index1].EntitiesGroup.Outside == null ? 0 : (Sheet.Parts[index1].EntitiesGroup.Outside.Entities.Count > 0 ? 1 : 0)) != 0)
      {
        buEntitiesGroup.Outside = new buEntityList();
        for (int index2 = 0; index2 <= Sheet.Parts[index1].EntitiesGroup.Outside.Entities.Count - 1; ++index2)
        {
          buEntity entity = Sheet.Parts[index1].EntitiesGroup.Outside.Entities[index2];
          if (entity.ToolName.Trim() == Tool.Data.Name.Trim())
          {
            buEntitiesGroup.Outside.Entities.Add(buEntity.Copy(entity));
            flag = true;
          }
        }
      }
      if ((Sheet.Parts[index1].EntitiesGroup.Text == null ? 0 : (Sheet.Parts[index1].EntitiesGroup.Text.Entities.Count > 0 ? 1 : 0)) != 0)
      {
        buEntitiesGroup.Text = new buEntityList();
        for (int index3 = 0; index3 <= Sheet.Parts[index1].EntitiesGroup.Text.Entities.Count - 1; ++index3)
        {
          buEntity entity = Sheet.Parts[index1].EntitiesGroup.Text.Entities[index3];
          if (entity.ToolName.Trim() == Tool.Data.Name.Trim())
          {
            buEntitiesGroup.Text.Entities.Add(buEntity.Copy(entity));
            flag = true;
          }
        }
      }
      if ((Sheet.Parts[index1].EntitiesGroup.Inside == null ? 0 : (Sheet.Parts[index1].EntitiesGroup.Inside.Count > 0 ? 1 : 0)) != 0)
      {
        buEntitiesGroup.Inside = new List<buEntityList>();
        for (int index4 = 0; index4 <= Sheet.Parts[index1].EntitiesGroup.Inside.Count - 1; ++index4)
        {
          buEntityList buEntityList = new buEntityList();
          for (int index5 = 0; index5 <= Sheet.Parts[index1].EntitiesGroup.Inside[index4].Entities.Count - 1; ++index5)
          {
            buEntity entity = Sheet.Parts[index1].EntitiesGroup.Inside[index4].Entities[index5];
            if (entity.ToolName.Trim() == Tool.Data.Name.Trim())
            {
              buEntityList.Entities.Add(buEntity.Copy(entity));
              flag = true;
            }
          }
          if (buEntityList.Entities.Count > 0)
            buEntitiesGroup.Inside.Add(buEntityList);
        }
      }
      if ((Sheet.Parts[index1].EntitiesGroup.OpenEntities == null ? 0 : (Sheet.Parts[index1].EntitiesGroup.OpenEntities.Count > 0 ? 1 : 0)) != 0)
      {
        buEntitiesGroup.OpenEntities = new List<buEntityList>();
        for (int index6 = 0; index6 <= Sheet.Parts[index1].EntitiesGroup.OpenEntities.Count - 1; ++index6)
        {
          buEntityList buEntityList = new buEntityList();
          for (int index7 = 0; index7 <= Sheet.Parts[index1].EntitiesGroup.OpenEntities[index6].Entities.Count - 1; ++index7)
          {
            buEntity entity = Sheet.Parts[index1].EntitiesGroup.OpenEntities[index6].Entities[index7];
            if (entity.ToolName.Trim() == Tool.Data.Name.Trim())
            {
              buEntityList.Entities.Add(buEntity.Copy(entity));
              flag = true;
            }
          }
          if (buEntityList.Entities.Count > 0)
            buEntitiesGroup.OpenEntities.Add(buEntityList);
        }
      }
      if (flag)
        Entities.Add(buEntitiesGroup);
    }
  }

  public void FindToolsFromPurpose(Router3AXLayerPurpose LayerPurpose, ref List<ToolBase5> Tools)
  {
    Tools = new List<ToolBase5>();
    for (int index1 = 0; index1 <= ccVars.Tools.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.Tools[index1].Tools.Count - 1; ++index2)
      {
        if (LayerPurpose == Router3AXLayerPurpose.Derz && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.Derz)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.CenterCut && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.CutCenter)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.Cutting && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.Cutting)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.Drill && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.Drilling)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.Engrave && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.Engrave)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.InsideCut && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.CutIn)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.OutsideCut && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.CutOut)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.PocketOffset && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.PocketCircular)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.PocketParalel && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.PocketFlat)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
        if (LayerPurpose == Router3AXLayerPurpose.Text && ccVars.Tools[index1].Tools[index2].Purpose == ToolPurpose.Text)
          Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
      }
    }
  }

  public void doCamDelete()
  {
    if (this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1)
    {
      if (buString5.MessageBoxQuestion(buRouter3AX.LangRouterMessage[0]) != DialogResult.Yes)
        return;
      this.activeJob.CamList.RemoveAt(this.SelectedCamIndex);
      this.SelectedCamIndex = -1;
      this.JobUpdate();
      this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
      if (this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1)
        ccVars.Pages[ccVars.PageIndex].Cams.RemoveAt(this.SelectedCamIndex);
      this.UpdateDrawJob(this.SelectedCamIndex);
    }
    else
      buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
  }

  public void doCamDeleteAll()
  {
    if (ccVars.Pages.Count == 0 || buString5.MessageBoxQuestion(buRouter3AX.LangRouterMessage[2]) != DialogResult.Yes)
      return;
    this.activeJob.CamList.Clear();
    ccVars.Pages[ccVars.PageIndex].Cams.Clear();
    this.SelectedCamIndex = -1;
    this.JobUpdate();
    this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
  }

  public void doCamEnableDisable()
  {
    if (this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1)
    {
      if (!this.activeJob.CamList[this.SelectedCamIndex].Enable)
      {
        this.activeJob.CamList[this.SelectedCamIndex].Enable = true;
        this.JobCamEnableDisabe();
        this.UpdateDrawJob(this.SelectedCamIndex);
      }
      else
      {
        this.activeJob.CamList[this.SelectedCamIndex].Enable = false;
        this.JobCamEnableDisabe();
        this.UpdateDrawJob(this.SelectedCamIndex);
      }
    }
    else
      buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
  }

  public void doCamEdit()
  {
    if (this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1)
    {
      if (this.activeJob.CamList[this.SelectedCamIndex].Enable)
      {
        this.MWCalcOptions.Editing = true;
        if (this.activeJob.CamList[this.SelectedCamIndex].camMode != CamMode.WireFrame)
          return;
        if (this.activeJob.CamList[this.SelectedCamIndex].camWireframeType == CamWireFrameType.Contour)
          this.doWireframeContour(this.activeJob.CamList[this.SelectedCamIndex].Purpose, this.activeJob.CamList[this.SelectedCamIndex].Tool);
        if (this.activeJob.CamList[this.SelectedCamIndex].camWireframeType == CamWireFrameType.Pocket)
          this.doWireframePocket(this.activeJob.CamList[this.SelectedCamIndex].Purpose, this.activeJob.CamList[this.SelectedCamIndex].Tool);
        if (this.activeJob.CamList[this.SelectedCamIndex].camWireframeType != CamWireFrameType.CenterPath)
          return;
        this.doWireframeCenterPath(this.activeJob.CamList[this.SelectedCamIndex].Purpose, this.activeJob.CamList[this.SelectedCamIndex].Tool);
      }
      else
        buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[3]);
    }
    else
      buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
  }

  public void doCamToolEdit()
  {
    if (this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1)
    {
      if (this.activeJob.CamList[this.SelectedCamIndex].Enable)
      {
        ToolBase5 tool = this.activeJob.CamList[this.SelectedCamIndex].Tool;
        if (!clsInit.appCommand.cmdToolSelect(ref tool))
          return;
        this.MWCalcOptions.Editing = true;
        this.activeJob.CamList[this.SelectedCamIndex].Tool = tool;
        if (this.activeJob.CamList[this.SelectedCamIndex].camMode != CamMode.WireFrame)
          return;
        if (this.activeJob.CamList[this.SelectedCamIndex].camWireframeType == CamWireFrameType.Contour)
          this.doWireframeContour(this.activeJob.CamList[this.SelectedCamIndex].Purpose, this.activeJob.CamList[this.SelectedCamIndex].Tool);
        if (this.activeJob.CamList[this.SelectedCamIndex].camWireframeType == CamWireFrameType.Pocket)
          this.doWireframePocket(this.activeJob.CamList[this.SelectedCamIndex].Purpose, this.activeJob.CamList[this.SelectedCamIndex].Tool);
        if (this.activeJob.CamList[this.SelectedCamIndex].camWireframeType != CamWireFrameType.CenterPath)
          return;
        this.doWireframeCenterPath(this.activeJob.CamList[this.SelectedCamIndex].Purpose, this.activeJob.CamList[this.SelectedCamIndex].Tool);
      }
      else
        buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[3]);
    }
    else
      buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
  }

  public void doCamRename()
  {
    if (this.activeJob == null || this.activeJob.CamList.Count <= 0)
      return;
    if (this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1)
    {
      DialogBoxText dialogBoxText = new DialogBoxText();
      dialogBoxText.Caption = $"{buLangTranslate.preDef.Rename} {buLangTranslate.preDef.Cam}";
      dialogBoxText.Text = $"{buLangTranslate.preDef.Rename} {buLangTranslate.preDef.Cam}";
      dialogBoxText.Init(this.activeJob.CamList[this.SelectedCamIndex].CamName);
      int num = (int) dialogBoxText.ShowDialog();
      if (dialogBoxText.Result != DialogResult.OK)
        return;
      this.activeJob.CamList[this.SelectedCamIndex].CamName = dialogBoxText.Value;
      this.JobCamName();
    }
    else
      buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
  }

  public void doCamMoveUp()
  {
    if (!(this.activeJob.CamList.Count > 0 & this.SelectedCamIndex > 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 1))
      return;
    Router3AXCAM cam = this.activeJob.CamList[this.SelectedCamIndex];
    this.activeJob.CamList.RemoveAt(this.SelectedCamIndex);
    --this.SelectedCamIndex;
    this.activeJob.CamList.Insert(this.SelectedCamIndex, cam);
    this.JobUpdate();
  }

  public void doCamMoveDown()
  {
    if (!(this.activeJob.CamList.Count > 0 & this.SelectedCamIndex >= 0 & this.SelectedCamIndex <= this.activeJob.CamList.Count - 2))
      return;
    Router3AXCAM cam = this.activeJob.CamList[this.SelectedCamIndex];
    this.activeJob.CamList.RemoveAt(this.SelectedCamIndex);
    ++this.SelectedCamIndex;
    this.activeJob.CamList.Insert(this.SelectedCamIndex, cam);
    this.JobUpdate();
  }

  public void doDrill(
    Router3AXLayerPurpose Purpose,
    ToolBase5 Tool,
    List<EntitiesList> EntGroup = null,
    string CamName = "")
  {
    if (this.activeJob == null)
      this.activeJob = new Router3AXItem();
    Router3AXCAM RouterCam = new Router3AXCAM();
    RouterCam.entitiesPlane = new Router3AXCamPlane();
    if (Purpose == Router3AXLayerPurpose.Drill)
    {
      buMWRouter3XVars.varCamWireframeDrill.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
      buMWRouter3XVars.varCamWireframeDrill.buPar.Speeds.Plunge = Tool.CamData.PlungeSpeed;
      buMWRouter3XVars.varCamWireframeDrill.buPar.Operations.isClosed = true;
      buMWRouter3XVars.varCamWireframeDrill.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
      buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.RapidRetractFlg = true;
      buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutting.mwPar, buMWRouter3XVars.varCamWireframeCompCutting.buPar, out clsMW.varbuCamWFContourPars);
    }
    camResult Result = (camResult) null;
    clsMW.CamEntities.Clear();
    this.MWCalcOptions.UseSortedAndSplitedEntities = false;
    this.MWCalcOptions.HeightFromEntities = false;
    this.MWCalcOptions.CheckIsCLosedEntities = false;
    this.MWCalcOptions.CamMode = CamMode.Drill;
    if ((EntGroup == null ? 0 : (EntGroup.Count > 0 ? 1 : 0)) != 0)
    {
      clsMW.CamEntitiesGroup.Clear();
      for (int index1 = 0; index1 <= EntGroup.Count - 1; ++index1)
      {
        List<Entity> entityList = new List<Entity>();
        for (int index2 = 0; index2 <= EntGroup[index1].Entities.Count - 1; ++index2)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(EntGroup[index1].Entities[index2], ref copiedEntity, true, 0.01);
          if (copiedEntity != null)
            entityList.Add(copiedEntity);
          if (copiedEntity is Circle)
          {
            if (clsMW.CamEntities.Count == 0)
            {
              clsMW.CamEntities.Add(copiedEntity);
            }
            else
            {
              bool flag = true;
              for (int index3 = 0; index3 <= clsMW.CamEntities.Count - 1; ++index3)
              {
                if (buCompare5.EQ((clsMW.CamEntities[index3] as Circle).Center, ((Circle) copiedEntity).Center))
                  flag = false;
              }
              if (flag)
                clsMW.CamEntities.Add(copiedEntity);
            }
          }
        }
        if (entityList.Count > 0)
          ;
      }
      if (clsMW.CamEntitiesGroup.Count > 0)
      {
        this.MWCalcOptions.DontShowbuDialogBox = true;
        this.MWCalcOptions.DontShowDialogBox = true;
        this.MWCalcOptions.UseSortedAndSplitedEntities = true;
      }
    }
    buMWRouter3XVars.varCamWireframeDrill.buPar.Runtime.SimG0DevideLength = 20.0;
    buMWRouter3XVars.varCamWireframeDrill.buPar.Runtime.SimG1DevideLength = 10.0;
    clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeDrill.mwPar, buMWRouter3XVars.varCamWireframeDrill.buPar, out clsMW.varbuCamDrillPars);
    clsMW.varbuCamDrillPars.Speeds.Plunge = Tool.CamData.PlungeSpeed;
    clsMW.varbuCamDrillPars.Speeds.Feed = Tool.CamData.FeedSpeed;
    clsMW.varbuCamDrillPars.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
    clsMW.varbuCamDrillPars.Drill.EndHeight = Tool.CamData.DepthConstant;
    clsMW.varMWCamDrillPars.MachParam.PlungeFeedRate = Tool.CamData.PlungeSpeed;
    this.MWCalcOptions.DontShowbuDialogBox = true;
    this.MWCalcOptions.DontShowDialogBox = true;
    int num = clsInit.appMW.doDrill(this.MWCalcOptions, new ToolBase5(Tool)
    {
      Purpose = ToolPurpose.Drilling
    }, ref RouterCam.CamData, ref Result);
    buMWRouter3XVars.varCamWireframeDrill.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWRouter3XVars.varCamWireframeDrill.buPar);
    buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeDrill.mwPar, ref buMWRouter3XVars.varCamWireframeDrill.buPar);
    if (num >= 1)
    {
      if (CamName.Trim().Length > 0)
      {
        RouterCam.CamData.Name = CamName;
        RouterCam.CamName = CamName;
      }
      buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
      RouterCam.Tool = new ToolBase5(Tool);
      RouterCam.Purpose = Purpose;
      if ((RouterCam.CamData == null ? 0 : (RouterCam.CamData.CamPoints.Count > 0 ? 1 : 0)) != 0)
      {
        clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
        this.doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
        RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeContour.buPar);
        this.doAddOrEditCam(RouterCam, this.MWCalcOptions.Editing);
      }
      this.JobUpdate();
      this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
      this.UpdateDrawJob(this.SelectedCamIndex);
      this.SaveRouter3XFile();
      clsInit.appCommand.Reset();
    }
    else
    {
      buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
      clsInit.appCommand.Reset();
    }
  }

  public void doWireframeContour(
    Router3AXLayerPurpose Purpose,
    ToolBase5 Tool,
    List<EntitiesList> EntGroup = null,
    string CamName = "")
  {
    if (this.activeJob == null)
      this.activeJob = new Router3AXItem();
    Router3AXCAM RouterCam = new Router3AXCAM();
    RouterCam.entitiesPlane = new Router3AXCamPlane();
    switch (Purpose)
    {
      case Router3AXLayerPurpose.Cutting:
        buMWRouter3XVars.varCamWireframeCompCutting.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeCompCutting.buPar.Operations.isClosed = true;
        buMWRouter3XVars.varCamWireframeCompCutting.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
        buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutting.mwPar, buMWRouter3XVars.varCamWireframeCompCutting.buPar, out clsMW.varbuCamWFContourPars);
        break;
      case Router3AXLayerPurpose.OutsideCut:
        buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Operations.isClosed = true;
        buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Operations.Direction = ClockDirectionType.CW;
        buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
        buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar, buMWRouter3XVars.varCamWireframeCompCutOutside.buPar, out clsMW.varbuCamWFContourPars);
        break;
      case Router3AXLayerPurpose.InsideCut:
        buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Operations.isClosed = true;
        buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
        buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Operations.Direction = ClockDirectionType.CW;
        buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar, buMWRouter3XVars.varCamWireframeCompCutInside.buPar, out clsMW.varbuCamWFContourPars);
        break;
      default:
        buMWRouter3XVars.varCamWireframeContour.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeContour.mwPar, buMWRouter3XVars.varCamWireframeContour.buPar, out clsMW.varbuCamWFContourPars);
        break;
    }
    camResult Result = (camResult) null;
    clsMW.CamEntities.Clear();
    this.MWCalcOptions.UseSortedAndSplitedEntities = false;
    this.MWCalcOptions.HeightFromEntities = false;
    this.MWCalcOptions.CheckIsCLosedEntities = false;
    this.MWCalcOptions.CamMode = CamMode.WireFrame;
    if ((EntGroup == null ? 0 : (EntGroup.Count > 0 ? 1 : 0)) != 0)
    {
      clsMW.CamEntitiesGroup.Clear();
      for (int index1 = 0; index1 <= EntGroup.Count - 1; ++index1)
      {
        List<Entity> entityList = new List<Entity>();
        for (int index2 = 0; index2 <= EntGroup[index1].Entities.Count - 1; ++index2)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(EntGroup[index1].Entities[index2], ref copiedEntity, true, 0.01);
          if (copiedEntity != null)
            entityList.Add(copiedEntity);
        }
        if (entityList.Count > 0)
          clsMW.CamEntitiesGroup.Add(entityList);
      }
      if (clsMW.CamEntitiesGroup.Count > 0)
      {
        this.MWCalcOptions.DontShowbuDialogBox = true;
        this.MWCalcOptions.DontShowDialogBox = true;
        this.MWCalcOptions.UseSortedAndSplitedEntities = true;
      }
    }
    if (this.MWCalcOptions.Editing)
    {
      if (this.activeJob.CamList[this.SelectedCamIndex].CamEntities.Count == 0)
        return;
      RouterCam = new Router3AXCAM(this.activeJob.CamList[this.SelectedCamIndex]);
      clsMW.CamEntities.Clear();
      buEntity.Copy(this.activeJob.CamList[this.SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
      RouterCam.CamData = new camTp();
      RouterCam.CamEntities.Clear();
      clsMW.varbuCamWFContourPars = new camParameters5(this.activeJob.CamList[this.SelectedCamIndex].CamPars);
    }
    int num = clsInit.appMW.doWireframeContour(this.MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
    buMWRouter3XVars.varCamWireframeContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWRouter3XVars.varCamWireframeContour.buPar);
    buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeContour.mwPar, ref buMWRouter3XVars.varCamWireframeContour.buPar);
    if (num >= 1)
    {
      if (CamName.Trim().Length > 0)
      {
        RouterCam.CamData.Name = CamName;
        RouterCam.CamName = CamName;
      }
      buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
      RouterCam.Tool = new ToolBase5(Tool);
      RouterCam.Purpose = Purpose;
      if ((RouterCam.CamData == null ? 0 : (RouterCam.CamData.CamPoints.Count > 0 ? 1 : 0)) != 0)
      {
        clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
        this.doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
        RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeContour.buPar);
        this.doAddOrEditCam(RouterCam, this.MWCalcOptions.Editing);
      }
      this.JobUpdate();
      this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
      this.UpdateDrawJob(this.SelectedCamIndex);
      this.SaveRouter3XFile();
      clsInit.appCommand.Reset();
    }
    else
    {
      buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
      clsInit.appCommand.Reset();
    }
  }

  public void doWireframePocket(
    Router3AXLayerPurpose Purpose,
    ToolBase5 Tool,
    List<EntitiesList> EntGroup = null,
    string CamName = "")
  {
    if (this.activeJob == null)
      this.activeJob = new Router3AXItem();
    Router3AXCAM RouterCam = new Router3AXCAM();
    RouterCam.entitiesPlane = new Router3AXCamPlane();
    if (Purpose == Router3AXLayerPurpose.PocketOffset | Purpose == Router3AXLayerPurpose.PocketParalel)
    {
      buMWRouter3XVars.varCamWireframeCompPocket.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
      buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.RapidRetractFlg = true;
      buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.MaxStepoverDistance = Tool.Geometry.Diameter * 0.8;
      clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompPocket.mwPar, buMWRouter3XVars.varCamWireframeCompPocket.buPar, out clsMW.varbuCamWFPocketPars);
    }
    else
    {
      buMWRouter3XVars.varCamWireframeRough.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
      buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.RapidRetractFlg = true;
      buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
      buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.MaxStepoverDistance = Tool.Geometry.Diameter * 0.8;
      clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeRough.mwPar, buMWRouter3XVars.varCamWireframeRough.buPar, out clsMW.varbuCamWFPocketPars);
    }
    camResult Result = (camResult) null;
    clsMW.CamEntities.Clear();
    this.MWCalcOptions.UseSortedAndSplitedEntities = false;
    this.MWCalcOptions.HeightFromEntities = false;
    this.MWCalcOptions.CamMode = CamMode.WireFrame;
    if ((EntGroup == null ? 0 : (EntGroup.Count > 0 ? 1 : 0)) != 0)
    {
      clsMW.CamEntitiesGroup.Clear();
      for (int index1 = 0; index1 <= EntGroup.Count - 1; ++index1)
      {
        List<Entity> entityList = new List<Entity>();
        for (int index2 = 0; index2 <= EntGroup[index1].Entities.Count - 1; ++index2)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(EntGroup[index1].Entities[index2], ref copiedEntity);
          if (copiedEntity != null)
            entityList.Add(copiedEntity);
        }
        if (entityList.Count > 0)
          clsMW.CamEntitiesGroup.Add(entityList);
      }
      if (clsMW.CamEntitiesGroup.Count > 0)
      {
        this.MWCalcOptions.DontShowbuDialogBox = true;
        this.MWCalcOptions.DontShowDialogBox = true;
        this.MWCalcOptions.UseSortedAndSplitedEntities = true;
      }
    }
    this.MWCalcOptions.ShowProgressForm = true;
    if (this.MWCalcOptions.Editing)
    {
      if (this.activeJob.CamList[this.SelectedCamIndex].CamEntities.Count == 0)
        return;
      RouterCam = new Router3AXCAM(this.activeJob.CamList[this.SelectedCamIndex]);
      clsMW.CamEntities.Clear();
      buEntity.Copy(this.activeJob.CamList[this.SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
      RouterCam.CamData = new camTp();
      RouterCam.CamEntities.Clear();
      clsMW.varbuCamWFContourPars = new camParameters5(this.activeJob.CamList[this.SelectedCamIndex].CamPars);
    }
    int num = clsInit.appMW.doWireframeContour(this.MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
    buMWRouter3XVars.varCamWireframeRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWRouter3XVars.varCamWireframeRough.buPar);
    buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeRough.mwPar, ref buMWRouter3XVars.varCamWireframeRough.buPar);
    if (num >= 1)
    {
      if (CamName.Trim().Length > 0)
      {
        RouterCam.CamData.Name = CamName;
        RouterCam.CamName = CamName;
      }
      RouterCam.camWireframeType = this.MWCalcOptions.CamWireframeType;
      buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
      RouterCam.Purpose = Purpose;
      RouterCam.Tool = new ToolBase5(Tool);
      clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
      this.doPlaneCalculation(buMWRouter3XVars.varCamWireframeRough.buPar, ref RouterCam);
      RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeRough.buPar);
      this.doAddOrEditCam(RouterCam, this.MWCalcOptions.Editing);
      this.JobUpdate();
      this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
      this.UpdateDrawJob(this.SelectedCamIndex);
      this.SaveRouter3XFile();
      clsInit.appCommand.Reset();
    }
    else
    {
      buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
      clsInit.appCommand.Reset();
    }
  }

  public void doWireframeCenterPath(
    Router3AXLayerPurpose Purpose,
    ToolBase5 Tool,
    List<EntitiesList> EntGroup = null,
    string CamName = "")
  {
    if (this.activeJob == null)
      this.activeJob = new Router3AXItem();
    Router3AXCAM RouterCam = new Router3AXCAM();
    RouterCam.entitiesPlane = new Router3AXCamPlane();
    switch (Purpose)
    {
      case Router3AXLayerPurpose.Derz:
        buMWRouter3XVars.varCamWireframeCompGrove.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
        buMWRouter3XVars.varCamWireframeCompGrove.buPar.Offsets.OpenContour = CamOpenContourType.Center;
        buMWRouter3XVars.varCamWireframeCompGrove.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompGrove.mwPar, buMWRouter3XVars.varCamWireframeCompGrove.buPar, out clsMW.varbuCamWFContourPars);
        break;
      case Router3AXLayerPurpose.CenterCut:
        buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
        buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Offsets.OpenContour = CamOpenContourType.Center;
        buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar, buMWRouter3XVars.varCamWireframeCompCutCenter.buPar, out clsMW.varbuCamWFContourPars);
        break;
      case Router3AXLayerPurpose.Text:
        buMWRouter3XVars.varCamWireframeCompText.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
        buMWRouter3XVars.varCamWireframeCompText.buPar.Offsets.OpenContour = CamOpenContourType.Center;
        buMWRouter3XVars.varCamWireframeCompText.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompText.mwPar, buMWRouter3XVars.varCamWireframeCompText.buPar, out clsMW.varbuCamWFContourPars);
        break;
      default:
        buMWRouter3XVars.varCamWireframeCenterPath.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
        buMWRouter3XVars.varCamWireframeCenterPath.buPar.Offsets.OpenContour = CamOpenContourType.Center;
        buMWRouter3XVars.varCamWireframeCenterPath.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.RapidRetractFlg = true;
        buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
        clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCenterPath.mwPar, buMWRouter3XVars.varCamWireframeCenterPath.buPar, out clsMW.varbuCamWFContourPars);
        break;
    }
    camResult Result = (camResult) null;
    clsMW.CamEntities.Clear();
    this.MWCalcOptions.UseSortedAndSplitedEntities = false;
    this.MWCalcOptions.HeightFromEntities = false;
    this.MWCalcOptions.isBuWireframeCalculation = clsRouter3AX.varRouter3AXSettings.BuCenterCalculation;
    this.MWCalcOptions.CamMode = CamMode.WireFrame;
    if (!clsRouter3AX.varRouter3AXSettings.BuCenterCalculation)
    {
      if ((EntGroup == null ? 0 : (EntGroup.Count > 0 ? 1 : 0)) != 0)
      {
        clsMW.CamEntitiesGroup.Clear();
        for (int index1 = 0; index1 <= EntGroup.Count - 1; ++index1)
        {
          List<Entity> entityList = new List<Entity>();
          for (int index2 = 0; index2 <= EntGroup[index1].Entities.Count - 1; ++index2)
          {
            Entity copiedEntity = (Entity) null;
            if (EntGroup[index1].Entities[index2] is buLinearPath)
            {
              for (int index3 = 1; index3 <= EntGroup[index1].Entities[index2].Vertices.Count - 1; ++index3)
              {
                Line line = new Line(EntGroup[index1].Entities[index2].Vertices[index3 - 1], EntGroup[index1].Entities[index2].Vertices[index3]);
                CustomData CD = new CustomData();
                buEntity.EntityToCustomData(EntGroup[index1].Entities[index2], ref CD);
                line.EntityData = (object) CD;
                entityList.Add((Entity) line);
              }
            }
            else
            {
              buEntity.Copy(EntGroup[index1].Entities[index2], ref copiedEntity);
              if (copiedEntity != null)
                entityList.Add(copiedEntity);
            }
          }
          if (entityList.Count > 0)
            clsMW.CamEntitiesGroup.Add(entityList);
        }
        if (clsMW.CamEntitiesGroup.Count > 0)
        {
          this.MWCalcOptions.DontShowbuDialogBox = true;
          this.MWCalcOptions.DontShowDialogBox = true;
          this.MWCalcOptions.UseSortedAndSplitedEntities = true;
        }
      }
    }
    else if ((EntGroup == null ? 0 : (EntGroup.Count > 0 ? 1 : 0)) != 0)
    {
      List<buEntity> BaseRefEntities = new List<buEntity>();
      for (int index4 = 0; index4 <= EntGroup.Count - 1; ++index4)
      {
        for (int index5 = 0; index5 <= EntGroup[index4].Entities.Count - 1; ++index5)
        {
          buEntity buEntity = buEntity.Copy(EntGroup[index4].Entities[index5]);
          BaseRefEntities.Add(buEntity);
        }
      }
      List<buEntity> SortedEntities = new List<buEntity>();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].StartPoint, ref BaseRefEntities, new SortbuSettings()
      {
        Option = {
          NextGroupRules = SortingNextGroupFindRulesType.ClosestLength
        }
      }, ref SortedEntities);
      List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      if (SplitedEntitites.Count > 0)
      {
        clsMW.CamEntitiesGroup.Clear();
        for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
        {
          List<Entity> copiedEntities = new List<Entity>();
          buEntity.Copy(SplitedEntitites[index], ref copiedEntities);
          clsMW.CamEntitiesGroup.Add(copiedEntities);
        }
        this.MWCalcOptions.DontShowbuDialogBox = true;
        this.MWCalcOptions.DontShowDialogBox = true;
        this.MWCalcOptions.UseSortedAndSplitedEntities = true;
      }
    }
    if (this.MWCalcOptions.Editing)
    {
      if (this.activeJob.CamList[this.SelectedCamIndex].CamEntities.Count == 0)
        return;
      RouterCam = new Router3AXCAM(this.activeJob.CamList[this.SelectedCamIndex]);
      clsMW.CamEntities.Clear();
      buEntity.Copy(this.activeJob.CamList[this.SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
      RouterCam.CamData = new camTp();
      RouterCam.CamEntities.Clear();
      clsMW.varbuCamWFContourPars = new camParameters5(this.activeJob.CamList[this.SelectedCamIndex].CamPars);
    }
    int num = clsInit.appMW.doWireframeContour(this.MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
    buMWRouter3XVars.varCamWireframeCenterPath.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWRouter3XVars.varCamWireframeCenterPath.buPar);
    buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeCenterPath.mwPar, ref buMWRouter3XVars.varCamWireframeCenterPath.buPar);
    if (num >= 1 & RouterCam.CamData.CamPoints.Count > 0)
    {
      if (CamName.Trim().Length > 0)
      {
        RouterCam.CamData.Name = CamName;
        RouterCam.CamName = CamName;
      }
      buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
      RouterCam.Purpose = Purpose;
      RouterCam.Tool = new ToolBase5(Tool);
      clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
      this.doPlaneCalculation(buMWRouter3XVars.varCamWireframeCenterPath.buPar, ref RouterCam);
      RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeCenterPath.buPar);
      this.doAddOrEditCam(RouterCam, this.MWCalcOptions.Editing);
      this.JobUpdate();
      this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
      this.UpdateDrawJob(this.SelectedCamIndex);
      this.SaveRouter3XFile();
      clsInit.appCommand.Reset();
    }
    else
    {
      buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
      clsInit.appCommand.Reset();
    }
  }

  public void doTriangularMesh3AX(
    CamTriangularMeshType CamType,
    ToolBase5 Tool,
    List<EntitiesList> EntGroup = null,
    string CamName = "")
  {
    if (this.activeJob == null)
      this.activeJob = new Router3AXItem();
    Router3AXCAM RouterCam = new Router3AXCAM();
    RouterCam.entitiesPlane = new Router3AXCamPlane();
    switch (CamType)
    {
      case CamTriangularMeshType.Rough:
        buMWRouter3XVars.varCamMeshRough.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamMeshRough.mwPar.MachParam.RapidRetractFlg = true;
        clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshRough.mwPar, buMWRouter3XVars.varCamMeshRough.buPar, out clsMW.varbuCamMeshRoughPars);
        break;
      case CamTriangularMeshType.ParallelCuts:
        buMWRouter3XVars.varCamMeshParallel.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamMeshParallel.mwPar.MachParam.RapidRetractFlg = true;
        clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshParallel.mwPar, buMWRouter3XVars.varCamMeshParallel.buPar, out clsMW.varbuCamMeshParallelPars);
        break;
      case CamTriangularMeshType.ConstantZ:
        buMWRouter3XVars.varCamMeshConstantZ.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamMeshConstantZ.mwPar.MachParam.RapidRetractFlg = true;
        clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshConstantZ.mwPar, buMWRouter3XVars.varCamMeshConstantZ.buPar, out clsMW.varbuCamMeshConstantZPars);
        break;
      default:
        buString5.MessageBoxError(buLangTranslate.preDef.UnknownCam);
        return;
    }
    camResult Result = (camResult) null;
    clsMW.CamEntities.Clear();
    this.MWCalcOptions.DontShowbuDialogBox = false;
    this.MWCalcOptions.CamMode = CamMode.TriangularMesh;
    if (this.MWCalcOptions.Editing)
    {
      if (this.activeJob.CamList[this.SelectedCamIndex].CamEntities.Count == 0)
        return;
      RouterCam = new Router3AXCAM(this.activeJob.CamList[this.SelectedCamIndex]);
      clsMW.CamEntities.Clear();
      buEntity.Copy(this.activeJob.CamList[this.SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
      RouterCam.CamData = new camTp();
      RouterCam.CamEntities.Clear();
      clsMW.varbuCamWFContourPars = new camParameters5(this.activeJob.CamList[this.SelectedCamIndex].CamPars);
    }
    int num = clsInit.appMW.doTriangularMesh3D(this.MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
    RouterCam.camMode = CamMode.TriangularMesh;
    RouterCam.camMeshType = CamType;
    if (CamType == CamTriangularMeshType.Rough)
    {
      buMWRouter3XVars.varCamMeshRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWRouter3XVars.varCamMeshRough.buPar);
      buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshRough.mwPar, ref buMWRouter3XVars.varCamMeshRough.buPar);
    }
    if (CamType == CamTriangularMeshType.ParallelCuts)
    {
      buMWRouter3XVars.varCamMeshParallel.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRouter3XVars.varCamMeshParallel.buPar);
      buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshParallel.mwPar, ref buMWRouter3XVars.varCamMeshParallel.buPar);
    }
    if (CamType == CamTriangularMeshType.ConstantZ)
    {
      buMWRouter3XVars.varCamMeshConstantZ.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRouter3XVars.varCamMeshConstantZ.buPar);
      buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshConstantZ.mwPar, ref buMWRouter3XVars.varCamMeshConstantZ.buPar);
    }
    if (num >= 1)
    {
      if (CamName.Trim().Length > 0)
      {
        RouterCam.CamData.Name = CamName;
        RouterCam.CamName = CamName;
      }
      buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
      RouterCam.Tool = new ToolBase5(Tool);
      RouterCam.Purpose = Router3AXLayerPurpose.None;
      clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
      this.doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
      if (CamType == CamTriangularMeshType.Rough)
        RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamMeshRough.buPar);
      if (CamType == CamTriangularMeshType.ParallelCuts)
        RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamMeshParallel.buPar);
      if (CamType == CamTriangularMeshType.ConstantZ)
        RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamMeshConstantZ.buPar);
      this.doAddOrEditCam(RouterCam, this.MWCalcOptions.Editing);
      this.JobUpdate();
      this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
      this.UpdateDrawJob(this.SelectedCamIndex);
      this.SaveRouter3XFile();
      clsInit.appCommand.Reset();
    }
    else
    {
      buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
      clsInit.appCommand.Reset();
    }
  }

  public void doTriangularMesh5AX(
    CamTriangularMesh5AxType CamType,
    ToolBase5 Tool,
    List<EntitiesList> EntGroup = null,
    string CamName = "")
  {
    if (this.activeJob == null)
      this.activeJob = new Router3AXItem();
    Router3AXCAM RouterCam = new Router3AXCAM();
    RouterCam.entitiesPlane = new Router3AXCamPlane();
    switch (CamType)
    {
      case CamTriangularMesh5AxType.Rough:
        this.MWCalcOptions.CamTriMesh5AXType = CamTriangularMesh5AxType.Rough;
        buMWRouter3XVars.varCamMeshRough5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamMeshRough5AX.mwPar.MachParam.RapidRetractFlg = true;
        clsMW.varMWCamMeshRough5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshRough5AX.mwPar, buMWRouter3XVars.varCamMeshRough5AX.buPar, out clsMW.varbuCamMeshRough5AXPars);
        RouterCam.camSurfType = CamSurfaceType.MeshRough;
        RouterCam.camMesh5AXType = CamTriangularMesh5AxType.Rough;
        break;
      case CamTriangularMesh5AxType.ParallelCuts:
        this.MWCalcOptions.CamTriMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;
        buMWRouter3XVars.varCamMeshParallel5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamMeshParallel5AX.mwPar.MachParam.RapidRetractFlg = true;
        clsMW.varMWCamMeshParalel5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, buMWRouter3XVars.varCamMeshParallel5AX.buPar, out clsMW.varbuCamMeshParallel5AXPars);
        RouterCam.camSurfType = CamSurfaceType.MeshParalel;
        RouterCam.camMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;
        break;
      case CamTriangularMesh5AxType.ConstantZ:
        this.MWCalcOptions.CamTriMesh5AXType = CamTriangularMesh5AxType.ConstantZ;
        buMWRouter3XVars.varCamMeshConstantZ5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
        buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar.MachParam.RapidRetractFlg = true;
        clsMW.varMWCamMeshContantZ5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar, buMWRouter3XVars.varCamMeshConstantZ5AX.buPar, out clsMW.varbuCamMeshConstantZ5AXPars);
        RouterCam.camSurfType = CamSurfaceType.MeshConstantZ;
        RouterCam.camMesh5AXType = CamTriangularMesh5AxType.ConstantZ;
        break;
      default:
        buString5.MessageBoxError(buLangTranslate.preDef.UnknownCam);
        return;
    }
    camResult Result = (camResult) null;
    clsMW.CamEntities.Clear();
    this.MWCalcOptions.DontShowbuDialogBox = false;
    if (this.MWCalcOptions.Editing)
    {
      if (this.activeJob.CamList[this.SelectedCamIndex].CamEntities.Count == 0)
        return;
      RouterCam = new Router3AXCAM(this.activeJob.CamList[this.SelectedCamIndex]);
      clsMW.CamEntities.Clear();
      buEntity.Copy(this.activeJob.CamList[this.SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
      RouterCam.CamData = new camTp();
      RouterCam.CamEntities.Clear();
      clsMW.varbuCamWFContourPars = new camParameters5(this.activeJob.CamList[this.SelectedCamIndex].CamPars);
    }
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.SmoothingFlg = true;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 30.0;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 150.0;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 30.0;
    clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 150.0;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.SmoothingFlg = true;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 30.0;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 150.0;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 30.0;
    clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 150.0;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.SmoothingFlg = true;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 30.0;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 150.0;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 30.0;
    clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 150.0;
    this.MWCalcOptions.CamMode = CamMode.TriangularMesh5AX;
    this.MWCalcOptions.NumberofAxis = 5;
    this.MWCalcOptions.StartPointX = 0.0;
    this.MWCalcOptions.StartPointY = -970.0;
    this.MWCalcOptions.UseConstantStartPoint = true;
    int num1 = clsInit.appMW.doTriangularMesh3D5Axis(this.MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
    RouterCam.camMode = CamMode.TriangularMesh5AX;
    switch (CamType)
    {
      case CamTriangularMesh5AxType.Rough:
        buMWRouter3XVars.varCamMeshRough5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRough5AXPars, clsMW.varbuCamMeshRough5AXPars, out buMWRouter3XVars.varCamMeshRough5AX.buPar);
        buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshRough5AX.mwPar, ref buMWRouter3XVars.varCamMeshRough5AX.buPar);
        break;
      case CamTriangularMesh5AxType.ParallelCuts:
        buMWRouter3XVars.varCamMeshParallel5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalel5AXPars, clsMW.varbuCamMeshParallel5AXPars, out buMWRouter3XVars.varCamMeshParallel5AX.buPar);
        buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, ref buMWRouter3XVars.varCamMeshParallel5AX.buPar);
        break;
      case CamTriangularMesh5AxType.ConstantZ:
        buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZ5AXPars, clsMW.varbuCamMeshConstantZ5AXPars, out buMWRouter3XVars.varCamMeshConstantZ5AX.buPar);
        buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar, ref buMWRouter3XVars.varCamMeshConstantZ5AX.buPar);
        break;
    }
    RouterCam.Tool = new ToolBase5(Tool);
    int num2 = 0;
    double num3 = 0.0;
    for (int index1 = 0; index1 <= RouterCam.CamData.CamPoints.Count - 1; ++index1)
    {
      bool flag1 = false;
      bool flag2 = false;
      if (index1 == 134)
        ;
      for (int index2 = 0; index2 <= RouterCam.CamData.CamPoints[index1].Points.Count - 1; ++index2)
      {
        TpPnt9D point = RouterCam.CamData.CamPoints[index1].Points[index2];
        double double_4 = 0.0;
        double double_2 = 0.0;
        IJK ijk = new IJK(point.P9.A, point.P9.B, point.P9.C);
        Point3D MovePoint = new Point3D(point.P9.X, point.P9.Y, point.P9.Z);
        Pnt6D CalcPoint = new Pnt6D();
        double a = point.P9.A;
        double b = point.P9.B;
        Class5.smethod_155(point.P9.C, a, ref double_2, b, out double_4);
        if (index2 > 0)
        {
          if (double_2 > 370.0)
            ;
          if (double_2 < -370.0)
            ;
          if (Math.Abs(double_2 - num3) > 180.0)
            ;
          if (double_2 > 370.0)
            flag1 = true;
          if (double_2 < -370.0)
            flag2 = true;
        }
        OrientationAngle Orientation = new OrientationAngle(0.0, double_4, double_2);
        clsInit.cKinematic5.ForwardKinematix5AxMilling(RouterCam.Tool.Geometry.Length, ccVars.KinematicOrjinal.RotateCenterOffsetOfB.Y, ijk, Orientation, MovePoint, ref CalcPoint);
        point.P9.X = CalcPoint.X;
        point.P9.Y = CalcPoint.Y;
        point.P9.Z = CalcPoint.Z;
        point.P9.A = CalcPoint.A;
        point.P9.B = CalcPoint.B;
        point.P9.C = CalcPoint.C;
        if (point.P9.C > 370.0)
          ;
        if (point.P9.C < -370.0)
          ;
        if (num2 > 0)
        {
          double num4 = num3 - point.P9.C;
          if (num4 > 180.0 | num4 < -180.0)
          {
            if (num4 < 0.0)
              point.P9.C -= 360.0;
            else
              point.P9.C += 360.0;
          }
        }
        if (index2 > 0 && Math.Abs(RouterCam.CamData.CamPoints[index1].Points[index2].P9.C - RouterCam.CamData.CamPoints[index1].Points[index2 - 1].P9.C) > 180.0)
        {
          double num5 = RouterCam.CamData.CamPoints[index1].Points[index2 - 1].P9.C - RouterCam.CamData.CamPoints[index1].Points[index2].P9.C;
          if (num5 > 180.0 | num5 < -180.0)
          {
            if (num5 < 0.0)
              RouterCam.CamData.CamPoints[index1].Points[index2].P9.C -= 360.0;
            else
              RouterCam.CamData.CamPoints[index1].Points[index2].P9.C += 360.0;
          }
        }
        if (point.P9.C > 370.0)
          flag1 = true;
        if (point.P9.C < -370.0)
          flag2 = true;
        num3 = point.P9.C;
        ++num2;
      }
      if (flag1 & flag2)
        ;
      if (flag1)
      {
        for (int index3 = 0; index3 <= RouterCam.CamData.CamPoints[index1].Points.Count - 1; ++index3)
          RouterCam.CamData.CamPoints[index1].Points[index3].P9.C -= 360.0;
        num3 -= 360.0;
      }
      if (flag2)
      {
        for (int index4 = 0; index4 <= RouterCam.CamData.CamPoints[index1].Points.Count - 1; ++index4)
          RouterCam.CamData.CamPoints[index1].Points[index4].P9.C += 360.0;
        num3 += 360.0;
      }
    }
    for (int index5 = 0; index5 <= RouterCam.CamData.CamPoints.Count - 1; ++index5)
    {
      if (index5 > 0 && Math.Abs(RouterCam.CamData.CamPoints[index5 - 1].Points[RouterCam.CamData.CamPoints[index5 - 1].Points.Count - 1].P9.C - RouterCam.CamData.CamPoints[index5].Points[0].P9.C) > 180.0)
      {
        TpPnt9D Pnt = new TpPnt9D(RouterCam.CamData.CamPoints[index5 - 1].Points[RouterCam.CamData.CamPoints[index5 - 1].Points.Count - 1]);
        Pnt.P9.Z = 100.0;
        Pnt.Type = 0;
        RouterCam.CamData.CamPoints[index5 - 1].Points.Add(Pnt);
        TpPnt9D tpPnt9D = new TpPnt9D(Pnt);
        tpPnt9D.P9.C = RouterCam.CamData.CamPoints[index5].Points[0].P9.C;
        RouterCam.CamData.CamPoints[index5 - 1].Points.Add(tpPnt9D);
      }
      for (int index6 = 1; index6 <= RouterCam.CamData.CamPoints[index5].Points.Count - 1; ++index6)
      {
        if (Math.Abs(RouterCam.CamData.CamPoints[index5].Points[index6 - 1].P9.C - RouterCam.CamData.CamPoints[index5].Points[index6].P9.C) > 180.0)
          ;
      }
    }
    for (int index = 0; index <= RouterCam.CamData.SimilationPoint.SimMove.Count - 1; ++index)
    {
      Pnt6DSimMove pnt6DsimMove = RouterCam.CamData.SimilationPoint.SimMove[index];
      double double_4 = 0.0;
      double double_2 = 0.0;
      double a = pnt6DsimMove.A;
      double b = pnt6DsimMove.B;
      Class5.smethod_155(pnt6DsimMove.C, a, ref double_2, b, out double_4);
      pnt6DsimMove.A = 0.0;
      pnt6DsimMove.B = double_4;
      pnt6DsimMove.C = double_2;
    }
    if (num1 >= 1)
    {
      if (CamName.Trim().Length > 0)
      {
        RouterCam.CamData.Name = CamName;
        RouterCam.CamName = CamName;
      }
      buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
      RouterCam.Tool = new ToolBase5(Tool);
      RouterCam.Purpose = Router3AXLayerPurpose.None;
      clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
      this.doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
      this.doAddOrEditCam(RouterCam, this.MWCalcOptions.Editing);
      this.JobUpdate();
      this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
      this.UpdateDrawJob(this.SelectedCamIndex);
      this.SaveRouter3XFile();
      clsInit.appCommand.Reset();
    }
    else
    {
      buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
      clsInit.appCommand.Reset();
    }
  }

  public void doSurface5AX(
    CamSurfaceType CamType,
    ToolBase5 Tool,
    List<EntitiesList> EntGroup = null,
    string CamName = "")
  {
    if (this.activeJob == null)
      this.activeJob = new Router3AXItem();
    Router3AXCAM RouterCam = new Router3AXCAM();
    RouterCam.entitiesPlane = new Router3AXCamPlane();
    if (CamType == CamSurfaceType.SurfaceParalel)
    {
      this.MWCalcOptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
      buMWRouter3XVars.varCamMeshParallel5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
      buMWRouter3XVars.varCamMeshParallel5AX.mwPar.MachParam.RapidRetractFlg = true;
      clsMW.varMWCamMeshParalel5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, buMWRouter3XVars.varCamMeshParallel5AX.buPar, out clsMW.varbuCamSurfaceParallelPars);
      camResult Result = (camResult) null;
      clsMW.CamEntities.Clear();
      this.MWCalcOptions.DontShowbuDialogBox = true;
      if (this.MWCalcOptions.Editing)
      {
        if (this.activeJob.CamList[this.SelectedCamIndex].CamEntities.Count == 0)
          return;
        RouterCam = new Router3AXCAM(this.activeJob.CamList[this.SelectedCamIndex]);
        clsMW.CamEntities.Clear();
        buEntity.Copy(this.activeJob.CamList[this.SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
        RouterCam.CamData = new camTp();
        RouterCam.CamEntities.Clear();
        clsMW.varbuCamWFContourPars = new camParameters5(this.activeJob.CamList[this.SelectedCamIndex].CamPars);
      }
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 45.0;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 135.0;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 45.0;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 135.0;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.ParallelMachAngleInYX = 90.0;
      clsMW.varMWCamMeshParalel5AXPars.MachParam.MaxStepoverDistance = 5.0;
      this.MWCalcOptions.NumberofAxis = 5;
      int num = clsInit.appMW.doTriangularMesh3D5Axis(this.MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
      RouterCam.camMode = CamMode.TriangularMesh;
      RouterCam.camSurfType = CamType;
      if (CamType == CamSurfaceType.SurfaceParalel)
      {
        buMWRouter3XVars.varCamMeshParallel5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalel5AXPars, clsMW.varbuCamMeshParallel5AXPars, out buMWRouter3XVars.varCamMeshParallel5AX.buPar);
        buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, ref buMWRouter3XVars.varCamMeshParallel5AX.buPar);
      }
      for (int index1 = 0; index1 <= RouterCam.CamData.CamPoints.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= RouterCam.CamData.CamPoints[index1].Points.Count - 1; ++index2)
        {
          TpPnt9D point = RouterCam.CamData.CamPoints[index1].Points[index2];
          double double_4 = 0.0;
          double double_2 = 0.0;
          double a = point.P9.A;
          double b = point.P9.B;
          Class5.smethod_155(point.P9.C, a, ref double_2, b, out double_4);
          point.P9.A = 0.0;
          point.P9.B = double_4;
          point.P9.C = double_2;
        }
      }
      for (int index = 0; index <= RouterCam.CamData.SimilationPoint.SimMove.Count - 1; ++index)
      {
        Pnt6DSimMove pnt6DsimMove = RouterCam.CamData.SimilationPoint.SimMove[index];
        double double_4 = 0.0;
        double double_2 = 0.0;
        double a = pnt6DsimMove.A;
        double b = pnt6DsimMove.B;
        Class5.smethod_155(pnt6DsimMove.C, a, ref double_2, b, out double_4);
        pnt6DsimMove.A = 0.0;
        pnt6DsimMove.B = double_4;
        pnt6DsimMove.C = double_2;
      }
      if (num >= 1)
      {
        if (CamName.Trim().Length > 0)
        {
          RouterCam.CamData.Name = CamName;
          RouterCam.CamName = CamName;
        }
        buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
        RouterCam.Tool = new ToolBase5(Tool);
        RouterCam.Purpose = Router3AXLayerPurpose.None;
        clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
        this.doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
        this.doAddOrEditCam(RouterCam, this.MWCalcOptions.Editing);
        this.JobUpdate();
        this.DrawJob(new DrawOptions(true), this.SelectedCamIndex);
        this.UpdateDrawJob(this.SelectedCamIndex);
        this.SaveRouter3XFile();
        clsInit.appCommand.Reset();
      }
      else
      {
        buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
        clsInit.appCommand.Reset();
      }
    }
    else
      buString5.MessageBoxError(buLangTranslate.preDef.UnknownCam);
  }

  public static void ConvertIJKToBC(
    double I,
    double J,
    double K,
    out double B_deg,
    out double C_deg)
  {
    Math.Sqrt(I * I + J * J + K * K);
    double d = Math.Asin(I);
    double num1 = Math.Cos(d);
    double num2 = Math.Atan2(J / num1, K / num1);
    B_deg = d * 180.0 / Math.PI;
    C_deg = num2 * 180.0 / Math.PI;
  }

  public void doPlaneCalculation(camParameters5 buPar, ref Router3AXCAM RouterCam)
  {
    clsInit.cVector5.CreateCamHeightPlane(buPar.Distances.Safe, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneClearance.Color, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneClearance.Transperancy, $"{buLangTranslate.preDef.Safe} = {buPar.Distances.Safe.ToString("f1")}", CamPlaneHeightType.Clearance, ref RouterCam.entitiesPlane.entityPlaneClearance, ref RouterCam.entitiesPlane.entityPlaneClearanceText);
    if (buPar.Steps.Enable)
    {
      clsInit.cVector5.CreateCamHeightPlane(buPar.Steps.EndValue, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneBottom.Color, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneBottom.Transperancy, $"{buLangTranslate.preDef.Bottom} = {buPar.Steps.EndValue.ToString("f1")}", CamPlaneHeightType.Bottom, ref RouterCam.entitiesPlane.entityPlaneBottom, ref RouterCam.entitiesPlane.entityPlaneBottomText);
      clsInit.cVector5.CreateCamHeightPlane(buPar.Distances.Rapid, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneRetract.Color, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneRetract.Transperancy, $"{buLangTranslate.preDef.Retract} = {buPar.Distances.Rapid.ToString("f1")}", CamPlaneHeightType.Retract, ref RouterCam.entitiesPlane.entityPlaneRetract, ref RouterCam.entitiesPlane.entityPlaneRetractText);
      clsInit.cVector5.CreateCamHeightPlane(buPar.Steps.StartValue, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneTop.Color, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneTop.Transperancy, $"{buLangTranslate.preDef.Top} = {buPar.Steps.StartValue.ToString("f1")}", CamPlaneHeightType.Top, ref RouterCam.entitiesPlane.entityPlaneTop, ref RouterCam.entitiesPlane.entityPlaneTopText);
    }
    else
    {
      clsInit.cVector5.CreateCamHeightPlane(buPar.Operations.Height, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneBottom.Color, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneBottom.Transperancy, $"{buLangTranslate.preDef.Bottom} = {buPar.Steps.EndValue.ToString("f1")}", CamPlaneHeightType.Bottom, ref RouterCam.entitiesPlane.entityPlaneBottom, ref RouterCam.entitiesPlane.entityPlaneBottomText);
      if (this.activeJob.Stock == null)
        return;
      clsInit.cVector5.CreateCamHeightPlane(buPar.Distances.Rapid, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneRetract.Color, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneRetract.Transperancy, $"{buLangTranslate.preDef.Retract} = {buPar.Distances.Rapid.ToString("f1")}", CamPlaneHeightType.Retract, ref RouterCam.entitiesPlane.entityPlaneRetract, ref RouterCam.entitiesPlane.entityPlaneRetractText);
      clsInit.cVector5.CreateCamHeightPlane(this.activeJob.Stock.MaxPoint.Z, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneTop.Color, clsRouter3AX.varRouter3AXDisplaySettings.colorPlaneTop.Transperancy, $"{buLangTranslate.preDef.Top} = {buPar.Steps.StartValue.ToString("f1")}", CamPlaneHeightType.Top, ref RouterCam.entitiesPlane.entityPlaneTop, ref RouterCam.entitiesPlane.entityPlaneTopText);
    }
  }

  public void doAddOrEditCam(Router3AXCAM RouterCam, bool Editing)
  {
    if (!Editing)
    {
      this.activeJob.CamList.Add(RouterCam);
      this.SelectedCamIndex = this.activeJob.CamList.Count - 1;
      ccVars.Pages[ccVars.PageIndex].Cams.Add(RouterCam.CamData);
    }
    else
    {
      this.activeJob.CamList[this.SelectedCamIndex] = RouterCam;
      ccVars.Pages[ccVars.PageIndex].Cams[this.SelectedCamIndex] = RouterCam.CamData;
    }
  }
}
