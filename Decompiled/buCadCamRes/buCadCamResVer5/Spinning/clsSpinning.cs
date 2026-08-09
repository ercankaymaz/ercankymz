using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Spining;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Spinning;

public class clsSpinning
{
	public static SpinPattern varMetalSpinning = new SpinPattern();

	public static SpinPipePattern varMetalPipeSpinning = new SpinPipePattern();

	public SpinPatternRuntime varSpinningRuntime = null;

	public static F_MetalSpinning frmSpin = null;

	public static F_MetalPipeSpinning frmSpinPipe = null;

	public List<Entity> BaseFinishOffsetedEntities = null;

	public List<Entity> BaseRoughtOffsetedEntities = null;

	public List<Entity> calcEnt = null;

	public List<Entity> calcEntReturn = null;

	public List<List<Entity>> tempCalcEntitities = null;

	public List<SpinCalculatedData> CalculatedEntitiesList = null;

	public Point3D pntStart = new Point3D();

	public Point3D pntLastCalc = new Point3D();

	public double TotalLength = 0.0;

	public void Init()
	{
		varSpinningRuntime = new SpinPatternRuntime();
		frmSpin = new F_MetalSpinning();
		frmSpin.ShowPath += ShowPath;
		frmSpin.SpinValueChanged += ValueChanged;
		frmSpinPipe = new F_MetalPipeSpinning();
		frmSpinPipe.ShowPath += ShowPipePath;
		frmSpinPipe.SpinValueChanged += ValuePipeChanged;
	}

