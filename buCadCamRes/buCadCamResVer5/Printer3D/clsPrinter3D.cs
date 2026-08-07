// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Printer3D.clsPrinter3D
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Printer3D;
using buMW;
using buMW.Variables;
using devDept;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Printer3D;

public class clsPrinter3D
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
  private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();
  internal Slicing slicing_0;
  private Simulation simulation_0;
  private int int_6 = 0;
  public Printer3DJob activeJob = (Printer3DJob) null;

  public void Init()
  {
    buMWPrinter3DVars.Init();
    this.OpenPrinter3DFile();
    this.LoadLanguage();
    this.activeJob = new Printer3DJob();
  }

  public void InitSimulation()
  {
  }

  public void Printer3DTree_AfterSelect(object sender, TreeViewEventArgs e)
  {
    if (ccVars.Pages.Count == 0)
      ;
  }

  public void Printer3DTree_AfterCheck(object sender, TreeViewEventArgs e)
  {
    if (ccVars.Pages.Count == 0)
      ;
  }

  public void ProfileTreeUpdate()
  {
    clsItem.FrmPrinter3DJob.tree_jobs.Nodes.Clear();
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
    TreeNodeSettings node1 = treeNodeSettings1;
    TreeNodeSettings node2 = (TreeNodeSettings) null;
    for (int index = 0; index <= this.activeJob.Layers.Count - 1; ++index)
    {
      TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings(buPrinter3D.LayerToString(this.activeJob.Layers[index]));
      treeNodeSettings2.ImageIndex = 1;
      treeNodeSettings2.SelectedImageIndex = 1;
      treeNodeSettings2.Tag = (object) 0;
      treeNodeSettings2.ClassIndex = 0;
      treeNodeSettings2.ClassSubIndex = -1;
      treeNodeSettings2.ClassSubSubIndex = -1;
      treeNodeSettings2.Command = "layer";
      treeNodeSettings2.Name = "layer";
      treeNodeSettings2.Info = "layer";
      treeNodeSettings2.Index = 0;
      treeNodeSettings2.Checked = this.activeJob.Layers[index].Enable;
      node2 = treeNodeSettings2;
      node1.Nodes.Add((TreeNode) node2);
    }
    if (node2 != null)
    {
      node2.Expand();
      node1.Expand();
    }
    clsItem.FrmPrinter3DJob.tree_jobs.Nodes.Add((TreeNode) node1);
  }

  public void Checked_Checked(object sender, EventArgs e)
  {
    buPrinter3D.varPrinter3DRunSettings.SelectMode = clsItem.FrmPrinter3DJob.chk_selectmode.Checked;
    clsItem.FrmPrinter3DJob.tree_jobs.CheckBoxes = buPrinter3D.varPrinter3DRunSettings.SelectMode;
    if (buPrinter3D.varPrinter3DRunSettings.SelectMode)
      return;
    for (int index = 0; index <= clsItem.FrmPrinter3DJob.tree_jobs.Nodes.Count - 1; ++index)
      clsItem.FrmPrinter3DJob.tree_jobs.Nodes[index].Expand();
  }

  public void cmdSlice() => Class5.smethod_124(this);

  public void cmdShowPattern3D() => this.Simulate();

  public void cmdSettings()
  {
    F_Printer3DSettings printer3Dsettings = new F_Printer3DSettings();
    printer3Dsettings.Settings = new Printer3DSettings(buPrinter3D.varPrinter3DSettings);
    printer3Dsettings.Init();
    int num = (int) printer3Dsettings.ShowDialog();
    if (printer3Dsettings.PropertiesForm.Result != DialogResult.OK)
      return;
    buPrinter3D.varPrinter3DSettings = new Printer3DSettings(printer3Dsettings.Settings);
    this.SavePrinter3DFile();
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
    clsMW.CamEntities.Clear();
    camTp cam = new camTp();
    Point3D refPoint = new Point3D();
    int num1 = 0;
    List<Point3D> point3DList1 = new List<Point3D>();
    clsInit.appCommand.undoBuffer();
    List<List<Point3D>> point3DListList = new List<List<Point3D>>();
    for (int index1 = 0; index1 <= this.activeJob.Layers.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.activeJob.Layers[index1].entitiesOffsetedSlices.Count - 1; ++index2)
      {
        buEntity entitiesOffsetedSlice = this.activeJob.Layers[index1].entitiesOffsetedSlices[index2];
        buEntity buEntity = (buEntity) null;
        if (index1 < this.activeJob.Layers.Count - 1)
          buEntity = this.activeJob.Layers[index1 + 1].entitiesOffsetedSlices[index2];
        List<Point3D> List1 = new List<Point3D>();
        List<Point3D> List2 = new List<Point3D>();
        List<Point3D> point3DList2 = new List<Point3D>();
        if (num1 == 0)
        {
          List1.AddRange((IEnumerable<Point3D>) entitiesOffsetedSlice.Vertices);
          refPoint = new Point3D(List1[0].X, List1[0].Y, List1[0].Z);
        }
        else
        {
          int indexClosest1 = -1;
          int indexClosest2 = -1;
          clsInit.cVector5.FindPointClosestIndexByRefPoint(entitiesOffsetedSlice.Vertices, refPoint, ref indexClosest1);
          List1.AddRange((IEnumerable<Point3D>) entitiesOffsetedSlice.Vertices);
          if (indexClosest1 >= 0)
            clsInit.cVector5.ShiftPointList(ref List1, -indexClosest1);
          if (buEntity != null)
          {
            clsInit.cVector5.FindPointClosestIndexByRefPoint(buEntity.Vertices, List1[0], ref indexClosest2);
            List2.AddRange((IEnumerable<Point3D>) buEntity.Vertices);
            clsInit.cVector5.ShiftPointList(ref List2, -indexClosest2);
            double num2 = List2[0].X - List1[List1.Count - 1].X;
            double num3 = List2[0].Y - List1[List1.Count - 1].Y;
            if (List2.Count > 0)
            {
              num1 = 1;
              for (int index3 = List1.Count - 5; index3 <= List1.Count - 1; ++index3)
                ++num1;
            }
          }
          refPoint = new Point3D(List1[0].X, List1[0].Y, List1[0].Z);
        }
        if (buPrinter3D.varPrinter3DSettings.FilletRadius > 0.0)
        {
          clsInit.cVector5.CurvePoints(List1, buPrinter3D.varPrinter3DSettings.FilletLimitMinAngle, buPrinter3D.varPrinter3DSettings.FilletLimitMaxAngle, ref point3DList2);
        }
        else
        {
          point3DList2 = new List<Point3D>();
          buVector5.Copy(List1, ref point3DList2);
        }
        clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList2);
        if (clsInit.cVector5.GetClockDirection(point3DList2) == ClockDirectionType.CW)
          point3DList2.Reverse();
        if (buPrinter3D.varPrinter3DSettings.ZSpiralMove & index1 <= this.activeJob.Layers.Count - 2)
        {
          point3DList2.RemoveAt(point3DList2.Count - 1);
          double num4 = clsInit.cVector5.Length3D(point3DList2);
          double num5 = 0.0;
          double num6 = this.activeJob.Layers[index1 + 1].LevelZ - this.activeJob.Layers[index1].LevelZ;
          for (int index4 = 1; index4 <= point3DList2.Count - 1; ++index4)
          {
            num5 += clsInit.cVector5.Length3D(point3DList2[index4 - 1], point3DList2[index4], Plane.XY);
            double num7 = num5 / num4;
            if (num7 > 1.0)
              ;
            point3DList2[index4].Z += num7 * num6;
          }
        }
        point3DListList.Add(point3DList2);
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) point3DList2);
        ccVars.UndoDont = true;
        ++num1;
      }
    }
    if (point3DListList.Count > 0)
    {
      int num8 = 0;
      int num9 = 5;
      for (int index5 = 0; index5 <= point3DListList.Count - 1; ++index5)
      {
        if (index5 == 43)
          ;
        List<Point3D> Points1 = new List<Point3D>();
        List<Point3D> point3DList3 = new List<Point3D>();
        List<Point3D> Points2 = new List<Point3D>();
        List<Point3D> collection = new List<Point3D>();
        for (int index6 = num8; index6 <= point3DListList[index5].Count - num9; ++index6)
          Points1.Add(new Point3D(point3DListList[index5][index6].X, point3DListList[index5][index6].Y, point3DListList[index5][index6].Z));
        for (int index7 = point3DListList[index5].Count - num9; index7 <= point3DListList[index5].Count - 1; ++index7)
          Points2.Add(new Point3D(point3DListList[index5][index7].X, point3DListList[index5][index7].Y, point3DListList[index5][index7].Z));
        if (index5 < point3DListList.Count - 1)
        {
          List<Point3D> copiedPoint = new List<Point3D>();
          buVector5.Copy(point3DListList[index5 + 1], ref copiedPoint);
          double num10 = clsInit.cVector5.PointAngle(Points2[Points2.Count - 1], Points2[Points2.Count - 2]);
          clsInit.cVector5.Length2D(Points2[Points2.Count - 1], Points2[Points2.Count - 2], Plane.XY);
          double num11 = clsInit.cVector5.PointAngle(copiedPoint[0], copiedPoint[1]);
          double num12 = 180.0 - Math.Abs(num10 - num11);
          List<Point3D> point3DList4 = new List<Point3D>();
          for (int index8 = 0; index8 <= num9; ++index8)
          {
            Points2.Add(copiedPoint[index8]);
            num8 = index8;
          }
        }
        Color color = Color.Red;
        clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points2);
        if (buPrinter3D.varPrinter3DSettings.SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Linear)
        {
          buVector5.Copy(Points2, ref collection);
          color = Color.Black;
        }
        else if (buPrinter3D.varPrinter3DSettings.SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Quadratic)
        {
          clsInit.cVector5.BSplineQuadraticUniform(Points2, buPrinter3D.varPrinter3DSettings.SpiralConnectionDT, false, ref collection);
          color = Color.Blue;
        }
        else if (buPrinter3D.varPrinter3DSettings.SpiralConnection == Printer3DSpiralNextLEvelConnectionType.Cubic)
        {
          clsInit.cVector5.BSplineCubicUniform(Points2, buPrinter3D.varPrinter3DSettings.SpiralConnectionDT, false, ref collection);
          color = Color.Green;
        }
        else
          clsInit.cVector5.BezeirCurve(Points2, buPrinter3D.varPrinter3DSettings.SpiralConnectionDT, ref collection);
        if (collection.Count > 0)
        {
          Points1.AddRange((IEnumerable<Point3D>) collection);
          clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points1);
        }
        LinearPath Ent = new LinearPath((ICollection<Point3D>) Points1);
        Ent.LayerName = "OffsetSlice";
        Ent.Color = color;
        Ent.ColorMethod = colorMethodType.byEntity;
        ccVars.UndoDont = true;
        clsInit.appCommand.AddEntity((Entity) Ent);
        clsMW.CamEntities.Add((Entity) Ent);
      }
    }
    List<Entity> LayerEntities1 = new List<Entity>();
    List<Entity> LayerEntities2 = new List<Entity>();
    clsInit.cVector5.GetEntitiesByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, buPrinter3D.varTemps.layerOffsetSliceName, ref LayerEntities2);
    clsInit.cVector5.GetEntitiesByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, buPrinter3D.varTemps.layerInFill, ref LayerEntities1);
    int num13 = 0;
    while (num13 <= LayerEntities2.Count - 1)
      ++num13;
    if (!buPrinter3D.varPrinter3DSettings.ZSpiralMove)
    {
      for (int index9 = 0; index9 <= clsMW.CamEntities.Count - 1; ++index9)
      {
        camTpPoint camTpPoint = new camTpPoint();
        if (index9 > 0 && cam.CamPoints.Count > 0 & clsMW.CamEntities[index9].Vertices.Length != 0)
        {
          double z1 = clsMW.CamEntities[index9].Vertices[0].Z;
          double z2 = cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].P9.Z;
          if (z1 - z2 > 0.1)
          {
            TpPnt9D tpPnt9D = new TpPnt9D(cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1]);
            tpPnt9D.PreCodes.Clear();
            tpPnt9D.AfterCodes.Clear();
            tpPnt9D.PreCodes.Add((object) "M5");
            tpPnt9D.P9.Z = z1;
            tpPnt9D.Feed = buPrinter3D.varPrinter3DSettings.PlungeSpeed;
            tpPnt9D.Type = 1;
            camTpPoint.Points.Add(tpPnt9D);
            cam.CamPoints.Add(camTpPoint);
            camTpPoint = new camTpPoint();
          }
        }
        for (int index10 = 0; index10 <= clsMW.CamEntities[index9].Vertices.Length - 1; ++index10)
        {
          TpPnt9D tpPnt9D = new TpPnt9D(new Pnt6D(clsMW.CamEntities[index9].Vertices[index10].X, clsMW.CamEntities[index9].Vertices[index10].Y, clsMW.CamEntities[index9].Vertices[index10].Z));
          if (index10 == 0)
          {
            tpPnt9D.Type = 0;
            tpPnt9D.AfterCodes.Add((object) "M3");
          }
          else
            tpPnt9D.Type = 1;
          if (index10 > 0)
            ;
          tpPnt9D.Feed = buPrinter3D.varPrinter3DSettings.FeedSpeed;
          camTpPoint.Points.Add(tpPnt9D);
        }
        LinearPath linearPath = new LinearPath(clsMW.CamEntities[index9].Vertices);
        cam.EntitiesG1.Add((Entity) linearPath);
        if (camTpPoint.Points.Count > 0)
        {
          if (cam.CamPoints.Count > 0)
          {
            Point3D StartPoint = new Point3D(cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].P9.X, cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].P9.Y, cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].P9.Z);
            Point3D EndPoint = new Point3D(camTpPoint.Points[0].P9.X, camTpPoint.Points[0].P9.Y, camTpPoint.Points[0].P9.Z);
            if (clsInit.cVector5.Length3D(StartPoint, EndPoint, Plane.XY) > 10.0)
            {
              camTpPoint.Points[0].AfterCodes.Add((object) "M3");
              if (cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Count == 0)
                cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Add((object) "M5");
              cam.CamPoints.Add(camTpPoint);
            }
            else
              cam.CamPoints.Add(camTpPoint);
          }
          else
            cam.CamPoints.Add(camTpPoint);
        }
        cam.Tool = new ToolBase5(ccVars.toolActive);
        if (index9 == clsMW.CamEntities.Count - 1 & cam.CamPoints.Count == 0 & camTpPoint.Points.Count > 0)
        {
          camTpPoint.Points[0].AfterCodes.Add((object) "M3");
          camTpPoint.Points[camTpPoint.Points.Count - 1].AfterCodes.Add((object) "M5");
          cam.CamPoints.Add(camTpPoint);
        }
      }
    }
    else
    {
      List<Point3D> copiedPoint = new List<Point3D>();
      for (int index11 = 0; index11 <= clsMW.CamEntities.Count - 1; ++index11)
      {
        for (int index12 = 0; index12 <= clsMW.CamEntities[index11].Vertices.Length - 1; ++index12)
        {
          if (copiedPoint.Count == 0)
            copiedPoint.Add(new Point3D(clsMW.CamEntities[index11].Vertices[index12].X, clsMW.CamEntities[index11].Vertices[index12].Y, clsMW.CamEntities[index11].Vertices[index12].Z));
          else if (Point3D.Distance(copiedPoint[copiedPoint.Count - 1], clsMW.CamEntities[index11].Vertices[index12]) > 0.01)
            copiedPoint.Add(new Point3D(clsMW.CamEntities[index11].Vertices[index12].X, clsMW.CamEntities[index11].Vertices[index12].Y, clsMW.CamEntities[index11].Vertices[index12].Z));
        }
      }
      if (copiedPoint.Count > 0)
      {
        if (buPrinter3D.varPrinter3DSettings.UseSpline)
        {
          buCurve buCurve = new buCurve(2, copiedPoint);
          copiedPoint = new List<Point3D>();
          buVector5.Copy(buCurve.Vertices, ref copiedPoint);
        }
        camTpPoint camTpPoint = new camTpPoint();
        for (int index = 0; index <= copiedPoint.Count - 1; ++index)
        {
          TpPnt9D tpPnt9D = new TpPnt9D(new Pnt6D(copiedPoint[index].X, copiedPoint[index].Y, copiedPoint[index].Z));
          if (index == 0)
          {
            tpPnt9D.Type = 0;
            tpPnt9D.AfterCodes.Add((object) "M3");
          }
          else
            tpPnt9D.Type = 1;
          tpPnt9D.Feed = buPrinter3D.varPrinter3DSettings.FeedSpeed;
          camTpPoint.Points.Add(tpPnt9D);
        }
        cam.CamPoints.Add(camTpPoint);
        cam.EntitiesG1.Clear();
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) copiedPoint);
        cam.EntitiesG1.Add((Entity) linearPath);
      }
    }
    ccVars.Pages[ccVars.PageIndex].Cams.Clear();
    if (cam.CamPoints.Count > 0)
    {
      if (cam.CamPoints[0].Points[0].AfterCodes.Count == 0)
        cam.CamPoints[0].Points[0].AfterCodes.Add((object) "M3");
      if (cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Count == 0)
        cam.CamPoints[cam.CamPoints.Count - 1].Points[cam.CamPoints[cam.CamPoints.Count - 1].Points.Count - 1].AfterCodes.Add((object) "M5");
      clsInit.appCommand.CamAdd(cam, buPrinter3D.varTemps.layerCamName);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdSimStart()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Clear();
    Design viewportcad = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerOnlineSimulationName, viewportcad, this);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    clsInit.appCommand.simStart();
  }

  public void cmdSimStop()
  {
    clsInit.appCommand.simStop();
    ccVars.SimCamPointIndex = 0;
    ccVars.SimCamBaseIndex = 0;
    clsVar.varInterface.CamSimulationStep = 1;
    this.int_6 = 0;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Clear();
    Design viewportcad = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerOnlineSimulationName, viewportcad, this);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void Sim_Tick(object sender, EventArgs e)
  {
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count <= 0 || !(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Mesh) || !(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].EntityData is CustomData) || (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].EntityData as CustomData).typeDefination == entityTypeDefination.Simulation)
      ;
    if (ccVars.SimCamPointIndex == 0)
      this.int_6 = 0;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Clear();
    Thread.Sleep(5);
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1; ++index)
    {
      camTp cam = ccVars.Pages[ccVars.PageIndex].Cams[index];
      List<Point3D> points = new List<Point3D>();
      for (int int6 = this.int_6; int6 <= ccVars.SimCamPointIndex - 1; ++int6)
        points.Add(new Point3D(cam.SimilationPoint.SimMove[int6].X, cam.SimilationPoint.SimMove[int6].Y, cam.SimilationPoint.SimMove[int6].Z));
      if (points.Count > 2)
      {
        if (cam.SimilationPoint.SimMove[ccVars.SimCamPointIndex].GCode == 0)
        {
          CustomData customData = new CustomData();
          this.int_6 = ccVars.SimCamPointIndex;
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
          customData.typeDefination = entityTypeDefination.Simulation;
          Mesh mesh = linearPath.Inflate(20.0, 10.0, 180.0, 10.0);
          mesh.LayerName = buPrinter3D.varTemps.layerOnlineSimulationName;
          mesh.EntityData = (object) customData;
          mesh.Color = Color.Lime;
          mesh.ColorMethod = colorMethodType.byEntity;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh);
        }
        else
        {
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
          CustomData customData = new CustomData();
          customData.typeDefination = entityTypeDefination.Simulation;
          Mesh mesh = linearPath.Inflate(20.0, 10.0, 180.0, 10.0);
          mesh.LayerName = buPrinter3D.varTemps.layerOnlineSimulationName;
          mesh.EntityData = (object) customData;
          mesh.Color = Color.Lime;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.TempEntities.Add((Entity) mesh);
        }
      }
    }
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buPrinter3D.lng") : new FileInfo(AppPath.Language + "\\buPrinter3D.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buPrinter3D.LangPrinter3DCommands);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Printer3D Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Printer3D Language File Missing");
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

  public void SavePrinter3DFile()
  {
    try
    {
      string FileName1 = AppPath.Settings + "\\Printer3D\\Printer3D.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Printer3D Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "<buPrinter3D.varPrinter3DSettings>");
      StringList1.AddRange((ICollection) buPrinter3D.varPrinter3DSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buPrinter3D.varPrinter3DSettings>");
      StringList1.Add((object) "<buPrinter3D.varPrinter3DRunSettings>");
      StringList1.AddRange((ICollection) buPrinter3D.varPrinter3DRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</buPrinter3D.varPrinter3DRunSettings>");
      buFile.SaveToFile(StringList1, FileName1);
      buLog.addLog("Foam Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      buMWPrinter3DVars.varCamContour.mwPar.Serialize(AppPath.Settings + "\\Printer3D\\mwPrinter3DContour.bin");
      buMWPrinter3DVars.varCamRough.mwPar.Serialize(AppPath.Settings + "\\Printer3D\\mwPrinter3DRough.bin");
      string FileName2 = AppPath.Settings + "\\Printer3D\\Printer3DCam.bucamset";
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "   MW Cam Settings");
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "<MwCamSettings>");
      StringList2.AddRange((ICollection) buMWPrinter3DVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
      StringList2.AddRange((ICollection) buMWPrinter3DVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
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

  public void OpenPrinter3DFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Printer3D\\Printer3D.prm");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<buPrinter3D.varPrinter3DSettings>", "</buPrinter3D.varPrinter3DSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buPrinter3D.varPrinter3DSettings);
            buLog.addLog("Printer3D Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<buPrinter3D.varPrinter3DRunSettings>", "</buPrinter3D.varPrinter3DRunSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buPrinter3D.varPrinter3DRunSettings);
            buLog.addLog("Printer3D varDrillCNCSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Printer3D Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Printer3D Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Printer3D Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Drill Settings File Missing");
      }
      buLog.addLog("Printer3D Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Printer3D\\mwPrinter3DContour.bin");
      if (fileInfo2.Exists)
        buMWPrinter3DVars.varCamContour.mwPar.Deserialize(fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Printer3D\\mwPrinter3DRough.bin");
      if (fileInfo3.Exists)
        buMWPrinter3DVars.varCamRough.mwPar.Deserialize(fileInfo3.FullName);
      string str = AppPath.Settings + "\\Printer3D\\Printer3DCam.bucamset";
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
          buSerilization.Decode(StringList, "_varCamContour", SerilizationMode.MultiLine, (object) buMWPrinter3DVars.varCamContour);
          buSerilization.Decode(StringList, "_varCamRough", SerilizationMode.MultiLine, (object) buMWPrinter3DVars.varCamRough);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Printer 3D Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Printer 3D Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Printer 3D Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Printer 3D Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void NewPageExtension()
  {
    this.activeJob = new Printer3DJob();
    this.ProfileTreeUpdate();
  }

  public void PageClosed()
  {
    this.activeJob = new Printer3DJob();
    this.ProfileTreeUpdate();
  }

  public void Simulate()
  {
    if (this.slicing_0 == null)
      return;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == buPrinter3D.varTemps.layerSimulationName)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    this.simulation_0 = new Simulation(this.slicing_0, buPrinter3D.varPrinter3DSettings.InFill, buPrinter3D.varPrinter3DSettings.NozzleDiameter);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) this.simulation_0);
  }

  public void doSlicing(WorkCompletedEventArgs e)
  {
    Slicing workUnit = (Slicing) e.WorkUnit;
    Design viewportcad1 = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerSliceName, viewportcad1, this);
    Design viewportcad2 = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerRegionName, viewportcad2, this);
    Design viewportcad3 = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerOffsetSliceName, viewportcad3, this);
    Design viewportcad4 = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerSimulationName, viewportcad4, this);
    Design viewportcad5 = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerTessellationName, viewportcad5, this);
    Design viewportcad6 = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerCamName, viewportcad6, this);
    Design viewportcad7 = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerInFill, viewportcad7, this);
    this.activeJob = new Printer3DJob();
    for (int index1 = 0; index1 < workUnit.NumMeshes; ++index1)
    {
      for (int index2 = 0; index2 <= workUnit.OffsetSectionsByMesh[0].Length - 1; ++index2)
      {
        if (workUnit.OffsetSectionsByMesh[0][index2].Vertices == null)
          workUnit.OffsetSectionsByMesh[0][index2].Regen(0.01);
        double z = workUnit.OffsetSectionsByMesh[0][index2].Vertices[0].Z;
        if (index2 == 0)
        {
          Printer3DLayer printer3Dlayer = new Printer3DLayer();
          printer3Dlayer.LevelZ = z;
          if (printer3Dlayer.LevelZ > buPrinter3D.varPrinter3DSettings.TopHeight & buPrinter3D.varPrinter3DSettings.TopHeight > 0.0)
            printer3Dlayer.Enable = false;
          buEntity buEntity = buEntity.Copy(workUnit.OffsetSectionsByMesh[0][index2]);
          printer3Dlayer.entitiesOffsetedSlices.Add(buEntity);
          this.activeJob.Layers.Add(printer3Dlayer);
        }
        else if (buCompare5.EQ(this.activeJob.Layers[this.activeJob.Layers.Count - 1].LevelZ, z, 0.01))
        {
          if (this.activeJob.Layers[this.activeJob.Layers.Count - 1].LevelZ > buPrinter3D.varPrinter3DSettings.TopHeight & buPrinter3D.varPrinter3DSettings.TopHeight > 0.0)
            this.activeJob.Layers[this.activeJob.Layers.Count - 1].Enable = false;
          this.activeJob.Layers[this.activeJob.Layers.Count - 1].entitiesOffsetedSlices.Add(buEntity.Copy(workUnit.OffsetSectionsByMesh[0][index2]));
        }
        else
        {
          Printer3DLayer printer3Dlayer = new Printer3DLayer();
          printer3Dlayer.LevelZ = z;
          if (printer3Dlayer.LevelZ > buPrinter3D.varPrinter3DSettings.TopHeight & buPrinter3D.varPrinter3DSettings.TopHeight > 0.0)
            printer3Dlayer.Enable = false;
          buEntity buEntity = buEntity.Copy(workUnit.OffsetSectionsByMesh[0][index2]);
          printer3Dlayer.entitiesOffsetedSlices.Add(buEntity);
          this.activeJob.Layers.Add(printer3Dlayer);
        }
      }
    }
    for (int index3 = 0; index3 < workUnit.NumMeshes; ++index3)
    {
      if (workUnit.HatchingByMeshByLayer[0] != null)
      {
        for (int index4 = 0; index4 <= workUnit.HatchingByMeshByLayer[0].Length - 1; ++index4)
        {
          int index5 = -1;
          if (!buPrinter3D.varPrinter3DSettings.InFillConnect)
          {
            for (int index6 = 0; index6 <= workUnit.HatchingByMeshByLayer[0][index4].Length - 1; ++index6)
            {
              for (int index7 = 0; index7 <= this.activeJob.Layers.Count - 1; ++index7)
              {
                double z = workUnit.HatchingByMeshByLayer[0][index4][index6].Vertices[0].Z;
                if (buCompare5.EQ(this.activeJob.Layers[index7].LevelZ, z, 0.1))
                  this.activeJob.Layers[index7].entitiesInfill.Add(buEntity.Copy((Entity) workUnit.HatchingByMeshByLayer[0][index4][index6]));
              }
            }
          }
          else
          {
            int num1 = 0;
            while (num1 <= this.activeJob.Layers.Count - 1)
              ++num1;
            if (index5 >= 0)
            {
              workUnit.HatchingByMeshByLayer[0][index4][0].Selected = true;
              List<Point3D> points = new List<Point3D>();
              points.Add(buVector5.ToPoint3D(workUnit.HatchingByMeshByLayer[0][index4][0].StartPoint));
              points.Add(buVector5.ToPoint3D(workUnit.HatchingByMeshByLayer[0][index4][0].EndPoint));
              for (int index8 = 0; index8 <= workUnit.HatchingByMeshByLayer[0][index4].Length - 1; ++index8)
              {
                double num2 = double.MaxValue;
                int index9 = -1;
                bool flag = false;
                for (int index10 = 1; index10 <= workUnit.HatchingByMeshByLayer[0][index4].Length - 1; ++index10)
                {
                  if (!workUnit.HatchingByMeshByLayer[0][index4][index10].Selected)
                  {
                    double num3 = Point3D.Distance(points[points.Count - 1], workUnit.HatchingByMeshByLayer[0][index4][index10].StartPoint);
                    if (num3 < num2)
                    {
                      num2 = num3;
                      flag = true;
                      index9 = index10;
                    }
                    double num4 = Point3D.Distance(points[points.Count - 1], workUnit.HatchingByMeshByLayer[0][index4][index10].EndPoint);
                    if (num4 < num2)
                    {
                      num2 = num4;
                      flag = false;
                      index9 = index10;
                    }
                  }
                }
                if (index9 >= 0)
                {
                  workUnit.HatchingByMeshByLayer[0][index4][index9].Selected = true;
                  if (flag)
                  {
                    points.Add(buVector5.ToPoint3D(workUnit.HatchingByMeshByLayer[0][index4][index9].StartPoint));
                    points.Add(buVector5.ToPoint3D(workUnit.HatchingByMeshByLayer[0][index4][index9].EndPoint));
                  }
                  else
                  {
                    points.Add(buVector5.ToPoint3D(workUnit.HatchingByMeshByLayer[0][index4][index9].EndPoint));
                    points.Add(buVector5.ToPoint3D(workUnit.HatchingByMeshByLayer[0][index4][index9].StartPoint));
                  }
                }
              }
              if (points.Count > 0)
              {
                buLinearPath refEntity = new buLinearPath(points);
                this.activeJob.Layers[index5].entitiesInfill.Add((buEntity) refEntity);
                Entity copiedEntity = (Entity) null;
                buEntity.Copy((buEntity) refEntity, ref copiedEntity);
              }
            }
          }
        }
      }
    }
    this.ProfileTreeUpdate();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == buPrinter3D.varTemps.layerOnlineSimulationName)
      {
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = false;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerOnlineSimulationName].Visible = false;
      }
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == buPrinter3D.varTemps.layerRegionName)
      {
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = false;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerRegionName].Visible = false;
      }
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == buPrinter3D.varTemps.layerSliceName)
      {
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = false;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerSliceName].Visible = false;
      }
      if (ccVars.Pages[ccVars.PageIndex].Layers[index].Name == buPrinter3D.varTemps.layerTessellationName)
      {
        ccVars.Pages[ccVars.PageIndex].Layers[index].Enable = false;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[buPrinter3D.varTemps.layerTessellationName].Visible = false;
      }
    }
    clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, true, -1);
    for (int iM = 0; iM < workUnit.NumMeshes; ++iM)
    {
      if (workUnit.HasOffsetSlices(iM))
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.AddRange<Entity>((IEnumerable<Entity>) workUnit.OffsetSectionsByMesh[iM], buPrinter3D.varTemps.layerOffsetSliceName);
      if (workUnit.HasHatching(iM))
      {
        foreach (Entity[] collection in workUnit.CuttingRegionByMeshByLayer[iM])
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.AddRange<Entity>((IEnumerable<Entity>) collection, buPrinter3D.varTemps.layerRegionName);
      }
      if (workUnit.HasSlices(iM))
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.AddRange<Entity>((IEnumerable<Entity>) workUnit.SectionsByMesh[iM], buPrinter3D.varTemps.layerSliceName);
      Mesh tessellatedMesh = workUnit.TessellatedMeshes[iM];
      if (tessellatedMesh.IsValid((StringBuilder) null))
      {
        tessellatedMesh.ColorMethod = colorMethodType.byLayer;
        tessellatedMesh.LayerName = buPrinter3D.varTemps.layerTessellationName;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) tessellatedMesh, buPrinter3D.varTemps.layerTessellationName);
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) tessellatedMesh);
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doSimulation(WorkCompletedEventArgs e)
  {
    SimulationRender simulationRender = new SimulationRender((Simulation) e.WorkUnit);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) simulationRender);
  }

  public void doSimulationRender(WorkCompletedEventArgs e)
  {
    Design viewportcad = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
    Class5.smethod_43(buPrinter3D.varTemps.layerSimulationName, viewportcad, this);
    SimulationRender workUnit = (SimulationRender) e.WorkUnit;
    if (workUnit.HasContour)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) workUnit.ContourMesh, buPrinter3D.varTemps.layerSimulationName);
      if (workUnit.HasHatching)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) workUnit.HatchingMesh, buPrinter3D.varTemps.layerSimulationName, Color.YellowGreen);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doReset()
  {
  }

  public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWPrinter3DVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWPrinter3DVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWPrinter3DVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
    buMWPrinter3DVars.varCamContour.buPar.Distances.Air = 0.0;
    buMWPrinter3DVars.varCamContour.buPar.Distances.Safe = 0.0;
    buMWPrinter3DVars.varCamContour.buPar.Distances.Rapid = 0.0;
    buMWPrinter3DVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
    buMWPrinter3DVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
    buMWPrinter3DVars.varCamContour.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
    buMWPrinter3DVars.varCamContour.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWPrinter3DVars.varCamContour.mwPar, buMWPrinter3DVars.varCamContour.buPar);
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWPrinter3DVars.varCamContour.mwPar, buMWPrinter3DVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWPrinter3DVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWPrinter3DVars.varCamContour.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }

  public void doWireframeRough(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    buMWPrinter3DVars.varCamRough.buPar.Runtime.SimG0DevideLength = 100.0;
    buMWPrinter3DVars.varCamRough.buPar.Runtime.SimG1DevideLength = 40.0;
    buMWPrinter3DVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
    buMWPrinter3DVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
    buMWPrinter3DVars.varCamRough.buPar.Operations.Height = MWCalcoptions.Height;
    buMWPrinter3DVars.varCamRough.buPar.Offsets.OpenContour = CamOpenContourType.Center;
    buMWPrinter3DVars.varCamRough.buPar.Distances.Air = 0.0;
    buMWPrinter3DVars.varCamRough.buPar.Distances.Safe = 0.0;
    buMWPrinter3DVars.varCamRough.buPar.Distances.Rapid = 0.0;
    buMWPrinter3DVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
    buMWPrinter3DVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
    buMWPrinter3DVars.varCamRough.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
    buMWPrinter3DVars.varCamRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWPrinter3DVars.varCamRough.mwPar, buMWPrinter3DVars.varCamRough.buPar);
    clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWPrinter3DVars.varCamRough.mwPar, buMWPrinter3DVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
    buMWPrinter3DVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWPrinter3DVars.varCamRough.buPar);
    if (num >= 1)
      return;
    buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
    clsInit.appCommand.Reset();
  }
}
