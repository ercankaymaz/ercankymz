// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.PipeBending.clsPipeBending
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buApplication3D.UserInterfaces;
using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.SheetBending;
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
namespace buCadCamResVer5.PipeBending;

public class clsPipeBending
{
  public Plane planeActive = Plane.XY;
  public static List<Entity> SimToCollsionCheck1 = new List<Entity>();
  public static List<Entity> SimToCollsionCheck2 = new List<Entity>();
  public F_PipeBendMachSim frmMachSim = (F_PipeBendMachSim) null;
  public static F_BendingLRAList FrmPipeLRA = (F_BendingLRAList) null;
  public PipeBendSimulationMove pntSim = new PipeBendSimulationMove();
  private int int_0 = 0;
  private bool bool_0;

  public event OkCommandWithThreeDataEventHandler SimulationUpdate;

  public void Init() => clsPipeBending.FrmPipeLRA = new F_BendingLRAList();

  public void InitSimulation(bool ShowForm = true)
  {
    clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
    buUserSimVariables.Init();
    buUserControls.timSim = new Timer();
    buUserControls.timSim.Tick += new EventHandler(this.tick_Simulation);
    buUserControls.timCollision = new Timer();
    buUserControls.timCollision.Interval = 1000;
    buUserControls.timCollision.Tick += new EventHandler(this.method_0);
    if (ShowForm)
    {
      if (this.frmMachSim == null)
        this.frmMachSim = new F_PipeBendMachSim();
      this.frmMachSim.btn_xplus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_xminus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_yplus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_yminus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_zplus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_zminus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_rplus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_rminus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_tplus.Click += new EventHandler(this.MoveAxesEvent);
      this.frmMachSim.btn_tminus.Click += new EventHandler(this.MoveAxesEvent);
    }
    if (buEyeItems.viewportCNC == null)
    {
      clsInit.cVector5.CreateModelControl(ref buEyeItems.viewportCNC, clsVar.UnlockKey, new CreateModelProperties()
      {
        DisplayType = displayType.Rendered,
        CoordinateSystemIconVisible = true,
        OriginSymbolVisible = false,
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
      buEyeItems.viewportCNC.Name = "ModelAuto";
      if (ShowForm)
        this.frmMachSim.pnl_viewport.Controls.Add((System.Windows.Forms.Control) buEyeItems.viewportCNC);
      buEyeItems.viewportCNC.MouseMove += new MouseEventHandler(this.method_3);
      buEyeItems.viewportCNC.MouseDown += new MouseEventHandler(this.method_4);
      buEyeItems.viewportCNC.MouseUp += new MouseEventHandler(this.method_5);
      buEyeItems.viewportCNC.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
      buEyeItems.viewportCNC.ProgressBar.Visible = false;
      buEyeItems.viewportCNC.WaitCursorMode = waitCursorType.Never;
      buEyeItems.viewportCNC.MouseMove += new MouseEventHandler(this.method_2);
      this.CreateMachine();
    }
    if (buEyeItems.viewportDialogs != null)
      return;
    buEyeItems.viewportDialogs = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, new CreateModelProperties()
    {
      DisplayType = displayType.Rendered,
      CoordinateSystemIconVisible = false,
      OriginSymbolVisible = false,
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
    buEyeItems.viewportDialogs.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    buEyeItems.viewportDialogs.Name = "ModelDialog";
    buEyeItems.viewportDialogs.MouseMove += new MouseEventHandler(buEyeItems.mouseMoveViewportDialogs);
  }

  public void tick_Simulation(object sender, EventArgs e)
  {
    try
    {
      if (clsInit.cPipeBend.activeJob == null || clsInit.cPipeBend.activeJob.SimMoves.Count == 0 || buEyeItems.viewportCNC.IsBusy)
        return;
      buUserControls.timSim.Enabled = false;
      int indexMove1 = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].IndexMove;
      if (clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].MovePipe)
        PipeBendTempVars._excecutionPipe = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].ExecutedPipe;
      if (buUserSimVariables.indexSim >= 0 & buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1)
      {
        this.pntSim.BendPos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].CPos;
        this.pntSim.YPreasurePos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].YPreasurePos;
      }
      if (PipeBendTempVars._excecutionPipe > PipeBendTempVars._pipeTotalLength)
        PipeBendTempVars._excecutionPipe = PipeBendTempVars._pipeTotalLength;
      if (clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].MovePipe)
      {
        int indexMove2 = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].IndexMove;
        this.method_1(ref indexMove2, clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim]);
        ++buUserSimVariables.indexSim;
        if (!(PipeBendTempVars.ProgressFinished | indexMove2 > indexMove1))
          ;
      }
      else
        ++buUserSimVariables.indexSim;
      if (buUserSimVariables.indexSim >= 0 & buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1)
      {
        this.pntSim.ZPos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].ZPos;
        this.pntSim.YPos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].YPos;
        this.MoveSimPart(this.pntSim);
      }
      if (PipeBendTempVars._excecutionPipe < PipeBendTempVars._pipeTotalLength & !AppBool.Pause & !AppBool.CollisionAvailable)
        buUserControls.timSim.Enabled = true;
      if (buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1)
        return;
      buUserSimVariables.indexSim = 0;
      buUserControls.timSim.Enabled = false;
    }
    catch (Exception ex)
    {
    }
  }

  private void method_0(object sender, EventArgs e)
  {
    if (this.bool_0)
    {
      clsInit.cPipeBend.Highlight(buEyeItems.viewportCNC.Entities[PipeBendTempVars._entityCollisionIndex], PipeBendTempVars.collisionColor, buEyeItems.viewportCNC);
      this.bool_0 = false;
    }
    else
    {
      clsInit.cPipeBend.Highlight(buEyeItems.viewportCNC.Entities[PipeBendTempVars._entityCollisionIndex], PipeBendTempVars.collisionColor2, buEyeItems.viewportCNC);
      this.bool_0 = true;
    }
    buEyeItems.viewportCNC.Invalidate();
  }

  public void MoveSimPart(PipeBendSimulationMove pntMove)
  {
    for (int index = 0; index <= buUserSimVariables.SimMovePartIndex.Count - 1; ++index)
    {
      if (buEyeItems.viewportCNC.Entities.Count > 0 & buUserSimVariables.SimMovePartIndex[index] <= buEyeItems.viewportCNC.Entities.Count - 1)
      {
        CustomData entityData = buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]].EntityData as CustomData;
        Pnt6D pnt6D = new Pnt6D();
        Point3D point3D = new Point3D();
        int num = buUserSimVariables.SimMovePartIndex[index];
        if (buUserSimVariables.SimMovePartIndex[index] >= 0 & buUserSimVariables.SimMovePartIndex[index] <= buEyeItems.viewportCNC.Entities.Count - 1 && buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]].GetType() == typeof (buMachinePart))
        {
          buMachinePart entity = buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]] as buMachinePart;
          if (entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.MachineParts)
          {
            string blockName = ((BlockReference) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).BlockName;
            if (blockName == "XBlock")
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).xPos = pntMove.Length;
            if (blockName == "YMoveOnXBlock")
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).xPos = pntMove.Length;
            if (blockName == "XBending")
            {
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).xPos = pntMove.XBendingPos;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).yPos = pntMove.YPos;
            }
            if (blockName == "PipeRotate")
            {
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).xPos = pntMove.Length;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).aPos = pntMove.RotatePos;
            }
            if (blockName == "ProductLean")
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).xPos = pntMove.Length;
            if (blockName == "YBlock")
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).yPos = pntMove.YPos;
            if (blockName == "YPreasure")
            {
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).yPos = pntMove.YPos;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).zPos = pntMove.ZPos;
            }
            if (blockName == "ZBlock")
            {
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).yPos = pntMove.YPos;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).zPos = pntMove.ZPos;
            }
            if (blockName == "RotateAll")
            {
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).cPos = pntMove.BendPos;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).yPos = pntMove.YPos;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).zPos = pntMove.ZPos;
            }
            if (blockName == "RotateAndYMove")
            {
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).cPos = pntMove.BendPos;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).yPos = pntMove.YPos + pntMove.YPreasurePos;
              ((buMachinePart) buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[index]]).zPos = pntMove.ZPos;
            }
          }
        }
      }
    }
    buEyeItems.viewportCNC.Entities.Regen();
    if (!buEyeItems.viewportCNC.IsAnimationRunning)
      ;
  }

  public void AddMaterial(Entity entMat)
  {
    Entity copiedEntity = (Entity) null;
    buEntity.Copy(entMat, ref copiedEntity);
    copiedEntity.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Material,
      OriginalEntityIndex = buEyeItems.viewportCNC.Entities.Count
    };
    buEyeItems.viewportCNC.Entities.Add(copiedEntity);
    buEyeItems.viewportCNC.Invalidate();
  }

  public void CreateMachine()
  {
    buUserSimVariables.SimMovePartIndex.Clear();
    if (ccVars.SimMachine != null)
    {
      buEyeItems.viewportCNC.Blocks.Clear();
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
          refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) buEyeItems.viewportCNC));
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
          buEyeItems.viewportCNC.Blocks.Add(block);
        }
      }
    }
    PipeBendTempVars._numOfFileBlocks = buEyeItems.viewportCNC.Blocks.Count;
  }

  public void DrawEntities(bool ZoomFit)
  {
    buEyeItems.viewportCNC.Entities.Clear();
    buUserSimVariables.SimMovePartIndex.Clear();
    if (buEyeItems.viewportCNC.Blocks.Count <= 5)
    {
      this.CreateMachine();
      buEyeItems.viewportCNC.Blocks.Clear();
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
          refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) buEyeItems.viewportCNC));
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
          buEyeItems.viewportCNC.Blocks.Add(block);
        }
      }
    }
    for (int index3 = 0; index3 <= ccVars.SimMachine.MachineParts.Count - 1; ++index3)
    {
      for (int index4 = 0; index4 <= ccVars.SimMachine.MachineParts[index3].Entities.Count - 1; ++index4)
      {
        buMachinePart buMachinePart = new buMachinePart(ccVars.SimMachine.MachineParts[index3].PartName);
        buMachinePart.ARotation = ccVars.SimMachine.MachineParts[index3].MoveAxisPermision.A;
        buMachinePart.BRotation = ccVars.SimMachine.MachineParts[index3].MoveAxisPermision.B;
        buMachinePart.CRotation = ccVars.SimMachine.MachineParts[index3].MoveAxisPermision.C;
        buMachinePart.XMove = ccVars.SimMachine.MachineParts[index3].MoveAxisPermision.X;
        buMachinePart.YMove = ccVars.SimMachine.MachineParts[index3].MoveAxisPermision.Y;
        buMachinePart.ZMove = ccVars.SimMachine.MachineParts[index3].MoveAxisPermision.Z;
        buMachinePart.xRot = ccVars.SimMachine.MachineParts[index3].RotationCenter.X;
        buMachinePart.yRot = ccVars.SimMachine.MachineParts[index3].RotationCenter.Y;
        buMachinePart.zRot = ccVars.SimMachine.MachineParts[index3].RotationCenter.Z;
        buMachinePart.Color = ccVars.SimMachine.MachineParts[index3].Color;
        buMachinePart.ColorMethod = colorMethodType.byEntity;
        double num = 0.0;
        double dx = ccVars.SimMachine.MachineParts[index3].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[index3].PositionAuxOffset.X;
        double dy = ccVars.SimMachine.MachineParts[index3].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[index3].PositionAuxOffset.Y;
        double dz = ccVars.SimMachine.MachineParts[index3].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[index3].PositionAuxOffset.Z + num;
        buMachinePart.Translate(dx, dy, dz);
        if (buEyeItems.viewportCNC.Blocks.Count > 0)
          ;
        buMachinePart.Tag = ccVars.SimMachine.MachineParts[index3].Tag;
        buMachinePart.No = ccVars.SimMachine.MachineParts[index3].No;
        buMachinePart.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.MachineBody,
          OriginalEntityIndex = buEyeItems.viewportCNC.Entities.Count
        };
        buEyeItems.viewportCNC.Entities.Add((Entity) buMachinePart);
        buUserSimVariables.SimMovePartIndex.Add(buEyeItems.viewportCNC.Entities.Count - 1);
      }
    }
    PipeBendTempVars._numOfFileEntities = buEyeItems.viewportCNC.Entities.Count;
  }

  public void MoveAxesEvent(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
    if (control.Name == this.frmMachSim.btn_xplus.Name)
      this.MoveAxes("X", 20.0);
    if (control.Name == this.frmMachSim.btn_xminus.Name)
      this.MoveAxes("X", -20.0);
    if (control.Name == this.frmMachSim.btn_yplus.Name)
      this.MoveAxes("Y", 10.0);
    if (control.Name == this.frmMachSim.btn_yminus.Name)
      this.MoveAxes("Y", -10.0);
    if (control.Name == this.frmMachSim.btn_zplus.Name)
      this.MoveAxes("Z", 10.0);
    if (control.Name == this.frmMachSim.btn_zminus.Name)
      this.MoveAxes("Z", -10.0);
    if (control.Name == this.frmMachSim.btn_rplus.Name)
      this.MoveAxes("M", -5.0);
    if (control.Name == this.frmMachSim.btn_rminus.Name)
      this.MoveAxes("M", 5.0);
    if (control.Name == this.frmMachSim.btn_tplus.Name)
      this.MoveAxes("A", 5.0);
    if (!(control.Name == this.frmMachSim.btn_tminus.Name))
      return;
    this.MoveAxes("A", -5.0);
  }

  public void MoveAxes(string Axis, double Value)
  {
    if (Axis == "X")
      this.pntSim.Length += Value;
    if (Axis == "Y")
      this.pntSim.YPos += Value;
    if (Axis == "Z")
      this.pntSim.ZPos += Value;
    if (Axis == "M")
      this.pntSim.BendPos += Value;
    if (Axis == "A")
      this.pntSim.RotatePos += Value;
    if (Axis == "YPreasure")
      this.pntSim.YPreasurePos += Value;
    if (Axis == "XBending")
      this.pntSim.XBendingPos += Value;
    this.MoveSimPart(this.pntSim);
  }

  private void method_1(
    ref int int_1,
    PipeBendSimulationMove pipeBendSimulationMove_0,
    bool bool_1 = false)
  {
    try
    {
      PipeBendTempVars._sw.Start();
      double num1 = 0.0;
      int_1 = 0;
      ++PipeBendTempVars.doneZSteps;
      while (buEyeItems.viewportCNC.Blocks.Count > PipeBendTempVars._numOfFileBlocks)
        buEyeItems.viewportCNC.Blocks.RemoveAt(buEyeItems.viewportCNC.Blocks.Count - 1);
      while (buEyeItems.viewportCNC.Entities.Count > PipeBendTempVars._numOfFileEntities & buEyeItems.viewportCNC.Entities.Count > 0)
        buEyeItems.viewportCNC.Entities.RemoveAt(buEyeItems.viewportCNC.Entities.Count - 1);
      PipeBendTempVars._surfList.Clear();
      PipeBendTempVars._straightPartCounter = 0;
      PipeBendTempVars._bendPartCounter = 0;
      PipeBendTempVars.ProgressFinished = false;
      PipeBendTempVars._excecutionPipe = pipeBendSimulationMove_0.ExecutedPipe;
      while (num1 < PipeBendTempVars._excecutionPipe)
      {
        if (PipeBendTempVars._excecutionPipe >= num1 + clsInit.cPipeBend.activeJob.BendingList[int_1].Length)
        {
          if (clsInit.cPipeBend.activeJob.BendingList[int_1].Length > 0.0)
            buEyeItems.viewportCNC = clsInit.cPipeBend.AddStraight(clsInit.cPipeBend.activeJob.BendingList[int_1].Length, buEyeItems.viewportCNC);
          num1 += clsInit.cPipeBend.activeJob.BendingList[int_1].Length;
          if (PipeBendTempVars._excecutionPipe - num1 < pipeBendSimulationMove_0.ExecutedStep)
          {
            PipeBendTempVars.ProgressFinished = true;
            PipeBendTempVars._excecutionPipe = num1;
          }
          if (PipeBendTempVars._excecutionPipe > num1)
          {
            clsInit.cPipeBend.RotatePipe(clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
          }
          else
          {
            if (clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation < 0.0)
              --PipeBendTempVars.doneZSteps;
            else
              ++PipeBendTempVars.doneZSteps;
            double num2 = (double) (PipeBendTempVars.doneZSteps * 10);
            if (num2 >= clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation & num2 > 0.0 | num2 <= clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation & num2 < 0.0)
            {
              num2 = clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation;
              PipeBendTempVars.doneZSteps = 0;
            }
            clsInit.cPipeBend.RotatePipe(num2 / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
          }
          if (PipeBendTempVars._excecutionPipe >= num1 + clsInit.cPipeBend.CurveUnbending(int_1, clsInit.cPipeBend.activeJob.BendingList))
          {
            if (clsInit.cPipeBend.activeJob.BendingList[int_1].Angle > 0.0)
            {
              buEyeItems.viewportCNC = clsInit.cPipeBend.AddTurn(clsInit.cPipeBend.activeJob.BendingList[int_1].Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, clsInit.cPipeBend.activeJob.BendingList[int_1].Radius, 0.0), buEyeItems.viewportCNC);
              num1 += clsInit.cPipeBend.CurveUnbending(int_1, clsInit.cPipeBend.activeJob.BendingList);
            }
            ++int_1;
          }
          else
          {
            double mm = PipeBendTempVars._excecutionPipe - num1;
            PipeBendTempVars.ProgressFinished = false;
            if (mm > 0.0)
            {
              double num3 = clsInit.cPipeBend.AnglePortion(mm, int_1, clsInit.cPipeBend.activeJob.BendingList) / 180.0 * Math.PI;
              buEyeItems.viewportCNC = clsInit.cPipeBend.AddTurn(num3, Vector3D.AxisZ, new Point3D(0.0, clsInit.cPipeBend.activeJob.BendingList[int_1].Radius, 0.0), buEyeItems.viewportCNC);
              this.pntSim.BendPos = -buConversion5.RadianToDegree(num3);
              if (buUserSimVariables.indexSim >= 1 & buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1)
                this.pntSim.YPreasurePos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim - 1].YPreasurePos;
              num1 += mm;
            }
          }
        }
        else
        {
          buEyeItems.viewportCNC = clsInit.cPipeBend.AddStraight(PipeBendTempVars._excecutionPipe - num1, buEyeItems.viewportCNC);
          double num4 = num1 + (PipeBendTempVars._excecutionPipe - num1);
          break;
        }
      }
      this.pntSim.Length = -PipeBendTempVars._pipeTotalLength + PipeBendTempVars._excecutionPipe - 1.0;
      if (buUserSimVariables.indexSim >= 0 & buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1)
        this.MoveSimPart(this.pntSim);
      if (PipeBendTempVars._pipeTotalLength > PipeBendTempVars._excecutionPipe)
        buEyeItems.viewportCNC = clsInit.cPipeBend.AddStraightBack(PipeBendTempVars._pipeTotalLength - PipeBendTempVars._excecutionPipe, buEyeItems.viewportCNC);
      foreach (Entity surf in PipeBendTempVars._surfList)
      {
        surf.Rotate(Math.PI, Vector3D.AxisX, Point3D.Origin);
        surf.Translate((double) PipeBendTempVars.OffsetX, (double) PipeBendTempVars.OffsetY);
      }
      Block newItem1 = new Block("pipe");
      for (int index = 1; index <= PipeBendTempVars._straightPartCounter; ++index)
      {
        BlockReference blockReference = new BlockReference(PipeBendTempVars.StraightBlockName + index.ToString());
        newItem1.Entities.Add((Entity) blockReference);
      }
      for (int index = 1; index <= PipeBendTempVars._bendPartCounter; ++index)
      {
        BlockReference blockReference = new BlockReference(PipeBendTempVars.BendBlockName + index.ToString());
        newItem1.Entities.Add((Entity) blockReference);
      }
      buEyeItems.viewportCNC.Blocks.AddOrReplace(newItem1);
      BlockReference blockReference1 = new BlockReference("pipe");
      buEyeItems.viewportCNC.Entities.Add((Entity) blockReference1);
      try
      {
        BlockReference blockReference2 = new BlockReference(PipeBendTempVars.StraightbackBlockName);
        newItem1.Entities.Add((Entity) blockReference2);
      }
      catch
      {
      }
      if (PipeBendTempVars._excecutionPipe == PipeBendTempVars._pipeTotalLength)
      {
        buUserControls.timSim.Enabled = false;
        PipeBendTempVars._sw.Stop();
      }
      else if (!bool_1)
        buUserControls.timSim.Enabled = true;
      List<Entity> list = new List<Entity>();
      List<Entity> entityList = new List<Entity>();
      Block newItem2 = new Block(PipeBendTempVars.MachineBlockName);
      PipeBendTempVars.machineCollisionEntities = new int[1];
      foreach (int machineCollisionEntity in PipeBendTempVars.machineCollisionEntities)
        newItem2.Entities.Add(buEyeItems.viewportCNC.Entities[machineCollisionEntity]);
      BlockReference blockReference3 = new BlockReference(PipeBendTempVars.MachineBlockName);
      buEyeItems.viewportCNC.Blocks.AddOrReplace(newItem2);
      list.Add((Entity) blockReference3);
      list.Add(buEyeItems.viewportCNC.Entities[buEyeItems.viewportCNC.Entities.Count - 1]);
      // ISSUE: reference to a compiler-generated field
      if (this.okCommandWithThreeDataEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.okCommandWithThreeDataEventHandler_0((object) this.pntSim, (object) null, (object) null);
      }
      if (buPipeBendCalc.varPipeBendingProgramSettings.CollisionCheck)
      {
        PipeBendTempVars._cd = new CollisionDetection((IList<Entity>) list, buEyeItems.viewportCNC.Blocks, PipeBendTempVars._firstOnly, PipeBendTempVars._checkMethod);
        PipeBendTempVars._cd.DoWork();
        if ((PipeBendTempVars._cd.Result == null ? 0 : (PipeBendTempVars._cd.Result.Length != 0 ? 1 : 0)) != 0)
        {
          PipeBendTempVars._entityCollisionIndex = clsInit.cPipeBend.GetCollisionIndex(buEyeItems.viewportCNC);
          PipeBendTempVars.collidedEntities.Add(buEyeItems.viewportCNC.Entities[PipeBendTempVars._entityCollisionIndex]);
          buEyeItems.viewportCNC.Entities[PipeBendTempVars._entityCollisionIndex].ColorMethod = colorMethodType.byEntity;
          buEyeItems.viewportCNC = clsInit.cPipeBend.Highlight(buEyeItems.viewportCNC.Entities[PipeBendTempVars._entityCollisionIndex], PipeBendTempVars.collisionColor, buEyeItems.viewportCNC);
          buUserControls.timSim.Enabled = false;
          buUserControls.timCollision.Enabled = true;
          AppBool.CollisionAvailable = true;
          PipeBendTempVars._sw.Stop();
        }
      }
      PipeBendTempVars._sw.Stop();
      buEyeItems.viewportCNC.Invalidate();
    }
    catch (Exception ex)
    {
      PipeBendTempVars._sw.Stop();
    }
  }

  private void method_2(object sender, MouseEventArgs e)
  {
    Point3D point3D = new Point3D();
  }

  private void method_3(object sender, MouseEventArgs e)
  {
    if (!((sender as Design).Name == buEyeItems.viewportCNC.Name) || buUserSimVariables.pntMouseViewport != (Point3D) null)
      ;
  }

  private void method_4(object sender, MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
      ;
  }

  private void method_5(object sender, MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
      ;
  }

  public void cmdSimilation(bool ShowForm = true)
  {
    if (!buEyeItems.viewportCNC.IsAnimationRunning)
      buEyeItems.viewportCNC.StartAnimation(new int?(buPipeBendCalc.varPipeBendingProgramSettings.SimulationIntervalMs));
    if (ShowForm)
    {
      this.frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      this.frmMachSim.Init();
      this.frmMachSim.StartPosition = FormStartPosition.CenterParent;
    }
    this.DrawEntities(true);
    buUserControls.timCollision.Enabled = false;
    foreach (KeyValuePair<Entity, Color> originalColor in PipeBendTempVars.originalColors)
      originalColor.Key.Color = originalColor.Value;
    PipeBendTempVars.OffsetX = 0;
    PipeBendTempVars.OffsetY = 216;
    ++PipeBendTempVars.NumberOfSim;
    PipeBendTempVars._pipeTotalLength = clsInit.cPipeBend.GetPipeLength(clsInit.cPipeBend.activeJob.BendingList);
    PipeBendTempVars._excecutionPipe = 0.0;
    int int_1 = 0;
    if (clsInit.cPipeBend.activeJob.SimMoves.Count > 0)
      this.method_1(ref int_1, clsInit.cPipeBend.activeJob.SimMoves[0]);
    buUserControls.timSim.Enabled = false;
    if (!ShowForm)
      return;
    int num = (int) this.frmMachSim.ShowDialog();
  }

  public void cmdStartSimulation(bool Step)
  {
    if (AppBool.Pause)
    {
      buUserControls.timSim.Enabled = true;
      AppBool.Pause = false;
    }
    else
    {
      buUserControls.timCollision.Enabled = false;
      PipeBendTempVars._excecutionPipe = 0.0;
      buUserControls.timSim.Interval = buPipeBendCalc.varPipeBendingProgramSettings.SimulationIntervalMs;
      buRollerBendCalc.varRollerBendRuntime.StepRun = Step;
      if (buUserSimVariables.indexSim == -1)
        buUserSimVariables.indexSim = 0;
      buUserControls.timSim.Enabled = true;
      if (!Step)
      {
        buRollerBendCalc.varRollerBendRuntime.StepRun = false;
        buEyeItems.viewportCNC.Entities.ClearSelection();
        buEyeItems.viewportCNC.Invalidate();
      }
      else if (buRollerBendCalc.varRollerBendRuntime.StepRun & Step)
        ;
    }
  }

  public void cmdStopSimulation()
  {
    if (buUserControls.timSim.Enabled)
    {
      buUserControls.timSim.Enabled = false;
      AppBool.Pause = true;
    }
    else
    {
      AppBool.CollisionAvailable = false;
      AppBool.Pause = false;
      buUserSimVariables.indexSim = 0;
      buUserControls.timSim.Enabled = false;
    }
  }

  public void cmdNextSimulation() => this.tick_Simulation((object) null, (EventArgs) null);

  public void cmdPreSimulation()
  {
    if (buUserSimVariables.indexSim <= 0)
      return;
    buUserSimVariables.indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
    buUserSimVariables.indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
    this.tick_Simulation((object) null, (EventArgs) null);
  }

  public void cmdSetView(viewType Type)
  {
    switch (Type)
    {
      case viewType.Front:
        buEyeShotFunctions.Viewfront(ref buEyeItems.viewportCNC, false);
        this.planeActive = Plane.XZ;
        break;
      case viewType.Right:
        buEyeShotFunctions.ViewRight(ref buEyeItems.viewportCNC, false);
        this.planeActive = Plane.YZ;
        break;
      case viewType.Rear:
        buEyeShotFunctions.ViewBack(ref buEyeItems.viewportCNC, false);
        this.planeActive = Plane.XZ;
        break;
      case viewType.Left:
        buEyeShotFunctions.ViewLeft(ref buEyeItems.viewportCNC, false);
        this.planeActive = Plane.YZ;
        break;
      case viewType.Top:
        buEyeShotFunctions.ViewTop(ref buEyeItems.viewportCNC, false);
        this.planeActive = Plane.XY;
        break;
      case viewType.Bottom:
        buEyeShotFunctions.ShowViewportViewBox(ref buEyeItems.viewportCNC, false);
        this.planeActive = Plane.XY;
        break;
      default:
        buEyeShotFunctions.ViewIso(ref buEyeItems.viewportCNC, false);
        this.planeActive = Plane.XY;
        break;
    }
  }

  public void cmdCreateBase()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    double width = 566.0;
    double height = 88.0;
    List<ICurve> contours = new List<ICurve>();
    contours.Add((ICurve) new LinearPath(0.0, 0.0, width, height));
    Circle circle = new Circle(50.0, 10.0, 0.0, 4.0);
    Brep brep = new devDept.Eyeshot.Entities.Region((IList<ICurve>) contours).ExtrudeAsBrep(-1.0, 0.0, 0.0);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) brep, Color.SteelBlue);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdSelect()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = devDept.Eyeshot.actionType.SelectVisibleByPickDynamic;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SelectionFilterMode = selectionFilterType.Edge | selectionFilterType.Face;
  }

  public void SelectedIndex(int i)
  {
    F_SheetBendData fSheetBendData = new F_SheetBendData();
    fSheetBendData.spn_angle.Value = 90M;
    fSheetBendData.spn_len.Value = 20M;
    fSheetBendData.spn_rad.Value = 1M;
    int num = (int) fSheetBendData.ShowDialog();
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0 && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0] is Brep)
    {
      Brep entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0] as Brep;
      entity.Rebuild();
      entity.AddFlange(i, (double) fSheetBendData.spn_rad.Value, (double) fSheetBendData.spn_len.Value, Utility.DegToRad((double) fSheetBendData.spn_angle.Value));
      entity.Rebuild();
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdAnalyse()
  {
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0)
    {
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveRange(1, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0] is Brep)
      {
        Brep entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0] as Brep;
        entity.Color = Color.FromArgb(150, entity.Color);
        if (entity.Faces.Length != 0)
        {
          for (int index1 = 0; index1 <= entity.Faces.Length - 1; ++index1)
          {
            if (index1 <= 10)
            {
              Brep.Face face = entity.Faces[index1];
              for (int index2 = 0; index2 <= face.Loops.Length - 1; ++index2)
              {
                List<ICurve> curveList = new List<ICurve>();
                for (int index3 = 0; index3 <= face.Loops[index2].Segments.Length - 1; ++index3)
                {
                  Brep.OrientedEdge segment = face.Loops[index2].Segments[index3];
                  if (segment.CurveIndex >= 0 & segment.CurveIndex <= entity.Edges.Length - 1)
                  {
                    Entity copiedEntity = (Entity) null;
                    buEntity.Copy((Entity) entity.Edges[segment.CurveIndex].Curve, ref copiedEntity);
                    copiedEntity.ColorMethod = colorMethodType.byEntity;
                    copiedEntity.Color = Color.Red;
                    copiedEntity.LineWeight = 4f;
                    copiedEntity.LineWeightMethod = colorMethodType.byEntity;
                    curveList.Add((ICurve) copiedEntity);
                  }
                }
                bool flag = false;
                if (curveList.Count > 0)
                {
                  for (int index4 = 0; index4 <= curveList.Count - 1; ++index4)
                  {
                    if (((Entity) curveList[index4]).GetType() == typeof (Arc))
                      ;
                    if (((Entity) curveList[index4]).GetType() == typeof (Curve))
                      flag = true;
                  }
                  if (flag)
                  {
                    CompositeCurve compositeCurve = new CompositeCurve((IEnumerable<ICurve>) curveList);
                    compositeCurve.ColorMethod = colorMethodType.byEntity;
                    compositeCurve.Color = Color.Red;
                    compositeCurve.LineWeight = 4f;
                    compositeCurve.LineWeightMethod = colorMethodType.byEntity;
                    compositeCurve.LayerName = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[1].Name;
                    compositeCurve.Regen(0.01);
                    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) compositeCurve);
                  }
                }
              }
            }
          }
        }
        if (entity.Edges.Length != 0)
          ;
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdDraw1()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    double num1 = 1.0;
    double radius = 1.0;
    double num2 = 566.0;
    double amount1 = 98.0;
    double height = 88.0;
    double amount2 = 24.0;
    List<ICurve> contours = new List<ICurve>();
    contours.Add((ICurve) new LinearPath(0.0, 0.0, num2, height));
    double x = 50.0;
    Circle circle = new Circle(x, 10.0, 0.0, 4.0);
    contours.Add((ICurve) circle);
    for (int index = 1; index < 9; ++index)
    {
      Entity entity = (Entity) circle.Clone();
      entity.Translate((double) index * (num2 - x * 2.0) / 8.0, 0.0);
      contours.Add((ICurve) entity);
    }
    Brep brep = new devDept.Eyeshot.Entities.Region((IList<ICurve>) contours).ExtrudeAsBrep(-num1, 0.0, 0.0);
    int edgeIndex1 = brep.GetEdgeIndex(new Point3D(0.5, 0.0, 0.0));
    brep.AddFlange(edgeIndex1, radius, amount2, Math.PI / 4.0);
    int num3 = brep.Edges.Length - 1;
    brep.AddFlange(50, radius, amount2, Utility.DegToRad(90.0));
    int edgeIndex2 = brep.GetEdgeIndex(new Point3D(0.0, num1 / 2.0, 0.0));
    brep.AddFlange(edgeIndex2, radius, amount1);
    Plane xy = Plane.XY;
    xy.Translate(0.0, 0.0, radius + amount2 + num1);
    brep.Rebuild(0.01);
    int planarFaceIndex1 = brep.GetPlanarFaceIndex(Plane.XZ, new Point3D(-radius - num1 / 2.0, 0.0, radius + num1 / 2.0));
    int num4 = (int) brep.SubdivideBy(planarFaceIndex1, xy);
    int edgeIndex3 = brep.GetEdgeIndex(new Point3D(-radius, 0.0, amount2 + radius + num1 + num1 / 2.0));
    brep.AddFlange(edgeIndex3, radius, amount2);
    int edgeIndex4 = brep.GetEdgeIndex(new Point3D(num2, num1 / 2.0, 0.0));
    brep.AddFlange(edgeIndex4, radius, amount1);
    brep.Rebuild(0.01);
    int planarFaceIndex2 = brep.GetPlanarFaceIndex(Plane.XZ, new Point3D(num2 + radius + num1 / 2.0, 0.0, amount2 + radius + num1 / 2.0));
    int num5 = (int) brep.SubdivideBy(planarFaceIndex2, xy);
    int edgeIndex5 = brep.GetEdgeIndex(new Point3D(num2 + radius, 0.0, amount2 + radius + num1 * 2.0));
    brep.AddFlange(edgeIndex5, radius, amount2);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) brep, Color.AliceBlue);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public DialogResult cmdShowAndGetPipeLRA(ref List<Entity> Entities, ref List<Block> Blocks)
  {
    try
    {
      if (clsPipeBending.FrmPipeLRA != null)
      {
        if (clsInit.cPipeBend.activeJob == null)
          clsInit.cPipeBend.activeJob = new PipeBendJob();
        if (!clsPipeBending.FrmPipeLRA.Visible)
        {
          clsPipeBending.FrmPipeLRA.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
          clsPipeBending.FrmPipeLRA.pathLRA = buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles;
          PipeBendTempVars._pipeDiameter = clsInit.cPipeBend.activeJob.PipeDiameter;
          clsPipeBending.FrmPipeLRA.BendingList.Clear();
          for (int index = 0; index <= clsInit.cPipeBend.activeJob.BendingList.Count - 1; ++index)
            clsPipeBending.FrmPipeLRA.BendingList.Add(new BendingLRAMaterialData(clsInit.cPipeBend.activeJob.BendingList[index]));
          clsPipeBending.FrmPipeLRA.Job = clsInit.cPipeBend.activeJob;
          clsPipeBending.FrmPipeLRA.Init();
          int num = (int) clsPipeBending.FrmPipeLRA.ShowDialog();
          if (clsPipeBending.FrmPipeLRA.PropertiesForm.Result == DialogResult.OK)
          {
            PipeBendTempVars._numOfFileBlocks = ccVars.SimMachine.MachineParts.Count + 1;
            PipeBendTempVars._pipeDiameter = clsInit.cPipeBend.activeJob.PipeDiameter;
            Entities.Clear();
            Blocks.Clear();
            clsInit.cPipeBend.activeJob.EntityList.Clear();
            clsInit.cPipeBend.activeJob.BlockList.Clear();
            if (clsPipeBending.FrmPipeLRA.viewportPart.Entities.Count > 0)
            {
              for (int index = 1; index <= clsPipeBending.FrmPipeLRA.viewportPart.Blocks.Count - 1; ++index)
              {
                Block block = (Block) clsPipeBending.FrmPipeLRA.viewportPart.Blocks[index].Clone();
                clsInit.cPipeBend.activeJob.BlockList.Add(block);
              }
              for (int index = 0; index <= clsPipeBending.FrmPipeLRA.viewportPart.Entities.Count - 1; ++index)
              {
                Entity entity = (Entity) clsPipeBending.FrmPipeLRA.viewportPart.Entities[index].Clone();
                clsInit.cPipeBend.activeJob.EntityList.Add(entity);
              }
            }
            clsInit.cPipeBend.activeJob.BendingList.Clear();
            for (int index = 0; index <= clsPipeBending.FrmPipeLRA.BendingList.Count - 1; ++index)
              clsInit.cPipeBend.activeJob.BendingList.Add(new BendingLRAMaterialData(clsPipeBending.FrmPipeLRA.BendingList[index]));
            buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles = clsPipeBending.FrmPipeLRA.pathLRA;
            if (PipeBendTempVars._pipeDiameter <= 0.0)
              PipeBendTempVars._pipeDiameter = 10.0;
            PipeBendTempVars._c1 = new Circle(Plane.YZ, PipeBendTempVars._pipeDiameter / 2.0);
            PipeBendTempVars._c1.Reverse();
            return DialogResult.OK;
          }
        }
        else
          clsPipeBending.FrmPipeLRA.Visible = false;
      }
      return DialogResult.None;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
      return DialogResult.None;
    }
  }

  public void cmdShowPipeLRA()
  {
    try
    {
      if (clsPipeBending.FrmPipeLRA == null)
        return;
      if (!clsPipeBending.FrmPipeLRA.Visible)
      {
        clsPipeBending.FrmPipeLRA.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsPipeBending.FrmPipeLRA.pathLRA = buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles;
        PipeBendTempVars._pipeDiameter = clsInit.cPipeBend.activeJob.PipeDiameter;
        clsPipeBending.FrmPipeLRA.BendingList.Clear();
        for (int index = 0; index <= clsInit.cPipeBend.activeJob.BendingList.Count - 1; ++index)
          clsPipeBending.FrmPipeLRA.BendingList.Add(new BendingLRAMaterialData(clsInit.cPipeBend.activeJob.BendingList[index]));
        clsPipeBending.FrmPipeLRA.Init();
        int num = (int) clsPipeBending.FrmPipeLRA.ShowDialog();
        if (clsPipeBending.FrmPipeLRA.PropertiesForm.Result != DialogResult.OK)
          return;
        clsInit.cPipeBend.activeJob.PipeDiameter = PipeBendTempVars._pipeDiameter;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Blocks.Clear();
        if (clsPipeBending.FrmPipeLRA.viewportPart.Entities.Count > 0)
        {
          for (int index = 1; index <= clsPipeBending.FrmPipeLRA.viewportPart.Blocks.Count - 1; ++index)
          {
            Block newItem = (Block) clsPipeBending.FrmPipeLRA.viewportPart.Blocks[index].Clone();
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Blocks.AddOrReplace(newItem);
          }
          for (int index = 0; index <= clsPipeBending.FrmPipeLRA.viewportPart.Entities.Count - 1; ++index)
          {
            Entity entity = (Entity) clsPipeBending.FrmPipeLRA.viewportPart.Entities[index].Clone();
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity);
          }
        }
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
        clsInit.cPipeBend.activeJob.BendingList.Clear();
        for (int index = 0; index <= clsPipeBending.FrmPipeLRA.BendingList.Count - 1; ++index)
          clsInit.cPipeBend.activeJob.BendingList.Add(new BendingLRAMaterialData(clsPipeBending.FrmPipeLRA.BendingList[index]));
        buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles = clsPipeBending.FrmPipeLRA.pathLRA;
        PipeBendTempVars._pipeDiameter = 80.0;
        PipeBendTempVars._c1 = new Circle(Plane.YZ, 40.0);
        PipeBendTempVars._c1.Reverse();
        clsFiles.SaveParameter();
      }
      else
        clsPipeBending.FrmPipeLRA.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdMenuCommand(object sender, EventArgs e)
  {
    switch (sender)
    {
      case System.Windows.Forms.Control _:
        string name1 = (sender as System.Windows.Forms.Control).Name;
        break;
      case ToolStripMenuItem _:
        string name2 = (sender as ToolStripMenuItem).Name;
        break;
    }
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
  }

  public static void SaveLRAFile(string FileName, List<BendingLRAMaterialData> BendingList)
  {
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "<LRAList>");
    for (int index = 0; index <= BendingList.Count - 1; ++index)
      StringList.AddRange((ICollection) BendingList[index].ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList.Add((object) "</LRAList>");
    buFile.SaveToFile(StringList, FileName);
  }

  public static void OpenLRAFile(string FileName, ref List<BendingLRAMaterialData> BendingList)
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      ArrayList StringList = new ArrayList();
      buFile.OpenFromFile(FileName, ref StringList);
      List<List<string>> CalcList = new List<List<string>>();
      buString.ListToSpecificList("<LRAList>", "</LRAList>", true, StringList, ref CalcList);
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        BendingLRAMaterialData bendingLraMaterialData = new BendingLRAMaterialData();
        buSerilization.Decode(CalcList[index], "", SerilizationMode.MultiLine, (object) bendingLraMaterialData);
        BendingList.Add(bendingLraMaterialData);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (OpenLRAFile), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, nameof (OpenLRAFile));
    }
  }

  public void SavePipeBendingFile() => this.SavePipeBendingFile(AppPath.Settings + "\\PipeBend");

  public void SavePipeBendingFile(string Path)
  {
    if (AppBool.MachineMode)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\PipeBend");
      if (directoryInfo.Exists)
        Path = directoryInfo.FullName;
    }
    string FileName = Path + "\\PipeBending.prm";
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "   Pipe Bending Settings");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "<PipeBendingSettings>");
    StringList.AddRange((ICollection) buPipeBendCalc.varPipeBendingSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.Add((object) "</PipeBendingSettings>");
    StringList.Add((object) "<varPipeBendRunSettings>");
    StringList.AddRange((ICollection) buPipeBendCalc.varPipeBendingRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.Add((object) "</varPipeBendRunSettings>");
    StringList.Add((object) "<varPipeBendSettings>");
    StringList.AddRange((ICollection) buPipeBendCalc.varPipeBendingProgramSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
    StringList.Add((object) "</varPipeBendSettings>");
    StringList.Add((object) "<DiskAndBlocksList>");
    StringList.AddRange((ICollection) PipeBendDiskBlocks.ToDef(buPipeBendCalc.DiskBlocks, "", 2));
    StringList.Add((object) "</DiskAndBlocksList>");
    buFile.SaveToFile(StringList, FileName);
    buLog.addLog("Pipe Bending Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
  }

  public void OpenPipeBendingFile() => this.OpenPipeBendingFile(AppPath.Settings + "\\PipeBend");

  public void OpenPipeBendingFile(string Path)
  {
    try
    {
      if (AppBool.MachineMode)
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\PipeBend");
        if (directoryInfo.Exists)
          Path = directoryInfo.FullName;
      }
      ArrayList StringList = new ArrayList();
      FileInfo fileInfo = new FileInfo(Path + "\\PipeBending.prm");
      if (fileInfo.Exists)
      {
        StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        try
        {
          ArrayList CalcList1 = new ArrayList();
          buString.ListToSpecificList("<PipeBendingSettings>", "</PipeBendingSettings>", true, StringList, ref CalcList1);
          if (CalcList1.Count > 0)
          {
            buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) buPipeBendCalc.varPipeBendingSettings);
            buLog.addLog("Pipe Bending Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          ArrayList CalcList2 = new ArrayList();
          buString.ListToSpecificList("<varPipeBendRunSettings>", "</varPipeBendRunSettings>", true, StringList, ref CalcList2);
          if (CalcList2.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buPipeBendCalc.varPipeBendingRunSettings);
            buLog.addLog("varPipeBendRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          ArrayList CalcList3 = new ArrayList();
          buString.ListToSpecificList("<varPipeBendSettings>", "</varPipeBendSettings>", true, StringList, ref CalcList3);
          if (CalcList3.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) buPipeBendCalc.varPipeBendingProgramSettings);
            buLog.addLog("varPipeBendSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Pipe Bending Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Laser Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Pipe Bending Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Pipe Bending Settings File Missing");
      }
      buLog.addLog("Pipe Bending Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      List<string> CalcList = new List<string>();
      buStatics.ListToSpecificList("<DiskAndBlocksList>", "</DiskAndBlocksList>", false, StringList, ref CalcList);
      if (CalcList.Count > 0)
        PipeBendDiskBlocks.Decode(CalcList, ref buPipeBendCalc.DiskBlocks);
      if (buPipeBendCalc.DiskBlocks.Count != 0)
        return;
      buPipeBendCalc.DiskBlocks.Add(new PipeBendDiskBlocks());
    }
    catch (Exception ex)
    {
      buLog.addLog("Pipe Bending Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Pipe Bending Settings Decoder Error");
    }
  }

  public bool isReverseAngle(Plane refPlane)
  {
    return !buVector5.isPlaneXZ(refPlane) && (buVector5.isPlaneZX(refPlane) || !buVector5.isPlaneYZ(refPlane) && (buVector5.isPlaneZY(refPlane) || !buVector5.isPlaneXY(refPlane) && (buVector5.isPlaneYX(refPlane) || buCompare5.EQ(refPlane.Equation.X, 0.0, 0.1) & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1) & refPlane.Equation.Z < 0.0 || !(buCompare5.EQ(refPlane.Equation.X, 0.0, 0.1) & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1) & refPlane.Equation.Z < 0.0) && !(buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1) & buCompare5.EQ(refPlane.Equation.Z, 0.0, 0.1) & refPlane.Equation.X < 0.0) && !(buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.2) & buCompare5.EQ(refPlane.Equation.Z, 0.0, 0.2) & refPlane.Equation.X > 0.0) && (refPlane.Equation.X < 0.0 & refPlane.Equation.Z < 0.0 & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1) || !(refPlane.Equation.X < 0.0 & refPlane.Equation.Y < 0.0 & buCompare5.EQ(refPlane.Equation.Z, 0.0, 0.1)) && !(refPlane.Equation.X > 0.0 & refPlane.Equation.Z < 0.0 & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1)) && refPlane.Equation.X > 0.0 & refPlane.Equation.Y > 0.0 & refPlane.Equation.Z > 0.0))));
  }

  public void doWireframeToLRAList(
    List<buEntity> refEntities,
    ref List<BendingLRAMaterialData> LRAList)
  {
    if (LRAList == null)
      LRAList = new List<BendingLRAMaterialData>();
    LRAList.Clear();
    clsInit.cPipeBend.activeJob.AuxEntityList.Clear();
    if (refEntities.Count <= 0)
      return;
    Plane plane1 = (Plane) null;
    Vector3D Vec1 = (Vector3D) null;
    for (int index = 0; index <= refEntities.Count - 1; ++index)
    {
      buEntity refEntity = refEntities[index];
      double num1 = 0.0;
      double num2 = 0.0;
      List<Point3D> point3DList = new List<Point3D>();
      List<Point3D> copiedPoint1 = new List<Point3D>();
      List<Point3D> copiedPoint2 = new List<Point3D>();
      buVector5.Copy(refEntities[index].Vertices, ref point3DList);
      if (refEntities[index].sortDirection == entitySortDirection.Reverse)
        point3DList.Reverse();
      if (index > 0)
      {
        buVector5.Copy(refEntities[index - 1].Vertices, ref copiedPoint2);
        if (refEntities[index - 1].sortDirection == entitySortDirection.Reverse)
          copiedPoint2.Reverse();
      }
      if (index < refEntities.Count - 1)
      {
        buVector5.Copy(refEntities[index + 1].Vertices, ref copiedPoint1);
        if (refEntities[index + 1].sortDirection == entitySortDirection.Reverse)
          copiedPoint1.Reverse();
      }
      clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
      PlaneAngle planeAngle1 = new PlaneAngle();
      PlaneAngle planeAngle2 = new PlaneAngle();
      Vector3D vector3D1 = new Vector3D(point3DList[0], point3DList[1]);
      if (copiedPoint2.Count > 0)
        ;
      Vector3D vector3D2 = new Vector3D(point3DList[point3DList.Count - 1], point3DList[point3DList.Count - 2]);
      if (copiedPoint1.Count > 0)
        ;
      Vector3D vector3D3 = Vector3D.Cross(vector3D1, vector3D2);
      clsInit.cVector5.VectorAngle(vector3D1, ref planeAngle1.AngleXY, ref planeAngle1.AngleXZ, ref planeAngle1.AngleYZ);
      clsInit.cVector5.VectorAngle(vector3D2, ref planeAngle2.AngleXY, ref planeAngle2.AngleXZ, ref planeAngle2.AngleYZ);
      Plane plane2 = new Plane(point3DList[0], vector3D1);
      Plane plane3 = new Plane(point3DList[point3DList.Count - 1], vector3D2);
      buArc buArc = (buArc) null;
      bool flag = false;
      if (refEntity is buArc)
      {
        buArc = refEntity as buArc;
        flag = this.isReverseAngle(buArc.Plane);
      }
      if (vector3D3.Length > 0.0)
      {
        Plane plane4 = new Plane(vector3D3);
        Utility.VectorsAngle(vector3D2, vector3D1, plane4);
        if (refEntity is buArc)
        {
          if (copiedPoint2.Count > 0)
          {
            if (buArc.sortDirection == entitySortDirection.Normal)
            {
              if (buCompare5.EQ(buArc.StartPoint, copiedPoint2[copiedPoint2.Count - 1]))
                num1 = buArc.StartAngle - buArc.EndAngle;
              else if (buCompare5.EQ(buArc.EndPoint, copiedPoint2[copiedPoint2.Count - 1]))
                num1 = buArc.EndAngle - buArc.StartAngle;
            }
            else if (buCompare5.EQ(buArc.StartPoint, copiedPoint2[copiedPoint2.Count - 1]))
              num1 = buArc.StartAngle - buArc.EndAngle;
            else if (buCompare5.EQ(buArc.EndPoint, copiedPoint2[copiedPoint2.Count - 1]))
              num1 = buArc.EndAngle - buArc.StartAngle;
            if (flag)
              num1 = -num1;
          }
          else
            num1 = refEntity.sortDirection != entitySortDirection.Normal ? buArc.StartAngle - buArc.EndAngle : buArc.EndAngle - buArc.StartAngle;
        }
      }
      if (Vec1 != (Vector3D) null && vector3D3.Length > 0.0 & Vec1.Length > 0.0)
      {
        int Count1 = 0;
        int Count2 = 0;
        clsInit.cVector5.HowManyVectorAxesDifferentThenZero(vector3D3, ref Count1);
        clsInit.cVector5.HowManyTwoVectorAxesDifferentThenZero(Vec1, vector3D3, ref Count2);
        if (Count2 >= 2 & buArc != null)
        {
          num2 = this.PlaneToPlaneDirection((Vector3D) plane1.Equation, (Vector3D) buArc.Plane.Equation) * clsPipeBending.AngleBetweenPlanes(plane1, buArc.Plane);
          clsPipeBending.AngleBetweenPlanes((Vector3D) plane1.Equation, (Vector3D) buArc.Plane.Equation);
          if (copiedPoint2.Count > 0)
            ;
        }
      }
      if (refEntities[index] is buLinearPath && refEntities[index].Vertices.Count == 2)
        LRAList.Add(new BendingLRAMaterialData()
        {
          Length = Math.Round(clsInit.cVector5.Length3D(refEntities[index].Vertices), 3)
        });
      if (refEntities[index] is buLine)
      {
        if (refEntities[index].Vertices.Count == 2)
          LRAList.Add(new BendingLRAMaterialData()
          {
            Length = Math.Round(clsInit.cVector5.Length3D(refEntities[index].Vertices), 3)
          });
      }
      else if (refEntities[index] is buArc)
      {
        if (!buCompare5.EQ(num2, 0.0, 0.01))
          LRAList.Add(new BendingLRAMaterialData()
          {
            Rotation = Math.Round(num2, 3)
          });
        Plane plane5 = (Plane) ((buArc) refEntities[index]).Plane.Clone();
        plane1 = (Plane) ((buArc) refEntities[index]).Plane.Clone();
        LRAList.Add(new BendingLRAMaterialData()
        {
          Angle = Math.Round(num1, 3),
          Radius = Math.Round(((buArc) refEntities[index]).Radius)
        });
      }
      else if (refEntities[index] is buArc)
        ;
      if (vector3D3.Length > 0.0)
        Vec1 = Vector3D.Cross(vector3D1, vector3D2);
    }
  }

  public double PlaneToPlaneDirection(Vector3D normal1, Vector3D normal2)
  {
    double planeDirection = 1.0;
    if (buVector5.isVectorYMinus(normal1) & buVector5.isVectorXPlus(normal2))
      planeDirection = 1.0;
    else if (buVector5.isVectorXPlus(normal1) & buVector5.isVectorZMinus(normal2))
      planeDirection = -1.0;
    else if (buVector5.isVectorXMinus(normal1) & buVector5.isVectorYPlus(normal2))
      planeDirection = 1.0;
    else if (buVector5.isVectorZMinus(normal1) & buVector5.isVectorXMinus(normal2))
      planeDirection = -1.0;
    else if (buVector5.isVectorZMinus(normal1) & buCompare5.EQ(normal2.Z, 0.0) & normal2.X > 0.0 & normal2.Y > 0.0)
      planeDirection = -1.0;
    else if (buCompare5.EQ(normal1.Z, 0.0) & normal1.X < 0.0 & normal1.Y < 0.0 & buVector5.isVectorZMinus(normal2))
      planeDirection = -1.0;
    else if (buVector5.isVectorYPlus(normal1) & buCompare5.EQ(normal2.Y, 0.0) & normal2.X < 0.0 & normal2.Z < 0.0)
      planeDirection = 1.0;
    else if (buCompare5.EQ(normal1.Y, 0.0) & normal1.X < 0.0 & normal1.Z < 0.0 & buVector5.isVectorYMinus(normal2))
      planeDirection = 1.0;
    else if (buCompare5.EQ(normal1.Y, 0.0) & normal1.X < 0.0 & normal1.Z > 0.0 & normal2.X < 0.0 & normal2.Y < 0.0 & normal2.Z > 0.0)
      planeDirection = -1.0;
    else if ((!(normal1.X > 0.0 & normal1.Y > 0.0 & normal1.Z > 0.0 & buCompare5.EQ(normal2.Y, 0.0) & normal2.X < 0.0) ? 0 : (normal2.Z > 0.0 ? 1 : 0)) != 0)
      planeDirection = 1.0;
    return planeDirection;
  }

  public static double AngleBetweenPlanes(Plane plane1, Plane plane2)
  {
    Vector3D equation1 = (Vector3D) plane1.Equation;
    Vector3D equation2 = (Vector3D) plane2.Equation;
    double d = Vector3D.Dot(equation1, equation2) / (equation1.Length * equation2.Length);
    if (d < -1.0)
      d = -1.0;
    if (d > 1.0)
      d = 1.0;
    double num = Math.Acos(d) * (180.0 / Math.PI);
    return num > 90.0 ? 180.0 - num : num;
  }

  public static double AngleBetweenPlanes(Vector3D normal1, Vector3D normal2)
  {
    double d = Vector3D.Dot(normal1, normal2) / (normal1.Length * normal2.Length);
    if (d < -1.0)
      d = -1.0;
    if (d > 1.0)
      d = 1.0;
    double num = Math.Acos(d) * (180.0 / Math.PI);
    return num > 90.0 ? 180.0 - num : num;
  }

  public void doGetFromSolid(Entity entPipe, ref List<buEntity> EL, ref double PipeDiameter)
  {
    EL.Clear();
    List<buEntity> BaseRefEntities = new List<buEntity>();
    List<Entity> entityList = new List<Entity>();
    if (entPipe is Brep)
    {
      Brep brep = entPipe as Brep;
      brep.Color = Color.FromArgb(150, brep.Color);
      if (brep.Faces.Length != 0)
      {
        for (int index1 = 0; index1 <= brep.Faces.Length - 1; ++index1)
        {
          if (index1 <= brep.Faces.Length - 1)
          {
            Brep.Face face = brep.Faces[index1];
            List<ICurve> curveList = new List<ICurve>();
            for (int index2 = 0; index2 <= face.Loops.Length - 1; ++index2)
            {
              for (int index3 = 0; index3 <= face.Loops[index2].Segments.Length - 1; ++index3)
              {
                Brep.OrientedEdge segment = face.Loops[index2].Segments[index3];
                if (segment.CurveIndex >= 0 & segment.CurveIndex <= brep.Edges.Length - 1)
                {
                  Entity copiedEntity = (Entity) null;
                  buEntity.Copy((Entity) brep.Edges[segment.CurveIndex].Curve, ref copiedEntity);
                  copiedEntity.ColorMethod = colorMethodType.byEntity;
                  copiedEntity.Color = Color.Red;
                  copiedEntity.LineWeight = 4f;
                  copiedEntity.LineWeightMethod = colorMethodType.byEntity;
                  curveList.Add((ICurve) copiedEntity);
                }
              }
            }
            Surface[] surface = face.Surface.GetSurface((IList<ICurve>) curveList);
            AnalyticSurf extended = face.Surface.GetExtended((IList<ICurve>) curveList);
            bool flag = false;
            if ((surface == null ? 0 : (surface.Length != 0 ? 1 : 0)) != 0)
            {
              if (surface[0] is CylindricalSurface)
              {
                Entity E = (Entity) null;
                double MinDiameter = 0.0;
                double MaxDiameter = 0.0;
                this.doGetCylindricalSurface(surface[0], curveList, ref E, ref MinDiameter, ref MaxDiameter);
                if (E != null)
                {
                  if (MaxDiameter > 0.0)
                    PipeDiameter = MaxDiameter;
                  buEntity checkEntity = buEntity.Copy(E);
                  if (!clsInit.cVector5.isEntitySame(BaseRefEntities, checkEntity))
                    BaseRefEntities.Add(checkEntity);
                  flag = true;
                }
              }
              else if (surface[0] is ToroidalSurface)
              {
                Entity E = (Entity) null;
                this.doGetToroidalSurface(surface[0], curveList, ref E);
                if (E != null)
                {
                  entityList.Add(E);
                  buEntity checkEntity = buEntity.Copy(E);
                  if (!clsInit.cVector5.isEntitySame(BaseRefEntities, checkEntity))
                    BaseRefEntities.Add(checkEntity);
                  flag = true;
                }
              }
              else if (surface[0] is PlanarSurface)
              {
                for (int index4 = 0; index4 <= curveList.Count - 1; ++index4)
                {
                  if (curveList[index4] is Arc)
                    ;
                  flag = true;
                }
              }
            }
            if (extended != null & !flag && extended is ToroidalSurf)
            {
              Entity E = (Entity) null;
              this.doGetToroidalSurface(extended, curveList, ref E);
              if (E != null)
              {
                entityList.Add(E);
                buEntity checkEntity = buEntity.Copy(E);
                if (!clsInit.cVector5.isEntitySame(BaseRefEntities, checkEntity))
                  BaseRefEntities.Add(checkEntity);
              }
            }
          }
        }
      }
      if (brep.Edges.Length != 0)
      {
        for (int index = 0; index <= brep.Edges.Length - 1; ++index)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy((Entity) brep.Edges[index].Curve, ref copiedEntity);
        }
      }
    }
    if (entityList.Count > 0)
      ;
    if (BaseRefEntities.Count <= 0)
      return;
    SortbuSettings Settings = new SortbuSettings();
    Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    for (int index = 0; index <= BaseRefEntities.Count - 1; ++index)
    {
      List<buEntity> SortedEntities = new List<buEntity>();
      clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[index].StartPoint, ref BaseRefEntities, Settings, ref SortedEntities);
      List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      if (SplitedEntitites.Count == 1)
      {
        buEntity.Copy(SortedEntities, ref EL);
        index = BaseRefEntities.Count;
      }
    }
    if (EL.Count != 0)
      return;
    for (int index = 0; index <= BaseRefEntities.Count - 1; ++index)
    {
      List<buEntity> SortedEntities = new List<buEntity>();
      clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[index].EndPoint, ref BaseRefEntities, Settings, ref SortedEntities);
      List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      if (SplitedEntitites.Count == 1)
      {
        buEntity.Copy(SortedEntities, ref EL);
        index = BaseRefEntities.Count;
      }
    }
  }

  public void doGetCylindricalSurface(
    Surface S,
    List<ICurve> IC,
    ref Entity E,
    ref double MinDiameter,
    ref double MaxDiameter)
  {
    if (!(S is CylindricalSurface))
      return;
    List<Point3D> Points = new List<Point3D>();
    MinDiameter = 999999999.0;
    MaxDiameter = -999999999.0;
    double num1 = 0.0;
    for (int index = 0; index <= IC.Count - 1; ++index)
    {
      if (IC[index] is Circle)
      {
        Points.Add(buVector5.ToPoint3D(((Circle) IC[index]).Center));
        if (((Circle) IC[index]).Radius * 2.0 > MaxDiameter)
          MaxDiameter = ((Circle) IC[index]).Radius * 2.0;
        if (((Circle) IC[index]).Radius * 2.0 < MinDiameter)
          MinDiameter = ((Circle) IC[index]).Radius * 2.0;
      }
      if (IC[index] is Line)
      {
        num1 = IC[index].Length();
        double num2 = IC[index].EndPoint.X - IC[index].StartPoint.X;
        double num3 = IC[index].EndPoint.Y - IC[index].StartPoint.Y;
        double num4 = IC[index].EndPoint.Z - IC[index].StartPoint.Z;
      }
    }
    Point3D point3D1 = new Point3D(((RevolvedSurface) S).Center.X, ((RevolvedSurface) S).Center.Y, ((RevolvedSurface) S).Center.Z);
    Point3D point3D2 = new Point3D();
    point3D2.X = ((RevolvedSurface) S).Center.X + num1 * ((RevolvedSurface) S).Axis.X;
    point3D2.Y = ((RevolvedSurface) S).Center.Y + num1 * ((RevolvedSurface) S).Axis.Y;
    point3D2.Z = ((RevolvedSurface) S).Center.Z + num1 * ((RevolvedSurface) S).Axis.Z;
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
    if (Points.Count >= 2 && Points[0] == Points[Points.Count - 1])
      Points.RemoveAt(Points.Count - 1);
    if (Points.Count == 1)
    {
      Point3D point3D3 = new Point3D(Points[0].X + num1 * ((RevolvedSurface) S).Axis.X, Points[0].Y + num1 * ((RevolvedSurface) S).Axis.Y, Points[0].Z + num1 * ((RevolvedSurface) S).Axis.Z);
    }
    if (Points.Count < 2)
      return;
    E = (Entity) new LinearPath((ICollection<Point3D>) Points);
    E.ColorMethod = colorMethodType.byEntity;
    E.Color = Color.Red;
    E.LineWeight = 4f;
    E.LineWeightMethod = colorMethodType.byEntity;
  }

  public void doGetToroidalSurface(AnalyticSurf S, List<ICurve> IC, ref Entity E)
  {
    ToroidalSurf toroidalSurf = S as ToroidalSurf;
    Point3D center = (Point3D) null;
    Arc arc1 = (Arc) null;
    for (int index = 0; index <= IC.Count - 1; ++index)
    {
      if (IC[index] is Arc)
      {
        Arc arc2 = IC[index] as Arc;
        if (buCompare5.EQ(arc2.Radius, toroidalSurf.MajorRadius + toroidalSurf.MinorRadius, 0.1))
        {
          center = buVector5.ToPoint3D(arc2.Center);
          arc1 = arc2;
        }
      }
    }
    if (!(center != (Point3D) null & arc1 != null))
      return;
    E = (Entity) new Arc(arc1.Plane, center, toroidalSurf.MajorRadius, arc1.StartPoint, arc1.EndPoint, false);
    E.ColorMethod = colorMethodType.byEntity;
    E.Color = Color.Red;
    E.LineWeight = 4f;
    E.LineWeightMethod = colorMethodType.byEntity;
  }

  public void doGetToroidalSurface(Surface S, List<ICurve> IC, ref Entity E)
  {
    ToroidalSurface toroidalSurface = S as ToroidalSurface;
    Point3D center = (Point3D) null;
    Arc arc1 = (Arc) null;
    for (int index = 0; index <= IC.Count - 1; ++index)
    {
      if (IC[index] is Arc)
      {
        Arc arc2 = IC[index] as Arc;
        if (buCompare5.EQ(arc2.Radius, toroidalSurface.MajorRadius + toroidalSurface.MinorRadius, 0.1))
        {
          center = buVector5.ToPoint3D(arc2.Center);
          arc1 = arc2;
        }
      }
    }
    if (!(center != (Point3D) null & arc1 != null))
      return;
    E = (Entity) new Arc(arc1.Plane, center, toroidalSurface.MajorRadius, arc1.StartPoint, arc1.EndPoint, false);
    E.ColorMethod = colorMethodType.byEntity;
    E.Color = Color.Red;
    E.LineWeight = 4f;
    E.LineWeightMethod = colorMethodType.byEntity;
  }

  public void doCreateCodes(ref PipeBendJob Item)
  {
    try
    {
      if (Item != null)
      {
        PipeBendSimulationMove bendSimulationMove1 = new PipeBendSimulationMove();
        Item.SimMoves.Clear();
        double YPos = 0.0;
        double num1 = 0.0;
        double ZPos = 0.0;
        double num2 = 0.0;
        double num3 = 0.0;
        double num4 = -999999.0;
        this.doAddBendList(ref Item, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0, false, false);
        int num5 = 0;
        for (int index1 = 0; index1 <= Item.BendingList.Count - 1; ++index1)
        {
          PipeBendSimulationMove bendSimulationMove2 = new PipeBendSimulationMove();
          double num6 = 0.0;
          double radius = Item.BendingList[index1].Radius;
          for (int index2 = index1 + 1; index2 <= Item.BendingList.Count - 1; ++index2)
          {
            if (Item.BendingList[index2].Radius > 0.0)
            {
              num6 = Item.BendingList[index2].Radius;
              index2 = Item.BendingList.Count;
            }
          }
          if (radius == 0.0)
          {
            if (num6 >= 300.0)
            {
              ZPos = 0.0;
              num5 = 0;
            }
            else if (num6 >= 200.0 & num6 < 300.0)
            {
              ZPos = -75.0;
              num5 = 1;
            }
            else
            {
              ZPos = -155.0;
              num5 = 2;
            }
            if (ZPos != num4)
            {
              num1 = 0.0;
              YPos = -50.0;
              this.doAddBendList(ref Item, 0.0, YPos, Item.SimMoves[Item.SimMoves.Count - 1].ZPos, num2, num3, 0.0, 0.0, num1, 0.0, 0.0, index1, false, true);
              this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, num1, 0.0, 0.0, index1, false, true);
              if (num5 == 0)
                YPos = 0.0;
              if (num5 == 1)
                YPos = 50.0;
              if (num5 == 2)
                YPos = 100.0;
              this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, num1, 0.0, 0.0, index1, false, true);
            }
          }
          if (Item.BendingList[index1].Angle > 0.0)
          {
            if (num5 == 0)
              num1 = -150.0;
            if (num5 == 1)
              num1 = -100.0;
            if (num5 == 2)
              num1 = -50.0;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, num1, 0.0, 0.0, index1, false, true);
            double CPos = -Item.BendingList[index1].Angle;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, CPos, Item.BendingList[index1].Angle, 0.0, 0.0, num1, Item.BendingList[index1].Radius, index1, true, true);
            num3 = 0.0;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, 0.0, num1, Item.BendingList[index1].Radius, index1, false, true);
            num1 = 0.0;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, 0.0, num1, Item.BendingList[index1].Radius, index1, false, true);
          }
          else if (Item.BendingList[index1].Angle < 0.0)
          {
            if (num5 == 0)
              num1 = -150.0;
            if (num5 == 1)
              num1 = -100.0;
            if (num5 == 2)
              num1 = -50.0;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 180.0, num1, 0.0, 0.0, index1, true, false);
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, num1, 0.0, 0.0, index1, false, true);
            double angle = Item.BendingList[index1].Angle;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, angle, -Item.BendingList[index1].Angle, 0.0, 0.0, num1, Item.BendingList[index1].Radius, index1, true, false);
            num3 = 0.0;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, 0.0, num1, Item.BendingList[index1].Radius, index1, false, true);
            num1 = 0.0;
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, 0.0, 0.0, num1, Item.BendingList[index1].Radius, index1, false, true);
          }
          if (Item.BendingList[index1].Rotation > 0.0)
            this.doAddBendList(ref Item, 0.0, YPos, ZPos, num2, num3, 0.0, Item.BendingList[index1].Rotation, num1, 0.0, 0.0, index1, true, false);
          if (Item.BendingList[index1].Length > 0.0)
            this.doAddBendList(ref Item, Item.BendingList[index1].Length, YPos, ZPos, num2, num2, num3, 0.0, num1, 0.0, 0.0, index1, true, true);
          num4 = ZPos;
        }
      }
      this.doAddBendList(ref Item, -100.0, Item.SimMoves[Item.SimMoves.Count - 1].YPos, Item.SimMoves[Item.SimMoves.Count - 1].ZPos, Item.SimMoves[Item.SimMoves.Count - 1].APos, Item.SimMoves[Item.SimMoves.Count - 1].CPos, Item.SimMoves[Item.SimMoves.Count - 1].BendPos, Item.SimMoves[Item.SimMoves.Count - 1].RotatePos, Item.SimMoves[Item.SimMoves.Count - 1].YPreasurePos, Item.SimMoves[Item.SimMoves.Count - 1].XBendingPos, 0.0, Item.SimMoves[Item.SimMoves.Count - 1].IndexMove, false, true);
      buUserSimVariables.indexSim = 0;
    }
    catch (Exception ex)
    {
    }
  }

  public void doAddBendList(
    ref PipeBendJob Item,
    double XPos,
    double YPos,
    double ZPos,
    double APos,
    double CPos,
    double BendAngle,
    double Rotation,
    double YPreasure,
    double XBending,
    double Radius,
    int Index,
    bool MovePipe,
    bool Devide)
  {
    if (Item.SimMoves.Count == 0)
    {
      PipeBendSimulationMove bendSimulationMove = new PipeBendSimulationMove(XPos, YPos, ZPos, APos, CPos, BendAngle, Rotation, YPreasure, XBending, Radius, MovePipe, 0, PipeBendMoveCommand.None);
      Item.SimMoves.Add(bendSimulationMove);
    }
    else
    {
      double xpos = XPos;
      PipeBendSimulationMove bendSimulationMove1 = new PipeBendSimulationMove(xpos, YPos, ZPos, APos, CPos, BendAngle, Rotation, YPreasure, XBending, Radius, MovePipe, Index, PipeBendMoveCommand.None);
      bendSimulationMove1.ExecutedPipe = Item.SimMoves[Item.SimMoves.Count - 1].ExecutedPipe;
      if (PipeBendSimulationMove.EQ(bendSimulationMove1, Item.SimMoves[Item.SimMoves.Count - 1]))
        return;
      if (Devide)
      {
        List<PipeBendSimulationMove> devidedPoints = new List<PipeBendSimulationMove>();
        clsInit.cPipeBend.SimulationPointDevide(Item.SimMoves[Item.SimMoves.Count - 1], bendSimulationMove1, 0.0, 10, Item.SimMoves[Item.SimMoves.Count - 1].ExecutedPipe, ref devidedPoints);
        if (devidedPoints.Count > 0)
        {
          for (int index = 0; index <= devidedPoints.Count - 1; ++index)
          {
            PipeBendSimulationMove bendSimulationMove2 = new PipeBendSimulationMove(devidedPoints[index]);
            Item.SimMoves.Add(bendSimulationMove2);
          }
        }
        else
          Item.SimMoves.Add(new PipeBendSimulationMove(xpos, YPos, ZPos, APos, CPos, BendAngle, Rotation, YPreasure, XBending, Radius, MovePipe, Index, PipeBendMoveCommand.None)
          {
            ExecutedPipe = Item.SimMoves[Item.SimMoves.Count - 1].ExecutedPipe
          });
      }
      else
        Item.SimMoves.Add(bendSimulationMove1);
    }
  }
}
