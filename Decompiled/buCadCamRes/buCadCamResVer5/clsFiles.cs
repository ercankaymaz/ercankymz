using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buCadCamResVer5.Nesting;
using buCadCamResVer5.Spinning;
using buClass;
using buClass.UserFiles.buCad;
using buControls.Forms.WinControlForms.AlarmWarning;
using buControls.Forms.WinControlForms.CAM;
using buControls.Forms.WinControlForms.ClassForm;
using buControls.Forms.WinControlForms.Command;
using buControls.Forms.WinControlForms.Coordinate;
using buControls.Forms.WinControlForms.Diemaker;
using buControls.Forms.WinControlForms.Drawings;
using buControls.Forms.WinControlForms.Events;
using buControls.Forms.WinControlForms.File;
using buControls.Forms.WinControlForms.Helps;
using buControls.Forms.WinControlForms.Kinematic;
using buControls.Forms.WinControlForms.Library;
using buControls.Forms.WinControlForms.License;
using buControls.Forms.WinControlForms.Machine;
using buControls.Forms.WinControlForms.Marble;
using buControls.Forms.WinControlForms.Materials;
using buControls.Forms.WinControlForms.Notepad;
using buControls.Forms.WinControlForms.Osnap;
using buControls.Forms.WinControlForms.Progress;
using buControls.Forms.WinControlForms.Report;
using buControls.Forms.WinControlForms.Settings;
using buControls.Forms.WinControlForms.Tools;
using buControls.Forms.WinControlForms.Views;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.CamForms;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;

namespace buCadCamResVer5;

public class clsFiles
{
	public static string sClass;

	public static Design modelCommon;

	public clsFiles()
	{
		if (!clsSystem.smethod_0("clsFiles"))
		{
			throw new RegisterException("clsFiles");
		}
	}

