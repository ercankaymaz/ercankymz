// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.FoamCutting.clsFoamCutting
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Editor;
using buCadCamResVer5.Forms;
using buCadCamResVer5.Library;
using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Foam;
using buEyeBaseVer5.Forms.GCode;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Variables;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.FoamCutting;

public class clsFoamCutting
{
  public List<string> cmdExceptionID = new List<string>();
  public FoamItem activeFoam = new FoamItem();
  public List<List<buEntity>> selectedEntities = new List<List<buEntity>>();
  public List<buEntity> selectedEntity = new List<buEntity>();
  public F_FoamPattern frmPattern = (F_FoamPattern) null;
  public F_FoamWaveForm frmWave = (F_FoamWaveForm) null;
  public F_FoamSlices frmSlice = (F_FoamSlices) null;
  public F_FoamSlicesList frmSliceList = (F_FoamSlicesList) null;
  public List<Color> OperationColors = new List<Color>();
  public List<buEntity> sortRefEntities = new List<buEntity>();
  public FoamPattern activePattern = (FoamPattern) null;
  public FoamBlock activeBlock = (FoamBlock) null;
  public FoamCalcVars varCalc = new FoamCalcVars();
  public TreeView treejobs = new TreeView();
  public Panel pnldata = new Panel();
  public RadioButton radiosortNone = new RadioButton();
  public RadioButton radiosortmanuel = new RadioButton();
  public RadioButton radiosortCW = new RadioButton();
  public RadioButton radiosortJump = new RadioButton();
  public RadioButton radiosortCCW = new RadioButton();
  public RadioButton radiosortHigherIndex = new RadioButton();
  public RadioButton radiosortFirstDirThenAuto = new RadioButton();
  public RadioButton radiosortLowerIndex = new RadioButton();
  private SortbuSettings sortbuSettings_0 = new SortbuSettings();
  private SortbuResult sortbuResult_0 = new SortbuResult();
  private SortPointClickResult sortPointClickResult_0 = new SortPointClickResult();
  private FoamActiveBlock foamActiveBlock_0 = new FoamActiveBlock();
  public List<LengthCount> SliceVerticalList = new List<LengthCount>();
  public List<LengthCount> SliceHorizontalList = new List<LengthCount>();
  private Point3D point3D_0 = new Point3D();
  private Point3D point3D_1 = new Point3D();
  public int simIndex = -1;
  private int int_0 = -1;
  private bool bool_0 = false;
  private bool bool_1 = false;
  private Timer timer_0 = new Timer();
  private Timer timer_1 = new Timer();
  private double double_0 = 0.0;
  private double double_1 = 0.0;
  private double double_2 = 0.0;
  private double double_3 = 0.0;
  private double double_4 = 0.0;
  private int int_1 = 0;
  private int int_2 = 0;
  private int int_3 = 0;
  private int int_4 = 0;

  public event OkCommandWithTwoDataEventHandler CommandFoam;

