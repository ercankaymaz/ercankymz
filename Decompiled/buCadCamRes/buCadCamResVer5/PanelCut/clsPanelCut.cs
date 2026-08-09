using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buCadCamResVer5.Nesting;
using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Forms.BarCodes;
using buEyeBaseVer5.Forms.PanelCut;
using buEyeBaseVer5.buEntities;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.PanelCut;

public class clsPanelCut
{
	public static PanelCutTempVars varTemps = new PanelCutTempVars();

	public static PanelCutSettings varPanelCutSettings = new PanelCutSettings();

	public static PanelCutRuntimeSettings varPanelCutRunSettings = new PanelCutRuntimeSettings();

	public F_PanelCutMachSim frmMachSim = null;

	public F_PanelCutSheetList FrmNestPanelSheet = null;

	public F_PanelCutPartList FrmNestPanelPart = null;

	public F_PanelCutMaterials FrmPanelCutMaterial = null;

	public static Design viewportAuto = null;

	public static Design viewportAutoPanel = null;

	public static Design viewportAutoDone = null;

	public static Design viewportAutoWaiting = null;

	public Plane planeActive = Plane.XY;

	public bool isCollisionRunning = false;

	public static List<int> SimMovePartIndex = new List<int>();

	public int indexSim = -1;

	public int selectedJobIndex = -1;

	public int selectedItemIndex = -1;

	public int selectedItemSubIndex = -1;

	public int entityIndex = -1;

	public List<string> cmdExceptionID = new List<string>();

	public int JobIndex = -1;

	public int MoveIndex = 0;

	public NestingPanelJob activeJob = new NestingPanelJob();

	public NestingPanel cutPanel = new NestingPanel();

	public Timer timSim = null;

