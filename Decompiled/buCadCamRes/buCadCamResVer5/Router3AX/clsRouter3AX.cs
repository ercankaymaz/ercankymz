using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buCadCamResVer5.Nesting;
using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.ClassViewer;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.CamForms;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Router3AX;

public class clsRouter3AX
{
	public static Router3AXTempVars varTemps = new Router3AXTempVars();

	public static Router3AXSettings varRouter3AXSettings = new Router3AXSettings();

	public static Router3AXDisplaySettings varRouter3AXDisplaySettings = new Router3AXDisplaySettings();

	public static Router3AXRuntimeSettings varRouter3AXRunSettings = new Router3AXRuntimeSettings();

	public Timer timGeneral = null;

	public int countGeneral = 0;

	public int SelectedCamIndex = -1;

	public static List<Router3AXItem> JobList = null;

	public Router3AXItem activeJob = null;

	public MWCalculationOptions MWCalcOptions = new MWCalculationOptions();

	public F_CamSequence frmSequence = null;

	public F_CamTable frmTableSelection = null;

	public clsYilmazCPM cModeYilmaz = null;

	public clsCMD cModeCMD = null;

	public clsInfinite cModeInfinite = null;

	private string string_0 = "clsRouter3AX";

	private string string_1 = "Microsoft Sans Serif";

	public void Init()
	{
		buMWRouter3XVars.Init();
		timGeneral = new Timer();
		timGeneral.Tick += General_Tick;
		timGeneral.Interval = 100;
		timGeneral.Enabled = true;
		OpenRouter3Xile();
		LoadLanguage();
		frmSequence = new F_CamSequence();
		frmTableSelection = new F_CamTable();
		if (clsVar.appDefination.CustomerID == AppCustomerID.Yilmaz)
		{
			cModeYilmaz = new clsYilmazCPM();
		}
		if (clsVar.appDefination.CustomerID == AppCustomerID.CMD)
		{
			cModeCMD = new clsCMD();
		}
		if (clsVar.appDefination.CustomerID == AppCustomerID.Infinite)
		{
			cModeInfinite = new clsInfinite();
		}
	}

	public void InitSimulation()
	{
	}

	public void cmdNewJob()
	{
		activeJob = new Router3AXItem();
		JobUpdate();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		DrawJob(new DrawOptions(drawall: true), -1);
	}

