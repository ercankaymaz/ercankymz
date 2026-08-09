using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Forms.Shape;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Wood;

public class clsWood
{
	public List<string> cmdExceptionID = new List<string>();

	private int int_0 = -1;

	private int int_1 = -1;

	private int int_2 = -1;

	private int int_3 = -1;

	private int int_4 = -1;

	private int int_5 = -1;

	private string string_0 = "XZ";

	private bool bool_0 = false;

	private Timer timer_0 = new Timer();

	private ShapeCreateParameters shapeCreateParameters_0 = new ShapeCreateParameters();

	public static WoodJob activeJob;

	public List<buEntity> refEntities = new List<buEntity>();

	public void Init()
	{
		buMWWoodVars.Init();
		OpenWoodFile();
		LoadLanguage();
	}

	public void InitSimulation()
	{
	}

	public void WoodTree_AfterSelect(object sender, TreeViewEventArgs e)
	{
		if (ccVars.Pages.Count == 0)
		{
		}
	}

	public void WoodTree_AfterCheck(object sender, TreeViewEventArgs e)
	{
		if (ccVars.Pages.Count == 0)
		{
		}
	}

	public void ProfileTreeUpdate()
	{
		clsItem.FrmWoodJob.tree_jobs.Nodes.Clear();
		TreeNodeSettings treeNodeSettings = new TreeNodeSettings("Job")
		{
			ImageIndex = 15,
			SelectedImageIndex = 15,
			Tag = "-1",
			ClassIndex = -1,
			ClassSubIndex = -1,
			ClassSubSubIndex = -1,
			Command = "profilebase",
			Name = "base",
			Info = "base",
			Index = 0,
			Checked = false
		};
		TreeNodeSettings treeNodeSettings2 = null;
		if (treeNodeSettings2 != null)
		{
			treeNodeSettings2.Expand();
			treeNodeSettings.Expand();
		}
		clsItem.FrmWoodJob.tree_jobs.Nodes.Add(treeNodeSettings);
	}

	public void Checked_Checked(object sender, EventArgs e)
	{
		buWood.varWoodRunSettings.SelectMode = clsItem.FrmWoodJob.chk_selectmode.Checked;
		clsItem.FrmWoodJob.tree_jobs.CheckBoxes = buWood.varWoodRunSettings.SelectMode;
		if (!buWood.varWoodRunSettings.SelectMode)
		{
			for (int i = 0; i <= clsItem.FrmWoodJob.tree_jobs.Nodes.Count - 1; i++)
			{
				clsItem.FrmWoodJob.tree_jobs.Nodes[i].Expand();
			}
		}
	}

