using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.CamForms;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5;

public class clsMW
{
	public static GeoLib varMWCamMeshRoughPars = null;

	public static camParameters5 varbuCamMeshRoughPars = null;

	public static GeoLib varMWCamMeshParalelPars = null;

	public static camParameters5 varbuCamMeshParallelPars = null;

	public static GeoLib varMWCamMeshContantZPars = null;

	public static camParameters5 varbuCamMeshConstantZPars = null;

	public static GeoLib varMWCamMeshPencilPars = null;

	public static camParameters5 varbuCamMeshPencilPars = null;

	public static GeoLib varMWCamMeshProjectionPars = null;

	public static camParameters5 varbuCamMeshProjectionPars = null;

	public static GeoLib varMWCamMeshFlatlandPars = null;

	public static camParameters5 varbuCamMeshFlatlandsPars = null;

	public static GeoLib varMWCamMeshContantCuspPars = null;

	public static camParameters5 varbuCamMeshConstantCuspPars = null;

	public static GeoLib varMWCamMeshRough5AXPars = null;

	public static camParameters5 varbuCamMeshRough5AXPars = null;

	public static GeoLib varMWCamMeshParalel5AXPars = null;

	public static camParameters5 varbuCamMeshParallel5AXPars = null;

	public static GeoLib varMWCamMeshContantZ5AXPars = null;

	public static camParameters5 varbuCamMeshConstantZ5AXPars = null;

	public static GeoLib varMWCamWFPocketPars = null;

	public static camParameters5 varbuCamWFPocketPars = null;

	public static GeoLib varMWCamWFContourPars = null;

	public static camParameters5 varbuCamWFContourPars = null;

	public static GeoLib varMWCamWFProfile3AxisPars = null;

	public static camParameters5 varbuCamWFProfile3AxisPars = null;

	public static GeoLib varMWCamDrillPars = null;

	public static camParameters5 varbuCamDrillPars = null;

	public static GeoLib varMWCamWFFacePars = null;

	public static camParameters5 varbuCamWFFacePars = null;

	public static GeoLib varMWCamSurfaceParallelPars = null;

	public static camParameters5 varbuCamSurfaceParallelPars = null;

	public static GeoLib varMWCamGeodesicPars = null;

	public static camParameters5 varbuCamGeodesicPars = null;

	public static GeoLib varMWCamContourPars = null;

	public static camParameters5 varbuCamContourPars = null;

	public static List<Entity> CamEntities = new List<Entity>();

	public static List<Entity> Containment2DEntities = new List<Entity>();

	public static List<Entity> StockEntities = new List<Entity>();

	public static List<List<Entity>> CamEntitiesGroup = new List<List<Entity>>();

	public static List<buEntity> CamBuEntities = new List<buEntity>();