	public void cmdNewMaterial(CamStock Stock, bool SkipForm = false)
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
		if (Stock != null)
		{
			clsItem.FrmMaterial3D.Init(new MaterialBase5(Stock.SizeStock));
		}
		else
		{
			clsItem.FrmMaterial3D.Material = new MaterialBase5(varRouter3AXSettings.SizeStock);
			clsItem.FrmMaterial3D.Init(null);
		}
		clsItem.FrmMaterial3D.StartPosition = FormStartPosition.CenterParent;
		if (!SkipForm)
		{
			clsItem.FrmMaterial3D.ShowDialog();
		}
		if (clsItem.FrmMaterial3D.PropertiesForm.Result == DialogResult.OK || SkipForm)
		{
			varRouter3AXSettings.SizeStock = new SizeObject(clsItem.FrmMaterial3D.Material.Size);
			activeJob.Stock = new CamStock();
			activeJob.Stock.SizeStock = new SizeObject(clsItem.FrmMaterial3D.Material.Size);
			Brep brep = Brep.CreateBox(activeJob.Stock.SizeStock.Width, activeJob.Stock.SizeStock.Height, activeJob.Stock.SizeStock.Depth);
			brep.Translate(0.0, 0.0);
			brep.Regen(0.01);
			brep.Rebuild(0.1);
			Mesh another = brep.ConvertToMesh(0.01);
			buMesh buMesh2 = new buMesh(another);
			buMesh2.typeDefination = entityTypeDefination.Stock;
			activeJob.Stock.StockEntities.Add(buMesh2);
			activeJob.Stock.colorStock = new ColorType(varRouter3AXDisplaySettings.colorStock);
			activeJob.Stock.MinPoint = new Point3D(brep.BoxMin.X, brep.BoxMin.Y, brep.BoxMin.Z);
			activeJob.Stock.MaxPoint = new Point3D(brep.BoxMax.X, brep.BoxMax.Y, brep.BoxMax.Z);
			activeJob.Stock.StockName = buLangTranslate.preDef.Stock;
		}
		clsItem.ModelMainPreview.ActiveViewport.DisplayMode = displayType.Flat;
		clsItem.ModelMainPreview.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		clsItem.ModelMainPreview.SetView(viewType.Trimetric);
		clsItem.ModelMainPreview.ZoomFit();
		clsItem.ModelMainPreview.Invalidate();
		DrawJob(new DrawOptions(drawall: true), -1);
		AppBool.Save = true;
		clsInit.appCommand.cmdViewZoomFit();
	}

	public void cmdCamDrillCommand(CamDrillType Cmd)
	{
		string text = "cmdCamDrillCommand";
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = clsInit.cRouter3AX.CamDrillTypeToAction(Cmd);
			MWCalcOptions.NumberofAxis = 3;
			MWCalcOptions.CamDrillType = Cmd;
			MWCalcOptions.CamDrillMode = CamDrillMode.Point;
			MWCalcOptions.AddToCamListInMWCalculation = false;
			MWCalcOptions.AddToCamListInLocalCalculation = true;
			MWCalcOptions.Mode = CamMode.Drill;
			MWCalcOptions.DontShowbuDialogBox = false;
			MWCalcOptions.DontApplyReset = true;
			MWCalcOptions.ShowProgressForm = true;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsInit.cMwCalc.Settings.ShowProgressForm = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				ccVars.selectionProcess = false;
				if (Cmd == CamDrillType.Point)
				{
					doDrill(Router3AXLayerPurpose.None, ccVars.toolActive);
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
			}
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog(string_0, text, "Error", "", 0.0, 0.0, AddException: true);
			buException.throwException(mSException, text, ShowMessageBox: true, "");
		}
	}

	public void cmdCamWireCommand(CamWireFrameType Cmd)
	{
		string text = "cmdCamWireCommand";
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = clsInit.cRouter3AX.CamWireframeTypeToAction(Cmd);
			MWCalcOptions.NumberofAxis = 3;
			MWCalcOptions.CamWireframeType = Cmd;
			MWCalcOptions.AddToCamListInMWCalculation = false;
			MWCalcOptions.AddToCamListInLocalCalculation = true;
			MWCalcOptions.Mode = CamMode.WireFrame;
			MWCalcOptions.DontShowbuDialogBox = false;
			MWCalcOptions.DontApplyReset = true;
			MWCalcOptions.ShowProgressForm = true;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsInit.cMwCalc.Settings.ShowProgressForm = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				ccVars.selectionProcess = false;
				if (Cmd == CamWireFrameType.Contour)
				{
					doWireframeContour(Router3AXLayerPurpose.None, ccVars.toolActive);
				}
				if (Cmd == CamWireFrameType.Pocket)
				{
					doWireframePocket(Router3AXLayerPurpose.None, ccVars.toolActive);
				}
				if (Cmd == CamWireFrameType.CenterPath)
				{
					doWireframeCenterPath(Router3AXLayerPurpose.None, ccVars.toolActive);
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
			}
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog(string_0, text, "Error", "", 0.0, 0.0, AddException: true);
			buException.throwException(mSException, text, ShowMessageBox: true, "");
		}
	}

	public void cmdCamMeshCommand(CamTriangularMeshType Cmd)
	{
		string text = "cmdCamMeshCommand";
		try
		{
			if (clsVar.appModes_0.CompositeMode.MeshEnabled)
			{
				if (!clsVar.appModes_0.CompositeMode.MeshAdvanced)
				{
					switch (Cmd)
					{
					case CamTriangularMeshType.Pencil:
						buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
						return;
					case CamTriangularMeshType.Flatlands:
						buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
						return;
					}
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
				ccVars.Action = clsInit.cRouter3AX.CamMeshTypeToAction(Cmd);
				MWCalcOptions.NumberofAxis = 3;
				MWCalcOptions.CamTriMeshType = Cmd;
				MWCalcOptions.AddToCamListInMWCalculation = false;
				MWCalcOptions.AddToCamListInLocalCalculation = true;
				MWCalcOptions.Mode = CamMode.TriangularMesh;
				MWCalcOptions.DontShowbuDialogBox = false;
				MWCalcOptions.DontApplyReset = true;
				MWCalcOptions.ShowProgressForm = true;
				dynamicInfo.Command = AppLanguage.CadCamCommand[36];
				ccVars.selectionProcess = true;
				clsInit.cMwCalc.Settings.ShowProgressForm = true;
				if (ccVars.SelectionOP.Selections.Count != 0)
				{
					ccVars.selectionProcess = false;
					doTriangularMesh3AX(Cmd, ccVars.toolActive);
				}
				else
				{
					ccVars.stpDrawing = 2;
				}
			}
			else
			{
				buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
			}
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog(string_0, text, "Error", "", 0.0, 0.0, AddException: true);
			buException.throwException(mSException, text, ShowMessageBox: true, "");
		}
	}

	public void cmdCamMesh5AXCommand(CamTriangularMesh5AxType Cmd)
	{
		string text = "cmdCamMesh5AXCommand";
		try
		{
			if (clsVar.appModes_0.CompositeMode.MeshEnabled)
			{
				if (clsVar.appModes_0.CompositeMode.Surface5Axis)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
					ccVars.Action = clsInit.cRouter3AX.CamMeshTypeToAction(Cmd);
					MWCalcOptions.NumberofAxis = 5;
					MWCalcOptions.CamTriMesh5AXType = Cmd;
					MWCalcOptions.AddToCamListInMWCalculation = false;
					MWCalcOptions.AddToCamListInLocalCalculation = true;
					MWCalcOptions.Mode = CamMode.TriangularMesh;
					MWCalcOptions.DontShowbuDialogBox = false;
					MWCalcOptions.DontApplyReset = true;
					MWCalcOptions.ShowProgressForm = true;
					dynamicInfo.Command = AppLanguage.CadCamCommand[36];
					ccVars.selectionProcess = true;
					clsInit.cMwCalc.Settings.ShowProgressForm = true;
					if (ccVars.SelectionOP.Selections.Count != 0)
					{
						ccVars.selectionProcess = false;
						doTriangularMesh5AX(Cmd, ccVars.toolActive);
					}
					else
					{
						ccVars.stpDrawing = 2;
					}
				}
				else
				{
					buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
				}
			}
			else
			{
				buString5.MessageBoxInfo(buLangTranslate.preSentences.YourLicensiIsNotCoverThisFunction);
			}
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog(string_0, text, "Error", "", 0.0, 0.0, AddException: true);
			buException.throwException(mSException, text, ShowMessageBox: true, "");
		}
	}

	public void cmdCamSurfaceCommand(CamSurfaceType Cmd)
	{
		string text = "cmdCamSurfaceCommand";
		try
		{
			if (clsVar.appModes_0.CompositeMode.Surface5Axis)
			{
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = clsInit.cRouter3AX.CamSurfaceTypeToAction(Cmd);
			MWCalcOptions.NumberofAxis = 3;
			MWCalcOptions.CamSurfType = Cmd;
			MWCalcOptions.AddToCamListInMWCalculation = false;
			MWCalcOptions.AddToCamListInLocalCalculation = true;
			MWCalcOptions.Mode = CamMode.Surface;
			MWCalcOptions.DontShowbuDialogBox = false;
			MWCalcOptions.DontApplyReset = true;
			MWCalcOptions.ShowProgressForm = true;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsInit.cMwCalc.Settings.ShowProgressForm = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				ccVars.selectionProcess = false;
				doSurface5AX(Cmd, ccVars.toolActive);
			}
			else
			{
				ccVars.stpDrawing = 2;
			}
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog(string_0, text, "Error", "", 0.0, 0.0, AddException: true);
			buException.throwException(mSException, text, ShowMessageBox: true, "");
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
		if (text == clsItem.FrmRouter3AXJob.mnu_camdelete.Name)
		{
			doCamDelete();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_camdeleteall.Name)
		{
			doCamDeleteAll();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_camedit.Name)
		{
			doCamEdit();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_camedittool.Name)
		{
			doCamToolEdit();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_camenabledisable.Name)
		{
			doCamEnableDisable();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_camrename.Name)
		{
			doCamRename();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_down.Name)
		{
			doCamMoveDown();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_up.Name)
		{
			doCamMoveUp();
		}
		if (text == clsItem.FrmRouter3AXJob.mnu_redraw.Name)
		{
			DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
			UpdateDrawJob(SelectedCamIndex);
		}
	}

	public void cmdSimStart()
	{
		clsInit.appCommand.simStart();
	}

	public void cmdSimStop()
	{
		clsInit.appCommand.simStop();
	}

	public void cmdSimNext()
	{
		clsInit.appCommand.simNext();
	}

	public void cmdSimPre()
	{
		clsInit.appCommand.simPre();
	}

	public void cmdSettings()
	{
		F_ClassViewerDialog5 f_ClassViewerDialog = new F_ClassViewerDialog5();
		f_ClassViewerDialog.FormCaption = buLangTranslate.preDef.Setting;
		f_ClassViewerDialog.Value = varRouter3AXSettings;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Width = 500;
		f_ClassViewerDialog.Height = 750;
		f_ClassViewerDialog.ValuePersentage = 35.0;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog();
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			varRouter3AXSettings = new Router3AXSettings((Router3AXSettings)f_ClassViewerDialog.Value);
			SaveRouter3XFile();
		}
	}

	public void cmdSettingsDisplay()
	{
		F_ClassViewerDialog5 f_ClassViewerDialog = new F_ClassViewerDialog5();
		f_ClassViewerDialog.FormCaption = buLangTranslate.preDef.Setting + " " + buLangTranslate.preDef.Display;
		f_ClassViewerDialog.Value = varRouter3AXDisplaySettings;
		f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
		f_ClassViewerDialog.Width = 500;
		f_ClassViewerDialog.Height = 750;
		f_ClassViewerDialog.ValuePersentage = 35.0;
		f_ClassViewerDialog.Init();
		f_ClassViewerDialog.ShowDialog();
		if (f_ClassViewerDialog.Result == DialogResult.OK)
		{
			varRouter3AXDisplaySettings = new Router3AXDisplaySettings((Router3AXDisplaySettings)f_ClassViewerDialog.Value);
			SaveRouter3XFile();
			DrawJob(new DrawOptions(drawall: true, deletestock: true, deletetool: true), SelectedCamIndex);
		}
	}

	public void cmdSettingsMilling2D(CamType CamType)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_059a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Expected O, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected O, but got Unknown
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Expected O, but got Unknown
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected O, but got Unknown
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Expected O, but got Unknown
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Expected O, but got Unknown
		//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Expected O, but got Unknown
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d6: Expected O, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected O, but got Unknown
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bf: Expected O, but got Unknown
		//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Expected O, but got Unknown
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Expected O, but got Unknown
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c8: Expected O, but got Unknown
		//IL_09de: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Expected O, but got Unknown
		//IL_0a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a73: Expected O, but got Unknown
		if (CamType == CamType.PocketCircular || CamType == CamType.PocketFlat)
		{
			F_WFRough f_WFRough = new F_WFRough();
			MWCalculationOptions data = new MWCalculationOptions();
			f_WFRough.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeRough.mwPar.Units, 0);
			f_WFRough.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeRough.mwPar, f_WFRough.mwCamParameter);
			f_WFRough.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeRough.buPar);
			f_WFRough.Text = buLangTranslate.preDef.Contour;
			f_WFRough.Configration = new MWCalculationOptions(data);
			f_WFRough.Init();
			f_WFRough.ShowDialog();
			if (f_WFRough.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam = new MachiningParams(f_WFRough.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFRough.mwCamParameter, buMWRouter3XVars.varCamWireframeRough.mwPar);
				buMWRouter3XVars.varCamWireframeRough.buPar = new camParameters5(f_WFRough.buCamParameter);
			}
		}
		if (CamType == CamType.Center)
		{
			F_WFContour f_WFContour = new F_WFContour();
			MWCalculationOptions data2 = new MWCalculationOptions();
			f_WFContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCenterPath.mwPar.Units, 0);
			f_WFContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCenterPath.mwPar, f_WFContour.mwCamParameter);
			f_WFContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCenterPath.buPar);
			f_WFContour.Text = buLangTranslate.preDef.Contour;
			f_WFContour.Configration = new MWCalculationOptions(data2);
			f_WFContour.Init();
			f_WFContour.ShowDialog();
			if (f_WFContour.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam = new MachiningParams(f_WFContour.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCenterPath.mwPar);
				buMWRouter3XVars.varCamWireframeCenterPath.buPar = new camParameters5(f_WFContour.buCamParameter);
			}
		}
		if (CamType == CamType.Contour)
		{
			F_WFContour f_WFContour2 = new F_WFContour();
			MWCalculationOptions data3 = new MWCalculationOptions();
			f_WFContour2.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeContour.mwPar.Units, 0);
			f_WFContour2.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeContour.mwPar, f_WFContour2.mwCamParameter);
			f_WFContour2.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeContour.buPar);
			f_WFContour2.Text = buLangTranslate.preDef.Contour;
			f_WFContour2.Configration = new MWCalculationOptions(data3);
			f_WFContour2.Init();
			f_WFContour2.ShowDialog();
			if (f_WFContour2.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam = new MachiningParams(f_WFContour2.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour2.mwCamParameter, buMWRouter3XVars.varCamWireframeContour.mwPar);
				buMWRouter3XVars.varCamWireframeContour.buPar = new camParameters5(f_WFContour2.buCamParameter);
			}
		}
		if (CamType == CamType.Chamfer)
		{
			F_WFContour f_WFContour3 = new F_WFContour();
			MWCalculationOptions data4 = new MWCalculationOptions();
			f_WFContour3.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeChamfer.mwPar.Units, 0);
			f_WFContour3.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeChamfer.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeChamfer.mwPar, f_WFContour3.mwCamParameter);
			f_WFContour3.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeChamfer.buPar);
			f_WFContour3.Text = buLangTranslate.preDef.Chamfer;
			f_WFContour3.Configration = new MWCalculationOptions(data4);
			f_WFContour3.Init();
			f_WFContour3.ShowDialog();
			if (f_WFContour3.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeChamfer.mwPar.MachParam = new MachiningParams(f_WFContour3.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour3.mwCamParameter, buMWRouter3XVars.varCamWireframeChamfer.mwPar);
				buMWRouter3XVars.varCamWireframeChamfer.buPar = new camParameters5(f_WFContour3.buCamParameter);
			}
		}
		if (CamType == CamType.Engrave)
		{
			F_WFContour f_WFContour4 = new F_WFContour();
			MWCalculationOptions data5 = new MWCalculationOptions();
			f_WFContour4.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeEngrave.mwPar.Units, 0);
			f_WFContour4.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeEngrave.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeEngrave.mwPar, f_WFContour4.mwCamParameter);
			f_WFContour4.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeEngrave.buPar);
			f_WFContour4.Text = buLangTranslate.preDef.Engrave;
			f_WFContour4.Configration = new MWCalculationOptions(data5);
			f_WFContour4.Init();
			f_WFContour4.ShowDialog();
			if (f_WFContour4.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeEngrave.mwPar.MachParam = new MachiningParams(f_WFContour4.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour4.mwCamParameter, buMWRouter3XVars.varCamWireframeEngrave.mwPar);
				buMWRouter3XVars.varCamWireframeEngrave.buPar = new camParameters5(f_WFContour4.buCamParameter);
			}
		}
		if (CamType == CamType.Face)
		{
			F_WFContour f_WFContour5 = new F_WFContour();
			MWCalculationOptions data6 = new MWCalculationOptions();
			f_WFContour5.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeFace.mwPar.Units, 0);
			f_WFContour5.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeFace.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeFace.mwPar, f_WFContour5.mwCamParameter);
			f_WFContour5.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeFace.buPar);
			f_WFContour5.Text = buLangTranslate.preDef.Face;
			f_WFContour5.Configration = new MWCalculationOptions(data6);
			f_WFContour5.Init();
			f_WFContour5.ShowDialog();
			if (f_WFContour5.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeFace.mwPar.MachParam = new MachiningParams(f_WFContour5.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour5.mwCamParameter, buMWRouter3XVars.varCamWireframeFace.mwPar);
				buMWRouter3XVars.varCamWireframeFace.buPar = new camParameters5(f_WFContour5.buCamParameter);
			}
		}
		if (CamType == CamType.FloorFinishing)
		{
			F_WFContour f_WFContour6 = new F_WFContour();
			MWCalculationOptions data7 = new MWCalculationOptions();
			f_WFContour6.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.Units, 0);
			f_WFContour6.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeFloorFinish.mwPar, f_WFContour6.mwCamParameter);
			f_WFContour6.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeFloorFinish.buPar);
			f_WFContour6.Text = buLangTranslate.preDef.FloorFinish;
			f_WFContour6.Configration = new MWCalculationOptions(data7);
			f_WFContour6.Init();
			f_WFContour6.ShowDialog();
			if (f_WFContour6.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.MachParam = new MachiningParams(f_WFContour6.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour6.mwCamParameter, buMWRouter3XVars.varCamWireframeFloorFinish.mwPar);
				buMWRouter3XVars.varCamWireframeFloorFinish.buPar = new camParameters5(f_WFContour6.buCamParameter);
			}
		}
		if (CamType == CamType.TextEngrave)
		{
			F_WFContour f_WFContour7 = new F_WFContour();
			MWCalculationOptions data8 = new MWCalculationOptions();
			f_WFContour7.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.Units, 0);
			f_WFContour7.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeTextEngrave.mwPar, f_WFContour7.mwCamParameter);
			f_WFContour7.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeTextEngrave.buPar);
			f_WFContour7.Text = buLangTranslate.preDef.TextEngrave;
			f_WFContour7.Configration = new MWCalculationOptions(data8);
			f_WFContour7.Init();
			f_WFContour7.ShowDialog();
			if (f_WFContour7.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.MachParam = new MachiningParams(f_WFContour7.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour7.mwCamParameter, buMWRouter3XVars.varCamWireframeTextEngrave.mwPar);
				buMWRouter3XVars.varCamWireframeTextEngrave.buPar = new camParameters5(f_WFContour7.buCamParameter);
			}
		}
		if (CamType == CamType.Trochoidal)
		{
			F_WFContour f_WFContour8 = new F_WFContour();
			MWCalculationOptions data9 = new MWCalculationOptions();
			f_WFContour8.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.Units, 0);
			f_WFContour8.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeTrochoidial.mwPar, f_WFContour8.mwCamParameter);
			f_WFContour8.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeTrochoidial.buPar);
			f_WFContour8.Text = buLangTranslate.preDef.Trochoidal;
			f_WFContour8.Configration = new MWCalculationOptions(data9);
			f_WFContour8.Init();
			f_WFContour8.ShowDialog();
			if (f_WFContour8.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.MachParam = new MachiningParams(f_WFContour8.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour8.mwCamParameter, buMWRouter3XVars.varCamWireframeTrochoidial.mwPar);
				buMWRouter3XVars.varCamWireframeTrochoidial.buPar = new camParameters5(f_WFContour8.buCamParameter);
			}
		}
		if (CamType == CamType.Drill)
		{
			F_DrillLine f_DrillLine = new F_DrillLine();
			MWCalculationOptions data10 = new MWCalculationOptions();
			f_DrillLine.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeDrill.mwPar.Units, 0);
			f_DrillLine.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeDrill.mwPar, f_DrillLine.mwCamParameter);
			f_DrillLine.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeDrill.buPar);
			f_DrillLine.Text = buLangTranslate.preDef.Trochoidal;
			f_DrillLine.Configration = new MWCalculationOptions(data10);
			f_DrillLine.Init();
			f_DrillLine.ShowDialog();
			if (f_DrillLine.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam = new MachiningParams(f_DrillLine.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_DrillLine.mwCamParameter, buMWRouter3XVars.varCamWireframeDrill.mwPar);
				buMWRouter3XVars.varCamWireframeDrill.buPar = new camParameters5(f_DrillLine.buCamParameter);
			}
		}
		SaveRouter3XFile();
	}

	public void cmdSettingsMilling3D(CamTriangularMeshType CamType)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		if (CamType == CamTriangularMeshType.Rough)
		{
			F_TriMeshRough f_TriMeshRough = new F_TriMeshRough();
			MWCalculationOptions data = new MWCalculationOptions();
			f_TriMeshRough.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshRough.mwPar.Units, 0);
			f_TriMeshRough.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshRough.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshRough.mwPar, f_TriMeshRough.mwCamParameter);
			f_TriMeshRough.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshRough.buPar);
			f_TriMeshRough.Text = buLangTranslate.preDef.Rough;
			f_TriMeshRough.Configration = new MWCalculationOptions(data);
			f_TriMeshRough.Init();
			f_TriMeshRough.ShowDialog();
			if (f_TriMeshRough.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamMeshRough.mwPar.MachParam = new MachiningParams(f_TriMeshRough.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshRough.mwCamParameter, buMWRouter3XVars.varCamMeshRough.mwPar);
				buMWRouter3XVars.varCamMeshRough.buPar = new camParameters5(f_TriMeshRough.buCamParameter);
			}
		}
		if (CamType == CamTriangularMeshType.ParallelCuts)
		{
			F_TriMeshParallelCut f_TriMeshParallelCut = new F_TriMeshParallelCut();
			MWCalculationOptions data2 = new MWCalculationOptions();
			f_TriMeshParallelCut.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshParallel.mwPar.Units, 0);
			f_TriMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshParallel.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshParallel.mwPar, f_TriMeshParallelCut.mwCamParameter);
			f_TriMeshParallelCut.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshParallel.buPar);
			f_TriMeshParallelCut.Text = buLangTranslate.preDef.ParalelCuts;
			f_TriMeshParallelCut.Configration = new MWCalculationOptions(data2);
			f_TriMeshParallelCut.Init();
			f_TriMeshParallelCut.ShowDialog();
			if (f_TriMeshParallelCut.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamMeshParallel.mwPar.MachParam = new MachiningParams(f_TriMeshParallelCut.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshParallelCut.mwCamParameter, buMWRouter3XVars.varCamMeshParallel.mwPar);
				buMWRouter3XVars.varCamMeshParallel.buPar = new camParameters5(f_TriMeshParallelCut.buCamParameter);
			}
		}
		if (CamType == CamTriangularMeshType.ConstantZ)
		{
			F_TriMeshConstantZ f_TriMeshConstantZ = new F_TriMeshConstantZ();
			MWCalculationOptions data3 = new MWCalculationOptions();
			f_TriMeshConstantZ.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshConstantZ.mwPar.Units, 0);
			f_TriMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshConstantZ.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshConstantZ.mwPar, f_TriMeshConstantZ.mwCamParameter);
			f_TriMeshConstantZ.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshConstantZ.buPar);
			f_TriMeshConstantZ.Text = buLangTranslate.preDef.ConstantZ;
			f_TriMeshConstantZ.Configration = new MWCalculationOptions(data3);
			f_TriMeshConstantZ.Init();
			f_TriMeshConstantZ.ShowDialog();
			if (f_TriMeshConstantZ.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamMeshConstantZ.mwPar.MachParam = new MachiningParams(f_TriMeshConstantZ.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshConstantZ.mwCamParameter, buMWRouter3XVars.varCamMeshConstantZ.mwPar);
				buMWRouter3XVars.varCamMeshConstantZ.buPar = new camParameters5(f_TriMeshConstantZ.buCamParameter);
			}
		}
		if (CamType == CamTriangularMeshType.Flatlands)
		{
			F_TriMeshConstantZ f_TriMeshConstantZ2 = new F_TriMeshConstantZ();
			MWCalculationOptions data4 = new MWCalculationOptions();
			f_TriMeshConstantZ2.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshFlatLand.mwPar.Units, 0);
			f_TriMeshConstantZ2.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshFlatLand.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshFlatLand.mwPar, f_TriMeshConstantZ2.mwCamParameter);
			f_TriMeshConstantZ2.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshFlatLand.buPar);
			f_TriMeshConstantZ2.Text = buLangTranslate.preDef.Flatlands;
			f_TriMeshConstantZ2.Configration = new MWCalculationOptions(data4);
			f_TriMeshConstantZ2.Init();
			f_TriMeshConstantZ2.ShowDialog();
			if (f_TriMeshConstantZ2.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamMeshFlatLand.mwPar.MachParam = new MachiningParams(f_TriMeshConstantZ2.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshConstantZ2.mwCamParameter, buMWRouter3XVars.varCamMeshFlatLand.mwPar);
				buMWRouter3XVars.varCamMeshFlatLand.buPar = new camParameters5(f_TriMeshConstantZ2.buCamParameter);
			}
		}
		if (CamType == CamTriangularMeshType.Pencil)
		{
			F_TriMeshConstantZ f_TriMeshConstantZ3 = new F_TriMeshConstantZ();
			MWCalculationOptions data5 = new MWCalculationOptions();
			f_TriMeshConstantZ3.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamMeshPencil.mwPar.Units, 0);
			f_TriMeshConstantZ3.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamMeshPencil.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamMeshPencil.mwPar, f_TriMeshConstantZ3.mwCamParameter);
			f_TriMeshConstantZ3.buCamParameter = new camParameters5(buMWRouter3XVars.varCamMeshPencil.buPar);
			f_TriMeshConstantZ3.Text = buLangTranslate.preDef.Pencil;
			f_TriMeshConstantZ3.Configration = new MWCalculationOptions(data5);
			f_TriMeshConstantZ3.Init();
			f_TriMeshConstantZ3.ShowDialog();
			if (f_TriMeshConstantZ3.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamMeshPencil.mwPar.MachParam = new MachiningParams(f_TriMeshConstantZ3.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshConstantZ3.mwCamParameter, buMWRouter3XVars.varCamMeshPencil.mwPar);
				buMWRouter3XVars.varCamMeshPencil.buPar = new camParameters5(f_TriMeshConstantZ3.buCamParameter);
			}
		}
		SaveRouter3XFile();
	}

	public void cmdSettingsComposite(ToolPurpose Tool)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected O, but got Unknown
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Expected O, but got Unknown
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Expected O, but got Unknown
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Expected O, but got Unknown
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Expected O, but got Unknown
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Expected O, but got Unknown
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Expected O, but got Unknown
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Expected O, but got Unknown
		if (Tool == ToolPurpose.Cutting)
		{
			F_WFContour f_WFContour = new F_WFContour();
			MWCalculationOptions data = new MWCalculationOptions();
			buMWRouter3XVars.varCamWireframeCompCutting.buPar.Operations.isClosed = true;
			f_WFContour.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutting.mwPar.Units, 0);
			f_WFContour.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutting.mwPar, f_WFContour.mwCamParameter);
			f_WFContour.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutting.buPar);
			f_WFContour.Text = buLangTranslate.preDef.Cutting;
			f_WFContour.Configration = new MWCalculationOptions(data);
			f_WFContour.Init();
			f_WFContour.ShowDialog();
			if (f_WFContour.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam = new MachiningParams(f_WFContour.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutting.mwPar);
				buMWRouter3XVars.varCamWireframeCompCutting.buPar = new camParameters5(f_WFContour.buCamParameter);
			}
		}
		if (Tool == ToolPurpose.Derz)
		{
			F_WFContour f_WFContour2 = new F_WFContour();
			MWCalculationOptions data2 = new MWCalculationOptions();
			buMWRouter3XVars.varCamWireframeCompGrove.buPar.Operations.isClosed = false;
			f_WFContour2.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompGrove.mwPar.Units, 0);
			f_WFContour2.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompGrove.mwPar, f_WFContour2.mwCamParameter);
			f_WFContour2.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompGrove.buPar);
			f_WFContour2.Text = buLangTranslate.preDef.Center;
			f_WFContour2.Configration = new MWCalculationOptions(data2);
			f_WFContour2.Init();
			f_WFContour2.ShowDialog();
			if (f_WFContour2.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam = new MachiningParams(f_WFContour2.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour2.mwCamParameter, buMWRouter3XVars.varCamWireframeCompGrove.mwPar);
				buMWRouter3XVars.varCamWireframeCompGrove.buPar = new camParameters5(f_WFContour2.buCamParameter);
			}
		}
		if (Tool == ToolPurpose.CutCenter)
		{
			F_WFContour f_WFContour3 = new F_WFContour();
			MWCalculationOptions data3 = new MWCalculationOptions();
			buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Operations.isClosed = false;
			f_WFContour3.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.Units, 0);
			f_WFContour3.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar, f_WFContour3.mwCamParameter);
			f_WFContour3.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutCenter.buPar);
			f_WFContour3.Text = buLangTranslate.preDef.Center;
			f_WFContour3.Configration = new MWCalculationOptions(data3);
			f_WFContour3.Init();
			f_WFContour3.ShowDialog();
			if (f_WFContour3.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam = new MachiningParams(f_WFContour3.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour3.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar);
				buMWRouter3XVars.varCamWireframeCompCutCenter.buPar = new camParameters5(f_WFContour3.buCamParameter);
			}
		}
		if (Tool == ToolPurpose.CutIn)
		{
			F_WFContour f_WFContour4 = new F_WFContour();
			MWCalculationOptions data4 = new MWCalculationOptions();
			buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Operations.isClosed = true;
			f_WFContour4.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.Units, 0);
			f_WFContour4.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar, f_WFContour4.mwCamParameter);
			f_WFContour4.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutInside.buPar);
			f_WFContour4.Text = buLangTranslate.preDef.Inside;
			f_WFContour4.Configration = new MWCalculationOptions(data4);
			f_WFContour4.Init();
			f_WFContour4.ShowDialog();
			if (f_WFContour4.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam = new MachiningParams(f_WFContour4.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour4.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutInside.mwPar);
				buMWRouter3XVars.varCamWireframeCompCutInside.buPar = new camParameters5(f_WFContour4.buCamParameter);
			}
		}
		if (Tool == ToolPurpose.CutOut)
		{
			F_WFContour f_WFContour5 = new F_WFContour();
			MWCalculationOptions data5 = new MWCalculationOptions();
			buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Operations.isClosed = true;
			f_WFContour5.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.Units, 0);
			f_WFContour5.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar, f_WFContour5.mwCamParameter);
			f_WFContour5.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompCutOutside.buPar);
			f_WFContour5.Text = buLangTranslate.preDef.Outside;
			f_WFContour5.Configration = new MWCalculationOptions(data5);
			f_WFContour5.Init();
			f_WFContour5.ShowDialog();
			if (f_WFContour5.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam = new MachiningParams(f_WFContour5.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour5.mwCamParameter, buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar);
				buMWRouter3XVars.varCamWireframeCompCutOutside.buPar = new camParameters5(f_WFContour5.buCamParameter);
			}
		}
		if (Tool == ToolPurpose.PocketCircular || Tool == ToolPurpose.PocketFlat)
		{
			F_WFRough f_WFRough = new F_WFRough();
			MWCalculationOptions data6 = new MWCalculationOptions();
			f_WFRough.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompPocket.mwPar.Units, 0);
			f_WFRough.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompPocket.mwPar, f_WFRough.mwCamParameter);
			f_WFRough.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompPocket.buPar);
			f_WFRough.Text = buLangTranslate.preDef.Pocket;
			f_WFRough.Configration = new MWCalculationOptions(data6);
			f_WFRough.Init();
			f_WFRough.ShowDialog();
			if (f_WFRough.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam = new MachiningParams(f_WFRough.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFRough.mwCamParameter, buMWRouter3XVars.varCamWireframeCompPocket.mwPar);
				buMWRouter3XVars.varCamWireframeCompPocket.buPar = new camParameters5(f_WFRough.buCamParameter);
			}
		}
		if (Tool == ToolPurpose.Text)
		{
			F_WFContour f_WFContour6 = new F_WFContour();
			MWCalculationOptions data7 = new MWCalculationOptions();
			f_WFContour6.mwCamParameter = new GeoLib(buMWRouter3XVars.varCamWireframeCompText.mwPar.Units, 0);
			f_WFContour6.mwCamParameter.MachParam = new MachiningParams(buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam);
			buMWCalcs.CopyGeoLibProperties(buMWRouter3XVars.varCamWireframeCompText.mwPar, f_WFContour6.mwCamParameter);
			f_WFContour6.buCamParameter = new camParameters5(buMWRouter3XVars.varCamWireframeCompText.buPar);
			f_WFContour6.Text = buLangTranslate.preDef.Text;
			f_WFContour6.Configration = new MWCalculationOptions(data7);
			f_WFContour6.Init();
			f_WFContour6.ShowDialog();
			if (f_WFContour6.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam = new MachiningParams(f_WFContour6.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_WFContour6.mwCamParameter, buMWRouter3XVars.varCamWireframeCompText.mwPar);
				buMWRouter3XVars.varCamWireframeCompText.buPar = new camParameters5(f_WFContour6.buCamParameter);
			}
		}
		SaveRouter3XFile();
	}

	public void cmdSequence()
	{
		frmSequence.Properties.FormCloseMode = FormCloseModeType.Invisible;
		frmSequence.Properties.FormPosition = FormStartPosition.CenterParent;
		frmSequence.SourceList.Clear();
		frmSequence.SourceList.AddRange(buConversion5.EnumToString(typeof(Router3AXLayerPurpose)));
		frmSequence.TargetList.Clear();
		frmSequence.TargetList.AddRange(buString5.Copy(varRouter3AXRunSettings.SequenceList));
		frmSequence.Init();
		frmSequence.ShowDialog();
		if (frmSequence.Properties.Result == DialogResult.OK)
		{
			varRouter3AXRunSettings.SequenceList.Clear();
			varRouter3AXRunSettings.SequenceList.AddRange(buString5.Copy(frmSequence.TargetList));
			SaveRouter3XFile();
		}
	}

	public void cmdShowCode(bool SaveFile)
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count > 0)
			{
				if (clsVar.appDefination.CustomerID == AppCustomerID.Yilmaz && cModeYilmaz != null)
				{
					cModeYilmaz.cmdShowCode(SaveFile);
				}
				if (clsVar.appDefination.CustomerID == AppCustomerID.CMD && cModeCMD != null)
				{
					cModeCMD.cmdShowCode(SaveFile);
				}
				if (clsVar.appDefination.CustomerID == AppCustomerID.Infinite && cModeInfinite != null)
				{
					cModeInfinite.cmdShowCode(SaveFile);
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentences.NoPageOpened);
			}
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentences.NotAvailableDemoMode);
		}
	}

	public void UpdateDrawJob(int selectedCam)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			if (entity.EntityData == null || !(entity.EntityData is CustomData))
			{
				continue;
			}
			CustomData customData = entity.EntityData as CustomData;
			if (customData.typeDefination == entityTypeDefination.Plane)
			{
				if (customData.RefIndex != selectedCam)
				{
					entity.Visible = false;
				}
				else
				{
					entity.Visible = true;
				}
				if (!activeJob.CamList[customData.RefIndex].Enable)
				{
					entity.Visible = false;
				}
			}
			if (clsInit.cVector5.isEntityCamEntity(entity))
			{
				if (!(customData.RefIndex == selectedCam || selectedCam == -1))
				{
					entity.Visible = false;
				}
				else
				{
					entity.Visible = true;
				}
				if (!activeJob.CamList[customData.RefIndex].Enable)
				{
					entity.Visible = false;
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void DrawJob(DrawOptions Options, int selectedCam)
	{
		if (Options.DrawAll)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (clsInit.cVector5.isEntityCamEntity(entity))
				{
					entity.Selected = true;
				}
				if (clsInit.cVector5.isEntityToolEntity(entity))
				{
					entity.Selected = true;
				}
				if (clsInit.cVector5.isEntityStockEntity(entity))
				{
					entity.Selected = true;
				}
				if (clsInit.cVector5.isEntityPlaneEntity(entity))
				{
					entity.Selected = true;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			if (activeJob.Stock != null)
			{
				for (int j = 0; j <= activeJob.Stock.StockEntities.Count - 1; j++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(activeJob.Stock.StockEntities[j], ref copiedEntity);
					copiedEntity.Color = Color.FromArgb(activeJob.Stock.colorStock.Transperancy, activeJob.Stock.colorStock.Color);
					copiedEntity.ColorMethod = colorMethodType.byEntity;
					copiedEntity.LineTypeMethod = colorMethodType.byEntity;
					copiedEntity.Selectable = false;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
				}
			}
			for (int k = 0; k <= activeJob.CamList.Count - 1; k++)
			{
				Router3AXCAM router3AXCAM = activeJob.CamList[k];
				string layerName = varTemps.layerCamPlane;
				if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, layerName))
				{
					layerName = "Default";
				}
				if (router3AXCAM.entitiesPlane != null)
				{
					Entity entPlane = null;
					Entity entText = null;
					clsInit.cRouter3AX.CreatePlaneEntities(router3AXCAM.entitiesPlane.entityPlaneBottom, router3AXCAM.entitiesPlane.entityPlaneBottomText, CamPlaneHeightType.Bottom, k, varRouter3AXDisplaySettings, ref entPlane, ref entText);
					if (k != selectedCam)
					{
						if (entPlane != null)
						{
							entPlane.Visible = false;
						}
						if (entText != null)
						{
							entText.Visible = false;
						}
					}
					if (entPlane != null)
					{
						entPlane.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
					}
					if (entText != null)
					{
						entText.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
					}
					entPlane = null;
					entText = null;
					clsInit.cRouter3AX.CreatePlaneEntities(router3AXCAM.entitiesPlane.entityPlaneTop, router3AXCAM.entitiesPlane.entityPlaneTopText, CamPlaneHeightType.Top, k, varRouter3AXDisplaySettings, ref entPlane, ref entText);
					if (k != selectedCam)
					{
						if (entPlane != null)
						{
							entPlane.Visible = false;
						}
						if (entText != null)
						{
							entText.Visible = false;
						}
					}
					if (entPlane != null)
					{
						entPlane.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
					}
					if (entText != null)
					{
						entText.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
					}
					entPlane = null;
					entText = null;
					clsInit.cRouter3AX.CreatePlaneEntities(router3AXCAM.entitiesPlane.entityPlaneRetract, router3AXCAM.entitiesPlane.entityPlaneRetractText, CamPlaneHeightType.Retract, k, varRouter3AXDisplaySettings, ref entPlane, ref entText);
					if (k != selectedCam)
					{
						if (entPlane != null)
						{
							entPlane.Visible = false;
						}
						if (entText != null)
						{
							entText.Visible = false;
						}
					}
					if (entPlane != null)
					{
						entPlane.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
					}
					if (entText != null)
					{
						entText.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
					}
					entPlane = null;
					entText = null;
					clsInit.cRouter3AX.CreatePlaneEntities(router3AXCAM.entitiesPlane.entityPlaneClearance, router3AXCAM.entitiesPlane.entityPlaneClearanceText, CamPlaneHeightType.Clearance, k, varRouter3AXDisplaySettings, ref entPlane, ref entText);
					if (k != selectedCam)
					{
						if (entPlane != null)
						{
							entPlane.Visible = false;
						}
						if (entText != null)
						{
							entText.Visible = false;
						}
					}
					if (entPlane != null)
					{
						entPlane.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entPlane);
					}
					if (entText != null)
					{
						entText.LayerName = layerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entText);
					}
				}
				string layerName2 = varTemps.layerWireframe;
				if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, layerName2))
				{
					layerName2 = "Default";
				}
				for (int l = 0; l <= router3AXCAM.CamEntities.Count - 1; l++)
				{
					Entity copiedEntity2 = null;
					buEntity.Copy(router3AXCAM.CamEntities[l], ref copiedEntity2);
					((CustomData)copiedEntity2.EntityData).typeDefination = entityTypeDefination.Cam;
					((CustomData)copiedEntity2.EntityData).RefIndex = k;
					copiedEntity2.Color = varRouter3AXDisplaySettings.colorCamBase.Color;
					copiedEntity2.LineWeight = (float)varRouter3AXDisplaySettings.colorCamBase.Thickess;
					copiedEntity2.ColorMethod = colorMethodType.byEntity;
					copiedEntity2.LineWeightMethod = colorMethodType.byEntity;
					copiedEntity2.Selectable = false;
					copiedEntity2.LayerName = layerName2;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity2);
				}
				string layerName3 = varTemps.layerCam;
				if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, layerName3))
				{
					layerName3 = "Default";
				}
				if (clsVar.varCam.ShowCamG0Drawings)
				{
					for (int m = 0; m <= router3AXCAM.CamData.EntitiesG0.Count - 1; m++)
					{
						Entity copiedEntity3 = null;
						buEntity.Copy(router3AXCAM.CamData.EntitiesG0[m], ref copiedEntity3);
						((CustomData)copiedEntity3.EntityData).typeDefination = entityTypeDefination.CamG0;
						((CustomData)copiedEntity3.EntityData).RefIndex = k;
						copiedEntity3.Color = varRouter3AXDisplaySettings.colorCamG0.Color;
						copiedEntity3.LineWeight = (float)varRouter3AXDisplaySettings.colorCamG0.Thickess;
						copiedEntity3.ColorMethod = colorMethodType.byEntity;
						copiedEntity3.LineWeightMethod = colorMethodType.byEntity;
						copiedEntity3.Selectable = false;
						copiedEntity3.LayerName = layerName3;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity3);
					}
				}
				if (clsVar.varCam.ShowCamG1Drawings)
				{
					for (int n = 0; n <= router3AXCAM.CamData.EntitiesG1.Count - 1; n++)
					{
						Entity copiedEntity4 = null;
						buEntity.Copy(router3AXCAM.CamData.EntitiesG1[n], ref copiedEntity4);
						((CustomData)copiedEntity4.EntityData).typeDefination = entityTypeDefination.CamG1;
						((CustomData)copiedEntity4.EntityData).RefIndex = k;
						copiedEntity4.Color = varRouter3AXDisplaySettings.colorCamG1.Color;
						copiedEntity4.LineWeight = (float)varRouter3AXDisplaySettings.colorCamG1.Thickess;
						copiedEntity4.ColorMethod = colorMethodType.byEntity;
						copiedEntity4.LineWeightMethod = colorMethodType.byEntity;
						copiedEntity4.Selectable = false;
						copiedEntity4.LayerName = layerName3;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity4);
					}
				}
				if (clsVar.varCam.ShowCamLeaveDrawings)
				{
					for (int num = 0; num <= router3AXCAM.CamData.EntitiesLeave.Count - 1; num++)
					{
						Entity copiedEntity5 = null;
						buEntity.Copy(router3AXCAM.CamData.EntitiesLeave[num], ref copiedEntity5);
						((CustomData)copiedEntity5.EntityData).typeDefination = entityTypeDefination.CamLeave;
						((CustomData)copiedEntity5.EntityData).RefIndex = k;
						copiedEntity5.Color = varRouter3AXDisplaySettings.colorCamLeave.Color;
						copiedEntity5.LineWeight = (float)varRouter3AXDisplaySettings.colorCamLeave.Thickess;
						copiedEntity5.ColorMethod = colorMethodType.byEntity;
						copiedEntity5.LineWeightMethod = colorMethodType.byEntity;
						copiedEntity5.Selectable = false;
						copiedEntity5.LayerName = layerName3;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity5);
					}
				}
				if (clsVar.varCam.ShowCamPlungeDrawings)
				{
					for (int num2 = 0; num2 <= router3AXCAM.CamData.EntitiesPlunge.Count - 1; num2++)
					{
						Entity copiedEntity6 = null;
						buEntity.Copy(router3AXCAM.CamData.EntitiesPlunge[num2], ref copiedEntity6);
						((CustomData)copiedEntity6.EntityData).typeDefination = entityTypeDefination.CamPlunge;
						((CustomData)copiedEntity6.EntityData).RefIndex = k;
						copiedEntity6.Color = varRouter3AXDisplaySettings.colorCamPlunge.Color;
						copiedEntity6.LineWeight = (float)varRouter3AXDisplaySettings.colorCamPlunge.Thickess;
						copiedEntity6.ColorMethod = colorMethodType.byEntity;
						copiedEntity6.LineWeightMethod = colorMethodType.byEntity;
						copiedEntity6.Selectable = false;
						copiedEntity6.LayerName = layerName3;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity6);
					}
				}
				if (clsVar.varCam.ShowCamLeadinDrawings)
				{
					for (int num3 = 0; num3 <= router3AXCAM.CamData.EntitiesLeadIn.Count - 1; num3++)
					{
						Entity copiedEntity7 = null;
						buEntity.Copy(router3AXCAM.CamData.EntitiesLeadIn[num3], ref copiedEntity7);
						((CustomData)copiedEntity7.EntityData).typeDefination = entityTypeDefination.CamLeadin;
						((CustomData)copiedEntity7.EntityData).RefIndex = k;
						copiedEntity7.Color = varRouter3AXDisplaySettings.colorCamLeadIn.Color;
						copiedEntity7.LineWeight = (float)varRouter3AXDisplaySettings.colorCamLeadIn.Thickess;
						copiedEntity7.ColorMethod = colorMethodType.byEntity;
						copiedEntity7.LineWeightMethod = colorMethodType.byEntity;
						copiedEntity7.Selectable = false;
						copiedEntity7.LayerName = layerName3;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity7);
					}
				}
				if (clsVar.varCam.ShowCamLeadOutDrawings)
				{
					for (int num4 = 0; num4 <= router3AXCAM.CamData.EntitiesLeadOut.Count - 1; num4++)
					{
						Entity copiedEntity8 = null;
						buEntity.Copy(router3AXCAM.CamData.EntitiesLeadOut[num4], ref copiedEntity8);
						((CustomData)copiedEntity8.EntityData).typeDefination = entityTypeDefination.CamLeadOut;
						((CustomData)copiedEntity8.EntityData).RefIndex = k;
						copiedEntity8.Color = varRouter3AXDisplaySettings.colorCamLeadOut.Color;
						copiedEntity8.LineWeight = (float)varRouter3AXDisplaySettings.colorCamLeadOut.Thickess;
						copiedEntity8.ColorMethod = colorMethodType.byEntity;
						copiedEntity8.LineWeightMethod = colorMethodType.byEntity;
						copiedEntity8.Selectable = false;
						copiedEntity8.LayerName = layerName3;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity8);
					}
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
		TreeView treeView = (TreeView)sender;
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)treeView.SelectedNode;
		switch (treeNodeSettings.Command)
		{
		case "Base":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				SelectedCamIndex = -1;
			}
			break;
		case "Stock":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				SelectedCamIndex = -1;
			}
			break;
		case "Cam":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				SelectedCamIndex = treeNodeSettings.ClassSubIndex;
			}
			break;
		case "Tool":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				SelectedCamIndex = treeNodeSettings.ClassSubIndex;
			}
			break;
		case "Info":
			if (treeNodeSettings.ClassIndex >= 0)
			{
				SelectedCamIndex = treeNodeSettings.ClassSubIndex;
			}
			break;
		}
		UpdateDrawJob(SelectedCamIndex);
	}

	public void JobUpdate()
	{
		try
		{
			if (clsItem.FrmRouter3AXJob == null)
			{
				return;
			}
			_ = AppLanguage.CadCamDynamic[114];
			_ = AppLanguage.CadCamDynamic[108];
			_ = AppLanguage.CadCamDynamic[107] + " - ";
			_ = AppLanguage.CadCamDynamic[106];
			_ = AppLanguage.CadCamDynamic[112];
			TreeNodeSettings treeNodeSettings = null;
			TreeNodeSettings treeNodeSettings2 = null;
			clsItem.FrmRouter3AXJob.tree_jobs.Nodes.Clear();
			string nodeText = clsInit.cRouter3AX.JobToString(activeJob);
			treeNodeSettings = new TreeNodeSettings(nodeText)
			{
				ImageIndex = 0,
				SelectedImageIndex = 0,
				Tag = "0",
				ClassIndex = 0,
				ClassSubIndex = -1,
				ClassSubSubIndex = -1,
				Command = "Base",
				Info = "",
				Checked = true
			};
			treeNodeSettings.NodeFont = new Font(string_1, 10f, FontStyle.Regular);
			treeNodeSettings.ForeColor = Color.Black;
			nodeText = clsInit.cRouter3AX.JobStockToString(activeJob);
			treeNodeSettings2 = new TreeNodeSettings(nodeText)
			{
				ImageIndex = 1,
				SelectedImageIndex = 1,
				Tag = "",
				ClassIndex = 0,
				ClassSubIndex = 0,
				ClassSubSubIndex = -1,
				Command = "Stock",
				Info = "Stock",
				Checked = true
			};
			treeNodeSettings2.NodeFont = new Font(string_1, 8f, FontStyle.Regular);
			treeNodeSettings2.ForeColor = Color.Black;
			treeNodeSettings.Nodes.Add(treeNodeSettings2);
			for (int i = 0; i <= activeJob.CamList.Count - 1; i++)
			{
				nodeText = clsInit.cRouter3AX.JobCamToString(activeJob.CamList[i]);
				TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings(nodeText)
				{
					ImageIndex = clsInit.cRouter3AX.JobCamToIndex(activeJob.CamList[i]),
					SelectedImageIndex = clsInit.cRouter3AX.JobCamToIndex(activeJob.CamList[i]),
					Tag = "",
					ClassIndex = 0,
					ClassSubIndex = i,
					ClassSubSubIndex = -1,
					Command = "Cam",
					Info = "Cam",
					Checked = true
				};
				if (!activeJob.CamList[i].Enable)
				{
					treeNodeSettings3.NodeFont = new Font(string_1, 8f, FontStyle.Strikeout);
					treeNodeSettings3.ForeColor = Color.Red;
				}
				else
				{
					treeNodeSettings3.NodeFont = new Font(string_1, 8f, FontStyle.Regular);
					treeNodeSettings3.ForeColor = Color.Black;
				}
				nodeText = clsInit.cRouter3AX.JobCamToolToString(activeJob.CamList[i].Tool);
				TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings(nodeText)
				{
					ImageIndex = clsInit.cRouter3AX.JobCamToolToIndex(activeJob.CamList[i].Tool),
					SelectedImageIndex = clsInit.cRouter3AX.JobCamToolToIndex(activeJob.CamList[i].Tool),
					Tag = "",
					ClassIndex = 0,
					ClassSubIndex = i,
					ClassSubSubIndex = -1,
					Command = "Tool",
					Info = "Tool",
					Checked = true
				};
				nodeText = clsInit.cRouter3AX.JobCamInfoToString(activeJob.CamList[i].CamPars);
				TreeNodeSettings node = new TreeNodeSettings(nodeText)
				{
					ImageIndex = clsInit.cRouter3AX.JobCamInfoToIndex(),
					SelectedImageIndex = clsInit.cRouter3AX.JobCamInfoToIndex(),
					Tag = "",
					ClassIndex = 0,
					ClassSubIndex = i,
					ClassSubSubIndex = -1,
					Command = "Info",
					Info = "Info",
					Checked = true
				};
				if (!activeJob.CamList[i].Enable)
				{
					treeNodeSettings4.NodeFont = new Font(string_1, 8f, FontStyle.Strikeout);
					treeNodeSettings4.ForeColor = Color.Red;
				}
				else
				{
					treeNodeSettings4.NodeFont = new Font(string_1, 8f, FontStyle.Regular);
					treeNodeSettings4.ForeColor = Color.Black;
				}
				treeNodeSettings3.Nodes.Add(treeNodeSettings4);
				treeNodeSettings3.Nodes.Add(node);
				treeNodeSettings.Nodes.Add(treeNodeSettings3);
			}
			clsItem.FrmRouter3AXJob.tree_jobs.Nodes.Add(treeNodeSettings);
			treeNodeSettings.Expand();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void JobCamEnableDisabe()
	{
		if (!((SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1)))
		{
			return;
		}
		if (!activeJob.CamList[SelectedCamIndex].Enable)
		{
			clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].NodeFont = new Font(string_1, 8f, FontStyle.Strikeout);
			clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].ForeColor = Color.Red;
			for (int i = 0; i <= clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].Nodes.Count - 1; i++)
			{
				clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].Nodes[i].NodeFont = new Font(string_1, 8f, FontStyle.Strikeout);
				clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].Nodes[i].ForeColor = Color.Red;
			}
		}
		else
		{
			clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].NodeFont = new Font(string_1, 8f, FontStyle.Regular);
			clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].ForeColor = Color.Black;
			for (int j = 0; j <= clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].Nodes.Count - 1; j++)
			{
				clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].Nodes[j].NodeFont = new Font(string_1, 8f, FontStyle.Regular);
				clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].Nodes[j].ForeColor = Color.Black;
			}
		}
		UpdateDrawJob(SelectedCamIndex);
	}

	public void JobCamName()
	{
		if ((SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1))
		{
			clsItem.FrmRouter3AXJob.tree_jobs.Nodes[0].Nodes[SelectedCamIndex + 1].Text = clsInit.cRouter3AX.JobCamToString(activeJob.CamList[SelectedCamIndex]);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buRouter3Ax.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buRouter3Ax.lng"));
			if (!fileInfo.Exists)
			{
				buLogVer5.addToLog("clsRouter3AX", "LoadLanguage", "Error", "File Missing");
				buString5.MessageBoxError("Router Language File Missing");
				return;
			}
			List<string> StringList = new List<string>();
			buFile.OpenFromFile(fileInfo.FullName, ref StringList);
			buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterStatus);
			buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterMessage);
			buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterCaptions);
			buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buRouter3AX.LangRouterCommands);
			buLogVer5.addToLog("clsRouter3AX", "LoadLanguage", "End");
			StringList.Clear();
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog("clsRouter3AX", "LoadLanguage", "Error", ex.Message);
			buException.throwException(ex, "LoadLanguage", ShowMessageBox: true, "");
		}
	}

	public void SaveRouter3XFile()
	{
		string fileName = AppPath.Settings + "\\Router\\Router3X.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("  Router 3X Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<varRouter3AXSettings>");
		arrayList.AddRange(varRouter3AXSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</varRouter3AXSettings>");
		arrayList.Add("<varRouter3AXRunSettings>");
		arrayList.AddRange(varRouter3AXRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</varRouter3AXRunSettings>");
		arrayList.Add("<varRouter3AXDisplaySettings>");
		arrayList.AddRange(varRouter3AXDisplaySettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</varRouter3AXDisplaySettings>");
		buFile5.SaveToFile(arrayList, fileName);
		buLogVer5.addToLog("clsRouter3AX", "SavePipeBendingFile", "End");
		buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutCenter.bin");
		buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutInside.bin");
		buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutOutside.bin");
		buMWRouter3XVars.varCamWireframeCompCutting.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompCutting.bin");
		buMWRouter3XVars.varCamWireframeCompGrove.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompGrove.bin");
		buMWRouter3XVars.varCamWireframeCompPocket.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompPocket.bin");
		buMWRouter3XVars.varCamWireframeCompText.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCompText.bin");
		buMWRouter3XVars.varCamWireframeCenterPath.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeCenterPath.bin");
		buMWRouter3XVars.varCamWireframeChamfer.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeChamfer.bin");
		buMWRouter3XVars.varCamWireframeContour.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeContour.bin");
		buMWRouter3XVars.varCamWireframeDrill.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeDrill.bin");
		buMWRouter3XVars.varCamWireframeEngrave.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeEngrave.bin");
		buMWRouter3XVars.varCamWireframeFace.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeFace.bin");
		buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeFloorFinish.bin");
		buMWRouter3XVars.varCamWireframeRough.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeRough.bin");
		buMWRouter3XVars.varCamWireframeTextEngrave.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeTextEngrave.bin");
		buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.Serialize(AppPath.Settings + "\\Router\\mwWireframeTrochoidial.bin");
		buMWRouter3XVars.varCamMeshConstantCusp.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshConstantCusp.bin");
		buMWRouter3XVars.varCamMeshConstantZ.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshConstantZ.bin");
		buMWRouter3XVars.varCamMeshFlatLand.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshFlatLand.bin");
		buMWRouter3XVars.varCamMeshParallel.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshParallel.bin");
		buMWRouter3XVars.varCamMeshPencil.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshPencil.bin");
		buMWRouter3XVars.varCamMeshProjectCurves.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshProjectCurves.bin");
		buMWRouter3XVars.varCamMeshProjection.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshProjection.bin");
		buMWRouter3XVars.varCamMeshRotary.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshRotary.bin");
		buMWRouter3XVars.varCamMeshRough.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshRough.bin");
		buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshConstantZ5AX.bin");
		buMWRouter3XVars.varCamMeshParallel5AX.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshParallel5AX.bin");
		buMWRouter3XVars.varCamMeshRough5AX.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshRough5AX.bin");
		buMWRouter3XVars.varCamSurfaceParallel.mwPar.Serialize(AppPath.Settings + "\\Router\\mwMeshSurface5AX.bin");
		string fileName2 = AppPath.Settings + "\\Router\\Router3XCam.bucamset";
		arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Cam Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<BuCamSettings>");
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.ToDefAll("_varCamWireframeCompCutCenter", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCompCutInside.buPar.ToDefAll("_varCamWireframeCompCutInside", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.ToDefAll("_varCamWireframeCompCutOutside", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCompCutting.buPar.ToDefAll("_varCamWireframeCompCutting", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCompGrove.buPar.ToDefAll("_varCamWireframeCompGrove", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCompPocket.buPar.ToDefAll("_varCamWireframeCompPocket", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCompText.buPar.ToDefAll("_varCamWireframeCompText", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeCenterPath.buPar.ToDefAll("_varCamWireframeCenterPath", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeChamfer.buPar.ToDefAll("_varCamWireframeChamfer", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeContour.buPar.ToDefAll("_varCamWireframeContour", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeDrill.buPar.ToDefAll("_varCamWireframeDrill", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeEngrave.buPar.ToDefAll("_varCamWireframeEngrave", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeFace.buPar.ToDefAll("_varCamWireframeFace", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeFloorFinish.buPar.ToDefAll("_varCamWireframeFloorFinish", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeRough.buPar.ToDefAll("_varCamWireframeRough", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeTextEngrave.buPar.ToDefAll("_varCamWireframeTextEngrave", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamWireframeTrochoidial.buPar.ToDefAll("_varCamWireframeTrochoidial", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshConstantCusp.buPar.ToDefAll("_varCamMeshConstantCusp", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshConstantZ.buPar.ToDefAll("_varCamMeshConstantZ", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshFlatLand.buPar.ToDefAll("_varCamMeshFlatLand", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshParallel.buPar.ToDefAll("_varCamMeshParallel", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshPencil.buPar.ToDefAll("_varCamMeshPencil", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshProjectCurves.buPar.ToDefAll("_varCamMeshProjectCurves", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshProjection.buPar.ToDefAll("_varCamMeshProjection", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshRotary.buPar.ToDefAll("_varCamMeshRotary", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshRough.buPar.ToDefAll("_varCamMeshRough", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshParallel5AX.buPar.ToDefAll("_varCamMeshParallel5AX", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshConstantZ5AX.buPar.ToDefAll("_varCamMeshConstantZ5AX", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamMeshRough5AX.buPar.ToDefAll("_varCamMeshRough5AX", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRouter3XVars.varCamSurfaceParallel.buPar.ToDefAll("_varCamSurfaceParallel5AX", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</BuCamSettings>");
		buFile5.SaveToFile(arrayList, fileName2);
	}

	public void OpenRouter3Xile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Router\\Router3X.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				buLogVer5.addToLog("clsRouter3AX", "OpenPipeBendingFile", "Error", "Router 3AX Settings File Mising");
				buString.MessageBoxError("Router 3AX  Settings File Missing");
			}
			else
			{
				arrayList = new ArrayList();
				buFile5.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<varRouter3AXSettings>", "</varRouter3AXSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, varRouter3AXSettings);
						buLogVer5.addToLog("clsRouter3AX", "OpenPipeBendingFile", "Ok", "varRouter3AXSettings");
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varRouter3AXRunSettings>", "</varRouter3AXRunSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, varRouter3AXRunSettings);
						buLogVer5.addToLog("clsRouter3AX", "OpenPipeBendingFile", "Ok", "varRouter3AXRunSettings");
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varRouter3AXDisplaySettings>", "</varRouter3AXDisplaySettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, varRouter3AXDisplaySettings);
						buLogVer5.addToLog("clsRouter3AX", "OpenPipeBendingFile", "Ok", "varRouter3AXDisplaySettings");
					}
				}
				catch (Exception mSException)
				{
					buLogVer5.addToLog("clsRouter3AX", "OpenPipeBendingFile", "Error", "Router 3AX Settings Decoder Error");
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Laser Settings Decoder Error");
				}
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenPipeBendingFile", "End");
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "Setting File Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutCenter.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCompCutCenter Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutInside.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCompCutInside Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutOutside.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCompCutOutside Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompCutting.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCompCutting.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCompCutting Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompGrove.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCompGrove.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCompGrove Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompPocket.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCompPocket.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCompPocket Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCompText.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCompText.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCompText Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeCenterPath.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeCenterPath.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeCenterPath Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeChamfer.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeChamfer.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeChamfer Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeContour.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeContour.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeContour Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeDrill.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeDrill.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeDrill Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeEngrave.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeEngrave.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeEngrave Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeFace.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeFace.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeFace Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeFloorFinish.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeFloorFinish.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeFloorFinish Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeRough.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeRough.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeRough Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwWireframeTrochoidial.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamWireframeTrochoidial.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwWireframeTrochoidial Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshConstantCusp.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshConstantCusp.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshConstantCusp Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshConstantZ.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshConstantZ.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshConstantZ Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshFlatLand.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshFlatLand.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshFlatLand Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshParallel.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshParallel.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshParallel Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshPencil.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshPencil.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshPencil Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshProjectCurves.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshProjectCurves.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshProjectCurves Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshProjection.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshProjection.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshProjection Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshRotary.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshRotary.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshRotary Decoded");
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshRough.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshRough.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshConstantZ5AX.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshParallel5AX.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshParallel5AX.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshRough5AX.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamMeshRough5AX.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Router\\mwMeshSurface5AX.bin");
			if (fileInfo.Exists)
			{
				buMWRouter3XVars.varCamSurfaceParallel.mwPar.Deserialize(fileInfo.FullName);
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Ok", "MW Bin mwMeshRough Decoded");
			string fileName2 = AppPath.Settings + "\\Router\\Router3XCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Error", "MW Router Cam Settings File Missing");
				buString.MessageBoxError("Router Cam Settings File Missing");
			}
			else
			{
				arrayList = new ArrayList();
				buFile5.OpenFromFile(fileName2, ref arrayList);
				try
				{
					ArrayList CalcList2 = new ArrayList();
					buString.ListToSpecificList("<BuCamSettings>", "</BuCamSettings>", AddStartEndKey: true, arrayList, ref CalcList2);
					if (CalcList2.Count > 0)
					{
						buSerilization5.Decode(arrayList, "_varCamWireframeCompCutCenter", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCompCutCenter.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeCompCutInside", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCompCutInside.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeCompCutOutside", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCompCutOutside.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeCompCutting", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCompCutting.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeCompGrove", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCompGrove.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeCompPocket", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCompPocket.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeCompText", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCompText.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeCenterPath", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeCenterPath.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeChamfer", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeChamfer.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeContour", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeContour.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeDrill", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeDrill.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeEngrave", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeEngrave.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeFace", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeFace.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeFloorFinish", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeFloorFinish.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeRough", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeRough.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeTextEngrave", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeTextEngrave.buPar);
						buSerilization5.Decode(arrayList, "_varCamWireframeTrochoidial", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamWireframeTrochoidial.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshConstantCusp", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshConstantCusp.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshConstantZ", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshConstantZ.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshFlatLand", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshFlatLand.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshParallel", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshParallel.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshPencil", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshPencil.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshProjectCurves", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshProjectCurves.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshProjection", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshProjection.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshRotary", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshRotary.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshRough", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshRough.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshParallel5AX", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshParallel5AX.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshConstantZ5AX", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshConstantZ5AX.buPar);
						buSerilization5.Decode(arrayList, "_varCamMeshRough5AX", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamMeshRough5AX.buPar);
						buSerilization5.Decode(arrayList, "_varCamSurfaceParallel5AX", SerilizationMode5.MultiLine, buMWRouter3XVars.varCamSurfaceParallel.buPar);
					}
				}
				catch (Exception mSException2)
				{
					buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "Error", "MW Router Cam Settings Decoder Error");
					buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Router Settings Decoder Error");
				}
			}
			buLogVer5.addToLog("clsRouter3AX", "OpenRouter3Xile", "End");
		}
		catch (Exception mSException3)
		{
			buLogVer5.addToLog("clsRouter3AX", "OpenPipeBendingFile", "Error", "Router 3AX Settings Decoder Error");
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Router 3AX  Settings Decoder Error");
		}
	}

	public void General_Tick(object sender, EventArgs e)
	{
		countGeneral++;
		if (AppBool.Save && countGeneral % 100 == 0)
		{
			SaveRouter3XFile();
			clsFiles.SaveParameter();
			AppBool.Save = false;
		}
		if (countGeneral > 10000000)
		{
			countGeneral = 0;
		}
	}

	public void doNewPage()
	{
		cmdNewJob();
		clsNesting.varTemps.layerPart = varTemps.layerPart;
		clsNesting.varTemps.layerSheet = varTemps.layerSheet;
		clsNesting.varTemps.layerWireframe = varTemps.layerWireframe;
	}

	public void doReset()
	{
		MWCalcOptions.Editing = false;
	}

	public void doOpenPage()
	{
	}

	public void doCamFromNesting(buNestedResultEventArg NestResult)
	{
		int num = NestResult.SelectedSheet;
		if (NestResult.ResultSheetType == nestedCreateSheetType.All)
		{
			num = -1;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
		if (NestResult.ResultCreateType == nestedCreateType.Draw)
		{
			clsInit.appNesting.doDrawAllNesting(NestResult.nestedResult, num, -1, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: true, isPreview: false);
		}
		if (!NestResult.DoCam)
		{
			return;
		}
		if (activeJob != null)
		{
			activeJob.CamList.Clear();
		}
		if (num != -1)
		{
			if ((num >= 0) & (num <= NestResult.nestedResult.NestedResultSheets.Count - 1))
			{
				buNestedSheet sheet = NestResult.nestedResult.NestedResultSheets[num];
				CreateSheetCam(sheet);
			}
			return;
		}
		if (NestResult.ResultCreateType == nestedCreateType.SaveFile)
		{
			bool flag = true;
			if (varRouter3AXSettings.DualTable)
			{
				flag = false;
				frmTableSelection.Properties.FormCloseMode = FormCloseModeType.Invisible;
				frmTableSelection.Properties.FormPosition = FormStartPosition.CenterScreen;
				frmTableSelection.CamTable = varRouter3AXSettings.TableType;
				frmTableSelection.Init();
				frmTableSelection.ShowDialog();
				if (frmTableSelection.Properties.Result == DialogResult.OK)
				{
					varRouter3AXSettings.TableType = frmTableSelection.CamTable;
					flag = true;
				}
			}
			if (flag)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
				saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					JobList = new List<Router3AXItem>();
					for (int i = 0; i <= NestResult.nestedResult.NestedResultSheets.Count - 1; i++)
					{
						activeJob = new Router3AXItem();
						buNestedSheet sheet2 = NestResult.nestedResult.NestedResultSheets[i];
						CreateSheetCam(sheet2);
						JobList.Add(activeJob);
					}
					clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
					clsFiles.SaveParameter();
					if (clsVar.appDefination.CustomerID == AppCustomerID.Yilmaz && cModeYilmaz != null)
					{
						cModeYilmaz.CodeFromList(JobList, saveFileDialog.FileName);
					}
					if (clsVar.appDefination.CustomerID == AppCustomerID.CMD && cModeCMD != null)
					{
						cModeCMD.CodeFromList(JobList, saveFileDialog.FileName);
					}
					if (clsVar.appDefination.CustomerID == AppCustomerID.Infinite && cModeInfinite != null)
					{
						cModeInfinite.CodeFromList(JobList, saveFileDialog.FileName);
					}
					for (int j = 0; j <= JobList.Count - 1; j++)
					{
						if (j <= NestResult.nestedResult.NestedResultSheets.Count - 1 && JobList[j].GCodeResult != null)
						{
							NestResult.nestedResult.NestedResultSheets[j].GCodeResult = new MachineGCodeExecutionResult(JobList[j].GCodeResult);
						}
					}
				}
			}
		}
		if (clsItem.FrmProgress != null)
		{
			clsItem.FrmProgress.Visible = false;
		}
	}

	public void CreateSheetCam(buNestedSheet Sheet)
	{
		if (activeJob == null || Sheet.Parts.Count <= 0)
		{
			return;
		}
		activeJob.Stock = new CamStock();
		activeJob.Stock.SizeStock = new SizeObject(Sheet.MaterialWidth, Sheet.MaterialHeight, Sheet.MaterialThickness);
		activeJob.Stock.StockName = buLangTranslate.preDef.Nesting + " " + buLangTranslate.preDef.Sheet;
		activeJob.Stock.MinPoint = new Point3D();
		activeJob.Stock.MaxPoint = new Point3D(Sheet.MaterialWidth, Sheet.MaterialHeight, Sheet.MaterialThickness);
		for (int i = 0; i <= varRouter3AXRunSettings.SequenceList.Count - 1; i++)
		{
			List<buEntitiesGroup> Entities = new List<buEntitiesGroup>();
			EnumConverter enumConverter = new EnumConverter(typeof(Router3AXLayerPurpose));
			Router3AXLayerPurpose router3AXLayerPurpose = (Router3AXLayerPurpose)enumConverter.ConvertFromString(varRouter3AXRunSettings.SequenceList[i]);
			List<ToolBase5> Tools = new List<ToolBase5>();
			FindToolsFromPurpose(router3AXLayerPurpose, ref Tools);
			if (Tools.Count <= 0)
			{
				continue;
			}
			for (int j = 0; j <= Tools.Count - 1; j++)
			{
				FindEntitiesFromSequenceType(Tools[j], Sheet, ref Entities);
				if (Entities.Count <= 0)
				{
					continue;
				}
				List<EntitiesList> list = new List<EntitiesList>();
				for (int k = 0; k <= Entities.Count - 1; k++)
				{
					if (Entities[k].Outside != null && Entities[k].Outside.Entities.Count > 0)
					{
						EntitiesList entitiesList = new EntitiesList();
						buEntity.Add(Entities[k].Outside.Entities, ref entitiesList.Entities);
						list.Add(entitiesList);
					}
					if (Entities[k].Inside != null && Entities[k].Inside.Count > 0)
					{
						for (int l = 0; l <= Entities[k].Inside.Count - 1; l++)
						{
							EntitiesList entitiesList2 = new EntitiesList();
							buEntity.Add(Entities[k].Inside[l].Entities, ref entitiesList2.Entities);
							list.Add(entitiesList2);
						}
					}
					if (Entities[k].OpenEntities != null && Entities[k].OpenEntities.Count > 0)
					{
						EntitiesList entitiesList3 = new EntitiesList();
						for (int m = 0; m <= Entities[k].OpenEntities.Count - 1; m++)
						{
							buEntity.Add(Entities[k].OpenEntities[m].Entities, ref entitiesList3.Entities);
						}
						list.Add(entitiesList3);
					}
				}
				if (list.Count > 0)
				{
					if (router3AXLayerPurpose == Router3AXLayerPurpose.Derz || router3AXLayerPurpose == Router3AXLayerPurpose.CenterCut || router3AXLayerPurpose == Router3AXLayerPurpose.Text)
					{
						doWireframeCenterPath(router3AXLayerPurpose, Tools[j], list, router3AXLayerPurpose.ToString());
					}
					if (router3AXLayerPurpose == Router3AXLayerPurpose.Cutting || router3AXLayerPurpose == Router3AXLayerPurpose.OutsideCut)
					{
						doWireframeContour(router3AXLayerPurpose, Tools[j], list, router3AXLayerPurpose.ToString());
					}
					if (router3AXLayerPurpose == Router3AXLayerPurpose.InsideCut)
					{
						doWireframeContour(router3AXLayerPurpose, Tools[j], list, router3AXLayerPurpose.ToString());
					}
					if (router3AXLayerPurpose == Router3AXLayerPurpose.PocketOffset)
					{
						doWireframePocket(router3AXLayerPurpose, Tools[j], list, router3AXLayerPurpose.ToString());
					}
					if (router3AXLayerPurpose == Router3AXLayerPurpose.PocketParalel)
					{
						doWireframePocket(router3AXLayerPurpose, Tools[j], list, router3AXLayerPurpose.ToString());
					}
					if (router3AXLayerPurpose == Router3AXLayerPurpose.Drill)
					{
						doDrill(router3AXLayerPurpose, Tools[j], list, router3AXLayerPurpose.ToString());
					}
				}
			}
		}
	}

	public void FindEntitiesFromSequenceType(ToolBase5 Tool, buNestedSheet Sheet, ref List<buEntitiesGroup> Entities)
	{
		if (Tool == null)
		{
			return;
		}
		Entities = new List<buEntitiesGroup>();
		for (int i = 0; i <= Sheet.Parts.Count - 1; i++)
		{
			buEntitiesGroup buEntitiesGroup2 = new buEntitiesGroup();
			bool flag = false;
			if (Sheet.Parts[i].EntitiesGroup.Outside != null && Sheet.Parts[i].EntitiesGroup.Outside.Entities.Count > 0)
			{
				buEntitiesGroup2.Outside = new buEntityList();
				for (int j = 0; j <= Sheet.Parts[i].EntitiesGroup.Outside.Entities.Count - 1; j++)
				{
					buEntity buEntity2 = Sheet.Parts[i].EntitiesGroup.Outside.Entities[j];
					if (buEntity2.ToolName.Trim() == Tool.Data.Name.Trim())
					{
						buEntitiesGroup2.Outside.Entities.Add(buEntity.Copy(buEntity2));
						flag = true;
					}
				}
			}
			if (Sheet.Parts[i].EntitiesGroup.Text != null && Sheet.Parts[i].EntitiesGroup.Text.Entities.Count > 0)
			{
				buEntitiesGroup2.Text = new buEntityList();
				for (int k = 0; k <= Sheet.Parts[i].EntitiesGroup.Text.Entities.Count - 1; k++)
				{
					buEntity buEntity3 = Sheet.Parts[i].EntitiesGroup.Text.Entities[k];
					if (buEntity3.ToolName.Trim() == Tool.Data.Name.Trim())
					{
						buEntitiesGroup2.Text.Entities.Add(buEntity.Copy(buEntity3));
						flag = true;
					}
				}
			}
			if (Sheet.Parts[i].EntitiesGroup.Inside != null && Sheet.Parts[i].EntitiesGroup.Inside.Count > 0)
			{
				buEntitiesGroup2.Inside = new List<buEntityList>();
				for (int l = 0; l <= Sheet.Parts[i].EntitiesGroup.Inside.Count - 1; l++)
				{
					buEntityList buEntityList2 = new buEntityList();
					for (int m = 0; m <= Sheet.Parts[i].EntitiesGroup.Inside[l].Entities.Count - 1; m++)
					{
						buEntity buEntity4 = Sheet.Parts[i].EntitiesGroup.Inside[l].Entities[m];
						if (buEntity4.ToolName.Trim() == Tool.Data.Name.Trim())
						{
							buEntityList2.Entities.Add(buEntity.Copy(buEntity4));
							flag = true;
						}
					}
					if (buEntityList2.Entities.Count > 0)
					{
						buEntitiesGroup2.Inside.Add(buEntityList2);
					}
				}
			}
			if (Sheet.Parts[i].EntitiesGroup.OpenEntities != null && Sheet.Parts[i].EntitiesGroup.OpenEntities.Count > 0)
			{
				buEntitiesGroup2.OpenEntities = new List<buEntityList>();
				for (int n = 0; n <= Sheet.Parts[i].EntitiesGroup.OpenEntities.Count - 1; n++)
				{
					buEntityList buEntityList3 = new buEntityList();
					for (int num = 0; num <= Sheet.Parts[i].EntitiesGroup.OpenEntities[n].Entities.Count - 1; num++)
					{
						buEntity buEntity5 = Sheet.Parts[i].EntitiesGroup.OpenEntities[n].Entities[num];
						if (buEntity5.ToolName.Trim() == Tool.Data.Name.Trim())
						{
							buEntityList3.Entities.Add(buEntity.Copy(buEntity5));
							flag = true;
						}
					}
					if (buEntityList3.Entities.Count > 0)
					{
						buEntitiesGroup2.OpenEntities.Add(buEntityList3);
					}
				}
			}
			if (flag)
			{
				Entities.Add(buEntitiesGroup2);
			}
		}
	}

	public void FindToolsFromPurpose(Router3AXLayerPurpose LayerPurpose, ref List<ToolBase5> Tools)
	{
		Tools = new List<ToolBase5>();
		for (int i = 0; i <= ccVars.Tools.Count - 1; i++)
		{
			for (int j = 0; j <= ccVars.Tools[i].Tools.Count - 1; j++)
			{
				if (LayerPurpose == Router3AXLayerPurpose.Derz && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.Derz)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.CenterCut && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.CutCenter)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.Cutting && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.Cutting)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.Drill && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.Drilling)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.Engrave && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.Engrave)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.InsideCut && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.CutIn)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.OutsideCut && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.CutOut)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.PocketOffset && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.PocketCircular)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.PocketParalel && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.PocketFlat)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
				if (LayerPurpose == Router3AXLayerPurpose.Text && ccVars.Tools[i].Tools[j].Purpose == ToolPurpose.Text)
				{
					Tools.Add(new ToolBase5(ccVars.Tools[i].Tools[j]));
				}
			}
		}
	}

	public void doCamDelete()
	{
		if (!((SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1)))
		{
			buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
		}
		else if (buString5.MessageBoxQuestion(buRouter3AX.LangRouterMessage[0]) == DialogResult.Yes)
		{
			activeJob.CamList.RemoveAt(SelectedCamIndex);
			SelectedCamIndex = -1;
			JobUpdate();
			DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
			if ((SelectedCamIndex >= 0) & (SelectedCamIndex <= ccVars.Pages[ccVars.PageIndex].Cams.Count - 1))
			{
				ccVars.Pages[ccVars.PageIndex].Cams.RemoveAt(SelectedCamIndex);
			}
			UpdateDrawJob(SelectedCamIndex);
		}
	}

	public void doCamDeleteAll()
	{
		if (ccVars.Pages.Count != 0 && buString5.MessageBoxQuestion(buRouter3AX.LangRouterMessage[2]) == DialogResult.Yes)
		{
			activeJob.CamList.Clear();
			ccVars.Pages[ccVars.PageIndex].Cams.Clear();
			SelectedCamIndex = -1;
			JobUpdate();
			DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		}
	}

	public void doCamEnableDisable()
	{
		if (!((SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1)))
		{
			buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
		}
		else if (activeJob.CamList[SelectedCamIndex].Enable)
		{
			activeJob.CamList[SelectedCamIndex].Enable = false;
			JobCamEnableDisabe();
			UpdateDrawJob(SelectedCamIndex);
		}
		else
		{
			activeJob.CamList[SelectedCamIndex].Enable = true;
			JobCamEnableDisabe();
			UpdateDrawJob(SelectedCamIndex);
		}
	}

	public void doCamEdit()
	{
		if (!((SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1)))
		{
			buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
			return;
		}
		if (!activeJob.CamList[SelectedCamIndex].Enable)
		{
			buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[3]);
			return;
		}
		MWCalcOptions.Editing = true;
		if (activeJob.CamList[SelectedCamIndex].camMode == CamMode.WireFrame)
		{
			if (activeJob.CamList[SelectedCamIndex].camWireframeType == CamWireFrameType.Contour)
			{
				doWireframeContour(activeJob.CamList[SelectedCamIndex].Purpose, activeJob.CamList[SelectedCamIndex].Tool);
			}
			if (activeJob.CamList[SelectedCamIndex].camWireframeType == CamWireFrameType.Pocket)
			{
				doWireframePocket(activeJob.CamList[SelectedCamIndex].Purpose, activeJob.CamList[SelectedCamIndex].Tool);
			}
			if (activeJob.CamList[SelectedCamIndex].camWireframeType == CamWireFrameType.CenterPath)
			{
				doWireframeCenterPath(activeJob.CamList[SelectedCamIndex].Purpose, activeJob.CamList[SelectedCamIndex].Tool);
			}
		}
	}

	public void doCamToolEdit()
	{
		if (!((SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1)))
		{
			buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
			return;
		}
		if (!activeJob.CamList[SelectedCamIndex].Enable)
		{
			buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[3]);
			return;
		}
		ToolBase5 Tool = activeJob.CamList[SelectedCamIndex].Tool;
		if (!clsInit.appCommand.cmdToolSelect(ref Tool))
		{
			return;
		}
		MWCalcOptions.Editing = true;
		activeJob.CamList[SelectedCamIndex].Tool = Tool;
		if (activeJob.CamList[SelectedCamIndex].camMode == CamMode.WireFrame)
		{
			if (activeJob.CamList[SelectedCamIndex].camWireframeType == CamWireFrameType.Contour)
			{
				doWireframeContour(activeJob.CamList[SelectedCamIndex].Purpose, activeJob.CamList[SelectedCamIndex].Tool);
			}
			if (activeJob.CamList[SelectedCamIndex].camWireframeType == CamWireFrameType.Pocket)
			{
				doWireframePocket(activeJob.CamList[SelectedCamIndex].Purpose, activeJob.CamList[SelectedCamIndex].Tool);
			}
			if (activeJob.CamList[SelectedCamIndex].camWireframeType == CamWireFrameType.CenterPath)
			{
				doWireframeCenterPath(activeJob.CamList[SelectedCamIndex].Purpose, activeJob.CamList[SelectedCamIndex].Tool);
			}
		}
	}

	public void doCamRename()
	{
		if (activeJob == null || activeJob.CamList.Count <= 0)
		{
			return;
		}
		if (!((SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1)))
		{
			buString5.MessageBoxInfo(buRouter3AX.LangRouterMessage[1]);
			return;
		}
		DialogBoxText dialogBoxText = new DialogBoxText();
		dialogBoxText.Caption = buLangTranslate.preDef.Rename + " " + buLangTranslate.preDef.Cam;
		dialogBoxText.Text = buLangTranslate.preDef.Rename + " " + buLangTranslate.preDef.Cam;
		dialogBoxText.Init(activeJob.CamList[SelectedCamIndex].CamName);
		dialogBoxText.ShowDialog();
		if (dialogBoxText.Result == DialogResult.OK)
		{
			activeJob.CamList[SelectedCamIndex].CamName = dialogBoxText.Value;
			JobCamName();
		}
	}

	public void doCamMoveUp()
	{
		if ((activeJob.CamList.Count > 0) & (SelectedCamIndex > 0) & (SelectedCamIndex <= activeJob.CamList.Count - 1))
		{
			Router3AXCAM item = activeJob.CamList[SelectedCamIndex];
			activeJob.CamList.RemoveAt(SelectedCamIndex);
			SelectedCamIndex--;
			activeJob.CamList.Insert(SelectedCamIndex, item);
			JobUpdate();
		}
	}

	public void doCamMoveDown()
	{
		if ((activeJob.CamList.Count > 0) & (SelectedCamIndex >= 0) & (SelectedCamIndex <= activeJob.CamList.Count - 2))
		{
			Router3AXCAM item = activeJob.CamList[SelectedCamIndex];
			activeJob.CamList.RemoveAt(SelectedCamIndex);
			SelectedCamIndex++;
			activeJob.CamList.Insert(SelectedCamIndex, item);
			JobUpdate();
		}
	}

	public void doDrill(Router3AXLayerPurpose Purpose, ToolBase5 Tool, List<EntitiesList> EntGroup = null, string CamName = "")
	{
		if (activeJob == null)
		{
			activeJob = new Router3AXItem();
		}
		Router3AXCAM RouterCam = new Router3AXCAM();
		RouterCam.entitiesPlane = new Router3AXCamPlane();
		if (Purpose == Router3AXLayerPurpose.Drill)
		{
			buMWRouter3XVars.varCamWireframeDrill.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			buMWRouter3XVars.varCamWireframeDrill.buPar.Speeds.Plunge = Tool.CamData.PlungeSpeed;
			buMWRouter3XVars.varCamWireframeDrill.buPar.Operations.isClosed = true;
			buMWRouter3XVars.varCamWireframeDrill.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
			buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.RapidRetractFlg = true;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeDrill.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutting.mwPar, buMWRouter3XVars.varCamWireframeCompCutting.buPar, out clsMW.varbuCamWFContourPars);
		}
		camResult Result = null;
		clsMW.CamEntities.Clear();
		MWCalcOptions.UseSortedAndSplitedEntities = false;
		MWCalcOptions.HeightFromEntities = false;
		MWCalcOptions.CheckIsCLosedEntities = false;
		MWCalcOptions.CamMode = CamMode.Drill;
		if (EntGroup != null && EntGroup.Count > 0)
		{
			clsMW.CamEntitiesGroup.Clear();
			for (int i = 0; i <= EntGroup.Count - 1; i++)
			{
				List<Entity> list = new List<Entity>();
				for (int j = 0; j <= EntGroup[i].Entities.Count - 1; j++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(EntGroup[i].Entities[j], ref copiedEntity, CheckDuplicated: true, 0.01);
					if (copiedEntity != null)
					{
						list.Add(copiedEntity);
					}
					if (!(copiedEntity is Circle))
					{
						continue;
					}
					if (clsMW.CamEntities.Count != 0)
					{
						bool flag = true;
						for (int k = 0; k <= clsMW.CamEntities.Count - 1; k++)
						{
							Circle circle = clsMW.CamEntities[k] as Circle;
							if (buCompare5.EQ(circle.Center, ((Circle)copiedEntity).Center))
							{
								flag = false;
							}
						}
						if (flag)
						{
							clsMW.CamEntities.Add(copiedEntity);
						}
					}
					else
					{
						clsMW.CamEntities.Add(copiedEntity);
					}
				}
				if (list.Count <= 0)
				{
				}
			}
			if (clsMW.CamEntitiesGroup.Count > 0)
			{
				MWCalcOptions.DontShowbuDialogBox = true;
				MWCalcOptions.DontShowDialogBox = true;
				MWCalcOptions.UseSortedAndSplitedEntities = true;
			}
		}
		buMWRouter3XVars.varCamWireframeDrill.buPar.Runtime.SimG0DevideLength = 20.0;
		buMWRouter3XVars.varCamWireframeDrill.buPar.Runtime.SimG1DevideLength = 10.0;
		clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeDrill.mwPar, buMWRouter3XVars.varCamWireframeDrill.buPar, out clsMW.varbuCamDrillPars);
		clsMW.varbuCamDrillPars.Speeds.Plunge = Tool.CamData.PlungeSpeed;
		clsMW.varbuCamDrillPars.Speeds.Feed = Tool.CamData.FeedSpeed;
		clsMW.varbuCamDrillPars.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
		clsMW.varbuCamDrillPars.Drill.EndHeight = Tool.CamData.DepthConstant;
		clsMW.varMWCamDrillPars.MachParam.PlungeFeedRate = Tool.CamData.PlungeSpeed;
		MWCalcOptions.DontShowbuDialogBox = true;
		MWCalcOptions.DontShowDialogBox = true;
		ToolBase5 toolBase = new ToolBase5(Tool);
		toolBase.Purpose = ToolPurpose.Drilling;
		int num = clsInit.appMW.doDrill(MWCalcOptions, toolBase, ref RouterCam.CamData, ref Result);
		buMWRouter3XVars.varCamWireframeDrill.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWRouter3XVars.varCamWireframeDrill.buPar);
		buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeDrill.mwPar, ref buMWRouter3XVars.varCamWireframeDrill.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
			return;
		}
		if (CamName.Trim().Length > 0)
		{
			RouterCam.CamData.Name = CamName;
			RouterCam.CamName = CamName;
		}
		buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
		RouterCam.Tool = new ToolBase5(Tool);
		RouterCam.Purpose = Purpose;
		if (RouterCam.CamData != null && RouterCam.CamData.CamPoints.Count > 0)
		{
			clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
			doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
			RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeContour.buPar);
			doAddOrEditCam(RouterCam, MWCalcOptions.Editing);
		}
		JobUpdate();
		DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		UpdateDrawJob(SelectedCamIndex);
		SaveRouter3XFile();
		clsInit.appCommand.Reset();
	}

	public void doWireframeContour(Router3AXLayerPurpose Purpose, ToolBase5 Tool, List<EntitiesList> EntGroup = null, string CamName = "")
	{
		if (activeJob == null)
		{
			activeJob = new Router3AXItem();
		}
		Router3AXCAM RouterCam = new Router3AXCAM();
		RouterCam.entitiesPlane = new Router3AXCamPlane();
		if (Purpose != Router3AXLayerPurpose.Cutting)
		{
			if (Purpose != Router3AXLayerPurpose.OutsideCut)
			{
				if (Purpose != Router3AXLayerPurpose.InsideCut)
				{
					buMWRouter3XVars.varCamWireframeContour.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
					buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.RapidRetractFlg = true;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeContour.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeContour.mwPar, buMWRouter3XVars.varCamWireframeContour.buPar, out clsMW.varbuCamWFContourPars);
				}
				else
				{
					buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
					buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Operations.isClosed = true;
					buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Offsets.ClosedContour = CamClosedContourType.Inner;
					buMWRouter3XVars.varCamWireframeCompCutInside.buPar.Operations.Direction = ClockDirectionType.CW;
					buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.RapidRetractFlg = true;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutInside.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutInside.mwPar, buMWRouter3XVars.varCamWireframeCompCutInside.buPar, out clsMW.varbuCamWFContourPars);
				}
			}
			else
			{
				buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
				buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Operations.isClosed = true;
				buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Operations.Direction = ClockDirectionType.CW;
				buMWRouter3XVars.varCamWireframeCompCutOutside.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
				buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.RapidRetractFlg = true;
				((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutOutside.mwPar, buMWRouter3XVars.varCamWireframeCompCutOutside.buPar, out clsMW.varbuCamWFContourPars);
			}
		}
		else
		{
			buMWRouter3XVars.varCamWireframeCompCutting.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			buMWRouter3XVars.varCamWireframeCompCutting.buPar.Operations.isClosed = true;
			buMWRouter3XVars.varCamWireframeCompCutting.buPar.Offsets.ClosedContour = CamClosedContourType.Outter;
			buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.RapidRetractFlg = true;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutting.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutting.mwPar, buMWRouter3XVars.varCamWireframeCompCutting.buPar, out clsMW.varbuCamWFContourPars);
		}
		camResult Result = null;
		clsMW.CamEntities.Clear();
		MWCalcOptions.UseSortedAndSplitedEntities = false;
		MWCalcOptions.HeightFromEntities = false;
		MWCalcOptions.CheckIsCLosedEntities = false;
		MWCalcOptions.CamMode = CamMode.WireFrame;
		if (EntGroup != null && EntGroup.Count > 0)
		{
			clsMW.CamEntitiesGroup.Clear();
			for (int i = 0; i <= EntGroup.Count - 1; i++)
			{
				List<Entity> list = new List<Entity>();
				for (int j = 0; j <= EntGroup[i].Entities.Count - 1; j++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(EntGroup[i].Entities[j], ref copiedEntity, CheckDuplicated: true, 0.01);
					if (copiedEntity != null)
					{
						list.Add(copiedEntity);
					}
				}
				if (list.Count > 0)
				{
					clsMW.CamEntitiesGroup.Add(list);
				}
			}
			if (clsMW.CamEntitiesGroup.Count > 0)
			{
				MWCalcOptions.DontShowbuDialogBox = true;
				MWCalcOptions.DontShowDialogBox = true;
				MWCalcOptions.UseSortedAndSplitedEntities = true;
			}
		}
		if (MWCalcOptions.Editing)
		{
			if (activeJob.CamList[SelectedCamIndex].CamEntities.Count == 0)
			{
				return;
			}
			RouterCam = new Router3AXCAM(activeJob.CamList[SelectedCamIndex]);
			clsMW.CamEntities.Clear();
			buEntity.Copy(activeJob.CamList[SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
			RouterCam.CamData = new camTp();
			RouterCam.CamEntities.Clear();
			clsMW.varbuCamWFContourPars = new camParameters5(activeJob.CamList[SelectedCamIndex].CamPars);
		}
		int num = clsInit.appMW.doWireframeContour(MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
		buMWRouter3XVars.varCamWireframeContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWRouter3XVars.varCamWireframeContour.buPar);
		buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeContour.mwPar, ref buMWRouter3XVars.varCamWireframeContour.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
			return;
		}
		if (CamName.Trim().Length > 0)
		{
			RouterCam.CamData.Name = CamName;
			RouterCam.CamName = CamName;
		}
		buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
		RouterCam.Tool = new ToolBase5(Tool);
		RouterCam.Purpose = Purpose;
		if (RouterCam.CamData != null && RouterCam.CamData.CamPoints.Count > 0)
		{
			clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
			doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
			RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeContour.buPar);
			doAddOrEditCam(RouterCam, MWCalcOptions.Editing);
		}
		JobUpdate();
		DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		UpdateDrawJob(SelectedCamIndex);
		SaveRouter3XFile();
		clsInit.appCommand.Reset();
	}

	public void doWireframePocket(Router3AXLayerPurpose Purpose, ToolBase5 Tool, List<EntitiesList> EntGroup = null, string CamName = "")
	{
		if (activeJob == null)
		{
			activeJob = new Router3AXItem();
		}
		Router3AXCAM RouterCam = new Router3AXCAM();
		RouterCam.entitiesPlane = new Router3AXCamPlane();
		if (!(Purpose == Router3AXLayerPurpose.PocketOffset || Purpose == Router3AXLayerPurpose.PocketParalel))
		{
			buMWRouter3XVars.varCamWireframeRough.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.RapidRetractFlg = true;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			buMWRouter3XVars.varCamWireframeRough.mwPar.MachParam.MaxStepoverDistance = Tool.Geometry.Diameter * 0.8;
			clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeRough.mwPar, buMWRouter3XVars.varCamWireframeRough.buPar, out clsMW.varbuCamWFPocketPars);
		}
		else
		{
			buMWRouter3XVars.varCamWireframeCompPocket.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.RapidRetractFlg = true;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			buMWRouter3XVars.varCamWireframeCompPocket.mwPar.MachParam.MaxStepoverDistance = Tool.Geometry.Diameter * 0.8;
			clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompPocket.mwPar, buMWRouter3XVars.varCamWireframeCompPocket.buPar, out clsMW.varbuCamWFPocketPars);
		}
		camResult Result = null;
		clsMW.CamEntities.Clear();
		MWCalcOptions.UseSortedAndSplitedEntities = false;
		MWCalcOptions.HeightFromEntities = false;
		MWCalcOptions.CamMode = CamMode.WireFrame;
		if (EntGroup != null && EntGroup.Count > 0)
		{
			clsMW.CamEntitiesGroup.Clear();
			for (int i = 0; i <= EntGroup.Count - 1; i++)
			{
				List<Entity> list = new List<Entity>();
				for (int j = 0; j <= EntGroup[i].Entities.Count - 1; j++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(EntGroup[i].Entities[j], ref copiedEntity);
					if (copiedEntity != null)
					{
						list.Add(copiedEntity);
					}
				}
				if (list.Count > 0)
				{
					clsMW.CamEntitiesGroup.Add(list);
				}
			}
			if (clsMW.CamEntitiesGroup.Count > 0)
			{
				MWCalcOptions.DontShowbuDialogBox = true;
				MWCalcOptions.DontShowDialogBox = true;
				MWCalcOptions.UseSortedAndSplitedEntities = true;
			}
		}
		MWCalcOptions.ShowProgressForm = true;
		if (MWCalcOptions.Editing)
		{
			if (activeJob.CamList[SelectedCamIndex].CamEntities.Count == 0)
			{
				return;
			}
			RouterCam = new Router3AXCAM(activeJob.CamList[SelectedCamIndex]);
			clsMW.CamEntities.Clear();
			buEntity.Copy(activeJob.CamList[SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
			RouterCam.CamData = new camTp();
			RouterCam.CamEntities.Clear();
			clsMW.varbuCamWFContourPars = new camParameters5(activeJob.CamList[SelectedCamIndex].CamPars);
		}
		int num = clsInit.appMW.doWireframeContour(MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
		buMWRouter3XVars.varCamWireframeRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWRouter3XVars.varCamWireframeRough.buPar);
		buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeRough.mwPar, ref buMWRouter3XVars.varCamWireframeRough.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
			return;
		}
		if (CamName.Trim().Length > 0)
		{
			RouterCam.CamData.Name = CamName;
			RouterCam.CamName = CamName;
		}
		RouterCam.camWireframeType = MWCalcOptions.CamWireframeType;
		buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
		RouterCam.Purpose = Purpose;
		RouterCam.Tool = new ToolBase5(Tool);
		clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
		doPlaneCalculation(buMWRouter3XVars.varCamWireframeRough.buPar, ref RouterCam);
		RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeRough.buPar);
		doAddOrEditCam(RouterCam, MWCalcOptions.Editing);
		JobUpdate();
		DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		UpdateDrawJob(SelectedCamIndex);
		SaveRouter3XFile();
		clsInit.appCommand.Reset();
	}

	public void doWireframeCenterPath(Router3AXLayerPurpose Purpose, ToolBase5 Tool, List<EntitiesList> EntGroup = null, string CamName = "")
	{
		if (activeJob == null)
		{
			activeJob = new Router3AXItem();
		}
		Router3AXCAM RouterCam = new Router3AXCAM();
		RouterCam.entitiesPlane = new Router3AXCamPlane();
		if (Purpose != Router3AXLayerPurpose.Derz)
		{
			if (Purpose != Router3AXLayerPurpose.CenterCut)
			{
				if (Purpose != Router3AXLayerPurpose.Text)
				{
					buMWRouter3XVars.varCamWireframeCenterPath.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
					buMWRouter3XVars.varCamWireframeCenterPath.buPar.Offsets.OpenContour = CamOpenContourType.Center;
					buMWRouter3XVars.varCamWireframeCenterPath.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
					buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.RapidRetractFlg = true;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCenterPath.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCenterPath.mwPar, buMWRouter3XVars.varCamWireframeCenterPath.buPar, out clsMW.varbuCamWFContourPars);
				}
				else
				{
					buMWRouter3XVars.varCamWireframeCompText.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
					buMWRouter3XVars.varCamWireframeCompText.buPar.Offsets.OpenContour = CamOpenContourType.Center;
					buMWRouter3XVars.varCamWireframeCompText.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
					buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.RapidRetractFlg = true;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					buMWRouter3XVars.varCamWireframeCompText.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
					clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompText.mwPar, buMWRouter3XVars.varCamWireframeCompText.buPar, out clsMW.varbuCamWFContourPars);
				}
			}
			else
			{
				buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
				buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Offsets.OpenContour = CamOpenContourType.Center;
				buMWRouter3XVars.varCamWireframeCompCutCenter.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
				buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.RapidRetractFlg = true;
				((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
				clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompCutCenter.mwPar, buMWRouter3XVars.varCamWireframeCompCutCenter.buPar, out clsMW.varbuCamWFContourPars);
			}
		}
		else
		{
			buMWRouter3XVars.varCamWireframeCompGrove.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
			buMWRouter3XVars.varCamWireframeCompGrove.buPar.Offsets.OpenContour = CamOpenContourType.Center;
			buMWRouter3XVars.varCamWireframeCompGrove.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.RapidRetractFlg = true;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			((InterlinkHandeler)buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
			buMWRouter3XVars.varCamWireframeCompGrove.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamWireframeCompGrove.mwPar, buMWRouter3XVars.varCamWireframeCompGrove.buPar, out clsMW.varbuCamWFContourPars);
		}
		camResult Result = null;
		clsMW.CamEntities.Clear();
		MWCalcOptions.UseSortedAndSplitedEntities = false;
		MWCalcOptions.HeightFromEntities = false;
		MWCalcOptions.isBuWireframeCalculation = varRouter3AXSettings.BuCenterCalculation;
		MWCalcOptions.CamMode = CamMode.WireFrame;
		if (varRouter3AXSettings.BuCenterCalculation)
		{
			if (EntGroup != null && EntGroup.Count > 0)
			{
				List<buEntity> BaseRefEntities = new List<buEntity>();
				for (int i = 0; i <= EntGroup.Count - 1; i++)
				{
					for (int j = 0; j <= EntGroup[i].Entities.Count - 1; j++)
					{
						buEntity item = buEntity.Copy(EntGroup[i].Entities[j]);
						BaseRefEntities.Add(item);
					}
				}
				List<buEntity> SortedEntities = new List<buEntity>();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
				SortbuSettings sortbuSettings = new SortbuSettings();
				sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
				clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].StartPoint, ref BaseRefEntities, sortbuSettings, ref SortedEntities);
				List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
				clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
				if (SplitedEntitites.Count > 0)
				{
					clsMW.CamEntitiesGroup.Clear();
					for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
					{
						List<Entity> copiedEntities = new List<Entity>();
						buEntity.Copy(SplitedEntitites[k], ref copiedEntities);
						clsMW.CamEntitiesGroup.Add(copiedEntities);
					}
					MWCalcOptions.DontShowbuDialogBox = true;
					MWCalcOptions.DontShowDialogBox = true;
					MWCalcOptions.UseSortedAndSplitedEntities = true;
				}
			}
		}
		else if (EntGroup != null && EntGroup.Count > 0)
		{
			clsMW.CamEntitiesGroup.Clear();
			for (int l = 0; l <= EntGroup.Count - 1; l++)
			{
				List<Entity> list = new List<Entity>();
				for (int m = 0; m <= EntGroup[l].Entities.Count - 1; m++)
				{
					Entity copiedEntity = null;
					if (!(EntGroup[l].Entities[m] is buLinearPath))
					{
						buEntity.Copy(EntGroup[l].Entities[m], ref copiedEntity);
						if (copiedEntity != null)
						{
							list.Add(copiedEntity);
						}
						continue;
					}
					for (int n = 1; n <= EntGroup[l].Entities[m].Vertices.Count - 1; n++)
					{
						Line line = new Line(EntGroup[l].Entities[m].Vertices[n - 1], EntGroup[l].Entities[m].Vertices[n]);
						CustomData CD = new CustomData();
						buEntity.EntityToCustomData(EntGroup[l].Entities[m], ref CD);
						line.EntityData = CD;
						list.Add(line);
					}
				}
				if (list.Count > 0)
				{
					clsMW.CamEntitiesGroup.Add(list);
				}
			}
			if (clsMW.CamEntitiesGroup.Count > 0)
			{
				MWCalcOptions.DontShowbuDialogBox = true;
				MWCalcOptions.DontShowDialogBox = true;
				MWCalcOptions.UseSortedAndSplitedEntities = true;
			}
		}
		if (MWCalcOptions.Editing)
		{
			if (activeJob.CamList[SelectedCamIndex].CamEntities.Count == 0)
			{
				return;
			}
			RouterCam = new Router3AXCAM(activeJob.CamList[SelectedCamIndex]);
			clsMW.CamEntities.Clear();
			buEntity.Copy(activeJob.CamList[SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
			RouterCam.CamData = new camTp();
			RouterCam.CamEntities.Clear();
			clsMW.varbuCamWFContourPars = new camParameters5(activeJob.CamList[SelectedCamIndex].CamPars);
		}
		int num = clsInit.appMW.doWireframeContour(MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
		buMWRouter3XVars.varCamWireframeCenterPath.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWRouter3XVars.varCamWireframeCenterPath.buPar);
		buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamWireframeCenterPath.mwPar, ref buMWRouter3XVars.varCamWireframeCenterPath.buPar);
		if (!((num >= 1) & (RouterCam.CamData.CamPoints.Count > 0)))
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
			return;
		}
		if (CamName.Trim().Length > 0)
		{
			RouterCam.CamData.Name = CamName;
			RouterCam.CamName = CamName;
		}
		buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
		RouterCam.Purpose = Purpose;
		RouterCam.Tool = new ToolBase5(Tool);
		clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
		doPlaneCalculation(buMWRouter3XVars.varCamWireframeCenterPath.buPar, ref RouterCam);
		RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamWireframeCenterPath.buPar);
		doAddOrEditCam(RouterCam, MWCalcOptions.Editing);
		JobUpdate();
		DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		UpdateDrawJob(SelectedCamIndex);
		SaveRouter3XFile();
		clsInit.appCommand.Reset();
	}

	public void doTriangularMesh3AX(CamTriangularMeshType CamType, ToolBase5 Tool, List<EntitiesList> EntGroup = null, string CamName = "")
	{
		if (activeJob == null)
		{
			activeJob = new Router3AXItem();
		}
		Router3AXCAM RouterCam = new Router3AXCAM();
		RouterCam.entitiesPlane = new Router3AXCamPlane();
		if (CamType != CamTriangularMeshType.Rough)
		{
			if (CamType != CamTriangularMeshType.ParallelCuts)
			{
				if (CamType != CamTriangularMeshType.ConstantZ)
				{
					buString5.MessageBoxError(buLangTranslate.preDef.UnknownCam);
					return;
				}
				buMWRouter3XVars.varCamMeshConstantZ.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
				buMWRouter3XVars.varCamMeshConstantZ.mwPar.MachParam.RapidRetractFlg = true;
				clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshConstantZ.mwPar, buMWRouter3XVars.varCamMeshConstantZ.buPar, out clsMW.varbuCamMeshConstantZPars);
			}
			else
			{
				buMWRouter3XVars.varCamMeshParallel.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
				buMWRouter3XVars.varCamMeshParallel.mwPar.MachParam.RapidRetractFlg = true;
				clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshParallel.mwPar, buMWRouter3XVars.varCamMeshParallel.buPar, out clsMW.varbuCamMeshParallelPars);
			}
		}
		else
		{
			buMWRouter3XVars.varCamMeshRough.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			buMWRouter3XVars.varCamMeshRough.mwPar.MachParam.RapidRetractFlg = true;
			clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshRough.mwPar, buMWRouter3XVars.varCamMeshRough.buPar, out clsMW.varbuCamMeshRoughPars);
		}
		camResult Result = null;
		clsMW.CamEntities.Clear();
		MWCalcOptions.DontShowbuDialogBox = false;
		MWCalcOptions.CamMode = CamMode.TriangularMesh;
		if (MWCalcOptions.Editing)
		{
			if (activeJob.CamList[SelectedCamIndex].CamEntities.Count == 0)
			{
				return;
			}
			RouterCam = new Router3AXCAM(activeJob.CamList[SelectedCamIndex]);
			clsMW.CamEntities.Clear();
			buEntity.Copy(activeJob.CamList[SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
			RouterCam.CamData = new camTp();
			RouterCam.CamEntities.Clear();
			clsMW.varbuCamWFContourPars = new camParameters5(activeJob.CamList[SelectedCamIndex].CamPars);
		}
		int num = clsInit.appMW.doTriangularMesh3D(MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
		RouterCam.camMode = CamMode.TriangularMesh;
		RouterCam.camMeshType = CamType;
		if (CamType == CamTriangularMeshType.Rough)
		{
			buMWRouter3XVars.varCamMeshRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWRouter3XVars.varCamMeshRough.buPar);
			buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshRough.mwPar, ref buMWRouter3XVars.varCamMeshRough.buPar);
		}
		if (CamType == CamTriangularMeshType.ParallelCuts)
		{
			buMWRouter3XVars.varCamMeshParallel.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRouter3XVars.varCamMeshParallel.buPar);
			buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshParallel.mwPar, ref buMWRouter3XVars.varCamMeshParallel.buPar);
		}
		if (CamType == CamTriangularMeshType.ConstantZ)
		{
			buMWRouter3XVars.varCamMeshConstantZ.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRouter3XVars.varCamMeshConstantZ.buPar);
			buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshConstantZ.mwPar, ref buMWRouter3XVars.varCamMeshConstantZ.buPar);
		}
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
			return;
		}
		if (CamName.Trim().Length > 0)
		{
			RouterCam.CamData.Name = CamName;
			RouterCam.CamName = CamName;
		}
		buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
		RouterCam.Tool = new ToolBase5(Tool);
		RouterCam.Purpose = Router3AXLayerPurpose.None;
		clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
		doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
		if (CamType == CamTriangularMeshType.Rough)
		{
			RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamMeshRough.buPar);
		}
		if (CamType == CamTriangularMeshType.ParallelCuts)
		{
			RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamMeshParallel.buPar);
		}
		if (CamType == CamTriangularMeshType.ConstantZ)
		{
			RouterCam.CamPars = new camParameters5(buMWRouter3XVars.varCamMeshConstantZ.buPar);
		}
		doAddOrEditCam(RouterCam, MWCalcOptions.Editing);
		JobUpdate();
		DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		UpdateDrawJob(SelectedCamIndex);
		SaveRouter3XFile();
		clsInit.appCommand.Reset();
	}

	public void doTriangularMesh5AX(CamTriangularMesh5AxType CamType, ToolBase5 Tool, List<EntitiesList> EntGroup = null, string CamName = "")
	{
		if (activeJob == null)
		{
			activeJob = new Router3AXItem();
		}
		Router3AXCAM RouterCam = new Router3AXCAM();
		RouterCam.entitiesPlane = new Router3AXCamPlane();
		if (CamType != CamTriangularMesh5AxType.ParallelCuts)
		{
			if (CamType != CamTriangularMesh5AxType.ConstantZ)
			{
				if (CamType != CamTriangularMesh5AxType.Rough)
				{
					buString5.MessageBoxError(buLangTranslate.preDef.UnknownCam);
					return;
				}
				MWCalcOptions.CamTriMesh5AXType = CamTriangularMesh5AxType.Rough;
				buMWRouter3XVars.varCamMeshRough5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
				buMWRouter3XVars.varCamMeshRough5AX.mwPar.MachParam.RapidRetractFlg = true;
				clsMW.varMWCamMeshRough5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshRough5AX.mwPar, buMWRouter3XVars.varCamMeshRough5AX.buPar, out clsMW.varbuCamMeshRough5AXPars);
				RouterCam.camSurfType = CamSurfaceType.MeshRough;
				RouterCam.camMesh5AXType = CamTriangularMesh5AxType.Rough;
			}
			else
			{
				MWCalcOptions.CamTriMesh5AXType = CamTriangularMesh5AxType.ConstantZ;
				buMWRouter3XVars.varCamMeshConstantZ5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
				buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar.MachParam.RapidRetractFlg = true;
				clsMW.varMWCamMeshContantZ5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar, buMWRouter3XVars.varCamMeshConstantZ5AX.buPar, out clsMW.varbuCamMeshConstantZ5AXPars);
				RouterCam.camSurfType = CamSurfaceType.MeshConstantZ;
				RouterCam.camMesh5AXType = CamTriangularMesh5AxType.ConstantZ;
			}
		}
		else
		{
			MWCalcOptions.CamTriMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;
			buMWRouter3XVars.varCamMeshParallel5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			buMWRouter3XVars.varCamMeshParallel5AX.mwPar.MachParam.RapidRetractFlg = true;
			clsMW.varMWCamMeshParalel5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, buMWRouter3XVars.varCamMeshParallel5AX.buPar, out clsMW.varbuCamMeshParallel5AXPars);
			RouterCam.camSurfType = CamSurfaceType.MeshParalel;
			RouterCam.camMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;
		}
		camResult Result = null;
		clsMW.CamEntities.Clear();
		MWCalcOptions.DontShowbuDialogBox = false;
		if (MWCalcOptions.Editing)
		{
			if (activeJob.CamList[SelectedCamIndex].CamEntities.Count == 0)
			{
				return;
			}
			RouterCam = new Router3AXCAM(activeJob.CamList[SelectedCamIndex]);
			clsMW.CamEntities.Clear();
			buEntity.Copy(activeJob.CamList[SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
			RouterCam.CamData = new camTp();
			RouterCam.CamEntities.Clear();
			clsMW.varbuCamWFContourPars = new camParameters5(activeJob.CamList[SelectedCamIndex].CamPars);
		}
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.SmoothingFlg = true;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 30.0;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 150.0;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 30.0;
		clsMW.varMWCamMeshRough5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 150.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.SmoothingFlg = true;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 30.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 150.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 30.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 150.0;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.SmoothingFlg = true;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 30.0;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 150.0;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 30.0;
		clsMW.varMWCamMeshContantZ5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 150.0;
		MWCalcOptions.CamMode = CamMode.TriangularMesh5AX;
		MWCalcOptions.NumberofAxis = 5;
		MWCalcOptions.StartPointX = 0.0;
		MWCalcOptions.StartPointY = -970.0;
		MWCalcOptions.UseConstantStartPoint = true;
		int num = clsInit.appMW.doTriangularMesh3D5Axis(MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
		RouterCam.camMode = CamMode.TriangularMesh5AX;
		if (CamType != CamTriangularMesh5AxType.ParallelCuts)
		{
			if (CamType != CamTriangularMesh5AxType.ConstantZ)
			{
				if (CamType == CamTriangularMesh5AxType.Rough)
				{
					buMWRouter3XVars.varCamMeshRough5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRough5AXPars, clsMW.varbuCamMeshRough5AXPars, out buMWRouter3XVars.varCamMeshRough5AX.buPar);
					buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshRough5AX.mwPar, ref buMWRouter3XVars.varCamMeshRough5AX.buPar);
				}
			}
			else
			{
				buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZ5AXPars, clsMW.varbuCamMeshConstantZ5AXPars, out buMWRouter3XVars.varCamMeshConstantZ5AX.buPar);
				buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshConstantZ5AX.mwPar, ref buMWRouter3XVars.varCamMeshConstantZ5AX.buPar);
			}
		}
		else
		{
			buMWRouter3XVars.varCamMeshParallel5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalel5AXPars, clsMW.varbuCamMeshParallel5AXPars, out buMWRouter3XVars.varCamMeshParallel5AX.buPar);
			buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, ref buMWRouter3XVars.varCamMeshParallel5AX.buPar);
		}
		RouterCam.Tool = new ToolBase5(Tool);
		int num2 = 0;
		double num3 = 0.0;
		for (int i = 0; i <= RouterCam.CamData.CamPoints.Count - 1; i++)
		{
			bool flag = false;
			bool flag2 = false;
			if (i != 134)
			{
			}
			for (int j = 0; j <= RouterCam.CamData.CamPoints[i].Points.Count - 1; j++)
			{
				TpPnt9D tpPnt9D = RouterCam.CamData.CamPoints[i].Points[j];
				double double_ = 0.0;
				double double_2 = 0.0;
				IJK ijk = new IJK(tpPnt9D.P9.A, tpPnt9D.P9.B, tpPnt9D.P9.C);
				Point3D movePoint = new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z);
				Pnt6D CalcPoint = new Pnt6D();
				double a = tpPnt9D.P9.A;
				double b = tpPnt9D.P9.B;
				double c = tpPnt9D.P9.C;
				Class5.smethod_155(c, a, ref double_2, b, out double_);
				if (j > 0)
				{
					if (!(double_2 > 370.0))
					{
					}
					if (!(double_2 < -370.0))
					{
					}
					double value = double_2 - num3;
					if (!(Math.Abs(value) > 180.0))
					{
					}
					if (double_2 > 370.0)
					{
						flag = true;
					}
					if (double_2 < -370.0)
					{
						flag2 = true;
					}
				}
				OrientationAngle orientation = new OrientationAngle(0.0, double_, double_2);
				clsInit.cKinematic5.ForwardKinematix5AxMilling(RouterCam.Tool.Geometry.Length, ccVars.KinematicOrjinal.RotateCenterOffsetOfB.Y, ijk, orientation, movePoint, ref CalcPoint);
				tpPnt9D.P9.X = CalcPoint.X;
				tpPnt9D.P9.Y = CalcPoint.Y;
				tpPnt9D.P9.Z = CalcPoint.Z;
				tpPnt9D.P9.A = CalcPoint.A;
				tpPnt9D.P9.B = CalcPoint.B;
				tpPnt9D.P9.C = CalcPoint.C;
				if (!(tpPnt9D.P9.C > 370.0))
				{
				}
				if (!(tpPnt9D.P9.C < -370.0))
				{
				}
				if (num2 > 0)
				{
					double num4 = num3 - tpPnt9D.P9.C;
					if (num4 > 180.0 || num4 < -180.0)
					{
						if (!(num4 < 0.0))
						{
							tpPnt9D.P9.C += 360.0;
						}
						else
						{
							tpPnt9D.P9.C -= 360.0;
						}
					}
				}
				if (j > 0)
				{
					double value2 = RouterCam.CamData.CamPoints[i].Points[j].P9.C - RouterCam.CamData.CamPoints[i].Points[j - 1].P9.C;
					if (Math.Abs(value2) > 180.0)
					{
						double num5 = RouterCam.CamData.CamPoints[i].Points[j - 1].P9.C - RouterCam.CamData.CamPoints[i].Points[j].P9.C;
						if (num5 > 180.0 || num5 < -180.0)
						{
							if (!(num5 < 0.0))
							{
								RouterCam.CamData.CamPoints[i].Points[j].P9.C += 360.0;
							}
							else
							{
								RouterCam.CamData.CamPoints[i].Points[j].P9.C -= 360.0;
							}
						}
					}
				}
				if (tpPnt9D.P9.C > 370.0)
				{
					flag = true;
				}
				if (tpPnt9D.P9.C < -370.0)
				{
					flag2 = true;
				}
				num3 = tpPnt9D.P9.C;
				num2++;
			}
			if (!(flag && flag2))
			{
			}
			if (flag)
			{
				for (int k = 0; k <= RouterCam.CamData.CamPoints[i].Points.Count - 1; k++)
				{
					RouterCam.CamData.CamPoints[i].Points[k].P9.C -= 360.0;
				}
				num3 -= 360.0;
			}
			if (flag2)
			{
				for (int l = 0; l <= RouterCam.CamData.CamPoints[i].Points.Count - 1; l++)
				{
					RouterCam.CamData.CamPoints[i].Points[l].P9.C += 360.0;
				}
				num3 += 360.0;
			}
		}
		for (int m = 0; m <= RouterCam.CamData.CamPoints.Count - 1; m++)
		{
			if (m > 0)
			{
				double num6 = Math.Abs(RouterCam.CamData.CamPoints[m - 1].Points[RouterCam.CamData.CamPoints[m - 1].Points.Count - 1].P9.C - RouterCam.CamData.CamPoints[m].Points[0].P9.C);
				if (num6 > 180.0)
				{
					TpPnt9D tpPnt9D2 = new TpPnt9D(RouterCam.CamData.CamPoints[m - 1].Points[RouterCam.CamData.CamPoints[m - 1].Points.Count - 1]);
					tpPnt9D2.P9.Z = 100.0;
					tpPnt9D2.Type = 0;
					RouterCam.CamData.CamPoints[m - 1].Points.Add(tpPnt9D2);
					TpPnt9D tpPnt9D3 = new TpPnt9D(tpPnt9D2);
					tpPnt9D3.P9.C = RouterCam.CamData.CamPoints[m].Points[0].P9.C;
					RouterCam.CamData.CamPoints[m - 1].Points.Add(tpPnt9D3);
				}
			}
			for (int n = 1; n <= RouterCam.CamData.CamPoints[m].Points.Count - 1; n++)
			{
				double num7 = Math.Abs(RouterCam.CamData.CamPoints[m].Points[n - 1].P9.C - RouterCam.CamData.CamPoints[m].Points[n].P9.C);
				if (!(num7 > 180.0))
				{
				}
			}
		}
		for (int num8 = 0; num8 <= RouterCam.CamData.SimilationPoint.SimMove.Count - 1; num8++)
		{
			Pnt6DSimMove pnt6DSimMove = RouterCam.CamData.SimilationPoint.SimMove[num8];
			double double_3 = 0.0;
			double double_4 = 0.0;
			double a = pnt6DSimMove.A;
			double b = pnt6DSimMove.B;
			double c = pnt6DSimMove.C;
			Class5.smethod_155(c, a, ref double_4, b, out double_3);
			pnt6DSimMove.A = 0.0;
			pnt6DSimMove.B = double_3;
			pnt6DSimMove.C = double_4;
		}
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
			return;
		}
		if (CamName.Trim().Length > 0)
		{
			RouterCam.CamData.Name = CamName;
			RouterCam.CamName = CamName;
		}
		buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
		RouterCam.Tool = new ToolBase5(Tool);
		RouterCam.Purpose = Router3AXLayerPurpose.None;
		clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
		doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
		doAddOrEditCam(RouterCam, MWCalcOptions.Editing);
		JobUpdate();
		DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		UpdateDrawJob(SelectedCamIndex);
		SaveRouter3XFile();
		clsInit.appCommand.Reset();
	}

	public void doSurface5AX(CamSurfaceType CamType, ToolBase5 Tool, List<EntitiesList> EntGroup = null, string CamName = "")
	{
		if (activeJob == null)
		{
			activeJob = new Router3AXItem();
		}
		Router3AXCAM RouterCam = new Router3AXCAM();
		RouterCam.entitiesPlane = new Router3AXCamPlane();
		if (CamType != CamSurfaceType.SurfaceParalel)
		{
			buString5.MessageBoxError(buLangTranslate.preDef.UnknownCam);
			return;
		}
		MWCalcOptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
		buMWRouter3XVars.varCamMeshParallel5AX.buPar.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
		buMWRouter3XVars.varCamMeshParallel5AX.mwPar.MachParam.RapidRetractFlg = true;
		clsMW.varMWCamMeshParalel5AXPars = buMWCalcs.CopyCamParameter(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, buMWRouter3XVars.varCamMeshParallel5AX.buPar, out clsMW.varbuCamSurfaceParallelPars);
		camResult Result = null;
		clsMW.CamEntities.Clear();
		MWCalcOptions.DontShowbuDialogBox = true;
		if (MWCalcOptions.Editing)
		{
			if (activeJob.CamList[SelectedCamIndex].CamEntities.Count == 0)
			{
				return;
			}
			RouterCam = new Router3AXCAM(activeJob.CamList[SelectedCamIndex]);
			clsMW.CamEntities.Clear();
			buEntity.Copy(activeJob.CamList[SelectedCamIndex].CamEntities, ref clsMW.CamEntities);
			RouterCam.CamData = new camTp();
			RouterCam.CamEntities.Clear();
			clsMW.varbuCamWFContourPars = new camParameters5(activeJob.CamList[SelectedCamIndex].CamPars);
		}
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.CurOutputType = MachiningParamsOutputType.OutputType5axis;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.LimitsFlg = true;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = 45.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 135.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = 45.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 135.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.ParallelMachAngleInYX = 90.0;
		clsMW.varMWCamMeshParalel5AXPars.MachParam.MaxStepoverDistance = 5.0;
		MWCalcOptions.NumberofAxis = 5;
		int num = clsInit.appMW.doTriangularMesh3D5Axis(MWCalcOptions, Tool, ref RouterCam.CamData, ref Result);
		RouterCam.camMode = CamMode.TriangularMesh;
		RouterCam.camSurfType = CamType;
		if (CamType == CamSurfaceType.SurfaceParalel)
		{
			buMWRouter3XVars.varCamMeshParallel5AX.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalel5AXPars, clsMW.varbuCamMeshParallel5AXPars, out buMWRouter3XVars.varCamMeshParallel5AX.buPar);
			buMWCalcs.ConvertFromMwCamParToBuCamPar(buMWRouter3XVars.varCamMeshParallel5AX.mwPar, ref buMWRouter3XVars.varCamMeshParallel5AX.buPar);
		}
		for (int i = 0; i <= RouterCam.CamData.CamPoints.Count - 1; i++)
		{
			for (int j = 0; j <= RouterCam.CamData.CamPoints[i].Points.Count - 1; j++)
			{
				TpPnt9D tpPnt9D = RouterCam.CamData.CamPoints[i].Points[j];
				double double_ = 0.0;
				double double_2 = 0.0;
				double a = tpPnt9D.P9.A;
				double b = tpPnt9D.P9.B;
				double c = tpPnt9D.P9.C;
				Class5.smethod_155(c, a, ref double_2, b, out double_);
				tpPnt9D.P9.A = 0.0;
				tpPnt9D.P9.B = double_;
				tpPnt9D.P9.C = double_2;
			}
		}
		for (int k = 0; k <= RouterCam.CamData.SimilationPoint.SimMove.Count - 1; k++)
		{
			Pnt6DSimMove pnt6DSimMove = RouterCam.CamData.SimilationPoint.SimMove[k];
			double double_3 = 0.0;
			double double_4 = 0.0;
			double a = pnt6DSimMove.A;
			double b = pnt6DSimMove.B;
			double c = pnt6DSimMove.C;
			Class5.smethod_155(c, a, ref double_4, b, out double_3);
			pnt6DSimMove.A = 0.0;
			pnt6DSimMove.B = double_3;
			pnt6DSimMove.C = double_4;
		}
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
			return;
		}
		if (CamName.Trim().Length > 0)
		{
			RouterCam.CamData.Name = CamName;
			RouterCam.CamName = CamName;
		}
		buEntity.Copy(Result.UsedEntities, ref RouterCam.CamEntities);
		RouterCam.Tool = new ToolBase5(Tool);
		RouterCam.Purpose = Router3AXLayerPurpose.None;
		clsInit.cVector5.BoxSizeCalculate(RouterCam.CamData, ref RouterCam.MinPoint, ref RouterCam.MaxPoint);
		doPlaneCalculation(buMWRouter3XVars.varCamWireframeContour.buPar, ref RouterCam);
		doAddOrEditCam(RouterCam, MWCalcOptions.Editing);
		JobUpdate();
		DrawJob(new DrawOptions(drawall: true), SelectedCamIndex);
		UpdateDrawJob(SelectedCamIndex);
		SaveRouter3XFile();
		clsInit.appCommand.Reset();
	}

	public static void ConvertIJKToBC(double I, double J, double K, out double B_deg, out double C_deg)
	{
		Math.Sqrt(I * I + J * J + K * K);
		double num = Math.Asin(I);
		double num2 = Math.Cos(num);
		double num3 = Math.Atan2(J / num2, K / num2);
		B_deg = num * 180.0 / Math.PI;
		C_deg = num3 * 180.0 / Math.PI;
	}

	public void doPlaneCalculation(camParameters5 buPar, ref Router3AXCAM RouterCam)
	{
		clsInit.cVector5.CreateCamHeightPlane(buPar.Distances.Safe, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, varRouter3AXDisplaySettings.colorPlaneClearance.Color, varRouter3AXDisplaySettings.colorPlaneClearance.Transperancy, buLangTranslate.preDef.Safe + " = " + buPar.Distances.Safe.ToString("f1"), CamPlaneHeightType.Clearance, ref RouterCam.entitiesPlane.entityPlaneClearance, ref RouterCam.entitiesPlane.entityPlaneClearanceText);
		if (!buPar.Steps.Enable)
		{
			clsInit.cVector5.CreateCamHeightPlane(buPar.Operations.Height, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, varRouter3AXDisplaySettings.colorPlaneBottom.Color, varRouter3AXDisplaySettings.colorPlaneBottom.Transperancy, buLangTranslate.preDef.Bottom + " = " + buPar.Steps.EndValue.ToString("f1"), CamPlaneHeightType.Bottom, ref RouterCam.entitiesPlane.entityPlaneBottom, ref RouterCam.entitiesPlane.entityPlaneBottomText);
			if (activeJob.Stock != null)
			{
				clsInit.cVector5.CreateCamHeightPlane(buPar.Distances.Rapid, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, varRouter3AXDisplaySettings.colorPlaneRetract.Color, varRouter3AXDisplaySettings.colorPlaneRetract.Transperancy, buLangTranslate.preDef.Retract + " = " + buPar.Distances.Rapid.ToString("f1"), CamPlaneHeightType.Retract, ref RouterCam.entitiesPlane.entityPlaneRetract, ref RouterCam.entitiesPlane.entityPlaneRetractText);
				clsInit.cVector5.CreateCamHeightPlane(activeJob.Stock.MaxPoint.Z, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, varRouter3AXDisplaySettings.colorPlaneTop.Color, varRouter3AXDisplaySettings.colorPlaneTop.Transperancy, buLangTranslate.preDef.Top + " = " + buPar.Steps.StartValue.ToString("f1"), CamPlaneHeightType.Top, ref RouterCam.entitiesPlane.entityPlaneTop, ref RouterCam.entitiesPlane.entityPlaneTopText);
			}
		}
		else
		{
			clsInit.cVector5.CreateCamHeightPlane(buPar.Steps.EndValue, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, varRouter3AXDisplaySettings.colorPlaneBottom.Color, varRouter3AXDisplaySettings.colorPlaneBottom.Transperancy, buLangTranslate.preDef.Bottom + " = " + buPar.Steps.EndValue.ToString("f1"), CamPlaneHeightType.Bottom, ref RouterCam.entitiesPlane.entityPlaneBottom, ref RouterCam.entitiesPlane.entityPlaneBottomText);
			clsInit.cVector5.CreateCamHeightPlane(buPar.Distances.Rapid, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, varRouter3AXDisplaySettings.colorPlaneRetract.Color, varRouter3AXDisplaySettings.colorPlaneRetract.Transperancy, buLangTranslate.preDef.Retract + " = " + buPar.Distances.Rapid.ToString("f1"), CamPlaneHeightType.Retract, ref RouterCam.entitiesPlane.entityPlaneRetract, ref RouterCam.entitiesPlane.entityPlaneRetractText);
			clsInit.cVector5.CreateCamHeightPlane(buPar.Steps.StartValue, RouterCam.planeName, RouterCam.MinPoint, RouterCam.MaxPoint, varRouter3AXDisplaySettings.colorPlaneTop.Color, varRouter3AXDisplaySettings.colorPlaneTop.Transperancy, buLangTranslate.preDef.Top + " = " + buPar.Steps.StartValue.ToString("f1"), CamPlaneHeightType.Top, ref RouterCam.entitiesPlane.entityPlaneTop, ref RouterCam.entitiesPlane.entityPlaneTopText);
		}
	}

	public void doAddOrEditCam(Router3AXCAM RouterCam, bool Editing)
	{
		if (Editing)
		{
			activeJob.CamList[SelectedCamIndex] = RouterCam;
			ccVars.Pages[ccVars.PageIndex].Cams[SelectedCamIndex] = RouterCam.CamData;
		}
		else
		{
			activeJob.CamList.Add(RouterCam);
			SelectedCamIndex = activeJob.CamList.Count - 1;
			ccVars.Pages[ccVars.PageIndex].Cams.Add(RouterCam.CamData);
		}
	}
}
