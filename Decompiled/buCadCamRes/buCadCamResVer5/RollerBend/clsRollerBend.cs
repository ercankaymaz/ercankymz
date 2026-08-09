using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.RollerBend;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.RollerBend;

public class clsRollerBend
{
	private string string_0 = "clsRollerBend";

	public static Design viewportAuto = null;

	public Plane planeActive = Plane.XY;

	public int indexSim = -1;

	public static List<int> SimMovePartIndex = new List<int>();

	public static List<Entity> SimToCollsionCheck1 = new List<Entity>();

	public static List<Entity> SimToCollsionCheck2 = new List<Entity>();

	public Timer timSim = null;

	public F_RollerMachSim frmMachSim = null;

	public RollerJob activeJob = null;

	public RollerBendMove activeMove = new RollerBendMove();

	public void Init()
	{
		clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
	}

	public void InitSimulation()
	{
		if (frmMachSim == null)
		{
			frmMachSim = new F_RollerMachSim();
		}
		timSim = new Timer();
		timSim.Tick += tick_Simulation;
		if (viewportAuto != null)
		{
			return;
		}
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
		viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		viewportAuto.ProgressBar.Visible = false;
		viewportAuto.WaitCursorMode = waitCursorType.Never;
		viewportAuto.MouseMove += method_0;
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
		}
	}

	public void cmdSetView(viewType Type)
	{
		switch (Type)
		{
		default:
			buEyeShotFunctions.ViewIso(ref viewportAuto, isZoomFit: false);
			planeActive = Plane.XY;
			break;
		case viewType.Top:
			buEyeShotFunctions.ViewTop(ref viewportAuto, isZoomFit: false);
			planeActive = Plane.XY;
			break;
		case viewType.Bottom:
			buEyeShotFunctions.ShowViewportViewBox(ref viewportAuto, Show: false);
			planeActive = Plane.XY;
			break;
		case viewType.Front:
			buEyeShotFunctions.Viewfront(ref viewportAuto, isZoomFit: false);
			planeActive = Plane.XZ;
			break;
		case viewType.Rear:
			buEyeShotFunctions.ViewBack(ref viewportAuto, isZoomFit: false);
			planeActive = Plane.XZ;
			break;
		case viewType.Left:
			buEyeShotFunctions.ViewLeft(ref viewportAuto, isZoomFit: false);
			planeActive = Plane.YZ;
			break;
		case viewType.Right:
			buEyeShotFunctions.ViewRight(ref viewportAuto, isZoomFit: false);
			planeActive = Plane.YZ;
			break;
		}
	}

	public void cmdZoomFit()
	{
		buEyeShotFunctions.ZoomFit(ref viewportAuto);
	}

	public void cmdSimilation()
	{
		frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		frmMachSim.Init();
		frmMachSim.StartPosition = FormStartPosition.CenterParent;
		DrawEntities(ZoomFit: true);
		frmMachSim.ShowDialog();
		if (frmMachSim.PropertiesForm.Result == DialogResult.OK)
		{
		}
	}

	public void cmdStartSimulation(bool Step)
	{
		timSim.Interval = buRollerBendCalc.varRollerBendSetting.SimulationIntervalMs;
		buRollerBendCalc.varRollerBendRuntime.StepRun = Step;
		if (!viewportAuto.IsAnimationRunning)
		{
			viewportAuto.StartAnimation(buRollerBendCalc.varRollerBendSetting.SimulationIntervalMs);
		}
		if (indexSim == -1)
		{
			indexSim = 0;
		}
		timSim.Enabled = true;
		if (Step)
		{
			if (!(buRollerBendCalc.varRollerBendRuntime.StepRun && Step))
			{
			}
		}
		else
		{
			buRollerBendCalc.varRollerBendRuntime.StepRun = false;
			viewportAuto.Entities.ClearSelection();
			viewportAuto.Invalidate();
		}
	}

	public void cmdStopSimulation()
	{
		if (!timSim.Enabled)
		{
			indexSim = 0;
			timSim.Enabled = false;
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
			indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
			indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
			tick_Simulation(null, null);
		}
	}

	public void cmdCircle()
	{
		F_RollerCircle f_RollerCircle = new F_RollerCircle();
		f_RollerCircle.Diameter = buRollerBendCalc.varRollerBendRuntime.CircleDiameter;
		f_RollerCircle.Length = buRollerBendCalc.varRollerBendRuntime.CircleLength;
		f_RollerCircle.Thickness = buRollerBendCalc.varRollerBendRuntime.CircleThickness;
		f_RollerCircle.Init();
		f_RollerCircle.ShowDialog();
		if (f_RollerCircle.Properties.Result == DialogResult.OK)
		{
			buRollerBendCalc.varRollerBendRuntime.CircleDiameter = f_RollerCircle.Diameter;
			buRollerBendCalc.varRollerBendRuntime.CircleLength = f_RollerCircle.Length;
			buRollerBendCalc.varRollerBendRuntime.CircleThickness = f_RollerCircle.Thickness;
			doCircle(buRollerBendCalc.varRollerBendRuntime.CircleDiameter, buRollerBendCalc.varRollerBendRuntime.CircleThickness, buRollerBendCalc.varRollerBendRuntime.CircleLength);
		}
	}

	public void tick_Simulation(object sender, EventArgs e)
	{
		if (!((indexSim >= 0) & (indexSim <= activeJob.SimulationMoves.Count - 1)))
		{
			indexSim = -1;
			timSim.Enabled = false;
			return;
		}
		if ((indexSim >= 0) & (indexSim <= activeJob.SimulationMoves.Count - 1))
		{
			if (!AppBool.Connected)
			{
				activeMove = activeJob.SimulationMoves[indexSim];
			}
			if (activeMove.Command != RollerBendMoveCommand.CreateMaterial)
			{
				if (!((activeMove.Command == RollerBendMoveCommand.MoveBend) | (activeMove.Command == RollerBendMoveCommand.MoveMaterial)))
				{
					MoveSimPart(activeMove);
				}
				else
				{
					int num = Convert.ToInt32(activeMove.XPosition);
					if (viewportAuto.Entities.Count > 3)
					{
						Entity entity = viewportAuto.Entities[viewportAuto.Entities.Count - 1];
						if (entity is Mesh && entity.EntityData != null && entity.EntityData is CustomData && ((((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Temp) | (((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Sheet)))
						{
							entity.Selected = true;
							viewportAuto.Entities.DeleteSelected();
						}
						entity = viewportAuto.Entities[viewportAuto.Entities.Count - 2];
						if (entity is Mesh && entity.EntityData != null && entity.EntityData is CustomData && ((((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Temp) | (((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Sheet)))
						{
							entity.Selected = true;
							viewportAuto.Entities.DeleteSelected();
						}
						entity = viewportAuto.Entities[viewportAuto.Entities.Count - 3];
						if (entity is Mesh && entity.EntityData != null && entity.EntityData is CustomData && ((((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Temp) | (((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Sheet)))
						{
							entity.Selected = true;
							viewportAuto.Entities.DeleteSelected();
						}
					}
					if (num >= activeJob.matPoints.Count)
					{
						num = activeJob.matPoints.Count - 1;
					}
					if ((num >= 0) & (num <= activeJob.matPoints.Count - 1) & (activeMove.Command == RollerBendMoveCommand.MoveBend))
					{
						List<Point3D> list = new List<Point3D>();
						new List<Point3D>();
						int num2 = 2;
						if (num <= 500)
						{
							if (num > 1000)
							{
								num2 = 6;
							}
						}
						else
						{
							num2 = 4;
						}
						for (int i = 0; i <= num; i += num2)
						{
							list.Add(activeJob.matPoints[i]);
						}
						if (!buCompare5.EQ(list[list.Count - 1], activeJob.matPoints[num]))
						{
							list.Add(activeJob.matPoints[num]);
						}
						if (list.Count > 3)
						{
							LinearPath linearPath = new LinearPath(list);
							devDept.Eyeshot.Entities.Region region = linearPath.OffsetToRegion(activeJob.Thickness, sharp: false);
							Mesh mesh = region.ExtrudeAsMesh(new Vector3D(0.0, activeJob.SheetWidth, 0.0), 2.5, Mesh.natureType.RichSmooth);
							mesh.Color = Color.SteelBlue;
							mesh.ColorMethod = colorMethodType.byEntity;
							CustomData customData = new CustomData();
							customData.typeDefination = entityTypeDefination.Temp;
							mesh.EntityData = customData;
							viewportAuto.Entities.Add(mesh);
							viewportAuto.Invalidate();
						}
					}
					double num3 = activeJob.TotalBendingLength;
					if ((activeMove.XPosition > 0.0) & (activeMove.Command == RollerBendMoveCommand.MoveBend))
					{
						num3 = activeJob.TotalBendingLength - activeMove.XPosition;
					}
					if (num3 > 0.1)
					{
						CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(Plane.XZ, num3, activeJob.Thickness);
						compositeCurve.Translate(0.0 - activeJob.TotalBendingLength + activeMove.XPosition, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0);
						if (activeMove.LeftAngle != 0.0)
						{
							compositeCurve.Rotate(buConversion5.DegreeToRadian(activeMove.LeftAngle + 1.0), Vector3D.AxisY, new Point3D(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0));
						}
						devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(compositeCurve);
						Mesh mesh2 = region2.ExtrudeAsMesh(new Vector3D(0.0, activeJob.SheetWidth, 0.0), 0.5, Mesh.natureType.RichSmooth);
						mesh2.Color = Color.SteelBlue;
						mesh2.ColorMethod = colorMethodType.byEntity;
						CustomData customData2 = new CustomData();
						customData2.typeDefination = entityTypeDefination.Sheet;
						mesh2.EntityData = customData2;
						viewportAuto.Entities.Add(mesh2);
						viewportAuto.Invalidate();
					}
					MoveSimPart(activeMove);
				}
			}
			else
			{
				AddMaterial(activeJob.solidEntity);
			}
			if (frmMachSim == null)
			{
			}
		}
		indexSim += buRollerBendCalc.varRollerBendRuntime.SimStep;
	}

	public void MoveSimPart(RollerBendMove pntMove)
	{
		for (int i = 0; i <= SimMovePartIndex.Count - 1; i++)
		{
			if (!((viewportAuto.Entities.Count > 0) & (SimMovePartIndex[i] <= viewportAuto.Entities.Count - 1)))
			{
				continue;
			}
			CustomData customData = viewportAuto.Entities[SimMovePartIndex[i]].EntityData as CustomData;
			KinematicBase5 kinematicBase = new KinematicBase5();
			kinematicBase.RotateCenterOffsetOfA.Z = 171.0;
			kinematicBase.Type = KinemeticType.CartezianXYZ_WristA_4Axis;
			new Pnt6D();
			new Point3D();
			_ = SimMovePartIndex[i];
			if (!((SimMovePartIndex[i] >= 0) & (SimMovePartIndex[i] <= viewportAuto.Entities.Count - 1)) || !(viewportAuto.Entities[SimMovePartIndex[i]].GetType() == typeof(buMachinePart)))
			{
				continue;
			}
			_ = viewportAuto.Entities[SimMovePartIndex[i]] is buMachinePart;
			if ((customData.typeDefination == entityTypeDefination.MachineBody) | (customData.typeDefination == entityTypeDefination.MachineParts))
			{
				string blockName = ((BlockReference)viewportAuto.Entities[SimMovePartIndex[i]]).BlockName;
				if (blockName == "TopCylinder")
				{
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[i]]).zPos = pntMove.UpDistance;
				}
				if ((blockName == "LeftCylinder") | (blockName == "LeftFoot"))
				{
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[i]]).xPos = pntMove.LeftDistance * Math.Cos(buConversion5.DegreeToRadian(90.0 - buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[i]]).zPos = pntMove.LeftDistance * Math.Sin(buConversion5.DegreeToRadian(90.0 - buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
				}
				if ((blockName == "RightCylinder") | (blockName == "RightFoot"))
				{
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[i]]).xPos = pntMove.RightDistance * Math.Cos(buConversion5.DegreeToRadian(90.0 + buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[i]]).zPos = pntMove.RightDistance * Math.Sin(buConversion5.DegreeToRadian(90.0 + buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle));
				}
			}
		}
		viewportAuto.Entities.Regen();
		if (!viewportAuto.IsAnimationRunning)
		{
		}
	}

	public void AddMaterial(Entity entMat)
	{
		Entity copiedEntity = null;
		buEntity.Copy(entMat, ref copiedEntity);
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Material;
		customData.OriginalEntityIndex = viewportAuto.Entities.Count;
		copiedEntity.EntityData = customData;
		viewportAuto.Entities.Add(copiedEntity);
		viewportAuto.Invalidate();
	}

	public void DrawEntities(bool ZoomFit)
	{
		viewportAuto.Entities.Clear();
		CustomData customData = null;
		SimMovePartIndex.Clear();
		for (int i = 0; i <= ccVars.SimMachine.MachineParts.Count - 1; i++)
		{
			for (int j = 0; j <= ccVars.SimMachine.MachineParts[i].Entities.Count - 1; j++)
			{
				buMachinePart buMachinePart2 = new buMachinePart(ccVars.SimMachine.MachineParts[i].PartName);
				buMachinePart2.ARotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.A;
				buMachinePart2.BRotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.B;
				buMachinePart2.CRotation = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.C;
				buMachinePart2.XMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.X;
				buMachinePart2.YMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.Y;
				buMachinePart2.ZMove = ccVars.SimMachine.MachineParts[i].MoveAxisPermision.Z;
				buMachinePart2.xRot = ccVars.SimMachine.MachineParts[i].RotationCenter.X;
				buMachinePart2.yRot = ccVars.SimMachine.MachineParts[i].RotationCenter.Y;
				buMachinePart2.zRot = ccVars.SimMachine.MachineParts[i].RotationCenter.Z;
				buMachinePart2.Color = ccVars.SimMachine.MachineParts[i].Color;
				buMachinePart2.ColorMethod = colorMethodType.byEntity;
				double num = 0.0;
				double dx = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.X;
				double dy = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Y;
				double dz = ccVars.SimMachine.MachineParts[i].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[i].PositionAuxOffset.Z + num;
				buMachinePart2.Translate(dx, dy, dz);
				buMachinePart2.Tag = ccVars.SimMachine.MachineParts[i].Tag;
				buMachinePart2.No = ccVars.SimMachine.MachineParts[i].No;
				customData = new CustomData();
				customData.typeDefination = entityTypeDefination.MachineBody;
				customData.OriginalEntityIndex = viewportAuto.Entities.Count;
				buMachinePart2.EntityData = customData;
				viewportAuto.Entities.Add(buMachinePart2);
				SimMovePartIndex.Add(viewportAuto.Entities.Count - 1);
			}
		}
	}

	private void method_0(object sender, MouseEventArgs e)
	{
		Point3D intPoint = new Point3D();
		viewportAuto.ScreenToPlane(e.Location, planeActive, out intPoint);
		if (intPoint != null && frmMachSim != null && frmMachSim != null)
		{
			frmMachSim.lbl_x.Text = "X: " + intPoint.X.ToString("f3");
			frmMachSim.lbl_y.Text = "Y: " + intPoint.Y.ToString("f3");
			frmMachSim.lbl_z.Text = "Z: " + intPoint.Z.ToString("f3");
		}
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
	}

	public void LoadLanguage()
	{
		try
		{
		}
		catch (Exception)
		{
		}
	}

	public void SaveRollerBend()
	{
		SaveRollerBend(AppPath.Settings + "\\RollerBend");
	}

	public void SaveRollerBend(string Path)
	{
		try
		{
			if (AppBool.MachineMode)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\RollerBend");
				if (directoryInfo.Exists)
				{
					Path = directoryInfo.FullName;
				}
			}
			string fileName = Path + "\\RollerBend.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Roller Bend Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<varRollerBendSetting>");
			arrayList.AddRange(buRollerBendCalc.varRollerBendSetting.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</varRollerBendSetting>");
			arrayList.Add(" ");
			arrayList.Add("<varRollerBendRuntime>");
			arrayList.AddRange(buRollerBendCalc.varRollerBendRuntime.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</varRollerBendRuntime>");
			arrayList.Add(" ");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("RollerBend Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenRollerBend()
	{
		OpenRollerBend(AppPath.Settings + "\\RollerBend");
	}

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
				{
					Path = directoryInfo.FullName;
				}
			}
			string fileName = Path + "\\RollerBend.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				buLog.addLog("RollerBend.prm File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString5.MessageBoxError("RollerBend Settings File Missing");
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString5.ListToSpecificList("<varRollerBendSetting>", "</varRollerBendSetting>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(CalcList, "", SerilizationMode5.MultiLine, buRollerBendCalc.varRollerBendSetting);
						buLog.addLog("RollerBendSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString5.ListToSpecificList("<varRollerBendRuntime>", "</varRollerBendRuntime>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(CalcList, "", SerilizationMode5.MultiLine, buRollerBendCalc.varRollerBendRuntime);
						buLog.addLog("RollerBendRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					buLogVer5.addToLog(string_0, method, "Decoded", "RollerBend");
				}
				catch (Exception mSException)
				{
					buLog.addLog("RollerBend Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "RollerBend Settings Decoder Error");
				}
			}
			buLog.addLog("RollerBend Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException2)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doFindIntersectionLeft(double ProducedCircleDiameter, ref Point3D foundPoint, ref double foundLength, ref double Angle, bool AddPageEntity = false)
	{
		foundPoint = null;
		foundLength = 0.0;
		if (AddPageEntity)
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (entity.EntityData != null && entity.EntityData is CustomData && ((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Temp)
				{
					entity.Selected = true;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		Circle circle = new Circle(Plane.XY, new Point3D(0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
		circle.Regen(0.01);
		Circle circle2 = new Circle(Plane.XZ, new Point3D(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
		circle2.Regen(0.01);
		circle2.EntityData = new CustomData
		{
			typeDefination = entityTypeDefination.Temp
		};
		if (AddPageEntity)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(circle2);
		}
		Point3D point3D = new Point3D(buRollerBendCalc.varRollerBendSetting.LeftCylinderXOffset, buRollerBendCalc.varRollerBendSetting.LeftCylinderZOffset);
		new Circle(Plane.XZ, point3D, buRollerBendCalc.varRollerBendSetting.LeftCylinderDiameter / 2.0);
		for (double num = 10.0; num <= 500.0; num += 2.0)
		{
			Point3D EndPnt = new Point3D();
			clsInit.cVector5.LineWithLengthAndAngle(point3D, num, 90.0 - buRollerBendCalc.varRollerBendSetting.LeftCylinderAngle, ref EndPnt);
			Circle circle3 = new Circle(Plane.XY, EndPnt, buRollerBendCalc.varRollerBendSetting.LeftCylinderDiameter / 2.0);
			Circle circle4 = new Circle(Plane.XZ, new Point3D(EndPnt.X, 0.0, EndPnt.Y), buRollerBendCalc.varRollerBendSetting.LeftCylinderDiameter / 2.0);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Temp;
			circle4.EntityData = customData;
			circle4.Regen(new RegenParams(0.01));
			if (AddPageEntity)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(circle4);
			}
			circle3.Regen(0.01);
			Point3D[] array = Utility.Intersection(circle, circle3, 0.5);
			if (array != null && array.Length != 0)
			{
				Angle = 180.0 - clsInit.cVector5.PointAngle(array[0], new Point3D(0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0, 0.0));
				foundLength = num;
				foundPoint = new Point3D(EndPnt.X, 0.0, EndPnt.Y);
				num = 1000.0;
			}
		}
		if (AddPageEntity)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public void doFindIntersectionRight(double ProducedCircleDiameter, ref Point3D foundPoint, ref double foundLength, bool AddPageEntity = false)
	{
		foundPoint = null;
		foundLength = 0.0;
		if (AddPageEntity)
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (entity.EntityData != null && entity.EntityData is CustomData && ((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Temp)
				{
					entity.Selected = true;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		Circle circle = new Circle(Plane.XY, new Point3D(0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
		circle.Regen(0.01);
		Circle circle2 = new Circle(Plane.XZ, new Point3D(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + ProducedCircleDiameter / 2.0), ProducedCircleDiameter / 2.0);
		circle2.Regen(0.01);
		circle2.EntityData = new CustomData
		{
			typeDefination = entityTypeDefination.Temp
		};
		if (AddPageEntity)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(circle2);
		}
		Point3D point3D = new Point3D(buRollerBendCalc.varRollerBendSetting.RightCylinderXOffset, buRollerBendCalc.varRollerBendSetting.RightCylinderZOffset);
		new Circle(Plane.XZ, point3D, buRollerBendCalc.varRollerBendSetting.RightCylinderDiameter / 2.0);
		for (double num = 10.0; num <= 500.0; num += 2.0)
		{
			Point3D EndPnt = new Point3D();
			clsInit.cVector5.LineWithLengthAndAngle(point3D, num, 90.0 + buRollerBendCalc.varRollerBendSetting.RightCylinderAngle, ref EndPnt);
			Circle circle3 = new Circle(Plane.XY, EndPnt, buRollerBendCalc.varRollerBendSetting.RightCylinderDiameter / 2.0);
			Circle circle4 = new Circle(Plane.XZ, new Point3D(EndPnt.X, 0.0, EndPnt.Y), buRollerBendCalc.varRollerBendSetting.RightCylinderDiameter / 2.0);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Temp;
			circle4.EntityData = customData;
			circle4.Regen(new RegenParams(0.01));
			if (AddPageEntity)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(circle4);
			}
			circle3.Regen(0.01);
			Point3D[] array = Utility.Intersection(circle, circle3, 0.5);
			if (array != null && array.Length != 0)
			{
				foundLength = num;
				foundPoint = new Point3D(EndPnt.X, 0.0, EndPnt.Y);
				num = 1000.0;
			}
		}
		if (AddPageEntity)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public void doCircle(double Diameter, double Thickness, double SheetWidth, bool Simulation = false)
	{
		Point3D foundPoint = null;
		Point3D foundPoint2 = null;
		double foundLength = 0.0;
		double foundLength2 = 0.0;
		activeJob = new RollerJob();
		doFindIntersectionLeft(Diameter, ref foundPoint, ref foundLength, ref activeJob.LeftAngle);
		doFindIntersectionRight(Diameter, ref foundPoint2, ref foundLength2);
		List<ICurve> list = new List<ICurve>();
		list.Add(new Circle(Plane.XZ, Diameter / 2.0));
		list.Add(new Circle(Plane.XZ, Diameter / 2.0 - Thickness));
		Arc arc = new Arc(Plane.XZ, new Point3D(), Diameter / 2.0, buConversion5.DegreeToRadian(-90.0), buConversion5.DegreeToRadian(270.0));
		activeJob.TotalBendingLength = arc.Length();
		activeJob.SheetWidth = SheetWidth;
		activeJob.Thickness = Thickness;
		activeJob.Explanation = buLangTranslate.preDef.Cirlce + " - " + buLangTranslate.preDef.Diameter + ": " + Diameter.ToString("f2");
		arc.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Diameter / 2.0);
		arc.Regen(new RegenParams(1E-05));
		activeJob.matPoints = new List<Point3D>();
		activeJob.matPoints.Add(buVector5.ToPoint3D(arc.Vertices[0]));
		buVector5.ToPoint3D(arc.Vertices[0]);
		double num = 0.0;
		double num2 = 1.0;
		for (int i = 1; i <= arc.Vertices.Length - 1; i++)
		{
			double num3 = Point3D.Distance(arc.Vertices[i - 1], arc.Vertices[i]);
			num += num3;
			if (num >= num2)
			{
				activeJob.matPoints.Add(buVector5.ToPoint3D(arc.Vertices[i]));
				buVector5.ToPoint3D(arc.Vertices[i]);
				num2 += 1.0;
			}
		}
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list);
		region.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Diameter / 2.0);
		Mesh mesh = region.ExtrudeAsMesh(0.0 - SheetWidth, 0.01, Mesh.natureType.RichSmooth);
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = Color.FromArgb(40, Color.LightSteelBlue);
		double topBottomCylinderDistance = buRollerBendCalc.varRollerBendSetting.TopBottomCylinderDistance;
		activeJob.refEntitiy = new buCircle(Plane.XZ, Diameter / 2.0);
		activeJob.solidEntity = mesh;
		activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(0.0, foundLength * 0.6, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(150.0, foundLength * 0.6, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(150.0, -10.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(150.0, -10.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(activeJob.TotalBendingLength * 1.0, -10.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		clsInit.cRollerBend.CreateSimulationPoints(activeJob.Moves, ref activeJob.SimulationMoves);
	}

	public void doRectangle(double Width, double Height, double Radius, double Thickness, double SheetWidth, bool Simulation = false)
	{
		Point3D foundPoint = null;
		Point3D foundPoint2 = null;
		double foundLength = 0.0;
		double foundLength2 = 0.0;
		activeJob = new RollerJob();
		doFindIntersectionLeft(Radius * 2.0, ref foundPoint, ref foundLength, ref activeJob.LeftAngle);
		doFindIntersectionRight(Radius * 2.0, ref foundPoint2, ref foundLength2);
		List<ICurve> list = new List<ICurve>();
		CompositeCurve compositeCurve = CompositeCurve.CreateRoundedRectangle(Plane.XZ, Width, Height, Radius, centered: true);
		CompositeCurve compositeCurve2 = CompositeCurve.CreateRoundedRectangle(Plane.XZ, Width - 2.0 * Thickness, Height - 2.0 * Thickness, Radius - Thickness, centered: true);
		compositeCurve.Regen(0.1);
		compositeCurve2.Regen(0.1);
		list.Add(compositeCurve);
		list.Add(compositeCurve2);
		Line line = new Line(new Point3D(0.0, 0.0, (0.0 - Height) / 2.0), new Point3D(Width / 2.0 - Radius, 0.0, (0.0 - Height) / 2.0));
		Point3D[] pointsByLength = line.GetPointsByLength(0.1);
		LinearPath item = new LinearPath(pointsByLength);
		Arc arc = new Arc(Plane.XZ, new Point3D(Width / 2.0 - Radius, 0.0, (0.0 - Height) / 2.0 + Radius), Radius, buConversion5.DegreeToRadian(-90.0), buConversion5.DegreeToRadian(0.0));
		Line line2 = new Line(new Point3D(Width / 2.0, 0.0, (0.0 - Height) / 2.0 + Radius), new Point3D(Width / 2.0, 0.0, Height / 2.0 - Radius));
		Point3D[] pointsByLength2 = line2.GetPointsByLength(0.1);
		LinearPath item2 = new LinearPath(pointsByLength2);
		Arc arc2 = new Arc(Plane.XZ, new Point3D(Width / 2.0 - Radius, 0.0, Height / 2.0 - Radius), Radius, buConversion5.DegreeToRadian(0.0), buConversion5.DegreeToRadian(90.0));
		Line line3 = new Line(new Point3D(Width / 2.0 - Radius, 0.0, Height / 2.0), new Point3D((0.0 - Width) / 2.0 + Radius, 0.0, Height / 2.0));
		Point3D[] pointsByLength3 = line3.GetPointsByLength(0.1);
		LinearPath item3 = new LinearPath(pointsByLength3);
		Arc arc3 = new Arc(Plane.XZ, new Point3D((0.0 - Width) / 2.0 + Radius, 0.0, Height / 2.0 - Radius), Radius, buConversion5.DegreeToRadian(90.0), buConversion5.DegreeToRadian(180.0));
		Line line4 = new Line(new Point3D((0.0 - Width) / 2.0, 0.0, Height / 2.0 - Radius), new Point3D((0.0 - Width) / 2.0, 0.0, (0.0 - Height) / 2.0 + Radius));
		Point3D[] pointsByLength4 = line4.GetPointsByLength(0.1);
		LinearPath item4 = new LinearPath(pointsByLength4);
		Arc arc4 = new Arc(Plane.XZ, new Point3D((0.0 - Width) / 2.0 + Radius, 0.0, (0.0 - Height) / 2.0 + Radius), Radius, buConversion5.DegreeToRadian(180.0), buConversion5.DegreeToRadian(270.0));
		Line line5 = new Line(new Point3D((0.0 - Width) / 2.0 + Radius, 0.0, (0.0 - Height) / 2.0), new Point3D(0.0, 0.0, (0.0 - Height) / 2.0));
		Point3D[] pointsByLength5 = line5.GetPointsByLength(0.1);
		LinearPath item5 = new LinearPath(pointsByLength5);
		List<ICurve> list2 = new List<ICurve>();
		list2.Add(item);
		list2.Add(arc);
		list2.Add(item2);
		list2.Add(arc2);
		list2.Add(item3);
		list2.Add(arc3);
		list2.Add(item4);
		list2.Add(arc4);
		list2.Add(item5);
		double xPosition = line.Length();
		double xPosition2 = line.Length() + arc.Length();
		double xPosition3 = line.Length() + arc.Length() + line2.Length();
		double xPosition4 = line.Length() + arc.Length() + line2.Length() + arc2.Length();
		double xPosition5 = line.Length() + arc.Length() + line2.Length() + arc2.Length() + line3.Length();
		double xPosition6 = line.Length() + arc.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length();
		double xPosition7 = line.Length() + arc.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length() + line4.Length();
		double xPosition8 = line.Length() + arc.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length() + line4.Length() + arc4.Length();
		double xPosition9 = line.Length() + arc.Length() + line2.Length() + arc2.Length() + line3.Length() + arc3.Length() + line4.Length() + arc4.Length() + line5.Length();
		CompositeCurve compositeCurve3 = new CompositeCurve(list2, sortAndOrient: true);
		activeJob.TotalBendingLength = 2.0 * Width - 2.0 * Radius + (2.0 * Height - 2.0 * Radius) + Math.PI * 2.0 * Radius;
		activeJob.SheetWidth = SheetWidth;
		activeJob.Thickness = Thickness;
		compositeCurve3.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Height / 2.0);
		compositeCurve3.Regen(new RegenParams(1E-05));
		activeJob.matPoints = new List<Point3D>();
		activeJob.matPoints.Add(buVector5.ToPoint3D(compositeCurve3.Vertices[0]));
		buVector5.ToPoint3D(compositeCurve3.Vertices[0]);
		double num = 0.0;
		double num2 = 1.0;
		for (int i = 1; i <= compositeCurve3.Vertices.Length - 1; i++)
		{
			double num3 = Point3D.Distance(compositeCurve3.Vertices[i - 1], compositeCurve3.Vertices[i]);
			num += num3;
			if (num >= num2)
			{
				activeJob.matPoints.Add(buVector5.ToPoint3D(compositeCurve3.Vertices[i]));
				buVector5.ToPoint3D(compositeCurve3.Vertices[i]);
				num2 += 1.0;
			}
		}
		activeJob.matPoints.Reverse();
		clsInit.cVector5.Rotate(new Point3D(), 180.0, Plane.XY, ref activeJob.matPoints);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list, Plane.XZ, sortAndOrient: true);
		region.Translate(0.0, 0.0, buRollerBendCalc.varRollerBendSetting.DownCylinderDiameter / 2.0 + Height / 2.0);
		Mesh mesh = region.ExtrudeAsMesh(0.0 - SheetWidth, 0.01, Mesh.natureType.RichSmooth);
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = Color.FromArgb(40, Color.LightSteelBlue);
		double topBottomCylinderDistance = buRollerBendCalc.varRollerBendSetting.TopBottomCylinderDistance;
		activeJob.solidEntity = mesh;
		if (Simulation)
		{
			activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveFree));
			activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 30.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveFree));
			activeJob.Moves.Add(new RollerBendMove(200.0, 0.0, 30.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveMaterial));
			activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 30.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveMaterial));
		}
		activeJob.Moves.Add(new RollerBendMove(0.0, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveMaterial));
		activeJob.Moves.Add(new RollerBendMove(xPosition, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition2, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition2, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition3, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition3, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition4, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition4, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition5, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition5, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition6, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition6, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition7, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition7, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition8, 0.0, foundLength2, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition8, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		activeJob.Moves.Add(new RollerBendMove(xPosition9, 0.0, 0.0, 0.0 - topBottomCylinderDistance, RollerBendMoveCommand.MoveBend));
		clsInit.cRollerBend.CreateSimulationPoints(activeJob.Moves, ref activeJob.SimulationMoves);
	}

	public void doCreateCode(RollerJob JobItem, ref string strCode)
	{
		if (JobItem != null)
		{
			strCode = "// " + buLangTranslate.preDef.Job + " " + buLangTranslate.preDef.Name + " : " + JobItem.Name + Environment.NewLine;
			strCode = strCode + "// " + JobItem.Explanation + Environment.NewLine;
			strCode = strCode + "// " + buLangTranslate.preDef.Thickness + " " + JobItem.Thickness.ToString("f2") + Environment.NewLine;
			strCode = strCode + "// " + buLangTranslate.preDef.Sheet + " " + buLangTranslate.preDef.Width + " " + JobItem.SheetWidth.ToString("f2") + Environment.NewLine;
			strCode = strCode + "// " + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " " + JobItem.TotalBendingLength.ToString("f2") + Environment.NewLine;
			for (int i = 0; i <= JobItem.Moves.Count - 1; i++)
			{
				RollerBendMove rollerBendMove = JobItem.Moves[i];
				string text = JobItem.Moves[i].XPosition.ToString("f2");
				string text2 = JobItem.Moves[i].LeftDistance.ToString("f2");
				string text3 = JobItem.Moves[i].RightDistance.ToString("f2");
				if (i > 0)
				{
					double value = JobItem.Moves[i].XPosition - JobItem.Moves[i - 1].XPosition;
					if (buCompare5.EQ(value, 0.0, 0.1))
					{
						text = "";
					}
					double value2 = JobItem.Moves[i].LeftDistance - JobItem.Moves[i - 1].LeftDistance;
					if (buCompare5.EQ(value2, 0.0, 0.1))
					{
						text2 = "";
					}
					double value3 = JobItem.Moves[i].RightDistance - JobItem.Moves[i - 1].RightDistance;
					if (buCompare5.EQ(value3, 0.0, 0.1))
					{
						text3 = "";
					}
				}
				if (rollerBendMove.Command != RollerBendMoveCommand.MoveMaterial)
				{
					if (rollerBendMove.Command != RollerBendMoveCommand.CreateMaterial)
					{
						if (rollerBendMove.Command != RollerBendMoveCommand.MoveBend)
						{
							if (rollerBendMove.Command != RollerBendMoveCommand.MoveFree)
							{
								strCode = strCode + "Unknow Code" + Environment.NewLine;
								continue;
							}
							string text4 = "";
							if (text.Length > 0)
							{
								text4 = text4 + "Free Move Sheet: " + text + " ";
							}
							if (text2.Length > 0)
							{
								text4 = text4 + "Free Bend A: " + text2 + " ";
							}
							if (text3.Length > 0)
							{
								text4 = text4 + "Free Bend B: " + text3 + " ";
							}
							if (text4.Length == 0)
							{
								text4 = "Free : No Code";
							}
							strCode = strCode + text4 + Environment.NewLine;
						}
						else
						{
							string text5 = "";
							if (text.Length > 0)
							{
								text5 = text5 + "Move Sheet: " + text + " ";
							}
							if (text2.Length > 0)
							{
								text5 = text5 + "Bend A: " + text2 + " ";
							}
							if (text3.Length > 0)
							{
								text5 = text5 + "Bend B: " + text3 + " ";
							}
							if (text5.Length == 0)
							{
								text5 = "Bend : No Code";
							}
							strCode = strCode + text5 + Environment.NewLine;
						}
					}
					else
					{
						strCode = strCode + "Create Material : " + JobItem.TotalBendingLength.ToString("f2") + " X " + JobItem.SheetWidth.ToString("f2") + Environment.NewLine;
					}
				}
				else
				{
					string text6 = "";
					if (text.Length > 0)
					{
						text6 = text6 + "Move Sheet: " + text + " ";
					}
					if (text2.Length > 0)
					{
						text6 = text6 + "Bend A: " + text2 + " ";
					}
					if (text3.Length > 0)
					{
						text6 = text6 + "Bend B: " + text3 + " ";
					}
					if (text6.Length == 0)
					{
						text6 = "Move Sheet : No Code";
					}
					strCode = strCode + text6 + Environment.NewLine;
				}
			}
		}
		else
		{
			strCode = "";
		}
	}

	public void Calculate()
	{
	}
}