	public void Init()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		varMWCamMeshRoughPars = new GeoLib(Unit.Metric);
		varbuCamMeshRoughPars = new camParameters5();
		varMWCamMeshParalelPars = new GeoLib(Unit.Metric);
		varbuCamMeshParallelPars = new camParameters5();
		varMWCamMeshContantZPars = new GeoLib(Unit.Metric);
		varbuCamMeshConstantZPars = new camParameters5();
		varMWCamMeshPencilPars = new GeoLib(Unit.Metric);
		varbuCamMeshPencilPars = new camParameters5();
		varMWCamMeshProjectionPars = new GeoLib(Unit.Metric);
		varbuCamMeshProjectionPars = new camParameters5();
		varMWCamMeshFlatlandPars = new GeoLib(Unit.Metric);
		varbuCamMeshFlatlandsPars = new camParameters5();
		varMWCamMeshContantCuspPars = new GeoLib(Unit.Metric);
		varbuCamMeshConstantCuspPars = new camParameters5();
		varMWCamMeshParalel5AXPars = new GeoLib(Unit.Metric);
		varbuCamMeshParallel5AXPars = new camParameters5();
		varMWCamMeshContantZ5AXPars = new GeoLib(Unit.Metric);
		varbuCamMeshConstantZ5AXPars = new camParameters5();
		varMWCamMeshRough5AXPars = new GeoLib(Unit.Metric);
		varbuCamMeshRough5AXPars = new camParameters5();
		varMWCamWFPocketPars = new GeoLib(Unit.Metric);
		varbuCamWFPocketPars = new camParameters5();
		varMWCamWFContourPars = new GeoLib(Unit.Metric);
		varbuCamWFContourPars = new camParameters5();
		varMWCamWFProfile3AxisPars = new GeoLib(Unit.Metric);
		varbuCamWFProfile3AxisPars = new camParameters5();
		varMWCamDrillPars = new GeoLib(Unit.Metric);
		varbuCamDrillPars = new camParameters5();
		varMWCamGeodesicPars = new GeoLib(Unit.Metric);
		varbuCamGeodesicPars = new camParameters5();
		varMWCamSurfaceParallelPars = new GeoLib(Unit.Metric);
		varbuCamSurfaceParallelPars = new camParameters5();
		varMWCamContourPars = new GeoLib(Unit.Metric);
		varbuCamContourPars = new camParameters5();
		clsVar.varCamMeshRoughPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamMeshParallelPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamMeshConstantZPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamMeshPencilPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamMeshProjectionPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamMeshFlatlandsPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamMeshConstantCuspPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamWFPocketPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamWFContourPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamWFContour4XPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamDrillPars = new MWParameters(Unit.Metric, 0);
		clsVar.varCamDrill4XPars = new MWParameters(Unit.Metric, 0);
		clsInit.cMwCalc.GetCalculations += GetCalculationFromMWCore;
		clsInit.cMwCalc.CalculationInProgressMwCalc += clsInit.appCommand.CalculationInProgressCmd;
	}

	public void GetCalculationFromMWCore(MWCalculationResult Result, MWCalculationResultEventArg e)
	{
		try
		{
			if (!e.CalculationSuccess)
			{
				clsInit.appCommand.Reset(ClearSelection: true, ReDraw: true);
				return;
			}
			clsFiles.SaveParameter();
			if (buSystem.Canceled)
			{
			}
			clsInit.appCommand.Reset(ClearSelection: true, ReDraw: true);
		}
		catch (Exception)
		{
		}
	}

	public int doWireframeContour(MWCalculationOptions MWCalcOptions, ToolBase5 ToolSelected, ref camTp Cam, ref camResult Result)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Expected O, but got Unknown
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Expected O, but got Unknown
		//IL_09bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c7: Expected O, but got Unknown
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Expected O, but got Unknown
		//IL_0e50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5a: Expected O, but got Unknown
		//IL_0e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7a: Expected O, but got Unknown
		//IL_0b3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b49: Expected O, but got Unknown
		//IL_0b5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b69: Expected O, but got Unknown
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a95: Expected O, but got Unknown
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab5: Expected O, but got Unknown
		//IL_0d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d86: Expected O, but got Unknown
		//IL_0f1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f24: Expected O, but got Unknown
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Expected O, but got Unknown
		//IL_0c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca4: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_15d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15df: Expected O, but got Unknown
		//IL_1721: Unknown result type (might be due to invalid IL or missing references)
		//IL_172b: Expected O, but got Unknown
		//IL_1420: Unknown result type (might be due to invalid IL or missing references)
		//IL_142a: Expected O, but got Unknown
		//IL_16dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e6: Expected O, but got Unknown
		//IL_162d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1637: Expected O, but got Unknown
		//IL_1571: Unknown result type (might be due to invalid IL or missing references)
		//IL_157b: Expected O, but got Unknown
		ToolBase5 Tool = new ToolBase5(ToolSelected);
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		MWCalculationResult mWCalculationResult = new MWCalculationResult();
		bool flag = false;
		bool flag2 = false;
		WireframeBasedTpCalcParamsPattern calcType = WireframeBasedTpCalcParamsPattern.Wfb2axisProfile;
		List<List<Entity>> copiedEnt = new List<List<Entity>>();
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> SortedEntities = new List<Entity>();
		List<buMWCurveEntities> list = new List<buMWCurveEntities>();
		new List<Curve>();
		buMWCurveEntities buMWCurveEntities2 = new buMWCurveEntities();
		SortSettings sortSettings = new SortSettings(MWCalcOptions.SortingSettings);
		SortResult Result2 = new SortResult();
		Cam = new camTp();
		Result = new camResult();
		if (Tool.Purpose != ToolPurpose.Drilling)
		{
			if (MWCalcOptions.CamWireframeType == CamWireFrameType.Contour || Tool.Purpose != ToolPurpose.Saw)
			{
				if (MWCalcOptions.UseSortedAndSplitedEntities & (CamEntitiesGroup.Count > 0))
				{
					flag2 = true;
					buVector5.CopyEntities(CamEntitiesGroup, ref copiedEnt);
				}
				SelectionOption selectionOption = new SelectionOption();
				selectionOption.CircleToArc = true;
				selectionOption.CircleTo4Arc = true;
				selectionOption.SplitArcIfGreatThen180 = true;
				selectionOption.Point = false;
				if (!flag2)
				{
					if (CamEntities.Count != 0)
					{
						for (int i = 0; i <= CamEntities.Count - 1; i++)
						{
							if (!(CamEntities[i].GetType() == typeof(Circle)))
							{
								Entity copiedEnt2 = null;
								buVector5.CopyEntities(CamEntities[i], ref copiedEnt2);
								selectedEntities.Add(copiedEnt2);
								continue;
							}
							Entity copiedEnt3 = null;
							buVector5.CopyEntities(CamEntities[i], ref copiedEnt3);
							Entity Arc = null;
							Entity Arc2 = null;
							Entity Arc3 = null;
							Entity Arc4 = null;
							clsInit.cVector5.CircletoFourArc((Circle)copiedEnt3, ref Arc, ref Arc2, ref Arc3, ref Arc4);
							selectedEntities.Add(Arc);
							selectedEntities.Add(Arc2);
							selectedEntities.Add(Arc3);
							selectedEntities.Add(Arc4);
						}
						clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
					}
					else
					{
						clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
						clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
						if (ccVars.entityEdges != null && ccVars.entityEdges.Count > 0)
						{
							selectedEntities.Clear();
							buVector5.CopyEntities(ccVars.entityEdges[0], ref selectedEntities);
						}
					}
					Result.UsedEntities.Clear();
					buEntity.Copy(selectedEntities, ref Result.UsedEntities);
					if (MWCalcOptions.DevideData.DevideEnable)
					{
						List<Entity> devideEntities = new List<Entity>();
						clsInit.cVector5.EntitiesDevideByLengthAsPolyline(selectedEntities, MWCalcOptions.DevideData, ref devideEntities);
						selectedEntities.Clear();
						buVector5.CopyEntities(devideEntities, ref selectedEntities);
					}
					if (ccVars.SelectionOP.ClickList.Count <= 0)
					{
						if (selectedEntities.Count > 0)
						{
							clsInit.cVector5.SortEntitiesByRefPoint(((ICurve)selectedEntities[0]).StartPoint, ref selectedEntities, sortSettings, ref SortedEntities, ref Result2);
						}
					}
					else
					{
						sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
						clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref selectedEntities, sortSettings, ref SortedEntities, ref Result2);
					}
					clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref copiedEnt);
				}
				if (clsInit.cMwCalc.mwCamDataParameter != null)
				{
					clsInit.cMwCalc.mwCamDataParameter.Dispose();
				}
				clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
				if (!((MWCalcOptions.CamWireframeType == CamWireFrameType.Contour) | (MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)))
				{
					if (MWCalcOptions.CamWireframeType != CamWireFrameType.Pocket)
					{
						if (MWCalcOptions.CamWireframeType != CamWireFrameType.Profile3Axis)
						{
							if (MWCalcOptions.CamWireframeType == CamWireFrameType.Face)
							{
								buMWCalcs.CopyGeoLibProperties(varMWCamWFFacePars, clsInit.cMwCalc.mwCamDataParameter);
								clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamWFFacePars.MachParam);
								clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamWFFacePars);
								calcType = WireframeBasedTpCalcParamsPattern.WfbFace;
							}
						}
						else
						{
							buMWCalcs.CopyGeoLibProperties(varMWCamWFProfile3AxisPars, clsInit.cMwCalc.mwCamDataParameter);
							clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamWFProfile3AxisPars.MachParam);
							clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamWFProfile3AxisPars);
							calcType = WireframeBasedTpCalcParamsPattern.Wfb3axisProfile;
						}
					}
					else
					{
						buMWCalcs.CopyGeoLibProperties(varMWCamWFPocketPars, clsInit.cMwCalc.mwCamDataParameter);
						clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamWFPocketPars.MachParam);
						clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamWFPocketPars);
						calcType = WireframeBasedTpCalcParamsPattern.Wfb2axisRough;
					}
				}
				else
				{
					buMWCalcs.CopyGeoLibProperties(varMWCamWFContourPars, clsInit.cMwCalc.mwCamDataParameter);
					clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamWFContourPars.MachParam);
					clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamWFContourPars);
					calcType = WireframeBasedTpCalcParamsPattern.Wfb2axisProfile;
				}
				clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.AllowDriveCurvesSelfIntersectionsFlg = MWCalcOptions.AllowIntercetionCurve;
				if (MWCalcOptions.NumberofAxis == 4)
				{
					clsInit.cMwCalc.buCamDataParameter.Strategy.ArcToPoints = true;
				}
				if (MWCalcOptions.ToolDataToCamData)
				{
					ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
				}
				clsInit.cVector5.BoxSizeCalculate(copiedEnt, ref MinPoint, ref MidPoint, ref MaxPoint);
				if (MWCalcOptions.CheckBoxBounding)
				{
					if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
					{
						if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
						{
							if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
							{
								CalculationError item = new CalculationError(AppLanguage.CadCamError[1], 0);
								Result.Errors.Add(item);
							}
							if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
							{
								CalculationError item2 = new CalculationError(AppLanguage.CadCamError[0], 0);
								Result.Errors.Add(item2);
							}
						}
						if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
						{
							if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
							{
								CalculationError item3 = new CalculationError(AppLanguage.CadCamError[3], 0);
								Result.Errors.Add(item3);
							}
							if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
							{
								CalculationError item4 = new CalculationError(AppLanguage.CadCamError[2], 0);
								Result.Errors.Add(item4);
							}
						}
						if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
						{
							if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
							{
								CalculationError item5 = new CalculationError(AppLanguage.CadCamError[5], 0);
								Result.Errors.Add(item5);
							}
							if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
							{
								CalculationError item6 = new CalculationError(AppLanguage.CadCamError[4], 0);
								Result.Errors.Add(item6);
							}
						}
					}
					if (Result.Errors.Count > 0)
					{
						return -1;
					}
				}
				if (MWCalcOptions.HeightFromEntities && clsInit.cMwCalc.buCamDataParameter != null)
				{
					clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
				}
				if (MWCalcOptions.WireframeRoughtStepOverParaelelOverride > 0.0)
				{
					clsInit.cMwCalc.mwCamDataParameter.MachParam.MaxStepoverDistance = MWCalcOptions.WireframeRoughtStepOverParaelelOverride;
				}
				if (!MWCalcOptions.DontShowDialogBox)
				{
					if (!((MWCalcOptions.CamWireframeType == CamWireFrameType.Contour) | (MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)))
					{
						if (MWCalcOptions.CamWireframeType != CamWireFrameType.Pocket)
						{
							return -1;
						}
						F_WFRough f_WFRough = new F_WFRough();
						f_WFRough.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
						f_WFRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_WFRough.mwCamParameter);
						f_WFRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
						f_WFRough.Configration = new MWCalculationOptions(MWCalcOptions);
						f_WFRough.Tool = new ToolBase5(Tool);
						f_WFRough.Init();
						f_WFRough.ShowDialog();
						if (f_WFRough.PropertiesForm.Result != DialogResult.OK)
						{
							return -1;
						}
						Tool.CamData.SpindleSpeed = f_WFRough.buCamParameter.Speeds.SpindleSpeed;
						clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_WFRough.mwCamParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(f_WFRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
						clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_WFRough.buCamParameter);
					}
					else
					{
						if (MWCalcOptions.NumberofAxis != 4)
						{
							F_WFContour f_WFContour = new F_WFContour();
							f_WFContour.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
							f_WFContour.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_WFContour.mwCamParameter);
							f_WFContour.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
							f_WFContour.Text = "Contour Cut";
							f_WFContour.Configration = new MWCalculationOptions(MWCalcOptions);
							f_WFContour.Tool = new ToolBase5(Tool);
							f_WFContour.Init();
							f_WFContour.ShowDialog();
							if (f_WFContour.PropertiesForm.Result != DialogResult.OK)
							{
								return -1;
							}
							Tool.CamData.SpindleSpeed = f_WFContour.buCamParameter.Speeds.SpindleSpeed;
							clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_WFContour.mwCamParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(f_WFContour.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
							clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_WFContour.buCamParameter);
							if (MWCalcOptions.isSpinCalculation)
							{
								clsInit.cMwCalc.mwCamDataParameter.MachParam.StockRemain = 0.0;
								clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
								clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
								clsInit.cMwCalc.buCamDataParameter.Offsets.ClosedContour = CamClosedContourType.Center;
							}
						}
						else if (MWCalcOptions.isSpinCalculation)
						{
							F_WFSpin f_WFSpin = new F_WFSpin();
							f_WFSpin.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
							f_WFSpin.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_WFSpin.mwCamParameter);
							f_WFSpin.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
							f_WFSpin.Configration = new MWCalculationOptions(MWCalcOptions);
							f_WFSpin.Tool = new ToolBase5(Tool);
							f_WFSpin.Init();
							f_WFSpin.ShowDialog();
							if (f_WFSpin.PropertiesForm.Result != DialogResult.OK)
							{
								return -1;
							}
							Tool.CamData.SpindleSpeed = f_WFSpin.buCamParameter.Speeds.SpindleSpeed;
							clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_WFSpin.mwCamParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(f_WFSpin.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
							clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_WFSpin.buCamParameter);
							clsInit.cMwCalc.mwCamDataParameter.MachParam.StockRemain = 0.0;
							clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
							clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType = CutterRadiusCompParamsCompensationType.CtOff;
							clsInit.cMwCalc.buCamDataParameter.Offsets.ClosedContour = CamClosedContourType.Center;
						}
						else
						{
							F_WFContour4AX f_WFContour4AX = new F_WFContour4AX();
							f_WFContour4AX.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
							f_WFContour4AX.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_WFContour4AX.mwCamParameter);
							f_WFContour4AX.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
							f_WFContour4AX.Configration = new MWCalculationOptions(MWCalcOptions);
							f_WFContour4AX.Tool = new ToolBase5(Tool);
							f_WFContour4AX.Init();
							f_WFContour4AX.ShowDialog();
							if (f_WFContour4AX.PropertiesForm.Result != DialogResult.OK)
							{
								return -1;
							}
							Tool.CamData.SpindleSpeed = f_WFContour4AX.buCamParameter.Speeds.SpindleSpeed;
							clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_WFContour4AX.mwCamParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(f_WFContour4AX.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
							clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_WFContour4AX.buCamParameter);
						}
						if (clsInit.cMwCalc.buCamDataParameter.Operations.Direction == MWCalcOptions.Direction)
						{
						}
					}
				}
				CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
				bool flag3 = true;
				if (!MWCalcOptions.isBuWireframeCalculation)
				{
					if (!MWCalcOptions.isSpinCalculation)
					{
						if (MWCalcOptions.isSpinConstantCalculation)
						{
							flag3 = false;
						}
					}
					else
					{
						flag3 = false;
					}
				}
				else
				{
					if (clsInit.cMwCalc.buCamDataParameter.Operations.isClosed & (clsInit.cMwCalc.buCamDataParameter.Offsets.ClosedContour == CamClosedContourType.Center))
					{
						flag3 = false;
					}
					if (!clsInit.cMwCalc.buCamDataParameter.Operations.isClosed & (clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter))
					{
						flag3 = false;
					}
					if (clsInit.cMwCalc.mwCamDataParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtOff)
					{
						flag3 = false;
					}
				}
				bool flag4 = false;
				if (!flag3)
				{
					camParameters5 BUPar = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
					clsInit.appCommand.CamAvailableIDGet(ref BUPar.Runtime.CamID);
					buMWCalcs.ConvertFromMwCamParToBuCamPar(clsInit.cMwCalc.mwCamDataParameter, ref BUPar);
					flag = (MWCalcOptions.isSpinCalculation ? clsInit.cCam5.camSpin(copiedEnt, TangentCalculaton: true, Tool, BUPar, ref Cam) : (MWCalcOptions.isSpinCalculation ? clsInit.cCam5.camContourCenter(SortedEntities, TangentCalculaton: false, Tool, BUPar, ref Cam) : ((copiedEnt.Count <= 0) ? ((MWCalcOptions.NumberofAxis == 3) ? clsInit.cCam5.camContourCenter(SortedEntities, TangentCalculaton: false, Tool, BUPar, ref Cam) : clsInit.cCam5.camContourCenter(SortedEntities, TangentCalculaton: true, Tool, BUPar, ref Cam)) : ((MWCalcOptions.NumberofAxis == 3) ? clsInit.cCam5.camContourCenter(copiedEnt, TangentCalculaton: false, Tool, BUPar, ref Cam) : clsInit.cCam5.camContourCenter(copiedEnt, TangentCalculaton: true, Tool, BUPar, ref Cam)))));
					mWCalculationResult.buCamParamters = new camParameters5(BUPar);
					mWCalculationResult.geoLib = new GeoLib(Unit.Metric);
					mWCalculationResult.geoLib.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
					mWCalculationResult.Tool = new ToolBase5(Tool);
				}
				else
				{
					for (int j = 0; j <= copiedEnt.Count - 1; j++)
					{
						List<Entity> ChangedEntities = new List<Entity>();
						bool flag5 = clsInit.cVector5.isEntitiesClosed(copiedEnt[j]);
						ClockDirectionType clockDirectionType = clsInit.cVector5.EntitiesClockDirection(copiedEnt[j]);
						if (MWCalcOptions.CheckIsCLosedEntities)
						{
							clsInit.cMwCalc.buCamDataParameter.Operations.isClosed = flag5;
						}
						if (!flag5)
						{
							buVector5.CopyEntities(copiedEnt[j], ref ChangedEntities);
						}
						else if (clockDirectionType == clsInit.cMwCalc.buCamDataParameter.Operations.Direction)
						{
							buVector5.CopyEntities(copiedEnt[j], ref ChangedEntities);
						}
						else
						{
							clsInit.cVector5.ChangeEntitiesDirection(copiedEnt[j], ref ChangedEntities);
						}
						for (int k = 0; k <= ChangedEntities.Count - 1; k++)
						{
							entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(ChangedEntities[k]);
							if (k == 0)
							{
								if (sortDirection == entitySortDirection.Normal)
								{
									buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)ChangedEntities[k]).StartPoint.X, ((ICurve)ChangedEntities[k]).StartPoint.Y, ((ICurve)ChangedEntities[k]).StartPoint.Z);
								}
								if (sortDirection == entitySortDirection.Reverse)
								{
									buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)ChangedEntities[k]).EndPoint.X, ((ICurve)ChangedEntities[k]).EndPoint.Y, ((ICurve)ChangedEntities[k]).EndPoint.Z);
								}
								if ((list.Count < ccVars.SelectionOP.ClickList.Count - 1) & (ccVars.SelectionOP.ClickList.Count > 0) & varbuCamWFContourPars.Strategy.StartFromAnyPoint)
								{
									buMWCurveEntities2.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[list.Count].X, ccVars.SelectionOP.ClickList[list.Count].Y, ccVars.SelectionOP.ClickList[list.Count].Z);
								}
							}
							Curve mwEntity = null;
							buMWCalcs.ConvertWireEntity(ChangedEntities[k], ref mwEntity);
							buMWCurveEntities2.CurveList.Add(mwEntity);
						}
						if (buMWCurveEntities2.CurveList.Count > 0)
						{
							list.Add(buMWCurveEntities2);
							buMWCurveEntities2 = new buMWCurveEntities();
						}
					}
					if (list.Count == 0)
					{
						buString.MessageBoxError(AppLanguage.CadCamMessages[80]);
						clsInit.appCommand.Reset();
						clsItem.FrmProgress.Visible = false;
						return -1;
					}
					flag4 = false;
					if (list.Count > 1)
					{
						flag4 = true;
					}
					flag = clsInit.cMwCalc.CalculateWireframe(Tool, list, calcType, MWCalcOptions, ref mWCalculationResult);
				}
				if (!flag)
				{
					return -1;
				}
				ccVars.UndoDont = true;
				clsInit.appCommand.undoBuffer();
				int AvailableCamID = 0;
				clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
				if (!flag3)
				{
					if (MWCalcOptions.CamWireframeType == CamWireFrameType.Contour)
					{
						varMWCamWFContourPars.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, varMWCamWFContourPars);
						varbuCamWFContourPars = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
					}
				}
				else if (!MWCalcOptions.is5AxisWireframe)
				{
					if (!((MWCalcOptions.CamWireframeType == CamWireFrameType.Contour) | (MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)))
					{
						if (MWCalcOptions.CamWireframeType != CamWireFrameType.Pocket)
						{
							if (MWCalcOptions.CamWireframeType == CamWireFrameType.Profile3Axis)
							{
								IterateThroughEntireStructure3X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam, MWCalcOptions.isAllG1);
								varMWCamWFProfile3AxisPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
								buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamWFProfile3AxisPars);
								varbuCamWFProfile3AxisPars = new camParameters5(mWCalculationResult.buCamParamters);
							}
						}
						else
						{
							IterateThroughEntireStructure3X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam, MWCalcOptions.isAllG1);
							varMWCamWFPocketPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
							buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamWFPocketPars);
							varbuCamWFPocketPars = new camParameters5(mWCalculationResult.buCamParamters);
						}
					}
					else
					{
						if (MWCalcOptions.NumberofAxis == 3)
						{
							IterateThroughEntireStructure3X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam, MWCalcOptions.isAllG1);
						}
						if (MWCalcOptions.NumberofAxis == 4)
						{
							IterateThroughEntireStructure4X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
						}
						varMWCamWFContourPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
						buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamWFContourPars);
						varbuCamWFContourPars = new camParameters5(mWCalculationResult.buCamParamters);
					}
				}
				else
				{
					clsInit.appMW.IterateThroughEntireStructure5X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
					varMWCamWFContourPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
					buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamWFContourPars);
					varbuCamWFContourPars = new camParameters5(mWCalculationResult.buCamParamters);
				}
				Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
				Cam.Parameter = new camParameters5(mWCalculationResult.buCamParamters);
				Cam.mwParameter = (object)new MachiningParams(mWCalculationResult.geoLib.MachParam);
				if (!((MWCalcOptions.CamWireframeType == CamWireFrameType.Contour) | (MWCalcOptions.CamWireframeType == CamWireFrameType.CenterPath)))
				{
					if (MWCalcOptions.CamWireframeType == CamWireFrameType.Pocket)
					{
						Cam.TypeCam = CamType.PocketCircular;
					}
				}
				else if (MWCalcOptions.NumberofAxis != 3)
				{
					if (MWCalcOptions.NumberofAxis == 4)
					{
						Cam.TypeCam = CamType.Contour4X;
					}
				}
				else
				{
					if (!MWCalcOptions.isClosed)
					{
						if (varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
						{
							if (varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
							{
								Cam.TypeCam = CamType.ContourOpenCenter;
							}
							else
							{
								Cam.TypeCam = CamType.ContourOpenRight;
							}
						}
						else
						{
							Cam.TypeCam = CamType.ContourOpenLeft;
						}
					}
					else if (varbuCamWFContourPars.Operations.Direction != ClockDirectionType.CCW)
					{
						if (varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
						{
							if (varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
							{
								Cam.TypeCam = CamType.ContourClosedCenter;
							}
							else
							{
								Cam.TypeCam = CamType.ContourClosedInside;
							}
						}
						else
						{
							Cam.TypeCam = CamType.ContourClosedOutside;
						}
					}
					else if (varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
					{
						if (varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide != WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
						{
							Cam.TypeCam = CamType.ContourClosedCenter;
						}
						else
						{
							Cam.TypeCam = CamType.ContourClosedOutside;
						}
					}
					else
					{
						Cam.TypeCam = CamType.ContourClosedInside;
					}
					if (flag4)
					{
						Cam.TypeCam = CamType.ContourMulti;
					}
				}
				Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
				Cam.Tool = new ToolBase5(mWCalculationResult.Tool);
				buVector5.CopyEntities(SortedEntities, ref Cam.sortedEntities);
				buVector5.CopyEntities(selectedEntities, ref Cam.RefEntities);
				if (Cam.Tool.Geometry.GeometryType == buClass.ToolType.Saw)
				{
					Cam.SimilationToolOffset.Z = Cam.Tool.Geometry.Diameter / 2.0;
				}
				Cam.CamID = AvailableCamID;
				SaveMWParameter();
				if (MWCalcOptions.AddToCamListInMWCalculation)
				{
					clsInit.appCommand.CamAdd(Cam);
				}
				if (!MWCalcOptions.DontApplyReset)
				{
					clsInit.appCommand.Reset();
				}
				if (MWCalcOptions.ShowProgressForm)
				{
					clsItem.FrmProgress.Visible = false;
				}
				return 1;
			}
			MessageBox.Show(AppLanguage.CadCamMessages[57]);
			clsInit.appCommand.Reset();
			return -1;
		}
		MessageBox.Show(AppLanguage.CadCamMessages[57]);
		clsInit.appCommand.Reset();
		return -1;
	}

	public int doTriangularMesh3D(MWCalculationOptions MWCalcOptions, ToolBase5 ToolSelected, ref camTp Cam, ref camResult Result)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Expected O, but got Unknown
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_084e: Expected O, but got Unknown
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_086e: Expected O, but got Unknown
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Expected O, but got Unknown
		//IL_0939: Unknown result type (might be due to invalid IL or missing references)
		//IL_0943: Expected O, but got Unknown
		//IL_0959: Unknown result type (might be due to invalid IL or missing references)
		//IL_0963: Expected O, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_09cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d7: Expected O, but got Unknown
		//IL_1318: Unknown result type (might be due to invalid IL or missing references)
		//IL_1322: Expected O, but got Unknown
		//IL_135e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1368: Expected O, but got Unknown
		//IL_13a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ae: Expected O, but got Unknown
		//IL_12bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c7: Expected O, but got Unknown
		try
		{
			ToolBase5 Tool = new ToolBase5(ToolSelected);
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			MWCalculationResult mWCalculationResult = new MWCalculationResult();
			TriangleMeshBasedTpCalcParamsPattern calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
			List<Entity> selectedEntities = new List<Entity>();
			List<Entity> selectedEntities2 = new List<Entity>();
			List<Entity> list = new List<Entity>();
			List<buMWCurveEntities> list2 = new List<buMWCurveEntities>();
			buMWCurveEntities buMWCurveEntities2 = new buMWCurveEntities();
			SelectionOption option = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
			bool flag = true;
			Result = new camResult();
			if ((Tool.Purpose == ToolPurpose.Drilling) | (Tool.Purpose == ToolPurpose.DiamondCut))
			{
				flag = false;
			}
			if (flag)
			{
				if (CamEntities.Count != 0)
				{
					buVector5.CopyEntities(CamEntities, ref selectedEntities);
					clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
					buVector5.CopyEntities(Containment2DEntities, ref selectedEntities2);
				}
				else
				{
					clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
					option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false);
					clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
				}
				if (Containment2DEntities.Count > 0)
				{
					buVector5.CopyEntities(Containment2DEntities, ref selectedEntities2);
				}
				if (clsInit.cMwCalc.mwCamDataParameter != null)
				{
					clsInit.cMwCalc.mwCamDataParameter.Dispose();
				}
				clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
				if (!((MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Rough) | (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.Rough3Plus2)))
				{
					if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.ParallelCuts)
					{
						if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.ConstantZ)
						{
							if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.ConstantCusp)
							{
								if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.Flatlands)
								{
									if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.Pencil)
									{
										if ((MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ProjectionAlong) | (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ProjectionAround))
										{
											buMWCalcs.CopyGeoLibProperties(varMWCamMeshProjectionPars, clsInit.cMwCalc.mwCamDataParameter);
											clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshProjectionPars.MachParam);
											clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshProjectionPars);
											calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbProjection;
										}
									}
									else
									{
										buMWCalcs.CopyGeoLibProperties(varMWCamMeshPencilPars, clsInit.cMwCalc.mwCamDataParameter);
										clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshPencilPars.MachParam);
										clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshPencilPars);
										calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil;
									}
								}
								else
								{
									buMWCalcs.CopyGeoLibProperties(varMWCamMeshFlatlandPars, clsInit.cMwCalc.mwCamDataParameter);
									clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshFlatlandPars.MachParam);
									clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshFlatlandsPars);
									calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbFlatlands;
								}
							}
							else
							{
								buMWCalcs.CopyGeoLibProperties(varMWCamMeshContantCuspPars, clsInit.cMwCalc.mwCamDataParameter);
								clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshContantCuspPars.MachParam);
								clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshConstantCuspPars);
								calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantCusp;
							}
						}
						else
						{
							buMWCalcs.CopyGeoLibProperties(varMWCamMeshContantZPars, clsInit.cMwCalc.mwCamDataParameter);
							clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshContantZPars.MachParam);
							clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshConstantZPars);
							calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ;
						}
					}
					else
					{
						buMWCalcs.CopyGeoLibProperties(varMWCamMeshParalelPars, clsInit.cMwCalc.mwCamDataParameter);
						clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshParalelPars.MachParam);
						clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshParallelPars);
						calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts;
					}
				}
				else
				{
					buMWCalcs.CopyGeoLibProperties(varMWCamMeshRoughPars, clsInit.cMwCalc.mwCamDataParameter);
					clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshRoughPars.MachParam);
					clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshRoughPars);
					calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
				}
				ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
				clsInit.cVector5.BoxSizeCalculate(selectedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
				clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
				if (MWCalcOptions.CheckBoxBounding)
				{
					if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
					{
						if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
						{
							if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
							{
								CalculationError item = new CalculationError(AppLanguage.CadCamError[1], 0);
								Result.Errors.Add(item);
							}
							if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
							{
								CalculationError item2 = new CalculationError(AppLanguage.CadCamError[0], 0);
								Result.Errors.Add(item2);
							}
						}
						if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
						{
							if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
							{
								CalculationError item3 = new CalculationError(AppLanguage.CadCamError[3], 0);
								Result.Errors.Add(item3);
							}
							if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
							{
								CalculationError item4 = new CalculationError(AppLanguage.CadCamError[2], 0);
								Result.Errors.Add(item4);
							}
						}
						if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
						{
							if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
							{
								CalculationError item5 = new CalculationError(AppLanguage.CadCamError[5], 0);
								Result.Errors.Add(item5);
							}
							if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
							{
								CalculationError item6 = new CalculationError(AppLanguage.CadCamError[4], 0);
								Result.Errors.Add(item6);
							}
						}
					}
					if (Result.Errors.Count > 0)
					{
						return -1;
					}
				}
				if (!MWCalcOptions.DontShowbuDialogBox)
				{
					if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.Rough)
					{
						if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.ParallelCuts)
						{
							if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.ConstantZ)
							{
								return -1;
							}
							F_TriMeshConstantZ f_TriMeshConstantZ = new F_TriMeshConstantZ();
							f_TriMeshConstantZ.Configration = new MWCalculationOptions(MWCalcOptions);
							f_TriMeshConstantZ.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
							f_TriMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_TriMeshConstantZ.mwCamParameter);
							f_TriMeshConstantZ.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
							f_TriMeshConstantZ.Init();
							f_TriMeshConstantZ.ShowDialog();
							if (f_TriMeshConstantZ.PropertiesForm.Result != DialogResult.OK)
							{
								return -1;
							}
							clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_TriMeshConstantZ.mwCamParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(f_TriMeshConstantZ.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
							clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_TriMeshConstantZ.buCamParameter);
						}
						else
						{
							F_TriMeshParallelCut f_TriMeshParallelCut = new F_TriMeshParallelCut();
							f_TriMeshParallelCut.Configration = new MWCalculationOptions(MWCalcOptions);
							f_TriMeshParallelCut.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
							f_TriMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_TriMeshParallelCut.mwCamParameter);
							f_TriMeshParallelCut.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
							f_TriMeshParallelCut.Init();
							f_TriMeshParallelCut.ShowDialog();
							if (f_TriMeshParallelCut.PropertiesForm.Result != DialogResult.OK)
							{
								return -1;
							}
							clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_TriMeshParallelCut.mwCamParameter.MachParam);
							buMWCalcs.CopyGeoLibProperties(f_TriMeshParallelCut.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
							clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_TriMeshParallelCut.buCamParameter);
						}
					}
					else
					{
						F_TriMeshRough f_TriMeshRough = new F_TriMeshRough();
						f_TriMeshRough.Configration = new MWCalculationOptions(MWCalcOptions);
						f_TriMeshRough.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
						f_TriMeshRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_TriMeshRough.mwCamParameter);
						f_TriMeshRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
						f_TriMeshRough.Init();
						f_TriMeshRough.ShowDialog();
						if (f_TriMeshRough.PropertiesForm.Result != DialogResult.OK)
						{
							return -1;
						}
						clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_TriMeshRough.mwCamParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(f_TriMeshRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
						clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_TriMeshRough.buCamParameter);
					}
				}
				CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
				List<Meshd> list3 = new List<Meshd>();
				clsInit.cMwCalc.Stock = null;
				List<Point3D> list4 = new List<Point3D>();
				for (int i = 0; i <= selectedEntities.Count - 1; i++)
				{
					if (!(selectedEntities[i] is Mesh))
					{
						if (!(selectedEntities[i] is Surface))
						{
							if (selectedEntities[i] is Brep)
							{
								Mesh mesh = ((Brep)selectedEntities[i]).ConvertToMesh(0.01);
								mesh.Regen(0.01);
								if (mesh.BoxMax == null)
								{
									mesh.Regen(new RegenParams(0.01));
								}
								list4.Add(buVector5.ToPoint3D(mesh.BoxMax));
								list4.Add(buVector5.ToPoint3D(mesh.BoxMin));
								Meshd val = buMWCalcs.ConvertToMWMesh(mesh);
								if (val != null)
								{
									list3.Add(val);
								}
							}
						}
						else
						{
							Mesh mesh2 = ((Surface)selectedEntities[i]).ConvertToMesh();
							if (mesh2.BoxMax == null)
							{
								mesh2.Regen(new RegenParams(0.01));
							}
							list4.Add(buVector5.ToPoint3D(mesh2.BoxMax));
							list4.Add(buVector5.ToPoint3D(mesh2.BoxMin));
							Meshd val2 = buMWCalcs.ConvertToMWMesh(mesh2);
							if (val2 != null)
							{
								list3.Add(val2);
							}
						}
						continue;
					}
					if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
					{
						if (!(selectedEntities[i].BoxMax == null))
						{
							list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMax));
							list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMin));
						}
						else
						{
							selectedEntities[i].Regen(new RegenParams(0.01));
							list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMax));
							list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMin));
						}
					}
					Meshd val3 = buMWCalcs.ConvertToMWMesh((Mesh)selectedEntities[i]);
					if (val3 != null)
					{
						list3.Add(val3);
					}
				}
				if (list3.Count != 0)
				{
					if (list4.Count > 0)
					{
						Point3D min = new Point3D();
						Point3D max = new Point3D();
						Utility.BoundingBox(list4, out min, out max);
						Mesh mesh3 = null;
						mesh3 = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
						mesh3.Translate(min.X, min.Y, min.Z);
						if (mesh3 != null)
						{
							if (clsInit.cMwCalc.Stock == null)
							{
								clsInit.cMwCalc.Stock = new List<Meshd>();
							}
							Meshd item7 = buMWCalcs.ConvertToMWMesh(mesh3);
							clsInit.cMwCalc.Stock.Add(item7);
						}
					}
					if (StockEntities.Count > 0)
					{
						if (clsInit.cMwCalc.Stock == null)
						{
							clsInit.cMwCalc.Stock = new List<Meshd>();
						}
						clsInit.cMwCalc.Stock.Clear();
						for (int j = 0; j <= StockEntities.Count - 1; j++)
						{
							if (StockEntities[j] is Mesh)
							{
								Meshd item8 = buMWCalcs.ConvertToMWMesh((Mesh)StockEntities[j]);
								clsInit.cMwCalc.Stock.Add(item8);
							}
						}
					}
					SortSettings sortSettings = new SortSettings();
					SortResult Result2 = new SortResult();
					list = new List<Entity>();
					if (selectedEntities2.Count > 0)
					{
						if (!MWCalcOptions.isBuSort)
						{
							buVector5.CopyEntities(selectedEntities2, ref list);
						}
						else if (ccVars.SelectionOP.ClickList.Count <= 0)
						{
							if (!MWCalcOptions.UseConstantStartPoint)
							{
								clsInit.cVector5.SortEntitiesByRefPoint(((ICurve)selectedEntities2[0]).StartPoint, ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
							}
							else
							{
								clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcOptions.StartPointX, MWCalcOptions.StartPointY), ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
							}
						}
						else
						{
							sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
							clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
						}
					}
					List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
					new List<List<Entity>>();
					clsInit.cVector5.EntitiesSplitByUpperLine(list, ref SplitedEntitites);
					for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
					{
						List<Entity> list5 = new List<Entity>();
						bool flag2 = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[k]);
						clsInit.cVector5.EntitiesClockDirection(SplitedEntitites[k]);
						if (flag2)
						{
							List<Point3D> Points = new List<Point3D>();
							clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[k], clsVar.varEntities.RegenDeviation, ref Points);
							if (Points.Count > 1)
							{
								LinearPath item9 = new LinearPath(Points);
								list5.Add(item9);
							}
							for (int l = 0; l <= list5.Count - 1; l++)
							{
								entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(list5[l]);
								if (sortDirection == entitySortDirection.Normal)
								{
									buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)list5[l]).StartPoint.X, ((ICurve)list5[l]).StartPoint.Y, ((ICurve)list5[l]).StartPoint.Z);
								}
								if (sortDirection == entitySortDirection.Reverse)
								{
									buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)list5[l]).EndPoint.X, ((ICurve)list5[l]).EndPoint.Y, ((ICurve)list5[l]).EndPoint.Z);
								}
								if ((list2.Count < ccVars.SelectionOP.ClickList.Count - 1) & (ccVars.SelectionOP.ClickList.Count > 0))
								{
									buMWCurveEntities2.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[list2.Count].X, ccVars.SelectionOP.ClickList[list2.Count].Y, ccVars.SelectionOP.ClickList[list2.Count].Z);
								}
								Curve mwEntity = null;
								buMWCalcs.ConvertWireEntity(list5[l], ref mwEntity);
								buMWCurveEntities2.CurveList.Add(mwEntity);
							}
						}
						if (buMWCurveEntities2.CurveList.Count > 0)
						{
							list2.Add(buMWCurveEntities2);
							buMWCurveEntities2 = new buMWCurveEntities();
						}
					}
					if (list2.Count == 0)
					{
						clsInit.cMwCalc.mwCamDataParameter.MachParam.Containment2dParams.IsUsedFlg = false;
					}
					if (!clsInit.cMwCalc.CalculateTriangleMesh(Tool, list3, list2, calcType, MWCalcOptions, ref mWCalculationResult))
					{
						return -1;
					}
					ccVars.UndoDont = true;
					Cam = new camTp();
					int AvailableCamID = 0;
					clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
					CamType typeCam = CamType.None;
					if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.Rough)
					{
						if (MWCalcOptions.CamTriMeshType != CamTriangularMeshType.ParallelCuts)
						{
							if (MWCalcOptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
							{
								varMWCamMeshContantZPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
								buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamMeshContantZPars);
								buMWCalcs.ConvertFromMwCamParToBuCamParTriangleMesh(mWCalculationResult.geoLib, ref varbuCamMeshConstantZPars);
								typeCam = CamType.ConstantZ;
							}
						}
						else
						{
							varMWCamMeshParalelPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
							buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamMeshParalelPars);
							buMWCalcs.ConvertFromMwCamParToBuCamParTriangleMesh(mWCalculationResult.geoLib, ref varbuCamMeshParallelPars);
							typeCam = CamType.ParallelCut;
						}
					}
					else
					{
						varMWCamMeshRoughPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
						buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamMeshRoughPars);
						buMWCalcs.ConvertFromMwCamParToBuCamParTriangleMesh(mWCalculationResult.geoLib, ref varbuCamMeshRoughPars);
						typeCam = CamType.Rough;
					}
					if (MWCalcOptions.NumberofAxis != 3)
					{
						if (MWCalcOptions.NumberofAxis != 4)
						{
							IterateThroughEntireStructure5X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
						}
						else
						{
							IterateThroughEntireStructure4XVectorX(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
						}
					}
					else
					{
						IterateThroughEntireStructure3X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
					}
					Cam.TypeCam = typeCam;
					Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
					Cam.Tool = new ToolBase5(mWCalculationResult.Tool);
					Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
					Cam.Parameter = new camParameters5(mWCalculationResult.buCamParamters);
					Cam.mwParameter = (object)new MachiningParams(mWCalculationResult.geoLib.MachParam);
					Cam.CamID = AvailableCamID;
					buVector5.CopyEntities(selectedEntities, ref Cam.RefEntities);
					if (MWCalcOptions.SaveDefaultMWParameter)
					{
						SaveMWParameter();
					}
					if (MWCalcOptions.AddToCamListInMWCalculation)
					{
						clsInit.appCommand.CamAdd(Cam);
					}
					if (!MWCalcOptions.DontApplyReset)
					{
						clsInit.appCommand.Reset();
					}
					clsItem.FrmProgress.Visible = false;
					return 1;
				}
				buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
				clsInit.appCommand.Reset();
				clsItem.FrmProgress.Visible = false;
				return -1;
			}
			MessageBox.Show(AppLanguage.CadCamMessages[57]);
			clsInit.appCommand.Reset();
			return -1;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public int doTriangularMesh3D5Axis(MWCalculationOptions MWCalcOptions, ToolBase5 ToolSelected, ref camTp Cam, ref camResult Result)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Expected O, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Expected O, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Expected O, but got Unknown
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Expected O, but got Unknown
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Expected O, but got Unknown
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Expected O, but got Unknown
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e9: Expected O, but got Unknown
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Expected O, but got Unknown
		//IL_10ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f8: Expected O, but got Unknown
		//IL_108a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1094: Expected O, but got Unknown
		//IL_1134: Unknown result type (might be due to invalid IL or missing references)
		//IL_113e: Expected O, but got Unknown
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1184: Expected O, but got Unknown
		ToolBase5 Tool = new ToolBase5(ToolSelected);
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		MWCalculationResult mWCalculationResult = new MWCalculationResult();
		TriangleMeshBasedTpCalcParamsPattern calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> selectedEntities2 = new List<Entity>();
		List<Entity> list = new List<Entity>();
		List<buMWCurveEntities> list2 = new List<buMWCurveEntities>();
		buMWCurveEntities buMWCurveEntities2 = new buMWCurveEntities();
		SelectionOption option = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
		bool flag = true;
		Result = new camResult();
		if ((Tool.Purpose == ToolPurpose.Drilling) | (Tool.Purpose == ToolPurpose.DiamondCut))
		{
			flag = false;
		}
		if (flag)
		{
			if (CamEntities.Count != 0)
			{
				buVector5.CopyEntities(CamEntities, ref selectedEntities);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			}
			else
			{
				clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
				option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false);
				clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
			}
			if (Containment2DEntities.Count > 0)
			{
				buVector5.CopyEntities(Containment2DEntities, ref selectedEntities2);
			}
			if (clsInit.cMwCalc.mwCamDataParameter != null)
			{
				clsInit.cMwCalc.mwCamDataParameter.Dispose();
			}
			clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
			if (MWCalcOptions.CamTriMesh5AXType != CamTriangularMesh5AxType.Rough)
			{
				if (MWCalcOptions.CamTriMesh5AXType != CamTriangularMesh5AxType.ParallelCuts)
				{
					if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
					{
						buMWCalcs.CopyGeoLibProperties(varMWCamMeshContantZPars, clsInit.cMwCalc.mwCamDataParameter);
						clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshContantZ5AXPars.MachParam);
						clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshConstantZ5AXPars);
						calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ;
					}
				}
				else
				{
					buMWCalcs.CopyGeoLibProperties(varMWCamMeshParalel5AXPars, clsInit.cMwCalc.mwCamDataParameter);
					clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshParalel5AXPars.MachParam);
					clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshParallel5AXPars);
					clsInit.cMwCalc.mwCamDataParameter.MachParam.ToolAxisControlParams.LimitsFlg = true;
					calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts;
				}
			}
			else
			{
				buMWCalcs.CopyGeoLibProperties(varMWCamMeshRough5AXPars, clsInit.cMwCalc.mwCamDataParameter);
				clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamMeshRough5AXPars.MachParam);
				clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamMeshRough5AXPars);
				calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
			}
			ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cVector5.BoxSizeCalculate(selectedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
			clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
			if (MWCalcOptions.CheckBoxBounding)
			{
				if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
				{
					if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
						{
							CalculationError item = new CalculationError(AppLanguage.CadCamError[1], 0);
							Result.Errors.Add(item);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
						{
							CalculationError item2 = new CalculationError(AppLanguage.CadCamError[0], 0);
							Result.Errors.Add(item2);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
					{
						if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
						{
							CalculationError item3 = new CalculationError(AppLanguage.CadCamError[3], 0);
							Result.Errors.Add(item3);
						}
						if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
						{
							CalculationError item4 = new CalculationError(AppLanguage.CadCamError[2], 0);
							Result.Errors.Add(item4);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
						{
							CalculationError item5 = new CalculationError(AppLanguage.CadCamError[5], 0);
							Result.Errors.Add(item5);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
						{
							CalculationError item6 = new CalculationError(AppLanguage.CadCamError[4], 0);
							Result.Errors.Add(item6);
						}
					}
				}
				if (Result.Errors.Count > 0)
				{
					return -1;
				}
			}
			if (!MWCalcOptions.DontShowbuDialogBox)
			{
				if (MWCalcOptions.CamTriMesh5AXType != CamTriangularMesh5AxType.Rough)
				{
					if (MWCalcOptions.CamTriMesh5AXType != CamTriangularMesh5AxType.ParallelCuts)
					{
						if (MWCalcOptions.CamTriMesh5AXType != CamTriangularMesh5AxType.ConstantZ)
						{
							return -1;
						}
						F_TriMeshConstantZ f_TriMeshConstantZ = new F_TriMeshConstantZ();
						f_TriMeshConstantZ.Configration = new MWCalculationOptions(MWCalcOptions);
						f_TriMeshConstantZ.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
						f_TriMeshConstantZ.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_TriMeshConstantZ.mwCamParameter);
						f_TriMeshConstantZ.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
						f_TriMeshConstantZ.Init();
						f_TriMeshConstantZ.ShowDialog();
						if (f_TriMeshConstantZ.PropertiesForm.Result != DialogResult.OK)
						{
							return -1;
						}
						clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_TriMeshConstantZ.mwCamParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(f_TriMeshConstantZ.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
						clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_TriMeshConstantZ.buCamParameter);
					}
					else
					{
						F_TriMeshParallelCut f_TriMeshParallelCut = new F_TriMeshParallelCut();
						f_TriMeshParallelCut.Configration = new MWCalculationOptions(MWCalcOptions);
						f_TriMeshParallelCut.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
						f_TriMeshParallelCut.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_TriMeshParallelCut.mwCamParameter);
						f_TriMeshParallelCut.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
						f_TriMeshParallelCut.Init();
						f_TriMeshParallelCut.ShowDialog();
						if (f_TriMeshParallelCut.PropertiesForm.Result != DialogResult.OK)
						{
							return -1;
						}
						clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_TriMeshParallelCut.mwCamParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(f_TriMeshParallelCut.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
						clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_TriMeshParallelCut.buCamParameter);
					}
				}
				else
				{
					F_TriMeshRough f_TriMeshRough = new F_TriMeshRough();
					f_TriMeshRough.Configration = new MWCalculationOptions(MWCalcOptions);
					f_TriMeshRough.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
					f_TriMeshRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
					buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_TriMeshRough.mwCamParameter);
					f_TriMeshRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
					f_TriMeshRough.Init();
					f_TriMeshRough.ShowDialog();
					if (f_TriMeshRough.PropertiesForm.Result != DialogResult.OK)
					{
						return -1;
					}
					clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_TriMeshRough.mwCamParameter.MachParam);
					buMWCalcs.CopyGeoLibProperties(f_TriMeshRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
					clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_TriMeshRough.buCamParameter);
				}
			}
			CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
			List<Meshd> list3 = new List<Meshd>();
			clsInit.cMwCalc.Stock = null;
			List<Point3D> list4 = new List<Point3D>();
			for (int i = 0; i <= selectedEntities.Count - 1; i++)
			{
				if (!(selectedEntities[i] is Mesh))
				{
					if (!(selectedEntities[i] is Surface))
					{
						if (selectedEntities[i] is Brep)
						{
							Mesh mesh = ((Brep)selectedEntities[i]).ConvertToMesh(0.01);
							mesh.Regen(0.01);
							if (mesh.BoxMax == null)
							{
								mesh.Regen(new RegenParams(0.01));
							}
							list4.Add(buVector5.ToPoint3D(mesh.BoxMax));
							list4.Add(buVector5.ToPoint3D(mesh.BoxMin));
							Meshd val = buMWCalcs.ConvertToMWMesh(mesh);
							if (val != null)
							{
								list3.Add(val);
							}
						}
					}
					else
					{
						Mesh mesh2 = ((Surface)selectedEntities[i]).ConvertToMesh();
						if (mesh2.BoxMax == null)
						{
							mesh2.Regen(new RegenParams(0.01));
						}
						list4.Add(buVector5.ToPoint3D(mesh2.BoxMax));
						list4.Add(buVector5.ToPoint3D(mesh2.BoxMin));
						Meshd val2 = buMWCalcs.ConvertToMWMesh(mesh2);
						if (val2 != null)
						{
							list3.Add(val2);
						}
					}
					continue;
				}
				if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
				{
					if (!(selectedEntities[i].BoxMax == null))
					{
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMax));
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMin));
					}
					else
					{
						selectedEntities[i].Regen(new RegenParams(0.01));
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMax));
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMin));
					}
				}
				Meshd val3 = buMWCalcs.ConvertToMWMesh((Mesh)selectedEntities[i]);
				if (val3 != null)
				{
					list3.Add(val3);
				}
			}
			if (list3.Count != 0)
			{
				if (list4.Count > 0)
				{
					Point3D min = new Point3D();
					Point3D max = new Point3D();
					Utility.BoundingBox(list4, out min, out max);
					Mesh mesh3 = null;
					mesh3 = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
					mesh3.Translate(min.X, min.Y, min.Z);
					if (mesh3 != null)
					{
						if (clsInit.cMwCalc.Stock == null)
						{
							clsInit.cMwCalc.Stock = new List<Meshd>();
						}
						Meshd item7 = buMWCalcs.ConvertToMWMesh(mesh3);
						clsInit.cMwCalc.Stock.Add(item7);
					}
				}
				SortSettings sortSettings = new SortSettings();
				SortResult Result2 = new SortResult();
				list = new List<Entity>();
				if (selectedEntities2.Count > 0)
				{
					if (!MWCalcOptions.isBuSort)
					{
						buVector5.CopyEntities(selectedEntities2, ref list);
					}
					else if (ccVars.SelectionOP.ClickList.Count <= 0)
					{
						if (!MWCalcOptions.UseConstantStartPoint)
						{
							clsInit.cVector5.SortEntitiesByRefPoint(((ICurve)selectedEntities2[0]).StartPoint, ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
						}
						else
						{
							clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcOptions.StartPointX, MWCalcOptions.StartPointY), ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
						}
					}
					else
					{
						sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
						clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
					}
				}
				List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
				new List<List<Entity>>();
				clsInit.cVector5.EntitiesSplitByUpperLine(list, ref SplitedEntitites);
				for (int j = 0; j <= SplitedEntitites.Count - 1; j++)
				{
					List<Entity> list5 = new List<Entity>();
					bool flag2 = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[j]);
					clsInit.cVector5.EntitiesClockDirection(SplitedEntitites[j]);
					if (flag2)
					{
						List<Point3D> Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[j], clsVar.varEntities.RegenDeviation, ref Points);
						if (Points.Count > 1)
						{
							LinearPath item8 = new LinearPath(Points);
							list5.Add(item8);
						}
						for (int k = 0; k <= list5.Count - 1; k++)
						{
							entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(list5[k]);
							if (sortDirection == entitySortDirection.Normal)
							{
								buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)list5[k]).StartPoint.X, ((ICurve)list5[k]).StartPoint.Y, ((ICurve)list5[k]).StartPoint.Z);
							}
							if (sortDirection == entitySortDirection.Reverse)
							{
								buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)list5[k]).EndPoint.X, ((ICurve)list5[k]).EndPoint.Y, ((ICurve)list5[k]).EndPoint.Z);
							}
							if ((list2.Count < ccVars.SelectionOP.ClickList.Count - 1) & (ccVars.SelectionOP.ClickList.Count > 0))
							{
								buMWCurveEntities2.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[list2.Count].X, ccVars.SelectionOP.ClickList[list2.Count].Y, ccVars.SelectionOP.ClickList[list2.Count].Z);
							}
							Curve mwEntity = null;
							buMWCalcs.ConvertWireEntity(list5[k], ref mwEntity);
							buMWCurveEntities2.CurveList.Add(mwEntity);
						}
					}
					if (buMWCurveEntities2.CurveList.Count > 0)
					{
						list2.Add(buMWCurveEntities2);
						buMWCurveEntities2 = new buMWCurveEntities();
					}
				}
				if (list2.Count == 0)
				{
					clsInit.cMwCalc.mwCamDataParameter.MachParam.Containment2dParams.IsUsedFlg = false;
				}
				if (!clsInit.cMwCalc.CalculateTriangleMesh(Tool, list3, list2, calcType, MWCalcOptions, ref mWCalculationResult))
				{
					return -1;
				}
				clsInit.appCommand.undoBuffer();
				ccVars.UndoDont = true;
				Cam = new camTp();
				int AvailableCamID = 0;
				clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
				CamType typeCam = CamType.None;
				if (MWCalcOptions.CamTriMesh5AXType != CamTriangularMesh5AxType.Rough)
				{
					if (MWCalcOptions.CamTriMesh5AXType != CamTriangularMesh5AxType.ParallelCuts)
					{
						if (MWCalcOptions.CamTriMesh5AXType == CamTriangularMesh5AxType.ConstantZ)
						{
							varMWCamMeshContantZ5AXPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
							buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamMeshContantZ5AXPars);
							varbuCamMeshConstantZ5AXPars = new camParameters5(mWCalculationResult.buCamParamters);
							typeCam = CamType.ConstantZ;
						}
					}
					else
					{
						varMWCamMeshParalel5AXPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
						buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamMeshParalel5AXPars);
						varbuCamMeshParallel5AXPars = new camParameters5(mWCalculationResult.buCamParamters);
						typeCam = CamType.ParallelCut;
					}
				}
				else
				{
					varMWCamMeshRough5AXPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
					buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamMeshRough5AXPars);
					varbuCamMeshRough5AXPars = new camParameters5(mWCalculationResult.buCamParamters);
					typeCam = CamType.Rough;
				}
				IterateThroughEntireStructure5X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
				Cam.TypeCam = typeCam;
				Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
				Cam.Tool = new ToolBase5(mWCalculationResult.Tool);
				Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
				Cam.Parameter = new camParameters5(mWCalculationResult.buCamParamters);
				Cam.mwParameter = (object)new MachiningParams(mWCalculationResult.geoLib.MachParam);
				Cam.CamID = AvailableCamID;
				buVector5.CopyEntities(selectedEntities, ref Cam.RefEntities);
				SaveMWParameter();
				if (MWCalcOptions.AddToCamListInMWCalculation)
				{
					clsInit.appCommand.CamAdd(Cam);
				}
				if (!MWCalcOptions.DontApplyReset)
				{
					clsInit.appCommand.Reset();
				}
				clsItem.FrmProgress.Visible = false;
				return 1;
			}
			buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
			clsInit.appCommand.Reset();
			clsItem.FrmProgress.Visible = false;
			return -1;
		}
		MessageBox.Show(AppLanguage.CadCamMessages[57]);
		clsInit.appCommand.Reset();
		return -1;
	}

	public int doGeodesic(MWCalculationOptions MWCalcOptions, ToolBase5 ToolSelected, ref camTp Cam, ref camResult Result)
	{
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected O, but got Unknown
		//IL_0cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce8: Expected O, but got Unknown
		//IL_0d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da3: Expected O, but got Unknown
		ToolBase5 Tool = new ToolBase5(ToolSelected);
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		MWCalculationResult mWCalculationResult = new MWCalculationResult();
		TriangleMeshBasedTpCalcParamsPattern calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> selectedEntities2 = new List<Entity>();
		List<Entity> list = new List<Entity>();
		List<buMWCurveEntities> list2 = new List<buMWCurveEntities>();
		buMWCurveEntities buMWCurveEntities2 = new buMWCurveEntities();
		SelectionOption option = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
		bool flag = true;
		Result = new camResult();
		if ((Tool.Purpose == ToolPurpose.Drilling) | (Tool.Purpose == ToolPurpose.DiamondCut))
		{
			flag = false;
		}
		if (flag)
		{
			if (CamEntities.Count != 0)
			{
				buVector5.CopyEntities(CamEntities, ref selectedEntities);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			}
			else
			{
				clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
				option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false);
				clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
			}
			if (Containment2DEntities.Count > 0)
			{
				buVector5.CopyEntities(Containment2DEntities, ref selectedEntities2);
			}
			if (clsInit.cMwCalc.mwCamDataParameter != null)
			{
				clsInit.cMwCalc.mwCamDataParameter.Dispose();
			}
			clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
			buMWCalcs.CopyGeoLibProperties(varMWCamGeodesicPars, clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamGeodesicPars.MachParam);
			clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamGeodesicPars);
			ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cVector5.BoxSizeCalculate(selectedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
			clsInit.cMwCalc.buCamDataParameter.Operations.Height = MaxPoint.Z;
			if (MWCalcOptions.CheckBoxBounding)
			{
				if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
				{
					if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
						{
							CalculationError item = new CalculationError(AppLanguage.CadCamError[1], 0);
							Result.Errors.Add(item);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
						{
							CalculationError item2 = new CalculationError(AppLanguage.CadCamError[0], 0);
							Result.Errors.Add(item2);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
					{
						if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
						{
							CalculationError item3 = new CalculationError(AppLanguage.CadCamError[3], 0);
							Result.Errors.Add(item3);
						}
						if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
						{
							CalculationError item4 = new CalculationError(AppLanguage.CadCamError[2], 0);
							Result.Errors.Add(item4);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
						{
							CalculationError item5 = new CalculationError(AppLanguage.CadCamError[5], 0);
							Result.Errors.Add(item5);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
						{
							CalculationError item6 = new CalculationError(AppLanguage.CadCamError[4], 0);
							Result.Errors.Add(item6);
						}
					}
				}
				if (Result.Errors.Count > 0)
				{
					return -1;
				}
			}
			if (!MWCalcOptions.DontShowbuDialogBox)
			{
				F_TriMeshRough f_TriMeshRough = new F_TriMeshRough();
				f_TriMeshRough.Configration = new MWCalculationOptions(MWCalcOptions);
				f_TriMeshRough.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
				f_TriMeshRough.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_TriMeshRough.mwCamParameter);
				f_TriMeshRough.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
				f_TriMeshRough.Init();
				f_TriMeshRough.ShowDialog();
				if (f_TriMeshRough.PropertiesForm.Result != DialogResult.OK)
				{
					return -1;
				}
				clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_TriMeshRough.mwCamParameter.MachParam);
				buMWCalcs.CopyGeoLibProperties(f_TriMeshRough.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
				clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_TriMeshRough.buCamParameter);
			}
			CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
			List<Meshd> list3 = new List<Meshd>();
			clsInit.cMwCalc.Stock = null;
			List<Point3D> list4 = new List<Point3D>();
			for (int i = 0; i <= selectedEntities.Count - 1; i++)
			{
				if (!(selectedEntities[i] is Mesh))
				{
					if (!(selectedEntities[i] is Surface))
					{
						if (selectedEntities[i] is Brep)
						{
							Mesh mesh = ((Brep)selectedEntities[i]).ConvertToMesh(0.01);
							mesh.Regen(0.01);
							if (mesh.BoxMax == null)
							{
								mesh.Regen(new RegenParams(0.01));
							}
							list4.Add(buVector5.ToPoint3D(mesh.BoxMax));
							list4.Add(buVector5.ToPoint3D(mesh.BoxMin));
							Meshd val = buMWCalcs.ConvertToMWMesh(mesh);
							if (val != null)
							{
								list3.Add(val);
							}
						}
					}
					else
					{
						Mesh mesh2 = ((Surface)selectedEntities[i]).ConvertToMesh();
						if (mesh2.BoxMax == null)
						{
							mesh2.Regen(new RegenParams(0.01));
						}
						list4.Add(buVector5.ToPoint3D(mesh2.BoxMax));
						list4.Add(buVector5.ToPoint3D(mesh2.BoxMin));
						Meshd val2 = buMWCalcs.ConvertToMWMesh(mesh2);
						if (val2 != null)
						{
							list3.Add(val2);
						}
					}
					continue;
				}
				if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
				{
					if (!(selectedEntities[i].BoxMax == null))
					{
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMax));
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMin));
					}
					else
					{
						selectedEntities[i].Regen(new RegenParams(0.01));
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMax));
						list4.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMin));
					}
				}
				Meshd val3 = buMWCalcs.ConvertToMWMesh((Mesh)selectedEntities[i]);
				if (val3 != null)
				{
					list3.Add(val3);
				}
			}
			if (list3.Count != 0)
			{
				if (list4.Count > 0)
				{
					Point3D min = new Point3D();
					Point3D max = new Point3D();
					Utility.BoundingBox(list4, out min, out max);
					Mesh mesh3 = null;
					mesh3 = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
					mesh3.Translate(min.X, min.Y, min.Z);
					if (mesh3 != null)
					{
						if (clsInit.cMwCalc.Stock == null)
						{
							clsInit.cMwCalc.Stock = new List<Meshd>();
						}
						Meshd item7 = buMWCalcs.ConvertToMWMesh(mesh3);
						clsInit.cMwCalc.Stock.Add(item7);
					}
				}
				SortSettings sortSettings = new SortSettings();
				SortResult Result2 = new SortResult();
				list = new List<Entity>();
				if (selectedEntities2.Count > 0)
				{
					if (!MWCalcOptions.isBuSort)
					{
						buVector5.CopyEntities(selectedEntities2, ref list);
					}
					else if (ccVars.SelectionOP.ClickList.Count <= 0)
					{
						if (!MWCalcOptions.UseConstantStartPoint)
						{
							clsInit.cVector5.SortEntitiesByRefPoint(((ICurve)selectedEntities2[0]).StartPoint, ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
						}
						else
						{
							clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(MWCalcOptions.StartPointX, MWCalcOptions.StartPointY), ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
						}
					}
					else
					{
						sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
						clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref selectedEntities2, MWCalcOptions.SortingSettings, ref list, ref Result2);
					}
				}
				List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
				new List<List<Entity>>();
				clsInit.cVector5.EntitiesSplitByUpperLine(list, ref SplitedEntitites);
				for (int j = 0; j <= SplitedEntitites.Count - 1; j++)
				{
					List<Entity> list5 = new List<Entity>();
					bool flag2 = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[j]);
					clsInit.cVector5.EntitiesClockDirection(SplitedEntitites[j]);
					if (flag2)
					{
						List<Point3D> Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[j], clsVar.varEntities.RegenDeviation, ref Points);
						if (Points.Count > 1)
						{
							LinearPath item8 = new LinearPath(Points);
							list5.Add(item8);
						}
						for (int k = 0; k <= list5.Count - 1; k++)
						{
							entitySortDirection sortDirection = clsInit.cVector5.GetSortDirection(list5[k]);
							if (sortDirection == entitySortDirection.Normal)
							{
								buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)list5[k]).StartPoint.X, ((ICurve)list5[k]).StartPoint.Y, ((ICurve)list5[k]).StartPoint.Z);
							}
							if (sortDirection == entitySortDirection.Reverse)
							{
								buMWCurveEntities2.pntStart = new Point3d<double>(((ICurve)list5[k]).EndPoint.X, ((ICurve)list5[k]).EndPoint.Y, ((ICurve)list5[k]).EndPoint.Z);
							}
							if ((list2.Count < ccVars.SelectionOP.ClickList.Count - 1) & (ccVars.SelectionOP.ClickList.Count > 0))
							{
								buMWCurveEntities2.pntStart = new Point3d<double>(ccVars.SelectionOP.ClickList[list2.Count].X, ccVars.SelectionOP.ClickList[list2.Count].Y, ccVars.SelectionOP.ClickList[list2.Count].Z);
							}
							Curve mwEntity = null;
							buMWCalcs.ConvertWireEntity(list5[k], ref mwEntity);
							buMWCurveEntities2.CurveList.Add(mwEntity);
						}
					}
					if (buMWCurveEntities2.CurveList.Count > 0)
					{
						list2.Add(buMWCurveEntities2);
						buMWCurveEntities2 = new buMWCurveEntities();
					}
				}
				if (list2.Count == 0)
				{
					clsInit.cMwCalc.mwCamDataParameter.MachParam.Containment2dParams.IsUsedFlg = false;
				}
				if (!clsInit.cMwCalc.CalculateGeodesic(Tool, list3, list2, calcType, MWCalcOptions, ref mWCalculationResult))
				{
					return -1;
				}
				clsInit.appCommand.undoBuffer();
				ccVars.UndoDont = true;
				Cam = new camTp();
				int AvailableCamID = 0;
				clsInit.appCommand.CamAvailableIDGet(ref AvailableCamID);
				varMWCamGeodesicPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
				buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamGeodesicPars);
				varbuCamGeodesicPars = new camParameters5(mWCalculationResult.buCamParamters);
				IterateThroughEntireStructure5X(mWCalculationResult.ToolPathCalc, AvailableCamID, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
				Cam.TypeCam = CamType.Finish;
				Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
				Cam.Tool = new ToolBase5(mWCalculationResult.Tool);
				Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
				Cam.Parameter = new camParameters5(mWCalculationResult.buCamParamters);
				Cam.mwParameter = (object)new MachiningParams(mWCalculationResult.geoLib.MachParam);
				Cam.CamID = AvailableCamID;
				buVector5.CopyEntities(selectedEntities, ref Cam.RefEntities);
				SaveMWParameter();
				if (MWCalcOptions.AddToCamListInMWCalculation)
				{
					clsInit.appCommand.CamAdd(Cam);
				}
				if (!MWCalcOptions.DontApplyReset)
				{
					clsInit.appCommand.Reset();
				}
				clsItem.FrmProgress.Visible = false;
				return 1;
			}
			buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
			clsInit.appCommand.Reset();
			clsItem.FrmProgress.Visible = false;
			return -1;
		}
		MessageBox.Show(AppLanguage.CadCamMessages[57]);
		clsInit.appCommand.Reset();
		return -1;
	}

	public int doDrill(MWCalculationOptions MWCalcOptions, ToolBase5 ToolSelected, ref camTp Cam, ref camResult Result)
	{
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab5: Expected O, but got Unknown
		//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad5: Expected O, but got Unknown
		//IL_0b4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b56: Expected O, but got Unknown
		//IL_0bbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc6: Expected O, but got Unknown
		//IL_0c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1e: Expected O, but got Unknown
		//IL_0c64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6e: Expected O, but got Unknown
		//IL_09fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a07: Expected O, but got Unknown
		ToolBase5 Tool = new ToolBase5(ToolSelected);
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		MWCalculationResult mWCalculationResult = new MWCalculationResult();
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> BaseRefEntities = new List<Entity>();
		List<Entity> SortedEntities = new List<Entity>();
		new List<buMWCurveEntities>();
		new List<Curve>();
		new buMWCurveEntities();
		SortSettings sortSettings = new SortSettings();
		SortResult Result2 = new SortResult();
		bool flag = false;
		Result = new camResult();
		if ((Tool.Purpose == ToolPurpose.Drilling) | (Tool.Purpose == ToolPurpose.DiamondCut))
		{
			flag = true;
		}
		if (flag)
		{
			if (CamEntities.Count != 0)
			{
				buVector5.CopyEntities(CamEntities, ref selectedEntities);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			}
			else
			{
				SelectionOption option = new SelectionOption();
				clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
			}
			for (int i = 0; i <= selectedEntities.Count - 1; i++)
			{
				Point3D point3D = null;
				OrientationAngle orientationAngle = null;
				if (!(selectedEntities[i] is Circle))
				{
					if (!(selectedEntities[i] is devDept.Eyeshot.Entities.Point))
					{
						if (!(selectedEntities[i] is Arc))
						{
							if (!(selectedEntities[i] is Ellipse))
							{
								if (!(selectedEntities[i] is EllipticalArc))
								{
									if (selectedEntities[i] is Line)
									{
										point3D = new Point3D(((Line)selectedEntities[i]).MidPoint.X, ((Line)selectedEntities[i]).MidPoint.Y, ((Line)selectedEntities[i]).MidPoint.Z);
										double c = clsInit.cVector5.PointAngle(((Line)selectedEntities[i]).EndPoint, ((Line)selectedEntities[i]).StartPoint, Plane.XY);
										orientationAngle = new OrientationAngle(0.0, 0.0, c);
									}
								}
								else
								{
									point3D = new Point3D(((EllipticalArc)selectedEntities[i]).Center.X, ((EllipticalArc)selectedEntities[i]).Center.Y, ((EllipticalArc)selectedEntities[i]).Center.Z);
									orientationAngle = new OrientationAngle();
								}
							}
							else
							{
								point3D = new Point3D(((Ellipse)selectedEntities[i]).Center.X, ((Ellipse)selectedEntities[i]).Center.Y, ((Ellipse)selectedEntities[i]).Center.Z);
								orientationAngle = new OrientationAngle();
							}
						}
						else
						{
							point3D = new Point3D(((Arc)selectedEntities[i]).Center.X, ((Arc)selectedEntities[i]).Center.Y, ((Arc)selectedEntities[i]).Center.Z);
							orientationAngle = new OrientationAngle();
						}
					}
					else
					{
						point3D = new Point3D(((devDept.Eyeshot.Entities.Point)selectedEntities[i]).StartPoint.X, ((devDept.Eyeshot.Entities.Point)selectedEntities[i]).StartPoint.Y, ((devDept.Eyeshot.Entities.Point)selectedEntities[i]).StartPoint.Z);
						orientationAngle = new OrientationAngle();
					}
				}
				else
				{
					point3D = new Point3D(((Circle)selectedEntities[i]).Center.X, ((Circle)selectedEntities[i]).Center.Y, ((Circle)selectedEntities[i]).Center.Z);
					orientationAngle = new OrientationAngle();
				}
				if (point3D != null)
				{
					devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(point3D);
					point.EntityData = new CustomData();
					((CustomData)point.EntityData).OrientationC = orientationAngle.C;
					BaseRefEntities.Add(point);
				}
			}
			sortSettings.Filter.UsePointEntities = true;
			if (ccVars.SelectionOP.ClickList.Count <= 0)
			{
				clsInit.cVector5.SortEntitiesByRefPoint(((ICurve)selectedEntities[0]).StartPoint, ref BaseRefEntities, sortSettings, ref SortedEntities, ref Result2);
			}
			else
			{
				sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
				clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref BaseRefEntities, sortSettings, ref SortedEntities, ref Result2);
			}
			if (clsInit.cMwCalc.mwCamDataParameter != null)
			{
				clsInit.cMwCalc.mwCamDataParameter.Dispose();
			}
			clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
			buMWCalcs.CopyGeoLibProperties(varMWCamDrillPars, clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamDrillPars.MachParam);
			clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamDrillPars);
			ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cVector5.BoxSizeCalculate(SortedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
			MWCalcOptions.isClosed = clsInit.cVector5.isEntitiesClosed(SortedEntities);
			MWCalcOptions.Direction = clsInit.cVector5.GetClockDirection(SortedEntities);
			if (MWCalcOptions.CheckBoxBounding)
			{
				if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
				{
					if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
						{
							CalculationError item = new CalculationError(AppLanguage.CadCamError[1], 0);
							Result.Errors.Add(item);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
						{
							CalculationError item2 = new CalculationError(AppLanguage.CadCamError[0], 0);
							Result.Errors.Add(item2);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
					{
						if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
						{
							CalculationError item3 = new CalculationError(AppLanguage.CadCamError[3], 0);
							Result.Errors.Add(item3);
						}
						if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
						{
							CalculationError item4 = new CalculationError(AppLanguage.CadCamError[2], 0);
							Result.Errors.Add(item4);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
						{
							CalculationError item5 = new CalculationError(AppLanguage.CadCamError[5], 0);
							Result.Errors.Add(item5);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
						{
							CalculationError item6 = new CalculationError(AppLanguage.CadCamError[4], 0);
							Result.Errors.Add(item6);
						}
					}
				}
				if (Result.Errors.Count > 0)
				{
					return -1;
				}
			}
			List<Pnt6D> Points = new List<Pnt6D>();
			for (int j = 0; j <= SortedEntities.Count - 1; j++)
			{
				if (SortedEntities[j] is devDept.Eyeshot.Entities.Point)
				{
					devDept.Eyeshot.Entities.Point point2 = (devDept.Eyeshot.Entities.Point)SortedEntities[j];
					double c2 = 0.0;
					if (point2.EntityData != null)
					{
						c2 = ((CustomData)point2.EntityData).OrientationC;
					}
					Points.Add(new Pnt6D(point2.Vertices[0].X, point2.Vertices[0].Y, point2.Vertices[0].Z, 0.0, 0.0, c2));
				}
			}
			if (Points.Count != 0)
			{
				if (!MWCalcOptions.DontShowDialogBox)
				{
					F_DrillLine f_DrillLine = new F_DrillLine();
					f_DrillLine.mwCamParameter = new GeoLib(clsInit.cMwCalc.mwCamDataParameter.Units, 0);
					f_DrillLine.mwCamParameter.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
					buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, f_DrillLine.mwCamParameter);
					f_DrillLine.buCamParameter = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
					f_DrillLine.Configration = new MWCalculationOptions(MWCalcOptions);
					f_DrillLine.Init();
					f_DrillLine.ShowDialog();
					if (f_DrillLine.PropertiesForm.Result != DialogResult.OK)
					{
						return -1;
					}
					clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(f_DrillLine.mwCamParameter.MachParam);
					buMWCalcs.CopyGeoLibProperties(f_DrillLine.mwCamParameter, clsInit.cMwCalc.mwCamDataParameter);
					clsInit.cMwCalc.buCamDataParameter = new camParameters5(f_DrillLine.buCamParameter);
				}
				CamDataToolData(clsInit.cMwCalc.buCamDataParameter, ref Tool);
				Tool.CamData.SpindleSpeed = clsInit.cMwCalc.buCamDataParameter.Speeds.SpindleSpeed;
				Tool.CamData.SpindleDirection = clsInit.cMwCalc.buCamDataParameter.Speeds.SpindleDirection;
				clsInit.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
				Cam = new camTp();
				camParameters5 BUPar = new camParameters5(clsInit.cMwCalc.buCamDataParameter);
				clsInit.appCommand.CamAvailableIDGet(ref BUPar.Runtime.CamID);
				buMWCalcs.ConvertFromMwCamParToBuCamPar(clsInit.cMwCalc.mwCamDataParameter, ref BUPar);
				if (!((MWCalcOptions.CamDrillMode == CamDrillMode.Point) | (MWCalcOptions.CamDrillMode == CamDrillMode.Tangent)))
				{
					if (MWCalcOptions.CamDrillMode == CamDrillMode.Rotation)
					{
						clsInit.cCam5.camDrillThenRotation(Points, Tool, new WorkPlane(), BUPar, ref Cam);
						varbuCamDrillPars = new camParameters5(BUPar);
						varMWCamDrillPars.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
						buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, varMWCamDrillPars);
					}
				}
				else
				{
					clsInit.cCam5.camDrill(Points, Tool, new WorkPlane(), BUPar, ref Cam);
					varbuCamDrillPars = new camParameters5(BUPar);
					varMWCamDrillPars.MachParam = new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
					buMWCalcs.CopyGeoLibProperties(clsInit.cMwCalc.mwCamDataParameter, varMWCamDrillPars);
				}
				clsInit.appCommand.undoBuffer();
				ccVars.UndoDont = true;
				if (MWCalcOptions.NumberofAxis == 3)
				{
					Cam.TypeCam = CamType.Drill;
				}
				if (MWCalcOptions.NumberofAxis == 4)
				{
					Cam.TypeCam = CamType.Drill4X;
				}
				Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
				if (mWCalculationResult.geoLib != null)
				{
					varMWCamDrillPars.MachParam = new MachiningParams(mWCalculationResult.geoLib.MachParam);
					buMWCalcs.CopyGeoLibProperties(mWCalculationResult.geoLib, varMWCamDrillPars);
				}
				if (mWCalculationResult.buCamParamters != null)
				{
					varbuCamDrillPars = new camParameters5(mWCalculationResult.buCamParamters);
				}
				Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
				Cam.Parameter = new camParameters5(BUPar);
				Cam.mwParameter = (object)new MachiningParams(clsInit.cMwCalc.mwCamDataParameter.MachParam);
				Cam.CamID = BUPar.Runtime.CamID;
				Cam.Tool = Tool;
				buVector5.CopyEntities(selectedEntities, ref Cam.RefEntities);
				SaveMWParameter();
				if (MWCalcOptions.AddToCamListInMWCalculation)
				{
					clsInit.appCommand.CamAdd(Cam);
				}
				if (!MWCalcOptions.DontApplyReset)
				{
					clsInit.appCommand.Reset();
				}
				clsItem.FrmProgress.Visible = false;
				return 1;
			}
			buString.MessageBoxError(AppLanguage.CadCamMessages[80]);
			clsInit.appCommand.Reset();
			clsItem.FrmProgress.Visible = false;
			return -1;
		}
		MessageBox.Show(AppLanguage.CadCamMessages[57]);
		clsInit.appCommand.Reset();
		return -1;
	}

	public int doContouring(MWCalculationOptions MWCalcOptions, ToolBase5 ToolSelected, ref camTp Cam, ref camResult Result)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Expected O, but got Unknown
		ToolBase5 Tool = new ToolBase5(ToolSelected);
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		MWCalculationResult mWCalculationResult = new MWCalculationResult();
		TriangleMeshBasedTpCalcParamsPattern calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
		List<Entity> copiedEnt = new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		List<buMWCurveEntities> edgeCurves = new List<buMWCurveEntities>();
		new buMWCurveEntities();
		new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
		bool flag = true;
		Result = new camResult();
		if ((Tool.Purpose == ToolPurpose.Drilling) | (Tool.Purpose == ToolPurpose.DiamondCut))
		{
			flag = false;
		}
		if (flag)
		{
			buVector5.CopyEntities(CamEntities, ref copiedEnt);
			clsInit.cVector5.EntitiesPlaneCheck(ref copiedEnt);
			if (buMWCalcs.CamEntities.Count > 0)
			{
				buVector5.CopyEntities(buMWCalcs.CamEntities, ref copiedEnt);
				clsInit.cVector5.EntitiesPlaneCheck(ref copiedEnt);
			}
			if (clsInit.cMwCalc.mwCamDataParameter != null)
			{
				clsInit.cMwCalc.mwCamDataParameter.Dispose();
			}
			clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
			buMWCalcs.CopyCamParameter(buMWCalcs.varCamContouringPars, ref clsInit.cMwCalc.mwCamDataParameter, ref clsInit.cMwCalc.buCamDataParameter);
			ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cVector5.BoxSizeCalculate(copiedEnt, ref MinPoint, ref MidPoint, ref MaxPoint);
			if (MWCalcOptions.CheckBoxBounding)
			{
				if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
				{
					if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
						{
							CalculationError item = new CalculationError(AppLanguage.CadCamError[1], 0);
							Result.Errors.Add(item);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
						{
							CalculationError item2 = new CalculationError(AppLanguage.CadCamError[0], 0);
							Result.Errors.Add(item2);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
					{
						if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
						{
							CalculationError item3 = new CalculationError(AppLanguage.CadCamError[3], 0);
							Result.Errors.Add(item3);
						}
						if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
						{
							CalculationError item4 = new CalculationError(AppLanguage.CadCamError[2], 0);
							Result.Errors.Add(item4);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
						{
							CalculationError item5 = new CalculationError(AppLanguage.CadCamError[5], 0);
							Result.Errors.Add(item5);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
						{
							CalculationError item6 = new CalculationError(AppLanguage.CadCamError[4], 0);
							Result.Errors.Add(item6);
						}
					}
				}
				if (Result.Errors.Count > 0)
				{
					return -1;
				}
			}
			CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
			List<Meshd> list = new List<Meshd>();
			clsInit.cMwCalc.Stock = null;
			List<Point3D> list2 = new List<Point3D>();
			for (int i = 0; i <= copiedEnt.Count - 1; i++)
			{
				if (!(copiedEnt[i] is Mesh))
				{
					if (!(copiedEnt[i] is Surface))
					{
						if (copiedEnt[i] is Brep)
						{
							((Brep)copiedEnt[i]).Regen(new RegenParams(0.01));
							Mesh mesh = ((Brep)copiedEnt[i]).ConvertToMesh();
							if (mesh.BoxMax == null)
							{
								mesh.Regen(new RegenParams(0.01));
							}
							list2.Add(buVector5.ToPoint3D(mesh.BoxMax));
							list2.Add(buVector5.ToPoint3D(mesh.BoxMin));
							Meshd val = buMWCalcs.ConvertToMWMesh(mesh);
							if (val != null)
							{
								list.Add(val);
							}
						}
					}
					else
					{
						Mesh mesh2 = ((Surface)copiedEnt[i]).ConvertToMesh();
						if (mesh2.BoxMax == null)
						{
							mesh2.Regen(new RegenParams(0.01));
						}
						list2.Add(buVector5.ToPoint3D(mesh2.BoxMax));
						list2.Add(buVector5.ToPoint3D(mesh2.BoxMin));
						Meshd val2 = buMWCalcs.ConvertToMWMesh(mesh2);
						if (val2 != null)
						{
							list.Add(val2);
						}
					}
					continue;
				}
				if (clsInit.cMwCalc.buCamDataParameter.Options.StockHeight > 0.0)
				{
					if (!(copiedEnt[i].BoxMax == null))
					{
						list2.Add(buVector5.ToPoint3D(copiedEnt[i].BoxMax));
						list2.Add(buVector5.ToPoint3D(copiedEnt[i].BoxMin));
					}
					else
					{
						copiedEnt[i].Regen(new RegenParams(0.01));
						list2.Add(buVector5.ToPoint3D(copiedEnt[i].BoxMax));
						list2.Add(buVector5.ToPoint3D(copiedEnt[i].BoxMin));
					}
				}
				Meshd val3 = buMWCalcs.ConvertToMWMesh((Mesh)copiedEnt[i]);
				if (val3 != null)
				{
					list.Add(val3);
				}
			}
			if (list.Count != 0)
			{
				if (list2.Count > 0)
				{
					Point3D min = new Point3D();
					Point3D max = new Point3D();
					Utility.BoundingBox(list2, out min, out max);
					Mesh mesh3 = null;
					mesh3 = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
					mesh3.Translate(min.X, min.Y, min.Z);
					if (mesh3 != null)
					{
						if (clsInit.cMwCalc.Stock == null)
						{
							clsInit.cMwCalc.Stock = new List<Meshd>();
						}
						Meshd item7 = buMWCalcs.ConvertToMWMesh(mesh3);
						clsInit.cMwCalc.Stock.Add(item7);
					}
				}
				if (!clsInit.cMwCalc.CalculateContouring(Tool, list, edgeCurves, calcType, MWCalcOptions, ref mWCalculationResult))
				{
					return -1;
				}
				Cam = new camTp();
				buMWCalcs.CopyCamParameter(mWCalculationResult.geoLib, mWCalculationResult.buCamParamters, ref buMWCalcs.varCamContouringPars);
				_ = mWCalculationResult.geoLib.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
				_ = buMWCalcs.varCamContouringPars.mwPar.MachParam.TpCalculationMethodsParams.ContouringBasedTpCalcParams.AxialShift;
				IterateThroughEntireStructure5X(mWCalculationResult.ToolPathCalc, 0, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
				Cam.TypeCam = CamType.None;
				Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
				Cam.Tool = new ToolBase5(mWCalculationResult.Tool);
				Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
				Cam.Parameter = new camParameters5(mWCalculationResult.buCamParamters);
				Cam.mwParameter = (object)new MachiningParams(mWCalculationResult.geoLib.MachParam);
				Cam.CamID = 0;
				buVector5.CopyEntities(copiedEnt, ref Cam.RefEntities);
				return 1;
			}
			buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
			return -1;
		}
		MessageBox.Show(AppLanguage.CadCamMessages[57]);
		return -1;
	}

	public int doSurface(MWCalculationOptions MWCalcOptions, ToolBase5 ToolSelected, ref camTp Cam, ref camResult Result)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		ToolBase5 Tool = new ToolBase5(ToolSelected);
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		MWCalculationResult mWCalculationResult = new MWCalculationResult();
		TriangleMeshBasedTpCalcParamsPattern calcType = TriangleMeshBasedTpCalcParamsPattern.TcTmbRough;
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> selectedEntities2 = new List<Entity>();
		new List<Entity>();
		new List<buMWCurveEntities>();
		new buMWCurveEntities();
		SelectionOption option = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
		bool flag = true;
		Result = new camResult();
		if ((Tool.Purpose == ToolPurpose.Drilling) | (Tool.Purpose == ToolPurpose.DiamondCut))
		{
			flag = false;
		}
		if (flag)
		{
			if (CamEntities.Count != 0)
			{
				buVector5.CopyEntities(CamEntities, ref selectedEntities);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			}
			else
			{
				clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
				option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false);
				clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
			}
			if (clsInit.cMwCalc.mwCamDataParameter != null)
			{
				clsInit.cMwCalc.mwCamDataParameter.Dispose();
			}
			clsInit.cMwCalc.mwCamDataParameter = new GeoLib(Unit.Metric);
			buMWCalcs.CopyGeoLibProperties(varMWCamSurfaceParallelPars, clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cMwCalc.mwCamDataParameter.MachParam = new MachiningParams(varMWCamSurfaceParallelPars.MachParam);
			clsInit.cMwCalc.buCamDataParameter = new camParameters5(varbuCamSurfaceParallelPars);
			ToolDataToCamData(Tool, ref clsInit.cMwCalc.buCamDataParameter, ref clsInit.cMwCalc.mwCamDataParameter);
			clsInit.cVector5.BoxSizeCalculate(selectedEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
			if (MWCalcOptions.CheckBoxBounding)
			{
				if (MWCalcOptions.BoxBoundingMax != MWCalcOptions.BoxBoundingMin)
				{
					if (MWCalcOptions.BoxBoundingMax.X != MWCalcOptions.BoxBoundingMin.X)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.X)
						{
							CalculationError item = new CalculationError(AppLanguage.CadCamError[1], 0);
							Result.Errors.Add(item);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.X)
						{
							CalculationError item2 = new CalculationError(AppLanguage.CadCamError[0], 0);
							Result.Errors.Add(item2);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Y != MWCalcOptions.BoxBoundingMin.Y)
					{
						if (MaxPoint.Y > MWCalcOptions.BoxBoundingMax.Y)
						{
							CalculationError item3 = new CalculationError(AppLanguage.CadCamError[3], 0);
							Result.Errors.Add(item3);
						}
						if (MinPoint.Y < MWCalcOptions.BoxBoundingMin.Y)
						{
							CalculationError item4 = new CalculationError(AppLanguage.CadCamError[2], 0);
							Result.Errors.Add(item4);
						}
					}
					if (MWCalcOptions.BoxBoundingMax.Z != MWCalcOptions.BoxBoundingMin.Z)
					{
						if (MaxPoint.X > MWCalcOptions.BoxBoundingMax.Z)
						{
							CalculationError item5 = new CalculationError(AppLanguage.CadCamError[5], 0);
							Result.Errors.Add(item5);
						}
						if (MinPoint.X < MWCalcOptions.BoxBoundingMin.Z)
						{
							CalculationError item6 = new CalculationError(AppLanguage.CadCamError[4], 0);
							Result.Errors.Add(item6);
						}
					}
				}
				if (Result.Errors.Count > 0)
				{
					return -1;
				}
			}
			CamDataToolData(clsInit.cMwCalc.buCamDataParameter, clsInit.cMwCalc.mwCamDataParameter, ref Tool);
			List<Surface> list = new List<Surface>();
			List<Meshd> list2 = new List<Meshd>();
			clsInit.cMwCalc.Stock = null;
			List<Point3D> list3 = new List<Point3D>();
			for (int i = 0; i <= selectedEntities.Count - 1; i++)
			{
				if (!(selectedEntities[i] is Mesh))
				{
					if (!(selectedEntities[i] is Surface))
					{
						if (!(selectedEntities[i] is Brep))
						{
							continue;
						}
						((Brep)selectedEntities[i]).Regen(new RegenParams(0.01));
						Surface[] array = ((Brep)selectedEntities[i]).ConvertToSurfaces();
						if (array == null)
						{
							continue;
						}
						for (int j = 0; j <= array.Length - 1; j++)
						{
							if (array[j].BoxMax == null)
							{
								array[j].Regen(new RegenParams(0.01));
							}
							list3.Add(buVector5.ToPoint3D(array[j].BoxMax));
							list3.Add(buVector5.ToPoint3D(array[j].BoxMin));
							Surface val = buMWCalcs.ConvertToMWSurface(array[j]);
							if (val != null)
							{
								list.Add(val);
							}
						}
					}
					else
					{
						Surface surface = (Surface)selectedEntities[i];
						if (surface.BoxMax == null)
						{
							surface.Regen(new RegenParams(0.01));
						}
						list3.Add(buVector5.ToPoint3D(surface.BoxMax));
						list3.Add(buVector5.ToPoint3D(surface.BoxMin));
						Surface val2 = buMWCalcs.ConvertToMWSurface(surface);
						if (val2 != null)
						{
							list.Add(val2);
							Mesh mesh = surface.ConvertToMesh();
							list2.Add(buMWCalcs.ConvertToMWMesh(mesh));
						}
					}
					continue;
				}
				Meshd val3 = buMWCalcs.ConvertToMWMesh((Mesh)selectedEntities[i]);
				if (val3 != null)
				{
					list2.Add(val3);
					if (selectedEntities[i].BoxMax == null)
					{
						selectedEntities[i].Regen(new RegenParams(0.01));
					}
					list3.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMax));
					list3.Add(buVector5.ToPoint3D(selectedEntities[i].BoxMin));
				}
			}
			if (!((list.Count == 0) & (list2.Count == 0)))
			{
				if (list3.Count > 0)
				{
					Point3D min = new Point3D();
					Point3D max = new Point3D();
					Utility.BoundingBox(list3, out min, out max);
					Mesh mesh2 = null;
					mesh2 = Mesh.CreateBox(max.X - min.X, max.Y - min.Y, clsInit.cMwCalc.buCamDataParameter.Options.StockHeight);
					mesh2.Translate(min.X, min.Y, min.Z);
					if (mesh2 != null)
					{
						if (clsInit.cMwCalc.Stock == null)
						{
							clsInit.cMwCalc.Stock = new List<Meshd>();
						}
						Meshd item7 = buMWCalcs.ConvertToMWMesh(mesh2);
						clsInit.cMwCalc.Stock.Add(item7);
					}
				}
				if (!clsInit.cMwCalc.CalculateSurface(Tool, list, list2, calcType, MWCalcOptions, ref mWCalculationResult))
				{
					return -1;
				}
				Cam = new camTp();
				buMWCalcs.CopyCamParameter(mWCalculationResult.geoLib, mWCalculationResult.buCamParamters, ref buMWCalcs.varCamSurfacePars);
				IterateThroughEntireStructure5X(mWCalculationResult.ToolPathCalc, 0, mWCalculationResult.buCamParamters, mWCalculationResult.geoLib, ref Cam);
				Cam.TypeCam = CamType.None;
				Cam.OperationVector = new Vector3D(0.0, 0.0, 1.0);
				Cam.Tool = new ToolBase5(mWCalculationResult.Tool);
				Cam.MWCalcOptions = new MWCalculationOptions(MWCalcOptions);
				Cam.Parameter = new camParameters5(mWCalculationResult.buCamParamters);
				Cam.mwParameter = (object)new MachiningParams(mWCalculationResult.geoLib.MachParam);
				Cam.CamID = 0;
				buVector5.CopyEntities(selectedEntities, ref Cam.RefEntities);
				return 1;
			}
			buString.MessageBoxError(AppLanguage.CadCamMessages[79]);
			return -1;
		}
		MessageBox.Show(AppLanguage.CadCamMessages[57]);
		return -1;
	}

	public void IterateThroughEntireStructure3X(ToolPath calculatedToolPath, int CamID, camParameters5 camPars, GeoLib mwPars, ref camTp CamResult, bool AllG1 = false)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		Point3D item = new Point3D();
		CamResult = new camTp();
		CalculationEventArg calculationEventArg = new CalculationEventArg();
		List<Point3D> list = new List<Point3D>();
		foreach (TPPass pass in calculatedToolPath.Passes)
		{
			num++;
			double num11 = (double)num / (double)calculatedToolPath.Passes.Count();
			if (num11 > 1.0)
			{
				num11 = 1.0;
			}
			Application.DoEvents();
			calculationEventArg.OverallProgressPercentage = num11 * 100.0;
			num2 = 0;
			foreach (TPSlice slice in pass.Slices)
			{
				num2++;
				double num12 = Convert.ToDouble(num2) / (double)pass.Slices.Count();
				if (num12 > 1.0)
				{
					num12 = 1.0;
				}
				calculationEventArg.ActiveProgressPercentage = num12 * 100.0;
				calculationEventArg.Job = "Iteration";
				calculationEventArg.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
				clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
				bool flag = false;
				bool flag2 = false;
				num4 = 0;
				if (num2 < 1)
				{
					continue;
				}
				camTpPoint camTpPoint2 = new camTpPoint();
				foreach (TPSection section in slice.Sections)
				{
					num4++;
					ToolPathLinkType toolPathLinkType = ToolPathLinkType.NotALink;
					if (!(section is TPContour))
					{
						num5++;
						flag = false;
						flag2 = true;
						TPLink val = (TPLink)(object)((section is TPLink) ? section : null);
						toolPathLinkType = val.LinkType;
					}
					else
					{
						num3++;
						flag = true;
						flag2 = false;
					}
					List<ICurve> list2 = new List<ICurve>();
					int num13 = 0;
					foreach (TPSectionFit sectionFit in section.SectionFits)
					{
						num13++;
						TPHelixFit val2 = (TPHelixFit)(object)((sectionFit is TPHelixFit) ? sectionFit : null);
						bool flag3 = false;
						if (val2 != null && !buCompare.EQ(val2.Helix.StartPoint.Z, val2.Helix.EndPoint.Z))
						{
							flag3 = true;
						}
						if (AllG1)
						{
							flag3 = true;
						}
						if (!(val2 != null && !flag3))
						{
							num6++;
							foreach (CNCMove move in sectionFit.Moves)
							{
								num8++;
								CNC5AxMove val3 = (CNC5AxMove)(object)((move is CNC5AxMove) ? move : null);
								if (val3 == null)
								{
									continue;
								}
								TpPnt9D tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z);
								if (!((CNCMove)val3).IsRapid)
								{
									tpPnt9D.Type = 1;
								}
								else
								{
									tpPnt9D.Type = 0;
								}
								tpPnt9D.Feed = ((CNCMove)val3).FeedRate;
								list.Add(new Point3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z));
								if (!flag & (list.Count > 1))
								{
									CamMoveType MoveType = CamMoveType.G0;
									GetCamMoveType(list, CamResult.OperationVector, val3, ref MoveType);
									buLinearPathCam buLinearPathCam2 = new buLinearPathCam(list);
									buLinearPathCam2.CamID = CamID;
									buLinearPathCam2.MoveType = MoveType;
									buLinearPathCam2.ColorMethod = colorMethodType.byEntity;
									buLinearPathCam2.isLink = flag2;
									buLinearPathCam2.LinkType = (CamLinkType)Convert.ToInt32(toolPathLinkType);
									if (MoveType != CamMoveType.G0)
									{
										if (MoveType != CamMoveType.Leave)
										{
											if (MoveType != CamMoveType.Plunge)
											{
												if (MoveType != CamMoveType.G1)
												{
													buLinearPathCam2.Color = clsVar.varCam.CamOtherDraw.Color;
													CamResult.EntitiesOther.Add(buLinearPathCam2);
												}
												else if (!flag2)
												{
													buLinearPathCam2.Color = clsVar.varCam.CamG1Draw.Color;
													CamResult.EntitiesG1.Add(buLinearPathCam2);
													CamResult.EntitiesG1Orj.Add(new buLinearPathCam(buLinearPathCam2));
												}
												else if (clsInit.cMwCalc.SettingsRuntime.CamLinkEntitiesAsG1)
												{
													buLinearPathCam2.Color = clsVar.varCam.CamG1Draw.Color;
													CamResult.EntitiesG1.Add(buLinearPathCam2);
													CamResult.EntitiesG1Orj.Add(new buLinearPathCam(buLinearPathCam2));
												}
											}
											else
											{
												tpPnt9D.PlungeAxisMovement = true;
												buLinearPathCam2.Color = clsVar.varCam.CamPlungeDraw.Color;
												CamResult.EntitiesPlunge.Add(buLinearPathCam2);
											}
										}
										else
										{
											tpPnt9D.LeaveAxisMovement = true;
											buLinearPathCam2.Color = clsVar.varCam.CamLeaveDraw.Color;
											CamResult.EntitiesLeave.Add(buLinearPathCam2);
										}
									}
									else
									{
										buLinearPathCam2.Color = clsVar.varCam.CamG0Draw.Color;
										CamResult.EntitiesG0.Add(buLinearPathCam2);
									}
									item = buVector5.ToPoint3D(list[list.Count - 1]);
									list.Clear();
									list.Add(item);
								}
								if ((flag & (tpPnt9D.Type == 1)) && camTpPoint2.Points.Count > 0)
								{
									List<Point3D> list3 = new List<Point3D>();
									list3.Add(new Point3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z));
									list3.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
									buLinearPathCam buLinearPathCam3 = new buLinearPathCam(list3);
									buLinearPathCam3.CamID = CamID;
									buLinearPathCam3.MoveType = CamMoveType.G1;
									buLinearPathCam3.ColorMethod = colorMethodType.byEntity;
									buLinearPathCam3.isLink = flag2;
									buLinearPathCam3.LinkType = (CamLinkType)Convert.ToInt32(toolPathLinkType);
									buLinearPathCam3.Color = clsVar.varCam.CamG1Draw.Color;
									CamResult.EntitiesG1Orj.Add(buLinearPathCam3);
								}
								camTpPoint2.Points.Add(tpPnt9D);
								num9++;
							}
							if (list.Count > 0)
							{
								item = buVector5.ToPoint3D(list[list.Count - 1]);
							}
						}
						else
						{
							num7++;
							if (!(val2.Helix.ArcSweep <= 2.8015926535897933))
							{
								Arc Arc = null;
								Arc Arc2 = null;
								bool flag4 = false;
								HelixToSplitedArcs(val2.Helix, ref Arc, ref Arc2);
								TpPnt9D tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									flag4 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc.StartPoint.X, Arc.StartPoint.Y, Arc.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								else
								{
									flag4 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc.EndPoint.X, Arc.EndPoint.Y, Arc.EndPoint.Z);
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsVar.varCam.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag4)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val4 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val4.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
								}
								else
								{
									CamResult.EntitiesG1Orj.Add(new buArcCam(buArcCam2));
									list2.Add(buArcCam2);
								}
								tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									flag4 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								else
								{
									flag4 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsVar.varCam.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag4)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val5 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val5.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
								}
								else
								{
									CamResult.EntitiesG1Orj.Add(new buArcCam(buArcCam2));
									list2.Add(buArcCam2);
								}
								item = ((val2.Helix.CenterOrientation.Z > 0.0) ? buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint));
								list.Clear();
								list.Add(item);
							}
							else
							{
								TpPnt9D tpPnt9D3 = new TpPnt9D();
								tpPnt9D3.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D3.IsArc = true;
								HelixToArcData(val2.Helix, ref tpPnt9D3.ArcData);
								tpPnt9D3.P9 = new Pnt9D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								buArcCam buArcCam3 = null;
								buArcCam3 = new buArcCam(Plane.XY, tpPnt9D3.ArcData.CenterPoint, tpPnt9D3.ArcData.Radius, tpPnt9D3.ArcData.StartPoint, tpPnt9D3.ArcData.EndPoint, flip: false);
								buArcCam3.MoveType = CamMoveType.G1;
								buArcCam3.CamID = CamID;
								buArcCam3.Color = clsVar.varCam.CamG1Draw.Color;
								buArcCam3.ColorMethod = colorMethodType.byEntity;
								buArcCam3.Regen(new RegenParams(0.001));
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									tpPnt9D3.ArcData.isCW = true;
									tpPnt9D3.Type = 2;
								}
								else
								{
									tpPnt9D3.ArcData.isCW = false;
									tpPnt9D3.Type = 3;
								}
								if (!buCompare5.EQ(new Point3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z), buArcCam3.StartPoint))
								{
									buArcCam3.isReverse = true;
								}
								camTpPoint2.Points.Add(tpPnt9D3);
								if (!flag)
								{
									TPLink val6 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val6.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam3);
									}
								}
								else
								{
									if (CamResult.EntitiesG1Orj.Count > 0)
									{
										Point3D point3D = new Point3D();
										point3D = ((!(CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1] is buArcCam)) ? buVector5.ToPoint3D(((ICurve)CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).EndPoint) : ((!((buArcCam)CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).isReverse) ? buVector5.ToPoint3D(((ICurve)CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).EndPoint) : buVector5.ToPoint3D(((ICurve)CamResult.EntitiesG1Orj[CamResult.EntitiesG1Orj.Count - 1]).StartPoint)));
										if (!buCompare5.EQ(point3D, buArcCam3.StartPoint))
										{
											buArcCam3.isReverse = true;
										}
									}
									CamResult.EntitiesG1Orj.Add(new buArcCam(buArcCam3));
									List<Point3D> list4 = new List<Point3D>();
									for (int i = 0; i <= buArcCam3.Vertices.Length - 1; i++)
									{
										list4.Add(new Point3D(buArcCam3.Vertices[i].X, buArcCam3.Vertices[i].Y, buArcCam3.Vertices[i].Z));
									}
									if (tpPnt9D3.Type == 2)
									{
										list4.Reverse();
									}
									if (list4.Count > 1)
									{
										buLinearPathCam buLinearPathCam4 = new buLinearPathCam(list4);
										buLinearPathCam4.MoveType = CamMoveType.G1;
										buLinearPathCam4.Color = clsVar.varCam.CamG1Draw.Color;
										buLinearPathCam4.CamID = CamID;
										buLinearPathCam4.isLink = flag2;
										buLinearPathCam4.LinkType = (CamLinkType)Convert.ToInt32(toolPathLinkType);
										list2.Add(buLinearPathCam4);
									}
								}
								item = new Point3D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								list.Clear();
								list.Add(item);
							}
						}
						if (list.Count <= 1)
						{
							continue;
						}
						if (!flag)
						{
							if (list.Count > 1)
							{
								buLinearPathCam buLinearPathCam5 = new buLinearPathCam(list);
								buLinearPathCam5.CamID = CamID;
								buLinearPathCam5.isLink = flag2;
								buLinearPathCam5.LinkType = (CamLinkType)Convert.ToInt32(toolPathLinkType);
								CamResult.EntitiesG0.Add(buLinearPathCam5);
							}
						}
						else if (list.Count > 1)
						{
							buLinearPathCam buLinearPathCam6 = new buLinearPathCam(list);
							buLinearPathCam6.MoveType = CamMoveType.G1;
							buLinearPathCam6.Color = clsVar.varCam.CamG1Draw.Color;
							buLinearPathCam6.CamID = CamID;
							buLinearPathCam6.isLink = flag2;
							buLinearPathCam6.LinkType = (CamLinkType)Convert.ToInt32(toolPathLinkType);
							list2.Add(buLinearPathCam6);
						}
						list.Clear();
						list.Add(item);
					}
					if (list2.Count > 0)
					{
						List<Point3D> list5 = new List<Point3D>();
						for (int j = 0; j <= list2.Count - 1; j++)
						{
							Entity entity = (Entity)list2[j];
							List<Point3D> PointList = new List<Point3D>();
							buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
							if (entity.GetType() == typeof(buArcCam) && ((buArcCam)entity).isReverse)
							{
								PointList.Reverse();
							}
							int num14 = 0;
							if (j > 0)
							{
								num14 = 1;
							}
							for (int k = num14; k <= PointList.Count - 1; k++)
							{
								list5.Add(new Point3D(PointList[k].X, PointList[k].Y, PointList[k].Z));
							}
						}
						if (list5.Count > 1)
						{
							buLinearPathCam buLinearPathCam7 = new buLinearPathCam(list5);
							buLinearPathCam7.CamID = CamID;
							buLinearPathCam7.MoveType = CamMoveType.G1;
							buLinearPathCam7.Color = clsVar.varCam.CamG1Draw.Color;
							buLinearPathCam7.isLink = flag2;
							buLinearPathCam7.LinkType = (CamLinkType)Convert.ToInt32(toolPathLinkType);
							CamResult.EntitiesG1.Add(buLinearPathCam7);
						}
						list2.Clear();
					}
					num10++;
				}
				if (camTpPoint2.Points.Count > 0)
				{
					CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[0]));
				}
				for (int l = 1; l <= camTpPoint2.Points.Count - 1; l++)
				{
					List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
					double num15 = clsInit.cVector.Length3D(new Pnt3D(camTpPoint2.Points[l - 1].P9.X, camTpPoint2.Points[l - 1].P9.Y, camTpPoint2.Points[l - 1].P9.Z), new Pnt3D(camTpPoint2.Points[l].P9.X, camTpPoint2.Points[l].P9.Y, camTpPoint2.Points[l].P9.Z));
					if (camTpPoint2.Points[l].Type != 0)
					{
						if (camTpPoint2.Points[l].Type != 1)
						{
							if ((camTpPoint2.Points[l].Type == 2) | (camTpPoint2.Points[l].Type == 3))
							{
								num15 = camTpPoint2.Points[l].ArcData.Length;
								Arc arc = new Arc(Plane.XY, camTpPoint2.Points[l].ArcData.CenterPoint, camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartPoint, camTpPoint2.Points[l].ArcData.EndPoint, flip: false);
								arc.Regen(0.01);
								List<Pnt3D> Vertices = new List<Pnt3D>();
								if (camTpPoint2.Points[l].ArcData.isReverse)
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, camPars.Runtime.SimG1DevideLength, new WorkPlane(), ref Vertices);
									Vertices.Reverse();
								}
								else
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, camPars.Runtime.SimG1DevideLength, new WorkPlane(), ref Vertices);
								}
								if (Vertices.Count > 0)
								{
									for (int m = 0; m <= Vertices.Count - 1; m++)
									{
										Pnt6DSimMove item2 = new Pnt6DSimMove(Vertices[m].X, Vertices[m].Y, Vertices[m].Z);
										CalculatedPoints.Add(item2);
									}
								}
							}
						}
						else
						{
							int count = Convert.ToInt32(num15 / camPars.Runtime.SimG1DevideLength);
							clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count, ref CalculatedPoints);
						}
					}
					else
					{
						int count2 = Convert.ToInt32(num15 / camPars.Runtime.SimG0DevideLength);
						clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count2, ref CalculatedPoints);
					}
					if (CalculatedPoints.Count < 2)
					{
						CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]));
						continue;
					}
					CalculatedPoints.RemoveAt(0);
					CamResult.SimilationPoint.SimMove.AddRange(CalculatedPoints);
				}
				CamResult.CamID = CamID;
				CamResult.CamPoints.Add(camTpPoint2);
			}
		}
	}

	public void IterateThroughEntireStructure4X(ToolPath calculatedToolPath, int CamID, camParameters5 camPars, GeoLib mwPars, ref camTp CamResult)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		double num11 = 0.0;
		Point3D item = new Point3D();
		Point3D point3D = new Point3D();
		CamResult = new camTp();
		CalculationEventArg calculationEventArg = new CalculationEventArg();
		List<Point3D> list = new List<Point3D>();
		foreach (TPPass pass in calculatedToolPath.Passes)
		{
			num++;
			double num12 = (double)num / (double)calculatedToolPath.Passes.Count();
			if (num12 > 1.0)
			{
				num12 = 1.0;
			}
			Application.DoEvents();
			calculationEventArg.OverallProgressPercentage = num12 * 100.0;
			num2 = 0;
			foreach (TPSlice slice in pass.Slices)
			{
				num2++;
				double num13 = Convert.ToDouble(num2) / (double)pass.Slices.Count();
				if (num13 > 1.0)
				{
					num13 = 1.0;
				}
				calculationEventArg.ActiveProgressPercentage = num13 * 100.0;
				calculationEventArg.Job = "Iteration";
				calculationEventArg.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
				clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
				bool flag = false;
				double num14 = 0.0;
				ToolPathLinkType toolPathLinkType = ToolPathLinkType.NotALink;
				num4 = 0;
				if (num2 < 0)
				{
					continue;
				}
				camTpPoint camTpPoint2 = new camTpPoint();
				MWIterationOption Option = new MWIterationOption();
				List<Pnt6D> P = new List<Pnt6D>();
				foreach (TPSection section in slice.Sections)
				{
					if (!(section is TPContour))
					{
						int nextSectionOfTP = GetNextSectionOfTP(slice.Sections, num4, ref Option, ref P);
						if (nextSectionOfTP == 1)
						{
							num14 = Option.StartPoint.C;
						}
						num5++;
						flag = false;
						TPLink val = (TPLink)(object)((section is TPLink) ? section : null);
						toolPathLinkType = val.LinkType;
					}
					else
					{
						num3++;
						flag = true;
					}
					List<ICurve> list2 = new List<ICurve>();
					foreach (TPSectionFit sectionFit in section.SectionFits)
					{
						TPHelixFit val2 = (TPHelixFit)(object)((sectionFit is TPHelixFit) ? sectionFit : null);
						bool flag2 = false;
						if (val2 != null && !buCompare.EQ(val2.Helix.StartPoint.Z, val2.Helix.EndPoint.Z))
						{
							flag2 = true;
						}
						if (!((val2 != null && !flag2) & !camPars.Strategy.ArcToPoints))
						{
							num6++;
							num8 = 0;
							num9 = 0;
							foreach (CNCMove move in sectionFit.Moves)
							{
								CNC5AxMove val3 = (CNC5AxMove)(object)((move is CNC5AxMove) ? move : null);
								double num15 = 0.0;
								if (val3 != null)
								{
									TpPnt9D tpPnt9D = new TpPnt9D();
									if (camTpPoint2.Points.Count == 0 && !flag)
									{
										tpPnt9D.P9 = new Pnt9D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z);
										tpPnt9D.Type = 0;
										tpPnt9D.PlungeAxisMovement = true;
										tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
										camTpPoint2.Points.Add(tpPnt9D);
									}
									if (flag)
									{
										num15 = clsInit.cVector5.PointAngle(new Point3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z), point3D, Plane.XY);
									}
									else
									{
										if (toolPathLinkType == ToolPathLinkType.Approach || toolPathLinkType == ToolPathLinkType.ConnectionNotClearanceArea || toolPathLinkType == ToolPathLinkType.ConnectionClearanceArea)
										{
											num15 = num14;
										}
										if (toolPathLinkType == ToolPathLinkType.Retract)
										{
											num15 = num11;
										}
									}
									num15 = ((!camPars.Strategy.UseContantTangent) ? (num15 + camPars.Strategy.TangentOffset) : camPars.Strategy.ContantTangent);
									if (flag)
									{
										double num16 = num15 - num11;
										double num17 = Math.Ceiling(Math.Abs(num16) / 360.0);
										if (Math.Abs(num16) > 180.0)
										{
											num15 = ((num16 > 0.0) ? (num15 - 360.0 * num17) : (num15 + 360.0 * num17));
										}
										if (num15 > camPars.Strategy.MaxTangentValue)
										{
											double num18 = camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
											num15 = ((num18 >= 360.0) ? (num15 - 360.0) : (num15 - (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue)));
										}
										if (num15 < camPars.Strategy.MinTangentValue)
										{
											double num19 = camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
											num15 = ((num19 >= 360.0) ? (num15 + 360.0) : (num15 + (camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue)));
										}
										num16 = num15 - num11;
										if ((Math.Abs(num16) > camPars.Strategy.AngleLimit) & camPars.Strategy.UseTangentLimit)
										{
											tpPnt9D = new TpPnt9D();
											tpPnt9D.P9 = new Pnt9D(point3D.X, point3D.Y, point3D.Z + mwPars.MachParam.LinkParams.RetractPlaneIncremental, 0.0, 0.0, num11);
											tpPnt9D.Type = 1;
											tpPnt9D.Feed = mwPars.MachParam.RetractFeedRate;
											tpPnt9D.PlungeAxisMovement = true;
											tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
											camTpPoint2.Points.Add(tpPnt9D);
											tpPnt9D = new TpPnt9D();
											tpPnt9D.P9 = new Pnt9D(point3D.X, point3D.Y, point3D.Z + mwPars.MachParam.LinkParams.RetractPlaneIncremental, 0.0, 0.0, num15);
											tpPnt9D.Type = 0;
											tpPnt9D.Feed = mwPars.MachParam.RapidFeedrate;
											tpPnt9D.PlungeAxisMovement = false;
											camTpPoint2.Points.Add(tpPnt9D);
											tpPnt9D = new TpPnt9D();
											tpPnt9D.P9 = new Pnt9D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, num15);
											tpPnt9D.Type = 1;
											tpPnt9D.Feed = mwPars.MachParam.PlungeFeedRate;
											tpPnt9D.PlungeAxisMovement = true;
											tpPnt9D.PlungeAction = CamPlungeActionType.GoDownAproach;
											camTpPoint2.Points.Add(tpPnt9D);
										}
									}
									if ((num15 > camPars.Strategy.MaxTangentValue) & (Math.Abs(camPars.Strategy.MinTangentValue - camPars.Strategy.MaxTangentValue) > 0.001))
									{
										num15 = ((camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue > 360.0) ? (num15 - 360.0) : (num15 - 180.0));
									}
									if ((num15 < camPars.Strategy.MinTangentValue) & (Math.Abs(camPars.Strategy.MinTangentValue - camPars.Strategy.MaxTangentValue) > 0.001))
									{
										num15 = ((camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue > 360.0) ? (num15 + 360.0) : (num15 + 180.0));
									}
									tpPnt9D = new TpPnt9D();
									tpPnt9D.P9 = new Pnt9D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z, 0.0, 0.0, Math.Round(num15, 5));
									if (!((CNCMove)val3).IsRapid)
									{
										tpPnt9D.Type = 1;
									}
									else
									{
										tpPnt9D.Type = 0;
									}
									tpPnt9D.Feed = ((CNCMove)val3).FeedRate;
									list.Add(new Point3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z));
									if (!flag & (list.Count > 1))
									{
										CamMoveType MoveType = CamMoveType.G0;
										GetCamMoveType(list, CamResult.OperationVector, val3, ref MoveType);
										buLinearPathCam buLinearPathCam2 = new buLinearPathCam(list);
										buLinearPathCam2.CamID = CamID;
										buLinearPathCam2.MoveType = MoveType;
										buLinearPathCam2.ColorMethod = colorMethodType.byEntity;
										if (MoveType != CamMoveType.G0)
										{
											if (MoveType != CamMoveType.Leave)
											{
												if (MoveType != CamMoveType.Plunge)
												{
													buLinearPathCam2.Color = clsVar.varCam.CamOtherDraw.Color;
													CamResult.EntitiesOther.Add(buLinearPathCam2);
												}
												else
												{
													buLinearPathCam2.Color = clsVar.varCam.CamPlungeDraw.Color;
													CamResult.EntitiesPlunge.Add(buLinearPathCam2);
												}
											}
											else
											{
												buLinearPathCam2.Color = clsVar.varCam.CamLeaveDraw.Color;
												CamResult.EntitiesLeave.Add(buLinearPathCam2);
											}
										}
										else
										{
											buLinearPathCam2.Color = clsVar.varCam.CamG0Draw.Color;
											CamResult.EntitiesG0.Add(buLinearPathCam2);
										}
										item = buVector5.ToPoint3D(list[list.Count - 1]);
										list.Clear();
										list.Add(item);
									}
									camTpPoint2.Points.Add(tpPnt9D);
									point3D = new Point3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z);
									num11 = num15;
									num9++;
								}
								num8++;
							}
							if (list.Count > 0)
							{
								item = buVector5.ToPoint3D(list[list.Count - 1]);
							}
						}
						else
						{
							num7++;
							TpPnt9D tpPnt9D2 = new TpPnt9D();
							new List<Pnt3D>();
							tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
							tpPnt9D2.IsArc = true;
							tpPnt9D2.ArcData.StartPoint = new Point3D(val2.Helix.StartPoint.X, val2.Helix.StartPoint.Y, val2.Helix.StartPoint.Z);
							tpPnt9D2.ArcData.EndPoint = new Point3D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
							tpPnt9D2.ArcData.CenterPoint = new Point3D(val2.Helix.CenterPoint.X, val2.Helix.CenterPoint.Y, val2.Helix.CenterPoint.Z);
							tpPnt9D2.ArcData.SweepAngle = val2.Helix.ArcSweep;
							tpPnt9D2.ArcData.Radius = Point3D.Distance(tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.CenterPoint);
							tpPnt9D2.ArcData.Length = val2.Helix.ArcSweep * tpPnt9D2.ArcData.Radius;
							tpPnt9D2.ArcData.StartAngle = clsInit.cVector5.PointAngle(tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.CenterPoint, Plane.XY);
							tpPnt9D2.ArcData.EndAngle = clsInit.cVector5.PointAngle(tpPnt9D2.ArcData.EndPoint, tpPnt9D2.ArcData.CenterPoint, Plane.XY);
							tpPnt9D2.P9 = new Pnt9D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
							Plane arcPlane = new Plane(new Vector3D(val2.Helix.CenterOrientation.X, val2.Helix.CenterOrientation.Y, val2.Helix.CenterOrientation.Z));
							buArcCam buArcCam2 = new buArcCam(arcPlane, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
							buArcCam2.MoveType = CamMoveType.G1;
							buArcCam2.CamID = CamID;
							buArcCam2.Color = clsVar.varCam.CamG1Draw.Color;
							buArcCam2.ColorMethod = colorMethodType.byEntity;
							buArcCam2.Regen(new RegenParams(0.01));
							if (!Utility.IsOrientedClockwise(buArcCam2.Vertices))
							{
								if (tpPnt9D2.ArcData.StartAngle > tpPnt9D2.ArcData.EndAngle)
								{
									tpPnt9D2.ArcData.StartAngle -= 360.0;
								}
								tpPnt9D2.ArcData.isCW = false;
								tpPnt9D2.Type = 3;
							}
							else
							{
								if (tpPnt9D2.ArcData.EndAngle > tpPnt9D2.ArcData.StartAngle)
								{
									tpPnt9D2.ArcData.EndAngle -= 360.0;
								}
								tpPnt9D2.ArcData.isCW = true;
								tpPnt9D2.Type = 2;
							}
							camTpPoint2.Points.Add(tpPnt9D2);
							if (!flag)
							{
								if (toolPathLinkType == ToolPathLinkType.LeadIn)
								{
									CamResult.EntitiesLeadIn.Add(buArcCam2);
								}
								if (toolPathLinkType == ToolPathLinkType.LeadOut)
								{
									CamResult.EntitiesLeadOut.Add(buArcCam2);
								}
								if (toolPathLinkType == ToolPathLinkType.Approach)
								{
									CamResult.EntitiesPlunge.Add(buArcCam2);
								}
								if (toolPathLinkType == ToolPathLinkType.Retract)
								{
									CamResult.EntitiesLeave.Add(buArcCam2);
								}
							}
							else
							{
								list2.Add(buArcCam2);
							}
							item = buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint);
							list.Clear();
							list.Add(item);
						}
						if (list.Count <= 1)
						{
							continue;
						}
						if (!flag)
						{
							if (list.Count > 1)
							{
								buLinearPathCam buLinearPathCam3 = new buLinearPathCam(list);
								buLinearPathCam3.CamID = CamID;
								CamResult.EntitiesG0.Add(buLinearPathCam3);
							}
						}
						else if (list.Count > 1)
						{
							buLinearPathCam buLinearPathCam4 = new buLinearPathCam(list);
							buLinearPathCam4.MoveType = CamMoveType.G1;
							buLinearPathCam4.Color = clsVar.varCam.CamG1Draw.Color;
							buLinearPathCam4.CamID = CamID;
							list2.Add(buLinearPathCam4);
						}
						list.Clear();
						list.Add(item);
					}
					if (list2.Count > 0)
					{
						buCompositeCurveCam buCompositeCurveCam2 = new buCompositeCurveCam(list2);
						buCompositeCurveCam2.CamID = CamID;
						buCompositeCurveCam2.MoveType = CamMoveType.G1;
						buCompositeCurveCam2.Color = clsVar.varCam.CamG1Draw.Color;
						CamResult.EntitiesG1.Add(buCompositeCurveCam2);
						list2.Clear();
					}
					num10++;
					num4++;
				}
				if (camTpPoint2.Points.Count > 0)
				{
					CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[0]));
				}
				for (int i = 1; i <= camTpPoint2.Points.Count - 1; i++)
				{
					List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
					double num20 = clsInit.cVector.Length3D(new Pnt3D(camTpPoint2.Points[i - 1].P9.X, camTpPoint2.Points[i - 1].P9.Y, camTpPoint2.Points[i - 1].P9.Z), new Pnt3D(camTpPoint2.Points[i].P9.X, camTpPoint2.Points[i].P9.Y, camTpPoint2.Points[i].P9.Z));
					if (camTpPoint2.Points[i].Type != 0)
					{
						if (camTpPoint2.Points[i].Type != 1)
						{
							if ((camTpPoint2.Points[i].Type == 2) | (camTpPoint2.Points[i].Type == 3))
							{
								num20 = camTpPoint2.Points[i].ArcData.Length;
								Arc arc = new Arc(Plane.XY, camTpPoint2.Points[i].ArcData.CenterPoint, camTpPoint2.Points[i].ArcData.Radius, camTpPoint2.Points[i].ArcData.StartPoint, camTpPoint2.Points[i].ArcData.EndPoint, flip: false);
								arc.Regen(0.01);
								List<Pnt3D> Vertices = new List<Pnt3D>();
								if (camTpPoint2.Points[i].ArcData.isCW)
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[i].ArcData.CenterPoint), camTpPoint2.Points[i].ArcData.Radius, camTpPoint2.Points[i].ArcData.EndAngle, camTpPoint2.Points[i].ArcData.StartAngle, 1.0, new WorkPlane(), ref Vertices);
									Vertices.Reverse();
								}
								else
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[i].ArcData.CenterPoint), camTpPoint2.Points[i].ArcData.Radius, camTpPoint2.Points[i].ArcData.StartAngle, camTpPoint2.Points[i].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
								}
								if (Vertices.Count > 0)
								{
									for (int j = 0; j <= Vertices.Count - 1; j++)
									{
										Pnt6DSimMove item2 = new Pnt6DSimMove(Vertices[j].X, Vertices[j].Y, Vertices[j].Z);
										CalculatedPoints.Add(item2);
									}
								}
							}
						}
						else
						{
							int count = Convert.ToInt32(num20 / 1.0);
							clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[i - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[i]), count, ref CalculatedPoints);
						}
					}
					else
					{
						int count2 = Convert.ToInt32(num20 / 5.0);
						clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[i - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[i]), count2, ref CalculatedPoints);
					}
					if (CalculatedPoints.Count < 2)
					{
						CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[i]));
						continue;
					}
					CalculatedPoints.RemoveAt(0);
					CamResult.SimilationPoint.SimMove.AddRange(CalculatedPoints);
				}
				CamResult.CamID = CamID;
				CamResult.CamPoints.Add(camTpPoint2);
			}
		}
	}

	public void IterateThroughEntireStructure4XVectorX(ToolPath calculatedToolPath, int CamID, camParameters5 camPars, GeoLib mwPars, ref camTp CamResult)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		Point3D item = new Point3D();
		CamResult = new camTp();
		CalculationEventArg calculationEventArg = new CalculationEventArg();
		List<Point3D> list = new List<Point3D>();
		foreach (TPPass pass in calculatedToolPath.Passes)
		{
			num++;
			double num11 = (double)num / (double)calculatedToolPath.Passes.Count();
			if (num11 > 1.0)
			{
				num11 = 1.0;
			}
			Application.DoEvents();
			calculationEventArg.OverallProgressPercentage = num11 * 100.0;
			num2 = 0;
			foreach (TPSlice slice in pass.Slices)
			{
				num2++;
				double num12 = Convert.ToDouble(num2) / (double)pass.Slices.Count();
				if (num12 > 1.0)
				{
					num12 = 1.0;
				}
				calculationEventArg.ActiveProgressPercentage = num12 * 100.0;
				calculationEventArg.Job = "Iteration";
				calculationEventArg.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
				clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
				bool flag = false;
				num4 = 0;
				if (num2 < 1)
				{
					continue;
				}
				camTpPoint camTpPoint2 = new camTpPoint();
				foreach (TPSection section in slice.Sections)
				{
					num4++;
					if (!(section is TPContour))
					{
						num5++;
						flag = false;
						TPLink val = (TPLink)(object)((section is TPLink) ? section : null);
						_ = val.LinkType;
					}
					else
					{
						num3++;
						flag = true;
					}
					List<ICurve> list2 = new List<ICurve>();
					int num13 = 0;
					foreach (TPSectionFit sectionFit in section.SectionFits)
					{
						num13++;
						TPHelixFit val2 = (TPHelixFit)(object)((sectionFit is TPHelixFit) ? sectionFit : null);
						bool flag2 = false;
						if (val2 != null && !buCompare.EQ(val2.Helix.StartPoint.Z, val2.Helix.EndPoint.Z))
						{
							flag2 = true;
						}
						if (!(val2 != null && !flag2))
						{
							num6++;
							foreach (CNCMove move in sectionFit.Moves)
							{
								num8++;
								CNC5AxMove val3 = (CNC5AxMove)(object)((move is CNC5AxMove) ? move : null);
								if (val3 == null)
								{
									continue;
								}
								TpPnt9D tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z, ((CNCMove)val3).Orientation.X, ((CNCMove)val3).Orientation.Y, ((CNCMove)val3).Orientation.Z);
								if (!((CNCMove)val3).IsRapid)
								{
									tpPnt9D.Type = 1;
								}
								else
								{
									tpPnt9D.Type = 0;
								}
								tpPnt9D.Feed = ((CNCMove)val3).FeedRate;
								list.Add(new Point3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z));
								if (!flag & (list.Count > 1))
								{
									CamMoveType MoveType = CamMoveType.G0;
									GetCamMoveType(list, CamResult.OperationVector, val3, ref MoveType);
									buLinearPathCam buLinearPathCam2 = new buLinearPathCam(list);
									buLinearPathCam2.CamID = CamID;
									buLinearPathCam2.MoveType = MoveType;
									buLinearPathCam2.ColorMethod = colorMethodType.byEntity;
									if (MoveType != CamMoveType.G0)
									{
										if (MoveType != CamMoveType.Leave)
										{
											if (MoveType != CamMoveType.Plunge)
											{
												buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamOtherDraw.Color;
												CamResult.EntitiesOther.Add(buLinearPathCam2);
											}
											else
											{
												if (buLinearPathCam2.Vertices.Length == 2)
												{
													Vector3D vector3D = new Vector3D(((CNCMove)val3).Orientation.X, ((CNCMove)val3).Orientation.Y, ((CNCMove)val3).Orientation.Z);
													double num14 = buLinearPathCam2.Length();
													Point3D item2 = new Point3D(buLinearPathCam2.Vertices[1].X + vector3D.X * num14, buLinearPathCam2.Vertices[1].Y + vector3D.Y * num14, buLinearPathCam2.Vertices[1].Z + vector3D.Z * num14);
													Point3D item3 = buVector5.ToPoint3D(buLinearPathCam2.Vertices[1]);
													List<Point3D> list3 = new List<Point3D>();
													list3.Add(item2);
													list3.Add(item3);
													buLinearPathCam2 = new buLinearPathCam(list3);
												}
												tpPnt9D.PlungeAxisMovement = true;
												buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamPlungeDraw.Color;
												CamResult.EntitiesPlunge.Add(buLinearPathCam2);
											}
										}
										else
										{
											if (buLinearPathCam2.Vertices.Length == 2)
											{
												Vector3D vector3D2 = new Vector3D(((CNCMove)val3).Orientation.X, ((CNCMove)val3).Orientation.Y, ((CNCMove)val3).Orientation.Z);
												double num15 = buLinearPathCam2.Length();
												Point3D point3D = buVector5.ToPoint3D(buLinearPathCam2.Vertices[0]);
												Point3D item4 = new Point3D(point3D.X + vector3D2.X * num15, point3D.Y + vector3D2.Y * num15, point3D.Z + vector3D2.Z * num15);
												List<Point3D> list4 = new List<Point3D>();
												list4.Add(point3D);
												list4.Add(item4);
												buLinearPathCam2 = new buLinearPathCam(list4);
											}
											tpPnt9D.PlungeAxisMovement = true;
											buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamLeaveDraw.Color;
											CamResult.EntitiesLeave.Add(buLinearPathCam2);
										}
									}
									else
									{
										buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamG0Draw.Color;
										CamResult.EntitiesG0.Add(buLinearPathCam2);
									}
									item = buVector5.ToPoint3D(list[list.Count - 1]);
									list.Clear();
									list.Add(item);
								}
								camTpPoint2.Points.Add(tpPnt9D);
								num9++;
							}
							if (list.Count > 0)
							{
								item = buVector5.ToPoint3D(list[list.Count - 1]);
							}
						}
						else
						{
							num7++;
							if (!(val2.Helix.ArcSweep <= 3.1315926535897933))
							{
								Arc Arc = null;
								Arc Arc2 = null;
								bool flag3 = false;
								HelixToSplitedArcs(val2.Helix, ref Arc, ref Arc2);
								TpPnt9D tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									tpPnt9D2.ArcData.isReverse = true;
									flag3 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc.StartPoint.X, Arc.StartPoint.Y, Arc.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
								}
								else
								{
									flag3 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc.EndPoint.X, Arc.EndPoint.Y, Arc.EndPoint.Z);
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag3)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val4 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val4.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
								}
								else
								{
									list2.Add(buArcCam2);
								}
								tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									flag3 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
								}
								else
								{
									flag3 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag3)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val5 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val5.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
								}
								else
								{
									list2.Add(buArcCam2);
								}
								item = ((val2.Helix.CenterOrientation.Z > 0.0) ? buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint));
								list.Clear();
								list.Add(item);
							}
							else
							{
								TpPnt9D tpPnt9D3 = new TpPnt9D();
								tpPnt9D3.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D3.IsArc = true;
								HelixToArcData(val2.Helix, ref tpPnt9D3.ArcData);
								tpPnt9D3.P9 = new Pnt9D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								buArcCam buArcCam3 = null;
								buArcCam3 = new buArcCam(Plane.XY, tpPnt9D3.ArcData.CenterPoint, tpPnt9D3.ArcData.Radius, tpPnt9D3.ArcData.StartPoint, tpPnt9D3.ArcData.EndPoint, flip: false);
								buArcCam3.MoveType = CamMoveType.G1;
								buArcCam3.CamID = CamID;
								buArcCam3.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam3.ColorMethod = colorMethodType.byEntity;
								buArcCam3.Regen(new RegenParams(0.001));
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									tpPnt9D3.ArcData.isCW = true;
									tpPnt9D3.Type = 2;
								}
								else
								{
									tpPnt9D3.ArcData.isCW = false;
									tpPnt9D3.Type = 3;
								}
								camTpPoint2.Points.Add(tpPnt9D3);
								if (!flag)
								{
									TPLink val6 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val6.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam3);
									}
								}
								else
								{
									List<Point3D> list5 = new List<Point3D>();
									for (int i = 0; i <= buArcCam3.Vertices.Length - 1; i++)
									{
										list5.Add(new Point3D(buArcCam3.Vertices[i].X, buArcCam3.Vertices[i].Y, buArcCam3.Vertices[i].Z));
									}
									if (tpPnt9D3.Type == 2)
									{
										list5.Reverse();
									}
									if (list5.Count > 1)
									{
										buLinearPathCam buLinearPathCam3 = new buLinearPathCam(list5);
										buLinearPathCam3.MoveType = CamMoveType.G1;
										buLinearPathCam3.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
										buLinearPathCam3.CamID = CamID;
										list2.Add(buLinearPathCam3);
									}
								}
								item = new Point3D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								list.Clear();
								list.Add(item);
							}
						}
						if (list.Count <= 1)
						{
							continue;
						}
						if (!flag)
						{
							if (list.Count > 1)
							{
								buLinearPathCam buLinearPathCam4 = new buLinearPathCam(list);
								buLinearPathCam4.CamID = CamID;
								CamResult.EntitiesG0.Add(buLinearPathCam4);
							}
						}
						else if (list.Count > 1)
						{
							buLinearPathCam buLinearPathCam5 = new buLinearPathCam(list);
							buLinearPathCam5.MoveType = CamMoveType.G1;
							buLinearPathCam5.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
							buLinearPathCam5.CamID = CamID;
							list2.Add(buLinearPathCam5);
						}
						list.Clear();
						list.Add(item);
					}
					if (list2.Count > 0)
					{
						List<Point3D> list6 = new List<Point3D>();
						for (int j = 0; j <= list2.Count - 1; j++)
						{
							Entity entity = (Entity)list2[j];
							List<Point3D> PointList = new List<Point3D>();
							buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
							if (entity.GetType() == typeof(buArcCam) && ((buArcCam)entity).isReverse)
							{
								PointList.Reverse();
							}
							int num16 = 0;
							if (j > 0)
							{
								num16 = 1;
							}
							for (int k = num16; k <= PointList.Count - 1; k++)
							{
								list6.Add(new Point3D(PointList[k].X, PointList[k].Y, PointList[k].Z));
							}
						}
						if (list6.Count > 1)
						{
							buLinearPathCam buLinearPathCam6 = new buLinearPathCam(list6);
							buLinearPathCam6.CamID = CamID;
							buLinearPathCam6.MoveType = CamMoveType.G1;
							buLinearPathCam6.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
							CamResult.EntitiesG1.Add(buLinearPathCam6);
						}
						list2.Clear();
					}
					num10++;
				}
				if (camTpPoint2.Points.Count > 0)
				{
					CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[0]));
				}
				for (int l = 1; l <= camTpPoint2.Points.Count - 1; l++)
				{
					List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
					double num17 = clsInit.cVector5.Length3D(new Pnt3D(camTpPoint2.Points[l - 1].P9.X, camTpPoint2.Points[l - 1].P9.Y, camTpPoint2.Points[l - 1].P9.Z), new Pnt3D(camTpPoint2.Points[l].P9.X, camTpPoint2.Points[l].P9.Y, camTpPoint2.Points[l].P9.Z));
					if (camTpPoint2.Points[l].Type != 0)
					{
						if (camTpPoint2.Points[l].Type != 1)
						{
							if ((camTpPoint2.Points[l].Type == 2) | (camTpPoint2.Points[l].Type == 3))
							{
								num17 = camTpPoint2.Points[l].ArcData.Length;
								Arc arc = new Arc(Plane.XY, camTpPoint2.Points[l].ArcData.CenterPoint, camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartPoint, camTpPoint2.Points[l].ArcData.EndPoint, flip: false);
								arc.Regen(0.01);
								List<Pnt3D> Vertices = new List<Pnt3D>();
								if (camTpPoint2.Points[l].ArcData.isReverse)
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
									Vertices.Reverse();
								}
								else
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
								}
								if (Vertices.Count > 0)
								{
									for (int m = 0; m <= Vertices.Count - 1; m++)
									{
										Pnt6DSimMove item5 = new Pnt6DSimMove(Vertices[m].X, Vertices[m].Y, Vertices[m].Z);
										CalculatedPoints.Add(item5);
									}
								}
							}
						}
						else
						{
							int count = Convert.ToInt32(num17 / 1.0);
							clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count, ref CalculatedPoints);
						}
					}
					else
					{
						int count2 = Convert.ToInt32(num17 / 5.0);
						clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count2, ref CalculatedPoints);
					}
					if (CalculatedPoints.Count < 2)
					{
						CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]));
						continue;
					}
					CalculatedPoints.RemoveAt(0);
					CamResult.SimilationPoint.SimMove.AddRange(CalculatedPoints);
				}
				CamResult.CamID = CamID;
				CamResult.CamPoints.Add(camTpPoint2);
			}
		}
	}

	public void IterateThroughEntireStructure5X(ToolPath calculatedToolPath, int CamID, camParameters5 camPars, GeoLib mwPars, ref camTp CamResult)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		Point3D item = new Point3D();
		CamResult = new camTp();
		CalculationEventArg calculationEventArg = new CalculationEventArg();
		List<Point3D> list = new List<Point3D>();
		foreach (TPPass pass in calculatedToolPath.Passes)
		{
			num++;
			double num11 = (double)num / (double)calculatedToolPath.Passes.Count();
			if (num11 > 1.0)
			{
				num11 = 1.0;
			}
			Application.DoEvents();
			calculationEventArg.OverallProgressPercentage = num11 * 100.0;
			num2 = 0;
			foreach (TPSlice slice in pass.Slices)
			{
				num2++;
				double num12 = Convert.ToDouble(num2) / (double)pass.Slices.Count();
				if (num12 > 1.0)
				{
					num12 = 1.0;
				}
				calculationEventArg.ActiveProgressPercentage = num12 * 100.0;
				calculationEventArg.Job = "Iteration";
				calculationEventArg.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
				clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
				bool flag = false;
				num4 = 0;
				if (num2 < 1)
				{
					continue;
				}
				camTpPoint camTpPoint2 = new camTpPoint();
				foreach (TPSection section in slice.Sections)
				{
					ToolPathLinkType toolPathLinkType = ToolPathLinkType.NotALink;
					num4++;
					if (!(section is TPContour))
					{
						num5++;
						flag = false;
						TPLink val = (TPLink)(object)((section is TPLink) ? section : null);
						toolPathLinkType = val.LinkType;
					}
					else
					{
						num3++;
						flag = true;
					}
					List<ICurve> list2 = new List<ICurve>();
					int num13 = 0;
					foreach (TPSectionFit sectionFit in section.SectionFits)
					{
						num13++;
						TPHelixFit val2 = (TPHelixFit)(object)((sectionFit is TPHelixFit) ? sectionFit : null);
						bool flag2 = false;
						if (val2 != null && !buCompare.EQ(val2.Helix.StartPoint.Z, val2.Helix.EndPoint.Z))
						{
							flag2 = true;
						}
						if (!(val2 != null && !flag2))
						{
							num6++;
							foreach (CNCMove move in sectionFit.Moves)
							{
								num8++;
								CNC5AxMove val3 = (CNC5AxMove)(object)((move is CNC5AxMove) ? move : null);
								if (val3 == null)
								{
									continue;
								}
								TpPnt9D tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z, ((CNCMove)val3).Orientation.X, ((CNCMove)val3).Orientation.Y, ((CNCMove)val3).Orientation.Z);
								if (!((CNCMove)val3).IsRapid)
								{
									tpPnt9D.Type = 1;
								}
								else
								{
									tpPnt9D.Type = 0;
								}
								tpPnt9D.Feed = ((CNCMove)val3).FeedRate;
								if (toolPathLinkType == ToolPathLinkType.Approach)
								{
									tpPnt9D.PlungeAxisMovement = true;
								}
								if (toolPathLinkType == ToolPathLinkType.Retract)
								{
									tpPnt9D.LeaveAxisMovement = true;
								}
								list.Add(new Point3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z));
								if (!flag & (list.Count > 1))
								{
									CamMoveType MoveType = CamMoveType.G0;
									GetCamMoveType(list, CamResult.OperationVector, val3, ref MoveType);
									if (MoveType != CamMoveType.G0)
									{
										switch (toolPathLinkType)
										{
										}
									}
								}
								camTpPoint2.Points.Add(tpPnt9D);
								num9++;
							}
							if (list.Count > 0)
							{
								List<Point3D> copiedPoint = new List<Point3D>();
								buVector5.Copy(list, ref copiedPoint);
								buLinearPathCam buLinearPathCam2 = new buLinearPathCam(copiedPoint);
								buLinearPathCam2.CamID = CamID;
								buLinearPathCam2.ColorMethod = colorMethodType.byEntity;
								if (toolPathLinkType != ToolPathLinkType.NotALink)
								{
									if (toolPathLinkType != ToolPathLinkType.Approach)
									{
										if (toolPathLinkType != ToolPathLinkType.Retract)
										{
											if (toolPathLinkType != ToolPathLinkType.LeadIn)
											{
												if (toolPathLinkType != ToolPathLinkType.LeadOut)
												{
													if (toolPathLinkType != ToolPathLinkType.ConnectionClearanceArea)
													{
														if (toolPathLinkType == ToolPathLinkType.ConnectionNotClearanceArea)
														{
															buLinearPathCam2.MoveType = CamMoveType.Connection;
															buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamConnectionDraw.Color;
															CamResult.EntitiesConnection.Add(buLinearPathCam2);
														}
													}
													else
													{
														buLinearPathCam2.MoveType = CamMoveType.Connection;
														buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamConnectionDraw.Color;
														CamResult.EntitiesConnection.Add(buLinearPathCam2);
													}
												}
												else
												{
													buLinearPathCam2.MoveType = CamMoveType.LeadOut;
													buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamLeadOutDraw.Color;
													CamResult.EntitiesLeadOut.Add(buLinearPathCam2);
												}
											}
											else
											{
												buLinearPathCam2.MoveType = CamMoveType.LeadIn;
												buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamLeadinDraw.Color;
												CamResult.EntitiesLeadIn.Add(buLinearPathCam2);
											}
										}
										else
										{
											buLinearPathCam2.MoveType = CamMoveType.Leave;
											buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamLeaveDraw.Color;
											CamResult.EntitiesLeave.Add(buLinearPathCam2);
										}
									}
									else
									{
										buLinearPathCam2.MoveType = CamMoveType.Plunge;
										buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamPlungeDraw.Color;
										CamResult.EntitiesPlunge.Add(buLinearPathCam2);
									}
								}
								item = buVector5.ToPoint3D(list[list.Count - 1]);
							}
						}
						else
						{
							num7++;
							if (!(val2.Helix.ArcSweep <= 3.1315926535897933))
							{
								Arc Arc = null;
								Arc Arc2 = null;
								bool flag3 = false;
								HelixToSplitedArcs(val2.Helix, ref Arc, ref Arc2);
								TpPnt9D tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									tpPnt9D2.ArcData.isReverse = true;
									flag3 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc.StartPoint.X, Arc.StartPoint.Y, Arc.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
								}
								else
								{
									flag3 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc.EndPoint.X, Arc.EndPoint.Y, Arc.EndPoint.Z);
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag3)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val4 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val4.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.ConnectionClearanceArea)
									{
										CamResult.EntitiesConnection.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.ConnectionNotClearanceArea)
									{
										CamResult.EntitiesConnection.Add(buArcCam2);
									}
								}
								else
								{
									list2.Add(buArcCam2);
								}
								tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									flag3 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
								}
								else
								{
									flag3 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag3)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val5 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val5.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.ConnectionClearanceArea)
									{
										CamResult.EntitiesConnection.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.ConnectionNotClearanceArea)
									{
										CamResult.EntitiesConnection.Add(buArcCam2);
									}
								}
								else
								{
									list2.Add(buArcCam2);
								}
								item = ((val2.Helix.CenterOrientation.Z > 0.0) ? buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint));
								list.Clear();
								list.Add(item);
							}
							else
							{
								TpPnt9D tpPnt9D3 = new TpPnt9D();
								tpPnt9D3.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D3.IsArc = true;
								HelixToArcData(val2.Helix, ref tpPnt9D3.ArcData);
								tpPnt9D3.P9 = new Pnt9D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								buArcCam buArcCam3 = null;
								buArcCam3 = new buArcCam(Plane.XY, tpPnt9D3.ArcData.CenterPoint, tpPnt9D3.ArcData.Radius, tpPnt9D3.ArcData.StartPoint, tpPnt9D3.ArcData.EndPoint, flip: false);
								buArcCam3.MoveType = CamMoveType.G1;
								buArcCam3.CamID = CamID;
								buArcCam3.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam3.ColorMethod = colorMethodType.byEntity;
								buArcCam3.Regen(new RegenParams(0.001));
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									tpPnt9D3.ArcData.isCW = true;
									tpPnt9D3.Type = 2;
								}
								else
								{
									tpPnt9D3.ArcData.isCW = false;
									tpPnt9D3.Type = 3;
								}
								camTpPoint2.Points.Add(tpPnt9D3);
								if (!flag)
								{
									TPLink val6 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val6.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.ConnectionClearanceArea)
									{
										CamResult.EntitiesConnection.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.ConnectionNotClearanceArea)
									{
										CamResult.EntitiesConnection.Add(buArcCam3);
									}
								}
								else
								{
									List<Point3D> list3 = new List<Point3D>();
									for (int i = 0; i <= buArcCam3.Vertices.Length - 1; i++)
									{
										list3.Add(new Point3D(buArcCam3.Vertices[i].X, buArcCam3.Vertices[i].Y, buArcCam3.Vertices[i].Z));
									}
									if (tpPnt9D3.Type == 2)
									{
										list3.Reverse();
									}
									if (list3.Count > 1)
									{
										buLinearPathCam buLinearPathCam3 = new buLinearPathCam(list3);
										buLinearPathCam3.MoveType = CamMoveType.G1;
										buLinearPathCam3.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
										buLinearPathCam3.CamID = CamID;
										list2.Add(buLinearPathCam3);
									}
								}
								item = new Point3D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								list.Clear();
								list.Add(item);
							}
						}
						if (list.Count <= 1)
						{
							continue;
						}
						if (!flag)
						{
							if (list.Count > 1)
							{
								buLinearPathCam buLinearPathCam4 = new buLinearPathCam(list);
								buLinearPathCam4.MoveType = CamMoveType.G0;
								buLinearPathCam4.Color = clsInit.cMwCalc.Settings.CamG0Draw.Color;
								buLinearPathCam4.CamID = CamID;
								CamResult.EntitiesG0.Add(buLinearPathCam4);
							}
						}
						else if (list.Count > 1)
						{
							buLinearPathCam buLinearPathCam5 = new buLinearPathCam(list);
							buLinearPathCam5.MoveType = CamMoveType.G1;
							buLinearPathCam5.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
							buLinearPathCam5.CamID = CamID;
							list2.Add(buLinearPathCam5);
						}
						list.Clear();
						list.Add(item);
					}
					if (list2.Count > 0)
					{
						List<Point3D> list4 = new List<Point3D>();
						for (int j = 0; j <= list2.Count - 1; j++)
						{
							Entity entity = (Entity)list2[j];
							List<Point3D> PointList = new List<Point3D>();
							buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
							if (entity.GetType() == typeof(buArcCam) && ((buArcCam)entity).isReverse)
							{
								PointList.Reverse();
							}
							int num14 = 0;
							if (j > 0)
							{
								num14 = 1;
							}
							for (int k = num14; k <= PointList.Count - 1; k++)
							{
								list4.Add(new Point3D(PointList[k].X, PointList[k].Y, PointList[k].Z));
							}
						}
						if (list4.Count > 1)
						{
							buLinearPathCam buLinearPathCam6 = new buLinearPathCam(list4);
							buLinearPathCam6.CamID = CamID;
							buLinearPathCam6.MoveType = CamMoveType.G1;
							buLinearPathCam6.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
							CamResult.EntitiesG1.Add(buLinearPathCam6);
						}
						list2.Clear();
					}
					num10++;
				}
				if (camTpPoint2.Points.Count > 0)
				{
					CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[0]));
				}
				for (int l = 1; l <= camTpPoint2.Points.Count - 1; l++)
				{
					List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
					double num15 = clsInit.cVector5.Length3D(new Pnt3D(camTpPoint2.Points[l - 1].P9.X, camTpPoint2.Points[l - 1].P9.Y, camTpPoint2.Points[l - 1].P9.Z), new Pnt3D(camTpPoint2.Points[l].P9.X, camTpPoint2.Points[l].P9.Y, camTpPoint2.Points[l].P9.Z));
					if (camTpPoint2.Points[l].Type != 0)
					{
						if (camTpPoint2.Points[l].Type != 1)
						{
							if ((camTpPoint2.Points[l].Type == 2) | (camTpPoint2.Points[l].Type == 3))
							{
								num15 = camTpPoint2.Points[l].ArcData.Length;
								Arc arc = new Arc(Plane.XY, camTpPoint2.Points[l].ArcData.CenterPoint, camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartPoint, camTpPoint2.Points[l].ArcData.EndPoint, flip: false);
								arc.Regen(0.01);
								List<Pnt3D> Vertices = new List<Pnt3D>();
								if (camTpPoint2.Points[l].ArcData.isReverse)
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
									Vertices.Reverse();
								}
								else
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
								}
								if (Vertices.Count > 0)
								{
									for (int m = 0; m <= Vertices.Count - 1; m++)
									{
										Pnt6DSimMove item2 = new Pnt6DSimMove(Vertices[m].X, Vertices[m].Y, Vertices[m].Z);
										CalculatedPoints.Add(item2);
									}
								}
							}
						}
						else
						{
							int count = Convert.ToInt32(num15 / 1.0);
							clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count, ref CalculatedPoints);
						}
					}
					else
					{
						int count2 = Convert.ToInt32(num15 / 5.0);
						clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count2, ref CalculatedPoints);
					}
					if (CalculatedPoints.Count < 2)
					{
						CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]));
						continue;
					}
					CalculatedPoints.RemoveAt(0);
					CamResult.SimilationPoint.SimMove.AddRange(CalculatedPoints);
				}
				CamResult.CamID = CamID;
				CamResult.CamPoints.Add(camTpPoint2);
			}
		}
	}

	public void IterateThroughEntireStructure5X_1(ToolPath calculatedToolPath, int CamID, camParameters5 camPars, GeoLib mwPars, ref camTp CamResult)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		Point3D item = new Point3D();
		CamResult = new camTp();
		CalculationEventArg calculationEventArg = new CalculationEventArg();
		List<Point3D> list = new List<Point3D>();
		foreach (TPPass pass in calculatedToolPath.Passes)
		{
			num++;
			double num11 = (double)num / (double)calculatedToolPath.Passes.Count();
			if (num11 > 1.0)
			{
				num11 = 1.0;
			}
			Application.DoEvents();
			calculationEventArg.OverallProgressPercentage = num11 * 100.0;
			num2 = 0;
			foreach (TPSlice slice in pass.Slices)
			{
				num2++;
				double num12 = Convert.ToDouble(num2) / (double)pass.Slices.Count();
				if (num12 > 1.0)
				{
					num12 = 1.0;
				}
				calculationEventArg.ActiveProgressPercentage = num12 * 100.0;
				calculationEventArg.Job = "Iteration";
				calculationEventArg.ShowForm = clsInit.cMwCalc.Settings.ShowProgressForm;
				clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
				bool flag = false;
				num4 = 0;
				if (num2 < 1)
				{
					continue;
				}
				camTpPoint camTpPoint2 = new camTpPoint();
				foreach (TPSection section in slice.Sections)
				{
					num4++;
					if (!(section is TPContour))
					{
						num5++;
						flag = false;
						TPLink val = (TPLink)(object)((section is TPLink) ? section : null);
						_ = val.LinkType;
					}
					else
					{
						num3++;
						flag = true;
					}
					List<ICurve> list2 = new List<ICurve>();
					int num13 = 0;
					foreach (TPSectionFit sectionFit in section.SectionFits)
					{
						num13++;
						TPHelixFit val2 = (TPHelixFit)(object)((sectionFit is TPHelixFit) ? sectionFit : null);
						bool flag2 = false;
						if (val2 != null && !buCompare.EQ(val2.Helix.StartPoint.Z, val2.Helix.EndPoint.Z))
						{
							flag2 = true;
						}
						if (!(val2 != null && !flag2))
						{
							num6++;
							foreach (CNCMove move in sectionFit.Moves)
							{
								num8++;
								CNC5AxMove val3 = (CNC5AxMove)(object)((move is CNC5AxMove) ? move : null);
								if (val3 == null)
								{
									continue;
								}
								TpPnt9D tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z, ((CNCMove)val3).Orientation.X, ((CNCMove)val3).Orientation.Y, ((CNCMove)val3).Orientation.Z);
								if (!((CNCMove)val3).IsRapid)
								{
									tpPnt9D.Type = 1;
								}
								else
								{
									tpPnt9D.Type = 0;
								}
								tpPnt9D.Feed = ((CNCMove)val3).FeedRate;
								list.Add(new Point3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z));
								if (!flag & (list.Count > 1))
								{
									CamMoveType MoveType = CamMoveType.G0;
									GetCamMoveType(list, CamResult.OperationVector, val3, ref MoveType);
									buLinearPathCam buLinearPathCam2 = new buLinearPathCam(list);
									buLinearPathCam2.CamID = CamID;
									buLinearPathCam2.MoveType = MoveType;
									buLinearPathCam2.ColorMethod = colorMethodType.byEntity;
									if (MoveType != CamMoveType.G0)
									{
										if (MoveType != CamMoveType.Leave)
										{
											if (MoveType != CamMoveType.Plunge)
											{
												buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamOtherDraw.Color;
												CamResult.EntitiesOther.Add(buLinearPathCam2);
											}
											else
											{
												if (buLinearPathCam2.Vertices.Length == 2)
												{
													Vector3D vector3D = new Vector3D(((CNCMove)val3).Orientation.X, ((CNCMove)val3).Orientation.Y, ((CNCMove)val3).Orientation.Z);
													double num14 = buLinearPathCam2.Length();
													Point3D item2 = new Point3D(buLinearPathCam2.Vertices[1].X + vector3D.X * num14, buLinearPathCam2.Vertices[1].Y + vector3D.Y * num14, buLinearPathCam2.Vertices[1].Z + vector3D.Z * num14);
													Point3D item3 = buVector5.ToPoint3D(buLinearPathCam2.Vertices[1]);
													List<Point3D> list3 = new List<Point3D>();
													list3.Add(item2);
													list3.Add(item3);
													buLinearPathCam2 = new buLinearPathCam(list3);
												}
												tpPnt9D.PlungeAxisMovement = true;
												buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamPlungeDraw.Color;
												CamResult.EntitiesPlunge.Add(buLinearPathCam2);
											}
										}
										else
										{
											if (buLinearPathCam2.Vertices.Length == 2)
											{
												Vector3D vector3D2 = new Vector3D(((CNCMove)val3).Orientation.X, ((CNCMove)val3).Orientation.Y, ((CNCMove)val3).Orientation.Z);
												double num15 = buLinearPathCam2.Length();
												Point3D point3D = buVector5.ToPoint3D(buLinearPathCam2.Vertices[0]);
												Point3D item4 = new Point3D(point3D.X + vector3D2.X * num15, point3D.Y + vector3D2.Y * num15, point3D.Z + vector3D2.Z * num15);
												List<Point3D> list4 = new List<Point3D>();
												list4.Add(point3D);
												list4.Add(item4);
												buLinearPathCam2 = new buLinearPathCam(list4);
											}
											tpPnt9D.PlungeAxisMovement = true;
											buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamLeaveDraw.Color;
											CamResult.EntitiesLeave.Add(buLinearPathCam2);
										}
									}
									else
									{
										buLinearPathCam2.Color = clsInit.cMwCalc.Settings.CamG0Draw.Color;
										CamResult.EntitiesG0.Add(buLinearPathCam2);
									}
									item = buVector5.ToPoint3D(list[list.Count - 1]);
									list.Clear();
									list.Add(item);
								}
								camTpPoint2.Points.Add(tpPnt9D);
								num9++;
							}
							if (list.Count > 0)
							{
								item = buVector5.ToPoint3D(list[list.Count - 1]);
							}
						}
						else
						{
							num7++;
							if (!(val2.Helix.ArcSweep <= 3.1315926535897933))
							{
								Arc Arc = null;
								Arc Arc2 = null;
								bool flag3 = false;
								HelixToSplitedArcs(val2.Helix, ref Arc, ref Arc2);
								TpPnt9D tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									tpPnt9D2.ArcData.isReverse = true;
									flag3 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc.StartPoint.X, Arc.StartPoint.Y, Arc.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
								}
								else
								{
									flag3 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc.EndPoint.X, Arc.EndPoint.Y, Arc.EndPoint.Z);
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag3)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val4 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val4.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val4.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
								}
								else
								{
									list2.Add(buArcCam2);
								}
								tpPnt9D2 = new TpPnt9D();
								tpPnt9D2.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D2.IsArc = true;
								ArcToArcData(Arc2, ref tpPnt9D2.ArcData);
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									flag3 = true;
									tpPnt9D2.P9 = new Pnt9D(Arc2.StartPoint.X, Arc2.StartPoint.Y, Arc2.StartPoint.Z);
									tpPnt9D2.ArcData.isReverse = true;
								}
								else
								{
									flag3 = false;
									tpPnt9D2.P9 = new Pnt9D(Arc2.EndPoint.X, Arc2.EndPoint.Y, Arc2.EndPoint.Z);
									tpPnt9D2.ArcData.isReverse = false;
								}
								buArcCam2 = new buArcCam(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
								buArcCam2.isReverse = tpPnt9D2.ArcData.isReverse;
								buArcCam2.MoveType = CamMoveType.G1;
								buArcCam2.CamID = CamID;
								buArcCam2.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam2.ColorMethod = colorMethodType.byEntity;
								buArcCam2.Regen(new RegenParams(0.01));
								if (!flag3)
								{
									tpPnt9D2.ArcData.isCW = false;
									tpPnt9D2.Type = 3;
								}
								else
								{
									tpPnt9D2.ArcData.isCW = true;
									tpPnt9D2.Type = 2;
								}
								camTpPoint2.Points.Add(tpPnt9D2);
								if (!flag)
								{
									TPLink val5 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val5.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam2);
									}
									if (val5.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam2);
									}
								}
								else
								{
									list2.Add(buArcCam2);
								}
								item = ((val2.Helix.CenterOrientation.Z > 0.0) ? buVector5.ToPoint3D(tpPnt9D2.ArcData.EndPoint) : buVector5.ToPoint3D(tpPnt9D2.ArcData.StartPoint));
								list.Clear();
								list.Add(item);
							}
							else
							{
								TpPnt9D tpPnt9D3 = new TpPnt9D();
								tpPnt9D3.Feed = sectionFit.Moves.ElementAt(0).FeedRate;
								tpPnt9D3.IsArc = true;
								HelixToArcData(val2.Helix, ref tpPnt9D3.ArcData);
								tpPnt9D3.P9 = new Pnt9D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								buArcCam buArcCam3 = null;
								buArcCam3 = new buArcCam(Plane.XY, tpPnt9D3.ArcData.CenterPoint, tpPnt9D3.ArcData.Radius, tpPnt9D3.ArcData.StartPoint, tpPnt9D3.ArcData.EndPoint, flip: false);
								buArcCam3.MoveType = CamMoveType.G1;
								buArcCam3.CamID = CamID;
								buArcCam3.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
								buArcCam3.ColorMethod = colorMethodType.byEntity;
								buArcCam3.Regen(new RegenParams(0.001));
								if (!(val2.Helix.CenterOrientation.Z > 0.0))
								{
									tpPnt9D3.ArcData.isCW = true;
									tpPnt9D3.Type = 2;
								}
								else
								{
									tpPnt9D3.ArcData.isCW = false;
									tpPnt9D3.Type = 3;
								}
								camTpPoint2.Points.Add(tpPnt9D3);
								if (!flag)
								{
									TPLink val6 = (TPLink)(object)((section is TPLink) ? section : null);
									if (val6.LinkType == ToolPathLinkType.LeadIn)
									{
										CamResult.EntitiesLeadIn.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.LeadOut)
									{
										CamResult.EntitiesLeadOut.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Approach)
									{
										CamResult.EntitiesPlunge.Add(buArcCam3);
									}
									if (val6.LinkType == ToolPathLinkType.Retract)
									{
										CamResult.EntitiesLeave.Add(buArcCam3);
									}
								}
								else
								{
									List<Point3D> list5 = new List<Point3D>();
									for (int i = 0; i <= buArcCam3.Vertices.Length - 1; i++)
									{
										list5.Add(new Point3D(buArcCam3.Vertices[i].X, buArcCam3.Vertices[i].Y, buArcCam3.Vertices[i].Z));
									}
									if (tpPnt9D3.Type == 2)
									{
										list5.Reverse();
									}
									if (list5.Count > 1)
									{
										buLinearPathCam buLinearPathCam3 = new buLinearPathCam(list5);
										buLinearPathCam3.MoveType = CamMoveType.G1;
										buLinearPathCam3.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
										buLinearPathCam3.CamID = CamID;
										list2.Add(buLinearPathCam3);
									}
								}
								item = new Point3D(val2.Helix.EndPoint.X, val2.Helix.EndPoint.Y, val2.Helix.EndPoint.Z);
								list.Clear();
								list.Add(item);
							}
						}
						if (list.Count <= 1)
						{
							continue;
						}
						if (!flag)
						{
							if (list.Count > 1)
							{
								buLinearPathCam buLinearPathCam4 = new buLinearPathCam(list);
								buLinearPathCam4.CamID = CamID;
								CamResult.EntitiesG0.Add(buLinearPathCam4);
							}
						}
						else if (list.Count > 1)
						{
							buLinearPathCam buLinearPathCam5 = new buLinearPathCam(list);
							buLinearPathCam5.MoveType = CamMoveType.G1;
							buLinearPathCam5.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
							buLinearPathCam5.CamID = CamID;
							list2.Add(buLinearPathCam5);
						}
						list.Clear();
						list.Add(item);
					}
					if (list2.Count > 0)
					{
						List<Point3D> list6 = new List<Point3D>();
						for (int j = 0; j <= list2.Count - 1; j++)
						{
							Entity entity = (Entity)list2[j];
							List<Point3D> PointList = new List<Point3D>();
							buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
							if (entity.GetType() == typeof(buArcCam) && ((buArcCam)entity).isReverse)
							{
								PointList.Reverse();
							}
							int num16 = 0;
							if (j > 0)
							{
								num16 = 1;
							}
							for (int k = num16; k <= PointList.Count - 1; k++)
							{
								list6.Add(new Point3D(PointList[k].X, PointList[k].Y, PointList[k].Z));
							}
						}
						if (list6.Count > 1)
						{
							buLinearPathCam buLinearPathCam6 = new buLinearPathCam(list6);
							buLinearPathCam6.CamID = CamID;
							buLinearPathCam6.MoveType = CamMoveType.G1;
							buLinearPathCam6.Color = clsInit.cMwCalc.Settings.CamG1Draw.Color;
							CamResult.EntitiesG1.Add(buLinearPathCam6);
						}
						list2.Clear();
					}
					num10++;
				}
				if (camTpPoint2.Points.Count > 0)
				{
					CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[0]));
				}
				for (int l = 1; l <= camTpPoint2.Points.Count - 1; l++)
				{
					List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
					double num17 = clsInit.cVector5.Length3D(new Pnt3D(camTpPoint2.Points[l - 1].P9.X, camTpPoint2.Points[l - 1].P9.Y, camTpPoint2.Points[l - 1].P9.Z), new Pnt3D(camTpPoint2.Points[l].P9.X, camTpPoint2.Points[l].P9.Y, camTpPoint2.Points[l].P9.Z));
					if (camTpPoint2.Points[l].Type != 0)
					{
						if (camTpPoint2.Points[l].Type != 1)
						{
							if ((camTpPoint2.Points[l].Type == 2) | (camTpPoint2.Points[l].Type == 3))
							{
								num17 = camTpPoint2.Points[l].ArcData.Length;
								Arc arc = new Arc(Plane.XY, camTpPoint2.Points[l].ArcData.CenterPoint, camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartPoint, camTpPoint2.Points[l].ArcData.EndPoint, flip: false);
								arc.Regen(0.01);
								List<Pnt3D> Vertices = new List<Pnt3D>();
								if (camTpPoint2.Points[l].ArcData.isReverse)
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
									Vertices.Reverse();
								}
								else
								{
									clsInit.cVector5.ArcToLineer(buConversion5.Point3DToPnt3D(camTpPoint2.Points[l].ArcData.CenterPoint), camTpPoint2.Points[l].ArcData.Radius, camTpPoint2.Points[l].ArcData.StartAngle, camTpPoint2.Points[l].ArcData.EndAngle, 1.0, new WorkPlane(), ref Vertices);
								}
								if (Vertices.Count > 0)
								{
									for (int m = 0; m <= Vertices.Count - 1; m++)
									{
										Pnt6DSimMove item5 = new Pnt6DSimMove(Vertices[m].X, Vertices[m].Y, Vertices[m].Z);
										CalculatedPoints.Add(item5);
									}
								}
							}
						}
						else
						{
							int count = Convert.ToInt32(num17 / 1.0);
							clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count, ref CalculatedPoints);
						}
					}
					else
					{
						int count2 = Convert.ToInt32(num17 / 5.0);
						clsInit.cVector5.LineerInterpolation(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l - 1]), TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]), count2, ref CalculatedPoints);
					}
					if (CalculatedPoints.Count < 2)
					{
						CamResult.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(camTpPoint2.Points[l]));
						continue;
					}
					CalculatedPoints.RemoveAt(0);
					CamResult.SimilationPoint.SimMove.AddRange(CalculatedPoints);
				}
				CamResult.CamID = CamID;
				CamResult.CamPoints.Add(camTpPoint2);
			}
		}
	}

	public int GetNextSectionOfTP(IEnumerable<TPSection> Sections, int Index, ref MWIterationOption Option, ref List<Pnt6D> P6)
	{
		try
		{
			Pnt3D pnt = null;
			P6 = new List<Pnt6D>();
			int num = Index;
			if (num < 0)
			{
				num = 0;
			}
			for (int i = num; i <= Sections.Count() - 1; i++)
			{
				TPSection val = Sections.ElementAt(i);
				bool flag = false;
				flag = val is TPContour;
				foreach (TPSectionFit sectionFit in val.SectionFits)
				{
					for (int j = 0; j <= sectionFit.Moves.Count() - 1; j++)
					{
						CNCMove val2 = sectionFit.Moves.ElementAt(j);
						CNC5AxMove val3 = (CNC5AxMove)(object)((val2 is CNC5AxMove) ? val2 : null);
						if (val3 != null && flag)
						{
							if (j == 0)
							{
								P6.Add(new Pnt6D(pnt));
							}
							P6.Add(new Pnt6D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z));
						}
						pnt = new Pnt3D(((CNCMove)val3).Position.X, ((CNCMove)val3).Position.Y, ((CNCMove)val3).Position.Z);
					}
				}
				if (P6.Count > 0)
				{
					double c = clsInit.cVector.PointAngle(new Pnt3D(P6[1]), new Pnt3D(P6[0]), new WorkPlane());
					double c2 = clsInit.cVector.PointAngle(new Pnt3D(P6[P6.Count - 1]), new Pnt3D(P6[P6.Count - 2]), new WorkPlane());
					Option.StartPoint = new Pnt6D(P6[0].X, P6[0].Y, P6[0].Z, 0.0, 0.0, c);
					Option.EndPoint = new Pnt6D(P6[P6.Count - 1].X, P6[P6.Count - 1].Y, P6[P6.Count - 1].Z, 0.0, 0.0, c2);
					return 1;
				}
			}
			return 1;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public void GetCamMoveType(List<Point3D> pointList, Vector3D OperationVector, CNC5AxMove mwCNC5AxMove, ref CamMoveType MoveType)
	{
		MoveType = CamMoveType.Other;
		if (pointList.Count < 2 || !(OperationVector == Vector3D.AxisZ))
		{
			return;
		}
		if (!buCompare.EQ(pointList[pointList.Count - 1].X, pointList[pointList.Count - 2].X, buSystem.resolutionCompare))
		{
			if (!((CNCMove)mwCNC5AxMove).IsRapid)
			{
				MoveType = CamMoveType.G1;
			}
			else
			{
				MoveType = CamMoveType.G0;
			}
		}
		else if (!buCompare.EQ(pointList[pointList.Count - 1].Y, pointList[pointList.Count - 2].Y, buSystem.resolutionCompare))
		{
			if (!((CNCMove)mwCNC5AxMove).IsRapid)
			{
				MoveType = CamMoveType.G1;
			}
			else
			{
				MoveType = CamMoveType.G0;
			}
		}
		else if (!(pointList[pointList.Count - 1].Z > pointList[pointList.Count - 2].Z))
		{
			MoveType = CamMoveType.Plunge;
		}
		else
		{
			MoveType = CamMoveType.Leave;
		}
	}

	public void HelixToArcData(HelixInformation Helix, ref TpArcData ArcData)
	{
		ArcData.CenterPoint = new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z);
		ArcData.SweepAngle = Helix.ArcSweep;
		ArcData.StartPoint = new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z);
		ArcData.EndPoint = new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z);
		ArcData.StartAngle = clsInit.cVector5.PointAngle(ArcData.StartPoint, ArcData.CenterPoint, Plane.XY);
		ArcData.EndAngle = clsInit.cVector5.PointAngle(ArcData.EndPoint, ArcData.CenterPoint, Plane.XY);
		Arc arc = new Arc(Plane.XY, ArcData.CenterPoint, new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z), new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z));
		if (!buCompare5.EQ(arc.AngleInRadians, Helix.ArcSweep))
		{
			arc = new Arc(Plane.XY, ArcData.CenterPoint, new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z), new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z));
			ArcData.isReverse = true;
			ArcData.StartPoint = new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z);
			ArcData.EndPoint = new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z);
			ArcData.StartAngle = clsInit.cVector5.PointAngle(ArcData.StartPoint, ArcData.CenterPoint, Plane.XY);
			ArcData.EndAngle = clsInit.cVector5.PointAngle(ArcData.EndPoint, ArcData.CenterPoint, Plane.XY);
		}
		ArcData.Radius = Point3D.Distance(ArcData.StartPoint, ArcData.CenterPoint);
		ArcData.Length = Helix.ArcSweep * ArcData.Radius;
		if (ArcData.StartAngle > ArcData.EndAngle)
		{
			ArcData.EndAngle += 360.0;
		}
	}

	public void ArcToArcData(Arc Arc, ref TpArcData ArcData)
	{
		if (Arc != null)
		{
			ArcData.StartPoint = new Point3D(Arc.StartPoint.X, Arc.StartPoint.Y, Arc.StartPoint.Z);
			ArcData.EndPoint = new Point3D(Arc.EndPoint.X, Arc.EndPoint.Y, Arc.EndPoint.Z);
			ArcData.CenterPoint = new Point3D(Arc.Center.X, Arc.Center.Y, Arc.Center.Z);
			ArcData.SweepAngle = Arc.AngleInRadians;
			ArcData.Radius = Arc.Radius;
			ArcData.Length = Arc.Length();
			ArcData.StartAngle = clsInit.cVector5.PointAngle(ArcData.StartPoint, ArcData.CenterPoint, Plane.XY);
			ArcData.EndAngle = clsInit.cVector5.PointAngle(ArcData.EndPoint, ArcData.CenterPoint, Plane.XY);
			if (ArcData.StartAngle > ArcData.EndAngle)
			{
				ArcData.EndAngle += 360.0;
			}
		}
	}

	public void HelixToSplitedArcs(HelixInformation Helix, ref Arc Arc1, ref Arc Arc2)
	{
		if (!buCompare5.EQ(Helix.ArcSweep, Math.PI * 2.0, 0.01))
		{
			Arc arc = ((Helix.CenterOrientation.Z > 0.0) ? new Arc(Plane.XY, new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z), new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z)) : new Arc(Plane.XY, new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), new Point3D(Helix.EndPoint.X, Helix.EndPoint.Y, Helix.EndPoint.Z), new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z)));
			arc.Translate(0.0, 0.0, Helix.CenterPoint.Z);
			arc.Regen(new RegenParams(0.001));
			arc.SplitBy(arc.MidPoint, out var lower, out var upper);
			if (lower != null)
			{
				((Arc)lower).Regen(new RegenParams(0.001));
				if (!(Helix.CenterOrientation.Z > 0.0))
				{
					Arc2 = (Arc)lower;
				}
				else
				{
					Arc1 = (Arc)lower;
				}
			}
			if (upper != null)
			{
				((Arc)upper).Regen(new RegenParams(0.001));
				if (!(Helix.CenterOrientation.Z > 0.0))
				{
					Arc1 = (Arc)upper;
				}
				else
				{
					Arc2 = (Arc)upper;
				}
			}
		}
		else
		{
			double radius = Point3D.Distance(new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), new Point3D(Helix.StartPoint.X, Helix.StartPoint.Y, Helix.StartPoint.Z));
			Arc1 = new Arc(Plane.XY, new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), radius, 0.0, Math.PI);
			Arc2 = new Arc(Plane.XY, new Point3D(Helix.CenterPoint.X, Helix.CenterPoint.Y, Helix.CenterPoint.Z), radius, Math.PI, Math.PI * 2.0);
		}
	}

	public void GetOffsetOfMesh(List<Entity> Meshes, double Offset, double StartZValue, double EndZValue, double ZStep, double Resolution, ref List<buEntity> OffsetEntities)
	{
		MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
		mWCalculationOptions.NumberofAxis = 3;
		mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
		mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
		mWCalculationOptions.Mode = CamMode.TriangularMesh;
		mWCalculationOptions.DontApplyReset = true;
		mWCalculationOptions.isBuWireframeCalculation = false;
		mWCalculationOptions.AddToCamListInLocalCalculation = false;
		mWCalculationOptions.ShowLeadInOutPage = false;
		mWCalculationOptions.DontShowDialogBox = true;
		mWCalculationOptions.DontShowbuDialogBox = true;
		varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = ZStep;
		varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = 1;
		varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
		varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = EndZValue;
		varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = StartZValue;
		varMWCamMeshContantZPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
		varMWCamMeshContantZPars.MachParam.CutTolerance = Resolution;
		varMWCamMeshContantZPars.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.Direct;
		varMWCamMeshContantZPars.MachParam.LinkParams.LastExit.Type = LastExitType.Direct;
		((InterlinkHandeler)varMWCamMeshContantZPars.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
		((InterlinkHandeler)varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
		((InterlinkHandeler)varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
		varMWCamMeshContantZPars.MachParam.LinkParams.ClearancePlaneHeight = 2000.0;
		ToolBase5 toolBase = new ToolBase5();
		toolBase.Geometry.GeometryType = buClass.ToolType.Slot;
		toolBase.Geometry.Diameter = Offset * 2.0;
		toolBase.Geometry.Length = 500.0;
		CamEntities.Clear();
		CamEntities.AddRange(Meshes);
		camTp Cam = new camTp();
		camResult Result = new camResult();
		int num = doTriangularMesh3D(mWCalculationOptions, toolBase, ref Cam, ref Result);
		if (num < 0 || Cam.CamPoints.Count <= 0)
		{
			return;
		}
		if (OffsetEntities == null)
		{
			OffsetEntities = new List<buEntity>();
		}
		OffsetEntities.Clear();
		for (int i = 0; i <= Cam.EntitiesG1.Count - 1; i++)
		{
			if (Cam.EntitiesG1[i] is buLinearPathCam)
			{
				buLinearPathCam buLinearPathCam2 = Cam.EntitiesG1[i] as buLinearPathCam;
				if (!buLinearPathCam2.isLink & (buLinearPathCam2.MoveType == CamMoveType.G1))
				{
					buEntity copiedEntity = null;
					buEntity.Copy(Cam.EntitiesG1[i], ref copiedEntity);
					OffsetEntities.Add(copiedEntity);
				}
			}
		}
	}

	public void GetPocketOfParalelEntities(List<Entity> refEntities, double Offset, double ZValue, double Resolution, ref List<buEntity> OffsetEntities)
	{
		MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
		mWCalculationOptions.NumberofAxis = 3;
		mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
		mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
		mWCalculationOptions.Mode = CamMode.WireFrame;
		mWCalculationOptions.DontApplyReset = true;
		mWCalculationOptions.isBuWireframeCalculation = false;
		mWCalculationOptions.AddToCamListInLocalCalculation = false;
		mWCalculationOptions.ShowLeadInOutPage = false;
		mWCalculationOptions.DontShowDialogBox = true;
		mWCalculationOptions.DontShowbuDialogBox = true;
		varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = 1.0;
		varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = 1;
		varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
		varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = ZValue;
		varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = ZValue;
		varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
		varMWCamWFPocketPars.MachParam.CutTolerance = Resolution;
		varMWCamWFPocketPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtParallel;
		varMWCamWFPocketPars.MachParam.CurMachType = MachiningParamsMachType.MachtypeOneway;
		varMWCamMeshContantZPars.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.Direct;
		varMWCamMeshContantZPars.MachParam.LinkParams.LastExit.Type = LastExitType.Direct;
		((InterlinkHandeler)varMWCamMeshContantZPars.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
		((InterlinkHandeler)varMWCamMeshContantZPars.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
		((InterlinkHandeler)varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenSlices).SmallMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
		((InterlinkHandeler)varMWCamMeshContantZPars.MachParam.LinkParams.LinkBetweenPasses).SmallMoveHandling.Action = MoveHandlingAction.ActionGapIncrementalRapidPlane;
		ToolBase5 toolBase = new ToolBase5();
		toolBase.Geometry.GeometryType = buClass.ToolType.Flat;
		toolBase.Geometry.Diameter = Offset * 2.0;
		toolBase.Geometry.Length = 500.0;
		CamEntities.Clear();
		CamEntities.AddRange(refEntities);
		camTp Cam = new camTp();
		camResult Result = new camResult();
		int num = doWireframeContour(mWCalculationOptions, toolBase, ref Cam, ref Result);
		if (num < 0 || Cam.CamPoints.Count <= 0)
		{
			return;
		}
		if (OffsetEntities == null)
		{
			OffsetEntities = new List<buEntity>();
		}
		OffsetEntities.Clear();
		for (int i = 0; i <= Cam.EntitiesG1.Count - 1; i++)
		{
			if (Cam.EntitiesG1[i] is buLinearPathCam)
			{
				buLinearPathCam buLinearPathCam2 = Cam.EntitiesG1[i] as buLinearPathCam;
				if (!buLinearPathCam2.isLink)
				{
					buEntity copiedEntity = null;
					buEntity.Copy(Cam.EntitiesG1[i], ref copiedEntity);
					OffsetEntities.Add(copiedEntity);
				}
			}
		}
	}

	public void SaveMWParameter()
	{
		if (clsInit.cMwCalc != null)
		{
			clsVar.varCamWFContourPars.mwPar.Serialize(AppPath.Settings + "\\mwWfContour.bin");
			clsVar.varCamWFContour4XPars.mwPar.Serialize(AppPath.Settings + "\\mwWfContour4X.bin");
			clsVar.varCamWFPocketPars.mwPar.Serialize(AppPath.Settings + "\\mwWfPocket.bin");
			clsVar.varCamDrillPars.mwPar.Serialize(AppPath.Settings + "\\mwDrill.bin");
			clsVar.varCamMeshRoughPars.mwPar.Serialize(AppPath.Settings + "\\mwTmRough.bin");
			clsVar.varCamMeshParallelPars.mwPar.Serialize(AppPath.Settings + "\\mwTmParallel.bin");
			clsVar.varCamMeshConstantZPars.mwPar.Serialize(AppPath.Settings + "\\mwTmConstantZ.bin");
			clsVar.varCamMeshPencilPars.mwPar.Serialize(AppPath.Settings + "\\mwTmPencil.bin");
			clsVar.varCamMeshProjectionPars.mwPar.Serialize(AppPath.Settings + "\\mwTmProjection.bin");
			clsVar.varCamMeshConstantCuspPars.mwPar.Serialize(AppPath.Settings + "\\mwTmConstantCusp.bin");
			clsVar.varCamMeshFlatlandsPars.mwPar.Serialize(AppPath.Settings + "\\mwTmFlatlands.bin");
			string fileName = AppPath.Settings + "\\mwCam.bucamset";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   MW Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<MwCamSettings>");
			arrayList.AddRange(clsVar.varCamWFContourPars.buPar.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamWFContour4XPars.buPar.ToDefAll("_varbuCamWFContour4XPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamWFPocketPars.buPar.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamDrillPars.buPar.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamMeshRoughPars.buPar.ToDefAll("_varbuCamMeshRoughPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamMeshParallelPars.buPar.ToDefAll("_varbuCamMeshParallelPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamMeshConstantZPars.buPar.ToDefAll("_varbuCamMeshContantZPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamMeshPencilPars.buPar.ToDefAll("_varbuCamMeshPencilPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamMeshProjectionPars.buPar.ToDefAll("_varbuCamMeshProjectionPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamMeshFlatlandsPars.buPar.ToDefAll("_varbuCamMeshFlatlandsPars", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(clsVar.varCamMeshConstantCuspPars.buPar.ToDefAll("_varbuCamMeshContantCuspPars", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</MwCamSettings>");
			buFile.SaveToFile(arrayList, fileName);
		}
	}

	public void OpenMWParameter()
	{
		if (clsInit.cMwCalc == null)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\mwWfContour.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamWFContourPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwWfPocket.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamWFPocketPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwWfContour4X.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamWFContour4XPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwDrill.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamDrillPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwTmRough.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamMeshRoughPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwTmParallel.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamMeshParallelPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwTmConstantZ.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamMeshConstantCuspPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwTmPencil.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamMeshPencilPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwTmProjection.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamMeshProjectionPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwTmConstantCusp.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamMeshConstantCuspPars.mwPar.Deserialize(fileInfo.FullName);
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\mwTmFlatlands.bin");
		if (fileInfo.Exists)
		{
			clsVar.varCamMeshFlatlandsPars.mwPar.Deserialize(fileInfo.FullName);
		}
		string fileName = AppPath.Settings + "\\mwCam.bucamset";
		fileInfo = new FileInfo(fileName);
		if (!fileInfo.Exists)
		{
			return;
		}
		ArrayList StringList = new ArrayList();
		buFile.OpenFromFile(fileName, ref StringList);
		try
		{
			ArrayList CalcList = new ArrayList();
			buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, StringList, ref CalcList);
			if (CalcList.Count > 0)
			{
				buSerilization.Decode(StringList, "_varbuCamWFContourPars", SerilizationMode.MultiLine, clsVar.varCamWFContourPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamWFPocketPars", SerilizationMode.MultiLine, clsVar.varCamWFPocketPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamWFContour4XPars", SerilizationMode.MultiLine, clsVar.varCamWFContour4XPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamDrillPars", SerilizationMode.MultiLine, clsVar.varCamDrillPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamMeshRoughPars", SerilizationMode.MultiLine, clsVar.varCamMeshRoughPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamMeshParallelPars", SerilizationMode.MultiLine, clsVar.varCamMeshParallelPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamMeshContantZPars", SerilizationMode.MultiLine, clsVar.varCamMeshConstantZPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamMeshPencilPars", SerilizationMode.MultiLine, clsVar.varCamMeshPencilPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamMeshProjectionPars", SerilizationMode.MultiLine, clsVar.varCamMeshProjectionPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamMeshFlatlandsPars", SerilizationMode.MultiLine, clsVar.varCamMeshFlatlandsPars.buPar);
				buSerilization.Decode(StringList, "_varbuCamMeshContantCuspPars", SerilizationMode.MultiLine, clsVar.varCamMeshConstantCuspPars.buPar);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("MW Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Marble Settings Decoder Error");
		}
	}

	public void ToolDataToCamData(ToolBase5 Tool, ref camParameters5 varBU, ref GeoLib varMW)
	{
		if (clsVar.varCam.CopyToolDataToCamData)
		{
			varBU.Speeds.SpindleSpeed = Tool.CamData.SpindleSpeed;
			varBU.Speeds.SpindleDirection = Tool.CamData.SpindleDirection;
			if (Tool.CamData.FeedFromTool)
			{
				varMW.MachParam.FeedRate = Tool.CamData.FeedSpeed;
				varMW.MachParam.PlungeFeedRate = Tool.CamData.PlungeSpeed;
				varMW.MachParam.RetractFeedRate = Tool.CamData.RetractSpeed;
				varBU.Speeds.Feed = Tool.CamData.FeedSpeed;
				varBU.Speeds.Plunge = Tool.CamData.PlungeSpeed;
				varBU.Speeds.Leave = Tool.CamData.RetractSpeed;
				varBU.Speeds.Finish = Tool.CamData.FinishSpeed;
			}
			if (Tool.CamData.DistanceFromTool)
			{
				varMW.MachParam.FeedRate = Tool.CamData.RapidDistance;
				varMW.MachParam.PlungeFeedRate = Tool.CamData.SafeDistance;
				varMW.MachParam.RetractFeedRate = Tool.CamData.RetractSpeed;
				varBU.Distances.Safe = Tool.CamData.SafeDistance;
				varBU.Speeds.Rapid = Tool.CamData.RapidDistance;
				varBU.Speeds.Leave = Tool.CamData.RetractSpeed;
				varBU.Speeds.Finish = Tool.CamData.FinishSpeed;
			}
		}
	}

	public void CamDataToolData(camParameters5 varBU, ref ToolBase5 Tool)
	{
		if (clsVar.varCam.CopyCamDataToToolData)
		{
			if (varBU.Speeds.SpindleSpeed > 0.0)
			{
				Tool.CamData.SpindleSpeed = varBU.Speeds.SpindleSpeed;
			}
			Tool.CamData.SpindleDirection = varBU.Speeds.SpindleDirection;
			if (clsVar.varCam.CopyCamFeedToToolFeed && varBU.Speeds.Feed > 0.0)
			{
				Tool.CamData.FeedSpeed = varBU.Speeds.Feed;
			}
			if (clsVar.varCam.CopyCamPlungeFeedToToolPlungeFeed && varBU.Speeds.Plunge > 0.0)
			{
				Tool.CamData.PlungeSpeed = varBU.Speeds.Plunge;
			}
			if (clsVar.varCam.CopyCamRetractFeedToToolRetractFeed && varBU.Speeds.Leave > 0.0)
			{
				Tool.CamData.LeaveSpeed = varBU.Speeds.Leave;
			}
		}
	}

	public void CamDataToolData(camParameters5 varBU, GeoLib varMW, ref ToolBase5 Tool)
	{
		if (clsVar.varCam.CopyCamDataToToolData)
		{
			if (varBU.Speeds.SpindleSpeed > 0.0)
			{
				Tool.CamData.SpindleSpeed = varBU.Speeds.SpindleSpeed;
			}
			Tool.CamData.SpindleDirection = varBU.Speeds.SpindleDirection;
			if (clsVar.varCam.CopyCamFeedToToolFeed && varMW.MachParam.FeedRate > 0.0)
			{
				Tool.CamData.FeedSpeed = varMW.MachParam.FeedRate;
			}
			if (clsVar.varCam.CopyCamPlungeFeedToToolPlungeFeed && varMW.MachParam.PlungeFeedRate > 0.0)
			{
				Tool.CamData.PlungeSpeed = varMW.MachParam.PlungeFeedRate;
			}
			if (clsVar.varCam.CopyCamRetractFeedToToolRetractFeed && varMW.MachParam.RetractFeedRate > 0.0)
			{
				Tool.CamData.RetractSpeed = varMW.MachParam.RetractFeedRate;
			}
		}
	}

	public void CamEntitesToEntities(camTp Cam, CamEntitiesToEntitiesOption Option, ref CamEntitiesToEntities calcEntities)
	{
		if (Option.AllAsSingle)
		{
			if (Option.G0EntitiesEnable)
			{
				for (int i = 0; i <= Cam.EntitiesG0.Count - 1; i++)
				{
					Entity entity = buVector5.CopyEntities(Cam.EntitiesG0[i]);
					if (entity.EntityData != null)
					{
						((CustomData)entity.EntityData).typeDefination = entityTypeDefination.CamG0;
					}
					calcEntities.AllEntities.Add(entity);
				}
			}
			if (Option.G1EntitiesEnable)
			{
				for (int j = 0; j <= Cam.EntitiesG1.Count - 1; j++)
				{
					Entity entity2 = buVector5.CopyEntities(Cam.EntitiesG1[j]);
					if (entity2.EntityData != null)
					{
						((CustomData)entity2.EntityData).typeDefination = entityTypeDefination.CamG1;
					}
					calcEntities.AllEntities.Add(entity2);
				}
			}
			if (Option.LeaveEntitiesEnable)
			{
				for (int k = 0; k <= Cam.EntitiesLeave.Count - 1; k++)
				{
					Entity entity3 = buVector5.CopyEntities(Cam.EntitiesLeave[k]);
					if (entity3.EntityData != null)
					{
						((CustomData)entity3.EntityData).typeDefination = entityTypeDefination.CamLeave;
					}
					calcEntities.AllEntities.Add(entity3);
				}
			}
			if (Option.PlungeEntitiesEnable)
			{
				for (int l = 0; l <= Cam.EntitiesPlunge.Count - 1; l++)
				{
					Entity entity4 = buVector5.CopyEntities(Cam.EntitiesPlunge[l]);
					if (entity4.EntityData != null)
					{
						((CustomData)entity4.EntityData).typeDefination = entityTypeDefination.CamPlunge;
					}
					calcEntities.AllEntities.Add(entity4);
				}
			}
			if (Option.LeadInEntitiesEnable)
			{
				for (int m = 0; m <= Cam.EntitiesLeadIn.Count - 1; m++)
				{
					Entity entity5 = buVector5.CopyEntities(Cam.EntitiesLeadIn[m]);
					if (entity5.EntityData != null)
					{
						((CustomData)entity5.EntityData).typeDefination = entityTypeDefination.CamLeadin;
					}
					calcEntities.AllEntities.Add(entity5);
				}
			}
			if (Option.LeadOutEntitiesEnable)
			{
				for (int n = 0; n <= Cam.EntitiesLeadOut.Count - 1; n++)
				{
					Entity entity6 = buVector5.CopyEntities(Cam.EntitiesLeadOut[n]);
					if (entity6.EntityData != null)
					{
						((CustomData)entity6.EntityData).typeDefination = entityTypeDefination.CamLeadOut;
					}
					calcEntities.AllEntities.Add(entity6);
				}
			}
			if (Option.MarkEntitiesEnable)
			{
				for (int num = 0; num <= Cam.EntitiesMark.Count - 1; num++)
				{
					Entity entity7 = buVector5.CopyEntities(Cam.EntitiesMark[num]);
					if (entity7.EntityData != null)
					{
						((CustomData)entity7.EntityData).typeDefination = entityTypeDefination.CamMark;
					}
					calcEntities.AllEntities.Add(entity7);
				}
			}
			if (!Option.OtherEntitiesEnable)
			{
				return;
			}
			for (int num2 = 0; num2 <= Cam.EntitiesOther.Count - 1; num2++)
			{
				Entity entity8 = buVector5.CopyEntities(Cam.EntitiesOther[num2]);
				if (entity8.EntityData != null)
				{
					((CustomData)entity8.EntityData).typeDefination = entityTypeDefination.CamOther;
				}
				calcEntities.AllEntities.Add(entity8);
			}
			return;
		}
		if (Option.G0EntitiesEnable)
		{
			for (int num3 = 0; num3 <= Cam.EntitiesG0.Count - 1; num3++)
			{
				Entity entity9 = buVector5.CopyEntities(Cam.EntitiesG0[num3]);
				if (entity9.EntityData != null)
				{
					((CustomData)entity9.EntityData).typeDefination = entityTypeDefination.CamG0;
				}
				calcEntities.G0Entities.Add(entity9);
			}
		}
		if (Option.G1EntitiesEnable)
		{
			for (int num4 = 0; num4 <= Cam.EntitiesG1.Count - 1; num4++)
			{
				Entity entity10 = buVector5.CopyEntities(Cam.EntitiesG1[num4]);
				if (entity10.EntityData != null)
				{
					((CustomData)entity10.EntityData).typeDefination = entityTypeDefination.CamG1;
				}
				calcEntities.G1Entities.Add(entity10);
			}
		}
		if (Option.LeaveEntitiesEnable)
		{
			for (int num5 = 0; num5 <= Cam.EntitiesLeave.Count - 1; num5++)
			{
				Entity entity11 = buVector5.CopyEntities(Cam.EntitiesLeave[num5]);
				if (entity11.EntityData != null)
				{
					((CustomData)entity11.EntityData).typeDefination = entityTypeDefination.CamLeave;
				}
				calcEntities.LeaveEntities.Add(entity11);
			}
		}
		if (Option.PlungeEntitiesEnable)
		{
			for (int num6 = 0; num6 <= Cam.EntitiesPlunge.Count - 1; num6++)
			{
				Entity entity12 = buVector5.CopyEntities(Cam.EntitiesPlunge[num6]);
				if (entity12.EntityData != null)
				{
					((CustomData)entity12.EntityData).typeDefination = entityTypeDefination.CamPlunge;
				}
				calcEntities.PlungeEntities.Add(entity12);
			}
		}
		if (Option.LeadInEntitiesEnable)
		{
			for (int num7 = 0; num7 <= Cam.EntitiesLeadIn.Count - 1; num7++)
			{
				Entity entity13 = buVector5.CopyEntities(Cam.EntitiesLeadIn[num7]);
				if (entity13.EntityData != null)
				{
					((CustomData)entity13.EntityData).typeDefination = entityTypeDefination.CamLeadin;
				}
				calcEntities.LeadInEntities.Add(entity13);
			}
		}
		if (Option.LeadOutEntitiesEnable)
		{
			for (int num8 = 0; num8 <= Cam.EntitiesLeadOut.Count - 1; num8++)
			{
				Entity entity14 = buVector5.CopyEntities(Cam.EntitiesLeadOut[num8]);
				if (entity14.EntityData != null)
				{
					((CustomData)entity14.EntityData).typeDefination = entityTypeDefination.CamLeadOut;
				}
				calcEntities.LeadOutEntities.Add(entity14);
			}
		}
		if (Option.MarkEntitiesEnable)
		{
			for (int num9 = 0; num9 <= Cam.EntitiesMark.Count - 1; num9++)
			{
				Entity entity15 = buVector5.CopyEntities(Cam.EntitiesMark[num9]);
				if (entity15.EntityData != null)
				{
					((CustomData)entity15.EntityData).typeDefination = entityTypeDefination.CamMark;
				}
				calcEntities.MarkEntities.Add(entity15);
			}
		}
		if (!Option.OtherEntitiesEnable)
		{
			return;
		}
		for (int num10 = 0; num10 <= Cam.EntitiesOther.Count - 1; num10++)
		{
			Entity entity16 = buVector5.CopyEntities(Cam.EntitiesOther[num10]);
			if (entity16.EntityData != null)
			{
				((CustomData)entity16.EntityData).typeDefination = entityTypeDefination.CamOther;
			}
			calcEntities.OtherEntities.Add(entity16);
		}
	}

	public void CamEntitesTobuEntities(camTp Cam, CamEntitiesToEntitiesOption Option, ref CamEntitiesTobuEntities calcEntities)
	{
		if (Option.AllAsSingle)
		{
			if (Option.G0EntitiesEnable)
			{
				for (int i = 0; i <= Cam.EntitiesG0.Count - 1; i++)
				{
					buEntity copiedEntity = null;
					buEntity.Copy(Cam.EntitiesG0[i], ref copiedEntity);
					if (copiedEntity != null)
					{
						copiedEntity.typeDefination = entityTypeDefination.CamG0;
					}
					if (Cam.EntitiesG0[i] is buArcCam && ((buArcCam)Cam.EntitiesG0[i]).isReverse)
					{
						copiedEntity.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.AllEntities.Add(copiedEntity);
				}
			}
			if (Option.G1EntitiesEnable)
			{
				for (int j = 0; j <= Cam.EntitiesG1.Count - 1; j++)
				{
					buEntity copiedEntity2 = null;
					buEntity.Copy(Cam.EntitiesG1[j], ref copiedEntity2);
					if (copiedEntity2 != null)
					{
						copiedEntity2.typeDefination = entityTypeDefination.CamG1;
					}
					copiedEntity2.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					if (Cam.EntitiesG1[j] is buArcCam && ((buArcCam)Cam.EntitiesG1[j]).isReverse)
					{
						copiedEntity2.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.AllEntities.Add(copiedEntity2);
				}
			}
			if (Option.LeaveEntitiesEnable)
			{
				for (int k = 0; k <= Cam.EntitiesLeave.Count - 1; k++)
				{
					buEntity copiedEntity3 = null;
					buEntity.Copy(Cam.EntitiesLeave[k], ref copiedEntity3);
					if (copiedEntity3 != null)
					{
						copiedEntity3.typeDefination = entityTypeDefination.CamLeave;
					}
					copiedEntity3.Info.CamSpeed = Cam.Parameter.Speeds.Leave;
					if (Cam.EntitiesLeave[k] is buArcCam && ((buArcCam)Cam.EntitiesLeave[k]).isReverse)
					{
						copiedEntity3.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.AllEntities.Add(copiedEntity3);
				}
			}
			if (Option.PlungeEntitiesEnable)
			{
				for (int l = 0; l <= Cam.EntitiesPlunge.Count - 1; l++)
				{
					buEntity copiedEntity4 = null;
					buEntity.Copy(Cam.EntitiesPlunge[l], ref copiedEntity4);
					if (copiedEntity4 != null)
					{
						copiedEntity4.typeDefination = entityTypeDefination.CamPlunge;
					}
					copiedEntity4.Info.CamSpeed = Cam.Parameter.Speeds.Plunge;
					if (Cam.EntitiesPlunge[l] is buArcCam && ((buArcCam)Cam.EntitiesPlunge[l]).isReverse)
					{
						copiedEntity4.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.AllEntities.Add(copiedEntity4);
				}
			}
			if (Option.LeadInEntitiesEnable)
			{
				for (int m = 0; m <= Cam.EntitiesLeadIn.Count - 1; m++)
				{
					buEntity copiedEntity5 = null;
					buEntity.Copy(Cam.EntitiesLeadIn[m], ref copiedEntity5);
					if (copiedEntity5 != null)
					{
						copiedEntity5.typeDefination = entityTypeDefination.CamLeadin;
					}
					copiedEntity5.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					if (Cam.EntitiesLeadIn[m] is buArcCam && ((buArcCam)Cam.EntitiesLeadIn[m]).isReverse)
					{
						copiedEntity5.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.AllEntities.Add(copiedEntity5);
				}
			}
			if (Option.LeadOutEntitiesEnable)
			{
				for (int n = 0; n <= Cam.EntitiesLeadOut.Count - 1; n++)
				{
					buEntity copiedEntity6 = null;
					buEntity.Copy(Cam.EntitiesLeadOut[n], ref copiedEntity6);
					if (copiedEntity6 != null)
					{
						copiedEntity6.typeDefination = entityTypeDefination.CamLeadOut;
					}
					copiedEntity6.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					if (Cam.EntitiesLeadOut[n] is buArcCam && ((buArcCam)Cam.EntitiesLeadOut[n]).isReverse)
					{
						copiedEntity6.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.AllEntities.Add(copiedEntity6);
				}
			}
			if (Option.MarkEntitiesEnable)
			{
				for (int num = 0; num <= Cam.EntitiesMark.Count - 1; num++)
				{
					buEntity copiedEntity7 = null;
					buEntity.Copy(Cam.EntitiesMark[num], ref copiedEntity7);
					if (copiedEntity7 != null)
					{
						copiedEntity7.typeDefination = entityTypeDefination.CamMark;
					}
					if (Cam.EntitiesMark[num] is buArcCam && ((buArcCam)Cam.EntitiesMark[num]).isReverse)
					{
						copiedEntity7.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.AllEntities.Add(copiedEntity7);
				}
			}
			if (!Option.OtherEntitiesEnable)
			{
				return;
			}
			for (int num2 = 0; num2 <= Cam.EntitiesOther.Count - 1; num2++)
			{
				buEntity copiedEntity8 = null;
				buEntity.Copy(Cam.EntitiesOther[num2], ref copiedEntity8);
				if (copiedEntity8 != null)
				{
					copiedEntity8.typeDefination = entityTypeDefination.CamOther;
				}
				if (Cam.EntitiesOther[num2] is buArcCam && ((buArcCam)Cam.EntitiesOther[num2]).isReverse)
				{
					copiedEntity8.sortDirection = entitySortDirection.Reverse;
				}
				calcEntities.AllEntities.Add(copiedEntity8);
			}
			return;
		}
		if (Option.G0EntitiesEnable)
		{
			for (int num3 = 0; num3 <= Cam.EntitiesG0.Count - 1; num3++)
			{
				buEntity copiedEntity9 = null;
				buEntity.Copy(Cam.EntitiesG0[num3], ref copiedEntity9);
				if (copiedEntity9 != null)
				{
					copiedEntity9.typeDefination = entityTypeDefination.CamG0;
				}
				if (Cam.EntitiesG0[num3] is buArcCam && ((buArcCam)Cam.EntitiesG0[num3]).isReverse)
				{
					copiedEntity9.sortDirection = entitySortDirection.Reverse;
				}
				calcEntities.G0Entities.Add(copiedEntity9);
			}
		}
		if (Option.G1EntitiesEnable)
		{
			if (!(Option.G1EntitiesFromOriginal & (Cam.EntitiesG1Orj.Count > 0)))
			{
				for (int num4 = 0; num4 <= Cam.EntitiesG1.Count - 1; num4++)
				{
					buEntity copiedEntity10 = null;
					buEntity.Copy(Cam.EntitiesG1[num4], ref copiedEntity10);
					if (copiedEntity10 != null)
					{
						copiedEntity10.typeDefination = entityTypeDefination.CamG1;
						copiedEntity10.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					}
					if (Cam.EntitiesG1[num4] is buArcCam && ((buArcCam)Cam.EntitiesG1[num4]).isReverse)
					{
						copiedEntity10.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.G1Entities.Add(copiedEntity10);
				}
			}
			else
			{
				for (int num5 = 0; num5 <= Cam.EntitiesG1Orj.Count - 1; num5++)
				{
					buEntity copiedEntity11 = null;
					buEntity.Copy(Cam.EntitiesG1Orj[num5], ref copiedEntity11);
					if (copiedEntity11 != null)
					{
						copiedEntity11.typeDefination = entityTypeDefination.CamG1;
					}
					if (Cam.EntitiesG1Orj[num5] is buArcCam && ((buArcCam)Cam.EntitiesG1Orj[num5]).isReverse)
					{
						copiedEntity11.sortDirection = entitySortDirection.Reverse;
					}
					copiedEntity11.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					if (calcEntities.G1Entities.Count > 0)
					{
						Point3D pntStart = new Point3D();
						Point3D pntEnd = new Point3D();
						Point3D pntEnd2 = new Point3D();
						clsInit.cVector5.GetEntityEndPointByCamDirection(calcEntities.G1Entities[calcEntities.G1Entities.Count - 1], ref pntEnd2);
						clsInit.cVector5.GetEntityEndPointByCamDirection(copiedEntity11, ref pntEnd);
						clsInit.cVector5.GetEntityStartPointByCamDirection(copiedEntity11, ref pntStart);
						if (!buCompare5.EQ(pntEnd2, pntStart) && buCompare5.EQ(pntEnd2, pntEnd))
						{
							copiedEntity11.sortDirection = entitySortDirection.Reverse;
						}
					}
					calcEntities.G1Entities.Add(copiedEntity11);
				}
			}
		}
		if (Option.LeaveEntitiesEnable)
		{
			for (int num6 = 0; num6 <= Cam.EntitiesLeave.Count - 1; num6++)
			{
				buEntity copiedEntity12 = null;
				buEntity.Copy(Cam.EntitiesLeave[num6], ref copiedEntity12);
				if (copiedEntity12 != null)
				{
					copiedEntity12.typeDefination = entityTypeDefination.CamLeave;
					copiedEntity12.Info.CamSpeed = Cam.Parameter.Speeds.Leave;
				}
				if (Cam.EntitiesLeave[num6] is buArcCam && ((buArcCam)Cam.EntitiesLeave[num6]).isReverse)
				{
					copiedEntity12.sortDirection = entitySortDirection.Reverse;
				}
				calcEntities.LeaveEntities.Add(copiedEntity12);
			}
		}
		if (Option.PlungeEntitiesEnable)
		{
			for (int num7 = 0; num7 <= Cam.EntitiesPlunge.Count - 1; num7++)
			{
				buEntity copiedEntity13 = null;
				buEntity.Copy(Cam.EntitiesPlunge[num7], ref copiedEntity13);
				if (copiedEntity13 != null)
				{
					copiedEntity13.typeDefination = entityTypeDefination.CamPlunge;
				}
				copiedEntity13.Info.CamSpeed = Cam.Parameter.Speeds.Plunge;
				if (Cam.EntitiesPlunge[num7] is buArcCam && ((buArcCam)Cam.EntitiesPlunge[num7]).isReverse)
				{
					copiedEntity13.sortDirection = entitySortDirection.Reverse;
				}
				calcEntities.PlungeEntities.Add(copiedEntity13);
			}
		}
		if (Option.LeadInEntitiesEnable)
		{
			if (!Option.G1EntitiesFromOriginal)
			{
				for (int num8 = 0; num8 <= Cam.EntitiesLeadIn.Count - 1; num8++)
				{
					List<Point3D> list = new List<Point3D>();
					list.AddRange(Cam.EntitiesLeadIn[num8].Vertices.ToList());
					if (Cam.EntitiesLeadIn[num8] is buArcCam && ((buArcCam)Cam.EntitiesLeadIn[num8]).isReverse)
					{
						list.Reverse();
					}
					buLinearPath buLinearPath2 = new buLinearPath(list);
					if (buLinearPath2 != null)
					{
						buLinearPath2.typeDefination = entityTypeDefination.CamLeadin;
					}
					buLinearPath2.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					calcEntities.LeadInEntities.Add(buLinearPath2);
				}
			}
			else
			{
				for (int num9 = 0; num9 <= Cam.EntitiesLeadIn.Count - 1; num9++)
				{
					buEntity copiedEntity14 = null;
					buEntity.Copy(Cam.EntitiesLeadIn[num9], ref copiedEntity14);
					if (copiedEntity14 != null)
					{
						copiedEntity14.typeDefination = entityTypeDefination.CamLeadin;
					}
					copiedEntity14.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					if (Cam.EntitiesLeadIn[num9] is buArcCam && ((buArcCam)Cam.EntitiesLeadIn[num9]).isReverse)
					{
						copiedEntity14.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.LeadInEntities.Add(copiedEntity14);
				}
			}
		}
		if (Option.LeadOutEntitiesEnable)
		{
			if (!Option.G1EntitiesFromOriginal)
			{
				for (int num10 = 0; num10 <= Cam.EntitiesLeadOut.Count - 1; num10++)
				{
					List<Point3D> list2 = new List<Point3D>();
					list2.AddRange(Cam.EntitiesLeadOut[num10].Vertices.ToList());
					if (Cam.EntitiesLeadOut[num10] is buArcCam && ((buArcCam)Cam.EntitiesLeadOut[num10]).isReverse)
					{
						list2.Reverse();
					}
					buLinearPath buLinearPath3 = new buLinearPath(list2);
					if (buLinearPath3 != null)
					{
						buLinearPath3.typeDefination = entityTypeDefination.CamLeadOut;
					}
					buLinearPath3.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					calcEntities.LeadOutEntities.Add(buLinearPath3);
				}
			}
			else
			{
				for (int num11 = 0; num11 <= Cam.EntitiesLeadOut.Count - 1; num11++)
				{
					buEntity copiedEntity15 = null;
					buEntity.Copy(Cam.EntitiesLeadOut[num11], ref copiedEntity15);
					if (copiedEntity15 != null)
					{
						copiedEntity15.typeDefination = entityTypeDefination.CamLeadOut;
					}
					copiedEntity15.Info.CamSpeed = Cam.Parameter.Speeds.Feed;
					if (Cam.EntitiesLeadOut[num11] is buArcCam && ((buArcCam)Cam.EntitiesLeadOut[num11]).isReverse)
					{
						copiedEntity15.sortDirection = entitySortDirection.Reverse;
					}
					calcEntities.LeadOutEntities.Add(copiedEntity15);
				}
			}
		}
		if (Option.MarkEntitiesEnable)
		{
			for (int num12 = 0; num12 <= Cam.EntitiesMark.Count - 1; num12++)
			{
				buEntity copiedEntity16 = null;
				buEntity.Copy(Cam.EntitiesMark[num12], ref copiedEntity16);
				if (copiedEntity16 != null)
				{
					copiedEntity16.typeDefination = entityTypeDefination.CamMark;
				}
				if (Cam.EntitiesMark[num12] is buArcCam && ((buArcCam)Cam.EntitiesMark[num12]).isReverse)
				{
					copiedEntity16.sortDirection = entitySortDirection.Reverse;
				}
				calcEntities.MarkEntities.Add(copiedEntity16);
			}
		}
		if (!Option.OtherEntitiesEnable)
		{
			return;
		}
		for (int num13 = 0; num13 <= Cam.EntitiesOther.Count - 1; num13++)
		{
			buEntity copiedEntity17 = null;
			buEntity.Copy(Cam.EntitiesOther[num13], ref copiedEntity17);
			if (copiedEntity17 != null)
			{
				copiedEntity17.typeDefination = entityTypeDefination.CamOther;
			}
			if (Cam.EntitiesOther[num13] is buArcCam && ((buArcCam)Cam.EntitiesOther[num13]).isReverse)
			{
				copiedEntity17.sortDirection = entitySortDirection.Reverse;
			}
			calcEntities.OtherEntities.Add(copiedEntity17);
		}
	}

	public void OffsetEntities(List<buEntity> refEntities, double Offset, ref List<buEntity> OffsetedEntities, CamOpenContourType OpenOffsetType = CamOpenContourType.Center, CamClosedContourType ClosedOffsetType = CamClosedContourType.Outter)
	{
		List<Entity> copiedEntities = new List<Entity>();
		List<Entity> OffsetedEntities2 = new List<Entity>();
		buEntity.Copy(refEntities, ref copiedEntities);
		OffsetEntities(copiedEntities, Offset, ref OffsetedEntities2, OpenOffsetType, ClosedOffsetType);
		if (OffsetedEntities == null)
		{
			OffsetedEntities = new List<buEntity>();
		}
		OffsetedEntities.Clear();
		buEntity.Copy(OffsetedEntities2, ref OffsetedEntities);
	}

	public void OffsetEntities(List<Entity> refEntities, double Offset, ref List<Entity> OffsetedEntities, CamOpenContourType OpenOffsetType = CamOpenContourType.Center, CamClosedContourType ClosedOffsetType = CamClosedContourType.Outter)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
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
		ToolBase5 toolBase = new ToolBase5();
		toolBase.Purpose = ToolPurpose.Milling;
		toolBase.Geometry.GeometryType = buClass.ToolType.Flat;
		toolBase.Geometry.Diameter = Offset * 2.0;
		toolBase.Geometry.Length = 100.0;
		CamEntities.Clear();
		buEntity.Copy(refEntities, ref CamEntities);
		camParameters5 camParameters6 = new camParameters5();
		GeoLib mWPar = new GeoLib(Unit.Metric);
		camParameters6.Offsets.OpenContour = OpenOffsetType;
		camParameters6.Offsets.ClosedContour = ClosedOffsetType;
		camParameters6.Distances.Air = 0.0;
		camParameters6.Distances.Safe = 0.0;
		camParameters6.Distances.Rapid = 0.0;
		camParameters6.Distances.EntryAndExit = 0.0;
		camParameters6.Distances.EntryAndExit = 0.0;
		mWPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(mWPar, camParameters6);
		varMWCamWFContourPars = buMWCalcs.CopyCamParameter(mWPar, camParameters6, out varbuCamWFContourPars);
		varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = true;
		camResult Result = null;
		camTp Cam = null;
		clsInit.appMW.doWireframeContour(mWCalculationOptions, toolBase, ref Cam, ref Result);
		OffsetedEntities = new List<Entity>();
		if (Cam != null)
		{
			for (int i = 0; i <= Cam.EntitiesG1Orj.Count - 1; i++)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(Cam.EntitiesG1Orj[i], ref copiedEnt);
				copiedEnt.EntityData = new CustomData();
				OffsetedEntities.Add(copiedEnt);
			}
		}
	}

	public void CreateToolWithToolDirection(ToolBase5 Tool, bool ToolCut, bool ToolBody, bool Arbor, bool Holder, bool ZeroIsMachineSide, ref List<Mesh> refMeshes)
	{
		CreateTool(Tool, ToolCut, ToolBody, Arbor, Holder, ref refMeshes);
		if (Tool.Geometry.ToolDirection.Z == 1.0)
		{
			for (int i = 0; i <= refMeshes.Count - 1; i++)
			{
				refMeshes[i].Rotate(buConversion5.DegreeToRadian(180.0), new Vector3D(1.0, 0.0, 0.0));
			}
		}
		if (Tool.Geometry.ToolDirection.X == 1.0)
		{
			for (int j = 0; j <= refMeshes.Count - 1; j++)
			{
				refMeshes[j].Rotate(buConversion5.DegreeToRadian(-90.0), new Vector3D(0.0, 1.0, 0.0));
			}
		}
		if (Tool.Geometry.ToolDirection.X == -1.0)
		{
			for (int k = 0; k <= refMeshes.Count - 1; k++)
			{
				refMeshes[k].Rotate(buConversion5.DegreeToRadian(90.0), new Vector3D(0.0, 1.0, 0.0));
			}
		}
		if (Tool.Geometry.ToolDirection.Y == 1.0)
		{
			for (int l = 0; l <= refMeshes.Count - 1; l++)
			{
				refMeshes[l].Rotate(buConversion5.DegreeToRadian(-90.0), new Vector3D(1.0, 0.0, 0.0));
			}
		}
		if (Tool.Geometry.ToolDirection.Y == -1.0)
		{
			for (int m = 0; m <= refMeshes.Count - 1; m++)
			{
				refMeshes[m].Rotate(buConversion5.DegreeToRadian(90.0), new Vector3D(1.0, 0.0, 0.0));
			}
		}
		if (!ZeroIsMachineSide)
		{
			return;
		}
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		clsInit.cVector5.BoxSizeCalculate(refMeshes, ref MinPoint, ref MidPoint, ref MaxPoint);
		if (Tool.Geometry.ToolDirection.Z == 1.0)
		{
			for (int n = 0; n <= refMeshes.Count - 1; n++)
			{
				refMeshes[n].Translate(0.0, 0.0, 0.0 - MinPoint.Z);
			}
		}
		if (Tool.Geometry.ToolDirection.Z == -1.0)
		{
			for (int num = 0; num <= refMeshes.Count - 1; num++)
			{
				refMeshes[num].Translate(0.0, 0.0, 0.0 - MaxPoint.Z);
			}
		}
		if (Tool.Geometry.ToolDirection.X == 1.0)
		{
			for (int num2 = 0; num2 <= refMeshes.Count - 1; num2++)
			{
				refMeshes[num2].Translate(0.0 - MinPoint.X, 0.0);
			}
		}
		if (Tool.Geometry.ToolDirection.X == -1.0)
		{
			for (int num3 = 0; num3 <= refMeshes.Count - 1; num3++)
			{
				refMeshes[num3].Translate(0.0 - MaxPoint.X, 0.0);
			}
		}
		if (Tool.Geometry.ToolDirection.Y == 1.0)
		{
			for (int num4 = 0; num4 <= refMeshes.Count - 1; num4++)
			{
				refMeshes[num4].Translate(0.0, 0.0 - MaxPoint.Y);
			}
		}
		if (Tool.Geometry.ToolDirection.Y == -1.0)
		{
			for (int num5 = 0; num5 <= refMeshes.Count - 1; num5++)
			{
				refMeshes[num5].Translate(0.0, 0.0 - MinPoint.Y);
			}
		}
	}

	public void CreateTool(ToolBase5 Tool, bool ToolCut, bool ToolBody, bool Arbor, bool Holder, ref List<Mesh> refMeshes)
	{
		Tool mwTool = null;
		Meshd val = null;
		Mesh mesh = null;
		clsInit.cMwCalc.CreateMWTool(Tool, ref mwTool);
		if (ToolCut && mwTool != (Tool)null)
		{
			val = MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.CuttingPart);
			mesh = buMWCalcs.ConvertToDevDeptMesh(val);
			mesh.Color = Color.FromArgb(Tool.Display.ToolCutSolid.SkinTransperancy, Tool.Display.ToolCutSolid.SkinColor);
			mesh.ColorMethod = colorMethodType.byEntity;
			if (mesh.Vertices.Length > 1)
			{
				refMeshes.Add(mesh);
			}
		}
		if (ToolBody)
		{
			if (!((Tool.Geometry.GeometryType != buClass.ToolType.Slot) & (Tool.Geometry.GeometryType != buClass.ToolType.Saw)))
			{
				if (Tool.Geometry.GeometryType != buClass.ToolType.Saw)
				{
					if (((Tool.Geometry.ShoulderLength > 0.0) & (Tool.Geometry.ShoulderDiameter > 0.0)) && mwTool != (Tool)null)
					{
						val = MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.NonCuttingPart);
						mesh = buMWCalcs.ConvertToDevDeptMesh(val);
						mesh.Color = Color.FromArgb(Tool.Display.ToolBodySolid.SkinTransperancy, Tool.Display.ToolBodySolid.SkinColor);
						mesh.ColorMethod = colorMethodType.byEntity;
						if (mesh.Vertices.Length > 1)
						{
							refMeshes.Add(mesh);
						}
					}
				}
				else
				{
					mesh = Mesh.CreateCylinder(Tool.Geometry.DiameterBody, Tool.Geometry.Length, 20);
					mesh.Color = Color.FromArgb(Tool.Display.ToolBodySolid.SkinTransperancy, Tool.Display.ToolBodySolid.SkinColor);
					mesh.ColorMethod = colorMethodType.byEntity;
					if (mesh.Vertices.Length > 1)
					{
						refMeshes.Add(mesh);
					}
				}
			}
			else if (mwTool != (Tool)null)
			{
				val = MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.NonCuttingPart);
				mesh = buMWCalcs.ConvertToDevDeptMesh(val);
				mesh.Color = Color.FromArgb(Tool.Display.ToolBodySolid.SkinTransperancy, Tool.Display.ToolBodySolid.SkinColor);
				mesh.ColorMethod = colorMethodType.byEntity;
				if (mesh.Vertices.Length > 1)
				{
					refMeshes.Add(mesh);
				}
			}
		}
		if (Arbor && mwTool != (Tool)null)
		{
			val = MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.Arbor);
			mesh = buMWCalcs.ConvertToDevDeptMesh(val);
			mesh.Color = Color.FromArgb(Tool.Display.ArborSolid.SkinTransperancy, Tool.Display.ArborSolid.SkinColor);
			mesh.ColorMethod = colorMethodType.byEntity;
			if (mesh.Vertices.Length > 1)
			{
				refMeshes.Add(mesh);
			}
		}
		if (Holder && mwTool != (Tool)null)
		{
			val = MeshHelper.CreateToolMeshD(mwTool, 0.01, ToolMeshType.Holder);
			mesh = buMWCalcs.ConvertToDevDeptMesh(val);
			mesh.Color = Color.FromArgb(Tool.Display.HolderSolid.SkinTransperancy, Tool.Display.HolderSolid.SkinColor);
			mesh.ColorMethod = colorMethodType.byEntity;
			if (mesh.Vertices.Length > 1)
			{
				refMeshes.Add(mesh);
			}
		}
	}
}
