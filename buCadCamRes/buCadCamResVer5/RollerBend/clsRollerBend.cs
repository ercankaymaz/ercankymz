// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.RollerBend.clsRollerBend
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.RollerBend;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
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
namespace buCadCamResVer5.RollerBend;

public class clsRollerBend
{
  private string string_0 = nameof (clsRollerBend);
  public static Design viewportAuto = (Design) null;
  public Plane planeActive = Plane.XY;
  public int indexSim = -1;
  public static List<int> SimMovePartIndex = new List<int>();
  public static List<Entity> SimToCollsionCheck1 = new List<Entity>();
  public static List<Entity> SimToCollsionCheck2 = new List<Entity>();
  public Timer timSim = (Timer) null;
  public F_RollerMachSim frmMachSim = (F_RollerMachSim) null;
  public RollerJob activeJob = (RollerJob) null;
  public RollerBendMove activeMove = new RollerBendMove();

  public void Init()
  {
    clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
  }

  public void InitSimulation()
  {
    if (this.frmMachSim == null)
      this.frmMachSim = new F_RollerMachSim();
    this.timSim = new Timer();
    this.timSim.Tick += new EventHandler(this.tick_Simulation);
    if (clsRollerBend.viewportAuto != null)
      return;
    clsInit.cVector5.CreateModelControl(ref clsRollerBend.viewportAuto, clsVar.UnlockKey, new CreateModelProperties()
    {
      CoordinateSystemIconVisible = false,
      OriginSymbolVisible = true,
      ViewCubeIconVisible = true,
      OrigineCaptionVisible = false,
      ToolBorVisible = false,
      BottomColor = Color.LightGray,
      MiddleColor = Color.WhiteSmoke,
      TopColor = Color.LightGray,
      PanMouseButtons = {
        Button = mouseButtonsZPR.Middle,
        ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
      },
      RotateMouseButtons = {
        Button = mouseButtonsZPR.Middle,
        ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
      },
      ZoomMouseButtons = {
        Button = mouseButtonsZPR.Middle,
        ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
      }
    });
    clsRollerBend.viewportAuto.Name = "ModelAuto";
    this.frmMachSim.pnl_viewport.Controls.Add((System.Windows.Forms.Control) clsRollerBend.viewportAuto);
    clsRollerBend.viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    clsRollerBend.viewportAuto.ProgressBar.Visible = false;
    clsRollerBend.viewportAuto.WaitCursorMode = waitCursorType.Never;
    clsRollerBend.viewportAuto.MouseMove += new MouseEventHandler(this.method_0);
    for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
      {
        Entity refEnt = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[index1].Entities[index2]);
        refEnt.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.MachineParts,
          EntityName = ccVars.SimMachine.MachineParts[index1].PartName
        };
        refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) clsRollerBend.viewportAuto));
        string name = ((CustomData) refEnt.EntityData).EntityName;
        if (name.Length == 0)
          name = "Block" + index1.ToString();
        Block block = new Block(name);
        Entity entity = buVector5.CopyEntities(refEnt);
        entity.Color = Color.Linen;
        int alpha = (int) byte.MaxValue;
        if (ccVars.SimMachine.MachineParts[index1].Transparency >= 0 & ccVars.SimMachine.MachineParts[index1].Transparency <= (int) byte.MaxValue)
          alpha = ccVars.SimMachine.MachineParts[index1].Transparency;
        if (index1 <= ccVars.SimMachine.MachineParts.Count - 1)
          entity.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[index1].Color);
        entity.ColorMethod = colorMethodType.byEntity;
        block.Entities.Add(entity);
        clsRollerBend.viewportAuto.Blocks.Add(block);
      }
    }
  }

  public void cmdSetView(viewType Type)
  {
    switch (Type)
    {
      case viewType.Front:
        buEyeShotFunctions.Viewfront(ref clsRollerBend.viewportAuto, false);
        this.planeActive = Plane.XZ;
        break;
      case viewType.Right:
        buEyeShotFunctions.ViewRight(ref clsRollerBend.viewportAuto, false);
        this.planeActive = Plane.YZ;
        break;
      case viewType.Rear:
        buEyeShotFunctions.ViewBack(ref clsRollerBend.viewportAuto, false);
        this.planeActive = Plane.XZ;
        break;
      case viewType.Left:
        buEyeShotFunctions.ViewLeft(ref clsRollerBend.viewportAuto, false);
        this.planeActive = Plane.YZ;
        break;
      case viewType.Top:
        buEyeShotFunctions.ViewTop(ref clsRollerBend.viewportAuto, false);
        this.planeActive = Plane.XY;
        break;
      case viewType.Bottom:
        buEyeShotFunctions.ShowViewportViewBox(ref clsRollerBend.viewportAuto, false);
        this.planeActive = Plane.XY;
        break;
      default:
        buEyeShotFunctions.ViewIso(ref clsRollerBend.viewportAuto, false);
        this.planeActive = Plane.XY;
        break;
    }
  }

  public void cmdZoomFit() => buEyeShotFunctions.ZoomFit(ref clsRollerBend.viewportAuto);

  public void cmdSimilation()
  {
    this.frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    this.frmMachSim.Init();
    this.frmMachSim.StartPosition = FormStartPosition.CenterParent;
    this.DrawEntities(true);
    int num = (int) this.frmMachSim.ShowDialog();
    if (this.frmMachSim.PropertiesForm.Result == DialogResult.OK)
      ;
  }

  public void cmdStartSimulation(bool Step)
  {
    this.timSim.Interval = buRollerBendCalc.varRollerBendSetting.SimulationIntervalMs;
    buRollerBendCalc.varRollerBendRuntime.StepRun = Step;
    if (!clsRollerBend.viewportAuto.IsAnimationRunning)
      clsRollerBend.viewportAuto.StartAnimation(new int?(buRollerBendCalc.varRollerBendSetting.SimulationIntervalMs));
    if (this.indexSim == -1)
      this.indexSim = 0;
    this.timSim.Enabled = true;
    if (!Step)
    {
      buRollerBendCalc.varRollerBendRuntime.StepRun = false;
      clsRollerBend.viewportAuto.Entities.ClearSelection();
      clsRollerBend.viewportAuto.Invalidate();
    }
    else if (buRollerBendCalc.varRollerBendRuntime.StepRun & Step)
      ;
  }

  public void cmdStopSimulation()
  {
    if (this.timSim.Enabled)
    {
      this.timSim.Enabled = false;
    }
    else
    {
      this.indexSim = 0;
      this.timSim.Enabled = false;
    }
  }

  public void cmdNextSimulation()
  {
    if (this.indexSim <= 0)
      return;
    this.tick_Simulation((object) null, (EventArgs) null);
  }

  public void cmdPreSimulation()
  {
    if (this.indexSim <= 0)
      return;
    this.indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
    this.indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
    this.tick_Simulation((object) null, (EventArgs) null);
  }

  public void cmdCircle()
  {
    F_RollerCircle fRollerCircle = new F_RollerCircle();
    fRollerCircle.Diameter = buRollerBendCalc.varRollerBendRuntime.CircleDiameter;
    fRollerCircle.Length = buRollerBendCalc.varRollerBendRuntime.CircleLength;
    fRollerCircle.Thickness = buRollerBendCalc.varRollerBendRuntime.CircleThickness;
    fRollerCircle.Init();
    int num = (int) fRollerCircle.ShowDialog();
    if (fRollerCircle.Properties.Result != DialogResult.OK)
      return;
    buRollerBendCalc.varRollerBendRuntime.CircleDiameter = fRollerCircle.Diameter;
    buRollerBendCalc.varRollerBendRuntime.CircleLength = fRollerCircle.Length;
    buRollerBendCalc.varRollerBendRuntime.CircleThickness = fRollerCircle.Thickness;
    this.doCircle(buRollerBendCalc.varRollerBendRuntime.CircleDiameter, buRollerBendCalc.varRollerBendRuntime.CircleThickness, buRollerBendCalc.varRollerBendRuntime.CircleLength);
  }

  public void tick_Simulation(object sender, EventArgs e)
  {
    if (this.indexSim >= 0 & this.indexSim <= this.activeJob.SimulationMoves.Count - 1)
    {
      if (this.indexSim >= 0 & this.indexSim <= this.activeJob.SimulationMoves.Count - 1)
      {
        if (!AppBool.Connected)
          this.activeMove = this.activeJob.SimulationMoves[this.indexSim];
        if (this.activeMove.Command == RollerBendMoveCommand.CreateMaterial)
          this.AddMaterial(this.activeJob.solidEntity);
        else if (this.activeMove.Command == RollerBendMoveCommand.MoveBend | this.activeMove.Command == RollerBendMoveCommand.MoveMaterial)
        {
          int index1 = Convert.ToInt32(this.activeMove.XPosition);
          if (clsRollerBend.viewportAuto.Entities.Count > 3)
          {
            Entity entity1 = clsRollerBend.viewportAuto.Entities[clsRollerBend.viewportAuto.Entities.Count - 1];
            if (entity1 is Mesh && (entity1.EntityData == null ? 0 : (entity1.EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) entity1.EntityData).typeDefination == entityTypeDefination.Temp | ((CustomData) entity1.EntityData).typeDefination == entityTypeDefination.Sheet)
            {
              entity1.Selected = true;
              clsRollerBend.viewportAuto.Entities.DeleteSelected();
            }
            Entity entity2 = clsRollerBend.viewportAuto.Entities[clsRollerBend.viewportAuto.Entities.Count - 2];
            if (entity2 is Mesh && (entity2.EntityData == null ? 0 : (entity2.EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) entity2.EntityData).typeDefination == entityTypeDefination.Temp | ((CustomData) entity2.EntityData).typeDefination == entityTypeDefination.Sheet)
            {
              entity2.Selected = true;
              clsRollerBend.viewportAuto.Entities.DeleteSelected();
            }
            Entity entity3 = clsRollerBend.viewportAuto.Entities[clsRollerBend.viewportAuto.Entities.Count - 3];
            if (entity3 is Mesh && (entity3.EntityData == null ? 0 : (entity3.EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) entity3.EntityData).typeDefination == entityTypeDefination.Temp | ((CustomData) entity3.EntityData).typeDefination == entityTypeDefination.Sheet)
            {
              entity3.Selected = true;
              clsRollerBend.viewportAuto.Entities.DeleteSelected();
            }
          }
          if (index1 >= this.activeJob.matPoints.Count)
            index1 = this.activeJob.matPoints.Count - 1;
          if (index1 >= 0 & index1 <= this.activeJob.matPoints.Count - 1 & this.activeMove.Command == RollerBendMoveCommand.MoveBend)
          {
            List<Point3D> points = new List<Point3D>();
            List<Point3D> point3DList = new List<Point3D>();
            int num = 2;
            if (index1 > 500)
              num = 4;
            else if (index1 > 1000)
              num = 6;
            for (int index2 = 0; index2 <= index1; index2 += num)
              points.Add(this.activeJob.matPoints[index2]);
            if (!buCompare5.EQ(points[points.Count - 1], this.activeJob.matPoints[index1]))
              points.Add(this.activeJob.matPoints[index1]);
            if (points.Count > 3)
            {
              Mesh mesh = new LinearPath((ICollection<Point3D>) points).OffsetToRegion(this.activeJob.Thickness, false).ExtrudeAsMesh(new Vector3D(0.0, this.activeJob.SheetWidth, 0.0), 2.5, Mesh.natureType.RichSmooth);
              mesh.Color = Color.SteelBlue;
              mesh.ColorMethod = colorMethodType.byEntity;
              mesh.EntityData = (object) new CustomData()
              {
                typeDefination = entityTypeDefination.Temp
              };
              clsRollerBend.viewportAuto.Entities.Add((Entity) mesh);
              clsRollerBend.viewportAuto.Invalidate();
            }
          }
          double width = this.activeJob.TotalBendingLength;
          if (this.activeMove.XPosition > 0.0 & this.activeMove.Command == RollerBendMoveCommand.MoveBend)
            width = this.activeJob.TotalBendingLength - this.activeMove.XPosition;
          if (width > 0.1)
          {
            CompositeCurve rectangle = CompositeCurve.CreateRectangle(Plane.XZ, width, this.activeJob.Thickness);
            rectangle.Translate(-this.activeJob.TotalBendingLength + this.activeMove.XPosition, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0);
            if (this.activeMove.LeftAngle != 0.0)
              rectangle.Rotate(buConversion5.DegreeToRadian(this.activeMove.LeftAngle + 1.0), Vector3D.AxisY, new Point3D(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0));
            Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) rectangle).ExtrudeAsMesh(new Vector3D(0.0, this.activeJob.SheetWidth, 0.0), 0.5, Mesh.natureType.RichSmooth);
            mesh.Color = Color.SteelBlue;
            mesh.ColorMethod = colorMethodType.byEntity;
            mesh.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.Sheet
            };
            clsRollerBend.viewportAuto.Entities.Add((Entity) mesh);
            clsRollerBend.viewportAuto.Invalidate();
          }
          this.MoveSimPart(this.activeMove);
        }
        else
          this.MoveSimPart(this.activeMove);
        if (this.frmMachSim != null)
          ;
      }
      this.indexSim += buRollerBendCalc.varRollerBendRuntime.SimStep;
    }
    else
    {
      this.indexSim = -1;
      this.timSim.Enabled = false;
    }
  }

  public void MoveSimPart(RollerBendMove pntMove)
  {
    for (int index = 0; index <= clsRollerBend.SimMovePartIndex.Count - 1; ++index)
    {
      if (clsRollerBend.viewportAuto.Entities.Count > 0 & clsRollerBend.SimMovePartIndex[index] <= clsRollerBend.viewportAuto.Entities.Count - 1)
      {
        CustomData entityData = clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]].EntityData as CustomData;
        KinematicBase5 kinematicBase5 = new KinematicBase5()
        {
          RotateCenterOffsetOfA = {
            Z = 171.0
          },
          Type = KinemeticType.CartezianXYZ_WristA_4Axis
        };
        Pnt6D pnt6D = new Pnt6D();
        Point3D point3D = new Point3D();
        int num = clsRollerBend.SimMovePartIndex[index];
        if (clsRollerBend.SimMovePartIndex[index] >= 0 & clsRollerBend.SimMovePartIndex[index] <= clsRollerBend.viewportAuto.Entities.Count - 1 && clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]].GetType() == typeof (buMachinePart))
        {
          buMachinePart entity = clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]] as buMachinePart;
          if (entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.MachineParts)
          {
            string blockName = ((BlockReference) clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]]).BlockName;
            if (blockName == "TopCylinder")
              ((buMachinePart) clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]]).zPos = pntMove.UpDistance;
            if (blockName == "LeftCylinder" | blockName == "LeftFoot")
            {
              ((buMachinePart) clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]]).xPos = pntMove.LeftDistance * Math.Cos(buConversion5.DegreeToRadian(90.0 - buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
              ((buMachinePart) clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]]).zPos = pntMove.LeftDistance * Math.Sin(buConversion5.DegreeToRadian(90.0 - buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
            }
            if (blockName == "RightCylinder" | blockName == "RightFoot")
            {
              ((buMachinePart) clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]]).xPos = pntMove.RightDistance * Math.Cos(buConversion5.DegreeToRadian(90.0 + buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
              ((buMachinePart) clsRollerBend.viewportAuto.Entities[clsRollerBend.SimMovePartIndex[index]]).zPos = pntMove.RightDistance * Math.Sin(buConversion5.DegreeToRadian(90.0 + buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
            }
          }
        }
      }
    }
    clsRollerBend.viewportAuto.Entities.Regen();
    if (!clsRollerBend.viewportAuto.IsAnimationRunning)
      ;
  }

  public void AddMaterial(Entity entMat)
  {
    Entity copiedEntity = (Entity) null;
    buEntity.Copy(entMat, ref copiedEntity);
    copiedEntity.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Material,
      OriginalEntityIndex = clsRollerBend.viewportAuto.Entities.Count
    };
    clsRollerBend.viewportAuto.Entities.Add(copiedEntity);
    clsRollerBend.viewportAuto.Invalidate();
  }

  public void DrawEntities(bool ZoomFit)
  {
    clsRollerBend.viewportAuto.Entities.Clear();
    clsRollerBend.SimMovePartIndex.Clear();
    for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
      {
        buMachinePart buMachinePart = new buMachinePart(ccVars.SimMachine.MachineParts[index1].PartName);
        buMachinePart.ARotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.A;
        buMachinePart.BRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.B;
        buMachinePart.CRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.C;
        buMachinePart.XMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.X;
        buMachinePart.YMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Y;
        buMachinePart.ZMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Z;
        buMachinePart.xRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.X;
        buMachinePart.yRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Y;
        buMachinePart.zRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Z;
        buMachinePart.Color = ccVars.SimMachine.MachineParts[index1].Color;
        buMachinePart.ColorMethod = colorMethodType.byEntity;
        double num = 0.0;
        double dx = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.X;
        double dy = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Y;
        double dz = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Z + num;
        buMachinePart.Translate(dx, dy, dz);
        buMachinePart.Tag = ccVars.SimMachine.MachineParts[index1].Tag;
        buMachinePart.No = ccVars.SimMachine.MachineParts[index1].No;
        buMachinePart.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.MachineBody,
          OriginalEntityIndex = clsRollerBend.viewportAuto.Entities.Count
        };
        clsRollerBend.viewportAuto.Entities.Add((Entity) buMachinePart);
        clsRollerBend.SimMovePartIndex.Add(clsRollerBend.viewportAuto.Entities.Count - 1);
      }
    }
  }

  private void method_0(object sender, MouseEventArgs e)
  {
    Point3D intPoint = new Point3D();
    clsRollerBend.viewportAuto.ScreenToPlane(e.Location, this.planeActive, out intPoint);
    if (!(intPoint != (Point3D) null) || this.frmMachSim == null || this.frmMachSim == null)
      return;
    this.frmMachSim.lbl_x.Text = "X: " + intPoint.X.ToString("f3");
    this.frmMachSim.lbl_y.Text = "Y: " + intPoint.Y.ToString("f3");
    this.frmMachSim.lbl_z.Text = "Z: " + intPoint.Z.ToString("f3");
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
  }

  public void LoadLanguage()
  {
    try
    {
    }
    catch (Exception ex)
    {
    }
  }

  public void SaveRollerBend() => this.SaveRollerBend(AppPath.Settings + "\\RollerBend");

  public void SaveRollerBend(string Path)
  {
    try
    {
      if (AppBool.MachineMode)
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\RollerBend");
        if (directoryInfo.Exists)
          Path = directoryInfo.FullName;
      }
      string FileName = Path + "\\RollerBend.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Roller Bend Settings");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "<varRollerBendSetting>");
      StringList.AddRange((ICollection) buRollerBendCalc.varRollerBendSetting.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</varRollerBendSetting>");
      StringList.Add((object) " ");
      StringList.Add((object) "<varRollerBendRuntime>");
      StringList.AddRange((ICollection) buRollerBendCalc.varRollerBendRuntime.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</varRollerBendRuntime>");
      StringList.Add((object) " ");
      buFile.SaveToFile(StringList, FileName);
      buLog.addLog("RollerBend Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenRollerBend() => this.OpenRollerBend(AppPath.Settings + "\\RollerBend");

  public void OpenRollerBend(string Path)
  {
    string method = "OpenRollerBendFile";
    try
    {
      ArrayList arrayList = new ArrayList();
      if (AppBool.MachineMode)
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\RollerBend");
        if (directoryInfo.Exists)
          Path = directoryInfo.FullName;
      }
      FileInfo fileInfo = new FileInfo(Path + "\\RollerBend.prm");
      if (fileInfo.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        try
        {
          ArrayList CalcList1 = new ArrayList();
          buString5.ListToSpecificList("<varRollerBendSetting>", "</varRollerBendSetting>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization5.Decode(CalcList1, "", SerilizationMode5.MultiLine, (object) buRollerBendCalc.varRollerBendSetting);
            buLog.addLog("RollerBendSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          ArrayList CalcList2 = new ArrayList();
          buString5.ListToSpecificList("<varRollerBendRuntime>", "</varRollerBendRuntime>", true, StringList, ref CalcList2);
          if (CalcList2.Count > 0)
          {
            buSerilization5.Decode(CalcList2, "", SerilizationMode5.MultiLine, (object) buRollerBendCalc.varRollerBendRuntime);
            buLog.addLog("RollerBendRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          buLogVer5.addToLog(this.string_0, method, "Decoded", "RollerBend");
        }
        catch (Exception ex)
        {
          buLog.addLog("RollerBend Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "RollerBend Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("RollerBend.prm File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString5.MessageBoxError("RollerBend Settings File Missing");
      }
      buLog.addLog("RollerBend Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doFindIntersectionLeft(
    double ProducedCircleDiameter,
    ref Point3D foundPoint,
    ref double foundLength,
    ref double Angle,
    bool AddPageEntity = false)
  {
    foundPoint = (Point3D) null;
    foundLength = 0.0;
    if (AddPageEntity)
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if ((entity.EntityData == null ? 0 : (entity.EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) entity.EntityData).typeDefination == entityTypeDefination.Temp)
          entity.Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    Circle C1 = new Circle(Plane.XY, new Point3D(0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
    C1.Regen(0.01);
    Circle circle1 = new Circle(Plane.XZ, new Point3D(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
    circle1.Regen(0.01);
    circle1.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Temp
    };
    if (AddPageEntity)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) circle1);
    Point3D point3D = new Point3D(buRollerBendCalc.varRollerBendSetting.LeftCylinderXOffset, buRollerBendCalc.varRollerBendSetting.LeftCylinderZOffset);
    Circle circle2 = new Circle(Plane.XZ, point3D, buRollerBendCalc.varRollerBendSetting.LeftCylinderDiameter / 2.0);
    for (double Length = 10.0; Length <= 500.0; Length += 2.0)
    {
      Point3D EndPnt = new Point3D();
      clsInit.cVector5.LineWithLengthAndAngle(point3D, Length, 90.0 - buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle, ref EndPnt);
      Circle C2 = new Circle(Plane.XY, EndPnt, buRollerBendCalc.varRollerBendSetting.LeftCylinderDiameter / 2.0);
      Circle circle3 = new Circle(Plane.XZ, new Point3D(EndPnt.X, 0.0, EndPnt.Y), buRollerBendCalc.varRollerBendSetting.LeftCylinderDiameter / 2.0);
      circle3.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Temp
      };
      circle3.Regen(new RegenParams(0.01));
      if (AddPageEntity)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) circle3);
      C2.Regen(0.01);
      Point3D[] point3DArray = Utility.Intersection((ICurve) C1, (ICurve) C2, 0.5);
      if ((point3DArray == null ? 0 : (point3DArray.Length != 0 ? 1 : 0)) != 0)
      {
        Angle = 180.0 - clsInit.cVector5.PointAngle(point3DArray[0], new Point3D(0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0, 0.0));
        foundLength = Length;
        foundPoint = new Point3D(EndPnt.X, 0.0, EndPnt.Y);
        Length = 1000.0;
      }
    }
    if (!AddPageEntity)
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doFindIntersectionRight(
    double ProducedCircleDiameter,
    ref Point3D foundPoint,
    ref double foundLength,
    bool AddPageEntity = false)
  {
    foundPoint = (Point3D) null;
    foundLength = 0.0;
    if (AddPageEntity)
    {
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
      {
        Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
        if ((entity.EntityData == null ? 0 : (entity.EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) entity.EntityData).typeDefination == entityTypeDefination.Temp)
          entity.Selected = true;
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    }
    Circle C1 = new Circle(Plane.XY, new Point3D(0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
    C1.Regen(0.01);
    Circle circle1 = new Circle(Plane.XZ, new Point3D(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
    circle1.Regen(0.01);
    circle1.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Temp
    };
    if (AddPageEntity)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) circle1);
    Point3D point3D = new Point3D(buRollerBendCalc.varRollerBendSetting.RightCylinderXOffset, buRollerBendCalc.varRollerBendSetting.RightCylinderZOffset);
    Circle circle2 = new Circle(Plane.XZ, point3D, buRollerBendCalc.varRollerBendSetting.RightCylinderDiameter / 2.0);
    for (double Length = 10.0; Length <= 500.0; Length += 2.0)
    {
      Point3D EndPnt = new Point3D();
      clsInit.cVector5.LineWithLengthAndAngle(point3D, Length, 90.0 + buRollerBendCalc.varRollerBendSetting.RightCylinderAngle, ref EndPnt);
      Circle C2 = new Circle(Plane.XY, EndPnt, buRollerBendCalc.varRollerBendSetting.RightCylinderDiameter / 2.0);
      Circle circle3 = new Circle(Plane.XZ, new Point3D(EndPnt.X, 0.0, EndPnt.Y), buRollerBendCalc.varRollerBendSetting.RightCylinderDiameter / 2.0);
      circle3.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Temp
      };
      circle3.Regen(new RegenParams(0.01));
      if (AddPageEntity)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) circle3);
      C2.Regen(0.01);
      Point3D[] point3DArray = Utility.Intersection((ICurve) C1, (ICurve) C2, 0.5);
      if ((point3DArray == null ? 0 : (point3DArray.Length != 0 ? 1 : 0)) != 0)
      {
        foundLength = Length;
        foundPoint = new Point3D(EndPnt.X, 0.0, EndPnt.Y);
        Length = 1000.0;
      }
    }
    if (!AddPageEntity)
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doCircle(double Diameter, double Thickness, double SheetWidth, bool Simulation = false)
  {
    Point3D foundPoint1 = (Point3D) null;
    Point3D foundPoint2 = (Point3D) null;
    double foundLength1 = 0.0;
    double foundLength2 = 0.0;
    this.activeJob = new RollerJob();
    this.doFindIntersectionLeft(Diameter, ref foundPoint1, ref foundLength1, ref this.activeJob.LeftAngle);
    this.doFindIntersectionRight(Diameter, ref foundPoint2, ref foundLength2);
    List<ICurve> contours = new List<ICurve>();
    contours.Add((ICurve) new Circle(Plane.XZ, Diameter / 2.0));
    contours.Add((ICurve) new Circle(Plane.XZ, Diameter / 2.0 - Thickness));
    Arc arc = new Arc(Plane.XZ, new Point3D(), Diameter / 2.0, buConversion5.DegreeToRadian(-90.0), buConversion5.DegreeToRadian(270.0));
    this.activeJob.TotalBendingLength = arc.Length();
    this.activeJob.SheetWidth = SheetWidth;
    this.activeJob.Thickness = Thickness;
    this.activeJob.Explanation = $"{buLangTranslate.preDef.Cirlce} - {buLangTranslate.preDef.Diameter}: {Diameter.ToString("f2")}";
    arc.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Diameter / 2.0);
    arc.Regen(new RegenParams(1E-05));
    this.activeJob.matPoints = new List<Point3D>();
    this.activeJob.matPoints.Add(buVector5.ToPoint3D(arc.Vertices[0]));
    buVector5.ToPoint3D(arc.Vertices[0]);
    double num1 = 0.0;
    double num2 = 1.0;
    for (int index = 1; index <= arc.Vertices.Length - 1; ++index)
    {
      double num3 = Point3D.Distance(arc.Vertices[index - 1], arc.Vertices[index]);
      num1 += num3;
      if (num1 >= num2)
      {
        this.activeJob.matPoints.Add(buVector5.ToPoint3D(arc.Vertices[index]));
        buVector5.ToPoint3D(arc.Vertices[index]);
        ++num2;
      }
    }
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((IList<ICurve>) contours);
    region.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Diameter / 2.0);
    Mesh mesh = region.ExtrudeAsMesh(-SheetWidth, 0.01, Mesh.natureType.RichSmooth);
    mesh.ColorMethod = colorMethodType.byEntity;
    mesh.Color = Color.FromArgb(40, Color.LightSteelBlue);
    double cylinderDistance = buRollerBendCalc.varRollerBendSetting.TopBottomCylinderDistance;
    this.activeJob.refEntitiy = (buEntity) new buCircle(Plane.XZ, Diameter / 2.0);
    this.activeJob.solidEntity = (Entity) mesh;
    this.activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(0.0, foundLength1 * 0.6, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(150.0, foundLength1 * 0.6, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(150.0, -10.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(150.0, -10.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(this.activeJob.TotalBendingLength * 1.0, -10.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    clsInit.cRollerBend.CreateSimulationPoints(this.activeJob.Moves, ref this.activeJob.SimulationMoves);
  }

  public void doRectangle(
    double Width,
    double Height,
    double Radius,
    double Thickness,
    double SheetWidth,
    bool Simulation = false)
  {
    Point3D foundPoint1 = (Point3D) null;
    Point3D foundPoint2 = (Point3D) null;
    double foundLength1 = 0.0;
    double foundLength2 = 0.0;
    this.activeJob = new RollerJob();
    this.doFindIntersectionLeft(Radius * 2.0, ref foundPoint1, ref foundLength1, ref this.activeJob.LeftAngle);
    this.doFindIntersectionRight(Radius * 2.0, ref foundPoint2, ref foundLength2);
    List<ICurve> contours = new List<ICurve>();
    CompositeCurve roundedRectangle1 = CompositeCurve.CreateRoundedRectangle(Plane.XZ, Width, Height, Radius, true);
    CompositeCurve roundedRectangle2 = CompositeCurve.CreateRoundedRectangle(Plane.XZ, Width - 2.0 * Thickness, Height - 2.0 * Thickness, Radius - Thickness, true);
    roundedRectangle1.Regen(0.1);
    roundedRectangle2.Regen(0.1);
    contours.Add((ICurve) roundedRectangle1);
    contours.Add((ICurve) roundedRectangle2);
    Line line1 = new Line(new Point3D(0.0, 0.0, -Height / 2.0), new Point3D(Width / 2.0 - Radius, 0.0, -Height / 2.0));
    LinearPath linearPath1 = new LinearPath(line1.GetPointsByLength(0.1));
    Arc arc1 = new Arc(Plane.XZ, new Point3D(Width / 2.0 - Radius, 0.0, -Height / 2.0 + Radius), Radius, buConversion5.DegreeToRadian(-90.0), buConversion5.DegreeToRadian(0.0));
    Line line2 = new Line(new Point3D(Width / 2.0, 0.0, -Height / 2.0 + Radius), new Point3D(Width / 2.0, 0.0, Height / 2.0 - Radius));
    LinearPath linearPath2 = new LinearPath(line2.GetPointsByLength(0.1));
    Arc arc2 = new Arc(Plane.XZ, new Point3D(Width / 2.0 - Radius, 0.0, Height / 2.0 - Radius), Radius, buConversion5.DegreeToRadian(0.0), buConversion5.DegreeToRadian(90.0));
    Line line3 = new Line(new Point3D(Width / 2.0 - Radius, 0.0, Height / 2.0), new Point3D(-Width / 2.0 + Radius, 0.0, Height / 2.0));
    LinearPath linearPath3 = new LinearPath(line3.GetPointsByLength(0.1));
    Arc arc3 = new Arc(Plane.XZ, new Point3D(-Width / 2.0 + Radius, 0.0, Height / 2.0 - Radius), Radius, buConversion5.DegreeToRadian(90.0), buConversion5.DegreeToRadian(180.0));
    Line line4 = new Line(new Point3D(-Width / 2.0, 0.0, Height / 2.0 - Radius), new Point3D(-Width / 2.0, 0.0, -Height / 2.0 + Radius));
    LinearPath linearPath4 = new LinearPath(line4.GetPointsByLength(0.1));
    Arc arc4 = new Arc(Plane.XZ, new Point3D(-Width / 2.0 + Radius, 0.0, -Height / 2.0 + Radius), Radius, buConversion5.DegreeToRadian(180.0), buConversion5.DegreeToRadian(270.0));
    Line line5 = new Line(new Point3D(-Width / 2.0 + Radius, 0.0, -Height / 2.0), new Point3D(0.0, 0.0, -Height / 2.0));
    LinearPath linearPath5 = new LinearPath(line5.GetPointsByLength(0.1));
    List<ICurve> curveList = new List<ICurve>();
    curveList.Add((ICurve) linearPath1);
    curveList.Add((ICurve) arc1);
    curveList.Add((ICurve) linearPath2);
    curveList.Add((ICurve) arc2);
    curveList.Add((ICurve) linearPath3);
    curveList.Add((ICurve) arc3);
    curveList.Add((ICurve) linearPath4);
    curveList.Add((ICurve) arc4);
    curveList.Add((ICurve) linearPath5);
    double xPosition1 = line1.Length();
    double xPosition2 = line1.Length() + arc1.Length();
    double xPosition3 = line1.Length() + arc1.Length() + line2.Length();
    double xPosition4 = line1.Length() + arc1.Length() + line2.Length() + arc2.Length();
    double xPosition5 = line1.Length() + arc1.Length() + line2.Length() + arc2.Length() + line3.Length();
    double xPosition6 = line1.Length() + arc1.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length();
    double xPosition7 = line1.Length() + arc1.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length() + line4.Length();
    double xPosition8 = line1.Length() + arc1.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length() + line4.Length() + arc4.Length();
    double xPosition9 = line1.Length() + arc1.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length() + line4.Length() + arc4.Length() + line5.Length();
    CompositeCurve compositeCurve = new CompositeCurve((IEnumerable<ICurve>) curveList, true);
    this.activeJob.TotalBendingLength = 2.0 * Width - 2.0 * Radius + (2.0 * Height - 2.0 * Radius) + 2.0 * Math.PI * Radius;
    this.activeJob.SheetWidth = SheetWidth;
    this.activeJob.Thickness = Thickness;
    compositeCurve.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Height / 2.0);
    compositeCurve.Regen(new RegenParams(1E-05));
    this.activeJob.matPoints = new List<Point3D>();
    this.activeJob.matPoints.Add(buVector5.ToPoint3D(compositeCurve.Vertices[0]));
    buVector5.ToPoint3D(compositeCurve.Vertices[0]);
    double num1 = 0.0;
    double num2 = 1.0;
    for (int index = 1; index <= compositeCurve.Vertices.Length - 1; ++index)
    {
      double num3 = Point3D.Distance(compositeCurve.Vertices[index - 1], compositeCurve.Vertices[index]);
      num1 += num3;
      if (num1 >= num2)
      {
        this.activeJob.matPoints.Add(buVector5.ToPoint3D(compositeCurve.Vertices[index]));
        buVector5.ToPoint3D(compositeCurve.Vertices[index]);
        ++num2;
      }
    }
    this.activeJob.matPoints.Reverse();
    clsInit.cVector5.Rotate(new Point3D(), 180.0, Plane.XY, ref this.activeJob.matPoints);
    devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region((IList<ICurve>) contours, Plane.XZ, true);
    region.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Height / 2.0);
    Mesh mesh = region.ExtrudeAsMesh(-SheetWidth, 0.01, Mesh.natureType.RichSmooth);
    mesh.ColorMethod = colorMethodType.byEntity;
    mesh.Color = Color.FromArgb(40, Color.LightSteelBlue);
    double cylinderDistance = buRollerBendCalc.varRollerBendSetting.TopBottomCylinderDistance;
    this.activeJob.solidEntity = (Entity) mesh;
    if (Simulation)
    {
      this.activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveFree));
      this.activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 30.0, -cylinderDistance, RollerBendMoveCommand.MoveFree));
      this.activeJob.Moves.Add(new RollerBendMove(200.0, 0.0, 30.0, -cylinderDistance, RollerBendMoveCommand.MoveMaterial));
      this.activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 30.0, -cylinderDistance, RollerBendMoveCommand.MoveMaterial));
    }
    this.activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition1, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveMaterial));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition1, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition2, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition2, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition3, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition3, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition4, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition4, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition5, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition5, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition6, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition6, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition7, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition7, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition8, 0.0, foundLength2, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition8, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    this.activeJob.Moves.Add(new RollerBendMove(xPosition9, 0.0, 0.0, -cylinderDistance, RollerBendMoveCommand.MoveBend));
    clsInit.cRollerBend.CreateSimulationPoints(this.activeJob.Moves, ref this.activeJob.SimulationMoves);
  }

  public void doCreateCode(RollerJob JobItem, ref string strCode)
  {
    if (JobItem == null)
    {
      strCode = "";
    }
    else
    {
      strCode = $"// {buLangTranslate.preDef.Job} {buLangTranslate.preDef.Name} : {JobItem.Name}{Environment.NewLine}";
      strCode = $"{strCode}// {JobItem.Explanation}{Environment.NewLine}";
      strCode = $"{strCode}// {buLangTranslate.preDef.Thickness} {JobItem.Thickness.ToString("f2")}{Environment.NewLine}";
      strCode = $"{strCode}// {buLangTranslate.preDef.Sheet} {buLangTranslate.preDef.Width} {JobItem.SheetWidth.ToString("f2")}{Environment.NewLine}";
      strCode = $"{strCode}// {buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} {JobItem.TotalBendingLength.ToString("f2")}{Environment.NewLine}";
      for (int index = 0; index <= JobItem.Moves.Count - 1; ++index)
      {
        RollerBendMove move = JobItem.Moves[index];
        string str1 = JobItem.Moves[index].XPosition.ToString("f2");
        string str2 = JobItem.Moves[index].LeftDistance.ToString("f2");
        string str3 = JobItem.Moves[index].RightDistance.ToString("f2");
        if (index > 0)
        {
          if (buCompare5.EQ(JobItem.Moves[index].XPosition - JobItem.Moves[index - 1].XPosition, 0.0, 0.1))
            str1 = "";
          if (buCompare5.EQ(JobItem.Moves[index].LeftDistance - JobItem.Moves[index - 1].LeftDistance, 0.0, 0.1))
            str2 = "";
          if (buCompare5.EQ(JobItem.Moves[index].RightDistance - JobItem.Moves[index - 1].RightDistance, 0.0, 0.1))
            str3 = "";
        }
        if (move.Command == RollerBendMoveCommand.MoveMaterial)
        {
          string str4 = "";
          if (str1.Length > 0)
            str4 = $"{str4}Move Sheet: {str1} ";
          if (str2.Length > 0)
            str4 = $"{str4}Bend A: {str2} ";
          if (str3.Length > 0)
            str4 = $"{str4}Bend B: {str3} ";
          if (str4.Length == 0)
            str4 = "Move Sheet : No Code";
          strCode = strCode + str4 + Environment.NewLine;
        }
        else if (move.Command == RollerBendMoveCommand.CreateMaterial)
          strCode = $"{strCode}Create Material : {JobItem.TotalBendingLength.ToString("f2")} X {JobItem.SheetWidth.ToString("f2")}{Environment.NewLine}";
        else if (move.Command == RollerBendMoveCommand.MoveBend)
        {
          string str5 = "";
          if (str1.Length > 0)
            str5 = $"{str5}Move Sheet: {str1} ";
          if (str2.Length > 0)
            str5 = $"{str5}Bend A: {str2} ";
          if (str3.Length > 0)
            str5 = $"{str5}Bend B: {str3} ";
          if (str5.Length == 0)
            str5 = "Bend : No Code";
          strCode = strCode + str5 + Environment.NewLine;
        }
        else if (move.Command == RollerBendMoveCommand.MoveFree)
        {
          string str6 = "";
          if (str1.Length > 0)
            str6 = $"{str6}Free Move Sheet: {str1} ";
          if (str2.Length > 0)
            str6 = $"{str6}Free Bend A: {str2} ";
          if (str3.Length > 0)
            str6 = $"{str6}Free Bend B: {str3} ";
          if (str6.Length == 0)
            str6 = "Free : No Code";
          strCode = strCode + str6 + Environment.NewLine;
        }
        else
          strCode = $"{strCode}Unknow Code{Environment.NewLine}";
      }
    }
  }

  public void Calculate()
  {
  }
}