	public void cmdSpinning()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.drawObjectSpinPattern;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doSpinPattern();
				return;
			}
			ccVars.stpDrawing = 2;
			clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSpinningEdit()
	{
		try
		{
			if (CalculatedEntitiesList.Count == 0)
			{
				return;
			}
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			clsInit.appCommand.cmdCamRemoveAll(DontAskQuestion: true);
			if (CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].isMoveSafe)
			{
				CalculatedEntitiesList.RemoveAt(CalculatedEntitiesList.Count - 1);
			}
			if (CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].isFinished)
			{
				if (CalculatedEntitiesList.Count < 3)
				{
					pntStart = buVector5.ToPoint3D(CalculatedEntitiesList[0].StartPoint);
				}
				else
				{
					CalculatedEntitiesList.RemoveAt(CalculatedEntitiesList.Count - 1);
					pntStart = buVector5.ToPoint3D(CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].StartPoint);
					CalculatedEntitiesList.RemoveAt(CalculatedEntitiesList.Count - 1);
				}
			}
			frmSpin.PropertiesForm.TopMost = true;
			frmSpin.varSpinPattern = new SpinPattern(varMetalSpinning);
			frmSpin.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			frmSpin.Init();
			frmSpin.Show();
			SpinPatternCommand spinPatternCommand = new SpinPatternCommand();
			spinPatternCommand.ShowPattern = true;
			ShowPath(null, spinPatternCommand);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSpinningSettings()
	{
		try
		{
			F_MetalSpinningSettings f_MetalSpinningSettings = new F_MetalSpinningSettings();
			f_MetalSpinningSettings.varSpinPattern = new SpinPattern(varMetalSpinning);
			f_MetalSpinningSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
			f_MetalSpinningSettings.Init();
			f_MetalSpinningSettings.ShowDialog();
			if (f_MetalSpinningSettings.PropertiesForm.Result == DialogResult.OK)
			{
				varMetalSpinning = new SpinPattern(f_MetalSpinningSettings.varSpinPattern);
				frmSpin.varSpinPattern = new SpinPattern(f_MetalSpinningSettings.varSpinPattern);
				clsFiles.SaveParameter();
				SpinPatternCommand spinPatternCommand = new SpinPatternCommand();
				spinPatternCommand.ShowPattern = true;
				ShowPath(null, spinPatternCommand);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdShowCode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					string Lines = "";
					clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
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
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
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

	public void cmdCreateCode()
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
						clsVar.varInterface.pathGCode = buFile.GetPath(saveFileDialog.FileName);
						string Lines = "";
						clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, ccVars.PostActive, ref Lines);
						buFile.SaveToFile(Lines, saveFileDialog.FileName);
						clsFiles.SaveParameter();
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
					}
				}
				else
				{
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
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

	public void cmd3DMaterial()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.surfaceRevolveByCurve;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doMaterialSurface();
				return;
			}
			ccVars.stpDrawing = 1;
			clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdPipeSpinning()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			doSpinPipePattern();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doSpinPipePattern()
	{
		frmSpinPipe.PropertiesForm.TopMost = true;
		frmSpinPipe.varSpinPattern = new SpinPipePattern(varMetalPipeSpinning);
		frmSpinPipe.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		frmSpinPipe.Init();
		frmSpinPipe.Show();
		SpinPatternCommand spinPatternCommand = new SpinPatternCommand();
		spinPatternCommand.ShowPattern = true;
		ShowPipePath(null, spinPatternCommand);
	}

	public void doSpinPattern()
	{
		SortSettings sortSettings = new SortSettings();
		SortResult Result = new SortResult();
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> SortedEntities = new List<Entity>();
		List<Entity> copiedEnt = new List<Entity>();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		CalculatedEntitiesList = new List<SpinCalculatedData>();
		varSpinningRuntime.isFinish = false;
		SelectionOption selectionOption = new SelectionOption();
		selectionOption.SplitArcIfGreatThen180 = true;
		selectionOption.CircleToArc = true;
		clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
		for (int i = 0; i <= selectedEntities.Count - 1; i++)
		{
			if (selectedEntities[i] is Curve)
			{
				Entity LinearPathEntity = null;
				clsInit.cVector5.EntitiesToLinearPath(selectedEntities[i], 0.001, ref LinearPathEntity);
				selectedEntities[i] = LinearPathEntity;
			}
		}
		sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
		if (ccVars.SelectionOP.ClickList.Count <= 0)
		{
			clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.Selections[0].pntClick, ref selectedEntities, sortSettings, ref SortedEntities, ref Result);
		}
		else
		{
			sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
			clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref selectedEntities, sortSettings, ref SortedEntities, ref Result);
		}
		buVector5.CopyEntities(SortedEntities, ref copiedEnt);
		if (varMetalSpinning.CurveOffset != 0.0)
		{
			CompositeCurve Curve = null;
			clsInit.appCommand.EntitiesToCompositeCurve(SortedEntities, 0.001, ref Curve);
			ICurve[] array = Curve.Offset(varMetalSpinning.CurveOffset, Vector3D.AxisZ, sharp: false);
			CompositeCurve compositeCurve = array[0] as CompositeCurve;
			compositeCurve.Regen(0.1);
			if (compositeCurve.BoxMin.Y < Curve.BoxMin.Y)
			{
				array = Curve.Offset(0.0 - varMetalSpinning.CurveOffset, Vector3D.AxisZ, sharp: false);
				compositeCurve = array[0] as CompositeCurve;
				compositeCurve.Regen(0.1);
			}
			if (compositeCurve != null)
			{
				List<Entity> refEntities = new List<Entity>();
				clsInit.appCommand.CompositeCurveToEntities(compositeCurve, 0.001, ref refEntities);
				SortedEntities.Clear();
				SortedEntities = new List<Entity>();
				if (ccVars.SelectionOP.ClickList.Count <= 0)
				{
					clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.Selections[0].pntClick, ref refEntities, sortSettings, ref SortedEntities, ref Result);
				}
				else
				{
					sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
					clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref refEntities, sortSettings, ref SortedEntities, ref Result);
				}
			}
		}
		if (varMetalSpinning.CurveFinishOffset == 0.0)
		{
			buVector5.CopyEntities(SortedEntities, ref copiedEnt);
		}
		else
		{
			CompositeCurve Curve2 = null;
			clsInit.appCommand.EntitiesToCompositeCurve(copiedEnt, 0.001, ref Curve2);
			ICurve[] array2 = Curve2.Offset(varMetalSpinning.CurveFinishOffset, Vector3D.AxisZ, sharp: false);
			CompositeCurve compositeCurve2 = (CompositeCurve)array2[0];
			compositeCurve2.Regen(0.1);
			if (compositeCurve2.BoxMin.Y < Curve2.BoxMin.Y)
			{
				array2 = Curve2.Offset(0.0 - varMetalSpinning.CurveFinishOffset, Vector3D.AxisZ, sharp: false);
				compositeCurve2 = (CompositeCurve)array2[0];
				compositeCurve2.Regen(0.1);
			}
			if (compositeCurve2 != null)
			{
				List<Entity> refEntities2 = new List<Entity>();
				clsInit.appCommand.CompositeCurveToEntities(compositeCurve2, 0.001, ref refEntities2);
				copiedEnt.Clear();
				copiedEnt = new List<Entity>();
				if (ccVars.SelectionOP.ClickList.Count <= 0)
				{
					clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.Selections[0].pntClick, ref refEntities2, sortSettings, ref copiedEnt, ref Result);
				}
				else
				{
					sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
					clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref refEntities2, sortSettings, ref copiedEnt, ref Result);
				}
			}
		}
		if (varMetalSpinning.CurveStartExtend > 0.001)
		{
			if (((CustomData)SortedEntities[0].EntityData).sortDirection != entitySortDirection.Normal)
			{
				point3D = buVector5.ToPoint3D(SortedEntities[0].Vertices[SortedEntities[0].Vertices.Length - 1]);
				point3D2 = buVector5.ToPoint3D(SortedEntities[0].Vertices[SortedEntities[0].Vertices.Length - 2]);
			}
			else
			{
				point3D = buVector5.ToPoint3D(SortedEntities[0].Vertices[0]);
				point3D2 = buVector5.ToPoint3D(SortedEntities[0].Vertices[1]);
			}
			double angle = clsInit.cVector5.PointAngle(point3D, point3D2, Plane.XY);
			Point3D EndPnt = new Point3D();
			clsInit.cVector5.LineWithLengthAndAngle(point3D, varMetalSpinning.CurveStartExtend, angle, ref EndPnt);
			SortedEntities.Insert(0, new Line(EndPnt, point3D));
		}
		if (varMetalSpinning.CurveEndExtend > 0.001)
		{
			if (((CustomData)SortedEntities[SortedEntities.Count - 1].EntityData).sortDirection != entitySortDirection.Normal)
			{
				point3D = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[1]);
				point3D2 = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[0]);
			}
			else
			{
				point3D = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[SortedEntities[SortedEntities.Count - 1].Vertices.Length - 2]);
				point3D2 = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[SortedEntities[SortedEntities.Count - 1].Vertices.Length - 1]);
			}
			double angle2 = clsInit.cVector5.PointAngle(point3D2, point3D, Plane.XY);
			Point3D EndPnt2 = new Point3D();
			clsInit.cVector5.LineWithLengthAndAngle(point3D2, varMetalSpinning.CurveEndExtend, angle2, ref EndPnt2);
			SortedEntities.Add(new Line(point3D2, EndPnt2));
		}
		TotalLength = 0.0;
		if (SortedEntities.Count > 0)
		{
			varSpinningRuntime.pntLeaveArcEnd = new Point3D();
			varSpinningRuntime.pntLeaveArcMid = new Point3D();
			if (((CustomData)SortedEntities[0].EntityData).sortDirection != entitySortDirection.Normal)
			{
				pntStart = buVector5.ToPoint3D(SortedEntities[0].Vertices[SortedEntities[0].Vertices.Length - 1]);
			}
			else
			{
				pntStart = buVector5.ToPoint3D(SortedEntities[0].Vertices[0]);
			}
			if (((CustomData)SortedEntities[SortedEntities.Count - 1].EntityData).sortDirection != entitySortDirection.Normal)
			{
				varSpinningRuntime.pntCurveEnd = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[0]);
			}
			else
			{
				varSpinningRuntime.pntCurveEnd = buVector5.ToPoint3D(SortedEntities[SortedEntities.Count - 1].Vertices[SortedEntities[SortedEntities.Count - 1].Vertices.Length - 1]);
			}
			varSpinningRuntime.pntCurveStart = buVector5.ToPoint3D(pntStart);
		}
		if (copiedEnt.Count > 0)
		{
			varSpinningRuntime.pntLeaveArcEnd = new Point3D();
			varSpinningRuntime.pntLeaveArcMid = new Point3D();
			if (((CustomData)copiedEnt[0].EntityData).sortDirection != entitySortDirection.Normal)
			{
				varSpinningRuntime.pntCurveFinishStart = buVector5.ToPoint3D(copiedEnt[0].Vertices[copiedEnt[0].Vertices.Length - 1]);
			}
			else
			{
				varSpinningRuntime.pntCurveFinishStart = buVector5.ToPoint3D(copiedEnt[0].Vertices[0]);
			}
			if (((CustomData)copiedEnt[copiedEnt.Count - 1].EntityData).sortDirection != entitySortDirection.Normal)
			{
				varSpinningRuntime.pntCurveFinishEnd = buVector5.ToPoint3D(copiedEnt[copiedEnt.Count - 1].Vertices[0]);
			}
			else
			{
				varSpinningRuntime.pntCurveFinishEnd = buVector5.ToPoint3D(copiedEnt[copiedEnt.Count - 1].Vertices[copiedEnt[SortedEntities.Count - 1].Vertices.Length - 1]);
			}
		}
		if (SortedEntities.Count > 0)
		{
			BaseFinishOffsetedEntities = new List<Entity>();
			BaseRoughtOffsetedEntities = new List<Entity>();
			if (copiedEnt.Count <= 0)
			{
				buVector5.CopyEntities(SortedEntities, ref BaseFinishOffsetedEntities);
			}
			else
			{
				buVector5.CopyEntities(copiedEnt, ref BaseFinishOffsetedEntities);
			}
			buVector5.CopyEntities(SortedEntities, ref BaseRoughtOffsetedEntities);
			for (int j = 0; j <= BaseRoughtOffsetedEntities.Count - 1; j++)
			{
				BaseRoughtOffsetedEntities[j].Regen(clsVar.varEntities.RegenDeviation);
			}
			for (int k = 0; k <= BaseFinishOffsetedEntities.Count - 1; k++)
			{
				BaseFinishOffsetedEntities[k].Regen(clsVar.varEntities.RegenDeviation);
			}
			frmSpin.PropertiesForm.TopMost = true;
			frmSpin.varSpinPattern = new SpinPattern(varMetalSpinning);
			frmSpin.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			frmSpin.Init();
			frmSpin.Show();
			SpinPatternCommand spinPatternCommand = new SpinPatternCommand();
			spinPatternCommand.ShowPattern = true;
			ShowPath(null, spinPatternCommand);
		}
	}

	public void doMaterialSurface()
	{
		Entity surfEntity = null;
		clsInit.appCommand.surfaceRevolveByPath(ref surfEntity);
		surfEntity.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[i].LayerPurposes == LayerPurpose.Model)
			{
				surfEntity.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[i].Name;
			}
		}
		clsInit.appCommand.AddEntity(surfEntity);
	}

	public void getEntitiesBetweenStartPointAndLength(Point3D pntStart, SpinPattern varPattern, List<Entity> baseEntities, bool CalcReturn, ref List<Entity> calcEntities, ref Point3D pntNewStart, ref Point3D pntReturn, ref double DirectionAngle)
	{
		pntNewStart = buVector5.ToPoint3D(pntStart);
		TotalLength = 0.0;
		bool flag = false;
		for (int i = 0; i <= baseEntities.Count - 1; i++)
		{
			ICurve curve = (ICurve)baseEntities[i];
			curve.ClosestPointTo(pntNewStart, out var t);
			if (!(clsInit.cVector5.isPointInsideEntity(curve, pntNewStart, 0.01) & (t >= curve.Domain.t0) & (t <= curve.Domain.t1)))
			{
				if (flag)
				{
					TotalLength += curve.Length();
				}
				continue;
			}
			flag = true;
			double num = curve.Domain.t1 - curve.Domain.t0;
			double num2 = curve.Length();
			double num3 = num / num2;
			double num4 = varPattern.StepCatchLength - TotalLength;
			Point3D point3D = new Point3D();
			ICurve sub = null;
			double num5;
			double num6;
			if (((CustomData)baseEntities[i].EntityData).sortDirection != entitySortDirection.Normal)
			{
				num5 = t - num4 * num3;
				num6 = t - (num4 - varPattern.StepReturnLength) * num3;
				if (num5 < curve.Domain.t0)
				{
					num5 = curve.Domain.t0;
				}
				if (num6 < curve.Domain.t0)
				{
					num6 = curve.Domain.t0;
				}
				if (num6 > curve.Domain.t1)
				{
					num6 = curve.Domain.t1;
				}
				if (!(t - num5 > 0.001))
				{
					continue;
				}
				Point3D point3D2 = new Point3D();
				curve.SubCurve(num5, t, out sub);
				double num7 = sub.Length();
				point3D = buVector5.ToPoint3D(curve.PointAt(num5));
				point3D2 = buVector5.ToPoint3D(curve.PointAt(num5 + 0.1));
				DirectionAngle = clsInit.cVector5.PointAngle(point3D, point3D2, Plane.XY);
				Entity entity = (Entity)sub;
				entity.Regen(new RegenParams(0.0001));
				calcEntities.Add(entity);
				pntNewStart = buVector5.ToPoint3D(point3D);
				pntReturn = buVector5.ToPoint3D(curve.PointAt(num6));
				if (buCompare5.EQ(pntNewStart, pntReturn))
				{
					pntReturn = buVector5.ToPoint3D(pntNewStart);
				}
				double num8 = (t - num5) / num3;
				if (!(buCompare5.EQ(num8 + TotalLength, varPattern.StepCatchLength, 0.01) | (num8 + TotalLength > varPattern.StepCatchLength)))
				{
					TotalLength += num7;
					continue;
				}
				if (!CalcReturn)
				{
					SpinPattern spinPattern = new SpinPattern(varPattern);
					spinPattern.StepCatchLength = varPattern.StepCatchLength - varPattern.StepReturnLength;
					List<Entity> calcEntities2 = new List<Entity>();
					Point3D pntNewStart2 = new Point3D();
					Point3D pntReturn2 = new Point3D();
					double DirectionAngle2 = 0.0;
					getEntitiesBetweenStartPointAndLength(pntStart, spinPattern, baseEntities, CalcReturn: true, ref calcEntities2, ref pntNewStart2, ref pntReturn2, ref DirectionAngle2);
					pntReturn = buVector5.ToPoint3D(pntNewStart2);
				}
				break;
			}
			num5 = t + num4 * num3;
			num6 = t + (num4 - varPattern.StepReturnLength) * num3;
			if (num5 > curve.Domain.t1)
			{
				num5 = curve.Domain.t1;
			}
			if (num6 > curve.Domain.t1)
			{
				num6 = curve.Domain.t1;
			}
			if (num6 < curve.Domain.t0)
			{
				num6 = curve.Domain.t0;
			}
			if (!(num5 - t > 0.001))
			{
				continue;
			}
			Point3D point3D3 = new Point3D();
			curve.SubCurve(t, num5, out sub);
			double num9 = sub.Length();
			point3D = buVector5.ToPoint3D(curve.PointAt(num5));
			point3D3 = buVector5.ToPoint3D(curve.PointAt(num5 - 0.1));
			DirectionAngle = clsInit.cVector5.PointAngle(point3D, point3D3, Plane.XY);
			Entity entity2 = (Entity)sub;
			entity2.Regen(0.001);
			calcEntities.Add(entity2);
			pntNewStart = buVector5.ToPoint3D(point3D);
			pntReturn = buVector5.ToPoint3D(curve.PointAt(num6));
			if (buCompare5.EQ(pntNewStart, pntReturn))
			{
				pntReturn = buVector5.ToPoint3D(pntNewStart);
			}
			double num10 = (num5 - t) / num3;
			if (!(buCompare5.EQ(num10 + TotalLength, varPattern.StepCatchLength, 0.01) | (num10 + TotalLength > varPattern.StepCatchLength)))
			{
				TotalLength += num9;
				continue;
			}
			if (!CalcReturn)
			{
				SpinPattern spinPattern2 = new SpinPattern(varPattern);
				spinPattern2.StepCatchLength = varPattern.StepCatchLength - varPattern.StepReturnLength;
				List<Entity> calcEntities3 = new List<Entity>();
				Point3D pntNewStart3 = new Point3D();
				Point3D pntReturn3 = new Point3D();
				double DirectionAngle3 = 0.0;
				getEntitiesBetweenStartPointAndLength(pntStart, spinPattern2, baseEntities, CalcReturn: true, ref calcEntities3, ref pntNewStart3, ref pntReturn3, ref DirectionAngle3);
				pntReturn = buVector5.ToPoint3D(pntNewStart3);
			}
			break;
		}
	}

	public void getEntitiesBetweenStartPointAndEndPoint(Point3D pntStart, Point3D pntEnd, SpinPattern varPattern, List<Entity> baseEntities, ref List<Entity> calcEntities)
	{
		Point3D point = buVector5.ToPoint3D(pntStart);
		TotalLength = 0.0;
		bool flag = false;
		int num = 0;
		ICurve curve;
		while (true)
		{
			if (num <= baseEntities.Count - 1)
			{
				curve = (ICurve)baseEntities[num];
				curve.ClosestPointTo(point, out var _);
				if (clsInit.cVector5.isPointInsideEntity(curve, pntStart, 0.01) & clsInit.cVector5.isPointInsideEntity(curve, pntEnd, 0.01))
				{
					break;
				}
				if (flag)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(baseEntities[num], ref copiedEnt);
					calcEntities.Add(copiedEnt);
				}
				num++;
				continue;
			}
			return;
		}
		flag = true;
		if (((CustomData)baseEntities[num].EntityData).sortDirection != entitySortDirection.Normal)
		{
			ICurve sub = null;
			curve.SubCurve(pntEnd, pntStart, out sub);
			Entity entity = (Entity)sub;
			entity.EntityData = new CustomData();
			entity.Regen(new RegenParams(0.0001));
			calcEntities.Add(entity);
		}
		else
		{
			ICurve sub2 = null;
			curve.SubCurve(pntStart, pntEnd, out sub2);
			Entity entity2 = (Entity)sub2;
			entity2.Regen(new RegenParams(0.0001));
			calcEntities.Add(entity2);
		}
	}

	public void CreateLeave(Entity LastEntity, Point3D pntStart, Point3D pntEnd, SpinPattern varPattern, ref List<Entity> calcEnt)
	{
		try
		{
			calcEnt.Clear();
			double num = pntEnd.X - varSpinningRuntime.pntLeaveArcEnd.X + varPattern.LeaveOffsetX;
			double num2 = pntEnd.X - varSpinningRuntime.pntLeaveArcMid.X + varPattern.LeaveOffsetX;
			num = 0.0;
			num2 = 0.0;
			if (varSpinningRuntime.isLastSpin)
			{
				Line item = new Line(pntEnd, new Point3D(pntEnd.X, pntEnd.Y + varPattern.LeaveHeight));
				calcEnt.Add(item);
				varSpinningRuntime.pntLastCalc = new Point3D(pntEnd.X, pntEnd.Y + varPattern.LeaveHeight);
				return;
			}
			CustomData customData;
			if (varMetalSpinning.ReturnSameWay)
			{
				if (!varPattern.isLeaveArc)
				{
					Line line = new Line(varSpinningRuntime.pntLeaveArcEnd, pntStart);
					line.Regen(new RegenParams(0.001));
					customData = new CustomData();
					customData.CamFeedrate = varMetalSpinning.CamFeed;
					line.EntityData = customData;
					calcEnt.Add(line);
					Line line2 = new Line(varSpinningRuntime.pntSameWayReturn, varSpinningRuntime.pntLeaveArcEnd);
					line2.Regen(new RegenParams(0.001));
					customData = new CustomData();
					customData.CamFeedrate = varMetalSpinning.CamFeed;
					line2.EntityData = customData;
					calcEnt.Add(line2);
					for (int i = 0; i <= calcEntReturn.Count - 1; i++)
					{
						Entity entity = buVector5.CopyEntities(calcEntReturn[i]);
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamFeed;
						entity.EntityData = customData;
						calcEnt.Add(entity);
					}
					varSpinningRuntime.pntLastCalc = new Point3D(varSpinningRuntime.pntSameWayReturn.X, varSpinningRuntime.pntSameWayReturn.Y, varSpinningRuntime.pntSameWayReturn.Z);
					return;
				}
				Point3D third = new Point3D(varSpinningRuntime.pntLeaveArcEnd.X + num / 2.0, varSpinningRuntime.pntLeaveArcEnd.Y, varSpinningRuntime.pntLeaveArcEnd.Z);
				Point3D second = new Point3D(varSpinningRuntime.pntLeaveArcMid.X + num2 / 2.0, varSpinningRuntime.pntLeaveArcMid.Y, varSpinningRuntime.pntLeaveArcMid.Z);
				Arc arc = new Arc(Plane.XY, pntStart, second, third, flip: true);
				arc.Regen(new RegenParams(0.001));
				customData = new CustomData();
				customData.CamFeedrate = varMetalSpinning.CamFeed;
				arc.EntityData = customData;
				calcEnt.Add(arc);
				double num3 = varMetalSpinning.ReturnSameWayOffset / 2.0;
				if (!varMetalSpinning.ReturnSameWayExtraMoveForArc)
				{
					num3 = 0.0;
				}
				second = new Point3D(varSpinningRuntime.pntLeaveArcMid.X + num2 / 2.0 - num3, varSpinningRuntime.pntLeaveArcMid.Y, varSpinningRuntime.pntLeaveArcMid.Z);
				Arc arc2 = new Arc(Plane.XY, varSpinningRuntime.pntSameWayReturn, second, third, flip: true);
				arc2.Regen(new RegenParams(0.001));
				customData = new CustomData();
				customData.CamFeedrate = varMetalSpinning.CamFeed;
				arc2.EntityData = customData;
				calcEnt.Add(arc2);
				for (int j = 0; j <= calcEntReturn.Count - 1; j++)
				{
					Entity entity2 = buVector5.CopyEntities(calcEntReturn[j]);
					customData = new CustomData();
					customData.CamFeedrate = varMetalSpinning.CamFeed;
					entity2.EntityData = customData;
					calcEnt.Add(entity2);
				}
				varSpinningRuntime.pntLastCalc = new Point3D(varSpinningRuntime.pntSameWayReturn.X, varSpinningRuntime.pntSameWayReturn.Y, varSpinningRuntime.pntSameWayReturn.Z);
				return;
			}
			if (!varPattern.isLeaveArc)
			{
				Line line3 = new Line(pntStart, varSpinningRuntime.pntLeaveArcEnd);
				line3.Regen(new RegenParams(0.001));
				customData = new CustomData();
				customData.CamFeedrate = varMetalSpinning.CamFeed;
				line3.EntityData = customData;
				calcEnt.Add(line3);
			}
			else
			{
				Point3D third2 = new Point3D(varSpinningRuntime.pntLeaveArcEnd.X + num / 2.0, varSpinningRuntime.pntLeaveArcEnd.Y, varSpinningRuntime.pntLeaveArcEnd.Z);
				Point3D second2 = new Point3D(varSpinningRuntime.pntLeaveArcMid.X + num2 / 2.0, varSpinningRuntime.pntLeaveArcMid.Y, varSpinningRuntime.pntLeaveArcMid.Z);
				Arc arc3 = new Arc(Plane.XY, pntStart, second2, third2, flip: true);
				arc3.Regen(new RegenParams(0.001));
				customData = new CustomData();
				customData.CamFeedrate = varMetalSpinning.CamFeed;
				arc3.EntityData = customData;
				calcEnt.Add(arc3);
			}
			Point3D point3D = new Point3D(pntEnd.X, varSpinningRuntime.pntLeaveArcEnd.Y, 0.0);
			Line line4 = new Line(varSpinningRuntime.pntLeaveArcEnd, point3D);
			line4.Regen(new RegenParams(0.001));
			customData = new CustomData();
			customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
			line4.EntityData = customData;
			calcEnt.Add(line4);
			if (varPattern.isArcCorner)
			{
				ICurve curve = (ICurve)calcEnt[0].Clone();
				ICurve curve2 = (ICurve)calcEnt[1].Clone();
				CustomData entityData = new CustomData((CustomData)calcEnt[0].EntityData);
				CustomData entityData2 = new CustomData((CustomData)calcEnt[1].EntityData);
				Arc fillet = null;
				if (Curve.Fillet(curve, curve2, varPattern.LeaveArcCornerRadius, flip1: false, flip2: false, trim1: true, trim2: true, out fillet))
				{
					calcEnt[0] = buVector5.CopyEntities((Entity)curve);
					calcEnt[1] = buVector5.CopyEntities((Entity)curve2);
					calcEnt[0].EntityData = entityData;
					calcEnt[1].EntityData = entityData2;
					fillet.Regen(0.001);
					if (fillet != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet.EntityData = customData;
						calcEnt.Insert(1, fillet);
					}
				}
				if (Curve.Fillet(curve, curve2, varPattern.LeaveArcCornerRadius, flip1: true, flip2: false, trim1: true, trim2: true, out fillet))
				{
					calcEnt[0] = buVector5.CopyEntities((Entity)curve);
					calcEnt[1] = buVector5.CopyEntities((Entity)curve2);
					calcEnt[0].EntityData = entityData;
					calcEnt[1].EntityData = entityData2;
					fillet.Regen(0.001);
					if (fillet != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet.EntityData = customData;
						calcEnt.Insert(1, fillet);
					}
				}
				if (Curve.Fillet(curve, curve2, varPattern.LeaveArcCornerRadius, flip1: false, flip2: true, trim1: true, trim2: true, out fillet))
				{
					calcEnt[0] = buVector5.CopyEntities((Entity)curve);
					calcEnt[1] = buVector5.CopyEntities((Entity)curve2);
					calcEnt[0].EntityData = entityData;
					calcEnt[1].EntityData = entityData2;
					fillet.Regen(0.001);
					if (fillet != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet.EntityData = customData;
						calcEnt.Insert(1, fillet);
					}
				}
				if (Curve.Fillet(curve, curve2, varPattern.LeaveArcCornerRadius, flip1: true, flip2: true, trim1: true, trim2: true, out fillet))
				{
					calcEnt[0] = buVector5.CopyEntities((Entity)curve);
					calcEnt[1] = buVector5.CopyEntities((Entity)curve2);
					calcEnt[0].EntityData = entityData;
					calcEnt[1].EntityData = entityData2;
					fillet.Regen(0.001);
					if (fillet != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet.EntityData = customData;
						calcEnt.Insert(1, fillet);
					}
				}
			}
			Line line5 = new Line(point3D, new Point3D(pntEnd.X, pntEnd.Y + varMetalSpinning.SafeDistance));
			line5.Regen(new RegenParams(0.001));
			customData = new CustomData();
			customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
			line5.EntityData = customData;
			calcEnt.Add(line5);
			if (varPattern.isArcCorner)
			{
				ICurve curve3 = (ICurve)calcEnt[calcEnt.Count - 2].Clone();
				ICurve curve4 = (ICurve)calcEnt[calcEnt.Count - 1].Clone();
				CustomData entityData3 = new CustomData((CustomData)calcEnt[calcEnt.Count - 2].EntityData);
				CustomData entityData4 = new CustomData((CustomData)calcEnt[calcEnt.Count - 1].EntityData);
				Arc fillet2 = null;
				if (Curve.Fillet(curve3, curve4, 5.0, flip1: false, flip2: false, trim1: true, trim2: true, out fillet2))
				{
					calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity)curve3);
					calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity)curve4);
					calcEnt[calcEnt.Count - 2].EntityData = entityData3;
					calcEnt[calcEnt.Count - 1].EntityData = entityData4;
					fillet2.Regen(0.001);
					if (fillet2 != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet2.EntityData = customData;
						calcEnt.Insert(calcEnt.Count - 1, fillet2);
					}
				}
				if (Curve.Fillet(curve3, curve4, 5.0, flip1: true, flip2: false, trim1: true, trim2: true, out fillet2))
				{
					calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity)curve3);
					calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity)curve4);
					fillet2.Regen(0.001);
					calcEnt[calcEnt.Count - 2].EntityData = entityData3;
					calcEnt[calcEnt.Count - 1].EntityData = entityData4;
					if (fillet2 != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet2.EntityData = customData;
						calcEnt.Insert(calcEnt.Count - 1, fillet2);
					}
				}
				if (Curve.Fillet(curve3, curve4, 5.0, flip1: false, flip2: true, trim1: true, trim2: true, out fillet2))
				{
					calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity)curve3);
					calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity)curve4);
					calcEnt[calcEnt.Count - 2].EntityData = entityData3;
					calcEnt[calcEnt.Count - 1].EntityData = entityData4;
					fillet2.Regen(0.001);
					if (fillet2 != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet2.EntityData = customData;
						calcEnt.Insert(calcEnt.Count - 1, fillet2);
					}
				}
				if (Curve.Fillet(curve3, curve4, 5.0, flip1: true, flip2: true, trim1: true, trim2: true, out fillet2))
				{
					calcEnt[calcEnt.Count - 2] = buVector5.CopyEntities((Entity)curve3);
					calcEnt[calcEnt.Count - 1] = buVector5.CopyEntities((Entity)curve4);
					fillet2.Regen(0.001);
					calcEnt[calcEnt.Count - 2].EntityData = entityData3;
					calcEnt[calcEnt.Count - 1].EntityData = entityData4;
					if (fillet2 != null)
					{
						customData = new CustomData();
						customData.CamFeedrate = varMetalSpinning.CamLeaveFeed;
						fillet2.EntityData = customData;
						calcEnt.Insert(calcEnt.Count - 1, fillet2);
					}
				}
			}
			Line line6 = new Line(new Point3D(pntEnd.X, pntEnd.Y + varMetalSpinning.SafeDistance), pntEnd);
			line6.Regen(new RegenParams(0.001));
			customData = new CustomData();
			customData.CamFeedrate = varMetalSpinning.CamFeed;
			line6.EntityData = customData;
			calcEnt.Add(line6);
			varSpinningRuntime.pntLastCalc = new Point3D(pntEnd.X, pntEnd.Y, pntEnd.Z);
		}
		catch (Exception)
		{
		}
	}

	public void CalculateLeaveAngle(Point3D lastPoint, SpinPattern varPattern, List<Entity> baseEntities, ref Point3D midPoint, ref Point3D endPoint)
	{
		double num = (varSpinningRuntime.DirectionAngle - 90.0) * varPattern.LeaveDeltaAngleRatio;
		double num2 = varSpinningRuntime.DirectionAngle - num;
		num2 += varPattern.LeaveOffsetAngle;
		if (num2 > varPattern.LeaveMaxAngle)
		{
			num2 = varPattern.LeaveMaxAngle;
		}
		if (num2 < varPattern.LeaveMinAngle)
		{
			num2 = varPattern.LeaveMinAngle;
		}
		double num3 = Math.Tan(buConversion5.DegreeToRadian(num2 - 90.0)) * varPattern.LeaveHeight;
		double num4 = Math.Tan(buConversion5.DegreeToRadian(num2 - 90.0)) * (varPattern.LeaveHeight / 2.0);
		double y = lastPoint.Y + varPattern.LeaveHeight;
		double num5 = lastPoint.Y + varPattern.LeaveHeight / 2.0;
		bool flag = false;
		midPoint = new Point3D();
		endPoint = new Point3D();
		for (int i = 0; i <= baseEntities.Count - 1; i++)
		{
			ICurve curve = (ICurve)baseEntities[i];
			if (baseEntities[i].BoxMax == null)
			{
				baseEntities[i].Regen(0.0001);
			}
			if ((num5 >= baseEntities[i].BoxMin.Y) & (num5 <= baseEntities[i].BoxMax.Y))
			{
				Line c = new Line(new Point3D(-100000.0, num5), new Point3D(100000.0, num5));
				Point3D[] array = curve.IntersectWith(c);
				if (array != null && array.Length != 0)
				{
					midPoint = buVector5.ToPoint3D(array[0]);
					flag = true;
				}
			}
		}
		endPoint = new Point3D(lastPoint.X - num3 + varPattern.LeaveOffsetX, y);
		midPoint = new Point3D(lastPoint.X - varPattern.LeaveArcRadiusRatioFromHeight * varPattern.LeaveHeight - num4 + varPattern.LeaveOffsetX * 0.5, num5);
		if (!flag)
		{
		}
		varSpinningRuntime.isLastSpin = false;
		if (varSpinningRuntime.isFinish)
		{
			if (lastPoint == varSpinningRuntime.pntCurveFinishEnd)
			{
				varSpinningRuntime.isLastSpin = true;
			}
		}
		else if (lastPoint == varSpinningRuntime.pntCurveEnd)
		{
			varSpinningRuntime.isLastSpin = true;
		}
	}

	public void ShowPath(object sender, object Data)
	{
		try
		{
			SpinPatternCommand spinPatternCommand = (SpinPatternCommand)Data;
			Point3D pntNewStart = new Point3D();
			Point3D pntReturn = new Point3D();
			List<Entity> list = new List<Entity>();
			if (!(spinPatternCommand.OK & (CalculatedEntitiesList != null)))
			{
				if (!spinPatternCommand.Cancel)
				{
					if (!(spinPatternCommand.Finish & (CalculatedEntitiesList != null)))
					{
						if (!(spinPatternCommand.SimStart & (tempCalcEntitities != null) & (BaseRoughtOffsetedEntities != null)))
						{
							if (!(spinPatternCommand.SimStop & (BaseRoughtOffsetedEntities != null)))
							{
								if (!(spinPatternCommand.Undo & (BaseRoughtOffsetedEntities != null)))
								{
									ccVars.pntDrawDynamicLinesArrColored.Clear();
									varMetalSpinning = new SpinPattern(frmSpin.varSpinPattern);
									if (!((spinPatternCommand.ShowPattern | spinPatternCommand.NextPattern) & (BaseRoughtOffsetedEntities != null)))
									{
										return;
									}
									double curveOffset = varMetalSpinning.CurveOffset;
									Point3D point3D = new Point3D();
									point3D = buVector5.ToPoint3D(pntStart);
									tempCalcEntitities = new List<List<Entity>>();
									if (varSpinningRuntime.isFinish)
									{
										curveOffset = 0.0;
									}
									curveOffset = 0.0;
									for (int i = 0; i <= varMetalSpinning.RepeatCount - 1; i++)
									{
										calcEnt = new List<Entity>();
										calcEntReturn = new List<Entity>();
										if (varSpinningRuntime.isFinish)
										{
											getEntitiesBetweenStartPointAndLength(point3D, varMetalSpinning, BaseFinishOffsetedEntities, CalcReturn: false, ref calcEnt, ref pntNewStart, ref pntReturn, ref varSpinningRuntime.DirectionAngle);
										}
										else
										{
											clsInit.cVector5.getPointAtEntitiesBetweenStartPointAndLength(point3D, varMetalSpinning.StepCatchLength + varMetalSpinning.ReturnSameWayOffset, 0.01, BaseRoughtOffsetedEntities, ref varSpinningRuntime.pntSameWayReturn);
											getEntitiesBetweenStartPointAndLength(point3D, varMetalSpinning, BaseRoughtOffsetedEntities, CalcReturn: false, ref calcEnt, ref pntNewStart, ref pntReturn, ref varSpinningRuntime.DirectionAngle);
											getEntitiesBetweenStartPointAndEndPoint(pntReturn, varSpinningRuntime.pntSameWayReturn, varMetalSpinning, BaseRoughtOffsetedEntities, ref calcEntReturn);
										}
										new Point3D();
										new Point3D();
										SpinPattern spinPattern = new SpinPattern(varMetalSpinning);
										if (!((varSpinningRuntime.DirectionAngle >= 90.0) & (varSpinningRuntime.DirectionAngle < 100.0)))
										{
											if (!((varSpinningRuntime.DirectionAngle >= 100.0) & (varSpinningRuntime.DirectionAngle < 110.0)))
											{
												if (!((varSpinningRuntime.DirectionAngle >= 110.0) & (varSpinningRuntime.DirectionAngle < 120.0)))
												{
													if (!((varSpinningRuntime.DirectionAngle >= 120.0) & (varSpinningRuntime.DirectionAngle < 130.0)))
													{
														if (!((varSpinningRuntime.DirectionAngle >= 130.0) & (varSpinningRuntime.DirectionAngle < 150.0)))
														{
															if ((varSpinningRuntime.DirectionAngle >= 150.0) & (varSpinningRuntime.DirectionAngle < 180.0))
															{
																spinPattern.LeaveArcRadiusRatioFromHeight = varMetalSpinning.LeaveArcRadiusRatioFromHeight150To180;
															}
														}
														else
														{
															spinPattern.LeaveArcRadiusRatioFromHeight = varMetalSpinning.LeaveArcRadiusRatioFromHeight130To150;
														}
													}
													else
													{
														spinPattern.LeaveArcRadiusRatioFromHeight = varMetalSpinning.LeaveArcRadiusRatioFromHeight120To130;
													}
												}
												else
												{
													spinPattern.LeaveArcRadiusRatioFromHeight = varMetalSpinning.LeaveArcRadiusRatioFromHeight110To120;
												}
											}
											else
											{
												spinPattern.LeaveArcRadiusRatioFromHeight = varMetalSpinning.LeaveArcRadiusRatioFromHeight100To110;
											}
										}
										else
										{
											spinPattern.LeaveArcRadiusRatioFromHeight = varMetalSpinning.LeaveArcRadiusRatioFromHeight90To100;
										}
										spinPattern.LeaveArcRadiusRatioFromHeight *= varMetalSpinning.LeaveArcRadiusRatioFromHeight;
										CalculateLeaveAngle(pntNewStart, spinPattern, BaseRoughtOffsetedEntities, ref varSpinningRuntime.pntLeaveArcMid, ref varSpinningRuntime.pntLeaveArcEnd);
										if (calcEnt.Count > 0)
										{
											for (int j = 0; j <= calcEnt.Count - 1; j++)
											{
												if (calcEnt[j].EntityData != null)
												{
													((CustomData)calcEnt[j].EntityData).CamFeedrate = varMetalSpinning.CamFeed;
													continue;
												}
												CustomData customData = new CustomData();
												customData.CamFeedrate = varMetalSpinning.CamFeed;
												calcEnt[j].EntityData = customData;
											}
											CreateLeave(calcEnt[calcEnt.Count - 1], pntNewStart, pntReturn, spinPattern, ref list);
											for (int k = 0; k <= list.Count - 1; k++)
											{
												calcEnt.Add(list[k]);
											}
											if (!varMetalSpinning.HidePrevious)
											{
												for (int l = 0; l <= CalculatedEntitiesList.Count - 1; l++)
												{
													for (int m = 0; m <= CalculatedEntitiesList[l].CalculatedEntities.Count - 1; m++)
													{
														List<PointRGB> PointList = new List<PointRGB>();
														buVector5.VerticeToPointsList(CalculatedEntitiesList[l].CalculatedEntities[m].Vertices, ref PointList, Color.Blue);
														clsInit.cVector5.AddValueToPointList(0.0, curveOffset, 0.0, ref PointList);
														ccVars.pntDrawDynamicLinesArrColored.Add(PointList);
													}
												}
											}
											if (calcEnt.Count > 0)
											{
												for (int n = 0; n <= calcEnt.Count - 1; n++)
												{
													List<PointRGB> PointList2 = new List<PointRGB>();
													buVector5.VerticeToPointsList(calcEnt[n].Vertices, ref PointList2, Color.Red);
													clsInit.cVector5.AddValueToPointList(0.0, curveOffset, 0.0, ref PointList2);
													ccVars.pntDrawDynamicLinesArrColored.Add(PointList2);
												}
											}
											tempCalcEntitities.Add(calcEnt);
										}
										ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
										point3D = buVector5.ToPoint3D(pntReturn);
										if (!spinPatternCommand.NextPattern)
										{
											continue;
										}
										pntLastCalc = buVector5.ToPoint3D(varSpinningRuntime.pntLastCalc);
										SpinCalculatedData spinCalculatedData = new SpinCalculatedData();
										spinCalculatedData.StartPoint = buVector5.ToPoint3D(pntStart);
										spinCalculatedData.YOffset = curveOffset;
										spinCalculatedData.ReturnSameWay = varMetalSpinning.ReturnSameWay;
										spinCalculatedData.isFinished = varSpinningRuntime.isFinish;
										buVector5.CopyEntities(calcEnt, ref spinCalculatedData.CalculatedEntities);
										CalculatedEntitiesList.Add(spinCalculatedData);
										pntStart = buVector5.ToPoint3D(pntReturn);
										if (varSpinningRuntime.isLastSpin)
										{
											if (!varSpinningRuntime.isFinish)
											{
												SpinPatternCommand spinPatternCommand2 = new SpinPatternCommand();
												spinPatternCommand2.OK = true;
												ShowPath(null, spinPatternCommand2);
											}
										}
										else
										{
											SpinPatternCommand spinPatternCommand3 = new SpinPatternCommand();
											spinPatternCommand3.ShowPattern = true;
											ShowPath(null, spinPatternCommand3);
										}
									}
									Point3D MaxPoint = new Point3D();
									Point3D MinPoint = new Point3D();
									Point3D MidPoint = new Point3D();
									clsInit.cVector5.BoxSizeCalculate(ccVars.pntDrawDynamicLinesArrColored, ref MinPoint, ref MidPoint, ref MaxPoint);
									ccVars.pntDrawDynamicMeasure.Clear();
									MeasureData measureData = new MeasureData();
									measureData.Color = Color.Red;
									measureData.Points.Add(new Point3D(MinPoint.X, MaxPoint.Y + 10.0, 0.0));
									measureData.Points.Add(new Point3D(MaxPoint.X, MaxPoint.Y + 10.0, 0.0));
									measureData.PntText = new Point3D(MidPoint.X, MaxPoint.Y + 20.0, 0.0);
									measureData.Text = (MaxPoint.X - MinPoint.X).ToString("f1") + " mm";
									ccVars.pntDrawDynamicMeasure.Add(measureData);
									measureData = new MeasureData();
									measureData.Color = Color.Green;
									measureData.Points.Add(new Point3D(MinPoint.X - 10.0, MaxPoint.Y, 0.0));
									measureData.Points.Add(new Point3D(MinPoint.X - 10.0, 0.0, 0.0));
									measureData.PntText = new Point3D(MinPoint.X - 20.0, MaxPoint.Y / 2.0, 0.0);
									measureData.Text = (MaxPoint.Y - 0.0).ToString("f1") + " mm";
									ccVars.pntDrawDynamicMeasure.Add(measureData);
								}
								else if (CalculatedEntitiesList != null && CalculatedEntitiesList.Count > 0)
								{
									pntStart = buVector5.ToPoint3D(CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].StartPoint);
									CalculatedEntitiesList.RemoveAt(CalculatedEntitiesList.Count - 1);
									SpinPatternCommand spinPatternCommand4 = new SpinPatternCommand();
									spinPatternCommand4.ShowPattern = true;
									ShowPath(null, spinPatternCommand4);
								}
							}
							else
							{
								ccVars.Pages[ccVars.PageIndex].Cams.Clear();
								clsInit.appCommand.simStop();
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.Top);
							}
							return;
						}
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(viewType.Top);
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.SetView(new Vector3D(0.0, -0.1, 0.999), fit: false);
						ccVars.Pages[ccVars.PageIndex].Cams.Clear();
						List<Entity> BaseRefEntities = new List<Entity>();
						if (!varMetalSpinning.HidePrevious)
						{
							for (int num = 0; num <= CalculatedEntitiesList.Count - 1; num++)
							{
								for (int num2 = 0; num2 <= CalculatedEntitiesList[num].CalculatedEntities.Count - 1; num2++)
								{
									Entity copiedEnt = null;
									buVector5.CopyEntities(CalculatedEntitiesList[num].CalculatedEntities[num2], ref copiedEnt);
									BaseRefEntities.Add(copiedEnt);
								}
							}
						}
						for (int num3 = 0; num3 <= tempCalcEntitities.Count - 1; num3++)
						{
							for (int num4 = 0; num4 <= tempCalcEntitities[num3].Count - 1; num4++)
							{
								Entity copiedEnt2 = null;
								buVector5.CopyEntities(tempCalcEntitities[num3][num4], ref copiedEnt2);
								BaseRefEntities.Add(copiedEnt2);
							}
						}
						camTp CamCalculated = new camTp();
						SortSettings settings = new SortSettings();
						List<Entity> SortedEntities = new List<Entity>();
						SortResult Result = new SortResult();
						clsInit.cVector5.SortEntitiesByRefPoint(varSpinningRuntime.pntCurveStart, ref BaseRefEntities, settings, ref SortedEntities, ref Result);
						camParameters5 camParameters6 = new camParameters5();
						camParameters6.Distances.Safe = 0.0;
						camParameters6.Distances.Rapid = 0.0;
						camParameters6.Options.FeedFromEntityFeedrate = true;
						clsInit.cCam5.camContourCenter(SortedEntities, TangentCalculaton: false, ccVars.toolActive, camParameters6, ref CamCalculated);
						ccVars.Pages[ccVars.PageIndex].Cams.Add(CamCalculated);
						clsInit.appCommand.simStart();
						return;
					}
					varSpinningRuntime.isFinish = true;
					if (CalculatedEntitiesList.Count > 0)
					{
						if (!CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].ReturnSameWay)
						{
							CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.RemoveAt(CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1);
							CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.RemoveAt(CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1);
							if (CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities[CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1] is Arc)
							{
								CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.RemoveAt(CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1);
							}
						}
						Point3D point3D2 = new Point3D();
						Entity entity = CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities[CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.Count - 1];
						point3D2 = ((((CustomData)entity.EntityData).sortDirection == entitySortDirection.Normal) ? buVector5.ToPoint3D(entity.Vertices[entity.Vertices.Length - 1]) : buVector5.ToPoint3D(entity.Vertices[0]));
						Line line = new Line(point3D2, new Point3D(varSpinningRuntime.pntCurveFinishStart.X, point3D2.Y, point3D2.Z));
						line.EntityData = new CustomData();
						CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.Add(line);
						line = new Line(new Point3D(varSpinningRuntime.pntCurveFinishStart.X, point3D2.Y, point3D2.Z), new Point3D(varSpinningRuntime.pntCurveFinishStart.X, varSpinningRuntime.pntCurveFinishStart.Y - 0.0, varSpinningRuntime.pntCurveFinishStart.Z));
						CustomData customData2 = new CustomData();
						customData2.Tags = "finishconnect";
						line.EntityData = customData2;
						CalculatedEntitiesList[CalculatedEntitiesList.Count - 1].CalculatedEntities.Add(line);
						SpinPatternCommand spinPatternCommand5 = new SpinPatternCommand();
						spinPatternCommand5.NextPattern = true;
						pntStart = buVector5.ToPoint3D(varSpinningRuntime.pntCurveFinishStart);
						double stepCatchLength = frmSpin.varSpinPattern.StepCatchLength;
						frmSpin.varSpinPattern.StepCatchLength = 10000.0;
						varMetalSpinning.StepCatchLength = 100000.0;
						ShowPath(null, spinPatternCommand5);
						frmSpin.varSpinPattern.StepCatchLength = stepCatchLength;
						varMetalSpinning.StepCatchLength = stepCatchLength;
						spinPatternCommand5 = new SpinPatternCommand();
						spinPatternCommand5.OK = true;
						ShowPath(null, spinPatternCommand5);
					}
					varSpinningRuntime.isFinish = false;
				}
				else
				{
					clsInit.appCommand.Reset();
				}
			}
			else
			{
				if (CalculatedEntitiesList.Count == 0)
				{
					return;
				}
				clsInit.appCommand.undoBuffer();
				clsInit.appCommand.cmdCamRemoveAll(DontAskQuestion: true);
				if (!varSpinningRuntime.isFinish)
				{
					Line line2 = new Line(pntLastCalc, new Point3D(pntLastCalc.X, pntLastCalc.Y + varMetalSpinning.LeaveHeight, pntLastCalc.Z));
					CustomData customData3 = new CustomData();
					customData3.CamFeedrate = varMetalSpinning.CamLeaveFeed;
					line2.EntityData = customData3;
					SpinCalculatedData spinCalculatedData2 = new SpinCalculatedData();
					spinCalculatedData2.StartPoint = buVector5.ToPoint3D(pntLastCalc);
					spinCalculatedData2.isFinished = varSpinningRuntime.isFinish;
					spinCalculatedData2.CalculatedEntities.Add(line2);
					spinCalculatedData2.isMoveSafe = true;
					CalculatedEntitiesList.Add(spinCalculatedData2);
				}
				ccVars.Pages[ccVars.PageIndex].Cams.Clear();
				List<Entity> BaseRefEntities2 = new List<Entity>();
				tempCalcEntitities.Clear();
				for (int num5 = 0; num5 <= CalculatedEntitiesList.Count - 1; num5++)
				{
					List<Entity> copiedEnt3 = new List<Entity>();
					buVector5.CopyEntities(CalculatedEntitiesList[num5].CalculatedEntities, ref copiedEnt3);
					for (int num6 = 0; num6 <= copiedEnt3.Count - 1; num6++)
					{
						copiedEnt3[num6].Translate(0.0, CalculatedEntitiesList[num5].YOffset);
						copiedEnt3[num6].Regen(new RegenParams(clsVar.varEntities.RegenDeviation));
					}
					tempCalcEntitities.Add(copiedEnt3);
				}
				for (int num7 = 0; num7 <= tempCalcEntitities.Count - 1; num7++)
				{
					for (int num8 = 0; num8 <= tempCalcEntitities[num7].Count - 1; num8++)
					{
						Entity copiedEnt4 = null;
						buVector5.CopyEntities(tempCalcEntitities[num7][num8], ref copiedEnt4);
						BaseRefEntities2.Add(copiedEnt4);
					}
				}
				if (varSpinningRuntime.isFinish)
				{
				}
				camTp CamCalculated2 = new camTp();
				SortSettings sortSettings = new SortSettings();
				sortSettings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
				sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
				List<Entity> SortedEntities2 = new List<Entity>();
				SortResult Result2 = new SortResult();
				clsInit.cVector5.SortEntitiesByRefPoint(varSpinningRuntime.pntCurveStart, ref BaseRefEntities2, sortSettings, ref SortedEntities2, ref Result2);
				camParameters5 camParameters7 = new camParameters5();
				camParameters7.Distances.Safe = 0.0;
				camParameters7.Distances.Rapid = 0.0;
				camParameters7.Options.FeedFromEntityFeedrate = true;
				clsInit.cCam5.camContourCenter(SortedEntities2, TangentCalculaton: false, ccVars.toolActive, camParameters7, ref CamCalculated2);
				clsInit.appCommand.CamAvailableIDGet(ref CamCalculated2.CamID);
				ccVars.UndoDont = true;
				clsInit.appCommand.CamAdd(CamCalculated2);
				frmSpin.Visible = false;
				clsInit.appCommand.Reset();
				ccVars.UndoDont = false;
				clsFiles.SaveParameter();
			}
		}
		catch (Exception)
		{
		}
	}

	public void ValueChanged(object Data)
	{
		varMetalSpinning = new SpinPattern((SpinPattern)Data);
		SpinPatternCommand spinPatternCommand = new SpinPatternCommand();
		spinPatternCommand.ShowPattern = true;
		ShowPath(null, spinPatternCommand);
	}

	public void ShowPipePath(object sender, object Data)
	{
		try
		{
			SpinPatternCommand spinPatternCommand = (SpinPatternCommand)Data;
			new Point3D();
			new Point3D();
			new List<Entity>();
			ccVars.pntDrawDynamicLinesArrColored.Clear();
			varMetalPipeSpinning = new SpinPipePattern(frmSpinPipe.varSpinPattern);
			if (!(spinPatternCommand.ShowPattern | spinPatternCommand.NextPattern))
			{
				return;
			}
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
			camStep camStep6 = new camStep();
			List<double> CalcValues = new List<double>();
			camStep6.StartValue = MaxPoint.Y - varMetalPipeSpinning.TubeTopOffset;
			camStep6.EndValue = MidPoint.Y + varMetalPipeSpinning.CenterLineOffset;
			camStep6.StepType = CamStepType.StartToEndByStep;
			camStep6.Step = varMetalPipeSpinning.StepDepth;
			camStep6.Enable = true;
			clsInit.cVector.CamStepCalculation(camStep6, ref CalcValues);
			if (CalcValues.Count <= 0)
			{
				return;
			}
			double num = 0.0;
			double num2 = 0.0;
			double x = 0.0;
			double y = 0.0;
			for (int i = 0; i <= CalcValues.Count - 1; i++)
			{
				num = (double)i * varMetalPipeSpinning.SetTubeLeftOffsetEachStep;
				num2 = (double)i * varMetalPipeSpinning.SetTubeRightOffsetEachStep;
				List<Point3D> SortingPoints = new List<Point3D>();
				Line line = new Line(new Point3D(MinPoint.X - 10.0, CalcValues[i]), new Point3D(MaxPoint.X + 10.0, CalcValues[i]));
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
				{
					Point3D[] array = line.IntersectWith((ICurve)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j]);
					if (array != null && array.Length != 0)
					{
						SortingPoints.AddRange(array);
					}
				}
				clsInit.cVector5.SortDeltaX(MaxPoint, SortDirectionType.Bigger, ref SortingPoints);
				if (SortingPoints.Count >= 2)
				{
					List<PointRGB> list = new List<PointRGB>();
					double num3 = SortingPoints[0].X - varMetalPipeSpinning.TubeRigthOffset - num2;
					double y2 = SortingPoints[0].Y;
					double num4 = SortingPoints[1].X + varMetalPipeSpinning.PipeLeftOffset + num;
					double y3 = SortingPoints[1].Y;
					Point3D first = new Point3D(num3 + varMetalPipeSpinning.FirstCurveLength, y2 - varMetalPipeSpinning.FirstCurveLength);
					Point3D second = new Point3D(num3 + varMetalPipeSpinning.LeadinCurveLength * 0.8, y2);
					Point3D point3D = new Point3D(num3, y2 + varMetalPipeSpinning.LeadinCurveLength);
					Arc arc = new Arc(first, second, point3D, flip: false);
					arc.Regen(0.001);
					if (i > 0)
					{
						list.Add(new PointRGB(x, y, 0.0, Color.DarkOrange.R, Color.DarkOrange.G, Color.DarkOrange.B));
						list.Add(new PointRGB(point3D.X, y, 0.0, Color.LimeGreen.R, Color.LimeGreen.G, Color.LimeGreen.B));
					}
					for (int num5 = arc.Vertices.Length - 1; num5 >= 0; num5--)
					{
						list.Add(new PointRGB(arc.Vertices[num5].X, arc.Vertices[num5].Y, arc.Vertices[num5].Z, Color.Blue.R, Color.Blue.B, Color.Blue.B));
					}
					Point3D first2 = new Point3D(num3 + varMetalPipeSpinning.FirstCurveLength, y2 - varMetalPipeSpinning.FirstCurveLength);
					Point3D second2 = new Point3D(num3 + varMetalPipeSpinning.FirstCurveLength * 0.8, y2 - varMetalPipeSpinning.FirstCurveLength * 0.5);
					Point3D third = new Point3D(num3, y2);
					Arc arc2 = new Arc(first2, second2, third, flip: false);
					arc2.Regen(0.001);
					for (int k = 0; k <= arc2.Vertices.Length - 1; k++)
					{
						list.Add(new PointRGB(arc2.Vertices[k].X, arc2.Vertices[k].Y, arc2.Vertices[k].Z, Color.Blue.R, Color.Blue.G, Color.Blue.B));
					}
					list.Add(new PointRGB(num3, y2, SortingPoints[0].Z, Color.Blue.R, Color.Blue.G, Color.Blue.B));
					list.Add(new PointRGB(num4, y3, SortingPoints[1].Z, Color.Blue.R, Color.Blue.G, Color.Blue.B));
					if (list.Count > 0)
					{
						list[list.Count - 1] = new PointRGB(list[list.Count - 1].X, list[list.Count - 1].Y, list[list.Count - 1].Z, Color.Gold.R, Color.Gold.G, Color.Gold.B);
					}
					list.Add(new PointRGB(num4, y3 + varMetalPipeSpinning.LeaveHeight, SortingPoints[0].Z, Color.Gold.R, Color.Gold.G, Color.Gold.B));
					x = num4;
					y = y3 + varMetalPipeSpinning.LeaveHeight;
					ccVars.pntDrawDynamicLinesArrColored.Add(list);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void ValuePipeChanged(object Data)
	{
		varMetalPipeSpinning = new SpinPipePattern((SpinPipePattern)Data);
		SpinPatternCommand spinPatternCommand = new SpinPatternCommand();
		spinPatternCommand.ShowPattern = true;
		clsFiles.SaveParameter();
		ShowPipePath(null, spinPatternCommand);
	}
}
