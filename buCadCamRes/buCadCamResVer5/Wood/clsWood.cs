// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Wood.clsWood
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.Shape;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Wood;

public class clsWood
{
  public List<string> cmdExceptionID = new List<string>();
  private int int_0 = -1;
  private int int_1 = -1;
  private int int_2 = -1;
  private int int_3 = -1;
  private int int_4 = -1;
  private int int_5 = -1;
  private string string_0 = "XZ";
  private bool bool_0 = false;
  private Timer timer_0 = new Timer();
  private ShapeCreateParameters shapeCreateParameters_0 = new ShapeCreateParameters();
  public static WoodJob activeJob;
  public List<buEntity> refEntities = new List<buEntity>();

  public void Init()
  {
    buMWWoodVars.Init();
    this.OpenWoodFile();
    this.LoadLanguage();
  }

  public void InitSimulation()
  {
  }

  public void WoodTree_AfterSelect(object sender, TreeViewEventArgs e)
  {
    if (ccVars.Pages.Count == 0)
      ;
  }

  public void WoodTree_AfterCheck(object sender, TreeViewEventArgs e)
  {
    if (ccVars.Pages.Count == 0)
      ;
  }

  public void ProfileTreeUpdate()
  {
    clsItem.FrmWoodJob.tree_jobs.Nodes.Clear();
    TreeNodeSettings treeNodeSettings1 = new TreeNodeSettings("Job");
    treeNodeSettings1.ImageIndex = 15;
    treeNodeSettings1.SelectedImageIndex = 15;
    treeNodeSettings1.Tag = (object) "-1";
    treeNodeSettings1.ClassIndex = -1;
    treeNodeSettings1.ClassSubIndex = -1;
    treeNodeSettings1.ClassSubSubIndex = -1;
    treeNodeSettings1.Command = "profilebase";
    treeNodeSettings1.Name = "base";
    treeNodeSettings1.Info = "base";
    treeNodeSettings1.Index = 0;
    treeNodeSettings1.Checked = false;
    TreeNodeSettings node = treeNodeSettings1;
    TreeNodeSettings treeNodeSettings2 = (TreeNodeSettings) null;
    if (treeNodeSettings2 != null)
    {
      treeNodeSettings2.Expand();
      node.Expand();
    }
    clsItem.FrmWoodJob.tree_jobs.Nodes.Add((TreeNode) node);
  }

  public void Checked_Checked(object sender, EventArgs e)
  {
    buWood.varWoodRunSettings.SelectMode = clsItem.FrmWoodJob.chk_selectmode.Checked;
    clsItem.FrmWoodJob.tree_jobs.CheckBoxes = buWood.varWoodRunSettings.SelectMode;
    if (buWood.varWoodRunSettings.SelectMode)
      return;
    for (int index = 0; index <= clsItem.FrmWoodJob.tree_jobs.Nodes.Count - 1; ++index)
      clsItem.FrmWoodJob.tree_jobs.Nodes[index].Expand();
  }

