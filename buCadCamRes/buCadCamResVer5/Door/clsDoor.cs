// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Door.clsDoor
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Editor;
using buCadCamResVer5.Library;
using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Door;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Shape;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Door;

public class clsDoor
{
  public List<string> cmdExceptionID = new List<string>();
  private string string_0 = "XZ";
  private bool bool_0 = false;
  private Timer timer_0 = new Timer();
  public Timer timNew = new Timer();
  private int int_0 = 1;
  private int int_1 = -1;
  private string string_1 = "";
  private ShapeCreateParameters shapeCreateParameters_0 = new ShapeCreateParameters();
  private F_DoorMat f_DoorMat_0 = (F_DoorMat) null;
  public static DoorJob activeJob;
  public List<buEntity> refEntities = new List<buEntity>();

  public void Init()
  {
    buMWDoorVars.Init();
    this.OpenDoorFile();
    this.LoadLanguage();
    this.timNew.Tick += new EventHandler(this.NewPageTick);
    if (clsInit.appLibrary == null)
      return;
    clsInit.appLibrary.Init();
  }

  public void InitSimulation()
  {
  }

  public void DoorTree_AfterSelect(object sender, TreeViewEventArgs e)
  {
    if (ccVars.Pages.Count == 0)
      return;
    TreeNodeSettings selectedNode = (TreeNodeSettings) ((TreeView) sender).SelectedNode;
    if (clsItem.FrmDoorJob.tree_jobs.Nodes != null)
    {
      for (int index1 = 0; index1 <= clsItem.FrmDoorJob.tree_jobs.Nodes.Count - 1; ++index1)
      {
        clsItem.FrmDoorJob.tree_jobs.Nodes[index1].ForeColor = Color.Black;
        if (clsItem.FrmDoorJob.tree_jobs.Nodes[index1].Nodes != null)
        {
          for (int index2 = 0; index2 <= clsItem.FrmDoorJob.tree_jobs.Nodes[index1].Nodes.Count - 1; ++index2)
            clsItem.FrmDoorJob.tree_jobs.Nodes[index1].Nodes[index2].ForeColor = Color.Black;
        }
      }
    }
    switch (selectedNode.Command)
    {
      case "panelbase":
        buDoor.varTemps.selectedDoorIndex = selectedNode.ClassIndex;
        break;
      case "item":
        buDoor.varTemps.selectedDoorIndex = selectedNode.ClassIndex;
        buDoor.varTemps.selectedItemIndex = selectedNode.ClassSubIndex;
        break;
    }
  }

  public void DoorTree_AfterCheck(object sender, TreeViewEventArgs e)
  {
    if (ccVars.Pages.Count == 0)
      ;
  }

  public void DoorTreeUpdate()
  {
    clsItem.FrmDoorJob.tree_jobs.Nodes.Clear();
    TreeNodeSettings treeNodeSettings1 = new TreeNodeSettings("Job");
    treeNodeSettings1.ImageIndex = 10;
    treeNodeSettings1.SelectedImageIndex = 10;
    treeNodeSettings1.Tag = (object) "-1";
    treeNodeSettings1.ClassIndex = 0;
    treeNodeSettings1.ClassSubIndex = -1;
    treeNodeSettings1.ClassSubSubIndex = -1;
    treeNodeSettings1.Command = "panelbase";
    treeNodeSettings1.Name = "base";
    treeNodeSettings1.Info = "base";
    treeNodeSettings1.Index = 0;
    treeNodeSettings1.Checked = false;
    TreeNodeSettings node1 = treeNodeSettings1;
    TreeNodeSettings node2 = (TreeNodeSettings) null;
    if (clsDoor.activeJob != null)
    {
      for (int index = 0; index <= clsDoor.activeJob.Items.Count - 1; ++index)
      {
        TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings(buShape.ToDefination(clsDoor.activeJob.Items[index]));
        treeNodeSettings2.ImageIndex = clsInit.cDoor.JobImageIndex(clsDoor.activeJob.Items[index]);
        treeNodeSettings2.SelectedImageIndex = clsInit.cDoor.JobImageIndex(clsDoor.activeJob.Items[index]);
        treeNodeSettings2.Tag = (object) 0;
        treeNodeSettings2.ClassIndex = 0;
        treeNodeSettings2.ClassSubIndex = index;
        treeNodeSettings2.ClassSubSubIndex = -1;
        treeNodeSettings2.Command = "item";
        treeNodeSettings2.Name = "item";
        treeNodeSettings2.Info = "item";
        treeNodeSettings2.Index = 0;
        treeNodeSettings2.Checked = clsDoor.activeJob.Items[index].Enable;
        node2 = treeNodeSettings2;
        node1.Nodes.Add((TreeNode) node2);
      }
    }
    if (node2 != null)
    {
      node2.Expand();
      node1.Expand();
    }
    clsItem.FrmDoorJob.tree_jobs.Nodes.Add((TreeNode) node1);
  }

  public void Checked_Checked(object sender, EventArgs e)
  {
    buDoor.varDoorRunSettings.SelectMode = clsItem.FrmDoorJob.chk_selectmode.Checked;
    clsItem.FrmDoorJob.tree_jobs.CheckBoxes = buDoor.varDoorRunSettings.SelectMode;
    if (buDoor.varDoorRunSettings.SelectMode)
      return;
    for (int index = 0; index <= clsItem.FrmDoorJob.tree_jobs.Nodes.Count - 1; ++index)
      clsItem.FrmDoorJob.tree_jobs.Nodes[index].Expand();
  }

