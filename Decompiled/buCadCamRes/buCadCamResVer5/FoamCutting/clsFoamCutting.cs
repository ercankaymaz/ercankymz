using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buCadCamResVer5.Editor;
using buCadCamResVer5.Forms;
using buCadCamResVer5.Library;
using buClass;
using buControls.ClassViewer;
using buControls.DialogBox;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Foam;
using buEyeBaseVer5.Forms.GCode;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.Variables;
using buEyeBaseVer5.buEntities;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.FoamCutting;

public class clsFoamCutting
{
	public List<string> cmdExceptionID = new List<string>();

	public FoamItem activeFoam = new FoamItem();

	public List<List<buEntity>> selectedEntities = new List<List<buEntity>>();

	public List<buEntity> selectedEntity = new List<buEntity>();

	public F_FoamPattern frmPattern = null;

	public F_FoamWaveForm frmWave = null;

	public F_FoamSlices frmSlice = null;

	public F_FoamSlicesList frmSliceList = null;

	public List<Color> OperationColors = new List<Color>();

	public List<buEntity> sortRefEntities = new List<buEntity>();

	public FoamPattern activePattern = null;

	public FoamBlock activeBlock = null;

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	public FoamCalcVars varCalc = new FoamCalcVars();

	public TreeView treejobs = new TreeView();

	public Panel pnldata = new Panel();

	public RadioButton radiosortNone = new RadioButton();

	public RadioButton radiosortmanuel = new RadioButton();

	public RadioButton radiosortCW = new RadioButton();

	public RadioButton radiosortJump = new RadioButton();

	public RadioButton radiosortCCW = new RadioButton();

	public RadioButton radiosortHigherIndex = new RadioButton();

	public RadioButton radiosortFirstDirThenAuto = new RadioButton();

	public RadioButton radiosortLowerIndex = new RadioButton();

	private SortbuSettings sortbuSettings_0 = new SortbuSettings();

	private SortbuResult sortbuResult_0 = new SortbuResult();

	private SortPointClickResult sortPointClickResult_0 = new SortPointClickResult();

	private FoamActiveBlock foamActiveBlock_0 = new FoamActiveBlock();

	public List<LengthCount> SliceVerticalList = new List<LengthCount>();

	public List<LengthCount> SliceHorizontalList = new List<LengthCount>();

	private Point3D point3D_0 = new Point3D();

	private Point3D point3D_1 = new Point3D();

	public int simIndex = -1;

	private int int_0 = -1;

	private bool bool_0 = false;

	private bool bool_1 = false;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	private System.Windows.Forms.Timer timer_1 = new System.Windows.Forms.Timer();

	private double double_0 = 0.0;

	private double double_1 = 0.0;

	private double double_2 = 0.0;

	private double double_3 = 0.0;

	private double double_4 = 0.0;

	private int int_1 = 0;

	private int int_2 = 0;

	private int int_3 = 0;

	private int int_4 = 0;