  public void cmdNewMaterial(DrillJob panel)
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
      clsItem.FrmMaterial3D.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
    }
    clsItem.FrmMaterial3D.pnl_model.Controls.Add((Control) clsItem.FrmMaterial3D.viewportLayout);
    clsItem.FrmMaterial3D.viewportLayout.Entities.Clear();
    clsItem.FrmMaterial3D.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    ccVars.activeMaterial.Size.Width = buWood.varWoodSettings.MaterialWidth;
    ccVars.activeMaterial.Size.Height = buWood.varWoodSettings.MaterialHeight;
    ccVars.activeMaterial.Size.Depth = buWood.varWoodSettings.MaterialDepth;
    clsItem.FrmMaterial3D.Material = new MaterialBase5(ccVars.activeMaterial);
    if (panel != null)
      clsItem.FrmMaterial3D.Init(panel.Material);
    else
      clsItem.FrmMaterial3D.Init((MaterialBase5) null);
    clsItem.FrmMaterial3D.StartPosition = FormStartPosition.CenterParent;
    int num = (int) clsItem.FrmMaterial3D.ShowDialog();
    if (clsItem.FrmMaterial3D.PropertiesForm.Result == DialogResult.OK)
    {
      ccVars.activeMaterial = new MaterialBase5(clsItem.FrmMaterial3D.Material);
      buWood.varWoodSettings.MaterialWidth = ccVars.activeMaterial.Size.Width;
      buWood.varWoodSettings.MaterialHeight = ccVars.activeMaterial.Size.Height;
      buWood.varWoodSettings.MaterialDepth = ccVars.activeMaterial.Size.Depth;
      if (panel == null)
        this.AddPanel(ccVars.activeMaterial);
    }
    this.SaveWoodFile();
  }

  public void cmdShapes()
  {
    if (clsItem.FrmShapeList == null)
    {
      clsItem.FrmShapeList = new F_ShapeList();
      CreateModelProperties Properties = new CreateModelProperties();
      clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
      Properties.CoordinateSystemIconVisible = false;
      Properties.ViewCubeIconVisible = false;
      Properties.OrigineCaptionVisible = false;
      Properties.ToolBorVisible = false;
      clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
    }
    clsItem.FrmShapeList.selectedShape = buWood.varTemps.lastShape != null ? buShape.Copy(buWood.varTemps.lastShape) : (buShape) new buShapeRectangle(buWood.varWoodRunSettings.ShapeDataParameters.RectangleWidth, buWood.varWoodRunSettings.ShapeDataParameters.RectangleHeight, buWood.varWoodRunSettings.ShapeDataParameters.RectangleRadius, buWood.varWoodRunSettings.ShapeDataParameters.RectangleChamfer, buWood.varWoodRunSettings.ShapeDataParameters.RectangleDepth, buWood.varWoodRunSettings.ShapeDataParameters.RectangleAngle);
    clsItem.FrmShapeList.PropertiesForm.TopMost = true;
    clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
    clsItem.FrmShapeList.Top = 50;
    clsItem.FrmShapeList.Left = 1500;
    clsItem.FrmShapeList.TopMost = true;
    clsItem.FrmShapeList.pnl_model.Controls.Add((Control) clsItem.FrmShapeList.viewportLayout);
    clsItem.FrmShapeList.viewportLayout.Entities.Clear();
    clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmShapeList.Init();
    clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmShapeList.Show();
    clsItem.FrmShapeList.Top = 50;
    clsItem.FrmShapeList.Left = 1500;
  }

  public void cmdSettings()
  {
  }

  public void cmdShowGcode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString5.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        string Lines = "";
        this.cmdCamContour();
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(Lines);
        fNotepad.Show();
        if (clsItem.FrmProgress != null)
          clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSaveGcode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString5.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;
        string Lines = "";
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
        clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
        buFile5.SaveToFile(Lines, saveFileDialog.FileName);
        if (clsItem.FrmProgress != null)
          clsItem.FrmProgress.Visible = false;
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamContour()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Pages[ccVars.PageIndex].Cams.Clear();
      clsMW.CamEntities.Clear();
      for (int index1 = 0; index1 <= clsWood.activeJob.Items.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= clsWood.activeJob.Items[index1].entitiesShape.Count - 1; ++index2)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(clsWood.activeJob.Items[index1].entitiesShape[index2], ref copiedEntity);
          if (clsWood.activeJob.Items[index1].planeName == planeBoxNames.Front)
            copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
          if (clsWood.activeJob.Items[index1].planeName == planeBoxNames.Back)
            copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
          clsMW.CamEntities.Add(copiedEntity);
        }
        camTp Cam = new camTp();
        this.doWireframeContour(new MWCalculationOptions()
        {
          NumberofAxis = 3,
          CamWireframeType = CamWireFrameType.Contour,
          Mode = CamMode.WireFrame,
          DontApplyReset = true,
          isBuWireframeCalculation = false,
          AddToCamListInLocalCalculation = false,
          AddToCamListInMWCalculation = false,
          ShowLeadInOutPage = false,
          DontShowDialogBox = true
        }, ccVars.toolActive, ref Cam);
        ccVars.Pages[ccVars.PageIndex].Cams.Add(Cam);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdAddFromFile()
  {
    if (clsItem.FrmFromFile == null)
      clsItem.FrmFromFile = new F_AddFromFile();
    clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmFromFile.Path = buWood.varWoodSettings.pathFromFile;
    clsItem.FrmFromFile.KeepRatio = buWood.varWoodSettings.FromFileKeepRatio;
    clsItem.FrmFromFile.Init();
    int num = (int) clsItem.FrmFromFile.ShowDialog();
    if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
      return;
    this.shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
    for (int index = 0; index <= clsItem.FrmFromFile.viewport.Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
      this.shapeCreateParameters_0.entitiesCurve.Add(copiedEntity);
    }
    buWood.varWoodSettings.pathFromFile = clsItem.FrmFromFile.Path;
    buWood.varWoodSettings.FromFileKeepRatio = clsItem.FrmFromFile.KeepRatio;
    this.SaveWoodFile();
    buWood.varTemps.lastShape = (buShape) new buShapeFreeDraw(buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawWidth, buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawHeight, buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawDepth, buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawAngle);
    this.cmdShapes();
  }

  public void Sim_Tick(object sender, EventArgs e)
  {
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buWood.lng") : new FileInfo(AppPath.Language + "\\buWood.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodCommands);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Wood Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Wood Language File Missing");
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

  public void SaveWoodFile()
  {
    try
    {
      string FileName1 = AppPath.Settings + "\\Wood\\Wood.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Wood Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "<buWood.varWoodSettings>");
      StringList1.AddRange((ICollection) buWood.varWoodSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buWood.varWoodSettings>");
      StringList1.Add((object) "<buWood.varWoodRunSettings>");
      StringList1.AddRange((ICollection) buWood.varWoodRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buWood.varWoodRunSettings>");
      buFile.SaveToFile(StringList1, FileName1);
      buLog.addLog("Wood Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      buMWWoodVars.varCamContour.mwPar.Serialize(AppPath.Settings + "\\Wood\\mwWoodContour.bin");
      buMWWoodVars.varCamRough.mwPar.Serialize(AppPath.Settings + "\\Wood\\mwWoodRough.bin");
      string FileName2 = AppPath.Settings + "\\Wood\\WoodCam.bucamset";
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "   MW Cam Settings");
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "<MwCamSettings>");
      StringList2.AddRange((ICollection) buMWWoodVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
      StringList2.AddRange((ICollection) buMWWoodVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
      StringList2.Add((object) "</MwCamSettings>");
      buFile.SaveToFile(StringList2, FileName2);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenWoodFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Wood\\Wood.prm");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<buWood.varWoodSettings>", "</buWood.varWoodSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buWood.varWoodSettings);
            buLog.addLog("Wood Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<buWood.varWoodRunSettings>", "</buWood.varWoodRunSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buWood.varWoodRunSettings);
            buLog.addLog("Wood varDrillCNCSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Wood Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Printer3D Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Wood Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Wood Settings File Missing");
      }
      buLog.addLog("Wood Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Wood\\mwWoodContour.bin");
      if (fileInfo2.Exists)
        buMWWoodVars.varCamContour.mwPar.Deserialize(fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Wood\\mwWoodRough.bin");
      if (fileInfo3.Exists)
        buMWWoodVars.varCamRough.mwPar.Deserialize(fileInfo3.FullName);
      string str = AppPath.Settings + "\\Wood\\WoodCam.bucamset";
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
          buSerilization.Decode(StringList, "_varCamContour", SerilizationMode.MultiLine, (object) buMWWoodVars.varCamContour);
          buSerilization.Decode(StringList, "_varCamRough", SerilizationMode.MultiLine, (object) buMWWoodVars.varCamRough);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Wood Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Wood Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Wood Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Wood Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void NewPageExtension() => this.ProfileTreeUpdate();

  public void PageClosed() => this.ProfileTreeUpdate();

  public void AddPanel(MaterialBase5 Mat)
  {
    if (ccVars.Pages.Count <= 0)
      return;
    clsWood.activeJob = new WoodJob();
    clsWood.activeJob.Items = new List<buShape>();
    clsWood.activeJob.Material = new MaterialBase5(Mat);
    this.CreatePanelFromJob(ref clsWood.activeJob, 1.0, true);
    clsInit.appCommand.PagesUpdate(true, "");
    clsInit.appCommand.cmdViewZoomFit();
    clsInit.appCommand.cmdViewZoomOut();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void CreatePanelFromJob(ref WoodJob Job, double Sing, bool Solid)
  {
    try
    {
      Brep box = Brep.CreateBox(Job.Material.Size.Width, Job.Material.Size.Height, Job.Material.Size.Depth);
      if (Sing != 1.0)
        box.Translate(Sing * Job.Material.Size.Width, Sing * Job.Material.Size.Height);
      box.Rebuild(0.1);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      box.LayerName = buWood.varTemps.layerPanel;
      box.ColorMethod = colorMethodType.byEntity;
      box.Color = Color.FromArgb(150, buWood.varWoodSettings.colorPanel);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) box);
      for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
      {
        buShape Shape = Job.Items[index1];
        this.shapeCreateParameters_0.Solid = true;
        clsInit.cVector5.CreatebuShape(ref Shape, this.shapeCreateParameters_0);
        for (int index2 = 0; index2 <= Shape.entitySolid.Count - 1; ++index2)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(Shape.entitySolid[index2], ref copiedEntity);
          copiedEntity.LayerName = buWood.varTemps.layerOperation;
          copiedEntity.ColorMethod = colorMethodType.byEntity;
          copiedEntity.Color = buWood.varWoodSettings.colorOperation;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void ShapeChanged(object Data1, object Data2)
  {
    buShape Shape = Data1 as buShape;
    if (!(Data2 as ShapeUpdateArg).Finished)
    {
      ccVars.pntDrawDynamicLinesArr.Clear();
      this.shapeCreateParameters_0.Solid = false;
      this.shapeCreateParameters_0.Size = new SizeObject(clsWood.activeJob.Material.Size);
      Shape.BasePoint.X = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.X;
      Shape.BasePoint.Y = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Y;
      Shape.BasePoint.Z = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Z;
      clsInit.cVector5.CreatebuShape(ref Shape, this.shapeCreateParameters_0);
      if (Shape.entitiesShape.Count > 0)
      {
        for (int index = 0; index <= Shape.entitiesShape.Count - 1; ++index)
        {
          List<Point3D> copiedPoint = new List<Point3D>();
          buVector5.Copy(Shape.entitiesShape[index].Vertices, ref copiedPoint);
          ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
        }
      }
    }
    else
    {
      this.shapeCreateParameters_0.Solid = true;
      this.shapeCreateParameters_0.Size = new SizeObject(clsWood.activeJob.Material.Size);
      Shape.BasePoint.X = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.X;
      Shape.BasePoint.Y = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Y;
      Shape.BasePoint.Z = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Z;
      clsInit.cVector5.CreatebuShape(ref Shape, this.shapeCreateParameters_0);
      buShape buShape = buShape.Copy(Shape);
      clsWood.activeJob.Items.Add(buShape);
      this.CreatePanelFromJob(ref clsWood.activeJob, 1.0, true);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doReset()
  {
  }

  public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWWoodVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWWoodVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWWoodVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
    buMWWoodVars.varCamContour.buPar.Distances.Air = 0.0;
    buMWWoodVars.varCamContour.buPar.Distances.Safe = 0.0;
    buMWWoodVars.varCamContour.buPar.Distances.Rapid = 0.0;
    buMWWoodVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
    buMWWoodVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
    buMWWoodVars.varCamContour.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
    buMWWoodVars.varCamContour.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWWoodVars.varCamContour.mwPar, buMWWoodVars.varCamContour.buPar);
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWWoodVars.varCamContour.mwPar, buMWWoodVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWWoodVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWWoodVars.varCamContour.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doWireframeRough(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWWoodVars.varCamRough.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWWoodVars.varCamRough.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWWoodVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
    buMWWoodVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
    buMWWoodVars.varCamRough.buPar.Operations.Height = MWCalcoptions.Height;
    buMWWoodVars.varCamRough.buPar.Offsets.OpenContour = CamOpenContourType.Center;
    buMWWoodVars.varCamRough.buPar.Distances.Air = 0.0;
    buMWWoodVars.varCamRough.buPar.Distances.Safe = 0.0;
    buMWWoodVars.varCamRough.buPar.Distances.Rapid = 0.0;
    buMWWoodVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
    buMWWoodVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
    buMWWoodVars.varCamRough.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
    buMWWoodVars.varCamRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWWoodVars.varCamRough.mwPar, buMWWoodVars.varCamRough.buPar);
    clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWWoodVars.varCamRough.mwPar, buMWWoodVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWWoodVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWWoodVars.varCamRough.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }
}