  public void cmdNewMaterial(DoorJob panel)
  {
    if (this.f_DoorMat_0 == null)
    {
      this.f_DoorMat_0 = new F_DoorMat();
      CreateModelProperties Properties = new CreateModelProperties();
      clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
      Properties.CoordinateSystemIconVisible = false;
      Properties.ViewCubeIconVisible = false;
      Properties.OrigineCaptionVisible = false;
      Properties.ToolBorVisible = false;
      Properties.OrigineSize = 5;
      this.f_DoorMat_0.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      this.f_DoorMat_0.viewportLayout.CompileUserInterfaceElements();
    }
    this.f_DoorMat_0.pnl_model.Controls.Add((System.Windows.Forms.Control) this.f_DoorMat_0.viewportLayout);
    this.f_DoorMat_0.viewportLayout.Entities.Clear();
    this.f_DoorMat_0.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    ccVars.activeMaterial.Size.Width = buDoor.varDoorRunSettings.MaterialWidth;
    ccVars.activeMaterial.Size.Height = buDoor.varDoorRunSettings.MaterialHeight;
    ccVars.activeMaterial.Size.Depth = buDoor.varDoorRunSettings.MaterialDepth;
    ccVars.activeMaterial.FrontAngle = buDoor.varDoorRunSettings.MaterialFrontAngle;
    ccVars.activeMaterial.BackAngle = buDoor.varDoorRunSettings.MaterialBackAngle;
    ccVars.activeMaterial.Purpose = buDoor.varDoorRunSettings.MaterailPurpuse;
    if (panel != null)
    {
      ccVars.activeMaterial.Size.Width = panel.Material.Size.Width;
      ccVars.activeMaterial.Size.Height = panel.Material.Size.Height;
      ccVars.activeMaterial.Size.Depth = panel.Material.Size.Depth;
      ccVars.activeMaterial.FrontAngle = panel.Material.FrontAngle;
      ccVars.activeMaterial.BackAngle = panel.Material.BackAngle;
      ccVars.activeMaterial.Purpose = panel.Material.Purpose;
    }
    this.f_DoorMat_0.Material = new MaterialBase5(ccVars.activeMaterial);
    this.f_DoorMat_0.Case1.Width = buDoor.varDoorRunSettings.Case1Width;
    this.f_DoorMat_0.Case1.Height = buDoor.varDoorRunSettings.Case1Height;
    this.f_DoorMat_0.Case1.Depth = buDoor.varDoorRunSettings.Case1Depth;
    this.f_DoorMat_0.Case2.Width = buDoor.varDoorRunSettings.Case2Width;
    this.f_DoorMat_0.Case2.Height = buDoor.varDoorRunSettings.Case2Height;
    this.f_DoorMat_0.Case2.Depth = buDoor.varDoorRunSettings.Case2Depth;
    if (panel != null)
      this.f_DoorMat_0.Init((MaterialBase5) null);
    else
      this.f_DoorMat_0.Init((MaterialBase5) null);
    this.f_DoorMat_0.StartPosition = FormStartPosition.CenterParent;
    int num = (int) this.f_DoorMat_0.ShowDialog();
    if (this.f_DoorMat_0.PropertiesForm.Result == DialogResult.OK)
    {
      buDoor.varDoorRunSettings.Case1Width = this.f_DoorMat_0.Case1.Width;
      buDoor.varDoorRunSettings.Case1Height = this.f_DoorMat_0.Case1.Height;
      buDoor.varDoorRunSettings.Case1Depth = this.f_DoorMat_0.Case1.Depth;
      buDoor.varDoorRunSettings.Case2Width = this.f_DoorMat_0.Case2.Width;
      buDoor.varDoorRunSettings.Case2Height = this.f_DoorMat_0.Case2.Height;
      buDoor.varDoorRunSettings.Case2Depth = this.f_DoorMat_0.Case2.Depth;
      ccVars.activeMaterial = new MaterialBase5(this.f_DoorMat_0.Material);
      buDoor.varDoorRunSettings.MaterialWidth = ccVars.activeMaterial.Size.Width;
      buDoor.varDoorRunSettings.MaterialHeight = ccVars.activeMaterial.Size.Height;
      buDoor.varDoorRunSettings.MaterialDepth = ccVars.activeMaterial.Size.Depth;
      buDoor.varDoorRunSettings.MaterialFrontAngle = ccVars.activeMaterial.FrontAngle;
      buDoor.varDoorRunSettings.MaterialBackAngle = ccVars.activeMaterial.BackAngle;
      buDoor.varDoorRunSettings.MaterailPurpuse = ccVars.activeMaterial.Purpose;
      if (panel == null)
        this.AddPanel(ccVars.activeMaterial);
      else
        this.EditPanel(ccVars.activeMaterial);
    }
    this.SaveDoorFile();
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
      Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
      Properties.OriginSymbolVisible = true;
      Properties.OrigineSize = 5;
      clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
      clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
      clsItem.FrmShapeList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
    }
    clsItem.FrmShapeList.parShape = new ShapeRuntimeData(buDoor.varDoorRunSettings.ShapeDataParameters);
    clsItem.FrmShapeList.selectedShape = buDoor.varTemps.lastShape != null ? buShape.Copy(buDoor.varTemps.lastShape) : (buShape) new buShapeRectangle(buDoor.varDoorRunSettings.ShapeDataParameters.RectangleWidth, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleHeight, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleRadius, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleChamfer, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleDepth, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleAngle);
    this.string_1 = "";
    if (AppBool.EditMode || buDoor.varDoorRunSettings.SecondToolEnable)
      ;
    clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDoorVars.varCamCommon.buPar);
    clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDoorVars.varCamCommon.buPar);
    if (clsItem.FrmShapeList.parShape.FreeDrawDepth <= 0.0)
      clsItem.FrmShapeList.parShape.FreeDrawDepth = 5.0;
    clsItem.FrmShapeList.PropertiesForm.TopMost = true;
    clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
    clsItem.FrmShapeList.Top = 50;
    clsItem.FrmShapeList.Left = 1500;
    clsItem.FrmShapeList.TopMost = true;
    if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
      clsItem.FrmShapeList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmShapeList.viewportLayout);
    clsItem.FrmShapeList.viewportLayout.Entities.Clear();
    clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    if (clsItem.FrmMain != null)
      clsItem.FrmShapeList.Owner = clsItem.FrmMain;
    clsItem.FrmShapeList.ClosePageAfterOk = false;
    clsItem.FrmShapeList.Init();
    clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmShapeList.Show();
    clsItem.FrmShapeList.Top = 50;
    clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
  }

  public void cmdSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = "Settings";
      classViewerDialog.Value = (object) buDoor.varDoorSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      buDoor.varDoorSettings = new DoorSettings((DoorSettings) classViewerDialog.Value);
      this.SaveDoorFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdCamSettings()
  {
    try
    {
      F_CamSettings1 fCamSettings1 = new F_CamSettings1();
      fCamSettings1.Properties.FormCloseMode = FormCloseModeType.Dispose;
      fCamSettings1.CamPar = new camParameters5(buMWDoorVars.varCamCommon.buPar);
      fCamSettings1.Init();
      int num = (int) fCamSettings1.ShowDialog();
      if (fCamSettings1.Properties.Result != DialogResult.OK)
        return;
      buMWDoorVars.varCamCommon.buPar = new camParameters5(fCamSettings1.CamPar);
      this.SaveDoorFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdSaveGcode(bool ShowCode)
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
        this.cmdCamContour();
        string Lines = "";
        PostProcessor Post = new PostProcessor(ccVars.PostActive);
        Post.StartLines.Insert(0, (object) "L YUKLE");
        Post.StartLines.Insert(0, (object) ("R2600=" + clsDoor.activeJob.Material.Size.Width.ToString("f1")));
        Post.StartLines.Insert(0, (object) ("R2601=" + clsDoor.activeJob.Material.Size.Height.ToString("f1")));
        Post.StartLines.Insert(0, (object) ("R2602=" + clsDoor.activeJob.Material.Size.Depth.ToString("f1")));
        Post.StartLines.Insert(0, (object) ("R2603=" + clsDoor.activeJob.Material.BackAngle.ToString("f1")));
        Post.StartLines.Insert(0, (object) ("R2604=" + clsDoor.activeJob.Material.FrontAngle.ToString("f1")));
        Post.EndLines.Add((object) "[BOSALT]");
        Post.EndLines.Add((object) "L BOSALT");
        Post.EndLines.Add((object) "M05");
        Post.EndLines.Add((object) "M02");
        clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, Post, ref Lines);
        string str;
        if (ShowCode)
        {
          F_Notepad fNotepad = new F_Notepad();
          fNotepad.Init(Lines);
          fNotepad.Show();
          if (clsItem.FrmProgress != null)
            clsItem.FrmProgress.Visible = false;
          str = "";
        }
        else
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
          saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
          saveFileDialog.FilterIndex = 1;
          if (saveFileDialog.ShowDialog() != DialogResult.OK)
            return;
          clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
          buFile5.SaveToFile(Lines, saveFileDialog.FileName);
          if (clsItem.FrmProgress != null)
            clsItem.FrmProgress.Visible = false;
          str = "";
          clsFiles.SaveParameter();
        }
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
      List<camTp> camTpList1 = new List<camTp>();
      List<camTp> camTpList2 = new List<camTp>();
      List<camTp> camTpList3 = new List<camTp>();
      for (int index = 0; index <= clsDoor.activeJob.Items.Count - 1; ++index)
      {
        if (clsDoor.activeJob.Items[index].planeName == planeBoxNames.Front)
          camTpList1.Add(new camTp(clsDoor.activeJob.Items[index].Cam));
        if (clsDoor.activeJob.Items[index].planeName == planeBoxNames.Back)
          camTpList2.Add(new camTp(clsDoor.activeJob.Items[index].Cam));
        if (clsDoor.activeJob.Items[index].planeName == planeBoxNames.Top)
          camTpList3.Add(new camTp(clsDoor.activeJob.Items[index].Cam));
      }
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.None;
      ccVars.Pages[ccVars.PageIndex].Cams.Clear();
      if (camTpList2.Count > 0)
      {
        for (int index1 = 0; index1 <= camTpList2.Count - 1; ++index1)
        {
          camTpList2[index1].SimilationPoint.SimMove.Clear();
          List<Pnt6DSimMove> pnt6DsimMoveList = new List<Pnt6DSimMove>();
          for (int index2 = 0; index2 <= camTpList2[index1].CamPoints.Count - 1; ++index2)
          {
            List<Pnt6DSimMove> SimPoints = new List<Pnt6DSimMove>();
            clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref SimPoints, camTpList2[index1].CamPoints[index2]);
            if (SimPoints.Count > 0)
            {
              for (int index3 = 0; index3 <= SimPoints.Count - 1; ++index3)
              {
                Pnt6DSimMove Pnt = new Pnt6DSimMove(SimPoints[index3]);
                Pnt.Y += clsDoor.activeJob.Material.Size.Height;
                pnt6DsimMoveList.Add(new Pnt6DSimMove(Pnt));
              }
            }
            if (camTpList2[index1].CamPoints[index2].isSecondHead)
            {
              camTpList2[index1].CamPoints[index2].PreCodes.Add((object) "G0 G53 Z(V4063 / 2 - V4090)");
              camTpList2[index1].CamPoints[index2].PreCodes.Add((object) "M6 T42");
              camTpList2[index1].CamPoints[index2].PreCodes.Add((object) ("M03 S" + camTpList2[index1].Tool.CamData.SpindleSpeed.ToString()));
              camTpList2[index1].CamPoints[index2].PreCodes.Add((object) "G16 XYZ+");
              camTpList2[index1].CamPoints[index2].PreCodes.Add((object) "G0 G53 Z(V4063 / 2 - V4090)");
            }
          }
          if (index1 == 0)
          {
            camTpList2[index1].PreCodes.Add((object) "[M1]");
            camTpList2[index1].PreCodes.Add((object) "L GINIPRO.ISC");
            camTpList2[index1].PreCodes.Add((object) "G305 OFF");
            camTpList2[index1].PreCodes.Add((object) "G54.01");
            camTpList2[index1].PreCodes.Add((object) "M06 T41");
            camTpList2[index1].PreCodes.Add((object) ("M03 S" + camTpList2[index1].Tool.CamData.SpindleSpeed.ToString()));
            camTpList2[index1].PreCodes.Add((object) "G16 XYZ+");
          }
          camTpList2[index1].CamPoints[0].PreCodes.Add((object) "G0 G53 Z(V4063 / 2 - V4090)");
          if (index1 == camTpList2.Count - 1)
          {
            camTpList2[index1].AfterCodes.Add((object) "G0 G53 Z(V4063 / 2 - V4090)");
            camTpList2[index1].AfterCodes.Add((object) "L GFINPRO.ISC");
            camTpList2[index1].AfterCodes.Add((object) "JMP [BOSALT]");
            camTpList2[index1].AfterCodes.Add((object) "M05");
            camTpList2[index1].AfterCodes.Add((object) "M02");
            camTpList2[index1].AfterCodes.Add((object) "RET");
          }
          List<camTpPoint> camPoints = camTpList2[index1].CamPoints;
          clsInit.cCam5.ChangeCamPointCoordinates(ref camPoints, CamPointChangeMethod.XZYToXYZ);
          camTpList2[index1].SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) pnt6DsimMoveList.ToArray());
          camTpList2[index1].Tool.Geometry.ToolDirection = new Vec3D(0.0, 1.0, 0.0);
          ccVars.Pages[ccVars.PageIndex].Cams.Add(camTpList2[index1]);
        }
      }
      if (camTpList3.Count > 0)
      {
        for (int index4 = 0; index4 <= camTpList3.Count - 1; ++index4)
        {
          camTpList3[index4].SimilationPoint.SimMove.Clear();
          List<Pnt6DSimMove> pnt6DsimMoveList = new List<Pnt6DSimMove>();
          for (int index5 = 0; index5 <= camTpList3[index4].CamPoints.Count - 1; ++index5)
          {
            List<Pnt6DSimMove> SimPoints = new List<Pnt6DSimMove>();
            clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref SimPoints, camTpList3[index4].CamPoints[index5]);
            if (SimPoints.Count > 0)
            {
              for (int index6 = 0; index6 <= SimPoints.Count - 1; ++index6)
              {
                Pnt6DSimMove Pnt = new Pnt6DSimMove(SimPoints[index6]);
                pnt6DsimMoveList.Add(new Pnt6DSimMove(Pnt));
              }
            }
          }
          if (index4 == 0)
          {
            camTpList3[index4].PreCodes.Add((object) "[M2]");
            camTpList3[index4].PreCodes.Add((object) "L GINIPRO.ISC");
            camTpList3[index4].PreCodes.Add((object) "G305 OFF");
            camTpList3[index4].PreCodes.Add((object) "G54.01");
            camTpList3[index4].PreCodes.Add((object) "M06 T41");
            camTpList3[index4].PreCodes.Add((object) ("M03 S" + camTpList3[index4].Tool.CamData.SpindleSpeed.ToString()));
            camTpList3[index4].PreCodes.Add((object) "G16 XZY+");
          }
          if (index4 == camTpList3.Count - 1)
            camTpList3[index4].AfterCodes.Add((object) "G0 G53 Y(V4063/1-V4090)");
          List<camTpPoint> camPoints = camTpList3[index4].CamPoints;
          clsInit.cCam5.ChangeCamPointCoordinates(ref camPoints, CamPointChangeMethod.XYZToXZY);
          camTpList3[index4].SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) pnt6DsimMoveList.ToArray());
          camTpList3[index4].Tool.Geometry.ToolDirection = new Vec3D(0.0, 0.0, -1.0);
          ccVars.Pages[ccVars.PageIndex].Cams.Add(camTpList3[index4]);
        }
      }
      if (camTpList1.Count > 0)
      {
        for (int index7 = 0; index7 <= camTpList1.Count - 1; ++index7)
        {
          camTpList1[index7].SimilationPoint.SimMove.Clear();
          List<Pnt6DSimMove> pnt6DsimMoveList = new List<Pnt6DSimMove>();
          for (int index8 = 0; index8 <= camTpList1[index7].CamPoints.Count - 1; ++index8)
          {
            List<Pnt6DSimMove> SimPoints = new List<Pnt6DSimMove>();
            clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref SimPoints, camTpList1[index7].CamPoints[index8]);
            if (SimPoints.Count > 0)
            {
              for (int index9 = 0; index9 <= SimPoints.Count - 1; ++index9)
              {
                Pnt6DSimMove Pnt = new Pnt6DSimMove(SimPoints[index9]);
                Pnt.Y *= -1.0;
                pnt6DsimMoveList.Add(new Pnt6DSimMove(Pnt));
              }
            }
          }
          if (index7 == 0)
          {
            if (camTpList3.Count == 0)
            {
              camTpList1[index7].PreCodes.Add((object) "[M2]");
              camTpList1[index7].PreCodes.Add((object) "L GINIPRO.ISC");
              camTpList1[index7].PreCodes.Add((object) "G305 OFF");
              camTpList1[index7].PreCodes.Add((object) "G54.01");
              camTpList1[index7].PreCodes.Add((object) "M06 T42");
              camTpList1[index7].PreCodes.Add((object) ("M03 S" + camTpList1[index7].Tool.CamData.SpindleSpeed.ToString()));
              camTpList1[index7].PreCodes.Add((object) "G16 XYZ+");
            }
            else
            {
              camTpList1[index7].PreCodes.Add((object) "M06 T42");
              camTpList1[index7].PreCodes.Add((object) ("M03 S" + camTpList1[index7].Tool.CamData.SpindleSpeed.ToString()));
              camTpList1[index7].PreCodes.Add((object) "G16 XYZ+");
            }
          }
          if (index7 == camTpList1.Count - 1)
            camTpList1[index7].AfterCodes.Add((object) "G53 Z(V4063/2-V4090)");
          List<camTpPoint> camPoints = camTpList1[index7].CamPoints;
          clsInit.cCam5.ChangeCamPointCoordinates(ref camPoints, CamPointChangeMethod.XZYToXYZ);
          camTpList1[index7].SimilationPoint.SimMove.AddRange((IEnumerable<Pnt6DSimMove>) pnt6DsimMoveList.ToArray());
          camTpList1[index7].Tool.Geometry.ToolDirection = new Vec3D(0.0, -1.0, 0.0);
          ccVars.Pages[ccVars.PageIndex].Cams.Add(camTpList1[index7]);
        }
      }
      if (camTpList1.Count > 0 | camTpList3.Count > 0)
      {
        if (camTpList2.Count == 0)
        {
          ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(0, (object) "[M1]");
          ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(1, (object) "JMP [BOSALT]");
          ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(2, (object) "M05");
          ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(3, (object) "M02");
          ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(4, (object) "RET");
        }
        ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add((object) "L GFINPRO.ISC");
        ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add((object) "JMP [BOSALT]");
        ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add((object) "M05");
        ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add((object) "M02");
        ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add((object) "RET");
      }
      else
        ccVars.Pages[ccVars.PageIndex].Cams.Add(new camTp()
        {
          PreCodes = {
            (object) "[M2]"
          },
          AfterCodes = {
            (object) "RET"
          }
        });
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
    clsItem.FrmFromFile.Path = buDoor.varDoorRunSettings.pathFromFile;
    clsItem.FrmFromFile.KeepRatio = buDoor.varDoorRunSettings.FromFileKeepRatio;
    clsItem.FrmFromFile.Init();
    int num = (int) clsItem.FrmFromFile.ShowDialog();
    if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
      return;
    this.shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
    List<buEntity> BaseRefEntities = new List<buEntity>();
    for (int index = 0; index <= clsItem.FrmFromFile.viewport.Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
      BaseRefEntities.Add(copiedEntity);
    }
    List<buEntity> SortedEntities = new List<buEntity>();
    SortbuResult Result = new SortbuResult();
    clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].StartPoint, ref BaseRefEntities, new SortbuSettings(), ref SortedEntities, ref Result);
    List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
    clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
    Point3D MinPoint1 = new Point3D();
    Point3D MaxPoint1 = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(SplitedEntitites, ref MinPoint1, ref MaxPoint1);
    List<List<buEntity>> buEntityListList = new List<List<buEntity>>();
    for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
    {
      Point3D MinPoint2 = new Point3D();
      Point3D MaxPoint2 = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(SplitedEntitites[index], ref MinPoint2, ref MaxPoint2);
      if (buCompare5.EQ(MinPoint2, MinPoint1, 2.0) & buCompare5.EQ(MaxPoint2, MaxPoint1, 2.0))
      {
        buCompositeCurve calcCompositeCurve = (buCompositeCurve) null;
        clsInit.cVector5.CreateCompositeCurveFromEntitiesWithCamDirection(SplitedEntitites[index], ref calcCompositeCurve);
        this.shapeCreateParameters_0.entitiesCurve.Add((buEntity) calcCompositeCurve);
        SplitedEntitites.RemoveAt(index);
        index = SplitedEntitites.Count;
      }
    }
    for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
    {
      buCompositeCurve calcCompositeCurve = (buCompositeCurve) null;
      clsInit.cVector5.CreateCompositeCurveFromEntitiesWithCamDirection(SplitedEntitites[index], ref calcCompositeCurve);
      this.shapeCreateParameters_0.entitiesCurve.Add((buEntity) calcCompositeCurve);
    }
    buDoor.varDoorRunSettings.pathFromFile = clsItem.FrmFromFile.Path;
    Point3D MinPoint3 = new Point3D();
    Point3D MaxPoint3 = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(this.shapeCreateParameters_0.entitiesCurve, ref MinPoint3, ref MaxPoint3);
    buDoor.varDoorRunSettings.FromFileKeepRatio = clsItem.FrmFromFile.KeepRatio;
    this.SaveDoorFile();
    buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth = Math.Round(MaxPoint3.X - MinPoint3.X, 3);
    buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight = Math.Round(MaxPoint3.Y - MinPoint3.Y, 3);
    buDoor.varTemps.lastShape = (buShape) new buShapeFreeDraw(buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawAngle);
    buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint3.X, MaxPoint3.Y, MaxPoint3.Z);
    buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint3.X, MinPoint3.Y, MinPoint3.Z);
    this.cmdShapes();
  }

  public void cmdAddFromLibrary()
  {
    if (!new DirectoryInfo(clsVar.varLibrary.pathLibrary).Exists)
      clsVar.varLibrary.pathLibrary = AppPath.Base + "\\Library";
    clsInit.appCommand.cmdLibDraw();
    if (clsItem.FrmLibraryDraw.PropertiesForm.Result != DialogResult.OK)
      return;
    this.shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
    SketchAnalyseData AnalyseData = new SketchAnalyseData();
    clsInit.appEditor.AnalyseSketchEntity(clsLibrary.LibraryEntities, new SketchAnalyseSetData(buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth), ref AnalyseData);
    if (AnalyseData.AnalyseEntities.Count <= 0)
      return;
    buEntity.Copy(AnalyseData.AnalyseEntities, ref this.shapeCreateParameters_0.entitiesCurve);
    buNumeric5.Copy(AnalyseData.DepthLevel, ref buDoor.varDoorRunSettings.ShapeDataParameters.DepthLevels);
    buNumeric5.Copy(AnalyseData.DepthLevel, ref this.shapeCreateParameters_0.DepthLevel);
    Point3D MinPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(this.shapeCreateParameters_0.entitiesCurve, ref MinPoint, ref MaxPoint);
    this.SaveDoorFile();
    buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
    buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
    buDoor.varTemps.lastShape = (buShape) new buShapeFreeDraw(buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawAngle);
    buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
    buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
    this.cmdShapes();
  }

  public void cmdMenuCommand(object sender, EventArgs e)
  {
    string str = "";
    if (sender is System.Windows.Forms.Control)
      str = (sender as System.Windows.Forms.Control).Name;
    else if (sender is ToolStripMenuItem)
      str = (sender as ToolStripMenuItem).Name;
    if (str == clsItem.FrmDoorJob.mnu_addpanel.Name)
      this.cmdNewMaterial((DoorJob) null);
    if (str == clsItem.FrmDoorJob.mnu_deletepanel.Name && clsDoor.activeJob != null && buString5.MessageBoxQuestion(buDoor.LangDoorMessage[17]) == DialogResult.Yes)
      this.doDeletePanel();
    if (str == clsItem.FrmDoorJob.mnu_editpanel.Name && clsDoor.activeJob != null)
      this.cmdNewMaterial(clsDoor.activeJob);
    if (str == clsItem.FrmDoorJob.mnu_renamepanel.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_add.Name | str == clsItem.FrmDoorJob.mnu_add.Name)
      ;
    if (str == clsItem.FrmDoorJob.mnu_refresh.Name && clsDoor.activeJob != null)
    {
      this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
      this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
    }
    if (str == clsItem.FrmDoorJob.btn_remove.Name | str == clsItem.FrmDoorJob.mnu_remove.Name && clsDoor.activeJob != null && buDoor.varTemps.selectedDoorIndex >= 0 & buDoor.varTemps.selectedItemIndex >= 0 && buString5.MessageBoxQuestion(buDoor.LangDoorMessage[18]) == DialogResult.Yes)
      this.doDeleteOperation(buDoor.varTemps.selectedItemIndex);
    if (str == clsItem.FrmDoorJob.mnu_removeall.Name && clsDoor.activeJob != null && buDoor.varTemps.selectedDoorIndex >= 0 & buDoor.varTemps.selectedItemIndex >= 0 && buString5.MessageBoxQuestion(buDoor.LangDoorMessage[23]) == DialogResult.Yes)
      this.doDeleteAllOperations();
    if (str == clsItem.FrmDoorJob.mnu_removeselectedOP.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_edit.Name | str == clsItem.FrmDoorJob.mnu_edit.Name && clsDoor.activeJob != null && buDoor.varTemps.selectedDoorIndex >= 0 & buDoor.varTemps.selectedItemIndex >= 0)
      this.doEditOperation(buDoor.varTemps.selectedItemIndex);
    if (str == clsItem.FrmDoorJob.btn_copy.Name | str == clsItem.FrmDoorJob.mnu_copy.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_move.Name | str == clsItem.FrmDoorJob.mnu_move.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_mirror.Name | str == clsItem.FrmDoorJob.mnu_mirror.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_array.Name | str == clsItem.FrmDoorJob.mnu_array.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_rotate.Name | str == clsItem.FrmDoorJob.mnu_rotate.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_up.Name | str == clsItem.FrmDoorJob.mnu_up.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_down.Name | str == clsItem.FrmDoorJob.mnu_down.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_tool.Name | str == clsItem.FrmDoorJob.mnu_tool.Name)
      ;
    if (str == clsItem.FrmDoorJob.btn_disable.Name | str == clsItem.FrmDoorJob.mnu_disable.Name)
      ;
  }

  public void cmdDrawEditor()
  {
    try
    {
      if (clsItem.frmEditor == null)
        clsItem.frmEditor = new F_Editor();
      clsVar.varEditorRuntimeSet.isSketchMode = true;
      clsItem.frmEditor = new F_Editor();
      clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.frmEditor.Init();
      clsItem.frmEditor.Show((IWin32Window) clsItem.FrmMain);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSimStart()
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
        this.cmdCamContour();
        clsInit.appCommand.simStart();
      }
    }
    catch (Exception ex)
    {
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
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSaveCode()
  {
    if (clsVar.appModes_0.DemoMode)
    {
      int num = (int) MessageBox.Show("Not Available in Demo Mode");
    }
    else if (ccVars.Pages.Count <= 0)
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
    else if (clsDoor.activeJob == null)
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31 /*0x1F*/]);
    }
    else
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = buDoor.varDoorRunSettings.pathJob;
      saveFileDialog.Filter = "Door File (*.budoor)|*.budoor";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      buDoor.varDoorRunSettings.pathJob = buFile5.GetPath(saveFileDialog.FileName);
      this.SaveDoorJobFile(saveFileDialog.FileName, clsDoor.activeJob);
      this.SaveDoorFile();
    }
  }

  public void cmdOpenCode()
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
      Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
      Properties.OriginSymbolVisible = true;
      Properties.OrigineSize = 5;
      clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
      clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
      clsItem.FrmShapeList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
    }
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = buDoor.varDoorRunSettings.pathJob;
    openFileDialog.Filter = "Door File (*.budoor)|*.budoor";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    buDoor.varDoorRunSettings.pathJob = buFile5.GetPath(openFileDialog.FileName);
    this.OpenDoorJobFile(openFileDialog.FileName, ref clsDoor.activeJob);
  }

  public void Sim_Tick(object sender, EventArgs e)
  {
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buDoor.lng") : new FileInfo(AppPath.Language + "\\buDoor.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorCommands);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Door Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Door Language File Missing");
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

  public void SaveDoorFile()
  {
    try
    {
      string FileName1 = AppPath.Settings + "\\Door\\Door.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Door Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "<buDoor.varDoorSettings>");
      StringList1.AddRange((ICollection) buDoor.varDoorSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buDoor.varDoorSettings>");
      StringList1.Add((object) "<buDoor.varDoorRunSettings>");
      StringList1.AddRange((ICollection) buDoor.varDoorRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buDoor.varDoorRunSettings>");
      buFile.SaveToFile(StringList1, FileName1);
      buLog.addLog("Door Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      buMWDoorVars.varCamCommon.mwPar.Serialize(AppPath.Settings + "\\Door\\mwDoorCommon.bin");
      string FileName2 = AppPath.Settings + "\\Door\\DoorCam.bucamset";
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "   MW Cam Settings");
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "<MwCamSettings>");
      StringList2.AddRange((ICollection) buMWDoorVars.varCamCommon.buPar.ToDefAll("_varCamCommon", 2, SerilizationMode5.MultiLine));
      StringList2.Add((object) "</MwCamSettings>");
      buFile.SaveToFile(StringList2, FileName2);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenDoorFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Door\\Door.prm");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<buDoor.varDoorSettings>", "</buDoor.varDoorSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buDoor.varDoorSettings);
            buLog.addLog("Door Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<buDoor.varDoorRunSettings>", "</buDoor.varDoorRunSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buDoor.varDoorRunSettings);
            buLog.addLog("Door varDoorRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Door Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Printer3D Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Door Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Door Settings File Missing");
      }
      buLog.addLog("Door Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Door\\mwDoorCommon.bin");
      if (fileInfo2.Exists)
        buMWDoorVars.varCamCommon.mwPar.Deserialize(fileInfo2.FullName);
      string str = AppPath.Settings + "\\Door\\DoorCam.bucamset";
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
          buSerilization5.Decode(StringList, "_varCamCommon", SerilizationMode5.MultiLine, (object) buMWDoorVars.varCamCommon.buPar);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Door Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Door Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Door Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Door Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void SaveDoorJobFile(string FileName, DoorJob Job)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      List<string> stringList = new List<string>();
      StringList.Add((object) "<Job>");
      StringList.Add((object) "  <Material>");
      StringList.Add((object) ("    Name;" + Job.Name));
      StringList.Add((object) ("    Width;" + Job.Material.Size.Height.ToString()));
      StringList.Add((object) ("    Length;" + Job.Material.Size.Width.ToString()));
      StringList.Add((object) ("    Height;" + Job.Material.Size.Depth.ToString()));
      StringList.Add((object) "  </Material>");
      StringList.Add((object) "  <Items>");
      for (int index = 0; index <= Job.Items.Count - 1; ++index)
      {
        if (Job.Items[index].ShapeGroup == ShapeGroup.Shape)
          StringList.AddRange((ICollection) Job.Items[index].ToDef(6));
      }
      StringList.Add((object) "  </Items>");
      StringList.Add((object) "</Job>");
      buFile5.SaveToFile(StringList, FileName);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void OpenDoorJobFile(string FileName, ref DoorJob Job)
  {
    try
    {
      List<string> StringList = new List<string>();
      List<string> stringList = new List<string>();
      List<string> CalcList1 = new List<string>();
      List<List<string>> CalcList2 = new List<List<string>>();
      buFile5.OpenFromFile(FileName, ref StringList);
      buString5.ListToSpecificList("<Material>", "</Material>", false, StringList, ref CalcList1);
      buString5.ListToSpecificList("<buShape>", "</buShape>", false, StringList, ref CalcList2);
      for (int index = 0; index <= CalcList1.Count - 1; ++index)
      {
        string[] strArray = CalcList1[index].Split(';');
        if (strArray != null && strArray.Length >= 2)
        {
          if (strArray[0].ToLower().IndexOf("name") >= 0)
            Job.Name = strArray[1];
          if (strArray[0].ToLower().IndexOf("width") >= 0 && buNumeric5.IsNumeric(strArray[1]))
            Job.Material.Size.Height = double.Parse(strArray[1]);
          if (strArray[0].ToLower().IndexOf("length") >= 0 && buNumeric5.IsNumeric(strArray[1]))
            Job.Material.Size.Width = double.Parse(strArray[1]);
          if (strArray[0].ToLower().IndexOf("height") >= 0 && buNumeric5.IsNumeric(strArray[1]))
            Job.Material.Size.Depth = double.Parse(strArray[1]);
        }
      }
      Job.Items.Clear();
      Job.Cams.Clear();
      Job.Material.Entities.Clear();
      if (Job.Material.Entities.Count >= 0)
      {
        Entity entDoor = (Entity) null;
        clsInit.cDoor.CreateDoorEntityFromMaterial(Job.Material, ref entDoor);
        Job.Material.Entities.Add(entDoor);
        Job.panelEntity = entDoor;
      }
      bool secondToolEnable = buDoor.varDoorRunSettings.SecondToolEnable;
      int secondToolNo = buDoor.varDoorRunSettings.SecondToolNo;
      for (int index1 = 0; index1 <= CalcList2.Count - 1; ++index1)
      {
        buShape refShape = buShape.Decode(CalcList2[index1]);
        if ((refShape.SecondToolName == null ? 0 : (refShape.SecondToolName.Trim().Length > 0 ? 1 : 0)) != 0)
        {
          for (int index2 = 0; index2 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index2)
          {
            if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index1].Limits.PlaneFront & ccVars.Tools[ccVars.ToolGroupIndex].Tools[index1].Data.Name == refShape.SecondToolName.Trim())
            {
              buDoor.varDoorRunSettings.SecondToolNo = ccVars.Tools[ccVars.ToolGroupIndex].Tools[index1].Data.No;
              buDoor.varDoorRunSettings.SecondToolEnable = true;
            }
          }
        }
        else
          buDoor.varDoorRunSettings.SecondToolEnable = false;
        ShapeUpdateArg Data2 = new ShapeUpdateArg();
        Data2.Parameters.pntBase.X = refShape.BasePoint.X;
        Data2.Parameters.pntBase.Y = refShape.BasePoint.Y;
        Data2.Parameters.pntBase.Z = refShape.BasePoint.Z;
        buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = refShape.BasePoint.X;
        buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = refShape.BasePoint.Y;
        buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = refShape.BasePoint.Z;
        if (this.shapeCreateParameters_0.entitiesCurve == null)
          this.shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
        this.shapeCreateParameters_0.entitiesCurve.Clear();
        if ((refShape.entitiesRef == null ? 0 : (refShape.entitiesRef.Count > 0 ? 1 : 0)) != 0)
          buEntity.Copy(refShape.entitiesRef, ref this.shapeCreateParameters_0.entitiesCurve);
        this.ShapeChanged((object) refShape, (object) Data2);
        this.ShapeCam(ref refShape);
        clsDoor.activeJob.Items.Add(refShape);
      }
      buDoor.varDoorRunSettings.SecondToolEnable = secondToolEnable;
      buDoor.varDoorRunSettings.SecondToolNo = secondToolNo;
      this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
      this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
      this.DoorTreeUpdate();
      this.SaveDoorFile();
      clsInit.appCommand.Reset();
      ccVars.Pages[ccVars.PageIndex].Form.Text = buFile5.getFileName(FileName);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void NewPageExtension()
  {
    this.timNew.Interval = 100;
    this.timNew.Enabled = true;
    this.DoorTreeUpdate();
  }

  public void NewPageTick(object sender, EventArgs e)
  {
    this.timNew.Enabled = false;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
      clsItem.ModelMainPreview.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
    ccVars.activeMaterial.Size.Width = buDoor.varDoorRunSettings.MaterialWidth;
    ccVars.activeMaterial.Size.Height = buDoor.varDoorRunSettings.MaterialHeight;
    ccVars.activeMaterial.Size.Depth = buDoor.varDoorRunSettings.MaterialDepth;
    ccVars.activeMaterial.FrontAngle = buDoor.varDoorRunSettings.MaterialFrontAngle;
    ccVars.activeMaterial.BackAngle = buDoor.varDoorRunSettings.MaterialBackAngle;
    ccVars.activeMaterial.Purpose = buDoor.varDoorRunSettings.MaterailPurpuse;
    this.AddPanel(ccVars.activeMaterial);
  }

  public void PageClosed() => this.DoorTreeUpdate();

  public void AddPanel(MaterialBase5 Mat)
  {
    if (ccVars.Pages.Count <= 0)
      return;
    clsDoor.activeJob = new DoorJob();
    clsDoor.activeJob.Items = new List<buShape>();
    clsDoor.activeJob.Material = new MaterialBase5(Mat);
    clsDoor.activeJob.Material.Entities.Clear();
    Entity entDoor = (Entity) null;
    if (ccVars.activeMaterial.Purpose == MaterialPurpose.Door)
    {
      clsInit.cDoor.CreateDoorEntityFromMaterial(ccVars.activeMaterial, ref entDoor);
      clsDoor.activeJob.panelEntity = entDoor;
      clsDoor.activeJob.Material.Entities.Add(entDoor);
    }
    else
    {
      Entity entCase1 = (Entity) null;
      Entity entCase2 = (Entity) null;
      clsInit.cDoor.CreateCaseEntityFromMaterial(new SizeObject(buDoor.varDoorRunSettings.Case1Width, buDoor.varDoorRunSettings.Case1Height, buDoor.varDoorRunSettings.Case1Depth), new SizeObject(buDoor.varDoorRunSettings.Case2Width, buDoor.varDoorRunSettings.Case2Height, buDoor.varDoorRunSettings.Case2Depth), ccVars.activeMaterial.Display.SkinColor, buDoor.varDoorRunSettings.CaseSpace, ref entCase1, ref entCase2);
      clsDoor.activeJob.panelEntity = entCase1;
      clsDoor.activeJob.panelEntity2 = entCase1;
      clsDoor.activeJob.Material.Entities.Add(entCase1);
      clsDoor.activeJob.Material.Entities.Add(entCase2);
      clsDoor.activeJob.Material.Size = new SizeObject(buDoor.varDoorRunSettings.Case1Width, buDoor.varDoorRunSettings.Case1Height + buDoor.varDoorRunSettings.Case2Height + buDoor.varDoorRunSettings.CaseSpace, buDoor.varDoorRunSettings.Case1Depth);
    }
    this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
    this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
    clsInit.appCommand.PagesUpdate(true, "");
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.SetView(viewType.Trimetric);
    clsInit.appCommand.cmdViewZoomFit();
    clsInit.appCommand.cmdViewZoomOut();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    this.DoorTreeUpdate();
  }

  public void EditPanel(MaterialBase5 Mat)
  {
    List<buShape> buShapeList = new List<buShape>();
    for (int index = 0; index <= clsDoor.activeJob.Items.Count - 1; ++index)
      buShapeList.Add(buShape.Copy(clsDoor.activeJob.Items[index]));
    clsDoor.activeJob.Items.Clear();
    clsDoor.activeJob.Cams.Clear();
    clsDoor.activeJob.Material.Entities.Clear();
    clsDoor.activeJob.Material = new MaterialBase5(Mat);
    if (clsDoor.activeJob.Material.Entities.Count >= 0)
    {
      Entity entDoor = (Entity) null;
      clsInit.cDoor.CreateDoorEntityFromMaterial(Mat, ref entDoor);
      clsDoor.activeJob.Material.Entities.Add(entDoor);
      clsDoor.activeJob.panelEntity = entDoor;
    }
    bool secondToolEnable = buDoor.varDoorRunSettings.SecondToolEnable;
    int secondToolNo = buDoor.varDoorRunSettings.SecondToolNo;
    for (int index1 = 0; index1 <= buShapeList.Count - 1; ++index1)
    {
      buShape Data1 = buShape.Copy(buShapeList[index1]);
      Data1.entitiesShape.Clear();
      Data1.Cam = new camTp();
      Data1.entitiesCam.Clear();
      if ((Data1.SecondToolName == null ? 0 : (Data1.SecondToolName.Trim().Length > 0 ? 1 : 0)) != 0)
      {
        for (int index2 = 0; index2 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index2)
        {
          if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index1].Limits.PlaneFront & ccVars.Tools[ccVars.ToolGroupIndex].Tools[index1].Data.Name == Data1.SecondToolName.Trim())
          {
            buDoor.varDoorRunSettings.SecondToolNo = ccVars.Tools[ccVars.ToolGroupIndex].Tools[index1].Data.No;
            buDoor.varDoorRunSettings.SecondToolEnable = true;
          }
        }
      }
      else
        buDoor.varDoorRunSettings.SecondToolEnable = false;
      ShapeUpdateArg Data2 = new ShapeUpdateArg();
      Data2.Parameters.pntBase.X = Data1.BasePoint.X;
      Data2.Parameters.pntBase.Y = Data1.BasePoint.Y;
      Data2.Parameters.pntBase.Z = Data1.BasePoint.Z;
      buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = Data1.BasePoint.X;
      buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = Data1.BasePoint.Y;
      buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = Data1.BasePoint.Z;
      if (this.shapeCreateParameters_0.entitiesCurve == null)
        this.shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
      this.shapeCreateParameters_0.entitiesCurve.Clear();
      this.shapeCreateParameters_0.DepthLevel.Clear();
      Data2.Parameters.DepthLevels.Clear();
      Data2.Parameters.DepthLevels.AddRange((IEnumerable<double>) Data1.DepthLevel);
      if ((Data1.entitiesRef == null ? 0 : (Data1.entitiesRef.Count > 0 ? 1 : 0)) != 0)
        buEntity.Copy(Data1.entitiesRef, ref this.shapeCreateParameters_0.entitiesCurve);
      Data2.Finished = true;
      this.ShapeChanged((object) Data1, (object) Data2);
    }
    buDoor.varDoorRunSettings.SecondToolEnable = secondToolEnable;
    buDoor.varDoorRunSettings.SecondToolNo = secondToolNo;
    this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
    this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
    this.DoorTreeUpdate();
    this.SaveDoorFile();
    clsInit.appCommand.Reset();
  }

  public void DrawPanelFromJob(DoorJob Job, ViewportDrawOptions Options)
  {
    try
    {
      Design design = (Design) null;
      if (Options.ViewportRef == ViewportRefType.Main)
        design = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
      else if (Options.ViewportRef == ViewportRefType.Operation)
        design = clsItem.FrmShapeList.viewportLayout;
      else if (Options.ViewportRef == ViewportRefType.Preview)
        design = clsItem.ModelMainPreview;
      design.Entities.Clear();
      if (Job == null)
      {
        design.Invalidate();
      }
      else
      {
        Entity copiedEntity1 = (Entity) null;
        if (Job.Material.Entities.Count > 0)
        {
          buEntity.Copy(Job.Material.Entities[0], ref copiedEntity1);
          copiedEntity1.LayerName = buDoor.varTemps.layerPanel;
          copiedEntity1.ColorMethod = colorMethodType.byEntity;
          copiedEntity1.Color = Color.FromArgb(150, buDoor.varDoorSettings.colorPanel);
          copiedEntity1.Selectable = false;
          design.Entities.Add(copiedEntity1);
          if (Job.Material.Entities.Count >= 2)
          {
            Entity copiedEntity2 = (Entity) null;
            buEntity.Copy(Job.Material.Entities[1], ref copiedEntity2);
            copiedEntity2.LayerName = buDoor.varTemps.layerPanel;
            copiedEntity2.ColorMethod = colorMethodType.byEntity;
            copiedEntity2.Color = Color.FromArgb(150, buDoor.varDoorSettings.colorPanel);
            copiedEntity2.Selectable = false;
            design.Entities.Add(copiedEntity2);
          }
          if (Options.DrawItems)
          {
            for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
            {
              buShape buShape = Job.Items[index1];
              this.shapeCreateParameters_0.Solid = true;
              for (int index2 = 0; index2 <= buShape.entitySolid.Count - 1; ++index2)
              {
                Entity copiedEntity3 = (Entity) null;
                buEntity.Copy(buShape.entitySolid[index2], ref copiedEntity3);
                copiedEntity3.LayerName = buDoor.varTemps.layerOperation;
                copiedEntity3.ColorMethod = colorMethodType.byEntity;
                copiedEntity3.Color = Color.FromArgb(160 /*0xA0*/, buDoor.varDoorSettings.colorOperation);
                copiedEntity3.Selectable = false;
                if (Job.Material.FrontAngle != 0.0 & Job.Items[index1].planeName == planeBoxNames.Front)
                {
                  Point3D point3D1 = new Point3D(0.0, 0.0, Job.Material.Size.Depth);
                  copiedEntity3.Rotate(buConversion5.DegreeToRadian(Job.Material.FrontAngle), Vector3D.AxisX, point3D1);
                  Point3D point3D2 = buVector5.ToPoint3D(buShape.CalculatedPoint);
                  clsInit.cVector5.Rotate(point3D1, Job.Material.FrontAngle, Plane.YZ, ref point3D2);
                  double dz = buShape.BasePoint.Z - point3D2.Z;
                  double num = dz * Math.Tan(buConversion5.DegreeToRadian(Job.Material.FrontAngle));
                  copiedEntity3.Translate(0.0, -num, dz);
                }
                if (Job.Material.BackAngle != 0.0 & Job.Items[index1].planeName == planeBoxNames.Back)
                {
                  Point3D point3D3 = new Point3D(0.0, Job.Material.Size.Height, Job.Material.Size.Depth);
                  copiedEntity3.Rotate(buConversion5.DegreeToRadian(-Job.Material.BackAngle), Vector3D.AxisX, point3D3);
                  Point3D point3D4 = buVector5.ToPoint3D(buShape.CalculatedPoint);
                  clsInit.cVector5.Rotate(point3D3, Job.Material.BackAngle, Plane.YZ, ref point3D4);
                  double dz = buShape.BasePoint.Z - point3D4.Z;
                  double dy = dz * Math.Tan(buConversion5.DegreeToRadian(Job.Material.BackAngle));
                  copiedEntity3.Translate(0.0, dy, dz);
                }
                design.Entities.Add(copiedEntity3);
              }
              for (int index3 = 0; index3 <= buShape.entitiesShape.Count - 1; ++index3)
              {
                Entity copiedEntity4 = (Entity) null;
                buEntity.Copy(buShape.entitiesShape[index3], ref copiedEntity4);
                copiedEntity4.LayerName = buDoor.varTemps.layerOperation;
                copiedEntity4.ColorMethod = colorMethodType.byEntity;
                copiedEntity4.Color = Color.FromArgb((int) byte.MaxValue, buDoor.varDoorSettings.colorOperation);
                copiedEntity4.Selectable = false;
                if (Job.Material.FrontAngle != 0.0 & Job.Items[index1].planeName == planeBoxNames.Front)
                {
                  Point3D point3D5 = new Point3D(0.0, 0.0, Job.Material.Size.Depth);
                  copiedEntity4.Rotate(buConversion5.DegreeToRadian(Job.Material.FrontAngle), Vector3D.AxisX, point3D5);
                  Point3D point3D6 = buVector5.ToPoint3D(buShape.CalculatedPoint);
                  clsInit.cVector5.Rotate(point3D5, Job.Material.FrontAngle, Plane.YZ, ref point3D6);
                  double dz = buShape.BasePoint.Z - point3D6.Z;
                  double num = dz * Math.Tan(buConversion5.DegreeToRadian(Job.Material.FrontAngle));
                  copiedEntity4.Translate(0.0, -num, dz);
                }
                if (Job.Material.BackAngle != 0.0 & Job.Items[index1].planeName == planeBoxNames.Back)
                {
                  Point3D point3D7 = new Point3D(0.0, Job.Material.Size.Height, Job.Material.Size.Depth);
                  copiedEntity4.Rotate(buConversion5.DegreeToRadian(-Job.Material.BackAngle), Vector3D.AxisX, point3D7);
                  Point3D point3D8 = buVector5.ToPoint3D(buShape.CalculatedPoint);
                  clsInit.cVector5.Rotate(point3D7, Job.Material.BackAngle, Plane.YZ, ref point3D8);
                  double dz = buShape.BasePoint.Z - point3D8.Z;
                  double dy = dz * Math.Tan(buConversion5.DegreeToRadian(Job.Material.BackAngle));
                  copiedEntity4.Translate(0.0, dy, dz);
                }
                design.Entities.Add(copiedEntity4);
              }
              if (Job.Items[index1].Cam != null)
              {
                for (int index4 = 0; index4 <= Job.Items[index1].Cam.EntitiesG1.Count - 1; ++index4)
                {
                  Entity copiedEntity5 = (Entity) null;
                  buEntity.Copy(Job.Items[index1].Cam.EntitiesG1[index4], ref copiedEntity5);
                  copiedEntity5.ColorMethod = colorMethodType.byEntity;
                  copiedEntity5.Color = Color.Red;
                  copiedEntity5.LineWeight = 3f;
                  copiedEntity5.LineWeightMethod = colorMethodType.byEntity;
                  copiedEntity5.LayerName = buDoor.varTemps.layerCam;
                  copiedEntity5.Selectable = false;
                  copiedEntity5.Regen(0.01);
                  design.Entities.Add(copiedEntity5);
                }
              }
            }
          }
          if (Options.OtherEntities != null)
          {
            for (int index = 0; index <= Options.OtherEntities.Count - 1; ++index)
            {
              Options.OtherEntities[index].Selectable = false;
              design.Entities.Add(Options.OtherEntities[index]);
            }
          }
        }
        design.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
        design.ActiveViewport.DisplayMode = displayType.Flat;
        if (Options.ViewportRef != ViewportRefType.Main)
        {
          if (Options.ViewportRef == ViewportRefType.Operation)
          {
            if (design.Entities.Count >= 2)
            {
              design.Entities[design.Entities.Count - 2].Selected = true;
              design.Entities[design.Entities.Count - 1].Selected = true;
              design.ZoomFit(true);
              design.Entities[design.Entities.Count - 2].Selected = false;
              design.Entities[design.Entities.Count - 1].Selected = false;
            }
          }
          else if (Options.ViewportRef == ViewportRefType.Preview)
          {
            design.SetView(viewType.Dimetric);
            design.ZoomFit(5);
          }
        }
        design.Invalidate();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void FindSecondTool(planeBoxNames planeName, ref ToolBase5 SecondTool)
  {
    SecondTool = (ToolBase5) null;
    if (!buDoor.varDoorRunSettings.SecondToolEnable)
      return;
    if (planeName == planeBoxNames.Front)
    {
      for (int index = 0; index <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index)
      {
        if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].Limits.PlaneFront & ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].Data.No == buDoor.varDoorRunSettings.SecondToolNo)
          SecondTool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index]);
      }
    }
    if (planeName == planeBoxNames.Back)
    {
      for (int index = 0; index <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index)
      {
        if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].Limits.PlaneBack & ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].Data.No == buDoor.varDoorRunSettings.SecondToolNo)
          SecondTool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index]);
      }
    }
    if (planeName != planeBoxNames.Top)
      return;
    for (int index = 0; index <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index)
    {
      if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].Limits.PlaneTop & ccVars.Tools[ccVars.ToolGroupIndex].Tools[index].Data.No == buDoor.varDoorRunSettings.SecondToolNo)
        SecondTool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index]);
    }
  }

  public void ShapeCam(ref buShape refShape)
  {
    clsMW.CamEntities = new List<Entity>();
    int num1 = 0;
    ToolBase5 SecondTool = (ToolBase5) null;
    if (buDoor.varDoorRunSettings.SecondToolEnable)
    {
      this.FindSecondTool(refShape.planeName, ref SecondTool);
      if (SecondTool != null)
      {
        refShape.SecondToolName = SecondTool.Data.Name;
        num1 = 1;
      }
    }
    for (int index1 = 0; index1 <= num1; ++index1)
    {
      for (int index2 = 0; index2 <= refShape.entitiesShape.Count - 1; ++index2)
      {
        Pnt6D refPoint = new Pnt6D();
        bool flag1 = false;
        buEntity refEntity = buEntity.Copy(refShape.entitiesShape[index2]);
        if (!buCompare5.EQ(refEntity.StartPoint, refEntity.EndPoint))
          clsInit.cVector5.ExtendEntitiesIfOpenContour(ref refEntity, refShape.planeOperation, refShape.CamPar.LeadIn.Length, refShape.CamPar.LeadOut.Length);
        ClockDirectionType clockDirection = clsInit.cVector5.GetClockDirection(refEntity, Plane.XZ);
        if (buMWDoorVars.varCamCommon.buPar.Operations.Direction != clockDirection)
        {
          buEntity ChangedEntities = refEntity;
          clsInit.cVector5.ChangeEntitiesDirection(ref ChangedEntities);
        }
        clsMW.CamEntities.Clear();
        clsMW.CamEntities = new List<Entity>();
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(refEntity, ref copiedEntity);
        if (!buCompare5.EQ(refEntity.StartPoint, refEntity.EndPoint) && refShape.CamPar.Pockets.Enable && copiedEntity is CompositeCurve)
        {
          Line line = new Line(refEntity.EndPoint, refEntity.StartPoint);
          ((CompositeCurve) copiedEntity).CurveList.Add((ICurve) line);
          copiedEntity.Regen(0.01);
        }
        if (refShape.planeName == planeBoxNames.Front)
          copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
        if (refShape.planeName == planeBoxNames.Back)
          copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
        copiedEntity.Regen(0.01);
        if (copiedEntity is Circle)
        {
          ToolBase5 toolBase5 = (ToolBase5) null;
          if (refShape.planeName == planeBoxNames.Front)
          {
            for (int index3 = 0; index3 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index3)
            {
              if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index3].Limits.PlaneFront)
                toolBase5 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index3]);
            }
          }
          if (refShape.planeName == planeBoxNames.Back)
          {
            for (int index4 = 0; index4 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index4)
            {
              if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index4].Limits.PlaneBack)
                toolBase5 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index4]);
            }
          }
          if (refShape.planeName == planeBoxNames.Top)
          {
            for (int index5 = 0; index5 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index5)
            {
              if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index5].Limits.PlaneTop)
                toolBase5 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index5]);
            }
          }
          if (toolBase5 != null && buCompare5.EQ(toolBase5.Geometry.Diameter, ((Circle) copiedEntity).Diameter, 0.1))
          {
            flag1 = true;
            refPoint = new Pnt6D(((Circle) copiedEntity).Center.X, ((Circle) copiedEntity).Center.Y, ((Circle) copiedEntity).Center.Z);
          }
        }
        clsMW.CamEntities.Add(copiedEntity);
        ToolBase5 toolBase5_1 = (ToolBase5) null;
        if (clsMW.CamEntities.Count > 0)
        {
          camTp Cam = new camTp();
          MWCalculationOptions MWCalcoptions = new MWCalculationOptions();
          MWCalcoptions.NumberofAxis = 3;
          MWCalcoptions.Mode = CamMode.WireFrame;
          MWCalcoptions.DontApplyReset = true;
          MWCalcoptions.isBuWireframeCalculation = false;
          MWCalcoptions.AddToCamListInLocalCalculation = false;
          MWCalcoptions.AddToCamListInMWCalculation = false;
          MWCalcoptions.ShowLeadInOutPage = false;
          MWCalcoptions.DontShowDialogBox = true;
          double depth = refShape.Depth;
          if (index2 >= 1 && refShape.DepthLevel.Count >= 2)
            depth = refShape.DepthLevel[1];
          MWCalcoptions.Depth = depth;
          if (refShape.planeName == planeBoxNames.Front)
          {
            MWCalcoptions.StartZ = 0.0;
            MWCalcoptions.Height = -depth;
            for (int index6 = 0; index6 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index6)
            {
              if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index6].Limits.PlaneFront & toolBase5_1 == null)
                toolBase5_1 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index6]);
            }
            if (clsDoor.activeJob.Material.FrontAngle != 0.0)
              MWCalcoptions.isPointDistrubition = true;
          }
          if (refShape.planeName == planeBoxNames.Back)
          {
            MWCalcoptions.StartZ = 0.0;
            MWCalcoptions.Height = -depth;
            for (int index7 = 0; index7 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index7)
            {
              if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index7].Limits.PlaneBack & toolBase5_1 == null)
                toolBase5_1 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index7]);
            }
            if (clsDoor.activeJob.Material.BackAngle != 0.0)
              MWCalcoptions.isPointDistrubition = true;
          }
          if (refShape.planeName == planeBoxNames.Top)
          {
            MWCalcoptions.StartZ = clsDoor.activeJob.Material.Size.Depth;
            MWCalcoptions.Height = clsDoor.activeJob.Material.Size.Depth - depth;
            for (int index8 = 0; index8 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; ++index8)
            {
              if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[index8].Limits.PlaneTop & toolBase5_1 == null)
                toolBase5_1 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[index8]);
            }
          }
          if (refShape.planeName == planeBoxNames.Top)
          {
            MWCalcoptions.RapidDistance = clsDoor.activeJob.Material.Size.Depth - MWCalcoptions.Height + buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
            MWCalcoptions.SafeDistance = clsDoor.activeJob.Material.Size.Depth + buMWDoorVars.varCamCommon.buPar.Distances.Safe;
          }
          else
          {
            MWCalcoptions.RapidDistance = MWCalcoptions.Height + buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
            if (MWCalcoptions.RapidDistance < 0.0)
              MWCalcoptions.RapidDistance = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
            MWCalcoptions.RapidDistance = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
            MWCalcoptions.SafeDistance = buMWDoorVars.varCamCommon.buPar.Distances.Safe;
          }
          if (toolBase5_1 != null)
          {
            refShape.Tool = new ToolBase5(toolBase5_1);
            bool flag2 = refShape.CamPar.Pockets.Enable;
            if ((index1 != 1 ? 0 : (SecondTool != null ? 1 : 0)) != 0)
            {
              flag2 = false;
              toolBase5_1 = new ToolBase5(SecondTool);
            }
            if (!flag2)
            {
              MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
              if (!flag1)
              {
                this.doWireframeContour(MWCalcoptions, toolBase5_1, ref Cam);
              }
              else
              {
                MWCalcoptions.SafeDistance = clsDoor.activeJob.Material.Size.Depth + buMWDoorVars.varCamCommon.buPar.Distances.Safe;
                this.doDrill(refPoint, refShape.planeName, MWCalcoptions, toolBase5_1, ref Cam);
              }
              if (Cam.CamPoints.Count > 0 && Cam.CamPoints[0].Points.Count > 0)
              {
                if (!buDoor.varDoorSettings.GoFirstXYZSameTime)
                {
                  TpPnt9D tpPnt9D = new TpPnt9D(Cam.CamPoints[0].Points[0]);
                  Cam.CamPoints[0].Points[0].EnableAxes.Z = false;
                  tpPnt9D.PlungeAxisMovement = true;
                  Cam.CamPoints[0].Points.Insert(1, tpPnt9D);
                }
                if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].PlungeAxisMovement)
                  Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].Type = 0;
                if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].PlungeAxisMovement)
                  Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].Type = 0;
              }
            }
            else
            {
              MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
              this.doWireframeRough(MWCalcoptions, toolBase5_1, ref Cam);
              if (Cam.CamPoints.Count > 0 && Cam.CamPoints[0].Points.Count > 0)
              {
                if (!buDoor.varDoorSettings.GoFirstXYZSameTime)
                {
                  TpPnt9D tpPnt9D = new TpPnt9D(Cam.CamPoints[0].Points[0]);
                  Cam.CamPoints[0].Points[0].EnableAxes.Z = false;
                  tpPnt9D.PlungeAxisMovement = true;
                  Cam.CamPoints[0].Points.Insert(1, tpPnt9D);
                }
                if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].PlungeAxisMovement)
                  Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].Type = 0;
                if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].PlungeAxisMovement)
                  Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].Type = 0;
              }
            }
            if (refShape.planeName == planeBoxNames.Top)
            {
              Cam.EntitiesG1.Clear();
              clsInit.cCam5.CamPointsToEntities(Cam, ref Cam.EntitiesG1);
            }
            if (refShape.planeName == planeBoxNames.Front)
            {
              List<camTpPoint> camPoints = Cam.CamPoints;
              clsInit.cCam5.ChangeCamPointCoordinates(ref camPoints, CamPointChangeMethod.XYZToXZY);
              if (clsDoor.activeJob.Material.FrontAngle != 0.0)
              {
                for (int index9 = 0; index9 <= Cam.CamPoints.Count - 1; ++index9)
                {
                  for (int index10 = 0; index10 <= Cam.CamPoints[index9].Points.Count - 1; ++index10)
                  {
                    TpPnt9D point = Cam.CamPoints[index9].Points[index10];
                    Point3D CenterPoint = new Point3D(0.0, 0.0, clsDoor.activeJob.Material.Size.Depth);
                    Point3D point3D = buVector5.ToPoint3D(refShape.CalculatedPoint);
                    if (buDoor.varDoorSettings.UseAngles)
                    {
                      clsInit.cVector5.Rotate(CenterPoint, -clsDoor.activeJob.Material.FrontAngle, Plane.YZ, ref point3D);
                      clsInit.cVector5.Rotate(CenterPoint, -clsDoor.activeJob.Material.FrontAngle, Plane.YZ, ref point);
                      double dZ = refShape.BasePoint.Z - point3D.Z;
                      double num2 = dZ * Math.Tan(buConversion5.DegreeToRadian(-clsDoor.activeJob.Material.FrontAngle));
                      clsInit.cVector5.Move(0.0, -num2, dZ, ref point);
                    }
                  }
                }
              }
              Cam.EntitiesG1.Clear();
              clsInit.cCam5.CamPointsToEntities(Cam, ref Cam.EntitiesG1);
              clsInit.cVector5.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref Cam.EntitiesG1);
            }
            if (refShape.planeName == planeBoxNames.Back)
            {
              List<camTpPoint> camPoints = Cam.CamPoints;
              clsInit.cCam5.ChangeCamPointCoordinates(ref camPoints, CamPointChangeMethod.XYZToXZY);
              if (clsDoor.activeJob.Material.BackAngle != 0.0)
              {
                for (int index11 = 0; index11 <= Cam.CamPoints.Count - 1; ++index11)
                {
                  for (int index12 = 0; index12 <= Cam.CamPoints[index11].Points.Count - 1; ++index12)
                  {
                    TpPnt9D point = Cam.CamPoints[index11].Points[index12];
                    Point3D CenterPoint = new Point3D(0.0, 0.0, clsDoor.activeJob.Material.Size.Depth);
                    Point3D Points = new Point3D(refShape.CalculatedPoint.X, 0.0, refShape.CalculatedPoint.Z);
                    if (buDoor.varDoorSettings.UseAngles)
                    {
                      clsInit.cVector5.Rotate(CenterPoint, -clsDoor.activeJob.Material.BackAngle, Plane.YZ, ref Points);
                      clsInit.cVector5.Rotate(CenterPoint, -clsDoor.activeJob.Material.BackAngle, Plane.YZ, ref point);
                      double dZ = refShape.BasePoint.Z - Points.Z;
                      double dY = dZ * Math.Tan(buConversion5.DegreeToRadian(clsDoor.activeJob.Material.BackAngle));
                      clsInit.cVector5.Move(0.0, dY, dZ, ref point);
                    }
                  }
                }
              }
              if (SecondTool != null & index1 == 1)
              {
                for (int index13 = 0; index13 <= Cam.CamPoints.Count - 1; ++index13)
                  Cam.CamPoints[index13].isSecondHead = true;
              }
              Cam.EntitiesG1.Clear();
              clsInit.cCam5.CamPointsToEntities(Cam, ref Cam.EntitiesG1);
              clsInit.cVector5.Move(0.0, clsDoor.activeJob.Material.Size.Height, 0.0, ref Cam.EntitiesG1);
            }
            Cam.Tool.CamData.SpindleSpeed = toolBase5_1.CamData.SpindleSpeed;
            if (refShape.Cam == null)
              refShape.Cam = new camTp(Cam);
            else if (refShape.Cam.CamPoints.Count == 0)
            {
              refShape.Cam = new camTp(Cam);
            }
            else
            {
              for (int index14 = 0; index14 <= Cam.CamPoints.Count - 1; ++index14)
                refShape.Cam.CamPoints.Add(Cam.CamPoints[index14]);
              for (int index15 = 0; index15 <= Cam.EntitiesG0.Count - 1; ++index15)
                refShape.Cam.EntitiesG0.Add(Cam.EntitiesG0[index15]);
              for (int index16 = 0; index16 <= Cam.EntitiesG1.Count - 1; ++index16)
                refShape.Cam.EntitiesG1.Add(Cam.EntitiesG1[index16]);
              for (int index17 = 0; index17 <= Cam.EntitiesLeadIn.Count - 1; ++index17)
                refShape.Cam.EntitiesLeadIn.Add(Cam.EntitiesLeadIn[index17]);
              for (int index18 = 0; index18 <= Cam.EntitiesLeadOut.Count - 1; ++index18)
                refShape.Cam.EntitiesLeadOut.Add(Cam.EntitiesLeadOut[index18]);
              for (int index19 = 0; index19 <= Cam.EntitiesPlunge.Count - 1; ++index19)
                refShape.Cam.EntitiesPlunge.Add(Cam.EntitiesPlunge[index19]);
              for (int index20 = 0; index20 <= Cam.EntitiesLeave.Count - 1; ++index20)
                refShape.Cam.EntitiesLeave.Add(Cam.EntitiesLeave[index20]);
            }
          }
          else
            buString5.MessageBoxWarning(buDoor.LangDoorMessage[35]);
        }
      }
    }
  }

  public void ShapeChanged(object Data1, object Data2)
  {
    buShape Shape = Data1 as buShape;
    ShapeUpdateArg shapeUpdateArg = Data2 as ShapeUpdateArg;
    buDoor.varTemps.activePlane = Shape.planeName;
    if (!shapeUpdateArg.Finished)
    {
      ccVars.pntDrawDynamicLinesArr.Clear();
      this.shapeCreateParameters_0.Solid = false;
      this.shapeCreateParameters_0.Size = new SizeObject(clsDoor.activeJob.Material.Size);
      clsInit.cVector5.CreatebuShape(ref Shape, this.shapeCreateParameters_0);
      if (Shape.entitiesShape.Count > 0)
      {
        if (Shape.entitySolid != null)
        {
          ViewportDrawOptions Options = new ViewportDrawOptions();
          Options.OtherEntities = new List<Entity>();
          for (int index = 0; index <= Shape.entitySolid.Count - 1; ++index)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(Shape.entitySolid[index], ref copiedEntity);
            copiedEntity.Regen(0.01);
            Options.ViewportRef = ViewportRefType.Operation;
            Options.OtherEntities.Add(copiedEntity);
          }
          Options.calcPoint = new Point3D(Shape.CalculatedPoint.X, Shape.CalculatedPoint.Y, Shape.CalculatedPoint.Z);
          Options.refPoint = new Point3D(Shape.BasePoint.X, Shape.BasePoint.Y, Shape.BasePoint.Z);
          double num = Point3D.Distance(Shape.ItemSize.MinBox, Shape.ItemSize.MaxBox);
          Joint joint = new Joint(buVector5.ToPoint3D(Shape.CalculatedPoint), num * 0.05, (byte) 2);
          joint.Color = Color.Red;
          joint.ColorMethod = colorMethodType.byEntity;
          Options.OtherEntities.Add((Entity) joint);
          this.DrawPanelFromJob(clsDoor.activeJob, Options);
          if (Shape.planeName == planeBoxNames.Back)
          {
            clsItem.FrmShapeList.viewportLayout.SetView(viewType.Front);
            clsItem.FrmShapeList.viewportLayout.ZoomFit(true);
          }
          if (Shape.planeName == planeBoxNames.Front)
          {
            clsItem.FrmShapeList.viewportLayout.SetView(viewType.Front);
            clsItem.FrmShapeList.viewportLayout.ZoomFit(true);
          }
          if (Shape.planeName == planeBoxNames.Left)
          {
            clsItem.FrmShapeList.viewportLayout.SetView(viewType.Right);
            clsItem.FrmShapeList.viewportLayout.ZoomFit(true);
          }
          if (Shape.planeName == planeBoxNames.Right)
          {
            clsItem.FrmShapeList.viewportLayout.SetView(viewType.Right);
            clsItem.FrmShapeList.viewportLayout.ZoomFit(true);
          }
          if (Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom)
          {
            clsItem.FrmShapeList.viewportLayout.SetView(viewType.Top);
            clsItem.FrmShapeList.viewportLayout.ZoomFit(true);
          }
        }
        clsItem.FrmShapeList.viewportLayout.Entities.ClearSelection();
        for (int index = 0; index <= Shape.entitiesShape.Count - 1; ++index)
        {
          List<Point3D> point3DList = new List<Point3D>();
          buVector5.Copy(Shape.entitiesShape[index].Vertices, ref point3DList);
          if (Shape.planeName == planeBoxNames.Front)
            clsInit.cDoor.RotatePointAtFrontPlane(ref point3DList, Shape.BasePoint, Shape.CalculatedPoint, clsDoor.activeJob.Material.Size.Depth, clsDoor.activeJob.Material.FrontAngle);
          if (Shape.planeName == planeBoxNames.Back)
            clsInit.cDoor.RotatePointAtBackPlane(ref point3DList, Shape.BasePoint, Shape.CalculatedPoint, clsDoor.activeJob.Material.Size.Depth, clsDoor.activeJob.Material.Size.Height, clsDoor.activeJob.Material.BackAngle);
          ccVars.pntDrawDynamicLinesArr.Add(point3DList);
        }
      }
    }
    else
    {
      this.shapeCreateParameters_0.Solid = true;
      this.shapeCreateParameters_0.Size = new SizeObject(clsDoor.activeJob.Material.Size);
      Shape.BasePoint.X = shapeUpdateArg.Parameters.pntBase.X;
      Shape.BasePoint.Y = shapeUpdateArg.Parameters.pntBase.Y;
      Shape.BasePoint.Z = shapeUpdateArg.Parameters.pntBase.Z;
      buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = shapeUpdateArg.Parameters.pntBase.X;
      buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = shapeUpdateArg.Parameters.pntBase.Y;
      buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = shapeUpdateArg.Parameters.pntBase.Z;
      clsInit.cVector5.CreatebuShape(ref Shape, this.shapeCreateParameters_0);
      Shape.DepthLevel = new List<double>();
      Shape.DepthLevel.AddRange((IEnumerable<double>) shapeUpdateArg.Parameters.DepthLevels);
      buDoor.varDoorRunSettings.ShapeDataParameters = new ShapeRuntimeData(shapeUpdateArg.Parameters);
      buShape refShape = buShape.Copy(Shape);
      buDoor.varTemps.lastShape = buShape.Copy(Shape);
      refShape.ID = this.int_0;
      if (refShape.CamPar != null)
        buMWDoorVars.varCamCommon.buPar = new camParameters5(refShape.CamPar);
      this.ShapeCam(ref refShape);
      if (AppBool.EditMode)
      {
        if (this.int_1 >= 0 & this.int_1 <= clsDoor.activeJob.Items.Count - 1)
          clsDoor.activeJob.Items[this.int_1] = refShape;
      }
      else
        clsDoor.activeJob.Items.Add(refShape);
      this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
      this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
      this.DoorTreeUpdate();
      this.SaveDoorFile();
      clsInit.appCommand.Reset();
      ++this.int_0;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void ShapeCancel() => clsInit.appCommand.Reset();

  public void doEditOperation(int Index)
  {
    if (!(Index >= 0 & Index <= clsDoor.activeJob.Items.Count - 1))
      return;
    AppBool.EditMode = true;
    this.int_1 = Index;
    buShape.Copy(clsDoor.activeJob.Items[Index], ref buDoor.varTemps.lastShape);
    if (this.shapeCreateParameters_0.entitiesCurve != null)
      this.shapeCreateParameters_0.entitiesCurve.Clear();
    if ((clsDoor.activeJob.Items[Index].entitiesRef == null ? 0 : (clsDoor.activeJob.Items[Index].entitiesRef.Count > 0 ? 1 : 0)) != 0)
      buEntity.Copy(clsDoor.activeJob.Items[Index].entitiesRef, ref this.shapeCreateParameters_0.entitiesCurve);
    buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = buDoor.varTemps.lastShape.BasePoint.X;
    buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = buDoor.varTemps.lastShape.BasePoint.Y;
    buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = buDoor.varTemps.lastShape.BasePoint.Z;
    if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Rectangle)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint, ref MaxPoint);
      buDoor.varDoorRunSettings.ShapeDataParameters.RectangleWidth = ((buShapeRectangle) buDoor.varTemps.lastShape).Width;
      buDoor.varDoorRunSettings.ShapeDataParameters.RectangleHeight = ((buShapeRectangle) buDoor.varTemps.lastShape).Height;
      buDoor.varDoorRunSettings.ShapeDataParameters.RectangleRadius = ((buShapeRectangle) buDoor.varTemps.lastShape).Radius;
      buDoor.varDoorRunSettings.ShapeDataParameters.RectangleDepth = buDoor.varTemps.lastShape.Depth;
      buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
    }
    if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Circle)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint, ref MaxPoint);
      buDoor.varDoorRunSettings.ShapeDataParameters.CircleRadius = ((buShapeCircle) buDoor.varTemps.lastShape).Radius;
      buDoor.varDoorRunSettings.ShapeDataParameters.CircleDepth = buDoor.varTemps.lastShape.Depth;
      buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
    }
    if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Ellipse)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint, ref MaxPoint);
      buDoor.varDoorRunSettings.ShapeDataParameters.EllipseRadiusX = ((buShapeEllipse) buDoor.varTemps.lastShape).RadiusX;
      buDoor.varDoorRunSettings.ShapeDataParameters.EllipseRadiusY = ((buShapeEllipse) buDoor.varTemps.lastShape).RadiusY;
      buDoor.varDoorRunSettings.ShapeDataParameters.EllipseDepth = buDoor.varTemps.lastShape.Depth;
      buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
    }
    if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Slot)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint, ref MaxPoint);
      buDoor.varDoorRunSettings.ShapeDataParameters.SlotLength = ((buShapeSlot) buDoor.varTemps.lastShape).Length;
      buDoor.varDoorRunSettings.ShapeDataParameters.SlotDiameter = ((buShapeSlot) buDoor.varTemps.lastShape).Diameter;
      buDoor.varDoorRunSettings.ShapeDataParameters.SlotAngle = ((buShapeSlot) buDoor.varTemps.lastShape).Angle;
      buDoor.varDoorRunSettings.ShapeDataParameters.SlotDepth = buDoor.varTemps.lastShape.Depth;
      buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
    }
    if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.KeyHole)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint, ref MaxPoint);
      buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleDiameter = ((buShapeKeyHole) buDoor.varTemps.lastShape).Diameter;
      buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleHeadDiameter = ((buShapeKeyHole) buDoor.varTemps.lastShape).HeadDiameter;
      buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleLength = ((buShapeKeyHole) buDoor.varTemps.lastShape).Length;
      buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleAngle = ((buShapeKeyHole) buDoor.varTemps.lastShape).Angle;
      buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleDepth = buDoor.varTemps.lastShape.Depth;
      buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
    }
    if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.FreeDraw)
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint, ref MaxPoint);
      buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth = Math.Round(MaxPoint.X - MinPoint.X, 3);
      buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight = Math.Round(MaxPoint.Y - MinPoint.Y, 3);
      buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth = buDoor.varTemps.lastShape.Depth;
      buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
    }
    buDoor.varDoorRunSettings.ShapeDataParameters.selectedPlane = buDoor.varTemps.lastShape.planeName;
    this.cmdShapes();
  }

  public void doDeleteOperation(int Index)
  {
    if (!(Index >= 0 & Index <= clsDoor.activeJob.Items.Count - 1))
      return;
    clsDoor.activeJob.Items.RemoveAt(Index);
    this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
    this.DoorTreeUpdate();
    clsInit.appCommand.Reset();
  }

  public void doDeleteAllOperations()
  {
    clsDoor.activeJob.Items.Clear();
    this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
    this.DoorTreeUpdate();
    clsInit.appCommand.Reset();
  }

  public void doDeletePanel()
  {
    clsDoor.activeJob.Items.Clear();
    clsDoor.activeJob = (DoorJob) null;
    this.DrawPanelFromJob(clsDoor.activeJob, new ViewportDrawOptions());
    this.DoorTreeUpdate();
    clsInit.appCommand.Reset();
  }

  public void doReset() => AppBool.EditMode = false;

  public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWDoorVars.varCamCommon.buPar.Offsets.OpenContour = buMWDoorVars.varCamCommon.buPar.Operations.Direction != ClockDirectionType.CW ? CamOpenContourType.Left : CamOpenContourType.Right;
    buMWDoorVars.varCamCommon.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWDoorVars.varCamCommon.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWDoorVars.varCamCommon.buPar.Steps.DepthStep = MWCalcoptions.Height;
    int int32 = Convert.ToInt32(buNumeric5.RoundToUpper(Math.Abs(MWCalcoptions.Depth) / buDoor.varDoorSettings.ZDownOneTimeLimit));
    buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice = int32;
    if (buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice >= 2)
      buMWDoorVars.varCamCommon.buPar.Steps.Enable = true;
    buMWDoorVars.varCamCommon.buPar.Steps.DepthStepMode = !buMWDoorVars.varCamCommon.buPar.Steps.Enable ? CamStepDepthMode.ConstantDepthStep : CamStepDepthMode.NumberOfSlices;
    buMWDoorVars.varCamCommon.buPar.Distances.Air = 0.0;
    buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
    buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
    buMWDoorVars.varCamCommon.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
    buMWDoorVars.varCamCommon.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar);
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
    if (buMWDoorVars.varCamCommon.buPar.Steps.Enable)
      buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.StartZ;
    MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = !MWCalcoptions.isPointDistrubition ? TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution : TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
    if (ccVars.PostActive.IsArcAsLine)
      buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar, out clsMW.varbuCamWFContourPars);
    if (MWCalcoptions.RapidDistance != 0.0)
    {
      clsMW.varbuCamWFContourPars.Distances.EntryAndExit = MWCalcoptions.RapidDistance;
      clsMW.varbuCamWFContourPars.Distances.EntryAndExit = MWCalcoptions.RapidDistance;
      clsMW.varbuCamWFContourPars.Distances.Rapid = MWCalcoptions.RapidDistance;
      clsMW.varMWCamWFContourPars.MachParam.LinkParams.RetractPlaneIncremental = MWCalcoptions.RapidDistance;
      clsMW.varMWCamWFContourPars.MachParam.LinkParams.ApproachFeedPlaneIncremental = MWCalcoptions.RapidDistance;
      clsMW.varMWCamWFContourPars.MachParam.LinkParams.FeedPlaneIncremental = MWCalcoptions.RapidDistance;
    }
    if (MWCalcoptions.SafeDistance != 0.0)
    {
      clsMW.varbuCamWFContourPars.Distances.Safe = MWCalcoptions.SafeDistance;
      clsMW.varMWCamWFContourPars.MachParam.LinkParams.ClearancePlaneHeight = MWCalcoptions.SafeDistance;
    }
    clsMW.varMWCamWFContourPars.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.FromRapidPlane;
    clsMW.varMWCamWFContourPars.MachParam.LinkParams.LastExit.Type = LastExitType.BackToRapidPlane;
    clsMW.varMWCamWFContourPars.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    clsMW.varMWCamWFContourPars.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    clsMW.varMWCamWFContourPars.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    camResult Result = (camResult) null;
    if (clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result) >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doWireframeRough(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWDoorVars.varCamCommon.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWDoorVars.varCamCommon.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWDoorVars.varCamCommon.buPar.Steps.StartValue = MWCalcoptions.Height;
    buMWDoorVars.varCamCommon.buPar.Steps.EndValue = MWCalcoptions.Height;
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
    buMWDoorVars.varCamCommon.buPar.Operations.Height = MWCalcoptions.Height;
    int int32 = Convert.ToInt32(buNumeric5.RoundToUpper(Math.Abs(MWCalcoptions.Depth) / buDoor.varDoorSettings.ZDownOneTimeLimit));
    buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice = int32;
    if (buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice >= 2)
      buMWDoorVars.varCamCommon.buPar.Steps.Enable = true;
    if (buMWDoorVars.varCamCommon.buPar.Steps.Enable)
    {
      buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.StartZ;
      buMWDoorVars.varCamCommon.buPar.Steps.StartValue = MWCalcoptions.StartZ;
      buMWDoorVars.varCamCommon.buPar.Steps.EndValue = MWCalcoptions.Height;
    }
    buMWDoorVars.varCamCommon.buPar.Distances.Air = 0.0;
    buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
    buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
    buMWDoorVars.varCamCommon.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
    MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
    buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage = 70.0;
    buMWDoorVars.varCamCommon.mwPar.MachParam.MaxStepoverDistance = !(buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage > 0.0 & buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage <= 100.0) ? Tool.Geometry.Diameter : buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage / 100.0 * Tool.Geometry.Diameter;
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ReverseCuttingOrderFlg = buMWDoorVars.varCamCommon.buPar.Pockets.PocketInOut != InToOutType.OutToIn;
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = !MWCalcoptions.isPointDistrubition ? TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution : TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
    if (ccVars.PostActive.IsArcAsLine)
      buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
    buMWDoorVars.varCamCommon.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar);
    buMWDoorVars.varCamCommon.mwPar.MachParam.FeedRate = buMWDoorVars.varCamCommon.buPar.Speeds.Pocket;
    clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar, out clsMW.varbuCamWFPocketPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWDoorVars.varCamCommon.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWDoorVars.varCamCommon.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doDrill(
    Pnt6D refPoint,
    planeBoxNames planeName,
    MWCalculationOptions MWCalcoptions,
    ToolBase5 Tool,
    ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    camParameters5 copyBU = new camParameters5(buMWDoorVars.varCamCommon.buPar);
    copyBU.Offsets.OpenContour = copyBU.Operations.Direction != ClockDirectionType.CW ? CamOpenContourType.Left : CamOpenContourType.Right;
    copyBU.Runtime.SimG0DevideLength = 100.0;
    copyBU.Runtime.SimG1DevideLength = 40.0;
    copyBU.Steps.DepthStep = MWCalcoptions.Height;
    int int32 = Convert.ToInt32(buNumeric5.RoundToUpper(Math.Abs(MWCalcoptions.Depth) / buDoor.varDoorSettings.ZDownOneTimeLimit));
    copyBU.Steps.NumberOfSlice = int32;
    if (copyBU.Steps.NumberOfSlice >= 2)
      copyBU.Steps.Enable = true;
    copyBU.Steps.DepthStepMode = !copyBU.Steps.Enable ? CamStepDepthMode.ConstantDepthStep : CamStepDepthMode.NumberOfSlices;
    copyBU.Distances.Air = 0.0;
    copyBU.Distances.EntryAndExit = copyBU.Distances.Rapid;
    copyBU.Distances.EntryAndExit = copyBU.Distances.Rapid;
    copyBU.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
    buMWDoorVars.varCamCommon.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDoorVars.varCamCommon.mwPar, copyBU);
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
    buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
    if (copyBU.Steps.Enable)
      buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.StartZ;
    copyBU.Distances.RapidRetract = true;
    copyBU.Operations.Depth = MWCalcoptions.Depth;
    if (planeName == planeBoxNames.Top)
    {
      copyBU.Drill.StartHeight = clsDoor.activeJob.Material.Size.Depth;
      copyBU.Drill.EndHeight = clsDoor.activeJob.Material.Size.Depth - MWCalcoptions.Depth;
      copyBU.Distances.Safe = clsDoor.activeJob.Material.Size.Depth + copyBU.Distances.Safe;
    }
    else
    {
      copyBU.Drill.StartHeight = 0.0;
      copyBU.Drill.EndHeight = -MWCalcoptions.Depth;
    }
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDoorVars.varCamCommon.mwPar, copyBU, out clsMW.varbuCamWFContourPars);
    clsInit.cCam5.camDrill(new List<Pnt6D>() { refPoint }, Tool, new WorkPlane(), copyBU, ref Cam);
    buMWDoorVars.varCamCommon.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out copyBU);
  }
}