	public void Init()
	{
		FrmPanelCutMaterial = new F_PanelCutMaterials();
		clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
		clsInit.appNestingPanel.CalculationDone += doCalculationDone;
		clsItem.FrmPanelCutJob.dgv_sheets.CellClick += SheetDone_CellClick;
		clsItem.FrmPanelCutJob.dgv_sheets.RowHeadersVisible = false;
		clsItem.FrmPanelCutJob.dgv_sheets.AllowUserToAddRows = false;
		clsItem.FrmPanelCutJob.dgv_sheets.AllowUserToResizeColumns = false;
		if (clsItem.FrmPanelCutJob.dgv_sheets.Columns.Count == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn.Width = 100;
			dataGridViewColumn.HeaderText = "No";
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 180;
			dataGridViewColumn2.HeaderText = "Size";
			dataGridViewColumn2.Name = "Size";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn3.Width = 100;
			dataGridViewColumn3.HeaderText = "Count";
			dataGridViewColumn3.Name = "Count";
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn4.Width = 120;
			dataGridViewColumn4.HeaderText = "Parts";
			dataGridViewColumn4.Name = "Parts";
			dataGridViewColumn4.ReadOnly = true;
			dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn5.Width = 120;
			dataGridViewColumn5.HeaderText = "Waste";
			dataGridViewColumn5.Name = "Waste";
			dataGridViewColumn5.ReadOnly = false;
			dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn6.Width = 200;
			dataGridViewColumn6.HeaderText = "Total Cut";
			dataGridViewColumn6.Name = "TotalCut";
			dataGridViewColumn6.ReadOnly = false;
			dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn7.Width = 150;
			dataGridViewColumn7.HeaderText = "Material";
			dataGridViewColumn7.Name = "Material";
			dataGridViewColumn7.ReadOnly = false;
			dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn8.Width = 400;
			dataGridViewColumn8.HeaderText = "Explanation";
			dataGridViewColumn8.Name = "Explanation";
			dataGridViewColumn8.ReadOnly = true;
			dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
			clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn8);
		}
		timSim = new Timer();
		timSim.Tick += tick_Simulation;
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
	}

	public void InitViewport()
	{
		if (frmMachSim == null)
		{
			frmMachSim = new F_PanelCutMachSim();
			frmMachSim.ValueChanged += SimValueChaned;
		}
		if (viewportAuto == null)
		{
			CreateModelProperties createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
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
			clsInit.cVector5.CreateModelControl(ref viewportAuto, clsVar.UnlockKey, createModelProperties);
			viewportAuto.Name = "ModelAuto";
			frmMachSim.pnl_viewport.Controls.Add(viewportAuto);
			viewportAuto.MouseMove += method_0;
			viewportAuto.MouseDown += method_1;
			viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
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
			for (int k = 0; k < 8; k++)
			{
				for (int l = 0; l <= ccVars.SimMachine.Clampers.Count - 1; l++)
				{
					for (int m = 0; m <= ccVars.SimMachine.Clampers[l].Entities.Count - 1; m++)
					{
						Entity entity3 = buVector5.CopyEntities(ccVars.SimMachine.Clampers[l].Entities[m]);
						CustomData customData2 = new CustomData();
						customData2.typeDefination = entityTypeDefination.MachineParts;
						customData2.EntityName = ccVars.SimMachine.Clampers[l].PartName;
						entity3.EntityData = customData2;
						entity3.Regen(new RegenParams(buSystem.RegenDeviation, viewportAuto));
						string text2 = ((CustomData)entity3.EntityData).EntityName + k;
						if (text2.Length == 0)
						{
							text2 = "BlockClamper" + k + l;
						}
						Block block2 = new Block(text2);
						Entity entity4 = buVector5.CopyEntities(entity3);
						entity4.Color = Color.Linen;
						int alpha2 = 255;
						if ((ccVars.SimMachine.Clampers[l].Transparency >= 0) & (ccVars.SimMachine.Clampers[l].Transparency <= 255))
						{
							alpha2 = ccVars.SimMachine.Clampers[l].Transparency;
						}
						if (l <= ccVars.SimMachine.Clampers.Count - 1)
						{
							entity4.Color = Color.FromArgb(alpha2, ccVars.SimMachine.Clampers[l].Color);
						}
						entity4.ColorMethod = colorMethodType.byEntity;
						block2.Entities.Add(entity4);
						viewportAuto.Blocks.Add(block2);
					}
				}
			}
		}
		if (viewportAutoPanel == null)
		{
			CreateModelProperties createModelProperties2 = new CreateModelProperties();
			createModelProperties2.CoordinateSystemIconVisible = false;
			createModelProperties2.OriginSymbolVisible = false;
			createModelProperties2.ViewCubeIconVisible = false;
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
			clsInit.cVector5.CreateModelControl(ref viewportAutoPanel, clsVar.UnlockKey, createModelProperties2);
			viewportAutoPanel.Name = "ModelAutoPanel";
			frmMachSim.pnl_viewportpanel.Controls.Add(viewportAutoPanel);
			viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		if (viewportAutoDone == null)
		{
			CreateModelProperties createModelProperties3 = new CreateModelProperties();
			createModelProperties3.CoordinateSystemIconVisible = false;
			createModelProperties3.OriginSymbolVisible = false;
			createModelProperties3.ViewCubeIconVisible = false;
			createModelProperties3.OrigineCaptionVisible = false;
			createModelProperties3.ToolBorVisible = false;
			createModelProperties3.BottomColor = Color.LightGray;
			createModelProperties3.MiddleColor = Color.WhiteSmoke;
			createModelProperties3.TopColor = Color.LightGray;
			createModelProperties3.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties3.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties3.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties3.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties3.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties3.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			clsInit.cVector5.CreateModelControl(ref viewportAutoDone, clsVar.UnlockKey, createModelProperties3);
			viewportAutoDone.Name = "ModelAutoDone";
			frmMachSim.pnl_viewportdone.Controls.Add(viewportAutoDone);
			viewportAutoDone.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		if (viewportAutoWaiting == null)
		{
			CreateModelProperties createModelProperties4 = new CreateModelProperties();
			createModelProperties4.CoordinateSystemIconVisible = false;
			createModelProperties4.OriginSymbolVisible = false;
			createModelProperties4.ViewCubeIconVisible = false;
			createModelProperties4.OrigineCaptionVisible = false;
			createModelProperties4.ToolBorVisible = false;
			createModelProperties4.BottomColor = Color.LightGray;
			createModelProperties4.MiddleColor = Color.WhiteSmoke;
			createModelProperties4.TopColor = Color.LightGray;
			createModelProperties4.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties4.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties4.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties4.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties4.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties4.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			clsInit.cVector5.CreateModelControl(ref viewportAutoWaiting, clsVar.UnlockKey, createModelProperties4);
			viewportAutoWaiting.Name = "ModelAutoWaiting";
			frmMachSim.pnl_viewportwaiting.Controls.Add(viewportAutoWaiting);
			viewportAutoWaiting.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
	}

	public void cmdNestingExecute()
	{
		GC.Collect();
		clsInit.appNestingPanel.Execute();
	}

	public void cmdNestingMaterial()
	{
		try
		{
			if (FrmPanelCutMaterial == null)
			{
				return;
			}
			if (FrmPanelCutMaterial.Visible)
			{
				FrmNestPanelSheet.Visible = false;
				return;
			}
			FrmPanelCutMaterial.Materails.Clear();
			FrmPanelCutMaterial.Materails = new List<buNestingMaterials>();
			FrmPanelCutMaterial.Materails = buNestingMaterials.Copy(clsNesting.Materials);
			FrmPanelCutMaterial.Init();
			FrmPanelCutMaterial.ShowDialog();
			if (FrmPanelCutMaterial.PropertiesForm.Result == DialogResult.OK)
			{
				clsNesting.Materials = buNestingMaterials.Copy(FrmPanelCutMaterial.Materails);
				clsInit.appNesting.SaveNestingFile();
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdShowSheetPage(bool SheetVisible)
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				if (FrmNestPanelSheet == null)
				{
					FrmNestPanelSheet = new F_PanelCutSheetList();
				}
				if (FrmNestPanelSheet == null)
				{
					return;
				}
				if (FrmNestPanelSheet.Visible)
				{
					FrmNestPanelSheet.Visible = false;
					return;
				}
				FrmNestPanelSheet.CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
				FrmNestPanelSheet.AddPartFromFileExtenderAsCsvType = true;
				FrmNestPanelSheet.Sheets.Clear();
				FrmNestPanelSheet.Sheets = new List<buNestingSheet>();
				for (int i = 0; i <= clsNesting.Sheets.Count - 1; i++)
				{
					buNestingSheet Copied = new buNestingSheet();
					buNestingSheet.Copy(clsNesting.Sheets[i], ref Copied);
					if (Copied.ID <= 0)
					{
						clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref Copied.ID);
						clsNesting.Sheets[i].ID = Copied.ID;
					}
					FrmNestPanelSheet.Sheets.Add(Copied);
				}
				FrmNestPanelSheet.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
				if (!SheetVisible)
				{
					FrmNestPanelSheet.Init(1);
				}
				else
				{
					FrmNestPanelSheet.Init(0);
				}
				FrmNestPanelSheet.ShowDialog();
				if (FrmNestPanelSheet.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				SheetUpdate();
				if (FrmNestPanelSheet.SendToCad)
				{
					clsInit.appCommand.undoBuffer();
					for (int j = 0; j <= FrmNestPanelSheet.SendToCadEntities.Count - 1; j++)
					{
						ccVars.UndoDont = true;
						clsInit.appCommand.AddEntity(FrmNestPanelSheet.SendToCadEntities[j]);
					}
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdNestingSheets()
	{
		if (FrmNestPanelSheet == null)
		{
			FrmNestPanelSheet = new F_PanelCutSheetList();
		}
		if (FrmNestPanelSheet == null)
		{
			return;
		}
		if (FrmNestPanelSheet.Visible)
		{
			FrmNestPanelSheet.Visible = false;
			return;
		}
		FrmNestPanelSheet.CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
		FrmNestPanelSheet.AddPartFromFileExtenderAsCsvType = true;
		FrmNestPanelSheet.Sheets.Clear();
		FrmNestPanelSheet.Sheets = new List<buNestingSheet>();
		for (int i = 0; i <= clsNesting.Sheets.Count - 1; i++)
		{
			buNestingSheet Copied = new buNestingSheet();
			buNestingSheet.Copy(clsNesting.Sheets[i], ref Copied);
			if (Copied.ID <= 0)
			{
				clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref Copied.ID);
				clsNesting.Sheets[i].ID = Copied.ID;
			}
			FrmNestPanelSheet.Sheets.Add(Copied);
		}
		FrmNestPanelSheet.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
		FrmNestPanelSheet.Init(0);
		FrmNestPanelSheet.ShowDialog();
		if (FrmNestPanelSheet.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		SheetUpdate();
		if (FrmNestPanelSheet.SendToCad)
		{
			clsInit.appCommand.undoBuffer();
			for (int j = 0; j <= FrmNestPanelSheet.SendToCadEntities.Count - 1; j++)
			{
				ccVars.UndoDont = true;
				clsInit.appCommand.AddEntity(FrmNestPanelSheet.SendToCadEntities[j]);
			}
		}
	}

	public void cmdNestingParts()
	{
		if (FrmNestPanelPart == null)
		{
			FrmNestPanelPart = new F_PanelCutPartList();
		}
		if (FrmNestPanelPart == null)
		{
			return;
		}
		if (FrmNestPanelPart.Visible)
		{
			FrmNestPanelPart.Visible = false;
			return;
		}
		FrmNestPanelPart.CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
		FrmNestPanelPart.AddPartFromFileExtenderAsCsvType = true;
		FrmNestPanelPart.Parts.Clear();
		FrmNestPanelPart.Parts = new List<buNestingPart>();
		for (int i = 0; i <= clsNesting.Parts.Count - 1; i++)
		{
			buNestingPart Copied = new buNestingPart();
			buNestingPart.Copy(clsNesting.Parts[i], ref Copied);
			if (Copied.ID <= 0)
			{
				clsInit.cNesting.GetAvailableNestingPartID(clsNesting.Parts, ref Copied.ID);
				clsNesting.Sheets[i].ID = Copied.ID;
			}
			FrmNestPanelPart.Parts.Add(Copied);
		}
		FrmNestPanelPart.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
		FrmNestPanelPart.Init(0);
		FrmNestPanelPart.ShowDialog();
		if (FrmNestPanelPart.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		PartUpdate();
		if (FrmNestPanelPart.SendToCad)
		{
			clsInit.appCommand.undoBuffer();
			for (int j = 0; j <= FrmNestPanelPart.SendToCadEntities.Count - 1; j++)
			{
				ccVars.UndoDont = true;
				clsInit.appCommand.AddEntity(FrmNestPanelPart.SendToCadEntities[j]);
			}
		}
	}

	public void cmdNestingSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = "Nesting";
			f_ClassViewerDialog.Value = varPanelCutSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 600;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				varPanelCutSettings = new PanelCutSettings((PanelCutSettings)f_ClassViewerDialog.Value);
				clsFiles.SaveParameter();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdSimilation()
	{
		if (frmMachSim == null)
		{
			frmMachSim = new F_PanelCutMachSim();
			frmMachSim.ValueChanged += SimValueChaned;
		}
		if (viewportAuto == null)
		{
			CreateModelProperties createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
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
			clsInit.cVector5.CreateModelControl(ref viewportAuto, clsVar.UnlockKey, createModelProperties);
			viewportAuto.Name = "ModelAuto";
			frmMachSim.pnl_viewport.Controls.Add(viewportAuto);
			viewportAuto.MouseMove += method_0;
			viewportAuto.MouseDown += method_1;
			viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
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
			for (int k = 0; k < 8; k++)
			{
				for (int l = 0; l <= ccVars.SimMachine.Clampers.Count - 1; l++)
				{
					for (int m = 0; m <= ccVars.SimMachine.Clampers[l].Entities.Count - 1; m++)
					{
						Entity entity3 = buVector5.CopyEntities(ccVars.SimMachine.Clampers[l].Entities[m]);
						CustomData customData2 = new CustomData();
						customData2.typeDefination = entityTypeDefination.MachineParts;
						customData2.EntityName = ccVars.SimMachine.Clampers[l].PartName;
						entity3.EntityData = customData2;
						entity3.Regen(new RegenParams(buSystem.RegenDeviation, viewportAuto));
						string text2 = ((CustomData)entity3.EntityData).EntityName + k;
						if (text2.Length == 0)
						{
							text2 = "BlockClamper" + k + l;
						}
						Block block2 = new Block(text2);
						Entity entity4 = buVector5.CopyEntities(entity3);
						entity4.Color = Color.Linen;
						int alpha2 = 255;
						if ((ccVars.SimMachine.Clampers[l].Transparency >= 0) & (ccVars.SimMachine.Clampers[l].Transparency <= 255))
						{
							alpha2 = ccVars.SimMachine.Clampers[l].Transparency;
						}
						if (l <= ccVars.SimMachine.Clampers.Count - 1)
						{
							entity4.Color = Color.FromArgb(alpha2, ccVars.SimMachine.Clampers[l].Color);
						}
						entity4.ColorMethod = colorMethodType.byEntity;
						block2.Entities.Add(entity4);
						viewportAuto.Blocks.Add(block2);
					}
				}
			}
		}
		if (viewportAutoPanel == null)
		{
			CreateModelProperties createModelProperties2 = new CreateModelProperties();
			createModelProperties2.CoordinateSystemIconVisible = false;
			createModelProperties2.OriginSymbolVisible = false;
			createModelProperties2.ViewCubeIconVisible = false;
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
			clsInit.cVector5.CreateModelControl(ref viewportAutoPanel, clsVar.UnlockKey, createModelProperties2);
			viewportAutoPanel.Name = "ModelAutoPanel";
			frmMachSim.pnl_viewportpanel.Controls.Add(viewportAutoPanel);
			viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		if (viewportAutoDone == null)
		{
			CreateModelProperties createModelProperties3 = new CreateModelProperties();
			createModelProperties3.CoordinateSystemIconVisible = false;
			createModelProperties3.OriginSymbolVisible = false;
			createModelProperties3.ViewCubeIconVisible = false;
			createModelProperties3.OrigineCaptionVisible = false;
			createModelProperties3.ToolBorVisible = false;
			createModelProperties3.BottomColor = Color.LightGray;
			createModelProperties3.MiddleColor = Color.WhiteSmoke;
			createModelProperties3.TopColor = Color.LightGray;
			createModelProperties3.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties3.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties3.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties3.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties3.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties3.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			clsInit.cVector5.CreateModelControl(ref viewportAutoDone, clsVar.UnlockKey, createModelProperties3);
			viewportAutoDone.Name = "ModelAutoDone";
			frmMachSim.pnl_viewportdone.Controls.Add(viewportAutoDone);
			viewportAutoDone.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		if (viewportAutoWaiting == null)
		{
			CreateModelProperties createModelProperties4 = new CreateModelProperties();
			createModelProperties4.CoordinateSystemIconVisible = false;
			createModelProperties4.OriginSymbolVisible = false;
			createModelProperties4.ViewCubeIconVisible = false;
			createModelProperties4.OrigineCaptionVisible = false;
			createModelProperties4.ToolBorVisible = false;
			createModelProperties4.BottomColor = Color.LightGray;
			createModelProperties4.MiddleColor = Color.WhiteSmoke;
			createModelProperties4.TopColor = Color.LightGray;
			createModelProperties4.PanMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties4.PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
			createModelProperties4.RotateMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties4.RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
			createModelProperties4.ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
			createModelProperties4.ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
			clsInit.cVector5.CreateModelControl(ref viewportAutoWaiting, clsVar.UnlockKey, createModelProperties4);
			viewportAutoWaiting.Name = "ModelAutoWaiting";
			frmMachSim.pnl_viewportwaiting.Controls.Add(viewportAutoWaiting);
			viewportAutoWaiting.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		}
		if (viewportAuto.Layers.Count != ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count)
		{
			viewportAuto.Layers.Clear();
			for (int n = 0; n <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; n++)
			{
				viewportAuto.Layers.Add((Layer)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[n].Clone());
			}
		}
		JobToSimulationMoves();
		frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		frmMachSim.txt_gcode.Text = "";
		frmMachSim.Init();
		frmMachSim.txt_gcode.Text = buString5.StringListToString(activeJob.SimulationCodes, NewLineEnable: true);
		frmMachSim.StartPosition = FormStartPosition.CenterParent;
		frmMachSim.ShowDialog();
		if (frmMachSim.PropertiesForm.Result != DialogResult.OK)
		{
		}
	}

	public void cmdStartSimulation(bool Step)
	{
		timSim.Interval = 20;
		varPanelCutRunSettings.StepRun = Step;
		if (!viewportAuto.IsAnimationRunning)
		{
			viewportAuto.StartAnimation(varPanelCutSettings.simulationInterval);
		}
		if (indexSim == -1)
		{
			indexSim = 0;
		}
		if (indexSim == 0)
		{
			viewportAutoDone.Entities.Clear();
			viewportAutoWaiting.Entities.Clear();
			viewportAutoDone.Invalidate();
			viewportAutoWaiting.Invalidate();
			activeJob.DoneParts.Clear();
			activeJob.WaitingAssembly.Clear();
		}
		timSim.Enabled = true;
		if (Step)
		{
			if (varPanelCutRunSettings.StepRun && Step)
			{
				varTemps.simRelease = true;
			}
		}
		else
		{
			varPanelCutRunSettings.StepRun = false;
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
			isCollisionRunning = false;
			SimFinished();
		}
		else
		{
			timSim.Enabled = false;
		}
	}

	public void cmdMenuCommand(object sender, EventArgs e)
	{
		string text = "";
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
		if (text == clsItem.FrmPanelCutJob.btn_viewfront.Name)
		{
			clsItem.ModelMainPreview.SetView(viewType.Front);
			clsItem.ModelMainPreview.Invalidate();
		}
		if (text == clsItem.FrmPanelCutJob.btn_viewleft.Name)
		{
			clsItem.ModelMainPreview.SetView(viewType.Left);
			clsItem.ModelMainPreview.Invalidate();
		}
		if (text == clsItem.FrmPanelCutJob.btn_viewiso.Name)
		{
			clsItem.ModelMainPreview.SetView(viewType.Isometric);
			clsItem.ModelMainPreview.Invalidate();
		}
		if (text == clsItem.FrmPanelCutJob.btn_zoomfit.Name)
		{
			clsItem.ModelMainPreview.ZoomFit();
			clsItem.ModelMainPreview.Invalidate();
		}
	}

	public void cmdSetView(viewType Type)
	{
		switch (Type)
		{
		default:
			buEyeShotFunctions.ViewIso(ref viewportAuto, isZoomFit: false);
			clsInit.appPanelCut.planeActive = Plane.XY;
			break;
		case viewType.Top:
			buEyeShotFunctions.ViewTop(ref viewportAuto, isZoomFit: false);
			clsInit.appPanelCut.planeActive = Plane.XY;
			break;
		case viewType.Bottom:
			buEyeShotFunctions.ShowViewportViewBox(ref viewportAuto, Show: false);
			clsInit.appPanelCut.planeActive = Plane.XY;
			break;
		case viewType.Front:
			buEyeShotFunctions.Viewfront(ref viewportAuto, isZoomFit: false);
			clsInit.appPanelCut.planeActive = Plane.XZ;
			break;
		case viewType.Rear:
			buEyeShotFunctions.ViewBack(ref viewportAuto, isZoomFit: false);
			clsInit.appPanelCut.planeActive = Plane.XZ;
			break;
		case viewType.Left:
			buEyeShotFunctions.ViewLeft(ref viewportAuto, isZoomFit: false);
			clsInit.appPanelCut.planeActive = Plane.YZ;
			break;
		case viewType.Right:
			buEyeShotFunctions.ViewRight(ref viewportAuto, isZoomFit: false);
			clsInit.appPanelCut.planeActive = Plane.YZ;
			break;
		}
	}

	public void cmdZoomFit()
	{
		buEyeShotFunctions.ZoomFit(ref viewportAuto);
	}

	public void cmdBarCode()
	{
		F_BarCode f_BarCode = new F_BarCode();
		f_BarCode.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
		f_BarCode.StartPosition = FormStartPosition.CenterParent;
		f_BarCode.Init();
		f_BarCode.ShowDialog();
	}

	public void cmdQRCode()
	{
	}

	public void cmdShowCode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					if (activeJob.Panels.Count != 0)
					{
						varTemps.OffcutCount = 0;
						new ArrayList();
						string Code = "";
						doCreateCode(ref Code);
						F_Notepad f_Notepad = new F_Notepad();
						f_Notepad.Init(Code);
						f_Notepad.Show();
					}
				}
				else
				{
					buString5.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private void method_0(object sender, MouseEventArgs e)
	{
		Control control = new Control();
		control = (Design)sender;
		if (control.Name == viewportAuto.Name)
		{
			Point3D intPoint = new Point3D();
			viewportAuto.ScreenToPlane(e.Location, clsInit.appPanelCut.planeActive, out intPoint);
			if (intPoint != null)
			{
				frmMachSim.lbl_x.Text = "X: " + intPoint.X.ToString("f3");
				frmMachSim.lbl_y.Text = "Y: " + intPoint.Y.ToString("f3");
				frmMachSim.lbl_z.Text = "Z: " + intPoint.Z.ToString("f3");
			}
		}
	}

	private void method_1(object sender, MouseEventArgs e)
	{
	}

	public void DrawEntities(bool ZoomFit)
	{
		viewportAuto.Entities.Clear();
		viewportAutoPanel.Entities.Clear();
		viewportAutoDone.Entities.Clear();
		viewportAutoWaiting.Entities.Clear();
		CustomData customData = null;
		SimMovePartIndex.Clear();
		List<Entity> PartEntities = new List<Entity>();
		DrawNodesParts(activeJob.Panels[JobIndex].Nodes, activeJob.Panels[JobIndex].Depth, 0, ref PartEntities);
		if (PartEntities.Count > 0)
		{
			List<Point3D> Vertices = new List<Point3D>();
			Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].Nodes[0].Rectangle, ref Vertices);
			LinearPath outer = new LinearPath(Vertices);
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
			Mesh mesh = region.ExtrudeAsMesh(19.0, 0.1, Mesh.natureType.RichSmooth);
			mesh.Color = Color.FromArgb(150, Color.Gold);
			mesh.ColorMethod = colorMethodType.byEntity;
			mesh.Selectable = false;
			mesh.Translate(0.0, 0.0);
			for (int i = 0; i <= PartEntities.Count - 1; i++)
			{
				PartEntities[i].Translate(0.0, 0.0);
				viewportAutoPanel.Entities.Add(PartEntities[i]);
			}
		}
		for (int j = 0; j <= ccVars.SimMachine.MachineParts.Count - 1; j++)
		{
			for (int k = 0; k <= ccVars.SimMachine.MachineParts[j].Entities.Count - 1; k++)
			{
				buMachinePart buMachinePart2 = new buMachinePart(ccVars.SimMachine.MachineParts[j].PartName);
				buMachinePart2.ARotation = ccVars.SimMachine.MachineParts[j].MoveAxisPermision.A;
				buMachinePart2.BRotation = ccVars.SimMachine.MachineParts[j].MoveAxisPermision.B;
				buMachinePart2.CRotation = ccVars.SimMachine.MachineParts[j].MoveAxisPermision.C;
				buMachinePart2.XMove = ccVars.SimMachine.MachineParts[j].MoveAxisPermision.X;
				buMachinePart2.YMove = ccVars.SimMachine.MachineParts[j].MoveAxisPermision.Y;
				buMachinePart2.ZMove = ccVars.SimMachine.MachineParts[j].MoveAxisPermision.Z;
				buMachinePart2.xRot = ccVars.SimMachine.MachineParts[j].RotationCenter.X;
				buMachinePart2.yRot = ccVars.SimMachine.MachineParts[j].RotationCenter.Y;
				buMachinePart2.zRot = ccVars.SimMachine.MachineParts[j].RotationCenter.Z;
				buMachinePart2.Color = ccVars.SimMachine.MachineParts[j].Color;
				buMachinePart2.ColorMethod = colorMethodType.byEntity;
				double num = 0.0;
				double dx = ccVars.SimMachine.MachineParts[j].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[j].PositionAuxOffset.X;
				double dy = ccVars.SimMachine.MachineParts[j].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[j].PositionAuxOffset.Y;
				double dz = ccVars.SimMachine.MachineParts[j].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[j].PositionAuxOffset.Z + num;
				buMachinePart2.Translate(dx, dy, dz);
				buMachinePart2.Tag = ccVars.SimMachine.MachineParts[j].Tag;
				buMachinePart2.No = ccVars.SimMachine.MachineParts[j].No;
				customData = new CustomData();
				customData.typeDefination = entityTypeDefination.MachineBody;
				customData.OriginalEntityIndex = viewportAuto.Entities.Count;
				buMachinePart2.EntityData = customData;
				viewportAuto.Entities.Add(buMachinePart2);
				SimMovePartIndex.Add(viewportAuto.Entities.Count - 1);
			}
		}
		for (int l = 0; l < 8; l++)
		{
			for (int m = 0; m <= ccVars.SimMachine.Clampers.Count - 1; m++)
			{
				for (int n = 0; n <= ccVars.SimMachine.Clampers[m].Entities.Count - 1; n++)
				{
					buMachinePart buMachinePart3 = new buMachinePart(ccVars.SimMachine.Clampers[m].PartName + l);
					buMachinePart3.ARotation = ccVars.SimMachine.Clampers[m].MoveAxisPermision.A;
					buMachinePart3.BRotation = ccVars.SimMachine.Clampers[m].MoveAxisPermision.B;
					buMachinePart3.CRotation = ccVars.SimMachine.Clampers[m].MoveAxisPermision.C;
					buMachinePart3.XMove = ccVars.SimMachine.Clampers[m].MoveAxisPermision.X;
					buMachinePart3.YMove = ccVars.SimMachine.Clampers[m].MoveAxisPermision.Y;
					buMachinePart3.ZMove = ccVars.SimMachine.Clampers[m].MoveAxisPermision.Z;
					buMachinePart3.xRot = ccVars.SimMachine.Clampers[m].RotationCenter.X;
					buMachinePart3.yRot = ccVars.SimMachine.Clampers[m].RotationCenter.Y;
					buMachinePart3.zRot = ccVars.SimMachine.Clampers[m].RotationCenter.Z;
					buMachinePart3.Color = ccVars.SimMachine.Clampers[m].Color;
					buMachinePart3.ColorMethod = colorMethodType.byEntity;
					double num2 = 0.0;
					double dx2 = ccVars.SimMachine.Clampers[m].PositionBaseOffset.X + ccVars.SimMachine.Clampers[m].PositionAuxOffset.X;
					double num3 = ccVars.SimMachine.Clampers[m].PositionBaseOffset.Y + ccVars.SimMachine.Clampers[m].PositionAuxOffset.Y;
					double dz2 = ccVars.SimMachine.Clampers[m].PositionBaseOffset.Z + ccVars.SimMachine.Clampers[m].PositionAuxOffset.Z + num2;
					buMachinePart3.Translate(dx2, num3 - (double)l * 500.0, dz2);
					buMachinePart3.Tag = ccVars.SimMachine.Clampers[m].Tag;
					buMachinePart3.No = ccVars.SimMachine.Clampers[m].No;
					customData = new CustomData();
					customData.typeDefination = entityTypeDefination.MachineParts;
					customData.OriginalEntityIndex = viewportAuto.Entities.Count;
					buMachinePart3.EntityData = customData;
					viewportAuto.Entities.Add(buMachinePart3);
					SimMovePartIndex.Add(viewportAuto.Entities.Count - 1);
				}
			}
		}
		if (activeJob != null)
		{
		}
	}

	public void RemoveMaterial()
	{
		for (int num = viewportAuto.Entities.Count - 1; num >= 0; num--)
		{
			if (viewportAuto.Entities[num] is buMaterialMoveable)
			{
				viewportAuto.Entities[num].Selected = true;
				if ((SimMovePartIndex.Count > 0) & (num <= SimMovePartIndex.Count - 1))
				{
					SimMovePartIndex.RemoveAt(num);
				}
			}
		}
		viewportAuto.Entities.DeleteSelected();
		viewportAuto.Invalidate();
	}

	public void AddMaterial(double Width, double Height, double Depth, double XPos)
	{
		if (!(Width > 0.0 && Height > 0.0 && Depth > 0.0))
		{
			return;
		}
		buMaterialMoveable buMaterialMoveable2 = new buMaterialMoveable("MaterialWood");
		buMaterialMoveable2.XMove = true;
		Mesh mesh = Mesh.CreateBox(Width, Height, Depth, Mesh.natureType.RichSmooth);
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = Color.Gold;
		mesh.Translate(XPos, 0.0 - Height);
		Block block = new Block("MaterialWood");
		block.Entities.Add(mesh);
		for (int num = viewportAuto.Blocks.Count - 1; num >= 0; num--)
		{
			if (viewportAuto.Blocks[num].Name == "MaterialWood")
			{
				viewportAuto.Blocks.RemoveAt(num);
			}
		}
		viewportAuto.Blocks.Add(block);
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Material;
		customData.OriginalEntityIndex = viewportAuto.Entities.Count;
		buMaterialMoveable2.EntityData = customData;
		viewportAuto.Entities.Add(buMaterialMoveable2);
		SimMovePartIndex.Add(viewportAuto.Entities.Count - 1);
		viewportAuto.Invalidate();
	}

	public void AddMaterial(Rectangle2D Panel, List<Rectangle2D> CutLines, double Depth, double XPos)
	{
		if (!(((Panel.Width > 0.0) & (Panel.Height > 0.0)) && Depth > 0.0))
		{
			return;
		}
		buMaterialMoveable buMaterialMoveable2 = new buMaterialMoveable("MaterialWood");
		buMaterialMoveable2.XMove = true;
		Mesh mesh = Mesh.CreateBox(Panel.Width, Panel.Height, Depth, Mesh.natureType.RichSmooth);
		mesh.ColorMethod = colorMethodType.byEntity;
		mesh.Color = Color.FromArgb(150, Color.Gold);
		mesh.Translate(XPos, 0.0 - Panel.Height);
		Block block = new Block("MaterialWood");
		block.Entities.Add(mesh);
		for (int num = viewportAuto.Blocks.Count - 1; num >= 0; num--)
		{
			if (viewportAuto.Blocks[num].Name == "MaterialWood")
			{
				viewportAuto.Blocks.RemoveAt(num);
			}
		}
		viewportAuto.Blocks.Add(block);
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Material;
		customData.OriginalEntityIndex = viewportAuto.Entities.Count;
		buMaterialMoveable2.EntityData = customData;
		viewportAuto.Entities.Add(buMaterialMoveable2);
		SimMovePartIndex.Add(viewportAuto.Entities.Count - 1);
		for (int i = 0; i <= CutLines.Count - 1; i++)
		{
			buMaterialMoveable2 = new buMaterialMoveable("MaterialWood" + i);
			buMaterialMoveable2.XMove = true;
			Mesh mesh2 = Mesh.CreateBox(CutLines[i].Width, CutLines[i].Height, Depth, Mesh.natureType.RichSmooth);
			mesh2.Translate(CutLines[i].StartPoint.X, 0.0);
			mesh2.ColorMethod = colorMethodType.byEntity;
			mesh2.Color = Color.FromArgb(255, Color.Red);
			mesh2.Translate(XPos, 0.0 - Panel.Height);
			block = new Block("MaterialWood" + i);
			block.Entities.Add(mesh2);
			for (int num2 = viewportAuto.Blocks.Count - 1; num2 >= 0; num2--)
			{
				if (viewportAuto.Blocks[num2].Name == "MaterialWood" + i)
				{
					viewportAuto.Blocks.RemoveAt(num2);
				}
			}
			viewportAuto.Blocks.Add(block);
			customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Material;
			customData.OriginalEntityIndex = viewportAuto.Entities.Count;
			buMaterialMoveable2.EntityData = customData;
			viewportAuto.Entities.Add(buMaterialMoveable2);
			SimMovePartIndex.Add(viewportAuto.Entities.Count - 1);
		}
		viewportAuto.Invalidate();
	}

	public void AddFinishedPart(PanelDonePart Part)
	{
		try
		{
			if (activeJob.DoneParts.Count != 0)
			{
				bool flag = false;
				for (int i = 0; i <= activeJob.DoneParts.Count - 1; i++)
				{
					if (activeJob.DoneParts[i].PartID == Part.PartID)
					{
						activeJob.DoneParts[i].Count++;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Part.Count = 1;
					activeJob.DoneParts.Add(Part);
				}
			}
			else
			{
				Part.Count = 1;
				activeJob.DoneParts.Add(Part);
			}
			double num = 0.0;
			viewportAutoDone.Entities.Clear();
			for (int j = 0; j <= activeJob.DoneParts.Count - 1; j++)
			{
				Color color = Color.LightSteelBlue;
				if ((activeJob.DoneParts[j].PartID >= 0) & (activeJob.DoneParts[j].PartID <= buImage5.ColorList.Count - 1))
				{
					int index = (int)buNumeric5.RoundToLower((double)activeJob.DoneParts[j].PartID / 2.0);
					color = buImage5.ColorList[index];
				}
				Mesh partEntity = null;
				Rectangle2D foundRect = null;
				clsInit.cPanelCut.GetPartFromPartListWithID(activeJob.Parts, activeJob.Panels[JobIndex].Depth, activeJob.DoneParts[j].PartID, color, RotateToLongWidth: false, ref partEntity, ref foundRect);
				partEntity.Translate(num, 0.0);
				viewportAutoDone.Entities.Add(partEntity);
				Point3D Center = new Point3D();
				Rectangle2D.Rectangle2DCenter(foundRect, ref Center);
				Text text = new Text(Plane.XY, new Point3D(Center.X + num, Center.Y, activeJob.Panels[JobIndex].Depth + 2.0), activeJob.DoneParts[j].Count.ToString(), 40.0, Text.alignmentType.MiddleCenter);
				text.Color = Color.Black;
				text.ColorMethod = colorMethodType.byEntity;
				viewportAutoDone.Entities.Add(text);
				num = ((foundRect.Width > foundRect.Height) ? (num + foundRect.Width + 30.0) : (num + foundRect.Height + 30.0));
			}
			viewportAutoDone.SetView(viewType.Top);
			viewportAutoDone.ZoomFit(10);
			viewportAutoDone.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	public void AddAssemblyPart(PanelWaitAssembly Assembly)
	{
		activeJob.WaitingAssembly.Add(Assembly);
		double num = 0.0;
		viewportAutoWaiting.Entities.Clear();
		for (int i = 0; i <= activeJob.WaitingAssembly.Count - 1; i++)
		{
			Color darkOrange = Color.DarkOrange;
			Mesh meshPanel = null;
			Rectangle2D rectangle2D = new Rectangle2D(activeJob.WaitingAssembly[i].Panel);
			clsInit.cPanelCut.RectangleToMesh(activeJob.WaitingAssembly[i].Panel, activeJob.Panels[JobIndex].Depth, darkOrange, 0, -1, -1, null, ref meshPanel);
			meshPanel.Translate(num, 0.0);
			viewportAutoDone.Entities.Add(meshPanel);
			Point3D Center = new Point3D();
			Rectangle2D.Rectangle2DCenter(rectangle2D, ref Center);
			Text text = new Text(Plane.XY, new Point3D(Center.X + num, Center.Y, activeJob.Panels[JobIndex].Depth + 2.0), activeJob.WaitingAssembly[i].Panel.Width.ToString(), 40.0, Text.alignmentType.MiddleCenter);
			text.Color = Color.Black;
			text.ColorMethod = colorMethodType.byEntity;
			viewportAutoDone.Entities.Add(text);
			num = ((rectangle2D.Width > rectangle2D.Height) ? (num + rectangle2D.Width + 30.0) : (num + rectangle2D.Height + 30.0));
		}
		viewportAutoWaiting.SetView(viewType.Top);
		viewportAutoWaiting.ZoomFit(10);
		viewportAutoWaiting.Invalidate();
	}

	public void SimValueChaned(double Value, object Data)
	{
		if (Data != null && Data.ToString() == "Track")
		{
		}
	}

	public void tick_Simulation(object sender, EventArgs e)
	{
		if (!(!varPanelCutRunSettings.StepRun | (varPanelCutRunSettings.StepRun & varTemps.simRelease)))
		{
			return;
		}
		varTemps.simRelease = false;
		if (activeJob == null)
		{
			varTemps.acliveLine = -1;
			timSim.Enabled = false;
			SimFinished();
		}
		else if (!((indexSim >= 0) & (indexSim <= activeJob.SimulationMoves.Count - 1)))
		{
			indexSim = -1;
			timSim.Enabled = false;
			varTemps.acliveLine = -1;
			SimFinished();
		}
		else
		{
			PanelCutMove panelCutMove = activeJob.SimulationMoves[indexSim];
			varTemps.acliveLine = activeJob.SimulationMoves[indexSim].Index;
			if (activeJob.SimulationMoves[indexSim].Command == PanelCutMoveCommand.PartFinished)
			{
				PanelDonePart panelDonePart = new PanelDonePart();
				panelDonePart.PartID = panelCutMove.PartID;
				AddFinishedPart(panelDonePart);
			}
			if (activeJob.SimulationMoves[indexSim].Command == PanelCutMoveCommand.RemoveMaterial)
			{
				RemoveMaterial();
			}
			if (activeJob.SimulationMoves[indexSim].Command == PanelCutMoveCommand.AddMaterial)
			{
				RemoveMaterial();
				AddMaterial(activeJob.SimulationMoves[indexSim].Panel, activeJob.SimulationMoves[indexSim].SawCutRectangles, 18.0, activeJob.SimulationMoves[indexSim].XPosition);
			}
			if (activeJob.SimulationMoves[indexSim].Command != PanelCutMoveCommand.CutMaterial)
			{
			}
			if ((indexSim >= 0) & (indexSim <= activeJob.SimulationMoves.Count - 1))
			{
				PanelCutMove pntMove = new PanelCutMove(activeJob.SimulationMoves[indexSim]);
				MoveSimPart(pntMove);
				if (frmMachSim != null)
				{
					frmMachSim.lbl_x.Text = "X: " + activeJob.SimulationMoves[indexSim].Position.X.ToString("f2");
					frmMachSim.lbl_y.Text = "Y: " + activeJob.SimulationMoves[indexSim].Position.Y.ToString("f2");
					frmMachSim.lbl_z.Text = "Z: " + activeJob.SimulationMoves[indexSim].Position.Z.ToString("f2");
				}
			}
			indexSim += varPanelCutRunSettings.SimStep;
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

	public void SimFinished()
	{
		for (int i = 0; i <= viewportAutoPanel.Entities.Count - 1; i++)
		{
			viewportAutoPanel.Entities[i].Selected = false;
		}
		viewportAutoPanel.Invalidate();
	}

	public void MoveSimPart(PanelCutMove pntMove)
	{
		for (int i = 0; i <= viewportAutoPanel.Entities.Count - 1; i++)
		{
			viewportAutoPanel.Entities[i].Selected = false;
			if (viewportAutoPanel.Entities[i].EntityData != null && viewportAutoPanel.Entities[i].EntityData is PanelEntityData)
			{
				PanelEntityData panelEntityData = viewportAutoPanel.Entities[i].EntityData as PanelEntityData;
				if (panelEntityData.NodeID == pntMove.NodeID)
				{
					viewportAutoPanel.Entities[i].Selected = true;
				}
			}
		}
		if (viewportAutoPanel.Entities.Count > 0)
		{
			viewportAutoPanel.Invalidate();
		}
		for (int j = 0; j <= SimMovePartIndex.Count - 1; j++)
		{
			int num = SimMovePartIndex[j];
			if (!((num >= 0) & (num <= viewportAuto.Entities.Count - 1)))
			{
				continue;
			}
			CustomData customData = viewportAuto.Entities[SimMovePartIndex[j]].EntityData as CustomData;
			KinematicBase5 kinematicBase = new KinematicBase5();
			kinematicBase.RotateCenterOffsetOfA.Z = 171.0;
			kinematicBase.Type = KinemeticType.CartezianXYZ_WristA_4Axis;
			new Pnt6D();
			new Point3D();
			_ = SimMovePartIndex[j];
			if (!((SimMovePartIndex[j] >= 0) & (SimMovePartIndex[j] <= viewportAuto.Entities.Count - 1)))
			{
				continue;
			}
			if (viewportAuto.Entities[SimMovePartIndex[j]].GetType() == typeof(buTool))
			{
				buTool buTool2 = viewportAuto.Entities[SimMovePartIndex[j]] as buTool;
				_ = ((BlockReference)viewportAuto.Entities[SimMovePartIndex[j]]).BlockName;
				if (buTool2.Tag == null)
				{
				}
			}
			if (viewportAuto.Entities[SimMovePartIndex[j]].GetType() == typeof(buMaterialMoveable))
			{
				((buMaterialMoveable)viewportAuto.Entities[SimMovePartIndex[j]]).xPos = pntMove.Position.X;
			}
			if (viewportAuto.Entities[SimMovePartIndex[j]].GetType() == typeof(buMachinePart))
			{
				_ = viewportAuto.Entities[SimMovePartIndex[j]] is buMachinePart;
				if ((customData.typeDefination == entityTypeDefination.MachineBody) | (customData.typeDefination == entityTypeDefination.MachineParts))
				{
					_ = ((BlockReference)viewportAuto.Entities[SimMovePartIndex[j]]).BlockName;
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[j]]).xPos = pntMove.Position.X;
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[j]]).yPos = pntMove.Position.Y;
					((buMachinePart)viewportAuto.Entities[SimMovePartIndex[j]]).zPos = pntMove.Position.Z;
				}
			}
		}
		viewportAuto.Entities.Regen();
		if (!viewportAuto.IsAnimationRunning)
		{
		}
	}

	public void JobToSimulationMoves()
	{
		if (activeJob == null)
		{
			MessageBox.Show("No Acitve Job");
		}
		activeJob.SimulationMoves.Clear();
		activeJob.SimulationCodes.Clear();
		activeJob.WaitingAssembly.Clear();
		activeJob.DoneParts.Clear();
		viewportAutoDone.Entities.Clear();
		viewportAutoWaiting.Entities.Clear();
		viewportAutoDone.Invalidate();
		viewportAutoWaiting.Invalidate();
		MoveIndex = 0;
		if (activeJob.Panels.Count <= 0)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i <= activeJob.Panels[JobIndex].Nodes.Count - 1; i++)
		{
			NestingPanelNode nestingPanelNode = activeJob.Panels[JobIndex].Nodes[i];
			GetMove(nestingPanelNode, num);
			num++;
			for (int j = 0; j <= nestingPanelNode.Node.Count - 1; j++)
			{
				NestingPanelNode nestingPanelNode2 = nestingPanelNode.Node[j];
				GetMove(nestingPanelNode2, num);
				num++;
				for (int k = 0; k <= nestingPanelNode2.Node.Count - 1; k++)
				{
					NestingPanelNode nestingPanelNode3 = nestingPanelNode2.Node[k];
					GetMove(nestingPanelNode3, num);
					num++;
					for (int l = 0; l <= nestingPanelNode3.Node.Count - 1; l++)
					{
						NestingPanelNode nestingPanelNode4 = nestingPanelNode3.Node[l];
						GetMove(nestingPanelNode4, num);
						num++;
						for (int m = 0; m <= nestingPanelNode4.Node.Count - 1; m++)
						{
							NestingPanelNode nestingPanelNode5 = nestingPanelNode4.Node[m];
							GetMove(nestingPanelNode5, num);
							num++;
							for (int n = 0; n <= nestingPanelNode5.Node.Count - 1; n++)
							{
								NestingPanelNode node = nestingPanelNode5.Node[n];
								GetMove(node, num);
								num++;
							}
						}
					}
				}
			}
		}
	}

	public void GetMove(NestingPanelNode Node, int index)
	{
		double num = 0.0;
		double num2 = 0.0;
		double sawThickness = varPanelCutSettings.SawThickness;
		int countStep = 3;
		int num3 = 3;
		Rectangle2D rectangle2D = null;
		PanelCutMove panelCutMove = new PanelCutMove();
		_ = activeJob.Parts.Count;
		if (Node.NodeType == nestPanelNodeType.Assembly)
		{
			if (index != 0)
			{
				if (Node.Direction == DirectionXandY.YDirection)
				{
					if (Node.BaseRectangle == null)
					{
						panelCutMove = new PanelCutMove();
						panelCutMove.Position.X = 0.0;
						panelCutMove.Position.Y = 0.0;
						panelCutMove.XPosition = 0.0 - Node.DimensionY;
						panelCutMove.Command = PanelCutMoveCommand.AddMaterial;
						panelCutMove.Panel = new Rectangle2D(Node.DimensionY, Node.DimensionX);
						panelCutMove.Index = MoveIndex;
						panelCutMove.NodeID = Node.NodeID;
						panelCutMove.NodeType = Node.NodeType;
						activeJob.SimulationMoves.Add(panelCutMove);
						activeJob.SimulationCodes.Add("Assembly (" + Node.DimensionX.ToString("f2") + " , " + Node.DimensionY.ToString("f2") + ")");
						CreateSimMoveXStep(MoveIndex, Node, countStep, 0.0, 0.0, Node.DimensionY);
						MoveIndex++;
					}
					else
					{
						panelCutMove = new PanelCutMove();
						panelCutMove.Position.X = Node.BaseRectangle.Width;
						panelCutMove.Position.Y = 0.0;
						panelCutMove.XPosition = 0.0 - Node.BaseRectangle.Width;
						panelCutMove.Command = PanelCutMoveCommand.AddMaterial;
						panelCutMove.Panel = new Rectangle2D(Node.BaseRectangle.Width, Node.BaseRectangle.Height);
						rectangle2D = new Rectangle2D(new Point3D(Node.CutFeedDistance - sawThickness / 2.0, 0.0), sawThickness, Node.CutSawDistance);
						panelCutMove.SawCutRectangles.Add(rectangle2D);
						panelCutMove.Index = MoveIndex;
						panelCutMove.NodeID = Node.NodeID;
						panelCutMove.NodeType = Node.NodeType;
						activeJob.SimulationMoves.Add(panelCutMove);
						activeJob.SimulationCodes.Add("Assembly (" + Node.DimensionX.ToString("f2") + " , " + Node.DimensionY.ToString("f2") + ")");
						num = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X;
						CreateSimMoveXStep(MoveIndex, Node, countStep, 0.0, num, 0.0 - Node.DimensionX);
						num = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X;
						num3 = clsInit.cPanelCut.SimCountFromLength(Node.DimensionY, varPanelCutSettings.CutSimDevideLen);
						CreateSimMoveYCut(MoveIndex, Node, num3, num, 0.0, Node.DimensionY);
						panelCutMove = new PanelCutMove();
						panelCutMove.Position.X = num;
						panelCutMove.Position.Y = 0.0;
						panelCutMove.Index = MoveIndex;
						panelCutMove.NodeID = Node.NodeID;
						panelCutMove.NodeType = Node.NodeType;
						activeJob.SimulationMoves.Add(panelCutMove);
						num = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X;
						CreateSimMoveXStep(MoveIndex, Node, countStep, 0.0, num, 0.0 - (Node.BaseRectangle.Width - Node.DimensionX));
						MoveIndex++;
					}
				}
			}
			else if (Node.Direction == DirectionXandY.XDirection)
			{
				panelCutMove = new PanelCutMove();
				panelCutMove.Position.X = 0.0;
				panelCutMove.Position.Y = 0.0;
				panelCutMove.XPosition = 0.0 - Node.DimensionX;
				panelCutMove.Command = PanelCutMoveCommand.AddMaterial;
				panelCutMove.Panel = new Rectangle2D(Node.DimensionX, Node.DimensionY);
				panelCutMove.Index = MoveIndex;
				panelCutMove.NodeID = Node.NodeID;
				panelCutMove.NodeType = Node.NodeType;
				activeJob.SimulationMoves.Add(panelCutMove);
				activeJob.SimulationCodes.Add("Assembly (" + Node.DimensionX.ToString("f2") + " , " + Node.DimensionY.ToString("f2") + ")");
				CreateSimMoveXStep(MoveIndex, Node, 10, 0.0, 0.0, Node.DimensionX);
				MoveIndex++;
			}
		}
		if (Node.NodeType == nestPanelNodeType.Module)
		{
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = Node.BaseRectangle.Height;
			panelCutMove.Position.Y = 0.0;
			panelCutMove.XPosition = 0.0 - Node.BaseRectangle.Height;
			panelCutMove.Command = PanelCutMoveCommand.AddMaterial;
			panelCutMove.Panel = new Rectangle2D(Node.BaseRectangle.Height, Node.BaseRectangle.Width);
			panelCutMove.NodeID = Node.NodeID;
			panelCutMove.NodeType = Node.NodeType;
			rectangle2D = new Rectangle2D(new Point3D(Node.CutFeedDistance - sawThickness / 2.0, 0.0), sawThickness, Node.CutSawDistance);
			panelCutMove.SawCutRectangles.Add(rectangle2D);
			activeJob.SimulationMoves.Add(panelCutMove);
			CreateSimMoveXStep(MoveIndex, Node, countStep, 0.0, panelCutMove.Position.X, 0.0 - Node.DimensionY);
			num = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X;
			num3 = clsInit.cPanelCut.SimCountFromLength(Node.DimensionX, varPanelCutSettings.CutSimDevideLen);
			CreateSimMoveYCut(MoveIndex, Node, num3, num, 0.0, Node.DimensionX);
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = num;
			panelCutMove.Position.Y = 0.0;
			panelCutMove.Index = MoveIndex;
			activeJob.SimulationMoves.Add(panelCutMove);
			activeJob.SimulationCodes.Add("  Module (" + Node.DimensionX.ToString("f2") + " , " + Node.DimensionY.ToString("f2") + ")");
			num = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X;
			CreateSimMoveXStep(MoveIndex, Node, countStep, 0.0, num, 0.0 - num);
			MoveIndex++;
			num = 0.0;
			int num4 = Node.Node.Count - 1;
			for (int i = 0; i < num4; i++)
			{
				num2 = Node.Node[i].DimensionX + sawThickness;
				num = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X;
				if (i == 0)
				{
					panelCutMove = new PanelCutMove();
					panelCutMove.Position.X = Node.DimensionX;
					panelCutMove.Position.Y = 0.0;
					panelCutMove.XPosition = 0.0 - Node.DimensionX;
					panelCutMove.Command = PanelCutMoveCommand.AddMaterial;
					panelCutMove.Panel = new Rectangle2D(Node.DimensionX, Node.DimensionY);
					panelCutMove.Index = MoveIndex;
					panelCutMove.NodeID = Node.Node[i].NodeID;
					panelCutMove.NodeType = Node.Node[i].NodeType;
					activeJob.SimulationMoves.Add(panelCutMove);
					num = Node.DimensionX;
					num2 = Node.Node[i].DimensionX + sawThickness / 2.0;
				}
				rectangle2D = new Rectangle2D(new Point3D(Node.Node[i].CutFeedDistance - Node.CutOffset - sawThickness / 2.0, 0.0), sawThickness, Node.Node[i].CutSawDistance);
				panelCutMove.SawCutRectangles.Add(rectangle2D);
				CreateSimMoveXStep(MoveIndex, Node.Node[i], countStep, 0.0, num, 0.0 - num2);
				num3 = clsInit.cPanelCut.SimCountFromLength(Node.DimensionY, varPanelCutSettings.CutSimDevideLen);
				CreateSimMoveYCut(MoveIndex, Node.Node[i], num3, activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X, 0.0, Node.DimensionY);
				activeJob.SimulationCodes.Add("    Cut (" + (Node.Node[i].CutFeedDistance - Node.CutOffset).ToString("f2") + ")");
				if (Node.Node[i].Node.Count == 0)
				{
					panelCutMove = new PanelCutMove();
					panelCutMove.Position = buVector5.ToPoint3D(activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position);
					panelCutMove.Command = PanelCutMoveCommand.PartFinished;
					panelCutMove.Panel = new Rectangle2D(Node.Node[i].Rectangle);
					panelCutMove.PartID = Node.Node[i].PartID;
					activeJob.SimulationMoves.Add(panelCutMove);
				}
				MoveIndex++;
			}
			num = 0.0;
			int num5 = 1;
			for (int j = 0; j <= Node.Node.Count - 1; j++)
			{
				for (int k = 0; k <= Node.Node[j].Node.Count - 1; k++)
				{
					NestingPanelNode nestingPanelNode = Node.Node[j].Node[k];
					if (k != 0)
					{
						num2 = nestingPanelNode.DimensionY + sawThickness;
					}
					else
					{
						num2 = nestingPanelNode.CutLine.StartPoint.Y - num;
						panelCutMove = new PanelCutMove();
						panelCutMove.Position.X = Node.Node[j].DimensionY;
						panelCutMove.Position.Y = 0.0;
						panelCutMove.XPosition = 0.0 - Node.Node[j].DimensionY;
						panelCutMove.Command = PanelCutMoveCommand.AddMaterial;
						panelCutMove.Panel = new Rectangle2D(Node.Node[j].DimensionY, Node.Node[j].DimensionX);
						for (int l = 0; l <= Node.Node[j].Node.Count - 1; l++)
						{
							rectangle2D = new Rectangle2D(new Point3D(Node.Node[j].Node[l].CutFeedDistance - sawThickness / 2.0, 0.0), sawThickness, Node.Node[j].Node[l].CutSawDistance);
							panelCutMove.SawCutRectangles.Add(rectangle2D);
						}
						panelCutMove.Index = MoveIndex;
						panelCutMove.NodeID = nestingPanelNode.NodeID;
						panelCutMove.NodeType = nestingPanelNode.NodeType;
						activeJob.SimulationMoves.Add(panelCutMove);
						num = Node.Node[j].DimensionY;
						num2 = nestingPanelNode.DimensionY + sawThickness / 2.0;
					}
					CreateSimMoveXStep(MoveIndex, nestingPanelNode, countStep, 0.0, num, 0.0 - num2);
					num -= num2;
					if (k < Node.Node[j].Node.Count - 1)
					{
						num3 = clsInit.cPanelCut.SimCountFromLength(Node.Node[j].DimensionX, varPanelCutSettings.CutSimDevideLen);
						CreateSimMoveYCut(MoveIndex, nestingPanelNode, num3, activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.X, 0.0, Node.Node[j].DimensionX);
					}
					activeJob.SimulationCodes.Add("      Part = " + num5 + " (" + activeJob.Parts[nestingPanelNode.PartID].Width.ToString("f2") + " X " + activeJob.Parts[nestingPanelNode.PartID].Height.ToString("f2") + ")");
					panelCutMove = new PanelCutMove();
					panelCutMove.Position = buVector5.ToPoint3D(activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position);
					panelCutMove.Command = PanelCutMoveCommand.PartFinished;
					panelCutMove.Panel = new Rectangle2D(nestingPanelNode.Rectangle);
					panelCutMove.PartID = nestingPanelNode.PartID;
					activeJob.SimulationMoves.Add(panelCutMove);
					MoveIndex++;
					num5++;
				}
			}
		}
		if (Node.NodeType != nestPanelNodeType.CutLine)
		{
		}
	}

	public void CreateSimMoveXStep(int Index, NestingPanelNode node, int countStep, double YPos, double LastX, double XDistance)
	{
		double num = XDistance / (double)countStep;
		for (int i = 1; i <= countStep; i++)
		{
			PanelCutMove panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = LastX + (double)i * num;
			panelCutMove.Position.Y = YPos;
			panelCutMove.Command = PanelCutMoveCommand.AxisMove;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
		}
	}

	public void CreateSimMoveYCut(int Index, NestingPanelNode node, int countStep, double XPos, double LastY, double YDistance)
	{
		double num = (0.0 - YDistance) / (double)countStep;
		PanelCutMove panelCutMove = new PanelCutMove();
		if (varPanelCutSettings.CutSawZMoveCount != 3)
		{
			if (varPanelCutSettings.CutSawZMoveCount != 2)
			{
				panelCutMove = new PanelCutMove();
				panelCutMove.Position.X = XPos;
				panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
				panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth + 2.0;
				panelCutMove.Index = Index;
				panelCutMove.NodeID = node.NodeID;
				panelCutMove.NodeType = node.NodeType;
				activeJob.SimulationMoves.Add(panelCutMove);
			}
			else
			{
				panelCutMove = new PanelCutMove();
				panelCutMove.Position.X = XPos;
				panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
				panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth * 0.5;
				panelCutMove.Index = Index;
				panelCutMove.NodeID = node.NodeID;
				panelCutMove.NodeType = node.NodeType;
				activeJob.SimulationMoves.Add(panelCutMove);
				panelCutMove = new PanelCutMove();
				panelCutMove.Position.X = XPos;
				panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
				panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth + 2.0;
				panelCutMove.Index = Index;
				panelCutMove.NodeID = node.NodeID;
				panelCutMove.NodeType = node.NodeType;
				activeJob.SimulationMoves.Add(panelCutMove);
			}
		}
		else
		{
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
			panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth * 0.33;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
			panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth * 0.66;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
			panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth + 2.0;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
		}
		for (int i = 1; i <= countStep; i++)
		{
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = (double)i * num;
			panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth + 2.0;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
		}
		if (varPanelCutSettings.CutSawZMoveCount != 3)
		{
			if (varPanelCutSettings.CutSawZMoveCount != 2)
			{
				panelCutMove = new PanelCutMove();
				panelCutMove.Position.X = XPos;
				panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
				panelCutMove.Position.Z = 0.0;
				panelCutMove.Index = Index;
				panelCutMove.NodeID = node.NodeID;
				panelCutMove.NodeType = node.NodeType;
				activeJob.SimulationMoves.Add(panelCutMove);
			}
			else
			{
				panelCutMove = new PanelCutMove();
				panelCutMove.Position.X = XPos;
				panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
				panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth * 0.5;
				panelCutMove.Index = Index;
				panelCutMove.NodeID = node.NodeID;
				panelCutMove.NodeType = node.NodeType;
				activeJob.SimulationMoves.Add(panelCutMove);
				panelCutMove = new PanelCutMove();
				panelCutMove.Position.X = XPos;
				panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
				panelCutMove.Position.Z = 0.0;
				panelCutMove.Index = Index;
				panelCutMove.NodeID = node.NodeID;
				panelCutMove.NodeType = node.NodeType;
				activeJob.SimulationMoves.Add(panelCutMove);
			}
		}
		else
		{
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
			panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth * 0.66;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
			panelCutMove.Position.Z = activeJob.Panels[JobIndex].Depth * 0.33;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = activeJob.SimulationMoves[activeJob.SimulationMoves.Count - 1].Position.Y;
			panelCutMove.Position.Z = 0.0;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
		}
		num = YDistance / (double)countStep;
		for (int j = 1; j <= countStep; j++)
		{
			panelCutMove = new PanelCutMove();
			panelCutMove.Position.X = XPos;
			panelCutMove.Position.Y = 0.0 - YDistance + (double)j * num;
			panelCutMove.Index = Index;
			panelCutMove.NodeID = node.NodeID;
			panelCutMove.NodeType = node.NodeType;
			activeJob.SimulationMoves.Add(panelCutMove);
		}
	}

	public void DrawSelectedRegion(List<Point3D> PL)
	{
		LinearPath outer = new LinearPath(PL);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
		Mesh mesh = region.ExtrudeAsMesh(20.0, 0.01, Mesh.natureType.RichSmooth);
		mesh.Color = Color.FromArgb(120, Color.Tan);
		mesh.ColorMethod = colorMethodType.byEntity;
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Temp;
		mesh.EntityData = customData;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void DrawNodesParts(List<NestingPanelNode> Nodes)
	{
		for (int i = 0; i <= Nodes.Count - 1; i++)
		{
			if (Nodes[i].NodeType == nestPanelNodeType.Module)
			{
				Rectangle2D rectangle2D = null;
				if (Nodes[i].PartID >= 0 && Nodes[i].PartID <= activeJob.Parts.Count - 1)
				{
					rectangle2D = new Rectangle2D(activeJob.Parts[Nodes[i].PartID].Width, activeJob.Parts[Nodes[i].PartID].Height);
				}
				if (((Nodes[i].XQuantity > 0) & (Nodes[i].YQuantity > 0)) && rectangle2D != null)
				{
					for (double num = 0.0; num <= (double)(Nodes[i].XQuantity - 1); num += 1.0)
					{
						for (double num2 = 0.0; num2 <= (double)(Nodes[i].YQuantity - 1); num2 += 1.0)
						{
							double num3 = num * (rectangle2D.Width + varPanelCutSettings.SawThickness);
							double num4 = num2 * (rectangle2D.Height + varPanelCutSettings.SawThickness);
							Rectangle2D rect = new Rectangle2D(new Point3D(Nodes[i].LowerLeft.X + num3, Nodes[i].LowerLeft.Y + num4), rectangle2D.Width, rectangle2D.Height);
							List<Point3D> Vertices = new List<Point3D>();
							Rectangle2D.Rectangle3DToVertices(rect, ref Vertices);
							LinearPath outer = new LinearPath(Vertices);
							ccVars.UndoDont = true;
							devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
							Mesh mesh = region.ExtrudeAsMesh(18.0, 0.1, Mesh.natureType.RichSmooth);
							mesh.Color = Color.LightSteelBlue;
							if ((Nodes[i].PartID >= 0) & (Nodes[i].PartID <= buImage5.ColorList.Count - 1))
							{
								int index = (int)buNumeric5.RoundToLower((double)Nodes[i].PartID / 2.0);
								mesh.Color = buImage5.ColorList[index];
							}
							mesh.ColorMethod = colorMethodType.byEntity;
							mesh.Selectable = false;
							if (mesh != null)
							{
								clsInit.appCommand.AddMesh(mesh);
							}
						}
					}
				}
			}
			if (Nodes[i].NodeType == nestPanelNodeType.CutLine && Nodes[i].CutLine != null)
			{
				devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(Nodes[i].CutLine.StartPoint, Nodes[i].CutLine.EndPoint);
				line.Color = Color.Black;
				line.ColorMethod = colorMethodType.byEntity;
				line.LineWeight = 3f;
				line.LineWeightMethod = colorMethodType.byEntity;
				line.Selectable = true;
				ccVars.UndoDont = true;
				clsInit.appCommand.AddLine(line);
			}
			if (Nodes[i].NodeType == nestPanelNodeType.OffCut)
			{
				Rectangle2D rectangle2D2 = new Rectangle2D(Nodes[i].Rectangle);
				List<Point3D> Vertices2 = new List<Point3D>();
				if ((rectangle2D2.Width > 0.0) & (rectangle2D2.Height > 0.0))
				{
					Rectangle2D.Rectangle3DToVertices(rectangle2D2, ref Vertices2);
					clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Vertices2);
					if (Vertices2.Count >= 3)
					{
						LinearPath outer2 = new LinearPath(Vertices2);
						ccVars.UndoDont = true;
						devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(outer2);
						Mesh mesh2 = region2.ExtrudeAsMesh(18.0, 0.1, Mesh.natureType.RichSmooth);
						mesh2.Color = Color.Gray;
						mesh2.ColorMethod = colorMethodType.byEntity;
						mesh2.Selectable = false;
						if (mesh2 != null)
						{
							clsInit.appCommand.AddMesh(mesh2);
						}
					}
				}
			}
			if (Nodes[i].Node.Count > 0)
			{
				DrawNodesParts(Nodes[i].Node);
			}
		}
	}

	public void DrawNodesParts(List<NestingPanelNode> Nodes, double PanelDepth, int Level, ref List<Entity> PartEntities)
	{
		Rectangle2D rectangle2D = null;
		for (int i = 0; i <= Nodes.Count - 1; i++)
		{
			if (Nodes[i].NodeType == nestPanelNodeType.Assembly)
			{
				rectangle2D = new Rectangle2D(Nodes[i].Rectangle);
				if ((rectangle2D.Width > 0.0) & (rectangle2D.Height > 0.0))
				{
					Mesh meshPanel = null;
					clsInit.cPanelCut.RectangleToMesh(rectangle2D, PanelDepth, Color.FromArgb(70, Color.WhiteSmoke), Level, -1, -1, Nodes[i], ref meshPanel);
					if (meshPanel != null)
					{
						PartEntities.Add(meshPanel);
					}
				}
			}
			if (Nodes[i].NodeType == nestPanelNodeType.Module)
			{
				rectangle2D = new Rectangle2D(Nodes[i].Rectangle);
				if ((rectangle2D.Width > 0.0) & (rectangle2D.Height > 0.0))
				{
					Mesh meshPanel2 = null;
					clsInit.cPanelCut.RectangleToMesh(rectangle2D, PanelDepth, Color.FromArgb(100, Color.Tan), Level, -1, -1, Nodes[i], ref meshPanel2);
					if (meshPanel2 != null)
					{
						PartEntities.Add(meshPanel2);
					}
				}
				if (Nodes[i].PartID >= 0 && Nodes[i].PartID <= activeJob.Parts.Count - 1)
				{
					new Rectangle2D(activeJob.Parts[Nodes[i].PartID].Width, activeJob.Parts[Nodes[i].PartID].Height);
				}
			}
			if (Nodes[i].NodeType == nestPanelNodeType.CutLine)
			{
				rectangle2D = new Rectangle2D(Nodes[i].Rectangle);
				if ((rectangle2D.Width > 0.0) & (rectangle2D.Height > 0.0))
				{
					Color color = Color.LightSteelBlue;
					if ((Nodes[i].PartID >= 0) & (Nodes[i].PartID <= buImage5.ColorList.Count - 1))
					{
						int index = (int)buNumeric5.RoundToLower((double)Nodes[i].PartID / 2.0);
						color = buImage5.ColorList[index];
					}
					Mesh meshPanel3 = null;
					clsInit.cPanelCut.RectangleToMesh(rectangle2D, PanelDepth, color, Level, -1, -1, Nodes[i], ref meshPanel3);
					if (meshPanel3 != null)
					{
						PartEntities.Add(meshPanel3);
					}
				}
				if (Nodes[i].CutLine != null)
				{
					devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(Nodes[i].CutLine.StartPoint, Nodes[i].CutLine.EndPoint);
					line.Color = Color.Black;
					line.ColorMethod = colorMethodType.byEntity;
					line.LineWeight = 3f;
					line.LineWeightMethod = colorMethodType.byEntity;
					line.Selectable = true;
					ccVars.UndoDont = true;
				}
			}
			if (Nodes[i].NodeType == nestPanelNodeType.OffCut)
			{
				rectangle2D = new Rectangle2D(Nodes[i].Rectangle);
				new List<Point3D>();
				if ((rectangle2D.Width > 0.0) & (rectangle2D.Height > 0.0))
				{
					Mesh meshPanel4 = null;
					clsInit.cPanelCut.RectangleToMesh(rectangle2D, PanelDepth, Color.FromArgb(255, Color.Gray), Level, -1, -1, Nodes[i], ref meshPanel4);
					if (meshPanel4 != null)
					{
						PartEntities.Add(meshPanel4);
					}
				}
			}
			if (Nodes[i].Node.Count > 0)
			{
				DrawNodesParts(Nodes[i].Node, PanelDepth, Level + 1, ref PartEntities);
			}
		}
	}

	public void DeleteNodeSelection()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData is CustomData)
			{
				CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
				if (customData.typeDefination == entityTypeDefination.Temp)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
	}

	public void GetCodeNodes(List<NestingPanelNode> Nodes, DirectionXandY PreDir, ref List<string> SL)
	{
		for (int i = 0; i <= Nodes.Count - 1; i++)
		{
			if (Nodes[i].Depth > 0)
			{
				if (Nodes[i].NodeType == nestPanelNodeType.Assembly)
				{
					string text = "000";
					string text2 = "0";
					if (PreDir == DirectionXandY.XDirection)
					{
						SL.Add("KES1," + Nodes[i].Depth + "," + Nodes[i].DimensionX + "," + text2 + "," + text);
					}
					if (PreDir == DirectionXandY.YDirection)
					{
						SL.Add("KES1," + Nodes[i].Depth + "," + Nodes[i].DimensionY + "," + text2 + "," + text);
					}
				}
				if (Nodes[i].NodeType == nestPanelNodeType.Module)
				{
					Rectangle2D rectangle2D = null;
					if (Nodes[i].PartID < 0)
					{
					}
					if (((Nodes[i].XQuantity > 0) & (Nodes[i].YQuantity > 0)) && rectangle2D != null)
					{
						for (double num = 0.0; num <= (double)(Nodes[i].XQuantity - 1); num += 1.0)
						{
							for (double num2 = 0.0; num2 <= (double)(Nodes[i].YQuantity - 1); num2 += 1.0)
							{
								double num3 = num * (rectangle2D.Width + varPanelCutSettings.SawThickness);
								double num4 = num2 * (rectangle2D.Height + varPanelCutSettings.SawThickness);
								Rectangle2D rect = new Rectangle2D(new Point3D(Nodes[i].LowerLeft.X + num3, Nodes[i].LowerLeft.Y + num4), rectangle2D.Width, rectangle2D.Height);
								List<Point3D> Vertices = new List<Point3D>();
								Rectangle2D.Rectangle3DToVertices(rect, ref Vertices);
								LinearPath outer = new LinearPath(Vertices);
								ccVars.UndoDont = true;
								devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
								Mesh mesh = region.ExtrudeAsMesh(18.0, 0.1, Mesh.natureType.RichSmooth);
								mesh.Color = Color.LightSteelBlue;
								if ((Nodes[i].PartID >= 0) & (Nodes[i].PartID <= buImage5.ColorList.Count - 1))
								{
									int index = (int)buNumeric5.RoundToLower((double)Nodes[i].PartID / 2.0);
									mesh.Color = buImage5.ColorList[index];
								}
								mesh.ColorMethod = colorMethodType.byEntity;
								mesh.Selectable = false;
								if (mesh != null)
								{
									clsInit.appCommand.AddMesh(mesh);
								}
							}
						}
					}
				}
				if (Nodes[i].NodeType == nestPanelNodeType.CutLine)
				{
					string text3 = "000";
					string text4 = "1";
					text3 = Nodes[i].ID.ToString("D3");
					if (Nodes[i].Direction == DirectionXandY.XDirection)
					{
						SL.Add("KES1," + Nodes[i].Depth + "," + Nodes[i].DimensionX + "," + text4 + "," + text3);
					}
					if (Nodes[i].Direction == DirectionXandY.YDirection)
					{
						SL.Add("KES1," + Nodes[i].Depth + "," + Nodes[i].DimensionY + "," + text4 + "," + text3);
					}
				}
				if (Nodes[i].NodeType == nestPanelNodeType.OffCut)
				{
					if ((varTemps.OffcutCount == 0) & (varPanelCutSettings.GeneralTrimWidth > 0.0))
					{
						string text5 = "0";
						string text6 = "000";
						if (Nodes[i].Node.Count > 0)
						{
							text5 = "0";
						}
						SL.Add("KES1," + Nodes[i].Depth + "," + Nodes[i].DimensionX + "," + text5 + "," + text6);
					}
					varTemps.OffcutCount++;
				}
			}
			if (Nodes[i].Node.Count > 0)
			{
				GetCodeNodes(Nodes[i].Node, Nodes[i].Direction, ref SL);
			}
		}
	}

	public void SavePanelCutFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\PanelCut\\PanelCut.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Panel Cut Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<varPanelCutSettings>");
			arrayList.AddRange(varPanelCutSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</varPanelCutSettings>");
			arrayList.Add("<varPanelCutRunSettings>");
			arrayList.AddRange(varPanelCutRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</varPanelCutRunSettings>");
			arrayList.Add("<NestingPartsAndSheets>");
			arrayList.AddRange(buNestingSheet.ToDef(clsNesting.Sheets, 2).ToArray());
			arrayList.Add(" ");
			arrayList.AddRange(buNestingPart.ToDef(clsNesting.Parts, 2).ToArray());
			arrayList.Add(" ");
			arrayList.AddRange(buNestingMaterials.ToDef(clsNesting.Materials, 2).ToArray());
			arrayList.Add("</NestingPartsAndSheets>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("PanelCut Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[17];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenPanelCutFile()
	{
		try
		{
			ArrayList StringList = new ArrayList();
			string fileName = AppPath.Settings + "\\PanelCut\\PanelCut.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("PanelCut Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Drill Settings File Missing");
				}
			}
			else
			{
				StringList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<varPanelCutSettings>", "</varPanelCutSettings>", AddStartEndKey: true, StringList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, varPanelCutSettings);
						buLog.addLog("Panel Cut varPanelCutSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varPanelCutRunSettings>", "</varPanelCutRunSettings>", AddStartEndKey: true, StringList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, varPanelCutRunSettings);
						buLog.addLog("Panel Cut varPanelCutRunSettings  Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("PanelCut Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Drill Settings Decoder Error");
				}
			}
			buLog.addLog("PanelCut Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buNestingSheet.Decode(StringList, ref clsNesting.Sheets);
			buNestingPart.Decode(StringList, ref clsNesting.Parts);
			buNestingMaterials.Decode(StringList, ref clsNesting.Materials);
		}
		catch (Exception mSException2)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
		TreeView treeView = (TreeView)sender;
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)treeView.SelectedNode;
		DeleteNodeSelection();
		if (treeNodeSettings.Level >= 0)
		{
			List<Point3D> Vertices = new List<Point3D>();
			if (treeNodeSettings.Level == 0 && activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Rectangle != null)
			{
				Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Rectangle, ref Vertices);
				DrawSelectedRegion(Vertices);
			}
			if (treeNodeSettings.Level == 1 && activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Rectangle != null)
			{
				Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Rectangle, ref Vertices);
				DrawSelectedRegion(Vertices);
			}
			if (treeNodeSettings.Level == 2 && activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Rectangle != null)
			{
				Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Rectangle, ref Vertices);
				DrawSelectedRegion(Vertices);
			}
			if (treeNodeSettings.Level == 3 && activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Node[treeNodeSettings.ClassSubSubSubIndex].Rectangle != null)
			{
				Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Node[treeNodeSettings.ClassSubSubSubIndex].Rectangle, ref Vertices);
				DrawSelectedRegion(Vertices);
			}
			if (treeNodeSettings.Level == 4 && activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Node[treeNodeSettings.ClassSubSubSubIndex].Node[treeNodeSettings.ClassSubSubSubSubIndex].Rectangle != null)
			{
				Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Node[treeNodeSettings.ClassSubSubSubIndex].Node[treeNodeSettings.ClassSubSubSubSubIndex].Rectangle, ref Vertices);
				DrawSelectedRegion(Vertices);
			}
			if (treeNodeSettings.Level == 5 && activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Node[treeNodeSettings.ClassSubSubSubIndex].Node[treeNodeSettings.ClassSubSubSubSubIndex].Node[treeNodeSettings.ClassSubSubSubSubSubIndex].Rectangle != null)
			{
				Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].Nodes[treeNodeSettings.ClassIndex].Node[treeNodeSettings.ClassSubIndex].Node[treeNodeSettings.ClassSubSubIndex].Node[treeNodeSettings.ClassSubSubSubIndex].Node[treeNodeSettings.ClassSubSubSubSubIndex].Node[treeNodeSettings.ClassSubSubSubSubSubIndex].Rectangle, ref Vertices);
				DrawSelectedRegion(Vertices);
			}
		}
	}

	public void SheetDone_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex <= activeJob.Panels.Count - 1 && e.RowIndex >= 0)
		{
			clsItem.FrmPanelCutJob.dgv_sheets.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
			JobIndex = e.RowIndex;
			doDrawNestingResult();
			JobUpdate(FillPages: true, "", new DrillItem(), -1);
			if (e.RowIndex != 0)
			{
				clsItem.FrmPanelCutJob.dgv_sheets.Rows[0].Cells[0].Selected = false;
			}
		}
	}

	public void JobUpdate(bool FillPages, string Command, DrillItem Item, int indexItem)
	{
		try
		{
			if (clsItem.FrmPanelCutJob == null)
			{
				return;
			}
			if (ccVars.Pages.Count != clsItem.FrmPanelCutJob.tree_jobs.Nodes.Count)
			{
				FillPages = true;
			}
			clsItem.FrmPanelCutJob.tree_jobs.CheckBoxes = false;
			clsItem.FrmPanelCutJob.dgv_sheets.Rows.Clear();
			_ = AppLanguage.CadCamDynamic[114];
			_ = AppLanguage.CadCamDynamic[108];
			_ = AppLanguage.CadCamDynamic[107] + " - ";
			_ = AppLanguage.CadCamDynamic[106];
			_ = AppLanguage.CadCamDynamic[112];
			TreeNodeSettings treeNodeSettings = null;
			TreeNodeSettings treeNodeSettings2 = null;
			TreeNodeSettings treeNodeSettings3 = null;
			TreeNodeSettings treeNodeSettings4 = null;
			TreeNodeSettings treeNodeSettings5 = null;
			TreeNodeSettings treeNodeSettings6 = null;
			TreeNodeSettings treeNodeSettings7 = null;
			TreeNodeSettings treeNodeSettings8 = null;
			TreeNodeSettings treeNodeSettings9 = null;
			if (FillPages)
			{
				clsItem.FrmPanelCutJob.tree_jobs.Nodes.Clear();
				int num = 0;
				int num2 = 0;
				double num3 = 0.0;
				double num4 = 0.0;
				for (int i = 0; i <= activeJob.Panels.Count - 1; i++)
				{
					clsItem.FrmPanelCutJob.dgv_sheets.Rows.Add(method_2(i + 1, activeJob.Panels[i].Width.ToString("f2") + " X " + activeJob.Panels[i].Height.ToString("f2"), activeJob.Panels[i].Count, activeJob.Panels[i].PartCount, activeJob.Panels[i].Waste, activeJob.Panels[i].TotalCutLength, activeJob.Panels[i].Material, activeJob.Panels[i].Explanation));
					num += activeJob.Panels[i].Count;
					num2 += activeJob.Panels[i].PartCount * activeJob.Panels[i].Count;
					num3 += activeJob.Panels[i].TotalCutLength * (double)activeJob.Panels[i].Count;
					num4 += activeJob.Panels[i].Waste * (double)activeJob.Panels[i].Count;
				}
				clsItem.FrmPanelCutJob.dgv_sheets.Rows.Add(method_2(-1, "Total Panel Count - Part Count", num, num2, num4 / (double)num, 0.0, activeJob.Panels[0].Material, "Summurize"));
				for (int j = 0; j <= activeJob.Panels[JobIndex].Nodes.Count - 1; j++)
				{
					string nodeText = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j]);
					treeNodeSettings = new TreeNodeSettings(nodeText)
					{
						ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Direction),
						SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Direction),
						Tag = j.ToString(),
						ClassIndex = j,
						ClassSubIndex = -1,
						ClassSubSubIndex = -1,
						Command = "panel",
						Checked = true
					};
					for (int k = 0; k <= activeJob.Panels[JobIndex].Nodes[j].Node.Count - 1; k++)
					{
						string nodeText2 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k]);
						treeNodeSettings2 = new TreeNodeSettings(nodeText2)
						{
							ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Direction),
							SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Direction),
							Tag = k.ToString(),
							ClassIndex = j,
							ClassSubIndex = k,
							ClassSubSubIndex = -1,
							Command = "panel",
							Checked = true
						};
						for (int l = 0; l <= activeJob.Panels[JobIndex].Nodes[j].Node[k].Node.Count - 1; l++)
						{
							string nodeText3 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l]);
							treeNodeSettings3 = new TreeNodeSettings(nodeText3)
							{
								ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Direction),
								SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Direction),
								Tag = l.ToString(),
								ClassIndex = j,
								ClassSubIndex = k,
								ClassSubSubIndex = l,
								Command = "panel",
								Checked = true
							};
							for (int m = 0; m <= activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node.Count - 1; m++)
							{
								string nodeText4 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m]);
								treeNodeSettings4 = new TreeNodeSettings(nodeText4)
								{
									ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Direction),
									SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Direction),
									Tag = m.ToString(),
									ClassIndex = j,
									ClassSubIndex = k,
									ClassSubSubIndex = l,
									ClassSubSubSubIndex = m,
									Command = "panel",
									Checked = true
								};
								for (int n = 0; n <= activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node.Count - 1; n++)
								{
									string nodeText5 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n]);
									treeNodeSettings5 = new TreeNodeSettings(nodeText5)
									{
										ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Direction),
										SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Direction),
										Tag = n.ToString(),
										ClassIndex = j,
										ClassSubIndex = k,
										ClassSubSubIndex = l,
										ClassSubSubSubIndex = m,
										ClassSubSubSubSubIndex = n,
										Command = "panel",
										Checked = true
									};
									for (int num5 = 0; num5 <= activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node.Count - 1; num5++)
									{
										string nodeText6 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5]);
										treeNodeSettings6 = new TreeNodeSettings(nodeText6)
										{
											ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Direction),
											SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Direction),
											Tag = num5.ToString(),
											ClassIndex = j,
											ClassSubIndex = k,
											ClassSubSubIndex = l,
											ClassSubSubSubIndex = m,
											ClassSubSubSubSubIndex = n,
											ClassSubSubSubSubSubIndex = num5,
											Command = "panel",
											Checked = true
										};
										for (int num6 = 0; num6 <= activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node.Count - 1; num6++)
										{
											string nodeText7 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6]);
											treeNodeSettings7 = new TreeNodeSettings(nodeText7)
											{
												ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Direction),
												SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Direction),
												Tag = num5.ToString(),
												ClassIndex = j,
												ClassSubIndex = k,
												ClassSubSubIndex = l,
												ClassSubSubSubIndex = m,
												ClassSubSubSubSubIndex = n,
												ClassSubSubSubSubSubIndex = num5,
												ClassSubSubSubSubSubSubIndex = num6,
												Command = "panel",
												Checked = true
											};
											for (int num7 = 0; num7 <= activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node.Count - 1; num7++)
											{
												string nodeText8 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node[num7]);
												treeNodeSettings8 = new TreeNodeSettings(nodeText8)
												{
													ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node[num7].Direction),
													SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node[num7].Direction),
													Tag = num5.ToString(),
													ClassIndex = j,
													ClassSubIndex = k,
													ClassSubSubIndex = l,
													ClassSubSubSubIndex = m,
													ClassSubSubSubSubIndex = n,
													ClassSubSubSubSubSubIndex = num5,
													ClassSubSubSubSubSubSubIndex = num6,
													ClassSubSubSubSubSubSubSubIndex = num7,
													Command = "panel",
													Checked = true
												};
												for (int num8 = 0; num8 <= activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node[num7].Node.Count - 1; num8++)
												{
													string nodeText9 = clsInit.cPanelCut.PanelCutToString(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node[num7].Node[num8]);
													treeNodeSettings9 = new TreeNodeSettings(nodeText9)
													{
														ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node[num7].Node[num8].Direction),
														SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(activeJob.Panels[JobIndex].Nodes[j].Node[k].Node[l].Node[m].Node[n].Node[num5].Node[num6].Node[num7].Node[num8].Direction),
														Tag = num5.ToString(),
														ClassIndex = j,
														ClassSubIndex = k,
														ClassSubSubIndex = l,
														ClassSubSubSubIndex = m,
														ClassSubSubSubSubIndex = n,
														ClassSubSubSubSubSubIndex = num5,
														ClassSubSubSubSubSubSubIndex = num6,
														ClassSubSubSubSubSubSubSubIndex = num7,
														ClassSubSubSubSubSubSubSubSubIndex = num8,
														Command = "panel",
														Checked = true
													};
													treeNodeSettings8.Nodes.Add(treeNodeSettings9);
												}
												treeNodeSettings7.Nodes.Add(treeNodeSettings8);
											}
											treeNodeSettings6.Nodes.Add(treeNodeSettings7);
										}
										treeNodeSettings5.Nodes.Add(treeNodeSettings6);
									}
									treeNodeSettings4.Nodes.Add(treeNodeSettings5);
								}
								treeNodeSettings3.Nodes.Add(treeNodeSettings4);
							}
							treeNodeSettings2.Nodes.Add(treeNodeSettings3);
						}
						treeNodeSettings.Nodes.Add(treeNodeSettings2);
					}
				}
				if (treeNodeSettings != null)
				{
					clsItem.FrmPanelCutJob.tree_jobs.Nodes.Add(treeNodeSettings);
					clsItem.FrmPanelCutJob.tree_jobs.Nodes[0].Expand();
				}
			}
			if (JobIndex >= 0)
			{
				clsItem.FrmPanelCutJob.dgv_sheets.Rows[JobIndex].Selected = true;
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	private object[] method_2(int int_0, string string_0, int int_1, int int_2, double double_0, double double_1, string string_1, string string_2)
	{
		return new object[8]
		{
			int_0,
			string_0,
			int_1,
			int_2,
			"%" + Math.Round(double_0, 3),
			Math.Round(double_1 / 1000.0, 3) + "m",
			string_1,
			string_2
		};
	}

	public void SheetUpdate()
	{
		clsNesting.Sheets.Clear();
		for (int i = 0; i <= FrmNestPanelSheet.Sheets.Count - 1; i++)
		{
			clsNesting.Sheets.Add(new buNestingSheet(FrmNestPanelSheet.Sheets[i]));
		}
		clsVar.varInterface.pathNestingFiles = FrmNestPanelSheet.SaveFileFolder;
		SavePanelCutFile();
	}

	public void PartUpdate()
	{
		clsNesting.Parts.Clear();
		for (int i = 0; i <= FrmNestPanelPart.Parts.Count - 1; i++)
		{
			clsNesting.Parts.Add(new buNestingPart(FrmNestPanelPart.Parts[i]));
		}
		clsVar.varInterface.pathNestingFiles = FrmNestPanelPart.SaveFileFolder;
		SavePanelCutFile();
	}

	public string OutputURN(int PartQuantity, double PartWidth, double PartHeight, int CabinetNo, int Sequence)
	{
		string text = "";
		text = text + "URN1," + $"{PartQuantity.ToString(),6}" + "," + $"{PartQuantity.ToString(),6}" + "," + string.Format("{0,6}", PartWidth.ToString("f2")) + "," + string.Format("{0,6}", PartHeight.ToString("f2")) + ", ,N" + Environment.NewLine;
		text = text + "URN2," + string.Format("{0,6}", " ") + "," + string.Format("{0,6}", PartWidth.ToString("f2")) + "," + string.Format("{0,6}", PartHeight.ToString("f2")) + Environment.NewLine;
		return text + "URN3," + $"{CabinetNo.ToString(),3}" + "," + string.Format("{0,3}", Sequence.ToString("f2")) + Environment.NewLine;
	}

	public string OutputPRT(int PartQuantity, double PartWidth, double PartHeight, int CabinetNo, int Sequence, double Thickness)
	{
		string text = "";
		text = text + "PRT1," + $"{PartQuantity.ToString(),6}" + "," + $"{Sequence.ToString(),6}" + "," + string.Format("{0,6}", PartWidth.ToString("f2")) + "," + string.Format("{0,6}", PartHeight.ToString("f2")) + ", 1" + string.Format("{0,15}", " ") + string.Format("{0,10}", " ") + ",,,," + string.Format("{0,10}", " ") + "," + Environment.NewLine;
		text = text + "PRT2, 0, ," + string.Format("{0,9}", Thickness.ToString("f1")) + "," + Environment.NewLine;
		text = text + "PRT3,0000" + string.Format("{0,9}", " ") + ",," + string.Format("{0,9}", " ") + "," + string.Format("{0,9}", " ") + ",," + string.Format("{0,9}", " ") + "," + string.Format("{0,9}", " ") + ",," + string.Format("{0,9}", " ") + ",," + Environment.NewLine;
		text = text + "PRT4,,,,,0," + Environment.NewLine;
		return text + "PRT5, ,N,    ," + Environment.NewLine;
	}

	public string OutputPNL(NestingPanel Panel, string Direction, int PanelCount, double Val1, double Val2, double Val3, double Val4)
	{
		string text = "";
		string text2 = "";
		if (Panel.Nodes[0].Direction == DirectionXandY.XDirection)
		{
			text2 = "S";
		}
		if (Panel.Nodes[0].Direction == DirectionXandY.YDirection)
		{
			text2 = "L";
		}
		text = text + "PNL1,01," + text2 + "," + $"{Panel.Count.ToString(),6}" + ",1" + string.Format("{0,15}", " ") + string.Format("{0,10}", " ") + ",,,," + string.Format("{0,10}", " ") + "," + Environment.NewLine;
		text = text + "PNL2," + string.Format("{0,9}", Panel.Waste.ToString("f1")) + "," + string.Format("{0,15}", Val1.ToString("f3")) + "," + string.Format("{0,15}", Val2.ToString("f3")) + "," + string.Format("{0,15}", Val3.ToString("f3")) + "," + string.Format("{0,15}", Val4.ToString("f3")) + "," + Environment.NewLine;
		text = text + "PNL3," + string.Format("{0,6}", " ") + "," + string.Format("{0,6}", " ") + "," + string.Format("{0,6}", " ") + "," + Environment.NewLine;
		text = text + "PNL4," + string.Format("{0,6}", " ") + "," + string.Format("{0,6}", " ") + "," + Environment.NewLine;
		text = text + "PNL5," + string.Format("{0,6}", " ") + "," + string.Format("{0,6}", " ") + "," + string.Format("{0,6}", " ") + "," + Environment.NewLine;
		text = text + "BASLA" + Environment.NewLine;
		List<string> SL = new List<string>();
		GetCodeNodes(Panel.Nodes, DirectionXandY.XDirection, ref SL);
		for (int i = 0; i <= SL.Count - 1; i++)
		{
			text = text + SL[i] + Environment.NewLine;
		}
		return text + "BITIR" + Environment.NewLine;
	}

	public void doDrawNestingResult()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		if ((JobIndex >= 0) & (JobIndex <= activeJob.Panels.Count - 1))
		{
			for (int i = 0; i <= activeJob.Panels[JobIndex].CalculatedRectangles.Count - 1; i++)
			{
				List<Point3D> Vertices = new List<Point3D>();
				Rectangle2D.Rectangle3DToVertices(activeJob.Panels[JobIndex].CalculatedRectangles[i], ref Vertices);
				LinearPath linearPath = new LinearPath(Vertices);
				linearPath.ColorMethod = colorMethodType.byEntity;
				linearPath.Color = Color.Red;
				clsInit.appCommand.AddPolyline(linearPath);
			}
			DrawNodesParts(activeJob.Panels[JobIndex].Nodes);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doCalculationDone(object data)
	{
		JobIndex = -1;
		if (activeJob.Panels.Count > 0)
		{
			JobIndex = 0;
		}
		doDrawNestingResult();
		JobUpdate(FillPages: true, "", null, -1);
		clsInit.appCommand.cmdViewTop(ZoomFit: false, AtPlane: false);
		clsInit.appCommand.cmdViewZoomFit();
		clsInit.appCommand.cmdViewZoomOut();
	}

	public void doReset()
	{
		DeleteNodeSelection();
	}

	public void doNewPage()
	{
	}

	public void doOpenPage()
	{
	}

	public void doCreateCode(ref string Code)
	{
		string text = "FileName";
		string text2 = "2.10";
		Code = "";
		Code = Code + "BSL1,," + text + Environment.NewLine;
		Code = Code + "BSL2,," + DateTime.Now.Month + "," + DateTime.Now.Day + "," + DateTime.Now.Year + "," + DateTime.Now.ToShortTimeString() + Environment.NewLine;
		Code = Code + "BSL3,," + text2 + ",," + Environment.NewLine;
		Code = Code + "KON1,,,,," + Environment.NewLine;
		Code = Code + "KON2," + varPanelCutSettings.SawThickness + Environment.NewLine;
		Code = Code + "KON3," + Environment.NewLine;
		Code = Code + "LMT1," + varPanelCutSettings.PanelThickness + "," + varPanelCutSettings.PanelMaxThickness + Environment.NewLine;
		for (int i = 0; i <= activeJob.usedParts.Count - 1; i++)
		{
			Code += OutputURN(activeJob.usedParts[i].PartData.Quantity, activeJob.usedParts[i].PartData.Width, activeJob.usedParts[i].PartData.Height, 1, i + 1);
		}
		for (int j = 0; j <= activeJob.usedParts.Count - 1; j++)
		{
			Code += OutputPRT(activeJob.usedParts[j].PartData.Quantity, activeJob.usedParts[j].PartData.Width, activeJob.usedParts[j].PartData.Height, 1, j, varPanelCutSettings.PanelThickness);
		}
		for (int k = 0; k <= activeJob.Panels.Count - 1; k++)
		{
			Code += OutputPNL(activeJob.Panels[k], "", 0, 1.0, 1.0, 1.0, 1.0);
		}
	}
}