  public void Init()
  {
    buMWFoamVars.Init();
    this.OpenFoamFile();
    this.LoadLanguage();
    if (clsItem.FrmFoamJob == null)
      clsItem.FrmFoamJob = new F_FoamJob();
    if (buFoamCalc.RadiusFeedList.Count == 0)
    {
      buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(0.0, 5.0, 10.0));
      buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(5.0, 10.0, 15.0));
      buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(10.0, 20.0, 20.0));
      buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(20.0, 40.0, 25.0));
      buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(40.0, 100.0, 50.0));
      buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(100.0, 100000000.0, 100.0));
    }
    if (buFoamCalc.LengthFeedList.Count == 0)
    {
      buFoamCalc.LengthFeedList.Add(new camLengthFeed(0.0, 5.0, 10.0));
      buFoamCalc.LengthFeedList.Add(new camLengthFeed(5.0, 10.0, 15.0));
      buFoamCalc.LengthFeedList.Add(new camLengthFeed(10.0, 20.0, 20.0));
      buFoamCalc.LengthFeedList.Add(new camLengthFeed(20.0, 40.0, 25.0));
      buFoamCalc.LengthFeedList.Add(new camLengthFeed(40.0, 100.0, 50.0));
      buFoamCalc.LengthFeedList.Add(new camLengthFeed(100.0, 100000000.0, 100.0));
    }
    clsItem.FrmFromFile = new F_AddFromFile();
    clsItem.FrmFromFile.ReadFile += new OkCommandWithTwoDataEventHandler(this.OpenFoamPatternFile);
    if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.None)
      this.radiosortNone.Checked = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.CCW)
      this.radiosortCCW.Checked = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.CW)
      this.radiosortCW.Checked = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.FirstDirectionThenAuto)
      this.radiosortFirstDirThenAuto.Checked = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.HigherIndex)
      this.radiosortHigherIndex.Checked = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.Jump)
      this.radiosortJump.Checked = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.LowerIndex)
      this.radiosortLowerIndex.Checked = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.Manuel)
      this.radiosortmanuel.Checked = true;
    this.radiosortCCW.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.radiosortCW.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.radiosortFirstDirThenAuto.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.radiosortHigherIndex.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.radiosortJump.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.radiosortLowerIndex.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.radiosortmanuel.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.radiosortNone.CheckedChanged += new EventHandler(this.radio_CheckedChanged);
    this.timer_0.Tick += new EventHandler(this.Sim_Tick);
    this.timer_0.Interval = 10;
    this.timer_1.Tick += new EventHandler(this.New_Tick);
    this.timer_1.Interval = 500;
    clsInit.appFoamCutting.frmPattern = new F_FoamPattern();
    clsInit.appFoamCutting.frmPattern.DataChanged += new OkCommandWithTwoDataEventHandler(clsInit.appFoamCutting.OperationDataChanged);
    clsInit.appFoamCutting.frmPattern.ParameterChanged += new OkCommandWithTwoDataEventHandler(clsInit.appFoamCutting.ParameterChanged);
    clsInit.appFoamCutting.frmPattern.DataCancel += new CancelCommandEventHandler(clsInit.appFoamCutting.OperationDataCancel);
    clsInit.appFoamCutting.frmPattern.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsInit.appFoamCutting.frmPattern.PropertiesForm.TopMost = true;
    clsInit.appFoamCutting.frmPattern.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsInit.appFoamCutting.frmPattern.StartPosition = FormStartPosition.Manual;
    clsInit.appFoamCutting.frmWave = new F_FoamWaveForm();
    clsInit.appFoamCutting.frmWave.DataChanged += new OkCommandWithTwoDataEventHandler(clsInit.appFoamCutting.OperationDataChanged);
    clsInit.appFoamCutting.frmWave.ParameterChanged += new OkCommandWithTwoDataEventHandler(clsInit.appFoamCutting.ParameterChanged);
    clsInit.appFoamCutting.frmWave.DataCancel += new CancelCommandEventHandler(clsInit.appFoamCutting.OperationDataCancel);
    clsInit.appFoamCutting.frmWave.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsInit.appFoamCutting.frmWave.PropertiesForm.TopMost = true;
    clsInit.appFoamCutting.frmWave.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsInit.appFoamCutting.frmWave.StartPosition = FormStartPosition.Manual;
    clsInit.appFoamCutting.frmSlice = new F_FoamSlices();
    clsInit.appFoamCutting.frmSlice.DataChanged += new OkCommandWithTwoDataEventHandler(clsInit.appFoamCutting.OperationDataChanged);
    clsInit.appFoamCutting.frmSlice.ParameterChanged += new OkCommandWithTwoDataEventHandler(clsInit.appFoamCutting.ParameterChanged);
    clsInit.appFoamCutting.frmSlice.DataCancel += new CancelCommandEventHandler(clsInit.appFoamCutting.OperationDataCancel);
    clsInit.appFoamCutting.frmSlice.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsInit.appFoamCutting.frmSlice.PropertiesForm.TopMost = true;
    clsInit.appFoamCutting.frmSlice.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsInit.appFoamCutting.frmSlice.StartPosition = FormStartPosition.Manual;
  }

  public void InitSimulation()
  {
  }

  public void cmdNewMaterial(FoamItem foam, bool SkipForm = false, bool Editing = false)
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
      Properties.OriginSymbolVisible = false;
      clsInit.cVector5.CreateModelControl(ref clsItem.FrmMaterial3D.viewportLayout, clsVar.UnlockKey, Properties);
    }
    clsItem.FrmMaterial3D.pnl_model.Controls.Add((Control) clsItem.FrmMaterial3D.viewportLayout);
    clsItem.FrmMaterial3D.viewportLayout.Entities.Clear();
    clsItem.FrmMaterial3D.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmMaterial3D.Material.Size.Width = buFoamCalc.varFoamRunSettings.MaterialWidth;
    clsItem.FrmMaterial3D.Material.Size.Height = buFoamCalc.varFoamRunSettings.MaterialHeight;
    clsItem.FrmMaterial3D.Material.Size.Depth = buFoamCalc.varFoamRunSettings.MaterialDepth;
    clsItem.FrmMaterial3D.Material = new MaterialBase5(ccVars.activeMaterial);
    clsItem.FrmMaterial3D.DrawDimension = true;
    if (foam == null)
    {
      clsItem.FrmMaterial3D.Init((MaterialBase5) null);
    }
    else
    {
      clsItem.FrmMaterial3D.Init(foam.Material);
      ccVars.activeMaterial.Size = new SizeObject(foam.Material.Size);
    }
    clsItem.FrmMaterial3D.StartPosition = FormStartPosition.CenterParent;
    if (!SkipForm)
    {
      int num = (int) clsItem.FrmMaterial3D.ShowDialog();
    }
    if (clsItem.FrmMaterial3D.PropertiesForm.Result == DialogResult.OK | SkipForm)
    {
      buFoamCalc.varFoamRunSettings.MaterialWidth = ccVars.activeMaterial.Size.Width;
      buFoamCalc.varFoamRunSettings.MaterialHeight = ccVars.activeMaterial.Size.Height;
      buFoamCalc.varFoamRunSettings.MaterialDepth = ccVars.activeMaterial.Size.Depth;
      if (foam == null)
        this.activeFoam = new FoamItem();
      ccVars.activeMaterial = new MaterialBase5(clsItem.FrmMaterial3D.Material);
      if (foam == null)
        this.doAddFoam(ccVars.activeMaterial, true);
      else
        this.doAddFoam(ccVars.activeMaterial, false);
      this.JobUpdate(true, "", (DrillItem) null, -1);
    }
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
    {
      buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Width;
      buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
    }
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
    {
      buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Height;
      buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
    }
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
    if (clsItem.ModelMainPreview != null)
    {
      clsItem.ModelMainPreview.ActiveViewport.DisplayMode = displayType.Flat;
      clsItem.ModelMainPreview.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
      clsItem.ModelMainPreview.SetView(viewType.Isometric);
      clsItem.ModelMainPreview.ZoomFit();
      clsItem.ModelMainPreview.Invalidate();
    }
    clsFiles.SaveParameter();
    this.SaveFoamFile();
    this.doEditBlocks();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.ViewCubeIcon.FrontText = "Main";
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.ViewCubeIcon.RightText = "Side";
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.ViewCubeIcon.Visible = true;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CompileUserInterfaceElements();
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
      this.cmdPlaneXZ(true);
    else
      this.cmdPlaneYZ(true);
  }

  public void cmdAddBlock()
  {
    if (ccVars.Pages.Count <= 0)
      return;
    FoamBlock foamBlock = new FoamBlock();
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
    {
      foamBlock.BlockName = $"{buLangTranslate.preDef.Block} XZ{this.activeFoam.BlockXZ.Count.ToString()}{1.ToString()}";
      this.activeFoam.BlockXZ.Add(foamBlock);
      this.foamActiveBlock_0.Plane = FoamPlaneType.XZ;
      this.foamActiveBlock_0.BlockIndex = this.activeFoam.BlockXZ.Count - 1;
      this.foamActiveBlock_0.PatternIndex = -1;
    }
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
    {
      foamBlock.BlockName = $"{buLangTranslate.preDef.Block} YZ{this.activeFoam.BlockYZ.Count.ToString()}{1.ToString()}";
      this.activeFoam.BlockYZ.Add(foamBlock);
      this.foamActiveBlock_0.Plane = FoamPlaneType.YZ;
      this.foamActiveBlock_0.BlockIndex = this.activeFoam.BlockYZ.Count - 1;
      this.foamActiveBlock_0.PatternIndex = -1;
    }
    this.JobUpdate(true, "", (DrillItem) null, -1);
  }

  public void cmdAddFromFile(List<buEntity> Entities, List<List<buEntity>> EntitiesGroup)
  {
    if (clsItem.FrmFromFile == null)
      clsItem.FrmFromFile = new F_AddFromFile();
    bool flag1 = false;
    bool flag2 = false;
    if (Entities != null && Entities.Count > 0)
      flag1 = true;
    if (EntitiesGroup != null && EntitiesGroup.Count > 0)
      flag2 = true;
    if (!flag1 & !flag2)
    {
      clsItem.FrmFromFile.ExtensionList.Clear();
      clsItem.FrmFromFile.ExtensionList.Add(".dxf");
      clsItem.FrmFromFile.ExtensionList.Add(".dwg");
      clsItem.FrmFromFile.ExtensionList.Add(".bucadv5");
      clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
      clsItem.FrmFromFile.Path = buFoamCalc.varFoamSettings.pathFromFile;
      clsItem.FrmFromFile.KeepRatio = buFoamCalc.varFoamSettings.FromFileKeepRatio;
      clsItem.FrmFromFile.Init();
      int num = (int) clsItem.FrmFromFile.ShowDialog();
    }
    if (!(clsItem.FrmFromFile.PropertiesForm.Result == DialogResult.OK | flag1 | flag2))
      return;
    List<buEntity> copiedEntities = new List<buEntity>();
    List<buEntity> refEntities1 = new List<buEntity>();
    List<List<buEntity>> refEntities2 = new List<List<buEntity>>();
    buFoamCalc.varFoamSettings.pathFromFile = clsItem.FrmFromFile.Path;
    this.activePattern = new FoamPattern();
    if (!flag1 & !flag2)
    {
      for (int index = 0; index <= clsItem.FrmFromFile.viewport.Entities.Count - 1; ++index)
      {
        buEntity copiedEntity = (buEntity) null;
        buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
        if (clsItem.FrmFromFile.viewport.Entities[index].GetType() == typeof (Circle))
        {
          buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
          buArc Arc1 = new buArc();
          buArc Arc2 = new buArc();
          buArc Arc3 = new buArc();
          buArc Arc4 = new buArc();
          clsInit.cVector5.CircletoFourArc((buCircle) copiedEntity, ref Arc1, ref Arc2, ref Arc3, ref Arc4);
          copiedEntities.Add((buEntity) Arc1);
          copiedEntities.Add((buEntity) Arc2);
          copiedEntities.Add((buEntity) Arc3);
          copiedEntities.Add((buEntity) Arc4);
        }
        else
          copiedEntities.Add(copiedEntity);
      }
    }
    else if (flag1)
      buEntity.Copy(Entities, ref copiedEntities);
    if (copiedEntities.Count > 0)
    {
      FoamEntities foamEntities = new FoamEntities();
      buEntity.Copy(refEntities1, ref this.activePattern.sortEntities);
      buEntity.Copy(copiedEntities, ref foamEntities.GroupEntity.Outside.Entities);
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(foamEntities.GroupEntity.Outside.Entities, ref MinPoint, ref MaxPoint);
      clsInit.cVector5.Move(-MinPoint.X, -MinPoint.Y, 0.0, ref this.activePattern.sortEntities);
      clsInit.cVector5.Move(-MinPoint.X, -MinPoint.Y, 0.0, ref foamEntities.GroupEntity.Outside.Entities);
      clsInit.cVector5.BoxSizeCalculate(foamEntities.GroupEntity.Outside.Entities, ref this.activePattern.BoxMinItem, ref this.activePattern.BoxMaxItem);
      this.activePattern.Width = Math.Round(this.activePattern.BoxMaxItem.X - this.activePattern.BoxMinItem.X, 3);
      this.activePattern.Height = Math.Round(this.activePattern.BoxMaxItem.Y - this.activePattern.BoxMinItem.Y, 3);
      this.SaveFoamFile();
      SortbuSettings Settings = new SortbuSettings();
      Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
      List<buEntity> SortedEntities = new List<buEntity>();
      clsInit.cVector5.SortEntitiesByRefPoint(foamEntities.GroupEntity.Outside.Entities[0].Vertices[0], ref foamEntities.GroupEntity.Outside.Entities, Settings, ref SortedEntities);
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref refEntities2);
      this.activePattern.foamEntities.Add(foamEntities);
    }
    else if (EntitiesGroup.Count > 0)
    {
      this.activePattern.foamEntities.Clear();
      for (int index1 = 0; index1 <= EntitiesGroup.Count - 1; ++index1)
      {
        FoamEntities foamEntities = new FoamEntities();
        for (int index2 = 0; index2 <= EntitiesGroup[index1].Count - 1; ++index2)
          foamEntities.GroupEntity.Outside.Entities.Add(buEntity.Copy(EntitiesGroup[index1][index2]));
        this.activePattern.foamEntities.Add(foamEntities);
      }
      buEntity.Copy(EntitiesGroup, ref refEntities2);
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(refEntities2, ref MinPoint, ref MaxPoint);
      clsInit.cVector5.Move(-MinPoint.X, -MinPoint.Y, 0.0, ref refEntities2);
      clsInit.cVector5.BoxSizeCalculate(refEntities2, ref this.activePattern.BoxMinItem, ref this.activePattern.BoxMaxItem);
      this.activePattern.Width = Math.Round(this.activePattern.BoxMaxItem.X - this.activePattern.BoxMinItem.X, 3);
      this.activePattern.Height = Math.Round(this.activePattern.BoxMaxItem.Y - this.activePattern.BoxMinItem.Y, 3);
    }
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithTwoDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithTwoDataEventHandler_0((object) "PatternCommand", (object) null);
    }
    int width = Screen.PrimaryScreen.Bounds.Width;
    buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Pattern;
    buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.FromDrawing;
    buFoamCalc.varFoamRunSettings.PatternOrjWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternOrjHeight = this.activePattern.Height;
    buFoamCalc.varFoamRunSettings.PatternHeight = this.activePattern.Height;
    this.frmPattern.Location = new System.Drawing.Point(width - this.frmPattern.Width - 40, 200);
    this.frmPattern.Init();
    this.BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
    if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
      this.frmPattern.Show();
    this.OperationDataChanged((object) buFoamCalc.varFoamRunSettings, (object) new FoamUpdateArg()
    {
      PatternSpaceHeight = buFoamCalc.varFoamSettings.PatternDistancesHeight,
      PatternSpaceWidth = buFoamCalc.varFoamSettings.PatternDistancesWidth
    });
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
      this.cmdPlaneXZ(false);
    if (buFoamCalc.varFoamRunSettings.planeNames != FoamPlaneType.YZ)
      return;
    this.cmdPlaneYZ(false);
  }

  public void cmdAddPattern(bool EditPattern = false)
  {
    clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmFromFile.Path = buFoamCalc.varFoamRunSettings.pathFoamPattern;
    clsItem.FrmFromFile.KeepRatio = buFoamCalc.varFoamSettings.FromFileKeepRatio;
    clsItem.FrmFromFile.ExtensionList.Clear();
    clsItem.FrmFromFile.ExtensionList.Add(".foampattern");
    clsItem.FrmFromFile.Init();
    int num1 = (int) clsItem.FrmFromFile.ShowDialog();
    if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
      return;
    buFoamCalc.varFoamRunSettings.pathFoamPattern = clsItem.FrmFromFile.Path;
    clsInit.appCommand.Reset();
    if (EditPattern)
    {
      if (clsItem.frmEditor == null)
        clsItem.frmEditor = new F_Editor();
      clsVar.varEditorRuntimeSet.isFoamMode = true;
      clsVar.varEditorRuntimeSet.isSewingMode = false;
      clsVar.varEditorRuntimeSet.isSketchMode = false;
      clsItem.frmEditor = new F_Editor();
      clsItem.frmEditor.OpenFileExtension.Add("All Supported Files (*.dxf,*.dwg,*.bucadV5)|*.dxf;*.dwg;*.bucadv5");
      clsItem.frmEditor.OpenFileExtension.Add("buCad Cad/Cam Files Ver5.X (*.bucadv5)|*.bucadv5");
      clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dxf)|*.dxf");
      clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dwg)|*.dwg");
      clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.frmEditor.fileNameSorted = clsItem.FrmFromFile.FileName;
      clsItem.frmEditor.Init();
      int num2 = (int) clsItem.frmEditor.ShowDialog((IWin32Window) clsItem.FrmMain);
    }
    else
    {
      List<buEntity> DrawEntities = new List<buEntity>();
      List<buEntity> SortedEntities1 = new List<buEntity>();
      FileInfo fileInfo = new FileInfo(clsItem.FrmFromFile.FileName);
      if (!fileInfo.Exists)
        return;
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithTwoDataEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithTwoDataEventHandler_0((object) "PatternCommand", (object) null);
      }
      clsInit.appEditor.OpenSortedEntities(fileInfo.FullName, ref DrawEntities, ref SortedEntities1);
      this.activePattern = new FoamPattern();
      List<buEntity> refEntities = new List<buEntity>();
      buEntity.Copy(SortedEntities1, ref this.activePattern.sortEntities);
      buEntity.Copy(DrawEntities, ref refEntities);
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
      clsInit.cVector5.Move(-MinPoint.X, -MinPoint.Y, 0.0, ref this.activePattern.sortEntities);
      clsInit.cVector5.Move(-MinPoint.X, -MinPoint.Y, 0.0, ref refEntities);
      clsInit.cVector5.BoxSizeCalculate(refEntities, ref this.activePattern.BoxMinItem, ref this.activePattern.BoxMaxItem);
      this.activePattern.Width = Math.Round(this.activePattern.BoxMaxItem.X - this.activePattern.BoxMinItem.X, 3);
      this.activePattern.Height = Math.Round(this.activePattern.BoxMaxItem.Y - this.activePattern.BoxMinItem.Y, 3);
      this.SaveFoamFile();
      SortbuSettings Settings = new SortbuSettings();
      Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
      List<buEntity> SortedEntities2 = new List<buEntity>();
      List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
      clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].Vertices[0], ref refEntities, Settings, ref SortedEntities2);
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities2, ref SplitedEntitites);
      this.activePattern.foamEntities.Clear();
      for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
      {
        List<Point3D> Points = new List<Point3D>();
        clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index], ref Points);
        buCompositeCurve calcCompositeCurve = (buCompositeCurve) null;
        clsInit.cVector5.CreateCompositeCurveFromEntities(SplitedEntitites[index], ref calcCompositeCurve);
        this.activePattern.foamEntities.Add(new FoamEntities()
        {
          GroupEntity = {
            Outside = {
              Entities = {
                (buEntity) calcCompositeCurve
              }
            }
          }
        });
      }
      int width = Screen.PrimaryScreen.Bounds.Width;
      buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.Pattern;
      buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Pattern;
      buFoamCalc.varFoamRunSettings.PatternOrjWidth = this.activePattern.Width;
      buFoamCalc.varFoamRunSettings.PatternWidth = this.activePattern.Width;
      buFoamCalc.varFoamRunSettings.PatternOrjHeight = this.activePattern.Height;
      buFoamCalc.varFoamRunSettings.PatternHeight = this.activePattern.Height;
      ccVars.Action = actionTypeBU.foamWavePattern;
      if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
        this.activePattern.planeName = FoamPlaneType.XZ;
      if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
        this.activePattern.planeName = FoamPlaneType.YZ;
      this.varCalc.PatternHeight = this.activePattern.Height;
      this.varCalc.PatternWidth = this.activePattern.Width;
      this.varCalc.TypeFoam = FoamType.Pattern;
      this.varCalc.Operation = FoamOperationType.Pattern;
      this.varCalc.planeNames = this.activePattern.planeName;
      this.frmPattern.FoamSize = new SizeObject(this.activeFoam.Material.Size);
      this.frmPattern.Location = new System.Drawing.Point(width - this.frmPattern.Width - 40, 200);
      this.frmPattern.Init();
      this.BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
      if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
        this.frmPattern.Show();
      this.OperationDataChanged((object) buFoamCalc.varFoamRunSettings, (object) new FoamUpdateArg()
      {
        PatternSpaceHeight = buFoamCalc.varFoamSettings.PatternDistancesHeight,
        PatternSpaceWidth = buFoamCalc.varFoamSettings.PatternDistancesWidth
      });
      if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
        this.cmdPlaneXZ(false);
      if (buFoamCalc.varFoamRunSettings.planeNames != FoamPlaneType.YZ)
        return;
      this.cmdPlaneYZ(false);
    }
  }

  public void cmdCreatePattern(List<Entity> refEntitites)
  {
    try
    {
      if (clsItem.frmEditor == null)
        clsItem.frmEditor = new F_Editor();
      clsVar.varEditorRuntimeSet.isFoamMode = true;
      clsVar.varEditorRuntimeSet.isSewingMode = false;
      clsVar.varEditorRuntimeSet.isSketchMode = false;
      clsItem.frmEditor = new F_Editor();
      clsItem.frmEditor.OpenFileExtension.Add("All Supported Files (*.dxf,*.dwg,*.bucadV5)|*.dxf;*.dwg;*.bucadv5");
      clsItem.frmEditor.OpenFileExtension.Add("buCad Cad/Cam Files Ver5.X (*.bucadv5)|*.bucadv5");
      clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dxf)|*.dxf");
      clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dwg)|*.dwg");
      clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      if (refEntitites != null && refEntitites.Count > 0)
        clsItem.frmEditor.entitiesExisting.AddRange((IEnumerable<Entity>) refEntitites);
      clsItem.frmEditor.Init();
      if (clsItem.FrmMain == null)
      {
        int num1 = (int) clsItem.frmEditor.ShowDialog();
      }
      else
      {
        int num2 = (int) clsItem.frmEditor.ShowDialog((IWin32Window) clsItem.FrmMain);
      }
      this.SaveFoamFile();
      clsInit.appEditor.SaveEditorFile();
      List<buEntity> buEntityList = new List<buEntity>();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCreatePatternFromFile()
  {
    clsItem.FrmFromFile.ExtensionList.Clear();
    clsItem.FrmFromFile.ExtensionList.Add(".dxf");
    clsItem.FrmFromFile.ExtensionList.Add(".dwg");
    clsItem.FrmFromFile.ExtensionList.Add(".bucadv5");
    clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmFromFile.Path = buFoamCalc.varFoamSettings.pathFromFile;
    clsItem.FrmFromFile.KeepRatio = buFoamCalc.varFoamSettings.FromFileKeepRatio;
    clsItem.FrmFromFile.Init();
    int num = (int) clsItem.FrmFromFile.ShowDialog();
    if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
      return;
    List<Entity> refEntitites = new List<Entity>();
    List<Entity> entityList = new List<Entity>();
    buEntity.Copy(clsItem.FrmFromFile.viewport.Entities, ref refEntitites);
    clsInit.cVector5.CheckEntities(new CheckEntitesOption(), ref refEntitites);
    if (refEntitites.Count <= 0)
      return;
    this.cmdCreatePattern(refEntitites);
  }

  public void cmdCreatePatternFromSketch(bool isPattern)
  {
    clsItem.frmEditor = new F_Editor();
    clsVar.varEditorRuntimeSet.isFoamMode = false;
    clsVar.varEditorRuntimeSet.isSewingMode = false;
    clsVar.varEditorRuntimeSet.isSketchMode = true;
    clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.frmEditor.Init();
    int num = (int) clsItem.frmEditor.ShowDialog();
    List<Entity> copiedEnt = new List<Entity>();
    buVector5.CopyEntities(clsItem.frmEditor.viewport.Entities, ref copiedEnt);
    if (clsItem.frmEditor.viewport.CurrentSketch.Editing)
    {
      for (int index = copiedEnt.Count - 1; index >= 0; --index)
      {
        if (copiedEnt[index] is SketchEntity)
          copiedEnt.RemoveAt(index);
        else if (copiedEnt[index] is devDept.Eyeshot.Entities.Point)
          copiedEnt.RemoveAt(index);
        else if (copiedEnt[index] is Dimension)
          copiedEnt.RemoveAt(index);
      }
    }
    if (copiedEnt.Count <= 0)
      return;
    if (isPattern)
    {
      this.cmdCreatePattern(copiedEnt);
      copiedEnt.Clear();
    }
    else
    {
      List<buEntity> copiedEntities = new List<buEntity>();
      buEntity.Copy(copiedEnt, ref copiedEntities);
      this.cmdAddFromFile(copiedEntities, (List<List<buEntity>>) null);
      copiedEnt.Clear();
      copiedEntities.Clear();
    }
  }

  public void cmdCreatePatternFromLibrary(bool isPattern)
  {
    if (!new DirectoryInfo(clsVar.varLibrary.pathLibrary).Exists)
      clsVar.varLibrary.pathLibrary = AppPath.Base + "\\Library";
    clsInit.appCommand.cmdLibDraw();
    if (clsItem.FrmLibraryDraw.PropertiesForm.Result != DialogResult.OK)
      return;
    clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
    SketchAnalyseData AnalyseData = new SketchAnalyseData();
    clsInit.appEditor.AnalyseSketchEntity(clsLibrary.LibraryEntities, new SketchAnalyseSetData(clsVar5.ShapeDataParameters.FreeDrawDepth), ref AnalyseData);
    if (AnalyseData.AnalyseEntities.Count <= 0)
      return;
    List<Entity> entityList = new List<Entity>();
    for (int index1 = 0; index1 <= AnalyseData.AnalyseEntities.Count - 1; ++index1)
    {
      if (AnalyseData.AnalyseEntities[index1].GetType() == typeof (buCompositeCurve))
      {
        buCompositeCurve analyseEntity = AnalyseData.AnalyseEntities[index1] as buCompositeCurve;
        for (int index2 = 0; index2 <= analyseEntity.CurveList.Count - 1; ++index2)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(analyseEntity.CurveList[index2], ref copiedEntity);
          entityList.Add(copiedEntity);
        }
      }
      else
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(AnalyseData.AnalyseEntities[index1], ref copiedEntity);
        entityList.Add(copiedEntity);
      }
    }
    if (entityList.Count <= 0)
      return;
    if (isPattern)
    {
      this.cmdCreatePattern(entityList);
      entityList.Clear();
    }
    else
    {
      List<buEntity> copiedEntities = new List<buEntity>();
      buEntity.Copy(entityList, ref copiedEntities);
      this.cmdAddFromFile(copiedEntities, (List<List<buEntity>>) null);
      entityList.Clear();
      copiedEntities.Clear();
    }
  }

  public void cmdWaveMenu()
  {
    F_FoamWaveMenu fFoamWaveMenu = new F_FoamWaveMenu();
    fFoamWaveMenu.foamType = FoamType.SlicesVertical;
    fFoamWaveMenu.Init();
    int num = (int) fFoamWaveMenu.ShowDialog();
    if (fFoamWaveMenu.PropertiesForm.Result != DialogResult.OK)
      return;
    if (fFoamWaveMenu.foamType == FoamType.SlicesHorizontal)
      this.cmdWaveSliceFormHorizontal();
    else
      this.cmdWaveForm(fFoamWaveMenu.foamType);
  }

  public void cmdWaveForm(FoamType Type)
  {
    this.activePattern = new FoamPattern();
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
      this.activePattern.planeName = FoamPlaneType.XZ;
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
      this.activePattern.planeName = FoamPlaneType.YZ;
    clsInit.appCommand.Reset();
    int width = Screen.PrimaryScreen.Bounds.Width;
    buFoamCalc.varFoamRunSettings.TypeFoam = Type;
    buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Wave;
    buFoamCalc.varFoamRunSettings.PatternOrjWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternOrjHeight = this.activePattern.Height;
    buFoamCalc.varFoamRunSettings.PatternHeight = this.activePattern.Height;
    this.BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
    if (Type == FoamType.VForm)
    {
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormVShapeBaseHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormVShapeHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormVShapeWidth;
    }
    if (Type == FoamType.Pyramid)
    {
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeBaseHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeWidth;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonCount = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeCount;
    }
    if (Type == FoamType.UForm)
    {
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormUShapeBaseHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormUShapeHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormUShapeWidth;
    }
    if (Type == FoamType.CForm)
    {
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormCShapeBaseHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormCShapeHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormCShapeWidth;
    }
    if (Type == FoamType.SForm)
    {
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormSShapeBaseHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormSShapeHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormSShapeWidth;
    }
    if (Type == FoamType.ZForm)
    {
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormZShapeBaseHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormZShapeHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormZShapeWidth;
    }
    if (Type == FoamType.Rectangle)
    {
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormRectShapeBaseHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormRectShapeHeight;
      buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormRectShapeWidth;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithTwoDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithTwoDataEventHandler_0((object) "WaveCommand", (object) null);
    }
    buFoamCalc.varFoamRunSettings.TypeFoam = Type;
    ccVars.Action = actionTypeBU.foamWaveShape;
    this.frmWave.Location = new System.Drawing.Point(width - this.frmWave.Width - 40, 200);
    this.frmWave.FoamSize = new SizeObject(this.activeFoam.Material.Size);
    this.frmWave.Init();
    if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
      this.frmWave.Show();
    FoamUpdateArg Data2 = new FoamUpdateArg();
    this.OperationDataChanged((object) buFoamCalc.varFoamRunSettings, (object) Data2);
  }

  public void cmdWaveSliceFormHorizontal()
  {
    this.activePattern = new FoamPattern();
    int width = Screen.PrimaryScreen.Bounds.Width;
    clsInit.appCommand.Reset();
    buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.SlicesHorizontal;
    buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Slice;
    buFoamCalc.varFoamRunSettings.PatternOrjWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternOrjHeight = this.activePattern.Height;
    buFoamCalc.varFoamRunSettings.PatternHeight = this.activePattern.Height;
    this.BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
      this.activePattern.planeName = FoamPlaneType.XZ;
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
      this.activePattern.planeName = FoamPlaneType.YZ;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithTwoDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithTwoDataEventHandler_0((object) "SliceCommand", (object) null);
    }
    this.frmSlice.Location = new System.Drawing.Point(width - this.frmSlice.Width - 40, 200);
    this.frmSlice.FoamSize = new SizeObject(this.activeFoam.Material.Size);
    this.frmSlice.Init();
    ccVars.Action = actionTypeBU.foamWaveSlice;
    if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
      this.frmSlice.Show();
    FoamUpdateArg Data2 = new FoamUpdateArg();
    this.OperationDataChanged((object) buFoamCalc.varFoamRunSettings, (object) Data2);
  }

  public void cmdWaveSliceFormVerical()
  {
    this.activePattern = new FoamPattern();
    int width = Screen.PrimaryScreen.Bounds.Width;
    clsInit.appCommand.Reset();
    this.varCalc.isVertical = true;
    buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.SlicesVertical;
    buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Slice;
    buFoamCalc.varFoamRunSettings.PatternOrjWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternWidth = this.activePattern.Width;
    buFoamCalc.varFoamRunSettings.PatternOrjHeight = this.activePattern.Height;
    buFoamCalc.varFoamRunSettings.PatternHeight = this.activePattern.Height;
    this.BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
      this.activePattern.planeName = FoamPlaneType.XZ;
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
      this.activePattern.planeName = FoamPlaneType.YZ;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithTwoDataEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.okCommandWithTwoDataEventHandler_0((object) "SliceCommand", (object) null);
    }
    this.frmSlice.Location = new System.Drawing.Point(width - this.frmSlice.Width - 40, 200);
    this.frmSlice.FoamSize = new SizeObject(this.activeFoam.Material.Size);
    this.frmSlice.Init();
    ccVars.Action = actionTypeBU.foamWaveSlice;
    if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
      this.frmSlice.Show();
    FoamUpdateArg Data2 = new FoamUpdateArg();
    this.OperationDataChanged((object) buFoamCalc.varFoamRunSettings, (object) Data2);
  }

  public void cmdWaveSingleLine()
  {
  }

  public void cmdDeleteAll()
  {
    if (this.activeFoam == null || buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[15]) != DialogResult.Yes)
      return;
    this.doDeleteAllBlocks();
  }

  public void cmdUndoPattern()
  {
    if (this.foamActiveBlock_0.Plane == FoamPlaneType.XZ)
    {
      int index = this.activeFoam.BlockXZ.Count - 1;
      if (index >= 0 & index <= this.activeFoam.BlockXZ.Count - 1)
      {
        this.activeFoam.BlockXZ.RemoveAt(index);
        this.activeFoam.sortedEntitiesXZ.Clear();
        this.activeFoam.sortedEntitiesYZ.Clear();
        this.activeFoam.CamXZ = new camTp();
        this.activeFoam.CamYZ = new camTp();
        this.activeFoam.isGCodeCreated = false;
      }
    }
    if (this.foamActiveBlock_0.Plane == FoamPlaneType.YZ)
    {
      int index = this.activeFoam.BlockXZ.Count - 1;
      if (index >= 0 & index <= this.activeFoam.BlockYZ.Count - 1)
      {
        this.activeFoam.BlockYZ.RemoveAt(index);
        this.activeFoam.sortedEntitiesXZ.Clear();
        this.activeFoam.sortedEntitiesYZ.Clear();
        this.activeFoam.CamXZ = new camTp();
        this.activeFoam.CamYZ = new camTp();
        this.activeFoam.isGCodeCreated = false;
      }
    }
    this.JobUpdate(true, "", (DrillItem) null, -1);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
  }

  public void cmdSpeedTable()
  {
    F_FoamSpeedList fFoamSpeedList = new F_FoamSpeedList();
    fFoamSpeedList.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
    fFoamSpeedList.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
    fFoamSpeedList.RadiusFeedList.Clear();
    for (int index = 0; index <= buFoamCalc.RadiusFeedList.Count - 1; ++index)
      fFoamSpeedList.RadiusFeedList.Add(new camRadiusFeed(buFoamCalc.RadiusFeedList[index]));
    for (int index = 0; index <= buFoamCalc.LengthFeedList.Count - 1; ++index)
      fFoamSpeedList.LengthFeedList.Add(new camLengthFeed(buFoamCalc.LengthFeedList[index]));
    fFoamSpeedList.Init();
    int num = (int) fFoamSpeedList.ShowDialog();
    if (fFoamSpeedList.PropertiesForm.Result != DialogResult.OK)
      return;
    buFoamCalc.RadiusFeedList.Clear();
    for (int index = 0; index <= fFoamSpeedList.RadiusFeedList.Count - 1; ++index)
      buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(fFoamSpeedList.RadiusFeedList[index]));
    buFoamCalc.LengthFeedList.Clear();
    for (int index = 0; index <= fFoamSpeedList.LengthFeedList.Count - 1; ++index)
      buFoamCalc.LengthFeedList.Add(new camLengthFeed(fFoamSpeedList.LengthFeedList[index]));
    this.SaveFoamFile();
  }

  public void cmdViewObject()
  {
    if (ccVars.Pages.Count <= 0)
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdMenuCommand(object sender, EventArgs e)
  {
    string str = "";
    if (sender is Control)
      str = (sender as Control).Name;
    else if (sender is ToolStripMenuItem)
      str = (sender as ToolStripMenuItem).Name;
    if (str == clsItem.FrmFoamJob.mnu_foamedit.Name && this.activeFoam != null)
      this.cmdNewMaterial(this.activeFoam, Editing: true);
    if (str == clsItem.FrmFoamJob.mnu_foamrename.Name && this.activeFoam != null)
    {
      DialogBoxText dialogBoxText = new DialogBoxText();
      dialogBoxText.Caption = $"{AppLanguage.CadCamDynamic[106]} {AppLanguage.CadCamDynamic[40]}";
      dialogBoxText.Text = $"{AppLanguage.CadCamDynamic[106]} {AppLanguage.CadCamDynamic[40]}";
      dialogBoxText.Init(this.activeFoam.ItemName);
      int num = (int) dialogBoxText.ShowDialog();
      if (dialogBoxText.Result == DialogResult.OK)
      {
        this.activeFoam.ItemName = dialogBoxText.Value;
        this.treejobs.Nodes[0].Text = clsInit.cFoamCut.JobItemName(this.activeFoam);
      }
    }
    if (str == clsItem.FrmFoamJob.mnu_foamdelete.Name && this.activeFoam != null && buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[22]) == DialogResult.Yes)
    {
      this.activeFoam = (FoamItem) null;
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, false));
    }
    if (str == clsItem.FrmFoamJob.mnu_editblock.Name)
      this.doEditBlock();
    if (str == clsItem.FrmFoamJob.mnu_renameblock.Name && this.activeFoam != null & this.foamActiveBlock_0.BlockIndex >= 0)
    {
      DialogBoxText dialogBoxText = new DialogBoxText();
      dialogBoxText.Caption = $"{AppLanguage.CadCamDynamic[106]} {AppLanguage.CadCamDynamic[40]}";
      dialogBoxText.Text = $"{AppLanguage.CadCamDynamic[106]} {AppLanguage.CadCamDynamic[40]}";
      if (this.foamActiveBlock_0.Plane == FoamPlaneType.XZ)
        dialogBoxText.Init(this.activeFoam.BlockXZ[this.foamActiveBlock_0.BlockIndex].BlockName);
      if (this.foamActiveBlock_0.Plane == FoamPlaneType.YZ)
        dialogBoxText.Init(this.activeFoam.BlockYZ[this.foamActiveBlock_0.BlockIndex].BlockName);
      int num = (int) dialogBoxText.ShowDialog();
      if (dialogBoxText.Result == DialogResult.OK)
      {
        if (this.foamActiveBlock_0.Plane == FoamPlaneType.XZ)
        {
          this.activeFoam.BlockXZ[this.foamActiveBlock_0.BlockIndex].BlockName = dialogBoxText.Value;
          this.treejobs.Nodes[0].Nodes[0].Nodes[this.foamActiveBlock_0.BlockIndex].Text = clsInit.cFoamCut.JobBlockName(this.activeFoam.BlockXZ[this.foamActiveBlock_0.BlockIndex]);
        }
        if (this.foamActiveBlock_0.Plane == FoamPlaneType.YZ)
        {
          this.activeFoam.BlockYZ[this.foamActiveBlock_0.BlockIndex].BlockName = dialogBoxText.Value;
          this.treejobs.Nodes[0].Nodes[0].Nodes[this.foamActiveBlock_0.BlockIndex].Text = clsInit.cFoamCut.JobBlockName(this.activeFoam.BlockYZ[this.foamActiveBlock_0.BlockIndex]);
        }
      }
    }
    if (str == clsItem.FrmFoamJob.mnu_deleteblock.Name && this.activeFoam != null & this.foamActiveBlock_0.BlockIndex >= 0 && buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[9]) == DialogResult.Yes)
      this.doDeleteBlocks(this.foamActiveBlock_0.BlockIndex);
    if (str == clsItem.FrmFoamJob.mnu_deleteallblock.Name && this.activeFoam != null && buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[15]) == DialogResult.Yes)
      this.doDeleteAllBlocks();
    if (str == clsItem.FrmFoamJob.mnu_deleteXZselection.Name)
      this.doDeleteSelection(FoamPlaneType.XZ);
    if (str == clsItem.FrmFoamJob.mnu_deleteYZselection.Name)
      this.doDeleteSelection(FoamPlaneType.YZ);
    if (str == clsItem.FrmFoamJob.mnu_redraw.Name && this.activeFoam != null)
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
    if (str == clsItem.FrmFoamJob.btn_viewfront.Name)
    {
      clsItem.ModelMainPreview.SetView(viewType.Front);
      clsItem.ModelMainPreview.Invalidate();
    }
    if (str == clsItem.FrmFoamJob.btn_viewleft.Name)
    {
      clsItem.ModelMainPreview.SetView(viewType.Right);
      clsItem.ModelMainPreview.Invalidate();
    }
    if (str == clsItem.FrmFoamJob.btn_viewiso.Name)
    {
      clsItem.ModelMainPreview.SetView(viewType.Isometric);
      clsItem.ModelMainPreview.Invalidate();
    }
    if (!(str == clsItem.FrmFoamJob.btn_zoomfit.Name))
      return;
    clsItem.ModelMainPreview.ZoomFit();
    clsItem.ModelMainPreview.Invalidate();
  }

  public void AddLeadInLeadOut(
    ref FoamSortGroup sortGroup,
    FoamPlaneType refPlane,
    FoamSequenceHor SequenceType)
  {
    Point3D pntEnd = new Point3D();
    Point3D pntStart = new Point3D();
    if (sortGroup.sortEntities.Count <= 0)
      return;
    if (sortGroup.Direction == NormalReverse.Normal && sortGroup.sortEntities[0].Count > 0)
    {
      if (buFoamCalc.varFoamSettings.LeadInLength > 0.1)
      {
        clsInit.cVector5.GetEntityStartPointByCamDirection(sortGroup.sortEntities[0][0], ref pntStart);
        if (refPlane == FoamPlaneType.XZ)
        {
          Point3D start = new Point3D(pntStart.X - buFoamCalc.varFoamSettings.LeadInLength, pntStart.Y, pntStart.Z);
          Point3D end = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
          if (start.X > sortGroup.MinPoint.X)
            start.X = sortGroup.MinPoint.X - buFoamCalc.varFoamSettings.LeadInLength;
          buLine buLine = new buLine(start, end);
          buLine.typeDefination = entityTypeDefination.CamLeadin;
          sortGroup.sortEntities[0].Insert(0, (buEntity) buLine);
        }
        if (refPlane == FoamPlaneType.YZ)
        {
          Point3D start = new Point3D(pntStart.X, pntStart.Y - buFoamCalc.varFoamSettings.LeadInLength, pntStart.Z);
          Point3D end = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
          if (start.Y > sortGroup.MinPoint.Y)
            start.Y = sortGroup.MinPoint.Y - buFoamCalc.varFoamSettings.LeadInLength;
          buLine buLine = new buLine(start, end);
          buLine.typeDefination = entityTypeDefination.CamLeadin;
          sortGroup.sortEntities[0].Insert(0, (buEntity) buLine);
        }
      }
      if (buFoamCalc.varFoamSettings.LeadOutLength > 0.1)
      {
        clsInit.cVector5.GetEntityEndPointByCamDirection(sortGroup.sortEntities[sortGroup.sortEntities.Count - 1][sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Count - 1], ref pntEnd);
        if (refPlane == FoamPlaneType.XZ)
        {
          Point3D start = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
          Point3D end = new Point3D(pntEnd.X + buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Y, pntEnd.Z);
          if (end.X < sortGroup.MaxPoint.X)
            end.X = sortGroup.MaxPoint.X + buFoamCalc.varFoamSettings.LeadOutLength;
          if (SequenceType == FoamSequenceHor.HorizontalStartThenStartDirect)
            end = new Point3D(pntEnd.X - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Y, pntEnd.Z);
          buLine buLine = new buLine(start, end);
          buLine.typeDefination = entityTypeDefination.CamLeadOut;
          sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add((buEntity) buLine);
        }
        if (refPlane == FoamPlaneType.YZ)
        {
          Point3D start = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
          Point3D end = new Point3D(pntEnd.X, pntEnd.Y + buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Z);
          if (end.Y < sortGroup.MaxPoint.Y)
            end.Y = sortGroup.MaxPoint.Y + buFoamCalc.varFoamSettings.LeadOutLength;
          if (SequenceType == FoamSequenceHor.HorizontalStartThenStartDirect)
            end = new Point3D(pntEnd.X, pntEnd.Y - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Z);
          buLine buLine = new buLine(start, end);
          buLine.typeDefination = entityTypeDefination.CamLeadOut;
          sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add((buEntity) buLine);
        }
      }
    }
    if (sortGroup.Direction != NormalReverse.Reverse || sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Count <= 0)
      return;
    if (buFoamCalc.varFoamSettings.LeadInLength > 0.1)
    {
      clsInit.cVector5.GetEntityStartPointByCamDirection(sortGroup.sortEntities[0][0], ref pntStart);
      if (refPlane == FoamPlaneType.XZ)
      {
        Point3D start = new Point3D(pntStart.X + buFoamCalc.varFoamSettings.LeadInLength, pntStart.Y, pntStart.Z);
        Point3D end = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
        if (start.X < sortGroup.MaxPoint.X)
          start.X = sortGroup.MaxPoint.X + buFoamCalc.varFoamSettings.LeadInLength;
        buLine buLine = new buLine(start, end);
        buLine.typeDefination = entityTypeDefination.CamLeadin;
        sortGroup.sortEntities[0].Insert(0, (buEntity) buLine);
      }
      if (refPlane == FoamPlaneType.YZ)
      {
        Point3D start = new Point3D(pntStart.X, pntStart.Y + buFoamCalc.varFoamSettings.LeadInLength, pntStart.Z);
        Point3D end = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
        if (start.Y < sortGroup.MaxPoint.Y)
          start.Y = sortGroup.MaxPoint.Y + buFoamCalc.varFoamSettings.LeadInLength;
        buLine buLine = new buLine(start, end);
        buLine.typeDefination = entityTypeDefination.CamLeadin;
        sortGroup.sortEntities[0].Insert(0, (buEntity) buLine);
      }
    }
    if (buFoamCalc.varFoamSettings.LeadOutLength <= 0.1)
      return;
    clsInit.cVector5.GetEntityEndPointByCamDirection(sortGroup.sortEntities[sortGroup.sortEntities.Count - 1][sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Count - 1], ref pntEnd);
    if (refPlane == FoamPlaneType.XZ)
    {
      Point3D start = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
      Point3D end = new Point3D(pntEnd.X - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Y, pntEnd.Z);
      if (end.X > sortGroup.MinPoint.X)
        end.X = sortGroup.MinPoint.X - buFoamCalc.varFoamSettings.LeadOutLength;
      buLine buLine = new buLine(start, end);
      buLine.typeDefination = entityTypeDefination.CamLeadOut;
      sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add((buEntity) buLine);
    }
    if (refPlane != FoamPlaneType.YZ)
      return;
    Point3D start1 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
    Point3D end1 = new Point3D(pntEnd.X, pntEnd.Y - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Z);
    if (end1.Y > sortGroup.MinPoint.Y)
      end1.Y = sortGroup.MinPoint.Y - buFoamCalc.varFoamSettings.LeadOutLength;
    buLine buLine1 = new buLine(start1, end1);
    buLine1.typeDefination = entityTypeDefination.CamLeadOut;
    sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add((buEntity) buLine1);
  }

  public void GetPatternSortHorizontal(
    FoamBlock FoamBlock,
    FoamBlock FoamBlockNext,
    FoamPlaneType refPlane,
    ref int Cnt,
    ref List<FoamSortGroup> patternSortEnt)
  {
    List<Point3D> Points = new List<Point3D>();
    FoamSortGroup sortGroup = new FoamSortGroup();
    sortGroup.PlaneType = refPlane;
    if (FoamBlock.Pattern.Count <= 0)
      return;
    int verticalIndex = FoamBlock.Pattern[0].VerticalIndex;
    for (int index1 = 0; index1 <= FoamBlock.Pattern.Count - 1; ++index1)
    {
      if (verticalIndex != FoamBlock.Pattern[index1].VerticalIndex)
      {
        if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd & sortGroup.Direction == NormalReverse.Reverse)
        {
          sortGroup.sortEntities.Reverse();
          sortGroup.Direction = NormalReverse.Reverse;
          for (int index2 = 0; index2 <= sortGroup.sortEntities.Count - 1; ++index2)
          {
            List<buEntity> sortEntity = sortGroup.sortEntities[index2];
            clsInit.cVector5.ChangeEntitiesDirection(ref sortEntity);
            for (int index3 = 0; index3 <= sortGroup.sortEntities[index2].Count - 1; ++index3)
            {
              if (sortGroup.sortEntities[index2][index3].typeDefination == entityTypeDefination.CamLeadin)
                sortGroup.sortEntities[index2][index3].typeDefination = entityTypeDefination.CamLeadOut;
              else if (sortGroup.sortEntities[index2][index3].typeDefination == entityTypeDefination.CamLeadOut)
                sortGroup.sortEntities[index2][index3].typeDefination = entityTypeDefination.CamLeadin;
            }
          }
        }
        clsInit.cVector5.BoxSizeCalculate(Points, ref sortGroup.MinPoint, ref sortGroup.MaxPoint);
        this.AddLeadInLeadOut(ref sortGroup, refPlane, buFoamCalc.varFoamSettings.SequenceHorizontal);
        patternSortEnt.Add(sortGroup);
        sortGroup = new FoamSortGroup();
        sortGroup.PlaneType = refPlane;
        Points.Clear();
        Points = new List<Point3D>();
        ++Cnt;
        List<buEntity> copiedEntities = new List<buEntity>();
        if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd)
        {
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
          sortGroup.Direction = NormalReverse.Reverse;
        }
        else
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
        sortGroup.sortEntities.Add(copiedEntities);
        verticalIndex = FoamBlock.Pattern[index1].VerticalIndex;
      }
      else
      {
        List<buEntity> copiedEntities = new List<buEntity>();
        if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd)
        {
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
          sortGroup.Direction = NormalReverse.Reverse;
        }
        else
        {
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
          sortGroup.Direction = NormalReverse.Normal;
        }
        sortGroup.sortEntities.Add(copiedEntities);
      }
      Points.Add(buVector5.ToPoint3D(FoamBlock.Pattern[index1].BoxMinItem));
      Points.Add(buVector5.ToPoint3D(FoamBlock.Pattern[index1].BoxMaxItem));
    }
    if (sortGroup.sortEntities.Count <= 0)
      return;
    if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd & sortGroup.Direction == NormalReverse.Reverse)
    {
      sortGroup.sortEntities.Reverse();
      for (int index = 0; index <= sortGroup.sortEntities.Count - 1; ++index)
      {
        List<buEntity> sortEntity = sortGroup.sortEntities[index];
        clsInit.cVector5.ChangeEntitiesDirection(ref sortEntity);
      }
      sortGroup.Direction = NormalReverse.Reverse;
    }
    clsInit.cVector5.BoxSizeCalculate(Points, ref sortGroup.MinPoint, ref sortGroup.MaxPoint);
    this.AddLeadInLeadOut(ref sortGroup, refPlane, buFoamCalc.varFoamSettings.SequenceHorizontal);
    patternSortEnt.Add(sortGroup);
    new FoamSortGroup().PlaneType = refPlane;
    ++Cnt;
  }

  public void GetPatternSortVertical(
    FoamBlock FoamBlock,
    FoamBlock FoamBlockNext,
    FoamPlaneType refPlane,
    ref int Cnt,
    ref List<FoamSortGroup> patternSortEnt)
  {
    List<Point3D> Points = new List<Point3D>();
    FoamSortGroup foamSortGroup = new FoamSortGroup();
    foamSortGroup.PlaneType = refPlane;
    if (FoamBlock.Pattern.Count <= 0)
      return;
    int num = FoamBlock.Pattern[0].HorizontalIndex;
    for (int index1 = 0; index1 <= FoamBlock.Pattern.Count - 1; ++index1)
    {
      if (num != FoamBlock.Pattern[index1].HorizontalIndex)
      {
        if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd & foamSortGroup.Direction == NormalReverse.Reverse)
        {
          foamSortGroup.sortEntities.Reverse();
          foamSortGroup.Direction = NormalReverse.Reverse;
          for (int index2 = 0; index2 <= foamSortGroup.sortEntities.Count - 1; ++index2)
          {
            List<buEntity> sortEntity = foamSortGroup.sortEntities[index2];
            clsInit.cVector5.ChangeEntitiesDirection(ref sortEntity);
            for (int index3 = 0; index3 <= foamSortGroup.sortEntities[index2].Count - 1; ++index3)
            {
              if (foamSortGroup.sortEntities[index2][index3].typeDefination == entityTypeDefination.CamLeadin)
                foamSortGroup.sortEntities[index2][index3].typeDefination = entityTypeDefination.CamLeadOut;
              else if (foamSortGroup.sortEntities[index2][index3].typeDefination == entityTypeDefination.CamLeadOut)
                foamSortGroup.sortEntities[index2][index3].typeDefination = entityTypeDefination.CamLeadin;
            }
          }
        }
        clsInit.cVector5.BoxSizeCalculate(Points, ref foamSortGroup.MinPoint, ref foamSortGroup.MaxPoint);
        patternSortEnt.Add(foamSortGroup);
        foamSortGroup = new FoamSortGroup();
        foamSortGroup.PlaneType = refPlane;
        Points.Clear();
        Points = new List<Point3D>();
        ++Cnt;
        List<buEntity> copiedEntities = new List<buEntity>();
        if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd)
        {
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
          foamSortGroup.Direction = NormalReverse.Reverse;
        }
        else
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
        foamSortGroup.sortEntities.Add(copiedEntities);
        num = FoamBlock.Pattern[index1].VerticalIndex;
      }
      else
      {
        List<buEntity> copiedEntities = new List<buEntity>();
        if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd)
        {
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
          foamSortGroup.Direction = NormalReverse.Reverse;
        }
        else
        {
          buEntity.Copy(FoamBlock.Pattern[index1].sortEntities, ref copiedEntities);
          foamSortGroup.Direction = NormalReverse.Normal;
        }
        foamSortGroup.sortEntities.Add(copiedEntities);
      }
      Points.Add(buVector5.ToPoint3D(FoamBlock.Pattern[index1].BoxMinItem));
      Points.Add(buVector5.ToPoint3D(FoamBlock.Pattern[index1].BoxMaxItem));
    }
    if (foamSortGroup.sortEntities.Count <= 0)
      return;
    if (Cnt % 2 == 1 & buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd & foamSortGroup.Direction == NormalReverse.Reverse)
    {
      foamSortGroup.sortEntities.Reverse();
      for (int index = 0; index <= foamSortGroup.sortEntities.Count - 1; ++index)
      {
        List<buEntity> sortEntity = foamSortGroup.sortEntities[index];
        clsInit.cVector5.ChangeEntitiesDirection(ref sortEntity);
      }
      foamSortGroup.Direction = NormalReverse.Reverse;
    }
    clsInit.cVector5.BoxSizeCalculate(Points, ref foamSortGroup.MinPoint, ref foamSortGroup.MaxPoint);
    patternSortEnt.Add(foamSortGroup);
    new FoamSortGroup().PlaneType = refPlane;
    ++Cnt;
  }

  public void ConnectPattertSort(
    List<FoamSortGroup> patternSortEnt,
    FoamPlaneType refPlane,
    ref List<buEntity> sortedEntities)
  {
    Point3D pntStart = new Point3D();
    Point3D pntEnd = new Point3D();
    for (int index1 = 0; index1 <= patternSortEnt.Count - 1; ++index1)
    {
      if (index1 == 0)
      {
        clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[index1].sortEntities[0][0], ref pntStart);
        if (patternSortEnt[index1].Direction == NormalReverse.Normal)
        {
          if (refPlane == FoamPlaneType.XZ && pntStart.X > this.activeFoam.MinPoint.X)
          {
            buLine buLine = new buLine(new Point3D(this.activeFoam.MinPoint.X, pntStart.Y, pntStart.Z), new Point3D(pntStart.X, pntStart.Y, pntStart.Z));
            buLine.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine);
          }
          if (refPlane == FoamPlaneType.YZ && pntStart.Y > this.activeFoam.MinPoint.Y)
          {
            buLine buLine = new buLine(new Point3D(pntStart.X, this.activeFoam.MinPoint.Y, pntStart.Z), new Point3D(pntStart.X, pntStart.Y, pntStart.Z));
            buLine.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine);
          }
        }
      }
      if (index1 > 0)
      {
        if (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd)
        {
          clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
          clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[index1].sortEntities[0][0], ref pntStart);
          if (refPlane == FoamPlaneType.XZ && !buCompare5.EQ(pntEnd.X, pntStart.X))
          {
            if (patternSortEnt[index1].Direction == NormalReverse.Reverse && pntStart.X > pntEnd.X)
            {
              buLine buLine = new buLine(pntEnd, new Point3D(pntStart.X, pntEnd.Y, pntEnd.Z));
              buLine.typeDefination = entityTypeDefination.Connection;
              sortedEntities.Add((buEntity) buLine);
              clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
            }
            if (patternSortEnt[index1].Direction == NormalReverse.Normal && pntEnd.X > pntStart.X)
            {
              buLine buLine = new buLine(pntEnd, new Point3D(pntStart.X, pntEnd.Y, pntEnd.Z));
              buLine.typeDefination = entityTypeDefination.Connection;
              sortedEntities.Add((buEntity) buLine);
              clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
            }
            buLine buLine1 = new buLine(pntEnd, new Point3D(pntEnd.X, pntStart.Y, pntStart.Z));
            buLine1.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine1);
            clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
          }
          if (refPlane == FoamPlaneType.YZ && !buCompare5.EQ(pntEnd.Y, pntStart.Y))
          {
            buLine buLine = new buLine(pntEnd, new Point3D(pntStart.X, pntEnd.Y, pntStart.Z));
            buLine.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine);
            clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
          }
          buLine buLine2 = new buLine(pntEnd, pntStart);
          buLine2.typeDefination = entityTypeDefination.Connection;
          sortedEntities.Add((buEntity) buLine2);
        }
        if (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenStart)
        {
          clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
          clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[index1].sortEntities[0][0], ref pntStart);
          if (refPlane == FoamPlaneType.XZ)
          {
            double z = (patternSortEnt[index1 - 1].MinPoint.Z + patternSortEnt[index1].MaxPoint.Z) / 2.0;
            buLine buLine3 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntEnd.X, pntEnd.Y, z));
            buLine3.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine3);
            buLine buLine4 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, z), new Point3D(pntStart.X, pntStart.Y, z));
            buLine4.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine4);
            buLine buLine5 = new buLine(new Point3D(pntStart.X, pntStart.Y, z), new Point3D(pntStart.X, pntStart.Y, pntStart.Z));
            buLine5.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine5);
          }
          if (refPlane == FoamPlaneType.YZ)
          {
            double z = (patternSortEnt[index1 - 1].MinPoint.Z + patternSortEnt[index1].MaxPoint.Z) / 2.0;
            buLine buLine6 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntEnd.X, pntEnd.Y, z));
            buLine6.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine6);
            buLine buLine7 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, z), new Point3D(pntStart.X, pntStart.Y, z));
            buLine7.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine7);
            buLine buLine8 = new buLine(new Point3D(pntStart.X, pntStart.Y, z), new Point3D(pntStart.X, pntStart.Y, pntStart.Z));
            buLine8.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine8);
          }
        }
        if (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenStartDirect)
        {
          clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
          clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[index1].sortEntities[0][0], ref pntStart);
          if (refPlane == FoamPlaneType.XZ)
          {
            buLine buLine = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntStart.X, pntStart.Y, pntStart.Z));
            buLine.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine);
          }
          if (refPlane == FoamPlaneType.YZ)
          {
            double z = (patternSortEnt[index1 - 1].MinPoint.Z + patternSortEnt[index1].MaxPoint.Z) / 2.0;
            buLine buLine9 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntEnd.X, pntEnd.Y, z));
            buLine9.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine9);
            buLine buLine10 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, z), new Point3D(pntStart.X, pntStart.Y, z));
            buLine10.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine10);
            buLine buLine11 = new buLine(new Point3D(pntStart.X, pntStart.Y, z), new Point3D(pntStart.X, pntStart.Y, pntStart.Z));
            buLine11.typeDefination = entityTypeDefination.Connection;
            sortedEntities.Add((buEntity) buLine11);
          }
        }
      }
      for (int index2 = 0; index2 <= patternSortEnt[index1].sortEntities.Count - 1; ++index2)
      {
        if (index2 > 0)
        {
          clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[index1].sortEntities[index2][0], ref pntStart);
          buLine buLine12 = new buLine(pntEnd, pntStart);
          buLine12.typeDefination = entityTypeDefination.Upper;
          bool flag = false;
          if (patternSortEnt[index1].Direction == NormalReverse.Normal)
          {
            double num = Point3D.Distance(pntEnd, pntStart);
            if (refPlane == FoamPlaneType.XZ)
            {
              if (num > 5.0 & pntStart.X > pntEnd.X)
              {
                sortedEntities.Add((buEntity) buLine12);
                flag = true;
              }
              if (num > 5.0 & pntStart.X < pntEnd.X)
              {
                pntEnd.X = pntStart.X;
                buLine12 = new buLine(pntEnd, pntStart);
                num = Point3D.Distance(pntEnd, pntStart);
                if (num > 1.0)
                {
                  sortedEntities[sortedEntities.Count - 1].EndPoint.X = pntEnd.X;
                  sortedEntities[sortedEntities.Count - 1].Update();
                  sortedEntities.Add((buEntity) buLine12);
                  flag = true;
                }
              }
            }
            if (refPlane == FoamPlaneType.YZ)
            {
              if (num > 5.0 & pntStart.Y > pntEnd.Y)
              {
                sortedEntities.Add((buEntity) buLine12);
                flag = true;
              }
              if (num > 5.0 & pntStart.Y < pntEnd.Y)
              {
                pntEnd.Y = pntStart.Y;
                buLine12 = new buLine(pntEnd, pntStart);
                if (Point3D.Distance(pntEnd, pntStart) > 1.0)
                {
                  sortedEntities[sortedEntities.Count - 1].EndPoint.Y = pntEnd.Y;
                  sortedEntities[sortedEntities.Count - 1].Update();
                  sortedEntities.Add((buEntity) buLine12);
                  flag = true;
                }
              }
            }
          }
          if (patternSortEnt[index1].Direction == NormalReverse.Reverse)
          {
            double num = Point3D.Distance(pntEnd, pntStart);
            if (refPlane == FoamPlaneType.XZ)
            {
              if (num > 5.0 & pntEnd.X > pntStart.X)
              {
                sortedEntities.Add((buEntity) buLine12);
                flag = true;
              }
              if (num > 5.0 & pntEnd.X < pntStart.X)
              {
                pntStart.X = pntEnd.X;
                buLine buLine13 = new buLine(pntEnd, pntStart);
                if (Point3D.Distance(pntEnd, pntStart) > 1.0)
                {
                  sortedEntities[sortedEntities.Count - 1].StartPoint.X = pntStart.X;
                  sortedEntities[sortedEntities.Count - 1].Update();
                  sortedEntities.Add((buEntity) buLine13);
                  flag = true;
                }
              }
            }
          }
          if (!flag)
          {
            if (sortedEntities[sortedEntities.Count - 1].sortDirection == entitySortDirection.Normal)
            {
              if (sortedEntities[sortedEntities.Count - 1] is buLine)
              {
                sortedEntities[sortedEntities.Count - 1].EndPoint = buVector5.ToPoint3D(pntStart);
                sortedEntities[sortedEntities.Count - 1].Update();
              }
            }
            else if (sortedEntities[sortedEntities.Count - 1].sortDirection == entitySortDirection.Reverse && sortedEntities[sortedEntities.Count - 1] is buLine)
            {
              sortedEntities[sortedEntities.Count - 1].StartPoint = buVector5.ToPoint3D(pntStart);
              sortedEntities[sortedEntities.Count - 1].Update();
            }
          }
        }
        List<buEntity> copiedEntities = new List<buEntity>();
        buEntity.Copy(patternSortEnt[index1].sortEntities[index2], ref copiedEntities);
        for (int index3 = 0; index3 <= copiedEntities.Count - 1; ++index3)
          sortedEntities.Add(copiedEntities[index3]);
        clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
      }
      clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
    }
    if (!(buFoamCalc.varFoamSettings.LeaveAlwaysFromStart & sortedEntities.Count > 0))
      return;
    Point3D MinPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(sortedEntities, ref MinPoint, ref MaxPoint);
    clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
    if (refPlane == FoamPlaneType.XZ)
    {
      if (pntEnd.Z > MinPoint.Z)
      {
        double z = MinPoint.Z - buFoamCalc.varFoamSettings.LeadOutLength;
        if (z < 0.0)
          z = 0.0;
        buLine buLine = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntEnd.X, pntEnd.Y, z));
        buLine.typeDefination = entityTypeDefination.CamLeadOut;
        sortedEntities.Add((buEntity) buLine);
      }
      clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
      buLine buLine14 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(-buFoamCalc.varFoamSettings.LeadInLength, pntEnd.Y, pntEnd.Z));
      buLine14.typeDefination = entityTypeDefination.Connection;
      sortedEntities.Add((buEntity) buLine14);
    }
    if (refPlane == FoamPlaneType.YZ)
    {
      if (pntEnd.Z > MinPoint.Z)
      {
        double z = MinPoint.Z - buFoamCalc.varFoamSettings.LeadOutLength;
        if (z < 0.0)
          z = 0.0;
        buLine buLine = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntEnd.X, pntEnd.Y, z));
        buLine.typeDefination = entityTypeDefination.CamLeadOut;
        sortedEntities.Add((buEntity) buLine);
      }
      clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
      buLine buLine15 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntEnd.X, -buFoamCalc.varFoamSettings.LeadInLength, pntEnd.Z));
      buLine15.typeDefination = entityTypeDefination.Connection;
      sortedEntities.Add((buEntity) buLine15);
    }
    if (!buFoamCalc.varFoamSettings.MoveZUpPosition)
      return;
    clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
    buLine buLine16 = new buLine(new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z), new Point3D(pntEnd.X, pntEnd.Y, this.activeFoam.Material.Size.Depth + buFoamCalc.varFoamSettings.LeadOutLength - buFoamCalc.varFoamSettings.LeaveAlwaysZeroZOffsetFromBlockHeight));
    buLine16.typeDefination = entityTypeDefination.Connection;
    sortedEntities.Add((buEntity) buLine16);
  }

  public void cmdSelectAuto()
  {
    this.activeFoam.sortedEntitiesXZ.Clear();
    this.activeFoam.sortedEntitiesYZ.Clear();
    List<FoamSortGroup> patternSortEnt1 = new List<FoamSortGroup>();
    List<FoamSortGroup> patternSortEnt2 = new List<FoamSortGroup>();
    int Cnt1 = 0;
    for (int index = 0; index <= this.activeFoam.BlockXZ.Count - 1; ++index)
    {
      FoamBlock FoamBlockNext = (FoamBlock) null;
      if (index < this.activeFoam.BlockXZ.Count - 1)
        FoamBlockNext = this.activeFoam.BlockXZ[index + 1];
      if (!this.activeFoam.BlockXZ[index].isVertical)
        this.GetPatternSortHorizontal(this.activeFoam.BlockXZ[index], FoamBlockNext, FoamPlaneType.XZ, ref Cnt1, ref patternSortEnt1);
      else
        this.GetPatternSortVertical(this.activeFoam.BlockXZ[index], FoamBlockNext, FoamPlaneType.XZ, ref Cnt1, ref patternSortEnt1);
    }
    int Cnt2 = 0;
    for (int index = 0; index <= this.activeFoam.BlockYZ.Count - 1; ++index)
    {
      FoamBlock FoamBlockNext = (FoamBlock) null;
      if (index < this.activeFoam.BlockYZ.Count - 1)
        FoamBlockNext = this.activeFoam.BlockYZ[index + 1];
      if (!this.activeFoam.BlockYZ[index].isVertical)
        this.GetPatternSortHorizontal(this.activeFoam.BlockYZ[index], FoamBlockNext, FoamPlaneType.YZ, ref Cnt2, ref patternSortEnt2);
      else
        this.GetPatternSortVertical(this.activeFoam.BlockYZ[index], FoamBlockNext, FoamPlaneType.YZ, ref Cnt2, ref patternSortEnt2);
    }
    this.ConnectPattertSort(patternSortEnt1, FoamPlaneType.XZ, ref this.activeFoam.sortedEntitiesXZ);
    this.ConnectPattertSort(patternSortEnt2, FoamPlaneType.YZ, ref this.activeFoam.sortedEntitiesYZ);
    this.JobUpdate(true, "", (DrillItem) null, -1);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
  }

  public void cmdManuelSelection()
  {
    try
    {
      this.activeFoam.isGCodeCreated = false;
      buFoamCalc.varTemps.NotCatchFound = false;
      buFoamCalc.varTemps.pntLastSelected = (Point3D) null;
      this.pnldata.Visible = true;
      this.radiosortFirstDirThenAuto.Checked = true;
      this.sortbuSettings_0.Option.UseCamSelectedProps = true;
      this.sortbuSettings_0.Option.NextGroupRules = SortingNextGroupFindRulesType.AskMe;
      this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.FirstDirectionThenAuto;
      if (buFoamCalc.varFoamRunSettings.SemiAutoSelection)
        this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.First180DegreeTehnFromDrawing;
      this.sortbuResult_0.ResultType = SortingResultType.None;
      buVector5.PointClickData.FoundCount = 0;
      buVector5.PointClickData.SelectedIndex = -1;
      buVector5.PointClickData.isPointOnEntity = false;
      buVector5.PointClickData.CatchPoint = (Point3D) null;
      buVector5.PointClickData.PreCatchPoint = (Point3D) null;
      if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
      {
        int num = 1;
        this.sortbuSettings_0.Option.refPlane = Plane.XZ;
        this.sortRefEntities.Clear();
        for (int index1 = 0; index1 <= this.activeFoam.BlockXZ.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= this.activeFoam.BlockXZ[index1].Pattern.Count - 1; ++index2)
          {
            for (int index3 = 0; index3 <= this.activeFoam.BlockXZ[index1].Pattern[index2].foamEntities.Count - 1; ++index3)
            {
              for (int index4 = 0; index4 <= this.activeFoam.BlockXZ[index1].Pattern[index2].foamEntities[index3].GroupEntity.Outside.Entities.Count - 1; ++index4)
              {
                buEntity checkEntity = buEntity.Copy(this.activeFoam.BlockXZ[index1].Pattern[index2].foamEntities[index3].GroupEntity.Outside.Entities[index4]);
                if (this.sortRefEntities.Count == 0)
                {
                  checkEntity.Info.ID = num.ToString();
                  this.sortRefEntities.Add(checkEntity);
                  ++num;
                }
                else if (!clsInit.cVector5.isEntitySame(this.sortRefEntities, checkEntity))
                {
                  checkEntity.Info.ID = num.ToString();
                  this.sortRefEntities.Add(checkEntity);
                  ++num;
                }
              }
            }
          }
        }
        ccVars.Action = actionTypeBU.foamManuelSelect;
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = false;
        ccVars.planeActive = Plane.XZ;
        ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XZ;
        clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
        clsInit.appCommand.cmdViewFront(false, false);
        if (this.activeFoam.sortedEntitiesXZ.Count > 0)
        {
          clsInit.cVector5.GetEntityEndPointByCamDirection(this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1], ref buVector5.PointClickData.CatchPoint);
          buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
          ccVars.pntBase = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
          ccVars.enableViewportDrawCurrentLine = true;
          buVector5.PointClickData.isPointOnEntity = clsInit.cVector5.isPointTouchStartAndEndPointOfEntities(buVector5.PointClickData.CatchPoint, this.sortRefEntities);
        }
      }
      if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
      {
        this.sortbuSettings_0.Option.refPlane = Plane.YZ;
        this.sortRefEntities.Clear();
        for (int index5 = 0; index5 <= this.activeFoam.BlockYZ.Count - 1; ++index5)
        {
          for (int index6 = 0; index6 <= this.activeFoam.BlockYZ[index5].Pattern.Count - 1; ++index6)
          {
            for (int index7 = 0; index7 <= this.activeFoam.BlockYZ[index5].Pattern[index6].foamEntities.Count - 1; ++index7)
            {
              for (int index8 = 0; index8 <= this.activeFoam.BlockYZ[index5].Pattern[index6].foamEntities[index7].GroupEntity.Outside.Entities.Count - 1; ++index8)
              {
                buEntity checkEntity = buEntity.Copy(this.activeFoam.BlockYZ[index5].Pattern[index6].foamEntities[index7].GroupEntity.Outside.Entities[index8]);
                if (this.sortRefEntities.Count == 0)
                  this.sortRefEntities.Add(checkEntity);
                else if (!clsInit.cVector5.isEntitySame(this.sortRefEntities, checkEntity))
                  this.sortRefEntities.Add(checkEntity);
              }
            }
          }
        }
        ccVars.Action = actionTypeBU.foamManuelSelect;
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = false;
        ccVars.planeActive = Plane.YZ;
        ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.YZ;
        clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
        clsInit.appCommand.cmdViewRight(false, false);
        if (this.activeFoam.sortedEntitiesYZ.Count > 0)
        {
          clsInit.cVector5.GetEntityEndPointByCamDirection(this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1], ref buVector5.PointClickData.CatchPoint);
          buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
          ccVars.pntBase = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
          ccVars.enableViewportDrawCurrentLine = true;
          buVector5.PointClickData.isPointOnEntity = clsInit.cVector5.isPointTouchStartAndEndPointOfEntities(buVector5.PointClickData.CatchPoint, this.sortRefEntities);
        }
      }
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, true, true, true));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdUndoSelection() => this.doUndoSelection();

  public void cmdDeleteSelection()
  {
    if (ccVars.Pages.Count <= 0)
      return;
    this.doDeleteSelection(buFoamCalc.varFoamRunSettings.planeNames);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    this.activeFoam.isGCodeCreated = false;
  }

  public void cmdSaveJob()
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.Filter = "Foam Job File (*.foamjob)|*.foamjob";
    saveFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamJob;
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buFoamCalc.varFoamRunSettings.pathFoamJob = buFile5.GetPath(saveFileDialog.FileName);
    clsInit.appFoamCutting.SaveFoamFile();
    this.SaveFoamJobFile(saveFileDialog.FileName);
  }

  public void cmdOpenJob()
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "Foam Job File (*.foamjob)|*.foamjob";
    openFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamJob;
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buFoamCalc.varFoamRunSettings.pathFoamJob = buFile5.GetPath(openFileDialog.FileName);
    clsInit.appFoamCutting.SaveFoamFile();
    this.OpenFoamJobFile(openFileDialog.FileName);
  }

  public void cmdShowGcode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num1 = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
        buString5.MessageBoxWarning(AppLanguage.Messages[9]);
      else if (this.activeFoam == null)
      {
        buString5.MessageBoxWarning(buFoamCalc.LangFoamMessage[21]);
      }
      else
      {
        this.doCheckLimits();
        if (this.activeFoam.isError)
          return;
        string Lines = "";
        List<camTp> CamList = new List<camTp>();
        PostProcessor P = new PostProcessor(ccVars.PostActive);
        this.CreateGCode(ref CamList, ref P);
        List<string> stringList = new List<string>();
        if (CamList.Count <= 0)
          return;
        for (int index1 = 0; index1 <= CamList.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= CamList[index1].CamPoints.Count - 1; ++index2)
          {
            for (int index3 = 0; index3 <= CamList[index1].CamPoints[index2].Points.Count - 1; ++index3)
            {
              if (CamList[index1].CamPoints[index2].Points[index3].P9.C > buFoamCalc.varFoamSettings.TangentMaxAngle)
                stringList.Add($"{buLangTranslate.preDef.Limit} C = {CamList[index1].CamPoints[index2].Points[index3].P9.C.ToString("f2")}");
              if (CamList[index1].CamPoints[index2].Points[index3].P9.C < buFoamCalc.varFoamSettings.TangentMinAngle)
                stringList.Add($"{buLangTranslate.preDef.Limit} C = {CamList[index1].CamPoints[index2].Points[index3].P9.C.ToString("f2")}");
            }
          }
        }
        if (stringList.Count > 0)
        {
          DialogBoxList dialogBoxList = new DialogBoxList();
          dialogBoxList.Caption = buLangTranslate.preDef.Warning;
          dialogBoxList.Width = 500;
          for (int index = 0; index <= stringList.Count - 1; ++index)
            dialogBoxList.Items.Add(stringList[index]);
          dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
          dialogBoxList.Init();
          int num2 = (int) dialogBoxList.ShowDialog();
        }
        clsInit.cGcodeCreate.CreatGCode(CamList, P, ref Lines);
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

  public void cmdSaveGcode(bool ShowDialog = true)
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num1 = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
        buString5.MessageBoxWarning(AppLanguage.Messages[9]);
      else if (this.activeFoam == null)
      {
        buString5.MessageBoxWarning(buFoamCalc.LangFoamMessage[21]);
      }
      else
      {
        this.doCheckLimits();
        if (this.activeFoam.isError)
          return;
        List<camTp> CamList = new List<camTp>();
        PostProcessor P = new PostProcessor(ccVars.PostActive);
        this.CreateGCode(ref CamList, ref P);
        List<string> stringList = new List<string>();
        if (CamList.Count <= 0)
          return;
        for (int index1 = 0; index1 <= CamList.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= CamList[index1].CamPoints.Count - 1; ++index2)
          {
            for (int index3 = 0; index3 <= CamList[index1].CamPoints[index2].Points.Count - 1; ++index3)
            {
              if (CamList[index1].CamPoints[index2].Points[index3].P9.C > buFoamCalc.varFoamSettings.TangentMaxAngle)
                stringList.Add($"{buLangTranslate.preDef.Limit} C = {CamList[index1].CamPoints[index2].Points[index3].P9.C.ToString("f2")}");
              if (CamList[index1].CamPoints[index2].Points[index3].P9.C < buFoamCalc.varFoamSettings.TangentMinAngle)
                stringList.Add($"{buLangTranslate.preDef.Limit} C = {CamList[index1].CamPoints[index2].Points[index3].P9.C.ToString("f2")}");
            }
          }
        }
        if (stringList.Count > 0)
        {
          DialogBoxList dialogBoxList = new DialogBoxList();
          dialogBoxList.Caption = buLangTranslate.preDef.Warning;
          dialogBoxList.Width = 500;
          for (int index = 0; index <= stringList.Count - 1; ++index)
            dialogBoxList.Items.Add(stringList[index]);
          dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
          dialogBoxList.Init();
          int num2 = (int) dialogBoxList.ShowDialog();
        }
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = $"{P.FileExplanation} ({P.FileExtension})|{P.FileExtension}";
        saveFileDialog.FilterIndex = 1;
        if (ShowDialog)
        {
          if (saveFileDialog.ShowDialog() != DialogResult.OK)
            return;
          clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
          string Lines = "";
          clsInit.cGcodeCreate.CreatGCode(CamList, P, ref Lines);
          buFile5.SaveToFile(Lines, saveFileDialog.FileName);
          clsFiles.SaveParameter();
          if (clsItem.FrmProgress == null)
            return;
          clsItem.FrmProgress.Visible = false;
        }
        else
        {
          string Lines = "";
          clsInit.cGcodeCreate.CreatGCode(CamList, P, ref Lines);
          buFile5.SaveToFile(Lines, AppPath.Base + "\\temp.cnc");
          if (clsItem.FrmProgress == null)
            return;
          clsItem.FrmProgress.Visible = false;
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSimStart()
  {
    this.bool_0 = true;
    if (!this.activeFoam.isGCodeCreated)
    {
      List<camTp> CamList = new List<camTp>();
      PostProcessor P = new PostProcessor(ccVars.PostActive);
      this.CreateGCode(ref CamList, ref P);
    }
    if (this.int_0 == -1)
      this.int_0 = 0;
    if (this.simIndex == -1)
      this.simIndex = 0;
    this.timer_0.Enabled = true;
  }

  public void cmdSimStop()
  {
    if (this.bool_0)
    {
      this.timer_0.Enabled = false;
      this.bool_0 = false;
    }
    else
    {
      this.simIndex = -1;
      this.int_0 = -1;
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
    }
  }

  public void cmdSimFwd() => this.Sim_Tick((object) null, (EventArgs) null);

  public void cmdSimBwd()
  {
    this.simIndex -= buFoamCalc.varFoamRunSettings.SimStep;
    this.simIndex -= buFoamCalc.varFoamRunSettings.SimStep;
    this.Sim_Tick((object) null, (EventArgs) null);
  }

  public void cmdSequence()
  {
    F_FoamSequence fFoamSequence = new F_FoamSequence();
    fFoamSequence.SequenceHor = buFoamCalc.varFoamSettings.SequenceHorizontal;
    fFoamSequence.SequenceVer = buFoamCalc.varFoamSettings.SequenceVertical;
    fFoamSequence.Init();
    int num = (int) fFoamSequence.ShowDialog();
    if (fFoamSequence.PropertiesForm.Result != DialogResult.OK)
      return;
    buFoamCalc.varFoamSettings.SequenceHorizontal = fFoamSequence.SequenceHor;
    buFoamCalc.varFoamSettings.SequenceVertical = fFoamSequence.SequenceVer;
    this.SaveFoamFile();
  }

  public void cmdGetNestedPart()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
        buString5.MessageBoxWarning(AppLanguage.Messages[9]);
      else if (this.activeFoam == null)
        buString5.MessageBoxWarning(buFoamCalc.LangFoamMessage[21]);
      else
        clsInit.appNesting.cmdShowNestedPage();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdPlaneXZ(bool ZoomFit)
  {
    ccVars.planeActive = Plane.XZ;
    ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XZ;
    clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
    clsInit.appCommand.cmdViewFront(false, false);
    if (ZoomFit)
    {
      clsInit.appCommand.cmdViewZoomFit();
      clsInit.appCommand.cmdViewZoomOut();
    }
    buFoamCalc.varFoamRunSettings.planeNames = FoamPlaneType.XZ;
    if (this.activePattern != null)
      this.activePattern.planeName = FoamPlaneType.XZ;
    if (!(ccVars.Action == actionTypeBU.foamWaveSlice | ccVars.Action == actionTypeBU.foamWaveShape | ccVars.Action == actionTypeBU.foamWavePattern))
      return;
    this.BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
  }

  public void cmdPlaneYZ(bool ZoomFit)
  {
    ccVars.planeActive = Plane.YZ;
    ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.YZ;
    clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
    clsInit.appCommand.cmdViewRight(false, false);
    if (ZoomFit)
    {
      clsInit.appCommand.cmdViewZoomFit();
      clsInit.appCommand.cmdViewZoomOut();
    }
    buFoamCalc.varFoamRunSettings.planeNames = FoamPlaneType.YZ;
    if (this.activePattern != null)
      this.activePattern.planeName = FoamPlaneType.YZ;
    if (!(ccVars.Action == actionTypeBU.foamWaveSlice | ccVars.Action == actionTypeBU.foamWaveShape | ccVars.Action == actionTypeBU.foamWavePattern))
      return;
    this.BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
  }

  public void cmdShowSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = "Settings";
      classViewerDialog.Value = (object) buFoamCalc.varFoamSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      buFoamCalc.varFoamSettings = new FoamSettings((FoamSettings) classViewerDialog.Value);
      buFoamCalc.UnitLength = buFoamCalc.varFoamSettings.UnitLength;
      buFoamCalc.UnitsSpeed = buFoamCalc.varFoamSettings.UnitSpeed;
      this.SaveFoamFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdCodeConverter()
  {
    try
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "G Codes (*.nc,*cnc)|*.nc;*.cnc";
      openFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathConverter;
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      F_FoamGCodeConverter foamGcodeConverter = new F_FoamGCodeConverter();
      foamGcodeConverter.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      foamGcodeConverter.Converter = new GCodeConverter(buFoamCalc.varFoamGCodeConverter);
      foamGcodeConverter.Init();
      int num = (int) foamGcodeConverter.ShowDialog();
      if (foamGcodeConverter.PropertiesForm.Result != DialogResult.OK)
        return;
      buFoamCalc.varFoamGCodeConverter = new GCodeConverter(foamGcodeConverter.Converter);
      buFoamCalc.varFoamRunSettings.pathConverter = buFile5.GetPath(openFileDialog.FileName);
      clsInit.appFoamCutting.SaveFoamFile();
      this.CodeConverter(openFileDialog.FileName, buFoamCalc.varFoamGCodeConverter);
    }
    catch (Exception ex)
    {
    }
  }

  public void radio_CheckedChanged(object sender, EventArgs e)
  {
    if (this.radiosortCCW.Checked)
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.CCW;
    else if (this.radiosortCW.Checked)
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.CW;
    else if (this.radiosortFirstDirThenAuto.Checked)
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.FirstDirectionThenAuto;
    else if (this.radiosortHigherIndex.Checked)
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.HigherIndex;
    else if (this.radiosortJump.Checked)
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.Jump;
    else if (this.radiosortLowerIndex.Checked)
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.LowerIndex;
    else if (this.radiosortNone.Checked)
    {
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.None;
    }
    else
    {
      if (!this.radiosortmanuel.Checked)
        return;
      this.sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.Manuel;
    }
  }

  public void New_Tick(object sender, EventArgs e)
  {
    this.timer_1.Enabled = false;
    this.cmdNewMaterial(new FoamItem()
    {
      Material = {
        Size = new SizeObject(buFoamCalc.varFoamRunSettings.MaterialWidth, buFoamCalc.varFoamRunSettings.MaterialHeight, buFoamCalc.varFoamRunSettings.MaterialDepth)
      }
    }, true);
    clsInit.appCommand.cmdViewZoomFit();
    clsInit.appCommand.cmdViewZoomOut();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
    {
      if (index == 0)
        buFoamCalc.varTemps.LayerGeneral = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name;
      if (index == 1)
        buFoamCalc.varTemps.LayerFoam = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name;
      if (index == 2)
        buFoamCalc.varTemps.Layer3DPattern = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name;
      if (index == 3)
        buFoamCalc.varTemps.LayerWirePattern = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name;
      if (index == 4)
        buFoamCalc.varTemps.LayerSelection = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name;
      if (index == 5)
        buFoamCalc.varTemps.LayerMark = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name;
    }
    GC.Collect();
  }

  public void Sim_Tick(object sender, EventArgs e)
  {
    if (this.int_0 == 0)
    {
      if (this.activeFoam.CamXZ.SimilationPoint.SimMove.Count > 0)
      {
        if (this.simIndex >= 0 & this.simIndex <= this.activeFoam.CamXZ.SimilationPoint.SimMove.Count - 1)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0)
          {
            Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1];
            if (entity1.EntityData != null & entity1.EntityData is CustomData && (entity1.EntityData as CustomData).typeDefination == entityTypeDefination.Tool)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
            Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1];
            if (entity2.EntityData != null & entity2.EntityData is CustomData && (entity2.EntityData as CustomData).typeDefination == entityTypeDefination.Tool)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
            Pnt6DSimMove pnt6DsimMove = this.activeFoam.CamXZ.SimilationPoint.SimMove[this.simIndex];
            LinearPath outer = new LinearPath((ICollection<Point3D>) new List<Point3D>()
            {
              new Point3D(pnt6DsimMove.X, 0.0, pnt6DsimMove.Y),
              new Point3D(pnt6DsimMove.X + 80.0, 0.0, pnt6DsimMove.Y + 20.0),
              new Point3D(pnt6DsimMove.X + 80.0, 0.0, pnt6DsimMove.Y - 20.0),
              new Point3D(pnt6DsimMove.X, 0.0, pnt6DsimMove.Y)
            });
            outer.Rotate(buConversion5.DegreeToRadian(-pnt6DsimMove.C + 180.0), Vector3D.AxisY, new Point3D(pnt6DsimMove.X, 0.0, pnt6DsimMove.Y));
            Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) outer, Plane.XZ, true).ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);
            mesh.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.Tool
            };
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh);
            Text text = new Text(Plane.XZ, new Point3D(pnt6DsimMove.X, pnt6DsimMove.Z - 6.0, pnt6DsimMove.Y), pnt6DsimMove.C.ToString("f1"), 20.0);
            text.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.Tool
            };
            text.Color = Color.Red;
            text.ColorMethod = colorMethodType.byEntity;
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) text);
            this.simIndex += buFoamCalc.varFoamRunSettings.SimStep;
          }
        }
        else
        {
          this.simIndex = 0;
          this.int_0 = 1;
        }
      }
      else
      {
        this.simIndex = 0;
        this.int_0 = 1;
      }
    }
    else if (this.int_0 == 1)
    {
      if (this.activeFoam.CamYZ.SimilationPoint.SimMove.Count > 0)
      {
        if (this.simIndex >= 0 & this.simIndex <= this.activeFoam.CamYZ.SimilationPoint.SimMove.Count - 1)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0)
          {
            Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1];
            if (entity.EntityData != null & entity.EntityData is CustomData && (entity.EntityData as CustomData).typeDefination == entityTypeDefination.Tool)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
            Pnt6DSimMove pnt6DsimMove = this.activeFoam.CamYZ.SimilationPoint.SimMove[this.simIndex];
            LinearPath outer = new LinearPath((ICollection<Point3D>) new List<Point3D>()
            {
              new Point3D(this.activeFoam.Material.Size.Width + 1.0, pnt6DsimMove.X, pnt6DsimMove.Y),
              new Point3D(this.activeFoam.Material.Size.Width + 1.0, pnt6DsimMove.X + 80.0, pnt6DsimMove.Y + 20.0),
              new Point3D(this.activeFoam.Material.Size.Width + 1.0, pnt6DsimMove.X + 80.0, pnt6DsimMove.Y - 20.0),
              new Point3D(this.activeFoam.Material.Size.Width + 1.0, pnt6DsimMove.X, pnt6DsimMove.Y)
            });
            outer.Rotate(buConversion5.DegreeToRadian(pnt6DsimMove.C + 180.0), Vector3D.AxisX, new Point3D(this.activeFoam.Material.Size.Width, pnt6DsimMove.X, pnt6DsimMove.Y));
            devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) outer, Plane.YZ, true);
            region.Translate(this.activeFoam.Material.Size.Width, 0.0);
            Mesh mesh = region.ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);
            mesh.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.Tool
            };
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh);
            this.simIndex += buFoamCalc.varFoamRunSettings.SimStep;
          }
        }
        else
        {
          this.simIndex = -1;
          this.int_0 = -1;
          this.timer_0.Enabled = false;
          this.bool_0 = false;
          this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
        }
      }
      else
      {
        this.simIndex = -1;
        this.int_0 = -1;
        this.timer_0.Enabled = false;
        this.bool_0 = false;
        this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void SaveFoamJobFile(string FileName)
  {
    ArrayList arrayList = new ArrayList();
    buFile5.SaveToFile(FoamItem.ToDef(this.activeFoam, 2), FileName);
  }

  public void OpenFoamJobFile(string FileName)
  {
    ArrayList StringList = new ArrayList();
    buFile5.OpenFromFile(FileName, ref StringList);
    if (StringList.Count <= 0)
      return;
    FoamItem data = new FoamItem();
    FoamItem.Decode(StringList, ref data);
    if (!(data.BlockXZ.Count > 0 | data.BlockYZ.Count > 0))
      return;
    this.activeFoam = new FoamItem(data);
    if (buFoamCalc.varFoamSettings.Draw3D)
    {
      for (int index1 = 0; index1 <= this.activeFoam.BlockXZ.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= this.activeFoam.BlockXZ[index1].Pattern.Count - 1; ++index2)
        {
          List<buEntity> buEntityList = new List<buEntity>();
          for (int index3 = 0; index3 <= this.activeFoam.BlockXZ[index1].Pattern[index2].foamEntities.Count - 1; ++index3)
          {
            for (int index4 = 0; index4 <= this.activeFoam.BlockXZ[index1].Pattern[index2].foamEntities[index3].GroupEntity.Outside.Entities.Count - 1; ++index4)
              buEntityList.Add(buEntity.Copy(this.activeFoam.BlockXZ[index1].Pattern[index2].foamEntities[index3].GroupEntity.Outside.Entities[index4]));
          }
          FoamPattern Pattern = this.activeFoam.BlockXZ[index1].Pattern[index2];
          clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
        }
      }
    }
    this.JobUpdate(true, "", (DrillItem) null, -1);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, true, true));
    if (data.BlockXZ.Count > 0)
    {
      this.cmdPlaneXZ(true);
    }
    else
    {
      if (data.BlockYZ.Count <= 0)
        return;
      this.cmdPlaneYZ(true);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buFoam.lng") : new FileInfo(AppPath.Language + "\\buFoam.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamCommands);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Foam Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Foam Language File Missing");
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

  public void SaveFoamFile()
  {
    try
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Settings + "\\Foam");
      if (!directoryInfo.Exists)
      {
        directoryInfo = new DirectoryInfo(AppPath.MachineSettings + "\\Foam");
        if (!directoryInfo.Exists)
        {
          directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Foam");
          if (!directoryInfo.Exists)
          {
            buString5.MessageBoxWarning("Settins Path Not Available");
            return;
          }
        }
      }
      string FileName = directoryInfo.FullName + "\\Foam.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Foam Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "<buFoamCuttingCalc.varFoamSettings>");
      StringList1.AddRange((ICollection) buFoamCalc.varFoamSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buFoamCuttingCalc.varFoamSettings>");
      StringList1.Add((object) "<buFoamCuttingCalc.varFoamRunSettings>");
      StringList1.AddRange((ICollection) buFoamCalc.varFoamRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buFoamCuttingCalc.varFoamRunSettings>");
      StringList1.Add((object) "<buFoamCuttingCalc.varFoamEditorSettings>");
      StringList1.AddRange((ICollection) buFoamCalc.varFoamEditorSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buFoamCuttingCalc.varFoamEditorSettings>");
      StringList1.Add((object) "<buFoamCuttingCalc.varFoamGCodeConverter>");
      StringList1.AddRange((ICollection) buFoamCalc.varFoamGCodeConverter.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buFoamCuttingCalc.varFoamGCodeConverter>");
      buFile.SaveToFile(StringList1, FileName);
      buLog.addLog("Foam Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "Radius Feed Table");
      StringList2.Add((object) "MinRadius ; MaxRadius ; Feed");
      StringList2.Add((object) "<RadiusFeed>");
      for (int index = 0; index <= buFoamCalc.RadiusFeedList.Count - 1; ++index)
        StringList2.Add((object) $"{buFoamCalc.RadiusFeedList[index].MinRadius.ToString()} ; {buFoamCalc.RadiusFeedList[index].MaxRadius.ToString()} ; {buFoamCalc.RadiusFeedList[index].Feed.ToString()}");
      StringList2.Add((object) "</RadiusFeed>");
      StringList2.Add((object) " ");
      StringList2.Add((object) "---------------- ");
      StringList2.Add((object) " ");
      StringList2.Add((object) "Length Feed Table");
      StringList2.Add((object) "MinLength; MaxLength; Feed");
      StringList2.Add((object) "<LengthFeed>");
      for (int index = 0; index <= buFoamCalc.LengthFeedList.Count - 1; ++index)
        StringList2.Add((object) $"{buFoamCalc.LengthFeedList[index].MinLength.ToString()} ; {buFoamCalc.LengthFeedList[index].MaxLength.ToString()} ; {buFoamCalc.LengthFeedList[index].Feed.ToString()}");
      StringList2.Add((object) "</LengthFeed>");
      buFile5.SaveToFile(StringList2, directoryInfo.FullName + "\\SpeedsList.prm");
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenFoamFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Settings + "\\Foam");
      if (!directoryInfo.Exists)
      {
        directoryInfo = new DirectoryInfo(AppPath.MachineSettings + "\\Foam");
        if (!directoryInfo.Exists)
        {
          directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Foam");
          if (!directoryInfo.Exists)
          {
            buString5.MessageBoxWarning("Settins Path Not Available");
            return;
          }
        }
      }
      FileInfo fileInfo1 = new FileInfo(directoryInfo.FullName + "\\Foam.prm");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList1 = new ArrayList();
          buString.ListToSpecificList("<buFoamCuttingCalc.varFoamSettings>", "</buFoamCuttingCalc.varFoamSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buFoamCalc.varFoamSettings);
            buLog.addLog("Foam varFoamSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          ArrayList CalcList2 = new ArrayList();
          buString.ListToSpecificList("<buFoamCuttingCalc.varFoamRunSettings>", "</buFoamCuttingCalc.varFoamRunSettings>", true, StringList, ref CalcList2);
          if (CalcList2.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buFoamCalc.varFoamRunSettings);
            buLog.addLog("Foam varFoamRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          ArrayList CalcList3 = new ArrayList();
          buString.ListToSpecificList("<buFoamCuttingCalc.varFoamEditorSettings>", "</buFoamCuttingCalc.varFoamEditorSettings>", true, StringList, ref CalcList3);
          if (CalcList3.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buFoamCalc.varFoamEditorSettings);
            buLog.addLog("Foam varFoamEditorSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          ArrayList CalcList4 = new ArrayList();
          buString.ListToSpecificList("<buFoamCuttingCalc.varFoamGCodeConverter>", "</buFoamCuttingCalc.varFoamGCodeConverter>", true, StringList, ref CalcList4);
          if (CalcList4.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buFoamCalc.varFoamGCodeConverter);
            buLog.addLog("Foam varFoamGCodeConverter Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Foam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Drill Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Foam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Drill Settings File Missing");
      }
      buLog.addLog("Foam Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(directoryInfo.FullName + "\\SpeedsList.prm");
      if (fileInfo2.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile5.OpenFromFile(fileInfo2.FullName, ref StringList);
        if (StringList.Count > 0)
        {
          ArrayList CalcList5 = new ArrayList();
          buString.ListToSpecificList("<RadiusFeed>", "</RadiusFeed>", false, StringList, ref CalcList5);
          if (CalcList5.Count > 0)
          {
            buFoamCalc.RadiusFeedList.Clear();
            for (int index = 0; index <= CalcList5.Count - 1; ++index)
            {
              string[] strArray = CalcList5[index].ToString().Split(';');
              if ((strArray == null ? 0 : (strArray.Length == 3 ? 1 : 0)) != 0)
              {
                camRadiusFeed camRadiusFeed = new camRadiusFeed();
                double.TryParse(strArray[0], out camRadiusFeed.MinRadius);
                double.TryParse(strArray[1], out camRadiusFeed.MaxRadius);
                double.TryParse(strArray[2], out camRadiusFeed.Feed);
                buFoamCalc.RadiusFeedList.Add(camRadiusFeed);
              }
            }
          }
          ArrayList CalcList6 = new ArrayList();
          buString.ListToSpecificList("<LengthFeed>", "</LengthFeed>", false, StringList, ref CalcList6);
          if (CalcList6.Count > 0)
          {
            buFoamCalc.LengthFeedList.Clear();
            for (int index = 0; index <= CalcList6.Count - 1; ++index)
            {
              string[] strArray = CalcList6[index].ToString().Split(';');
              if ((strArray == null ? 0 : (strArray.Length == 3 ? 1 : 0)) != 0)
              {
                camLengthFeed camLengthFeed = new camLengthFeed();
                double.TryParse(strArray[0], out camLengthFeed.MinLength);
                double.TryParse(strArray[1], out camLengthFeed.MaxLength);
                double.TryParse(strArray[2], out camLengthFeed.Feed);
                buFoamCalc.LengthFeedList.Add(camLengthFeed);
              }
            }
          }
        }
      }
      buFoamCalc.UnitLength = buFoamCalc.varFoamSettings.UnitLength;
      buFoamCalc.UnitsSpeed = buFoamCalc.varFoamSettings.UnitSpeed;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenFoamPatternFile(object FileName, object Data)
  {
    if (FileName == null)
      return;
    FileInfo fileInfo = new FileInfo(FileName.ToString());
    if (!fileInfo.Exists)
      return;
    List<Entity> EyeEntities = new List<Entity>();
    List<buEntity> SortedEntities = new List<buEntity>();
    clsInit.appEditor.OpenSortedEntities(fileInfo.FullName, ref EyeEntities, ref SortedEntities);
    clsItem.FrmFromFile.viewport.Entities.Clear();
    for (int index = 0; index <= EyeEntities.Count - 1; ++index)
    {
      EyeEntities[index].LayerName = "Default";
      clsItem.FrmFromFile.viewport.Entities.Add(EyeEntities[index]);
    }
    clsItem.FrmFromFile.viewport.SetView(viewType.Top);
    clsItem.FrmFromFile.viewport.ZoomFit(10);
    clsItem.FrmFromFile.viewport.Invalidate();
  }

  public void CodeConverter(string FileName, GCodeConverter Converter)
  {
    List<string> StringList = new List<string>();
    List<string> stringList = new List<string>();
    if (Converter.FilterLength > 0.0)
    {
      buFile5.GCodeRead gcodeRead = new buFile5.GCodeRead();
      List<GCodePoint5> GCodeList = new List<GCodePoint5>();
      gcodeRead.Settings.FilterLength = Converter.FilterLength;
      gcodeRead.DecodeAxes.A = false;
      gcodeRead.DecodeAxes.B = false;
      gcodeRead.DecodeAxes.C = false;
      gcodeRead.OpenGCode(FileName, ref GCodeList);
      for (int index = 0; index <= GCodeList.Count - 1; ++index)
      {
        if (GCodeList[index].isGCode)
        {
          string str = $"G{GCodeList[index].CodeType.ToString()} X{GCodeList[index].Positions.X.ToString("f3")} Y{GCodeList[index].Positions.Y.ToString("f3")} Z{GCodeList[index].Positions.Z.ToString("f3")}";
          if (GCodeList[index].CodeType == 1 | GCodeList[index].CodeType == 2 | GCodeList[index].CodeType == 3)
            str = $"{str} F{GCodeList[index].Feed.ToString()}";
          StringList.Add(str);
        }
      }
      buString5.MessageBoxInfo($"{buLangTranslate.preDef.Count} {gcodeRead.Result.OriginalGCodeLineCount.ToString()} - {gcodeRead.Result.ConvertedGCodeLineCount.ToString()}");
    }
    else
      buFile5.OpenFromFile(FileName, ref StringList);
    if (StringList.Count > 0)
    {
      int num1 = 100;
      stringList.Add("<Info>");
      stringList.Add("0;0;0");
      stringList.Add("</Info>");
      stringList.Add("<GCodesMain>");
      stringList.Add("N20 G90");
      stringList.Add("N30 G75");
      stringList.Add("N40 G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      stringList.Add("N50 G75");
      stringList.Add("N60 M154");
      stringList.Add("N70 G75");
      stringList.Add("N80 G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
      stringList.Add("N90 G75");
      string str1 = "";
      string str2 = "";
      string str3 = "";
      for (int index = 0; index <= StringList.Count - 1; ++index)
      {
        string str4 = "";
        string str5 = "";
        string str6 = "";
        if (StringList[index].IndexOf("G0 ") >= 0 | StringList[index].IndexOf("G00 ") >= 0)
        {
          string str7 = "G0";
          if (StringList[index].IndexOf("X") >= 0)
          {
            double num2 = 0.0;
            buString5.ReadCharValue(StringList[index], "X", ref num2);
            str7 = $"{str7} X{((num2 + Converter.XOffset) * Converter.XMultiply).ToString("f3")}";
            str4 = num2.ToString("f3");
          }
          if (StringList[index].IndexOf("Y") >= 0)
          {
            double num3 = 0.0;
            buString5.ReadCharValue(StringList[index], "Y", ref num3);
            str7 = $"{str7} Y{((num3 + Converter.YOffset) * Converter.YMultiply).ToString("f3")}";
            str5 = num3.ToString("f3");
          }
          if (StringList[index].IndexOf("Z") >= 0)
          {
            double num4 = 0.0;
            buString5.ReadCharValue(StringList[index], "Z", ref num4);
            str7 = $"{str7} C{((num4 + Converter.ZOffset) * Converter.ZMultiply).ToString("f3")}";
            str6 = num4.ToString("f3");
          }
          if (str7.Length > 2 && str4 != str1 | str5 != str2 | str6 != str3)
          {
            stringList.Add($"N{num1.ToString()} {str7}");
            str1 = str4;
            str2 = str5;
            str3 = str6;
            num1 += 10;
          }
        }
        if (StringList[index].IndexOf("G1 ") >= 0 | StringList[index].IndexOf("G01 ") >= 0)
        {
          string str8 = "G1";
          if (StringList[index].IndexOf("X") >= 0)
          {
            double num5 = 0.0;
            buString5.ReadCharValue(StringList[index], "X", ref num5);
            str8 = $"{str8} X{((num5 + Converter.XOffset) * Converter.XMultiply).ToString("f3")}";
            str4 = num5.ToString("f3");
          }
          if (StringList[index].IndexOf("Y") >= 0)
          {
            double num6 = 0.0;
            buString5.ReadCharValue(StringList[index], "Y", ref num6);
            str8 = $"{str8} Y{((num6 + Converter.YOffset) * Converter.YMultiply).ToString("f3")}";
            str5 = num6.ToString("f3");
          }
          if (StringList[index].IndexOf("Z") >= 0)
          {
            double num7 = 0.0;
            buString5.ReadCharValue(StringList[index], "Z", ref num7);
            str8 = $"{str8} C{((num7 + Converter.ZOffset) * Converter.ZMultiply).ToString("f3")}";
            str6 = num7.ToString("f3");
          }
          if (StringList[index].IndexOf("F") >= 0)
          {
            double num8 = 0.0;
            buString5.ReadCharValue(StringList[index], "F", ref num8);
            str8 = $"{str8} F{((num8 + Converter.FOffset) * Converter.FMultiply).ToString("f1")}";
          }
          if (str8.Length > 2 && str4 != str1 | str5 != str2 | str6 != str3)
          {
            stringList.Add($"N{num1.ToString()} {str8}");
            str1 = str4;
            str2 = str5;
            str3 = str6;
            num1 += 10;
          }
        }
      }
      stringList.Add($"N{num1.ToString()} M30");
      int num9 = num1 + 10;
      stringList.Add($"N{num9.ToString()} M2");
      stringList.Add("</GCodesMain>");
    }
    if (stringList.Count <= 0)
      return;
    string withoutExtension = buFile5.getFileNameWithoutExtension(FileName);
    string FileName1 = $"{buFile5.GetPath(FileName)}\\{withoutExtension}_Conv.cnc";
    buFile5.SaveToFile(stringList, FileName1);
    buString5.StringListToString(stringList);
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
    TreeNodeSettings selectedNode = (TreeNodeSettings) ((TreeView) sender).SelectedNode;
    string command = selectedNode.Command;
    switch (Class5.smethod_167(command))
    {
      case 697773883:
        if (!(command == "patternXZ") || selectedNode.ClassIndex < 0)
          break;
        this.foamActiveBlock_0.PatternIndex = selectedNode.ClassSubSubSubIndex;
        this.foamActiveBlock_0.BlockIndex = selectedNode.ClassSubSubIndex;
        this.foamActiveBlock_0.Plane = (FoamPlaneType) selectedNode.Tag;
        break;
      case 701609025:
        if (!(command == "blocksXZ") || selectedNode.ClassIndex < 0)
          break;
        this.foamActiveBlock_0.PatternIndex = -1;
        this.foamActiveBlock_0.BlockIndex = selectedNode.ClassSubSubIndex;
        this.foamActiveBlock_0.Plane = (FoamPlaneType) selectedNode.Tag;
        break;
      case 1077441436:
        if (!(command == "foam") || selectedNode.ClassIndex < 0)
          break;
        this.foamActiveBlock_0.PatternIndex = -1;
        this.foamActiveBlock_0.BlockIndex = -1;
        break;
      case 1457186172:
        if (!(command == "blockXZ") || selectedNode.ClassIndex < 0)
          break;
        this.foamActiveBlock_0.PatternIndex = -1;
        this.foamActiveBlock_0.BlockIndex = -1;
        this.foamActiveBlock_0.Plane = (FoamPlaneType) selectedNode.Tag;
        break;
      case 1875792092:
        if (!(command == "blocksYZ") || selectedNode.ClassIndex < 0)
          break;
        this.foamActiveBlock_0.PatternIndex = -1;
        this.foamActiveBlock_0.BlockIndex = selectedNode.ClassSubSubIndex;
        this.foamActiveBlock_0.Plane = (FoamPlaneType) selectedNode.Tag;
        break;
      case 2430435169:
        if (!(command == "blockYZ") || selectedNode.ClassIndex < 0)
          break;
        this.foamActiveBlock_0.PatternIndex = -1;
        this.foamActiveBlock_0.BlockIndex = -1;
        this.foamActiveBlock_0.Plane = (FoamPlaneType) selectedNode.Tag;
        break;
      case 3885271230:
        if (!(command == "patternYZ") || selectedNode.ClassIndex < 0)
          break;
        this.foamActiveBlock_0.PatternIndex = selectedNode.ClassSubSubSubIndex;
        this.foamActiveBlock_0.BlockIndex = selectedNode.ClassSubSubIndex;
        this.foamActiveBlock_0.Plane = (FoamPlaneType) selectedNode.Tag;
        break;
    }
  }

  public void JobUpdate(bool FillPages, string Command, DrillItem Item, int indexItem)
  {
    try
    {
      if (clsItem.FrmFoamJob == null)
        return;
      string str1 = AppLanguage.CadCamDynamic[114];
      string str2 = AppLanguage.CadCamDynamic[108];
      string str3 = AppLanguage.CadCamDynamic[107] + " - ";
      string str4 = AppLanguage.CadCamDynamic[106];
      string str5 = AppLanguage.CadCamDynamic[112 /*0x70*/];
      if (!FillPages)
        return;
      this.treejobs.Nodes.Clear();
      TreeNodeSettings treeNodeSettings1 = new TreeNodeSettings(clsInit.cFoamCut.JobItemName(this.activeFoam));
      treeNodeSettings1.ImageIndex = 0;
      treeNodeSettings1.SelectedImageIndex = 0;
      treeNodeSettings1.Tag = (object) "0";
      treeNodeSettings1.ClassIndex = 0;
      treeNodeSettings1.ClassSubIndex = -1;
      treeNodeSettings1.ClassSubSubIndex = -1;
      treeNodeSettings1.Command = "foam";
      treeNodeSettings1.Info = "";
      treeNodeSettings1.Checked = true;
      TreeNodeSettings node1 = treeNodeSettings1;
      TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings("Main");
      treeNodeSettings2.ImageIndex = 2;
      treeNodeSettings2.SelectedImageIndex = 2;
      treeNodeSettings2.Tag = (object) FoamPlaneType.XZ;
      treeNodeSettings2.ClassIndex = 0;
      treeNodeSettings2.ClassSubIndex = 0;
      treeNodeSettings2.ClassSubSubIndex = -1;
      treeNodeSettings2.Command = "blockXZ";
      treeNodeSettings2.Info = "XZ";
      treeNodeSettings2.Checked = true;
      TreeNodeSettings node2 = treeNodeSettings2;
      TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings("Side");
      treeNodeSettings3.ImageIndex = 3;
      treeNodeSettings3.SelectedImageIndex = 3;
      treeNodeSettings3.Tag = (object) FoamPlaneType.YZ;
      treeNodeSettings3.ClassIndex = 0;
      treeNodeSettings3.ClassSubIndex = 1;
      treeNodeSettings3.ClassSubSubIndex = -1;
      treeNodeSettings3.Command = "blockYZ";
      treeNodeSettings3.Info = "YZ";
      treeNodeSettings3.Checked = true;
      TreeNodeSettings node3 = treeNodeSettings3;
      node1.Nodes.Add((TreeNode) node2);
      node1.Nodes.Add((TreeNode) node3);
      int num;
      for (int index1 = 0; index1 <= this.activeFoam.BlockXZ.Count - 1; ++index1)
      {
        TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings(clsInit.cFoamCut.JobBlockName(this.activeFoam.BlockXZ[index1]));
        treeNodeSettings4.ImageIndex = 1;
        treeNodeSettings4.SelectedImageIndex = 1;
        treeNodeSettings4.Tag = (object) FoamPlaneType.XZ;
        treeNodeSettings4.ClassIndex = 0;
        treeNodeSettings4.ClassSubIndex = 0;
        treeNodeSettings4.ClassSubSubIndex = index1;
        treeNodeSettings4.Command = "blocksXZ";
        treeNodeSettings4.Info = "XZ";
        treeNodeSettings4.Checked = true;
        TreeNodeSettings node4 = treeNodeSettings4;
        node2.Nodes.Add((TreeNode) node4);
        for (int index2 = 0; index2 <= this.activeFoam.BlockXZ[index1].Pattern.Count - 1; ++index2)
        {
          num = index2 + 1;
          string NodeText = $"{num.ToString()} - {clsInit.cFoamCut.JobPatternName(this.activeFoam.BlockXZ[index1].Pattern[index2])}";
          clsInit.cFoamCut.JobPatternImageIndex(this.activeFoam.BlockXZ[index1].Pattern[index2]);
          TreeNodeSettings treeNodeSettings5 = new TreeNodeSettings(NodeText);
          treeNodeSettings5.ImageIndex = 4;
          treeNodeSettings5.SelectedImageIndex = 4;
          treeNodeSettings5.Tag = (object) FoamPlaneType.XZ;
          treeNodeSettings5.ClassIndex = 0;
          treeNodeSettings5.ClassSubIndex = 0;
          treeNodeSettings5.ClassSubSubIndex = index1;
          treeNodeSettings5.ClassSubSubSubIndex = index2;
          treeNodeSettings5.Command = "patternXZ";
          treeNodeSettings5.Info = "XZ";
          treeNodeSettings5.Checked = true;
          TreeNodeSettings node5 = treeNodeSettings5;
          node4.Nodes.Add((TreeNode) node5);
        }
      }
      for (int index3 = 0; index3 <= this.activeFoam.BlockYZ.Count - 1; ++index3)
      {
        TreeNodeSettings treeNodeSettings6 = new TreeNodeSettings(clsInit.cFoamCut.JobBlockName(this.activeFoam.BlockYZ[index3]));
        treeNodeSettings6.ImageIndex = 1;
        treeNodeSettings6.SelectedImageIndex = 1;
        treeNodeSettings6.Tag = (object) FoamPlaneType.YZ;
        treeNodeSettings6.ClassIndex = 0;
        treeNodeSettings6.ClassSubIndex = 0;
        treeNodeSettings6.ClassSubSubIndex = index3;
        treeNodeSettings6.Command = "blocksYZ";
        treeNodeSettings6.Info = "YZ";
        treeNodeSettings6.Checked = true;
        TreeNodeSettings node6 = treeNodeSettings6;
        node3.Nodes.Add((TreeNode) node6);
        for (int index4 = 0; index4 <= this.activeFoam.BlockYZ[index3].Pattern.Count - 1; ++index4)
        {
          num = index4 + 1;
          string NodeText = $"{num.ToString()} - {clsInit.cFoamCut.JobPatternName(this.activeFoam.BlockYZ[index3].Pattern[index4])}";
          clsInit.cFoamCut.JobPatternImageIndex(this.activeFoam.BlockYZ[index3].Pattern[index4]);
          TreeNodeSettings treeNodeSettings7 = new TreeNodeSettings(NodeText);
          treeNodeSettings7.ImageIndex = 4;
          treeNodeSettings7.SelectedImageIndex = 4;
          treeNodeSettings7.Tag = (object) FoamPlaneType.YZ;
          treeNodeSettings7.ClassIndex = 0;
          treeNodeSettings7.ClassSubIndex = 0;
          treeNodeSettings7.ClassSubSubIndex = index3;
          treeNodeSettings7.ClassSubSubSubIndex = index4;
          treeNodeSettings7.Command = "patternYZ";
          treeNodeSettings7.Info = "YZ";
          treeNodeSettings7.Checked = true;
          TreeNodeSettings node7 = treeNodeSettings7;
          node6.Nodes.Add((TreeNode) node7);
        }
      }
      node1.Expand();
      this.treejobs.Nodes.Add((TreeNode) node1);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void DrawPreview()
  {
    if (clsItem.ModelMainPreview == null)
      return;
    if (clsItem.ModelMainPreview.Layers.Count != ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count)
    {
      clsItem.ModelMainPreview.Layers.Clear();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        clsItem.ModelMainPreview.Layers.Add((Layer) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Clone());
    }
    clsItem.ModelMainPreview.Entities.Clear();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      clsItem.ModelMainPreview.Entities.Add((Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Clone());
    clsItem.ModelMainPreview.Invalidate();
  }

  public void DeleteEntities(bool Mark, bool Sorted, bool Tool)
  {
    int num = 0;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData is CustomData)
      {
        CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Mark & Mark)
        {
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
          ++num;
        }
        if (entityData.typeDefination == entityTypeDefination.Sorted & Sorted)
        {
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
          ++num;
        }
        if (entityData.typeDefination == entityTypeDefination.Tool & Tool)
        {
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
          ++num;
        }
      }
    }
    if (num <= 0)
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void DrawBlock(List<FoamBlock> Blocks, Plane refPlane)
  {
    for (int index1 = 0; index1 <= Blocks.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Blocks[index1].Pattern.Count - 1; ++index2)
      {
        if (Blocks[index1].Pattern[index2].SolidEntities != null)
        {
          for (int index3 = 0; index3 <= Blocks[index1].Pattern[index2].SolidEntities.Count - 1; ++index3)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(Blocks[index1].Pattern[index2].SolidEntities[index3], ref copiedEntity);
            copiedEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
            if (buFoamCalc.varTemps.Layer3DPattern.Length > 0)
              copiedEntity.LayerName = buFoamCalc.varTemps.Layer3DPattern;
            ccVars.UndoDont = true;
            clsInit.appCommand.AddEntity(copiedEntity);
          }
        }
        bool flag = false;
        if (ccVars.Action == actionTypeBU.foamManuelSelect && Blocks[index1].Pattern[index2].sortEntities != null && Blocks[index1].Pattern[index2].sortEntities.Count > 0)
        {
          flag = true;
          Point3D pntStart = (Point3D) null;
          if (Blocks[index1].Pattern[index2].sortEntities[0].sortDirection == entitySortDirection.Normal)
            clsInit.cVector5.GetEntityStartPointByCamDirection(Blocks[index1].Pattern[index2].sortEntities[0], ref pntStart);
          else
            clsInit.cVector5.GetEntityStartPointByCamDirection(Blocks[index1].Pattern[index2].sortEntities[0], ref pntStart);
          if (refPlane == Plane.YZ)
            pntStart.X = this.activeFoam.Material.Size.Width;
          Entity refEntity1 = (Entity) null;
          clsInit.cFoamCut.CreateMarkCircleEntity(pntStart, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter + 2.0, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity1);
          ccVars.UndoDont = true;
          refEntity1.LayerName = buFoamCalc.varTemps.LayerDefault;
          if (buFoamCalc.varTemps.LayerSelection.Length > 0)
            refEntity1.LayerName = buFoamCalc.varTemps.LayerSelection;
          clsInit.appCommand.AddEntity(refEntity1);
          Point3D pntEnd = (Point3D) null;
          if (Blocks[index1].Pattern[index2].sortEntities[Blocks[index1].Pattern[index2].sortEntities.Count - 1].sortDirection == entitySortDirection.Normal)
            clsInit.cVector5.GetEntityEndPointByCamDirection(Blocks[index1].Pattern[index2].sortEntities[Blocks[index1].Pattern[index2].sortEntities.Count - 1], ref pntEnd);
          else
            clsInit.cVector5.GetEntityEndPointByCamDirection(Blocks[index1].Pattern[index2].sortEntities[Blocks[index1].Pattern[index2].sortEntities.Count - 1], ref pntEnd);
          if (refPlane == Plane.YZ)
            pntEnd.X = this.activeFoam.Material.Size.Width;
          Entity refEntity2 = (Entity) null;
          clsInit.cFoamCut.CreateMarkCircleEntity(pntEnd, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter + 2.0, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity2);
          refEntity2.LayerName = buFoamCalc.varTemps.LayerDefault;
          if (buFoamCalc.varTemps.LayerSelection.Length > 0)
            refEntity2.LayerName = buFoamCalc.varTemps.LayerSelection;
          ccVars.UndoDont = true;
          clsInit.appCommand.AddEntity(refEntity2);
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(Blocks[index1].Pattern[index2].sortEntities[0], ref copiedEntity);
          copiedEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
          if (buFoamCalc.varTemps.LayerSelection.Length > 0)
            copiedEntity.LayerName = buFoamCalc.varTemps.LayerSelection;
          ccVars.UndoDont = true;
          clsInit.appCommand.AddEntity(copiedEntity);
          copiedEntity = (Entity) null;
          buEntity.Copy(Blocks[index1].Pattern[index2].sortEntities[Blocks[index1].Pattern[index2].sortEntities.Count - 1], ref copiedEntity);
          copiedEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
          if (buFoamCalc.varTemps.LayerSelection.Length > 0)
            copiedEntity.LayerName = buFoamCalc.varTemps.LayerSelection;
          if (refPlane == Plane.YZ)
            copiedEntity.Translate(this.activeFoam.Material.Size.Width, 0.0);
          ccVars.UndoDont = true;
          clsInit.appCommand.AddEntity(copiedEntity);
        }
        if (Blocks[index1].Pattern[index2].foamEntities != null)
        {
          int num = 0;
          for (int index4 = 0; index4 <= Blocks[index1].Pattern[index2].foamEntities.Count - 1; ++index4)
          {
            for (int index5 = 0; index5 <= Blocks[index1].Pattern[index2].foamEntities[index4].GroupEntity.Outside.Entities.Count - 1; ++index5)
            {
              buEntity entity = Blocks[index1].Pattern[index2].foamEntities[index4].GroupEntity.Outside.Entities[index5];
              Entity copiedEntity = (Entity) null;
              buEntity.Copy(Blocks[index1].Pattern[index2].foamEntities[index4].GroupEntity.Outside.Entities[index5], ref copiedEntity);
              if (refPlane == Plane.YZ)
                copiedEntity.Translate(this.activeFoam.Material.Size.Width, 0.0);
              if (ccVars.Pages[ccVars.PageIndex].Layers.Count >= 4)
                copiedEntity.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[3].Name;
              ccVars.UndoDont = true;
              copiedEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
              if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
                copiedEntity.LayerName = buFoamCalc.varTemps.LayerWirePattern;
              clsInit.appCommand.AddEntity(copiedEntity);
              if (ccVars.Action == actionTypeBU.foamManuelSelect & !flag)
              {
                ++num;
                if (index5 == 0)
                {
                  Entity refEntity3 = (Entity) null;
                  Point3D point3D1 = buVector5.ToPoint3D(entity.StartPoint);
                  Point3D point3D2 = buVector5.ToPoint3D(entity.EndPoint);
                  if (refPlane == Plane.YZ)
                  {
                    point3D1.X = this.activeFoam.Material.Size.Width;
                    point3D2.X = this.activeFoam.Material.Size.Width;
                  }
                  clsInit.cFoamCut.CreateMarkCircleEntity(point3D1, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity3);
                  ccVars.UndoDont = true;
                  refEntity3.LayerName = buFoamCalc.varTemps.LayerDefault;
                  if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
                    refEntity3.LayerName = buFoamCalc.varTemps.LayerWirePattern;
                  clsInit.appCommand.AddEntity(refEntity3);
                  Entity refEntity4 = (Entity) null;
                  clsInit.cFoamCut.CreateMarkCircleEntity(point3D2, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity4);
                  ccVars.UndoDont = true;
                  refEntity4.LayerName = buFoamCalc.varTemps.LayerDefault;
                  if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
                    refEntity4.LayerName = buFoamCalc.varTemps.LayerWirePattern;
                  clsInit.appCommand.AddEntity(refEntity4);
                }
                else
                {
                  Point3D pntEnd = (Point3D) null;
                  clsInit.cVector5.GetEntityEndPointByCamDirection(entity, ref pntEnd);
                  if (refPlane == Plane.YZ)
                    pntEnd.X = this.activeFoam.Material.Size.Width;
                  Entity refEntity = (Entity) null;
                  clsInit.cFoamCut.CreateMarkCircleEntity(pntEnd, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity);
                  ccVars.UndoDont = true;
                  refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
                  if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
                    refEntity.LayerName = buFoamCalc.varTemps.LayerWirePattern;
                  clsInit.appCommand.AddEntity(refEntity);
                }
              }
            }
          }
          if (num > 0)
            ;
        }
      }
    }
  }

  public void BlockSizeAdjustFromPlane(FoamPlaneType refPlane)
  {
    if (refPlane == FoamPlaneType.XZ)
    {
      if (!this.varCalc.isVertical)
      {
        buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Width;
        if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.DownToUp)
        {
          buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
          if (this.activeFoam.BlockXZ.Count > 0)
          {
            double topZ = this.activeFoam.BlockXZ[this.activeFoam.BlockXZ.Count - 1].TopZ;
            buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth - topZ;
          }
        }
        if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
        {
          buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
          if (this.activeFoam.BlockXZ.Count > 0)
          {
            double bottomZ = this.activeFoam.BlockXZ[this.activeFoam.BlockXZ.Count - 1].BottomZ;
            buFoamCalc.varFoamRunSettings.BlockHeight = bottomZ;
          }
        }
      }
      else
      {
        buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
        buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Width;
        if (this.activeFoam.BlockXZ.Count > 0)
          buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Width - this.activeFoam.BlockXZ[this.activeFoam.BlockXZ.Count - 1].LeftMax;
      }
      if (this.frmWave != null & buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
      {
        this.frmWave.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
        this.frmWave.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
      }
      if (this.frmPattern != null & buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern)
      {
        this.frmPattern.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
        this.frmPattern.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
      }
      if (this.frmSlice != null & buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice && buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.SlicesHorizontal)
      {
        this.frmSlice.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
        this.frmSlice.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
      }
    }
    if (refPlane != FoamPlaneType.YZ)
      return;
    if (!this.varCalc.isVertical)
    {
      buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Height;
      if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.DownToUp)
      {
        buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
        if (this.activeFoam.BlockYZ.Count > 0)
        {
          double topZ = this.activeFoam.BlockYZ[this.activeFoam.BlockYZ.Count - 1].TopZ;
          buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth - topZ;
        }
      }
      if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
      {
        buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
        if (this.activeFoam.BlockYZ.Count > 0)
        {
          double bottomZ = this.activeFoam.BlockYZ[this.activeFoam.BlockYZ.Count - 1].BottomZ;
          buFoamCalc.varFoamRunSettings.BlockHeight = bottomZ;
        }
      }
    }
    else
    {
      buFoamCalc.varFoamRunSettings.BlockHeight = this.activeFoam.Material.Size.Depth;
      buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Height;
      if (this.activeFoam.BlockYZ.Count > 0)
        buFoamCalc.varFoamRunSettings.BlockWidth = this.activeFoam.Material.Size.Height - this.activeFoam.BlockYZ[this.activeFoam.BlockYZ.Count - 1].LeftMax;
    }
    if (this.frmWave != null & buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
    {
      this.frmWave.PropertiesForm.Inited = false;
      this.frmWave.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
      this.frmWave.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
      this.frmWave.PropertiesForm.Inited = true;
    }
    if (this.frmPattern != null & buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern)
    {
      this.frmPattern.PropertiesForm.Inited = false;
      this.frmPattern.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
      this.frmPattern.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
      this.frmPattern.PropertiesForm.Inited = true;
    }
    if (!(this.frmSlice != null & buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice))
      return;
    this.frmSlice.PropertiesForm.Inited = false;
    if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.SlicesHorizontal)
    {
      this.frmSlice.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
      this.frmSlice.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
    }
    if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.SlicesVertical)
    {
      this.frmSlice.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
      this.frmSlice.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
    }
    this.frmSlice.PropertiesForm.Inited = true;
  }

  public void CreatePanelFromJob(ref FoamItem Job, FoamCreatePanelOptions Option)
  {
    try
    {
      if (Option.DrawAll)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      }
      else
      {
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData is CustomData)
          {
            CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
            if (entityData.typeDefination == entityTypeDefination.Sorted & Option.DeleteSort)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
            if (entityData.typeDefination == entityTypeDefination.Tool & Option.DeleteTool)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
          }
        }
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
      }
      if (Job != null)
      {
        if (Option.DrawAll)
        {
          Brep box = Brep.CreateBox(Job.Material.Size.Width + 0.2, Job.Material.Size.Height + 0.2, Job.Material.Size.Depth + 0.2);
          box.Translate(-0.1, -0.1, -0.1);
          box.Rebuild(0.1);
          Job.SolidEntity = (Entity) box;
          Job.SolidEntity.Color = Color.FromArgb(buFoamCalc.varFoamSettings.FoamBaseTransparency, buFoamCalc.varFoamSettings.FoamBaseColor);
          Job.SolidEntity.ColorMethod = colorMethodType.byEntity;
          Job.SolidEntity.Regen(new RegenParams(0.01));
          if (ccVars.Pages[ccVars.PageIndex].Layers.Count >= 2)
            Job.SolidEntity.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[1].Name;
          Entity copiedEnt = (Entity) null;
          ccVars.UndoDont = true;
          buVector5.CopyEntities(this.activeFoam.SolidEntity, ref copiedEnt);
          copiedEnt.Selectable = false;
          copiedEnt.LayerName = buFoamCalc.varTemps.LayerDefault;
          if (buFoamCalc.varTemps.LayerFoam.Length > 0)
            copiedEnt.LayerName = buFoamCalc.varTemps.LayerFoam;
          clsInit.appCommand.AddEntity(copiedEnt);
          this.DrawBlock(Job.BlockXZ, Plane.XZ);
          this.DrawBlock(Job.BlockYZ, Plane.YZ);
        }
        for (int index1 = 0; index1 <= Job.sortedEntitiesXZ.Count - 1; ++index1)
        {
          List<Entity> createdEntities = new List<Entity>();
          clsInit.cFoamCut.CreateSortEntitiesAndArrow(Job.sortedEntitiesXZ[index1], Plane.XZ, ref createdEntities);
          for (int index2 = 0; index2 <= createdEntities.Count - 1; ++index2)
          {
            ccVars.UndoDont = true;
            createdEntities[index2].LayerName = buFoamCalc.varTemps.LayerDefault;
            if (buFoamCalc.varTemps.LayerSelection.Length > 0)
              createdEntities[index2].LayerName = buFoamCalc.varTemps.LayerSelection;
            clsInit.appCommand.AddEntity(createdEntities[index2]);
          }
        }
        for (int index3 = 0; index3 <= Job.sortedEntitiesYZ.Count - 1; ++index3)
        {
          List<Entity> createdEntities = new List<Entity>();
          clsInit.cFoamCut.CreateSortEntitiesAndArrow(Job.sortedEntitiesYZ[index3], Plane.YZ, ref createdEntities);
          for (int index4 = 0; index4 <= createdEntities.Count - 1; ++index4)
          {
            createdEntities[index4].Translate(this.activeFoam.Material.Size.Width + 0.5, 0.0);
            createdEntities[index4].LayerName = buFoamCalc.varTemps.LayerDefault;
            if (buFoamCalc.varTemps.LayerSelection.Length > 0)
              createdEntities[index4].LayerName = buFoamCalc.varTemps.LayerSelection;
            ccVars.UndoDont = true;
            clsInit.appCommand.AddEntity(createdEntities[index4]);
          }
        }
        for (int index5 = 0; index5 <= Job.CamXZ.CamPoints.Count - 1; ++index5)
        {
          for (int index6 = 0; index6 <= Job.CamXZ.CamPoints[index5].Points.Count - 1; ++index6)
          {
            if (Job.CamXZ.CamPoints[index5].Points[index6].IsMark | Job.CamXZ.CamPoints[index5].Points[index6].IsLimit)
            {
              Color color = buFoamCalc.varFoamSettings.LimitExceedColor;
              if (Job.CamXZ.CamPoints[index5].Points[index6].IsLimit)
                color = buFoamCalc.varFoamSettings.RotationMoreThen180;
              Point3D pntCenter = new Point3D(Job.CamXZ.CamPoints[index5].Points[index6].P9.X, Job.CamXZ.CamPoints[index5].Points[index6].P9.Z, Job.CamXZ.CamPoints[index5].Points[index6].P9.Y);
              Entity refEntity = (Entity) null;
              clsInit.cFoamCut.CreateMarkCircleEntity(pntCenter, Plane.XZ, buFoamCalc.varFoamSettings.LastPointDiameter + 0.0, entityTypeDefination.Sorted, color, ref refEntity);
              ccVars.UndoDont = true;
              refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
              if (buFoamCalc.varTemps.LayerMark.Length > 0)
                refEntity.LayerName = buFoamCalc.varTemps.LayerMark;
              clsInit.appCommand.AddEntity(refEntity);
            }
          }
        }
        for (int index7 = 0; index7 <= Job.CamYZ.CamPoints.Count - 1; ++index7)
        {
          for (int index8 = 0; index8 <= Job.CamYZ.CamPoints[index7].Points.Count - 1; ++index8)
          {
            if (Job.CamYZ.CamPoints[index7].Points[index8].IsMark | Job.CamYZ.CamPoints[index7].Points[index8].IsLimit)
            {
              Color color = buFoamCalc.varFoamSettings.LimitExceedColor;
              if (Job.CamYZ.CamPoints[index7].Points[index8].IsLimit)
                color = buFoamCalc.varFoamSettings.RotationMoreThen180;
              Point3D pntCenter = new Point3D(Job.CamYZ.CamPoints[index7].Points[index8].P9.Z, Job.CamYZ.CamPoints[index7].Points[index8].P9.X, Job.CamYZ.CamPoints[index7].Points[index8].P9.Y);
              Entity refEntity = (Entity) null;
              clsInit.cFoamCut.CreateMarkCircleEntity(pntCenter, Plane.YZ, buFoamCalc.varFoamSettings.LastPointDiameter + 0.0, entityTypeDefination.Sorted, color, ref refEntity);
              ccVars.UndoDont = true;
              refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
              if (buFoamCalc.varTemps.LayerMark.Length > 0)
                refEntity.LayerName = buFoamCalc.varTemps.LayerMark;
              clsInit.appCommand.AddEntity(refEntity);
            }
          }
        }
        if (ccVars.Action == actionTypeBU.foamManuelSelect)
        {
          if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ && Job.sortedEntitiesXZ.Count > 0)
          {
            Point3D pntEnd = new Point3D();
            clsInit.cVector5.GetEntityEndPointByCamDirection(Job.sortedEntitiesXZ[Job.sortedEntitiesXZ.Count - 1], ref pntEnd);
            Entity refEntity = (Entity) null;
            clsInit.cFoamCut.CreateMarkHexagonEntity(pntEnd, Plane.XZ, buFoamCalc.varFoamSettings.LastPointDiameter, entityTypeDefination.Sorted, buFoamCalc.varFoamSettings.MarkLastColor, ref refEntity);
            ccVars.UndoDont = true;
            refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
            if (buFoamCalc.varTemps.LayerSelection.Length > 0)
              refEntity.LayerName = buFoamCalc.varTemps.LayerSelection;
            clsInit.appCommand.AddEntity(refEntity);
          }
          if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ && Job.sortedEntitiesYZ.Count > 0)
          {
            Point3D pntEnd = new Point3D();
            clsInit.cVector5.GetEntityEndPointByCamDirection(Job.sortedEntitiesYZ[Job.sortedEntitiesYZ.Count - 1], ref pntEnd);
            Entity refEntity = (Entity) null;
            clsInit.cFoamCut.CreateMarkHexagonEntity(pntEnd, Plane.YZ, buFoamCalc.varFoamSettings.LastPointDiameter, entityTypeDefination.Sorted, buFoamCalc.varFoamSettings.MarkLastColor, ref refEntity);
            ccVars.UndoDont = true;
            refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
            if (buFoamCalc.varTemps.LayerSelection.Length > 0)
              refEntity.LayerName = buFoamCalc.varTemps.LayerSelection;
            clsInit.appCommand.AddEntity(refEntity);
          }
        }
      }
      if (Option.DrawPreview)
        this.DrawPreview();
      clsItem.FrmFoamJob.txt_info.Text = this.doCalcululateAllInfo();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.02);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void ParameterChanged(object Data1, object Data2)
  {
    if (Data1 == null)
      return;
    string str = Data1.ToString();
    if (str == "HorizontalCount" && (Data2 == null ? 0 : (Data2.GetType() == typeof (double) ? 1 : 0)) != 0)
    {
      double num = double.Parse(Data2.ToString());
      if (num > 0.0)
      {
        if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern)
        {
          buFoamCalc.varFoamRunSettings.BlockWidth = (buFoamCalc.varFoamRunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth) * num + buFoamCalc.varFoamRunSettings.PatternWidthStartOffset + buFoamCalc.varFoamRunSettings.PatternWidthEndOffset;
          this.frmPattern.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
        }
        if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
        {
          double shapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth;
          buFoamCalc.varFoamRunSettings.BlockWidth = shapeCommonWidth * (double) buFoamCalc.varFoamRunSettings.WaveFormRepeatCount * num + buFoamCalc.varFoamSettings.PatternDistancesHeight + buFoamCalc.varFoamRunSettings.PatternWidthStartOffset + buFoamCalc.varFoamRunSettings.PatternWidthEndOffset;
          this.frmWave.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
        }
        if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice)
        {
          buFoamCalc.varFoamRunSettings.BlockWidth = buFoamCalc.varFoamRunSettings.SlicesHeight * num + buFoamCalc.varFoamRunSettings.PatternWidthStartOffset + buFoamCalc.varFoamRunSettings.PatternWidthEndOffset;
          this.frmSlice.spn_blocktotalwidth.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockWidth;
        }
      }
    }
    if (str == "VerticalCount" && (Data2 == null ? 0 : (Data2.GetType() == typeof (double) ? 1 : 0)) != 0)
    {
      double num1 = double.Parse(Data2.ToString());
      if (num1 > 0.0)
      {
        if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern)
        {
          buFoamCalc.varFoamRunSettings.BlockHeight = (buFoamCalc.varFoamRunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight) * num1 + buFoamCalc.varFoamRunSettings.PatternHeightStartOffset + buFoamCalc.varFoamRunSettings.PatternHeightEndOffset;
          this.frmPattern.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
        }
        if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
        {
          double num2 = 2.0 * buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight;
          if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.VForm | buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.CForm)
            num2 = 2.0 * buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight - buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight;
          if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.Pyramid)
            num2 = buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight + (buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight - buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight);
          if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.Rectangle | buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.UForm)
            num2 = buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight + (buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight - buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight);
          buFoamCalc.varFoamRunSettings.BlockHeight = (num2 + buFoamCalc.varFoamRunSettings.WaveFormSpace) * num1 + buFoamCalc.varFoamSettings.PatternDistancesHeight + buFoamCalc.varFoamRunSettings.PatternHeightStartOffset + buFoamCalc.varFoamRunSettings.PatternHeightEndOffset;
          this.frmWave.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
          FoamUpdateArg Data2_1 = new FoamUpdateArg();
          this.OperationDataChanged((object) buFoamCalc.varFoamRunSettings, (object) Data2_1);
        }
        if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice)
        {
          buFoamCalc.varFoamRunSettings.BlockHeight = buFoamCalc.varFoamRunSettings.SlicesHeight * num1 + buFoamCalc.varFoamRunSettings.PatternHeightStartOffset + buFoamCalc.varFoamRunSettings.PatternHeightEndOffset;
          this.frmSlice.spn_blocktotalheight.Value = (Decimal) buFoamCalc.varFoamRunSettings.BlockHeight;
        }
      }
    }
    if (str == "FoamSize" && (Data2 == null ? 0 : (Data2 is SizeObject ? 1 : 0)) != 0)
    {
      this.activeFoam.Material.Size = new SizeObject((SizeObject) Data2);
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, false));
    }
    if (str == "VelCut" && (Data2 == null ? 0 : (Data2.GetType() == typeof (double) ? 1 : 0)) != 0)
    {
      double num = double.Parse(Data2.ToString());
      buFoamCalc.varFoamSettings.CuttingFeed = num;
    }
    if (str == "VelLeadIn" && (Data2 == null ? 0 : (Data2.GetType() == typeof (double) ? 1 : 0)) != 0)
    {
      double num = double.Parse(Data2.ToString());
      buFoamCalc.varFoamSettings.EntryFeed = num;
    }
    if (str == "VelLeadOut" && (Data2 == null ? 0 : (Data2.GetType() == typeof (double) ? 1 : 0)) != 0)
    {
      double num = double.Parse(Data2.ToString());
      buFoamCalc.varFoamSettings.LeaveFeed = num;
    }
    if (!(str == "VelConnection") || (Data2 == null ? 0 : (Data2.GetType() == typeof (double) ? 1 : 0)) == 0)
      return;
    double num3 = double.Parse(Data2.ToString());
    buFoamCalc.varFoamSettings.ConnectionFeed = num3;
  }

  public void OperationDataChanged(object Data1, object Data2)
  {
    FoamUpdateArg foamUpdateArg1 = new FoamUpdateArg();
    FoamUpdateArg foamUpdateArg2 = (FoamUpdateArg) Data2;
    if (!(Data1 is FoamRuntimeSettings))
      return;
    FoamRuntimeSettings foamRuntimeSettings = Data1 as FoamRuntimeSettings;
    buFoamCalc.varFoamRunSettings = new FoamRuntimeSettings(foamRuntimeSettings);
    buFoamCalc.varFoamSettings.PatternDistancesHeight = foamUpdateArg2.PatternSpaceHeight;
    buFoamCalc.varFoamSettings.PatternDistancesWidth = foamUpdateArg2.PatternSpaceWidth;
    if (foamUpdateArg2.Command == "PlaneYZ" | foamUpdateArg2.Command == "PlaneXZ")
    {
      if (foamRuntimeSettings.planeNames == FoamPlaneType.XZ)
      {
        this.cmdPlaneXZ(false);
        foamRuntimeSettings.BlockHeight = buFoamCalc.varFoamRunSettings.BlockHeight;
        foamRuntimeSettings.BlockWidth = buFoamCalc.varFoamRunSettings.BlockWidth;
      }
      else
      {
        this.cmdPlaneYZ(false);
        foamRuntimeSettings.BlockHeight = buFoamCalc.varFoamRunSettings.BlockHeight;
        foamRuntimeSettings.BlockWidth = buFoamCalc.varFoamRunSettings.BlockWidth;
      }
    }
    if (!foamUpdateArg2.Finished)
    {
      if (foamRuntimeSettings.TypeFoam == FoamType.VForm)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateWaveShape(foamRuntimeSettings, false, FoamType.VForm, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.SForm)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateWaveShape(foamRuntimeSettings, false, FoamType.SForm, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.CForm)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateWaveShape(foamRuntimeSettings, false, foamRuntimeSettings.TypeFoam, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.ZForm)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateWaveShape(foamRuntimeSettings, false, foamRuntimeSettings.TypeFoam, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.UForm)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateWaveShape(foamRuntimeSettings, false, foamRuntimeSettings.TypeFoam, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.Rectangle)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateWaveShape(foamRuntimeSettings, false, foamRuntimeSettings.TypeFoam, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.Pyramid)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateWaveShape(foamRuntimeSettings, false, foamRuntimeSettings.TypeFoam, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.FromDrawing)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculatePattern(foamRuntimeSettings, false, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.SlicesHorizontal)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateSlicesHorizontal(foamRuntimeSettings, false, foamRuntimeSettings.TypeFoam, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam == FoamType.SlicesVertical)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculateSlicesVertical(foamRuntimeSettings, false, foamRuntimeSettings.TypeFoam, ref FoamPatterns);
      }
      else if (foamRuntimeSettings.TypeFoam != FoamType.SingleLine && foamRuntimeSettings.TypeFoam == FoamType.Pattern)
      {
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.doCalculatePattern(foamRuntimeSettings, false, ref FoamPatterns);
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    else
    {
      this.doAddOperation(foamRuntimeSettings);
      if (foamRuntimeSettings.TypeFoam == FoamType.VForm)
      {
        foamRuntimeSettings.WaveFormVShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
        foamRuntimeSettings.WaveFormVShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
        foamRuntimeSettings.WaveFormVShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
      }
      if (foamRuntimeSettings.TypeFoam == FoamType.Pyramid)
      {
        foamRuntimeSettings.WaveFormPyramidShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
        foamRuntimeSettings.WaveFormPyramidShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
        foamRuntimeSettings.WaveFormPyramidShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
        foamRuntimeSettings.WaveFormPyramidShapeCount = foamRuntimeSettings.WaveFormShapeCommonCount;
      }
      if (foamRuntimeSettings.TypeFoam == FoamType.UForm)
      {
        foamRuntimeSettings.WaveFormUShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
        foamRuntimeSettings.WaveFormUShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
        foamRuntimeSettings.WaveFormUShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
      }
      if (foamRuntimeSettings.TypeFoam == FoamType.CForm)
      {
        foamRuntimeSettings.WaveFormCShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
        foamRuntimeSettings.WaveFormCShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
        foamRuntimeSettings.WaveFormCShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
      }
      if (foamRuntimeSettings.TypeFoam == FoamType.SForm)
      {
        foamRuntimeSettings.WaveFormSShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
        foamRuntimeSettings.WaveFormSShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
        foamRuntimeSettings.WaveFormSShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
      }
      if (foamRuntimeSettings.TypeFoam == FoamType.ZForm)
      {
        foamRuntimeSettings.WaveFormZShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
        foamRuntimeSettings.WaveFormZShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
        foamRuntimeSettings.WaveFormZShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
      }
      if (foamRuntimeSettings.TypeFoam == FoamType.Rectangle)
      {
        foamRuntimeSettings.WaveFormRectShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
        foamRuntimeSettings.WaveFormRectShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
        foamRuntimeSettings.WaveFormRectShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
      }
      buFoamCalc.varFoamRunSettings = new FoamRuntimeSettings(foamRuntimeSettings);
    }
  }

  public void OperationDataCancel() => clsInit.appCommand.Reset();

  public void doUndoSelection()
  {
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ && this.activeFoam.sortedEntitiesXZ.Count > 0)
    {
      if (this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.Upper | this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin | this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut)
      {
        this.activeFoam.sortedEntitiesXZ.RemoveAt(this.activeFoam.sortedEntitiesXZ.Count - 1);
        buVector5.PointClickData.isPointOnEntity = false;
        if (this.activeFoam.sortedEntitiesXZ.Count > 0)
        {
          Point3D pntEnd = new Point3D();
          clsInit.cVector5.GetEntityEndPointByCamDirection(this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1], ref pntEnd);
          ccVars.pntBase = buVector5.ToPoint3D(pntEnd);
          buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd);
          this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
        }
      }
      else
      {
        for (int index = this.activeFoam.sortedEntitiesXZ.Count - 1; index >= 0; --index)
        {
          if (!(this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.Upper | this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin | this.activeFoam.sortedEntitiesXZ[this.activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut))
          {
            int sequence = this.activeFoam.sortedEntitiesXZ[index].Info.Sequence;
            if (sequence >= 0 & sequence <= this.sortRefEntities.Count - 1)
              this.sortRefEntities[sequence].Info.CamSelected = false;
            this.activeFoam.sortedEntitiesXZ.RemoveAt(index);
          }
          else
          {
            Point3D pntEnd = new Point3D();
            clsInit.cVector5.GetEntityEndPointByCamDirection(this.activeFoam.sortedEntitiesXZ[index], ref pntEnd);
            ccVars.pntBase = buVector5.ToPoint3D(pntEnd);
            buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd);
            buVector5.PointClickData.isPointOnEntity = true;
            this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
            return;
          }
        }
      }
    }
    if (buFoamCalc.varFoamRunSettings.planeNames != FoamPlaneType.YZ || this.activeFoam.sortedEntitiesYZ.Count <= 0)
      return;
    if (this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.Upper | this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin | this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut)
    {
      this.activeFoam.sortedEntitiesYZ.RemoveAt(this.activeFoam.sortedEntitiesYZ.Count - 1);
      buVector5.PointClickData.isPointOnEntity = false;
      if (this.activeFoam.sortedEntitiesYZ.Count <= 0)
        return;
      Point3D pntEnd = new Point3D();
      clsInit.cVector5.GetEntityEndPointByCamDirection(this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1], ref pntEnd);
      ccVars.pntBase = buVector5.ToPoint3D(pntEnd);
      buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd);
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
    }
    else
    {
      for (int index = this.activeFoam.sortedEntitiesYZ.Count - 1; index >= 0; --index)
      {
        if (!(this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.Upper | this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin | this.activeFoam.sortedEntitiesYZ[this.activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut))
        {
          int sequence = this.activeFoam.sortedEntitiesYZ[index].Info.Sequence;
          if (sequence >= 0 & sequence <= this.sortRefEntities.Count - 1)
            this.sortRefEntities[sequence].Info.CamSelected = false;
          this.activeFoam.sortedEntitiesYZ.RemoveAt(index);
        }
        else
        {
          Point3D pntEnd = new Point3D();
          clsInit.cVector5.GetEntityEndPointByCamDirection(this.activeFoam.sortedEntitiesYZ[index], ref pntEnd);
          ccVars.pntBase = buVector5.ToPoint3D(pntEnd);
          buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd);
          buVector5.PointClickData.isPointOnEntity = true;
          this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
          break;
        }
      }
    }
  }

  public void doFinishSelection()
  {
    this.doReset();
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
    this.activeFoam.isGCodeCreated = false;
  }

  public void doDeleteSelection(FoamPlaneType refPlane)
  {
    if (buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[20]) != DialogResult.Yes)
      return;
    if (refPlane == FoamPlaneType.XZ)
    {
      this.activeFoam.isGCodeCreated = false;
      this.activeFoam.CamXZ = new camTp();
      this.activeFoam.sortedEntitiesXZ.Clear();
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
      this.JobUpdate(true, "", (DrillItem) null, -1);
    }
    if (refPlane == FoamPlaneType.YZ)
    {
      this.activeFoam.isGCodeCreated = false;
      this.activeFoam.CamYZ = new camTp();
      this.activeFoam.sortedEntitiesYZ.Clear();
      this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
      this.JobUpdate(true, "", (DrillItem) null, -1);
    }
    this.activeFoam.isGCodeCreated = false;
  }

  public void doManuelSelection(Point3D refPoint)
  {
    ccVars.enableViewportDrawCurrentLine = true;
    ccVars.pntBase = buVector5.ToPoint3D(refPoint);
    this.sortbuSettings_0.Option.Jump = false;
    this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
    if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.CW)
      this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.CW;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.CCW)
      this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.CCW;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.LowerIndex)
      this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.HigherIndex)
      this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.Jump)
      this.sortbuSettings_0.Option.Jump = true;
    else if (this.sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.Manuel)
      this.sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
    {
      List<buEntity> copiedEntities1 = new List<buEntity>();
      buEntity.Copy(this.activeFoam.sortedEntitiesXZ, ref copiedEntities1);
      if (this.sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.Jump)
      {
        for (int index1 = 0; index1 <= this.activeFoam.BlockXZ.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= this.activeFoam.BlockXZ[index1].Pattern.Count - 1; ++index2)
          {
            if (this.activeFoam.BlockXZ[index1].Pattern[index2].sortEntities.Count > 0)
            {
              buEntity sortEntity1 = this.activeFoam.BlockXZ[index1].Pattern[index2].sortEntities[0];
              buEntity sortEntity2 = this.activeFoam.BlockXZ[index1].Pattern[index2].sortEntities[this.activeFoam.BlockXZ[index1].Pattern[index2].sortEntities.Count - 1];
              if (!buCompare5.EQ(sortEntity1.StartPoint, refPoint, 0.1))
              {
                if (buCompare5.EQ(sortEntity2.EndPoint, refPoint, 0.1))
                {
                  if (Point3D.Distance(this.sortPointClickResult_0.LastPoint, refPoint) > 0.1)
                  {
                    buLine buLine = new buLine(this.sortPointClickResult_0.LastPoint, refPoint);
                    buLine.typeDefination = entityTypeDefination.Upper;
                    this.activeFoam.sortedEntitiesXZ.Add((buEntity) buLine);
                  }
                  List<buEntity> copiedEntities2 = new List<buEntity>();
                  buEntity.Copy(this.activeFoam.BlockXZ[index1].Pattern[index2].sortEntities, ref copiedEntities2);
                  copiedEntities2.Reverse();
                  for (int index3 = 0; index3 <= copiedEntities2.Count - 1; ++index3)
                  {
                    buEntity copiedEntity = (buEntity) null;
                    buEntity.Copy(copiedEntities2[index3], ref copiedEntity);
                    copiedEntity.sortDirection = copiedEntity.sortDirection != entitySortDirection.Normal ? entitySortDirection.Normal : entitySortDirection.Reverse;
                    this.activeFoam.sortedEntitiesXZ.Add(copiedEntity);
                  }
                  this.sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(sortEntity1.StartPoint);
                  ccVars.pntBase = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                  buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                  buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                  this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
                  return;
                }
              }
              else
              {
                if (Point3D.Distance(this.sortPointClickResult_0.LastPoint, refPoint) > 0.1)
                {
                  buLine buLine = new buLine(this.sortPointClickResult_0.LastPoint, refPoint);
                  buLine.typeDefination = entityTypeDefination.Upper;
                  this.activeFoam.sortedEntitiesXZ.Add((buEntity) buLine);
                }
                for (int index4 = 0; index4 <= this.activeFoam.BlockXZ[index1].Pattern[index2].sortEntities.Count - 1; ++index4)
                {
                  buEntity copiedEntity = (buEntity) null;
                  buEntity.Copy(this.activeFoam.BlockXZ[index1].Pattern[index2].sortEntities[index4], ref copiedEntity);
                  this.activeFoam.sortedEntitiesXZ.Add(copiedEntity);
                }
                this.sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(sortEntity2.EndPoint);
                ccVars.pntBase = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
                return;
              }
            }
          }
        }
      }
      this.sortbuSettings_0.Option.refPlane = Plane.XZ;
      clsInit.cVector5.SortEntitiesByClick(refPoint, ref this.sortRefEntities, this.sortbuSettings_0, ref this.activeFoam.sortedEntitiesXZ, ref this.sortPointClickResult_0);
      ccVars.pntBase = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
    }
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
    {
      List<buEntity> copiedEntities3 = new List<buEntity>();
      buEntity.Copy(this.activeFoam.sortedEntitiesYZ, ref copiedEntities3);
      if (this.sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.Jump)
      {
        for (int index5 = 0; index5 <= this.activeFoam.BlockYZ.Count - 1; ++index5)
        {
          for (int index6 = 0; index6 <= this.activeFoam.BlockYZ[index5].Pattern.Count - 1; ++index6)
          {
            if (this.activeFoam.BlockYZ[index5].Pattern[index6].sortEntities.Count > 0)
            {
              buEntity sortEntity3 = this.activeFoam.BlockYZ[index5].Pattern[index6].sortEntities[0];
              buEntity sortEntity4 = this.activeFoam.BlockYZ[index5].Pattern[index6].sortEntities[this.activeFoam.BlockYZ[index5].Pattern[index6].sortEntities.Count - 1];
              if (!buCompare5.EQ(sortEntity3.StartPoint, refPoint, 0.1))
              {
                if (buCompare5.EQ(sortEntity4.EndPoint, refPoint, 0.1))
                {
                  if (Point3D.Distance(this.sortPointClickResult_0.LastPoint, refPoint) > 0.1)
                  {
                    buLine buLine = new buLine(this.sortPointClickResult_0.LastPoint, refPoint);
                    buLine.typeDefination = entityTypeDefination.Upper;
                    this.activeFoam.sortedEntitiesXZ.Add((buEntity) buLine);
                  }
                  List<buEntity> copiedEntities4 = new List<buEntity>();
                  buEntity.Copy(this.activeFoam.BlockYZ[index5].Pattern[index6].sortEntities, ref copiedEntities4);
                  copiedEntities4.Reverse();
                  for (int index7 = 0; index7 <= copiedEntities4.Count - 1; ++index7)
                  {
                    buEntity copiedEntity = (buEntity) null;
                    buEntity.Copy(copiedEntities4[index7], ref copiedEntity);
                    copiedEntity.sortDirection = copiedEntity.sortDirection != entitySortDirection.Normal ? entitySortDirection.Normal : entitySortDirection.Reverse;
                    this.activeFoam.sortedEntitiesXZ.Add(copiedEntity);
                  }
                  this.sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(sortEntity3.StartPoint);
                  ccVars.pntBase = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                  buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                  buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                  this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
                  return;
                }
              }
              else
              {
                if (Point3D.Distance(this.sortPointClickResult_0.LastPoint, refPoint) > 0.1)
                {
                  buLine buLine = new buLine(this.sortPointClickResult_0.LastPoint, refPoint);
                  buLine.typeDefination = entityTypeDefination.Upper;
                  this.activeFoam.sortedEntitiesXZ.Add((buEntity) buLine);
                }
                for (int index8 = 0; index8 <= this.activeFoam.BlockYZ[index5].Pattern[index6].sortEntities.Count - 1; ++index8)
                {
                  buEntity copiedEntity = (buEntity) null;
                  buEntity.Copy(this.activeFoam.BlockYZ[index5].Pattern[index6].sortEntities[index8], ref copiedEntity);
                  this.activeFoam.sortedEntitiesXZ.Add(copiedEntity);
                }
                this.sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(sortEntity4.EndPoint);
                ccVars.pntBase = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
                this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
                return;
              }
            }
          }
        }
      }
      this.sortbuSettings_0.Option.refPlane = Plane.YZ;
      clsInit.cVector5.SortEntitiesByClick(refPoint, ref this.sortRefEntities, this.sortbuSettings_0, ref this.activeFoam.sortedEntitiesYZ, ref this.sortPointClickResult_0);
      ccVars.pntBase = buVector5.ToPoint3D(this.sortPointClickResult_0.LastPoint);
    }
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
  }

  public void doAddFoam(MaterialBase5 Mat, bool New)
  {
    if (ccVars.Pages.Count <= 0)
      return;
    if (New)
      this.activeFoam = new FoamItem();
    if (this.activeFoam == null)
      this.activeFoam = new FoamItem();
    this.activeFoam.Material = new MaterialBase5(Mat);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
    if (New)
    {
      clsInit.appCommand.PagesUpdate(true, "");
      clsInit.appCommand.cmdViewZoomFit();
      clsInit.appCommand.cmdViewZoomOut();
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public string doCalcululateAllInfo()
  {
    string str1 = "";
    string str2;
    if (this.activeFoam == null)
    {
      str2 = $"{buLangTranslate.preDef.Foam} {buLangTranslate.preDef.NotReady}";
    }
    else
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 0.0;
      double num5 = 0.0;
      double num6 = 0.0;
      TpPnt9D tpPnt9D = new TpPnt9D();
      double num7 = this.activeFoam.Material.Size.Width * this.activeFoam.Material.Size.Depth;
      double num8 = this.activeFoam.Material.Size.Height * this.activeFoam.Material.Size.Depth;
      for (int index1 = 0; index1 <= this.activeFoam.BlockXZ.Count - 1; ++index1)
      {
        FoamBlock foamBlock = this.activeFoam.BlockXZ[index1];
        for (int index2 = 0; index2 <= foamBlock.Pattern.Count - 1; ++index2)
          num3 += this.activeFoam.BlockXZ[index1].Pattern[index2].Info.TotalArea;
      }
      for (int index = 0; index <= this.activeFoam.sortedEntitiesXZ.Count - 1; ++index)
        num1 += clsInit.cVector5.Length3D(this.activeFoam.sortedEntitiesXZ[index].Vertices);
      for (int index3 = 0; index3 <= this.activeFoam.CamXZ.CamPoints.Count - 1; ++index3)
      {
        camTp camXz = this.activeFoam.CamXZ;
        if (index3 > 0 && camXz.CamPoints[index3].Points.Count > 0)
        {
          TpPnt9D point = camXz.CamPoints[index3].Points[0];
          double num9 = Point3D.Distance(new Point3D(point.P9.X, point.P9.Y, point.P9.Z), new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
          if (num9 > 0.0)
          {
            if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
              num2 += Math.Round(num9 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
            if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
              num2 += Math.Round(num9 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
          }
        }
        if (camXz.CamPoints[index3].Points.Count > 0)
        {
          for (int index4 = 1; index4 <= camXz.CamPoints[index3].Points.Count - 1; ++index4)
          {
            TpPnt9D point1 = camXz.CamPoints[index3].Points[index4 - 1];
            TpPnt9D point2 = camXz.CamPoints[index3].Points[index4];
            double num10 = Point3D.Distance(new Point3D(point1.P9.X, point1.P9.Y, point1.P9.Z), new Point3D(point2.P9.X, point2.P9.Y, point2.P9.Z));
            if (num10 > 0.0)
            {
              if (point2.Feed > 0.0 & (point2.Type == 1 | point2.Type == 2 | point2.Type == 3))
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num2 += Math.Round(num10 / point2.Feed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num2 += Math.Round(num10 / point2.Feed * 60.0, 3);
              }
              else
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num2 += Math.Round(num10 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num2 += Math.Round(num10 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
              }
            }
            else if (Math.Abs(point1.P9.C - point2.P9.C) > 0.0)
            {
              if (point2.Type == 1)
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num2 += Math.Round(Math.Abs(point1.P9.C - point2.P9.C) / point2.Feed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num2 += Math.Round(Math.Abs(point1.P9.C - point2.P9.C) / (point2.Feed * 60.0), 3);
              }
              else
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num2 += Math.Round(Math.Abs(point1.P9.C - point2.P9.C) / buFoamCalc.varFoamSettings.MachineG0TangentSpeed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num2 += Math.Round(Math.Abs(point1.P9.C - point2.P9.C) / (buFoamCalc.varFoamSettings.MachineG0TangentSpeed * 60.0), 3);
              }
            }
          }
          tpPnt9D = new TpPnt9D(camXz.CamPoints[index3].Points[camXz.CamPoints[index3].Points.Count - 1]);
        }
      }
      for (int index5 = 0; index5 <= this.activeFoam.BlockYZ.Count - 1; ++index5)
      {
        FoamBlock foamBlock = this.activeFoam.BlockYZ[index5];
        for (int index6 = 0; index6 <= foamBlock.Pattern.Count - 1; ++index6)
          num6 += this.activeFoam.BlockYZ[index5].Pattern[index6].Info.TotalArea;
      }
      for (int index = 0; index <= this.activeFoam.sortedEntitiesYZ.Count - 1; ++index)
        num4 += clsInit.cVector5.Length3D(this.activeFoam.sortedEntitiesYZ[index].Vertices);
      for (int index7 = 0; index7 <= this.activeFoam.CamYZ.CamPoints.Count - 1; ++index7)
      {
        camTp camYz = this.activeFoam.CamYZ;
        if (index7 > 0 && camYz.CamPoints[index7].Points.Count > 0)
        {
          TpPnt9D point = camYz.CamPoints[index7].Points[0];
          double num11 = Point3D.Distance(new Point3D(point.P9.X, point.P9.Y, point.P9.Z), new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
          if (num11 > 0.0)
          {
            if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
              num5 += Math.Round(num11 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
            if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
              num5 += Math.Round(num11 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
          }
        }
        if (camYz.CamPoints[index7].Points.Count > 0)
        {
          for (int index8 = 1; index8 <= camYz.CamPoints[index7].Points.Count - 1; ++index8)
          {
            TpPnt9D point3 = camYz.CamPoints[index7].Points[index8 - 1];
            TpPnt9D point4 = camYz.CamPoints[index7].Points[index8];
            double num12 = Point3D.Distance(new Point3D(point3.P9.X, point3.P9.Y, point3.P9.Z), new Point3D(point4.P9.X, point4.P9.Y, point4.P9.Z));
            if (num12 > 0.0)
            {
              if (point4.Feed > 0.0 & (point4.Type == 1 | point4.Type == 2 | point4.Type == 3))
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num5 += Math.Round(num12 / point4.Feed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num5 += Math.Round(num12 / point4.Feed * 60.0, 3);
              }
              else
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num5 += Math.Round(num12 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num5 += Math.Round(num12 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
              }
            }
            else if (Math.Abs(point3.P9.C - point4.P9.C) > 0.0)
            {
              if (point4.Type == 1)
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num5 += Math.Round(Math.Abs(point3.P9.C - point4.P9.C) / point4.Feed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num5 += Math.Round(Math.Abs(point3.P9.C - point4.P9.C) / (point4.Feed * 60.0), 3);
              }
              else
              {
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
                  num5 += Math.Round(Math.Abs(point3.P9.C - point4.P9.C) / buFoamCalc.varFoamSettings.MachineG0TangentSpeed, 3);
                if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
                  num5 += Math.Round(Math.Abs(point3.P9.C - point4.P9.C) / (buFoamCalc.varFoamSettings.MachineG0TangentSpeed * 60.0), 3);
              }
            }
          }
          tpPnt9D = new TpPnt9D(camYz.CamPoints[index7].Points[camYz.CamPoints[index7].Points.Count - 1]);
        }
      }
      str2 = $"{$"{$"{$"{$"{$"{$"{$"{$"{str1}----- {buLangTranslate.preDef.Foam} {buLangTranslate.preDef.Information} -----{Environment.NewLine}"}[ {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane} ]{Environment.NewLine}"}{buLangTranslate.preDef.Execution}{buLangTranslate.preDef.Time} = {num2.ToString("f1")} {buLangTranslate.preDef.Second}{Environment.NewLine}"}{buLangTranslate.preDef.Efficiency}%{(num3 / num7).ToString("f1")}{Environment.NewLine}"}{buLangTranslate.preDef.Total}{buLangTranslate.preDef.Length} = {num1.ToString("f1")} {buFoamCalc.varFoamSettings.UnitLength.ToString()}{Environment.NewLine}" + Environment.NewLine}[ {buLangTranslate.preDef.Side} {buLangTranslate.preDef.Plane} ]{Environment.NewLine}"}{buLangTranslate.preDef.Execution}{buLangTranslate.preDef.Time} = {num5.ToString("f1")} {buLangTranslate.preDef.Second}{Environment.NewLine}"}{buLangTranslate.preDef.Efficiency}%{(num6 / num8).ToString("f1")}{Environment.NewLine}"}{buLangTranslate.preDef.Total}{buLangTranslate.preDef.Length} = {num4.ToString("f1")} {buFoamCalc.varFoamSettings.UnitLength.ToString()}{Environment.NewLine}";
    }
    return str2;
  }

  public void doCheckLimits()
  {
    List<string> stringList1 = new List<string>();
    List<string> stringList2 = new List<string>();
    Point3D MinPoint1 = new Point3D();
    Point3D MaxPoint = new Point3D();
    this.activeFoam.isError = false;
    if (this.activeFoam.sortedEntitiesXZ.Count > 0)
    {
      clsInit.cVector5.BoxSizeCalculate(this.activeFoam.sortedEntitiesXZ, ref MinPoint1, ref MaxPoint);
      if (buFoamCalc.varFoamSettings.CheckMachineSize)
      {
        if (MinPoint1.Z < buFoamCalc.varFoamSettings.MachineLimitMinZ)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[23]} [Z] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.Z > buFoamCalc.varFoamSettings.MachineLimitZ)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[24]} [Z] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MinPoint1.Y < buFoamCalc.varFoamSettings.MachineLimitMinY)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[23]} [Y] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.Y > buFoamCalc.varFoamSettings.MachineLimitY)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[24]} [Y] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MinPoint1.X < buFoamCalc.varFoamSettings.MachineLimitMinX)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[23]} [X] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.X > buFoamCalc.varFoamSettings.MachineLimitX)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[24]} [X] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
      }
      if (buFoamCalc.varFoamSettings.CheckFoamSize)
      {
        if (MaxPoint.Z > this.activeFoam.Material.Size.Depth)
          stringList2.Add($"{buLangTranslate.preDef.Warning} {buLangTranslate.preDef.Foam} | {buFoamCalc.LangFoamMessage[24]} [Z] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.Y > this.activeFoam.Material.Size.Height)
          stringList2.Add($"{buLangTranslate.preDef.Warning} {buLangTranslate.preDef.Foam} | {buFoamCalc.LangFoamMessage[24]} [Y] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.X > this.activeFoam.Material.Size.Width)
          stringList2.Add($"{buLangTranslate.preDef.Warning} {buLangTranslate.preDef.Foam} | {buFoamCalc.LangFoamMessage[24]} [X] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
      }
    }
    Point3D MinPoint2 = new Point3D();
    MaxPoint = new Point3D();
    if (this.activeFoam.sortedEntitiesYZ.Count > 0)
    {
      clsInit.cVector5.BoxSizeCalculate(this.activeFoam.sortedEntitiesYZ, ref MinPoint2, ref MaxPoint);
      if (buFoamCalc.varFoamSettings.CheckMachineSize)
      {
        if (MinPoint2.Z < buFoamCalc.varFoamSettings.MachineLimitMinZ)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[23]} [Z] - {buLangTranslate.preDef.Side} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.Z > buFoamCalc.varFoamSettings.MachineLimitZ)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[24]} [Z] - {buLangTranslate.preDef.Side} {buLangTranslate.preDef.Plane}");
        if (MinPoint2.Y < buFoamCalc.varFoamSettings.MachineLimitMinY)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[23]} [Y] - {buLangTranslate.preDef.Side} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.Y > buFoamCalc.varFoamSettings.MachineLimitY)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[24]} [Y] - {buLangTranslate.preDef.Side} {buLangTranslate.preDef.Plane}");
        if (MinPoint2.X < buFoamCalc.varFoamSettings.MachineLimitMinX)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[23]} [X] - {buLangTranslate.preDef.Side} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.X > buFoamCalc.varFoamSettings.MachineLimitX)
          stringList1.Add($"{buLangTranslate.preDef.Error} {buLangTranslate.preDef.Machine} | {buFoamCalc.LangFoamMessage[24]} [X] - {buLangTranslate.preDef.Side} {buLangTranslate.preDef.Plane}");
      }
      if (buFoamCalc.varFoamSettings.CheckFoamSize)
      {
        if (MaxPoint.Z > this.activeFoam.Material.Size.Depth)
          stringList2.Add($"{buLangTranslate.preDef.Warning} {buLangTranslate.preDef.Foam} | {buFoamCalc.LangFoamMessage[24]} [Z] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.Y > this.activeFoam.Material.Size.Height)
          stringList2.Add($"{buLangTranslate.preDef.Warning} {buLangTranslate.preDef.Foam} | {buFoamCalc.LangFoamMessage[24]} [Y] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
        if (MaxPoint.X > this.activeFoam.Material.Size.Width)
          stringList2.Add($"{buLangTranslate.preDef.Warning} {buLangTranslate.preDef.Foam} | {buFoamCalc.LangFoamMessage[24]} [X] - {buLangTranslate.preDef.Main} {buLangTranslate.preDef.Plane}");
      }
    }
    if (stringList1.Count > 0)
      this.activeFoam.isError = true;
    if (!(stringList1.Count > 0 | stringList2.Count > 0))
      return;
    DialogBoxList dialogBoxList = new DialogBoxList();
    dialogBoxList.Caption = buLangTranslate.preDef.Error;
    dialogBoxList.Width = 500;
    for (int index = 0; index <= stringList1.Count - 1; ++index)
      dialogBoxList.Items.Add(stringList1[index]);
    for (int index = 0; index <= stringList2.Count - 1; ++index)
      dialogBoxList.Items.Add(stringList2[index]);
    dialogBoxList.Init();
    int num = (int) dialogBoxList.ShowDialog();
  }

  public void doDeleteBlocks(int indexBlock)
  {
    if (this.foamActiveBlock_0.Plane == FoamPlaneType.XZ && indexBlock >= 0 & indexBlock <= this.activeFoam.BlockXZ.Count - 1)
    {
      this.activeFoam.BlockXZ.RemoveAt(indexBlock);
      this.activeFoam.sortedEntitiesXZ.Clear();
      this.activeFoam.sortedEntitiesYZ.Clear();
      this.activeFoam.CamXZ = new camTp();
      this.activeFoam.CamYZ = new camTp();
      this.activeFoam.isGCodeCreated = false;
    }
    if (this.foamActiveBlock_0.Plane == FoamPlaneType.YZ && indexBlock >= 0 & indexBlock <= this.activeFoam.BlockYZ.Count - 1)
    {
      this.activeFoam.BlockYZ.RemoveAt(indexBlock);
      this.activeFoam.sortedEntitiesXZ.Clear();
      this.activeFoam.sortedEntitiesYZ.Clear();
      this.activeFoam.CamXZ = new camTp();
      this.activeFoam.CamYZ = new camTp();
      this.activeFoam.isGCodeCreated = false;
    }
    this.JobUpdate(true, "", (DrillItem) null, -1);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
  }

  public void doDeleteAllBlocks()
  {
    this.activeFoam.BlockXZ.Clear();
    this.activeFoam.BlockYZ.Clear();
    this.activeFoam.sortedEntitiesXZ.Clear();
    this.activeFoam.sortedEntitiesYZ.Clear();
    this.activeFoam.CamXZ = new camTp();
    this.activeFoam.CamYZ = new camTp();
    this.activeFoam.isGCodeCreated = false;
    this.JobUpdate(true, "", (DrillItem) null, -1);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
  }

  public void doEditBlocks()
  {
    FoamRuntimeSettings foamRuntimeSettings = new FoamRuntimeSettings(buFoamCalc.varFoamRunSettings);
    for (int index = 0; index <= this.activeFoam.BlockXZ.Count - 1; ++index)
    {
      if (this.activeFoam.BlockXZ[index].isWaveOperation)
      {
        this.activeBlock = new FoamBlock(this.activeFoam.BlockXZ[index]);
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.activeFoam.BlockXZ[index].Settings.BlockWidth = this.activeFoam.Material.Size.Width;
        this.doCalculateWaveShape(this.activeFoam.BlockXZ[index].Settings, true, this.activeFoam.BlockXZ[index].BlockFoamType, ref FoamPatterns, true);
        if (FoamPatterns.Count > 0)
          this.activeFoam.BlockXZ[index].Pattern = FoamPatterns;
      }
      if (this.activeFoam.BlockXZ[index].BlockFoamType == FoamType.Pattern)
      {
        this.activeBlock = new FoamBlock(this.activeFoam.BlockXZ[index]);
        if (this.activeFoam.BlockXZ[index].basePattern != null)
          this.activePattern = new FoamPattern(this.activeFoam.BlockXZ[index].basePattern);
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.activeFoam.BlockXZ[index].Settings.BlockWidth = this.activeFoam.Material.Size.Width;
        this.doCalculatePattern(this.activeFoam.BlockXZ[index].Settings, true, ref FoamPatterns, true);
        if (FoamPatterns.Count > 0)
          this.activeFoam.BlockXZ[index].Pattern = FoamPatterns;
      }
    }
    for (int index = 0; index <= this.activeFoam.BlockYZ.Count - 1; ++index)
    {
      if (this.activeFoam.BlockYZ[index].isWaveOperation)
      {
        this.activeBlock = new FoamBlock(this.activeFoam.BlockYZ[index]);
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.activeFoam.BlockYZ[index].Settings.BlockWidth = this.activeFoam.Material.Size.Height;
        this.doCalculateWaveShape(this.activeFoam.BlockYZ[index].Settings, true, this.activeFoam.BlockYZ[index].BlockFoamType, ref FoamPatterns, true);
        if (FoamPatterns.Count > 0)
          this.activeFoam.BlockYZ[index].Pattern = FoamPatterns;
      }
      if (this.activeFoam.BlockYZ[index].BlockFoamType == FoamType.Pattern)
      {
        this.activeBlock = new FoamBlock(this.activeFoam.BlockYZ[index]);
        if (this.activeFoam.BlockYZ[index].basePattern != null)
          this.activePattern = new FoamPattern(this.activeFoam.BlockYZ[index].basePattern);
        List<FoamPattern> FoamPatterns = new List<FoamPattern>();
        this.activeFoam.BlockYZ[index].Settings.BlockWidth = this.activeFoam.Material.Size.Height;
        this.doCalculatePattern(this.activeFoam.BlockYZ[index].Settings, true, ref FoamPatterns, true);
        if (FoamPatterns.Count > 0)
          this.activeFoam.BlockYZ[index].Pattern = FoamPatterns;
      }
    }
    this.activeFoam.sortedEntitiesXZ.Clear();
    this.activeFoam.sortedEntitiesYZ.Clear();
    this.JobUpdate(true, "", (DrillItem) null, -1);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
    this.activeFoam.isGCodeCreated = false;
    clsInit.appCommand.Reset();
  }

  public void doOperationSizeCalcHor(ref FoamRuntimeSettings RunSettings, bool Edit = false)
  {
    if (this.activeBlock == null)
      this.activeBlock = new FoamBlock();
    List<FoamBlock> foamBlockList = (List<FoamBlock>) null;
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
    {
      if (this.activeFoam.BlockXZ == null)
        this.activeFoam.BlockXZ = new List<FoamBlock>();
      foamBlockList = this.activeFoam.BlockXZ;
    }
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
    {
      if (this.activeFoam.BlockYZ == null)
        this.activeFoam.BlockYZ = new List<FoamBlock>();
      foamBlockList = this.activeFoam.BlockYZ;
    }
    this.varCalc.BlockTrimedWidth = RunSettings.BlockWidth - RunSettings.PatternWidthStartOffset - RunSettings.PatternWidthEndOffset;
    this.varCalc.BlockTrimedHeight = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset - RunSettings.PatternHeightEndOffset;
    if (buFoamCalc.varFoamRunSettings.WaveFormRepeatCount <= 0)
      buFoamCalc.varFoamRunSettings.WaveFormRepeatCount = 1;
    if (this.varCalc.PatternWidth != 0.0)
    {
      this.varCalc.XRatio = Math.Round(this.varCalc.BlockTrimedWidth / this.varCalc.PatternWidth, 5);
      if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
        this.varCalc.XRatio = Math.Round(this.varCalc.BlockTrimedWidth / (this.varCalc.PatternWidth * (double) buFoamCalc.varFoamRunSettings.WaveFormRepeatCount), 5);
    }
    this.varCalc.YRatio = Math.Round(this.varCalc.BlockTrimedHeight / this.varCalc.PatternHeight, 5);
    if (RunSettings.TypeFoam == FoamType.FromDrawing)
    {
      if (this.varCalc.PatternWidth != 0.0)
        this.varCalc.XRatio = Math.Round(this.varCalc.BlockTrimedWidth / this.varCalc.PatternWidth, 5);
      this.varCalc.YRatio = Math.Round(this.varCalc.BlockTrimedHeight / this.varCalc.PatternHeight, 5);
    }
    if (this.varCalc.XRatio < 1.0)
      this.varCalc.XRatio = 1.0;
    if (this.varCalc.YRatio < 1.0)
      this.varCalc.YRatio = 1.0;
    this.varCalc.XCountActual = (int) buNumeric5.RoundToLower(this.varCalc.XRatio);
    this.varCalc.YCountActual = (int) buNumeric5.RoundToLower(this.varCalc.YRatio);
    if (this.varCalc.PatternWidth != 0.0)
      this.varCalc.XMax = (double) (int) buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitX / this.varCalc.PatternWidth);
    this.varCalc.YMax = (double) (int) buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitZ / this.varCalc.PatternHeight);
    if (this.activePattern.planeName == FoamPlaneType.YZ && this.varCalc.PatternWidth != 0.0)
      this.int_3 = (int) buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitY / this.varCalc.PatternWidth);
    this.varCalc.BlockIdealWidth = Math.Round(this.varCalc.PatternWidth * (double) this.varCalc.XCountActual - buFoamCalc.varFoamSettings.PatternDistancesWidth, 3);
    this.varCalc.BlockIdealHeight = Math.Round(this.varCalc.PatternHeight * (double) this.varCalc.YCountActual - buFoamCalc.varFoamSettings.PatternDistancesHeight, 3);
    if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
    {
      this.varCalc.BlockIdealWidth = Math.Round(this.varCalc.PatternWidth * (double) this.varCalc.XCountActual * (double) buFoamCalc.varFoamRunSettings.WaveFormRepeatCount - buFoamCalc.varFoamSettings.PatternDistancesWidth, 3);
      this.varCalc.BlockIdealHeight = Math.Round(this.varCalc.PatternHeight * (double) this.varCalc.YCountActual - buFoamCalc.varFoamRunSettings.WaveFormSpace, 3);
    }
    if (!Edit)
      this.activeBlock.BottomZ = buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown ? (foamBlockList.Count <= 0 ? RunSettings.PatternHeightEndOffset : foamBlockList[foamBlockList.Count - 1].TopZ + RunSettings.PatternHeightStartOffset) : (foamBlockList.Count <= 0 ? this.activeFoam.Material.Size.Depth - RunSettings.PatternHeightStartOffset : foamBlockList[foamBlockList.Count - 1].BottomZ - RunSettings.PatternHeightStartOffset);
    if (!Edit)
    {
      AppBool.Calculation = true;
      if (this.frmPattern != null & RunSettings.Operation == FoamOperationType.Pattern)
      {
        this.frmPattern.spn_blockhorcount.Value = (Decimal) this.varCalc.XCountActual;
        this.frmPattern.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
        this.frmPattern.spn_totalpart.Value = (Decimal) (this.varCalc.XCountActual * this.varCalc.YCountActual);
      }
      if (this.frmWave != null & RunSettings.Operation == FoamOperationType.Wave)
      {
        this.frmWave.spn_blockhorcount.Value = (Decimal) this.varCalc.XCountActual;
        this.frmWave.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
        this.frmWave.spn_totalpart.Value = (Decimal) (this.varCalc.XCountActual * this.varCalc.YCountActual);
      }
      if (this.frmSlice != null & RunSettings.Operation == FoamOperationType.Slice)
      {
        this.frmSlice.spn_blockhorcount.Value = (Decimal) this.varCalc.XCountActual;
        this.frmSlice.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
        this.frmSlice.spn_totalpart.Value = (Decimal) (this.varCalc.XCountActual * this.varCalc.YCountActual);
      }
      AppBool.Calculation = false;
    }
    this.varCalc.ZOffset += this.activeBlock.BottomZ;
  }

  public void doOperationSizeCalcVer(ref FoamRuntimeSettings RunSettings, bool Edit = false)
  {
    if (this.activeBlock == null)
      this.activeBlock = new FoamBlock();
    List<FoamBlock> foamBlockList = (List<FoamBlock>) null;
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
    {
      if (this.activeFoam.BlockXZ == null)
        this.activeFoam.BlockXZ = new List<FoamBlock>();
      foamBlockList = this.activeFoam.BlockXZ;
    }
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
    {
      if (this.activeFoam.BlockYZ == null)
        this.activeFoam.BlockYZ = new List<FoamBlock>();
      foamBlockList = this.activeFoam.BlockYZ;
    }
    if (!Edit)
      this.activeBlock.LeftMin = foamBlockList.Count <= 0 ? RunSettings.PatternWidthStartOffset : foamBlockList[foamBlockList.Count - 1].LeftMax + buFoamCalc.varFoamSettings.BlockSpace;
    this.varCalc.BlockTrimedWidth = RunSettings.BlockWidth - RunSettings.PatternWidthStartOffset - RunSettings.PatternWidthEndOffset;
    this.varCalc.BlockTrimedHeight = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset - RunSettings.PatternHeightEndOffset;
    if (this.varCalc.PatternWidth != 0.0)
      this.varCalc.XRatio = Math.Round(this.varCalc.BlockTrimedWidth / this.varCalc.PatternWidth, 5);
    if (this.varCalc.PatternHeight != 0.0)
      this.varCalc.YRatio = Math.Round(this.varCalc.BlockTrimedHeight / this.varCalc.PatternHeight, 5);
    if (RunSettings.TypeFoam == FoamType.FromDrawing)
    {
      if (this.varCalc.PatternWidth != 0.0)
        this.varCalc.XRatio = Math.Round(this.varCalc.BlockTrimedWidth / this.varCalc.PatternWidth, 5);
      if (this.varCalc.PatternHeight != 0.0)
        this.varCalc.YRatio = Math.Round(this.varCalc.BlockTrimedHeight / this.varCalc.PatternHeight, 5);
    }
    if (this.varCalc.XRatio < 1.0)
      this.varCalc.XRatio = 1.0;
    if (this.varCalc.YRatio < 1.0)
      this.varCalc.YRatio = 1.0;
    this.varCalc.XCountActual = (int) buNumeric5.RoundToLower(this.varCalc.XRatio);
    this.varCalc.YCountActual = (int) buNumeric5.RoundToLower(this.varCalc.YRatio);
    if (this.varCalc.PatternWidth != 0.0)
      this.varCalc.XMax = (double) (int) buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitX / this.varCalc.PatternWidth);
    if (this.varCalc.PatternHeight != 0.0)
      this.varCalc.YMax = (double) (int) buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitZ / this.varCalc.PatternHeight);
    if (this.activePattern.planeName == FoamPlaneType.YZ && this.varCalc.PatternWidth != 0.0)
      this.varCalc.XMax = (double) (int) buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitY / this.varCalc.PatternWidth);
    this.varCalc.BlockIdealWidth = Math.Round(this.varCalc.PatternWidth * (double) this.varCalc.XCountActual - buFoamCalc.varFoamSettings.PatternDistancesWidth, 3);
    this.varCalc.BlockIdealHeight = Math.Round(this.varCalc.PatternHeight * (double) this.varCalc.YCountActual - buFoamCalc.varFoamSettings.PatternDistancesHeight, 3);
    if (!Edit)
      ;
    if (!Edit)
    {
      if (this.frmPattern != null & RunSettings.Operation == FoamOperationType.Pattern)
      {
        this.frmPattern.spn_blockhorcount.Value = (Decimal) this.varCalc.XCountActual;
        this.frmPattern.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
        this.frmPattern.spn_totalpart.Value = (Decimal) (this.varCalc.XCountActual * this.varCalc.YCountActual);
      }
      if (this.frmWave != null & RunSettings.Operation == FoamOperationType.Wave)
      {
        this.frmWave.spn_blockhorcount.Value = (Decimal) this.varCalc.XCountActual;
        this.frmWave.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
        this.frmWave.spn_totalpart.Value = (Decimal) (this.varCalc.XCountActual * this.varCalc.YCountActual);
      }
      if (this.frmSlice != null & RunSettings.Operation == FoamOperationType.Slice)
      {
        this.frmSlice.spn_blockhorcount.Value = (Decimal) this.varCalc.XCountActual;
        this.frmSlice.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
        this.frmSlice.spn_totalpart.Value = (Decimal) (this.varCalc.XCountActual * this.varCalc.YCountActual);
      }
    }
    this.varCalc.XOffset += this.activeBlock.LeftMin;
  }

  public void doCalculatePattern(
    FoamRuntimeSettings RunSettings,
    bool Finished,
    ref List<FoamPattern> FoamPatterns,
    bool Edit = false)
  {
    this.varCalc.PatternWidth = RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth;
    this.varCalc.PatternHeight = RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
    this.varCalc.ZOffset = 0.0;
    this.doOperationSizeCalcHor(ref RunSettings, Edit);
    FoamPatterns = new List<FoamPattern>();
    this.frmPattern.lst_idealwidth.Items.Clear();
    this.frmPattern.lst_idealheight.Items.Clear();
    for (double num = 1.0; num <= this.varCalc.XMax; ++num)
      this.frmPattern.lst_idealwidth.Items.Add((object) Math.Round(RunSettings.PatternWidth * num + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + Convert.ToDouble(num - 0.0) * buFoamCalc.varFoamSettings.PatternDistancesWidth, 3));
    for (double num = 1.0; num <= this.varCalc.YMax; ++num)
      this.frmPattern.lst_idealheight.Items.Add((object) Math.Round(RunSettings.PatternHeight * num + RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + Convert.ToDouble(num - 0.0) * buFoamCalc.varFoamSettings.PatternDistancesHeight, 3));
    this.frmPattern.lst_idealwidth.Text = this.varCalc.BlockIdealWidth.ToString();
    this.frmPattern.lst_idealheight.Text = this.varCalc.BlockIdealHeight.ToString();
    ccVars.pntDrawDynamicLinesArr.Clear();
    ccVars.pntDrawDynamicLinesArrColored.Clear();
    if (this.activePattern == null)
      return;
    List<Point3D> point3DList = new List<Point3D>();
    List<buEntity> refEntities1 = new List<buEntity>();
    List<buEntity> refEntities2 = new List<buEntity>();
    clsInit.cFoamCut.FoamEntitiesToEntities(this.activePattern.foamEntities, ref refEntities1);
    if (this.activePattern.planeName == FoamPlaneType.XZ | this.activePattern.planeName == FoamPlaneType.YZ)
    {
      if (this.activePattern.planeName == FoamPlaneType.XZ)
      {
        clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref refEntities1);
        if (Finished)
        {
          buEntity.Copy(this.activePattern.sortEntities, ref refEntities2);
          clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref refEntities2);
          clsInit.cFoamCut.FoamEntitiesRotate(90.0, Vector3D.AxisX, ref this.activePattern.foamEntities);
        }
      }
      if (this.activePattern.planeName == FoamPlaneType.YZ)
      {
        clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref refEntities1);
        clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisZ, ref refEntities1);
        if (Finished)
        {
          buEntity.Copy(this.activePattern.sortEntities, ref refEntities2);
          clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref refEntities2);
          clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisZ, ref refEntities2);
          clsInit.cFoamCut.FoamEntitiesRotate(90.0, Vector3D.AxisX, ref this.activePattern.foamEntities);
          clsInit.cFoamCut.FoamEntitiesRotate(90.0, Vector3D.AxisZ, ref this.activePattern.foamEntities);
        }
      }
      this.activeBlock.BlockName = RunSettings.BlockName;
      this.activeBlock.MinPoint = new Point3D(0.0, 0.0, this.activeBlock.BottomZ);
      this.activeBlock.SizeObj = new SizeObject(this.activeBlock.MaxPoint.X - this.activeBlock.MinPoint.X, this.activeBlock.MaxPoint.Y - this.activeBlock.MinPoint.Y, this.activeBlock.MaxPoint.Z - this.activeBlock.MinPoint.Z);
      List<PointRGB> pointRgbList = new List<PointRGB>();
      double z1;
      double z2;
      if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
      {
        z1 = this.varCalc.ZOffset + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
        z2 = this.varCalc.ZOffset - this.varCalc.BlockIdealHeight - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
        this.activeBlock.TopZ = this.varCalc.ZOffset;
        this.activeBlock.BottomZ = this.varCalc.ZOffset - this.varCalc.BlockIdealHeight;
      }
      else
      {
        z1 = this.varCalc.ZOffset + this.varCalc.BlockIdealHeight + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
        z2 = this.varCalc.ZOffset - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
        this.activeBlock.TopZ = this.varCalc.ZOffset + this.varCalc.BlockIdealHeight;
        this.activeBlock.BottomZ = this.varCalc.ZOffset;
      }
      if (this.activePattern.planeName == FoamPlaneType.XZ)
      {
        this.activeBlock.MaxPoint = new Point3D(this.varCalc.BlockIdealWidth, this.activeFoam.Material.Size.Height, this.activeBlock.BottomZ + this.varCalc.BlockIdealHeight);
        pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
        pointRgbList.Add(new PointRGB(this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, z1, Color.Lime));
        pointRgbList.Add(new PointRGB(this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, z2, Color.Lime));
        pointRgbList.Add(new PointRGB(0.0, 0.0, z2, Color.Lime));
        pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
      }
      if (this.activePattern.planeName == FoamPlaneType.YZ)
      {
        this.activeBlock.MaxPoint = new Point3D(this.activeFoam.Material.Size.Width, this.varCalc.BlockIdealWidth, this.activeBlock.BottomZ + this.varCalc.BlockIdealHeight);
        pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
        pointRgbList.Add(new PointRGB(0.0, this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, z1, Color.Lime));
        pointRgbList.Add(new PointRGB(0.0, this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, z2, Color.Lime));
        pointRgbList.Add(new PointRGB(0.0, 0.0, z2, Color.Lime));
        pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
      }
      ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList);
      if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
      {
        for (double num1 = (double) (this.varCalc.YCountActual - 1); num1 >= 0.0; --num1)
        {
          double num2 = 0.0;
          if (num1 == (double) (this.varCalc.YCountActual - 1))
            num2 = buFoamCalc.varFoamSettings.PatternDistancesHeight;
          this.varCalc.ZOffset -= RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight - num2;
          for (double num3 = 0.0; num3 <= (double) (this.varCalc.XCountActual - 1); ++num3)
          {
            List<buEntity> buEntityList = new List<buEntity>();
            buEntity.Copy(refEntities1, ref buEntityList);
            if (num1 % 2.0 == 1.0 && RunSettings.PatternMirrorX | RunSettings.PatternMirrorY)
              clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, this.activePattern.planeName, ref buEntityList);
            double num4 = 0.0;
            double dY = 0.0;
            if (this.activePattern.planeName == FoamPlaneType.XZ)
              num4 = RunSettings.PatternWidthStartOffset + num3 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
            if (this.activePattern.planeName == FoamPlaneType.YZ)
              dY = RunSettings.PatternWidthStartOffset + num3 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
            double num5 = 0.0;
            num5 = RunSettings.PatternMirrorY ? (num1 % 2.0 != 1.0 ? num1 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight) : num1 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight)) : num1 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
            double num6 = 0.0;
            if (!Finished)
            {
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                clsInit.cVector5.Move(num4, 0.0, num6 + this.varCalc.ZOffset, ref buEntityList);
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                clsInit.cVector5.Move(0.0, dY, num6 + this.varCalc.ZOffset, ref buEntityList);
              for (int index = 0; index <= buEntityList.Count - 1; ++index)
              {
                List<Point3D> copiedPoint = new List<Point3D>();
                buVector5.Copy(buEntityList[index].Vertices, ref copiedPoint);
                ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
              }
            }
            else
            {
              FoamPattern Pattern = new FoamPattern();
              FoamEntities.Copy(this.activePattern.foamEntities, ref Pattern.foamEntities);
              buEntity.Copy(refEntities2, ref Pattern.sortEntities);
              if (num1 % 2.0 == 1.0 && RunSettings.PatternMirrorX | RunSettings.PatternMirrorY)
              {
                clsInit.cFoamCut.FoamEntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, this.activePattern.planeName, ref Pattern.foamEntities);
                clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, this.activePattern.planeName, ref Pattern.sortEntities);
                if (RunSettings.PatternMirrorX)
                  clsInit.cVector5.ChangeEntitiesDirection(ref Pattern.sortEntities);
              }
              clsInit.cVector5.Move(num4, 0.0, num6 + this.varCalc.ZOffset, ref Pattern.sortEntities);
              clsInit.cFoamCut.FoamEntitiesMove(num4, 0.0, num6 + this.varCalc.ZOffset, ref Pattern.foamEntities);
              clsInit.cFoamCut.FoamEntitiesBoxSize(Pattern.foamEntities, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
              Pattern.Type = FoamType.Pattern;
              Pattern.GroupType = FoamOperationType.Pattern;
              Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
              Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
              Pattern.Offset = new Point3D(num4, 0.0, num6 + this.varCalc.ZOffset);
              Pattern.HorizontalIndex = Convert.ToInt32(num3);
              Pattern.VerticalIndex = Convert.ToInt32(num1);
              if (buFoamCalc.varFoamSettings.Draw3D)
                clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, this.activePattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
              FoamPatterns.Add(Pattern);
            }
          }
        }
      }
      else
      {
        for (double num7 = 0.0; num7 <= (double) (this.varCalc.YCountActual - 1); ++num7)
        {
          double num8 = 0.0;
          if (num7 > 0.0)
            num8 = RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
          this.varCalc.ZOffset += num8;
          for (double num9 = 0.0; num9 <= (double) (this.varCalc.XCountActual - 1); ++num9)
          {
            List<buEntity> buEntityList = new List<buEntity>();
            buEntity.Copy(refEntities1, ref buEntityList);
            if (num7 % 2.0 == 1.0 && RunSettings.PatternMirrorX | RunSettings.PatternMirrorY)
              clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, this.activePattern.planeName, ref buEntityList);
            double num10 = 0.0;
            double dY = 0.0;
            if (this.activePattern.planeName == FoamPlaneType.XZ)
              num10 = RunSettings.PatternWidthStartOffset + num9 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
            if (this.activePattern.planeName == FoamPlaneType.YZ)
              dY = RunSettings.PatternWidthStartOffset + num9 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
            double num11 = 0.0;
            num11 = RunSettings.PatternMirrorY ? (num7 % 2.0 != 1.0 ? num7 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight) : num7 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight)) : num7 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
            double num12 = 0.0;
            if (!Finished)
            {
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                clsInit.cVector5.Move(num10, 0.0, num12 + this.varCalc.ZOffset, ref buEntityList);
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                clsInit.cVector5.Move(0.0, dY, num12 + this.varCalc.ZOffset, ref buEntityList);
              for (int index = 0; index <= buEntityList.Count - 1; ++index)
              {
                List<Point3D> copiedPoint = new List<Point3D>();
                buVector5.Copy(buEntityList[index].Vertices, ref copiedPoint);
                ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
              }
            }
            else
            {
              FoamPattern Pattern = new FoamPattern();
              FoamEntities.Copy(this.activePattern.foamEntities, ref Pattern.foamEntities);
              buEntity.Copy(refEntities2, ref Pattern.sortEntities);
              if (num7 % 2.0 == 1.0 && RunSettings.PatternMirrorX | RunSettings.PatternMirrorY)
              {
                clsInit.cFoamCut.FoamEntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, this.activePattern.planeName, ref Pattern.foamEntities);
                clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, this.activePattern.planeName, ref Pattern.sortEntities);
                if (RunSettings.PatternMirrorX)
                  clsInit.cVector5.ChangeEntitiesDirection(ref Pattern.sortEntities);
              }
              clsInit.cVector5.Move(num10, 0.0, num12 + this.varCalc.ZOffset, ref Pattern.sortEntities);
              clsInit.cFoamCut.FoamEntitiesMove(num10, 0.0, num12 + this.varCalc.ZOffset, ref Pattern.foamEntities);
              clsInit.cFoamCut.FoamEntitiesBoxSize(Pattern.foamEntities, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
              Pattern.Type = FoamType.Pattern;
              Pattern.GroupType = FoamOperationType.Pattern;
              Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
              Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
              Pattern.Offset = new Point3D(num10, 0.0, num12 + this.varCalc.ZOffset);
              Pattern.HorizontalIndex = Convert.ToInt32(num9);
              Pattern.VerticalIndex = Convert.ToInt32(num7);
              if (buFoamCalc.varFoamSettings.Draw3D)
                clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, this.activePattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
              FoamPatterns.Add(Pattern);
            }
          }
        }
      }
    }
    this.activePattern.Info.TotalArea = 0.0;
    this.activePattern.Info.TotalCuttingLength = 0.0;
    clsInit.cVector5.BoxSizeCalculate(refEntities1, ref this.activePattern.BoxMinItem, ref this.activePattern.BoxMaxItem);
    for (int index = 0; index <= this.activePattern.foamEntities.Count - 1; ++index)
    {
      List<Point3D> Points = new List<Point3D>();
      clsInit.cVector5.EntitiesToPointsWithCamDirection(this.activePattern.foamEntities[index].GroupEntity.Outside.Entities, ref Points);
      this.activePattern.Info.TotalArea += clsInit.cVector5.PolygonArea(Points, Plane.XY);
      this.activePattern.Info.TotalCuttingLength += clsInit.cVector5.Length3D(Points);
    }
    if (this.activePattern.planeName == FoamPlaneType.XZ)
      this.activePattern.Info.BoxArea = Math.Round((this.activePattern.BoxMaxItem.X - this.activePattern.BoxMinItem.X) * (this.activePattern.BoxMaxItem.Z - this.activePattern.BoxMinItem.Z), 3);
    if (this.activePattern.planeName == FoamPlaneType.YZ)
      this.activePattern.Info.BoxArea = Math.Round((this.activePattern.BoxMaxItem.Y - this.activePattern.BoxMinItem.Y) * (this.activePattern.BoxMaxItem.Z - this.activePattern.BoxMinItem.Z), 3);
    if (this.activePattern.Info.BoxArea > 0.0)
      this.activePattern.Info.UsedPersentageFromBoxArea = Math.Round(this.activePattern.Info.TotalArea / this.activePattern.Info.BoxArea * 100.0, 3);
    if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
      this.activePattern.Info.TimeCutting = Math.Round(this.activePattern.Info.TotalCuttingLength / buFoamCalc.varFoamSettings.CuttingFeed, 3);
    if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
      this.activePattern.Info.TimeCutting = Math.Round(this.activePattern.Info.TotalCuttingLength / buFoamCalc.varFoamSettings.CuttingFeed * 60.0, 3);
    string Info = "";
    clsInit.cFoamCut.PatternInfo(this.activePattern, this.activeFoam.Material.Size, (double) this.varCalc.XCountActual, (double) this.varCalc.YCountActual, buFoamCalc.varFoamSettings, RunSettings, ref Info);
    this.frmPattern.txt_info.Text = Info;
  }

  public void doCalculateWaveShape(
    FoamRuntimeSettings RunSettings,
    bool Finished,
    FoamType Type,
    ref List<FoamPattern> FoamPatterns,
    bool Edit = false)
  {
    FoamPatterns = new List<FoamPattern>();
    if (RunSettings.WaveFormShapeCommonBaseHeight <= RunSettings.WaveFormShapeCommonHeight)
      RunSettings.WaveFormShapeCommonBaseHeight = RunSettings.WaveFormShapeCommonHeight * 2.0;
    this.frmWave.lst_idealwidth.Items.Clear();
    this.frmWave.lst_idealheight.Items.Clear();
    double num1 = 2.0 * RunSettings.WaveFormShapeCommonBaseHeight;
    double zPos = RunSettings.WaveFormShapeCommonBaseHeight;
    if (Type == FoamType.VForm | Type == FoamType.CForm)
    {
      num1 = 2.0 * RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight + RunSettings.WaveFormSpace;
      zPos = RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight;
    }
    if (Type == FoamType.ZForm | Type == FoamType.SForm)
    {
      num1 = 2.0 * RunSettings.WaveFormShapeCommonBaseHeight + RunSettings.WaveFormSpace;
      zPos = (num1 - RunSettings.WaveFormSpace) / 2.0;
    }
    if (Type == FoamType.Pyramid)
    {
      num1 = RunSettings.WaveFormShapeCommonBaseHeight + (RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight) + RunSettings.WaveFormSpace;
      zPos = RunSettings.WaveFormShapeCommonBaseHeight;
    }
    if (Type == FoamType.Rectangle | Type == FoamType.UForm)
    {
      num1 = RunSettings.WaveFormShapeCommonBaseHeight + (RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight) + RunSettings.WaveFormSpace;
      zPos = RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight;
    }
    this.varCalc.PatternWidth = RunSettings.WaveFormShapeCommonWidth;
    this.varCalc.PatternHeight = num1;
    this.varCalc.ZOffset = 0.0;
    this.doOperationSizeCalcHor(ref RunSettings, Edit);
    int repeatCount = 1;
    double num2;
    if (RunSettings.WaveFormRepeatCount > 0)
    {
      double num3 = (double) RunSettings.WaveFormRepeatCount * RunSettings.WaveFormShapeCommonWidth;
      repeatCount = (int) buNumeric5.RoundToLower(this.varCalc.BlockTrimedWidth / num3);
      this.int_1 = RunSettings.WaveFormRepeatCount;
      this.frmWave.lst_idealwidth.Items.Add((object) (RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double) (repeatCount - 2)).ToString("f1"));
      this.frmWave.lst_idealwidth.Items.Add((object) (RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double) (repeatCount - 1)).ToString("f1"));
      this.frmWave.lst_idealwidth.Items.Add((object) (RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double) repeatCount).ToString("f1"));
      this.frmWave.lst_idealwidth.Items.Add((object) (RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double) (repeatCount + 1)).ToString("f1"));
      this.frmWave.lst_idealwidth.Items.Add((object) (RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double) (repeatCount + 2)).ToString("f1"));
    }
    else
    {
      this.int_1 = this.varCalc.XCountActual - 1;
      ListBox.ObjectCollection items1 = this.frmWave.lst_idealwidth.Items;
      num2 = RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double) (this.int_1 - 2);
      string str1 = num2.ToString("f1");
      items1.Add((object) str1);
      ListBox.ObjectCollection items2 = this.frmWave.lst_idealwidth.Items;
      num2 = RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double) (this.int_1 - 1);
      string str2 = num2.ToString("f1");
      items2.Add((object) str2);
      ListBox.ObjectCollection items3 = this.frmWave.lst_idealwidth.Items;
      num2 = RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double) this.int_1;
      string str3 = num2.ToString("f1");
      items3.Add((object) str3);
      ListBox.ObjectCollection items4 = this.frmWave.lst_idealwidth.Items;
      num2 = RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double) (this.int_1 + 1);
      string str4 = num2.ToString("f1");
      items4.Add((object) str4);
      ListBox.ObjectCollection items5 = this.frmWave.lst_idealwidth.Items;
      num2 = RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double) (this.int_1 + 2);
      string str5 = num2.ToString("f1");
      items5.Add((object) str5);
    }
    ListBox.ObjectCollection items6 = this.frmWave.lst_idealheight.Items;
    num2 = RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double) (this.varCalc.YCountActual - 2);
    string str6 = num2.ToString("f1");
    items6.Add((object) str6);
    ListBox.ObjectCollection items7 = this.frmWave.lst_idealheight.Items;
    num2 = RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double) (this.varCalc.YCountActual - 1);
    string str7 = num2.ToString("f1");
    items7.Add((object) str7);
    ListBox.ObjectCollection items8 = this.frmWave.lst_idealheight.Items;
    num2 = RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double) this.varCalc.YCountActual;
    string str8 = num2.ToString("f1");
    items8.Add((object) str8);
    ListBox.ObjectCollection items9 = this.frmWave.lst_idealheight.Items;
    num2 = RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double) (this.varCalc.YCountActual + 1);
    string str9 = num2.ToString("f1");
    items9.Add((object) str9);
    ListBox.ObjectCollection items10 = this.frmWave.lst_idealheight.Items;
    num2 = RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double) (this.varCalc.YCountActual + 2);
    string str10 = num2.ToString("f1");
    items10.Add((object) str10);
    FoamPatterns = new List<FoamPattern>();
    this.frmWave.spn_blockhorcount.Value = (Decimal) repeatCount;
    this.frmWave.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
    this.frmWave.spn_totalpart.Value = (Decimal) (repeatCount * this.int_2);
    ccVars.pntDrawDynamicLinesArr.Clear();
    ccVars.pntDrawDynamicLinesArrColored.Clear();
    if (this.activePattern == null)
      return;
    List<Point3D> point3DList1 = new List<Point3D>();
    List<PointRGB> pointRgbList = new List<PointRGB>();
    double z1;
    double z2;
    if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
    {
      z1 = this.varCalc.ZOffset + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
      z2 = this.varCalc.ZOffset - this.varCalc.BlockIdealHeight - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
    }
    else
    {
      z1 = this.varCalc.ZOffset + this.varCalc.BlockIdealHeight + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
      z2 = this.varCalc.ZOffset - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
    }
    if (this.activePattern.planeName == FoamPlaneType.XZ)
    {
      pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
      pointRgbList.Add(new PointRGB(this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, z1, Color.Lime));
      pointRgbList.Add(new PointRGB(this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, z2, Color.Lime));
      pointRgbList.Add(new PointRGB(0.0, 0.0, z2, Color.Lime));
      pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
      ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList);
      Point3D MidPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref this.activeBlock.MinPoint, ref MidPoint, ref this.activeBlock.MaxPoint);
      this.activeBlock.MinPoint.Y = 0.0;
      this.activeBlock.MaxPoint.Y = this.activeFoam.Material.Size.Height;
    }
    if (this.activePattern.planeName == FoamPlaneType.YZ)
    {
      pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
      pointRgbList.Add(new PointRGB(0.0, this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, z1, Color.Lime));
      pointRgbList.Add(new PointRGB(0.0, this.varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, z2, Color.Lime));
      pointRgbList.Add(new PointRGB(0.0, 0.0, z2, Color.Lime));
      pointRgbList.Add(new PointRGB(0.0, 0.0, z1, Color.Lime));
      ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList);
      Point3D MidPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref this.activeBlock.MinPoint, ref MidPoint, ref this.activeBlock.MaxPoint);
      this.activeBlock.MinPoint.X = 0.0;
      this.activeBlock.MaxPoint.X = this.activeFoam.Material.Size.Width;
    }
    if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
    {
      this.activeBlock.TopZ = this.varCalc.ZOffset;
      this.activeBlock.BottomZ = this.varCalc.ZOffset - this.varCalc.BlockIdealHeight;
    }
    else
    {
      this.activeBlock.TopZ = this.varCalc.ZOffset + this.varCalc.BlockIdealHeight;
      this.activeBlock.BottomZ = this.varCalc.ZOffset;
    }
    this.activeBlock.BlockName = RunSettings.BlockName;
    this.activeBlock.SizeObj = new SizeObject(this.activeBlock.MaxPoint.X - this.activeBlock.MinPoint.X, this.activeBlock.MaxPoint.Y - this.activeBlock.MinPoint.Y, this.activeBlock.MaxPoint.Z - this.activeBlock.MinPoint.Z);
    if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
    {
      for (double num4 = (double) (this.varCalc.YCountActual - 1); num4 >= 0.0; --num4)
      {
        double num5 = 0.0;
        if (num4 == (double) (this.varCalc.YCountActual - 1))
          num5 = buFoamCalc.varFoamRunSettings.WaveFormSpace;
        this.varCalc.ZOffset -= num1 - num5;
        List<Point3D> point3DList2 = new List<Point3D>();
        List<FoamPattern> calcPatterns = new List<FoamPattern>();
        FoamWaveShapeArgs Args = new FoamWaveShapeArgs(RunSettings.PatternWidthStartOffset, zPos, RunSettings.WaveFormShapeCommonHeight, RunSettings.WaveFormShapeCommonWidth, RunSettings.WaveFormShapeCommonBaseHeight, this.int_1, repeatCount, this.varCalc.ZOffset, buFoamCalc.varFoamSettings.CuttingFeed, RunSettings.WaveFormShapeCommonRoundRad, RunSettings.WaveFormShapeCommonChamferLen, buFoamCalc.varFoamRunSettings.planeNames, this.activeFoam.Material.Size);
        if (Type == FoamType.Pyramid)
          clsInit.cFoamCut.WavePyramitShape(Args, Type, ref calcPatterns);
        else if (Type == FoamType.Rectangle | Type == FoamType.UForm)
          clsInit.cFoamCut.WavePyramitShape(Args, Type, ref calcPatterns);
        else
          clsInit.cFoamCut.WaveTypeShape(Args, Type, ref calcPatterns);
        for (int index1 = 0; index1 <= calcPatterns.Count - 1; ++index1)
        {
          FoamPattern Pattern = calcPatterns[index1];
          calcPatterns[index1].VerticalIndex = (int) num4;
          calcPatterns[index1].HorizontalIndex = index1;
          for (int index2 = 0; index2 <= calcPatterns[index1].foamEntities.Count - 1; ++index2)
          {
            List<Point3D> Points = new List<Point3D>();
            clsInit.cVector5.EntitiesToPointsWithCamDirection(calcPatterns[index1].foamEntities[index2].GroupEntity.Outside.Entities, ref Points);
            ccVars.pntDrawDynamicLinesArr.Add(Points);
          }
          FoamPatterns.Add(calcPatterns[index1]);
          if (Finished && buFoamCalc.varFoamSettings.Draw3D)
            clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, this.activePattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
        }
      }
      this.varCalc.ZOffset = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset;
    }
    else
    {
      for (double num6 = 0.0; num6 <= (double) (this.varCalc.YCountActual - 1); ++num6)
      {
        double num7 = 0.0;
        if (num6 > 0.0)
          num7 = num1;
        this.varCalc.ZOffset += num7;
        List<Point3D> point3DList3 = new List<Point3D>();
        List<FoamPattern> calcPatterns = new List<FoamPattern>();
        FoamWaveShapeArgs Args = new FoamWaveShapeArgs(RunSettings.PatternWidthStartOffset, zPos, RunSettings.WaveFormShapeCommonHeight, RunSettings.WaveFormShapeCommonWidth, RunSettings.WaveFormShapeCommonBaseHeight, this.int_1, repeatCount, this.varCalc.ZOffset, buFoamCalc.varFoamSettings.CuttingFeed, RunSettings.WaveFormShapeCommonRoundRad, RunSettings.WaveFormShapeCommonChamferLen, buFoamCalc.varFoamRunSettings.planeNames, this.activeFoam.Material.Size);
        if (Type == FoamType.Pyramid)
          clsInit.cFoamCut.WavePyramitShape(Args, Type, ref calcPatterns);
        else if (Type == FoamType.Rectangle | Type == FoamType.UForm)
          clsInit.cFoamCut.WavePyramitShape(Args, Type, ref calcPatterns);
        else
          clsInit.cFoamCut.WaveTypeShape(Args, Type, ref calcPatterns);
        for (int index3 = 0; index3 <= calcPatterns.Count - 1; ++index3)
        {
          FoamPattern Pattern = calcPatterns[index3];
          calcPatterns[index3].VerticalIndex = (int) num6;
          calcPatterns[index3].HorizontalIndex = index3;
          for (int index4 = 0; index4 <= calcPatterns[index3].foamEntities.Count - 1; ++index4)
          {
            List<Point3D> Points = new List<Point3D>();
            clsInit.cVector5.EntitiesToPointsWithCamDirection(calcPatterns[index3].foamEntities[index4].GroupEntity.Outside.Entities, ref Points);
            ccVars.pntDrawDynamicLinesArr.Add(Points);
          }
          FoamPatterns.Add(calcPatterns[index3]);
          if (Finished && buFoamCalc.varFoamSettings.Draw3D)
            clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, this.activePattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
        }
      }
      this.varCalc.ZOffset = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset;
    }
    string Info = "";
    clsInit.cFoamCut.PatternInfo(FoamPatterns, this.activeFoam.Material.Size, buFoamCalc.varFoamSettings, RunSettings, ref Info);
    this.frmWave.txt_info.Text = Info;
  }

  public void doCalculateSlicesHorizontal(
    FoamRuntimeSettings RunSettings,
    bool Finished,
    FoamType Type,
    ref List<FoamPattern> FoamPatterns,
    bool Edit = false)
  {
    AppBool.Calculation = true;
    this.varCalc.PatternHeight = RunSettings.SlicesHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
    this.varCalc.ZOffset = 0.0;
    this.doOperationSizeCalcHor(ref RunSettings, Edit);
    FoamPatterns = new List<FoamPattern>();
    AppBool.Calculation = true;
    this.frmSlice.spn_blockvercount.Value = (Decimal) this.varCalc.YCountActual;
    this.frmSlice.spn_blockhorcount.Value = 1M;
    this.frmSlice.spn_totalpart.Value = (Decimal) this.varCalc.YCountActual;
    AppBool.Calculation = false;
    ccVars.pntDrawDynamicLinesArr.Clear();
    ccVars.pntDrawDynamicLinesArrColored.Clear();
    if (this.activePattern != null)
    {
      List<Point3D> point3DList = new List<Point3D>();
      if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
      {
        if (this.activePattern.planeName == FoamPlaneType.XZ | this.activePattern.planeName == FoamPlaneType.YZ)
        {
          this.activeBlock.TopZ = this.varCalc.ZOffset;
          this.activeBlock.BottomZ = this.varCalc.ZOffset - this.varCalc.BlockIdealHeight;
          for (double num = (double) (this.varCalc.YCountActual - 1); num >= 0.0; --num)
          {
            List<Point3D> points = new List<Point3D>();
            List<Point3D> Points;
            if (num == (double) (this.varCalc.YCountActual - 1))
            {
              Points = new List<Point3D>();
              Points.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                Points.Add(new Point3D(RunSettings.BlockWidth, 0.0, this.varCalc.ZOffset));
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                Points.Add(new Point3D(0.0, RunSettings.BlockWidth, this.varCalc.ZOffset));
              ccVars.pntDrawDynamicLinesArr.Add(Points);
              if (Finished)
              {
                FoamPattern foamPattern = new FoamPattern();
                buLine buLine = (buLine) null;
                if (this.activePattern.planeName == FoamPlaneType.XZ)
                  buLine = new buLine(new Point3D(Points[0].X - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Y, Points[0].Z), Points[0]);
                if (this.activePattern.planeName == FoamPlaneType.YZ)
                  buLine = new buLine(new Point3D(Points[0].X, Points[0].Y - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Z), Points[0]);
                foamPattern.planeName = this.activePattern.planeName;
                foamPattern.HorizontalIndex = 0;
                foamPattern.VerticalIndex = Convert.ToInt32(num + 1.0);
                foamPattern.Type = FoamType.SlicesHorizontal;
                foamPattern.GroupType = FoamOperationType.Wave;
                foamPattern.sortEntities.Add((buEntity) buLine);
                if (this.activePattern.planeName == FoamPlaneType.XZ)
                  foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.X - foamPattern.BoxMinItem.X, 3);
                if (this.activePattern.planeName == FoamPlaneType.YZ)
                  foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.Y - foamPattern.BoxMinItem.Y, 3);
                foamPattern.Height = Math.Round(foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z, 3);
                clsInit.cVector5.BoxSizeCalculate(Points, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
                for (int index = 1; index <= Points.Count - 1; ++index)
                {
                  buLine = new buLine(Points[index - 1], Points[index]);
                  foamPattern.sortEntities.Add((buEntity) buLine);
                }
                if (this.activePattern.planeName == FoamPlaneType.XZ)
                  buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z));
                if (this.activePattern.planeName == FoamPlaneType.YZ)
                  buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Z));
                foamPattern.sortEntities.Add((buEntity) buLine);
                FoamPatterns.Add(foamPattern);
              }
            }
            this.varCalc.ZOffset -= RunSettings.SlicesHeight;
            Points = new List<Point3D>();
            Points.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
            points.Add(buVector5.ToPoint3D(Points[Points.Count - 1]));
            if (this.activePattern.planeName == FoamPlaneType.XZ)
            {
              Points.Add(new Point3D(RunSettings.BlockWidth, 0.0, this.varCalc.ZOffset));
              points.Add(buVector5.ToPoint3D(Points[Points.Count - 1]));
              double x = Points[Points.Count - 1].X;
              points.Add(new Point3D(x, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
              points.Add(new Point3D(0.0, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
              points.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
            }
            if (this.activePattern.planeName == FoamPlaneType.YZ)
            {
              Points.Add(new Point3D(0.0, RunSettings.BlockWidth, this.varCalc.ZOffset));
              points.Add(buVector5.ToPoint3D(Points[Points.Count - 1]));
              double y = Points[Points.Count - 1].Y;
              points.Add(new Point3D(Points[Points.Count - 1].X, y, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
              points.Add(new Point3D(Points[Points.Count - 1].X, 0.0, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
              points.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
            }
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
            ccVars.pntDrawDynamicLinesArr.Add(Points);
            if (Finished)
            {
              FoamPattern Pattern = new FoamPattern();
              clsInit.cVector5.BoxSizeCalculate(new List<buEntity>()
              {
                (buEntity) new buLinearPath(points)
              }, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
              buLine buLine = (buLine) null;
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                buLine = new buLine(new Point3D(Points[0].X - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Y, Points[0].Z), Points[0]);
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                buLine = new buLine(new Point3D(Points[0].X, Points[0].Y - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Z), Points[0]);
              Pattern.planeName = this.activePattern.planeName;
              Pattern.HorizontalIndex = 0;
              Pattern.VerticalIndex = Convert.ToInt32(num);
              Pattern.Type = FoamType.SlicesHorizontal;
              Pattern.GroupType = FoamOperationType.Wave;
              Pattern.sortEntities.Add((buEntity) buLine);
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                Pattern.Width = Math.Round(Pattern.BoxMaxItem.Y - Pattern.BoxMinItem.Y, 3);
              Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
              clsInit.cVector5.BoxSizeCalculate(Points, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
              for (int index = 1; index <= Points.Count - 1; ++index)
              {
                buLine = new buLine(Points[index - 1], Points[index]);
                Pattern.sortEntities.Add((buEntity) buLine);
              }
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z));
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Z));
              Pattern.sortEntities.Add((buEntity) buLine);
              FoamEntities foamEntities = new FoamEntities();
              buLinearPath buLinearPath = new buLinearPath(points);
              foamEntities.GroupEntity.Outside.Entities.Add((buEntity) buLinearPath);
              Pattern.foamEntities.Add(foamEntities);
              if (buFoamCalc.varFoamSettings.Draw3D)
                clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
              FoamPatterns.Add(Pattern);
            }
          }
          Point3D MidPoint = new Point3D();
          clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref this.activeBlock.MinPoint, ref MidPoint, ref this.activeBlock.MaxPoint);
          if (this.activePattern.planeName == FoamPlaneType.XZ)
          {
            this.activeBlock.MinPoint.Y = 0.0;
            this.activeBlock.MaxPoint.Y = this.activeFoam.Material.Size.Height;
          }
          if (this.activePattern.planeName == FoamPlaneType.YZ)
          {
            this.activeBlock.MinPoint.X = 0.0;
            this.activeBlock.MaxPoint.X = this.activeFoam.Material.Size.Width;
          }
          this.activeBlock.BlockName = RunSettings.BlockName;
          this.activeBlock.SizeObj = new SizeObject(this.activeBlock.MaxPoint.X - this.activeBlock.MinPoint.X, this.activeBlock.MaxPoint.Y - this.activeBlock.MinPoint.Y, this.activeBlock.MaxPoint.Z - this.activeBlock.MinPoint.Z);
        }
      }
      else if (this.activePattern.planeName == FoamPlaneType.XZ | this.activePattern.planeName == FoamPlaneType.YZ)
      {
        this.activeBlock.TopZ = this.varCalc.ZOffset + this.varCalc.BlockIdealHeight;
        this.activeBlock.BottomZ = this.varCalc.ZOffset;
        for (double num = 0.0; num <= (double) (this.varCalc.YCountActual - 1); ++num)
        {
          List<Point3D> refPoints = new List<Point3D>();
          List<Point3D> Points;
          if (num == 0.0)
          {
            Points = new List<Point3D>();
            Points.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
            if (this.activePattern.planeName == FoamPlaneType.XZ)
              Points.Add(new Point3D(RunSettings.BlockWidth, 0.0, this.varCalc.ZOffset));
            if (this.activePattern.planeName == FoamPlaneType.YZ)
              Points.Add(new Point3D(0.0, RunSettings.BlockWidth, this.varCalc.ZOffset));
            ccVars.pntDrawDynamicLinesArr.Add(Points);
            if (Finished)
            {
              FoamPattern foamPattern = new FoamPattern();
              buLine buLine = (buLine) null;
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                buLine = new buLine(new Point3D(Points[0].X - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Y, Points[0].Z), Points[0]);
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                buLine = new buLine(new Point3D(Points[0].X, Points[0].Y - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Z), Points[0]);
              foamPattern.planeName = this.activePattern.planeName;
              foamPattern.HorizontalIndex = 0;
              foamPattern.VerticalIndex = Convert.ToInt32(num + 1.0);
              foamPattern.Type = FoamType.SlicesHorizontal;
              foamPattern.GroupType = FoamOperationType.Wave;
              foamPattern.sortEntities.Add((buEntity) buLine);
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.X - foamPattern.BoxMinItem.X, 3);
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.Y - foamPattern.BoxMinItem.Y, 3);
              foamPattern.Height = Math.Round(foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z, 3);
              clsInit.cVector5.BoxSizeCalculate(Points, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
              for (int index = 1; index <= Points.Count - 1; ++index)
              {
                buLine = new buLine(Points[index - 1], Points[index]);
                foamPattern.sortEntities.Add((buEntity) buLine);
              }
              if (this.activePattern.planeName == FoamPlaneType.XZ)
                buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z));
              if (this.activePattern.planeName == FoamPlaneType.YZ)
                buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Z));
              foamPattern.sortEntities.Add((buEntity) buLine);
              FoamPatterns.Add(foamPattern);
            }
          }
          this.varCalc.ZOffset += RunSettings.SlicesHeight;
          Points = new List<Point3D>();
          Points.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
          refPoints.Add(buVector5.ToPoint3D(Points[Points.Count - 1]));
          if (this.activePattern.planeName == FoamPlaneType.XZ)
          {
            Points.Add(new Point3D(RunSettings.BlockWidth, 0.0, this.varCalc.ZOffset));
            refPoints.Add(buVector5.ToPoint3D(Points[Points.Count - 1]));
            double x = Points[Points.Count - 1].X;
            refPoints.Add(new Point3D(x, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
            refPoints.Add(new Point3D(0.0, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
            refPoints.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
          }
          if (this.activePattern.planeName == FoamPlaneType.YZ)
          {
            Points.Add(new Point3D(0.0, RunSettings.BlockWidth, this.varCalc.ZOffset));
            refPoints.Add(buVector5.ToPoint3D(Points[Points.Count - 1]));
            double y = Points[Points.Count - 1].Y;
            refPoints.Add(new Point3D(Points[Points.Count - 1].X, y, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
            refPoints.Add(new Point3D(Points[Points.Count - 1].X, 0.0, Points[Points.Count - 1].Z + RunSettings.SlicesHeight));
            refPoints.Add(new Point3D(0.0, 0.0, this.varCalc.ZOffset));
          }
          clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
          ccVars.pntDrawDynamicLinesArr.Add(Points);
          if (Finished)
          {
            clsInit.cVector5.Move(0.0, 0.0, -RunSettings.SlicesHeight, ref refPoints);
            FoamPattern Pattern = new FoamPattern();
            clsInit.cVector5.BoxSizeCalculate(new List<buEntity>()
            {
              (buEntity) new buLinearPath(refPoints)
            }, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
            buLine buLine = (buLine) null;
            if (this.activePattern.planeName == FoamPlaneType.XZ)
              buLine = new buLine(new Point3D(Points[0].X - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Y, Points[0].Z), Points[0]);
            if (this.activePattern.planeName == FoamPlaneType.YZ)
              buLine = new buLine(new Point3D(Points[0].X, Points[0].Y - buFoamCalc.varFoamSettings.LeadInLength, Points[0].Z), Points[0]);
            Pattern.planeName = this.activePattern.planeName;
            Pattern.HorizontalIndex = 0;
            Pattern.VerticalIndex = Convert.ToInt32(num);
            Pattern.Type = FoamType.SlicesHorizontal;
            Pattern.GroupType = FoamOperationType.Wave;
            Pattern.sortEntities.Add((buEntity) buLine);
            if (this.activePattern.planeName == FoamPlaneType.XZ)
              Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
            if (this.activePattern.planeName == FoamPlaneType.YZ)
              Pattern.Width = Math.Round(Pattern.BoxMaxItem.Y - Pattern.BoxMinItem.Y, 3);
            Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
            clsInit.cVector5.BoxSizeCalculate(Points, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
            for (int index = 1; index <= Points.Count - 1; ++index)
            {
              buLine = new buLine(Points[index - 1], Points[index]);
              Pattern.sortEntities.Add((buEntity) buLine);
            }
            if (this.activePattern.planeName == FoamPlaneType.XZ)
              buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z));
            if (this.activePattern.planeName == FoamPlaneType.YZ)
              buLine = new buLine(Points[Points.Count - 1], new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, Points[Points.Count - 1].Z));
            Pattern.sortEntities.Add((buEntity) buLine);
            FoamEntities foamEntities = new FoamEntities();
            buLinearPath buLinearPath = new buLinearPath(refPoints);
            foamEntities.GroupEntity.Outside.Entities.Add((buEntity) buLinearPath);
            Pattern.foamEntities.Add(foamEntities);
            if (buFoamCalc.varFoamSettings.Draw3D)
              clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
            FoamPatterns.Add(Pattern);
          }
        }
        Point3D MidPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref this.activeBlock.MinPoint, ref MidPoint, ref this.activeBlock.MaxPoint);
        if (this.activePattern.planeName == FoamPlaneType.XZ)
        {
          this.activeBlock.MinPoint.Y = 0.0;
          this.activeBlock.MaxPoint.Y = this.activeFoam.Material.Size.Height;
        }
        if (this.activePattern.planeName == FoamPlaneType.YZ)
        {
          this.activeBlock.MinPoint.X = 0.0;
          this.activeBlock.MaxPoint.X = this.activeFoam.Material.Size.Width;
        }
        this.activeBlock.BlockName = RunSettings.BlockName;
        this.activeBlock.SizeObj = new SizeObject(this.activeBlock.MaxPoint.X - this.activeBlock.MinPoint.X, this.activeBlock.MaxPoint.Y - this.activeBlock.MinPoint.Y, this.activeBlock.MaxPoint.Z - this.activeBlock.MinPoint.Z);
      }
    }
    AppBool.Calculation = false;
  }

  public void doCalculateSlicesVertical(
    FoamRuntimeSettings RunSettings,
    bool Finished,
    FoamType Type,
    ref List<FoamPattern> FoamPatterns,
    bool Edit = false)
  {
    AppBool.Calculation = true;
    this.varCalc.PatternWidth = RunSettings.SlicesHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
    this.varCalc.XOffset = 0.0;
    this.doOperationSizeCalcVer(ref RunSettings, Edit);
    FoamPatterns = new List<FoamPattern>();
    this.frmSlice.spn_blockvercount.Value = 1M;
    this.frmSlice.spn_blockhorcount.Value = (Decimal) this.varCalc.XCountActual;
    this.frmSlice.spn_totalpart.Value = (Decimal) this.varCalc.XCountActual;
    ccVars.pntDrawDynamicLinesArr.Clear();
    ccVars.pntDrawDynamicLinesArrColored.Clear();
    if (this.activePattern != null)
    {
      List<Point3D> point3DList = new List<Point3D>();
      List<Point3D> Points;
      if (this.activePattern.planeName == FoamPlaneType.XZ)
      {
        for (double num = 0.0; num <= (double) (this.varCalc.XCountActual - 1); ++num)
        {
          List<Point3D> points = new List<Point3D>();
          if (num == 0.0)
          {
            Points = new List<Point3D>();
            Points.Add(new Point3D(this.varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset));
            Points.Add(new Point3D(this.varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset + this.varCalc.BlockTrimedHeight));
            ccVars.pntDrawDynamicLinesArr.Add(Points);
            if (Finished)
            {
              FoamPattern foamPattern = new FoamPattern()
              {
                planeName = FoamPlaneType.XZ,
                HorizontalIndex = Convert.ToInt32(num),
                VerticalIndex = Convert.ToInt32(num),
                Type = FoamType.SlicesHorizontal,
                GroupType = FoamOperationType.Wave
              };
              foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.X - foamPattern.BoxMinItem.X, 3);
              foamPattern.Height = Math.Round(foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z, 3);
              clsInit.cVector5.BoxSizeCalculate(Points, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
              for (int index = 1; index <= Points.Count - 1; ++index)
              {
                buLine buLine = new buLine(Points[index - 1], Points[index]);
                foamPattern.sortEntities.Add((buEntity) buLine);
              }
              FoamPatterns.Add(foamPattern);
            }
          }
          this.varCalc.XOffset += RunSettings.SlicesHeight;
          Points = new List<Point3D>();
          Points.Add(new Point3D(this.varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset));
          points.Add(new Point3D(this.varCalc.XOffset - RunSettings.SlicesHeight, 0.0, RunSettings.PatternHeightStartOffset));
          Points.Add(new Point3D(this.varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset + this.varCalc.BlockTrimedHeight));
          points.Add(new Point3D(this.varCalc.XOffset - RunSettings.SlicesHeight, 0.0, RunSettings.PatternHeightStartOffset + this.varCalc.BlockTrimedHeight));
          double z = Points[Points.Count - 1].Z;
          points.Add(new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, z));
          points.Add(new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, RunSettings.PatternHeightStartOffset));
          points.Add(new Point3D(this.varCalc.XOffset - RunSettings.SlicesHeight, 0.0, RunSettings.PatternHeightStartOffset));
          clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
          ccVars.pntDrawDynamicLinesArr.Add(Points);
          if (Finished)
          {
            FoamPattern Pattern = new FoamPattern();
            clsInit.cVector5.BoxSizeCalculate(new List<buEntity>()
            {
              (buEntity) new buLinearPath(points)
            }, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
            Pattern.planeName = FoamPlaneType.XZ;
            Pattern.HorizontalIndex = Convert.ToInt32(num + 1.0);
            Pattern.VerticalIndex = Convert.ToInt32(num + 1.0);
            Pattern.Type = FoamType.SlicesHorizontal;
            Pattern.GroupType = FoamOperationType.Wave;
            Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
            Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
            clsInit.cVector5.BoxSizeCalculate(Points, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
            for (int index = 1; index <= Points.Count - 1; ++index)
            {
              buLine buLine = new buLine(Points[index - 1], Points[index]);
              Pattern.sortEntities.Add((buEntity) buLine);
            }
            FoamEntities foamEntities = new FoamEntities();
            buLinearPath buLinearPath = new buLinearPath(points);
            foamEntities.GroupEntity.Outside.Entities.Add((buEntity) buLinearPath);
            Pattern.foamEntities.Add(foamEntities);
            if (buFoamCalc.varFoamSettings.Draw3D)
              clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
            FoamPatterns.Add(Pattern);
          }
        }
        Point3D MidPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref this.activeBlock.MinPoint, ref MidPoint, ref this.activeBlock.MaxPoint);
        this.activeBlock.MinPoint.Y = 0.0;
        this.activeBlock.MaxPoint.Y = this.activeFoam.Material.Size.Height;
        this.activeBlock.LeftMax = this.activeBlock.MaxPoint.X;
        this.activeBlock.BlockName = RunSettings.BlockName;
        this.activeBlock.SizeObj = new SizeObject(this.activeBlock.MaxPoint.X - this.activeBlock.MinPoint.X, this.activeBlock.MaxPoint.Y - this.activeBlock.MinPoint.Y, this.activeBlock.MaxPoint.Z - this.activeBlock.MinPoint.Z);
      }
      if (this.activePattern.planeName == FoamPlaneType.YZ)
      {
        for (double num = 0.0; num <= (double) (this.varCalc.XCountActual - 1); ++num)
        {
          List<Point3D> points = new List<Point3D>();
          if (num == 0.0)
          {
            Points = new List<Point3D>();
            Points.Add(new Point3D(0.0, this.varCalc.XOffset, RunSettings.PatternHeightStartOffset));
            Points.Add(new Point3D(0.0, this.varCalc.XOffset, RunSettings.PatternHeightStartOffset + this.varCalc.BlockTrimedHeight));
            ccVars.pntDrawDynamicLinesArr.Add(Points);
            if (Finished)
            {
              FoamPattern foamPattern = new FoamPattern()
              {
                planeName = FoamPlaneType.YZ,
                HorizontalIndex = Convert.ToInt32(num),
                VerticalIndex = Convert.ToInt32(num),
                Type = FoamType.SlicesHorizontal,
                GroupType = FoamOperationType.Wave
              };
              foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.Y - foamPattern.BoxMinItem.Y, 3);
              foamPattern.Height = Math.Round(foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z, 3);
              clsInit.cVector5.BoxSizeCalculate(Points, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
              for (int index = 1; index <= Points.Count - 1; ++index)
              {
                buLine buLine = new buLine(Points[index - 1], Points[index]);
                foamPattern.sortEntities.Add((buEntity) buLine);
              }
              FoamPatterns.Add(foamPattern);
            }
          }
          this.varCalc.XOffset += RunSettings.SlicesHeight;
          Points = new List<Point3D>();
          Points.Add(new Point3D(0.0, this.varCalc.XOffset, RunSettings.PatternHeightStartOffset));
          points.Add(new Point3D(0.0, this.varCalc.XOffset - RunSettings.SlicesHeight, RunSettings.PatternHeightStartOffset));
          Points.Add(new Point3D(0.0, this.varCalc.XOffset, RunSettings.PatternHeightStartOffset + this.varCalc.BlockTrimedHeight));
          points.Add(new Point3D(0.0, this.varCalc.XOffset - RunSettings.SlicesHeight, RunSettings.PatternHeightStartOffset + this.varCalc.BlockTrimedHeight));
          double z = Points[Points.Count - 1].Z;
          points.Add(new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, z));
          points.Add(new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, RunSettings.PatternHeightStartOffset));
          points.Add(new Point3D(0.0, this.varCalc.XOffset - RunSettings.SlicesHeight, RunSettings.PatternHeightStartOffset));
          clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
          ccVars.pntDrawDynamicLinesArr.Add(Points);
          if (Finished)
          {
            FoamPattern Pattern = new FoamPattern();
            clsInit.cVector5.BoxSizeCalculate(new List<buEntity>()
            {
              (buEntity) new buLinearPath(points)
            }, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
            Pattern.planeName = FoamPlaneType.YZ;
            Pattern.HorizontalIndex = Convert.ToInt32(num + 1.0);
            Pattern.VerticalIndex = Convert.ToInt32(num + 1.0);
            Pattern.Type = FoamType.SlicesHorizontal;
            Pattern.GroupType = FoamOperationType.Wave;
            Pattern.Width = Math.Round(Pattern.BoxMaxItem.Y - Pattern.BoxMinItem.Y, 3);
            Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
            clsInit.cVector5.BoxSizeCalculate(Points, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
            for (int index = 1; index <= Points.Count - 1; ++index)
            {
              buLine buLine = new buLine(Points[index - 1], Points[index]);
              Pattern.sortEntities.Add((buEntity) buLine);
            }
            if (buFoamCalc.varFoamSettings.Draw3D)
            {
              FoamEntities foamEntities = new FoamEntities();
              buLinearPath buLinearPath = new buLinearPath(points);
              foamEntities.GroupEntity.Outside.Entities.Add((buEntity) buLinearPath);
              Pattern.foamEntities.Add(foamEntities);
              clsInit.cFoamCut.CreateSolidOperation(ref Pattern, this.activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
            }
            FoamPatterns.Add(Pattern);
          }
        }
        Point3D MidPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref this.activeBlock.MinPoint, ref MidPoint, ref this.activeBlock.MaxPoint);
        this.activeBlock.MinPoint.X = 0.0;
        this.activeBlock.MaxPoint.X = this.activeFoam.Material.Size.Width;
        this.activeBlock.LeftMax = this.activeBlock.MaxPoint.Y;
        this.activeBlock.BlockName = RunSettings.BlockName;
        this.activeBlock.SizeObj = new SizeObject(this.activeBlock.MaxPoint.X - this.activeBlock.MinPoint.X, this.activeBlock.MaxPoint.Y - this.activeBlock.MinPoint.Y, this.activeBlock.MaxPoint.Z - this.activeBlock.MinPoint.Z);
      }
      if (this.activePattern.planeName == FoamPlaneType.YZ)
        ;
    }
    AppBool.Calculation = false;
  }

  public void doAddOperation(FoamRuntimeSettings Set)
  {
    buFoamCalc.varFoamRunSettings = new FoamRuntimeSettings(Set);
    List<List<Point3D>> point3DListList = new List<List<Point3D>>();
    List<FoamPattern> FoamPatterns = new List<FoamPattern>();
    FoamBlock foamBlock = new FoamBlock(this.activeBlock);
    if (Set.TypeFoam == FoamType.VForm)
    {
      this.doCalculateWaveShape(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isWaveOperation = true;
    }
    if (Set.TypeFoam == FoamType.ZForm)
    {
      this.doCalculateWaveShape(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isWaveOperation = true;
    }
    else if (Set.TypeFoam == FoamType.SForm)
    {
      this.doCalculateWaveShape(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isWaveOperation = true;
    }
    else if (Set.TypeFoam == FoamType.CForm)
    {
      this.doCalculateWaveShape(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isWaveOperation = true;
    }
    else if (Set.TypeFoam == FoamType.UForm)
    {
      this.doCalculateWaveShape(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isWaveOperation = true;
    }
    else if (Set.TypeFoam == FoamType.Rectangle)
    {
      this.doCalculateWaveShape(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isWaveOperation = true;
    }
    if (Set.TypeFoam == FoamType.Pyramid)
    {
      this.doCalculateWaveShape(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isWaveOperation = true;
    }
    else if (Set.TypeFoam == FoamType.FromDrawing)
    {
      this.doCalculatePattern(Set, true, ref FoamPatterns);
      foamBlock.basePattern = new FoamPattern(this.activePattern);
    }
    else if (Set.TypeFoam == FoamType.SlicesHorizontal)
      this.doCalculateSlicesHorizontal(Set, true, Set.TypeFoam, ref FoamPatterns);
    else if (Set.TypeFoam == FoamType.SlicesVertical)
    {
      this.doCalculateSlicesVertical(Set, true, Set.TypeFoam, ref FoamPatterns);
      foamBlock.isVertical = true;
    }
    else if (Set.TypeFoam == FoamType.SingleLine)
      ;
    if (Set.TypeFoam == FoamType.Pattern)
    {
      foamBlock.basePattern = new FoamPattern(this.activePattern);
      this.doCalculatePattern(Set, true, ref FoamPatterns);
    }
    foamBlock.planeName = buFoamCalc.varFoamRunSettings.planeNames;
    foamBlock.BlockName = Set.BlockName;
    foamBlock.BlockFoamType = Set.TypeFoam;
    foamBlock.Settings = new FoamRuntimeSettings(Set);
    foamBlock.Speeds = new FoamSpeeds(buFoamCalc.varFoamSettings.CuttingFeed, buFoamCalc.varFoamSettings.EntryFeed, buFoamCalc.varFoamSettings.LeaveFeed, buFoamCalc.varFoamSettings.ConnectionFeed, buFoamCalc.varFoamSettings.CRotationFeed);
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
    {
      if (this.activeFoam.BlockXZ.Count == 0)
      {
        this.activeFoam.BlockXZ.Add(foamBlock);
        this.foamActiveBlock_0.BlockIndex = 0;
      }
      else if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.DownToUp)
      {
        this.activeFoam.BlockXZ.Add(foamBlock);
        this.foamActiveBlock_0.BlockIndex = this.activeFoam.BlockXZ.Count - 1;
      }
      else if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
      {
        this.activeFoam.BlockXZ.Add(foamBlock);
        this.foamActiveBlock_0.BlockIndex = this.activeFoam.BlockXZ.Count - 1;
      }
      this.foamActiveBlock_0.Plane = FoamPlaneType.XZ;
      this.activeFoam.BlockXZ[this.foamActiveBlock_0.BlockIndex].Pattern = FoamPatterns;
    }
    if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
    {
      if (this.activeFoam.BlockYZ.Count == 0)
      {
        this.activeFoam.BlockYZ.Add(foamBlock);
        this.foamActiveBlock_0.BlockIndex = 0;
      }
      else if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.DownToUp)
      {
        this.activeFoam.BlockYZ.Add(foamBlock);
        this.foamActiveBlock_0.BlockIndex = this.activeFoam.BlockXZ.Count - 1;
      }
      else if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
      {
        this.activeFoam.BlockYZ.Add(foamBlock);
        this.foamActiveBlock_0.BlockIndex = this.activeFoam.BlockYZ.Count - 1;
      }
      this.foamActiveBlock_0.Plane = FoamPlaneType.YZ;
      this.activeFoam.BlockYZ[this.foamActiveBlock_0.BlockIndex].Pattern = FoamPatterns;
    }
    this.JobUpdate(true, "", (DrillItem) null, -1);
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(true, false, false, true));
    this.SaveFoamFile();
    this.activeFoam.isGCodeCreated = false;
    clsInit.appCommand.Reset();
  }

  public void doEditBlock()
  {
    if (buFoamCalc.varFoamRunSettings.planeNames != FoamPlaneType.XZ || !(this.foamActiveBlock_0.BlockIndex >= 0 & this.foamActiveBlock_0.BlockIndex <= this.activeFoam.BlockXZ.Count - 1))
      return;
    this.bool_1 = true;
  }

  public void doShowVirtualDrawings()
  {
    if (clsInit.appEditor == null)
      return;
    Sketcher2D.DrawingPoints.Clear();
    clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
    double dX = clsItem.frmEditor.viewport.Entities.BoxMax.X - clsItem.frmEditor.viewport.Entities.BoxMin.X + buFoamCalc.varFoamEditorSettings.RigthVirtualDrawingDistance;
    double dY = -(clsItem.frmEditor.viewport.Entities.BoxMax.Y - clsItem.frmEditor.viewport.Entities.BoxMin.Y) - buFoamCalc.varFoamEditorSettings.BottomVirtualDrawingDistance;
    if (buFoamCalc.varFoamEditorSettings.ShowRightVirtualDrawing)
    {
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        List<Point3D> point3DList = new List<Point3D>();
        buVector5.Copy(clsItem.frmEditor.viewport.Entities[index].Vertices, ref point3DList);
        clsInit.cVector5.Move(dX, 0.0, 0.0, ref point3DList);
        Sketcher2D.DrawingPoints.Add(point3DList);
      }
      for (int index = 0; index <= clsInit.appEditor.sortedEntities.Count - 1; ++index)
      {
        List<Point3D> point3DList = new List<Point3D>();
        buVector5.Copy(clsInit.appEditor.sortedEntities[index].Vertices, ref point3DList);
        clsInit.cVector5.Move(dX, 0.0, 0.0, ref point3DList);
        Sketcher2D.DrawingPoints.Add(point3DList);
      }
    }
    if (buFoamCalc.varFoamEditorSettings.ShowBottomVirtualDrawing)
    {
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        List<Point3D> point3DList = new List<Point3D>();
        buVector5.Copy(clsItem.frmEditor.viewport.Entities[index].Vertices, ref point3DList);
        clsInit.cVector5.Move(0.0, dY, 0.0, ref point3DList);
        Sketcher2D.DrawingPoints.Add(point3DList);
      }
      for (int index = 0; index <= clsInit.appEditor.sortedEntities.Count - 1; ++index)
      {
        List<Point3D> point3DList = new List<Point3D>();
        buVector5.Copy(clsInit.appEditor.sortedEntities[index].Vertices, ref point3DList);
        clsInit.cVector5.Move(0.0, dY, 0.0, ref point3DList);
        Sketcher2D.DrawingPoints.Add(point3DList);
      }
    }
    if (buFoamCalc.varFoamEditorSettings.ShowBottomRightVirtualDrawing)
    {
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        List<Point3D> point3DList = new List<Point3D>();
        buVector5.Copy(clsItem.frmEditor.viewport.Entities[index].Vertices, ref point3DList);
        clsInit.cVector5.Move(dX, dY, 0.0, ref point3DList);
        Sketcher2D.DrawingPoints.Add(point3DList);
      }
      for (int index = 0; index <= clsInit.appEditor.sortedEntities.Count - 1; ++index)
      {
        List<Point3D> point3DList = new List<Point3D>();
        buVector5.Copy(clsInit.appEditor.sortedEntities[index].Vertices, ref point3DList);
        clsInit.cVector5.Move(dX, dY, 0.0, ref point3DList);
        Sketcher2D.DrawingPoints.Add(point3DList);
      }
    }
    clsItem.frmEditor.viewport.Invalidate();
  }

  public void doGetNestResult(buNestedResult Result, int SheetIndex, int PartIndex)
  {
    int num1 = 0;
    int num2 = Result.NestedResultSheets.Count - 1;
    if (SheetIndex >= 0)
    {
      num1 = SheetIndex;
      num2 = SheetIndex;
    }
    this.selectedEntities.Clear();
    this.selectedEntities = new List<List<buEntity>>();
    if (Result.NestedResultSheets.Count <= 0)
      return;
    for (int index1 = num1; index1 <= num2; ++index1)
    {
      List<Entity> calcEntities1 = new List<Entity>();
      List<Entity> UselessEntities = new List<Entity>();
      ccVars.UndoDont = true;
      clsInit.cNesting.NestedSheetToEntity(Result.NestedResultSheets[index1], false, false, ref calcEntities1, ref UselessEntities);
      int num3 = 0;
      int num4 = Result.NestedResultSheets[index1].Parts.Count - 1;
      if (PartIndex >= 0)
      {
        num3 = PartIndex;
        num4 = PartIndex;
      }
      List<buEntity> buEntityList1 = new List<buEntity>();
      for (int index2 = num3; index2 <= num4; ++index2)
      {
        ccVars.UndoDont = true;
        List<Entity> calcEntities2 = new List<Entity>();
        clsInit.cNesting.NestedPartToEntity(Result.NestedResultSheets[index1].Parts[index2], false, false, ref calcEntities2);
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        List<buEntity> refEntities = new List<buEntity>();
        buEntity.Copy(Result.NestedResultSheets[index1].Parts[index2].EntitiesGroup.Outside.Entities, ref refEntities);
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
        if (MinPoint.Z != 0.0)
          clsInit.cVector5.Move(0.0, 0.0, -MinPoint.Z, ref refEntities);
        List<buEntity> SortedEntities = new List<buEntity>();
        SortbuResult Result1 = new SortbuResult();
        clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].StartPoint, ref refEntities, new SortbuSettings(), ref SortedEntities, ref Result1);
        List<buEntity> buEntityList2 = new List<buEntity>();
        for (int index3 = 0; index3 <= SortedEntities.Count - 1; ++index3)
        {
          if (SortedEntities[index3] is buCircle)
          {
            buArc Arc1 = (buArc) null;
            buArc Arc2 = (buArc) null;
            buArc Arc3 = (buArc) null;
            buArc Arc4 = (buArc) null;
            clsInit.cVector5.CircletoFourArc((buCircle) SortedEntities[index3], ref Arc1, ref Arc2, ref Arc3, ref Arc4);
            buEntityList2.Add((buEntity) Arc1);
            buEntityList2.Add((buEntity) Arc2);
            buEntityList2.Add((buEntity) Arc3);
            buEntityList2.Add((buEntity) Arc4);
          }
          else if (SortedEntities[index3] is buArc)
          {
            if (((buArc) SortedEntities[index3]).EndAngle - ((buArc) SortedEntities[index3]).StartAngle > 170.0)
            {
              buEntity Arc1 = (buEntity) null;
              buEntity Arc2 = (buEntity) null;
              clsInit.cVector5.ArcToTwoArc((buArc) SortedEntities[index3], ref Arc1, ref Arc2);
              buEntityList2.Add(Arc1);
              buEntityList2.Add(Arc2);
            }
            else
              buEntityList2.Add(SortedEntities[index3]);
          }
          else
            buEntityList2.Add(SortedEntities[index3]);
        }
        this.selectedEntities.Add(buEntityList2);
      }
      this.cmdAddFromFile((List<buEntity>) null, this.selectedEntities);
    }
  }

  public void doGeneralTick(int TickCount)
  {
  }

  public void doReset()
  {
    this.pnldata.Visible = false;
    this.DeleteEntities(true, false, false);
    buFoamCalc.varTemps.pntLastSelected = (Point3D) null;
    this.bool_1 = false;
    this.varCalc.isVertical = false;
    // ISSUE: reference to a compiler-generated field
    if (this.okCommandWithTwoDataEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.okCommandWithTwoDataEventHandler_0((object) "Cancel", (object) null);
  }

  public void doNewPage()
  {
    ccVars.planeActive = Plane.XY;
    ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XY;
    clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
    clsInit.appCommand.cmdViewTop(false, false);
    this.timer_1.Enabled = true;
  }

  public void doOpenPage()
  {
    ccVars.planeActive = Plane.XY;
    ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XY;
    clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
    clsInit.appCommand.cmdViewTop(false, false);
  }

  public void CreateGCode(ref List<camTp> CamList, ref PostProcessor P)
  {
    for (int index = 0; index <= this.activeFoam.sortedEntitiesXZ.Count - 1; ++index)
    {
      if (index > 0)
      {
        if (this.activeFoam.sortedEntitiesXZ[index].typeDefination == entityTypeDefination.None | this.activeFoam.sortedEntitiesXZ[index].typeDefination == entityTypeDefination.Cutting && this.activeFoam.sortedEntitiesXZ[index - 1].typeDefination == entityTypeDefination.Upper)
          this.activeFoam.sortedEntitiesXZ[index - 1].typeDefination = entityTypeDefination.CamLeadin;
        if (this.activeFoam.sortedEntitiesXZ[index].typeDefination == entityTypeDefination.Upper && this.activeFoam.sortedEntitiesXZ[index - 1].typeDefination == entityTypeDefination.None | this.activeFoam.sortedEntitiesXZ[index - 1].typeDefination == entityTypeDefination.Cutting)
          this.activeFoam.sortedEntitiesXZ[index].typeDefination = entityTypeDefination.CamLeadOut;
      }
    }
    for (int index = 0; index <= this.activeFoam.sortedEntitiesYZ.Count - 1; ++index)
    {
      if (index > 0)
      {
        if (this.activeFoam.sortedEntitiesYZ[index].typeDefination == entityTypeDefination.None | this.activeFoam.sortedEntitiesYZ[index].typeDefination == entityTypeDefination.Cutting && this.activeFoam.sortedEntitiesYZ[index - 1].typeDefination == entityTypeDefination.Upper)
          this.activeFoam.sortedEntitiesYZ[index - 1].typeDefination = entityTypeDefination.CamLeadin;
        if (this.activeFoam.sortedEntitiesYZ[index].typeDefination == entityTypeDefination.Upper && this.activeFoam.sortedEntitiesYZ[index - 1].typeDefination == entityTypeDefination.None | this.activeFoam.sortedEntitiesYZ[index - 1].typeDefination == entityTypeDefination.Cutting)
          this.activeFoam.sortedEntitiesYZ[index].typeDefination = entityTypeDefination.CamLeadOut;
      }
    }
    if (ccVars.PostActive.Mode == "AES")
      this.CreateGCodeAES(ref CamList, ref P);
    if (!(ccVars.PostActive.Mode == "CMD"))
      return;
    this.CreateGCodeCMD(ref CamList, ref P);
  }

  public void cmdCamContour(ref camTp Cam)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      List<Point3D> Points = new List<Point3D>();
      clsInit.cVector5.EntitiesToPointsWithCamDirection(clsMW.CamBuEntities, ref Points);
      clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
      double LastAng1 = 0.0;
      double num1 = 0.0;
      Point3D pntLast1 = new Point3D();
      Cam = new camTp();
      camTpPoint CamPoint = new camTpPoint();
      TpPnt9D tpPnt9D1 = new TpPnt9D();
      ClockDirectionType clockDirectionType = ClockDirectionType.CW;
      for (int index1 = 0; index1 <= clsMW.CamBuEntities.Count - 1; ++index1)
      {
        int num2 = 0;
        double connectionFeed = buFoamCalc.varFoamSettings.ConnectionFeed;
        double entryFeed = buFoamCalc.varFoamSettings.EntryFeed;
        double leaveFeed = buFoamCalc.varFoamSettings.LeaveFeed;
        double num3 = buFoamCalc.varFoamSettings.CuttingFeed;
        double crotationFeed = buFoamCalc.varFoamSettings.CRotationFeed;
        if (clsMW.CamBuEntities[index1].Info.OrjType == entityOriginalType.Arc && clsMW.CamBuEntities[index1].Info.Radius > 0.0 & buFoamCalc.RadiusFeedList.Count > 0)
        {
          for (int index2 = 0; index2 <= buFoamCalc.RadiusFeedList.Count - 1; ++index2)
          {
            if (buFoamCalc.RadiusFeedList[index2].MinRadius <= clsMW.CamBuEntities[index1].Info.Radius & clsMW.CamBuEntities[index1].Info.Radius <= buFoamCalc.RadiusFeedList[index2].MaxRadius && buFoamCalc.RadiusFeedList[index2].Feed > 0.0)
            {
              num3 = buFoamCalc.RadiusFeedList[index2].Feed;
              index2 = buFoamCalc.RadiusFeedList.Count;
            }
          }
        }
        if (index1 > 0 && clsMW.CamBuEntities[index1 - 1].Info.OrjType == entityOriginalType.Arc & (clsMW.CamBuEntities[index1].Info.OrjType == entityOriginalType.Line | clsMW.CamBuEntities[index1].Info.OrjType == entityOriginalType.LinearPath))
        {
          double num4 = clsMW.CamBuEntities[index1].Length();
          for (int index3 = 0; index3 <= buFoamCalc.LengthFeedList.Count - 1; ++index3)
          {
            if (buFoamCalc.LengthFeedList[index3].MinLength <= num4 & num4 <= buFoamCalc.LengthFeedList[index3].MaxLength && buFoamCalc.LengthFeedList[index3].Feed > 0.0)
            {
              num3 = buFoamCalc.LengthFeedList[index3].Feed;
              index3 = buFoamCalc.LengthFeedList.Count;
            }
          }
        }
        if (buFoamCalc.varFoamSettings.UseG1InsteadOfG0)
          num2 = 1;
        bool flag1 = false;
        if (index1 == 0)
        {
          double c = clsInit.cVector5.PointAngle(clsMW.CamBuEntities[index1].Vertices[1], clsMW.CamBuEntities[index1].Vertices[0]);
          if (!buFoamCalc.varFoamSettings.NonLinearCAxis)
          {
            if (c > 180.0)
              c -= 360.0;
          }
          else if (c < 90.0)
            c += 360.0;
          tpPnt9D1 = new TpPnt9D(new Pnt6D(clsMW.CamBuEntities[index1].Vertices[0].X, clsMW.CamBuEntities[index1].Vertices[0].Y, clsMW.CamBuEntities[index1].Vertices[0].Z, 0.0, 0.0, c), connectionFeed, num2);
          CamPoint.Points.Add(tpPnt9D1);
          pntLast1 = buVector5.ToPoint3D(clsMW.CamBuEntities[index1].Vertices[0]);
          LastAng1 = c;
        }
        if (clsMW.CamBuEntities[index1].typeDefination == entityTypeDefination.Upper | clsMW.CamBuEntities[index1].typeDefination == entityTypeDefination.Connection | clsMW.CamBuEntities[index1].typeDefination == entityTypeDefination.CamLeadin | clsMW.CamBuEntities[index1].typeDefination == entityTypeDefination.CamLeadOut)
        {
          bool flag2 = false;
          bool flag3 = false;
          bool flag4 = false;
          NoneContinousResult Result = new NoneContinousResult();
          List<buEntity> buEntityList1 = new List<buEntity>();
          List<buEntity> buEntityList2 = new List<buEntity>();
          if (index1 < clsMW.CamBuEntities.Count - 1 && clsMW.CamBuEntities[index1 + 1].typeDefination == entityTypeDefination.None | clsMW.CamBuEntities[index1 + 1].typeDefination == entityTypeDefination.Cutting)
          {
            Point3D vertex1 = clsMW.CamBuEntities[index1 + 1].Vertices[0];
            Point3D vertex2 = clsMW.CamBuEntities[index1 + 1].Vertices[1];
            clsInit.cVector5.PointAngle(vertex2, vertex1);
            buEntityList1.Add(buEntity.Copy(clsMW.CamBuEntities[index1]));
            for (int index4 = index1 + 1; index4 <= clsMW.CamBuEntities.Count - 1; ++index4)
            {
              if (clsMW.CamBuEntities[index4].typeDefination == entityTypeDefination.Upper | clsMW.CamBuEntities[index4].typeDefination == entityTypeDefination.CamLeadin | clsMW.CamBuEntities[index4].typeDefination == entityTypeDefination.CamLeadOut)
              {
                Point3D vertex3 = clsMW.CamBuEntities[index4 - 1].Vertices[clsMW.CamBuEntities[index4 - 1].Vertices.Count - 2];
                Point3D vertex4 = clsMW.CamBuEntities[index4 - 1].Vertices[clsMW.CamBuEntities[index4 - 1].Vertices.Count - 1];
                clsInit.cVector5.PointAngle(vertex4, vertex3);
                index4 = clsMW.CamBuEntities.Count;
              }
              else
              {
                buEntityList1.Add(buEntity.Copy(clsMW.CamBuEntities[index4]));
                buEntityList2.Add(buEntity.Copy(clsMW.CamBuEntities[index4]));
              }
            }
            if (buEntityList2.Count > 0)
            {
              List<TpPnt9D> P9List = new List<TpPnt9D>();
              Point3D pntLast2 = new Point3D(pntLast1.X, pntLast1.Y, pntLast1.Z);
              double LastAng2 = LastAng1;
              for (int index5 = 0; index5 <= buEntityList2.Count - 1; ++index5)
                this.calcNoneContinous(buEntityList2[index5], ref pntLast2, ref LastAng2, num2, crotationFeed, num3, ref P9List, ref Result);
            }
          }
          if (Result.OutLimitMinAngle < 0.0)
            flag2 = true;
          if (Result.OutLimitMaxAngle > 0.0)
            flag3 = true;
          for (int index6 = 1; index6 <= clsMW.CamBuEntities[index1].Vertices.Count - 1; ++index6)
          {
            bool flag5 = false;
            bool flag6 = false;
            double c = clsInit.cVector5.PointAngle(clsMW.CamBuEntities[index1].Vertices[index6], pntLast1);
            if (flag2 & !flag3)
            {
              if (c + Result.MaxAngle + 360.0 < buFoamCalc.varFoamSettings.TangentMaxAngle)
                c += 360.0;
            }
            else if (flag3 & !flag2)
            {
              if (c - Result.MinAngle - 360.0 > buFoamCalc.varFoamSettings.TangentMinAngle)
                c -= 360.0;
            }
            else
            {
              double num5 = c - LastAng1;
              if (buFoamCalc.varFoamSettings.ContiniousTangent)
              {
                double num6 = num5 >= 0.0 ? -buNumeric5.RoundToLower(num5 / 360.0) : -buNumeric5.RoundToUpper(num5 / 360.0);
                c += num6 * 360.0;
              }
              double num7 = c - LastAng1;
              if (num7 > 180.0)
                c -= 360.0;
              if (num7 < -180.0)
                c += 360.0;
              num1 = c - LastAng1;
            }
            if (flag1 & flag4)
            {
              if (clockDirectionType == ClockDirectionType.CW && c < -10.0)
                c += 360.0;
              if (clockDirectionType == ClockDirectionType.CCW && c > 70.0)
                c -= 360.0;
            }
            if (!buFoamCalc.varFoamSettings.ContiniousTangent)
            {
              if (c > buFoamCalc.varFoamSettings.TangentMaxAngle)
              {
                c -= 360.0;
                flag5 = true;
              }
              if (c < buFoamCalc.varFoamSettings.TangentMinAngle)
              {
                c += 360.0;
                flag5 = true;
              }
            }
            double num8 = c - LastAng1;
            if (Math.Abs(num8) > 180.0)
              flag6 = true;
            if (Math.Abs(num8) > buFoamCalc.varFoamSettings.AngleLimitOnlyCRotation)
            {
              if (CamPoint.Points.Count <= 0 || Math.Abs(CamPoint.Points[CamPoint.Points.Count - 1].P9.C - tpPnt9D1.P9.C) > 180.0)
                ;
              Point3D point3D = new Point3D(pntLast1.X, pntLast1.Y, pntLast1.Z);
              if (index1 < clsMW.CamBuEntities.Count - 1 && clsMW.CamBuEntities[index1 + 1].typeDefination == entityTypeDefination.None | clsMW.CamBuEntities[index1 + 1].typeDefination == entityTypeDefination.Cutting)
              {
                point3D = clsInit.cVector5.MiddlePointOfLine(pntLast1, clsMW.CamBuEntities[index1].Vertices[index6]);
                TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, CamPoint.Points[CamPoint.Points.Count - 1].P9.C), CamPoint.Points[CamPoint.Points.Count - 1].Feed, CamPoint.Points[CamPoint.Points.Count - 1].Type);
                CamPoint.Points.Add(tpPnt9D2);
              }
              int type = num2;
              if (buFoamCalc.varFoamSettings.UseCRotationAsG0Always)
                type = 0;
              CamPoint.Points.Add(new TpPnt9D(new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, c), crotationFeed, type)
              {
                IsMark = flag5,
                IsLimit = flag6
              });
            }
            int type1 = num2;
            double feed = connectionFeed;
            if (clsMW.CamBuEntities[index1].typeDefination == entityTypeDefination.CamLeadin)
            {
              type1 = 1;
              feed = entryFeed;
            }
            if (clsMW.CamBuEntities[index1].typeDefination == entityTypeDefination.CamLeadOut)
            {
              type1 = 1;
              feed = leaveFeed;
            }
            tpPnt9D1 = new TpPnt9D(new Pnt6D(clsMW.CamBuEntities[index1].Vertices[index6].X, clsMW.CamBuEntities[index1].Vertices[index6].Y, clsMW.CamBuEntities[index1].Vertices[index6].Z, 0.0, 0.0, c), feed, type1);
            tpPnt9D1.IsMark = flag5;
            tpPnt9D1.IsLimit = flag6;
            if (CamPoint.Points.Count <= 0 || Math.Abs(CamPoint.Points[CamPoint.Points.Count - 1].P9.C - tpPnt9D1.P9.C) > 180.0)
              ;
            CamPoint.Points.Add(tpPnt9D1);
            pntLast1 = buVector5.ToPoint3D(clsMW.CamBuEntities[index1].Vertices[index6]);
            LastAng1 = c;
          }
        }
        else
        {
          List<TpPnt9D> tpPnt9DList = new List<TpPnt9D>();
          if (!buFoamCalc.varFoamSettings.ContiniousTangent)
          {
            NoneContinousResult Result = new NoneContinousResult();
            this.calcNoneContinous(clsMW.CamBuEntities[index1], ref pntLast1, ref LastAng1, num2, crotationFeed, num3, ref CamPoint.Points, ref Result);
          }
          else
          {
            for (int index7 = 1; index7 <= clsMW.CamBuEntities[index1].Vertices.Count - 1; ++index7)
            {
              double num9 = clsInit.cVector5.PointAngle(clsMW.CamBuEntities[index1].Vertices[index7], pntLast1);
              double num10 = LastAng1 - num9;
              double num11 = num10 >= 0.0 ? buNumeric5.RoundToLower(num10 / 360.0) : buNumeric5.RoundToUpper(num10 / 360.0);
              double c = num9 + num11 * 360.0;
              double num12 = LastAng1 - c;
              if (num11 > 0.0)
                ;
              if (num12 > 180.0)
                c += 360.0;
              if (num12 < -180.0)
                c -= 360.0;
              if (Math.Abs(LastAng1 - c) > 20.0)
              {
                int type = num2;
                if (buFoamCalc.varFoamSettings.UseCRotationAsG0Always)
                  type = 0;
                TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(pntLast1.X, pntLast1.Y, pntLast1.Z, 0.0, 0.0, c), crotationFeed, type);
                CamPoint.Points.Add(tpPnt9D3);
              }
              tpPnt9D1 = new TpPnt9D(new Pnt6D(clsMW.CamBuEntities[index1].Vertices[index7].X, clsMW.CamBuEntities[index1].Vertices[index7].Y, clsMW.CamBuEntities[index1].Vertices[index7].Z, 0.0, 0.0, c), num3, 1);
              tpPnt9D1.IsMark = false;
              CamPoint.Points.Add(tpPnt9D1);
              pntLast1 = buVector5.ToPoint3D(clsMW.CamBuEntities[index1].Vertices[index7]);
              LastAng1 = c;
            }
          }
        }
      }
      clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam.SimilationPoint.SimMove, CamPoint, 10.0);
      Cam.CamPoints.Add(CamPoint);
    }
    catch (Exception ex)
    {
    }
  }

  public void calcNoneContinous(
    buEntity refEntity,
    ref Point3D pntLast,
    ref double LastAng,
    int G0Type,
    double velRot,
    double velCut,
    ref List<TpPnt9D> P9List,
    ref NoneContinousResult Result)
  {
    TpPnt9D tpPnt9D1 = new TpPnt9D();
    for (int index = 1; index <= refEntity.Vertices.Count - 1; ++index)
    {
      bool flag1 = false;
      bool flag2 = false;
      double c = clsInit.cVector5.PointAngle(refEntity.Vertices[index], pntLast);
      double num1 = c - LastAng;
      double lower = buNumeric5.RoundToLower(Math.Abs(num1) / 360.0);
      if (num1 < 0.0)
        lower *= 1.0;
      if (num1 > 0.0)
        lower *= -1.0;
      if (lower < 0.0 | lower > 0.0)
      {
        c += 360.0 * lower;
        num1 = c - LastAng;
      }
      if (num1 > 180.0)
        c -= 360.0;
      if (num1 < -180.0)
        c += 360.0;
      if (c > buFoamCalc.varFoamSettings.TangentMaxAngle)
      {
        Result.OutLimitMaxAngle = c;
        c -= 360.0;
        flag1 = true;
      }
      if (c < buFoamCalc.varFoamSettings.TangentMinAngle)
      {
        Result.OutLimitMinAngle = c;
        c += 360.0;
        flag1 = true;
      }
      double num2 = c - LastAng;
      if (Math.Abs(num2) > 180.0)
        flag2 = true;
      if (c > Result.MaxAngle)
        Result.MaxAngle = c;
      if (c < Result.MinAngle)
        Result.MinAngle = c;
      if (Math.Abs(num2) > 20.0)
      {
        int type = G0Type;
        if (buFoamCalc.varFoamSettings.UseCRotationAsG0Always)
          type = 0;
        TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(pntLast.X, pntLast.Y, pntLast.Z, 0.0, 0.0, c), velRot, type);
        tpPnt9D2.IsMark = flag1;
        tpPnt9D2.IsLimit = flag2;
        if (P9List.Count <= 0 || Math.Abs(P9List[P9List.Count - 1].P9.C - tpPnt9D2.P9.C) > 180.0)
          ;
        P9List.Add(tpPnt9D2);
      }
      TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(refEntity.Vertices[index].X, refEntity.Vertices[index].Y, refEntity.Vertices[index].Z, 0.0, 0.0, c), velCut, 1);
      if (P9List.Count <= 0 || Math.Abs(P9List[P9List.Count - 1].P9.C - tpPnt9D3.P9.C) > 180.0)
        ;
      P9List.Add(tpPnt9D3);
      pntLast = buVector5.ToPoint3D(refEntity.Vertices[index]);
      LastAng = c;
    }
  }

  public void cmdCamContour1(ref camTp Cam)
  {
  }

  public void CreateGCodeAES(ref List<camTp> CamList, ref PostProcessor P)
  {
    SortbuSettings sortbuSettings = new SortbuSettings();
    SortbuResult sortbuResult = new SortbuResult();
    List<buEntity> buEntityList = new List<buEntity>();
    buMWFoamVars.varCamFoam.buPar.Strategy.MaxTangentValue = buFoamCalc.varFoamSettings.TangentMaxAngle;
    buMWFoamVars.varCamFoam.buPar.Strategy.MinTangentValue = buFoamCalc.varFoamSettings.TangentMinAngle;
    buMWFoamVars.varCamFoam.buPar.Strategy.AngleLimit = 20.0;
    buMWFoamVars.varCamFoam.buPar.Speeds.Feed = buFoamCalc.varFoamSettings.CuttingFeed;
    if (this.activeFoam.sortedEntitiesXZ.Count > 0)
    {
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      clsMW.CamBuEntities.Clear();
      clsMW.CamBuEntities = new List<buEntity>();
      if (this.activeFoam.sortedEntitiesXZ.Count > 0)
      {
        for (int index = 0; index <= this.activeFoam.sortedEntitiesXZ.Count - 1; ++index)
        {
          List<Point3D> RefPoint = new List<Point3D>();
          List<Point3D> CalcPoint = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(this.activeFoam.sortedEntitiesXZ[index], buFoamCalc.varFoamSettings.RegenDeviation, ref RefPoint);
          if (buFoamCalc.varFoamSettings.MaxDevideLen > 0.0)
            clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref RefPoint);
          clsInit.cVector5.PointConversionByPlane(Plane.XZ, Plane.XY, RefPoint, ref CalcPoint);
          buLinearPath buLinearPath = new buLinearPath(CalcPoint);
          buLinearPath.typeDefination = this.activeFoam.sortedEntitiesXZ[index].typeDefination;
          clsMW.CamBuEntities.Add((buEntity) buLinearPath);
        }
      }
      this.activeFoam.CamXZ = new camTp();
      if (clsMW.CamBuEntities.Count > 0 | clsMW.CamEntities.Count > 0)
      {
        this.cmdCamContour(ref this.activeFoam.CamXZ);
        for (int index = 0; index <= this.activeFoam.CamXZ.CamPoints[0].Points.Count - 1; ++index)
        {
          if (this.activeFoam.CamXZ.CamPoints[0].Points[index].Feed == buFoamCalc.varFoamSettings.CuttingFeed)
          {
            this.activeFoam.CamXZ.CamPoints[0].Points[index].Feed = buFoamCalc.varFoamSettings.EntryFeed;
            break;
          }
        }
        for (int index = this.activeFoam.CamXZ.CamPoints[0].Points.Count - 1; index >= 0; --index)
        {
          if (this.activeFoam.CamXZ.CamPoints[0].Points[index].Feed == buFoamCalc.varFoamSettings.CuttingFeed)
          {
            this.activeFoam.CamXZ.CamPoints[0].Points[index].Feed = buFoamCalc.varFoamSettings.LeaveFeed;
            break;
          }
        }
        if (this.activeFoam.CamXZ.CamPoints.Count > 0)
          this.activeFoam.CamXZ.CamPoints[0].PreCodes.Add((object) "L TABLA0");
      }
    }
    if (this.activeFoam.sortedEntitiesYZ.Count > 0)
    {
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      clsMW.CamBuEntities.Clear();
      clsMW.CamBuEntities = new List<buEntity>();
      if (this.activeFoam.sortedEntitiesYZ.Count > 0)
      {
        for (int index = 0; index <= this.activeFoam.sortedEntitiesYZ.Count - 1; ++index)
        {
          List<Point3D> RefPoint = new List<Point3D>();
          List<Point3D> CalcPoint = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(this.activeFoam.sortedEntitiesYZ[index], buFoamCalc.varFoamSettings.RegenDeviation, ref RefPoint);
          if (buFoamCalc.varFoamSettings.MaxDevideLen > 0.0)
            clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref RefPoint);
          clsInit.cVector5.PointConversionByPlane(Plane.YZ, Plane.XY, RefPoint, ref CalcPoint);
          buLinearPath buLinearPath = new buLinearPath(CalcPoint);
          buLinearPath.typeDefination = this.activeFoam.sortedEntitiesXZ[index].typeDefination;
          clsMW.CamBuEntities.Add((buEntity) buLinearPath);
        }
      }
      this.activeFoam.CamYZ = new camTp();
      if (clsMW.CamEntities.Count > 0)
      {
        this.cmdCamContour(ref this.activeFoam.CamYZ);
        if (this.activeFoam.CamYZ.CamPoints.Count > 0)
          this.activeFoam.CamYZ.CamPoints[0].PreCodes.Add((object) "L TABLA90");
      }
    }
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
    this.activeFoam.isGCodeCreated = true;
    P = new PostProcessor(ccVars.PostActive);
    P.StartLines.Add((object) ("R4000=" + this.activeFoam.Material.Size.Width.ToString("f2")));
    P.StartLines.Add((object) ("R4001=" + this.activeFoam.Material.Size.Depth.ToString("f2")));
    P.StartLines.Add((object) "L GINIPRO.ISC");
    P.StartLines.Add((object) "G305 OFF");
    CamList = new List<camTp>();
    if (this.activeFoam.CamYZ.CamPoints.Count > 0)
      CamList.Add(new camTp(this.activeFoam.CamYZ));
    if (this.activeFoam.CamXZ.CamPoints.Count > 0)
      CamList.Add(new camTp(this.activeFoam.CamXZ));
    if (CamList.Count <= 0)
      return;
    for (int index = 0; index <= CamList.Count - 1; ++index)
    {
      CamList[index].EntitiesG1.Clear();
      CamList[index].EntitiesG0.Clear();
      CamList[index].EntitiesLeave.Clear();
      CamList[index].EntitiesPlunge.Clear();
    }
  }

  public void CreateGCodeCMD(ref List<camTp> CamList, ref PostProcessor P)
  {
    SortbuSettings sortbuSettings = new SortbuSettings();
    SortbuResult sortbuResult = new SortbuResult();
    List<buEntity> buEntityList = new List<buEntity>();
    buMWFoamVars.varCamFoam.buPar.Strategy.MaxTangentValue = buFoamCalc.varFoamSettings.TangentMaxAngle;
    buMWFoamVars.varCamFoam.buPar.Strategy.MinTangentValue = buFoamCalc.varFoamSettings.TangentMinAngle;
    buMWFoamVars.varCamFoam.buPar.Strategy.AngleLimit = 20.0;
    clsMW.CamEntities.Clear();
    clsMW.CamBuEntities.Clear();
    this.activeFoam.CamXZ = new camTp();
    if (this.activeFoam.sortedEntitiesXZ.Count > 0)
    {
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      clsMW.CamBuEntities.Clear();
      clsMW.CamBuEntities = new List<buEntity>();
      if (this.activeFoam.sortedEntitiesXZ.Count > 0)
      {
        for (int index = 0; index <= this.activeFoam.sortedEntitiesXZ.Count - 1; ++index)
        {
          List<Point3D> RefPoint = new List<Point3D>();
          List<Point3D> CalcPoint = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(this.activeFoam.sortedEntitiesXZ[index], buFoamCalc.varFoamSettings.RegenDeviation, ref RefPoint);
          if (buFoamCalc.varFoamSettings.MaxDevideLen > 0.0 & this.activeFoam.sortedEntitiesXZ[index] is buLine)
            clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref RefPoint);
          clsInit.cVector5.PointConversionByPlane(Plane.XZ, Plane.XY, RefPoint, ref CalcPoint);
          buLinearPath buLinearPath = new buLinearPath(CalcPoint);
          clsInit.cVector5.EntityToOriginalType(this.activeFoam.sortedEntitiesXZ[index], ref buLinearPath.Info.OrjType, ref buLinearPath.Info.Radius);
          buLinearPath.typeDefination = this.activeFoam.sortedEntitiesXZ[index].typeDefination;
          clsMW.CamBuEntities.Add((buEntity) buLinearPath);
        }
      }
      this.activeFoam.CamXZ = new camTp();
      if (clsMW.CamBuEntities.Count > 0)
        this.cmdCamContour(ref this.activeFoam.CamXZ);
    }
    this.activeFoam.CamYZ = new camTp();
    if (this.activeFoam.sortedEntitiesYZ.Count > 0)
    {
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      clsMW.CamBuEntities.Clear();
      clsMW.CamBuEntities = new List<buEntity>();
      if (this.activeFoam.sortedEntitiesYZ.Count > 0)
      {
        for (int index = 0; index <= this.activeFoam.sortedEntitiesYZ.Count - 1; ++index)
        {
          List<Point3D> RefPoint = new List<Point3D>();
          List<Point3D> CalcPoint = new List<Point3D>();
          clsInit.cVector5.EntitiesToPointsWithCamDirection(this.activeFoam.sortedEntitiesYZ[index], buFoamCalc.varFoamSettings.RegenDeviation, ref RefPoint);
          if (buFoamCalc.varFoamSettings.MaxDevideLen > 0.0 & this.activeFoam.sortedEntitiesYZ[index] is buLine)
            clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref RefPoint);
          clsInit.cVector5.PointConversionByPlane(Plane.YZ, Plane.XY, RefPoint, ref CalcPoint);
          buLinearPath buLinearPath = new buLinearPath(CalcPoint);
          buLinearPath.typeDefination = this.activeFoam.sortedEntitiesYZ[index].typeDefination;
          clsMW.CamBuEntities.Add((buEntity) buLinearPath);
        }
      }
      this.activeFoam.CamYZ = new camTp();
      if (clsMW.CamBuEntities.Count > 0)
      {
        this.cmdCamContour(ref this.activeFoam.CamYZ);
        if (this.activeFoam.CamYZ.CamPoints.Count > 0)
          ;
      }
    }
    this.CreatePanelFromJob(ref this.activeFoam, new FoamCreatePanelOptions(false, true, true, false));
    this.activeFoam.isGCodeCreated = true;
    P = new PostProcessor(ccVars.PostActive);
    CamList = new List<camTp>();
    if (this.activeFoam.CamXZ.CamPoints.Count > 0)
    {
      if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
        this.activeFoam.CamXZ.PreCodesWithoutNo.Add((object) "<GCodesMain>");
      for (int index = 0; index <= P.StartLines.Count - 1; ++index)
        this.activeFoam.CamXZ.PreCodes.Add(P.StartLines[index]);
      for (int index = 0; index <= P.EndLines.Count - 1; ++index)
        this.activeFoam.CamXZ.AfterCodes.Add(P.EndLines[index]);
      if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
        this.activeFoam.CamXZ.AfterCodesWithoutNo.Add((object) "</GCodesMain>");
      CamList.Add(new camTp(this.activeFoam.CamXZ));
    }
    if (this.activeFoam.CamYZ.CamPoints.Count > 0)
    {
      if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
        this.activeFoam.CamYZ.PreCodesWithoutNo.Add((object) "<GCodesSide>");
      for (int index = 0; index <= P.StartLines.Count - 1; ++index)
        this.activeFoam.CamYZ.PreCodes.Add(P.StartLines[index]);
      for (int index = 0; index <= P.EndLines.Count - 1; ++index)
        this.activeFoam.CamYZ.AfterCodes.Add(P.EndLines[index]);
      if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
        this.activeFoam.CamYZ.AfterCodesWithoutNo.Add((object) "</GCodesSide>");
      CamList.Add(new camTp(this.activeFoam.CamYZ));
    }
    P.StartLines.Clear();
    P.EndLines.Clear();
    P.StartLinesWithoutProcess.Clear();
    P.EndLinesWithoutProcess.Clear();
    if (!buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
      return;
    P.StartLinesWithoutProcess.Add((object) "<Info>");
    P.StartLinesWithoutProcess.Add((object) $"{this.activeFoam.Material.Size.Width.ToString()} ; {this.activeFoam.Material.Size.Height.ToString()} ; {this.activeFoam.Material.Size.Depth.ToString()}");
    P.StartLinesWithoutProcess.Add((object) "</Info>");
  }
}
