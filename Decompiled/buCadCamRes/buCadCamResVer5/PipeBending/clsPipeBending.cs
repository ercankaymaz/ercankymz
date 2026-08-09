using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buApplication3D.UserInterfaces;
using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.SheetBending;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.PipeBending;

public class clsPipeBending
{
	[CompilerGenerated]
	private OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler_0;

	public Plane planeActive = Plane.XY;

	public static List<Entity> SimToCollsionCheck1 = new List<Entity>();

	public static List<Entity> SimToCollsionCheck2 = new List<Entity>();

	public F_PipeBendMachSim frmMachSim = null;

	public static F_BendingLRAList FrmPipeLRA = null;

	public PipeBendSimulationMove pntSim = new PipeBendSimulationMove();

	private int int_0 = 0;

	private bool bool_0;

	public event OkCommandWithThreeDataEventHandler SimulationUpdate
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Combine(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Remove(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
	}

	public void Init()
	{
		FrmPipeLRA = new F_BendingLRAList();
	}

	public void InitSimulation(bool ShowForm = true)
	{
		clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
		buUserSimVariables.Init();
		buUserControls.timSim = new System.Windows.Forms.Timer();
		buUserControls.timSim.Tick += tick_Simulation;
		buUserControls.timCollision = new System.Windows.Forms.Timer();
		buUserControls.timCollision.Interval = 1000;
		buUserControls.timCollision.Tick += method_0;
		if (ShowForm)
		{
			if (frmMachSim == null)
			{
				frmMachSim = new F_PipeBendMachSim();
			}
			frmMachSim.btn_xplus.Click += MoveAxesEvent;
			frmMachSim.btn_xminus.Click += MoveAxesEvent;
			frmMachSim.btn_yplus.Click += MoveAxesEvent;
			frmMachSim.btn_yminus.Click += MoveAxesEvent;
			frmMachSim.btn_zplus.Click += MoveAxesEvent;
			frmMachSim.btn_zminus.Click += MoveAxesEvent;
			frmMachSim.btn_rplus.Click += MoveAxesEvent;
			frmMachSim.btn_rminus.Click += MoveAxesEvent;
			frmMachSim.btn_tplus.Click += MoveAxesEvent;
			frmMachSim.btn_tminus.Click += MoveAxesEvent;
		}
		if (buEyeItems.viewportCNC == null)
		{
			CreateModelProperties createModelProperties = new CreateModelProperties();
			createModelProperties.DisplayType = displayType.Rendered;
			createModelProperties.CoordinateSystemIconVisible = true;
			createModelProperties.OriginSymbolVisible = false;
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
			clsInit.cVector5.CreateModelControl(ref buEyeItems.viewportCNC, clsVar.UnlockKey, createModelProperties);
			buEyeItems.viewportCNC.Name = "ModelAuto";
			if (ShowForm)
			{
				frmMachSim.pnl_viewport.Controls.Add(buEyeItems.viewportCNC);
			}
			buEyeItems.viewportCNC.MouseMove += method_3;
			buEyeItems.viewportCNC.MouseDown += method_4;
			buEyeItems.viewportCNC.MouseUp += method_5;
			buEyeItems.viewportCNC.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
			buEyeItems.viewportCNC.ProgressBar.Visible = false;
			buEyeItems.viewportCNC.WaitCursorMode = waitCursorType.Never;
			buEyeItems.viewportCNC.MouseMove += method_2;
			CreateMachine();
		}
		if (buEyeItems.viewportDialogs == null)
		{
			CreateModelProperties createModelProperties2 = new CreateModelProperties();
			createModelProperties2.DisplayType = displayType.Rendered;
			createModelProperties2.CoordinateSystemIconVisible = false;
			createModelProperties2.OriginSymbolVisible = false;
			createModelProperties2.ViewCubeIconVisible = true;
			createModelProperties2.OrigineCaptionVisible = false;
			createModelProperties2.ToolBorVisible = false;
			createModelProperties2.BottomColor = Color.LightGray;
			createModelProperties2.MiddleColor = Color.WhiteSmoke;
			createModelProperties2.TopColor = Color.LightGray;
			createModelProperties2.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties2.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties2.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties2.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties2.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties2.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			buEyeItems.viewportDialogs = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, createModelProperties2);
			buEyeItems.viewportDialogs.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
			buEyeItems.viewportDialogs.Name = "ModelDialog";
			buEyeItems.viewportDialogs.MouseMove += buEyeItems.mouseMoveViewportDialogs;
		}
	}