	public void cmdNewMaterial(DrillJob panel)
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
			clsItem.FrmMaterial3D.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
		}
		clsItem.FrmMaterial3D.pnl_model.Controls.Add(clsItem.FrmMaterial3D.viewportLayout);
		clsItem.FrmMaterial3D.viewportLayout.Entities.Clear();
		clsItem.FrmMaterial3D.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		ccVars.activeMaterial.Size.Width = buWood.varWoodSettings.MaterialWidth;
		ccVars.activeMaterial.Size.Height = buWood.varWoodSettings.MaterialHeight;
		ccVars.activeMaterial.Size.Depth = buWood.varWoodSettings.MaterialDepth;
		clsItem.FrmMaterial3D.Material = new MaterialBase5(ccVars.activeMaterial);
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
			buWood.varWoodSettings.MaterialWidth = ccVars.activeMaterial.Size.Width;
			buWood.varWoodSettings.MaterialHeight = ccVars.activeMaterial.Size.Height;
			buWood.varWoodSettings.MaterialDepth = ccVars.activeMaterial.Size.Depth;
			if (panel == null)
			{
				AddPanel(ccVars.activeMaterial);
			}
		}
		SaveWoodFile();
	}

	public void cmdShapes()
	{
		if (clsItem.FrmShapeList == null)
		{
			clsItem.FrmShapeList = new F_ShapeList();
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = false;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
			clsItem.FrmShapeList.DataOk += ShapeChanged;
		}
		if (buWood.varTemps.lastShape != null)
		{
			clsItem.FrmShapeList.selectedShape = buShape.Copy(buWood.varTemps.lastShape);
		}
		else
		{
			clsItem.FrmShapeList.selectedShape = new buShapeRectangle(buWood.varWoodRunSettings.ShapeDataParameters.RectangleWidth, buWood.varWoodRunSettings.ShapeDataParameters.RectangleHeight, buWood.varWoodRunSettings.ShapeDataParameters.RectangleRadius, buWood.varWoodRunSettings.ShapeDataParameters.RectangleChamfer, buWood.varWoodRunSettings.ShapeDataParameters.RectangleDepth, buWood.varWoodRunSettings.ShapeDataParameters.RectangleAngle);
		}
		clsItem.FrmShapeList.PropertiesForm.TopMost = true;
		clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
		clsItem.FrmShapeList.Top = 50;
		clsItem.FrmShapeList.Left = 1500;
		clsItem.FrmShapeList.TopMost = true;
		clsItem.FrmShapeList.pnl_model.Controls.Add(clsItem.FrmShapeList.viewportLayout);
		clsItem.FrmShapeList.viewportLayout.Entities.Clear();
		clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmShapeList.Init();
		clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmShapeList.Show();
		clsItem.FrmShapeList.Top = 50;
		clsItem.FrmShapeList.Left = 1500;
	}

	public void cmdSettings()
	{
	}

	public void cmdShowGcode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					string Lines = "";
					cmdCamContour();
					clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
					F_Notepad f_Notepad = new F_Notepad();
					f_Notepad.Init(Lines);
					f_Notepad.Show();
					if (clsItem.FrmProgress != null)
					{
						clsItem.FrmProgress.Visible = false;
					}
					Lines = "";
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

	public void cmdSaveGcode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
					saveFileDialog.FilterIndex = 1;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						string Lines = "";
						clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
						clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
						buFile5.SaveToFile(Lines, saveFileDialog.FileName);
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
						Lines = "";
						clsFiles.SaveParameter();
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

	public void cmdCamContour()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Pages[ccVars.PageIndex].Cams.Clear();
			clsMW.CamEntities.Clear();
			for (int i = 0; i <= activeJob.Items.Count - 1; i++)
			{
				for (int j = 0; j <= activeJob.Items[i].entitiesShape.Count - 1; j++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(activeJob.Items[i].entitiesShape[j], ref copiedEntity);
					if (activeJob.Items[i].planeName == planeBoxNames.Front)
					{
						copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
					}
					if (activeJob.Items[i].planeName == planeBoxNames.Back)
					{
						copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
					}
					clsMW.CamEntities.Add(copiedEntity);
				}
				camTp Cam = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInLocalCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.ShowLeadInOutPage = false;
				mWCalculationOptions.DontShowDialogBox = true;
				doWireframeContour(mWCalculationOptions, ccVars.toolActive, ref Cam);
				ccVars.Pages[ccVars.PageIndex].Cams.Add(Cam);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdAddFromFile()
	{
		if (clsItem.FrmFromFile == null)
		{
			clsItem.FrmFromFile = new F_AddFromFile();
		}
		clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmFromFile.Path = buWood.varWoodSettings.pathFromFile;
		clsItem.FrmFromFile.KeepRatio = buWood.varWoodSettings.FromFileKeepRatio;
		clsItem.FrmFromFile.Init();
		clsItem.FrmFromFile.ShowDialog();
		if (clsItem.FrmFromFile.PropertiesForm.Result == DialogResult.OK)
		{
			shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
			for (int i = 0; i <= clsItem.FrmFromFile.viewport.Entities.Count - 1; i++)
			{
				buEntity copiedEntity = null;
				buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
				shapeCreateParameters_0.entitiesCurve.Add(copiedEntity);
			}
			buWood.varWoodSettings.pathFromFile = clsItem.FrmFromFile.Path;
			buWood.varWoodSettings.FromFileKeepRatio = clsItem.FrmFromFile.KeepRatio;
			SaveWoodFile();
			buWood.varTemps.lastShape = new buShapeFreeDraw(buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawWidth, buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawHeight, buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawDepth, buWood.varWoodRunSettings.ShapeDataParameters.FreeDrawAngle);
			cmdShapes();
		}
	}

	public void Sim_Tick(object sender, EventArgs e)
	{
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buWood.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buWood.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Wood Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Wood Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buWood.LangWoodCommands);
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

	public void SaveWoodFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\Wood\\Wood.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Wood Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<buWood.varWoodSettings>");
			arrayList.AddRange(buWood.varWoodSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buWood.varWoodSettings>");
			arrayList.Add("<buWood.varWoodRunSettings>");
			arrayList.AddRange(buWood.varWoodRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buWood.varWoodRunSettings>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Wood Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			buMWWoodVars.varCamContour.mwPar.Serialize(AppPath.Settings + "\\Wood\\mwWoodContour.bin");
			buMWWoodVars.varCamRough.mwPar.Serialize(AppPath.Settings + "\\Wood\\mwWoodRough.bin");
			string fileName2 = AppPath.Settings + "\\Wood\\WoodCam.bucamset";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   MW Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<MwCamSettings>");
			arrayList.AddRange(buMWWoodVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(buMWWoodVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</MwCamSettings>");
			buFile.SaveToFile(arrayList, fileName2);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenWoodFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Wood\\Wood.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Wood Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Wood Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<buWood.varWoodSettings>", "</buWood.varWoodSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buWood.varWoodSettings);
						buLog.addLog("Wood Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<buWood.varWoodRunSettings>", "</buWood.varWoodRunSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buWood.varWoodRunSettings);
						buLog.addLog("Wood varDrillCNCSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Wood Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Printer3D Settings Decoder Error");
				}
			}
			buLog.addLog("Wood Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Wood\\mwWoodContour.bin");
			if (fileInfo.Exists)
			{
				buMWWoodVars.varCamContour.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Wood\\mwWoodRough.bin");
			if (fileInfo.Exists)
			{
				buMWWoodVars.varCamRough.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Wood\\WoodCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLog.addLog("Wood Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Wood Cam Settings File Missing");
				return;
			}
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileName2, ref arrayList);
			try
			{
				ArrayList CalcList2 = new ArrayList();
				buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, arrayList, ref CalcList2);
				if (CalcList2.Count > 0)
				{
					buSerilization.Decode(arrayList, "_varCamContour", SerilizationMode.MultiLine, buMWWoodVars.varCamContour);
					buSerilization.Decode(arrayList, "_varCamRough", SerilizationMode.MultiLine, buMWWoodVars.varCamRough);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Wood Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Wood Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void NewPageExtension()
	{
		ProfileTreeUpdate();
	}

	public void PageClosed()
	{
		ProfileTreeUpdate();
	}

	public void AddPanel(MaterialBase5 Mat)
	{
		if (ccVars.Pages.Count > 0)
		{
			activeJob = new WoodJob();
			activeJob.Items = new List<buShape>();
			activeJob.Material = new MaterialBase5(Mat);
			CreatePanelFromJob(ref activeJob, 1.0, Solid: true);
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
			clsInit.appCommand.cmdViewZoomFit();
			clsInit.appCommand.cmdViewZoomOut();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public void CreatePanelFromJob(ref WoodJob Job, double Sing, bool Solid)
	{
		try
		{
			Brep brep = Brep.CreateBox(Job.Material.Size.Width, Job.Material.Size.Height, Job.Material.Size.Depth);
			if (Sing != 1.0)
			{
				brep.Translate(Sing * Job.Material.Size.Width, Sing * Job.Material.Size.Height);
			}
			brep.Rebuild(0.1);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			brep.LayerName = buWood.varTemps.layerPanel;
			brep.ColorMethod = colorMethodType.byEntity;
			brep.Color = Color.FromArgb(150, buWood.varWoodSettings.colorPanel);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(brep);
			for (int i = 0; i <= Job.Items.Count - 1; i++)
			{
				buShape Shape = Job.Items[i];
				shapeCreateParameters_0.Solid = true;
				clsInit.cVector5.CreatebuShape(ref Shape, shapeCreateParameters_0);
				for (int j = 0; j <= Shape.entitySolid.Count - 1; j++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(Shape.entitySolid[j], ref copiedEntity);
					copiedEntity.LayerName = buWood.varTemps.layerOperation;
					copiedEntity.ColorMethod = colorMethodType.byEntity;
					copiedEntity.Color = buWood.varWoodSettings.colorOperation;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	public void ShapeChanged(object Data1, object Data2)
	{
		buShape Shape = Data1 as buShape;
		ShapeUpdateArg shapeUpdateArg = Data2 as ShapeUpdateArg;
		if (shapeUpdateArg.Finished)
		{
			shapeCreateParameters_0.Solid = true;
			shapeCreateParameters_0.Size = new SizeObject(activeJob.Material.Size);
			Shape.BasePoint.X = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.X;
			Shape.BasePoint.Y = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Y;
			Shape.BasePoint.Z = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Z;
			clsInit.cVector5.CreatebuShape(ref Shape, shapeCreateParameters_0);
			buShape item = buShape.Copy(Shape);
			activeJob.Items.Add(item);
			CreatePanelFromJob(ref activeJob, 1.0, Solid: true);
		}
		else
		{
			ccVars.pntDrawDynamicLinesArr.Clear();
			shapeCreateParameters_0.Solid = false;
			shapeCreateParameters_0.Size = new SizeObject(activeJob.Material.Size);
			Shape.BasePoint.X = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.X;
			Shape.BasePoint.Y = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Y;
			Shape.BasePoint.Z = buWood.varWoodRunSettings.ShapeDataParameters.pntBase.Z;
			clsInit.cVector5.CreatebuShape(ref Shape, shapeCreateParameters_0);
			if (Shape.entitiesShape.Count > 0)
			{
				for (int i = 0; i <= Shape.entitiesShape.Count - 1; i++)
				{
					List<Point3D> copiedPoint = new List<Point3D>();
					buVector5.Copy(Shape.entitiesShape[i].Vertices, ref copiedPoint);
					ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doReset()
	{
	}

	public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWWoodVars.varCamContour.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWWoodVars.varCamContour.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWWoodVars.varCamContour.buPar.Offsets.OpenContour = CamOpenContourType.Center;
		buMWWoodVars.varCamContour.buPar.Distances.Air = 0.0;
		buMWWoodVars.varCamContour.buPar.Distances.Safe = 0.0;
		buMWWoodVars.varCamContour.buPar.Distances.Rapid = 0.0;
		buMWWoodVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
		buMWWoodVars.varCamContour.buPar.Distances.EntryAndExit = 0.0;
		buMWWoodVars.varCamContour.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
		buMWWoodVars.varCamContour.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWWoodVars.varCamContour.mwPar, buMWWoodVars.varCamContour.buPar);
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWWoodVars.varCamContour.mwPar, buMWWoodVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWWoodVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWWoodVars.varCamContour.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doWireframeRough(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWWoodVars.varCamRough.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWWoodVars.varCamRough.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWWoodVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
		buMWWoodVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
		buMWWoodVars.varCamRough.buPar.Operations.Height = MWCalcoptions.Height;
		buMWWoodVars.varCamRough.buPar.Offsets.OpenContour = CamOpenContourType.Center;
		buMWWoodVars.varCamRough.buPar.Distances.Air = 0.0;
		buMWWoodVars.varCamRough.buPar.Distances.Safe = 0.0;
		buMWWoodVars.varCamRough.buPar.Distances.Rapid = 0.0;
		buMWWoodVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
		buMWWoodVars.varCamRough.buPar.Distances.EntryAndExit = 0.0;
		buMWWoodVars.varCamRough.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
		buMWWoodVars.varCamRough.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWWoodVars.varCamRough.mwPar, buMWWoodVars.varCamRough.buPar);
		clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWWoodVars.varCamRough.mwPar, buMWWoodVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWWoodVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWWoodVars.varCamRough.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}
}
