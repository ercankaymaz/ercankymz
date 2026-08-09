using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buClass.Apps;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Tufting;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace buCadCamResVer5.Tufting;

public class clsTufting
{
	public static TuftingSettings varTuftingSettings = new TuftingSettings();

	public static TuftingRuntimeSettings varTuftingRunSettings = new TuftingRuntimeSettings();

	public static TuftingTempVars varTufting = new TuftingTempVars();

	public List<TuftingYarn> Yarns = new List<TuftingYarn>();

	public int TuftCounter = 1;

	public SortResult tuftingSortResult = new SortResult();

	public List<List<Entity>> refSortEntitiesLL = new List<List<Entity>>();

	public List<Entity> refSortEntities = new List<Entity>();

	public SortSettings tuftingSortSettings = new SortSettings();

	public List<string> cmdExceptionID = new List<string>();

	public void Init()
	{
		buMWTuftingVars.Init();
		buTuftingCalc.Sorted = new List<TuftingSequenceItem>();
		cmdExceptionID.Add("clsTufting - ID = 101-00100");
		cmdExceptionID.Add("clsTufting - ID = 101-00101");
		cmdExceptionID.Add("clsTufting - ID = 101-00102");
		cmdExceptionID.Add("clsTufting - ID = 101-00103");
		cmdExceptionID.Add("clsTufting - ID = 101-00104");
		cmdExceptionID.Add("clsTufting - ID = 101-00105");
		cmdExceptionID.Add("clsTufting - ID = 101-00106");
		cmdExceptionID.Add("clsTufting - ID = 101-00107");
		cmdExceptionID.Add("clsTufting - ID = 101-00108");
		cmdExceptionID.Add("clsTufting - ID = 101-00109");
		cmdExceptionID.Add("clsTufting - ID = 101-00110");
		cmdExceptionID.Add("clsTufting - ID = 101-00111");
		cmdExceptionID.Add("clsTufting - ID = 101-00112");
		cmdExceptionID.Add("clsTufting - ID = 101-00113");
		cmdExceptionID.Add("clsTufting - ID = 101-00114");
		cmdExceptionID.Add("clsTufting - ID = 101-00115");
		cmdExceptionID.Add("clsTufting - ID = 101-00116");
		cmdExceptionID.Add("clsTufting - ID = 101-00117");
		cmdExceptionID.Add("clsTufting - ID = 101-00118");
		cmdExceptionID.Add("clsTufting - ID = 101-00119");
		cmdExceptionID.Add("clsTufting - ID = 101-00120");
		cmdExceptionID.Add("clsTufting - ID = 101-00121");
		cmdExceptionID.Add("clsTufting - ID = 101-00122");
		cmdExceptionID.Add("clsTufting - ID = 101-00123");
		cmdExceptionID.Add("clsTufting - ID = 101-00124");
		cmdExceptionID.Add("clsTufting - ID = 101-00125");
		cmdExceptionID.Add("clsTufting - ID = 101-00126");
		cmdExceptionID.Add("clsTufting - ID = 101-00127");
		cmdExceptionID.Add("clsTufting - ID = 101-00128");
		cmdExceptionID.Add("clsTufting - ID = 101-00129");
		cmdExceptionID.Add("clsTufting - ID = 101-00130");
		cmdExceptionID.Add("clsTufting - ID = 101-00131");
		cmdExceptionID.Add("clsTufting - ID = 101-00132");
		cmdExceptionID.Add("clsTufting - ID = 101-00133");
	}