	public void tick_Simulation(object sender, EventArgs e)
	{
		try
		{
			if (clsInit.cPipeBend.activeJob == null || clsInit.cPipeBend.activeJob.SimMoves.Count == 0 || buEyeItems.viewportCNC.IsBusy)
			{
				return;
			}
			buUserControls.timSim.Enabled = false;
			int indexMove = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].IndexMove;
			if (clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].MovePipe)
			{
				PipeBendTempVars._excecutionPipe = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].ExecutedPipe;
			}
			if ((buUserSimVariables.indexSim >= 0) & (buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1))
			{
				pntSim.BendPos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].CPos;
				pntSim.YPreasurePos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].YPreasurePos;
			}
			if (PipeBendTempVars._excecutionPipe > PipeBendTempVars._pipeTotalLength)
			{
				PipeBendTempVars._excecutionPipe = PipeBendTempVars._pipeTotalLength;
			}
			if (!clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].MovePipe)
			{
				buUserSimVariables.indexSim++;
			}
			else
			{
				int int_ = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].IndexMove;
				method_1(ref int_, clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim]);
				buUserSimVariables.indexSim++;
				if (!(PipeBendTempVars.ProgressFinished || int_ > indexMove))
				{
				}
			}
			if ((buUserSimVariables.indexSim >= 0) & (buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1))
			{
				pntSim.ZPos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].ZPos;
				pntSim.YPos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim].YPos;
				MoveSimPart(pntSim);
			}
			if ((PipeBendTempVars._excecutionPipe < PipeBendTempVars._pipeTotalLength) & !AppBool.Pause & !AppBool.CollisionAvailable)
			{
				buUserControls.timSim.Enabled = true;
			}
			if (buUserSimVariables.indexSim > clsInit.cPipeBend.activeJob.SimMoves.Count - 1)
			{
				buUserSimVariables.indexSim = 0;
				buUserControls.timSim.Enabled = false;
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			clsInit.cPipeBend.Highlight(buEyeItems.viewportCNC.Entities[PipeBendTempVars._entityCollisionIndex], PipeBendTempVars.collisionColor2, buEyeItems.viewportCNC);
			bool_0 = true;
		}
		else
		{
			clsInit.cPipeBend.Highlight(buEyeItems.viewportCNC.Entities[PipeBendTempVars._entityCollisionIndex], PipeBendTempVars.collisionColor, buEyeItems.viewportCNC);
			bool_0 = false;
		}
		buEyeItems.viewportCNC.Invalidate();
	}

	public void MoveSimPart(PipeBendSimulationMove pntMove)
	{
		for (int i = 0; i <= buUserSimVariables.SimMovePartIndex.Count - 1; i++)
		{
			if (!((buEyeItems.viewportCNC.Entities.Count > 0) & (buUserSimVariables.SimMovePartIndex[i] <= buEyeItems.viewportCNC.Entities.Count - 1)))
			{
				continue;
			}
			CustomData customData = buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]].EntityData as CustomData;
			new Pnt6D();
			new Point3D();
			_ = buUserSimVariables.SimMovePartIndex[i];
			if (!((buUserSimVariables.SimMovePartIndex[i] >= 0) & (buUserSimVariables.SimMovePartIndex[i] <= buEyeItems.viewportCNC.Entities.Count - 1)) || !(buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]].GetType() == typeof(buMachinePart)))
			{
				continue;
			}
			_ = buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]] is buMachinePart;
			if ((customData.typeDefination == entityTypeDefination.MachineBody) | (customData.typeDefination == entityTypeDefination.MachineParts))
			{
				string blockName = ((BlockReference)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).BlockName;
				if (blockName == "XBlock")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).xPos = pntMove.Length;
				}
				if (blockName == "YMoveOnXBlock")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).xPos = pntMove.Length;
				}
				if (blockName == "XBending")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).xPos = pntMove.XBendingPos;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).yPos = pntMove.YPos;
				}
				if (blockName == "PipeRotate")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).xPos = pntMove.Length;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).aPos = pntMove.RotatePos;
				}
				if (blockName == "ProductLean")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).xPos = pntMove.Length;
				}
				if (blockName == "YBlock")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).yPos = pntMove.YPos;
				}
				if (blockName == "YPreasure")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).yPos = pntMove.YPos;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).zPos = pntMove.ZPos;
				}
				if (blockName == "ZBlock")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).yPos = pntMove.YPos;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).zPos = pntMove.ZPos;
				}
				if (blockName == "RotateAll")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).cPos = pntMove.BendPos;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).yPos = pntMove.YPos;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).zPos = pntMove.ZPos;
				}
				if (blockName == "RotateAndYMove")
				{
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).cPos = pntMove.BendPos;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).yPos = pntMove.YPos + pntMove.YPreasurePos;
					((buMachinePart)buEyeItems.viewportCNC.Entities[buUserSimVariables.SimMovePartIndex[i]]).zPos = pntMove.ZPos;
				}
			}
		}
		buEyeItems.viewportCNC.Entities.Regen();
		if (!buEyeItems.viewportCNC.IsAnimationRunning)
		{
		}
	}

	public void AddMaterial(Entity entMat)
	{
		Entity copiedEntity = null;
		buEntity.Copy(entMat, ref copiedEntity);
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Material;
		customData.OriginalEntityIndex = buEyeItems.viewportCNC.Entities.Count;
		copiedEntity.EntityData = customData;
		buEyeItems.viewportCNC.Entities.Add(copiedEntity);
		buEyeItems.viewportCNC.Invalidate();
	}

	public void CreateMachine()
	{
		buUserSimVariables.SimMovePartIndex.Clear();
		if (ccVars.SimMachine != null)
		{
			buEyeItems.viewportCNC.Blocks.Clear();
			for (int i = 0; i <= ccVars.SimMachine.MachineParts.Count - 1; i++)
			{
				for (int j = 0; j <= ccVars.SimMachine.MachineParts[i].Entities.Count - 1; j++)
				{
					Entity entity = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[i].Entities[j]);
					CustomData customData = new CustomData();
					customData.typeDefination = entityTypeDefination.MachineParts;
					customData.EntityName = ccVars.SimMachine.MachineParts[i].PartName;
					entity.EntityData = customData;
					entity.Regen(new RegenParams(buSystem.RegenDeviation, buEyeItems.viewportCNC));
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
					buEyeItems.viewportCNC.Blocks.Add(block);
				}
			}
		}
		PipeBendTempVars._numOfFileBlocks = buEyeItems.viewportCNC.Blocks.Count;
	}

	public void DrawEntities(bool ZoomFit)
	{
		buEyeItems.viewportCNC.Entities.Clear();
		CustomData customData = null;
		buUserSimVariables.SimMovePartIndex.Clear();
		if (buEyeItems.viewportCNC.Blocks.Count <= 5)
		{
			CreateMachine();
			buEyeItems.viewportCNC.Blocks.Clear();
			for (int i = 0; i <= ccVars.SimMachine.MachineParts.Count - 1; i++)
			{
				for (int j = 0; j <= ccVars.SimMachine.MachineParts[i].Entities.Count - 1; j++)
				{
					Entity entity = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[i].Entities[j]);
					customData = new CustomData();
					customData.typeDefination = entityTypeDefination.MachineParts;
					customData.EntityName = ccVars.SimMachine.MachineParts[i].PartName;
					entity.EntityData = customData;
					entity.Regen(new RegenParams(buSystem.RegenDeviation, buEyeItems.viewportCNC));
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
					buEyeItems.viewportCNC.Blocks.Add(block);
				}
			}
		}
		for (int k = 0; k <= ccVars.SimMachine.MachineParts.Count - 1; k++)
		{
			for (int l = 0; l <= ccVars.SimMachine.MachineParts[k].Entities.Count - 1; l++)
			{
				buMachinePart buMachinePart2 = new buMachinePart(ccVars.SimMachine.MachineParts[k].PartName);
				buMachinePart2.ARotation = ccVars.SimMachine.MachineParts[k].MoveAxisPermision.A;
				buMachinePart2.BRotation = ccVars.SimMachine.MachineParts[k].MoveAxisPermision.B;
				buMachinePart2.CRotation = ccVars.SimMachine.MachineParts[k].MoveAxisPermision.C;
				buMachinePart2.XMove = ccVars.SimMachine.MachineParts[k].MoveAxisPermision.X;
				buMachinePart2.YMove = ccVars.SimMachine.MachineParts[k].MoveAxisPermision.Y;
				buMachinePart2.ZMove = ccVars.SimMachine.MachineParts[k].MoveAxisPermision.Z;
				buMachinePart2.xRot = ccVars.SimMachine.MachineParts[k].RotationCenter.X;
				buMachinePart2.yRot = ccVars.SimMachine.MachineParts[k].RotationCenter.Y;
				buMachinePart2.zRot = ccVars.SimMachine.MachineParts[k].RotationCenter.Z;
				buMachinePart2.Color = ccVars.SimMachine.MachineParts[k].Color;
				buMachinePart2.ColorMethod = colorMethodType.byEntity;
				double num = 0.0;
				double dx = ccVars.SimMachine.MachineParts[k].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[k].PositionAuxOffset.X;
				double dy = ccVars.SimMachine.MachineParts[k].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[k].PositionAuxOffset.Y;
				double dz = ccVars.SimMachine.MachineParts[k].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[k].PositionAuxOffset.Z + num;
				buMachinePart2.Translate(dx, dy, dz);
				if (buEyeItems.viewportCNC.Blocks.Count <= 0)
				{
				}
				buMachinePart2.Tag = ccVars.SimMachine.MachineParts[k].Tag;
				buMachinePart2.No = ccVars.SimMachine.MachineParts[k].No;
				customData = new CustomData();
				customData.typeDefination = entityTypeDefination.MachineBody;
				customData.OriginalEntityIndex = buEyeItems.viewportCNC.Entities.Count;
				buMachinePart2.EntityData = customData;
				buEyeItems.viewportCNC.Entities.Add(buMachinePart2);
				buUserSimVariables.SimMovePartIndex.Add(buEyeItems.viewportCNC.Entities.Count - 1);
			}
		}
		PipeBendTempVars._numOfFileEntities = buEyeItems.viewportCNC.Entities.Count;
	}

	public void MoveAxesEvent(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == frmMachSim.btn_xplus.Name)
		{
			MoveAxes("X", 20.0);
		}
		if (control.Name == frmMachSim.btn_xminus.Name)
		{
			MoveAxes("X", -20.0);
		}
		if (control.Name == frmMachSim.btn_yplus.Name)
		{
			MoveAxes("Y", 10.0);
		}
		if (control.Name == frmMachSim.btn_yminus.Name)
		{
			MoveAxes("Y", -10.0);
		}
		if (control.Name == frmMachSim.btn_zplus.Name)
		{
			MoveAxes("Z", 10.0);
		}
		if (control.Name == frmMachSim.btn_zminus.Name)
		{
			MoveAxes("Z", -10.0);
		}
		if (control.Name == frmMachSim.btn_rplus.Name)
		{
			MoveAxes("M", -5.0);
		}
		if (control.Name == frmMachSim.btn_rminus.Name)
		{
			MoveAxes("M", 5.0);
		}
		if (control.Name == frmMachSim.btn_tplus.Name)
		{
			MoveAxes("A", 5.0);
		}
		if (control.Name == frmMachSim.btn_tminus.Name)
		{
			MoveAxes("A", -5.0);
		}
	}

	public void MoveAxes(string Axis, double Value)
	{
		if (Axis == "X")
		{
			pntSim.Length += Value;
		}
		if (Axis == "Y")
		{
			pntSim.YPos += Value;
		}
		if (Axis == "Z")
		{
			pntSim.ZPos += Value;
		}
		if (Axis == "M")
		{
			pntSim.BendPos += Value;
		}
		if (Axis == "A")
		{
			pntSim.RotatePos += Value;
		}
		if (Axis == "YPreasure")
		{
			pntSim.YPreasurePos += Value;
		}
		if (Axis == "XBending")
		{
			pntSim.XBendingPos += Value;
		}
		MoveSimPart(pntSim);
	}

	private void method_1(ref int int_1, PipeBendSimulationMove pipeBendSimulationMove_0, bool bool_1 = false)
	{
		try
		{
			PipeBendTempVars._sw.Start();
			double num = 0.0;
			int_1 = 0;
			PipeBendTempVars.doneZSteps++;
			while (buEyeItems.viewportCNC.Blocks.Count > PipeBendTempVars._numOfFileBlocks)
			{
				buEyeItems.viewportCNC.Blocks.RemoveAt(buEyeItems.viewportCNC.Blocks.Count - 1);
			}
			while ((buEyeItems.viewportCNC.Entities.Count > PipeBendTempVars._numOfFileEntities) & (buEyeItems.viewportCNC.Entities.Count > 0))
			{
				buEyeItems.viewportCNC.Entities.RemoveAt(buEyeItems.viewportCNC.Entities.Count - 1);
			}
			PipeBendTempVars._surfList.Clear();
			PipeBendTempVars._straightPartCounter = 0;
			PipeBendTempVars._bendPartCounter = 0;
			PipeBendTempVars.ProgressFinished = false;
			PipeBendTempVars._excecutionPipe = pipeBendSimulationMove_0.ExecutedPipe;
			while (num < PipeBendTempVars._excecutionPipe)
			{
				if (!(PipeBendTempVars._excecutionPipe >= num + clsInit.cPipeBend.activeJob.BendingList[int_1].Length))
				{
					buEyeItems.viewportCNC = clsInit.cPipeBend.AddStraight(PipeBendTempVars._excecutionPipe - num, buEyeItems.viewportCNC);
					num += PipeBendTempVars._excecutionPipe - num;
					break;
				}
				if (clsInit.cPipeBend.activeJob.BendingList[int_1].Length > 0.0)
				{
					buEyeItems.viewportCNC = clsInit.cPipeBend.AddStraight(clsInit.cPipeBend.activeJob.BendingList[int_1].Length, buEyeItems.viewportCNC);
				}
				num += clsInit.cPipeBend.activeJob.BendingList[int_1].Length;
				if (PipeBendTempVars._excecutionPipe - num < pipeBendSimulationMove_0.ExecutedStep)
				{
					PipeBendTempVars.ProgressFinished = true;
					PipeBendTempVars._excecutionPipe = num;
				}
				if (!(PipeBendTempVars._excecutionPipe > num))
				{
					if (!(clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation < 0.0))
					{
						PipeBendTempVars.doneZSteps++;
					}
					else
					{
						PipeBendTempVars.doneZSteps--;
					}
					double num2 = PipeBendTempVars.doneZSteps * 10;
					if ((num2 >= clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation && num2 > 0.0) | (num2 <= clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation && num2 < 0.0))
					{
						num2 = clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation;
						PipeBendTempVars.doneZSteps = 0;
					}
					clsInit.cPipeBend.RotatePipe(num2 / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
				}
				else
				{
					clsInit.cPipeBend.RotatePipe(clsInit.cPipeBend.activeJob.BendingList[int_1].Rotation / 180.0 * Math.PI, Vector3D.AxisX, Point3D.Origin);
				}
				if (!(PipeBendTempVars._excecutionPipe >= num + clsInit.cPipeBend.CurveUnbending(int_1, clsInit.cPipeBend.activeJob.BendingList)))
				{
					double num3 = PipeBendTempVars._excecutionPipe - num;
					PipeBendTempVars.ProgressFinished = false;
					if (num3 > 0.0)
					{
						double num4 = clsInit.cPipeBend.AnglePortion(num3, int_1, clsInit.cPipeBend.activeJob.BendingList) / 180.0 * Math.PI;
						buEyeItems.viewportCNC = clsInit.cPipeBend.AddTurn(num4, Vector3D.AxisZ, new Point3D(0.0, clsInit.cPipeBend.activeJob.BendingList[int_1].Radius, 0.0), buEyeItems.viewportCNC);
						pntSim.BendPos = 0.0 - buConversion5.RadianToDegree(num4);
						if ((buUserSimVariables.indexSim >= 1) & (buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1))
						{
							pntSim.YPreasurePos = clsInit.cPipeBend.activeJob.SimMoves[buUserSimVariables.indexSim - 1].YPreasurePos;
						}
						num += num3;
					}
				}
				else
				{
					if (clsInit.cPipeBend.activeJob.BendingList[int_1].Angle > 0.0)
					{
						buEyeItems.viewportCNC = clsInit.cPipeBend.AddTurn(clsInit.cPipeBend.activeJob.BendingList[int_1].Angle / 180.0 * Math.PI, Vector3D.AxisZ, new Point3D(0.0, clsInit.cPipeBend.activeJob.BendingList[int_1].Radius, 0.0), buEyeItems.viewportCNC);
						num += clsInit.cPipeBend.CurveUnbending(int_1, clsInit.cPipeBend.activeJob.BendingList);
					}
					int_1++;
				}
			}
			pntSim.Length = 0.0 - PipeBendTempVars._pipeTotalLength + PipeBendTempVars._excecutionPipe - 1.0;
			if ((buUserSimVariables.indexSim >= 0) & (buUserSimVariables.indexSim <= clsInit.cPipeBend.activeJob.SimMoves.Count - 1))
			{
				MoveSimPart(pntSim);
			}
			if (PipeBendTempVars._pipeTotalLength > PipeBendTempVars._excecutionPipe)
			{
				buEyeItems.viewportCNC = clsInit.cPipeBend.AddStraightBack(PipeBendTempVars._pipeTotalLength - PipeBendTempVars._excecutionPipe, buEyeItems.viewportCNC);
			}
			foreach (Entity surf in PipeBendTempVars._surfList)
			{
				surf.Rotate(Math.PI, Vector3D.AxisX, Point3D.Origin);
				surf.Translate(PipeBendTempVars.OffsetX, PipeBendTempVars.OffsetY);
			}
			Block block = new Block("pipe");
			BlockReference item;
			for (int i = 1; i <= PipeBendTempVars._straightPartCounter; i++)
			{
				string blockName = PipeBendTempVars.StraightBlockName + i;
				item = new BlockReference(blockName);
				block.Entities.Add(item);
			}
			for (int i = 1; i <= PipeBendTempVars._bendPartCounter; i++)
			{
				string blockName = PipeBendTempVars.BendBlockName + i;
				item = new BlockReference(blockName);
				block.Entities.Add(item);
			}
			buEyeItems.viewportCNC.Blocks.AddOrReplace(block);
			item = new BlockReference("pipe");
			buEyeItems.viewportCNC.Entities.Add(item);
			try
			{
				item = new BlockReference(PipeBendTempVars.StraightbackBlockName);
				block.Entities.Add(item);
			}
			catch
			{
			}
			if (PipeBendTempVars._excecutionPipe != PipeBendTempVars._pipeTotalLength)
			{
				if (!bool_1)
				{
					buUserControls.timSim.Enabled = true;
				}
			}
			else
			{
				buUserControls.timSim.Enabled = false;
				PipeBendTempVars._sw.Stop();
			}
			List<Entity> list = new List<Entity>();
			new List<Entity>();
			Block block2 = new Block(PipeBendTempVars.MachineBlockName);
			PipeBendTempVars.machineCollisionEntities = new int[1];
			int[] machineCollisionEntities = PipeBendTempVars.machineCollisionEntities;
			foreach (int index in machineCollisionEntities)
			{
				block2.Entities.Add(buEyeItems.viewportCNC.Entities[index]);
			}
			item = new BlockReference(PipeBendTempVars.MachineBlockName);
			buEyeItems.viewportCNC.Blocks.AddOrReplace(block2);
			list.Add(item);
			list.Add(buEyeItems.viewportCNC.Entities[buEyeItems.viewportCNC.Entities.Count - 1]);
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				okCommandWithThreeDataEventHandler_0(pntSim, null, null);
			}
			if (buPipeBendCalc.varPipeBendingProgramSettings.CollisionCheck)
			{
				PipeBendTempVars._cd = new CollisionDetection(list, buEyeItems.viewportCNC.Blocks, PipeBendTempVars._firstOnly, PipeBendTempVars._checkMethod);
				PipeBendTempVars._cd.DoWork();
				if (PipeBendTempVars._cd.Result != null && PipeBendTempVars._cd.Result.Length != 0)
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
		catch (Exception)
		{
			PipeBendTempVars._sw.Stop();
		}
	}

	private void method_2(object sender, MouseEventArgs e)
	{
		new Point3D();
	}

	private void method_3(object sender, MouseEventArgs e)
	{
		Design design = sender as Design;
		if (design.Name == buEyeItems.viewportCNC.Name && buUserSimVariables.pntMouseViewport != null)
		{
		}
	}

	private void method_4(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
		}
	}

	private void method_5(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
		}
	}

	public void cmdSimilation(bool ShowForm = true)
	{
		if (!buEyeItems.viewportCNC.IsAnimationRunning)
		{
			buEyeItems.viewportCNC.StartAnimation(buPipeBendCalc.varPipeBendingProgramSettings.SimulationIntervalMs);
		}
		if (ShowForm)
		{
			frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			frmMachSim.Init();
			frmMachSim.StartPosition = FormStartPosition.CenterParent;
		}
		DrawEntities(ZoomFit: true);
		buUserControls.timCollision.Enabled = false;
		foreach (KeyValuePair<Entity, Color> originalColor in PipeBendTempVars.originalColors)
		{
			originalColor.Key.Color = originalColor.Value;
		}
		PipeBendTempVars.OffsetX = 0;
		PipeBendTempVars.OffsetY = 216;
		PipeBendTempVars.NumberOfSim++;
		PipeBendTempVars._pipeTotalLength = clsInit.cPipeBend.GetPipeLength(clsInit.cPipeBend.activeJob.BendingList);
		PipeBendTempVars._excecutionPipe = 0.0;
		int int_ = 0;
		if (clsInit.cPipeBend.activeJob.SimMoves.Count > 0)
		{
			method_1(ref int_, clsInit.cPipeBend.activeJob.SimMoves[0]);
		}
		buUserControls.timSim.Enabled = false;
		if (ShowForm)
		{
			frmMachSim.ShowDialog();
		}
	}

	public void cmdStartSimulation(bool Step)
	{
		if (!AppBool.Pause)
		{
			buUserControls.timCollision.Enabled = false;
			PipeBendTempVars._excecutionPipe = 0.0;
			buUserControls.timSim.Interval = buPipeBendCalc.varPipeBendingProgramSettings.SimulationIntervalMs;
			buRollerBendCalc.varRollerBendRuntime.StepRun = Step;
			if (buUserSimVariables.indexSim == -1)
			{
				buUserSimVariables.indexSim = 0;
			}
			buUserControls.timSim.Enabled = true;
			if (Step)
			{
				if (!(buRollerBendCalc.varRollerBendRuntime.StepRun && Step))
				{
				}
			}
			else
			{
				buRollerBendCalc.varRollerBendRuntime.StepRun = false;
				buEyeItems.viewportCNC.Entities.ClearSelection();
				buEyeItems.viewportCNC.Invalidate();
			}
		}
		else
		{
			buUserControls.timSim.Enabled = true;
			AppBool.Pause = false;
		}
	}

	public void cmdStopSimulation()
	{
		if (!buUserControls.timSim.Enabled)
		{
			AppBool.CollisionAvailable = false;
			AppBool.Pause = false;
			buUserSimVariables.indexSim = 0;
			buUserControls.timSim.Enabled = false;
		}
		else
		{
			buUserControls.timSim.Enabled = false;
			AppBool.Pause = true;
		}
	}

	public void cmdNextSimulation()
	{
		tick_Simulation(null, null);
	}

	public void cmdPreSimulation()
	{
		if (buUserSimVariables.indexSim > 0)
		{
			buUserSimVariables.indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
			buUserSimVariables.indexSim -= buRollerBendCalc.varRollerBendRuntime.SimStep;
			tick_Simulation(null, null);
		}
	}

	public void cmdSetView(viewType Type)
	{
		switch (Type)
		{
		default:
			buEyeShotFunctions.ViewIso(ref buEyeItems.viewportCNC, isZoomFit: false);
			planeActive = Plane.XY;
			break;
		case viewType.Top:
			buEyeShotFunctions.ViewTop(ref buEyeItems.viewportCNC, isZoomFit: false);
			planeActive = Plane.XY;
			break;
		case viewType.Bottom:
			buEyeShotFunctions.ShowViewportViewBox(ref buEyeItems.viewportCNC, Show: false);
			planeActive = Plane.XY;
			break;
		case viewType.Front:
			buEyeShotFunctions.Viewfront(ref buEyeItems.viewportCNC, isZoomFit: false);
			planeActive = Plane.XZ;
			break;
		case viewType.Rear:
			buEyeShotFunctions.ViewBack(ref buEyeItems.viewportCNC, isZoomFit: false);
			planeActive = Plane.XZ;
			break;
		case viewType.Left:
			buEyeShotFunctions.ViewLeft(ref buEyeItems.viewportCNC, isZoomFit: false);
			planeActive = Plane.YZ;
			break;
		case viewType.Right:
			buEyeShotFunctions.ViewRight(ref buEyeItems.viewportCNC, isZoomFit: false);
			planeActive = Plane.YZ;
			break;
		}
	}

	public void cmdCreateBase()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		double width = 566.0;
		double height = 88.0;
		List<ICurve> list = new List<ICurve>();
		LinearPath item = new LinearPath(0.0, 0.0, width, height);
		list.Add(item);
		double x = 50.0;
		new Circle(x, 10.0, 0.0, 4.0);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list);
		Brep entity = region.ExtrudeAsBrep(-1.0);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity, Color.SteelBlue);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdSelect()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.SelectVisibleByPickDynamic;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SelectionFilterMode = selectionFilterType.Edge | selectionFilterType.Face;
	}

	public void SelectedIndex(int i)
	{
		F_SheetBendData f_SheetBendData = new F_SheetBendData();
		f_SheetBendData.spn_angle.Value = 90m;
		f_SheetBendData.spn_len.Value = 20m;
		f_SheetBendData.spn_rad.Value = 1m;
		f_SheetBendData.ShowDialog();
		if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0 && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0] is Brep)
		{
			Brep brep = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0] as Brep;
			brep.Rebuild();
			brep.AddFlange(i, (double)f_SheetBendData.spn_rad.Value, (double)f_SheetBendData.spn_len.Value, Utility.DegToRad((double)f_SheetBendData.spn_angle.Value));
			brep.Rebuild();
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
				Brep brep = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0] as Brep;
				brep.Color = Color.FromArgb(150, brep.Color);
				if (brep.Faces.Length != 0)
				{
					for (int i = 0; i <= brep.Faces.Length - 1; i++)
					{
						if (i > 10)
						{
							continue;
						}
						Brep.Face face = brep.Faces[i];
						for (int j = 0; j <= face.Loops.Length - 1; j++)
						{
							List<ICurve> list = new List<ICurve>();
							for (int k = 0; k <= face.Loops[j].Segments.Length - 1; k++)
							{
								Brep.OrientedEdge orientedEdge = face.Loops[j].Segments[k];
								if ((orientedEdge.CurveIndex >= 0) & (orientedEdge.CurveIndex <= brep.Edges.Length - 1))
								{
									Entity copiedEntity = null;
									buEntity.Copy((Entity)brep.Edges[orientedEdge.CurveIndex].Curve, ref copiedEntity);
									copiedEntity.ColorMethod = colorMethodType.byEntity;
									copiedEntity.Color = Color.Red;
									copiedEntity.LineWeight = 4f;
									copiedEntity.LineWeightMethod = colorMethodType.byEntity;
									list.Add((ICurve)copiedEntity);
								}
							}
							bool flag = false;
							if (list.Count <= 0)
							{
								continue;
							}
							for (int l = 0; l <= list.Count - 1; l++)
							{
								if (!(((Entity)list[l]).GetType() == typeof(Arc)))
								{
								}
								if (((Entity)list[l]).GetType() == typeof(Curve))
								{
									flag = true;
								}
							}
							if (flag)
							{
								CompositeCurve compositeCurve = new CompositeCurve(list);
								compositeCurve.ColorMethod = colorMethodType.byEntity;
								compositeCurve.Color = Color.Red;
								compositeCurve.LineWeight = 4f;
								compositeCurve.LineWeightMethod = colorMethodType.byEntity;
								compositeCurve.LayerName = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[1].Name;
								compositeCurve.Regen(0.01);
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(compositeCurve);
							}
						}
					}
				}
				if (brep.Edges.Length == 0)
				{
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdDraw1()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		double num = 1.0;
		double num2 = 1.0;
		double num3 = 566.0;
		double amount = 98.0;
		double height = 88.0;
		double num4 = 24.0;
		List<ICurve> list = new List<ICurve>();
		LinearPath item = new LinearPath(0.0, 0.0, num3, height);
		list.Add(item);
		double num5 = 50.0;
		Circle circle = new Circle(num5, 10.0, 0.0, 4.0);
		list.Add(circle);
		for (int i = 1; i < 9; i++)
		{
			Entity entity = (Entity)circle.Clone();
			entity.Translate((double)i * (num3 - num5 * 2.0) / 8.0, 0.0);
			list.Add((ICurve)entity);
		}
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list);
		Brep brep = region.ExtrudeAsBrep(0.0 - num);
		int edgeIndex = brep.GetEdgeIndex(new Point3D(0.5, 0.0, 0.0));
		brep.AddFlange(edgeIndex, num2, num4, Math.PI / 4.0);
		_ = brep.Edges.Length - 1;
		brep.AddFlange(50, num2, num4, Utility.DegToRad(90.0));
		edgeIndex = brep.GetEdgeIndex(new Point3D(0.0, num / 2.0, 0.0));
		brep.AddFlange(edgeIndex, num2, amount);
		Plane xY = Plane.XY;
		xY.Translate(0.0, 0.0, num2 + num4 + num);
		brep.Rebuild(0.01);
		int planarFaceIndex = brep.GetPlanarFaceIndex(Plane.XZ, new Point3D(0.0 - num2 - num / 2.0, 0.0, num2 + num / 2.0));
		brep.SubdivideBy(planarFaceIndex, xY);
		edgeIndex = brep.GetEdgeIndex(new Point3D(0.0 - num2, 0.0, num4 + num2 + num + num / 2.0));
		brep.AddFlange(edgeIndex, num2, num4);
		edgeIndex = brep.GetEdgeIndex(new Point3D(num3, num / 2.0, 0.0));
		brep.AddFlange(edgeIndex, num2, amount);
		brep.Rebuild(0.01);
		planarFaceIndex = brep.GetPlanarFaceIndex(Plane.XZ, new Point3D(num3 + num2 + num / 2.0, 0.0, num4 + num2 + num / 2.0));
		brep.SubdivideBy(planarFaceIndex, xY);
		edgeIndex = brep.GetEdgeIndex(new Point3D(num3 + num2, 0.0, num4 + num2 + num * 2.0));
		brep.AddFlange(edgeIndex, num2, num4);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(brep, Color.AliceBlue);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public DialogResult cmdShowAndGetPipeLRA(ref List<Entity> Entities, ref List<Block> Blocks)
	{
		try
		{
			if (FrmPipeLRA != null)
			{
				if (clsInit.cPipeBend.activeJob == null)
				{
					clsInit.cPipeBend.activeJob = new PipeBendJob();
				}
				if (FrmPipeLRA.Visible)
				{
					FrmPipeLRA.Visible = false;
				}
				else
				{
					FrmPipeLRA.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
					FrmPipeLRA.pathLRA = buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles;
					PipeBendTempVars._pipeDiameter = clsInit.cPipeBend.activeJob.PipeDiameter;
					FrmPipeLRA.BendingList.Clear();
					for (int i = 0; i <= clsInit.cPipeBend.activeJob.BendingList.Count - 1; i++)
					{
						FrmPipeLRA.BendingList.Add(new BendingLRAMaterialData(clsInit.cPipeBend.activeJob.BendingList[i]));
					}
					FrmPipeLRA.Job = clsInit.cPipeBend.activeJob;
					FrmPipeLRA.Init();
					FrmPipeLRA.ShowDialog();
					if (FrmPipeLRA.PropertiesForm.Result == DialogResult.OK)
					{
						PipeBendTempVars._numOfFileBlocks = ccVars.SimMachine.MachineParts.Count + 1;
						PipeBendTempVars._pipeDiameter = clsInit.cPipeBend.activeJob.PipeDiameter;
						Entities.Clear();
						Blocks.Clear();
						clsInit.cPipeBend.activeJob.EntityList.Clear();
						clsInit.cPipeBend.activeJob.BlockList.Clear();
						if (FrmPipeLRA.viewportPart.Entities.Count > 0)
						{
							for (int j = 1; j <= FrmPipeLRA.viewportPart.Blocks.Count - 1; j++)
							{
								Block block = FrmPipeLRA.viewportPart.Blocks[j];
								Block item = (Block)block.Clone();
								clsInit.cPipeBend.activeJob.BlockList.Add(item);
							}
							for (int k = 0; k <= FrmPipeLRA.viewportPart.Entities.Count - 1; k++)
							{
								Entity entity = FrmPipeLRA.viewportPart.Entities[k];
								Entity item2 = (Entity)entity.Clone();
								clsInit.cPipeBend.activeJob.EntityList.Add(item2);
							}
						}
						clsInit.cPipeBend.activeJob.BendingList.Clear();
						for (int l = 0; l <= FrmPipeLRA.BendingList.Count - 1; l++)
						{
							clsInit.cPipeBend.activeJob.BendingList.Add(new BendingLRAMaterialData(FrmPipeLRA.BendingList[l]));
						}
						buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles = FrmPipeLRA.pathLRA;
						if (PipeBendTempVars._pipeDiameter <= 0.0)
						{
							PipeBendTempVars._pipeDiameter = 10.0;
						}
						PipeBendTempVars._c1 = new Circle(Plane.YZ, PipeBendTempVars._pipeDiameter / 2.0);
						PipeBendTempVars._c1.Reverse();
						return DialogResult.OK;
					}
				}
			}
			return DialogResult.None;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
			return DialogResult.None;
		}
	}

	public void cmdShowPipeLRA()
	{
		try
		{
			if (FrmPipeLRA == null)
			{
				return;
			}
			if (FrmPipeLRA.Visible)
			{
				FrmPipeLRA.Visible = false;
				return;
			}
			FrmPipeLRA.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			FrmPipeLRA.pathLRA = buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles;
			PipeBendTempVars._pipeDiameter = clsInit.cPipeBend.activeJob.PipeDiameter;
			FrmPipeLRA.BendingList.Clear();
			for (int i = 0; i <= clsInit.cPipeBend.activeJob.BendingList.Count - 1; i++)
			{
				FrmPipeLRA.BendingList.Add(new BendingLRAMaterialData(clsInit.cPipeBend.activeJob.BendingList[i]));
			}
			FrmPipeLRA.Init();
			FrmPipeLRA.ShowDialog();
			if (FrmPipeLRA.PropertiesForm.Result != DialogResult.OK)
			{
				return;
			}
			clsInit.cPipeBend.activeJob.PipeDiameter = PipeBendTempVars._pipeDiameter;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Blocks.Clear();
			if (FrmPipeLRA.viewportPart.Entities.Count > 0)
			{
				for (int j = 1; j <= FrmPipeLRA.viewportPart.Blocks.Count - 1; j++)
				{
					Block block = FrmPipeLRA.viewportPart.Blocks[j];
					Block newItem = (Block)block.Clone();
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Blocks.AddOrReplace(newItem);
				}
				for (int k = 0; k <= FrmPipeLRA.viewportPart.Entities.Count - 1; k++)
				{
					Entity entity = FrmPipeLRA.viewportPart.Entities[k];
					Entity item = (Entity)entity.Clone();
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item);
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.cPipeBend.activeJob.BendingList.Clear();
			for (int l = 0; l <= FrmPipeLRA.BendingList.Count - 1; l++)
			{
				clsInit.cPipeBend.activeJob.BendingList.Add(new BendingLRAMaterialData(FrmPipeLRA.BendingList[l]));
			}
			buPipeBendCalc.varPipeBendingProgramSettings.pathLRAFiles = FrmPipeLRA.pathLRA;
			PipeBendTempVars._pipeDiameter = 80.0;
			PipeBendTempVars._c1 = new Circle(Plane.YZ, 40.0);
			PipeBendTempVars._c1.Reverse();
			clsFiles.SaveParameter();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdMenuCommand(object sender, EventArgs e)
	{
		if (!(sender is Control))
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				_ = toolStripMenuItem.Name;
			}
		}
		else
		{
			Control control = sender as Control;
			_ = control.Name;
		}
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
	}

	public static void SaveLRAFile(string FileName, List<BendingLRAMaterialData> BendingList)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<LRAList>");
		for (int i = 0; i <= BendingList.Count - 1; i++)
		{
			arrayList.AddRange(BendingList[i].ToDefAll("", 2, SerilizationMode.MultiLine));
		}
		arrayList.Add("</LRAList>");
		buFile.SaveToFile(arrayList, FileName);
	}

	public static void OpenLRAFile(string FileName, ref List<BendingLRAMaterialData> BendingList)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			arrayList = new ArrayList();
			buFile.OpenFromFile(FileName, ref arrayList);
			List<List<string>> CalcList = new List<List<string>>();
			buString.ListToSpecificList("<LRAList>", "</LRAList>", AddStartEndKey: true, arrayList, ref CalcList);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				BendingLRAMaterialData bendingLRAMaterialData = new BendingLRAMaterialData();
				buSerilization.Decode(CalcList[i], "", SerilizationMode.MultiLine, bendingLRAMaterialData);
				BendingList.Add(bendingLRAMaterialData);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("OpenLRAFile", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "OpenLRAFile");
		}
	}

	public void SavePipeBendingFile()
	{
		SavePipeBendingFile(AppPath.Settings + "\\PipeBend");
	}

	public void SavePipeBendingFile(string Path)
	{
		if (AppBool.MachineMode)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\PipeBend");
			if (directoryInfo.Exists)
			{
				Path = directoryInfo.FullName;
			}
		}
		string fileName = Path + "\\PipeBending.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Pipe Bending Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<PipeBendingSettings>");
		arrayList.AddRange(buPipeBendCalc.varPipeBendingSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</PipeBendingSettings>");
		arrayList.Add("<varPipeBendRunSettings>");
		arrayList.AddRange(buPipeBendCalc.varPipeBendingRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</varPipeBendRunSettings>");
		arrayList.Add("<varPipeBendSettings>");
		arrayList.AddRange(buPipeBendCalc.varPipeBendingProgramSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</varPipeBendSettings>");
		arrayList.Add("<DiskAndBlocksList>");
		arrayList.AddRange(PipeBendDiskBlocks.ToDef(buPipeBendCalc.DiskBlocks, "", 2));
		arrayList.Add("</DiskAndBlocksList>");
		buFile.SaveToFile(arrayList, fileName);
		buLog.addLog("Pipe Bending Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
	}

	public void OpenPipeBendingFile()
	{
		OpenPipeBendingFile(AppPath.Settings + "\\PipeBend");
	}

	public void OpenPipeBendingFile(string Path)
	{
		try
		{
			if (AppBool.MachineMode)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\PipeBend");
				if (directoryInfo.Exists)
				{
					Path = directoryInfo.FullName;
				}
			}
			ArrayList StringList = new ArrayList();
			string fileName = Path + "\\PipeBending.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Pipe Bending Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Pipe Bending Settings File Missing");
				}
			}
			else
			{
				StringList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<PipeBendingSettings>", "</PipeBendingSettings>", AddStartEndKey: true, StringList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, buPipeBendCalc.varPipeBendingSettings);
						buLog.addLog("Pipe Bending Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varPipeBendRunSettings>", "</varPipeBendRunSettings>", AddStartEndKey: true, StringList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, buPipeBendCalc.varPipeBendingRunSettings);
						buLog.addLog("varPipeBendRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varPipeBendSettings>", "</varPipeBendSettings>", AddStartEndKey: true, StringList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, buPipeBendCalc.varPipeBendingProgramSettings);
						buLog.addLog("varPipeBendSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Pipe Bending Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Laser Settings Decoder Error");
				}
			}
			buLog.addLog("Pipe Bending Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			List<string> CalcList2 = new List<string>();
			buStatics.ListToSpecificList("<DiskAndBlocksList>", "</DiskAndBlocksList>", AddStartEndKey: false, StringList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				PipeBendDiskBlocks.Decode(CalcList2, ref buPipeBendCalc.DiskBlocks);
			}
			if (buPipeBendCalc.DiskBlocks.Count == 0)
			{
				buPipeBendCalc.DiskBlocks.Add(new PipeBendDiskBlocks());
			}
		}
		catch (Exception mSException2)
		{
			buLog.addLog("Pipe Bending Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Pipe Bending Settings Decoder Error");
		}
	}

	public bool isReverseAngle(Plane refPlane)
	{
		if (!buVector5.isPlaneXZ(refPlane))
		{
			if (!buVector5.isPlaneZX(refPlane))
			{
				if (!buVector5.isPlaneYZ(refPlane))
				{
					if (!buVector5.isPlaneZY(refPlane))
					{
						if (!buVector5.isPlaneXY(refPlane))
						{
							if (!buVector5.isPlaneYX(refPlane))
							{
								if (!(buCompare5.EQ(refPlane.Equation.X, 0.0, 0.1) & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1) & (refPlane.Equation.Z < 0.0)))
								{
									if (!(buCompare5.EQ(refPlane.Equation.X, 0.0, 0.1) & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1) & (refPlane.Equation.Z < 0.0)))
									{
										if (!(buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1) & buCompare5.EQ(refPlane.Equation.Z, 0.0, 0.1) & (refPlane.Equation.X < 0.0)))
										{
											if (!(buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.2) & buCompare5.EQ(refPlane.Equation.Z, 0.0, 0.2) & (refPlane.Equation.X > 0.0)))
											{
												if (!((refPlane.Equation.X < 0.0) & (refPlane.Equation.Z < 0.0) & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1)))
												{
													if (!((refPlane.Equation.X < 0.0) & (refPlane.Equation.Y < 0.0) & buCompare5.EQ(refPlane.Equation.Z, 0.0, 0.1)))
													{
														if (!((refPlane.Equation.X > 0.0) & (refPlane.Equation.Z < 0.0) & buCompare5.EQ(refPlane.Equation.Y, 0.0, 0.1)))
														{
															if (!((refPlane.Equation.X > 0.0) & (refPlane.Equation.Y > 0.0) & (refPlane.Equation.Z > 0.0)))
															{
																return false;
															}
															return true;
														}
														return false;
													}
													return false;
												}
												return true;
											}
											return false;
										}
										return false;
									}
									return false;
								}
								return true;
							}
							return true;
						}
						return false;
					}
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public void doWireframeToLRAList(List<buEntity> refEntities, ref List<BendingLRAMaterialData> LRAList)
	{
		if (LRAList == null)
		{
			LRAList = new List<BendingLRAMaterialData>();
		}
		LRAList.Clear();
		clsInit.cPipeBend.activeJob.AuxEntityList.Clear();
		if (refEntities.Count <= 0)
		{
			return;
		}
		Plane plane = null;
		Vector3D vector3D = null;
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			buEntity buEntity2 = refEntities[i];
			double num = 0.0;
			double num2 = 0.0;
			List<Point3D> copiedPoint = new List<Point3D>();
			List<Point3D> copiedPoint2 = new List<Point3D>();
			List<Point3D> copiedPoint3 = new List<Point3D>();
			buVector5.Copy(refEntities[i].Vertices, ref copiedPoint);
			if (refEntities[i].sortDirection == entitySortDirection.Reverse)
			{
				copiedPoint.Reverse();
			}
			if (i > 0)
			{
				buVector5.Copy(refEntities[i - 1].Vertices, ref copiedPoint3);
				if (refEntities[i - 1].sortDirection == entitySortDirection.Reverse)
				{
					copiedPoint3.Reverse();
				}
			}
			if (i < refEntities.Count - 1)
			{
				buVector5.Copy(refEntities[i + 1].Vertices, ref copiedPoint2);
				if (refEntities[i + 1].sortDirection == entitySortDirection.Reverse)
				{
					copiedPoint2.Reverse();
				}
			}
			clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
			PlaneAngle planeAngle = new PlaneAngle();
			PlaneAngle planeAngle2 = new PlaneAngle();
			Vector3D vector3D2 = new Vector3D(copiedPoint[0], copiedPoint[1]);
			if (copiedPoint3.Count <= 0)
			{
			}
			Vector3D vector3D3 = new Vector3D(copiedPoint[copiedPoint.Count - 1], copiedPoint[copiedPoint.Count - 2]);
			if (copiedPoint2.Count <= 0)
			{
			}
			Vector3D vector3D4 = Vector3D.Cross(vector3D2, vector3D3);
			clsInit.cVector5.VectorAngle(vector3D2, ref planeAngle.AngleXY, ref planeAngle.AngleXZ, ref planeAngle.AngleYZ);
			clsInit.cVector5.VectorAngle(vector3D3, ref planeAngle2.AngleXY, ref planeAngle2.AngleXZ, ref planeAngle2.AngleYZ);
			new Plane(copiedPoint[0], vector3D2);
			new Plane(copiedPoint[copiedPoint.Count - 1], vector3D3);
			buArc buArc2 = null;
			bool flag = false;
			if (buEntity2 is buArc)
			{
				buArc2 = buEntity2 as buArc;
				flag = isReverseAngle(buArc2.Plane);
			}
			if (vector3D4.Length > 0.0)
			{
				Plane plane2 = new Plane(vector3D4);
				Utility.VectorsAngle(vector3D3, vector3D2, plane2);
				if (buEntity2 is buArc)
				{
					if (copiedPoint3.Count <= 0)
					{
						num = ((buEntity2.sortDirection == entitySortDirection.Normal) ? (buArc2.EndAngle - buArc2.StartAngle) : (buArc2.StartAngle - buArc2.EndAngle));
					}
					else
					{
						if (buArc2.sortDirection != entitySortDirection.Normal)
						{
							if (!buCompare5.EQ(buArc2.StartPoint, copiedPoint3[copiedPoint3.Count - 1]))
							{
								if (buCompare5.EQ(buArc2.EndPoint, copiedPoint3[copiedPoint3.Count - 1]))
								{
									num = buArc2.EndAngle - buArc2.StartAngle;
								}
							}
							else
							{
								num = buArc2.StartAngle - buArc2.EndAngle;
							}
						}
						else if (!buCompare5.EQ(buArc2.StartPoint, copiedPoint3[copiedPoint3.Count - 1]))
						{
							if (buCompare5.EQ(buArc2.EndPoint, copiedPoint3[copiedPoint3.Count - 1]))
							{
								num = buArc2.EndAngle - buArc2.StartAngle;
							}
						}
						else
						{
							num = buArc2.StartAngle - buArc2.EndAngle;
						}
						if (flag)
						{
							num = 0.0 - num;
						}
					}
				}
			}
			if (vector3D != null && ((vector3D4.Length > 0.0) & (vector3D.Length > 0.0)))
			{
				int Count = 0;
				int Count2 = 0;
				clsInit.cVector5.HowManyVectorAxesDifferentThenZero(vector3D4, ref Count);
				clsInit.cVector5.HowManyTwoVectorAxesDifferentThenZero(vector3D, vector3D4, ref Count2);
				if (Count2 >= 2 && buArc2 != null)
				{
					double num3 = PlaneToPlaneDirection(plane.Equation, buArc2.Plane.Equation);
					num2 = num3 * AngleBetweenPlanes(plane, buArc2.Plane);
					AngleBetweenPlanes(plane.Equation, buArc2.Plane.Equation);
					if (copiedPoint3.Count <= 0)
					{
					}
				}
			}
			if (refEntities[i] is buLinearPath && refEntities[i].Vertices.Count == 2)
			{
				BendingLRAMaterialData bendingLRAMaterialData = new BendingLRAMaterialData();
				bendingLRAMaterialData.Length = Math.Round(clsInit.cVector5.Length3D(refEntities[i].Vertices), 3);
				LRAList.Add(bendingLRAMaterialData);
			}
			if (!(refEntities[i] is buLine))
			{
				if (!(refEntities[i] is buArc))
				{
					if (refEntities[i] is buArc)
					{
					}
				}
				else
				{
					if (!buCompare5.EQ(num2, 0.0, 0.01))
					{
						BendingLRAMaterialData bendingLRAMaterialData2 = new BendingLRAMaterialData();
						bendingLRAMaterialData2.Rotation = Math.Round(num2, 3);
						LRAList.Add(bendingLRAMaterialData2);
					}
					_ = (Plane)((buArc)refEntities[i]).Plane.Clone();
					plane = (Plane)((buArc)refEntities[i]).Plane.Clone();
					BendingLRAMaterialData bendingLRAMaterialData3 = new BendingLRAMaterialData();
					bendingLRAMaterialData3.Angle = Math.Round(num, 3);
					bendingLRAMaterialData3.Radius = Math.Round(((buArc)refEntities[i]).Radius);
					LRAList.Add(bendingLRAMaterialData3);
				}
			}
			else if (refEntities[i].Vertices.Count == 2)
			{
				BendingLRAMaterialData bendingLRAMaterialData4 = new BendingLRAMaterialData();
				bendingLRAMaterialData4.Length = Math.Round(clsInit.cVector5.Length3D(refEntities[i].Vertices), 3);
				LRAList.Add(bendingLRAMaterialData4);
			}
			if (vector3D4.Length > 0.0)
			{
				vector3D = Vector3D.Cross(vector3D2, vector3D3);
			}
		}
	}

	public double PlaneToPlaneDirection(Vector3D normal1, Vector3D normal2)
	{
		double result = 1.0;
		if (!(buVector5.isVectorYMinus(normal1) & buVector5.isVectorXPlus(normal2)))
		{
			if (!(buVector5.isVectorXPlus(normal1) & buVector5.isVectorZMinus(normal2)))
			{
				if (!(buVector5.isVectorXMinus(normal1) & buVector5.isVectorYPlus(normal2)))
				{
					if (!(buVector5.isVectorZMinus(normal1) & buVector5.isVectorXMinus(normal2)))
					{
						if (!(buVector5.isVectorZMinus(normal1) & buCompare5.EQ(normal2.Z, 0.0) & (normal2.X > 0.0) & (normal2.Y > 0.0)))
						{
							if (!(buCompare5.EQ(normal1.Z, 0.0) & (normal1.X < 0.0) & (normal1.Y < 0.0) & buVector5.isVectorZMinus(normal2)))
							{
								if (!(buVector5.isVectorYPlus(normal1) & buCompare5.EQ(normal2.Y, 0.0) & (normal2.X < 0.0) & (normal2.Z < 0.0)))
								{
									if (!(buCompare5.EQ(normal1.Y, 0.0) & (normal1.X < 0.0) & (normal1.Z < 0.0) & buVector5.isVectorYMinus(normal2)))
									{
										if (!(buCompare5.EQ(normal1.Y, 0.0) & (normal1.X < 0.0) & (normal1.Z > 0.0) & (normal2.X < 0.0) & (normal2.Y < 0.0) & (normal2.Z > 0.0)))
										{
											if (((normal1.X > 0.0) & (normal1.Y > 0.0) & (normal1.Z > 0.0) & buCompare5.EQ(normal2.Y, 0.0) & (normal2.X < 0.0)) && normal2.Z > 0.0)
											{
												result = 1.0;
											}
										}
										else
										{
											result = -1.0;
										}
									}
									else
									{
										result = 1.0;
									}
								}
								else
								{
									result = 1.0;
								}
							}
							else
							{
								result = -1.0;
							}
						}
						else
						{
							result = -1.0;
						}
					}
					else
					{
						result = -1.0;
					}
				}
				else
				{
					result = 1.0;
				}
			}
			else
			{
				result = -1.0;
			}
		}
		else
		{
			result = 1.0;
		}
		return result;
	}

	public static double AngleBetweenPlanes(Plane plane1, Plane plane2)
	{
		Vector3D equation = plane1.Equation;
		Vector3D equation2 = plane2.Equation;
		double num = Vector3D.Dot(equation, equation2);
		double num2 = equation.Length * equation2.Length;
		double num3 = num / num2;
		if (num3 < -1.0)
		{
			num3 = -1.0;
		}
		if (num3 > 1.0)
		{
			num3 = 1.0;
		}
		double num4 = Math.Acos(num3);
		double num5 = num4 * (180.0 / Math.PI);
		return (num5 <= 90.0) ? num5 : (180.0 - num5);
	}

	public static double AngleBetweenPlanes(Vector3D normal1, Vector3D normal2)
	{
		double num = Vector3D.Dot(normal1, normal2);
		double num2 = normal1.Length * normal2.Length;
		double num3 = num / num2;
		if (num3 < -1.0)
		{
			num3 = -1.0;
		}
		if (num3 > 1.0)
		{
			num3 = 1.0;
		}
		double num4 = Math.Acos(num3);
		double num5 = num4 * (180.0 / Math.PI);
		return (num5 <= 90.0) ? num5 : (180.0 - num5);
	}

	public void doGetFromSolid(Entity entPipe, ref List<buEntity> EL, ref double PipeDiameter)
	{
		EL.Clear();
		List<buEntity> BaseRefEntities = new List<buEntity>();
		List<Entity> list = new List<Entity>();
		if (entPipe is Brep)
		{
			Brep brep = entPipe as Brep;
			brep.Color = Color.FromArgb(150, brep.Color);
			if (brep.Faces.Length != 0)
			{
				for (int i = 0; i <= brep.Faces.Length - 1; i++)
				{
					if (i > brep.Faces.Length - 1)
					{
						continue;
					}
					Brep.Face face = brep.Faces[i];
					List<ICurve> list2 = new List<ICurve>();
					for (int j = 0; j <= face.Loops.Length - 1; j++)
					{
						for (int k = 0; k <= face.Loops[j].Segments.Length - 1; k++)
						{
							Brep.OrientedEdge orientedEdge = face.Loops[j].Segments[k];
							if ((orientedEdge.CurveIndex >= 0) & (orientedEdge.CurveIndex <= brep.Edges.Length - 1))
							{
								Entity copiedEntity = null;
								buEntity.Copy((Entity)brep.Edges[orientedEdge.CurveIndex].Curve, ref copiedEntity);
								copiedEntity.ColorMethod = colorMethodType.byEntity;
								copiedEntity.Color = Color.Red;
								copiedEntity.LineWeight = 4f;
								copiedEntity.LineWeightMethod = colorMethodType.byEntity;
								list2.Add((ICurve)copiedEntity);
							}
						}
					}
					Surface[] surface = face.Surface.GetSurface(list2);
					AnalyticSurf extended = face.Surface.GetExtended(list2);
					bool flag = false;
					if (surface != null && surface.Length != 0)
					{
						if (!(surface[0] is CylindricalSurface))
						{
							if (!(surface[0] is ToroidalSurface))
							{
								if (surface[0] is PlanarSurface)
								{
									for (int l = 0; l <= list2.Count - 1; l++)
									{
										if (!(list2[l] is Arc))
										{
										}
										flag = true;
									}
								}
							}
							else
							{
								Entity E = null;
								doGetToroidalSurface(surface[0], list2, ref E);
								if (E != null)
								{
									list.Add(E);
									buEntity buEntity2 = buEntity.Copy(E);
									if (!clsInit.cVector5.isEntitySame(BaseRefEntities, buEntity2))
									{
										BaseRefEntities.Add(buEntity2);
									}
									flag = true;
								}
							}
						}
						else
						{
							Entity E2 = null;
							double MinDiameter = 0.0;
							double MaxDiameter = 0.0;
							doGetCylindricalSurface(surface[0], list2, ref E2, ref MinDiameter, ref MaxDiameter);
							if (E2 != null)
							{
								if (MaxDiameter > 0.0)
								{
									PipeDiameter = MaxDiameter;
								}
								buEntity buEntity3 = buEntity.Copy(E2);
								if (!clsInit.cVector5.isEntitySame(BaseRefEntities, buEntity3))
								{
									BaseRefEntities.Add(buEntity3);
								}
								flag = true;
							}
						}
					}
					if (!(extended != null && !flag) || !(extended is ToroidalSurf))
					{
						continue;
					}
					Entity E3 = null;
					doGetToroidalSurface(extended, list2, ref E3);
					if (E3 != null)
					{
						list.Add(E3);
						buEntity buEntity4 = buEntity.Copy(E3);
						if (!clsInit.cVector5.isEntitySame(BaseRefEntities, buEntity4))
						{
							BaseRefEntities.Add(buEntity4);
						}
					}
				}
			}
			if (brep.Edges.Length != 0)
			{
				for (int m = 0; m <= brep.Edges.Length - 1; m++)
				{
					Entity copiedEntity2 = null;
					buEntity.Copy((Entity)brep.Edges[m].Curve, ref copiedEntity2);
				}
			}
		}
		if (list.Count <= 0)
		{
		}
		if (BaseRefEntities.Count <= 0)
		{
			return;
		}
		SortbuSettings sortbuSettings = new SortbuSettings();
		sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
		for (int n = 0; n <= BaseRefEntities.Count - 1; n++)
		{
			List<buEntity> SortedEntities = new List<buEntity>();
			clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[n].StartPoint, ref BaseRefEntities, sortbuSettings, ref SortedEntities);
			List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			if (SplitedEntitites.Count == 1)
			{
				buEntity.Copy(SortedEntities, ref EL);
				n = BaseRefEntities.Count;
			}
		}
		if (EL.Count != 0)
		{
			return;
		}
		for (int num = 0; num <= BaseRefEntities.Count - 1; num++)
		{
			List<buEntity> SortedEntities2 = new List<buEntity>();
			clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[num].EndPoint, ref BaseRefEntities, sortbuSettings, ref SortedEntities2);
			List<List<buEntity>> SplitedEntitites2 = new List<List<buEntity>>();
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities2, ref SplitedEntitites2);
			if (SplitedEntitites2.Count == 1)
			{
				buEntity.Copy(SortedEntities2, ref EL);
				num = BaseRefEntities.Count;
			}
		}
	}

	public void doGetCylindricalSurface(Surface S, List<ICurve> IC, ref Entity E, ref double MinDiameter, ref double MaxDiameter)
	{
		if (!(S is CylindricalSurface))
		{
			return;
		}
		List<Point3D> Points = new List<Point3D>();
		MinDiameter = 999999999.0;
		MaxDiameter = -999999999.0;
		double num = 0.0;
		for (int i = 0; i <= IC.Count - 1; i++)
		{
			if (IC[i] is Circle)
			{
				Points.Add(buVector5.ToPoint3D(((Circle)IC[i]).Center));
				if (((Circle)IC[i]).Radius * 2.0 > MaxDiameter)
				{
					MaxDiameter = ((Circle)IC[i]).Radius * 2.0;
				}
				if (((Circle)IC[i]).Radius * 2.0 < MinDiameter)
				{
					MinDiameter = ((Circle)IC[i]).Radius * 2.0;
				}
			}
			if (IC[i] is Line)
			{
				num = IC[i].Length();
				_ = IC[i].EndPoint.X - IC[i].StartPoint.X;
				_ = IC[i].EndPoint.Y - IC[i].StartPoint.Y;
				_ = IC[i].EndPoint.Z - IC[i].StartPoint.Z;
			}
		}
		new Point3D(((CylindricalSurface)S).Center.X, ((CylindricalSurface)S).Center.Y, ((CylindricalSurface)S).Center.Z);
		Point3D point3D = new Point3D();
		point3D.X = ((CylindricalSurface)S).Center.X + num * ((CylindricalSurface)S).Axis.X;
		point3D.Y = ((CylindricalSurface)S).Center.Y + num * ((CylindricalSurface)S).Axis.Y;
		point3D.Z = ((CylindricalSurface)S).Center.Z + num * ((CylindricalSurface)S).Axis.Z;
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
		if (Points.Count >= 2 && Points[0] == Points[Points.Count - 1])
		{
			Points.RemoveAt(Points.Count - 1);
		}
		if (Points.Count == 1)
		{
			new Point3D(Points[0].X + num * ((CylindricalSurface)S).Axis.X, Points[0].Y + num * ((CylindricalSurface)S).Axis.Y, Points[0].Z + num * ((CylindricalSurface)S).Axis.Z);
		}
		if (Points.Count >= 2)
		{
			E = new LinearPath(Points);
			E.ColorMethod = colorMethodType.byEntity;
			E.Color = Color.Red;
			E.LineWeight = 4f;
			E.LineWeightMethod = colorMethodType.byEntity;
		}
	}

	public void doGetToroidalSurface(AnalyticSurf S, List<ICurve> IC, ref Entity E)
	{
		ToroidalSurf toroidalSurf = S as ToroidalSurf;
		Point3D point3D = null;
		Arc arc = null;
		for (int i = 0; i <= IC.Count - 1; i++)
		{
			if (IC[i] is Arc)
			{
				Arc arc2 = IC[i] as Arc;
				if (buCompare5.EQ(arc2.Radius, toroidalSurf.MajorRadius + toroidalSurf.MinorRadius, 0.1))
				{
					point3D = buVector5.ToPoint3D(arc2.Center);
					arc = arc2;
				}
			}
		}
		if (point3D != null && arc != null)
		{
			E = new Arc(arc.Plane, point3D, toroidalSurf.MajorRadius, arc.StartPoint, arc.EndPoint, flip: false);
			E.ColorMethod = colorMethodType.byEntity;
			E.Color = Color.Red;
			E.LineWeight = 4f;
			E.LineWeightMethod = colorMethodType.byEntity;
		}
	}

	public void doGetToroidalSurface(Surface S, List<ICurve> IC, ref Entity E)
	{
		ToroidalSurface toroidalSurface = S as ToroidalSurface;
		Point3D point3D = null;
		Arc arc = null;
		for (int i = 0; i <= IC.Count - 1; i++)
		{
			if (IC[i] is Arc)
			{
				Arc arc2 = IC[i] as Arc;
				if (buCompare5.EQ(arc2.Radius, toroidalSurface.MajorRadius + toroidalSurface.MinorRadius, 0.1))
				{
					point3D = buVector5.ToPoint3D(arc2.Center);
					arc = arc2;
				}
			}
		}
		if (point3D != null && arc != null)
		{
			E = new Arc(arc.Plane, point3D, toroidalSurface.MajorRadius, arc.StartPoint, arc.EndPoint, flip: false);
			E.ColorMethod = colorMethodType.byEntity;
			E.Color = Color.Red;
			E.LineWeight = 4f;
			E.LineWeightMethod = colorMethodType.byEntity;
		}
	}

	public void doCreateCodes(ref PipeBendJob Item)
	{
		try
		{
			if (Item != null)
			{
				new PipeBendSimulationMove();
				Item.SimMoves.Clear();
				double yPos = 0.0;
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = -999999.0;
				doAddBendList(ref Item, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0, MovePipe: false, Devide: false);
				int num6 = 0;
				for (int i = 0; i <= Item.BendingList.Count - 1; i++)
				{
					new PipeBendSimulationMove();
					double num7 = 0.0;
					double radius = Item.BendingList[i].Radius;
					for (int j = i + 1; j <= Item.BendingList.Count - 1; j++)
					{
						if (Item.BendingList[j].Radius > 0.0)
						{
							num7 = Item.BendingList[j].Radius;
							j = Item.BendingList.Count;
						}
					}
					if (radius == 0.0)
					{
						if (!(num7 >= 300.0))
						{
							if (!(num7 >= 200.0 && num7 < 300.0))
							{
								num2 = -155.0;
								num6 = 2;
							}
							else
							{
								num2 = -75.0;
								num6 = 1;
							}
						}
						else
						{
							num2 = 0.0;
							num6 = 0;
						}
						if (num2 != num5)
						{
							num = 0.0;
							yPos = -50.0;
							doAddBendList(ref Item, 0.0, yPos, Item.SimMoves[Item.SimMoves.Count - 1].ZPos, num3, num4, 0.0, 0.0, num, 0.0, 0.0, i, MovePipe: false, Devide: true);
							doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, num, 0.0, 0.0, i, MovePipe: false, Devide: true);
							if (num6 == 0)
							{
								yPos = 0.0;
							}
							if (num6 == 1)
							{
								yPos = 50.0;
							}
							if (num6 == 2)
							{
								yPos = 100.0;
							}
							doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, num, 0.0, 0.0, i, MovePipe: false, Devide: true);
						}
					}
					if (!(Item.BendingList[i].Angle > 0.0))
					{
						if (Item.BendingList[i].Angle < 0.0)
						{
							if (num6 == 0)
							{
								num = -150.0;
							}
							if (num6 == 1)
							{
								num = -100.0;
							}
							if (num6 == 2)
							{
								num = -50.0;
							}
							doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 180.0, num, 0.0, 0.0, i, MovePipe: true, Devide: false);
							doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, num, 0.0, 0.0, i, MovePipe: false, Devide: true);
							num4 = Item.BendingList[i].Angle;
							doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0 - Item.BendingList[i].Angle, 0.0, 0.0, num, Item.BendingList[i].Radius, i, MovePipe: true, Devide: false);
							num4 = 0.0;
							doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, 0.0, num, Item.BendingList[i].Radius, i, MovePipe: false, Devide: true);
							num = 0.0;
							doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, 0.0, num, Item.BendingList[i].Radius, i, MovePipe: false, Devide: true);
						}
					}
					else
					{
						if (num6 == 0)
						{
							num = -150.0;
						}
						if (num6 == 1)
						{
							num = -100.0;
						}
						if (num6 == 2)
						{
							num = -50.0;
						}
						doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, num, 0.0, 0.0, i, MovePipe: false, Devide: true);
						num4 = 0.0 - Item.BendingList[i].Angle;
						doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, Item.BendingList[i].Angle, 0.0, 0.0, num, Item.BendingList[i].Radius, i, MovePipe: true, Devide: true);
						num4 = 0.0;
						doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, 0.0, num, Item.BendingList[i].Radius, i, MovePipe: false, Devide: true);
						num = 0.0;
						doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, 0.0, 0.0, num, Item.BendingList[i].Radius, i, MovePipe: false, Devide: true);
					}
					if (Item.BendingList[i].Rotation > 0.0)
					{
						doAddBendList(ref Item, 0.0, yPos, num2, num3, num4, 0.0, Item.BendingList[i].Rotation, num, 0.0, 0.0, i, MovePipe: true, Devide: false);
					}
					if (Item.BendingList[i].Length > 0.0)
					{
						doAddBendList(ref Item, Item.BendingList[i].Length, yPos, num2, num3, num3, num4, 0.0, num, 0.0, 0.0, i, MovePipe: true, Devide: true);
					}
					num5 = num2;
				}
			}
			doAddBendList(ref Item, -100.0, Item.SimMoves[Item.SimMoves.Count - 1].YPos, Item.SimMoves[Item.SimMoves.Count - 1].ZPos, Item.SimMoves[Item.SimMoves.Count - 1].APos, Item.SimMoves[Item.SimMoves.Count - 1].CPos, Item.SimMoves[Item.SimMoves.Count - 1].BendPos, Item.SimMoves[Item.SimMoves.Count - 1].RotatePos, Item.SimMoves[Item.SimMoves.Count - 1].YPreasurePos, Item.SimMoves[Item.SimMoves.Count - 1].XBendingPos, 0.0, Item.SimMoves[Item.SimMoves.Count - 1].IndexMove, MovePipe: false, Devide: true);
			buUserSimVariables.indexSim = 0;
		}
		catch (Exception)
		{
		}
	}

	public void doAddBendList(ref PipeBendJob Item, double XPos, double YPos, double ZPos, double APos, double CPos, double BendAngle, double Rotation, double YPreasure, double XBending, double Radius, int Index, bool MovePipe, bool Devide)
	{
		if (Item.SimMoves.Count != 0)
		{
			PipeBendSimulationMove pipeBendSimulationMove = new PipeBendSimulationMove(XPos, YPos, ZPos, APos, CPos, BendAngle, Rotation, YPreasure, XBending, Radius, MovePipe, Index, PipeBendMoveCommand.None);
			pipeBendSimulationMove.ExecutedPipe = Item.SimMoves[Item.SimMoves.Count - 1].ExecutedPipe;
			if (PipeBendSimulationMove.EQ(pipeBendSimulationMove, Item.SimMoves[Item.SimMoves.Count - 1]))
			{
				return;
			}
			if (!Devide)
			{
				Item.SimMoves.Add(pipeBendSimulationMove);
				return;
			}
			List<PipeBendSimulationMove> devidedPoints = new List<PipeBendSimulationMove>();
			clsInit.cPipeBend.SimulationPointDevide(Item.SimMoves[Item.SimMoves.Count - 1], pipeBendSimulationMove, 0.0, 10, Item.SimMoves[Item.SimMoves.Count - 1].ExecutedPipe, ref devidedPoints);
			if (devidedPoints.Count <= 0)
			{
				PipeBendSimulationMove pipeBendSimulationMove2 = new PipeBendSimulationMove(XPos, YPos, ZPos, APos, CPos, BendAngle, Rotation, YPreasure, XBending, Radius, MovePipe, Index, PipeBendMoveCommand.None);
				pipeBendSimulationMove2.ExecutedPipe = Item.SimMoves[Item.SimMoves.Count - 1].ExecutedPipe;
				Item.SimMoves.Add(pipeBendSimulationMove2);
				return;
			}
			for (int i = 0; i <= devidedPoints.Count - 1; i++)
			{
				PipeBendSimulationMove item = new PipeBendSimulationMove(devidedPoints[i]);
				Item.SimMoves.Add(item);
			}
		}
		else
		{
			PipeBendSimulationMove item2 = new PipeBendSimulationMove(XPos, YPos, ZPos, APos, CPos, BendAngle, Rotation, YPreasure, XBending, Radius, MovePipe, 0, PipeBendMoveCommand.None);
			Item.SimMoves.Add(item2);
		}
	}
}