	public static void OpenRuntimeAndConfig(bool UsePathFromUserInfo, bool MW)
	{
		string method = "OpenRunAndCfg";
		buLogVer5.addToList(sClass, method, "RunCfg", "Started");
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base);
		if (!directoryInfo.Exists)
		{
			AppPath.Base = Application.StartupPath;
		}
		buLogVer5.addToList(sClass, method, "Command Init", "Mode 0010");
		clsCommand.Init();
		AppPath.Settings = AppPath.Base + "\\Settings";
		directoryInfo = new DirectoryInfo("D:\\Icons\\AppGif");
		if (!directoryInfo.Exists)
		{
			AppPath.Gif = AppPath.Base + "\\Gif";
		}
		AppPath.Language = AppPath.Base + "\\Language";
		AppPath.Image = AppPath.Base + "\\Images";
		AppPath.Job = AppPath.Base + "\\Job";
		AppPath.Backup = AppPath.Base + "\\Backup";
		AppPath.Parameter = AppPath.Base + "\\Parameter";
		AppPath.DefaultParameter = AppPath.Base + "\\Default";
		AppPath.Kinematic = AppPath.Base + "\\Kinematics";
		AppPath.PostProcessor = AppPath.Base + "\\PostProcessors";
		AppPath.User = AppPath.Base;
		AppPath.Cam = AppPath.Base + "\\Cam";
		AppPath.Record = AppPath.Base + "\\Records";
		AppPath.Misc = AppPath.Base + "\\Misc";
		AppPath.Materials = AppPath.Base + "\\Materials";
		AppPath.Counter = AppPath.Base + "\\Counter";
		AppPath.MachineSimConfig = AppPath.Base + "\\MachineData";
		AppPath.Help = AppPath.Base + "\\Help";
		AppPath.HelpImages = AppPath.Base + "\\Help\\Images";
		AppPath.Exception = AppPath.Base + "\\Exception";
		AppPath.ImageFlag = AppPath.Image + "\\Flags";
		buSystem.fileNameException = AppPath.Base + "\\buException.csv";
		buSystem.fileNameLog = AppPath.Base + "\\buLog.csv";
		buSystem.fileUndo = AppPath.Base + "\\buUndo.und";
		if (clsVar.appModes_0.DeveloperPCMode && UsePathFromUserInfo)
		{
			AppPath.User = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode;
			AppPath.Image = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode;
			AppPath.Settings = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode + "\\Settings";
			AppPath.DefaultParameter = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode + "\\Default";
			AppPath.MachineSimConfig = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode + "\\MachineData";
			AppPath.Kinematic = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode + "\\Kinematic";
			AppSecurity.PasswordLevel = 10;
		}
		if (clsVar.appModes_0.DeveloperPCMode)
		{
			AppPath.Help = "D:\\PCProjects\\Generation5\\CommonFolder\\Help";
			AppPath.HelpImages = "D:\\PCProjects\\Generation5\\CommonFolder\\Help\\Images";
		}
		AppPath.Texture = AppPath.Base + "\\Textures";
		buLogVer5.addToList(sClass, method, "Defination", "BasePath", AppPath.Base);
		buLogVer5.addToList(sClass, method, "Defination", "SettingPath", AppPath.Settings);
		buLogVer5.addToList(sClass, method, "Defination", "LanguagePath", AppPath.Language);
		buLogVer5.addToList(sClass, method, "Defination", "ImagePath", AppPath.Image);
		buLogVer5.addToList(sClass, method, "Defination", "JobPath", AppPath.Job);
		buLogVer5.addToList(sClass, method, "Defination", "BackupPath", AppPath.Backup);
		buLogVer5.addToList(sClass, method, "Defination", "KinematicPath", AppPath.Kinematic);
		buLogVer5.addToList(sClass, method, "Defination", "PostProcessorPath", AppPath.PostProcessor);
		buLogVer5.addToList(sClass, method, "Defination", "UserPath", AppPath.User);
		buLogVer5.addToList(sClass, method, "Defination", "CamPath", AppPath.Cam);
		buLogVer5.addToList(sClass, method, "Defination", "MiscPath", AppPath.Misc);
		buLogVer5.addToList(sClass, method, "Defination", "MaterialsPath", AppPath.Materials);
		buLogVer5.addToList(sClass, method, "Defination", "CounterPath", AppPath.Counter);
		buLogVer5.addToList(sClass, method, "Defination", "MachineSimConfigPath", AppPath.MachineSimConfig);
		buLogVer5.addToList(sClass, method, "Defination", "DefaultParameterPath", AppPath.DefaultParameter);
		buLogVer5.addToList(sClass, method, "Defination", "HelpPath", AppPath.Help);
		buLogVer5.addToList(sClass, method, "Defination", "Help ImagesPath", AppPath.HelpImages);
		FileInfo fileInfo = new FileInfo(AppPath.Base + "\\_offline.dll");
		if (fileInfo.Exists)
		{
			AppBool.Offline = true;
		}
		buLogVer5.addToList(sClass, method, "Offline", "Mode 0013", AppBool.Offline.ToString());
		fileInfo = new FileInfo(AppPath.Base + "\\_DontWritePLC.dll");
		if (fileInfo.Exists)
		{
			AppBool.DontWriteParameters = true;
			buLogVer5.addToList(sClass, method, "DontWrite", "Mode 0013_1", AppBool.Offline.ToString());
		}
		string fileName = AppPath.Settings + "\\Runtime.prm";
		fileInfo = new FileInfo(fileName);
		buLogVer5.addToList(sClass, method, "Runtime.Prm", "Mode 0014", fileInfo.Exists.ToString());
		if (!fileInfo.Exists)
		{
			buLogVer5.addToList(sClass, method, "RuntimeFile", "Missing", fileInfo.Exists.ToString());
			MessageBox.Show("Main Program Runtime Parameter File Missing");
		}
		else
		{
			ArrayList arrayList = new ArrayList();
			TextReader textReader = File.OpenText(fileInfo.FullName);
			string text = "";
			while ((text = textReader.ReadLine()) != null)
			{
				arrayList.Add(text);
			}
			textReader.Close();
			try
			{
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varRuntime);
				buLogVer5.addToList(sClass, method, "RuntimeFile", "Decoded", fileInfo.Exists.ToString());
				AppLanguage.SelectedLanguage = clsVar.varRuntime.Language;
			}
			catch (Exception mSException)
			{
				buLogVer5.addToList(sClass, method, "RuntimeFile", "Exception", fileInfo.Exists.ToString());
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Parameter Open");
			}
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\_psw.cspass");
		if (fileInfo.Exists)
		{
			OpenPassword(fileInfo.FullName, 2.0);
		}
		AppPath.Machine = AppPath.Base + "\\Machines\\" + clsVar.varRuntime.MachineID;
		AppPath.MachineJob = AppPath.Machine + "\\Job";
		AppPath.MachineBackup = AppPath.Machine + "\\Backup";
		AppPath.MachineCounter = AppPath.Machine + "\\Counter";
		AppPath.MachineImage = AppPath.Machine + "\\Images";
		AppPath.MachineKinematic = AppPath.Machine + "\\Kinematics";
		AppPath.MachineLanguage = AppPath.Machine + "\\Language";
		AppPath.MachinePostProcessor = AppPath.Machine + "\\PostProcessors";
		AppPath.MachineSettings = AppPath.Machine + "\\Settings";
		AppPath.MachineSettingsCam = AppPath.Machine + "\\Settings\\Cam";
		AppPath.MachineTool = AppPath.Machine + "\\Tool";
		AppPath.MachineMachineData = AppPath.Machine + "\\MachineData";
		buLogVer5.addToList(sClass, method, "Defination", "MachinePath", AppPath.Machine);
		buLogVer5.addToList(sClass, method, "Defination", "MachineJobPath", AppPath.MachineJob);
		buLogVer5.addToList(sClass, method, "Defination", "MachineBackupPath", AppPath.MachineBackup);
		buLogVer5.addToList(sClass, method, "Defination", "MachineCounterPath", AppPath.MachineCounter);
		buLogVer5.addToList(sClass, method, "Defination", "MachineImagePath", AppPath.MachineImage);
		buLogVer5.addToList(sClass, method, "Defination", "MachineKinematicPath", AppPath.MachineKinematic);
		buLogVer5.addToList(sClass, method, "Defination", "MachineLanguagePath", AppPath.MachineLanguage);
		buLogVer5.addToList(sClass, method, "Defination", "MachinePostProcessorPath", AppPath.MachinePostProcessor);
		buLogVer5.addToList(sClass, method, "Defination", "MachineSettingsPath", AppPath.MachineSettings);
		buLogVer5.addToList(sClass, method, "Defination", "MachineSettingsCamPath", AppPath.MachineSettingsCam);
		buLogVer5.addToList(sClass, method, "Defination", "MachineToolPath", AppPath.MachineTool);
		buLogVer5.addToList(sClass, method, "Defination", "MachineMachineDataPath", AppPath.MachineMachineData);
		if (clsVar.UserMode.ModuleWork)
		{
			clsCommand.InitCam();
		}
		buVector5.AskMeResult = "";
		buVector5.AskMeValue = 0.0;
		buLogVer5.addToList("clsFile", "OpenRuntime", "MachinePath", AppPath.Machine);
	}

	public static void SaveRuntime()
	{
		string fileName = AppPath.Settings + "\\Runtime.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(clsVar.varRuntime.ToDefAll("", 0, SerilizationMode.MultiLine));
		buFile5.SaveToFile(arrayList, fileName);
	}

	public static void OpenRuntime(string Path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base);
		if (!directoryInfo.Exists)
		{
			AppPath.Base = Application.StartupPath;
		}
		AppPath.Settings = AppPath.Base + "\\Settings";
		string fileName = AppPath.Settings + "\\Runtime.prm";
		FileInfo fileInfo = new FileInfo(fileName);
		if (!fileInfo.Exists)
		{
			buLog.addLog("Runtime File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
			MessageBox.Show("Main Program Runtime Parameter File Missing");
		}
		else
		{
			ArrayList arrayList = new ArrayList();
			TextReader textReader = File.OpenText(fileInfo.FullName);
			string text = "";
			while ((text = textReader.ReadLine()) != null)
			{
				arrayList.Add(text);
			}
			textReader.Close();
			buLog.addLog("Runtime File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
			try
			{
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varRuntime);
				buLog.addLog("Runtime Parameter Decoded Good", "Ok", MethodBase.GetCurrentMethod().Name);
			}
			catch (Exception mSException)
			{
				buLog.addLog("Runtime Parameter Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Parameter Open");
			}
		}
		directoryInfo = new DirectoryInfo(Path);
		clsVar.appModes_0.DeveloperPCMode = false;
		fileInfo = (directoryInfo.Exists ? new FileInfo(directoryInfo.FullName + "\\_finalusermode.dll") : new FileInfo(Application.StartupPath + "\\_finalusermode.dll"));
		if (fileInfo.Exists)
		{
			clsVar.appModes_0.DeveloperPCMode = true;
		}
		AppPath.Gif = AppPath.Base + "\\Gif";
		if (clsVar.appModes_0.DeveloperPCMode)
		{
			AppPath.Base = "D:\\PCProjects\\Generation5\\buCadCamVer5Data";
			AppPath.Gif = "D:\\Icons\\AppGif";
		}
		AppPath.Settings = AppPath.Base + "\\Settings";
		AppPath.Language = AppPath.Base + "\\Language";
		AppPath.Image = AppPath.Base + "\\Images";
		AppPath.Job = AppPath.Base + "\\Job";
		AppPath.Backup = AppPath.Base + "\\Backup";
		AppPath.Parameter = AppPath.Base + "\\Parameter";
		AppPath.Kinematic = AppPath.Base + "\\Kinematics";
		AppPath.PostProcessor = AppPath.Base + "\\PostProcessors";
		AppPath.User = AppPath.Base;
		AppPath.Cam = AppPath.Base + "\\Cam";
		AppPath.Record = AppPath.Base + "\\Records";
		AppPath.Misc = AppPath.Base + "\\Misc";
		AppPath.Materials = AppPath.Base + "\\Materials";
		buSystem.fileNameException = AppPath.Base + "\\buException.csv";
		buSystem.fileNameLog = AppPath.Base + "\\buLog.csv";
		buSystem.fileUndo = AppPath.Base + "\\buUndo.und";
		AppPath.MachineSimConfig = AppPath.Base + "\\MachineData";
		AppPath.Kinematic = AppPath.Base + "\\Kinematic";
		AppPath.Machine = AppPath.Base + "\\Machines";
		if (clsVar.appModes_0.DeveloperPCMode)
		{
			AppPath.User = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode;
			AppPath.Image = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode;
			AppPath.Settings = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode + "\\Settings";
			AppPath.MachineSimConfig = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode + "\\MachineData";
			AppPath.Kinematic = AppPath.Base + "\\UserData\\" + clsVar.appDefination.CustomerInfo + "\\" + clsVar.appDefination.Mode + "\\Kinematic";
		}
	}

	public static void OpenParameter()
	{
		OpenParameter(AppPath.Settings);
	}

	public static void OpenParameter(string Path, bool OnlyCommon = false, bool CamPar = true)
	{
		if (AppBool.MachineMode)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam);
			if (directoryInfo.Exists)
			{
				Path = directoryInfo.FullName;
			}
		}
		string fileName = Path + "\\Program.prm";
		string fileName2 = Path + "\\MetalSpin.prm";
		string fileName3 = Path + "\\CharCurrent.buprm";
		ArrayList arrayList = new ArrayList();
		FileInfo fileInfo = null;
		try
		{
			fileInfo = new FileInfo(AppPath.Settings + "\\CharCurrent.buchar");
			if (!fileInfo.Exists)
			{
				fileInfo = new FileInfo(fileName3);
				if (!fileInfo.Exists)
				{
					buLog.addLog("Char Current File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Char Current File Missing");
				}
				else
				{
					arrayList = new ArrayList();
					buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
					try
					{
						CharLibrary5.Decode(arrayList, ref ccVars.CharLibList);
						if ((ccVars.CharLibList.Count == 0) | (ccVars.CharLibList.Count == 1))
						{
							List<CharLibrary> Chars = new List<CharLibrary>();
							CharLibrary.Decode(arrayList, ref Chars);
							ccVars.CharLibList.Clear();
							for (int i = 0; i <= Chars.Count - 1; i++)
							{
								CharLibrary5 charLibrary = new CharLibrary5();
								charLibrary.Char = Chars[i].Char;
								buEntity.GeoEntitiyToBuEntity(Chars[i].CharEntities, ref charLibrary.CharEntities);
								ccVars.CharLibList.Add(charLibrary);
							}
							arrayList = new ArrayList();
							arrayList.Add("------------------------------------------------------------------------");
							arrayList.Add("   Char Settings");
							arrayList.Add("------------------------------------------------------------------------");
							arrayList.Add("<Char>");
							arrayList.AddRange(CharLibrary5.ToDef(ccVars.CharLibList, 2));
							arrayList.Add("</Char>");
							buFile.SaveToFile(arrayList, fileName3);
						}
					}
					catch (Exception mSException)
					{
						buLog.addLog("Char Current Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
						buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Char Current Decoder Error");
					}
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					CharLibrary5.Decode(arrayList, ref ccVars.CharLibList);
					if ((ccVars.CharLibList.Count == 0) | (ccVars.CharLibList.Count == 1))
					{
						List<CharLibrary> Chars2 = new List<CharLibrary>();
						CharLibrary.Decode(arrayList, ref Chars2);
						ccVars.CharLibList.Clear();
						for (int j = 0; j <= Chars2.Count - 1; j++)
						{
							CharLibrary5 charLibrary2 = new CharLibrary5();
							charLibrary2.Char = Chars2[j].Char;
							buEntity.Copy(charLibrary2.CharEntities, ref charLibrary2.CharEntities);
							ccVars.CharLibList.Add(charLibrary2);
						}
					}
				}
				catch (Exception mSException2)
				{
					buLog.addLog("Char Current Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Char Current Decoder Error");
				}
			}
		}
		catch (Exception)
		{
			buLog.addLog("Char Current Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Char Current Error");
		}
		fileInfo = new FileInfo(fileName);
		if (!fileInfo.Exists)
		{
			buLog.addLog("Program Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Program Settings File Missing");
		}
		else
		{
			arrayList = new ArrayList();
			TextReader textReader = File.OpenText(fileInfo.FullName);
			string text = "";
			while ((text = textReader.ReadLine()) != null)
			{
				arrayList.Add(text);
			}
			textReader.Close();
			buLog.addLog("Program File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
			try
			{
				List<List<string>> CalcList = new List<List<string>>();
				ArrayList CalcList2 = new ArrayList();
				buString.ListToSpecificList("<Materials>", "</Materials>", AddStartEndKey: true, arrayList, ref CalcList2);
				buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", AddStartEndKey: true, CalcList2, ref CalcList);
				for (int k = 0; k <= CalcList.Count - 1; k++)
				{
					ArrayList arrayList2 = new ArrayList();
					arrayList2.AddRange(CalcList[k].ToArray());
					MaterialBase5 materialBase = new MaterialBase5();
					buSerilization5.Decode(arrayList2, "", SerilizationMode5.MultiLine, materialBase);
					ccVars.MaterialList.Add(materialBase);
				}
				CalcList2 = new ArrayList();
				buString.ListToSpecificList("<ActiveMaterial>", "</ActiveMaterial>", AddStartEndKey: true, arrayList, ref CalcList2);
				buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", AddStartEndKey: true, CalcList2, ref CalcList);
				for (int l = 0; l <= CalcList.Count - 1; l++)
				{
					ArrayList arrayList3 = new ArrayList();
					arrayList3.AddRange(CalcList[l].ToArray());
					ccVars.activeMaterial = new MaterialBase5();
					buSerilization5.Decode(arrayList3, "", SerilizationMode5.MultiLine, ccVars.activeMaterial);
				}
				List<string> CalcList3 = new List<string>();
				buString.ListToSpecificList("<ColorList>", "</ColorList>", AddStartEndKey: false, arrayList, ref CalcList3);
				for (int m = 0; m <= CalcList3.Count - 1; m++)
				{
					if (m <= buImage5.ColorList.Count - 1)
					{
						buImage5.ColorList[m] = Color.FromName(CalcList3[m]);
					}
				}
				CalcList = new List<List<string>>();
				CalcList2 = new ArrayList();
				buString.ListToSpecificList("<LayerOptions>", "</LayerOptions>", AddStartEndKey: true, arrayList, ref CalcList2);
				buString.ListToSpecificList("<LayerOverride>", "</LayerOverride>", AddStartEndKey: true, CalcList2, ref CalcList);
				for (int n = 0; n <= CalcList.Count - 1; n++)
				{
					ArrayList arrayList4 = new ArrayList();
					arrayList4.AddRange(CalcList[n].ToArray());
					LayerOverride layerOverride = new LayerOverride();
					buSerilization5.Decode(arrayList4, "", SerilizationMode5.MultiLine, layerOverride);
					ccVars.LayerOptions.Add(layerOverride);
				}
				CalcList = new List<List<string>>();
				List<List<string>> CalcList4 = new List<List<string>>();
				buString.ListToSpecificList("<ToolGroup5>", "</ToolGroup5>", AddStartEndKey: true, arrayList, ref CalcList4);
				for (int num = 0; num <= CalcList4.Count - 1; num++)
				{
					ToolGroup5 toolGroup = new ToolGroup5();
					buSerilization5.Decode(CalcList4[num], "", SerilizationMode5.MultiLine, toolGroup);
					buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", AddStartEndKey: true, CalcList4[num], ref CalcList);
					new List<ToolBase5>();
					for (int num2 = 0; num2 <= CalcList.Count - 1; num2++)
					{
						ArrayList arrayList5 = new ArrayList();
						arrayList5.AddRange(CalcList[num2].ToArray());
						ToolBase5 Tool = new ToolBase5();
						buSerilization5.Decode(arrayList5, "", SerilizationMode5.MultiLine, Tool);
						clsInit.cVector5.ToolTotalLengthCalculate(ref Tool);
						toolGroup.Tools.Add(Tool);
					}
					ccVars.Tools.Add(toolGroup);
				}
				buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsVar.varInterface5);
				buLog.addLog("Interface 5 Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varProgram);
				buLog.addLog("Program Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varSelection);
				buLog.addLog("Selection Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varDisplay);
				buLog.addLog("Display Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varScreen);
				buLog.addLog("Screen Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varPreviewViewport);
				buLog.addLog("Preview Page Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varCam);
				buLog.addLog("Cam Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varFile);
				buLog.addLog("File Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varEntities);
				buLog.addLog("Entities Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varGeometry);
				buLog.addLog("Geometry Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varInterface);
				buLog.addLog("Interface Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varLayer);
				buLog.addLog("Layer Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varLibrary);
				buLog.addLog("Library Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varMainForm);
				buLog.addLog("Main Form Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varMouse);
				buLog.addLog("Mouse Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varSimulation);
				buLog.addLog("Simulation Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "Cad", SerilizationMode.MultiLine, clsVar.varCadEntResolution);
				buLog.addLog("Cad Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "Cam", SerilizationMode.MultiLine, clsVar.varCamCalcResolution);
				buLog.addLog("Cam Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varView);
				buLog.addLog("View Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varCommunication);
				buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsVar.varAutoCadFileProps);
				buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buLog.addLog("Parameter Decoded Good", "Ok", MethodBase.GetCurrentMethod().Name);
				if (clsInit.cMwCalc != null)
				{
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsInit.cMwCalc.Settings);
					buLog.addLog("MW Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				}
				AppPath.ToolHolder = clsVar.varInterface.pathToolHolder;
				AppPath.Tool = clsVar.varInterface.pathTool;
				CalcList.Clear();
			}
			catch (Exception mSException3)
			{
				buLog.addLog("Parameter Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Parameter Open");
			}
		}
		if (clsInit.appMW != null && CamPar)
		{
			clsInit.appMW.OpenMWParameter();
		}
		if (OnlyCommon)
		{
			return;
		}
		fileInfo = new FileInfo(fileName2);
		if (!(fileInfo.Exists & clsVar.appModes_0.MetalSpinningMode.Enable))
		{
			if (clsVar.appModes_0.MetalSpinningMode.Enable)
			{
				buLog.addLog("Spinning Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Spinning Settings File Missing");
			}
		}
		else
		{
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
			try
			{
				ArrayList CalcList5 = new ArrayList();
				buString.ListToSpecificList("<SpinPattern>", "</SpinPattern>", AddStartEndKey: true, arrayList, ref CalcList5);
				if (CalcList5.Count <= 0)
				{
					buLog.addLog("<SpinPattern> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("<SpinPattern> Line Missing");
				}
				else
				{
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsSpinning.varMetalSpinning);
					buLog.addLog("Spinning Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				}
				CalcList5 = new ArrayList();
				buString.ListToSpecificList("<SpinPipePattern>", "</SpinPipePattern>", AddStartEndKey: true, arrayList, ref CalcList5);
				if (CalcList5.Count <= 0)
				{
					buLog.addLog("<SpinPipePattern> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("<SpinPipePattern> Line Missing");
				}
				else
				{
					buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsSpinning.varMetalPipeSpinning);
					buLog.addLog("Spinning Pipe Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				}
			}
			catch (Exception mSException4)
			{
				buLog.addLog("Spinning Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException4, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Tufting Settings Decoder Error");
			}
		}
		if (clsVar.appModes_0.NestingMode.Enable)
		{
			clsInit.appNesting.OpenNestingFile();
		}
		if (clsVar.appModes_0.NestingMode.PanelMode)
		{
			clsInit.appPanelCut.OpenPanelCutFile();
		}
		if (clsVar.appModes_0.CutterMode.Enable)
		{
			clsInit.appCutter.OpenCutterFile();
		}
		if (clsVar.appModes_0.DiemakerMode.Enable)
		{
			clsInit.appDiemaker.OpenDiemakerFile();
		}
		if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
		{
			clsInit.appLaserRouter.OpenLaserFile();
		}
		if (clsVar.appModes_0.PipeBendMode.Enable)
		{
			clsInit.appPipeBending.OpenPipeBendingFile();
		}
		if (clsVar.appModes_0.TuftingMode.Enable)
		{
			clsInit.appTufting.OpenTuftingFile();
		}
		if (clsVar.appModes_0.ProfileMode.Enable)
		{
			clsInit.appProfile.OpenProfileFile();
		}
		if (clsVar.appModes_0.MarbleMode.Enable)
		{
			clsInit.appMarble.OpenMarbleFile();
		}
		if (clsVar.appModes_0.RollerBendMode.Enable)
		{
			clsInit.appRollerBend.OpenRollerBend();
		}
		if (clsVar.appModes_0.RoboticMode.Enable)
		{
			clsInit.appRobotic.OpenRoboticFile();
		}
		if (clsVar.appModes_0.JewelMode.Enable)
		{
			clsInit.appJewel.OpenJewelFile();
		}
		if (clsVar.appModes_0.QuiltingMode.Enable)
		{
			clsInit.appQuilting.OpenQuiltingFile();
		}
		OpenMachineConfig();
	}

	public static void OpenParameterLess(string Path)
	{
		if (AppBool.MachineMode)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam);
			if (directoryInfo.Exists)
			{
				Path = directoryInfo.FullName;
			}
		}
		ArrayList arrayList = new ArrayList();
		FileInfo fileInfo = null;
		try
		{
			fileInfo = new FileInfo(Path + "\\CharCurrent.buprm");
			if (fileInfo.Exists)
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					CharLibrary5.Decode(arrayList, ref ccVars.CharLibList);
					if ((ccVars.CharLibList.Count == 0) | (ccVars.CharLibList.Count == 1))
					{
						List<CharLibrary> Chars = new List<CharLibrary>();
						CharLibrary.Decode(arrayList, ref Chars);
						ccVars.CharLibList.Clear();
						for (int i = 0; i <= Chars.Count - 1; i++)
						{
							CharLibrary5 charLibrary = new CharLibrary5();
							charLibrary.Char = Chars[i].Char;
							buEntity.Copy(charLibrary.CharEntities, ref charLibrary.CharEntities);
							ccVars.CharLibList.Add(charLibrary);
						}
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Char Current Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Char Current Decoder Error");
				}
			}
		}
		catch (Exception)
		{
			buLog.addLog("Char Current Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Char Current Error");
		}
		fileInfo = new FileInfo(Path + "\\Program.prm");
		if (!fileInfo.Exists)
		{
			buLog.addLog("Program Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Program Settings File Missing");
			return;
		}
		arrayList = new ArrayList();
		TextReader textReader = File.OpenText(fileInfo.FullName);
		string text = "";
		while ((text = textReader.ReadLine()) != null)
		{
			arrayList.Add(text);
		}
		textReader.Close();
		buLog.addLog("Program File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
		try
		{
			List<List<string>> CalcList = new List<List<string>>();
			ArrayList CalcList2 = new ArrayList();
			buString.ListToSpecificList("<Materials>", "</Materials>", AddStartEndKey: true, arrayList, ref CalcList2);
			buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", AddStartEndKey: true, CalcList2, ref CalcList);
			for (int j = 0; j <= CalcList.Count - 1; j++)
			{
				ArrayList arrayList2 = new ArrayList();
				arrayList2.AddRange(CalcList[j].ToArray());
				MaterialBase5 materialBase = new MaterialBase5();
				buSerilization5.Decode(arrayList2, "", SerilizationMode5.MultiLine, materialBase);
				ccVars.MaterialList.Add(materialBase);
			}
			CalcList2 = new ArrayList();
			buString.ListToSpecificList("<ActiveMaterial>", "</ActiveMaterial>", AddStartEndKey: true, arrayList, ref CalcList2);
			buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", AddStartEndKey: true, CalcList2, ref CalcList);
			for (int k = 0; k <= CalcList.Count - 1; k++)
			{
				ArrayList arrayList3 = new ArrayList();
				arrayList3.AddRange(CalcList[k].ToArray());
				ccVars.activeMaterial = new MaterialBase5();
				buSerilization5.Decode(arrayList3, "", SerilizationMode5.MultiLine, ccVars.activeMaterial);
			}
			List<string> CalcList3 = new List<string>();
			buString.ListToSpecificList("<ColorList>", "</ColorList>", AddStartEndKey: false, arrayList, ref CalcList3);
			for (int l = 0; l <= CalcList3.Count - 1; l++)
			{
				if (l <= buImage5.ColorList.Count - 1)
				{
					buImage5.ColorList[l] = Color.FromName(CalcList3[l]);
				}
			}
			CalcList = new List<List<string>>();
			CalcList2 = new ArrayList();
			buString.ListToSpecificList("<LayerOptions>", "</LayerOptions>", AddStartEndKey: true, arrayList, ref CalcList2);
			buString.ListToSpecificList("<LayerOverride>", "</LayerOverride>", AddStartEndKey: true, CalcList2, ref CalcList);
			for (int m = 0; m <= CalcList.Count - 1; m++)
			{
				ArrayList arrayList4 = new ArrayList();
				arrayList4.AddRange(CalcList[m].ToArray());
				LayerOverride layerOverride = new LayerOverride();
				buSerilization5.Decode(arrayList4, "", SerilizationMode5.MultiLine, layerOverride);
				ccVars.LayerOptions.Add(layerOverride);
			}
			CalcList = new List<List<string>>();
			List<List<string>> CalcList4 = new List<List<string>>();
			buString.ListToSpecificList("<ToolGroup5>", "</ToolGroup5>", AddStartEndKey: true, arrayList, ref CalcList4);
			for (int n = 0; n <= CalcList4.Count - 1; n++)
			{
				ToolGroup5 toolGroup = new ToolGroup5();
				buSerilization5.Decode(CalcList4[n], "", SerilizationMode5.MultiLine, toolGroup);
				buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", AddStartEndKey: true, CalcList4[n], ref CalcList);
				new List<ToolBase5>();
				for (int num = 0; num <= CalcList.Count - 1; num++)
				{
					ArrayList arrayList5 = new ArrayList();
					arrayList5.AddRange(CalcList[num].ToArray());
					ToolBase5 Tool = new ToolBase5();
					buSerilization5.Decode(arrayList5, "", SerilizationMode5.MultiLine, Tool);
					clsInit.cVector5.ToolTotalLengthCalculate(ref Tool);
					toolGroup.Tools.Add(Tool);
				}
				ccVars.Tools.Add(toolGroup);
			}
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsVar.varInterface5);
			buLog.addLog("Interface 5 Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varProgram);
			buLog.addLog("Program Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varSelection);
			buLog.addLog("Selection Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varDisplay);
			buLog.addLog("Display Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varScreen);
			buLog.addLog("Screen Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varPreviewViewport);
			buLog.addLog("Preview Page Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varCam);
			buLog.addLog("Cam Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varFile);
			buLog.addLog("File Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varEntities);
			buLog.addLog("Entities Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varGeometry);
			buLog.addLog("Geometry Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varInterface);
			buLog.addLog("Interface Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varLayer);
			buLog.addLog("Layer Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varLibrary);
			buLog.addLog("Library Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varMainForm);
			buLog.addLog("Main Form Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varMouse);
			buLog.addLog("Mouse Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varSimulation);
			buLog.addLog("Simulation Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "Cad", SerilizationMode.MultiLine, clsVar.varCadEntResolution);
			buLog.addLog("Cad Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "Cam", SerilizationMode.MultiLine, clsVar.varCamCalcResolution);
			buLog.addLog("Cam Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varView);
			buLog.addLog("View Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsVar.varCommunication);
			buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, clsVar.varAutoCadFileProps);
			buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			buLog.addLog("Parameter Decoded Good", "Ok", MethodBase.GetCurrentMethod().Name);
			if (clsInit.cMwCalc != null)
			{
				buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, clsInit.cMwCalc.Settings);
				buLog.addLog("MW Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			}
			AppPath.ToolHolder = clsVar.varInterface.pathToolHolder;
			AppPath.Tool = clsVar.varInterface.pathTool;
			CalcList.Clear();
		}
		catch (Exception mSException2)
		{
			buLog.addLog("Parameter Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Parameter Open");
		}
	}

	public static void SaveParameter()
	{
		SaveParameter(AppPath.Settings, "");
	}

	public static void SaveParameter(string Path, string FileNameAddStrings, bool OnlyCommon = false, bool CamPar = true)
	{
		try
		{
			if (AppBool.MachineMode)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam);
				if (directoryInfo.Exists)
				{
					Path = directoryInfo.FullName;
				}
			}
			ArrayList arrayList = new ArrayList();
			string text = "";
			string text2 = "";
			string text3 = Path + "\\Program.prm";
			if (FileNameAddStrings.Length > 0)
			{
				text3 = Path + "\\Program" + FileNameAddStrings + ".prm";
			}
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Interface Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varInterface.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Interface 5 Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varInterface5.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Materials ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <Materials>");
			for (int i = 0; i <= ccVars.MaterialList.Count - 1; i++)
			{
				arrayList.AddRange(ccVars.MaterialList[i].ToDefAll("", 4, SerilizationMode5.MultiLine));
			}
			arrayList.Add("  </Materials>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Layer Options ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <LayerOptions>");
			for (int j = 0; j <= ccVars.LayerOptions.Count - 1; j++)
			{
				arrayList.AddRange(ccVars.LayerOptions[j].ToDefAll("", 4, SerilizationMode5.MultiLine));
			}
			arrayList.Add("  </LayerOptions>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   ColorList ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <ColorList>");
			for (int k = 0; k <= buImage5.ColorList.Count - 1; k++)
			{
				arrayList.Add(buImage5.ColorList[k].ToKnownColor());
			}
			arrayList.Add("  </ColorList>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Active Material ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <ActiveMaterial>");
			arrayList.AddRange(ccVars.activeMaterial.ToDefAll("", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ActiveMaterial>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Tools ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <Tools>");
			for (int l = 0; l <= ccVars.Tools.Count - 1; l++)
			{
				arrayList.Add("    <ToolGroup5>");
				ArrayList arrayList2 = new ArrayList();
				arrayList2.AddRange(ccVars.Tools[l].ToDefAll("", 6, SerilizationMode5.MultiLine));
				arrayList2.RemoveAt(0);
				arrayList2.RemoveAt(arrayList2.Count - 1);
				arrayList.AddRange(arrayList2);
				for (int m = 0; m <= ccVars.Tools[l].Tools.Count - 1; m++)
				{
					arrayList.AddRange(ccVars.Tools[l].Tools[m].ToDefAll("", 6, SerilizationMode5.MultiLine));
				}
				arrayList.Add("    </ToolGroup5>");
			}
			arrayList.Add("  </Tools>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Form Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varMainForm.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Program Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varProgram.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Program Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varSelection.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varCam.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Display Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varDisplay.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Screen Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varScreen.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Preview PAge Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varPreviewViewport.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   File Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varFile.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Entities Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varEntities.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   View Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varView.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Geometry Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varGeometry.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Layer Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varLayer.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Library Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varLibrary.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Mouse Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varMouse.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Simulation Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varSimulation.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Entities Resolutions");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varCadEntResolution.ToDefAll("Cad", 2, SerilizationMode.MultiLine));
			arrayList.AddRange(clsVar.varCamCalcResolution.ToDefAll("Cam", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Communication Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varCommunication.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   AutoCadFileProps Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varAutoCadFileProps.ToDefAll("", 2, SerilizationMode5.MultiLine));
			if (clsInit.cMwCalc != null)
			{
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.Add("   MW Settings");
				arrayList.Add("------------------------------------------------------------------------");
				arrayList.AddRange(clsInit.cMwCalc.Settings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			}
			buFile.SaveToFile(arrayList, text3);
			if (clsInit.appMW != null && CamPar)
			{
				clsInit.appMW.SaveMWParameter();
			}
			text = buFile.GetPath(text3);
			buFile.getFileNameWithoutExtension(text3);
			text2 = text + "\\CharCurrent.buprm";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Char Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<Char>");
			arrayList.AddRange(CharLibrary5.ToDef(ccVars.CharLibList, 2));
			arrayList.Add("</Char>");
			buFile.SaveToFile(arrayList, text2);
			buLog.addLog("Char Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			if (!OnlyCommon)
			{
				if (clsVar.appModes_0.MetalSpinningMode.Enable)
				{
					text3 = Path + "\\MetalSpin.prm";
					arrayList = new ArrayList();
					arrayList.AddRange(clsSpinning.varMetalSpinning.ToDefAll("", 2, SerilizationMode.MultiLine));
					arrayList.AddRange(clsSpinning.varMetalPipeSpinning.ToDefAll("", 2, SerilizationMode.MultiLine));
					buFile.SaveToFile(arrayList, text3);
					buLog.addLog("Spining Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
				}
				if (clsVar.appModes_0.DiemakerMode.Enable)
				{
					clsInit.appDiemaker.SaveDiemakerFile();
				}
				if (clsVar.appModes_0.NestingMode.Enable)
				{
					clsInit.appNesting.SaveNestingFile();
				}
				if (clsVar.appModes_0.NestingMode.PanelMode)
				{
					clsInit.appPanelCut.SavePanelCutFile();
				}
				if (clsVar.appModes_0.CutterMode.Enable)
				{
					clsInit.appCutter.SaveCutterFile();
				}
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					clsInit.appLaserRouter.SaveLaserFile();
				}
				if (clsVar.appModes_0.PipeBendMode.Enable)
				{
					clsInit.appPipeBending.SavePipeBendingFile();
				}
				if (clsVar.appModes_0.RoboticMode.Enable)
				{
					clsInit.appRobotic.SaveRoboticFile();
				}
				if (clsVar.appModes_0.TuftingMode.Enable)
				{
					clsInit.appTufting.SaveTuftingFile();
				}
				if (clsVar.appModes_0.JewelMode.Enable)
				{
					clsInit.appJewel.SaveJewelFile();
				}
				if (clsVar.appModes_0.QuiltingMode.Enable && clsInit.appQuilting != null)
				{
					clsInit.appQuilting.SaveQuiltingFile();
				}
				SaveMachineConfig();
			}
			arrayList.Clear();
			GC.Collect();
			buLog.addLog("Program File Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog("Program File Not Saved", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void SaveParameterLess(string Path)
	{
		try
		{
			if (AppBool.MachineMode)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam);
				if (directoryInfo.Exists)
				{
					Path = directoryInfo.FullName;
				}
			}
			ArrayList arrayList = new ArrayList();
			string fileName = Path + "\\Program.prm";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Interface Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varInterface.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Interface 5 Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varInterface5.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Materials ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <Materials>");
			for (int i = 0; i <= ccVars.MaterialList.Count - 1; i++)
			{
				arrayList.AddRange(ccVars.MaterialList[i].ToDefAll("", 4, SerilizationMode5.MultiLine));
			}
			arrayList.Add("  </Materials>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Layer Options ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <LayerOptions>");
			for (int j = 0; j <= ccVars.LayerOptions.Count - 1; j++)
			{
				arrayList.AddRange(ccVars.LayerOptions[j].ToDefAll("", 4, SerilizationMode5.MultiLine));
			}
			arrayList.Add("  </LayerOptions>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Active Material ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <ActiveMaterial>");
			arrayList.AddRange(ccVars.activeMaterial.ToDefAll("", 4, SerilizationMode5.MultiLine));
			arrayList.Add("  </ActiveMaterial>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Tools ");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  <Tools>");
			for (int k = 0; k <= ccVars.Tools.Count - 1; k++)
			{
				arrayList.Add("    <ToolGroup5>");
				ArrayList arrayList2 = new ArrayList();
				arrayList2.AddRange(ccVars.Tools[k].ToDefAll("", 6, SerilizationMode5.MultiLine));
				arrayList2.RemoveAt(0);
				arrayList2.RemoveAt(arrayList2.Count - 1);
				arrayList.AddRange(arrayList2);
				for (int l = 0; l <= ccVars.Tools[k].Tools.Count - 1; l++)
				{
					arrayList.AddRange(ccVars.Tools[k].Tools[l].ToDefAll("", 6, SerilizationMode5.MultiLine));
				}
				arrayList.Add("    </ToolGroup5>");
			}
			arrayList.Add("  </Tools>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Form Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varMainForm.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Program Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varProgram.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Program Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varSelection.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varCam.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Display Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varDisplay.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Screen Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varScreen.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Preview PAge Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varPreviewViewport.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   File Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varFile.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Entities Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varEntities.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   View Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varView.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Geometry Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varGeometry.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Layer Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varLayer.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Library Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varLibrary.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Mouse Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varMouse.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Simulation Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varSimulation.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Entities Resolutions");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varCadEntResolution.ToDefAll("Cad", 2, SerilizationMode.MultiLine));
			arrayList.AddRange(clsVar.varCamCalcResolution.ToDefAll("Cam", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Communication Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varCommunication.ToDefAll("", 2, SerilizationMode.MultiLine));
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   AutoCadFileProps Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(clsVar.varAutoCadFileProps.ToDefAll("", 2, SerilizationMode5.MultiLine));
			buFile.SaveToFile(arrayList, fileName);
			fileName = Path + "\\CharCurrent.buprm";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Char Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<Char>");
			arrayList.AddRange(CharLibrary5.ToDef(ccVars.CharLibList, 2));
			arrayList.Add("</Char>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Char Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			arrayList.Clear();
			buLog.addLog("Program File Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog("Program File Not Saved", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void SaveMachineConfig()
	{
		SaveMachineConfig(AppPath.Settings + "\\MachineConfig.prm");
	}

	public static void SaveMachineConfig(string FileName)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<Version>");
		arrayList.Add("  " + Application.ProductVersion + " - R" + clsVar.varRuntime.ReleaseVer);
		arrayList.Add("</Version>");
		arrayList.AddRange(MachineGCodeConfigrasyon.ToDef(clsVar.varMachineGCodeConfig, 0));
		buFile.SaveToFile(arrayList, FileName);
		arrayList.Clear();
	}

	public static void OpenMachineConfig()
	{
		clsFiles.OpenMachineConfig(AppPath.Settings + "\\MachineConfig.prm");
		string method = nameof(OpenMachineConfig);
		string profileFile = buCadCamResVer5.Marble.FiveAxisSafetyProfileStore.GetDefaultFilePath(AppPath.Settings);
		try
		{
			buCadCamResVer5.Marble.FiveAxisSafetyProfile loadedFiveAxisProfile;
			if (!buCadCamResVer5.Marble.FiveAxisSafetyProfileStore.TryLoad(profileFile, out loadedFiveAxisProfile))
			{
				buCadCamResVer5.Marble.FiveAxisPathSafety.ClearConfiguration();
				buLogVer5.addToList(clsFiles.sClass, method, "FiveAxisSafety", "Missing", profileFile);
				return;
			}
			buCadCamResVer5.Marble.FiveAxisPathSafety.Configure(loadedFiveAxisProfile);
			buLogVer5.addToList(clsFiles.sClass, method, "FiveAxisSafety", "Loaded", buCadCamResVer5.Marble.FiveAxisPathSafety.ConfigurationRevision.ToString());
		}
		catch (Exception ex)
		{
			buCadCamResVer5.Marble.FiveAxisPathSafety.ClearConfiguration();
			buLogVer5.addToList(clsFiles.sClass, method, "FiveAxisSafety", "Invalid", profileFile);
			buException.throwException(ex, method, true, "XYZ/ABC machine limits were not activated.");
		}
	}

	public static void OpenMachineConfig(string FileName)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Exists)
		{
			List<string> StringList = new List<string>();
			buFile5.OpenFromFile(FileName, ref StringList);
			MachineGCodeConfigrasyon.Decode(StringList, ref clsVar.varMachineGCodeConfig);
			StringList.Clear();
		}
	}

	public static void OpenLanguageFiles(int LangSelect)
	{
		try
		{
			AppLanguage.Clear();
			FileInfo fileInfo = null;
			FileInfo fileInfo2 = null;
			FileInfo fileInfo3 = null;
			FileInfo fileInfo4 = null;
			FileInfo fileInfo5 = null;
			FileInfo fileInfo6 = null;
			if (clsVar.UserMode.DeveloperPCMode)
			{
				fileInfo = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buCadCam.lng");
				fileInfo2 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buClasses.lng");
				fileInfo6 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buEnum.lng");
				new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buTufting.lng");
				new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buMarble.lng");
				new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buProfile.lng");
				fileInfo3 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buForms.lng");
				fileInfo4 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buNesting.lng");
				new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buGrinding.lng");
				new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buQuilting.lng");
				fileInfo5 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buMotion.lng");
			}
			else
			{
				fileInfo = new FileInfo(AppPath.Language + "\\buCadCam.lng");
				fileInfo2 = new FileInfo(AppPath.Language + "\\buClasses.lng");
				fileInfo6 = new FileInfo(AppPath.Language + "\\buEnum.lng");
				new FileInfo(AppPath.Language + "\\buMarble.lng");
				new FileInfo(AppPath.Language + "\\buTufting.lng");
				new FileInfo(AppPath.Language + "\\buProfile.lng");
				fileInfo3 = new FileInfo(AppPath.Language + "\\buForms.lng");
				fileInfo4 = new FileInfo(AppPath.Language + "\\buNesting.lng");
				new FileInfo(AppPath.Language + "\\buGrinding.lng");
				new FileInfo(AppPath.Language + "\\buQuilting.lng");
				fileInfo5 = new FileInfo(AppPath.Language + "\\buMotion.lng");
			}
			if (!fileInfo.Exists)
			{
				buLogVer5.addToLog("clsFile", "buCadCam.lng", "Cad/Cam Language Loaded", "Ok", -1.0, 0.0);
				buString.MessageBoxError("Language CadCam File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				AppLanguage.CadCamMessages.Clear();
				AppLanguage.CadCamStatus.Clear();
				AppLanguage.CadCamError.Clear();
				AppLanguage.CadCamWarning.Clear();
				AppLanguage.CadCamDynamic.Clear();
				AppLanguage.CadCamCommand.Clear();
				AppLanguage.CadCamInfo.Clear();
				AppLanguage.CadCamSentences.Clear();
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamMessage>", "</CadCamMessage>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamMessages);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamStatus>", "</CadCamStatus>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamError>", "</CadCamError>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamError);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamWarning>", "</CadCamWarning>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamWarning);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamDynamic>", "</CadCamDynamic>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamDynamic);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamCommands>", "</CadCamCommands>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamCommand);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamInfo>", "</CadCamInfo>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamInfo);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CadCamSentences>", "</CadCamSentences>", StringList), clsVar.varRuntime.Language, ref AppLanguage.CadCamSentences);
				StringList.Clear();
				buLogVer5.addToLog("clsFile", "buCadCam.lng", "Cad/Cam Language Loaded", "Ok", -1.0, 0.0);
			}
			if (!fileInfo2.Exists)
			{
				buLogVer5.addToLog("clsFile", "buClass.lng", "buClass Language Loaded", "Ok", -1.0, 0.0);
				buString.MessageBoxError("Language Class File Missing");
			}
			else
			{
				List<string> StringList2 = new List<string>();
				buFile.OpenFromFile(fileInfo2.FullName, ref StringList2);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<FirstEntryType>", "</FirstEntryType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.FirstEntryType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LastExitType>", "</LastExitType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.LastExitType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MoveHandlingAction>", "</MoveHandlingAction>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.MoveHandlingAction);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadInUsage>", "</LeadInUsage>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.LeadInUsage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadOutUsage>", "</LeadOutUsage>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.LeadOutUsage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadInOutUsage>", "</LeadInOutUsage>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.LeadInOutUsage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadParamsType>", "</LeadParamsType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.LeadParamsType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadParamsAxisOrientation>", "</LeadParamsAxisOrientation>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.LeadParamsAxisOrientation);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadExtensionParamsType>", "</LeadExtensionParamsType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.LeadExtensionParamsType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<SharpCorners>", "</SharpCorners>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.SharpCorners);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Offset2dContainmentMethod>", "</Offset2dContainmentMethod>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.Offset2dContainmentMethod);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MultiCutsRoughParamsSortType>", "</MultiCutsRoughParamsSortType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.MultiCutsRoughParamsSortType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsToolPlaneDirTypeFor3Axis>", "</MachiningParamsToolPlaneDirTypeFor3Axis>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsToolPlaneDirTypeFor3Axis);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsMachiningAreaMode>", "</MachiningParamsMachiningAreaMode>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsMachiningAreaMode);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsMachType>", "</MachiningParamsMachType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsMachType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CamOpenContourType>", "</CamOpenContourType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.CamOpenContourType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CamClosedContourType>", "</CamClosedContourType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.CamClosedContourType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<ClockDirectionType>", "</ClockDirectionType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.ClockDirectionType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<WireframeBasedTpCalcParamsRoughType>", "</WireframeBasedTpCalcParamsRoughType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.WireframeBasedTpCalcParamsRoughType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsDirection>", "</MachiningParamsDirection>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsDirection);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<UseRamp>", "</UseRamp>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.UseRamp);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsRampType>", "</TriangleMeshBasedTpCalcParamsRampType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsRampType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsContourPassType>", "</TriangleMeshBasedTpCalcParamsContourPassType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsContourPassType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsFilteringMode>", "</TriangleMeshBasedTpCalcParamsFilteringMode>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsFilteringType>", "</TriangleMeshBasedTpCalcParamsFilteringType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsCornerPegs>", "</TriangleMeshBasedTpCalcParamsCornerPegs>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockOffsetMode>", "</CollCtrlOpStockParamsStockOffsetMode>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockOffsetMode);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockType>", "</CollCtrlOpStockParamsStockType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockAreaLimitOffsetMethod>", "</CollCtrlOpStockParamsStockAreaLimitOffsetMethod>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockAreaLimitOffsetMethod);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockDirection>", "</CollCtrlOpStockParamsStockDirection>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockDirection);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsStockRemainType>", "</MachiningParamsStockRemainType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsStockRemainType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsRoughType>", "</TriangleMeshBasedTpCalcParamsRoughType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<WireframeBasedTpCalcParamsFixtureCurveMode>", "</WireframeBasedTpCalcParamsFixtureCurveMode>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.WireframeBasedTpCalcParamsFixtureCurveMode);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CutterRadiusCompParamsCompensationType>", "</CutterRadiusCompParamsCompensationType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.CutterRadiusCompParamsCompensationType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType>", "</TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsParallelCutsStartCorner>", "</TriangleMeshBasedTpCalcParamsParallelCutsStartCorner>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsParallelCutsStartCorner);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsToolpathOutputType>", "</TriangleMeshBasedTpCalcParamsToolpathOutputType>", StringList2), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsToolpathOutputType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<SortingNextGroupFindRulesType>", "</SortingNextGroupFindRulesType>", StringList2), clsVar.varRuntime.Language, ref buClassLanguage.SortingNextGroupFindRulesType);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<SortingIntersectionRulesType>", "</SortingIntersectionRulesType>", StringList2), clsVar.varRuntime.Language, ref buClassLanguage.SortingIntersectionRulesType);
				StringList2.Clear();
				buLogVer5.addToLog("clsFile", "buClass.lng", "buClass Language Loaded", "Ok", -1.0, 0.0);
			}
			if (!fileInfo6.Exists)
			{
				buLogVer5.addToLog("clsFile", "buEnum.lng", "Enum Language Missing", "NotOk", -1.0, 0.0);
				buString.MessageBoxError("Enum Language File Missing");
			}
			else
			{
				new List<string>();
				buFile.OpenFromFile(fileInfo6.FullName, ref AppLanguage.EnumBase);
				buLogVer5.addToLog("clsFile", "buEnum.lng", "Enum Language Loaded", "Ok", -1.0, 0.0);
			}
			if (!clsVar.appModes_0.Motion)
			{
				if (fileInfo5.Exists)
				{
					List<string> StringList3 = new List<string>();
					buFile.OpenFromFile(fileInfo5.FullName, ref StringList3);
					buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList3), clsVar.varRuntime.Language, ref AppLanguage.SystemMessages);
					buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList3), clsVar.varRuntime.Language, ref AppLanguage.SystemStatus);
					buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Error>", "</Error>", StringList3), clsVar.varRuntime.Language, ref AppLanguage.SystemError);
					buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Warning>", "</Warning>", StringList3), clsVar.varRuntime.Language, ref AppLanguage.SystemWarning);
					buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Dynamic>", "</Dynamic>", StringList3), clsVar.varRuntime.Language, ref AppLanguage.SystemDynamic);
					buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisError>", "</AxisError>", StringList3), clsVar.varRuntime.Language, ref AppLanguage.AxesError);
					buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisWarning>", "</AxisWarning>", StringList3), clsVar.varRuntime.Language, ref AppLanguage.AxesWarning);
					StringList3.Clear();
					buLogVer5.addToLog("clsFile", "buMotion.lng", "buMotion Language Loaded", "Ok", -1.0, 0.0);
				}
			}
			else if (!fileInfo5.Exists)
			{
				buLogVer5.addToLog("clsFile", "buMotion.lng", "buMotion Language Loaded", "Ok", -1.0, 0.0);
				buString.MessageBoxError("Language buMotion File Missing");
			}
			else
			{
				List<string> StringList4 = new List<string>();
				buFile.OpenFromFile(fileInfo5.FullName, ref StringList4);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList4), clsVar.varRuntime.Language, ref AppLanguage.SystemMessages);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList4), clsVar.varRuntime.Language, ref AppLanguage.SystemStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Error>", "</Error>", StringList4), clsVar.varRuntime.Language, ref AppLanguage.SystemError);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Warning>", "</Warning>", StringList4), clsVar.varRuntime.Language, ref AppLanguage.SystemWarning);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Dynamic>", "</Dynamic>", StringList4), clsVar.varRuntime.Language, ref AppLanguage.SystemDynamic);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisError>", "</AxisError>", StringList4), clsVar.varRuntime.Language, ref AppLanguage.AxesError);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisWarning>", "</AxisWarning>", StringList4), clsVar.varRuntime.Language, ref AppLanguage.AxesWarning);
				StringList4.Clear();
				buLogVer5.addToLog("clsFile", "buMotion.lng", "buMotion Language Loaded", "Ok", -1.0, 0.0);
			}
			if (!fileInfo3.Exists)
			{
				buLogVer5.addToLog("clsFile", "buForms.lng", "buForms Language Loaded", "Ok", -1.0, 0.0);
				buString.MessageBoxError("buForm Language Form File Missing");
			}
			else
			{
				List<string> StringList5 = new List<string>();
				buFile.OpenFromFile(fileInfo3.FullName, ref StringList5);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AskLicense>", "</F_AskLicense>", StringList5), clsVar.varRuntime.Language, ref F_AskLicense.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Report>", "</F_Report>", StringList5), clsVar.varRuntime.Language, ref F_Report.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Layer>", "</F_Layer>", StringList5), clsVar.varRuntime.Language, ref F_Layer.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Preview>", "</F_Preview>", StringList5), clsVar.varRuntime.Language, ref buControls.Forms.WinControlForms.Views.F_Preview.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SettingsTreeView>", "</F_SettingsTreeView>", StringList5), clsVar.varRuntime.Language, ref F_SettingsTreeView.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ProgressCalculation>", "</F_ProgressCalculation>", StringList5), clsVar.varRuntime.Language, ref F_ProgressCalculation.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_OsnapSettings>", "</F_OsnapSettings>", StringList5), clsVar.varRuntime.Language, ref F_OsnapSettings.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_LibraryProps>", "</F_LibraryProps>", StringList5), clsVar.varRuntime.Language, ref F_LibraryProps.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Alarm>", "</F_Alarm>", StringList5), clsVar.varRuntime.Language, ref F_Alarm.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CoordsSingleAxis>", "</F_CoordsSingleAxis>", StringList5), clsVar.varRuntime.Language, ref F_CoordsSingleAxis.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MoveXYZ>", "</F_MoveXYZ>", StringList5), clsVar.varRuntime.Language, ref F_MoveXYZ.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Cf2Properties>", "</F_Cf2Properties>", StringList5), clsVar.varRuntime.Language, ref F_Cf2PropertiesList.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Cf2Properties>", "</F_Cf2Properties>", StringList5), clsVar.varRuntime.Language, ref F_DxfPropertiesList.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_About>", "</F_About>", StringList5), clsVar.varRuntime.Language, ref F_About.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Notepad>", "</F_Notepad>", StringList5), clsVar.varRuntime.Language, ref F_Notepad.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CamAll>", "</F_CamAll>", StringList5), clsVar.varRuntime.Language, ref F_Hatch.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Barrel>", "</F_Barrel>", StringList5), clsVar.varRuntime.Language, ref F_Barrel.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CircleCenter>", "</F_CircleCenter>", StringList5), clsVar.varRuntime.Language, ref F_CircleCenter.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Ellipse>", "</F_Ellipse>", StringList5), clsVar.varRuntime.Language, ref F_Ellipse.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Line>", "</F_Line>", StringList5), clsVar.varRuntime.Language, ref F_Line.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Point>", "</F_Point>", StringList5), clsVar.varRuntime.Language, ref F_Point.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Polygon>", "</F_Polygon>", StringList5), clsVar.varRuntime.Language, ref F_Polygon.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Rectangle>", "</F_Rectangle>", StringList5), clsVar.varRuntime.Language, ref F_Rectangle.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RectangleChamfer>", "</F_RectangleChamfer>", StringList5), clsVar.varRuntime.Language, ref F_RectangleChamfer.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RectangleRound>", "</F_RectangleRound>", StringList5), clsVar.varRuntime.Language, ref F_RectangleRound.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Slot>", "</F_Slot>", StringList5), clsVar.varRuntime.Language, ref F_Slot.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Triangle>", "</F_Triangle>", StringList5), clsVar.varRuntime.Language, ref F_Triangle.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_VectorText>", "</F_VectorText>", StringList5), clsVar.varRuntime.Language, ref F_VectorText.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<FWin_Debug>", "</FWin_Debug>", StringList5), clsVar.varRuntime.Language, ref FWin_Debug.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CutAngles>", "</F_CutAngles>", StringList5), clsVar.varRuntime.Language, ref F_CutAngles.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Material>", "</F_Material>", StringList5), clsVar.varRuntime.Language, ref buEyeBaseVer5.Forms.F_Material.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MaterialList>", "</F_MaterialList>", StringList5), clsVar.varRuntime.Language, ref F_MaterialList.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MaterialRectangle>", "</F_MaterialRectangle>", StringList5), clsVar.varRuntime.Language, ref F_MaterialRectangle.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_KinematicBasic>", "</F_KinematicBasic>", StringList5), clsVar.varRuntime.Language, ref F_KinematicBasic.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_KinematicDefine>", "</F_KinematicDefine>", StringList5), clsVar.varRuntime.Language, ref F_KinematicDefine.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MachineSelect>", "</F_MachineSelect>", StringList5), clsVar.varRuntime.Language, ref F_MachineSelect.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MachineTypeAdd>", "</F_MachineTypeAdd>", StringList5), clsVar.varRuntime.Language, ref F_MachineTypeAdd.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_DrawPropertiesType>", "</F_DrawPropertiesType>", StringList5), clsVar.varRuntime.Language, ref F_DrawPropertiesType.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_EntitiyResolution>", "</F_EntitiyResolution>", StringList5), clsVar.varRuntime.Language, ref F_EntitiyResolution.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MouseKeyboardConfig>", "</F_MouseKeyboardConfig>", StringList5), clsVar.varRuntime.Language, ref F_MouseKeyboardConfig.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Pnt3D>", "</F_Pnt3D>", StringList5), clsVar.varRuntime.Language, ref F_Pnt3D.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SimAxisDefination>", "</F_SimAxisDefination>", StringList5), clsVar.varRuntime.Language, ref F_SimAxisDefinition.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Size>", "</F_Size>", StringList5), clsVar.varRuntime.Language, ref F_Size.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SolidItemDisplay>", "</F_SolidItemDisplay>", StringList5), clsVar.varRuntime.Language, ref F_SolidItemDisplay.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_LinearArray>", "</F_LinearArray>", StringList5), clsVar.varRuntime.Language, ref F_LinearArray.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MoveScaleRotate>", "</F_MoveScaleRotate>", StringList5), clsVar.varRuntime.Language, ref F_MoveScaleRotate.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_StockDef>", "</F_StockDef>", StringList5), clsVar.varRuntime.Language, ref F_StockDef.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RoughingAdvanced>", "</F_RoughingAdvanced>", StringList5), clsVar.varRuntime.Language, ref F_RoughingAdvanced.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Roughing>", "</F_Roughing>", StringList5), clsVar.varRuntime.Language, ref F_Roughing.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_DeptStepAdvanced>", "</F_DeptStepAdvanced>", StringList5), clsVar.varRuntime.Language, ref F_DepthStepAdvanced.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Height>", "</F_Height>", StringList5), clsVar.varRuntime.Language, ref F_Height.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_HeightAdvanced>", "</F_HeightAdvanced>", StringList5), clsVar.varRuntime.Language, ref F_HeightAdvanced.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SurfaceQuality>", "</F_SurfaceQuality>", StringList5), clsVar.varRuntime.Language, ref F_SurfaceQuality.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFContourLink>", "</F_WFContourLink>", StringList5), clsVar.varRuntime.Language, ref F_ContourLink.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFRoughLink>", "</F_WFRoughLink>", StringList5), clsVar.varRuntime.Language, ref F_RoughLink.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_DrillLine>", "</F_DrillLine>", StringList5), clsVar.varRuntime.Language, ref F_DrillLine.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFRough>", "</F_WFRough>", StringList5), clsVar.varRuntime.Language, ref F_WFRough.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFContour>", "</F_WFContour>", StringList5), clsVar.varRuntime.Language, ref F_WFContour.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFContour>", "</F_WFContour>", StringList5), clsVar.varRuntime.Language, ref F_WFContour4AX.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFSpin>", "</F_WFSpin>", StringList5), clsVar.varRuntime.Language, ref F_WFSpin.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFLeadControl>", "</F_WFLeadControl>", StringList5), clsVar.varRuntime.Language, ref F_LeadControl.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshRough>", "</F_TriMeshRough>", StringList5), clsVar.varRuntime.Language, ref F_TriMeshRough.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshParallelCut>", "</F_TriMeshParallelCut>", StringList5), clsVar.varRuntime.Language, ref F_TriMeshParallelCut.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshConstantZ>", "</F_TriMeshConstantZ>", StringList5), clsVar.varRuntime.Language, ref F_TriMeshConstantZ.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_2DContainment>", "</F_2DContainment>", StringList5), clsVar.varRuntime.Language, ref F_2DContainment.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AngleRange>", "</F_AngleRange>", StringList5), clsVar.varRuntime.Language, ref F_AngleRange.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Filtering>", "</F_Filtering>", StringList5), clsVar.varRuntime.Language, ref F_Filtering.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Fixtures>", "</F_Fixtures>", StringList5), clsVar.varRuntime.Language, ref F_Fixtures.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MultiPass>", "</F_MultiPass>", StringList5), clsVar.varRuntime.Language, ref F_MultiPass.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ProfilePass>", "</F_ProfilePass>", StringList5), clsVar.varRuntime.Language, ref F_ProfilePass.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RestFinish>", "</F_RestFinish>", StringList5), clsVar.varRuntime.Language, ref F_RestFinish.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RestRough>", "</F_RestRough>", StringList5), clsVar.varRuntime.Language, ref F_RestRough.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RoundCorner>", "</F_RoundCorner>", StringList5), clsVar.varRuntime.Language, ref F_RoundCorner.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Silhouette>", "</F_Silhouette>", StringList5), clsVar.varRuntime.Language, ref F_Silhouette.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshParallelCut>", "</F_TriMeshParallelCut>", StringList5), clsVar.varRuntime.Language, ref F_TriMeshParallelCut.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolDataBase>", "</F_ToolDataBase>", StringList5), clsVar.varRuntime.Language, ref F_ToolDBase.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolDetailed>", "</F_ToolDetailed>", StringList5), clsVar.varRuntime.Language, ref F_ToolDetailed.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolDiemaker>", "</F_ToolDiemaker>", StringList5), clsVar.varRuntime.Language, ref F_ToolDiemaker.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolTypeSaw>", "</F_ToolTypeSaw>", StringList5), clsVar.varRuntime.Language, ref F_ToolTypeSaw.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolType1>", "</F_ToolType1>", StringList5), clsVar.varRuntime.Language, ref F_ToolType1.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BendingItems>", "</F_BendingItems>", StringList5), clsVar.varRuntime.Language, ref F_BendingItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BendMarkItems>", "</F_BendMarkItems>", StringList5), clsVar.varRuntime.Language, ref F_BendMarkItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BridgeItems>", "</F_BridgeItems>", StringList5), clsVar.varRuntime.Language, ref F_BridgeItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BridgeProps>", "</F_BridgeProps>", StringList5), clsVar.varRuntime.Language, ref F_BridgeProps.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BroachItems>", "</F_BroachItems>", StringList5), clsVar.varRuntime.Language, ref F_BroachItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CreasingCornerItems>", "</F_CreasingCornerItems>", StringList5), clsVar.varRuntime.Language, ref F_CreasingCornerItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_HalfBridgeItems>", "</F_HalfBridgeItems>", StringList5), clsVar.varRuntime.Language, ref F_HalfBridgeItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NickItems>", "</F_NickItems>", StringList5), clsVar.varRuntime.Language, ref F_NickItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Offsets>", "</F_Offsets>", StringList5), clsVar.varRuntime.Language, ref F_Offsets.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_PerfoCombiItems>", "</F_PerfoCombiItems>", StringList5), clsVar.varRuntime.Language, ref F_PerfoCombiItems.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RuleSettings>", "</F_RuleSettings>", StringList5), clsVar.varRuntime.Language, ref F_RuleSettings.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SelectAlParts>", "</F_SelectAlParts>", StringList5), clsVar.varRuntime.Language, ref F_SelectAlParts.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Status>", "</F_Status>", StringList5), clsVar.varRuntime.Language, ref F_Status.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TestPage>", "</F_TestPage>", StringList5), clsVar.varRuntime.Language, ref F_TestPage.Captions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolTest>", "</F_ToolTest>", StringList5), clsVar.varRuntime.Language, ref F_ToolTest.Captions);
				StringList5.Clear();
				buLogVer5.addToLog("clsFile", "buForms.lng", "buForms Language Loaded", "Ok", -1.0, 0.0);
			}
			if (clsVar.appModes_0.MarbleMode.Enable && clsInit.appMarble != null)
			{
				clsInit.appMarble.LoadLanguage();
			}
			if (clsVar.appModes_0.ProfileMode.Enable && clsInit.appProfile != null)
			{
				clsInit.appProfile.LoadLanguage();
			}
			if (clsVar.appModes_0.DrillMode.Enable && clsInit.appDrill != null)
			{
				clsInit.appDrill.LoadLanguage();
			}
			if (clsVar.appModes_0.NestingMode.Enable && fileInfo4.Exists && clsInit.appNesting != null)
			{
				clsInit.appNesting.LoadLanguage();
			}
			if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable && clsInit.appLaserRouter != null)
			{
				clsInit.appLaserRouter.LoadLanguage();
			}
			if (clsVar.appModes_0.TuftingMode.Enable && clsInit.appTufting != null)
			{
				clsInit.appTufting.LoadLanguage();
			}
			if (clsVar.appModes_0.QuiltingMode.Enable && clsInit.appQuilting != null)
			{
				clsInit.appQuilting.LoadLanguage();
			}
			if (clsVar.appModes_0.SewingMode.Enable && clsInit.appSewing != null)
			{
				clsInit.appSewing.LoadLanguage();
			}
			if (clsVar.appModes_0.RollerBendMode.Enable && clsInit.appRollerBend != null)
			{
				clsInit.appRollerBend.LoadLanguage();
			}
			buLogVer5.addToLog("clsFile", "OpenLanguageFiles", "Language File Loaded", "Ok", -1.0, 0.0);
			GC.Collect();
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog("clsFile", "OpenLanguageFiles", "Language File Loaded", "Fail", -1.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void OpenMaterials(string Path, ref List<Material> MaterialList)
	{
		List<string> Files = new List<string>();
		buFile5.GetFilesInDirectory(Path, ".bumat", ref Files);
		for (int i = 0; i <= Files.Count - 1; i++)
		{
			List<string> StringList = new List<string>();
			buFile5.OpenFromFile(Files[i], ref StringList);
			string name = "Mats";
			Color ambient = Color.FromArgb(100, 100, 100);
			Color specular = Color.White;
			float environment = 0.01f;
			float shininess = 1f;
			Image image = null;
			linearUnitsType linearUnits = linearUnitsType.Millimeters;
			massUnitsType massUnits = massUnitsType.Kilograms;
			double density = 6E-07;
			float textureLength = 2000f;
			string fileName = Path + "\\" + buFile5.getFileNameWithoutExtension(Files[i]) + ".jpg";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				fileName = Path + "\\" + buFile5.getFileNameWithoutExtension(Files[i]) + ".png";
				fileInfo = new FileInfo(fileName);
				if (fileInfo.Exists)
				{
					image = Image.FromFile(fileInfo.FullName);
				}
			}
			else
			{
				image = Image.FromFile(fileInfo.FullName);
			}
			for (int j = 0; j <= StringList.Count - 1; j++)
			{
				if (StringList[j].ToLower().IndexOf("name") >= 0)
				{
					string[] array = StringList[j].Split('=');
					if (array != null && array.Length >= 2)
					{
						name = array[1].Trim();
					}
				}
				if (StringList[j].ToLower().IndexOf("ambiance") >= 0)
				{
					string[] array2 = StringList[j].Split('=');
					if (array2 != null && array2.Length >= 2)
					{
						string[] array3 = array2[1].Split(',');
						if (array3 != null && array3.Length >= 3)
						{
							int red = int.Parse(array3[0]);
							int green = int.Parse(array3[1]);
							int blue = int.Parse(array3[2]);
							ambient = Color.FromArgb(red, green, blue);
						}
					}
				}
				if (StringList[j].ToLower().IndexOf("specularcolor") >= 0)
				{
					string[] array4 = StringList[j].Split('=');
					if (array4 != null && array4.Length >= 2)
					{
						specular = Color.FromName(array4[1]);
					}
				}
				if (StringList[j].ToLower().IndexOf("shininess") >= 0)
				{
					string[] array5 = StringList[j].Split('=');
					if (array5 != null && array5.Length >= 2)
					{
						shininess = float.Parse(array5[1]);
					}
				}
				if (StringList[j].ToLower().IndexOf("density") >= 0)
				{
					string[] array6 = StringList[j].Split('=');
					if (array6 != null && array6.Length >= 2)
					{
						density = double.Parse(array6[1]);
					}
				}
				if (StringList[j].ToLower().IndexOf("texturelength") >= 0)
				{
					string[] array7 = StringList[j].Split('=');
					if (array7 != null && array7.Length >= 2)
					{
						textureLength = float.Parse(array7[1]);
					}
				}
				if (StringList[j].ToLower().IndexOf("environment") >= 0)
				{
					string[] array8 = StringList[j].Split('=');
					if (array8 != null && array8.Length >= 2)
					{
						environment = float.Parse(array8[1]);
					}
				}
				if (StringList[j].ToLower().IndexOf("linearunits") >= 0)
				{
					string[] array9 = StringList[j].Split('=');
					if (array9 != null && array9.Length >= 2)
					{
						int num = int.Parse(array9[1]);
						linearUnits = (linearUnitsType)num;
					}
				}
				if (StringList[j].ToLower().IndexOf("massunits") >= 0)
				{
					string[] array10 = StringList[j].Split('=');
					if (array10 != null && array10.Length >= 2)
					{
						int num2 = int.Parse(array10[1]);
						massUnits = (massUnitsType)num2;
					}
				}
			}
			if (image != null)
			{
				Material item = new Material(name, ambient, specular, shininess, image.ToByteArray())
				{
					LinearUnits = linearUnits,
					MassUnits = massUnits,
					Density = density,
					TextureLength = textureLength,
					Environment = environment
				};
				MaterialList.Add(item);
			}
		}
	}

	public static void OpenMachineConfig(string FileName, ref MachineDef Machine, MachineConfigSettings Settings)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Exists)
		{
			Machine = new MachineDef();
			buFile5.OpenMachineConfigFile(FileName, ref Machine, Settings);
		}
	}

	public static void OpenMachineConfig(string FileName, ref MachineDef Machine)
	{
		OpenMachineConfig(FileName, ref Machine, new MachineConfigSettings());
	}

	public static void OpenKinematic(string FileName, ref KinematicBase5 Kinematic)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Exists)
		{
			Kinematic = new KinematicBase5();
			buFile5.OpenKinemticFile(FileName, ref Kinematic);
		}
	}

	public static void OpenPassword(string FileName, double Key)
	{
		try
		{
			int num = 0;
			string text = "";
			FileInfo fileInfo = new FileInfo(FileName);
			if (fileInfo.Exists)
			{
				FileStream input = new FileStream(FileName, FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(input);
				num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte value = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass1 = text + Convert.ToChar(value));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int j = 0; j < num; j++)
				{
					byte value2 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass2 = text + Convert.ToChar(value2));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int k = 0; k < num; k++)
				{
					byte value3 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass3 = text + Convert.ToChar(value3));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int l = 0; l < num; l++)
				{
					byte value4 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass4 = text + Convert.ToChar(value4));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int m = 0; m < num; m++)
				{
					byte value5 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass5 = text + Convert.ToChar(value5));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int n = 0; n < num; n++)
				{
					byte value6 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass6 = text + Convert.ToChar(value6));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num2 = 0; num2 < num; num2++)
				{
					byte value7 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass7 = text + Convert.ToChar(value7));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num3 = 0; num3 < num; num3++)
				{
					byte value8 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass8 = text + Convert.ToChar(value8));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num4 = 0; num4 < num; num4++)
				{
					byte value9 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass9 = text + Convert.ToChar(value9));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num5 = 0; num5 < num; num5++)
				{
					byte value10 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
					text = (AppSecurity.Pass10 = text + Convert.ToChar(value10));
				}
				binaryReader.Close();
			}
			buLogVer5.addToList(sClass, "OpenPassword", "Password", "Decoded");
		}
		catch (Exception mSException)
		{
			string auxMessage = "";
			buLogVer5.addToList(sClass, "OpenPassword", "Password", "Exception");
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, auxMessage);
		}
	}

	public bool OpenDefAndKFile()
	{
		BinaryReader binaryReader = null;
		try
		{
			buLogVer5.addToLog("DefK", "Mode 999", "Starts", "", 0.0, 0.0);
			FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
			buLogVer5.addToLog("DefK", "Mode 1000", "mnb", fileInfo.Exists.ToString(), 0.0, 0.0);
			if (fileInfo.Exists)
			{
				if (!fileInfo.Exists)
				{
					buLogVer5.addToLog("DefK", "Mode 1019", "SWK", "Fail", 0.0, 0.0);
					buString.MessageBoxError("Configration File is Missing");
					Environment.Exit(0);
					return false;
				}
				List<double> list = new List<double>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				try
				{
					buLogVer5.addToLog("DefK", "Mode 1001", "mnb", "1", 0.0, 0.0);
					binaryReader = new BinaryReader(new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None));
					string text = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					string text10 = "";
					string text11 = "";
					string text12 = "";
					string text13 = "";
					string text14 = "";
					for (int i = 0; i < 755; i++)
					{
						binaryReader.ReadSingle();
					}
					for (int j = 0; j < 1274; j++)
					{
						binaryReader.ReadDouble();
					}
					for (int k = 0; k < 1498; k++)
					{
						binaryReader.ReadDecimal();
					}
					for (int l = 0; l < 5614; l++)
					{
						binaryReader.ReadInt32();
					}
					for (int m = 0; m < 4243; m++)
					{
						binaryReader.ReadSingle();
					}
					for (int n = 0; n < 9867; n++)
					{
						binaryReader.ReadDouble();
					}
					for (int num = 0; num < 3886; num++)
					{
						binaryReader.ReadDecimal();
					}
					for (int num2 = 0; num2 < 5765; num2++)
					{
						binaryReader.ReadInt32();
					}
					int num3 = binaryReader.ReadInt32();
					list.Clear();
					list2.Clear();
					list3.Clear();
					for (int num4 = 0; num4 <= num3 - 1; num4++)
					{
						double item = binaryReader.ReadDouble() / 65.87;
						list.Add(item);
						int num5 = binaryReader.ReadInt32();
						string text15 = "";
						for (int num6 = 0; num6 < num5; num6++)
						{
							byte value = Convert.ToByte(binaryReader.ReadDouble() / 46.8613);
							text15 += Convert.ToChar(value);
						}
						list2.Add(text15);
						num5 = binaryReader.ReadInt32();
						string text16 = "";
						for (int num7 = 0; num7 < num5; num7++)
						{
							byte value2 = Convert.ToByte(binaryReader.ReadDouble() / 86.3456);
							text16 += Convert.ToChar(value2);
						}
						list3.Add(text16);
					}
					int num8 = binaryReader.ReadInt32();
					for (int num9 = 0; num9 < num8; num9++)
					{
						byte value3 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text += Convert.ToChar(value3);
					}
					num8 = binaryReader.ReadInt32();
					for (int num10 = 0; num10 < num8; num10++)
					{
						byte value4 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text2 += Convert.ToChar(value4);
					}
					num8 = binaryReader.ReadInt32();
					for (int num11 = 0; num11 < num8; num11++)
					{
						byte value5 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text3 += Convert.ToChar(value5);
					}
					num8 = binaryReader.ReadInt32();
					for (int num12 = 0; num12 < num8; num12++)
					{
						byte value6 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text4 += Convert.ToChar(value6);
					}
					num8 = binaryReader.ReadInt32();
					for (int num13 = 0; num13 < num8; num13++)
					{
						byte value7 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text5 += Convert.ToChar(value7);
					}
					num8 = binaryReader.ReadInt32();
					for (int num14 = 0; num14 < num8; num14++)
					{
						byte value8 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text6 += Convert.ToChar(value8);
					}
					num8 = binaryReader.ReadInt32();
					for (int num15 = 0; num15 < num8; num15++)
					{
						byte value9 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text7 += Convert.ToChar(value9);
					}
					num8 = binaryReader.ReadInt32();
					for (int num16 = 0; num16 < num8; num16++)
					{
						byte value10 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text8 += Convert.ToChar(value10);
					}
					num8 = binaryReader.ReadInt32();
					for (int num17 = 0; num17 < num8; num17++)
					{
						byte value11 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
						text9 += Convert.ToChar(value11);
					}
					clsVar.appDefination.Name = text;
					clsVar.appDefination.Type = text2;
					clsVar.appDefination.Description = text3;
					clsVar.appDefination.Vendor = text4;
					clsVar.appDefination.Mode = text5;
					clsVar.appDefination.Web = text6;
					clsVar.appDefination.Aux = text7;
					clsVar.appDefination.CustomerInfo = text8;
					clsVar.appDefination.Command = text9;
					clsVar.appDefination.CustomerID = (AppCustomerID)Convert.ToInt32(Math.Round(binaryReader.ReadDouble() / 164.542, 7));
					double value12 = binaryReader.ReadDouble() / 533.134;
					clsVar.appDefination.AppID = Convert.ToInt32(value12);
					clsVar.appDefination.AppType = (AppDefinationType)Convert.ToInt32(value12);
					clsVar.appModes_0.NumberOfDemoRun = Convert.ToInt32(binaryReader.ReadDouble() / -164.433);
					clsVar.appModes_0.NumberOfDemoOpenFile = Convert.ToInt32(binaryReader.ReadDouble() / 149.124);
					_ = binaryReader.ReadDouble() / 624.56;
					_ = binaryReader.ReadDouble() / 456.34;
					_ = binaryReader.ReadDouble() / 875.14;
					_ = binaryReader.ReadDouble() / 326.98;
					_ = binaryReader.ReadDouble() / 934.67;
					num8 = binaryReader.ReadInt32();
					for (int num18 = 0; num18 < num8; num18++)
					{
						byte value13 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
						text10 += Convert.ToChar(value13);
					}
					num8 = binaryReader.ReadInt32();
					for (int num19 = 0; num19 < num8; num19++)
					{
						byte value14 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
						text11 += Convert.ToChar(value14);
					}
					num8 = binaryReader.ReadInt32();
					for (int num20 = 0; num20 < num8; num20++)
					{
						byte value15 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
						text12 += Convert.ToChar(value15);
					}
					num8 = binaryReader.ReadInt32();
					for (int num21 = 0; num21 < num8; num21++)
					{
						byte value16 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
						text13 += Convert.ToChar(value16);
					}
					num8 = binaryReader.ReadInt32();
					for (int num22 = 0; num22 < num8; num22++)
					{
						byte value17 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
						text14 += Convert.ToChar(value17);
					}
					int day = Convert.ToInt32(binaryReader.ReadDouble() / 624.65423);
					int month = Convert.ToInt32(binaryReader.ReadDouble() / -423.45738);
					int year = Convert.ToInt32(binaryReader.ReadDouble() / 382.19531);
					clsVar.appModes_0.ExpireDateTime = new DateTime(year, month, day);
					clsVar.appModes_0.DemoMode = binaryReader.ReadBoolean();
					clsVar.appModes_0.Mode2D = binaryReader.ReadBoolean();
					clsVar.appModes_0.HardKeyCmdEnable = binaryReader.ReadBoolean();
					clsVar.appModes_0.TimeMode = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.ModuleWork = binaryReader.ReadBoolean();
					clsVar.appModes_0.ExpireModeEnable = binaryReader.ReadBoolean();
					clsVar.appModes_0.HardKeyPowerNestEnable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					_ = binaryReader.ReadDouble() / 167.678;
					_ = binaryReader.ReadDouble() / 84.573;
					_ = binaryReader.ReadDouble() / 205.678;
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.DrawingPage = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.EventPage = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.GrindingMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.GrindingMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.GrindingMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num23 = 0; num23 < num8; num23++)
					{
						byte value18 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value18);
					}
					clsVar.appModes_0.GrindingMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num24 = 0; num24 < num8; num24++)
					{
						byte value19 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value19);
					}
					clsVar.appModes_0.GrindingMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num25 = 0; num25 < num8; num25++)
					{
						byte value20 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value20);
					}
					clsVar.appModes_0.GrindingMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num26 = 0; num26 < num8; num26++)
					{
						byte value21 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value21);
					}
					clsVar.appModes_0.GrindingMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num27 = 0; num27 < num8; num27++)
					{
						byte value22 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value22);
					}
					clsVar.appModes_0.GrindingMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num28 = 0; num28 < num8; num28++)
					{
						byte value23 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value23);
					}
					clsVar.appModes_0.GrindingMode.Mode4Exp = text10;
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.NestingMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.NestingMode.PanelMode = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.NestingMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.NestingMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num29 = 0; num29 < num8; num29++)
					{
						byte value24 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value24);
					}
					clsVar.appModes_0.NestingMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num30 = 0; num30 < num8; num30++)
					{
						byte value25 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value25);
					}
					clsVar.appModes_0.NestingMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num31 = 0; num31 < num8; num31++)
					{
						byte value26 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value26);
					}
					clsVar.appModes_0.NestingMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num32 = 0; num32 < num8; num32++)
					{
						byte value27 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value27);
					}
					clsVar.appModes_0.NestingMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num33 = 0; num33 < num8; num33++)
					{
						byte value28 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value28);
					}
					clsVar.appModes_0.NestingMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num34 = 0; num34 < num8; num34++)
					{
						byte value29 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value29);
					}
					clsVar.appModes_0.NestingMode.Mode4Exp = text10;
					clsVar.appModes_0.JewelMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.JewelMode.FreeForm = binaryReader.ReadBoolean();
					clsVar.appModes_0.JewelMode.Drawing = binaryReader.ReadBoolean();
					clsVar.appModes_0.JewelMode.EllipseForm = binaryReader.ReadBoolean();
					clsVar.appModes_0.JewelMode.Lathe = binaryReader.ReadBoolean();
					clsVar.appModes_0.JewelMode.FlatMode = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.JewelMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.JewelMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num35 = 0; num35 < num8; num35++)
					{
						byte value30 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value30);
					}
					clsVar.appModes_0.JewelMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num36 = 0; num36 < num8; num36++)
					{
						byte value31 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value31);
					}
					clsVar.appModes_0.JewelMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num37 = 0; num37 < num8; num37++)
					{
						byte value32 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value32);
					}
					clsVar.appModes_0.JewelMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num38 = 0; num38 < num8; num38++)
					{
						byte value33 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value33);
					}
					clsVar.appModes_0.JewelMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num39 = 0; num39 < num8; num39++)
					{
						byte value34 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value34);
					}
					clsVar.appModes_0.JewelMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num40 = 0; num40 < num8; num40++)
					{
						byte value35 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value35);
					}
					clsVar.appModes_0.JewelMode.Mode4Exp = text10;
					clsVar.appModes_0.CompositeMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.CompositeMode.MeshEnabled = binaryReader.ReadBoolean();
					clsVar.appModes_0.CompositeMode.MeshAdvanced = binaryReader.ReadBoolean();
					clsVar.appModes_0.CompositeMode.Surface5Axis = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.CompositeMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.CompositeMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num41 = 0; num41 < num8; num41++)
					{
						byte value36 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value36);
					}
					clsVar.appModes_0.CompositeMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num42 = 0; num42 < num8; num42++)
					{
						byte value37 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value37);
					}
					clsVar.appModes_0.CompositeMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num43 = 0; num43 < num8; num43++)
					{
						byte value38 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value38);
					}
					clsVar.appModes_0.CompositeMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num44 = 0; num44 < num8; num44++)
					{
						byte value39 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value39);
					}
					clsVar.appModes_0.CompositeMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num45 = 0; num45 < num8; num45++)
					{
						byte value40 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value40);
					}
					clsVar.appModes_0.CompositeMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num46 = 0; num46 < num8; num46++)
					{
						byte value41 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value41);
					}
					clsVar.appModes_0.CompositeMode.Mode4Exp = text10;
					clsVar.appModes_0.WoodMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.WoodMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.WoodMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num47 = 0; num47 < num8; num47++)
					{
						byte value42 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value42);
					}
					clsVar.appModes_0.WoodMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num48 = 0; num48 < num8; num48++)
					{
						byte value43 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value43);
					}
					clsVar.appModes_0.WoodMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num49 = 0; num49 < num8; num49++)
					{
						byte value44 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value44);
					}
					clsVar.appModes_0.WoodMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num50 = 0; num50 < num8; num50++)
					{
						byte value45 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value45);
					}
					clsVar.appModes_0.WoodMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num51 = 0; num51 < num8; num51++)
					{
						byte value46 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value46);
					}
					clsVar.appModes_0.WoodMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num52 = 0; num52 < num8; num52++)
					{
						byte value47 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value47);
					}
					clsVar.appModes_0.WoodMode.Mode4Exp = text10;
					clsVar.appModes_0.CustomMenu1 = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.TuftingMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.TuftingMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.TuftingMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num53 = 0; num53 < num8; num53++)
					{
						byte value48 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value48);
					}
					clsVar.appModes_0.TuftingMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num54 = 0; num54 < num8; num54++)
					{
						byte value49 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value49);
					}
					clsVar.appModes_0.TuftingMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num55 = 0; num55 < num8; num55++)
					{
						byte value50 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value50);
					}
					clsVar.appModes_0.TuftingMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num56 = 0; num56 < num8; num56++)
					{
						byte value51 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value51);
					}
					clsVar.appModes_0.TuftingMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num57 = 0; num57 < num8; num57++)
					{
						byte value52 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value52);
					}
					clsVar.appModes_0.TuftingMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num58 = 0; num58 < num8; num58++)
					{
						byte value53 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value53);
					}
					clsVar.appModes_0.TuftingMode.Mode4Exp = text10;
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.DiemakerMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.DiemakerMode.Grinding = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.DiemakerMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.DiemakerMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num59 = 0; num59 < num8; num59++)
					{
						byte value54 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value54);
					}
					clsVar.appModes_0.DiemakerMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num60 = 0; num60 < num8; num60++)
					{
						byte value55 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value55);
					}
					clsVar.appModes_0.DiemakerMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num61 = 0; num61 < num8; num61++)
					{
						byte value56 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value56);
					}
					clsVar.appModes_0.DiemakerMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num62 = 0; num62 < num8; num62++)
					{
						byte value57 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value57);
					}
					clsVar.appModes_0.DiemakerMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num63 = 0; num63 < num8; num63++)
					{
						byte value58 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value58);
					}
					clsVar.appModes_0.DiemakerMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num64 = 0; num64 < num8; num64++)
					{
						byte value59 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value59);
					}
					clsVar.appModes_0.DiemakerMode.Mode4Exp = text10;
					clsVar.appModes_0.WireBendMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.WireBendMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.WireBendMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num65 = 0; num65 < num8; num65++)
					{
						byte value60 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value60);
					}
					clsVar.appModes_0.WireBendMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num66 = 0; num66 < num8; num66++)
					{
						byte value61 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value61);
					}
					clsVar.appModes_0.WireBendMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num67 = 0; num67 < num8; num67++)
					{
						byte value62 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value62);
					}
					clsVar.appModes_0.WireBendMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num68 = 0; num68 < num8; num68++)
					{
						byte value63 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value63);
					}
					clsVar.appModes_0.WireBendMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num69 = 0; num69 < num8; num69++)
					{
						byte value64 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value64);
					}
					clsVar.appModes_0.WireBendMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num70 = 0; num70 < num8; num70++)
					{
						byte value65 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value65);
					}
					clsVar.appModes_0.WireBendMode.Mode4Exp = text10;
					clsVar.appModes_0.Motion = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.MetalSpinningMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.FootMode = binaryReader.ReadBoolean();
					clsVar.appModes_0.FootBasicMode = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.ProfileMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.ProfileMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.ProfileMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num71 = 0; num71 < num8; num71++)
					{
						byte value66 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value66);
					}
					clsVar.appModes_0.ProfileMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num72 = 0; num72 < num8; num72++)
					{
						byte value67 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value67);
					}
					clsVar.appModes_0.ProfileMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num73 = 0; num73 < num8; num73++)
					{
						byte value68 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value68);
					}
					clsVar.appModes_0.ProfileMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num74 = 0; num74 < num8; num74++)
					{
						byte value69 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value69);
					}
					clsVar.appModes_0.ProfileMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num75 = 0; num75 < num8; num75++)
					{
						byte value70 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value70);
					}
					clsVar.appModes_0.ProfileMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num76 = 0; num76 < num8; num76++)
					{
						byte value71 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value71);
					}
					clsVar.appModes_0.ProfileMode.Mode4Exp = text10;
					clsVar.appModes_0.Kinematic = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.Object = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.Shape3D = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.LibraryMode = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.SurfaceMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.SurfaceMode.Conversion = binaryReader.ReadBoolean();
					clsVar.appModes_0.SurfaceMode.CurveSurface = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					if (!clsVar.appModes_0.ModuleWork)
					{
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
					}
					else
					{
						clsVar.appModes_0.ModuleWorkMode.Wireframe = binaryReader.ReadBoolean();
						clsVar.appModes_0.ModuleWorkMode.Drill = binaryReader.ReadBoolean();
						clsVar.appModes_0.ModuleWorkMode.TriangleMeshBasic = binaryReader.ReadBoolean();
						clsVar.appModes_0.ModuleWorkMode.TriangleMeshAdvanced = binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
						binaryReader.ReadBoolean();
					}
					clsVar.appModes_0.PunchMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.PunchMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.PunchMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num77 = 0; num77 < num8; num77++)
					{
						byte value72 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value72);
					}
					clsVar.appModes_0.PunchMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num78 = 0; num78 < num8; num78++)
					{
						byte value73 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value73);
					}
					clsVar.appModes_0.PunchMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num79 = 0; num79 < num8; num79++)
					{
						byte value74 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value74);
					}
					clsVar.appModes_0.PunchMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num80 = 0; num80 < num8; num80++)
					{
						byte value75 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value75);
					}
					clsVar.appModes_0.PunchMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num81 = 0; num81 < num8; num81++)
					{
						byte value76 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value76);
					}
					clsVar.appModes_0.PunchMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num82 = 0; num82 < num8; num82++)
					{
						byte value77 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value77);
					}
					clsVar.appModes_0.PunchMode.Mode4Exp = text10;
					clsVar.appModes_0.RoboticMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.RoboticMode.XRay = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.RoboticMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.RoboticMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num83 = 0; num83 < num8; num83++)
					{
						byte value78 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value78);
					}
					clsVar.appModes_0.RoboticMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num84 = 0; num84 < num8; num84++)
					{
						byte value79 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value79);
					}
					clsVar.appModes_0.RoboticMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num85 = 0; num85 < num8; num85++)
					{
						byte value80 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value80);
					}
					clsVar.appModes_0.RoboticMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num86 = 0; num86 < num8; num86++)
					{
						byte value81 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value81);
					}
					clsVar.appModes_0.RoboticMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num87 = 0; num87 < num8; num87++)
					{
						byte value82 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value82);
					}
					clsVar.appModes_0.RoboticMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num88 = 0; num88 < num8; num88++)
					{
						byte value83 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value83);
					}
					clsVar.appModes_0.RoboticMode.Mode4Exp = text10;
					clsVar.appModes_0.FileOpenMode.buCadVer5 = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.buCadVer4 = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.DrawWorks = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Dxf = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Dwg = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Dwf = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Asc = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.cf2 = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.cnc = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Iges = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Icf = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Jt = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Las = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Lucas = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Nastran = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Obj = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Pdf = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Ply = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Rcp = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Rcs = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Step = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Stl = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Xyz = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Medit = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode._3DS = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.FileOpenMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.FileOpenMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num89 = 0; num89 < num8; num89++)
					{
						byte value84 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value84);
					}
					clsVar.appModes_0.FileOpenMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num90 = 0; num90 < num8; num90++)
					{
						byte value85 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value85);
					}
					clsVar.appModes_0.FileOpenMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num91 = 0; num91 < num8; num91++)
					{
						byte value86 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value86);
					}
					clsVar.appModes_0.FileOpenMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num92 = 0; num92 < num8; num92++)
					{
						byte value87 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value87);
					}
					clsVar.appModes_0.FileOpenMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num93 = 0; num93 < num8; num93++)
					{
						byte value88 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value88);
					}
					clsVar.appModes_0.FileOpenMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num94 = 0; num94 < num8; num94++)
					{
						byte value89 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value89);
					}
					clsVar.appModes_0.FileOpenMode.Mode4Exp = text10;
					clsVar.appModes_0.FileSaveMode.buCadVer5 = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Dxf = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Dwg = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Xml = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.WebGL = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Asc = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Iges = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Las = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Obj = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Pdf = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Step = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Stl = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Prc = binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Xyz = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.FileSaveMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.FileSaveMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num95 = 0; num95 < num8; num95++)
					{
						byte value90 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value90);
					}
					clsVar.appModes_0.FileSaveMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num96 = 0; num96 < num8; num96++)
					{
						byte value91 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value91);
					}
					clsVar.appModes_0.FileSaveMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num97 = 0; num97 < num8; num97++)
					{
						byte value92 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value92);
					}
					clsVar.appModes_0.FileSaveMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num98 = 0; num98 < num8; num98++)
					{
						byte value93 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value93);
					}
					clsVar.appModes_0.FileSaveMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num99 = 0; num99 < num8; num99++)
					{
						byte value94 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value94);
					}
					clsVar.appModes_0.FileSaveMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num100 = 0; num100 < num8; num100++)
					{
						byte value95 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value95);
					}
					clsVar.appModes_0.FileSaveMode.Mode4Exp = text10;
					clsVar.appModes_0.ViewerMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.ViewerMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.ViewerMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num101 = 0; num101 < num8; num101++)
					{
						byte value96 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value96);
					}
					clsVar.appModes_0.ViewerMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num102 = 0; num102 < num8; num102++)
					{
						byte value97 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value97);
					}
					clsVar.appModes_0.ViewerMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num103 = 0; num103 < num8; num103++)
					{
						byte value98 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value98);
					}
					clsVar.appModes_0.ViewerMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num104 = 0; num104 < num8; num104++)
					{
						byte value99 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value99);
					}
					clsVar.appModes_0.ViewerMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num105 = 0; num105 < num8; num105++)
					{
						byte value100 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value100);
					}
					clsVar.appModes_0.ViewerMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num106 = 0; num106 < num8; num106++)
					{
						byte value101 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value101);
					}
					clsVar.appModes_0.ViewerMode.Mode4Exp = text10;
					clsVar.appModes_0.DrawMode.Draw2D = binaryReader.ReadBoolean();
					clsVar.appModes_0.DrawMode.Draw3D = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.DrawMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.DrawMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num107 = 0; num107 < num8; num107++)
					{
						byte value102 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value102);
					}
					clsVar.appModes_0.DrawMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num108 = 0; num108 < num8; num108++)
					{
						byte value103 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value103);
					}
					clsVar.appModes_0.DrawMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num109 = 0; num109 < num8; num109++)
					{
						byte value104 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value104);
					}
					clsVar.appModes_0.DrawMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num110 = 0; num110 < num8; num110++)
					{
						byte value105 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value105);
					}
					clsVar.appModes_0.DrawMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num111 = 0; num111 < num8; num111++)
					{
						byte value106 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value106);
					}
					clsVar.appModes_0.DrawMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num112 = 0; num112 < num8; num112++)
					{
						byte value107 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value107);
					}
					clsVar.appModes_0.DrawMode.Mode4Exp = text10;
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.Temp2Mode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.Temp2Mode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num113 = 0; num113 < num8; num113++)
					{
						byte value108 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value108);
					}
					clsVar.appModes_0.Temp2Mode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num114 = 0; num114 < num8; num114++)
					{
						byte value109 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value109);
					}
					clsVar.appModes_0.Temp2Mode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num115 = 0; num115 < num8; num115++)
					{
						byte value110 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value110);
					}
					clsVar.appModes_0.Temp2Mode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num116 = 0; num116 < num8; num116++)
					{
						byte value111 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value111);
					}
					clsVar.appModes_0.Temp2Mode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num117 = 0; num117 < num8; num117++)
					{
						byte value112 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value112);
					}
					clsVar.appModes_0.Temp2Mode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num118 = 0; num118 < num8; num118++)
					{
						byte value113 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value113);
					}
					clsVar.appModes_0.Temp2Mode.Mode4Exp = text10;
					clsVar.appModes_0.PipeBendMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.PipeBendMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.PipeBendMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num119 = 0; num119 < num8; num119++)
					{
						byte value114 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value114);
					}
					clsVar.appModes_0.PipeBendMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num120 = 0; num120 < num8; num120++)
					{
						byte value115 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value115);
					}
					clsVar.appModes_0.PipeBendMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num121 = 0; num121 < num8; num121++)
					{
						byte value116 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value116);
					}
					clsVar.appModes_0.PipeBendMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num122 = 0; num122 < num8; num122++)
					{
						byte value117 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value117);
					}
					clsVar.appModes_0.PipeBendMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num123 = 0; num123 < num8; num123++)
					{
						byte value118 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value118);
					}
					clsVar.appModes_0.PipeBendMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num124 = 0; num124 < num8; num124++)
					{
						byte value119 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value119);
					}
					clsVar.appModes_0.PipeBendMode.Mode4Exp = text10;
					clsVar.appModes_0.WireBendMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.WireBendMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num125 = 0; num125 < num8; num125++)
					{
						byte value120 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value120);
					}
					clsVar.appModes_0.WireBendMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num126 = 0; num126 < num8; num126++)
					{
						byte value121 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value121);
					}
					clsVar.appModes_0.WireBendMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num127 = 0; num127 < num8; num127++)
					{
						byte value122 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value122);
					}
					clsVar.appModes_0.WireBendMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num128 = 0; num128 < num8; num128++)
					{
						byte value123 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value123);
					}
					clsVar.appModes_0.WireBendMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num129 = 0; num129 < num8; num129++)
					{
						byte value124 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value124);
					}
					clsVar.appModes_0.WireBendMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num130 = 0; num130 < num8; num130++)
					{
						byte value125 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value125);
					}
					clsVar.appModes_0.WireBendMode.Mode4Exp = text10;
					clsVar.appModes_0.LaserRouterDiamekerMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.LaserRouterDiamekerMode.Laser = binaryReader.ReadBoolean();
					clsVar.appModes_0.LaserRouterDiamekerMode.Router = binaryReader.ReadBoolean();
					clsVar.appModes_0.LaserRouterDiamekerMode.Cam = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num131 = 0; num131 < num8; num131++)
					{
						byte value126 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value126);
					}
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num132 = 0; num132 < num8; num132++)
					{
						byte value127 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value127);
					}
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num133 = 0; num133 < num8; num133++)
					{
						byte value128 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value128);
					}
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num134 = 0; num134 < num8; num134++)
					{
						byte value129 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value129);
					}
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num135 = 0; num135 < num8; num135++)
					{
						byte value130 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value130);
					}
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num136 = 0; num136 < num8; num136++)
					{
						byte value131 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value131);
					}
					clsVar.appModes_0.LaserRouterDiamekerMode.Mode4Exp = text10;
					clsVar.appModes_0.CutterMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.CutterMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.CutterMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num137 = 0; num137 < num8; num137++)
					{
						byte value132 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value132);
					}
					clsVar.appModes_0.CutterMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num138 = 0; num138 < num8; num138++)
					{
						byte value133 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value133);
					}
					clsVar.appModes_0.CutterMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num139 = 0; num139 < num8; num139++)
					{
						byte value134 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value134);
					}
					clsVar.appModes_0.CutterMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num140 = 0; num140 < num8; num140++)
					{
						byte value135 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value135);
					}
					clsVar.appModes_0.CutterMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num141 = 0; num141 < num8; num141++)
					{
						byte value136 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value136);
					}
					clsVar.appModes_0.CutterMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num142 = 0; num142 < num8; num142++)
					{
						byte value137 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value137);
					}
					clsVar.appModes_0.CutterMode.Mode4Exp = text10;
					clsVar.appModes_0.GlassCutMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.GlassCutMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.GlassCutMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num143 = 0; num143 < num8; num143++)
					{
						byte value138 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value138);
					}
					clsVar.appModes_0.GlassCutMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num144 = 0; num144 < num8; num144++)
					{
						byte value139 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value139);
					}
					clsVar.appModes_0.GlassCutMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num145 = 0; num145 < num8; num145++)
					{
						byte value140 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value140);
					}
					clsVar.appModes_0.GlassCutMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num146 = 0; num146 < num8; num146++)
					{
						byte value141 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value141);
					}
					clsVar.appModes_0.GlassCutMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num147 = 0; num147 < num8; num147++)
					{
						byte value142 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value142);
					}
					clsVar.appModes_0.GlassCutMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num148 = 0; num148 < num8; num148++)
					{
						byte value143 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value143);
					}
					clsVar.appModes_0.GlassCutMode.Mode4Exp = text10;
					clsVar.appModes_0.LeatherMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.LeatherMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.LeatherMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num149 = 0; num149 < num8; num149++)
					{
						byte value144 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value144);
					}
					clsVar.appModes_0.LeatherMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num150 = 0; num150 < num8; num150++)
					{
						byte value145 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value145);
					}
					clsVar.appModes_0.LeatherMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num151 = 0; num151 < num8; num151++)
					{
						byte value146 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value146);
					}
					clsVar.appModes_0.LeatherMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num152 = 0; num152 < num8; num152++)
					{
						byte value147 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value147);
					}
					clsVar.appModes_0.LeatherMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num153 = 0; num153 < num8; num153++)
					{
						byte value148 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value148);
					}
					clsVar.appModes_0.LeatherMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num154 = 0; num154 < num8; num154++)
					{
						byte value149 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value149);
					}
					clsVar.appModes_0.LeatherMode.Mode4Exp = text10;
					clsVar.appDefination.IntroAppNameLeft = (int)(binaryReader.ReadDouble() / 51.0);
					clsVar.appDefination.IntroAppNameTop = (int)(binaryReader.ReadDouble() / 52.0);
					clsVar.appDefination.IntroAppNameWidth = (int)(binaryReader.ReadDouble() / 53.0);
					clsVar.appDefination.IntroAppNameColor = (int)(binaryReader.ReadDouble() / 54.0);
					clsVar.appDefination.IntroAppNameFont = (int)(binaryReader.ReadDouble() / 55.0);
					clsVar.appDefination.IntroAppNameVisible = binaryReader.ReadBoolean();
					clsVar.appDefination.IntroVersionLeft = (int)(binaryReader.ReadDouble() / 61.0);
					clsVar.appDefination.IntroVersionTop = (int)(binaryReader.ReadDouble() / 62.0);
					clsVar.appDefination.IntroVerisonWidth = (int)(binaryReader.ReadDouble() / 63.0);
					clsVar.appDefination.IntroVersionColor = (int)(binaryReader.ReadDouble() / 64.0);
					clsVar.appDefination.IntroVersionFont = (int)(binaryReader.ReadDouble() / 65.0);
					clsVar.appDefination.IntroVersionVisible = binaryReader.ReadBoolean();
					clsVar.appDefination.IntroWebLeft = (int)(binaryReader.ReadDouble() / 71.0);
					clsVar.appDefination.IntroWebTop = (int)(binaryReader.ReadDouble() / 72.0);
					clsVar.appDefination.IntroWebWidth = (int)(binaryReader.ReadDouble() / 73.0);
					clsVar.appDefination.IntroWebColor = (int)(binaryReader.ReadDouble() / 74.0);
					clsVar.appDefination.IntroWebFont = (int)(binaryReader.ReadDouble() / 75.0);
					clsVar.appDefination.IntroWebVisible = binaryReader.ReadBoolean();
					clsVar.appDefination.IntroVendorLeft = (int)(binaryReader.ReadDouble() / 81.0);
					clsVar.appDefination.IntroVendorTop = (int)(binaryReader.ReadDouble() / 82.0);
					clsVar.appDefination.IntroVendorWidth = (int)(binaryReader.ReadDouble() / 83.0);
					clsVar.appDefination.IntroVendorColor = (int)(binaryReader.ReadDouble() / 84.0);
					clsVar.appDefination.IntroVendorFont = (int)(binaryReader.ReadDouble() / 85.0);
					clsVar.appDefination.IntroVendorVisible = binaryReader.ReadBoolean();
					clsVar.appDefination.IntroAuxLeft = (int)(binaryReader.ReadDouble() / 91.0);
					clsVar.appDefination.IntroAuxTop = (int)(binaryReader.ReadDouble() / 92.0);
					clsVar.appDefination.IntroAuxWidth = (int)(binaryReader.ReadDouble() / 93.0);
					clsVar.appDefination.IntroAuxColor = (int)(binaryReader.ReadDouble() / 94.0);
					clsVar.appDefination.IntroAuxFont = (int)(binaryReader.ReadDouble() / 95.0);
					clsVar.appDefination.IntroAuxVisible = binaryReader.ReadBoolean();
					clsVar.appDefination.IntroOther1Left = (int)(binaryReader.ReadDouble() / 101.0);
					clsVar.appDefination.IntroOther1Top = (int)(binaryReader.ReadDouble() / 102.0);
					clsVar.appDefination.IntroOther1Width = (int)(binaryReader.ReadDouble() / 103.0);
					clsVar.appDefination.IntroOther1Color = (int)(binaryReader.ReadDouble() / 104.0);
					clsVar.appDefination.IntroOther1Font = (int)(binaryReader.ReadDouble() / 105.0);
					clsVar.appDefination.IntroOther1Visible = binaryReader.ReadBoolean();
					clsVar.appModes_0.QuiltingMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.QuiltingMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.QuiltingMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num155 = 0; num155 < num8; num155++)
					{
						byte value150 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value150);
					}
					clsVar.appModes_0.QuiltingMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num156 = 0; num156 < num8; num156++)
					{
						byte value151 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value151);
					}
					clsVar.appModes_0.QuiltingMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num157 = 0; num157 < num8; num157++)
					{
						byte value152 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value152);
					}
					clsVar.appModes_0.QuiltingMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num158 = 0; num158 < num8; num158++)
					{
						byte value153 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value153);
					}
					clsVar.appModes_0.QuiltingMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num159 = 0; num159 < num8; num159++)
					{
						byte value154 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value154);
					}
					clsVar.appModes_0.QuiltingMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num160 = 0; num160 < num8; num160++)
					{
						byte value155 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value155);
					}
					clsVar.appModes_0.QuiltingMode.Mode4Exp = text10;
					clsVar.appModes_0.MarbleMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Countertop = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Profile = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.ProfileArc = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Engraving3Axis = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Engraving3Axis = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Lathe = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.SawMilling = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.FileImport = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Camera = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Vacuum = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.GCodeImport = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Library = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Columns = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.ToolMeasure = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Sweep = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Hole = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Text = binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.OPMenu = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.MarbleMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.MarbleMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num161 = 0; num161 < num8; num161++)
					{
						byte value156 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value156);
					}
					clsVar.appModes_0.MarbleMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num162 = 0; num162 < num8; num162++)
					{
						byte value157 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value157);
					}
					clsVar.appModes_0.MarbleMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num163 = 0; num163 < num8; num163++)
					{
						byte value158 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value158);
					}
					clsVar.appModes_0.MarbleMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num164 = 0; num164 < num8; num164++)
					{
						byte value159 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value159);
					}
					clsVar.appModes_0.MarbleMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num165 = 0; num165 < num8; num165++)
					{
						byte value160 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value160);
					}
					clsVar.appModes_0.MarbleMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num166 = 0; num166 < num8; num166++)
					{
						byte value161 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value161);
					}
					clsVar.appModes_0.MarbleMode.Mode4Exp = text10;
					clsVar.appModes_0.DrillMode.Enable = binaryReader.ReadBoolean();
					clsVar.appModes_0.DrillMode.GoUltra = binaryReader.ReadBoolean();
					clsVar.appModes_0.DrillMode.Go = binaryReader.ReadBoolean();
					clsVar.appModes_0.DrillMode.Sirius = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.DrillMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.DrillMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num167 = 0; num167 < num8; num167++)
					{
						byte value162 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value162);
					}
					clsVar.appModes_0.DrillMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num168 = 0; num168 < num8; num168++)
					{
						byte value163 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value163);
					}
					clsVar.appModes_0.DrillMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num169 = 0; num169 < num8; num169++)
					{
						byte value164 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value164);
					}
					clsVar.appModes_0.DrillMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num170 = 0; num170 < num8; num170++)
					{
						byte value165 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value165);
					}
					clsVar.appModes_0.DrillMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num171 = 0; num171 < num8; num171++)
					{
						byte value166 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value166);
					}
					clsVar.appModes_0.DrillMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num172 = 0; num172 < num8; num172++)
					{
						byte value167 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value167);
					}
					clsVar.appModes_0.DrillMode.Mode4Exp = text10;
					clsVar.appModes_0.FlexoMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.FlexoMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.FlexoMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num173 = 0; num173 < num8; num173++)
					{
						byte value168 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value168);
					}
					clsVar.appModes_0.FlexoMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num174 = 0; num174 < num8; num174++)
					{
						byte value169 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value169);
					}
					clsVar.appModes_0.FlexoMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num175 = 0; num175 < num8; num175++)
					{
						byte value170 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value170);
					}
					clsVar.appModes_0.FlexoMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num176 = 0; num176 < num8; num176++)
					{
						byte value171 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value171);
					}
					clsVar.appModes_0.FlexoMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num177 = 0; num177 < num8; num177++)
					{
						byte value172 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value172);
					}
					clsVar.appModes_0.FlexoMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num178 = 0; num178 < num8; num178++)
					{
						byte value173 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value173);
					}
					clsVar.appModes_0.FlexoMode.Mode4Exp = text10;
					clsVar.appModes_0.SewingMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.SewingMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.SewingMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num179 = 0; num179 < num8; num179++)
					{
						byte value174 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value174);
					}
					clsVar.appModes_0.SewingMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num180 = 0; num180 < num8; num180++)
					{
						byte value175 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value175);
					}
					clsVar.appModes_0.SewingMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num181 = 0; num181 < num8; num181++)
					{
						byte value176 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value176);
					}
					clsVar.appModes_0.SewingMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num182 = 0; num182 < num8; num182++)
					{
						byte value177 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value177);
					}
					clsVar.appModes_0.SewingMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num183 = 0; num183 < num8; num183++)
					{
						byte value178 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value178);
					}
					clsVar.appModes_0.SewingMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num184 = 0; num184 < num8; num184++)
					{
						byte value179 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value179);
					}
					clsVar.appModes_0.SewingMode.Mode4Exp = text10;
					clsVar.appModes_0.FoamCuttingMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.FoamCuttingMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.FoamCuttingMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num185 = 0; num185 < num8; num185++)
					{
						byte value180 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value180);
					}
					clsVar.appModes_0.FoamCuttingMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num186 = 0; num186 < num8; num186++)
					{
						byte value181 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value181);
					}
					clsVar.appModes_0.FoamCuttingMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num187 = 0; num187 < num8; num187++)
					{
						byte value182 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value182);
					}
					clsVar.appModes_0.FoamCuttingMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num188 = 0; num188 < num8; num188++)
					{
						byte value183 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value183);
					}
					clsVar.appModes_0.FoamCuttingMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num189 = 0; num189 < num8; num189++)
					{
						byte value184 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value184);
					}
					clsVar.appModes_0.FoamCuttingMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num190 = 0; num190 < num8; num190++)
					{
						byte value185 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value185);
					}
					clsVar.appModes_0.FoamCuttingMode.Mode4Exp = text10;
					clsVar.appModes_0.Printer3DMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.Printer3DMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.Printer3DMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num191 = 0; num191 < num8; num191++)
					{
						byte value186 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value186);
					}
					clsVar.appModes_0.Printer3DMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num192 = 0; num192 < num8; num192++)
					{
						byte value187 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value187);
					}
					clsVar.appModes_0.Printer3DMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num193 = 0; num193 < num8; num193++)
					{
						byte value188 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value188);
					}
					clsVar.appModes_0.Printer3DMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num194 = 0; num194 < num8; num194++)
					{
						byte value189 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value189);
					}
					clsVar.appModes_0.Printer3DMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num195 = 0; num195 < num8; num195++)
					{
						byte value190 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value190);
					}
					clsVar.appModes_0.Printer3DMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num196 = 0; num196 < num8; num196++)
					{
						byte value191 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value191);
					}
					clsVar.appModes_0.Printer3DMode.Mode4Exp = text10;
					clsVar.appModes_0.DoorMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.DoorMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.DoorMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num197 = 0; num197 < num8; num197++)
					{
						byte value192 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value192);
					}
					clsVar.appModes_0.DoorMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num198 = 0; num198 < num8; num198++)
					{
						byte value193 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value193);
					}
					clsVar.appModes_0.DoorMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num199 = 0; num199 < num8; num199++)
					{
						byte value194 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value194);
					}
					clsVar.appModes_0.DoorMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num200 = 0; num200 < num8; num200++)
					{
						byte value195 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value195);
					}
					clsVar.appModes_0.DoorMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num201 = 0; num201 < num8; num201++)
					{
						byte value196 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value196);
					}
					clsVar.appModes_0.DoorMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num202 = 0; num202 < num8; num202++)
					{
						byte value197 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value197);
					}
					clsVar.appModes_0.DoorMode.Mode4Exp = text10;
					clsVar.appModes_0.RollerBendMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.RollerBendMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.RollerBendMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num203 = 0; num203 < num8; num203++)
					{
						byte value198 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value198);
					}
					clsVar.appModes_0.RollerBendMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num204 = 0; num204 < num8; num204++)
					{
						byte value199 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value199);
					}
					clsVar.appModes_0.RollerBendMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num205 = 0; num205 < num8; num205++)
					{
						byte value200 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value200);
					}
					clsVar.appModes_0.RollerBendMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num206 = 0; num206 < num8; num206++)
					{
						byte value201 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value201);
					}
					clsVar.appModes_0.RollerBendMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num207 = 0; num207 < num8; num207++)
					{
						byte value202 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value202);
					}
					clsVar.appModes_0.RollerBendMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num208 = 0; num208 < num8; num208++)
					{
						byte value203 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value203);
					}
					clsVar.appModes_0.RollerBendMode.Mode4Exp = text10;
					clsVar.appModes_0.ToolGrindingMode.Enable = binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					binaryReader.ReadBoolean();
					clsVar.appModes_0.ToolGrindingMode.Mode1 = binaryReader.ReadDouble() / 376.558;
					clsVar.appModes_0.ToolGrindingMode.Mode2 = binaryReader.ReadDouble() / 196.428;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num209 = 0; num209 < num8; num209++)
					{
						byte value204 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
						text10 += Convert.ToChar(value204);
					}
					clsVar.appModes_0.ToolGrindingMode.Mode3 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num210 = 0; num210 < num8; num210++)
					{
						byte value205 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
						text10 += Convert.ToChar(value205);
					}
					clsVar.appModes_0.ToolGrindingMode.Mode4 = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num211 = 0; num211 < num8; num211++)
					{
						byte value206 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value206);
					}
					clsVar.appModes_0.ToolGrindingMode.Mode1Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num212 = 0; num212 < num8; num212++)
					{
						byte value207 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value207);
					}
					clsVar.appModes_0.ToolGrindingMode.Mode2Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num213 = 0; num213 < num8; num213++)
					{
						byte value208 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value208);
					}
					clsVar.appModes_0.ToolGrindingMode.Mode3Exp = text10;
					text10 = "";
					num8 = binaryReader.ReadInt32();
					for (int num214 = 0; num214 < num8; num214++)
					{
						byte value209 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
						text10 += Convert.ToChar(value209);
					}
					clsVar.appModes_0.ToolGrindingMode.Mode4Exp = text10;
					binaryReader.Close();
					buLogVer5.addToLog("DefK", "Mode 1002", "mnb", "100", 0.0, 0.0);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					binaryReader.Close();
				}
				if (new FileInfo(AppPath.Base + "\\buhardkey.dll").Exists)
				{
					buLogVer5.addToLog("DefK", "Mode 1003", "HK", "True", 0.0, 0.0);
					clsVar.appModes_0.HardKeyCmdEnable = true;
				}
				bool flag;
				if (flag = ReadDevFile())
				{
					buLogVer5.addToLog("DefK", "Mode 1004", "Dev", "True", 0.0, 0.0);
					AppSecurity.PasswordLevel = 10;
					clsVar.appModes_0.DeveloperMode = true;
				}
				if (ReadDevFileFull())
				{
					flag = true;
					clsVar.appModes_0.DeveloperMode = true;
					clsVar.appModes_0.NestingMode.Enable = true;
					clsVar.appModes_0.GrindingMode.Enable = true;
					clsVar.appModes_0.LibraryMode = true;
					clsVar.appModes_0.JewelMode.Enable = true;
					clsVar.appModes_0.ImageProcessMode = true;
					clsVar.appModes_0.WoodMode.Enable = true;
					clsVar.appModes_0.MarbleMode.Enable = true;
					clsVar.appModes_0.DrillMode.Enable = true;
					clsVar.appModes_0.TuftingMode.Enable = true;
					clsVar.appModes_0.WoodMode.Enable = true;
					clsVar.appModes_0.FootMode = true;
					clsVar.appModes_0.ProfileMode.Enable = true;
					clsVar.appModes_0.DiemakerMode.Enable = true;
					clsVar.appModes_0.Motion = true;
					clsVar.appModes_0.WireBendMode.Enable = true;
					clsVar.appModes_0.PipeBendMode.Enable = true;
					clsVar.appModes_0.FlexoMode.Enable = true;
					clsVar.appModes_0.SewingMode.Enable = true;
					clsVar.appModes_0.FoamCuttingMode.Enable = true;
					clsVar.appModes_0.Printer3DMode.Enable = true;
					clsVar.appModes_0.DoorMode.Enable = true;
					clsVar.appModes_0.RollerBendMode.Enable = true;
				}
				buLogVer5.addToLog("DefK", "Mode 1005", "DT", "Begins", 0.0, 0.0);
				if (DateTime.Now >= clsVar.appModes_0.ExpireDateTime && !flag)
				{
					buLogVer5.addToLog("DefK", "Mode 1006", "DT", "Opppsss", 0.0, 0.0);
					clsInit.appSystem.SetTr(567.001);
				}
				bool flag2 = false;
				if (!clsVar.appModes_0.HardKeyCmdEnable)
				{
					if (!clsVar.appModes_0.NestingMode.Enable)
					{
						List<string> MacAddress = new List<string>();
						List<string> CpuAddress = new List<string>();
						string MBAddress = "";
						buLogVer5.addToLog("DefK", "Mode 1007", "HW", "Get", 0.0, 0.0);
						clsSystem.getMacAddress(ref MacAddress);
						clsSystem.getCpuID(ref CpuAddress);
						clsSystem.GetMotherBoardID(ref MBAddress);
						buLogVer5.addToLog("DefK", "Mode 1008", "HW", "Done", 0.0, 0.0);
						buLogVer5.addToLog("DefK", "Mode 1016", "SWK", "Begins", 0.0, 0.0);
						if ((MacAddress.Count > 0) & (CpuAddress.Count > 0))
						{
							for (int num215 = 0; num215 <= MacAddress.Count - 1; num215++)
							{
								double num216 = 0.0;
								double num217 = 0.0;
								double num218 = 0.0;
								for (int num219 = 0; num219 <= MacAddress[num215].Length - 1; num219++)
								{
									double num220 = (int)Convert.ToByte(Convert.ToChar(MacAddress[num215].Substring(num219, 1)));
									num216 += num220 * 17.92;
								}
								for (int num221 = 0; num221 <= CpuAddress[0].Length - 1; num221++)
								{
									double num222 = (int)Convert.ToByte(Convert.ToChar(CpuAddress[0].Substring(num221, 1)));
									num217 += num222 * 47.93;
								}
								for (int num223 = 0; num223 <= MBAddress.Length - 1; num223++)
								{
									double num224 = (int)Convert.ToByte(Convert.ToChar(MBAddress.Substring(num223, 1)));
									num218 += num224 * 51.95;
								}
								double num225 = (num216 + num217 + num218) * 9.912;
								for (int num226 = 0; num226 <= list.Count - 1; num226++)
								{
									if (Math.Abs(list[num226] - num225) < 0.0001)
									{
										clsVar.appDefination.ProgramCode = num225.ToString();
										flag2 = true;
									}
								}
							}
							if (!flag2)
							{
								flag2 = clsInit.appSystem.ReadHK(flag);
							}
							if (flag2)
							{
								buLogVer5.addToLog("DefK", "Mode 1018", "SWK", "True", 0.0, 0.0);
								clsVar.bool_0 = flag2;
								if (flag2)
								{
									clsInit.appNesting = new clsNesting();
									clsInit.appNesting.Init();
								}
								_ = !flag2 && !flag;
								return flag2;
							}
							buLogVer5.addToLog("DefK", "Mode 1017", "SWK", "False", 0.0, 0.0);
							return true;
						}
					}
					else
					{
						if (clsVar.appModes_0.HardKeyPowerNestEnable & !clsVar.appModes_0.isPowerNestDongleInited)
						{
							clsInit.appNesting = new clsNesting();
							buLogVer5.addToLog("DefK", "Mode 1012", "HKPwr", "Init", 0.0, 0.0);
							clsInit.appNesting.Init();
							buLogVer5.addToLog("DefK", "Mode 1013", "HKPwr", "Done", 0.0, 0.0);
							bool flag3;
							if (flag3 = clsInit.appNestingPower.isDongleAvailable())
							{
								clsVar.bool_0 = flag3;
								clsVar.appModes_0.isPowerNestDongleAvailable = flag3;
								clsVar.appModes_0.isPowerNestDongleInited = true;
								buLogVer5.addToLog("DefK", "Mode 1015", "HKPwr", "True", 0.0, 0.0);
								return true;
							}
							buLogVer5.addToLog("DefK", "Mode 1014", "HKPwr", "False", 0.0, 0.0);
							buString.MessageBoxError("NO Nesting Dongle");
							Environment.Exit(0);
							return false;
						}
						if (clsVar.appModes_0.HardKeyPowerNestEnable & clsVar.appModes_0.isPowerNestDongleInited & clsVar.appModes_0.isPowerNestDongleAvailable)
						{
							return true;
						}
					}
					buLogVer5.addToLog("DefK", "Mode 1020", "L", "True", 0.0, 0.0);
					return false;
				}
				buLogVer5.addToLog("DefK", "Mode 1008", "HW", "Done", 0.0, 0.0);
				bool flag4 = clsInit.appSystem.ReadHK(flag);
				buLogVer5.addToLog("DefK", "Mode 1009", "HK", "Done", 0.0, 0.0);
				clsVar.bool_0 = flag4;
				clsVar.appModes_0.isCMDDongleAvailable = flag4;
				if (flag4)
				{
					if (clsVar.appModes_0.NestingMode.Enable)
					{
						clsInit.appNesting = new clsNesting();
						clsInit.appNesting.Init();
					}
					buLogVer5.addToLog("DefK", "Mode 1011", "HKCMD", "True", 0.0, 0.0);
					return flag4;
				}
				buLogVer5.addToLog("DefK", "Mode 1010", "HKCMD", "False", 0.0, 0.0);
				buString.MessageBoxError("License Error - No Dongle Available");
				Environment.Exit(0);
				return false;
			}
			buLogVer5.addToLog("DefK", "Mode 998", "mn", "Missing", 0.0, 0.0);
			buString.MessageBoxError("Configration File is Missing");
			Environment.Exit(0);
			return false;
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog("DefK", "Mode 1030", "L", "Exception", 0.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Program Init Failure");
			MessageBox.Show("Program Init Failure ");
			return false;
		}
	}

	public static string HC(List<string> M, List<string> C, string mb)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		if ((M.Count > 0) & (C.Count > 0))
		{
			for (int i = 0; i <= M[0].Length - 1; i++)
			{
				string value = M[0].Substring(i, 1);
				double num4 = (int)Convert.ToByte(Convert.ToChar(value));
				num += num4 * 17.92;
			}
			for (int j = 0; j <= C[0].Length - 1; j++)
			{
				string value2 = C[0].Substring(j, 1);
				double num5 = (int)Convert.ToByte(Convert.ToChar(value2));
				num2 += num5 * 47.93;
			}
			for (int k = 0; k <= mb.Length - 1; k++)
			{
				string value3 = mb.Substring(k, 1);
				double num6 = (int)Convert.ToByte(Convert.ToChar(value3));
				num3 += num6 * 51.95;
			}
		}
		return ((num + num2 + num3) * 9.912).ToString();
	}

	public static void OpenMacroFile(string FileName)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(FileName);
			if (fileInfo.Exists)
			{
				List<string> StringList = new List<string>();
				new List<string>();
				new List<string>();
				List<string> CalcList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.ListToSpecificList("<NewPage>", "</NewPage>", AddStartEndKey: false, StringList, ref CalcList);
				if (CalcList.Count > 0)
				{
					clsVar.macroNewPage.Clear();
				}
				for (int i = 0; i <= CalcList.Count - 1; i++)
				{
					MacroBase macroBase = new MacroBase();
					macroBase = buGeneral.DecodeMacro(CalcList[i].ToString());
					clsVar.macroNewPage.Add(macroBase);
				}
				new List<string>();
				CalcList = new List<string>();
				buString.ListToSpecificList("<StartUp>", "</StartUp>", AddStartEndKey: false, StringList, ref CalcList);
				if (CalcList.Count > 0)
				{
					clsVar.macroStartUp.Clear();
				}
				for (int j = 0; j <= CalcList.Count - 1; j++)
				{
					MacroBase macroBase2 = new MacroBase();
					macroBase2 = buGeneral.DecodeMacro(CalcList[j].ToString());
					clsVar.macroStartUp.Add(macroBase2);
				}
				new List<string>();
				CalcList = new List<string>();
				buString.ListToSpecificList("<Init>", "</Init>", AddStartEndKey: false, StringList, ref CalcList);
				if (CalcList.Count > 0)
				{
					clsVar.macroInit.Clear();
				}
				for (int k = 0; k <= CalcList.Count - 1; k++)
				{
					MacroBase macroBase3 = new MacroBase();
					macroBase3 = buGeneral.DecodeMacro(CalcList[k].ToString());
					clsVar.macroInit.Add(macroBase3);
				}
				new List<string>();
				CalcList = new List<string>();
				buString.ListToSpecificList("<OpenFile>", "</OpenFile>", AddStartEndKey: false, StringList, ref CalcList);
				if (CalcList.Count > 0)
				{
					clsVar.macroOpen.Clear();
				}
				for (int l = 0; l <= CalcList.Count - 1; l++)
				{
					MacroBase macroBase4 = new MacroBase();
					macroBase4 = buGeneral.DecodeMacro(CalcList[l].ToString());
					clsVar.macroOpen.Add(macroBase4);
				}
				new List<string>();
				CalcList = new List<string>();
				buString.ListToSpecificList("<ImportFile>", "</ImportFile>", AddStartEndKey: false, StringList, ref CalcList);
				if (CalcList.Count > 0)
				{
					clsVar.macroImport.Clear();
				}
				for (int m = 0; m <= CalcList.Count - 1; m++)
				{
					MacroBase macroBase5 = new MacroBase();
					macroBase5 = buGeneral.DecodeMacro(CalcList[m].ToString());
					clsVar.macroImport.Add(macroBase5);
				}
				buLog.addLog("Macro File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog(FileName, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static void OpenShortKeyFile(string FileName)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(FileName);
			if (!fileInfo.Exists)
			{
				return;
			}
			List<string> StringList = new List<string>();
			buFile.OpenFromFile(fileInfo.FullName, ref StringList);
			for (int i = 0; i <= StringList.Count - 1; i++)
			{
				ShortCutKey shortCutKey = new ShortCutKey();
				shortCutKey = buGeneral.DecodeShortKey(StringList[i]);
				if ((shortCutKey.Command.Length > 0) & (shortCutKey.Key.ToString().Length > 0) & (shortCutKey.Key != ActionKeys.KeyNone))
				{
					clsVar.ShortKeyList.Add(shortCutKey);
				}
			}
			buLog.addLog("ShortCut File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog(FileName, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}

	public static Image OpenIntroImage(string Path)
	{
		Image image = null;
		FileInfo fileInfo = new FileInfo(Path + "\\Intro.jpg");
		if (!fileInfo.Exists)
		{
			fileInfo = new FileInfo(Path + "\\Intro.png");
			if (!fileInfo.Exists)
			{
				fileInfo = new FileInfo(Path + "\\Intro.gif");
				if (fileInfo.Exists)
				{
					image = Image.FromFile(fileInfo.FullName);
				}
			}
			else
			{
				image = Image.FromFile(fileInfo.FullName);
			}
		}
		else
		{
			image = Image.FromFile(fileInfo.FullName);
		}
		if (image == null)
		{
			buLogVer5.addToLog("clsFile", "OpenIntroImage", "Intro Image Load", "Fail", -1.0, 0.0);
			buString.MessageBoxError("Intro Image File Missing");
		}
		return image;
	}

	public static Image OpenCompanyImage(string Path)
	{
		Image image = null;
		FileInfo fileInfo = new FileInfo(Path + "\\Company.jpg");
		if (!fileInfo.Exists)
		{
			fileInfo = new FileInfo(Path + "\\Company.png");
			if (fileInfo.Exists)
			{
				image = Image.FromFile(fileInfo.FullName);
			}
		}
		else
		{
			image = Image.FromFile(fileInfo.FullName);
		}
		if (image == null)
		{
			buLogVer5.addToLog("clsFile", "OpenCompanyImage", "Intro Image Load", "Fail", -1.0, 0.0);
		}
		return image;
	}

	public static void OpenDefinationFile()
	{
		try
		{
			clsVar.appDefination.Name = "buCad/Cam";
			clsVar.appDefination.Description = "";
			clsVar.appDefination.Vendor = "CMD Software & Automation Ltd. Şti";
			clsVar.appDefination.Mode = "";
			clsVar.appDefination.Web = "www.cmdsoft.com.tr";
			buLogVer5.addToLog("clsFile", "DefinationFile", "Defination File Load", "Ok", -1.0, 0.0);
			Application.DoEvents();
		}
		catch (Exception mSException)
		{
			buLogVer5.addToLog("clsFile", "DefinationFile", "Defination File Load", "Fail", -1.0, 0.0);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static bool ReadDevFile()
	{
		try
		{
			FileInfo fileInfo = new FileInfo(AppPath.Base + "\\_developer.dll");
			if (!fileInfo.Exists)
			{
				return false;
			}
			string Str = "";
			buFile.OpenFromFile(fileInfo.FullName, ref Str);
			if (Str.Length <= 400)
			{
				AppBool.DeveloperMode = false;
				return false;
			}
			string text = Str[143].ToString();
			string text2 = Str[276].ToString();
			string text3 = Str[399].ToString();
			if (!((text == "V") & (text2 == "d") & (text3 == "y")))
			{
				AppBool.DeveloperMode = false;
				return false;
			}
			buLog.addLog("ReadDev File", "Ok", MethodBase.GetCurrentMethod().Name);
			AppBool.DeveloperMode = true;
			return true;
		}
		catch (Exception mSException)
		{
			buLog.addLog("ReadDev File", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public static bool ReadDevFileFull()
	{
		try
		{
			FileInfo fileInfo = new FileInfo(AppPath.Base + "\\_developerfull.dll");
			if (fileInfo.Exists)
			{
				string Str = "";
				buFile.OpenFromFile(fileInfo.FullName, ref Str);
				if (Str.Length <= 400)
				{
					return false;
				}
				string text = Str[143].ToString();
				string text2 = Str[276].ToString();
				string text3 = Str[399].ToString();
				if (!((text == "V") & (text2 == "d") & (text3 == "y")))
				{
					return false;
				}
				buLog.addLog("ReadDev File", "Ok", MethodBase.GetCurrentMethod().Name);
				return true;
			}
			return false;
		}
		catch (Exception mSException)
		{
			buLog.addLog("ReadDev File", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}

	public static void SaveBackupFile(string FileName, BackupModes Modes, bool Compress)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Backup);
			if (!directoryInfo.Exists)
			{
				Directory.CreateDirectory(AppPath.Backup);
			}
			string text = AppPath.Backup + "\\" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
			if (FileName.Trim().Length > 0)
			{
				string fileNameWithoutExtension = buFile.getFileNameWithoutExtension(FileName);
				string text2 = buFile.GetPath(FileName) + "\\" + fileNameWithoutExtension;
				DirectoryInfo directoryInfo2 = new DirectoryInfo(text2);
				if (!directoryInfo2.Exists)
				{
					Directory.CreateDirectory(text2);
				}
				text = text2;
			}
			DirectoryInfo directoryInfo3 = new DirectoryInfo(text);
			FileInfo fileInfo = null;
			if (!directoryInfo3.Exists)
			{
				Directory.CreateDirectory(directoryInfo3.FullName);
			}
			DirectoryInfo directoryInfo4 = new DirectoryInfo(text + "\\Settings");
			if (!directoryInfo3.Exists)
			{
				Directory.CreateDirectory(directoryInfo4.FullName);
				buFile5.CopyFilesRecursively(AppPath.Settings, directoryInfo4.FullName);
			}
			if (Modes.Settings)
			{
				SaveParameter(directoryInfo3.FullName, "");
			}
			if (Modes.Macro)
			{
				fileInfo = new FileInfo(AppPath.User + "\\Macro.bumacro");
				if (fileInfo.Exists)
				{
					File.Copy(fileInfo.FullName, directoryInfo3.FullName + "\\Macro.bumacro", overwrite: true);
				}
			}
			if (Modes.ShortKeys)
			{
				fileInfo = new FileInfo(AppPath.User + "\\ShortKey.bukey");
				if (fileInfo.Exists)
				{
					File.Copy(fileInfo.FullName, directoryInfo3.FullName + "\\ShortKey.bukey", overwrite: true);
				}
			}
			if (Modes.mnbucf)
			{
				fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
				if (fileInfo.Exists)
				{
					File.Copy(fileInfo.FullName, directoryInfo3.FullName + "\\mnbucfd.dll", overwrite: true);
				}
			}
			if (Modes.Runtime)
			{
				fileInfo = new FileInfo(AppPath.Settings + "\\Runtime.prm");
				if (fileInfo.Exists)
				{
					File.Copy(fileInfo.FullName, directoryInfo3.FullName + "\\Runtime.prm", overwrite: true);
				}
			}
			if (Modes.Diemaker)
			{
				fileInfo = new FileInfo(AppPath.Settings + "\\Heff.bucf2set");
				if (fileInfo.Exists)
				{
					File.Copy(fileInfo.FullName, directoryInfo3.FullName + "\\Heff.bucf2set", overwrite: true);
				}
			}
			if (!Modes.Nesting)
			{
			}
			if (Modes.Post && ccVars.PostActive.FileName.Length > 0)
			{
				fileInfo = new FileInfo(ccVars.PostActive.FileName);
				if (fileInfo.Exists)
				{
					string fileName = buFile.getFileName(fileInfo.FullName);
					File.Copy(fileInfo.FullName, directoryInfo3.FullName + "\\" + fileName, overwrite: true);
				}
			}
			if (Modes.ActualOperation & (ccVars.Pages.Count > 0))
			{
				clsInit.appCommand.SavePage(directoryInfo3.FullName + "\\actualFile.bucadv5");
			}
			if (!Modes.LastCreatedCode)
			{
			}
			if (Modes.LastImportedFile && clsVar.varInterface.LastImportedFiles[0].ToString().Length > 1)
			{
				string fileName2 = buFile.getFileName(clsVar.varInterface.LastImportedFiles[0].ToString());
				FileInfo fileInfo2 = new FileInfo(clsVar.varInterface.LastImportedFiles[0].ToString());
				if (fileInfo2.Exists)
				{
					File.Copy(clsVar.varInterface.LastImportedFiles[0].ToString(), directoryInfo3.FullName + "\\LastImport_" + fileName2, overwrite: true);
				}
			}
			if (Modes.LastLoadedFile && clsVar.varInterface.LastLoadedFiles[0].ToString().Length > 1)
			{
				string fileName3 = buFile.getFileName(clsVar.varInterface.LastLoadedFiles[0].ToString());
				FileInfo fileInfo3 = new FileInfo(clsVar.varInterface.LastLoadedFiles[0].ToString());
				if (fileInfo3.Exists)
				{
					File.Copy(clsVar.varInterface.LastLoadedFiles[0].ToString(), directoryInfo3.FullName + "\\LastLoad_" + fileName3, overwrite: true);
				}
			}
			if (!Modes.Marble)
			{
			}
			if (!Modes.Profile)
			{
			}
			if (Modes.ScreenShot)
			{
				Bitmap SSBmp = null;
				buImage5.GetScreenShot(clsItem.FrmMain, ref SSBmp);
				SSBmp?.Save(directoryInfo3.FullName + "\\ScreeenShot.bmp");
			}
			if (Compress)
			{
				FileInfo fileInfo4 = new FileInfo(FileName);
				if (fileInfo4.Exists)
				{
					fileInfo4.Delete();
				}
				buFile.ZipFolderToFile(directoryInfo3.FullName, FileName);
				string path = buFile.GetPath(FileName) + "\\" + buFile.getFileNameWithoutExtension(FileName);
				DirectoryInfo directoryInfo5 = new DirectoryInfo(path);
				if (directoryInfo5.Exists)
				{
					directoryInfo5.Delete(recursive: true);
				}
			}
			buLog.addLog("Backup File Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog("Backup File Not Saved", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenSystemFile(ref systemFileArg e)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(AppPath.Base + "\\busydmch.dll");
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.DemoMode)
				{
					e.ReachDemoModeFileOpenLimit = true;
					e.ReachDemoModeRunLimit = true;
					MessageBox.Show(AppLanguage.CadCamMessages[73]);
				}
				return;
			}
			BinaryReader binaryReader = null;
			FileStream input = new FileStream(AppPath.Base + "\\busydmch.dll", FileMode.Open);
			binaryReader = new BinaryReader(input);
			decimal num = default(decimal);
			for (int i = 0; i < 398; i++)
			{
				binaryReader.ReadSingle();
			}
			for (int j = 0; j < 1278; j++)
			{
				binaryReader.ReadDouble();
			}
			for (int k = 0; k < 6298; k++)
			{
				num = binaryReader.ReadDecimal();
			}
			for (int l = 0; l < 4952; l++)
			{
				_ = (double)binaryReader.ReadInt32();
			}
			for (int m = 0; m < 6543; m++)
			{
				binaryReader.ReadSingle();
			}
			for (int n = 0; n < 8543; n++)
			{
				binaryReader.ReadDouble();
			}
			for (int num2 = 0; num2 < 8643; num2++)
			{
				num = binaryReader.ReadDecimal();
			}
			for (int num3 = 0; num3 < 8524; num3++)
			{
				_ = (double)binaryReader.ReadInt32();
			}
			int num4 = binaryReader.ReadInt32();
			int num5 = binaryReader.ReadInt32();
			int num6 = binaryReader.ReadInt32();
			clsVar.OpenedFileCount = binaryReader.ReadInt32();
			clsVar.RunCount = binaryReader.ReadInt32();
			e.ReachDemoModeFileOpenLimit = false;
			e.ReachDemoModeRunLimit = false;
			if (!clsVar.appModes_0.DeveloperMode)
			{
				if (!((clsVar.OpenedFileCount >= clsVar.appModes_0.NumberOfDemoOpenFile) & (clsVar.appModes_0.NumberOfDemoOpenFile > 0)))
				{
					clsVar.OpenedFileCount = 0;
				}
				else if ((num4 >= DateTime.Now.Year) & (num5 >= DateTime.Now.Month) & (num6 >= DateTime.Now.Day))
				{
					e.ReachDemoModeFileOpenLimit = true;
				}
				if (!((clsVar.RunCount >= clsVar.appModes_0.NumberOfDemoRun) & (clsVar.appModes_0.NumberOfDemoRun > 0)))
				{
					clsVar.RunCount = 0;
				}
				else if ((num4 >= DateTime.Now.Year) & (num5 >= DateTime.Now.Month) & (num6 >= DateTime.Now.Day))
				{
					e.ReachDemoModeRunLimit = true;
				}
			}
			binaryReader.Close();
		}
		catch (Exception)
		{
			if (clsVar.appModes_0.DemoMode)
			{
				e.ReachDemoModeFileOpenLimit = true;
				e.ReachDemoModeRunLimit = true;
			}
		}
	}

	public void SaveSystemFile()
	{
		BinaryWriter binaryWriter = null;
		FileStream output = new FileStream(AppPath.Base + "\\busydmch.dll", FileMode.Create);
		binaryWriter = new BinaryWriter(output);
		float num = 0f;
		double num2 = 0.0;
		decimal num3 = default(decimal);
		Random random = new Random();
		for (int i = 0; i < 398; i++)
		{
			int num4 = random.Next(500);
			num = (float)num4 * 1.8764f;
			binaryWriter.Write(num);
		}
		for (int j = 0; j < 1278; j++)
		{
			int num5 = random.Next(800);
			num2 = (double)num5 * 23.567;
			binaryWriter.Write(num2);
		}
		for (int k = 0; k < 6298; k++)
		{
			int num6 = random.Next(12000);
			num3 = (decimal)((double)num6 * 4.123);
			binaryWriter.Write(num3);
		}
		for (int l = 0; l < 4952; l++)
		{
			int value = random.Next(2015);
			binaryWriter.Write(value);
		}
		for (int m = 0; m < 6543; m++)
		{
			int num7 = random.Next(500);
			num = (float)num7 * 1.9764f;
			binaryWriter.Write(num);
		}
		for (int n = 0; n < 8543; n++)
		{
			int num8 = random.Next(800);
			num2 = (double)num8 * 23.667;
			binaryWriter.Write(num2);
		}
		for (int num9 = 0; num9 < 8643; num9++)
		{
			int num10 = random.Next(12000);
			num3 = (decimal)((double)num10 * 4.223);
			binaryWriter.Write(num3);
		}
		for (int num11 = 0; num11 < 8524; num11++)
		{
			int value2 = random.Next(2015);
			binaryWriter.Write(value2);
		}
		binaryWriter.Write(DateTime.Now.Year);
		binaryWriter.Write(DateTime.Now.Month);
		binaryWriter.Write(DateTime.Now.Day);
		binaryWriter.Write(clsVar.OpenedFileCount);
		binaryWriter.Write(clsVar.RunCount);
		for (int num12 = 0; num12 < 7868; num12++)
		{
			int num13 = random.Next(500);
			num = (float)num13 * 1.8764f;
			binaryWriter.Write(num);
		}
		for (int num14 = 0; num14 < 6688; num14++)
		{
			int num15 = random.Next(800);
			num2 = (double)num15 * 23.567;
			binaryWriter.Write(num2);
		}
		for (int num16 = 0; num16 < 9642; num16++)
		{
			int num17 = random.Next(12000);
			num3 = (decimal)((double)num17 * 4.123);
			binaryWriter.Write(num3);
		}
		for (int num18 = 0; num18 < 3456; num18++)
		{
			int value3 = random.Next(2015);
			binaryWriter.Write(value3);
		}
		for (int num19 = 0; num19 < 9743; num19++)
		{
			int num20 = random.Next(500);
			num = (float)num20 * 1.9764f;
			binaryWriter.Write(num);
		}
		for (int num21 = 0; num21 < 12873; num21++)
		{
			int num22 = random.Next(800);
			num2 = (double)num22 * 23.667;
			binaryWriter.Write(num2);
		}
		for (int num23 = 0; num23 < 7532; num23++)
		{
			int num24 = random.Next(12000);
			num3 = (decimal)((double)num24 * 4.223);
			binaryWriter.Write(num3);
		}
		for (int num25 = 0; num25 < 3457; num25++)
		{
			int value4 = random.Next(2015);
			binaryWriter.Write(value4);
		}
		binaryWriter.Close();
	}

	public void OpenToolFile(ref List<ToolGroup5> Tools)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = clsVar.varInterface.pathData;
		openFileDialog.Multiselect = false;
		openFileDialog.Filter = "buCad/Cam Tools File (*.butools)|*.butools";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
		clsVar.varInterface.pathData = fileInfo.DirectoryName;
		ArrayList StringList = new ArrayList();
		buFile.OpenFromFile(fileInfo.FullName, ref StringList);
		List<List<string>> CalcList = new List<List<string>>();
		List<List<string>> CalcList2 = new List<List<string>>();
		buString.ListToSpecificList("<ToolGroup5>", "</ToolGroup5>", AddStartEndKey: true, StringList, ref CalcList2);
		if (CalcList2.Count > 0)
		{
			Tools.Clear();
		}
		for (int i = 0; i <= CalcList2.Count - 1; i++)
		{
			ToolGroup5 toolGroup = new ToolGroup5();
			buSerilization5.Decode(CalcList2[i], "", SerilizationMode5.MultiLine, toolGroup);
			buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", AddStartEndKey: true, CalcList2[i], ref CalcList);
			new List<ToolBase5>();
			for (int j = 0; j <= CalcList.Count - 1; j++)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(CalcList[j].ToArray());
				ToolBase5 toolBase = new ToolBase5();
				buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, toolBase);
				toolGroup.Tools.Add(toolBase);
			}
			Tools.Add(toolGroup);
		}
	}

	public void OpenToolFile(ref List<ToolBase5> Tools)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = clsVar.varInterface.pathData;
		openFileDialog.Multiselect = false;
		openFileDialog.Filter = "buCad/Cam Tools Group File (*.butoolgroup)|*.butoolgroup";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
			clsVar.varInterface.pathData = fileInfo.DirectoryName;
			ArrayList StringList = new ArrayList();
			buFile.OpenFromFile(fileInfo.FullName, ref StringList);
			List<List<string>> CalcList = new List<List<string>>();
			buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", AddStartEndKey: true, StringList, ref CalcList);
			if (CalcList.Count > 0)
			{
				Tools.Clear();
			}
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				ToolBase5 toolBase = new ToolBase5();
				buSerilization5.Decode(CalcList[i], "", SerilizationMode5.MultiLine, toolBase);
				Tools.Add(toolBase);
			}
		}
	}

	public void SaveToolFile(List<ToolGroup5> Tools)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathData;
		saveFileDialog.Filter = "buCad/Cam Tools File (*.butools)|*.butools";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
		clsVar.varInterface.pathData = fileInfo.DirectoryName;
		ArrayList arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("  buCadCam Tools ");
		arrayList.Add("------------------------------------------------------------------------");
		for (int i = 0; i <= Tools.Count - 1; i++)
		{
			arrayList.Add("<ToolGroup5>");
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(Tools[i].ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList2.RemoveAt(0);
			arrayList2.RemoveAt(arrayList2.Count - 1);
			arrayList.AddRange(arrayList2);
			for (int j = 0; j <= Tools[i].Tools.Count - 1; j++)
			{
				arrayList.AddRange(Tools[i].Tools[j].ToDefAll("", 6, SerilizationMode5.MultiLine));
			}
			arrayList.Add("</ToolGroup5>");
		}
		buFile.SaveToFile(arrayList, saveFileDialog.FileName);
	}

	public void SaveToolFile(List<ToolBase5> Tools)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathData;
		saveFileDialog.Filter = "buCad/Cam Tools Group File (*.butoolgroup)|*.butoolgroup";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
			clsVar.varInterface.pathData = fileInfo.DirectoryName;
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("  buCadCam Tools Groups ");
			arrayList.Add("------------------------------------------------------------------------");
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				arrayList.AddRange(Tools[i].ToDefAll("", 6, SerilizationMode5.MultiLine));
			}
			buFile.SaveToFile(arrayList, saveFileDialog.FileName);
		}
	}

	public void cmdShowCF2Fileroperties()
	{
		try
		{
			if (clsItem.FrmCf2Properties == null)
			{
				return;
			}
			if (clsItem.FrmCf2Properties.Visible)
			{
				clsItem.FrmCf2Properties.Visible = false;
				return;
			}
			clsItem.FrmCf2Properties.Cf2Properties.Clear();
			clsItem.FrmCf2Properties.Cf2Properties = new List<Cf2FileProperties>();
			for (int i = 0; i <= clsVar.Cf2Properties.Count - 1; i++)
			{
				Cf2FileProperties item = new Cf2FileProperties(clsVar.Cf2Properties[i]);
				clsItem.FrmCf2Properties.Cf2Properties.Add(item);
			}
			clsItem.FrmCf2Properties.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmCf2Properties.pathCf2File = clsVar.varInterface.pathCf2Settings;
			clsItem.FrmCf2Properties.fileCf2SettingsName = clsVar.varInterface.fileCf2SettingsName;
			clsItem.FrmCf2Properties.Init();
			clsItem.FrmCf2Properties.ShowDialog();
			if (clsItem.FrmCf2Properties.PropertiesForm.Result == DialogResult.OK)
			{
				clsVar.Cf2Properties.Clear();
				clsVar.Cf2Properties = new List<Cf2FileProperties>();
				for (int j = 0; j <= clsItem.FrmCf2Properties.Cf2Properties.Count - 1; j++)
				{
					Cf2FileProperties item2 = new Cf2FileProperties(clsItem.FrmCf2Properties.Cf2Properties[j]);
					clsVar.Cf2Properties.Add(item2);
				}
				clsVar.varInterface.pathCf2Settings = clsItem.FrmCf2Properties.pathCf2File;
				clsVar.varInterface.fileCf2SettingsName = clsItem.FrmCf2Properties.fileCf2SettingsName;
				SaveParameter();
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdShowDxfileroperties()
	{
		try
		{
			if (clsItem.FrmDxfProperties != null && clsItem.FrmDxfProperties.Visible)
			{
				clsItem.FrmDxfProperties.Visible = false;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void OpenCadFiles(string FileName, ref List<Entity> OpenedEntities)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(FileName);
			OpenedEntities.Clear();
			OpenedEntities = new List<Entity>();
			bool clear = true;
			if (modelCommon == null)
			{
				modelCommon = new Design();
			}
			if (fileInfo.Extension.ToLower() == ".bucadv5")
			{
				modelCommon.Clear();
				OpenBuCadFileVer5(fileInfo.FullName, clear, ref modelCommon);
				for (int i = 0; i <= modelCommon.Entities.Count - 1; i++)
				{
					OpenedEntities.Add(buVector5.CopyEntities(modelCommon.Entities[i]));
				}
			}
			if (!(fileInfo.Extension.ToLower() == ".bucad"))
			{
				if (!(fileInfo.Extension.ToLower() == ".ply"))
				{
					if (!(fileInfo.Extension.ToLower() == ".cf2"))
					{
						if (!(fileInfo.Extension.ToLower() == ".hpgl"))
						{
							if (!((fileInfo.Extension.ToLower() == ".xyz") | (fileInfo.Extension.ToLower() == ".txt")))
							{
								if (!((fileInfo.Extension.ToLower() == ".cnc") | (fileInfo.Extension.ToLower() == ".nc") | (fileInfo.Extension.ToLower() == ".mpf")))
								{
									if (!(fileInfo.Extension.ToLower() == ".dxf"))
									{
										if (!(fileInfo.Extension.ToLower() == ".dwg"))
										{
											if (!(fileInfo.Extension.ToLower() == ".stl"))
											{
												if (!(fileInfo.Extension.ToLower() == ".obj"))
												{
													if (fileInfo.Extension.ToLower() == ".3ds")
													{
														return;
													}
													if (!(fileInfo.Extension.ToLower() == ".asc"))
													{
														if (!(fileInfo.Extension.ToLower() == ".dwf"))
														{
															if (fileInfo.Extension.ToLower() == ".ifc")
															{
																return;
															}
															if (!(fileInfo.Extension.ToLower() == ".jt"))
															{
																if (!(fileInfo.Extension.ToLower() == ".las"))
																{
																	if (!(fileInfo.Extension.ToLower() == ".pdf"))
																	{
																		if (!((fileInfo.Extension.ToLower() == ".step") | (fileInfo.Extension.ToLower() == ".stp")))
																		{
																			if (!((fileInfo.Extension.ToLower() == ".iges") | (fileInfo.Extension.ToLower() == ".igs")))
																			{
																				if (!((fileInfo.Extension.ToLower() == ".medit") | (fileInfo.Extension.ToLower() == ".mesh")))
																				{
																				}
																				return;
																			}
																			ReadFileAsync readFileAsync = new ReadIGES(fileInfo.FullName);
																			modelCommon.Clear();
																			modelCommon.DoWork(readFileAsync);
																			for (int j = 0; j <= readFileAsync.Entities.Count - 1; j++)
																			{
																				OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[j]));
																			}
																		}
																		else
																		{
																			ReadFileAsync readFileAsync2 = new ReadSTEP(fileInfo.FullName);
																			modelCommon.Clear();
																			modelCommon.DoWork(readFileAsync2);
																			for (int k = 0; k <= readFileAsync2.Entities.Count - 1; k++)
																			{
																				OpenedEntities.Add(buVector5.CopyEntities(readFileAsync2.Entities[k]));
																			}
																		}
																	}
																	else
																	{
																		ReadFileAsync readFileAsync3 = new ReadPDF(fileInfo.FullName);
																		modelCommon.Clear();
																		modelCommon.DoWork(readFileAsync3);
																		for (int l = 0; l <= readFileAsync3.Entities.Count - 1; l++)
																		{
																			OpenedEntities.Add(buVector5.CopyEntities(readFileAsync3.Entities[l]));
																		}
																	}
																}
																else
																{
																	ReadFileAsync readFileAsync4 = new ReadLAS(fileInfo.FullName);
																	modelCommon.Clear();
																	modelCommon.DoWork(readFileAsync4);
																	for (int m = 0; m <= readFileAsync4.Entities.Count - 1; m++)
																	{
																		OpenedEntities.Add(buVector5.CopyEntities(readFileAsync4.Entities[m]));
																	}
																}
															}
															else
															{
																ReadFileAsync readFileAsync5 = new ReadJT(fileInfo.FullName);
																modelCommon.Clear();
																modelCommon.DoWork(readFileAsync5);
																for (int n = 0; n <= readFileAsync5.Entities.Count - 1; n++)
																{
																	OpenedEntities.Add(buVector5.CopyEntities(readFileAsync5.Entities[n]));
																}
															}
														}
														else
														{
															ReadFileAsync readFileAsync6 = new ReadDWF(fileInfo.FullName);
															modelCommon.Clear();
															modelCommon.DoWork(readFileAsync6);
															for (int num = 0; num <= readFileAsync6.Entities.Count - 1; num++)
															{
																OpenedEntities.Add(buVector5.CopyEntities(readFileAsync6.Entities[num]));
															}
														}
													}
													else
													{
														ReadFileAsync readFileAsync7 = new ReadASC(fileInfo.FullName);
														modelCommon.Clear();
														modelCommon.DoWork(readFileAsync7);
														for (int num2 = 0; num2 <= readFileAsync7.Entities.Count - 1; num2++)
														{
															OpenedEntities.Add(buVector5.CopyEntities(readFileAsync7.Entities[num2]));
														}
													}
												}
												else
												{
													ReadFileAsync readFileAsync8 = new ReadOBJ(fileInfo.FullName);
													modelCommon.Clear();
													modelCommon.DoWork(readFileAsync8);
													for (int num3 = 0; num3 <= readFileAsync8.Entities.Count - 1; num3++)
													{
														OpenedEntities.Add(buVector5.CopyEntities(readFileAsync8.Entities[num3]));
													}
												}
											}
											else
											{
												ReadFileAsync readFileAsync9 = new ReadSTL(fileInfo.FullName);
												modelCommon.Clear();
												modelCommon.DoWork(readFileAsync9);
												for (int num4 = 0; num4 <= readFileAsync9.Entities.Count - 1; num4++)
												{
													OpenedEntities.Add(buVector5.CopyEntities(readFileAsync9.Entities[num4]));
												}
											}
										}
										else
										{
											ReadFileAsync readFileAsync10 = new ReadAutodesk(fileInfo.FullName);
											((ReadAutodesk)readFileAsync10).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
											modelCommon.Clear();
											modelCommon.DoWork(readFileAsync10);
											for (int num5 = 0; num5 <= readFileAsync10.Entities.Count - 1; num5++)
											{
												OpenedEntities.Add(buVector5.CopyEntities(readFileAsync10.Entities[num5]));
											}
										}
									}
									else
									{
										ReadFileAsync readFileAsync11 = new ReadAutodesk(fileInfo.FullName);
										((ReadAutodesk)readFileAsync11).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
										modelCommon.Clear();
										modelCommon.DoWork(readFileAsync11);
										for (int num6 = 0; num6 <= readFileAsync11.Entities.Count - 1; num6++)
										{
											OpenedEntities.Add(buVector5.CopyEntities(readFileAsync11.Entities[num6]));
										}
									}
								}
								else
								{
									modelCommon.Clear();
									OpenGCodeFile(fileInfo.FullName, clear, ref modelCommon);
									for (int num7 = 0; num7 <= modelCommon.Entities.Count - 1; num7++)
									{
										OpenedEntities.Add(buVector5.CopyEntities(modelCommon.Entities[num7]));
									}
								}
							}
							else
							{
								modelCommon.Clear();
								OpenXYZFile(fileInfo.FullName, clear, ref modelCommon);
								for (int num8 = 0; num8 <= modelCommon.Entities.Count - 1; num8++)
								{
									OpenedEntities.Add(buVector5.CopyEntities(modelCommon.Entities[num8]));
								}
							}
						}
						else
						{
							modelCommon.Clear();
							OpenHpglFile(fileInfo.FullName, clear, ref modelCommon);
							for (int num9 = 0; num9 <= modelCommon.Entities.Count - 1; num9++)
							{
								OpenedEntities.Add(buVector5.CopyEntities(modelCommon.Entities[num9]));
							}
						}
					}
					else
					{
						modelCommon.Clear();
						OpenCf2File(fileInfo.FullName, clear, ref modelCommon);
						for (int num10 = 0; num10 <= modelCommon.Entities.Count - 1; num10++)
						{
							OpenedEntities.Add(buVector5.CopyEntities(modelCommon.Entities[num10]));
						}
					}
				}
				else
				{
					modelCommon.Clear();
					OpenPlyFile(fileInfo.FullName, clear, ref modelCommon);
					for (int num11 = 0; num11 <= modelCommon.Entities.Count - 1; num11++)
					{
						OpenedEntities.Add(buVector5.CopyEntities(modelCommon.Entities[num11]));
					}
				}
			}
			else
			{
				modelCommon.Clear();
				OpenBuCadFileVer4(fileInfo.FullName, clear, ref modelCommon);
				for (int num12 = 0; num12 <= modelCommon.Entities.Count - 1; num12++)
				{
					OpenedEntities.Add(buVector5.CopyEntities(modelCommon.Entities[num12]));
				}
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			throw;
		}
	}

	public void OpenCadFiles(string FileName, bool ClearEntities, ref Design model)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(FileName);
			bool clear = (ccVars.Action == actionTypeBU.fileOpenAsPage) | (ccVars.Action == actionTypeBU.fileImportAsPage);
			if (!((clsVar.OpenedFileCount >= clsVar.appModes_0.NumberOfDemoOpenFile) & (clsVar.appModes_0.NumberOfDemoOpenFile > 0) & clsVar.appModes_0.DemoMode))
			{
				clsVar.OpenedFileCount++;
				SaveSystemFile();
				if (fileInfo.Extension.ToLower() == ".bucadv5")
				{
					OpenBuCadFileVer5(fileInfo.FullName, clear, ref model);
					if (ccVars.Action == actionTypeBU.fileInsert)
					{
						if (model.Entities != null)
						{
							for (int i = 0; i <= model.Entities.Count - 1; i++)
							{
								Entity entity = (Entity)model.Entities[i].Clone();
								entity.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
								clsInit.appCommand.AddEntity(entity);
							}
						}
						clsInit.appCommand.DrawingPropertiesUpdate();
					}
					if ((ccVars.Action == actionTypeBU.fileImportAsPage) | (ccVars.Action == actionTypeBU.fileOpenAsPage))
					{
						clsInit.appCommand.MaterialUpdate(FillMaterial: true, clsVar.varInterface.MaterialIndex);
					}
					clsInit.appCommand.OsnapCalculationByThread();
				}
				if (!(fileInfo.Extension.ToLower() == ".bucad"))
				{
					if (!(fileInfo.Extension.ToLower() == ".ply"))
					{
						if (!(fileInfo.Extension.ToLower() == ".cf2"))
						{
							if (!(fileInfo.Extension.ToLower() == ".hpgl"))
							{
								if (!((fileInfo.Extension.ToLower() == ".xyz") | (fileInfo.Extension.ToLower() == ".txt")))
								{
									if (!((fileInfo.Extension.ToLower() == ".cnc") | (fileInfo.Extension.ToLower() == ".nc") | (fileInfo.Extension.ToLower() == ".mpf")))
									{
										if (!(fileInfo.Extension.ToLower() == ".dxf"))
										{
											if (!(fileInfo.Extension.ToLower() == ".dwg"))
											{
												if (!(fileInfo.Extension.ToLower() == ".stl"))
												{
													if (!(fileInfo.Extension.ToLower() == ".obj"))
													{
														if (fileInfo.Extension.ToLower() == ".3ds")
														{
															return;
														}
														if (!(fileInfo.Extension.ToLower() == ".asc"))
														{
															if (!(fileInfo.Extension.ToLower() == ".dwf"))
															{
																if (fileInfo.Extension.ToLower() == ".ifc")
																{
																	return;
																}
																if (!(fileInfo.Extension.ToLower() == ".jt"))
																{
																	if (!(fileInfo.Extension.ToLower() == ".las"))
																	{
																		if (!(fileInfo.Extension.ToLower() == ".pdf"))
																		{
																			if (!((fileInfo.Extension.ToLower() == ".step") | (fileInfo.Extension.ToLower() == ".stp")))
																			{
																				if (!((fileInfo.Extension.ToLower() == ".iges") | (fileInfo.Extension.ToLower() == ".igs")))
																				{
																					if ((fileInfo.Extension.ToLower() == ".medit") | (fileInfo.Extension.ToLower() == ".mesh"))
																					{
																					}
																					return;
																				}
																				ReadFileAsync workUnit = new ReadIGES(fileInfo.FullName);
																				if (model == null)
																				{
																					if (ClearEntities)
																					{
																						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
																					}
																					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit);
																				}
																				else
																				{
																					model.Clear();
																					model.StartWork(workUnit);
																				}
																				return;
																			}
																			ReadFileAsync workUnit2 = new ReadSTEP(fileInfo.FullName);
																			if (model == null)
																			{
																				if (!ClearEntities)
																				{
																				}
																				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit2);
																			}
																			else
																			{
																				model.Clear();
																				model.StartWork(workUnit2);
																			}
																			return;
																		}
																		ReadFileAsync workUnit3 = new ReadPDF(fileInfo.FullName);
																		if (model == null)
																		{
																			if (ClearEntities)
																			{
																				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
																			}
																			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit3);
																		}
																		else
																		{
																			model.Clear();
																			model.StartWork(workUnit3);
																		}
																		return;
																	}
																	ReadFileAsync workUnit4 = new ReadLAS(fileInfo.FullName);
																	if (model == null)
																	{
																		if (ClearEntities)
																		{
																			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
																		}
																		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit4);
																	}
																	else
																	{
																		model.Clear();
																		model.StartWork(workUnit4);
																	}
																	return;
																}
																ReadFileAsync workUnit5 = new ReadJT(fileInfo.FullName);
																if (model == null)
																{
																	if (ClearEntities)
																	{
																		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
																	}
																	ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit5);
																}
																else
																{
																	model.Clear();
																	model.StartWork(workUnit5);
																}
																return;
															}
															ReadFileAsync workUnit6 = new ReadDWF(fileInfo.FullName);
															if (model == null)
															{
																if (ClearEntities)
																{
																	ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
																}
																ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit6);
															}
															else
															{
																model.Clear();
																model.StartWork(workUnit6);
															}
															return;
														}
														ReadFileAsync workUnit7 = new ReadASC(fileInfo.FullName);
														if (model == null)
														{
															if (ClearEntities)
															{
																ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
															}
															ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit7);
														}
														else
														{
															model.Clear();
															model.StartWork(workUnit7);
														}
														return;
													}
													ReadFileAsync workUnit8 = new ReadOBJ(fileInfo.FullName);
													if (model == null)
													{
														if (ClearEntities)
														{
															ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
														}
														ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit8);
													}
													else
													{
														model.Clear();
														model.StartWork(workUnit8);
													}
													return;
												}
												ReadFileAsync workUnit9 = new ReadSTL(fileInfo.FullName);
												if (model == null)
												{
													if (ClearEntities)
													{
														ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
													}
													ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(workUnit9);
												}
												else
												{
													model.Clear();
													model.StartWork(workUnit9);
												}
												return;
											}
											if (clsVar.appModes_0.CutterMode.Enable)
											{
												string fileName = fileInfo.Directory?.ToString() + "\\" + buFile.getFileNameWithoutExtension(fileInfo.FullName) + ".rul";
												FileInfo fileInfo2 = new FileInfo(fileName);
												if (!fileInfo2.Exists)
												{
													clsInit.appCutter.Properties = new RulProperties();
												}
												else
												{
													OpenRulFile(fileInfo2.FullName);
												}
											}
											if (clsNesting.ParNest.PartSettings.DeletePartAfterImport)
											{
												if (clsNesting.ParNest.PartSettings.SavePartsBeforeDeleted)
												{
													buFile5.bunesting bunesting = new buFile5.bunesting();
													bunesting.SaveNesting(AppPath.Misc + "\\PartDeleted_" + buFile.FileNameFromDate(0), clsNesting.Parts, new List<buNestingSheet>(), clsNesting.ParNest);
												}
												clsNesting.Parts.Clear();
											}
											if (clsNesting.ParNest.MaterailSettings.DeleteSheetAfterImport)
											{
												if (clsNesting.ParNest.MaterailSettings.SaveSheetsBeforeDeleted)
												{
													buFile5.bunesting bunesting2 = new buFile5.bunesting();
													bunesting2.SaveNesting(AppPath.Misc + "\\SheetDeleted_" + buFile.FileNameFromDate(0), new List<buNestingPart>(), clsNesting.Sheets, clsNesting.ParNest);
												}
												clsNesting.Sheets.Clear();
											}
											ReadFileAsync readFileAsync = new ReadAutodesk(fileInfo.FullName);
											((ReadAutodesk)readFileAsync).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
											if (model == null)
											{
												if (ClearEntities)
												{
													ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
												}
												ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(readFileAsync);
											}
											else
											{
												model.Clear();
												model.StartWork(readFileAsync);
											}
											return;
										}
										if (clsVar.appModes_0.CutterMode.Enable)
										{
											string fileName2 = fileInfo.Directory?.ToString() + "\\" + buFile.getFileNameWithoutExtension(fileInfo.FullName) + ".rul";
											FileInfo fileInfo3 = new FileInfo(fileName2);
											if (!fileInfo3.Exists)
											{
												clsInit.appCutter.Properties = new RulProperties();
											}
											else
											{
												OpenRulFile(fileInfo3.FullName);
											}
										}
										if (clsVar.appModes_0.NestingMode.Enable)
										{
											if (clsNesting.ParNest.PartSettings.DeletePartAfterImport)
											{
												if (clsNesting.ParNest.PartSettings.SavePartsBeforeDeleted)
												{
													buFile5.bunesting bunesting3 = new buFile5.bunesting();
													bunesting3.SaveNesting(AppPath.Misc + "\\PartDeleted_" + buFile.FileNameFromDate(0) + ".bunesting", clsNesting.Parts, new List<buNestingSheet>(), clsNesting.ParNest);
												}
												clsNesting.Parts.Clear();
											}
											if (clsNesting.ParNest.MaterailSettings.DeleteSheetAfterImport)
											{
												if (clsNesting.ParNest.MaterailSettings.SaveSheetsBeforeDeleted)
												{
													buFile5.bunesting bunesting4 = new buFile5.bunesting();
													bunesting4.SaveNesting(AppPath.Misc + "\\SheetDeleted_" + buFile.FileNameFromDate(0) + ".bunesting", new List<buNestingPart>(), clsNesting.Sheets, clsNesting.ParNest);
												}
												clsNesting.Sheets.Clear();
											}
										}
										ReadFileAsync readFileAsync2 = new ReadAutodesk(fileInfo.FullName);
										((ReadAutodesk)readFileAsync2).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
										if (model == null)
										{
											if (ClearEntities)
											{
												ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
											}
											ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork(readFileAsync2);
										}
										else
										{
											model.Clear();
											model.StartWork(readFileAsync2);
										}
										return;
									}
									OpenGCodeFile(fileInfo.FullName, clear, ref model);
									if (ccVars.Action != actionTypeBU.fileInsert)
									{
										return;
									}
									if (model.Entities != null)
									{
										for (int j = 0; j <= model.Entities.Count - 1; j++)
										{
											Entity entity2 = (Entity)model.Entities[j].Clone();
											entity2.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
											clsInit.appCommand.OsnapCalculation(entity2);
											ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity2);
										}
									}
									clsInit.appCommand.DrawingPropertiesUpdate();
									return;
								}
								OpenXYZFile(fileInfo.FullName, clear, ref model);
								if (ccVars.Action != actionTypeBU.fileInsert)
								{
									return;
								}
								if (model.Entities != null)
								{
									for (int k = 0; k <= model.Entities.Count - 1; k++)
									{
										Entity entity3 = (Entity)model.Entities[k].Clone();
										entity3.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
										clsInit.appCommand.OsnapCalculation(entity3);
										ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity3);
									}
								}
								clsInit.appCommand.DrawingPropertiesUpdate();
								return;
							}
							OpenHpglFile(fileInfo.FullName, clear, ref model);
							if (ccVars.Action != actionTypeBU.fileInsert)
							{
								return;
							}
							if (model.Entities != null)
							{
								for (int l = 0; l <= model.Entities.Count - 1; l++)
								{
									Entity entity4 = (Entity)model.Entities[l].Clone();
									entity4.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
									clsInit.appCommand.OsnapCalculation(entity4);
									ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity4);
								}
							}
							clsInit.appCommand.DrawingPropertiesUpdate();
							return;
						}
						OpenCf2File(fileInfo.FullName, clear, ref model);
						if (ccVars.Action != actionTypeBU.fileInsert)
						{
							return;
						}
						if (model.Entities != null)
						{
							for (int m = 0; m <= model.Entities.Count - 1; m++)
							{
								Entity entity5 = (Entity)model.Entities[m].Clone();
								entity5.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
								clsInit.appCommand.OsnapCalculation(entity5);
								ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity5);
							}
						}
						clsInit.appCommand.DrawingPropertiesUpdate();
						return;
					}
					OpenPlyFile(fileInfo.FullName, clear, ref model);
					if (ccVars.Action != actionTypeBU.fileInsert)
					{
						return;
					}
					if (model.Entities != null)
					{
						for (int n = 0; n <= model.Entities.Count - 1; n++)
						{
							Entity entity6 = (Entity)model.Entities[n].Clone();
							entity6.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity6);
						}
					}
					clsInit.appCommand.DrawingPropertiesUpdate();
					return;
				}
				OpenBuCadFileVer4(fileInfo.FullName, clear, ref model);
				if ((ccVars.Action == actionTypeBU.fileImportAsPage) | (ccVars.Action == actionTypeBU.fileOpenAsPage))
				{
					clsInit.appCommand.MaterialUpdate(FillMaterial: true, clsVar.varInterface.MaterialIndex);
				}
				if (ccVars.Action != actionTypeBU.fileInsert)
				{
					return;
				}
				if (model.Entities != null)
				{
					for (int num = 0; num <= model.Entities.Count - 1; num++)
					{
						Entity entity7 = (Entity)model.Entities[num].Clone();
						entity7.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity7);
					}
				}
				clsInit.appCommand.DrawingPropertiesUpdate();
			}
			else
			{
				MessageBox.Show(AppLanguage.CadCamMessages[71]);
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			throw;
		}
	}

	public void OpenBuCadFileVer5(string FileName, bool Clear, ref Design model)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\T");
		if (directoryInfo.Exists)
		{
			directoryInfo.Delete(recursive: true);
		}
		buFile.ExtractToFolder(AppPath.Base + "\\T", FileName);
		List<string> Files = new List<string>();
		buFile.getFiles(AppPath.Base + "\\T", ref Files);
		Files.Reverse();
		foreach (string item in Files)
		{
			FileInfo fileInfo = new FileInfo(item);
			if ((fileInfo.Extension == ".bupage") & fileInfo.Exists)
			{
				ReadFile readFile = new ReadFile(fileInfo.FullName, new MyFileSerializer(contentType.GeometryAndTessellation));
				readFile.DoWork();
				RegenOptions ro = new RegenOptions();
				if (model == null)
				{
					if (Clear)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
					}
					readFile.OpenTo(ccVars.Pages[ccVars.PageIndex].Form.viewportcad, ro);
					if (clsVar.appModes_0.TuftingMode.Enable)
					{
						List<Entity> BrokeEntities = new List<Entity>();
						if (clsVar.varFile.BreakCurveEntitiesByConnection)
						{
							clsInit.cVector5.BreakEntitiesWithIntersectionPoints(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref BrokeEntities);
						}
						if (BrokeEntities.Count > 0)
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
							for (int i = 0; i <= BrokeEntities.Count - 1; i++)
							{
								BrokeEntities[i].EntityData = new CustomData((CustomData)BrokeEntities[i].EntityData);
								ccVars.UndoDont = true;
								clsInit.appCommand.AddEntity(BrokeEntities[i]);
							}
						}
					}
				}
				else
				{
					if (model.Entities != null)
					{
						model.Entities.Clear();
					}
					readFile.OpenTo(model, ro);
				}
			}
			if (!((fileInfo.Extension == ".busets") & fileInfo.Exists))
			{
				continue;
			}
			if (model != null)
			{
				ArrayList StringList = new ArrayList();
				buFile.OpenFromFile(item, ref StringList);
				List<List<string>> CalcList = new List<List<string>>();
				buString.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", AddStartEndKey: true, StringList, ref CalcList);
				if (CalcList.Count > 0)
				{
					buCadCamFileInfo buCadCamFileInfo2 = new buCadCamFileInfo();
					buSerilization.Decode(CalcList[0], "", SerilizationMode.MultiLine, buCadCamFileInfo2);
					string notes = buCadCamFileInfo2.Notes;
					buCadCamFileInfo2.Notes = notes.Replace("{[NewLine]}", "\r\n");
					string s = buCadCamFileInfo2.ProgramVersionNo.Replace(".", "");
					MyFileSerializer.Version = int.Parse(s);
				}
				continue;
			}
			ccVars.Pages[ccVars.PageIndex].Layers.Clear();
			ccVars.Pages[ccVars.PageIndex].Scene.Clear();
			ArrayList StringList2 = new ArrayList();
			buFile.OpenFromFile(item, ref StringList2);
			List<List<string>> CalcList2 = new List<List<string>>();
			buString.ListToSpecificList("<LayerBase5>", "</LayerBase5>", AddStartEndKey: true, StringList2, ref CalcList2);
			for (int j = 0; j <= CalcList2.Count - 1; j++)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.AddRange(CalcList2[j].ToArray());
				LayerBase5 layerBase = new LayerBase5();
				buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, layerBase);
				layerBase = new LayerBase5(layerBase);
				ccVars.Pages[ccVars.PageIndex].Layers.Add(layerBase);
			}
			CalcList2 = new List<List<string>>();
			buString.ListToSpecificList("<PageScene>", "</PageScene>", AddStartEndKey: true, StringList2, ref CalcList2);
			for (int k = 0; k <= CalcList2.Count - 1; k++)
			{
				ArrayList arrayList2 = new ArrayList();
				arrayList2.AddRange(CalcList2[k].ToArray());
				PageScene scene = new PageScene();
				PageScene.DecodeLocal(CalcList2[k], "", ref scene);
				ccVars.Pages[ccVars.PageIndex].Scene.Add(scene);
			}
			CalcList2 = new List<List<string>>();
			buString.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", AddStartEndKey: true, StringList2, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				buCadCamFileInfo buCadCamFileInfo3 = new buCadCamFileInfo();
				buSerilization.Decode(CalcList2[0], "", SerilizationMode.MultiLine, buCadCamFileInfo3);
				string notes2 = buCadCamFileInfo3.Notes;
				buCadCamFileInfo3.Notes = notes2.Replace("{[NewLine]}", "\r\n");
			}
		}
		if (model == null)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers.Count > 0)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(ccVars.Pages[ccVars.PageIndex].Layers);
			}
			clsItem.timOpenAfter.Enabled = true;
		}
	}

	public void OpenBuCadFileVer5(string FileName, bool Clear, ref List<Entity> refEntities)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\T");
		if (directoryInfo.Exists)
		{
			directoryInfo.Delete(recursive: true);
		}
		buFile.ExtractToFolder(AppPath.Base + "\\T", FileName);
		List<string> Files = new List<string>();
		buFile.getFiles(AppPath.Base + "\\T", ref Files);
		Files.Reverse();
		foreach (string item in Files)
		{
			FileInfo fileInfo = new FileInfo(item);
			if (!((fileInfo.Extension == ".bupage") & fileInfo.Exists))
			{
				continue;
			}
			ReadFile readFile = new ReadFile(fileInfo.FullName, new MyFileSerializer(contentType.GeometryAndTessellation));
			readFile.DoWork();
			RegenOptions ro = new RegenOptions();
			Design design = new Design();
			design.CreateControl();
			Viewport value = new Viewport();
			design.Viewports.Add(value);
			readFile.OpenTo(design, ro);
			refEntities = new List<Entity>();
			for (int i = 0; i <= design.Entities.Count - 1; i++)
			{
				Entity copiedEntity = null;
				buEntity.Copy(design.Entities[i], ref copiedEntity);
				if (copiedEntity != null)
				{
					copiedEntity.LayerName = "Default";
					copiedEntity.ColorMethod = colorMethodType.byEntity;
					refEntities.Add(copiedEntity);
				}
			}
		}
	}

	public void OpenBuTeachFile(string FileName, ref List<EntitiesGroup> refGroups)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (!fileInfo.Exists)
		{
			return;
		}
		ArrayList StringList = new ArrayList();
		buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
		List<List<string>> CalcList = new List<List<string>>();
		buString.ListToSpecificList("<Contour>", "</Contour>", AddStartEndKey: false, StringList, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			List<string> CalcList2 = new List<string>();
			buString.ListToSpecificList("<Outer>", "</Outer>", AddStartEndKey: false, CalcList[i], ref CalcList2);
			List<List<string>> CalcList3 = new List<List<string>>();
			buString.ListToSpecificList("<Inside>", "</Inside>", AddStartEndKey: false, CalcList[i], ref CalcList3);
			EntitiesGroup entitiesGroup = new EntitiesGroup();
			if (CalcList3.Count > 0)
			{
				entitiesGroup.Inside = new List<List<Entity>>();
				for (int j = 0; j <= CalcList3.Count - 1; j++)
				{
					List<Entity> refEntities = new List<Entity>();
					clsInit.cVector5.GetEntitiesFronEntityStrings(CalcList3[j], ref refEntities);
					if (refEntities.Count > 0)
					{
						entitiesGroup.Inside.Add(refEntities);
					}
				}
			}
			if (CalcList2.Count > 0)
			{
				clsInit.cVector5.GetEntitiesFronEntityStrings(CalcList2, ref entitiesGroup.Outside);
				if (entitiesGroup.Outside.Count > 0)
				{
					refGroups.Add(entitiesGroup);
				}
			}
		}
	}

	public void OpenBuCadFileVer4(string FileName, bool Clear, ref Design model)
	{
		buCadFileOpenOptions options = new buCadFileOpenOptions();
		buCadCamFileInfo FileInfo = new buCadCamFileInfo();
		List<eEntities> Entities = new List<eEntities>();
		List<LayerBase> Layers = new List<LayerBase>();
		List<LayerBase5> list = new List<LayerBase5>();
		List<Entity> eyeEntity = new List<Entity>();
		buFile.OpenBuCadCam(FileName, options, ref FileInfo, ref Entities, ref Layers);
		for (int i = 0; i <= Layers.Count - 1; i++)
		{
			LayerBase5 layerBase = new LayerBase5();
			layerBase.Enable = Layers[i].Enable;
			layerBase.LayerColor = Layers[i].LayerColor;
			layerBase.LayerPurposes = Layers[i].LayerPurposes;
			layerBase.LayerThickness = Layers[i].LayerThickness;
			layerBase.Lock = Layers[i].Lock;
			layerBase.MaterialName = Layers[i].MaterialName;
			layerBase.Mode = Layers[i].Mode;
			layerBase.Name = Layers[i].Name;
			layerBase.Note = Layers[i].Note;
			layerBase.Option = Layers[i].Option;
			layerBase.Pattern.Name = Layers[i].Pattern.Name;
			layerBase.Pattern.Type = Layers[i].Pattern.Type;
			layerBase.RealDrawMode = Layers[i].RealDrawMode;
			layerBase.ShownName = Layers[i].ShownName;
			layerBase.Transparency = Layers[i].Transparency;
			list.Add(layerBase);
		}
		buConversion5.buEntityToEyeEntity(Entities, SetCurrentData: true, ref eyeEntity, list, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
		if (model != null)
		{
			model.Entities.Clear();
			model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list);
			for (int j = 0; j <= eyeEntity.Count - 1; j++)
			{
				model.Entities.Add(eyeEntity[j]);
			}
			return;
		}
		if (Clear)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list);
		for (int k = 0; k <= eyeEntity.Count - 1; k++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity[k]);
		}
		clsItem.timOpenAfter.Enabled = true;
	}

	public void OpenPlyFile(string FileName, bool Clear, ref Design model)
	{
		new buCadFileOpenOptions();
		new buCadCamFileInfo();
		List<eEntities> Entities = new List<eEntities>();
		new List<LayerBase5>();
		List<Entity> eyeEntity = new List<Entity>();
		buFile.Ply ply = new buFile.Ply();
		ply.ReadPly(FileName, ref Entities);
		List<LayerBase5> list = new List<LayerBase5>();
		LayerBase5 layerBase = new LayerBase5("Layer1");
		layerBase.LayerColor = Color.DimGray;
		list.Add(layerBase);
		buConversion5.buEntityToEyeEntity(Entities, SetCurrentData: true, ref eyeEntity, list, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
		if (model != null)
		{
			model.Clear();
			model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list);
			for (int i = 0; i <= eyeEntity.Count - 1; i++)
			{
				model.Entities.Add(eyeEntity[i]);
			}
			return;
		}
		if (Clear)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list);
		for (int j = 0; j <= eyeEntity.Count - 1; j++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity[j]);
		}
		clsItem.timOpenAfter.Enabled = true;
	}

	public void OpenXYZFile(string FileName, bool Clear, ref Design model)
	{
		List<string> StringList = new List<string>();
		buFile5.OpenFromFile(FileName, ref StringList);
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			string[] array = StringList[i].Split(';');
			if (array != null)
			{
				if (array.Length == 2)
				{
					Point3D point3D = new Point3D();
					double.TryParse(array[0].Trim(), out point3D.X);
					double.TryParse(array[1].Trim(), out point3D.Y);
					list.Add(point3D);
				}
				if (array.Length == 3)
				{
					Point3D point3D2 = new Point3D();
					double.TryParse(array[0].Trim(), out point3D2.X);
					double.TryParse(array[1].Trim(), out point3D2.Y);
					double.TryParse(array[2].Trim(), out point3D2.Z);
					list.Add(point3D2);
				}
			}
		}
		if (list.Count < 2)
		{
			return;
		}
		if (model != null)
		{
			model.Clear();
			LinearPath item = new LinearPath(list);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item);
			return;
		}
		if (Clear)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		}
		LinearPath item2 = new LinearPath(list);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(item2);
		clsItem.timOpenAfter.Enabled = true;
	}

	public void OpenCf2File(string FileName, bool Clear, ref Design model)
	{
		buFile5.Cf2 cf = new buFile5.Cf2();
		List<Cf2FileProperties> list = new List<Cf2FileProperties>();
		if (clsVar.Cf2Properties.Count <= 0)
		{
			Cf2FileProperties.Copy(list, ref cf.FileDefinations);
		}
		else
		{
			Cf2FileProperties.Copy(clsVar.Cf2Properties, ref cf.FileDefinations);
		}
		cf.MinEntityLength = clsVar.varFile.MinAllowedEntityLength;
		List<eEntities> Entities = new List<eEntities>();
		List<eEntities> Bridges = new List<eEntities>();
		List<Entity> refEntities = new List<Entity>();
		List<Entity> list2 = new List<Entity>();
		cf.ReadCf2(FileName, ref Entities, ref Bridges);
		List<LayerBase5> list3 = new List<LayerBase5>();
		LayerBase5 item = new LayerBase5("Layer1");
		list3.Add(item);
		string sceneName = "";
		if (ccVars.Pages.Count > 0)
		{
			sceneName = ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName;
		}
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			Entity eyeEntity = null;
			buConversion5.buEntityToEyeEntity(Entities[i], SetCurrentData: true, i, ref eyeEntity, list3, sceneName);
			if (eyeEntity == null)
			{
				continue;
			}
			if (model == null)
			{
				for (int j = 0; j <= cf.FoundLayers.Count - 1; j++)
				{
					if ((Entities[i].Diemaker.Pt == cf.FoundLayers[j].Diemaker.Pt) & (Entities[i].Diemaker.DiemakerType == cf.FoundLayers[j].Diemaker.Type))
					{
						eyeEntity.LayerName = cf.FoundLayers[j].Name;
						j = 2147483646;
					}
				}
			}
			eyeEntity.LineTypeMethod = colorMethodType.byEntity;
			eyeEntity.LineWeightMethod = colorMethodType.byEntity;
			eyeEntity.ColorMethod = colorMethodType.byEntity;
			refEntities.Add(eyeEntity);
		}
		for (int k = 0; k <= Bridges.Count - 1; k++)
		{
			Entity eyeEntity2 = null;
			buConversion5.buEntityToEyeEntity(Bridges[k], SetCurrentData: true, k, ref eyeEntity2, list3, sceneName);
			if (eyeEntity2 == null)
			{
				continue;
			}
			if (model == null)
			{
				for (int l = 0; l <= cf.FoundLayers.Count - 1; l++)
				{
					if ((Bridges[k].Diemaker.Pt == cf.FoundLayers[l].Diemaker.Pt) & (Bridges[k].Diemaker.DiemakerType == cf.FoundLayers[l].Diemaker.Type))
					{
						eyeEntity2.LayerName = cf.FoundLayers[l].Name;
						l = 2147483646;
					}
				}
			}
			eyeEntity2.LineTypeMethod = colorMethodType.byEntity;
			eyeEntity2.LineWeightMethod = colorMethodType.byEntity;
			eyeEntity2.ColorMethod = colorMethodType.byEntity;
			eyeEntity2.LineWeight += 1f;
			list2.Add(eyeEntity2);
		}
		if (model != null)
		{
			model.Entities.Clear();
			model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list3);
			for (int m = 0; m <= refEntities.Count - 1; m++)
			{
				model.Entities.Add(refEntities[m]);
			}
			for (int n = 0; n <= list2.Count - 1; n++)
			{
				((CustomData)list2[n].EntityData).CamSelectable = false;
				model.Entities.Add(list2[n]);
			}
		}
		else
		{
			if (Clear)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			}
			if (cf.FoundLayers.Count > 0)
			{
				ccVars.Pages[ccVars.PageIndex].Layers.Clear();
				for (int num = 0; num <= cf.FoundLayers.Count - 1; num++)
				{
					LayerBase5 item2 = new LayerBase5(cf.FoundLayers[num]);
					ccVars.Pages[ccVars.PageIndex].Layers.Add(item2);
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(ccVars.Pages[ccVars.PageIndex].Layers);
			clsInit.cVector5.ConnnectEntitiesGap(ref refEntities, 0.05);
			for (int num2 = 0; num2 <= refEntities.Count - 1; num2++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(refEntities[num2]);
			}
			for (int num3 = 0; num3 <= list2.Count - 1; num3++)
			{
				((CustomData)list2[num3].EntityData).CamSelectable = false;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(list2[num3]);
			}
			clsItem.timOpenAfter.Enabled = true;
		}
		if (ccVars.Pages.Count > 0)
		{
			clsInit.appCommand.OsnapCalculationByThread();
			Point3D MinPoint = new Point3D();
			Point3D MidPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities != null)
			{
				clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
				ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize = new Point3D(Math.Round(MaxPoint.X - MinPoint.X, 5), Math.Round(MaxPoint.Y - MinPoint.Y, 5), Math.Round(MaxPoint.Z - MinPoint.Z, 5));
			}
			if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
			{
				clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
			}
		}
	}

	public void OpenGCodeFile(string FileName, bool Clear, ref Design model)
	{
		new buCadFileOpenOptions();
		new buCadCamFileInfo();
		new List<eEntities>();
		List<Entity> list = new List<Entity>();
		buFile.GCodeRead gCodeRead = new buFile.GCodeRead();
		List<GCodePoint> GCodeList = new List<GCodePoint>();
		gCodeRead.DecodeAxes.A = false;
		gCodeRead.DecodeAxes.B = false;
		gCodeRead.DecodeAxes.C = false;
		gCodeRead.OpenGCode(FileName, ref GCodeList);
		if (!((GCodeList.Count > 0) & ((gCodeRead.EntitiesG1.Count > 0) | (gCodeRead.EntitiesG0.Count > 0) | (gCodeRead.EntitiesPlunge.Count > 0) | (gCodeRead.EntitiesLeave.Count > 0))))
		{
			return;
		}
		List<LayerBase5> list2 = new List<LayerBase5>();
		LayerBase5 layerBase = new LayerBase5("EntitiesG1");
		layerBase.LayerColor = Color.Black;
		list2.Add(layerBase);
		layerBase = new LayerBase5("EntitiesG0");
		layerBase.LayerColor = Color.Red;
		list2.Add(layerBase);
		layerBase = new LayerBase5("EntitiesPlunge");
		layerBase.LayerColor = Color.Green;
		list2.Add(layerBase);
		layerBase = new LayerBase5("EntitiesLeave");
		layerBase.LayerColor = Color.Blue;
		list2.Add(layerBase);
		if (model != null)
		{
			model.Clear();
			model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list2);
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesG1, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int i = 0; i <= list.Count - 1; i++)
			{
				list[i].LayerName = "EntitiesG1";
				model.Entities.Add(list[i]);
			}
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesG0, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int j = 0; j <= list.Count - 1; j++)
			{
				list[j].LayerName = "EntitiesG0";
				model.Entities.Add(list[j]);
			}
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesLeave, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int k = 0; k <= list.Count - 1; k++)
			{
				list[k].LayerName = "EntitiesLeave";
				model.Entities.Add(list[k]);
			}
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesPlunge, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int l = 0; l <= list.Count - 1; l++)
			{
				list[l].LayerName = "EntitiesPlunge";
				model.Entities.Add(list[l]);
			}
		}
		else
		{
			if (Clear)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list2);
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesG1, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int m = 0; m <= list.Count - 1; m++)
			{
				list[m].LayerName = "EntitiesG1";
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(list[m]);
			}
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesG0, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int n = 0; n <= list.Count - 1; n++)
			{
				list[n].LayerName = "EntitiesG0";
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(list[n]);
			}
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesLeave, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int num = 0; num <= list.Count - 1; num++)
			{
				list[num].LayerName = "EntitiesLeave";
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(list[num]);
			}
			list = new List<Entity>();
			buConversion5.buEntityToEyeEntity(gCodeRead.EntitiesPlunge, SetCurrentData: true, ref list, list2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
			for (int num2 = 0; num2 <= list.Count - 1; num2++)
			{
				list[num2].LayerName = "EntitiesPlunge";
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(list[num2]);
			}
		}
		CommonOperationAfterFileLoading();
		clsItem.timOpenAfter.Enabled = true;
	}

	public void OpenHpglFile(string FileName, bool Clear, ref Design model)
	{
		new buCadFileOpenOptions();
		new buCadCamFileInfo();
		new List<eEntities>();
		new List<LayerBase5>();
		List<Entity> Entities = new List<Entity>();
		buFile5.HPGLFile hPGLFile = new buFile5.HPGLFile();
		hPGLFile.ReadHPGL(FileName, ref Entities);
		List<LayerBase5> list = new List<LayerBase5>();
		LayerBase5 layerBase = new LayerBase5("Layer1");
		layerBase.LayerColor = Color.DimGray;
		list.Add(layerBase);
		if (model != null)
		{
			model.Clear();
			model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list);
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				model.Entities.Add(Entities[i]);
			}
			return;
		}
		if (Clear)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(list);
		for (int j = 0; j <= Entities.Count - 1; j++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(Entities[j]);
		}
		clsItem.timOpenAfter.Enabled = true;
		clsInit.appCommand.OsnapCalculationByThread();
	}

	public void OpenRulFile(string FileName)
	{
		buFile.Rul rul = new buFile.Rul();
		rul.ReadRulFile(FileName, ref clsInit.appCutter.Properties);
	}

	public void OpenLibraryFile(string FileName, ref List<buEntity> Entities, ref setLibrary Settings)
	{
		ArrayList StringList = new ArrayList();
		List<string> CalcList = new List<string>();
		List<List<string>> CalcList2 = new List<List<string>>();
		buFile5.OpenFromFile(FileName, ref StringList);
		buString5.ListToSpecificList("<LibraryEntities>", "</LibraryEntities>", AddStartEndKey: true, StringList, ref CalcList);
		Entities.Clear();
		Entities = new List<buEntity>();
		buStatics.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, CalcList, ref CalcList2);
		for (int i = 0; i <= CalcList2.Count - 1; i++)
		{
			buEntity buEntity2 = buEntity.Decode(CalcList2[i]);
			if (buEntity2 != null)
			{
				Entities.Add(buEntity2);
			}
		}
	}

	public void SaveLibraryFile(string FileName, List<buEntity> Entities, setLibrary Settings)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (fileInfo.Extension.ToLower() == ".bulib5")
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add("<LibraryEntities>");
			arrayList.AddRange(buEntity.ToDefEntity(Entities, 2));
			arrayList.Add("</LibraryEntities>");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Library Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.AddRange(Settings.ToDefAll("", 2, SerilizationMode.MultiLine));
			buFile5.SaveToFile(arrayList, FileName);
		}
	}

	public void CommonOperationAfterFileLoading()
	{
		clsInit.appCommand.PagesUpdate(FillPages: true, "");
		clsInit.appCommand.LayerConvertFromEyeLayerToBuLayer(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, ref ccVars.Pages[ccVars.PageIndex].Layers);
		clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: true, 0);
		ccVars.Pages[ccVars.PageIndex].LayerName = ccVars.Pages[ccVars.PageIndex].Layers[0].Name;
		clsInit.appCommand.cmdViewTop(ZoomFit: true, AtPlane: false);
		clsInit.appCommand.DrawingPropertiesUpdate();
		clsInit.appCommand.SetEntityCountForScene(ccVars.PageIndex);
		if (clsVar.appModes_0.CutterMode.Enable)
		{
			clsInit.appCutter.doOperationAfterFileLoad();
		}
	}

	public void FunctionAfterOpenTick()
	{
		if (clsVar.varFile.AnalyseEntitiesAfterImport)
		{
			clsInit.appCommand.AnalyseEntities();
		}
	}

	public void ModelOpenFileCommon_WorkCancelled(object sender, EventArgs e)
	{
	}

	public void ModelOpenFileCommon_WorkCompleted(object sender, WorkCompletedEventArgs e)
	{
		try
		{
			if (!(e.WorkUnit is ReadFileAsync))
			{
				if (!(e.WorkUnit is Regeneration))
				{
				}
				return;
			}
			ReadFileAsync readFileAsync = (ReadFileAsync)e.WorkUnit;
			RegenOptions ro = new RegenOptions();
			if (e.WorkUnit is ReadFile readFile)
			{
				_ = readFile.Camera != null;
			}
			readFileAsync.OpenTo(modelCommon, ro);
			List<List<Entity>> list = new List<List<Entity>>();
			if (clsVar.varFile.ExplodeBlockReferanceWhenOpenFile)
			{
				for (int i = 0; i <= 10; i++)
				{
					List<int> list2 = new List<int>();
					list = new List<List<Entity>>();
					for (int j = 0; j <= modelCommon.Entities.Count - 1; j++)
					{
						if (!(modelCommon.Entities[j] is BlockReference))
						{
							continue;
						}
						Entity[] array = ((BlockReference)modelCommon.Entities[j]).Explode(modelCommon.Blocks);
						if (array != null && array.Length != 0)
						{
							List<Entity> list3 = new List<Entity>();
							for (int k = 0; k <= array.Length - 1; k++)
							{
								if (!(array[k] is LinearPathEx))
								{
									if (!(array[k].GetType() == typeof(devDept.Eyeshot.Entities.Point)))
									{
										if (!(array[k].GetType() == typeof(Text)))
										{
											list3.Add(array[k]);
										}
										else if (!clsVar.varFile.DontAddTextFromDxfFile)
										{
											list3.Add(array[k]);
										}
									}
									else if (!clsVar.varFile.DontAddPointFromDxfFile)
									{
										list3.Add(array[k]);
									}
								}
								else
								{
									LinearPath linearPath = new LinearPath(array[k].Vertices);
									linearPath.LayerName = array[k].LayerName;
									linearPath.Color = array[k].Color;
									list3.Add(linearPath);
								}
							}
							list.Add(list3);
						}
						list2.Add(j);
					}
					if (list2.Count <= 0)
					{
						i = 11;
					}
					else
					{
						list2.Sort();
						list2.Reverse();
						for (int l = 0; l <= list2.Count - 1; l++)
						{
							modelCommon.Entities.RemoveAt(list2[l]);
						}
					}
					for (int m = 0; m <= list.Count - 1; m++)
					{
						for (int n = 0; n <= list[m].Count - 1; n++)
						{
							modelCommon.Entities.Add((Entity)list[m][n].Clone());
						}
					}
				}
			}
			if (clsVar.varFile.RemoveBlockWhileImport)
			{
				for (int num = modelCommon.Blocks.Count - 1; num >= 1; num--)
				{
					modelCommon.Blocks.RemoveAt(num);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void ModelOpenFileCommon_WorkFailed(object sender, WorkFailedEventArgs e)
	{
	}

	static clsFiles()
	{
		sClass = "buCadCamRes.clsFiles";
		modelCommon = null;
	}
}
