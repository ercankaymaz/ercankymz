using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ModuleWorks.ToolpathParameters;
using buClass;
using buClass.Apps;
using buControls.Forms.WinControlForms.Errors;
using buControls.Forms.WinControlForms.Events;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Jewel;

public class clsJewel
{
	public static List<JewelMode> JewelModes = null;

	public F_JewelModes frmModes = null;

	public F_JewelModeSelection frmModesSelection = null;

	public static JewelProgramSettings varJewelSettings = new JewelProgramSettings();

	public static JewelRuntimeSettings varJewelRuntimeSettings = new JewelRuntimeSettings();

	public void Init()
	{
		JewelModes = new List<JewelMode>();
		frmModesSelection = new F_JewelModeSelection();
		frmModes = new F_JewelModes();
		buMWJewelVars.Init();
		FileInfo fileInfo = new FileInfo(AppPath.Base + "\\Misc\\JewelModes.bujewelmode");
		if (fileInfo.Exists)
		{
			JewelModeOpen(fileInfo.FullName);
		}
	}

	public void cmdCamCreatGCode()
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

	public void cmdCamShowGCode()
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

	public void cmdModes()
	{
		try
		{
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdZHeight()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					Point3D MinPoint = new Point3D();
					Point3D MidPoint = new Point3D();
					Point3D MaxPoint = new Point3D();
					if (ccVars.SelectionOP.Selections.Count == 0)
					{
						return;
					}
					clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, SelectedCondition: true, ref MinPoint, ref MidPoint, ref MaxPoint);
					F_MoveXYZHeights f_MoveXYZHeights = new F_MoveXYZHeights();
					f_MoveXYZHeights.Settings = new MoveHeightEventVar(clsVar.varInterface.MoveHeightVar);
					f_MoveXYZHeights.txt_ztop.Text = "Max Z : " + MaxPoint.Z;
					f_MoveXYZHeights.txt_zbottom.Text = "Min Z : " + MinPoint.Z;
					f_MoveXYZHeights.txt_xrightpos.Text = "Max Y : " + MaxPoint.X;
					f_MoveXYZHeights.txt_xfleftpos.Text = "Min Y : " + MinPoint.X;
					f_MoveXYZHeights.txt_ybackpos.Text = "Max X : " + MaxPoint.Y;
					f_MoveXYZHeights.txt_yfrontpos.Text = "Min Y : " + MinPoint.Y;
					f_MoveXYZHeights.Init();
					f_MoveXYZHeights.ShowDialog();
					if (f_MoveXYZHeights.PropertiesForm.Result != DialogResult.OK)
					{
						return;
					}
					clsVar.varInterface.MoveHeightVar = new MoveHeightEventVar(f_MoveXYZHeights.Settings);
					if (clsVar.varInterface.MoveHeightVar.Axis == AxesXYZ.Z)
					{
						if (clsVar.varInterface.MoveHeightVar.ZType == TopBottomType.Top)
						{
							clsInit.appCommand.Move(new Point3D(0.0, 0.0, MaxPoint.Z), new Point3D(0.0, 0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition));
						}
						if (clsVar.varInterface.MoveHeightVar.ZType == TopBottomType.Bottom)
						{
							clsInit.appCommand.Move(new Point3D(0.0, 0.0, MinPoint.Z), new Point3D(0.0, 0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition));
						}
					}
					if (clsVar.varInterface.MoveHeightVar.Axis == AxesXYZ.X)
					{
						if (clsVar.varInterface.MoveHeightVar.XType == LeftRightType.Left)
						{
							clsInit.appCommand.Move(new Point3D(MinPoint.X, 0.0, 0.0), new Point3D(clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0, 0.0));
						}
						if (clsVar.varInterface.MoveHeightVar.XType == LeftRightType.Right)
						{
							clsInit.appCommand.Move(new Point3D(MaxPoint.X, 0.0, 0.0), new Point3D(clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0, 0.0));
						}
					}
					if (clsVar.varInterface.MoveHeightVar.Axis == AxesXYZ.Y)
					{
						if (clsVar.varInterface.MoveHeightVar.YType == FrontBackType.Front)
						{
							clsInit.appCommand.Move(new Point3D(0.0, MinPoint.Y, 0.0), new Point3D(0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0));
						}
						if (clsVar.varInterface.MoveHeightVar.YType == FrontBackType.Back)
						{
							clsInit.appCommand.Move(new Point3D(0.0, MaxPoint.Y, 0.0), new Point3D(0.0, clsVar.varInterface.MoveHeightVar.MoveToPosition, 0.0));
						}
					}
					clsFiles.SaveParameter();
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

	public void JewelModesToParameter(JewelMode Mode)
	{
	}

	public static void JewelModeOpen(string FileName)
	{
	}

	public static void JewelModeSave(string FileName, bool CheckExist)
	{
	}

	public void SaveJewelFile()
	{
		string fileName = AppPath.Settings + "\\Jewel\\Jewel.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Jewel Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<JewelSettings>");
		arrayList.AddRange(varJewelSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
		arrayList.Add("</JewelSettings>");
		arrayList.Add("<JewelRuntimeSettings>");
		arrayList.AddRange(varJewelRuntimeSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
		arrayList.Add("</JewelRuntimeSettings>");
		buFile.SaveToFile(arrayList, fileName);
		buLog.addLog("Jewel Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		buMWJewelVars.varCamMeshRough.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelMeshRough.bin");
		buMWJewelVars.varCamMeshParelelCut.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelMeshParalel.bin");
		buMWJewelVars.varCamMeshConstantZ.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelMeshContantZ.bin");
		buMWJewelVars.varCamWireDrill4X.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelDrill4X.bin");
		buMWJewelVars.varCamWireDrill.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelDrill.bin");
		buMWJewelVars.varCamWireSpin.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelSpin.bin");
		buMWJewelVars.varCamWireContour.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelWFContour4X.bin");
		buMWJewelVars.varCamWireContour4X.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelWFContour.bin");
		buMWJewelVars.varCamWirePocket.mwPar.Serialize(AppPath.Settings + "\\Jewel\\mwJewelWFPocket.bin");
		string fileName2 = AppPath.Settings + "\\Jewel\\JewelCam.bucamset";
		arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Cam Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<BuCamSettings>");
		arrayList.AddRange(buMWJewelVars.varCamMeshRough.buPar.ToDefAll("_varbuCamMeshRoughPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamMeshParelelCut.buPar.ToDefAll("_varbuCamMeshParallelPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamMeshConstantZ.buPar.ToDefAll("_varbuCamMeshConstantZPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamWireDrill4X.buPar.ToDefAll("_varbuCamDrill4XPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamWireDrill.buPar.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamWireSpin.buPar.ToDefAll("_varbuCamSpinPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamWireContour4X.buPar.ToDefAll("_varbuCamWFContour4XPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamWireContour.buPar.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWJewelVars.varCamWirePocket.buPar.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</BuCamSettings>");
		buFile.SaveToFile(arrayList, fileName2);
	}

	public void OpenJewelFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Jewel\\Jewel.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Jewel Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Jewel Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<JewelSettings>", "</JewelSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varJewelSettings);
						buLog.addLog("Jewel Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<JewelRuntimeSettings>", "</JewelRuntimeSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varJewelRuntimeSettings);
						buLog.addLog("Jewel RuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Jewel Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Jewel Settings Decoder Error");
				}
			}
			buLog.addLog("Jewel Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelMeshRough.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamMeshRough.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelMeshParalel.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamMeshParelelCut.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelMeshContantZ.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamMeshConstantZ.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelDrill4X.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamWireDrill4X.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelDrill.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamWireDrill.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelSpin.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamWireSpin.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelWFContour4X.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamWireContour4X.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelWFContour.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamWireContour.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Jewel\\mwJewelWFPocket.bin");
			if (fileInfo.Exists)
			{
				buMWJewelVars.varCamWirePocket.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Jewel\\JewelCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLog.addLog("Jewel Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Jewel Cam Settings File Missing");
				return;
			}
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileName2, ref arrayList);
			try
			{
				ArrayList CalcList2 = new ArrayList();
				buString.ListToSpecificList("<BuCamSettings>", "</BuCamSettings>", AddStartEndKey: true, arrayList, ref CalcList2);
				if (CalcList2.Count > 0)
				{
					buSerilization.Decode(arrayList, "_varbuCamMeshRoughPars", SerilizationMode.MultiLine, buMWJewelVars.varCamMeshRough.buPar);
					buSerilization.Decode(arrayList, "_varbuCamMeshParallelPars", SerilizationMode.MultiLine, buMWJewelVars.varCamMeshParelelCut.buPar);
					buSerilization.Decode(arrayList, "_varbuCamMeshConstantZPars", SerilizationMode.MultiLine, buMWJewelVars.varCamMeshConstantZ.buPar);
					buSerilization.Decode(arrayList, "_varbuCamDrill4XPars", SerilizationMode.MultiLine, buMWJewelVars.varCamWireDrill4X.buPar);
					buSerilization.Decode(arrayList, "_varbuCamDrillPars", SerilizationMode.MultiLine, buMWJewelVars.varCamWireDrill.buPar);
					buSerilization.Decode(arrayList, "_varbuCamSpinPars", SerilizationMode.MultiLine, buMWJewelVars.varCamWireSpin.buPar);
					buSerilization.Decode(arrayList, "_varbuCamWFContour4XPars", SerilizationMode.MultiLine, buMWJewelVars.varCamWireContour4X.buPar);
					buSerilization.Decode(arrayList, "_varbuCamWFContourPars", SerilizationMode.MultiLine, buMWJewelVars.varCamWireContour.buPar);
					buSerilization.Decode(arrayList, "_varbuCamWFPocketPars", SerilizationMode.MultiLine, buMWJewelVars.varCamWirePocket.buPar);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("bu Jeel Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Jewel Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			buLog.addLog("Jewel Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Jewel Settings Decoder Error");
		}
	}

	public void cmdCamContour(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				switch (Action)
				{
				case actionTypeBU.camJewel3AXContour:
				{
					camTp Cam3 = new camTp();
					MWCalculationOptions mWCalculationOptions3 = new MWCalculationOptions();
					mWCalculationOptions3.NumberofAxis = 3;
					mWCalculationOptions3.CamWireframeType = CamWireFrameType.Contour;
					mWCalculationOptions3.Mode = CamMode.WireFrame;
					mWCalculationOptions3.DontApplyReset = true;
					mWCalculationOptions3.isBuWireframeCalculation = true;
					mWCalculationOptions3.AddToCamListInLocalCalculation = true;
					mWCalculationOptions3.ShowLeadInOutPage = false;
					doWireframeContour(mWCalculationOptions3, ccVars.toolActive, ccVars.Action, ref Cam3);
					break;
				}
				case actionTypeBU.camJewel3AXPocket:
				{
					camTp Cam2 = new camTp();
					MWCalculationOptions mWCalculationOptions2 = new MWCalculationOptions();
					mWCalculationOptions2.NumberofAxis = 3;
					mWCalculationOptions2.CamWireframeType = CamWireFrameType.Pocket;
					mWCalculationOptions2.Mode = CamMode.WireFrame;
					mWCalculationOptions2.isRough = true;
					mWCalculationOptions2.DontApplyReset = true;
					mWCalculationOptions2.AddToCamListInLocalCalculation = true;
					mWCalculationOptions2.ShowLeadInOutPage = false;
					doWireframeContour(mWCalculationOptions2, ccVars.toolActive, ccVars.Action, ref Cam2);
					break;
				}
				case actionTypeBU.camJewel4AXContour:
				{
					camTp Cam = new camTp();
					MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
					mWCalculationOptions.NumberofAxis = 4;
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
					mWCalculationOptions.Mode = CamMode.WireFrame;
					mWCalculationOptions.DontApplyReset = true;
					mWCalculationOptions.isBuWireframeCalculation = true;
					mWCalculationOptions.AddToCamListInLocalCalculation = true;
					mWCalculationOptions.ShowLeadInOutPage = false;
					doWireframeContour(mWCalculationOptions, ccVars.toolActive, ccVars.Action, ref Cam);
					break;
				}
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public int cmdCamContourReCalculate(camTp OldCam, ref camTp NewCam)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Expected O, but got Unknown
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Expected O, but got Unknown
		try
		{
			MWCalculationOptions mWCalculationOptions = new MWCalculationOptions(OldCam.MWCalcOptions);
			clsMW.CamEntities.Clear();
			if (OldCam.Action != actionTypeBU.camJewel3AXContour)
			{
				if (OldCam.Action != actionTypeBU.camJewel3AXPocket)
				{
					if (OldCam.Action != actionTypeBU.camJewel4AXContour)
					{
						if (OldCam.Action != actionTypeBU.camJewel3AXSpinConstant)
						{
							if (OldCam.Action != actionTypeBU.camJewel4AXSpinRamp)
							{
								if (OldCam.Action != actionTypeBU.camJewel3AXPunch)
								{
									if (OldCam.Action != actionTypeBU.camJewel4AXPunch)
									{
										if (OldCam.Action != actionTypeBU.camJewel4AXPointRotation)
										{
											if (OldCam.Action != actionTypeBU.camJewel3AXTriMeshRough)
											{
												if (OldCam.Action != actionTypeBU.camJewel3AXTriMeshParalelCut)
												{
													if (OldCam.Action != actionTypeBU.camJewel3AXTriMeshConstantZ)
													{
														return -1;
													}
													buMWJewelVars.varCamMeshConstantZ.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
													buMWJewelVars.varCamMeshConstantZ.buPar = new camParameters5(OldCam.Parameter);
													clsMW.CamEntities.Clear();
													clsMW.CamEntities = new List<Entity>();
													buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
													mWCalculationOptions.AddToCamListInLocalCalculation = false;
													NewCam = new camTp();
													return doTriangleMesh(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
												}
												buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
												buMWJewelVars.varCamMeshParelelCut.buPar = new camParameters5(OldCam.Parameter);
												clsMW.CamEntities.Clear();
												clsMW.CamEntities = new List<Entity>();
												buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
												mWCalculationOptions.AddToCamListInLocalCalculation = false;
												NewCam = new camTp();
												return doTriangleMesh(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
											}
											buMWJewelVars.varCamMeshRough.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
											buMWJewelVars.varCamMeshRough.buPar = new camParameters5(OldCam.Parameter);
											clsMW.CamEntities.Clear();
											clsMW.CamEntities = new List<Entity>();
											buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
											mWCalculationOptions.AddToCamListInLocalCalculation = false;
											NewCam = new camTp();
											return doTriangleMesh(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
										}
										buMWJewelVars.varCamWireDrill4X.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
										buMWJewelVars.varCamWireDrill4X.buPar = new camParameters5(OldCam.Parameter);
										clsMW.CamEntities.Clear();
										clsMW.CamEntities = new List<Entity>();
										buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
										mWCalculationOptions.AddToCamListInLocalCalculation = false;
										NewCam = new camTp();
										return doDrill(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
									}
									buMWJewelVars.varCamWireDrill4X.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
									buMWJewelVars.varCamWireDrill4X.buPar = new camParameters5(OldCam.Parameter);
									clsMW.CamEntities.Clear();
									clsMW.CamEntities = new List<Entity>();
									buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
									mWCalculationOptions.AddToCamListInLocalCalculation = false;
									NewCam = new camTp();
									return doDrill(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
								}
								buMWJewelVars.varCamWireDrill.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
								buMWJewelVars.varCamWireDrill.buPar = new camParameters5(OldCam.Parameter);
								clsMW.CamEntities.Clear();
								clsMW.CamEntities = new List<Entity>();
								buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
								mWCalculationOptions.AddToCamListInLocalCalculation = false;
								NewCam = new camTp();
								return doDrill(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
							}
							buMWJewelVars.varCamWireSpin.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
							buMWJewelVars.varCamWireSpin.buPar = new camParameters5(OldCam.Parameter);
							clsMW.CamEntities.Clear();
							clsMW.CamEntities = new List<Entity>();
							buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
							mWCalculationOptions.AddToCamListInLocalCalculation = false;
							NewCam = new camTp();
							return doWireframeContour(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
						}
						buMWJewelVars.varCamWireSpin.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
						buMWJewelVars.varCamWireSpin.buPar = new camParameters5(OldCam.Parameter);
						clsMW.CamEntities.Clear();
						clsMW.CamEntities = new List<Entity>();
						buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
						mWCalculationOptions.AddToCamListInLocalCalculation = false;
						NewCam = new camTp();
						return doWireframeContour(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
					}
					buMWJewelVars.varCamWireContour4X.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
					buMWJewelVars.varCamWireContour4X.buPar = new camParameters5(OldCam.Parameter);
					clsMW.CamEntities.Clear();
					clsMW.CamEntities = new List<Entity>();
					buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
					mWCalculationOptions.AddToCamListInLocalCalculation = false;
					NewCam = new camTp();
					return doWireframeContour(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
				}
				buMWJewelVars.varCamWirePocket.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
				buMWJewelVars.varCamWireContour.buPar = new camParameters5(OldCam.Parameter);
				clsMW.CamEntities.Clear();
				clsMW.CamEntities = new List<Entity>();
				buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
				mWCalculationOptions.AddToCamListInLocalCalculation = false;
				NewCam = new camTp();
				return doWireframeContour(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
			}
			buMWJewelVars.varCamWireContour.mwPar.MachParam = new MachiningParams((MachiningParams)OldCam.mwParameter);
			buMWJewelVars.varCamWireContour.buPar = new camParameters5(OldCam.Parameter);
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			buVector5.CopyEntities(OldCam.RefEntities, ref clsMW.CamEntities);
			mWCalculationOptions.AddToCamListInLocalCalculation = false;
			NewCam = new camTp();
			return doWireframeContour(mWCalculationOptions, ccVars.toolActive, OldCam.Action, ref NewCam);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return -1;
		}
	}

	public void cmdCamLathe(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				camTp Cam = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = true;
				mWCalculationOptions.AddToCamListInLocalCalculation = true;
				mWCalculationOptions.ShowLeadInOutPage = false;
				doLathe(mWCalculationOptions, ccVars.toolActive, ccVars.Action, ref Cam);
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamSpin(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				camTp Cam = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.Action = ccVars.Action;
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInLocalCalculation = true;
				mWCalculationOptions.ShowLeadInOutPage = false;
				if (Action != actionTypeBU.camJewel4AXSpinRamp)
				{
					if (Action == actionTypeBU.camJewel3AXSpinConstant)
					{
						mWCalculationOptions.isSpinConstantCalculation = true;
					}
				}
				else
				{
					mWCalculationOptions.NumberofAxis = 4;
					mWCalculationOptions.isSpinCalculation = true;
				}
				doWireframeContour(mWCalculationOptions, ccVars.toolActive, ccVars.Action, ref Cam);
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamTriangleMesh(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				switch (Action)
				{
				case actionTypeBU.camJewel3AXTriMeshRough:
				{
					camTp Cam3 = new camTp();
					MWCalculationOptions mWCalculationOptions3 = new MWCalculationOptions();
					mWCalculationOptions3.NumberofAxis = 3;
					mWCalculationOptions3.CamTriMeshType = CamTriangularMeshType.Rough;
					mWCalculationOptions3.Mode = CamMode.TriangularMesh;
					mWCalculationOptions3.isRough = true;
					mWCalculationOptions3.DontApplyReset = true;
					mWCalculationOptions3.AddToCamListInLocalCalculation = true;
					doTriangleMesh(mWCalculationOptions3, ccVars.toolActive, Action, ref Cam3);
					break;
				}
				case actionTypeBU.camJewel3AXTriMeshParalelCut:
				{
					camTp Cam2 = new camTp();
					MWCalculationOptions mWCalculationOptions2 = new MWCalculationOptions();
					mWCalculationOptions2.NumberofAxis = 3;
					mWCalculationOptions2.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
					mWCalculationOptions2.Mode = CamMode.TriangularMesh;
					mWCalculationOptions2.DontApplyReset = true;
					mWCalculationOptions2.AddToCamListInLocalCalculation = true;
					doTriangleMesh(mWCalculationOptions2, ccVars.toolActive, Action, ref Cam2);
					break;
				}
				case actionTypeBU.camJewel3AXTriMeshConstantZ:
				{
					camTp Cam = new camTp();
					MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
					mWCalculationOptions.NumberofAxis = 3;
					mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
					mWCalculationOptions.Mode = CamMode.TriangularMesh;
					mWCalculationOptions.DontApplyReset = true;
					mWCalculationOptions.AddToCamListInLocalCalculation = true;
					doTriangleMesh(mWCalculationOptions, ccVars.toolActive, Action, ref Cam);
					break;
				}
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamDrill(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				switch (Action)
				{
				case actionTypeBU.camJewel3AXPunch:
				{
					camTp Cam3 = new camTp();
					MWCalculationOptions mWCalculationOptions3 = new MWCalculationOptions();
					mWCalculationOptions3.NumberofAxis = 3;
					mWCalculationOptions3.CamDrillType = CamDrillType.Line;
					mWCalculationOptions3.CamDrillMode = CamDrillMode.Point;
					mWCalculationOptions3.Mode = CamMode.Drill;
					mWCalculationOptions3.DontApplyReset = true;
					mWCalculationOptions3.AddToCamListInLocalCalculation = true;
					doDrill(mWCalculationOptions3, ccVars.toolActive, Action, ref Cam3);
					break;
				}
				case actionTypeBU.camJewel4AXPunch:
				{
					camTp Cam2 = new camTp();
					MWCalculationOptions mWCalculationOptions2 = new MWCalculationOptions();
					mWCalculationOptions2.NumberofAxis = 4;
					mWCalculationOptions2.CamDrillType = CamDrillType.Line;
					mWCalculationOptions2.CamDrillMode = CamDrillMode.Tangent;
					mWCalculationOptions2.Mode = CamMode.Drill;
					mWCalculationOptions2.DontApplyReset = true;
					mWCalculationOptions2.AddToCamListInLocalCalculation = true;
					doDrill(mWCalculationOptions2, ccVars.toolActive, Action, ref Cam2);
					break;
				}
				case actionTypeBU.camJewel4AXPointRotation:
				{
					camTp Cam = new camTp();
					MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
					mWCalculationOptions.NumberofAxis = 4;
					mWCalculationOptions.CamDrillType = CamDrillType.Line;
					mWCalculationOptions.CamDrillMode = CamDrillMode.Rotation;
					mWCalculationOptions.Mode = CamMode.Drill;
					mWCalculationOptions.DontApplyReset = true;
					mWCalculationOptions.AddToCamListInLocalCalculation = true;
					doDrill(mWCalculationOptions, ccVars.toolActive, Action, ref Cam);
					break;
				}
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public int doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, actionTypeBU Action, ref camTp Cam)
	{
		Cam = new camTp();
		_ = buMWJewelVars.varCamWireContour.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental;
		_ = buMWJewelVars.varCamWireContour4X.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental;
		if (Action == actionTypeBU.camJewel3AXContour)
		{
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireContour.mwPar, buMWJewelVars.varCamWireContour.buPar, out clsMW.varbuCamWFContourPars);
		}
		if (Action == actionTypeBU.camJewel4AXContour)
		{
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireContour4X.mwPar, buMWJewelVars.varCamWireContour4X.buPar, out clsMW.varbuCamWFContourPars);
		}
		if (Action == actionTypeBU.camJewel3AXPocket)
		{
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWirePocket.mwPar, buMWJewelVars.varCamWirePocket.buPar, out clsMW.varbuCamWFContourPars);
		}
		if (Action == actionTypeBU.camJewel3AXSpinConstant)
		{
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireSpin.mwPar, buMWJewelVars.varCamWireSpin.buPar, out clsMW.varbuCamWFContourPars);
		}
		if (Action == actionTypeBU.camJewel4AXSpinRamp)
		{
			clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireSpin.mwPar, buMWJewelVars.varCamWireSpin.buPar, out clsMW.varbuCamWFContourPars);
		}
		if (ccVars.MaterialList.Count > 0 && ccVars.MaterialList[clsVar.varInterface.MaterialIndex].Enable)
		{
			MWCalcoptions.CheckBoxBounding = true;
			MWCalcoptions.BoxBoundingMin.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.X;
			MWCalcoptions.BoxBoundingMin.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.Y;
			MWCalcoptions.BoxBoundingMin.Z = 0.0;
			MWCalcoptions.BoxBoundingMax.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.X;
			MWCalcoptions.BoxBoundingMax.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.Y;
			MWCalcoptions.BoxBoundingMax.Z = 0.0;
		}
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		if (Result.Errors.Count <= 0)
		{
			if (Action == actionTypeBU.camJewel3AXContour)
			{
				buMWJewelVars.varCamWireContour.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireContour.buPar);
			}
			if (Action == actionTypeBU.camJewel4AXContour)
			{
				buMWJewelVars.varCamWireContour4X.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireContour4X.buPar);
			}
			if (Action == actionTypeBU.camJewel3AXPocket)
			{
				buMWJewelVars.varCamWirePocket.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWirePocket.buPar);
			}
			if (Action == actionTypeBU.camJewel3AXSpinConstant)
			{
				buMWJewelVars.varCamWireSpin.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireSpin.buPar);
			}
			if (Action == actionTypeBU.camJewel4AXSpinRamp)
			{
				buMWJewelVars.varCamWireSpin.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWJewelVars.varCamWireSpin.buPar);
			}
			if (num >= 1)
			{
				Cam.Mode = MWCalcoptions.Mode;
				Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
				Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
				Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
				Cam.Action = Action;
				if (MWCalcoptions.Mode == CamMode.WireFrame)
				{
					if (Tool.Geometry.GeometryType != ToolType.Saw)
					{
						Cam.PreCodes.Add("M41");
						Cam.PreCodes.Add("M154");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("M6 T" + Tool.Data.No);
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("M154");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("M3 K" + Tool.CamData.SpindleSpeed);
					}
					else
					{
						Cam.PreCodes.Add("G0 Z100");
						Cam.PreCodes.Add("M40");
						Cam.PreCodes.Add("M154");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("M33 K" + Tool.CamData.SpindleSpeed);
					}
					if (MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
					{
						if (MWCalcoptions.NumberofAxis != 4)
						{
							if (!((MWCalcoptions.NumberofAxis == 3) & !MWCalcoptions.isSpinConstantCalculation))
							{
								if ((MWCalcoptions.NumberofAxis == 3) & MWCalcoptions.isSpinConstantCalculation)
								{
									buString5.AddToArrayList(ccVars.PostActive.JewellarySpinConstant3AXPreCodes, ref Cam.PreCodes);
									for (int i = 0; i <= Cam.Tool.ToolNext.Count - 1; i++)
									{
										if (Cam.Tool.ToolNext[i].ToString().Trim().Length > 0)
										{
											Cam.AfterCodes.Add(Cam.Tool.ToolNext[i].ToString().Trim());
										}
									}
									buString5.AddToArrayList(ccVars.PostActive.JewellarySpinConstant3AXAfterCodes, ref Cam.AfterCodes);
									for (int j = 0; j <= Cam.Tool.ToolPre.Count - 1; j++)
									{
										if (Cam.Tool.ToolPre[j].ToString().Trim().Length > 0)
										{
											Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[j].ToString().Trim());
										}
									}
									Cam.CamPoints[0].PreCodes.Add("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed);
									if (MWCalcoptions.AddToCamListInLocalCalculation)
									{
										clsInit.appCommand.CamAdd(Cam);
									}
								}
							}
							else
							{
								buString5.AddToArrayList(ccVars.PostActive.JewellaryContour3AXPreCodes, ref Cam.PreCodes);
								for (int k = 0; k <= Cam.Tool.ToolNext.Count - 1; k++)
								{
									if (Cam.Tool.ToolNext[k].ToString().Trim().Length > 0)
									{
										Cam.AfterCodes.Add(Cam.Tool.ToolNext[k].ToString().Trim());
									}
								}
								buString5.AddToArrayList(ccVars.PostActive.JewellaryContour3AXAfterCodes, ref Cam.AfterCodes);
								for (int l = 0; l <= Cam.Tool.ToolPre.Count - 1; l++)
								{
									if (Cam.Tool.ToolPre[l].ToString().Trim().Length > 0)
									{
										Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[l].ToString().Trim());
									}
								}
								if (MWCalcoptions.AddToCamListInLocalCalculation)
								{
									clsInit.appCommand.CamAdd(Cam);
								}
							}
						}
						else
						{
							buString5.AddToArrayList(ccVars.PostActive.JewellaryContour4AXPreCodes, ref Cam.PreCodes);
							for (int m = 0; m <= Cam.Tool.ToolNext.Count - 1; m++)
							{
								if (Cam.Tool.ToolNext[m].ToString().Trim().Length > 0)
								{
									Cam.AfterCodes.Add(Cam.Tool.ToolNext[m].ToString().Trim());
								}
							}
							buString5.AddToArrayList(ccVars.PostActive.JewellaryContour4AXAfterCodes, ref Cam.AfterCodes);
							for (int n = 0; n <= Cam.Tool.ToolPre.Count - 1; n++)
							{
								if (Cam.Tool.ToolPre[n].ToString().Trim().Length > 0)
								{
									Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[n].ToString().Trim());
								}
							}
							if (MWCalcoptions.AddToCamListInLocalCalculation)
							{
								clsInit.appCommand.CamAdd(Cam);
							}
						}
					}
					if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
					{
						buString5.AddToArrayList(ccVars.PostActive.JewellaryPocket3AXPreCodes, ref Cam.PreCodes);
						for (int num2 = 0; num2 <= Cam.Tool.ToolNext.Count - 1; num2++)
						{
							if (Cam.Tool.ToolNext[num2].ToString().Trim().Length > 0)
							{
								Cam.AfterCodes.Add(Cam.Tool.ToolNext[num2].ToString().Trim());
							}
						}
						buString5.AddToArrayList(ccVars.PostActive.JewellaryPocket3AXAfterCodes, ref Cam.AfterCodes);
						for (int num3 = 0; num3 <= Cam.Tool.ToolPre.Count - 1; num3++)
						{
							if (Cam.Tool.ToolPre[num3].ToString().Trim().Length > 0)
							{
								Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[num3].ToString().Trim());
							}
						}
						if (MWCalcoptions.AddToCamListInLocalCalculation)
						{
							clsInit.appCommand.CamAdd(Cam);
						}
					}
				}
				clsInit.appCommand.Reset();
				clsFiles.SaveParameter();
				return 1;
			}
			clsInit.appCommand.Reset();
			return num;
		}
		F_ErrorList f_ErrorList = new F_ErrorList();
		f_ErrorList.Init(Result.Errors);
		f_ErrorList.ShowDialog();
		clsInit.appCommand.Reset();
		return -2;
	}

	public int doTriangleMesh(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, actionTypeBU Action, ref camTp Cam)
	{
		Cam = new camTp();
		if (Action == actionTypeBU.camJewel3AXTriMeshRough)
		{
			clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamMeshRough.mwPar, buMWJewelVars.varCamMeshRough.buPar, out clsMW.varbuCamMeshRoughPars);
		}
		if (Action == actionTypeBU.camJewel3AXTriMeshParalelCut)
		{
			clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamMeshParelelCut.mwPar, buMWJewelVars.varCamMeshParelelCut.buPar, out clsMW.varbuCamMeshParallelPars);
		}
		if (Action == actionTypeBU.camJewel3AXTriMeshConstantZ)
		{
			clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamMeshConstantZ.mwPar, buMWJewelVars.varCamMeshConstantZ.buPar, out clsMW.varbuCamMeshConstantZPars);
		}
		if (ccVars.MaterialList.Count > 0 && ccVars.MaterialList[clsVar.varInterface.MaterialIndex].Enable)
		{
			MWCalcoptions.CheckBoxBounding = true;
			MWCalcoptions.BoxBoundingMin.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.X;
			MWCalcoptions.BoxBoundingMin.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.Y;
			MWCalcoptions.BoxBoundingMin.Z = 0.0;
			MWCalcoptions.BoxBoundingMax.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.X;
			MWCalcoptions.BoxBoundingMax.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.Y;
			MWCalcoptions.BoxBoundingMax.Z = 0.0;
		}
		camResult Result = null;
		int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, Tool, ref Cam, ref Result);
		if (Result.Errors.Count <= 0)
		{
			if (Action == actionTypeBU.camJewel3AXTriMeshRough)
			{
				buMWJewelVars.varCamMeshRough.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWJewelVars.varCamMeshRough.buPar);
			}
			if (Action == actionTypeBU.camJewel3AXTriMeshParalelCut)
			{
				buMWJewelVars.varCamMeshParelelCut.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWJewelVars.varCamMeshParelelCut.buPar);
			}
			if (Action == actionTypeBU.camJewel3AXTriMeshConstantZ)
			{
				buMWJewelVars.varCamMeshConstantZ.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWJewelVars.varCamMeshConstantZ.buPar);
			}
			if (num >= 1)
			{
				Cam.Mode = MWCalcoptions.Mode;
				Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
				Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
				Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
				Cam.Action = Action;
				if (MWCalcoptions.Mode == CamMode.TriangularMesh)
				{
					buString5.AddToArrayList(ccVars.PostActive.JewellaryTriangleMesh3AXPreCodes, ref Cam.PreCodes);
					for (int i = 0; i <= Cam.Tool.ToolNext.Count - 1; i++)
					{
						if (Cam.Tool.ToolNext[i].ToString().Trim().Length > 0)
						{
							Cam.AfterCodes.Add(Cam.Tool.ToolNext[i].ToString().Trim());
						}
					}
					buString5.AddToArrayList(ccVars.PostActive.JewellaryTriangleMesh3AXAfterCodes, ref Cam.AfterCodes);
					for (int j = 0; j <= Cam.Tool.ToolPre.Count - 1; j++)
					{
						if (Cam.Tool.ToolPre[j].ToString().Trim().Length > 0)
						{
							Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[j].ToString().Trim());
						}
					}
					if (MWCalcoptions.AddToCamListInLocalCalculation)
					{
						clsInit.appCommand.CamAdd(Cam);
					}
				}
				clsInit.appCommand.Reset();
				clsFiles.SaveParameter();
				return 1;
			}
			clsInit.appCommand.Reset();
			return num;
		}
		F_ErrorList f_ErrorList = new F_ErrorList();
		f_ErrorList.Init(Result.Errors);
		f_ErrorList.ShowDialog();
		clsInit.appCommand.Reset();
		return -2;
	}