	public event OkCommandWithTwoDataEventHandler CommandFoam
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public void Init()
	{
		buMWFoamVars.Init();
		OpenFoamFile();
		LoadLanguage();
		if (clsItem.FrmFoamJob == null)
		{
			clsItem.FrmFoamJob = new F_FoamJob();
		}
		if (buFoamCalc.RadiusFeedList.Count == 0)
		{
			buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(0.0, 5.0, 10.0));
			buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(5.0, 10.0, 15.0));
			buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(10.0, 20.0, 20.0));
			buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(20.0, 40.0, 25.0));
			buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(40.0, 100.0, 50.0));
			buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(100.0, 100000000.0, 100.0));
		}
		if (buFoamCalc.LengthFeedList.Count == 0)
		{
			buFoamCalc.LengthFeedList.Add(new camLengthFeed(0.0, 5.0, 10.0));
			buFoamCalc.LengthFeedList.Add(new camLengthFeed(5.0, 10.0, 15.0));
			buFoamCalc.LengthFeedList.Add(new camLengthFeed(10.0, 20.0, 20.0));
			buFoamCalc.LengthFeedList.Add(new camLengthFeed(20.0, 40.0, 25.0));
			buFoamCalc.LengthFeedList.Add(new camLengthFeed(40.0, 100.0, 50.0));
			buFoamCalc.LengthFeedList.Add(new camLengthFeed(100.0, 100000000.0, 100.0));
		}
		clsItem.FrmFromFile = new F_AddFromFile();
		clsItem.FrmFromFile.ReadFile += OpenFoamPatternFile;
		if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.None)
		{
			if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.CCW)
			{
				if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.CW)
				{
					if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.FirstDirectionThenAuto)
					{
						if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.HigherIndex)
						{
							if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.Jump)
							{
								if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.LowerIndex)
								{
									if (sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.Manuel)
									{
										radiosortmanuel.Checked = true;
									}
								}
								else
								{
									radiosortLowerIndex.Checked = true;
								}
							}
							else
							{
								radiosortJump.Checked = true;
							}
						}
						else
						{
							radiosortHigherIndex.Checked = true;
						}
					}
					else
					{
						radiosortFirstDirThenAuto.Checked = true;
					}
				}
				else
				{
					radiosortCW.Checked = true;
				}
			}
			else
			{
				radiosortCCW.Checked = true;
			}
		}
		else
		{
			radiosortNone.Checked = true;
		}
		radiosortCCW.CheckedChanged += radio_CheckedChanged;
		radiosortCW.CheckedChanged += radio_CheckedChanged;
		radiosortFirstDirThenAuto.CheckedChanged += radio_CheckedChanged;
		radiosortHigherIndex.CheckedChanged += radio_CheckedChanged;
		radiosortJump.CheckedChanged += radio_CheckedChanged;
		radiosortLowerIndex.CheckedChanged += radio_CheckedChanged;
		radiosortmanuel.CheckedChanged += radio_CheckedChanged;
		radiosortNone.CheckedChanged += radio_CheckedChanged;
		timer_0.Tick += Sim_Tick;
		timer_0.Interval = 10;
		timer_1.Tick += New_Tick;
		timer_1.Interval = 500;
		clsInit.appFoamCutting.frmPattern = new F_FoamPattern();
		clsInit.appFoamCutting.frmPattern.DataChanged += clsInit.appFoamCutting.OperationDataChanged;
		clsInit.appFoamCutting.frmPattern.ParameterChanged += clsInit.appFoamCutting.ParameterChanged;
		clsInit.appFoamCutting.frmPattern.DataCancel += clsInit.appFoamCutting.OperationDataCancel;
		clsInit.appFoamCutting.frmPattern.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsInit.appFoamCutting.frmPattern.PropertiesForm.TopMost = true;
		clsInit.appFoamCutting.frmPattern.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsInit.appFoamCutting.frmPattern.StartPosition = FormStartPosition.Manual;
		clsInit.appFoamCutting.frmWave = new F_FoamWaveForm();
		clsInit.appFoamCutting.frmWave.DataChanged += clsInit.appFoamCutting.OperationDataChanged;
		clsInit.appFoamCutting.frmWave.ParameterChanged += clsInit.appFoamCutting.ParameterChanged;
		clsInit.appFoamCutting.frmWave.DataCancel += clsInit.appFoamCutting.OperationDataCancel;
		clsInit.appFoamCutting.frmWave.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsInit.appFoamCutting.frmWave.PropertiesForm.TopMost = true;
		clsInit.appFoamCutting.frmWave.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsInit.appFoamCutting.frmWave.StartPosition = FormStartPosition.Manual;
		clsInit.appFoamCutting.frmSlice = new F_FoamSlices();
		clsInit.appFoamCutting.frmSlice.DataChanged += clsInit.appFoamCutting.OperationDataChanged;
		clsInit.appFoamCutting.frmSlice.ParameterChanged += clsInit.appFoamCutting.ParameterChanged;
		clsInit.appFoamCutting.frmSlice.DataCancel += clsInit.appFoamCutting.OperationDataCancel;
		clsInit.appFoamCutting.frmSlice.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsInit.appFoamCutting.frmSlice.PropertiesForm.TopMost = true;
		clsInit.appFoamCutting.frmSlice.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsInit.appFoamCutting.frmSlice.StartPosition = FormStartPosition.Manual;
	}

	public void InitSimulation()
	{
	}

	public void cmdNewMaterial(FoamItem foam, bool SkipForm = false, bool Editing = false)
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
			Properties.OriginSymbolVisible = false;
			clsInit.cVector5.CreateModelControl(ref clsItem.FrmMaterial3D.viewportLayout, clsVar.UnlockKey, Properties);
		}
		clsItem.FrmMaterial3D.pnl_model.Controls.Add(clsItem.FrmMaterial3D.viewportLayout);
		clsItem.FrmMaterial3D.viewportLayout.Entities.Clear();
		clsItem.FrmMaterial3D.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmMaterial3D.Material.Size.Width = buFoamCalc.varFoamRunSettings.MaterialWidth;
		clsItem.FrmMaterial3D.Material.Size.Height = buFoamCalc.varFoamRunSettings.MaterialHeight;
		clsItem.FrmMaterial3D.Material.Size.Depth = buFoamCalc.varFoamRunSettings.MaterialDepth;
		clsItem.FrmMaterial3D.Material = new MaterialBase5(ccVars.activeMaterial);
		clsItem.FrmMaterial3D.DrawDimension = true;
		if (foam != null)
		{
			clsItem.FrmMaterial3D.Init(foam.Material);
			ccVars.activeMaterial.Size = new SizeObject(foam.Material.Size);
		}
		else
		{
			clsItem.FrmMaterial3D.Init(null);
		}
		clsItem.FrmMaterial3D.StartPosition = FormStartPosition.CenterParent;
		if (!SkipForm)
		{
			clsItem.FrmMaterial3D.ShowDialog();
		}
		if (clsItem.FrmMaterial3D.PropertiesForm.Result == DialogResult.OK || SkipForm)
		{
			buFoamCalc.varFoamRunSettings.MaterialWidth = ccVars.activeMaterial.Size.Width;
			buFoamCalc.varFoamRunSettings.MaterialHeight = ccVars.activeMaterial.Size.Height;
			buFoamCalc.varFoamRunSettings.MaterialDepth = ccVars.activeMaterial.Size.Depth;
			if (foam == null)
			{
				activeFoam = new FoamItem();
			}
			ccVars.activeMaterial = new MaterialBase5(clsItem.FrmMaterial3D.Material);
			if (foam != null)
			{
				doAddFoam(ccVars.activeMaterial, New: false);
			}
			else
			{
				doAddFoam(ccVars.activeMaterial, New: true);
			}
			JobUpdate(FillPages: true, "", null, -1);
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Width;
			buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Height;
			buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
		}
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
		if (clsItem.ModelMainPreview != null)
		{
			clsItem.ModelMainPreview.ActiveViewport.DisplayMode = displayType.Flat;
			clsItem.ModelMainPreview.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
			clsItem.ModelMainPreview.SetView(viewType.Isometric);
			clsItem.ModelMainPreview.ZoomFit();
			clsItem.ModelMainPreview.Invalidate();
		}
		clsFiles.SaveParameter();
		SaveFoamFile();
		doEditBlocks();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.ViewCubeIcon.FrontText = "Main";
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.ViewCubeIcon.RightText = "Side";
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.ViewCubeIcon.Visible = true;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.CompileUserInterfaceElements();
		if (buFoamCalc.varFoamRunSettings.planeNames != FoamPlaneType.XZ)
		{
			cmdPlaneYZ(ZoomFit: true);
		}
		else
		{
			cmdPlaneXZ(ZoomFit: true);
		}
	}

	public void cmdAddBlock()
	{
		if (ccVars.Pages.Count > 0)
		{
			FoamBlock foamBlock = new FoamBlock();
			if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
			{
				foamBlock.BlockName = buLangTranslate.preDef.Block + " XZ" + activeFoam.BlockXZ.Count + 1;
				activeFoam.BlockXZ.Add(foamBlock);
				foamActiveBlock_0.Plane = FoamPlaneType.XZ;
				foamActiveBlock_0.BlockIndex = activeFoam.BlockXZ.Count - 1;
				foamActiveBlock_0.PatternIndex = -1;
			}
			if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
			{
				foamBlock.BlockName = buLangTranslate.preDef.Block + " YZ" + activeFoam.BlockYZ.Count + 1;
				activeFoam.BlockYZ.Add(foamBlock);
				foamActiveBlock_0.Plane = FoamPlaneType.YZ;
				foamActiveBlock_0.BlockIndex = activeFoam.BlockYZ.Count - 1;
				foamActiveBlock_0.PatternIndex = -1;
			}
			JobUpdate(FillPages: true, "", null, -1);
		}
	}

	public void cmdAddFromFile(List<buEntity> Entities, List<List<buEntity>> EntitiesGroup)
	{
		if (clsItem.FrmFromFile == null)
		{
			clsItem.FrmFromFile = new F_AddFromFile();
		}
		bool flag = false;
		bool flag2 = false;
		if (Entities != null && Entities.Count > 0)
		{
			flag = true;
		}
		if (EntitiesGroup != null && EntitiesGroup.Count > 0)
		{
			flag2 = true;
		}
		if (!flag && !flag2)
		{
			clsItem.FrmFromFile.ExtensionList.Clear();
			clsItem.FrmFromFile.ExtensionList.Add(".dxf");
			clsItem.FrmFromFile.ExtensionList.Add(".dwg");
			clsItem.FrmFromFile.ExtensionList.Add(".bucadv5");
			clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
			clsItem.FrmFromFile.Path = buFoamCalc.varFoamSettings.pathFromFile;
			clsItem.FrmFromFile.KeepRatio = buFoamCalc.varFoamSettings.FromFileKeepRatio;
			clsItem.FrmFromFile.Init();
			clsItem.FrmFromFile.ShowDialog();
		}
		if (!(clsItem.FrmFromFile.PropertiesForm.Result == DialogResult.OK || flag || flag2))
		{
			return;
		}
		List<buEntity> copiedEntities = new List<buEntity>();
		List<buEntity> refEntities = new List<buEntity>();
		List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
		buFoamCalc.varFoamSettings.pathFromFile = clsItem.FrmFromFile.Path;
		activePattern = new FoamPattern();
		if (!(!flag && !flag2))
		{
			if (flag)
			{
				buEntity.Copy(Entities, ref copiedEntities);
			}
		}
		else
		{
			for (int i = 0; i <= clsItem.FrmFromFile.viewport.Entities.Count - 1; i++)
			{
				buEntity copiedEntity = null;
				buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
				if (!(clsItem.FrmFromFile.viewport.Entities[i].GetType() == typeof(Circle)))
				{
					copiedEntities.Add(copiedEntity);
					continue;
				}
				buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
				buArc Arc = new buArc();
				buArc Arc2 = new buArc();
				buArc Arc3 = new buArc();
				buArc Arc4 = new buArc();
				clsInit.cVector5.CircletoFourArc((buCircle)copiedEntity, ref Arc, ref Arc2, ref Arc3, ref Arc4);
				copiedEntities.Add(Arc);
				copiedEntities.Add(Arc2);
				copiedEntities.Add(Arc3);
				copiedEntities.Add(Arc4);
			}
		}
		if (copiedEntities.Count <= 0)
		{
			if (EntitiesGroup.Count > 0)
			{
				activePattern.foamEntities.Clear();
				for (int j = 0; j <= EntitiesGroup.Count - 1; j++)
				{
					FoamEntities foamEntities = new FoamEntities();
					for (int k = 0; k <= EntitiesGroup[j].Count - 1; k++)
					{
						foamEntities.GroupEntity.Outside.Entities.Add(buEntity.Copy(EntitiesGroup[j][k]));
					}
					activePattern.foamEntities.Add(foamEntities);
				}
				buEntity.Copy(EntitiesGroup, ref SplitedEntitites);
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(SplitedEntitites, ref MinPoint, ref MaxPoint);
				clsInit.cVector5.Move(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0, ref SplitedEntitites);
				clsInit.cVector5.BoxSizeCalculate(SplitedEntitites, ref activePattern.BoxMinItem, ref activePattern.BoxMaxItem);
				activePattern.Width = Math.Round(activePattern.BoxMaxItem.X - activePattern.BoxMinItem.X, 3);
				activePattern.Height = Math.Round(activePattern.BoxMaxItem.Y - activePattern.BoxMinItem.Y, 3);
			}
		}
		else
		{
			FoamEntities foamEntities2 = new FoamEntities();
			buEntity.Copy(refEntities, ref activePattern.sortEntities);
			buEntity.Copy(copiedEntities, ref foamEntities2.GroupEntity.Outside.Entities);
			Point3D MinPoint2 = new Point3D();
			Point3D MaxPoint2 = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(foamEntities2.GroupEntity.Outside.Entities, ref MinPoint2, ref MaxPoint2);
			clsInit.cVector5.Move(0.0 - MinPoint2.X, 0.0 - MinPoint2.Y, 0.0, ref activePattern.sortEntities);
			clsInit.cVector5.Move(0.0 - MinPoint2.X, 0.0 - MinPoint2.Y, 0.0, ref foamEntities2.GroupEntity.Outside.Entities);
			clsInit.cVector5.BoxSizeCalculate(foamEntities2.GroupEntity.Outside.Entities, ref activePattern.BoxMinItem, ref activePattern.BoxMaxItem);
			activePattern.Width = Math.Round(activePattern.BoxMaxItem.X - activePattern.BoxMinItem.X, 3);
			activePattern.Height = Math.Round(activePattern.BoxMaxItem.Y - activePattern.BoxMinItem.Y, 3);
			SaveFoamFile();
			SortbuSettings sortbuSettings = new SortbuSettings();
			sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
			List<buEntity> SortedEntities = new List<buEntity>();
			clsInit.cVector5.SortEntitiesByRefPoint(foamEntities2.GroupEntity.Outside.Entities[0].Vertices[0], ref foamEntities2.GroupEntity.Outside.Entities, sortbuSettings, ref SortedEntities);
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			activePattern.foamEntities.Add(foamEntities2);
		}
		if (okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("PatternCommand", null);
		}
		int width = Screen.PrimaryScreen.Bounds.Width;
		buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Pattern;
		buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.FromDrawing;
		buFoamCalc.varFoamRunSettings.PatternOrjWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternOrjHeight = activePattern.Height;
		buFoamCalc.varFoamRunSettings.PatternHeight = activePattern.Height;
		frmPattern.Location = new System.Drawing.Point(width - frmPattern.Width - 40, 200);
		frmPattern.Init();
		BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
		if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
		{
			frmPattern.Show();
		}
		FoamUpdateArg foamUpdateArg = new FoamUpdateArg();
		foamUpdateArg.PatternSpaceHeight = buFoamCalc.varFoamSettings.PatternDistancesHeight;
		foamUpdateArg.PatternSpaceWidth = buFoamCalc.varFoamSettings.PatternDistancesWidth;
		OperationDataChanged(buFoamCalc.varFoamRunSettings, foamUpdateArg);
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			cmdPlaneXZ(ZoomFit: false);
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			cmdPlaneYZ(ZoomFit: false);
		}
	}

	public void cmdAddPattern(bool EditPattern = false)
	{
		clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmFromFile.Path = buFoamCalc.varFoamRunSettings.pathFoamPattern;
		clsItem.FrmFromFile.KeepRatio = buFoamCalc.varFoamSettings.FromFileKeepRatio;
		clsItem.FrmFromFile.ExtensionList.Clear();
		clsItem.FrmFromFile.ExtensionList.Add(".foampattern");
		clsItem.FrmFromFile.Init();
		clsItem.FrmFromFile.ShowDialog();
		if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		buFoamCalc.varFoamRunSettings.pathFoamPattern = clsItem.FrmFromFile.Path;
		clsInit.appCommand.Reset();
		if (!EditPattern)
		{
			List<buEntity> DrawEntities = new List<buEntity>();
			List<buEntity> SortedEntities = new List<buEntity>();
			FileInfo fileInfo = new FileInfo(clsItem.FrmFromFile.FileName);
			if (fileInfo.Exists)
			{
				if (okCommandWithTwoDataEventHandler_0 != null)
				{
					okCommandWithTwoDataEventHandler_0("PatternCommand", null);
				}
				clsInit.appEditor.OpenSortedEntities(fileInfo.FullName, ref DrawEntities, ref SortedEntities);
				activePattern = new FoamPattern();
				List<buEntity> copiedEntities = new List<buEntity>();
				buEntity.Copy(SortedEntities, ref activePattern.sortEntities);
				buEntity.Copy(DrawEntities, ref copiedEntities);
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(copiedEntities, ref MinPoint, ref MaxPoint);
				clsInit.cVector5.Move(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0, ref activePattern.sortEntities);
				clsInit.cVector5.Move(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0, ref copiedEntities);
				clsInit.cVector5.BoxSizeCalculate(copiedEntities, ref activePattern.BoxMinItem, ref activePattern.BoxMaxItem);
				activePattern.Width = Math.Round(activePattern.BoxMaxItem.X - activePattern.BoxMinItem.X, 3);
				activePattern.Height = Math.Round(activePattern.BoxMaxItem.Y - activePattern.BoxMinItem.Y, 3);
				SaveFoamFile();
				SortbuSettings sortbuSettings = new SortbuSettings();
				sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
				List<buEntity> SortedEntities2 = new List<buEntity>();
				List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
				clsInit.cVector5.SortEntitiesByRefPoint(copiedEntities[0].Vertices[0], ref copiedEntities, sortbuSettings, ref SortedEntities2);
				clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities2, ref SplitedEntitites);
				activePattern.foamEntities.Clear();
				for (int i = 0; i <= SplitedEntitites.Count - 1; i++)
				{
					List<Point3D> Points = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[i], ref Points);
					buCompositeCurve calcCompositeCurve = null;
					clsInit.cVector5.CreateCompositeCurveFromEntities(SplitedEntitites[i], ref calcCompositeCurve);
					FoamEntities foamEntities = new FoamEntities();
					foamEntities.GroupEntity.Outside.Entities.Add(calcCompositeCurve);
					activePattern.foamEntities.Add(foamEntities);
				}
				int width = Screen.PrimaryScreen.Bounds.Width;
				buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.Pattern;
				buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Pattern;
				buFoamCalc.varFoamRunSettings.PatternOrjWidth = activePattern.Width;
				buFoamCalc.varFoamRunSettings.PatternWidth = activePattern.Width;
				buFoamCalc.varFoamRunSettings.PatternOrjHeight = activePattern.Height;
				buFoamCalc.varFoamRunSettings.PatternHeight = activePattern.Height;
				ccVars.Action = actionTypeBU.foamWavePattern;
				if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
				{
					activePattern.planeName = FoamPlaneType.XZ;
				}
				if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
				{
					activePattern.planeName = FoamPlaneType.YZ;
				}
				varCalc.PatternHeight = activePattern.Height;
				varCalc.PatternWidth = activePattern.Width;
				varCalc.TypeFoam = FoamType.Pattern;
				varCalc.Operation = FoamOperationType.Pattern;
				varCalc.planeNames = activePattern.planeName;
				frmPattern.FoamSize = new SizeObject(activeFoam.Material.Size);
				frmPattern.Location = new System.Drawing.Point(width - frmPattern.Width - 40, 200);
				frmPattern.Init();
				BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
				if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
				{
					frmPattern.Show();
				}
				FoamUpdateArg foamUpdateArg = new FoamUpdateArg();
				foamUpdateArg.PatternSpaceHeight = buFoamCalc.varFoamSettings.PatternDistancesHeight;
				foamUpdateArg.PatternSpaceWidth = buFoamCalc.varFoamSettings.PatternDistancesWidth;
				OperationDataChanged(buFoamCalc.varFoamRunSettings, foamUpdateArg);
				if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
				{
					cmdPlaneXZ(ZoomFit: false);
				}
				if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
				{
					cmdPlaneYZ(ZoomFit: false);
				}
			}
		}
		else
		{
			if (clsItem.frmEditor == null)
			{
				clsItem.frmEditor = new F_Editor();
			}
			clsVar.varEditorRuntimeSet.isFoamMode = true;
			clsVar.varEditorRuntimeSet.isSewingMode = false;
			clsVar.varEditorRuntimeSet.isSketchMode = false;
			clsItem.frmEditor = new F_Editor();
			clsItem.frmEditor.OpenFileExtension.Add("All Supported Files (*.dxf,*.dwg,*.bucadV5)|*.dxf;*.dwg;*.bucadv5");
			clsItem.frmEditor.OpenFileExtension.Add("buCad Cad/Cam Files Ver5.X (*.bucadv5)|*.bucadv5");
			clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dxf)|*.dxf");
			clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dwg)|*.dwg");
			clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.frmEditor.fileNameSorted = clsItem.FrmFromFile.FileName;
			clsItem.frmEditor.Init();
			clsItem.frmEditor.ShowDialog(clsItem.FrmMain);
		}
	}

	public void cmdCreatePattern(List<Entity> refEntitites)
	{
		try
		{
			if (clsItem.frmEditor == null)
			{
				clsItem.frmEditor = new F_Editor();
			}
			clsVar.varEditorRuntimeSet.isFoamMode = true;
			clsVar.varEditorRuntimeSet.isSewingMode = false;
			clsVar.varEditorRuntimeSet.isSketchMode = false;
			clsItem.frmEditor = new F_Editor();
			clsItem.frmEditor.OpenFileExtension.Add("All Supported Files (*.dxf,*.dwg,*.bucadV5)|*.dxf;*.dwg;*.bucadv5");
			clsItem.frmEditor.OpenFileExtension.Add("buCad Cad/Cam Files Ver5.X (*.bucadv5)|*.bucadv5");
			clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dxf)|*.dxf");
			clsItem.frmEditor.OpenFileExtension.Add("Autocad Files (*.dwg)|*.dwg");
			clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			if (refEntitites != null && refEntitites.Count > 0)
			{
				clsItem.frmEditor.entitiesExisting.AddRange(refEntitites);
			}
			clsItem.frmEditor.Init();
			if (clsItem.FrmMain != null)
			{
				clsItem.frmEditor.ShowDialog(clsItem.FrmMain);
			}
			else
			{
				clsItem.frmEditor.ShowDialog();
			}
			SaveFoamFile();
			clsInit.appEditor.SaveEditorFile();
			new List<buEntity>();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCreatePatternFromFile()
	{
		clsItem.FrmFromFile.ExtensionList.Clear();
		clsItem.FrmFromFile.ExtensionList.Add(".dxf");
		clsItem.FrmFromFile.ExtensionList.Add(".dwg");
		clsItem.FrmFromFile.ExtensionList.Add(".bucadv5");
		clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmFromFile.Path = buFoamCalc.varFoamSettings.pathFromFile;
		clsItem.FrmFromFile.KeepRatio = buFoamCalc.varFoamSettings.FromFileKeepRatio;
		clsItem.FrmFromFile.Init();
		clsItem.FrmFromFile.ShowDialog();
		if (clsItem.FrmFromFile.PropertiesForm.Result == DialogResult.OK)
		{
			List<Entity> copiedEntity = new List<Entity>();
			new List<Entity>();
			buEntity.Copy(clsItem.FrmFromFile.viewport.Entities, ref copiedEntity);
			clsInit.cVector5.CheckEntities(new CheckEntitesOption(), ref copiedEntity);
			if (copiedEntity.Count > 0)
			{
				cmdCreatePattern(copiedEntity);
			}
		}
	}

	public void cmdCreatePatternFromSketch(bool isPattern)
	{
		clsItem.frmEditor = new F_Editor();
		clsVar.varEditorRuntimeSet.isFoamMode = false;
		clsVar.varEditorRuntimeSet.isSewingMode = false;
		clsVar.varEditorRuntimeSet.isSketchMode = true;
		clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.frmEditor.Init();
		clsItem.frmEditor.ShowDialog();
		List<Entity> copiedEnt = new List<Entity>();
		buVector5.CopyEntities(clsItem.frmEditor.viewport.Entities, ref copiedEnt);
		if (clsItem.frmEditor.viewport.CurrentSketch.Editing)
		{
			for (int num = copiedEnt.Count - 1; num >= 0; num--)
			{
				if (!(copiedEnt[num] is SketchEntity))
				{
					if (!(copiedEnt[num] is devDept.Eyeshot.Entities.Point))
					{
						if (copiedEnt[num] is Dimension)
						{
							copiedEnt.RemoveAt(num);
						}
					}
					else
					{
						copiedEnt.RemoveAt(num);
					}
				}
				else
				{
					copiedEnt.RemoveAt(num);
				}
			}
		}
		if (copiedEnt.Count > 0)
		{
			if (!isPattern)
			{
				List<buEntity> copiedEntities = new List<buEntity>();
				buEntity.Copy(copiedEnt, ref copiedEntities);
				cmdAddFromFile(copiedEntities, null);
				copiedEnt.Clear();
				copiedEntities.Clear();
			}
			else
			{
				cmdCreatePattern(copiedEnt);
				copiedEnt.Clear();
			}
		}
	}

	public void cmdCreatePatternFromLibrary(bool isPattern)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(clsVar.varLibrary.pathLibrary);
		if (!directoryInfo.Exists)
		{
			clsVar.varLibrary.pathLibrary = AppPath.Base + "\\Library";
		}
		clsInit.appCommand.cmdLibDraw();
		if (clsItem.FrmLibraryDraw.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		clsVar5.shapeCreatePar.entitiesCurve = new List<buEntity>();
		SketchAnalyseData AnalyseData = new SketchAnalyseData();
		clsInit.appEditor.AnalyseSketchEntity(clsLibrary.LibraryEntities, new SketchAnalyseSetData(clsVar5.ShapeDataParameters.FreeDrawDepth), ref AnalyseData);
		if (AnalyseData.AnalyseEntities.Count <= 0)
		{
			return;
		}
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= AnalyseData.AnalyseEntities.Count - 1; i++)
		{
			if (!(AnalyseData.AnalyseEntities[i].GetType() == typeof(buCompositeCurve)))
			{
				Entity copiedEntity = null;
				buEntity.Copy(AnalyseData.AnalyseEntities[i], ref copiedEntity);
				list.Add(copiedEntity);
				continue;
			}
			buCompositeCurve buCompositeCurve2 = AnalyseData.AnalyseEntities[i] as buCompositeCurve;
			for (int j = 0; j <= buCompositeCurve2.CurveList.Count - 1; j++)
			{
				Entity copiedEntity2 = null;
				buEntity.Copy(buCompositeCurve2.CurveList[j], ref copiedEntity2);
				list.Add(copiedEntity2);
			}
		}
		if (list.Count > 0)
		{
			if (!isPattern)
			{
				List<buEntity> copiedEntities = new List<buEntity>();
				buEntity.Copy(list, ref copiedEntities);
				cmdAddFromFile(copiedEntities, null);
				list.Clear();
				copiedEntities.Clear();
			}
			else
			{
				cmdCreatePattern(list);
				list.Clear();
			}
		}
	}

	public void cmdWaveMenu()
	{
		F_FoamWaveMenu f_FoamWaveMenu = new F_FoamWaveMenu();
		f_FoamWaveMenu.foamType = FoamType.SlicesVertical;
		f_FoamWaveMenu.Init();
		f_FoamWaveMenu.ShowDialog();
		if (f_FoamWaveMenu.PropertiesForm.Result == DialogResult.OK)
		{
			if (f_FoamWaveMenu.foamType != FoamType.SlicesHorizontal)
			{
				cmdWaveForm(f_FoamWaveMenu.foamType);
			}
			else
			{
				cmdWaveSliceFormHorizontal();
			}
		}
	}

	public void cmdWaveForm(FoamType Type)
	{
		activePattern = new FoamPattern();
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			activePattern.planeName = FoamPlaneType.XZ;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			activePattern.planeName = FoamPlaneType.YZ;
		}
		clsInit.appCommand.Reset();
		int width = Screen.PrimaryScreen.Bounds.Width;
		buFoamCalc.varFoamRunSettings.TypeFoam = Type;
		buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Wave;
		buFoamCalc.varFoamRunSettings.PatternOrjWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternOrjHeight = activePattern.Height;
		buFoamCalc.varFoamRunSettings.PatternHeight = activePattern.Height;
		BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
		if (Type == FoamType.VForm)
		{
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormVShapeBaseHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormVShapeHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormVShapeWidth;
		}
		if (Type == FoamType.Pyramid)
		{
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeBaseHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeWidth;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonCount = buFoamCalc.varFoamRunSettings.WaveFormPyramidShapeCount;
		}
		if (Type == FoamType.UForm)
		{
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormUShapeBaseHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormUShapeHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormUShapeWidth;
		}
		if (Type == FoamType.CForm)
		{
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormCShapeBaseHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormCShapeHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormCShapeWidth;
		}
		if (Type == FoamType.SForm)
		{
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormSShapeBaseHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormSShapeHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormSShapeWidth;
		}
		if (Type == FoamType.ZForm)
		{
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormZShapeBaseHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormZShapeHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormZShapeWidth;
		}
		if (Type == FoamType.Rectangle)
		{
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight = buFoamCalc.varFoamRunSettings.WaveFormRectShapeBaseHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight = buFoamCalc.varFoamRunSettings.WaveFormRectShapeHeight;
			buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormRectShapeWidth;
		}
		if (okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("WaveCommand", null);
		}
		buFoamCalc.varFoamRunSettings.TypeFoam = Type;
		ccVars.Action = actionTypeBU.foamWaveShape;
		frmWave.Location = new System.Drawing.Point(width - frmWave.Width - 40, 200);
		frmWave.FoamSize = new SizeObject(activeFoam.Material.Size);
		frmWave.Init();
		if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
		{
			frmWave.Show();
		}
		FoamUpdateArg data = new FoamUpdateArg();
		OperationDataChanged(buFoamCalc.varFoamRunSettings, data);
	}

	public void cmdWaveSliceFormHorizontal()
	{
		activePattern = new FoamPattern();
		int width = Screen.PrimaryScreen.Bounds.Width;
		clsInit.appCommand.Reset();
		buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.SlicesHorizontal;
		buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Slice;
		buFoamCalc.varFoamRunSettings.PatternOrjWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternOrjHeight = activePattern.Height;
		buFoamCalc.varFoamRunSettings.PatternHeight = activePattern.Height;
		BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			activePattern.planeName = FoamPlaneType.XZ;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			activePattern.planeName = FoamPlaneType.YZ;
		}
		if (okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("SliceCommand", null);
		}
		frmSlice.Location = new System.Drawing.Point(width - frmSlice.Width - 40, 200);
		frmSlice.FoamSize = new SizeObject(activeFoam.Material.Size);
		frmSlice.Init();
		ccVars.Action = actionTypeBU.foamWaveSlice;
		if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
		{
			frmSlice.Show();
		}
		FoamUpdateArg data = new FoamUpdateArg();
		OperationDataChanged(buFoamCalc.varFoamRunSettings, data);
	}

	public void cmdWaveSliceFormVerical()
	{
		activePattern = new FoamPattern();
		int width = Screen.PrimaryScreen.Bounds.Width;
		clsInit.appCommand.Reset();
		varCalc.isVertical = true;
		buFoamCalc.varFoamRunSettings.TypeFoam = FoamType.SlicesVertical;
		buFoamCalc.varFoamRunSettings.Operation = FoamOperationType.Slice;
		buFoamCalc.varFoamRunSettings.PatternOrjWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternWidth = activePattern.Width;
		buFoamCalc.varFoamRunSettings.PatternOrjHeight = activePattern.Height;
		buFoamCalc.varFoamRunSettings.PatternHeight = activePattern.Height;
		BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			activePattern.planeName = FoamPlaneType.XZ;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			activePattern.planeName = FoamPlaneType.YZ;
		}
		if (okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("SliceCommand", null);
		}
		frmSlice.Location = new System.Drawing.Point(width - frmSlice.Width - 40, 200);
		frmSlice.FoamSize = new SizeObject(activeFoam.Material.Size);
		frmSlice.Init();
		ccVars.Action = actionTypeBU.foamWaveSlice;
		if (buFoamCalc.varFoamSettings.OperationWindow == ProfileOperationWindowType.FormPage)
		{
			frmSlice.Show();
		}
		FoamUpdateArg data = new FoamUpdateArg();
		OperationDataChanged(buFoamCalc.varFoamRunSettings, data);
	}

	public void cmdWaveSingleLine()
	{
	}

	public void cmdDeleteAll()
	{
		if (activeFoam != null && buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[15]) == DialogResult.Yes)
		{
			doDeleteAllBlocks();
		}
	}

	public void cmdUndoPattern()
	{
		if (foamActiveBlock_0.Plane == FoamPlaneType.XZ)
		{
			int num = activeFoam.BlockXZ.Count - 1;
			if ((num >= 0) & (num <= activeFoam.BlockXZ.Count - 1))
			{
				activeFoam.BlockXZ.RemoveAt(num);
				activeFoam.sortedEntitiesXZ.Clear();
				activeFoam.sortedEntitiesYZ.Clear();
				activeFoam.CamXZ = new camTp();
				activeFoam.CamYZ = new camTp();
				activeFoam.isGCodeCreated = false;
			}
		}
		if (foamActiveBlock_0.Plane == FoamPlaneType.YZ)
		{
			int num2 = activeFoam.BlockXZ.Count - 1;
			if ((num2 >= 0) & (num2 <= activeFoam.BlockYZ.Count - 1))
			{
				activeFoam.BlockYZ.RemoveAt(num2);
				activeFoam.sortedEntitiesXZ.Clear();
				activeFoam.sortedEntitiesYZ.Clear();
				activeFoam.CamXZ = new camTp();
				activeFoam.CamYZ = new camTp();
				activeFoam.isGCodeCreated = false;
			}
		}
		JobUpdate(FillPages: true, "", null, -1);
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
	}

	public void cmdSpeedTable()
	{
		F_FoamSpeedList f_FoamSpeedList = new F_FoamSpeedList();
		f_FoamSpeedList.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
		f_FoamSpeedList.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
		f_FoamSpeedList.RadiusFeedList.Clear();
		for (int i = 0; i <= buFoamCalc.RadiusFeedList.Count - 1; i++)
		{
			f_FoamSpeedList.RadiusFeedList.Add(new camRadiusFeed(buFoamCalc.RadiusFeedList[i]));
		}
		for (int j = 0; j <= buFoamCalc.LengthFeedList.Count - 1; j++)
		{
			f_FoamSpeedList.LengthFeedList.Add(new camLengthFeed(buFoamCalc.LengthFeedList[j]));
		}
		f_FoamSpeedList.Init();
		f_FoamSpeedList.ShowDialog();
		if (f_FoamSpeedList.PropertiesForm.Result == DialogResult.OK)
		{
			buFoamCalc.RadiusFeedList.Clear();
			for (int k = 0; k <= f_FoamSpeedList.RadiusFeedList.Count - 1; k++)
			{
				buFoamCalc.RadiusFeedList.Add(new camRadiusFeed(f_FoamSpeedList.RadiusFeedList[k]));
			}
			buFoamCalc.LengthFeedList.Clear();
			for (int l = 0; l <= f_FoamSpeedList.LengthFeedList.Count - 1; l++)
			{
				buFoamCalc.LengthFeedList.Add(new camLengthFeed(f_FoamSpeedList.LengthFeedList[l]));
			}
			SaveFoamFile();
		}
	}

	public void cmdViewObject()
	{
		if (ccVars.Pages.Count > 0)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
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
		if (text == clsItem.FrmFoamJob.mnu_foamedit.Name && activeFoam != null)
		{
			cmdNewMaterial(activeFoam, SkipForm: false, Editing: true);
		}
		if (text == clsItem.FrmFoamJob.mnu_foamrename.Name && activeFoam != null)
		{
			DialogBoxText dialogBoxText = new DialogBoxText();
			dialogBoxText.Caption = AppLanguage.CadCamDynamic[106] + " " + AppLanguage.CadCamDynamic[40];
			dialogBoxText.Text = AppLanguage.CadCamDynamic[106] + " " + AppLanguage.CadCamDynamic[40];
			dialogBoxText.Init(activeFoam.ItemName);
			dialogBoxText.ShowDialog();
			if (dialogBoxText.Result == DialogResult.OK)
			{
				activeFoam.ItemName = dialogBoxText.Value;
				((TreeNodeSettings)treejobs.Nodes[0]).Text = clsInit.cFoamCut.JobItemName(activeFoam);
			}
		}
		if (text == clsItem.FrmFoamJob.mnu_foamdelete.Name && activeFoam != null && buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[22]) == DialogResult.Yes)
		{
			activeFoam = null;
			CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: false));
		}
		if (text == clsItem.FrmFoamJob.mnu_editblock.Name)
		{
			doEditBlock();
		}
		if (text == clsItem.FrmFoamJob.mnu_renameblock.Name && ((activeFoam != null) & (foamActiveBlock_0.BlockIndex >= 0)))
		{
			DialogBoxText dialogBoxText2 = new DialogBoxText();
			dialogBoxText2.Caption = AppLanguage.CadCamDynamic[106] + " " + AppLanguage.CadCamDynamic[40];
			dialogBoxText2.Text = AppLanguage.CadCamDynamic[106] + " " + AppLanguage.CadCamDynamic[40];
			if (foamActiveBlock_0.Plane == FoamPlaneType.XZ)
			{
				dialogBoxText2.Init(activeFoam.BlockXZ[foamActiveBlock_0.BlockIndex].BlockName);
			}
			if (foamActiveBlock_0.Plane == FoamPlaneType.YZ)
			{
				dialogBoxText2.Init(activeFoam.BlockYZ[foamActiveBlock_0.BlockIndex].BlockName);
			}
			dialogBoxText2.ShowDialog();
			if (dialogBoxText2.Result == DialogResult.OK)
			{
				if (foamActiveBlock_0.Plane == FoamPlaneType.XZ)
				{
					activeFoam.BlockXZ[foamActiveBlock_0.BlockIndex].BlockName = dialogBoxText2.Value;
					((TreeNodeSettings)treejobs.Nodes[0].Nodes[0].Nodes[foamActiveBlock_0.BlockIndex]).Text = clsInit.cFoamCut.JobBlockName(activeFoam.BlockXZ[foamActiveBlock_0.BlockIndex]);
				}
				if (foamActiveBlock_0.Plane == FoamPlaneType.YZ)
				{
					activeFoam.BlockYZ[foamActiveBlock_0.BlockIndex].BlockName = dialogBoxText2.Value;
					((TreeNodeSettings)treejobs.Nodes[0].Nodes[0].Nodes[foamActiveBlock_0.BlockIndex]).Text = clsInit.cFoamCut.JobBlockName(activeFoam.BlockYZ[foamActiveBlock_0.BlockIndex]);
				}
			}
		}
		if (text == clsItem.FrmFoamJob.mnu_deleteblock.Name && ((activeFoam != null) & (foamActiveBlock_0.BlockIndex >= 0)) && buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[9]) == DialogResult.Yes)
		{
			doDeleteBlocks(foamActiveBlock_0.BlockIndex);
		}
		if (text == clsItem.FrmFoamJob.mnu_deleteallblock.Name && activeFoam != null && buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[15]) == DialogResult.Yes)
		{
			doDeleteAllBlocks();
		}
		if (text == clsItem.FrmFoamJob.mnu_deleteXZselection.Name)
		{
			doDeleteSelection(FoamPlaneType.XZ);
		}
		if (text == clsItem.FrmFoamJob.mnu_deleteYZselection.Name)
		{
			doDeleteSelection(FoamPlaneType.YZ);
		}
		if (text == clsItem.FrmFoamJob.mnu_redraw.Name && activeFoam != null)
		{
			CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
		}
		if (text == clsItem.FrmFoamJob.btn_viewfront.Name)
		{
			clsItem.ModelMainPreview.SetView(viewType.Front);
			clsItem.ModelMainPreview.Invalidate();
		}
		if (text == clsItem.FrmFoamJob.btn_viewleft.Name)
		{
			clsItem.ModelMainPreview.SetView(viewType.Right);
			clsItem.ModelMainPreview.Invalidate();
		}
		if (text == clsItem.FrmFoamJob.btn_viewiso.Name)
		{
			clsItem.ModelMainPreview.SetView(viewType.Isometric);
			clsItem.ModelMainPreview.Invalidate();
		}
		if (text == clsItem.FrmFoamJob.btn_zoomfit.Name)
		{
			clsItem.ModelMainPreview.ZoomFit();
			clsItem.ModelMainPreview.Invalidate();
		}
	}

	public void AddLeadInLeadOut(ref FoamSortGroup sortGroup, FoamPlaneType refPlane, FoamSequenceHor SequenceType)
	{
		Point3D pntEnd = new Point3D();
		Point3D pntStart = new Point3D();
		if (sortGroup.sortEntities.Count <= 0)
		{
			return;
		}
		if (sortGroup.Direction == NormalReverse.Normal && sortGroup.sortEntities[0].Count > 0)
		{
			if (buFoamCalc.varFoamSettings.LeadInLength > 0.1)
			{
				clsInit.cVector5.GetEntityStartPointByCamDirection(sortGroup.sortEntities[0][0], ref pntStart);
				if (refPlane == FoamPlaneType.XZ)
				{
					Point3D point3D = new Point3D(pntStart.X - buFoamCalc.varFoamSettings.LeadInLength, pntStart.Y, pntStart.Z);
					Point3D end = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
					if (point3D.X > sortGroup.MinPoint.X)
					{
						point3D.X = sortGroup.MinPoint.X - buFoamCalc.varFoamSettings.LeadInLength;
					}
					buLine buLine2 = new buLine(point3D, end);
					buLine2.typeDefination = entityTypeDefination.CamLeadin;
					sortGroup.sortEntities[0].Insert(0, buLine2);
				}
				if (refPlane == FoamPlaneType.YZ)
				{
					Point3D point3D2 = new Point3D(pntStart.X, pntStart.Y - buFoamCalc.varFoamSettings.LeadInLength, pntStart.Z);
					Point3D end2 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
					if (point3D2.Y > sortGroup.MinPoint.Y)
					{
						point3D2.Y = sortGroup.MinPoint.Y - buFoamCalc.varFoamSettings.LeadInLength;
					}
					buLine buLine3 = new buLine(point3D2, end2);
					buLine3.typeDefination = entityTypeDefination.CamLeadin;
					sortGroup.sortEntities[0].Insert(0, buLine3);
				}
			}
			if (buFoamCalc.varFoamSettings.LeadOutLength > 0.1)
			{
				clsInit.cVector5.GetEntityEndPointByCamDirection(sortGroup.sortEntities[sortGroup.sortEntities.Count - 1][sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Count - 1], ref pntEnd);
				if (refPlane == FoamPlaneType.XZ)
				{
					Point3D start = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
					Point3D point3D3 = new Point3D(pntEnd.X + buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Y, pntEnd.Z);
					if (point3D3.X < sortGroup.MaxPoint.X)
					{
						point3D3.X = sortGroup.MaxPoint.X + buFoamCalc.varFoamSettings.LeadOutLength;
					}
					if (SequenceType == FoamSequenceHor.HorizontalStartThenStartDirect)
					{
						point3D3 = new Point3D(pntEnd.X - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Y, pntEnd.Z);
					}
					buLine buLine4 = new buLine(start, point3D3);
					buLine4.typeDefination = entityTypeDefination.CamLeadOut;
					sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add(buLine4);
				}
				if (refPlane == FoamPlaneType.YZ)
				{
					Point3D start2 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
					Point3D point3D4 = new Point3D(pntEnd.X, pntEnd.Y + buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Z);
					if (point3D4.Y < sortGroup.MaxPoint.Y)
					{
						point3D4.Y = sortGroup.MaxPoint.Y + buFoamCalc.varFoamSettings.LeadOutLength;
					}
					if (SequenceType == FoamSequenceHor.HorizontalStartThenStartDirect)
					{
						point3D4 = new Point3D(pntEnd.X, pntEnd.Y - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Z);
					}
					buLine buLine5 = new buLine(start2, point3D4);
					buLine5.typeDefination = entityTypeDefination.CamLeadOut;
					sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add(buLine5);
				}
			}
		}
		if (sortGroup.Direction != NormalReverse.Reverse || sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Count <= 0)
		{
			return;
		}
		if (buFoamCalc.varFoamSettings.LeadInLength > 0.1)
		{
			clsInit.cVector5.GetEntityStartPointByCamDirection(sortGroup.sortEntities[0][0], ref pntStart);
			if (refPlane == FoamPlaneType.XZ)
			{
				Point3D point3D5 = new Point3D(pntStart.X + buFoamCalc.varFoamSettings.LeadInLength, pntStart.Y, pntStart.Z);
				Point3D end3 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
				if (point3D5.X < sortGroup.MaxPoint.X)
				{
					point3D5.X = sortGroup.MaxPoint.X + buFoamCalc.varFoamSettings.LeadInLength;
				}
				buLine buLine6 = new buLine(point3D5, end3);
				buLine6.typeDefination = entityTypeDefination.CamLeadin;
				sortGroup.sortEntities[0].Insert(0, buLine6);
			}
			if (refPlane == FoamPlaneType.YZ)
			{
				Point3D point3D6 = new Point3D(pntStart.X, pntStart.Y + buFoamCalc.varFoamSettings.LeadInLength, pntStart.Z);
				Point3D end4 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
				if (point3D6.Y < sortGroup.MaxPoint.Y)
				{
					point3D6.Y = sortGroup.MaxPoint.Y + buFoamCalc.varFoamSettings.LeadInLength;
				}
				buLine buLine7 = new buLine(point3D6, end4);
				buLine7.typeDefination = entityTypeDefination.CamLeadin;
				sortGroup.sortEntities[0].Insert(0, buLine7);
			}
		}
		if (!(buFoamCalc.varFoamSettings.LeadOutLength > 0.1))
		{
			return;
		}
		clsInit.cVector5.GetEntityEndPointByCamDirection(sortGroup.sortEntities[sortGroup.sortEntities.Count - 1][sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Count - 1], ref pntEnd);
		if (refPlane == FoamPlaneType.XZ)
		{
			Point3D start3 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
			Point3D point3D7 = new Point3D(pntEnd.X - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Y, pntEnd.Z);
			if (point3D7.X > sortGroup.MinPoint.X)
			{
				point3D7.X = sortGroup.MinPoint.X - buFoamCalc.varFoamSettings.LeadOutLength;
			}
			buLine buLine8 = new buLine(start3, point3D7);
			buLine8.typeDefination = entityTypeDefination.CamLeadOut;
			sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add(buLine8);
		}
		if (refPlane == FoamPlaneType.YZ)
		{
			Point3D start4 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
			Point3D point3D8 = new Point3D(pntEnd.X, pntEnd.Y - buFoamCalc.varFoamSettings.LeadOutLength, pntEnd.Z);
			if (point3D8.Y > sortGroup.MinPoint.Y)
			{
				point3D8.Y = sortGroup.MinPoint.Y - buFoamCalc.varFoamSettings.LeadOutLength;
			}
			buLine buLine9 = new buLine(start4, point3D8);
			buLine9.typeDefination = entityTypeDefination.CamLeadOut;
			sortGroup.sortEntities[sortGroup.sortEntities.Count - 1].Add(buLine9);
		}
	}

	public void GetPatternSortHorizontal(FoamBlock FoamBlock, FoamBlock FoamBlockNext, FoamPlaneType refPlane, ref int Cnt, ref List<FoamSortGroup> patternSortEnt)
	{
		List<Point3D> list = new List<Point3D>();
		FoamSortGroup sortGroup = new FoamSortGroup();
		sortGroup.PlaneType = refPlane;
		if (FoamBlock.Pattern.Count <= 0)
		{
			return;
		}
		int verticalIndex = FoamBlock.Pattern[0].VerticalIndex;
		for (int i = 0; i <= FoamBlock.Pattern.Count - 1; i++)
		{
			if (verticalIndex == FoamBlock.Pattern[i].VerticalIndex)
			{
				List<buEntity> copiedEntities = new List<buEntity>();
				if (!((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd)))
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities);
					sortGroup.Direction = NormalReverse.Normal;
				}
				else
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities);
					sortGroup.Direction = NormalReverse.Reverse;
				}
				sortGroup.sortEntities.Add(copiedEntities);
			}
			else
			{
				if ((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd) & (sortGroup.Direction == NormalReverse.Reverse))
				{
					sortGroup.sortEntities.Reverse();
					sortGroup.Direction = NormalReverse.Reverse;
					for (int j = 0; j <= sortGroup.sortEntities.Count - 1; j++)
					{
						List<buEntity> ChangedEntities = sortGroup.sortEntities[j];
						clsInit.cVector5.ChangeEntitiesDirection(ref ChangedEntities);
						for (int k = 0; k <= sortGroup.sortEntities[j].Count - 1; k++)
						{
							if (sortGroup.sortEntities[j][k].typeDefination != entityTypeDefination.CamLeadin)
							{
								if (sortGroup.sortEntities[j][k].typeDefination == entityTypeDefination.CamLeadOut)
								{
									sortGroup.sortEntities[j][k].typeDefination = entityTypeDefination.CamLeadin;
								}
							}
							else
							{
								sortGroup.sortEntities[j][k].typeDefination = entityTypeDefination.CamLeadOut;
							}
						}
					}
				}
				clsInit.cVector5.BoxSizeCalculate(list, ref sortGroup.MinPoint, ref sortGroup.MaxPoint);
				AddLeadInLeadOut(ref sortGroup, refPlane, buFoamCalc.varFoamSettings.SequenceHorizontal);
				patternSortEnt.Add(sortGroup);
				sortGroup = new FoamSortGroup();
				sortGroup.PlaneType = refPlane;
				list.Clear();
				list = new List<Point3D>();
				Cnt++;
				List<buEntity> copiedEntities2 = new List<buEntity>();
				if (!((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd)))
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities2);
				}
				else
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities2);
					sortGroup.Direction = NormalReverse.Reverse;
				}
				sortGroup.sortEntities.Add(copiedEntities2);
				verticalIndex = FoamBlock.Pattern[i].VerticalIndex;
			}
			list.Add(buVector5.ToPoint3D(FoamBlock.Pattern[i].BoxMinItem));
			list.Add(buVector5.ToPoint3D(FoamBlock.Pattern[i].BoxMaxItem));
		}
		if (sortGroup.sortEntities.Count <= 0)
		{
			return;
		}
		if ((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd) & (sortGroup.Direction == NormalReverse.Reverse))
		{
			sortGroup.sortEntities.Reverse();
			for (int l = 0; l <= sortGroup.sortEntities.Count - 1; l++)
			{
				List<buEntity> ChangedEntities2 = sortGroup.sortEntities[l];
				clsInit.cVector5.ChangeEntitiesDirection(ref ChangedEntities2);
			}
			sortGroup.Direction = NormalReverse.Reverse;
		}
		clsInit.cVector5.BoxSizeCalculate(list, ref sortGroup.MinPoint, ref sortGroup.MaxPoint);
		AddLeadInLeadOut(ref sortGroup, refPlane, buFoamCalc.varFoamSettings.SequenceHorizontal);
		patternSortEnt.Add(sortGroup);
		sortGroup = new FoamSortGroup();
		sortGroup.PlaneType = refPlane;
		Cnt++;
	}

	public void GetPatternSortVertical(FoamBlock FoamBlock, FoamBlock FoamBlockNext, FoamPlaneType refPlane, ref int Cnt, ref List<FoamSortGroup> patternSortEnt)
	{
		List<Point3D> list = new List<Point3D>();
		FoamSortGroup foamSortGroup = new FoamSortGroup();
		foamSortGroup.PlaneType = refPlane;
		if (FoamBlock.Pattern.Count <= 0)
		{
			return;
		}
		int num = FoamBlock.Pattern[0].HorizontalIndex;
		for (int i = 0; i <= FoamBlock.Pattern.Count - 1; i++)
		{
			if (num == FoamBlock.Pattern[i].HorizontalIndex)
			{
				List<buEntity> copiedEntities = new List<buEntity>();
				if (!((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd)))
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities);
					foamSortGroup.Direction = NormalReverse.Normal;
				}
				else
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities);
					foamSortGroup.Direction = NormalReverse.Reverse;
				}
				foamSortGroup.sortEntities.Add(copiedEntities);
			}
			else
			{
				if ((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd) & (foamSortGroup.Direction == NormalReverse.Reverse))
				{
					foamSortGroup.sortEntities.Reverse();
					foamSortGroup.Direction = NormalReverse.Reverse;
					for (int j = 0; j <= foamSortGroup.sortEntities.Count - 1; j++)
					{
						List<buEntity> ChangedEntities = foamSortGroup.sortEntities[j];
						clsInit.cVector5.ChangeEntitiesDirection(ref ChangedEntities);
						for (int k = 0; k <= foamSortGroup.sortEntities[j].Count - 1; k++)
						{
							if (foamSortGroup.sortEntities[j][k].typeDefination != entityTypeDefination.CamLeadin)
							{
								if (foamSortGroup.sortEntities[j][k].typeDefination == entityTypeDefination.CamLeadOut)
								{
									foamSortGroup.sortEntities[j][k].typeDefination = entityTypeDefination.CamLeadin;
								}
							}
							else
							{
								foamSortGroup.sortEntities[j][k].typeDefination = entityTypeDefination.CamLeadOut;
							}
						}
					}
				}
				clsInit.cVector5.BoxSizeCalculate(list, ref foamSortGroup.MinPoint, ref foamSortGroup.MaxPoint);
				patternSortEnt.Add(foamSortGroup);
				foamSortGroup = new FoamSortGroup();
				foamSortGroup.PlaneType = refPlane;
				list.Clear();
				list = new List<Point3D>();
				Cnt++;
				List<buEntity> copiedEntities2 = new List<buEntity>();
				if (!((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd)))
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities2);
				}
				else
				{
					buEntity.Copy(FoamBlock.Pattern[i].sortEntities, ref copiedEntities2);
					foamSortGroup.Direction = NormalReverse.Reverse;
				}
				foamSortGroup.sortEntities.Add(copiedEntities2);
				num = FoamBlock.Pattern[i].VerticalIndex;
			}
			list.Add(buVector5.ToPoint3D(FoamBlock.Pattern[i].BoxMinItem));
			list.Add(buVector5.ToPoint3D(FoamBlock.Pattern[i].BoxMaxItem));
		}
		if (foamSortGroup.sortEntities.Count <= 0)
		{
			return;
		}
		if ((Cnt % 2 == 1) & (buFoamCalc.varFoamSettings.SequenceVertical == FoamSequenceVer.VerticalStartThenEnd) & (foamSortGroup.Direction == NormalReverse.Reverse))
		{
			foamSortGroup.sortEntities.Reverse();
			for (int l = 0; l <= foamSortGroup.sortEntities.Count - 1; l++)
			{
				List<buEntity> ChangedEntities2 = foamSortGroup.sortEntities[l];
				clsInit.cVector5.ChangeEntitiesDirection(ref ChangedEntities2);
			}
			foamSortGroup.Direction = NormalReverse.Reverse;
		}
		clsInit.cVector5.BoxSizeCalculate(list, ref foamSortGroup.MinPoint, ref foamSortGroup.MaxPoint);
		patternSortEnt.Add(foamSortGroup);
		foamSortGroup = new FoamSortGroup();
		foamSortGroup.PlaneType = refPlane;
		Cnt++;
	}

	public void ConnectPattertSort(List<FoamSortGroup> patternSortEnt, FoamPlaneType refPlane, ref List<buEntity> sortedEntities)
	{
		Point3D pntStart = new Point3D();
		Point3D pntEnd = new Point3D();
		buLine buLine2 = null;
		for (int i = 0; i <= patternSortEnt.Count - 1; i++)
		{
			if (i == 0)
			{
				clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[i].sortEntities[0][0], ref pntStart);
				if (patternSortEnt[i].Direction == NormalReverse.Normal)
				{
					if (refPlane == FoamPlaneType.XZ && pntStart.X > activeFoam.MinPoint.X)
					{
						Point3D start = new Point3D(activeFoam.MinPoint.X, pntStart.Y, pntStart.Z);
						Point3D end = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
						buLine buLine3 = new buLine(start, end);
						buLine3.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine3);
					}
					if (refPlane == FoamPlaneType.YZ && pntStart.Y > activeFoam.MinPoint.Y)
					{
						Point3D start2 = new Point3D(pntStart.X, activeFoam.MinPoint.Y, pntStart.Z);
						Point3D end2 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
						buLine buLine4 = new buLine(start2, end2);
						buLine4.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine4);
					}
				}
			}
			if (i > 0)
			{
				if (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenEnd)
				{
					clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
					clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[i].sortEntities[0][0], ref pntStart);
					if (refPlane == FoamPlaneType.XZ && !buCompare5.EQ(pntEnd.X, pntStart.X))
					{
						if (patternSortEnt[i].Direction == NormalReverse.Reverse && pntStart.X > pntEnd.X)
						{
							buLine2 = new buLine(pntEnd, new Point3D(pntStart.X, pntEnd.Y, pntEnd.Z));
							buLine2.typeDefination = entityTypeDefination.Connection;
							sortedEntities.Add(buLine2);
							clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
						}
						if (patternSortEnt[i].Direction == NormalReverse.Normal && pntEnd.X > pntStart.X)
						{
							buLine2 = new buLine(pntEnd, new Point3D(pntStart.X, pntEnd.Y, pntEnd.Z));
							buLine2.typeDefination = entityTypeDefination.Connection;
							sortedEntities.Add(buLine2);
							clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
						}
						buLine2 = new buLine(pntEnd, new Point3D(pntEnd.X, pntStart.Y, pntStart.Z));
						buLine2.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine2);
						clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
					}
					if (refPlane == FoamPlaneType.YZ && !buCompare5.EQ(pntEnd.Y, pntStart.Y))
					{
						buLine buLine5 = new buLine(pntEnd, new Point3D(pntStart.X, pntEnd.Y, pntStart.Z));
						buLine5.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine5);
						clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
					}
					buLine buLine6 = new buLine(pntEnd, pntStart);
					buLine6.typeDefination = entityTypeDefination.Connection;
					sortedEntities.Add(buLine6);
				}
				if (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenStart)
				{
					clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
					clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[i].sortEntities[0][0], ref pntStart);
					if (refPlane == FoamPlaneType.XZ)
					{
						double z = (patternSortEnt[i - 1].MinPoint.Z + patternSortEnt[i].MaxPoint.Z) / 2.0;
						Point3D start3 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
						Point3D end3 = new Point3D(pntEnd.X, pntEnd.Y, z);
						buLine buLine7 = new buLine(start3, end3);
						buLine7.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine7);
						start3 = new Point3D(pntEnd.X, pntEnd.Y, z);
						end3 = new Point3D(pntStart.X, pntStart.Y, z);
						buLine7 = new buLine(start3, end3);
						buLine7.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine7);
						start3 = new Point3D(pntStart.X, pntStart.Y, z);
						end3 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
						buLine7 = new buLine(start3, end3);
						buLine7.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine7);
					}
					if (refPlane == FoamPlaneType.YZ)
					{
						double z2 = (patternSortEnt[i - 1].MinPoint.Z + patternSortEnt[i].MaxPoint.Z) / 2.0;
						Point3D start4 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
						Point3D end4 = new Point3D(pntEnd.X, pntEnd.Y, z2);
						buLine buLine8 = new buLine(start4, end4);
						buLine8.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine8);
						start4 = new Point3D(pntEnd.X, pntEnd.Y, z2);
						end4 = new Point3D(pntStart.X, pntStart.Y, z2);
						buLine8 = new buLine(start4, end4);
						buLine8.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine8);
						start4 = new Point3D(pntStart.X, pntStart.Y, z2);
						end4 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
						buLine8 = new buLine(start4, end4);
						buLine8.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine8);
					}
				}
				if (buFoamCalc.varFoamSettings.SequenceHorizontal == FoamSequenceHor.HorizontalStartThenStartDirect)
				{
					clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
					clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[i].sortEntities[0][0], ref pntStart);
					if (refPlane == FoamPlaneType.XZ)
					{
						Point3D start5 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
						Point3D end5 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
						buLine buLine9 = new buLine(start5, end5);
						buLine9.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine9);
					}
					if (refPlane == FoamPlaneType.YZ)
					{
						double z3 = (patternSortEnt[i - 1].MinPoint.Z + patternSortEnt[i].MaxPoint.Z) / 2.0;
						Point3D start6 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
						Point3D end6 = new Point3D(pntEnd.X, pntEnd.Y, z3);
						buLine buLine10 = new buLine(start6, end6);
						buLine10.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine10);
						start6 = new Point3D(pntEnd.X, pntEnd.Y, z3);
						end6 = new Point3D(pntStart.X, pntStart.Y, z3);
						buLine10 = new buLine(start6, end6);
						buLine10.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine10);
						start6 = new Point3D(pntStart.X, pntStart.Y, z3);
						end6 = new Point3D(pntStart.X, pntStart.Y, pntStart.Z);
						buLine10 = new buLine(start6, end6);
						buLine10.typeDefination = entityTypeDefination.Connection;
						sortedEntities.Add(buLine10);
					}
				}
			}
			for (int j = 0; j <= patternSortEnt[i].sortEntities.Count - 1; j++)
			{
				if (j > 0)
				{
					clsInit.cVector5.GetEntityStartPointByCamDirection(patternSortEnt[i].sortEntities[j][0], ref pntStart);
					buLine buLine11 = new buLine(pntEnd, pntStart);
					buLine11.typeDefination = entityTypeDefination.Upper;
					bool flag = false;
					if (patternSortEnt[i].Direction == NormalReverse.Normal)
					{
						double num = Point3D.Distance(pntEnd, pntStart);
						if (refPlane == FoamPlaneType.XZ)
						{
							if ((num > 5.0) & (pntStart.X > pntEnd.X))
							{
								sortedEntities.Add(buLine11);
								flag = true;
							}
							if ((num > 5.0) & (pntStart.X < pntEnd.X))
							{
								pntEnd.X = pntStart.X;
								buLine11 = new buLine(pntEnd, pntStart);
								num = Point3D.Distance(pntEnd, pntStart);
								if (num > 1.0)
								{
									sortedEntities[sortedEntities.Count - 1].EndPoint.X = pntEnd.X;
									sortedEntities[sortedEntities.Count - 1].Update();
									sortedEntities.Add(buLine11);
									flag = true;
								}
							}
						}
						if (refPlane == FoamPlaneType.YZ)
						{
							if ((num > 5.0) & (pntStart.Y > pntEnd.Y))
							{
								sortedEntities.Add(buLine11);
								flag = true;
							}
							if ((num > 5.0) & (pntStart.Y < pntEnd.Y))
							{
								pntEnd.Y = pntStart.Y;
								buLine11 = new buLine(pntEnd, pntStart);
								num = Point3D.Distance(pntEnd, pntStart);
								if (num > 1.0)
								{
									sortedEntities[sortedEntities.Count - 1].EndPoint.Y = pntEnd.Y;
									sortedEntities[sortedEntities.Count - 1].Update();
									sortedEntities.Add(buLine11);
									flag = true;
								}
							}
						}
					}
					if (patternSortEnt[i].Direction == NormalReverse.Reverse)
					{
						double num2 = Point3D.Distance(pntEnd, pntStart);
						if (refPlane == FoamPlaneType.XZ)
						{
							if ((num2 > 5.0) & (pntEnd.X > pntStart.X))
							{
								sortedEntities.Add(buLine11);
								flag = true;
							}
							if ((num2 > 5.0) & (pntEnd.X < pntStart.X))
							{
								pntStart.X = pntEnd.X;
								buLine11 = new buLine(pntEnd, pntStart);
								num2 = Point3D.Distance(pntEnd, pntStart);
								if (num2 > 1.0)
								{
									sortedEntities[sortedEntities.Count - 1].StartPoint.X = pntStart.X;
									sortedEntities[sortedEntities.Count - 1].Update();
									sortedEntities.Add(buLine11);
									flag = true;
								}
							}
						}
					}
					if (!flag)
					{
						if (sortedEntities[sortedEntities.Count - 1].sortDirection != entitySortDirection.Normal)
						{
							if (sortedEntities[sortedEntities.Count - 1].sortDirection == entitySortDirection.Reverse && sortedEntities[sortedEntities.Count - 1] is buLine)
							{
								sortedEntities[sortedEntities.Count - 1].StartPoint = buVector5.ToPoint3D(pntStart);
								sortedEntities[sortedEntities.Count - 1].Update();
							}
						}
						else if (sortedEntities[sortedEntities.Count - 1] is buLine)
						{
							sortedEntities[sortedEntities.Count - 1].EndPoint = buVector5.ToPoint3D(pntStart);
							sortedEntities[sortedEntities.Count - 1].Update();
						}
					}
				}
				List<buEntity> copiedEntities = new List<buEntity>();
				buEntity.Copy(patternSortEnt[i].sortEntities[j], ref copiedEntities);
				for (int k = 0; k <= copiedEntities.Count - 1; k++)
				{
					sortedEntities.Add(copiedEntities[k]);
				}
				clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
			}
			clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
		}
		if (!(buFoamCalc.varFoamSettings.LeaveAlwaysFromStart & (sortedEntities.Count > 0)))
		{
			return;
		}
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		clsInit.cVector5.BoxSizeCalculate(sortedEntities, ref MinPoint, ref MaxPoint);
		clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
		if (refPlane == FoamPlaneType.XZ)
		{
			Point3D point3D = null;
			Point3D point3D2 = null;
			buLine buLine12 = null;
			if (pntEnd.Z > MinPoint.Z)
			{
				double num3 = MinPoint.Z - buFoamCalc.varFoamSettings.LeadOutLength;
				if (num3 < 0.0)
				{
					num3 = 0.0;
				}
				point3D = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
				point3D2 = new Point3D(pntEnd.X, pntEnd.Y, num3);
				buLine12 = new buLine(point3D, point3D2);
				buLine12.typeDefination = entityTypeDefination.CamLeadOut;
				sortedEntities.Add(buLine12);
			}
			clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
			point3D = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
			point3D2 = new Point3D(0.0 - buFoamCalc.varFoamSettings.LeadInLength, pntEnd.Y, pntEnd.Z);
			buLine12 = new buLine(point3D, point3D2);
			buLine12.typeDefination = entityTypeDefination.Connection;
			sortedEntities.Add(buLine12);
		}
		if (refPlane == FoamPlaneType.YZ)
		{
			Point3D point3D3 = null;
			Point3D point3D4 = null;
			buLine buLine13 = null;
			if (pntEnd.Z > MinPoint.Z)
			{
				double num4 = MinPoint.Z - buFoamCalc.varFoamSettings.LeadOutLength;
				if (num4 < 0.0)
				{
					num4 = 0.0;
				}
				point3D3 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
				point3D4 = new Point3D(pntEnd.X, pntEnd.Y, num4);
				buLine13 = new buLine(point3D3, point3D4);
				buLine13.typeDefination = entityTypeDefination.CamLeadOut;
				sortedEntities.Add(buLine13);
			}
			clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
			point3D3 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
			point3D4 = new Point3D(pntEnd.X, 0.0 - buFoamCalc.varFoamSettings.LeadInLength, pntEnd.Z);
			buLine13 = new buLine(point3D3, point3D4);
			buLine13.typeDefination = entityTypeDefination.Connection;
			sortedEntities.Add(buLine13);
		}
		if (buFoamCalc.varFoamSettings.MoveZUpPosition)
		{
			clsInit.cVector5.GetEntityEndPointByCamDirection(sortedEntities[sortedEntities.Count - 1], ref pntEnd);
			Point3D start7 = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
			Point3D end7 = new Point3D(pntEnd.X, pntEnd.Y, activeFoam.Material.Size.Depth + buFoamCalc.varFoamSettings.LeadOutLength - buFoamCalc.varFoamSettings.LeaveAlwaysZeroZOffsetFromBlockHeight);
			buLine buLine14 = new buLine(start7, end7);
			buLine14.typeDefination = entityTypeDefination.Connection;
			sortedEntities.Add(buLine14);
		}
	}

	public void cmdSelectAuto()
	{
		activeFoam.sortedEntitiesXZ.Clear();
		activeFoam.sortedEntitiesYZ.Clear();
		List<FoamSortGroup> patternSortEnt = new List<FoamSortGroup>();
		List<FoamSortGroup> patternSortEnt2 = new List<FoamSortGroup>();
		int Cnt = 0;
		for (int i = 0; i <= activeFoam.BlockXZ.Count - 1; i++)
		{
			FoamBlock foamBlockNext = null;
			if (i < activeFoam.BlockXZ.Count - 1)
			{
				foamBlockNext = activeFoam.BlockXZ[i + 1];
			}
			if (activeFoam.BlockXZ[i].isVertical)
			{
				GetPatternSortVertical(activeFoam.BlockXZ[i], foamBlockNext, FoamPlaneType.XZ, ref Cnt, ref patternSortEnt);
			}
			else
			{
				GetPatternSortHorizontal(activeFoam.BlockXZ[i], foamBlockNext, FoamPlaneType.XZ, ref Cnt, ref patternSortEnt);
			}
		}
		Cnt = 0;
		for (int j = 0; j <= activeFoam.BlockYZ.Count - 1; j++)
		{
			FoamBlock foamBlockNext2 = null;
			if (j < activeFoam.BlockYZ.Count - 1)
			{
				foamBlockNext2 = activeFoam.BlockYZ[j + 1];
			}
			if (activeFoam.BlockYZ[j].isVertical)
			{
				GetPatternSortVertical(activeFoam.BlockYZ[j], foamBlockNext2, FoamPlaneType.YZ, ref Cnt, ref patternSortEnt2);
			}
			else
			{
				GetPatternSortHorizontal(activeFoam.BlockYZ[j], foamBlockNext2, FoamPlaneType.YZ, ref Cnt, ref patternSortEnt2);
			}
		}
		ConnectPattertSort(patternSortEnt, FoamPlaneType.XZ, ref activeFoam.sortedEntitiesXZ);
		ConnectPattertSort(patternSortEnt2, FoamPlaneType.YZ, ref activeFoam.sortedEntitiesYZ);
		JobUpdate(FillPages: true, "", null, -1);
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
	}

	public void cmdManuelSelection()
	{
		try
		{
			activeFoam.isGCodeCreated = false;
			buFoamCalc.varTemps.NotCatchFound = false;
			buFoamCalc.varTemps.pntLastSelected = null;
			pnldata.Visible = true;
			radiosortFirstDirThenAuto.Checked = true;
			sortbuSettings_0.Option.UseCamSelectedProps = true;
			sortbuSettings_0.Option.NextGroupRules = SortingNextGroupFindRulesType.AskMe;
			sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
			sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.FirstDirectionThenAuto;
			if (buFoamCalc.varFoamRunSettings.SemiAutoSelection)
			{
				sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.First180DegreeTehnFromDrawing;
			}
			sortbuResult_0.ResultType = SortingResultType.None;
			buVector5.PointClickData.FoundCount = 0;
			buVector5.PointClickData.SelectedIndex = -1;
			buVector5.PointClickData.isPointOnEntity = false;
			buVector5.PointClickData.CatchPoint = null;
			buVector5.PointClickData.PreCatchPoint = null;
			if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
			{
				int num = 1;
				sortbuSettings_0.Option.refPlane = Plane.XZ;
				sortRefEntities.Clear();
				for (int i = 0; i <= activeFoam.BlockXZ.Count - 1; i++)
				{
					for (int j = 0; j <= activeFoam.BlockXZ[i].Pattern.Count - 1; j++)
					{
						for (int k = 0; k <= activeFoam.BlockXZ[i].Pattern[j].foamEntities.Count - 1; k++)
						{
							for (int l = 0; l <= activeFoam.BlockXZ[i].Pattern[j].foamEntities[k].GroupEntity.Outside.Entities.Count - 1; l++)
							{
								buEntity buEntity2 = buEntity.Copy(activeFoam.BlockXZ[i].Pattern[j].foamEntities[k].GroupEntity.Outside.Entities[l]);
								if (sortRefEntities.Count != 0)
								{
									if (!clsInit.cVector5.isEntitySame(sortRefEntities, buEntity2))
									{
										buEntity2.Info.ID = num.ToString();
										sortRefEntities.Add(buEntity2);
										num++;
									}
								}
								else
								{
									buEntity2.Info.ID = num.ToString();
									sortRefEntities.Add(buEntity2);
									num++;
								}
							}
						}
					}
				}
				ccVars.Action = actionTypeBU.foamManuelSelect;
				ccVars.stpDrawing = 1;
				ccVars.selectionProcess = false;
				ccVars.planeActive = Plane.XZ;
				ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XZ;
				clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
				clsInit.appCommand.cmdViewFront(ZoomFit: false, AtPlane: false);
				if (activeFoam.sortedEntitiesXZ.Count > 0)
				{
					clsInit.cVector5.GetEntityEndPointByCamDirection(activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1], ref buVector5.PointClickData.CatchPoint);
					buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
					ccVars.pntBase = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
					ccVars.enableViewportDrawCurrentLine = true;
					buVector5.PointClickData.isPointOnEntity = clsInit.cVector5.isPointTouchStartAndEndPointOfEntities(buVector5.PointClickData.CatchPoint, sortRefEntities);
				}
			}
			if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
			{
				sortbuSettings_0.Option.refPlane = Plane.YZ;
				sortRefEntities.Clear();
				for (int m = 0; m <= activeFoam.BlockYZ.Count - 1; m++)
				{
					for (int n = 0; n <= activeFoam.BlockYZ[m].Pattern.Count - 1; n++)
					{
						for (int num2 = 0; num2 <= activeFoam.BlockYZ[m].Pattern[n].foamEntities.Count - 1; num2++)
						{
							for (int num3 = 0; num3 <= activeFoam.BlockYZ[m].Pattern[n].foamEntities[num2].GroupEntity.Outside.Entities.Count - 1; num3++)
							{
								buEntity buEntity3 = buEntity.Copy(activeFoam.BlockYZ[m].Pattern[n].foamEntities[num2].GroupEntity.Outside.Entities[num3]);
								if (sortRefEntities.Count != 0)
								{
									if (!clsInit.cVector5.isEntitySame(sortRefEntities, buEntity3))
									{
										sortRefEntities.Add(buEntity3);
									}
								}
								else
								{
									sortRefEntities.Add(buEntity3);
								}
							}
						}
					}
				}
				ccVars.Action = actionTypeBU.foamManuelSelect;
				ccVars.stpDrawing = 1;
				ccVars.selectionProcess = false;
				ccVars.planeActive = Plane.YZ;
				ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.YZ;
				clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
				clsInit.appCommand.cmdViewRight(ZoomFit: false, AtPlane: false);
				if (activeFoam.sortedEntitiesYZ.Count > 0)
				{
					clsInit.cVector5.GetEntityEndPointByCamDirection(activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1], ref buVector5.PointClickData.CatchPoint);
					buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
					ccVars.pntBase = buVector5.ToPoint3D(buVector5.PointClickData.CatchPoint);
					ccVars.enableViewportDrawCurrentLine = true;
					buVector5.PointClickData.isPointOnEntity = clsInit.cVector5.isPointTouchStartAndEndPointOfEntities(buVector5.PointClickData.CatchPoint, sortRefEntities);
				}
			}
			CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: true, deletetool: true, drawpreview: true));
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdUndoSelection()
	{
		doUndoSelection();
	}

	public void cmdDeleteSelection()
	{
		if (ccVars.Pages.Count > 0)
		{
			doDeleteSelection(buFoamCalc.varFoamRunSettings.planeNames);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			activeFoam.isGCodeCreated = false;
		}
	}

	public void cmdSaveJob()
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "Foam Job File (*.foamjob)|*.foamjob";
		saveFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamJob;
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			buFoamCalc.varFoamRunSettings.pathFoamJob = buFile5.GetPath(saveFileDialog.FileName);
			clsInit.appFoamCutting.SaveFoamFile();
			SaveFoamJobFile(saveFileDialog.FileName);
		}
	}

	public void cmdOpenJob()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Foam Job File (*.foamjob)|*.foamjob";
		openFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathFoamJob;
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			buFoamCalc.varFoamRunSettings.pathFoamJob = buFile5.GetPath(openFileDialog.FileName);
			clsInit.appFoamCutting.SaveFoamFile();
			OpenFoamJobFile(openFileDialog.FileName);
		}
	}

	public void cmdShowGcode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					if (activeFoam != null)
					{
						doCheckLimits();
						if (activeFoam.isError)
						{
							return;
						}
						string Lines = "";
						List<camTp> CamList = new List<camTp>();
						PostProcessor P = new PostProcessor(ccVars.PostActive);
						CreateGCode(ref CamList, ref P);
						List<string> list = new List<string>();
						if (CamList.Count <= 0)
						{
							return;
						}
						for (int i = 0; i <= CamList.Count - 1; i++)
						{
							for (int j = 0; j <= CamList[i].CamPoints.Count - 1; j++)
							{
								for (int k = 0; k <= CamList[i].CamPoints[j].Points.Count - 1; k++)
								{
									if (CamList[i].CamPoints[j].Points[k].P9.C > buFoamCalc.varFoamSettings.TangentMaxAngle)
									{
										list.Add(buLangTranslate.preDef.Limit + " C = " + CamList[i].CamPoints[j].Points[k].P9.C.ToString("f2"));
									}
									if (CamList[i].CamPoints[j].Points[k].P9.C < buFoamCalc.varFoamSettings.TangentMinAngle)
									{
										list.Add(buLangTranslate.preDef.Limit + " C = " + CamList[i].CamPoints[j].Points[k].P9.C.ToString("f2"));
									}
								}
							}
						}
						if (list.Count > 0)
						{
							DialogBoxList dialogBoxList = new DialogBoxList();
							dialogBoxList.Caption = buLangTranslate.preDef.Warning;
							dialogBoxList.Width = 500;
							for (int l = 0; l <= list.Count - 1; l++)
							{
								dialogBoxList.Items.Add(list[l]);
							}
							dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
							dialogBoxList.Init();
							dialogBoxList.ShowDialog();
						}
						clsInit.cGcodeCreate.CreatGCode(CamList, P, ref Lines);
						F_Notepad f_Notepad = new F_Notepad();
						f_Notepad.Init(Lines);
						f_Notepad.Show();
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
					}
					else
					{
						buString5.MessageBoxWarning(buFoamCalc.LangFoamMessage[21]);
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

	public void cmdSaveGcode(bool ShowDialog = true)
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					if (activeFoam != null)
					{
						doCheckLimits();
						if (activeFoam.isError)
						{
							return;
						}
						List<camTp> CamList = new List<camTp>();
						PostProcessor P = new PostProcessor(ccVars.PostActive);
						CreateGCode(ref CamList, ref P);
						List<string> list = new List<string>();
						if (CamList.Count <= 0)
						{
							return;
						}
						for (int i = 0; i <= CamList.Count - 1; i++)
						{
							for (int j = 0; j <= CamList[i].CamPoints.Count - 1; j++)
							{
								for (int k = 0; k <= CamList[i].CamPoints[j].Points.Count - 1; k++)
								{
									if (CamList[i].CamPoints[j].Points[k].P9.C > buFoamCalc.varFoamSettings.TangentMaxAngle)
									{
										list.Add(buLangTranslate.preDef.Limit + " C = " + CamList[i].CamPoints[j].Points[k].P9.C.ToString("f2"));
									}
									if (CamList[i].CamPoints[j].Points[k].P9.C < buFoamCalc.varFoamSettings.TangentMinAngle)
									{
										list.Add(buLangTranslate.preDef.Limit + " C = " + CamList[i].CamPoints[j].Points[k].P9.C.ToString("f2"));
									}
								}
							}
						}
						if (list.Count > 0)
						{
							DialogBoxList dialogBoxList = new DialogBoxList();
							dialogBoxList.Caption = buLangTranslate.preDef.Warning;
							dialogBoxList.Width = 500;
							for (int l = 0; l <= list.Count - 1; l++)
							{
								dialogBoxList.Items.Add(list[l]);
							}
							dialogBoxList.StartPosition = FormStartPosition.CenterScreen;
							dialogBoxList.Init();
							dialogBoxList.ShowDialog();
						}
						SaveFileDialog saveFileDialog = new SaveFileDialog();
						saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
						saveFileDialog.Filter = P.FileExplanation + " (" + P.FileExtension + ")|" + P.FileExtension;
						saveFileDialog.FilterIndex = 1;
						if (!ShowDialog)
						{
							string Lines = "";
							clsInit.cGcodeCreate.CreatGCode(CamList, P, ref Lines);
							buFile5.SaveToFile(Lines, AppPath.Base + "\\temp.cnc");
							if (clsItem.FrmProgress != null)
							{
								clsItem.FrmProgress.Visible = false;
							}
						}
						else if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
							string Lines2 = "";
							clsInit.cGcodeCreate.CreatGCode(CamList, P, ref Lines2);
							buFile5.SaveToFile(Lines2, saveFileDialog.FileName);
							clsFiles.SaveParameter();
							if (clsItem.FrmProgress != null)
							{
								clsItem.FrmProgress.Visible = false;
							}
						}
					}
					else
					{
						buString5.MessageBoxWarning(buFoamCalc.LangFoamMessage[21]);
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

	public void cmdSimStart()
	{
		bool_0 = true;
		if (!activeFoam.isGCodeCreated)
		{
			List<camTp> CamList = new List<camTp>();
			PostProcessor P = new PostProcessor(ccVars.PostActive);
			CreateGCode(ref CamList, ref P);
		}
		if (int_0 == -1)
		{
			int_0 = 0;
		}
		if (simIndex == -1)
		{
			simIndex = 0;
		}
		timer_0.Enabled = true;
	}

	public void cmdSimStop()
	{
		if (!bool_0)
		{
			simIndex = -1;
			int_0 = -1;
			CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
		}
		else
		{
			timer_0.Enabled = false;
			bool_0 = false;
		}
	}

	public void cmdSimFwd()
	{
		Sim_Tick(null, null);
	}

	public void cmdSimBwd()
	{
		simIndex -= buFoamCalc.varFoamRunSettings.SimStep;
		simIndex -= buFoamCalc.varFoamRunSettings.SimStep;
		Sim_Tick(null, null);
	}

	public void cmdSequence()
	{
		F_FoamSequence f_FoamSequence = new F_FoamSequence();
		f_FoamSequence.SequenceHor = buFoamCalc.varFoamSettings.SequenceHorizontal;
		f_FoamSequence.SequenceVer = buFoamCalc.varFoamSettings.SequenceVertical;
		f_FoamSequence.Init();
		f_FoamSequence.ShowDialog();
		if (f_FoamSequence.PropertiesForm.Result == DialogResult.OK)
		{
			buFoamCalc.varFoamSettings.SequenceHorizontal = f_FoamSequence.SequenceHor;
			buFoamCalc.varFoamSettings.SequenceVertical = f_FoamSequence.SequenceVer;
			SaveFoamFile();
		}
	}

	public void cmdGetNestedPart()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					if (activeFoam != null)
					{
						clsInit.appNesting.cmdShowNestedPage();
					}
					else
					{
						buString5.MessageBoxWarning(buFoamCalc.LangFoamMessage[21]);
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

	public void cmdPlaneXZ(bool ZoomFit)
	{
		ccVars.planeActive = Plane.XZ;
		ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XZ;
		clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
		clsInit.appCommand.cmdViewFront(ZoomFit: false, AtPlane: false);
		if (ZoomFit)
		{
			clsInit.appCommand.cmdViewZoomFit();
			clsInit.appCommand.cmdViewZoomOut();
		}
		buFoamCalc.varFoamRunSettings.planeNames = FoamPlaneType.XZ;
		if (activePattern != null)
		{
			activePattern.planeName = FoamPlaneType.XZ;
		}
		if ((ccVars.Action == actionTypeBU.foamWaveSlice) | (ccVars.Action == actionTypeBU.foamWaveShape) | (ccVars.Action == actionTypeBU.foamWavePattern))
		{
			BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
		}
	}

	public void cmdPlaneYZ(bool ZoomFit)
	{
		ccVars.planeActive = Plane.YZ;
		ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.YZ;
		clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
		clsInit.appCommand.cmdViewRight(ZoomFit: false, AtPlane: false);
		if (ZoomFit)
		{
			clsInit.appCommand.cmdViewZoomFit();
			clsInit.appCommand.cmdViewZoomOut();
		}
		buFoamCalc.varFoamRunSettings.planeNames = FoamPlaneType.YZ;
		if (activePattern != null)
		{
			activePattern.planeName = FoamPlaneType.YZ;
		}
		if ((ccVars.Action == actionTypeBU.foamWaveSlice) | (ccVars.Action == actionTypeBU.foamWaveShape) | (ccVars.Action == actionTypeBU.foamWavePattern))
		{
			BlockSizeAdjustFromPlane(buFoamCalc.varFoamRunSettings.planeNames);
		}
	}

	public void cmdShowSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = "Settings";
			f_ClassViewerDialog.Value = buFoamCalc.varFoamSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				buFoamCalc.varFoamSettings = new FoamSettings((FoamSettings)f_ClassViewerDialog.Value);
				buFoamCalc.UnitLength = buFoamCalc.varFoamSettings.UnitLength;
				buFoamCalc.UnitsSpeed = buFoamCalc.varFoamSettings.UnitSpeed;
				SaveFoamFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdCodeConverter()
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "G Codes (*.nc,*cnc)|*.nc;*.cnc";
			openFileDialog.InitialDirectory = buFoamCalc.varFoamRunSettings.pathConverter;
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				F_FoamGCodeConverter f_FoamGCodeConverter = new F_FoamGCodeConverter();
				f_FoamGCodeConverter.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_FoamGCodeConverter.Converter = new GCodeConverter(buFoamCalc.varFoamGCodeConverter);
				f_FoamGCodeConverter.Init();
				f_FoamGCodeConverter.ShowDialog();
				if (f_FoamGCodeConverter.PropertiesForm.Result == DialogResult.OK)
				{
					buFoamCalc.varFoamGCodeConverter = new GCodeConverter(f_FoamGCodeConverter.Converter);
					buFoamCalc.varFoamRunSettings.pathConverter = buFile5.GetPath(openFileDialog.FileName);
					clsInit.appFoamCutting.SaveFoamFile();
					CodeConverter(openFileDialog.FileName, buFoamCalc.varFoamGCodeConverter);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void radio_CheckedChanged(object sender, EventArgs e)
	{
		if (!radiosortCCW.Checked)
		{
			if (!radiosortCW.Checked)
			{
				if (!radiosortFirstDirThenAuto.Checked)
				{
					if (!radiosortHigherIndex.Checked)
					{
						if (!radiosortJump.Checked)
						{
							if (!radiosortLowerIndex.Checked)
							{
								if (!radiosortNone.Checked)
								{
									if (radiosortmanuel.Checked)
									{
										sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.Manuel;
									}
								}
								else
								{
									sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.None;
								}
							}
							else
							{
								sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.LowerIndex;
							}
						}
						else
						{
							sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.Jump;
						}
					}
					else
					{
						sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.HigherIndex;
					}
				}
				else
				{
					sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.FirstDirectionThenAuto;
				}
			}
			else
			{
				sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.CW;
			}
		}
		else
		{
			sortbuSettings_0.Option.FirstRules = SortingFirstCatchRulesType.CCW;
		}
	}

	public void New_Tick(object sender, EventArgs e)
	{
		timer_1.Enabled = false;
		FoamItem foamItem = new FoamItem();
		foamItem.Material.Size = new SizeObject(buFoamCalc.varFoamRunSettings.MaterialWidth, buFoamCalc.varFoamRunSettings.MaterialHeight, buFoamCalc.varFoamRunSettings.MaterialDepth);
		cmdNewMaterial(foamItem, SkipForm: true);
		clsInit.appCommand.cmdViewZoomFit();
		clsInit.appCommand.cmdViewZoomOut();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			if (i == 0)
			{
				buFoamCalc.varTemps.LayerGeneral = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name;
			}
			if (i == 1)
			{
				buFoamCalc.varTemps.LayerFoam = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name;
			}
			if (i == 2)
			{
				buFoamCalc.varTemps.Layer3DPattern = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name;
			}
			if (i == 3)
			{
				buFoamCalc.varTemps.LayerWirePattern = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name;
			}
			if (i == 4)
			{
				buFoamCalc.varTemps.LayerSelection = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name;
			}
			if (i == 5)
			{
				buFoamCalc.varTemps.LayerMark = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name;
			}
		}
		GC.Collect();
	}

	public void Sim_Tick(object sender, EventArgs e)
	{
		if (int_0 != 0)
		{
			if (int_0 == 1)
			{
				if (activeFoam.CamYZ.SimilationPoint.SimMove.Count <= 0)
				{
					simIndex = -1;
					int_0 = -1;
					timer_0.Enabled = false;
					bool_0 = false;
					CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
				}
				else if (!((simIndex >= 0) & (simIndex <= activeFoam.CamYZ.SimilationPoint.SimMove.Count - 1)))
				{
					simIndex = -1;
					int_0 = -1;
					timer_0.Enabled = false;
					bool_0 = false;
					CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
				}
				else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1];
					if ((entity.EntityData != null) & (entity.EntityData is CustomData))
					{
						CustomData customData = entity.EntityData as CustomData;
						if (customData.typeDefination == entityTypeDefination.Tool)
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
						}
					}
					Pnt6DSimMove pnt6DSimMove = activeFoam.CamYZ.SimilationPoint.SimMove[simIndex];
					List<Point3D> list = new List<Point3D>();
					list.Add(new Point3D(activeFoam.Material.Size.Width + 1.0, pnt6DSimMove.X, pnt6DSimMove.Y));
					list.Add(new Point3D(activeFoam.Material.Size.Width + 1.0, pnt6DSimMove.X + 80.0, pnt6DSimMove.Y + 20.0));
					list.Add(new Point3D(activeFoam.Material.Size.Width + 1.0, pnt6DSimMove.X + 80.0, pnt6DSimMove.Y - 20.0));
					list.Add(new Point3D(activeFoam.Material.Size.Width + 1.0, pnt6DSimMove.X, pnt6DSimMove.Y));
					LinearPath linearPath = new LinearPath(list);
					linearPath.Rotate(buConversion5.DegreeToRadian(pnt6DSimMove.C + 180.0), Vector3D.AxisX, new Point3D(activeFoam.Material.Size.Width, pnt6DSimMove.X, pnt6DSimMove.Y));
					devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(linearPath, Plane.YZ, true);
					region.Translate(activeFoam.Material.Size.Width, 0.0);
					Mesh mesh = region.ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);
					CustomData customData2 = new CustomData();
					customData2.typeDefination = entityTypeDefination.Tool;
					mesh.EntityData = customData2;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh);
					simIndex += buFoamCalc.varFoamRunSettings.SimStep;
				}
			}
		}
		else if (activeFoam.CamXZ.SimilationPoint.SimMove.Count <= 0)
		{
			simIndex = 0;
			int_0 = 1;
		}
		else if (!((simIndex >= 0) & (simIndex <= activeFoam.CamXZ.SimilationPoint.SimMove.Count - 1)))
		{
			simIndex = 0;
			int_0 = 1;
		}
		else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count > 0)
		{
			Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1];
			if ((entity2.EntityData != null) & (entity2.EntityData is CustomData))
			{
				CustomData customData3 = entity2.EntityData as CustomData;
				if (customData3.typeDefination == entityTypeDefination.Tool)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
				}
			}
			entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1];
			if ((entity2.EntityData != null) & (entity2.EntityData is CustomData))
			{
				CustomData customData4 = entity2.EntityData as CustomData;
				if (customData4.typeDefination == entityTypeDefination.Tool)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
				}
			}
			Pnt6DSimMove pnt6DSimMove2 = activeFoam.CamXZ.SimilationPoint.SimMove[simIndex];
			List<Point3D> list2 = new List<Point3D>();
			list2.Add(new Point3D(pnt6DSimMove2.X, 0.0, pnt6DSimMove2.Y));
			list2.Add(new Point3D(pnt6DSimMove2.X + 80.0, 0.0, pnt6DSimMove2.Y + 20.0));
			list2.Add(new Point3D(pnt6DSimMove2.X + 80.0, 0.0, pnt6DSimMove2.Y - 20.0));
			list2.Add(new Point3D(pnt6DSimMove2.X, 0.0, pnt6DSimMove2.Y));
			LinearPath linearPath2 = new LinearPath(list2);
			linearPath2.Rotate(buConversion5.DegreeToRadian(0.0 - pnt6DSimMove2.C + 180.0), Vector3D.AxisY, new Point3D(pnt6DSimMove2.X, 0.0, pnt6DSimMove2.Y));
			devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(linearPath2, Plane.XZ, true);
			Mesh mesh2 = region2.ExtrudeAsMesh(5.0, 0.1, Mesh.natureType.RichSmooth);
			CustomData customData5 = new CustomData();
			customData5.typeDefination = entityTypeDefination.Tool;
			mesh2.EntityData = customData5;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh2);
			Text text = new Text(Plane.XZ, new Point3D(pnt6DSimMove2.X, pnt6DSimMove2.Z - 6.0, pnt6DSimMove2.Y), pnt6DSimMove2.C.ToString("f1"), 20.0);
			CustomData customData6 = new CustomData();
			customData6.typeDefination = entityTypeDefination.Tool;
			text.EntityData = customData6;
			text.Color = Color.Red;
			text.ColorMethod = colorMethodType.byEntity;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(text);
			simIndex += buFoamCalc.varFoamRunSettings.SimStep;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void SaveFoamJobFile(string FileName)
	{
		ArrayList arrayList = new ArrayList();
		arrayList = FoamItem.ToDef(activeFoam, 2);
		buFile5.SaveToFile(arrayList, FileName);
	}

	public void OpenFoamJobFile(string FileName)
	{
		ArrayList StringList = new ArrayList();
		buFile5.OpenFromFile(FileName, ref StringList);
		if (StringList.Count <= 0)
		{
			return;
		}
		FoamItem Item = new FoamItem();
		FoamItem.Decode(StringList, ref Item);
		if (!((Item.BlockXZ.Count > 0) | (Item.BlockYZ.Count > 0)))
		{
			return;
		}
		activeFoam = new FoamItem(Item);
		if (buFoamCalc.varFoamSettings.Draw3D)
		{
			for (int i = 0; i <= activeFoam.BlockXZ.Count - 1; i++)
			{
				for (int j = 0; j <= activeFoam.BlockXZ[i].Pattern.Count - 1; j++)
				{
					List<buEntity> list = new List<buEntity>();
					for (int k = 0; k <= activeFoam.BlockXZ[i].Pattern[j].foamEntities.Count - 1; k++)
					{
						for (int l = 0; l <= activeFoam.BlockXZ[i].Pattern[j].foamEntities[k].GroupEntity.Outside.Entities.Count - 1; l++)
						{
							list.Add(buEntity.Copy(activeFoam.BlockXZ[i].Pattern[j].foamEntities[k].GroupEntity.Outside.Entities[l]));
						}
					}
					FoamPattern Pattern = activeFoam.BlockXZ[i].Pattern[j];
					clsInit.cFoamCut.CreateSolidOperation(ref Pattern, activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
				}
			}
		}
		JobUpdate(FillPages: true, "", null, -1);
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: true, drawpreview: true));
		if (Item.BlockXZ.Count <= 0)
		{
			if (Item.BlockYZ.Count > 0)
			{
				cmdPlaneYZ(ZoomFit: true);
			}
		}
		else
		{
			cmdPlaneXZ(ZoomFit: true);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buFoam.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buFoam.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Foam Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Foam Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buFoamCalc.LangFoamCommands);
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

	public void SaveFoamFile()
	{
		try
		{
			string path = AppPath.Settings + "\\Foam";
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (!directoryInfo.Exists)
			{
				directoryInfo = new DirectoryInfo(AppPath.MachineSettings + "\\Foam");
				if (!directoryInfo.Exists)
				{
					directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Foam");
					if (!directoryInfo.Exists)
					{
						buString5.MessageBoxWarning("Settins Path Not Available");
						return;
					}
				}
			}
			string fileName = directoryInfo.FullName + "\\Foam.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Foam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<buFoamCuttingCalc.varFoamSettings>");
			arrayList.AddRange(buFoamCalc.varFoamSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buFoamCuttingCalc.varFoamSettings>");
			arrayList.Add("<buFoamCuttingCalc.varFoamRunSettings>");
			arrayList.AddRange(buFoamCalc.varFoamRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buFoamCuttingCalc.varFoamRunSettings>");
			arrayList.Add("<buFoamCuttingCalc.varFoamEditorSettings>");
			arrayList.AddRange(buFoamCalc.varFoamEditorSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buFoamCuttingCalc.varFoamEditorSettings>");
			arrayList.Add("<buFoamCuttingCalc.varFoamGCodeConverter>");
			arrayList.AddRange(buFoamCalc.varFoamGCodeConverter.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buFoamCuttingCalc.varFoamGCodeConverter>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Foam Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			arrayList = new ArrayList();
			arrayList.Add("Radius Feed Table");
			arrayList.Add("MinRadius ; MaxRadius ; Feed");
			arrayList.Add("<RadiusFeed>");
			for (int i = 0; i <= buFoamCalc.RadiusFeedList.Count - 1; i++)
			{
				arrayList.Add(buFoamCalc.RadiusFeedList[i].MinRadius + " ; " + buFoamCalc.RadiusFeedList[i].MaxRadius + " ; " + buFoamCalc.RadiusFeedList[i].Feed);
			}
			arrayList.Add("</RadiusFeed>");
			arrayList.Add(" ");
			arrayList.Add("---------------- ");
			arrayList.Add(" ");
			arrayList.Add("Length Feed Table");
			arrayList.Add("MinLength; MaxLength; Feed");
			arrayList.Add("<LengthFeed>");
			for (int j = 0; j <= buFoamCalc.LengthFeedList.Count - 1; j++)
			{
				arrayList.Add(buFoamCalc.LengthFeedList[j].MinLength + " ; " + buFoamCalc.LengthFeedList[j].MaxLength + " ; " + buFoamCalc.LengthFeedList[j].Feed);
			}
			arrayList.Add("</LengthFeed>");
			buFile5.SaveToFile(arrayList, directoryInfo.FullName + "\\SpeedsList.prm");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenFoamFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Settings + "\\Foam");
			if (!directoryInfo.Exists)
			{
				directoryInfo = new DirectoryInfo(AppPath.MachineSettings + "\\Foam");
				if (!directoryInfo.Exists)
				{
					directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Foam");
					if (!directoryInfo.Exists)
					{
						buString5.MessageBoxWarning("Settins Path Not Available");
						return;
					}
				}
			}
			string fileName = directoryInfo.FullName + "\\Foam.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Foam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Drill Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<buFoamCuttingCalc.varFoamSettings>", "</buFoamCuttingCalc.varFoamSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buFoamCalc.varFoamSettings);
						buLog.addLog("Foam varFoamSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<buFoamCuttingCalc.varFoamRunSettings>", "</buFoamCuttingCalc.varFoamRunSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buFoamCalc.varFoamRunSettings);
						buLog.addLog("Foam varFoamRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<buFoamCuttingCalc.varFoamEditorSettings>", "</buFoamCuttingCalc.varFoamEditorSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buFoamCalc.varFoamEditorSettings);
						buLog.addLog("Foam varFoamEditorSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<buFoamCuttingCalc.varFoamGCodeConverter>", "</buFoamCuttingCalc.varFoamGCodeConverter>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buFoamCalc.varFoamGCodeConverter);
						buLog.addLog("Foam varFoamGCodeConverter Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Foam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Drill Settings Decoder Error");
				}
			}
			buLog.addLog("Foam Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(directoryInfo.FullName + "\\SpeedsList.prm");
			if (fileInfo.Exists)
			{
				arrayList = new ArrayList();
				buFile5.OpenFromFile(fileInfo.FullName, ref arrayList);
				if (arrayList.Count > 0)
				{
					ArrayList CalcList2 = new ArrayList();
					buString.ListToSpecificList("<RadiusFeed>", "</RadiusFeed>", AddStartEndKey: false, arrayList, ref CalcList2);
					if (CalcList2.Count > 0)
					{
						buFoamCalc.RadiusFeedList.Clear();
						for (int i = 0; i <= CalcList2.Count - 1; i++)
						{
							string[] array = CalcList2[i].ToString().Split(';');
							if (array != null && array.Length == 3)
							{
								camRadiusFeed camRadiusFeed2 = new camRadiusFeed();
								double.TryParse(array[0], out camRadiusFeed2.MinRadius);
								double.TryParse(array[1], out camRadiusFeed2.MaxRadius);
								double.TryParse(array[2], out camRadiusFeed2.Feed);
								buFoamCalc.RadiusFeedList.Add(camRadiusFeed2);
							}
						}
					}
					CalcList2 = new ArrayList();
					buString.ListToSpecificList("<LengthFeed>", "</LengthFeed>", AddStartEndKey: false, arrayList, ref CalcList2);
					if (CalcList2.Count > 0)
					{
						buFoamCalc.LengthFeedList.Clear();
						for (int j = 0; j <= CalcList2.Count - 1; j++)
						{
							string[] array2 = CalcList2[j].ToString().Split(';');
							if (array2 != null && array2.Length == 3)
							{
								camLengthFeed camLengthFeed2 = new camLengthFeed();
								double.TryParse(array2[0], out camLengthFeed2.MinLength);
								double.TryParse(array2[1], out camLengthFeed2.MaxLength);
								double.TryParse(array2[2], out camLengthFeed2.Feed);
								buFoamCalc.LengthFeedList.Add(camLengthFeed2);
							}
						}
					}
				}
			}
			buFoamCalc.UnitLength = buFoamCalc.varFoamSettings.UnitLength;
			buFoamCalc.UnitsSpeed = buFoamCalc.varFoamSettings.UnitSpeed;
		}
		catch (Exception mSException2)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenFoamPatternFile(object FileName, object Data)
	{
		if (FileName == null)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(FileName.ToString());
		if (fileInfo.Exists)
		{
			List<Entity> EyeEntities = new List<Entity>();
			List<buEntity> SortedEntities = new List<buEntity>();
			clsInit.appEditor.OpenSortedEntities(fileInfo.FullName, ref EyeEntities, ref SortedEntities);
			clsItem.FrmFromFile.viewport.Entities.Clear();
			for (int i = 0; i <= EyeEntities.Count - 1; i++)
			{
				EyeEntities[i].LayerName = "Default";
				clsItem.FrmFromFile.viewport.Entities.Add(EyeEntities[i]);
			}
			clsItem.FrmFromFile.viewport.SetView(viewType.Top);
			clsItem.FrmFromFile.viewport.ZoomFit(10);
			clsItem.FrmFromFile.viewport.Invalidate();
		}
	}

	public void CodeConverter(string FileName, GCodeConverter Converter)
	{
		List<string> StringList = new List<string>();
		List<string> list = new List<string>();
		if (!(Converter.FilterLength > 0.0))
		{
			buFile5.OpenFromFile(FileName, ref StringList);
		}
		else
		{
			buFile5.GCodeRead gCodeRead = new buFile5.GCodeRead();
			List<GCodePoint5> GCodeList = new List<GCodePoint5>();
			gCodeRead.Settings.FilterLength = Converter.FilterLength;
			gCodeRead.DecodeAxes.A = false;
			gCodeRead.DecodeAxes.B = false;
			gCodeRead.DecodeAxes.C = false;
			gCodeRead.OpenGCode(FileName, ref GCodeList);
			for (int i = 0; i <= GCodeList.Count - 1; i++)
			{
				if (GCodeList[i].isGCode)
				{
					string text = "G" + GCodeList[i].CodeType + " X" + GCodeList[i].Positions.X.ToString("f3") + " Y" + GCodeList[i].Positions.Y.ToString("f3") + " Z" + GCodeList[i].Positions.Z.ToString("f3");
					if ((GCodeList[i].CodeType == 1) | (GCodeList[i].CodeType == 2) | (GCodeList[i].CodeType == 3))
					{
						text = text + " F" + GCodeList[i].Feed;
					}
					StringList.Add(text);
				}
			}
			buString5.MessageBoxInfo(buLangTranslate.preDef.Count + " " + gCodeRead.Result.OriginalGCodeLineCount + " - " + gCodeRead.Result.ConvertedGCodeLineCount);
		}
		if (StringList.Count > 0)
		{
			int num = 100;
			list.Add("<Info>");
			list.Add("0;0;0");
			list.Add("</Info>");
			list.Add("<GCodesMain>");
			list.Add("N20 G90");
			list.Add("N30 G75");
			list.Add("N40 G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			list.Add("N50 G75");
			list.Add("N60 M154");
			list.Add("N70 G75");
			list.Add("N80 G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
			list.Add("N90 G75");
			string text2 = "";
			string text3 = "";
			string text4 = "";
			for (int j = 0; j <= StringList.Count - 1; j++)
			{
				string text5 = "";
				string text6 = "";
				string text7 = "";
				string text8 = "";
				if ((StringList[j].IndexOf("G0 ") >= 0) | (StringList[j].IndexOf("G00 ") >= 0))
				{
					text5 = "G0";
					if (StringList[j].IndexOf("X") >= 0)
					{
						double Value = 0.0;
						buString5.ReadCharValue(StringList[j], "X", ref Value);
						text5 = text5 + " X" + ((Value + Converter.XOffset) * Converter.XMultiply).ToString("f3");
						text6 = Value.ToString("f3");
					}
					if (StringList[j].IndexOf("Y") >= 0)
					{
						double Value2 = 0.0;
						buString5.ReadCharValue(StringList[j], "Y", ref Value2);
						text5 = text5 + " Y" + ((Value2 + Converter.YOffset) * Converter.YMultiply).ToString("f3");
						text7 = Value2.ToString("f3");
					}
					if (StringList[j].IndexOf("Z") >= 0)
					{
						double Value3 = 0.0;
						buString5.ReadCharValue(StringList[j], "Z", ref Value3);
						text5 = text5 + " C" + ((Value3 + Converter.ZOffset) * Converter.ZMultiply).ToString("f3");
						text8 = Value3.ToString("f3");
					}
					if (text5.Length > 2 && ((text6 != text2) | (text7 != text3) | (text8 != text4)))
					{
						list.Add("N" + num + " " + text5);
						text2 = text6;
						text3 = text7;
						text4 = text8;
						num += 10;
					}
				}
				if ((StringList[j].IndexOf("G1 ") >= 0) | (StringList[j].IndexOf("G01 ") >= 0))
				{
					text5 = "G1";
					if (StringList[j].IndexOf("X") >= 0)
					{
						double Value4 = 0.0;
						buString5.ReadCharValue(StringList[j], "X", ref Value4);
						text5 = text5 + " X" + ((Value4 + Converter.XOffset) * Converter.XMultiply).ToString("f3");
						text6 = Value4.ToString("f3");
					}
					if (StringList[j].IndexOf("Y") >= 0)
					{
						double Value5 = 0.0;
						buString5.ReadCharValue(StringList[j], "Y", ref Value5);
						text5 = text5 + " Y" + ((Value5 + Converter.YOffset) * Converter.YMultiply).ToString("f3");
						text7 = Value5.ToString("f3");
					}
					if (StringList[j].IndexOf("Z") >= 0)
					{
						double Value6 = 0.0;
						buString5.ReadCharValue(StringList[j], "Z", ref Value6);
						text5 = text5 + " C" + ((Value6 + Converter.ZOffset) * Converter.ZMultiply).ToString("f3");
						text8 = Value6.ToString("f3");
					}
					if (StringList[j].IndexOf("F") >= 0)
					{
						double Value7 = 0.0;
						buString5.ReadCharValue(StringList[j], "F", ref Value7);
						text5 = text5 + " F" + ((Value7 + Converter.FOffset) * Converter.FMultiply).ToString("f1");
					}
					if (text5.Length > 2 && ((text6 != text2) | (text7 != text3) | (text8 != text4)))
					{
						list.Add("N" + num + " " + text5);
						text2 = text6;
						text3 = text7;
						text4 = text8;
						num += 10;
					}
				}
			}
			list.Add("N" + num + " M30");
			list.Add("N" + (num + 10) + " M2");
			list.Add("</GCodesMain>");
		}
		if (list.Count > 0)
		{
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(FileName);
			string path = buFile5.GetPath(FileName);
			string fileName = path + "\\" + fileNameWithoutExtension + "_Conv.cnc";
			buFile5.SaveToFile(list, fileName);
			buString5.StringListToString(list);
		}
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
		TreeView treeView = (TreeView)sender;
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)treeView.SelectedNode;
		string command = treeNodeSettings.Command;
		string text = command;
		switch (Class5.smethod_167(text))
		{
		case 2430435169u:
			if (text == "blockYZ" && treeNodeSettings.ClassIndex >= 0)
			{
				foamActiveBlock_0.PatternIndex = -1;
				foamActiveBlock_0.BlockIndex = -1;
				foamActiveBlock_0.Plane = (FoamPlaneType)treeNodeSettings.Tag;
			}
			break;
		case 697773883u:
			if (text == "patternXZ" && treeNodeSettings.ClassIndex >= 0)
			{
				foamActiveBlock_0.PatternIndex = treeNodeSettings.ClassSubSubSubIndex;
				foamActiveBlock_0.BlockIndex = treeNodeSettings.ClassSubSubIndex;
				foamActiveBlock_0.Plane = (FoamPlaneType)treeNodeSettings.Tag;
			}
			break;
		case 701609025u:
			if (text == "blocksXZ" && treeNodeSettings.ClassIndex >= 0)
			{
				foamActiveBlock_0.PatternIndex = -1;
				foamActiveBlock_0.BlockIndex = treeNodeSettings.ClassSubSubIndex;
				foamActiveBlock_0.Plane = (FoamPlaneType)treeNodeSettings.Tag;
			}
			break;
		case 1077441436u:
			if (text == "foam" && treeNodeSettings.ClassIndex >= 0)
			{
				foamActiveBlock_0.PatternIndex = -1;
				foamActiveBlock_0.BlockIndex = -1;
			}
			break;
		case 1457186172u:
			if (text == "blockXZ" && treeNodeSettings.ClassIndex >= 0)
			{
				foamActiveBlock_0.PatternIndex = -1;
				foamActiveBlock_0.BlockIndex = -1;
				foamActiveBlock_0.Plane = (FoamPlaneType)treeNodeSettings.Tag;
			}
			break;
		case 1875792092u:
			if (text == "blocksYZ" && treeNodeSettings.ClassIndex >= 0)
			{
				foamActiveBlock_0.PatternIndex = -1;
				foamActiveBlock_0.BlockIndex = treeNodeSettings.ClassSubSubIndex;
				foamActiveBlock_0.Plane = (FoamPlaneType)treeNodeSettings.Tag;
			}
			break;
		case 3885271230u:
			if (text == "patternYZ" && treeNodeSettings.ClassIndex >= 0)
			{
				foamActiveBlock_0.PatternIndex = treeNodeSettings.ClassSubSubSubIndex;
				foamActiveBlock_0.BlockIndex = treeNodeSettings.ClassSubSubIndex;
				foamActiveBlock_0.Plane = (FoamPlaneType)treeNodeSettings.Tag;
			}
			break;
		}
	}

	public void JobUpdate(bool FillPages, string Command, DrillItem Item, int indexItem)
	{
		try
		{
			if (clsItem.FrmFoamJob == null)
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
			TreeNodeSettings treeNodeSettings3 = null;
			TreeNodeSettings treeNodeSettings4 = null;
			TreeNodeSettings treeNodeSettings5 = null;
			if (!FillPages)
			{
				return;
			}
			treejobs.Nodes.Clear();
			string nodeText = clsInit.cFoamCut.JobItemName(activeFoam);
			treeNodeSettings = new TreeNodeSettings(nodeText)
			{
				ImageIndex = 0,
				SelectedImageIndex = 0,
				Tag = "0",
				ClassIndex = 0,
				ClassSubIndex = -1,
				ClassSubSubIndex = -1,
				Command = "foam",
				Info = "",
				Checked = true
			};
			treeNodeSettings3 = new TreeNodeSettings("Main")
			{
				ImageIndex = 2,
				SelectedImageIndex = 2,
				Tag = FoamPlaneType.XZ,
				ClassIndex = 0,
				ClassSubIndex = 0,
				ClassSubSubIndex = -1,
				Command = "blockXZ",
				Info = "XZ",
				Checked = true
			};
			treeNodeSettings4 = new TreeNodeSettings("Side")
			{
				ImageIndex = 3,
				SelectedImageIndex = 3,
				Tag = FoamPlaneType.YZ,
				ClassIndex = 0,
				ClassSubIndex = 1,
				ClassSubSubIndex = -1,
				Command = "blockYZ",
				Info = "YZ",
				Checked = true
			};
			treeNodeSettings.Nodes.Add(treeNodeSettings3);
			treeNodeSettings.Nodes.Add(treeNodeSettings4);
			for (int i = 0; i <= activeFoam.BlockXZ.Count - 1; i++)
			{
				string nodeText2 = clsInit.cFoamCut.JobBlockName(activeFoam.BlockXZ[i]);
				treeNodeSettings2 = new TreeNodeSettings(nodeText2)
				{
					ImageIndex = 1,
					SelectedImageIndex = 1,
					Tag = FoamPlaneType.XZ,
					ClassIndex = 0,
					ClassSubIndex = 0,
					ClassSubSubIndex = i,
					Command = "blocksXZ",
					Info = "XZ",
					Checked = true
				};
				treeNodeSettings3.Nodes.Add(treeNodeSettings2);
				for (int j = 0; j <= activeFoam.BlockXZ[i].Pattern.Count - 1; j++)
				{
					string nodeText3 = j + 1 + " - " + clsInit.cFoamCut.JobPatternName(activeFoam.BlockXZ[i].Pattern[j]);
					clsInit.cFoamCut.JobPatternImageIndex(activeFoam.BlockXZ[i].Pattern[j]);
					treeNodeSettings5 = new TreeNodeSettings(nodeText3)
					{
						ImageIndex = 4,
						SelectedImageIndex = 4,
						Tag = FoamPlaneType.XZ,
						ClassIndex = 0,
						ClassSubIndex = 0,
						ClassSubSubIndex = i,
						ClassSubSubSubIndex = j,
						Command = "patternXZ",
						Info = "XZ",
						Checked = true
					};
					treeNodeSettings2.Nodes.Add(treeNodeSettings5);
				}
			}
			for (int k = 0; k <= activeFoam.BlockYZ.Count - 1; k++)
			{
				string nodeText4 = clsInit.cFoamCut.JobBlockName(activeFoam.BlockYZ[k]);
				treeNodeSettings2 = new TreeNodeSettings(nodeText4)
				{
					ImageIndex = 1,
					SelectedImageIndex = 1,
					Tag = FoamPlaneType.YZ,
					ClassIndex = 0,
					ClassSubIndex = 0,
					ClassSubSubIndex = k,
					Command = "blocksYZ",
					Info = "YZ",
					Checked = true
				};
				treeNodeSettings4.Nodes.Add(treeNodeSettings2);
				for (int l = 0; l <= activeFoam.BlockYZ[k].Pattern.Count - 1; l++)
				{
					string nodeText5 = l + 1 + " - " + clsInit.cFoamCut.JobPatternName(activeFoam.BlockYZ[k].Pattern[l]);
					clsInit.cFoamCut.JobPatternImageIndex(activeFoam.BlockYZ[k].Pattern[l]);
					treeNodeSettings5 = new TreeNodeSettings(nodeText5)
					{
						ImageIndex = 4,
						SelectedImageIndex = 4,
						Tag = FoamPlaneType.YZ,
						ClassIndex = 0,
						ClassSubIndex = 0,
						ClassSubSubIndex = k,
						ClassSubSubSubIndex = l,
						Command = "patternYZ",
						Info = "YZ",
						Checked = true
					};
					treeNodeSettings2.Nodes.Add(treeNodeSettings5);
				}
			}
			treeNodeSettings.Expand();
			treejobs.Nodes.Add(treeNodeSettings);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DrawPreview()
	{
		if (clsItem.ModelMainPreview == null)
		{
			return;
		}
		if (clsItem.ModelMainPreview.Layers.Count != ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count)
		{
			clsItem.ModelMainPreview.Layers.Clear();
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
			{
				clsItem.ModelMainPreview.Layers.Add((Layer)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Clone());
			}
		}
		clsItem.ModelMainPreview.Entities.Clear();
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
		{
			clsItem.ModelMainPreview.Entities.Add((Entity)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Clone());
		}
		clsItem.ModelMainPreview.Invalidate();
	}

	public void DeleteEntities(bool Mark, bool Sorted, bool Tool)
	{
		int num = 0;
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData is CustomData)
			{
				CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
				if (customData.typeDefination == entityTypeDefination.Mark && Mark)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
					num++;
				}
				if (customData.typeDefination == entityTypeDefination.Sorted && Sorted)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
					num++;
				}
				if (customData.typeDefination == entityTypeDefination.Tool && Tool)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
					num++;
				}
			}
		}
		if (num > 0)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public void DrawBlock(List<FoamBlock> Blocks, Plane refPlane)
	{
		for (int i = 0; i <= Blocks.Count - 1; i++)
		{
			for (int j = 0; j <= Blocks[i].Pattern.Count - 1; j++)
			{
				if (Blocks[i].Pattern[j].SolidEntities != null)
				{
					for (int k = 0; k <= Blocks[i].Pattern[j].SolidEntities.Count - 1; k++)
					{
						Entity copiedEntity = null;
						buEntity.Copy(Blocks[i].Pattern[j].SolidEntities[k], ref copiedEntity);
						copiedEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.Layer3DPattern.Length > 0)
						{
							copiedEntity.LayerName = buFoamCalc.varTemps.Layer3DPattern;
						}
						ccVars.UndoDont = true;
						clsInit.appCommand.AddEntity(copiedEntity);
					}
				}
				bool flag = false;
				if (ccVars.Action == actionTypeBU.foamManuelSelect && Blocks[i].Pattern[j].sortEntities != null && Blocks[i].Pattern[j].sortEntities.Count > 0)
				{
					flag = true;
					Point3D pntStart = null;
					if (Blocks[i].Pattern[j].sortEntities[0].sortDirection != entitySortDirection.Normal)
					{
						clsInit.cVector5.GetEntityStartPointByCamDirection(Blocks[i].Pattern[j].sortEntities[0], ref pntStart);
					}
					else
					{
						clsInit.cVector5.GetEntityStartPointByCamDirection(Blocks[i].Pattern[j].sortEntities[0], ref pntStart);
					}
					if (refPlane == Plane.YZ)
					{
						pntStart.X = activeFoam.Material.Size.Width;
					}
					Entity refEntity = null;
					clsInit.cFoamCut.CreateMarkCircleEntity(pntStart, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter + 2.0, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity);
					ccVars.UndoDont = true;
					refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
					if (buFoamCalc.varTemps.LayerSelection.Length > 0)
					{
						refEntity.LayerName = buFoamCalc.varTemps.LayerSelection;
					}
					clsInit.appCommand.AddEntity(refEntity);
					Point3D pntEnd = null;
					if (Blocks[i].Pattern[j].sortEntities[Blocks[i].Pattern[j].sortEntities.Count - 1].sortDirection != entitySortDirection.Normal)
					{
						clsInit.cVector5.GetEntityEndPointByCamDirection(Blocks[i].Pattern[j].sortEntities[Blocks[i].Pattern[j].sortEntities.Count - 1], ref pntEnd);
					}
					else
					{
						clsInit.cVector5.GetEntityEndPointByCamDirection(Blocks[i].Pattern[j].sortEntities[Blocks[i].Pattern[j].sortEntities.Count - 1], ref pntEnd);
					}
					if (refPlane == Plane.YZ)
					{
						pntEnd.X = activeFoam.Material.Size.Width;
					}
					refEntity = null;
					clsInit.cFoamCut.CreateMarkCircleEntity(pntEnd, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter + 2.0, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity);
					refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
					if (buFoamCalc.varTemps.LayerSelection.Length > 0)
					{
						refEntity.LayerName = buFoamCalc.varTemps.LayerSelection;
					}
					ccVars.UndoDont = true;
					clsInit.appCommand.AddEntity(refEntity);
					Entity copiedEntity2 = null;
					buEntity.Copy(Blocks[i].Pattern[j].sortEntities[0], ref copiedEntity2);
					copiedEntity2.LayerName = buFoamCalc.varTemps.LayerDefault;
					if (buFoamCalc.varTemps.LayerSelection.Length > 0)
					{
						copiedEntity2.LayerName = buFoamCalc.varTemps.LayerSelection;
					}
					ccVars.UndoDont = true;
					clsInit.appCommand.AddEntity(copiedEntity2);
					copiedEntity2 = null;
					buEntity.Copy(Blocks[i].Pattern[j].sortEntities[Blocks[i].Pattern[j].sortEntities.Count - 1], ref copiedEntity2);
					copiedEntity2.LayerName = buFoamCalc.varTemps.LayerDefault;
					if (buFoamCalc.varTemps.LayerSelection.Length > 0)
					{
						copiedEntity2.LayerName = buFoamCalc.varTemps.LayerSelection;
					}
					if (refPlane == Plane.YZ)
					{
						copiedEntity2.Translate(activeFoam.Material.Size.Width, 0.0);
					}
					ccVars.UndoDont = true;
					clsInit.appCommand.AddEntity(copiedEntity2);
				}
				if (Blocks[i].Pattern[j].foamEntities == null)
				{
					continue;
				}
				int num = 0;
				for (int l = 0; l <= Blocks[i].Pattern[j].foamEntities.Count - 1; l++)
				{
					for (int m = 0; m <= Blocks[i].Pattern[j].foamEntities[l].GroupEntity.Outside.Entities.Count - 1; m++)
					{
						buEntity buEntity2 = Blocks[i].Pattern[j].foamEntities[l].GroupEntity.Outside.Entities[m];
						Entity copiedEntity3 = null;
						buEntity.Copy(Blocks[i].Pattern[j].foamEntities[l].GroupEntity.Outside.Entities[m], ref copiedEntity3);
						if (refPlane == Plane.YZ)
						{
							copiedEntity3.Translate(activeFoam.Material.Size.Width, 0.0);
						}
						if (ccVars.Pages[ccVars.PageIndex].Layers.Count >= 4)
						{
							copiedEntity3.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[3].Name;
						}
						ccVars.UndoDont = true;
						copiedEntity3.LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
						{
							copiedEntity3.LayerName = buFoamCalc.varTemps.LayerWirePattern;
						}
						clsInit.appCommand.AddEntity(copiedEntity3);
						if (!(ccVars.Action == actionTypeBU.foamManuelSelect && !flag))
						{
							continue;
						}
						num++;
						if (m != 0)
						{
							Point3D pntEnd2 = null;
							clsInit.cVector5.GetEntityEndPointByCamDirection(buEntity2, ref pntEnd2);
							if (refPlane == Plane.YZ)
							{
								pntEnd2.X = activeFoam.Material.Size.Width;
							}
							Entity refEntity2 = null;
							clsInit.cFoamCut.CreateMarkCircleEntity(pntEnd2, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity2);
							ccVars.UndoDont = true;
							refEntity2.LayerName = buFoamCalc.varTemps.LayerDefault;
							if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
							{
								refEntity2.LayerName = buFoamCalc.varTemps.LayerWirePattern;
							}
							clsInit.appCommand.AddEntity(refEntity2);
							continue;
						}
						Entity refEntity3 = null;
						Point3D point3D = buVector5.ToPoint3D(buEntity2.StartPoint);
						Point3D point3D2 = buVector5.ToPoint3D(buEntity2.EndPoint);
						if (refPlane == Plane.YZ)
						{
							point3D.X = activeFoam.Material.Size.Width;
							point3D2.X = activeFoam.Material.Size.Width;
						}
						clsInit.cFoamCut.CreateMarkCircleEntity(point3D, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity3);
						ccVars.UndoDont = true;
						refEntity3.LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
						{
							refEntity3.LayerName = buFoamCalc.varTemps.LayerWirePattern;
						}
						clsInit.appCommand.AddEntity(refEntity3);
						refEntity3 = null;
						clsInit.cFoamCut.CreateMarkCircleEntity(point3D2, refPlane, buFoamCalc.varFoamSettings.StartPointDiameter, entityTypeDefination.Mark, buFoamCalc.varFoamSettings.MarkColor, ref refEntity3);
						ccVars.UndoDont = true;
						refEntity3.LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.LayerWirePattern.Length > 0)
						{
							refEntity3.LayerName = buFoamCalc.varTemps.LayerWirePattern;
						}
						clsInit.appCommand.AddEntity(refEntity3);
					}
				}
				if (num > 0)
				{
					flag = true;
				}
			}
		}
	}

	public void BlockSizeAdjustFromPlane(FoamPlaneType refPlane)
	{
		if (refPlane == FoamPlaneType.XZ)
		{
			double num = 0.0;
			if (varCalc.isVertical)
			{
				buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
				buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Width;
				if (activeFoam.BlockXZ.Count > 0)
				{
					buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Width - activeFoam.BlockXZ[activeFoam.BlockXZ.Count - 1].LeftMax;
				}
			}
			else
			{
				buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Width;
				if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.DownToUp)
				{
					buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
					if (activeFoam.BlockXZ.Count > 0)
					{
						num = activeFoam.BlockXZ[activeFoam.BlockXZ.Count - 1].TopZ;
						buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth - num;
					}
				}
				if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
				{
					buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
					if (activeFoam.BlockXZ.Count > 0)
					{
						num = activeFoam.BlockXZ[activeFoam.BlockXZ.Count - 1].BottomZ;
						buFoamCalc.varFoamRunSettings.BlockHeight = num;
					}
				}
			}
			if ((frmWave != null) & (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave))
			{
				frmWave.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				frmWave.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
			}
			if ((frmPattern != null) & (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern))
			{
				frmPattern.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				frmPattern.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
			}
			if (((frmSlice != null) & (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice)) && buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.SlicesHorizontal)
			{
				frmSlice.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				frmSlice.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
			}
		}
		if (refPlane != FoamPlaneType.YZ)
		{
			return;
		}
		double num2 = 0.0;
		if (varCalc.isVertical)
		{
			buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
			buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Height;
			if (activeFoam.BlockYZ.Count > 0)
			{
				buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Height - activeFoam.BlockYZ[activeFoam.BlockYZ.Count - 1].LeftMax;
			}
		}
		else
		{
			buFoamCalc.varFoamRunSettings.BlockWidth = activeFoam.Material.Size.Height;
			if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.DownToUp)
			{
				buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
				if (activeFoam.BlockYZ.Count > 0)
				{
					num2 = activeFoam.BlockYZ[activeFoam.BlockYZ.Count - 1].TopZ;
					buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth - num2;
				}
			}
			if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
			{
				buFoamCalc.varFoamRunSettings.BlockHeight = activeFoam.Material.Size.Depth;
				if (activeFoam.BlockYZ.Count > 0)
				{
					num2 = activeFoam.BlockYZ[activeFoam.BlockYZ.Count - 1].BottomZ;
					buFoamCalc.varFoamRunSettings.BlockHeight = num2;
				}
			}
		}
		if ((frmWave != null) & (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave))
		{
			frmWave.PropertiesForm.Inited = false;
			frmWave.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
			frmWave.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
			frmWave.PropertiesForm.Inited = true;
		}
		if ((frmPattern != null) & (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern))
		{
			frmPattern.PropertiesForm.Inited = false;
			frmPattern.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
			frmPattern.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
			frmPattern.PropertiesForm.Inited = true;
		}
		if ((frmSlice != null) & (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice))
		{
			frmSlice.PropertiesForm.Inited = false;
			if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.SlicesHorizontal)
			{
				frmSlice.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				frmSlice.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
			}
			if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.SlicesVertical)
			{
				frmSlice.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				frmSlice.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
			}
			frmSlice.PropertiesForm.Inited = true;
		}
	}

	public void CreatePanelFromJob(ref FoamItem Job, FoamCreatePanelOptions Option)
	{
		try
		{
			if (!Option.DrawAll)
			{
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData is CustomData)
					{
						CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
						if ((customData.typeDefination == entityTypeDefination.Sorted) & Option.DeleteSort)
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
						}
						if ((customData.typeDefination == entityTypeDefination.Tool) & Option.DeleteTool)
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
						}
					}
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			}
			else
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			}
			if (Job != null)
			{
				if (Option.DrawAll)
				{
					Brep brep = Brep.CreateBox(Job.Material.Size.Width + 0.2, Job.Material.Size.Height + 0.2, Job.Material.Size.Depth + 0.2);
					brep.Translate(-0.1, -0.1, -0.1);
					brep.Rebuild(0.1);
					Job.SolidEntity = brep;
					Job.SolidEntity.Color = Color.FromArgb(buFoamCalc.varFoamSettings.FoamBaseTransparency, buFoamCalc.varFoamSettings.FoamBaseColor);
					Job.SolidEntity.ColorMethod = colorMethodType.byEntity;
					Job.SolidEntity.Regen(new RegenParams(0.01));
					if (ccVars.Pages[ccVars.PageIndex].Layers.Count >= 2)
					{
						Job.SolidEntity.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[1].Name;
					}
					Entity copiedEnt = null;
					ccVars.UndoDont = true;
					buVector5.CopyEntities(activeFoam.SolidEntity, ref copiedEnt);
					copiedEnt.Selectable = false;
					copiedEnt.LayerName = buFoamCalc.varTemps.LayerDefault;
					if (buFoamCalc.varTemps.LayerFoam.Length > 0)
					{
						copiedEnt.LayerName = buFoamCalc.varTemps.LayerFoam;
					}
					clsInit.appCommand.AddEntity(copiedEnt);
					DrawBlock(Job.BlockXZ, Plane.XZ);
					DrawBlock(Job.BlockYZ, Plane.YZ);
				}
				for (int j = 0; j <= Job.sortedEntitiesXZ.Count - 1; j++)
				{
					List<Entity> createdEntities = new List<Entity>();
					clsInit.cFoamCut.CreateSortEntitiesAndArrow(Job.sortedEntitiesXZ[j], Plane.XZ, ref createdEntities);
					for (int k = 0; k <= createdEntities.Count - 1; k++)
					{
						ccVars.UndoDont = true;
						createdEntities[k].LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.LayerSelection.Length > 0)
						{
							createdEntities[k].LayerName = buFoamCalc.varTemps.LayerSelection;
						}
						clsInit.appCommand.AddEntity(createdEntities[k]);
					}
				}
				for (int l = 0; l <= Job.sortedEntitiesYZ.Count - 1; l++)
				{
					List<Entity> createdEntities2 = new List<Entity>();
					clsInit.cFoamCut.CreateSortEntitiesAndArrow(Job.sortedEntitiesYZ[l], Plane.YZ, ref createdEntities2);
					for (int m = 0; m <= createdEntities2.Count - 1; m++)
					{
						createdEntities2[m].Translate(activeFoam.Material.Size.Width + 0.5, 0.0);
						createdEntities2[m].LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.LayerSelection.Length > 0)
						{
							createdEntities2[m].LayerName = buFoamCalc.varTemps.LayerSelection;
						}
						ccVars.UndoDont = true;
						clsInit.appCommand.AddEntity(createdEntities2[m]);
					}
				}
				for (int n = 0; n <= Job.CamXZ.CamPoints.Count - 1; n++)
				{
					for (int num = 0; num <= Job.CamXZ.CamPoints[n].Points.Count - 1; num++)
					{
						if (Job.CamXZ.CamPoints[n].Points[num].IsMark | Job.CamXZ.CamPoints[n].Points[num].IsLimit)
						{
							Color color = buFoamCalc.varFoamSettings.LimitExceedColor;
							if (Job.CamXZ.CamPoints[n].Points[num].IsLimit)
							{
								color = buFoamCalc.varFoamSettings.RotationMoreThen180;
							}
							Point3D pntCenter = new Point3D(Job.CamXZ.CamPoints[n].Points[num].P9.X, Job.CamXZ.CamPoints[n].Points[num].P9.Z, Job.CamXZ.CamPoints[n].Points[num].P9.Y);
							Entity refEntity = null;
							clsInit.cFoamCut.CreateMarkCircleEntity(pntCenter, Plane.XZ, buFoamCalc.varFoamSettings.LastPointDiameter + 0.0, entityTypeDefination.Sorted, color, ref refEntity);
							ccVars.UndoDont = true;
							refEntity.LayerName = buFoamCalc.varTemps.LayerDefault;
							if (buFoamCalc.varTemps.LayerMark.Length > 0)
							{
								refEntity.LayerName = buFoamCalc.varTemps.LayerMark;
							}
							clsInit.appCommand.AddEntity(refEntity);
						}
					}
				}
				for (int num2 = 0; num2 <= Job.CamYZ.CamPoints.Count - 1; num2++)
				{
					for (int num3 = 0; num3 <= Job.CamYZ.CamPoints[num2].Points.Count - 1; num3++)
					{
						if (Job.CamYZ.CamPoints[num2].Points[num3].IsMark | Job.CamYZ.CamPoints[num2].Points[num3].IsLimit)
						{
							Color color2 = buFoamCalc.varFoamSettings.LimitExceedColor;
							if (Job.CamYZ.CamPoints[num2].Points[num3].IsLimit)
							{
								color2 = buFoamCalc.varFoamSettings.RotationMoreThen180;
							}
							Point3D pntCenter2 = new Point3D(Job.CamYZ.CamPoints[num2].Points[num3].P9.Z, Job.CamYZ.CamPoints[num2].Points[num3].P9.X, Job.CamYZ.CamPoints[num2].Points[num3].P9.Y);
							Entity refEntity2 = null;
							clsInit.cFoamCut.CreateMarkCircleEntity(pntCenter2, Plane.YZ, buFoamCalc.varFoamSettings.LastPointDiameter + 0.0, entityTypeDefination.Sorted, color2, ref refEntity2);
							ccVars.UndoDont = true;
							refEntity2.LayerName = buFoamCalc.varTemps.LayerDefault;
							if (buFoamCalc.varTemps.LayerMark.Length > 0)
							{
								refEntity2.LayerName = buFoamCalc.varTemps.LayerMark;
							}
							clsInit.appCommand.AddEntity(refEntity2);
						}
					}
				}
				if (ccVars.Action == actionTypeBU.foamManuelSelect)
				{
					if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ && Job.sortedEntitiesXZ.Count > 0)
					{
						Point3D pntEnd = new Point3D();
						clsInit.cVector5.GetEntityEndPointByCamDirection(Job.sortedEntitiesXZ[Job.sortedEntitiesXZ.Count - 1], ref pntEnd);
						Entity refEntity3 = null;
						clsInit.cFoamCut.CreateMarkHexagonEntity(pntEnd, Plane.XZ, buFoamCalc.varFoamSettings.LastPointDiameter, entityTypeDefination.Sorted, buFoamCalc.varFoamSettings.MarkLastColor, ref refEntity3);
						ccVars.UndoDont = true;
						refEntity3.LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.LayerSelection.Length > 0)
						{
							refEntity3.LayerName = buFoamCalc.varTemps.LayerSelection;
						}
						clsInit.appCommand.AddEntity(refEntity3);
					}
					if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ && Job.sortedEntitiesYZ.Count > 0)
					{
						Point3D pntEnd2 = new Point3D();
						clsInit.cVector5.GetEntityEndPointByCamDirection(Job.sortedEntitiesYZ[Job.sortedEntitiesYZ.Count - 1], ref pntEnd2);
						Entity refEntity4 = null;
						clsInit.cFoamCut.CreateMarkHexagonEntity(pntEnd2, Plane.YZ, buFoamCalc.varFoamSettings.LastPointDiameter, entityTypeDefination.Sorted, buFoamCalc.varFoamSettings.MarkLastColor, ref refEntity4);
						ccVars.UndoDont = true;
						refEntity4.LayerName = buFoamCalc.varTemps.LayerDefault;
						if (buFoamCalc.varTemps.LayerSelection.Length > 0)
						{
							refEntity4.LayerName = buFoamCalc.varTemps.LayerSelection;
						}
						clsInit.appCommand.AddEntity(refEntity4);
					}
				}
			}
			if (Option.DrawPreview)
			{
				DrawPreview();
			}
			clsItem.FrmFoamJob.txt_info.Text = doCalcululateAllInfo();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.02);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	public void ParameterChanged(object Data1, object Data2)
	{
		if (Data1 == null)
		{
			return;
		}
		string text = Data1.ToString();
		if (text == "HorizontalCount" && Data2 != null && Data2.GetType() == typeof(double))
		{
			double num = double.Parse(Data2.ToString());
			if (num > 0.0)
			{
				if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern)
				{
					buFoamCalc.varFoamRunSettings.BlockWidth = (buFoamCalc.varFoamRunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth) * num + buFoamCalc.varFoamRunSettings.PatternWidthStartOffset + buFoamCalc.varFoamRunSettings.PatternWidthEndOffset;
					frmPattern.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				}
				if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
				{
					double waveFormShapeCommonWidth = buFoamCalc.varFoamRunSettings.WaveFormShapeCommonWidth;
					buFoamCalc.varFoamRunSettings.BlockWidth = waveFormShapeCommonWidth * (double)buFoamCalc.varFoamRunSettings.WaveFormRepeatCount * num + buFoamCalc.varFoamSettings.PatternDistancesHeight + buFoamCalc.varFoamRunSettings.PatternWidthStartOffset + buFoamCalc.varFoamRunSettings.PatternWidthEndOffset;
					frmWave.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				}
				if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice)
				{
					buFoamCalc.varFoamRunSettings.BlockWidth = buFoamCalc.varFoamRunSettings.SlicesHeight * num + buFoamCalc.varFoamRunSettings.PatternWidthStartOffset + buFoamCalc.varFoamRunSettings.PatternWidthEndOffset;
					frmSlice.spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
				}
			}
		}
		if (text == "VerticalCount" && Data2 != null && Data2.GetType() == typeof(double))
		{
			double num2 = double.Parse(Data2.ToString());
			if (num2 > 0.0)
			{
				if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Pattern)
				{
					buFoamCalc.varFoamRunSettings.BlockHeight = (buFoamCalc.varFoamRunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight) * num2 + buFoamCalc.varFoamRunSettings.PatternHeightStartOffset + buFoamCalc.varFoamRunSettings.PatternHeightEndOffset;
					frmPattern.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
				}
				if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
				{
					double num3 = 2.0 * buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight;
					if ((buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.VForm) | (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.CForm))
					{
						num3 = 2.0 * buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight - buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight;
					}
					if (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.Pyramid)
					{
						num3 = buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight + (buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight - buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight);
					}
					if ((buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.Rectangle) | (buFoamCalc.varFoamRunSettings.TypeFoam == FoamType.UForm))
					{
						num3 = buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight + (buFoamCalc.varFoamRunSettings.WaveFormShapeCommonBaseHeight - buFoamCalc.varFoamRunSettings.WaveFormShapeCommonHeight);
					}
					buFoamCalc.varFoamRunSettings.BlockHeight = (num3 + buFoamCalc.varFoamRunSettings.WaveFormSpace) * num2 + buFoamCalc.varFoamSettings.PatternDistancesHeight + buFoamCalc.varFoamRunSettings.PatternHeightStartOffset + buFoamCalc.varFoamRunSettings.PatternHeightEndOffset;
					frmWave.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
					FoamUpdateArg data = new FoamUpdateArg();
					OperationDataChanged(buFoamCalc.varFoamRunSettings, data);
				}
				if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Slice)
				{
					buFoamCalc.varFoamRunSettings.BlockHeight = buFoamCalc.varFoamRunSettings.SlicesHeight * num2 + buFoamCalc.varFoamRunSettings.PatternHeightStartOffset + buFoamCalc.varFoamRunSettings.PatternHeightEndOffset;
					frmSlice.spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
				}
			}
		}
		if (text == "FoamSize" && Data2 != null && Data2 is SizeObject)
		{
			activeFoam.Material.Size = new SizeObject((SizeObject)Data2);
			CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: false));
		}
		if (text == "VelCut" && Data2 != null && Data2.GetType() == typeof(double))
		{
			double cuttingFeed = double.Parse(Data2.ToString());
			buFoamCalc.varFoamSettings.CuttingFeed = cuttingFeed;
		}
		if (text == "VelLeadIn" && Data2 != null && Data2.GetType() == typeof(double))
		{
			double entryFeed = double.Parse(Data2.ToString());
			buFoamCalc.varFoamSettings.EntryFeed = entryFeed;
		}
		if (text == "VelLeadOut" && Data2 != null && Data2.GetType() == typeof(double))
		{
			double leaveFeed = double.Parse(Data2.ToString());
			buFoamCalc.varFoamSettings.LeaveFeed = leaveFeed;
		}
		if (text == "VelConnection" && Data2 != null && Data2.GetType() == typeof(double))
		{
			double connectionFeed = double.Parse(Data2.ToString());
			buFoamCalc.varFoamSettings.ConnectionFeed = connectionFeed;
		}
	}

	public void OperationDataChanged(object Data1, object Data2)
	{
		FoamUpdateArg foamUpdateArg = new FoamUpdateArg();
		foamUpdateArg = (FoamUpdateArg)Data2;
		if (!(Data1 is FoamRuntimeSettings))
		{
			return;
		}
		FoamRuntimeSettings foamRuntimeSettings = Data1 as FoamRuntimeSettings;
		buFoamCalc.varFoamRunSettings = new FoamRuntimeSettings(foamRuntimeSettings);
		buFoamCalc.varFoamSettings.PatternDistancesHeight = foamUpdateArg.PatternSpaceHeight;
		buFoamCalc.varFoamSettings.PatternDistancesWidth = foamUpdateArg.PatternSpaceWidth;
		if ((foamUpdateArg.Command == "PlaneYZ") | (foamUpdateArg.Command == "PlaneXZ"))
		{
			if (foamRuntimeSettings.planeNames != FoamPlaneType.XZ)
			{
				cmdPlaneYZ(ZoomFit: false);
				foamRuntimeSettings.BlockHeight = buFoamCalc.varFoamRunSettings.BlockHeight;
				foamRuntimeSettings.BlockWidth = buFoamCalc.varFoamRunSettings.BlockWidth;
			}
			else
			{
				cmdPlaneXZ(ZoomFit: false);
				foamRuntimeSettings.BlockHeight = buFoamCalc.varFoamRunSettings.BlockHeight;
				foamRuntimeSettings.BlockWidth = buFoamCalc.varFoamRunSettings.BlockWidth;
			}
		}
		if (foamUpdateArg.Finished)
		{
			doAddOperation(foamRuntimeSettings);
			if (foamRuntimeSettings.TypeFoam == FoamType.VForm)
			{
				foamRuntimeSettings.WaveFormVShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
				foamRuntimeSettings.WaveFormVShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
				foamRuntimeSettings.WaveFormVShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
			}
			if (foamRuntimeSettings.TypeFoam == FoamType.Pyramid)
			{
				foamRuntimeSettings.WaveFormPyramidShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
				foamRuntimeSettings.WaveFormPyramidShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
				foamRuntimeSettings.WaveFormPyramidShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
				foamRuntimeSettings.WaveFormPyramidShapeCount = foamRuntimeSettings.WaveFormShapeCommonCount;
			}
			if (foamRuntimeSettings.TypeFoam == FoamType.UForm)
			{
				foamRuntimeSettings.WaveFormUShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
				foamRuntimeSettings.WaveFormUShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
				foamRuntimeSettings.WaveFormUShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
			}
			if (foamRuntimeSettings.TypeFoam == FoamType.CForm)
			{
				foamRuntimeSettings.WaveFormCShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
				foamRuntimeSettings.WaveFormCShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
				foamRuntimeSettings.WaveFormCShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
			}
			if (foamRuntimeSettings.TypeFoam == FoamType.SForm)
			{
				foamRuntimeSettings.WaveFormSShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
				foamRuntimeSettings.WaveFormSShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
				foamRuntimeSettings.WaveFormSShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
			}
			if (foamRuntimeSettings.TypeFoam == FoamType.ZForm)
			{
				foamRuntimeSettings.WaveFormZShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
				foamRuntimeSettings.WaveFormZShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
				foamRuntimeSettings.WaveFormZShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
			}
			if (foamRuntimeSettings.TypeFoam == FoamType.Rectangle)
			{
				foamRuntimeSettings.WaveFormRectShapeBaseHeight = foamRuntimeSettings.WaveFormShapeCommonBaseHeight;
				foamRuntimeSettings.WaveFormRectShapeHeight = foamRuntimeSettings.WaveFormShapeCommonHeight;
				foamRuntimeSettings.WaveFormRectShapeWidth = foamRuntimeSettings.WaveFormShapeCommonWidth;
			}
			buFoamCalc.varFoamRunSettings = new FoamRuntimeSettings(foamRuntimeSettings);
			return;
		}
		if (foamRuntimeSettings.TypeFoam != FoamType.VForm)
		{
			if (foamRuntimeSettings.TypeFoam != FoamType.SForm)
			{
				if (foamRuntimeSettings.TypeFoam != FoamType.CForm)
				{
					if (foamRuntimeSettings.TypeFoam != FoamType.ZForm)
					{
						if (foamRuntimeSettings.TypeFoam != FoamType.UForm)
						{
							if (foamRuntimeSettings.TypeFoam != FoamType.Rectangle)
							{
								if (foamRuntimeSettings.TypeFoam != FoamType.Pyramid)
								{
									if (foamRuntimeSettings.TypeFoam != FoamType.FromDrawing)
									{
										if (foamRuntimeSettings.TypeFoam != FoamType.SlicesHorizontal)
										{
											if (foamRuntimeSettings.TypeFoam != FoamType.SlicesVertical)
											{
												if (foamRuntimeSettings.TypeFoam != FoamType.SingleLine && foamRuntimeSettings.TypeFoam == FoamType.Pattern)
												{
													List<FoamPattern> FoamPatterns = new List<FoamPattern>();
													doCalculatePattern(foamRuntimeSettings, Finished: false, ref FoamPatterns);
												}
											}
											else
											{
												List<FoamPattern> FoamPatterns2 = new List<FoamPattern>();
												doCalculateSlicesVertical(foamRuntimeSettings, Finished: false, foamRuntimeSettings.TypeFoam, ref FoamPatterns2);
											}
										}
										else
										{
											List<FoamPattern> FoamPatterns3 = new List<FoamPattern>();
											doCalculateSlicesHorizontal(foamRuntimeSettings, Finished: false, foamRuntimeSettings.TypeFoam, ref FoamPatterns3);
										}
									}
									else
									{
										List<FoamPattern> FoamPatterns4 = new List<FoamPattern>();
										doCalculatePattern(foamRuntimeSettings, Finished: false, ref FoamPatterns4);
									}
								}
								else
								{
									List<FoamPattern> FoamPatterns5 = new List<FoamPattern>();
									doCalculateWaveShape(foamRuntimeSettings, Finished: false, foamRuntimeSettings.TypeFoam, ref FoamPatterns5);
								}
							}
							else
							{
								List<FoamPattern> FoamPatterns6 = new List<FoamPattern>();
								doCalculateWaveShape(foamRuntimeSettings, Finished: false, foamRuntimeSettings.TypeFoam, ref FoamPatterns6);
							}
						}
						else
						{
							List<FoamPattern> FoamPatterns7 = new List<FoamPattern>();
							doCalculateWaveShape(foamRuntimeSettings, Finished: false, foamRuntimeSettings.TypeFoam, ref FoamPatterns7);
						}
					}
					else
					{
						List<FoamPattern> FoamPatterns8 = new List<FoamPattern>();
						doCalculateWaveShape(foamRuntimeSettings, Finished: false, foamRuntimeSettings.TypeFoam, ref FoamPatterns8);
					}
				}
				else
				{
					List<FoamPattern> FoamPatterns9 = new List<FoamPattern>();
					doCalculateWaveShape(foamRuntimeSettings, Finished: false, foamRuntimeSettings.TypeFoam, ref FoamPatterns9);
				}
			}
			else
			{
				List<FoamPattern> FoamPatterns10 = new List<FoamPattern>();
				doCalculateWaveShape(foamRuntimeSettings, Finished: false, FoamType.SForm, ref FoamPatterns10);
			}
		}
		else
		{
			List<FoamPattern> FoamPatterns11 = new List<FoamPattern>();
			doCalculateWaveShape(foamRuntimeSettings, Finished: false, FoamType.VForm, ref FoamPatterns11);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void OperationDataCancel()
	{
		clsInit.appCommand.Reset();
	}

	public void doUndoSelection()
	{
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ && activeFoam.sortedEntitiesXZ.Count > 0)
		{
			if (!((activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.Upper) | (activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin) | (activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut)))
			{
				int num = activeFoam.sortedEntitiesXZ.Count - 1;
				while (num >= 0)
				{
					if (!((activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.Upper) | (activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin) | (activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut)))
					{
						int sequence = activeFoam.sortedEntitiesXZ[num].Info.Sequence;
						if ((sequence >= 0) & (sequence <= sortRefEntities.Count - 1))
						{
							sortRefEntities[sequence].Info.CamSelected = false;
						}
						activeFoam.sortedEntitiesXZ.RemoveAt(num);
						num--;
						continue;
					}
					Point3D pntEnd = new Point3D();
					clsInit.cVector5.GetEntityEndPointByCamDirection(activeFoam.sortedEntitiesXZ[num], ref pntEnd);
					ccVars.pntBase = buVector5.ToPoint3D(pntEnd);
					buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd);
					buVector5.PointClickData.isPointOnEntity = true;
					CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
					return;
				}
			}
			else
			{
				activeFoam.sortedEntitiesXZ.RemoveAt(activeFoam.sortedEntitiesXZ.Count - 1);
				buVector5.PointClickData.isPointOnEntity = false;
				if (activeFoam.sortedEntitiesXZ.Count > 0)
				{
					Point3D pntEnd2 = new Point3D();
					clsInit.cVector5.GetEntityEndPointByCamDirection(activeFoam.sortedEntitiesXZ[activeFoam.sortedEntitiesXZ.Count - 1], ref pntEnd2);
					ccVars.pntBase = buVector5.ToPoint3D(pntEnd2);
					buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd2);
					CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
				}
			}
		}
		if (buFoamCalc.varFoamRunSettings.planeNames != FoamPlaneType.YZ || activeFoam.sortedEntitiesYZ.Count <= 0)
		{
			return;
		}
		if (!((activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.Upper) | (activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin) | (activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut)))
		{
			int num2 = activeFoam.sortedEntitiesYZ.Count - 1;
			while (true)
			{
				if (num2 >= 0)
				{
					if ((activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.Upper) | (activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadin) | (activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1].typeDefination == entityTypeDefination.CamLeadOut))
					{
						break;
					}
					int sequence2 = activeFoam.sortedEntitiesYZ[num2].Info.Sequence;
					if ((sequence2 >= 0) & (sequence2 <= sortRefEntities.Count - 1))
					{
						sortRefEntities[sequence2].Info.CamSelected = false;
					}
					activeFoam.sortedEntitiesYZ.RemoveAt(num2);
					num2--;
					continue;
				}
				return;
			}
			Point3D pntEnd3 = new Point3D();
			clsInit.cVector5.GetEntityEndPointByCamDirection(activeFoam.sortedEntitiesYZ[num2], ref pntEnd3);
			ccVars.pntBase = buVector5.ToPoint3D(pntEnd3);
			buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd3);
			buVector5.PointClickData.isPointOnEntity = true;
			CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
		}
		else
		{
			activeFoam.sortedEntitiesYZ.RemoveAt(activeFoam.sortedEntitiesYZ.Count - 1);
			buVector5.PointClickData.isPointOnEntity = false;
			if (activeFoam.sortedEntitiesYZ.Count > 0)
			{
				Point3D pntEnd4 = new Point3D();
				clsInit.cVector5.GetEntityEndPointByCamDirection(activeFoam.sortedEntitiesYZ[activeFoam.sortedEntitiesYZ.Count - 1], ref pntEnd4);
				ccVars.pntBase = buVector5.ToPoint3D(pntEnd4);
				buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(pntEnd4);
				CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
			}
		}
	}

	public void doFinishSelection()
	{
		doReset();
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
		activeFoam.isGCodeCreated = false;
	}

	public void doDeleteSelection(FoamPlaneType refPlane)
	{
		if (buString5.MessageBoxQuestion(buFoamCalc.LangFoamMessage[20]) == DialogResult.Yes)
		{
			if (refPlane == FoamPlaneType.XZ)
			{
				activeFoam.isGCodeCreated = false;
				activeFoam.CamXZ = new camTp();
				activeFoam.sortedEntitiesXZ.Clear();
				CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
				JobUpdate(FillPages: true, "", null, -1);
			}
			if (refPlane == FoamPlaneType.YZ)
			{
				activeFoam.isGCodeCreated = false;
				activeFoam.CamYZ = new camTp();
				activeFoam.sortedEntitiesYZ.Clear();
				CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
				JobUpdate(FillPages: true, "", null, -1);
			}
			activeFoam.isGCodeCreated = false;
		}
	}

	public void doManuelSelection(Point3D refPoint)
	{
		ccVars.enableViewportDrawCurrentLine = true;
		ccVars.pntBase = buVector5.ToPoint3D(refPoint);
		sortbuSettings_0.Option.Jump = false;
		sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
		if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.CW)
		{
			if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.CCW)
			{
				if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.LowerIndex)
				{
					if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.HigherIndex)
					{
						if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.Jump)
						{
							if (sortbuSettings_0.Option.FirstRules == SortingFirstCatchRulesType.Manuel)
							{
								sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.Stop;
							}
						}
						else
						{
							sortbuSettings_0.Option.Jump = true;
						}
					}
					else
					{
						sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.HigherIndex;
					}
				}
				else
				{
					sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
				}
			}
			else
			{
				sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.CCW;
			}
		}
		else
		{
			sortbuSettings_0.Option.IntersectionRules = SortingIntersectionRulesType.CW;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			List<buEntity> copiedEntities = new List<buEntity>();
			buEntity.Copy(activeFoam.sortedEntitiesXZ, ref copiedEntities);
			if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.Jump)
			{
				for (int i = 0; i <= activeFoam.BlockXZ.Count - 1; i++)
				{
					for (int j = 0; j <= activeFoam.BlockXZ[i].Pattern.Count - 1; j++)
					{
						if (activeFoam.BlockXZ[i].Pattern[j].sortEntities.Count <= 0)
						{
							continue;
						}
						buEntity buEntity2 = activeFoam.BlockXZ[i].Pattern[j].sortEntities[0];
						buEntity buEntity3 = activeFoam.BlockXZ[i].Pattern[j].sortEntities[activeFoam.BlockXZ[i].Pattern[j].sortEntities.Count - 1];
						if (!buCompare5.EQ(buEntity2.StartPoint, refPoint, 0.1))
						{
							if (!buCompare5.EQ(buEntity3.EndPoint, refPoint, 0.1))
							{
								continue;
							}
							if (Point3D.Distance(sortPointClickResult_0.LastPoint, refPoint) > 0.1)
							{
								buLine buLine2 = new buLine(sortPointClickResult_0.LastPoint, refPoint);
								buLine2.typeDefination = entityTypeDefination.Upper;
								activeFoam.sortedEntitiesXZ.Add(buLine2);
							}
							List<buEntity> copiedEntities2 = new List<buEntity>();
							buEntity.Copy(activeFoam.BlockXZ[i].Pattern[j].sortEntities, ref copiedEntities2);
							copiedEntities2.Reverse();
							for (int k = 0; k <= copiedEntities2.Count - 1; k++)
							{
								buEntity copiedEntity = null;
								buEntity.Copy(copiedEntities2[k], ref copiedEntity);
								if (copiedEntity.sortDirection != entitySortDirection.Normal)
								{
									copiedEntity.sortDirection = entitySortDirection.Normal;
								}
								else
								{
									copiedEntity.sortDirection = entitySortDirection.Reverse;
								}
								activeFoam.sortedEntitiesXZ.Add(copiedEntity);
							}
							sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(buEntity2.StartPoint);
							ccVars.pntBase = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
							buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
							buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
							CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
							return;
						}
						if (Point3D.Distance(sortPointClickResult_0.LastPoint, refPoint) > 0.1)
						{
							buLine buLine3 = new buLine(sortPointClickResult_0.LastPoint, refPoint);
							buLine3.typeDefination = entityTypeDefination.Upper;
							activeFoam.sortedEntitiesXZ.Add(buLine3);
						}
						for (int l = 0; l <= activeFoam.BlockXZ[i].Pattern[j].sortEntities.Count - 1; l++)
						{
							buEntity copiedEntity2 = null;
							buEntity.Copy(activeFoam.BlockXZ[i].Pattern[j].sortEntities[l], ref copiedEntity2);
							activeFoam.sortedEntitiesXZ.Add(copiedEntity2);
						}
						sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(buEntity3.EndPoint);
						ccVars.pntBase = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
						buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
						buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
						CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
						return;
					}
				}
			}
			sortbuSettings_0.Option.refPlane = Plane.XZ;
			clsInit.cVector5.SortEntitiesByClick(refPoint, ref sortRefEntities, sortbuSettings_0, ref activeFoam.sortedEntitiesXZ, ref sortPointClickResult_0);
			ccVars.pntBase = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			List<buEntity> copiedEntities3 = new List<buEntity>();
			buEntity.Copy(activeFoam.sortedEntitiesYZ, ref copiedEntities3);
			if (sortbuSettings_0.Option.FirstRules != SortingFirstCatchRulesType.Jump)
			{
				for (int m = 0; m <= activeFoam.BlockYZ.Count - 1; m++)
				{
					for (int n = 0; n <= activeFoam.BlockYZ[m].Pattern.Count - 1; n++)
					{
						if (activeFoam.BlockYZ[m].Pattern[n].sortEntities.Count <= 0)
						{
							continue;
						}
						buEntity buEntity4 = activeFoam.BlockYZ[m].Pattern[n].sortEntities[0];
						buEntity buEntity5 = activeFoam.BlockYZ[m].Pattern[n].sortEntities[activeFoam.BlockYZ[m].Pattern[n].sortEntities.Count - 1];
						if (!buCompare5.EQ(buEntity4.StartPoint, refPoint, 0.1))
						{
							if (!buCompare5.EQ(buEntity5.EndPoint, refPoint, 0.1))
							{
								continue;
							}
							if (Point3D.Distance(sortPointClickResult_0.LastPoint, refPoint) > 0.1)
							{
								buLine buLine4 = new buLine(sortPointClickResult_0.LastPoint, refPoint);
								buLine4.typeDefination = entityTypeDefination.Upper;
								activeFoam.sortedEntitiesXZ.Add(buLine4);
							}
							List<buEntity> copiedEntities4 = new List<buEntity>();
							buEntity.Copy(activeFoam.BlockYZ[m].Pattern[n].sortEntities, ref copiedEntities4);
							copiedEntities4.Reverse();
							for (int num = 0; num <= copiedEntities4.Count - 1; num++)
							{
								buEntity copiedEntity3 = null;
								buEntity.Copy(copiedEntities4[num], ref copiedEntity3);
								if (copiedEntity3.sortDirection != entitySortDirection.Normal)
								{
									copiedEntity3.sortDirection = entitySortDirection.Normal;
								}
								else
								{
									copiedEntity3.sortDirection = entitySortDirection.Reverse;
								}
								activeFoam.sortedEntitiesXZ.Add(copiedEntity3);
							}
							sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(buEntity4.StartPoint);
							ccVars.pntBase = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
							buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
							buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
							CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
							return;
						}
						if (Point3D.Distance(sortPointClickResult_0.LastPoint, refPoint) > 0.1)
						{
							buLine buLine5 = new buLine(sortPointClickResult_0.LastPoint, refPoint);
							buLine5.typeDefination = entityTypeDefination.Upper;
							activeFoam.sortedEntitiesXZ.Add(buLine5);
						}
						for (int num2 = 0; num2 <= activeFoam.BlockYZ[m].Pattern[n].sortEntities.Count - 1; num2++)
						{
							buEntity copiedEntity4 = null;
							buEntity.Copy(activeFoam.BlockYZ[m].Pattern[n].sortEntities[num2], ref copiedEntity4);
							activeFoam.sortedEntitiesXZ.Add(copiedEntity4);
						}
						sortPointClickResult_0.LastPoint = buVector5.ToPoint3D(buEntity5.EndPoint);
						ccVars.pntBase = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
						buVector5.PointClickData.CatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
						buVector5.PointClickData.PreCatchPoint = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
						CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
						return;
					}
				}
			}
			sortbuSettings_0.Option.refPlane = Plane.YZ;
			clsInit.cVector5.SortEntitiesByClick(refPoint, ref sortRefEntities, sortbuSettings_0, ref activeFoam.sortedEntitiesYZ, ref sortPointClickResult_0);
			ccVars.pntBase = buVector5.ToPoint3D(sortPointClickResult_0.LastPoint);
		}
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
	}

	public void doAddFoam(MaterialBase5 Mat, bool New)
	{
		if (ccVars.Pages.Count > 0)
		{
			if (New)
			{
				activeFoam = new FoamItem();
			}
			if (activeFoam == null)
			{
				activeFoam = new FoamItem();
			}
			activeFoam.Material = new MaterialBase5(Mat);
			CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
			if (New)
			{
				clsInit.appCommand.PagesUpdate(FillPages: true, "");
				clsInit.appCommand.cmdViewZoomFit();
				clsInit.appCommand.cmdViewZoomOut();
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public string doCalcululateAllInfo()
	{
		string text = "";
		if (activeFoam != null)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			TpPnt9D tpPnt9D = new TpPnt9D();
			num4 = activeFoam.Material.Size.Width * activeFoam.Material.Size.Depth;
			num8 = activeFoam.Material.Size.Height * activeFoam.Material.Size.Depth;
			for (int i = 0; i <= activeFoam.BlockXZ.Count - 1; i++)
			{
				FoamBlock foamBlock = activeFoam.BlockXZ[i];
				for (int j = 0; j <= foamBlock.Pattern.Count - 1; j++)
				{
					num3 += activeFoam.BlockXZ[i].Pattern[j].Info.TotalArea;
				}
			}
			for (int k = 0; k <= activeFoam.sortedEntitiesXZ.Count - 1; k++)
			{
				num += clsInit.cVector5.Length3D(activeFoam.sortedEntitiesXZ[k].Vertices);
			}
			for (int l = 0; l <= activeFoam.CamXZ.CamPoints.Count - 1; l++)
			{
				camTp camXZ = activeFoam.CamXZ;
				if (l > 0 && camXZ.CamPoints[l].Points.Count > 0)
				{
					TpPnt9D tpPnt9D2 = camXZ.CamPoints[l].Points[0];
					Point3D a = new Point3D(tpPnt9D2.P9.X, tpPnt9D2.P9.Y, tpPnt9D2.P9.Z);
					Point3D b = new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z);
					double num9 = Point3D.Distance(a, b);
					if (num9 > 0.0)
					{
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
						{
							num2 += Math.Round(num9 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
						}
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
						{
							num2 += Math.Round(num9 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
						}
					}
				}
				if (camXZ.CamPoints[l].Points.Count <= 0)
				{
					continue;
				}
				for (int m = 1; m <= camXZ.CamPoints[l].Points.Count - 1; m++)
				{
					TpPnt9D tpPnt9D3 = camXZ.CamPoints[l].Points[m - 1];
					TpPnt9D tpPnt9D4 = camXZ.CamPoints[l].Points[m];
					Point3D a2 = new Point3D(tpPnt9D3.P9.X, tpPnt9D3.P9.Y, tpPnt9D3.P9.Z);
					Point3D b2 = new Point3D(tpPnt9D4.P9.X, tpPnt9D4.P9.Y, tpPnt9D4.P9.Z);
					double num10 = Point3D.Distance(a2, b2);
					if (!(num10 > 0.0))
					{
						if (!(Math.Abs(tpPnt9D3.P9.C - tpPnt9D4.P9.C) > 0.0))
						{
							continue;
						}
						if (tpPnt9D4.Type != 1)
						{
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
							{
								num2 += Math.Round(Math.Abs(tpPnt9D3.P9.C - tpPnt9D4.P9.C) / buFoamCalc.varFoamSettings.MachineG0TangentSpeed, 3);
							}
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
							{
								num2 += Math.Round(Math.Abs(tpPnt9D3.P9.C - tpPnt9D4.P9.C) / (buFoamCalc.varFoamSettings.MachineG0TangentSpeed * 60.0), 3);
							}
						}
						else
						{
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
							{
								num2 += Math.Round(Math.Abs(tpPnt9D3.P9.C - tpPnt9D4.P9.C) / tpPnt9D4.Feed, 3);
							}
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
							{
								num2 += Math.Round(Math.Abs(tpPnt9D3.P9.C - tpPnt9D4.P9.C) / (tpPnt9D4.Feed * 60.0), 3);
							}
						}
					}
					else if (!((tpPnt9D4.Feed > 0.0) & ((tpPnt9D4.Type == 1) | (tpPnt9D4.Type == 2) | (tpPnt9D4.Type == 3))))
					{
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
						{
							num2 += Math.Round(num10 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
						}
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
						{
							num2 += Math.Round(num10 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
						}
					}
					else
					{
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
						{
							num2 += Math.Round(num10 / tpPnt9D4.Feed, 3);
						}
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
						{
							num2 += Math.Round(num10 / tpPnt9D4.Feed * 60.0, 3);
						}
					}
				}
				tpPnt9D = new TpPnt9D(camXZ.CamPoints[l].Points[camXZ.CamPoints[l].Points.Count - 1]);
			}
			for (int n = 0; n <= activeFoam.BlockYZ.Count - 1; n++)
			{
				FoamBlock foamBlock2 = activeFoam.BlockYZ[n];
				for (int num11 = 0; num11 <= foamBlock2.Pattern.Count - 1; num11++)
				{
					num7 += activeFoam.BlockYZ[n].Pattern[num11].Info.TotalArea;
				}
			}
			for (int num12 = 0; num12 <= activeFoam.sortedEntitiesYZ.Count - 1; num12++)
			{
				num5 += clsInit.cVector5.Length3D(activeFoam.sortedEntitiesYZ[num12].Vertices);
			}
			for (int num13 = 0; num13 <= activeFoam.CamYZ.CamPoints.Count - 1; num13++)
			{
				camTp camYZ = activeFoam.CamYZ;
				if (num13 > 0 && camYZ.CamPoints[num13].Points.Count > 0)
				{
					TpPnt9D tpPnt9D5 = camYZ.CamPoints[num13].Points[0];
					Point3D a3 = new Point3D(tpPnt9D5.P9.X, tpPnt9D5.P9.Y, tpPnt9D5.P9.Z);
					Point3D b3 = new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z);
					double num14 = Point3D.Distance(a3, b3);
					if (num14 > 0.0)
					{
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
						{
							num6 += Math.Round(num14 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
						}
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
						{
							num6 += Math.Round(num14 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
						}
					}
				}
				if (camYZ.CamPoints[num13].Points.Count <= 0)
				{
					continue;
				}
				for (int num15 = 1; num15 <= camYZ.CamPoints[num13].Points.Count - 1; num15++)
				{
					TpPnt9D tpPnt9D6 = camYZ.CamPoints[num13].Points[num15 - 1];
					TpPnt9D tpPnt9D7 = camYZ.CamPoints[num13].Points[num15];
					Point3D a4 = new Point3D(tpPnt9D6.P9.X, tpPnt9D6.P9.Y, tpPnt9D6.P9.Z);
					Point3D b4 = new Point3D(tpPnt9D7.P9.X, tpPnt9D7.P9.Y, tpPnt9D7.P9.Z);
					double num16 = Point3D.Distance(a4, b4);
					if (!(num16 > 0.0))
					{
						if (!(Math.Abs(tpPnt9D6.P9.C - tpPnt9D7.P9.C) > 0.0))
						{
							continue;
						}
						if (tpPnt9D7.Type != 1)
						{
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
							{
								num6 += Math.Round(Math.Abs(tpPnt9D6.P9.C - tpPnt9D7.P9.C) / buFoamCalc.varFoamSettings.MachineG0TangentSpeed, 3);
							}
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
							{
								num6 += Math.Round(Math.Abs(tpPnt9D6.P9.C - tpPnt9D7.P9.C) / (buFoamCalc.varFoamSettings.MachineG0TangentSpeed * 60.0), 3);
							}
						}
						else
						{
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
							{
								num6 += Math.Round(Math.Abs(tpPnt9D6.P9.C - tpPnt9D7.P9.C) / tpPnt9D7.Feed, 3);
							}
							if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
							{
								num6 += Math.Round(Math.Abs(tpPnt9D6.P9.C - tpPnt9D7.P9.C) / (tpPnt9D7.Feed * 60.0), 3);
							}
						}
					}
					else if (!((tpPnt9D7.Feed > 0.0) & ((tpPnt9D7.Type == 1) | (tpPnt9D7.Type == 2) | (tpPnt9D7.Type == 3))))
					{
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
						{
							num6 += Math.Round(num16 / buFoamCalc.varFoamSettings.MachineG0Speed, 3);
						}
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
						{
							num6 += Math.Round(num16 / buFoamCalc.varFoamSettings.MachineG0Speed * 60.0, 3);
						}
					}
					else
					{
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
						{
							num6 += Math.Round(num16 / tpPnt9D7.Feed, 3);
						}
						if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
						{
							num6 += Math.Round(num16 / tpPnt9D7.Feed * 60.0, 3);
						}
					}
				}
				tpPnt9D = new TpPnt9D(camYZ.CamPoints[num13].Points[camYZ.CamPoints[num13].Points.Count - 1]);
			}
			text = text + "----- " + buLangTranslate.preDef.Foam + " " + buLangTranslate.preDef.Information + " -----" + Environment.NewLine;
			text = text + "[ " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane + " ]" + Environment.NewLine;
			text = text + buLangTranslate.preDef.Execution + buLangTranslate.preDef.Time + " = " + num2.ToString("f1") + " " + buLangTranslate.preDef.Second + Environment.NewLine;
			text = text + buLangTranslate.preDef.Efficiency + "%" + (num3 / num4).ToString("f1") + Environment.NewLine;
			text = text + buLangTranslate.preDef.Total + buLangTranslate.preDef.Length + " = " + num.ToString("f1") + " " + buFoamCalc.varFoamSettings.UnitLength.ToString() + Environment.NewLine;
			text += Environment.NewLine;
			text = text + "[ " + buLangTranslate.preDef.Side + " " + buLangTranslate.preDef.Plane + " ]" + Environment.NewLine;
			text = text + buLangTranslate.preDef.Execution + buLangTranslate.preDef.Time + " = " + num6.ToString("f1") + " " + buLangTranslate.preDef.Second + Environment.NewLine;
			text = text + buLangTranslate.preDef.Efficiency + "%" + (num7 / num8).ToString("f1") + Environment.NewLine;
			return text + buLangTranslate.preDef.Total + buLangTranslate.preDef.Length + " = " + num5.ToString("f1") + " " + buFoamCalc.varFoamSettings.UnitLength.ToString() + Environment.NewLine;
		}
		return buLangTranslate.preDef.Foam + " " + buLangTranslate.preDef.NotReady;
	}

	public void doCheckLimits()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		activeFoam.isError = false;
		if (activeFoam.sortedEntitiesXZ.Count > 0)
		{
			clsInit.cVector5.BoxSizeCalculate(activeFoam.sortedEntitiesXZ, ref MinPoint, ref MaxPoint);
			if (buFoamCalc.varFoamSettings.CheckMachineSize)
			{
				if (MinPoint.Z < buFoamCalc.varFoamSettings.MachineLimitMinZ)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[23] + " [Z] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.Z > buFoamCalc.varFoamSettings.MachineLimitZ)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[24] + " [Z] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MinPoint.Y < buFoamCalc.varFoamSettings.MachineLimitMinY)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[23] + " [Y] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.Y > buFoamCalc.varFoamSettings.MachineLimitY)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[24] + " [Y] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MinPoint.X < buFoamCalc.varFoamSettings.MachineLimitMinX)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[23] + " [X] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.X > buFoamCalc.varFoamSettings.MachineLimitX)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[24] + " [X] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
			}
			if (buFoamCalc.varFoamSettings.CheckFoamSize)
			{
				if (MaxPoint.Z > activeFoam.Material.Size.Depth)
				{
					list2.Add(buLangTranslate.preDef.Warning + " " + buLangTranslate.preDef.Foam + " | " + buFoamCalc.LangFoamMessage[24] + " [Z] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.Y > activeFoam.Material.Size.Height)
				{
					list2.Add(buLangTranslate.preDef.Warning + " " + buLangTranslate.preDef.Foam + " | " + buFoamCalc.LangFoamMessage[24] + " [Y] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.X > activeFoam.Material.Size.Width)
				{
					list2.Add(buLangTranslate.preDef.Warning + " " + buLangTranslate.preDef.Foam + " | " + buFoamCalc.LangFoamMessage[24] + " [X] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
			}
		}
		MinPoint = new Point3D();
		MaxPoint = new Point3D();
		if (activeFoam.sortedEntitiesYZ.Count > 0)
		{
			clsInit.cVector5.BoxSizeCalculate(activeFoam.sortedEntitiesYZ, ref MinPoint, ref MaxPoint);
			if (buFoamCalc.varFoamSettings.CheckMachineSize)
			{
				if (MinPoint.Z < buFoamCalc.varFoamSettings.MachineLimitMinZ)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[23] + " [Z] - " + buLangTranslate.preDef.Side + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.Z > buFoamCalc.varFoamSettings.MachineLimitZ)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[24] + " [Z] - " + buLangTranslate.preDef.Side + " " + buLangTranslate.preDef.Plane);
				}
				if (MinPoint.Y < buFoamCalc.varFoamSettings.MachineLimitMinY)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[23] + " [Y] - " + buLangTranslate.preDef.Side + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.Y > buFoamCalc.varFoamSettings.MachineLimitY)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[24] + " [Y] - " + buLangTranslate.preDef.Side + " " + buLangTranslate.preDef.Plane);
				}
				if (MinPoint.X < buFoamCalc.varFoamSettings.MachineLimitMinX)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[23] + " [X] - " + buLangTranslate.preDef.Side + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.X > buFoamCalc.varFoamSettings.MachineLimitX)
				{
					list.Add(buLangTranslate.preDef.Error + " " + buLangTranslate.preDef.Machine + " | " + buFoamCalc.LangFoamMessage[24] + " [X] - " + buLangTranslate.preDef.Side + " " + buLangTranslate.preDef.Plane);
				}
			}
			if (buFoamCalc.varFoamSettings.CheckFoamSize)
			{
				if (MaxPoint.Z > activeFoam.Material.Size.Depth)
				{
					list2.Add(buLangTranslate.preDef.Warning + " " + buLangTranslate.preDef.Foam + " | " + buFoamCalc.LangFoamMessage[24] + " [Z] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.Y > activeFoam.Material.Size.Height)
				{
					list2.Add(buLangTranslate.preDef.Warning + " " + buLangTranslate.preDef.Foam + " | " + buFoamCalc.LangFoamMessage[24] + " [Y] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
				if (MaxPoint.X > activeFoam.Material.Size.Width)
				{
					list2.Add(buLangTranslate.preDef.Warning + " " + buLangTranslate.preDef.Foam + " | " + buFoamCalc.LangFoamMessage[24] + " [X] - " + buLangTranslate.preDef.Main + " " + buLangTranslate.preDef.Plane);
				}
			}
		}
		if (list.Count > 0)
		{
			activeFoam.isError = true;
		}
		if ((list.Count > 0) | (list2.Count > 0))
		{
			DialogBoxList dialogBoxList = new DialogBoxList();
			dialogBoxList.Caption = buLangTranslate.preDef.Error;
			dialogBoxList.Width = 500;
			for (int i = 0; i <= list.Count - 1; i++)
			{
				dialogBoxList.Items.Add(list[i]);
			}
			for (int j = 0; j <= list2.Count - 1; j++)
			{
				dialogBoxList.Items.Add(list2[j]);
			}
			dialogBoxList.Init();
			dialogBoxList.ShowDialog();
		}
	}

	public void doDeleteBlocks(int indexBlock)
	{
		if (foamActiveBlock_0.Plane == FoamPlaneType.XZ && ((indexBlock >= 0) & (indexBlock <= activeFoam.BlockXZ.Count - 1)))
		{
			activeFoam.BlockXZ.RemoveAt(indexBlock);
			activeFoam.sortedEntitiesXZ.Clear();
			activeFoam.sortedEntitiesYZ.Clear();
			activeFoam.CamXZ = new camTp();
			activeFoam.CamYZ = new camTp();
			activeFoam.isGCodeCreated = false;
		}
		if (foamActiveBlock_0.Plane == FoamPlaneType.YZ && ((indexBlock >= 0) & (indexBlock <= activeFoam.BlockYZ.Count - 1)))
		{
			activeFoam.BlockYZ.RemoveAt(indexBlock);
			activeFoam.sortedEntitiesXZ.Clear();
			activeFoam.sortedEntitiesYZ.Clear();
			activeFoam.CamXZ = new camTp();
			activeFoam.CamYZ = new camTp();
			activeFoam.isGCodeCreated = false;
		}
		JobUpdate(FillPages: true, "", null, -1);
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
	}

	public void doDeleteAllBlocks()
	{
		activeFoam.BlockXZ.Clear();
		activeFoam.BlockYZ.Clear();
		activeFoam.sortedEntitiesXZ.Clear();
		activeFoam.sortedEntitiesYZ.Clear();
		activeFoam.CamXZ = new camTp();
		activeFoam.CamYZ = new camTp();
		activeFoam.isGCodeCreated = false;
		JobUpdate(FillPages: true, "", null, -1);
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
	}

	public void doEditBlocks()
	{
		new FoamRuntimeSettings(buFoamCalc.varFoamRunSettings);
		for (int i = 0; i <= activeFoam.BlockXZ.Count - 1; i++)
		{
			if (activeFoam.BlockXZ[i].isWaveOperation)
			{
				activeBlock = new FoamBlock(activeFoam.BlockXZ[i]);
				List<FoamPattern> FoamPatterns = new List<FoamPattern>();
				activeFoam.BlockXZ[i].Settings.BlockWidth = activeFoam.Material.Size.Width;
				doCalculateWaveShape(activeFoam.BlockXZ[i].Settings, Finished: true, activeFoam.BlockXZ[i].BlockFoamType, ref FoamPatterns, Edit: true);
				if (FoamPatterns.Count > 0)
				{
					activeFoam.BlockXZ[i].Pattern = FoamPatterns;
				}
			}
			if (activeFoam.BlockXZ[i].BlockFoamType == FoamType.Pattern)
			{
				activeBlock = new FoamBlock(activeFoam.BlockXZ[i]);
				if (activeFoam.BlockXZ[i].basePattern != null)
				{
					activePattern = new FoamPattern(activeFoam.BlockXZ[i].basePattern);
				}
				List<FoamPattern> FoamPatterns2 = new List<FoamPattern>();
				activeFoam.BlockXZ[i].Settings.BlockWidth = activeFoam.Material.Size.Width;
				doCalculatePattern(activeFoam.BlockXZ[i].Settings, Finished: true, ref FoamPatterns2, Edit: true);
				if (FoamPatterns2.Count > 0)
				{
					activeFoam.BlockXZ[i].Pattern = FoamPatterns2;
				}
			}
		}
		for (int j = 0; j <= activeFoam.BlockYZ.Count - 1; j++)
		{
			if (activeFoam.BlockYZ[j].isWaveOperation)
			{
				activeBlock = new FoamBlock(activeFoam.BlockYZ[j]);
				List<FoamPattern> FoamPatterns3 = new List<FoamPattern>();
				activeFoam.BlockYZ[j].Settings.BlockWidth = activeFoam.Material.Size.Height;
				doCalculateWaveShape(activeFoam.BlockYZ[j].Settings, Finished: true, activeFoam.BlockYZ[j].BlockFoamType, ref FoamPatterns3, Edit: true);
				if (FoamPatterns3.Count > 0)
				{
					activeFoam.BlockYZ[j].Pattern = FoamPatterns3;
				}
			}
			if (activeFoam.BlockYZ[j].BlockFoamType == FoamType.Pattern)
			{
				activeBlock = new FoamBlock(activeFoam.BlockYZ[j]);
				if (activeFoam.BlockYZ[j].basePattern != null)
				{
					activePattern = new FoamPattern(activeFoam.BlockYZ[j].basePattern);
				}
				List<FoamPattern> FoamPatterns4 = new List<FoamPattern>();
				activeFoam.BlockYZ[j].Settings.BlockWidth = activeFoam.Material.Size.Height;
				doCalculatePattern(activeFoam.BlockYZ[j].Settings, Finished: true, ref FoamPatterns4, Edit: true);
				if (FoamPatterns4.Count > 0)
				{
					activeFoam.BlockYZ[j].Pattern = FoamPatterns4;
				}
			}
		}
		activeFoam.sortedEntitiesXZ.Clear();
		activeFoam.sortedEntitiesYZ.Clear();
		JobUpdate(FillPages: true, "", null, -1);
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
		activeFoam.isGCodeCreated = false;
		clsInit.appCommand.Reset();
	}

	public void doOperationSizeCalcHor(ref FoamRuntimeSettings RunSettings, bool Edit = false)
	{
		if (activeBlock == null)
		{
			activeBlock = new FoamBlock();
		}
		List<FoamBlock> list = null;
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			if (activeFoam.BlockXZ == null)
			{
				activeFoam.BlockXZ = new List<FoamBlock>();
			}
			list = activeFoam.BlockXZ;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			if (activeFoam.BlockYZ == null)
			{
				activeFoam.BlockYZ = new List<FoamBlock>();
			}
			list = activeFoam.BlockYZ;
		}
		varCalc.BlockTrimedWidth = RunSettings.BlockWidth - RunSettings.PatternWidthStartOffset - RunSettings.PatternWidthEndOffset;
		varCalc.BlockTrimedHeight = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset - RunSettings.PatternHeightEndOffset;
		if (buFoamCalc.varFoamRunSettings.WaveFormRepeatCount <= 0)
		{
			buFoamCalc.varFoamRunSettings.WaveFormRepeatCount = 1;
		}
		if (varCalc.PatternWidth != 0.0)
		{
			varCalc.XRatio = Math.Round(varCalc.BlockTrimedWidth / varCalc.PatternWidth, 5);
			if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
			{
				varCalc.XRatio = Math.Round(varCalc.BlockTrimedWidth / (varCalc.PatternWidth * (double)buFoamCalc.varFoamRunSettings.WaveFormRepeatCount), 5);
			}
		}
		varCalc.YRatio = Math.Round(varCalc.BlockTrimedHeight / varCalc.PatternHeight, 5);
		if (RunSettings.TypeFoam == FoamType.FromDrawing)
		{
			if (varCalc.PatternWidth != 0.0)
			{
				varCalc.XRatio = Math.Round(varCalc.BlockTrimedWidth / varCalc.PatternWidth, 5);
			}
			varCalc.YRatio = Math.Round(varCalc.BlockTrimedHeight / varCalc.PatternHeight, 5);
		}
		if (varCalc.XRatio < 1.0)
		{
			varCalc.XRatio = 1.0;
		}
		if (varCalc.YRatio < 1.0)
		{
			varCalc.YRatio = 1.0;
		}
		varCalc.XCountActual = (int)buNumeric5.RoundToLower(varCalc.XRatio);
		varCalc.YCountActual = (int)buNumeric5.RoundToLower(varCalc.YRatio);
		if (varCalc.PatternWidth != 0.0)
		{
			varCalc.XMax = (int)buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitX / varCalc.PatternWidth);
		}
		varCalc.YMax = (int)buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitZ / varCalc.PatternHeight);
		if (activePattern.planeName == FoamPlaneType.YZ && varCalc.PatternWidth != 0.0)
		{
			int_3 = (int)buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitY / varCalc.PatternWidth);
		}
		varCalc.BlockIdealWidth = Math.Round(varCalc.PatternWidth * (double)varCalc.XCountActual - buFoamCalc.varFoamSettings.PatternDistancesWidth, 3);
		varCalc.BlockIdealHeight = Math.Round(varCalc.PatternHeight * (double)varCalc.YCountActual - buFoamCalc.varFoamSettings.PatternDistancesHeight, 3);
		if (buFoamCalc.varFoamRunSettings.Operation == FoamOperationType.Wave)
		{
			varCalc.BlockIdealWidth = Math.Round(varCalc.PatternWidth * (double)varCalc.XCountActual * (double)buFoamCalc.varFoamRunSettings.WaveFormRepeatCount - buFoamCalc.varFoamSettings.PatternDistancesWidth, 3);
			varCalc.BlockIdealHeight = Math.Round(varCalc.PatternHeight * (double)varCalc.YCountActual - buFoamCalc.varFoamRunSettings.WaveFormSpace, 3);
		}
		if (!Edit)
		{
			if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown)
			{
				if (list.Count <= 0)
				{
					activeBlock.BottomZ = RunSettings.PatternHeightEndOffset;
				}
				else
				{
					activeBlock.BottomZ = list[list.Count - 1].TopZ + RunSettings.PatternHeightStartOffset;
				}
			}
			else if (list.Count <= 0)
			{
				activeBlock.BottomZ = activeFoam.Material.Size.Depth - RunSettings.PatternHeightStartOffset;
			}
			else
			{
				activeBlock.BottomZ = list[list.Count - 1].BottomZ - RunSettings.PatternHeightStartOffset;
			}
		}
		if (!Edit)
		{
			AppBool.Calculation = true;
			if ((frmPattern != null) & (RunSettings.Operation == FoamOperationType.Pattern))
			{
				frmPattern.spn_blockhorcount.Value = varCalc.XCountActual;
				frmPattern.spn_blockvercount.Value = varCalc.YCountActual;
				frmPattern.spn_totalpart.Value = varCalc.XCountActual * varCalc.YCountActual;
			}
			if ((frmWave != null) & (RunSettings.Operation == FoamOperationType.Wave))
			{
				frmWave.spn_blockhorcount.Value = varCalc.XCountActual;
				frmWave.spn_blockvercount.Value = varCalc.YCountActual;
				frmWave.spn_totalpart.Value = varCalc.XCountActual * varCalc.YCountActual;
			}
			if ((frmSlice != null) & (RunSettings.Operation == FoamOperationType.Slice))
			{
				frmSlice.spn_blockhorcount.Value = varCalc.XCountActual;
				frmSlice.spn_blockvercount.Value = varCalc.YCountActual;
				frmSlice.spn_totalpart.Value = varCalc.XCountActual * varCalc.YCountActual;
			}
			AppBool.Calculation = false;
		}
		varCalc.ZOffset += activeBlock.BottomZ;
	}

	public void doOperationSizeCalcVer(ref FoamRuntimeSettings RunSettings, bool Edit = false)
	{
		if (activeBlock == null)
		{
			activeBlock = new FoamBlock();
		}
		List<FoamBlock> list = null;
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			if (activeFoam.BlockXZ == null)
			{
				activeFoam.BlockXZ = new List<FoamBlock>();
			}
			list = activeFoam.BlockXZ;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			if (activeFoam.BlockYZ == null)
			{
				activeFoam.BlockYZ = new List<FoamBlock>();
			}
			list = activeFoam.BlockYZ;
		}
		if (!Edit)
		{
			if (list.Count <= 0)
			{
				activeBlock.LeftMin = RunSettings.PatternWidthStartOffset;
			}
			else
			{
				activeBlock.LeftMin = list[list.Count - 1].LeftMax + buFoamCalc.varFoamSettings.BlockSpace;
			}
		}
		varCalc.BlockTrimedWidth = RunSettings.BlockWidth - RunSettings.PatternWidthStartOffset - RunSettings.PatternWidthEndOffset;
		varCalc.BlockTrimedHeight = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset - RunSettings.PatternHeightEndOffset;
		if (varCalc.PatternWidth != 0.0)
		{
			varCalc.XRatio = Math.Round(varCalc.BlockTrimedWidth / varCalc.PatternWidth, 5);
		}
		if (varCalc.PatternHeight != 0.0)
		{
			varCalc.YRatio = Math.Round(varCalc.BlockTrimedHeight / varCalc.PatternHeight, 5);
		}
		if (RunSettings.TypeFoam == FoamType.FromDrawing)
		{
			if (varCalc.PatternWidth != 0.0)
			{
				varCalc.XRatio = Math.Round(varCalc.BlockTrimedWidth / varCalc.PatternWidth, 5);
			}
			if (varCalc.PatternHeight != 0.0)
			{
				varCalc.YRatio = Math.Round(varCalc.BlockTrimedHeight / varCalc.PatternHeight, 5);
			}
		}
		if (varCalc.XRatio < 1.0)
		{
			varCalc.XRatio = 1.0;
		}
		if (varCalc.YRatio < 1.0)
		{
			varCalc.YRatio = 1.0;
		}
		varCalc.XCountActual = (int)buNumeric5.RoundToLower(varCalc.XRatio);
		varCalc.YCountActual = (int)buNumeric5.RoundToLower(varCalc.YRatio);
		if (varCalc.PatternWidth != 0.0)
		{
			varCalc.XMax = (int)buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitX / varCalc.PatternWidth);
		}
		if (varCalc.PatternHeight != 0.0)
		{
			varCalc.YMax = (int)buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitZ / varCalc.PatternHeight);
		}
		if (activePattern.planeName == FoamPlaneType.YZ && varCalc.PatternWidth != 0.0)
		{
			varCalc.XMax = (int)buNumeric5.RoundToLower(buFoamCalc.varFoamSettings.MachineLimitY / varCalc.PatternWidth);
		}
		varCalc.BlockIdealWidth = Math.Round(varCalc.PatternWidth * (double)varCalc.XCountActual - buFoamCalc.varFoamSettings.PatternDistancesWidth, 3);
		varCalc.BlockIdealHeight = Math.Round(varCalc.PatternHeight * (double)varCalc.YCountActual - buFoamCalc.varFoamSettings.PatternDistancesHeight, 3);
		if (Edit)
		{
		}
		if (!Edit)
		{
			if ((frmPattern != null) & (RunSettings.Operation == FoamOperationType.Pattern))
			{
				frmPattern.spn_blockhorcount.Value = varCalc.XCountActual;
				frmPattern.spn_blockvercount.Value = varCalc.YCountActual;
				frmPattern.spn_totalpart.Value = varCalc.XCountActual * varCalc.YCountActual;
			}
			if ((frmWave != null) & (RunSettings.Operation == FoamOperationType.Wave))
			{
				frmWave.spn_blockhorcount.Value = varCalc.XCountActual;
				frmWave.spn_blockvercount.Value = varCalc.YCountActual;
				frmWave.spn_totalpart.Value = varCalc.XCountActual * varCalc.YCountActual;
			}
			if ((frmSlice != null) & (RunSettings.Operation == FoamOperationType.Slice))
			{
				frmSlice.spn_blockhorcount.Value = varCalc.XCountActual;
				frmSlice.spn_blockvercount.Value = varCalc.YCountActual;
				frmSlice.spn_totalpart.Value = varCalc.XCountActual * varCalc.YCountActual;
			}
		}
		varCalc.XOffset += activeBlock.LeftMin;
	}

	public void doCalculatePattern(FoamRuntimeSettings RunSettings, bool Finished, ref List<FoamPattern> FoamPatterns, bool Edit = false)
	{
		varCalc.PatternWidth = RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth;
		varCalc.PatternHeight = RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
		varCalc.ZOffset = 0.0;
		doOperationSizeCalcHor(ref RunSettings, Edit);
		FoamPatterns = new List<FoamPattern>();
		frmPattern.lst_idealwidth.Items.Clear();
		frmPattern.lst_idealheight.Items.Clear();
		for (double num = 1.0; num <= varCalc.XMax; num += 1.0)
		{
			double num2 = Math.Round(RunSettings.PatternWidth * num + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + Convert.ToDouble(num - 0.0) * buFoamCalc.varFoamSettings.PatternDistancesWidth, 3);
			frmPattern.lst_idealwidth.Items.Add(num2);
		}
		for (double num3 = 1.0; num3 <= varCalc.YMax; num3 += 1.0)
		{
			double num4 = Math.Round(RunSettings.PatternHeight * num3 + RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + Convert.ToDouble(num3 - 0.0) * buFoamCalc.varFoamSettings.PatternDistancesHeight, 3);
			frmPattern.lst_idealheight.Items.Add(num4);
		}
		frmPattern.lst_idealwidth.Text = varCalc.BlockIdealWidth.ToString();
		frmPattern.lst_idealheight.Text = varCalc.BlockIdealHeight.ToString();
		ccVars.pntDrawDynamicLinesArr.Clear();
		ccVars.pntDrawDynamicLinesArrColored.Clear();
		if (activePattern == null)
		{
			return;
		}
		List<Point3D> list = new List<Point3D>();
		List<buEntity> refEntities = new List<buEntity>();
		List<buEntity> copiedEntities = new List<buEntity>();
		clsInit.cFoamCut.FoamEntitiesToEntities(activePattern.foamEntities, ref refEntities);
		if ((activePattern.planeName == FoamPlaneType.XZ) | (activePattern.planeName == FoamPlaneType.YZ))
		{
			if (activePattern.planeName == FoamPlaneType.XZ)
			{
				clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref refEntities);
				if (Finished)
				{
					buEntity.Copy(activePattern.sortEntities, ref copiedEntities);
					clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref copiedEntities);
					clsInit.cFoamCut.FoamEntitiesRotate(90.0, Vector3D.AxisX, ref activePattern.foamEntities);
				}
			}
			if (activePattern.planeName == FoamPlaneType.YZ)
			{
				clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref refEntities);
				clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisZ, ref refEntities);
				if (Finished)
				{
					buEntity.Copy(activePattern.sortEntities, ref copiedEntities);
					clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisX, ref copiedEntities);
					clsInit.cVector5.Rotate(new Point3D(), 90.0, Vector3D.AxisZ, ref copiedEntities);
					clsInit.cFoamCut.FoamEntitiesRotate(90.0, Vector3D.AxisX, ref activePattern.foamEntities);
					clsInit.cFoamCut.FoamEntitiesRotate(90.0, Vector3D.AxisZ, ref activePattern.foamEntities);
				}
			}
			activeBlock.BlockName = RunSettings.BlockName;
			activeBlock.MinPoint = new Point3D(0.0, 0.0, activeBlock.BottomZ);
			activeBlock.SizeObj = new SizeObject(activeBlock.MaxPoint.X - activeBlock.MinPoint.X, activeBlock.MaxPoint.Y - activeBlock.MinPoint.Y, activeBlock.MaxPoint.Z - activeBlock.MinPoint.Z);
			List<PointRGB> list2 = new List<PointRGB>();
			double num5 = 0.0;
			double num6 = 0.0;
			if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown)
			{
				num5 = varCalc.ZOffset + varCalc.BlockIdealHeight + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
				num6 = varCalc.ZOffset - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
				activeBlock.TopZ = varCalc.ZOffset + varCalc.BlockIdealHeight;
				activeBlock.BottomZ = varCalc.ZOffset;
			}
			else
			{
				num5 = varCalc.ZOffset + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
				num6 = varCalc.ZOffset - varCalc.BlockIdealHeight - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
				activeBlock.TopZ = varCalc.ZOffset;
				activeBlock.BottomZ = varCalc.ZOffset - varCalc.BlockIdealHeight;
			}
			if (activePattern.planeName == FoamPlaneType.XZ)
			{
				activeBlock.MaxPoint = new Point3D(varCalc.BlockIdealWidth, activeFoam.Material.Size.Height, activeBlock.BottomZ + varCalc.BlockIdealHeight);
				list2.Add(new PointRGB(0.0, 0.0, num5, Color.Lime));
				list2.Add(new PointRGB(varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, num5, Color.Lime));
				list2.Add(new PointRGB(varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, num6, Color.Lime));
				list2.Add(new PointRGB(0.0, 0.0, num6, Color.Lime));
				list2.Add(new PointRGB(0.0, 0.0, num5, Color.Lime));
			}
			if (activePattern.planeName == FoamPlaneType.YZ)
			{
				activeBlock.MaxPoint = new Point3D(activeFoam.Material.Size.Width, varCalc.BlockIdealWidth, activeBlock.BottomZ + varCalc.BlockIdealHeight);
				list2.Add(new PointRGB(0.0, 0.0, num5, Color.Lime));
				list2.Add(new PointRGB(0.0, varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, num5, Color.Lime));
				list2.Add(new PointRGB(0.0, varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, num6, Color.Lime));
				list2.Add(new PointRGB(0.0, 0.0, num6, Color.Lime));
				list2.Add(new PointRGB(0.0, 0.0, num5, Color.Lime));
			}
			ccVars.pntDrawDynamicLinesArrColored.Add(list2);
			if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown)
			{
				for (double num7 = 0.0; num7 <= (double)(varCalc.YCountActual - 1); num7 += 1.0)
				{
					double num8 = 0.0;
					if (num7 > 0.0)
					{
						num8 = RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
					}
					varCalc.ZOffset += num8;
					for (double num9 = 0.0; num9 <= (double)(varCalc.XCountActual - 1); num9 += 1.0)
					{
						List<buEntity> copiedEntities2 = new List<buEntity>();
						buEntity.Copy(refEntities, ref copiedEntities2);
						if (num7 % 2.0 == 1.0 && (RunSettings.PatternMirrorX | RunSettings.PatternMirrorY))
						{
							clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, activePattern.planeName, ref copiedEntities2);
						}
						double num10 = 0.0;
						double dY = 0.0;
						if (activePattern.planeName == FoamPlaneType.XZ)
						{
							num10 = RunSettings.PatternWidthStartOffset + num9 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
						}
						if (activePattern.planeName == FoamPlaneType.YZ)
						{
							dY = RunSettings.PatternWidthStartOffset + num9 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
						}
						double num11 = 0.0;
						if (RunSettings.PatternMirrorY)
						{
							if (num7 % 2.0 != 1.0)
							{
								num11 = num7 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
							}
							else
							{
								num11 = num7 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
							}
						}
						else
						{
							num11 = num7 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
						}
						num11 = 0.0;
						if (Finished)
						{
							FoamPattern Pattern = new FoamPattern();
							FoamEntities.Copy(activePattern.foamEntities, ref Pattern.foamEntities);
							buEntity.Copy(copiedEntities, ref Pattern.sortEntities);
							if (num7 % 2.0 == 1.0 && (RunSettings.PatternMirrorX | RunSettings.PatternMirrorY))
							{
								clsInit.cFoamCut.FoamEntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, activePattern.planeName, ref Pattern.foamEntities);
								clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, activePattern.planeName, ref Pattern.sortEntities);
								if (RunSettings.PatternMirrorX)
								{
									clsInit.cVector5.ChangeEntitiesDirection(ref Pattern.sortEntities);
								}
							}
							clsInit.cVector5.Move(num10, 0.0, num11 + varCalc.ZOffset, ref Pattern.sortEntities);
							clsInit.cFoamCut.FoamEntitiesMove(num10, 0.0, num11 + varCalc.ZOffset, ref Pattern.foamEntities);
							clsInit.cFoamCut.FoamEntitiesBoxSize(Pattern.foamEntities, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
							Pattern.Type = FoamType.Pattern;
							Pattern.GroupType = FoamOperationType.Pattern;
							Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
							Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
							Pattern.Offset = new Point3D(num10, 0.0, num11 + varCalc.ZOffset);
							Pattern.HorizontalIndex = Convert.ToInt32(num9);
							Pattern.VerticalIndex = Convert.ToInt32(num7);
							if (buFoamCalc.varFoamSettings.Draw3D)
							{
								clsInit.cFoamCut.CreateSolidOperation(ref Pattern, activeFoam.Material.Size, activePattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
							}
							FoamPatterns.Add(Pattern);
						}
						else
						{
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								clsInit.cVector5.Move(num10, 0.0, num11 + varCalc.ZOffset, ref copiedEntities2);
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								clsInit.cVector5.Move(0.0, dY, num11 + varCalc.ZOffset, ref copiedEntities2);
							}
							for (int i = 0; i <= copiedEntities2.Count - 1; i++)
							{
								list = new List<Point3D>();
								buVector5.Copy(copiedEntities2[i].Vertices, ref list);
								ccVars.pntDrawDynamicLinesArr.Add(list);
							}
						}
					}
				}
			}
			else
			{
				for (double num12 = varCalc.YCountActual - 1; num12 >= 0.0; num12 -= 1.0)
				{
					double num13 = 0.0;
					if (num12 == (double)(varCalc.YCountActual - 1))
					{
						num13 = buFoamCalc.varFoamSettings.PatternDistancesHeight;
					}
					varCalc.ZOffset -= RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight - num13;
					for (double num14 = 0.0; num14 <= (double)(varCalc.XCountActual - 1); num14 += 1.0)
					{
						List<buEntity> copiedEntities3 = new List<buEntity>();
						buEntity.Copy(refEntities, ref copiedEntities3);
						if (num12 % 2.0 == 1.0 && (RunSettings.PatternMirrorX | RunSettings.PatternMirrorY))
						{
							clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, activePattern.planeName, ref copiedEntities3);
						}
						double num15 = 0.0;
						double dY2 = 0.0;
						if (activePattern.planeName == FoamPlaneType.XZ)
						{
							num15 = RunSettings.PatternWidthStartOffset + num14 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
						}
						if (activePattern.planeName == FoamPlaneType.YZ)
						{
							dY2 = RunSettings.PatternWidthStartOffset + num14 * (RunSettings.PatternWidth + buFoamCalc.varFoamSettings.PatternDistancesWidth);
						}
						double num16 = 0.0;
						if (RunSettings.PatternMirrorY)
						{
							if (num12 % 2.0 != 1.0)
							{
								num16 = num12 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
							}
							else
							{
								num16 = num12 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
							}
						}
						else
						{
							num16 = num12 * (RunSettings.PatternHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight);
						}
						num16 = 0.0;
						if (Finished)
						{
							FoamPattern Pattern2 = new FoamPattern();
							FoamEntities.Copy(activePattern.foamEntities, ref Pattern2.foamEntities);
							buEntity.Copy(copiedEntities, ref Pattern2.sortEntities);
							if (num12 % 2.0 == 1.0 && (RunSettings.PatternMirrorX | RunSettings.PatternMirrorY))
							{
								clsInit.cFoamCut.FoamEntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, activePattern.planeName, ref Pattern2.foamEntities);
								clsInit.cFoamCut.EntitiesMirror(RunSettings.PatternMirrorX, RunSettings.PatternMirrorY, activePattern.planeName, ref Pattern2.sortEntities);
								if (RunSettings.PatternMirrorX)
								{
									clsInit.cVector5.ChangeEntitiesDirection(ref Pattern2.sortEntities);
								}
							}
							clsInit.cVector5.Move(num15, 0.0, num16 + varCalc.ZOffset, ref Pattern2.sortEntities);
							clsInit.cFoamCut.FoamEntitiesMove(num15, 0.0, num16 + varCalc.ZOffset, ref Pattern2.foamEntities);
							clsInit.cFoamCut.FoamEntitiesBoxSize(Pattern2.foamEntities, ref Pattern2.BoxMinItem, ref Pattern2.BoxMaxItem);
							Pattern2.Type = FoamType.Pattern;
							Pattern2.GroupType = FoamOperationType.Pattern;
							Pattern2.Width = Math.Round(Pattern2.BoxMaxItem.X - Pattern2.BoxMinItem.X, 3);
							Pattern2.Height = Math.Round(Pattern2.BoxMaxItem.Z - Pattern2.BoxMinItem.Z, 3);
							Pattern2.Offset = new Point3D(num15, 0.0, num16 + varCalc.ZOffset);
							Pattern2.HorizontalIndex = Convert.ToInt32(num14);
							Pattern2.VerticalIndex = Convert.ToInt32(num12);
							if (buFoamCalc.varFoamSettings.Draw3D)
							{
								clsInit.cFoamCut.CreateSolidOperation(ref Pattern2, activeFoam.Material.Size, activePattern.planeName, Pattern2.Color, buFoamCalc.varFoamSettings.UseMultiColor);
							}
							FoamPatterns.Add(Pattern2);
						}
						else
						{
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								clsInit.cVector5.Move(num15, 0.0, num16 + varCalc.ZOffset, ref copiedEntities3);
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								clsInit.cVector5.Move(0.0, dY2, num16 + varCalc.ZOffset, ref copiedEntities3);
							}
							for (int j = 0; j <= copiedEntities3.Count - 1; j++)
							{
								list = new List<Point3D>();
								buVector5.Copy(copiedEntities3[j].Vertices, ref list);
								ccVars.pntDrawDynamicLinesArr.Add(list);
							}
						}
					}
				}
			}
		}
		activePattern.Info.TotalArea = 0.0;
		activePattern.Info.TotalCuttingLength = 0.0;
		clsInit.cVector5.BoxSizeCalculate(refEntities, ref activePattern.BoxMinItem, ref activePattern.BoxMaxItem);
		for (int k = 0; k <= activePattern.foamEntities.Count - 1; k++)
		{
			List<Point3D> Points = new List<Point3D>();
			clsInit.cVector5.EntitiesToPointsWithCamDirection(activePattern.foamEntities[k].GroupEntity.Outside.Entities, ref Points);
			activePattern.Info.TotalArea = activePattern.Info.TotalArea + clsInit.cVector5.PolygonArea(Points, Plane.XY);
			activePattern.Info.TotalCuttingLength = activePattern.Info.TotalCuttingLength + clsInit.cVector5.Length3D(Points);
		}
		if (activePattern.planeName == FoamPlaneType.XZ)
		{
			activePattern.Info.BoxArea = Math.Round((activePattern.BoxMaxItem.X - activePattern.BoxMinItem.X) * (activePattern.BoxMaxItem.Z - activePattern.BoxMinItem.Z), 3);
		}
		if (activePattern.planeName == FoamPlaneType.YZ)
		{
			activePattern.Info.BoxArea = Math.Round((activePattern.BoxMaxItem.Y - activePattern.BoxMinItem.Y) * (activePattern.BoxMaxItem.Z - activePattern.BoxMinItem.Z), 3);
		}
		if (activePattern.Info.BoxArea > 0.0)
		{
			activePattern.Info.UsedPersentageFromBoxArea = Math.Round(activePattern.Info.TotalArea / activePattern.Info.BoxArea * 100.0, 3);
		}
		if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerSec)
		{
			activePattern.Info.TimeCutting = Math.Round(activePattern.Info.TotalCuttingLength / buFoamCalc.varFoamSettings.CuttingFeed, 3);
		}
		if (buFoamCalc.varFoamSettings.UnitSpeed == SpeedUnit.mmPerMin)
		{
			activePattern.Info.TimeCutting = Math.Round(activePattern.Info.TotalCuttingLength / buFoamCalc.varFoamSettings.CuttingFeed * 60.0, 3);
		}
		string Info = "";
		clsInit.cFoamCut.PatternInfo(activePattern, activeFoam.Material.Size, varCalc.XCountActual, varCalc.YCountActual, buFoamCalc.varFoamSettings, RunSettings, ref Info);
		frmPattern.txt_info.Text = Info;
	}

	public void doCalculateWaveShape(FoamRuntimeSettings RunSettings, bool Finished, FoamType Type, ref List<FoamPattern> FoamPatterns, bool Edit = false)
	{
		FoamPatterns = new List<FoamPattern>();
		if (RunSettings.WaveFormShapeCommonBaseHeight <= RunSettings.WaveFormShapeCommonHeight)
		{
			RunSettings.WaveFormShapeCommonBaseHeight = RunSettings.WaveFormShapeCommonHeight * 2.0;
		}
		frmWave.lst_idealwidth.Items.Clear();
		frmWave.lst_idealheight.Items.Clear();
		double num = 2.0 * RunSettings.WaveFormShapeCommonBaseHeight;
		double zPos = RunSettings.WaveFormShapeCommonBaseHeight;
		if (Type == FoamType.VForm || Type == FoamType.CForm)
		{
			num = 2.0 * RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight + RunSettings.WaveFormSpace;
			zPos = RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight;
		}
		if (Type == FoamType.ZForm || Type == FoamType.SForm)
		{
			num = 2.0 * RunSettings.WaveFormShapeCommonBaseHeight + RunSettings.WaveFormSpace;
			zPos = (num - RunSettings.WaveFormSpace) / 2.0;
		}
		if (Type == FoamType.Pyramid)
		{
			num = RunSettings.WaveFormShapeCommonBaseHeight + (RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight) + RunSettings.WaveFormSpace;
			zPos = RunSettings.WaveFormShapeCommonBaseHeight;
		}
		if (Type == FoamType.Rectangle || Type == FoamType.UForm)
		{
			num = RunSettings.WaveFormShapeCommonBaseHeight + (RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight) + RunSettings.WaveFormSpace;
			zPos = RunSettings.WaveFormShapeCommonBaseHeight - RunSettings.WaveFormShapeCommonHeight;
		}
		varCalc.PatternWidth = RunSettings.WaveFormShapeCommonWidth;
		varCalc.PatternHeight = num;
		varCalc.ZOffset = 0.0;
		doOperationSizeCalcHor(ref RunSettings, Edit);
		int num2 = 1;
		if (RunSettings.WaveFormRepeatCount <= 0)
		{
			int_1 = varCalc.XCountActual - 1;
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double)(int_1 - 2)).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double)(int_1 - 1)).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double)int_1).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double)(int_1 + 1)).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + RunSettings.WaveFormShapeCommonWidth * (double)(int_1 + 2)).ToString("f1"));
		}
		else
		{
			double num3 = (double)RunSettings.WaveFormRepeatCount * RunSettings.WaveFormShapeCommonWidth;
			num2 = (int)buNumeric5.RoundToLower(varCalc.BlockTrimedWidth / num3);
			int_1 = RunSettings.WaveFormRepeatCount;
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double)(num2 - 2)).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double)(num2 - 1)).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double)num2).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double)(num2 + 1)).ToString("f1"));
			frmWave.lst_idealwidth.Items.Add((RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset + num3 * (double)(num2 + 2)).ToString("f1"));
		}
		frmWave.lst_idealheight.Items.Add((RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double)(varCalc.YCountActual - 2)).ToString("f1"));
		frmWave.lst_idealheight.Items.Add((RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double)(varCalc.YCountActual - 1)).ToString("f1"));
		frmWave.lst_idealheight.Items.Add((RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double)varCalc.YCountActual).ToString("f1"));
		frmWave.lst_idealheight.Items.Add((RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double)(varCalc.YCountActual + 1)).ToString("f1"));
		frmWave.lst_idealheight.Items.Add((RunSettings.PatternHeightStartOffset + RunSettings.PatternHeightEndOffset + RunSettings.WaveFormShapeCommonBaseHeight * 2.0 * (double)(varCalc.YCountActual + 2)).ToString("f1"));
		FoamPatterns = new List<FoamPattern>();
		frmWave.spn_blockhorcount.Value = num2;
		frmWave.spn_blockvercount.Value = varCalc.YCountActual;
		frmWave.spn_totalpart.Value = num2 * int_2;
		ccVars.pntDrawDynamicLinesArr.Clear();
		ccVars.pntDrawDynamicLinesArrColored.Clear();
		if (activePattern == null)
		{
			return;
		}
		new List<Point3D>();
		List<PointRGB> list = new List<PointRGB>();
		double num4 = 0.0;
		double num5 = 0.0;
		if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown)
		{
			num4 = varCalc.ZOffset + varCalc.BlockIdealHeight + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
			num5 = varCalc.ZOffset - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
		}
		else
		{
			num4 = varCalc.ZOffset + buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
			num5 = varCalc.ZOffset - varCalc.BlockIdealHeight - buFoamCalc.varFoamSettings.OnlineBorderDrawOffset;
		}
		if (activePattern.planeName == FoamPlaneType.XZ)
		{
			list.Add(new PointRGB(0.0, 0.0, num4, Color.Lime));
			list.Add(new PointRGB(varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, num4, Color.Lime));
			list.Add(new PointRGB(varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, 0.0, num5, Color.Lime));
			list.Add(new PointRGB(0.0, 0.0, num5, Color.Lime));
			list.Add(new PointRGB(0.0, 0.0, num4, Color.Lime));
			ccVars.pntDrawDynamicLinesArrColored.Add(list);
			Point3D MidPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref activeBlock.MinPoint, ref MidPoint, ref activeBlock.MaxPoint);
			activeBlock.MinPoint.Y = 0.0;
			activeBlock.MaxPoint.Y = activeFoam.Material.Size.Height;
		}
		if (activePattern.planeName == FoamPlaneType.YZ)
		{
			list.Add(new PointRGB(0.0, 0.0, num4, Color.Lime));
			list.Add(new PointRGB(0.0, varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, num4, Color.Lime));
			list.Add(new PointRGB(0.0, varCalc.BlockIdealWidth + RunSettings.PatternWidthStartOffset + RunSettings.PatternWidthEndOffset, num5, Color.Lime));
			list.Add(new PointRGB(0.0, 0.0, num5, Color.Lime));
			list.Add(new PointRGB(0.0, 0.0, num4, Color.Lime));
			ccVars.pntDrawDynamicLinesArrColored.Add(list);
			Point3D MidPoint2 = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref activeBlock.MinPoint, ref MidPoint2, ref activeBlock.MaxPoint);
			activeBlock.MinPoint.X = 0.0;
			activeBlock.MaxPoint.X = activeFoam.Material.Size.Width;
		}
		if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown)
		{
			activeBlock.TopZ = varCalc.ZOffset + varCalc.BlockIdealHeight;
			activeBlock.BottomZ = varCalc.ZOffset;
		}
		else
		{
			activeBlock.TopZ = varCalc.ZOffset;
			activeBlock.BottomZ = varCalc.ZOffset - varCalc.BlockIdealHeight;
		}
		activeBlock.BlockName = RunSettings.BlockName;
		activeBlock.SizeObj = new SizeObject(activeBlock.MaxPoint.X - activeBlock.MinPoint.X, activeBlock.MaxPoint.Y - activeBlock.MinPoint.Y, activeBlock.MaxPoint.Z - activeBlock.MinPoint.Z);
		if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown)
		{
			for (double num6 = 0.0; num6 <= (double)(varCalc.YCountActual - 1); num6 += 1.0)
			{
				double num7 = 0.0;
				if (num6 > 0.0)
				{
					num7 = num;
				}
				varCalc.ZOffset += num7;
				new List<Point3D>();
				List<FoamPattern> calcPatterns = new List<FoamPattern>();
				FoamWaveShapeArgs args = new FoamWaveShapeArgs(RunSettings.PatternWidthStartOffset, zPos, RunSettings.WaveFormShapeCommonHeight, RunSettings.WaveFormShapeCommonWidth, RunSettings.WaveFormShapeCommonBaseHeight, int_1, num2, varCalc.ZOffset, buFoamCalc.varFoamSettings.CuttingFeed, RunSettings.WaveFormShapeCommonRoundRad, RunSettings.WaveFormShapeCommonChamferLen, buFoamCalc.varFoamRunSettings.planeNames, activeFoam.Material.Size);
				if (Type != FoamType.Pyramid)
				{
					if (!(Type == FoamType.Rectangle || Type == FoamType.UForm))
					{
						clsInit.cFoamCut.WaveTypeShape(args, Type, ref calcPatterns);
					}
					else
					{
						clsInit.cFoamCut.WavePyramitShape(args, Type, ref calcPatterns);
					}
				}
				else
				{
					clsInit.cFoamCut.WavePyramitShape(args, Type, ref calcPatterns);
				}
				for (int i = 0; i <= calcPatterns.Count - 1; i++)
				{
					FoamPattern Pattern = calcPatterns[i];
					calcPatterns[i].VerticalIndex = (int)num6;
					calcPatterns[i].HorizontalIndex = i;
					for (int j = 0; j <= calcPatterns[i].foamEntities.Count - 1; j++)
					{
						List<Point3D> Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(calcPatterns[i].foamEntities[j].GroupEntity.Outside.Entities, ref Points);
						ccVars.pntDrawDynamicLinesArr.Add(Points);
					}
					FoamPatterns.Add(calcPatterns[i]);
					if (Finished && buFoamCalc.varFoamSettings.Draw3D)
					{
						clsInit.cFoamCut.CreateSolidOperation(ref Pattern, activeFoam.Material.Size, activePattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
					}
				}
			}
			varCalc.ZOffset = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset;
		}
		else
		{
			for (double num8 = varCalc.YCountActual - 1; num8 >= 0.0; num8 -= 1.0)
			{
				double num9 = 0.0;
				if (num8 == (double)(varCalc.YCountActual - 1))
				{
					num9 = buFoamCalc.varFoamRunSettings.WaveFormSpace;
				}
				varCalc.ZOffset -= num - num9;
				new List<Point3D>();
				List<FoamPattern> calcPatterns2 = new List<FoamPattern>();
				FoamWaveShapeArgs args2 = new FoamWaveShapeArgs(RunSettings.PatternWidthStartOffset, zPos, RunSettings.WaveFormShapeCommonHeight, RunSettings.WaveFormShapeCommonWidth, RunSettings.WaveFormShapeCommonBaseHeight, int_1, num2, varCalc.ZOffset, buFoamCalc.varFoamSettings.CuttingFeed, RunSettings.WaveFormShapeCommonRoundRad, RunSettings.WaveFormShapeCommonChamferLen, buFoamCalc.varFoamRunSettings.planeNames, activeFoam.Material.Size);
				if (Type != FoamType.Pyramid)
				{
					if (!(Type == FoamType.Rectangle || Type == FoamType.UForm))
					{
						clsInit.cFoamCut.WaveTypeShape(args2, Type, ref calcPatterns2);
					}
					else
					{
						clsInit.cFoamCut.WavePyramitShape(args2, Type, ref calcPatterns2);
					}
				}
				else
				{
					clsInit.cFoamCut.WavePyramitShape(args2, Type, ref calcPatterns2);
				}
				for (int k = 0; k <= calcPatterns2.Count - 1; k++)
				{
					FoamPattern Pattern2 = calcPatterns2[k];
					calcPatterns2[k].VerticalIndex = (int)num8;
					calcPatterns2[k].HorizontalIndex = k;
					for (int l = 0; l <= calcPatterns2[k].foamEntities.Count - 1; l++)
					{
						List<Point3D> Points2 = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(calcPatterns2[k].foamEntities[l].GroupEntity.Outside.Entities, ref Points2);
						ccVars.pntDrawDynamicLinesArr.Add(Points2);
					}
					FoamPatterns.Add(calcPatterns2[k]);
					if (Finished && buFoamCalc.varFoamSettings.Draw3D)
					{
						clsInit.cFoamCut.CreateSolidOperation(ref Pattern2, activeFoam.Material.Size, activePattern.planeName, Pattern2.Color, buFoamCalc.varFoamSettings.UseMultiColor);
					}
				}
			}
			varCalc.ZOffset = RunSettings.BlockHeight - RunSettings.PatternHeightStartOffset;
		}
		string Info = "";
		clsInit.cFoamCut.PatternInfo(FoamPatterns, activeFoam.Material.Size, buFoamCalc.varFoamSettings, RunSettings, ref Info);
		frmWave.txt_info.Text = Info;
	}

	public void doCalculateSlicesHorizontal(FoamRuntimeSettings RunSettings, bool Finished, FoamType Type, ref List<FoamPattern> FoamPatterns, bool Edit = false)
	{
		AppBool.Calculation = true;
		varCalc.PatternHeight = RunSettings.SlicesHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
		varCalc.ZOffset = 0.0;
		doOperationSizeCalcHor(ref RunSettings, Edit);
		FoamPatterns = new List<FoamPattern>();
		AppBool.Calculation = true;
		frmSlice.spn_blockvercount.Value = varCalc.YCountActual;
		frmSlice.spn_blockhorcount.Value = 1m;
		frmSlice.spn_totalpart.Value = varCalc.YCountActual;
		AppBool.Calculation = false;
		ccVars.pntDrawDynamicLinesArr.Clear();
		ccVars.pntDrawDynamicLinesArrColored.Clear();
		if (activePattern != null)
		{
			List<Point3D> list = new List<Point3D>();
			if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.UpToDown)
			{
				if ((activePattern.planeName == FoamPlaneType.XZ) | (activePattern.planeName == FoamPlaneType.YZ))
				{
					activeBlock.TopZ = varCalc.ZOffset + varCalc.BlockIdealHeight;
					activeBlock.BottomZ = varCalc.ZOffset;
					for (double num = 0.0; num <= (double)(varCalc.YCountActual - 1); num += 1.0)
					{
						List<Point3D> refPoints = new List<Point3D>();
						if (num == 0.0)
						{
							list = new List<Point3D>();
							list.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								list.Add(new Point3D(RunSettings.BlockWidth, 0.0, varCalc.ZOffset));
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								list.Add(new Point3D(0.0, RunSettings.BlockWidth, varCalc.ZOffset));
							}
							ccVars.pntDrawDynamicLinesArr.Add(list);
							if (Finished)
							{
								FoamPattern foamPattern = new FoamPattern();
								buLine item = null;
								if (activePattern.planeName == FoamPlaneType.XZ)
								{
									item = new buLine(new Point3D(list[0].X - buFoamCalc.varFoamSettings.LeadInLength, list[0].Y, list[0].Z), list[0]);
								}
								if (activePattern.planeName == FoamPlaneType.YZ)
								{
									item = new buLine(new Point3D(list[0].X, list[0].Y - buFoamCalc.varFoamSettings.LeadInLength, list[0].Z), list[0]);
								}
								foamPattern.planeName = activePattern.planeName;
								foamPattern.HorizontalIndex = 0;
								foamPattern.VerticalIndex = Convert.ToInt32(num + 1.0);
								foamPattern.Type = FoamType.SlicesHorizontal;
								foamPattern.GroupType = FoamOperationType.Wave;
								foamPattern.sortEntities.Add(item);
								if (activePattern.planeName == FoamPlaneType.XZ)
								{
									foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.X - foamPattern.BoxMinItem.X, 3);
								}
								if (activePattern.planeName == FoamPlaneType.YZ)
								{
									foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.Y - foamPattern.BoxMinItem.Y, 3);
								}
								foamPattern.Height = Math.Round(foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z, 3);
								clsInit.cVector5.BoxSizeCalculate(list, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
								for (int i = 1; i <= list.Count - 1; i++)
								{
									item = new buLine(list[i - 1], list[i]);
									foamPattern.sortEntities.Add(item);
								}
								if (activePattern.planeName == FoamPlaneType.XZ)
								{
									item = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Y, list[list.Count - 1].Z));
								}
								if (activePattern.planeName == FoamPlaneType.YZ)
								{
									item = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Z));
								}
								foamPattern.sortEntities.Add(item);
								FoamPatterns.Add(foamPattern);
							}
						}
						varCalc.ZOffset += RunSettings.SlicesHeight;
						list = new List<Point3D>();
						list.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
						refPoints.Add(buVector5.ToPoint3D(list[list.Count - 1]));
						if (activePattern.planeName == FoamPlaneType.XZ)
						{
							list.Add(new Point3D(RunSettings.BlockWidth, 0.0, varCalc.ZOffset));
							refPoints.Add(buVector5.ToPoint3D(list[list.Count - 1]));
							double x = list[list.Count - 1].X;
							refPoints.Add(new Point3D(x, list[list.Count - 1].Y, list[list.Count - 1].Z + RunSettings.SlicesHeight));
							refPoints.Add(new Point3D(0.0, list[list.Count - 1].Y, list[list.Count - 1].Z + RunSettings.SlicesHeight));
							refPoints.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
						}
						if (activePattern.planeName == FoamPlaneType.YZ)
						{
							list.Add(new Point3D(0.0, RunSettings.BlockWidth, varCalc.ZOffset));
							refPoints.Add(buVector5.ToPoint3D(list[list.Count - 1]));
							double y = list[list.Count - 1].Y;
							refPoints.Add(new Point3D(list[list.Count - 1].X, y, list[list.Count - 1].Z + RunSettings.SlicesHeight));
							refPoints.Add(new Point3D(list[list.Count - 1].X, 0.0, list[list.Count - 1].Z + RunSettings.SlicesHeight));
							refPoints.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
						}
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref list);
						ccVars.pntDrawDynamicLinesArr.Add(list);
						if (Finished)
						{
							clsInit.cVector5.Move(0.0, 0.0, 0.0 - RunSettings.SlicesHeight, ref refPoints);
							FoamPattern Pattern = new FoamPattern();
							List<buEntity> list2 = new List<buEntity>();
							list2.Add(new buLinearPath(refPoints));
							clsInit.cVector5.BoxSizeCalculate(list2, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
							buLine item2 = null;
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								item2 = new buLine(new Point3D(list[0].X - buFoamCalc.varFoamSettings.LeadInLength, list[0].Y, list[0].Z), list[0]);
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								item2 = new buLine(new Point3D(list[0].X, list[0].Y - buFoamCalc.varFoamSettings.LeadInLength, list[0].Z), list[0]);
							}
							Pattern.planeName = activePattern.planeName;
							Pattern.HorizontalIndex = 0;
							Pattern.VerticalIndex = Convert.ToInt32(num);
							Pattern.Type = FoamType.SlicesHorizontal;
							Pattern.GroupType = FoamOperationType.Wave;
							Pattern.sortEntities.Add(item2);
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								Pattern.Width = Math.Round(Pattern.BoxMaxItem.Y - Pattern.BoxMinItem.Y, 3);
							}
							Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
							clsInit.cVector5.BoxSizeCalculate(list, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
							for (int j = 1; j <= list.Count - 1; j++)
							{
								item2 = new buLine(list[j - 1], list[j]);
								Pattern.sortEntities.Add(item2);
							}
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								item2 = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Y, list[list.Count - 1].Z));
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								item2 = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Z));
							}
							Pattern.sortEntities.Add(item2);
							FoamEntities foamEntities = new FoamEntities();
							buLinearPath item3 = new buLinearPath(refPoints);
							foamEntities.GroupEntity.Outside.Entities.Add(item3);
							Pattern.foamEntities.Add(foamEntities);
							if (buFoamCalc.varFoamSettings.Draw3D)
							{
								clsInit.cFoamCut.CreateSolidOperation(ref Pattern, activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
							}
							FoamPatterns.Add(Pattern);
						}
					}
					Point3D MidPoint = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref activeBlock.MinPoint, ref MidPoint, ref activeBlock.MaxPoint);
					if (activePattern.planeName == FoamPlaneType.XZ)
					{
						activeBlock.MinPoint.Y = 0.0;
						activeBlock.MaxPoint.Y = activeFoam.Material.Size.Height;
					}
					if (activePattern.planeName == FoamPlaneType.YZ)
					{
						activeBlock.MinPoint.X = 0.0;
						activeBlock.MaxPoint.X = activeFoam.Material.Size.Width;
					}
					activeBlock.BlockName = RunSettings.BlockName;
					activeBlock.SizeObj = new SizeObject(activeBlock.MaxPoint.X - activeBlock.MinPoint.X, activeBlock.MaxPoint.Y - activeBlock.MinPoint.Y, activeBlock.MaxPoint.Z - activeBlock.MinPoint.Z);
				}
			}
			else if ((activePattern.planeName == FoamPlaneType.XZ) | (activePattern.planeName == FoamPlaneType.YZ))
			{
				activeBlock.TopZ = varCalc.ZOffset;
				activeBlock.BottomZ = varCalc.ZOffset - varCalc.BlockIdealHeight;
				for (double num2 = varCalc.YCountActual - 1; num2 >= 0.0; num2 -= 1.0)
				{
					List<Point3D> list3 = new List<Point3D>();
					if (num2 == (double)(varCalc.YCountActual - 1))
					{
						list = new List<Point3D>();
						list.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
						if (activePattern.planeName == FoamPlaneType.XZ)
						{
							list.Add(new Point3D(RunSettings.BlockWidth, 0.0, varCalc.ZOffset));
						}
						if (activePattern.planeName == FoamPlaneType.YZ)
						{
							list.Add(new Point3D(0.0, RunSettings.BlockWidth, varCalc.ZOffset));
						}
						ccVars.pntDrawDynamicLinesArr.Add(list);
						if (Finished)
						{
							FoamPattern foamPattern2 = new FoamPattern();
							buLine item4 = null;
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								item4 = new buLine(new Point3D(list[0].X - buFoamCalc.varFoamSettings.LeadInLength, list[0].Y, list[0].Z), list[0]);
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								item4 = new buLine(new Point3D(list[0].X, list[0].Y - buFoamCalc.varFoamSettings.LeadInLength, list[0].Z), list[0]);
							}
							foamPattern2.planeName = activePattern.planeName;
							foamPattern2.HorizontalIndex = 0;
							foamPattern2.VerticalIndex = Convert.ToInt32(num2 + 1.0);
							foamPattern2.Type = FoamType.SlicesHorizontal;
							foamPattern2.GroupType = FoamOperationType.Wave;
							foamPattern2.sortEntities.Add(item4);
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								foamPattern2.Width = Math.Round(foamPattern2.BoxMaxItem.X - foamPattern2.BoxMinItem.X, 3);
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								foamPattern2.Width = Math.Round(foamPattern2.BoxMaxItem.Y - foamPattern2.BoxMinItem.Y, 3);
							}
							foamPattern2.Height = Math.Round(foamPattern2.BoxMaxItem.Z - foamPattern2.BoxMinItem.Z, 3);
							clsInit.cVector5.BoxSizeCalculate(list, ref foamPattern2.BoxMinItem, ref foamPattern2.BoxMaxItem);
							for (int k = 1; k <= list.Count - 1; k++)
							{
								item4 = new buLine(list[k - 1], list[k]);
								foamPattern2.sortEntities.Add(item4);
							}
							if (activePattern.planeName == FoamPlaneType.XZ)
							{
								item4 = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Y, list[list.Count - 1].Z));
							}
							if (activePattern.planeName == FoamPlaneType.YZ)
							{
								item4 = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Z));
							}
							foamPattern2.sortEntities.Add(item4);
							FoamPatterns.Add(foamPattern2);
						}
					}
					varCalc.ZOffset -= RunSettings.SlicesHeight;
					list = new List<Point3D>();
					list.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
					list3.Add(buVector5.ToPoint3D(list[list.Count - 1]));
					if (activePattern.planeName == FoamPlaneType.XZ)
					{
						list.Add(new Point3D(RunSettings.BlockWidth, 0.0, varCalc.ZOffset));
						list3.Add(buVector5.ToPoint3D(list[list.Count - 1]));
						double x2 = list[list.Count - 1].X;
						list3.Add(new Point3D(x2, list[list.Count - 1].Y, list[list.Count - 1].Z + RunSettings.SlicesHeight));
						list3.Add(new Point3D(0.0, list[list.Count - 1].Y, list[list.Count - 1].Z + RunSettings.SlicesHeight));
						list3.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
					}
					if (activePattern.planeName == FoamPlaneType.YZ)
					{
						list.Add(new Point3D(0.0, RunSettings.BlockWidth, varCalc.ZOffset));
						list3.Add(buVector5.ToPoint3D(list[list.Count - 1]));
						double y2 = list[list.Count - 1].Y;
						list3.Add(new Point3D(list[list.Count - 1].X, y2, list[list.Count - 1].Z + RunSettings.SlicesHeight));
						list3.Add(new Point3D(list[list.Count - 1].X, 0.0, list[list.Count - 1].Z + RunSettings.SlicesHeight));
						list3.Add(new Point3D(0.0, 0.0, varCalc.ZOffset));
					}
					clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref list);
					ccVars.pntDrawDynamicLinesArr.Add(list);
					if (Finished)
					{
						FoamPattern Pattern2 = new FoamPattern();
						List<buEntity> list4 = new List<buEntity>();
						list4.Add(new buLinearPath(list3));
						clsInit.cVector5.BoxSizeCalculate(list4, ref Pattern2.BoxMinItem, ref Pattern2.BoxMaxItem);
						buLine item5 = null;
						if (activePattern.planeName == FoamPlaneType.XZ)
						{
							item5 = new buLine(new Point3D(list[0].X - buFoamCalc.varFoamSettings.LeadInLength, list[0].Y, list[0].Z), list[0]);
						}
						if (activePattern.planeName == FoamPlaneType.YZ)
						{
							item5 = new buLine(new Point3D(list[0].X, list[0].Y - buFoamCalc.varFoamSettings.LeadInLength, list[0].Z), list[0]);
						}
						Pattern2.planeName = activePattern.planeName;
						Pattern2.HorizontalIndex = 0;
						Pattern2.VerticalIndex = Convert.ToInt32(num2);
						Pattern2.Type = FoamType.SlicesHorizontal;
						Pattern2.GroupType = FoamOperationType.Wave;
						Pattern2.sortEntities.Add(item5);
						if (activePattern.planeName == FoamPlaneType.XZ)
						{
							Pattern2.Width = Math.Round(Pattern2.BoxMaxItem.X - Pattern2.BoxMinItem.X, 3);
						}
						if (activePattern.planeName == FoamPlaneType.YZ)
						{
							Pattern2.Width = Math.Round(Pattern2.BoxMaxItem.Y - Pattern2.BoxMinItem.Y, 3);
						}
						Pattern2.Height = Math.Round(Pattern2.BoxMaxItem.Z - Pattern2.BoxMinItem.Z, 3);
						clsInit.cVector5.BoxSizeCalculate(list, ref Pattern2.BoxMinItem, ref Pattern2.BoxMaxItem);
						for (int l = 1; l <= list.Count - 1; l++)
						{
							item5 = new buLine(list[l - 1], list[l]);
							Pattern2.sortEntities.Add(item5);
						}
						if (activePattern.planeName == FoamPlaneType.XZ)
						{
							item5 = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Y, list[list.Count - 1].Z));
						}
						if (activePattern.planeName == FoamPlaneType.YZ)
						{
							item5 = new buLine(list[list.Count - 1], new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y + buFoamCalc.varFoamSettings.LeadOutLength, list[list.Count - 1].Z));
						}
						Pattern2.sortEntities.Add(item5);
						FoamEntities foamEntities2 = new FoamEntities();
						buLinearPath item6 = new buLinearPath(list3);
						foamEntities2.GroupEntity.Outside.Entities.Add(item6);
						Pattern2.foamEntities.Add(foamEntities2);
						if (buFoamCalc.varFoamSettings.Draw3D)
						{
							clsInit.cFoamCut.CreateSolidOperation(ref Pattern2, activeFoam.Material.Size, Pattern2.planeName, Pattern2.Color, buFoamCalc.varFoamSettings.UseMultiColor);
						}
						FoamPatterns.Add(Pattern2);
					}
				}
				Point3D MidPoint2 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref activeBlock.MinPoint, ref MidPoint2, ref activeBlock.MaxPoint);
				if (activePattern.planeName == FoamPlaneType.XZ)
				{
					activeBlock.MinPoint.Y = 0.0;
					activeBlock.MaxPoint.Y = activeFoam.Material.Size.Height;
				}
				if (activePattern.planeName == FoamPlaneType.YZ)
				{
					activeBlock.MinPoint.X = 0.0;
					activeBlock.MaxPoint.X = activeFoam.Material.Size.Width;
				}
				activeBlock.BlockName = RunSettings.BlockName;
				activeBlock.SizeObj = new SizeObject(activeBlock.MaxPoint.X - activeBlock.MinPoint.X, activeBlock.MaxPoint.Y - activeBlock.MinPoint.Y, activeBlock.MaxPoint.Z - activeBlock.MinPoint.Z);
			}
		}
		AppBool.Calculation = false;
	}

	public void doCalculateSlicesVertical(FoamRuntimeSettings RunSettings, bool Finished, FoamType Type, ref List<FoamPattern> FoamPatterns, bool Edit = false)
	{
		AppBool.Calculation = true;
		varCalc.PatternWidth = RunSettings.SlicesHeight + buFoamCalc.varFoamSettings.PatternDistancesHeight;
		varCalc.XOffset = 0.0;
		doOperationSizeCalcVer(ref RunSettings, Edit);
		FoamPatterns = new List<FoamPattern>();
		frmSlice.spn_blockvercount.Value = 1m;
		frmSlice.spn_blockhorcount.Value = varCalc.XCountActual;
		frmSlice.spn_totalpart.Value = varCalc.XCountActual;
		ccVars.pntDrawDynamicLinesArr.Clear();
		ccVars.pntDrawDynamicLinesArrColored.Clear();
		if (activePattern != null)
		{
			List<Point3D> list = new List<Point3D>();
			if (activePattern.planeName == FoamPlaneType.XZ)
			{
				for (double num = 0.0; num <= (double)(varCalc.XCountActual - 1); num += 1.0)
				{
					List<Point3D> list2 = new List<Point3D>();
					if (num == 0.0)
					{
						list = new List<Point3D>();
						list.Add(new Point3D(varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset));
						list.Add(new Point3D(varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset + varCalc.BlockTrimedHeight));
						ccVars.pntDrawDynamicLinesArr.Add(list);
						if (Finished)
						{
							FoamPattern foamPattern = new FoamPattern();
							buLine buLine2 = null;
							foamPattern.planeName = FoamPlaneType.XZ;
							foamPattern.HorizontalIndex = Convert.ToInt32(num);
							foamPattern.VerticalIndex = Convert.ToInt32(num);
							foamPattern.Type = FoamType.SlicesHorizontal;
							foamPattern.GroupType = FoamOperationType.Wave;
							foamPattern.Width = Math.Round(foamPattern.BoxMaxItem.X - foamPattern.BoxMinItem.X, 3);
							foamPattern.Height = Math.Round(foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z, 3);
							clsInit.cVector5.BoxSizeCalculate(list, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
							for (int i = 1; i <= list.Count - 1; i++)
							{
								buLine2 = new buLine(list[i - 1], list[i]);
								foamPattern.sortEntities.Add(buLine2);
							}
							FoamPatterns.Add(foamPattern);
						}
					}
					varCalc.XOffset += RunSettings.SlicesHeight;
					list = new List<Point3D>();
					list.Add(new Point3D(varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset));
					list2.Add(new Point3D(varCalc.XOffset - RunSettings.SlicesHeight, 0.0, RunSettings.PatternHeightStartOffset));
					list.Add(new Point3D(varCalc.XOffset, 0.0, RunSettings.PatternHeightStartOffset + varCalc.BlockTrimedHeight));
					list2.Add(new Point3D(varCalc.XOffset - RunSettings.SlicesHeight, 0.0, RunSettings.PatternHeightStartOffset + varCalc.BlockTrimedHeight));
					double z = list[list.Count - 1].Z;
					list2.Add(new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y, z));
					list2.Add(new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y, RunSettings.PatternHeightStartOffset));
					list2.Add(new Point3D(varCalc.XOffset - RunSettings.SlicesHeight, 0.0, RunSettings.PatternHeightStartOffset));
					clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref list);
					ccVars.pntDrawDynamicLinesArr.Add(list);
					if (Finished)
					{
						FoamPattern Pattern = new FoamPattern();
						List<buEntity> list3 = new List<buEntity>();
						list3.Add(new buLinearPath(list2));
						clsInit.cVector5.BoxSizeCalculate(list3, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
						buLine buLine3 = null;
						Pattern.planeName = FoamPlaneType.XZ;
						Pattern.HorizontalIndex = Convert.ToInt32(num + 1.0);
						Pattern.VerticalIndex = Convert.ToInt32(num + 1.0);
						Pattern.Type = FoamType.SlicesHorizontal;
						Pattern.GroupType = FoamOperationType.Wave;
						Pattern.Width = Math.Round(Pattern.BoxMaxItem.X - Pattern.BoxMinItem.X, 3);
						Pattern.Height = Math.Round(Pattern.BoxMaxItem.Z - Pattern.BoxMinItem.Z, 3);
						clsInit.cVector5.BoxSizeCalculate(list, ref Pattern.BoxMinItem, ref Pattern.BoxMaxItem);
						for (int j = 1; j <= list.Count - 1; j++)
						{
							buLine3 = new buLine(list[j - 1], list[j]);
							Pattern.sortEntities.Add(buLine3);
						}
						FoamEntities foamEntities = new FoamEntities();
						buLinearPath item = new buLinearPath(list2);
						foamEntities.GroupEntity.Outside.Entities.Add(item);
						Pattern.foamEntities.Add(foamEntities);
						if (buFoamCalc.varFoamSettings.Draw3D)
						{
							clsInit.cFoamCut.CreateSolidOperation(ref Pattern, activeFoam.Material.Size, Pattern.planeName, Pattern.Color, buFoamCalc.varFoamSettings.UseMultiColor);
						}
						FoamPatterns.Add(Pattern);
					}
				}
				Point3D MidPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref activeBlock.MinPoint, ref MidPoint, ref activeBlock.MaxPoint);
				activeBlock.MinPoint.Y = 0.0;
				activeBlock.MaxPoint.Y = activeFoam.Material.Size.Height;
				activeBlock.LeftMax = activeBlock.MaxPoint.X;
				activeBlock.BlockName = RunSettings.BlockName;
				activeBlock.SizeObj = new SizeObject(activeBlock.MaxPoint.X - activeBlock.MinPoint.X, activeBlock.MaxPoint.Y - activeBlock.MinPoint.Y, activeBlock.MaxPoint.Z - activeBlock.MinPoint.Z);
			}
			if (activePattern.planeName == FoamPlaneType.YZ)
			{
				for (double num2 = 0.0; num2 <= (double)(varCalc.XCountActual - 1); num2 += 1.0)
				{
					List<Point3D> list4 = new List<Point3D>();
					if (num2 == 0.0)
					{
						list = new List<Point3D>();
						list.Add(new Point3D(0.0, varCalc.XOffset, RunSettings.PatternHeightStartOffset));
						list.Add(new Point3D(0.0, varCalc.XOffset, RunSettings.PatternHeightStartOffset + varCalc.BlockTrimedHeight));
						ccVars.pntDrawDynamicLinesArr.Add(list);
						if (Finished)
						{
							FoamPattern foamPattern2 = new FoamPattern();
							buLine buLine4 = null;
							foamPattern2.planeName = FoamPlaneType.YZ;
							foamPattern2.HorizontalIndex = Convert.ToInt32(num2);
							foamPattern2.VerticalIndex = Convert.ToInt32(num2);
							foamPattern2.Type = FoamType.SlicesHorizontal;
							foamPattern2.GroupType = FoamOperationType.Wave;
							foamPattern2.Width = Math.Round(foamPattern2.BoxMaxItem.Y - foamPattern2.BoxMinItem.Y, 3);
							foamPattern2.Height = Math.Round(foamPattern2.BoxMaxItem.Z - foamPattern2.BoxMinItem.Z, 3);
							clsInit.cVector5.BoxSizeCalculate(list, ref foamPattern2.BoxMinItem, ref foamPattern2.BoxMaxItem);
							for (int k = 1; k <= list.Count - 1; k++)
							{
								buLine4 = new buLine(list[k - 1], list[k]);
								foamPattern2.sortEntities.Add(buLine4);
							}
							FoamPatterns.Add(foamPattern2);
						}
					}
					varCalc.XOffset += RunSettings.SlicesHeight;
					list = new List<Point3D>();
					list.Add(new Point3D(0.0, varCalc.XOffset, RunSettings.PatternHeightStartOffset));
					list4.Add(new Point3D(0.0, varCalc.XOffset - RunSettings.SlicesHeight, RunSettings.PatternHeightStartOffset));
					list.Add(new Point3D(0.0, varCalc.XOffset, RunSettings.PatternHeightStartOffset + varCalc.BlockTrimedHeight));
					list4.Add(new Point3D(0.0, varCalc.XOffset - RunSettings.SlicesHeight, RunSettings.PatternHeightStartOffset + varCalc.BlockTrimedHeight));
					double z2 = list[list.Count - 1].Z;
					list4.Add(new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y, z2));
					list4.Add(new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y, RunSettings.PatternHeightStartOffset));
					list4.Add(new Point3D(0.0, varCalc.XOffset - RunSettings.SlicesHeight, RunSettings.PatternHeightStartOffset));
					clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref list);
					ccVars.pntDrawDynamicLinesArr.Add(list);
					if (Finished)
					{
						FoamPattern Pattern2 = new FoamPattern();
						List<buEntity> list5 = new List<buEntity>();
						list5.Add(new buLinearPath(list4));
						clsInit.cVector5.BoxSizeCalculate(list5, ref Pattern2.BoxMinItem, ref Pattern2.BoxMaxItem);
						buLine buLine5 = null;
						Pattern2.planeName = FoamPlaneType.YZ;
						Pattern2.HorizontalIndex = Convert.ToInt32(num2 + 1.0);
						Pattern2.VerticalIndex = Convert.ToInt32(num2 + 1.0);
						Pattern2.Type = FoamType.SlicesHorizontal;
						Pattern2.GroupType = FoamOperationType.Wave;
						Pattern2.Width = Math.Round(Pattern2.BoxMaxItem.Y - Pattern2.BoxMinItem.Y, 3);
						Pattern2.Height = Math.Round(Pattern2.BoxMaxItem.Z - Pattern2.BoxMinItem.Z, 3);
						clsInit.cVector5.BoxSizeCalculate(list, ref Pattern2.BoxMinItem, ref Pattern2.BoxMaxItem);
						for (int l = 1; l <= list.Count - 1; l++)
						{
							buLine5 = new buLine(list[l - 1], list[l]);
							Pattern2.sortEntities.Add(buLine5);
						}
						if (buFoamCalc.varFoamSettings.Draw3D)
						{
							FoamEntities foamEntities2 = new FoamEntities();
							buLinearPath item2 = new buLinearPath(list4);
							foamEntities2.GroupEntity.Outside.Entities.Add(item2);
							Pattern2.foamEntities.Add(foamEntities2);
							clsInit.cFoamCut.CreateSolidOperation(ref Pattern2, activeFoam.Material.Size, Pattern2.planeName, Pattern2.Color, buFoamCalc.varFoamSettings.UseMultiColor);
						}
						FoamPatterns.Add(Pattern2);
					}
				}
				Point3D MidPoint2 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArr, ref activeBlock.MinPoint, ref MidPoint2, ref activeBlock.MaxPoint);
				activeBlock.MinPoint.X = 0.0;
				activeBlock.MaxPoint.X = activeFoam.Material.Size.Width;
				activeBlock.LeftMax = activeBlock.MaxPoint.Y;
				activeBlock.BlockName = RunSettings.BlockName;
				activeBlock.SizeObj = new SizeObject(activeBlock.MaxPoint.X - activeBlock.MinPoint.X, activeBlock.MaxPoint.Y - activeBlock.MinPoint.Y, activeBlock.MaxPoint.Z - activeBlock.MinPoint.Z);
			}
			if (activePattern.planeName != FoamPlaneType.YZ)
			{
			}
		}
		AppBool.Calculation = false;
	}

	public void doAddOperation(FoamRuntimeSettings Set)
	{
		buFoamCalc.varFoamRunSettings = new FoamRuntimeSettings(Set);
		new List<List<Point3D>>();
		List<FoamPattern> FoamPatterns = new List<FoamPattern>();
		FoamBlock foamBlock = new FoamBlock(activeBlock);
		if (Set.TypeFoam == FoamType.VForm)
		{
			doCalculateWaveShape(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
			foamBlock.isWaveOperation = true;
		}
		if (Set.TypeFoam != FoamType.ZForm)
		{
			if (Set.TypeFoam != FoamType.SForm)
			{
				if (Set.TypeFoam != FoamType.CForm)
				{
					if (Set.TypeFoam != FoamType.UForm)
					{
						if (Set.TypeFoam == FoamType.Rectangle)
						{
							doCalculateWaveShape(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
							foamBlock.isWaveOperation = true;
						}
					}
					else
					{
						doCalculateWaveShape(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
						foamBlock.isWaveOperation = true;
					}
				}
				else
				{
					doCalculateWaveShape(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
					foamBlock.isWaveOperation = true;
				}
			}
			else
			{
				doCalculateWaveShape(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
				foamBlock.isWaveOperation = true;
			}
		}
		else
		{
			doCalculateWaveShape(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
			foamBlock.isWaveOperation = true;
		}
		if (Set.TypeFoam != FoamType.Pyramid)
		{
			if (Set.TypeFoam != FoamType.FromDrawing)
			{
				if (Set.TypeFoam != FoamType.SlicesHorizontal)
				{
					if (Set.TypeFoam != FoamType.SlicesVertical)
					{
						if (Set.TypeFoam == FoamType.SingleLine)
						{
						}
					}
					else
					{
						doCalculateSlicesVertical(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
						foamBlock.isVertical = true;
					}
				}
				else
				{
					doCalculateSlicesHorizontal(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
				}
			}
			else
			{
				doCalculatePattern(Set, Finished: true, ref FoamPatterns);
				foamBlock.basePattern = new FoamPattern(activePattern);
			}
		}
		else
		{
			doCalculateWaveShape(Set, Finished: true, Set.TypeFoam, ref FoamPatterns);
			foamBlock.isWaveOperation = true;
		}
		if (Set.TypeFoam == FoamType.Pattern)
		{
			foamBlock.basePattern = new FoamPattern(activePattern);
			doCalculatePattern(Set, Finished: true, ref FoamPatterns);
		}
		foamBlock.planeName = buFoamCalc.varFoamRunSettings.planeNames;
		foamBlock.BlockName = Set.BlockName;
		foamBlock.BlockFoamType = Set.TypeFoam;
		foamBlock.Settings = new FoamRuntimeSettings(Set);
		foamBlock.Speeds = new FoamSpeeds(buFoamCalc.varFoamSettings.CuttingFeed, buFoamCalc.varFoamSettings.EntryFeed, buFoamCalc.varFoamSettings.LeaveFeed, buFoamCalc.varFoamSettings.ConnectionFeed, buFoamCalc.varFoamSettings.CRotationFeed);
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			if (activeFoam.BlockXZ.Count != 0)
			{
				if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.DownToUp)
				{
					if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
					{
						activeFoam.BlockXZ.Add(foamBlock);
						foamActiveBlock_0.BlockIndex = activeFoam.BlockXZ.Count - 1;
					}
				}
				else
				{
					activeFoam.BlockXZ.Add(foamBlock);
					foamActiveBlock_0.BlockIndex = activeFoam.BlockXZ.Count - 1;
				}
			}
			else
			{
				activeFoam.BlockXZ.Add(foamBlock);
				foamActiveBlock_0.BlockIndex = 0;
			}
			foamActiveBlock_0.Plane = FoamPlaneType.XZ;
			activeFoam.BlockXZ[foamActiveBlock_0.BlockIndex].Pattern = FoamPatterns;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			if (activeFoam.BlockYZ.Count != 0)
			{
				if (buFoamCalc.varFoamSettings.ZDirection != UpToDownType.DownToUp)
				{
					if (buFoamCalc.varFoamSettings.ZDirection == UpToDownType.UpToDown)
					{
						activeFoam.BlockYZ.Add(foamBlock);
						foamActiveBlock_0.BlockIndex = activeFoam.BlockYZ.Count - 1;
					}
				}
				else
				{
					activeFoam.BlockYZ.Add(foamBlock);
					foamActiveBlock_0.BlockIndex = activeFoam.BlockXZ.Count - 1;
				}
			}
			else
			{
				activeFoam.BlockYZ.Add(foamBlock);
				foamActiveBlock_0.BlockIndex = 0;
			}
			foamActiveBlock_0.Plane = FoamPlaneType.YZ;
			activeFoam.BlockYZ[foamActiveBlock_0.BlockIndex].Pattern = FoamPatterns;
		}
		JobUpdate(FillPages: true, "", null, -1);
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: true, deletesort: false, deletetool: false, drawpreview: true));
		SaveFoamFile();
		activeFoam.isGCodeCreated = false;
		clsInit.appCommand.Reset();
	}

	public void doEditBlock()
	{
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ && ((foamActiveBlock_0.BlockIndex >= 0) & (foamActiveBlock_0.BlockIndex <= activeFoam.BlockXZ.Count - 1)))
		{
			bool_1 = true;
		}
	}

	public void doShowVirtualDrawings()
	{
		if (clsInit.appEditor == null)
		{
			return;
		}
		Sketcher2D.DrawingPoints.Clear();
		clsItem.frmEditor.viewport.Entities.RegenAllCurved(0.01);
		double dX = clsItem.frmEditor.viewport.Entities.BoxMax.X - clsItem.frmEditor.viewport.Entities.BoxMin.X + buFoamCalc.varFoamEditorSettings.RigthVirtualDrawingDistance;
		double dY = 0.0 - (clsItem.frmEditor.viewport.Entities.BoxMax.Y - clsItem.frmEditor.viewport.Entities.BoxMin.Y) - buFoamCalc.varFoamEditorSettings.BottomVirtualDrawingDistance;
		if (buFoamCalc.varFoamEditorSettings.ShowRightVirtualDrawing)
		{
			for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
			{
				List<Point3D> copiedPoint = new List<Point3D>();
				buVector5.Copy(clsItem.frmEditor.viewport.Entities[i].Vertices, ref copiedPoint);
				clsInit.cVector5.Move(dX, 0.0, 0.0, ref copiedPoint);
				Sketcher2D.DrawingPoints.Add(copiedPoint);
			}
			for (int j = 0; j <= clsInit.appEditor.sortedEntities.Count - 1; j++)
			{
				List<Point3D> copiedPoint2 = new List<Point3D>();
				buVector5.Copy(clsInit.appEditor.sortedEntities[j].Vertices, ref copiedPoint2);
				clsInit.cVector5.Move(dX, 0.0, 0.0, ref copiedPoint2);
				Sketcher2D.DrawingPoints.Add(copiedPoint2);
			}
		}
		if (buFoamCalc.varFoamEditorSettings.ShowBottomVirtualDrawing)
		{
			for (int k = 0; k <= clsItem.frmEditor.viewport.Entities.Count - 1; k++)
			{
				List<Point3D> copiedPoint3 = new List<Point3D>();
				buVector5.Copy(clsItem.frmEditor.viewport.Entities[k].Vertices, ref copiedPoint3);
				clsInit.cVector5.Move(0.0, dY, 0.0, ref copiedPoint3);
				Sketcher2D.DrawingPoints.Add(copiedPoint3);
			}
			for (int l = 0; l <= clsInit.appEditor.sortedEntities.Count - 1; l++)
			{
				List<Point3D> copiedPoint4 = new List<Point3D>();
				buVector5.Copy(clsInit.appEditor.sortedEntities[l].Vertices, ref copiedPoint4);
				clsInit.cVector5.Move(0.0, dY, 0.0, ref copiedPoint4);
				Sketcher2D.DrawingPoints.Add(copiedPoint4);
			}
		}
		if (buFoamCalc.varFoamEditorSettings.ShowBottomRightVirtualDrawing)
		{
			for (int m = 0; m <= clsItem.frmEditor.viewport.Entities.Count - 1; m++)
			{
				List<Point3D> copiedPoint5 = new List<Point3D>();
				buVector5.Copy(clsItem.frmEditor.viewport.Entities[m].Vertices, ref copiedPoint5);
				clsInit.cVector5.Move(dX, dY, 0.0, ref copiedPoint5);
				Sketcher2D.DrawingPoints.Add(copiedPoint5);
			}
			for (int n = 0; n <= clsInit.appEditor.sortedEntities.Count - 1; n++)
			{
				List<Point3D> copiedPoint6 = new List<Point3D>();
				buVector5.Copy(clsInit.appEditor.sortedEntities[n].Vertices, ref copiedPoint6);
				clsInit.cVector5.Move(dX, dY, 0.0, ref copiedPoint6);
				Sketcher2D.DrawingPoints.Add(copiedPoint6);
			}
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void doGetNestResult(buNestedResult Result, int SheetIndex, int PartIndex)
	{
		int num = 0;
		int num2 = Result.NestedResultSheets.Count - 1;
		if (SheetIndex >= 0)
		{
			num = SheetIndex;
			num2 = SheetIndex;
		}
		selectedEntities.Clear();
		selectedEntities = new List<List<buEntity>>();
		if (Result.NestedResultSheets.Count <= 0)
		{
			return;
		}
		for (int i = num; i <= num2; i++)
		{
			List<Entity> calcEntities = new List<Entity>();
			List<Entity> UselessEntities = new List<Entity>();
			ccVars.UndoDont = true;
			clsInit.cNesting.NestedSheetToEntity(Result.NestedResultSheets[i], isSolid: false, OnlyOutterSolid: false, ref calcEntities, ref UselessEntities);
			int num3 = 0;
			int num4 = Result.NestedResultSheets[i].Parts.Count - 1;
			if (PartIndex >= 0)
			{
				num3 = PartIndex;
				num4 = PartIndex;
			}
			List<buEntity> list = new List<buEntity>();
			for (int j = num3; j <= num4; j++)
			{
				ccVars.UndoDont = true;
				List<Entity> calcEntities2 = new List<Entity>();
				clsInit.cNesting.NestedPartToEntity(Result.NestedResultSheets[i].Parts[j], isSolid: false, OnlyOutterSolid: false, ref calcEntities2);
				new List<Pnt3D>();
				List<buEntity> copiedEntities = new List<buEntity>();
				buEntity.Copy(Result.NestedResultSheets[i].Parts[j].EntitiesGroup.Outside.Entities, ref copiedEntities);
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(copiedEntities, ref MinPoint, ref MaxPoint);
				if (MinPoint.Z != 0.0)
				{
					clsInit.cVector5.Move(0.0, 0.0, 0.0 - MinPoint.Z, ref copiedEntities);
				}
				List<buEntity> SortedEntities = new List<buEntity>();
				SortbuResult Result2 = new SortbuResult();
				clsInit.cVector5.SortEntitiesByRefPoint(copiedEntities[0].StartPoint, ref copiedEntities, new SortbuSettings(), ref SortedEntities, ref Result2);
				list = new List<buEntity>();
				for (int k = 0; k <= SortedEntities.Count - 1; k++)
				{
					if (!(SortedEntities[k] is buCircle))
					{
						if (!(SortedEntities[k] is buArc))
						{
							list.Add(SortedEntities[k]);
							continue;
						}
						double num5 = ((buArc)SortedEntities[k]).EndAngle - ((buArc)SortedEntities[k]).StartAngle;
						if (!(num5 > 170.0))
						{
							list.Add(SortedEntities[k]);
							continue;
						}
						buEntity Arc = null;
						buEntity Arc2 = null;
						clsInit.cVector5.ArcToTwoArc((buArc)SortedEntities[k], ref Arc, ref Arc2);
						list.Add(Arc);
						list.Add(Arc2);
					}
					else
					{
						buArc Arc3 = null;
						buArc Arc4 = null;
						buArc Arc5 = null;
						buArc Arc6 = null;
						clsInit.cVector5.CircletoFourArc((buCircle)SortedEntities[k], ref Arc3, ref Arc4, ref Arc5, ref Arc6);
						list.Add(Arc3);
						list.Add(Arc4);
						list.Add(Arc5);
						list.Add(Arc6);
					}
				}
				selectedEntities.Add(list);
			}
			cmdAddFromFile(null, selectedEntities);
		}
	}

	public void doGeneralTick(int TickCount)
	{
	}

	public void doReset()
	{
		pnldata.Visible = false;
		DeleteEntities(Mark: true, Sorted: false, Tool: false);
		buFoamCalc.varTemps.pntLastSelected = null;
		bool_1 = false;
		varCalc.isVertical = false;
		if (okCommandWithTwoDataEventHandler_0 != null)
		{
			okCommandWithTwoDataEventHandler_0("Cancel", null);
		}
	}

	public void doNewPage()
	{
		ccVars.planeActive = Plane.XY;
		ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XY;
		clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
		clsInit.appCommand.cmdViewTop(ZoomFit: false, AtPlane: false);
		timer_1.Enabled = true;
	}

	public void doOpenPage()
	{
		ccVars.planeActive = Plane.XY;
		ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane = Plane.XY;
		clsInit.appCommand.SetViewAccordingToPlane(ccVars.Pages[ccVars.PageIndex].Scene[ccVars.Pages[ccVars.PageIndex].SceneIndex].ScenePlane);
		clsInit.appCommand.cmdViewTop(ZoomFit: false, AtPlane: false);
	}

	public void CreateGCode(ref List<camTp> CamList, ref PostProcessor P)
	{
		for (int i = 0; i <= activeFoam.sortedEntitiesXZ.Count - 1; i++)
		{
			if (i > 0)
			{
				if (((activeFoam.sortedEntitiesXZ[i].typeDefination == entityTypeDefination.None) | (activeFoam.sortedEntitiesXZ[i].typeDefination == entityTypeDefination.Cutting)) && activeFoam.sortedEntitiesXZ[i - 1].typeDefination == entityTypeDefination.Upper)
				{
					activeFoam.sortedEntitiesXZ[i - 1].typeDefination = entityTypeDefination.CamLeadin;
				}
				if (activeFoam.sortedEntitiesXZ[i].typeDefination == entityTypeDefination.Upper && ((activeFoam.sortedEntitiesXZ[i - 1].typeDefination == entityTypeDefination.None) | (activeFoam.sortedEntitiesXZ[i - 1].typeDefination == entityTypeDefination.Cutting)))
				{
					activeFoam.sortedEntitiesXZ[i].typeDefination = entityTypeDefination.CamLeadOut;
				}
			}
		}
		for (int j = 0; j <= activeFoam.sortedEntitiesYZ.Count - 1; j++)
		{
			if (j > 0)
			{
				if (((activeFoam.sortedEntitiesYZ[j].typeDefination == entityTypeDefination.None) | (activeFoam.sortedEntitiesYZ[j].typeDefination == entityTypeDefination.Cutting)) && activeFoam.sortedEntitiesYZ[j - 1].typeDefination == entityTypeDefination.Upper)
				{
					activeFoam.sortedEntitiesYZ[j - 1].typeDefination = entityTypeDefination.CamLeadin;
				}
				if (activeFoam.sortedEntitiesYZ[j].typeDefination == entityTypeDefination.Upper && ((activeFoam.sortedEntitiesYZ[j - 1].typeDefination == entityTypeDefination.None) | (activeFoam.sortedEntitiesYZ[j - 1].typeDefination == entityTypeDefination.Cutting)))
				{
					activeFoam.sortedEntitiesYZ[j].typeDefination = entityTypeDefination.CamLeadOut;
				}
			}
		}
		if (ccVars.PostActive.Mode == "AES")
		{
			CreateGCodeAES(ref CamList, ref P);
		}
		if (ccVars.PostActive.Mode == "CMD")
		{
			CreateGCodeCMD(ref CamList, ref P);
		}
	}

	public void cmdCamContour(ref camTp Cam)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			bool flag = false;
			List<Point3D> Points = new List<Point3D>();
			clsInit.cVector5.EntitiesToPointsWithCamDirection(clsMW.CamBuEntities, ref Points);
			clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
			double num = 0.0;
			double LastAng = 0.0;
			double num2 = 0.0;
			Point3D pntLast = new Point3D();
			Cam = new camTp();
			camTpPoint camTpPoint2 = new camTpPoint();
			TpPnt9D tpPnt9D = new TpPnt9D();
			ClockDirectionType clockDirectionType = ClockDirectionType.CW;
			for (int i = 0; i <= clsMW.CamBuEntities.Count - 1; i++)
			{
				int num3 = 0;
				double connectionFeed = buFoamCalc.varFoamSettings.ConnectionFeed;
				double entryFeed = buFoamCalc.varFoamSettings.EntryFeed;
				double leaveFeed = buFoamCalc.varFoamSettings.LeaveFeed;
				double num4 = buFoamCalc.varFoamSettings.CuttingFeed;
				double cRotationFeed = buFoamCalc.varFoamSettings.CRotationFeed;
				if (clsMW.CamBuEntities[i].Info.OrjType == entityOriginalType.Arc && ((clsMW.CamBuEntities[i].Info.Radius > 0.0) & (buFoamCalc.RadiusFeedList.Count > 0)))
				{
					for (int j = 0; j <= buFoamCalc.RadiusFeedList.Count - 1; j++)
					{
						if (((buFoamCalc.RadiusFeedList[j].MinRadius <= clsMW.CamBuEntities[i].Info.Radius) & (clsMW.CamBuEntities[i].Info.Radius <= buFoamCalc.RadiusFeedList[j].MaxRadius)) && buFoamCalc.RadiusFeedList[j].Feed > 0.0)
						{
							num4 = buFoamCalc.RadiusFeedList[j].Feed;
							j = buFoamCalc.RadiusFeedList.Count;
						}
					}
				}
				if (i > 0 && ((clsMW.CamBuEntities[i - 1].Info.OrjType == entityOriginalType.Arc) & ((clsMW.CamBuEntities[i].Info.OrjType == entityOriginalType.Line) | (clsMW.CamBuEntities[i].Info.OrjType == entityOriginalType.LinearPath))))
				{
					double num5 = clsMW.CamBuEntities[i].Length();
					for (int k = 0; k <= buFoamCalc.LengthFeedList.Count - 1; k++)
					{
						if (((buFoamCalc.LengthFeedList[k].MinLength <= num5) & (num5 <= buFoamCalc.LengthFeedList[k].MaxLength)) && buFoamCalc.LengthFeedList[k].Feed > 0.0)
						{
							num4 = buFoamCalc.LengthFeedList[k].Feed;
							k = buFoamCalc.LengthFeedList.Count;
						}
					}
				}
				if (buFoamCalc.varFoamSettings.UseG1InsteadOfG0)
				{
					num3 = 1;
				}
				flag = false;
				if (i == 0)
				{
					num = clsInit.cVector5.PointAngle(clsMW.CamBuEntities[i].Vertices[1], clsMW.CamBuEntities[i].Vertices[0]);
					if (buFoamCalc.varFoamSettings.NonLinearCAxis)
					{
						if (num < 90.0)
						{
							num += 360.0;
						}
					}
					else if (num > 180.0)
					{
						num -= 360.0;
					}
					tpPnt9D = new TpPnt9D(new Pnt6D(clsMW.CamBuEntities[i].Vertices[0].X, clsMW.CamBuEntities[i].Vertices[0].Y, clsMW.CamBuEntities[i].Vertices[0].Z, 0.0, 0.0, num), connectionFeed, num3);
					camTpPoint2.Points.Add(tpPnt9D);
					pntLast = buVector5.ToPoint3D(clsMW.CamBuEntities[i].Vertices[0]);
					LastAng = num;
				}
				if (!((clsMW.CamBuEntities[i].typeDefination == entityTypeDefination.Upper) | (clsMW.CamBuEntities[i].typeDefination == entityTypeDefination.Connection) | (clsMW.CamBuEntities[i].typeDefination == entityTypeDefination.CamLeadin) | (clsMW.CamBuEntities[i].typeDefination == entityTypeDefination.CamLeadOut)))
				{
					new List<TpPnt9D>();
					if (buFoamCalc.varFoamSettings.ContiniousTangent)
					{
						for (int l = 1; l <= clsMW.CamBuEntities[i].Vertices.Count - 1; l++)
						{
							num = clsInit.cVector5.PointAngle(clsMW.CamBuEntities[i].Vertices[l], pntLast);
							num2 = LastAng - num;
							double num6 = 0.0;
							num6 = ((num2 < 0.0) ? buNumeric5.RoundToUpper(num2 / 360.0) : buNumeric5.RoundToLower(num2 / 360.0));
							num += num6 * 360.0;
							num2 = LastAng - num;
							if (!(num6 > 0.0))
							{
							}
							if (num2 > 180.0)
							{
								num += 360.0;
							}
							if (num2 < -180.0)
							{
								num -= 360.0;
							}
							num2 = LastAng - num;
							if (Math.Abs(num2) > 20.0)
							{
								int type = num3;
								if (buFoamCalc.varFoamSettings.UseCRotationAsG0Always)
								{
									type = 0;
								}
								tpPnt9D = new TpPnt9D(new Pnt6D(pntLast.X, pntLast.Y, pntLast.Z, 0.0, 0.0, num), cRotationFeed, type);
								camTpPoint2.Points.Add(tpPnt9D);
							}
							tpPnt9D = new TpPnt9D(new Pnt6D(clsMW.CamBuEntities[i].Vertices[l].X, clsMW.CamBuEntities[i].Vertices[l].Y, clsMW.CamBuEntities[i].Vertices[l].Z, 0.0, 0.0, num), num4, 1);
							tpPnt9D.IsMark = false;
							camTpPoint2.Points.Add(tpPnt9D);
							pntLast = buVector5.ToPoint3D(clsMW.CamBuEntities[i].Vertices[l]);
							LastAng = num;
						}
					}
					else
					{
						NoneContinousResult Result = new NoneContinousResult();
						calcNoneContinous(clsMW.CamBuEntities[i], ref pntLast, ref LastAng, num3, cRotationFeed, num4, ref camTpPoint2.Points, ref Result);
					}
					continue;
				}
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				NoneContinousResult Result2 = new NoneContinousResult();
				List<buEntity> list = new List<buEntity>();
				List<buEntity> list2 = new List<buEntity>();
				if (i < clsMW.CamBuEntities.Count - 1 && ((clsMW.CamBuEntities[i + 1].typeDefination == entityTypeDefination.None) | (clsMW.CamBuEntities[i + 1].typeDefination == entityTypeDefination.Cutting)))
				{
					Point3D basePoint = clsMW.CamBuEntities[i + 1].Vertices[0];
					Point3D tipPoint = clsMW.CamBuEntities[i + 1].Vertices[1];
					clsInit.cVector5.PointAngle(tipPoint, basePoint);
					list.Add(buEntity.Copy(clsMW.CamBuEntities[i]));
					for (int m = i + 1; m <= clsMW.CamBuEntities.Count - 1; m++)
					{
						if (!((clsMW.CamBuEntities[m].typeDefination == entityTypeDefination.Upper) | (clsMW.CamBuEntities[m].typeDefination == entityTypeDefination.CamLeadin) | (clsMW.CamBuEntities[m].typeDefination == entityTypeDefination.CamLeadOut)))
						{
							list.Add(buEntity.Copy(clsMW.CamBuEntities[m]));
							list2.Add(buEntity.Copy(clsMW.CamBuEntities[m]));
							continue;
						}
						Point3D basePoint2 = clsMW.CamBuEntities[m - 1].Vertices[clsMW.CamBuEntities[m - 1].Vertices.Count - 2];
						Point3D tipPoint2 = clsMW.CamBuEntities[m - 1].Vertices[clsMW.CamBuEntities[m - 1].Vertices.Count - 1];
						clsInit.cVector5.PointAngle(tipPoint2, basePoint2);
						m = clsMW.CamBuEntities.Count;
					}
					if (list2.Count > 0)
					{
						List<TpPnt9D> P9List = new List<TpPnt9D>();
						Point3D pntLast2 = new Point3D(pntLast.X, pntLast.Y, pntLast.Z);
						double LastAng2 = LastAng;
						for (int n = 0; n <= list2.Count - 1; n++)
						{
							calcNoneContinous(list2[n], ref pntLast2, ref LastAng2, num3, cRotationFeed, num4, ref P9List, ref Result2);
						}
					}
				}
				if (Result2.OutLimitMinAngle < 0.0)
				{
					flag2 = true;
				}
				if (Result2.OutLimitMaxAngle > 0.0)
				{
					flag3 = true;
				}
				for (int num7 = 1; num7 <= clsMW.CamBuEntities[i].Vertices.Count - 1; num7++)
				{
					flag4 = false;
					flag5 = false;
					num = clsInit.cVector5.PointAngle(clsMW.CamBuEntities[i].Vertices[num7], pntLast);
					if (!(flag2 && !flag3))
					{
						if (!(flag3 && !flag2))
						{
							double num8 = 0.0;
							num2 = num - LastAng;
							if (buFoamCalc.varFoamSettings.ContiniousTangent)
							{
								num8 = ((num2 < 0.0) ? (0.0 - buNumeric5.RoundToUpper(num2 / 360.0)) : (0.0 - buNumeric5.RoundToLower(num2 / 360.0)));
								num += num8 * 360.0;
							}
							num2 = num - LastAng;
							if (num2 > 180.0)
							{
								num -= 360.0;
							}
							if (num2 < -180.0)
							{
								num += 360.0;
							}
							num2 = num - LastAng;
						}
						else if (num - Result2.MinAngle - 360.0 > buFoamCalc.varFoamSettings.TangentMinAngle)
						{
							num -= 360.0;
						}
					}
					else if (num + Result2.MaxAngle + 360.0 < buFoamCalc.varFoamSettings.TangentMaxAngle)
					{
						num += 360.0;
					}
					if (flag && flag6)
					{
						if (clockDirectionType == ClockDirectionType.CW && num < -10.0)
						{
							num += 360.0;
						}
						if (clockDirectionType == ClockDirectionType.CCW && num > 70.0)
						{
							num -= 360.0;
						}
					}
					if (!buFoamCalc.varFoamSettings.ContiniousTangent)
					{
						if (num > buFoamCalc.varFoamSettings.TangentMaxAngle)
						{
							num -= 360.0;
							flag4 = true;
						}
						if (num < buFoamCalc.varFoamSettings.TangentMinAngle)
						{
							num += 360.0;
							flag4 = true;
						}
					}
					num2 = num - LastAng;
					if (Math.Abs(num2) > 180.0)
					{
						flag5 = true;
					}
					if (Math.Abs(num2) > buFoamCalc.varFoamSettings.AngleLimitOnlyCRotation)
					{
						if (camTpPoint2.Points.Count > 0)
						{
							double num9 = Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.C - tpPnt9D.P9.C);
							if (!(num9 > 180.0))
							{
							}
						}
						Point3D point3D = new Point3D(pntLast.X, pntLast.Y, pntLast.Z);
						if (i < clsMW.CamBuEntities.Count - 1 && ((clsMW.CamBuEntities[i + 1].typeDefination == entityTypeDefination.None) | (clsMW.CamBuEntities[i + 1].typeDefination == entityTypeDefination.Cutting)))
						{
							point3D = clsInit.cVector5.MiddlePointOfLine(pntLast, clsMW.CamBuEntities[i].Vertices[num7]);
							tpPnt9D = new TpPnt9D(new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.C), camTpPoint2.Points[camTpPoint2.Points.Count - 1].Feed, camTpPoint2.Points[camTpPoint2.Points.Count - 1].Type);
							camTpPoint2.Points.Add(tpPnt9D);
						}
						int type2 = num3;
						if (buFoamCalc.varFoamSettings.UseCRotationAsG0Always)
						{
							type2 = 0;
						}
						tpPnt9D = new TpPnt9D(new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, num), cRotationFeed, type2);
						tpPnt9D.IsMark = flag4;
						tpPnt9D.IsLimit = flag5;
						camTpPoint2.Points.Add(tpPnt9D);
					}
					int type3 = num3;
					double feed = connectionFeed;
					if (clsMW.CamBuEntities[i].typeDefination == entityTypeDefination.CamLeadin)
					{
						type3 = 1;
						feed = entryFeed;
					}
					if (clsMW.CamBuEntities[i].typeDefination == entityTypeDefination.CamLeadOut)
					{
						type3 = 1;
						feed = leaveFeed;
					}
					tpPnt9D = new TpPnt9D(new Pnt6D(clsMW.CamBuEntities[i].Vertices[num7].X, clsMW.CamBuEntities[i].Vertices[num7].Y, clsMW.CamBuEntities[i].Vertices[num7].Z, 0.0, 0.0, num), feed, type3);
					tpPnt9D.IsMark = flag4;
					tpPnt9D.IsLimit = flag5;
					if (camTpPoint2.Points.Count > 0)
					{
						double num10 = Math.Abs(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.C - tpPnt9D.P9.C);
						if (!(num10 > 180.0))
						{
						}
					}
					camTpPoint2.Points.Add(tpPnt9D);
					pntLast = buVector5.ToPoint3D(clsMW.CamBuEntities[i].Vertices[num7]);
					LastAng = num;
				}
			}
			clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam.SimilationPoint.SimMove, camTpPoint2, 10.0);
			Cam.CamPoints.Add(camTpPoint2);
		}
		catch (Exception)
		{
		}
	}

	public void calcNoneContinous(buEntity refEntity, ref Point3D pntLast, ref double LastAng, int G0Type, double velRot, double velCut, ref List<TpPnt9D> P9List, ref NoneContinousResult Result)
	{
		double num = 0.0;
		TpPnt9D tpPnt9D = new TpPnt9D();
		for (int i = 1; i <= refEntity.Vertices.Count - 1; i++)
		{
			bool isMark = false;
			bool isLimit = false;
			double num2 = clsInit.cVector5.PointAngle(refEntity.Vertices[i], pntLast);
			num = num2 - LastAng;
			double num3 = buNumeric5.RoundToLower(Math.Abs(num) / 360.0);
			if (num < 0.0)
			{
				num3 *= 1.0;
			}
			if (num > 0.0)
			{
				num3 *= -1.0;
			}
			if (num3 < 0.0 || num3 > 0.0)
			{
				num2 += 360.0 * num3;
				num = num2 - LastAng;
			}
			if (num > 180.0)
			{
				num2 -= 360.0;
			}
			if (num < -180.0)
			{
				num2 += 360.0;
			}
			if (num2 > buFoamCalc.varFoamSettings.TangentMaxAngle)
			{
				Result.OutLimitMaxAngle = num2;
				num2 -= 360.0;
				isMark = true;
			}
			if (num2 < buFoamCalc.varFoamSettings.TangentMinAngle)
			{
				Result.OutLimitMinAngle = num2;
				num2 += 360.0;
				isMark = true;
			}
			num = num2 - LastAng;
			if (Math.Abs(num) > 180.0)
			{
				isLimit = true;
			}
			if (num2 > Result.MaxAngle)
			{
				Result.MaxAngle = num2;
			}
			if (num2 < Result.MinAngle)
			{
				Result.MinAngle = num2;
			}
			if (Math.Abs(num) > 20.0)
			{
				int type = G0Type;
				if (buFoamCalc.varFoamSettings.UseCRotationAsG0Always)
				{
					type = 0;
				}
				tpPnt9D = new TpPnt9D(new Pnt6D(pntLast.X, pntLast.Y, pntLast.Z, 0.0, 0.0, num2), velRot, type);
				tpPnt9D.IsMark = isMark;
				tpPnt9D.IsLimit = isLimit;
				if (P9List.Count > 0)
				{
					double num4 = Math.Abs(P9List[P9List.Count - 1].P9.C - tpPnt9D.P9.C);
					if (!(num4 > 180.0))
					{
					}
				}
				P9List.Add(tpPnt9D);
			}
			tpPnt9D = new TpPnt9D(new Pnt6D(refEntity.Vertices[i].X, refEntity.Vertices[i].Y, refEntity.Vertices[i].Z, 0.0, 0.0, num2), velCut, 1);
			if (P9List.Count > 0)
			{
				double num5 = Math.Abs(P9List[P9List.Count - 1].P9.C - tpPnt9D.P9.C);
				if (!(num5 > 180.0))
				{
				}
			}
			P9List.Add(tpPnt9D);
			pntLast = buVector5.ToPoint3D(refEntity.Vertices[i]);
			LastAng = num2;
		}
	}

	public void cmdCamContour1(ref camTp Cam)
	{
	}

	public void CreateGCodeAES(ref List<camTp> CamList, ref PostProcessor P)
	{
		new SortbuSettings();
		new SortbuResult();
		new List<buEntity>();
		buMWFoamVars.varCamFoam.buPar.Strategy.MaxTangentValue = buFoamCalc.varFoamSettings.TangentMaxAngle;
		buMWFoamVars.varCamFoam.buPar.Strategy.MinTangentValue = buFoamCalc.varFoamSettings.TangentMinAngle;
		buMWFoamVars.varCamFoam.buPar.Strategy.AngleLimit = 20.0;
		buMWFoamVars.varCamFoam.buPar.Speeds.Feed = buFoamCalc.varFoamSettings.CuttingFeed;
		if (activeFoam.sortedEntitiesXZ.Count > 0)
		{
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			clsMW.CamBuEntities.Clear();
			clsMW.CamBuEntities = new List<buEntity>();
			if (activeFoam.sortedEntitiesXZ.Count > 0)
			{
				for (int i = 0; i <= activeFoam.sortedEntitiesXZ.Count - 1; i++)
				{
					List<Point3D> Points = new List<Point3D>();
					List<Point3D> CalcPoint = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(activeFoam.sortedEntitiesXZ[i], buFoamCalc.varFoamSettings.RegenDeviation, ref Points);
					if (buFoamCalc.varFoamSettings.MaxDevideLen > 0.0)
					{
						clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref Points);
					}
					clsInit.cVector5.PointConversionByPlane(Plane.XZ, Plane.XY, Points, ref CalcPoint);
					buLinearPath buLinearPath2 = new buLinearPath(CalcPoint);
					buLinearPath2.typeDefination = activeFoam.sortedEntitiesXZ[i].typeDefination;
					clsMW.CamBuEntities.Add(buLinearPath2);
				}
			}
			activeFoam.CamXZ = new camTp();
			if ((clsMW.CamBuEntities.Count > 0) | (clsMW.CamEntities.Count > 0))
			{
				cmdCamContour(ref activeFoam.CamXZ);
				for (int j = 0; j <= activeFoam.CamXZ.CamPoints[0].Points.Count - 1; j++)
				{
					if (activeFoam.CamXZ.CamPoints[0].Points[j].Feed == buFoamCalc.varFoamSettings.CuttingFeed)
					{
						activeFoam.CamXZ.CamPoints[0].Points[j].Feed = buFoamCalc.varFoamSettings.EntryFeed;
						break;
					}
				}
				int num = activeFoam.CamXZ.CamPoints[0].Points.Count - 1;
				while (num >= 0)
				{
					if (activeFoam.CamXZ.CamPoints[0].Points[num].Feed != buFoamCalc.varFoamSettings.CuttingFeed)
					{
						num--;
						continue;
					}
					activeFoam.CamXZ.CamPoints[0].Points[num].Feed = buFoamCalc.varFoamSettings.LeaveFeed;
					break;
				}
				if (activeFoam.CamXZ.CamPoints.Count > 0)
				{
					activeFoam.CamXZ.CamPoints[0].PreCodes.Add("L TABLA0");
				}
			}
		}
		if (activeFoam.sortedEntitiesYZ.Count > 0)
		{
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			clsMW.CamBuEntities.Clear();
			clsMW.CamBuEntities = new List<buEntity>();
			if (activeFoam.sortedEntitiesYZ.Count > 0)
			{
				for (int k = 0; k <= activeFoam.sortedEntitiesYZ.Count - 1; k++)
				{
					List<Point3D> Points2 = new List<Point3D>();
					List<Point3D> CalcPoint2 = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(activeFoam.sortedEntitiesYZ[k], buFoamCalc.varFoamSettings.RegenDeviation, ref Points2);
					if (buFoamCalc.varFoamSettings.MaxDevideLen > 0.0)
					{
						clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref Points2);
					}
					clsInit.cVector5.PointConversionByPlane(Plane.YZ, Plane.XY, Points2, ref CalcPoint2);
					buLinearPath buLinearPath3 = new buLinearPath(CalcPoint2);
					buLinearPath3.typeDefination = activeFoam.sortedEntitiesXZ[k].typeDefination;
					clsMW.CamBuEntities.Add(buLinearPath3);
				}
			}
			activeFoam.CamYZ = new camTp();
			if (clsMW.CamEntities.Count > 0)
			{
				cmdCamContour(ref activeFoam.CamYZ);
				if (activeFoam.CamYZ.CamPoints.Count > 0)
				{
					activeFoam.CamYZ.CamPoints[0].PreCodes.Add("L TABLA90");
				}
			}
		}
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
		activeFoam.isGCodeCreated = true;
		P = new PostProcessor(ccVars.PostActive);
		P.StartLines.Add("R4000=" + activeFoam.Material.Size.Width.ToString("f2"));
		P.StartLines.Add("R4001=" + activeFoam.Material.Size.Depth.ToString("f2"));
		P.StartLines.Add("L GINIPRO.ISC");
		P.StartLines.Add("G305 OFF");
		CamList = new List<camTp>();
		if (activeFoam.CamYZ.CamPoints.Count > 0)
		{
			CamList.Add(new camTp(activeFoam.CamYZ));
		}
		if (activeFoam.CamXZ.CamPoints.Count > 0)
		{
			CamList.Add(new camTp(activeFoam.CamXZ));
		}
		if (CamList.Count > 0)
		{
			for (int l = 0; l <= CamList.Count - 1; l++)
			{
				CamList[l].EntitiesG1.Clear();
				CamList[l].EntitiesG0.Clear();
				CamList[l].EntitiesLeave.Clear();
				CamList[l].EntitiesPlunge.Clear();
			}
		}
	}

	public void CreateGCodeCMD(ref List<camTp> CamList, ref PostProcessor P)
	{
		new SortbuSettings();
		new SortbuResult();
		new List<buEntity>();
		buMWFoamVars.varCamFoam.buPar.Strategy.MaxTangentValue = buFoamCalc.varFoamSettings.TangentMaxAngle;
		buMWFoamVars.varCamFoam.buPar.Strategy.MinTangentValue = buFoamCalc.varFoamSettings.TangentMinAngle;
		buMWFoamVars.varCamFoam.buPar.Strategy.AngleLimit = 20.0;
		clsMW.CamEntities.Clear();
		clsMW.CamBuEntities.Clear();
		activeFoam.CamXZ = new camTp();
		if (activeFoam.sortedEntitiesXZ.Count > 0)
		{
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			clsMW.CamBuEntities.Clear();
			clsMW.CamBuEntities = new List<buEntity>();
			if (activeFoam.sortedEntitiesXZ.Count > 0)
			{
				for (int i = 0; i <= activeFoam.sortedEntitiesXZ.Count - 1; i++)
				{
					List<Point3D> Points = new List<Point3D>();
					List<Point3D> CalcPoint = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(activeFoam.sortedEntitiesXZ[i], buFoamCalc.varFoamSettings.RegenDeviation, ref Points);
					if ((buFoamCalc.varFoamSettings.MaxDevideLen > 0.0) & (activeFoam.sortedEntitiesXZ[i] is buLine))
					{
						clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref Points);
					}
					clsInit.cVector5.PointConversionByPlane(Plane.XZ, Plane.XY, Points, ref CalcPoint);
					buLinearPath buLinearPath2 = new buLinearPath(CalcPoint);
					clsInit.cVector5.EntityToOriginalType(activeFoam.sortedEntitiesXZ[i], ref buLinearPath2.Info.OrjType, ref buLinearPath2.Info.Radius);
					buLinearPath2.typeDefination = activeFoam.sortedEntitiesXZ[i].typeDefination;
					clsMW.CamBuEntities.Add(buLinearPath2);
				}
			}
			activeFoam.CamXZ = new camTp();
			if (clsMW.CamBuEntities.Count > 0)
			{
				cmdCamContour(ref activeFoam.CamXZ);
			}
		}
		activeFoam.CamYZ = new camTp();
		if (activeFoam.sortedEntitiesYZ.Count > 0)
		{
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			clsMW.CamBuEntities.Clear();
			clsMW.CamBuEntities = new List<buEntity>();
			if (activeFoam.sortedEntitiesYZ.Count > 0)
			{
				for (int j = 0; j <= activeFoam.sortedEntitiesYZ.Count - 1; j++)
				{
					List<Point3D> Points2 = new List<Point3D>();
					List<Point3D> CalcPoint2 = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(activeFoam.sortedEntitiesYZ[j], buFoamCalc.varFoamSettings.RegenDeviation, ref Points2);
					if ((buFoamCalc.varFoamSettings.MaxDevideLen > 0.0) & (activeFoam.sortedEntitiesYZ[j] is buLine))
					{
						clsInit.cVector5.PointFilterByLengthCornerPoint(buFoamCalc.varFoamSettings.MaxDevideLen, ref Points2);
					}
					clsInit.cVector5.PointConversionByPlane(Plane.YZ, Plane.XY, Points2, ref CalcPoint2);
					buLinearPath buLinearPath3 = new buLinearPath(CalcPoint2);
					buLinearPath3.typeDefination = activeFoam.sortedEntitiesYZ[j].typeDefination;
					clsMW.CamBuEntities.Add(buLinearPath3);
				}
			}
			activeFoam.CamYZ = new camTp();
			if (clsMW.CamBuEntities.Count > 0)
			{
				cmdCamContour(ref activeFoam.CamYZ);
				if (activeFoam.CamYZ.CamPoints.Count <= 0)
				{
				}
			}
		}
		CreatePanelFromJob(ref activeFoam, new FoamCreatePanelOptions(drawall: false, deletesort: true, deletetool: true, drawpreview: false));
		activeFoam.isGCodeCreated = true;
		P = new PostProcessor(ccVars.PostActive);
		CamList = new List<camTp>();
		if (activeFoam.CamXZ.CamPoints.Count > 0)
		{
			if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
			{
				activeFoam.CamXZ.PreCodesWithoutNo.Add("<GCodesMain>");
			}
			for (int k = 0; k <= P.StartLines.Count - 1; k++)
			{
				activeFoam.CamXZ.PreCodes.Add(P.StartLines[k]);
			}
			for (int l = 0; l <= P.EndLines.Count - 1; l++)
			{
				activeFoam.CamXZ.AfterCodes.Add(P.EndLines[l]);
			}
			if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
			{
				activeFoam.CamXZ.AfterCodesWithoutNo.Add("</GCodesMain>");
			}
			CamList.Add(new camTp(activeFoam.CamXZ));
		}
		if (activeFoam.CamYZ.CamPoints.Count > 0)
		{
			if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
			{
				activeFoam.CamYZ.PreCodesWithoutNo.Add("<GCodesSide>");
			}
			for (int m = 0; m <= P.StartLines.Count - 1; m++)
			{
				activeFoam.CamYZ.PreCodes.Add(P.StartLines[m]);
			}
			for (int n = 0; n <= P.EndLines.Count - 1; n++)
			{
				activeFoam.CamYZ.AfterCodes.Add(P.EndLines[n]);
			}
			if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
			{
				activeFoam.CamYZ.AfterCodesWithoutNo.Add("</GCodesSide>");
			}
			CamList.Add(new camTp(activeFoam.CamYZ));
		}
		P.StartLines.Clear();
		P.EndLines.Clear();
		P.StartLinesWithoutProcess.Clear();
		P.EndLinesWithoutProcess.Clear();
		if (buFoamCalc.varFoamSettings.ShowInfoAtGCodes)
		{
			P.StartLinesWithoutProcess.Add("<Info>");
			P.StartLinesWithoutProcess.Add(activeFoam.Material.Size.Width + " ; " + activeFoam.Material.Size.Height + " ; " + activeFoam.Material.Size.Depth);
			P.StartLinesWithoutProcess.Add("</Info>");
		}
	}
}
