// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Drill.clsDrill
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Editor;
using buCadCamResVer5.Library;
using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Drawings;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Progress;
using buCore;
using buDialogExtenders;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.Shape;
using buEyeBaseVer5.Variables;
using buMutliTextbox;
using buMW.Variables;
using devDept;
using devDept.Eyeshot;
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
using System.Windows.Forms;
using System.Xml;

#nullable disable
namespace buCadCamResVer5.Drill;

public class clsDrill
{
  public static DrillTempVars varTemps = new DrillTempVars();
  public static DrillSettings varDrillSettings = new DrillSettings();
  public static List<ToolBase5> toolTops = new List<ToolBase5>();
  public static List<ToolBase5> toolBottoms = new List<ToolBase5>();
  public static DrillMachineSettings varDrillMachineSettings = new DrillMachineSettings();
  public static DrillCNCSettings varDrillCNCSettings = new DrillCNCSettings();
  public static DrillRuntimeSettings varDrillRunSettings = new DrillRuntimeSettings();
  public static string fileNameToolSetting = "C:\\";
  public static List<ToolBase5> ToolList = new List<ToolBase5>();
  public static ToolBase5 toolTop = new ToolBase5();
  public static ToolBase5 toolBottom = new ToolBase5();
  public static ToolBase5 toolSlotY1 = new ToolBase5();
  public static ToolBase5 toolSlotY2 = new ToolBase5();
  public static double[] ToolPistonDownPos = new double[300];
  public static DrillJob activeJob = (DrillJob) null;
  public static List<DrillJob> JobList = (List<DrillJob>) null;
  public static List<DrillJob> JobStoredList = (List<DrillJob>) null;
  public buCadCamResVer5.DialogBoxx.OpenFileDialogBoxPreview openDialogCtrlPreview = new buCadCamResVer5.DialogBoxx.OpenFileDialogBoxPreview();
  private OpenFileDialog openFileDialog_0 = new OpenFileDialog();
  public DrillMachineType MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;
  public List<string> FilesERP = new List<string>();
  public clsDrillGoUltra2Up1Down cGoUltra2Up1Down = (clsDrillGoUltra2Up1Down) null;
  public clsDrillGoAtc cGoAtc = (clsDrillGoAtc) null;
  public clsDrillSirius cGoSirius = (clsDrillSirius) null;
  public static List<int> SimMovePartIndex = new List<int>();
  public static List<Entity> SimToCollsionCheck1 = new List<Entity>();
  public static List<Entity> SimToCollsionCheck2 = new List<Entity>();
  public bool isCollisionRunning = false;
  public bool EditOperation = false;
  public int indexSim = -1;
  public int indexCollision = -1;
  public int Sing = -1;
  public int IDCounter = 0;
  public int IDIndex = 1;
  public int GroupIndex = 1;
  public int selectedJobIndex = -1;
  public int selectedItemIndex = -1;
  public int selectedItemSubIndex = -1;
  public int entityIndex = -1;
  public double NoMove = 100000.0;
  public double NoMoveX1 = 100000.0;
  public double NoMoveX2 = 100000.0;
  public double NoMoveY1 = 100000.0;
  public double NoMoveY2 = 100000.0;
  public double NoMoveY3 = 100000.0;
  public double NoMoveZ1 = 100000.0;
  public double NoMoveZ2 = 100000.0;
  public double NoMoveZ3 = 100000.0;
  public double X1ClamperZOffset = 0.0;
  public double X2ClamperZOffset = 0.0;
  public Plane planeActive = Plane.XY;
  private static CollisionDetection collisionDetection_0;
  public F_DrillMachSim frmMachSim = (F_DrillMachSim) null;
  public F_DrillEdit frmEdit = (F_DrillEdit) null;
  public F_DrillEdit frmList = (F_DrillEdit) null;
  public F_Tools FrmTools = (F_Tools) null;
  public F_CabinetCycle FrmCabinetCycle = (F_CabinetCycle) null;
  public Timer timNew = new Timer();
  public Mesh ClamperEntity = (Mesh) null;
  public DrillSplitedItems SplitedItems = new DrillSplitedItems();
  public List<string> calcErrorList = new List<string>();
  public List<string> operationErrorList = new List<string>();
  public List<DrillFound> FoundDrills = new List<DrillFound>();
  public List<List<DrillCalcItem>> ItemSplited = new List<List<DrillCalcItem>>();
  public DrillCalcItem LastCalcItem = (DrillCalcItem) null;
  public string fileNameActual = "";
  public string fileNameCabinerCycle = "";
  private bool bool_0 = false;
  private Point3D point3D_0;
  private Point3D point3D_1;
  private Point3D point3D_2;
  private DrillRuntimeSettings drillRuntimeSettings_0 = (DrillRuntimeSettings) null;
  private ShapeRuntimeData shapeRuntimeData_0 = (ShapeRuntimeData) null;
  private List<Entity> list_0 = new List<Entity>();
  public static Design viewportAuto = (Design) null;
  public static Design viewportEdit = (Design) null;
  public static Design viewportList = (Design) null;
  public List<string> cmdExceptionID = new List<string>();
  public Timer timSim = (Timer) null;
  public Timer timCabinetCycle = (Timer) null;
  public Timer timCabinetStartCycle = (Timer) null;
  public Point3D pntCenter = new Point3D();
  public Point3D pntTarget = new Point3D();
  public List<Point3D> pntList = new List<Point3D>();
  public int indx = 0;
  public double AngleTot = 0.0;
  public Timer timm = (Timer) null;
  public Point3D pntMove = new Point3D();
  private List<buEntity> list_1 = new List<buEntity>();

  public void Init()
  {
    buMWDrillVars.Init();
    this.openDialogCtrlPreview.FileSelect += new buCadCamResVer5.DialogBoxx.OpenFileDialogBoxPreview.SelectFile(this.OpenFilePreview);
    this.timSim = new Timer();
    this.timSim.Tick += new EventHandler(this.tick_Simulation);
    string str = AppPath.Settings + "\\Drill\\";
    if (clsVar.appModes_0.DrillMode.GoUltra)
    {
      this.MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;
      str += "\\GoUltra2Up1Down\\";
    }
    if (clsVar.appModes_0.DrillMode.Go)
    {
      this.MachType = DrillMachineType.GoWithAtc;
      str += "\\GoAtc\\";
    }
    if (clsVar.appModes_0.DrillMode.Sirius)
    {
      this.MachType = DrillMachineType.Sirius;
      str += "\\Sirius\\";
    }
    this.OpenDrillFile();
    if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
    {
      clsDrill.fileNameToolSetting = str + "ToolsSettingsGoUltra.prm";
      clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\MachineGoUltra.bumachdef", ref ccVars.SimMachine);
      this.MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;
      this.cGoUltra2Up1Down = new clsDrillGoUltra2Up1Down();
    }
    if (this.MachType == DrillMachineType.GoWithAtc)
    {
      clsDrill.fileNameToolSetting = str + "ToolsSettingsGo.prm";
      clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\MachineGo.bumachdef", ref ccVars.SimMachine, new MachineConfigSettings()
      {
        PartTypeInfo = "Clamper",
        PartTypeAdder = clsDrill.varDrillMachineSettings.ClamperVersion
      });
      this.MachType = DrillMachineType.GoWithAtc;
      this.cGoAtc = new clsDrillGoAtc();
    }
    if (this.MachType == DrillMachineType.Sirius)
    {
      clsDrill.fileNameToolSetting = str + "ToolsSettingsSirius.prm";
      clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\MachineSirius.bumachdef", ref ccVars.SimMachine, new MachineConfigSettings()
      {
        PartTypeInfo = "Clamper",
        PartTypeAdder = clsDrill.varDrillMachineSettings.ClamperVersion
      });
      this.MachType = DrillMachineType.Sirius;
      this.cGoSirius = new clsDrillSirius();
    }
    this.OpenToolConfigFile(clsDrill.fileNameToolSetting);
    this.FrmCabinetCycle = new F_CabinetCycle();
    clsVar5.shapeCreatePar.SingX = -1.0;
    clsVar5.shapeCreatePar.SingY = -1.0;
    this.cmdExceptionID.Add("clsProfile - ID = 101-00100");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00101");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00102");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00103");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00104");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00105");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00106");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00107");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00108");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00109");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00110");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00111");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00112");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00113");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00114");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00115");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00116");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00117");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00118");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00119");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00120");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00121");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00122");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00123");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00124");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00125");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00126");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00127");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00128");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00129");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00130");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00131");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00132");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00133");
    this.timCabinetCycle = new Timer();
    this.timCabinetCycle.Tick += new EventHandler(this.ERPCycle_Tick);
    this.timCabinetCycle.Interval = clsDrill.varDrillRunSettings.CabinetAutoCycleTickMs;
    this.timCabinetStartCycle = new Timer();
    this.timCabinetStartCycle.Tick += new EventHandler(this.ERPStartCycle_Tick);
    this.timCabinetStartCycle.Interval = clsDrill.varDrillRunSettings.CabinetAutoCycleTickDelayMs;
    this.timNew.Tick += new EventHandler(this.NewPageTick);
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 80 /*0x50*/)
        clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[index]);
      if (clsDrill.ToolList[index].Data.No == 270)
        clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[index]);
      if (clsDrill.ToolList[index].Data.No == 85)
        clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[index]);
      if (clsDrill.ToolList[index].Data.No == 185)
        clsDrill.toolSlotY2 = new ToolBase5(clsDrill.ToolList[index]);
    }
  }

  public void InitViewport()
  {
    if (this.frmMachSim == null)
    {
      this.frmMachSim = new F_DrillMachSim();
      this.frmMachSim.ValueChanged += new ValueChangedWithDataEventHandler(this.SimValueChaned);
    }
    if (clsDrill.viewportAuto == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsDrill.viewportAuto, clsVar.UnlockKey, new CreateModelProperties()
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
      clsDrill.viewportAuto.Name = "ModelAuto";
      this.frmMachSim.pnl_viewport.Controls.Add((System.Windows.Forms.Control) clsDrill.viewportAuto);
      clsDrill.viewportAuto.MouseMove += new MouseEventHandler(this.mouseMoveVierport);
      clsDrill.viewportAuto.MouseDown += new MouseEventHandler(this.mouseDownVierport);
      clsDrill.viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
      clsDrill.viewportAuto.ProgressBar.Visible = false;
      clsDrill.viewportAuto.WaitCursorMode = waitCursorType.Never;
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
          refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) clsDrill.viewportAuto));
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
          clsDrill.viewportAuto.Blocks.Add(block);
        }
        if (ccVars.SimMachine.MachineParts[index1].PartName == "X1_Body")
        {
          this.ClamperEntity = (Mesh) ccVars.SimMachine.MachineParts[index1].Entities[0].Clone();
          this.ClamperEntity.Regen(0.01);
        }
        if (ccVars.SimMachine.MachineParts[index1].PartName == "X1_Clamper" && this.ClamperEntity != null)
          this.ClamperEntity.MergeWith((Mesh) ccVars.SimMachine.MachineParts[index1].Entities[0]);
      }
      if (this.ClamperEntity != null && this.MachType == DrillMachineType.Sirius)
        this.ClamperEntity.Rotate(Math.PI, Vector3D.AxisZ);
    }
    clsDrill.viewportAuto.WorkCompleted += new WorkUnit.WorkCompletedEventHandler(this.method_0);
    clsDrill.viewportAuto.WorkCancelled += new WorkUnit.WorkCancelledEventHandler(this.method_2);
    clsDrill.viewportAuto.WorkFailed += new WorkUnit.WorkFailedEventHandler(this.method_1);
  }

  public void roundrect()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    CompositeCurve roundedRectangle = CompositeCurve.CreateRoundedRectangle(Plane.XY, 140.0, 200.0, 40.0, true);
    this.pntTarget = new Point3D(-70.0, 0.0);
    roundedRectangle.Regen(0.01);
    roundedRectangle.ColorMethod = colorMethodType.byEntity;
    List<Entity> refEntities = new List<Entity>();
    for (int index = 0; index <= roundedRectangle.CurveList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy((Entity) roundedRectangle.CurveList[index], ref copiedEntity);
      refEntities.Add(copiedEntity);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) roundedRectangle);
    Joint joint = new Joint(new Point3D(), 2.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.Lime;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) joint);
    buCircle buCircle = new buCircle(new Point3D(-70.0, 0.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> devideEntities = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.LineLength = 3.0;
    Settings.ArcLength = 3.0;
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    clsInit.cVector5.EntitiesDevideByLengthAsPolyline(refEntities, Settings, ref devideEntities);
    clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref this.pntList);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<Entity> BaseRefEntities = new List<Entity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      line.Visible = true;
      line.ColorMethod = colorMethodType.byEntity;
      line.LineWeight = 3f;
      line.LineWeightMethod = colorMethodType.byEntity;
      line.EntityData = (object) new CustomData();
      BaseRefEntities.Add((Entity) line);
    }
    List<Entity> SortedEntities = new List<Entity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
    for (int index = 0; index <= SortedEntities.Count - 1; ++index)
    {
      if (((CustomData) SortedEntities[index].EntityData).sortDirection == entitySortDirection.Normal)
      {
        devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(SortedEntities[index].Vertices[0], SortedEntities[index].Vertices[1]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
      else
      {
        devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(SortedEntities[index].Vertices[1], SortedEntities[index].Vertices[0]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
    }
    this.indx = 2;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void slot()
  {
    if (this.timm == null)
    {
      this.timm = new Timer();
      this.timm.Interval = 50;
      this.timm.Tick += new EventHandler(this.timtic);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    CompositeCurve slot = CompositeCurve.CreateSlot(Plane.XY, 150.0, 50.0, true);
    slot.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
    this.pntTarget = new Point3D(50.0, 0.0);
    slot.Regen(0.01);
    slot.ColorMethod = colorMethodType.byEntity;
    List<Entity> refEntities = new List<Entity>();
    for (int index = 0; index <= slot.CurveList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy((Entity) slot.CurveList[index], ref copiedEntity);
      refEntities.Add(copiedEntity);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) slot);
    Joint joint = new Joint(new Point3D(), 2.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.Lime;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) joint);
    buCircle buCircle = new buCircle(new Point3D(50.0, 0.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> devideEntities = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    clsInit.cVector5.EntitiesDevideByLengthAsPolyline(refEntities, Settings, ref devideEntities);
    clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref this.pntList);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<Entity> BaseRefEntities = new List<Entity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      line.Visible = true;
      line.ColorMethod = colorMethodType.byEntity;
      line.LineWeight = 3f;
      line.LineWeightMethod = colorMethodType.byEntity;
      line.EntityData = (object) new CustomData();
      BaseRefEntities.Add((Entity) line);
    }
    List<Entity> entityList = new List<Entity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortSettings(), ref entityList);
    clsInit.cVector5.ChangeEntitiesDirection(ref entityList);
    for (int index = 0; index <= entityList.Count - 1; ++index)
    {
      if (((CustomData) entityList[index].EntityData).sortDirection == entitySortDirection.Normal)
      {
        devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(entityList[index].Vertices[0], entityList[index].Vertices[1]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
      else
      {
        devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(entityList[index].Vertices[1], entityList[index].Vertices[0]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
    }
    this.AngleTot = 0.0;
    this.pntMove = new Point3D();
    this.indx = 2;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void slotMinus(double Length, double Radius, ref List<buEntity> Lines)
  {
    if (this.timm == null)
    {
      this.timm = new Timer();
      this.timm.Interval = 50;
      this.timm.Tick += new EventHandler(this.timtic);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    CompositeCurve slot = CompositeCurve.CreateSlot(Plane.XY, Length, Radius, true);
    slot.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
    this.pntTarget = new Point3D(Radius, 0.0);
    slot.Regen(0.01);
    slot.ColorMethod = colorMethodType.byEntity;
    List<Entity> refEntities = new List<Entity>();
    for (int index = 0; index <= slot.CurveList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buEntity.Copy((Entity) slot.CurveList[index], ref copiedEntity);
      refEntities.Add(copiedEntity);
    }
    buCircle buCircle = new buCircle(new Point3D(Radius, 0.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> devideEntities = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    clsInit.cVector5.EntitiesDevideByLengthAsPolyline(refEntities, Settings, ref devideEntities);
    clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref this.pntList);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<buEntity> BaseRefEntities = new List<buEntity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      buEntity buEntity = (buEntity) new buLine(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      BaseRefEntities.Add(buEntity);
    }
    List<buEntity> buEntityList = new List<buEntity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortbuSettings(), ref buEntityList);
    clsInit.cVector5.ChangeEntitiesDirection(ref buEntityList);
    Lines.Clear();
    devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D());
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) point);
    Lines.Add((buEntity) new buPoint());
    for (int index = 0; index <= buEntityList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      if (buEntityList[index].sortDirection == entitySortDirection.Normal)
      {
        buEntity refEntity = (buEntity) new buLine(buEntityList[index].Vertices[0], buEntityList[index].Vertices[1]);
        Lines.Add(refEntity);
        buEntity.Copy(refEntity, ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = Color.Black;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
      else
      {
        buEntity refEntity = (buEntity) new buLine(buEntityList[index].Vertices[1], buEntityList[index].Vertices[0]);
        Lines.Add(refEntity);
        buEntity.Copy(refEntity, ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = Color.Black;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
    }
    this.AngleTot = 0.0;
    this.pntMove = new Point3D();
    this.indx = 1;
  }

  public void slotPlus(double Length, double Radius, bool isPlus, ref List<buEntity> Lines)
  {
    if (this.timm == null)
    {
      this.timm = new Timer();
      this.timm.Interval = 50;
      this.timm.Tick += new EventHandler(this.timtic);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    CompositeCurve slot = CompositeCurve.CreateSlot(Plane.XY, Length, Radius, true);
    if (slot == null)
      return;
    slot.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
    if (!isPlus)
    {
      slot.Translate(0.0, Length / 2.0);
      this.pntTarget = new Point3D(Radius, 0.0);
    }
    else
    {
      slot.Translate(0.0, -Length / 2.0);
      this.pntTarget = new Point3D(Radius, 0.0);
    }
    slot.Regen(0.01);
    slot.ColorMethod = colorMethodType.byEntity;
    List<Entity> entityList = new List<Entity>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    if (!isPlus)
    {
      for (int index = 0; index <= slot.CurveList.Count - 1; ++index)
      {
        Entity copiedEntity = (Entity) null;
        Entity devideEntity = (Entity) null;
        buEntity.Copy((Entity) slot.CurveList[index], ref copiedEntity);
        clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity, Settings, ref devideEntity);
        buVector5.Add(devideEntity.Vertices, ref this.pntList);
        entityList.Add(copiedEntity);
      }
    }
    else
    {
      Entity copiedEntity1 = (Entity) null;
      Entity devideEntity1 = (Entity) null;
      buEntity.Copy((Entity) slot.CurveList[0], ref copiedEntity1);
      clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity1, Settings, ref devideEntity1);
      List<Point3D> copiedPoint1 = new List<Point3D>();
      buVector5.Copy(devideEntity1.Vertices, ref copiedPoint1);
      copiedPoint1.Reverse();
      buVector5.Add(copiedPoint1, ref this.pntList);
      entityList.Add(copiedEntity1);
      for (int index = slot.CurveList.Count - 1; index >= 1; --index)
      {
        Entity copiedEntity2 = (Entity) null;
        Entity devideEntity2 = (Entity) null;
        buEntity.Copy((Entity) slot.CurveList[index], ref copiedEntity2);
        clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity2, Settings, ref devideEntity2);
        List<Point3D> copiedPoint2 = new List<Point3D>();
        buVector5.Copy(devideEntity2.Vertices, ref copiedPoint2);
        copiedPoint2.Reverse();
        buVector5.Add(copiedPoint2, ref this.pntList);
        entityList.Add(copiedEntity2);
      }
    }
    buCircle buCircle = new buCircle(new Point3D(Radius, 0.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<buEntity> buEntityList = new List<buEntity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      buEntity buEntity = (buEntity) new buLine(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      buEntityList.Add(buEntity);
    }
    Lines.Clear();
    devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D());
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) point);
    if (!isPlus)
      Lines.Add((buEntity) new buPoint(new Point3D(0.0, Length / 2.0)));
    else
      Lines.Add((buEntity) new buPoint(new Point3D(0.0, -Length / 2.0)));
    for (int index = 0; index <= buEntityList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      if (buEntityList[index].sortDirection == entitySortDirection.Normal)
      {
        buEntity refEntity = (buEntity) new buLine(buEntityList[index].Vertices[0], buEntityList[index].Vertices[1]);
        Lines.Add(refEntity);
        buEntity.Copy(refEntity, ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = Color.Black;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
      else
      {
        buEntity refEntity = (buEntity) new buLine(buEntityList[index].Vertices[1], buEntityList[index].Vertices[0]);
        Lines.Add(refEntity);
        buEntity.Copy(refEntity, ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = Color.Black;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
    }
    this.AngleTot = 0.0;
    this.pntMove = new Point3D();
    this.indx = 1;
  }

  public void RoundRect(
    double Width,
    double Height,
    double Radius,
    bool isPlus,
    ref List<buEntity> Lines)
  {
    if (this.timm == null)
    {
      this.timm = new Timer();
      this.timm.Interval = 50;
      this.timm.Tick += new EventHandler(this.timtic);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    CompositeCurve roundedRectangle = CompositeCurve.CreateRoundedRectangle(Plane.XY, Width, Height, Radius, true);
    if (roundedRectangle == null)
      return;
    roundedRectangle.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
    if (!isPlus)
    {
      roundedRectangle.Translate(0.0, Width / 2.0 - Radius);
      this.pntTarget = new Point3D(Height / 2.0, 0.0);
    }
    else
    {
      roundedRectangle.Translate(0.0, -Width / 2.0 + Radius);
      this.pntTarget = new Point3D(Height / 2.0, 0.0);
    }
    roundedRectangle.Regen(0.01);
    roundedRectangle.ColorMethod = colorMethodType.byEntity;
    List<Entity> entityList = new List<Entity>();
    EntityDevideData Settings = new EntityDevideData();
    Settings.Line = true;
    this.pntList = new List<Point3D>();
    if (!isPlus)
    {
      for (int index = 0; index <= roundedRectangle.CurveList.Count - 1; ++index)
      {
        Entity copiedEntity = (Entity) null;
        Entity devideEntity = (Entity) null;
        buEntity.Copy((Entity) roundedRectangle.CurveList[index], ref copiedEntity);
        clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity, Settings, ref devideEntity);
        buVector5.Add(devideEntity.Vertices, ref this.pntList);
        entityList.Add(copiedEntity);
      }
    }
    else
    {
      Entity copiedEntity1 = (Entity) null;
      Entity devideEntity1 = (Entity) null;
      buEntity.Copy((Entity) roundedRectangle.CurveList[0], ref copiedEntity1);
      clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity1, Settings, ref devideEntity1);
      List<Point3D> copiedPoint1 = new List<Point3D>();
      buVector5.Copy(devideEntity1.Vertices, ref copiedPoint1);
      copiedPoint1.Reverse();
      buVector5.Add(copiedPoint1, ref this.pntList);
      entityList.Add(copiedEntity1);
      for (int index = roundedRectangle.CurveList.Count - 1; index >= 1; --index)
      {
        Entity copiedEntity2 = (Entity) null;
        Entity devideEntity2 = (Entity) null;
        buEntity.Copy((Entity) roundedRectangle.CurveList[index], ref copiedEntity2);
        clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity2, Settings, ref devideEntity2);
        List<Point3D> copiedPoint2 = new List<Point3D>();
        buVector5.Copy(devideEntity2.Vertices, ref copiedPoint2);
        copiedPoint2.Reverse();
        buVector5.Add(copiedPoint2, ref this.pntList);
        entityList.Add(copiedEntity2);
      }
    }
    buCircle buCircle = new buCircle(new Point3D(Height / 2.0, 0.0), 3.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<buEntity> buEntityList = new List<buEntity>();
    for (int index = 1; index <= this.pntList.Count - 1; ++index)
    {
      buEntity buEntity = (buEntity) new buLine(new Point3D(this.pntList[index - 1].X, this.pntList[index - 1].Y), this.pntList[index]);
      buEntityList.Add(buEntity);
    }
    Lines.Clear();
    devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D());
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) point);
    if (!isPlus)
      Lines.Add((buEntity) new buPoint(new Point3D(0.0, Height / 2.0)));
    else
      Lines.Add((buEntity) new buPoint(new Point3D(0.0, -Height / 2.0)));
    for (int index = 0; index <= buEntityList.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      if (buEntityList[index].sortDirection == entitySortDirection.Normal)
      {
        buEntity refEntity = (buEntity) new buLine(buEntityList[index].Vertices[0], buEntityList[index].Vertices[1]);
        Lines.Add(refEntity);
        buEntity.Copy(refEntity, ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = Color.Black;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
      else
      {
        buEntity refEntity = (buEntity) new buLine(buEntityList[index].Vertices[1], buEntityList[index].Vertices[0]);
        Lines.Add(refEntity);
        buEntity.Copy(refEntity, ref copiedEntity);
        copiedEntity.ColorMethod = colorMethodType.byEntity;
        copiedEntity.Color = Color.Black;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
      }
    }
    this.AngleTot = 0.0;
    this.pntMove = new Point3D();
    this.indx = 1;
  }

  public void freedraw()
  {
    if (this.timm == null)
    {
      this.timm = new Timer();
      this.timm.Interval = 50;
      this.timm.Tick += new EventHandler(this.timtic);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    this.pntTarget = new Point3D();
    List<buEntity> buEntityList = new List<buEntity>();
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      buEntity copiedEntity = (buEntity) null;
      buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index], ref copiedEntity);
      buEntityList.Add(copiedEntity);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    Joint joint = new Joint(new Point3D(), 2.0, (byte) 2);
    joint.ColorMethod = colorMethodType.byEntity;
    joint.Color = Color.Lime;
    buCircle buCircle = new buCircle(new Point3D(this.pntTarget.X, this.pntTarget.Y), 4.0);
    ccVars.pntDrawDynamicLines = new List<Point3D>();
    ccVars.pntDrawDynamicLines.AddRange((IEnumerable<Point3D>) buCircle.Vertices);
    List<Entity> entityList = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    EntityDevideData entityDevideData = new EntityDevideData()
    {
      Line = true,
      LineLength = 4.0,
      Arc = true,
      ArcLength = 4.0
    };
    this.pntList = new List<Point3D>();
    List<buEntity> BaseRefEntities = new List<buEntity>();
    for (int index1 = 0; index1 <= buEntityList.Count - 1; ++index1)
    {
      if (buEntityList[index1] is buLine)
      {
        this.pntList = new List<Point3D>();
        clsInit.cVector5.EntityDevide(buEntityList[index1], 4.0, ref this.pntList);
        for (int index2 = 1; index2 <= this.pntList.Count - 1; ++index2)
        {
          buLine buLine = new buLine(this.pntList[index2 - 1], this.pntList[index2]);
          BaseRefEntities.Add((buEntity) buLine);
        }
      }
      else
      {
        for (int index3 = 1; index3 <= buEntityList[index1].Vertices.Count - 1; ++index3)
        {
          buLine buLine = new buLine(buEntityList[index1].Vertices[index3 - 1], buEntityList[index1].Vertices[index3]);
          BaseRefEntities.Add((buEntity) buLine);
        }
      }
    }
    BaseRefEntities.Reverse();
    clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref this.pntList);
    List<buEntity> SortedEntities = new List<buEntity>();
    clsInit.cVector5.SortEntitiesByRefPoint(this.pntTarget, ref BaseRefEntities, new SortbuSettings()
    {
      Option = {
        NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup,
        IntersectionRules = SortingIntersectionRulesType.FromDrawing
      }
    }, ref SortedEntities);
    for (int index = 0; index <= SortedEntities.Count - 1; ++index)
    {
      if (SortedEntities[index].sortDirection == entitySortDirection.Normal)
      {
        devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(SortedEntities[index].Vertices[0], SortedEntities[index].Vertices[1]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
      else
      {
        devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(SortedEntities[index].Vertices[1], SortedEntities[index].Vertices[0]);
        line.Visible = true;
        line.ColorMethod = colorMethodType.byEntity;
        line.LineWeight = 3f;
        line.LineWeightMethod = colorMethodType.byEntity;
        line.EntityData = (object) new CustomData();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) line);
      }
    }
    double dx = this.pntTarget.X - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].X;
    double dy = this.pntTarget.Y - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].Y;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(dx, dy);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
    this.indx = 0;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void rotate1()
  {
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indx] is devDept.Eyeshot.Entities.Line)
    {
      devDept.Eyeshot.Entities.Line entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indx] as devDept.Eyeshot.Entities.Line;
      double radian = buConversion5.DegreeToRadian(180.0 - clsInit.cVector5.PointAngle(entity.EndPoint, entity.StartPoint));
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.indx].Selected = true;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(radian, Vector3D.AxisZ, entity.StartPoint);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      Point3D endPoint = entity.EndPoint;
      double dx = this.pntTarget.X - endPoint.X;
      double dy = this.pntTarget.Y - endPoint.Y;
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(dx, dy);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    ++this.indx;
  }

  public void rotate()
  {
    if (this.indx <= this.list_1.Count - 1)
    {
      buLine buLine = this.list_1[this.indx] as buLine;
      double num1 = clsInit.cVector5.PointAngle(buLine.EndPoint, buLine.StartPoint) + 0.0;
      if (num1 != 90.0)
        ;
      double num2 = 90.0 - num1;
      this.AngleTot += num2;
      double num3 = buLine.StartPoint.X - buLine.EndPoint.X;
      double num4 = buLine.StartPoint.Y - buLine.EndPoint.Y;
      clsInit.cVector5.Move(num3, num4, 0.0, ref this.list_1);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(num3, num4);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      double radian = buConversion5.DegreeToRadian(num2);
      clsInit.cVector5.Rotate(this.pntTarget, num2, Vector3D.AxisZ, ref this.list_1);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(radian, Vector3D.AxisZ, this.pntTarget);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Text)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
      this.pntMove = this.list_1[0].StartPoint;
      Text text = new Text(Plane.XY, new Point3D(), $"{this.AngleTot.ToString()}{Environment.NewLine}  {this.pntMove.X.ToString("f1")} , {this.pntMove.Y.ToString("f1")}", 20.0);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) text);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    else
    {
      this.timm.Enabled = false;
      this.indx = 1;
    }
    ++this.indx;
  }

  public void rotateplus(bool isPlus)
  {
    if (this.indx <= this.list_1.Count - 1)
    {
      buLine buLine = this.list_1[this.indx] as buLine;
      double num1 = isPlus ? clsInit.cVector5.PointAngle(buLine.StartPoint, buLine.EndPoint) + 0.0 : clsInit.cVector5.PointAngle(buLine.EndPoint, buLine.StartPoint) + 0.0;
      if (num1 != 90.0)
        ;
      double num2 = 90.0 - num1;
      this.AngleTot += num2;
      double num3 = buLine.StartPoint.X - buLine.EndPoint.X;
      double num4 = buLine.StartPoint.Y - buLine.EndPoint.Y;
      clsInit.cVector5.Move(num3, num4, 0.0, ref this.list_1);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(num3, num4);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      double radian = buConversion5.DegreeToRadian(num2);
      clsInit.cVector5.Rotate(this.pntTarget, num2, Vector3D.AxisZ, ref this.list_1);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(radian, Vector3D.AxisZ, this.pntTarget);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Text)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
      this.pntMove = this.list_1[0].StartPoint;
      Text text = new Text(Plane.XY, new Point3D(), $"{this.AngleTot.ToString()}{Environment.NewLine}  {this.pntMove.X.ToString("f1")} , {this.pntMove.Y.ToString("f1")}", 20.0);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) text);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    else
    {
      this.timm.Enabled = false;
      this.indx = 1;
    }
    ++this.indx;
  }

  public void rotate(int Index, List<buEntity> Entities, ref Point3D pntMove, ref double Angle)
  {
    if (Index > Entities.Count - 1 || !(Entities[Index] is buLine))
      return;
    buLine entity = Entities[Index] as buLine;
    double Degree = 90.0 - clsInit.cVector5.PointAngle(entity.EndPoint, entity.StartPoint);
    double num1 = entity.StartPoint.X - entity.EndPoint.X;
    double num2 = entity.StartPoint.Y - entity.EndPoint.Y;
    buConversion5.DegreeToRadian(Degree);
    Angle += Degree;
    pntMove.X += num1;
    pntMove.Y += num2;
  }

  public void timtic(object sender, EventArgs e) => this.rotateplus(true);

  public void cmdNewMaterial(DrillJob panel)
  {
    if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
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
      clsItem.FrmMaterial3D.Material = new MaterialBase5(ccVars.activeMaterial);
      buEntity.Copy((Entity) this.ClamperEntity, ref clsItem.FrmMaterial3D.EntClamper);
      if (panel != null)
        clsItem.FrmMaterial3D.Init(panel.Material);
      else
        clsItem.FrmMaterial3D.Init((MaterialBase5) null);
      clsItem.FrmMaterial3D.StartPosition = FormStartPosition.CenterParent;
      int num = (int) clsItem.FrmMaterial3D.ShowDialog();
      if (clsItem.FrmMaterial3D.PropertiesForm.Result != DialogResult.OK)
        return;
      ccVars.activeMaterial = new MaterialBase5(clsItem.FrmMaterial3D.Material);
      if (clsVar5.shapeCreatePar.SingX < 0.0 & clsVar5.shapeCreatePar.SingY < 0.0)
        clsInit.cVector5.Move(-ccVars.activeMaterial.Size.Width, -ccVars.activeMaterial.Size.Height, 0.0, ref ccVars.activeMaterial.Entities);
      if (panel == null)
        this.AddPanel(ccVars.activeMaterial);
      else
        this.doEditPanel(this.selectedJobIndex, ccVars.activeMaterial);
    }
  }

  public void cmdHolesMenu()
  {
    if (this.timm == null)
      return;
    if (!this.timm.Enabled)
      this.timm.Enabled = true;
    else
      this.timm.Enabled = false;
  }

  public void cmdCutsMenu()
  {
    this.list_1 = new List<buEntity>();
    this.RoundRect(350.0, 150.0, 25.0, true, ref this.list_1);
  }

  public void cmdDrawingsMenu()
  {
    if (clsDrill.activeJob == null)
      return;
    if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
      clsItem.FrmDrillList.Visible = false;
    if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
      clsItem.FrmProfilingList.Visible = false;
    if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
      clsItem.FrmJunctionList.Visible = false;
    if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
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
      Properties.OriginSymbolVisible = false;
      Properties.OrigineSize = 3;
      clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
      clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
      clsItem.FrmShapeList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
    }
    buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
    buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
    clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
    clsItem.FrmShapeList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
    if (clsVar5.lastShape == null)
    {
      clsItem.FrmShapeList.selectedShape = (buShape) new buShapeRectangle(clsVar5.ShapeDataParameters.RectangleWidth, clsVar5.ShapeDataParameters.RectangleHeight);
      clsItem.FrmShapeList.selectedShape.ShapeType = ShapeTypes.Rectangle;
      clsVar5.ShapeDataParameters.ShapeType = ShapeTypes.Rectangle;
    }
    else if (clsVar5.lastShape != null)
    {
      clsItem.FrmShapeList.selectedShape = buShape.Copy(clsVar5.lastShape);
      clsVar5.ShapeDataParameters.ShapeType = clsItem.FrmShapeList.selectedShape.ShapeType;
    }
    clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDrillVars.varCamContour.buPar);
    clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDrillVars.varCamContour.buPar);
    clsItem.FrmShapeList.PropertiesForm.TopMost = true;
    clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
    clsItem.FrmShapeList.TopMost = true;
    if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
      clsItem.FrmShapeList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmShapeList.viewportLayout);
    clsItem.FrmShapeList.viewportLayout.Entities.Clear();
    clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    if (clsItem.FrmMain != null)
      clsItem.FrmShapeList.Owner = clsItem.FrmMain;
    clsItem.FrmShapeList.Width = 410;
    clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmShapeList.ShowTool = true;
    clsItem.FrmShapeList.Tools.Clear();
    for (int index1 = 0; index1 <= ccVars.Tools.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.Tools[index1].Tools.Count - 1; ++index2)
        clsItem.FrmShapeList.Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
    }
    if (this.EditOperation)
    {
      int num = clsVar5.lastShape == null ? 0 : (clsVar5.lastShape.Tool != null ? 1 : 0);
      clsItem.FrmShapeList.activeTool = num == 0 ? new ToolBase5(ccVars.toolActive) : new ToolBase5(clsVar5.lastShape.Tool);
    }
    else
      clsItem.FrmShapeList.activeTool = new ToolBase5(ccVars.toolActive);
    clsItem.FrmShapeList.Init();
    clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmShapeList.Show();
    clsItem.FrmShapeList.Top = 20;
    clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
  }

  public void cmdCornerMenu()
  {
    if (clsDrill.activeJob == null)
      return;
    if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
      clsItem.FrmDrillList.Visible = false;
    if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
      clsItem.FrmShapeList.Visible = false;
    if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
      clsItem.FrmJunctionList.Visible = false;
    if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsItem.FrmProfilingList == null)
    {
      clsItem.FrmProfilingList = new F_ProfilingList();
      CreateModelProperties Properties = new CreateModelProperties();
      clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
      Properties.CoordinateSystemIconVisible = false;
      Properties.ViewCubeIconVisible = false;
      Properties.OrigineCaptionVisible = false;
      Properties.ToolBorVisible = false;
      Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
      Properties.OriginSymbolVisible = false;
      Properties.OrigineSize = 3;
      clsItem.FrmProfilingList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      clsItem.FrmProfilingList.viewportLayout.CompileUserInterfaceElements();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        clsItem.FrmProfilingList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
      clsItem.FrmProfilingList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
      clsItem.FrmProfilingList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
    }
    clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Profiling;
    clsItem.FrmProfilingList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
    if (clsVar5.lastProfiling == null)
    {
      clsItem.FrmProfilingList.selectedShape = (buShape) new buShapeProfiling(ProfilingTypes.ProfilingRectangle, clsVar5.ShapeDataParameters.ProfilingRadius, clsVar5.ShapeDataParameters.ProfilingDepth, clsVar5.ShapeDataParameters.ProfilingLength, clsVar5.ShapeDataParameters.ProfilingWidth, clsVar5.ShapeDataParameters.ProfilingHeight);
      ((buShapeProfiling) clsItem.FrmProfilingList.selectedShape).ProfilingType = ProfilingTypes.ProfilingRectangle;
      clsVar5.ShapeDataParameters.ProfilingType = ProfilingTypes.ProfilingRectangle;
    }
    else if (clsVar5.lastProfiling is buShapeProfiling)
    {
      clsItem.FrmProfilingList.selectedShape = buShape.Copy(clsVar5.lastProfiling);
      clsVar5.ShapeDataParameters.ProfilingType = ((buShapeProfiling) clsItem.FrmProfilingList.selectedShape).ProfilingType;
    }
    clsItem.FrmProfilingList.selectedShape.CamPar = new camParameters5();
    clsItem.FrmProfilingList.CamPar = new camParameters5();
    clsItem.FrmProfilingList.PropertiesForm.TopMost = true;
    clsItem.FrmProfilingList.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsItem.FrmProfilingList.StartPosition = FormStartPosition.Manual;
    clsItem.FrmProfilingList.TopMost = true;
    clsItem.FrmProfilingList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    if (clsItem.FrmProfilingList.pnl_model.Controls.Count == 0)
      clsItem.FrmProfilingList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmProfilingList.viewportLayout);
    clsItem.FrmProfilingList.viewportLayout.Entities.Clear();
    clsItem.FrmProfilingList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    if (clsItem.FrmMain != null)
      clsItem.FrmProfilingList.Owner = clsItem.FrmMain;
    clsItem.FrmProfilingList.Width = 410;
    clsItem.FrmProfilingList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmProfilingList.ShowTool = true;
    clsItem.FrmProfilingList.Tools.Clear();
    for (int index1 = 0; index1 <= ccVars.Tools.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.Tools[index1].Tools.Count - 1; ++index2)
        clsItem.FrmProfilingList.Tools.Add(new ToolBase5(ccVars.Tools[index1].Tools[index2]));
    }
    clsItem.FrmProfilingList.activeTool = new ToolBase5(ccVars.toolActive);
    clsItem.FrmProfilingList.Init();
    clsItem.FrmProfilingList.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmProfilingList.Show();
    clsItem.FrmProfilingList.Top = 20;
    clsItem.FrmProfilingList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmProfilingList.Width;
  }

  public void cmdContourMaterial()
  {
    this.EditOperation = false;
    if (clsDrill.activeJob == null)
      return;
    if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
      clsItem.FrmDrillList.Visible = false;
    if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
      clsItem.FrmProfilingList.Visible = false;
    if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
      clsItem.FrmShapeList.Visible = false;
    if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
      clsItem.FrmJunctionList.Visible = false;
    if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsDrill.activeJob.Material.Size.Width < 400.0)
    {
      buString5.MessageBoxError(buDrillCalc.LangDrillMessage[42]);
    }
    else
    {
      if (clsDrill.activeJob.MakeContour)
      {
        clsDrill.activeJob.MakeContour = false;
      }
      else
      {
        F_Contour fContour = new F_Contour()
        {
          PropertiesForm = {
            FormCloseMode = FormCloseModeType.Invisible
          },
          settingRuntime = new DrillRuntimeSettings(clsDrill.varDrillRunSettings),
          settingCNC = new DrillCNCSettings(clsDrill.varDrillCNCSettings)
        };
        fContour.settingRuntime.lastContourPlaneNames = planeBoxNames.Top;
        fContour.Job = new DrillJob(clsDrill.activeJob);
        fContour.Init();
        fContour.StartPosition = FormStartPosition.CenterParent;
        int num1 = (int) fContour.ShowDialog();
        if (fContour.PropertiesForm.Result == DialogResult.OK)
        {
          buShape Shape = new buShape();
          Shape.ShapeGroup = ShapeGroup.Contour;
          Shape.OffsetDistance = clsDrill.varDrillRunSettings.ContourOffset;
          Shape.Depth = clsDrill.varDrillRunSettings.ContourDepth;
          Shape.planeName = clsDrill.varDrillRunSettings.lastContourPlaneNames;
          Shape.ID = this.IDCounter;
          if (!this.CheckOperations(Shape, ref this.operationErrorList) && this.operationErrorList.Count > 0)
          {
            DialogBoxList dialogBoxList = new DialogBoxList();
            dialogBoxList.Caption = buLangTranslate.preDef.Error;
            dialogBoxList.Width = 500;
            for (int index = 0; index <= this.operationErrorList.Count - 1; ++index)
              dialogBoxList.Items.Add(this.operationErrorList[index]);
            dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
            dialogBoxList.Init();
            int num2 = (int) dialogBoxList.ShowDialog();
            if (dialogBoxList.Result != DialogResult.OK)
            {
              clsInit.appCommand.Reset();
              return;
            }
          }
          clsDrill.activeJob.Items.Add(Shape);
          this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
          this.SaveDrillFile();
          clsInit.appCommand.Reset();
          this.JobUpdate(true, (DrillItem) null);
          ++this.IDCounter;
        }
      }
      this.JobUpdate(true, (DrillItem) null);
    }
  }

  public void cmdEngraving()
  {
    if (clsDrill.activeJob == null)
      return;
    if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
      clsItem.FrmDrillList.Visible = false;
    if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
      clsItem.FrmProfilingList.Visible = false;
    if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
      clsItem.FrmShapeList.Visible = false;
    if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
      clsItem.FrmJunctionList.Visible = false;
    if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsItem.FrmFromFile == null)
      clsItem.FrmFromFile = new F_AddFromFile();
    clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmFromFile.Path = clsDrill.varDrillRunSettings.pathEngraving;
    clsItem.FrmFromFile.KeepRatio = clsDrill.varDrillRunSettings.EngravingKeepRatio;
    clsItem.FrmFromFile.ExtensionList.Clear();
    clsItem.FrmFromFile.ExtensionList.Add(".stl");
    clsItem.FrmFromFile.ExtensionList.Add(".step");
    clsItem.FrmFromFile.ExtensionList.Add(".stp");
    clsItem.FrmFromFile.ExtensionList.Add(".iges");
    clsItem.FrmFromFile.ExtensionList.Add(".igs");
    clsItem.FrmFromFile.Init();
    int num = (int) clsItem.FrmFromFile.ShowDialog();
    if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
      return;
    this.list_0.Clear();
    this.list_0 = new List<Entity>();
    for (int index = 0; index <= clsItem.FrmFromFile.viewport.Entities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      if (clsItem.FrmFromFile.viewport.Entities[index] is Mesh)
      {
        buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
        this.list_0.Add(copiedEntity);
      }
      else if (clsItem.FrmFromFile.viewport.Entities[index] is Brep)
        this.list_0.Add((Entity) ((Brep) clsItem.FrmFromFile.viewport.Entities[index]).ConvertToMesh());
    }
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    clsInit.cVector5.BoxSizeCalculate(this.list_0, ref MinPoint, ref MidPoint, ref MaxPoint);
    clsInit.cVector5.Move(-MidPoint.X, -MidPoint.Y, -MinPoint.Z, ref this.list_0);
    clsDrill.varDrillRunSettings.pathEngraving = clsItem.FrmFromFile.Path;
    clsDrill.varDrillRunSettings.EngravingKeepRatio = clsItem.FrmFromFile.KeepRatio;
    if (this.list_0.Count > 0)
    {
      clsInit.cVector5.BoxSizeCalculate(this.list_0[0], ref MinPoint, ref MidPoint, ref MaxPoint);
      clsVar5.ShapeDataParameters.EngravingWidth = MaxPoint.X - MinPoint.X;
      clsVar5.ShapeDataParameters.EngravingHeight = MaxPoint.Y - MinPoint.Y;
      clsVar5.ShapeDataParameters.EngravingDepth = MaxPoint.Z - MinPoint.Z;
      if (clsItem.FrmEngraveList == null)
      {
        clsItem.FrmEngraveList = new F_EngraveList();
        CreateModelProperties Properties = new CreateModelProperties();
        clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
        Properties.CoordinateSystemIconVisible = false;
        Properties.ViewCubeIconVisible = false;
        Properties.OrigineCaptionVisible = false;
        Properties.ToolBorVisible = false;
        Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
        Properties.OriginSymbolVisible = false;
        Properties.OrigineSize = 3;
        clsItem.FrmEngraveList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
        clsItem.FrmEngraveList.viewportLayout.CompileUserInterfaceElements();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
          clsItem.FrmEngraveList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
        clsItem.FrmEngraveList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
        clsItem.FrmEngraveList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
      }
      clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Engraving;
      clsItem.FrmEngraveList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
      clsItem.FrmEngraveList.selectedShape = (buShape) new buShapeEngrave(clsVar5.ShapeDataParameters.EngravingDepth, clsVar5.ShapeDataParameters.EngravingWidth, clsVar5.ShapeDataParameters.EngravingHeight, this.list_0[0]);
      clsItem.FrmEngraveList.selectedShape.CamPar = new camParameters5();
      clsItem.FrmEngraveList.CamPar = new camParameters5();
      clsItem.FrmEngraveList.PropertiesForm.TopMost = true;
      clsItem.FrmEngraveList.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsItem.FrmEngraveList.StartPosition = FormStartPosition.Manual;
      clsItem.FrmEngraveList.TopMost = true;
      if (clsItem.FrmEngraveList.pnl_model.Controls.Count == 0)
        clsItem.FrmEngraveList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmEngraveList.viewportLayout);
      clsItem.FrmEngraveList.viewportLayout.Entities.Clear();
      clsItem.FrmEngraveList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      if (clsItem.FrmMain != null)
        clsItem.FrmEngraveList.Owner = clsItem.FrmMain;
      clsItem.FrmEngraveList.Width = 410;
      if (this.list_0.Count > 0)
        ;
      buEntity.Copy(this.list_0, ref clsVar5.shapeCreatePar.entitiesEngraving);
      clsItem.FrmEngraveList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmEngraveList.Init();
      clsItem.FrmEngraveList.StartPosition = FormStartPosition.CenterParent;
      clsItem.FrmEngraveList.Show();
      clsItem.FrmEngraveList.Top = 20;
      clsItem.FrmEngraveList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmEngraveList.Width;
    }
    this.SaveDrillFile();
  }

  public void cmdJunctionMenu()
  {
    if (clsDrill.activeJob == null)
      return;
    if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
      clsItem.FrmDrillList.Visible = false;
    if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
      clsItem.FrmProfilingList.Visible = false;
    if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
      clsItem.FrmShapeList.Visible = false;
    if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
      clsItem.FrmSlotList.Visible = false;
    if (clsItem.FrmJunctionList == null)
    {
      clsItem.FrmJunctionList = new F_JunctionList();
      CreateModelProperties Properties = new CreateModelProperties();
      clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
      Properties.CoordinateSystemIconVisible = false;
      Properties.ViewCubeIconVisible = false;
      Properties.OrigineCaptionVisible = false;
      Properties.ToolBorVisible = false;
      Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
      Properties.OriginSymbolVisible = false;
      Properties.OrigineSize = 3;
      clsItem.FrmJunctionList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      clsItem.FrmJunctionList.viewportLayout.CompileUserInterfaceElements();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        clsItem.FrmJunctionList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
      clsItem.FrmJunctionList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
      clsItem.FrmJunctionList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
    }
    clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Junction;
    clsItem.FrmJunctionList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
    if (clsVar5.lastJunction == null)
    {
      clsItem.FrmJunctionList.selectedShape = (buShape) new buShapeJunction(JunctionTypes.Junction3HoleIntersectHorizontal, clsVar5.ShapeDataParameters.JunctionDiameter, clsVar5.ShapeDataParameters.JunctionDepth, clsVar5.ShapeDataParameters.JunctionDiameterOutside, clsVar5.ShapeDataParameters.JunctionDistance, clsVar5.ShapeDataParameters.isMillingJunction);
      clsVar5.ShapeDataParameters.JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
    }
    else if (clsVar5.lastJunction is buShapeJunction)
    {
      clsItem.FrmJunctionList.selectedShape = buShape.Copy(clsVar5.lastJunction);
      clsVar5.ShapeDataParameters.JunctionType = ((buShapeJunction) clsItem.FrmJunctionList.selectedShape).JunctionType;
    }
    clsItem.FrmJunctionList.selectedShape.CamPar = new camParameters5();
    clsItem.FrmJunctionList.CamPar = new camParameters5();
    clsItem.FrmJunctionList.PropertiesForm.TopMost = true;
    clsItem.FrmJunctionList.PropertiesForm.FormPosition = FormStartPosition.Manual;
    clsItem.FrmJunctionList.StartPosition = FormStartPosition.Manual;
    clsItem.FrmJunctionList.TopMost = true;
    if (clsItem.FrmJunctionList.pnl_model.Controls.Count == 0)
      clsItem.FrmJunctionList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmJunctionList.viewportLayout);
    clsItem.FrmJunctionList.viewportLayout.Entities.Clear();
    clsItem.FrmJunctionList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    if (clsItem.FrmMain != null)
      clsItem.FrmJunctionList.Owner = clsItem.FrmMain;
    clsItem.FrmJunctionList.Width = 410;
    clsItem.FrmJunctionList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    clsItem.FrmJunctionList.Init();
    clsItem.FrmJunctionList.StartPosition = FormStartPosition.CenterParent;
    clsItem.FrmJunctionList.Show();
    clsItem.FrmJunctionList.Top = 20;
    clsItem.FrmJunctionList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmJunctionList.Width;
  }

  public void cmdTextMenu()
  {
    try
    {
      if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
        clsItem.FrmDrillList.Visible = false;
      if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
        clsItem.FrmProfilingList.Visible = false;
      if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
        clsItem.FrmShapeList.Visible = false;
      if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
        clsItem.FrmJunctionList.Visible = false;
      if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
        clsItem.FrmSlotList.Visible = false;
      if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
        clsItem.FrmSlotList.Visible = false;
      F_VectorText fVectorText = new F_VectorText();
      fVectorText.TextData = new TextVectorData(clsVar.varInterface.VectorTextVar);
      fVectorText.Init();
      int num = (int) fVectorText.ShowDialog();
      if (fVectorText.Result != DialogResult.OK)
        return;
      clsVar.varInterface.VectorTextVar = new TextVectorData(fVectorText.TextData);
      ccVars.VectorTextRunVar.Alignment = clsVar.varInterface.VectorTextVar.Alignment;
      ccVars.VectorTextRunVar.DrawAsCurve = clsVar.varInterface.VectorTextVar.DrawAsCurve;
      ccVars.VectorTextRunVar.Height = clsVar.varInterface.VectorTextVar.Height;
      ccVars.VectorTextRunVar.Text = clsVar.varInterface.VectorTextVar.Text;
      clsFiles.SaveParameter();
      clsInit.appCommand.VectorTextCreate(clsVar.varInterface.VectorTextVar.Text, clsVar.varInterface.VectorTextVar.Font, clsVar.varInterface.VectorTextVar.Height, ccVars.VectorTextRunVar.Alignment, ccVars.planeActive, ref ccVars.ContourPoints);
      if (clsDrill.activeJob == null)
        return;
      clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
      clsVar5.shapeCreatePar.entitiesCurve.Clear();
      for (int index1 = 0; index1 <= ccVars.ContourPoints.Count - 1; ++index1)
      {
        List<Point3D> CopiedPnt1 = new List<Point3D>();
        buConversion5.Pnt3DToPoint3D(ccVars.ContourPoints[index1].Outter, ref CopiedPnt1);
        buCompositeCurve buCompositeCurve1 = new buCompositeCurve((buEntity) new buLinearPath(CopiedPnt1));
        clsVar5.shapeCreatePar.entitiesCurve.Add((buEntity) buCompositeCurve1);
        for (int index2 = 0; index2 <= ccVars.ContourPoints[index1].Holes.Count - 1; ++index2)
        {
          List<Point3D> CopiedPnt2 = new List<Point3D>();
          buConversion5.Pnt3DToPoint3D(ccVars.ContourPoints[index1].Holes[index2], ref CopiedPnt2);
          buCompositeCurve buCompositeCurve2 = new buCompositeCurve((buEntity) new buLinearPath(CopiedPnt2));
          clsVar5.shapeCreatePar.entitiesCurve.Add((buEntity) buCompositeCurve2);
        }
      }
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
        Properties.OriginSymbolVisible = false;
        Properties.OrigineSize = 3;
        clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
        clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
          clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
        clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
        clsItem.FrmShapeList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
      }
      buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
      buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
      clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
      clsItem.FrmShapeList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
      clsVar5.ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(clsVar5.shapeCreatePar.entitiesCurve, ref MinPoint, ref MaxPoint);
      clsVar5.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
      clsVar5.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
      clsItem.FrmShapeList.selectedShape = (buShape) new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
      clsItem.FrmShapeList.selectedShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      clsItem.FrmShapeList.selectedShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
      clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.PropertiesForm.TopMost = true;
      clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.TopMost = true;
      if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
        clsItem.FrmShapeList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmShapeList.viewportLayout);
      clsItem.FrmShapeList.viewportLayout.Entities.Clear();
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      if (clsItem.FrmMain != null)
        clsItem.FrmShapeList.Owner = clsItem.FrmMain;
      clsItem.FrmShapeList.Width = 410;
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmShapeList.Init();
      clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
      clsItem.FrmShapeList.Show();
      clsItem.FrmShapeList.Top = 20;
      clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdLibraryMenu()
  {
    try
    {
      if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
        clsItem.FrmDrillList.Visible = false;
      if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
        clsItem.FrmProfilingList.Visible = false;
      if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
        clsItem.FrmShapeList.Visible = false;
      if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
        clsItem.FrmJunctionList.Visible = false;
      if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
        clsItem.FrmSlotList.Visible = false;
      if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
        clsItem.FrmSlotList.Visible = false;
      if (!new DirectoryInfo(clsVar.varLibrary.pathLibrary).Exists)
        clsVar.varLibrary.pathLibrary = AppPath.Base + "\\Library";
      clsInit.appCommand.cmdLibDraw();
      if (clsItem.FrmLibraryDraw.PropertiesForm.Result == DialogResult.OK)
      {
        clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
        SketchAnalyseData AnalyseData = new SketchAnalyseData();
        clsInit.appEditor.AnalyseSketchEntity(clsLibrary.LibraryEntities, new SketchAnalyseSetData(clsVar5.ShapeDataParameters.FreeDrawDepth), ref AnalyseData);
        if (AnalyseData.AnalyseEntities.Count > 0)
        {
          buEntity.Copy(AnalyseData.AnalyseEntities, ref clsVar5.shapeCreatePar.entitiesCurve);
          buNumeric5.Copy(AnalyseData.DepthLevel, ref clsVar5.ShapeDataParameters.DepthLevels);
          buNumeric5.Copy(AnalyseData.DepthLevel, ref clsVar5.shapeCreatePar.DepthLevel);
        }
      }
      if (clsDrill.activeJob == null)
        return;
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
        Properties.OriginSymbolVisible = false;
        Properties.OrigineSize = 3;
        clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
        clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
          clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
        clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
        clsItem.FrmShapeList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
      }
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(clsVar5.shapeCreatePar.entitiesCurve, ref MinPoint, ref MaxPoint);
      clsVar5.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
      clsVar5.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
      clsItem.FrmShapeList.selectedShape = (buShape) new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
      clsItem.FrmShapeList.selectedShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      clsItem.FrmShapeList.selectedShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
      clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
      clsVar5.ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
      clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
      clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.PropertiesForm.TopMost = true;
      clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.TopMost = true;
      if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
        clsItem.FrmShapeList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmShapeList.viewportLayout);
      clsItem.FrmShapeList.viewportLayout.Entities.Clear();
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      if (clsItem.FrmMain != null)
        clsItem.FrmShapeList.Owner = clsItem.FrmMain;
      clsItem.FrmShapeList.Width = 410;
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmShapeList.Init();
      clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
      clsItem.FrmShapeList.Show();
      clsItem.FrmShapeList.Top = 20;
      clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdFromFileMenu()
  {
    try
    {
      if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
        clsItem.FrmDrillList.Visible = false;
      if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
        clsItem.FrmProfilingList.Visible = false;
      if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
        clsItem.FrmShapeList.Visible = false;
      if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
        clsItem.FrmJunctionList.Visible = false;
      if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
        clsItem.FrmSlotList.Visible = false;
      if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
        clsItem.FrmSlotList.Visible = false;
      if (clsItem.FrmFromFile == null)
        clsItem.FrmFromFile = new F_AddFromFile();
      clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
      clsItem.FrmFromFile.Path = clsVar.varEditorRuntimeSet.pathFromFile;
      clsItem.FrmFromFile.KeepRatio = clsVar.varEditorRuntimeSet.FromFileKeepRatio;
      clsItem.FrmFromFile.Init();
      int num = (int) clsItem.FrmFromFile.ShowDialog();
      if (clsItem.FrmFromFile.PropertiesForm.Result == DialogResult.OK)
      {
        clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
        for (int index = 0; index <= clsItem.FrmFromFile.viewport.Entities.Count - 1; ++index)
        {
          buEntity copiedEntity = (buEntity) null;
          buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
          clsVar5.shapeCreatePar.entitiesCurve.Add(copiedEntity);
        }
        clsVar.varEditorRuntimeSet.pathFromFile = clsItem.FrmFromFile.Path;
        clsVar.varEditorRuntimeSet.FromFileKeepRatio = clsItem.FrmFromFile.KeepRatio;
        clsInit.appEditor.SaveEditorFile();
      }
      if (clsDrill.activeJob == null)
        return;
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
        Properties.OriginSymbolVisible = false;
        Properties.OrigineSize = 3;
        clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
        clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
          clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
        clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
        clsItem.FrmShapeList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
      }
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(clsVar5.shapeCreatePar.entitiesCurve, ref MinPoint, ref MaxPoint);
      clsVar5.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
      clsVar5.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
      clsItem.FrmShapeList.selectedShape = (buShape) new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
      clsItem.FrmShapeList.selectedShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      clsItem.FrmShapeList.selectedShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
      clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
      clsVar5.ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
      clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
      clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.PropertiesForm.TopMost = true;
      clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.TopMost = true;
      if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
        clsItem.FrmShapeList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmShapeList.viewportLayout);
      clsItem.FrmShapeList.viewportLayout.Entities.Clear();
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      if (clsItem.FrmMain != null)
        clsItem.FrmShapeList.Owner = clsItem.FrmMain;
      clsItem.FrmShapeList.Width = 410;
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmShapeList.Init();
      clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
      clsItem.FrmShapeList.Show();
      clsItem.FrmShapeList.Top = 20;
      clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdFromDrawing()
  {
    try
    {
      if (clsItem.frmEditor == null)
        clsItem.frmEditor = new F_Editor();
      clsItem.frmEditor = new F_Editor();
      clsVar.varEditorRuntimeSet.isSewingMode = false;
      clsVar.varEditorRuntimeSet.isSketchMode = false;
      clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.frmEditor.Init();
      int num = (int) clsItem.frmEditor.ShowDialog();
      clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
      for (int index = 0; index <= clsItem.frmEditor.viewport.Entities.Count - 1; ++index)
      {
        buEntity copiedEntity = (buEntity) null;
        buEntity.Copy(clsItem.frmEditor.viewport.Entities[index], ref copiedEntity);
        clsVar5.shapeCreatePar.entitiesCurve.Add(copiedEntity);
      }
      clsInit.appEditor.SaveEditorFile();
      if (clsDrill.activeJob == null)
        return;
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
        Properties.OriginSymbolVisible = false;
        Properties.OrigineSize = 3;
        clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
        clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
          clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index]);
        clsItem.FrmShapeList.DataOk += new OkCommandWithTwoDataEventHandler(this.ShapeChanged);
        clsItem.FrmShapeList.DataCancel += new CancelCommandEventHandler(this.ShapeCancel);
      }
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      clsInit.cVector5.BoxSizeCalculate(clsVar5.shapeCreatePar.entitiesCurve, ref MinPoint, ref MaxPoint);
      clsVar5.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
      clsVar5.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
      clsItem.FrmShapeList.selectedShape = (buShape) new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
      clsItem.FrmShapeList.selectedShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
      clsItem.FrmShapeList.selectedShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
      clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
      clsVar5.ShapeDataParameters.ShapeType = ShapeTypes.FreeDraw;
      clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
      clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDrillVars.varCamContour.buPar);
      clsItem.FrmShapeList.PropertiesForm.TopMost = true;
      clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
      clsItem.FrmShapeList.TopMost = true;
      if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
        clsItem.FrmShapeList.pnl_model.Controls.Add((System.Windows.Forms.Control) clsItem.FrmShapeList.viewportLayout);
      clsItem.FrmShapeList.viewportLayout.Entities.Clear();
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      if (clsItem.FrmMain != null)
        clsItem.FrmShapeList.Owner = clsItem.FrmMain;
      clsItem.FrmShapeList.Width = 410;
      clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      clsItem.FrmShapeList.Init();
      clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
      clsItem.FrmShapeList.Show();
      clsItem.FrmShapeList.Top = 20;
      clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdStartSimulation(bool Step)
  {
    this.timSim.Interval = clsDrill.varDrillMachineSettings.SimulationIntervalMs;
    clsDrill.varDrillRunSettings.StepRun = Step;
    if (!clsDrill.viewportAuto.IsAnimationRunning)
      clsDrill.viewportAuto.StartAnimation(new int?(clsDrill.varDrillSettings.simulationInterval));
    if (this.indexSim == -1)
      this.indexSim = 0;
    this.timSim.Enabled = true;
    if (!Step)
    {
      clsDrill.varDrillRunSettings.StepRun = false;
      clsDrill.viewportAuto.Entities.ClearSelection();
      clsDrill.viewportAuto.Invalidate();
      clsDrill.varTemps.activeMove.isActive = true;
    }
    else
    {
      if (!(clsDrill.varDrillRunSettings.StepRun & Step))
        return;
      clsDrill.varTemps.simRelease = true;
    }
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
      this.isCollisionRunning = false;
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
    this.indexSim -= clsDrill.varDrillRunSettings.SimStep;
    this.indexSim -= clsDrill.varDrillRunSettings.SimStep;
    this.tick_Simulation((object) null, (EventArgs) null);
  }

  public void cmdGoLineSimulation(int Line)
  {
    if (this.indexSim <= 0)
      return;
    for (int index = 0; index <= clsDrill.activeJob.SimulationMoves.Count - 1; ++index)
    {
      if (clsDrill.activeJob.SimulationMoves[index].LineIndex == Line)
      {
        this.indexSim = index;
        break;
      }
    }
    this.tick_Simulation((object) null, (EventArgs) null);
  }

  public void cmdSaveCode()
  {
    if (clsVar.appModes_0.DemoMode)
    {
      int num = (int) MessageBox.Show("Not Available in Demo Mode");
    }
    else if (ccVars.Pages.Count <= 0)
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
    else if (clsDrill.activeJob == null)
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31 /*0x1F*/]);
    else if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathSaveCode;
      saveFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings.pathSaveCode = buFile5.GetPath(saveFileDialog.FileName);
      this.SaveDrillJobFile(saveFileDialog.FileName, clsDrill.activeJob);
      this.SaveDrillFile();
    }
  }

  public void cmdSaveCodeAll()
  {
    if (clsVar.appModes_0.DemoMode)
    {
      int num = (int) MessageBox.Show("Not Available in Demo Mode");
    }
    else if (ccVars.Pages.Count <= 0)
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
    else if (clsDrill.activeJob == null)
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31 /*0x1F*/]);
    else if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathSaveCode;
      saveFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings.pathSaveCode = buFile5.GetPath(saveFileDialog.FileName);
      this.SaveDrillJobFile(saveFileDialog.FileName, clsDrill.activeJob, true);
      this.SaveDrillFile();
    }
  }

  public void cmdOpenCode()
  {
    if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathOpenCode;
      openFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog.FileName);
      this.OpenDrillJobFile(openFileDialog.FileName, ref clsDrill.activeJob);
    }
  }

  public void cmdOpenCodeAll()
  {
    if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathOpenCode;
      openFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog.FileName);
      this.OpenDrillJobFile(openFileDialog.FileName, ref clsDrill.activeJob, true);
    }
  }

  public bool cmdFileOpenPreview(bool OpenAll = false, string InitPath = "")
  {
    try
    {
      this.openFileDialog_0 = new OpenFileDialog();
      this.openDialogCtrlPreview.Extensions.Clear();
      this.openFileDialog_0.Filter = "AES Drill File (*.AESjob)|*.AESjob";
      this.openDialogCtrlPreview.Extensions.Add("AES Drill File (*.AESjob)|*.AESjob");
      string pathOpenCode = clsDrill.varDrillRunSettings.pathOpenCode;
      int num = 1;
      this.openDialogCtrlPreview.Properties = new FileOpenModes(clsVar.varFile.FileOpenMode);
      clsVar.PreviewLoaded = true;
      this.openDialogCtrlPreview.SubFolder = true;
      this.openDialogCtrlPreview.FileDlgCaption = $"{AppLanguage.CadCamDynamic[32 /*0x20*/]} {AppLanguage.CadCamDynamic[31 /*0x1F*/]}";
      this.openDialogCtrlPreview.FileDlgOkCaption = AppLanguage.CadCamDynamic[31 /*0x1F*/];
      this.openDialogCtrlPreview.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      this.openDialogCtrlPreview.SubFolder = clsVar.varFile.FileOpenMode.SubFolder;
      this.openDialogCtrlPreview.ShowInfoButton = clsVar.varFile.FileOpenMode.ShowInfoButton;
      this.openDialogCtrlPreview.ShowPreviewDisable = clsVar.varFile.FileOpenMode.ShowDisablePreview;
      this.openDialogCtrlPreview.ShowLoading(false);
      this.openDialogCtrlPreview.Init();
      this.openFileDialog_0.AddExtension = true;
      this.openDialogCtrlPreview.PreviewEnable = true;
      this.openFileDialog_0.InitialDirectory = pathOpenCode;
      if (InitPath.Trim().Length > 0)
        this.openFileDialog_0.InitialDirectory = InitPath;
      this.openFileDialog_0.FilterIndex = num;
      this.openFileDialog_0.CheckFileExists = true;
      this.openFileDialog_0.DefaultExt = "bucad";
      this.openFileDialog_0.FileName = "";
      this.openFileDialog_0.DereferenceLinks = true;
      if (this.openFileDialog_0.ShowDialog((FileDialogControlBase) this.openDialogCtrlPreview, (IWin32Window) clsItem.FrmMain) != DialogResult.OK)
        return false;
      clsDrill.varDrillRunSettings.pathOpenCode = buFile5.GetPath(this.openFileDialog_0.FileName);
      this.OpenDrillJobFile(this.openFileDialog_0.FileName, ref clsDrill.activeJob, OpenAll);
      this.SaveDrillFile();
      return true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }

  public void cmdShowCode(bool CreateCode = false, string FileName = "")
  {
    if (clsVar.appModes_0.DemoMode)
    {
      int num = (int) MessageBox.Show("Not Available in Demo Mode");
    }
    else if (ccVars.Pages.Count <= 0)
      buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
    else if (clsDrill.activeJob == null)
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31 /*0x1F*/]);
    else if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      List<string> SL = new List<string>();
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
        this.SaveDrillJobFile(ref SL, clsDrill.activeJob);
      if (this.MachType == DrillMachineType.GoWithAtc)
      {
        this.cGoAtc.CreatCodeFromJobItem(ref clsDrill.activeJob);
        this.cGoAtc.cmdCreateCodes(ref SL, clsDrill.activeJob);
      }
      if (this.MachType == DrillMachineType.Sirius)
      {
        this.cGoSirius.CreatCodeFromJobItem(ref clsDrill.activeJob);
        this.cGoSirius.cmdCreateCodes(ref SL, clsDrill.activeJob);
      }
      string str = buString5.StringListToString(SL, true);
      if (!CreateCode)
      {
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(str);
        fNotepad.Show();
      }
      else
      {
        if (this.MachType == DrillMachineType.GoWithAtc)
          this.cGoAtc.cmdCreateCode(str, FileName);
        if (this.MachType != DrillMachineType.Sirius)
          return;
        this.cGoSirius.cmdCreateCode(str, FileName);
      }
    }
  }

  public void cmdSimilation()
  {
    if (clsDrill.activeJob == null)
      return;
    if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      if (this.frmMachSim == null)
      {
        this.frmMachSim = new F_DrillMachSim();
        this.frmMachSim.ValueChanged += new ValueChangedWithDataEventHandler(this.SimValueChaned);
      }
      if (clsDrill.viewportAuto.Layers.Count != ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count)
      {
        clsDrill.viewportAuto.Layers.Clear();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
          clsDrill.viewportAuto.Layers.Add((Layer) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Clone());
      }
      clsDrill.activeJob.Cams.Clear();
      if (!clsDrill.varDrillCNCSettings.FindFastestPattern)
      {
        if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
          this.cGoUltra2Up1Down.CreatCodeFromJobItem(ref clsDrill.activeJob);
        if (this.MachType == DrillMachineType.GoWithAtc)
          this.cGoAtc.CreatCodeFromJobItem(ref clsDrill.activeJob);
        if (this.MachType == DrillMachineType.Sirius)
          this.cGoSirius.CreatCodeFromJobItem(ref clsDrill.activeJob);
      }
      else
        this.doFindFastestPattern();
      this.indexSim = 0;
      this.frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      this.frmMachSim.MachType = this.MachType;
      this.frmMachSim.Init();
      this.frmMachSim.StartPosition = FormStartPosition.CenterParent;
      int num = (int) this.frmMachSim.ShowDialog();
      this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
      if (this.frmMachSim.PropertiesForm.Result == DialogResult.OK)
        ;
    }
  }

  public void cmdShowToolsCommon()
  {
    if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
        this.cGoUltra2Up1Down.cmdShowTools();
      if (this.MachType == DrillMachineType.GoWithAtc && this.cGoAtc.cmdShowTools())
      {
        this.SaveDrillFile();
        this.SaveToolConfigFile(clsDrill.fileNameToolSetting);
      }
      if (this.MachType != DrillMachineType.Sirius || !this.cGoSirius.cmdShowTools())
        return;
      this.SaveDrillFile();
      this.SaveToolConfigFile(clsDrill.fileNameToolSetting);
    }
  }

  public void cmdShowToolsRecommend()
  {
    if (this.isOperationActive())
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64 /*0x40*/]);
    }
    else
    {
      if (this.FrmTools == null)
        this.FrmTools = new F_Tools();
      this.FrmTools.fileNameLeftTools = AppPath.MachineSimConfig + "\\Tools\\LeftToolGroups.step";
      this.FrmTools.fileNameRightTools = AppPath.MachineSimConfig + "\\Tools\\RightToolGroups.step";
      this.FrmTools.fileNameBottomTools = AppPath.MachineSimConfig + "\\Tools\\BottomToolGroups.step";
      CreateModelProperties createModelProperties = new CreateModelProperties();
      if (this.FrmTools.viewportLeft == null)
      {
        this.FrmTools.viewportLeft = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, new CreateModelProperties()
        {
          CoordinateSystemIconVisible = false,
          OriginSymbolVisible = false,
          ViewCubeIconVisible = false,
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
        this.FrmTools.viewportLeft.Name = "viewportLeft";
        this.FrmTools.pnl_viewportleft.Controls.Add((System.Windows.Forms.Control) this.FrmTools.viewportLeft);
      }
      if (this.FrmTools.viewportRight == null)
      {
        this.FrmTools.viewportRight = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, new CreateModelProperties()
        {
          CoordinateSystemIconVisible = false,
          OriginSymbolVisible = false,
          ViewCubeIconVisible = false,
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
        this.FrmTools.viewportRight.Name = "viewportRight";
        this.FrmTools.pnl_viewportright.Controls.Add((System.Windows.Forms.Control) this.FrmTools.viewportRight);
      }
      if (this.FrmTools.viewportBottom == null)
      {
        this.FrmTools.viewportBottom = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, new CreateModelProperties()
        {
          CoordinateSystemIconVisible = false,
          OriginSymbolVisible = false,
          ViewCubeIconVisible = false,
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
        this.FrmTools.viewportBottom.Name = "viewportBottom";
        this.FrmTools.pnl_viewportbottom.Controls.Add((System.Windows.Forms.Control) this.FrmTools.viewportBottom);
      }
      this.FrmTools.StartPosition = FormStartPosition.CenterParent;
      this.FrmTools.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      this.FrmTools.settingRuntime = new DrillRuntimeSettings(clsDrill.varDrillRunSettings);
      this.FrmTools.Init();
      int num = (int) this.FrmTools.ShowDialog();
      if (this.FrmTools.PropertiesForm.Result != DialogResult.OK)
        return;
      for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
      {
        if (clsDrill.ToolList[index].Data.No == 80 /*0x50*/)
          clsDrill.toolTop = new ToolBase5(clsDrill.ToolList[index]);
        if (clsDrill.ToolList[index].Data.No == 270)
          clsDrill.toolBottom = new ToolBase5(clsDrill.ToolList[index]);
      }
      clsDrill.varDrillRunSettings = new DrillRuntimeSettings(this.FrmTools.settingRuntime);
      this.SaveDrillFile();
      this.SaveToolConfigFile(clsDrill.fileNameToolSetting);
    }
  }

  public void cmdShowSlotSettings()
  {
    try
    {
      F_SlotSettings fSlotSettings = new F_SlotSettings();
      fSlotSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      fSlotSettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
      fSlotSettings.varCNC = new DrillCNCSettings(clsDrill.varDrillCNCSettings);
      fSlotSettings.Init();
      int num = (int) fSlotSettings.ShowDialog();
      if (fSlotSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      clsDrill.varDrillCNCSettings = fSlotSettings.varCNC;
      this.SaveDrillFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdShowCNCSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = buLangTranslate.preDef.Setting;
      classViewerDialog.Value = (object) clsDrill.varDrillCNCSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 700;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      clsDrill.varDrillCNCSettings = new DrillCNCSettings((DrillCNCSettings) classViewerDialog.Value);
      this.SaveDrillFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdShowSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = buLangTranslate.preDef.Setting;
      classViewerDialog.Value = (object) clsDrill.varDrillSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      clsDrill.varDrillSettings = new DrillSettings((DrillSettings) classViewerDialog.Value);
      this.SaveDrillFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdShowMachineSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = $"{buLangTranslate.preDef.Machine} {buLangTranslate.preDef.Setting}";
      classViewerDialog.Value = (object) clsDrill.varDrillMachineSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      clsDrill.varDrillMachineSettings = new DrillMachineSettings((DrillMachineSettings) classViewerDialog.Value);
      this.SaveDrillFile();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdRender()
  {
    try
    {
      Entity entPanel = (Entity) null;
      this.DrawAsRenderFromJob(clsDrill.activeJob, ref entPanel);
      if (entPanel == null)
        return;
      if (clsItem.FrmPreview == null)
      {
        clsItem.FrmPreview = new F_Preview();
        CreateModelProperties Properties = new CreateModelProperties();
        clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
        Properties.CoordinateSystemIconVisible = false;
        Properties.ViewCubeIconVisible = true;
        Properties.OrigineCaptionVisible = false;
        Properties.ToolBorVisible = false;
        Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
        Properties.OriginSymbolVisible = false;
        Properties.OrigineSize = 3;
        clsItem.FrmPreview.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
        clsItem.FrmDrillList.viewportLayout.CompileUserInterfaceElements();
      }
      FileInfo fileInfo = new FileInfo(clsVar.varInterface.fileTexture);
      if (fileInfo.Exists)
      {
        this.CreateMaterialsAndLayers(fileInfo.FullName);
        entPanel.LayerName = "Wood";
      }
      clsItem.FrmPreview.viewportLayout.ActiveViewport.DisplayMode = displayType.Rendered;
      clsItem.FrmPreview.viewportLayout.Entities.Clear();
      entPanel.ColorMethod = colorMethodType.byLayer;
      clsItem.FrmPreview.viewportLayout.Entities.Add(entPanel);
      clsItem.FrmPreview.viewportLayout.SetView(viewType.Trimetric, true, false);
      clsItem.FrmPreview.Init();
      clsItem.FrmPreview.Show();
      clsItem.FrmPreview.viewportLayout.Invalidate();
      clsItem.FrmPreview.Focus();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdGetDrillsFrom3D()
  {
    try
    {
      List<Entity> selectedEntities = new List<Entity>();
      clsInit.appCommand.SelectionToEntities(ref selectedEntities, new SelectionOption()
      {
        Text = false,
        Point = false
      });
      if (selectedEntities.Count == 0)
      {
        if (clsItem.FrmFromFile == null)
          clsItem.FrmFromFile = new F_AddFromFile();
        clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
        clsItem.FrmFromFile.Path = clsDrill.varDrillRunSettings.path3DJob;
        clsItem.FrmFromFile.KeepRatio = clsDrill.varDrillRunSettings.EngravingKeepRatio;
        clsItem.FrmFromFile.ExtensionList.Clear();
        clsItem.FrmFromFile.ExtensionList.Add(".step");
        clsItem.FrmFromFile.ExtensionList.Add(".stp");
        clsItem.FrmFromFile.ExtensionList.Add(".iges");
        clsItem.FrmFromFile.ExtensionList.Add(".igs");
        clsItem.FrmFromFile.ExtensionList.Add(".bucadv5");
        clsItem.FrmFromFile.Init();
        int num = (int) clsItem.FrmFromFile.ShowDialog();
        if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
          return;
        clsDrill.varDrillRunSettings.path3DJob = clsItem.FrmFromFile.Path;
        List<Entity> EL = new List<Entity>();
        for (int index = 0; index <= clsItem.FrmFromFile.viewport.Entities.Count - 1; ++index)
        {
          Entity copiedEntity = (Entity) null;
          if (clsItem.FrmFromFile.viewport.Entities[index] is Brep)
          {
            buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
            EL.Add(copiedEntity);
          }
          else if (clsItem.FrmFromFile.viewport.Entities[index] is Solid)
          {
            buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[index], ref copiedEntity);
            EL.Add(copiedEntity);
          }
        }
        this.doGetDrill(EL);
        this.SaveDrillFile();
      }
      else
        this.doGetDrill(selectedEntities);
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdGetDrillsFromCabinet()
  {
    try
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.path3DJob;
      openFileDialog.Filter = "Cabinet AES File (*.AESNC)|*.AESNC";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.OpenCabinetFile(openFileDialog.FileName, ref clsDrill.activeJob);
      clsDrill.varDrillRunSettings.path3DJob = buFile5.GetPath(openFileDialog.FileName);
      this.SaveDrillFile();
    }
    catch (Exception ex)
    {
    }
  }

  public bool cmdFileOpenFromCabinetPreview(bool OpenAll = false, string InitPath = "")
  {
    try
    {
      this.openFileDialog_0 = new OpenFileDialog();
      this.openDialogCtrlPreview.Extensions.Clear();
      this.openFileDialog_0.Filter = "AES Drill File (*.AESNC)|*.AESNC";
      this.openDialogCtrlPreview.Extensions.Add("AES Drill File (*.AESNC)|*.AESNC");
      string pathOpenCode = clsDrill.varDrillRunSettings.pathOpenCode;
      int num = 1;
      this.openDialogCtrlPreview.Properties = new FileOpenModes(clsVar.varFile.FileOpenMode);
      clsVar.PreviewLoaded = true;
      this.openDialogCtrlPreview.SubFolder = true;
      this.openDialogCtrlPreview.FileDlgCaption = $"{AppLanguage.CadCamDynamic[32 /*0x20*/]} {AppLanguage.CadCamDynamic[31 /*0x1F*/]}";
      this.openDialogCtrlPreview.FileDlgOkCaption = AppLanguage.CadCamDynamic[31 /*0x1F*/];
      this.openDialogCtrlPreview.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      this.openDialogCtrlPreview.SubFolder = clsVar.varFile.FileOpenMode.SubFolder;
      this.openDialogCtrlPreview.ShowInfoButton = clsVar.varFile.FileOpenMode.ShowInfoButton;
      this.openDialogCtrlPreview.ShowPreviewDisable = clsVar.varFile.FileOpenMode.ShowDisablePreview;
      this.openDialogCtrlPreview.ShowLoading(false);
      this.openDialogCtrlPreview.Init();
      this.openFileDialog_0.AddExtension = true;
      this.openDialogCtrlPreview.PreviewEnable = true;
      this.openFileDialog_0.InitialDirectory = pathOpenCode;
      if (InitPath.Trim().Length > 0)
        this.openFileDialog_0.InitialDirectory = InitPath;
      this.openFileDialog_0.FilterIndex = num;
      this.openFileDialog_0.CheckFileExists = true;
      this.openFileDialog_0.DefaultExt = "bucad";
      this.openFileDialog_0.FileName = "";
      this.openFileDialog_0.DereferenceLinks = true;
      if (this.openFileDialog_0.ShowDialog((FileDialogControlBase) this.openDialogCtrlPreview, (IWin32Window) clsItem.FrmMain) != DialogResult.OK)
        return false;
      clsDrill.varDrillRunSettings.pathOpenCode = buFile5.GetPath(this.openFileDialog_0.FileName);
      this.OpenCabinetFile(this.openFileDialog_0.FileName, ref clsDrill.activeJob);
      return true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }

  public void cmdFileCabinetConversion()
  {
    try
    {
      if (new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathImport).Exists)
        clsDrill.varDrillRunSettings.pathOpenCode = clsDrill.varDrillRunSettings.CabinetpathImport;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.pathOpenCode;
      openFileDialog.Filter = "Cabinet Job List(*.txt)|*.txt";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog.FileName);
      this.OpenCabinetJobListFile(openFileDialog.FileName);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdFileCabinetSettings()
  {
    try
    {
      F_CabinetSettings fCabinetSettings = new F_CabinetSettings();
      fCabinetSettings.Settings = new DrillRuntimeSettings(clsDrill.varDrillRunSettings);
      fCabinetSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
      fCabinetSettings.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
      fCabinetSettings.Init();
      int num = (int) fCabinetSettings.ShowDialog();
      if (fCabinetSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings = new DrillRuntimeSettings(fCabinetSettings.Settings);
      this.SaveDrillFile();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdFileCabinetCycle()
  {
    try
    {
      this.FrmCabinetCycle = new F_CabinetCycle();
      this.FrmCabinetCycle.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      this.FrmCabinetCycle.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
      this.FrmCabinetCycle.Init();
      this.timCabinetCycle.Enabled = true;
      int num = (int) this.FrmCabinetCycle.ShowDialog();
      this.timCabinetCycle.Enabled = false;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdGetDrillsFromCyncly()
  {
    try
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.path3DJob;
      openFileDialog.Filter = "Cyncly AES File (*.xml)|*.xml";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings.path3DJob = buFile5.GetPath(openFileDialog.FileName);
      this.SaveDrillFile();
      this.OpenCynClyFile(openFileDialog.FileName, ref clsDrill.activeJob);
    }
    catch (Exception ex)
    {
    }
  }

  public bool cmdFileOpenFromCorpusPreview(bool OpenAll = false, string InitPath = "")
  {
    try
    {
      this.openFileDialog_0 = new OpenFileDialog();
      this.openDialogCtrlPreview.Extensions.Clear();
      this.openFileDialog_0.Filter = "Corpus Drill File (*.dxf)|*.dxf";
      this.openDialogCtrlPreview.Extensions.Add("Corpus Drill File (*.dxf)|*.dxf");
      string pathOpenCode = clsDrill.varDrillRunSettings.pathOpenCode;
      int num = 1;
      this.openDialogCtrlPreview.Properties = new FileOpenModes(clsVar.varFile.FileOpenMode);
      clsVar.PreviewLoaded = true;
      this.openDialogCtrlPreview.SubFolder = true;
      this.openDialogCtrlPreview.FileDlgCaption = $"{AppLanguage.CadCamDynamic[32 /*0x20*/]} {AppLanguage.CadCamDynamic[31 /*0x1F*/]}";
      this.openDialogCtrlPreview.FileDlgOkCaption = AppLanguage.CadCamDynamic[31 /*0x1F*/];
      this.openDialogCtrlPreview.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      this.openDialogCtrlPreview.SubFolder = clsVar.varFile.FileOpenMode.SubFolder;
      this.openDialogCtrlPreview.ShowInfoButton = clsVar.varFile.FileOpenMode.ShowInfoButton;
      this.openDialogCtrlPreview.ShowPreviewDisable = clsVar.varFile.FileOpenMode.ShowDisablePreview;
      this.openDialogCtrlPreview.ShowLoading(false);
      this.openDialogCtrlPreview.Init();
      this.openFileDialog_0.AddExtension = true;
      this.openDialogCtrlPreview.PreviewEnable = true;
      this.openFileDialog_0.InitialDirectory = pathOpenCode;
      if (InitPath.Trim().Length > 0)
        this.openFileDialog_0.InitialDirectory = InitPath;
      this.openFileDialog_0.FilterIndex = num;
      this.openFileDialog_0.CheckFileExists = true;
      this.openFileDialog_0.DefaultExt = "dxf";
      this.openFileDialog_0.FileName = "";
      this.openFileDialog_0.DereferenceLinks = true;
      if (this.openFileDialog_0.ShowDialog((FileDialogControlBase) this.openDialogCtrlPreview, (IWin32Window) clsItem.FrmMain) != DialogResult.OK)
        return false;
      clsDrill.varDrillRunSettings.pathOpenCode = buFile5.GetPath(this.openFileDialog_0.FileName);
      this.OpenCorpusFile(this.openFileDialog_0.FileName, ref clsDrill.activeJob);
      return true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return false;
    }
  }

  public void cmdGetDrillsFromCorpus()
  {
    try
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = clsDrill.varDrillRunSettings.path3DJob;
      openFileDialog.Filter = "Cyncly AES File (*.xml)|*.xml";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      clsDrill.varDrillRunSettings.path3DJob = buFile5.GetPath(openFileDialog.FileName);
      this.SaveDrillFile();
      this.OpenCynClyFile(openFileDialog.FileName, ref clsDrill.activeJob);
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdJobList()
  {
    try
    {
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdZoomFit(drillViewports ViewportType)
  {
    if (ViewportType == drillViewports.Simulation)
      buEyeShotFunctions.ZoomFit(ref clsDrill.viewportAuto);
    if (ViewportType == drillViewports.Edit && this.frmEdit != null)
      buEyeShotFunctions.ZoomFit(ref clsDrill.viewportEdit);
    if (ViewportType != drillViewports.List || this.frmList == null)
      return;
    buEyeShotFunctions.ZoomFit(ref clsDrill.viewportList);
  }

  public void cmdSetView(viewType Type, drillViewports ViewportType)
  {
    switch (Type)
    {
      case viewType.Front:
        if (ViewportType == drillViewports.Simulation)
          buEyeShotFunctions.Viewfront(ref clsDrill.viewportAuto, false);
        if (ViewportType == drillViewports.Edit)
          buEyeShotFunctions.Viewfront(ref clsDrill.viewportEdit, false);
        if (ViewportType == drillViewports.List)
          buEyeShotFunctions.Viewfront(ref clsDrill.viewportList, false);
        clsInit.appDrill.planeActive = Plane.XZ;
        break;
      case viewType.Right:
        if (ViewportType == drillViewports.Simulation)
          buEyeShotFunctions.ViewRight(ref clsDrill.viewportAuto, false);
        if (ViewportType == drillViewports.Edit)
          buEyeShotFunctions.ViewRight(ref clsDrill.viewportEdit, false);
        if (ViewportType == drillViewports.List)
          buEyeShotFunctions.ViewRight(ref clsDrill.viewportList, false);
        clsInit.appDrill.planeActive = Plane.YZ;
        break;
      case viewType.Rear:
        if (ViewportType == drillViewports.Simulation)
          buEyeShotFunctions.ViewBack(ref clsDrill.viewportAuto, false);
        if (ViewportType == drillViewports.Edit)
          buEyeShotFunctions.ViewBack(ref clsDrill.viewportEdit, false);
        if (ViewportType == drillViewports.List)
          buEyeShotFunctions.ViewBack(ref clsDrill.viewportList, false);
        clsInit.appDrill.planeActive = Plane.XZ;
        break;
      case viewType.Left:
        if (ViewportType == drillViewports.Simulation)
          buEyeShotFunctions.ViewLeft(ref clsDrill.viewportAuto, false);
        if (ViewportType == drillViewports.Edit)
          buEyeShotFunctions.ViewLeft(ref clsDrill.viewportEdit, false);
        if (ViewportType == drillViewports.List)
          buEyeShotFunctions.ViewLeft(ref clsDrill.viewportList, false);
        clsInit.appDrill.planeActive = Plane.YZ;
        break;
      case viewType.Top:
        if (ViewportType == drillViewports.Simulation)
          buEyeShotFunctions.ViewTop(ref clsDrill.viewportAuto, false);
        if (ViewportType == drillViewports.Edit)
          buEyeShotFunctions.ViewTop(ref clsDrill.viewportEdit, false);
        if (ViewportType == drillViewports.List)
          buEyeShotFunctions.ViewTop(ref clsDrill.viewportList, false);
        clsInit.appDrill.planeActive = Plane.XY;
        break;
      case viewType.Bottom:
        if (ViewportType == drillViewports.Simulation)
          buEyeShotFunctions.ShowViewportViewBox(ref clsDrill.viewportAuto, false);
        if (ViewportType == drillViewports.Edit)
          buEyeShotFunctions.ShowViewportViewBox(ref clsDrill.viewportEdit, false);
        if (ViewportType == drillViewports.List)
          buEyeShotFunctions.ShowViewportViewBox(ref clsDrill.viewportList, false);
        clsInit.appDrill.planeActive = Plane.XY;
        break;
      default:
        if (ViewportType == drillViewports.Simulation)
          buEyeShotFunctions.ViewIso(ref clsDrill.viewportAuto, false);
        if (ViewportType == drillViewports.Edit)
          buEyeShotFunctions.ViewIso(ref clsDrill.viewportEdit, false);
        if (ViewportType == drillViewports.List)
          buEyeShotFunctions.ViewIso(ref clsDrill.viewportList, false);
        clsInit.appDrill.planeActive = Plane.XY;
        break;
    }
  }

  public void cmdMenuCommand(object sender, EventArgs e)
  {
    string str = "";
    bool flag1 = false;
    if (sender is System.Windows.Forms.Control)
      str = (sender as System.Windows.Forms.Control).Name;
    else if (sender is ToolStripMenuItem)
      str = (sender as ToolStripMenuItem).Name;
    if (str == clsItem.FrmDrillJob.mnu_addpanel.Name)
      this.cmdNewMaterial((DrillJob) null);
    if (str == clsItem.FrmDrillJob.mnu_deletepanel.Name && clsDrill.JobList.Count > 0 && this.selectedJobIndex >= 0 && buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[23]) == DialogResult.Yes)
      this.doDeletePanel(this.selectedJobIndex);
    if (str == clsItem.FrmDrillJob.mnu_editpanel.Name && this.selectedJobIndex >= 0)
      this.cmdNewMaterial(clsDrill.activeJob);
    if (str == clsItem.FrmDrillJob.mnu_renamepanel.Name && this.selectedJobIndex >= 0)
    {
      DialogBoxText dialogBoxText = new DialogBoxText();
      dialogBoxText.Caption = $"{AppLanguage.CadCamDynamic[112 /*0x70*/]} {AppLanguage.CadCamDynamic[40]}";
      dialogBoxText.Text = $"{AppLanguage.CadCamDynamic[112 /*0x70*/]} {AppLanguage.CadCamDynamic[40]}";
      dialogBoxText.Init(clsDrill.activeJob.Name);
      int num = (int) dialogBoxText.ShowDialog();
      if (dialogBoxText.Result == DialogResult.OK)
      {
        clsDrill.activeJob.Name = dialogBoxText.Value.Trim();
        if (clsItem.FrmDrillJob.tree_jobs.Nodes.Count > 0)
        {
          clsItem.FrmDrillJob.tree_jobs.Nodes[0].Text = this.JobToString(clsDrill.activeJob);
          ((buCadCamResVer5.TreeNodeSettings) clsItem.FrmDrillJob.tree_jobs.Nodes[0]).Info = this.JobToString(clsDrill.activeJob);
        }
      }
    }
    if (str == clsItem.FrmDrillJob.mnu_removeoperation.Name && clsDrill.activeJob != null)
    {
      if (this.selectedJobIndex >= 0 & this.selectedItemIndex >= 0 & this.selectedItemSubIndex == -1)
      {
        if (buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[24]) == DialogResult.Yes)
          this.doDeleteOperation(this.selectedJobIndex, this.selectedItemIndex, this.selectedItemSubIndex);
      }
      else if (this.selectedJobIndex >= 0 & this.selectedItemIndex >= 0 & this.selectedItemSubIndex >= 0 && buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[24]) == DialogResult.Yes)
        this.doDeleteOperation(this.selectedJobIndex, this.selectedItemIndex, this.selectedItemSubIndex);
    }
    if (str == clsItem.FrmDrillJob.mnu_removealloperation.Name && clsDrill.activeJob != null && buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[18]) == DialogResult.Yes)
      this.doDeletaAllOperations();
    if (str == clsItem.FrmDrillJob.mnu_editoperation.Name && this.selectedJobIndex >= 0 & this.selectedItemIndex >= 0)
      this.doEditOperation();
    bool flag2 = false;
    if (str == clsItem.FrmDrillJob.mnu_alldrilldisable.Name)
    {
      clsInit.cDrill.EnableDisableOperations(false, ref clsDrill.activeJob, true, false, false, false, false, false, false, false, false);
      flag2 = true;
    }
    if (str == clsItem.FrmDrillJob.mnu_alldrillenable.Name)
    {
      clsInit.cDrill.EnableDisableOperations(true, ref clsDrill.activeJob, true, false, false, false, false, false, false, false, false);
      flag2 = true;
    }
    if (str == clsItem.FrmDrillJob.mnu_allslotdisable.Name)
    {
      clsInit.cDrill.EnableDisableOperations(false, ref clsDrill.activeJob, false, false, true, false, false, false, false, false, false);
      flag2 = true;
    }
    if (str == clsItem.FrmDrillJob.mnu_allslotenable.Name)
    {
      clsInit.cDrill.EnableDisableOperations(true, ref clsDrill.activeJob, false, false, true, false, false, false, false, false, false);
      flag2 = true;
    }
    if (str == clsItem.FrmDrillJob.mnu_allshapedisable.Name)
    {
      clsInit.cDrill.EnableDisableOperations(false, ref clsDrill.activeJob, false, true, false, false, false, false, false, false, false);
      flag2 = true;
    }
    if (str == clsItem.FrmDrillJob.mnu_allshapeenable.Name)
    {
      clsInit.cDrill.EnableDisableOperations(true, ref clsDrill.activeJob, false, true, false, false, false, false, false, false, false);
      flag2 = true;
    }
    if (str == clsItem.FrmDrillJob.mnu_disableoperation.Name && this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1)
    {
      if (!clsDrill.activeJob.Items[this.selectedItemIndex].Enable)
        clsInit.cDrill.EnableDisableOperation(true, ref clsDrill.activeJob, this.selectedItemIndex);
      else
        clsInit.cDrill.EnableDisableOperation(false, ref clsDrill.activeJob, this.selectedItemIndex);
      flag2 = true;
    }
    if (flag2)
    {
      this.JobUpdate(true, (DrillItem) null);
      this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
    }
    flag1 = false;
    if (str == clsItem.FrmDrillJob.mnu_copyoperation.Name && clsDrill.activeJob != null && this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1)
      this.doCopyOperation();
    if (str == clsItem.FrmDrillJob.mnu_mirroroperation.Name && clsDrill.activeJob != null && this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1)
      this.doMirrorOperation();
    if (str == clsItem.FrmDrillJob.mnu_rotatepanel.Name && clsDrill.activeJob != null)
      this.doRotateOperation();
    if (str == clsItem.FrmDrillJob.mnu_upmove.Name)
      this.doOperationMoveUp();
    if (!(str == clsItem.FrmDrillJob.mnu_downmove.Name))
      return;
    this.doOperationMoveDown();
  }

  public void CollisionCheck()
  {
    clsDrill.collisionDetection_0 = new CollisionDetection((IList<Entity>) clsDrill.SimToCollsionCheck1, (IList<Entity>) clsDrill.SimToCollsionCheck2, clsDrill.viewportAuto.Blocks, false, collisionCheckType.SubdivisionTree);
    if (this.isCollisionRunning)
      return;
    this.isCollisionRunning = true;
    if (!clsDrill.varDrillRunSettings.CollisionCheck)
      return;
    clsDrill.viewportAuto.StartWork((WorkUnit) clsDrill.collisionDetection_0);
  }

  private void method_0(object sender, WorkCompletedEventArgs e)
  {
    try
    {
      this.isCollisionRunning = false;
      if (!(e.WorkUnit is CollisionDetection))
        return;
      CollisionDetection workUnit = e.WorkUnit as CollisionDetection;
      if (workUnit.Result != null)
      {
        if (workUnit.Result.Length == 0)
          return;
        Class5.smethod_119(this, (IList<CollisionResult>) workUnit.Result);
        clsDrill.viewportAuto.Invalidate();
      }
      else
        clsDrill.viewportAuto.TempEntities.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  private void method_1(object sender, WorkFailedEventArgs e)
  {
    this.isCollisionRunning = false;
    clsDrill.viewportAuto.TempEntities.Clear();
  }

  private void method_2(object sender, EventArgs e)
  {
    this.isCollisionRunning = false;
    clsDrill.viewportAuto.TempEntities.Clear();
  }

  public void mouseMoveVierport(object sender, MouseEventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == clsDrill.viewportAuto.Name)
    {
      Point3D intPoint = new Point3D();
      clsDrill.viewportAuto.ScreenToPlane(e.Location, clsInit.appDrill.planeActive, out intPoint);
      if (intPoint != (Point3D) null)
      {
        this.frmMachSim.lbl_x.Text = "X: " + intPoint.X.ToString("f3");
        this.frmMachSim.lbl_y.Text = "Y: " + intPoint.Y.ToString("f3");
        this.frmMachSim.lbl_z.Text = "Z: " + intPoint.Z.ToString("f3");
      }
    }
    if (this.frmEdit != null && control2.Name == clsDrill.viewportEdit.Name)
    {
      Point3D intPoint = new Point3D();
      clsDrill.viewportEdit.ScreenToPlane(e.Location, clsInit.appDrill.planeActive, out intPoint);
      if (intPoint != (Point3D) null)
      {
        this.frmEdit.lbl_x.Text = "X: " + intPoint.X.ToString("f3");
        this.frmEdit.lbl_y.Text = "Y: " + intPoint.Y.ToString("f3");
        this.frmEdit.lbl_z.Text = "Z: " + intPoint.Z.ToString("f3");
      }
    }
    if (this.frmList == null || !(control2.Name == clsDrill.viewportList.Name))
      return;
    Point3D intPoint1 = new Point3D();
    clsDrill.viewportList.ScreenToPlane(e.Location, clsInit.appDrill.planeActive, out intPoint1);
    if (!(intPoint1 != (Point3D) null))
      return;
    this.frmList.lbl_x.Text = "X: " + intPoint1.X.ToString("f3");
    this.frmList.lbl_y.Text = "Y: " + intPoint1.Y.ToString("f3");
    this.frmList.lbl_z.Text = "Z: " + intPoint1.Z.ToString("f3");
  }

  public void mouseDownVierport(object sender, MouseEventArgs e)
  {
  }

  public void viewportMouseDown(Point3D Points, object sender, MouseEventArgs e)
  {
    if ((e.Button != MouseButtons.Left || ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode != devDept.Eyeshot.actionType.None ? 1 : (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Viewports[0].ToolBar.Contains(e.Location) ? 1 : 0)) != 0)
      return;
    this.entityIndex = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.GetEntityUnderMouseCursor(e.Location);
    if (this.entityIndex < 0)
      return;
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex].EntityData != null)
    {
      if (((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex].EntityData).typeDefination != entityTypeDefination.Clamper)
      {
        this.entityIndex = -1;
      }
      else
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, new Plane(), out this.point3D_0);
        this.point3D_1 = new Point3D(this.point3D_0.X, this.point3D_0.Y, this.point3D_0.Z);
        ccVars.selectionProcess = false;
      }
    }
    else
      this.entityIndex = -1;
  }

  public void viewportMouseUp(Point3D Points, object sender, MouseEventArgs e)
  {
    if (clsDrill.activeJob == null)
      return;
    if (this.entityIndex >= 0 && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex].EntityData != null)
    {
      CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex].EntityData as CustomData;
      if (entityData.typeDefination == entityTypeDefination.Clamper)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, new Plane(), out this.point3D_2);
        int refIndex = entityData.RefIndex;
        if (entityData.RefIndex == 2)
        {
          buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex], ref clsDrill.activeJob.SecondClamperEntity);
          clsDrill.activeJob.SecondClamperX = Points.X;
          Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex - 1];
          Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex];
          entity1.Regen(0.1);
          entity2.Regen(0.1);
          if (entity2.BoxMin.X - entity1.BoxMax.X < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          {
            double num = entity1.BoxMax.X - entity2.BoxMin.X;
            double dx = clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + num;
            entity2.Translate(dx, 0.0);
            entity2.Regen(0.1);
          }
          if (entity2.BoxMax == (Point3D) null)
            entity2.Regen(0.01);
          clsDrill.activeJob.SecondClamperX = (entity2.BoxMax.X + entity2.BoxMin.X) / 2.0;
          clsDrill.activeJob.ClampesSetByManuelly = true;
        }
        if (entityData.RefIndex == 1)
        {
          buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex], ref clsDrill.activeJob.FirstClamperEntity);
          clsDrill.activeJob.FirstClamperX = Points.X;
          Entity entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex];
          Entity entity4 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex + 1];
          entity3.Regen(0.1);
          entity4.Regen(0.1);
          if (entity4.BoxMin.X - entity3.BoxMax.X < clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
          {
            double num1 = entity3.BoxMax.X - entity4.BoxMin.X;
            double num2 = clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance + num1;
            entity3.Translate(-num2, 0.0);
            entity4.Regen(0.1);
          }
          if (entity4.BoxMax == (Point3D) null)
            entity4.Regen(0.01);
          if (entity3.BoxMax == (Point3D) null)
            entity3.Regen(0.01);
          clsDrill.activeJob.FirstClamperX = (entity3.BoxMax.X + entity3.BoxMin.X) / 2.0;
          clsDrill.activeJob.ClampesSetByManuelly = true;
        }
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
      }
    }
    this.entityIndex = -1;
    ViewportCC.buttonPressedForSelection = false;
    ccVars.selectionProcess = true;
  }

  public void viewportMouseMove(Point3D Points, object sender, MouseEventArgs e)
  {
    Point3D intPoint1 = new Point3D();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, this.planeActive, out intPoint1);
    if (this.entityIndex == -1)
      return;
    Entity entity1 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex];
    double num1 = 0.0;
    double num2 = 0.0;
    Entity entity2 = (Entity) null;
    Entity entity3 = (Entity) null;
    if (this.entityIndex == 1)
    {
      entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex];
      entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex + 1];
    }
    if (this.entityIndex == 2)
    {
      entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex - 1];
      entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[this.entityIndex];
    }
    if (entity2.BoxMin != (Point3D) null)
    {
      double x = entity2.BoxMin.X;
      num1 = entity2.BoxMax.X;
    }
    if (entity3.BoxMin != (Point3D) null)
    {
      num2 = entity3.BoxMin.X;
      double x = entity3.BoxMax.X;
    }
    Point3D intPoint2;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, new Plane(), out intPoint2);
    if (this.point3D_0 != (Point3D) null)
    {
      double num3 = intPoint2.X - this.point3D_0.X;
      if (this.entityIndex == 1)
      {
        if (num2 - num1 > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          Vector3D v = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(this.point3D_0.X, 0.0, 0.0));
          entity1.Translate(v);
          this.point3D_0 = intPoint2;
        }
        else if (num3 < -clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          Vector3D v = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(this.point3D_0.X, 0.0, 0.0));
          entity1.Translate(v);
          this.point3D_0 = intPoint2;
        }
      }
      if (this.entityIndex == 2)
      {
        if (num2 - num1 > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          Vector3D v = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(this.point3D_0.X, 0.0, 0.0));
          entity1.Translate(v);
          this.point3D_0 = intPoint2;
        }
        else if (num3 > clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          Vector3D v = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(this.point3D_0.X, 0.0, 0.0));
          entity1.Translate(v);
          this.point3D_0 = intPoint2;
        }
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void SimValueChaned(double Value, object Data)
  {
    if (Data == null || !(Data.ToString() == "Track"))
      return;
    clsDrill.varDrillRunSettings.SimStep = (int) Value;
  }

  public void tick_Simulation(object sender, EventArgs e)
  {
    if (!(!clsDrill.varDrillRunSettings.StepRun | clsDrill.varDrillRunSettings.StepRun & clsDrill.varTemps.simRelease))
      return;
    clsDrill.varTemps.simRelease = false;
    if (clsDrill.activeJob != null)
    {
      if (this.indexSim >= 0 & this.indexSim <= clsDrill.activeJob.SimulationMoves.Count - 1)
      {
        if (clsDrill.varDrillRunSettings.SimStopAtMatReady & clsDrill.activeJob.SimulationMoves[this.indexSim].Command == DrillMoveCommand.Wait)
          clsDrill.varDrillRunSettings.StepRun = true;
        clsDrill.varTemps.acliveLine = clsDrill.activeJob.SimulationMoves[this.indexSim].LineIndex;
        if (this.indexSim >= 0 & this.indexSim <= clsDrill.activeJob.SimulationMoves.Count - 1)
        {
          clsDrill.varTemps.activeMove = new DrillMove(clsDrill.activeJob.SimulationMoves[this.indexSim]);
          if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
            this.cGoUltra2Up1Down.MoveSimPart(clsDrill.activeJob.SimulationMoves[this.indexSim]);
          if (this.MachType == DrillMachineType.GoWithAtc)
            this.cGoAtc.MoveSimPart(clsDrill.activeJob.SimulationMoves[this.indexSim]);
          if (this.MachType == DrillMachineType.Sirius)
            this.cGoSirius.MoveSimPart(clsDrill.activeJob.SimulationMoves[this.indexSim]);
          if (this.frmMachSim != null)
          {
            this.frmMachSim.lbl_x1.Text = "X1: " + clsDrill.activeJob.SimulationMoves[this.indexSim].X1Clamper.ToString("f2");
            this.frmMachSim.lbl_x2.Text = "X2: " + clsDrill.activeJob.SimulationMoves[this.indexSim].X2Clamper.ToString("f2");
            this.frmMachSim.lbl_y1.Text = "Y1: " + clsDrill.activeJob.SimulationMoves[this.indexSim].Y1Position.ToString("f2");
            this.frmMachSim.lbl_y2.Text = "Y2: " + clsDrill.activeJob.SimulationMoves[this.indexSim].Y2Position.ToString("f2");
            this.frmMachSim.lbl_y3.Text = "Y3: " + clsDrill.activeJob.SimulationMoves[this.indexSim].Y3Position.ToString("f2");
            this.frmMachSim.lbl_z1.Text = "Z1: " + clsDrill.activeJob.SimulationMoves[this.indexSim].Z1Position.ToString("f2");
            this.frmMachSim.lbl_z2.Text = "Z2: " + clsDrill.activeJob.SimulationMoves[this.indexSim].Z2Position.ToString("f2");
            this.frmMachSim.lbl_z3.Text = "Z3: " + clsDrill.activeJob.SimulationMoves[this.indexSim].Z3Position.ToString("f2");
          }
          if (!this.isCollisionRunning)
            this.indexCollision = this.indexSim;
          this.CollisionCheck();
        }
        this.indexSim += clsDrill.varDrillRunSettings.SimStep;
        clsDrill.varTemps.activeMove.isActive = true;
      }
      else
      {
        this.indexSim = -1;
        this.timSim.Enabled = false;
        clsDrill.varTemps.activeMove.isActive = false;
        clsDrill.varTemps.acliveLine = -1;
      }
    }
    else
    {
      clsDrill.varTemps.activeMove.isActive = false;
      clsDrill.varTemps.acliveLine = -1;
      this.timSim.Enabled = false;
    }
    if (this.frmMachSim == null)
      return;
    if (clsDrill.varTemps.acliveLine > 0 & clsDrill.varTemps.acliveLine <= this.frmMachSim.txt_gcode.TextSource.Count - 1)
    {
      this.frmMachSim.txt_gcode.Selection.Start = new Place()
      {
        iLine = clsDrill.varTemps.acliveLine
      };
      Place place = new Place();
      place.iLine = clsDrill.varTemps.acliveLine + 1;
      this.frmMachSim.txt_gcode.Selection.End = place;
      this.frmMachSim.txt_gcode.Refresh();
      if (place.iLine <= this.frmMachSim.txt_gcode.Lines.Count - 1)
        this.frmMachSim.txt_gcode.DoSelectionVisible();
    }
    if (!(clsDrill.varTemps.acliveLine == -1 & this.frmMachSim.txt_gcode.TextSource.Count > 0))
      return;
    this.frmMachSim.txt_gcode.Selection.Start = new Place()
    {
      iLine = 0
    };
    Place place1 = new Place();
    place1.iLine = 1;
    this.frmMachSim.txt_gcode.Selection.End = place1;
    this.frmMachSim.txt_gcode.Refresh();
    if (place1.iLine > this.frmMachSim.txt_gcode.Lines.Count - 1)
      return;
    this.frmMachSim.txt_gcode.DoSelectionVisible();
  }

  public void AddCornerArrow(DrillItemBase Data)
  {
    CustomData customData = new CustomData();
    Vector3D VectorX = new Vector3D(0.0, 0.0, 0.0);
    Vector3D VectorY = new Vector3D(0.0, 0.0, 0.0);
    Vector3D VectorZ = new Vector3D(0.0, 0.0, 0.0);
    clsInit.cVector5.Vector3DToVectorXYZ(Data.CornerDirection, ref VectorX, ref VectorY, ref VectorZ);
    if (VectorX.X != 0.0)
    {
      Mesh arrow = Mesh.CreateArrow(Data.CornerPoint, VectorX, clsDrill.varDrillSettings.CornerArrowDiameter / 2.0, clsDrill.varDrillSettings.CornerArrowLength, clsDrill.varDrillSettings.CornerArrowConeDiameter / 2.0, clsDrill.varDrillSettings.CornerArrowConeLength, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
      arrow.Color = clsDrill.varDrillSettings.CornerArrowXColor;
      arrow.ColorMethod = colorMethodType.byEntity;
      arrow.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Temp
      };
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) arrow);
    }
    if (VectorY.Y != 0.0)
    {
      Mesh arrow = Mesh.CreateArrow(Data.CornerPoint, VectorY, clsDrill.varDrillSettings.CornerArrowDiameter / 2.0, clsDrill.varDrillSettings.CornerArrowLength, clsDrill.varDrillSettings.CornerArrowConeDiameter / 2.0, clsDrill.varDrillSettings.CornerArrowConeLength, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
      arrow.Color = clsDrill.varDrillSettings.CornerArrowYColor;
      arrow.ColorMethod = colorMethodType.byEntity;
      arrow.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Temp
      };
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) arrow);
    }
    if (VectorZ.Z != 0.0)
    {
      Mesh arrow = Mesh.CreateArrow(Data.CornerPoint, VectorZ, clsDrill.varDrillSettings.CornerArrowDiameter / 2.0, clsDrill.varDrillSettings.CornerArrowLength, clsDrill.varDrillSettings.CornerArrowConeDiameter / 2.0, clsDrill.varDrillSettings.CornerArrowConeLength, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
      arrow.Color = clsDrill.varDrillSettings.CornerArrowZColor;
      arrow.ColorMethod = colorMethodType.byEntity;
      arrow.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Temp
      };
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) arrow);
    }
    Mesh sphere = Mesh.CreateSphere(6.0, 20, 20, Mesh.natureType.RichSmooth);
    sphere.Translate(Data.CornerPoint.X, Data.CornerPoint.Y, Data.CornerPoint.Z);
    sphere.Color = clsDrill.varDrillSettings.CornerArrowBallColor;
    sphere.ColorMethod = colorMethodType.byEntity;
    sphere.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Temp
    };
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) sphere);
  }

  public void DrawPanelFromJobMainAndPreview(DrillJob Job)
  {
    this.DrawPanelFromJob(Job, new ViewportDrawOptions(ViewportRefType.Main));
  }

  public void DrawPanelFromJob(DrillJob Job, ViewportDrawOptions Options, buShape Shape = null)
  {
    try
    {
      Design design = (Design) null;
      if (Options.ViewportRef == ViewportRefType.Main)
        design = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
      else if (Options.ViewportRef == ViewportRefType.Operation)
      {
        if (Options.GroupType == ShapeGroup.Drill)
          design = clsItem.FrmDrillList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Cut)
          design = clsItem.FrmSlotList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Shape)
          design = clsItem.FrmShapeList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Profiling)
          design = clsItem.FrmProfilingList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Engraving)
          design = clsItem.FrmEngraveList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Junction)
          design = clsItem.FrmJunctionList.viewportLayout;
      }
      else if (Options.ViewportRef == ViewportRefType.Preview)
        design = clsItem.ModelMainPreview;
      else if (Options.ViewportRef == ViewportRefType.OpenDialog)
        design = clsItem.ModelOpenPreview;
      design.UpdateBoundingBox();
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
          copiedEntity1.LayerName = clsDrill.varTemps.layerPanel;
          copiedEntity1.ColorMethod = colorMethodType.byEntity;
          copiedEntity1.Color = Color.FromArgb(clsDrill.varDrillSettings.transparencyPanel, clsDrill.varDrillSettings.colorPanel);
          copiedEntity1.Selectable = false;
          copiedEntity1.EntityData = (object) new CustomData()
          {
            typeDefination = entityTypeDefination.Panel,
            RefIndex = 0
          };
          design.Entities.Add(copiedEntity1);
        }
        if (Options.ViewportRef == ViewportRefType.Main)
        {
          if (Job.FirstClamperEntity != null)
          {
            Entity copiedEnt = (Entity) null;
            buVector5.CopyEntities(Job.FirstClamperEntity, ref copiedEnt);
            design.Entities.Add(copiedEnt);
          }
          if (Job.SecondClamperEntity != null && this.MachType != DrillMachineType.Sirius)
          {
            Entity copiedEnt = (Entity) null;
            buVector5.CopyEntities(Job.SecondClamperEntity, ref copiedEnt);
            design.Entities.Add(copiedEnt);
          }
        }
        if (Options.DrawItems)
        {
          for (int index1 = 0; index1 <= Job.Cams.Count - 1; ++index1)
          {
            for (int index2 = 0; index2 <= Job.Cams[index1].EntitiesG1.Count - 1; ++index2)
            {
              Entity entity = (Entity) null;
              buEntity.Copy(Job.Cams[index1].EntitiesG1[index2], ref entity);
              entity.LayerName = clsDrill.varTemps.layerOperation;
              entity.ColorMethod = colorMethodType.byEntity;
              entity.Color = Color.Red;
              entity.Selectable = false;
              entity.EntityData = (object) new CustomData()
              {
                typeDefination = entityTypeDefination.Operation,
                RefIndex = index1,
                Sequence = index2
              };
              clsInit.cVector5.Mirror(new Point3D(), new Point3D(1.0, 0.0, 0.0), Plane.XY, ref entity);
              clsInit.cVector5.Mirror(new Point3D(), new Point3D(0.0, -1.0, 0.0), Plane.XY, ref entity);
              design.Entities.Add(entity);
            }
          }
          for (int index3 = 0; index3 <= Job.Items.Count - 1; ++index3)
          {
            buShape S = Job.Items[index3];
            for (int index4 = 0; index4 <= S.entitySolid.Count - 1; ++index4)
            {
              Entity copiedEntity2 = (Entity) null;
              buEntity.Copy(S.entitySolid[index4], ref copiedEntity2);
              copiedEntity2.LayerName = clsDrill.varTemps.layerOperation;
              copiedEntity2.ColorMethod = colorMethodType.byEntity;
              copiedEntity2.Color = Color.FromArgb(100, clsInit.cVector5.setbuShapeColors(S));
              copiedEntity2.Selectable = true;
              if (Job.Material.FrontAngle != 0.0 & Job.Items[index3].planeName == planeBoxNames.Front)
              {
                Point3D point3D1 = new Point3D(0.0, 0.0, Job.Material.Size.Depth);
                copiedEntity2.Rotate(buConversion5.DegreeToRadian(Job.Material.FrontAngle), Vector3D.AxisX, point3D1);
                Point3D point3D2 = buVector5.ToPoint3D(S.CalculatedPoint);
                clsInit.cVector5.Rotate(point3D1, Job.Material.FrontAngle, Plane.YZ, ref point3D2);
                double dz = S.BasePoint.Z - point3D2.Z;
                double num = dz * Math.Tan(buConversion5.DegreeToRadian(Job.Material.FrontAngle));
                copiedEntity2.Translate(0.0, -num, dz);
              }
              if (Job.Material.BackAngle != 0.0 & Job.Items[index3].planeName == planeBoxNames.Back)
              {
                Point3D point3D3 = new Point3D(0.0, Job.Material.Size.Height, Job.Material.Size.Depth);
                copiedEntity2.Rotate(buConversion5.DegreeToRadian(-Job.Material.BackAngle), Vector3D.AxisX, point3D3);
                Point3D point3D4 = buVector5.ToPoint3D(S.CalculatedPoint);
                clsInit.cVector5.Rotate(point3D3, Job.Material.BackAngle, Plane.YZ, ref point3D4);
                double dz = S.BasePoint.Z - point3D4.Z;
                double dy = dz * Math.Tan(buConversion5.DegreeToRadian(Job.Material.BackAngle));
                copiedEntity2.Translate(0.0, dy, dz);
              }
              copiedEntity2.EntityData = (object) new CustomData()
              {
                typeDefination = entityTypeDefination.Operation,
                RefIndex = index3,
                Sequence = index4,
                Tags = S.ShapeGroup.ToString()
              };
              design.Entities.Add(copiedEntity2);
            }
            for (int index5 = 0; index5 <= S.entityWireframe.Count - 1; ++index5)
            {
              Entity copiedEntity3 = (Entity) null;
              buEntity.Copy(S.entityWireframe[index5], ref copiedEntity3);
              copiedEntity3.LayerName = clsDrill.varTemps.layerOperation;
              copiedEntity3.ColorMethod = colorMethodType.byEntity;
              copiedEntity3.Color = clsInit.cVector5.setbuShapeColors(S);
              copiedEntity3.LineTypeMethod = colorMethodType.byEntity;
              copiedEntity3.Selectable = true;
              copiedEntity3.EntityData = (object) new CustomData()
              {
                typeDefination = entityTypeDefination.Operation,
                RefIndex = index3,
                Sequence = index5,
                Tags = S.ShapeGroup.ToString()
              };
              design.Entities.Add(copiedEntity3);
            }
            if (Job.Items[index3].Cam != null)
            {
              for (int index6 = 0; index6 <= Job.Items[index3].Cam.EntitiesG1.Count - 1; ++index6)
              {
                Entity copiedEntity4 = (Entity) null;
                buEntity.Copy(Job.Items[index3].Cam.EntitiesG1[index6], ref copiedEntity4);
                copiedEntity4.ColorMethod = colorMethodType.byEntity;
                copiedEntity4.Color = Color.Red;
                copiedEntity4.LineWeight = 3f;
                copiedEntity4.LineWeightMethod = colorMethodType.byEntity;
                copiedEntity4.LayerName = clsDrill.varTemps.layerCam;
                copiedEntity4.Selectable = false;
                copiedEntity4.Regen(0.01);
                CustomData customData = new CustomData()
                {
                  typeDefination = entityTypeDefination.Cam,
                  RefIndex = index3,
                  CamID = index6
                };
                design.Entities.Add(copiedEntity4);
              }
            }
          }
        }
        if (Options.OtherEntities != null)
        {
          for (int index = 0; index <= Options.OtherEntities.Count - 1; ++index)
            design.Entities.Add(Options.OtherEntities[index]);
        }
        design.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
        design.ActiveViewport.DisplayMode = displayType.Flat;
        if (Options.ViewportRef != ViewportRefType.Main)
        {
          if (Options.ViewportRef == ViewportRefType.Operation)
          {
            if (Shape != null)
            {
              List<Entity> entitiesDim = new List<Entity>();
              clsInit.cVector5.CreateShapeDimension(Shape, Job.Material, clsVar5.ShapeTempPar.ValueType, ref entitiesDim, ref Options.SetView);
              if (entitiesDim.Count > 0)
              {
                if (clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.EndDistance)
                  design.Entities.ClearSelection();
                for (int index = 0; index <= entitiesDim.Count - 1; ++index)
                {
                  entitiesDim[index].Selected = true;
                  design.Entities.Add(entitiesDim[index]);
                }
              }
              if (Options.SetView != viewType.Other)
                design.SetView(Options.SetView);
              if (Shape.planeName == planeBoxNames.Back)
              {
                if (Options.SetView == viewType.Other)
                  design.SetView(viewType.Front);
                design.ZoomFit(true);
              }
              if (Shape.planeName == planeBoxNames.Front)
              {
                if (Options.SetView == viewType.Other)
                  design.SetView(viewType.Front);
                design.ZoomFit(true);
              }
              if (Shape.planeName == planeBoxNames.Left)
              {
                if (Options.SetView == viewType.Other)
                  design.SetView(viewType.Right);
                design.ZoomFit(true);
              }
              if (Shape.planeName == planeBoxNames.Right)
              {
                if (Options.SetView == viewType.Other)
                  design.SetView(viewType.Right);
                design.ZoomFit(true);
              }
              if (Shape.planeName == planeBoxNames.Top | Shape.planeName == planeBoxNames.Bottom)
              {
                if (Options.SetView == viewType.Other)
                  design.SetView(viewType.Top);
                design.ZoomFit(true);
              }
            }
          }
          else if (Options.ViewportRef == ViewportRefType.Preview)
          {
            design.SetView(viewType.Dimetric);
            design.ZoomFit(5);
          }
        }
        design.UpdateBoundingBox();
        design.Invalidate();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void DrawAsRenderFromJob(DrillJob Job, ref Entity entPanel)
  {
    try
    {
      Brep box = Brep.CreateBox(Job.Material.Size.Width, Job.Material.Size.Height, Job.Material.Size.Depth);
      if (this.Sing != 1)
        box.Translate((double) this.Sing * Job.Material.Size.Width, (double) this.Sing * Job.Material.Size.Height);
      List<ICurve> curveList = new List<ICurve>();
      for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
      {
        double amount = Job.Items[index1].Depth;
        if (amount <= 0.02)
          amount = 0.1;
        new CustomData().typeDefination = entityTypeDefination.Operation;
        List<ICurve> copiedEntities = new List<ICurve>();
        int clockDirection = (int) clsInit.cVector5.GetClockDirection(Job.Items[index1].entitiesShape[0].Vertices, Job.Items[index1].planeOperation);
        buEntity.Copy(Job.Items[index1].entitiesShape, ref copiedEntities);
        if (Job.Items[index1].planeName == planeBoxNames.Top)
        {
          if (Job.Items[index1].ShapeGroup == ShapeGroup.Drill)
          {
            buShapeHole buShapeHole = Job.Items[index1] as buShapeHole;
            if (Job.Items[index1].multiCenter == null)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, -amount);
            }
            else if (Job.Items[index1].multiCenter.Count == 0)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, -amount);
            }
            else
            {
              for (int index2 = 0; index2 <= Job.Items[index1].multiCenter.Count - 1; ++index2)
              {
                Circle outer = new Circle(Job.Items[index1].planeOperation, Job.Items[index1].multiCenter[index2].Center, buShapeHole.Diameter / 2.0);
                outer.Regen(0.01);
                devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((ICurve) outer);
                box.ExtrudeRemove(reg, -amount);
              }
            }
          }
          else
          {
            devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities, Job.Items[index1].planeOperation, true);
            box.ExtrudeRemove(reg, -amount);
          }
        }
        if (Job.Items[index1].planeName == planeBoxNames.Left)
        {
          if (Job.Items[index1].ShapeGroup == ShapeGroup.Drill)
          {
            buShapeHole buShapeHole = Job.Items[index1] as buShapeHole;
            if (Job.Items[index1].multiCenter == null)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, amount);
            }
            else if (Job.Items[index1].multiCenter.Count == 0)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, amount);
            }
            else
            {
              for (int index3 = 0; index3 <= Job.Items[index1].multiCenter.Count - 1; ++index3)
              {
                Circle outer = new Circle(Job.Items[index1].planeOperation, Job.Items[index1].multiCenter[index3].Center, buShapeHole.Diameter / 2.0);
                outer.Regen(0.01);
                devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((ICurve) outer);
                box.ExtrudeRemove(reg, amount);
              }
            }
          }
          else
          {
            devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities, Job.Items[index1].planeOperation, true);
            box.ExtrudeRemove(reg, amount);
          }
        }
        if (Job.Items[index1].planeName == planeBoxNames.Right)
        {
          if (Job.Items[index1].ShapeGroup == ShapeGroup.Drill)
          {
            buShapeHole buShapeHole = Job.Items[index1] as buShapeHole;
            if (Job.Items[index1].multiCenter == null)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, -amount);
            }
            else if (Job.Items[index1].multiCenter.Count == 0)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, -amount);
            }
            else
            {
              for (int index4 = 0; index4 <= Job.Items[index1].multiCenter.Count - 1; ++index4)
              {
                Circle outer = new Circle(Job.Items[index1].planeOperation, Job.Items[index1].multiCenter[index4].Center, buShapeHole.Diameter / 2.0);
                outer.Regen(0.01);
                devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((ICurve) outer);
                box.ExtrudeRemove(reg, -amount);
              }
            }
          }
          else
          {
            devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities, Job.Items[index1].planeOperation, true);
            box.ExtrudeRemove(reg, -amount);
          }
        }
        if (Job.Items[index1].planeName == planeBoxNames.Front)
        {
          if (Job.Items[index1].ShapeGroup == ShapeGroup.Drill)
          {
            buShapeHole buShapeHole = Job.Items[index1] as buShapeHole;
            if (Job.Items[index1].multiCenter == null)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, -amount);
            }
            else if (Job.Items[index1].multiCenter.Count == 0)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, -amount);
            }
            else
            {
              for (int index5 = 0; index5 <= Job.Items[index1].multiCenter.Count - 1; ++index5)
              {
                Circle outer = new Circle(Job.Items[index1].planeOperation, Job.Items[index1].multiCenter[index5].Center, buShapeHole.Diameter / 2.0);
                outer.Regen(0.01);
                devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((ICurve) outer);
                box.ExtrudeRemove(reg, -amount);
              }
            }
          }
          else
          {
            devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities, Job.Items[index1].planeOperation, true);
            box.ExtrudeRemove(reg, -amount);
          }
        }
        if (Job.Items[index1].planeName == planeBoxNames.Back)
        {
          if (Job.Items[index1].ShapeGroup == ShapeGroup.Drill)
          {
            buShapeHole buShapeHole = Job.Items[index1] as buShapeHole;
            if (Job.Items[index1].multiCenter == null)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, amount);
            }
            else if (Job.Items[index1].multiCenter.Count == 0)
            {
              devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities);
              box.ExtrudeRemove(reg, amount);
            }
            else
            {
              for (int index6 = 0; index6 <= Job.Items[index1].multiCenter.Count - 1; ++index6)
              {
                Circle outer = new Circle(Job.Items[index1].planeOperation, Job.Items[index1].multiCenter[index6].Center, buShapeHole.Diameter / 2.0);
                outer.Regen(0.01);
                devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((ICurve) outer);
                box.ExtrudeRemove(reg, amount);
              }
            }
          }
          else
          {
            devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region((IList<ICurve>) copiedEntities, Job.Items[index1].planeOperation, true);
            box.ExtrudeRemove(reg, amount);
          }
        }
      }
      box.Rebuild(0.1);
      entPanel = (Entity) box;
      entPanel.Color = Color.FromArgb(150, clsDrill.varDrillSettings.colorPanel);
      entPanel.ColorMethod = colorMethodType.byEntity;
      entPanel.LayerName = clsDrill.varTemps.layerPanel;
    }
    catch (Exception ex)
    {
    }
  }

  public void UpdateSelectedOperation(ViewportDrawOptions Options)
  {
    try
    {
      Design design = (Design) null;
      if (Options.ViewportRef == ViewportRefType.Main)
        design = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
      else if (Options.ViewportRef == ViewportRefType.Operation)
      {
        if (Options.GroupType == ShapeGroup.Drill)
          design = clsItem.FrmDrillList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Cut)
          design = clsItem.FrmSlotList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Shape)
          design = clsItem.FrmShapeList.viewportLayout;
        else if (Options.GroupType == ShapeGroup.Profiling)
          design = clsItem.FrmProfilingList.viewportLayout;
      }
      else if (Options.ViewportRef == ViewportRefType.Preview)
        design = clsItem.ModelMainPreview;
      design.UpdateBoundingBox();
      for (int index = 0; index <= design.Entities.Count - 1; ++index)
      {
        if (design.Entities[index].EntityData != null && design.Entities[index].EntityData is CustomData)
        {
          CustomData entityData = design.Entities[index].EntityData as CustomData;
          if (entityData.typeDefination == entityTypeDefination.Operation)
          {
            if (entityData.RefIndex >= 0 & entityData.RefIndex <= clsDrill.activeJob.Items.Count - 1)
              design.Entities[index].Color = clsInit.cVector5.setbuShapeColors(clsDrill.activeJob.Items[entityData.RefIndex]);
            if (Options.indexSelectdOP >= 0 & Options.indexSelectdOPSub == -1 & entityData.RefIndex == Options.indexSelectdOP)
              design.Entities[index].Color = clsVar5.VarbuShapeVisilation.colorOperationSelected.Color;
            if (Options.indexSelectdOP >= 0 & Options.indexSelectdOPSub >= 0 & entityData.RefIndex == Options.indexSelectdOP & entityData.Sequence == Options.indexSelectdOPSub)
              design.Entities[index].Color = clsVar5.VarbuShapeVisilation.colorOperationSelected.Color;
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void CreateMaterialsAndLayers(string FileName)
  {
    List<string> stringList = new List<string>();
    Bitmap image = new Bitmap(FileName);
    Material material = new Material("Wood", Color.FromArgb(100, 100, 100), Color.White, 1f, image.ToByteArray())
    {
      LinearUnits = linearUnitsType.Meters,
      MassUnits = massUnitsType.Kilograms,
      Density = 6E-07,
      TextureLength = 2000f,
      Environment = 0.01f
    };
    clsItem.FrmPreview.viewportLayout.Materials.Clear();
    if (clsItem.FrmPreview.viewportLayout.Materials.Count == 0)
      clsItem.FrmPreview.viewportLayout.Materials.Add(material);
    Layer newItem = new Layer("Wood", Color.Brown);
    newItem.LineWeight = 1f;
    newItem.MaterialName = material.Name;
    bool flag = false;
    for (int index = 0; index <= clsItem.FrmPreview.viewportLayout.Layers.Count - 1; ++index)
    {
      if (clsItem.FrmPreview.viewportLayout.Layers[index].Name == newItem.Name)
        flag = true;
    }
    if (flag)
      return;
    clsItem.FrmPreview.viewportLayout.Layers.AddOrReplace(newItem);
  }

  public void PageClosed()
  {
    if (clsDrill.JobList == null)
      return;
    clsDrill.JobList.Clear();
    clsDrill.JobList = new List<DrillJob>();
    clsDrill.activeJob = (DrillJob) null;
    clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
  }

  public void OpenExtension()
  {
    if (clsDrill.JobList == null)
      clsDrill.JobList = new List<DrillJob>();
    clsDrill.JobList.Clear();
    clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
  }

  public void NewPageExtension()
  {
    if (clsDrill.JobList == null)
      clsDrill.JobList = new List<DrillJob>();
    clsDrill.JobList.Clear();
    clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
    this.timNew.Interval = 100;
    this.timNew.Enabled = true;
  }

  public void NewPageTick(object sender, EventArgs e)
  {
    this.timNew.Enabled = false;
    Point3D point3D = (Point3D) null;
    for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
    {
      if (clsDrill.ToolList[index].Data.No == 31 /*0x1F*/)
      {
        point3D = new Point3D();
        point3D.X = clsDrill.ToolList[index].Positions.CommonOffset.X;
        point3D.Y = clsDrill.ToolList[index].Positions.CommonOffset.Y;
        point3D.Z = clsDrill.ToolList[index].Positions.CommonOffset.Z;
      }
    }
    if (point3D != (Point3D) null & ccVars.Tools.Count > 0)
    {
      for (int index = 0; index <= ccVars.Tools[0].Tools.Count - 1; ++index)
      {
        ccVars.Tools[0].Tools[index].Positions.CommonOffset.X = point3D.X;
        ccVars.Tools[0].Tools[index].Positions.CommonOffset.Y = point3D.Y;
        ccVars.Tools[0].Tools[index].Positions.CommonOffset.Z = point3D.Z;
      }
    }
    if (clsDrill.varDrillSettings.AutoOpenLastPanel)
      this.AddPanel(ccVars.activeMaterial);
    else if (clsDrill.varDrillSettings.AutoOpenLastPanelAndDrill & !clsDrill.varDrillSettings.AutoOpenLastPanel)
      ;
  }

  public void AddPanel(MaterialBase5 Mat)
  {
    if (ccVars.Pages.Count <= 0)
      return;
    clsDrill.activeJob = new DrillJob();
    if (clsDrill.JobList == null)
      clsDrill.JobList = new List<DrillJob>();
    clsDrill.JobList = new List<DrillJob>();
    if (Mat.Entities.Count == 0)
    {
      Entity entity = (Entity) null;
      clsInit.cVector5.CreateMaterialEntities(Mat, ref entity);
      clsInit.cVector5.Move(-ccVars.activeMaterial.Size.Width, -ccVars.activeMaterial.Size.Height, 0.0, ref entity);
      Mat.Entities.Add(entity);
    }
    clsDrill.activeJob.Material = new MaterialBase5(Mat);
    clsDrill.activeJob.Material.Sing = new Point3D(clsVar5.shapeCreatePar.SingX, clsVar5.shapeCreatePar.SingY, 1.0);
    if (Mat.Entities.Count > 0)
      buEntity.Copy(Mat.Entities[0], ref clsDrill.activeJob.panelEntity);
    double MaterialZeroYPos = 0.0;
    if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
      this.cGoUltra2Up1Down.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
    if (this.MachType == DrillMachineType.GoWithAtc)
      this.cGoAtc.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
    if (this.MachType == DrillMachineType.Sirius)
      this.cGoSirius.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
    if (this.ClamperEntity != null)
      clsInit.cDrill.CreateClamperEntities((Entity) this.ClamperEntity, clsDrill.activeJob.FirstClamperX, clsDrill.activeJob.SecondClamperX, ref clsDrill.activeJob.FirstClamperEntity, ref clsDrill.activeJob.SecondClamperEntity, Color.Gray);
    this.DrawPanelFromJob(clsDrill.activeJob, new ViewportDrawOptions());
    clsInit.appCommand.PagesUpdate(true, "");
    clsInit.appCommand.cmdViewZoomFit();
    clsInit.appCommand.cmdViewZoomOut();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    clsDrill.JobList.Add(clsDrill.activeJob);
    this.selectedJobIndex = clsDrill.JobList.Count - 1;
    this.JobUpdate(true, (DrillItem) null);
    this.SaveDrillFile();
    clsFiles.SaveParameter();
  }

  public void JobUpdate(bool FillPages, DrillItem Item, int indexItem = -1, string Command = "")
  {
    try
    {
      if (clsItem.FrmDrillJob == null)
        return;
      if (clsDrill.activeJob == null)
      {
        clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
      }
      else
      {
        if (clsDrill.activeJob.Items.Count != clsItem.FrmDrillJob.tree_jobs.Nodes.Count)
          FillPages = true;
        string str1 = AppLanguage.CadCamDynamic[114];
        string str2 = AppLanguage.CadCamDynamic[108];
        string str3 = AppLanguage.CadCamDynamic[107] + " - ";
        string str4 = AppLanguage.CadCamDynamic[106];
        string str5 = AppLanguage.CadCamDynamic[112 /*0x70*/];
        if (!FillPages)
          return;
        List<string> stringList = new List<string>();
        clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
        buCadCamResVer5.TreeNodeSettings treeNodeSettings1 = new buCadCamResVer5.TreeNodeSettings(this.JobToString(clsDrill.activeJob));
        treeNodeSettings1.ImageIndex = 0;
        treeNodeSettings1.SelectedImageIndex = 0;
        treeNodeSettings1.Tag = (object) "0";
        treeNodeSettings1.ClassIndex = 0;
        treeNodeSettings1.ClassSubIndex = -1;
        treeNodeSettings1.ClassSubSubIndex = -1;
        treeNodeSettings1.Command = "panel";
        treeNodeSettings1.Checked = true;
        buCadCamResVer5.TreeNodeSettings node1 = treeNodeSettings1;
        for (int index1 = 0; index1 <= clsDrill.activeJob.Items.Count - 1; ++index1)
        {
          clsDrill.activeJob.Items[index1].ShapeGroup.ToString().Trim();
          int num = this.JobImageIndex(clsDrill.activeJob.Items[index1]);
          if (!clsDrill.activeJob.Items[index1].Enable)
            num = 1;
          buCadCamResVer5.TreeNodeSettings treeNodeSettings2 = new buCadCamResVer5.TreeNodeSettings(this.JobItemToString(clsDrill.activeJob.Items[index1]));
          treeNodeSettings2.ImageIndex = num;
          treeNodeSettings2.SelectedImageIndex = num;
          treeNodeSettings2.Tag = (object) index1.ToString();
          treeNodeSettings2.ClassIndex = 0;
          treeNodeSettings2.ClassSubIndex = index1;
          treeNodeSettings2.ClassSubSubIndex = -1;
          treeNodeSettings2.Command = "item";
          treeNodeSettings2.Checked = true;
          buCadCamResVer5.TreeNodeSettings node2 = treeNodeSettings2;
          if ((clsDrill.activeJob.Items[index1].InfoMessages == null ? 0 : (clsDrill.activeJob.Items[index1].InfoMessages.Count > 0 ? 1 : 0)) != 0)
          {
            node2.ForeColor = Color.Red;
            for (int index2 = 0; index2 <= clsDrill.activeJob.Items[index1].InfoMessages.Count - 1; ++index2)
              stringList.Add($"[ {(index2 + 1).ToString()}. {buLangTranslate.preDef.Operation} ] - {clsDrill.activeJob.Items[index1].InfoMessages[index2]}");
          }
          if (clsDrill.activeJob.Items[index1].ShapeGroup == ShapeGroup.Drill && clsDrill.activeJob.Items[index1] is buShapeHoleMulti)
          {
            buShapeHoleMulti buShapeHoleMulti = clsDrill.activeJob.Items[index1] as buShapeHoleMulti;
            if (buShapeHoleMulti.multiCenter != null)
            {
              for (int index3 = 0; index3 <= buShapeHoleMulti.multiCenter.Count - 1; ++index3)
              {
                string NodeText = "";
                if (buShapeHoleMulti.planeName == planeBoxNames.Top | buShapeHoleMulti.planeName == planeBoxNames.Bottom)
                  NodeText = $"X: {buShapeHoleMulti.multiCenter[index3].Center.X.ToString("f2")} , Y: {buShapeHoleMulti.multiCenter[index3].Center.Y.ToString("f2")}";
                if (buShapeHoleMulti.planeName == planeBoxNames.Front | buShapeHoleMulti.planeName == planeBoxNames.Back)
                  NodeText = $"X: {buShapeHoleMulti.multiCenter[index3].Center.X.ToString("f2")} , Z: {buShapeHoleMulti.multiCenter[index3].Center.Z.ToString("f2")}";
                if (buShapeHoleMulti.planeName == planeBoxNames.Left | buShapeHoleMulti.planeName == planeBoxNames.Right)
                  NodeText = $"Y: {buShapeHoleMulti.multiCenter[index3].Center.Y.ToString("f2")} , Z: {buShapeHoleMulti.multiCenter[index3].Center.Z.ToString("f2")}";
                buCadCamResVer5.TreeNodeSettings treeNodeSettings3 = new buCadCamResVer5.TreeNodeSettings(NodeText);
                treeNodeSettings3.ImageIndex = 9;
                treeNodeSettings3.SelectedImageIndex = 9;
                treeNodeSettings3.Tag = (object) index1.ToString();
                treeNodeSettings3.ClassIndex = 0;
                treeNodeSettings3.ClassSubIndex = index1;
                treeNodeSettings3.ClassSubSubIndex = index3;
                treeNodeSettings3.Command = "subitem";
                treeNodeSettings3.Checked = true;
                buCadCamResVer5.TreeNodeSettings node3 = treeNodeSettings3;
                node2.Nodes.Add((TreeNode) node3);
              }
            }
          }
          if (node2 != null)
            node1.Nodes.Add((TreeNode) node2);
        }
        for (int index = 0; index <= stringList.Count - 1; ++index)
        {
          buCadCamResVer5.TreeNodeSettings treeNodeSettings4 = new buCadCamResVer5.TreeNodeSettings(stringList[index]);
          treeNodeSettings4.ImageIndex = 39;
          treeNodeSettings4.SelectedImageIndex = 39;
          treeNodeSettings4.Tag = (object) "";
          treeNodeSettings4.ClassIndex = -1;
          treeNodeSettings4.ClassSubIndex = -1;
          treeNodeSettings4.ClassSubSubIndex = -1;
          treeNodeSettings4.Command = "info";
          treeNodeSettings4.Checked = true;
          buCadCamResVer5.TreeNodeSettings node4 = treeNodeSettings4;
          node1.Nodes.Add((TreeNode) node4);
        }
        if (node1 == null)
          return;
        node1.Expand();
        clsItem.FrmDrillJob.tree_jobs.Nodes.Add((TreeNode) node1);
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public int JobImageIndex(buShape Item)
  {
    int num = -1;
    if (Item.ShapeGroup == ShapeGroup.Drill)
    {
      if (Item.GetType() == typeof (buShapeHole))
      {
        num = 2;
        if (((buShapeHole) Item).isMilling)
          num = 9;
      }
      else if (Item.GetType() == typeof (buShapeHoleMulti))
      {
        buShapeHoleMulti buShapeHoleMulti = Item as buShapeHoleMulti;
        if (buShapeHoleMulti.DrillType == drillTypes.HorizontalHoles)
          num = 3;
        if (buShapeHoleMulti.DrillType == drillTypes.HorizontalLineHoles)
          num = 4;
        if (buShapeHoleMulti.DrillType == drillTypes.VerticalHoles)
          num = 5;
        if (buShapeHoleMulti.DrillType == drillTypes.VerticalLineHoles)
          num = 6;
        if (buShapeHoleMulti.DrillType == drillTypes.InclineHoles)
          num = 7;
      }
      else if (Item.GetType() == typeof (buShapeHole3))
        num = 8;
    }
    if (Item.ShapeGroup == ShapeGroup.Shape)
    {
      buShape buShape = Item;
      if (buShape.ShapeType == ShapeTypes.Circle)
        num = 10;
      if (buShape.ShapeType == ShapeTypes.Ellipse)
        num = 11;
      if (buShape.ShapeType == ShapeTypes.FreeDraw)
        num = 12;
      if (buShape.ShapeType == ShapeTypes.KeyHole)
        num = 14;
      if (buShape.ShapeType == ShapeTypes.Polygon)
        num = 15;
      if (buShape.ShapeType == ShapeTypes.Rectangle)
      {
        num = 16 /*0x10*/;
        if (((buShapeRectangle) buShape).Radius > 0.0)
          num = 17;
      }
      if (buShape.ShapeType == ShapeTypes.Rhombus)
        num = 18;
      if (buShape.ShapeType == ShapeTypes.Slot)
        num = 19;
      if (buShape.ShapeType == ShapeTypes.Star)
        num = 20;
      if (buShape.ShapeType == ShapeTypes.Text)
        num = 21;
      if (buShape.ShapeType == ShapeTypes.Trepezoid)
        num = 22;
      if (buShape.ShapeType == ShapeTypes.Triangle)
        num = 23;
    }
    if (Item.ShapeGroup == ShapeGroup.Cut && Item.GetType() == typeof (buShapeCut))
    {
      buShapeCut buShapeCut = Item as buShapeCut;
      if (buShapeCut.CutType == CutTypes.CutHorizontal)
        num = !buShapeCut.isMilling ? 29 : 24;
      if (buShapeCut.CutType == CutTypes.CutHorizontalLine)
        num = 25;
      if (buShapeCut.CutType == CutTypes.CutVertical)
        num = 26;
      if (buShapeCut.CutType == CutTypes.CutVerticalLine)
        num = 27;
      if (buShapeCut.CutType == CutTypes.CutFree)
        num = 28;
    }
    if (Item.ShapeGroup == ShapeGroup.Profiling)
    {
      buShapeProfiling buShapeProfiling = Item as buShapeProfiling;
      if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingRectangle)
        num = 30;
      if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingRound)
        num = 31 /*0x1F*/;
      if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingChamfer)
        num = 32 /*0x20*/;
      if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingRoundConcave)
        num = 40;
    }
    if (Item.ShapeGroup == ShapeGroup.Engraving)
      num = 33;
    if (Item.ShapeGroup == ShapeGroup.Junction)
    {
      buShapeJunction buShapeJunction = Item as buShapeJunction;
      if (buShapeJunction.JunctionType == JunctionTypes.Junction2HoleNearByHorizontal)
        num = 34;
      if (buShapeJunction.JunctionType == JunctionTypes.Junction2HoleNearByVertical)
        num = 35;
      if (buShapeJunction.JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal)
        num = 36;
      if (buShapeJunction.JunctionType == JunctionTypes.Junction3HoleIntersectVertical)
        num = 37;
    }
    if (Item.ShapeGroup == ShapeGroup.Contour)
      num = 38;
    return num;
  }

  public string JobItemToString(buShape Item)
  {
    string str1 = "";
    if (Item.ShapeGroup == ShapeGroup.Drill)
    {
      if (Item.GetType() == typeof (buShapeHole))
      {
        buShapeHole buShapeHole = Item as buShapeHole;
        str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Diameter}: {buShapeHole.Diameter.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeHole.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeHole.Depth.ToString()}";
      }
      else if (Item.GetType() == typeof (buShapeHoleMulti))
      {
        buShapeHoleMulti buShapeHoleMulti = Item as buShapeHoleMulti;
        str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Diameter}: {buShapeHoleMulti.Diameter.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeHoleMulti.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeHoleMulti.Depth.ToString()}";
      }
      else if (Item.GetType() == typeof (buShapeHole3))
      {
        buShapeHole3 buShapeHole3 = Item as buShapeHole3;
        str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Diameter}: {buShapeHole3.Diameter.ToString("f2")} , {buLangTranslate.preDef.Outside} {buLangTranslate.preDef.Diameter}: {buShapeHole3.DiameterOutside.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeHole3.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeHole3.Depth.ToString()}";
      }
    }
    else if (Item.ShapeGroup == ShapeGroup.Shape)
    {
      string str2 = str1 + clsInit.cDrill.JobItemCommandToString(Item);
      if (Item.ShapeType == ShapeTypes.Circle)
      {
        buShapeCircle buShapeCircle = Item as buShapeCircle;
        str2 = $"{str2} - {buLangTranslate.preDef.Diameter}: {(buShapeCircle.Radius * 2.0).ToString("f2")}";
      }
      else if (Item.ShapeType == ShapeTypes.Rectangle)
      {
        buShapeRectangle buShapeRectangle = Item as buShapeRectangle;
        str2 = $"{str2} - {buLangTranslate.preDef.Width}: {buShapeRectangle.Width.ToString("f2")} , {buLangTranslate.preDef.Height}: {buShapeRectangle.Height.ToString("f2")}";
      }
      else if (Item.ShapeType == ShapeTypes.Ellipse)
      {
        buShapeEllipse buShapeEllipse = Item as buShapeEllipse;
        str2 = $"{str2} - {buLangTranslate.preDef.DiaX}: {(buShapeEllipse.RadiusX * 2.0).ToString("f2")} , {buLangTranslate.preDef.DiaY}: {(buShapeEllipse.RadiusY * 2.0).ToString("f2")}";
      }
      else if (Item.ShapeType == ShapeTypes.Slot)
      {
        buShapeSlot buShapeSlot = Item as buShapeSlot;
        str2 = $"{str2} - {buLangTranslate.preDef.Length}: {buShapeSlot.Length.ToString("f2")} , {buLangTranslate.preDef.Diameter}: {buShapeSlot.Diameter.ToString("f2")}";
      }
      else if (Item.ShapeType == ShapeTypes.Polygon)
      {
        buShapePolygon buShapePolygon = Item as buShapePolygon;
        str2 = $"{str2} - {buLangTranslate.preDef.Side}: {buShapePolygon.Side.ToString("")} , {buLangTranslate.preDef.Diameter}: {(buShapePolygon.Radius * 2.0).ToString("f2")}";
      }
      else if (Item.ShapeType == ShapeTypes.FreeDraw)
      {
        buShapeFreeDraw buShapeFreeDraw = Item as buShapeFreeDraw;
        str2 = $"{str2} - {buLangTranslate.preDef.Width}: {buShapeFreeDraw.Width.ToString("f2")} , {buLangTranslate.preDef.Height}: {buShapeFreeDraw.Height.ToString("f2")}";
      }
      else if (Item.ShapeType == ShapeTypes.FreeLines)
      {
        buShapeFreeLines buShapeFreeLines = Item as buShapeFreeLines;
        str2 = $"{str2} - {buLangTranslate.preDef.Width}: {buShapeFreeLines.Width.ToString("f2")} , {buLangTranslate.preDef.Height}: {buShapeFreeLines.Height.ToString("f2")}";
      }
      else if (Item.ShapeType == ShapeTypes.KeyHole)
      {
        buShapeKeyHole buShapeKeyHole = Item as buShapeKeyHole;
        str2 = $"{str2} - {buLangTranslate.preDef.Length}: {buShapeKeyHole.Length.ToString("f2")} , {buLangTranslate.preDef.HeadDiameter}: {buShapeKeyHole.HeadDiameter.ToString("f2")} , {buLangTranslate.preDef.Diameter}: {buShapeKeyHole.Diameter.ToString("f2")}";
      }
      str1 = $"{str2} , {buLangTranslate.preDef.Plane}: {Item.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {Item.Depth.ToString()}";
    }
    else if (Item.ShapeGroup == ShapeGroup.Cut)
    {
      if (Item.GetType() == typeof (buShapeCut))
      {
        buShapeCut buShapeCut = Item as buShapeCut;
        str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Diameter}: {buShapeCut.Diameter.ToString("f2")}{buLangTranslate.preDef.Length}: {buShapeCut.Length.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeCut.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeCut.Depth.ToString()}";
      }
    }
    else if (Item.ShapeGroup == ShapeGroup.Profiling)
    {
      if (Item.GetType() == typeof (buShapeProfiling))
      {
        buShapeProfiling buShapeProfiling = Item as buShapeProfiling;
        if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingRectangle)
          str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Width}: {buShapeProfiling.Width.ToString("f2")}{buLangTranslate.preDef.Height}: {buShapeProfiling.Height.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeProfiling.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeProfiling.Depth.ToString()}";
        if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingRound)
          str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Radius}: {buShapeProfiling.Radius.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeProfiling.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeProfiling.Depth.ToString()}";
        if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingChamfer)
          str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Length}: {buShapeProfiling.Length.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeProfiling.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeProfiling.Depth.ToString()}";
        if (buShapeProfiling.ProfilingType == ProfilingTypes.ProfilingRoundConcave)
          str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Radius}: {buShapeProfiling.Radius.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeProfiling.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeProfiling.Depth.ToString()}";
      }
    }
    else if (Item.ShapeGroup == ShapeGroup.Contour)
      str1 = $"{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Offset}: {Item.OffsetDistance.ToString("f1")} , {buLangTranslate.preDef.Depth}: {Item.Depth.ToString("f1")}";
    else if (Item.ShapeGroup != ShapeGroup.Text)
    {
      if (Item.ShapeGroup == ShapeGroup.Engraving)
      {
        if (Item.GetType() == typeof (buShapeEngrave))
        {
          buShapeEngrave buShapeEngrave = Item as buShapeEngrave;
          str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Width}: {buShapeEngrave.Width.ToString("f2")}{buLangTranslate.preDef.Height}: {buShapeEngrave.Height.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeEngrave.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeEngrave.Depth.ToString()}";
        }
      }
      else if (Item.ShapeGroup == ShapeGroup.Junction && Item.GetType() == typeof (buShapeJunction))
      {
        buShapeJunction buShapeJunction = Item as buShapeJunction;
        if (buShapeJunction.JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal | buShapeJunction.JunctionType == JunctionTypes.Junction3HoleIntersectVertical)
          str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Diameter}: {buShapeJunction.Diameter.ToString("f2")} , {buLangTranslate.preDef.Distance}: {buShapeJunction.Distance.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeJunction.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeJunction.Depth.ToString()}";
        if (buShapeJunction.JunctionType == JunctionTypes.Junction2HoleNearByHorizontal | buShapeJunction.JunctionType == JunctionTypes.Junction2HoleNearByVertical)
          str1 = $"{str1}{clsInit.cDrill.JobItemCommandToString(Item)} - {buLangTranslate.preDef.Diameter}: {buShapeJunction.Diameter.ToString("f2")} , {buLangTranslate.preDef.Diameter} {buLangTranslate.preDef.Outside}: {buShapeJunction.Distance.ToString("f2")} , {buLangTranslate.preDef.Distance}: {buShapeJunction.Distance.ToString("f2")} , {buLangTranslate.preDef.Plane}: {buShapeJunction.planeName.ToString()} , {buLangTranslate.preDef.Depth}: {buShapeJunction.Depth.ToString()}";
      }
    }
    return str1;
  }

  public string JobToString(DrillJob Job)
  {
    string str = Job.Name.Trim();
    if (str.Length == 0)
      str = AppLanguage.CadCamDynamic[114];
    return $"{str}- W: {Job.Material.Size.Width.ToString()}, H: {Job.Material.Size.Height.ToString()}, D: {Job.Material.Size.Depth.ToString()}";
  }

  public void Job_AfterChecked(object sender, TreeViewEventArgs e)
  {
    if (this.bool_0)
      return;
    buCadCamResVer5.TreeNodeSettings node = (buCadCamResVer5.TreeNodeSettings) e.Node;
    if (node != null)
    {
      int num = node.Checked ? 1 : 0;
      switch (node.Command)
      {
        case "panel":
          if (node.ClassIndex >= 0)
          {
            this.bool_0 = true;
            this.selectedJobIndex = node.ClassIndex;
            this.selectedItemIndex = -1;
            this.selectedItemSubIndex = -1;
            this.bool_0 = false;
            break;
          }
          break;
        case "item":
          if (node.ClassIndex >= 0)
          {
            this.bool_0 = true;
            this.selectedJobIndex = node.ClassIndex;
            this.selectedItemIndex = node.ClassSubIndex;
            this.selectedItemSubIndex = -1;
            this.bool_0 = false;
            break;
          }
          break;
        case "itemsub":
          if (node.ClassIndex >= 0)
          {
            this.bool_0 = true;
            this.selectedJobIndex = node.ClassIndex;
            this.selectedItemIndex = node.ClassSubIndex;
            this.selectedItemSubIndex = node.ClassSubSubIndex;
            this.bool_0 = false;
            break;
          }
          break;
      }
    }
    if (clsDrill.activeJob == null)
      return;
    this.UpdateSelectedOperation(new ViewportDrawOptions(ViewportRefType.Main, this.selectedItemIndex, this.selectedItemSubIndex));
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
    buCadCamResVer5.TreeNodeSettings selectedNode = (buCadCamResVer5.TreeNodeSettings) ((TreeView) sender).SelectedNode;
    this.selectedJobIndex = -1;
    this.selectedItemIndex = -1;
    this.selectedItemSubIndex = -1;
    if (clsItem.FrmDrillJob.tree_jobs.Nodes != null && clsItem.FrmDrillJob.tree_jobs.Nodes.Count > 0)
    {
      clsItem.FrmDrillJob.tree_jobs.Nodes[0].BackColor = Color.White;
      if (clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes != null)
      {
        for (int index = 0; index <= clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes.Count - 1; ++index)
          clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes[index].BackColor = Color.White;
      }
    }
    if (selectedNode.Parent != null)
      selectedNode.BackColor = Color.LightSteelBlue;
    switch (selectedNode.Command)
    {
      case "panel":
        if (selectedNode.ClassIndex >= 0)
        {
          this.selectedJobIndex = selectedNode.ClassIndex;
          break;
        }
        break;
      case "item":
        if (selectedNode.ClassIndex >= 0)
        {
          this.selectedJobIndex = selectedNode.ClassIndex;
          this.selectedItemIndex = selectedNode.ClassSubIndex;
          this.selectedItemSubIndex = selectedNode.ClassSubSubIndex;
          break;
        }
        break;
      case "subitem":
        if (selectedNode.ClassIndex >= 0)
        {
          this.selectedJobIndex = selectedNode.ClassIndex;
          this.selectedItemIndex = selectedNode.ClassSubIndex;
          this.selectedItemSubIndex = selectedNode.ClassSubSubIndex;
          break;
        }
        break;
    }
    if (clsDrill.activeJob == null)
      return;
    this.UpdateSelectedOperation(new ViewportDrawOptions(ViewportRefType.Main, this.selectedItemIndex, this.selectedItemSubIndex));
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void AddDrillMove(
    double X1,
    double X2,
    double Y1,
    double Y2,
    double Y3,
    double Z1,
    double Z2,
    double Z3,
    DrillMoveCommand Cmd,
    drillPlaneNames Plane,
    double X,
    ref DrillJob Job)
  {
    DrillMoveOptions Options = new DrillMoveOptions(Plane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation);
    this.AddDrillMove(X1, X2, Y1, Y2, Y3, Z1, Z2, Z3, Cmd, X, Options, ref Job);
  }

  public void AddDrillMove(
    double X1,
    double X2,
    double Y1,
    double Y2,
    double Y3,
    double Z1,
    double Z2,
    double Z3,
    DrillMoveCommand Cmd,
    drillPlaneNames Plane,
    DrillCNCMode Mode,
    double X,
    ref DrillJob Job)
  {
    DrillMoveOptions Options = new DrillMoveOptions(Plane, Mode, DrillMoveAddType.BothMoveAndSimulation);
    this.AddDrillMove(X1, X2, Y1, Y2, Y3, Z1, Z2, Z3, Cmd, X, Options, ref Job);
  }

  public void AddDrillMove(
    double X1,
    double X2,
    double Y1,
    double Y2,
    double Y3,
    double Z1,
    double Z2,
    double Z3,
    DrillMoveCommand Cmd,
    drillPlaneNames Plane,
    DrillCNCMode Mode,
    double X,
    int Tool1,
    int Tool2,
    int Tool3,
    int Tool4,
    int Tool5,
    int Tool6,
    ref DrillJob Job)
  {
    DrillMoveOptions Options = new DrillMoveOptions(Plane, Mode, DrillMoveAddType.BothMoveAndSimulation, Tool1, Tool2, Tool3, Tool4, Tool5, Tool6);
    this.AddDrillMove(X1, X2, Y1, Y2, Y3, Z1, Z2, Z3, Cmd, X, Options, ref Job);
  }

  public void AddDrillMove(
    double X1,
    double X2,
    double Y1,
    double Y2,
    double Y3,
    double Z1,
    double Z2,
    double Z3,
    DrillMoveCommand Cmd,
    double X,
    DrillMoveOptions Options,
    ref DrillJob Job)
  {
    double X1_1 = X1;
    double X2_1 = X2;
    double Y1_1 = Y1;
    double Y2_1 = Y2;
    double Y3_1 = Y3;
    double Z1_1 = Z1;
    double Z2_1 = Z2;
    double Z3_1 = Z3;
    double XPos = X;
    if (Job.Moves.Count > 0 && Cmd == DrillMoveCommand.AxisMove)
    {
      double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
      double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
      double xposition = Job.Moves[Job.Moves.Count - 1].XPosition;
      double y1Position = Job.Moves[Job.Moves.Count - 1].Y1Position;
      double y2Position = Job.Moves[Job.Moves.Count - 1].Y2Position;
      double y3Position = Job.Moves[Job.Moves.Count - 1].Y3Position;
      double z1Position = Job.Moves[Job.Moves.Count - 1].Z1Position;
      double z2Position = Job.Moves[Job.Moves.Count - 1].Z2Position;
      double z3Position = Job.Moves[Job.Moves.Count - 1].Z3Position;
      if ((buCompare5.EQ(X1, x1Clamper, 0.01) | X1 == this.NoMove) & (buCompare5.EQ(X2, x2Clamper, 0.01) | X2 == this.NoMove) & (buCompare5.EQ(X, xposition, 0.01) | X == this.NoMove) && (buCompare5.EQ(Y1, y1Position, 0.01) | Y1 == this.NoMove) & (buCompare5.EQ(Y2, y2Position, 0.01) | Y2 == this.NoMove) & (buCompare5.EQ(Y3, y3Position, 0.01) | Y3 == this.NoMove) && (buCompare5.EQ(Z1, z1Position, 0.01) | Z1 == this.NoMove) & (buCompare5.EQ(Z2, z2Position, 0.01) | Z2 == this.NoMove) & (buCompare5.EQ(Z3, z3Position, 0.01) | Z3 == this.NoMove))
      {
        if (Options.Cmd1 == DrillMoveCommand.None & Options.Cmd2 == DrillMoveCommand.None & Options.Cmd3 == DrillMoveCommand.None)
          return;
        if (Options.Cmd1 == DrillMoveCommand.ResetAll)
          Cmd = Options.Cmd1;
        if (Options.Cmd2 == DrillMoveCommand.ResetAll)
          Cmd = Options.Cmd2;
        if (Options.Cmd3 == DrillMoveCommand.ResetAll)
          Cmd = Options.Cmd3;
        if (Options.Cmd1 == DrillMoveCommand.SetPiston)
          Cmd = Options.Cmd1;
        if (Options.Cmd2 == DrillMoveCommand.SetPiston)
          Cmd = Options.Cmd2;
        if (Options.Cmd3 == DrillMoveCommand.SetPiston)
          Cmd = Options.Cmd3;
      }
    }
    if (Cmd == DrillMoveCommand.AxisMove && X1 == this.NoMove & X2 == this.NoMove & Y1 == this.NoMove & Y2 == this.NoMove & Y3 == this.NoMove & Z1 == this.NoMove & Z2 == this.NoMove & Z3 == this.NoMove & X == this.NoMove && Options.Cmd1 == DrillMoveCommand.None & Options.Cmd2 == DrillMoveCommand.None & Options.Cmd3 == DrillMoveCommand.None)
      return;
    if (Job.Moves.Count > 0 & X1 == this.NoMove)
      X1_1 = Job.Moves[Job.Moves.Count - 1].X1Clamper;
    if (Job.Moves.Count > 0 & X2 == this.NoMove)
      X2_1 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
    if (Job.Moves.Count > 0 & Y1 == this.NoMove)
      Y1_1 = Job.Moves[Job.Moves.Count - 1].Y1Position;
    if (Job.Moves.Count > 0 & Y2 == this.NoMove)
      Y2_1 = Job.Moves[Job.Moves.Count - 1].Y2Position;
    if (Job.Moves.Count > 0 & Y3 == this.NoMove)
      Y3_1 = Job.Moves[Job.Moves.Count - 1].Y3Position;
    if (Job.Moves.Count > 0 & Z1 == this.NoMove)
      Z1_1 = Job.Moves[Job.Moves.Count - 1].Z1Position;
    if (Job.Moves.Count > 0 & Z2 == this.NoMove)
      Z2_1 = Job.Moves[Job.Moves.Count - 1].Z2Position;
    if (Job.Moves.Count > 0 & Z3 == this.NoMove)
      Z3_1 = Job.Moves[Job.Moves.Count - 1].Z3Position;
    if (Job.Moves.Count > 0 & X == this.NoMove)
      XPos = Job.Moves[Job.Moves.Count - 1].XPosition;
    DrillMove drillMove = new DrillMove(X1_1, X2_1, Y1_1, Y2_1, Y3_1, Z1_1, Z2_1, Z3_1, Cmd, XPos);
    drillMove.Tool1 = Options.Tool1;
    drillMove.Tool2 = Options.Tool2;
    drillMove.Tool3 = Options.Tool3;
    drillMove.Tool4 = Options.Tool4;
    drillMove.Tool5 = Options.Tool5;
    drillMove.Tool6 = Options.Tool6;
    drillMove.Tool7 = Options.Tool7;
    drillMove.Tool8 = Options.Tool8;
    drillMove.Tool9 = Options.Tool9;
    drillMove.Tool10 = Options.Tool10;
    drillMove.Tool11 = Options.Tool11;
    drillMove.Tool12 = Options.Tool12;
    drillMove.Mode = Options.Mode;
    drillMove.Plane = Options.Plane;
    drillMove.Command2 = Options.Cmd2;
    drillMove.Command3 = Options.Cmd3;
    if (Options.pntCenter != (Point3D) null)
      drillMove.pntCenter = new Point3D(Options.pntCenter.X, Options.pntCenter.Y, Options.pntCenter.Z);
    if (Options.AddType == DrillMoveAddType.OnlyMove)
      Job.Moves.Add(drillMove);
    else if (Options.AddType == DrillMoveAddType.OnlySimulation)
    {
      if (Job.SimulationMoves.Count == 0)
      {
        Job.SimulationMoves.Add(drillMove);
      }
      else
      {
        List<DrillMove> calcSimMoves = new List<DrillMove>();
        clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, Options.DevideLen, ref calcSimMoves);
        if (calcSimMoves.Count <= 0)
          return;
        for (int index = 0; index <= calcSimMoves.Count - 1; ++index)
          Job.SimulationMoves.Add(calcSimMoves[index]);
      }
    }
    else
    {
      Job.Moves.Add(drillMove);
      if (Job.SimulationMoves.Count == 0 | Cmd != 0)
      {
        Job.SimulationMoves.Add(new DrillMove(drillMove)
        {
          LineIndex = Job.Moves.Count - 1
        });
      }
      else
      {
        double devideLen = clsDrill.varDrillCNCSettings.SimulationDevideG0Length;
        if (drillMove.Mode == DrillCNCMode.Plunge | drillMove.Mode == DrillCNCMode.Cut)
          devideLen = clsDrill.varDrillCNCSettings.SimulationDevideG1Length;
        List<DrillMove> calcSimMoves = new List<DrillMove>();
        clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, devideLen, ref calcSimMoves);
        if (calcSimMoves.Count <= 0)
          return;
        for (int index = 0; index <= calcSimMoves.Count - 1; ++index)
        {
          calcSimMoves[index].LineIndex = Job.Moves.Count - 1;
          Job.SimulationMoves.Add(calcSimMoves[index]);
        }
      }
    }
  }

  public void MirrorOperation(ref DrillJob Job)
  {
    for (int index = 0; index <= Job.Items.Count - 1; ++index)
    {
      if (Job.Items[index] is buShapeHole)
      {
        buShapeHole buShapeHole = Job.Items[index] as buShapeHole;
        if (buShapeHole.planeName == planeBoxNames.Top)
        {
          buShapeHole.BasePoint.Y = Job.Material.Size.Height - buShapeHole.BasePoint.Y;
          clsVar5.shapeCreatePar.Solid = true;
          clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
          clsVar5.shapeCreatePar.SingX = -1.0;
          clsVar5.shapeCreatePar.SingY = -1.0;
          buShape Shape = (buShape) buShapeHole;
          clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
        }
        if (buShapeHole.planeName == planeBoxNames.Left | buShapeHole.planeName == planeBoxNames.Right)
        {
          buShapeHole.BasePoint.Y = Job.Material.Size.Height - buShapeHole.BasePoint.Y;
          clsVar5.shapeCreatePar.Solid = true;
          clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
          clsVar5.shapeCreatePar.SingX = -1.0;
          clsVar5.shapeCreatePar.SingY = -1.0;
          buShape Shape = (buShape) buShapeHole;
          clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
        }
        if (buShapeHole.planeName == planeBoxNames.Front)
        {
          buShapeHole.planeName = planeBoxNames.Back;
          buShapeHole.BasePoint.Y = 0.0;
          clsVar5.shapeCreatePar.Solid = true;
          clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
          clsVar5.shapeCreatePar.SingX = -1.0;
          clsVar5.shapeCreatePar.SingY = -1.0;
          buShape Shape = (buShape) buShapeHole;
          clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
        }
        if (buShapeHole.planeName == planeBoxNames.Back)
        {
          buShapeHole.planeName = planeBoxNames.Front;
          buShapeHole.BasePoint.Y = Job.Material.Size.Height;
          clsVar5.shapeCreatePar.Solid = true;
          clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
          clsVar5.shapeCreatePar.SingX = -1.0;
          clsVar5.shapeCreatePar.SingY = -1.0;
          buShape Shape = (buShape) buShapeHole;
          clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
        }
        if (buShapeHole.entityWireframe.Count > 0)
          clsInit.cVector5.Mirror(new Point3D(0.0, -Job.Material.Size.Height / 2.0, 0.0), new Point3D(10.0, -Job.Material.Size.Height / 2.0, 0.0), Plane.XY, ref buShapeHole.entityWireframe);
      }
      else if (Job.Items[index] is buShapeCut)
      {
        buShapeCut buShapeCut = Job.Items[index] as buShapeCut;
        buShapeCut.BasePoint.Y = Job.Material.Size.Height - buShapeCut.BasePoint.Y;
        clsVar5.shapeCreatePar.Solid = true;
        clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
        clsVar5.shapeCreatePar.SingX = -1.0;
        clsVar5.shapeCreatePar.SingY = -1.0;
        buShape Shape = (buShape) buShapeCut;
        clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
        if (buShapeCut.entityWireframe.Count > 0)
          clsInit.cVector5.Mirror(new Point3D(0.0, -Job.Material.Size.Height / 2.0, 0.0), new Point3D(10.0, -Job.Material.Size.Height / 2.0, 0.0), Plane.XY, ref buShapeCut.entityWireframe);
      }
    }
  }

  public bool isOperationActive()
  {
    return clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible || clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible || clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible || clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible || clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible || clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible;
  }

  public void OperationToParameter(buShape Shape, ref ShapeRuntimeData varSettings)
  {
    if (Shape.ShapeGroup == ShapeGroup.Drill)
    {
      varSettings.ShapeGroup = Shape.ShapeGroup;
      varSettings.selectedPlane = Shape.planeName;
      varSettings.selectedCorner = Shape.Corner;
      varSettings.objectAlignment = Shape.Alignment;
      varSettings.selectedPlane = Shape.planeName;
      varSettings.pntBase = buVector5.ToPoint3D(Shape.BasePoint);
      if (Shape.GetType() == typeof (buShapeHole))
      {
        buShapeHole buShapeHole = Shape as buShapeHole;
        varSettings.DrillType = buShapeHole.DrillType;
        varSettings.HoleDiameter = buShapeHole.Diameter;
        varSettings.HoleDepth = buShapeHole.Depth;
        varSettings.isMillingHole = buShapeHole.isMilling;
      }
      else if (Shape.GetType() == typeof (buShapeHoleMulti))
      {
        buShapeHoleMulti buShapeHoleMulti = Shape as buShapeHoleMulti;
        if (buShapeHoleMulti.DrillType == drillTypes.HorizontalHoles | buShapeHoleMulti.DrillType == drillTypes.VerticalHoles)
        {
          varSettings.DrillType = buShapeHoleMulti.DrillType;
          varSettings.HoleDiameter = buShapeHoleMulti.Diameter;
          varSettings.HoleDepth = buShapeHoleMulti.Depth;
          varSettings.HoleDistance = buShapeHoleMulti.Distance;
          varSettings.HoleCount = buShapeHoleMulti.Count;
          varSettings.isMillingHole = buShapeHoleMulti.isMilling;
        }
        if (buShapeHoleMulti.DrillType == drillTypes.HorizontalLineHoles | buShapeHoleMulti.DrillType == drillTypes.VerticalLineHoles)
        {
          varSettings.DrillType = buShapeHoleMulti.DrillType;
          varSettings.HoleDiameter = buShapeHoleMulti.Diameter;
          varSettings.HoleDepth = buShapeHoleMulti.Depth;
          varSettings.HoleDistance = buShapeHoleMulti.Distance;
          varSettings.HoleEndDistance = buShapeHoleMulti.EndDistance;
          varSettings.HoleStartDistance = buShapeHoleMulti.StartDistance;
          varSettings.isMillingHole = buShapeHoleMulti.isMilling;
        }
        if (buShapeHoleMulti.DrillType == drillTypes.InclineHoles)
        {
          varSettings.DrillType = buShapeHoleMulti.DrillType;
          varSettings.HoleDiameter = buShapeHoleMulti.Diameter;
          varSettings.HoleDepth = buShapeHoleMulti.Depth;
          varSettings.HoleDistance = buShapeHoleMulti.Distance;
          varSettings.HoleAngle = buShapeHoleMulti.Angle;
          varSettings.HoleCount = buShapeHoleMulti.Count;
          varSettings.isMillingHole = buShapeHoleMulti.isMilling;
        }
      }
      else if (Shape.GetType() == typeof (buShapeHole3))
      {
        buShapeHole3 buShapeHole3 = Shape as buShapeHole3;
        if (buShapeHole3.DrillType == drillTypes.ThreeHole)
        {
          varSettings.DrillType = buShapeHole3.DrillType;
          varSettings.HoleDiameter = buShapeHole3.Diameter;
          varSettings.HoleDiameterOutside = buShapeHole3.DiameterOutside;
          varSettings.HoleDepth = buShapeHole3.Depth;
          varSettings.HoleOutsideDisX = buShapeHole3.DistanceX;
          varSettings.HoleOutsideDisY = buShapeHole3.DistanceY;
          varSettings.HoleAngle3Point = buShapeHole3.Hole3Angle;
          varSettings.isMillingHole = buShapeHole3.isMilling;
        }
      }
    }
    if (Shape.ShapeGroup == ShapeGroup.Shape)
    {
      varSettings.ShapeGroup = Shape.ShapeGroup;
      varSettings.selectedPlane = Shape.planeName;
      varSettings.selectedCorner = Shape.Corner;
      varSettings.objectAlignment = Shape.Alignment;
      varSettings.selectedPlane = Shape.planeName;
      varSettings.pntBase = buVector5.ToPoint3D(Shape.BasePoint);
      varSettings.isShapePocket = Shape.isPocket;
      if (Shape.ShapeType == ShapeTypes.Circle)
      {
        buShapeCircle buShapeCircle = Shape as buShapeCircle;
        varSettings.CircleDepth = buShapeCircle.Depth;
        varSettings.CircleRadius = buShapeCircle.Radius;
      }
      if (Shape.ShapeType == ShapeTypes.Ellipse)
      {
        buShapeEllipse buShapeEllipse = Shape as buShapeEllipse;
        varSettings.EllipseDepth = buShapeEllipse.Depth;
        varSettings.EllipseAngle = buShapeEllipse.Angle;
        varSettings.EllipseRadiusX = buShapeEllipse.RadiusX;
        varSettings.EllipseRadiusY = buShapeEllipse.RadiusY;
      }
      if (Shape.ShapeType == ShapeTypes.FreeDraw)
      {
        buShapeFreeDraw buShapeFreeDraw = Shape as buShapeFreeDraw;
        varSettings.FreeDrawDepth = buShapeFreeDraw.Depth;
        varSettings.FreeDrawAngle = buShapeFreeDraw.Angle;
        varSettings.FreeDrawWidth = buShapeFreeDraw.Width;
        varSettings.FreeDrawHeight = buShapeFreeDraw.Height;
      }
      if (Shape.ShapeType == ShapeTypes.KeyHole)
      {
        buShapeKeyHole buShapeKeyHole = Shape as buShapeKeyHole;
        varSettings.KeyHoleAngle = buShapeKeyHole.Angle;
        varSettings.KeyHoleDepth = buShapeKeyHole.Depth;
        varSettings.KeyHoleDiameter = buShapeKeyHole.Diameter;
        varSettings.KeyHoleHeadDiameter = buShapeKeyHole.HeadDiameter;
        varSettings.KeyHoleLength = buShapeKeyHole.Length;
      }
      if (Shape.ShapeType == ShapeTypes.Polygon)
      {
        buShapePolygon buShapePolygon = Shape as buShapePolygon;
        varSettings.PolygonAngle = buShapePolygon.Angle;
        varSettings.PolygonDepth = buShapePolygon.Depth;
        varSettings.PolygonRadius = buShapePolygon.Radius;
        varSettings.PolygonSide = buShapePolygon.Side;
      }
      if (Shape.ShapeType == ShapeTypes.Rectangle)
      {
        buShapeRectangle buShapeRectangle = Shape as buShapeRectangle;
        varSettings.RectangleAngle = buShapeRectangle.Angle;
        varSettings.RectangleChamfer = buShapeRectangle.Chamfer;
        varSettings.RectangleDepth = buShapeRectangle.Depth;
        varSettings.RectangleHeight = buShapeRectangle.Height;
        varSettings.RectangleRadius = buShapeRectangle.Radius;
        varSettings.RectangleWidth = buShapeRectangle.Width;
      }
      if (Shape.ShapeType == ShapeTypes.Slot)
      {
        buShapeSlot buShapeSlot = Shape as buShapeSlot;
        varSettings.SlotAngle = buShapeSlot.Angle;
        varSettings.SlotDepth = buShapeSlot.Depth;
        varSettings.SlotDiameter = buShapeSlot.Diameter;
        varSettings.SlotLength = buShapeSlot.Length;
      }
    }
    if (Shape.ShapeGroup == ShapeGroup.Cut)
    {
      varSettings.ShapeGroup = Shape.ShapeGroup;
      varSettings.selectedPlane = Shape.planeName;
      varSettings.selectedCorner = Shape.Corner;
      varSettings.objectAlignment = Shape.Alignment;
      varSettings.selectedPlane = Shape.planeName;
      varSettings.pntBase = buVector5.ToPoint3D(Shape.BasePoint);
      if (Shape.GetType() == typeof (buShapeCut))
      {
        buShapeCut buShapeCut = Shape as buShapeCut;
        varSettings.CutType = buShapeCut.CutType;
        varSettings.CutAngle = buShapeCut.Angle;
        varSettings.CutDepth = buShapeCut.Depth;
        varSettings.CutDiameter = buShapeCut.Diameter;
        varSettings.CutEndDistance = buShapeCut.EndDistance;
        varSettings.CutLength = buShapeCut.Length;
        varSettings.CutStartDistance = buShapeCut.StartDistance;
        varSettings.isMillingCut = buShapeCut.isMilling;
      }
    }
    if (Shape.ShapeGroup != ShapeGroup.Profiling)
      return;
    varSettings.ShapeGroup = Shape.ShapeGroup;
    varSettings.selectedPlane = Shape.planeName;
    varSettings.selectedCorner = Shape.Corner;
    varSettings.objectAlignment = Shape.Alignment;
    varSettings.selectedPlane = Shape.planeName;
    varSettings.isProfilingPocket = Shape.isPocket;
    varSettings.pntBase = buVector5.ToPoint3D(Shape.BasePoint);
    if (!(Shape.GetType() == typeof (buShapeProfiling)))
      return;
    buShapeProfiling buShapeProfiling = Shape as buShapeProfiling;
    varSettings.ProfilingType = buShapeProfiling.ProfilingType;
    varSettings.ProfilingDepth = buShapeProfiling.Depth;
    varSettings.ProfilingHeight = buShapeProfiling.Height;
    varSettings.ProfilingLength = buShapeProfiling.Length;
    varSettings.ProfilingRadius = buShapeProfiling.Radius;
    varSettings.ProfilingWidth = buShapeProfiling.Width;
  }

  public void GetPickEntity(int index)
  {
    if (clsItem.FrmDrillJob.tree_jobs.Nodes == null || clsItem.FrmDrillJob.tree_jobs.Nodes.Count <= 0 || clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes == null || ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData == null || !(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData is CustomData))
      return;
    CustomData entityData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
    if (!(entityData.RefIndex >= 0 & entityData.RefIndex <= clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes.Count - 1))
      return;
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    clsInit.appCommand.Reset();
    clsItem.FrmDrillJob.tree_jobs.SelectedNode = clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes[entityData.RefIndex];
  }

  public void GetIndexFromItemID(int ID, List<DrillCalcItem> Items, ref int Index)
  {
    Index = -1;
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (Items[index].ID == ID)
      {
        Index = index;
        break;
      }
    }
  }

  public void SetAsUsedToolByNo(int ToolNo, ref List<ToolBase5> Tools)
  {
    for (int index = 0; index <= Tools.Count - 1; ++index)
    {
      if (Tools[index].Data.No == ToolNo)
        Tools[index].Data.Used = true;
    }
  }

  public void SetAsCalculatedDrillItemByID(int ID)
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstTop.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.SplitedItems.lstTop[index1].Count - 1; ++index2)
      {
        if (this.SplitedItems.lstTop[index1][index2].ID == ID)
          this.SplitedItems.lstTop[index1][index2].Calculated = true;
      }
    }
    for (int index3 = 0; index3 <= this.SplitedItems.lstBottom.Count - 1; ++index3)
    {
      for (int index4 = 0; index4 <= this.SplitedItems.lstBottom[index3].Count - 1; ++index4)
      {
        if (this.SplitedItems.lstBottom[index3][index4].ID == ID)
          this.SplitedItems.lstBottom[index3][index4].Calculated = true;
      }
    }
    for (int index5 = 0; index5 <= this.SplitedItems.lstLeftRight.Count - 1; ++index5)
    {
      for (int index6 = 0; index6 <= this.SplitedItems.lstLeftRight[index5].Count - 1; ++index6)
      {
        if (this.SplitedItems.lstLeftRight[index5][index6].ID == ID)
          this.SplitedItems.lstLeftRight[index5][index6].Calculated = true;
      }
    }
    for (int index7 = 0; index7 <= this.SplitedItems.lstFront.Count - 1; ++index7)
    {
      for (int index8 = 0; index8 <= this.SplitedItems.lstFront[index7].Count - 1; ++index8)
      {
        if (this.SplitedItems.lstFront[index7][index8].ID == ID)
          this.SplitedItems.lstFront[index7][index8].Calculated = true;
      }
    }
    for (int index9 = 0; index9 <= this.SplitedItems.lstBack.Count - 1; ++index9)
    {
      for (int index10 = 0; index10 <= this.SplitedItems.lstBack[index9].Count - 1; ++index10)
      {
        if (this.SplitedItems.lstBack[index9][index10].ID == ID)
          this.SplitedItems.lstBack[index9][index10].Calculated = true;
      }
    }
  }

  public void ClearCalculatedThings(bool ToolData = true, bool CalculatedData = true)
  {
    for (int index1 = 0; index1 <= this.SplitedItems.lstTop.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= this.SplitedItems.lstTop[index1].Count - 1; ++index2)
      {
        if (CalculatedData)
          this.SplitedItems.lstTop[index1][index2].Calculated = false;
        if (ToolData)
          this.SplitedItems.lstTop[index1][index2].Tool = 0;
      }
    }
    for (int index3 = 0; index3 <= this.SplitedItems.lstBottom.Count - 1; ++index3)
    {
      for (int index4 = 0; index4 <= this.SplitedItems.lstBottom[index3].Count - 1; ++index4)
      {
        if (CalculatedData)
          this.SplitedItems.lstBottom[index3][index4].Calculated = false;
        if (ToolData)
          this.SplitedItems.lstBottom[index3][index4].Tool = 0;
      }
    }
    for (int index5 = 0; index5 <= this.SplitedItems.lstLeftRight.Count - 1; ++index5)
    {
      for (int index6 = 0; index6 <= this.SplitedItems.lstLeftRight[index5].Count - 1; ++index6)
      {
        if (CalculatedData)
          this.SplitedItems.lstLeftRight[index5][index6].Calculated = false;
        if (ToolData)
          this.SplitedItems.lstLeftRight[index5][index6].Tool = 0;
      }
    }
    for (int index7 = 0; index7 <= this.SplitedItems.lstFront.Count - 1; ++index7)
    {
      for (int index8 = 0; index8 <= this.SplitedItems.lstFront[index7].Count - 1; ++index8)
      {
        if (CalculatedData)
          this.SplitedItems.lstFront[index7][index8].Calculated = false;
        if (ToolData)
          this.SplitedItems.lstFront[index7][index8].Tool = 0;
      }
    }
    for (int index9 = 0; index9 <= this.SplitedItems.lstBack.Count - 1; ++index9)
    {
      for (int index10 = 0; index10 <= this.SplitedItems.lstBack[index9].Count - 1; ++index10)
      {
        if (CalculatedData)
          this.SplitedItems.lstBack[index9][index10].Calculated = false;
        if (ToolData)
          this.SplitedItems.lstBack[index9][index10].Tool = 0;
      }
    }
  }

  public void SetAsCalculatedDrillItemByID(int ID, ref List<DrillCalcItem> Items)
  {
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      if (Items[index].ID == ID)
        Items[index].Calculated = true;
    }
  }

  public void SplitItemsByDepth(
    List<DrillCalcItem> Items,
    ref List<List<DrillCalcItem>> SplitedItems)
  {
    if (Items.Count <= 0)
      return;
    SplitedItems.Add(new List<DrillCalcItem>()
    {
      new DrillCalcItem(Items[0])
    });
    for (int index1 = 1; index1 <= Items.Count - 1; ++index1)
    {
      bool flag = false;
      for (int index2 = 0; index2 <= SplitedItems.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= SplitedItems[index2].Count - 1; ++index3)
        {
          if (buCompare5.EQ(SplitedItems[index2][index3].Depth, Items[index1].Depth, 0.01) & !flag)
          {
            SplitedItems[index2].Add(new DrillCalcItem(Items[index1]));
            flag = true;
          }
        }
      }
      if (!flag)
        SplitedItems.Add(new List<DrillCalcItem>()
        {
          new DrillCalcItem(Items[index1])
        });
    }
  }

  public bool CheckOperations(buShape Shape, ref List<string> Messages)
  {
    bool flag;
    if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
      flag = this.cGoUltra2Up1Down.CheckOperationsGoUltra2Top1BottomNoAtc(Shape, ref Messages);
    else if (this.MachType == DrillMachineType.GoWithAtc)
      flag = this.cGoAtc.CheckOperationsGoUltra2Top1BottomNoAtc(Shape, ref Messages);
    else if (this.MachType == DrillMachineType.Sirius)
    {
      flag = this.cGoSirius.CheckOperationsGoUltra2Top1BottomNoAtc(Shape, ref Messages);
    }
    else
    {
      Messages.Add(buDrillCalc.LangDrillMessage[58]);
      flag = false;
    }
    return flag;
  }

  public void ShapeChanged(object Data1, object Data2)
  {
    CustomData customData = new CustomData();
    buShape Shape = Data1 as buShape;
    ShapeUpdateArg shapeUpdateArg = Data2 as ShapeUpdateArg;
    if (Shape.ShapeGroup == ShapeGroup.Profiling)
    {
      Shape.LeadInOut.LeadInLength = clsDrill.varDrillCNCSettings.ProfilingLeadInDistance;
      Shape.LeadInOut.LeadOutLength = clsDrill.varDrillCNCSettings.ProfilingLeadOutDistance;
    }
    if (!shapeUpdateArg.Finished)
    {
      ccVars.pntDrawDynamicLinesArr.Clear();
      clsVar5.shapeCreatePar.Solid = false;
      clsVar5.shapeCreatePar.Size = new SizeObject(clsDrill.activeJob.Material.Size);
      clsVar5.shapeCreatePar.SingX = -1.0;
      clsVar5.shapeCreatePar.SingY = -1.0;
      clsVar5.ShapeDataParameters.DrillType = drillTypes.SingleHole;
      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
      if (Shape.entitiesShape.Count > 0 | Shape.entitySolid.Count > 0)
      {
        if (Shape.entitySolid != null)
        {
          ViewportDrawOptions Options = new ViewportDrawOptions();
          Options.OtherEntities = new List<Entity>();
          for (int index = 0; index <= Shape.entitySolid.Count - 1; ++index)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(Shape.entitySolid[index], ref copiedEntity);
            if (index == 0)
              copiedEntity.Selected = false;
            copiedEntity.Selectable = false;
            copiedEntity.Regen(0.01);
            Options.ViewportRef = ViewportRefType.Operation;
            Options.OtherEntities.Add(copiedEntity);
          }
          Options.calcPoint = new Point3D(Shape.CalculatedPoint.X, Shape.CalculatedPoint.Y, Shape.CalculatedPoint.Z);
          Options.refPoint = new Point3D(Shape.BasePoint.X, Shape.BasePoint.Y, Shape.BasePoint.Z);
          double num = Point3D.Distance(Shape.ItemSize.MinBox, Shape.ItemSize.MaxBox) * 0.05;
          if (Shape.ShapeGroup == ShapeGroup.Drill)
            num = clsVar5.ShapeDataParameters.HoleDiameter * 0.05;
          else if (Shape.ShapeGroup == ShapeGroup.Cut)
            num = clsVar5.ShapeDataParameters.CutDiameter;
          if (num > 10.0)
            num = 10.0;
          Joint joint1 = new Joint(buVector5.ToPoint3D(Shape.CalculatedPoint), num * 1.0, (byte) 2);
          joint1.Color = Color.Red;
          joint1.ColorMethod = colorMethodType.byEntity;
          joint1.Regen(0.1);
          Options.OtherEntities.Add((Entity) joint1);
          Options.GroupType = Shape.ShapeGroup;
          Joint joint2 = new Joint(buVector5.ToPoint3D(Shape.CornerPoint), num * 1.0, (byte) 2);
          joint2.Color = Color.Red;
          joint2.ColorMethod = colorMethodType.byEntity;
          joint2.Regen(0.1);
          if (clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.XPosition | clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.ZPosition | clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.YPosition)
            joint2.Selected = true;
          Options.OtherEntities.Add((Entity) joint2);
          Options.GroupType = Shape.ShapeGroup;
          this.DrawPanelFromJob(clsDrill.activeJob, Options, Shape);
        }
        if (Shape.ShapeGroup == ShapeGroup.Drill)
          clsItem.FrmDrillList.viewportLayout.Entities.ClearSelection();
        else if (Shape.ShapeGroup == ShapeGroup.Cut)
          clsItem.FrmSlotList.viewportLayout.Entities.ClearSelection();
        else if (Shape.ShapeGroup == ShapeGroup.Shape)
          clsItem.FrmShapeList.viewportLayout.Entities.ClearSelection();
        else if (Shape.ShapeGroup == ShapeGroup.Profiling)
          clsItem.FrmProfilingList.viewportLayout.Entities.ClearSelection();
        for (int index = 0; index <= Shape.entitiesShape.Count - 1; ++index)
        {
          List<Point3D> copiedPoint = new List<Point3D>();
          buVector5.Copy(Shape.entitiesShape[index].Vertices, ref copiedPoint);
          ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
        }
        if (Shape.ShapeGroup == ShapeGroup.Engraving)
        {
          List<List<Point3D>> refPoints = new List<List<Point3D>>();
          clsInit.cVector5.CreateBoxOrRectangleFromBoxSize(Shape.ItemSize.MinBox, Shape.ItemSize.MaxBox, ref refPoints);
          for (int index = 0; index <= refPoints.Count - 1; ++index)
            ccVars.pntDrawDynamicLinesArr.Add(refPoints[index]);
        }
      }
      if ((clsItem.FrmDrillList == null ? 0 : (clsItem.FrmDrillList.Visible ? 1 : 0)) != 0)
      {
        clsItem.FrmDrillList.lst_info.Visible = false;
        clsItem.FrmDrillList.lst_info.Items.Clear();
      }
      if ((clsItem.FrmShapeList == null ? 0 : (clsItem.FrmShapeList.Visible ? 1 : 0)) != 0)
      {
        clsItem.FrmShapeList.lst_info.Visible = false;
        clsItem.FrmShapeList.lst_info.Items.Clear();
      }
      if (Shape.InfoMessages != null && Shape.InfoMessages.Count > 0)
      {
        if (Shape.ShapeGroup == ShapeGroup.Drill)
        {
          clsItem.FrmDrillList.lst_info.Visible = true;
          for (int index = 0; index <= Shape.InfoMessages.Count - 1; ++index)
            clsItem.FrmDrillList.lst_info.Items.Add((object) Shape.InfoMessages[index]);
        }
        if (Shape.ShapeGroup == ShapeGroup.Shape)
        {
          clsItem.FrmShapeList.lst_info.Visible = true;
          for (int index = 0; index <= Shape.InfoMessages.Count - 1; ++index)
            clsItem.FrmShapeList.lst_info.Items.Add((object) Shape.InfoMessages[index]);
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    else
    {
      clsVar5.shapeCreatePar.Solid = true;
      clsVar5.shapeCreatePar.Size = new SizeObject(clsDrill.activeJob.Material.Size);
      clsVar5.shapeCreatePar.SingX = -1.0;
      clsVar5.shapeCreatePar.SingY = -1.0;
      Shape.BasePoint.X = shapeUpdateArg.Parameters.pntBase.X;
      Shape.BasePoint.Y = shapeUpdateArg.Parameters.pntBase.Y;
      Shape.BasePoint.Z = shapeUpdateArg.Parameters.pntBase.Z;
      clsVar5.ShapeDataParameters.pntBase.X = shapeUpdateArg.Parameters.pntBase.X;
      clsVar5.ShapeDataParameters.pntBase.Y = shapeUpdateArg.Parameters.pntBase.Y;
      clsVar5.ShapeDataParameters.pntBase.Z = shapeUpdateArg.Parameters.pntBase.Z;
      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
      Shape.Tool = new ToolBase5(ccVars.toolActive);
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Drill)
      {
        for (int index1 = 0; index1 <= ccVars.Tools.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= ccVars.Tools[index1].Tools.Count - 1; ++index2)
          {
            if (Shape is buShapeHole && buCompare5.EQ(ccVars.Tools[index1].Tools[index2].Geometry.Diameter, ((buShapeHole) Shape).Diameter))
            {
              Shape.Tool = new ToolBase5(ccVars.Tools[index1].Tools[index2]);
              clsDrill.toolTop = new ToolBase5(ccVars.Tools[index1].Tools[index2]);
              ccVars.toolActive = new ToolBase5(ccVars.Tools[index1].Tools[index2]);
            }
          }
        }
      }
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Cut && (clsItem.FrmSlotList == null ? 0 : (clsItem.FrmSlotList.ShowTool ? 1 : 0)) != 0 && clsItem.FrmSlotList.activeTool != null)
      {
        Shape.Tool = new ToolBase5(clsItem.FrmSlotList.activeTool);
        ccVars.toolActive = new ToolBase5(clsItem.FrmSlotList.activeTool);
      }
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Shape && (clsItem.FrmShapeList == null ? 0 : (clsItem.FrmShapeList.ShowTool ? 1 : 0)) != 0 && clsItem.FrmShapeList.activeTool != null)
      {
        Shape.Tool = new ToolBase5(clsItem.FrmShapeList.activeTool);
        ccVars.toolActive = new ToolBase5(clsItem.FrmShapeList.activeTool);
      }
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Profiling && (clsItem.FrmProfilingList == null ? 0 : (clsItem.FrmProfilingList.ShowTool ? 1 : 0)) != 0 && clsItem.FrmProfilingList.activeTool != null)
      {
        Shape.Tool = new ToolBase5(clsItem.FrmProfilingList.activeTool);
        ccVars.toolActive = new ToolBase5(clsItem.FrmProfilingList.activeTool);
      }
      if (!this.CheckOperations(Shape, ref this.operationErrorList) && this.operationErrorList.Count > 0)
      {
        DialogBoxList dialogBoxList = new DialogBoxList();
        dialogBoxList.lst_items.ScrollAlwaysVisible = true;
        dialogBoxList.lst_items.HorizontalScrollbar = true;
        dialogBoxList.Caption = buLangTranslate.preDef.Error;
        dialogBoxList.Width = 500;
        for (int index = 0; index <= this.operationErrorList.Count - 1; ++index)
          dialogBoxList.Items.Add(this.operationErrorList[index]);
        dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
        dialogBoxList.Init();
        int num = (int) dialogBoxList.ShowDialog();
        if (dialogBoxList.Result != DialogResult.OK)
        {
          clsInit.appCommand.Reset();
          return;
        }
      }
      Shape.DepthLevel = new List<double>();
      Shape.DepthLevel.AddRange((IEnumerable<double>) shapeUpdateArg.Parameters.DepthLevels);
      clsVar5.ShapeDataParameters = new ShapeRuntimeData(shapeUpdateArg.Parameters);
      buShape buShape = buShape.Copy(Shape);
      buShape.InfoMessages = (List<string>) null;
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Drill)
        clsVar5.lastDrill = buShape.Copy(Shape);
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Cut)
      {
        clsVar5.lastCut = buShape.Copy(Shape);
        buShape.Tool = new ToolBase5(ccVars.toolActive);
      }
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Shape)
      {
        clsVar5.lastShape = buShape.Copy(Shape);
        buShape.Tool = new ToolBase5(ccVars.toolActive);
      }
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Junction)
        clsVar5.lastJunction = buShape.Copy(Shape);
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Profiling)
      {
        clsVar5.lastProfiling = buShape.Copy(Shape);
        buShape.Tool = new ToolBase5(ccVars.toolActive);
      }
      if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Contour)
      {
        clsVar5.lastProfiling = buShape.Copy(Shape);
        buShape.Tool = new ToolBase5(ccVars.toolActive);
      }
      if (buShape.CamPar != null)
        buMWDrillVars.varCamContour.buPar = new camParameters5(buShape.CamPar);
      buShape.ID = this.IDCounter;
      if (!this.EditOperation)
      {
        clsDrill.activeJob.Items.Add(buShape);
      }
      else
      {
        if (this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1)
          clsDrill.activeJob.Items[this.selectedItemIndex] = buShape;
        if (clsItem.FrmDrillList != null)
          clsItem.FrmDrillList.Visible = false;
        if (clsItem.FrmShapeList != null)
          clsItem.FrmShapeList.Visible = false;
        if (clsItem.FrmSlotList != null)
          clsItem.FrmSlotList.Visible = false;
        if (clsItem.FrmProfilingList != null)
          clsItem.FrmProfilingList.Visible = false;
      }
      this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
      this.SaveDrillFile();
      clsInit.appCommand.Reset();
      this.JobUpdate(true, (DrillItem) null);
      this.operationErrorList.Clear();
      this.calcErrorList.Clear();
      ++this.IDCounter;
    }
  }

  public void ShapeCancel()
  {
    clsInit.appCommand.Reset();
    this.EditOperation = false;
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buDrill.lng") : new FileInfo(AppPath.Language + "\\buDrill.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillCommands);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Drill Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Drill Language File Missing");
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

  public void SaveDrillFile()
  {
    try
    {
      ArrayList ALSettings = new ArrayList();
      ArrayList ALCam = new ArrayList();
      this.SaveDrillFile(ref ALSettings, ref ALCam);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[17];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void SaveDrillFile(ref ArrayList ALSettings, ref ArrayList ALCam)
  {
    try
    {
      string str = AppPath.Settings + "\\Drill\\";
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
        str += "\\GoUltra2Up1Down\\";
      if (this.MachType == DrillMachineType.GoWithAtc)
        str += "\\GoAtc\\";
      if (this.MachType == DrillMachineType.Sirius)
        str += "\\Sirius\\";
      string FileName1 = str + "Drill.prm";
      ALSettings = new ArrayList();
      ALSettings.Add((object) "------------------------------------------------------------------------");
      ALSettings.Add((object) "   Drill Settings");
      ALSettings.Add((object) "------------------------------------------------------------------------");
      ALSettings.Add((object) "<DrillSettings>");
      ALSettings.AddRange((ICollection) clsDrill.varDrillSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      ALSettings.Add((object) "</DrillSettings>");
      ALSettings.Add((object) "<varDrillCNCSettings>");
      ALSettings.AddRange((ICollection) clsDrill.varDrillCNCSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      ALSettings.Add((object) "</varDrillCNCSettings>");
      ALSettings.Add((object) "<varDrillMachineSettings>");
      ALSettings.AddRange((ICollection) clsDrill.varDrillMachineSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      ALSettings.Add((object) "</varDrillMachineSettings>");
      ALSettings.Add((object) "<DrillRuntimeSettings>");
      ALSettings.AddRange((ICollection) clsDrill.varDrillRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      ALSettings.Add((object) "</DrillRuntimeSettings>");
      ALSettings.Add((object) "<ShapeDataParameters>");
      ALSettings.AddRange((ICollection) clsVar5.ShapeDataParameters.ToDefAll("", 2, SerilizationMode5.MultiLine));
      ALSettings.Add((object) "</ShapeDataParameters>");
      buFile.SaveToFile(ALSettings, FileName1);
      buLog.addLog("Drill Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      buMWDrillVars.varCamContour.mwPar.Serialize(str + "mwDrillContour.bin");
      buMWDrillVars.varCamRough.mwPar.Serialize(str + "mwDrillRough.bin");
      buMWDrillVars.varCamMeshRough.mwPar.Serialize(str + "mwDrillMeshRough.bin");
      buMWDrillVars.varCamMeshParalelCut.mwPar.Serialize(str + "mwDrillMeshParalelCut.bin");
      string FileName2 = str + "DrillCam.bucamset";
      ALCam = new ArrayList();
      ALCam.Add((object) "------------------------------------------------------------------------");
      ALCam.Add((object) "   MW Cam Settings");
      ALCam.Add((object) "------------------------------------------------------------------------");
      ALCam.Add((object) "<MwCamSettings>");
      ALCam.AddRange((ICollection) buMWDrillVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
      ALCam.AddRange((ICollection) buMWDrillVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
      ALCam.AddRange((ICollection) buMWDrillVars.varCamMeshParalelCut.buPar.ToDefAll("_varCamMeshParalelCut", 2, SerilizationMode5.MultiLine));
      ALCam.AddRange((ICollection) buMWDrillVars.varCamMeshRough.buPar.ToDefAll("_varCamMeshRough", 2, SerilizationMode5.MultiLine));
      ALCam.Add((object) "</MwCamSettings>");
      buFile.SaveToFile(ALCam, FileName2);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[17];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenDrillFile()
  {
    try
    {
      ArrayList StringList1 = new ArrayList();
      ArrayList StringList2 = new ArrayList();
      string str = AppPath.Settings + "\\Drill\\";
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
        str += "\\GoUltra2Up1Down\\";
      if (this.MachType == DrillMachineType.GoWithAtc)
        str += "\\GoAtc\\";
      if (this.MachType == DrillMachineType.Sirius)
        str += "\\Sirius\\";
      FileInfo fileInfo1 = new FileInfo(str + "Drill.prm");
      if (fileInfo1.Exists)
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList1);
      FileInfo fileInfo2 = new FileInfo(str + "DrillCam.bucamset");
      if (fileInfo2.Exists)
        buFile.OpenFromFile(fileInfo2.FullName, ref StringList2);
      this.OpenDrillFile(StringList1, StringList2);
      FileInfo fileInfo3 = new FileInfo(str + "mwDrillContour.bin");
      if (fileInfo3.Exists)
        buMWDrillVars.varCamContour.mwPar.Deserialize(fileInfo3.FullName);
      FileInfo fileInfo4 = new FileInfo(str + "mwDrillRough.bin");
      if (fileInfo4.Exists)
        buMWDrillVars.varCamRough.mwPar.Deserialize(fileInfo4.FullName);
      FileInfo fileInfo5 = new FileInfo(str + "mwDrillMeshRough.bin");
      if (fileInfo5.Exists)
        buMWDrillVars.varCamMeshRough.mwPar.Deserialize(fileInfo5.FullName);
      FileInfo fileInfo6 = new FileInfo(str + "mwDrillMeshParalelCut.bin");
      if (fileInfo6.Exists)
        buMWDrillVars.varCamMeshParalelCut.mwPar.Deserialize(fileInfo6.FullName);
      if (clsInit.appEditor == null)
        return;
      clsInit.appEditor.OpenEditorFile();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenDrillFile(ArrayList ALSettings, ArrayList ALCam)
  {
    try
    {
      if (ALSettings.Count > 0)
      {
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<DrillSettings>", "</DrillSettings>", true, ALSettings, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, (object) clsDrill.varDrillSettings);
            buLog.addLog("Drill Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<varDrillCNCSettings>", "</varDrillCNCSettings>", true, ALSettings, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, (object) clsDrill.varDrillCNCSettings);
            buLog.addLog("Drill varDrillCNCSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<varDrillMachineSettings>", "</varDrillMachineSettings>", true, ALSettings, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, (object) clsDrill.varDrillMachineSettings);
            buLog.addLog("Drill varDrillMachineSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<DrillRuntimeSettings>", "</DrillRuntimeSettings>", true, ALSettings, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, (object) clsDrill.varDrillRunSettings);
            buLog.addLog("Drill RuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<ShapeDataParameters>", "</DrillRuntShapeDataParametersimeSettings>", true, ALSettings, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, (object) clsVar5.ShapeDataParameters);
            buLog.addLog(" ShapeDataParameters Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Drill Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Drill Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Drill Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Drill Settings File Missing");
      }
      buLog.addLog("Drill Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      if (ALCam.Count > 0)
      {
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", true, ALCam, ref CalcList);
          if (CalcList.Count <= 0)
            return;
          buSerilization.Decode(ALCam, "_varCamContour", SerilizationMode.MultiLine, (object) buMWDrillVars.varCamContour.buPar);
          buSerilization.Decode(ALCam, "_varCamRough", SerilizationMode.MultiLine, (object) buMWDrillVars.varCamRough.buPar);
          buSerilization.Decode(ALCam, "_varCamMeshRough", SerilizationMode.MultiLine, (object) buMWDrillVars.varCamMeshRough.buPar);
          buSerilization.Decode(ALCam, "_varCamMeshParalelCut", SerilizationMode.MultiLine, (object) buMWDrillVars.varCamMeshParalelCut.buPar);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Drill Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Drill Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Drill Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Drill Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void AddRecentOpenFile(string FileName)
  {
    if (!(FileName != clsDrill.varDrillRunSettings.RecentOpenFile1))
      return;
    if (clsDrill.varDrillRunSettings.RecentOpenFile6 != clsDrill.varDrillRunSettings.RecentOpenFile5)
      clsDrill.varDrillRunSettings.RecentOpenFile6 = clsDrill.varDrillRunSettings.RecentOpenFile5;
    if (clsDrill.varDrillRunSettings.RecentOpenFile5 != clsDrill.varDrillRunSettings.RecentOpenFile4)
      clsDrill.varDrillRunSettings.RecentOpenFile5 = clsDrill.varDrillRunSettings.RecentOpenFile4;
    if (clsDrill.varDrillRunSettings.RecentOpenFile4 != clsDrill.varDrillRunSettings.RecentOpenFile3)
      clsDrill.varDrillRunSettings.RecentOpenFile4 = clsDrill.varDrillRunSettings.RecentOpenFile3;
    if (clsDrill.varDrillRunSettings.RecentOpenFile3 != clsDrill.varDrillRunSettings.RecentOpenFile2)
      clsDrill.varDrillRunSettings.RecentOpenFile3 = clsDrill.varDrillRunSettings.RecentOpenFile2;
    if (clsDrill.varDrillRunSettings.RecentOpenFile2 != clsDrill.varDrillRunSettings.RecentOpenFile1)
      clsDrill.varDrillRunSettings.RecentOpenFile2 = clsDrill.varDrillRunSettings.RecentOpenFile1;
    if (!(FileName != clsDrill.varDrillRunSettings.RecentOpenFile1))
      return;
    clsDrill.varDrillRunSettings.RecentOpenFile1 = FileName;
  }

  public void AddRecentSaveFile(string FileName)
  {
    if (!(FileName != clsDrill.varDrillRunSettings.RecentSaveFile1))
      return;
    if (clsDrill.varDrillRunSettings.RecentSaveFile6 != clsDrill.varDrillRunSettings.RecentSaveFile5)
      clsDrill.varDrillRunSettings.RecentSaveFile6 = clsDrill.varDrillRunSettings.RecentSaveFile5;
    if (clsDrill.varDrillRunSettings.RecentSaveFile5 != clsDrill.varDrillRunSettings.RecentSaveFile4)
      clsDrill.varDrillRunSettings.RecentSaveFile5 = clsDrill.varDrillRunSettings.RecentSaveFile4;
    if (clsDrill.varDrillRunSettings.RecentSaveFile4 != clsDrill.varDrillRunSettings.RecentSaveFile3)
      clsDrill.varDrillRunSettings.RecentSaveFile4 = clsDrill.varDrillRunSettings.RecentSaveFile3;
    if (clsDrill.varDrillRunSettings.RecentSaveFile3 != clsDrill.varDrillRunSettings.RecentSaveFile2)
      clsDrill.varDrillRunSettings.RecentSaveFile3 = clsDrill.varDrillRunSettings.RecentSaveFile2;
    if (clsDrill.varDrillRunSettings.RecentSaveFile2 != clsDrill.varDrillRunSettings.RecentSaveFile1)
      clsDrill.varDrillRunSettings.RecentSaveFile2 = clsDrill.varDrillRunSettings.RecentSaveFile1;
    if (!(clsDrill.varDrillRunSettings.RecentSaveFile1 != FileName))
      return;
    clsDrill.varDrillRunSettings.RecentSaveFile1 = FileName;
  }

  public void SaveDrillJobFile(string FileName, DrillJob Job, bool SaveAll = false)
  {
    List<string> stringList = new List<string>();
    this.SaveDrillJobFile(ref stringList, Job, SaveAll);
    buFile5.SaveToFile(stringList, FileName);
    this.fileNameActual = FileName;
    this.AddRecentSaveFile(FileName);
    ccVars.Pages[ccVars.PageIndex].Form.Text = buFile5.getFileName(FileName);
  }

  public void SaveDrillJobFile(ref List<string> stringList, DrillJob Job, bool SaveAll = false)
  {
    try
    {
      stringList = new List<string>();
      List<string> collection = new List<string>();
      stringList.Add("<JobCsv>");
      stringList.Add("  <Material>");
      stringList.Add("    Name;" + Job.Name);
      stringList.Add("    Width;" + Job.Material.Size.Height.ToString());
      stringList.Add("    Length;" + Job.Material.Size.Width.ToString());
      stringList.Add("    Height;" + Job.Material.Size.Depth.ToString());
      stringList.Add("  </Material>");
      for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
      {
        if (Job.Items[index1].Tool == null)
          Job.Items[index1].Tool = new ToolBase5(ccVars.toolActive);
        stringList.Add("  <DrillGroup>");
        if (Job.Items[index1].ShapeGroup == ShapeGroup.Drill)
        {
          if (Job.Items[index1].GetType() == typeof (buShapeHole))
          {
            buShapeHole buShapeHole = Job.Items[index1] as buShapeHole;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeHole.DrillType.ToString()}");
            string str1 = $"{$"{$"    {buShapeHole.BasePoint.X.ToString("f3")};{buShapeHole.BasePoint.Y.ToString("f3")};{buShapeHole.BasePoint.Z.ToString("f3")};"}{buShapeHole.Depth.ToString("f3")};{buShapeHole.Diameter.ToString("f3")};{buShapeHole.planeName.ToString()};{Convert.ToInt32(buShapeHole.Enable).ToString()};{Convert.ToInt32(buShapeHole.isMilling).ToString()};"}{buShapeHole.Corner.ToString()};{buShapeHole.Alignment.ToString()};{buShapeHole.Tool.Data.Name.ToString()};";
            stringList.Add(str1);
            collection.Add("  <DrillGroup>");
            string str2 = $"{$"{$"    {(buShapeHole.CalculatedPoint.X * -1.0).ToString("f3")};{(buShapeHole.CalculatedPoint.Y * -1.0).ToString("f3")};{buShapeHole.CalculatedPoint.Z.ToString("f3")};"}{buShapeHole.Depth.ToString("f3")};{buShapeHole.Diameter.ToString("f3")};{buShapeHole.planeName.ToString()};{Convert.ToInt32(buShapeHole.Enable).ToString()};{Convert.ToInt32(buShapeHole.isMilling).ToString()};"}{buShapeHole.Corner.ToString()};{buShapeHole.Alignment.ToString()};{buShapeHole.Tool.Data.Name.ToString()};";
            collection.Add(str2);
            collection.Add("  </DrillGroup>");
          }
          if (Job.Items[index1].GetType() == typeof (buShapeHoleMulti))
          {
            buShapeHoleMulti buShapeHoleMulti = Job.Items[index1] as buShapeHoleMulti;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeHoleMulti.DrillType.ToString()}");
            string str3 = $"{$"{$"{$"    {buShapeHoleMulti.BasePoint.X.ToString("f3")};{buShapeHoleMulti.BasePoint.Y.ToString("f3")};{buShapeHoleMulti.BasePoint.Z.ToString("f3")};"}{buShapeHoleMulti.Depth.ToString("f3")};{buShapeHoleMulti.Diameter.ToString("f3")};{buShapeHoleMulti.planeName.ToString()};{Convert.ToInt32(buShapeHoleMulti.Enable).ToString()};{Convert.ToInt32(buShapeHoleMulti.isMilling).ToString()};"}{buShapeHoleMulti.Count.ToString()};{buShapeHoleMulti.Distance.ToString("f3")};{buShapeHoleMulti.StartDistance.ToString()};{buShapeHoleMulti.EndDistance.ToString()};{buShapeHoleMulti.Angle.ToString()};"}{buShapeHoleMulti.Corner.ToString()};{buShapeHoleMulti.Alignment.ToString()};{buShapeHoleMulti.Tool.Data.Name.ToString()};";
            stringList.Add(str3);
            for (int index2 = 0; index2 <= buShapeHoleMulti.multiCenter.Count - 1; ++index2)
            {
              string str4 = $"{$"{$"{$"    {(buShapeHoleMulti.multiCenter[index2].Center.X * -1.0).ToString("f3")};{(buShapeHoleMulti.multiCenter[index2].Center.Y * -1.0).ToString("f3")};{buShapeHoleMulti.multiCenter[index2].Center.Z.ToString("f3")};"}{buShapeHoleMulti.Depth.ToString("f3")};{buShapeHoleMulti.Diameter.ToString("f3")};{buShapeHoleMulti.planeName.ToString()};{Convert.ToInt32(buShapeHoleMulti.Enable).ToString()};{Convert.ToInt32(buShapeHoleMulti.isMilling).ToString()};"}{buShapeHoleMulti.Count.ToString()};{buShapeHoleMulti.Distance.ToString("f3")};{buShapeHoleMulti.StartDistance.ToString()};{buShapeHoleMulti.EndDistance.ToString()};{buShapeHoleMulti.Angle.ToString()};"}{buShapeHoleMulti.Corner.ToString()};{buShapeHoleMulti.Alignment.ToString()};{buShapeHoleMulti.Tool.Data.Name.ToString()};";
              collection.Add("  <DrillGroup>");
              collection.Add("  " + str4);
              collection.Add("  </DrillGroup>");
            }
          }
          if (Job.Items[index1].GetType() == typeof (buShapeHole3))
          {
            buShapeHole3 buShapeHole3 = Job.Items[index1] as buShapeHole3;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeHole3.DrillType.ToString()}");
            string str = $"{$"{$"{$"    {buShapeHole3.BasePoint.X.ToString("f3")};{buShapeHole3.BasePoint.Y.ToString("f3")};{buShapeHole3.BasePoint.Z.ToString("f3")};"}{buShapeHole3.Depth.ToString("f3")};{buShapeHole3.Diameter.ToString("f3")};{buShapeHole3.planeName.ToString()};{Convert.ToInt32(buShapeHole3.Enable).ToString()};{Convert.ToInt32(buShapeHole3.isMilling).ToString()};"}{buShapeHole3.DiameterOutside.ToString("f3")};{buShapeHole3.Hole3Angle.ToString("f3")};{buShapeHole3.DistanceX.ToString()};{buShapeHole3.DistanceY.ToString()};"}{buShapeHole3.Corner.ToString()};{buShapeHole3.Alignment.ToString()};{buShapeHole3.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
        }
        if (Job.Items[index1].ShapeGroup == ShapeGroup.Cut && Job.Items[index1].GetType() == typeof (buShapeCut))
        {
          buShapeCut buShapeCut = Job.Items[index1] as buShapeCut;
          stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeCut.CutType.ToString()}");
          string str5 = $"{$"{$"{$"    {buShapeCut.BasePoint.X.ToString("f3")};{buShapeCut.BasePoint.Y.ToString("f3")};{buShapeCut.BasePoint.Z.ToString("f3")};"}{buShapeCut.Depth.ToString("f3")};{buShapeCut.Diameter.ToString("f3")};{buShapeCut.planeName.ToString()};{Convert.ToInt32(buShapeCut.Enable).ToString()};{Convert.ToInt32(buShapeCut.isMilling).ToString()};"}{buShapeCut.Length.ToString("f3")};{buShapeCut.Angle.ToString("f3")};{buShapeCut.StartDistance.ToString()};{buShapeCut.EndDistance.ToString()};"}{buShapeCut.Corner.ToString()};{buShapeCut.Alignment.ToString()};{buShapeCut.Tool.Data.Name.ToString()};";
          stringList.Add(str5);
          collection.Add("  <SlotGroup>");
          string[] strArray = new string[11]
          {
            $"    {(buShapeCut.CalculatedPoint.X * -1.0).ToString("f3")};{(buShapeCut.CalculatedPoint.Y * -1.0).ToString("f3")};{buShapeCut.CalculatedPoint.Z.ToString("f3")};",
            buShapeCut.Depth.ToString("f3"),
            ";",
            buShapeCut.Diameter.ToString("f3"),
            ";",
            buShapeCut.planeName.ToString(),
            ";",
            null,
            null,
            null,
            null
          };
          int int32 = Convert.ToInt32(buShapeCut.Enable);
          strArray[7] = int32.ToString();
          strArray[8] = ";";
          int32 = Convert.ToInt32(buShapeCut.isMilling);
          strArray[9] = int32.ToString();
          strArray[10] = ";";
          string str6 = $"{$"{string.Concat(strArray)}{buShapeCut.Length.ToString("f3")};{buShapeCut.Angle.ToString("f3")};{buShapeCut.StartDistance.ToString()};{buShapeCut.EndDistance.ToString()};"}{buShapeCut.Corner.ToString()};{buShapeCut.Alignment.ToString()};{buShapeCut.Tool.Data.Name.ToString()};";
          collection.Add(str6);
          collection.Add("  </SlotGroup>");
        }
        if (Job.Items[index1].ShapeGroup == ShapeGroup.Profiling && Job.Items[index1].GetType() == typeof (buShapeProfiling))
        {
          buShapeProfiling buShapeProfiling = Job.Items[index1] as buShapeProfiling;
          stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeProfiling.ProfilingType.ToString()}");
          string str = $"{$"{$"{$"    {buShapeProfiling.BasePoint.X.ToString("f3")};{buShapeProfiling.BasePoint.Y.ToString("f3")};{buShapeProfiling.BasePoint.Z.ToString("f3")};"}{buShapeProfiling.Depth.ToString("f3")};{buShapeProfiling.Radius.ToString("f3")};{buShapeProfiling.planeName.ToString()};{Convert.ToInt32(buShapeProfiling.Enable).ToString()};{Convert.ToInt32(buShapeProfiling.isPocket).ToString()};"}{buShapeProfiling.Length.ToString("f3")};{buShapeProfiling.Width.ToString("f3")};{buShapeProfiling.Height.ToString()};"}{buShapeProfiling.Corner.ToString()};{buShapeProfiling.Alignment.ToString()};{buShapeProfiling.Tool.Data.Name.ToString()};";
          stringList.Add(str);
        }
        if (Job.Items[index1].ShapeGroup == ShapeGroup.Shape && Job.Items[index1].ShapeGroup == ShapeGroup.Shape)
        {
          if (Job.Items[index1].GetType() == typeof (buShapeRectangle))
          {
            buShapeRectangle buShapeRectangle = Job.Items[index1] as buShapeRectangle;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeRectangle.ShapeType.ToString()}");
            string str = $"{$"{$"{$"    {buShapeRectangle.BasePoint.X.ToString("f3")};{buShapeRectangle.BasePoint.Y.ToString("f3")};{buShapeRectangle.BasePoint.Z.ToString("f3")};"}{buShapeRectangle.Depth.ToString("f3")};{buShapeRectangle.Radius.ToString("f3")};{buShapeRectangle.planeName.ToString()};{Convert.ToInt32(buShapeRectangle.Enable).ToString()};{Convert.ToInt32(buShapeRectangle.isPocket).ToString()};"}{buShapeRectangle.Angle.ToString("f3")};{buShapeRectangle.Width.ToString("f3")};{buShapeRectangle.Height.ToString()};{buShapeRectangle.Chamfer.ToString("f3")};"}{buShapeRectangle.Corner.ToString()};{buShapeRectangle.Alignment.ToString()};{buShapeRectangle.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
          if (Job.Items[index1].GetType() == typeof (buShapeCircle))
          {
            buShapeCircle buShapeCircle = Job.Items[index1] as buShapeCircle;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeCircle.ShapeType.ToString()}");
            string str = $"{$"{$"    {buShapeCircle.BasePoint.X.ToString("f3")};{buShapeCircle.BasePoint.Y.ToString("f3")};{buShapeCircle.BasePoint.Z.ToString("f3")};"}{buShapeCircle.Depth.ToString("f3")};{buShapeCircle.Radius.ToString("f3")};{buShapeCircle.planeName.ToString()};{Convert.ToInt32(buShapeCircle.Enable).ToString()};{Convert.ToInt32(buShapeCircle.isPocket).ToString()};"}{buShapeCircle.Corner.ToString()};{buShapeCircle.Alignment.ToString()};{buShapeCircle.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
          if (Job.Items[index1].GetType() == typeof (buShapeEllipse))
          {
            buShapeEllipse buShapeEllipse = Job.Items[index1] as buShapeEllipse;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeEllipse.ShapeType.ToString()}");
            string str = $"{$"{$"{$"    {buShapeEllipse.BasePoint.X.ToString("f3")};{buShapeEllipse.BasePoint.Y.ToString("f3")};{buShapeEllipse.BasePoint.Z.ToString("f3")};"}{buShapeEllipse.Depth.ToString("f3")};{buShapeEllipse.RadiusX.ToString("f3")};{buShapeEllipse.planeName.ToString()};{Convert.ToInt32(buShapeEllipse.Enable).ToString()};{Convert.ToInt32(buShapeEllipse.isPocket).ToString()};"}{buShapeEllipse.Angle.ToString("f3")};{buShapeEllipse.RadiusY.ToString("f3")};"}{buShapeEllipse.Corner.ToString()};{buShapeEllipse.Alignment.ToString()};{buShapeEllipse.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
          if (Job.Items[index1].GetType() == typeof (buShapeSlot))
          {
            buShapeSlot buShapeSlot = Job.Items[index1] as buShapeSlot;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeSlot.ShapeType.ToString()}");
            string str = $"{$"{$"{$"    {buShapeSlot.BasePoint.X.ToString("f3")};{buShapeSlot.BasePoint.Y.ToString("f3")};{buShapeSlot.BasePoint.Z.ToString("f3")};"}{buShapeSlot.Depth.ToString("f3")};{buShapeSlot.Diameter.ToString("f3")};{buShapeSlot.planeName.ToString()};{Convert.ToInt32(buShapeSlot.Enable).ToString()};{Convert.ToInt32(buShapeSlot.isPocket).ToString()};"}{buShapeSlot.Angle.ToString("f3")};{buShapeSlot.Length.ToString("f3")};"}{buShapeSlot.Corner.ToString()};{buShapeSlot.Alignment.ToString()};{buShapeSlot.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
          if (Job.Items[index1].GetType() == typeof (buShapeKeyHole))
          {
            buShapeKeyHole buShapeKeyHole = Job.Items[index1] as buShapeKeyHole;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeKeyHole.ShapeType.ToString()}");
            string str = $"{$"{$"{$"    {buShapeKeyHole.BasePoint.X.ToString("f3")};{buShapeKeyHole.BasePoint.Y.ToString("f3")};{buShapeKeyHole.BasePoint.Z.ToString("f3")};"}{buShapeKeyHole.Depth.ToString("f3")};{buShapeKeyHole.Diameter.ToString("f3")};{buShapeKeyHole.planeName.ToString()};{Convert.ToInt32(buShapeKeyHole.Enable).ToString()};{Convert.ToInt32(buShapeKeyHole.isPocket).ToString()};"}{buShapeKeyHole.Angle.ToString("f3")};{buShapeKeyHole.HeadDiameter.ToString("f3")};{buShapeKeyHole.Length.ToString("f3")};"}{buShapeKeyHole.Corner.ToString()};{buShapeKeyHole.Alignment.ToString()};{buShapeKeyHole.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
          if (Job.Items[index1].GetType() == typeof (buShapePolygon))
          {
            buShapePolygon buShapePolygon = Job.Items[index1] as buShapePolygon;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapePolygon.ShapeType.ToString()}");
            string str = $"{$"{$"{$"    {buShapePolygon.BasePoint.X.ToString("f3")};{buShapePolygon.BasePoint.Y.ToString("f3")};{buShapePolygon.BasePoint.Z.ToString("f3")};"}{buShapePolygon.Depth.ToString("f3")};{buShapePolygon.Radius.ToString("f3")};{buShapePolygon.planeName.ToString()};{Convert.ToInt32(buShapePolygon.Enable).ToString()};{Convert.ToInt32(buShapePolygon.isPocket).ToString()};"}{buShapePolygon.Angle.ToString("f3")};{buShapePolygon.Side.ToString()};"}{buShapePolygon.Corner.ToString()};{buShapePolygon.Alignment.ToString()};{buShapePolygon.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
          if (Job.Items[index1].GetType() == typeof (buShapeFreeDraw))
          {
            buShapeFreeDraw buShapeFreeDraw = Job.Items[index1] as buShapeFreeDraw;
            stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeFreeDraw.ShapeType.ToString()}");
            string str = $"{$"{$"{$"    {buShapeFreeDraw.BasePoint.X.ToString("f3")};{buShapeFreeDraw.BasePoint.Y.ToString("f3")};{buShapeFreeDraw.BasePoint.Z.ToString("f3")};"}{buShapeFreeDraw.Depth.ToString("f3")};{buShapeFreeDraw.Width.ToString("f3")};{buShapeFreeDraw.planeName.ToString()};{Convert.ToInt32(buShapeFreeDraw.Enable).ToString()};{Convert.ToInt32(buShapeFreeDraw.isPocket).ToString()};"}{buShapeFreeDraw.Angle.ToString("f3")};{buShapeFreeDraw.Height.ToString("f3")};"}{buShapeFreeDraw.Corner.ToString()};{buShapeFreeDraw.Alignment.ToString()};{buShapeFreeDraw.Tool.Data.Name.ToString()};";
            stringList.Add(str);
          }
        }
        if (Job.Items[index1].ShapeGroup == ShapeGroup.Junction && Job.Items[index1].GetType() == typeof (buShapeJunction))
        {
          buShapeJunction buShapeJunction = Job.Items[index1] as buShapeJunction;
          stringList.Add($"    {Job.Items[index1].ShapeGroup.ToString()} ; {buShapeJunction.JunctionType.ToString()}");
          string str = $"{$"{$"{$"    {buShapeJunction.BasePoint.X.ToString("f3")};{buShapeJunction.BasePoint.Y.ToString("f3")};{buShapeJunction.BasePoint.Z.ToString("f3")};"}{buShapeJunction.Depth.ToString("f3")};{buShapeJunction.Diameter.ToString("f3")};{buShapeJunction.planeName.ToString()};{Convert.ToInt32(buShapeJunction.Enable).ToString()};{Convert.ToInt32(buShapeJunction.isMilling).ToString()};"}{buShapeJunction.DiameterOutside.ToString("f3")};{buShapeJunction.Distance.ToString("f3")};"}{buShapeJunction.Corner.ToString()};{buShapeJunction.Alignment.ToString()};{buShapeJunction.Tool.Data.Name.ToString()};";
          stringList.Add(str);
        }
        stringList.Add("  </DrillGroup>");
      }
      stringList.Add("</JobCsv>");
      stringList.Add(" ");
      stringList.Add("<ItemCode>");
      stringList.AddRange((IEnumerable<string>) collection);
      stringList.Add("</ItemCode>");
      stringList.Add(" ");
      clsDrill.activeJob.Cams.Clear();
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
        this.cGoUltra2Up1Down.CreatCodeFromJobItem(ref clsDrill.activeJob);
      if (this.MachType == DrillMachineType.GoWithAtc)
        this.cGoAtc.CreatCodeFromJobItem(ref clsDrill.activeJob);
      if (this.MachType == DrillMachineType.Sirius)
        this.cGoSirius.CreatCodeFromJobItem(ref clsDrill.activeJob);
      stringList.Add("<MachineCode>");
      stringList.Add("  <Props>");
      stringList.Add("    Width = " + clsDrill.activeJob.Material.Size.Width.ToString("f3"));
      stringList.Add("    Height = " + clsDrill.activeJob.Material.Size.Height.ToString("f3"));
      stringList.Add("    Depth = " + clsDrill.activeJob.Material.Size.Depth.ToString("f3"));
      stringList.Add("  </Props>");
      stringList.Add("  <AutoCode>");
      for (int index = 0; index <= clsDrill.activeJob.Codes.Count - 1; ++index)
        stringList.Add("    " + clsDrill.activeJob.Codes[index]);
      stringList.Add("  </AutoCode>");
      if (clsDrill.activeJob.Cams.Count > 0)
      {
        for (int index3 = 0; index3 <= clsDrill.activeJob.Cams.Count - 1; ++index3)
        {
          string Lines1 = "";
          List<camTp> Cams = new List<camTp>();
          camTp copiedCam = new camTp();
          camTp.CopyCam(clsDrill.activeJob.Cams[index3], ref copiedCam);
          Cams.Add(copiedCam);
          clsInit.cGcodeCreate.CreatGCode(Cams, ccVars.PostActive, ref Lines1);
          ArrayList Lines2 = new ArrayList();
          buString5.StringToArrayListByNewLine(Lines1, ref Lines2);
          if (clsItem.FrmProgress != null)
            clsItem.FrmProgress.Visible = false;
          stringList.Add("  <GCodes>");
          for (int index4 = 0; index4 <= Lines2.Count - 1; ++index4)
          {
            if (Lines2[index4].ToString().Trim().Length > 0)
              stringList.Add("    " + Lines2[index4].ToString());
          }
          stringList.Add("  </GCodes>");
        }
      }
      if (clsDrill.activeJob.Moves.Count > 0)
      {
        stringList.Add("  <Moves>");
        for (int index = 0; index <= clsDrill.activeJob.Moves.Count - 1; ++index)
        {
          string str = $"    {clsDrill.activeJob.Moves[index].XPosition.ToString()};{clsDrill.activeJob.Moves[index].X1Clamper.ToString()};{clsDrill.activeJob.Moves[index].X2Clamper.ToString()};{clsDrill.activeJob.Moves[index].Y1Position.ToString()};{clsDrill.activeJob.Moves[index].Y2Position.ToString()};{clsDrill.activeJob.Moves[index].Y3Position.ToString()};{clsDrill.activeJob.Moves[index].Z1Position.ToString()};{clsDrill.activeJob.Moves[index].Z2Position.ToString()};{clsDrill.activeJob.Moves[index].Z3Position.ToString()};{Convert.ToInt32((object) clsDrill.activeJob.Moves[index].Command).ToString()};{clsDrill.activeJob.Moves[index].Tool1.ToString()};{clsDrill.activeJob.Moves[index].Tool2.ToString()};{clsDrill.activeJob.Moves[index].Tool3.ToString()};{clsDrill.activeJob.Moves[index].Tool4.ToString()};{clsDrill.activeJob.Moves[index].Tool5.ToString()};{clsDrill.activeJob.Moves[index].Tool6.ToString()};{clsDrill.activeJob.Moves[index].Tool7.ToString()};{clsDrill.activeJob.Moves[index].Tool8.ToString()};{clsDrill.activeJob.Moves[index].Tool9.ToString()};{clsDrill.activeJob.Moves[index].Tool10.ToString()};{clsDrill.activeJob.Moves[index].Tool11.ToString()};{clsDrill.activeJob.Moves[index].Tool12.ToString()};{Convert.ToInt32((object) clsDrill.activeJob.Moves[index].Mode).ToString()};{Convert.ToInt32((object) clsDrill.activeJob.Moves[index].Plane).ToString()};{Convert.ToInt32((object) clsDrill.activeJob.Moves[index].Command2).ToString()};{Convert.ToInt32((object) clsDrill.activeJob.Moves[index].Command3).ToString()}";
          stringList.Add(str);
        }
        stringList.Add("  </Moves>");
        stringList.Add("  <MovesDetailed>");
        for (int index = 0; index <= clsDrill.activeJob.Moves.Count - 1; ++index)
        {
          string str = $"    X: {clsDrill.activeJob.Moves[index].XPosition.ToString()} ; X1: {clsDrill.activeJob.Moves[index].X1Clamper.ToString()} ; X2: {clsDrill.activeJob.Moves[index].X2Clamper.ToString()} ; Y1: {clsDrill.activeJob.Moves[index].Y1Position.ToString()} ; Y2: {clsDrill.activeJob.Moves[index].Y2Position.ToString()} ; Y2: {clsDrill.activeJob.Moves[index].Y3Position.ToString()} ; Z1: {clsDrill.activeJob.Moves[index].Z1Position.ToString()} ; Z2: {clsDrill.activeJob.Moves[index].Z2Position.ToString()} ; Z3: {clsDrill.activeJob.Moves[index].Z3Position.ToString()} ; {clsDrill.activeJob.Moves[index].Command.ToString()} ; T1: {clsDrill.activeJob.Moves[index].Tool1.ToString()} ; T2: {clsDrill.activeJob.Moves[index].Tool2.ToString()} ; T3: {clsDrill.activeJob.Moves[index].Tool3.ToString()} ; T4: {clsDrill.activeJob.Moves[index].Tool4.ToString()} ; T5: {clsDrill.activeJob.Moves[index].Tool5.ToString()} ; T6: {clsDrill.activeJob.Moves[index].Tool6.ToString()} ; T7: {clsDrill.activeJob.Moves[index].Tool7.ToString()} ; T8: {clsDrill.activeJob.Moves[index].Tool8.ToString()} ; T9: {clsDrill.activeJob.Moves[index].Tool9.ToString()} ; T10: {clsDrill.activeJob.Moves[index].Tool10.ToString()} ; T11: {clsDrill.activeJob.Moves[index].Tool11.ToString()} ; T12: {clsDrill.activeJob.Moves[index].Tool12.ToString()} ; Mode: {clsDrill.activeJob.Moves[index].Mode.ToString()} ; {clsDrill.activeJob.Moves[index].Plane.ToString()};{clsDrill.activeJob.Moves[index].Command2.ToString()};{clsDrill.activeJob.Moves[index].Command3.ToString()}";
          stringList.Add(str);
        }
        stringList.Add("  </MovesDetailed>");
      }
      if (clsDrill.activeJob.ErrorCodes.Count > 0)
      {
        stringList.Add("  <ErrorCodes>");
        for (int index = 0; index <= clsDrill.activeJob.ErrorCodes.Count - 1; ++index)
          stringList.Add("    " + clsDrill.activeJob.ErrorCodes[index]);
        stringList.Add("  </ErrorCodes>");
      }
      stringList.Add("</MachineCode>");
      if (!SaveAll)
        return;
      stringList.Add("<ToolConfiguration>");
      List<string> SL = new List<string>();
      clsInit.cDrill.ToolToStringList(clsDrill.ToolList, ref SL);
      stringList.AddRange((IEnumerable<string>) SL);
      stringList.Add("</ToolConfiguration>");
      ArrayList ALSettings = new ArrayList();
      ArrayList ALCam = new ArrayList();
      this.SaveDrillFile(ref ALSettings, ref ALCam);
      ALSettings.Insert(0, (object) "<SettingConfiguration>");
      ALSettings.Add((object) "</SettingConfiguration>");
      ALCam.Insert(0, (object) "<CamConfiguration>");
      ALCam.Add((object) "</CamConfiguration>");
      for (int index = 0; index <= ALSettings.Count - 1; ++index)
        stringList.Add(ALSettings[index].ToString());
      for (int index = 0; index <= ALCam.Count - 1; ++index)
        stringList.Add(ALCam[index].ToString());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void OpenDrillJobFile(List<string> Lines, ref DrillJob Job, bool OpenAll = false, bool Preview = false)
  {
    List<string> CalcList1 = new List<string>();
    List<string> CalcList2 = new List<string>();
    if (Lines.Count > 0)
    {
      Job = new DrillJob();
      List<List<string>> CalcList3 = new List<List<string>>();
      buString5.ListToSpecificList("<JobCsv>", "</JobCsv>", false, Lines, ref CalcList1);
      buString5.ListToSpecificList("<DrillGroup>", "</DrillGroup>", false, CalcList1, ref CalcList3);
      buString5.ListToSpecificList("<Material>", "</Material>", false, CalcList1, ref CalcList2);
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        string[] strArray = CalcList2[index].Split(';');
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
      if (Job.Material.Entities.Count == 0)
      {
        Entity entity = (Entity) null;
        clsInit.cVector5.CreateMaterialEntities(Job.Material, ref entity);
        clsInit.cVector5.Move(-Job.Material.Size.Width, -Job.Material.Size.Height, 0.0, ref entity);
        Job.Material.Entities.Add(entity);
        Job.panelEntity = entity;
      }
      double MaterialZeroYPos = 0.0;
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
        this.cGoUltra2Up1Down.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
      if (this.MachType == DrillMachineType.GoWithAtc)
        this.cGoAtc.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
      if (this.MachType == DrillMachineType.Sirius)
        this.cGoSirius.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
      if (this.ClamperEntity != null)
        clsInit.cDrill.CreateClamperEntities((Entity) this.ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
      for (int index = 0; index <= CalcList3.Count - 1; ++index)
      {
        DrillItemBase drillItemBase = new DrillItemBase();
        buShape buShape = new buShape();
        List<DrillItem> drillItemList = new List<DrillItem>();
        if (CalcList3[index].Count == 2)
        {
          string[] strArray1 = CalcList3[index][0].Split(';');
          if (strArray1.Length == 2)
          {
            if (strArray1[0].Trim() == ShapeGroup.Drill.ToString())
            {
              string str1 = strArray1[1].Trim();
              drillTypes drillTypes1 = drillTypes.SingleHole;
              string str2 = drillTypes1.ToString();
              if (str1 == str2)
              {
                string[] strArray2 = CalcList3[index][1].Split(';');
                if (strArray2.Length != 0)
                {
                  buShapeHole buShapeHole = new buShapeHole();
                  buShapeHole.DrillType = drillTypes.SingleHole;
                  buShapeHole.BasePoint.X = double.Parse(strArray2[0]);
                  buShapeHole.BasePoint.Y = double.Parse(strArray2[1]);
                  buShapeHole.BasePoint.Z = double.Parse(strArray2[2]);
                  buShapeHole.Depth = double.Parse(strArray2[3]);
                  buShapeHole.Diameter = double.Parse(strArray2[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray2[5].Trim(), true);
                  buShapeHole.planeName = planeBoxNames;
                  buShapeHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole.planeName);
                  buShapeHole.Enable = buConversion5.StringToBool(strArray2[6]);
                  buShapeHole.isMilling = buConversion5.StringToBool(strArray2[7]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray2[8].Trim(), true);
                  buShapeHole.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray2[9].Trim(), true);
                  buShapeHole.Alignment = objectAlignment;
                  if (strArray2.Length >= 10 & buShapeHole.isMilling && strArray2.Length >= 10)
                  {
                    string sTool = strArray2[strArray2.Length - 1].Trim();
                    if (sTool.Length == 0)
                      sTool = strArray2[strArray2.Length - 2].Trim();
                    buShape S = (buShape) buShapeHole;
                    clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, sTool, ref S);
                  }
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeHole;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                }
              }
              string str3 = strArray1[1].Trim();
              drillTypes1 = drillTypes.HorizontalHoles;
              string str4 = drillTypes1.ToString();
              int num1 = str3 == str4 ? 1 : 0;
              string str5 = strArray1[1].Trim();
              drillTypes1 = drillTypes.VerticalHoles;
              string str6 = drillTypes1.ToString();
              int num2 = str5 == str6 ? 1 : 0;
              int num3 = num1 | num2;
              string str7 = strArray1[1].Trim();
              drillTypes1 = drillTypes.HorizontalLineHoles;
              string str8 = drillTypes1.ToString();
              int num4 = str7 == str8 ? 1 : 0;
              int num5 = num3 | num4;
              string str9 = strArray1[1].Trim();
              drillTypes1 = drillTypes.VerticalLineHoles;
              string str10 = drillTypes1.ToString();
              int num6 = str9 == str10 ? 1 : 0;
              int num7 = num5 | num6;
              string str11 = strArray1[1].Trim();
              drillTypes1 = drillTypes.InclineHoles;
              string str12 = drillTypes1.ToString();
              int num8 = str11 == str12 ? 1 : 0;
              if ((num7 | num8) != 0)
              {
                drillTypes drillTypes2 = drillTypes.HorizontalHoles;
                string str13 = strArray1[1].Trim();
                drillTypes1 = drillTypes.HorizontalHoles;
                string str14 = drillTypes1.ToString();
                if (str13 == str14)
                  drillTypes2 = drillTypes.HorizontalHoles;
                string str15 = strArray1[1].Trim();
                drillTypes1 = drillTypes.HorizontalLineHoles;
                string str16 = drillTypes1.ToString();
                if (str15 == str16)
                  drillTypes2 = drillTypes.HorizontalLineHoles;
                string str17 = strArray1[1].Trim();
                drillTypes1 = drillTypes.VerticalHoles;
                string str18 = drillTypes1.ToString();
                if (str17 == str18)
                  drillTypes2 = drillTypes.VerticalHoles;
                string str19 = strArray1[1].Trim();
                drillTypes1 = drillTypes.VerticalLineHoles;
                string str20 = drillTypes1.ToString();
                if (str19 == str20)
                  drillTypes2 = drillTypes.VerticalLineHoles;
                string str21 = strArray1[1].Trim();
                drillTypes1 = drillTypes.InclineHoles;
                string str22 = drillTypes1.ToString();
                if (str21 == str22)
                  drillTypes2 = drillTypes.InclineHoles;
                string[] strArray3 = CalcList3[index][1].Split(';');
                if (strArray3.Length != 0)
                {
                  buShapeHoleMulti buShapeHoleMulti = new buShapeHoleMulti();
                  buShapeHoleMulti.DrillType = drillTypes2;
                  buShapeHoleMulti.BasePoint.X = double.Parse(strArray3[0]);
                  buShapeHoleMulti.BasePoint.Y = double.Parse(strArray3[1]);
                  buShapeHoleMulti.BasePoint.Z = double.Parse(strArray3[2]);
                  buShapeHoleMulti.Depth = double.Parse(strArray3[3]);
                  buShapeHoleMulti.Diameter = double.Parse(strArray3[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray3[5].Trim(), true);
                  buShapeHoleMulti.planeName = planeBoxNames;
                  buShapeHoleMulti.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHoleMulti.planeName);
                  buShapeHoleMulti.Enable = buConversion5.StringToBool(strArray3[6]);
                  buShapeHoleMulti.isMilling = buConversion5.StringToBool(strArray3[7]);
                  buShapeHoleMulti.Count = int.Parse(strArray3[8]);
                  buShapeHoleMulti.Distance = double.Parse(strArray3[9]);
                  buShapeHoleMulti.StartDistance = double.Parse(strArray3[10]);
                  buShapeHoleMulti.EndDistance = double.Parse(strArray3[11]);
                  buShapeHoleMulti.Angle = double.Parse(strArray3[12]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray3[13].Trim(), true);
                  buShapeHoleMulti.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray3[14].Trim(), true);
                  buShapeHoleMulti.Alignment = objectAlignment;
                  if (strArray3.Length >= 10 & buShapeHoleMulti.isMilling && strArray3.Length >= 10)
                  {
                    string sTool = strArray3[strArray3.Length - 1].Trim();
                    if (sTool.Length == 0)
                      sTool = strArray3[strArray3.Length - 2].Trim();
                    buShape S = (buShape) buShapeHoleMulti;
                    clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, sTool, ref S);
                  }
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeHoleMulti;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                }
              }
              string str23 = strArray1[1].Trim();
              drillTypes1 = drillTypes.ThreeHole;
              string str24 = drillTypes1.ToString();
              if (str23 == str24)
              {
                string[] strArray4 = CalcList3[index][1].Split(';');
                if (strArray4.Length != 0)
                {
                  buShapeHole3 buShapeHole3 = new buShapeHole3();
                  buShapeHole3.DrillType = drillTypes.ThreeHole;
                  buShapeHole3.BasePoint.X = double.Parse(strArray4[0]);
                  buShapeHole3.BasePoint.Y = double.Parse(strArray4[1]);
                  buShapeHole3.BasePoint.Z = double.Parse(strArray4[2]);
                  buShapeHole3.Depth = double.Parse(strArray4[3]);
                  buShapeHole3.Diameter = double.Parse(strArray4[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray4[5].Trim(), true);
                  buShapeHole3.planeName = planeBoxNames;
                  buShapeHole3.Enable = buConversion5.StringToBool(strArray4[6]);
                  buShapeHole3.isMilling = buConversion5.StringToBool(strArray4[7]);
                  buShapeHole3.DiameterOutside = double.Parse(strArray4[8]);
                  buShapeHole3.Hole3Angle = double.Parse(strArray4[9]);
                  buShapeHole3.DistanceX = double.Parse(strArray4[10]);
                  buShapeHole3.DistanceY = double.Parse(strArray4[11]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray4[12].Trim(), true);
                  buShapeHole3.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray4[13].Trim(), true);
                  buShapeHole3.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeHole3;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                }
              }
            }
            if (strArray1[0].Trim() == ShapeGroup.Cut.ToString())
            {
              string[] strArray5 = CalcList3[index][1].Split(';');
              if (strArray5.Length != 0)
              {
                buShapeCut buShapeCut = new buShapeCut();
                buShapeCut.CutType = (CutTypes) Enum.Parse(typeof (CutTypes), strArray1[1].Trim(), true);
                buShapeCut.BasePoint.X = double.Parse(strArray5[0]);
                buShapeCut.BasePoint.Y = double.Parse(strArray5[1]);
                buShapeCut.BasePoint.Z = double.Parse(strArray5[2]);
                buShapeCut.Depth = double.Parse(strArray5[3]);
                buShapeCut.Diameter = double.Parse(strArray5[4]);
                planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray5[5].Trim(), true);
                buShapeCut.planeName = planeBoxNames;
                buShapeCut.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut.planeName);
                buShapeCut.Enable = buConversion5.StringToBool(strArray5[6]);
                buShapeCut.isMilling = buConversion5.StringToBool(strArray5[7]);
                buShapeCut.Length = double.Parse(strArray5[8]);
                buShapeCut.Angle = double.Parse(strArray5[9]);
                buShapeCut.StartDistance = double.Parse(strArray5[10]);
                buShapeCut.EndDistance = double.Parse(strArray5[11]);
                CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray5[12].Trim(), true);
                buShapeCut.Corner = cornerLocation;
                ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray5[13].Trim(), true);
                buShapeCut.Alignment = objectAlignment;
                if (strArray5.Length >= 10 & buShapeCut.isMilling && strArray5.Length >= 10)
                {
                  string sTool = strArray5[strArray5.Length - 1].Trim();
                  if (sTool.Length == 0)
                    sTool = strArray5[strArray5.Length - 2].Trim();
                  buShape S = (buShape) buShapeCut;
                  clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, sTool, ref S);
                }
                clsVar5.shapeCreatePar.Solid = true;
                clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                clsVar5.shapeCreatePar.SingX = -1.0;
                clsVar5.shapeCreatePar.SingY = -1.0;
                buShape Shape = (buShape) buShapeCut;
                clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                Job.Items.Add(Shape);
              }
            }
            if (strArray1[0].Trim() == ShapeGroup.Shape.ToString())
            {
              string[] strArray6 = CalcList3[index][1].Split(';');
              if (strArray6.Length != 0)
              {
                ShapeTypes shapeTypes = (ShapeTypes) Enum.Parse(typeof (ShapeTypes), strArray1[1].Trim(), true);
                bool flag = false;
                if (shapeTypes == ShapeTypes.Rectangle)
                {
                  buShapeRectangle buShapeRectangle = new buShapeRectangle();
                  buShapeRectangle.ShapeType = shapeTypes;
                  buShapeRectangle.BasePoint.X = double.Parse(strArray6[0]);
                  buShapeRectangle.BasePoint.Y = double.Parse(strArray6[1]);
                  buShapeRectangle.BasePoint.Z = double.Parse(strArray6[2]);
                  buShapeRectangle.Depth = double.Parse(strArray6[3]);
                  buShapeRectangle.Radius = double.Parse(strArray6[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray6[5].Trim(), true);
                  buShapeRectangle.planeName = planeBoxNames;
                  buShapeRectangle.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeRectangle.planeName);
                  buShapeRectangle.Enable = buConversion5.StringToBool(strArray6[6]);
                  buShapeRectangle.isPocket = buConversion5.StringToBool(strArray6[7]);
                  buShapeRectangle.Angle = double.Parse(strArray6[8]);
                  buShapeRectangle.Width = double.Parse(strArray6[9]);
                  buShapeRectangle.Height = double.Parse(strArray6[10]);
                  buShapeRectangle.Chamfer = double.Parse(strArray6[11]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray6[12].Trim(), true);
                  buShapeRectangle.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray6[13].Trim(), true);
                  buShapeRectangle.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeRectangle;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                  flag = true;
                }
                if (shapeTypes == ShapeTypes.Circle)
                {
                  buShapeCircle buShapeCircle = new buShapeCircle();
                  buShapeCircle.ShapeType = shapeTypes;
                  buShapeCircle.BasePoint.X = double.Parse(strArray6[0]);
                  buShapeCircle.BasePoint.Y = double.Parse(strArray6[1]);
                  buShapeCircle.BasePoint.Z = double.Parse(strArray6[2]);
                  buShapeCircle.Depth = double.Parse(strArray6[3]);
                  buShapeCircle.Radius = double.Parse(strArray6[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray6[5].Trim(), true);
                  buShapeCircle.planeName = planeBoxNames;
                  buShapeCircle.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCircle.planeName);
                  buShapeCircle.Enable = buConversion5.StringToBool(strArray6[6]);
                  buShapeCircle.isPocket = buConversion5.StringToBool(strArray6[7]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray6[8].Trim(), true);
                  buShapeCircle.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray6[9].Trim(), true);
                  buShapeCircle.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeCircle;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                  flag = true;
                }
                if (shapeTypes == ShapeTypes.Ellipse)
                {
                  buShapeEllipse buShapeEllipse = new buShapeEllipse();
                  buShapeEllipse.ShapeType = shapeTypes;
                  buShapeEllipse.BasePoint.X = double.Parse(strArray6[0]);
                  buShapeEllipse.BasePoint.Y = double.Parse(strArray6[1]);
                  buShapeEllipse.BasePoint.Z = double.Parse(strArray6[2]);
                  buShapeEllipse.Depth = double.Parse(strArray6[3]);
                  buShapeEllipse.RadiusX = double.Parse(strArray6[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray6[5].Trim(), true);
                  buShapeEllipse.planeName = planeBoxNames;
                  buShapeEllipse.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeEllipse.planeName);
                  buShapeEllipse.Enable = buConversion5.StringToBool(strArray6[6]);
                  buShapeEllipse.isPocket = buConversion5.StringToBool(strArray6[7]);
                  buShapeEllipse.Angle = double.Parse(strArray6[8]);
                  buShapeEllipse.RadiusY = double.Parse(strArray6[9]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray6[10].Trim(), true);
                  buShapeEllipse.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray6[11].Trim(), true);
                  buShapeEllipse.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeEllipse;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                  flag = true;
                }
                if (shapeTypes == ShapeTypes.Slot)
                {
                  buShapeSlot buShapeSlot = new buShapeSlot();
                  buShapeSlot.ShapeType = shapeTypes;
                  buShapeSlot.BasePoint.X = double.Parse(strArray6[0]);
                  buShapeSlot.BasePoint.Y = double.Parse(strArray6[1]);
                  buShapeSlot.BasePoint.Z = double.Parse(strArray6[2]);
                  buShapeSlot.Depth = double.Parse(strArray6[3]);
                  buShapeSlot.Diameter = double.Parse(strArray6[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray6[5].Trim(), true);
                  buShapeSlot.planeName = planeBoxNames;
                  buShapeSlot.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeSlot.planeName);
                  buShapeSlot.Enable = buConversion5.StringToBool(strArray6[6]);
                  buShapeSlot.isPocket = buConversion5.StringToBool(strArray6[7]);
                  buShapeSlot.Angle = double.Parse(strArray6[8]);
                  buShapeSlot.Length = double.Parse(strArray6[9]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray6[10].Trim(), true);
                  buShapeSlot.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray6[11].Trim(), true);
                  buShapeSlot.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeSlot;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                  flag = true;
                }
                if (shapeTypes == ShapeTypes.KeyHole)
                {
                  buShapeKeyHole buShapeKeyHole = new buShapeKeyHole();
                  buShapeKeyHole.ShapeType = shapeTypes;
                  buShapeKeyHole.BasePoint.X = double.Parse(strArray6[0]);
                  buShapeKeyHole.BasePoint.Y = double.Parse(strArray6[1]);
                  buShapeKeyHole.BasePoint.Z = double.Parse(strArray6[2]);
                  buShapeKeyHole.Depth = double.Parse(strArray6[3]);
                  buShapeKeyHole.Diameter = double.Parse(strArray6[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray6[5].Trim(), true);
                  buShapeKeyHole.planeName = planeBoxNames;
                  buShapeKeyHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeKeyHole.planeName);
                  buShapeKeyHole.Enable = buConversion5.StringToBool(strArray6[6]);
                  buShapeKeyHole.isPocket = buConversion5.StringToBool(strArray6[7]);
                  buShapeKeyHole.Angle = double.Parse(strArray6[8]);
                  buShapeKeyHole.HeadDiameter = double.Parse(strArray6[9]);
                  buShapeKeyHole.Length = double.Parse(strArray6[10]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray6[11].Trim(), true);
                  buShapeKeyHole.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray6[12].Trim(), true);
                  buShapeKeyHole.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeKeyHole;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                  flag = true;
                }
                if (shapeTypes == ShapeTypes.Polygon)
                {
                  buShapePolygon buShapePolygon = new buShapePolygon();
                  buShapePolygon.ShapeType = shapeTypes;
                  buShapePolygon.BasePoint.X = double.Parse(strArray6[0]);
                  buShapePolygon.BasePoint.Y = double.Parse(strArray6[1]);
                  buShapePolygon.BasePoint.Z = double.Parse(strArray6[2]);
                  buShapePolygon.Depth = double.Parse(strArray6[3]);
                  buShapePolygon.Radius = double.Parse(strArray6[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray6[5].Trim(), true);
                  buShapePolygon.planeName = planeBoxNames;
                  buShapePolygon.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapePolygon.planeName);
                  buShapePolygon.Enable = buConversion5.StringToBool(strArray6[6]);
                  buShapePolygon.isPocket = buConversion5.StringToBool(strArray6[7]);
                  buShapePolygon.Angle = double.Parse(strArray6[8]);
                  buShapePolygon.Side = int.Parse(strArray6[9]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray6[10].Trim(), true);
                  buShapePolygon.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray6[11].Trim(), true);
                  buShapePolygon.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapePolygon;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                  flag = true;
                }
                if (shapeTypes == ShapeTypes.FreeDraw)
                {
                  buShapeFreeDraw buShapeFreeDraw = new buShapeFreeDraw();
                  buShapeFreeDraw.ShapeType = shapeTypes;
                  buShapeFreeDraw.BasePoint.X = double.Parse(strArray6[0]);
                  buShapeFreeDraw.BasePoint.Y = double.Parse(strArray6[1]);
                  buShapeFreeDraw.BasePoint.Z = double.Parse(strArray6[2]);
                  buShapeFreeDraw.Depth = double.Parse(strArray6[3]);
                  buShapeFreeDraw.Width = double.Parse(strArray6[4]);
                  planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray6[5].Trim(), true);
                  buShapeFreeDraw.planeName = planeBoxNames;
                  buShapeFreeDraw.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeFreeDraw.planeName);
                  buShapeFreeDraw.Enable = buConversion5.StringToBool(strArray6[6]);
                  buShapeFreeDraw.isPocket = buConversion5.StringToBool(strArray6[7]);
                  buShapeFreeDraw.Angle = double.Parse(strArray6[8]);
                  buShapeFreeDraw.Height = double.Parse(strArray6[9]);
                  CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray6[10].Trim(), true);
                  buShapeFreeDraw.Corner = cornerLocation;
                  ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray6[11].Trim(), true);
                  buShapeFreeDraw.Alignment = objectAlignment;
                  clsVar5.shapeCreatePar.Solid = true;
                  clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                  clsVar5.shapeCreatePar.SingX = -1.0;
                  clsVar5.shapeCreatePar.SingY = -1.0;
                  buShape Shape = (buShape) buShapeFreeDraw;
                  clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                  Job.Items.Add(Shape);
                  flag = true;
                }
                if (strArray6.Length >= 10 & flag && strArray6.Length >= 10)
                {
                  string sTool = strArray6[strArray6.Length - 1].Trim();
                  if (sTool.Length == 0)
                    sTool = strArray6[strArray6.Length - 2].Trim();
                  buShape S = Job.Items[Job.Items.Count - 1];
                  clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, sTool, ref S);
                }
              }
            }
            if (strArray1[0].Trim() == ShapeGroup.Profiling.ToString())
            {
              string[] strArray7 = CalcList3[index][1].Split(';');
              if (strArray7.Length != 0)
              {
                buShapeProfiling buShapeProfiling = new buShapeProfiling();
                buShapeProfiling.ProfilingType = (ProfilingTypes) Enum.Parse(typeof (ProfilingTypes), strArray1[1].Trim(), true);
                buShapeProfiling.BasePoint.X = double.Parse(strArray7[0]);
                buShapeProfiling.BasePoint.Y = double.Parse(strArray7[1]);
                buShapeProfiling.BasePoint.Z = double.Parse(strArray7[2]);
                buShapeProfiling.Depth = double.Parse(strArray7[3]);
                buShapeProfiling.Radius = double.Parse(strArray7[4]);
                planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray7[5].Trim(), true);
                buShapeProfiling.planeName = planeBoxNames;
                buShapeProfiling.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeProfiling.planeName);
                buShapeProfiling.Enable = buConversion5.StringToBool(strArray7[6]);
                buShapeProfiling.isPocket = buConversion5.StringToBool(strArray7[7]);
                buShapeProfiling.Length = double.Parse(strArray7[8]);
                buShapeProfiling.Width = double.Parse(strArray7[9]);
                buShapeProfiling.Height = double.Parse(strArray7[10]);
                CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray7[11].Trim(), true);
                buShapeProfiling.Corner = cornerLocation;
                ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray7[12].Trim(), true);
                buShapeProfiling.Alignment = objectAlignment;
                if (strArray7.Length >= 10)
                {
                  string sTool = strArray7[strArray7.Length - 1].Trim();
                  if (sTool.Length == 0)
                    sTool = strArray7[strArray7.Length - 2].Trim();
                  buShape S = (buShape) buShapeProfiling;
                  clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, sTool, ref S);
                }
                clsVar5.shapeCreatePar.Solid = true;
                clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                clsVar5.shapeCreatePar.SingX = -1.0;
                clsVar5.shapeCreatePar.SingY = -1.0;
                buShape Shape = (buShape) buShapeProfiling;
                clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                Job.Items.Add(Shape);
              }
            }
            if (strArray1[0].Trim() == ShapeGroup.Junction.ToString())
            {
              string[] strArray8 = CalcList3[index][1].Split(';');
              if (strArray8.Length != 0)
              {
                buShapeJunction buShapeJunction = new buShapeJunction();
                buShapeJunction.JunctionType = (JunctionTypes) Enum.Parse(typeof (JunctionTypes), strArray1[1].Trim(), true);
                buShapeJunction.BasePoint.X = double.Parse(strArray8[0]);
                buShapeJunction.BasePoint.Y = double.Parse(strArray8[1]);
                buShapeJunction.BasePoint.Z = double.Parse(strArray8[2]);
                buShapeJunction.Depth = double.Parse(strArray8[3]);
                buShapeJunction.Diameter = double.Parse(strArray8[4]);
                planeBoxNames planeBoxNames = (planeBoxNames) Enum.Parse(typeof (planeBoxNames), strArray8[5].Trim(), true);
                buShapeJunction.planeName = planeBoxNames;
                buShapeJunction.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeJunction.planeName);
                buShapeJunction.Enable = buConversion5.StringToBool(strArray8[6]);
                buShapeJunction.isMilling = buConversion5.StringToBool(strArray8[7]);
                buShapeJunction.DiameterOutside = double.Parse(strArray8[8]);
                buShapeJunction.Distance = double.Parse(strArray8[9]);
                CornerLocation cornerLocation = (CornerLocation) Enum.Parse(typeof (CornerLocation), strArray8[10].Trim(), true);
                buShapeJunction.Corner = cornerLocation;
                ObjectAlignment objectAlignment = (ObjectAlignment) Enum.Parse(typeof (ObjectAlignment), strArray8[11].Trim(), true);
                buShapeJunction.Alignment = objectAlignment;
                clsVar5.shapeCreatePar.Solid = true;
                clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                clsVar5.shapeCreatePar.SingX = -1.0;
                clsVar5.shapeCreatePar.SingY = -1.0;
                buShape Shape = (buShape) buShapeJunction;
                clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                Job.Items.Add(Shape);
              }
            }
          }
        }
      }
      if (OpenAll)
      {
        List<ToolBase5> CopiedTools = new List<ToolBase5>();
        ToolBase5.Copy(clsDrill.ToolList, ref CopiedTools);
        if (clsDrill.ToolList.Count == 0)
          ;
        List<string> CalcList4 = new List<string>();
        buString5.ListToSpecificList("<ToolConfiguration>", "</ToolConfiguration>", false, Lines, ref CalcList4);
        if (CalcList4.Count > 0)
        {
          clsDrill.ToolList = new List<ToolBase5>();
          clsInit.cDrill.StringListToTool(CalcList1, ref clsDrill.ToolList);
        }
        if (clsDrill.ToolList.Count == 0 & CopiedTools.Count > 0)
          ToolBase5.Copy(CopiedTools, ref clsDrill.ToolList);
        ArrayList CalcList5 = new ArrayList();
        buString5.ListToSpecificList("<SettingConfiguration>", "</SettingConfiguration>", false, Lines, ref CalcList5);
        ArrayList CalcList6 = new ArrayList();
        buString5.ListToSpecificList("<CamConfiguration>", "</CamConfiguration>", false, Lines, ref CalcList6);
        if (CalcList5.Count > 0 | CalcList6.Count > 0)
          this.OpenDrillFile(CalcList5, CalcList6);
        if (clsDrill.ToolList.Count == 0)
          this.OpenDrillFile();
      }
      if (clsDrill.ToolList.Count == 0)
        buString5.MessageBoxWarning(buLangTranslate.preSentences.CustomerClassNotReady);
    }
    if (Preview)
      return;
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(Job);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit(40);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void OpenDrillJobFile(string FileName, ref DrillJob Job, bool OpenAll = false, bool Preview = false)
  {
    try
    {
      List<string> StringList = new List<string>();
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      buFile5.OpenFromFile(FileName, ref StringList);
      this.OpenDrillJobFile(StringList, ref Job, OpenAll, Preview);
      this.fileNameActual = FileName;
      this.AddRecentOpenFile(FileName);
      ccVars.Pages[ccVars.PageIndex].Form.Text = buFile5.getFileName(FileName);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void OpenToolConfigFile(string FileName)
  {
    try
    {
      List<string> StringList = new List<string>();
      buFile5.OpenFromFile(FileName, ref StringList);
      clsDrill.ToolList = new List<ToolBase5>();
      clsInit.cDrill.StringListToTool(StringList, ref clsDrill.ToolList);
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Data.No == 85)
            clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[index]);
          if (clsDrill.ToolList[index].Data.No == 185)
            clsDrill.toolSlotY2 = new ToolBase5(clsDrill.ToolList[index]);
        }
      }
      if (this.MachType == DrillMachineType.GoWithAtc)
      {
        for (int index = 0; index <= clsDrill.ToolList.Count - 1; ++index)
        {
          if (clsDrill.ToolList[index].Data.No == 95)
            clsDrill.toolSlotY1 = new ToolBase5(clsDrill.ToolList[index]);
        }
      }
      if (this.MachType == DrillMachineType.Sirius)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void SaveToolConfigFile(string FileName)
  {
    List<string> SL = new List<string>();
    clsInit.cDrill.ToolToStringList(clsDrill.ToolList, ref SL);
    if (SL.Count <= 0)
      return;
    SL.Insert(0, $"{Application.ProductVersion} - {clsVar.varRuntime.ReleaseVer}");
    SL.Insert(1, this.MachType.ToString());
    buFile5.SaveToFile(SL, FileName);
  }

  public void OpenFilePreview(FileEventArg e)
  {
    try
    {
      FileInfo fileInfo = new FileInfo(e.FileName);
      if (fileInfo.Exists & this.openDialogCtrlPreview.chk_preview.Checked)
      {
        clsVar.PreviewLoaded = false;
        clsItem.ModelOpenPreview.Width = this.openDialogCtrlPreview.picture_preview.Width;
        clsItem.ModelOpenPreview.Height = this.openDialogCtrlPreview.picture_preview.Height;
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        {
          Layer layer = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index];
          if (!clsInit.cVector5.IsLayerNameAvailable(clsItem.ModelOpenPreview.Layers, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Name))
          {
            Layer newItem = new Layer(layer.Name, layer.Color, layer.LineTypeName, layer.LineWeight, true);
            clsItem.ModelOpenPreview.Layers.AddOrReplace(newItem);
          }
        }
        if (fileInfo.Extension.ToLower() == ".aesjob")
        {
          this.openDialogCtrlPreview.ShowLoading(true);
          Application.DoEvents();
          DrillJob Job = new DrillJob();
          this.OpenDrillJobFile(fileInfo.FullName, ref Job, Preview: true);
          this.DrawPanelFromJob(Job, new ViewportDrawOptions(ViewportRefType.OpenDialog));
          this.openDialogCtrlPreview.lbl_info.Text = $"{Job.Material.Size.Width.ToString("f1")} X {Job.Material.Size.Height.ToString("f1")} X {Job.Material.Size.Depth.ToString("f1")}";
          this.SetPreviewImage();
        }
        if (fileInfo.Extension.ToLower() == ".aesnc")
        {
          this.openDialogCtrlPreview.ShowLoading(true);
          Application.DoEvents();
          DrillJob Job = new DrillJob();
          this.OpenCabinetFile(fileInfo.FullName, ref Job, true);
          this.DrawPanelFromJob(Job, new ViewportDrawOptions(ViewportRefType.OpenDialog));
          this.openDialogCtrlPreview.lbl_info.Text = $"{Job.Material.Size.Width.ToString("f1")} X {Job.Material.Size.Height.ToString("f1")} X {Job.Material.Size.Depth.ToString("f1")}";
          this.SetPreviewImage();
        }
        if (!(fileInfo.Extension.ToLower() == ".dxf"))
          return;
        this.openDialogCtrlPreview.ShowLoading(true);
        Application.DoEvents();
        DrillJob Job1 = new DrillJob();
        this.OpenCorpusFile(fileInfo.FullName, ref Job1, true);
        this.DrawPanelFromJob(Job1, new ViewportDrawOptions(ViewportRefType.OpenDialog));
        this.openDialogCtrlPreview.lbl_info.Text = $"{Job1.Material.Size.Width.ToString("f1")} X {Job1.Material.Size.Height.ToString("f1")} X {Job1.Material.Size.Depth.ToString("f1")}";
        this.SetPreviewImage();
      }
      else
        this.openDialogCtrlPreview.picture_preview.Image = (Image) null;
    }
    catch (Exception ex)
    {
      Console.WriteLine((object) ex);
      throw;
    }
  }

  public void ERPCycle_Tick(object sender, EventArgs e)
  {
    if (this.timCabinetStartCycle.Enabled)
      return;
    this.FilesERP = new List<string>();
    buFile5.getFiles(clsDrill.varDrillRunSettings.CabinetpathImport, ref this.FilesERP);
    if (!(this.FilesERP.Count > 0 & this.fileNameCabinerCycle == ""))
      return;
    if (clsDrill.varDrillRunSettings.ErpFileType == drillErpFileType.Cabinet)
    {
      for (int index = 0; index <= this.FilesERP.Count - 1; ++index)
      {
        FileInfo fileInfo = new FileInfo(this.FilesERP[index]);
        if (fileInfo.Exists && fileInfo.Extension == "." + clsDrill.varDrillRunSettings.CabinetAutoFileExtension)
        {
          this.fileNameCabinerCycle = fileInfo.FullName;
          this.timCabinetStartCycle.Enabled = true;
        }
      }
    }
    if (clsDrill.varDrillRunSettings.ErpFileType == drillErpFileType.Corpus)
    {
      this.timCabinetCycle.Enabled = false;
      this.OpenCorpusJobListFile(this.FilesERP, true);
    }
    if (clsDrill.varDrillRunSettings.ErpFileType != drillErpFileType.Cyncly)
      return;
    this.timCabinetCycle.Enabled = false;
    this.OpenCynclyJobListFile(this.FilesERP, true);
  }

  public void ERPStartCycle_Tick(object sender, EventArgs e)
  {
    this.timCabinetStartCycle.Enabled = false;
    if (clsDrill.varDrillRunSettings.ErpFileType == drillErpFileType.Cabinet)
      this.OpenCabinetJobListFile(this.fileNameCabinerCycle, true);
    DirectoryInfo directoryInfo = new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathDeleted);
    if (directoryInfo.Exists & clsDrill.varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
      buFile5.CopyFileToFolder(this.fileNameCabinerCycle, directoryInfo.FullName);
    System.IO.File.Delete(this.fileNameCabinerCycle);
    this.fileNameCabinerCycle = "";
  }

  public void OpenCabinetJobListFile(string Filename, bool AutoFileArrived = false)
  {
    List<string> StringList1 = new List<string>();
    buFile5.OpenFromFile(Filename, ref StringList1);
    List<InfoCount> infoCountList = new List<InfoCount>();
    int num1 = -1;
    for (int index = 0; index <= StringList1.Count - 1; ++index)
    {
      if (StringList1[index].IndexOf(clsDrill.varDrillRunSettings.CabinetReferanceKey) >= 0)
      {
        num1 = index;
        index = StringList1.Count;
      }
    }
    if (num1 == -1)
    {
      buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[65]);
    }
    else
    {
      if (StringList1.Count <= num1 || StringList1[0].IndexOf("^Job") < 0)
        return;
      if (clsItem.FrmProgress == null)
        clsItem.FrmProgress = new F_ProgressCalculation();
      string withoutExtension1 = buFile5.getFileNameWithoutExtension(Filename);
      string path = buFile5.GetPath(Filename);
      DirectoryInfo directoryInfo1 = new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathExport);
      if (!directoryInfo1.Exists)
      {
        directoryInfo1 = new DirectoryInfo($"{path}\\{withoutExtension1}");
        if (directoryInfo1.Exists)
          directoryInfo1.Delete(true);
        directoryInfo1.Create();
      }
      else if (clsDrill.varDrillRunSettings.CabinetSubFolder)
      {
        directoryInfo1 = new DirectoryInfo($"{clsDrill.varDrillRunSettings.CabinetpathExport}\\{withoutExtension1}");
        if (!directoryInfo1.Exists)
          directoryInfo1.Create();
      }
      TreeNode node = (TreeNode) null;
      if (AutoFileArrived & this.FrmCabinetCycle.Visible)
        node = new TreeNode(withoutExtension1);
      CalculationEventArg e = new CalculationEventArg();
      for (int index1 = num1; index1 <= StringList1.Count - 1; ++index1)
      {
        clsItem.FrmProgress.Visible = true;
        string[] strArray = StringList1[index1].Split(',');
        if ((strArray == null ? 0 : (strArray.Length != 0 ? 1 : 0)) != 0)
        {
          FileInfo fileInfo = new FileInfo($"{path}\\{strArray[0].Trim()}.AESNC");
          bool flag = true;
          if (fileInfo.Exists)
          {
            InfoCount infoCount = new InfoCount(1.0, strArray[0].Trim());
            for (int index2 = 0; index2 <= infoCountList.Count - 1; ++index2)
            {
              if (infoCountList[index2].Info == strArray[0].Trim())
              {
                ++infoCountList[index2].Count;
                flag = false;
                index2 = infoCountList.Count;
              }
            }
            if (flag)
            {
              infoCountList.Add(infoCount);
              string withoutExtension2 = buFile5.getFileNameWithoutExtension(fileInfo.FullName);
              clsDrill.activeJob = new DrillJob();
              this.OpenCabinetFile(fileInfo.FullName, ref clsDrill.activeJob);
              this.cmdShowCode(true, $"{directoryInfo1.FullName}\\{withoutExtension2}");
            }
          }
          if (AutoFileArrived & fileInfo.Exists)
          {
            if (this.FrmCabinetCycle.Visible & node != null)
            {
              TreeNode treeNode = new TreeNode();
              node.Nodes.Add($"{strArray[0].Trim()} - {strArray[1].Trim()}");
            }
            DirectoryInfo directoryInfo2 = new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathDeleted);
            if (directoryInfo2.Exists & clsDrill.varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
              buFile5.CopyFileToFolder(fileInfo.FullName, directoryInfo2.FullName);
            fileInfo.Delete();
          }
        }
        e.ActiveProgressPercentage = 100.0 * (double) index1 / Convert.ToDouble(StringList1.Count - 1);
        e.OverallProgressPercentage = 100.0;
        e.Job = buLangTranslate.preDef.Calculating;
        clsInit.appCommand.CalculationInProgressCmd(e);
      }
      clsItem.FrmProgress.Visible = false;
      if (AutoFileArrived & this.FrmCabinetCycle.Visible & node != null)
        this.FrmCabinetCycle.tree_files.Nodes.Add(node);
      if (!(infoCountList.Count > 0 & clsDrill.varDrillRunSettings.CabinetShowInfo & !AutoFileArrived))
        return;
      DialogBoxList dialogBoxList = new DialogBoxList();
      List<string> StringList2 = new List<string>();
      for (int index = 0; index <= infoCountList.Count - 1; ++index)
      {
        StringList2.Add($"{infoCountList[index].Info};{infoCountList[index].Count.ToString("f0")}");
        dialogBoxList.Items.Add($"{buLangTranslate.preDef.FileName}: {infoCountList[index].Info}  {buLangTranslate.preDef.Count}: {infoCountList[index].Count.ToString("f0")}");
      }
      string FileName = directoryInfo1.FullName + "\\Info.txt";
      buFile5.SaveToFile(StringList2, FileName);
      clsItem.FrmProgress.Visible = false;
      dialogBoxList.Caption = buLangTranslate.preDef.Job;
      dialogBoxList.Init();
      int num2 = (int) dialogBoxList.ShowDialog();
      clsItem.FrmProgress.Visible = false;
    }
  }

  public void OpenCabinetFile(string Filename, ref DrillJob Job, bool Preview = false)
  {
    clsDrill.varDrillRunSettings.path3DJob = buFile5.GetPath(Filename);
    this.SaveDrillFile();
    List<string> StringList = new List<string>();
    buFile5.OpenFromFile(Filename, ref StringList);
    string withoutExtension = buFile5.getFileNameWithoutExtension(Filename);
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    if (withoutExtension.Length < 4 || withoutExtension.Substring(3, 1).ToLower() == "f")
      ;
    if (StringList.Count <= 0)
      return;
    string s = "";
    bool flag1 = false;
    bool flag2 = false;
    Job = new DrillJob();
    List<string> stringList = new List<string>();
    ToolBase5 tool = (ToolBase5) null;
    for (int index1 = 0; index1 <= StringList.Count - 1; ++index1)
    {
      if (StringList[index1].IndexOf("PNAME") >= 0)
        buString5.ReadStringValue(StringList[index1], "PNAME=", ref Job.Name);
      if (StringList[index1].IndexOf("XAX") >= 0)
      {
        string[] strArray = StringList[index1].Split(' ');
        if (strArray.Length != 0)
        {
          for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
          {
            if (strArray[index2].IndexOf("XAX") >= 0)
            {
              buString5.ReadStringValue(strArray[index2], "XAX=", ref s);
              double.TryParse(s, out Job.Material.Size.Width);
            }
            if (strArray[index2].IndexOf("YAX") >= 0)
            {
              buString5.ReadStringValue(strArray[index2], "YAX=", ref s);
              double.TryParse(s, out Job.Material.Size.Height);
            }
            if (strArray[index2].IndexOf("ZAX") >= 0)
            {
              buString5.ReadStringValue(strArray[index2], "ZAX=", ref s);
              double.TryParse(s, out Job.Material.Size.Depth);
            }
          }
          Entity entity = (Entity) null;
          clsInit.cVector5.CreateMaterialEntities(Job.Material, ref entity);
          clsInit.cVector5.Move(-Job.Material.Size.Width, -Job.Material.Size.Height, 0.0, ref entity);
          Job.Material.Entities.Add(entity);
          Job.panelEntity = entity;
        }
      }
      if (StringList[index1].IndexOf("M40") >= 0 | StringList[index1].IndexOf("M41") >= 0)
      {
        string[] strArray1 = StringList[index1].Split(' ');
        if (strArray1.Length != 0)
        {
          buShapeHole buShapeHole = new buShapeHole();
          if (StringList[index1].IndexOf("M41") >= 0)
            buShapeHole.isMilling = true;
          bool flag3 = false;
          for (int index3 = 0; index3 <= strArray1.Length - 1; ++index3)
          {
            if (strArray1[index3].IndexOf("FACE") >= 0)
            {
              buString5.ReadStringValue(strArray1[index3], "FACE=", ref s);
              int result = 0;
              int.TryParse(s, out result);
              if (result == 2)
              {
                buShapeHole.planeName = planeBoxNames.Left;
                flag3 = true;
              }
              if (result == 4)
              {
                buShapeHole.planeName = planeBoxNames.Right;
                flag3 = true;
              }
              if (result == 5)
              {
                buShapeHole.planeName = planeBoxNames.Bottom;
                flag3 = true;
              }
              if (result == 0)
              {
                buShapeHole.planeName = planeBoxNames.Top;
                flag3 = true;
              }
              if (result == 3)
              {
                buShapeHole.planeName = planeBoxNames.Front;
                flag3 = true;
              }
              if (result == 1)
              {
                buShapeHole.planeName = planeBoxNames.Back;
                flag3 = true;
              }
            }
          }
          string[] strArray2 = StringList[index1 + 1].Split(' ');
          for (int index4 = 0; index4 <= strArray2.Length - 1; ++index4)
          {
            if (strArray2[index4].IndexOf("X") >= 0)
            {
              if (buShapeHole.planeName == planeBoxNames.Top | buShapeHole.planeName == planeBoxNames.Bottom | buShapeHole.planeName == planeBoxNames.Front | buShapeHole.planeName == planeBoxNames.Back)
                buString5.ReadCharValue(strArray2[index4], "X", ref buShapeHole.BasePoint.X);
              if (buShapeHole.planeName == planeBoxNames.Right)
                buShapeHole.BasePoint.X = 0.0;
              if (buShapeHole.planeName == planeBoxNames.Left)
                buShapeHole.BasePoint.X = Job.Material.Size.Width;
            }
            if (strArray2[index4].IndexOf("Y") >= 0)
            {
              if (buShapeHole.planeName == planeBoxNames.Left | buShapeHole.planeName == planeBoxNames.Right | buShapeHole.planeName == planeBoxNames.Top | buShapeHole.planeName == planeBoxNames.Bottom)
                buString5.ReadCharValue(strArray2[index4], "Y", ref buShapeHole.BasePoint.Y);
              if (buShapeHole.planeName == planeBoxNames.Back)
                buShapeHole.BasePoint.Y = 0.0;
              if (buShapeHole.planeName == planeBoxNames.Front)
                buShapeHole.BasePoint.Y = Job.Material.Size.Height;
              buShapeHole.BasePoint.Z = 9.0;
            }
            if (strArray2[index4].IndexOf("D") >= 0)
              buString5.ReadCharValue(strArray2[index4], "D", ref buShapeHole.Diameter);
            if (strArray2[index4].IndexOf("VB") >= 0)
            {
              buString5.ReadCharValue(strArray2[index4], "VB", ref buShapeHole.Depth);
              buShapeHole.Depth = Math.Abs(buShapeHole.Depth);
            }
          }
          buShapeHole.DrillType = drillTypes.SingleHole;
          buShapeHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole.planeName);
          buShapeHole.Corner = CornerLocation.RightTop;
          buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
          if (buShapeHole.isMilling)
          {
            for (int index5 = 0; index5 <= ccVars.Tools[0].Tools.Count - 1; ++index5)
            {
              if (buCompare5.EQ(ccVars.Tools[0].Tools[index5].Geometry.Diameter, buShapeHole.Diameter, 0.01))
                buShapeHole.Tool = new ToolBase5(ccVars.Tools[0].Tools[index5]);
            }
          }
          clsVar5.shapeCreatePar.Solid = true;
          clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
          clsVar5.shapeCreatePar.SingX = -1.0;
          clsVar5.shapeCreatePar.SingY = -1.0;
          buShape Shape = (buShape) buShapeHole;
          clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
          if (flag3)
            Job.Items.Add(Shape);
        }
      }
      if (StringList[index1].IndexOf("M42") >= 0)
      {
        string[] strArray3 = StringList[index1].Split(' ');
        if (strArray3.Length != 0)
        {
          buShapeCut buShapeCut = new buShapeCut();
          bool flag4 = false;
          for (int index6 = 0; index6 <= strArray3.Length - 1; ++index6)
          {
            if (strArray3[index6].IndexOf("FACE") >= 0)
            {
              buString5.ReadStringValue(strArray3[index6], "FACE=", ref s);
              int result = 0;
              int.TryParse(s, out result);
              if (result == 4)
              {
                buShapeCut.planeName = planeBoxNames.Left;
                flag4 = true;
              }
              if (result == 2)
              {
                buShapeCut.planeName = planeBoxNames.Right;
                flag4 = true;
              }
              if (result == 0)
              {
                buShapeCut.planeName = planeBoxNames.Top;
                flag4 = true;
              }
              if (result == 1)
              {
                buShapeCut.planeName = planeBoxNames.Front;
                flag4 = true;
              }
              if (result == 3)
              {
                buShapeCut.planeName = planeBoxNames.Back;
                flag4 = true;
              }
            }
          }
          string[] strArray4 = StringList[index1 + 1].Split(' ');
          for (int index7 = 0; index7 <= strArray4.Length - 1; ++index7)
          {
            if (strArray4[index7].IndexOf("XBAS") >= 0)
            {
              if (buShapeCut.planeName == planeBoxNames.Top | buShapeCut.planeName == planeBoxNames.Front | buShapeCut.planeName == planeBoxNames.Back)
                buString5.ReadStringValue(strArray4[index7], "XBAS", ref buShapeCut.BasePoint.X, "=");
              if (buShapeCut.planeName == planeBoxNames.Right)
                buShapeCut.BasePoint.X = 0.0;
              if (buShapeCut.planeName == planeBoxNames.Left)
                buShapeCut.BasePoint.X = Job.Material.Size.Width;
            }
            if (strArray4[index7].IndexOf("XSON") >= 0)
            {
              if (buShapeCut.planeName == planeBoxNames.Top | buShapeCut.planeName == planeBoxNames.Front | buShapeCut.planeName == planeBoxNames.Back)
              {
                double num4 = 0.0;
                buString5.ReadStringValue(strArray4[index7], "XSON", ref num4, "=");
                buShapeCut.Length = num4 - buShapeCut.BasePoint.X;
              }
              if (buShapeCut.planeName == planeBoxNames.Right)
                buShapeCut.BasePoint.X = 0.0;
              if (buShapeCut.planeName == planeBoxNames.Left)
                buShapeCut.BasePoint.X = Job.Material.Size.Width;
            }
            if (strArray4[index7].IndexOf("YBAS") >= 0)
            {
              if (buShapeCut.planeName == planeBoxNames.Left | buShapeCut.planeName == planeBoxNames.Right | buShapeCut.planeName == planeBoxNames.Top)
                buString5.ReadStringValue(strArray4[index7], "YBAS", ref buShapeCut.BasePoint.Y, "=");
              if (buShapeCut.planeName == planeBoxNames.Back)
                buShapeCut.BasePoint.Y = 0.0;
              if (buShapeCut.planeName == planeBoxNames.Front)
                buShapeCut.BasePoint.Y = Job.Material.Size.Height;
              buShapeCut.BasePoint.Z = 9.0;
            }
            if (strArray4[index7].IndexOf("Z=") >= 0)
            {
              double num5 = 0.0;
              buString5.ReadStringValue(strArray4[index7], "Z", ref num5, "=");
              buShapeCut.Depth = Math.Abs(num5);
            }
            if (strArray4[index7].IndexOf("D") >= 0)
              buString5.ReadCharValue(strArray4[index7], "D", ref buShapeCut.Diameter);
          }
          buShapeCut.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut.planeName);
          buShapeCut.Corner = CornerLocation.RightTop;
          buShapeCut.Alignment = ObjectAlignment.MiddleCenter;
          clsVar5.shapeCreatePar.Solid = true;
          clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
          clsVar5.shapeCreatePar.SingX = -1.0;
          clsVar5.shapeCreatePar.SingY = -1.0;
          buShape Shape = (buShape) buShapeCut;
          clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
          if (flag4)
            Job.Items.Add(Shape);
        }
      }
      if (StringList[index1].IndexOf("M60") >= 0 & flag2)
      {
        buFile.GCodeRead gcodeRead = new buFile.GCodeRead();
        List<GCodePoint> GCodeList = new List<GCodePoint>();
        buSystem.EntitiesResolution.LnRatio = 0.75;
        buSystem.EntitiesResolution.MinPointCount = 15;
        gcodeRead.OpenGCode(stringList, ref GCodeList);
        buShapeCut buShapeCut = new buShapeCut();
        for (int index8 = 0; index8 <= stringList.Count - 1; ++index8)
        {
          if (stringList[index8].IndexOf("T") >= 0)
          {
            double num6 = 0.0;
            buString5.ReadCharValue(stringList[index8], "T", ref num6);
            for (int index9 = 0; index9 <= ccVars.Tools[0].Tools.Count - 1; ++index9)
            {
              if (ccVars.Tools[0].Tools[index9].Data.No == (int) num6)
              {
                buShapeCut.Tool = new ToolBase5(ccVars.Tools[0].Tools[index9]);
                buShapeCut.SpindleSpeed = buShapeCut.Tool.CamData.SpindleSpeed;
                tool = new ToolBase5(buShapeCut.Tool);
              }
            }
          }
          if (stringList[index8].IndexOf("S") >= 0)
          {
            double num7 = 0.0;
            buString5.ReadCharValue(stringList[index8], "S", ref num7);
            if (num7 >= 100.0)
            {
              buShapeCut.SpindleSpeed = num7;
              num3 = num7;
            }
          }
          if ((stringList[index8].IndexOf("G01") >= 0 | stringList[index8].IndexOf("G1") >= 0) & stringList[index8].IndexOf("X") >= 0 & stringList[index8].IndexOf("F") >= 0)
          {
            double num8 = 0.0;
            buString5.ReadCharValue(stringList[index8], "F", ref num8);
            if (num8 > 100.0)
            {
              buShapeCut.feedCutting = num8;
              num1 = num8;
            }
          }
          if ((stringList[index8].IndexOf("G01") >= 0 | stringList[index8].IndexOf("G1") >= 0) & stringList[index8].IndexOf("Z") >= 0 & stringList[index8].IndexOf("F") >= 0)
          {
            double num9 = 0.0;
            buString5.ReadCharValue(stringList[index8], "F", ref num9);
            if (num9 > 100.0)
            {
              buShapeCut.feedPlunge = num9;
              num2 = num9;
            }
          }
        }
        if (buShapeCut.SpindleSpeed == 0.0)
        {
          if (num3 > 0.0)
            buShapeCut.SpindleSpeed = num3;
          else
            buShapeCut.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
        }
        if (buShapeCut.feedCutting == 0.0)
        {
          if (num1 > 0.0)
            buShapeCut.feedCutting = num1;
          else
            buShapeCut.feedCutting = clsDrill.varDrillCNCSettings.MillingFeed;
        }
        if (buShapeCut.feedPlunge == 0.0)
        {
          if (num2 > 0.0)
            buShapeCut.feedPlunge = num2;
          else
            buShapeCut.feedPlunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
        }
        if (buShapeCut.Tool == null & tool != null)
          buShapeCut.Tool = new ToolBase5(tool);
        stringList = new List<string>();
        buEntity.eEntityToEyeEntity(gcodeRead.EntitiesG1, ref buShapeCut.entityWireframe);
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(buShapeCut.entityWireframe, ref MinPoint, ref MidPoint, ref MaxPoint);
        if (buCompare5.EQ(MaxPoint.X - MinPoint.X, 0.0))
        {
          buShapeCut.CutType = CutTypes.CutVertical;
          buShapeCut.Length = MaxPoint.Y - MinPoint.Y;
        }
        if (buCompare5.EQ(MaxPoint.Y - MinPoint.Y, 0.0))
        {
          buShapeCut.CutType = CutTypes.CutHorizontal;
          buShapeCut.Length = MaxPoint.X - MinPoint.X;
        }
        buShapeCut.planeName = planeBoxNames.Top;
        buShapeCut.BasePoint.X = MinPoint.X;
        buShapeCut.BasePoint.Y = MinPoint.Y;
        buShapeCut.BasePoint.Z = MinPoint.Z;
        buShapeCut.Depth = Math.Abs(MinPoint.Z);
        if (buShapeCut.Tool != null)
          buShapeCut.Diameter = buShapeCut.Tool.Geometry.Diameter;
        buShapeCut.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut.planeName);
        buShapeCut.Corner = CornerLocation.RightTop;
        buShapeCut.Alignment = ObjectAlignment.MiddleCenter;
        buShapeCut.isMilling = true;
        clsVar5.shapeCreatePar.Solid = true;
        clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
        clsVar5.shapeCreatePar.SingX = -1.0;
        clsVar5.shapeCreatePar.SingY = -1.0;
        buShape Shape = (buShape) buShapeCut;
        clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
        buShapeCut.entityWireframe.Clear();
        for (int index10 = 0; index10 <= gcodeRead.EntitiesG1.Count - 1; ++index10)
        {
          List<Point3D> Points = new List<Point3D>();
          for (int index11 = 0; index11 <= gcodeRead.EntitiesG1[index10].Vertice.Count - 1; ++index11)
            Points.Add(new Point3D(-gcodeRead.EntitiesG1[index10].Vertice[index11].X, -gcodeRead.EntitiesG1[index10].Vertice[index11].Y, Job.Material.Size.Depth - buShapeCut.Depth));
          if (Points.Count >= 2)
          {
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
            buShapeCut.entityWireframe.Add((Entity) new LinearPath((ICollection<Point3D>) Points));
          }
        }
        Job.Items.Add(Shape);
      }
      if (StringList[index1].IndexOf("M60") >= 0 & !flag2)
      {
        buFile.GCodeRead gcodeRead = new buFile.GCodeRead();
        List<GCodePoint> GCodeList = new List<GCodePoint>();
        buSystem.EntitiesResolution.LnRatio = 0.75;
        buSystem.EntitiesResolution.MinPointCount = 15;
        gcodeRead.OpenGCode(stringList, ref GCodeList);
        buShapeFreeLines buShapeFreeLines = new buShapeFreeLines();
        buShapeFreeLines.Codes = new List<string>();
        buShapeFreeLines.Codes.AddRange((IEnumerable<string>) stringList);
        for (int index12 = 0; index12 <= stringList.Count - 1; ++index12)
        {
          if (stringList[index12].IndexOf("T") >= 0)
          {
            double num10 = 0.0;
            buString5.ReadCharValue(stringList[index12], "T", ref num10);
            for (int index13 = 0; index13 <= ccVars.Tools[0].Tools.Count - 1; ++index13)
            {
              if (ccVars.Tools[0].Tools[index13].Data.No == (int) num10)
              {
                buShapeFreeLines.Tool = new ToolBase5(ccVars.Tools[0].Tools[index13]);
                tool = new ToolBase5(buShapeFreeLines.Tool);
              }
            }
          }
          if (stringList[index12].IndexOf("S") >= 0)
          {
            double num11 = 0.0;
            buString5.ReadCharValue(stringList[index12], "S", ref num11);
            if (num11 >= 100.0)
            {
              buShapeFreeLines.SpindleSpeed = num11;
              num3 = num11;
            }
          }
          if ((stringList[index12].IndexOf("G01") >= 0 | stringList[index12].IndexOf("G1") >= 0) & stringList[index12].IndexOf("X") >= 0 & stringList[index12].IndexOf("F") >= 0)
          {
            double num12 = 0.0;
            buString5.ReadCharValue(stringList[index12], "F", ref num12);
            if (num12 > 100.0)
            {
              buShapeFreeLines.feedCutting = num12;
              num1 = num12;
            }
          }
          if ((stringList[index12].IndexOf("G01") >= 0 | stringList[index12].IndexOf("G1") >= 0) & stringList[index12].IndexOf("Z") >= 0 & stringList[index12].IndexOf("F") >= 0)
          {
            double num13 = 0.0;
            buString5.ReadCharValue(stringList[index12], "F", ref num13);
            if (num13 > 100.0)
            {
              buShapeFreeLines.feedPlunge = num13;
              num2 = num13;
            }
          }
        }
        if (buShapeFreeLines.SpindleSpeed == 0.0)
        {
          if (num3 > 0.0)
            buShapeFreeLines.SpindleSpeed = num3;
          else
            buShapeFreeLines.SpindleSpeed = clsDrill.varDrillCNCSettings.TopSpindleSpeed;
        }
        if (buShapeFreeLines.feedCutting == 0.0)
        {
          if (num1 > 0.0)
            buShapeFreeLines.feedCutting = num1;
          else
            buShapeFreeLines.feedCutting = clsDrill.varDrillCNCSettings.MillingFeed;
        }
        if (buShapeFreeLines.feedPlunge == 0.0)
        {
          if (num2 > 0.0)
            buShapeFreeLines.feedPlunge = num2;
          else
            buShapeFreeLines.feedPlunge = clsDrill.varDrillCNCSettings.MillingPlungeFeed;
        }
        if (buShapeFreeLines.Tool == null & tool != null)
          buShapeFreeLines.Tool = new ToolBase5(tool);
        buEntity.eEntityToEyeEntity(gcodeRead.EntitiesG1, ref buShapeFreeLines.entityWireframe);
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(buShapeFreeLines.entityWireframe, ref MinPoint, ref MidPoint, ref MaxPoint);
        if (MaxPoint.Y - MinPoint.Y <= 0.1 && buShapeFreeLines.Tool != null)
        {
          MaxPoint.Y += buShapeFreeLines.Tool.Geometry.Diameter / 2.0;
          MinPoint.Y -= buShapeFreeLines.Tool.Geometry.Diameter / 2.0;
        }
        if (gcodeRead.EntitiesG1[0].Vertice[1].Z < Job.Material.Size.Depth)
          buShapeFreeLines.Depth = Job.Material.Size.Depth - Math.Abs(gcodeRead.EntitiesG1[0].Vertice[1].Z);
        buShapeFreeLines.BasePoint = new Point3D(MidPoint.X, MidPoint.Y, Job.Material.Size.Depth);
        buShapeFreeLines.ShapeGroup = ShapeGroup.Shape;
        buShapeFreeLines.ShapeType = ShapeTypes.FreeLines;
        buShapeFreeLines.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeFreeLines.planeName);
        buShapeFreeLines.Corner = CornerLocation.RightTop;
        buShapeFreeLines.Alignment = ObjectAlignment.MiddleCenter;
        buShapeFreeLines.planeName = planeBoxNames.Top;
        buShapeFreeLines.Width = MaxPoint.X - MinPoint.X;
        buShapeFreeLines.Height = MaxPoint.Y - MinPoint.Y;
        buShapeFreeLines.entityWireframe.Clear();
        for (int index14 = 0; index14 <= gcodeRead.EntitiesG1.Count - 1; ++index14)
        {
          List<Point3D> Points = new List<Point3D>();
          for (int index15 = 0; index15 <= gcodeRead.EntitiesG1[index14].Vertice.Count - 1; ++index15)
            Points.Add(new Point3D(-gcodeRead.EntitiesG1[index14].Vertice[index15].X, -gcodeRead.EntitiesG1[index14].Vertice[index15].Y, Job.Material.Size.Depth - buShapeFreeLines.Depth));
          if (Points.Count >= 2)
          {
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
            clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
            buShapeFreeLines.entityWireframe.Add((Entity) new LinearPath((ICollection<Point3D>) Points));
          }
        }
        clsVar5.shapeCreatePar.Solid = true;
        clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
        clsVar5.shapeCreatePar.SingX = -1.0;
        clsVar5.shapeCreatePar.SingY = -1.0;
        buShape Shape = (buShape) buShapeFreeLines;
        clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
        Job.Items.Add(Shape);
        flag1 = false;
        flag2 = false;
      }
      if (flag1)
        stringList.Add(StringList[index1]);
      if (StringList[index1].IndexOf("M50") >= 0 | StringList[index1].IndexOf("M51") >= 0 | StringList[index1].IndexOf("M52") >= 0 | StringList[index1].IndexOf("M54") >= 0 | StringList[index1].IndexOf("M55") >= 0)
      {
        stringList.Clear();
        flag1 = true;
        flag2 = false;
      }
      if (StringList[index1].IndexOf("M53") >= 0)
      {
        stringList.Clear();
        flag1 = true;
        flag2 = true;
      }
    }
    double MaterialZeroYPos = 0.0;
    bool flag5 = false;
    if (clsDrill.varDrillRunSettings.CabinetMirrorIfSlotClamperSide)
    {
      bool flag6 = false;
      bool flag7 = false;
      bool flag8 = false;
      for (int index = 0; index <= Job.Items.Count - 1; ++index)
      {
        if (Job.Items[index] is buShapeCut)
        {
          buShapeCut buShapeCut = Job.Items[index] as buShapeCut;
          if (buShapeCut.BasePoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth)
            flag7 = true;
          if (buShapeCut.BasePoint.Y > Job.Material.Size.Height - clsDrill.varDrillCNCSettings.ClamperCatchWidth)
            flag8 = true;
        }
        if (Job.Items[index] is buShapeFreeLines)
          flag6 = true;
      }
      if (flag7 & !flag8 & !flag6)
        flag5 = true;
    }
    if (flag5 & !Preview)
      this.MirrorOperation(ref Job);
    this.FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
    if (this.ClamperEntity != null)
      clsInit.cDrill.CreateClamperEntities((Entity) this.ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
    if (Preview)
      return;
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(Job);
    clsItem.FrmMain.Text = buFile5.getFileName(Filename);
  }

  public void OpenCynClyFile(string Filename, ref DrillJob Job, bool Preview = false)
  {
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(Filename);
    foreach (XmlNode childNode1 in xmlDocument.DocumentElement.ChildNodes)
    {
      if (childNode1.Name == "Panels")
      {
        foreach (XmlNode childNode2 in childNode1.ChildNodes)
        {
          if (childNode2.Name == "Panel")
          {
            Job = new DrillJob();
            foreach (XmlNode childNode3 in childNode2.ChildNodes)
            {
              string name = childNode3.Name;
              if (name == "Name")
                Job.Name = childNode3.FirstChild.Value;
              if (name == "Width" && (childNode3.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                Job.Material.Size.Width = double.Parse(childNode3.FirstChild.Value.ToString());
              if (name == "Height" && (childNode3.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                Job.Material.Size.Height = double.Parse(childNode3.FirstChild.Value.ToString());
              if (name == "Thickness" && (childNode3.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
              {
                Job.Material.Size.Depth = double.Parse(childNode3.FirstChild.Value.ToString());
                Entity entity = (Entity) null;
                clsInit.cVector5.CreateMaterialEntities(Job.Material, ref entity);
                clsInit.cVector5.Move(-Job.Material.Size.Width, -Job.Material.Size.Height, 0.0, ref entity);
                Job.Material.Entities.Add(entity);
                Job.panelEntity = entity;
              }
              if (name == "Details")
              {
                foreach (XmlNode childNode4 in childNode3.ChildNodes)
                {
                  foreach (XmlNode childNode5 in childNode4.ChildNodes)
                  {
                    if (childNode5.Name.Length > 0)
                    {
                      buShape shape = (buShape) null;
                      this.GetCynCltShapeType(childNode5, ref Job, ref shape);
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
    double MaterialZeroYPos = 0.0;
    this.FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
    if (this.ClamperEntity != null)
      clsInit.cDrill.CreateClamperEntities((Entity) this.ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
    if (Preview)
      return;
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(Job);
    clsItem.FrmMain.Text = buFile5.getFileName(Filename);
  }

  public void GetCynCltShapeType(XmlNode Child, ref DrillJob Job, ref buShape shape)
  {
    if (Child != null)
    {
      string str = "";
      int Face = -1;
      double num1 = 0.0;
      double num2 = 0.0;
      Point3D point3D1 = (Point3D) null;
      Point3D point3D2 = (Point3D) null;
      Point3D point3D3 = (Point3D) null;
      if (Child.Name == "Circle")
      {
        if ((Child.ChildNodes == null ? 0 : (Child.ChildNodes.Count > 0 ? 1 : 0)) != 0)
        {
          foreach (XmlNode childNode in Child.ChildNodes)
          {
            string name = childNode.Name;
            if (name == "Face" && (childNode.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
              Face = int.Parse(childNode.FirstChild.Value);
            if (name == "FeatureType" && childNode.FirstChild.Value != null)
              str = childNode.FirstChild.Value.ToString();
            if (name == "Depth" && (childNode.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
              num1 = double.Parse(childNode.FirstChild.Value);
            if (name == "Side" && childNode.FirstChild.Value != null)
              childNode.FirstChild.Value.ToString();
            if (name == "Diameter" && (childNode.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
              num2 = double.Parse(childNode.FirstChild.Value);
            if (name == "Center" && (childNode.Attributes == null ? 0 : (childNode.Attributes.Count > 0 ? 1 : 0)) != 0)
            {
              point3D1 = new Point3D();
              for (int i = 0; i <= childNode.Attributes.Count - 1; ++i)
              {
                XmlAttribute attribute = childNode.Attributes[i];
                if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                  point3D1.X = double.Parse(attribute.FirstChild.Value);
                if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                  point3D1.Y = double.Parse(attribute.FirstChild.Value);
              }
            }
          }
          if (Face >= 0 & str.Length > 0 & point3D1 != (Point3D) null)
          {
            if (str == "Hole")
            {
              shape = (buShape) new buShapeHole();
              shape.planeName = this.GetCynCltFace(Face);
              ((buShapeHole) shape).Diameter = num2;
              shape.Depth = num1;
              ((buShapeHole) shape).DrillType = drillTypes.SingleHole;
            }
            if (shape.planeName == planeBoxNames.Top)
            {
              shape.BasePoint.X = point3D1.X;
              shape.BasePoint.Y = point3D1.Y;
              shape.BasePoint.Z = Job.Material.Size.Depth;
            }
            if (shape.planeName == planeBoxNames.Right)
            {
              shape.BasePoint.X = 0.0;
              shape.BasePoint.Y = Job.Material.Size.Height - point3D1.X;
              shape.BasePoint.Z = point3D1.Y;
            }
            if (shape.planeName == planeBoxNames.Left)
            {
              shape.BasePoint.X = Job.Material.Size.Width;
              shape.BasePoint.Y = point3D1.X;
              shape.BasePoint.Z = point3D1.Y;
            }
            if (shape.planeName == planeBoxNames.Front)
            {
              shape.BasePoint.X = Job.Material.Size.Width - point3D1.X;
              shape.BasePoint.Y = Job.Material.Size.Height;
              shape.BasePoint.Z = point3D1.Y;
            }
            if (shape.planeName == planeBoxNames.Back)
            {
              shape.BasePoint.X = point3D1.X;
              shape.BasePoint.Y = 0.0;
              shape.BasePoint.Z = point3D1.Y;
            }
            shape.planeOperation = clsInit.cVector5.PlaneNameToPlane(shape.planeName);
            shape.Corner = CornerLocation.RightTop;
            shape.Alignment = ObjectAlignment.MiddleCenter;
            clsVar5.shapeCreatePar.Solid = true;
            clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
            clsVar5.shapeCreatePar.SingX = -1.0;
            clsVar5.shapeCreatePar.SingY = -1.0;
            clsInit.cVector5.CreatebuShape(ref shape, clsVar5.shapeCreatePar);
            Job.Items.Add(shape);
          }
        }
        else
          shape = (buShape) null;
      }
      if (Child.Name == "Rectangle")
      {
        if ((Child.ChildNodes == null ? 0 : (Child.ChildNodes.Count > 0 ? 1 : 0)) != 0)
        {
          foreach (XmlNode childNode in Child.ChildNodes)
          {
            string name = childNode.Name;
            if (name == "Face" && (childNode.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
              Face = int.Parse(childNode.FirstChild.Value);
            if (name == "FlipAxis" && childNode.FirstChild.Value != null)
              childNode.FirstChild.Value.ToString();
            if (name == "FeatureType" && childNode.FirstChild.Value != null)
              str = childNode.FirstChild.Value.ToString();
            if (name == "Direction" && childNode.FirstChild.Value != null)
              childNode.FirstChild.Value.ToString();
            if (name == "Side" && childNode.FirstChild.Value != null)
              childNode.FirstChild.Value.ToString();
            if (name == "Depth" && (childNode.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
              num1 = double.Parse(childNode.FirstChild.Value);
            if (name == "Diameter" && (childNode.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
              double.Parse(childNode.FirstChild.Value);
            if (name == "Start" && (childNode.Attributes == null ? 0 : (childNode.Attributes.Count > 0 ? 1 : 0)) != 0)
            {
              point3D2 = new Point3D();
              for (int i = 0; i <= childNode.Attributes.Count - 1; ++i)
              {
                XmlAttribute attribute = childNode.Attributes[i];
                if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                  point3D2.X = double.Parse(attribute.FirstChild.Value);
                if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                  point3D2.Y = double.Parse(attribute.FirstChild.Value);
              }
            }
            if (name == "End" && (childNode.Attributes == null ? 0 : (childNode.Attributes.Count > 0 ? 1 : 0)) != 0)
            {
              point3D3 = new Point3D();
              for (int i = 0; i <= childNode.Attributes.Count - 1; ++i)
              {
                XmlAttribute attribute = childNode.Attributes[i];
                if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                  point3D3.X = double.Parse(attribute.FirstChild.Value);
                if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                  point3D3.Y = double.Parse(attribute.FirstChild.Value);
              }
            }
          }
          if (Face >= 0 & str.Length > 0 & point3D2 != (Point3D) null & point3D3 != (Point3D) null)
          {
            if (str == "BladeCut")
            {
              shape = (buShape) new buShapeCut();
              shape.planeName = this.GetCynCltFace(Face);
              shape.Depth = num1;
              ((buShapeCut) shape).Length = Math.Abs(point3D2.X - point3D3.X);
              if (point3D3.X < point3D2.X)
                point3D2.X = point3D3.X;
              ((buShapeCut) shape).Diameter = Math.Abs(point3D2.Y - point3D3.Y);
              ((buShapeCut) shape).isMilling = true;
              point3D2.Y = (point3D2.Y + point3D3.Y) / 2.0;
              for (int index = 0; index <= ccVars.Tools[0].Tools.Count - 1; ++index)
              {
                if (buCompare5.EQ(ccVars.Tools[0].Tools[index].Geometry.Diameter, ((buShapeCut) shape).Diameter, 0.1))
                  shape.Tool = new ToolBase5(ccVars.Tools[0].Tools[index]);
              }
              if (shape.Tool == null)
                buString5.MessageBoxError($"{buLangTranslate.preDef.Error} - {buLangTranslate.preDef.Tool}");
            }
            if (str == "Contour" | str == "Pocket")
            {
              shape = (buShape) new buShapeRectangle();
              shape.planeName = this.GetCynCltFace(Face);
              shape.Depth = num1;
              ((buShapeRectangle) shape).Width = Math.Abs(point3D2.X - point3D3.X);
              ((buShapeRectangle) shape).Height = Math.Abs(point3D2.Y - point3D3.Y);
              if (str == "Pocket")
                shape.isPocket = true;
              if (point3D3.X < point3D2.X)
                point3D2.X = point3D3.X;
              point3D2.Y = (point3D2.Y + point3D3.Y) / 2.0;
              point3D2.X = (point3D2.X + point3D3.X) / 2.0;
              shape.Tool = new ToolBase5(ccVars.Tools[0].Tools[0]);
            }
            if (shape != null)
            {
              if (shape.planeName == planeBoxNames.Top)
              {
                shape.BasePoint.X = point3D2.X;
                shape.BasePoint.Y = point3D2.Y;
                shape.BasePoint.Z = Job.Material.Size.Depth;
              }
              if (shape.planeName == planeBoxNames.Right)
              {
                shape.BasePoint.X = 0.0;
                shape.BasePoint.Y = point3D2.X;
                shape.BasePoint.Z = point3D2.Y;
              }
              if (shape.planeName == planeBoxNames.Left)
              {
                shape.BasePoint.X = Job.Material.Size.Width;
                shape.BasePoint.Y = point3D2.X;
                shape.BasePoint.Z = point3D2.Y;
              }
              if (shape.planeName == planeBoxNames.Front)
              {
                shape.BasePoint.X = point3D2.X;
                shape.BasePoint.Y = Job.Material.Size.Height;
                shape.BasePoint.Z = point3D2.Y;
              }
              if (shape.planeName == planeBoxNames.Back)
              {
                shape.BasePoint.X = point3D2.X;
                shape.BasePoint.Y = 0.0;
                shape.BasePoint.Z = point3D2.Y;
              }
              shape.planeOperation = clsInit.cVector5.PlaneNameToPlane(shape.planeName);
              shape.Corner = CornerLocation.RightTop;
              shape.Alignment = ObjectAlignment.MiddleCenter;
              clsVar5.shapeCreatePar.Solid = true;
              clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
              clsVar5.shapeCreatePar.SingX = -1.0;
              clsVar5.shapeCreatePar.SingY = -1.0;
              clsInit.cVector5.CreatebuShape(ref shape, clsVar5.shapeCreatePar);
              Job.Items.Add(shape);
            }
            else
              buString5.MessageBoxError($"{buLangTranslate.preDef.Error} - {Child.Name} - {str}");
          }
        }
        else
          shape = (buShape) null;
      }
      if (!(Child.Name == "Polyline"))
        return;
      List<buEntity> refEntities = new List<buEntity>();
      if ((Child.ChildNodes == null ? 0 : (Child.ChildNodes.Count > 0 ? 1 : 0)) != 0)
      {
        foreach (XmlNode childNode1 in Child.ChildNodes)
        {
          string name1 = childNode1.Name;
          if (name1 == "Face" && (childNode1.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode1.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
            Face = int.Parse(childNode1.FirstChild.Value);
          if (name1 == "FlipAxis" && childNode1.FirstChild.Value != null)
            childNode1.FirstChild.Value.ToString();
          if (name1 == "FeatureType" && childNode1.FirstChild.Value != null)
            str = childNode1.FirstChild.Value.ToString();
          if (name1 == "Side" && childNode1.FirstChild.Value != null)
            childNode1.FirstChild.Value.ToString();
          if (name1 == "Depth" && (childNode1.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(childNode1.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
            num1 = double.Parse(childNode1.FirstChild.Value);
          if (name1 == "Elements")
          {
            foreach (XmlNode childNode2 in childNode1.ChildNodes)
            {
              string name2 = childNode2.Name;
              if (name2 == "Line")
              {
                Point3D start = (Point3D) null;
                Point3D end = (Point3D) null;
                foreach (XmlNode childNode3 in childNode2.ChildNodes)
                {
                  string name3 = childNode3.Name;
                  if (name3 == "Start" && (childNode3.Attributes == null ? 0 : (childNode3.Attributes.Count > 0 ? 1 : 0)) != 0)
                  {
                    start = new Point3D();
                    for (int i = 0; i <= childNode3.Attributes.Count - 1; ++i)
                    {
                      XmlAttribute attribute = childNode3.Attributes[i];
                      if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        start.X = double.Parse(attribute.FirstChild.Value);
                      if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        start.Y = double.Parse(attribute.FirstChild.Value);
                    }
                  }
                  if (name3 == "End" && (childNode3.Attributes == null ? 0 : (childNode3.Attributes.Count > 0 ? 1 : 0)) != 0)
                  {
                    end = new Point3D();
                    for (int i = 0; i <= childNode3.Attributes.Count - 1; ++i)
                    {
                      XmlAttribute attribute = childNode3.Attributes[i];
                      if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        end.X = double.Parse(attribute.FirstChild.Value);
                      if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        end.Y = double.Parse(attribute.FirstChild.Value);
                    }
                  }
                  if (start != (Point3D) null & end != (Point3D) null)
                  {
                    buLine buLine = new buLine(start, end);
                    refEntities.Add((buEntity) buLine);
                  }
                }
              }
              if (name2 == "Arc")
              {
                Point3D first = (Point3D) null;
                Point3D second = (Point3D) null;
                Point3D third = (Point3D) null;
                foreach (XmlNode childNode4 in childNode2.ChildNodes)
                {
                  string name4 = childNode4.Name;
                  if (name4 == "Start" && (childNode4.Attributes == null ? 0 : (childNode4.Attributes.Count > 0 ? 1 : 0)) != 0)
                  {
                    first = new Point3D();
                    for (int i = 0; i <= childNode4.Attributes.Count - 1; ++i)
                    {
                      XmlAttribute attribute = childNode4.Attributes[i];
                      if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        first.X = double.Parse(attribute.FirstChild.Value);
                      if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        first.Y = double.Parse(attribute.FirstChild.Value);
                    }
                  }
                  if (name4 == "Mid" && (childNode4.Attributes == null ? 0 : (childNode4.Attributes.Count > 0 ? 1 : 0)) != 0)
                  {
                    second = new Point3D();
                    for (int i = 0; i <= childNode4.Attributes.Count - 1; ++i)
                    {
                      XmlAttribute attribute = childNode4.Attributes[i];
                      if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        second.X = double.Parse(attribute.FirstChild.Value);
                      if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        second.Y = double.Parse(attribute.FirstChild.Value);
                    }
                  }
                  if (name4 == "End" && (childNode4.Attributes == null ? 0 : (childNode4.Attributes.Count > 0 ? 1 : 0)) != 0)
                  {
                    third = new Point3D();
                    for (int i = 0; i <= childNode4.Attributes.Count - 1; ++i)
                    {
                      XmlAttribute attribute = childNode4.Attributes[i];
                      if (attribute.Name == "X" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        third.X = double.Parse(attribute.FirstChild.Value);
                      if (attribute.Name == "Y" && (attribute.FirstChild.Value == null ? 0 : (buNumeric5.IsNumeric(attribute.FirstChild.Value.ToString()) ? 1 : 0)) != 0)
                        third.Y = double.Parse(attribute.FirstChild.Value);
                    }
                  }
                  if (first != (Point3D) null & third != (Point3D) null & second != (Point3D) null)
                  {
                    buArc buArc = new buArc(Plane.XY, (Point2D) first, (Point2D) second, (Point2D) third, false);
                    refEntities.Add((buEntity) buArc);
                  }
                }
              }
            }
          }
        }
        if (!(Face >= 0 & str.Length > 0 & refEntities.Count > 0))
          return;
        if (str == "Contour" | str == "Pocket")
        {
          shape = (buShape) new buShapeFreeDraw();
          shape.planeName = this.GetCynCltFace(Face);
          shape.Depth = num1;
          if (clsVar5.shapeCreatePar.entitiesCurve == null)
            clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
          clsVar5.shapeCreatePar.entitiesCurve.Clear();
          buEntity.Copy(refEntities, ref clsVar5.shapeCreatePar.entitiesCurve);
          if (str == "Pocket")
            shape.isPocket = true;
          clsInit.cVector5.BoxSizeCalculate(refEntities, ref shape.ItemSize.MinBox, ref shape.ItemSize.MaxBox);
          point3D2 = new Point3D(shape.ItemSize.MinBox.X, shape.ItemSize.MinBox.Y, shape.ItemSize.MinBox.Z);
          ((buShapeFreeDraw) shape).Width = shape.ItemSize.MaxBox.X - shape.ItemSize.MinBox.X;
          ((buShapeFreeDraw) shape).Height = shape.ItemSize.MaxBox.Y - shape.ItemSize.MinBox.Y;
          shape.Tool = new ToolBase5(ccVars.Tools[0].Tools[0]);
        }
        if (shape != null)
        {
          if (shape.planeName == planeBoxNames.Top)
          {
            shape.BasePoint.X = point3D2.X;
            shape.BasePoint.Y = point3D2.Y;
            shape.BasePoint.Z = Job.Material.Size.Depth;
          }
          if (shape.planeName == planeBoxNames.Right)
          {
            shape.BasePoint.X = 0.0;
            shape.BasePoint.Y = point3D2.X;
            shape.BasePoint.Z = point3D2.Y;
          }
          if (shape.planeName == planeBoxNames.Left)
          {
            shape.BasePoint.X = Job.Material.Size.Width;
            shape.BasePoint.Y = point3D2.X;
            shape.BasePoint.Z = point3D2.Y;
          }
          if (shape.planeName == planeBoxNames.Front)
          {
            shape.BasePoint.X = point3D2.X;
            shape.BasePoint.Y = Job.Material.Size.Height;
            shape.BasePoint.Z = point3D2.Y;
          }
          if (shape.planeName == planeBoxNames.Back)
          {
            shape.BasePoint.X = point3D2.X;
            shape.BasePoint.Y = 0.0;
            shape.BasePoint.Z = point3D2.Y;
          }
          shape.planeOperation = clsInit.cVector5.PlaneNameToPlane(shape.planeName);
          shape.Corner = CornerLocation.RightTop;
          shape.Alignment = ObjectAlignment.TopRight;
          clsVar5.shapeCreatePar.Solid = true;
          clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
          clsVar5.shapeCreatePar.SingX = -1.0;
          clsVar5.shapeCreatePar.SingY = -1.0;
          clsInit.cVector5.CreatebuShape(ref shape, clsVar5.shapeCreatePar);
          Job.Items.Add(shape);
        }
        else
          buString5.MessageBoxError($"{buLangTranslate.preDef.Error} - {Child.Name} - {str}");
      }
      else
        shape = (buShape) null;
    }
    else
      shape = (buShape) null;
  }

  public planeBoxNames GetCynCltFace(int Face)
  {
    planeBoxNames cynCltFace;
    switch (Face)
    {
      case 0:
        cynCltFace = planeBoxNames.Top;
        break;
      case 1:
        cynCltFace = planeBoxNames.Back;
        break;
      case 2:
        cynCltFace = planeBoxNames.Left;
        break;
      case 3:
        cynCltFace = planeBoxNames.Front;
        break;
      case 4:
        cynCltFace = planeBoxNames.Right;
        break;
      case 5:
        cynCltFace = planeBoxNames.Top;
        break;
      default:
        cynCltFace = planeBoxNames.Free;
        break;
    }
    return cynCltFace;
  }

  public void OpenCynclyJobListFile(List<string> Filenames, bool AutoFileArrived = false)
  {
    List<InfoCount> infoCountList = new List<InfoCount>();
    if (clsItem.FrmProgress == null)
      clsItem.FrmProgress = new F_ProgressCalculation();
    for (int index1 = 0; index1 <= Filenames.Count - 1; ++index1)
    {
      string filename = Filenames[index1];
      string withoutExtension1 = buFile5.getFileNameWithoutExtension(filename);
      string path = buFile5.GetPath(filename);
      DirectoryInfo directoryInfo1 = new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathExport);
      if (!directoryInfo1.Exists)
      {
        directoryInfo1 = new DirectoryInfo($"{path}\\{withoutExtension1}");
        if (directoryInfo1.Exists)
          directoryInfo1.Delete(true);
        directoryInfo1.Create();
      }
      else if (clsDrill.varDrillRunSettings.CabinetSubFolder)
      {
        directoryInfo1 = new DirectoryInfo($"{clsDrill.varDrillRunSettings.CabinetpathExport}\\{withoutExtension1}");
        if (!directoryInfo1.Exists)
          directoryInfo1.Create();
      }
      TreeNode node = (TreeNode) null;
      if (AutoFileArrived & this.FrmCabinetCycle.Visible)
        node = new TreeNode(withoutExtension1);
      CalculationEventArg e = new CalculationEventArg();
      clsItem.FrmProgress.Visible = true;
      FileInfo fileInfo = new FileInfo(filename);
      bool flag = true;
      if (fileInfo.Exists)
      {
        InfoCount infoCount = new InfoCount(1.0, filename);
        if (flag)
        {
          infoCountList.Add(infoCount);
          string withoutExtension2 = buFile5.getFileNameWithoutExtension(fileInfo.FullName);
          clsDrill.activeJob = new DrillJob();
          this.OpenCynClyFile(fileInfo.FullName, ref clsDrill.activeJob);
          this.cmdShowCode(true, $"{directoryInfo1.FullName}\\{withoutExtension2}");
        }
      }
      if (AutoFileArrived & fileInfo.Exists)
      {
        if (this.FrmCabinetCycle.Visible & node != null)
        {
          TreeNode treeNode = new TreeNode();
          node.Nodes.Add(filename.Trim() + " - ");
        }
        DirectoryInfo directoryInfo2 = new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathDeleted);
        if (directoryInfo2.Exists & clsDrill.varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
          buFile5.CopyFileToFolder(fileInfo.FullName, directoryInfo2.FullName);
        fileInfo.Delete();
      }
      e.ActiveProgressPercentage = 100.0 * (double) index1 / Convert.ToDouble(Filenames.Count - 1);
      e.OverallProgressPercentage = 100.0;
      e.Job = buLangTranslate.preDef.Calculating;
      clsInit.appCommand.CalculationInProgressCmd(e);
      clsItem.FrmProgress.Visible = false;
      if (AutoFileArrived & this.FrmCabinetCycle.Visible & node != null)
        this.FrmCabinetCycle.tree_files.Nodes.Add(node);
      if (infoCountList.Count > 0 & clsDrill.varDrillRunSettings.CabinetShowInfo & !AutoFileArrived)
      {
        DialogBoxList dialogBoxList = new DialogBoxList();
        List<string> StringList = new List<string>();
        for (int index2 = 0; index2 <= infoCountList.Count - 1; ++index2)
        {
          StringList.Add($"{infoCountList[index2].Info};{infoCountList[index2].Count.ToString("f0")}");
          dialogBoxList.Items.Add($"{buLangTranslate.preDef.FileName}: {infoCountList[index2].Info}  {buLangTranslate.preDef.Count}: {infoCountList[index2].Count.ToString("f0")}");
        }
        string FileName = directoryInfo1.FullName + "\\Info.txt";
        buFile5.SaveToFile(StringList, FileName);
        clsItem.FrmProgress.Visible = false;
        dialogBoxList.Caption = buLangTranslate.preDef.Job;
        dialogBoxList.Init();
        int num = (int) dialogBoxList.ShowDialog();
        clsItem.FrmProgress.Visible = false;
      }
    }
    this.timCabinetCycle.Enabled = true;
  }

  public void OpenCorpusFile(string Filename, ref DrillJob Job, bool Preview = false)
  {
    clsDrill.varDrillRunSettings.path3DJob = buFile5.GetPath(Filename);
    this.SaveDrillFile();
    List<Entity> EntityList = new List<Entity>();
    buFile5.OpenDxfDwg(ref EntityList, Filename, "");
    if (EntityList.Count > 0)
    {
      List<Entity> refEntities = new List<Entity>();
      for (int index = EntityList.Count - 1; index >= 0; --index)
      {
        if (EntityList[index].LayerName == "PLYTA")
        {
          refEntities.Add(EntityList[index]);
          EntityList.RemoveAt(index);
        }
      }
      if (refEntities.Count > 0)
      {
        Point3D MinPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        double num = Math.Abs(refEntities[0].AutodeskProperties.Thickness);
        clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
        Job = new DrillJob();
        Job.Material.Size.Width = MaxPoint.X - MinPoint.X;
        Job.Material.Size.Height = MaxPoint.Y - MinPoint.Y;
        Job.Material.Size.Depth = num;
        Entity entity = (Entity) null;
        clsInit.cVector5.CreateMaterialEntities(Job.Material, ref entity);
        clsInit.cVector5.Move(-Job.Material.Size.Width, -Job.Material.Size.Height, 0.0, ref entity);
        entity.Color = Color.FromArgb(150, entity.Color);
        Job.Material.Entities.Add(entity);
        Job.panelEntity = entity;
      }
      for (int index1 = 0; index1 <= EntityList.Count - 1; ++index1)
      {
        string[] strArray = EntityList[index1].LayerName.Split('_');
        if ((strArray == null ? 0 : (strArray.Length != 0 ? 1 : 0)) != 0)
        {
          if (EntityList[index1].BoxMax == (Point3D) null)
            EntityList[index1].Regen(0.1);
          double result1 = 0.0;
          double result2 = 0.0;
          for (int index2 = 1; index2 <= strArray.Length - 1; ++index2)
          {
            if (strArray[index2].IndexOf("DIAM") >= 0)
            {
              string s = strArray[index2].Trim().Replace("DIAM", "");
              if (buNumeric5.IsNumeric(s))
                double.TryParse(s, out result1);
            }
            if (strArray[index2].IndexOf("DIA") >= 0)
            {
              string s = strArray[index2].Trim().Replace("DIA", "");
              if (buNumeric5.IsNumeric(s))
                double.TryParse(s, out result1);
            }
            if (strArray[index2].IndexOf("DEPTH") >= 0)
            {
              string s = strArray[index2].Trim().Replace("DEPTH", "");
              if (buNumeric5.IsNumeric(s))
                double.TryParse(s, out result2);
            }
          }
          if (strArray[0] == "SAW")
          {
            if (result1 > 0.0)
            {
              buShapeCut buShapeCut = new buShapeCut();
              buShapeCut.planeName = planeBoxNames.Top;
              buShapeCut.Diameter = result1;
              buShapeCut.BasePoint.X = EntityList[index1].BoxMin.X;
              buShapeCut.BasePoint.Y = (EntityList[index1].BoxMin.Y + EntityList[index1].BoxMax.Y) / 2.0;
              buShapeCut.BasePoint.Z = Job.Material.Size.Depth - result2;
              buShapeCut.Length = EntityList[index1].BoxMax.X - EntityList[index1].BoxMin.X;
              buShapeCut.Depth = result2;
              buShapeCut.Corner = CornerLocation.RightTop;
              buShapeCut.Alignment = ObjectAlignment.MiddleCenter;
              buShapeCut.isMilling = false;
              clsVar5.shapeCreatePar.Solid = true;
              clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
              clsVar5.shapeCreatePar.SingX = -1.0;
              clsVar5.shapeCreatePar.SingY = -1.0;
              buShape Shape = (buShape) buShapeCut;
              clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
              Job.Items.Add(Shape);
            }
          }
          else if (strArray[0] == "VERT")
          {
            if (EntityList[index1] is Circle & result1 > 0.0)
            {
              Circle circle = EntityList[index1] as Circle;
              buShapeHole buShapeHole = new buShapeHole();
              buShapeHole.isMilling = false;
              buShapeHole.planeName = planeBoxNames.Top;
              buShapeHole.Diameter = circle.Diameter;
              buShapeHole.Depth = result2;
              buShapeHole.BasePoint.X = circle.Center.X;
              buShapeHole.BasePoint.Y = circle.Center.Y;
              buShapeHole.BasePoint.Z = Job.Material.Size.Depth - result2;
              buShapeHole.Corner = CornerLocation.RightTop;
              buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
              buShapeHole.DrillType = drillTypes.SingleHole;
              buShapeHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole.planeName);
              clsVar5.shapeCreatePar.Solid = true;
              clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
              clsVar5.shapeCreatePar.SingX = -1.0;
              clsVar5.shapeCreatePar.SingY = -1.0;
              buShape Shape = (buShape) buShapeHole;
              clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
              Job.Items.Add(Shape);
            }
          }
          else if (strArray[0] == "HOR")
          {
            if (strArray[1] == "RIGHT")
            {
              if (EntityList[index1] is Circle & result1 > 0.0)
              {
                Circle circle = EntityList[index1] as Circle;
                buShapeHole buShapeHole = new buShapeHole();
                buShapeHole.isMilling = false;
                buShapeHole.planeName = planeBoxNames.Left;
                buShapeHole.Diameter = circle.Diameter;
                buShapeHole.Depth = result2;
                buShapeHole.BasePoint.X = Job.Material.Size.Width;
                buShapeHole.BasePoint.Y = circle.Center.Y;
                buShapeHole.BasePoint.Z = Math.Abs(circle.Center.Z);
                buShapeHole.Corner = CornerLocation.RightBottom;
                buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
                buShapeHole.DrillType = drillTypes.SingleHole;
                buShapeHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole.planeName);
                clsVar5.shapeCreatePar.Solid = true;
                clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                clsVar5.shapeCreatePar.SingX = -1.0;
                clsVar5.shapeCreatePar.SingY = -1.0;
                buShape Shape = (buShape) buShapeHole;
                clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                Job.Items.Add(Shape);
              }
            }
            else if (strArray[1] == "LEFT")
            {
              if (EntityList[index1] is Circle & result1 > 0.0)
              {
                Circle circle = EntityList[index1] as Circle;
                buShapeHole buShapeHole = new buShapeHole();
                buShapeHole.isMilling = false;
                buShapeHole.planeName = planeBoxNames.Right;
                buShapeHole.Diameter = circle.Diameter;
                buShapeHole.Depth = result2;
                buShapeHole.BasePoint.X = 0.0;
                buShapeHole.BasePoint.Y = circle.Center.Y;
                buShapeHole.BasePoint.Z = Math.Abs(circle.Center.Z);
                buShapeHole.Corner = CornerLocation.RightTop;
                buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
                buShapeHole.DrillType = drillTypes.SingleHole;
                buShapeHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole.planeName);
                clsVar5.shapeCreatePar.Solid = true;
                clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                clsVar5.shapeCreatePar.SingX = -1.0;
                clsVar5.shapeCreatePar.SingY = -1.0;
                buShape Shape = (buShape) buShapeHole;
                clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                Job.Items.Add(Shape);
              }
            }
            else if (strArray[1] == "FRONT")
            {
              if (EntityList[index1] is Circle & result1 > 0.0)
              {
                Circle circle = EntityList[index1] as Circle;
                buShapeHole buShapeHole = new buShapeHole();
                buShapeHole.isMilling = false;
                buShapeHole.planeName = planeBoxNames.Front;
                buShapeHole.Diameter = circle.Diameter;
                buShapeHole.Depth = result2;
                buShapeHole.BasePoint.X = circle.Center.X;
                buShapeHole.BasePoint.Y = Job.Material.Size.Height;
                buShapeHole.BasePoint.Z = Math.Abs(circle.Center.Z);
                buShapeHole.Corner = CornerLocation.RightTop;
                buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
                buShapeHole.DrillType = drillTypes.SingleHole;
                buShapeHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole.planeName);
                clsVar5.shapeCreatePar.Solid = true;
                clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                clsVar5.shapeCreatePar.SingX = -1.0;
                clsVar5.shapeCreatePar.SingY = -1.0;
                buShape Shape = (buShape) buShapeHole;
                clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                Job.Items.Add(Shape);
              }
            }
            else if (strArray[1] == "BACK" | strArray[1] == "REAR" && EntityList[index1] is Circle & result1 > 0.0)
            {
              Circle circle = EntityList[index1] as Circle;
              buShapeHole buShapeHole = new buShapeHole();
              buShapeHole.isMilling = false;
              buShapeHole.planeName = planeBoxNames.Back;
              buShapeHole.Diameter = circle.Diameter;
              buShapeHole.Depth = result2;
              buShapeHole.BasePoint.X = circle.Center.X;
              buShapeHole.BasePoint.Y = 0.0;
              buShapeHole.BasePoint.Z = Math.Abs(circle.Center.Z);
              buShapeHole.Corner = CornerLocation.RightTop;
              buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
              buShapeHole.DrillType = drillTypes.SingleHole;
              buShapeHole.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole.planeName);
              clsVar5.shapeCreatePar.Solid = true;
              clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
              clsVar5.shapeCreatePar.SingX = -1.0;
              clsVar5.shapeCreatePar.SingY = -1.0;
              buShape Shape = (buShape) buShapeHole;
              clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
              Job.Items.Add(Shape);
            }
          }
          else if (strArray[0] == "MILLING" | strArray[0] == "FREZOWANIE" | strArray[0] == "DRAW")
          {
            int result3 = -1;
            if (strArray[1].IndexOf("NARZ") >= 0)
            {
              string s = strArray[1].Replace("NARZ", "");
              if (buNumeric5.IsNumeric(s))
                int.TryParse(s, out result3);
            }
            if (strArray[1].IndexOf("TOOL") >= 0)
            {
              string s = strArray[1].Replace("TOOL", "").Replace("T", "");
              if (buNumeric5.IsNumeric(s))
                int.TryParse(s, out result3);
            }
            if (strArray[2].IndexOf("SRED") >= 0)
            {
              string s = strArray[2].Replace("SRED", "");
              if (buNumeric5.IsNumeric(s))
                double.TryParse(s, out result1);
            }
            if (strArray[2].IndexOf("DIA") >= 0)
            {
              string s = strArray[2].Replace("DIA", "");
              if (buNumeric5.IsNumeric(s))
                double.TryParse(s, out result1);
            }
            if (strArray[2].IndexOf("GLEB") >= 0)
            {
              string s = strArray[2].Replace("GLEB", "");
              if (buNumeric5.IsNumeric(s))
                double.TryParse(s, out result2);
            }
            if (strArray[3].IndexOf("DEPTH") >= 0)
            {
              string s = strArray[3].Replace("DEPTH", "");
              if (buNumeric5.IsNumeric(s))
                double.TryParse(s, out result2);
            }
            if (strArray[3].IndexOf("KOREKCJA") >= 0)
            {
              string s = strArray[3].Replace("KOREKCJA", "");
              if (buNumeric5.IsNumeric(s))
              {
                int result4 = 0;
                int.TryParse(s, out result4);
                if (result4 == 0)
                  ;
                if (result4 == 1)
                  ;
                if (result4 == 2)
                  ;
              }
            }
            if (EntityList[index1] is LinearPath & EntityList[index1].Vertices.Length == 2 | EntityList[index1] is devDept.Eyeshot.Entities.Line)
            {
              if (result1 > 0.0)
              {
                double num = 0.0;
                double x;
                double y;
                if (buCompare5.EQ(EntityList[index1].Vertices[0].X, EntityList[index1].Vertices[1].X))
                {
                  if (EntityList[index1].Vertices[0].Y < EntityList[index1].Vertices[1].Y)
                  {
                    x = EntityList[index1].Vertices[0].X;
                    y = EntityList[index1].Vertices[0].Y;
                  }
                  else
                  {
                    x = EntityList[index1].Vertices[1].X;
                    y = EntityList[index1].Vertices[1].Y;
                  }
                }
                else if (buCompare5.EQ(EntityList[index1].Vertices[0].Y, EntityList[index1].Vertices[1].Y))
                {
                  if (EntityList[index1].Vertices[0].X < EntityList[index1].Vertices[1].X)
                  {
                    x = EntityList[index1].Vertices[0].X;
                    y = EntityList[index1].Vertices[0].Y;
                  }
                  else
                  {
                    x = EntityList[index1].Vertices[1].X;
                    y = EntityList[index1].Vertices[1].Y;
                  }
                }
                else
                {
                  x = EntityList[index1].Vertices[0].X;
                  y = EntityList[index1].Vertices[0].Y;
                  num = clsInit.cVector5.PointAngle(EntityList[index1].Vertices[1], EntityList[index1].Vertices[0]);
                }
                buShapeCut buShapeCut = new buShapeCut();
                buShapeCut.planeName = planeBoxNames.Top;
                buShapeCut.isMilling = true;
                buShapeCut.Diameter = result1;
                buShapeCut.BasePoint.X = x;
                buShapeCut.BasePoint.Y = y;
                buShapeCut.BasePoint.Z = Job.Material.Size.Depth - result2;
                buShapeCut.Length = clsInit.cVector5.Length3D(EntityList[index1].Vertices[0], EntityList[index1].Vertices[1]);
                buShapeCut.Angle = num;
                buShapeCut.Corner = CornerLocation.RightTop;
                buShapeCut.Alignment = ObjectAlignment.MiddleCenter;
                clsVar5.shapeCreatePar.Solid = true;
                clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
                clsVar5.shapeCreatePar.SingX = -1.0;
                clsVar5.shapeCreatePar.SingY = -1.0;
                buShape Shape = (buShape) buShapeCut;
                clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                for (int index3 = 0; index3 <= ccVars.Tools.Count - 1; ++index3)
                {
                  for (int index4 = 0; index4 <= ccVars.Tools[index3].Tools.Count - 1; ++index4)
                  {
                    if (ccVars.Tools[index3].Tools[index4].Geometry.Diameter == buShapeCut.Diameter)
                      buShapeCut.Tool = new ToolBase5(ccVars.Tools[index3].Tools[index4]);
                  }
                }
                Job.Items.Add(Shape);
              }
            }
            else if (EntityList[index1] is LinearPath)
            {
              buShapeFreeLines buShapeFreeLines = new buShapeFreeLines();
              for (int index5 = 0; index5 <= ccVars.Tools.Count - 1; ++index5)
              {
                for (int index6 = 0; index6 <= ccVars.Tools[index5].Tools.Count - 1; ++index6)
                {
                  if (ccVars.Tools[index5].Tools[index6].Geometry.Diameter == result1)
                  {
                    buShapeFreeLines.Tool = new ToolBase5(ccVars.Tools[index5].Tools[index6]);
                    buShapeFreeLines.SpindleSpeed = buShapeFreeLines.Tool.CamData.SpindleSpeed;
                    buShapeFreeLines.feedCutting = buShapeFreeLines.Tool.CamData.FeedSpeed;
                    buShapeFreeLines.feedPlunge = buShapeFreeLines.Tool.CamData.PlungeSpeed;
                  }
                }
              }
              if (buShapeFreeLines.Tool == null)
              {
                buShapeFreeLines.InfoMessages = new List<string>();
                buShapeFreeLines.InfoMessages.Add(buLangTranslate.preSentences.OperationToolIsNotInToolList);
              }
              Entity copiedEntity = (Entity) null;
              buEntity.Copy(EntityList[index1], ref copiedEntity);
              buShapeFreeLines.entityWireframe = new List<Entity>();
              List<Point3D> points1 = new List<Point3D>();
              for (int index7 = 0; index7 <= EntityList[index1].Vertices.Length - 1; ++index7)
                points1.Add(new Point3D(EntityList[index1].Vertices[index7].X, EntityList[index1].Vertices[index7].Y, Job.Material.Size.Depth - result2));
              if (points1.Count > 0)
              {
                LinearPath linearPath = new LinearPath((ICollection<Point3D>) points1);
                buShapeFreeLines.entityWireframe.Add((Entity) linearPath);
              }
              Point3D MinPoint = new Point3D();
              Point3D MidPoint = new Point3D();
              Point3D MaxPoint = new Point3D();
              clsInit.cVector5.BoxSizeCalculate(buShapeFreeLines.entityWireframe, ref MinPoint, ref MidPoint, ref MaxPoint);
              if (MaxPoint.Y - MinPoint.Y <= 0.1 && buShapeFreeLines.Tool != null)
              {
                MaxPoint.Y += buShapeFreeLines.Tool.Geometry.Diameter / 2.0;
                MinPoint.Y -= buShapeFreeLines.Tool.Geometry.Diameter / 2.0;
              }
              buShapeFreeLines.Depth = result2;
              buShapeFreeLines.BasePoint = new Point3D(MidPoint.X, MidPoint.Y, Job.Material.Size.Depth);
              buShapeFreeLines.ShapeGroup = ShapeGroup.Shape;
              buShapeFreeLines.ShapeType = ShapeTypes.FreeLines;
              buShapeFreeLines.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeFreeLines.planeName);
              buShapeFreeLines.Corner = CornerLocation.RightTop;
              buShapeFreeLines.Alignment = ObjectAlignment.MiddleCenter;
              buShapeFreeLines.planeName = planeBoxNames.Top;
              buShapeFreeLines.Width = MaxPoint.X - MinPoint.X;
              buShapeFreeLines.Height = MaxPoint.Y - MinPoint.Y;
              List<Point3D> points2 = new List<Point3D>();
              for (int index8 = 0; index8 <= EntityList[index1].Vertices.Length - 1; ++index8)
                points2.Add(new Point3D(-EntityList[index1].Vertices[index8].X, -EntityList[index1].Vertices[index8].Y, Job.Material.Size.Depth - result2));
              buShapeFreeLines.entityWireframe = new List<Entity>();
              if (points2.Count > 0)
              {
                LinearPath linearPath = new LinearPath((ICollection<Point3D>) points2);
                buShapeFreeLines.entityWireframe.Add((Entity) linearPath);
              }
              clsVar5.shapeCreatePar.Solid = true;
              clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
              clsVar5.shapeCreatePar.SingX = -1.0;
              clsVar5.shapeCreatePar.SingY = -1.0;
              buShape Shape = (buShape) buShapeFreeLines;
              clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
              Job.Items.Add(Shape);
            }
          }
        }
      }
    }
    double MaterialZeroYPos = 0.0;
    bool flag1 = false;
    if (clsDrill.varDrillRunSettings.CabinetMirrorIfSlotClamperSide)
    {
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      for (int index = 0; index <= Job.Items.Count - 1; ++index)
      {
        if (Job.Items[index] is buShapeCut)
        {
          buShapeCut buShapeCut = Job.Items[index] as buShapeCut;
          if (buShapeCut.BasePoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth)
            flag3 = true;
          if (buShapeCut.BasePoint.Y > Job.Material.Size.Height - clsDrill.varDrillCNCSettings.ClamperCatchWidth)
            flag4 = true;
        }
        if (Job.Items[index] is buShapeFreeLines)
          flag2 = true;
      }
      if (flag3 & !flag4 & !flag2)
        flag1 = true;
    }
    if (flag1 & !Preview)
      this.MirrorOperation(ref Job);
    this.FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
    if (this.ClamperEntity != null)
      clsInit.cDrill.CreateClamperEntities((Entity) this.ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
    if (Preview)
      return;
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(Job);
    clsItem.FrmMain.Text = buFile5.getFileName(Filename);
  }

  public void OpenCorpusJobListFile(List<string> Filenames, bool AutoFileArrived = false)
  {
    List<InfoCount> infoCountList = new List<InfoCount>();
    if (clsItem.FrmProgress == null)
      clsItem.FrmProgress = new F_ProgressCalculation();
    for (int index1 = 0; index1 <= Filenames.Count - 1; ++index1)
    {
      string filename = Filenames[index1];
      string withoutExtension1 = buFile5.getFileNameWithoutExtension(filename);
      string path = buFile5.GetPath(filename);
      DirectoryInfo directoryInfo1 = new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathExport);
      if (!directoryInfo1.Exists)
      {
        directoryInfo1 = new DirectoryInfo($"{path}\\{withoutExtension1}");
        if (directoryInfo1.Exists)
          directoryInfo1.Delete(true);
        directoryInfo1.Create();
      }
      else if (clsDrill.varDrillRunSettings.CabinetSubFolder)
      {
        directoryInfo1 = new DirectoryInfo($"{clsDrill.varDrillRunSettings.CabinetpathExport}\\{withoutExtension1}");
        if (!directoryInfo1.Exists)
          directoryInfo1.Create();
      }
      TreeNode node = (TreeNode) null;
      if (AutoFileArrived & this.FrmCabinetCycle.Visible)
        node = new TreeNode(withoutExtension1);
      CalculationEventArg e = new CalculationEventArg();
      clsItem.FrmProgress.Visible = true;
      FileInfo fileInfo = new FileInfo(filename);
      bool flag = true;
      if (fileInfo.Exists)
      {
        InfoCount infoCount = new InfoCount(1.0, filename);
        if (flag)
        {
          infoCountList.Add(infoCount);
          string withoutExtension2 = buFile5.getFileNameWithoutExtension(fileInfo.FullName);
          clsDrill.activeJob = new DrillJob();
          this.OpenCorpusFile(fileInfo.FullName, ref clsDrill.activeJob);
          this.cmdShowCode(true, $"{directoryInfo1.FullName}\\{withoutExtension2}");
        }
      }
      if (AutoFileArrived & fileInfo.Exists)
      {
        if (this.FrmCabinetCycle.Visible & node != null)
        {
          TreeNode treeNode = new TreeNode();
          node.Nodes.Add(filename.Trim() + " - ");
        }
        DirectoryInfo directoryInfo2 = new DirectoryInfo(clsDrill.varDrillRunSettings.CabinetpathDeleted);
        if (directoryInfo2.Exists & clsDrill.varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
          buFile5.CopyFileToFolder(fileInfo.FullName, directoryInfo2.FullName);
        fileInfo.Delete();
      }
      e.ActiveProgressPercentage = 100.0 * (double) index1 / Convert.ToDouble(Filenames.Count - 1);
      e.OverallProgressPercentage = 100.0;
      e.Job = buLangTranslate.preDef.Calculating;
      clsInit.appCommand.CalculationInProgressCmd(e);
      clsItem.FrmProgress.Visible = false;
      if (AutoFileArrived & this.FrmCabinetCycle.Visible & node != null)
        this.FrmCabinetCycle.tree_files.Nodes.Add(node);
      if (infoCountList.Count > 0 & clsDrill.varDrillRunSettings.CabinetShowInfo & !AutoFileArrived)
      {
        DialogBoxList dialogBoxList = new DialogBoxList();
        List<string> StringList = new List<string>();
        for (int index2 = 0; index2 <= infoCountList.Count - 1; ++index2)
        {
          StringList.Add($"{infoCountList[index2].Info};{infoCountList[index2].Count.ToString("f0")}");
          dialogBoxList.Items.Add($"{buLangTranslate.preDef.FileName}: {infoCountList[index2].Info}  {buLangTranslate.preDef.Count}: {infoCountList[index2].Count.ToString("f0")}");
        }
        string FileName = directoryInfo1.FullName + "\\Info.txt";
        buFile5.SaveToFile(StringList, FileName);
        clsItem.FrmProgress.Visible = false;
        dialogBoxList.Caption = buLangTranslate.preDef.Job;
        dialogBoxList.Init();
        int num = (int) dialogBoxList.ShowDialog();
        clsItem.FrmProgress.Visible = false;
      }
    }
    this.timCabinetCycle.Enabled = true;
  }

  public void SetPreviewImage()
  {
    clsItem.ModelOpenPreview.Invalidate();
    clsItem.ModelOpenPreview.Entities.RegenAllCurved(0.01);
    clsItem.ModelOpenPreview.SetView(buConversion5.buViewTypeToEyeViewType(this.openDialogCtrlPreview.ViewType), true, false);
    clsItem.ModelOpenPreview.ZoomFit(5);
    clsItem.ModelOpenPreview.Invalidate();
    clsItem.ModelOpenPreview.CopyToClipboardRaster(new Size(this.openDialogCtrlPreview.picture_preview.Width, this.openDialogCtrlPreview.picture_preview.Height));
    this.openDialogCtrlPreview.DrawPreviewImage(Clipboard.GetImage());
    this.openDialogCtrlPreview.ShowLoading(false);
    clsVar.PreviewLoaded = true;
  }

  public List<DrillItem> SortByXDistance(
    List<DrillItem> lst,
    DrillItem refPoint,
    SortDirection Direction)
  {
    List<DrillItem> drillItemList = new List<DrillItem>();
    if (lst.Count > 0)
    {
      drillItemList.Add(lst[this.NearestXPoint(new DrillItem(refPoint), lst)]);
      lst.Remove(drillItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillItemList.Add(lst[this.NearestXPoint(drillItemList[drillItemList.Count - 1], lst)]);
        lst.Remove(drillItemList[drillItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillItemList.Reverse();
    }
    return drillItemList;
  }

  public int NearestXPoint(DrillItem srcPt, List<DrillItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.Center.X - lookIn[index].Center.X;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillItem> SortByXOffsetedDistance(
    List<DrillItem> lst,
    DrillItem refPoint,
    SortDirection Direction)
  {
    List<DrillItem> drillItemList = new List<DrillItem>();
    if (lst.Count > 0)
    {
      drillItemList.Add(lst[this.NearestXOffsetedPoint(new DrillItem(refPoint), lst)]);
      lst.Remove(drillItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillItemList.Add(lst[this.NearestXOffsetedPoint(drillItemList[drillItemList.Count - 1], lst)]);
        lst.Remove(drillItemList[drillItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillItemList.Reverse();
    }
    return drillItemList;
  }

  public int NearestXOffsetedPoint(DrillItem srcPt, List<DrillItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.OffsetedPoint.X - lookIn[index].OffsetedPoint.X;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillItem> SortByYDistance(
    List<DrillItem> lst,
    DrillItem refPoint,
    SortDirection Direction)
  {
    List<DrillItem> drillItemList = new List<DrillItem>();
    drillItemList.Add(lst[this.NearestYPoint(new DrillItem(refPoint), lst)]);
    lst.Remove(drillItemList[0]);
    int num = 0;
    for (int index = 0; index < lst.Count + num; ++index)
    {
      drillItemList.Add(lst[this.NearestYPoint(drillItemList[drillItemList.Count - 1], lst)]);
      lst.Remove(drillItemList[drillItemList.Count - 1]);
      ++num;
    }
    if (Direction == SortDirection.LowerToBigger)
      drillItemList.Reverse();
    return drillItemList;
  }

  public int NearestYPoint(DrillItem srcPt, List<DrillItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.Center.Y - lookIn[index].Center.Y;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillItem> SortByZDistance(
    List<DrillItem> lst,
    DrillItem refPoint,
    SortDirection Direction)
  {
    List<DrillItem> drillItemList = new List<DrillItem>();
    if (lst.Count > 0)
    {
      drillItemList.Add(lst[this.NearestZPoint(new DrillItem(refPoint), lst)]);
      lst.Remove(drillItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillItemList.Add(lst[this.NearestZPoint(drillItemList[drillItemList.Count - 1], lst)]);
        lst.Remove(drillItemList[drillItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillItemList.Reverse();
    }
    return drillItemList;
  }

  public int NearestZPoint(DrillItem srcPt, List<DrillItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.Center.Z - lookIn[index].Center.Z;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillCalcItem> SortByXDistance(
    List<DrillCalcItem> lst,
    DrillCalcItem refPoint,
    SortDirection Direction)
  {
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    if (lst.Count > 0)
    {
      drillCalcItemList.Add(lst[this.NearestXPoint(new DrillCalcItem(refPoint), lst)]);
      lst.Remove(drillCalcItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillCalcItemList.Add(lst[this.NearestXPoint(drillCalcItemList[drillCalcItemList.Count - 1], lst)]);
        lst.Remove(drillCalcItemList[drillCalcItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillCalcItemList.Reverse();
    }
    return drillCalcItemList;
  }

  public int NearestXPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.Center.X - lookIn[index].Center.X;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillCalcItem> SortByXOffsetedDistance(
    List<DrillCalcItem> lst,
    DrillCalcItem refPoint,
    SortDirection Direction)
  {
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    if (lst.Count > 0)
    {
      drillCalcItemList.Add(lst[this.NearestXOffsetedPoint(new DrillCalcItem(refPoint), lst)]);
      lst.Remove(drillCalcItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillCalcItemList.Add(lst[this.NearestXOffsetedPoint(drillCalcItemList[drillCalcItemList.Count - 1], lst)]);
        lst.Remove(drillCalcItemList[drillCalcItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillCalcItemList.Reverse();
    }
    return drillCalcItemList;
  }

  public int NearestXOffsetedPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.OffsetedPoint.X - lookIn[index].OffsetedPoint.X;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillFound> SortByXOffsetedDistanceDrillFound(
    List<DrillFound> lst,
    DrillCalcItem refPoint,
    SortDirection Direction)
  {
    List<DrillFound> drillFoundList = new List<DrillFound>();
    if (lst.Count > 0)
    {
      drillFoundList.Add(lst[this.NearestXOffsetedPointDrillFound(new DrillCalcItem(refPoint), lst)]);
      lst.Remove(drillFoundList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillFoundList.Add(lst[this.NearestXOffsetedPointDrillFound(drillFoundList[drillFoundList.Count - 1].Items[0], lst)]);
        lst.Remove(drillFoundList[drillFoundList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillFoundList.Reverse();
    }
    return drillFoundList;
  }

  public int NearestXOffsetedPointDrillFound(DrillCalcItem srcPt, List<DrillFound> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.OffsetedPoint.X - lookIn[index].Items[0].OffsetedPoint.X;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillItem> SortShapeByXDistance(
    List<DrillItem> lst,
    DrillItem refPoint,
    SortDirection Direction)
  {
    List<DrillItem> drillItemList = new List<DrillItem>();
    if (lst.Count > 0)
    {
      drillItemList.Add(lst[this.NearestShapeXPoint(new DrillItem(refPoint), lst)]);
      lst.Remove(drillItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillItemList.Add(lst[this.NearestShapeXPoint(drillItemList[drillItemList.Count - 1], lst)]);
        lst.Remove(drillItemList[drillItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillItemList.Reverse();
    }
    return drillItemList;
  }

  public int NearestShapeXPoint(DrillItem srcPt, List<DrillItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.BoxMinItem.X - lookIn[index].BoxMinItem.X;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillCalcItem> SortByYDistance(
    List<DrillCalcItem> lst,
    DrillCalcItem refPoint,
    SortDirection Direction)
  {
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    if (lst.Count > 0)
    {
      drillCalcItemList.Add(lst[this.NearestYPoint(new DrillCalcItem(refPoint), lst)]);
      lst.Remove(drillCalcItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillCalcItemList.Add(lst[this.NearestYPoint(drillCalcItemList[drillCalcItemList.Count - 1], lst)]);
        lst.Remove(drillCalcItemList[drillCalcItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillCalcItemList.Reverse();
    }
    return drillCalcItemList;
  }

  public int NearestYPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.Center.Y - lookIn[index].Center.Y;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public List<DrillCalcItem> SortByZDistance(
    List<DrillCalcItem> lst,
    DrillCalcItem refPoint,
    SortDirection Direction)
  {
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    if (lst.Count > 0)
    {
      drillCalcItemList.Add(lst[this.NearestZPoint(new DrillCalcItem(refPoint), lst)]);
      lst.Remove(drillCalcItemList[0]);
      int num = 0;
      for (int index = 0; index < lst.Count + num; ++index)
      {
        drillCalcItemList.Add(lst[this.NearestZPoint(drillCalcItemList[drillCalcItemList.Count - 1], lst)]);
        lst.Remove(drillCalcItemList[drillCalcItemList.Count - 1]);
        ++num;
      }
      if (Direction == SortDirection.LowerToBigger)
        drillCalcItemList.Reverse();
    }
    return drillCalcItemList;
  }

  public int NearestZPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
  {
    KeyValuePair<double, int> keyValuePair = new KeyValuePair<double, int>();
    for (int index = 0; index < lookIn.Count; ++index)
    {
      double key = srcPt.Center.Z - lookIn[index].Center.Z;
      if (index == 0)
        keyValuePair = new KeyValuePair<double, int>(key, index);
      else if (key < keyValuePair.Key)
        keyValuePair = new KeyValuePair<double, int>(key, index);
    }
    return keyValuePair.Value;
  }

  public void SortJobItems(ref DrillJob Job)
  {
    List<List<DrillCalcItem>> drillCalcItemListList = new List<List<DrillCalcItem>>();
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    if (Job == null)
      return;
    Job.ItemCalc = this.SortByXDistance(Job.ItemCalc, new DrillCalcItem(), SortDirection.LowerToBigger);
    for (int index = 0; index <= Job.ItemCalc.Count - 1; ++index)
    {
      Job.ItemCalc[index].NumberNextHorizontalItem = 0;
      Job.ItemCalc[index].NumberNextVerticalItem = 0;
      if (drillCalcItemList.Count == 0)
        drillCalcItemList.Add(new DrillCalcItem(Job.ItemCalc[index]));
      else if (buCompare5.EQ(drillCalcItemList[drillCalcItemList.Count - 1].Center.X, Job.ItemCalc[index].Center.X, 0.01))
      {
        drillCalcItemList.Add(Job.ItemCalc[index]);
      }
      else
      {
        drillCalcItemListList.Add(drillCalcItemList);
        drillCalcItemList = new List<DrillCalcItem>();
        drillCalcItemList.Add(Job.ItemCalc[index]);
      }
    }
    if (drillCalcItemList.Count > 0)
      drillCalcItemListList.Add(drillCalcItemList);
    for (int index = 0; index <= drillCalcItemListList.Count - 1; ++index)
      drillCalcItemListList[index] = this.SortByYDistance(drillCalcItemListList[index], new DrillCalcItem(), SortDirection.LowerToBigger);
    List<double> doubleList1 = new List<double>()
    {
      32.0,
      64.0,
      96.0,
      128.0,
      160.0
    };
    List<double> doubleList2 = new List<double>()
    {
      32.0,
      64.0,
      128.0,
      160.0,
      192.0
    };
    for (int index1 = 0; index1 <= drillCalcItemListList.Count - 1; ++index1)
    {
      if (drillCalcItemListList[index1].Count >= 2)
      {
        for (int index2 = 0; index2 <= drillCalcItemListList[index1].Count - 2; ++index2)
        {
          for (int index3 = index2 + 1; index3 <= drillCalcItemListList[index1].Count - 1; ++index3)
          {
            double num = drillCalcItemListList[index1][index3].Center.Y - drillCalcItemListList[index1][index2].Center.Y;
            for (int index4 = 0; index4 <= doubleList1.Count - 1; ++index4)
            {
              if (buCompare5.EQ(num, doubleList1[index4], 0.05))
              {
                ++drillCalcItemListList[index1][index2].NumberNextHorizontalItem;
                int Index = -1;
                this.GetIndexFromItemID(drillCalcItemListList[index1][index2].ID, Job.ItemCalc, ref Index);
                if (Index >= 0)
                  Job.ItemCalc[Index].NumberNextHorizontalItem = drillCalcItemListList[index1][index2].NumberNextHorizontalItem;
                index4 = doubleList1.Count;
              }
            }
          }
        }
      }
      for (int index5 = 0; index5 <= drillCalcItemListList[index1].Count - 1; ++index5)
      {
        for (int index6 = 0; index6 <= Job.ItemCalc.Count - 1; ++index6)
        {
          if (Job.ItemCalc[index6].NumberNextHorizontalItem == 0 && buCompare5.EQ(drillCalcItemListList[index1][index5].Center.Y, Job.ItemCalc[index6].Center.Y, 0.05) & drillCalcItemListList[index1][index5].planeName == Job.ItemCalc[index6].planeName)
          {
            double num = Job.ItemCalc[index6].Center.X - drillCalcItemListList[index1][index5].Center.X;
            for (int index7 = 0; index7 <= doubleList2.Count - 1; ++index7)
            {
              if (buCompare5.EQ(num, doubleList2[index7], 0.05))
              {
                ++drillCalcItemListList[index1][index5].NumberNextVerticalItem;
                int Index = -1;
                this.GetIndexFromItemID(drillCalcItemListList[index1][index5].ID, Job.ItemCalc, ref Index);
                if (Index >= 0)
                  Job.ItemCalc[Index].NumberNextVerticalItem = drillCalcItemListList[index1][index5].NumberNextVerticalItem;
                index7 = doubleList2.Count;
              }
            }
          }
        }
      }
    }
  }

  public void JobShapeToItemCalc(ref DrillJob Job)
  {
    if (Job == null)
      return;
    Job.ItemCalc.Clear();
    for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
    {
      if (Job.Items[index1] is buShapeHole)
      {
        buShapeHole buShapeHole1 = Job.Items[index1] as buShapeHole;
        if (buShapeHole1.Enable)
        {
          if (buShapeHole1.planeName == planeBoxNames.Back)
            Job.isClamperSideDrillOpAvailable = true;
          if (buShapeHole1.DrillType == drillTypes.SingleHole)
          {
            if (!buShapeHole1.isMilling)
            {
              Job.ItemCalc.Add(new DrillCalcItem(buShapeHole1));
              Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
              if (Job.Items[index1].BasePoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
                Job.isClamperSideDrillOpAvailable = true;
              ++this.IDCounter;
            }
            else
            {
              DrillItem drillItem = new DrillItem((buShapeHole) Job.Items[index1]);
              Job.ItemCalc.Add(new DrillCalcItem(drillItem));
            }
          }
          if (buShapeHole1.DrillType == drillTypes.HorizontalHoles | buShapeHole1.DrillType == drillTypes.HorizontalLineHoles | buShapeHole1.DrillType == drillTypes.VerticalHoles | buShapeHole1.DrillType == drillTypes.VerticalLineHoles | buShapeHole1.DrillType == drillTypes.InclineHoles)
          {
            if (!buShapeHole1.isMilling)
            {
              for (int index2 = 0; index2 <= buShapeHole1.multiCenter.Count - 1; ++index2)
              {
                buShapeHole buShapeHole2 = new buShapeHole(buShapeHole1.Diameter, buShapeHole1.Depth);
                buShapeHole2.CalculatedPoint = new Point3D(buShapeHole1.multiCenter[index2].Center.X, buShapeHole1.multiCenter[index2].Center.Y, buShapeHole1.multiCenter[index2].Center.Z);
                buShapeHole2.planeName = buShapeHole1.planeName;
                buShapeHole2.ID = this.IDCounter;
                Job.ItemCalc.Add(new DrillCalcItem(buShapeHole2));
                Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
                if (Math.Abs(buShapeHole1.multiCenter[index2].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
                  Job.isClamperSideDrillOpAvailable = true;
                ++this.IDCounter;
              }
            }
            else
            {
              for (int index3 = 0; index3 <= buShapeHole1.multiCenter.Count - 1; ++index3)
              {
                buShapeHole buShapeHole3 = new buShapeHole(buShapeHole1.Diameter, buShapeHole1.Depth);
                buShapeHole3.CalculatedPoint = new Point3D(buShapeHole1.multiCenter[index3].Center.X, buShapeHole1.multiCenter[index3].Center.Y, buShapeHole1.multiCenter[index3].Center.Z);
                buShapeHole3.ItemSize.MinBox = new Point3D(buShapeHole1.multiCenter[index3].Center.X - buShapeHole1.Diameter / 2.0, buShapeHole1.multiCenter[index3].Center.Y - buShapeHole1.Diameter / 2.0);
                buShapeHole3.ItemSize.MaxBox = new Point3D(buShapeHole1.multiCenter[index3].Center.X + buShapeHole1.Diameter / 2.0, buShapeHole1.multiCenter[index3].Center.Y + buShapeHole1.Diameter / 2.0);
                buShapeHole3.planeName = buShapeHole1.planeName;
                Job.ItemCalc.Add(new DrillCalcItem(buShapeHole3));
              }
            }
          }
          if (buShapeHole1.DrillType == drillTypes.ThreeHole)
          {
            buShapeHole3 buShapeHole3 = Job.Items[index1] as buShapeHole3;
            Point3D calcCenter1 = new Point3D();
            Point3D calcCenter2 = new Point3D();
            clsInit.cVector5.calcBuShapeHole3Point(buShapeHole3.CalculatedPoint, buShapeHole3.planeName, buShapeHole3.DistanceX, buShapeHole3.DistanceY, buShapeHole3.DiameterOutside, buShapeHole3.Hole3Angle, ref calcCenter1, ref calcCenter2);
            buShapeHole buShapeHole4 = new buShapeHole(buShapeHole3.Diameter, buShapeHole3.Depth);
            buShapeHole4.CalculatedPoint = new Point3D(buShapeHole1.CalculatedPoint.X, buShapeHole1.CalculatedPoint.Y, buShapeHole1.CalculatedPoint.Z);
            buShapeHole4.planeName = buShapeHole1.planeName;
            buShapeHole4.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole4));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole4.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
            buShapeHole buShapeHole5 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole5.CalculatedPoint = new Point3D(calcCenter1.X, calcCenter1.Y, calcCenter1.Z);
            buShapeHole5.planeName = buShapeHole1.planeName;
            buShapeHole5.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole5));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole5.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
            buShapeHole buShapeHole6 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole6.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter1.Z);
            buShapeHole6.planeName = buShapeHole1.planeName;
            buShapeHole6.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole6));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole6.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
          }
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Shape & Job.Items[index1].Enable)
        ;
    }
  }

  public bool FindFirstClamperPositionsFromFullJob(
    DrillJob Job,
    ref double MaterialZeroYPos,
    ref double X1,
    ref double X2,
    bool ReSort = true)
  {
    X1 = 0.0;
    X2 = 0.0;
    if (ReSort)
    {
      this.JobShapeToItemCalc(ref clsDrill.activeJob);
      this.SortJobItems(ref clsDrill.activeJob);
    }
    List<DrillCalcItem> drillCalcItemList = new List<DrillCalcItem>();
    double num1 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
    for (int index = 0; index <= Job.ItemCalc.Count - 1; ++index)
    {
      if (Job.ItemCalc[index].planeName == planeBoxNames.Left)
        drillCalcItemList.Add(new DrillCalcItem(Job.ItemCalc[index]));
      if (Job.ItemCalc[index].planeName == planeBoxNames.Top && Job.ItemCalc[index].Center.Y - Job.ItemCalc[index].Diameter / 2.0 < clsDrill.varDrillCNCSettings.ClamperCatchWidth)
        drillCalcItemList.Add(new DrillCalcItem(Job.ItemCalc[index]));
    }
    List<MinMidMaxRange> minMidMaxRangeList = new List<MinMidMaxRange>();
    for (int index = 0; index <= drillCalcItemList.Count - 1; ++index)
    {
      if (index == 0)
      {
        if (drillCalcItemList[index].Center.X + drillCalcItemList[index].Diameter / 2.0 > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
        {
          MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
          {
            Mid = drillCalcItemList[index].Center.X / 2.0,
            Min = 0.0,
            Max = drillCalcItemList[index].Center.X - drillCalcItemList[index].Diameter / 2.0
          };
          minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
          minMidMaxRangeList.Add(minMidMaxRange);
        }
      }
      else if (index == drillCalcItemList.Count - 1)
      {
        if (drillCalcItemList[index].Center.X - drillCalcItemList[index].Diameter / 2.0 - (drillCalcItemList[index - 1].Center.X + drillCalcItemList[index - 1].Diameter / 2.0) > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
        {
          MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
          {
            Mid = (drillCalcItemList[index].Center.X + drillCalcItemList[index - 1].Center.X) / 2.0,
            Min = drillCalcItemList[index - 1].Center.X + drillCalcItemList[index - 1].Diameter / 2.0,
            Max = drillCalcItemList[index].Center.X - drillCalcItemList[index].Diameter / 2.0
          };
          minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
          minMidMaxRangeList.Add(minMidMaxRange);
        }
        if (Job.Material.Size.Width - (drillCalcItemList[index].Center.X + drillCalcItemList[index].Diameter / 2.0) > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
        {
          MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
          {
            Mid = (drillCalcItemList[index].Center.X + Job.Material.Size.Width) / 2.0,
            Min = drillCalcItemList[index].Center.X + drillCalcItemList[index].Diameter / 2.0,
            Max = Job.Material.Size.Width
          };
          minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
          minMidMaxRangeList.Add(minMidMaxRange);
        }
      }
      else if (drillCalcItemList[index].Center.X - drillCalcItemList[index].Diameter / 2.0 - (drillCalcItemList[index - 1].Center.X + drillCalcItemList[index - 1].Diameter / 2.0) > clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance)
      {
        MinMidMaxRange minMidMaxRange = new MinMidMaxRange()
        {
          Mid = (drillCalcItemList[index].Center.X + drillCalcItemList[index - 1].Center.X) / 2.0,
          Min = drillCalcItemList[index - 1].Center.X + drillCalcItemList[index - 1].Diameter / 2.0,
          Max = drillCalcItemList[index].Center.X - drillCalcItemList[index].Diameter / 2.0
        };
        minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
        minMidMaxRangeList.Add(minMidMaxRange);
      }
    }
    double num2 = clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance;
    double num3 = 1.0;
    double num4 = 1.0;
    if (Job.Material.Size.Width < 500.0)
    {
      num3 = 0.3;
      num4 = 0.7;
    }
    if (Job.Material.Size.Width >= 500.0 & Job.Material.Size.Width < 600.0)
    {
      num3 = 0.32;
      num4 = 0.68;
    }
    if (Job.Material.Size.Width >= 600.0 & Job.Material.Size.Width < 750.0)
    {
      num3 = 0.35;
      num4 = 0.65;
    }
    if (Job.Material.Size.Width >= 750.0 & Job.Material.Size.Width < 1000.0)
    {
      num3 = 0.37;
      num4 = 0.63;
    }
    if (Job.Material.Size.Width >= 1000.0 & Job.Material.Size.Width < 1500.0)
    {
      num3 = 0.3;
      num4 = 0.75;
    }
    if (Job.Material.Size.Width >= 1500.0 & Job.Material.Size.Width < 2000.0)
    {
      num3 = 0.25;
      num4 = 0.7;
    }
    if (Job.Material.Size.Width >= 2000.0 & Job.Material.Size.Width < 2500.0)
    {
      num3 = 0.2;
      num4 = Math.Round((Math.Abs(clsDrill.varDrillMachineSettings.MachineMinXStroke) - num2) / Job.Material.Size.Width, 3) - 0.05;
    }
    if (Job.Material.Size.Width >= 2500.0)
    {
      num3 = 0.15;
      num4 = 0.5;
    }
    if (minMidMaxRangeList.Count == 1 && minMidMaxRangeList[0].Range > 2.0 * (clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperOperationMinDistance))
    {
      if (minMidMaxRangeList[0].Min + num2 < Job.Material.Size.Width * num3)
        X2 = -Math.Round(minMidMaxRangeList[0].Min + num2, 3);
      if (minMidMaxRangeList[0].Max - num2 > Job.Material.Size.Width * num4)
        X1 = -Math.Round(minMidMaxRangeList[0].Max - num2, 3);
    }
    if (minMidMaxRangeList.Count >= 2)
    {
      if (minMidMaxRangeList[0].Mid < Job.Material.Size.Width * num3)
        X2 = -Math.Round(minMidMaxRangeList[0].Mid, 3);
      else if (Job.Material.Size.Width * num3 >= minMidMaxRangeList[0].Min & Job.Material.Size.Width * num3 < minMidMaxRangeList[0].Max)
        X2 = -Math.Round(Job.Material.Size.Width * num3, 3);
      for (int index = minMidMaxRangeList.Count - 1; index >= 0; --index)
      {
        if (-Job.Material.Size.Width * num4 > clsDrill.varDrillMachineSettings.MachineMinXStroke)
        {
          if (-minMidMaxRangeList[index].Mid > clsDrill.varDrillMachineSettings.MachineMinXStroke & minMidMaxRangeList[index].Mid > Job.Material.Size.Width * num4)
          {
            if (minMidMaxRangeList[index].Mid > Job.Material.Size.Width * num4)
            {
              X1 = -Math.Round(minMidMaxRangeList[minMidMaxRangeList.Count - 1].Mid, 3);
              index = 0;
            }
          }
          else if (-(minMidMaxRangeList[index].Min + num2) > clsDrill.varDrillMachineSettings.MachineMinXStroke & minMidMaxRangeList[index].Min + num2 > Job.Material.Size.Width * num4)
          {
            X1 = -Math.Round(minMidMaxRangeList[index].Min + num2, 3);
            index = 0;
          }
          else if (-(minMidMaxRangeList[index].Max - num2) > clsDrill.varDrillMachineSettings.MachineMinXStroke & minMidMaxRangeList[index].Max - num2 > Job.Material.Size.Width * num4)
          {
            X1 = -Math.Round(minMidMaxRangeList[index].Max - num2, 3);
            index = 0;
          }
        }
        else if (-Job.Material.Size.Width * (num4 - 0.1) > clsDrill.varDrillMachineSettings.MachineMinXStroke && minMidMaxRangeList[minMidMaxRangeList.Count - 1].Mid > Job.Material.Size.Width * (num4 - 0.1))
          X1 = -Math.Round(minMidMaxRangeList[minMidMaxRangeList.Count - 1].Mid, 3);
      }
    }
    bool positionsFromFullJob;
    if (minMidMaxRangeList.Count > 0)
    {
      if (X1 == 0.0)
      {
        if (Job.Material.Size.Width > 3.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
        }
        else
        {
          double num5 = Job.Material.Size.Width - (2.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
          if (num5 > 0.0)
            num5 = 0.0;
          X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num5 / 2.0;
        }
      }
      if (X2 == 0.0)
      {
        if (Job.Material.Size.Width > 3.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          X2 = -(clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperLength / 4.0);
        }
        else
        {
          double num6 = 2.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - Job.Material.Size.Width;
          if (num6 < 0.0)
            num6 = 0.0;
          X2 = -(clsDrill.varDrillCNCSettings.ClamperLength / 2.0) + num6 / 2.0;
        }
      }
      if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
      {
        double num7 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (X2 - X1);
        if (num7 > 0.0)
        {
          X2 += num7 / 2.0;
          X1 -= num7 / 2.0;
        }
      }
      if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
        X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
      positionsFromFullJob = true;
    }
    else
    {
      MaterialZeroYPos = Job.Material.Size.Height / 2.0;
      if (MaterialZeroYPos < clsDrill.varDrillCNCSettings.MaterialZeroYMinPosition)
        MaterialZeroYPos = clsDrill.varDrillCNCSettings.MaterialZeroYMinPosition;
      if (MaterialZeroYPos > clsDrill.varDrillCNCSettings.MaterialZeroYMaxPosition)
        MaterialZeroYPos = clsDrill.varDrillCNCSettings.MaterialZeroYMaxPosition;
      if (Job.Material.Size.Width > 3.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
      {
        X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperLength / 2.0;
      }
      else
      {
        double num8 = Job.Material.Size.Width - (2.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance);
        X1 = -Job.Material.Size.Width + clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + num8 / 2.0;
      }
      if (Job.Material.Size.Width > 3.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
      {
        X2 = -(clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperLength / 3.0);
        if (Job.Material.Size.Width > 1500.0 & Job.Material.Size.Width <= 2000.0)
          X2 = -(2.0 * clsDrill.varDrillCNCSettings.ClamperLength);
        if (Job.Material.Size.Width > 2000.0)
          X2 = -(3.0 * clsDrill.varDrillCNCSettings.ClamperLength);
      }
      else
      {
        double num9 = 2.0 * clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - Job.Material.Size.Width;
        X2 = -(clsDrill.varDrillCNCSettings.ClamperLength / 2.0 + clsDrill.varDrillCNCSettings.ClamperLength / 4.0) + num9 / 2.0;
      }
      if (clsDrill.activeJob == null)
      {
        positionsFromFullJob = false;
      }
      else
      {
        if (clsDrill.activeJob.FirstClamperX != clsDrill.activeJob.SecondClamperX)
        {
          X2 = clsDrill.activeJob.SecondClamperX;
          X1 = clsDrill.activeJob.FirstClamperX;
        }
        if (X2 - X1 < clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance)
        {
          double num10 = clsDrill.varDrillCNCSettings.ClamperLength + clsDrill.varDrillCNCSettings.ClamperBetweenMinDistance - (X2 - X1);
          if (num10 > 0.0)
          {
            X2 += num10 / 2.0;
            X1 -= num10 / 2.0;
          }
        }
        if (X1 < clsDrill.varDrillMachineSettings.MachineMinXStroke)
          X1 = clsDrill.varDrillMachineSettings.MachineMinXStroke;
        positionsFromFullJob = true;
      }
    }
    return positionsFromFullJob;
  }

  public void doGeneralTick(int TickCount)
  {
  }

  public void doFindFastestPattern()
  {
    DrillCNCSettings data = new DrillCNCSettings(clsDrill.varDrillCNCSettings);
    DrillCNCSettings drillCncSettings = new DrillCNCSettings(clsDrill.varDrillCNCSettings);
    List<DrillItem> drillItemList = new List<DrillItem>();
    DrillJob drillJob = new DrillJob(clsDrill.activeJob);
    int num = 0;
    while (num <= 10)
      ++num;
    clsDrill.varDrillCNCSettings = new DrillCNCSettings(data);
  }

  public void doCalculateTime(ref double totTimeAsSec)
  {
    bool flag = false;
    totTimeAsSec = 0.0;
    for (int index = 0; index <= clsDrill.activeJob.Moves.Count - 1; ++index)
    {
      if (flag)
      {
        if (clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.AxisMove)
        {
          double num1 = 0.0;
          double Distance1 = Math.Abs(clsDrill.activeJob.Moves[index - 1].XPosition - clsDrill.activeJob.Moves[index].XPosition);
          double Distance2 = Math.Abs(clsDrill.activeJob.Moves[index - 1].X1Clamper - clsDrill.activeJob.Moves[index].X1Clamper);
          double Distance3 = Math.Abs(clsDrill.activeJob.Moves[index - 1].X2Clamper - clsDrill.activeJob.Moves[index].X2Clamper);
          double Distance4 = Math.Abs(clsDrill.activeJob.Moves[index - 1].Y1Position - clsDrill.activeJob.Moves[index].Y1Position);
          double Distance5 = Math.Abs(clsDrill.activeJob.Moves[index - 1].Y2Position - clsDrill.activeJob.Moves[index].Y2Position);
          double Distance6 = Math.Abs(clsDrill.activeJob.Moves[index - 1].Y3Position - clsDrill.activeJob.Moves[index].Y3Position);
          double Distance7 = Math.Abs(clsDrill.activeJob.Moves[index - 1].Z1Position - clsDrill.activeJob.Moves[index].Z1Position);
          double Distance8 = Math.Abs(clsDrill.activeJob.Moves[index - 1].Z2Position - clsDrill.activeJob.Moves[index].Z2Position);
          double Distance9 = Math.Abs(clsDrill.activeJob.Moves[index - 1].Z3Position - clsDrill.activeJob.Moves[index].Z3Position);
          if (Distance1 > 0.0)
            ;
          double num2 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.X1Velocity, Distance1, clsDrill.varDrillMachineSettings.X1AccDec, clsDrill.varDrillMachineSettings.X1AccDec);
          clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.X1Velocity, Distance2, clsDrill.varDrillMachineSettings.X1AccDec, clsDrill.varDrillMachineSettings.X1AccDec);
          clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.X2Velocity, Distance3, clsDrill.varDrillMachineSettings.X2AccDec, clsDrill.varDrillMachineSettings.X2AccDec);
          double num3 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.Y1Velocity, Distance4, clsDrill.varDrillMachineSettings.Y1AccDec, clsDrill.varDrillMachineSettings.Y1AccDec);
          double num4 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.Y2Velocity, Distance5, clsDrill.varDrillMachineSettings.Y2AccDec, clsDrill.varDrillMachineSettings.Y2AccDec);
          double num5 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.Y3Velocity, Distance6, clsDrill.varDrillMachineSettings.Y3AccDec, clsDrill.varDrillMachineSettings.Y3AccDec);
          double num6 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.Z1Velocity, Distance7, clsDrill.varDrillMachineSettings.Z1AccDec, clsDrill.varDrillMachineSettings.Z1AccDec);
          double num7 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.Z2Velocity, Distance8, clsDrill.varDrillMachineSettings.Z2AccDec, clsDrill.varDrillMachineSettings.Z2AccDec);
          double num8 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(clsDrill.varDrillMachineSettings.Z3Velocity, Distance9, clsDrill.varDrillMachineSettings.Z3AccDec, clsDrill.varDrillMachineSettings.Z3AccDec);
          if (num2 > num1)
            num1 = num2;
          if (num3 > num1)
            num1 = num3;
          if (num4 > num1)
            num1 = num4;
          if (num5 > num1)
            num1 = num5;
          if (num6 > num1)
            num1 = num6;
          if (num7 > num1)
            num1 = num7;
          if (num8 > num1)
            num1 = num8;
          if (num1 == 0.0)
          {
            if (clsDrill.activeJob.Moves[index].Command2 == DrillMoveCommand.SetPiston | clsDrill.activeJob.Moves[index].Command2 == DrillMoveCommand.SetPress)
              num1 = clsDrill.varDrillMachineSettings.ToolSetTime;
            if (clsDrill.activeJob.Moves[index].Command2 == DrillMoveCommand.ResetAll | clsDrill.activeJob.Moves[index].Command2 == DrillMoveCommand.ResetAllPress | clsDrill.activeJob.Moves[index].Command2 == DrillMoveCommand.ResetPiston | clsDrill.activeJob.Moves[index].Command2 == DrillMoveCommand.ResetPress)
              num1 = clsDrill.varDrillMachineSettings.ToolResetTime;
          }
          totTimeAsSec += num1;
        }
        if (clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.SetPiston)
          totTimeAsSec += clsDrill.varDrillMachineSettings.ToolSetTime;
        if (clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.SetPiston)
          totTimeAsSec += clsDrill.varDrillMachineSettings.ToolSetTime;
        if (clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.ResetAll | clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.ResetAllPress | clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.ResetPiston | clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.ResetPress)
          totTimeAsSec += clsDrill.varDrillMachineSettings.ToolResetTime;
        if (clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.AllClamperUp | clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.Clamper1Up | clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.Clamper2Up)
          totTimeAsSec += clsDrill.varDrillMachineSettings.ClamperUpTime;
        if (clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.AllClamperDown | clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.Clamper1Down | clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.Clamper2Down)
          totTimeAsSec += clsDrill.varDrillMachineSettings.ClamperUpTime;
      }
      if (clsDrill.activeJob.Moves[index].Command == DrillMoveCommand.Wait)
        flag = true;
    }
  }

  public void doDeletePanel(int JobIndex)
  {
    clsDrill.activeJob.Items.Clear();
    clsDrill.activeJob.ItemCalc.Clear();
    clsDrill.activeJob = (DrillJob) null;
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
  }

  public void doEditPanel(int JobIndex, MaterialBase5 mat)
  {
    if (clsDrill.activeJob == null)
      return;
    clsDrill.activeJob.Material = new MaterialBase5(mat);
    double MaterialZeroYPos = 0.0;
    if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
      this.cGoUltra2Up1Down.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
    if (this.MachType == DrillMachineType.GoWithAtc)
      this.cGoAtc.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
    if (this.MachType == DrillMachineType.Sirius)
      this.cGoSirius.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
    if (this.ClamperEntity != null)
      clsInit.cDrill.CreateClamperEntities((Entity) this.ClamperEntity, clsDrill.activeJob.FirstClamperX, clsDrill.activeJob.SecondClamperX, ref clsDrill.activeJob.FirstClamperEntity, ref clsDrill.activeJob.SecondClamperEntity, Color.Gray);
    this.shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
    clsVar5.shapeCreatePar.Size = new SizeObject(mat.Size);
    for (int index = 0; index <= clsDrill.activeJob.Items.Count - 1; ++index)
    {
      buShape Shape = buShape.Copy(clsDrill.activeJob.Items[index]);
      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
      clsDrill.activeJob.Items[index] = Shape;
    }
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
    clsVar5.ShapeDataParameters = new ShapeRuntimeData(this.shapeRuntimeData_0);
  }

  public void doDeleteOperation(int JobIndex, int OperationIndex, int OperationSubIndex)
  {
    if (JobIndex >= 0 & OperationIndex >= 0 & OperationIndex <= clsDrill.activeJob.Items.Count - 1 & OperationSubIndex == -1)
    {
      clsDrill.activeJob.Items.RemoveAt(OperationIndex);
      this.JobUpdate(true, (DrillItem) null);
      this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
    }
    else
    {
      if (!(JobIndex >= 0 & OperationIndex >= 0 & OperationIndex <= clsDrill.activeJob.Items.Count - 1 & OperationSubIndex >= 0))
        return;
      if (OperationSubIndex <= clsDrill.activeJob.Items[OperationIndex].multiCenter.Count - 1)
        clsDrill.activeJob.Items[OperationIndex].multiCenter.RemoveAt(OperationSubIndex);
      if (OperationSubIndex <= clsDrill.activeJob.Items[OperationIndex].entitySolid.Count - 1)
        clsDrill.activeJob.Items[OperationIndex].entitySolid.RemoveAt(OperationSubIndex);
      this.JobUpdate(true, (DrillItem) null);
      this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
    }
  }

  public void doDeletaAllOperations()
  {
    clsDrill.activeJob.Items.Clear();
    clsDrill.activeJob.ItemCalc.Clear();
    clsDrill.activeJob.Moves.Clear();
    clsDrill.activeJob.SimulationMoves.Clear();
    clsDrill.activeJob.Cams.Clear();
    clsDrill.activeJob.Codes.Clear();
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
  }

  public void doEditOperation()
  {
    if (!(this.selectedJobIndex >= 0 & this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1))
      return;
    this.OperationToParameter(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.ShapeDataParameters);
    this.shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
    if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup == ShapeGroup.Drill)
    {
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastDrill);
      this.EditOperation = true;
      this.cmdHolesMenu();
      this.EditOperation = true;
    }
    else if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup == ShapeGroup.Shape)
    {
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastShape);
      this.EditOperation = true;
      this.cmdDrawingsMenu();
      this.EditOperation = true;
    }
    else if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup == ShapeGroup.Cut)
    {
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastCut);
      this.EditOperation = true;
      this.cmdCutsMenu();
      this.EditOperation = true;
    }
    else
    {
      if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup != ShapeGroup.Profiling)
        return;
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastProfiling);
      this.EditOperation = true;
      this.cmdCornerMenu();
      this.EditOperation = true;
    }
  }

  public void doCopyOperation()
  {
    if (!(this.selectedJobIndex >= 0 & this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1))
      return;
    this.shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
    this.OperationToParameter(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.ShapeDataParameters);
    if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup == ShapeGroup.Drill)
    {
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastDrill);
      this.cmdHolesMenu();
    }
    else if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup == ShapeGroup.Shape)
    {
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastShape);
      this.cmdDrawingsMenu();
    }
    else if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup == ShapeGroup.Cut)
    {
      this.EditOperation = true;
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastCut);
      this.cmdCutsMenu();
    }
    else
    {
      if (clsDrill.activeJob.Items[this.selectedItemIndex].ShapeGroup != ShapeGroup.Profiling)
        return;
      this.EditOperation = true;
      buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.lastProfiling);
      this.cmdCornerMenu();
    }
  }

  public void doMirrorOperation()
  {
    if (!(this.selectedJobIndex >= 0 & this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1))
      return;
    F_MirrorOP fMirrorOp = new F_MirrorOP();
    fMirrorOp.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
    fMirrorOp.Shape = buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex]);
    fMirrorOp.CopyAsNew = clsDrill.varDrillRunSettings.MirrorCopyAsNew;
    fMirrorOp.MirrorType = clsDrill.varDrillRunSettings.MirrorType;
    fMirrorOp.Init();
    fMirrorOp.StartPosition = FormStartPosition.CenterParent;
    int num = (int) fMirrorOp.ShowDialog();
    if (fMirrorOp.PropertiesForm.Result != DialogResult.OK)
      return;
    this.shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
    clsDrill.varDrillRunSettings.MirrorType = fMirrorOp.MirrorType;
    clsDrill.varDrillRunSettings.MirrorCopyAsNew = fMirrorOp.CopyAsNew;
    this.OperationToParameter(clsDrill.activeJob.Items[this.selectedItemIndex], ref clsVar5.ShapeDataParameters);
    buShape Shape = buShape.Copy(clsDrill.activeJob.Items[this.selectedItemIndex]);
    if (clsDrill.varDrillRunSettings.MirrorType == MirrorBoxType.Plane)
    {
      Shape.planeName = fMirrorOp.newPlane;
      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
    }
    if (clsDrill.varDrillRunSettings.MirrorType == MirrorBoxType.Horizotal)
    {
      Shape.Corner = fMirrorOp.newCorner;
      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
    }
    if (clsDrill.varDrillRunSettings.MirrorType == MirrorBoxType.Vertical)
    {
      Shape.Corner = fMirrorOp.newCorner;
      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
    }
    if (clsDrill.varDrillRunSettings.MirrorCopyAsNew)
      clsDrill.activeJob.Items.Add(Shape);
    else
      clsDrill.activeJob.Items[this.selectedItemIndex] = Shape;
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
    clsVar5.ShapeDataParameters = new ShapeRuntimeData(this.shapeRuntimeData_0);
    this.shapeRuntimeData_0 = (ShapeRuntimeData) null;
  }

  public void doRotateOperation()
  {
    F_RotatePanel fRotatePanel = new F_RotatePanel();
    fRotatePanel.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
    fRotatePanel.ClockType = clsDrill.varDrillRunSettings.RotateClockType;
    fRotatePanel.Degree = clsDrill.varDrillRunSettings.RotateDegree;
    fRotatePanel.Init();
    fRotatePanel.StartPosition = FormStartPosition.CenterParent;
    int num = (int) fRotatePanel.ShowDialog();
    if (fRotatePanel.PropertiesForm.Result != DialogResult.OK)
      return;
    clsDrill.varDrillRunSettings.RotateClockType = fRotatePanel.ClockType;
    clsDrill.varDrillRunSettings.RotateDegree = fRotatePanel.Degree;
    if (clsDrill.varDrillRunSettings.RotateDegree == 90.0)
    {
      buNumeric5.ExchangeTwoVaues(ref clsDrill.activeJob.Material.Size.Width, ref clsDrill.activeJob.Material.Size.Height);
      clsDrill.activeJob.Material.Entities.Clear();
      Entity entity = (Entity) null;
      clsInit.cVector5.CreateMaterialEntities(clsDrill.activeJob.Material, ref entity);
      clsInit.cVector5.Move(-clsDrill.activeJob.Material.Size.Width, -clsDrill.activeJob.Material.Size.Height, 0.0, ref entity);
      clsDrill.activeJob.Material.Entities.Add(entity);
      clsDrill.activeJob.Material.Sing = new Point3D(clsVar5.shapeCreatePar.SingX, clsVar5.shapeCreatePar.SingY, 1.0);
      if (clsDrill.activeJob.Material.Entities.Count > 0)
        buEntity.Copy(clsDrill.activeJob.Material.Entities[0], ref clsDrill.activeJob.panelEntity);
      double MaterialZeroYPos = 0.0;
      if (this.MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
        this.cGoUltra2Up1Down.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
      if (this.MachType == DrillMachineType.GoWithAtc)
        this.cGoAtc.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
      if (this.MachType == DrillMachineType.Sirius)
        this.cGoSirius.FindFirstClamperPositions(clsDrill.activeJob, ref MaterialZeroYPos, ref clsDrill.activeJob.FirstClamperX, ref clsDrill.activeJob.SecondClamperX);
      if (this.ClamperEntity != null)
        clsInit.cDrill.CreateClamperEntities((Entity) this.ClamperEntity, clsDrill.activeJob.FirstClamperX, clsDrill.activeJob.SecondClamperX, ref clsDrill.activeJob.FirstClamperEntity, ref clsDrill.activeJob.SecondClamperEntity, Color.Gray);
    }
    if (clsDrill.activeJob.Items.Count <= 0)
      return;
    for (int index = 0; index <= clsDrill.activeJob.Items.Count - 1; ++index)
    {
      if (clsDrill.varDrillRunSettings.RotateDegree == 180.0)
      {
        buShape buShape = clsDrill.activeJob.Items[index];
        if (clsDrill.activeJob.Items[index].Corner == CornerLocation.RightTop)
          clsDrill.activeJob.Items[index].Corner = CornerLocation.LeftBottom;
        else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.RightBottom)
          clsDrill.activeJob.Items[index].Corner = CornerLocation.LeftTop;
        else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.LeftBottom)
          clsDrill.activeJob.Items[index].Corner = CornerLocation.RightTop;
        else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.LeftTop)
          clsDrill.activeJob.Items[index].Corner = CornerLocation.RightBottom;
        if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Front)
          clsDrill.activeJob.Items[index].planeName = planeBoxNames.Back;
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Back)
          clsDrill.activeJob.Items[index].planeName = planeBoxNames.Front;
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Left)
          clsDrill.activeJob.Items[index].planeName = planeBoxNames.Right;
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Right)
          clsDrill.activeJob.Items[index].planeName = planeBoxNames.Left;
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Top)
          clsDrill.activeJob.Items[index].planeName = planeBoxNames.Top;
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Bottom)
          clsDrill.activeJob.Items[index].planeName = planeBoxNames.Bottom;
      }
      else if (clsDrill.varDrillRunSettings.RotateDegree == 90.0)
      {
        bool flag1 = false;
        bool flag2;
        if (((clsDrill.activeJob.Items[index].planeName == planeBoxNames.Front ? 1 : 0) & 1) != 0)
        {
          buNumeric5.ExchangeTwoVaues(ref clsDrill.activeJob.Items[index].BasePoint.X, ref clsDrill.activeJob.Items[index].BasePoint.Y);
          if (clsDrill.varDrillRunSettings.RotateClockType == ClockDirectionType.CW)
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Left;
            clsDrill.activeJob.Items[index].planeOperation = Plane.YZ;
            clsInit.cDrill.ChangeCornerOpposite(ref clsDrill.activeJob.Items[index].Corner);
          }
          else
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Right;
            clsDrill.activeJob.Items[index].planeOperation = Plane.YZ;
          }
          flag2 = true;
        }
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Back & !flag1)
        {
          buNumeric5.ExchangeTwoVaues(ref clsDrill.activeJob.Items[index].BasePoint.X, ref clsDrill.activeJob.Items[index].BasePoint.Y);
          if (clsDrill.varDrillRunSettings.RotateClockType == ClockDirectionType.CW)
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Right;
            clsDrill.activeJob.Items[index].planeOperation = Plane.YZ;
            clsInit.cDrill.ChangeCornerOpposite(ref clsDrill.activeJob.Items[index].Corner);
          }
          else
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Left;
            clsDrill.activeJob.Items[index].planeOperation = Plane.YZ;
          }
          flag2 = true;
        }
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Left & !flag1)
        {
          buNumeric5.ExchangeTwoVaues(ref clsDrill.activeJob.Items[index].BasePoint.X, ref clsDrill.activeJob.Items[index].BasePoint.Y);
          if (clsDrill.varDrillRunSettings.RotateClockType == ClockDirectionType.CW)
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Back;
            clsDrill.activeJob.Items[index].planeOperation = Plane.XZ;
          }
          else
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Front;
            clsDrill.activeJob.Items[index].planeOperation = Plane.XZ;
            clsInit.cDrill.ChangeCornerOpposite(ref clsDrill.activeJob.Items[index].Corner);
          }
          flag2 = true;
        }
        else if (clsDrill.activeJob.Items[index].planeName == planeBoxNames.Right & !flag1)
        {
          buNumeric5.ExchangeTwoVaues(ref clsDrill.activeJob.Items[index].BasePoint.X, ref clsDrill.activeJob.Items[index].BasePoint.Y);
          if (clsDrill.varDrillRunSettings.RotateClockType == ClockDirectionType.CW)
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Front;
            clsDrill.activeJob.Items[index].planeOperation = Plane.XZ;
          }
          else
          {
            clsDrill.activeJob.Items[index].planeName = planeBoxNames.Back;
            clsDrill.activeJob.Items[index].planeOperation = Plane.XZ;
            clsInit.cDrill.ChangeCornerOpposite(ref clsDrill.activeJob.Items[index].Corner);
          }
          flag2 = true;
        }
        else if ((clsDrill.activeJob.Items[index].planeName == planeBoxNames.Top | clsDrill.activeJob.Items[index].planeName == planeBoxNames.Bottom) & !flag1)
        {
          buNumeric5.ExchangeTwoVaues(ref clsDrill.activeJob.Items[index].BasePoint.X, ref clsDrill.activeJob.Items[index].BasePoint.Y);
          if (clsDrill.activeJob.Items[index] is buShapeCut)
          {
            clsDrill.activeJob.Items[index].entityWireframe.Clear();
            clsDrill.activeJob.Items[index].entitiesDim.Clear();
            if (((buShapeCut) clsDrill.activeJob.Items[index]).CutType == CutTypes.CutHorizontal)
              ((buShapeCut) clsDrill.activeJob.Items[index]).CutType = CutTypes.CutVertical;
            else if (((buShapeCut) clsDrill.activeJob.Items[index]).CutType == CutTypes.CutHorizontalLine)
              ((buShapeCut) clsDrill.activeJob.Items[index]).CutType = CutTypes.CutVerticalLine;
            else if (((buShapeCut) clsDrill.activeJob.Items[index]).CutType == CutTypes.CutVertical)
              ((buShapeCut) clsDrill.activeJob.Items[index]).CutType = CutTypes.CutHorizontal;
            else if (((buShapeCut) clsDrill.activeJob.Items[index]).CutType == CutTypes.CutVerticalLine)
              ((buShapeCut) clsDrill.activeJob.Items[index]).CutType = CutTypes.CutHorizontalLine;
          }
          if (clsDrill.activeJob.Items[index] is buShapeHoleMulti)
          {
            if (((buShapeHole) clsDrill.activeJob.Items[index]).DrillType == drillTypes.HorizontalHoles)
              ((buShapeHole) clsDrill.activeJob.Items[index]).DrillType = drillTypes.VerticalHoles;
            else if (((buShapeHole) clsDrill.activeJob.Items[index]).DrillType == drillTypes.HorizontalLineHoles)
              ((buShapeHole) clsDrill.activeJob.Items[index]).DrillType = drillTypes.VerticalLineHoles;
            else if (((buShapeHole) clsDrill.activeJob.Items[index]).DrillType == drillTypes.VerticalHoles)
              ((buShapeHole) clsDrill.activeJob.Items[index]).DrillType = drillTypes.HorizontalHoles;
            else if (((buShapeHole) clsDrill.activeJob.Items[index]).DrillType == drillTypes.VerticalLineHoles)
              ((buShapeHole) clsDrill.activeJob.Items[index]).DrillType = drillTypes.HorizontalLineHoles;
          }
          if (clsDrill.varDrillRunSettings.RotateClockType == ClockDirectionType.CW)
          {
            if (clsDrill.activeJob.Items[index].Corner == CornerLocation.RightTop)
              clsDrill.activeJob.Items[index].Corner = CornerLocation.RightBottom;
            else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.RightBottom)
              clsDrill.activeJob.Items[index].Corner = CornerLocation.LeftBottom;
            else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.LeftBottom)
              clsDrill.activeJob.Items[index].Corner = CornerLocation.LeftTop;
            else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.LeftTop)
              clsDrill.activeJob.Items[index].Corner = CornerLocation.RightTop;
          }
          else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.RightTop)
            clsDrill.activeJob.Items[index].Corner = CornerLocation.LeftTop;
          else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.LeftTop)
            clsDrill.activeJob.Items[index].Corner = CornerLocation.LeftBottom;
          else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.LeftBottom)
            clsDrill.activeJob.Items[index].Corner = CornerLocation.RightBottom;
          else if (clsDrill.activeJob.Items[index].Corner == CornerLocation.RightBottom)
            clsDrill.activeJob.Items[index].Corner = CornerLocation.RightTop;
          flag2 = true;
        }
      }
      clsVar5.shapeCreatePar.Solid = true;
      clsVar5.shapeCreatePar.Size = new SizeObject(clsDrill.activeJob.Material.Size);
      clsVar5.shapeCreatePar.SingX = -1.0;
      clsVar5.shapeCreatePar.SingY = -1.0;
      buShape Shape = clsDrill.activeJob.Items[index];
      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
    }
    this.JobUpdate(true, (DrillItem) null);
    this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
  }

  public void doOperationMoveDown()
  {
    if (!(clsDrill.activeJob.Items.Count > 0 & this.selectedItemIndex >= 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 2))
      return;
    buShape buShape = clsDrill.activeJob.Items[this.selectedItemIndex];
    clsDrill.activeJob.Items.RemoveAt(this.selectedItemIndex);
    ++this.selectedItemIndex;
    clsDrill.activeJob.Items.Insert(this.selectedItemIndex, buShape);
    this.JobUpdate(true, (DrillItem) null);
  }

  public void doOperationMoveUp()
  {
    if (!(clsDrill.activeJob.Items.Count >= 0 & this.selectedItemIndex > 0 & this.selectedItemIndex <= clsDrill.activeJob.Items.Count - 1))
      return;
    buShape buShape = clsDrill.activeJob.Items[this.selectedItemIndex];
    clsDrill.activeJob.Items.RemoveAt(this.selectedItemIndex);
    --this.selectedItemIndex;
    clsDrill.activeJob.Items.Insert(this.selectedItemIndex, buShape);
    this.JobUpdate(true, (DrillItem) null);
  }

  public void FindDrillsAtPlane(
    DrillJob Job,
    planeBoxNames refPlane,
    ref List<DrillCalcItem> Items)
  {
    for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
    {
      if (Job.Items[index1] is buShapeHole)
      {
        buShapeHole buShapeHole1 = Job.Items[index1] as buShapeHole;
        if (buShapeHole1.Enable)
        {
          if (buShapeHole1.planeName == planeBoxNames.Back)
            Job.isClamperSideDrillOpAvailable = true;
          if (buShapeHole1.DrillType == drillTypes.SingleHole && !buShapeHole1.isMilling & buShapeHole1.planeName == refPlane)
          {
            Items.Add(new DrillCalcItem(buShapeHole1));
            Items[Items.Count - 1].ID = this.IDCounter;
          }
          if (buShapeHole1.DrillType == drillTypes.HorizontalHoles | buShapeHole1.DrillType == drillTypes.HorizontalLineHoles | buShapeHole1.DrillType == drillTypes.VerticalHoles | buShapeHole1.DrillType == drillTypes.VerticalLineHoles | buShapeHole1.DrillType == drillTypes.InclineHoles && !buShapeHole1.isMilling & buShapeHole1.planeName == refPlane)
          {
            for (int index2 = 0; index2 <= buShapeHole1.multiCenter.Count - 1; ++index2)
            {
              buShapeHole buShapeHole2 = new buShapeHole(buShapeHole1.Diameter, buShapeHole1.Depth);
              buShapeHole2.CalculatedPoint = new Point3D(buShapeHole1.multiCenter[index2].Center.X, buShapeHole1.multiCenter[index2].Center.Y, buShapeHole1.multiCenter[index2].Center.Z);
              buShapeHole2.planeName = buShapeHole1.planeName;
              buShapeHole2.ID = this.IDCounter;
              Items.Add(new DrillCalcItem(buShapeHole2));
              Items[Items.Count - 1].ID = this.IDCounter;
            }
          }
          if (buShapeHole1.DrillType == drillTypes.ThreeHole & buShapeHole1.planeName == refPlane)
          {
            buShapeHole3 buShapeHole3 = Job.Items[index1] as buShapeHole3;
            Point3D calcCenter1 = new Point3D();
            Point3D calcCenter2 = new Point3D();
            clsInit.cVector5.calcBuShapeHole3Point(buShapeHole3.CalculatedPoint, buShapeHole3.planeName, buShapeHole3.DistanceX, buShapeHole3.DistanceY, buShapeHole3.DiameterOutside, buShapeHole3.Hole3Angle, ref calcCenter1, ref calcCenter2);
            buShapeHole buShapeHole4 = new buShapeHole(buShapeHole3.Diameter, buShapeHole3.Depth);
            buShapeHole4.CalculatedPoint = new Point3D(buShapeHole1.CalculatedPoint.X, buShapeHole1.CalculatedPoint.Y, buShapeHole1.CalculatedPoint.Z);
            buShapeHole4.planeName = buShapeHole1.planeName;
            buShapeHole4.ID = this.IDCounter;
            Items.Add(new DrillCalcItem(buShapeHole4));
            Items[Items.Count - 1].ID = this.IDCounter;
            buShapeHole buShapeHole5 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole5.CalculatedPoint = new Point3D(calcCenter1.X, calcCenter1.Y, calcCenter1.Z);
            buShapeHole5.planeName = buShapeHole1.planeName;
            buShapeHole5.ID = this.IDCounter;
            Items.Add(new DrillCalcItem(buShapeHole5));
            Items[Items.Count - 1].ID = this.IDCounter;
            buShapeHole buShapeHole6 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole6.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter1.Z);
            buShapeHole6.planeName = buShapeHole1.planeName;
            buShapeHole6.ID = this.IDCounter;
            Items.Add(new DrillCalcItem(buShapeHole6));
            Items[Items.Count - 1].ID = this.IDCounter;
          }
        }
      }
    }
  }

  public void doGetDrill(List<Entity> EL)
  {
    if (EL.Count > 0)
    {
      clsDrill.activeJob = new DrillJob();
      clsDrill.activeJob.Items.Clear();
      bool flag1 = false;
      bool flag2 = false;
      if (EL[0] is Brep)
        flag2 = true;
      else if (EL[0] is ICurve)
        flag1 = true;
      if (flag2)
      {
        if (EL[0] is Brep)
        {
          Brep brep = EL[0] as Brep;
          brep.Regen(0.01);
          brep.Translate(-brep.BoxMin.X, -brep.BoxMin.Y, -brep.BoxMin.Z);
          brep.Regen(0.01);
          double factor = 1.0;
          if (brep.BoxMax.Z > 0.0 & brep.BoxMax.Z < 1.0)
          {
            double num = 10.0 / brep.BoxMax.Z;
            if (num > 1.0 & num <= 10.0)
              factor = 10.0;
            if (num > 10.0 & num <= 100.0)
              factor = 100.0;
            if (num > 100.0 & num <= 1000.0)
              factor = 1000.0;
          }
          if (factor > 1.0)
          {
            brep.Scale(factor);
            brep.Regen(0.01);
          }
          clsDrill.activeJob = new DrillJob();
          if (clsDrill.JobList == null)
            clsDrill.JobList = new List<DrillJob>();
          clsDrill.JobList = new List<DrillJob>();
          SizeObject size = new SizeObject(brep.BoxMax.X - brep.BoxMin.X, brep.BoxMax.Y - brep.BoxMin.Y, brep.BoxMax.Z - brep.BoxMin.Z);
          clsDrill.activeJob.Material = new MaterialBase5(size);
          for (int index1 = 0; index1 <= brep.Faces.Length - 1; ++index1)
          {
            Brep.Face face = brep.Faces[index1];
            if (face.Surface != null)
            {
              ICurve[] trimLoops = (ICurve[]) null;
              for (int index2 = 0; index2 <= face.Loops.Length - 1; ++index2)
              {
                trimLoops = new ICurve[face.Loops[index2].Segments.Length];
                for (int index3 = 0; index3 <= face.Loops[index2].Segments.Length - 1; ++index3)
                {
                  Brep.OrientedEdge segment = face.Loops[index2].Segments[index3];
                  Brep.Edge edge = brep.Edges[segment.CurveIndex];
                  trimLoops[index3] = edge.Curve;
                }
              }
              Surface[] surface = face.Surface.GetSurface((IList<ICurve>) trimLoops);
              if (surface != null & surface.Length != 0 && surface[0] is PlanarSurface)
              {
                PlanarSurface planarSurface = surface[0] as PlanarSurface;
                if (planarSurface.Plane.Equation.Z == 1.0 | planarSurface.Plane.Equation.Z == -1.0)
                {
                  List<Entity> refEntities = new List<Entity>();
                  for (int index4 = 0; index4 <= trimLoops.Length - 1; ++index4)
                  {
                    if ((trimLoops[index4] is devDept.Eyeshot.Entities.Line ? 1 : (trimLoops[index4] is LinearPath ? 1 : 0)) != 0)
                      refEntities.Add((Entity) trimLoops[index4]);
                  }
                  Point3D MinPoint = new Point3D();
                  Point3D MidPoint = new Point3D();
                  Point3D MaxPoint = new Point3D();
                  if (refEntities.Count > 0)
                  {
                    clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
                    double num1 = MaxPoint.X - MinPoint.X;
                    double num2 = MaxPoint.Y - MinPoint.Y;
                    bool flag3 = false;
                    bool flag4 = false;
                    bool flag5 = false;
                    Point3D point3D = new Point3D();
                    double num3;
                    double num4;
                    if (num1 < num2)
                    {
                      num3 = num1;
                      num4 = num2;
                      point3D.X = MidPoint.X;
                      point3D.Y = MinPoint.Y;
                      point3D.Z = MinPoint.Z;
                    }
                    else
                    {
                      num3 = num2;
                      num4 = num1;
                      flag3 = true;
                      point3D.X = MinPoint.X;
                      point3D.Y = MidPoint.Y;
                      point3D.Z = MinPoint.Z;
                    }
                    for (int index5 = 0; index5 <= clsDrill.ToolList.Count - 1; ++index5)
                    {
                      if (clsDrill.ToolList[index5].Purpose == ToolPurpose.Saw && buCompare5.EQ(clsDrill.ToolList[index5].Geometry.Thickness, num3))
                        flag4 = true;
                      if (clsDrill.ToolList[index5].Purpose == ToolPurpose.Milling && buCompare5.EQ(clsDrill.ToolList[index5].Geometry.Diameter, num3))
                      {
                        flag4 = true;
                        flag5 = true;
                      }
                    }
                    if (flag4)
                    {
                      buShapeCut buShapeCut = new buShapeCut();
                      buShapeCut.CutType = CutTypes.CutVertical;
                      if (flag3)
                        buShapeCut.CutType = CutTypes.CutHorizontal;
                      buShapeCut.BasePoint.X = point3D.X;
                      buShapeCut.BasePoint.Y = point3D.Y;
                      buShapeCut.BasePoint.Z = point3D.X;
                      buShapeCut.Depth = size.Depth - point3D.Z;
                      buShapeCut.Diameter = num3;
                      buShapeCut.planeName = planeBoxNames.Top;
                      buShapeCut.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut.planeName);
                      buShapeCut.Enable = true;
                      buShapeCut.isMilling = flag5;
                      buShapeCut.Length = num4;
                      buShapeCut.Angle = 0.0;
                      buShapeCut.Corner = CornerLocation.LeftTop;
                      buShapeCut.Alignment = ObjectAlignment.MiddleLeft;
                      clsVar5.shapeCreatePar.Solid = true;
                      clsVar5.shapeCreatePar.Size = new SizeObject(size);
                      clsVar5.shapeCreatePar.SingX = -1.0;
                      clsVar5.shapeCreatePar.SingY = -1.0;
                      buShape Shape = (buShape) buShapeCut;
                      clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                      if (clsDrill.activeJob.Items.Count == 0)
                      {
                        clsDrill.activeJob.Items.Add(Shape);
                      }
                      else
                      {
                        bool flag6 = false;
                        for (int index6 = 0; index6 <= clsDrill.activeJob.Items.Count - 1; ++index6)
                        {
                          if (buShape.isSame(clsDrill.activeJob.Items[index6], Shape))
                            flag6 = true;
                        }
                        if (!flag6)
                          clsDrill.activeJob.Items.Add(Shape);
                      }
                    }
                  }
                }
              }
            }
          }
          for (int index7 = 0; index7 <= brep.Edges.Length - 1; ++index7)
          {
            Brep.Edge edge1 = brep.Edges[index7];
            ICurve curve = edge1.Curve;
            switch (curve)
            {
              case Circle _:
                Circle circle = curve as Circle;
                if (circle.Plane.Equation.Z == 1.0)
                {
                  List<Entity> refEntities = new List<Entity>();
                  if (buCompare5.EQ(circle.Center.Z, clsDrill.activeJob.Material.Size.Depth, 0.1))
                  {
                    for (int index8 = 0; index8 <= edge1.Parents.Length - 1; ++index8)
                    {
                      int parent = edge1.Parents[index8];
                      Brep.Face face = brep.Faces[parent];
                      for (int index9 = 0; index9 <= face.Loops.Length - 1; ++index9)
                      {
                        for (int index10 = 0; index10 <= face.Loops[index9].Segments.Length - 1; ++index10)
                        {
                          Brep.OrientedEdge segment = face.Loops[index9].Segments[index10];
                          Brep.Edge edge2 = brep.Edges[segment.CurveIndex];
                          refEntities.Add((Entity) edge2.Curve);
                        }
                      }
                    }
                  }
                  else if (circle.Center.Z < clsDrill.activeJob.Material.Size.Depth)
                  {
                    for (int index11 = 0; index11 <= edge1.Parents.Length - 1; ++index11)
                    {
                      int parent = edge1.Parents[index11];
                      Brep.Face face = brep.Faces[parent];
                      for (int index12 = 0; index12 <= face.Loops.Length - 1; ++index12)
                      {
                        for (int index13 = 0; index13 <= face.Loops[index12].Segments.Length - 1; ++index13)
                        {
                          Brep.OrientedEdge segment = face.Loops[index12].Segments[index13];
                          Brep.Edge edge3 = brep.Edges[segment.CurveIndex];
                          refEntities.Add((Entity) edge3.Curve);
                        }
                      }
                    }
                  }
                  if (refEntities.Count > 0)
                  {
                    Point3D MinPoint = new Point3D();
                    Point3D MaxPoint = new Point3D();
                    clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
                    buShapeHole buShapeHole = new buShapeHole();
                    buShapeHole.DrillType = drillTypes.SingleHole;
                    buShapeHole.BasePoint.X = circle.Center.X;
                    buShapeHole.BasePoint.Y = circle.Center.Y;
                    buShapeHole.BasePoint.Z = circle.Center.Z;
                    buShapeHole.Depth = clsDrill.activeJob.Material.Size.Depth - MinPoint.Z;
                    buShapeHole.Diameter = circle.Radius * 2.0;
                    buShapeHole.planeName = planeBoxNames.Top;
                    buShapeHole.planeOperation = Plane.XY;
                    buShapeHole.Enable = true;
                    buShapeHole.isMilling = false;
                    buShapeHole.Corner = CornerLocation.LeftBottom;
                    buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
                    clsVar5.shapeCreatePar.Solid = true;
                    clsVar5.shapeCreatePar.Size = new SizeObject(clsDrill.activeJob.Material.Size);
                    clsVar5.shapeCreatePar.SingX = -1.0;
                    clsVar5.shapeCreatePar.SingY = -1.0;
                    buShape Shape = (buShape) buShapeHole;
                    clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                    if (clsDrill.activeJob.Items.Count == 0)
                    {
                      clsDrill.activeJob.Items.Add(Shape);
                    }
                    else
                    {
                      bool flag7 = false;
                      for (int index14 = 0; index14 <= clsDrill.activeJob.Items.Count - 1; ++index14)
                      {
                        if (buShape.isSame(clsDrill.activeJob.Items[index14], Shape))
                          flag7 = true;
                      }
                      if (!flag7)
                        clsDrill.activeJob.Items.Add(Shape);
                    }
                  }
                }
                if (circle.Plane.Equation.Y == 1.0 | circle.Plane.Equation.Y == -1.0)
                {
                  List<Entity> refEntities = new List<Entity>();
                  planeBoxNames planeBoxNames = planeBoxNames.Front;
                  if (buCompare5.EQ(circle.Center.Y, clsDrill.activeJob.Material.Size.Height, 0.1) | buCompare5.EQ(circle.Center.Y, 0.0, 0.1))
                  {
                    if (buCompare5.EQ(circle.Center.Y, clsDrill.activeJob.Material.Size.Height, 0.1))
                      planeBoxNames = planeBoxNames.Front;
                    if (buCompare5.EQ(circle.Center.Y, 0.0, 0.1))
                      planeBoxNames = planeBoxNames.Back;
                    for (int index15 = 0; index15 <= edge1.Parents.Length - 1; ++index15)
                    {
                      int parent = edge1.Parents[index15];
                      Brep.Face face = brep.Faces[parent];
                      for (int index16 = 0; index16 <= face.Loops.Length - 1; ++index16)
                      {
                        for (int index17 = 0; index17 <= face.Loops[index16].Segments.Length - 1; ++index17)
                        {
                          Brep.OrientedEdge segment = face.Loops[index16].Segments[index17];
                          Brep.Edge edge4 = brep.Edges[segment.CurveIndex];
                          refEntities.Add((Entity) edge4.Curve);
                        }
                      }
                    }
                  }
                  if (refEntities.Count > 0)
                  {
                    Point3D MinPoint = new Point3D();
                    Point3D MaxPoint = new Point3D();
                    clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
                    double num = 0.0;
                    if (buCompare5.EQ(circle.Center.Y, clsDrill.activeJob.Material.Size.Height, 0.1))
                      num = clsDrill.activeJob.Material.Size.Height - MinPoint.Y;
                    if (buCompare5.EQ(circle.Center.Y, 0.0, 0.1))
                      num = MaxPoint.Y;
                    if (num <= 0.01)
                      num = 0.1;
                    buShapeHole buShapeHole = new buShapeHole();
                    buShapeHole.DrillType = drillTypes.SingleHole;
                    buShapeHole.BasePoint.X = circle.Center.X;
                    buShapeHole.BasePoint.Y = circle.Center.Y;
                    buShapeHole.BasePoint.Z = circle.Center.Z;
                    buShapeHole.Depth = num;
                    buShapeHole.Diameter = circle.Radius * 2.0;
                    buShapeHole.planeName = planeBoxNames;
                    buShapeHole.planeOperation = Plane.XZ;
                    buShapeHole.Enable = true;
                    buShapeHole.isMilling = false;
                    buShapeHole.Corner = CornerLocation.LeftBottom;
                    buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
                    clsVar5.shapeCreatePar.Solid = true;
                    clsVar5.shapeCreatePar.Size = new SizeObject(clsDrill.activeJob.Material.Size);
                    clsVar5.shapeCreatePar.SingX = -1.0;
                    clsVar5.shapeCreatePar.SingY = -1.0;
                    buShape Shape = (buShape) buShapeHole;
                    clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                    if (clsDrill.activeJob.Items.Count == 0)
                    {
                      clsDrill.activeJob.Items.Add(Shape);
                    }
                    else
                    {
                      bool flag8 = false;
                      for (int index18 = 0; index18 <= clsDrill.activeJob.Items.Count - 1; ++index18)
                      {
                        if (buShape.isSame(clsDrill.activeJob.Items[index18], Shape))
                          flag8 = true;
                      }
                      if (!flag8)
                        clsDrill.activeJob.Items.Add(Shape);
                    }
                  }
                }
                if (circle.Plane.Equation.X == 1.0 | circle.Plane.Equation.X == -1.0)
                {
                  DrillItem drillItem = new DrillItem();
                  planeBoxNames planeBoxNames = planeBoxNames.Left;
                  List<Entity> refEntities = new List<Entity>();
                  if (buCompare5.EQ(circle.Center.X, clsDrill.activeJob.Material.Size.Width, 0.1) | buCompare5.EQ(circle.Center.X, 0.0, 0.1))
                  {
                    if (buCompare5.EQ(circle.Center.X, clsDrill.activeJob.Material.Size.Width, 0.1))
                      planeBoxNames = planeBoxNames.Right;
                    if (buCompare5.EQ(circle.Center.X, 0.0, 0.1))
                      planeBoxNames = planeBoxNames.Left;
                    for (int index19 = 0; index19 <= edge1.Parents.Length - 1; ++index19)
                    {
                      int parent = edge1.Parents[index19];
                      Brep.Face face = brep.Faces[parent];
                      for (int index20 = 0; index20 <= face.Loops.Length - 1; ++index20)
                      {
                        for (int index21 = 0; index21 <= face.Loops[index20].Segments.Length - 1; ++index21)
                        {
                          Brep.OrientedEdge segment = face.Loops[index20].Segments[index21];
                          Brep.Edge edge5 = brep.Edges[segment.CurveIndex];
                          refEntities.Add((Entity) edge5.Curve);
                        }
                      }
                    }
                  }
                  if (refEntities.Count > 0)
                  {
                    Point3D MinPoint = new Point3D();
                    Point3D MaxPoint = new Point3D();
                    clsInit.cVector5.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
                    double num = 0.0;
                    if (buCompare5.EQ(circle.Center.X, clsDrill.activeJob.Material.Size.Width, 0.1))
                      num = clsDrill.activeJob.Material.Size.Width - MinPoint.X;
                    if (buCompare5.EQ(circle.Center.X, 0.0, 0.1))
                      num = MaxPoint.X;
                    if (num <= 0.01)
                      num = 0.1;
                    buShapeHole buShapeHole = new buShapeHole();
                    buShapeHole.DrillType = drillTypes.SingleHole;
                    buShapeHole.BasePoint.X = circle.Center.X;
                    buShapeHole.BasePoint.Y = circle.Center.Y;
                    buShapeHole.BasePoint.Z = circle.Center.Z;
                    buShapeHole.Depth = num;
                    buShapeHole.Diameter = circle.Radius * 2.0;
                    buShapeHole.planeName = planeBoxNames;
                    buShapeHole.planeOperation = Plane.YZ;
                    buShapeHole.Enable = true;
                    buShapeHole.isMilling = false;
                    buShapeHole.Corner = CornerLocation.LeftBottom;
                    buShapeHole.Alignment = ObjectAlignment.MiddleCenter;
                    clsVar5.shapeCreatePar.Solid = true;
                    clsVar5.shapeCreatePar.Size = new SizeObject(clsDrill.activeJob.Material.Size);
                    clsVar5.shapeCreatePar.SingX = -1.0;
                    clsVar5.shapeCreatePar.SingY = -1.0;
                    buShape Shape = (buShape) buShapeHole;
                    clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
                    if (clsDrill.activeJob.Items.Count == 0)
                    {
                      clsDrill.activeJob.Items.Add(Shape);
                      break;
                    }
                    bool flag9 = false;
                    for (int index22 = 0; index22 <= clsDrill.activeJob.Items.Count - 1; ++index22)
                    {
                      if (buShape.isSame(clsDrill.activeJob.Items[index22], Shape))
                        flag9 = true;
                    }
                    if (!flag9)
                    {
                      clsDrill.activeJob.Items.Add(Shape);
                      break;
                    }
                    break;
                  }
                  break;
                }
                break;
              case devDept.Eyeshot.Entities.Line _:
                if ((curve as devDept.Eyeshot.Entities.Line).Direction.X != 0.0)
                  break;
                break;
            }
          }
          if (clsDrill.activeJob.Material.Entities.Count == 0)
          {
            Entity entity = (Entity) null;
            clsInit.cVector5.CreateMaterialEntities(clsDrill.activeJob.Material, ref entity);
            clsInit.cVector5.Move(-clsDrill.activeJob.Material.Size.Width, -clsDrill.activeJob.Material.Size.Height, 0.0, ref entity);
            clsDrill.activeJob.Material.Entities.Add(entity);
            clsDrill.activeJob.panelEntity = entity;
          }
          clsDrill.activeJob.Material.Sing = new Point3D(clsVar5.shapeCreatePar.SingX, clsVar5.shapeCreatePar.SingY, 1.0);
          this.JobUpdate(true, (DrillItem) null);
          this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.Dimetric);
          ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit();
        }
      }
      else if (flag1)
        buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[38]);
      else
        buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[38]);
    }
    else if (clsDrill.JobList.Count > 0)
    {
      if (this.frmEdit == null)
        this.frmEdit = new F_DrillEdit();
      this.frmEdit.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
      this.frmEdit.Init();
      int num = (int) this.frmEdit.ShowDialog();
      if (this.frmEdit.PropertiesForm.Result == DialogResult.OK)
      {
        clsDrill.JobList[this.selectedJobIndex] = clsDrill.activeJob;
        this.DrawPanelFromJobMainAndPreview(clsDrill.activeJob);
      }
    }
    if (clsDrill.varDrillSettings.DeleteDrawingAfterChangeToJob)
      clsInit.appCommand.Delete(true);
    else
      clsInit.appCommand.Reset();
  }

  public void doReset()
  {
    if (this.shapeRuntimeData_0 != null)
      clsVar5.ShapeDataParameters = new ShapeRuntimeData(this.shapeRuntimeData_0);
    this.UpdateSelectedOperation(new ViewportDrawOptions(ViewportRefType.Main, -1, -1));
    this.shapeRuntimeData_0 = (ShapeRuntimeData) null;
    this.operationErrorList.Clear();
    this.calcErrorList.Clear();
    this.EditOperation = false;
  }

  public void GetItemsFromDrillTypes(ref DrillJob Job)
  {
    Job.ErrorCodes = new List<string>();
    Job.isClamperSideDrillOpAvailable = false;
    Job.isClamperSideSlotOpAvailable = false;
    Job.isClamperSideMillingOpAvailable = false;
    Job.ItemShape.Clear();
    Job.ItemCalc.Clear();
    Job.Codes.Clear();
    Job.Cams.Clear();
    Job.Moves.Clear();
    Job.SimulationMoves.Clear();
    Job.Moves = new List<DrillMove>();
    Job.SimulationMoves = new List<DrillMove>();
    for (int index1 = 0; index1 <= Job.Items.Count - 1; ++index1)
    {
      if (Job.Items[index1] is buShapeHole)
      {
        buShapeHole buShapeHole1 = Job.Items[index1] as buShapeHole;
        if (buShapeHole1.Enable)
        {
          if (buShapeHole1.planeName == planeBoxNames.Back)
            Job.isClamperSideDrillOpAvailable = true;
          if (buShapeHole1.DrillType == drillTypes.SingleHole)
          {
            if (!buShapeHole1.isMilling)
            {
              Job.ItemCalc.Add(new DrillCalcItem(buShapeHole1));
              Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
              if (Job.Items[index1].BasePoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
                Job.isClamperSideDrillOpAvailable = true;
              ++this.IDCounter;
            }
            else
              Job.ItemShape.Add(new DrillItem((buShapeHole) Job.Items[index1])
              {
                isDrill = true
              });
          }
          if (buShapeHole1.DrillType == drillTypes.HorizontalHoles | buShapeHole1.DrillType == drillTypes.HorizontalLineHoles | buShapeHole1.DrillType == drillTypes.VerticalHoles | buShapeHole1.DrillType == drillTypes.VerticalLineHoles | buShapeHole1.DrillType == drillTypes.InclineHoles)
          {
            if (!buShapeHole1.isMilling)
            {
              for (int index2 = 0; index2 <= buShapeHole1.multiCenter.Count - 1; ++index2)
              {
                buShapeHole buShapeHole2 = new buShapeHole(buShapeHole1.Diameter, buShapeHole1.Depth);
                buShapeHole2.CalculatedPoint = new Point3D(buShapeHole1.multiCenter[index2].Center.X, buShapeHole1.multiCenter[index2].Center.Y, buShapeHole1.multiCenter[index2].Center.Z);
                buShapeHole2.planeName = buShapeHole1.planeName;
                buShapeHole2.ID = this.IDCounter;
                Job.ItemCalc.Add(new DrillCalcItem(buShapeHole2));
                Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
                if (Math.Abs(buShapeHole1.multiCenter[index2].Center.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
                  Job.isClamperSideDrillOpAvailable = true;
                ++this.IDCounter;
              }
            }
            else
            {
              for (int index3 = 0; index3 <= buShapeHole1.multiCenter.Count - 1; ++index3)
              {
                buShapeHole buShapeHole3 = new buShapeHole(buShapeHole1.Diameter, buShapeHole1.Depth);
                buShapeHole3.CalculatedPoint = new Point3D(buShapeHole1.multiCenter[index3].Center.X, buShapeHole1.multiCenter[index3].Center.Y, buShapeHole1.multiCenter[index3].Center.Z);
                buShapeHole3.ItemSize.MinBox = new Point3D(buShapeHole1.multiCenter[index3].Center.X - buShapeHole1.Diameter / 2.0, buShapeHole1.multiCenter[index3].Center.Y - buShapeHole1.Diameter / 2.0);
                buShapeHole3.ItemSize.MaxBox = new Point3D(buShapeHole1.multiCenter[index3].Center.X + buShapeHole1.Diameter / 2.0, buShapeHole1.multiCenter[index3].Center.Y + buShapeHole1.Diameter / 2.0);
                buShapeHole3.planeName = buShapeHole1.planeName;
                Job.ItemShape.Add(new DrillItem(buShapeHole3));
              }
            }
          }
          if (buShapeHole1.DrillType == drillTypes.ThreeHole)
          {
            buShapeHole3 buShapeHole3 = Job.Items[index1] as buShapeHole3;
            Point3D calcCenter1 = new Point3D();
            Point3D calcCenter2 = new Point3D();
            clsInit.cVector5.calcBuShapeHole3Point(buShapeHole3.CalculatedPoint, buShapeHole3.planeName, buShapeHole3.DistanceX, buShapeHole3.DistanceY, buShapeHole3.DiameterOutside, buShapeHole3.Hole3Angle, ref calcCenter1, ref calcCenter2);
            buShapeHole buShapeHole4 = new buShapeHole(buShapeHole3.Diameter, buShapeHole3.Depth);
            buShapeHole4.CalculatedPoint = new Point3D(buShapeHole1.CalculatedPoint.X, buShapeHole1.CalculatedPoint.Y, buShapeHole1.CalculatedPoint.Z);
            buShapeHole4.planeName = buShapeHole1.planeName;
            buShapeHole4.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole4));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole4.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
            buShapeHole buShapeHole5 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole5.CalculatedPoint = new Point3D(calcCenter1.X, calcCenter1.Y, calcCenter1.Z);
            buShapeHole5.planeName = buShapeHole1.planeName;
            buShapeHole5.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole5));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole5.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
            buShapeHole buShapeHole6 = new buShapeHole(buShapeHole3.DiameterOutside, buShapeHole3.Depth);
            buShapeHole6.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter1.Z);
            buShapeHole6.planeName = buShapeHole1.planeName;
            buShapeHole6.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole6));
            Job.ItemCalc[Job.ItemCalc.Count - 1].ID = this.IDCounter;
            ++this.IDCounter;
            if (Math.Abs(buShapeHole6.CalculatedPoint.Y) < clsDrill.varDrillCNCSettings.ClamperCatchWidth && buShapeHole1.planeName != planeBoxNames.Back)
              Job.isClamperSideDrillOpAvailable = true;
          }
        }
      }
      if (Job.Items[index1] is buShapeCut & Job.Items[index1].Enable)
      {
        buShapeCut buShapeCut = Job.Items[index1] as buShapeCut;
        if ((buShapeCut.CutType == CutTypes.CutHorizontal | buShapeCut.CutType == CutTypes.CutHorizontalLine) & !buShapeCut.isMilling)
          Job.ItemCalc.Add(new DrillCalcItem(buShapeCut));
        else if (buShapeCut.CutType == CutTypes.CutVertical | buShapeCut.CutType == CutTypes.CutVerticalLine | buShapeCut.CutType == CutTypes.CutFree)
        {
          Job.ItemShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
        }
        else
        {
          DrillItem data = new DrillItem((buShapeCut) Job.Items[index1]);
          if (-buShapeCut.CalculatedPoint.Y < clsDrill.varDrillCNCSettings.ClamperCatchWidth + buShapeCut.Diameter / 2.0)
          {
            if (buShapeCut.Length < Job.Material.Size.Width * 0.25)
            {
              Job.ItemShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
            }
            else
            {
              List<Point3D> Points = new List<Point3D>();
              List<Point3D> PointsDevided = new List<Point3D>();
              Points.Add(buVector5.ToPoint3D(data.camEntities[0][0].StartPoint));
              Points.Add(buVector5.ToPoint3D(data.camEntities[0][0].EndPoint));
              double num = 6.0;
              if (clsDrill.activeJob.Material.Size.Width > 1000.0)
                num = 8.0;
              if (clsDrill.activeJob.Material.Size.Width > 2000.0)
                num = 12.0;
              clsInit.cVector5.DevidePointsByLength(Points, buShapeCut.Length / num, ref PointsDevided);
              if (PointsDevided.Count > 0)
              {
                data.camEntities[0].Clear();
                DrillItem drillItem1 = new DrillItem(data);
                drillItem1.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities1 = new List<buEntity>();
                refEntities1.Add((buEntity) new buLine(PointsDevided[0], PointsDevided[1]));
                clsInit.cVector5.BoxSizeCalculate(refEntities1, ref drillItem1.BoxMinOfDrawing, ref drillItem1.BoxMaxOfDrawing);
                drillItem1.BoxMinItem = new Point3D(-drillItem1.BoxMaxOfDrawing.X, -drillItem1.BoxMaxOfDrawing.Y, drillItem1.BoxMinOfDrawing.Z);
                drillItem1.BoxMaxItem = new Point3D(-drillItem1.BoxMinOfDrawing.X, -drillItem1.BoxMinOfDrawing.Y, drillItem1.BoxMaxOfDrawing.Z);
                drillItem1.camEntities.Add(refEntities1);
                Job.ItemShape.Add(drillItem1);
                DrillItem drillItem2 = new DrillItem(data);
                drillItem2.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities2 = new List<buEntity>();
                refEntities2.Add((buEntity) new buLine(PointsDevided[1], PointsDevided[2]));
                clsInit.cVector5.BoxSizeCalculate(refEntities2, ref drillItem2.BoxMinOfDrawing, ref drillItem2.BoxMaxOfDrawing);
                drillItem2.BoxMinItem = new Point3D(-drillItem2.BoxMaxOfDrawing.X, -drillItem2.BoxMaxOfDrawing.Y, drillItem2.BoxMinOfDrawing.Z);
                drillItem2.BoxMaxItem = new Point3D(-drillItem2.BoxMinOfDrawing.X, -drillItem2.BoxMinOfDrawing.Y, drillItem2.BoxMaxOfDrawing.Z);
                drillItem2.camEntities.Add(refEntities2);
                Job.ItemShape.Add(drillItem2);
                DrillItem drillItem3 = new DrillItem(data);
                drillItem3.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities3 = new List<buEntity>();
                refEntities3.Add((buEntity) new buLine(PointsDevided[2], PointsDevided[PointsDevided.Count - 3]));
                clsInit.cVector5.BoxSizeCalculate(refEntities3, ref drillItem3.BoxMinOfDrawing, ref drillItem3.BoxMaxOfDrawing);
                drillItem3.BoxMinItem = new Point3D(-drillItem3.BoxMaxOfDrawing.X, -drillItem3.BoxMaxOfDrawing.Y, drillItem3.BoxMinOfDrawing.Z);
                drillItem3.BoxMaxItem = new Point3D(-drillItem3.BoxMinOfDrawing.X, -drillItem3.BoxMinOfDrawing.Y, drillItem3.BoxMaxOfDrawing.Z);
                drillItem3.camEntities.Add(refEntities3);
                Job.ItemShape.Add(drillItem3);
                DrillItem drillItem4 = new DrillItem(data);
                drillItem4.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities4 = new List<buEntity>();
                refEntities4.Add((buEntity) new buLine(PointsDevided[PointsDevided.Count - 3], PointsDevided[PointsDevided.Count - 2]));
                clsInit.cVector5.BoxSizeCalculate(refEntities4, ref drillItem4.BoxMinOfDrawing, ref drillItem4.BoxMaxOfDrawing);
                drillItem4.BoxMinItem = new Point3D(-drillItem4.BoxMaxOfDrawing.X, -drillItem4.BoxMaxOfDrawing.Y, drillItem4.BoxMinOfDrawing.Z);
                drillItem4.BoxMaxItem = new Point3D(-drillItem4.BoxMinOfDrawing.X, -drillItem4.BoxMinOfDrawing.Y, drillItem4.BoxMaxOfDrawing.Z);
                drillItem4.camEntities.Add(refEntities4);
                Job.ItemShape.Add(drillItem4);
                DrillItem drillItem5 = new DrillItem(data);
                drillItem5.camEntities = new List<List<buEntity>>();
                List<buEntity> refEntities5 = new List<buEntity>();
                refEntities5.Add((buEntity) new buLine(PointsDevided[PointsDevided.Count - 2], PointsDevided[PointsDevided.Count - 1]));
                clsInit.cVector5.BoxSizeCalculate(refEntities5, ref drillItem5.BoxMinOfDrawing, ref drillItem5.BoxMaxOfDrawing);
                drillItem5.BoxMinItem = new Point3D(-drillItem5.BoxMaxOfDrawing.X, -drillItem5.BoxMaxOfDrawing.Y, drillItem5.BoxMinOfDrawing.Z);
                drillItem5.BoxMaxItem = new Point3D(-drillItem5.BoxMinOfDrawing.X, -drillItem5.BoxMinOfDrawing.Y, drillItem5.BoxMaxOfDrawing.Z);
                drillItem5.camEntities.Add(refEntities5);
                Job.ItemShape.Add(drillItem5);
              }
            }
          }
          else
            Job.ItemShape.Add(new DrillItem((buShapeCut) Job.Items[index1]));
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Shape & Job.Items[index1].Enable)
        Job.ItemShape.Add(new DrillItem(Job.Items[index1]));
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Profiling & Job.Items[index1].Enable)
        Job.ItemShape.Add(new DrillItem((buShapeProfiling) Job.Items[index1]));
      if (Job.Items[index1] is buShapeJunction & Job.Items[index1].Enable)
      {
        buShapeJunction buShapeJunction = Job.Items[index1] as buShapeJunction;
        if (buShapeJunction.Enable)
        {
          for (int index4 = 0; index4 <= buShapeJunction.multiCenter.Count - 1; ++index4)
          {
            buShapeHole buShapeHole = new buShapeHole(buShapeJunction.multiCenter[index4].Diameter, buShapeJunction.Depth);
            buShapeHole.CalculatedPoint = new Point3D(buShapeJunction.multiCenter[index4].Center.X, buShapeJunction.multiCenter[index4].Center.Y, buShapeJunction.multiCenter[index4].Center.Z);
            buShapeHole.planeName = buShapeJunction.planeName;
            buShapeHole.ID = this.IDCounter;
            Job.ItemCalc.Add(new DrillCalcItem(buShapeHole));
            ++this.IDCounter;
          }
        }
      }
      if (Job.Items[index1].ShapeGroup == ShapeGroup.Engraving & Job.Items[index1].Enable)
        Job.ItemShape.Add(new DrillItem((buShapeEngrave) Job.Items[index1]));
    }
    this.SortJobItems(ref Job);
    Job.isSorted = true;
    for (int index = 0; index <= Job.ItemCalc.Count - 1; ++index)
      Job.ItemCalc[index].Calculated = false;
  }
}