	public int doDrill(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, actionTypeBU Action, ref camTp Cam)
	{
		Cam = new camTp();
		if (Action == actionTypeBU.camJewel3AXPunch)
		{
			clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireDrill.mwPar, buMWJewelVars.varCamWireDrill.buPar, out clsMW.varbuCamDrillPars);
		}
		if (Action == actionTypeBU.camJewel4AXPunch)
		{
			clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireDrill4X.mwPar, buMWJewelVars.varCamWireDrill4X.buPar, out clsMW.varbuCamDrillPars);
		}
		if (Action == actionTypeBU.camJewel4AXPointRotation)
		{
			clsMW.varMWCamDrillPars = buMWCalcs.CopyCamParameter(buMWJewelVars.varCamWireDrill4X.mwPar, buMWJewelVars.varCamWireDrill4X.buPar, out clsMW.varbuCamDrillPars);
		}
		if (ccVars.MaterialList.Count > 0 && ccVars.MaterialList[clsVar.varInterface.MaterialIndex].Enable)
		{
			MWCalcoptions.CheckBoxBounding = true;
			MWCalcoptions.BoxBoundingMin.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.X;
			MWCalcoptions.BoxBoundingMin.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMinPoint.Y;
			MWCalcoptions.BoxBoundingMin.Z = 0.0;
			MWCalcoptions.BoxBoundingMax.X = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.X;
			MWCalcoptions.BoxBoundingMax.Y = ccVars.MaterialList[clsVar.varInterface.MaterialIndex].BoxMaxPoint.Y;
			MWCalcoptions.BoxBoundingMax.Z = 0.0;
		}
		camResult Result = null;
		int num = clsInit.appMW.doDrill(MWCalcoptions, Tool, ref Cam, ref Result);
		if (Result.Errors.Count <= 0)
		{
			if (Action == actionTypeBU.camJewel3AXPunch)
			{
				buMWJewelVars.varCamWireDrill.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWJewelVars.varCamWireDrill.buPar);
			}
			if (Action == actionTypeBU.camJewel4AXPunch)
			{
				buMWJewelVars.varCamWireDrill4X.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWJewelVars.varCamWireDrill4X.buPar);
			}
			if (Action == actionTypeBU.camJewel4AXPointRotation)
			{
				buMWJewelVars.varCamWireDrill4X.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamDrillPars, clsMW.varbuCamDrillPars, out buMWJewelVars.varCamWireDrill4X.buPar);
			}
			if (num >= 1)
			{
				Cam.Mode = MWCalcoptions.Mode;
				Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
				Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
				Cam.CamDrillType = MWCalcoptions.CamDrillType;
				Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
				Cam.Action = Action;
				if (MWCalcoptions.Mode == CamMode.Drill)
				{
					if (MWCalcoptions.NumberofAxis == 4)
					{
						buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill4AXPreCodes, ref Cam.PreCodes);
						for (int i = 0; i <= Cam.Tool.ToolNext.Count - 1; i++)
						{
							if (Cam.Tool.ToolNext[i].ToString().Trim().Length > 0)
							{
								Cam.AfterCodes.Add(Cam.Tool.ToolNext[i].ToString().Trim());
							}
						}
						buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill4AXAfterCodes, ref Cam.AfterCodes);
						for (int j = 0; j <= Cam.Tool.ToolPre.Count - 1; j++)
						{
							if (Cam.Tool.ToolPre[j].ToString().Trim().Length > 0)
							{
								Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[j].ToString().Trim());
							}
						}
						clsInit.appCommand.CamAdd(Cam);
					}
					if (MWCalcoptions.NumberofAxis == 3)
					{
						buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill3AXPreCodes, ref Cam.PreCodes);
						for (int k = 0; k <= Cam.Tool.ToolNext.Count - 1; k++)
						{
							if (Cam.Tool.ToolNext[k].ToString().Trim().Length > 0)
							{
								Cam.AfterCodes.Add(Cam.Tool.ToolNext[k].ToString().Trim());
							}
						}
						buString5.AddToArrayList(ccVars.PostActive.JewellaryDrill3AXAfterCodes, ref Cam.AfterCodes);
						for (int l = 0; l <= Cam.Tool.ToolPre.Count - 1; l++)
						{
							if (Cam.Tool.ToolPre[l].ToString().Trim().Length > 0)
							{
								Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[l].ToString().Trim());
							}
						}
						if (MWCalcoptions.AddToCamListInLocalCalculation)
						{
							clsInit.appCommand.CamAdd(Cam);
						}
					}
				}
				clsInit.appCommand.Reset();
				clsFiles.SaveParameter();
				return 1;
			}
			clsInit.appCommand.Reset();
			return num;
		}
		F_ErrorList f_ErrorList = new F_ErrorList();
		f_ErrorList.Init(Result.Errors);
		f_ErrorList.ShowDialog();
		clsInit.appCommand.Reset();
		return -2;
	}

	public int doLathe(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, actionTypeBU Action, ref camTp Cam)
	{
		Cam = new camTp();
		List<Entity> selectedEntities = new List<Entity>();
		SelectionOption option = new SelectionOption();
		clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		new Point3D();
		SortbuSettings sortbuSettings = new SortbuSettings();
		SortbuResult Result = new SortbuResult();
		sortbuSettings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
		sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
		new List<Entity>();
		List<buEntity> copiedEntities = new List<buEntity>();
		List<buEntity> SortedEntities = new List<buEntity>();
		buEntity.Copy(selectedEntities, ref copiedEntities);
		clsInit.cVector5.BoxSizeCalculate(copiedEntities, ref MinPoint, ref MaxPoint);
		Point3D refPoint = new Point3D();
		double num = double.MinValue;
		for (int i = 0; i <= copiedEntities.Count - 1; i++)
		{
			if (!(copiedEntities[i].StartPoint.X > copiedEntities[i].EndPoint.X))
			{
				if (copiedEntities[i].EndPoint.X > num)
				{
					refPoint = buVector5.ToPoint3D(copiedEntities[i].EndPoint);
				}
			}
			else if (copiedEntities[i].StartPoint.X > num)
			{
				refPoint = buVector5.ToPoint3D(copiedEntities[i].StartPoint);
			}
		}
		clsInit.cVector5.SortEntitiesByRefPoint(refPoint, ref copiedEntities, sortbuSettings, ref SortedEntities, ref Result);
		MarbleItemSettings varSettings = new MarbleItemSettings();
		F_MarbleLathe f_MarbleLathe = new F_MarbleLathe();
		f_MarbleLathe.varSettings = varSettings;
		f_MarbleLathe.Init();
		f_MarbleLathe.ShowDialog();
		if (f_MarbleLathe.Properties.Result == DialogResult.OK)
		{
			varSettings = f_MarbleLathe.varSettings;
			Entity entSureface = null;
			List<Point3D> list = new List<Point3D>();
			for (int j = 0; j <= SortedEntities.Count - 1; j++)
			{
				List<Point3D> pntDevided = new List<Point3D>();
				clsInit.cVector5.EntityDevideByCamDir(SortedEntities[j], 1.0, ref pntDevided);
				list.AddRange(pntDevided);
			}
			clsInit.cVector5.SurfaceExturudeByPoints(list, Vector3D.AxisY, 2.0, ref entSureface);
			Cam = new camTp();
			MWCalcoptions = new MWCalculationOptions();
			MWCalcoptions.NumberofAxis = 3;
			MWCalcoptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
			MWCalcoptions.Mode = CamMode.TriangularMesh;
			MWCalcoptions.isRough = true;
			MWCalcoptions.DontApplyReset = true;
			MWCalcoptions.AddToCamListInLocalCalculation = false;
			MWCalcoptions.AddToCamListInMWCalculation = false;
			MWCalcoptions.DontShowbuDialogBox = true;
			ToolBase5 toolBase = new ToolBase5();
			toolBase.Geometry.Diameter = ccVars.toolActive.Geometry.Thickness;
			toolBase.Geometry.Length = 500.0;
			toolBase.Geometry.GeometryType = ToolType.Flat;
			buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.ParallelMachAngleInYX = 90.0;
			buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.ApproachFeedPlaneIncremental = 0.0;
			buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.FeedPlaneIncremental = 0.0;
			buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.RetractPlaneIncremental = 0.0;
			buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.ClearancePlaneHeight = 100.0;
			buMWJewelVars.varCamMeshParelelCut.mwPar.MachParam.LinkParams.AirMoveSafetyDistance = 0.0;
			clsMW.CamEntities.Add(entSureface);
			entSureface.Regen(0.01);
			entSureface.Translate(0.0, 0.0, 0.0 - entSureface.BoxMax.Z);
			camTpPoint camTpPoint2 = new camTpPoint();
			List<Point3D> list2 = new List<Point3D>();
			MWCalcoptions.DontShowDialogBox = true;
			Cam = new camTp();
			doTriangleMesh(MWCalcoptions, toolBase, actionTypeBU.camJewel3AXTriMeshParalelCut, ref Cam);
			List<Point3D> Points = new List<Point3D>();
			if (Cam.EntitiesG1Orj.Count > 0)
			{
				for (int k = 0; k <= Cam.EntitiesG1Orj.Count - 1; k++)
				{
					for (int l = 0; l <= Cam.EntitiesG1Orj[k].Vertices.Length - 1; l++)
					{
						Points.Add(buVector5.ToPoint3D(Cam.EntitiesG1Orj[k].Vertices[l]));
					}
				}
			}
			if (Points.Count >= 2)
			{
				Points[0] = new Point3D(Points[0].X, Points[0].Y, entSureface.BoxMax.Z + varSettings.settingLatheCut.LatheSafeDistance);
				Points[Points.Count - 1] = new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, entSureface.BoxMax.Z + varSettings.settingLatheCut.LatheSafeDistance);
				if (varSettings.settingLatheCut.LatheDirection == MarbleLatheDirection.MaxToMin)
				{
					Points.Reverse();
				}
				clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
				if (Points.Count >= 2)
				{
					for (int m = 0; m <= Points.Count - 1; m++)
					{
						int type = 1;
						if (m == 0)
						{
							type = 0;
						}
						if (m == Points.Count - 1)
						{
							type = 0;
						}
						TpPnt9D item = new TpPnt9D(new Pnt6D(Points[m].X, 0.0, Points[m].Z), varSettings.settingLatheCut.LatheCutFeed, type);
						camTpPoint2.Points.Add(item);
					}
					list2.AddRange(Points);
				}
			}
			for (double num2 = entSureface.BoxMax.Z; num2 >= entSureface.BoxMin.Z; num2 -= 2.0)
			{
			}
			new List<Entity>();
			Cam.EntitiesG1.Clear();
			Cam.EntitiesG1.Add(new LinearPath(list2));
			Cam.CamPoints.Clear();
			Cam.CamPoints.Add(camTpPoint2);
			Cam.SimilationPoint.SimMove.Clear();
			clsInit.cCam5.SimPointCreatForDetailedPoints(camTpPoint2.Points, 0.25, 0.1, 3.0, 30.0, ref Cam.SimilationPoint);
			Cam.Mode = CamMode.WireFrame;
			Cam.CamWireframeType = CamWireFrameType.Contour;
			Cam.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
			Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
			Cam.Action = Action;
			clsInit.appCommand.CamAdd(Cam);
			_ = ccVars.Pages[ccVars.PageIndex].Cams.Count;
			clsInit.appCommand.Reset();
			clsFiles.SaveParameter();
			return 1;
		}
		return -1;
	}
}
