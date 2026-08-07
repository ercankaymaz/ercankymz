// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Robotic.clsRobotic
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Cam;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Robotic;

public class clsRobotic
{
  private List<Entity> list_0 = new List<Entity>();
  public List<Entity> SelectedMeshes = (List<Entity>) null;
  public List<RoboticSurfacePoint> SurfacePoints;
  public RobotItem activeRobotItem = new RobotItem();
  public Timer timSim = (Timer) null;
  public Point3D pntStart = new Point3D();
  public Point3D pntBase = new Point3D();
  public int indexSim = -1;
  public int indexEnt = -1;
  public Entity SelectedEntity = (Entity) null;
  public List<string> CodeList = new List<string>();
  public MWCalculationOptions LastMWOptions = (MWCalculationOptions) null;
  public double LastPlungeFeed = 10.0;
  private static double double_0 = 1E-10;
  private static Random random_0 = new Random();

  public void Init()
  {
    buMWRoboticVars.Init();
    this.SurfacePoints = new List<RoboticSurfacePoint>();
  }

  public void cmdIJKToEuler()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count != 0)
        return;
      ccVars.stpDrawing = 2;
      clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamRoughFlat()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.robotic3AxisRoughFlat;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp camTp = new camTp();
        this.doTriangleMesh(new MWCalculationOptions()
        {
          NumberofAxis = 3,
          CamTriMeshType = CamTriangularMeshType.Rough,
          Mode = CamMode.TriangularMesh,
          isRough = true,
          DontApplyReset = true,
          AddToCamListInMWCalculation = true,
          CamRotateType = CamRotationType.Flat
        });
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamRoughCircular()
  {
    try
    {
      F_CamFrontBack fCamFrontBack = new F_CamFrontBack();
      fCamFrontBack.Properties.FormCloseMode = FormCloseModeType.Dispose;
      fCamFrontBack.Init();
      int num = (int) fCamFrontBack.ShowDialog();
      RoboticTempVars.FaceType = fCamFrontBack.FrontBack;
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.robotic4AxisRoughCircular;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp camTp = new camTp();
        this.doTriangleMesh(new MWCalculationOptions()
        {
          NumberofAxis = 4,
          CamTriMeshType = CamTriangularMeshType.Rough,
          Mode = CamMode.TriangularMesh,
          isRough = true,
          DontApplyReset = true,
          AddToCamListInMWCalculation = true,
          CamRotateType = CamRotationType.Circular
        });
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamParallelCutCircular(int AxisNumber)
  {
    try
    {
      F_CamFrontBack fCamFrontBack = new F_CamFrontBack();
      fCamFrontBack.Properties.FormCloseMode = FormCloseModeType.Dispose;
      fCamFrontBack.Init();
      int num = (int) fCamFrontBack.ShowDialog();
      RoboticTempVars.FaceType = fCamFrontBack.FrontBack;
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.robotic4AxisParallelCutCircular;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp camTp = new camTp();
        this.doTriangleMesh(new MWCalculationOptions()
        {
          NumberofAxis = AxisNumber,
          CamTriMeshType = CamTriangularMeshType.ParallelCuts,
          Mode = CamMode.TriangularMesh,
          CamRotateType = CamRotationType.Circular,
          isRough = false,
          DontApplyReset = true,
          AddToCamListInMWCalculation = true
        });
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamParallelCutFlat(int AxisNumber)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      switch (AxisNumber)
      {
        case 3:
          ccVars.Action = actionTypeBU.robotic3AxisParallelCutFlat;
          break;
        case 4:
          ccVars.Action = actionTypeBU.robotic4AxisParallelCutFlat;
          break;
        default:
          ccVars.Action = actionTypeBU.robotic5AxisParallelCutFlat;
          break;
      }
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp camTp = new camTp();
        this.doTriangleMesh(new MWCalculationOptions()
        {
          NumberofAxis = AxisNumber,
          CamTriMeshType = CamTriangularMeshType.ParallelCuts,
          Mode = CamMode.TriangularMesh,
          isRough = false,
          DontApplyReset = true,
          AddToCamListInMWCalculation = true,
          CamRotateType = CamRotationType.Flat
        });
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamConstantZCircular(int AxisNumber)
  {
    try
    {
      F_CamFrontBack fCamFrontBack = new F_CamFrontBack();
      fCamFrontBack.Properties.FormCloseMode = FormCloseModeType.Dispose;
      fCamFrontBack.Init();
      int num = (int) fCamFrontBack.ShowDialog();
      RoboticTempVars.FaceType = fCamFrontBack.FrontBack;
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.robotic4AxisContantZCircular;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp camTp = new camTp();
        this.doTriangleMesh(new MWCalculationOptions()
        {
          NumberofAxis = AxisNumber,
          CamTriMeshType = CamTriangularMeshType.ConstantZ,
          Mode = CamMode.TriangularMesh,
          CamRotateType = CamRotationType.Circular,
          isRough = false,
          DontApplyReset = true,
          AddToCamListInMWCalculation = true
        });
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamConstantZFlat(int AxisNumber)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      switch (AxisNumber)
      {
        case 3:
          ccVars.Action = actionTypeBU.robotic3AxisConstantZFlat;
          goto case 4;
        case 4:
          dynamicInfo.Command = AppLanguage.CadCamCommand[36];
          ccVars.selectionProcess = true;
          clsMW.CamEntities.Clear();
          clsMW.CamEntities = new List<Entity>();
          if (ccVars.SelectionOP.Selections.Count == 0)
          {
            ccVars.stpDrawing = 2;
            clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
            break;
          }
          camTp camTp = new camTp();
          this.doTriangleMesh(new MWCalculationOptions()
          {
            NumberofAxis = AxisNumber,
            CamTriMeshType = CamTriangularMeshType.ConstantZ,
            Mode = CamMode.TriangularMesh,
            isRough = false,
            DontApplyReset = true,
            AddToCamListInMWCalculation = true,
            CamRotateType = CamRotationType.Flat
          });
          break;
        default:
          ccVars.Action = actionTypeBU.robotic5AxisConstantZFlat;
          goto case 4;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamParallelCutSurface()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.robotic5AxisParallelCutSurface;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp camTp = new camTp();
        this.doSurface(new MWCalculationOptions()
        {
          NumberofAxis = 5,
          CamTriMeshType = CamTriangularMeshType.ParallelCuts,
          Mode = CamMode.Surface,
          CamSurfType = CamSurfaceType.SurfaceParalel,
          isRough = false,
          DontApplyReset = true,
          AddToCamListInMWCalculation = true
        });
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamTrimContour()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.robotic5AxisParallelCutSurface;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      clsMW.CamEntities.Clear();
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        camTp camTp = new camTp();
        this.doTriangleMesh(new MWCalculationOptions()
        {
          NumberofAxis = 5,
          Mode = CamMode.Contour,
          isRough = false,
          DontApplyReset = true,
          AddToCamListInMWCalculation = true
        });
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
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        switch (Action)
        {
          case actionTypeBU.camTriangularMesh3DRough:
            camTp camTp1 = new camTp();
            this.doTriangleMesh(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamTriMeshType = CamTriangularMeshType.Rough,
              Mode = CamMode.TriangularMesh,
              isRough = true,
              DontApplyReset = true,
              AddToCamListInMWCalculation = true
            });
            break;
          case actionTypeBU.camTriangularMesh3DParalelCut:
            camTp camTp2 = new camTp();
            this.doTriangleMesh(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamTriMeshType = CamTriangularMeshType.ParallelCuts,
              Mode = CamMode.TriangularMesh,
              DontApplyReset = true,
              AddToCamListInMWCalculation = true
            });
            break;
          case actionTypeBU.camTriangularMesh3DConstantZ:
            camTp camTp3 = new camTp();
            this.doTriangleMesh(new MWCalculationOptions()
            {
              NumberofAxis = 3,
              CamTriMeshType = CamTriangularMeshType.ConstantZ,
              Mode = CamMode.TriangularMesh,
              DontApplyReset = true,
              AddToCamListInMWCalculation = true
            });
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

  public void cmdCamWireFrame()
  {
    try
    {
      F_Notepad fNotepad = new F_Notepad();
      string text = buString5.StringListToString(this.CodeList, true);
      fNotepad.Init(text);
      fNotepad.Show();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdGetPointOnSurfece()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.miscGetPoint;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = false;
      dynamicInfo.Command = AppLanguage.CadCamCommand[1] + " ";
      clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
      buRoboticCalc.varRoboticRunSettings.isFirst = false;
      buRoboticCalc.varRoboticRunSettings.isLast = false;
      if (this.SelectedMeshes != null)
        this.SelectedMeshes.Clear();
      this.SelectedMeshes = new List<Entity>();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is Mesh)
          this.SelectedMeshes.Add((Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Clone());
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdContouring()
  {
    SelectionOption Option = new SelectionOption(false, true, false, false, false, false);
    clsInit.appCommand.SelectionToEntities(ref buMWCalcs.CamEntities, Option);
    MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
    MWCalcOptions.NumberofAxis = 3;
    MWCalcOptions.CamTriMeshType = CamTriangularMeshType.Rough;
    MWCalcOptions.Mode = CamMode.TriangularMesh;
    MWCalcOptions.isRough = true;
    MWCalcOptions.DontApplyReset = true;
    MWCalcOptions.AddToCamListInMWCalculation = true;
    camTp Cam = new camTp();
    camResult Result = new camResult();
    buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamContouring, ref buMWCalcs.varCamContouringPars);
    clsInit.appMW.doContouring(MWCalcOptions, ccVars.toolActive, ref Cam, ref Result);
    buMWCalcs.CopyCamParameter(buMWCalcs.varCamContouringPars, ref buMWRoboticVars.varCamContouring);
    this.SurfacePoints.Clear();
    clsInit.appCommand.undoBuffer();
    if (Cam.CamPoints.Count > 0)
    {
      for (int index = 0; index <= Cam.CamPoints[0].Points.Count - 1; ++index)
      {
        RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
        ccVars.UndoDont = true;
        Vector3D vector3D = new Vector3D(Cam.CamPoints[0].Points[index].P9.A, Cam.CamPoints[0].Points[index].P9.B, Cam.CamPoints[0].Points[index].P9.C);
        double c = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XY);
        double b = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XZ);
        double a = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.YZ);
        Point3D StartPoint = new Point3D(Cam.CamPoints[0].Points[index].P9.X, Cam.CamPoints[0].Points[index].P9.Y, Cam.CamPoints[0].Points[index].P9.Z);
        Point3D EndPoint = new Point3D(Cam.CamPoints[0].Points[index].P9.X + vector3D.X * 50.0, Cam.CamPoints[0].Points[index].P9.Y + vector3D.Y * 50.0, Cam.CamPoints[0].Points[index].P9.Z + vector3D.Z * 50.0);
        EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData();
        Line Ent = (Line) null;
        clsInit.appCommand.CreateLine(StartPoint, EndPoint, entData, customData, ref Ent);
        roboticSurfacePoint.entTangent = (Entity) Ent;
        roboticSurfacePoint.pntTangent = new Pnt6D(Cam.CamPoints[0].Points[index].P9.X, Cam.CamPoints[0].Points[index].P9.Y, Cam.CamPoints[0].Points[index].P9.Z, a, b, c);
        this.SurfacePoints.Add(roboticSurfacePoint);
      }
      for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
      {
        Pnt6D pntTangent = this.SurfacePoints[index].pntTangent;
        if (pntTangent != (Pnt6D) null)
        {
          double a = this.SurfacePoints[index].pntTangent.A;
          double num1 = 0.0;
          double num2 = 0.0;
          double num3 = 0.0;
          num1 = a <= 90.0 ? 180.0 - (90.0 - a) : a - 270.0;
          num2 = this.SurfacePoints[index].pntTangent.B <= 90.0 ? this.SurfacePoints[index].pntTangent.B - 90.0 : this.SurfacePoints[index].pntTangent.B - 90.0;
          double num4 = 0.0;
          string str = $"{$"{this.SurfacePoints[index].pntTangent.X.ToString("f2")};{this.SurfacePoints[index].pntTangent.Y.ToString("f2")};{this.SurfacePoints[index].pntTangent.Z.ToString("f2")};"}{num1.ToString("f2")};{num4.ToString("f2")};{num3.ToString("f2")};" + "100;0;0;0;1;100;";
          Cam.PreCodes.Add((object) str);
          Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(this.SurfacePoints[index].pntTangent.X, this.SurfacePoints[index].pntTangent.Y, this.SurfacePoints[index].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
          Cam.SimilationPoint.SimMove.Add(pnt6DsimMove);
        }
      }
      Cam.PreCodes.Insert(0, (object) ((Cam.PreCodes.Count + 1).ToString() + ";"));
      string str1 = $"{this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.X.ToString("f2")};{this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.Y.ToString("f2")};{(this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2")};" + "0.00;0.00;0.00;100;0;0;0;1;100;";
      Cam.PreCodes.Add((object) str1);
      Cam.Tool = new ToolBase5(ccVars.toolActive);
      for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
      {
        if (this.SurfacePoints[index].entTangent != null)
        {
          Entity copiedEnt = (Entity) null;
          buVector5.CopyEntities(this.SurfacePoints[index].entTangent, ref copiedEnt);
          Cam.EntitiesOther.Add(copiedEnt);
        }
      }
      Cam.CamPoints.Clear();
      clsInit.appCommand.CamAdd(Cam);
      clsInit.appCommand.Reset();
    }
    clsFiles.SaveParameter();
  }

  public void cmdSurface()
  {
    SelectionOption Option = new SelectionOption(false, true, false, false, false, false);
    clsInit.appCommand.SelectionToEntities(ref buMWCalcs.CamEntities, Option);
    MWCalculationOptions MWCalcOptions = new MWCalculationOptions();
    MWCalcOptions.NumberofAxis = 3;
    MWCalcOptions.CamTriMeshType = CamTriangularMeshType.Rough;
    MWCalcOptions.Mode = CamMode.TriangularMesh;
    MWCalcOptions.isRough = true;
    MWCalcOptions.DontApplyReset = true;
    MWCalcOptions.AddToCamListInMWCalculation = true;
    if (buMWCalcs.CamEntities.Count > 0)
      this.SelectedEntity = (Entity) buMWCalcs.CamEntities[0].Clone();
    camTp Cam = new camTp();
    camResult Result = new camResult();
    buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamSurface5Axis, ref buMWCalcs.varCamSurfacePars);
    buMWCalcs.entityProjection = new List<List<Entity>>();
    List<Entity> entityList = new List<Entity>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
        if (copiedEntity != null)
        {
          copiedEntity.Translate(0.0, 0.0, 30.0);
          entityList.Add(copiedEntity);
        }
      }
    }
    buMWCalcs.varCamSurfacePars.mwPar.MachParam.CurCutType = MachiningParamsCutType.CutParallel;
    if (entityList.Count > 0)
    {
      buMWCalcs.entityProjection.Add(entityList);
      buMWCalcs.varCamSurfacePars.mwPar.MachParam.ProjectCurvesParams.MaxProjectionDistance = 30.0;
      buMWCalcs.varCamSurfacePars.mwPar.MachParam.CurCutType = MachiningParamsCutType.CutProjectCurves;
    }
    clsInit.appMW.doSurface(MWCalcOptions, ccVars.toolActive, ref Cam, ref Result);
    buMWCalcs.CopyCamParameter(buMWCalcs.varCamSurfacePars, ref buMWRoboticVars.varCamSurface5Axis);
    this.SurfacePoints.Clear();
    clsInit.appCommand.undoBuffer();
    if (clsItem.FrmProgress != null)
      clsItem.FrmProgress.Visible = false;
    this.list_0 = new List<Entity>();
    this.CodeList = new List<string>();
    if (Cam.CamPoints.Count > 0)
    {
      for (int index1 = 0; index1 <= Cam.CamPoints.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= Cam.CamPoints[index1].Points.Count - 1; ++index2)
        {
          RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
          ccVars.UndoDont = true;
          Vector3D vector3D = new Vector3D(Cam.CamPoints[index1].Points[index2].P9.A, Cam.CamPoints[index1].Points[index2].P9.B, Cam.CamPoints[index1].Points[index2].P9.C);
          double c = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XY);
          double b = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XZ);
          double a = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.YZ);
          Point3D StartPoint = new Point3D(Cam.CamPoints[index1].Points[index2].P9.X, Cam.CamPoints[index1].Points[index2].P9.Y, Cam.CamPoints[index1].Points[index2].P9.Z);
          Point3D EndPoint = new Point3D(Cam.CamPoints[index1].Points[index2].P9.X + vector3D.X * 1.0, Cam.CamPoints[index1].Points[index2].P9.Y + vector3D.Y * 1.0, Cam.CamPoints[index1].Points[index2].P9.Z + vector3D.Z * 1.0);
          EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
          CustomData customData = new CustomData();
          Line Ent = (Line) null;
          clsInit.appCommand.CreateLine(StartPoint, EndPoint, entData, customData, ref Ent);
          roboticSurfacePoint.entTangent = (Entity) Ent;
          roboticSurfacePoint.pntTangent = new Pnt6D(Cam.CamPoints[index1].Points[index2].P9.X, Cam.CamPoints[index1].Points[index2].P9.Y, Cam.CamPoints[index1].Points[index2].P9.Z, a, b, c);
          roboticSurfacePoint.vecNormal = new Vector3D(vector3D.X, vector3D.Y, vector3D.Z);
          this.SurfacePoints.Add(roboticSurfacePoint);
          ccVars.UndoDont = true;
          Ent.Color = Color.Black;
          Ent.ColorMethod = colorMethodType.byEntity;
          Ent.EntityData = (object) new CustomData()
          {
            typeDefination = entityTypeDefination.Simulation
          };
          this.list_0.Add((Entity) Ent);
        }
      }
      for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        Pnt6D pntTangent = this.SurfacePoints[index].pntTangent;
        if (pntTangent != (Pnt6D) null)
        {
          double a = this.SurfacePoints[index].pntTangent.A;
          double b = this.SurfacePoints[index].pntTangent.B;
          double num1 = 0.0;
          double num2 = 0.0;
          double num3 = this.SurfacePoints[index].pntTangent.A - 90.0;
          num1 = this.SurfacePoints[index].pntTangent.B <= 90.0 ? 180.0 - (90.0 - this.SurfacePoints[index].pntTangent.B) : this.SurfacePoints[index].pntTangent.B - 270.0;
          num1 = this.SurfacePoints[index].pntTangent.B - 90.0;
          num2 = this.SurfacePoints[index].pntTangent.C;
          string str = $"{$"{$"{this.SurfacePoints[index].pntTangent.X.ToString("f2")};{this.SurfacePoints[index].pntTangent.Y.ToString("f2")};{this.SurfacePoints[index].pntTangent.Z.ToString("f2")};"}{num3.ToString("f2")};{num1.ToString("f2")};{num2.ToString("f2")};"}{this.SurfacePoints[index].vecNormal.X.ToString("f2")};{this.SurfacePoints[index].vecNormal.Y.ToString("f2")};{this.SurfacePoints[index].vecNormal.Z.ToString("f2")};" + "100;0;0;0;1;100;";
          Cam.PreCodes.Add((object) str);
          this.CodeList.Add($"{$"{$"{this.SurfacePoints[index].pntTangent.X.ToString("f2")} ; {this.SurfacePoints[index].pntTangent.Y.ToString("f2")} ; {this.SurfacePoints[index].pntTangent.Z.ToString("f2")} ; "}{num3.ToString("f2")} ; {num1.ToString("f2")} ; {num2.ToString("f2")} ; "}{this.SurfacePoints[index].vecNormal.X.ToString("f2")} ; {this.SurfacePoints[index].vecNormal.Y.ToString("f2")} ; {this.SurfacePoints[index].vecNormal.Z.ToString("f2")}");
          Pnt6DSim pnt6Dsim = new Pnt6DSim(this.SurfacePoints[index].pntTangent.X, this.SurfacePoints[index].pntTangent.Y, this.SurfacePoints[index].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
        }
      }
      Cam.PreCodes.Insert(0, (object) ((Cam.PreCodes.Count + 1).ToString() + ";"));
      string str1 = $"{this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.X.ToString("f2")};{this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.Y.ToString("f2")};{(this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2")};" + "0.00;0.00;0.000.00;0.00;0.00;100;0;0;0;1;100;";
      Cam.PreCodes.Add((object) str1);
      Cam.Tool = new ToolBase5(ccVars.toolActive);
      double num4 = 10000000.0;
      for (int index = 0; index <= Cam.SimilationPoint.SimMove.Count - 1; ++index)
      {
        double num5 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.XY);
        double num6 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.XZ);
        double num7 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.YZ);
        if (num5 == 0.0 & num4 != 0.0)
          ;
        Cam.SimilationPoint.SimMove[index].A = num7 - 90.0;
        Cam.SimilationPoint.SimMove[index].B = num6;
        Cam.SimilationPoint.SimMove[index].C = Cam.SimilationPoint.SimMove[index].A <= 0.0 ? num5 - 90.0 : num5 + 90.0;
        num4 = num5;
      }
      Cam.CamPoints.Clear();
      clsInit.appCommand.CamAdd(Cam);
      clsInit.appCommand.Reset();
    }
    clsFiles.SaveParameter();
  }

  public void cmdContourByPoints()
  {
    try
    {
      if (this.SurfacePoints.Count <= 0)
        return;
      this.doContourBySelected(new MWCalculationOptions()
      {
        NumberofAxis = 5,
        DontApplyReset = true,
        AddToCamListInMWCalculation = true
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSurfaceByPoints()
  {
    try
    {
      if (this.SurfacePoints.Count <= 0)
        return;
      this.doSurfaceBySelected(new MWCalculationOptions()
      {
        NumberofAxis = 5,
        DontApplyReset = true,
        AddToCamListInMWCalculation = true
      });
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSurfaceToCurvature()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.surfaceConvertToMeshFace;
      dynamicInfo.Command = AppLanguage.CadCamCommand[36];
      ccVars.selectionProcess = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doGetCurveture();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdEditCurvaturePoints()
  {
    try
    {
      F_RoboticSurfacePoints roboticSurfacePoints = new F_RoboticSurfacePoints();
      for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
      {
        RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint(this.SurfacePoints[index]);
        roboticSurfacePoints.SurfPoints.Add(roboticSurfacePoint);
      }
      roboticSurfacePoints.TopMost = true;
      roboticSurfacePoints.isTangent = true;
      roboticSurfacePoints.Init();
      roboticSurfacePoints.DataValueChanged += new ApplyCommandWithDataEventHandler(this.doReCalculateSurfacePoints);
      roboticSurfacePoints.SelectedIndexChanged += new ApplyCommandWithDataEventHandler(this.doSelecredPointChanged);
      roboticSurfacePoints.Show();
      if (roboticSurfacePoints.PropertiesForm.Result == DialogResult.OK)
        ;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdShowSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Text = "Settings";
      classViewerDialog.Value = (object) buRoboticCalc.varRoboticSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      buRoboticCalc.varRoboticSettings = new RoboticSettings((RoboticSettings) classViewerDialog.Value);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdContourFollow()
  {
    try
    {
      this.doContourFromWireAndAngle(45.0);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdRoboticSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = "Settings";
      classViewerDialog.Value = (object) buRoboticCalc.varRoboticSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      buRoboticCalc.varRoboticSettings = new RoboticSettings((RoboticSettings) classViewerDialog.Value);
      this.SaveRoboticFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdRoboticRecalculate()
  {
    if ((ccVars.Pages[ccVars.PageIndex].Cams.Count <= 0 ? 0 : (this.LastMWOptions != null ? 1 : 0)) == 0)
      return;
    this.ToolPathToRobotPathCode(ccVars.Pages[ccVars.PageIndex].Cams[0], this.LastMWOptions, this.LastPlungeFeed);
  }

  public void cmdRoboticShowCode(bool SaveFile)
  {
    if (clsVar.appModes_0.DemoMode)
      buString5.MessageBoxWarning(buLangTranslate.preSentences.NotAvailableDemoMode);
    else if (ccVars.Pages.Count <= 0)
    {
      buString5.MessageBoxWarning(buLangTranslate.preSentences.NoPageOpened);
    }
    else
    {
      bool flag = false;
      string str1 = "";
      string str2 = "";
      if (SaveFile)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = "Pdl Files (.pdl)|*.pdl";
        saveFileDialog.FilterIndex = 1;
        flag = false;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          flag = true;
          str2 = saveFileDialog.FileName;
          clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
        }
      }
      if (!flag)
        return;
      string newValue = "";
      if (str2.Length > 0)
        newValue = buFile5.getFileNameWithoutExtension(str2);
      if (this.activeRobotItem.Codes.Count <= 0)
        return;
      this.activeRobotItem.Codes[0] = this.activeRobotItem.Codes[0].Replace("$$$", newValue);
      this.activeRobotItem.Codes[this.activeRobotItem.Codes.Count - 1] = this.activeRobotItem.Codes[this.activeRobotItem.Codes.Count - 1].Replace("$$$", newValue);
      string str3 = buString5.StringListToString(this.activeRobotItem.Codes);
      if (SaveFile)
      {
        buFile5.SaveToFile(str3, str2);
        str1 = "";
        clsFiles.SaveParameter();
      }
      else
      {
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(str3);
        fNotepad.Show();
        str1 = "";
      }
    }
  }

  public void ToolPathToGCode(camTp Cam)
  {
    if (Cam.CamPoints.Count <= 0)
      return;
    for (int index1 = 0; index1 <= Cam.CamPoints.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Cam.CamPoints[index1].Points.Count - 1; ++index2)
      {
        RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
        ccVars.UndoDont = true;
        Vector3D vector3D = new Vector3D(Cam.CamPoints[index1].Points[index2].P9.A, Cam.CamPoints[index1].Points[index2].P9.B, Cam.CamPoints[index1].Points[index2].P9.C);
        double c = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XY);
        double b = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XZ);
        double a = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.YZ);
        Point3D StartPoint = new Point3D(Cam.CamPoints[index1].Points[index2].P9.X, Cam.CamPoints[index1].Points[index2].P9.Y, Cam.CamPoints[index1].Points[index2].P9.Z);
        Point3D EndPoint = new Point3D(Cam.CamPoints[index1].Points[index2].P9.X + vector3D.X * 50.0, Cam.CamPoints[index1].Points[index2].P9.Y + vector3D.Y * 50.0, Cam.CamPoints[index1].Points[index2].P9.Z + vector3D.Z * 50.0);
        EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData();
        Line Ent = (Line) null;
        clsInit.appCommand.CreateLine(StartPoint, EndPoint, entData, customData, ref Ent);
        roboticSurfacePoint.entTangent = (Entity) Ent;
        roboticSurfacePoint.pntTangent = new Pnt6D(Cam.CamPoints[index1].Points[index2].P9.X, Cam.CamPoints[index1].Points[index2].P9.Y, Cam.CamPoints[index1].Points[index2].P9.Z, a, b, c);
        this.SurfacePoints.Add(roboticSurfacePoint);
      }
    }
    for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
    {
      Pnt6D pntTangent = this.SurfacePoints[index].pntTangent;
      if (pntTangent != (Pnt6D) null)
      {
        double a = this.SurfacePoints[index].pntTangent.A;
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = a <= 90.0 ? 180.0 - (90.0 - a) : a - 270.0;
        num1 = this.SurfacePoints[index].pntTangent.B <= 90.0 ? this.SurfacePoints[index].pntTangent.B - 90.0 : this.SurfacePoints[index].pntTangent.B - 90.0;
        double num4 = 0.0;
        string str = $"{$"{this.SurfacePoints[index].pntTangent.X.ToString("f2")};{this.SurfacePoints[index].pntTangent.Y.ToString("f2")};{this.SurfacePoints[index].pntTangent.Z.ToString("f2")};"}{num3.ToString("f2")};{num4.ToString("f2")};{num2.ToString("f2")};" + "100;0;0;0;1;100;";
        Cam.PreCodes.Add((object) str);
        Pnt6DSim pnt6Dsim = new Pnt6DSim(this.SurfacePoints[index].pntTangent.X, this.SurfacePoints[index].pntTangent.Y, this.SurfacePoints[index].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
      }
    }
    Cam.PreCodes.Insert(0, (object) ((Cam.PreCodes.Count + 1).ToString() + ";"));
    string str1 = $"{this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.X.ToString("f2")};{this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.Y.ToString("f2")};{(this.SurfacePoints[this.SurfacePoints.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2")};" + "0.00;0.00;0.00;100;0;0;0;1;100;";
    Cam.PreCodes.Add((object) str1);
    Cam.Tool = new ToolBase5(ccVars.toolActive);
    double num5 = 10000000.0;
    for (int index = 0; index <= Cam.SimilationPoint.SimMove.Count - 1; ++index)
    {
      double num6 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.XY);
      double num7 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.XZ);
      double num8 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.YZ);
      if (num6 == 0.0 & num5 != 0.0)
        ;
      Cam.SimilationPoint.SimMove[index].A = num8 - 90.0;
      Cam.SimilationPoint.SimMove[index].B = num7;
      Cam.SimilationPoint.SimMove[index].C = Cam.SimilationPoint.SimMove[index].A <= 0.0 ? num6 - 90.0 : num6 + 90.0;
      num5 = num6;
    }
    Cam.CamPoints.Clear();
    clsInit.appCommand.CamAdd(Cam);
    clsInit.appCommand.Reset();
  }

  public void ToolPathToRobotPathCode(
    camTp Cam,
    MWCalculationOptions MWCalcoptions,
    double PlungeFeed)
  {
    this.activeRobotItem.ToolPaths.Clear();
    this.activeRobotItem.Codes.Clear();
    this.activeRobotItem = new RobotItem();
    if (Cam.CamPoints.Count > 0)
    {
      this.activeRobotItem.Codes.Add($"{$"{$"{$"{$"{$"{$"{$"{$"{$"{"PROGRAM $$$ PROG_ARM = 1" + Environment.NewLine}ROUTINE ToolFrame(ai_tool, ai_frame, ai_arm : INTEGER()) EXPORTED FROM tt_tool GLOBAL{Environment.NewLine}"}BEGIN{Environment.NewLine}"}  $CNFG_CARE:= FALSE{Environment.NewLine}"}  $TURN_CARE:= FALSE{Environment.NewLine}"}  $SING_CARE:= TRUE{Environment.NewLine}"}  $JNT_MTURN:= FALSE{Environment.NewLine}"}  $ORNT_TYPE:= WRIST_JNT{Environment.NewLine}"}  ToolFrame({buRoboticCalc.varRoboticSettings.ToolFrame.ToString()},{buRoboticCalc.varRoboticSettings.WorkFrame.ToString()},{buRoboticCalc.varRoboticSettings.RobotFrame.ToString()}){Environment.NewLine}"}  $ARM_OVR:={buRoboticCalc.varRoboticSettings.FeedOverride.ToString("f0")}{Environment.NewLine}"}  MOVE ARM[1] TO $CAL_SYS{Environment.NewLine}");
      RobotToolPath robotToolPath1 = (RobotToolPath) null;
      List<RobotToolPath> robotToolPathList = new List<RobotToolPath>();
      for (int index1 = 0; index1 <= Cam.CamPoints.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= Cam.CamPoints[index1].Points.Count - 1; ++index2)
        {
          ccVars.UndoDont = true;
          Pnt9D p9 = Cam.CamPoints[index1].Points[index2].P9;
          RobotToolPath robotToolPath2 = new RobotToolPath();
          robotToolPath2.RoboPosition = (RobotPose) CamToComauConverter.ConvertCamToComau(new Point3D(p9.X, p9.Y, p9.Z), new Vector3D(p9.A, p9.B, p9.C), toolLength: Cam.Tool.CamData.DepthOffset);
          if (MWCalcoptions.NumberofAxis == 3)
          {
            if (robotToolPath2.RoboPosition == null)
              robotToolPath2.RoboPosition = new RobotPose();
            robotToolPath2.RoboPosition.Position = new Point3D(p9.X, p9.Y, p9.Z + Cam.Tool.CamData.DepthOffset);
            robotToolPath2.RoboPosition.Orientation = new EulerAngles(0.0, 0.0, 0.0);
          }
          if (MWCalcoptions.NumberofAxis == 4 && MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts & MWCalcoptions.CamRotateType == CamRotationType.Flat)
          {
            if (robotToolPath2.RoboPosition.Orientation.Roll == 180.0)
            {
              robotToolPath2.RoboPosition.Orientation.Roll = -180.0;
              robotToolPath2.RoboPosition.Orientation.Yaw = -90.0;
            }
            else if (robotToolPath2.RoboPosition.Orientation.Roll == 0.0)
            {
              robotToolPath2.RoboPosition.Orientation.Pitch = 360.0 - robotToolPath2.RoboPosition.Orientation.Pitch;
              robotToolPath2.RoboPosition.Orientation.Roll = -180.0;
              robotToolPath2.RoboPosition.Orientation.Yaw = -90.0;
            }
          }
          if ((robotToolPath2.RoboPosition != null ? 0 : (robotToolPath1 != null ? 1 : 0)) != 0)
          {
            robotToolPath2.RoboPosition = new RobotPose();
            robotToolPath2.RoboPosition.Position = new Point3D(p9.X, p9.Y, p9.Z);
            robotToolPath2.RoboPosition.Orientation = new EulerAngles(robotToolPath1.RoboPosition.Orientation.Roll, robotToolPath1.RoboPosition.Orientation.Pitch, robotToolPath1.RoboPosition.Orientation.Yaw);
          }
          if (p9.C > 0.9999 & robotToolPath1 != null)
            robotToolPath2.RoboPosition.Orientation = new EulerAngles(robotToolPath1.RoboPosition.Orientation.Roll, robotToolPath1.RoboPosition.Orientation.Pitch, robotToolPath1.RoboPosition.Orientation.Yaw);
          if ((robotToolPath1 == null ? 0 : (Math.Abs(robotToolPath1.RoboPosition.Orientation.Pitch - robotToolPath2.RoboPosition.Orientation.Pitch) > 20.0 ? 1 : 0)) != 0)
            ;
          if (robotToolPath2.RoboPosition == null)
          {
            robotToolPath2.RoboPosition = new RobotPose();
            robotToolPath2.RoboPosition.Position = new Point3D(p9.X, p9.Y, p9.Z);
            robotToolPath2.RoboPosition.Orientation = new EulerAngles(0.0, 90.0, 0.0);
          }
          if (robotToolPath2.RoboPosition.Orientation.Yaw != 90.0)
            ;
          robotToolPath1 = new RobotToolPath();
          robotToolPath1.RoboPosition.Orientation = new EulerAngles(robotToolPath2.RoboPosition.Orientation.Roll, robotToolPath2.RoboPosition.Orientation.Pitch, robotToolPath2.RoboPosition.Orientation.Yaw);
          robotToolPath1.RoboPosition.Position = new Point3D(robotToolPath2.RoboPosition.Position.X, robotToolPath2.RoboPosition.Position.Y, robotToolPath2.RoboPosition.Position.Z);
          robotToolPath1.RoboPosition.PositionNoTool = new Point3D(robotToolPath2.RoboPosition.PositionNoTool.X, robotToolPath2.RoboPosition.PositionNoTool.Y, robotToolPath2.RoboPosition.PositionNoTool.Z);
          robotToolPath2.RoboPosition.Orientation.Yaw -= 90.0;
          robotToolPath2.RoboPosition.IJKVector = new Vector3D(p9.A, p9.B, p9.C);
          robotToolPath2.RoboPosition.PositionNoTool = new Point3D(p9.X, p9.Y, p9.Z);
          double B = 0.0;
          double C = 0.0;
          this.CalculateBCAngles(p9.A, p9.B, p9.C, ref B, ref C);
          robotToolPath2.RoboPosition.PlaneAngle.B = B;
          robotToolPath2.RoboPosition.PlaneAngle.C = C;
          new CustomData().typeDefination = entityTypeDefination.SurfaceInfo;
          if (Cam.CamPoints[index1].Points[index2].Type == 0)
            robotToolPath2.RoboPosition.isQuickMove = true;
          else if (Cam.CamPoints[index1].Points[index2].Feed == PlungeFeed)
            robotToolPath2.RoboPosition.isPlungeMove = true;
          else
            robotToolPath2.RoboPosition.isCuttingMove = true;
          robotToolPathList.Add(robotToolPath2);
        }
      }
      double moveDevideLength1 = buRoboticCalc.varRoboticSettings.PlungeMoveDevideLength;
      double moveDevideLength2 = buRoboticCalc.varRoboticSettings.CuttingMoveDevideLength;
      double moveDevideLength3 = buRoboticCalc.varRoboticSettings.AngleMoveDevideLength;
      for (int index3 = 0; index3 <= robotToolPathList.Count - 1; ++index3)
      {
        if (index3 > 0)
        {
          double num1 = Point3D.Distance(robotToolPathList[index3 - 1].RoboPosition.Position, robotToolPathList[index3].RoboPosition.Position);
          double num2 = robotToolPathList[index3].RoboPosition.Orientation.Yaw - robotToolPathList[index3 - 1].RoboPosition.Orientation.Yaw;
          double num3 = robotToolPathList[index3].RoboPosition.Orientation.Pitch - robotToolPathList[index3 - 1].RoboPosition.Orientation.Pitch;
          double num4 = robotToolPathList[index3].RoboPosition.Orientation.Roll - robotToolPathList[index3 - 1].RoboPosition.Orientation.Roll;
          bool flag1 = false;
          bool flag2 = false;
          if (robotToolPathList[index3].RoboPosition.isPlungeMove)
          {
            if (num1 > moveDevideLength1 * 2.0)
            {
              int upper = (int) buNumeric5.RoundToUpper(Math.Abs(num1) / moveDevideLength1);
              List<RobotPose> Devided = new List<RobotPose>();
              bool flag3 = clsInit.cRobotic.DevideToolPath(robotToolPathList[index3 - 1].RoboPosition, robotToolPathList[index3].RoboPosition, upper, ref Devided);
              if (Devided.Count > 1 & flag3)
              {
                for (int index4 = 1; index4 <= Devided.Count - 1; ++index4)
                {
                  RobotToolPath robotToolPath3 = new RobotToolPath();
                  robotToolPath3.RoboPosition = Devided[index4];
                  robotToolPath3.entVectorNormal = (Entity) new Line(new Point3D(Devided[index4].PositionNoTool.X, Devided[index4].PositionNoTool.Y, Devided[index4].PositionNoTool.Z), new Point3D(Devided[index4].PositionNoTool.X + Devided[index4].IJKVector.X * 10.0, Devided[index4].PositionNoTool.Y + Devided[index4].IJKVector.Y * 10.0, Devided[index4].PositionNoTool.Z + Devided[index4].IJKVector.Z * 10.0));
                  CustomData customData = new CustomData();
                  robotToolPath3.entVectorNormal.EntityData = (object) customData;
                  this.activeRobotItem.ToolPaths.Add(robotToolPath3);
                }
                flag1 = true;
                flag2 = true;
              }
            }
          }
          else if (robotToolPathList[index3].RoboPosition.isCuttingMove && num1 > moveDevideLength2 * 2.0)
          {
            int upper = (int) buNumeric5.RoundToUpper(Math.Abs(num1) / moveDevideLength2);
            if (Math.Abs(num3) > moveDevideLength3)
              ;
            List<RobotPose> Devided = new List<RobotPose>();
            bool flag4 = clsInit.cRobotic.DevideToolPath(robotToolPathList[index3 - 1].RoboPosition, robotToolPathList[index3].RoboPosition, upper, ref Devided);
            if (Devided.Count > 1 & flag4)
            {
              for (int index5 = 1; index5 <= Devided.Count - 1; ++index5)
              {
                RobotToolPath robotToolPath4 = new RobotToolPath();
                robotToolPath4.RoboPosition = Devided[index5];
                robotToolPath4.entVectorNormal = (Entity) new Line(new Point3D(Devided[index5].PositionNoTool.X, Devided[index5].PositionNoTool.Y, Devided[index5].PositionNoTool.Z), new Point3D(Devided[index5].PositionNoTool.X + Devided[index5].IJKVector.X * 10.0, Devided[index5].PositionNoTool.Y + Devided[index5].IJKVector.Y * 10.0, Devided[index5].PositionNoTool.Z + Devided[index5].IJKVector.Z * 10.0));
                CustomData customData = new CustomData();
                robotToolPath4.entVectorNormal.EntityData = (object) customData;
                this.activeRobotItem.ToolPaths.Add(robotToolPath4);
              }
              flag1 = true;
              flag2 = true;
            }
          }
          if (!flag1)
          {
            bool flag5;
            if (Math.Abs(num4) > moveDevideLength3)
            {
              int upper = (int) buNumeric5.RoundToUpper(Math.Abs(num4) / moveDevideLength3);
              List<RobotPose> Devided = new List<RobotPose>();
              bool flag6 = clsInit.cRobotic.DevideToolPath(robotToolPathList[index3 - 1].RoboPosition, robotToolPathList[index3].RoboPosition, upper, ref Devided);
              if (Devided.Count > 1 & flag6)
              {
                for (int index6 = 1; index6 <= Devided.Count - 1; ++index6)
                {
                  RobotToolPath robotToolPath5 = new RobotToolPath();
                  robotToolPath5.RoboPosition = Devided[index6];
                  robotToolPath5.entVectorNormal = (Entity) new Line(new Point3D(Devided[index6].PositionNoTool.X, Devided[index6].PositionNoTool.Y, Devided[index6].PositionNoTool.Z), new Point3D(Devided[index6].PositionNoTool.X + Devided[index6].IJKVector.X * 10.0, Devided[index6].PositionNoTool.Y + Devided[index6].IJKVector.Y * 10.0, Devided[index6].PositionNoTool.Z + Devided[index6].IJKVector.Z * 10.0));
                  CustomData customData = new CustomData();
                  robotToolPath5.entVectorNormal.EntityData = (object) customData;
                  this.activeRobotItem.ToolPaths.Add(robotToolPath5);
                }
                flag5 = true;
                flag2 = true;
              }
            }
            if (Math.Abs(num3) > moveDevideLength3)
            {
              RobotPose PrePos = new RobotPose(robotToolPathList[index3 - 1].RoboPosition);
              RobotPose NextPos = new RobotPose(robotToolPathList[index3].RoboPosition);
              if (Math.Abs(num3) > 180.0)
              {
                if (num3 > 0.0)
                {
                  num3 = robotToolPathList[index3].RoboPosition.Orientation.Pitch - 360.0 - robotToolPathList[index3 - 1].RoboPosition.Orientation.Pitch;
                  NextPos.Orientation.Pitch = robotToolPathList[index3].RoboPosition.Orientation.Pitch - 360.0;
                }
                else
                {
                  num3 = robotToolPathList[index3].RoboPosition.Orientation.Pitch - (robotToolPathList[index3 - 1].RoboPosition.Orientation.Pitch - 360.0);
                  PrePos.Orientation.Pitch = robotToolPathList[index3 - 1].RoboPosition.Orientation.Pitch - 360.0;
                }
              }
              if (Math.Abs(num3) > moveDevideLength3)
              {
                int upper = (int) buNumeric5.RoundToUpper(Math.Abs(num3) / moveDevideLength3);
                if (upper > 5)
                  ;
                List<RobotPose> Devided = new List<RobotPose>();
                bool flag7 = clsInit.cRobotic.DevideToolPath(PrePos, NextPos, upper, ref Devided);
                if (Devided.Count > 1 & flag7)
                {
                  for (int index7 = 1; index7 <= Devided.Count - 1; ++index7)
                  {
                    RobotToolPath robotToolPath6 = new RobotToolPath();
                    robotToolPath6.RoboPosition = Devided[index7];
                    if (robotToolPath6.RoboPosition.Orientation.Pitch < 0.0)
                      robotToolPath6.RoboPosition.Orientation.Pitch = 360.0 + robotToolPath6.RoboPosition.Orientation.Pitch;
                    robotToolPath6.entVectorNormal = (Entity) new Line(new Point3D(Devided[index7].PositionNoTool.X, Devided[index7].PositionNoTool.Y, Devided[index7].PositionNoTool.Z), new Point3D(Devided[index7].PositionNoTool.X + Devided[index7].IJKVector.X * 10.0, Devided[index7].PositionNoTool.Y + Devided[index7].IJKVector.Y * 10.0, Devided[index7].PositionNoTool.Z + Devided[index7].IJKVector.Z * 10.0));
                    CustomData customData = new CustomData();
                    robotToolPath6.entVectorNormal.EntityData = (object) customData;
                    this.activeRobotItem.ToolPaths.Add(robotToolPath6);
                  }
                  flag5 = true;
                  flag2 = true;
                }
              }
            }
          }
          if (!flag2)
            this.activeRobotItem.ToolPaths.Add(robotToolPathList[index3]);
        }
        else
          this.activeRobotItem.ToolPaths.Add(robotToolPathList[index3]);
      }
      for (int index = 0; index <= this.activeRobotItem.ToolPaths.Count - 1; ++index)
      {
        this.activeRobotItem.Code = this.activeRobotItem.Code + $"{$"  MOVEFLY LINEAR TO POS({this.activeRobotItem.ToolPaths[index].RoboPosition.Position.X.ToString("f2")}, {this.activeRobotItem.ToolPaths[index].RoboPosition.Position.Y.ToString("f2")}, {this.activeRobotItem.ToolPaths[index].RoboPosition.Position.Z.ToString("f2")}, "}{this.activeRobotItem.ToolPaths[index].RoboPosition.Orientation.Roll.ToString("f2")}, {this.activeRobotItem.ToolPaths[index].RoboPosition.Orientation.Pitch.ToString("f2")}, {this.activeRobotItem.ToolPaths[index].RoboPosition.Orientation.Yaw.ToString("f2")},'w') ADVANCE" + Environment.NewLine;
        if (this.activeRobotItem.Code.Length > 1000)
        {
          this.activeRobotItem.Codes.Add(this.activeRobotItem.Code);
          this.activeRobotItem.Code = "";
        }
      }
      if (this.activeRobotItem.Code.Length > 0)
      {
        this.activeRobotItem.Codes.Add(this.activeRobotItem.Code);
        this.activeRobotItem.Code = "";
      }
      for (int index = 0; index <= Cam.SimilationPoint.SimMove.Count - 1; ++index)
      {
        Pnt6DSimMove pnt6DsimMove = Cam.SimilationPoint.SimMove[index];
        double B = 0.0;
        double C = 0.0;
        this.CalculateBCAngles(pnt6DsimMove.A, pnt6DsimMove.B, pnt6DsimMove.C, ref B, ref C);
        pnt6DsimMove.A = 0.0;
        pnt6DsimMove.B = B;
        pnt6DsimMove.C = C;
      }
      this.activeRobotItem.Codes.Add("END $$$");
      string str = buString5.StringListToString(this.activeRobotItem.Codes);
      Cam.PreCodes.Clear();
      Cam.PreCodes.Add((object) str);
      Cam.EntitiesG1Orj.Clear();
      clsInit.appCommand.CamAdd(Cam);
      clsInit.appCommand.Reset();
    }
    this.LastMWOptions = MWCalcoptions;
    this.LastPlungeFeed = PlungeFeed;
  }

  public void SaveRoboticFile()
  {
    string FileName1 = AppPath.Settings + "\\Robotic\\Robotic.prm";
    ArrayList StringList1 = new ArrayList();
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "   Robotic Settings");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "<RoboticSettings>");
    StringList1.AddRange((ICollection) buRoboticCalc.varRoboticSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList1.Add((object) "</RoboticSettings>");
    buFile.SaveToFile(StringList1, FileName1);
    buLog.addLog("Robotic Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    buMWRoboticVars.varCamContouring.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticWfContour.bin");
    buMWRoboticVars.varCamWFPocket.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticWfPocket.bin");
    buMWRoboticVars.varCamDrill.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticDrill.bin");
    buMWRoboticVars.varCamContouring.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticContouring.bin");
    buMWRoboticVars.varCamSurface4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticSurface4Axis.bin");
    buMWRoboticVars.varCamSurface5Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticSurface5Axis.bin");
    buMWRoboticVars.varCamMeshRough3Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmRough3Axis.bin");
    buMWRoboticVars.varCamMeshRough4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmRough4Axis.bin");
    buMWRoboticVars.varCamMeshParallel3Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel3Axis.bin");
    buMWRoboticVars.varCamMeshParallel4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel4Axis.bin");
    buMWRoboticVars.varCamMeshParallel5Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel5Axis.bin");
    buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ3Axis.bin");
    buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ4Axis.bin");
    buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ5Axis.bin");
    string FileName2 = AppPath.Settings + "\\Robotic\\RoboticCam.bucamset";
    ArrayList StringList2 = new ArrayList();
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "   MW Cam Settings");
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "<MwCamSettings>");
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamWFContour.buPar.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamWFPocket.buPar.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamDrill.buPar.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamContouring.buPar.ToDefAll("_buMWRoboticVars.varCamContouring", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamSurface4Axis.buPar.ToDefAll("_buMWRoboticVars.varCamSurface4Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamSurface5Axis.buPar.ToDefAll("_buMWRoboticVars.varCamSurface5Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshRough3Axis.buPar.ToDefAll("_varbuCamMeshRoughPars3Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshRough4Axis.buPar.ToDefAll("_varbuCamMeshRoughPars4Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshParallel3Axis.buPar.ToDefAll("_varbuCamMeshParallelPars3Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshParallel4Axis.buPar.ToDefAll("_varbuCamMeshParallelPars4Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshParallel5Axis.buPar.ToDefAll("_varbuCamMeshParallelPars5Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.ToDefAll("_varbuCamMeshContantZPars3Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.ToDefAll("_varbuCamMeshContantZPars4Axis", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.ToDefAll("_varbuCamMeshContantZPars5Axis", 2, SerilizationMode5.MultiLine));
    StringList2.Add((object) "</MwCamSettings>");
    buFile.SaveToFile(StringList2, FileName2);
  }

  public void OpenRoboticFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Robotic\\Robotic.prm");
      clsVar.Cf2Properties = new List<Cf2FileProperties>();
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<RoboticSettings>", "</RoboticSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buRoboticCalc.varRoboticSettings);
            buLog.addLog("RoboticSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Robotic Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Robotic Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.RoboticMode.Enable)
      {
        buLog.addLog("Robotic Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Robotic Settings File Missing");
      }
      buLog.addLog("Robotic Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticWfContour.bin");
      if (fileInfo2.Exists)
        buMWRoboticVars.varCamWFContour.mwPar.Deserialize(fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticWfPocket.bin");
      if (fileInfo3.Exists)
        buMWRoboticVars.varCamWFPocket.mwPar.Deserialize(fileInfo3.FullName);
      FileInfo fileInfo4 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticDrill.bin");
      if (fileInfo4.Exists)
        buMWRoboticVars.varCamDrill.mwPar.Deserialize(fileInfo4.FullName);
      FileInfo fileInfo5 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticContouring.bin");
      if (fileInfo5.Exists)
        buMWRoboticVars.varCamContouring.mwPar.Deserialize(fileInfo5.FullName);
      FileInfo fileInfo6 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticSurface4Axis.bin");
      if (fileInfo6.Exists)
        buMWRoboticVars.varCamSurface4Axis.mwPar.Deserialize(fileInfo6.FullName);
      FileInfo fileInfo7 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticSurface5Axis.bin");
      if (fileInfo7.Exists)
        buMWRoboticVars.varCamSurface5Axis.mwPar.Deserialize(fileInfo7.FullName);
      FileInfo fileInfo8 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmRough3Axis.bin");
      if (fileInfo8.Exists)
        buMWRoboticVars.varCamMeshRough3Axis.mwPar.Deserialize(fileInfo8.FullName);
      FileInfo fileInfo9 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmRough4Axis.bin");
      if (fileInfo9.Exists)
        buMWRoboticVars.varCamMeshRough4Axis.mwPar.Deserialize(fileInfo9.FullName);
      FileInfo fileInfo10 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel3Axis.bin");
      if (fileInfo10.Exists)
        buMWRoboticVars.varCamMeshParallel3Axis.mwPar.Deserialize(fileInfo10.FullName);
      FileInfo fileInfo11 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel4Axis.bin");
      if (fileInfo11.Exists)
        buMWRoboticVars.varCamMeshParallel4Axis.mwPar.Deserialize(fileInfo11.FullName);
      FileInfo fileInfo12 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel5Axis.bin");
      if (fileInfo12.Exists)
        buMWRoboticVars.varCamMeshParallel5Axis.mwPar.Deserialize(fileInfo12.FullName);
      FileInfo fileInfo13 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ3Axis.bin");
      if (fileInfo13.Exists)
        buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.Deserialize(fileInfo13.FullName);
      FileInfo fileInfo14 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ4Axis.bin");
      if (fileInfo14.Exists)
        buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.Deserialize(fileInfo14.FullName);
      FileInfo fileInfo15 = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ5Axis.bin");
      if (fileInfo15.Exists)
        buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.Deserialize(fileInfo15.FullName);
      string str = AppPath.Settings + "\\Robotic\\RoboticCam.bucamset";
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
          buSerilization5.Decode(StringList, "_varbuCamWFContourPars", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamWFContour.buPar);
          buSerilization5.Decode(StringList, "_varbuCamWFPocketPars", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamWFPocket.buPar);
          buSerilization5.Decode(StringList, "_varbuCamDrillPars", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamDrill.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshRoughPars3Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshRough3Axis.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshRoughPars4Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshRough4Axis.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshParallelPars3Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshParallel3Axis.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshParallelPars4Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshParallel4Axis.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshParallelPars5Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshParallel5Axis.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshContantZPars3Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshConstantZ3Axis.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshContantZPars4Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshConstantZ4Axis.buPar);
          buSerilization5.Decode(StringList, "_varbuCamMeshContantZPars5Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamMeshConstantZ5Axis.buPar);
          buSerilization5.Decode(StringList, "_buMWRoboticVars.varCamContouring", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamContouring.buPar);
          buSerilization5.Decode(StringList, "_buMWRoboticVars.varCamSurface4Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamSurface4Axis.buPar);
          buSerilization5.Decode(StringList, "_buMWRoboticVars.varCamSurface5Axis", SerilizationMode5.MultiLine, (object) buMWRoboticVars.varCamSurface5Axis.buPar);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Marble Settings Decoder Error");
        }
      }
      else
      {
        if (!clsVar.appModes_0.RoboticMode.Enable)
          return;
        buLog.addLog("Robotic Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Robotic Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("Robotic Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Robotic Settings Decoder Error");
    }
  }

  public void DrawSurfacePointsAsDynamicLine(int SelectedPoint)
  {
    ccVars.pntDrawDynamicLinesArrColored.Clear();
    for (int index1 = 0; index1 <= this.SurfacePoints.Count - 1; ++index1)
    {
      Color color1 = Color.Red;
      Color color2 = Color.Purple;
      Color gold = Color.Gold;
      Color darkOrange = Color.DarkOrange;
      if (SelectedPoint != -1 && SelectedPoint == index1)
      {
        color1 = Color.Blue;
        color2 = Color.Blue;
      }
      if (this.SurfacePoints[index1].Enable)
      {
        List<PointRGB> pointRgbList1 = new List<PointRGB>();
        if (this.SurfacePoints[index1].entNormal != null)
        {
          for (int index2 = 0; index2 <= this.SurfacePoints[index1].entNormal.Vertices.Length - 1; ++index2)
          {
            Point3D point3D = buVector5.ToPoint3D(this.SurfacePoints[index1].entNormal.Vertices[index2]);
            pointRgbList1.Add(new PointRGB(point3D.X, point3D.Y, point3D.Z, color1.R, color1.G, color1.B));
          }
        }
        if (this.SurfacePoints[index1].entTangent != null)
        {
          for (int index3 = 0; index3 <= this.SurfacePoints[index1].entTangent.Vertices.Length - 1; ++index3)
          {
            Point3D point3D = buVector5.ToPoint3D(this.SurfacePoints[index1].entTangent.Vertices[index3]);
            pointRgbList1.Add(new PointRGB(point3D.X, point3D.Y, point3D.Z, color2.R, color2.G, color2.B));
          }
        }
        if (pointRgbList1.Count > 0)
          ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList1);
        List<PointRGB> pointRgbList2 = new List<PointRGB>();
        if (this.SurfacePoints[index1].entLeadIn != null)
        {
          for (int index4 = 0; index4 <= this.SurfacePoints[index1].entLeadIn.Vertices.Length - 1; ++index4)
          {
            Point3D point3D = buVector5.ToPoint3D(this.SurfacePoints[index1].entLeadIn.Vertices[index4]);
            pointRgbList2.Add(new PointRGB(point3D.X, point3D.Y, point3D.Z, gold.R, gold.G, gold.B));
          }
        }
        if (pointRgbList2.Count > 0)
          ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList2);
        List<PointRGB> pointRgbList3 = new List<PointRGB>();
        if (this.SurfacePoints[index1].entSafeIn != null)
        {
          for (int index5 = 0; index5 <= this.SurfacePoints[index1].entSafeIn.Vertices.Length - 1; ++index5)
          {
            Point3D point3D = buVector5.ToPoint3D(this.SurfacePoints[index1].entSafeIn.Vertices[index5]);
            pointRgbList3.Add(new PointRGB(point3D.X, point3D.Y, point3D.Z, darkOrange.R, darkOrange.G, darkOrange.B));
          }
        }
        if (pointRgbList3.Count > 0)
          ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList3);
        List<PointRGB> pointRgbList4 = new List<PointRGB>();
        if (this.SurfacePoints[index1].entLeadOut != null)
        {
          for (int index6 = 0; index6 <= this.SurfacePoints[index1].entLeadOut.Vertices.Length - 1; ++index6)
          {
            Point3D point3D = buVector5.ToPoint3D(this.SurfacePoints[index1].entLeadOut.Vertices[index6]);
            pointRgbList4.Add(new PointRGB(point3D.X, point3D.Y, point3D.Z, gold.R, gold.G, gold.B));
          }
        }
        if (pointRgbList4.Count > 0)
          ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList4);
        List<PointRGB> pointRgbList5 = new List<PointRGB>();
        if (this.SurfacePoints[index1].entSafeOut != null)
        {
          for (int index7 = 0; index7 <= this.SurfacePoints[index1].entSafeOut.Vertices.Length - 1; ++index7)
          {
            Point3D point3D = buVector5.ToPoint3D(this.SurfacePoints[index1].entSafeOut.Vertices[index7]);
            pointRgbList5.Add(new PointRGB(point3D.X, point3D.Y, point3D.Z, darkOrange.R, darkOrange.G, darkOrange.B));
          }
        }
        if (pointRgbList5.Count > 0)
          ccVars.pntDrawDynamicLinesArrColored.Add(pointRgbList5);
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void CreateCode(string FileName)
  {
    if (ccVars.Pages[ccVars.PageIndex].Cams.Count <= 0)
      return;
    buFile5.SaveToFile(ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes, FileName);
  }

  public GeoLib Default4Or5AxisParameter(
    GeoLib MwPar,
    int AxisNumber,
    Vector3D vecRotation,
    double BAngLimit,
    double AAngleLimit,
    bool RadiusFit)
  {
    MwPar.MachParam.RadiusFitFlg = RadiusFit;
    MwPar.MachParam.SplineMaxDeviation = MwPar.MachParam.CutTolerance;
    MwPar.MachParam.MaxAngleChange = 3.0;
    MwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveFlg = false;
    MwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinStepover = 0.2;
    MwPar.MachParam.ToolAxisControlParams.Cur4AxisDef.SetBasePointAndDirection(new Point3d<double>(0.0, 0.0, 0.0), new Point3d<double>(vecRotation.X, vecRotation.Y, vecRotation.Z));
    MwPar.MachParam.ToolAxisControlParams.TiltStrategy = MachiningParamsTiltStrategy.NoTilt;
    MwPar.MachParam.ToolAxisControlParams.LagAngle = 0.0;
    MwPar.MachParam.ToolAxisControlParams.SideTiltAngle = 0.0;
    MwPar.MachParam.ToolAxisControlParams.CurSideTiltDefType = MachiningParamsSideTiltDefTypes.FollowSurfIsoDir;
    MwPar.MachParam.ToolAxisControlParams.SmoothingFlg = true;
    MwPar.MachParam.ToolAxisControlParams.LimitsFlg = true;
    MwPar.MachParam.ToolAxisControlParams.ToolAxisSmoothingParams.MaxAngleFromInitialToolOrientation = 30.0;
    MwPar.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = false;
    if (BAngLimit > 0.0)
      MwPar.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
    MwPar.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = BAngLimit;
    MwPar.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 180.0 - BAngLimit;
    MwPar.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = false;
    if (AAngleLimit > 0.0)
      MwPar.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
    MwPar.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = AAngleLimit;
    MwPar.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 180.0 - AAngleLimit;
    MwPar.MachParam.ToolAxisControlParams.CAngleLimitInXYPlaneFlg = false;
    MwPar.MachParam.ToolAxisControlParams.CAngleLimitStartInXYPlane = 0.0;
    MwPar.MachParam.ToolAxisControlParams.CAngleLimitEndInXYPlane = 360.0;
    MwPar.MachParam.ToolAxisControlParams.WOrtAngleLimitFlg = true;
    MwPar.MachParam.ToolAxisControlParams.WOrtAngleLimitStart = 0.0;
    MwPar.MachParam.ToolAxisControlParams.WOrtAngleLimitEnd = 80.0;
    return MwPar;
  }

  public void doContourFromWireAndAngle(double Angle)
  {
    camTp cam = new camTp();
    List<Entity> selectedEntities = new List<Entity>();
    clsInit.appCommand.SelectionToEntities(ref selectedEntities, new SelectionOption()
    {
      CircleToArc = true,
      CircleTo4Arc = true,
      SplitArcIfGreatThen180 = true,
      Point = false
    });
    List<buEntity> buEntityList = new List<buEntity>();
    List<buEntity> SortedEntities = new List<buEntity>();
    buEntity.Copy(selectedEntities, ref buEntityList);
    clsInit.cVector5.SortEntitiesByRefPoint(buEntityList[0].StartPoint, ref buEntityList, new SortbuSettings()
    {
      Option = {
        NextGroupRules = SortingNextGroupFindRulesType.ClosestLength
      }
    }, ref SortedEntities);
    List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
    clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
    List<RoboticSurfacePoint> roboticSurfacePointList = new List<RoboticSurfacePoint>();
    for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
    {
      List<Point3D> Vertices = new List<Point3D>();
      clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index1], ref Vertices);
      clsInit.cVector5.DevidePointsByLength(ref Vertices, 5.0);
      if (clsInit.cVector5.GetClockDirection(Vertices) == ClockDirectionType.CW)
        Vertices.Reverse();
      for (int index2 = 0; index2 <= Vertices.Count - 1; ++index2)
      {
        RoboticSurfacePoint roboticSurfacePoint1 = new RoboticSurfacePoint();
        roboticSurfacePoint1.pntBase = new Point3D(Vertices[index2].X, Vertices[index2].Y, Vertices[index2].Z);
        if (index2 == 0)
        {
          double c = clsInit.cVector5.PointAngle(Vertices[index2 + 1], Vertices[index2]);
          Point3D EndPnt = new Point3D();
          clsInit.cVector5.LineWithLengthAndAngle(Vertices[index2], 50.0, c - 90.0, ref EndPnt);
          Line refEntity = new Line(Vertices[index2], EndPnt);
          Vector3D axis = new Vector3D(Vertices[index2].X - Vertices[index2 + 1].X, Vertices[index2].Y - Vertices[index2 + 1].Y);
          refEntity.Rotate(buConversion5.DegreeToRadian(45.0), axis, Vertices[index2]);
          refEntity.Regen(0.1);
          double a = 45.0;
          double b = 0.0;
          List<Point3D> pntDevided = new List<Point3D>();
          clsInit.cVector5.EntityDevide((Entity) refEntity, 5.0, ref pntDevided);
          pntDevided.Reverse();
          for (int index3 = 0; index3 <= pntDevided.Count - 1; ++index3)
          {
            RoboticSurfacePoint roboticSurfacePoint2 = new RoboticSurfacePoint();
            roboticSurfacePoint2.pntTangent = new Pnt6D(pntDevided[index3].X, pntDevided[index3].Y, pntDevided[index3].Z, a, b, c);
            if (index3 == 0)
              roboticSurfacePoint2.entSafeIn = (Entity) refEntity;
            roboticSurfacePointList.Add(roboticSurfacePoint2);
          }
          roboticSurfacePoint1.pntTangent = new Pnt6D(Vertices[index2].X, Vertices[index2].Y, Vertices[index2].Z, a, b, c);
          roboticSurfacePointList.Add(roboticSurfacePoint1);
        }
        else
        {
          double c = clsInit.cVector5.PointAngle(Vertices[index2], Vertices[index2 - 1]);
          Point3D EndPnt = new Point3D();
          clsInit.cVector5.LineWithLengthAndAngle(Vertices[index2], 50.0, c - 90.0, ref EndPnt);
          Line refEntity = new Line(Vertices[index2], EndPnt);
          Vector3D axis = new Vector3D(Vertices[index2 - 1].X - Vertices[index2].X, Vertices[index2 - 1].Y - Vertices[index2].Y);
          refEntity.Rotate(buConversion5.DegreeToRadian(45.0), axis, Vertices[index2 - 1]);
          refEntity.Regen(0.1);
          double a = 45.0;
          double b = 0.0;
          roboticSurfacePoint1.pntTangent = new Pnt6D(Vertices[index2].X, Vertices[index2].Y, Vertices[index2].Z, a, b, c);
          roboticSurfacePointList.Add(roboticSurfacePoint1);
          if (index2 == Vertices.Count - 1)
          {
            List<Point3D> pntDevided = new List<Point3D>();
            clsInit.cVector5.EntityDevide((Entity) refEntity, 5.0, ref pntDevided);
            for (int index4 = 0; index4 <= pntDevided.Count - 1; ++index4)
            {
              RoboticSurfacePoint roboticSurfacePoint3 = new RoboticSurfacePoint();
              roboticSurfacePoint3.pntTangent = new Pnt6D(pntDevided[index4].X, pntDevided[index4].Y, pntDevided[index4].Z, a, b, c);
              if (index4 == 0)
                roboticSurfacePoint3.entSafeOut = (Entity) refEntity;
              roboticSurfacePointList.Add(roboticSurfacePoint3);
            }
          }
        }
      }
    }
    for (int index = 0; index <= roboticSurfacePointList.Count - 1; ++index)
    {
      Pnt6D pntTangent = roboticSurfacePointList[index].pntTangent;
      if (pntTangent != (Pnt6D) null)
      {
        double a = roboticSurfacePointList[index].pntTangent.A;
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        num1 = a <= 90.0 ? 180.0 - (90.0 - a) : a - 270.0;
        num2 = roboticSurfacePointList[index].pntTangent.B <= 90.0 ? roboticSurfacePointList[index].pntTangent.B - 90.0 : roboticSurfacePointList[index].pntTangent.B - 90.0;
        num2 = 0.0;
        string str = $"{$"{roboticSurfacePointList[index].pntTangent.X.ToString("f2")};{roboticSurfacePointList[index].pntTangent.Y.ToString("f2")};{roboticSurfacePointList[index].pntTangent.Z.ToString("f2")};"}{num1.ToString("f2")};{num2.ToString("f2")};{num3.ToString("f2")};" + "100;0;0;0;1;100;";
        cam.PreCodes.Add((object) str);
        Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(roboticSurfacePointList[index].pntTangent.X, roboticSurfacePointList[index].pntTangent.Y, roboticSurfacePointList[index].pntTangent.Z, pntTangent.A, pntTangent.B, pntTangent.C);
        cam.SimilationPoint.SimMove.Add(pnt6DsimMove);
      }
    }
    cam.PreCodes.Insert(0, (object) ((cam.PreCodes.Count + 1).ToString() + ";"));
    string str1 = $"{roboticSurfacePointList[roboticSurfacePointList.Count - 1].pntTangent.X.ToString("f2")};{roboticSurfacePointList[roboticSurfacePointList.Count - 1].pntTangent.Y.ToString("f2")};{(roboticSurfacePointList[roboticSurfacePointList.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2")};" + "0.00;0.00;0.00;100;0;0;0;1;100;";
    cam.PreCodes.Add((object) str1);
    cam.Tool = new ToolBase5(ccVars.toolActive);
    cam.TypeCam = CamType.Contour;
    for (int index = 0; index <= roboticSurfacePointList.Count - 1; ++index)
    {
      if (roboticSurfacePointList[index].entTangent != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entTangent, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
    }
    for (int index = 0; index <= roboticSurfacePointList.Count - 1; ++index)
    {
      if (roboticSurfacePointList[index].entSafeIn != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entSafeIn, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
      if (roboticSurfacePointList[index].entLeadIn != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entLeadIn, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
      if (roboticSurfacePointList[index].entSafeOut != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entSafeOut, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
      if (roboticSurfacePointList[index].entLeadOut != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entLeadOut, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
    }
    cam.CamPoints.Clear();
    clsInit.appCommand.CamAdd(cam);
    clsInit.appCommand.Reset();
  }

  public void doWireframeContourRobotic(MWCalculationOptions MWCalcoptions, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    MWCalcoptions.StartPointX = 0.0;
    MWCalcoptions.StartPointY = 0.0;
    buMWRoboticVars.varCamWFContour.buPar.Sorting.Option.NextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
    buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamWFContour, ref buMWCalcs.varCamWFContourPars);
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
    buMWCalcs.CopyCamParameter(buMWCalcs.varCamWFContourPars, ref buMWRoboticVars.varCamWFContour);
    if (num < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      List<Point3D> point3DList = new List<Point3D>();
      if (Cam.CamPoints.Count > 0)
      {
        for (int index1 = 0; index1 <= Cam.CamPoints.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= Cam.CamPoints[index1].Points.Count - 1; ++index2)
          {
            if (MWCalcoptions.NumberofAxis == 5)
            {
              point3DList.Add(new Point3D(Cam.CamPoints[index1].Points[index2].P9.X, Cam.CamPoints[index1].Points[index2].P9.Y, 0.0));
            }
            else
            {
              string str1 = "-180.00";
              string str2 = "0.00";
              string str3 = "0.00";
              string str4 = $"{$"{Cam.CamPoints[index1].Points[index2].P9.X.ToString("f2")};{Cam.CamPoints[index1].Points[index2].P9.Y.ToString("f2")};{Cam.CamPoints[index1].Points[index2].P9.Z.ToString("f2")};"}{str1};{str2};{str3};" + "50;0;0;0;1;0;";
              Cam.PreCodes.Add((object) str4);
            }
          }
        }
        Cam.PreCodes.Insert(0, (object) (Cam.PreCodes.Count.ToString() + ";"));
      }
      Cam.CamPoints.Clear();
      clsInit.appCommand.Reset();
    }
  }

  public void doTriangleMeshRough(
    MWCalculationOptions MWCalcoptions,
    Point3D pntMinOrj,
    Point3D pntMaxOrj)
  {
    try
    {
      double RotateAngle = -90.0;
      if (RoboticTempVars.FaceType == CamFrontBackAll.Back)
        RotateAngle = 90.0;
      if (MWCalcoptions.NumberofAxis == 3)
      {
        buMWRoboticVars.varCamMeshRough3Axis.buPar.Operations.isCircularCam = false;
        F_CamRough4XSettings camRough4Xsettings = new F_CamRough4XSettings();
        camRough4Xsettings.Settings = buMWRoboticVars.varCamMeshRough3Axis.buPar;
        camRough4Xsettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
        camRough4Xsettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        camRough4Xsettings.Init();
        int num = (int) camRough4Xsettings.ShowDialog();
        if (camRough4Xsettings.PropertiesForm.Result != DialogResult.OK)
          return;
        buMWRoboticVars.varCamMeshRough3Axis.buPar = camRough4Xsettings.Settings;
        Point3D point3D1 = new Point3D(pntMinOrj.X, pntMinOrj.Y, pntMinOrj.Z);
        Point3D point3D2 = new Point3D(pntMaxOrj.X, pntMaxOrj.Y, pntMaxOrj.Z);
        point3D1.X += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMin.X;
        point3D1.Y += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMin.Y;
        point3D1.Z += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMin.Z;
        point3D2.X += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMax.X;
        point3D2.Y += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMax.Y;
        point3D2.Z += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMax.Z;
        Mesh box = Mesh.CreateBox(point3D2.X - point3D1.X, point3D2.Y - point3D1.Y, point3D2.Z - point3D1.Z);
        box.Translate(point3D1.X, point3D1.Y, point3D1.Z);
        box.Regen(0.1);
        clsMW.StockEntities.Add((Entity) box);
        buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.StartOffset;
        buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.EndValue = 0.0 + buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.EndOffset;
        buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
        buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultipleDirectionsFlg = false;
        buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningDirectionsForMesh[0] = new Vectord(0.0, 0.0, 1.0);
        buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
        buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0].Status = false;
        clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshRough3Axis.mwPar, buMWRoboticVars.varCamMeshRough3Axis.buPar, out clsMW.varbuCamMeshRoughPars);
        if (clsMW.varbuCamMeshRoughPars.Distances.Safe < pntMaxOrj.Z)
          clsMW.varbuCamMeshRoughPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshRoughPars.Distances.Rapid, 3);
        clsMW.varMWCamMeshRoughPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshRoughPars, buMWRoboticVars.varCamMeshRough3Axis.buPar);
        clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
        clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
        clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockOffsetMode = (CollCtrlOpStockParamsStockOffsetMode) Convert.ToInt32((object) buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMode);
        clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockDefTolerance = buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffset;
        clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance = buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockTolarance;
        clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StBoundingBox;
        if (buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.StBoundingBox | buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.St2dContainment)
          clsMW.StockEntities.Clear();
        if (clsMW.StockEntities.Count > 0)
        {
          clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock;
          clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StSurfaces;
        }
      }
      if (MWCalcoptions.NumberofAxis == 4)
      {
        buMWRoboticVars.varCamMeshRough3Axis.buPar.Operations.isCircularCam = true;
        F_CamRough4XSettings camRough4Xsettings = new F_CamRough4XSettings();
        camRough4Xsettings.Settings = buMWRoboticVars.varCamMeshRough4Axis.buPar;
        camRough4Xsettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
        camRough4Xsettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        camRough4Xsettings.Init();
        int num = (int) camRough4Xsettings.ShowDialog();
        if (camRough4Xsettings.PropertiesForm.Result != DialogResult.OK)
          return;
        buMWRoboticVars.varCamMeshRough4Axis.buPar = camRough4Xsettings.Settings;
        SelectionOption Option = new SelectionOption(false, true, false, false, false, false);
        List<Entity> selectedEntities = new List<Entity>();
        clsInit.appCommand.SelectionToEntities(ref selectedEntities, Option);
        clsMW.CamEntities.Clear();
        for (int index = 0; index <= selectedEntities.Count - 1; ++index)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(selectedEntities[index], ref copiedEntity);
          clsMW.CamEntities.Add(copiedEntity);
        }
        clsInit.cVector5.Rotate(new Point3D(), RotateAngle, Vector3D.AxisX, ref clsMW.CamEntities);
        clsInit.cVector5.RegenEntities(0.1, ref clsMW.CamEntities);
        buMWRoboticVars.varCamMeshRough4Axis.buPar.Strategy.RotaryAxis = VectorType.YVector;
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(clsMW.CamEntities, ref MinPoint, ref MaxPoint);
        if (buMWRoboticVars.varCamMeshRough4Axis.buPar.Strategy.RotaryAxis == VectorType.YVector)
        {
          MinPoint.X += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMin.X;
          MinPoint.Y += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMin.Z;
          MinPoint.Z += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMin.Y;
          MaxPoint.X += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMax.X;
          MaxPoint.Y += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMax.Z;
          MaxPoint.Z += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMax.Y;
        }
        Mesh box = Mesh.CreateBox(MaxPoint.X - MinPoint.X, MaxPoint.Y - MinPoint.Y, MaxPoint.Z - MinPoint.Z);
        box.Translate(MinPoint.X, MinPoint.Y, MinPoint.Z);
        box.Regen(0.1);
        clsMW.StockEntities.Add((Entity) box);
        buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.StartValue = MaxPoint.Z + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.StartOffset;
        buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.EndValue = 0.0 + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.EndOffset;
        buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
        buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultipleDirectionsFlg = false;
        buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningDirectionsForMesh[0] = new Vectord(0.0, 0.0, 1.0);
        buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
        buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0].Status = false;
        clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshRough4Axis.mwPar, buMWRoboticVars.varCamMeshRough4Axis.buPar, out clsMW.varbuCamMeshRoughPars);
        if (clsMW.varbuCamMeshRoughPars.Distances.Safe < MaxPoint.Z)
          clsMW.varbuCamMeshRoughPars.Distances.Safe = Math.Round(MaxPoint.Z + clsMW.varbuCamMeshRoughPars.Distances.Rapid, 3);
        clsMW.varMWCamMeshRoughPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshRoughPars, buMWRoboticVars.varCamMeshRough4Axis.buPar);
        clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockOffsetMode = (CollCtrlOpStockParamsStockOffsetMode) Convert.ToInt32((object) buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMode);
        clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockDefTolerance = buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffset;
        clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance = buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockTolarance;
        clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StBoundingBox;
        if (buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.StBoundingBox | buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.St2dContainment)
          clsMW.StockEntities.Clear();
        if (clsMW.StockEntities.Count > 0)
          clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StSurfaces;
      }
      clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.Status = true;
    }
    catch (Exception ex)
    {
    }
  }

  public void doTriangleMeshParallelCut(
    MWCalculationOptions MWCalcoptions,
    Point3D pntMinOrj,
    Point3D pntMaxOrj)
  {
    try
    {
      double RotateAngle = -90.0;
      if (RoboticTempVars.FaceType == CamFrontBackAll.Back)
        RotateAngle = 90.0;
      if (MWCalcoptions.NumberofAxis == 3)
      {
        buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.isCircularCam = false;
        F_CamParallelCutSettings parallelCutSettings = new F_CamParallelCutSettings();
        parallelCutSettings.Settings = buMWRoboticVars.varCamMeshParallel3Axis.buPar;
        parallelCutSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
        parallelCutSettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
        parallelCutSettings.Init();
        int num = (int) parallelCutSettings.ShowDialog();
        if (parallelCutSettings.PropertiesForm.Result != DialogResult.OK)
          return;
        buMWRoboticVars.varCamMeshParallel3Axis.buPar = parallelCutSettings.Settings;
        if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.Y, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.Y, 0.0))
        {
          List<Point3D> Vertices = new List<Point3D>();
          Entity entRectangle = (Entity) null;
          clsInit.cVector5.Rectangle2Point(new Point3D(pntMinOrj.X + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.X, pntMinOrj.Y + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(pntMaxOrj.X + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.X, pntMaxOrj.Y + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices, ref entRectangle);
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) Vertices);
          clsMW.Containment2DEntities.Add((Entity) linearPath);
        }
        buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.StartOffset;
        buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.EndValue = pntMinOrj.Z + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.EndValue;
        buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0].Status = false;
        buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
        buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
        buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel3Axis.mwPar, buMWRoboticVars.varCamMeshParallel3Axis.buPar, out clsMW.varbuCamMeshParallelPars);
        if (clsMW.varbuCamMeshParallelPars.Distances.Safe < pntMaxOrj.Z)
          clsMW.varbuCamMeshParallelPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshParallelPars.Distances.Rapid, 3);
        clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars);
      }
      if (MWCalcoptions.NumberofAxis == 4)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        if (MWCalcoptions.CamRotateType == CamRotationType.Circular)
        {
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.isCircularCam = true;
          F_CamParallelCutSettings parallelCutSettings = new F_CamParallelCutSettings();
          parallelCutSettings.Settings = buMWRoboticVars.varCamMeshParallel3Axis.buPar;
          parallelCutSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
          parallelCutSettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
          parallelCutSettings.Init();
          int num = (int) parallelCutSettings.ShowDialog();
          if (parallelCutSettings.PropertiesForm.Result != DialogResult.OK)
            return;
          buMWRoboticVars.varCamMeshParallel4Axis.buPar = parallelCutSettings.Settings;
          SelectionOption Option = new SelectionOption(false, true, false, false, false, false);
          List<Entity> selectedEntities = new List<Entity>();
          clsInit.appCommand.SelectionToEntities(ref selectedEntities, Option);
          clsMW.CamEntities.Clear();
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.Containment2dParams.IsUsedFlg = false;
          for (int index = 0; index <= selectedEntities.Count - 1; ++index)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(selectedEntities[index], ref copiedEntity);
            clsMW.CamEntities.Add(copiedEntity);
          }
          clsInit.cVector5.Rotate(new Point3D(), RotateAngle, Vector3D.AxisX, ref clsMW.CamEntities);
          clsInit.cVector5.RegenEntities(0.1, ref clsMW.CamEntities);
          clsInit.cVector5.BoxSizeCalculate(clsMW.CamEntities, ref MinPoint, ref MaxPoint);
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Distances.Safe = MaxPoint.Z - MinPoint.Z + 10.0;
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Distances.Air = MaxPoint.Z - MinPoint.Z + 10.0;
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.StartValue = MaxPoint.Z + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.StartOffset;
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.EndValue = 0.0 + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.EndOffset;
          clsMW.Containment2DEntities.Clear();
          Point3D point3D1 = new Point3D(MinPoint.X, MinPoint.Y);
          Point3D point3D2 = new Point3D(MaxPoint.X, MaxPoint.Y);
          List<Point3D> Vertices = new List<Point3D>();
          Entity entRectangle = (Entity) null;
          clsInit.cVector5.Rectangle2Point(new Point3D(point3D1.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.X, point3D1.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(point3D2.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.X, point3D2.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices, ref entRectangle);
          LinearPath linearPath = new LinearPath((ICollection<Point3D>) Vertices);
          clsMW.Containment2DEntities.Add((Entity) linearPath);
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.Containment2dParams.IsUsedFlg = true;
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar = this.Default4Or5AxisParameter(buMWRoboticVars.varCamMeshParallel4Axis.mwPar, 4, Vector3D.AxisY, 45.0, 45.0, false);
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
          clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel4Axis.mwPar, buMWRoboticVars.varCamMeshParallel4Axis.buPar, out clsMW.varbuCamMeshParallelPars);
          clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, buMWRoboticVars.varCamMeshParallel4Axis.buPar);
        }
        else
        {
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.isCircularCam = false;
          F_CamParallelCutSettings parallelCutSettings = new F_CamParallelCutSettings();
          parallelCutSettings.Settings = buMWRoboticVars.varCamMeshParallel4Axis.buPar;
          parallelCutSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
          parallelCutSettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
          parallelCutSettings.Init();
          int num = (int) parallelCutSettings.ShowDialog();
          if (parallelCutSettings.PropertiesForm.Result != DialogResult.OK)
            return;
          buMWRoboticVars.varCamMeshParallel4Axis.buPar = parallelCutSettings.Settings;
          if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.Y, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.Y, 0.0))
          {
            List<Point3D> Vertices = new List<Point3D>();
            Entity entRectangle = (Entity) null;
            clsInit.cVector5.Rectangle2Point(new Point3D(pntMinOrj.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.X, pntMinOrj.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(pntMaxOrj.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.X, pntMaxOrj.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices, ref entRectangle);
            LinearPath linearPath = new LinearPath((ICollection<Point3D>) Vertices);
            clsMW.Containment2DEntities.Add((Entity) linearPath);
          }
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.StartOffset;
          buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.EndValue = pntMinOrj.Z + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.EndValue;
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
          clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel4Axis.mwPar, buMWRoboticVars.varCamMeshParallel4Axis.buPar, out clsMW.varbuCamMeshParallelPars);
          if (clsMW.varbuCamMeshParallelPars.Distances.Safe < pntMaxOrj.Z)
            clsMW.varbuCamMeshParallelPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshParallelPars.Distances.Rapid, 3);
          clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars);
        }
      }
      if (MWCalcoptions.NumberofAxis != 5)
        return;
      buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.isCircularCam = false;
      F_CamParallelCutSettings parallelCutSettings1 = new F_CamParallelCutSettings();
      parallelCutSettings1.Settings = buMWRoboticVars.varCamMeshParallel3Axis.buPar;
      parallelCutSettings1.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      parallelCutSettings1.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      parallelCutSettings1.Init();
      int num1 = (int) parallelCutSettings1.ShowDialog();
      if (parallelCutSettings1.PropertiesForm.Result != DialogResult.OK)
        return;
      buMWRoboticVars.varCamMeshParallel5Axis.buPar = parallelCutSettings1.Settings;
      if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.Y, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.Y, 0.0))
      {
        List<Point3D> Vertices = new List<Point3D>();
        Entity entRectangle = (Entity) null;
        clsInit.cVector5.Rectangle2Point(new Point3D(pntMinOrj.X + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.X, pntMinOrj.Y + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(pntMaxOrj.X + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.X, pntMaxOrj.Y + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices, ref entRectangle);
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) Vertices);
        clsMW.Containment2DEntities.Add((Entity) linearPath);
      }
      buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.StartOffset;
      buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.EndValue = pntMinOrj.Z + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.EndValue;
      buMWRoboticVars.varCamMeshParallel5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
      buMWRoboticVars.varCamMeshParallel5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
      buMWRoboticVars.varCamMeshParallel5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
      clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel5Axis.mwPar, buMWRoboticVars.varCamMeshParallel5Axis.buPar, out clsMW.varbuCamMeshParallelPars);
      if (clsMW.varbuCamMeshParallelPars.Distances.Safe < pntMaxOrj.Z)
        clsMW.varbuCamMeshParallelPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshParallelPars.Distances.Rapid, 3);
      clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, buMWRoboticVars.varCamMeshParallel5Axis.buPar);
    }
    catch (Exception ex)
    {
    }
  }

  public void doTriangleMesh(MWCalculationOptions MWCalcoptions)
  {
    camTp Cam = new camTp();
    double num1 = -90.0;
    double PlungeFeed = 10.0;
    if (RoboticTempVars.FaceType == CamFrontBackAll.Back)
      num1 = 90.0;
    Point3D MinPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    MWCalcoptions.AddToCamListInMWCalculation = false;
    MWCalcoptions.DontApplyReset = true;
    clsMW.varMWCamMeshRoughPars.MachParam.Containment2dParams.IsUsedFlg = false;
    clsMW.varMWCamMeshParalelPars.MachParam.Containment2dParams.IsUsedFlg = false;
    clsMW.varMWCamMeshContantZPars.MachParam.Containment2dParams.IsUsedFlg = false;
    clsMW.Containment2DEntities.Clear();
    clsMW.StockEntities.Clear();
    if (MWCalcoptions.NumberofAxis == 3)
    {
      buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
      buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
      buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
      buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0].Status = false;
      buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0].Status = false;
      buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0].Status = false;
    }
    SelectionOption Option1 = new SelectionOption(true, false, false, false, false, false);
    List<Entity> selectedEntities1 = new List<Entity>();
    List<Entity> selectedEntities2 = new List<Entity>();
    clsInit.appCommand.SelectionToEntities(ref selectedEntities2, Option1);
    SelectionOption Option2 = new SelectionOption(false, true, false, false, false, false);
    clsInit.appCommand.SelectionToEntities(ref selectedEntities1, Option2);
    clsInit.cVector5.BoxSizeCalculate(selectedEntities1, ref MinPoint, ref MaxPoint);
    if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
      this.doTriangleMeshRough(MWCalcoptions, MinPoint, MaxPoint);
    if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
      this.doTriangleMeshParallelCut(MWCalcoptions, MinPoint, MaxPoint);
    if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
    {
      if (MWCalcoptions.NumberofAxis == 3)
      {
        buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.StartValue = MaxPoint.Z;
        buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.EndValue = MinPoint.Z;
        buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0].Status = false;
        buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
        buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
        buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Distances.Air = 200.0;
        buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.StartValue = 140.0;
        buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.EndValue = 0.0;
        clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar, buMWRoboticVars.varCamMeshConstantZ3Axis.buPar, out clsMW.varbuCamMeshConstantZPars);
        if (clsMW.varbuCamMeshConstantZPars.Distances.Safe < MaxPoint.Z)
          clsMW.varbuCamMeshConstantZPars.Distances.Safe = Math.Round(MaxPoint.Z + clsMW.varbuCamMeshConstantZPars.Distances.Rapid, 3);
        clsMW.varMWCamMeshContantZPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshContantZPars, buMWRoboticVars.varCamMeshConstantZ3Axis.buPar);
      }
      if (MWCalcoptions.NumberofAxis == 4)
      {
        buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar = this.Default4Or5AxisParameter(buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar, 4, Vector3D.AxisZ, 45.0, 45.0, false);
        buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
        buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
        buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Distances.Air = MaxPoint.Z - MinPoint.Z + buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Distances.Rapid;
        buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Steps.StartValue = MaxPoint.Z;
        buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Steps.EndValue = MinPoint.Z;
        clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar, buMWRoboticVars.varCamMeshConstantZ4Axis.buPar, out clsMW.varbuCamMeshConstantZPars);
        if (clsMW.varbuCamMeshConstantZPars.Distances.Safe < MaxPoint.Z)
          clsMW.varbuCamMeshConstantZPars.Distances.Safe = Math.Round(MaxPoint.Z + clsMW.varbuCamMeshConstantZPars.Distances.Rapid, 3);
        clsMW.varMWCamMeshContantZPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshContantZPars, buMWRoboticVars.varCamMeshConstantZ4Axis.buPar);
      }
      if (MWCalcoptions.NumberofAxis == 5)
      {
        buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar = this.Default4Or5AxisParameter(buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar, 4, Vector3D.AxisZ, 45.0, 45.0, false);
        buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
        buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
        buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Strategy.CutTolerance = 0.1;
        buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Distances.Air = 200.0;
        buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Steps.StartValue = 140.0;
        buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Steps.EndValue = 0.0;
        clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar, buMWRoboticVars.varCamMeshConstantZ5Axis.buPar, out clsMW.varbuCamMeshConstantZPars);
        clsMW.varMWCamMeshContantZPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshContantZPars, buMWRoboticVars.varCamMeshConstantZ5Axis.buPar);
        clsMW.Containment2DEntities.Clear();
        Point3D FirstPoint = new Point3D(-100.0, 5.0);
        Point3D SecondPoint = new Point3D(100.0, 100.0);
        List<Point3D> Vertices = new List<Point3D>();
        Entity entRectangle = (Entity) null;
        clsInit.cVector5.Rectangle2Point(FirstPoint, SecondPoint, Plane.XY, ref Vertices, ref entRectangle);
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) Vertices);
        clsMW.Containment2DEntities.Add((Entity) linearPath);
      }
    }
    if (clsMW.Containment2DEntities.Count > 0)
    {
      if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
        clsMW.varMWCamMeshRoughPars.MachParam.Containment2dParams.IsUsedFlg = true;
      if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
        clsMW.varMWCamMeshParalelPars.MachParam.Containment2dParams.IsUsedFlg = true;
      if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
        clsMW.varMWCamMeshContantZPars.MachParam.Containment2dParams.IsUsedFlg = true;
    }
    camResult Result = (camResult) null;
    int num2 = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
    Cam.EntitiesG1Orj.Clear();
    Cam.Tool = new ToolBase5(ccVars.toolActive);
    if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
    {
      if (MWCalcoptions.NumberofAxis == 3)
      {
        for (int index1 = 0; index1 <= Cam.CamPoints.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= Cam.CamPoints[index1].Points.Count - 1; ++index2)
          {
            TpPnt9D point = Cam.CamPoints[index1].Points[index2];
            point.P9.A = 0.0;
            point.P9.B = 0.0;
            point.P9.C = 1.0;
            point.P9.Z += buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
          }
        }
        if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, 0.0))
        {
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG1);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG0);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesPlunge);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeave);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesOther);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadIn);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadOut);
        }
      }
      if (MWCalcoptions.NumberofAxis == 4)
      {
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesG1);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesG0);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesLeave);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesPlunge);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesOther);
        Cam.SimilationPoint.SimMove.Clear();
        for (int index3 = 0; index3 <= Cam.CamPoints.Count - 1; ++index3)
        {
          for (int index4 = 0; index4 <= Cam.CamPoints[index3].Points.Count - 1; ++index4)
          {
            TpPnt9D point = Cam.CamPoints[index3].Points[index4];
            clsInit.cVector5.Rotate(new Point3D(), -num1, Plane.YZ, ref point);
            point.P9.C = 0.0;
            if (num1 < 0.0)
              point.P9.B = -1.0;
            else
              point.P9.B = 1.0;
          }
          clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[index3]);
        }
      }
    }
    if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
    {
      Cam.Tool.CamData.DepthOffset = buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
      if (MWCalcoptions.NumberofAxis == 4 & MWCalcoptions.CamRotateType == CamRotationType.Circular)
      {
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesG1);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesG0);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesLeave);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesPlunge);
        clsInit.cVector5.Rotate(new Point3D(), -num1, Vector3D.AxisX, ref Cam.EntitiesOther);
        Cam.SimilationPoint.SimMove.Clear();
        for (int index5 = 0; index5 <= Cam.CamPoints.Count - 1; ++index5)
        {
          for (int index6 = 0; index6 <= Cam.CamPoints[index5].Points.Count - 1; ++index6)
          {
            TpPnt9D point = Cam.CamPoints[index5].Points[index6];
            clsInit.cVector5.Rotate(new Point3D(), -num1, Plane.YZ, ref point);
            Point3D Points = new Point3D(point.P9.A, point.P9.B, point.P9.C);
            clsInit.cVector5.Rotate(new Point3D(), -num1, Plane.YZ, ref Points);
            point.P9.A = Points.X;
            point.P9.B = Points.Y;
            point.P9.C = Points.Z;
          }
          clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[index5]);
        }
      }
      if (MWCalcoptions.NumberofAxis == 4 & MWCalcoptions.CamRotateType == CamRotationType.Flat)
      {
        Cam.SimilationPoint.SimMove.Clear();
        for (int index7 = 0; index7 <= Cam.CamPoints.Count - 1; ++index7)
        {
          for (int index8 = 0; index8 <= Cam.CamPoints[index7].Points.Count - 1; ++index8)
            Cam.CamPoints[index7].Points[index8].P9.B = 0.0;
          clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[index7]);
        }
      }
      if (MWCalcoptions.NumberofAxis == 3)
      {
        for (int index9 = 0; index9 <= Cam.CamPoints.Count - 1; ++index9)
        {
          for (int index10 = 0; index10 <= Cam.CamPoints[index9].Points.Count - 1; ++index10)
          {
            TpPnt9D point = Cam.CamPoints[index9].Points[index10];
            point.P9.A = 0.0;
            point.P9.B = 0.0;
            point.P9.C = 1.0;
            point.P9.Z += buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
          }
        }
        if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, 0.0))
        {
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG1);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG0);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesPlunge);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeave);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesOther);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadIn);
          clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadOut);
        }
      }
    }
    if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ && MWCalcoptions.NumberofAxis == 3)
    {
      for (int index11 = 0; index11 <= Cam.CamPoints.Count - 1; ++index11)
      {
        for (int index12 = 0; index12 <= Cam.CamPoints[index11].Points.Count - 1; ++index12)
        {
          TpPnt9D point = Cam.CamPoints[index11].Points[index12];
          point.P9.A = 0.0;
          point.P9.B = 0.0;
          point.P9.C = 1.0;
          point.P9.Z += buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
        }
      }
      if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, 0.0))
      {
        clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG1);
        clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG0);
        clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesPlunge);
        clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeave);
        clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesOther);
        clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadIn);
        clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadOut);
      }
    }
    if (num2 < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      if (MWCalcoptions.NumberofAxis == 3)
      {
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
        {
          buMWRoboticVars.varCamMeshRough3Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWRoboticVars.varCamMeshRough3Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshRough3Axis.buPar.Speeds.Plunge;
        }
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
        {
          buMWRoboticVars.varCamMeshParallel3Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRoboticVars.varCamMeshParallel3Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshParallel3Axis.buPar.Speeds.Plunge;
        }
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
        {
          buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRoboticVars.varCamMeshConstantZ3Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Speeds.Plunge;
        }
      }
      if (MWCalcoptions.NumberofAxis == 4)
      {
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
        {
          buMWRoboticVars.varCamMeshRough4Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWRoboticVars.varCamMeshRough4Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshRough4Axis.buPar.Speeds.Plunge;
        }
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
        {
          buMWRoboticVars.varCamMeshParallel4Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRoboticVars.varCamMeshParallel4Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshParallel4Axis.buPar.Speeds.Plunge;
        }
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
        {
          buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRoboticVars.varCamMeshConstantZ4Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Speeds.Plunge;
        }
      }
      if (MWCalcoptions.NumberofAxis == 5)
      {
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
        {
          buMWRoboticVars.varCamMeshParallel5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRoboticVars.varCamMeshParallel5Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshParallel5Axis.buPar.Speeds.Plunge;
        }
        if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
        {
          buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRoboticVars.varCamMeshConstantZ5Axis.buPar);
          PlungeFeed = buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Speeds.Plunge;
        }
      }
      this.ToolPathToRobotPathCode(Cam, MWCalcoptions, PlungeFeed);
      this.SaveRoboticFile();
    }
  }

  public void doSurface(MWCalculationOptions MWCalcoptions)
  {
    camTp Cam = new camTp();
    double PlungeFeed = 10.0;
    MWCalcoptions.AddToCamListInMWCalculation = false;
    MWCalcoptions.DontApplyReset = true;
    if (MWCalcoptions.NumberofAxis == 5 && MWCalcoptions.CamSurfType == CamSurfaceType.SurfaceParalel)
    {
      clsMW.varMWCamSurfaceParallelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamSurface5Axis.mwPar, buMWRoboticVars.varCamSurface5Axis.buPar, out clsMW.varbuCamSurfaceParallelPars);
      clsMW.varMWCamSurfaceParallelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamSurfaceParallelPars, buMWRoboticVars.varCamSurface5Axis.buPar);
      clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
      clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
      clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
    }
    buMWCalcs.entityProjection = new List<List<Entity>>();
    List<Entity> entityList = new List<Entity>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
        if (copiedEntity != null)
        {
          copiedEntity.Translate(0.0, 0.0, 30.0);
          entityList.Add(copiedEntity);
        }
      }
    }
    clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutParallel;
    if (entityList.Count > 0)
    {
      buMWCalcs.entityProjection.Add(entityList);
      clsMW.varMWCamSurfaceParallelPars.MachParam.ProjectCurvesParams.MaxProjectionDistance = 30.0;
      clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutProjectCurves;
    }
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doSurface(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
    Cam.EntitiesG1Orj.Clear();
    if (num < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      if (MWCalcoptions.NumberofAxis == 5 && MWCalcoptions.CamSurfType == CamSurfaceType.SurfaceParalel)
      {
        buMWRoboticVars.varCamSurface5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamSurfaceParallelPars, clsMW.varbuCamSurfaceParallelPars, out buMWRoboticVars.varCamSurface5Axis.buPar);
        PlungeFeed = buMWRoboticVars.varCamSurface5Axis.buPar.Speeds.Plunge;
      }
      this.ToolPathToRobotPathCode(Cam, MWCalcoptions, PlungeFeed);
      clsFiles.SaveParameter();
    }
  }

  public void doTrimContour(MWCalculationOptions MWCalcoptions)
  {
    camTp Cam = new camTp();
    double PlungeFeed = 10.0;
    MWCalcoptions.AddToCamListInMWCalculation = false;
    MWCalcoptions.DontApplyReset = true;
    if (MWCalcoptions.NumberofAxis == 5)
    {
      clsMW.varMWCamSurfaceParallelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamSurface5Axis.mwPar, buMWRoboticVars.varCamSurface5Axis.buPar, out clsMW.varbuCamSurfaceParallelPars);
      clsMW.varMWCamSurfaceParallelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamSurfaceParallelPars, buMWRoboticVars.varCamSurface5Axis.buPar);
      clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
      clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
      clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
    }
    buMWCalcs.entityProjection = new List<List<Entity>>();
    List<Entity> entityList = new List<Entity>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
        if (copiedEntity != null)
        {
          copiedEntity.Translate(0.0, 0.0, 30.0);
          entityList.Add(copiedEntity);
        }
      }
    }
    clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutParallel;
    if (entityList.Count > 0)
    {
      buMWCalcs.entityProjection.Add(entityList);
      clsMW.varMWCamSurfaceParallelPars.MachParam.ProjectCurvesParams.MaxProjectionDistance = 30.0;
      clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutProjectCurves;
    }
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doContouring(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
    Cam.EntitiesG1Orj.Clear();
    if (num < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      if (MWCalcoptions.NumberofAxis == 5 && MWCalcoptions.CamSurfType == CamSurfaceType.SurfaceParalel)
      {
        buMWRoboticVars.varCamSurface5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamSurfaceParallelPars, clsMW.varbuCamSurfaceParallelPars, out buMWRoboticVars.varCamSurface5Axis.buPar);
        PlungeFeed = buMWRoboticVars.varCamSurface5Axis.buPar.Speeds.Plunge;
      }
      this.ToolPathToRobotPathCode(Cam, MWCalcoptions, PlungeFeed);
      this.SaveRoboticFile();
    }
  }

  public void doTriangleMesh5Axis(MWCalculationOptions MWCalcoptions)
  {
    camTp Cam = new camTp();
    MWCalcoptions.AddToCamListInMWCalculation = false;
    MWCalcoptions.DontApplyReset = true;
    MWCalcoptions.NumberofAxis = 5;
    camResult Result = (camResult) null;
    int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
    for (int index1 = 0; index1 <= Cam.CamPoints.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= Cam.CamPoints[index1].Points.Count - 1; ++index2)
      {
        Pnt9D p9 = Cam.CamPoints[index1].Points[index2].P9;
        Line line = new Line(new Point3D(p9.X, p9.Y, p9.Z), new Point3D(p9.X + p9.A * 10.0, p9.Y + p9.B * 10.0, p9.Z + p9.C * 10.0));
        Cam.EntitiesG1.Add((Entity) line);
      }
    }
    for (int index = 0; index <= Cam.SimilationPoint.SimMove.Count - 1; ++index)
    {
      Pnt6DSimMove pnt6DsimMove = Cam.SimilationPoint.SimMove[index];
      clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.XY);
      clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.XZ);
      clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[index].A, Cam.SimilationPoint.SimMove[index].B, Cam.SimilationPoint.SimMove[index].C), new Point3D(), Plane.YZ);
    }
    if (num >= 1)
      return;
    clsInit.appCommand.Reset();
  }

  public void CalculateBCAngles(double I, double J, double K, ref double B, ref double C)
  {
    if (buCompare5.EQ(I, 0.0) & buCompare5.EQ(J, 0.0) & buCompare5.EQ(K, 0.0))
    {
      B = 0.0;
      C = 0.0;
    }
    else
    {
      B = Math.Acos(K) * (180.0 / Math.PI);
      C = Math.Atan2(J, I) * (180.0 / Math.PI);
      if (C >= 0.0)
        return;
      C += 360.0;
    }
  }

  public void doContourBySelected(MWCalculationOptions MWCalcoptions)
  {
    camTp cam = new camTp();
    List<RoboticSurfacePoint> roboticSurfacePointList = new List<RoboticSurfacePoint>();
    RoboticSurfacePoint roboticSurfacePoint1 = new RoboticSurfacePoint(this.SurfacePoints[0]);
    RoboticSurfacePoint roboticSurfacePoint2 = new RoboticSurfacePoint(this.SurfacePoints[0]);
    roboticSurfacePoint2.pntTangent = new Pnt6D(((ICurve) this.SurfacePoints[0].entSafeIn).StartPoint.X, ((ICurve) this.SurfacePoints[0].entSafeIn).StartPoint.Y, ((ICurve) this.SurfacePoints[0].entSafeIn).StartPoint.Z, roboticSurfacePoint2.pntTangent.A, roboticSurfacePoint2.pntTangent.B, roboticSurfacePoint2.pntTangent.C);
    roboticSurfacePointList.Add(roboticSurfacePoint2);
    RoboticSurfacePoint roboticSurfacePoint3 = new RoboticSurfacePoint(this.SurfacePoints[0]);
    roboticSurfacePoint3.pntTangent = new Pnt6D(((ICurve) this.SurfacePoints[0].entLeadIn).StartPoint.X, ((ICurve) this.SurfacePoints[0].entLeadIn).StartPoint.Y, ((ICurve) this.SurfacePoints[0].entLeadIn).StartPoint.Z, roboticSurfacePoint3.pntTangent.A, roboticSurfacePoint3.pntTangent.B, roboticSurfacePoint3.pntTangent.C);
    roboticSurfacePointList.Add(roboticSurfacePoint3);
    for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
    {
      RoboticSurfacePoint roboticSurfacePoint4 = new RoboticSurfacePoint(this.SurfacePoints[index]);
      roboticSurfacePointList.Add(roboticSurfacePoint4);
    }
    RoboticSurfacePoint roboticSurfacePoint5 = new RoboticSurfacePoint(this.SurfacePoints[this.SurfacePoints.Count - 1]);
    roboticSurfacePoint5.pntTangent = new Pnt6D(((ICurve) this.SurfacePoints[this.SurfacePoints.Count - 1].entLeadOut).EndPoint.X, ((ICurve) this.SurfacePoints[this.SurfacePoints.Count - 1].entLeadOut).EndPoint.Y, ((ICurve) this.SurfacePoints[this.SurfacePoints.Count - 1].entLeadOut).EndPoint.Z, roboticSurfacePoint5.pntTangent.A, roboticSurfacePoint5.pntTangent.B, roboticSurfacePoint5.pntTangent.C);
    roboticSurfacePointList.Add(roboticSurfacePoint5);
    RoboticSurfacePoint roboticSurfacePoint6 = new RoboticSurfacePoint(this.SurfacePoints[this.SurfacePoints.Count - 1]);
    roboticSurfacePoint6.pntTangent = new Pnt6D(((ICurve) this.SurfacePoints[this.SurfacePoints.Count - 1].entSafeOut).EndPoint.X, ((ICurve) this.SurfacePoints[this.SurfacePoints.Count - 1].entSafeOut).EndPoint.Y, ((ICurve) this.SurfacePoints[this.SurfacePoints.Count - 1].entSafeOut).EndPoint.Z, roboticSurfacePoint6.pntTangent.A, roboticSurfacePoint6.pntTangent.B, roboticSurfacePoint6.pntTangent.C);
    roboticSurfacePointList.Add(roboticSurfacePoint6);
    for (int index = 0; index <= roboticSurfacePointList.Count - 1; ++index)
    {
      Pnt6D pntTangent = roboticSurfacePointList[index].pntTangent;
      if (pntTangent != (Pnt6D) null)
      {
        double a = roboticSurfacePointList[index].pntTangent.A;
        double num1 = 0.0;
        double num2 = 0.0;
        double num3 = a <= 90.0 ? 180.0 - (90.0 - a) : a - 270.0;
        num1 = roboticSurfacePointList[index].pntTangent.B <= 90.0 ? roboticSurfacePointList[index].pntTangent.B - 90.0 : roboticSurfacePointList[index].pntTangent.B - 90.0;
        double num4 = 0.0;
        string str = $"{$"{roboticSurfacePointList[index].pntTangent.X.ToString("f2")};{roboticSurfacePointList[index].pntTangent.Y.ToString("f2")};{roboticSurfacePointList[index].pntTangent.Z.ToString("f2")};"}{num3.ToString("f2")};{num4.ToString("f2")};{num2.ToString("f2")};" + "100;0;0;0;1;100;";
        cam.PreCodes.Add((object) str);
        Pnt6DSimMove pnt6DsimMove = new Pnt6DSimMove(roboticSurfacePointList[index].pntTangent.X, roboticSurfacePointList[index].pntTangent.Y, roboticSurfacePointList[index].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
        cam.SimilationPoint.SimMove.Add(pnt6DsimMove);
      }
    }
    cam.PreCodes.Insert(0, (object) ((cam.PreCodes.Count + 1).ToString() + ";"));
    string str1 = $"{roboticSurfacePointList[roboticSurfacePointList.Count - 1].pntTangent.X.ToString("f2")};{roboticSurfacePointList[roboticSurfacePointList.Count - 1].pntTangent.Y.ToString("f2")};{(roboticSurfacePointList[roboticSurfacePointList.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2")};" + "0.00;0.00;0.00;100;0;0;0;1;100;";
    cam.PreCodes.Add((object) str1);
    cam.Tool = new ToolBase5(ccVars.toolActive);
    for (int index = 0; index <= roboticSurfacePointList.Count - 1; ++index)
    {
      if (roboticSurfacePointList[index].entTangent != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entTangent, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
    }
    for (int index = 0; index <= roboticSurfacePointList.Count - 1; ++index)
    {
      if (roboticSurfacePointList[index].entSafeIn != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entSafeIn, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
      if (roboticSurfacePointList[index].entLeadIn != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entLeadIn, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
      if (roboticSurfacePointList[index].entSafeOut != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entSafeOut, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
      if (roboticSurfacePointList[index].entLeadOut != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(roboticSurfacePointList[index].entLeadOut, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
    }
    cam.CamPoints.Clear();
    clsInit.appCommand.CamAdd(cam);
    clsInit.appCommand.Reset();
  }

  public void doSurfaceBySelected(MWCalculationOptions MWCalcoptions)
  {
    camTp cam = new camTp();
    for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
    {
      double a = this.SurfacePoints[index].pntNormal.A;
      double num1 = 0.0;
      double num2 = a <= 90.0 ? 180.0 - (90.0 - a) : a - 270.0;
      double num3 = this.SurfacePoints[index].pntNormal.B <= 90.0 ? this.SurfacePoints[index].pntNormal.B - 90.0 : this.SurfacePoints[index].pntNormal.B - 90.0;
      string str = $"{$"{this.SurfacePoints[index].pntNormal.X.ToString("f2")};{this.SurfacePoints[index].pntNormal.Y.ToString("f2")};{this.SurfacePoints[index].pntNormal.Z.ToString("f2")};"}{num2.ToString("f2")};{num3.ToString("f2")};{num1.ToString("f2")};" + "100;0;0;0;1;100;";
      cam.PreCodes.Add((object) str);
    }
    cam.PreCodes.Insert(0, (object) ((cam.PreCodes.Count + 1).ToString() + ";"));
    string str1 = $"{this.SurfacePoints[this.SurfacePoints.Count - 1].pntNormal.X.ToString("f2")};{this.SurfacePoints[this.SurfacePoints.Count - 1].pntNormal.Y.ToString("f2")};{(this.SurfacePoints[this.SurfacePoints.Count - 1].pntNormal.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2")};" + "0.00;0.00;0.00;100;0;0;0;1;100;";
    cam.PreCodes.Add((object) str1);
    cam.CamPoints.Clear();
    for (int index = 0; index <= this.SurfacePoints.Count - 1; ++index)
    {
      if (this.SurfacePoints[index].entNormal != null)
      {
        Entity copiedEnt = (Entity) null;
        buVector5.CopyEntities(this.SurfacePoints[index].entNormal, ref copiedEnt);
        cam.EntitiesOther.Add(copiedEnt);
      }
    }
    clsInit.appCommand.CamAdd(cam);
    clsInit.appCommand.Reset();
  }

  public bool doAddSurfacePoint(
    Point3D pntPre,
    Point3D refPoint,
    Point3D pntNext,
    bool isLast,
    MeshToSurfacePointsSettings Settings)
  {
    if (this.SurfacePoints == null)
      this.SurfacePoints = new List<RoboticSurfacePoint>();
    MeshToSurfacePointsCalculations Calc = new MeshToSurfacePointsCalculations();
    RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
    bool meshSurfaceByPoint = clsInit.cVector5.GetHitPointsFromMeshSurfaceByPoint(this.SelectedMeshes, pntPre, refPoint, pntNext, Settings, ref Calc);
    roboticSurfacePoint.entNormal = Calc.normalEntities;
    roboticSurfacePoint.entTangent = Calc.tangentEntities;
    roboticSurfacePoint.pntNormal = Calc.normalPoint;
    roboticSurfacePoint.pntTangent = Calc.tangentPoint;
    roboticSurfacePoint.vecNormal = Calc.NormalVector;
    roboticSurfacePoint.entLeadIn = Calc.LeadInEntities;
    roboticSurfacePoint.entLeadOut = Calc.LeadOutEntities;
    roboticSurfacePoint.entSafeIn = Calc.SafeInEntities;
    roboticSurfacePoint.entSafeOut = Calc.SafeOutEntities;
    if (meshSurfaceByPoint)
    {
      if (pntPre != (Point3D) null)
        roboticSurfacePoint.pntPre = buVector5.ToPoint3D(pntPre);
      roboticSurfacePoint.pntBase = buVector5.ToPoint3D(refPoint);
      if (pntNext != (Point3D) null)
        roboticSurfacePoint.pntNext = buVector5.ToPoint3D(pntNext);
      this.SurfacePoints.Add(roboticSurfacePoint);
    }
    return meshSurfaceByPoint;
  }

  public void doReCalculateSurfacePoints(object Data)
  {
    this.SurfacePoints.Clear();
    List<RoboticSurfacePoint> roboticSurfacePointList = (List<RoboticSurfacePoint>) Data;
    for (int index = 0; index <= roboticSurfacePointList.Count - 1; ++index)
      this.SurfacePoints.Add(new RoboticSurfacePoint(roboticSurfacePointList[index]));
    this.DrawSurfacePointsAsDynamicLine(-1);
  }

  public void doSelecredPointChanged(object Data)
  {
    this.DrawSurfacePointsAsDynamicLine(Convert.ToInt32(Data.ToString()));
  }

  public void doGetCurveture()
  {
    List<List<Point3D>> point3DListList = new List<List<Point3D>>();
    List<Entity> selectedEntities = new List<Entity>();
    clsInit.appCommand.SelectionToEntitiesBySequence(ref selectedEntities, new SelectionOption(false)
    {
      Mesh = true,
      Surface = true,
      Brep = true
    });
    clsInit.appCommand.undoBuffer();
    List<Entity> entityList = new List<Entity>();
    this.SelectedMeshes = new List<Entity>();
    this.SurfacePoints.Clear();
    this.SurfacePoints = new List<RoboticSurfacePoint>();
    if (selectedEntities.Count <= 0)
      return;
    for (int index1 = 0; index1 <= selectedEntities.Count - 1; ++index1)
    {
      List<List<Point3D>> ControlPoints = new List<List<Point3D>>();
      clsInit.cVector5.SurfaceToControlPoints(selectedEntities[index1], ref ControlPoints);
      if (selectedEntities[index1] is devDept.Eyeshot.Entities.Surface)
        this.SelectedMeshes.Add((Entity) ((devDept.Eyeshot.Entities.Surface) selectedEntities[index1]).ConvertToMesh());
      List<Point3D> PointsList = new List<Point3D>();
      if (ControlPoints.Count == 2)
      {
        for (int index2 = 0; index2 <= ControlPoints[0].Count - 1; ++index2)
          PointsList.Add(clsInit.cVector5.MiddlePointOfLine(ControlPoints[0][index2], ControlPoints[1][index2]));
      }
      else
      {
        for (int index3 = 0; index3 <= ControlPoints.Count - 1; ++index3)
        {
          if (ControlPoints[index3].Count == 2)
            PointsList.Add(clsInit.cVector5.MiddlePointOfLine(ControlPoints[index3][0], ControlPoints[index3][1]));
        }
      }
      ccVars.UndoDont = true;
      if (PointsList.Count > 1)
      {
        EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData();
        LinearPath Ent = (LinearPath) null;
        clsInit.appCommand.CreatePolyLine(PointsList, entData, customData, ref Ent);
        entityList.Add((Entity) Ent);
      }
    }
  }

  public void doGetCurveture11()
  {
    List<List<Point3D>> point3DListList1 = new List<List<Point3D>>();
    List<Entity> selectedEntities = new List<Entity>();
    clsInit.appCommand.SelectionToEntitiesBySequence(ref selectedEntities, new SelectionOption(false)
    {
      Mesh = true,
      Surface = true,
      Brep = true
    });
    clsInit.appCommand.undoBuffer();
    List<Entity> BaseRefEntities = new List<Entity>();
    this.SelectedMeshes = new List<Entity>();
    this.SurfacePoints.Clear();
    this.SurfacePoints = new List<RoboticSurfacePoint>();
    if (selectedEntities.Count <= 0)
      return;
    for (int index1 = 0; index1 <= selectedEntities.Count - 1; ++index1)
    {
      List<List<Point3D>> ControlPoints = new List<List<Point3D>>();
      clsInit.cVector5.SurfaceToControlPoints(selectedEntities[index1], ref ControlPoints);
      if (selectedEntities[index1] is devDept.Eyeshot.Entities.Surface)
        this.SelectedMeshes.Add((Entity) ((devDept.Eyeshot.Entities.Surface) selectedEntities[index1]).ConvertToMesh());
      List<Point3D> PointsList = new List<Point3D>();
      if (ControlPoints.Count == 2)
      {
        for (int index2 = 0; index2 <= ControlPoints[0].Count - 1; ++index2)
          PointsList.Add(clsInit.cVector5.MiddlePointOfLine(ControlPoints[0][index2], ControlPoints[1][index2]));
      }
      else
      {
        for (int index3 = 0; index3 <= ControlPoints.Count - 1; ++index3)
        {
          if (ControlPoints[index3].Count == 2)
            PointsList.Add(clsInit.cVector5.MiddlePointOfLine(ControlPoints[index3][0], ControlPoints[index3][1]));
        }
      }
      ccVars.UndoDont = true;
      if (PointsList.Count > 1)
      {
        EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData();
        LinearPath Ent = (LinearPath) null;
        clsInit.appCommand.CreatePolyLine(PointsList, entData, customData, ref Ent);
        BaseRefEntities.Add((Entity) Ent);
      }
    }
    List<Entity> SortedEntities = new List<Entity>();
    for (int index4 = 0; index4 <= BaseRefEntities.Count - 1; ++index4)
    {
      bool flag = false;
      SortSettings Settings = new SortSettings();
      SortResult Result = new SortResult();
      SortedEntities = new List<Entity>();
      buVector5.ToPoint3D(BaseRefEntities[index4].Vertices[0]);
      Point3D RefPoint = new Point3D(602.0, 333.0, 218.0);
      clsInit.cVector5.SortEntitiesByRefPoint(RefPoint, ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
      for (int index5 = 0; index5 <= SortedEntities.Count - 1; ++index5)
      {
        if (SortedEntities[index5].GetType() == typeof (buUpperLineEnt))
          flag = true;
      }
      if (flag)
      {
        SortedEntities = new List<Entity>();
        clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[index4].Vertices[BaseRefEntities[0].Vertices.Length - 1], ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
        flag = false;
        for (int index6 = 0; index6 <= SortedEntities.Count - 1; ++index6)
        {
          if (SortedEntities[index6].GetType() == typeof (buUpperLineEnt))
            flag = true;
        }
      }
      if (!flag)
        index4 = BaseRefEntities.Count;
    }
    List<Point3D> Points = new List<Point3D>();
    List<List<Point3D>> point3DListList2 = new List<List<Point3D>>();
    Vector3D vector3D1 = new Vector3D();
    List<Point3D> point3DList = new List<Point3D>();
    double t = 0.5;
    bool flag1 = false;
    for (int index = 0; index <= SortedEntities.Count - 1; ++index)
    {
      bool flag2 = false;
      List<Point3D> collection = new List<Point3D>();
      collection.AddRange((IEnumerable<Point3D>) SortedEntities[index].Vertices);
      Vector3D vector3D2 = (Vector3D) ((ICurve) SortedEntities[index]).EndTangent.Clone();
      Vector3D vector3D3 = (Vector3D) ((ICurve) SortedEntities[index]).StartTangent.Clone();
      if (((CustomData) SortedEntities[index].EntityData).sortDirection == entitySortDirection.Reverse)
      {
        vector3D2 = (Vector3D) ((ICurve) SortedEntities[index]).StartTangent.Clone();
        vector3D3 = (Vector3D) ((ICurve) SortedEntities[index]).EndTangent.Clone();
        collection.Reverse();
        flag2 = true;
      }
      if (index == 0)
      {
        point3DList.AddRange((IEnumerable<Point3D>) collection);
        Point3D point3D1 = new Point3D();
        if (!flag2)
        {
          Point3D Pnt = ((ICurve) SortedEntities[index]).PointAt(t);
          point3DList[0] = buVector5.ToPoint3D(Pnt);
        }
        else
        {
          Point3D Pnt = ((ICurve) SortedEntities[index]).PointAt(((ICurve) SortedEntities[index]).Domain.t1 - t);
          point3DList[0] = buVector5.ToPoint3D(Pnt);
        }
        if (point3DList.Count > 0 & index == SortedEntities.Count - 1)
        {
          Point3D point3D2 = new Point3D();
          Point3D point3D3 = buVector5.ToPoint3D(((ICurve) SortedEntities[index]).PointAt(((ICurve) SortedEntities[index]).Domain.t1 - t));
          point3DList[point3DList.Count - 1] = buVector5.ToPoint3D(point3D3);
          point3DListList2.Add(point3DList);
        }
      }
      else if (buCompare5.EQ(vector3D3, vector3D1, 0.1))
      {
        point3DList.AddRange((IEnumerable<Point3D>) collection);
        if (point3DList.Count > 0 & index == SortedEntities.Count - 1)
        {
          Point3D point3D4 = new Point3D();
          Point3D point3D5 = buVector5.ToPoint3D(((ICurve) SortedEntities[index]).PointAt(((ICurve) SortedEntities[index]).Domain.t1 - t));
          point3DList[point3DList.Count - 1] = buVector5.ToPoint3D(point3D5);
          point3DListList2.Add(point3DList);
        }
      }
      else
      {
        Point3D point3D6 = new Point3D();
        if (!flag1)
        {
          Point3D point3D7 = buVector5.ToPoint3D(((ICurve) SortedEntities[index - 1]).PointAt(((ICurve) SortedEntities[index - 1]).Domain.t1 - t));
          point3DList[point3DList.Count - 1] = buVector5.ToPoint3D(point3D7);
        }
        else
        {
          Point3D point3D8 = buVector5.ToPoint3D(((ICurve) SortedEntities[index - 1]).PointAt(t));
          point3DList[point3DList.Count - 1] = buVector5.ToPoint3D(point3D8);
        }
        point3DListList2.Add(point3DList);
        point3DList = new List<Point3D>();
        point3DList.AddRange((IEnumerable<Point3D>) collection);
        Point3D point3D9 = new Point3D();
        if (!flag2)
        {
          Point3D Pnt = ((ICurve) SortedEntities[index]).PointAt(t);
          point3DList[0] = buVector5.ToPoint3D(Pnt);
        }
        else
        {
          Point3D Pnt = ((ICurve) SortedEntities[index]).PointAt(((ICurve) SortedEntities[index]).Domain.t1 - t);
          point3DList[0] = buVector5.ToPoint3D(Pnt);
        }
        if (point3DList.Count > 0 & index == SortedEntities.Count - 1)
        {
          point3D6 = new Point3D();
          if (!flag2)
          {
            Point3D point3D10 = buVector5.ToPoint3D(((ICurve) SortedEntities[index]).PointAt(((ICurve) SortedEntities[index]).Domain.t1 - t));
            point3DList[point3DList.Count - 1] = buVector5.ToPoint3D(point3D10);
          }
          else
          {
            Point3D point3D11 = buVector5.ToPoint3D(((ICurve) SortedEntities[index]).PointAt(t));
            point3DList[point3DList.Count - 1] = buVector5.ToPoint3D(point3D11);
          }
          point3DListList2.Add(point3DList);
        }
      }
      Points.AddRange((IEnumerable<Point3D>) collection);
      vector3D1 = (Vector3D) vector3D2.Clone();
      flag1 = flag2;
    }
    bool flag3 = clsInit.cVector5.IsClosed(Points);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
    Points.Clear();
    Points = new List<Point3D>();
    for (int index = 0; index <= point3DListList2.Count - 1; ++index)
    {
      List<Point3D> Vertice = new List<Point3D>();
      Vertice = point3DListList2[index];
      clsInit.cVector5.PointFilterByLength(buRoboticCalc.varRoboticSettings.FilterLength, ref Vertice);
      point3DListList2[index] = Vertice;
      Points.AddRange((IEnumerable<Point3D>) buVector5.ToPoint3D(Vertice));
    }
    Points.Add(buVector5.ToPoint3D(Points[0]));
    LinearPath Ent1 = (LinearPath) null;
    EntityDataSet entData1 = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
    CustomData customData1 = new CustomData();
    clsInit.appCommand.CreatePolyLine(Points, entData1, customData1, ref Ent1);
    if (Ent1 != null)
      clsInit.appCommand.AddPolyline(Ent1);
    MeshToSurfacePointsSettings Settings1 = new MeshToSurfacePointsSettings();
    Settings1.ToolOffset = ccVars.toolActive.Geometry.Diameter / 2.0;
    Settings1.ExtraDepth = buRoboticCalc.varRoboticSettings.ExtraDepth;
    double num1 = double.MinValue;
    int num2 = -1;
    for (int index = 0; index <= Points.Count - 1; ++index)
    {
      if (Points[index].Z > num1)
      {
        num1 = Points[index].Z;
        num2 = index;
      }
    }
    if (num2 >= 1 & flag3)
      ;
    Settings1.TangentAngleFromNormal = 90.0;
    Point3D BasePoint = new Point3D();
    int num3 = 0;
    AngleVector angleVector = new AngleVector();
    AngleVector angle = new AngleVector();
    for (int index = 0; index <= Points.Count - 1; ++index)
    {
      buVector5.ToPoint3D(Points[index]);
      Settings1.isFirst = false;
      Settings1.isLast = false;
      Settings1.isFirstEachSegment = false;
      Settings1.isLastEachSegment = false;
      if (num3 > 0)
      {
        angle.X = clsInit.cVector5.PointAngle(Points[index], BasePoint, Plane.YZ);
        angle.Y = clsInit.cVector5.PointAngle(Points[index], BasePoint, Plane.XZ);
        angle.Z = clsInit.cVector5.PointAngle(Points[index], BasePoint, Plane.XY);
        if (num3 > 1)
        {
          double num4 = Math.Abs(angle.X - angleVector.X);
          double num5 = Math.Abs(angle.Y - angleVector.Y);
          double num6 = Math.Abs(angle.Z - angleVector.Z);
          if ((num4 > 30.0 & num4 < 170.0 | num5 > 30.0 & num5 < 170.0 | num6 > 30.0 & num6 < 170.0) & index > 1)
            ;
        }
      }
      if (index == 0)
        Settings1.isFirst = true;
      if (index == Points.Count - 1)
        Settings1.isLast = true;
      if (!buCompare5.EQ(BasePoint, Points[index], 0.01))
      {
        bool flag4;
        if (index < Points.Count - 1)
        {
          if (index == 0)
          {
            Settings1.isFirstEachSegment = true;
            flag4 = this.doAddSurfacePoint((Point3D) null, Points[index], Points[index + 1], false, Settings1);
          }
          else
            flag4 = this.doAddSurfacePoint(Points[index - 1], Points[index], Points[index + 1], false, Settings1);
        }
        else
        {
          Settings1.isLastEachSegment = true;
          flag4 = this.doAddSurfacePoint(Points[index - 1], Points[index], (Point3D) null, true, Settings1);
        }
        if (!flag4)
          ;
        ++num3;
        angleVector = new AngleVector(angle);
        BasePoint = buVector5.ToPoint3D(Points[index]);
      }
    }
    this.DrawSurfacePointsAsDynamicLine(-1);
  }

  public void Tick_Sim(object sender, EventArgs e)
  {
    if (this.indexEnt >= 0 & this.indexEnt <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
    {
      Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indexEnt];
      Transformation xform1 = (Transformation) null;
      Transformation xform2 = (Transformation) null;
      if (entity1 is Line)
      {
        Line line1 = entity1 as Line;
        Vector3D axisZ = Vector3D.AxisZ;
        axisZ.Normalize();
        Point3D point3D = new Point3D(-200.0, -200.0, 50.0);
        Vector3D vector3D_1 = new Vector3D(line1.EndPoint.X - line1.StartPoint.X, line1.EndPoint.Y - line1.StartPoint.Y, line1.EndPoint.Z - line1.StartPoint.Z);
        vector3D_1.Normalize();
        xform1 = Class5.smethod_102(axisZ, this, vector3D_1);
        Line line2 = (Line) line1.Clone();
        line2.TransformBy(xform1);
        xform2 = (Transformation) new Translation(new Vector3D(point3D.X - line2.StartPoint.X, point3D.Y - line2.StartPoint.Y, point3D.Z - line2.StartPoint.Z));
      }
      Transformation transformation = xform2 * xform1;
      double num1 = this.pntBase.X - entity1.Vertices[0].X;
      double num2 = this.pntBase.Y - entity1.Vertices[0].Y;
      double num3 = this.pntBase.Z - entity1.Vertices[0].Z;
      double x = entity1.Vertices[1].X - entity1.Vertices[0].X;
      double y = entity1.Vertices[1].Y - entity1.Vertices[0].Y;
      double z = entity1.Vertices[1].Z - entity1.Vertices[0].Z;
      double[] double_1_1 = new double[3]
      {
        -200.0,
        -200.0,
        50.0
      };
      double[] double_1_2 = new double[3]{ 0.0, 0.0, 1.0 };
      double[] double_0_1 = new double[3]
      {
        entity1.Vertices[0].X,
        entity1.Vertices[0].Y,
        entity1.Vertices[0].Z
      };
      double[,] double_0_2 = Class5.smethod_50(new double[3]
      {
        x,
        y,
        z
      }, double_1_2);
      double[] double_1_3 = Class5.smethod_127(double_0_2, double_1_1);
      double[] numArray1 = Class5.smethod_154(double_0_1, double_1_3);
      double[,] numArray2 = new double[4, 4];
      for (int index1 = 0; index1 < 3; ++index1)
      {
        for (int index2 = 0; index2 < 3; ++index2)
          numArray2[index1, index2] = double_0_2[index1, index2];
      }
      for (int index = 0; index < 3; ++index)
        numArray2[index, 3] = numArray1[index];
      numArray2[3, 3] = 1.0;
      Vector3D vector3D1 = new Vector3D(0.0, 0.0, 1.0);
      Vector3D vector3D2 = new Vector3D(x, y, z);
      Vector3D axis = Vector3D.Cross(vector3D1, vector3D2);
      if (axis.Length < 1E-12)
        ;
      axis.Normalize();
      Rotation rotation = new Rotation(Math.Acos(Vector3D.Dot(vector3D1, vector3D2)), axis, entity1.Vertices[0]);
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if ((entity2.EntityData == null ? 0 : (entity2.EntityData is CustomData ? 1 : 0)) != 0 && (entity2.EntityData as CustomData).typeDefination == entityTypeDefination.Simulation)
        {
          entity2.TransformBy(xform1);
          entity2.Regen(0.1);
          entity2.TransformBy(xform2);
          entity2.Regen(0.1);
          entity2.Regen(0.1);
        }
      }
      ++this.indexEnt;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.1);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    if (this.indexEnt >= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
      ;
    ++this.indexSim;
    if (this.indexSim >= 20)
      this.timSim.Enabled = false;
    this.timSim.Enabled = false;
  }

  public void doSimulation()
  {
    if (this.timSim == null)
    {
      this.timSim = new Timer();
      this.timSim.Tick += new EventHandler(this.Tick_Sim);
      this.timSim.Interval = 100;
    }
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
      if ((entity.EntityData == null ? 0 : (entity.EntityData is CustomData ? 1 : 0)) != 0)
      {
        CustomData entityData = entity.EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Simulation | entityData.typeDefination == entityTypeDefination.Base)
          entity.Selected = true;
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    CustomData customData = new CustomData();
    this.pntBase = new Point3D(-200.0, -200.0, 50.0);
    Mesh arrow = Mesh.CreateArrow(this.pntBase, Vector3D.AxisMinusZ, 2.0, 15.0, 5.0, 5.0, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
    arrow.Translate(0.0, 0.0, 20.0);
    arrow.Regen(0.1);
    arrow.Color = Color.Red;
    arrow.ColorMethod = colorMethodType.byEntity;
    customData.typeDefination = entityTypeDefination.Base;
    arrow.EntityData = (object) customData;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) arrow);
    if (this.list_0.Count > 0)
    {
      this.pntStart.X = this.list_0[10].Vertices[0].X;
      this.pntStart.Y = this.list_0[10].Vertices[0].Y;
      this.pntStart.Z = this.list_0[10].Vertices[0].Z;
      this.indexEnt = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count;
      for (int index = 10; index <= this.list_0.Count - 1; ++index)
      {
        Entity copiedEntity = (Entity) null;
        buEntity.Copy(this.list_0[index], ref copiedEntity);
        copiedEntity.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.Simulation
        };
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
      if (this.SelectedEntity != null)
        ;
      this.indexSim = 0;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void DoIteration()
  {
    int index1 = 0;
    for (int indexEnt = this.indexEnt; indexEnt <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++indexEnt)
    {
      if (this.indexEnt >= 0 & this.indexEnt <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
      {
        Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEnt];
        if (entity1 is ICurve)
        {
          Transformation xform1 = (Transformation) null;
          Transformation xform2 = (Transformation) null;
          if (entity1 is Line)
          {
            Line line1 = entity1 as Line;
            Vector3D axisZ = Vector3D.AxisZ;
            axisZ.Normalize();
            Point3D point3D = new Point3D(-200.0, -200.0, 50.0);
            Vector3D vector3D_1 = new Vector3D(line1.EndPoint.X - line1.StartPoint.X, line1.EndPoint.Y - line1.StartPoint.Y, line1.EndPoint.Z - line1.StartPoint.Z);
            vector3D_1.Normalize();
            xform1 = Class5.smethod_102(axisZ, this, vector3D_1);
            Line line2 = (Line) line1.Clone();
            line2.TransformBy(xform1);
            xform2 = (Transformation) new Translation(new Vector3D(point3D.X - line2.StartPoint.X, point3D.Y - line2.StartPoint.Y, point3D.Z - line2.StartPoint.Z));
          }
          Transformation transformation = xform2 * xform1;
          double num1 = this.pntBase.X - entity1.Vertices[0].X;
          double num2 = this.pntBase.Y - entity1.Vertices[0].Y;
          double num3 = this.pntBase.Z - entity1.Vertices[0].Z;
          double x = entity1.Vertices[1].X - entity1.Vertices[0].X;
          double y = entity1.Vertices[1].Y - entity1.Vertices[0].Y;
          double z = entity1.Vertices[1].Z - entity1.Vertices[0].Z;
          double[] double_1_1 = new double[3]
          {
            -200.0,
            -200.0,
            50.0
          };
          double[] double_1_2 = new double[3]
          {
            0.0,
            0.0,
            1.0
          };
          double[] double_0_1 = new double[3]
          {
            entity1.Vertices[0].X,
            entity1.Vertices[0].Y,
            entity1.Vertices[0].Z
          };
          double[,] double_0_2 = Class5.smethod_50(new double[3]
          {
            x,
            y,
            z
          }, double_1_2);
          double[] double_1_3 = Class5.smethod_127(double_0_2, double_1_1);
          double[] numArray1 = Class5.smethod_154(double_0_1, double_1_3);
          double[,] numArray2 = new double[4, 4];
          for (int index2 = 0; index2 < 3; ++index2)
          {
            for (int index3 = 0; index3 < 3; ++index3)
              numArray2[index2, index3] = double_0_2[index2, index3];
          }
          for (int index4 = 0; index4 < 3; ++index4)
            numArray2[index4, 3] = numArray1[index4];
          numArray2[3, 3] = 1.0;
          Vector3D vector3D1 = new Vector3D(0.0, 0.0, 1.0);
          Vector3D vector3D2 = new Vector3D(x, y, z);
          Vector3D axis = Vector3D.Cross(vector3D1, vector3D2);
          if (axis.Length < 1E-12)
            ;
          axis.Normalize();
          Rotation rotation = new Rotation(Math.Acos(Vector3D.Dot(vector3D1, vector3D2)), axis, entity1.Vertices[0]);
          Entity entity2 = (Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indexEnt].Clone();
          for (int index5 = 0; index5 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index5)
          {
            Entity entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index5];
            if ((entity3.EntityData == null ? 0 : (entity3.EntityData is CustomData ? 1 : 0)) != 0 && (entity3.EntityData as CustomData).typeDefination == entityTypeDefination.Simulation)
            {
              entity3.TransformBy(xform1);
              entity3.Regen(0.1);
              entity3.TransformBy(xform2);
              entity3.Regen(0.1);
              entity3.Regen(0.1);
            }
          }
          Entity entity4 = (Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indexEnt].Clone();
          if (entity2 is Line & entity4 is Line)
          {
            double num4 = entity4.Vertices[0].X - entity2.Vertices[0].X;
            double num5 = entity4.Vertices[0].Y - entity2.Vertices[0].Y;
            double num6 = entity4.Vertices[0].Z - entity2.Vertices[0].Z;
            double num7 = entity2.Vertices[1].X - entity2.Vertices[0].X;
            double num8 = entity2.Vertices[1].Y - entity2.Vertices[0].Y;
            double num9 = entity2.Vertices[1].Z - entity2.Vertices[0].Z;
            double num10 = entity4.Vertices[1].X - entity4.Vertices[0].X;
            double num11 = entity4.Vertices[1].Y - entity4.Vertices[0].Y;
            double num12 = entity4.Vertices[1].Z - entity4.Vertices[0].Z;
            double num13 = num10 - num7;
            double num14 = num11 - num8;
            double num15 = num12 - num9;
            this.CodeList[index1] = $"{this.CodeList[index1]} ; {num4.ToString("f3")} ; {num5.ToString("f3")} ; {num6.ToString("f3")} ; {num13.ToString("f3")} ; {num14.ToString("f3")} ; {num15.ToString("f3")}";
          }
          ++this.indexEnt;
          ++index1;
        }
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.1);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doSim2()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
      if ((entity.EntityData == null ? 0 : (entity.EntityData is CustomData ? 1 : 0)) != 0)
      {
        CustomData entityData = entity.EntityData as CustomData;
        if (entityData.typeDefination == entityTypeDefination.Simulation | entityData.typeDefination == entityTypeDefination.Base)
          entity.Selected = true;
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    Line line1 = new Line(-100.0, -100.0, 20.0, -102.0, -105.0, 27.0);
    line1.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Simulation
    };
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line1, Color.Blue);
    Vector3D axisZ = Vector3D.AxisZ;
    axisZ.Normalize();
    Point3D targetPoint = new Point3D(-200.0, -200.0, 50.0);
    Line line2 = this.TransformLineCompletely(new Line(line1.StartPoint.Clone() as Point3D, line1.EndPoint.Clone() as Point3D), axisZ, targetPoint);
    line2.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Simulation
    };
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line2, Color.Red);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public Line TransformLineCompletely(
    Line originalLine,
    Vector3D targetDirection,
    Point3D targetPoint)
  {
    Vector3D vector3D_1 = new Vector3D(originalLine.EndPoint.X - originalLine.StartPoint.X, originalLine.EndPoint.Y - originalLine.StartPoint.Y, originalLine.EndPoint.Z - originalLine.StartPoint.Z);
    vector3D_1.Normalize();
    Transformation xform = Class5.smethod_102(targetDirection, this, vector3D_1);
    originalLine.TransformBy(xform);
    return this.MoveLineToPoint(originalLine, targetPoint);
  }

  public Line MoveLineToPoint(Line line, Point3D targetPoint)
  {
    Transformation xform = (Transformation) new Translation(new Vector3D(targetPoint.X - line.StartPoint.X, targetPoint.Y - line.StartPoint.Y, targetPoint.Z - line.StartPoint.Z));
    line.TransformBy(xform);
    return line;
  }
}
