// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Diemaker.clsDiemaker
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buClass.Apps;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Diamaker;
using buMW;
using buMW.CamForms;
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
namespace buCadCamResVer5.Diemaker;

public class clsDiemaker
{
  public static DiemakerProgramSettings varDiemakerSettings = new DiemakerProgramSettings();
  public List<Entity> CamOtherEntities = (List<Entity>) null;

  public void Init() => buMWDiamalerVars.Init();

  public void cmdGrindingShapeV()
  {
    try
    {
      ToolBase5 toolBase5_1 = (ToolBase5) null;
      ToolBase5 toolBase5_2 = (ToolBase5) null;
      for (int index = 0; index <= ccVars.Tools[0].Tools.Count - 1; ++index)
      {
        if (buDiamakerCalc.varGrindingShape.VShapeAngleToolNo == ccVars.Tools[0].Tools[index].Data.No)
          toolBase5_1 = new ToolBase5(ccVars.Tools[0].Tools[index]);
        if (buDiamakerCalc.varGrindingShape.NickToolNo == ccVars.Tools[0].Tools[index].Data.No)
          toolBase5_2 = new ToolBase5(ccVars.Tools[0].Tools[index]);
      }
      F_DiamakerGrindVShape diamakerGrindVshape = new F_DiamakerGrindVShape();
      diamakerGrindVshape.ToolGrinding = new ToolBase5(toolBase5_1);
      diamakerGrindVshape.ToolNick = new ToolBase5(toolBase5_2);
      diamakerGrindVshape.isCircular = false;
      diamakerGrindVshape.Init();
      diamakerGrindVshape.radiolineartype.Checked = true;
      int num1 = (int) diamakerGrindVshape.ShowDialog();
      if (diamakerGrindVshape.PropertiesForm.Result != DialogResult.OK)
        return;
      this.SaveDiemakerFile();
      List<Entity> calcEntities = new List<Entity>();
      camTp Cam = new camTp();
      clsInit.cDiamaker.doGrindingVShape(buDiamakerCalc.varGrindingShape, toolBase5_1, toolBase5_2, diamakerGrindVshape.isCircular, ref calcEntities, ref Cam);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      string name1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[0].Name;
      string name2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[1].Name;
      ccVars.Pages[ccVars.PageIndex].Cams.Clear();
      for (int index = 0; index <= calcEntities.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        calcEntities[index].LayerName = name1;
        clsInit.appCommand.AddEntity(calcEntities[index]);
      }
      clsInit.appCommand.CamAdd(Cam);
      double num2 = 1.0;
      List<Point3D> points1 = new List<Point3D>();
      List<Point3D> points2 = new List<Point3D>();
      if (diamakerGrindVshape.radiolineartype.Checked)
      {
        points1.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[1]));
        points1.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[2]));
        points1.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[3]));
        points1.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[1]));
        points2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[0]));
        points2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[1]));
        points2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[3]));
        points2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[4]));
        points2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[5]));
      }
      if (!buDiamakerCalc.varGrindingShape.NickEnable)
        num2 = 0.0;
      if (diamakerGrindVshape.radio_circulartype.Checked)
      {
        points1.AddRange((IEnumerable<Point3D>) calcEntities[1].Vertices);
        points2.Add(new Point3D(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0));
        points2.Add(new Point3D(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, calcEntities[1].Vertices[0].Y));
        points2.Add(new Point3D(buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, calcEntities[1].Vertices[0].Y));
        points2.Add(new Point3D(buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0));
        points2.Add(new Point3D(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0));
      }
      CompositeCurve rectangle1 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight);
      rectangle1.Translate(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0, num2 / 2.0);
      Mesh mesh1 = new devDept.Eyeshot.Entities.Region((ICurve) rectangle1).ExtrudeAsMesh(2.0, 0.01, Mesh.natureType.RichSmooth);
      mesh1.Color = Color.Gray;
      mesh1.ColorMethod = colorMethodType.byEntity;
      mesh1.LayerName = name2;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh1);
      int alpha = 150;
      for (int index = 0; index <= buDiamakerCalc.varGrindingShape.FeedCount - 1; ++index)
      {
        double num3 = -(double) index * (buDiamakerCalc.varGrindingShape.GrindingLength + num2 / 1.0 + num2 + 2.0);
        if (num2 > 0.0)
        {
          CompositeCurve rectangle2 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.NickDepth);
          rectangle2.Translate(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0, num2 / 2.0 + num3);
          Mesh mesh2 = new devDept.Eyeshot.Entities.Region((ICurve) rectangle2).ExtrudeAsMesh(-num2, 0.01, Mesh.natureType.RichSmooth);
          mesh2.Color = Color.Gray;
          mesh2.ColorMethod = colorMethodType.byEntity;
          mesh2.LayerName = name2;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh2);
          CompositeCurve rectangle3 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight - buDiamakerCalc.varGrindingShape.NickDepth);
          rectangle3.Translate(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, buDiamakerCalc.varGrindingShape.NickDepth, num2 / 2.0 + num3);
          Mesh mesh3 = new devDept.Eyeshot.Entities.Region((ICurve) rectangle3).ExtrudeAsMesh(-num2, 0.01, Mesh.natureType.RichSmooth);
          mesh3.Color = Color.FromArgb(alpha, Color.LightSteelBlue);
          mesh3.ColorMethod = colorMethodType.byEntity;
          mesh3.LayerName = name2;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh3);
        }
        CompositeCurve outer1 = new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
        {
          (ICurve) new LinearPath((ICollection<Point3D>) points1)
        });
        outer1.Translate(0.0, 0.0, -num2 / 2.0 + num3);
        devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((ICurve) outer1);
        Mesh mesh4 = !diamakerGrindVshape.radiolineartype.Checked ? region.ExtrudeAsMesh(-buDiamakerCalc.varGrindingShape.GrindingLength, 0.01, Mesh.natureType.RichSmooth) : region.ExtrudeAsMesh(buDiamakerCalc.varGrindingShape.GrindingLength, 0.01, Mesh.natureType.RichSmooth);
        mesh4.Color = Color.Red;
        mesh4.ColorMethod = colorMethodType.byEntity;
        mesh4.LayerName = name2;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh4);
        CompositeCurve outer2 = new CompositeCurve((IEnumerable<ICurve>) new List<ICurve>()
        {
          (ICurve) new LinearPath((ICollection<Point3D>) points2)
        });
        outer2.Translate(0.0, 0.0, -num2 / 2.0 + num3);
        Mesh mesh5 = new devDept.Eyeshot.Entities.Region((ICurve) outer2).ExtrudeAsMesh(buDiamakerCalc.varGrindingShape.GrindingLength, 0.01, Mesh.natureType.RichSmooth);
        mesh5.Color = Color.Gray;
        mesh5.ColorMethod = colorMethodType.byEntity;
        mesh5.LayerName = name2;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh5);
        if (num2 > 0.0)
        {
          CompositeCurve rectangle4 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.NickDepth);
          rectangle4.Translate(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0, -num2 / 2.0 - buDiamakerCalc.varGrindingShape.GrindingLength + num3);
          Mesh mesh6 = new devDept.Eyeshot.Entities.Region((ICurve) rectangle4).ExtrudeAsMesh(-num2, 0.01, Mesh.natureType.RichSmooth);
          mesh6.Color = Color.Gray;
          mesh6.ColorMethod = colorMethodType.byEntity;
          mesh6.LayerName = name2;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh6);
          CompositeCurve rectangle5 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight - buDiamakerCalc.varGrindingShape.NickDepth);
          rectangle5.Translate(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, buDiamakerCalc.varGrindingShape.NickDepth, -num2 / 2.0 - buDiamakerCalc.varGrindingShape.GrindingLength + num3);
          Mesh mesh7 = new devDept.Eyeshot.Entities.Region((ICurve) rectangle5).ExtrudeAsMesh(-num2, 0.01, Mesh.natureType.RichSmooth);
          mesh7.Color = Color.FromArgb(alpha, Color.LightSteelBlue);
          mesh7.ColorMethod = colorMethodType.byEntity;
          mesh7.LayerName = name2;
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh7);
        }
        CompositeCurve rectangle6 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight);
        rectangle6.Translate(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0, -num2 / 2.0 - num2 - buDiamakerCalc.varGrindingShape.GrindingLength + num3);
        Mesh mesh8 = new devDept.Eyeshot.Entities.Region((ICurve) rectangle6).ExtrudeAsMesh(-2.0, 0.01, Mesh.natureType.RichSmooth);
        mesh8.Color = Color.Gray;
        mesh8.ColorMethod = colorMethodType.byEntity;
        mesh8.LayerName = name2;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh8);
      }
      RegenOptions ro = new RegenOptions();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen(ro);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].Regen(0.01);
      double amount = 0.0;
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].BoxMin != (Point3D) null)
        amount = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].BoxMin.Z;
      if (amount != 0.0)
      {
        CompositeCurve rectangle7 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight);
        rectangle7.Translate(-buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0);
        Mesh mesh9 = new devDept.Eyeshot.Entities.Region((ICurve) rectangle7).ExtrudeAsMesh(amount, 0.01, Mesh.natureType.RichSmooth);
        mesh9.Color = Color.FromArgb(50, Color.Gray);
        mesh9.ColorMethod = colorMethodType.byEntity;
        mesh9.LayerName = name2;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh9);
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdGrindingShapeCircular()
  {
    try
    {
      ToolBase5 toolBase5_1 = (ToolBase5) null;
      ToolBase5 toolBase5_2 = (ToolBase5) null;
      for (int index = 0; index <= ccVars.Tools[0].Tools.Count - 1; ++index)
      {
        if (buDiamakerCalc.varGrindingShape.VShapeAngleToolNo == ccVars.Tools[0].Tools[index].Data.No)
          toolBase5_1 = new ToolBase5(ccVars.Tools[0].Tools[index]);
        if (buDiamakerCalc.varGrindingShape.NickToolNo == ccVars.Tools[0].Tools[index].Data.No)
          toolBase5_2 = new ToolBase5(ccVars.Tools[0].Tools[index]);
      }
      F_DiamakerGrindVShape diamakerGrindVshape = new F_DiamakerGrindVShape();
      diamakerGrindVshape.ToolGrinding = new ToolBase5(toolBase5_1);
      diamakerGrindVshape.ToolNick = new ToolBase5(toolBase5_2);
      diamakerGrindVshape.isCircular = true;
      diamakerGrindVshape.Init();
      diamakerGrindVshape.radio_circulartype.Checked = true;
      int num = (int) diamakerGrindVshape.ShowDialog();
      if (diamakerGrindVshape.PropertiesForm.Result != DialogResult.OK)
        return;
      List<Entity> calcEntities = new List<Entity>();
      camTp Cam = new camTp();
      clsInit.cDiamaker.doGrindingVShape(buDiamakerCalc.varGrindingShape, toolBase5_1, toolBase5_2, diamakerGrindVshape.isCircular, ref calcEntities, ref Cam);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      for (int index = 0; index <= calcEntities.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        clsInit.appCommand.AddEntity(calcEntities[index]);
      }
      clsInit.appCommand.CamAdd(Cam);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
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
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else if (Action == actionTypeBU.camContours)
      {
        camTp Cam = new camTp();
        this.doWireframeContour(new MWCalculationOptions()
        {
          NumberofAxis = 3,
          CamWireframeType = CamWireFrameType.Contour,
          Mode = CamMode.WireFrame,
          DontApplyReset = true,
          isBuWireframeCalculation = true,
          AddToCamListInMWCalculation = false
        }, ref Cam);
      }
      else
      {
        if (Action != actionTypeBU.camPocketing)
          return;
        camTp Cam = new camTp();
        this.doWireframeContour(new MWCalculationOptions()
        {
          NumberofAxis = 3,
          CamWireframeType = CamWireFrameType.Pocket,
          Mode = CamMode.WireFrame,
          isRough = true,
          DontApplyReset = true,
          AddToCamListInMWCalculation = false
        }, ref Cam);
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
              AddToCamListInMWCalculation = false
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
              AddToCamListInMWCalculation = false
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
              AddToCamListInMWCalculation = false
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
      clsMW.CamEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 2;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
      {
        if (Action != actionTypeBU.camDrill)
          return;
        camTp camTp = new camTp();
        this.doDrill(new MWCalculationOptions()
        {
          NumberofAxis = 3,
          CamDrillType = CamDrillType.Line,
          CamDrillMode = CamDrillMode.Point,
          Mode = CamMode.Drill,
          DontApplyReset = true,
          AddToCamListInMWCalculation = false
        });
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamSlot()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.diemakerSlotCam;
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
        this.doSlot();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamScan()
  {
    try
    {
      F_WFScan fWfScan = new F_WFScan();
      fWfScan.mwCamParameter = buMWCalcs.CopyCamParameter(buMWDiamalerVars.varMWDiemakerCamScanPars, buMWDiamalerVars.varbuDiemakerCamScanPars, out fWfScan.buCamParameter);
      fWfScan.Init();
      int num = (int) fWfScan.ShowDialog();
      if (fWfScan.PropertiesForm.Result != DialogResult.OK)
        return;
      buMWDiamalerVars.varMWDiemakerCamScanPars = buMWCalcs.CopyCamParameter(fWfScan.mwCamParameter, fWfScan.buCamParameter, out buMWDiamalerVars.varbuDiemakerCamScanPars);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void SaveDiemakerFile()
  {
    string FileName1 = AppPath.Settings + "\\Diemaker\\Diemaker.prm";
    ArrayList StringList1 = new ArrayList();
    StringList1.Add((object) "<Cf2Props>");
    for (int index = 0; index <= clsVar.Cf2Properties.Count - 1; ++index)
      StringList1.AddRange((ICollection) clsVar.Cf2Properties[index].ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</Cf2Props>");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "   Diemaker Settings");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "<DiemakerSettings>");
    StringList1.AddRange((ICollection) clsDiemaker.varDiemakerSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</DiemakerSettings>");
    StringList1.Add((object) "<varGrindingShape>");
    StringList1.AddRange((ICollection) buDiamakerCalc.varGrindingShape.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList1.Add((object) "</varGrindingShape>");
    buFile.SaveToFile(StringList1, FileName1);
    buLog.addLog("Diemaker Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    buMWDiamalerVars.varMWDiemakerCamWFContourPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour.bin");
    buMWDiamalerVars.varMWDiemakerCamWFContour4XPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour4X.bin");
    buMWDiamalerVars.varMWDiemakerCamWFPocketPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerWfPocket.bin");
    buMWDiamalerVars.varMWDiemakerCamDrillPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerDrill.bin");
    buMWDiamalerVars.varMWDiemakerCamDrillPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerScan.bin");
    buMWDiamalerVars.varMWDiemakerCamMeshRoughPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmRough.bin");
    buMWDiamalerVars.varMWDiemakerCamMeshParalelPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmParallel.bin");
    buMWDiamalerVars.varMWDiemakerCamMeshContantZPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantZ.bin");
    buMWDiamalerVars.varMWDiemakerCamMeshPencilPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmPencil.bin");
    buMWDiamalerVars.varMWDiemakerCamMeshProjectionPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmProjection.bin");
    buMWDiamalerVars.varMWDiemakerCamMeshContantCuspPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantCusp.bin");
    buMWDiamalerVars.varMWDiemakerCamMeshFlatlandPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmFlatlands.bin");
    string FileName2 = AppPath.Settings + "\\Diemaker\\DiemakerCam.bucamset";
    ArrayList StringList2 = new ArrayList();
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "   MW Cam Settings");
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "<MwCamSettings>");
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamWFContourPars.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamWFContour4XPars.ToDefAll("_varbuCamWFContour4XPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamWFPocketPars.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamDrillPars.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamDrillPars.ToDefAll("_varbuCamScanPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamMeshRoughPars.ToDefAll("_varbuCamMeshRoughPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamMeshParallelPars.ToDefAll("_varbuCamMeshParallelPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamMeshConstantZPars.ToDefAll("_varbuCamMeshContantZPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamMeshPencilPars.ToDefAll("_varbuCamMeshPencilPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamMeshProjectionPars.ToDefAll("_varbuCamMeshProjectionPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamMeshFlatlandsPars.ToDefAll("_varbuCamMeshFlatlandsPars", 2, SerilizationMode5.MultiLine));
    StringList2.AddRange((ICollection) buMWDiamalerVars.varbuDiemakerCamMeshConstantCuspPars.ToDefAll("_varbuCamMeshContantCuspPars", 2, SerilizationMode5.MultiLine));
    StringList2.Add((object) "</MwCamSettings>");
    buFile.SaveToFile(StringList2, FileName2);
  }

  public void OpenDiemakerFile()
  {
    try
    {
      ArrayList arrayList1 = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Diemaker\\Diemaker.prm");
      clsVar.Cf2Properties = new List<Cf2FileProperties>();
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList1 = new ArrayList();
          buString.ListToSpecificList("<DiemakerSettings>", "</DiemakerSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsDiemaker.varDiemakerSettings);
            buLog.addLog("DiemakerSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList1 = new ArrayList();
          buString.ListToSpecificList("<varGrindingShape>", "</varGrindingShape>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buDiamakerCalc.varGrindingShape);
            buLog.addLog("varGrindingShape Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          List<List<string>> stringListList = new List<List<string>>();
          ArrayList CalcList2 = new ArrayList();
          List<List<string>> CalcList3 = new List<List<string>>();
          clsVar.Cf2Properties = new List<Cf2FileProperties>();
          buString.ListToSpecificList("<Cf2Props>", "</Cf2Props>", true, StringList, ref CalcList2);
          buString.ListToSpecificList("<Cf2FileProperties>", "</Cf2FileProperties>", true, CalcList2, ref CalcList3);
          if (CalcList3.Count > 0)
          {
            for (int index = 0; index <= CalcList3.Count - 1; ++index)
            {
              Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
              buSerilization.Decode(CalcList3[index], "", SerilizationMode.MultiLine, (object) cf2FileProperties);
              clsVar.Cf2Properties.Add(cf2FileProperties);
            }
          }
          ArrayList arrayList2 = new ArrayList();
          stringListList = new List<List<string>>();
        }
        catch (Exception ex)
        {
          buLog.addLog("Diemaker Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Diemaker Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.DiemakerMode.Enable)
      {
        buLog.addLog("Diemaker Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Diemaker Settings File Missing");
      }
      buLog.addLog("Diemaker Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour.bin");
      if (fileInfo2.Exists)
        buMWDiamalerVars.varMWDiemakerCamWFContourPars.Deserialize(fileInfo2.FullName);
      FileInfo fileInfo3 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerWfPocket.bin");
      if (fileInfo3.Exists)
        buMWDiamalerVars.varMWDiemakerCamWFPocketPars.Deserialize(fileInfo3.FullName);
      FileInfo fileInfo4 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour4X.bin");
      if (fileInfo4.Exists)
        buMWDiamalerVars.varMWDiemakerCamWFContour4XPars.Deserialize(fileInfo4.FullName);
      FileInfo fileInfo5 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerDrill.bin");
      if (fileInfo5.Exists)
        buMWDiamalerVars.varMWDiemakerCamDrillPars.Deserialize(fileInfo5.FullName);
      FileInfo fileInfo6 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerScan.bin");
      if (fileInfo6.Exists)
        buMWDiamalerVars.varMWDiemakerCamScanPars.Deserialize(fileInfo6.FullName);
      FileInfo fileInfo7 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmRough.bin");
      if (fileInfo7.Exists)
        buMWDiamalerVars.varMWDiemakerCamMeshRoughPars.Deserialize(fileInfo7.FullName);
      FileInfo fileInfo8 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmParallel.bin");
      if (fileInfo8.Exists)
        buMWDiamalerVars.varMWDiemakerCamMeshParalelPars.Deserialize(fileInfo8.FullName);
      FileInfo fileInfo9 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantZ.bin");
      if (fileInfo9.Exists)
        buMWDiamalerVars.varMWDiemakerCamMeshContantZPars.Deserialize(fileInfo9.FullName);
      FileInfo fileInfo10 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmPencil.bin");
      if (fileInfo10.Exists)
        buMWDiamalerVars.varMWDiemakerCamMeshPencilPars.Deserialize(fileInfo10.FullName);
      FileInfo fileInfo11 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmProjection.bin");
      if (fileInfo11.Exists)
        buMWDiamalerVars.varMWDiemakerCamMeshProjectionPars.Deserialize(fileInfo11.FullName);
      FileInfo fileInfo12 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantCusp.bin");
      if (fileInfo12.Exists)
        buMWDiamalerVars.varMWDiemakerCamMeshContantCuspPars.Deserialize(fileInfo12.FullName);
      FileInfo fileInfo13 = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmFlatlands.bin");
      if (fileInfo13.Exists)
        buMWDiamalerVars.varMWDiemakerCamMeshFlatlandPars.Deserialize(fileInfo13.FullName);
      string str = AppPath.Settings + "\\Diemaker\\DiemakerCam.bucamset";
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
          buSerilization.Decode(StringList, "_varbuCamWFContourPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamWFContourPars);
          buSerilization.Decode(StringList, "_varbuCamWFPocketPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamWFPocketPars);
          buSerilization.Decode(StringList, "_varbuCamWFContour4XPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamWFContour4XPars);
          buSerilization.Decode(StringList, "_varbuCamDrillPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamDrillPars);
          buSerilization.Decode(StringList, "_varbuCamScanPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamScanPars);
          buSerilization.Decode(StringList, "_varbuCamMeshRoughPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamMeshRoughPars);
          buSerilization.Decode(StringList, "_varbuCamMeshParallelPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamMeshParallelPars);
          buSerilization.Decode(StringList, "_varbuCamMeshContantZPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamMeshConstantZPars);
          buSerilization.Decode(StringList, "_varbuCamMeshPencilPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamMeshPencilPars);
          buSerilization.Decode(StringList, "_varbuCamMeshProjectionPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamMeshProjectionPars);
          buSerilization.Decode(StringList, "_varbuCamMeshFlatlandsPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamMeshFlatlandsPars);
          buSerilization.Decode(StringList, "_varbuCamMeshContantCuspPars", SerilizationMode.MultiLine, (object) buMWDiamalerVars.varbuDiemakerCamMeshConstantCuspPars);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Marble Settings Decoder Error");
        }
      }
      else
      {
        if (!clsVar.appModes_0.DiemakerMode.Enable)
          return;
        buLog.addLog("Diemaker Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Diemaker Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("Diemaker Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Diemaker Settings Decoder Error");
    }
  }

  public void doSlot()
  {
    List<Entity> SortedEntities = new List<Entity>();
    List<Entity> entityList = new List<Entity>();
    SelectionOption Option = new SelectionOption();
    SortSettings Settings = new SortSettings();
    SortResult Result = new SortResult();
    Option.CircleToArc = true;
    Option.SplitArcIfGreatThen180 = true;
    DialogBoxInput dialogBoxInput = new DialogBoxInput();
    dialogBoxInput.Value = clsDiemaker.varDiemakerSettings.SlotDiameter;
    dialogBoxInput.FormCaption = "Data";
    dialogBoxInput.ValueCaption = "Slot Diameter";
    dialogBoxInput.StartPosition = FormStartPosition.CenterScreen;
    dialogBoxInput.Init();
    int num1 = (int) dialogBoxInput.ShowDialog();
    if (dialogBoxInput.Result != DialogResult.OK)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      this.CamOtherEntities = new List<Entity>();
      clsDiemaker.varDiemakerSettings.SlotDiameter = dialogBoxInput.Value;
      clsInit.appCommand.SelectionToEntities(ref entityList, Option);
      clsInit.cVector5.EntitiesPlaneCheck(ref entityList);
      if (ccVars.entityEdges != null && ccVars.entityEdges.Count > 0)
      {
        entityList.Clear();
        buVector5.CopyEntities(ccVars.entityEdges[0], ref entityList);
      }
      Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
      if (ccVars.SelectionOP.ClickList.Count > 0)
      {
        Settings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
        clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref entityList, Settings, ref SortedEntities, ref Result);
      }
      else
        clsInit.cVector5.SortEntitiesByRefPoint(((ICurve) entityList[0]).StartPoint, ref entityList, Settings, ref SortedEntities, ref Result);
      List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      clsInit.appCommand.undoBuffer();
      for (int index = 0; index <= SplitedEntitites.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        this.CamOtherEntities = new List<Entity>();
        MWCalculationOptions MWCalcoptions = new MWCalculationOptions();
        List<Point3D> Points = new List<Point3D>();
        clsMW.CamEntities.Clear();
        clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index], 0.01, ref Points);
        if (clsDiemaker.varDiemakerSettings.SlotDiameter > ccVars.toolActive.Geometry.Diameter)
        {
          Point3D EndPnt = new Point3D();
          double num2 = clsInit.cVector5.PointAngle(Points[1], Points[0], Plane.XY);
          clsInit.cVector5.LineWithLengthAndAngle(Points[0], clsDiemaker.varDiemakerSettings.SlotDiameter / 2.0, num2, ref EndPnt);
          List<Pnt3D> CopiedPnt = new List<Pnt3D>();
          List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
          buConversion5.Point3DToPnt3D(Points, ref CopiedPnt);
          double num3 = clsInit.cVector5.Length3D(Points[0], Points[1]);
          CompositeCurve slot = CompositeCurve.CreateSlot(ccVars.planeActive, EndPnt.X, EndPnt.Y, num3 - clsDiemaker.varDiemakerSettings.SlotDiameter, clsDiemaker.varDiemakerSettings.SlotDiameter / 2.0, Utility.DegToRad(num2));
          slot.Regen(0.1);
          this.CamOtherEntities.Add((Entity) slot);
          clsMW.CamEntities.Add((Entity) slot);
          MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
        }
        else
        {
          Entity entity = (Entity) new LinearPath((ICollection<Point3D>) Points);
          clsMW.CamEntities.Add(entity);
          MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
        }
        MWCalcoptions.NumberofAxis = 3;
        MWCalcoptions.Mode = CamMode.WireFrame;
        MWCalcoptions.isRough = true;
        MWCalcoptions.DontApplyReset = true;
        MWCalcoptions.AddToCamListInMWCalculation = false;
        if (index > 0)
          MWCalcoptions.DontShowDialogBox = true;
        camTp Cam = new camTp();
        this.doWireframeContour(MWCalcoptions, ref Cam);
      }
      clsFiles.SaveParameter();
    }
  }

  public void doWireframeContour(MWCalculationOptions MWCalcoptions, ref camTp Cam)
  {
    if (Cam == null)
      Cam = new camTp();
    camResult Result = (camResult) null;
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDiamalerVars.varMWDiemakerCamWFContourPars, buMWDiamalerVars.varbuDiemakerCamWFContourPars, out clsMW.varbuCamWFContourPars);
    int num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
    buMWDiamalerVars.varMWDiemakerCamWFContourPars = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWDiamalerVars.varbuDiemakerCamWFContourPars);
    if (num < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      if (this.CamOtherEntities != null && this.CamOtherEntities.Count > 0)
      {
        for (int index = 0; index <= this.CamOtherEntities.Count - 1; ++index)
        {
          Entity copiedEnt = (Entity) null;
          buVector5.CopyEntities(this.CamOtherEntities[index], ref copiedEnt);
          Cam.EntitiesOther.Add(copiedEnt);
        }
      }
      Cam.Mode = MWCalcoptions.Mode;
      Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
      Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
      Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
      if (MWCalcoptions.Mode == CamMode.WireFrame)
      {
        if (MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
        {
          if (MWCalcoptions.NumberofAxis == 4)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M55");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            clsInit.appCommand.CamAdd(Cam);
          }
          else if (MWCalcoptions.NumberofAxis == 3 & !MWCalcoptions.isSpinConstantCalculation)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            clsInit.appCommand.CamAdd(Cam);
          }
          else if (MWCalcoptions.NumberofAxis == 3 & MWCalcoptions.isSpinConstantCalculation)
          {
            Cam.PreCodes.Add((object) "G90");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G53");
            Cam.PreCodes.Add((object) "G0 Z0");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M55");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "M154");
            Cam.PreCodes.Add((object) "G75");
            Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
            Cam.PreCodes.Add((object) "G75");
            for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
            {
              if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
                Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
            }
            Cam.AfterCodes.Add((object) "M30");
            Cam.AfterCodes.Add((object) "M2");
            for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
            {
              if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
                Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
            }
            Cam.CamPoints[0].PreCodes.Add((object) ("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed.ToString()));
            clsInit.appCommand.CamAdd(Cam);
          }
        }
        if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
        {
          Cam.PreCodes.Add((object) "G90");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G53");
          Cam.PreCodes.Add((object) "G0 Z0");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "M154");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
          {
            if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
              Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
          }
          Cam.AfterCodes.Add((object) "M30");
          Cam.AfterCodes.Add((object) "M2");
          for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
          {
            if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
              Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
          }
          clsInit.appCommand.CamAdd(Cam);
        }
      }
      clsInit.appCommand.Reset();
    }
  }

  public void doTriangleMesh(MWCalculationOptions MWCalcoptions)
  {
    camTp Cam = new camTp();
    camResult Result = (camResult) null;
    if (clsInit.appMW.doTriangularMesh3D(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result) < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      Cam.Mode = MWCalcoptions.Mode;
      Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
      Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
      Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
      if (MWCalcoptions.Mode == CamMode.TriangularMesh)
      {
        Cam.PreCodes.Add((object) "<GCodes>");
        Cam.PreCodes.Add((object) ("Mode = " + 2.ToString()));
        Cam.PreCodes.Add((object) "G90");
        Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
        Cam.PreCodes.Add((object) "G75");
        Cam.PreCodes.Add((object) "G53");
        Cam.PreCodes.Add((object) "G0 Z0");
        Cam.PreCodes.Add((object) "G75");
        Cam.PreCodes.Add((object) "M154");
        Cam.PreCodes.Add((object) "G75");
        Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
        Cam.PreCodes.Add((object) "G75");
        for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
        {
          if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
            Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
        }
        Cam.AfterCodes.Add((object) "M30");
        Cam.AfterCodes.Add((object) "M2");
        Cam.AfterCodes.Add((object) "</GCodes>");
        for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
        {
          if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
            Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
        }
        clsInit.appCommand.CamAdd(Cam);
      }
      clsInit.appCommand.Reset();
    }
  }

  public void doDrill(MWCalculationOptions MWCalcoptions)
  {
    camTp Cam = new camTp();
    camResult Result = (camResult) null;
    if (clsInit.appMW.doDrill(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result) < 1)
    {
      clsInit.appCommand.Reset();
    }
    else
    {
      Cam.Mode = MWCalcoptions.Mode;
      Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
      Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
      Cam.CamDrillType = MWCalcoptions.CamDrillType;
      Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
      if (MWCalcoptions.Mode == CamMode.Drill)
      {
        int num;
        if (MWCalcoptions.NumberofAxis == 4)
        {
          Cam.PreCodes.Add((object) "<GCodes>");
          ArrayList preCodes = Cam.PreCodes;
          num = 1;
          string str = "Mode = " + num.ToString();
          preCodes.Add((object) str);
          Cam.PreCodes.Add((object) "G90");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G53");
          Cam.PreCodes.Add((object) "G0 Z0");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "M55");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "M154");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
          {
            if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
              Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
          }
          Cam.AfterCodes.Add((object) "M30");
          Cam.AfterCodes.Add((object) "M2");
          Cam.AfterCodes.Add((object) "</GCodes>");
          for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
          {
            if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
              Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
          }
          clsInit.appCommand.CamAdd(Cam);
        }
        if (MWCalcoptions.NumberofAxis == 3)
        {
          Cam.PreCodes.Add((object) "<GCodes>");
          ArrayList preCodes = Cam.PreCodes;
          num = 2;
          string str = "Mode = " + num.ToString();
          preCodes.Add((object) str);
          Cam.PreCodes.Add((object) "G90");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G53");
          Cam.PreCodes.Add((object) "G0 Z0");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "M154");
          Cam.PreCodes.Add((object) "G75");
          Cam.PreCodes.Add((object) "G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
          Cam.PreCodes.Add((object) "G75");
          for (int index = 0; index <= Cam.Tool.ToolNext.Count - 1; ++index)
          {
            if (Cam.Tool.ToolNext[index].ToString().Trim().Length > 0)
              Cam.AfterCodes.Add((object) Cam.Tool.ToolNext[index].ToString().Trim());
          }
          Cam.AfterCodes.Add((object) "M30");
          Cam.AfterCodes.Add((object) "M2");
          Cam.AfterCodes.Add((object) "</GCodes>");
          for (int index = 0; index <= Cam.Tool.ToolPre.Count - 1; ++index)
          {
            if (Cam.Tool.ToolPre[index].ToString().Trim().Length > 0)
              Cam.CamPoints[0].PreCodes.Add((object) Cam.Tool.ToolPre[index].ToString().Trim());
          }
          clsInit.appCommand.CamAdd(Cam);
        }
      }
      clsInit.appCommand.Reset();
    }
  }
}
