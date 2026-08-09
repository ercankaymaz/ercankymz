using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using buCadCamResVer5.DialogBoxx;
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
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.Shape;
using buEyeBaseVer5.Variables;
using buEyeBaseVer5.buEntities;
using buMW.Variables;
using buMutliTextbox;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

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

	public static DrillJob activeJob = null;

	public static List<DrillJob> JobList = null;

	public static List<DrillJob> JobStoredList = null;

	public buCadCamResVer5.DialogBoxx.OpenFileDialogBoxPreview openDialogCtrlPreview = new buCadCamResVer5.DialogBoxx.OpenFileDialogBoxPreview();

	private OpenFileDialog openFileDialog_0 = new OpenFileDialog();

	public DrillMachineType MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;

	public List<string> FilesERP = new List<string>();

	public clsDrillGoUltra2Up1Down cGoUltra2Up1Down = null;

	public clsDrillGoAtc cGoAtc = null;

	public clsDrillSirius cGoSirius = null;

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

	public F_DrillMachSim frmMachSim = null;

	public F_DrillEdit frmEdit = null;

	public F_DrillEdit frmList = null;

	public F_Tools FrmTools = null;

	public F_CabinetCycle FrmCabinetCycle = null;

	public Timer timNew = new Timer();

	public Mesh ClamperEntity = null;

	public DrillSplitedItems SplitedItems = new DrillSplitedItems();

	public List<string> calcErrorList = new List<string>();

	public List<string> operationErrorList = new List<string>();

	public List<DrillFound> FoundDrills = new List<DrillFound>();

	public List<List<DrillCalcItem>> ItemSplited = new List<List<DrillCalcItem>>();

	public DrillCalcItem LastCalcItem = null;

	public string fileNameActual = "";

	public string fileNameCabinerCycle = "";

	private bool bool_0 = false;

	private Point3D point3D_0;

	private Point3D point3D_1;

	private Point3D point3D_2;

	private DrillRuntimeSettings drillRuntimeSettings_0 = null;

	private ShapeRuntimeData shapeRuntimeData_0 = null;

	private List<Entity> list_0 = new List<Entity>();

	public static Design viewportAuto = null;

	public static Design viewportEdit = null;

	public static Design viewportList = null;

	public List<string> cmdExceptionID = new List<string>();

	public Timer timSim = null;

	public Timer timCabinetCycle = null;

	public Timer timCabinetStartCycle = null;

	public Point3D pntCenter = new Point3D();

	public Point3D pntTarget = new Point3D();

	public List<Point3D> pntList = new List<Point3D>();

	public int indx = 0;

	public double AngleTot = 0.0;

	public Timer timm = null;

	public Point3D pntMove = new Point3D();

	private List<buEntity> list_1 = new List<buEntity>();

	public void Init()
	{
		buMWDrillVars.Init();
		openDialogCtrlPreview.FileSelect += OpenFilePreview;
		timSim = new Timer();
		timSim.Tick += tick_Simulation;
		string text = AppPath.Settings + "\\Drill\\";
		if (clsVar.appModes_0.DrillMode.GoUltra)
		{
			MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;
			text += "\\GoUltra2Up1Down\\";
		}
		if (clsVar.appModes_0.DrillMode.Go)
		{
			MachType = DrillMachineType.GoWithAtc;
			text += "\\GoAtc\\";
		}
		if (clsVar.appModes_0.DrillMode.Sirius)
		{
			MachType = DrillMachineType.Sirius;
			text += "\\Sirius\\";
		}
		OpenDrillFile();
		if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
		{
			fileNameToolSetting = text + "ToolsSettingsGoUltra.prm";
			clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\MachineGoUltra.bumachdef", ref ccVars.SimMachine);
			MachType = DrillMachineType.GoUltra2Top1BottomNoAtc;
			cGoUltra2Up1Down = new clsDrillGoUltra2Up1Down();
		}
		if (MachType == DrillMachineType.GoWithAtc)
		{
			fileNameToolSetting = text + "ToolsSettingsGo.prm";
			MachineConfigSettings machineConfigSettings = new MachineConfigSettings();
			machineConfigSettings.PartTypeInfo = "Clamper";
			machineConfigSettings.PartTypeAdder = varDrillMachineSettings.ClamperVersion;
			clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\MachineGo.bumachdef", ref ccVars.SimMachine, machineConfigSettings);
			MachType = DrillMachineType.GoWithAtc;
			cGoAtc = new clsDrillGoAtc();
		}
		if (MachType == DrillMachineType.Sirius)
		{
			fileNameToolSetting = text + "ToolsSettingsSirius.prm";
			MachineConfigSettings machineConfigSettings2 = new MachineConfigSettings();
			machineConfigSettings2.PartTypeInfo = "Clamper";
			machineConfigSettings2.PartTypeAdder = varDrillMachineSettings.ClamperVersion;
			clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\MachineSirius.bumachdef", ref ccVars.SimMachine, machineConfigSettings2);
			MachType = DrillMachineType.Sirius;
			cGoSirius = new clsDrillSirius();
		}
		OpenToolConfigFile(fileNameToolSetting);
		FrmCabinetCycle = new F_CabinetCycle();
		clsVar5.shapeCreatePar.SingX = -1.0;
		clsVar5.shapeCreatePar.SingY = -1.0;
		cmdExceptionID.Add("clsProfile - ID = 101-00100");
		cmdExceptionID.Add("clsProfile - ID = 101-00101");
		cmdExceptionID.Add("clsProfile - ID = 101-00102");
		cmdExceptionID.Add("clsProfile - ID = 101-00103");
		cmdExceptionID.Add("clsProfile - ID = 101-00104");
		cmdExceptionID.Add("clsProfile - ID = 101-00105");
		cmdExceptionID.Add("clsProfile - ID = 101-00106");
		cmdExceptionID.Add("clsProfile - ID = 101-00107");
		cmdExceptionID.Add("clsProfile - ID = 101-00108");
		cmdExceptionID.Add("clsProfile - ID = 101-00109");
		cmdExceptionID.Add("clsProfile - ID = 101-00110");
		cmdExceptionID.Add("clsProfile - ID = 101-00111");
		cmdExceptionID.Add("clsProfile - ID = 101-00112");
		cmdExceptionID.Add("clsProfile - ID = 101-00113");
		cmdExceptionID.Add("clsProfile - ID = 101-00114");
		cmdExceptionID.Add("clsProfile - ID = 101-00115");
		cmdExceptionID.Add("clsProfile - ID = 101-00116");
		cmdExceptionID.Add("clsProfile - ID = 101-00117");
		cmdExceptionID.Add("clsProfile - ID = 101-00118");
		cmdExceptionID.Add("clsProfile - ID = 101-00119");
		cmdExceptionID.Add("clsProfile - ID = 101-00120");
		cmdExceptionID.Add("clsProfile - ID = 101-00121");
		cmdExceptionID.Add("clsProfile - ID = 101-00122");
		cmdExceptionID.Add("clsProfile - ID = 101-00123");
		cmdExceptionID.Add("clsProfile - ID = 101-00124");
		cmdExceptionID.Add("clsProfile - ID = 101-00125");
		cmdExceptionID.Add("clsProfile - ID = 101-00126");
		cmdExceptionID.Add("clsProfile - ID = 101-00127");
		cmdExceptionID.Add("clsProfile - ID = 101-00128");
		cmdExceptionID.Add("clsProfile - ID = 101-00129");
		cmdExceptionID.Add("clsProfile - ID = 101-00130");
		cmdExceptionID.Add("clsProfile - ID = 101-00131");
		cmdExceptionID.Add("clsProfile - ID = 101-00132");
		cmdExceptionID.Add("clsProfile - ID = 101-00133");
		timCabinetCycle = new Timer();
		timCabinetCycle.Tick += ERPCycle_Tick;
		timCabinetCycle.Interval = varDrillRunSettings.CabinetAutoCycleTickMs;
		timCabinetStartCycle = new Timer();
		timCabinetStartCycle.Tick += ERPStartCycle_Tick;
		timCabinetStartCycle.Interval = varDrillRunSettings.CabinetAutoCycleTickDelayMs;
		timNew.Tick += NewPageTick;
		for (int i = 0; i <= ToolList.Count - 1; i++)
		{
			if (ToolList[i].Data.No == 80)
			{
				toolTop = new ToolBase5(ToolList[i]);
			}
			if (ToolList[i].Data.No == 270)
			{
				toolBottom = new ToolBase5(ToolList[i]);
			}
			if (ToolList[i].Data.No == 85)
			{
				toolSlotY1 = new ToolBase5(ToolList[i]);
			}
			if (ToolList[i].Data.No == 185)
			{
				toolSlotY2 = new ToolBase5(ToolList[i]);
			}
		}
	}

	public void InitViewport()
	{
		if (frmMachSim == null)
		{
			frmMachSim = new F_DrillMachSim();
			frmMachSim.ValueChanged += SimValueChaned;
		}
		if (viewportAuto == null)
		{
			CreateModelProperties createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
			createModelProperties.OriginSymbolVisible = true;
			createModelProperties.ViewCubeIconVisible = true;
			createModelProperties.OrigineCaptionVisible = false;
			createModelProperties.ToolBorVisible = false;
			createModelProperties.BottomColor = Color.LightGray;
			createModelProperties.MiddleColor = Color.WhiteSmoke;
			createModelProperties.TopColor = Color.LightGray;
			createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			clsInit.cVector5.CreateModelControl(ref viewportAuto, clsVar.UnlockKey, createModelProperties);
			viewportAuto.Name = "ModelAuto";
			frmMachSim.pnl_viewport.Controls.Add(viewportAuto);
			viewportAuto.MouseMove += mouseMoveVierport;
			viewportAuto.MouseDown += mouseDownVierport;
			viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
			viewportAuto.ProgressBar.Visible = false;
			viewportAuto.WaitCursorMode = waitCursorType.Never;
			for (int i = 0; i <= ccVars.SimMachine.MachineParts.Count - 1; i++)
			{
				for (int j = 0; j <= ccVars.SimMachine.MachineParts[i].Entities.Count - 1; j++)
				{
					Entity entity = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[i].Entities[j]);
					CustomData customData = new CustomData();
					customData.typeDefination = entityTypeDefination.MachineParts;
					customData.EntityName = ccVars.SimMachine.MachineParts[i].PartName;
					entity.EntityData = customData;
					entity.Regen(new RegenParams(buSystem.RegenDeviation, viewportAuto));
					string text = ((CustomData)entity.EntityData).EntityName;
					if (text.Length == 0)
					{
						text = "Block" + i;
					}
					Block block = new Block(text);
					Entity entity2 = buVector5.CopyEntities(entity);
					entity2.Color = Color.Linen;
					int alpha = 255;
					if ((ccVars.SimMachine.MachineParts[i].Transparency >= 0) & (ccVars.SimMachine.MachineParts[i].Transparency <= 255))
					{
						alpha = ccVars.SimMachine.MachineParts[i].Transparency;
					}
					if (i <= ccVars.SimMachine.MachineParts.Count - 1)
					{
						entity2.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[i].Color);
					}
					entity2.ColorMethod = colorMethodType.byEntity;
					block.Entities.Add(entity2);
					viewportAuto.Blocks.Add(block);
				}
				if (ccVars.SimMachine.MachineParts[i].PartName == "X1_Body")
				{
					ClamperEntity = (Mesh)ccVars.SimMachine.MachineParts[i].Entities[0].Clone();
					ClamperEntity.Regen(0.01);
				}
				if (ccVars.SimMachine.MachineParts[i].PartName == "X1_Clamper" && ClamperEntity != null)
				{
					ClamperEntity.MergeWith((Mesh)ccVars.SimMachine.MachineParts[i].Entities[0]);
				}
			}
			if (ClamperEntity != null && MachType == DrillMachineType.Sirius)
			{
				ClamperEntity.Rotate(Math.PI, Vector3D.AxisZ);
			}
		}
		viewportAuto.WorkCompleted += method_0;
		viewportAuto.WorkCancelled += method_2;
		viewportAuto.WorkFailed += method_1;
	}

	public void roundrect()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		CompositeCurve compositeCurve = CompositeCurve.CreateRoundedRectangle(Plane.XY, 140.0, 200.0, 40.0, centered: true);
		pntTarget = new Point3D(-70.0, 0.0);
		compositeCurve.Regen(0.01);
		compositeCurve.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= compositeCurve.CurveList.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy((Entity)compositeCurve.CurveList[i], ref copiedEntity);
			list.Add(copiedEntity);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(compositeCurve);
		Joint joint = new Joint(new Point3D(), 2.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.Lime;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(joint);
		buCircle buCircle2 = new buCircle(new Point3D(-70.0, 0.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		List<Entity> devideEntities = new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.LineLength = 3.0;
		entityDevideData.ArcLength = 3.0;
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		clsInit.cVector5.EntitiesDevideByLengthAsPolyline(list, entityDevideData, ref devideEntities);
		clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref pntList);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<Entity> BaseRefEntities = new List<Entity>();
		for (int j = 1; j <= pntList.Count - 1; j++)
		{
			devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(new Point3D(pntList[j - 1].X, pntList[j - 1].Y), pntList[j]);
			line.Visible = true;
			line.ColorMethod = colorMethodType.byEntity;
			line.LineWeight = 3f;
			line.LineWeightMethod = colorMethodType.byEntity;
			line.EntityData = new CustomData();
			BaseRefEntities.Add(line);
		}
		List<Entity> SortedEntities = new List<Entity>();
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
		for (int k = 0; k <= SortedEntities.Count - 1; k++)
		{
			if (((CustomData)SortedEntities[k].EntityData).sortDirection != entitySortDirection.Normal)
			{
				devDept.Eyeshot.Entities.Line line2 = new devDept.Eyeshot.Entities.Line(SortedEntities[k].Vertices[1], SortedEntities[k].Vertices[0]);
				line2.Visible = true;
				line2.ColorMethod = colorMethodType.byEntity;
				line2.LineWeight = 3f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				line2.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
			}
			else
			{
				devDept.Eyeshot.Entities.Line line3 = new devDept.Eyeshot.Entities.Line(SortedEntities[k].Vertices[0], SortedEntities[k].Vertices[1]);
				line3.Visible = true;
				line3.ColorMethod = colorMethodType.byEntity;
				line3.LineWeight = 3f;
				line3.LineWeightMethod = colorMethodType.byEntity;
				line3.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line3);
			}
		}
		indx = 2;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void slot()
	{
		if (timm == null)
		{
			timm = new Timer();
			timm.Interval = 50;
			timm.Tick += timtic;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		CompositeCurve compositeCurve = CompositeCurve.CreateSlot(Plane.XY, 150.0, 50.0, centered: true);
		compositeCurve.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
		pntTarget = new Point3D(50.0, 0.0);
		compositeCurve.Regen(0.01);
		compositeCurve.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= compositeCurve.CurveList.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy((Entity)compositeCurve.CurveList[i], ref copiedEntity);
			list.Add(copiedEntity);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(compositeCurve);
		Joint joint = new Joint(new Point3D(), 2.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.Lime;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(joint);
		buCircle buCircle2 = new buCircle(new Point3D(50.0, 0.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		List<Entity> devideEntities = new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		clsInit.cVector5.EntitiesDevideByLengthAsPolyline(list, entityDevideData, ref devideEntities);
		clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref pntList);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<Entity> BaseRefEntities = new List<Entity>();
		for (int j = 1; j <= pntList.Count - 1; j++)
		{
			devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(new Point3D(pntList[j - 1].X, pntList[j - 1].Y), pntList[j]);
			line.Visible = true;
			line.ColorMethod = colorMethodType.byEntity;
			line.LineWeight = 3f;
			line.LineWeightMethod = colorMethodType.byEntity;
			line.EntityData = new CustomData();
			BaseRefEntities.Add(line);
		}
		List<Entity> SortedEntities = new List<Entity>();
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
		clsInit.cVector5.ChangeEntitiesDirection(ref SortedEntities);
		for (int k = 0; k <= SortedEntities.Count - 1; k++)
		{
			if (((CustomData)SortedEntities[k].EntityData).sortDirection != entitySortDirection.Normal)
			{
				devDept.Eyeshot.Entities.Line line2 = new devDept.Eyeshot.Entities.Line(SortedEntities[k].Vertices[1], SortedEntities[k].Vertices[0]);
				line2.Visible = true;
				line2.ColorMethod = colorMethodType.byEntity;
				line2.LineWeight = 3f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				line2.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
			}
			else
			{
				devDept.Eyeshot.Entities.Line line3 = new devDept.Eyeshot.Entities.Line(SortedEntities[k].Vertices[0], SortedEntities[k].Vertices[1]);
				line3.Visible = true;
				line3.ColorMethod = colorMethodType.byEntity;
				line3.LineWeight = 3f;
				line3.LineWeightMethod = colorMethodType.byEntity;
				line3.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line3);
			}
		}
		AngleTot = 0.0;
		pntMove = new Point3D();
		indx = 2;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void slotMinus(double Length, double Radius, ref List<buEntity> Lines)
	{
		if (timm == null)
		{
			timm = new Timer();
			timm.Interval = 50;
			timm.Tick += timtic;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		CompositeCurve compositeCurve = CompositeCurve.CreateSlot(Plane.XY, Length, Radius, centered: true);
		compositeCurve.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
		pntTarget = new Point3D(Radius, 0.0);
		compositeCurve.Regen(0.01);
		compositeCurve.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= compositeCurve.CurveList.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy((Entity)compositeCurve.CurveList[i], ref copiedEntity);
			list.Add(copiedEntity);
		}
		buCircle buCircle2 = new buCircle(new Point3D(Radius, 0.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		List<Entity> devideEntities = new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		clsInit.cVector5.EntitiesDevideByLengthAsPolyline(list, entityDevideData, ref devideEntities);
		clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref pntList);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<buEntity> BaseRefEntities = new List<buEntity>();
		for (int j = 1; j <= pntList.Count - 1; j++)
		{
			buEntity item = new buLine(new Point3D(pntList[j - 1].X, pntList[j - 1].Y), pntList[j]);
			BaseRefEntities.Add(item);
		}
		List<buEntity> SortedEntities = new List<buEntity>();
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, new SortbuSettings(), ref SortedEntities);
		clsInit.cVector5.ChangeEntitiesDirection(ref SortedEntities);
		Lines.Clear();
		devDept.Eyeshot.Entities.Point item2 = new devDept.Eyeshot.Entities.Point(new Point3D());
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item2);
		Lines.Add(new buPoint());
		for (int k = 0; k <= SortedEntities.Count - 1; k++)
		{
			Entity copiedEntity2 = null;
			if (SortedEntities[k].sortDirection != entitySortDirection.Normal)
			{
				buEntity buEntity2 = new buLine(SortedEntities[k].Vertices[1], SortedEntities[k].Vertices[0]);
				Lines.Add(buEntity2);
				buEntity.Copy(buEntity2, ref copiedEntity2);
				copiedEntity2.ColorMethod = colorMethodType.byEntity;
				copiedEntity2.Color = Color.Black;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity2);
			}
			else
			{
				buEntity buEntity3 = new buLine(SortedEntities[k].Vertices[0], SortedEntities[k].Vertices[1]);
				Lines.Add(buEntity3);
				buEntity.Copy(buEntity3, ref copiedEntity2);
				copiedEntity2.ColorMethod = colorMethodType.byEntity;
				copiedEntity2.Color = Color.Black;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity2);
			}
		}
		AngleTot = 0.0;
		pntMove = new Point3D();
		indx = 1;
	}

	public void slotPlus(double Length, double Radius, bool isPlus, ref List<buEntity> Lines)
	{
		if (timm == null)
		{
			timm = new Timer();
			timm.Interval = 50;
			timm.Tick += timtic;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		CompositeCurve compositeCurve = null;
		compositeCurve = CompositeCurve.CreateSlot(Plane.XY, Length, Radius, centered: true);
		if (compositeCurve == null)
		{
			return;
		}
		compositeCurve.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
		if (isPlus)
		{
			compositeCurve.Translate(0.0, (0.0 - Length) / 2.0);
			pntTarget = new Point3D(Radius, 0.0);
		}
		else
		{
			compositeCurve.Translate(0.0, Length / 2.0);
			pntTarget = new Point3D(Radius, 0.0);
		}
		compositeCurve.Regen(0.01);
		compositeCurve.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		if (isPlus)
		{
			Entity copiedEntity = null;
			Entity devideEntity = null;
			buEntity.Copy((Entity)compositeCurve.CurveList[0], ref copiedEntity);
			clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity, entityDevideData, ref devideEntity);
			List<Point3D> copiedPoint = new List<Point3D>();
			buVector5.Copy(devideEntity.Vertices, ref copiedPoint);
			copiedPoint.Reverse();
			buVector5.Add(copiedPoint, ref pntList);
			list.Add(copiedEntity);
			for (int num = compositeCurve.CurveList.Count - 1; num >= 1; num--)
			{
				copiedEntity = null;
				devideEntity = null;
				buEntity.Copy((Entity)compositeCurve.CurveList[num], ref copiedEntity);
				clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity, entityDevideData, ref devideEntity);
				copiedPoint = new List<Point3D>();
				buVector5.Copy(devideEntity.Vertices, ref copiedPoint);
				copiedPoint.Reverse();
				buVector5.Add(copiedPoint, ref pntList);
				list.Add(copiedEntity);
			}
		}
		else
		{
			for (int i = 0; i <= compositeCurve.CurveList.Count - 1; i++)
			{
				Entity copiedEntity2 = null;
				Entity devideEntity2 = null;
				buEntity.Copy((Entity)compositeCurve.CurveList[i], ref copiedEntity2);
				clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity2, entityDevideData, ref devideEntity2);
				buVector5.Add(devideEntity2.Vertices, ref pntList);
				list.Add(copiedEntity2);
			}
		}
		buCircle buCircle2 = new buCircle(new Point3D(Radius, 0.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<buEntity> list2 = new List<buEntity>();
		for (int j = 1; j <= pntList.Count - 1; j++)
		{
			buEntity item = new buLine(new Point3D(pntList[j - 1].X, pntList[j - 1].Y), pntList[j]);
			list2.Add(item);
		}
		Lines.Clear();
		devDept.Eyeshot.Entities.Point item2 = new devDept.Eyeshot.Entities.Point(new Point3D());
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item2);
		if (isPlus)
		{
			Lines.Add(new buPoint(new Point3D(0.0, (0.0 - Length) / 2.0)));
		}
		else
		{
			Lines.Add(new buPoint(new Point3D(0.0, Length / 2.0)));
		}
		for (int k = 0; k <= list2.Count - 1; k++)
		{
			Entity copiedEntity3 = null;
			if (list2[k].sortDirection != entitySortDirection.Normal)
			{
				buEntity buEntity2 = new buLine(list2[k].Vertices[1], list2[k].Vertices[0]);
				Lines.Add(buEntity2);
				buEntity.Copy(buEntity2, ref copiedEntity3);
				copiedEntity3.ColorMethod = colorMethodType.byEntity;
				copiedEntity3.Color = Color.Black;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity3);
			}
			else
			{
				buEntity buEntity3 = new buLine(list2[k].Vertices[0], list2[k].Vertices[1]);
				Lines.Add(buEntity3);
				buEntity.Copy(buEntity3, ref copiedEntity3);
				copiedEntity3.ColorMethod = colorMethodType.byEntity;
				copiedEntity3.Color = Color.Black;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity3);
			}
		}
		AngleTot = 0.0;
		pntMove = new Point3D();
		indx = 1;
	}

	public void RoundRect(double Width, double Height, double Radius, bool isPlus, ref List<buEntity> Lines)
	{
		if (timm == null)
		{
			timm = new Timer();
			timm.Interval = 50;
			timm.Tick += timtic;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		CompositeCurve compositeCurve = null;
		compositeCurve = CompositeCurve.CreateRoundedRectangle(Plane.XY, Width, Height, Radius, centered: true);
		if (compositeCurve == null)
		{
			return;
		}
		compositeCurve.Rotate(buConversion5.DegreeToRadian(90.0), Vector3D.AxisZ);
		if (isPlus)
		{
			compositeCurve.Translate(0.0, (0.0 - Width) / 2.0 + Radius);
			pntTarget = new Point3D(Height / 2.0, 0.0);
		}
		else
		{
			compositeCurve.Translate(0.0, Width / 2.0 - Radius);
			pntTarget = new Point3D(Height / 2.0, 0.0);
		}
		compositeCurve.Regen(0.01);
		compositeCurve.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		if (isPlus)
		{
			Entity copiedEntity = null;
			Entity devideEntity = null;
			buEntity.Copy((Entity)compositeCurve.CurveList[0], ref copiedEntity);
			clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity, entityDevideData, ref devideEntity);
			List<Point3D> copiedPoint = new List<Point3D>();
			buVector5.Copy(devideEntity.Vertices, ref copiedPoint);
			copiedPoint.Reverse();
			buVector5.Add(copiedPoint, ref pntList);
			list.Add(copiedEntity);
			for (int num = compositeCurve.CurveList.Count - 1; num >= 1; num--)
			{
				copiedEntity = null;
				devideEntity = null;
				buEntity.Copy((Entity)compositeCurve.CurveList[num], ref copiedEntity);
				clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity, entityDevideData, ref devideEntity);
				copiedPoint = new List<Point3D>();
				buVector5.Copy(devideEntity.Vertices, ref copiedPoint);
				copiedPoint.Reverse();
				buVector5.Add(copiedPoint, ref pntList);
				list.Add(copiedEntity);
			}
		}
		else
		{
			for (int i = 0; i <= compositeCurve.CurveList.Count - 1; i++)
			{
				Entity copiedEntity2 = null;
				Entity devideEntity2 = null;
				buEntity.Copy((Entity)compositeCurve.CurveList[i], ref copiedEntity2);
				clsInit.cVector5.EntityDevideByLengthAsPolyline(copiedEntity2, entityDevideData, ref devideEntity2);
				buVector5.Add(devideEntity2.Vertices, ref pntList);
				list.Add(copiedEntity2);
			}
		}
		buCircle buCircle2 = new buCircle(new Point3D(Height / 2.0, 0.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<buEntity> list2 = new List<buEntity>();
		for (int j = 1; j <= pntList.Count - 1; j++)
		{
			buEntity item = new buLine(new Point3D(pntList[j - 1].X, pntList[j - 1].Y), pntList[j]);
			list2.Add(item);
		}
		Lines.Clear();
		devDept.Eyeshot.Entities.Point item2 = new devDept.Eyeshot.Entities.Point(new Point3D());
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item2);
		if (isPlus)
		{
			Lines.Add(new buPoint(new Point3D(0.0, (0.0 - Height) / 2.0)));
		}
		else
		{
			Lines.Add(new buPoint(new Point3D(0.0, Height / 2.0)));
		}
		for (int k = 0; k <= list2.Count - 1; k++)
		{
			Entity copiedEntity3 = null;
			if (list2[k].sortDirection != entitySortDirection.Normal)
			{
				buEntity buEntity2 = new buLine(list2[k].Vertices[1], list2[k].Vertices[0]);
				Lines.Add(buEntity2);
				buEntity.Copy(buEntity2, ref copiedEntity3);
				copiedEntity3.ColorMethod = colorMethodType.byEntity;
				copiedEntity3.Color = Color.Black;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity3);
			}
			else
			{
				buEntity buEntity3 = new buLine(list2[k].Vertices[0], list2[k].Vertices[1]);
				Lines.Add(buEntity3);
				buEntity.Copy(buEntity3, ref copiedEntity3);
				copiedEntity3.ColorMethod = colorMethodType.byEntity;
				copiedEntity3.Color = Color.Black;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity3);
			}
		}
		AngleTot = 0.0;
		pntMove = new Point3D();
		indx = 1;
	}

	public void freedraw()
	{
		if (timm == null)
		{
			timm = new Timer();
			timm.Interval = 50;
			timm.Tick += timtic;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
		pntTarget = new Point3D();
		List<buEntity> list = new List<buEntity>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
			list.Add(copiedEntity);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		Joint joint = new Joint(new Point3D(), 2.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.Lime;
		buCircle buCircle2 = new buCircle(new Point3D(pntTarget.X, pntTarget.Y), 4.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.Line = true;
		entityDevideData.LineLength = 4.0;
		entityDevideData.Arc = true;
		entityDevideData.ArcLength = 4.0;
		pntList = new List<Point3D>();
		List<buEntity> BaseRefEntities = new List<buEntity>();
		for (int j = 0; j <= list.Count - 1; j++)
		{
			if (!(list[j] is buLine))
			{
				for (int k = 1; k <= list[j].Vertices.Count - 1; k++)
				{
					buLine item = new buLine(list[j].Vertices[k - 1], list[j].Vertices[k]);
					BaseRefEntities.Add(item);
				}
				continue;
			}
			pntList = new List<Point3D>();
			clsInit.cVector5.EntityDevide(list[j], 4.0, ref pntList);
			for (int l = 1; l <= pntList.Count - 1; l++)
			{
				buLine item2 = new buLine(pntList[l - 1], pntList[l]);
				BaseRefEntities.Add(item2);
			}
		}
		BaseRefEntities.Reverse();
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<buEntity> SortedEntities = new List<buEntity>();
		SortbuSettings sortbuSettings = new SortbuSettings();
		sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
		sortbuSettings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, sortbuSettings, ref SortedEntities);
		for (int m = 0; m <= SortedEntities.Count - 1; m++)
		{
			if (SortedEntities[m].sortDirection != entitySortDirection.Normal)
			{
				devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(SortedEntities[m].Vertices[1], SortedEntities[m].Vertices[0]);
				line.Visible = true;
				line.ColorMethod = colorMethodType.byEntity;
				line.LineWeight = 3f;
				line.LineWeightMethod = colorMethodType.byEntity;
				line.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line);
			}
			else
			{
				devDept.Eyeshot.Entities.Line line2 = new devDept.Eyeshot.Entities.Line(SortedEntities[m].Vertices[0], SortedEntities[m].Vertices[1]);
				line2.Visible = true;
				line2.ColorMethod = colorMethodType.byEntity;
				line2.LineWeight = 3f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				line2.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
			}
		}
		double dx = pntTarget.X - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].X;
		double dy = pntTarget.Y - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].Y;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(dx, dy);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
		indx = 0;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void rotate1()
	{
		if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indx] is devDept.Eyeshot.Entities.Line)
		{
			devDept.Eyeshot.Entities.Line line = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indx] as devDept.Eyeshot.Entities.Line;
			double degree = 180.0 - clsInit.cVector5.PointAngle(line.EndPoint, line.StartPoint);
			double angleInRadians = buConversion5.DegreeToRadian(degree);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indx].Selected = true;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(angleInRadians, Vector3D.AxisZ, line.StartPoint);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
			Point3D endPoint = line.EndPoint;
			double dx = pntTarget.X - endPoint.X;
			double dy = pntTarget.Y - endPoint.Y;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(dx, dy);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		indx++;
	}

	public void rotate()
	{
		if (indx > list_1.Count - 1)
		{
			timm.Enabled = false;
			indx = 1;
		}
		else
		{
			buLine buLine2 = list_1[indx] as buLine;
			double num = clsInit.cVector5.PointAngle(buLine2.EndPoint, buLine2.StartPoint) + 0.0;
			if (num == 90.0)
			{
			}
			num = 90.0 - num;
			AngleTot += num;
			double num2 = buLine2.StartPoint.X - buLine2.EndPoint.X;
			double num3 = buLine2.StartPoint.Y - buLine2.EndPoint.Y;
			clsInit.cVector5.Move(num2, num3, 0.0, ref list_1);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(num2, num3);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
			double angleInRadians = buConversion5.DegreeToRadian(num);
			clsInit.cVector5.Rotate(pntTarget, num, Vector3D.AxisZ, ref list_1);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(angleInRadians, Vector3D.AxisZ, pntTarget);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Text)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
			}
			pntMove = list_1[0].StartPoint;
			Text item = new Text(Plane.XY, new Point3D(), AngleTot + Environment.NewLine + "  " + pntMove.X.ToString("f1") + " , " + pntMove.Y.ToString("f1"), 20.0);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		indx++;
	}

	public void rotateplus(bool isPlus)
	{
		if (indx > list_1.Count - 1)
		{
			timm.Enabled = false;
			indx = 1;
		}
		else
		{
			buLine buLine2 = list_1[indx] as buLine;
			double num = 0.0;
			num = ((!isPlus) ? (clsInit.cVector5.PointAngle(buLine2.EndPoint, buLine2.StartPoint) + 0.0) : (clsInit.cVector5.PointAngle(buLine2.StartPoint, buLine2.EndPoint) + 0.0));
			if (num == 90.0)
			{
			}
			num = 90.0 - num;
			AngleTot += num;
			double num2 = buLine2.StartPoint.X - buLine2.EndPoint.X;
			double num3 = buLine2.StartPoint.Y - buLine2.EndPoint.Y;
			clsInit.cVector5.Move(num2, num3, 0.0, ref list_1);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(num2, num3);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
			double angleInRadians = buConversion5.DegreeToRadian(num);
			clsInit.cVector5.Rotate(pntTarget, num, Vector3D.AxisZ, ref list_1);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(angleInRadians, Vector3D.AxisZ, pntTarget);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Text)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
			}
			pntMove = list_1[0].StartPoint;
			Text item = new Text(Plane.XY, new Point3D(), AngleTot + Environment.NewLine + "  " + pntMove.X.ToString("f1") + " , " + pntMove.Y.ToString("f1"), 20.0);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		indx++;
	}

	public void rotate(int Index, List<buEntity> Entities, ref Point3D pntMove, ref double Angle)
	{
		if (Index <= Entities.Count - 1 && Entities[Index] is buLine)
		{
			buLine buLine2 = Entities[Index] as buLine;
			double num = 90.0 - clsInit.cVector5.PointAngle(buLine2.EndPoint, buLine2.StartPoint);
			double num2 = buLine2.StartPoint.X - buLine2.EndPoint.X;
			double num3 = buLine2.StartPoint.Y - buLine2.EndPoint.Y;
			buConversion5.DegreeToRadian(num);
			Angle += num;
			pntMove.X += num2;
			pntMove.Y += num3;
		}
	}

	public void timtic(object sender, EventArgs e)
	{
		rotateplus(isPlus: true);
	}

	public void cmdNewMaterial(DrillJob panel)
	{
		if (!isOperationActive())
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
			clsItem.FrmMaterial3D.pnl_model.Controls.Add(clsItem.FrmMaterial3D.viewportLayout);
			clsItem.FrmMaterial3D.viewportLayout.Entities.Clear();
			clsItem.FrmMaterial3D.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmMaterial3D.Material = new MaterialBase5(ccVars.activeMaterial);
			buEntity.Copy(ClamperEntity, ref clsItem.FrmMaterial3D.EntClamper);
			if (panel == null)
			{
				clsItem.FrmMaterial3D.Init(null);
			}
			else
			{
				clsItem.FrmMaterial3D.Init(panel.Material);
			}
			clsItem.FrmMaterial3D.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmMaterial3D.ShowDialog();
			if (clsItem.FrmMaterial3D.PropertiesForm.Result == DialogResult.OK)
			{
				ccVars.activeMaterial = new MaterialBase5(clsItem.FrmMaterial3D.Material);
				if ((clsVar5.shapeCreatePar.SingX < 0.0) & (clsVar5.shapeCreatePar.SingY < 0.0))
				{
					clsInit.cVector5.Move(0.0 - ccVars.activeMaterial.Size.Width, 0.0 - ccVars.activeMaterial.Size.Height, 0.0, ref ccVars.activeMaterial.Entities);
				}
				if (panel != null)
				{
					doEditPanel(selectedJobIndex, ccVars.activeMaterial);
				}
				else
				{
					AddPanel(ccVars.activeMaterial);
				}
			}
		}
		else
		{
			buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
		}
	}

	public void cmdHolesMenu()
	{
		if (timm != null)
		{
			if (timm.Enabled)
			{
				timm.Enabled = false;
			}
			else
			{
				timm.Enabled = true;
			}
		}
	}

	public void cmdCutsMenu()
	{
		list_1 = new List<buEntity>();
		RoundRect(350.0, 150.0, 25.0, isPlus: true, ref list_1);
	}

	public void cmdDrawingsMenu()
	{
		if (activeJob == null)
		{
			return;
		}
		if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
		{
			clsItem.FrmDrillList.Visible = false;
		}
		if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
		{
			clsItem.FrmProfilingList.Visible = false;
		}
		if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
		{
			clsItem.FrmJunctionList.Visible = false;
		}
		if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
		if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
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
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
			{
				clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i]);
			}
			clsItem.FrmShapeList.DataOk += ShapeChanged;
			clsItem.FrmShapeList.DataCancel += ShapeCancel;
		}
		buMWDrillVars.varCamContour.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
		buMWDrillVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
		clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Shape;
		clsItem.FrmShapeList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
		if (clsVar5.lastShape != null)
		{
			if (clsVar5.lastShape != null)
			{
				clsItem.FrmShapeList.selectedShape = buShape.Copy(clsVar5.lastShape);
				clsVar5.ShapeDataParameters.ShapeType = clsItem.FrmShapeList.selectedShape.ShapeType;
			}
		}
		else
		{
			clsItem.FrmShapeList.selectedShape = new buShapeRectangle(clsVar5.ShapeDataParameters.RectangleWidth, clsVar5.ShapeDataParameters.RectangleHeight);
			((buShapeRectangle)clsItem.FrmShapeList.selectedShape).ShapeType = ShapeTypes.Rectangle;
			clsVar5.ShapeDataParameters.ShapeType = ShapeTypes.Rectangle;
		}
		clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDrillVars.varCamContour.buPar);
		clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDrillVars.varCamContour.buPar);
		clsItem.FrmShapeList.PropertiesForm.TopMost = true;
		clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
		clsItem.FrmShapeList.TopMost = true;
		if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
		{
			clsItem.FrmShapeList.pnl_model.Controls.Add(clsItem.FrmShapeList.viewportLayout);
		}
		clsItem.FrmShapeList.viewportLayout.Entities.Clear();
		clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		if (clsItem.FrmMain != null)
		{
			clsItem.FrmShapeList.Owner = clsItem.FrmMain;
		}
		clsItem.FrmShapeList.Width = 410;
		clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmShapeList.ShowTool = true;
		clsItem.FrmShapeList.Tools.Clear();
		for (int j = 0; j <= ccVars.Tools.Count - 1; j++)
		{
			for (int k = 0; k <= ccVars.Tools[j].Tools.Count - 1; k++)
			{
				clsItem.FrmShapeList.Tools.Add(new ToolBase5(ccVars.Tools[j].Tools[k]));
			}
		}
		if (!EditOperation)
		{
			clsItem.FrmShapeList.activeTool = new ToolBase5(ccVars.toolActive);
		}
		else if (clsVar5.lastShape == null || clsVar5.lastShape.Tool == null)
		{
			clsItem.FrmShapeList.activeTool = new ToolBase5(ccVars.toolActive);
		}
		else
		{
			clsItem.FrmShapeList.activeTool = new ToolBase5(clsVar5.lastShape.Tool);
		}
		clsItem.FrmShapeList.Init();
		clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmShapeList.Show();
		clsItem.FrmShapeList.Top = 20;
		clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
	}

	public void cmdCornerMenu()
	{
		if (activeJob == null)
		{
			return;
		}
		if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
		{
			clsItem.FrmDrillList.Visible = false;
		}
		if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
		{
			clsItem.FrmShapeList.Visible = false;
		}
		if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
		{
			clsItem.FrmJunctionList.Visible = false;
		}
		if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
		if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
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
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
			{
				clsItem.FrmProfilingList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i]);
			}
			clsItem.FrmProfilingList.DataOk += ShapeChanged;
			clsItem.FrmProfilingList.DataCancel += ShapeCancel;
		}
		clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Profiling;
		clsItem.FrmProfilingList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
		if (clsVar5.lastProfiling != null)
		{
			if (clsVar5.lastProfiling is buShapeProfiling)
			{
				clsItem.FrmProfilingList.selectedShape = buShape.Copy(clsVar5.lastProfiling);
				clsVar5.ShapeDataParameters.ProfilingType = ((buShapeProfiling)clsItem.FrmProfilingList.selectedShape).ProfilingType;
			}
		}
		else
		{
			clsItem.FrmProfilingList.selectedShape = new buShapeProfiling(ProfilingTypes.ProfilingRectangle, clsVar5.ShapeDataParameters.ProfilingRadius, clsVar5.ShapeDataParameters.ProfilingDepth, clsVar5.ShapeDataParameters.ProfilingLength, clsVar5.ShapeDataParameters.ProfilingWidth, clsVar5.ShapeDataParameters.ProfilingHeight);
			((buShapeProfiling)clsItem.FrmProfilingList.selectedShape).ProfilingType = ProfilingTypes.ProfilingRectangle;
			clsVar5.ShapeDataParameters.ProfilingType = ProfilingTypes.ProfilingRectangle;
		}
		clsItem.FrmProfilingList.selectedShape.CamPar = new camParameters5();
		clsItem.FrmProfilingList.CamPar = new camParameters5();
		clsItem.FrmProfilingList.PropertiesForm.TopMost = true;
		clsItem.FrmProfilingList.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsItem.FrmProfilingList.StartPosition = FormStartPosition.Manual;
		clsItem.FrmProfilingList.TopMost = true;
		clsItem.FrmProfilingList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		if (clsItem.FrmProfilingList.pnl_model.Controls.Count == 0)
		{
			clsItem.FrmProfilingList.pnl_model.Controls.Add(clsItem.FrmProfilingList.viewportLayout);
		}
		clsItem.FrmProfilingList.viewportLayout.Entities.Clear();
		clsItem.FrmProfilingList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		if (clsItem.FrmMain != null)
		{
			clsItem.FrmProfilingList.Owner = clsItem.FrmMain;
		}
		clsItem.FrmProfilingList.Width = 410;
		clsItem.FrmProfilingList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmProfilingList.ShowTool = true;
		clsItem.FrmProfilingList.Tools.Clear();
		for (int j = 0; j <= ccVars.Tools.Count - 1; j++)
		{
			for (int k = 0; k <= ccVars.Tools[j].Tools.Count - 1; k++)
			{
				clsItem.FrmProfilingList.Tools.Add(new ToolBase5(ccVars.Tools[j].Tools[k]));
			}
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
		EditOperation = false;
		if (activeJob == null)
		{
			return;
		}
		if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
		{
			clsItem.FrmDrillList.Visible = false;
		}
		if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
		{
			clsItem.FrmProfilingList.Visible = false;
		}
		if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
		{
			clsItem.FrmShapeList.Visible = false;
		}
		if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
		{
			clsItem.FrmJunctionList.Visible = false;
		}
		if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
		if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
		if (!(activeJob.Material.Size.Width < 400.0))
		{
			if (!activeJob.MakeContour)
			{
				F_Contour f_Contour = new F_Contour();
				f_Contour.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				f_Contour.settingRuntime = new DrillRuntimeSettings(varDrillRunSettings);
				f_Contour.settingCNC = new DrillCNCSettings(varDrillCNCSettings);
				f_Contour.settingRuntime.lastContourPlaneNames = planeBoxNames.Top;
				f_Contour.Job = new DrillJob(activeJob);
				f_Contour.Init();
				f_Contour.StartPosition = FormStartPosition.CenterParent;
				f_Contour.ShowDialog();
				if (f_Contour.PropertiesForm.Result == DialogResult.OK)
				{
					buShape buShape2 = new buShape();
					buShape2.ShapeGroup = ShapeGroup.Contour;
					buShape2.OffsetDistance = varDrillRunSettings.ContourOffset;
					buShape2.Depth = varDrillRunSettings.ContourDepth;
					buShape2.planeName = varDrillRunSettings.lastContourPlaneNames;
					buShape2.ID = IDCounter;
					if (!CheckOperations(buShape2, ref operationErrorList) && operationErrorList.Count > 0)
					{
						DialogBoxList dialogBoxList = new DialogBoxList();
						dialogBoxList.Caption = buLangTranslate.preDef.Error;
						dialogBoxList.Width = 500;
						for (int i = 0; i <= operationErrorList.Count - 1; i++)
						{
							dialogBoxList.Items.Add(operationErrorList[i]);
						}
						dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
						dialogBoxList.Init();
						dialogBoxList.ShowDialog();
						if (dialogBoxList.Result != DialogResult.OK)
						{
							clsInit.appCommand.Reset();
							return;
						}
					}
					activeJob.Items.Add(buShape2);
					DrawPanelFromJobMainAndPreview(activeJob);
					SaveDrillFile();
					clsInit.appCommand.Reset();
					JobUpdate(FillPages: true, null);
					IDCounter++;
				}
			}
			else
			{
				activeJob.MakeContour = false;
			}
			JobUpdate(FillPages: true, null);
		}
		else
		{
			buString5.MessageBoxError(buDrillCalc.LangDrillMessage[42]);
		}
	}

	public void cmdEngraving()
	{
		if (activeJob == null)
		{
			return;
		}
		if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
		{
			clsItem.FrmDrillList.Visible = false;
		}
		if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
		{
			clsItem.FrmProfilingList.Visible = false;
		}
		if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
		{
			clsItem.FrmShapeList.Visible = false;
		}
		if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
		{
			clsItem.FrmJunctionList.Visible = false;
		}
		if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
		if (clsItem.FrmFromFile == null)
		{
			clsItem.FrmFromFile = new F_AddFromFile();
		}
		clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmFromFile.Path = varDrillRunSettings.pathEngraving;
		clsItem.FrmFromFile.KeepRatio = varDrillRunSettings.EngravingKeepRatio;
		clsItem.FrmFromFile.ExtensionList.Clear();
		clsItem.FrmFromFile.ExtensionList.Add(".stl");
		clsItem.FrmFromFile.ExtensionList.Add(".step");
		clsItem.FrmFromFile.ExtensionList.Add(".stp");
		clsItem.FrmFromFile.ExtensionList.Add(".iges");
		clsItem.FrmFromFile.ExtensionList.Add(".igs");
		clsItem.FrmFromFile.Init();
		clsItem.FrmFromFile.ShowDialog();
		if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		list_0.Clear();
		list_0 = new List<Entity>();
		for (int i = 0; i <= clsItem.FrmFromFile.viewport.Entities.Count - 1; i++)
		{
			Entity copiedEntity = null;
			if (!(clsItem.FrmFromFile.viewport.Entities[i] is Mesh))
			{
				if (clsItem.FrmFromFile.viewport.Entities[i] is Brep)
				{
					Mesh item = ((Brep)clsItem.FrmFromFile.viewport.Entities[i]).ConvertToMesh();
					list_0.Add(item);
				}
			}
			else
			{
				buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
				list_0.Add(copiedEntity);
			}
		}
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		clsInit.cVector5.BoxSizeCalculate(list_0, ref MinPoint, ref MidPoint, ref MaxPoint);
		clsInit.cVector5.Move(0.0 - MidPoint.X, 0.0 - MidPoint.Y, 0.0 - MinPoint.Z, ref list_0);
		varDrillRunSettings.pathEngraving = clsItem.FrmFromFile.Path;
		varDrillRunSettings.EngravingKeepRatio = clsItem.FrmFromFile.KeepRatio;
		if (list_0.Count > 0)
		{
			clsInit.cVector5.BoxSizeCalculate(list_0[0], ref MinPoint, ref MidPoint, ref MaxPoint);
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
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; j++)
				{
					clsItem.FrmEngraveList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[j]);
				}
				clsItem.FrmEngraveList.DataOk += ShapeChanged;
				clsItem.FrmEngraveList.DataCancel += ShapeCancel;
			}
			clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Engraving;
			clsItem.FrmEngraveList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
			clsItem.FrmEngraveList.selectedShape = new buShapeEngrave(clsVar5.ShapeDataParameters.EngravingDepth, clsVar5.ShapeDataParameters.EngravingWidth, clsVar5.ShapeDataParameters.EngravingHeight, list_0[0]);
			clsItem.FrmEngraveList.selectedShape.CamPar = new camParameters5();
			clsItem.FrmEngraveList.CamPar = new camParameters5();
			clsItem.FrmEngraveList.PropertiesForm.TopMost = true;
			clsItem.FrmEngraveList.PropertiesForm.FormPosition = FormStartPosition.Manual;
			clsItem.FrmEngraveList.StartPosition = FormStartPosition.Manual;
			clsItem.FrmEngraveList.TopMost = true;
			if (clsItem.FrmEngraveList.pnl_model.Controls.Count == 0)
			{
				clsItem.FrmEngraveList.pnl_model.Controls.Add(clsItem.FrmEngraveList.viewportLayout);
			}
			clsItem.FrmEngraveList.viewportLayout.Entities.Clear();
			clsItem.FrmEngraveList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			if (clsItem.FrmMain != null)
			{
				clsItem.FrmEngraveList.Owner = clsItem.FrmMain;
			}
			clsItem.FrmEngraveList.Width = 410;
			if (list_0.Count <= 0)
			{
			}
			buEntity.Copy(list_0, ref clsVar5.shapeCreatePar.entitiesEngraving);
			clsItem.FrmEngraveList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmEngraveList.Init();
			clsItem.FrmEngraveList.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmEngraveList.Show();
			clsItem.FrmEngraveList.Top = 20;
			clsItem.FrmEngraveList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmEngraveList.Width;
		}
		SaveDrillFile();
	}

	public void cmdJunctionMenu()
	{
		if (activeJob == null)
		{
			return;
		}
		if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
		{
			clsItem.FrmDrillList.Visible = false;
		}
		if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
		{
			clsItem.FrmProfilingList.Visible = false;
		}
		if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
		{
			clsItem.FrmShapeList.Visible = false;
		}
		if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
		if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
		{
			clsItem.FrmSlotList.Visible = false;
		}
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
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
			{
				clsItem.FrmJunctionList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i]);
			}
			clsItem.FrmJunctionList.DataOk += ShapeChanged;
			clsItem.FrmJunctionList.DataCancel += ShapeCancel;
		}
		clsVar5.ShapeDataParameters.ShapeGroup = ShapeGroup.Junction;
		clsItem.FrmJunctionList.parShape = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
		if (clsVar5.lastJunction != null)
		{
			if (clsVar5.lastJunction is buShapeJunction)
			{
				clsItem.FrmJunctionList.selectedShape = buShape.Copy(clsVar5.lastJunction);
				clsVar5.ShapeDataParameters.JunctionType = ((buShapeJunction)clsItem.FrmJunctionList.selectedShape).JunctionType;
			}
		}
		else
		{
			clsItem.FrmJunctionList.selectedShape = new buShapeJunction(JunctionTypes.Junction3HoleIntersectHorizontal, clsVar5.ShapeDataParameters.JunctionDiameter, clsVar5.ShapeDataParameters.JunctionDepth, clsVar5.ShapeDataParameters.JunctionDiameterOutside, clsVar5.ShapeDataParameters.JunctionDistance, clsVar5.ShapeDataParameters.isMillingJunction);
			clsVar5.ShapeDataParameters.JunctionType = JunctionTypes.Junction3HoleIntersectHorizontal;
		}
		clsItem.FrmJunctionList.selectedShape.CamPar = new camParameters5();
		clsItem.FrmJunctionList.CamPar = new camParameters5();
		clsItem.FrmJunctionList.PropertiesForm.TopMost = true;
		clsItem.FrmJunctionList.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsItem.FrmJunctionList.StartPosition = FormStartPosition.Manual;
		clsItem.FrmJunctionList.TopMost = true;
		if (clsItem.FrmJunctionList.pnl_model.Controls.Count == 0)
		{
			clsItem.FrmJunctionList.pnl_model.Controls.Add(clsItem.FrmJunctionList.viewportLayout);
		}
		clsItem.FrmJunctionList.viewportLayout.Entities.Clear();
		clsItem.FrmJunctionList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		if (clsItem.FrmMain != null)
		{
			clsItem.FrmJunctionList.Owner = clsItem.FrmMain;
		}
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
			{
				clsItem.FrmDrillList.Visible = false;
			}
			if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
			{
				clsItem.FrmProfilingList.Visible = false;
			}
			if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
			{
				clsItem.FrmShapeList.Visible = false;
			}
			if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
			{
				clsItem.FrmJunctionList.Visible = false;
			}
			if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
			{
				clsItem.FrmSlotList.Visible = false;
			}
			if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
			{
				clsItem.FrmSlotList.Visible = false;
			}
			F_VectorText f_VectorText = new F_VectorText();
			f_VectorText.TextData = new TextVectorData(clsVar.varInterface.VectorTextVar);
			f_VectorText.Init();
			f_VectorText.ShowDialog();
			if (f_VectorText.Result != DialogResult.OK)
			{
				return;
			}
			clsVar.varInterface.VectorTextVar = new TextVectorData(f_VectorText.TextData);
			ccVars.VectorTextRunVar.Alignment = clsVar.varInterface.VectorTextVar.Alignment;
			ccVars.VectorTextRunVar.DrawAsCurve = clsVar.varInterface.VectorTextVar.DrawAsCurve;
			ccVars.VectorTextRunVar.Height = clsVar.varInterface.VectorTextVar.Height;
			ccVars.VectorTextRunVar.Text = clsVar.varInterface.VectorTextVar.Text;
			clsFiles.SaveParameter();
			clsInit.appCommand.VectorTextCreate(clsVar.varInterface.VectorTextVar.Text, clsVar.varInterface.VectorTextVar.Font, clsVar.varInterface.VectorTextVar.Height, ccVars.VectorTextRunVar.Alignment, ccVars.planeActive, ref ccVars.ContourPoints);
			if (activeJob == null)
			{
				return;
			}
			clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
			clsVar5.shapeCreatePar.entitiesCurve.Clear();
			for (int i = 0; i <= ccVars.ContourPoints.Count - 1; i++)
			{
				List<Point3D> CopiedPnt = new List<Point3D>();
				buConversion5.Pnt3DToPoint3D(ccVars.ContourPoints[i].Outter, ref CopiedPnt);
				buLinearPath another = new buLinearPath(CopiedPnt);
				buCompositeCurve item = new buCompositeCurve(another);
				clsVar5.shapeCreatePar.entitiesCurve.Add(item);
				for (int j = 0; j <= ccVars.ContourPoints[i].Holes.Count - 1; j++)
				{
					List<Point3D> CopiedPnt2 = new List<Point3D>();
					buConversion5.Pnt3DToPoint3D(ccVars.ContourPoints[i].Holes[j], ref CopiedPnt2);
					another = new buLinearPath(CopiedPnt2);
					item = new buCompositeCurve(another);
					clsVar5.shapeCreatePar.entitiesCurve.Add(item);
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
				for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; k++)
				{
					clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[k]);
				}
				clsItem.FrmShapeList.DataOk += ShapeChanged;
				clsItem.FrmShapeList.DataCancel += ShapeCancel;
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
			clsItem.FrmShapeList.selectedShape = new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
			clsItem.FrmShapeList.selectedShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
			clsItem.FrmShapeList.selectedShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
			clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDrillVars.varCamContour.buPar);
			clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDrillVars.varCamContour.buPar);
			clsItem.FrmShapeList.PropertiesForm.TopMost = true;
			clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
			clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
			clsItem.FrmShapeList.TopMost = true;
			if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
			{
				clsItem.FrmShapeList.pnl_model.Controls.Add(clsItem.FrmShapeList.viewportLayout);
			}
			clsItem.FrmShapeList.viewportLayout.Entities.Clear();
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			if (clsItem.FrmMain != null)
			{
				clsItem.FrmShapeList.Owner = clsItem.FrmMain;
			}
			clsItem.FrmShapeList.Width = 410;
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmShapeList.Init();
			clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmShapeList.Show();
			clsItem.FrmShapeList.Top = 20;
			clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdLibraryMenu()
	{
		try
		{
			if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
			{
				clsItem.FrmDrillList.Visible = false;
			}
			if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
			{
				clsItem.FrmProfilingList.Visible = false;
			}
			if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
			{
				clsItem.FrmShapeList.Visible = false;
			}
			if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
			{
				clsItem.FrmJunctionList.Visible = false;
			}
			if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
			{
				clsItem.FrmSlotList.Visible = false;
			}
			if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
			{
				clsItem.FrmSlotList.Visible = false;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(clsVar.varLibrary.pathLibrary);
			if (!directoryInfo.Exists)
			{
				clsVar.varLibrary.pathLibrary = AppPath.Base + "\\Library";
			}
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
			if (activeJob == null)
			{
				return;
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
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
				{
					clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i]);
				}
				clsItem.FrmShapeList.DataOk += ShapeChanged;
				clsItem.FrmShapeList.DataCancel += ShapeCancel;
			}
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(clsVar5.shapeCreatePar.entitiesCurve, ref MinPoint, ref MaxPoint);
			clsVar5.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
			clsVar5.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
			clsItem.FrmShapeList.selectedShape = new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
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
			{
				clsItem.FrmShapeList.pnl_model.Controls.Add(clsItem.FrmShapeList.viewportLayout);
			}
			clsItem.FrmShapeList.viewportLayout.Entities.Clear();
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			if (clsItem.FrmMain != null)
			{
				clsItem.FrmShapeList.Owner = clsItem.FrmMain;
			}
			clsItem.FrmShapeList.Width = 410;
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmShapeList.Init();
			clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmShapeList.Show();
			clsItem.FrmShapeList.Top = 20;
			clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdFromFileMenu()
	{
		try
		{
			if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
			{
				clsItem.FrmDrillList.Visible = false;
			}
			if (clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.Visible)
			{
				clsItem.FrmProfilingList.Visible = false;
			}
			if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
			{
				clsItem.FrmShapeList.Visible = false;
			}
			if (clsItem.FrmJunctionList != null && clsItem.FrmJunctionList.Visible)
			{
				clsItem.FrmJunctionList.Visible = false;
			}
			if (clsItem.FrmSlotList != null && clsItem.FrmSlotList.Visible)
			{
				clsItem.FrmSlotList.Visible = false;
			}
			if (clsItem.FrmEngraveList != null && clsItem.FrmSlotList.Visible)
			{
				clsItem.FrmSlotList.Visible = false;
			}
			if (clsItem.FrmFromFile == null)
			{
				clsItem.FrmFromFile = new F_AddFromFile();
			}
			clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmFromFile.Path = clsVar.varEditorRuntimeSet.pathFromFile;
			clsItem.FrmFromFile.KeepRatio = clsVar.varEditorRuntimeSet.FromFileKeepRatio;
			clsItem.FrmFromFile.Init();
			clsItem.FrmFromFile.ShowDialog();
			if (clsItem.FrmFromFile.PropertiesForm.Result == DialogResult.OK)
			{
				clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
				for (int i = 0; i <= clsItem.FrmFromFile.viewport.Entities.Count - 1; i++)
				{
					buEntity copiedEntity = null;
					buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
					clsVar5.shapeCreatePar.entitiesCurve.Add(copiedEntity);
				}
				clsVar.varEditorRuntimeSet.pathFromFile = clsItem.FrmFromFile.Path;
				clsVar.varEditorRuntimeSet.FromFileKeepRatio = clsItem.FrmFromFile.KeepRatio;
				clsInit.appEditor.SaveEditorFile();
			}
			if (activeJob == null)
			{
				return;
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
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; j++)
				{
					clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[j]);
				}
				clsItem.FrmShapeList.DataOk += ShapeChanged;
				clsItem.FrmShapeList.DataCancel += ShapeCancel;
			}
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(clsVar5.shapeCreatePar.entitiesCurve, ref MinPoint, ref MaxPoint);
			clsVar5.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
			clsVar5.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
			clsItem.FrmShapeList.selectedShape = new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
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
			{
				clsItem.FrmShapeList.pnl_model.Controls.Add(clsItem.FrmShapeList.viewportLayout);
			}
			clsItem.FrmShapeList.viewportLayout.Entities.Clear();
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			if (clsItem.FrmMain != null)
			{
				clsItem.FrmShapeList.Owner = clsItem.FrmMain;
			}
			clsItem.FrmShapeList.Width = 410;
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmShapeList.Init();
			clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmShapeList.Show();
			clsItem.FrmShapeList.Top = 20;
			clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdFromDrawing()
	{
		try
		{
			if (clsItem.frmEditor == null)
			{
				clsItem.frmEditor = new F_Editor();
			}
			clsItem.frmEditor = new F_Editor();
			clsVar.varEditorRuntimeSet.isSewingMode = false;
			clsVar.varEditorRuntimeSet.isSketchMode = false;
			clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.frmEditor.Init();
			clsItem.frmEditor.ShowDialog();
			clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
			for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
			{
				buEntity copiedEntity = null;
				buEntity.Copy(clsItem.frmEditor.viewport.Entities[i], ref copiedEntity);
				clsVar5.shapeCreatePar.entitiesCurve.Add(copiedEntity);
			}
			clsInit.appEditor.SaveEditorFile();
			if (activeJob == null)
			{
				return;
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
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; j++)
				{
					clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[j]);
				}
				clsItem.FrmShapeList.DataOk += ShapeChanged;
				clsItem.FrmShapeList.DataCancel += ShapeCancel;
			}
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(clsVar5.shapeCreatePar.entitiesCurve, ref MinPoint, ref MaxPoint);
			clsVar5.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
			clsVar5.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
			clsItem.FrmShapeList.selectedShape = new buShapeFreeDraw(clsVar5.ShapeDataParameters.FreeDrawWidth, clsVar5.ShapeDataParameters.FreeDrawHeight, clsVar5.ShapeDataParameters.FreeDrawDepth, clsVar5.ShapeDataParameters.FreeDrawAngle);
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
			{
				clsItem.FrmShapeList.pnl_model.Controls.Add(clsItem.FrmShapeList.viewportLayout);
			}
			clsItem.FrmShapeList.viewportLayout.Entities.Clear();
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			if (clsItem.FrmMain != null)
			{
				clsItem.FrmShapeList.Owner = clsItem.FrmMain;
			}
			clsItem.FrmShapeList.Width = 410;
			clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmShapeList.Init();
			clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmShapeList.Show();
			clsItem.FrmShapeList.Top = 20;
			clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdStartSimulation(bool Step)
	{
		timSim.Interval = varDrillMachineSettings.SimulationIntervalMs;
		varDrillRunSettings.StepRun = Step;
		if (!viewportAuto.IsAnimationRunning)
		{
			viewportAuto.StartAnimation(varDrillSettings.simulationInterval);
		}
		if (indexSim == -1)
		{
			indexSim = 0;
		}
		timSim.Enabled = true;
		if (Step)
		{
			if (varDrillRunSettings.StepRun && Step)
			{
				varTemps.simRelease = true;
			}
		}
		else
		{
			varDrillRunSettings.StepRun = false;
			viewportAuto.Entities.ClearSelection();
			viewportAuto.Invalidate();
			varTemps.activeMove.isActive = true;
		}
	}

	public void cmdStopSimulation()
	{
		if (!timSim.Enabled)
		{
			indexSim = 0;
			timSim.Enabled = false;
			isCollisionRunning = false;
		}
		else
		{
			timSim.Enabled = false;
		}
	}

	public void cmdNextSimulation()
	{
		if (indexSim > 0)
		{
			tick_Simulation(null, null);
		}
	}

	public void cmdPreSimulation()
	{
		if (indexSim > 0)
		{
			indexSim -= varDrillRunSettings.SimStep;
			indexSim -= varDrillRunSettings.SimStep;
			tick_Simulation(null, null);
		}
	}

	public void cmdGoLineSimulation(int Line)
	{
		if (indexSim <= 0)
		{
			return;
		}
		for (int i = 0; i <= activeJob.SimulationMoves.Count - 1; i++)
		{
			if (activeJob.SimulationMoves[i].LineIndex == Line)
			{
				indexSim = i;
				break;
			}
		}
		tick_Simulation(null, null);
	}

	public void cmdSaveCode()
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count > 0)
			{
				if (activeJob != null)
				{
					if (!isOperationActive())
					{
						SaveFileDialog saveFileDialog = new SaveFileDialog();
						saveFileDialog.InitialDirectory = varDrillRunSettings.pathSaveCode;
						saveFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
						saveFileDialog.FilterIndex = 1;
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							varDrillRunSettings.pathSaveCode = buFile5.GetPath(saveFileDialog.FileName);
							SaveDrillJobFile(saveFileDialog.FileName, activeJob);
							SaveDrillFile();
						}
					}
					else
					{
						buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
					}
				}
				else
				{
					buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31]);
				}
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
			}
		}
		else
		{
			MessageBox.Show("Not Available in Demo Mode");
		}
	}

	public void cmdSaveCodeAll()
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count > 0)
			{
				if (activeJob != null)
				{
					if (!isOperationActive())
					{
						SaveFileDialog saveFileDialog = new SaveFileDialog();
						saveFileDialog.InitialDirectory = varDrillRunSettings.pathSaveCode;
						saveFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
						saveFileDialog.FilterIndex = 1;
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							varDrillRunSettings.pathSaveCode = buFile5.GetPath(saveFileDialog.FileName);
							SaveDrillJobFile(saveFileDialog.FileName, activeJob, SaveAll: true);
							SaveDrillFile();
						}
					}
					else
					{
						buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
					}
				}
				else
				{
					buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31]);
				}
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
			}
		}
		else
		{
			MessageBox.Show("Not Available in Demo Mode");
		}
	}

	public void cmdOpenCode()
	{
		if (!isOperationActive())
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = varDrillRunSettings.pathOpenCode;
			openFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog.FileName);
				OpenDrillJobFile(openFileDialog.FileName, ref activeJob);
			}
		}
		else
		{
			buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
		}
	}

	public void cmdOpenCodeAll()
	{
		if (!isOperationActive())
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = varDrillRunSettings.pathOpenCode;
			openFileDialog.Filter = "AES Drill File (*.AESjob)|*.AESjob";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog.FileName);
				OpenDrillJobFile(openFileDialog.FileName, ref activeJob, OpenAll: true);
			}
		}
		else
		{
			buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
		}
	}

	public bool cmdFileOpenPreview(bool OpenAll = false, string InitPath = "")
	{
		try
		{
			openFileDialog_0 = new OpenFileDialog();
			openDialogCtrlPreview.Extensions.Clear();
			openFileDialog_0.Filter = "AES Drill File (*.AESjob)|*.AESjob";
			openDialogCtrlPreview.Extensions.Add("AES Drill File (*.AESjob)|*.AESjob");
			string pathOpenCode = varDrillRunSettings.pathOpenCode;
			int filterIndex = 1;
			openDialogCtrlPreview.Properties = new FileOpenModes(clsVar.varFile.FileOpenMode);
			clsVar.PreviewLoaded = true;
			openDialogCtrlPreview.SubFolder = true;
			openDialogCtrlPreview.FileDlgCaption = AppLanguage.CadCamDynamic[32] + " " + AppLanguage.CadCamDynamic[31];
			openDialogCtrlPreview.FileDlgOkCaption = AppLanguage.CadCamDynamic[31];
			openDialogCtrlPreview.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			openDialogCtrlPreview.SubFolder = clsVar.varFile.FileOpenMode.SubFolder;
			openDialogCtrlPreview.ShowInfoButton = clsVar.varFile.FileOpenMode.ShowInfoButton;
			openDialogCtrlPreview.ShowPreviewDisable = clsVar.varFile.FileOpenMode.ShowDisablePreview;
			openDialogCtrlPreview.ShowLoading(Show: false);
			openDialogCtrlPreview.Init();
			openFileDialog_0.AddExtension = true;
			openDialogCtrlPreview.PreviewEnable = true;
			openFileDialog_0.InitialDirectory = pathOpenCode;
			if (InitPath.Trim().Length > 0)
			{
				openFileDialog_0.InitialDirectory = InitPath;
			}
			openFileDialog_0.FilterIndex = filterIndex;
			openFileDialog_0.CheckFileExists = true;
			openFileDialog_0.DefaultExt = "bucad";
			openFileDialog_0.FileName = "";
			openFileDialog_0.DereferenceLinks = true;
			DialogResult dialogResult = openFileDialog_0.ShowDialog(openDialogCtrlPreview, clsItem.FrmMain);
			if (dialogResult != DialogResult.OK)
			{
				return false;
			}
			varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog_0.FileName);
			OpenDrillJobFile(openFileDialog_0.FileName, ref activeJob, OpenAll);
			SaveDrillFile();
			return true;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public void cmdShowCode(bool CreateCode = false, string FileName = "")
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count > 0)
			{
				if (activeJob != null)
				{
					if (!isOperationActive())
					{
						string text = "";
						List<string> stringList = new List<string>();
						if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
						{
							SaveDrillJobFile(ref stringList, activeJob);
						}
						if (MachType == DrillMachineType.GoWithAtc)
						{
							cGoAtc.CreatCodeFromJobItem(ref activeJob);
							cGoAtc.cmdCreateCodes(ref stringList, activeJob);
						}
						if (MachType == DrillMachineType.Sirius)
						{
							cGoSirius.CreatCodeFromJobItem(ref activeJob);
							cGoSirius.cmdCreateCodes(ref stringList, activeJob);
						}
						text = buString5.StringListToString(stringList, NewLineEnable: true);
						if (CreateCode)
						{
							if (MachType == DrillMachineType.GoWithAtc)
							{
								cGoAtc.cmdCreateCode(text, FileName);
							}
							if (MachType == DrillMachineType.Sirius)
							{
								cGoSirius.cmdCreateCode(text, FileName);
							}
						}
						else
						{
							F_Notepad f_Notepad = new F_Notepad();
							f_Notepad.Init(text);
							f_Notepad.Show();
						}
					}
					else
					{
						buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
					}
				}
				else
				{
					buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31]);
				}
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
			}
		}
		else
		{
			MessageBox.Show("Not Available in Demo Mode");
		}
	}

	public void cmdSimilation()
	{
		if (activeJob == null)
		{
			return;
		}
		if (!isOperationActive())
		{
			if (frmMachSim == null)
			{
				frmMachSim = new F_DrillMachSim();
				frmMachSim.ValueChanged += SimValueChaned;
			}
			if (viewportAuto.Layers.Count != ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count)
			{
				viewportAuto.Layers.Clear();
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
				{
					viewportAuto.Layers.Add((Layer)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Clone());
				}
			}
			activeJob.Cams.Clear();
			if (varDrillCNCSettings.FindFastestPattern)
			{
				doFindFastestPattern();
			}
			else
			{
				if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
				{
					cGoUltra2Up1Down.CreatCodeFromJobItem(ref activeJob);
				}
				if (MachType == DrillMachineType.GoWithAtc)
				{
					cGoAtc.CreatCodeFromJobItem(ref activeJob);
				}
				if (MachType == DrillMachineType.Sirius)
				{
					cGoSirius.CreatCodeFromJobItem(ref activeJob);
				}
			}
			indexSim = 0;
			frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			frmMachSim.MachType = MachType;
			frmMachSim.Init();
			frmMachSim.StartPosition = FormStartPosition.CenterParent;
			frmMachSim.ShowDialog();
			DrawPanelFromJobMainAndPreview(activeJob);
			if (frmMachSim.PropertiesForm.Result != DialogResult.OK)
			{
			}
		}
		else
		{
			buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
		}
	}

	public void cmdShowToolsCommon()
	{
		if (!isOperationActive())
		{
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				cGoUltra2Up1Down.cmdShowTools();
			}
			if (MachType == DrillMachineType.GoWithAtc && cGoAtc.cmdShowTools())
			{
				SaveDrillFile();
				SaveToolConfigFile(fileNameToolSetting);
			}
			if (MachType == DrillMachineType.Sirius && cGoSirius.cmdShowTools())
			{
				SaveDrillFile();
				SaveToolConfigFile(fileNameToolSetting);
			}
		}
		else
		{
			buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
		}
	}

	public void cmdShowToolsRecommend()
	{
		if (!isOperationActive())
		{
			if (FrmTools == null)
			{
				FrmTools = new F_Tools();
			}
			FrmTools.fileNameLeftTools = AppPath.MachineSimConfig + "\\Tools\\LeftToolGroups.step";
			FrmTools.fileNameRightTools = AppPath.MachineSimConfig + "\\Tools\\RightToolGroups.step";
			FrmTools.fileNameBottomTools = AppPath.MachineSimConfig + "\\Tools\\BottomToolGroups.step";
			CreateModelProperties createModelProperties = new CreateModelProperties();
			if (FrmTools.viewportLeft == null)
			{
				createModelProperties = new CreateModelProperties();
				createModelProperties.CoordinateSystemIconVisible = false;
				createModelProperties.OriginSymbolVisible = false;
				createModelProperties.ViewCubeIconVisible = false;
				createModelProperties.OrigineCaptionVisible = false;
				createModelProperties.ToolBorVisible = false;
				createModelProperties.BottomColor = Color.LightGray;
				createModelProperties.MiddleColor = Color.WhiteSmoke;
				createModelProperties.TopColor = Color.LightGray;
				createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
				createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
				createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
				FrmTools.viewportLeft = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, createModelProperties);
				FrmTools.viewportLeft.Name = "viewportLeft";
				FrmTools.pnl_viewportleft.Controls.Add(FrmTools.viewportLeft);
			}
			if (FrmTools.viewportRight == null)
			{
				createModelProperties = new CreateModelProperties();
				createModelProperties.CoordinateSystemIconVisible = false;
				createModelProperties.OriginSymbolVisible = false;
				createModelProperties.ViewCubeIconVisible = false;
				createModelProperties.OrigineCaptionVisible = false;
				createModelProperties.ToolBorVisible = false;
				createModelProperties.BottomColor = Color.LightGray;
				createModelProperties.MiddleColor = Color.WhiteSmoke;
				createModelProperties.TopColor = Color.LightGray;
				createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
				createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
				createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
				FrmTools.viewportRight = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, createModelProperties);
				FrmTools.viewportRight.Name = "viewportRight";
				FrmTools.pnl_viewportright.Controls.Add(FrmTools.viewportRight);
			}
			if (FrmTools.viewportBottom == null)
			{
				createModelProperties = new CreateModelProperties();
				createModelProperties.CoordinateSystemIconVisible = false;
				createModelProperties.OriginSymbolVisible = false;
				createModelProperties.ViewCubeIconVisible = false;
				createModelProperties.OrigineCaptionVisible = false;
				createModelProperties.ToolBorVisible = false;
				createModelProperties.BottomColor = Color.LightGray;
				createModelProperties.MiddleColor = Color.WhiteSmoke;
				createModelProperties.TopColor = Color.LightGray;
				createModelProperties.PanMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
				createModelProperties.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
				createModelProperties.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
				createModelProperties.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
				FrmTools.viewportBottom = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, createModelProperties);
				FrmTools.viewportBottom.Name = "viewportBottom";
				FrmTools.pnl_viewportbottom.Controls.Add(FrmTools.viewportBottom);
			}
			FrmTools.StartPosition = FormStartPosition.CenterParent;
			FrmTools.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			FrmTools.settingRuntime = new DrillRuntimeSettings(varDrillRunSettings);
			FrmTools.Init();
			FrmTools.ShowDialog();
			if (FrmTools.PropertiesForm.Result != DialogResult.OK)
			{
				return;
			}
			for (int i = 0; i <= ToolList.Count - 1; i++)
			{
				if (ToolList[i].Data.No == 80)
				{
					toolTop = new ToolBase5(ToolList[i]);
				}
				if (ToolList[i].Data.No == 270)
				{
					toolBottom = new ToolBase5(ToolList[i]);
				}
			}
			varDrillRunSettings = new DrillRuntimeSettings(FrmTools.settingRuntime);
			SaveDrillFile();
			SaveToolConfigFile(fileNameToolSetting);
		}
		else
		{
			buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[64]);
		}
	}

	public void cmdShowSlotSettings()
	{
		try
		{
			F_SlotSettings f_SlotSettings = new F_SlotSettings();
			f_SlotSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
			f_SlotSettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
			f_SlotSettings.varCNC = new DrillCNCSettings(varDrillCNCSettings);
			f_SlotSettings.Init();
			f_SlotSettings.ShowDialog();
			if (f_SlotSettings.PropertiesForm.Result == DialogResult.OK)
			{
				varDrillCNCSettings = f_SlotSettings.varCNC;
				SaveDrillFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdShowCNCSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = buLangTranslate.preDef.Setting;
			f_ClassViewerDialog.Value = varDrillCNCSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 700;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				varDrillCNCSettings = new DrillCNCSettings((DrillCNCSettings)f_ClassViewerDialog.Value);
				SaveDrillFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdShowSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = buLangTranslate.preDef.Setting;
			f_ClassViewerDialog.Value = varDrillSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				varDrillSettings = new DrillSettings((DrillSettings)f_ClassViewerDialog.Value);
				SaveDrillFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdShowMachineSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = buLangTranslate.preDef.Machine + " " + buLangTranslate.preDef.Setting;
			f_ClassViewerDialog.Value = varDrillMachineSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				varDrillMachineSettings = new DrillMachineSettings((DrillMachineSettings)f_ClassViewerDialog.Value);
				SaveDrillFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdRender()
	{
		try
		{
			Entity entPanel = null;
			DrawAsRenderFromJob(activeJob, ref entPanel);
			if (entPanel != null)
			{
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
					string fullName = fileInfo.FullName;
					CreateMaterialsAndLayers(fullName);
					entPanel.LayerName = "Wood";
				}
				clsItem.FrmPreview.viewportLayout.ActiveViewport.DisplayMode = displayType.Rendered;
				clsItem.FrmPreview.viewportLayout.Entities.Clear();
				entPanel.ColorMethod = colorMethodType.byLayer;
				clsItem.FrmPreview.viewportLayout.Entities.Add(entPanel);
				clsItem.FrmPreview.viewportLayout.SetView(viewType.Trimetric, fit: true, animate: false);
				clsItem.FrmPreview.Init();
				clsItem.FrmPreview.Show();
				clsItem.FrmPreview.viewportLayout.Invalidate();
				clsItem.FrmPreview.Focus();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdGetDrillsFrom3D()
	{
		try
		{
			List<Entity> selectedEntities = new List<Entity>();
			SelectionOption selectionOption = new SelectionOption();
			selectionOption.Text = false;
			selectionOption.Point = false;
			clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
			if (selectedEntities.Count != 0)
			{
				doGetDrill(selectedEntities);
				return;
			}
			if (clsItem.FrmFromFile == null)
			{
				clsItem.FrmFromFile = new F_AddFromFile();
			}
			clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmFromFile.Path = varDrillRunSettings.path3DJob;
			clsItem.FrmFromFile.KeepRatio = varDrillRunSettings.EngravingKeepRatio;
			clsItem.FrmFromFile.ExtensionList.Clear();
			clsItem.FrmFromFile.ExtensionList.Add(".step");
			clsItem.FrmFromFile.ExtensionList.Add(".stp");
			clsItem.FrmFromFile.ExtensionList.Add(".iges");
			clsItem.FrmFromFile.ExtensionList.Add(".igs");
			clsItem.FrmFromFile.ExtensionList.Add(".bucadv5");
			clsItem.FrmFromFile.Init();
			clsItem.FrmFromFile.ShowDialog();
			if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
			{
				return;
			}
			varDrillRunSettings.path3DJob = clsItem.FrmFromFile.Path;
			selectedEntities = new List<Entity>();
			for (int i = 0; i <= clsItem.FrmFromFile.viewport.Entities.Count - 1; i++)
			{
				Entity copiedEntity = null;
				if (!(clsItem.FrmFromFile.viewport.Entities[i] is Brep))
				{
					if (clsItem.FrmFromFile.viewport.Entities[i] is Solid)
					{
						buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
						selectedEntities.Add(copiedEntity);
					}
				}
				else
				{
					buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
					selectedEntities.Add(copiedEntity);
				}
			}
			doGetDrill(selectedEntities);
			SaveDrillFile();
		}
		catch (Exception)
		{
		}
	}

	public void cmdGetDrillsFromCabinet()
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = varDrillRunSettings.path3DJob;
			openFileDialog.Filter = "Cabinet AES File (*.AESNC)|*.AESNC";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				OpenCabinetFile(openFileDialog.FileName, ref activeJob);
				varDrillRunSettings.path3DJob = buFile5.GetPath(openFileDialog.FileName);
				SaveDrillFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public bool cmdFileOpenFromCabinetPreview(bool OpenAll = false, string InitPath = "")
	{
		try
		{
			openFileDialog_0 = new OpenFileDialog();
			openDialogCtrlPreview.Extensions.Clear();
			openFileDialog_0.Filter = "AES Drill File (*.AESNC)|*.AESNC";
			openDialogCtrlPreview.Extensions.Add("AES Drill File (*.AESNC)|*.AESNC");
			string pathOpenCode = varDrillRunSettings.pathOpenCode;
			int filterIndex = 1;
			openDialogCtrlPreview.Properties = new FileOpenModes(clsVar.varFile.FileOpenMode);
			clsVar.PreviewLoaded = true;
			openDialogCtrlPreview.SubFolder = true;
			openDialogCtrlPreview.FileDlgCaption = AppLanguage.CadCamDynamic[32] + " " + AppLanguage.CadCamDynamic[31];
			openDialogCtrlPreview.FileDlgOkCaption = AppLanguage.CadCamDynamic[31];
			openDialogCtrlPreview.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			openDialogCtrlPreview.SubFolder = clsVar.varFile.FileOpenMode.SubFolder;
			openDialogCtrlPreview.ShowInfoButton = clsVar.varFile.FileOpenMode.ShowInfoButton;
			openDialogCtrlPreview.ShowPreviewDisable = clsVar.varFile.FileOpenMode.ShowDisablePreview;
			openDialogCtrlPreview.ShowLoading(Show: false);
			openDialogCtrlPreview.Init();
			openFileDialog_0.AddExtension = true;
			openDialogCtrlPreview.PreviewEnable = true;
			openFileDialog_0.InitialDirectory = pathOpenCode;
			if (InitPath.Trim().Length > 0)
			{
				openFileDialog_0.InitialDirectory = InitPath;
			}
			openFileDialog_0.FilterIndex = filterIndex;
			openFileDialog_0.CheckFileExists = true;
			openFileDialog_0.DefaultExt = "bucad";
			openFileDialog_0.FileName = "";
			openFileDialog_0.DereferenceLinks = true;
			DialogResult dialogResult = openFileDialog_0.ShowDialog(openDialogCtrlPreview, clsItem.FrmMain);
			if (dialogResult != DialogResult.OK)
			{
				return false;
			}
			varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog_0.FileName);
			OpenCabinetFile(openFileDialog_0.FileName, ref activeJob);
			return true;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public void cmdFileCabinetConversion()
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathImport);
			if (directoryInfo.Exists)
			{
				varDrillRunSettings.pathOpenCode = varDrillRunSettings.CabinetpathImport;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = varDrillRunSettings.pathOpenCode;
			openFileDialog.Filter = "Cabinet Job List(*.txt)|*.txt";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog.FileName);
				OpenCabinetJobListFile(openFileDialog.FileName);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdFileCabinetSettings()
	{
		try
		{
			F_CabinetSettings f_CabinetSettings = new F_CabinetSettings();
			f_CabinetSettings.Settings = new DrillRuntimeSettings(varDrillRunSettings);
			f_CabinetSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
			f_CabinetSettings.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
			f_CabinetSettings.Init();
			f_CabinetSettings.ShowDialog();
			if (f_CabinetSettings.PropertiesForm.Result == DialogResult.OK)
			{
				varDrillRunSettings = new DrillRuntimeSettings(f_CabinetSettings.Settings);
				SaveDrillFile();
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdFileCabinetCycle()
	{
		try
		{
			FrmCabinetCycle = new F_CabinetCycle();
			FrmCabinetCycle.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			FrmCabinetCycle.PropertiesForm.FormPosition = FormStartPosition.CenterParent;
			FrmCabinetCycle.Init();
			timCabinetCycle.Enabled = true;
			FrmCabinetCycle.ShowDialog();
			timCabinetCycle.Enabled = false;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdGetDrillsFromCyncly()
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = varDrillRunSettings.path3DJob;
			openFileDialog.Filter = "Cyncly AES File (*.xml)|*.xml";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				varDrillRunSettings.path3DJob = buFile5.GetPath(openFileDialog.FileName);
				SaveDrillFile();
				OpenCynClyFile(openFileDialog.FileName, ref activeJob);
			}
		}
		catch (Exception)
		{
		}
	}

	public bool cmdFileOpenFromCorpusPreview(bool OpenAll = false, string InitPath = "")
	{
		try
		{
			openFileDialog_0 = new OpenFileDialog();
			openDialogCtrlPreview.Extensions.Clear();
			openFileDialog_0.Filter = "Corpus Drill File (*.dxf)|*.dxf";
			openDialogCtrlPreview.Extensions.Add("Corpus Drill File (*.dxf)|*.dxf");
			string pathOpenCode = varDrillRunSettings.pathOpenCode;
			int filterIndex = 1;
			openDialogCtrlPreview.Properties = new FileOpenModes(clsVar.varFile.FileOpenMode);
			clsVar.PreviewLoaded = true;
			openDialogCtrlPreview.SubFolder = true;
			openDialogCtrlPreview.FileDlgCaption = AppLanguage.CadCamDynamic[32] + " " + AppLanguage.CadCamDynamic[31];
			openDialogCtrlPreview.FileDlgOkCaption = AppLanguage.CadCamDynamic[31];
			openDialogCtrlPreview.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			openDialogCtrlPreview.SubFolder = clsVar.varFile.FileOpenMode.SubFolder;
			openDialogCtrlPreview.ShowInfoButton = clsVar.varFile.FileOpenMode.ShowInfoButton;
			openDialogCtrlPreview.ShowPreviewDisable = clsVar.varFile.FileOpenMode.ShowDisablePreview;
			openDialogCtrlPreview.ShowLoading(Show: false);
			openDialogCtrlPreview.Init();
			openFileDialog_0.AddExtension = true;
			openDialogCtrlPreview.PreviewEnable = true;
			openFileDialog_0.InitialDirectory = pathOpenCode;
			if (InitPath.Trim().Length > 0)
			{
				openFileDialog_0.InitialDirectory = InitPath;
			}
			openFileDialog_0.FilterIndex = filterIndex;
			openFileDialog_0.CheckFileExists = true;
			openFileDialog_0.DefaultExt = "dxf";
			openFileDialog_0.FileName = "";
			openFileDialog_0.DereferenceLinks = true;
			DialogResult dialogResult = openFileDialog_0.ShowDialog(openDialogCtrlPreview, clsItem.FrmMain);
			if (dialogResult != DialogResult.OK)
			{
				return false;
			}
			varDrillRunSettings.pathOpenCode = buFile5.GetPath(openFileDialog_0.FileName);
			OpenCorpusFile(openFileDialog_0.FileName, ref activeJob);
			return true;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public void cmdGetDrillsFromCorpus()
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = varDrillRunSettings.path3DJob;
			openFileDialog.Filter = "Cyncly AES File (*.xml)|*.xml";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				varDrillRunSettings.path3DJob = buFile5.GetPath(openFileDialog.FileName);
				SaveDrillFile();
				OpenCynClyFile(openFileDialog.FileName, ref activeJob);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdJobList()
	{
		try
		{
		}
		catch (Exception)
		{
		}
	}

	public void cmdZoomFit(drillViewports ViewportType)
	{
		if (ViewportType == drillViewports.Simulation)
		{
			buEyeShotFunctions.ZoomFit(ref viewportAuto);
		}
		if (ViewportType == drillViewports.Edit && frmEdit != null)
		{
			buEyeShotFunctions.ZoomFit(ref viewportEdit);
		}
		if (ViewportType == drillViewports.List && frmList != null)
		{
			buEyeShotFunctions.ZoomFit(ref viewportList);
		}
	}

	public void cmdSetView(viewType Type, drillViewports ViewportType)
	{
		switch (Type)
		{
		default:
			if (ViewportType == drillViewports.Simulation)
			{
				buEyeShotFunctions.ViewIso(ref viewportAuto, isZoomFit: false);
			}
			if (ViewportType == drillViewports.Edit)
			{
				buEyeShotFunctions.ViewIso(ref viewportEdit, isZoomFit: false);
			}
			if (ViewportType == drillViewports.List)
			{
				buEyeShotFunctions.ViewIso(ref viewportList, isZoomFit: false);
			}
			clsInit.appDrill.planeActive = Plane.XY;
			break;
		case viewType.Top:
			if (ViewportType == drillViewports.Simulation)
			{
				buEyeShotFunctions.ViewTop(ref viewportAuto, isZoomFit: false);
			}
			if (ViewportType == drillViewports.Edit)
			{
				buEyeShotFunctions.ViewTop(ref viewportEdit, isZoomFit: false);
			}
			if (ViewportType == drillViewports.List)
			{
				buEyeShotFunctions.ViewTop(ref viewportList, isZoomFit: false);
			}
			clsInit.appDrill.planeActive = Plane.XY;
			break;
		case viewType.Bottom:
			if (ViewportType == drillViewports.Simulation)
			{
				buEyeShotFunctions.ShowViewportViewBox(ref viewportAuto, Show: false);
			}
			if (ViewportType == drillViewports.Edit)
			{
				buEyeShotFunctions.ShowViewportViewBox(ref viewportEdit, Show: false);
			}
			if (ViewportType == drillViewports.List)
			{
				buEyeShotFunctions.ShowViewportViewBox(ref viewportList, Show: false);
			}
			clsInit.appDrill.planeActive = Plane.XY;
			break;
		case viewType.Front:
			if (ViewportType == drillViewports.Simulation)
			{
				buEyeShotFunctions.Viewfront(ref viewportAuto, isZoomFit: false);
			}
			if (ViewportType == drillViewports.Edit)
			{
				buEyeShotFunctions.Viewfront(ref viewportEdit, isZoomFit: false);
			}
			if (ViewportType == drillViewports.List)
			{
				buEyeShotFunctions.Viewfront(ref viewportList, isZoomFit: false);
			}
			clsInit.appDrill.planeActive = Plane.XZ;
			break;
		case viewType.Rear:
			if (ViewportType == drillViewports.Simulation)
			{
				buEyeShotFunctions.ViewBack(ref viewportAuto, isZoomFit: false);
			}
			if (ViewportType == drillViewports.Edit)
			{
				buEyeShotFunctions.ViewBack(ref viewportEdit, isZoomFit: false);
			}
			if (ViewportType == drillViewports.List)
			{
				buEyeShotFunctions.ViewBack(ref viewportList, isZoomFit: false);
			}
			clsInit.appDrill.planeActive = Plane.XZ;
			break;
		case viewType.Left:
			if (ViewportType == drillViewports.Simulation)
			{
				buEyeShotFunctions.ViewLeft(ref viewportAuto, isZoomFit: false);
			}
			if (ViewportType == drillViewports.Edit)
			{
				buEyeShotFunctions.ViewLeft(ref viewportEdit, isZoomFit: false);
			}
			if (ViewportType == drillViewports.List)
			{
				buEyeShotFunctions.ViewLeft(ref viewportList, isZoomFit: false);
			}
			clsInit.appDrill.planeActive = Plane.YZ;
			break;
		case viewType.Right:
			if (ViewportType == drillViewports.Simulation)
			{
				buEyeShotFunctions.ViewRight(ref viewportAuto, isZoomFit: false);
			}
			if (ViewportType == drillViewports.Edit)
			{
				buEyeShotFunctions.ViewRight(ref viewportEdit, isZoomFit: false);
			}
			if (ViewportType == drillViewports.List)
			{
				buEyeShotFunctions.ViewRight(ref viewportList, isZoomFit: false);
			}
			clsInit.appDrill.planeActive = Plane.YZ;
			break;
		}
	}

	public void cmdMenuCommand(object sender, EventArgs e)
	{
		string text = "";
		bool flag = false;
		if (!(sender is Control))
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			Control control = sender as Control;
			text = control.Name;
		}
		if (text == clsItem.FrmDrillJob.mnu_addpanel.Name)
		{
			cmdNewMaterial(null);
		}
		if (text == clsItem.FrmDrillJob.mnu_deletepanel.Name && JobList.Count > 0 && selectedJobIndex >= 0 && buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[23]) == DialogResult.Yes)
		{
			doDeletePanel(selectedJobIndex);
		}
		if (text == clsItem.FrmDrillJob.mnu_editpanel.Name && selectedJobIndex >= 0)
		{
			cmdNewMaterial(activeJob);
		}
		if (text == clsItem.FrmDrillJob.mnu_renamepanel.Name && selectedJobIndex >= 0)
		{
			DialogBoxText dialogBoxText = new DialogBoxText();
			dialogBoxText.Caption = AppLanguage.CadCamDynamic[112] + " " + AppLanguage.CadCamDynamic[40];
			dialogBoxText.Text = AppLanguage.CadCamDynamic[112] + " " + AppLanguage.CadCamDynamic[40];
			dialogBoxText.Init(activeJob.Name);
			dialogBoxText.ShowDialog();
			if (dialogBoxText.Result == DialogResult.OK)
			{
				activeJob.Name = dialogBoxText.Value.Trim();
				if (clsItem.FrmDrillJob.tree_jobs.Nodes.Count > 0)
				{
					((TreeNodeSettings)clsItem.FrmDrillJob.tree_jobs.Nodes[0]).Text = JobToString(activeJob);
					((TreeNodeSettings)clsItem.FrmDrillJob.tree_jobs.Nodes[0]).Info = JobToString(activeJob);
				}
			}
		}
		if (text == clsItem.FrmDrillJob.mnu_removeoperation.Name && activeJob != null)
		{
			if (!((selectedJobIndex >= 0) & (selectedItemIndex >= 0) & (selectedItemSubIndex == -1)))
			{
				if (((selectedJobIndex >= 0) & (selectedItemIndex >= 0) & (selectedItemSubIndex >= 0)) && buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[24]) == DialogResult.Yes)
				{
					doDeleteOperation(selectedJobIndex, selectedItemIndex, selectedItemSubIndex);
				}
			}
			else if (buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[24]) == DialogResult.Yes)
			{
				doDeleteOperation(selectedJobIndex, selectedItemIndex, selectedItemSubIndex);
			}
		}
		if (text == clsItem.FrmDrillJob.mnu_removealloperation.Name && activeJob != null && buString5.MessageBoxQuestion(buDrillCalc.LangDrillMessage[18]) == DialogResult.Yes)
		{
			doDeletaAllOperations();
		}
		if (text == clsItem.FrmDrillJob.mnu_editoperation.Name && ((selectedJobIndex >= 0) & (selectedItemIndex >= 0)))
		{
			doEditOperation();
		}
		flag = false;
		if (text == clsItem.FrmDrillJob.mnu_alldrilldisable.Name)
		{
			clsInit.cDrill.EnableDisableOperations(Status: false, ref activeJob, Hole: true, Shape: false, Cut: false, Profiling: false, Junction: false, Engraving: false, Text: false, Contour: false, Profile: false);
			flag = true;
		}
		if (text == clsItem.FrmDrillJob.mnu_alldrillenable.Name)
		{
			clsInit.cDrill.EnableDisableOperations(Status: true, ref activeJob, Hole: true, Shape: false, Cut: false, Profiling: false, Junction: false, Engraving: false, Text: false, Contour: false, Profile: false);
			flag = true;
		}
		if (text == clsItem.FrmDrillJob.mnu_allslotdisable.Name)
		{
			clsInit.cDrill.EnableDisableOperations(Status: false, ref activeJob, Hole: false, Shape: false, Cut: true, Profiling: false, Junction: false, Engraving: false, Text: false, Contour: false, Profile: false);
			flag = true;
		}
		if (text == clsItem.FrmDrillJob.mnu_allslotenable.Name)
		{
			clsInit.cDrill.EnableDisableOperations(Status: true, ref activeJob, Hole: false, Shape: false, Cut: true, Profiling: false, Junction: false, Engraving: false, Text: false, Contour: false, Profile: false);
			flag = true;
		}
		if (text == clsItem.FrmDrillJob.mnu_allshapedisable.Name)
		{
			clsInit.cDrill.EnableDisableOperations(Status: false, ref activeJob, Hole: false, Shape: true, Cut: false, Profiling: false, Junction: false, Engraving: false, Text: false, Contour: false, Profile: false);
			flag = true;
		}
		if (text == clsItem.FrmDrillJob.mnu_allshapeenable.Name)
		{
			clsInit.cDrill.EnableDisableOperations(Status: true, ref activeJob, Hole: false, Shape: true, Cut: false, Profiling: false, Junction: false, Engraving: false, Text: false, Contour: false, Profile: false);
			flag = true;
		}
		if (text == clsItem.FrmDrillJob.mnu_disableoperation.Name && ((selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 1)))
		{
			if (activeJob.Items[selectedItemIndex].Enable)
			{
				clsInit.cDrill.EnableDisableOperation(Status: false, ref activeJob, selectedItemIndex);
			}
			else
			{
				clsInit.cDrill.EnableDisableOperation(Status: true, ref activeJob, selectedItemIndex);
			}
			flag = true;
		}
		if (flag)
		{
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(activeJob);
		}
		flag = false;
		if (text == clsItem.FrmDrillJob.mnu_copyoperation.Name && activeJob != null && ((selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 1)))
		{
			doCopyOperation();
		}
		if (text == clsItem.FrmDrillJob.mnu_mirroroperation.Name && activeJob != null && ((selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 1)))
		{
			doMirrorOperation();
		}
		if (text == clsItem.FrmDrillJob.mnu_rotatepanel.Name && activeJob != null)
		{
			doRotateOperation();
		}
		if (text == clsItem.FrmDrillJob.mnu_upmove.Name)
		{
			doOperationMoveUp();
		}
		if (text == clsItem.FrmDrillJob.mnu_downmove.Name)
		{
			doOperationMoveDown();
		}
	}

	public void CollisionCheck()
	{
		collisionDetection_0 = new CollisionDetection(SimToCollsionCheck1, SimToCollsionCheck2, viewportAuto.Blocks, firstOnly: false, collisionCheckType.SubdivisionTree);
		if (!isCollisionRunning)
		{
			isCollisionRunning = true;
			if (varDrillRunSettings.CollisionCheck)
			{
				viewportAuto.StartWork(collisionDetection_0);
			}
		}
	}

	private void method_0(object sender, WorkCompletedEventArgs e)
	{
		try
		{
			isCollisionRunning = false;
			if (e.WorkUnit is CollisionDetection)
			{
				CollisionDetection collisionDetection = e.WorkUnit as CollisionDetection;
				if (collisionDetection.Result == null)
				{
					viewportAuto.TempEntities.Clear();
				}
				else if (collisionDetection.Result.Length != 0)
				{
					Class5.smethod_119(this, (IList<CollisionResult>)collisionDetection.Result);
					viewportAuto.Invalidate();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_1(object sender, WorkFailedEventArgs e)
	{
		isCollisionRunning = false;
		viewportAuto.TempEntities.Clear();
	}

	private void method_2(object sender, EventArgs e)
	{
		isCollisionRunning = false;
		viewportAuto.TempEntities.Clear();
	}

	public void mouseMoveVierport(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Design)sender;
		if (control.Name == viewportAuto.Name)
		{
			Point3D intPoint = new Point3D();
			viewportAuto.ScreenToPlane(e.Location, clsInit.appDrill.planeActive, out intPoint);
			if (intPoint != null)
			{
				frmMachSim.lbl_x.Text = "X: " + intPoint.X.ToString("f3");
				frmMachSim.lbl_y.Text = "Y: " + intPoint.Y.ToString("f3");
				frmMachSim.lbl_z.Text = "Z: " + intPoint.Z.ToString("f3");
			}
		}
		if (frmEdit != null && control.Name == viewportEdit.Name)
		{
			Point3D intPoint2 = new Point3D();
			viewportEdit.ScreenToPlane(e.Location, clsInit.appDrill.planeActive, out intPoint2);
			if (intPoint2 != null)
			{
				frmEdit.lbl_x.Text = "X: " + intPoint2.X.ToString("f3");
				frmEdit.lbl_y.Text = "Y: " + intPoint2.Y.ToString("f3");
				frmEdit.lbl_z.Text = "Z: " + intPoint2.Z.ToString("f3");
			}
		}
		if (frmList != null && control.Name == viewportList.Name)
		{
			Point3D intPoint3 = new Point3D();
			viewportList.ScreenToPlane(e.Location, clsInit.appDrill.planeActive, out intPoint3);
			if (intPoint3 != null)
			{
				frmList.lbl_x.Text = "X: " + intPoint3.X.ToString("f3");
				frmList.lbl_y.Text = "Y: " + intPoint3.Y.ToString("f3");
				frmList.lbl_z.Text = "Z: " + intPoint3.Z.ToString("f3");
			}
		}
	}

	public void mouseDownVierport(object sender, MouseEventArgs e)
	{
	}

	public void viewportMouseDown(Point3D Points, object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Left || ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode != actionType.None || ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Viewports[0].ToolBar.Contains(e.Location))
		{
			return;
		}
		entityIndex = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.GetEntityUnderMouseCursor(e.Location);
		if (entityIndex < 0)
		{
			return;
		}
		if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex].EntityData == null)
		{
			entityIndex = -1;
			return;
		}
		CustomData customData = (CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex].EntityData;
		if (customData.typeDefination == entityTypeDefination.Clamper)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, new Plane(), out point3D_0);
			point3D_1 = new Point3D(point3D_0.X, point3D_0.Y, point3D_0.Z);
			ccVars.selectionProcess = false;
		}
		else
		{
			entityIndex = -1;
		}
	}

	public void viewportMouseUp(Point3D Points, object sender, MouseEventArgs e)
	{
		if (activeJob == null)
		{
			return;
		}
		if (entityIndex >= 0 && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex].EntityData != null)
		{
			CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex].EntityData as CustomData;
			if (customData.typeDefination == entityTypeDefination.Clamper)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, new Plane(), out point3D_2);
				_ = customData.RefIndex;
				if (customData.RefIndex == 2)
				{
					buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex], ref activeJob.SecondClamperEntity);
					activeJob.SecondClamperX = Points.X;
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex - 1];
					Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex];
					entity.Regen(0.1);
					entity2.Regen(0.1);
					if (entity2.BoxMin.X - entity.BoxMax.X < varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						double num = entity.BoxMax.X - entity2.BoxMin.X;
						double dx = varDrillCNCSettings.ClamperBetweenMinDistance + num;
						entity2.Translate(dx, 0.0);
						entity2.Regen(0.1);
					}
					if (entity2.BoxMax == null)
					{
						entity2.Regen(0.01);
					}
					activeJob.SecondClamperX = (entity2.BoxMax.X + entity2.BoxMin.X) / 2.0;
					activeJob.ClampesSetByManuelly = true;
				}
				if (customData.RefIndex == 1)
				{
					buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex], ref activeJob.FirstClamperEntity);
					activeJob.FirstClamperX = Points.X;
					Entity entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex];
					Entity entity4 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex + 1];
					entity3.Regen(0.1);
					entity4.Regen(0.1);
					if (entity4.BoxMin.X - entity3.BoxMax.X < varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						double num2 = entity3.BoxMax.X - entity4.BoxMin.X;
						double num3 = varDrillCNCSettings.ClamperBetweenMinDistance + num2;
						entity3.Translate(0.0 - num3, 0.0);
						entity4.Regen(0.1);
					}
					if (entity4.BoxMax == null)
					{
						entity4.Regen(0.01);
					}
					if (entity3.BoxMax == null)
					{
						entity3.Regen(0.01);
					}
					activeJob.FirstClamperX = (entity3.BoxMax.X + entity3.BoxMin.X) / 2.0;
					activeJob.ClampesSetByManuelly = true;
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			}
		}
		entityIndex = -1;
		ViewportCC.buttonPressedForSelection = false;
		ccVars.selectionProcess = true;
	}

	public void viewportMouseMove(Point3D Points, object sender, MouseEventArgs e)
	{
		Point3D intPoint = new Point3D();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, planeActive, out intPoint);
		if (entityIndex == -1)
		{
			return;
		}
		Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex];
		double num = 0.0;
		double num2 = 0.0;
		Entity entity2 = null;
		Entity entity3 = null;
		if (entityIndex == 1)
		{
			entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex];
			entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex + 1];
		}
		if (entityIndex == 2)
		{
			entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex - 1];
			entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityIndex];
		}
		if (entity2.BoxMin != null)
		{
			_ = entity2.BoxMin.X;
			num = entity2.BoxMax.X;
		}
		if (entity3.BoxMin != null)
		{
			num2 = entity3.BoxMin.X;
			_ = entity3.BoxMax.X;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ScreenToPlane(e.Location, new Plane(), out var intPoint2);
		if (point3D_0 != null)
		{
			double num3 = intPoint2.X - point3D_0.X;
			if (entityIndex == 1)
			{
				double num4 = num2 - num;
				if (!(num4 > varDrillCNCSettings.ClamperBetweenMinDistance))
				{
					if (num3 < 0.0 - varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						Vector3D v = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(point3D_0.X, 0.0, 0.0));
						entity.Translate(v);
						point3D_0 = intPoint2;
					}
				}
				else
				{
					Vector3D v2 = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(point3D_0.X, 0.0, 0.0));
					entity.Translate(v2);
					point3D_0 = intPoint2;
				}
			}
			if (entityIndex == 2)
			{
				double num5 = num2 - num;
				if (!(num5 > varDrillCNCSettings.ClamperBetweenMinDistance))
				{
					if (num3 > varDrillCNCSettings.ClamperBetweenMinDistance)
					{
						Vector3D v3 = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(point3D_0.X, 0.0, 0.0));
						entity.Translate(v3);
						point3D_0 = intPoint2;
					}
				}
				else
				{
					Vector3D v4 = Vector3D.Subtract(new Point3D(intPoint2.X, 0.0, 0.0), new Point3D(point3D_0.X, 0.0, 0.0));
					entity.Translate(v4);
					point3D_0 = intPoint2;
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void SimValueChaned(double Value, object Data)
	{
		if (Data != null && Data.ToString() == "Track")
		{
			varDrillRunSettings.SimStep = (int)Value;
		}
	}

	public void tick_Simulation(object sender, EventArgs e)
	{
		if (!(!varDrillRunSettings.StepRun | (varDrillRunSettings.StepRun & varTemps.simRelease)))
		{
			return;
		}
		varTemps.simRelease = false;
		if (activeJob == null)
		{
			varTemps.activeMove.isActive = false;
			varTemps.acliveLine = -1;
			timSim.Enabled = false;
		}
		else if (!((indexSim >= 0) & (indexSim <= activeJob.SimulationMoves.Count - 1)))
		{
			indexSim = -1;
			timSim.Enabled = false;
			varTemps.activeMove.isActive = false;
			varTemps.acliveLine = -1;
		}
		else
		{
			if (varDrillRunSettings.SimStopAtMatReady & (activeJob.SimulationMoves[indexSim].Command == DrillMoveCommand.Wait))
			{
				varDrillRunSettings.StepRun = true;
			}
			varTemps.acliveLine = activeJob.SimulationMoves[indexSim].LineIndex;
			if ((indexSim >= 0) & (indexSim <= activeJob.SimulationMoves.Count - 1))
			{
				varTemps.activeMove = new DrillMove(activeJob.SimulationMoves[indexSim]);
				if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
				{
					cGoUltra2Up1Down.MoveSimPart(activeJob.SimulationMoves[indexSim]);
				}
				if (MachType == DrillMachineType.GoWithAtc)
				{
					cGoAtc.MoveSimPart(activeJob.SimulationMoves[indexSim]);
				}
				if (MachType == DrillMachineType.Sirius)
				{
					cGoSirius.MoveSimPart(activeJob.SimulationMoves[indexSim]);
				}
				if (frmMachSim != null)
				{
					frmMachSim.lbl_x1.Text = "X1: " + activeJob.SimulationMoves[indexSim].X1Clamper.ToString("f2");
					frmMachSim.lbl_x2.Text = "X2: " + activeJob.SimulationMoves[indexSim].X2Clamper.ToString("f2");
					frmMachSim.lbl_y1.Text = "Y1: " + activeJob.SimulationMoves[indexSim].Y1Position.ToString("f2");
					frmMachSim.lbl_y2.Text = "Y2: " + activeJob.SimulationMoves[indexSim].Y2Position.ToString("f2");
					frmMachSim.lbl_y3.Text = "Y3: " + activeJob.SimulationMoves[indexSim].Y3Position.ToString("f2");
					frmMachSim.lbl_z1.Text = "Z1: " + activeJob.SimulationMoves[indexSim].Z1Position.ToString("f2");
					frmMachSim.lbl_z2.Text = "Z2: " + activeJob.SimulationMoves[indexSim].Z2Position.ToString("f2");
					frmMachSim.lbl_z3.Text = "Z3: " + activeJob.SimulationMoves[indexSim].Z3Position.ToString("f2");
				}
				if (!isCollisionRunning)
				{
					indexCollision = indexSim;
				}
				CollisionCheck();
			}
			indexSim += varDrillRunSettings.SimStep;
			varTemps.activeMove.isActive = true;
		}
		if (frmMachSim == null)
		{
			return;
		}
		if ((varTemps.acliveLine > 0) & (varTemps.acliveLine <= frmMachSim.txt_gcode.TextSource.Count - 1))
		{
			Place start = new Place
			{
				iLine = varTemps.acliveLine
			};
			frmMachSim.txt_gcode.Selection.Start = start;
			Place end = new Place
			{
				iLine = varTemps.acliveLine + 1
			};
			frmMachSim.txt_gcode.Selection.End = end;
			frmMachSim.txt_gcode.Refresh();
			if (end.iLine <= frmMachSim.txt_gcode.Lines.Count - 1)
			{
				frmMachSim.txt_gcode.DoSelectionVisible();
			}
		}
		if ((varTemps.acliveLine == -1) & (frmMachSim.txt_gcode.TextSource.Count > 0))
		{
			Place start2 = new Place
			{
				iLine = 0
			};
			frmMachSim.txt_gcode.Selection.Start = start2;
			Place end2 = new Place
			{
				iLine = 1
			};
			frmMachSim.txt_gcode.Selection.End = end2;
			frmMachSim.txt_gcode.Refresh();
			if (end2.iLine <= frmMachSim.txt_gcode.Lines.Count - 1)
			{
				frmMachSim.txt_gcode.DoSelectionVisible();
			}
		}
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
			Mesh mesh = Mesh.CreateArrow(Data.CornerPoint, VectorX, varDrillSettings.CornerArrowDiameter / 2.0, varDrillSettings.CornerArrowLength, varDrillSettings.CornerArrowConeDiameter / 2.0, varDrillSettings.CornerArrowConeLength, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
			mesh.Color = varDrillSettings.CornerArrowXColor;
			mesh.ColorMethod = colorMethodType.byEntity;
			customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Temp;
			mesh.EntityData = customData;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh);
		}
		if (VectorY.Y != 0.0)
		{
			Mesh mesh2 = Mesh.CreateArrow(Data.CornerPoint, VectorY, varDrillSettings.CornerArrowDiameter / 2.0, varDrillSettings.CornerArrowLength, varDrillSettings.CornerArrowConeDiameter / 2.0, varDrillSettings.CornerArrowConeLength, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
			mesh2.Color = varDrillSettings.CornerArrowYColor;
			mesh2.ColorMethod = colorMethodType.byEntity;
			customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Temp;
			mesh2.EntityData = customData;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh2);
		}
		if (VectorZ.Z != 0.0)
		{
			Mesh mesh3 = Mesh.CreateArrow(Data.CornerPoint, VectorZ, varDrillSettings.CornerArrowDiameter / 2.0, varDrillSettings.CornerArrowLength, varDrillSettings.CornerArrowConeDiameter / 2.0, varDrillSettings.CornerArrowConeLength, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
			mesh3.Color = varDrillSettings.CornerArrowZColor;
			mesh3.ColorMethod = colorMethodType.byEntity;
			customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Temp;
			mesh3.EntityData = customData;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh3);
		}
		Mesh mesh4 = Mesh.CreateSphere(6.0, 20, 20, Mesh.natureType.RichSmooth);
		mesh4.Translate(Data.CornerPoint.X, Data.CornerPoint.Y, Data.CornerPoint.Z);
		mesh4.Color = varDrillSettings.CornerArrowBallColor;
		mesh4.ColorMethod = colorMethodType.byEntity;
		customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Temp;
		mesh4.EntityData = customData;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh4);
	}

	public void DrawPanelFromJobMainAndPreview(DrillJob Job)
	{
		DrawPanelFromJob(Job, new ViewportDrawOptions(ViewportRefType.Main));
	}

	public void DrawPanelFromJob(DrillJob Job, ViewportDrawOptions Options, buShape Shape = null)
	{
		try
		{
			Design design = null;
			if (Options.ViewportRef != ViewportRefType.Main)
			{
				if (Options.ViewportRef != ViewportRefType.Operation)
				{
					if (Options.ViewportRef != ViewportRefType.Preview)
					{
						if (Options.ViewportRef == ViewportRefType.OpenDialog)
						{
							design = clsItem.ModelOpenPreview;
						}
					}
					else
					{
						design = clsItem.ModelMainPreview;
					}
				}
				else if (Options.GroupType != ShapeGroup.Drill)
				{
					if (Options.GroupType != ShapeGroup.Cut)
					{
						if (Options.GroupType != ShapeGroup.Shape)
						{
							if (Options.GroupType != ShapeGroup.Profiling)
							{
								if (Options.GroupType != ShapeGroup.Engraving)
								{
									if (Options.GroupType == ShapeGroup.Junction)
									{
										design = clsItem.FrmJunctionList.viewportLayout;
									}
								}
								else
								{
									design = clsItem.FrmEngraveList.viewportLayout;
								}
							}
							else
							{
								design = clsItem.FrmProfilingList.viewportLayout;
							}
						}
						else
						{
							design = clsItem.FrmShapeList.viewportLayout;
						}
					}
					else
					{
						design = clsItem.FrmSlotList.viewportLayout;
					}
				}
				else
				{
					design = clsItem.FrmDrillList.viewportLayout;
				}
			}
			else
			{
				design = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
			}
			design.UpdateBoundingBox();
			design.Entities.Clear();
			if (Job != null)
			{
				Entity copiedEntity = null;
				if (Job.Material.Entities.Count > 0)
				{
					buEntity.Copy(Job.Material.Entities[0], ref copiedEntity);
					copiedEntity.LayerName = varTemps.layerPanel;
					copiedEntity.ColorMethod = colorMethodType.byEntity;
					copiedEntity.Color = Color.FromArgb(varDrillSettings.transparencyPanel, varDrillSettings.colorPanel);
					copiedEntity.Selectable = false;
					CustomData customData = new CustomData();
					customData.typeDefination = entityTypeDefination.Panel;
					customData.RefIndex = 0;
					copiedEntity.EntityData = customData;
					design.Entities.Add(copiedEntity);
				}
				if (Options.ViewportRef == ViewportRefType.Main)
				{
					if (Job.FirstClamperEntity != null)
					{
						Entity copiedEnt = null;
						buVector5.CopyEntities(Job.FirstClamperEntity, ref copiedEnt);
						design.Entities.Add(copiedEnt);
					}
					if (Job.SecondClamperEntity != null && MachType != DrillMachineType.Sirius)
					{
						Entity copiedEnt2 = null;
						buVector5.CopyEntities(Job.SecondClamperEntity, ref copiedEnt2);
						design.Entities.Add(copiedEnt2);
					}
				}
				if (Options.DrawItems)
				{
					for (int i = 0; i <= Job.Cams.Count - 1; i++)
					{
						for (int j = 0; j <= Job.Cams[i].EntitiesG1.Count - 1; j++)
						{
							Entity copiedEntity2 = null;
							buEntity.Copy(Job.Cams[i].EntitiesG1[j], ref copiedEntity2);
							copiedEntity2.LayerName = varTemps.layerOperation;
							copiedEntity2.ColorMethod = colorMethodType.byEntity;
							copiedEntity2.Color = Color.Red;
							copiedEntity2.Selectable = false;
							CustomData customData2 = new CustomData();
							customData2.typeDefination = entityTypeDefination.Operation;
							customData2.RefIndex = i;
							customData2.Sequence = j;
							copiedEntity2.EntityData = customData2;
							clsInit.cVector5.Mirror(new Point3D(), new Point3D(1.0, 0.0, 0.0), Plane.XY, ref copiedEntity2);
							clsInit.cVector5.Mirror(new Point3D(), new Point3D(0.0, -1.0, 0.0), Plane.XY, ref copiedEntity2);
							design.Entities.Add(copiedEntity2);
						}
					}
					for (int k = 0; k <= Job.Items.Count - 1; k++)
					{
						buShape buShape2 = Job.Items[k];
						for (int l = 0; l <= buShape2.entitySolid.Count - 1; l++)
						{
							Entity copiedEntity3 = null;
							buEntity.Copy(buShape2.entitySolid[l], ref copiedEntity3);
							copiedEntity3.LayerName = varTemps.layerOperation;
							copiedEntity3.ColorMethod = colorMethodType.byEntity;
							copiedEntity3.Color = Color.FromArgb(100, clsInit.cVector5.setbuShapeColors(buShape2));
							copiedEntity3.Selectable = true;
							if ((Job.Material.FrontAngle != 0.0) & (Job.Items[k].planeName == planeBoxNames.Front))
							{
								Point3D point3D = new Point3D(0.0, 0.0, Job.Material.Size.Depth);
								copiedEntity3.Rotate(buConversion5.DegreeToRadian(Job.Material.FrontAngle), Vector3D.AxisX, point3D);
								Point3D Points = buVector5.ToPoint3D(buShape2.CalculatedPoint);
								clsInit.cVector5.Rotate(point3D, Job.Material.FrontAngle, Plane.YZ, ref Points);
								double num = buShape2.BasePoint.Z - Points.Z;
								double num2 = num * Math.Tan(buConversion5.DegreeToRadian(Job.Material.FrontAngle));
								copiedEntity3.Translate(0.0, 0.0 - num2, num);
							}
							if ((Job.Material.BackAngle != 0.0) & (Job.Items[k].planeName == planeBoxNames.Back))
							{
								Point3D point3D2 = new Point3D(0.0, Job.Material.Size.Height, Job.Material.Size.Depth);
								copiedEntity3.Rotate(buConversion5.DegreeToRadian(0.0 - Job.Material.BackAngle), Vector3D.AxisX, point3D2);
								Point3D Points2 = buVector5.ToPoint3D(buShape2.CalculatedPoint);
								clsInit.cVector5.Rotate(point3D2, Job.Material.BackAngle, Plane.YZ, ref Points2);
								double num3 = buShape2.BasePoint.Z - Points2.Z;
								double dy = num3 * Math.Tan(buConversion5.DegreeToRadian(Job.Material.BackAngle));
								copiedEntity3.Translate(0.0, dy, num3);
							}
							CustomData customData3 = new CustomData();
							customData3.typeDefination = entityTypeDefination.Operation;
							customData3.RefIndex = k;
							customData3.Sequence = l;
							customData3.Tags = buShape2.ShapeGroup.ToString();
							copiedEntity3.EntityData = customData3;
							design.Entities.Add(copiedEntity3);
						}
						for (int m = 0; m <= buShape2.entityWireframe.Count - 1; m++)
						{
							Entity copiedEntity4 = null;
							buEntity.Copy(buShape2.entityWireframe[m], ref copiedEntity4);
							copiedEntity4.LayerName = varTemps.layerOperation;
							copiedEntity4.ColorMethod = colorMethodType.byEntity;
							copiedEntity4.Color = clsInit.cVector5.setbuShapeColors(buShape2);
							copiedEntity4.LineTypeMethod = colorMethodType.byEntity;
							copiedEntity4.Selectable = true;
							CustomData customData4 = new CustomData();
							customData4.typeDefination = entityTypeDefination.Operation;
							customData4.RefIndex = k;
							customData4.Sequence = m;
							customData4.Tags = buShape2.ShapeGroup.ToString();
							copiedEntity4.EntityData = customData4;
							design.Entities.Add(copiedEntity4);
						}
						if (Job.Items[k].Cam != null)
						{
							for (int n = 0; n <= Job.Items[k].Cam.EntitiesG1.Count - 1; n++)
							{
								Entity copiedEntity5 = null;
								buEntity.Copy(Job.Items[k].Cam.EntitiesG1[n], ref copiedEntity5);
								copiedEntity5.ColorMethod = colorMethodType.byEntity;
								copiedEntity5.Color = Color.Red;
								copiedEntity5.LineWeight = 3f;
								copiedEntity5.LineWeightMethod = colorMethodType.byEntity;
								copiedEntity5.LayerName = varTemps.layerCam;
								copiedEntity5.Selectable = false;
								copiedEntity5.Regen(0.01);
								CustomData customData5 = new CustomData();
								customData5.typeDefination = entityTypeDefination.Cam;
								customData5.RefIndex = k;
								customData5.CamID = n;
								design.Entities.Add(copiedEntity5);
							}
						}
					}
				}
				if (Options.OtherEntities != null)
				{
					for (int num4 = 0; num4 <= Options.OtherEntities.Count - 1; num4++)
					{
						design.Entities.Add(Options.OtherEntities[num4]);
					}
				}
				design.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
				design.ActiveViewport.DisplayMode = displayType.Flat;
				if (Options.ViewportRef != ViewportRefType.Main)
				{
					if (Options.ViewportRef != ViewportRefType.Operation)
					{
						if (Options.ViewportRef == ViewportRefType.Preview)
						{
							design.SetView(viewType.Dimetric);
							design.ZoomFit(5);
						}
					}
					else if (Shape != null)
					{
						List<Entity> entitiesDim = new List<Entity>();
						clsInit.cVector5.CreateShapeDimension(Shape, Job.Material, clsVar5.ShapeTempPar.ValueType, ref entitiesDim, ref Options.SetView);
						if (entitiesDim.Count > 0)
						{
							if (clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.EndDistance)
							{
								design.Entities.ClearSelection();
							}
							for (int num5 = 0; num5 <= entitiesDim.Count - 1; num5++)
							{
								entitiesDim[num5].Selected = true;
								design.Entities.Add(entitiesDim[num5]);
							}
						}
						if (Options.SetView != viewType.Other)
						{
							design.SetView(Options.SetView);
						}
						if (Shape.planeName == planeBoxNames.Back)
						{
							if (Options.SetView == viewType.Other)
							{
								design.SetView(viewType.Front);
							}
							design.ZoomFit(selectedOnly: true);
						}
						if (Shape.planeName == planeBoxNames.Front)
						{
							if (Options.SetView == viewType.Other)
							{
								design.SetView(viewType.Front);
							}
							design.ZoomFit(selectedOnly: true);
						}
						if (Shape.planeName == planeBoxNames.Left)
						{
							if (Options.SetView == viewType.Other)
							{
								design.SetView(viewType.Right);
							}
							design.ZoomFit(selectedOnly: true);
						}
						if (Shape.planeName == planeBoxNames.Right)
						{
							if (Options.SetView == viewType.Other)
							{
								design.SetView(viewType.Right);
							}
							design.ZoomFit(selectedOnly: true);
						}
						if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom))
						{
							if (Options.SetView == viewType.Other)
							{
								design.SetView(viewType.Top);
							}
							design.ZoomFit(selectedOnly: true);
						}
					}
				}
				design.UpdateBoundingBox();
				design.Invalidate();
			}
			else
			{
				design.Invalidate();
			}
		}
		catch (Exception)
		{
		}
	}

	public void DrawAsRenderFromJob(DrillJob Job, ref Entity entPanel)
	{
		try
		{
			Brep brep = Brep.CreateBox(Job.Material.Size.Width, Job.Material.Size.Height, Job.Material.Size.Depth);
			if (Sing != 1)
			{
				brep.Translate((double)Sing * Job.Material.Size.Width, (double)Sing * Job.Material.Size.Height);
			}
			new List<ICurve>();
			for (int i = 0; i <= Job.Items.Count - 1; i++)
			{
				double num = Job.Items[i].Depth;
				if (num <= 0.02)
				{
					num = 0.1;
				}
				CustomData customData = new CustomData();
				customData.typeDefination = entityTypeDefination.Operation;
				List<ICurve> copiedEntities = new List<ICurve>();
				clsInit.cVector5.GetClockDirection(Job.Items[i].entitiesShape[0].Vertices, Job.Items[i].planeOperation);
				buEntity.Copy(Job.Items[i].entitiesShape, ref copiedEntities);
				if (Job.Items[i].planeName == planeBoxNames.Top)
				{
					if (Job.Items[i].ShapeGroup != ShapeGroup.Drill)
					{
						devDept.Eyeshot.Entities.Region reg = new devDept.Eyeshot.Entities.Region(copiedEntities, Job.Items[i].planeOperation, sortAndOrient: true);
						brep.ExtrudeRemove(reg, 0.0 - num);
					}
					else
					{
						buShapeHole buShapeHole4 = Job.Items[i] as buShapeHole;
						if (Job.Items[i].multiCenter != null)
						{
							if (Job.Items[i].multiCenter.Count != 0)
							{
								for (int j = 0; j <= Job.Items[i].multiCenter.Count - 1; j++)
								{
									Circle circle = new Circle(Job.Items[i].planeOperation, Job.Items[i].multiCenter[j].Center, buShapeHole4.Diameter / 2.0);
									circle.Regen(0.01);
									devDept.Eyeshot.Entities.Region reg2 = new devDept.Eyeshot.Entities.Region(circle);
									brep.ExtrudeRemove(reg2, 0.0 - num);
								}
							}
							else
							{
								devDept.Eyeshot.Entities.Region reg3 = new devDept.Eyeshot.Entities.Region(copiedEntities);
								brep.ExtrudeRemove(reg3, 0.0 - num);
							}
						}
						else
						{
							devDept.Eyeshot.Entities.Region reg4 = new devDept.Eyeshot.Entities.Region(copiedEntities);
							brep.ExtrudeRemove(reg4, 0.0 - num);
						}
					}
				}
				if (Job.Items[i].planeName == planeBoxNames.Left)
				{
					if (Job.Items[i].ShapeGroup != ShapeGroup.Drill)
					{
						devDept.Eyeshot.Entities.Region reg5 = new devDept.Eyeshot.Entities.Region(copiedEntities, Job.Items[i].planeOperation, sortAndOrient: true);
						brep.ExtrudeRemove(reg5, num);
					}
					else
					{
						buShapeHole buShapeHole5 = Job.Items[i] as buShapeHole;
						if (Job.Items[i].multiCenter != null)
						{
							if (Job.Items[i].multiCenter.Count != 0)
							{
								for (int k = 0; k <= Job.Items[i].multiCenter.Count - 1; k++)
								{
									Circle circle2 = new Circle(Job.Items[i].planeOperation, Job.Items[i].multiCenter[k].Center, buShapeHole5.Diameter / 2.0);
									circle2.Regen(0.01);
									devDept.Eyeshot.Entities.Region reg6 = new devDept.Eyeshot.Entities.Region(circle2);
									brep.ExtrudeRemove(reg6, num);
								}
							}
							else
							{
								devDept.Eyeshot.Entities.Region reg7 = new devDept.Eyeshot.Entities.Region(copiedEntities);
								brep.ExtrudeRemove(reg7, num);
							}
						}
						else
						{
							devDept.Eyeshot.Entities.Region reg8 = new devDept.Eyeshot.Entities.Region(copiedEntities);
							brep.ExtrudeRemove(reg8, num);
						}
					}
				}
				if (Job.Items[i].planeName == planeBoxNames.Right)
				{
					if (Job.Items[i].ShapeGroup != ShapeGroup.Drill)
					{
						devDept.Eyeshot.Entities.Region reg9 = new devDept.Eyeshot.Entities.Region(copiedEntities, Job.Items[i].planeOperation, sortAndOrient: true);
						brep.ExtrudeRemove(reg9, 0.0 - num);
					}
					else
					{
						buShapeHole buShapeHole6 = Job.Items[i] as buShapeHole;
						if (Job.Items[i].multiCenter != null)
						{
							if (Job.Items[i].multiCenter.Count != 0)
							{
								for (int l = 0; l <= Job.Items[i].multiCenter.Count - 1; l++)
								{
									Circle circle3 = new Circle(Job.Items[i].planeOperation, Job.Items[i].multiCenter[l].Center, buShapeHole6.Diameter / 2.0);
									circle3.Regen(0.01);
									devDept.Eyeshot.Entities.Region reg10 = new devDept.Eyeshot.Entities.Region(circle3);
									brep.ExtrudeRemove(reg10, 0.0 - num);
								}
							}
							else
							{
								devDept.Eyeshot.Entities.Region reg11 = new devDept.Eyeshot.Entities.Region(copiedEntities);
								brep.ExtrudeRemove(reg11, 0.0 - num);
							}
						}
						else
						{
							devDept.Eyeshot.Entities.Region reg12 = new devDept.Eyeshot.Entities.Region(copiedEntities);
							brep.ExtrudeRemove(reg12, 0.0 - num);
						}
					}
				}
				if (Job.Items[i].planeName == planeBoxNames.Front)
				{
					if (Job.Items[i].ShapeGroup != ShapeGroup.Drill)
					{
						devDept.Eyeshot.Entities.Region reg13 = new devDept.Eyeshot.Entities.Region(copiedEntities, Job.Items[i].planeOperation, sortAndOrient: true);
						brep.ExtrudeRemove(reg13, 0.0 - num);
					}
					else
					{
						buShapeHole buShapeHole7 = Job.Items[i] as buShapeHole;
						if (Job.Items[i].multiCenter != null)
						{
							if (Job.Items[i].multiCenter.Count != 0)
							{
								for (int m = 0; m <= Job.Items[i].multiCenter.Count - 1; m++)
								{
									Circle circle4 = new Circle(Job.Items[i].planeOperation, Job.Items[i].multiCenter[m].Center, buShapeHole7.Diameter / 2.0);
									circle4.Regen(0.01);
									devDept.Eyeshot.Entities.Region reg14 = new devDept.Eyeshot.Entities.Region(circle4);
									brep.ExtrudeRemove(reg14, 0.0 - num);
								}
							}
							else
							{
								devDept.Eyeshot.Entities.Region reg15 = new devDept.Eyeshot.Entities.Region(copiedEntities);
								brep.ExtrudeRemove(reg15, 0.0 - num);
							}
						}
						else
						{
							devDept.Eyeshot.Entities.Region reg16 = new devDept.Eyeshot.Entities.Region(copiedEntities);
							brep.ExtrudeRemove(reg16, 0.0 - num);
						}
					}
				}
				if (Job.Items[i].planeName != planeBoxNames.Back)
				{
					continue;
				}
				if (Job.Items[i].ShapeGroup != ShapeGroup.Drill)
				{
					devDept.Eyeshot.Entities.Region reg17 = new devDept.Eyeshot.Entities.Region(copiedEntities, Job.Items[i].planeOperation, sortAndOrient: true);
					brep.ExtrudeRemove(reg17, num);
					continue;
				}
				buShapeHole buShapeHole8 = Job.Items[i] as buShapeHole;
				if (Job.Items[i].multiCenter != null)
				{
					if (Job.Items[i].multiCenter.Count != 0)
					{
						for (int n = 0; n <= Job.Items[i].multiCenter.Count - 1; n++)
						{
							Circle circle5 = new Circle(Job.Items[i].planeOperation, Job.Items[i].multiCenter[n].Center, buShapeHole8.Diameter / 2.0);
							circle5.Regen(0.01);
							devDept.Eyeshot.Entities.Region reg18 = new devDept.Eyeshot.Entities.Region(circle5);
							brep.ExtrudeRemove(reg18, num);
						}
					}
					else
					{
						devDept.Eyeshot.Entities.Region reg19 = new devDept.Eyeshot.Entities.Region(copiedEntities);
						brep.ExtrudeRemove(reg19, num);
					}
				}
				else
				{
					devDept.Eyeshot.Entities.Region reg20 = new devDept.Eyeshot.Entities.Region(copiedEntities);
					brep.ExtrudeRemove(reg20, num);
				}
			}
			brep.Rebuild(0.1);
			entPanel = brep;
			entPanel.Color = Color.FromArgb(150, varDrillSettings.colorPanel);
			entPanel.ColorMethod = colorMethodType.byEntity;
			entPanel.LayerName = varTemps.layerPanel;
		}
		catch (Exception)
		{
		}
	}

	public void UpdateSelectedOperation(ViewportDrawOptions Options)
	{
		try
		{
			Design design = null;
			if (Options.ViewportRef != ViewportRefType.Main)
			{
				if (Options.ViewportRef != ViewportRefType.Operation)
				{
					if (Options.ViewportRef == ViewportRefType.Preview)
					{
						design = clsItem.ModelMainPreview;
					}
				}
				else if (Options.GroupType != ShapeGroup.Drill)
				{
					if (Options.GroupType != ShapeGroup.Cut)
					{
						if (Options.GroupType != ShapeGroup.Shape)
						{
							if (Options.GroupType == ShapeGroup.Profiling)
							{
								design = clsItem.FrmProfilingList.viewportLayout;
							}
						}
						else
						{
							design = clsItem.FrmShapeList.viewportLayout;
						}
					}
					else
					{
						design = clsItem.FrmSlotList.viewportLayout;
					}
				}
				else
				{
					design = clsItem.FrmDrillList.viewportLayout;
				}
			}
			else
			{
				design = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
			}
			design.UpdateBoundingBox();
			for (int i = 0; i <= design.Entities.Count - 1; i++)
			{
				if (design.Entities[i].EntityData == null || !(design.Entities[i].EntityData is CustomData))
				{
					continue;
				}
				CustomData customData = design.Entities[i].EntityData as CustomData;
				if (customData.typeDefination == entityTypeDefination.Operation)
				{
					if ((customData.RefIndex >= 0) & (customData.RefIndex <= activeJob.Items.Count - 1))
					{
						design.Entities[i].Color = clsInit.cVector5.setbuShapeColors(activeJob.Items[customData.RefIndex]);
					}
					if ((Options.indexSelectdOP >= 0) & (Options.indexSelectdOPSub == -1) & (customData.RefIndex == Options.indexSelectdOP))
					{
						design.Entities[i].Color = clsVar5.VarbuShapeVisilation.colorOperationSelected.Color;
					}
					if ((Options.indexSelectdOP >= 0) & (Options.indexSelectdOPSub >= 0) & (customData.RefIndex == Options.indexSelectdOP) & (customData.Sequence == Options.indexSelectdOPSub))
					{
						design.Entities[i].Color = clsVar5.VarbuShapeVisilation.colorOperationSelected.Color;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void CreateMaterialsAndLayers(string FileName)
	{
		new List<string>();
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
		{
			clsItem.FrmPreview.viewportLayout.Materials.Add(material);
		}
		Layer layer = new Layer("Wood", Color.Brown);
		layer.LineWeight = 1f;
		layer.MaterialName = material.Name;
		bool flag = false;
		for (int i = 0; i <= clsItem.FrmPreview.viewportLayout.Layers.Count - 1; i++)
		{
			if (clsItem.FrmPreview.viewportLayout.Layers[i].Name == layer.Name)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			clsItem.FrmPreview.viewportLayout.Layers.AddOrReplace(layer);
		}
	}

	public void PageClosed()
	{
		if (JobList != null)
		{
			JobList.Clear();
			JobList = new List<DrillJob>();
			activeJob = null;
			clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
		}
	}

	public void OpenExtension()
	{
		if (JobList == null)
		{
			JobList = new List<DrillJob>();
		}
		JobList.Clear();
		clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
	}

	public void NewPageExtension()
	{
		if (JobList == null)
		{
			JobList = new List<DrillJob>();
		}
		JobList.Clear();
		clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
		timNew.Interval = 100;
		timNew.Enabled = true;
	}

	public void NewPageTick(object sender, EventArgs e)
	{
		timNew.Enabled = false;
		Point3D point3D = null;
		for (int i = 0; i <= ToolList.Count - 1; i++)
		{
			if (ToolList[i].Data.No == 31)
			{
				point3D = new Point3D();
				point3D.X = ToolList[i].Positions.CommonOffset.X;
				point3D.Y = ToolList[i].Positions.CommonOffset.Y;
				point3D.Z = ToolList[i].Positions.CommonOffset.Z;
			}
		}
		if ((point3D != null) & (ccVars.Tools.Count > 0))
		{
			for (int j = 0; j <= ccVars.Tools[0].Tools.Count - 1; j++)
			{
				ccVars.Tools[0].Tools[j].Positions.CommonOffset.X = point3D.X;
				ccVars.Tools[0].Tools[j].Positions.CommonOffset.Y = point3D.Y;
				ccVars.Tools[0].Tools[j].Positions.CommonOffset.Z = point3D.Z;
			}
		}
		if (!varDrillSettings.AutoOpenLastPanel)
		{
			if (!(varDrillSettings.AutoOpenLastPanelAndDrill & !varDrillSettings.AutoOpenLastPanel))
			{
			}
		}
		else
		{
			AddPanel(ccVars.activeMaterial);
		}
	}

	public void AddPanel(MaterialBase5 Mat)
	{
		if (ccVars.Pages.Count > 0)
		{
			activeJob = new DrillJob();
			if (JobList == null)
			{
				JobList = new List<DrillJob>();
			}
			JobList = new List<DrillJob>();
			if (Mat.Entities.Count == 0)
			{
				Entity Ent = null;
				clsInit.cVector5.CreateMaterialEntities(Mat, ref Ent);
				clsInit.cVector5.Move(0.0 - ccVars.activeMaterial.Size.Width, 0.0 - ccVars.activeMaterial.Size.Height, 0.0, ref Ent);
				Mat.Entities.Add(Ent);
			}
			activeJob.Material = new MaterialBase5(Mat);
			activeJob.Material.Sing = new Point3D(clsVar5.shapeCreatePar.SingX, clsVar5.shapeCreatePar.SingY, 1.0);
			if (Mat.Entities.Count > 0)
			{
				buEntity.Copy(Mat.Entities[0], ref activeJob.panelEntity);
			}
			double MaterialZeroYPos = 0.0;
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				cGoUltra2Up1Down.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				cGoAtc.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (MachType == DrillMachineType.Sirius)
			{
				cGoSirius.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (ClamperEntity != null)
			{
				clsInit.cDrill.CreateClamperEntities(ClamperEntity, activeJob.FirstClamperX, activeJob.SecondClamperX, ref activeJob.FirstClamperEntity, ref activeJob.SecondClamperEntity, Color.Gray);
			}
			DrawPanelFromJob(activeJob, new ViewportDrawOptions());
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
			clsInit.appCommand.cmdViewZoomFit();
			clsInit.appCommand.cmdViewZoomOut();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			JobList.Add(activeJob);
			selectedJobIndex = JobList.Count - 1;
			JobUpdate(FillPages: true, null);
			SaveDrillFile();
			clsFiles.SaveParameter();
		}
	}

	public void JobUpdate(bool FillPages, DrillItem Item, int indexItem = -1, string Command = "")
	{
		try
		{
			if (clsItem.FrmDrillJob == null)
			{
				return;
			}
			if (activeJob != null)
			{
				if (activeJob.Items.Count != clsItem.FrmDrillJob.tree_jobs.Nodes.Count)
				{
					FillPages = true;
				}
				_ = AppLanguage.CadCamDynamic[114];
				_ = AppLanguage.CadCamDynamic[108];
				_ = AppLanguage.CadCamDynamic[107] + " - ";
				_ = AppLanguage.CadCamDynamic[106];
				_ = AppLanguage.CadCamDynamic[112];
				TreeNodeSettings treeNodeSettings = null;
				TreeNodeSettings treeNodeSettings2 = null;
				if (!FillPages)
				{
					return;
				}
				List<string> list = new List<string>();
				clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
				string nodeText = JobToString(activeJob);
				treeNodeSettings = new TreeNodeSettings(nodeText)
				{
					ImageIndex = 0,
					SelectedImageIndex = 0,
					Tag = "0",
					ClassIndex = 0,
					ClassSubIndex = -1,
					ClassSubSubIndex = -1,
					Command = "panel",
					Checked = true
				};
				for (int i = 0; i <= activeJob.Items.Count - 1; i++)
				{
					string text = activeJob.Items[i].ShapeGroup.ToString().Trim();
					int num = JobImageIndex(activeJob.Items[i]);
					if (!activeJob.Items[i].Enable)
					{
						num = 1;
					}
					text = JobItemToString(activeJob.Items[i]);
					treeNodeSettings2 = new TreeNodeSettings(text)
					{
						ImageIndex = num,
						SelectedImageIndex = num,
						Tag = i.ToString(),
						ClassIndex = 0,
						ClassSubIndex = i,
						ClassSubSubIndex = -1,
						Command = "item",
						Checked = true
					};
					if (activeJob.Items[i].InfoMessages != null && activeJob.Items[i].InfoMessages.Count > 0)
					{
						treeNodeSettings2.ForeColor = Color.Red;
						for (int j = 0; j <= activeJob.Items[i].InfoMessages.Count - 1; j++)
						{
							list.Add("[ " + (j + 1) + ". " + buLangTranslate.preDef.Operation + " ] - " + activeJob.Items[i].InfoMessages[j]);
						}
					}
					if (activeJob.Items[i].ShapeGroup == ShapeGroup.Drill && activeJob.Items[i] is buShapeHoleMulti)
					{
						buShapeHoleMulti buShapeHoleMulti2 = activeJob.Items[i] as buShapeHoleMulti;
						if (buShapeHoleMulti2.multiCenter != null)
						{
							for (int k = 0; k <= buShapeHoleMulti2.multiCenter.Count - 1; k++)
							{
								string nodeText2 = "";
								if ((buShapeHoleMulti2.planeName == planeBoxNames.Top) | (buShapeHoleMulti2.planeName == planeBoxNames.Bottom))
								{
									nodeText2 = "X: " + buShapeHoleMulti2.multiCenter[k].Center.X.ToString("f2") + " , Y: " + buShapeHoleMulti2.multiCenter[k].Center.Y.ToString("f2");
								}
								if ((buShapeHoleMulti2.planeName == planeBoxNames.Front) | (buShapeHoleMulti2.planeName == planeBoxNames.Back))
								{
									nodeText2 = "X: " + buShapeHoleMulti2.multiCenter[k].Center.X.ToString("f2") + " , Z: " + buShapeHoleMulti2.multiCenter[k].Center.Z.ToString("f2");
								}
								if ((buShapeHoleMulti2.planeName == planeBoxNames.Left) | (buShapeHoleMulti2.planeName == planeBoxNames.Right))
								{
									nodeText2 = "Y: " + buShapeHoleMulti2.multiCenter[k].Center.Y.ToString("f2") + " , Z: " + buShapeHoleMulti2.multiCenter[k].Center.Z.ToString("f2");
								}
								TreeNodeSettings node = new TreeNodeSettings(nodeText2)
								{
									ImageIndex = 9,
									SelectedImageIndex = 9,
									Tag = i.ToString(),
									ClassIndex = 0,
									ClassSubIndex = i,
									ClassSubSubIndex = k,
									Command = "subitem",
									Checked = true
								};
								treeNodeSettings2.Nodes.Add(node);
							}
						}
					}
					if (treeNodeSettings2 != null)
					{
						treeNodeSettings.Nodes.Add(treeNodeSettings2);
					}
				}
				for (int l = 0; l <= list.Count - 1; l++)
				{
					TreeNodeSettings node2 = new TreeNodeSettings(list[l])
					{
						ImageIndex = 39,
						SelectedImageIndex = 39,
						Tag = "",
						ClassIndex = -1,
						ClassSubIndex = -1,
						ClassSubSubIndex = -1,
						Command = "info",
						Checked = true
					};
					treeNodeSettings.Nodes.Add(node2);
				}
				if (treeNodeSettings != null)
				{
					treeNodeSettings.Expand();
					clsItem.FrmDrillJob.tree_jobs.Nodes.Add(treeNodeSettings);
				}
			}
			else
			{
				clsItem.FrmDrillJob.tree_jobs.Nodes.Clear();
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public int JobImageIndex(buShape Item)
	{
		int result = -1;
		if (Item.ShapeGroup == ShapeGroup.Drill)
		{
			if (!(Item.GetType() == typeof(buShapeHole)))
			{
				if (!(Item.GetType() == typeof(buShapeHoleMulti)))
				{
					if (Item.GetType() == typeof(buShapeHole3))
					{
						result = 8;
					}
				}
				else
				{
					buShapeHoleMulti buShapeHoleMulti2 = Item as buShapeHoleMulti;
					if (buShapeHoleMulti2.DrillType == drillTypes.HorizontalHoles)
					{
						result = 3;
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.HorizontalLineHoles)
					{
						result = 4;
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.VerticalHoles)
					{
						result = 5;
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.VerticalLineHoles)
					{
						result = 6;
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.InclineHoles)
					{
						result = 7;
					}
				}
			}
			else
			{
				result = 2;
				if (((buShapeHole)Item).isMilling)
				{
					result = 9;
				}
			}
		}
		if (Item.ShapeGroup == ShapeGroup.Shape)
		{
			if (Item.ShapeType == ShapeTypes.Circle)
			{
				result = 10;
			}
			if (Item.ShapeType == ShapeTypes.Ellipse)
			{
				result = 11;
			}
			if (Item.ShapeType == ShapeTypes.FreeDraw)
			{
				result = 12;
			}
			if (Item.ShapeType == ShapeTypes.KeyHole)
			{
				result = 14;
			}
			if (Item.ShapeType == ShapeTypes.Polygon)
			{
				result = 15;
			}
			if (Item.ShapeType == ShapeTypes.Rectangle)
			{
				result = 16;
				if (((buShapeRectangle)Item).Radius > 0.0)
				{
					result = 17;
				}
			}
			if (Item.ShapeType == ShapeTypes.Rhombus)
			{
				result = 18;
			}
			if (Item.ShapeType == ShapeTypes.Slot)
			{
				result = 19;
			}
			if (Item.ShapeType == ShapeTypes.Star)
			{
				result = 20;
			}
			if (Item.ShapeType == ShapeTypes.Text)
			{
				result = 21;
			}
			if (Item.ShapeType == ShapeTypes.Trepezoid)
			{
				result = 22;
			}
			if (Item.ShapeType == ShapeTypes.Triangle)
			{
				result = 23;
			}
		}
		if (Item.ShapeGroup == ShapeGroup.Cut && Item.GetType() == typeof(buShapeCut))
		{
			buShapeCut buShapeCut2 = Item as buShapeCut;
			if (buShapeCut2.CutType == CutTypes.CutHorizontal)
			{
				result = (buShapeCut2.isMilling ? 24 : 29);
			}
			if (buShapeCut2.CutType == CutTypes.CutHorizontalLine)
			{
				result = 25;
			}
			if (buShapeCut2.CutType == CutTypes.CutVertical)
			{
				result = 26;
			}
			if (buShapeCut2.CutType == CutTypes.CutVerticalLine)
			{
				result = 27;
			}
			if (buShapeCut2.CutType == CutTypes.CutFree)
			{
				result = 28;
			}
		}
		if (Item.ShapeGroup == ShapeGroup.Profiling)
		{
			buShapeProfiling buShapeProfiling2 = Item as buShapeProfiling;
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRectangle)
			{
				result = 30;
			}
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRound)
			{
				result = 31;
			}
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingChamfer)
			{
				result = 32;
			}
			if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRoundConcave)
			{
				result = 40;
			}
		}
		if (Item.ShapeGroup == ShapeGroup.Engraving)
		{
			result = 33;
		}
		if (Item.ShapeGroup == ShapeGroup.Junction)
		{
			buShapeJunction buShapeJunction2 = Item as buShapeJunction;
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction2HoleNearByHorizontal)
			{
				result = 34;
			}
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction2HoleNearByVertical)
			{
				result = 35;
			}
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal)
			{
				result = 36;
			}
			if (buShapeJunction2.JunctionType == JunctionTypes.Junction3HoleIntersectVertical)
			{
				result = 37;
			}
		}
		if (Item.ShapeGroup == ShapeGroup.Contour)
		{
			result = 38;
		}
		return result;
	}

	public string JobItemToString(buShape Item)
	{
		string text = "";
		if (Item.ShapeGroup != ShapeGroup.Drill)
		{
			if (Item.ShapeGroup != ShapeGroup.Shape)
			{
				if (Item.ShapeGroup != ShapeGroup.Cut)
				{
					if (Item.ShapeGroup != ShapeGroup.Profiling)
					{
						if (Item.ShapeGroup != ShapeGroup.Contour)
						{
							if (Item.ShapeGroup != ShapeGroup.Text)
							{
								if (Item.ShapeGroup != ShapeGroup.Engraving)
								{
									if (Item.ShapeGroup == ShapeGroup.Junction && Item.GetType() == typeof(buShapeJunction))
									{
										buShapeJunction buShapeJunction2 = Item as buShapeJunction;
										if ((buShapeJunction2.JunctionType == JunctionTypes.Junction3HoleIntersectHorizontal) | (buShapeJunction2.JunctionType == JunctionTypes.Junction3HoleIntersectVertical))
										{
											text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Diameter + ": " + buShapeJunction2.Diameter.ToString("f2") + " , " + buLangTranslate.preDef.Distance + ": " + buShapeJunction2.Distance.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeJunction2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeJunction2.Depth;
										}
										if ((buShapeJunction2.JunctionType == JunctionTypes.Junction2HoleNearByHorizontal) | (buShapeJunction2.JunctionType == JunctionTypes.Junction2HoleNearByVertical))
										{
											text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Diameter + ": " + buShapeJunction2.Diameter.ToString("f2") + " , " + buLangTranslate.preDef.Diameter + " " + buLangTranslate.preDef.Outside + ": " + buShapeJunction2.Distance.ToString("f2") + " , " + buLangTranslate.preDef.Distance + ": " + buShapeJunction2.Distance.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeJunction2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeJunction2.Depth;
										}
									}
								}
								else if (Item.GetType() == typeof(buShapeEngrave))
								{
									buShapeEngrave buShapeEngrave2 = Item as buShapeEngrave;
									text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Width + ": " + buShapeEngrave2.Width.ToString("f2") + buLangTranslate.preDef.Height + ": " + buShapeEngrave2.Height.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeEngrave2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeEngrave2.Depth;
								}
							}
						}
						else
						{
							text = clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Offset + ": " + Item.OffsetDistance.ToString("f1") + " , " + buLangTranslate.preDef.Depth + ": " + Item.Depth.ToString("f1");
						}
					}
					else if (Item.GetType() == typeof(buShapeProfiling))
					{
						buShapeProfiling buShapeProfiling2 = Item as buShapeProfiling;
						if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRectangle)
						{
							text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Width + ": " + buShapeProfiling2.Width.ToString("f2") + buLangTranslate.preDef.Height + ": " + buShapeProfiling2.Height.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeProfiling2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeProfiling2.Depth;
						}
						if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRound)
						{
							text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Radius + ": " + buShapeProfiling2.Radius.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeProfiling2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeProfiling2.Depth;
						}
						if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingChamfer)
						{
							text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Length + ": " + buShapeProfiling2.Length.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeProfiling2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeProfiling2.Depth;
						}
						if (buShapeProfiling2.ProfilingType == ProfilingTypes.ProfilingRoundConcave)
						{
							text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Radius + ": " + buShapeProfiling2.Radius.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeProfiling2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeProfiling2.Depth;
						}
					}
				}
				else if (Item.GetType() == typeof(buShapeCut))
				{
					buShapeCut buShapeCut2 = Item as buShapeCut;
					text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Diameter + ": " + buShapeCut2.Diameter.ToString("f2") + buLangTranslate.preDef.Length + ": " + buShapeCut2.Length.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeCut2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeCut2.Depth;
				}
			}
			else
			{
				text += clsInit.cDrill.JobItemCommandToString(Item);
				if (Item.ShapeType != ShapeTypes.Circle)
				{
					if (Item.ShapeType != ShapeTypes.Rectangle)
					{
						if (Item.ShapeType != ShapeTypes.Ellipse)
						{
							if (Item.ShapeType != ShapeTypes.Slot)
							{
								if (Item.ShapeType != ShapeTypes.Polygon)
								{
									if (Item.ShapeType != ShapeTypes.FreeDraw)
									{
										if (Item.ShapeType != ShapeTypes.FreeLines)
										{
											if (Item.ShapeType == ShapeTypes.KeyHole)
											{
												buShapeKeyHole buShapeKeyHole2 = Item as buShapeKeyHole;
												text = text + " - " + buLangTranslate.preDef.Length + ": " + buShapeKeyHole2.Length.ToString("f2") + " , " + buLangTranslate.preDef.HeadDiameter + ": " + buShapeKeyHole2.HeadDiameter.ToString("f2") + " , " + buLangTranslate.preDef.Diameter + ": " + buShapeKeyHole2.Diameter.ToString("f2");
											}
										}
										else
										{
											buShapeFreeLines buShapeFreeLines2 = Item as buShapeFreeLines;
											text = text + " - " + buLangTranslate.preDef.Width + ": " + buShapeFreeLines2.Width.ToString("f2") + " , " + buLangTranslate.preDef.Height + ": " + buShapeFreeLines2.Height.ToString("f2");
										}
									}
									else
									{
										buShapeFreeDraw buShapeFreeDraw2 = Item as buShapeFreeDraw;
										text = text + " - " + buLangTranslate.preDef.Width + ": " + buShapeFreeDraw2.Width.ToString("f2") + " , " + buLangTranslate.preDef.Height + ": " + buShapeFreeDraw2.Height.ToString("f2");
									}
								}
								else
								{
									buShapePolygon buShapePolygon2 = Item as buShapePolygon;
									text = text + " - " + buLangTranslate.preDef.Side + ": " + buShapePolygon2.Side.ToString("") + " , " + buLangTranslate.preDef.Diameter + ": " + (buShapePolygon2.Radius * 2.0).ToString("f2");
								}
							}
							else
							{
								buShapeSlot buShapeSlot2 = Item as buShapeSlot;
								text = text + " - " + buLangTranslate.preDef.Length + ": " + buShapeSlot2.Length.ToString("f2") + " , " + buLangTranslate.preDef.Diameter + ": " + buShapeSlot2.Diameter.ToString("f2");
							}
						}
						else
						{
							buShapeEllipse buShapeEllipse2 = Item as buShapeEllipse;
							text = text + " - " + buLangTranslate.preDef.DiaX + ": " + (buShapeEllipse2.RadiusX * 2.0).ToString("f2") + " , " + buLangTranslate.preDef.DiaY + ": " + (buShapeEllipse2.RadiusY * 2.0).ToString("f2");
						}
					}
					else
					{
						buShapeRectangle buShapeRectangle2 = Item as buShapeRectangle;
						text = text + " - " + buLangTranslate.preDef.Width + ": " + buShapeRectangle2.Width.ToString("f2") + " , " + buLangTranslate.preDef.Height + ": " + buShapeRectangle2.Height.ToString("f2");
					}
				}
				else
				{
					buShapeCircle buShapeCircle2 = Item as buShapeCircle;
					text = text + " - " + buLangTranslate.preDef.Diameter + ": " + (buShapeCircle2.Radius * 2.0).ToString("f2");
				}
				text = text + " , " + buLangTranslate.preDef.Plane + ": " + Item.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + Item.Depth;
			}
		}
		else if (!(Item.GetType() == typeof(buShapeHole)))
		{
			if (!(Item.GetType() == typeof(buShapeHoleMulti)))
			{
				if (Item.GetType() == typeof(buShapeHole3))
				{
					buShapeHole3 buShapeHole4 = Item as buShapeHole3;
					text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Diameter + ": " + buShapeHole4.Diameter.ToString("f2") + " , " + buLangTranslate.preDef.Outside + " " + buLangTranslate.preDef.Diameter + ": " + buShapeHole4.DiameterOutside.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeHole4.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeHole4.Depth;
				}
			}
			else
			{
				buShapeHoleMulti buShapeHoleMulti2 = Item as buShapeHoleMulti;
				text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Diameter + ": " + buShapeHoleMulti2.Diameter.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeHoleMulti2.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeHoleMulti2.Depth;
			}
		}
		else
		{
			buShapeHole buShapeHole5 = Item as buShapeHole;
			text = text + clsInit.cDrill.JobItemCommandToString(Item) + " - " + buLangTranslate.preDef.Diameter + ": " + buShapeHole5.Diameter.ToString("f2") + " , " + buLangTranslate.preDef.Plane + ": " + buShapeHole5.planeName.ToString() + " , " + buLangTranslate.preDef.Depth + ": " + buShapeHole5.Depth;
		}
		return text;
	}

	public string JobToString(DrillJob Job)
	{
		string text = Job.Name.Trim();
		if (text.Length == 0)
		{
			text = AppLanguage.CadCamDynamic[114];
		}
		return text + "- W: " + Job.Material.Size.Width + ", H: " + Job.Material.Size.Height + ", D: " + Job.Material.Size.Depth;
	}

	public void Job_AfterChecked(object sender, TreeViewEventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)e.Node;
		if (treeNodeSettings != null)
		{
			_ = treeNodeSettings.Checked;
			switch (treeNodeSettings.Command)
			{
			case "panel":
				if (treeNodeSettings.ClassIndex >= 0)
				{
					bool_0 = true;
					selectedJobIndex = treeNodeSettings.ClassIndex;
					selectedItemIndex = -1;
					selectedItemSubIndex = -1;
					bool_0 = false;
				}
				break;
			case "item":
				if (treeNodeSettings.ClassIndex >= 0)
				{
					bool_0 = true;
					selectedJobIndex = treeNodeSettings.ClassIndex;
					selectedItemIndex = treeNodeSettings.ClassSubIndex;
					selectedItemSubIndex = -1;
					bool_0 = false;
				}
				break;
			case "itemsub":
				if (treeNodeSettings.ClassIndex >= 0)
				{
					bool_0 = true;
					selectedJobIndex = treeNodeSettings.ClassIndex;
					selectedItemIndex = treeNodeSettings.ClassSubIndex;
					selectedItemSubIndex = treeNodeSettings.ClassSubSubIndex;
					bool_0 = false;
				}
				break;
			}
		}
		if (activeJob != null)
		{
			UpdateSelectedOperation(new ViewportDrawOptions(ViewportRefType.Main, selectedItemIndex, selectedItemSubIndex));
		}
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
		TreeView treeView = (TreeView)sender;
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)treeView.SelectedNode;
		selectedJobIndex = -1;
		selectedItemIndex = -1;
		selectedItemSubIndex = -1;
		if (clsItem.FrmDrillJob.tree_jobs.Nodes != null && clsItem.FrmDrillJob.tree_jobs.Nodes.Count > 0)
		{
			clsItem.FrmDrillJob.tree_jobs.Nodes[0].BackColor = Color.White;
			if (clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes != null)
			{
				for (int i = 0; i <= clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes.Count - 1; i++)
				{
					clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes[i].BackColor = Color.White;
				}
			}
		}
		if (treeNodeSettings.Parent != null)
		{
			treeNodeSettings.BackColor = Color.LightSteelBlue;
		}
		switch (treeNodeSettings.Command)
		{
		case "panel":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				selectedJobIndex = treeNodeSettings.ClassIndex;
			}
			break;
		case "item":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				selectedJobIndex = treeNodeSettings.ClassIndex;
				selectedItemIndex = treeNodeSettings.ClassSubIndex;
				selectedItemSubIndex = treeNodeSettings.ClassSubSubIndex;
			}
			break;
		case "subitem":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				selectedJobIndex = treeNodeSettings.ClassIndex;
				selectedItemIndex = treeNodeSettings.ClassSubIndex;
				selectedItemSubIndex = treeNodeSettings.ClassSubSubIndex;
			}
			break;
		}
		if (activeJob != null)
		{
			UpdateSelectedOperation(new ViewportDrawOptions(ViewportRefType.Main, selectedItemIndex, selectedItemSubIndex));
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public void AddDrillMove(double X1, double X2, double Y1, double Y2, double Y3, double Z1, double Z2, double Z3, DrillMoveCommand Cmd, drillPlaneNames Plane, double X, ref DrillJob Job)
	{
		DrillMoveOptions options = new DrillMoveOptions(Plane, DrillCNCMode.Fast, DrillMoveAddType.BothMoveAndSimulation);
		AddDrillMove(X1, X2, Y1, Y2, Y3, Z1, Z2, Z3, Cmd, X, options, ref Job);
	}

	public void AddDrillMove(double X1, double X2, double Y1, double Y2, double Y3, double Z1, double Z2, double Z3, DrillMoveCommand Cmd, drillPlaneNames Plane, DrillCNCMode Mode, double X, ref DrillJob Job)
	{
		DrillMoveOptions options = new DrillMoveOptions(Plane, Mode, DrillMoveAddType.BothMoveAndSimulation);
		AddDrillMove(X1, X2, Y1, Y2, Y3, Z1, Z2, Z3, Cmd, X, options, ref Job);
	}

	public void AddDrillMove(double X1, double X2, double Y1, double Y2, double Y3, double Z1, double Z2, double Z3, DrillMoveCommand Cmd, drillPlaneNames Plane, DrillCNCMode Mode, double X, int Tool1, int Tool2, int Tool3, int Tool4, int Tool5, int Tool6, ref DrillJob Job)
	{
		DrillMoveOptions options = new DrillMoveOptions(Plane, Mode, DrillMoveAddType.BothMoveAndSimulation, Tool1, Tool2, Tool3, Tool4, Tool5, Tool6);
		AddDrillMove(X1, X2, Y1, Y2, Y3, Z1, Z2, Z3, Cmd, X, options, ref Job);
	}

	public void AddDrillMove(double X1, double X2, double Y1, double Y2, double Y3, double Z1, double Z2, double Z3, DrillMoveCommand Cmd, double X, DrillMoveOptions Options, ref DrillJob Job)
	{
		double x = X1;
		double x2 = X2;
		double y = Y1;
		double y2 = Y2;
		double y3 = Y3;
		double z = Z1;
		double z2 = Z2;
		double z3 = Z3;
		double xPos = X;
		if (Job.Moves.Count > 0 && Cmd == DrillMoveCommand.AxisMove)
		{
			double x1Clamper = Job.Moves[Job.Moves.Count - 1].X1Clamper;
			double x2Clamper = Job.Moves[Job.Moves.Count - 1].X2Clamper;
			double xPosition = Job.Moves[Job.Moves.Count - 1].XPosition;
			double y1Position = Job.Moves[Job.Moves.Count - 1].Y1Position;
			double y2Position = Job.Moves[Job.Moves.Count - 1].Y2Position;
			double y3Position = Job.Moves[Job.Moves.Count - 1].Y3Position;
			double z1Position = Job.Moves[Job.Moves.Count - 1].Z1Position;
			double z2Position = Job.Moves[Job.Moves.Count - 1].Z2Position;
			double z3Position = Job.Moves[Job.Moves.Count - 1].Z3Position;
			if (((buCompare5.EQ(X1, x1Clamper, 0.01) | (X1 == NoMove)) & (buCompare5.EQ(X2, x2Clamper, 0.01) | (X2 == NoMove)) & (buCompare5.EQ(X, xPosition, 0.01) | (X == NoMove))) && ((buCompare5.EQ(Y1, y1Position, 0.01) | (Y1 == NoMove)) & (buCompare5.EQ(Y2, y2Position, 0.01) | (Y2 == NoMove)) & (buCompare5.EQ(Y3, y3Position, 0.01) | (Y3 == NoMove))) && ((buCompare5.EQ(Z1, z1Position, 0.01) | (Z1 == NoMove)) & (buCompare5.EQ(Z2, z2Position, 0.01) | (Z2 == NoMove)) & (buCompare5.EQ(Z3, z3Position, 0.01) | (Z3 == NoMove))))
			{
				if ((Options.Cmd1 == DrillMoveCommand.None) & (Options.Cmd2 == DrillMoveCommand.None) & (Options.Cmd3 == DrillMoveCommand.None))
				{
					return;
				}
				if (Options.Cmd1 == DrillMoveCommand.ResetAll)
				{
					Cmd = Options.Cmd1;
				}
				if (Options.Cmd2 == DrillMoveCommand.ResetAll)
				{
					Cmd = Options.Cmd2;
				}
				if (Options.Cmd3 == DrillMoveCommand.ResetAll)
				{
					Cmd = Options.Cmd3;
				}
				if (Options.Cmd1 == DrillMoveCommand.SetPiston)
				{
					Cmd = Options.Cmd1;
				}
				if (Options.Cmd2 == DrillMoveCommand.SetPiston)
				{
					Cmd = Options.Cmd2;
				}
				if (Options.Cmd3 == DrillMoveCommand.SetPiston)
				{
					Cmd = Options.Cmd3;
				}
			}
		}
		if (Cmd == DrillMoveCommand.AxisMove && ((X1 == NoMove) & (X2 == NoMove) & (Y1 == NoMove) & (Y2 == NoMove) & (Y3 == NoMove) & (Z1 == NoMove) & (Z2 == NoMove) & (Z3 == NoMove) & (X == NoMove)) && ((Options.Cmd1 == DrillMoveCommand.None) & (Options.Cmd2 == DrillMoveCommand.None) & (Options.Cmd3 == DrillMoveCommand.None)))
		{
			return;
		}
		if ((Job.Moves.Count > 0) & (X1 == NoMove))
		{
			x = Job.Moves[Job.Moves.Count - 1].X1Clamper;
		}
		if ((Job.Moves.Count > 0) & (X2 == NoMove))
		{
			x2 = Job.Moves[Job.Moves.Count - 1].X2Clamper;
		}
		if ((Job.Moves.Count > 0) & (Y1 == NoMove))
		{
			y = Job.Moves[Job.Moves.Count - 1].Y1Position;
		}
		if ((Job.Moves.Count > 0) & (Y2 == NoMove))
		{
			y2 = Job.Moves[Job.Moves.Count - 1].Y2Position;
		}
		if ((Job.Moves.Count > 0) & (Y3 == NoMove))
		{
			y3 = Job.Moves[Job.Moves.Count - 1].Y3Position;
		}
		if ((Job.Moves.Count > 0) & (Z1 == NoMove))
		{
			z = Job.Moves[Job.Moves.Count - 1].Z1Position;
		}
		if ((Job.Moves.Count > 0) & (Z2 == NoMove))
		{
			z2 = Job.Moves[Job.Moves.Count - 1].Z2Position;
		}
		if ((Job.Moves.Count > 0) & (Z3 == NoMove))
		{
			z3 = Job.Moves[Job.Moves.Count - 1].Z3Position;
		}
		if ((Job.Moves.Count > 0) & (X == NoMove))
		{
			xPos = Job.Moves[Job.Moves.Count - 1].XPosition;
		}
		DrillMove drillMove = new DrillMove(x, x2, y, y2, y3, z, z2, z3, Cmd, xPos);
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
		if (Options.pntCenter != null)
		{
			drillMove.pntCenter = new Point3D(Options.pntCenter.X, Options.pntCenter.Y, Options.pntCenter.Z);
		}
		if (Options.AddType != DrillMoveAddType.OnlyMove)
		{
			if (Options.AddType != DrillMoveAddType.OnlySimulation)
			{
				Job.Moves.Add(drillMove);
				if (!(Job.SimulationMoves.Count == 0 || Cmd != DrillMoveCommand.AxisMove))
				{
					double devideLen = varDrillCNCSettings.SimulationDevideG0Length;
					if ((drillMove.Mode == DrillCNCMode.Plunge) | (drillMove.Mode == DrillCNCMode.Cut))
					{
						devideLen = varDrillCNCSettings.SimulationDevideG1Length;
					}
					List<DrillMove> calcSimMoves = new List<DrillMove>();
					clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, devideLen, ref calcSimMoves);
					if (calcSimMoves.Count > 0)
					{
						for (int i = 0; i <= calcSimMoves.Count - 1; i++)
						{
							calcSimMoves[i].LineIndex = Job.Moves.Count - 1;
							Job.SimulationMoves.Add(calcSimMoves[i]);
						}
					}
				}
				else
				{
					DrillMove drillMove2 = new DrillMove(drillMove);
					drillMove2.LineIndex = Job.Moves.Count - 1;
					Job.SimulationMoves.Add(drillMove2);
				}
			}
			else if (Job.SimulationMoves.Count != 0)
			{
				List<DrillMove> calcSimMoves2 = new List<DrillMove>();
				clsInit.cDrill.SimPointMoveCalculate(Job.SimulationMoves[Job.SimulationMoves.Count - 1], drillMove, Options.DevideLen, ref calcSimMoves2);
				if (calcSimMoves2.Count > 0)
				{
					for (int j = 0; j <= calcSimMoves2.Count - 1; j++)
					{
						Job.SimulationMoves.Add(calcSimMoves2[j]);
					}
				}
			}
			else
			{
				Job.SimulationMoves.Add(drillMove);
			}
		}
		else
		{
			Job.Moves.Add(drillMove);
		}
	}

	public void MirrorOperation(ref DrillJob Job)
	{
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (!(Job.Items[i] is buShapeHole))
			{
				if (Job.Items[i] is buShapeCut)
				{
					buShapeCut buShapeCut2 = Job.Items[i] as buShapeCut;
					buShapeCut2.BasePoint.Y = Job.Material.Size.Height - buShapeCut2.BasePoint.Y;
					clsVar5.shapeCreatePar.Solid = true;
					clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
					clsVar5.shapeCreatePar.SingX = -1.0;
					clsVar5.shapeCreatePar.SingY = -1.0;
					buShape Shape = buShapeCut2;
					clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
					if (buShapeCut2.entityWireframe.Count > 0)
					{
						clsInit.cVector5.Mirror(new Point3D(0.0, (0.0 - Job.Material.Size.Height) / 2.0, 0.0), new Point3D(10.0, (0.0 - Job.Material.Size.Height) / 2.0, 0.0), Plane.XY, ref buShapeCut2.entityWireframe);
					}
				}
				continue;
			}
			buShapeHole buShapeHole4 = Job.Items[i] as buShapeHole;
			if (buShapeHole4.planeName == planeBoxNames.Top)
			{
				buShapeHole4.BasePoint.Y = Job.Material.Size.Height - buShapeHole4.BasePoint.Y;
				clsVar5.shapeCreatePar.Solid = true;
				clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
				clsVar5.shapeCreatePar.SingX = -1.0;
				clsVar5.shapeCreatePar.SingY = -1.0;
				buShape Shape2 = buShapeHole4;
				clsInit.cVector5.CreatebuShape(ref Shape2, clsVar5.shapeCreatePar);
			}
			if ((buShapeHole4.planeName == planeBoxNames.Left) | (buShapeHole4.planeName == planeBoxNames.Right))
			{
				buShapeHole4.BasePoint.Y = Job.Material.Size.Height - buShapeHole4.BasePoint.Y;
				clsVar5.shapeCreatePar.Solid = true;
				clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
				clsVar5.shapeCreatePar.SingX = -1.0;
				clsVar5.shapeCreatePar.SingY = -1.0;
				buShape Shape3 = buShapeHole4;
				clsInit.cVector5.CreatebuShape(ref Shape3, clsVar5.shapeCreatePar);
			}
			if (buShapeHole4.planeName == planeBoxNames.Front)
			{
				buShapeHole4.planeName = planeBoxNames.Back;
				buShapeHole4.BasePoint.Y = 0.0;
				clsVar5.shapeCreatePar.Solid = true;
				clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
				clsVar5.shapeCreatePar.SingX = -1.0;
				clsVar5.shapeCreatePar.SingY = -1.0;
				buShape Shape4 = buShapeHole4;
				clsInit.cVector5.CreatebuShape(ref Shape4, clsVar5.shapeCreatePar);
			}
			if (buShapeHole4.planeName == planeBoxNames.Back)
			{
				buShapeHole4.planeName = planeBoxNames.Front;
				buShapeHole4.BasePoint.Y = Job.Material.Size.Height;
				clsVar5.shapeCreatePar.Solid = true;
				clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
				clsVar5.shapeCreatePar.SingX = -1.0;
				clsVar5.shapeCreatePar.SingY = -1.0;
				buShape Shape5 = buShapeHole4;
				clsInit.cVector5.CreatebuShape(ref Shape5, clsVar5.shapeCreatePar);
			}
			if (buShapeHole4.entityWireframe.Count > 0)
			{
				clsInit.cVector5.Mirror(new Point3D(0.0, (0.0 - Job.Material.Size.Height) / 2.0, 0.0), new Point3D(10.0, (0.0 - Job.Material.Size.Height) / 2.0, 0.0), Plane.XY, ref buShapeHole4.entityWireframe);
			}
		}
	}

	public bool isOperationActive()
	{
		if (clsItem.FrmDrillList == null || !clsItem.FrmDrillList.Visible)
		{
			if (clsItem.FrmProfilingList == null || !clsItem.FrmProfilingList.Visible)
			{
				if (clsItem.FrmShapeList == null || !clsItem.FrmShapeList.Visible)
				{
					if (clsItem.FrmJunctionList == null || !clsItem.FrmJunctionList.Visible)
					{
						if (clsItem.FrmSlotList == null || !clsItem.FrmSlotList.Visible)
						{
							if (clsItem.FrmEngraveList == null || !clsItem.FrmSlotList.Visible)
							{
								return false;
							}
							return true;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return true;
		}
		return true;
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
			if (!(Shape.GetType() == typeof(buShapeHole)))
			{
				if (!(Shape.GetType() == typeof(buShapeHoleMulti)))
				{
					if (Shape.GetType() == typeof(buShapeHole3))
					{
						buShapeHole3 buShapeHole4 = Shape as buShapeHole3;
						if (buShapeHole4.DrillType == drillTypes.ThreeHole)
						{
							varSettings.DrillType = buShapeHole4.DrillType;
							varSettings.HoleDiameter = buShapeHole4.Diameter;
							varSettings.HoleDiameterOutside = buShapeHole4.DiameterOutside;
							varSettings.HoleDepth = buShapeHole4.Depth;
							varSettings.HoleOutsideDisX = buShapeHole4.DistanceX;
							varSettings.HoleOutsideDisY = buShapeHole4.DistanceY;
							varSettings.HoleAngle3Point = buShapeHole4.Hole3Angle;
							varSettings.isMillingHole = buShapeHole4.isMilling;
						}
					}
				}
				else
				{
					buShapeHoleMulti buShapeHoleMulti2 = Shape as buShapeHoleMulti;
					if ((buShapeHoleMulti2.DrillType == drillTypes.HorizontalHoles) | (buShapeHoleMulti2.DrillType == drillTypes.VerticalHoles))
					{
						varSettings.DrillType = buShapeHoleMulti2.DrillType;
						varSettings.HoleDiameter = buShapeHoleMulti2.Diameter;
						varSettings.HoleDepth = buShapeHoleMulti2.Depth;
						varSettings.HoleDistance = buShapeHoleMulti2.Distance;
						varSettings.HoleCount = buShapeHoleMulti2.Count;
						varSettings.isMillingHole = buShapeHoleMulti2.isMilling;
					}
					if ((buShapeHoleMulti2.DrillType == drillTypes.HorizontalLineHoles) | (buShapeHoleMulti2.DrillType == drillTypes.VerticalLineHoles))
					{
						varSettings.DrillType = buShapeHoleMulti2.DrillType;
						varSettings.HoleDiameter = buShapeHoleMulti2.Diameter;
						varSettings.HoleDepth = buShapeHoleMulti2.Depth;
						varSettings.HoleDistance = buShapeHoleMulti2.Distance;
						varSettings.HoleEndDistance = buShapeHoleMulti2.EndDistance;
						varSettings.HoleStartDistance = buShapeHoleMulti2.StartDistance;
						varSettings.isMillingHole = buShapeHoleMulti2.isMilling;
					}
					if (buShapeHoleMulti2.DrillType == drillTypes.InclineHoles)
					{
						varSettings.DrillType = buShapeHoleMulti2.DrillType;
						varSettings.HoleDiameter = buShapeHoleMulti2.Diameter;
						varSettings.HoleDepth = buShapeHoleMulti2.Depth;
						varSettings.HoleDistance = buShapeHoleMulti2.Distance;
						varSettings.HoleAngle = buShapeHoleMulti2.Angle;
						varSettings.HoleCount = buShapeHoleMulti2.Count;
						varSettings.isMillingHole = buShapeHoleMulti2.isMilling;
					}
				}
			}
			else
			{
				buShapeHole buShapeHole5 = Shape as buShapeHole;
				varSettings.DrillType = buShapeHole5.DrillType;
				varSettings.HoleDiameter = buShapeHole5.Diameter;
				varSettings.HoleDepth = buShapeHole5.Depth;
				varSettings.isMillingHole = buShapeHole5.isMilling;
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
				buShapeCircle buShapeCircle2 = Shape as buShapeCircle;
				varSettings.CircleDepth = buShapeCircle2.Depth;
				varSettings.CircleRadius = buShapeCircle2.Radius;
			}
			if (Shape.ShapeType == ShapeTypes.Ellipse)
			{
				buShapeEllipse buShapeEllipse2 = Shape as buShapeEllipse;
				varSettings.EllipseDepth = buShapeEllipse2.Depth;
				varSettings.EllipseAngle = buShapeEllipse2.Angle;
				varSettings.EllipseRadiusX = buShapeEllipse2.RadiusX;
				varSettings.EllipseRadiusY = buShapeEllipse2.RadiusY;
			}
			if (Shape.ShapeType == ShapeTypes.FreeDraw)
			{
				buShapeFreeDraw buShapeFreeDraw2 = Shape as buShapeFreeDraw;
				varSettings.FreeDrawDepth = buShapeFreeDraw2.Depth;
				varSettings.FreeDrawAngle = buShapeFreeDraw2.Angle;
				varSettings.FreeDrawWidth = buShapeFreeDraw2.Width;
				varSettings.FreeDrawHeight = buShapeFreeDraw2.Height;
			}
			if (Shape.ShapeType == ShapeTypes.KeyHole)
			{
				buShapeKeyHole buShapeKeyHole2 = Shape as buShapeKeyHole;
				varSettings.KeyHoleAngle = buShapeKeyHole2.Angle;
				varSettings.KeyHoleDepth = buShapeKeyHole2.Depth;
				varSettings.KeyHoleDiameter = buShapeKeyHole2.Diameter;
				varSettings.KeyHoleHeadDiameter = buShapeKeyHole2.HeadDiameter;
				varSettings.KeyHoleLength = buShapeKeyHole2.Length;
			}
			if (Shape.ShapeType == ShapeTypes.Polygon)
			{
				buShapePolygon buShapePolygon2 = Shape as buShapePolygon;
				varSettings.PolygonAngle = buShapePolygon2.Angle;
				varSettings.PolygonDepth = buShapePolygon2.Depth;
				varSettings.PolygonRadius = buShapePolygon2.Radius;
				varSettings.PolygonSide = buShapePolygon2.Side;
			}
			if (Shape.ShapeType == ShapeTypes.Rectangle)
			{
				buShapeRectangle buShapeRectangle2 = Shape as buShapeRectangle;
				varSettings.RectangleAngle = buShapeRectangle2.Angle;
				varSettings.RectangleChamfer = buShapeRectangle2.Chamfer;
				varSettings.RectangleDepth = buShapeRectangle2.Depth;
				varSettings.RectangleHeight = buShapeRectangle2.Height;
				varSettings.RectangleRadius = buShapeRectangle2.Radius;
				varSettings.RectangleWidth = buShapeRectangle2.Width;
			}
			if (Shape.ShapeType == ShapeTypes.Slot)
			{
				buShapeSlot buShapeSlot2 = Shape as buShapeSlot;
				varSettings.SlotAngle = buShapeSlot2.Angle;
				varSettings.SlotDepth = buShapeSlot2.Depth;
				varSettings.SlotDiameter = buShapeSlot2.Diameter;
				varSettings.SlotLength = buShapeSlot2.Length;
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
			if (Shape.GetType() == typeof(buShapeCut))
			{
				buShapeCut buShapeCut2 = Shape as buShapeCut;
				varSettings.CutType = buShapeCut2.CutType;
				varSettings.CutAngle = buShapeCut2.Angle;
				varSettings.CutDepth = buShapeCut2.Depth;
				varSettings.CutDiameter = buShapeCut2.Diameter;
				varSettings.CutEndDistance = buShapeCut2.EndDistance;
				varSettings.CutLength = buShapeCut2.Length;
				varSettings.CutStartDistance = buShapeCut2.StartDistance;
				varSettings.isMillingCut = buShapeCut2.isMilling;
			}
		}
		if (Shape.ShapeGroup == ShapeGroup.Profiling)
		{
			varSettings.ShapeGroup = Shape.ShapeGroup;
			varSettings.selectedPlane = Shape.planeName;
			varSettings.selectedCorner = Shape.Corner;
			varSettings.objectAlignment = Shape.Alignment;
			varSettings.selectedPlane = Shape.planeName;
			varSettings.isProfilingPocket = Shape.isPocket;
			varSettings.pntBase = buVector5.ToPoint3D(Shape.BasePoint);
			if (Shape.GetType() == typeof(buShapeProfiling))
			{
				buShapeProfiling buShapeProfiling2 = Shape as buShapeProfiling;
				varSettings.ProfilingType = buShapeProfiling2.ProfilingType;
				varSettings.ProfilingDepth = buShapeProfiling2.Depth;
				varSettings.ProfilingHeight = buShapeProfiling2.Height;
				varSettings.ProfilingLength = buShapeProfiling2.Length;
				varSettings.ProfilingRadius = buShapeProfiling2.Radius;
				varSettings.ProfilingWidth = buShapeProfiling2.Width;
			}
		}
	}

	public void GetPickEntity(int index)
	{
		if (clsItem.FrmDrillJob.tree_jobs.Nodes != null && clsItem.FrmDrillJob.tree_jobs.Nodes.Count > 0 && clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData is CustomData)
		{
			CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData;
			if ((customData.RefIndex >= 0) & (customData.RefIndex <= clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes.Count - 1))
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
				clsInit.appCommand.Reset();
				clsItem.FrmDrillJob.tree_jobs.SelectedNode = clsItem.FrmDrillJob.tree_jobs.Nodes[0].Nodes[customData.RefIndex];
			}
		}
	}

	public void GetIndexFromItemID(int ID, List<DrillCalcItem> Items, ref int Index)
	{
		Index = -1;
		int num = 0;
		while (true)
		{
			if (num <= Items.Count - 1)
			{
				if (Items[num].ID == ID)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		Index = num;
	}

	public void SetAsUsedToolByNo(int ToolNo, ref List<ToolBase5> Tools)
	{
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			if (Tools[i].Data.No == ToolNo)
			{
				Tools[i].Data.Used = true;
			}
		}
	}

	public void SetAsCalculatedDrillItemByID(int ID)
	{
		for (int i = 0; i <= SplitedItems.lstTop.Count - 1; i++)
		{
			for (int j = 0; j <= SplitedItems.lstTop[i].Count - 1; j++)
			{
				if (SplitedItems.lstTop[i][j].ID == ID)
				{
					SplitedItems.lstTop[i][j].Calculated = true;
				}
			}
		}
		for (int k = 0; k <= SplitedItems.lstBottom.Count - 1; k++)
		{
			for (int l = 0; l <= SplitedItems.lstBottom[k].Count - 1; l++)
			{
				if (SplitedItems.lstBottom[k][l].ID == ID)
				{
					SplitedItems.lstBottom[k][l].Calculated = true;
				}
			}
		}
		for (int m = 0; m <= SplitedItems.lstLeftRight.Count - 1; m++)
		{
			for (int n = 0; n <= SplitedItems.lstLeftRight[m].Count - 1; n++)
			{
				if (SplitedItems.lstLeftRight[m][n].ID == ID)
				{
					SplitedItems.lstLeftRight[m][n].Calculated = true;
				}
			}
		}
		for (int num = 0; num <= SplitedItems.lstFront.Count - 1; num++)
		{
			for (int num2 = 0; num2 <= SplitedItems.lstFront[num].Count - 1; num2++)
			{
				if (SplitedItems.lstFront[num][num2].ID == ID)
				{
					SplitedItems.lstFront[num][num2].Calculated = true;
				}
			}
		}
		for (int num3 = 0; num3 <= SplitedItems.lstBack.Count - 1; num3++)
		{
			for (int num4 = 0; num4 <= SplitedItems.lstBack[num3].Count - 1; num4++)
			{
				if (SplitedItems.lstBack[num3][num4].ID == ID)
				{
					SplitedItems.lstBack[num3][num4].Calculated = true;
				}
			}
		}
	}

	public void ClearCalculatedThings(bool ToolData = true, bool CalculatedData = true)
	{
		for (int i = 0; i <= SplitedItems.lstTop.Count - 1; i++)
		{
			for (int j = 0; j <= SplitedItems.lstTop[i].Count - 1; j++)
			{
				if (CalculatedData)
				{
					SplitedItems.lstTop[i][j].Calculated = false;
				}
				if (ToolData)
				{
					SplitedItems.lstTop[i][j].Tool = 0;
				}
			}
		}
		for (int k = 0; k <= SplitedItems.lstBottom.Count - 1; k++)
		{
			for (int l = 0; l <= SplitedItems.lstBottom[k].Count - 1; l++)
			{
				if (CalculatedData)
				{
					SplitedItems.lstBottom[k][l].Calculated = false;
				}
				if (ToolData)
				{
					SplitedItems.lstBottom[k][l].Tool = 0;
				}
			}
		}
		for (int m = 0; m <= SplitedItems.lstLeftRight.Count - 1; m++)
		{
			for (int n = 0; n <= SplitedItems.lstLeftRight[m].Count - 1; n++)
			{
				if (CalculatedData)
				{
					SplitedItems.lstLeftRight[m][n].Calculated = false;
				}
				if (ToolData)
				{
					SplitedItems.lstLeftRight[m][n].Tool = 0;
				}
			}
		}
		for (int num = 0; num <= SplitedItems.lstFront.Count - 1; num++)
		{
			for (int num2 = 0; num2 <= SplitedItems.lstFront[num].Count - 1; num2++)
			{
				if (CalculatedData)
				{
					SplitedItems.lstFront[num][num2].Calculated = false;
				}
				if (ToolData)
				{
					SplitedItems.lstFront[num][num2].Tool = 0;
				}
			}
		}
		for (int num3 = 0; num3 <= SplitedItems.lstBack.Count - 1; num3++)
		{
			for (int num4 = 0; num4 <= SplitedItems.lstBack[num3].Count - 1; num4++)
			{
				if (CalculatedData)
				{
					SplitedItems.lstBack[num3][num4].Calculated = false;
				}
				if (ToolData)
				{
					SplitedItems.lstBack[num3][num4].Tool = 0;
				}
			}
		}
	}

	public void SetAsCalculatedDrillItemByID(int ID, ref List<DrillCalcItem> Items)
	{
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			if (Items[i].ID == ID)
			{
				Items[i].Calculated = true;
			}
		}
	}

	public void SplitItemsByDepth(List<DrillCalcItem> Items, ref List<List<DrillCalcItem>> SplitedItems)
	{
		if (Items.Count <= 0)
		{
			return;
		}
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		list.Add(new DrillCalcItem(Items[0]));
		SplitedItems.Add(list);
		for (int i = 1; i <= Items.Count - 1; i++)
		{
			bool flag = false;
			for (int j = 0; j <= SplitedItems.Count - 1; j++)
			{
				for (int k = 0; k <= SplitedItems[j].Count - 1; k++)
				{
					if (buCompare5.EQ(SplitedItems[j][k].Depth, Items[i].Depth, 0.01) && !flag)
					{
						SplitedItems[j].Add(new DrillCalcItem(Items[i]));
						flag = true;
					}
				}
			}
			if (!flag)
			{
				list = new List<DrillCalcItem>();
				list.Add(new DrillCalcItem(Items[i]));
				SplitedItems.Add(list);
			}
		}
	}

	public bool CheckOperations(buShape Shape, ref List<string> Messages)
	{
		if (MachType != DrillMachineType.GoUltra2Top1BottomNoAtc)
		{
			if (MachType != DrillMachineType.GoWithAtc)
			{
				if (MachType != DrillMachineType.Sirius)
				{
					Messages.Add(buDrillCalc.LangDrillMessage[58]);
					return false;
				}
				return cGoSirius.CheckOperationsGoUltra2Top1BottomNoAtc(Shape, ref Messages);
			}
			return cGoAtc.CheckOperationsGoUltra2Top1BottomNoAtc(Shape, ref Messages);
		}
		return cGoUltra2Up1Down.CheckOperationsGoUltra2Top1BottomNoAtc(Shape, ref Messages);
	}

	public void ShapeChanged(object Data1, object Data2)
	{
		new CustomData();
		buShape Shape = Data1 as buShape;
		ShapeUpdateArg shapeUpdateArg = Data2 as ShapeUpdateArg;
		if (Shape.ShapeGroup == ShapeGroup.Profiling)
		{
			Shape.LeadInOut.LeadInLength = varDrillCNCSettings.ProfilingLeadInDistance;
			Shape.LeadInOut.LeadOutLength = varDrillCNCSettings.ProfilingLeadOutDistance;
		}
		if (shapeUpdateArg.Finished)
		{
			clsVar5.shapeCreatePar.Solid = true;
			clsVar5.shapeCreatePar.Size = new SizeObject(activeJob.Material.Size);
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
				for (int i = 0; i <= ccVars.Tools.Count - 1; i++)
				{
					for (int j = 0; j <= ccVars.Tools[i].Tools.Count - 1; j++)
					{
						if (Shape is buShapeHole && buCompare5.EQ(ccVars.Tools[i].Tools[j].Geometry.Diameter, ((buShapeHole)Shape).Diameter))
						{
							Shape.Tool = new ToolBase5(ccVars.Tools[i].Tools[j]);
							toolTop = new ToolBase5(ccVars.Tools[i].Tools[j]);
							ccVars.toolActive = new ToolBase5(ccVars.Tools[i].Tools[j]);
						}
					}
				}
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Cut && clsItem.FrmSlotList != null && clsItem.FrmSlotList.ShowTool && clsItem.FrmSlotList.activeTool != null)
			{
				Shape.Tool = new ToolBase5(clsItem.FrmSlotList.activeTool);
				ccVars.toolActive = new ToolBase5(clsItem.FrmSlotList.activeTool);
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Shape && clsItem.FrmShapeList != null && clsItem.FrmShapeList.ShowTool && clsItem.FrmShapeList.activeTool != null)
			{
				Shape.Tool = new ToolBase5(clsItem.FrmShapeList.activeTool);
				ccVars.toolActive = new ToolBase5(clsItem.FrmShapeList.activeTool);
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Profiling && clsItem.FrmProfilingList != null && clsItem.FrmProfilingList.ShowTool && clsItem.FrmProfilingList.activeTool != null)
			{
				Shape.Tool = new ToolBase5(clsItem.FrmProfilingList.activeTool);
				ccVars.toolActive = new ToolBase5(clsItem.FrmProfilingList.activeTool);
			}
			if (!CheckOperations(Shape, ref operationErrorList) && operationErrorList.Count > 0)
			{
				DialogBoxList dialogBoxList = new DialogBoxList();
				dialogBoxList.lst_items.ScrollAlwaysVisible = true;
				dialogBoxList.lst_items.HorizontalScrollbar = true;
				dialogBoxList.Caption = buLangTranslate.preDef.Error;
				dialogBoxList.Width = 500;
				for (int k = 0; k <= operationErrorList.Count - 1; k++)
				{
					dialogBoxList.Items.Add(operationErrorList[k]);
				}
				dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
				dialogBoxList.Init();
				dialogBoxList.ShowDialog();
				if (dialogBoxList.Result != DialogResult.OK)
				{
					clsInit.appCommand.Reset();
					return;
				}
			}
			Shape.DepthLevel = new List<double>();
			Shape.DepthLevel.AddRange(shapeUpdateArg.Parameters.DepthLevels);
			clsVar5.ShapeDataParameters = new ShapeRuntimeData(shapeUpdateArg.Parameters);
			buShape buShape2 = buShape.Copy(Shape);
			buShape2.InfoMessages = null;
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Drill)
			{
				clsVar5.lastDrill = buShape.Copy(Shape);
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Cut)
			{
				clsVar5.lastCut = buShape.Copy(Shape);
				buShape2.Tool = new ToolBase5(ccVars.toolActive);
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Shape)
			{
				clsVar5.lastShape = buShape.Copy(Shape);
				buShape2.Tool = new ToolBase5(ccVars.toolActive);
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Junction)
			{
				clsVar5.lastJunction = buShape.Copy(Shape);
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Profiling)
			{
				clsVar5.lastProfiling = buShape.Copy(Shape);
				buShape2.Tool = new ToolBase5(ccVars.toolActive);
			}
			if (clsVar5.ShapeDataParameters.ShapeGroup == ShapeGroup.Contour)
			{
				clsVar5.lastProfiling = buShape.Copy(Shape);
				buShape2.Tool = new ToolBase5(ccVars.toolActive);
			}
			if (buShape2.CamPar != null)
			{
				buMWDrillVars.varCamContour.buPar = new camParameters5(buShape2.CamPar);
			}
			buShape2.ID = IDCounter;
			if (EditOperation)
			{
				if ((selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 1))
				{
					activeJob.Items[selectedItemIndex] = buShape2;
				}
				if (clsItem.FrmDrillList != null)
				{
					clsItem.FrmDrillList.Visible = false;
				}
				if (clsItem.FrmShapeList != null)
				{
					clsItem.FrmShapeList.Visible = false;
				}
				if (clsItem.FrmSlotList != null)
				{
					clsItem.FrmSlotList.Visible = false;
				}
				if (clsItem.FrmProfilingList != null)
				{
					clsItem.FrmProfilingList.Visible = false;
				}
			}
			else
			{
				activeJob.Items.Add(buShape2);
			}
			DrawPanelFromJobMainAndPreview(activeJob);
			SaveDrillFile();
			clsInit.appCommand.Reset();
			JobUpdate(FillPages: true, null);
			operationErrorList.Clear();
			calcErrorList.Clear();
			IDCounter++;
			return;
		}
		ccVars.pntDrawDynamicLinesArr.Clear();
		clsVar5.shapeCreatePar.Solid = false;
		clsVar5.shapeCreatePar.Size = new SizeObject(activeJob.Material.Size);
		clsVar5.shapeCreatePar.SingX = -1.0;
		clsVar5.shapeCreatePar.SingY = -1.0;
		clsVar5.ShapeDataParameters.DrillType = drillTypes.SingleHole;
		clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
		if ((Shape.entitiesShape.Count > 0) | (Shape.entitySolid.Count > 0))
		{
			if (Shape.entitySolid != null)
			{
				ViewportDrawOptions viewportDrawOptions = new ViewportDrawOptions();
				viewportDrawOptions.OtherEntities = new List<Entity>();
				for (int l = 0; l <= Shape.entitySolid.Count - 1; l++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(Shape.entitySolid[l], ref copiedEntity);
					if (l == 0)
					{
						copiedEntity.Selected = false;
					}
					copiedEntity.Selectable = false;
					copiedEntity.Regen(0.01);
					viewportDrawOptions.ViewportRef = ViewportRefType.Operation;
					viewportDrawOptions.OtherEntities.Add(copiedEntity);
				}
				viewportDrawOptions.calcPoint = new Point3D(Shape.CalculatedPoint.X, Shape.CalculatedPoint.Y, Shape.CalculatedPoint.Z);
				viewportDrawOptions.refPoint = new Point3D(Shape.BasePoint.X, Shape.BasePoint.Y, Shape.BasePoint.Z);
				double num = Point3D.Distance(Shape.ItemSize.MinBox, Shape.ItemSize.MaxBox) * 0.05;
				if (Shape.ShapeGroup != ShapeGroup.Drill)
				{
					if (Shape.ShapeGroup == ShapeGroup.Cut)
					{
						num = clsVar5.ShapeDataParameters.CutDiameter;
					}
				}
				else
				{
					num = clsVar5.ShapeDataParameters.HoleDiameter * 0.05;
				}
				if (num > 10.0)
				{
					num = 10.0;
				}
				Joint joint = new Joint(buVector5.ToPoint3D(Shape.CalculatedPoint), num * 1.0, 2);
				joint.Color = Color.Red;
				joint.ColorMethod = colorMethodType.byEntity;
				joint.Regen(0.1);
				viewportDrawOptions.OtherEntities.Add(joint);
				viewportDrawOptions.GroupType = Shape.ShapeGroup;
				joint = new Joint(buVector5.ToPoint3D(Shape.CornerPoint), num * 1.0, 2);
				joint.Color = Color.Red;
				joint.ColorMethod = colorMethodType.byEntity;
				joint.Regen(0.1);
				if ((clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.XPosition) | (clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.ZPosition) | (clsVar5.ShapeTempPar.ValueType == ShapeDataValueType.YPosition))
				{
					joint.Selected = true;
				}
				viewportDrawOptions.OtherEntities.Add(joint);
				viewportDrawOptions.GroupType = Shape.ShapeGroup;
				DrawPanelFromJob(activeJob, viewportDrawOptions, Shape);
			}
			if (Shape.ShapeGroup != ShapeGroup.Drill)
			{
				if (Shape.ShapeGroup != ShapeGroup.Cut)
				{
					if (Shape.ShapeGroup != ShapeGroup.Shape)
					{
						if (Shape.ShapeGroup == ShapeGroup.Profiling)
						{
							clsItem.FrmProfilingList.viewportLayout.Entities.ClearSelection();
						}
					}
					else
					{
						clsItem.FrmShapeList.viewportLayout.Entities.ClearSelection();
					}
				}
				else
				{
					clsItem.FrmSlotList.viewportLayout.Entities.ClearSelection();
				}
			}
			else
			{
				clsItem.FrmDrillList.viewportLayout.Entities.ClearSelection();
			}
			for (int m = 0; m <= Shape.entitiesShape.Count - 1; m++)
			{
				List<Point3D> copiedPoint = new List<Point3D>();
				buVector5.Copy(Shape.entitiesShape[m].Vertices, ref copiedPoint);
				ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
			}
			if (Shape.ShapeGroup == ShapeGroup.Engraving)
			{
				List<List<Point3D>> refPoints = new List<List<Point3D>>();
				clsInit.cVector5.CreateBoxOrRectangleFromBoxSize(Shape.ItemSize.MinBox, Shape.ItemSize.MaxBox, ref refPoints);
				for (int n = 0; n <= refPoints.Count - 1; n++)
				{
					ccVars.pntDrawDynamicLinesArr.Add(refPoints[n]);
				}
			}
		}
		if (clsItem.FrmDrillList != null && clsItem.FrmDrillList.Visible)
		{
			clsItem.FrmDrillList.lst_info.Visible = false;
			clsItem.FrmDrillList.lst_info.Items.Clear();
		}
		if (clsItem.FrmShapeList != null && clsItem.FrmShapeList.Visible)
		{
			clsItem.FrmShapeList.lst_info.Visible = false;
			clsItem.FrmShapeList.lst_info.Items.Clear();
		}
		if (Shape.InfoMessages != null && Shape.InfoMessages.Count > 0)
		{
			if (Shape.ShapeGroup == ShapeGroup.Drill)
			{
				clsItem.FrmDrillList.lst_info.Visible = true;
				for (int num2 = 0; num2 <= Shape.InfoMessages.Count - 1; num2++)
				{
					clsItem.FrmDrillList.lst_info.Items.Add(Shape.InfoMessages[num2]);
				}
			}
			if (Shape.ShapeGroup == ShapeGroup.Shape)
			{
				clsItem.FrmShapeList.lst_info.Visible = true;
				for (int num3 = 0; num3 <= Shape.InfoMessages.Count - 1; num3++)
				{
					clsItem.FrmShapeList.lst_info.Items.Add(Shape.InfoMessages[num3]);
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void ShapeCancel()
	{
		clsInit.appCommand.Reset();
		EditOperation = false;
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buDrill.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buDrill.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Drill Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Drill Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buDrillCalc.LangDrillCommands);
				StringList.Clear();
			}
			if (list.Count <= 0)
			{
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[16];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void SaveDrillFile()
	{
		try
		{
			ArrayList ALSettings = new ArrayList();
			ArrayList ALCam = new ArrayList();
			SaveDrillFile(ref ALSettings, ref ALCam);
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[17];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void SaveDrillFile(ref ArrayList ALSettings, ref ArrayList ALCam)
	{
		try
		{
			string text = AppPath.Settings + "\\Drill\\";
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				text += "\\GoUltra2Up1Down\\";
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				text += "\\GoAtc\\";
			}
			if (MachType == DrillMachineType.Sirius)
			{
				text += "\\Sirius\\";
			}
			string fileName = text + "Drill.prm";
			ALSettings = new ArrayList();
			ALSettings.Add("------------------------------------------------------------------------");
			ALSettings.Add("   Drill Settings");
			ALSettings.Add("------------------------------------------------------------------------");
			ALSettings.Add("<DrillSettings>");
			ALSettings.AddRange(varDrillSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			ALSettings.Add("</DrillSettings>");
			ALSettings.Add("<varDrillCNCSettings>");
			ALSettings.AddRange(varDrillCNCSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			ALSettings.Add("</varDrillCNCSettings>");
			ALSettings.Add("<varDrillMachineSettings>");
			ALSettings.AddRange(varDrillMachineSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			ALSettings.Add("</varDrillMachineSettings>");
			ALSettings.Add("<DrillRuntimeSettings>");
			ALSettings.AddRange(varDrillRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			ALSettings.Add("</DrillRuntimeSettings>");
			ALSettings.Add("<ShapeDataParameters>");
			ALSettings.AddRange(clsVar5.ShapeDataParameters.ToDefAll("", 2, SerilizationMode5.MultiLine));
			ALSettings.Add("</ShapeDataParameters>");
			buFile.SaveToFile(ALSettings, fileName);
			buLog.addLog("Drill Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			buMWDrillVars.varCamContour.mwPar.Serialize(text + "mwDrillContour.bin");
			buMWDrillVars.varCamRough.mwPar.Serialize(text + "mwDrillRough.bin");
			buMWDrillVars.varCamMeshRough.mwPar.Serialize(text + "mwDrillMeshRough.bin");
			buMWDrillVars.varCamMeshParalelCut.mwPar.Serialize(text + "mwDrillMeshParalelCut.bin");
			string fileName2 = text + "DrillCam.bucamset";
			ALCam = new ArrayList();
			ALCam.Add("------------------------------------------------------------------------");
			ALCam.Add("   MW Cam Settings");
			ALCam.Add("------------------------------------------------------------------------");
			ALCam.Add("<MwCamSettings>");
			ALCam.AddRange(buMWDrillVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
			ALCam.AddRange(buMWDrillVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
			ALCam.AddRange(buMWDrillVars.varCamMeshParalelCut.buPar.ToDefAll("_varCamMeshParalelCut", 2, SerilizationMode5.MultiLine));
			ALCam.AddRange(buMWDrillVars.varCamMeshRough.buPar.ToDefAll("_varCamMeshRough", 2, SerilizationMode5.MultiLine));
			ALCam.Add("</MwCamSettings>");
			buFile.SaveToFile(ALCam, fileName2);
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[17];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenDrillFile()
	{
		try
		{
			ArrayList StringList = new ArrayList();
			ArrayList StringList2 = new ArrayList();
			string text = AppPath.Settings + "\\Drill\\";
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				text += "\\GoUltra2Up1Down\\";
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				text += "\\GoAtc\\";
			}
			if (MachType == DrillMachineType.Sirius)
			{
				text += "\\Sirius\\";
			}
			string fileName = text + "Drill.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (fileInfo.Exists)
			{
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
			}
			string fileName2 = text + "DrillCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (fileInfo.Exists)
			{
				buFile.OpenFromFile(fileInfo.FullName, ref StringList2);
			}
			OpenDrillFile(StringList, StringList2);
			fileInfo = new FileInfo(text + "mwDrillContour.bin");
			if (fileInfo.Exists)
			{
				buMWDrillVars.varCamContour.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(text + "mwDrillRough.bin");
			if (fileInfo.Exists)
			{
				buMWDrillVars.varCamRough.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(text + "mwDrillMeshRough.bin");
			if (fileInfo.Exists)
			{
				buMWDrillVars.varCamMeshRough.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(text + "mwDrillMeshParalelCut.bin");
			if (fileInfo.Exists)
			{
				buMWDrillVars.varCamMeshParalelCut.mwPar.Deserialize(fileInfo.FullName);
			}
			if (clsInit.appEditor != null)
			{
				clsInit.appEditor.OpenEditorFile();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenDrillFile(ArrayList ALSettings, ArrayList ALCam)
	{
		try
		{
			if (ALSettings.Count <= 0)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Drill Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Drill Settings File Missing");
				}
			}
			else
			{
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<DrillSettings>", "</DrillSettings>", AddStartEndKey: true, ALSettings, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, varDrillSettings);
						buLog.addLog("Drill Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varDrillCNCSettings>", "</varDrillCNCSettings>", AddStartEndKey: true, ALSettings, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, varDrillCNCSettings);
						buLog.addLog("Drill varDrillCNCSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varDrillMachineSettings>", "</varDrillMachineSettings>", AddStartEndKey: true, ALSettings, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, varDrillMachineSettings);
						buLog.addLog("Drill varDrillMachineSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<DrillRuntimeSettings>", "</DrillRuntimeSettings>", AddStartEndKey: true, ALSettings, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, varDrillRunSettings);
						buLog.addLog("Drill RuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<ShapeDataParameters>", "</DrillRuntShapeDataParametersimeSettings>", AddStartEndKey: true, ALSettings, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(ALSettings, "", SerilizationMode5.MultiLine, clsVar5.ShapeDataParameters);
						buLog.addLog(" ShapeDataParameters Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Drill Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Drill Settings Decoder Error");
				}
			}
			buLog.addLog("Drill Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			if (ALCam.Count <= 0)
			{
				buLog.addLog("Drill Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Drill Cam Settings File Missing");
				return;
			}
			try
			{
				ArrayList CalcList2 = new ArrayList();
				buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, ALCam, ref CalcList2);
				if (CalcList2.Count > 0)
				{
					buSerilization.Decode(ALCam, "_varCamContour", SerilizationMode.MultiLine, buMWDrillVars.varCamContour.buPar);
					buSerilization.Decode(ALCam, "_varCamRough", SerilizationMode.MultiLine, buMWDrillVars.varCamRough.buPar);
					buSerilization.Decode(ALCam, "_varCamMeshRough", SerilizationMode.MultiLine, buMWDrillVars.varCamMeshRough.buPar);
					buSerilization.Decode(ALCam, "_varCamMeshParalelCut", SerilizationMode.MultiLine, buMWDrillVars.varCamMeshParalelCut.buPar);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Drill Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Drill Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void AddRecentOpenFile(string FileName)
	{
		if (FileName != varDrillRunSettings.RecentOpenFile1)
		{
			if (varDrillRunSettings.RecentOpenFile6 != varDrillRunSettings.RecentOpenFile5)
			{
				varDrillRunSettings.RecentOpenFile6 = varDrillRunSettings.RecentOpenFile5;
			}
			if (varDrillRunSettings.RecentOpenFile5 != varDrillRunSettings.RecentOpenFile4)
			{
				varDrillRunSettings.RecentOpenFile5 = varDrillRunSettings.RecentOpenFile4;
			}
			if (varDrillRunSettings.RecentOpenFile4 != varDrillRunSettings.RecentOpenFile3)
			{
				varDrillRunSettings.RecentOpenFile4 = varDrillRunSettings.RecentOpenFile3;
			}
			if (varDrillRunSettings.RecentOpenFile3 != varDrillRunSettings.RecentOpenFile2)
			{
				varDrillRunSettings.RecentOpenFile3 = varDrillRunSettings.RecentOpenFile2;
			}
			if (varDrillRunSettings.RecentOpenFile2 != varDrillRunSettings.RecentOpenFile1)
			{
				varDrillRunSettings.RecentOpenFile2 = varDrillRunSettings.RecentOpenFile1;
			}
			if (FileName != varDrillRunSettings.RecentOpenFile1)
			{
				varDrillRunSettings.RecentOpenFile1 = FileName;
			}
		}
	}

	public void AddRecentSaveFile(string FileName)
	{
		if (FileName != varDrillRunSettings.RecentSaveFile1)
		{
			if (varDrillRunSettings.RecentSaveFile6 != varDrillRunSettings.RecentSaveFile5)
			{
				varDrillRunSettings.RecentSaveFile6 = varDrillRunSettings.RecentSaveFile5;
			}
			if (varDrillRunSettings.RecentSaveFile5 != varDrillRunSettings.RecentSaveFile4)
			{
				varDrillRunSettings.RecentSaveFile5 = varDrillRunSettings.RecentSaveFile4;
			}
			if (varDrillRunSettings.RecentSaveFile4 != varDrillRunSettings.RecentSaveFile3)
			{
				varDrillRunSettings.RecentSaveFile4 = varDrillRunSettings.RecentSaveFile3;
			}
			if (varDrillRunSettings.RecentSaveFile3 != varDrillRunSettings.RecentSaveFile2)
			{
				varDrillRunSettings.RecentSaveFile3 = varDrillRunSettings.RecentSaveFile2;
			}
			if (varDrillRunSettings.RecentSaveFile2 != varDrillRunSettings.RecentSaveFile1)
			{
				varDrillRunSettings.RecentSaveFile2 = varDrillRunSettings.RecentSaveFile1;
			}
			if (varDrillRunSettings.RecentSaveFile1 != FileName)
			{
				varDrillRunSettings.RecentSaveFile1 = FileName;
			}
		}
	}

	public void SaveDrillJobFile(string FileName, DrillJob Job, bool SaveAll = false)
	{
		List<string> stringList = new List<string>();
		SaveDrillJobFile(ref stringList, Job, SaveAll);
		buFile5.SaveToFile(stringList, FileName);
		fileNameActual = FileName;
		AddRecentSaveFile(FileName);
		ccVars.Pages[ccVars.PageIndex].Form.Text = buFile5.getFileName(FileName);
	}

	public void SaveDrillJobFile(ref List<string> stringList, DrillJob Job, bool SaveAll = false)
	{
		try
		{
			stringList = new List<string>();
			List<string> list = new List<string>();
			stringList.Add("<JobCsv>");
			stringList.Add("  <Material>");
			stringList.Add("    Name;" + Job.Name);
			stringList.Add("    Width;" + Job.Material.Size.Height);
			stringList.Add("    Length;" + Job.Material.Size.Width);
			stringList.Add("    Height;" + Job.Material.Size.Depth);
			stringList.Add("  </Material>");
			for (int i = 0; i <= Job.Items.Count - 1; i++)
			{
				if (Job.Items[i].Tool == null)
				{
					Job.Items[i].Tool = new ToolBase5(ccVars.toolActive);
				}
				stringList.Add("  <DrillGroup>");
				if (Job.Items[i].ShapeGroup == ShapeGroup.Drill)
				{
					if (Job.Items[i].GetType() == typeof(buShapeHole))
					{
						buShapeHole buShapeHole4 = Job.Items[i] as buShapeHole;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeHole4.DrillType);
						string text = "    " + buShapeHole4.BasePoint.X.ToString("f3") + ";" + buShapeHole4.BasePoint.Y.ToString("f3") + ";" + buShapeHole4.BasePoint.Z.ToString("f3") + ";";
						text = text + buShapeHole4.Depth.ToString("f3") + ";" + buShapeHole4.Diameter.ToString("f3") + ";" + buShapeHole4.planeName.ToString() + ";" + Convert.ToInt32(buShapeHole4.Enable) + ";" + Convert.ToInt32(buShapeHole4.isMilling) + ";";
						text = text + buShapeHole4.Corner.ToString() + ";" + buShapeHole4.Alignment.ToString() + ";" + buShapeHole4.Tool.Data.Name.ToString() + ";";
						stringList.Add(text);
						list.Add("  <DrillGroup>");
						string text2 = "    " + (buShapeHole4.CalculatedPoint.X * -1.0).ToString("f3") + ";" + (buShapeHole4.CalculatedPoint.Y * -1.0).ToString("f3") + ";" + buShapeHole4.CalculatedPoint.Z.ToString("f3") + ";";
						text2 = text2 + buShapeHole4.Depth.ToString("f3") + ";" + buShapeHole4.Diameter.ToString("f3") + ";" + buShapeHole4.planeName.ToString() + ";" + Convert.ToInt32(buShapeHole4.Enable) + ";" + Convert.ToInt32(buShapeHole4.isMilling) + ";";
						text2 = text2 + buShapeHole4.Corner.ToString() + ";" + buShapeHole4.Alignment.ToString() + ";" + buShapeHole4.Tool.Data.Name.ToString() + ";";
						list.Add(text2);
						list.Add("  </DrillGroup>");
					}
					if (Job.Items[i].GetType() == typeof(buShapeHoleMulti))
					{
						buShapeHoleMulti buShapeHoleMulti2 = Job.Items[i] as buShapeHoleMulti;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeHoleMulti2.DrillType);
						string text3 = "    " + buShapeHoleMulti2.BasePoint.X.ToString("f3") + ";" + buShapeHoleMulti2.BasePoint.Y.ToString("f3") + ";" + buShapeHoleMulti2.BasePoint.Z.ToString("f3") + ";";
						text3 = text3 + buShapeHoleMulti2.Depth.ToString("f3") + ";" + buShapeHoleMulti2.Diameter.ToString("f3") + ";" + buShapeHoleMulti2.planeName.ToString() + ";" + Convert.ToInt32(buShapeHoleMulti2.Enable) + ";" + Convert.ToInt32(buShapeHoleMulti2.isMilling) + ";";
						text3 = text3 + buShapeHoleMulti2.Count + ";" + buShapeHoleMulti2.Distance.ToString("f3") + ";" + buShapeHoleMulti2.StartDistance + ";" + buShapeHoleMulti2.EndDistance + ";" + buShapeHoleMulti2.Angle + ";";
						text3 = text3 + buShapeHoleMulti2.Corner.ToString() + ";" + buShapeHoleMulti2.Alignment.ToString() + ";" + buShapeHoleMulti2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text3);
						for (int j = 0; j <= buShapeHoleMulti2.multiCenter.Count - 1; j++)
						{
							string text4 = "    " + (buShapeHoleMulti2.multiCenter[j].Center.X * -1.0).ToString("f3") + ";" + (buShapeHoleMulti2.multiCenter[j].Center.Y * -1.0).ToString("f3") + ";" + buShapeHoleMulti2.multiCenter[j].Center.Z.ToString("f3") + ";";
							text4 = text4 + buShapeHoleMulti2.Depth.ToString("f3") + ";" + buShapeHoleMulti2.Diameter.ToString("f3") + ";" + buShapeHoleMulti2.planeName.ToString() + ";" + Convert.ToInt32(buShapeHoleMulti2.Enable) + ";" + Convert.ToInt32(buShapeHoleMulti2.isMilling) + ";";
							text4 = text4 + buShapeHoleMulti2.Count + ";" + buShapeHoleMulti2.Distance.ToString("f3") + ";" + buShapeHoleMulti2.StartDistance + ";" + buShapeHoleMulti2.EndDistance + ";" + buShapeHoleMulti2.Angle + ";";
							text4 = text4 + buShapeHoleMulti2.Corner.ToString() + ";" + buShapeHoleMulti2.Alignment.ToString() + ";" + buShapeHoleMulti2.Tool.Data.Name.ToString() + ";";
							list.Add("  <DrillGroup>");
							list.Add("  " + text4);
							list.Add("  </DrillGroup>");
						}
					}
					if (Job.Items[i].GetType() == typeof(buShapeHole3))
					{
						buShapeHole3 buShapeHole5 = Job.Items[i] as buShapeHole3;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeHole5.DrillType);
						string text5 = "    " + buShapeHole5.BasePoint.X.ToString("f3") + ";" + buShapeHole5.BasePoint.Y.ToString("f3") + ";" + buShapeHole5.BasePoint.Z.ToString("f3") + ";";
						text5 = text5 + buShapeHole5.Depth.ToString("f3") + ";" + buShapeHole5.Diameter.ToString("f3") + ";" + buShapeHole5.planeName.ToString() + ";" + Convert.ToInt32(buShapeHole5.Enable) + ";" + Convert.ToInt32(buShapeHole5.isMilling) + ";";
						text5 = text5 + buShapeHole5.DiameterOutside.ToString("f3") + ";" + buShapeHole5.Hole3Angle.ToString("f3") + ";" + buShapeHole5.DistanceX + ";" + buShapeHole5.DistanceY + ";";
						text5 = text5 + buShapeHole5.Corner.ToString() + ";" + buShapeHole5.Alignment.ToString() + ";" + buShapeHole5.Tool.Data.Name.ToString() + ";";
						stringList.Add(text5);
					}
				}
				if (Job.Items[i].ShapeGroup == ShapeGroup.Cut && Job.Items[i].GetType() == typeof(buShapeCut))
				{
					buShapeCut buShapeCut2 = Job.Items[i] as buShapeCut;
					stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeCut2.CutType);
					string text6 = "    " + buShapeCut2.BasePoint.X.ToString("f3") + ";" + buShapeCut2.BasePoint.Y.ToString("f3") + ";" + buShapeCut2.BasePoint.Z.ToString("f3") + ";";
					text6 = text6 + buShapeCut2.Depth.ToString("f3") + ";" + buShapeCut2.Diameter.ToString("f3") + ";" + buShapeCut2.planeName.ToString() + ";" + Convert.ToInt32(buShapeCut2.Enable) + ";" + Convert.ToInt32(buShapeCut2.isMilling) + ";";
					text6 = text6 + buShapeCut2.Length.ToString("f3") + ";" + buShapeCut2.Angle.ToString("f3") + ";" + buShapeCut2.StartDistance + ";" + buShapeCut2.EndDistance + ";";
					text6 = text6 + buShapeCut2.Corner.ToString() + ";" + buShapeCut2.Alignment.ToString() + ";" + buShapeCut2.Tool.Data.Name.ToString() + ";";
					stringList.Add(text6);
					list.Add("  <SlotGroup>");
					string text7 = "    " + (buShapeCut2.CalculatedPoint.X * -1.0).ToString("f3") + ";" + (buShapeCut2.CalculatedPoint.Y * -1.0).ToString("f3") + ";" + buShapeCut2.CalculatedPoint.Z.ToString("f3") + ";";
					text7 = text7 + buShapeCut2.Depth.ToString("f3") + ";" + buShapeCut2.Diameter.ToString("f3") + ";" + buShapeCut2.planeName.ToString() + ";" + Convert.ToInt32(buShapeCut2.Enable) + ";" + Convert.ToInt32(buShapeCut2.isMilling) + ";";
					text7 = text7 + buShapeCut2.Length.ToString("f3") + ";" + buShapeCut2.Angle.ToString("f3") + ";" + buShapeCut2.StartDistance + ";" + buShapeCut2.EndDistance + ";";
					text7 = text7 + buShapeCut2.Corner.ToString() + ";" + buShapeCut2.Alignment.ToString() + ";" + buShapeCut2.Tool.Data.Name.ToString() + ";";
					list.Add(text7);
					list.Add("  </SlotGroup>");
				}
				if (Job.Items[i].ShapeGroup == ShapeGroup.Profiling && Job.Items[i].GetType() == typeof(buShapeProfiling))
				{
					buShapeProfiling buShapeProfiling2 = Job.Items[i] as buShapeProfiling;
					stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeProfiling2.ProfilingType);
					string text8 = "    " + buShapeProfiling2.BasePoint.X.ToString("f3") + ";" + buShapeProfiling2.BasePoint.Y.ToString("f3") + ";" + buShapeProfiling2.BasePoint.Z.ToString("f3") + ";";
					text8 = text8 + buShapeProfiling2.Depth.ToString("f3") + ";" + buShapeProfiling2.Radius.ToString("f3") + ";" + buShapeProfiling2.planeName.ToString() + ";" + Convert.ToInt32(buShapeProfiling2.Enable) + ";" + Convert.ToInt32(buShapeProfiling2.isPocket) + ";";
					text8 = text8 + buShapeProfiling2.Length.ToString("f3") + ";" + buShapeProfiling2.Width.ToString("f3") + ";" + buShapeProfiling2.Height + ";";
					text8 = text8 + buShapeProfiling2.Corner.ToString() + ";" + buShapeProfiling2.Alignment.ToString() + ";" + buShapeProfiling2.Tool.Data.Name.ToString() + ";";
					stringList.Add(text8);
				}
				if (Job.Items[i].ShapeGroup == ShapeGroup.Shape && Job.Items[i].ShapeGroup == ShapeGroup.Shape)
				{
					if (Job.Items[i].GetType() == typeof(buShapeRectangle))
					{
						buShapeRectangle buShapeRectangle2 = Job.Items[i] as buShapeRectangle;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeRectangle2.ShapeType);
						string text9 = "    " + buShapeRectangle2.BasePoint.X.ToString("f3") + ";" + buShapeRectangle2.BasePoint.Y.ToString("f3") + ";" + buShapeRectangle2.BasePoint.Z.ToString("f3") + ";";
						text9 = text9 + buShapeRectangle2.Depth.ToString("f3") + ";" + buShapeRectangle2.Radius.ToString("f3") + ";" + buShapeRectangle2.planeName.ToString() + ";" + Convert.ToInt32(buShapeRectangle2.Enable) + ";" + Convert.ToInt32(buShapeRectangle2.isPocket) + ";";
						text9 = text9 + buShapeRectangle2.Angle.ToString("f3") + ";" + buShapeRectangle2.Width.ToString("f3") + ";" + buShapeRectangle2.Height + ";" + buShapeRectangle2.Chamfer.ToString("f3") + ";";
						text9 = text9 + buShapeRectangle2.Corner.ToString() + ";" + buShapeRectangle2.Alignment.ToString() + ";" + buShapeRectangle2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text9);
					}
					if (Job.Items[i].GetType() == typeof(buShapeCircle))
					{
						buShapeCircle buShapeCircle2 = Job.Items[i] as buShapeCircle;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeCircle2.ShapeType);
						string text10 = "    " + buShapeCircle2.BasePoint.X.ToString("f3") + ";" + buShapeCircle2.BasePoint.Y.ToString("f3") + ";" + buShapeCircle2.BasePoint.Z.ToString("f3") + ";";
						text10 = text10 + buShapeCircle2.Depth.ToString("f3") + ";" + buShapeCircle2.Radius.ToString("f3") + ";" + buShapeCircle2.planeName.ToString() + ";" + Convert.ToInt32(buShapeCircle2.Enable) + ";" + Convert.ToInt32(buShapeCircle2.isPocket) + ";";
						text10 = text10 + buShapeCircle2.Corner.ToString() + ";" + buShapeCircle2.Alignment.ToString() + ";" + buShapeCircle2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text10);
					}
					if (Job.Items[i].GetType() == typeof(buShapeEllipse))
					{
						buShapeEllipse buShapeEllipse2 = Job.Items[i] as buShapeEllipse;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeEllipse2.ShapeType);
						string text11 = "    " + buShapeEllipse2.BasePoint.X.ToString("f3") + ";" + buShapeEllipse2.BasePoint.Y.ToString("f3") + ";" + buShapeEllipse2.BasePoint.Z.ToString("f3") + ";";
						text11 = text11 + buShapeEllipse2.Depth.ToString("f3") + ";" + buShapeEllipse2.RadiusX.ToString("f3") + ";" + buShapeEllipse2.planeName.ToString() + ";" + Convert.ToInt32(buShapeEllipse2.Enable) + ";" + Convert.ToInt32(buShapeEllipse2.isPocket) + ";";
						text11 = text11 + buShapeEllipse2.Angle.ToString("f3") + ";" + buShapeEllipse2.RadiusY.ToString("f3") + ";";
						text11 = text11 + buShapeEllipse2.Corner.ToString() + ";" + buShapeEllipse2.Alignment.ToString() + ";" + buShapeEllipse2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text11);
					}
					if (Job.Items[i].GetType() == typeof(buShapeSlot))
					{
						buShapeSlot buShapeSlot2 = Job.Items[i] as buShapeSlot;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeSlot2.ShapeType);
						string text12 = "    " + buShapeSlot2.BasePoint.X.ToString("f3") + ";" + buShapeSlot2.BasePoint.Y.ToString("f3") + ";" + buShapeSlot2.BasePoint.Z.ToString("f3") + ";";
						text12 = text12 + buShapeSlot2.Depth.ToString("f3") + ";" + buShapeSlot2.Diameter.ToString("f3") + ";" + buShapeSlot2.planeName.ToString() + ";" + Convert.ToInt32(buShapeSlot2.Enable) + ";" + Convert.ToInt32(buShapeSlot2.isPocket) + ";";
						text12 = text12 + buShapeSlot2.Angle.ToString("f3") + ";" + buShapeSlot2.Length.ToString("f3") + ";";
						text12 = text12 + buShapeSlot2.Corner.ToString() + ";" + buShapeSlot2.Alignment.ToString() + ";" + buShapeSlot2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text12);
					}
					if (Job.Items[i].GetType() == typeof(buShapeKeyHole))
					{
						buShapeKeyHole buShapeKeyHole2 = Job.Items[i] as buShapeKeyHole;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeKeyHole2.ShapeType);
						string text13 = "    " + buShapeKeyHole2.BasePoint.X.ToString("f3") + ";" + buShapeKeyHole2.BasePoint.Y.ToString("f3") + ";" + buShapeKeyHole2.BasePoint.Z.ToString("f3") + ";";
						text13 = text13 + buShapeKeyHole2.Depth.ToString("f3") + ";" + buShapeKeyHole2.Diameter.ToString("f3") + ";" + buShapeKeyHole2.planeName.ToString() + ";" + Convert.ToInt32(buShapeKeyHole2.Enable) + ";" + Convert.ToInt32(buShapeKeyHole2.isPocket) + ";";
						text13 = text13 + buShapeKeyHole2.Angle.ToString("f3") + ";" + buShapeKeyHole2.HeadDiameter.ToString("f3") + ";" + buShapeKeyHole2.Length.ToString("f3") + ";";
						text13 = text13 + buShapeKeyHole2.Corner.ToString() + ";" + buShapeKeyHole2.Alignment.ToString() + ";" + buShapeKeyHole2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text13);
					}
					if (Job.Items[i].GetType() == typeof(buShapePolygon))
					{
						buShapePolygon buShapePolygon2 = Job.Items[i] as buShapePolygon;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapePolygon2.ShapeType);
						string text14 = "    " + buShapePolygon2.BasePoint.X.ToString("f3") + ";" + buShapePolygon2.BasePoint.Y.ToString("f3") + ";" + buShapePolygon2.BasePoint.Z.ToString("f3") + ";";
						text14 = text14 + buShapePolygon2.Depth.ToString("f3") + ";" + buShapePolygon2.Radius.ToString("f3") + ";" + buShapePolygon2.planeName.ToString() + ";" + Convert.ToInt32(buShapePolygon2.Enable) + ";" + Convert.ToInt32(buShapePolygon2.isPocket) + ";";
						text14 = text14 + buShapePolygon2.Angle.ToString("f3") + ";" + buShapePolygon2.Side + ";";
						text14 = text14 + buShapePolygon2.Corner.ToString() + ";" + buShapePolygon2.Alignment.ToString() + ";" + buShapePolygon2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text14);
					}
					if (Job.Items[i].GetType() == typeof(buShapeFreeDraw))
					{
						buShapeFreeDraw buShapeFreeDraw2 = Job.Items[i] as buShapeFreeDraw;
						stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeFreeDraw2.ShapeType);
						string text15 = "    " + buShapeFreeDraw2.BasePoint.X.ToString("f3") + ";" + buShapeFreeDraw2.BasePoint.Y.ToString("f3") + ";" + buShapeFreeDraw2.BasePoint.Z.ToString("f3") + ";";
						text15 = text15 + buShapeFreeDraw2.Depth.ToString("f3") + ";" + buShapeFreeDraw2.Width.ToString("f3") + ";" + buShapeFreeDraw2.planeName.ToString() + ";" + Convert.ToInt32(buShapeFreeDraw2.Enable) + ";" + Convert.ToInt32(buShapeFreeDraw2.isPocket) + ";";
						text15 = text15 + buShapeFreeDraw2.Angle.ToString("f3") + ";" + buShapeFreeDraw2.Height.ToString("f3") + ";";
						text15 = text15 + buShapeFreeDraw2.Corner.ToString() + ";" + buShapeFreeDraw2.Alignment.ToString() + ";" + buShapeFreeDraw2.Tool.Data.Name.ToString() + ";";
						stringList.Add(text15);
					}
				}
				if (Job.Items[i].ShapeGroup == ShapeGroup.Junction && Job.Items[i].GetType() == typeof(buShapeJunction))
				{
					buShapeJunction buShapeJunction2 = Job.Items[i] as buShapeJunction;
					stringList.Add("    " + Job.Items[i].ShapeGroup.ToString() + " ; " + buShapeJunction2.JunctionType);
					string text16 = "    " + buShapeJunction2.BasePoint.X.ToString("f3") + ";" + buShapeJunction2.BasePoint.Y.ToString("f3") + ";" + buShapeJunction2.BasePoint.Z.ToString("f3") + ";";
					text16 = text16 + buShapeJunction2.Depth.ToString("f3") + ";" + buShapeJunction2.Diameter.ToString("f3") + ";" + buShapeJunction2.planeName.ToString() + ";" + Convert.ToInt32(buShapeJunction2.Enable) + ";" + Convert.ToInt32(buShapeJunction2.isMilling) + ";";
					text16 = text16 + buShapeJunction2.DiameterOutside.ToString("f3") + ";" + buShapeJunction2.Distance.ToString("f3") + ";";
					text16 = text16 + buShapeJunction2.Corner.ToString() + ";" + buShapeJunction2.Alignment.ToString() + ";" + buShapeJunction2.Tool.Data.Name.ToString() + ";";
					stringList.Add(text16);
				}
				stringList.Add("  </DrillGroup>");
			}
			stringList.Add("</JobCsv>");
			stringList.Add(" ");
			stringList.Add("<ItemCode>");
			stringList.AddRange(list);
			stringList.Add("</ItemCode>");
			stringList.Add(" ");
			activeJob.Cams.Clear();
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				cGoUltra2Up1Down.CreatCodeFromJobItem(ref activeJob);
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				cGoAtc.CreatCodeFromJobItem(ref activeJob);
			}
			if (MachType == DrillMachineType.Sirius)
			{
				cGoSirius.CreatCodeFromJobItem(ref activeJob);
			}
			stringList.Add("<MachineCode>");
			stringList.Add("  <Props>");
			stringList.Add("    Width = " + activeJob.Material.Size.Width.ToString("f3"));
			stringList.Add("    Height = " + activeJob.Material.Size.Height.ToString("f3"));
			stringList.Add("    Depth = " + activeJob.Material.Size.Depth.ToString("f3"));
			stringList.Add("  </Props>");
			stringList.Add("  <AutoCode>");
			for (int k = 0; k <= activeJob.Codes.Count - 1; k++)
			{
				stringList.Add("    " + activeJob.Codes[k]);
			}
			stringList.Add("  </AutoCode>");
			if (activeJob.Cams.Count > 0)
			{
				for (int l = 0; l <= activeJob.Cams.Count - 1; l++)
				{
					string Lines = "";
					List<camTp> list2 = new List<camTp>();
					camTp copiedCam = new camTp();
					camTp.CopyCam(activeJob.Cams[l], ref copiedCam);
					list2.Add(copiedCam);
					clsInit.cGcodeCreate.CreatGCode(list2, ccVars.PostActive, ref Lines);
					ArrayList Lines2 = new ArrayList();
					buString5.StringToArrayListByNewLine(Lines, ref Lines2);
					if (clsItem.FrmProgress != null)
					{
						clsItem.FrmProgress.Visible = false;
					}
					stringList.Add("  <GCodes>");
					for (int m = 0; m <= Lines2.Count - 1; m++)
					{
						if (Lines2[m].ToString().Trim().Length > 0)
						{
							stringList.Add("    " + Lines2[m].ToString());
						}
					}
					stringList.Add("  </GCodes>");
				}
			}
			if (activeJob.Moves.Count > 0)
			{
				stringList.Add("  <Moves>");
				for (int n = 0; n <= activeJob.Moves.Count - 1; n++)
				{
					string item = "    " + activeJob.Moves[n].XPosition + ";" + activeJob.Moves[n].X1Clamper + ";" + activeJob.Moves[n].X2Clamper + ";" + activeJob.Moves[n].Y1Position + ";" + activeJob.Moves[n].Y2Position + ";" + activeJob.Moves[n].Y3Position + ";" + activeJob.Moves[n].Z1Position + ";" + activeJob.Moves[n].Z2Position + ";" + activeJob.Moves[n].Z3Position + ";" + Convert.ToInt32(activeJob.Moves[n].Command) + ";" + activeJob.Moves[n].Tool1 + ";" + activeJob.Moves[n].Tool2 + ";" + activeJob.Moves[n].Tool3 + ";" + activeJob.Moves[n].Tool4 + ";" + activeJob.Moves[n].Tool5 + ";" + activeJob.Moves[n].Tool6 + ";" + activeJob.Moves[n].Tool7 + ";" + activeJob.Moves[n].Tool8 + ";" + activeJob.Moves[n].Tool9 + ";" + activeJob.Moves[n].Tool10 + ";" + activeJob.Moves[n].Tool11 + ";" + activeJob.Moves[n].Tool12 + ";" + Convert.ToInt32(activeJob.Moves[n].Mode) + ";" + Convert.ToInt32(activeJob.Moves[n].Plane) + ";" + Convert.ToInt32(activeJob.Moves[n].Command2) + ";" + Convert.ToInt32(activeJob.Moves[n].Command3);
					stringList.Add(item);
				}
				stringList.Add("  </Moves>");
				stringList.Add("  <MovesDetailed>");
				for (int num = 0; num <= activeJob.Moves.Count - 1; num++)
				{
					string item2 = "    X: " + activeJob.Moves[num].XPosition + " ; X1: " + activeJob.Moves[num].X1Clamper + " ; X2: " + activeJob.Moves[num].X2Clamper + " ; Y1: " + activeJob.Moves[num].Y1Position + " ; Y2: " + activeJob.Moves[num].Y2Position + " ; Y2: " + activeJob.Moves[num].Y3Position + " ; Z1: " + activeJob.Moves[num].Z1Position + " ; Z2: " + activeJob.Moves[num].Z2Position + " ; Z3: " + activeJob.Moves[num].Z3Position + " ; " + activeJob.Moves[num].Command.ToString() + " ; T1: " + activeJob.Moves[num].Tool1 + " ; T2: " + activeJob.Moves[num].Tool2 + " ; T3: " + activeJob.Moves[num].Tool3 + " ; T4: " + activeJob.Moves[num].Tool4 + " ; T5: " + activeJob.Moves[num].Tool5 + " ; T6: " + activeJob.Moves[num].Tool6 + " ; T7: " + activeJob.Moves[num].Tool7 + " ; T8: " + activeJob.Moves[num].Tool8 + " ; T9: " + activeJob.Moves[num].Tool9 + " ; T10: " + activeJob.Moves[num].Tool10 + " ; T11: " + activeJob.Moves[num].Tool11 + " ; T12: " + activeJob.Moves[num].Tool12 + " ; Mode: " + activeJob.Moves[num].Mode.ToString() + " ; " + activeJob.Moves[num].Plane.ToString() + ";" + activeJob.Moves[num].Command2.ToString() + ";" + activeJob.Moves[num].Command3;
					stringList.Add(item2);
				}
				stringList.Add("  </MovesDetailed>");
			}
			if (activeJob.ErrorCodes.Count > 0)
			{
				stringList.Add("  <ErrorCodes>");
				for (int num2 = 0; num2 <= activeJob.ErrorCodes.Count - 1; num2++)
				{
					stringList.Add("    " + activeJob.ErrorCodes[num2]);
				}
				stringList.Add("  </ErrorCodes>");
			}
			stringList.Add("</MachineCode>");
			if (SaveAll)
			{
				stringList.Add("<ToolConfiguration>");
				List<string> SL = new List<string>();
				clsInit.cDrill.ToolToStringList(ToolList, ref SL);
				stringList.AddRange(SL);
				stringList.Add("</ToolConfiguration>");
				ArrayList ALSettings = new ArrayList();
				ArrayList ALCam = new ArrayList();
				SaveDrillFile(ref ALSettings, ref ALCam);
				ALSettings.Insert(0, "<SettingConfiguration>");
				ALSettings.Add("</SettingConfiguration>");
				ALCam.Insert(0, "<CamConfiguration>");
				ALCam.Add("</CamConfiguration>");
				for (int num3 = 0; num3 <= ALSettings.Count - 1; num3++)
				{
					stringList.Add(ALSettings[num3].ToString());
				}
				for (int num4 = 0; num4 <= ALCam.Count - 1; num4++)
				{
					stringList.Add(ALCam[num4].ToString());
				}
			}
		}
		catch (Exception mSException)
		{
			string text17 = "";
			buLog.addLog(text17, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text17);
		}
	}

	public void OpenDrillJobFile(List<string> Lines, ref DrillJob Job, bool OpenAll = false, bool Preview = false)
	{
		List<string> CalcList = new List<string>();
		List<string> CalcList2 = new List<string>();
		if (Lines.Count > 0)
		{
			Job = new DrillJob();
			List<List<string>> CalcList3 = new List<List<string>>();
			buString5.ListToSpecificList("<JobCsv>", "</JobCsv>", AddStartEndKey: false, Lines, ref CalcList);
			buString5.ListToSpecificList("<DrillGroup>", "</DrillGroup>", AddStartEndKey: false, CalcList, ref CalcList3);
			buString5.ListToSpecificList("<Material>", "</Material>", AddStartEndKey: false, CalcList, ref CalcList2);
			for (int i = 0; i <= CalcList2.Count - 1; i++)
			{
				string[] array = CalcList2[i].Split(';');
				if (array != null && array.Length >= 2)
				{
					if (array[0].ToLower().IndexOf("name") >= 0)
					{
						Job.Name = array[1];
					}
					if (array[0].ToLower().IndexOf("width") >= 0 && buNumeric5.IsNumeric(array[1]))
					{
						Job.Material.Size.Height = double.Parse(array[1]);
					}
					if (array[0].ToLower().IndexOf("length") >= 0 && buNumeric5.IsNumeric(array[1]))
					{
						Job.Material.Size.Width = double.Parse(array[1]);
					}
					if (array[0].ToLower().IndexOf("height") >= 0 && buNumeric5.IsNumeric(array[1]))
					{
						Job.Material.Size.Depth = double.Parse(array[1]);
					}
				}
			}
			if (Job.Material.Entities.Count == 0)
			{
				Entity Ent = null;
				clsInit.cVector5.CreateMaterialEntities(Job.Material, ref Ent);
				clsInit.cVector5.Move(0.0 - Job.Material.Size.Width, 0.0 - Job.Material.Size.Height, 0.0, ref Ent);
				Job.Material.Entities.Add(Ent);
				Job.panelEntity = Ent;
			}
			double MaterialZeroYPos = 0.0;
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				cGoUltra2Up1Down.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				cGoAtc.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
			}
			if (MachType == DrillMachineType.Sirius)
			{
				cGoSirius.FindFirstClamperPositions(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
			}
			if (ClamperEntity != null)
			{
				clsInit.cDrill.CreateClamperEntities(ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
			}
			for (int j = 0; j <= CalcList3.Count - 1; j++)
			{
				new DrillItemBase();
				new buShape();
				new List<DrillItem>();
				if (CalcList3[j].Count != 2)
				{
					continue;
				}
				string[] array2 = CalcList3[j][0].Split(';');
				if (array2.Length != 2)
				{
					continue;
				}
				if (array2[0].Trim() == ShapeGroup.Drill.ToString())
				{
					if (array2[1].Trim() == drillTypes.SingleHole.ToString())
					{
						string[] array3 = CalcList3[j][1].Split(';');
						if (array3.Length != 0)
						{
							buShapeHole buShapeHole4 = new buShapeHole();
							buShapeHole4.DrillType = drillTypes.SingleHole;
							buShapeHole4.BasePoint.X = double.Parse(array3[0]);
							buShapeHole4.BasePoint.Y = double.Parse(array3[1]);
							buShapeHole4.BasePoint.Z = double.Parse(array3[2]);
							buShapeHole4.Depth = double.Parse(array3[3]);
							buShapeHole4.Diameter = double.Parse(array3[4]);
							planeBoxNames planeName = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array3[5].Trim(), ignoreCase: true);
							buShapeHole4.planeName = planeName;
							buShapeHole4.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole4.planeName);
							buShapeHole4.Enable = buConversion5.StringToBool(array3[6]);
							buShapeHole4.isMilling = buConversion5.StringToBool(array3[7]);
							CornerLocation corner = (CornerLocation)Enum.Parse(typeof(CornerLocation), array3[8].Trim(), ignoreCase: true);
							buShapeHole4.Corner = corner;
							ObjectAlignment alignment = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array3[9].Trim(), ignoreCase: true);
							buShapeHole4.Alignment = alignment;
							if (((array3.Length >= 10) & buShapeHole4.isMilling) && array3.Length >= 10)
							{
								string text = array3[array3.Length - 1].Trim();
								if (text.Length == 0)
								{
									text = array3[array3.Length - 2].Trim();
								}
								buShape S = buShapeHole4;
								clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, text, ref S);
							}
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape = buShapeHole4;
							clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape);
						}
					}
					if ((array2[1].Trim() == drillTypes.HorizontalHoles.ToString()) | (array2[1].Trim() == drillTypes.VerticalHoles.ToString()) | (array2[1].Trim() == drillTypes.HorizontalLineHoles.ToString()) | (array2[1].Trim() == drillTypes.VerticalLineHoles.ToString()) | (array2[1].Trim() == drillTypes.InclineHoles.ToString()))
					{
						drillTypes drillType = drillTypes.HorizontalHoles;
						if (array2[1].Trim() == drillTypes.HorizontalHoles.ToString())
						{
							drillType = drillTypes.HorizontalHoles;
						}
						if (array2[1].Trim() == drillTypes.HorizontalLineHoles.ToString())
						{
							drillType = drillTypes.HorizontalLineHoles;
						}
						if (array2[1].Trim() == drillTypes.VerticalHoles.ToString())
						{
							drillType = drillTypes.VerticalHoles;
						}
						if (array2[1].Trim() == drillTypes.VerticalLineHoles.ToString())
						{
							drillType = drillTypes.VerticalLineHoles;
						}
						if (array2[1].Trim() == drillTypes.InclineHoles.ToString())
						{
							drillType = drillTypes.InclineHoles;
						}
						string[] array4 = CalcList3[j][1].Split(';');
						if (array4.Length != 0)
						{
							buShapeHoleMulti buShapeHoleMulti2 = new buShapeHoleMulti();
							buShapeHoleMulti2.DrillType = drillType;
							buShapeHoleMulti2.BasePoint.X = double.Parse(array4[0]);
							buShapeHoleMulti2.BasePoint.Y = double.Parse(array4[1]);
							buShapeHoleMulti2.BasePoint.Z = double.Parse(array4[2]);
							buShapeHoleMulti2.Depth = double.Parse(array4[3]);
							buShapeHoleMulti2.Diameter = double.Parse(array4[4]);
							planeBoxNames planeName2 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array4[5].Trim(), ignoreCase: true);
							buShapeHoleMulti2.planeName = planeName2;
							buShapeHoleMulti2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHoleMulti2.planeName);
							buShapeHoleMulti2.Enable = buConversion5.StringToBool(array4[6]);
							buShapeHoleMulti2.isMilling = buConversion5.StringToBool(array4[7]);
							buShapeHoleMulti2.Count = int.Parse(array4[8]);
							buShapeHoleMulti2.Distance = double.Parse(array4[9]);
							buShapeHoleMulti2.StartDistance = double.Parse(array4[10]);
							buShapeHoleMulti2.EndDistance = double.Parse(array4[11]);
							buShapeHoleMulti2.Angle = double.Parse(array4[12]);
							CornerLocation corner2 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array4[13].Trim(), ignoreCase: true);
							buShapeHoleMulti2.Corner = corner2;
							ObjectAlignment alignment2 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array4[14].Trim(), ignoreCase: true);
							buShapeHoleMulti2.Alignment = alignment2;
							if (((array4.Length >= 10) & buShapeHoleMulti2.isMilling) && array4.Length >= 10)
							{
								string text2 = array4[array4.Length - 1].Trim();
								if (text2.Length == 0)
								{
									text2 = array4[array4.Length - 2].Trim();
								}
								buShape S2 = buShapeHoleMulti2;
								clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, text2, ref S2);
							}
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape2 = buShapeHoleMulti2;
							clsInit.cVector5.CreatebuShape(ref Shape2, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape2);
						}
					}
					if (array2[1].Trim() == drillTypes.ThreeHole.ToString())
					{
						string[] array5 = CalcList3[j][1].Split(';');
						if (array5.Length != 0)
						{
							buShapeHole3 buShapeHole5 = new buShapeHole3();
							buShapeHole5.DrillType = drillTypes.ThreeHole;
							buShapeHole5.BasePoint.X = double.Parse(array5[0]);
							buShapeHole5.BasePoint.Y = double.Parse(array5[1]);
							buShapeHole5.BasePoint.Z = double.Parse(array5[2]);
							buShapeHole5.Depth = double.Parse(array5[3]);
							buShapeHole5.Diameter = double.Parse(array5[4]);
							planeBoxNames planeName3 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array5[5].Trim(), ignoreCase: true);
							buShapeHole5.planeName = planeName3;
							buShapeHole5.Enable = buConversion5.StringToBool(array5[6]);
							buShapeHole5.isMilling = buConversion5.StringToBool(array5[7]);
							buShapeHole5.DiameterOutside = double.Parse(array5[8]);
							buShapeHole5.Hole3Angle = double.Parse(array5[9]);
							buShapeHole5.DistanceX = double.Parse(array5[10]);
							buShapeHole5.DistanceY = double.Parse(array5[11]);
							CornerLocation corner3 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array5[12].Trim(), ignoreCase: true);
							buShapeHole5.Corner = corner3;
							ObjectAlignment alignment3 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array5[13].Trim(), ignoreCase: true);
							buShapeHole5.Alignment = alignment3;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape3 = buShapeHole5;
							clsInit.cVector5.CreatebuShape(ref Shape3, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape3);
						}
					}
				}
				if (array2[0].Trim() == ShapeGroup.Cut.ToString())
				{
					string[] array6 = CalcList3[j][1].Split(';');
					if (array6.Length != 0)
					{
						buShapeCut buShapeCut2 = new buShapeCut();
						CutTypes cutType = (CutTypes)Enum.Parse(typeof(CutTypes), array2[1].Trim(), ignoreCase: true);
						buShapeCut2.CutType = cutType;
						buShapeCut2.BasePoint.X = double.Parse(array6[0]);
						buShapeCut2.BasePoint.Y = double.Parse(array6[1]);
						buShapeCut2.BasePoint.Z = double.Parse(array6[2]);
						buShapeCut2.Depth = double.Parse(array6[3]);
						buShapeCut2.Diameter = double.Parse(array6[4]);
						planeBoxNames planeName4 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array6[5].Trim(), ignoreCase: true);
						buShapeCut2.planeName = planeName4;
						buShapeCut2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut2.planeName);
						buShapeCut2.Enable = buConversion5.StringToBool(array6[6]);
						buShapeCut2.isMilling = buConversion5.StringToBool(array6[7]);
						buShapeCut2.Length = double.Parse(array6[8]);
						buShapeCut2.Angle = double.Parse(array6[9]);
						buShapeCut2.StartDistance = double.Parse(array6[10]);
						buShapeCut2.EndDistance = double.Parse(array6[11]);
						CornerLocation corner4 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array6[12].Trim(), ignoreCase: true);
						buShapeCut2.Corner = corner4;
						ObjectAlignment alignment4 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array6[13].Trim(), ignoreCase: true);
						buShapeCut2.Alignment = alignment4;
						if (((array6.Length >= 10) & buShapeCut2.isMilling) && array6.Length >= 10)
						{
							string text3 = array6[array6.Length - 1].Trim();
							if (text3.Length == 0)
							{
								text3 = array6[array6.Length - 2].Trim();
							}
							buShape S3 = buShapeCut2;
							clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, text3, ref S3);
						}
						clsVar5.shapeCreatePar.Solid = true;
						clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
						clsVar5.shapeCreatePar.SingX = -1.0;
						clsVar5.shapeCreatePar.SingY = -1.0;
						buShape Shape4 = buShapeCut2;
						clsInit.cVector5.CreatebuShape(ref Shape4, clsVar5.shapeCreatePar);
						Job.Items.Add(Shape4);
					}
				}
				if (array2[0].Trim() == ShapeGroup.Shape.ToString())
				{
					string[] array7 = CalcList3[j][1].Split(';');
					if (array7.Length != 0)
					{
						ShapeTypes shapeTypes = (ShapeTypes)Enum.Parse(typeof(ShapeTypes), array2[1].Trim(), ignoreCase: true);
						bool flag = false;
						if (shapeTypes == ShapeTypes.Rectangle)
						{
							buShapeRectangle buShapeRectangle2 = new buShapeRectangle();
							buShapeRectangle2.ShapeType = shapeTypes;
							buShapeRectangle2.BasePoint.X = double.Parse(array7[0]);
							buShapeRectangle2.BasePoint.Y = double.Parse(array7[1]);
							buShapeRectangle2.BasePoint.Z = double.Parse(array7[2]);
							buShapeRectangle2.Depth = double.Parse(array7[3]);
							buShapeRectangle2.Radius = double.Parse(array7[4]);
							planeBoxNames planeName5 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array7[5].Trim(), ignoreCase: true);
							buShapeRectangle2.planeName = planeName5;
							buShapeRectangle2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeRectangle2.planeName);
							buShapeRectangle2.Enable = buConversion5.StringToBool(array7[6]);
							buShapeRectangle2.isPocket = buConversion5.StringToBool(array7[7]);
							buShapeRectangle2.Angle = double.Parse(array7[8]);
							buShapeRectangle2.Width = double.Parse(array7[9]);
							buShapeRectangle2.Height = double.Parse(array7[10]);
							buShapeRectangle2.Chamfer = double.Parse(array7[11]);
							CornerLocation corner5 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array7[12].Trim(), ignoreCase: true);
							buShapeRectangle2.Corner = corner5;
							ObjectAlignment alignment5 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array7[13].Trim(), ignoreCase: true);
							buShapeRectangle2.Alignment = alignment5;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape5 = buShapeRectangle2;
							clsInit.cVector5.CreatebuShape(ref Shape5, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape5);
							flag = true;
						}
						if (shapeTypes == ShapeTypes.Circle)
						{
							buShapeCircle buShapeCircle2 = new buShapeCircle();
							buShapeCircle2.ShapeType = shapeTypes;
							buShapeCircle2.BasePoint.X = double.Parse(array7[0]);
							buShapeCircle2.BasePoint.Y = double.Parse(array7[1]);
							buShapeCircle2.BasePoint.Z = double.Parse(array7[2]);
							buShapeCircle2.Depth = double.Parse(array7[3]);
							buShapeCircle2.Radius = double.Parse(array7[4]);
							planeBoxNames planeName6 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array7[5].Trim(), ignoreCase: true);
							buShapeCircle2.planeName = planeName6;
							buShapeCircle2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCircle2.planeName);
							buShapeCircle2.Enable = buConversion5.StringToBool(array7[6]);
							buShapeCircle2.isPocket = buConversion5.StringToBool(array7[7]);
							CornerLocation corner6 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array7[8].Trim(), ignoreCase: true);
							buShapeCircle2.Corner = corner6;
							ObjectAlignment alignment6 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array7[9].Trim(), ignoreCase: true);
							buShapeCircle2.Alignment = alignment6;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape6 = buShapeCircle2;
							clsInit.cVector5.CreatebuShape(ref Shape6, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape6);
							flag = true;
						}
						if (shapeTypes == ShapeTypes.Ellipse)
						{
							buShapeEllipse buShapeEllipse2 = new buShapeEllipse();
							buShapeEllipse2.ShapeType = shapeTypes;
							buShapeEllipse2.BasePoint.X = double.Parse(array7[0]);
							buShapeEllipse2.BasePoint.Y = double.Parse(array7[1]);
							buShapeEllipse2.BasePoint.Z = double.Parse(array7[2]);
							buShapeEllipse2.Depth = double.Parse(array7[3]);
							buShapeEllipse2.RadiusX = double.Parse(array7[4]);
							planeBoxNames planeName7 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array7[5].Trim(), ignoreCase: true);
							buShapeEllipse2.planeName = planeName7;
							buShapeEllipse2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeEllipse2.planeName);
							buShapeEllipse2.Enable = buConversion5.StringToBool(array7[6]);
							buShapeEllipse2.isPocket = buConversion5.StringToBool(array7[7]);
							buShapeEllipse2.Angle = double.Parse(array7[8]);
							buShapeEllipse2.RadiusY = double.Parse(array7[9]);
							CornerLocation corner7 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array7[10].Trim(), ignoreCase: true);
							buShapeEllipse2.Corner = corner7;
							ObjectAlignment alignment7 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array7[11].Trim(), ignoreCase: true);
							buShapeEllipse2.Alignment = alignment7;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape7 = buShapeEllipse2;
							clsInit.cVector5.CreatebuShape(ref Shape7, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape7);
							flag = true;
						}
						if (shapeTypes == ShapeTypes.Slot)
						{
							buShapeSlot buShapeSlot2 = new buShapeSlot();
							buShapeSlot2.ShapeType = shapeTypes;
							buShapeSlot2.BasePoint.X = double.Parse(array7[0]);
							buShapeSlot2.BasePoint.Y = double.Parse(array7[1]);
							buShapeSlot2.BasePoint.Z = double.Parse(array7[2]);
							buShapeSlot2.Depth = double.Parse(array7[3]);
							buShapeSlot2.Diameter = double.Parse(array7[4]);
							planeBoxNames planeName8 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array7[5].Trim(), ignoreCase: true);
							buShapeSlot2.planeName = planeName8;
							buShapeSlot2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeSlot2.planeName);
							buShapeSlot2.Enable = buConversion5.StringToBool(array7[6]);
							buShapeSlot2.isPocket = buConversion5.StringToBool(array7[7]);
							buShapeSlot2.Angle = double.Parse(array7[8]);
							buShapeSlot2.Length = double.Parse(array7[9]);
							CornerLocation corner8 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array7[10].Trim(), ignoreCase: true);
							buShapeSlot2.Corner = corner8;
							ObjectAlignment alignment8 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array7[11].Trim(), ignoreCase: true);
							buShapeSlot2.Alignment = alignment8;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape8 = buShapeSlot2;
							clsInit.cVector5.CreatebuShape(ref Shape8, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape8);
							flag = true;
						}
						if (shapeTypes == ShapeTypes.KeyHole)
						{
							buShapeKeyHole buShapeKeyHole2 = new buShapeKeyHole();
							buShapeKeyHole2.ShapeType = shapeTypes;
							buShapeKeyHole2.BasePoint.X = double.Parse(array7[0]);
							buShapeKeyHole2.BasePoint.Y = double.Parse(array7[1]);
							buShapeKeyHole2.BasePoint.Z = double.Parse(array7[2]);
							buShapeKeyHole2.Depth = double.Parse(array7[3]);
							buShapeKeyHole2.Diameter = double.Parse(array7[4]);
							planeBoxNames planeName9 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array7[5].Trim(), ignoreCase: true);
							buShapeKeyHole2.planeName = planeName9;
							buShapeKeyHole2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeKeyHole2.planeName);
							buShapeKeyHole2.Enable = buConversion5.StringToBool(array7[6]);
							buShapeKeyHole2.isPocket = buConversion5.StringToBool(array7[7]);
							buShapeKeyHole2.Angle = double.Parse(array7[8]);
							buShapeKeyHole2.HeadDiameter = double.Parse(array7[9]);
							buShapeKeyHole2.Length = double.Parse(array7[10]);
							CornerLocation corner9 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array7[11].Trim(), ignoreCase: true);
							buShapeKeyHole2.Corner = corner9;
							ObjectAlignment alignment9 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array7[12].Trim(), ignoreCase: true);
							buShapeKeyHole2.Alignment = alignment9;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape9 = buShapeKeyHole2;
							clsInit.cVector5.CreatebuShape(ref Shape9, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape9);
							flag = true;
						}
						if (shapeTypes == ShapeTypes.Polygon)
						{
							buShapePolygon buShapePolygon2 = new buShapePolygon();
							buShapePolygon2.ShapeType = shapeTypes;
							buShapePolygon2.BasePoint.X = double.Parse(array7[0]);
							buShapePolygon2.BasePoint.Y = double.Parse(array7[1]);
							buShapePolygon2.BasePoint.Z = double.Parse(array7[2]);
							buShapePolygon2.Depth = double.Parse(array7[3]);
							buShapePolygon2.Radius = double.Parse(array7[4]);
							planeBoxNames planeName10 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array7[5].Trim(), ignoreCase: true);
							buShapePolygon2.planeName = planeName10;
							buShapePolygon2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapePolygon2.planeName);
							buShapePolygon2.Enable = buConversion5.StringToBool(array7[6]);
							buShapePolygon2.isPocket = buConversion5.StringToBool(array7[7]);
							buShapePolygon2.Angle = double.Parse(array7[8]);
							buShapePolygon2.Side = int.Parse(array7[9]);
							CornerLocation corner10 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array7[10].Trim(), ignoreCase: true);
							buShapePolygon2.Corner = corner10;
							ObjectAlignment alignment10 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array7[11].Trim(), ignoreCase: true);
							buShapePolygon2.Alignment = alignment10;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape10 = buShapePolygon2;
							clsInit.cVector5.CreatebuShape(ref Shape10, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape10);
							flag = true;
						}
						if (shapeTypes == ShapeTypes.FreeDraw)
						{
							buShapeFreeDraw buShapeFreeDraw2 = new buShapeFreeDraw();
							buShapeFreeDraw2.ShapeType = shapeTypes;
							buShapeFreeDraw2.BasePoint.X = double.Parse(array7[0]);
							buShapeFreeDraw2.BasePoint.Y = double.Parse(array7[1]);
							buShapeFreeDraw2.BasePoint.Z = double.Parse(array7[2]);
							buShapeFreeDraw2.Depth = double.Parse(array7[3]);
							buShapeFreeDraw2.Width = double.Parse(array7[4]);
							planeBoxNames planeName11 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array7[5].Trim(), ignoreCase: true);
							buShapeFreeDraw2.planeName = planeName11;
							buShapeFreeDraw2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeFreeDraw2.planeName);
							buShapeFreeDraw2.Enable = buConversion5.StringToBool(array7[6]);
							buShapeFreeDraw2.isPocket = buConversion5.StringToBool(array7[7]);
							buShapeFreeDraw2.Angle = double.Parse(array7[8]);
							buShapeFreeDraw2.Height = double.Parse(array7[9]);
							CornerLocation corner11 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array7[10].Trim(), ignoreCase: true);
							buShapeFreeDraw2.Corner = corner11;
							ObjectAlignment alignment11 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array7[11].Trim(), ignoreCase: true);
							buShapeFreeDraw2.Alignment = alignment11;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape11 = buShapeFreeDraw2;
							clsInit.cVector5.CreatebuShape(ref Shape11, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape11);
							flag = true;
						}
						if (array7.Length >= 10 && flag && array7.Length >= 10)
						{
							string text4 = array7[array7.Length - 1].Trim();
							if (text4.Length == 0)
							{
								text4 = array7[array7.Length - 2].Trim();
							}
							buShape S4 = Job.Items[Job.Items.Count - 1];
							clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, text4, ref S4);
						}
					}
				}
				if (array2[0].Trim() == ShapeGroup.Profiling.ToString())
				{
					string[] array8 = CalcList3[j][1].Split(';');
					if (array8.Length != 0)
					{
						buShapeProfiling buShapeProfiling2 = new buShapeProfiling();
						ProfilingTypes profilingType = (ProfilingTypes)Enum.Parse(typeof(ProfilingTypes), array2[1].Trim(), ignoreCase: true);
						buShapeProfiling2.ProfilingType = profilingType;
						buShapeProfiling2.BasePoint.X = double.Parse(array8[0]);
						buShapeProfiling2.BasePoint.Y = double.Parse(array8[1]);
						buShapeProfiling2.BasePoint.Z = double.Parse(array8[2]);
						buShapeProfiling2.Depth = double.Parse(array8[3]);
						buShapeProfiling2.Radius = double.Parse(array8[4]);
						planeBoxNames planeName12 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array8[5].Trim(), ignoreCase: true);
						buShapeProfiling2.planeName = planeName12;
						buShapeProfiling2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeProfiling2.planeName);
						buShapeProfiling2.Enable = buConversion5.StringToBool(array8[6]);
						buShapeProfiling2.isPocket = buConversion5.StringToBool(array8[7]);
						buShapeProfiling2.Length = double.Parse(array8[8]);
						buShapeProfiling2.Width = double.Parse(array8[9]);
						buShapeProfiling2.Height = double.Parse(array8[10]);
						CornerLocation corner12 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array8[11].Trim(), ignoreCase: true);
						buShapeProfiling2.Corner = corner12;
						ObjectAlignment alignment12 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array8[12].Trim(), ignoreCase: true);
						buShapeProfiling2.Alignment = alignment12;
						if (array8.Length >= 10)
						{
							string text5 = array8[array8.Length - 1].Trim();
							if (text5.Length == 0)
							{
								text5 = array8[array8.Length - 2].Trim();
							}
							buShape S5 = buShapeProfiling2;
							clsInit.cDrill.FindOperationToolFromString(ccVars.Tools, ccVars.toolActive, text5, ref S5);
						}
						clsVar5.shapeCreatePar.Solid = true;
						clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
						clsVar5.shapeCreatePar.SingX = -1.0;
						clsVar5.shapeCreatePar.SingY = -1.0;
						buShape Shape12 = buShapeProfiling2;
						clsInit.cVector5.CreatebuShape(ref Shape12, clsVar5.shapeCreatePar);
						Job.Items.Add(Shape12);
					}
				}
				if (array2[0].Trim() == ShapeGroup.Junction.ToString())
				{
					string[] array9 = CalcList3[j][1].Split(';');
					if (array9.Length != 0)
					{
						buShapeJunction buShapeJunction2 = new buShapeJunction();
						JunctionTypes junctionType = (JunctionTypes)Enum.Parse(typeof(JunctionTypes), array2[1].Trim(), ignoreCase: true);
						buShapeJunction2.JunctionType = junctionType;
						buShapeJunction2.BasePoint.X = double.Parse(array9[0]);
						buShapeJunction2.BasePoint.Y = double.Parse(array9[1]);
						buShapeJunction2.BasePoint.Z = double.Parse(array9[2]);
						buShapeJunction2.Depth = double.Parse(array9[3]);
						buShapeJunction2.Diameter = double.Parse(array9[4]);
						planeBoxNames planeName13 = (planeBoxNames)Enum.Parse(typeof(planeBoxNames), array9[5].Trim(), ignoreCase: true);
						buShapeJunction2.planeName = planeName13;
						buShapeJunction2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeJunction2.planeName);
						buShapeJunction2.Enable = buConversion5.StringToBool(array9[6]);
						buShapeJunction2.isMilling = buConversion5.StringToBool(array9[7]);
						buShapeJunction2.DiameterOutside = double.Parse(array9[8]);
						buShapeJunction2.Distance = double.Parse(array9[9]);
						CornerLocation corner13 = (CornerLocation)Enum.Parse(typeof(CornerLocation), array9[10].Trim(), ignoreCase: true);
						buShapeJunction2.Corner = corner13;
						ObjectAlignment alignment13 = (ObjectAlignment)Enum.Parse(typeof(ObjectAlignment), array9[11].Trim(), ignoreCase: true);
						buShapeJunction2.Alignment = alignment13;
						clsVar5.shapeCreatePar.Solid = true;
						clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
						clsVar5.shapeCreatePar.SingX = -1.0;
						clsVar5.shapeCreatePar.SingY = -1.0;
						buShape Shape13 = buShapeJunction2;
						clsInit.cVector5.CreatebuShape(ref Shape13, clsVar5.shapeCreatePar);
						Job.Items.Add(Shape13);
					}
				}
			}
			if (OpenAll)
			{
				List<ToolBase5> CopiedTools = new List<ToolBase5>();
				ToolBase5.Copy(ToolList, ref CopiedTools);
				if (ToolList.Count != 0)
				{
				}
				List<string> CalcList4 = new List<string>();
				buString5.ListToSpecificList("<ToolConfiguration>", "</ToolConfiguration>", AddStartEndKey: false, Lines, ref CalcList4);
				if (CalcList4.Count > 0)
				{
					ToolList = new List<ToolBase5>();
					clsInit.cDrill.StringListToTool(CalcList, ref ToolList);
				}
				if ((ToolList.Count == 0) & (CopiedTools.Count > 0))
				{
					ToolBase5.Copy(CopiedTools, ref ToolList);
				}
				ArrayList CalcList5 = new ArrayList();
				buString5.ListToSpecificList("<SettingConfiguration>", "</SettingConfiguration>", AddStartEndKey: false, Lines, ref CalcList5);
				ArrayList CalcList6 = new ArrayList();
				buString5.ListToSpecificList("<CamConfiguration>", "</CamConfiguration>", AddStartEndKey: false, Lines, ref CalcList6);
				if ((CalcList5.Count > 0) | (CalcList6.Count > 0))
				{
					OpenDrillFile(CalcList5, CalcList6);
				}
				if (ToolList.Count == 0)
				{
					OpenDrillFile();
				}
			}
			if (ToolList.Count == 0)
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentences.CustomerClassNotReady);
			}
		}
		if (!Preview)
		{
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(Job);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit(40);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public void OpenDrillJobFile(string FileName, ref DrillJob Job, bool OpenAll = false, bool Preview = false)
	{
		try
		{
			List<string> StringList = new List<string>();
			new List<string>();
			new List<string>();
			buFile5.OpenFromFile(FileName, ref StringList);
			OpenDrillJobFile(StringList, ref Job, OpenAll, Preview);
			fileNameActual = FileName;
			AddRecentOpenFile(FileName);
			ccVars.Pages[ccVars.PageIndex].Form.Text = buFile5.getFileName(FileName);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void OpenToolConfigFile(string FileName)
	{
		try
		{
			List<string> StringList = new List<string>();
			buFile5.OpenFromFile(FileName, ref StringList);
			ToolList = new List<ToolBase5>();
			clsInit.cDrill.StringListToTool(StringList, ref ToolList);
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				for (int i = 0; i <= ToolList.Count - 1; i++)
				{
					if (ToolList[i].Data.No == 85)
					{
						toolSlotY1 = new ToolBase5(ToolList[i]);
					}
					if (ToolList[i].Data.No == 185)
					{
						toolSlotY2 = new ToolBase5(ToolList[i]);
					}
				}
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				for (int j = 0; j <= ToolList.Count - 1; j++)
				{
					if (ToolList[j].Data.No == 95)
					{
						toolSlotY1 = new ToolBase5(ToolList[j]);
					}
				}
			}
			if (MachType != DrillMachineType.Sirius)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void SaveToolConfigFile(string FileName)
	{
		List<string> SL = new List<string>();
		clsInit.cDrill.ToolToStringList(ToolList, ref SL);
		if (SL.Count > 0)
		{
			SL.Insert(0, Application.ProductVersion + " - " + clsVar.varRuntime.ReleaseVer);
			SL.Insert(1, MachType.ToString());
			buFile5.SaveToFile(SL, FileName);
		}
	}

	public void OpenFilePreview(FileEventArg e)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(e.FileName);
			if (!(fileInfo.Exists & openDialogCtrlPreview.chk_preview.Checked))
			{
				openDialogCtrlPreview.picture_preview.Image = null;
				return;
			}
			clsVar.PreviewLoaded = false;
			clsItem.ModelOpenPreview.Width = openDialogCtrlPreview.picture_preview.Width;
			clsItem.ModelOpenPreview.Height = openDialogCtrlPreview.picture_preview.Height;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
			{
				Layer layer = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i];
				if (!clsInit.cVector5.IsLayerNameAvailable(clsItem.ModelOpenPreview.Layers, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name))
				{
					Layer newItem = new Layer(layer.Name, layer.Color, layer.LineTypeName, layer.LineWeight, visible: true);
					clsItem.ModelOpenPreview.Layers.AddOrReplace(newItem);
				}
			}
			if (fileInfo.Extension.ToLower() == ".aesjob")
			{
				openDialogCtrlPreview.ShowLoading(Show: true);
				Application.DoEvents();
				DrillJob Job = new DrillJob();
				OpenDrillJobFile(fileInfo.FullName, ref Job, OpenAll: false, Preview: true);
				DrawPanelFromJob(Job, new ViewportDrawOptions(ViewportRefType.OpenDialog));
				openDialogCtrlPreview.lbl_info.Text = Job.Material.Size.Width.ToString("f1") + " X " + Job.Material.Size.Height.ToString("f1") + " X " + Job.Material.Size.Depth.ToString("f1");
				SetPreviewImage();
			}
			if (fileInfo.Extension.ToLower() == ".aesnc")
			{
				openDialogCtrlPreview.ShowLoading(Show: true);
				Application.DoEvents();
				DrillJob Job2 = new DrillJob();
				OpenCabinetFile(fileInfo.FullName, ref Job2, Preview: true);
				DrawPanelFromJob(Job2, new ViewportDrawOptions(ViewportRefType.OpenDialog));
				openDialogCtrlPreview.lbl_info.Text = Job2.Material.Size.Width.ToString("f1") + " X " + Job2.Material.Size.Height.ToString("f1") + " X " + Job2.Material.Size.Depth.ToString("f1");
				SetPreviewImage();
			}
			if (fileInfo.Extension.ToLower() == ".dxf")
			{
				openDialogCtrlPreview.ShowLoading(Show: true);
				Application.DoEvents();
				DrillJob Job3 = new DrillJob();
				OpenCorpusFile(fileInfo.FullName, ref Job3, Preview: true);
				DrawPanelFromJob(Job3, new ViewportDrawOptions(ViewportRefType.OpenDialog));
				openDialogCtrlPreview.lbl_info.Text = Job3.Material.Size.Width.ToString("f1") + " X " + Job3.Material.Size.Height.ToString("f1") + " X " + Job3.Material.Size.Depth.ToString("f1");
				SetPreviewImage();
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			throw;
		}
	}

	public void ERPCycle_Tick(object sender, EventArgs e)
	{
		if (timCabinetStartCycle.Enabled)
		{
			return;
		}
		FilesERP = new List<string>();
		buFile5.getFiles(varDrillRunSettings.CabinetpathImport, ref FilesERP);
		if (!((FilesERP.Count > 0) & (fileNameCabinerCycle == "")))
		{
			return;
		}
		if (varDrillRunSettings.ErpFileType == drillErpFileType.Cabinet)
		{
			for (int i = 0; i <= FilesERP.Count - 1; i++)
			{
				FileInfo fileInfo = new FileInfo(FilesERP[i]);
				if (fileInfo.Exists && fileInfo.Extension == "." + varDrillRunSettings.CabinetAutoFileExtension)
				{
					fileNameCabinerCycle = fileInfo.FullName;
					timCabinetStartCycle.Enabled = true;
				}
			}
		}
		if (varDrillRunSettings.ErpFileType == drillErpFileType.Corpus)
		{
			timCabinetCycle.Enabled = false;
			OpenCorpusJobListFile(FilesERP, AutoFileArrived: true);
		}
		if (varDrillRunSettings.ErpFileType == drillErpFileType.Cyncly)
		{
			timCabinetCycle.Enabled = false;
			OpenCynclyJobListFile(FilesERP, AutoFileArrived: true);
		}
	}

	public void ERPStartCycle_Tick(object sender, EventArgs e)
	{
		timCabinetStartCycle.Enabled = false;
		if (varDrillRunSettings.ErpFileType == drillErpFileType.Cabinet)
		{
			OpenCabinetJobListFile(fileNameCabinerCycle, AutoFileArrived: true);
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathDeleted);
		if (directoryInfo.Exists & varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
		{
			buFile5.CopyFileToFolder(fileNameCabinerCycle, directoryInfo.FullName);
		}
		File.Delete(fileNameCabinerCycle);
		fileNameCabinerCycle = "";
	}

	public void OpenCabinetJobListFile(string Filename, bool AutoFileArrived = false)
	{
		List<string> StringList = new List<string>();
		buFile5.OpenFromFile(Filename, ref StringList);
		List<InfoCount> list = new List<InfoCount>();
		int num = -1;
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			if (StringList[i].IndexOf(varDrillRunSettings.CabinetReferanceKey) >= 0)
			{
				num = i;
				i = StringList.Count;
			}
		}
		if (num != -1)
		{
			if (StringList.Count <= num || StringList[0].IndexOf("^Job") < 0)
			{
				return;
			}
			if (clsItem.FrmProgress == null)
			{
				clsItem.FrmProgress = new F_ProgressCalculation();
			}
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(Filename);
			string path = buFile5.GetPath(Filename);
			DirectoryInfo directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathExport);
			if (directoryInfo.Exists)
			{
				if (varDrillRunSettings.CabinetSubFolder)
				{
					directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathExport + "\\" + fileNameWithoutExtension);
					if (!directoryInfo.Exists)
					{
						directoryInfo.Create();
					}
				}
			}
			else
			{
				directoryInfo = new DirectoryInfo(path + "\\" + fileNameWithoutExtension);
				if (directoryInfo.Exists)
				{
					directoryInfo.Delete(recursive: true);
				}
				directoryInfo.Create();
			}
			TreeNode treeNode = null;
			if (AutoFileArrived & FrmCabinetCycle.Visible)
			{
				treeNode = new TreeNode(fileNameWithoutExtension);
			}
			CalculationEventArg calculationEventArg = new CalculationEventArg();
			for (int j = num; j <= StringList.Count - 1; j++)
			{
				clsItem.FrmProgress.Visible = true;
				string[] array = StringList[j].Split(',');
				if (array != null && array.Length != 0)
				{
					FileInfo fileInfo = new FileInfo(path + "\\" + array[0].Trim() + ".AESNC");
					bool flag = true;
					if (fileInfo.Exists)
					{
						InfoCount item = new InfoCount(1.0, array[0].Trim());
						for (int k = 0; k <= list.Count - 1; k++)
						{
							if (list[k].Info == array[0].Trim())
							{
								list[k].Count += 1.0;
								flag = false;
								k = list.Count;
							}
						}
						if (flag)
						{
							list.Add(item);
							fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(fileInfo.FullName);
							activeJob = new DrillJob();
							OpenCabinetFile(fileInfo.FullName, ref activeJob);
							string fileName = directoryInfo.FullName + "\\" + fileNameWithoutExtension;
							cmdShowCode(CreateCode: true, fileName);
						}
					}
					if (AutoFileArrived & fileInfo.Exists)
					{
						if (FrmCabinetCycle.Visible && treeNode != null)
						{
							new TreeNode();
							treeNode.Nodes.Add(array[0].Trim() + " - " + array[1].Trim());
						}
						DirectoryInfo directoryInfo2 = new DirectoryInfo(varDrillRunSettings.CabinetpathDeleted);
						if (directoryInfo2.Exists & varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
						{
							buFile5.CopyFileToFolder(fileInfo.FullName, directoryInfo2.FullName);
						}
						fileInfo.Delete();
					}
				}
				calculationEventArg.ActiveProgressPercentage = 100.0 * (double)j / Convert.ToDouble(StringList.Count - 1);
				calculationEventArg.OverallProgressPercentage = 100.0;
				calculationEventArg.Job = buLangTranslate.preDef.Calculating;
				clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
			}
			clsItem.FrmProgress.Visible = false;
			if ((AutoFileArrived & FrmCabinetCycle.Visible) && treeNode != null)
			{
				FrmCabinetCycle.tree_files.Nodes.Add(treeNode);
			}
			if (((list.Count > 0) & varDrillRunSettings.CabinetShowInfo) && !AutoFileArrived)
			{
				DialogBoxList dialogBoxList = new DialogBoxList();
				List<string> list2 = new List<string>();
				for (int l = 0; l <= list.Count - 1; l++)
				{
					list2.Add(list[l].Info + ";" + list[l].Count.ToString("f0"));
					dialogBoxList.Items.Add(buLangTranslate.preDef.FileName + ": " + list[l].Info + "  " + buLangTranslate.preDef.Count + ": " + list[l].Count.ToString("f0"));
				}
				string fileName2 = directoryInfo.FullName + "\\Info.txt";
				buFile5.SaveToFile(list2, fileName2);
				clsItem.FrmProgress.Visible = false;
				dialogBoxList.Caption = buLangTranslate.preDef.Job;
				dialogBoxList.Init();
				dialogBoxList.ShowDialog();
				clsItem.FrmProgress.Visible = false;
			}
		}
		else
		{
			buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[65]);
		}
	}

	public void OpenCabinetFile(string Filename, ref DrillJob Job, bool Preview = false)
	{
		varDrillRunSettings.path3DJob = buFile5.GetPath(Filename);
		SaveDrillFile();
		List<string> StringList = new List<string>();
		buFile5.OpenFromFile(Filename, ref StringList);
		string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(Filename);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		if (fileNameWithoutExtension.Length < 4 || fileNameWithoutExtension.Substring(3, 1).ToLower() == "f")
		{
		}
		if (StringList.Count <= 0)
		{
			return;
		}
		string Value = "";
		bool flag = false;
		bool flag2 = false;
		Job = new DrillJob();
		List<string> list = new List<string>();
		ToolBase5 toolBase = null;
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			if (StringList[i].IndexOf("PNAME") >= 0)
			{
				buString5.ReadStringValue(StringList[i], "PNAME=", ref Job.Name);
			}
			if (StringList[i].IndexOf("XAX") >= 0)
			{
				string[] array = StringList[i].Split(' ');
				if (array.Length != 0)
				{
					for (int j = 0; j <= array.Length - 1; j++)
					{
						if (array[j].IndexOf("XAX") >= 0)
						{
							buString5.ReadStringValue(array[j], "XAX=", ref Value);
							double.TryParse(Value, out Job.Material.Size.Width);
						}
						if (array[j].IndexOf("YAX") >= 0)
						{
							buString5.ReadStringValue(array[j], "YAX=", ref Value);
							double.TryParse(Value, out Job.Material.Size.Height);
						}
						if (array[j].IndexOf("ZAX") >= 0)
						{
							buString5.ReadStringValue(array[j], "ZAX=", ref Value);
							double.TryParse(Value, out Job.Material.Size.Depth);
						}
					}
					Entity Ent = null;
					clsInit.cVector5.CreateMaterialEntities(Job.Material, ref Ent);
					clsInit.cVector5.Move(0.0 - Job.Material.Size.Width, 0.0 - Job.Material.Size.Height, 0.0, ref Ent);
					Job.Material.Entities.Add(Ent);
					Job.panelEntity = Ent;
				}
			}
			if ((StringList[i].IndexOf("M40") >= 0) | (StringList[i].IndexOf("M41") >= 0))
			{
				string[] array2 = StringList[i].Split(' ');
				if (array2.Length != 0)
				{
					buShapeHole buShapeHole4 = new buShapeHole();
					if (StringList[i].IndexOf("M41") >= 0)
					{
						buShapeHole4.isMilling = true;
					}
					bool flag3 = false;
					for (int k = 0; k <= array2.Length - 1; k++)
					{
						if (array2[k].IndexOf("FACE") >= 0)
						{
							buString5.ReadStringValue(array2[k], "FACE=", ref Value);
							int result = 0;
							int.TryParse(Value, out result);
							if (result == 2)
							{
								buShapeHole4.planeName = planeBoxNames.Left;
								flag3 = true;
							}
							if (result == 4)
							{
								buShapeHole4.planeName = planeBoxNames.Right;
								flag3 = true;
							}
							if (result == 5)
							{
								buShapeHole4.planeName = planeBoxNames.Bottom;
								flag3 = true;
							}
							if (result == 0)
							{
								buShapeHole4.planeName = planeBoxNames.Top;
								flag3 = true;
							}
							if (result == 3)
							{
								buShapeHole4.planeName = planeBoxNames.Front;
								flag3 = true;
							}
							if (result == 1)
							{
								buShapeHole4.planeName = planeBoxNames.Back;
								flag3 = true;
							}
						}
					}
					string[] array3 = StringList[i + 1].Split(' ');
					for (int l = 0; l <= array3.Length - 1; l++)
					{
						if (array3[l].IndexOf("X") >= 0)
						{
							if ((buShapeHole4.planeName == planeBoxNames.Top) | (buShapeHole4.planeName == planeBoxNames.Bottom) | (buShapeHole4.planeName == planeBoxNames.Front) | (buShapeHole4.planeName == planeBoxNames.Back))
							{
								buString5.ReadCharValue(array3[l], "X", ref buShapeHole4.BasePoint.X);
							}
							if (buShapeHole4.planeName == planeBoxNames.Right)
							{
								buShapeHole4.BasePoint.X = 0.0;
							}
							if (buShapeHole4.planeName == planeBoxNames.Left)
							{
								buShapeHole4.BasePoint.X = Job.Material.Size.Width;
							}
						}
						if (array3[l].IndexOf("Y") >= 0)
						{
							if ((buShapeHole4.planeName == planeBoxNames.Left) | (buShapeHole4.planeName == planeBoxNames.Right) | (buShapeHole4.planeName == planeBoxNames.Top) | (buShapeHole4.planeName == planeBoxNames.Bottom))
							{
								buString5.ReadCharValue(array3[l], "Y", ref buShapeHole4.BasePoint.Y);
							}
							if (buShapeHole4.planeName == planeBoxNames.Back)
							{
								buShapeHole4.BasePoint.Y = 0.0;
							}
							if (buShapeHole4.planeName == planeBoxNames.Front)
							{
								buShapeHole4.BasePoint.Y = Job.Material.Size.Height;
							}
							buShapeHole4.BasePoint.Z = 9.0;
						}
						if (array3[l].IndexOf("D") >= 0)
						{
							buString5.ReadCharValue(array3[l], "D", ref buShapeHole4.Diameter);
						}
						if (array3[l].IndexOf("VB") >= 0)
						{
							buString5.ReadCharValue(array3[l], "VB", ref buShapeHole4.Depth);
							buShapeHole4.Depth = Math.Abs(buShapeHole4.Depth);
						}
					}
					buShapeHole4.DrillType = drillTypes.SingleHole;
					buShapeHole4.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole4.planeName);
					buShapeHole4.Corner = CornerLocation.RightTop;
					buShapeHole4.Alignment = ObjectAlignment.MiddleCenter;
					if (buShapeHole4.isMilling)
					{
						for (int m = 0; m <= ccVars.Tools[0].Tools.Count - 1; m++)
						{
							if (buCompare5.EQ(ccVars.Tools[0].Tools[m].Geometry.Diameter, buShapeHole4.Diameter, 0.01))
							{
								buShapeHole4.Tool = new ToolBase5(ccVars.Tools[0].Tools[m]);
							}
						}
					}
					clsVar5.shapeCreatePar.Solid = true;
					clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
					clsVar5.shapeCreatePar.SingX = -1.0;
					clsVar5.shapeCreatePar.SingY = -1.0;
					buShape Shape = buShapeHole4;
					clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
					if (flag3)
					{
						Job.Items.Add(Shape);
					}
				}
			}
			if (StringList[i].IndexOf("M42") >= 0)
			{
				string[] array4 = StringList[i].Split(' ');
				if (array4.Length != 0)
				{
					buShapeCut buShapeCut2 = new buShapeCut();
					bool flag4 = false;
					for (int n = 0; n <= array4.Length - 1; n++)
					{
						if (array4[n].IndexOf("FACE") >= 0)
						{
							buString5.ReadStringValue(array4[n], "FACE=", ref Value);
							int result2 = 0;
							int.TryParse(Value, out result2);
							if (result2 == 4)
							{
								buShapeCut2.planeName = planeBoxNames.Left;
								flag4 = true;
							}
							if (result2 == 2)
							{
								buShapeCut2.planeName = planeBoxNames.Right;
								flag4 = true;
							}
							if (result2 == 0)
							{
								buShapeCut2.planeName = planeBoxNames.Top;
								flag4 = true;
							}
							if (result2 == 1)
							{
								buShapeCut2.planeName = planeBoxNames.Front;
								flag4 = true;
							}
							if (result2 == 3)
							{
								buShapeCut2.planeName = planeBoxNames.Back;
								flag4 = true;
							}
						}
					}
					string[] array5 = StringList[i + 1].Split(' ');
					for (int num4 = 0; num4 <= array5.Length - 1; num4++)
					{
						if (array5[num4].IndexOf("XBAS") >= 0)
						{
							if ((buShapeCut2.planeName == planeBoxNames.Top) | (buShapeCut2.planeName == planeBoxNames.Front) | (buShapeCut2.planeName == planeBoxNames.Back))
							{
								buString5.ReadStringValue(array5[num4], "XBAS", ref buShapeCut2.BasePoint.X, "=");
							}
							if (buShapeCut2.planeName == planeBoxNames.Right)
							{
								buShapeCut2.BasePoint.X = 0.0;
							}
							if (buShapeCut2.planeName == planeBoxNames.Left)
							{
								buShapeCut2.BasePoint.X = Job.Material.Size.Width;
							}
						}
						if (array5[num4].IndexOf("XSON") >= 0)
						{
							if ((buShapeCut2.planeName == planeBoxNames.Top) | (buShapeCut2.planeName == planeBoxNames.Front) | (buShapeCut2.planeName == planeBoxNames.Back))
							{
								double Value2 = 0.0;
								buString5.ReadStringValue(array5[num4], "XSON", ref Value2, "=");
								buShapeCut2.Length = Value2 - buShapeCut2.BasePoint.X;
							}
							if (buShapeCut2.planeName == planeBoxNames.Right)
							{
								buShapeCut2.BasePoint.X = 0.0;
							}
							if (buShapeCut2.planeName == planeBoxNames.Left)
							{
								buShapeCut2.BasePoint.X = Job.Material.Size.Width;
							}
						}
						if (array5[num4].IndexOf("YBAS") >= 0)
						{
							if ((buShapeCut2.planeName == planeBoxNames.Left) | (buShapeCut2.planeName == planeBoxNames.Right) | (buShapeCut2.planeName == planeBoxNames.Top))
							{
								buString5.ReadStringValue(array5[num4], "YBAS", ref buShapeCut2.BasePoint.Y, "=");
							}
							if (buShapeCut2.planeName == planeBoxNames.Back)
							{
								buShapeCut2.BasePoint.Y = 0.0;
							}
							if (buShapeCut2.planeName == planeBoxNames.Front)
							{
								buShapeCut2.BasePoint.Y = Job.Material.Size.Height;
							}
							buShapeCut2.BasePoint.Z = 9.0;
						}
						if (array5[num4].IndexOf("Z=") >= 0)
						{
							double Value3 = 0.0;
							buString5.ReadStringValue(array5[num4], "Z", ref Value3, "=");
							buShapeCut2.Depth = Math.Abs(Value3);
						}
						if (array5[num4].IndexOf("D") >= 0)
						{
							buString5.ReadCharValue(array5[num4], "D", ref buShapeCut2.Diameter);
						}
					}
					buShapeCut2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut2.planeName);
					buShapeCut2.Corner = CornerLocation.RightTop;
					buShapeCut2.Alignment = ObjectAlignment.MiddleCenter;
					clsVar5.shapeCreatePar.Solid = true;
					clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
					clsVar5.shapeCreatePar.SingX = -1.0;
					clsVar5.shapeCreatePar.SingY = -1.0;
					buShape Shape2 = buShapeCut2;
					clsInit.cVector5.CreatebuShape(ref Shape2, clsVar5.shapeCreatePar);
					if (flag4)
					{
						Job.Items.Add(Shape2);
					}
				}
			}
			if (StringList[i].IndexOf("M60") >= 0 && flag2)
			{
				buFile.GCodeRead gCodeRead = new buFile.GCodeRead();
				List<GCodePoint> GCodeList = new List<GCodePoint>();
				buSystem.EntitiesResolution.LnRatio = 0.75;
				buSystem.EntitiesResolution.MinPointCount = 15;
				gCodeRead.OpenGCode(list, ref GCodeList);
				buShapeCut buShapeCut3 = new buShapeCut();
				for (int num5 = 0; num5 <= list.Count - 1; num5++)
				{
					if (list[num5].IndexOf("T") >= 0)
					{
						double Value4 = 0.0;
						buString5.ReadCharValue(list[num5], "T", ref Value4);
						for (int num6 = 0; num6 <= ccVars.Tools[0].Tools.Count - 1; num6++)
						{
							if (ccVars.Tools[0].Tools[num6].Data.No == (int)Value4)
							{
								buShapeCut3.Tool = new ToolBase5(ccVars.Tools[0].Tools[num6]);
								buShapeCut3.SpindleSpeed = buShapeCut3.Tool.CamData.SpindleSpeed;
								toolBase = new ToolBase5(buShapeCut3.Tool);
							}
						}
					}
					if (list[num5].IndexOf("S") >= 0)
					{
						double Value5 = 0.0;
						buString5.ReadCharValue(list[num5], "S", ref Value5);
						if (Value5 >= 100.0)
						{
							buShapeCut3.SpindleSpeed = Value5;
							num3 = Value5;
						}
					}
					if (((list[num5].IndexOf("G01") >= 0) | (list[num5].IndexOf("G1") >= 0)) & (list[num5].IndexOf("X") >= 0) & (list[num5].IndexOf("F") >= 0))
					{
						double Value6 = 0.0;
						buString5.ReadCharValue(list[num5], "F", ref Value6);
						if (Value6 > 100.0)
						{
							buShapeCut3.feedCutting = Value6;
							num = Value6;
						}
					}
					if (((list[num5].IndexOf("G01") >= 0) | (list[num5].IndexOf("G1") >= 0)) & (list[num5].IndexOf("Z") >= 0) & (list[num5].IndexOf("F") >= 0))
					{
						double Value7 = 0.0;
						buString5.ReadCharValue(list[num5], "F", ref Value7);
						if (Value7 > 100.0)
						{
							buShapeCut3.feedPlunge = Value7;
							num2 = Value7;
						}
					}
				}
				if (buShapeCut3.SpindleSpeed == 0.0)
				{
					if (!(num3 > 0.0))
					{
						buShapeCut3.SpindleSpeed = varDrillCNCSettings.TopSpindleSpeed;
					}
					else
					{
						buShapeCut3.SpindleSpeed = num3;
					}
				}
				if (buShapeCut3.feedCutting == 0.0)
				{
					if (!(num > 0.0))
					{
						buShapeCut3.feedCutting = varDrillCNCSettings.MillingFeed;
					}
					else
					{
						buShapeCut3.feedCutting = num;
					}
				}
				if (buShapeCut3.feedPlunge == 0.0)
				{
					if (!(num2 > 0.0))
					{
						buShapeCut3.feedPlunge = varDrillCNCSettings.MillingPlungeFeed;
					}
					else
					{
						buShapeCut3.feedPlunge = num2;
					}
				}
				if (buShapeCut3.Tool == null && toolBase != null)
				{
					buShapeCut3.Tool = new ToolBase5(toolBase);
				}
				list = new List<string>();
				buEntity.eEntityToEyeEntity(gCodeRead.EntitiesG1, ref buShapeCut3.entityWireframe);
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buShapeCut3.entityWireframe, ref MinPoint, ref MidPoint, ref MaxPoint);
				if (buCompare5.EQ(MaxPoint.X - MinPoint.X, 0.0))
				{
					buShapeCut3.CutType = CutTypes.CutVertical;
					buShapeCut3.Length = MaxPoint.Y - MinPoint.Y;
				}
				if (buCompare5.EQ(MaxPoint.Y - MinPoint.Y, 0.0))
				{
					buShapeCut3.CutType = CutTypes.CutHorizontal;
					buShapeCut3.Length = MaxPoint.X - MinPoint.X;
				}
				buShapeCut3.planeName = planeBoxNames.Top;
				buShapeCut3.BasePoint.X = MinPoint.X;
				buShapeCut3.BasePoint.Y = MinPoint.Y;
				buShapeCut3.BasePoint.Z = MinPoint.Z;
				buShapeCut3.Depth = Math.Abs(MinPoint.Z);
				if (buShapeCut3.Tool != null)
				{
					buShapeCut3.Diameter = buShapeCut3.Tool.Geometry.Diameter;
				}
				buShapeCut3.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut3.planeName);
				buShapeCut3.Corner = CornerLocation.RightTop;
				buShapeCut3.Alignment = ObjectAlignment.MiddleCenter;
				buShapeCut3.isMilling = true;
				clsVar5.shapeCreatePar.Solid = true;
				clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
				clsVar5.shapeCreatePar.SingX = -1.0;
				clsVar5.shapeCreatePar.SingY = -1.0;
				buShape Shape3 = buShapeCut3;
				clsInit.cVector5.CreatebuShape(ref Shape3, clsVar5.shapeCreatePar);
				buShapeCut3.entityWireframe.Clear();
				for (int num7 = 0; num7 <= gCodeRead.EntitiesG1.Count - 1; num7++)
				{
					List<Point3D> Points = new List<Point3D>();
					for (int num8 = 0; num8 <= gCodeRead.EntitiesG1[num7].Vertice.Count - 1; num8++)
					{
						Points.Add(new Point3D(0.0 - gCodeRead.EntitiesG1[num7].Vertice[num8].X, 0.0 - gCodeRead.EntitiesG1[num7].Vertice[num8].Y, Job.Material.Size.Depth - buShapeCut3.Depth));
					}
					if (Points.Count >= 2)
					{
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
						buShapeCut3.entityWireframe.Add(new LinearPath(Points));
					}
				}
				Job.Items.Add(Shape3);
			}
			if (StringList[i].IndexOf("M60") >= 0 && !flag2)
			{
				buFile.GCodeRead gCodeRead2 = new buFile.GCodeRead();
				List<GCodePoint> GCodeList2 = new List<GCodePoint>();
				buSystem.EntitiesResolution.LnRatio = 0.75;
				buSystem.EntitiesResolution.MinPointCount = 15;
				gCodeRead2.OpenGCode(list, ref GCodeList2);
				buShapeFreeLines buShapeFreeLines2 = new buShapeFreeLines();
				buShapeFreeLines2.Codes = new List<string>();
				buShapeFreeLines2.Codes.AddRange(list);
				for (int num9 = 0; num9 <= list.Count - 1; num9++)
				{
					if (list[num9].IndexOf("T") >= 0)
					{
						double Value8 = 0.0;
						buString5.ReadCharValue(list[num9], "T", ref Value8);
						for (int num10 = 0; num10 <= ccVars.Tools[0].Tools.Count - 1; num10++)
						{
							if (ccVars.Tools[0].Tools[num10].Data.No == (int)Value8)
							{
								buShapeFreeLines2.Tool = new ToolBase5(ccVars.Tools[0].Tools[num10]);
								toolBase = new ToolBase5(buShapeFreeLines2.Tool);
							}
						}
					}
					if (list[num9].IndexOf("S") >= 0)
					{
						double Value9 = 0.0;
						buString5.ReadCharValue(list[num9], "S", ref Value9);
						if (Value9 >= 100.0)
						{
							buShapeFreeLines2.SpindleSpeed = Value9;
							num3 = Value9;
						}
					}
					if (((list[num9].IndexOf("G01") >= 0) | (list[num9].IndexOf("G1") >= 0)) & (list[num9].IndexOf("X") >= 0) & (list[num9].IndexOf("F") >= 0))
					{
						double Value10 = 0.0;
						buString5.ReadCharValue(list[num9], "F", ref Value10);
						if (Value10 > 100.0)
						{
							buShapeFreeLines2.feedCutting = Value10;
							num = Value10;
						}
					}
					if (((list[num9].IndexOf("G01") >= 0) | (list[num9].IndexOf("G1") >= 0)) & (list[num9].IndexOf("Z") >= 0) & (list[num9].IndexOf("F") >= 0))
					{
						double Value11 = 0.0;
						buString5.ReadCharValue(list[num9], "F", ref Value11);
						if (Value11 > 100.0)
						{
							buShapeFreeLines2.feedPlunge = Value11;
							num2 = Value11;
						}
					}
				}
				if (buShapeFreeLines2.SpindleSpeed == 0.0)
				{
					if (!(num3 > 0.0))
					{
						buShapeFreeLines2.SpindleSpeed = varDrillCNCSettings.TopSpindleSpeed;
					}
					else
					{
						buShapeFreeLines2.SpindleSpeed = num3;
					}
				}
				if (buShapeFreeLines2.feedCutting == 0.0)
				{
					if (!(num > 0.0))
					{
						buShapeFreeLines2.feedCutting = varDrillCNCSettings.MillingFeed;
					}
					else
					{
						buShapeFreeLines2.feedCutting = num;
					}
				}
				if (buShapeFreeLines2.feedPlunge == 0.0)
				{
					if (!(num2 > 0.0))
					{
						buShapeFreeLines2.feedPlunge = varDrillCNCSettings.MillingPlungeFeed;
					}
					else
					{
						buShapeFreeLines2.feedPlunge = num2;
					}
				}
				if (buShapeFreeLines2.Tool == null && toolBase != null)
				{
					buShapeFreeLines2.Tool = new ToolBase5(toolBase);
				}
				buEntity.eEntityToEyeEntity(gCodeRead2.EntitiesG1, ref buShapeFreeLines2.entityWireframe);
				Point3D MinPoint2 = new Point3D();
				Point3D MidPoint2 = new Point3D();
				Point3D MaxPoint2 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buShapeFreeLines2.entityWireframe, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
				if (MaxPoint2.Y - MinPoint2.Y <= 0.1 && buShapeFreeLines2.Tool != null)
				{
					MaxPoint2.Y += buShapeFreeLines2.Tool.Geometry.Diameter / 2.0;
					MinPoint2.Y -= buShapeFreeLines2.Tool.Geometry.Diameter / 2.0;
				}
				if (gCodeRead2.EntitiesG1[0].Vertice[1].Z < Job.Material.Size.Depth)
				{
					buShapeFreeLines2.Depth = Job.Material.Size.Depth - Math.Abs(gCodeRead2.EntitiesG1[0].Vertice[1].Z);
				}
				buShapeFreeLines2.BasePoint = new Point3D(MidPoint2.X, MidPoint2.Y, Job.Material.Size.Depth);
				buShapeFreeLines2.ShapeGroup = ShapeGroup.Shape;
				buShapeFreeLines2.ShapeType = ShapeTypes.FreeLines;
				buShapeFreeLines2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeFreeLines2.planeName);
				buShapeFreeLines2.Corner = CornerLocation.RightTop;
				buShapeFreeLines2.Alignment = ObjectAlignment.MiddleCenter;
				buShapeFreeLines2.planeName = planeBoxNames.Top;
				buShapeFreeLines2.Width = MaxPoint2.X - MinPoint2.X;
				buShapeFreeLines2.Height = MaxPoint2.Y - MinPoint2.Y;
				buShapeFreeLines2.entityWireframe.Clear();
				for (int num11 = 0; num11 <= gCodeRead2.EntitiesG1.Count - 1; num11++)
				{
					List<Point3D> Points2 = new List<Point3D>();
					for (int num12 = 0; num12 <= gCodeRead2.EntitiesG1[num11].Vertice.Count - 1; num12++)
					{
						Points2.Add(new Point3D(0.0 - gCodeRead2.EntitiesG1[num11].Vertice[num12].X, 0.0 - gCodeRead2.EntitiesG1[num11].Vertice[num12].Y, Job.Material.Size.Depth - buShapeFreeLines2.Depth));
					}
					if (Points2.Count >= 2)
					{
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points2);
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points2);
						buShapeFreeLines2.entityWireframe.Add(new LinearPath(Points2));
					}
				}
				clsVar5.shapeCreatePar.Solid = true;
				clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
				clsVar5.shapeCreatePar.SingX = -1.0;
				clsVar5.shapeCreatePar.SingY = -1.0;
				buShape Shape4 = buShapeFreeLines2;
				clsInit.cVector5.CreatebuShape(ref Shape4, clsVar5.shapeCreatePar);
				Job.Items.Add(Shape4);
				flag = false;
				flag2 = false;
			}
			if (flag)
			{
				list.Add(StringList[i]);
			}
			if ((StringList[i].IndexOf("M50") >= 0) | (StringList[i].IndexOf("M51") >= 0) | (StringList[i].IndexOf("M52") >= 0) | (StringList[i].IndexOf("M54") >= 0) | (StringList[i].IndexOf("M55") >= 0))
			{
				list.Clear();
				flag = true;
				flag2 = false;
			}
			if (StringList[i].IndexOf("M53") >= 0)
			{
				list.Clear();
				flag = true;
				flag2 = true;
			}
		}
		double MaterialZeroYPos = 0.0;
		bool flag5 = false;
		if (varDrillRunSettings.CabinetMirrorIfSlotClamperSide)
		{
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			for (int num13 = 0; num13 <= Job.Items.Count - 1; num13++)
			{
				if (Job.Items[num13] is buShapeCut)
				{
					buShapeCut buShapeCut4 = Job.Items[num13] as buShapeCut;
					if (buShapeCut4.BasePoint.Y < varDrillCNCSettings.ClamperCatchWidth)
					{
						flag7 = true;
					}
					if (buShapeCut4.BasePoint.Y > Job.Material.Size.Height - varDrillCNCSettings.ClamperCatchWidth)
					{
						flag8 = true;
					}
				}
				if (Job.Items[num13] is buShapeFreeLines)
				{
					flag6 = true;
				}
			}
			if (flag7 && !flag8 && !flag6)
			{
				flag5 = true;
			}
		}
		if (flag5 && !Preview)
		{
			MirrorOperation(ref Job);
		}
		FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
		if (ClamperEntity != null)
		{
			clsInit.cDrill.CreateClamperEntities(ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
		}
		if (!Preview)
		{
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(Job);
			clsItem.FrmMain.Text = buFile5.getFileName(Filename);
		}
	}

	public void OpenCynClyFile(string Filename, ref DrillJob Job, bool Preview = false)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(Filename);
		foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
		{
			string name = childNode.Name;
			if (!(name == "Panels"))
			{
				continue;
			}
			foreach (XmlNode childNode2 in childNode.ChildNodes)
			{
				string name2 = childNode2.Name;
				if (!(name2 == "Panel"))
				{
					continue;
				}
				Job = new DrillJob();
				foreach (XmlNode childNode3 in childNode2.ChildNodes)
				{
					string name3 = childNode3.Name;
					if (name3 == "Name")
					{
						Job.Name = childNode3.FirstChild.Value;
					}
					if (name3 == "Width" && childNode3.FirstChild.Value != null && buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()))
					{
						Job.Material.Size.Width = double.Parse(childNode3.FirstChild.Value.ToString());
					}
					if (name3 == "Height" && childNode3.FirstChild.Value != null && buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()))
					{
						Job.Material.Size.Height = double.Parse(childNode3.FirstChild.Value.ToString());
					}
					if (name3 == "Thickness" && childNode3.FirstChild.Value != null && buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()))
					{
						Job.Material.Size.Depth = double.Parse(childNode3.FirstChild.Value.ToString());
						Entity Ent = null;
						clsInit.cVector5.CreateMaterialEntities(Job.Material, ref Ent);
						clsInit.cVector5.Move(0.0 - Job.Material.Size.Width, 0.0 - Job.Material.Size.Height, 0.0, ref Ent);
						Job.Material.Entities.Add(Ent);
						Job.panelEntity = Ent;
					}
					if (!(name3 == "Details"))
					{
						continue;
					}
					foreach (XmlNode childNode4 in childNode3.ChildNodes)
					{
						foreach (XmlNode childNode5 in childNode4.ChildNodes)
						{
							if (childNode5.Name.Length > 0)
							{
								buShape shape = null;
								GetCynCltShapeType(childNode5, ref Job, ref shape);
							}
						}
					}
				}
			}
		}
		double MaterialZeroYPos = 0.0;
		FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
		if (ClamperEntity != null)
		{
			clsInit.cDrill.CreateClamperEntities(ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
		}
		if (!Preview)
		{
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(Job);
			clsItem.FrmMain.Text = buFile5.getFileName(Filename);
		}
	}

	public void GetCynCltShapeType(XmlNode Child, ref DrillJob Job, ref buShape shape)
	{
		if (Child == null)
		{
			shape = null;
			return;
		}
		string text = "";
		int num = -1;
		double depth = 0.0;
		double diameter = 0.0;
		Point3D point3D = null;
		Point3D point3D2 = null;
		Point3D point3D3 = null;
		if (Child.Name == "Circle")
		{
			if (Child.ChildNodes == null || Child.ChildNodes.Count <= 0)
			{
				shape = null;
			}
			else
			{
				foreach (XmlNode childNode in Child.ChildNodes)
				{
					string name = childNode.Name;
					if (name == "Face" && childNode.FirstChild.Value != null && buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()))
					{
						num = int.Parse(childNode.FirstChild.Value);
					}
					if (name == "FeatureType" && childNode.FirstChild.Value != null)
					{
						text = childNode.FirstChild.Value.ToString();
					}
					if (name == "Depth" && childNode.FirstChild.Value != null && buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()))
					{
						depth = double.Parse(childNode.FirstChild.Value);
					}
					if (name == "Side" && childNode.FirstChild.Value != null)
					{
						childNode.FirstChild.Value.ToString();
					}
					if (name == "Diameter" && childNode.FirstChild.Value != null && buNumeric5.IsNumeric(childNode.FirstChild.Value.ToString()))
					{
						diameter = double.Parse(childNode.FirstChild.Value);
					}
					if (!(name == "Center") || childNode.Attributes == null || childNode.Attributes.Count <= 0)
					{
						continue;
					}
					point3D = new Point3D();
					for (int i = 0; i <= childNode.Attributes.Count - 1; i++)
					{
						XmlAttribute xmlAttribute = childNode.Attributes[i];
						if (xmlAttribute.Name == "X" && xmlAttribute.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute.FirstChild.Value.ToString()))
						{
							point3D.X = double.Parse(xmlAttribute.FirstChild.Value);
						}
						if (xmlAttribute.Name == "Y" && xmlAttribute.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute.FirstChild.Value.ToString()))
						{
							point3D.Y = double.Parse(xmlAttribute.FirstChild.Value);
						}
					}
				}
				if ((num >= 0) & (text.Length > 0) & (point3D != null))
				{
					if (text == "Hole")
					{
						shape = new buShapeHole();
						shape.planeName = GetCynCltFace(num);
						((buShapeHole)shape).Diameter = diameter;
						((buShapeHole)shape).Depth = depth;
						((buShapeHole)shape).DrillType = drillTypes.SingleHole;
					}
					if (shape.planeName == planeBoxNames.Top)
					{
						shape.BasePoint.X = point3D.X;
						shape.BasePoint.Y = point3D.Y;
						shape.BasePoint.Z = Job.Material.Size.Depth;
					}
					if (shape.planeName == planeBoxNames.Right)
					{
						shape.BasePoint.X = 0.0;
						shape.BasePoint.Y = Job.Material.Size.Height - point3D.X;
						shape.BasePoint.Z = point3D.Y;
					}
					if (shape.planeName == planeBoxNames.Left)
					{
						shape.BasePoint.X = Job.Material.Size.Width;
						shape.BasePoint.Y = point3D.X;
						shape.BasePoint.Z = point3D.Y;
					}
					if (shape.planeName == planeBoxNames.Front)
					{
						shape.BasePoint.X = Job.Material.Size.Width - point3D.X;
						shape.BasePoint.Y = Job.Material.Size.Height;
						shape.BasePoint.Z = point3D.Y;
					}
					if (shape.planeName == planeBoxNames.Back)
					{
						shape.BasePoint.X = point3D.X;
						shape.BasePoint.Y = 0.0;
						shape.BasePoint.Z = point3D.Y;
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
		}
		if (Child.Name == "Rectangle")
		{
			if (Child.ChildNodes == null || Child.ChildNodes.Count <= 0)
			{
				shape = null;
			}
			else
			{
				foreach (XmlNode childNode2 in Child.ChildNodes)
				{
					string name2 = childNode2.Name;
					if (name2 == "Face" && childNode2.FirstChild.Value != null && buNumeric5.IsNumeric(childNode2.FirstChild.Value.ToString()))
					{
						num = int.Parse(childNode2.FirstChild.Value);
					}
					if (name2 == "FlipAxis" && childNode2.FirstChild.Value != null)
					{
						childNode2.FirstChild.Value.ToString();
					}
					if (name2 == "FeatureType" && childNode2.FirstChild.Value != null)
					{
						text = childNode2.FirstChild.Value.ToString();
					}
					if (name2 == "Direction" && childNode2.FirstChild.Value != null)
					{
						childNode2.FirstChild.Value.ToString();
					}
					if (name2 == "Side" && childNode2.FirstChild.Value != null)
					{
						childNode2.FirstChild.Value.ToString();
					}
					if (name2 == "Depth" && childNode2.FirstChild.Value != null && buNumeric5.IsNumeric(childNode2.FirstChild.Value.ToString()))
					{
						depth = double.Parse(childNode2.FirstChild.Value);
					}
					if (name2 == "Diameter" && childNode2.FirstChild.Value != null && buNumeric5.IsNumeric(childNode2.FirstChild.Value.ToString()))
					{
						diameter = double.Parse(childNode2.FirstChild.Value);
					}
					if (name2 == "Start" && childNode2.Attributes != null && childNode2.Attributes.Count > 0)
					{
						point3D2 = new Point3D();
						for (int j = 0; j <= childNode2.Attributes.Count - 1; j++)
						{
							XmlAttribute xmlAttribute2 = childNode2.Attributes[j];
							if (xmlAttribute2.Name == "X" && xmlAttribute2.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute2.FirstChild.Value.ToString()))
							{
								point3D2.X = double.Parse(xmlAttribute2.FirstChild.Value);
							}
							if (xmlAttribute2.Name == "Y" && xmlAttribute2.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute2.FirstChild.Value.ToString()))
							{
								point3D2.Y = double.Parse(xmlAttribute2.FirstChild.Value);
							}
						}
					}
					if (!(name2 == "End") || childNode2.Attributes == null || childNode2.Attributes.Count <= 0)
					{
						continue;
					}
					point3D3 = new Point3D();
					for (int k = 0; k <= childNode2.Attributes.Count - 1; k++)
					{
						XmlAttribute xmlAttribute3 = childNode2.Attributes[k];
						if (xmlAttribute3.Name == "X" && xmlAttribute3.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute3.FirstChild.Value.ToString()))
						{
							point3D3.X = double.Parse(xmlAttribute3.FirstChild.Value);
						}
						if (xmlAttribute3.Name == "Y" && xmlAttribute3.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute3.FirstChild.Value.ToString()))
						{
							point3D3.Y = double.Parse(xmlAttribute3.FirstChild.Value);
						}
					}
				}
				if ((num >= 0) & (text.Length > 0) & (point3D2 != null) & (point3D3 != null))
				{
					if (text == "BladeCut")
					{
						shape = new buShapeCut();
						shape.planeName = GetCynCltFace(num);
						((buShapeCut)shape).Depth = depth;
						((buShapeCut)shape).Length = Math.Abs(point3D2.X - point3D3.X);
						if (point3D3.X < point3D2.X)
						{
							point3D2.X = point3D3.X;
						}
						((buShapeCut)shape).Diameter = Math.Abs(point3D2.Y - point3D3.Y);
						((buShapeCut)shape).isMilling = true;
						point3D2.Y = (point3D2.Y + point3D3.Y) / 2.0;
						for (int l = 0; l <= ccVars.Tools[0].Tools.Count - 1; l++)
						{
							if (buCompare5.EQ(ccVars.Tools[0].Tools[l].Geometry.Diameter, ((buShapeCut)shape).Diameter, 0.1))
							{
								((buShapeCut)shape).Tool = new ToolBase5(ccVars.Tools[0].Tools[l]);
							}
						}
						if (((buShapeCut)shape).Tool == null)
						{
							buString5.MessageBoxError(buLangTranslate.preDef.Error + " - " + buLangTranslate.preDef.Tool);
						}
					}
					if ((text == "Contour") | (text == "Pocket"))
					{
						shape = new buShapeRectangle();
						shape.planeName = GetCynCltFace(num);
						((buShapeRectangle)shape).Depth = depth;
						((buShapeRectangle)shape).Width = Math.Abs(point3D2.X - point3D3.X);
						((buShapeRectangle)shape).Height = Math.Abs(point3D2.Y - point3D3.Y);
						if (text == "Pocket")
						{
							((buShapeRectangle)shape).isPocket = true;
						}
						if (point3D3.X < point3D2.X)
						{
							point3D2.X = point3D3.X;
						}
						point3D2.Y = (point3D2.Y + point3D3.Y) / 2.0;
						point3D2.X = (point3D2.X + point3D3.X) / 2.0;
						((buShapeRectangle)shape).Tool = new ToolBase5(ccVars.Tools[0].Tools[0]);
					}
					if (shape == null)
					{
						buString5.MessageBoxError(buLangTranslate.preDef.Error + " - " + Child.Name + " - " + text);
					}
					else
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
				}
			}
		}
		if (!(Child.Name == "Polyline"))
		{
			return;
		}
		List<buEntity> list = new List<buEntity>();
		if (Child.ChildNodes == null || Child.ChildNodes.Count <= 0)
		{
			shape = null;
			return;
		}
		foreach (XmlNode childNode3 in Child.ChildNodes)
		{
			string name3 = childNode3.Name;
			if (name3 == "Face" && childNode3.FirstChild.Value != null && buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()))
			{
				num = int.Parse(childNode3.FirstChild.Value);
			}
			if (name3 == "FlipAxis" && childNode3.FirstChild.Value != null)
			{
				childNode3.FirstChild.Value.ToString();
			}
			if (name3 == "FeatureType" && childNode3.FirstChild.Value != null)
			{
				text = childNode3.FirstChild.Value.ToString();
			}
			if (name3 == "Side" && childNode3.FirstChild.Value != null)
			{
				childNode3.FirstChild.Value.ToString();
			}
			if (name3 == "Depth" && childNode3.FirstChild.Value != null && buNumeric5.IsNumeric(childNode3.FirstChild.Value.ToString()))
			{
				depth = double.Parse(childNode3.FirstChild.Value);
			}
			if (!(name3 == "Elements"))
			{
				continue;
			}
			foreach (XmlNode childNode4 in childNode3.ChildNodes)
			{
				string name4 = childNode4.Name;
				if (name4 == "Line")
				{
					Point3D point3D4 = null;
					Point3D point3D5 = null;
					foreach (XmlNode childNode5 in childNode4.ChildNodes)
					{
						string name5 = childNode5.Name;
						if (name5 == "Start" && childNode5.Attributes != null && childNode5.Attributes.Count > 0)
						{
							point3D4 = new Point3D();
							for (int m = 0; m <= childNode5.Attributes.Count - 1; m++)
							{
								XmlAttribute xmlAttribute4 = childNode5.Attributes[m];
								if (xmlAttribute4.Name == "X" && xmlAttribute4.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute4.FirstChild.Value.ToString()))
								{
									point3D4.X = double.Parse(xmlAttribute4.FirstChild.Value);
								}
								if (xmlAttribute4.Name == "Y" && xmlAttribute4.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute4.FirstChild.Value.ToString()))
								{
									point3D4.Y = double.Parse(xmlAttribute4.FirstChild.Value);
								}
							}
						}
						if (name5 == "End" && childNode5.Attributes != null && childNode5.Attributes.Count > 0)
						{
							point3D5 = new Point3D();
							for (int n = 0; n <= childNode5.Attributes.Count - 1; n++)
							{
								XmlAttribute xmlAttribute5 = childNode5.Attributes[n];
								if (xmlAttribute5.Name == "X" && xmlAttribute5.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute5.FirstChild.Value.ToString()))
								{
									point3D5.X = double.Parse(xmlAttribute5.FirstChild.Value);
								}
								if (xmlAttribute5.Name == "Y" && xmlAttribute5.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute5.FirstChild.Value.ToString()))
								{
									point3D5.Y = double.Parse(xmlAttribute5.FirstChild.Value);
								}
							}
						}
						if ((point3D4 != null) & (point3D5 != null))
						{
							buLine item = new buLine(point3D4, point3D5);
							list.Add(item);
						}
					}
				}
				if (!(name4 == "Arc"))
				{
					continue;
				}
				Point3D point3D6 = null;
				Point3D point3D7 = null;
				Point3D point3D8 = null;
				foreach (XmlNode childNode6 in childNode4.ChildNodes)
				{
					string name6 = childNode6.Name;
					if (name6 == "Start" && childNode6.Attributes != null && childNode6.Attributes.Count > 0)
					{
						point3D6 = new Point3D();
						for (int num2 = 0; num2 <= childNode6.Attributes.Count - 1; num2++)
						{
							XmlAttribute xmlAttribute6 = childNode6.Attributes[num2];
							if (xmlAttribute6.Name == "X" && xmlAttribute6.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute6.FirstChild.Value.ToString()))
							{
								point3D6.X = double.Parse(xmlAttribute6.FirstChild.Value);
							}
							if (xmlAttribute6.Name == "Y" && xmlAttribute6.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute6.FirstChild.Value.ToString()))
							{
								point3D6.Y = double.Parse(xmlAttribute6.FirstChild.Value);
							}
						}
					}
					if (name6 == "Mid" && childNode6.Attributes != null && childNode6.Attributes.Count > 0)
					{
						point3D7 = new Point3D();
						for (int num3 = 0; num3 <= childNode6.Attributes.Count - 1; num3++)
						{
							XmlAttribute xmlAttribute7 = childNode6.Attributes[num3];
							if (xmlAttribute7.Name == "X" && xmlAttribute7.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute7.FirstChild.Value.ToString()))
							{
								point3D7.X = double.Parse(xmlAttribute7.FirstChild.Value);
							}
							if (xmlAttribute7.Name == "Y" && xmlAttribute7.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute7.FirstChild.Value.ToString()))
							{
								point3D7.Y = double.Parse(xmlAttribute7.FirstChild.Value);
							}
						}
					}
					if (name6 == "End" && childNode6.Attributes != null && childNode6.Attributes.Count > 0)
					{
						point3D8 = new Point3D();
						for (int num4 = 0; num4 <= childNode6.Attributes.Count - 1; num4++)
						{
							XmlAttribute xmlAttribute8 = childNode6.Attributes[num4];
							if (xmlAttribute8.Name == "X" && xmlAttribute8.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute8.FirstChild.Value.ToString()))
							{
								point3D8.X = double.Parse(xmlAttribute8.FirstChild.Value);
							}
							if (xmlAttribute8.Name == "Y" && xmlAttribute8.FirstChild.Value != null && buNumeric5.IsNumeric(xmlAttribute8.FirstChild.Value.ToString()))
							{
								point3D8.Y = double.Parse(xmlAttribute8.FirstChild.Value);
							}
						}
					}
					if ((point3D6 != null) & (point3D8 != null) & (point3D7 != null))
					{
						buArc item2 = new buArc(Plane.XY, point3D6, point3D7, point3D8, flip: false);
						list.Add(item2);
					}
				}
			}
		}
		if (!((num >= 0) & (text.Length > 0) & (list.Count > 0)))
		{
			return;
		}
		if ((text == "Contour") | (text == "Pocket"))
		{
			shape = new buShapeFreeDraw();
			shape.planeName = GetCynCltFace(num);
			((buShapeFreeDraw)shape).Depth = depth;
			if (clsVar5.shapeCreatePar.entitiesCurve == null)
			{
				clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
			}
			clsVar5.shapeCreatePar.entitiesCurve.Clear();
			buEntity.Copy(list, ref clsVar5.shapeCreatePar.entitiesCurve);
			if (text == "Pocket")
			{
				((buShapeFreeDraw)shape).isPocket = true;
			}
			clsInit.cVector5.BoxSizeCalculate(list, ref shape.ItemSize.MinBox, ref shape.ItemSize.MaxBox);
			point3D2 = new Point3D(shape.ItemSize.MinBox.X, shape.ItemSize.MinBox.Y, shape.ItemSize.MinBox.Z);
			((buShapeFreeDraw)shape).Width = shape.ItemSize.MaxBox.X - shape.ItemSize.MinBox.X;
			((buShapeFreeDraw)shape).Height = shape.ItemSize.MaxBox.Y - shape.ItemSize.MinBox.Y;
			((buShapeFreeDraw)shape).Tool = new ToolBase5(ccVars.Tools[0].Tools[0]);
		}
		if (shape == null)
		{
			buString5.MessageBoxError(buLangTranslate.preDef.Error + " - " + Child.Name + " - " + text);
			return;
		}
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

	public planeBoxNames GetCynCltFace(int Face)
	{
		return Face switch
		{
			0 => planeBoxNames.Top, 
			1 => planeBoxNames.Back, 
			2 => planeBoxNames.Left, 
			3 => planeBoxNames.Front, 
			4 => planeBoxNames.Right, 
			5 => planeBoxNames.Top, 
			_ => planeBoxNames.Free, 
		};
	}

	public void OpenCynclyJobListFile(List<string> Filenames, bool AutoFileArrived = false)
	{
		List<InfoCount> list = new List<InfoCount>();
		if (clsItem.FrmProgress == null)
		{
			clsItem.FrmProgress = new F_ProgressCalculation();
		}
		for (int i = 0; i <= Filenames.Count - 1; i++)
		{
			string text = Filenames[i];
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(text);
			string path = buFile5.GetPath(text);
			DirectoryInfo directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathExport);
			if (directoryInfo.Exists)
			{
				if (varDrillRunSettings.CabinetSubFolder)
				{
					directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathExport + "\\" + fileNameWithoutExtension);
					if (!directoryInfo.Exists)
					{
						directoryInfo.Create();
					}
				}
			}
			else
			{
				directoryInfo = new DirectoryInfo(path + "\\" + fileNameWithoutExtension);
				if (directoryInfo.Exists)
				{
					directoryInfo.Delete(recursive: true);
				}
				directoryInfo.Create();
			}
			TreeNode treeNode = null;
			if (AutoFileArrived & FrmCabinetCycle.Visible)
			{
				treeNode = new TreeNode(fileNameWithoutExtension);
			}
			CalculationEventArg calculationEventArg = new CalculationEventArg();
			clsItem.FrmProgress.Visible = true;
			FileInfo fileInfo = new FileInfo(text);
			bool flag = true;
			if (fileInfo.Exists)
			{
				InfoCount item = new InfoCount(1.0, text);
				if (flag)
				{
					list.Add(item);
					fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(fileInfo.FullName);
					activeJob = new DrillJob();
					OpenCynClyFile(fileInfo.FullName, ref activeJob);
					string fileName = directoryInfo.FullName + "\\" + fileNameWithoutExtension;
					cmdShowCode(CreateCode: true, fileName);
				}
			}
			if (AutoFileArrived & fileInfo.Exists)
			{
				if (FrmCabinetCycle.Visible && treeNode != null)
				{
					new TreeNode();
					treeNode.Nodes.Add(text.Trim() + " - ");
				}
				DirectoryInfo directoryInfo2 = new DirectoryInfo(varDrillRunSettings.CabinetpathDeleted);
				if (directoryInfo2.Exists & varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
				{
					buFile5.CopyFileToFolder(fileInfo.FullName, directoryInfo2.FullName);
				}
				fileInfo.Delete();
			}
			calculationEventArg.ActiveProgressPercentage = 100.0 * (double)i / Convert.ToDouble(Filenames.Count - 1);
			calculationEventArg.OverallProgressPercentage = 100.0;
			calculationEventArg.Job = buLangTranslate.preDef.Calculating;
			clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
			clsItem.FrmProgress.Visible = false;
			if ((AutoFileArrived & FrmCabinetCycle.Visible) && treeNode != null)
			{
				FrmCabinetCycle.tree_files.Nodes.Add(treeNode);
			}
			if (((list.Count > 0) & varDrillRunSettings.CabinetShowInfo) && !AutoFileArrived)
			{
				DialogBoxList dialogBoxList = new DialogBoxList();
				List<string> list2 = new List<string>();
				for (int j = 0; j <= list.Count - 1; j++)
				{
					list2.Add(list[j].Info + ";" + list[j].Count.ToString("f0"));
					dialogBoxList.Items.Add(buLangTranslate.preDef.FileName + ": " + list[j].Info + "  " + buLangTranslate.preDef.Count + ": " + list[j].Count.ToString("f0"));
				}
				string fileName2 = directoryInfo.FullName + "\\Info.txt";
				buFile5.SaveToFile(list2, fileName2);
				clsItem.FrmProgress.Visible = false;
				dialogBoxList.Caption = buLangTranslate.preDef.Job;
				dialogBoxList.Init();
				dialogBoxList.ShowDialog();
				clsItem.FrmProgress.Visible = false;
			}
		}
		timCabinetCycle.Enabled = true;
	}

	public void OpenCorpusFile(string Filename, ref DrillJob Job, bool Preview = false)
	{
		varDrillRunSettings.path3DJob = buFile5.GetPath(Filename);
		SaveDrillFile();
		List<Entity> EntityList = new List<Entity>();
		buFile5.OpenDxfDwg(ref EntityList, Filename, "");
		if (EntityList.Count > 0)
		{
			List<Entity> list = new List<Entity>();
			for (int num = EntityList.Count - 1; num >= 0; num--)
			{
				if (EntityList[num].LayerName == "PLYTA")
				{
					list.Add(EntityList[num]);
					EntityList.RemoveAt(num);
				}
			}
			if (list.Count > 0)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				double depth = Math.Abs(list[0].AutodeskProperties.Thickness);
				clsInit.cVector5.BoxSizeCalculate(list, ref MinPoint, ref MaxPoint);
				Job = new DrillJob();
				Job.Material.Size.Width = MaxPoint.X - MinPoint.X;
				Job.Material.Size.Height = MaxPoint.Y - MinPoint.Y;
				Job.Material.Size.Depth = depth;
				Entity Ent = null;
				clsInit.cVector5.CreateMaterialEntities(Job.Material, ref Ent);
				clsInit.cVector5.Move(0.0 - Job.Material.Size.Width, 0.0 - Job.Material.Size.Height, 0.0, ref Ent);
				Ent.Color = Color.FromArgb(150, Ent.Color);
				Job.Material.Entities.Add(Ent);
				Job.panelEntity = Ent;
			}
			for (int i = 0; i <= EntityList.Count - 1; i++)
			{
				string[] array = EntityList[i].LayerName.Split('_');
				if (array == null || array.Length == 0)
				{
					continue;
				}
				if (EntityList[i].BoxMax == null)
				{
					EntityList[i].Regen(0.1);
				}
				double result = 0.0;
				double result2 = 0.0;
				for (int j = 1; j <= array.Length - 1; j++)
				{
					if (array[j].IndexOf("DIAM") >= 0)
					{
						string text = array[j].Trim().Replace("DIAM", "");
						if (buNumeric5.IsNumeric(text))
						{
							double.TryParse(text, out result);
						}
					}
					if (array[j].IndexOf("DIA") >= 0)
					{
						string text2 = array[j].Trim().Replace("DIA", "");
						if (buNumeric5.IsNumeric(text2))
						{
							double.TryParse(text2, out result);
						}
					}
					if (array[j].IndexOf("DEPTH") >= 0)
					{
						string text3 = array[j].Trim().Replace("DEPTH", "");
						if (buNumeric5.IsNumeric(text3))
						{
							double.TryParse(text3, out result2);
						}
					}
				}
				if (!(array[0] == "SAW"))
				{
					if (!(array[0] == "VERT"))
					{
						if (!(array[0] == "HOR"))
						{
							if (!((array[0] == "MILLING") | (array[0] == "FREZOWANIE") | (array[0] == "DRAW")))
							{
								continue;
							}
							int result3 = -1;
							if (array[1].IndexOf("NARZ") >= 0)
							{
								string text4 = array[1].Replace("NARZ", "");
								if (buNumeric5.IsNumeric(text4))
								{
									int.TryParse(text4, out result3);
								}
							}
							if (array[1].IndexOf("TOOL") >= 0)
							{
								string text5 = array[1].Replace("TOOL", "");
								text5 = text5.Replace("T", "");
								if (buNumeric5.IsNumeric(text5))
								{
									int.TryParse(text5, out result3);
								}
							}
							if (array[2].IndexOf("SRED") >= 0)
							{
								string text6 = array[2].Replace("SRED", "");
								if (buNumeric5.IsNumeric(text6))
								{
									double.TryParse(text6, out result);
								}
							}
							if (array[2].IndexOf("DIA") >= 0)
							{
								string text7 = array[2].Replace("DIA", "");
								if (buNumeric5.IsNumeric(text7))
								{
									double.TryParse(text7, out result);
								}
							}
							if (array[2].IndexOf("GLEB") >= 0)
							{
								string text8 = array[2].Replace("GLEB", "");
								if (buNumeric5.IsNumeric(text8))
								{
									double.TryParse(text8, out result2);
								}
							}
							if (array[3].IndexOf("DEPTH") >= 0)
							{
								string text9 = array[3].Replace("DEPTH", "");
								if (buNumeric5.IsNumeric(text9))
								{
									double.TryParse(text9, out result2);
								}
							}
							if (array[3].IndexOf("KOREKCJA") >= 0)
							{
								string text10 = array[3].Replace("KOREKCJA", "");
								if (buNumeric5.IsNumeric(text10))
								{
									int result4 = 0;
									int.TryParse(text10, out result4);
									if (result4 != 0)
									{
									}
									if (result4 != 1)
									{
									}
									if (result4 != 2)
									{
									}
								}
							}
							if (!(((EntityList[i] is LinearPath) & (EntityList[i].Vertices.Length == 2)) | (EntityList[i] is devDept.Eyeshot.Entities.Line)))
							{
								if (!(EntityList[i] is LinearPath))
								{
									continue;
								}
								buShapeFreeLines buShapeFreeLines2 = new buShapeFreeLines();
								for (int k = 0; k <= ccVars.Tools.Count - 1; k++)
								{
									for (int l = 0; l <= ccVars.Tools[k].Tools.Count - 1; l++)
									{
										if (ccVars.Tools[k].Tools[l].Geometry.Diameter == result)
										{
											buShapeFreeLines2.Tool = new ToolBase5(ccVars.Tools[k].Tools[l]);
											buShapeFreeLines2.SpindleSpeed = buShapeFreeLines2.Tool.CamData.SpindleSpeed;
											buShapeFreeLines2.feedCutting = buShapeFreeLines2.Tool.CamData.FeedSpeed;
											buShapeFreeLines2.feedPlunge = buShapeFreeLines2.Tool.CamData.PlungeSpeed;
										}
									}
								}
								if (buShapeFreeLines2.Tool == null)
								{
									buShapeFreeLines2.InfoMessages = new List<string>();
									buShapeFreeLines2.InfoMessages.Add(buLangTranslate.preSentences.OperationToolIsNotInToolList);
								}
								Entity copiedEntity = null;
								buEntity.Copy(EntityList[i], ref copiedEntity);
								buShapeFreeLines2.entityWireframe = new List<Entity>();
								List<Point3D> list2 = new List<Point3D>();
								for (int m = 0; m <= EntityList[i].Vertices.Length - 1; m++)
								{
									list2.Add(new Point3D(EntityList[i].Vertices[m].X, EntityList[i].Vertices[m].Y, Job.Material.Size.Depth - result2));
								}
								if (list2.Count > 0)
								{
									LinearPath item = new LinearPath(list2);
									buShapeFreeLines2.entityWireframe.Add(item);
								}
								Point3D MinPoint2 = new Point3D();
								Point3D MidPoint = new Point3D();
								Point3D MaxPoint2 = new Point3D();
								clsInit.cVector5.BoxSizeCalculate(buShapeFreeLines2.entityWireframe, ref MinPoint2, ref MidPoint, ref MaxPoint2);
								if (MaxPoint2.Y - MinPoint2.Y <= 0.1 && buShapeFreeLines2.Tool != null)
								{
									MaxPoint2.Y += buShapeFreeLines2.Tool.Geometry.Diameter / 2.0;
									MinPoint2.Y -= buShapeFreeLines2.Tool.Geometry.Diameter / 2.0;
								}
								buShapeFreeLines2.Depth = result2;
								buShapeFreeLines2.BasePoint = new Point3D(MidPoint.X, MidPoint.Y, Job.Material.Size.Depth);
								buShapeFreeLines2.ShapeGroup = ShapeGroup.Shape;
								buShapeFreeLines2.ShapeType = ShapeTypes.FreeLines;
								buShapeFreeLines2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeFreeLines2.planeName);
								buShapeFreeLines2.Corner = CornerLocation.RightTop;
								buShapeFreeLines2.Alignment = ObjectAlignment.MiddleCenter;
								buShapeFreeLines2.planeName = planeBoxNames.Top;
								buShapeFreeLines2.Width = MaxPoint2.X - MinPoint2.X;
								buShapeFreeLines2.Height = MaxPoint2.Y - MinPoint2.Y;
								list2 = new List<Point3D>();
								for (int n = 0; n <= EntityList[i].Vertices.Length - 1; n++)
								{
									list2.Add(new Point3D(0.0 - EntityList[i].Vertices[n].X, 0.0 - EntityList[i].Vertices[n].Y, Job.Material.Size.Depth - result2));
								}
								buShapeFreeLines2.entityWireframe = new List<Entity>();
								if (list2.Count > 0)
								{
									LinearPath item2 = new LinearPath(list2);
									buShapeFreeLines2.entityWireframe.Add(item2);
								}
								clsVar5.shapeCreatePar.Solid = true;
								clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
								clsVar5.shapeCreatePar.SingX = -1.0;
								clsVar5.shapeCreatePar.SingY = -1.0;
								buShape Shape = buShapeFreeLines2;
								clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
								Job.Items.Add(Shape);
							}
							else
							{
								if (!(result > 0.0))
								{
									continue;
								}
								double num2 = 0.0;
								double num3 = 0.0;
								double angle = 0.0;
								if (!buCompare5.EQ(EntityList[i].Vertices[0].X, EntityList[i].Vertices[1].X))
								{
									if (!buCompare5.EQ(EntityList[i].Vertices[0].Y, EntityList[i].Vertices[1].Y))
									{
										num2 = EntityList[i].Vertices[0].X;
										num3 = EntityList[i].Vertices[0].Y;
										angle = clsInit.cVector5.PointAngle(EntityList[i].Vertices[1], EntityList[i].Vertices[0]);
									}
									else if (!(EntityList[i].Vertices[0].X < EntityList[i].Vertices[1].X))
									{
										num2 = EntityList[i].Vertices[1].X;
										num3 = EntityList[i].Vertices[1].Y;
									}
									else
									{
										num2 = EntityList[i].Vertices[0].X;
										num3 = EntityList[i].Vertices[0].Y;
									}
								}
								else if (!(EntityList[i].Vertices[0].Y < EntityList[i].Vertices[1].Y))
								{
									num2 = EntityList[i].Vertices[1].X;
									num3 = EntityList[i].Vertices[1].Y;
								}
								else
								{
									num2 = EntityList[i].Vertices[0].X;
									num3 = EntityList[i].Vertices[0].Y;
								}
								buShapeCut buShapeCut2 = new buShapeCut();
								buShapeCut2.planeName = planeBoxNames.Top;
								buShapeCut2.isMilling = true;
								buShapeCut2.Diameter = result;
								buShapeCut2.BasePoint.X = num2;
								buShapeCut2.BasePoint.Y = num3;
								buShapeCut2.BasePoint.Z = Job.Material.Size.Depth - result2;
								buShapeCut2.Length = clsInit.cVector5.Length3D(EntityList[i].Vertices[0], EntityList[i].Vertices[1]);
								buShapeCut2.Angle = angle;
								buShapeCut2.Corner = CornerLocation.RightTop;
								buShapeCut2.Alignment = ObjectAlignment.MiddleCenter;
								clsVar5.shapeCreatePar.Solid = true;
								clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
								clsVar5.shapeCreatePar.SingX = -1.0;
								clsVar5.shapeCreatePar.SingY = -1.0;
								buShape Shape2 = buShapeCut2;
								clsInit.cVector5.CreatebuShape(ref Shape2, clsVar5.shapeCreatePar);
								for (int num4 = 0; num4 <= ccVars.Tools.Count - 1; num4++)
								{
									for (int num5 = 0; num5 <= ccVars.Tools[num4].Tools.Count - 1; num5++)
									{
										if (ccVars.Tools[num4].Tools[num5].Geometry.Diameter == buShapeCut2.Diameter)
										{
											buShapeCut2.Tool = new ToolBase5(ccVars.Tools[num4].Tools[num5]);
										}
									}
								}
								Job.Items.Add(Shape2);
							}
						}
						else if (!(array[1] == "RIGHT"))
						{
							if (!(array[1] == "LEFT"))
							{
								if (!(array[1] == "FRONT"))
								{
									if (((array[1] == "BACK") | (array[1] == "REAR")) && EntityList[i] is Circle && result > 0.0)
									{
										Circle circle = EntityList[i] as Circle;
										buShapeHole buShapeHole4 = new buShapeHole();
										buShapeHole4.isMilling = false;
										buShapeHole4.planeName = planeBoxNames.Back;
										buShapeHole4.Diameter = circle.Diameter;
										buShapeHole4.Depth = result2;
										buShapeHole4.BasePoint.X = circle.Center.X;
										buShapeHole4.BasePoint.Y = 0.0;
										buShapeHole4.BasePoint.Z = Math.Abs(circle.Center.Z);
										buShapeHole4.Corner = CornerLocation.RightTop;
										buShapeHole4.Alignment = ObjectAlignment.MiddleCenter;
										buShapeHole4.DrillType = drillTypes.SingleHole;
										buShapeHole4.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole4.planeName);
										clsVar5.shapeCreatePar.Solid = true;
										clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
										clsVar5.shapeCreatePar.SingX = -1.0;
										clsVar5.shapeCreatePar.SingY = -1.0;
										buShape Shape3 = buShapeHole4;
										clsInit.cVector5.CreatebuShape(ref Shape3, clsVar5.shapeCreatePar);
										Job.Items.Add(Shape3);
									}
								}
								else if (EntityList[i] is Circle && result > 0.0)
								{
									Circle circle2 = EntityList[i] as Circle;
									buShapeHole buShapeHole5 = new buShapeHole();
									buShapeHole5.isMilling = false;
									buShapeHole5.planeName = planeBoxNames.Front;
									buShapeHole5.Diameter = circle2.Diameter;
									buShapeHole5.Depth = result2;
									buShapeHole5.BasePoint.X = circle2.Center.X;
									buShapeHole5.BasePoint.Y = Job.Material.Size.Height;
									buShapeHole5.BasePoint.Z = Math.Abs(circle2.Center.Z);
									buShapeHole5.Corner = CornerLocation.RightTop;
									buShapeHole5.Alignment = ObjectAlignment.MiddleCenter;
									buShapeHole5.DrillType = drillTypes.SingleHole;
									buShapeHole5.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole5.planeName);
									clsVar5.shapeCreatePar.Solid = true;
									clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
									clsVar5.shapeCreatePar.SingX = -1.0;
									clsVar5.shapeCreatePar.SingY = -1.0;
									buShape Shape4 = buShapeHole5;
									clsInit.cVector5.CreatebuShape(ref Shape4, clsVar5.shapeCreatePar);
									Job.Items.Add(Shape4);
								}
							}
							else if (EntityList[i] is Circle && result > 0.0)
							{
								Circle circle3 = EntityList[i] as Circle;
								buShapeHole buShapeHole6 = new buShapeHole();
								buShapeHole6.isMilling = false;
								buShapeHole6.planeName = planeBoxNames.Right;
								buShapeHole6.Diameter = circle3.Diameter;
								buShapeHole6.Depth = result2;
								buShapeHole6.BasePoint.X = 0.0;
								buShapeHole6.BasePoint.Y = circle3.Center.Y;
								buShapeHole6.BasePoint.Z = Math.Abs(circle3.Center.Z);
								buShapeHole6.Corner = CornerLocation.RightTop;
								buShapeHole6.Alignment = ObjectAlignment.MiddleCenter;
								buShapeHole6.DrillType = drillTypes.SingleHole;
								buShapeHole6.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole6.planeName);
								clsVar5.shapeCreatePar.Solid = true;
								clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
								clsVar5.shapeCreatePar.SingX = -1.0;
								clsVar5.shapeCreatePar.SingY = -1.0;
								buShape Shape5 = buShapeHole6;
								clsInit.cVector5.CreatebuShape(ref Shape5, clsVar5.shapeCreatePar);
								Job.Items.Add(Shape5);
							}
						}
						else if (EntityList[i] is Circle && result > 0.0)
						{
							Circle circle4 = EntityList[i] as Circle;
							buShapeHole buShapeHole7 = new buShapeHole();
							buShapeHole7.isMilling = false;
							buShapeHole7.planeName = planeBoxNames.Left;
							buShapeHole7.Diameter = circle4.Diameter;
							buShapeHole7.Depth = result2;
							buShapeHole7.BasePoint.X = Job.Material.Size.Width;
							buShapeHole7.BasePoint.Y = circle4.Center.Y;
							buShapeHole7.BasePoint.Z = Math.Abs(circle4.Center.Z);
							buShapeHole7.Corner = CornerLocation.RightBottom;
							buShapeHole7.Alignment = ObjectAlignment.MiddleCenter;
							buShapeHole7.DrillType = drillTypes.SingleHole;
							buShapeHole7.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole7.planeName);
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape6 = buShapeHole7;
							clsInit.cVector5.CreatebuShape(ref Shape6, clsVar5.shapeCreatePar);
							Job.Items.Add(Shape6);
						}
					}
					else if (EntityList[i] is Circle && result > 0.0)
					{
						Circle circle5 = EntityList[i] as Circle;
						buShapeHole buShapeHole8 = new buShapeHole();
						buShapeHole8.isMilling = false;
						buShapeHole8.planeName = planeBoxNames.Top;
						buShapeHole8.Diameter = circle5.Diameter;
						buShapeHole8.Depth = result2;
						buShapeHole8.BasePoint.X = circle5.Center.X;
						buShapeHole8.BasePoint.Y = circle5.Center.Y;
						buShapeHole8.BasePoint.Z = Job.Material.Size.Depth - result2;
						buShapeHole8.Corner = CornerLocation.RightTop;
						buShapeHole8.Alignment = ObjectAlignment.MiddleCenter;
						buShapeHole8.DrillType = drillTypes.SingleHole;
						buShapeHole8.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeHole8.planeName);
						clsVar5.shapeCreatePar.Solid = true;
						clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
						clsVar5.shapeCreatePar.SingX = -1.0;
						clsVar5.shapeCreatePar.SingY = -1.0;
						buShape Shape7 = buShapeHole8;
						clsInit.cVector5.CreatebuShape(ref Shape7, clsVar5.shapeCreatePar);
						Job.Items.Add(Shape7);
					}
				}
				else if (result > 0.0)
				{
					buShapeCut buShapeCut3 = new buShapeCut();
					buShapeCut3.planeName = planeBoxNames.Top;
					buShapeCut3.Diameter = result;
					buShapeCut3.BasePoint.X = EntityList[i].BoxMin.X;
					buShapeCut3.BasePoint.Y = (EntityList[i].BoxMin.Y + EntityList[i].BoxMax.Y) / 2.0;
					buShapeCut3.BasePoint.Z = Job.Material.Size.Depth - result2;
					buShapeCut3.Length = EntityList[i].BoxMax.X - EntityList[i].BoxMin.X;
					buShapeCut3.Depth = result2;
					buShapeCut3.Corner = CornerLocation.RightTop;
					buShapeCut3.Alignment = ObjectAlignment.MiddleCenter;
					buShapeCut3.isMilling = false;
					clsVar5.shapeCreatePar.Solid = true;
					clsVar5.shapeCreatePar.Size = new SizeObject(Job.Material.Size);
					clsVar5.shapeCreatePar.SingX = -1.0;
					clsVar5.shapeCreatePar.SingY = -1.0;
					buShape Shape8 = buShapeCut3;
					clsInit.cVector5.CreatebuShape(ref Shape8, clsVar5.shapeCreatePar);
					Job.Items.Add(Shape8);
				}
			}
		}
		double MaterialZeroYPos = 0.0;
		bool flag = false;
		if (varDrillRunSettings.CabinetMirrorIfSlotClamperSide)
		{
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			for (int num6 = 0; num6 <= Job.Items.Count - 1; num6++)
			{
				if (Job.Items[num6] is buShapeCut)
				{
					buShapeCut buShapeCut4 = Job.Items[num6] as buShapeCut;
					if (buShapeCut4.BasePoint.Y < varDrillCNCSettings.ClamperCatchWidth)
					{
						flag3 = true;
					}
					if (buShapeCut4.BasePoint.Y > Job.Material.Size.Height - varDrillCNCSettings.ClamperCatchWidth)
					{
						flag4 = true;
					}
				}
				if (Job.Items[num6] is buShapeFreeLines)
				{
					flag2 = true;
				}
			}
			if (flag3 && !flag4 && !flag2)
			{
				flag = true;
			}
		}
		if (flag && !Preview)
		{
			MirrorOperation(ref Job);
		}
		FindFirstClamperPositionsFromFullJob(Job, ref MaterialZeroYPos, ref Job.FirstClamperX, ref Job.SecondClamperX);
		if (ClamperEntity != null)
		{
			clsInit.cDrill.CreateClamperEntities(ClamperEntity, Job.FirstClamperX, Job.SecondClamperX, ref Job.FirstClamperEntity, ref Job.SecondClamperEntity, Color.Gray);
		}
		if (!Preview)
		{
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(Job);
			clsItem.FrmMain.Text = buFile5.getFileName(Filename);
		}
	}

	public void OpenCorpusJobListFile(List<string> Filenames, bool AutoFileArrived = false)
	{
		List<InfoCount> list = new List<InfoCount>();
		if (clsItem.FrmProgress == null)
		{
			clsItem.FrmProgress = new F_ProgressCalculation();
		}
		for (int i = 0; i <= Filenames.Count - 1; i++)
		{
			string text = Filenames[i];
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(text);
			string path = buFile5.GetPath(text);
			DirectoryInfo directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathExport);
			if (directoryInfo.Exists)
			{
				if (varDrillRunSettings.CabinetSubFolder)
				{
					directoryInfo = new DirectoryInfo(varDrillRunSettings.CabinetpathExport + "\\" + fileNameWithoutExtension);
					if (!directoryInfo.Exists)
					{
						directoryInfo.Create();
					}
				}
			}
			else
			{
				directoryInfo = new DirectoryInfo(path + "\\" + fileNameWithoutExtension);
				if (directoryInfo.Exists)
				{
					directoryInfo.Delete(recursive: true);
				}
				directoryInfo.Create();
			}
			TreeNode treeNode = null;
			if (AutoFileArrived & FrmCabinetCycle.Visible)
			{
				treeNode = new TreeNode(fileNameWithoutExtension);
			}
			CalculationEventArg calculationEventArg = new CalculationEventArg();
			clsItem.FrmProgress.Visible = true;
			FileInfo fileInfo = new FileInfo(text);
			bool flag = true;
			if (fileInfo.Exists)
			{
				InfoCount item = new InfoCount(1.0, text);
				if (flag)
				{
					list.Add(item);
					fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(fileInfo.FullName);
					activeJob = new DrillJob();
					OpenCorpusFile(fileInfo.FullName, ref activeJob);
					string fileName = directoryInfo.FullName + "\\" + fileNameWithoutExtension;
					cmdShowCode(CreateCode: true, fileName);
				}
			}
			if (AutoFileArrived & fileInfo.Exists)
			{
				if (FrmCabinetCycle.Visible && treeNode != null)
				{
					new TreeNode();
					treeNode.Nodes.Add(text.Trim() + " - ");
				}
				DirectoryInfo directoryInfo2 = new DirectoryInfo(varDrillRunSettings.CabinetpathDeleted);
				if (directoryInfo2.Exists & varDrillRunSettings.CabinetAutoCycleDeleteAndMove)
				{
					buFile5.CopyFileToFolder(fileInfo.FullName, directoryInfo2.FullName);
				}
				fileInfo.Delete();
			}
			calculationEventArg.ActiveProgressPercentage = 100.0 * (double)i / Convert.ToDouble(Filenames.Count - 1);
			calculationEventArg.OverallProgressPercentage = 100.0;
			calculationEventArg.Job = buLangTranslate.preDef.Calculating;
			clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
			clsItem.FrmProgress.Visible = false;
			if ((AutoFileArrived & FrmCabinetCycle.Visible) && treeNode != null)
			{
				FrmCabinetCycle.tree_files.Nodes.Add(treeNode);
			}
			if (((list.Count > 0) & varDrillRunSettings.CabinetShowInfo) && !AutoFileArrived)
			{
				DialogBoxList dialogBoxList = new DialogBoxList();
				List<string> list2 = new List<string>();
				for (int j = 0; j <= list.Count - 1; j++)
				{
					list2.Add(list[j].Info + ";" + list[j].Count.ToString("f0"));
					dialogBoxList.Items.Add(buLangTranslate.preDef.FileName + ": " + list[j].Info + "  " + buLangTranslate.preDef.Count + ": " + list[j].Count.ToString("f0"));
				}
				string fileName2 = directoryInfo.FullName + "\\Info.txt";
				buFile5.SaveToFile(list2, fileName2);
				clsItem.FrmProgress.Visible = false;
				dialogBoxList.Caption = buLangTranslate.preDef.Job;
				dialogBoxList.Init();
				dialogBoxList.ShowDialog();
				clsItem.FrmProgress.Visible = false;
			}
		}
		timCabinetCycle.Enabled = true;
	}

	public void SetPreviewImage()
	{
		clsItem.ModelOpenPreview.Invalidate();
		clsItem.ModelOpenPreview.Entities.RegenAllCurved(0.01);
		clsItem.ModelOpenPreview.SetView(buConversion5.buViewTypeToEyeViewType(openDialogCtrlPreview.ViewType), fit: true, animate: false);
		clsItem.ModelOpenPreview.ZoomFit(5);
		clsItem.ModelOpenPreview.Invalidate();
		clsItem.ModelOpenPreview.CopyToClipboardRaster(new Size(openDialogCtrlPreview.picture_preview.Width, openDialogCtrlPreview.picture_preview.Height));
		Image image = Clipboard.GetImage();
		openDialogCtrlPreview.DrawPreviewImage(image);
		openDialogCtrlPreview.ShowLoading(Show: false);
		clsVar.PreviewLoaded = true;
	}

	public List<DrillItem> SortByXDistance(List<DrillItem> lst, DrillItem refPoint, SortDirection Direction)
	{
		List<DrillItem> list = new List<DrillItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestXPoint(new DrillItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestXPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestXPoint(DrillItem srcPt, List<DrillItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.Center.X - lookIn[i].Center.X;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillItem> SortByXOffsetedDistance(List<DrillItem> lst, DrillItem refPoint, SortDirection Direction)
	{
		List<DrillItem> list = new List<DrillItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestXOffsetedPoint(new DrillItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestXOffsetedPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestXOffsetedPoint(DrillItem srcPt, List<DrillItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.OffsetedPoint.X - lookIn[i].OffsetedPoint.X;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillItem> SortByYDistance(List<DrillItem> lst, DrillItem refPoint, SortDirection Direction)
	{
		List<DrillItem> list = new List<DrillItem>();
		list.Add(lst[NearestYPoint(new DrillItem(refPoint), lst)]);
		lst.Remove(list[0]);
		int num = 0;
		for (int i = 0; i < lst.Count + num; i++)
		{
			list.Add(lst[NearestYPoint(list[list.Count - 1], lst)]);
			lst.Remove(list[list.Count - 1]);
			num++;
		}
		if (Direction == SortDirection.LowerToBigger)
		{
			list.Reverse();
		}
		return list;
	}

	public int NearestYPoint(DrillItem srcPt, List<DrillItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.Center.Y - lookIn[i].Center.Y;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillItem> SortByZDistance(List<DrillItem> lst, DrillItem refPoint, SortDirection Direction)
	{
		List<DrillItem> list = new List<DrillItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestZPoint(new DrillItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestZPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestZPoint(DrillItem srcPt, List<DrillItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.Center.Z - lookIn[i].Center.Z;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillCalcItem> SortByXDistance(List<DrillCalcItem> lst, DrillCalcItem refPoint, SortDirection Direction)
	{
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestXPoint(new DrillCalcItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestXPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestXPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.Center.X - lookIn[i].Center.X;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillCalcItem> SortByXOffsetedDistance(List<DrillCalcItem> lst, DrillCalcItem refPoint, SortDirection Direction)
	{
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestXOffsetedPoint(new DrillCalcItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestXOffsetedPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestXOffsetedPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.OffsetedPoint.X - lookIn[i].OffsetedPoint.X;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillFound> SortByXOffsetedDistanceDrillFound(List<DrillFound> lst, DrillCalcItem refPoint, SortDirection Direction)
	{
		List<DrillFound> list = new List<DrillFound>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestXOffsetedPointDrillFound(new DrillCalcItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestXOffsetedPointDrillFound(list[list.Count - 1].Items[0], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestXOffsetedPointDrillFound(DrillCalcItem srcPt, List<DrillFound> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.OffsetedPoint.X - lookIn[i].Items[0].OffsetedPoint.X;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillItem> SortShapeByXDistance(List<DrillItem> lst, DrillItem refPoint, SortDirection Direction)
	{
		List<DrillItem> list = new List<DrillItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestShapeXPoint(new DrillItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestShapeXPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestShapeXPoint(DrillItem srcPt, List<DrillItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.BoxMinItem.X - lookIn[i].BoxMinItem.X;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillCalcItem> SortByYDistance(List<DrillCalcItem> lst, DrillCalcItem refPoint, SortDirection Direction)
	{
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestYPoint(new DrillCalcItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestYPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestYPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.Center.Y - lookIn[i].Center.Y;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public List<DrillCalcItem> SortByZDistance(List<DrillCalcItem> lst, DrillCalcItem refPoint, SortDirection Direction)
	{
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		if (lst.Count > 0)
		{
			list.Add(lst[NearestZPoint(new DrillCalcItem(refPoint), lst)]);
			lst.Remove(list[0]);
			int num = 0;
			for (int i = 0; i < lst.Count + num; i++)
			{
				list.Add(lst[NearestZPoint(list[list.Count - 1], lst)]);
				lst.Remove(list[list.Count - 1]);
				num++;
			}
			if (Direction == SortDirection.LowerToBigger)
			{
				list.Reverse();
			}
		}
		return list;
	}

	public int NearestZPoint(DrillCalcItem srcPt, List<DrillCalcItem> lookIn)
	{
		KeyValuePair<double, int> keyValuePair = default(KeyValuePair<double, int>);
		for (int i = 0; i < lookIn.Count; i++)
		{
			double num = srcPt.Center.Z - lookIn[i].Center.Z;
			if (i != 0)
			{
				if (num < keyValuePair.Key)
				{
					keyValuePair = new KeyValuePair<double, int>(num, i);
				}
			}
			else
			{
				keyValuePair = new KeyValuePair<double, int>(num, i);
			}
		}
		return keyValuePair.Value;
	}

	public void SortJobItems(ref DrillJob Job)
	{
		List<List<DrillCalcItem>> list = new List<List<DrillCalcItem>>();
		List<DrillCalcItem> list2 = new List<DrillCalcItem>();
		if (Job == null)
		{
			return;
		}
		Job.ItemCalc = SortByXDistance(Job.ItemCalc, new DrillCalcItem(), SortDirection.LowerToBigger);
		for (int i = 0; i <= Job.ItemCalc.Count - 1; i++)
		{
			Job.ItemCalc[i].NumberNextHorizontalItem = 0;
			Job.ItemCalc[i].NumberNextVerticalItem = 0;
			if (list2.Count != 0)
			{
				if (!buCompare5.EQ(list2[list2.Count - 1].Center.X, Job.ItemCalc[i].Center.X, 0.01))
				{
					list.Add(list2);
					list2 = new List<DrillCalcItem>();
					list2.Add(Job.ItemCalc[i]);
				}
				else
				{
					list2.Add(Job.ItemCalc[i]);
				}
			}
			else
			{
				list2.Add(new DrillCalcItem(Job.ItemCalc[i]));
			}
		}
		if (list2.Count > 0)
		{
			list.Add(list2);
		}
		for (int j = 0; j <= list.Count - 1; j++)
		{
			list[j] = SortByYDistance(list[j], new DrillCalcItem(), SortDirection.LowerToBigger);
		}
		List<double> list3 = new List<double> { 32.0, 64.0, 96.0, 128.0, 160.0 };
		List<double> list4 = new List<double> { 32.0, 64.0, 128.0, 160.0, 192.0 };
		for (int k = 0; k <= list.Count - 1; k++)
		{
			if (list[k].Count >= 2)
			{
				for (int l = 0; l <= list[k].Count - 2; l++)
				{
					for (int m = l + 1; m <= list[k].Count - 1; m++)
					{
						double value = list[k][m].Center.Y - list[k][l].Center.Y;
						for (int n = 0; n <= list3.Count - 1; n++)
						{
							if (buCompare5.EQ(value, list3[n], 0.05))
							{
								list[k][l].NumberNextHorizontalItem++;
								int Index = -1;
								GetIndexFromItemID(list[k][l].ID, Job.ItemCalc, ref Index);
								if (Index >= 0)
								{
									Job.ItemCalc[Index].NumberNextHorizontalItem = list[k][l].NumberNextHorizontalItem;
								}
								n = list3.Count;
							}
						}
					}
				}
			}
			for (int num = 0; num <= list[k].Count - 1; num++)
			{
				for (int num2 = 0; num2 <= Job.ItemCalc.Count - 1; num2++)
				{
					if (Job.ItemCalc[num2].NumberNextHorizontalItem != 0 || !(buCompare5.EQ(list[k][num].Center.Y, Job.ItemCalc[num2].Center.Y, 0.05) & (list[k][num].planeName == Job.ItemCalc[num2].planeName)))
					{
						continue;
					}
					double value2 = Job.ItemCalc[num2].Center.X - list[k][num].Center.X;
					for (int num3 = 0; num3 <= list4.Count - 1; num3++)
					{
						if (buCompare5.EQ(value2, list4[num3], 0.05))
						{
							list[k][num].NumberNextVerticalItem++;
							int Index2 = -1;
							GetIndexFromItemID(list[k][num].ID, Job.ItemCalc, ref Index2);
							if (Index2 >= 0)
							{
								Job.ItemCalc[Index2].NumberNextVerticalItem = list[k][num].NumberNextVerticalItem;
							}
							num3 = list4.Count;
						}
					}
				}
			}
		}
	}

	public void JobShapeToItemCalc(ref DrillJob Job)
	{
		if (Job == null)
		{
			return;
		}
		Job.ItemCalc.Clear();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (Job.Items[i] is buShapeHole)
			{
				buShapeHole buShapeHole4 = Job.Items[i] as buShapeHole;
				if (buShapeHole4.Enable)
				{
					if (buShapeHole4.planeName == planeBoxNames.Back)
					{
						Job.isClamperSideDrillOpAvailable = true;
					}
					if (buShapeHole4.DrillType == drillTypes.SingleHole)
					{
						if (buShapeHole4.isMilling)
						{
							DrillItem item = new DrillItem((buShapeHole)Job.Items[i]);
							Job.ItemCalc.Add(new DrillCalcItem(item));
						}
						else
						{
							Job.ItemCalc.Add(new DrillCalcItem(buShapeHole4));
							Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
							if (Job.Items[i].BasePoint.Y < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
							{
								Job.isClamperSideDrillOpAvailable = true;
							}
							IDCounter++;
						}
					}
					if ((buShapeHole4.DrillType == drillTypes.HorizontalHoles) | (buShapeHole4.DrillType == drillTypes.HorizontalLineHoles) | (buShapeHole4.DrillType == drillTypes.VerticalHoles) | (buShapeHole4.DrillType == drillTypes.VerticalLineHoles) | (buShapeHole4.DrillType == drillTypes.InclineHoles))
					{
						if (buShapeHole4.isMilling)
						{
							for (int j = 0; j <= buShapeHole4.multiCenter.Count - 1; j++)
							{
								buShapeHole buShapeHole5 = new buShapeHole(buShapeHole4.Diameter, buShapeHole4.Depth);
								buShapeHole5.CalculatedPoint = new Point3D(buShapeHole4.multiCenter[j].Center.X, buShapeHole4.multiCenter[j].Center.Y, buShapeHole4.multiCenter[j].Center.Z);
								buShapeHole5.ItemSize.MinBox = new Point3D(buShapeHole4.multiCenter[j].Center.X - buShapeHole4.Diameter / 2.0, buShapeHole4.multiCenter[j].Center.Y - buShapeHole4.Diameter / 2.0);
								buShapeHole5.ItemSize.MaxBox = new Point3D(buShapeHole4.multiCenter[j].Center.X + buShapeHole4.Diameter / 2.0, buShapeHole4.multiCenter[j].Center.Y + buShapeHole4.Diameter / 2.0);
								buShapeHole5.planeName = buShapeHole4.planeName;
								Job.ItemCalc.Add(new DrillCalcItem(buShapeHole5));
							}
						}
						else
						{
							for (int k = 0; k <= buShapeHole4.multiCenter.Count - 1; k++)
							{
								buShapeHole buShapeHole6 = new buShapeHole(buShapeHole4.Diameter, buShapeHole4.Depth);
								buShapeHole6.CalculatedPoint = new Point3D(buShapeHole4.multiCenter[k].Center.X, buShapeHole4.multiCenter[k].Center.Y, buShapeHole4.multiCenter[k].Center.Z);
								buShapeHole6.planeName = buShapeHole4.planeName;
								buShapeHole6.ID = IDCounter;
								Job.ItemCalc.Add(new DrillCalcItem(buShapeHole6));
								Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
								if (Math.Abs(buShapeHole4.multiCenter[k].Center.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
								{
									Job.isClamperSideDrillOpAvailable = true;
								}
								IDCounter++;
							}
						}
					}
					if (buShapeHole4.DrillType == drillTypes.ThreeHole)
					{
						buShapeHole3 buShapeHole7 = Job.Items[i] as buShapeHole3;
						Point3D calcCenter = new Point3D();
						Point3D calcCenter2 = new Point3D();
						clsInit.cVector5.calcBuShapeHole3Point(buShapeHole7.CalculatedPoint, buShapeHole7.planeName, buShapeHole7.DistanceX, buShapeHole7.DistanceY, buShapeHole7.DiameterOutside, buShapeHole7.Hole3Angle, ref calcCenter, ref calcCenter2);
						buShapeHole buShapeHole8 = new buShapeHole(buShapeHole7.Diameter, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(buShapeHole4.CalculatedPoint.X, buShapeHole4.CalculatedPoint.Y, buShapeHole4.CalculatedPoint.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
						buShapeHole8 = new buShapeHole(buShapeHole7.DiameterOutside, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(calcCenter.X, calcCenter.Y, calcCenter.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
						buShapeHole8 = new buShapeHole(buShapeHole7.DiameterOutside, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
					}
				}
			}
			if ((Job.Items[i].ShapeGroup == ShapeGroup.Shape) & Job.Items[i].Enable)
			{
			}
		}
	}

	public bool FindFirstClamperPositionsFromFullJob(DrillJob Job, ref double MaterialZeroYPos, ref double X1, ref double X2, bool ReSort = true)
	{
		X1 = 0.0;
		X2 = 0.0;
		if (ReSort)
		{
			JobShapeToItemCalc(ref activeJob);
			SortJobItems(ref activeJob);
		}
		List<DrillCalcItem> list = new List<DrillCalcItem>();
		double num = varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperOperationMinDistance;
		for (int i = 0; i <= Job.ItemCalc.Count - 1; i++)
		{
			if (Job.ItemCalc[i].planeName == planeBoxNames.Left)
			{
				list.Add(new DrillCalcItem(Job.ItemCalc[i]));
			}
			if (Job.ItemCalc[i].planeName == planeBoxNames.Top && Job.ItemCalc[i].Center.Y - Job.ItemCalc[i].Diameter / 2.0 < varDrillCNCSettings.ClamperCatchWidth)
			{
				list.Add(new DrillCalcItem(Job.ItemCalc[i]));
			}
		}
		List<MinMidMaxRange> list2 = new List<MinMidMaxRange>();
		for (int j = 0; j <= list.Count - 1; j++)
		{
			if (j != 0)
			{
				if (j != list.Count - 1)
				{
					double num2 = list[j].Center.X - list[j].Diameter / 2.0 - (list[j - 1].Center.X + list[j - 1].Diameter / 2.0);
					if (num2 > varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperOperationMinDistance)
					{
						MinMidMaxRange minMidMaxRange = new MinMidMaxRange();
						minMidMaxRange.Mid = (list[j].Center.X + list[j - 1].Center.X) / 2.0;
						minMidMaxRange.Min = list[j - 1].Center.X + list[j - 1].Diameter / 2.0;
						minMidMaxRange.Max = list[j].Center.X - list[j].Diameter / 2.0;
						minMidMaxRange.Range = minMidMaxRange.Max - minMidMaxRange.Min;
						list2.Add(minMidMaxRange);
					}
					continue;
				}
				double num3 = list[j].Center.X - list[j].Diameter / 2.0 - (list[j - 1].Center.X + list[j - 1].Diameter / 2.0);
				if (num3 > varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperOperationMinDistance)
				{
					MinMidMaxRange minMidMaxRange2 = new MinMidMaxRange();
					minMidMaxRange2.Mid = (list[j].Center.X + list[j - 1].Center.X) / 2.0;
					minMidMaxRange2.Min = list[j - 1].Center.X + list[j - 1].Diameter / 2.0;
					minMidMaxRange2.Max = list[j].Center.X - list[j].Diameter / 2.0;
					minMidMaxRange2.Range = minMidMaxRange2.Max - minMidMaxRange2.Min;
					list2.Add(minMidMaxRange2);
				}
				num3 = Job.Material.Size.Width - (list[j].Center.X + list[j].Diameter / 2.0);
				if (num3 > varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperOperationMinDistance)
				{
					MinMidMaxRange minMidMaxRange3 = new MinMidMaxRange();
					minMidMaxRange3.Mid = (list[j].Center.X + Job.Material.Size.Width) / 2.0;
					minMidMaxRange3.Min = list[j].Center.X + list[j].Diameter / 2.0;
					minMidMaxRange3.Max = Job.Material.Size.Width;
					minMidMaxRange3.Range = minMidMaxRange3.Max - minMidMaxRange3.Min;
					list2.Add(minMidMaxRange3);
				}
			}
			else
			{
				double num4 = list[j].Center.X + list[j].Diameter / 2.0;
				if (num4 > varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperOperationMinDistance)
				{
					MinMidMaxRange minMidMaxRange4 = new MinMidMaxRange();
					minMidMaxRange4.Mid = list[j].Center.X / 2.0;
					minMidMaxRange4.Min = 0.0;
					minMidMaxRange4.Max = list[j].Center.X - list[j].Diameter / 2.0;
					minMidMaxRange4.Range = minMidMaxRange4.Max - minMidMaxRange4.Min;
					list2.Add(minMidMaxRange4);
				}
			}
		}
		num = varDrillCNCSettings.ClamperLength / 2.0 + varDrillCNCSettings.ClamperOperationMinDistance;
		double num5 = 1.0;
		double num6 = 1.0;
		if (Job.Material.Size.Width < 500.0)
		{
			num5 = 0.3;
			num6 = 0.7;
		}
		if ((Job.Material.Size.Width >= 500.0) & (Job.Material.Size.Width < 600.0))
		{
			num5 = 0.32;
			num6 = 0.68;
		}
		if ((Job.Material.Size.Width >= 600.0) & (Job.Material.Size.Width < 750.0))
		{
			num5 = 0.35;
			num6 = 0.65;
		}
		if ((Job.Material.Size.Width >= 750.0) & (Job.Material.Size.Width < 1000.0))
		{
			num5 = 0.37;
			num6 = 0.63;
		}
		if ((Job.Material.Size.Width >= 1000.0) & (Job.Material.Size.Width < 1500.0))
		{
			num5 = 0.3;
			num6 = 0.75;
		}
		if ((Job.Material.Size.Width >= 1500.0) & (Job.Material.Size.Width < 2000.0))
		{
			num5 = 0.25;
			num6 = 0.7;
		}
		if ((Job.Material.Size.Width >= 2000.0) & (Job.Material.Size.Width < 2500.0))
		{
			num5 = 0.2;
			num6 = Math.Round((Math.Abs(varDrillMachineSettings.MachineMinXStroke) - num) / Job.Material.Size.Width, 3) - 0.05;
		}
		if (Job.Material.Size.Width >= 2500.0)
		{
			num5 = 0.15;
			num6 = 0.5;
		}
		if (list2.Count == 1 && list2[0].Range > 2.0 * (varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperOperationMinDistance))
		{
			if (list2[0].Min + num < Job.Material.Size.Width * num5)
			{
				X2 = 0.0 - Math.Round(list2[0].Min + num, 3);
			}
			if (list2[0].Max - num > Job.Material.Size.Width * num6)
			{
				X1 = 0.0 - Math.Round(list2[0].Max - num, 3);
			}
		}
		if (list2.Count >= 2)
		{
			if (!(list2[0].Mid < Job.Material.Size.Width * num5))
			{
				if ((Job.Material.Size.Width * num5 >= list2[0].Min) & (Job.Material.Size.Width * num5 < list2[0].Max))
				{
					X2 = 0.0 - Math.Round(Job.Material.Size.Width * num5, 3);
				}
			}
			else
			{
				X2 = 0.0 - Math.Round(list2[0].Mid, 3);
			}
			for (int num7 = list2.Count - 1; num7 >= 0; num7--)
			{
				if (!((0.0 - Job.Material.Size.Width) * num6 > varDrillMachineSettings.MachineMinXStroke))
				{
					if ((0.0 - Job.Material.Size.Width) * (num6 - 0.1) > varDrillMachineSettings.MachineMinXStroke && list2[list2.Count - 1].Mid > Job.Material.Size.Width * (num6 - 0.1))
					{
						X1 = 0.0 - Math.Round(list2[list2.Count - 1].Mid, 3);
					}
				}
				else if (!((0.0 - list2[num7].Mid > varDrillMachineSettings.MachineMinXStroke) & (list2[num7].Mid > Job.Material.Size.Width * num6)))
				{
					if (!((0.0 - (list2[num7].Min + num) > varDrillMachineSettings.MachineMinXStroke) & (list2[num7].Min + num > Job.Material.Size.Width * num6)))
					{
						if ((0.0 - (list2[num7].Max - num) > varDrillMachineSettings.MachineMinXStroke) & (list2[num7].Max - num > Job.Material.Size.Width * num6))
						{
							X1 = 0.0 - Math.Round(list2[num7].Max - num, 3);
							num7 = 0;
						}
					}
					else
					{
						X1 = 0.0 - Math.Round(list2[num7].Min + num, 3);
						num7 = 0;
					}
				}
				else if (list2[num7].Mid > Job.Material.Size.Width * num6)
				{
					X1 = 0.0 - Math.Round(list2[list2.Count - 1].Mid, 3);
					num7 = 0;
				}
			}
		}
		if (list2.Count <= 0)
		{
			MaterialZeroYPos = Job.Material.Size.Height / 2.0;
			if (MaterialZeroYPos < varDrillCNCSettings.MaterialZeroYMinPosition)
			{
				MaterialZeroYPos = varDrillCNCSettings.MaterialZeroYMinPosition;
			}
			if (MaterialZeroYPos > varDrillCNCSettings.MaterialZeroYMaxPosition)
			{
				MaterialZeroYPos = varDrillCNCSettings.MaterialZeroYMaxPosition;
			}
			if (!(Job.Material.Size.Width > 3.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance))
			{
				double num8 = Job.Material.Size.Width - (2.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance);
				X1 = 0.0 - Job.Material.Size.Width + varDrillCNCSettings.ClamperLength / 2.0 + num8 / 2.0;
			}
			else
			{
				X1 = 0.0 - Job.Material.Size.Width + varDrillCNCSettings.ClamperLength / 2.0 + varDrillCNCSettings.ClamperLength / 2.0;
			}
			if (!(Job.Material.Size.Width > 3.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance))
			{
				double num9 = 2.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance - Job.Material.Size.Width;
				X2 = 0.0 - (varDrillCNCSettings.ClamperLength / 2.0 + varDrillCNCSettings.ClamperLength / 4.0) + num9 / 2.0;
			}
			else
			{
				X2 = 0.0 - (varDrillCNCSettings.ClamperLength / 2.0 + varDrillCNCSettings.ClamperLength / 3.0);
				if ((Job.Material.Size.Width > 1500.0) & (Job.Material.Size.Width <= 2000.0))
				{
					X2 = 0.0 - 2.0 * varDrillCNCSettings.ClamperLength;
				}
				if (Job.Material.Size.Width > 2000.0)
				{
					X2 = 0.0 - 3.0 * varDrillCNCSettings.ClamperLength;
				}
			}
			if (activeJob != null)
			{
				if (activeJob.FirstClamperX != activeJob.SecondClamperX)
				{
					X2 = activeJob.SecondClamperX;
					X1 = activeJob.FirstClamperX;
				}
				if (X2 - X1 < varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance)
				{
					double num10 = varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance - (X2 - X1);
					if (num10 > 0.0)
					{
						X2 += num10 / 2.0;
						X1 -= num10 / 2.0;
					}
				}
				if (X1 < varDrillMachineSettings.MachineMinXStroke)
				{
					X1 = varDrillMachineSettings.MachineMinXStroke;
				}
				return true;
			}
			return false;
		}
		if (X1 == 0.0)
		{
			if (!(Job.Material.Size.Width > 3.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance))
			{
				double num11 = Job.Material.Size.Width - (2.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance);
				if (num11 > 0.0)
				{
					num11 = 0.0;
				}
				X1 = 0.0 - Job.Material.Size.Width + varDrillCNCSettings.ClamperLength / 2.0 + num11 / 2.0;
			}
			else
			{
				X1 = 0.0 - Job.Material.Size.Width + varDrillCNCSettings.ClamperLength / 2.0 + varDrillCNCSettings.ClamperLength / 2.0;
			}
		}
		if (X2 == 0.0)
		{
			if (!(Job.Material.Size.Width > 3.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance))
			{
				double num12 = 2.0 * varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance - Job.Material.Size.Width;
				if (num12 < 0.0)
				{
					num12 = 0.0;
				}
				X2 = 0.0 - varDrillCNCSettings.ClamperLength / 2.0 + num12 / 2.0;
			}
			else
			{
				X2 = 0.0 - (varDrillCNCSettings.ClamperLength / 2.0 + varDrillCNCSettings.ClamperLength / 4.0);
			}
		}
		if (X2 - X1 < varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance)
		{
			double num13 = varDrillCNCSettings.ClamperLength + varDrillCNCSettings.ClamperBetweenMinDistance - (X2 - X1);
			if (num13 > 0.0)
			{
				X2 += num13 / 2.0;
				X1 -= num13 / 2.0;
			}
		}
		if (X1 < varDrillMachineSettings.MachineMinXStroke)
		{
			X1 = varDrillMachineSettings.MachineMinXStroke;
		}
		return true;
	}

	public void doGeneralTick(int TickCount)
	{
	}

	public void doFindFastestPattern()
	{
		DrillCNCSettings data = new DrillCNCSettings(varDrillCNCSettings);
		new DrillCNCSettings(varDrillCNCSettings);
		new List<DrillItem>();
		new DrillJob(activeJob);
		for (int i = 0; i <= 10; i++)
		{
		}
		varDrillCNCSettings = new DrillCNCSettings(data);
	}

	public void doCalculateTime(ref double totTimeAsSec)
	{
		bool flag = false;
		totTimeAsSec = 0.0;
		for (int i = 0; i <= activeJob.Moves.Count - 1; i++)
		{
			if (flag)
			{
				if (activeJob.Moves[i].Command == DrillMoveCommand.AxisMove)
				{
					double num = 0.0;
					double num2 = Math.Abs(activeJob.Moves[i - 1].XPosition - activeJob.Moves[i].XPosition);
					double distance = Math.Abs(activeJob.Moves[i - 1].X1Clamper - activeJob.Moves[i].X1Clamper);
					double distance2 = Math.Abs(activeJob.Moves[i - 1].X2Clamper - activeJob.Moves[i].X2Clamper);
					double distance3 = Math.Abs(activeJob.Moves[i - 1].Y1Position - activeJob.Moves[i].Y1Position);
					double distance4 = Math.Abs(activeJob.Moves[i - 1].Y2Position - activeJob.Moves[i].Y2Position);
					double distance5 = Math.Abs(activeJob.Moves[i - 1].Y3Position - activeJob.Moves[i].Y3Position);
					double distance6 = Math.Abs(activeJob.Moves[i - 1].Z1Position - activeJob.Moves[i].Z1Position);
					double distance7 = Math.Abs(activeJob.Moves[i - 1].Z2Position - activeJob.Moves[i].Z2Position);
					double distance8 = Math.Abs(activeJob.Moves[i - 1].Z3Position - activeJob.Moves[i].Z3Position);
					if (!(num2 > 0.0))
					{
					}
					double num3 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.X1Velocity, num2, varDrillMachineSettings.X1AccDec, varDrillMachineSettings.X1AccDec);
					clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.X1Velocity, distance, varDrillMachineSettings.X1AccDec, varDrillMachineSettings.X1AccDec);
					clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.X2Velocity, distance2, varDrillMachineSettings.X2AccDec, varDrillMachineSettings.X2AccDec);
					double num4 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.Y1Velocity, distance3, varDrillMachineSettings.Y1AccDec, varDrillMachineSettings.Y1AccDec);
					double num5 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.Y2Velocity, distance4, varDrillMachineSettings.Y2AccDec, varDrillMachineSettings.Y2AccDec);
					double num6 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.Y3Velocity, distance5, varDrillMachineSettings.Y3AccDec, varDrillMachineSettings.Y3AccDec);
					double num7 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.Z1Velocity, distance6, varDrillMachineSettings.Z1AccDec, varDrillMachineSettings.Z1AccDec);
					double num8 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.Z2Velocity, distance7, varDrillMachineSettings.Z2AccDec, varDrillMachineSettings.Z2AccDec);
					double num9 = clsInit.cVector5.TimeFromVelocityDistanceAcceleration(varDrillMachineSettings.Z3Velocity, distance8, varDrillMachineSettings.Z3AccDec, varDrillMachineSettings.Z3AccDec);
					if (num3 > num)
					{
						num = num3;
					}
					if (num4 > num)
					{
						num = num4;
					}
					if (num5 > num)
					{
						num = num5;
					}
					if (num6 > num)
					{
						num = num6;
					}
					if (num7 > num)
					{
						num = num7;
					}
					if (num8 > num)
					{
						num = num8;
					}
					if (num9 > num)
					{
						num = num9;
					}
					if (num == 0.0)
					{
						if ((activeJob.Moves[i].Command2 == DrillMoveCommand.SetPiston) | (activeJob.Moves[i].Command2 == DrillMoveCommand.SetPress))
						{
							num = varDrillMachineSettings.ToolSetTime;
						}
						if ((activeJob.Moves[i].Command2 == DrillMoveCommand.ResetAll) | (activeJob.Moves[i].Command2 == DrillMoveCommand.ResetAllPress) | (activeJob.Moves[i].Command2 == DrillMoveCommand.ResetPiston) | (activeJob.Moves[i].Command2 == DrillMoveCommand.ResetPress))
						{
							num = varDrillMachineSettings.ToolResetTime;
						}
					}
					totTimeAsSec += num;
				}
				if (activeJob.Moves[i].Command == DrillMoveCommand.SetPiston)
				{
					totTimeAsSec += varDrillMachineSettings.ToolSetTime;
				}
				if (activeJob.Moves[i].Command == DrillMoveCommand.SetPiston)
				{
					totTimeAsSec += varDrillMachineSettings.ToolSetTime;
				}
				if ((activeJob.Moves[i].Command == DrillMoveCommand.ResetAll) | (activeJob.Moves[i].Command == DrillMoveCommand.ResetAllPress) | (activeJob.Moves[i].Command == DrillMoveCommand.ResetPiston) | (activeJob.Moves[i].Command == DrillMoveCommand.ResetPress))
				{
					totTimeAsSec += varDrillMachineSettings.ToolResetTime;
				}
				if ((activeJob.Moves[i].Command == DrillMoveCommand.AllClamperUp) | (activeJob.Moves[i].Command == DrillMoveCommand.Clamper1Up) | (activeJob.Moves[i].Command == DrillMoveCommand.Clamper2Up))
				{
					totTimeAsSec += varDrillMachineSettings.ClamperUpTime;
				}
				if ((activeJob.Moves[i].Command == DrillMoveCommand.AllClamperDown) | (activeJob.Moves[i].Command == DrillMoveCommand.Clamper1Down) | (activeJob.Moves[i].Command == DrillMoveCommand.Clamper2Down))
				{
					totTimeAsSec += varDrillMachineSettings.ClamperUpTime;
				}
			}
			if (activeJob.Moves[i].Command == DrillMoveCommand.Wait)
			{
				flag = true;
			}
		}
	}

	public void doDeletePanel(int JobIndex)
	{
		activeJob.Items.Clear();
		activeJob.ItemCalc.Clear();
		activeJob = null;
		JobUpdate(FillPages: true, null);
		DrawPanelFromJobMainAndPreview(activeJob);
	}

	public void doEditPanel(int JobIndex, MaterialBase5 mat)
	{
		if (activeJob != null)
		{
			activeJob.Material = new MaterialBase5(mat);
			double MaterialZeroYPos = 0.0;
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				cGoUltra2Up1Down.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				cGoAtc.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (MachType == DrillMachineType.Sirius)
			{
				cGoSirius.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (ClamperEntity != null)
			{
				clsInit.cDrill.CreateClamperEntities(ClamperEntity, activeJob.FirstClamperX, activeJob.SecondClamperX, ref activeJob.FirstClamperEntity, ref activeJob.SecondClamperEntity, Color.Gray);
			}
			shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
			clsVar5.shapeCreatePar.Size = new SizeObject(mat.Size);
			for (int i = 0; i <= activeJob.Items.Count - 1; i++)
			{
				buShape Shape = buShape.Copy(activeJob.Items[i]);
				clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
				activeJob.Items[i] = Shape;
			}
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(activeJob);
			clsVar5.ShapeDataParameters = new ShapeRuntimeData(shapeRuntimeData_0);
		}
	}

	public void doDeleteOperation(int JobIndex, int OperationIndex, int OperationSubIndex)
	{
		if (!(((JobIndex >= 0 && OperationIndex >= 0) & (OperationIndex <= activeJob.Items.Count - 1)) && OperationSubIndex == -1))
		{
			if (((JobIndex >= 0 && OperationIndex >= 0) & (OperationIndex <= activeJob.Items.Count - 1)) && OperationSubIndex >= 0)
			{
				if (OperationSubIndex <= activeJob.Items[OperationIndex].multiCenter.Count - 1)
				{
					activeJob.Items[OperationIndex].multiCenter.RemoveAt(OperationSubIndex);
				}
				if (OperationSubIndex <= activeJob.Items[OperationIndex].entitySolid.Count - 1)
				{
					activeJob.Items[OperationIndex].entitySolid.RemoveAt(OperationSubIndex);
				}
				JobUpdate(FillPages: true, null);
				DrawPanelFromJobMainAndPreview(activeJob);
			}
		}
		else
		{
			activeJob.Items.RemoveAt(OperationIndex);
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(activeJob);
		}
	}

	public void doDeletaAllOperations()
	{
		activeJob.Items.Clear();
		activeJob.ItemCalc.Clear();
		activeJob.Moves.Clear();
		activeJob.SimulationMoves.Clear();
		activeJob.Cams.Clear();
		activeJob.Codes.Clear();
		JobUpdate(FillPages: true, null);
		DrawPanelFromJobMainAndPreview(activeJob);
	}

	public void doEditOperation()
	{
		if (!((selectedJobIndex >= 0) & (selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 1)))
		{
			return;
		}
		OperationToParameter(activeJob.Items[selectedItemIndex], ref clsVar5.ShapeDataParameters);
		shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
		if (activeJob.Items[selectedItemIndex].ShapeGroup != ShapeGroup.Drill)
		{
			if (activeJob.Items[selectedItemIndex].ShapeGroup != ShapeGroup.Shape)
			{
				if (activeJob.Items[selectedItemIndex].ShapeGroup != ShapeGroup.Cut)
				{
					if (activeJob.Items[selectedItemIndex].ShapeGroup == ShapeGroup.Profiling)
					{
						buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastProfiling);
						EditOperation = true;
						cmdCornerMenu();
						EditOperation = true;
					}
				}
				else
				{
					buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastCut);
					EditOperation = true;
					cmdCutsMenu();
					EditOperation = true;
				}
			}
			else
			{
				buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastShape);
				EditOperation = true;
				cmdDrawingsMenu();
				EditOperation = true;
			}
		}
		else
		{
			buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastDrill);
			EditOperation = true;
			cmdHolesMenu();
			EditOperation = true;
		}
	}

	public void doCopyOperation()
	{
		if (!((selectedJobIndex >= 0) & (selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 1)))
		{
			return;
		}
		shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
		OperationToParameter(activeJob.Items[selectedItemIndex], ref clsVar5.ShapeDataParameters);
		if (activeJob.Items[selectedItemIndex].ShapeGroup != ShapeGroup.Drill)
		{
			if (activeJob.Items[selectedItemIndex].ShapeGroup != ShapeGroup.Shape)
			{
				if (activeJob.Items[selectedItemIndex].ShapeGroup != ShapeGroup.Cut)
				{
					if (activeJob.Items[selectedItemIndex].ShapeGroup == ShapeGroup.Profiling)
					{
						EditOperation = true;
						buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastProfiling);
						cmdCornerMenu();
					}
				}
				else
				{
					EditOperation = true;
					buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastCut);
					cmdCutsMenu();
				}
			}
			else
			{
				buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastShape);
				cmdDrawingsMenu();
			}
		}
		else
		{
			buShape.Copy(activeJob.Items[selectedItemIndex], ref clsVar5.lastDrill);
			cmdHolesMenu();
		}
	}

	public void doMirrorOperation()
	{
		if (!((selectedJobIndex >= 0) & (selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 1)))
		{
			return;
		}
		F_MirrorOP f_MirrorOP = new F_MirrorOP();
		f_MirrorOP.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
		f_MirrorOP.Shape = buShape.Copy(activeJob.Items[selectedItemIndex]);
		f_MirrorOP.CopyAsNew = varDrillRunSettings.MirrorCopyAsNew;
		f_MirrorOP.MirrorType = varDrillRunSettings.MirrorType;
		f_MirrorOP.Init();
		f_MirrorOP.StartPosition = FormStartPosition.CenterParent;
		f_MirrorOP.ShowDialog();
		if (f_MirrorOP.PropertiesForm.Result == DialogResult.OK)
		{
			shapeRuntimeData_0 = new ShapeRuntimeData(clsVar5.ShapeDataParameters);
			varDrillRunSettings.MirrorType = f_MirrorOP.MirrorType;
			varDrillRunSettings.MirrorCopyAsNew = f_MirrorOP.CopyAsNew;
			OperationToParameter(activeJob.Items[selectedItemIndex], ref clsVar5.ShapeDataParameters);
			buShape Shape = buShape.Copy(activeJob.Items[selectedItemIndex]);
			if (varDrillRunSettings.MirrorType == MirrorBoxType.Plane)
			{
				Shape.planeName = f_MirrorOP.newPlane;
				clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
			}
			if (varDrillRunSettings.MirrorType == MirrorBoxType.Horizotal)
			{
				Shape.Corner = f_MirrorOP.newCorner;
				clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
			}
			if (varDrillRunSettings.MirrorType == MirrorBoxType.Vertical)
			{
				Shape.Corner = f_MirrorOP.newCorner;
				clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
			}
			if (!varDrillRunSettings.MirrorCopyAsNew)
			{
				activeJob.Items[selectedItemIndex] = Shape;
			}
			else
			{
				activeJob.Items.Add(Shape);
			}
			JobUpdate(FillPages: true, null);
			DrawPanelFromJobMainAndPreview(activeJob);
			clsVar5.ShapeDataParameters = new ShapeRuntimeData(shapeRuntimeData_0);
			shapeRuntimeData_0 = null;
		}
	}

	public void doRotateOperation()
	{
		F_RotatePanel f_RotatePanel = new F_RotatePanel();
		f_RotatePanel.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
		f_RotatePanel.ClockType = varDrillRunSettings.RotateClockType;
		f_RotatePanel.Degree = varDrillRunSettings.RotateDegree;
		f_RotatePanel.Init();
		f_RotatePanel.StartPosition = FormStartPosition.CenterParent;
		f_RotatePanel.ShowDialog();
		if (f_RotatePanel.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		varDrillRunSettings.RotateClockType = f_RotatePanel.ClockType;
		varDrillRunSettings.RotateDegree = f_RotatePanel.Degree;
		if (varDrillRunSettings.RotateDegree == 90.0)
		{
			buNumeric5.ExchangeTwoVaues(ref activeJob.Material.Size.Width, ref activeJob.Material.Size.Height);
			activeJob.Material.Entities.Clear();
			Entity Ent = null;
			clsInit.cVector5.CreateMaterialEntities(activeJob.Material, ref Ent);
			clsInit.cVector5.Move(0.0 - activeJob.Material.Size.Width, 0.0 - activeJob.Material.Size.Height, 0.0, ref Ent);
			activeJob.Material.Entities.Add(Ent);
			activeJob.Material.Sing = new Point3D(clsVar5.shapeCreatePar.SingX, clsVar5.shapeCreatePar.SingY, 1.0);
			if (activeJob.Material.Entities.Count > 0)
			{
				buEntity.Copy(activeJob.Material.Entities[0], ref activeJob.panelEntity);
			}
			double MaterialZeroYPos = 0.0;
			if (MachType == DrillMachineType.GoUltra2Top1BottomNoAtc)
			{
				cGoUltra2Up1Down.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (MachType == DrillMachineType.GoWithAtc)
			{
				cGoAtc.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (MachType == DrillMachineType.Sirius)
			{
				cGoSirius.FindFirstClamperPositions(activeJob, ref MaterialZeroYPos, ref activeJob.FirstClamperX, ref activeJob.SecondClamperX);
			}
			if (ClamperEntity != null)
			{
				clsInit.cDrill.CreateClamperEntities(ClamperEntity, activeJob.FirstClamperX, activeJob.SecondClamperX, ref activeJob.FirstClamperEntity, ref activeJob.SecondClamperEntity, Color.Gray);
			}
		}
		if (activeJob.Items.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= activeJob.Items.Count - 1; i++)
		{
			if (varDrillRunSettings.RotateDegree != 180.0)
			{
				if (varDrillRunSettings.RotateDegree == 90.0)
				{
					bool flag = false;
					if ((((activeJob.Items[i].planeName == planeBoxNames.Front) ? 1u : 0u) & 1u) == 0)
					{
						if (!(activeJob.Items[i].planeName == planeBoxNames.Back && !flag))
						{
							if (!(activeJob.Items[i].planeName == planeBoxNames.Left && !flag))
							{
								if (!(activeJob.Items[i].planeName == planeBoxNames.Right && !flag))
								{
									if (((activeJob.Items[i].planeName == planeBoxNames.Top) | (activeJob.Items[i].planeName == planeBoxNames.Bottom)) && !flag)
									{
										buNumeric5.ExchangeTwoVaues(ref activeJob.Items[i].BasePoint.X, ref activeJob.Items[i].BasePoint.Y);
										if (activeJob.Items[i] is buShapeCut)
										{
											((buShapeCut)activeJob.Items[i]).entityWireframe.Clear();
											((buShapeCut)activeJob.Items[i]).entitiesDim.Clear();
											if (((buShapeCut)activeJob.Items[i]).CutType != CutTypes.CutHorizontal)
											{
												if (((buShapeCut)activeJob.Items[i]).CutType != CutTypes.CutHorizontalLine)
												{
													if (((buShapeCut)activeJob.Items[i]).CutType != CutTypes.CutVertical)
													{
														if (((buShapeCut)activeJob.Items[i]).CutType == CutTypes.CutVerticalLine)
														{
															((buShapeCut)activeJob.Items[i]).CutType = CutTypes.CutHorizontalLine;
														}
													}
													else
													{
														((buShapeCut)activeJob.Items[i]).CutType = CutTypes.CutHorizontal;
													}
												}
												else
												{
													((buShapeCut)activeJob.Items[i]).CutType = CutTypes.CutVerticalLine;
												}
											}
											else
											{
												((buShapeCut)activeJob.Items[i]).CutType = CutTypes.CutVertical;
											}
										}
										if (activeJob.Items[i] is buShapeHoleMulti)
										{
											if (((buShapeHoleMulti)activeJob.Items[i]).DrillType != drillTypes.HorizontalHoles)
											{
												if (((buShapeHoleMulti)activeJob.Items[i]).DrillType != drillTypes.HorizontalLineHoles)
												{
													if (((buShapeHoleMulti)activeJob.Items[i]).DrillType != drillTypes.VerticalHoles)
													{
														if (((buShapeHoleMulti)activeJob.Items[i]).DrillType == drillTypes.VerticalLineHoles)
														{
															((buShapeHoleMulti)activeJob.Items[i]).DrillType = drillTypes.HorizontalLineHoles;
														}
													}
													else
													{
														((buShapeHoleMulti)activeJob.Items[i]).DrillType = drillTypes.HorizontalHoles;
													}
												}
												else
												{
													((buShapeHoleMulti)activeJob.Items[i]).DrillType = drillTypes.VerticalLineHoles;
												}
											}
											else
											{
												((buShapeHoleMulti)activeJob.Items[i]).DrillType = drillTypes.VerticalHoles;
											}
										}
										if (varDrillRunSettings.RotateClockType != ClockDirectionType.CW)
										{
											if (activeJob.Items[i].Corner != CornerLocation.RightTop)
											{
												if (activeJob.Items[i].Corner != CornerLocation.LeftTop)
												{
													if (activeJob.Items[i].Corner != CornerLocation.LeftBottom)
													{
														if (activeJob.Items[i].Corner == CornerLocation.RightBottom)
														{
															activeJob.Items[i].Corner = CornerLocation.RightTop;
														}
													}
													else
													{
														activeJob.Items[i].Corner = CornerLocation.RightBottom;
													}
												}
												else
												{
													activeJob.Items[i].Corner = CornerLocation.LeftBottom;
												}
											}
											else
											{
												activeJob.Items[i].Corner = CornerLocation.LeftTop;
											}
										}
										else if (activeJob.Items[i].Corner != CornerLocation.RightTop)
										{
											if (activeJob.Items[i].Corner != CornerLocation.RightBottom)
											{
												if (activeJob.Items[i].Corner != CornerLocation.LeftBottom)
												{
													if (activeJob.Items[i].Corner == CornerLocation.LeftTop)
													{
														activeJob.Items[i].Corner = CornerLocation.RightTop;
													}
												}
												else
												{
													activeJob.Items[i].Corner = CornerLocation.LeftTop;
												}
											}
											else
											{
												activeJob.Items[i].Corner = CornerLocation.LeftBottom;
											}
										}
										else
										{
											activeJob.Items[i].Corner = CornerLocation.RightBottom;
										}
										flag = true;
									}
								}
								else
								{
									buNumeric5.ExchangeTwoVaues(ref activeJob.Items[i].BasePoint.X, ref activeJob.Items[i].BasePoint.Y);
									if (varDrillRunSettings.RotateClockType != ClockDirectionType.CW)
									{
										activeJob.Items[i].planeName = planeBoxNames.Back;
										activeJob.Items[i].planeOperation = Plane.XZ;
										clsInit.cDrill.ChangeCornerOpposite(ref activeJob.Items[i].Corner);
									}
									else
									{
										activeJob.Items[i].planeName = planeBoxNames.Front;
										activeJob.Items[i].planeOperation = Plane.XZ;
									}
									flag = true;
								}
							}
							else
							{
								buNumeric5.ExchangeTwoVaues(ref activeJob.Items[i].BasePoint.X, ref activeJob.Items[i].BasePoint.Y);
								if (varDrillRunSettings.RotateClockType != ClockDirectionType.CW)
								{
									activeJob.Items[i].planeName = planeBoxNames.Front;
									activeJob.Items[i].planeOperation = Plane.XZ;
									clsInit.cDrill.ChangeCornerOpposite(ref activeJob.Items[i].Corner);
								}
								else
								{
									activeJob.Items[i].planeName = planeBoxNames.Back;
									activeJob.Items[i].planeOperation = Plane.XZ;
								}
								flag = true;
							}
						}
						else
						{
							buNumeric5.ExchangeTwoVaues(ref activeJob.Items[i].BasePoint.X, ref activeJob.Items[i].BasePoint.Y);
							if (varDrillRunSettings.RotateClockType != ClockDirectionType.CW)
							{
								activeJob.Items[i].planeName = planeBoxNames.Left;
								activeJob.Items[i].planeOperation = Plane.YZ;
							}
							else
							{
								activeJob.Items[i].planeName = planeBoxNames.Right;
								activeJob.Items[i].planeOperation = Plane.YZ;
								clsInit.cDrill.ChangeCornerOpposite(ref activeJob.Items[i].Corner);
							}
							flag = true;
						}
					}
					else
					{
						buNumeric5.ExchangeTwoVaues(ref activeJob.Items[i].BasePoint.X, ref activeJob.Items[i].BasePoint.Y);
						if (varDrillRunSettings.RotateClockType != ClockDirectionType.CW)
						{
							activeJob.Items[i].planeName = planeBoxNames.Right;
							activeJob.Items[i].planeOperation = Plane.YZ;
						}
						else
						{
							activeJob.Items[i].planeName = planeBoxNames.Left;
							activeJob.Items[i].planeOperation = Plane.YZ;
							clsInit.cDrill.ChangeCornerOpposite(ref activeJob.Items[i].Corner);
						}
						flag = true;
					}
				}
			}
			else
			{
				_ = activeJob.Items[i];
				if (activeJob.Items[i].Corner != CornerLocation.RightTop)
				{
					if (activeJob.Items[i].Corner != CornerLocation.RightBottom)
					{
						if (activeJob.Items[i].Corner != CornerLocation.LeftBottom)
						{
							if (activeJob.Items[i].Corner == CornerLocation.LeftTop)
							{
								activeJob.Items[i].Corner = CornerLocation.RightBottom;
							}
						}
						else
						{
							activeJob.Items[i].Corner = CornerLocation.RightTop;
						}
					}
					else
					{
						activeJob.Items[i].Corner = CornerLocation.LeftTop;
					}
				}
				else
				{
					activeJob.Items[i].Corner = CornerLocation.LeftBottom;
				}
				if (activeJob.Items[i].planeName != planeBoxNames.Front)
				{
					if (activeJob.Items[i].planeName != planeBoxNames.Back)
					{
						if (activeJob.Items[i].planeName != planeBoxNames.Left)
						{
							if (activeJob.Items[i].planeName != planeBoxNames.Right)
							{
								if (activeJob.Items[i].planeName != planeBoxNames.Top)
								{
									if (activeJob.Items[i].planeName == planeBoxNames.Bottom)
									{
										activeJob.Items[i].planeName = planeBoxNames.Bottom;
									}
								}
								else
								{
									activeJob.Items[i].planeName = planeBoxNames.Top;
								}
							}
							else
							{
								activeJob.Items[i].planeName = planeBoxNames.Left;
							}
						}
						else
						{
							activeJob.Items[i].planeName = planeBoxNames.Right;
						}
					}
					else
					{
						activeJob.Items[i].planeName = planeBoxNames.Front;
					}
				}
				else
				{
					activeJob.Items[i].planeName = planeBoxNames.Back;
				}
			}
			clsVar5.shapeCreatePar.Solid = true;
			clsVar5.shapeCreatePar.Size = new SizeObject(activeJob.Material.Size);
			clsVar5.shapeCreatePar.SingX = -1.0;
			clsVar5.shapeCreatePar.SingY = -1.0;
			buShape Shape = activeJob.Items[i];
			clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
		}
		JobUpdate(FillPages: true, null);
		DrawPanelFromJobMainAndPreview(activeJob);
	}

	public void doOperationMoveDown()
	{
		if ((activeJob.Items.Count > 0) & (selectedItemIndex >= 0) & (selectedItemIndex <= activeJob.Items.Count - 2))
		{
			buShape item = activeJob.Items[selectedItemIndex];
			activeJob.Items.RemoveAt(selectedItemIndex);
			selectedItemIndex++;
			activeJob.Items.Insert(selectedItemIndex, item);
			JobUpdate(FillPages: true, null);
		}
	}

	public void doOperationMoveUp()
	{
		if ((activeJob.Items.Count >= 0) & (selectedItemIndex > 0) & (selectedItemIndex <= activeJob.Items.Count - 1))
		{
			buShape item = activeJob.Items[selectedItemIndex];
			activeJob.Items.RemoveAt(selectedItemIndex);
			selectedItemIndex--;
			activeJob.Items.Insert(selectedItemIndex, item);
			JobUpdate(FillPages: true, null);
		}
	}

	public void FindDrillsAtPlane(DrillJob Job, planeBoxNames refPlane, ref List<DrillCalcItem> Items)
	{
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (!(Job.Items[i] is buShapeHole))
			{
				continue;
			}
			buShapeHole buShapeHole4 = Job.Items[i] as buShapeHole;
			if (!buShapeHole4.Enable)
			{
				continue;
			}
			if (buShapeHole4.planeName == planeBoxNames.Back)
			{
				Job.isClamperSideDrillOpAvailable = true;
			}
			if (buShapeHole4.DrillType == drillTypes.SingleHole && (!buShapeHole4.isMilling & (buShapeHole4.planeName == refPlane)))
			{
				Items.Add(new DrillCalcItem(buShapeHole4));
				Items[Items.Count - 1].ID = IDCounter;
			}
			if (((buShapeHole4.DrillType == drillTypes.HorizontalHoles) | (buShapeHole4.DrillType == drillTypes.HorizontalLineHoles) | (buShapeHole4.DrillType == drillTypes.VerticalHoles) | (buShapeHole4.DrillType == drillTypes.VerticalLineHoles) | (buShapeHole4.DrillType == drillTypes.InclineHoles)) && (!buShapeHole4.isMilling & (buShapeHole4.planeName == refPlane)))
			{
				for (int j = 0; j <= buShapeHole4.multiCenter.Count - 1; j++)
				{
					buShapeHole buShapeHole5 = new buShapeHole(buShapeHole4.Diameter, buShapeHole4.Depth);
					buShapeHole5.CalculatedPoint = new Point3D(buShapeHole4.multiCenter[j].Center.X, buShapeHole4.multiCenter[j].Center.Y, buShapeHole4.multiCenter[j].Center.Z);
					buShapeHole5.planeName = buShapeHole4.planeName;
					buShapeHole5.ID = IDCounter;
					Items.Add(new DrillCalcItem(buShapeHole5));
					Items[Items.Count - 1].ID = IDCounter;
				}
			}
			if ((buShapeHole4.DrillType == drillTypes.ThreeHole) & (buShapeHole4.planeName == refPlane))
			{
				buShapeHole3 buShapeHole6 = Job.Items[i] as buShapeHole3;
				Point3D calcCenter = new Point3D();
				Point3D calcCenter2 = new Point3D();
				clsInit.cVector5.calcBuShapeHole3Point(buShapeHole6.CalculatedPoint, buShapeHole6.planeName, buShapeHole6.DistanceX, buShapeHole6.DistanceY, buShapeHole6.DiameterOutside, buShapeHole6.Hole3Angle, ref calcCenter, ref calcCenter2);
				buShapeHole buShapeHole7 = new buShapeHole(buShapeHole6.Diameter, buShapeHole6.Depth);
				buShapeHole7.CalculatedPoint = new Point3D(buShapeHole4.CalculatedPoint.X, buShapeHole4.CalculatedPoint.Y, buShapeHole4.CalculatedPoint.Z);
				buShapeHole7.planeName = buShapeHole4.planeName;
				buShapeHole7.ID = IDCounter;
				Items.Add(new DrillCalcItem(buShapeHole7));
				Items[Items.Count - 1].ID = IDCounter;
				buShapeHole7 = new buShapeHole(buShapeHole6.DiameterOutside, buShapeHole6.Depth);
				buShapeHole7.CalculatedPoint = new Point3D(calcCenter.X, calcCenter.Y, calcCenter.Z);
				buShapeHole7.planeName = buShapeHole4.planeName;
				buShapeHole7.ID = IDCounter;
				Items.Add(new DrillCalcItem(buShapeHole7));
				Items[Items.Count - 1].ID = IDCounter;
				buShapeHole7 = new buShapeHole(buShapeHole6.DiameterOutside, buShapeHole6.Depth);
				buShapeHole7.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter.Z);
				buShapeHole7.planeName = buShapeHole4.planeName;
				buShapeHole7.ID = IDCounter;
				Items.Add(new DrillCalcItem(buShapeHole7));
				Items[Items.Count - 1].ID = IDCounter;
			}
		}
	}

	public void doGetDrill(List<Entity> EL)
	{
		if (EL.Count <= 0)
		{
			if (JobList.Count > 0)
			{
				if (frmEdit == null)
				{
					frmEdit = new F_DrillEdit();
				}
				frmEdit.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				frmEdit.Init();
				frmEdit.ShowDialog();
				if (frmEdit.PropertiesForm.Result == DialogResult.OK)
				{
					JobList[selectedJobIndex] = activeJob;
					DrawPanelFromJobMainAndPreview(activeJob);
				}
			}
		}
		else
		{
			activeJob = new DrillJob();
			activeJob.Items.Clear();
			bool flag = false;
			bool flag2 = false;
			if (!(EL[0] is Brep))
			{
				if (EL[0] is ICurve)
				{
					flag = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (!flag2)
			{
				if (!flag)
				{
					buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[38]);
				}
				else
				{
					buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[38]);
				}
			}
			else if (EL[0] is Brep)
			{
				Brep brep = EL[0] as Brep;
				brep.Regen(0.01);
				brep.Translate(0.0 - brep.BoxMin.X, 0.0 - brep.BoxMin.Y, 0.0 - brep.BoxMin.Z);
				brep.Regen(0.01);
				double num = 1.0;
				if ((brep.BoxMax.Z > 0.0) & (brep.BoxMax.Z < 1.0))
				{
					double num2 = 10.0 / brep.BoxMax.Z;
					if (num2 > 1.0 && num2 <= 10.0)
					{
						num = 10.0;
					}
					if (num2 > 10.0 && num2 <= 100.0)
					{
						num = 100.0;
					}
					if (num2 > 100.0 && num2 <= 1000.0)
					{
						num = 1000.0;
					}
				}
				if (num > 1.0)
				{
					brep.Scale(num);
					brep.Regen(0.01);
				}
				activeJob = new DrillJob();
				if (JobList == null)
				{
					JobList = new List<DrillJob>();
				}
				JobList = new List<DrillJob>();
				SizeObject sizeObject = new SizeObject(brep.BoxMax.X - brep.BoxMin.X, brep.BoxMax.Y - brep.BoxMin.Y, brep.BoxMax.Z - brep.BoxMin.Z);
				activeJob.Material = new MaterialBase5(sizeObject);
				for (int i = 0; i <= brep.Faces.Length - 1; i++)
				{
					Brep.Face face = brep.Faces[i];
					if (face.Surface == null)
					{
						continue;
					}
					ICurve[] array = null;
					for (int j = 0; j <= face.Loops.Length - 1; j++)
					{
						array = new ICurve[face.Loops[j].Segments.Length];
						for (int k = 0; k <= face.Loops[j].Segments.Length - 1; k++)
						{
							Brep.OrientedEdge orientedEdge = face.Loops[j].Segments[k];
							Brep.Edge edge = brep.Edges[orientedEdge.CurveIndex];
							array[k] = edge.Curve;
						}
					}
					AnalyticSurf surface = face.Surface;
					Surface[] array2 = null;
					array2 = surface.GetSurface(array);
					if (!((array2 != null) & (array2.Length != 0)) || !(array2[0] is PlanarSurface))
					{
						continue;
					}
					PlanarSurface planarSurface = array2[0] as PlanarSurface;
					if (!((planarSurface.Plane.Equation.Z == 1.0) | (planarSurface.Plane.Equation.Z == -1.0)))
					{
						continue;
					}
					List<Entity> list = new List<Entity>();
					for (int l = 0; l <= array.Length - 1; l++)
					{
						if (array[l] is devDept.Eyeshot.Entities.Line || array[l] is LinearPath)
						{
							list.Add((Entity)array[l]);
						}
					}
					Point3D MinPoint = new Point3D();
					Point3D MidPoint = new Point3D();
					Point3D MaxPoint = new Point3D();
					if (list.Count <= 0)
					{
						continue;
					}
					clsInit.cVector5.BoxSizeCalculate(list, ref MinPoint, ref MidPoint, ref MaxPoint);
					double num3 = MaxPoint.X - MinPoint.X;
					double num4 = MaxPoint.Y - MinPoint.Y;
					double num5 = 0.0;
					double num6 = 0.0;
					bool flag3 = false;
					bool flag4 = false;
					bool isMilling = false;
					Point3D point3D = new Point3D();
					if (!(num3 < num4))
					{
						num5 = num4;
						num6 = num3;
						flag3 = true;
						point3D.X = MinPoint.X;
						point3D.Y = MidPoint.Y;
						point3D.Z = MinPoint.Z;
					}
					else
					{
						num5 = num3;
						num6 = num4;
						point3D.X = MidPoint.X;
						point3D.Y = MinPoint.Y;
						point3D.Z = MinPoint.Z;
					}
					for (int m = 0; m <= ToolList.Count - 1; m++)
					{
						if (ToolList[m].Purpose == ToolPurpose.Saw && buCompare5.EQ(ToolList[m].Geometry.Thickness, num5))
						{
							flag4 = true;
						}
						if (ToolList[m].Purpose == ToolPurpose.Milling && buCompare5.EQ(ToolList[m].Geometry.Diameter, num5))
						{
							flag4 = true;
							isMilling = true;
						}
					}
					if (!flag4)
					{
						continue;
					}
					buShapeCut buShapeCut2 = new buShapeCut();
					buShapeCut2.CutType = CutTypes.CutVertical;
					if (flag3)
					{
						buShapeCut2.CutType = CutTypes.CutHorizontal;
					}
					buShapeCut2.BasePoint.X = point3D.X;
					buShapeCut2.BasePoint.Y = point3D.Y;
					buShapeCut2.BasePoint.Z = point3D.X;
					buShapeCut2.Depth = sizeObject.Depth - point3D.Z;
					buShapeCut2.Diameter = num5;
					buShapeCut2.planeName = planeBoxNames.Top;
					buShapeCut2.planeOperation = clsInit.cVector5.PlaneNameToPlane(buShapeCut2.planeName);
					buShapeCut2.Enable = true;
					buShapeCut2.isMilling = isMilling;
					buShapeCut2.Length = num6;
					buShapeCut2.Angle = 0.0;
					buShapeCut2.Corner = CornerLocation.LeftTop;
					buShapeCut2.Alignment = ObjectAlignment.MiddleLeft;
					clsVar5.shapeCreatePar.Solid = true;
					clsVar5.shapeCreatePar.Size = new SizeObject(sizeObject);
					clsVar5.shapeCreatePar.SingX = -1.0;
					clsVar5.shapeCreatePar.SingY = -1.0;
					buShape Shape = buShapeCut2;
					clsInit.cVector5.CreatebuShape(ref Shape, clsVar5.shapeCreatePar);
					if (activeJob.Items.Count != 0)
					{
						bool flag5 = false;
						for (int n = 0; n <= activeJob.Items.Count - 1; n++)
						{
							if (buShape.isSame(activeJob.Items[n], Shape))
							{
								flag5 = true;
							}
						}
						if (!flag5)
						{
							activeJob.Items.Add(Shape);
						}
					}
					else
					{
						activeJob.Items.Add(Shape);
					}
				}
				for (int num7 = 0; num7 <= brep.Edges.Length - 1; num7++)
				{
					Brep.Edge edge2 = brep.Edges[num7];
					ICurve curve = edge2.Curve;
					if (!(curve is Circle))
					{
						if (curve is devDept.Eyeshot.Entities.Line)
						{
							devDept.Eyeshot.Entities.Line line = curve as devDept.Eyeshot.Entities.Line;
							if (line.Direction.X == 0.0)
							{
							}
						}
						continue;
					}
					Circle circle = curve as Circle;
					if (circle.Plane.Equation.Z == 1.0)
					{
						List<Entity> list2 = new List<Entity>();
						if (!buCompare5.EQ(circle.Center.Z, activeJob.Material.Size.Depth, 0.1))
						{
							if (circle.Center.Z < activeJob.Material.Size.Depth)
							{
								for (int num8 = 0; num8 <= edge2.Parents.Length - 1; num8++)
								{
									int num9 = edge2.Parents[num8];
									Brep.Face face2 = brep.Faces[num9];
									for (int num10 = 0; num10 <= face2.Loops.Length - 1; num10++)
									{
										for (int num11 = 0; num11 <= face2.Loops[num10].Segments.Length - 1; num11++)
										{
											Brep.OrientedEdge orientedEdge2 = face2.Loops[num10].Segments[num11];
											Brep.Edge edge3 = brep.Edges[orientedEdge2.CurveIndex];
											list2.Add((Entity)edge3.Curve);
										}
									}
								}
							}
						}
						else
						{
							for (int num12 = 0; num12 <= edge2.Parents.Length - 1; num12++)
							{
								int num13 = edge2.Parents[num12];
								Brep.Face face3 = brep.Faces[num13];
								for (int num14 = 0; num14 <= face3.Loops.Length - 1; num14++)
								{
									for (int num15 = 0; num15 <= face3.Loops[num14].Segments.Length - 1; num15++)
									{
										Brep.OrientedEdge orientedEdge3 = face3.Loops[num14].Segments[num15];
										Brep.Edge edge4 = brep.Edges[orientedEdge3.CurveIndex];
										list2.Add((Entity)edge4.Curve);
									}
								}
							}
						}
						if (list2.Count > 0)
						{
							Point3D MinPoint2 = new Point3D();
							Point3D MaxPoint2 = new Point3D();
							clsInit.cVector5.BoxSizeCalculate(list2, ref MinPoint2, ref MaxPoint2);
							buShapeHole buShapeHole4 = new buShapeHole();
							buShapeHole4.DrillType = drillTypes.SingleHole;
							buShapeHole4.BasePoint.X = circle.Center.X;
							buShapeHole4.BasePoint.Y = circle.Center.Y;
							buShapeHole4.BasePoint.Z = circle.Center.Z;
							buShapeHole4.Depth = activeJob.Material.Size.Depth - MinPoint2.Z;
							buShapeHole4.Diameter = circle.Radius * 2.0;
							buShapeHole4.planeName = planeBoxNames.Top;
							buShapeHole4.planeOperation = Plane.XY;
							buShapeHole4.Enable = true;
							buShapeHole4.isMilling = false;
							buShapeHole4.Corner = CornerLocation.LeftBottom;
							buShapeHole4.Alignment = ObjectAlignment.MiddleCenter;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(activeJob.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape2 = buShapeHole4;
							clsInit.cVector5.CreatebuShape(ref Shape2, clsVar5.shapeCreatePar);
							if (activeJob.Items.Count != 0)
							{
								bool flag6 = false;
								for (int num16 = 0; num16 <= activeJob.Items.Count - 1; num16++)
								{
									if (buShape.isSame(activeJob.Items[num16], Shape2))
									{
										flag6 = true;
									}
								}
								if (!flag6)
								{
									activeJob.Items.Add(Shape2);
								}
							}
							else
							{
								activeJob.Items.Add(Shape2);
							}
						}
					}
					if ((circle.Plane.Equation.Y == 1.0) | (circle.Plane.Equation.Y == -1.0))
					{
						List<Entity> list3 = new List<Entity>();
						planeBoxNames planeName = planeBoxNames.Front;
						if (buCompare5.EQ(circle.Center.Y, activeJob.Material.Size.Height, 0.1) | buCompare5.EQ(circle.Center.Y, 0.0, 0.1))
						{
							if (buCompare5.EQ(circle.Center.Y, activeJob.Material.Size.Height, 0.1))
							{
								planeName = planeBoxNames.Front;
							}
							if (buCompare5.EQ(circle.Center.Y, 0.0, 0.1))
							{
								planeName = planeBoxNames.Back;
							}
							for (int num17 = 0; num17 <= edge2.Parents.Length - 1; num17++)
							{
								int num18 = edge2.Parents[num17];
								Brep.Face face4 = brep.Faces[num18];
								for (int num19 = 0; num19 <= face4.Loops.Length - 1; num19++)
								{
									for (int num20 = 0; num20 <= face4.Loops[num19].Segments.Length - 1; num20++)
									{
										Brep.OrientedEdge orientedEdge4 = face4.Loops[num19].Segments[num20];
										Brep.Edge edge5 = brep.Edges[orientedEdge4.CurveIndex];
										list3.Add((Entity)edge5.Curve);
									}
								}
							}
						}
						if (list3.Count > 0)
						{
							Point3D MinPoint3 = new Point3D();
							Point3D MaxPoint3 = new Point3D();
							clsInit.cVector5.BoxSizeCalculate(list3, ref MinPoint3, ref MaxPoint3);
							double num21 = 0.0;
							if (buCompare5.EQ(circle.Center.Y, activeJob.Material.Size.Height, 0.1))
							{
								num21 = activeJob.Material.Size.Height - MinPoint3.Y;
							}
							if (buCompare5.EQ(circle.Center.Y, 0.0, 0.1))
							{
								num21 = MaxPoint3.Y;
							}
							if (num21 <= 0.01)
							{
								num21 = 0.1;
							}
							buShapeHole buShapeHole5 = new buShapeHole();
							buShapeHole5.DrillType = drillTypes.SingleHole;
							buShapeHole5.BasePoint.X = circle.Center.X;
							buShapeHole5.BasePoint.Y = circle.Center.Y;
							buShapeHole5.BasePoint.Z = circle.Center.Z;
							buShapeHole5.Depth = num21;
							buShapeHole5.Diameter = circle.Radius * 2.0;
							buShapeHole5.planeName = planeName;
							buShapeHole5.planeOperation = Plane.XZ;
							buShapeHole5.Enable = true;
							buShapeHole5.isMilling = false;
							buShapeHole5.Corner = CornerLocation.LeftBottom;
							buShapeHole5.Alignment = ObjectAlignment.MiddleCenter;
							clsVar5.shapeCreatePar.Solid = true;
							clsVar5.shapeCreatePar.Size = new SizeObject(activeJob.Material.Size);
							clsVar5.shapeCreatePar.SingX = -1.0;
							clsVar5.shapeCreatePar.SingY = -1.0;
							buShape Shape3 = buShapeHole5;
							clsInit.cVector5.CreatebuShape(ref Shape3, clsVar5.shapeCreatePar);
							if (activeJob.Items.Count != 0)
							{
								bool flag7 = false;
								for (int num22 = 0; num22 <= activeJob.Items.Count - 1; num22++)
								{
									if (buShape.isSame(activeJob.Items[num22], Shape3))
									{
										flag7 = true;
									}
								}
								if (!flag7)
								{
									activeJob.Items.Add(Shape3);
								}
							}
							else
							{
								activeJob.Items.Add(Shape3);
							}
						}
					}
					if (!((circle.Plane.Equation.X == 1.0) | (circle.Plane.Equation.X == -1.0)))
					{
						continue;
					}
					new DrillItem();
					planeBoxNames planeName2 = planeBoxNames.Left;
					List<Entity> list4 = new List<Entity>();
					if (buCompare5.EQ(circle.Center.X, activeJob.Material.Size.Width, 0.1) | buCompare5.EQ(circle.Center.X, 0.0, 0.1))
					{
						if (buCompare5.EQ(circle.Center.X, activeJob.Material.Size.Width, 0.1))
						{
							planeName2 = planeBoxNames.Right;
						}
						if (buCompare5.EQ(circle.Center.X, 0.0, 0.1))
						{
							planeName2 = planeBoxNames.Left;
						}
						for (int num23 = 0; num23 <= edge2.Parents.Length - 1; num23++)
						{
							int num24 = edge2.Parents[num23];
							Brep.Face face5 = brep.Faces[num24];
							for (int num25 = 0; num25 <= face5.Loops.Length - 1; num25++)
							{
								for (int num26 = 0; num26 <= face5.Loops[num25].Segments.Length - 1; num26++)
								{
									Brep.OrientedEdge orientedEdge5 = face5.Loops[num25].Segments[num26];
									Brep.Edge edge6 = brep.Edges[orientedEdge5.CurveIndex];
									list4.Add((Entity)edge6.Curve);
								}
							}
						}
					}
					if (list4.Count <= 0)
					{
						continue;
					}
					Point3D MinPoint4 = new Point3D();
					Point3D MaxPoint4 = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(list4, ref MinPoint4, ref MaxPoint4);
					double num27 = 0.0;
					if (buCompare5.EQ(circle.Center.X, activeJob.Material.Size.Width, 0.1))
					{
						num27 = activeJob.Material.Size.Width - MinPoint4.X;
					}
					if (buCompare5.EQ(circle.Center.X, 0.0, 0.1))
					{
						num27 = MaxPoint4.X;
					}
					if (num27 <= 0.01)
					{
						num27 = 0.1;
					}
					buShapeHole buShapeHole6 = new buShapeHole();
					buShapeHole6.DrillType = drillTypes.SingleHole;
					buShapeHole6.BasePoint.X = circle.Center.X;
					buShapeHole6.BasePoint.Y = circle.Center.Y;
					buShapeHole6.BasePoint.Z = circle.Center.Z;
					buShapeHole6.Depth = num27;
					buShapeHole6.Diameter = circle.Radius * 2.0;
					buShapeHole6.planeName = planeName2;
					buShapeHole6.planeOperation = Plane.YZ;
					buShapeHole6.Enable = true;
					buShapeHole6.isMilling = false;
					buShapeHole6.Corner = CornerLocation.LeftBottom;
					buShapeHole6.Alignment = ObjectAlignment.MiddleCenter;
					clsVar5.shapeCreatePar.Solid = true;
					clsVar5.shapeCreatePar.Size = new SizeObject(activeJob.Material.Size);
					clsVar5.shapeCreatePar.SingX = -1.0;
					clsVar5.shapeCreatePar.SingY = -1.0;
					buShape Shape4 = buShapeHole6;
					clsInit.cVector5.CreatebuShape(ref Shape4, clsVar5.shapeCreatePar);
					if (activeJob.Items.Count != 0)
					{
						bool flag8 = false;
						for (int num28 = 0; num28 <= activeJob.Items.Count - 1; num28++)
						{
							if (buShape.isSame(activeJob.Items[num28], Shape4))
							{
								flag8 = true;
							}
						}
						if (!flag8)
						{
							activeJob.Items.Add(Shape4);
						}
					}
					else
					{
						activeJob.Items.Add(Shape4);
					}
				}
				if (activeJob.Material.Entities.Count == 0)
				{
					Entity Ent = null;
					clsInit.cVector5.CreateMaterialEntities(activeJob.Material, ref Ent);
					clsInit.cVector5.Move(0.0 - activeJob.Material.Size.Width, 0.0 - activeJob.Material.Size.Height, 0.0, ref Ent);
					activeJob.Material.Entities.Add(Ent);
					activeJob.panelEntity = Ent;
				}
				activeJob.Material.Sing = new Point3D(clsVar5.shapeCreatePar.SingX, clsVar5.shapeCreatePar.SingY, 1.0);
				JobUpdate(FillPages: true, null);
				DrawPanelFromJobMainAndPreview(activeJob);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.Dimetric);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit();
			}
		}
		if (!varDrillSettings.DeleteDrawingAfterChangeToJob)
		{
			clsInit.appCommand.Reset();
		}
		else
		{
			clsInit.appCommand.Delete(applyReset: true);
		}
	}

	public void doReset()
	{
		if (shapeRuntimeData_0 != null)
		{
			clsVar5.ShapeDataParameters = new ShapeRuntimeData(shapeRuntimeData_0);
		}
		UpdateSelectedOperation(new ViewportDrawOptions(ViewportRefType.Main, -1, -1));
		shapeRuntimeData_0 = null;
		operationErrorList.Clear();
		calcErrorList.Clear();
		EditOperation = false;
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
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (Job.Items[i] is buShapeHole)
			{
				buShapeHole buShapeHole4 = Job.Items[i] as buShapeHole;
				if (buShapeHole4.Enable)
				{
					if (buShapeHole4.planeName == planeBoxNames.Back)
					{
						Job.isClamperSideDrillOpAvailable = true;
					}
					if (buShapeHole4.DrillType == drillTypes.SingleHole)
					{
						if (buShapeHole4.isMilling)
						{
							DrillItem drillItem = new DrillItem((buShapeHole)Job.Items[i]);
							drillItem.isDrill = true;
							Job.ItemShape.Add(drillItem);
						}
						else
						{
							Job.ItemCalc.Add(new DrillCalcItem(buShapeHole4));
							Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
							if (Job.Items[i].BasePoint.Y < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
							{
								Job.isClamperSideDrillOpAvailable = true;
							}
							IDCounter++;
						}
					}
					if ((buShapeHole4.DrillType == drillTypes.HorizontalHoles) | (buShapeHole4.DrillType == drillTypes.HorizontalLineHoles) | (buShapeHole4.DrillType == drillTypes.VerticalHoles) | (buShapeHole4.DrillType == drillTypes.VerticalLineHoles) | (buShapeHole4.DrillType == drillTypes.InclineHoles))
					{
						if (buShapeHole4.isMilling)
						{
							for (int j = 0; j <= buShapeHole4.multiCenter.Count - 1; j++)
							{
								buShapeHole buShapeHole5 = new buShapeHole(buShapeHole4.Diameter, buShapeHole4.Depth);
								buShapeHole5.CalculatedPoint = new Point3D(buShapeHole4.multiCenter[j].Center.X, buShapeHole4.multiCenter[j].Center.Y, buShapeHole4.multiCenter[j].Center.Z);
								buShapeHole5.ItemSize.MinBox = new Point3D(buShapeHole4.multiCenter[j].Center.X - buShapeHole4.Diameter / 2.0, buShapeHole4.multiCenter[j].Center.Y - buShapeHole4.Diameter / 2.0);
								buShapeHole5.ItemSize.MaxBox = new Point3D(buShapeHole4.multiCenter[j].Center.X + buShapeHole4.Diameter / 2.0, buShapeHole4.multiCenter[j].Center.Y + buShapeHole4.Diameter / 2.0);
								buShapeHole5.planeName = buShapeHole4.planeName;
								Job.ItemShape.Add(new DrillItem(buShapeHole5));
							}
						}
						else
						{
							for (int k = 0; k <= buShapeHole4.multiCenter.Count - 1; k++)
							{
								buShapeHole buShapeHole6 = new buShapeHole(buShapeHole4.Diameter, buShapeHole4.Depth);
								buShapeHole6.CalculatedPoint = new Point3D(buShapeHole4.multiCenter[k].Center.X, buShapeHole4.multiCenter[k].Center.Y, buShapeHole4.multiCenter[k].Center.Z);
								buShapeHole6.planeName = buShapeHole4.planeName;
								buShapeHole6.ID = IDCounter;
								Job.ItemCalc.Add(new DrillCalcItem(buShapeHole6));
								Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
								if (Math.Abs(buShapeHole4.multiCenter[k].Center.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
								{
									Job.isClamperSideDrillOpAvailable = true;
								}
								IDCounter++;
							}
						}
					}
					if (buShapeHole4.DrillType == drillTypes.ThreeHole)
					{
						buShapeHole3 buShapeHole7 = Job.Items[i] as buShapeHole3;
						Point3D calcCenter = new Point3D();
						Point3D calcCenter2 = new Point3D();
						clsInit.cVector5.calcBuShapeHole3Point(buShapeHole7.CalculatedPoint, buShapeHole7.planeName, buShapeHole7.DistanceX, buShapeHole7.DistanceY, buShapeHole7.DiameterOutside, buShapeHole7.Hole3Angle, ref calcCenter, ref calcCenter2);
						buShapeHole buShapeHole8 = new buShapeHole(buShapeHole7.Diameter, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(buShapeHole4.CalculatedPoint.X, buShapeHole4.CalculatedPoint.Y, buShapeHole4.CalculatedPoint.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
						buShapeHole8 = new buShapeHole(buShapeHole7.DiameterOutside, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(calcCenter.X, calcCenter.Y, calcCenter.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
						buShapeHole8 = new buShapeHole(buShapeHole7.DiameterOutside, buShapeHole7.Depth);
						buShapeHole8.CalculatedPoint = new Point3D(calcCenter2.X, calcCenter2.Y, calcCenter.Z);
						buShapeHole8.planeName = buShapeHole4.planeName;
						buShapeHole8.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole8));
						Job.ItemCalc[Job.ItemCalc.Count - 1].ID = IDCounter;
						IDCounter++;
						if (Math.Abs(buShapeHole8.CalculatedPoint.Y) < varDrillCNCSettings.ClamperCatchWidth && buShapeHole4.planeName != planeBoxNames.Back)
						{
							Job.isClamperSideDrillOpAvailable = true;
						}
					}
				}
			}
			if ((Job.Items[i] is buShapeCut) & Job.Items[i].Enable)
			{
				buShapeCut buShapeCut2 = Job.Items[i] as buShapeCut;
				if (!(((buShapeCut2.CutType == CutTypes.CutHorizontal) | (buShapeCut2.CutType == CutTypes.CutHorizontalLine)) & !buShapeCut2.isMilling))
				{
					if (!((buShapeCut2.CutType == CutTypes.CutVertical) | (buShapeCut2.CutType == CutTypes.CutVerticalLine) | (buShapeCut2.CutType == CutTypes.CutFree)))
					{
						DrillItem drillItem2 = new DrillItem((buShapeCut)Job.Items[i]);
						if (!(0.0 - buShapeCut2.CalculatedPoint.Y < varDrillCNCSettings.ClamperCatchWidth + buShapeCut2.Diameter / 2.0))
						{
							Job.ItemShape.Add(new DrillItem((buShapeCut)Job.Items[i]));
						}
						else if (!(buShapeCut2.Length < Job.Material.Size.Width * 0.25))
						{
							List<Point3D> list = new List<Point3D>();
							List<Point3D> PointsDevided = new List<Point3D>();
							list.Add(buVector5.ToPoint3D(drillItem2.camEntities[0][0].StartPoint));
							list.Add(buVector5.ToPoint3D(drillItem2.camEntities[0][0].EndPoint));
							double num = 6.0;
							if (activeJob.Material.Size.Width > 1000.0)
							{
								num = 8.0;
							}
							if (activeJob.Material.Size.Width > 2000.0)
							{
								num = 12.0;
							}
							clsInit.cVector5.DevidePointsByLength(list, buShapeCut2.Length / num, ref PointsDevided);
							if (PointsDevided.Count > 0)
							{
								drillItem2.camEntities[0].Clear();
								DrillItem drillItem3 = new DrillItem(drillItem2);
								drillItem3.camEntities = new List<List<buEntity>>();
								List<buEntity> list2 = new List<buEntity>();
								buLine item = new buLine(PointsDevided[0], PointsDevided[1]);
								list2.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list2, ref drillItem3.BoxMinOfDrawing, ref drillItem3.BoxMaxOfDrawing);
								drillItem3.BoxMinItem = new Point3D(0.0 - drillItem3.BoxMaxOfDrawing.X, 0.0 - drillItem3.BoxMaxOfDrawing.Y, drillItem3.BoxMinOfDrawing.Z);
								drillItem3.BoxMaxItem = new Point3D(0.0 - drillItem3.BoxMinOfDrawing.X, 0.0 - drillItem3.BoxMinOfDrawing.Y, drillItem3.BoxMaxOfDrawing.Z);
								drillItem3.camEntities.Add(list2);
								Job.ItemShape.Add(drillItem3);
								drillItem3 = new DrillItem(drillItem2);
								drillItem3.camEntities = new List<List<buEntity>>();
								list2 = new List<buEntity>();
								item = new buLine(PointsDevided[1], PointsDevided[2]);
								list2.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list2, ref drillItem3.BoxMinOfDrawing, ref drillItem3.BoxMaxOfDrawing);
								drillItem3.BoxMinItem = new Point3D(0.0 - drillItem3.BoxMaxOfDrawing.X, 0.0 - drillItem3.BoxMaxOfDrawing.Y, drillItem3.BoxMinOfDrawing.Z);
								drillItem3.BoxMaxItem = new Point3D(0.0 - drillItem3.BoxMinOfDrawing.X, 0.0 - drillItem3.BoxMinOfDrawing.Y, drillItem3.BoxMaxOfDrawing.Z);
								drillItem3.camEntities.Add(list2);
								Job.ItemShape.Add(drillItem3);
								drillItem3 = new DrillItem(drillItem2);
								drillItem3.camEntities = new List<List<buEntity>>();
								list2 = new List<buEntity>();
								item = new buLine(PointsDevided[2], PointsDevided[PointsDevided.Count - 3]);
								list2.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list2, ref drillItem3.BoxMinOfDrawing, ref drillItem3.BoxMaxOfDrawing);
								drillItem3.BoxMinItem = new Point3D(0.0 - drillItem3.BoxMaxOfDrawing.X, 0.0 - drillItem3.BoxMaxOfDrawing.Y, drillItem3.BoxMinOfDrawing.Z);
								drillItem3.BoxMaxItem = new Point3D(0.0 - drillItem3.BoxMinOfDrawing.X, 0.0 - drillItem3.BoxMinOfDrawing.Y, drillItem3.BoxMaxOfDrawing.Z);
								drillItem3.camEntities.Add(list2);
								Job.ItemShape.Add(drillItem3);
								drillItem3 = new DrillItem(drillItem2);
								drillItem3.camEntities = new List<List<buEntity>>();
								list2 = new List<buEntity>();
								item = new buLine(PointsDevided[PointsDevided.Count - 3], PointsDevided[PointsDevided.Count - 2]);
								list2.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list2, ref drillItem3.BoxMinOfDrawing, ref drillItem3.BoxMaxOfDrawing);
								drillItem3.BoxMinItem = new Point3D(0.0 - drillItem3.BoxMaxOfDrawing.X, 0.0 - drillItem3.BoxMaxOfDrawing.Y, drillItem3.BoxMinOfDrawing.Z);
								drillItem3.BoxMaxItem = new Point3D(0.0 - drillItem3.BoxMinOfDrawing.X, 0.0 - drillItem3.BoxMinOfDrawing.Y, drillItem3.BoxMaxOfDrawing.Z);
								drillItem3.camEntities.Add(list2);
								Job.ItemShape.Add(drillItem3);
								drillItem3 = new DrillItem(drillItem2);
								drillItem3.camEntities = new List<List<buEntity>>();
								list2 = new List<buEntity>();
								item = new buLine(PointsDevided[PointsDevided.Count - 2], PointsDevided[PointsDevided.Count - 1]);
								list2.Add(item);
								clsInit.cVector5.BoxSizeCalculate(list2, ref drillItem3.BoxMinOfDrawing, ref drillItem3.BoxMaxOfDrawing);
								drillItem3.BoxMinItem = new Point3D(0.0 - drillItem3.BoxMaxOfDrawing.X, 0.0 - drillItem3.BoxMaxOfDrawing.Y, drillItem3.BoxMinOfDrawing.Z);
								drillItem3.BoxMaxItem = new Point3D(0.0 - drillItem3.BoxMinOfDrawing.X, 0.0 - drillItem3.BoxMinOfDrawing.Y, drillItem3.BoxMaxOfDrawing.Z);
								drillItem3.camEntities.Add(list2);
								Job.ItemShape.Add(drillItem3);
							}
						}
						else
						{
							Job.ItemShape.Add(new DrillItem((buShapeCut)Job.Items[i]));
						}
					}
					else
					{
						Job.ItemShape.Add(new DrillItem((buShapeCut)Job.Items[i]));
					}
				}
				else
				{
					Job.ItemCalc.Add(new DrillCalcItem(buShapeCut2));
				}
			}
			if ((Job.Items[i].ShapeGroup == ShapeGroup.Shape) & Job.Items[i].Enable)
			{
				Job.ItemShape.Add(new DrillItem(Job.Items[i]));
			}
			if ((Job.Items[i].ShapeGroup == ShapeGroup.Profiling) & Job.Items[i].Enable)
			{
				Job.ItemShape.Add(new DrillItem((buShapeProfiling)Job.Items[i]));
			}
			if ((Job.Items[i] is buShapeJunction) & Job.Items[i].Enable)
			{
				buShapeJunction buShapeJunction2 = Job.Items[i] as buShapeJunction;
				if (buShapeJunction2.Enable)
				{
					for (int l = 0; l <= buShapeJunction2.multiCenter.Count - 1; l++)
					{
						buShapeHole buShapeHole9 = new buShapeHole(buShapeJunction2.multiCenter[l].Diameter, buShapeJunction2.Depth);
						buShapeHole9.CalculatedPoint = new Point3D(buShapeJunction2.multiCenter[l].Center.X, buShapeJunction2.multiCenter[l].Center.Y, buShapeJunction2.multiCenter[l].Center.Z);
						buShapeHole9.planeName = buShapeJunction2.planeName;
						buShapeHole9.ID = IDCounter;
						Job.ItemCalc.Add(new DrillCalcItem(buShapeHole9));
						IDCounter++;
					}
				}
			}
			if ((Job.Items[i].ShapeGroup == ShapeGroup.Engraving) & Job.Items[i].Enable)
			{
				Job.ItemShape.Add(new DrillItem((buShapeEngrave)Job.Items[i]));
			}
		}
		SortJobItems(ref Job);
		Job.isSorted = true;
		for (int m = 0; m <= Job.ItemCalc.Count - 1; m++)
		{
			Job.ItemCalc[m].Calculated = false;
		}
	}
}