	public void cmdShowGCode()
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (buTuftingCalc.Sorted.Count != 0)
			{
				string name = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
				for (int i = 0; i <= buTuftingCalc.Sorted.Count - 1; i++)
				{
					if (clsInit.cTuft.isSameLayerTuftOrOutline(buTuftingCalc.Sorted[i].LayerName, name))
					{
						List<string> GCodes = new List<string>();
						CreateCodeFromSorted(buTuftingCalc.Sorted[i], ref GCodes);
						string text = "";
						text = buString5.StringListToString(GCodes, NewLineEnable: true);
						F_Notepad f_Notepad = new F_Notepad();
						f_Notepad.Init(text);
						f_Notepad.Show();
					}
				}
			}
			else
			{
				buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
			}
		}
		else
		{
			buString5.MessageBoxWarning(AppLanguage.CadCamMessages[94]);
		}
	}

	public void cmdCreateGCode()
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = varTuftingRunSettings.pathGCode;
			saveFileDialog.Filter = "Tuftinf CNC File (*.inf)|*.inf";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string text = "";
			varTuftingRunSettings.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
			text = varTuftingRunSettings.pathGCode + "\\" + buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
			DirectoryInfo directoryInfo = new DirectoryInfo(text);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
				buFile5.SaveToFile(" ", text + "\\" + fileNameWithoutExtension + ".inf");
				for (int i = 0; i <= buTuftingCalc.Sorted.Count - 1; i++)
				{
					LayerBase5 Layer = new LayerBase5();
					clsInit.cVector5.GetLayerFromName(ccVars.Pages[ccVars.PageIndex].Layers, buTuftingCalc.Sorted[i].LayerName, ref Layer);
					string text2 = (i + 1).ToString("D2") + "_" + Layer.Name;
					if (Layer.Defination.Length > 0)
					{
						text2 = text2 + "_" + Layer.Defination;
					}
					List<string> GCodes = new List<string>();
					CreateCodeFromSorted(buTuftingCalc.Sorted[i], ref GCodes);
					string text3 = "";
					text3 = buString5.StringListToString(GCodes, NewLineEnable: true);
					buFile5.SaveToFile(text3, text + "\\" + text2 + ".hit");
				}
			}
			else
			{
				buString5.MessageBoxWarning(buTufting.LangTuftingMessage[5]);
			}
		}
		else
		{
			buString5.MessageBoxWarning(AppLanguage.CadCamMessages[94]);
		}
	}

	public void cmdYarnSettings()
	{
		try
		{
			F_YarnSettings f_YarnSettings = new F_YarnSettings();
			TuftingYarn.Copy(Yarns, ref f_YarnSettings.Yarns);
			f_YarnSettings.Init();
			f_YarnSettings.StartPosition = FormStartPosition.CenterParent;
			f_YarnSettings.ShowDialog();
			if (f_YarnSettings.PropertiesForm.Result == DialogResult.OK)
			{
				TuftingYarn.Copy(f_YarnSettings.Yarns, ref Yarns);
				SaveTuftingFile();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[0];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSimStart()
	{
		try
		{
			if (buTuftingCalc.Sorted.Count != 0)
			{
				ccVars.Pages[ccVars.PageIndex].Cams.Clear();
				camTp camTp2 = new camTp();
				camTp2.Tool = new ToolBase5();
				camTp2.Tool.Geometry.GeometryType = buClass.ToolType.Flat;
				camTp2.Tool.Geometry.Diameter = 2.0;
				for (int i = 0; i <= buTuftingCalc.Sorted.Count - 1; i++)
				{
					List<Point3D> Points = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(buTuftingCalc.Sorted[i].SortedEntities, buSystem.RegenDeviation, ref Points);
					new List<Pnt6DSimMove>();
					for (int j = 0; j <= Points.Count - 1; j++)
					{
						Pnt6DSimMove item = new Pnt6DSimMove(Points[j].X, Points[j].Y, Points[j].Z);
						camTp2.SimilationPoint.SimMove.Add(item);
					}
				}
				ccVars.Pages[ccVars.PageIndex].Cams.Add(camTp2);
				clsItem.timSim.Interval = clsVar.varSimulation.SimulationInterval;
				clsInit.appCommand.simStart();
			}
			else
			{
				buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[0];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSimStop()
	{
		try
		{
			clsInit.appCommand.simStop();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[0];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdFill()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doFill();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			ccVars.Action = actionTypeBU.tuftingFill;
			dynamicInfo.Command = buTufting.LangTuftingCommands[0];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[0] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdRandomPattern()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doRandomPattern();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			ccVars.Action = actionTypeBU.tuftingRandomPatternDraw;
			dynamicInfo.Command = buTufting.LangTuftingCommands[0];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[0] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdGetClosedArea()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.tuftingGetClosedPath;
			dynamicInfo.Command = AppLanguage.CadCamCommand[13];
			ccVars.selectionProcess = false;
			ccVars.stpDrawing = 1;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[2];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdChangePatternDirection()
	{
		try
		{
			if (buTuftingCalc.Sorted.Count != 0)
			{
				clsInit.appCommand.Reset(ClearSelection: false);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
				ccVars.Action = actionTypeBU.tuftingChangeSelectedDirection;
				dynamicInfo.Command = AppLanguage.CadCamCommand[1];
				clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[1] + " [ " + dynamicInfo.Command + " ]");
				ccVars.selectionProcess = false;
				ccVars.stpDrawing = 1;
				if (ccVars.SelectionOP.Selections.Count != 0)
				{
					doChangeDirection();
				}
				else
				{
					ccVars.selectionProcess = true;
				}
			}
			else
			{
				buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[3];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSetDefinationProps()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doSetProps();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			ccVars.Action = actionTypeBU.tuftingSetProperties;
			dynamicInfo.Command = buTufting.LangTuftingCommands[0];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[0] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSpeciftDefinationArea()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.selectAndBreakByFreeSelection;
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			dynamicInfo.Command = AppLanguage.CadCamCommand[9] + " ";
			clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
			clsInit.appCommand.SpinPropsSet(1, ContentAlignment.MiddleCenter, Visible: false, Focus: true, SelectAll: true, "Len");
			ccVars.enableViewportCross = true;
			ccVars.enableViewPortCurrentLineArrow = true;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[15];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDefinationFromSelection()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doSelectAndBrakeBySelection();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			ccVars.Action = actionTypeBU.tuftingDefinationFromSelection;
			dynamicInfo.Command = buTufting.LangTuftingCommands[0];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[0] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDefinationAllReset()
	{
		try
		{
			if (buString5.MessageBoxQuestion(buTufting.LangTuftingMessage[2]) != DialogResult.Yes)
			{
				return;
			}
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				CustomData customData = null;
				if (entity.EntityData != null && entity.EntityData is CustomData)
				{
					customData = new CustomData((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData);
				}
				if (customData != null)
				{
					customData.tuftingMode = tuftingStitchModeType.None;
					customData.tuftingPileHeight = 0.0;
					customData.tuftingStitchLength = 0.0;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData = customData;
				}
				Color LayerColor = Color.Black;
				double LayerThickness = 1.0;
				clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref LayerColor, ref LayerThickness);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].ColorMethod = colorMethodType.byLayer;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LineWeightMethod = colorMethodType.byEntity;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Color = LayerColor;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LineWeight = (float)LayerThickness;
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDefinationLayerReset()
	{
		try
		{
			if (buString5.MessageBoxQuestion(buTufting.LangTuftingMessage[3] + " - [ " + ccVars.Pages[ccVars.PageIndex].LayerName + " ]") != DialogResult.Yes)
			{
				return;
			}
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (entity.LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
				{
					CustomData customData = null;
					if (entity.EntityData != null && entity.EntityData is CustomData)
					{
						customData = new CustomData((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData);
					}
					if (customData != null)
					{
						customData.tuftingMode = tuftingStitchModeType.None;
						customData.tuftingPileHeight = 0.0;
						customData.tuftingStitchLength = 0.0;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData = customData;
					}
					Color LayerColor = Color.Black;
					double LayerThickness = 1.0;
					clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref LayerColor, ref LayerThickness);
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].ColorMethod = colorMethodType.byLayer;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LineWeightMethod = colorMethodType.byEntity;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Color = LayerColor;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LineWeight = (float)LayerThickness;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdExchangePattern()
	{
		try
		{
			if (buTuftingCalc.Sorted.Count != 0)
			{
				if (buTuftingCalc.Sorted.Count <= 0)
				{
					buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
					return;
				}
				int num = -1;
				F_TuftingExchange f_TuftingExchange = new F_TuftingExchange();
				for (int i = 0; i <= buTuftingCalc.Sorted.Count - 1; i++)
				{
					if (buTuftingCalc.Sorted[i].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
					{
						f_TuftingExchange.TuftSequence = new TuftingSequenceItem(buTuftingCalc.Sorted[i]);
						num = i;
						i = buTuftingCalc.Sorted.Count;
					}
				}
				if (num < 0)
				{
					buString5.MessageBoxWarning(buTufting.LangTuftingMessage[4]);
					return;
				}
				f_TuftingExchange.layerSelected = new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex]);
				f_TuftingExchange.AllEntities = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities);
				f_TuftingExchange.Init();
				f_TuftingExchange.ShowDialog();
				if (f_TuftingExchange.PropertiesForm.Result == DialogResult.OK)
				{
					buTuftingCalc.Sorted[num] = new TuftingSequenceItem(f_TuftingExchange.TuftSequence);
				}
			}
			else
			{
				buString5.MessageBoxWarning(buTufting.LangTuftingMessage[1]);
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[4];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDeletePattern()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count > 0)
			{
				doDeletePattern();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[5];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDeleteAllPattern()
	{
		try
		{
			doDeleteAllPattern();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[6];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDeleteSorted()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count > 0)
			{
				doDeleteSorted();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[7];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDeleteAllSorted()
	{
		try
		{
			doDeleteAllSorted();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[8];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdLockTuftEntities()
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (entity.GetType() == typeof(LinearPath) && ((CustomData)entity.EntityData).ActionName.ToLower().IndexOf("tuft") >= 0)
				{
					entity.Selectable = false;
				}
			}
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
			{
				if ((ccVars.Pages[ccVars.PageIndex].Layers[j].Name.ToLower().IndexOf("t_") >= 0) | (ccVars.Pages[ccVars.PageIndex].Layers[j].Name.ToLower().IndexOf("o_") >= 0))
				{
					ccVars.Pages[ccVars.PageIndex].Layers[j].Lock = true;
				}
			}
			clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: false, -1);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[9];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdUnLockTuftEntities()
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (entity.GetType() == typeof(LinearPath) && ((CustomData)entity.EntityData).ActionName.ToLower().IndexOf("tuft") >= 0)
				{
					entity.Selectable = true;
				}
			}
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
			{
				if ((ccVars.Pages[ccVars.PageIndex].Layers[j].Name.ToLower().IndexOf("t_") >= 0) | (ccVars.Pages[ccVars.PageIndex].Layers[j].Name.ToLower().IndexOf("o_") >= 0))
				{
					ccVars.Pages[ccVars.PageIndex].Layers[j].Lock = false;
				}
			}
			clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: false, -1);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[10];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdAddPoint()
	{
		try
		{
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			ccVars.Action = actionTypeBU.tuftingAddPoint;
			dynamicInfo.Command = buTufting.LangTuftingCommands[0];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[0] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdRemovePoint()
	{
		try
		{
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			ccVars.Action = actionTypeBU.tuftingRemovePoint;
			dynamicInfo.Command = buTufting.LangTuftingCommands[0];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[0] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdBreakAllIntersect()
	{
		try
		{
			varTuftingRunSettings.ThisIsTuftingOperation = true;
			doBreakAllIntersection();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[11];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdBreak()
	{
		try
		{
			varTuftingRunSettings.ThisIsTuftingOperation = true;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (entity.GetType() == typeof(LinearPath) && ((CustomData)entity.EntityData).EntityName.ToLower().IndexOf("tuft") >= 0)
				{
					entity.Selectable = true;
				}
			}
			varTuftingRunSettings.BreakTuftCurve = true;
			clsInit.appCommand.cmdEventBreak();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[11];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdJoin()
	{
		try
		{
			varTuftingRunSettings.ThisIsTuftingOperation = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doJoin();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			ccVars.Action = actionTypeBU.tuftingJoin;
			dynamicInfo.Command = buTufting.LangTuftingCommands[0];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[0] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[11];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDrawManuel()
	{
		try
		{
			varTuftingRunSettings.ThisIsTuftingOperation = true;
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.drawPolyline;
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			dynamicInfo.Command = AppLanguage.CadCamCommand[9] + " ";
			clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
			clsInit.appCommand.SpinPropsSet(1, ContentAlignment.MiddleCenter, Visible: false, Focus: true, SelectAll: true, "Len");
			ccVars.enableViewportCross = true;
			ccVars.enableViewPortCurrentLineArrow = true;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[15];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDrawText()
	{
		try
		{
			varTuftingRunSettings.ThisIsTuftingOperation = true;
			clsInit.appCommand.cmdDrawVectorText();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[33];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdPartOffset()
	{
		try
		{
			varTuftingRunSettings.ThisIsTuftingOperation = true;
			clsInit.appCommand.cmdEventOffset();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[33];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdBorderLine()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			varTuftingRunSettings.LineAsBorderLine = true;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.drawLine;
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			dynamicInfo.Command = AppLanguage.CadCamCommand[9] + " ";
			clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
			clsInit.appCommand.SpinPropsSet(1, ContentAlignment.MiddleCenter, Visible: false, Focus: true, SelectAll: true, "Len");
			ccVars.enableViewportCross = true;
			ccVars.enableViewPortCurrentLineArrow = true;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[15];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdAddImage()
	{
		clsInit.appCommand.cmdDrawImage();
	}

	public void cmdImageList()
	{
		F_TuftingImageList f_TuftingImageList = new F_TuftingImageList();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is Picture)
			{
				Entity entity = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]);
				f_TuftingImageList.Images.Add((Picture)entity);
				f_TuftingImageList.ImageIndex.Add(i);
			}
		}
		if (f_TuftingImageList.Images.Count <= 0)
		{
			return;
		}
		f_TuftingImageList.Init();
		f_TuftingImageList.StartPosition = FormStartPosition.CenterParent;
		f_TuftingImageList.ShowDialog();
		if (f_TuftingImageList.PropertiesForm.Result == DialogResult.OK)
		{
			for (int j = 0; j <= f_TuftingImageList.ImageIndex.Count - 1; j++)
			{
				Entity value = buVector5.CopyEntities(f_TuftingImageList.Images[j]);
				int index = f_TuftingImageList.ImageIndex[j];
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] = value;
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
	}

	public void cmdImageHideAll()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is Picture)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Visible = false;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdImageShowAll()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is Picture)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Visible = true;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdSortSequence()
	{
		try
		{
			F_TuftingSort f_TuftingSort = new F_TuftingSort();
			f_TuftingSort.Settings = new TuftingSettings(varTuftingSettings);
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Layers[i].Name.ToUpper().IndexOf("T_") >= 0)
				{
					f_TuftingSort.Layers.Add(new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[i]));
				}
			}
			f_TuftingSort.SelectedLayerIndex = varTuftingRunSettings.SelectedLayerIndex;
			f_TuftingSort.SelectedLayerName = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			f_TuftingSort.Init();
			f_TuftingSort.ShowDialog();
			if (f_TuftingSort.PropertiesForm.Result != DialogResult.OK)
			{
				return;
			}
			varTuftingSettings = new TuftingSettings(f_TuftingSort.Settings);
			if (varTuftingSettings.SortType != tuftingSelectionModeType.Manuel)
			{
				varTuftingRunSettings.SelectedLayerIndex = f_TuftingSort.SelectedLayerIndex;
				varTuftingRunSettings.SelectedLayerName = f_TuftingSort.SelectedLayerName;
				SaveTuftingFile();
				doSortPattern();
				return;
			}
			SaveTuftingFile();
			refSortEntitiesLL.Clear();
			ccVars.SortedEntities.Clear();
			ccVars.SortedEntities = new List<Entity>();
			refSortEntitiesLL = new List<List<Entity>>();
			refSortEntities = new List<Entity>();
			ccVars.pntMark.Clear();
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j];
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] is ICurve && ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name == entity.LayerName)
				{
					CustomData entityCustomData = clsInit.cVector5.GetEntityCustomData(entity);
					if ((entityCustomData.ActionName == "TuftFill") & !entityCustomData.CamSelected)
					{
						refSortEntities.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j]));
						ccVars.pntMark.Add(new PointRGB(((ICurve)entity).StartPoint.X, ((ICurve)entity).StartPoint.Y, ((ICurve)entity).StartPoint.Z, Color.Lime.R, Color.Lime.G, Color.Lime.B));
						ccVars.pntMark.Add(new PointRGB(((ICurve)entity).EndPoint.X, ((ICurve)entity).EndPoint.Y, ((ICurve)entity).EndPoint.Z, Color.Red.R, Color.Red.G, Color.Red.B));
					}
				}
			}
			if (refSortEntities.Count <= 0)
			{
				buString5.MessageBoxWarning(buTufting.LangTuftingMessage[4]);
				return;
			}
			clsInit.appCommand.ShowViewportButtons(OkButton: true, CancelButton: true, UndoButton: false);
			tuftingSortSettings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
			tuftingSortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.AskMe;
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			ccVars.Action = actionTypeBU.tuftingSelectPatternManuel;
			dynamicInfo.Command = buTufting.LangTuftingCommands[2];
			clsInit.appCommand.cmdMainFormStatusUpdate(buTufting.LangTuftingStatus[2] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[12];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSortAll()
	{
		try
		{
			doSortAll();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[12];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdRealViewMode()
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				if (entity.LayerName.ToLower().IndexOf("t_") < 0)
				{
					continue;
				}
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Layers[j].Name == entity.LayerName && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() == typeof(LinearPath))
					{
						((LinearPath)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]).GlobalWidth = ccVars.Pages[ccVars.PageIndex].Layers[j].Tufting.TuftingThickness;
					}
				}
			}
			clsInit.appCommand.eventGeneralCommand(new GeneralCommandEventArg("tuftingRealView"));
			ccVars.RealDrawMode = true;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.DrawingPropertiesUpdate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[13];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdDrawViewMode()
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() == typeof(LinearPath))
				{
					((LinearPath)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]).GlobalWidth = 0.0;
				}
			}
			clsInit.appCommand.eventGeneralCommand(new GeneralCommandEventArg("tuftingDrawView"));
			ccVars.RealDrawMode = false;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.DrawingPropertiesUpdate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[14];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void ShowSortedAllLayers(bool Show)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				CustomData customData = entity.EntityData as CustomData;
				if ((customData.typeDefination == entityTypeDefination.Tufting) & customData.CamSelected)
				{
					if (!Show)
					{
						Color color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName].Color;
						float lineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName].LineWeight;
						entity.Color = color;
						entity.LineWeight = lineWeight + 1f;
					}
					else
					{
						entity.ColorMethod = colorMethodType.byEntity;
						entity.LineWeightMethod = colorMethodType.byEntity;
						entity.Color = varTuftingSettings.ShowSortedEntitiesColor;
						entity.LineWeight = (float)varTuftingSettings.ShowSortedEntitiesThickness;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[33];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void ShowSortedSelectedLayers(bool Show)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				CustomData customData = entity.EntityData as CustomData;
				if ((customData.typeDefination == entityTypeDefination.Tufting) & customData.CamSelected & (ccVars.Pages[ccVars.PageIndex].LayerName == entity.LayerName))
				{
					if (!Show)
					{
						Color color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName].Color;
						float lineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName].LineWeight;
						entity.Color = color;
						entity.LineWeight = lineWeight + 1f;
					}
					else
					{
						entity.ColorMethod = colorMethodType.byEntity;
						entity.LineWeightMethod = colorMethodType.byEntity;
						entity.Color = varTuftingSettings.ShowSortedEntitiesColor;
						entity.LineWeight = (float)varTuftingSettings.ShowSortedEntitiesThickness;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[33];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void ShowSortedReset()
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
				CustomData customData = entity.EntityData as CustomData;
				if ((customData.typeDefination == entityTypeDefination.Tufting) & customData.CamSelected)
				{
					Color color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName].Color;
					float lineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName].LineWeight;
					entity.Color = color;
					entity.LineWeight = lineWeight + 1f;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[33];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void ShowDirectionArrowSelectedLayers(bool Show)
	{
		try
		{
			if (ccVars.Pages[ccVars.PageIndex].LayerIndex >= 0)
			{
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
				{
					CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
					if (ccVars.Pages[ccVars.PageIndex].LayerName == ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName && customData.typeDefination == entityTypeDefination.DirectionArrow)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Visible = Show;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[33];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void ShowDirectionArrowAllLayers(bool Show)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
				if (customData.typeDefination == entityTypeDefination.DirectionArrow)
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Visible = Show;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[33];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void NewPageTuftingExtension()
	{
		buTuftingCalc.Sorted.Clear();
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buTufting.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buTufting.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Tufting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Tufting Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buTufting.LangTuftingCommands);
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

	public void SaveTuftingFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\Tufting\\Tufting.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("<TuftYarns>");
			for (int i = 0; i <= Yarns.Count - 1; i++)
			{
				arrayList.AddRange(Yarns[i].ToDefAll("", 2, SerilizationMode.MultiLine));
			}
			arrayList.Add("</TuftYarns>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Tufting Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<TuftingSettings>");
			arrayList.AddRange(varTuftingSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("</TuftingSettings>");
			arrayList.Add("<TuftingRuntimeSettings>");
			arrayList.AddRange(varTuftingRunSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("</TuftingRuntimeSettings>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Tufting Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			buMWTuftingVars.varCamContour.mwPar.Serialize(AppPath.Settings + "\\Tufting\\mwTuftingContour.bin");
			buMWTuftingVars.varCamRough.mwPar.Serialize(AppPath.Settings + "\\Tufting\\mwTuftingRough.bin");
			string fileName2 = AppPath.Settings + "\\Tufting\\TuftingCam.bucamset";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   MW Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<MwCamSettings>");
			arrayList.AddRange(buMWTuftingVars.varCamContour.buPar.ToDefAll("_varCamContour", 2, SerilizationMode5.MultiLine));
			arrayList.AddRange(buMWTuftingVars.varCamRough.buPar.ToDefAll("_varCamRough", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</MwCamSettings>");
			buFile.SaveToFile(arrayList, fileName2);
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[17];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenTuftingFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Tufting\\Tufting.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			Yarns = new List<TuftingYarn>();
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Tufting Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Tufting Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<TuftingSettings>", "</TuftingSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varTuftingSettings);
						buLog.addLog("Tufting Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<TuftingRuntimeSettings>", "</TuftingRuntimeSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varTuftingRunSettings);
						buLog.addLog("TuftingRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					List<List<string>> list = new List<List<string>>();
					ArrayList CalcList2 = new ArrayList();
					list = new List<List<string>>();
					Yarns = new List<TuftingYarn>();
					buString.ListToSpecificList("<TuftYarns>", "</TuftYarns>", AddStartEndKey: true, arrayList, ref CalcList2);
					buString.ListToSpecificList("<TuftingYarn>", "</TuftingYarn>", AddStartEndKey: true, CalcList2, ref list);
					if (list.Count > 0)
					{
						for (int i = 0; i <= list.Count - 1; i++)
						{
							TuftingYarn tuftingYarn = new TuftingYarn();
							buSerilization.Decode(list[i], "", SerilizationMode.MultiLine, tuftingYarn);
							Yarns.Add(tuftingYarn);
						}
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Tufting Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Tufting Settings Decoder Error");
				}
			}
			buLog.addLog("Tufting Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Tufting\\mwTuftingContour.bin");
			if (fileInfo.Exists)
			{
				buMWTuftingVars.varCamContour.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Tufting\\mwTuftingRough.bin");
			if (fileInfo.Exists)
			{
				buMWTuftingVars.varCamRough.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Tufting\\TuftingCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLog.addLog("Tufting Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Tufting Cam Settings File Missing");
				return;
			}
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileName2, ref arrayList);
			try
			{
				ArrayList CalcList3 = new ArrayList();
				buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, arrayList, ref CalcList3);
				if (CalcList3.Count > 0)
				{
					buSerilization.Decode(arrayList, "_varCamContour", SerilizationMode.MultiLine, buMWTuftingVars.varCamContour);
					buSerilization.Decode(arrayList, "_varCamRough", SerilizationMode.MultiLine, buMWTuftingVars.varCamRough);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Tufting Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Tufting Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void CreateTuftEntityOutline(Entity refEntity, string LayerName)
	{
		try
		{
			string entityName = "Tufting" + TuftCounter;
			CreateTuftEntity(refEntity, LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftOutline", -1, -1);
			TuftCounter++;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[19];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void CreateTuftEntity(Entity refEntity, string LayerName)
	{
		try
		{
			string entityName = "Tufting" + TuftCounter;
			CreateTuftEntity(refEntity, LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftFill", -1, -1);
			TuftCounter++;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[19];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void CreateTuftEntity(Entity refEntity, string LayerName, string SceneName, string EntityName, string ActionName, int SeqID, int GroupID)
	{
		try
		{
			((CustomData)refEntity.EntityData).GroupIdIndex = GroupID;
			((CustomData)refEntity.EntityData).EntityName = EntityName;
			((CustomData)refEntity.EntityData).SceneName = SceneName;
			((CustomData)refEntity.EntityData).ActionName = ActionName;
			((CustomData)refEntity.EntityData).Sequence = SeqID;
			((CustomData)refEntity.EntityData).typeDefination = entityTypeDefination.Tufting;
			refEntity.Selectable = varTuftingSettings.LockTuftEntitiesWhenCreated;
			refEntity.LayerName = LayerName;
			if (ccVars.RealDrawMode && refEntity is LinearPath)
			{
				((LinearPath)refEntity).GlobalWidth = clsVar.varInterface.FatWireframeDistance;
			}
			clsInit.appCommand.AddEntity(refEntity);
			TuftCounter++;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[19];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteArrowByEntityIndex(int Index)
	{
		try
		{
			if (!((Index >= 0) & (Index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)))
			{
				return;
			}
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() == typeof(buLinearPathArrow))
				{
					buLinearPathArrow buLinearPathArrow2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] as buLinearPathArrow;
					if (buLinearPathArrow2.RefEntity == Index)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[20];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteArrowByReleatedEntityName(string Name)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() == typeof(buLinearPathArrow))
				{
					CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
					if (customData.EntityName == Name)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[20];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteArrowAndMarkerByReleatedEntityName(string Name)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
				CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
				if ((customData.EntityName == Name) & ((customData.typeDefination == entityTypeDefination.DirectionArrow) | (customData.typeDefination == entityTypeDefination.EndMarker) | (customData.typeDefination == entityTypeDefination.StartMarker)))
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[20];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteArrowByReleatedEntityName(List<string> Names)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
			}
			for (int j = 0; j <= Names.Count - 1; j++)
			{
				for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].GetType() == typeof(buLinearPathArrow))
					{
						CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].EntityData as CustomData;
						if (customData.EntityName == Names[j])
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						}
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[20];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteArrowAndMarkerByReleatedEntityName(List<string> Names)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
			}
			for (int j = 0; j <= Names.Count - 1; j++)
			{
				for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
				{
					CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].EntityData as CustomData;
					if ((customData.EntityName == Names[j]) & ((customData.typeDefination == entityTypeDefination.DirectionArrow) | (customData.typeDefination == entityTypeDefination.EndMarker) | (customData.typeDefination == entityTypeDefination.StartMarker)))
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[20];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void GetTuftingPropertiesFromLayer(string LayerName, ref double PileHeight, ref double StitchLen, ref tuftingStitchModeType Type)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
		{
			if (LayerName == ccVars.Pages[ccVars.PageIndex].Layers[i].Name)
			{
				PileHeight = ccVars.Pages[ccVars.PageIndex].Layers[i].Tufting.PileHeight;
				StitchLen = ccVars.Pages[ccVars.PageIndex].Layers[i].Tufting.StitchLength;
				Type = ccVars.Pages[ccVars.PageIndex].Layers[i].Tufting.StitchMode;
			}
		}
	}

	public void AddArrowByEntity(Entity refEntity, int RefIndex, string ArrowLayerName)
	{
		try
		{
			if (!clsVar.varInterface5.DirectionArrowSettings.Enable)
			{
				return;
			}
			List<buLinearPathArrow> DirArrows = new List<buLinearPathArrow>();
			clsInit.cVector5.DirectionArrowFromEntities(refEntity, clsVar.varInterface5.DirectionArrowSettings, ref DirArrows);
			if (DirArrows.Count > 0)
			{
				ccVars.OsnapDont = true;
				for (int i = 0; i <= DirArrows.Count - 1; i++)
				{
					ccVars.UndoDont = true;
					CustomData customData = new CustomData();
					customData.typeDefination = entityTypeDefination.DirectionArrow;
					customData.EntityName = ((CustomData)refEntity.EntityData).EntityName;
					customData.ActionName = "directionarrow";
					customData.RefIndex = RefIndex;
					DirArrows[i].EntityData = customData;
					DirArrows[i].LayerName = ArrowLayerName;
					DirArrows[i].Selectable = false;
					DirArrows[i].RefEntity = RefIndex;
					clsInit.appCommand.AddEntity(DirArrows[i]);
				}
				ccVars.OsnapDont = false;
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[21];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void AddAllMarkers()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
			if (customData.typeDefination == entityTypeDefination.Tufting)
			{
				ICurve curve = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] as ICurve;
				int refIndex = i;
				if (curve.IsClosed)
				{
					AddStartMarkerPoint(curve.StartPoint, customData.EntityName, refIndex, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName);
					continue;
				}
				AddStartMarkerPoint(curve.StartPoint, customData.EntityName, refIndex, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName);
				AddEndMarkerPoint(curve.EndPoint, customData.EntityName, refIndex, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName);
			}
		}
	}

	public void AddStartMarkerPoint(Point3D pntStart, string EntName, int RefIndex, string LayerName)
	{
		try
		{
			ccVars.OsnapDont = true;
			Circle circle = new Circle(pntStart, varTuftingSettings.StartMarkerCircleDiameter / 2.0);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.StartMarker;
			customData.EntityName = EntName;
			customData.ActionName = "startmarker";
			customData.RefIndex = RefIndex;
			circle.EntityData = customData;
			circle.LayerName = LayerName;
			circle.Selectable = false;
			clsInit.appCommand.AddEntity(circle);
			ccVars.OsnapDont = false;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[21];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void AddEndMarkerPoint(Point3D pntEnd, string EntName, int RefIndex, string LayerName)
	{
		try
		{
			ccVars.OsnapDont = true;
			CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(varTuftingSettings.EndMarkerSquareWidth, varTuftingSettings.EndMarkerSquareWidth, centered: true);
			compositeCurve.Translate(pntEnd.X, pntEnd.Y);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.EndMarker;
			customData.EntityName = EntName;
			customData.ActionName = "endmarker";
			customData.RefIndex = RefIndex;
			compositeCurve.EntityData = customData;
			compositeCurve.LayerName = LayerName;
			compositeCurve.Selectable = false;
			clsInit.appCommand.AddEntity(compositeCurve);
			ccVars.OsnapDont = false;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[21];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void AddStartEndMarkerPoint(Point3D pntStart, Point3D pntEnd, string EntName, int RefIndex, string LayerName)
	{
		try
		{
			ccVars.OsnapDont = true;
			Circle circle = new Circle(pntStart, varTuftingSettings.StartMarkerCircleDiameter / 2.0);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.StartMarker;
			customData.EntityName = EntName;
			customData.ActionName = "startmarker";
			customData.RefIndex = RefIndex;
			circle.EntityData = customData;
			circle.LayerName = LayerName;
			circle.Selectable = false;
			clsInit.appCommand.AddEntity(circle);
			CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(varTuftingSettings.EndMarkerSquareWidth, varTuftingSettings.EndMarkerSquareWidth, centered: true);
			compositeCurve.Translate(pntEnd.X, pntEnd.Y);
			customData = new CustomData();
			customData.typeDefination = entityTypeDefination.EndMarker;
			customData.EntityName = EntName;
			customData.ActionName = "endmarker";
			customData.RefIndex = RefIndex;
			compositeCurve.EntityData = customData;
			compositeCurve.LayerName = LayerName;
			compositeCurve.Selectable = false;
			clsInit.appCommand.AddEntity(compositeCurve);
			ccVars.OsnapDont = false;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[21];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteMarkerByReleatedEntityName(string Name)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
				CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
				if ((customData.EntityName == Name) & ((customData.typeDefination == entityTypeDefination.EndMarker) | (customData.typeDefination == entityTypeDefination.StartMarker)))
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[20];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteMarkerByReleatedEntityName(List<string> Names)
	{
		try
		{
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
			}
			for (int j = 0; j <= Names.Count - 1; j++)
			{
				for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
				{
					CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].EntityData as CustomData;
					if ((customData.EntityName == Names[j]) & ((customData.typeDefination == entityTypeDefination.EndMarker) | (customData.typeDefination == entityTypeDefination.StartMarker)))
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[20];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void DeleteMarkerPoint(int RefIndex)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
			if ((customData.RefIndex == RefIndex) & ((customData.typeDefination == entityTypeDefination.EndMarker) | (customData.typeDefination == entityTypeDefination.StartMarker)))
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
	}

	public void DeleteAllMarkerPoint()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData is CustomData customData && ((customData.typeDefination == entityTypeDefination.EndMarker) | (customData.typeDefination == entityTypeDefination.StartMarker)))
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
	}

	public void AddArrowAndMarkerEntitiesFromName(bool ReverseDir, List<string> EntityNameList)
	{
		for (int i = 0; i <= EntityNameList.Count - 1; i++)
		{
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j];
				CustomData customData = entity.EntityData as CustomData;
				if ((customData.EntityName == EntityNameList[i]) & (customData.typeDefination == entityTypeDefination.Tufting) & customData.CamSelected)
				{
					LinearPath linearPath = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] as LinearPath;
					if (ReverseDir)
					{
						linearPath.Reverse();
					}
					AddStartEndMarkerPoint(((ICurve)linearPath).StartPoint, ((ICurve)linearPath).EndPoint, ((CustomData)linearPath.EntityData).EntityName, j, linearPath.LayerName);
					if (clsVar.varInterface5.DirectionArrowSettings.Enable)
					{
						AddArrowByEntity(linearPath, j, linearPath.LayerName);
					}
				}
			}
		}
	}

	public void GetLayerNameFRomActiveColor(int ActiveColor, ref string LayerName)
	{
		switch (ActiveColor)
		{
		case 1:
			LayerName = "T_A";
			break;
		case 2:
			LayerName = "T_B";
			break;
		case 3:
			LayerName = "T_C";
			break;
		case 4:
			LayerName = "T_D";
			break;
		case 5:
			LayerName = "T_E";
			break;
		case 6:
			LayerName = "T_F";
			break;
		case 7:
			LayerName = "T_G";
			break;
		case 8:
			LayerName = "T_H";
			break;
		}
	}

	public void ContourOperation(bool AddTuftingEntity, double Offset, int ContourCount, CamClosedContourType Type, ClockDirectionType ClockDir, tuftingBorderOffsetType OffsetType, bool BorderConnect, string LayerName, List<Entity> contourEntities, ref List<Entity> LastCalcEntities)
	{
		List<List<Entity>> list = new List<List<Entity>>();
		for (int i = 1; i <= ContourCount; i++)
		{
			double num = Offset * (double)i;
			if (Type == CamClosedContourType.Inner)
			{
				num = 0.0 - num;
			}
			List<Point3D> Points = new List<Point3D>();
			clsInit.cVector5.EntitiesToPointsWithCamDirection(contourEntities, buSystem.RegenDeviation, ref Points);
			List<List<Point3D>> OffsetedPoints = new List<List<Point3D>>();
			clsInit.cVector5.OffsetContour(Points, num, OffsetCornerType.Line, CamOpenContourType2.Center, Plane.XY, 0.0, ref OffsetedPoints);
			if (OffsetedPoints.Count > 0)
			{
				Points.Clear();
				Points = new List<Point3D>();
				Points.AddRange(OffsetedPoints[0]);
			}
			LinearPath linearPath = new LinearPath(Points);
			linearPath.EntityData = new CustomData();
			ClockDirectionType clockDirection = clsInit.cVector5.GetClockDirection(Points);
			if (clockDirection != ClockDir)
			{
				Points.Reverse();
			}
			if (varTuftingSettings.StraightOutBorderCount <= 1)
			{
				List<Entity> list2 = new List<Entity>();
				list2.Add(linearPath);
				list.Add(buVector5.CopyEntities(list2));
			}
			else
			{
				if (OffsetType == tuftingBorderOffsetType.Contour)
				{
					LinearPath linearPath2 = new LinearPath(Points);
					linearPath2.EntityData = new CustomData();
					List<Entity> list3 = new List<Entity>();
					list3.Add(linearPath2);
					list.Add(list3);
				}
				if (OffsetType == tuftingBorderOffsetType.Spiral)
				{
					List<Entity> list4 = new List<Entity>();
					if (i != 1)
					{
						if (i > 1)
						{
							LinearPath linearPath3 = new LinearPath(Points);
							ICurve refCurve = linearPath3;
							if (Type == CamClosedContourType.Inner)
							{
								clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, Offset);
								list4.Add((Entity)refCurve);
							}
							if (Type == CamClosedContourType.Outter)
							{
								clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, 0.0);
								list4.Add((Entity)refCurve);
							}
						}
					}
					else
					{
						LinearPath linearPath4 = new LinearPath(Points);
						ICurve refCurve2 = linearPath4;
						if (Type == CamClosedContourType.Inner)
						{
							clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve2, 0.0, Offset);
							list4.Add((Entity)refCurve2);
						}
						if (Type == CamClosedContourType.Outter)
						{
							clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve2, Offset, 0.0);
							list4.Add((Entity)refCurve2);
						}
					}
					list.Add(list4);
				}
			}
			LastCalcEntities.Clear();
			LastCalcEntities = new List<Entity>();
			LastCalcEntities.Add(linearPath);
		}
		if (!(list.Count > 0 && AddTuftingEntity))
		{
			return;
		}
		List<Point3D> Points2 = new List<Point3D>();
		for (int j = 0; j <= list.Count - 1; j++)
		{
			for (int k = 0; k <= list[j].Count - 1; k++)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(list[j][k], ref copiedEnt);
				List<Point3D> Points3 = new List<Point3D>();
				clsInit.cVector5.EntityToPointWithCamDirection(copiedEnt, buSystem.RegenDeviation, ref Points3);
				Points2.AddRange(Points3);
			}
			if (!BorderConnect)
			{
				clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points2);
				LinearPath linearPath5 = new LinearPath(Points2);
				linearPath5.EntityData = new CustomData();
				CreateTuftEntityOutline(linearPath5, LayerName);
				Points2.Clear();
			}
		}
		if (Points2.Count > 2)
		{
			clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points2);
			LinearPath linearPath6 = new LinearPath(Points2);
			linearPath6.EntityData = new CustomData();
			CreateTuftEntityOutline(linearPath6, LayerName);
		}
	}

	public void ContourOperation11(double Offset, CamClosedContourType Type, ClockDirectionType ClockDir, tuftingBorderOffsetType OffsetType, bool BorderConnect, MWCalculationOptions MWCalcoptions, string LayerName, List<Entity> contourEntities, ref List<Entity> LastCalcEntities)
	{
		buMWTuftingVars.varCamContour.buPar.Offsets.ClosedContour = Type;
		buMWTuftingVars.varCamContour.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.TwoAxisPatternStartFromPosition = WireframeBasedTpCalcParamsStartFromPosition.SfpUserDefinedStartPoint;
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamContour.mwPar, buMWTuftingVars.varCamContour.buPar, out clsMW.varbuCamWFContourPars);
		List<List<Entity>> list = new List<List<Entity>>();
		for (int i = 1; i <= varTuftingSettings.StraightOutBorderCount; i++)
		{
			ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
			ccVars.toolActive.Geometry.Diameter = varTuftingSettings.StraightOutterOffset * 2.0 * (double)i;
			List<Point3D> Points = new List<Point3D>();
			clsMW.CamEntities.Clear();
			clsInit.cVector5.EntitiesToPointsWithCamDirection(contourEntities, buSystem.RegenDeviation, ref Points);
			LinearPath item = new LinearPath(Points);
			clsMW.CamEntities.Add(item);
			camTp camTp2 = new camTp();
			MWCalcoptions.UseConstantStartPoint = true;
			MWCalcoptions.UseStartPoint = true;
			MWCalcoptions.StartPointX = contourEntities[0].Vertices[0].X;
			MWCalcoptions.StartPointY = contourEntities[0].Vertices[0].Y;
			List<List<Point3D>> OffsetedPoints = new List<List<Point3D>>();
			clsInit.cVector5.OffsetContour(Points, ccVars.toolActive.Geometry.Diameter / 2.0, OffsetCornerType.Line, CamOpenContourType2.Center, Plane.XY, 0.0, ref OffsetedPoints);
			if (OffsetedPoints.Count > 0)
			{
				item = new LinearPath(OffsetedPoints[0]);
				item.EntityData = new CustomData();
				camTp2.EntitiesG1.Add(item);
			}
			buMWTuftingVars.varCamContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamContour.buPar);
			ClockDirectionType clockDirection = clsInit.cVector5.GetClockDirection(OffsetedPoints[0]);
			if (clockDirection != ClockDir)
			{
				clsInit.cVector5.ChangeEntitiesDirection(ref camTp2.EntitiesG1);
			}
			if (varTuftingSettings.StraightOutBorderCount <= 1)
			{
				list.Add(buVector5.CopyEntities(camTp2.EntitiesG1));
			}
			else
			{
				if (OffsetType == tuftingBorderOffsetType.Contour)
				{
					list.Add(buVector5.CopyEntities(camTp2.EntitiesG1));
				}
				if (OffsetType == tuftingBorderOffsetType.Spiral)
				{
					List<Entity> list2 = new List<Entity>();
					if (i != 1)
					{
						if (i > 1)
						{
							ICurve refCurve = camTp2.EntitiesG1[0] as ICurve;
							if (Type == CamClosedContourType.Inner)
							{
								clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, Offset);
								list2.Add((Entity)refCurve);
							}
							if (Type == CamClosedContourType.Outter)
							{
								clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve, Offset, 0.0);
								list2.Add((Entity)refCurve);
							}
							for (int j = 1; j <= camTp2.EntitiesG1.Count - 2; j++)
							{
								list2.Add(buVector5.CopyEntities(camTp2.EntitiesG1[j]));
							}
						}
					}
					else
					{
						for (int k = 0; k <= camTp2.EntitiesG1.Count - 2; k++)
						{
							list2.Add(buVector5.CopyEntities(camTp2.EntitiesG1[k]));
						}
						ICurve refCurve2 = camTp2.EntitiesG1[camTp2.EntitiesG1.Count - 1] as ICurve;
						if (Type == CamClosedContourType.Inner)
						{
							clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve2, 0.0, Offset);
							list2.Add((Entity)refCurve2);
						}
						if (Type == CamClosedContourType.Outter)
						{
							clsInit.cVector5.EntityCutFromStartAndEndByLength(ref refCurve2, Offset, 0.0);
							list2.Add((Entity)refCurve2);
						}
					}
					list.Add(list2);
				}
			}
			LastCalcEntities.Clear();
			LastCalcEntities = new List<Entity>();
			buVector5.CopyEntities(camTp2.EntitiesG1, ref LastCalcEntities);
		}
		if (list.Count <= 0)
		{
			return;
		}
		List<Point3D> Points2 = new List<Point3D>();
		for (int l = 0; l <= list.Count - 1; l++)
		{
			for (int m = 0; m <= list[l].Count - 1; m++)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(list[l][m], ref copiedEnt);
				List<Point3D> Points3 = new List<Point3D>();
				clsInit.cVector5.EntityToPointWithCamDirection(copiedEnt, buSystem.RegenDeviation, ref Points3);
				Points2.AddRange(Points3);
			}
			if (!BorderConnect)
			{
				clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points2);
				LinearPath linearPath = new LinearPath(Points2);
				linearPath.EntityData = new CustomData();
				CreateTuftEntity(linearPath, LayerName);
				Points2.Clear();
			}
		}
		if (Points2.Count > 2)
		{
			clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points2);
			LinearPath linearPath2 = new LinearPath(Points2);
			linearPath2.EntityData = new CustomData();
			CreateTuftEntity(linearPath2, LayerName);
		}
	}

	public void ApplySetProperties(List<int> IndexList, tuftingStitchModeType TuftingMode, double PileHeight, double StitchLenght)
	{
		List<int> list = new List<int>();
		if (IndexList.Count <= 0)
		{
			for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
			{
				int index = ccVars.SelectionOP.Selections[i].Index;
				list.Add(index);
			}
		}
		else
		{
			list.AddRange(IndexList);
		}
		float num = 1f;
		if (TuftingMode != tuftingStitchModeType.None)
		{
			num += 0.15f;
		}
		if (PileHeight != 0.0)
		{
			num += 0.15f;
		}
		if (StitchLenght != 0.0)
		{
			num += 0.15f;
		}
		for (int j = 0; j <= list.Count - 1; j++)
		{
			int index2 = list[j];
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2];
			CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData as CustomData;
			if (!((customData.tuftingMode != tuftingStitchModeType.None) | (customData.tuftingPileHeight > 0.0) | (customData.tuftingStitchLength > 0.0)))
			{
				Color LayerColor = Color.White;
				_ = Color.Black;
				double LayerThickness = 1.0;
				clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref LayerColor, ref LayerThickness);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].ColorMethod = colorMethodType.byLayer;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].LineWeightMethod = colorMethodType.byEntity;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Color = LayerColor;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].LineWeight = (float)LayerThickness;
			}
			else
			{
				Color LayerColor2 = Color.White;
				Color black = Color.Black;
				double LayerThickness2 = 1.0;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].ColorMethod = colorMethodType.byEntity;
				clsInit.cVector5.GetLayerColorAndThicknessByLayerName(entity.LayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref LayerColor2, ref LayerThickness2);
				black = buImage5.Darken(LayerColor2, num);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].ColorMethod = colorMethodType.byEntity;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Color = black;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].LineWeightMethod = colorMethodType.byEntity;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].LineWeight = (float)varTuftingSettings.DefinationEntityThickness;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Regen(buSystem.RegenDeviation);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void SortEntities(ref List<Entity> sortingEntities, Color layerColor, double LayerThickness, string LayerName, List<Entity> AlreadySortedEntities)
	{
		SortSettings sortSettings = new SortSettings();
		SortResult Result = new SortResult();
		List<Entity> SortedEntities = new List<Entity>();
		Point3D refPoint = new Point3D();
		sortSettings.Option.NextGroupRules = varTuftingSettings.SortAutoNextGroupRules;
		sortSettings.Option.UseBoxBoundingForMinMax = varTuftingSettings.SortBoxBounding;
		double PileHeight = 0.0;
		double StitchLen = 0.0;
		tuftingStitchModeType Type = tuftingStitchModeType.None;
		GetTuftingPropertiesFromLayer(LayerName, ref PileHeight, ref StitchLen, ref Type);
		if (!((sortingEntities.Count > 0) | ((sortingEntities.Count == 0) & (AlreadySortedEntities.Count > 0))))
		{
			return;
		}
		for (int i = 0; i <= sortingEntities.Count - 1; i++)
		{
			sortingEntities[i].Selectable = true;
		}
		if (sortingEntities.Count > 0)
		{
			refPoint = buVector5.ToPoint3D(sortingEntities[0].Vertices[0]);
		}
		if (AlreadySortedEntities.Count != 0)
		{
			buVector5.CopyEntities(AlreadySortedEntities, ref SortedEntities);
		}
		else
		{
			clsInit.cVector5.SortEntitiesByRefPoint(refPoint, ref sortingEntities, sortSettings, ref SortedEntities, ref Result);
		}
		if (SortedEntities.Count > 0)
		{
			List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			int count = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count;
			for (int j = 0; j <= count - 1; j++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j];
				CustomData customData = entity.EntityData as CustomData;
				for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
				{
					int num = -1;
					for (int l = 0; l <= SplitedEntitites[k].Count - 1; l++)
					{
						if (!((((CustomData)entity.EntityData).EntityName == ((CustomData)SplitedEntitites[k][l].EntityData).EntityName) & (((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Tufting)))
						{
							continue;
						}
						((CustomData)entity.EntityData).CamSelected = true;
						entity.ColorMethod = colorMethodType.byEntity;
						entity.LineWeightMethod = colorMethodType.byEntity;
						if (!((customData.tuftingMode == tuftingStitchModeType.None) & (customData.tuftingPileHeight == 0.0) & (customData.tuftingStitchLength == 0.0)))
						{
							if ((customData.tuftingMode == tuftingStitchModeType.None) | (customData.tuftingMode == tuftingStitchModeType.Auto))
							{
								customData.tuftingMode = Type;
								((CustomData)SplitedEntitites[k][l].EntityData).tuftingMode = Type;
							}
							if (customData.tuftingPileHeight == 0.0)
							{
								customData.tuftingPileHeight = PileHeight;
								((CustomData)SplitedEntitites[k][l].EntityData).tuftingPileHeight = PileHeight;
							}
							if (customData.tuftingStitchLength == 0.0)
							{
								customData.tuftingStitchLength = StitchLen;
								((CustomData)SplitedEntitites[k][l].EntityData).tuftingStitchLength = StitchLen;
							}
							entity.LineWeight += 2f;
						}
						else
						{
							entity.Color = layerColor;
							entity.LineWeight = (float)LayerThickness + 1f;
							customData.tuftingMode = Type;
							customData.tuftingPileHeight = PileHeight;
							customData.tuftingStitchLength = StitchLen;
							((CustomData)SplitedEntitites[k][l].EntityData).tuftingMode = Type;
							((CustomData)SplitedEntitites[k][l].EntityData).tuftingPileHeight = PileHeight;
							((CustomData)SplitedEntitites[k][l].EntityData).tuftingStitchLength = StitchLen;
						}
						AddArrowByEntity(entity, j, entity.LayerName);
						num = j;
					}
					if (SplitedEntitites[k].Count > 0 && num >= 0)
					{
						ICurve curve = SplitedEntitites[k][0] as ICurve;
						CustomData customData2 = SplitedEntitites[k][0].EntityData as CustomData;
						if (curve.IsClosed)
						{
							AddStartMarkerPoint(curve.StartPoint, ((CustomData)SplitedEntitites[k][0].EntityData).EntityName, num, SplitedEntitites[k][0].LayerName);
						}
						else if (customData2.sortDirection != entitySortDirection.Normal)
						{
							AddStartMarkerPoint(curve.EndPoint, ((CustomData)SplitedEntitites[k][0].EntityData).EntityName, num, SplitedEntitites[k][0].LayerName);
							AddEndMarkerPoint(curve.StartPoint, ((CustomData)SplitedEntitites[k][0].EntityData).EntityName, num, SplitedEntitites[k][0].LayerName);
						}
						else
						{
							AddStartMarkerPoint(curve.StartPoint, ((CustomData)SplitedEntitites[k][0].EntityData).EntityName, num, SplitedEntitites[k][0].LayerName);
							AddEndMarkerPoint(curve.EndPoint, ((CustomData)SplitedEntitites[k][0].EntityData).EntityName, num, SplitedEntitites[k][0].LayerName);
						}
					}
				}
			}
			if (SplitedEntitites.Count > 0)
			{
				if (buTuftingCalc.Sorted.Count != 0)
				{
					int num2 = -1;
					for (int m = 0; m <= buTuftingCalc.Sorted.Count - 1; m++)
					{
						if (buTuftingCalc.Sorted[m].LayerName == LayerName)
						{
							num2 = m;
						}
					}
					if (num2 < 0)
					{
						TuftingSequenceItem tuftingSequenceItem = new TuftingSequenceItem();
						tuftingSequenceItem.LayerName = LayerName;
						for (int n = 0; n <= SplitedEntitites.Count - 1; n++)
						{
							List<Entity> copiedEnt = new List<Entity>();
							buVector5.CopyEntities(SplitedEntitites[n], ref copiedEnt);
							tuftingSequenceItem.SortedEntities.AddRange(copiedEnt);
						}
						buTuftingCalc.Sorted.Add(tuftingSequenceItem);
					}
					else
					{
						for (int num3 = 0; num3 <= SplitedEntitites.Count - 1; num3++)
						{
							List<Entity> copiedEnt2 = new List<Entity>();
							buVector5.CopyEntities(SplitedEntitites[num3], ref copiedEnt2);
							buTuftingCalc.Sorted[num2].SortedEntities.AddRange(copiedEnt2);
						}
					}
				}
				else
				{
					TuftingSequenceItem tuftingSequenceItem2 = new TuftingSequenceItem();
					tuftingSequenceItem2.LayerName = LayerName;
					for (int num4 = 0; num4 <= SplitedEntitites.Count - 1; num4++)
					{
						List<Entity> copiedEnt3 = new List<Entity>();
						buVector5.CopyEntities(SplitedEntitites[num4], ref copiedEnt3);
						tuftingSequenceItem2.SortedEntities.AddRange(copiedEnt3);
					}
					buTuftingCalc.Sorted.Add(tuftingSequenceItem2);
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public bool isTuftingLayer(string Name)
	{
		if (Name.IndexOf("T_") < 0)
		{
			return false;
		}
		return true;
	}

	public bool GetDefinationFromEntity(Entity refEntity, ref double StitchLen, ref double PileHeight, ref tuftingStitchModeType TuftMode)
	{
		if (refEntity.EntityData == null)
		{
			return false;
		}
		if (!(refEntity.EntityData is CustomData))
		{
			return false;
		}
		CustomData customData = refEntity.EntityData as CustomData;
		if (customData.tuftingMode != tuftingStitchModeType.Cut)
		{
			if (customData.tuftingMode != tuftingStitchModeType.Loop)
			{
				double PileHeight2 = 0.0;
				double StitchLen2 = 0.0;
				GetTuftingPropertiesFromLayer(refEntity.LayerName, ref PileHeight2, ref StitchLen2, ref TuftMode);
			}
			else
			{
				TuftMode = tuftingStitchModeType.Loop;
			}
		}
		else
		{
			TuftMode = tuftingStitchModeType.Cut;
		}
		if (customData.tuftingPileHeight == 0.0)
		{
			double StitchLen3 = 0.0;
			tuftingStitchModeType Type = tuftingStitchModeType.None;
			GetTuftingPropertiesFromLayer(refEntity.LayerName, ref PileHeight, ref StitchLen3, ref Type);
		}
		else
		{
			PileHeight = customData.tuftingPileHeight;
		}
		if (customData.tuftingStitchLength == 0.0)
		{
			double PileHeight3 = 0.0;
			tuftingStitchModeType Type2 = tuftingStitchModeType.None;
			GetTuftingPropertiesFromLayer(refEntity.LayerName, ref PileHeight3, ref StitchLen, ref Type2);
		}
		else
		{
			StitchLen = customData.tuftingStitchLength;
		}
		return true;
	}

	public void doFill()
	{
		try
		{
			F_TuftingFill f_TuftingFill = new F_TuftingFill();
			f_TuftingFill.Settings = new TuftingSettings(varTuftingSettings);
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
			{
				f_TuftingFill.LayerNames.Add(ccVars.Pages[ccVars.PageIndex].Layers[i].Name);
			}
			f_TuftingFill.SelectedLayerIndex = varTuftingRunSettings.SelectedLayerIndex;
			f_TuftingFill.Init();
			f_TuftingFill.ShowDialog();
			if (f_TuftingFill.PropertiesForm.Result != DialogResult.OK)
			{
				return;
			}
			varTuftingSettings = new TuftingSettings(f_TuftingFill.Settings);
			varTuftingRunSettings.SelectedLayerIndex = f_TuftingFill.SelectedLayerIndex;
			if (varTuftingSettings.FillType != tuftingFillOffsetType.Spiral)
			{
				if (varTuftingSettings.FillType != tuftingFillOffsetType.Straight)
				{
					if (varTuftingSettings.FillType != tuftingFillOffsetType.Contour)
					{
						if (varTuftingSettings.FillType == tuftingFillOffsetType.Trace)
						{
							doWireframeTrace();
						}
					}
					else
					{
						doWireframeCounter();
					}
				}
				else
				{
					doWireframeStraight();
				}
			}
			else
			{
				doWireframeSpiral();
			}
			SaveTuftingFile();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[22];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doWireframeStraight()
	{
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		try
		{
			int groupID = -1;
			int SequenceID = -1;
			varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			string name = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Layers[i].Tufting.isDirectionArrow)
				{
					varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[i].Name;
				}
			}
			SelectionOption selectionOption = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
			selectionOption.OnlyClosedShapes = clsVar.varSelection.OnlyClosedShapes;
			selectionOption.MinVerticeCount = clsVar.varSelection.MinVeeticeCount;
			selectionOption.MinSingleEntityLength = clsVar.varSelection.MinSingleEntityLength;
			List<Entity> selectedEntities = new List<Entity>();
			clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
			clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			if (clsVar.varEntities.MinVerticesDistance > 0.0)
			{
				clsInit.cVector5.RemoveSmallLengthFromEntitiesPoints(ref selectedEntities, clsVar.varEntities.MinVerticesDistance);
			}
			Point3D refPoint = new Point3D();
			if (selectedEntities[0] is ICurve)
			{
				refPoint = buVector5.ToPoint3D(((ICurve)selectedEntities[0]).StartPoint);
			}
			List<EntitiesGroup> Groups = new List<EntitiesGroup>();
			clsInit.cVector5.FindEntitiesGroupFromEntities(refPoint, selectedEntities, Plane.XY, ref Groups);
			for (int j = 0; j <= Groups.Count - 1; j++)
			{
				List<Entity> copiedEnt = new List<Entity>();
				List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
				buVector5.CopyEntities(Groups[j].Outside, ref copiedEnt);
				buVector5.CopyEntities(Groups[j].Inside, ref copiedEnt2);
				clsInit.appCommand.undoBuffer();
				if (varTuftingSettings.StraightOutBorderEnable)
				{
					List<Entity> LastCalcEntities = new List<Entity>();
					ContourOperation(AddTuftingEntity: true, varTuftingSettings.StraightOutterOffset, varTuftingSettings.StraightOutBorderCount, CamClosedContourType.Inner, varTuftingSettings.StraightOutBorderFillDirection, varTuftingSettings.StraightOutBorderType, varTuftingSettings.StraightOutBorderConnect, name, copiedEnt, ref LastCalcEntities);
					copiedEnt.Clear();
					buVector5.CopyEntities(LastCalcEntities, ref copiedEnt);
					LastCalcEntities.Clear();
				}
				if (varTuftingSettings.StraightInBorderEnable & (copiedEnt2.Count > 0))
				{
					List<List<Entity>> list = new List<List<Entity>>();
					for (int k = 0; k <= copiedEnt2.Count - 1; k++)
					{
						List<Entity> LastCalcEntities2 = new List<Entity>();
						ContourOperation(AddTuftingEntity: true, varTuftingSettings.StraightInnerOffset, varTuftingSettings.StraightInBorderCount, CamClosedContourType.Outter, varTuftingSettings.StraightInBorderFillDirection, varTuftingSettings.StraightInBorderType, varTuftingSettings.StraightInBorderConenct, name, copiedEnt2[k], ref LastCalcEntities2);
						list.Add(LastCalcEntities2);
					}
					copiedEnt2.Clear();
					buVector5.CopyEntities(list, ref copiedEnt2);
					list.Clear();
				}
				camTp camTp2 = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
				ccVars.toolActive.Geometry.Diameter = varTuftingSettings.StraightRowSpace * 2.0;
				mWCalculationOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.DontShowDialogBox = true;
				mWCalculationOptions.isBuSort = false;
				mWCalculationOptions.UseStartPoint = false;
				mWCalculationOptions.UseConstantStartPoint = true;
				mWCalculationOptions.StartPointX = 0.0;
				mWCalculationOptions.StartPointY = 0.0;
				mWCalculationOptions.HeightFromEntities = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
				if (!varTuftingSettings.StraightRowLink)
				{
					buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeOneway;
				}
				buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = varTuftingSettings.StraightRowSpace;
				buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = varTuftingSettings.StraightAngle;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtParallel;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = varTuftingSettings.CutTolerance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
				buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = true;
				buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = varTuftingSettings.MaxDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = true;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = varTuftingSettings.MinDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = varTuftingSettings.SharpCorner;
				PercentOrValueParameter val = new PercentOrValueParameter(Unit.Metric, true);
				val.Percent = 50.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = val;
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				if (varTuftingSettings.LinkAsSpline)
				{
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
				}
				if (!varTuftingSettings.StraightRowLink)
				{
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				}
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
				clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
				List<Entity> selectedEntities2 = new List<Entity>();
				selectionOption = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
				new SortResult();
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.appCommand.SelectionToEntities(ref selectedEntities2, selectionOption);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities2);
				clsInit.cVector5.BoxSizeCalculate(selectedEntities2, ref MinPoint, ref MidPoint, ref MaxPoint);
				ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
				ccVars.toolActive.Geometry.Diameter = varTuftingSettings.StraightRowSpace * 2.0;
				double num = MaxPoint.Y - MinPoint.Y;
				num -= ccVars.toolActive.Geometry.Diameter;
				double num2 = Math.Round(num / varTuftingSettings.StraightRowSpace, 0);
				mWCalculationOptions.WireframeRoughtStepOverParaelelOverride = num / (num2 - 1.0);
				camTp2 = new camTp();
				camResult Result = null;
				clsMW.CamEntities.Clear();
				clsMW.CamEntitiesGroup.Clear();
				mWCalculationOptions.UseSortedAndSplitedEntities = false;
				if (!((copiedEnt.Count > 0) & (copiedEnt2.Count > 0)))
				{
					buVector5.CopyEntities(copiedEnt, ref clsMW.CamEntities);
				}
				else
				{
					mWCalculationOptions.UseSortedAndSplitedEntities = true;
					clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt));
					for (int l = 0; l <= copiedEnt2.Count - 1; l++)
					{
						clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt2[l]));
					}
				}
				clsInit.appMW.doWireframeContour(mWCalculationOptions, ccVars.toolActive, ref camTp2, ref Result);
				buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
				for (int m = 0; m <= camTp2.EntitiesG1.Count - 1; m++)
				{
					ICurve curve = camTp2.EntitiesG1[m] as ICurve;
					if (curve.StartPoint.Z != 0.0)
					{
						continue;
					}
					clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
					ccVars.UndoDont = true;
					Entity EyeEntity = null;
					buConversion5.EyeCamEntityToEyeEntity(camTp2.EntitiesG1[m], ref EyeEntity);
					if (EyeEntity == null)
					{
						continue;
					}
					string entityName = "Tufting" + TuftCounter;
					if (!varTuftingSettings.StraightRowLink)
					{
						if (!((buLinearPathCam)camTp2.EntitiesG1[m]).isLink)
						{
							CreateTuftEntity(EyeEntity, name, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftFill", SequenceID, groupID);
						}
					}
					else
					{
						CreateTuftEntity(EyeEntity, name, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftFill", SequenceID, groupID);
					}
				}
			}
			clsInit.appCommand.Reset();
			clsFiles.SaveParameter();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[23];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doWireframeSpiral()
	{
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		try
		{
			int GroupIndex = -1;
			int SequenceID = -1;
			varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			string name = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Layers[i].Tufting.isDirectionArrow)
				{
					varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[i].Name;
				}
			}
			SelectionOption option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
			List<Entity> selectedEntities = new List<Entity>();
			clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
			clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			Point3D refPoint = new Point3D();
			if (selectedEntities[0] is ICurve)
			{
				refPoint = buVector5.ToPoint3D(((ICurve)selectedEntities[0]).StartPoint);
			}
			List<EntitiesGroup> Groups = new List<EntitiesGroup>();
			clsInit.cVector5.FindEntitiesGroupFromEntities(refPoint, selectedEntities, Plane.XY, ref Groups);
			for (int j = 0; j <= Groups.Count - 1; j++)
			{
				List<Entity> copiedEnt = new List<Entity>();
				List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
				buVector5.CopyEntities(Groups[j].Outside, ref copiedEnt);
				buVector5.CopyEntities(Groups[j].Inside, ref copiedEnt2);
				clsInit.appCommand.undoBuffer();
				if (varTuftingSettings.SpiralOutterEnable)
				{
					List<Entity> LastCalcEntities = new List<Entity>();
					ContourOperation(AddTuftingEntity: true, varTuftingSettings.SpiralOutterOffset, 1, CamClosedContourType.Inner, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, BorderConnect: false, name, copiedEnt, ref LastCalcEntities);
					copiedEnt.Clear();
					buVector5.CopyEntities(LastCalcEntities, ref copiedEnt);
					LastCalcEntities.Clear();
				}
				if (varTuftingSettings.SpiralInnerEnable & (copiedEnt2.Count > 0))
				{
					List<List<Entity>> list = new List<List<Entity>>();
					for (int k = 0; k <= copiedEnt2.Count - 1; k++)
					{
						List<Entity> LastCalcEntities2 = new List<Entity>();
						ContourOperation(AddTuftingEntity: true, varTuftingSettings.SpiralInnerOffset, 1, CamClosedContourType.Outter, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, BorderConnect: false, name, copiedEnt2[k], ref LastCalcEntities2);
						list.Add(LastCalcEntities2);
					}
					copiedEnt2.Clear();
					buVector5.CopyEntities(list, ref copiedEnt2);
					list.Clear();
				}
				camTp camTp2 = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
				ccVars.toolActive.Geometry.Diameter = varTuftingSettings.StraightRowSpace * 2.0;
				mWCalculationOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.DontShowDialogBox = true;
				mWCalculationOptions.isBuSort = false;
				mWCalculationOptions.UseStartPoint = false;
				mWCalculationOptions.UseConstantStartPoint = true;
				mWCalculationOptions.StartPointX = 0.0;
				mWCalculationOptions.StartPointY = 0.0;
				mWCalculationOptions.HeightFromEntities = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
				buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = varTuftingSettings.StraightAngle;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtOffset;
				buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = varTuftingSettings.SpiralRowSpace;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ReverseCuttingOrderFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = varTuftingSettings.CutTolerance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
				buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = true;
				buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = varTuftingSettings.MaxDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = true;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = varTuftingSettings.MinDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = varTuftingSettings.SharpCorner;
				PercentOrValueParameter val = new PercentOrValueParameter(Unit.Metric, true);
				val.Percent = 50.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = val;
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				if (varTuftingSettings.LinkAsSpline)
				{
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
				}
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
				clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
				List<Entity> selectedEntities2 = new List<Entity>();
				option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
				new SortResult();
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities2);
				clsInit.cVector5.BoxSizeCalculate(selectedEntities2, ref MinPoint, ref MidPoint, ref MaxPoint);
				double num = MaxPoint.Y - MinPoint.Y;
				num -= ccVars.toolActive.Geometry.Diameter;
				double num2 = Math.Round(num / varTuftingSettings.StraightRowSpace, 0);
				mWCalculationOptions.WireframeRoughtStepOverParaelelOverride = num / (num2 - 1.0);
				camTp2 = new camTp();
				camResult Result = null;
				clsMW.CamEntities.Clear();
				clsMW.CamEntitiesGroup.Clear();
				mWCalculationOptions.UseSortedAndSplitedEntities = false;
				if (!((copiedEnt.Count > 0) & (copiedEnt2.Count > 0)))
				{
					buVector5.CopyEntities(copiedEnt, ref clsMW.CamEntities);
				}
				else
				{
					mWCalculationOptions.UseSortedAndSplitedEntities = true;
					clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt));
					for (int l = 0; l <= copiedEnt2.Count - 1; l++)
					{
						clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt2[l]));
					}
				}
				clsInit.appMW.doWireframeContour(mWCalculationOptions, ccVars.toolActive, ref camTp2, ref Result);
				buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
				if (!varTuftingSettings.SpiralInnerEnable)
				{
					ccVars.toolActive.Geometry.Diameter = varTuftingSettings.SpiralInnerOffset * 2.0;
				}
				else
				{
					ccVars.toolActive.Geometry.Diameter = varTuftingSettings.SpiralInnerOffset * 2.0 * 2.0;
				}
				clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
				List<List<Point3D>> list2 = new List<List<Point3D>>();
				List<Point3D> Points = new List<Point3D>();
				bool flag = false;
				Point3D pt = new Point3D();
				for (int m = 0; m <= camTp2.EntitiesG1.Count - 1; m++)
				{
					if (m != 14)
					{
					}
					new List<Point3D>();
					List<Point3D> List = new List<Point3D>();
					Point3D point3D = new Point3D();
					bool flag2 = false;
					for (int n = 0; n <= camTp2.EntitiesG1[m].Vertices.Length - 1; n++)
					{
						List.Add(buVector5.ToPoint3D(camTp2.EntitiesG1[m].Vertices[n]));
					}
					int num3 = -1;
					for (int num4 = 1; num4 <= List.Count - 2; num4++)
					{
						double num5 = clsInit.cVector5.AngleOfTwoLines(List[num4 - 1], List[num4], List[num4], List[num4 + 1], Plane.XY);
						if (num5 < 160.0 && num3 == -1)
						{
							num3 = num4;
							num4 = List.Count;
						}
					}
					if (num3 >= 0)
					{
						clsInit.cVector5.ShiftPointList(ref List, -num3);
					}
					if (m < camTp2.EntitiesG1.Count - 1)
					{
						double num6 = Point3D.Distance(camTp2.EntitiesG1[m].Vertices[camTp2.EntitiesG1[m].Vertices.Length - 1], camTp2.EntitiesG1[m + 1].Vertices[0]);
						if (num6 < varTuftingSettings.SpiralRowSpace * 1.3)
						{
							Point3D EndPnt = new Point3D();
							double angle = clsInit.cVector5.PointAngle(List[List.Count - 1], List[List.Count - 2], Plane.XY);
							clsInit.cVector5.LineWithLengthAndAngle(List[List.Count - 2], 10000.0, angle, ref EndPnt);
							Line line = new Line(List[List.Count - 2], EndPnt);
							Point3D[] array = line.IntersectWith((ICurve)camTp2.EntitiesG1[m + 1]);
							if (array != null && array.Length != 0)
							{
								point3D = buVector5.ToPoint3D(array[0]);
								List[List.Count - 1] = new Point3D(array[0].X, array[0].Y);
								flag2 = true;
							}
						}
					}
					if (m > 0)
					{
						double num7 = Point3D.Distance(camTp2.EntitiesG1[m - 1].Vertices[camTp2.EntitiesG1[m - 1].Vertices.Length - 1], camTp2.EntitiesG1[m].Vertices[0]);
						if (num7 < varTuftingSettings.SpiralRowSpace * 1.2 && flag)
						{
							LinearPath linearPath = new LinearPath(List);
							ICurve lower = new LinearPath();
							ICurve upper = new LinearPath();
							linearPath.SplitBy(pt, out lower, out upper);
							if (lower != null)
							{
								List = new List<Point3D>();
								if (((LinearPath)lower).Vertices.Length <= ((LinearPath)upper).Vertices.Length)
								{
									List.AddRange(((LinearPath)upper).Vertices);
								}
								else
								{
									List.AddRange(((LinearPath)lower).Vertices);
								}
							}
						}
					}
					ccVars.UndoDont = true;
					if (List.Count > 0)
					{
						Points.AddRange(List);
					}
					if (!flag2)
					{
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
						list2.Add(Points);
						Points = new List<Point3D>();
					}
					flag = flag2;
					pt = new Point3D(point3D.X, point3D.Y, point3D.Z);
				}
				if (list2.Count <= 0)
				{
					continue;
				}
				if (varTuftingSettings.SpiralInOutDirection == InOutDirection.OutsideToInside)
				{
					for (int num8 = 0; num8 <= list2.Count - 1; num8++)
					{
						list2[num8].Reverse();
					}
					list2.Reverse();
				}
				for (int num9 = 0; num9 <= list2.Count - 1; num9++)
				{
					ccVars.UndoDont = true;
					clsInit.cVector5.GetAvailableGroupIndex(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref GroupIndex);
					clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
					LinearPath linearPath2 = new LinearPath(list2[num9]);
					linearPath2.EntityData = new CustomData();
					string entityName = "Tufting" + TuftCounter;
					CreateTuftEntity(linearPath2, name, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftFill", SequenceID, GroupIndex);
				}
			}
			clsInit.appCommand.Reset();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsFiles.SaveParameter();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[24];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doWireframeTrace()
	{
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected O, but got Unknown
		try
		{
			int groupID = -1;
			int SequenceID = -1;
			varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			string name = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Layers[i].Tufting.isDirectionArrow)
				{
					varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[i].Name;
				}
			}
			SelectionOption option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
			List<Entity> selectedEntities = new List<Entity>();
			clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
			clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			Point3D refPoint = new Point3D();
			if (selectedEntities[0] is ICurve)
			{
				refPoint = buVector5.ToPoint3D(((ICurve)selectedEntities[0]).StartPoint);
			}
			List<EntitiesGroup> Groups = new List<EntitiesGroup>();
			clsInit.cVector5.FindEntitiesGroupFromEntities(refPoint, selectedEntities, Plane.XY, ref Groups);
			for (int j = 0; j <= Groups.Count - 1; j++)
			{
				List<Entity> copiedEnt = new List<Entity>();
				List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
				buVector5.CopyEntities(Groups[j].Outside, ref copiedEnt);
				buVector5.CopyEntities(Groups[j].Inside, ref copiedEnt2);
				clsInit.appCommand.undoBuffer();
				if (varTuftingSettings.TraceOutterEnable)
				{
					List<Entity> LastCalcEntities = new List<Entity>();
					ContourOperation(AddTuftingEntity: true, varTuftingSettings.TraceOutterOffset, 1, CamClosedContourType.Inner, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, BorderConnect: false, name, copiedEnt, ref LastCalcEntities);
					copiedEnt.Clear();
					buVector5.CopyEntities(LastCalcEntities, ref copiedEnt);
					LastCalcEntities.Clear();
				}
				if (varTuftingSettings.TraceInnerEnable & (copiedEnt2.Count > 0))
				{
					List<List<Entity>> list = new List<List<Entity>>();
					for (int k = 0; k <= copiedEnt2.Count - 1; k++)
					{
						List<Entity> LastCalcEntities2 = new List<Entity>();
						ContourOperation(AddTuftingEntity: true, varTuftingSettings.TraceInnerOffset, 1, CamClosedContourType.Outter, ClockDirectionType.CW, tuftingBorderOffsetType.Contour, BorderConnect: false, name, copiedEnt2[k], ref LastCalcEntities2);
						list.Add(LastCalcEntities2);
					}
					copiedEnt2.Clear();
					buVector5.CopyEntities(list, ref copiedEnt2);
					list.Clear();
				}
				camTp camTp2 = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
				ccVars.toolActive.Geometry.Diameter = varTuftingSettings.TraceRowSpace;
				mWCalculationOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.DontShowDialogBox = true;
				mWCalculationOptions.isBuSort = false;
				mWCalculationOptions.UseStartPoint = false;
				mWCalculationOptions.UseConstantStartPoint = true;
				mWCalculationOptions.StartPointX = 0.0;
				mWCalculationOptions.StartPointY = 0.0;
				mWCalculationOptions.HeightFromEntities = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
				buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = varTuftingSettings.StraightRowSpace;
				buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = varTuftingSettings.StraightAngle;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtOffset;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = varTuftingSettings.CutTolerance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
				buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = true;
				buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = varTuftingSettings.MaxDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = true;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = varTuftingSettings.MinDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = varTuftingSettings.SharpCorner;
				PercentOrValueParameter val = new PercentOrValueParameter(Unit.Metric, true);
				val.Percent = 50.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = val;
				if (!varTuftingSettings.TraceConnection)
				{
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				}
				else
				{
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
					if (varTuftingSettings.TraceSplineConnection & !varTuftingSettings.TraceConnectOneBefore)
					{
						((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
						((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
					}
				}
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
				clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
				List<Entity> selectedEntities2 = new List<Entity>();
				option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
				new SortResult();
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities2);
				clsInit.cVector5.BoxSizeCalculate(selectedEntities2, ref MinPoint, ref MidPoint, ref MaxPoint);
				ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
				ccVars.toolActive.Geometry.Diameter = varTuftingSettings.TraceRowSpace * 2.0;
				double num = MaxPoint.Y - MinPoint.Y;
				num -= ccVars.toolActive.Geometry.Diameter;
				double num2 = Math.Round(num / varTuftingSettings.TraceRowSpace, 0);
				mWCalculationOptions.WireframeRoughtStepOverParaelelOverride = num / (num2 - 1.0);
				camTp2 = new camTp();
				camResult Result = null;
				clsMW.CamEntities.Clear();
				clsMW.CamEntitiesGroup.Clear();
				mWCalculationOptions.UseSortedAndSplitedEntities = false;
				if (!((copiedEnt.Count > 0) & (copiedEnt2.Count > 0)))
				{
					buVector5.CopyEntities(copiedEnt, ref clsMW.CamEntities);
				}
				else
				{
					mWCalculationOptions.UseSortedAndSplitedEntities = true;
					clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt));
					for (int l = 0; l <= copiedEnt2.Count - 1; l++)
					{
						clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(copiedEnt2[l]));
					}
				}
				clsInit.appMW.doWireframeContour(mWCalculationOptions, ccVars.toolActive, ref camTp2, ref Result);
				buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
				List<Point3D> Points = new List<Point3D>();
				for (int m = 0; m <= camTp2.EntitiesG1.Count - 1; m++)
				{
					ICurve curve = camTp2.EntitiesG1[m] as ICurve;
					if (curve.StartPoint.Z != 0.0)
					{
						continue;
					}
					if ((varTuftingSettings.TraceConnectOneBefore & varTuftingSettings.TraceConnection) && ((camTp2.EntitiesG1[m] is buLinearPathCam) & (m < camTp2.EntitiesG1.Count - 1)))
					{
						buLinearPathCam buLinearPathCam2 = camTp2.EntitiesG1[m] as buLinearPathCam;
						buLinearPathCam buLinearPathCam3 = null;
						if (camTp2.EntitiesG1[m + 1] is buLinearPathCam)
						{
							buLinearPathCam3 = camTp2.EntitiesG1[m + 1] as buLinearPathCam;
							if (buLinearPathCam3.isLink & (buLinearPathCam3.LinkType == CamLinkType.ConnectionNotClearanceArea) & (buLinearPathCam2.Vertices[0].Z == 0.0) & (buLinearPathCam3.Vertices[0].Z == 0.0))
							{
								ICurve curve2 = buLinearPathCam2;
								ICurve lower = null;
								ICurve upper = null;
								curve2.SplitAt(curve2.Length() - varTuftingSettings.TraceRowSpace, out lower, out upper);
								if (lower != null && upper != null)
								{
									if (buCompare5.EQ(lower.Length(), varTuftingSettings.TraceRowSpace))
									{
										camTp2.EntitiesG1[m] = new buLinearPathCam((LinearPath)upper.Clone());
										camTp2.EntitiesG1[m + 1].Vertices[0] = buVector5.ToPoint3D(upper.EndPoint);
									}
									if (buCompare5.EQ(upper.Length(), varTuftingSettings.TraceRowSpace))
									{
										camTp2.EntitiesG1[m] = new buLinearPathCam((LinearPath)lower.Clone());
										camTp2.EntitiesG1[m + 1].Vertices[0] = buVector5.ToPoint3D(lower.EndPoint);
										camTp2.EntitiesG1[m + 1].Regen(buSystem.RegenDeviation);
									}
								}
							}
						}
						if ((buLinearPathCam2.isLink & (buLinearPathCam2.LinkType == CamLinkType.ConnectionNotClearanceArea)) && buLinearPathCam3 != null)
						{
							double num3 = Point3D.Distance(camTp2.EntitiesG1[m].Vertices[0], camTp2.EntitiesG1[m].Vertices[camTp2.EntitiesG1[m].Vertices.Length - 1]);
							buLinearPathCam buLinearPathCam4 = new buLinearPathCam((buLinearPathCam)camTp2.EntitiesG1[m - 1]);
							Point3D EndPnt = new Point3D();
							Point3D EndPnt2 = new Point3D();
							double num4 = clsInit.cVector5.PointAngle(buLinearPathCam3.Vertices[1], buLinearPathCam3.Vertices[0], Plane.XY);
							clsInit.cVector5.LineWithLengthAndAngle(buLinearPathCam3.Vertices[0], num3 * 0.2, num4 + 180.0, ref EndPnt);
							num4 = clsInit.cVector5.PointAngle(buLinearPathCam4.Vertices[buLinearPathCam4.Vertices.Length - 2], buLinearPathCam4.Vertices[buLinearPathCam4.Vertices.Length - 1], Plane.XY);
							clsInit.cVector5.LineWithLengthAndAngle(buLinearPathCam4.Vertices[buLinearPathCam4.Vertices.Length - 1], num3 * 0.2, num4 + 180.0, ref EndPnt2);
							List<Point3D> list2 = new List<Point3D>();
							Point3D pnt = clsInit.cVector5.MiddlePointOfLine(camTp2.EntitiesG1[m].Vertices[0], camTp2.EntitiesG1[m].Vertices[camTp2.EntitiesG1[m].Vertices.Length - 1]);
							list2.Add(buVector5.ToPoint3D(camTp2.EntitiesG1[m].Vertices[0]));
							list2.Add(buVector5.ToPoint3D(EndPnt2));
							list2.Add(buVector5.ToPoint3D(pnt));
							list2.Add(buVector5.ToPoint3D(EndPnt));
							list2.Add(buVector5.ToPoint3D(camTp2.EntitiesG1[m].Vertices[camTp2.EntitiesG1[m].Vertices.Length - 1]));
							Curve curve3 = new Curve(2, list2);
							curve3.Regen(0.01);
							camTp2.EntitiesG1[m] = new buLinearPathCam(curve3.Vertices);
						}
					}
					if (Points.Count != 0)
					{
						if (!buCompare5.EQ(Points[Points.Count - 1], camTp2.EntitiesG1[m].Vertices[0], buSystem.resolutionCompare))
						{
							clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
							clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
							ccVars.UndoDont = true;
							Entity entity = new LinearPath(Points);
							entity.EntityData = new CustomData();
							if (entity != null)
							{
								string entityName = "Tufting" + TuftCounter;
								CreateTuftEntity(entity, name, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftFill", SequenceID, groupID);
								Points.Clear();
								Points = new List<Point3D>();
								buVector5.VerticeToPointsListAdd(camTp2.EntitiesG1[m].Vertices, ref Points);
							}
						}
						else
						{
							buVector5.VerticeToPointsListAdd(camTp2.EntitiesG1[m].Vertices, ref Points);
						}
					}
					else
					{
						buVector5.VerticeToPointsListAdd(camTp2.EntitiesG1[m].Vertices, ref Points);
					}
				}
				if (Points.Count > 0)
				{
					clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
					clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
					ccVars.UndoDont = true;
					Entity entity2 = new LinearPath(Points);
					entity2.EntityData = new CustomData();
					if (entity2 != null)
					{
						string entityName2 = "Tufting" + TuftCounter;
						CreateTuftEntity(entity2, name, ccVars.Pages[ccVars.PageIndex].SceneName, entityName2, "TuftFill", SequenceID, groupID);
					}
				}
			}
			clsInit.appCommand.Reset();
			clsFiles.SaveParameter();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[23];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doWireframeCounter()
	{
		try
		{
			varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			string name = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Layers[i].Tufting.isDirectionArrow)
				{
					varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[i].Name;
				}
			}
			SelectionOption option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
			List<Entity> selectedEntities = new List<Entity>();
			clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
			clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			Point3D refPoint = new Point3D();
			if (selectedEntities[0] is ICurve)
			{
				refPoint = buVector5.ToPoint3D(((ICurve)selectedEntities[0]).StartPoint);
			}
			List<EntitiesGroup> Groups = new List<EntitiesGroup>();
			clsInit.cVector5.FindEntitiesGroupFromEntities(refPoint, selectedEntities, Plane.XY, ref Groups);
			for (int j = 0; j <= Groups.Count - 1; j++)
			{
				List<Entity> copiedEnt = new List<Entity>();
				List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
				buVector5.CopyEntities(Groups[j].Outside, ref copiedEnt);
				buVector5.CopyEntities(Groups[j].Inside, ref copiedEnt2);
				clsInit.appCommand.undoBuffer();
				if (varTuftingSettings.ContourOutBorderEnable)
				{
					List<Entity> LastCalcEntities = new List<Entity>();
					ContourOperation(AddTuftingEntity: true, varTuftingSettings.ContourOutterOffset, varTuftingSettings.ContourOutBorderCount, CamClosedContourType.Inner, varTuftingSettings.ContourOutBorderFillDirection, varTuftingSettings.ContourOutBorderType, varTuftingSettings.ContourOutBorderConnect, name, copiedEnt, ref LastCalcEntities);
					copiedEnt.Clear();
					buVector5.CopyEntities(LastCalcEntities, ref copiedEnt);
					LastCalcEntities.Clear();
				}
				if (varTuftingSettings.ContourInBorderEnable & (copiedEnt2.Count > 0))
				{
					List<List<Entity>> list = new List<List<Entity>>();
					for (int k = 0; k <= copiedEnt2.Count - 1; k++)
					{
						List<Entity> LastCalcEntities2 = new List<Entity>();
						ContourOperation(AddTuftingEntity: true, varTuftingSettings.ContourInnerOffset, varTuftingSettings.ContourInBorderCount, CamClosedContourType.Outter, varTuftingSettings.ContourInBorderFillDirection, varTuftingSettings.ContourInBorderType, varTuftingSettings.ContourInBorderConenct, name, copiedEnt2[k], ref LastCalcEntities2);
						list.Add(LastCalcEntities2);
					}
					copiedEnt2.Clear();
					buVector5.CopyEntities(list, ref copiedEnt2);
					list.Clear();
				}
			}
			clsInit.appCommand.Reset();
			clsFiles.SaveParameter();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[23];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doRandomPattern()
	{
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		try
		{
			List<Entity> list = new List<Entity>();
			F_TuftingRandomPattern f_TuftingRandomPattern = new F_TuftingRandomPattern();
			f_TuftingRandomPattern.Settings = new TuftingSettings(varTuftingSettings);
			f_TuftingRandomPattern.Init();
			f_TuftingRandomPattern.ShowDialog();
			if (f_TuftingRandomPattern.PropertiesForm.Result != DialogResult.OK)
			{
				return;
			}
			varTuftingSettings = new TuftingSettings(f_TuftingRandomPattern.Settings);
			int num = 0;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Layers[i].Name.IndexOf("T_") >= 0)
				{
					num++;
				}
			}
			if (num >= varTuftingSettings.RandomPatternColorNumber)
			{
				int SequenceID = -1;
				varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
				string name = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Layers[j].Tufting.isDirectionArrow)
					{
						varTuftingRunSettings.ArrowDirLayerName = ccVars.Pages[ccVars.PageIndex].Layers[j].Name;
					}
				}
				SelectionOption option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
				List<Entity> selectedEntities = new List<Entity>();
				clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
				Point3D refPoint = new Point3D();
				if (selectedEntities[0] is ICurve)
				{
					refPoint = buVector5.ToPoint3D(((ICurve)selectedEntities[0]).StartPoint);
				}
				List<Entity> OutsideEntities = new List<Entity>();
				List<List<Entity>> InsideEntities = new List<List<Entity>>();
				List<List<Entity>> NotInsideEntities = new List<List<Entity>>();
				clsInit.cVector5.FindOutsideAndInsidentitiesFromEntities(refPoint, selectedEntities, Plane.XY, ref OutsideEntities, ref InsideEntities, ref NotInsideEntities);
				clsInit.appCommand.undoBuffer();
				if (varTuftingSettings.StraightOutBorderEnable)
				{
					List<Entity> LastCalcEntities = new List<Entity>();
					ContourOperation(AddTuftingEntity: true, varTuftingSettings.StraightOutterOffset, varTuftingSettings.StraightOutBorderCount, CamClosedContourType.Inner, varTuftingSettings.StraightOutBorderFillDirection, varTuftingSettings.StraightOutBorderType, varTuftingSettings.StraightOutBorderConnect, name, OutsideEntities, ref LastCalcEntities);
					OutsideEntities.Clear();
					buVector5.CopyEntities(LastCalcEntities, ref OutsideEntities);
					LastCalcEntities.Clear();
				}
				if (varTuftingSettings.StraightInBorderEnable & (InsideEntities.Count > 0))
				{
					List<List<Entity>> list2 = new List<List<Entity>>();
					for (int k = 0; k <= InsideEntities.Count - 1; k++)
					{
						List<Entity> LastCalcEntities2 = new List<Entity>();
						ContourOperation(AddTuftingEntity: true, varTuftingSettings.StraightInnerOffset, varTuftingSettings.StraightInBorderCount, CamClosedContourType.Outter, varTuftingSettings.StraightInBorderFillDirection, varTuftingSettings.StraightInBorderType, varTuftingSettings.StraightInBorderConenct, name, InsideEntities[k], ref LastCalcEntities2);
						list2.Add(LastCalcEntities2);
					}
					InsideEntities.Clear();
					buVector5.CopyEntities(list2, ref InsideEntities);
					list2.Clear();
				}
				camTp camTp2 = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
				ccVars.toolActive.Geometry.Diameter = varTuftingSettings.StraightRowSpace * 2.0;
				mWCalculationOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.DontShowDialogBox = true;
				mWCalculationOptions.isBuSort = false;
				mWCalculationOptions.UseStartPoint = false;
				mWCalculationOptions.UseConstantStartPoint = true;
				mWCalculationOptions.StartPointX = 0.0;
				mWCalculationOptions.StartPointY = 0.0;
				mWCalculationOptions.HeightFromEntities = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeZigzag;
				if (!varTuftingSettings.StraightRowLink)
				{
					buMWTuftingVars.varCamRough.mwPar.MachParam.CurMachType = MachiningParamsMachType.MachtypeOneway;
				}
				buMWTuftingVars.varCamRough.mwPar.MachParam.MaxStepoverDistance = varTuftingSettings.StraightRowSpace;
				buMWTuftingVars.varCamRough.mwPar.MachParam.ParallelMachAngleInYX = varTuftingSettings.StraightAngle;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.RoughType = WireframeBasedTpCalcParamsRoughType.WfbRghtParallel;
				buMWTuftingVars.varCamRough.mwPar.MachParam.CutTolerance = varTuftingSettings.CutTolerance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
				buMWTuftingVars.varCamRough.mwPar.MachParam.DistanceFlag = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.Distance = varTuftingSettings.MaxDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = 1.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = varTuftingSettings.MinDistance;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = varTuftingSettings.SharpCorner;
				PercentOrValueParameter val = new PercentOrValueParameter(Unit.Metric, true);
				val.Percent = 50.0;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength = val;
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
				if (varTuftingSettings.LinkAsSpline)
				{
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
				}
				if (!varTuftingSettings.StraightRowLink)
				{
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
					((InterlinkHandeler)buMWTuftingVars.varCamRough.mwPar.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
				}
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
				buMWTuftingVars.varCamRough.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
				clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWTuftingVars.varCamRough.mwPar, buMWTuftingVars.varCamRough.buPar, out clsMW.varbuCamWFPocketPars);
				List<Entity> selectedEntities2 = new List<Entity>();
				option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
				new SortResult();
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
				clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities2);
				clsInit.cVector5.BoxSizeCalculate(selectedEntities2, ref MinPoint, ref MidPoint, ref MaxPoint);
				double num2 = MaxPoint.Y - MinPoint.Y;
				num2 -= ccVars.toolActive.Geometry.Diameter;
				double num3 = Math.Round(num2 / varTuftingSettings.StraightRowSpace, 0);
				mWCalculationOptions.WireframeRoughtStepOverParaelelOverride = num2 / (num3 - 1.0);
				camTp2 = new camTp();
				camResult Result = null;
				clsMW.CamEntities.Clear();
				clsMW.CamEntitiesGroup.Clear();
				mWCalculationOptions.UseSortedAndSplitedEntities = false;
				if (!((OutsideEntities.Count > 0) & (InsideEntities.Count > 0)))
				{
					buVector5.CopyEntities(OutsideEntities, ref clsMW.CamEntities);
				}
				else
				{
					mWCalculationOptions.UseSortedAndSplitedEntities = true;
					clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(OutsideEntities));
					for (int l = 0; l <= InsideEntities.Count - 1; l++)
					{
						clsMW.CamEntitiesGroup.Add(buVector5.CopyEntities(InsideEntities[l]));
					}
				}
				clsInit.appMW.doWireframeContour(mWCalculationOptions, ccVars.toolActive, ref camTp2, ref Result);
				buMWTuftingVars.varCamRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWTuftingVars.varCamRough.buPar);
				for (int m = 0; m <= camTp2.EntitiesG1.Count - 1; m++)
				{
					ICurve curve = camTp2.EntitiesG1[m] as ICurve;
					if (curve.StartPoint.Z != 0.0)
					{
						continue;
					}
					clsInit.cTuft.GetAvailableSequenceID(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref SequenceID);
					ccVars.UndoDont = true;
					Entity EyeEntity = null;
					buConversion5.EyeCamEntityToEyeEntity(camTp2.EntitiesG1[m], ref EyeEntity);
					if (EyeEntity == null)
					{
						continue;
					}
					for (int n = 1; n <= EyeEntity.Vertices.Length - 1; n++)
					{
						if (buCompare5.EQ(EyeEntity.Vertices[n - 1].Y, EyeEntity.Vertices[n].Y, 0.01))
						{
							Line line = new Line(EyeEntity.Vertices[n - 1], EyeEntity.Vertices[n]);
							line.EntityData = new CustomData();
							list.Add(line);
						}
					}
				}
				if (list.Count > 0)
				{
					int num4 = 0;
					int num5 = 0;
					string LayerName = "";
					GetLayerNameFRomActiveColor(varTuftingSettings.RandomPatternColorNumber + 1, ref LayerName);
					Random random = new Random();
					for (int num6 = 0; num6 <= list.Count - 1; num6++)
					{
						string LayerName2 = "";
						ICurve curve2 = list[num6] as ICurve;
						if (num4 % varTuftingSettings.RandomPatternColorLineNumber == 0)
						{
							num5++;
							if (num5 > varTuftingSettings.RandomPatternColorNumber)
							{
								num5 = 1;
							}
						}
						double num7 = random.NextDouble();
						if (num7 < 0.1)
						{
							num7 = 0.1;
						}
						if (num7 > 0.9)
						{
							num7 = 0.9;
						}
						GetLayerNameFRomActiveColor(num5, ref LayerName2);
						double num8 = Point3D.Distance(curve2.StartPoint, curve2.EndPoint);
						double num9 = 1.0 - num7;
						double x = curve2.StartPoint.X;
						double x2 = curve2.EndPoint.X;
						if (curve2.EndPoint.X < x)
						{
							x = curve2.EndPoint.X;
							x2 = curve2.StartPoint.X;
						}
						Point3D pnt = new Point3D(x, curve2.StartPoint.Y, 0.0);
						Point3D pnt2 = new Point3D(x + num8 * (num9 / 2.0), curve2.StartPoint.Y, 0.0);
						Point3D pnt3 = new Point3D(x + num8 - num8 * (num9 / 2.0), curve2.StartPoint.Y, 0.0);
						Point3D pnt4 = new Point3D(x2, curve2.StartPoint.Y, 0.0);
						List<Point3D> list3 = new List<Point3D>();
						list3.Add(buVector5.ToPoint3D(pnt2));
						list3.Add(buVector5.ToPoint3D(pnt3));
						LinearPath linearPath = new LinearPath(list3);
						CustomData entityData = new CustomData((CustomData)list[num6].EntityData);
						linearPath.EntityData = entityData;
						CreateTuftEntity(linearPath, LayerName2);
						list3 = new List<Point3D>();
						list3.Add(buVector5.ToPoint3D(pnt));
						list3.Add(buVector5.ToPoint3D(pnt2));
						linearPath = new LinearPath(list3);
						entityData = new CustomData((CustomData)list[num6].EntityData);
						linearPath.EntityData = entityData;
						CreateTuftEntity(linearPath, LayerName);
						list3 = new List<Point3D>();
						list3.Add(buVector5.ToPoint3D(pnt3));
						list3.Add(buVector5.ToPoint3D(pnt4));
						linearPath = new LinearPath(list3);
						entityData = new CustomData((CustomData)list[num6].EntityData);
						linearPath.EntityData = entityData;
						CreateTuftEntity(linearPath, LayerName);
						num4++;
					}
				}
				clsInit.appCommand.Reset();
				clsFiles.SaveParameter();
			}
			else
			{
				buString5.MessageBoxWarning(buTufting.LangTuftingMessage[6]);
				clsInit.appCommand.Reset();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[23];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doDeletePattern()
	{
		try
		{
			if (buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[88]) != DialogResult.Yes)
			{
				return;
			}
			List<string> list = new List<string>();
			for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
			{
				int index = ccVars.SelectionOP.Selections[i].Index;
				list.Add(((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData).EntityName);
			}
			DeleteArrowAndMarkerByReleatedEntityName(list);
			for (int j = 0; j <= list.Count - 1; j++)
			{
				for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k];
					CustomData customData = entity.EntityData as CustomData;
					if ((customData.EntityName == list[j]) & (customData.typeDefination == entityTypeDefination.Tufting))
					{
						clsInit.appCommand.OsnapDeleteByEntityName(customData.EntityName);
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.Reset();
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[28];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doDeleteSorted()
	{
		try
		{
			if (buString5.MessageBoxQuestion(buTufting.LangTuftingMessage[0]) != DialogResult.Yes)
			{
				return;
			}
			List<string> list = new List<string>();
			for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
			{
				int index = ccVars.SelectionOP.Selections[i].Index;
				list.Add(((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData).EntityName);
			}
			DeleteArrowAndMarkerByReleatedEntityName(list);
			for (int j = 0; j <= list.Count - 1; j++)
			{
				for (int num = buTuftingCalc.Sorted.Count - 1; num >= 0; num--)
				{
					for (int num2 = buTuftingCalc.Sorted[num].SortedEntities.Count - 1; num2 >= 0; num2--)
					{
						CustomData customData = buTuftingCalc.Sorted[num].SortedEntities[num2].EntityData as CustomData;
						if (customData.EntityName == list[j])
						{
							buTuftingCalc.Sorted[num].SortedEntities.RemoveAt(num2);
							num2 = 0;
						}
					}
					if (buTuftingCalc.Sorted[num].SortedEntities.Count == 0)
					{
						buTuftingCalc.Sorted.RemoveAt(num);
					}
				}
			}
			for (int k = 0; k <= list.Count - 1; k++)
			{
				for (int l = 0; l <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; l++)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l];
					if (entity.ColorMethod == colorMethodType.byEntity)
					{
						CustomData customData2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l].EntityData as CustomData;
						if ((customData2.typeDefination == entityTypeDefination.Tufting) & customData2.CamSelected & (list[k] == customData2.EntityName))
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l].ColorMethod = colorMethodType.byLayer;
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l].LineWeightMethod = colorMethodType.byLayer;
							((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l].EntityData).CamSelected = false;
						}
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[29];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doDeleteAllPattern()
	{
		try
		{
			if (buString5.MessageBoxQuestion(AppLanguage.CadCamMessages[88]) != DialogResult.Yes)
			{
				return;
			}
			List<string> list = new List<string>();
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
				if (customData.typeDefination == entityTypeDefination.Tufting)
				{
					list.Add(customData.EntityName);
				}
			}
			DeleteArrowAndMarkerByReleatedEntityName(list);
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j];
				CustomData customData2 = entity.EntityData as CustomData;
				if (customData2.typeDefination == entityTypeDefination.Tufting)
				{
					clsInit.appCommand.OsnapDeleteByEntityName(customData2.EntityName);
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Selected = true;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[30];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doDeleteAllSorted()
	{
		try
		{
			if (buString5.MessageBoxQuestion(buTufting.LangTuftingMessage[0]) != DialogResult.Yes)
			{
				return;
			}
			buTuftingCalc.Sorted.Clear();
			new List<string>();
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
				if ((customData.typeDefination == entityTypeDefination.DirectionArrow) | (customData.typeDefination == entityTypeDefination.EndMarker) | (customData.typeDefination == entityTypeDefination.StartMarker))
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j];
				if (entity.ColorMethod != colorMethodType.byEntity)
				{
					continue;
				}
				CustomData customData2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData as CustomData;
				if ((customData2.typeDefination == entityTypeDefination.Tufting) & customData2.CamSelected)
				{
					if (!((customData2.tuftingMode == tuftingStitchModeType.None) & (customData2.tuftingPileHeight == 0.0) & (customData2.tuftingStitchLength == 0.0)))
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LineWeight = (float)varTuftingSettings.DefinationEntityThickness;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].ColorMethod = colorMethodType.byEntity;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LineWeightMethod = colorMethodType.byEntity;
					}
					else
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].ColorMethod = colorMethodType.byLayer;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LineWeightMethod = colorMethodType.byLayer;
					}
					((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData).CamSelected = false;
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[31];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doSortAll()
	{
		Color LayerColor = Color.White;
		double LayerThickness = 1.0;
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
		{
			List<Entity> sortingEntities = new List<Entity>();
			if (ccVars.Pages[ccVars.PageIndex].Layers[i].Name.IndexOf("T_") < 0)
			{
				continue;
			}
			clsInit.cVector5.GetLayerColorAndThicknessByLayerName(ccVars.Pages[ccVars.PageIndex].Layers[i].Name, ccVars.Pages[ccVars.PageIndex].Layers, ref LayerColor, ref LayerThickness);
			if (LayerThickness < 1.0)
			{
				LayerThickness = 1.0;
			}
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j];
				clsInit.cVector5.GetEntityCustomData(entity);
				if (entity.LayerName.Trim() == ccVars.Pages[ccVars.PageIndex].Layers[i].Name.Trim())
				{
					Entity item = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j]);
					sortingEntities.Add(item);
				}
			}
			if (sortingEntities.Count > 0)
			{
				varTuftingSettings.SortAutoNextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
				SortEntities(ref sortingEntities, LayerColor, LayerThickness, ccVars.Pages[ccVars.PageIndex].Layers[i].Name, new List<Entity>());
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			}
		}
	}

	public void doSortPattern()
	{
		try
		{
			List<Entity> sortingEntities = new List<Entity>();
			List<Entity> sortingEntities2 = new List<Entity>();
			Color LayerColor = Color.White;
			double LayerThickness = 1.0;
			clsInit.cVector5.GetLayerColorAndThicknessByLayerName(varTuftingRunSettings.SelectedLayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref LayerColor, ref LayerThickness);
			if (LayerThickness < 1.0)
			{
				LayerThickness = 1.0;
			}
			if (varTuftingSettings.SortType != tuftingSelectionModeType.Auto)
			{
				return;
			}
			if (varTuftingSettings.SortOutlineFirst)
			{
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
					CustomData entityCustomData = clsInit.cVector5.GetEntityCustomData(entity);
					if (entity.LayerName.Trim() == varTuftingRunSettings.SelectedLayerName.Trim() && ((entityCustomData.ActionName == "TuftOutline") & clsInit.cTuft.isSameLayerTuftOrOutline(varTuftingRunSettings.SelectedLayerName, entity.LayerName)))
					{
						Entity item = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]);
						sortingEntities.Add(item);
					}
				}
				if (sortingEntities.Count > 0)
				{
					SortEntities(ref sortingEntities, LayerColor, LayerThickness, varTuftingRunSettings.SelectedLayerName, new List<Entity>());
				}
			}
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j];
				CustomData entityCustomData2 = clsInit.cVector5.GetEntityCustomData(entity2);
				if (entity2.LayerName.Trim() == varTuftingRunSettings.SelectedLayerName.Trim() && ((entityCustomData2.ActionName == "TuftFill") & clsInit.cTuft.isSameLayerTuftOrOutline(varTuftingRunSettings.SelectedLayerName, entity2.LayerName)))
				{
					Entity item2 = buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j]);
					sortingEntities2.Add(item2);
				}
			}
			if (sortingEntities2.Count > 0)
			{
				SortEntities(ref sortingEntities2, LayerColor, LayerThickness, varTuftingRunSettings.SelectedLayerName, new List<Entity>());
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[32];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doSortManuel()
	{
		Color LayerColor = Color.White;
		double LayerThickness = 1.0;
		if (ccVars.SortedEntities.Count == 0)
		{
			return;
		}
		varTuftingRunSettings.SelectedLayerName = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
		if (varTuftingRunSettings.SelectedLayerName != ccVars.SortedEntities[0].LayerName)
		{
			if (!(ccVars.SortedEntities[0] is buUpperLineEnt))
			{
				varTuftingRunSettings.SelectedLayerName = ccVars.SortedEntities[0].LayerName;
			}
			else if (ccVars.SortedEntities.Count >= 2)
			{
				varTuftingRunSettings.SelectedLayerName = ccVars.SortedEntities[1].LayerName;
			}
		}
		clsInit.cVector5.GetLayerColorAndThicknessByLayerName(varTuftingRunSettings.SelectedLayerName, ccVars.Pages[ccVars.PageIndex].Layers, ref LayerColor, ref LayerThickness);
		if (LayerThickness < 1.0)
		{
			LayerThickness = 1.0;
		}
		if (ccVars.SortedEntities.Count > 0)
		{
			List<Entity> sortingEntities = new List<Entity>();
			SortEntities(ref sortingEntities, LayerColor, LayerThickness, varTuftingRunSettings.SelectedLayerName, ccVars.SortedEntities);
			clsInit.appCommand.Reset();
		}
	}

	public void doChangeDirection()
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
			{
				int index = ccVars.SelectionOP.Selections[i].Index;
				list.Add(((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData).EntityName);
			}
			DeleteArrowAndMarkerByReleatedEntityName(list);
			AddArrowAndMarkerEntitiesFromName(ReverseDir: true, list);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.Reset();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[26];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doExchangeSelection()
	{
		try
		{
			List<string> list = new List<string>();
			for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
			{
				int index = ccVars.SelectionOP.Selections[i].Index;
				list.Add(((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData).EntityName);
			}
			DeleteArrowAndMarkerByReleatedEntityName(list);
			string name = ccVars.Pages[ccVars.PageIndex].Layers[varTuftingRunSettings.SelectedLayerIndex].Name;
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Layers[j].Tufting.isDirectionArrow)
				{
					name = ccVars.Pages[ccVars.PageIndex].Layers[j].Name;
				}
			}
			for (int k = 0; k <= list.Count - 1; k++)
			{
				for (int l = 0; l <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; l++)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l];
					if (!(((CustomData)entity.EntityData).EntityName == list[k]))
					{
						continue;
					}
					LinearPath linearPath = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l] as LinearPath;
					linearPath.Reverse();
					int refEntity = l;
					if (!clsVar.varInterface5.DirectionArrowSettings.Enable)
					{
						continue;
					}
					List<buLinearPathArrow> DirArrows = new List<buLinearPathArrow>();
					clsInit.cVector5.DirectionArrowFromEntities(linearPath, clsVar.varInterface5.DirectionArrowSettings, ref DirArrows);
					if (DirArrows.Count > 0)
					{
						for (int m = 0; m <= DirArrows.Count - 1; m++)
						{
							ccVars.UndoDont = true;
							DirArrows[m].EntityData = new CustomData();
							DirArrows[m].LayerName = name;
							DirArrows[m].Selectable = false;
							DirArrows[m].RefEntity = refEntity;
							clsInit.appCommand.AddEntity(DirArrows[m]);
						}
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.Reset();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[27];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doGetClosedArea(Point3D refPoint)
	{
		try
		{
			List<Entity> list = new List<Entity>();
			List<Entity> list2 = new List<Entity>();
			bool flag = false;
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				Entity copiedEntity = null;
				buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
				copiedEntity.EntityData = new CustomData((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData);
				list.Add(copiedEntity);
			}
			List<PointAndAngleRange> list3 = new List<PointAndAngleRange>();
			List<int> List = new List<int>();
			List<PointAndIndex> touchDomainPoints = new List<PointAndIndex>();
			for (double num = 0.0; num <= 360.0; num += 20.0)
			{
				Point3D EndPnt = new Point3D();
				clsInit.cVector5.LineWithLengthAndAngle(refPoint, 10000.0, num, ref EndPnt);
				Line entityIntersect = new Line(refPoint, EndPnt);
				List<Point3D> pntIntersect = new List<Point3D>();
				new List<int>();
				PointAndAngleRange pntRange = new PointAndAngleRange();
				int EntityIndex = -1;
				if (clsInit.cVector5.GetClosestIntersectPointsFromEntities(list, entityIntersect, refPoint, num, ref pntIntersect, ref pntRange, ref EntityIndex, ref touchDomainPoints) & (pntRange.AngleMin != pntRange.AngleMax))
				{
					if (EntityIndex >= 0)
					{
						buNumeric5.AddValueToList(EntityIndex, ref List);
					}
					list3.Add(pntRange);
					Line item = new Line(refPoint, pntRange.refPoint);
					list2.Add(item);
				}
			}
			List<int> list4 = new List<int>();
			if (List.Count > 0)
			{
				List<Entity> BaseRefEntities = new List<Entity>();
				for (int j = 0; j <= List.Count - 1; j++)
				{
					Entity copiedEntity2 = null;
					buEntity.Copy(list[List[j]], ref copiedEntity2);
					if (copiedEntity2.Vertices == null)
					{
						clsInit.cVector5.RegenEntity(buSystem.RegenDeviation, ref copiedEntity2);
					}
					BaseRefEntities.Add(copiedEntity2);
				}
				SortSettings sortSettings = new SortSettings();
				SortResult Result = new SortResult();
				List<Entity> SortedEntities = new List<Entity>();
				sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
				sortSettings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
				clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].Vertices[0], ref BaseRefEntities, sortSettings, ref SortedEntities, ref Result);
				if (clsInit.cVector5.isEntitiesClosed(SortedEntities))
				{
					for (int k = 0; k <= List.Count - 1; k++)
					{
						list4.Add(List[k]);
					}
					flag = true;
				}
			}
			if (!flag)
			{
				for (int l = 1; l <= 20; l++)
				{
					List<PointAndAngleRange> list5 = new List<PointAndAngleRange>();
					for (int m = 0; m <= list3.Count - 1; m++)
					{
						double num2 = (list3[m].AngleMax - 5.0 - (list3[m].AngleMin + 5.0)) / 10.0;
						for (double num3 = list3[m].AngleMin + 5.0; num3 <= list3[m].AngleMax - 5.0; num3 += num2)
						{
							Point3D EndPnt2 = new Point3D();
							clsInit.cVector5.LineWithLengthAndAngle(list3[m].refPoint, 100000.0, num3, ref EndPnt2);
							Line entityIntersect2 = new Line(list3[m].refPoint, EndPnt2);
							List<Point3D> pntIntersect2 = new List<Point3D>();
							new List<int>();
							PointAndAngleRange pntRange2 = new PointAndAngleRange();
							int EntityIndex2 = -1;
							if (clsInit.cVector5.GetClosestIntersectPointsFromEntities(list, entityIntersect2, list3[m].refPoint, num3, ref pntIntersect2, ref pntRange2, ref EntityIndex2, ref touchDomainPoints) & (pntRange2.AngleMax != pntRange2.AngleMin))
							{
								if (EntityIndex2 >= 0)
								{
									buNumeric5.AddValueToList(EntityIndex2, ref List);
								}
								Line item2 = new Line(list3[m].refPoint, pntRange2.refPoint);
								list2.Add(item2);
								list5.Add(pntRange2);
							}
						}
					}
					list3.Clear();
					list3 = new List<PointAndAngleRange>();
					if (list5.Count > 0)
					{
						list5 = clsInit.cVector5.SortByDistance(list5, new PointAndAngleRange());
						for (int n = 0; n <= list5.Count - 1; n++)
						{
							if (n != 0)
							{
								double num4 = Point3D.Distance(list3[list3.Count - 1].refPoint, list5[n].refPoint);
								if (num4 > 50.0)
								{
									list3.Add(new PointAndAngleRange(list5[n]));
								}
							}
							else
							{
								list3.Add(new PointAndAngleRange(list5[n]));
							}
						}
					}
					if (!((l == 1) | (l % 2 == 0)) || List.Count <= 0)
					{
						continue;
					}
					List<Entity> BaseRefEntities2 = new List<Entity>();
					for (int num5 = 0; num5 <= List.Count - 1; num5++)
					{
						Entity copiedEntity3 = null;
						buEntity.Copy(list[List[num5]], ref copiedEntity3);
						if (copiedEntity3.Vertices == null)
						{
							clsInit.cVector5.RegenEntity(buSystem.RegenDeviation, ref copiedEntity3);
						}
						BaseRefEntities2.Add(copiedEntity3);
					}
					SortSettings sortSettings2 = new SortSettings();
					SortResult Result2 = new SortResult();
					List<Entity> SortedEntities2 = new List<Entity>();
					sortSettings2.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
					sortSettings2.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
					clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities2[0].Vertices[0], ref BaseRefEntities2, sortSettings2, ref SortedEntities2, ref Result2);
					if (clsInit.cVector5.isEntitiesClosed(SortedEntities2))
					{
						for (int num6 = 0; num6 <= List.Count - 1; num6++)
						{
							list4.Add(List[num6]);
						}
						l = 100000;
					}
				}
			}
			if (varTuftingSettings.ShowClosedPathCalculationEntities)
			{
				clsInit.appCommand.undoBuffer();
				for (int num7 = 0; num7 <= list2.Count - 1; num7++)
				{
					ccVars.UndoDont = true;
					Entity copiedEntity4 = null;
					buEntity.Copy(list2[num7], ref copiedEntity4);
					copiedEntity4.LayerName = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
					copiedEntity4.Regen(0.01);
					clsInit.appCommand.AddEntity(copiedEntity4);
				}
			}
			list2.Clear();
			clsInit.appCommand.SelectedToSelectionAdd(list4);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[25];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doAnalyseImportEntities()
	{
		ccVars.Pages[ccVars.PageIndex].OsnapPoints.Clear();
		int num = 0;
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; j++)
			{
				if (i != j && (buImage5.isColorSame(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Color, ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[j].Color) & ((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name.ToLower().IndexOf("t_") >= 0) | (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name.ToLower().IndexOf("o_") >= 0))) && ((num >= 0) & (num <= clsVar.ColorList.Count - 1)))
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Color = clsVar.ColorList[num];
					ccVars.Pages[ccVars.PageIndex].Layers[i].LayerColor = clsVar.ColorList[num];
					num++;
				}
			}
		}
		for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].ColorMethod = colorMethodType.byLayer;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LineWeightMethod = colorMethodType.byLayer;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LineTypeMethod = colorMethodType.byLayer;
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].GetType() == typeof(LinearPathEx))
			{
				LinearPath linearPath = new LinearPath(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Vertices);
				linearPath.LayerName = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LayerName;
				linearPath.Color = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Color;
				linearPath.ColorMethod = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].ColorMethod;
				linearPath.LineWeight = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LineWeight;
				linearPath.LineWeightMethod = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LineWeightMethod;
				linearPath.EntityData = new CustomData((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].EntityData);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] = linearPath;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
		ccVars.Pages[ccVars.PageIndex].OsnapPoints.Clear();
		clsInit.appCommand.OsnapCalculationAll();
	}

	public void doBreakAllIntersection()
	{
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			string name = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName != name && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve)
			{
				list.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]));
			}
		}
		List<Entity> list2 = new List<Entity>();
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
		{
			string name2 = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
			if (!(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LayerName == name2))
			{
				continue;
			}
			ICurve curve = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] as ICurve;
			List<Point3D> SortingPoints = new List<Point3D>();
			for (int k = 0; k <= list.Count - 1; k++)
			{
				Point3D[] array = curve.IntersectWith((ICurve)list[k]);
				if ((array != null) & (array.Length != 0))
				{
					SortingPoints.AddRange(array);
				}
			}
			if (SortingPoints.Count <= 0)
			{
				continue;
			}
			clsInit.cVector5.SortPointByDistance(new Point3D(), SortDirectionType.Lower, ref SortingPoints);
			ICurve[] segments = null;
			clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref SortingPoints);
			curve.SplitBy(SortingPoints, out segments);
			if ((segments != null) & (segments.Length != 0))
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Selected = true;
				for (int l = 0; l <= segments.Length - 1; l++)
				{
					Entity entity = (Entity)segments[l];
					entity.EntityData = new CustomData((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData);
					list2.Add(entity);
				}
			}
		}
		if (list2.Count > 0)
		{
			clsInit.appCommand.undoBuffer();
			clsInit.appCommand.Delete(applyReset: true);
			for (int m = 0; m <= list2.Count - 1; m++)
			{
				ccVars.UndoDont = true;
				clsInit.appCommand.AddEntity(list2[m]);
			}
		}
	}

	public void doEntitiesEdited(List<Entity> entitiesEdited)
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= entitiesEdited.Count - 1; i++)
		{
			CustomData customData = entitiesEdited[i].EntityData as CustomData;
			if ((customData.typeDefination == entityTypeDefination.Tufting) & customData.CamSelected)
			{
				list.Add(customData.EntityName);
			}
		}
		DeleteArrowAndMarkerByReleatedEntityName(list);
		AddArrowAndMarkerEntitiesFromName(ReverseDir: false, list);
	}

	public void doAddManuelEntities(Entity Ent)
	{
		if (ccVars.Pages[ccVars.PageIndex].LayerName.ToLower().IndexOf("t_") < 0)
		{
			bool realDrawMode = ccVars.RealDrawMode;
			ccVars.RealDrawMode = false;
			if (!(Ent is LinearPath))
			{
				clsInit.appCommand.AddEntity(Ent);
			}
			else
			{
				clsInit.appCommand.AddPolyline((LinearPath)Ent);
			}
			ccVars.RealDrawMode = realDrawMode;
		}
		else
		{
			string entityName = "Tufting" + TuftCounter;
			CreateTuftEntity(Ent, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftManuel", -1, -1);
			TuftCounter++;
		}
	}

	public void doAddBorderLine(Entity Ent)
	{
		List<Point3D> list = new List<Point3D>();
		List<Entity> list2 = new List<Entity>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			ICurve curve = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] as ICurve;
			CustomData customData = new CustomData((CustomData)entity.EntityData);
			Point3D[] array = curve.IntersectWith((ICurve)Ent);
			if (array == null)
			{
				continue;
			}
			ICurve[] segments = null;
			List<Point3D> list3 = new List<Point3D>();
			for (int j = 0; j <= array.Length - 1; j++)
			{
				list3.Add(buVector5.ToPoint3D(array[j]));
				list.Add(buVector5.ToPoint3D(array[j]));
			}
			curve.SplitBy(list3, out segments);
			if (segments != null && segments.Length != 0)
			{
				for (int k = 0; k <= segments.Length - 1; k++)
				{
					Entity entity2 = (Entity)segments[k];
					customData.EntityName = "Tufting" + TuftCounter;
					TuftCounter++;
					entity2.EntityData = new CustomData(customData);
					entity2.LayerName = entity.LayerName;
					entity2.Color = entity.Color;
					entity2.ColorMethod = entity.ColorMethod;
					entity2.LineWeight = entity.LineWeight;
					entity2.LineWeightMethod = entity.LineWeightMethod;
					list2.Add(entity2);
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			}
		}
		if (list2.Count > 0)
		{
			clsInit.appCommand.undoBuffer();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			for (int l = 0; l <= list2.Count - 1; l++)
			{
				ccVars.UndoDont = true;
				clsInit.appCommand.AddEntity(list2[l]);
			}
			list = clsInit.cVector5.SortByDistance(list);
			ICurve[] segments2 = null;
			((ICurve)Ent).SplitBy(list, out segments2);
			if (segments2 != null && segments2.Length != 0)
			{
				for (int m = 0; m <= segments2.Length - 1; m++)
				{
					Entity entity3 = (Entity)segments2[m];
					CustomData customData2 = new CustomData((CustomData)list2[0].EntityData);
					customData2.EntityName = "Tufting" + TuftCounter;
					TuftCounter++;
					entity3.EntityData = customData2;
					entity3.LayerName = list2[0].LayerName;
					entity3.Color = list2[0].Color;
					entity3.ColorMethod = list2[0].ColorMethod;
					entity3.LineWeight = list2[0].LineWeight;
					entity3.LineWeightMethod = list2[0].LineWeightMethod;
					ccVars.UndoDont = true;
					clsInit.appCommand.AddEntity(entity3);
				}
			}
		}
		clsInit.appCommand.Reset();
	}

	public void doAddOutlineEntities(Entity Ent)
	{
		string entityName = "Tufting" + TuftCounter;
		CreateTuftEntity(Ent, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, entityName, "TuftOutline", -1, -1);
		TuftCounter++;
	}

	public void doAddImage()
	{
		if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count <= 0 || !(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1] is Picture))
		{
			return;
		}
		string text = "";
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[i].Name.ToLower().IndexOf("image") >= 0)
			{
				text = ccVars.Pages[ccVars.PageIndex].Layers[i].Name;
			}
		}
		if (text.Length > 0)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].LayerName = text;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doJoin()
	{
		try
		{
			SortSettings sortSettings = new SortSettings();
			SortResult Result = new SortResult();
			List<Entity> SortedEntities = new List<Entity>();
			sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
			List<Entity> selectedEntities = new List<Entity>();
			SelectionOption selectionOption = new SelectionOption();
			selectionOption.CircleToArc = true;
			selectionOption.CircleTo4Arc = true;
			selectionOption.SplitArcIfGreatThen180 = true;
			selectionOption.Point = false;
			clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
			if (selectedEntities.Count <= 0)
			{
				return;
			}
			string layerName = selectedEntities[0].LayerName;
			clsInit.cVector5.SortEntitiesByRefPoint(selectedEntities[0].Vertices[0], ref selectedEntities, sortSettings, ref SortedEntities, ref Result);
			List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			if (SplitedEntitites.Count > 1)
			{
				for (int i = 0; i <= selectedEntities.Count - 1; i++)
				{
					((CustomData)selectedEntities[i].EntityData).CamSelected = false;
				}
				clsInit.cVector5.SortEntitiesByRefPoint(selectedEntities[0].Vertices[selectedEntities[0].Vertices.Length - 1], ref selectedEntities, sortSettings, ref SortedEntities, ref Result);
				SplitedEntitites = new List<List<Entity>>();
				clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			for (int j = 0; j <= SplitedEntitites.Count - 1; j++)
			{
				List<Point3D> Points = new List<Point3D>();
				clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[j], buSystem.RegenDeviation, ref Points);
				LinearPath linearPath = new LinearPath(Points);
				linearPath.EntityData = new CustomData();
				CreateTuftEntity(linearPath, layerName);
			}
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[32];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doAddPoint(Point3D PntAdd, System.Drawing.Point mousePoint)
	{
		try
		{
			int entityUnderMouseCursor = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.GetEntityUnderMouseCursor(mousePoint);
			if (((entityUnderMouseCursor >= 0) & (entityUnderMouseCursor <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)) && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor] is ICurve)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor];
				ICurve curve = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor] as ICurve;
				double t = 0.0;
				curve.ClosestPointTo(PntAdd, out t);
				Point3D point3D = curve.PointAt(t);
				List<Point3D> list = new List<Point3D>();
				list.Add(buVector5.ToPoint3D(entity.Vertices[0]));
				for (int i = 1; i <= entity.Vertices.Length - 1; i++)
				{
					if (!clsInit.cVector5.IsPointInsideLine(entity.Vertices[i - 1], entity.Vertices[i], point3D, new WorkPlane()))
					{
						list.Add(buVector5.ToPoint3D(entity.Vertices[i]));
						continue;
					}
					list.Add(buVector5.ToPoint3D(point3D));
					list.Add(buVector5.ToPoint3D(entity.Vertices[i]));
				}
				if (list.Count > 0)
				{
					CustomData customData = new CustomData((CustomData)entity.EntityData);
					Entity entity2 = buVector5.CopyEntities(entity);
					clsInit.appCommand.OsnapDeleteByEntityName(customData.EntityName);
					LinearPath linearPath = new LinearPath(list);
					linearPath.EntityData = new CustomData(customData);
					linearPath.LayerName = entity2.LayerName;
					linearPath.Color = entity2.Color;
					linearPath.ColorMethod = entity2.ColorMethod;
					linearPath.LineWeight = entity2.LineWeight;
					linearPath.LineWeightMethod = entity2.LineWeightMethod;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor] = linearPath;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor].Regen(buSystem.RegenDeviation);
					clsInit.appCommand.OsnapCalculation(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor]);
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.Reset();
			cmdAddPoint();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[22];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doRemovePoint(Point3D PntRemove, System.Drawing.Point mousePoint)
	{
		try
		{
			int entityUnderMouseCursor = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.GetEntityUnderMouseCursor(mousePoint);
			if (((entityUnderMouseCursor >= 0) & (entityUnderMouseCursor <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)) && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor] is ICurve)
			{
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor];
				List<Point3D> list = new List<Point3D>();
				for (int i = 0; i <= entity.Vertices.Length - 1; i++)
				{
					if (!buCompare5.EQ(entity.Vertices[i], PntRemove, buSystem.resolutionCompare))
					{
						list.Add(buVector5.ToPoint3D(entity.Vertices[i]));
					}
				}
				if (list.Count > 0)
				{
					CustomData customData = new CustomData((CustomData)entity.EntityData);
					Entity entity2 = buVector5.CopyEntities(entity);
					clsInit.appCommand.OsnapDeleteByEntityName(customData.EntityName);
					LinearPath linearPath = new LinearPath(list);
					linearPath.EntityData = new CustomData(customData);
					linearPath.LayerName = entity2.LayerName;
					linearPath.Color = entity2.Color;
					linearPath.ColorMethod = entity2.ColorMethod;
					linearPath.LineWeight = entity2.LineWeight;
					linearPath.LineWeightMethod = entity2.LineWeightMethod;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor] = linearPath;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor].Regen(buSystem.RegenDeviation);
					clsInit.appCommand.OsnapCalculation(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[entityUnderMouseCursor]);
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			clsInit.appCommand.Reset();
			cmdRemovePoint();
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[22];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doSelectAndBrakeBySelection()
	{
		List<Entity> selectedEntities = new List<Entity>();
		List<int> list = new List<int>();
		List<string> list2 = new List<string>();
		SelectionOption option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false, circletoArc: true, circleto4Arc: true, splitArcIfGreatThen180: true);
		clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
		if (selectedEntities.Count != 0)
		{
			LayerBase5 Layer = new LayerBase5();
			clsInit.cVector5.GetLayerFromName(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name, ref Layer);
			double stitchLen = 0.0;
			double pileHeight = 0.0;
			tuftingStitchModeType tuftingMode = tuftingStitchModeType.None;
			if (Layer.Tufting != null)
			{
				stitchLen = Layer.Tufting.StitchLength;
				pileHeight = Layer.Tufting.PileHeight;
				tuftingMode = Layer.Tufting.StitchMode;
			}
			if (((CustomData)selectedEntities[0].EntityData).tuftingPileHeight > 0.0)
			{
				pileHeight = ((CustomData)selectedEntities[0].EntityData).tuftingPileHeight;
			}
			if (((CustomData)selectedEntities[0].EntityData).tuftingStitchLength > 0.0)
			{
				stitchLen = ((CustomData)selectedEntities[0].EntityData).tuftingStitchLength;
			}
			if (((CustomData)selectedEntities[0].EntityData).tuftingMode != tuftingStitchModeType.None)
			{
				tuftingMode = ((CustomData)selectedEntities[0].EntityData).tuftingMode;
			}
			F_TuftingSetProps f_TuftingSetProps = new F_TuftingSetProps();
			f_TuftingSetProps.StitchLen = stitchLen;
			f_TuftingSetProps.TuftingMode = tuftingMode;
			f_TuftingSetProps.PileHeight = pileHeight;
			f_TuftingSetProps.Init();
			f_TuftingSetProps.ShowDialog();
			if (f_TuftingSetProps.PropertiesForm.Result == DialogResult.OK)
			{
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected)
					{
						((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData).DontUseForCalculation = true;
					}
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
				if (selectedEntities.Count > 0)
				{
					clsInit.appCommand.undoBuffer();
					bool flag = false;
					List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
					List<Entity> SortedEntities = new List<Entity>();
					SortSettings sortSettings = new SortSettings();
					SortResult Result = new SortResult();
					sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
					sortSettings.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
					clsInit.cVector5.SortEntitiesByRefPoint(selectedEntities[0].Vertices[0], ref selectedEntities, sortSettings, ref SortedEntities, ref Result);
					clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
					for (int j = 0; j <= SplitedEntitites.Count - 1; j++)
					{
						List<Point3D> Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[j], buSystem.RegenDeviation, ref Points);
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
						if (!clsInit.cVector5.IsClosed(Points))
						{
							continue;
						}
						List<Entity> entSplited = new List<Entity>();
						clsInit.appCommand.SplitEntitiesByClosedPointList(Selected: true, Points, ref entSplited);
						if (entSplited.Count <= 0)
						{
							continue;
						}
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
						for (int k = 0; k <= entSplited.Count - 1; k++)
						{
							ccVars.UndoDont = true;
							clsInit.appTufting.CreateTuftEntity(entSplited[k], entSplited[k].LayerName);
							Point3D refPoint = clsInit.cVector5.MiddlePointOfLine(entSplited[k].BoxMin, entSplited[k].BoxMax);
							if (clsInit.cVector5.IsPointInsidePolygon(Points, refPoint))
							{
								flag = true;
								CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].EntityData as CustomData;
								list2.Add(customData.EntityName);
							}
						}
					}
					if (!flag)
					{
						for (int l = 0; l <= ccVars.SelectionOP.Selections.Count - 1; l++)
						{
							list.Add(ccVars.SelectionOP.Selections[l].Index);
							((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.SelectionOP.Selections[l].Index].EntityData).tuftingMode = f_TuftingSetProps.TuftingMode;
							((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.SelectionOP.Selections[l].Index].EntityData).tuftingStitchLength = f_TuftingSetProps.StitchLen;
							((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.SelectionOP.Selections[l].Index].EntityData).tuftingPileHeight = f_TuftingSetProps.PileHeight;
						}
						ApplySetProperties(list, f_TuftingSetProps.TuftingMode, f_TuftingSetProps.PileHeight, f_TuftingSetProps.StitchLen);
					}
					else
					{
						for (int m = 0; m <= list2.Count - 1; m++)
						{
							list.Add(clsInit.cVector5.GetEntityIndexByEntityName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, list2[m]));
						}
						for (int n = 0; n <= list.Count - 1; n++)
						{
							CustomData customData2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[list[n]].EntityData as CustomData;
							customData2.tuftingMode = f_TuftingSetProps.TuftingMode;
							customData2.tuftingStitchLength = f_TuftingSetProps.StitchLen;
							customData2.tuftingPileHeight = f_TuftingSetProps.PileHeight;
						}
						ApplySetProperties(list, f_TuftingSetProps.TuftingMode, f_TuftingSetProps.PileHeight, f_TuftingSetProps.StitchLen);
					}
				}
				clsInit.appCommand.SetDontUseForCalculation(Val: false);
				clsInit.appCommand.Reset();
			}
			else
			{
				clsInit.appCommand.Reset();
			}
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doSelectAndBrakeByFreeSelection(List<Entity> Entities, List<Point3D> refPoints)
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		List<int> list = new List<int>();
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			ccVars.UndoDont = true;
			clsInit.appTufting.CreateTuftEntity(Entities[i], Entities[i].LayerName);
			Point3D refPoint = clsInit.cVector5.MiddlePointOfLine(Entities[i].BoxMin, Entities[i].BoxMax);
			if (clsInit.cVector5.IsPointInsidePolygon(refPoints, refPoint))
			{
				list.Add(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		clsInit.appCommand.SelectedToSelectionAdd(list);
		doSetProps();
		clsInit.appCommand.Reset();
	}

	public void doSetProps()
	{
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
		{
			int index = ccVars.SelectionOP.Selections[i].Index;
			list.Add(((CustomData)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData).EntityName);
			list2.Add(index);
		}
		if (list2.Count <= 0)
		{
			return;
		}
		CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[list2[0]].EntityData as CustomData;
		F_TuftingSetProps f_TuftingSetProps = new F_TuftingSetProps();
		f_TuftingSetProps.StitchLen = customData.tuftingStitchLength;
		f_TuftingSetProps.TuftingMode = customData.tuftingMode;
		f_TuftingSetProps.PileHeight = customData.tuftingPileHeight;
		f_TuftingSetProps.Init();
		f_TuftingSetProps.ShowDialog();
		if (f_TuftingSetProps.PropertiesForm.Result == DialogResult.OK)
		{
			clsInit.appCommand.undoBuffer();
			for (int j = 0; j <= list2.Count - 1; j++)
			{
				CustomData customData2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[list2[j]].EntityData as CustomData;
				customData2.tuftingMode = f_TuftingSetProps.TuftingMode;
				customData2.tuftingStitchLength = f_TuftingSetProps.StitchLen;
				customData2.tuftingPileHeight = f_TuftingSetProps.PileHeight;
			}
			ApplySetProperties(new List<int>(), f_TuftingSetProps.TuftingMode, f_TuftingSetProps.PileHeight, f_TuftingSetProps.StitchLen);
		}
	}

	public void CreateCodeFromSorted(TuftingSequenceItem Sorted, ref List<string> GCodes)
	{
		double num = 0.0;
		double num2 = 0.0;
		tuftingStitchModeType tuftingStitchModeType2 = tuftingStitchModeType.None;
		LayerBase5 Layer = new LayerBase5();
		clsInit.cVector5.GetLayerFromName(ccVars.Pages[ccVars.PageIndex].Layers, Sorted.LayerName, ref Layer);
		num = Layer.Tufting.PileHeight;
		num2 = Layer.Tufting.StitchLength;
		tuftingStitchModeType2 = Layer.Tufting.StitchMode;
		Point3D value = new Point3D();
		tuftingStitchModeType tuftingStitchModeType3 = tuftingStitchModeType.None;
		for (int i = 0; i <= Sorted.SortedEntities.Count - 1; i++)
		{
			double PileHeight = 0.0;
			double StitchLen = 0.0;
			tuftingStitchModeType TuftMode = tuftingStitchModeType.None;
			string text = "";
			if (Sorted.SortedEntities[i].Vertices.Length < 2)
			{
				continue;
			}
			if (!GetDefinationFromEntity(Sorted.SortedEntities[i], ref StitchLen, ref PileHeight, ref TuftMode))
			{
				PileHeight = num;
				StitchLen = num2;
				TuftMode = tuftingStitchModeType2;
			}
			string text2 = "";
			if (i != 0)
			{
				if (buCompare5.EQ(Sorted.SortedEntities[i].Vertices[0], value, 0.1))
				{
					if (TuftMode != tuftingStitchModeType3)
					{
						if (TuftMode == tuftingStitchModeType.Cut)
						{
							GCodes.Add("M3");
						}
						if (TuftMode == tuftingStitchModeType.Loop)
						{
							GCodes.Add("M4");
						}
					}
				}
				else
				{
					text2 = "G0 X" + Sorted.SortedEntities[i].Vertices[0].X.ToString("f3") + " Y" + Sorted.SortedEntities[i].Vertices[0].Y.ToString("f3");
					text2 = text2 + " Z" + PileHeight.ToString("f1") + " S" + StitchLen.ToString("f1") + text;
					GCodes.Add("M2");
					GCodes.Add(text2);
					GCodes.Add("M1");
					if (TuftMode == tuftingStitchModeType.Cut)
					{
						GCodes.Add("M3");
					}
					if (TuftMode == tuftingStitchModeType.Loop)
					{
						GCodes.Add("M4");
					}
				}
			}
			else
			{
				text2 = "G0 X" + Sorted.SortedEntities[i].Vertices[0].X.ToString("f3") + " Y" + Sorted.SortedEntities[i].Vertices[0].Y.ToString("f3");
				text2 = text2 + " Z" + PileHeight.ToString("f1") + " S" + StitchLen.ToString("f1") + text;
				GCodes.Add("M2");
				GCodes.Add(text2);
				GCodes.Add("M1");
				if (TuftMode == tuftingStitchModeType.Cut)
				{
					GCodes.Add("M3");
				}
				if (TuftMode == tuftingStitchModeType.Loop)
				{
					GCodes.Add("M4");
				}
			}
			tuftingStitchModeType3 = TuftMode;
			for (int j = 1; j <= Sorted.SortedEntities[i].Vertices.Length - 1; j++)
			{
				text2 = "G1 X" + Sorted.SortedEntities[i].Vertices[j].X.ToString("f3") + " Y" + Sorted.SortedEntities[i].Vertices[j].Y.ToString("f3");
				text2 = text2 + " Z" + PileHeight.ToString("f1") + " S" + StitchLen.ToString("f1");
				if (j == 1)
				{
					text2 += text;
				}
				GCodes.Add(text2);
				if (j == Sorted.SortedEntities[i].Vertices.Length - 1)
				{
					value = buVector5.ToPoint3D(Sorted.SortedEntities[i].Vertices[j]);
				}
			}
		}
		GCodes.Add("M2");
	}

	public void doConvertToTuftingLayer()
	{
		int layerIndex = ccVars.Pages[ccVars.PageIndex].LayerIndex;
		if (layerIndex < 0)
		{
			return;
		}
		string name = ccVars.Pages[ccVars.PageIndex].Layers[layerIndex].Name;
		Color color = Color.Transparent;
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			if (entity.LayerName == name && entity.ColorMethod == colorMethodType.byEntity)
			{
				color = entity.Color;
			}
		}
		if (color == Color.Transparent)
		{
			color = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].LayerColor;
		}
		if (color == Color.Transparent)
		{
			color = Color.Blue;
		}
		F_LayerConvertToTufting f_LayerConvertToTufting = new F_LayerConvertToTufting();
		f_LayerConvertToTufting.layer = new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex]);
		f_LayerConvertToTufting.layer.LayerColor = color;
		for (int j = 0; j <= Yarns.Count - 1; j++)
		{
			f_LayerConvertToTufting.Yarns.Add(new TuftingYarn(Yarns[j]));
		}
		if (f_LayerConvertToTufting.layer.Name.IndexOf("T_") < 0)
		{
			f_LayerConvertToTufting.layer.Name = "T_" + f_LayerConvertToTufting.layer.Name;
		}
		f_LayerConvertToTufting.Init();
		f_LayerConvertToTufting.ShowDialog();
		if (f_LayerConvertToTufting.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		ccVars.Pages[ccVars.PageIndex].Layers[layerIndex] = new LayerBase5(f_LayerConvertToTufting.layer);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[layerIndex].Color = f_LayerConvertToTufting.layer.LayerColor;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[layerIndex].Name = f_LayerConvertToTufting.layer.Name;
		for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
		{
			Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k];
			if (entity2.LayerName == name)
			{
				entity2.LayerName = f_LayerConvertToTufting.layer.Name;
				entity2.ColorMethod = colorMethodType.byLayer;
			}
			((CustomData)entity2.EntityData).typeDefination = entityTypeDefination.Tufting;
			((CustomData)entity2.EntityData).ActionName = "TuftFill";
			clsInit.appCommand.OsnapDeleteByEntityName(((CustomData)entity2.EntityData).EntityName);
			clsInit.appCommand.OsnapCalculation(entity2);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
		clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: true, 0);
	}
}
