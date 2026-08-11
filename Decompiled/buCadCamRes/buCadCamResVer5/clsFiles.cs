// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.clsFiles
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

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
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buMW;
using buMW.CamForms;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5;

public class clsFiles
{
  public static string sClass = "buCadCamRes.clsFiles";
  public static Design modelCommon = (Design) null;

  public clsFiles()
  {
    if (!clsSystem.smethod_0(nameof (clsFiles)))
      throw new RegisterException(nameof (clsFiles));
  }

  public static void OpenRuntimeAndConfig(bool UsePathFromUserInfo, bool MW)
  {
    string method = "OpenRunAndCfg";
    buLogVer5.addToList(clsFiles.sClass, method, "RunCfg", "Started");
    if (!new DirectoryInfo(AppPath.Base).Exists)
      AppPath.Base = Application.StartupPath;
    buLogVer5.addToList(clsFiles.sClass, method, "Command Init", "Mode 0010");
    clsCommand.Init();
    AppPath.Settings = AppPath.Base + "\\Settings";
    if (!new DirectoryInfo("D:\\Icons\\AppGif").Exists)
      AppPath.Gif = AppPath.Base + "\\Gif";
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
    if (clsVar.appModes_0.DeveloperPCMode & UsePathFromUserInfo)
    {
      AppPath.User = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}";
      AppPath.Image = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}";
      AppPath.Settings = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}\\Settings";
      AppPath.DefaultParameter = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}\\Default";
      AppPath.MachineSimConfig = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}\\MachineData";
      AppPath.Kinematic = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}\\Kinematic";
      AppSecurity.PasswordLevel = 10;
    }
    if (clsVar.appModes_0.DeveloperPCMode)
    {
      AppPath.Help = "D:\\PCProjects\\Generation5\\CommonFolder\\Help";
      AppPath.HelpImages = "D:\\PCProjects\\Generation5\\CommonFolder\\Help\\Images";
    }
    AppPath.Texture = AppPath.Base + "\\Textures";
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "BasePath", AppPath.Base);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "SettingPath", AppPath.Settings);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "LanguagePath", AppPath.Language);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "ImagePath", AppPath.Image);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "JobPath", AppPath.Job);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "BackupPath", AppPath.Backup);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "KinematicPath", AppPath.Kinematic);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "PostProcessorPath", AppPath.PostProcessor);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "UserPath", AppPath.User);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "CamPath", AppPath.Cam);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MiscPath", AppPath.Misc);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MaterialsPath", AppPath.Materials);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "CounterPath", AppPath.Counter);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineSimConfigPath", AppPath.MachineSimConfig);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "DefaultParameterPath", AppPath.DefaultParameter);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "HelpPath", AppPath.Help);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "Help ImagesPath", AppPath.HelpImages);
    if (new FileInfo(AppPath.Base + "\\_offline.dll").Exists)
      AppBool.Offline = true;
    buLogVer5.addToList(clsFiles.sClass, method, "Offline", "Mode 0013", AppBool.Offline.ToString());
    if (new FileInfo(AppPath.Base + "\\_DontWritePLC.dll").Exists)
    {
      AppBool.DontWriteParameters = true;
      buLogVer5.addToList(clsFiles.sClass, method, "DontWrite", "Mode 0013_1", AppBool.Offline.ToString());
    }
    FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Runtime.prm");
    buLogVer5.addToList(clsFiles.sClass, method, "Runtime.Prm", "Mode 0014", fileInfo1.Exists.ToString());
    if (fileInfo1.Exists)
    {
      ArrayList AL = new ArrayList();
      TextReader textReader = (TextReader) System.IO.File.OpenText(fileInfo1.FullName);
      string str;
      while ((str = textReader.ReadLine()) != null)
        AL.Add((object) str);
      textReader.Close();
      try
      {
        buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) clsVar.varRuntime);
        buLogVer5.addToList(clsFiles.sClass, method, "RuntimeFile", "Decoded", fileInfo1.Exists.ToString());
        AppLanguage.SelectedLanguage = clsVar.varRuntime.Language;
      }
      catch (Exception ex)
      {
        buLogVer5.addToList(clsFiles.sClass, method, "RuntimeFile", "Exception", fileInfo1.Exists.ToString());
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Parameter Open");
      }
    }
    else
    {
      buLogVer5.addToList(clsFiles.sClass, method, "RuntimeFile", "Missing", fileInfo1.Exists.ToString());
      int num = (int) MessageBox.Show("Main Program Runtime Parameter File Missing");
    }
    FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\_psw.cspass");
    if (fileInfo2.Exists)
      clsFiles.OpenPassword(fileInfo2.FullName, 2.0);
    AppPath.Machine = $"{AppPath.Base}\\Machines\\{clsVar.varRuntime.MachineID.ToString()}";
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
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachinePath", AppPath.Machine);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineJobPath", AppPath.MachineJob);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineBackupPath", AppPath.MachineBackup);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineCounterPath", AppPath.MachineCounter);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineImagePath", AppPath.MachineImage);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineKinematicPath", AppPath.MachineKinematic);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineLanguagePath", AppPath.MachineLanguage);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachinePostProcessorPath", AppPath.MachinePostProcessor);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineSettingsPath", AppPath.MachineSettings);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineSettingsCamPath", AppPath.MachineSettingsCam);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineToolPath", AppPath.MachineTool);
    buLogVer5.addToList(clsFiles.sClass, method, "Defination", "MachineMachineDataPath", AppPath.MachineMachineData);
    if (clsVar.UserMode.ModuleWork)
      clsCommand.InitCam();
    buVector5.AskMeResult = "";
    buVector5.AskMeValue = 0.0;
    buLogVer5.addToList("clsFile", "OpenRuntime", "MachinePath", AppPath.Machine);
  }

  public static void SaveRuntime()
  {
    string FileName = AppPath.Settings + "\\Runtime.prm";
    ArrayList StringList = new ArrayList();
    StringList.AddRange((ICollection) clsVar.varRuntime.ToDefAll("", 0, SerilizationMode.MultiLine));
    buFile5.SaveToFile(StringList, FileName);
  }

  public static void OpenRuntime(string Path)
  {
    if (!new DirectoryInfo(AppPath.Base).Exists)
      AppPath.Base = Application.StartupPath;
    AppPath.Settings = AppPath.Base + "\\Settings";
    FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\Runtime.prm");
    if (fileInfo.Exists)
    {
      ArrayList AL = new ArrayList();
      TextReader textReader = (TextReader) System.IO.File.OpenText(fileInfo.FullName);
      string str;
      while ((str = textReader.ReadLine()) != null)
        AL.Add((object) str);
      textReader.Close();
      buLog.addLog("Runtime File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
      try
      {
        buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) clsVar.varRuntime);
        buLog.addLog("Runtime Parameter Decoded Good", "Ok", MethodBase.GetCurrentMethod().Name);
      }
      catch (Exception ex)
      {
        buLog.addLog("Runtime Parameter Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Parameter Open");
      }
    }
    else
    {
      buLog.addLog("Runtime File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
      int num = (int) MessageBox.Show("Main Program Runtime Parameter File Missing");
    }
    DirectoryInfo directoryInfo = new DirectoryInfo(Path);
    clsVar.appModes_0.DeveloperPCMode = false;
    if ((!directoryInfo.Exists ? (FileSystemInfo) new FileInfo(Application.StartupPath + "\\_finalusermode.dll") : (FileSystemInfo) new FileInfo(directoryInfo.FullName + "\\_finalusermode.dll")).Exists)
      clsVar.appModes_0.DeveloperPCMode = true;
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
    if (!clsVar.appModes_0.DeveloperPCMode)
      return;
    AppPath.User = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}";
    AppPath.Image = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}";
    AppPath.Settings = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}\\Settings";
    AppPath.MachineSimConfig = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}\\MachineData";
    AppPath.Kinematic = $"{AppPath.Base}\\UserData\\{clsVar.appDefination.CustomerInfo}\\{clsVar.appDefination.Mode}\\Kinematic";
  }

  public static void OpenParameter() => clsFiles.OpenParameter(AppPath.Settings);

  public static void OpenParameter(string Path, bool OnlyCommon = false, bool CamPar = true)
  {
    if (AppBool.MachineMode)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam);
      if (directoryInfo.Exists)
        Path = directoryInfo.FullName;
    }
    string fileName1 = Path + "\\Program.prm";
    string fileName2 = Path + "\\MetalSpin.prm";
    string str1 = Path + "\\CharCurrent.buprm";
    ArrayList arrayList1 = new ArrayList();
    try
    {
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\CharCurrent.buchar");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          CharLibrary5.Decode(StringList, ref ccVars.CharLibList);
          if (ccVars.CharLibList.Count == 0 | ccVars.CharLibList.Count == 1)
          {
            List<CharLibrary> Chars = new List<CharLibrary>();
            CharLibrary.Decode(StringList, ref Chars);
            ccVars.CharLibList.Clear();
            for (int index = 0; index <= Chars.Count - 1; ++index)
            {
              CharLibrary5 charLibrary5 = new CharLibrary5();
              charLibrary5.Char = Chars[index].Char;
              buEntity.Copy(charLibrary5.CharEntities, ref charLibrary5.CharEntities);
              ccVars.CharLibList.Add(charLibrary5);
            }
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Char Current Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Char Current Decoder Error");
        }
      }
      else
      {
        FileInfo fileInfo2 = new FileInfo(str1);
        if (fileInfo2.Exists)
        {
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(fileInfo2.FullName, ref StringList);
          try
          {
            CharLibrary5.Decode(StringList, ref ccVars.CharLibList);
            if (ccVars.CharLibList.Count == 0 | ccVars.CharLibList.Count == 1)
            {
              List<CharLibrary> Chars = new List<CharLibrary>();
              CharLibrary.Decode(StringList, ref Chars);
              ccVars.CharLibList.Clear();
              for (int index = 0; index <= Chars.Count - 1; ++index)
              {
                CharLibrary5 charLibrary5 = new CharLibrary5();
                charLibrary5.Char = Chars[index].Char;
                buEntity.GeoEntitiyToBuEntity(Chars[index].CharEntities, ref charLibrary5.CharEntities);
                ccVars.CharLibList.Add(charLibrary5);
              }
              StringList = new ArrayList();
              StringList.Add((object) "------------------------------------------------------------------------");
              StringList.Add((object) "   Char Settings");
              StringList.Add((object) "------------------------------------------------------------------------");
              StringList.Add((object) "<Char>");
              StringList.AddRange((ICollection) CharLibrary5.ToDef(ccVars.CharLibList, 2));
              StringList.Add((object) "</Char>");
              buFile.SaveToFile(StringList, str1);
            }
          }
          catch (Exception ex)
          {
            buLog.addLog("Char Current Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
            buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Char Current Decoder Error");
          }
        }
        else
        {
          buLog.addLog("Char Current File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buString.MessageBoxError("Char Current File Missing");
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("Char Current Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Char Current Error");
    }
    FileInfo fileInfo3 = new FileInfo(fileName1);
    if (fileInfo3.Exists)
    {
      ArrayList arrayList2 = new ArrayList();
      TextReader textReader = (TextReader) System.IO.File.OpenText(fileInfo3.FullName);
      string str2;
      while ((str2 = textReader.ReadLine()) != null)
        arrayList2.Add((object) str2);
      textReader.Close();
      buLog.addLog("Program File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
      try
      {
        List<List<string>> CalcList1 = new List<List<string>>();
        ArrayList CalcList2 = new ArrayList();
        buString.ListToSpecificList("<Materials>", "</Materials>", true, arrayList2, ref CalcList2);
        buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", true, CalcList2, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList1[index].ToArray());
          MaterialBase5 materialBase5 = new MaterialBase5();
          buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) materialBase5);
          ccVars.MaterialList.Add(materialBase5);
        }
        ArrayList CalcList3 = new ArrayList();
        buString.ListToSpecificList("<ActiveMaterial>", "</ActiveMaterial>", true, arrayList2, ref CalcList3);
        buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", true, CalcList3, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList1[index].ToArray());
          ccVars.activeMaterial = new MaterialBase5();
          buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) ccVars.activeMaterial);
        }
        List<string> CalcList4 = new List<string>();
        buString.ListToSpecificList("<ColorList>", "</ColorList>", false, arrayList2, ref CalcList4);
        for (int index = 0; index <= CalcList4.Count - 1; ++index)
        {
          if (index <= buImage5.ColorList.Count - 1)
            buImage5.ColorList[index] = Color.FromName(CalcList4[index]);
        }
        CalcList1 = new List<List<string>>();
        ArrayList CalcList5 = new ArrayList();
        buString.ListToSpecificList("<LayerOptions>", "</LayerOptions>", true, arrayList2, ref CalcList5);
        buString.ListToSpecificList("<LayerOverride>", "</LayerOverride>", true, CalcList5, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList1[index].ToArray());
          LayerOverride layerOverride = new LayerOverride();
          buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) layerOverride);
          ccVars.LayerOptions.Add(layerOverride);
        }
        CalcList1 = new List<List<string>>();
        List<List<string>> CalcList6 = new List<List<string>>();
        buString.ListToSpecificList("<ToolGroup5>", "</ToolGroup5>", true, arrayList2, ref CalcList6);
        for (int index1 = 0; index1 <= CalcList6.Count - 1; ++index1)
        {
          ToolGroup5 toolGroup5 = new ToolGroup5();
          buSerilization5.Decode(CalcList6[index1], "", SerilizationMode5.MultiLine, (object) toolGroup5);
          buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", true, CalcList6[index1], ref CalcList1);
          List<ToolBase5> toolBase5List = new List<ToolBase5>();
          for (int index2 = 0; index2 <= CalcList1.Count - 1; ++index2)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[index2].ToArray());
            ToolBase5 Tool = new ToolBase5();
            buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) Tool);
            clsInit.cVector5.ToolTotalLengthCalculate(ref Tool);
            toolGroup5.Tools.Add(Tool);
          }
          ccVars.Tools.Add(toolGroup5);
        }
        buSerilization5.Decode(arrayList2, "", SerilizationMode5.MultiLine, (object) clsVar.varInterface5);
        buLog.addLog("Interface 5 Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varProgram);
        buLog.addLog("Program Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varSelection);
        buLog.addLog("Selection Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varDisplay);
        buLog.addLog("Display Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varScreen);
        buLog.addLog("Screen Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varPreviewViewport);
        buLog.addLog("Preview Page Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varCam);
        buLog.addLog("Cam Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varFile);
        buLog.addLog("File Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varEntities);
        buLog.addLog("Entities Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varGeometry);
        buLog.addLog("Geometry Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varInterface);
        buLog.addLog("Interface Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varLayer);
        buLog.addLog("Layer Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varLibrary);
        buLog.addLog("Library Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varMainForm);
        buLog.addLog("Main Form Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varMouse);
        buLog.addLog("Mouse Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varSimulation);
        buLog.addLog("Simulation Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "Cad", SerilizationMode.MultiLine, (object) clsVar.varCadEntResolution);
        buLog.addLog("Cad Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "Cam", SerilizationMode.MultiLine, (object) clsVar.varCamCalcResolution);
        buLog.addLog("Cam Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varView);
        buLog.addLog("View Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varCommunication);
        buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization5.Decode(arrayList2, "", SerilizationMode5.MultiLine, (object) clsVar.varAutoCadFileProps);
        buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buLog.addLog("Parameter Decoded Good", "Ok", MethodBase.GetCurrentMethod().Name);
        if (clsInit.cMwCalc != null)
        {
          buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsInit.cMwCalc.Settings);
          buLog.addLog("MW Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        }
        AppPath.ToolHolder = clsVar.varInterface.pathToolHolder;
        AppPath.Tool = clsVar.varInterface.pathTool;
        CalcList1.Clear();
      }
      catch (Exception ex)
      {
        buLog.addLog("Parameter Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Parameter Open");
      }
    }
    else
    {
      buLog.addLog("Program Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Program Settings File Missing");
    }
    if (clsInit.appMW != null & CamPar)
      clsInit.appMW.OpenMWParameter();
    if (OnlyCommon)
      return;
    FileInfo fileInfo4 = new FileInfo(fileName2);
    if (fileInfo4.Exists & clsVar.appModes_0.MetalSpinningMode.Enable)
    {
      ArrayList StringList = new ArrayList();
      buFile.OpenFromFile(fileInfo4.FullName, ref StringList);
      try
      {
        ArrayList CalcList7 = new ArrayList();
        buString.ListToSpecificList("<SpinPattern>", "</SpinPattern>", true, StringList, ref CalcList7);
        if (CalcList7.Count > 0)
        {
          buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsSpinning.varMetalSpinning);
          buLog.addLog("Spinning Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        }
        else
        {
          buLog.addLog("<SpinPattern> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buString.MessageBoxError("<SpinPattern> Line Missing");
        }
        ArrayList CalcList8 = new ArrayList();
        buString.ListToSpecificList("<SpinPipePattern>", "</SpinPipePattern>", true, StringList, ref CalcList8);
        if (CalcList8.Count > 0)
        {
          buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) clsSpinning.varMetalPipeSpinning);
          buLog.addLog("Spinning Pipe Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        }
        else
        {
          buLog.addLog("<SpinPipePattern> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buString.MessageBoxError("<SpinPipePattern> Line Missing");
        }
      }
      catch (Exception ex)
      {
        buLog.addLog("Spinning Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Tufting Settings Decoder Error");
      }
    }
    else if (clsVar.appModes_0.MetalSpinningMode.Enable)
    {
      buLog.addLog("Spinning Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Spinning Settings File Missing");
    }
    if (clsVar.appModes_0.NestingMode.Enable)
      clsInit.appNesting.OpenNestingFile();
    if (clsVar.appModes_0.NestingMode.PanelMode)
      clsInit.appPanelCut.OpenPanelCutFile();
    if (clsVar.appModes_0.CutterMode.Enable)
      clsInit.appCutter.OpenCutterFile();
    if (clsVar.appModes_0.DiemakerMode.Enable)
      clsInit.appDiemaker.OpenDiemakerFile();
    if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      clsInit.appLaserRouter.OpenLaserFile();
    if (clsVar.appModes_0.PipeBendMode.Enable)
      clsInit.appPipeBending.OpenPipeBendingFile();
    if (clsVar.appModes_0.TuftingMode.Enable)
      clsInit.appTufting.OpenTuftingFile();
    if (clsVar.appModes_0.ProfileMode.Enable)
      clsInit.appProfile.OpenProfileFile();
    if (clsVar.appModes_0.MarbleMode.Enable)
      clsInit.appMarble.OpenMarbleFile();
    if (clsVar.appModes_0.RollerBendMode.Enable)
      clsInit.appRollerBend.OpenRollerBend();
    if (clsVar.appModes_0.RoboticMode.Enable)
      clsInit.appRobotic.OpenRoboticFile();
    if (clsVar.appModes_0.JewelMode.Enable)
      clsInit.appJewel.OpenJewelFile();
    if (clsVar.appModes_0.QuiltingMode.Enable)
      clsInit.appQuilting.OpenQuiltingFile();
    clsFiles.OpenMachineConfig();
  }

  public static void OpenParameterLess(string Path)
  {
    if (AppBool.MachineMode)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam);
      if (directoryInfo.Exists)
        Path = directoryInfo.FullName;
    }
    ArrayList arrayList1 = new ArrayList();
    try
    {
      FileInfo fileInfo = new FileInfo(Path + "\\CharCurrent.buprm");
      if (fileInfo.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        try
        {
          CharLibrary5.Decode(StringList, ref ccVars.CharLibList);
          if (ccVars.CharLibList.Count == 0 | ccVars.CharLibList.Count == 1)
          {
            List<CharLibrary> Chars = new List<CharLibrary>();
            CharLibrary.Decode(StringList, ref Chars);
            ccVars.CharLibList.Clear();
            for (int index = 0; index <= Chars.Count - 1; ++index)
            {
              CharLibrary5 charLibrary5 = new CharLibrary5();
              charLibrary5.Char = Chars[index].Char;
              buEntity.Copy(charLibrary5.CharEntities, ref charLibrary5.CharEntities);
              ccVars.CharLibList.Add(charLibrary5);
            }
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Char Current Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Char Current Decoder Error");
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("Char Current Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Char Current Error");
    }
    FileInfo fileInfo1 = new FileInfo(Path + "\\Program.prm");
    if (fileInfo1.Exists)
    {
      ArrayList arrayList2 = new ArrayList();
      TextReader textReader = (TextReader) System.IO.File.OpenText(fileInfo1.FullName);
      string str;
      while ((str = textReader.ReadLine()) != null)
        arrayList2.Add((object) str);
      textReader.Close();
      buLog.addLog("Program File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
      try
      {
        List<List<string>> CalcList1 = new List<List<string>>();
        ArrayList CalcList2 = new ArrayList();
        buString.ListToSpecificList("<Materials>", "</Materials>", true, arrayList2, ref CalcList2);
        buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", true, CalcList2, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList1[index].ToArray());
          MaterialBase5 materialBase5 = new MaterialBase5();
          buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) materialBase5);
          ccVars.MaterialList.Add(materialBase5);
        }
        ArrayList CalcList3 = new ArrayList();
        buString.ListToSpecificList("<ActiveMaterial>", "</ActiveMaterial>", true, arrayList2, ref CalcList3);
        buString.ListToSpecificList("<MaterialBase5>", "</MaterialBase5>", true, CalcList3, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList1[index].ToArray());
          ccVars.activeMaterial = new MaterialBase5();
          buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) ccVars.activeMaterial);
        }
        List<string> CalcList4 = new List<string>();
        buString.ListToSpecificList("<ColorList>", "</ColorList>", false, arrayList2, ref CalcList4);
        for (int index = 0; index <= CalcList4.Count - 1; ++index)
        {
          if (index <= buImage5.ColorList.Count - 1)
            buImage5.ColorList[index] = Color.FromName(CalcList4[index]);
        }
        CalcList1 = new List<List<string>>();
        ArrayList CalcList5 = new ArrayList();
        buString.ListToSpecificList("<LayerOptions>", "</LayerOptions>", true, arrayList2, ref CalcList5);
        buString.ListToSpecificList("<LayerOverride>", "</LayerOverride>", true, CalcList5, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          ArrayList AL = new ArrayList();
          AL.AddRange((ICollection) CalcList1[index].ToArray());
          LayerOverride layerOverride = new LayerOverride();
          buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) layerOverride);
          ccVars.LayerOptions.Add(layerOverride);
        }
        CalcList1 = new List<List<string>>();
        List<List<string>> CalcList6 = new List<List<string>>();
        buString.ListToSpecificList("<ToolGroup5>", "</ToolGroup5>", true, arrayList2, ref CalcList6);
        for (int index1 = 0; index1 <= CalcList6.Count - 1; ++index1)
        {
          ToolGroup5 toolGroup5 = new ToolGroup5();
          buSerilization5.Decode(CalcList6[index1], "", SerilizationMode5.MultiLine, (object) toolGroup5);
          buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", true, CalcList6[index1], ref CalcList1);
          List<ToolBase5> toolBase5List = new List<ToolBase5>();
          for (int index2 = 0; index2 <= CalcList1.Count - 1; ++index2)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[index2].ToArray());
            ToolBase5 Tool = new ToolBase5();
            buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) Tool);
            clsInit.cVector5.ToolTotalLengthCalculate(ref Tool);
            toolGroup5.Tools.Add(Tool);
          }
          ccVars.Tools.Add(toolGroup5);
        }
        buSerilization5.Decode(arrayList2, "", SerilizationMode5.MultiLine, (object) clsVar.varInterface5);
        buLog.addLog("Interface 5 Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varProgram);
        buLog.addLog("Program Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varSelection);
        buLog.addLog("Selection Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varDisplay);
        buLog.addLog("Display Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varScreen);
        buLog.addLog("Screen Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varPreviewViewport);
        buLog.addLog("Preview Page Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varCam);
        buLog.addLog("Cam Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varFile);
        buLog.addLog("File Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varEntities);
        buLog.addLog("Entities Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varGeometry);
        buLog.addLog("Geometry Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varInterface);
        buLog.addLog("Interface Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varLayer);
        buLog.addLog("Layer Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varLibrary);
        buLog.addLog("Library Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varMainForm);
        buLog.addLog("Main Form Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varMouse);
        buLog.addLog("Mouse Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varSimulation);
        buLog.addLog("Simulation Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "Cad", SerilizationMode.MultiLine, (object) clsVar.varCadEntResolution);
        buLog.addLog("Cad Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "Cam", SerilizationMode.MultiLine, (object) clsVar.varCamCalcResolution);
        buLog.addLog("Cam Entities Resolutions Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varView);
        buLog.addLog("View Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsVar.varCommunication);
        buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buSerilization5.Decode(arrayList2, "", SerilizationMode5.MultiLine, (object) clsVar.varAutoCadFileProps);
        buLog.addLog("Communication Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        buLog.addLog("Parameter Decoded Good", "Ok", MethodBase.GetCurrentMethod().Name);
        if (clsInit.cMwCalc != null)
        {
          buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, (object) clsInit.cMwCalc.Settings);
          buLog.addLog("MW Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        }
        AppPath.ToolHolder = clsVar.varInterface.pathToolHolder;
        AppPath.Tool = clsVar.varInterface.pathTool;
        CalcList1.Clear();
      }
      catch (Exception ex)
      {
        buLog.addLog("Parameter Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Parameter Open");
      }
    }
    else
    {
      buLog.addLog("Program Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Program Settings File Missing");
    }
  }

  public static void SaveParameter() => clsFiles.SaveParameter(AppPath.Settings, "");

  public static void SaveParameter(
    string Path,
    string FileNameAddStrings,
    bool OnlyCommon = false,
    bool CamPar = true)
  {
    try
    {
      if (AppBool.MachineMode)
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam);
        if (directoryInfo.Exists)
          Path = directoryInfo.FullName;
      }
      ArrayList arrayList = new ArrayList();
      string str = Path + "\\Program.prm";
      if (FileNameAddStrings.Length > 0)
        str = $"{Path}\\Program{FileNameAddStrings}.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Interface Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varInterface.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Interface 5 Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varInterface5.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Materials ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <Materials>");
      for (int index = 0; index <= ccVars.MaterialList.Count - 1; ++index)
        StringList1.AddRange((ICollection) ccVars.MaterialList[index].ToDefAll("", 4, SerilizationMode5.MultiLine));
      StringList1.Add((object) "  </Materials>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Layer Options ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <LayerOptions>");
      for (int index = 0; index <= ccVars.LayerOptions.Count - 1; ++index)
        StringList1.AddRange((ICollection) ccVars.LayerOptions[index].ToDefAll("", 4, SerilizationMode5.MultiLine));
      StringList1.Add((object) "  </LayerOptions>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   ColorList ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <ColorList>");
      for (int index = 0; index <= buImage5.ColorList.Count - 1; ++index)
        StringList1.Add((object) buImage5.ColorList[index].ToKnownColor());
      StringList1.Add((object) "  </ColorList>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Active Material ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <ActiveMaterial>");
      StringList1.AddRange((ICollection) ccVars.activeMaterial.ToDefAll("", 4, SerilizationMode5.MultiLine));
      StringList1.Add((object) "  </ActiveMaterial>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Tools ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <Tools>");
      for (int index1 = 0; index1 <= ccVars.Tools.Count - 1; ++index1)
      {
        StringList1.Add((object) "    <ToolGroup5>");
        ArrayList c = new ArrayList();
        c.AddRange((ICollection) ccVars.Tools[index1].ToDefAll("", 6, SerilizationMode5.MultiLine));
        c.RemoveAt(0);
        c.RemoveAt(c.Count - 1);
        StringList1.AddRange((ICollection) c);
        for (int index2 = 0; index2 <= ccVars.Tools[index1].Tools.Count - 1; ++index2)
          StringList1.AddRange((ICollection) ccVars.Tools[index1].Tools[index2].ToDefAll("", 6, SerilizationMode5.MultiLine));
        StringList1.Add((object) "    </ToolGroup5>");
      }
      StringList1.Add((object) "  </Tools>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Form Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varMainForm.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Program Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varProgram.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Program Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varSelection.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Cam Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varCam.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Display Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varDisplay.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Screen Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varScreen.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Preview PAge Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varPreviewViewport.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   File Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varFile.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Entities Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varEntities.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   View Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varView.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Geometry Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varGeometry.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Layer Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varLayer.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Library Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varLibrary.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Mouse Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varMouse.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Simulation Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varSimulation.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Entities Resolutions");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varCadEntResolution.ToDefAll("Cad", 2, SerilizationMode.MultiLine));
      StringList1.AddRange((ICollection) clsVar.varCamCalcResolution.ToDefAll("Cam", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Communication Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varCommunication.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   AutoCadFileProps Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varAutoCadFileProps.ToDefAll("", 2, SerilizationMode5.MultiLine));
      if (clsInit.cMwCalc != null)
      {
        StringList1.Add((object) "------------------------------------------------------------------------");
        StringList1.Add((object) "   MW Settings");
        StringList1.Add((object) "------------------------------------------------------------------------");
        StringList1.AddRange((ICollection) clsInit.cMwCalc.Settings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      }
      buFile.SaveToFile(StringList1, str);
      if (clsInit.appMW != null & CamPar)
        clsInit.appMW.SaveMWParameter();
      string path = buFile.GetPath(str);
      buFile.getFileNameWithoutExtension(str);
      string FileName1 = path + "\\CharCurrent.buprm";
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "   Char Settings");
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "<Char>");
      StringList2.AddRange((ICollection) CharLibrary5.ToDef(ccVars.CharLibList, 2));
      StringList2.Add((object) "</Char>");
      buFile.SaveToFile(StringList2, FileName1);
      buLog.addLog("Char Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      if (!OnlyCommon)
      {
        if (clsVar.appModes_0.MetalSpinningMode.Enable)
        {
          string FileName2 = Path + "\\MetalSpin.prm";
          StringList2 = new ArrayList();
          StringList2.AddRange((ICollection) clsSpinning.varMetalSpinning.ToDefAll("", 2, SerilizationMode.MultiLine));
          StringList2.AddRange((ICollection) clsSpinning.varMetalPipeSpinning.ToDefAll("", 2, SerilizationMode.MultiLine));
          buFile.SaveToFile(StringList2, FileName2);
          buLog.addLog("Spining Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
        }
        if (clsVar.appModes_0.DiemakerMode.Enable)
          clsInit.appDiemaker.SaveDiemakerFile();
        if (clsVar.appModes_0.NestingMode.Enable)
          clsInit.appNesting.SaveNestingFile();
        if (clsVar.appModes_0.NestingMode.PanelMode)
          clsInit.appPanelCut.SavePanelCutFile();
        if (clsVar.appModes_0.CutterMode.Enable)
          clsInit.appCutter.SaveCutterFile();
        if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
          clsInit.appLaserRouter.SaveLaserFile();
        if (clsVar.appModes_0.PipeBendMode.Enable)
          clsInit.appPipeBending.SavePipeBendingFile();
        if (clsVar.appModes_0.RoboticMode.Enable)
          clsInit.appRobotic.SaveRoboticFile();
        if (clsVar.appModes_0.TuftingMode.Enable)
          clsInit.appTufting.SaveTuftingFile();
        if (clsVar.appModes_0.JewelMode.Enable)
          clsInit.appJewel.SaveJewelFile();
        if (clsVar.appModes_0.QuiltingMode.Enable && clsInit.appQuilting != null)
          clsInit.appQuilting.SaveQuiltingFile();
        clsFiles.SaveMachineConfig();
      }
      StringList2.Clear();
      GC.Collect();
      buLog.addLog("Program File Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("Program File Not Saved", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
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
          Path = directoryInfo.FullName;
      }
      ArrayList arrayList = new ArrayList();
      string FileName1 = Path + "\\Program.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Interface Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varInterface.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Interface 5 Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varInterface5.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Materials ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <Materials>");
      for (int index = 0; index <= ccVars.MaterialList.Count - 1; ++index)
        StringList1.AddRange((ICollection) ccVars.MaterialList[index].ToDefAll("", 4, SerilizationMode5.MultiLine));
      StringList1.Add((object) "  </Materials>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Layer Options ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <LayerOptions>");
      for (int index = 0; index <= ccVars.LayerOptions.Count - 1; ++index)
        StringList1.AddRange((ICollection) ccVars.LayerOptions[index].ToDefAll("", 4, SerilizationMode5.MultiLine));
      StringList1.Add((object) "  </LayerOptions>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Active Material ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <ActiveMaterial>");
      StringList1.AddRange((ICollection) ccVars.activeMaterial.ToDefAll("", 4, SerilizationMode5.MultiLine));
      StringList1.Add((object) "  </ActiveMaterial>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Tools ");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "  <Tools>");
      for (int index1 = 0; index1 <= ccVars.Tools.Count - 1; ++index1)
      {
        StringList1.Add((object) "    <ToolGroup5>");
        ArrayList c = new ArrayList();
        c.AddRange((ICollection) ccVars.Tools[index1].ToDefAll("", 6, SerilizationMode5.MultiLine));
        c.RemoveAt(0);
        c.RemoveAt(c.Count - 1);
        StringList1.AddRange((ICollection) c);
        for (int index2 = 0; index2 <= ccVars.Tools[index1].Tools.Count - 1; ++index2)
          StringList1.AddRange((ICollection) ccVars.Tools[index1].Tools[index2].ToDefAll("", 6, SerilizationMode5.MultiLine));
        StringList1.Add((object) "    </ToolGroup5>");
      }
      StringList1.Add((object) "  </Tools>");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Form Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varMainForm.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Program Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varProgram.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Program Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varSelection.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Cam Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varCam.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Display Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varDisplay.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Screen Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varScreen.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Preview PAge Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varPreviewViewport.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   File Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varFile.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Entities Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varEntities.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   View Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varView.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Geometry Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varGeometry.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Layer Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varLayer.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Library Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varLibrary.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Mouse Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varMouse.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Simulation Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varSimulation.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Entities Resolutions");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varCadEntResolution.ToDefAll("Cad", 2, SerilizationMode.MultiLine));
      StringList1.AddRange((ICollection) clsVar.varCamCalcResolution.ToDefAll("Cam", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Communication Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varCommunication.ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   AutoCadFileProps Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.AddRange((ICollection) clsVar.varAutoCadFileProps.ToDefAll("", 2, SerilizationMode5.MultiLine));
      buFile.SaveToFile(StringList1, FileName1);
      string FileName2 = Path + "\\CharCurrent.buprm";
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "   Char Settings");
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "<Char>");
      StringList2.AddRange((ICollection) CharLibrary5.ToDef(ccVars.CharLibList, 2));
      StringList2.Add((object) "</Char>");
      buFile.SaveToFile(StringList2, FileName2);
      buLog.addLog("Char Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      StringList2.Clear();
      buLog.addLog("Program File Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("Program File Not Saved", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void SaveMachineConfig()
  {
    clsFiles.SaveMachineConfig(AppPath.Settings + "\\MachineConfig.prm");
  }

  public static void SaveMachineConfig(string FileName)
  {
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "<Version>");
    StringList.Add((object) $"  {Application.ProductVersion} - R{clsVar.varRuntime.ReleaseVer}");
    StringList.Add((object) "</Version>");
    StringList.AddRange((ICollection) MachineGCodeConfigrasyon.ToDef(clsVar.varMachineGCodeConfig, 0));
    buFile.SaveToFile(StringList, FileName);
    StringList.Clear();
  }

  public static void OpenMachineConfig()
  {
    clsFiles.OpenMachineConfig(AppPath.Settings + "\\MachineConfig.prm");
    string method = nameof (OpenMachineConfig);
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
      buLogVer5.addToList(
        clsFiles.sClass,
        method,
        "FiveAxisSafety",
        "Loaded",
        buCadCamResVer5.Marble.FiveAxisPathSafety.ConfigurationRevision.ToString());
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
    if (!new FileInfo(FileName).Exists)
      return;
    List<string> StringList = new List<string>();
    buFile5.OpenFromFile(FileName, ref StringList);
    MachineGCodeConfigrasyon.Decode(StringList, ref clsVar.varMachineGCodeConfig);
    StringList.Clear();
  }

  public static void OpenLanguageFiles(int LangSelect)
  {
    try
    {
      AppLanguage.Clear();
      FileInfo fileInfo1;
      FileInfo fileInfo2;
      FileInfo fileInfo3;
      FileInfo fileInfo4;
      FileInfo fileInfo5;
      FileInfo fileInfo6;
      if (!clsVar.UserMode.DeveloperPCMode)
      {
        fileInfo1 = new FileInfo(AppPath.Language + "\\buCadCam.lng");
        fileInfo2 = new FileInfo(AppPath.Language + "\\buClasses.lng");
        fileInfo3 = new FileInfo(AppPath.Language + "\\buEnum.lng");
        FileInfo fileInfo7 = new FileInfo(AppPath.Language + "\\buMarble.lng");
        FileInfo fileInfo8 = new FileInfo(AppPath.Language + "\\buTufting.lng");
        FileInfo fileInfo9 = new FileInfo(AppPath.Language + "\\buProfile.lng");
        fileInfo4 = new FileInfo(AppPath.Language + "\\buForms.lng");
        fileInfo5 = new FileInfo(AppPath.Language + "\\buNesting.lng");
        FileInfo fileInfo10 = new FileInfo(AppPath.Language + "\\buGrinding.lng");
        FileInfo fileInfo11 = new FileInfo(AppPath.Language + "\\buQuilting.lng");
        fileInfo6 = new FileInfo(AppPath.Language + "\\buMotion.lng");
      }
      else
      {
        fileInfo1 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buCadCam.lng");
        fileInfo2 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buClasses.lng");
        fileInfo3 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buEnum.lng");
        FileInfo fileInfo12 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buTufting.lng");
        FileInfo fileInfo13 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buMarble.lng");
        FileInfo fileInfo14 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buProfile.lng");
        fileInfo4 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buForms.lng");
        fileInfo5 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buNesting.lng");
        FileInfo fileInfo15 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buGrinding.lng");
        FileInfo fileInfo16 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buQuilting.lng");
        fileInfo6 = new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buMotion.lng");
      }
      if (fileInfo1.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
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
      else
      {
        buLogVer5.addToLog("clsFile", "buCadCam.lng", "Cad/Cam Language Loaded", "Ok", -1.0, 0.0);
        buString.MessageBoxError("Language CadCam File Missing");
      }
      if (fileInfo2.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo2.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<FirstEntryType>", "</FirstEntryType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.FirstEntryType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LastExitType>", "</LastExitType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.LastExitType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MoveHandlingAction>", "</MoveHandlingAction>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.MoveHandlingAction);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadInUsage>", "</LeadInUsage>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.LeadInUsage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadOutUsage>", "</LeadOutUsage>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.LeadOutUsage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadInOutUsage>", "</LeadInOutUsage>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.LeadInOutUsage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadParamsType>", "</LeadParamsType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.LeadParamsType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadParamsAxisOrientation>", "</LeadParamsAxisOrientation>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.LeadParamsAxisOrientation);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<LeadExtensionParamsType>", "</LeadExtensionParamsType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.LeadExtensionParamsType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<SharpCorners>", "</SharpCorners>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.SharpCorners);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Offset2dContainmentMethod>", "</Offset2dContainmentMethod>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.Offset2dContainmentMethod);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MultiCutsRoughParamsSortType>", "</MultiCutsRoughParamsSortType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.MultiCutsRoughParamsSortType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsToolPlaneDirTypeFor3Axis>", "</MachiningParamsToolPlaneDirTypeFor3Axis>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsToolPlaneDirTypeFor3Axis);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsMachiningAreaMode>", "</MachiningParamsMachiningAreaMode>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsMachiningAreaMode);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsMachType>", "</MachiningParamsMachType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsMachType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CamOpenContourType>", "</CamOpenContourType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.CamOpenContourType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CamClosedContourType>", "</CamClosedContourType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.CamClosedContourType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<ClockDirectionType>", "</ClockDirectionType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.ClockDirectionType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<WireframeBasedTpCalcParamsRoughType>", "</WireframeBasedTpCalcParamsRoughType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.WireframeBasedTpCalcParamsRoughType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsDirection>", "</MachiningParamsDirection>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsDirection);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<UseRamp>", "</UseRamp>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.UseRamp);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsRampType>", "</TriangleMeshBasedTpCalcParamsRampType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsRampType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsContourPassType>", "</TriangleMeshBasedTpCalcParamsContourPassType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsContourPassType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsFilteringMode>", "</TriangleMeshBasedTpCalcParamsFilteringMode>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsFilteringType>", "</TriangleMeshBasedTpCalcParamsFilteringType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsCornerPegs>", "</TriangleMeshBasedTpCalcParamsCornerPegs>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockOffsetMode>", "</CollCtrlOpStockParamsStockOffsetMode>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockOffsetMode);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockType>", "</CollCtrlOpStockParamsStockType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockAreaLimitOffsetMethod>", "</CollCtrlOpStockParamsStockAreaLimitOffsetMethod>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockAreaLimitOffsetMethod);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CollCtrlOpStockParamsStockDirection>", "</CollCtrlOpStockParamsStockDirection>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.CollCtrlOpStockParamsStockDirection);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MachiningParamsStockRemainType>", "</MachiningParamsStockRemainType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.MachiningParamsStockRemainType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsRoughType>", "</TriangleMeshBasedTpCalcParamsRoughType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsRoughType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<WireframeBasedTpCalcParamsFixtureCurveMode>", "</WireframeBasedTpCalcParamsFixtureCurveMode>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.WireframeBasedTpCalcParamsFixtureCurveMode);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CutterRadiusCompParamsCompensationType>", "</CutterRadiusCompParamsCompensationType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.CutterRadiusCompParamsCompensationType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType>", "</TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsParallelCutsStartCorner>", "</TriangleMeshBasedTpCalcParamsParallelCutsStartCorner>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsParallelCutsStartCorner);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<TriangleMeshBasedTpCalcParamsToolpathOutputType>", "</TriangleMeshBasedTpCalcParamsToolpathOutputType>", StringList), clsVar.varRuntime.Language, ref buMWCaptions.TriangleMeshBasedTpCalcParamsToolpathOutputType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<SortingNextGroupFindRulesType>", "</SortingNextGroupFindRulesType>", StringList), clsVar.varRuntime.Language, ref buClassLanguage.SortingNextGroupFindRulesType);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<SortingIntersectionRulesType>", "</SortingIntersectionRulesType>", StringList), clsVar.varRuntime.Language, ref buClassLanguage.SortingIntersectionRulesType);
        StringList.Clear();
        buLogVer5.addToLog("clsFile", "buClass.lng", "buClass Language Loaded", "Ok", -1.0, 0.0);
      }
      else
      {
        buLogVer5.addToLog("clsFile", "buClass.lng", "buClass Language Loaded", "Ok", -1.0, 0.0);
        buString.MessageBoxError("Language Class File Missing");
      }
      if (fileInfo3.Exists)
      {
        List<string> stringList = new List<string>();
        buFile.OpenFromFile(fileInfo3.FullName, ref AppLanguage.EnumBase);
        buLogVer5.addToLog("clsFile", "buEnum.lng", "Enum Language Loaded", "Ok", -1.0, 0.0);
      }
      else
      {
        buLogVer5.addToLog("clsFile", "buEnum.lng", "Enum Language Missing", "NotOk", -1.0, 0.0);
        buString.MessageBoxError("Enum Language File Missing");
      }
      if (clsVar.appModes_0.Motion)
      {
        if (fileInfo6.Exists)
        {
          List<string> StringList = new List<string>();
          buFile.OpenFromFile(fileInfo6.FullName, ref StringList);
          buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemMessages);
          buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemStatus);
          buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Error>", "</Error>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemError);
          buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Warning>", "</Warning>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemWarning);
          buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Dynamic>", "</Dynamic>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemDynamic);
          buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisError>", "</AxisError>", StringList), clsVar.varRuntime.Language, ref AppLanguage.AxesError);
          buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisWarning>", "</AxisWarning>", StringList), clsVar.varRuntime.Language, ref AppLanguage.AxesWarning);
          StringList.Clear();
          buLogVer5.addToLog("clsFile", "buMotion.lng", "buMotion Language Loaded", "Ok", -1.0, 0.0);
        }
        else
        {
          buLogVer5.addToLog("clsFile", "buMotion.lng", "buMotion Language Loaded", "Ok", -1.0, 0.0);
          buString.MessageBoxError("Language buMotion File Missing");
        }
      }
      else if (fileInfo6.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo6.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemMessages);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Error>", "</Error>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemError);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Warning>", "</Warning>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemWarning);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Dynamic>", "</Dynamic>", StringList), clsVar.varRuntime.Language, ref AppLanguage.SystemDynamic);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisError>", "</AxisError>", StringList), clsVar.varRuntime.Language, ref AppLanguage.AxesError);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<AxisWarning>", "</AxisWarning>", StringList), clsVar.varRuntime.Language, ref AppLanguage.AxesWarning);
        StringList.Clear();
        buLogVer5.addToLog("clsFile", "buMotion.lng", "buMotion Language Loaded", "Ok", -1.0, 0.0);
      }
      if (fileInfo4.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo4.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AskLicense>", "</F_AskLicense>", StringList), clsVar.varRuntime.Language, ref F_AskLicense.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Report>", "</F_Report>", StringList), clsVar.varRuntime.Language, ref F_Report.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Layer>", "</F_Layer>", StringList), clsVar.varRuntime.Language, ref F_Layer.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Preview>", "</F_Preview>", StringList), clsVar.varRuntime.Language, ref buControls.Forms.WinControlForms.Views.F_Preview.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SettingsTreeView>", "</F_SettingsTreeView>", StringList), clsVar.varRuntime.Language, ref F_SettingsTreeView.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ProgressCalculation>", "</F_ProgressCalculation>", StringList), clsVar.varRuntime.Language, ref F_ProgressCalculation.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_OsnapSettings>", "</F_OsnapSettings>", StringList), clsVar.varRuntime.Language, ref F_OsnapSettings.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_LibraryProps>", "</F_LibraryProps>", StringList), clsVar.varRuntime.Language, ref F_LibraryProps.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Alarm>", "</F_Alarm>", StringList), clsVar.varRuntime.Language, ref F_Alarm.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CoordsSingleAxis>", "</F_CoordsSingleAxis>", StringList), clsVar.varRuntime.Language, ref F_CoordsSingleAxis.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MoveXYZ>", "</F_MoveXYZ>", StringList), clsVar.varRuntime.Language, ref F_MoveXYZ.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Cf2Properties>", "</F_Cf2Properties>", StringList), clsVar.varRuntime.Language, ref F_Cf2PropertiesList.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Cf2Properties>", "</F_Cf2Properties>", StringList), clsVar.varRuntime.Language, ref F_DxfPropertiesList.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_About>", "</F_About>", StringList), clsVar.varRuntime.Language, ref F_About.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Notepad>", "</F_Notepad>", StringList), clsVar.varRuntime.Language, ref F_Notepad.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CamAll>", "</F_CamAll>", StringList), clsVar.varRuntime.Language, ref F_Hatch.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Barrel>", "</F_Barrel>", StringList), clsVar.varRuntime.Language, ref F_Barrel.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CircleCenter>", "</F_CircleCenter>", StringList), clsVar.varRuntime.Language, ref F_CircleCenter.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Ellipse>", "</F_Ellipse>", StringList), clsVar.varRuntime.Language, ref F_Ellipse.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Line>", "</F_Line>", StringList), clsVar.varRuntime.Language, ref F_Line.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Point>", "</F_Point>", StringList), clsVar.varRuntime.Language, ref F_Point.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Polygon>", "</F_Polygon>", StringList), clsVar.varRuntime.Language, ref F_Polygon.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Rectangle>", "</F_Rectangle>", StringList), clsVar.varRuntime.Language, ref F_Rectangle.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RectangleChamfer>", "</F_RectangleChamfer>", StringList), clsVar.varRuntime.Language, ref F_RectangleChamfer.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RectangleRound>", "</F_RectangleRound>", StringList), clsVar.varRuntime.Language, ref F_RectangleRound.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Slot>", "</F_Slot>", StringList), clsVar.varRuntime.Language, ref F_Slot.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Triangle>", "</F_Triangle>", StringList), clsVar.varRuntime.Language, ref F_Triangle.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_VectorText>", "</F_VectorText>", StringList), clsVar.varRuntime.Language, ref F_VectorText.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<FWin_Debug>", "</FWin_Debug>", StringList), clsVar.varRuntime.Language, ref FWin_Debug.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CutAngles>", "</F_CutAngles>", StringList), clsVar.varRuntime.Language, ref F_CutAngles.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Material>", "</F_Material>", StringList), clsVar.varRuntime.Language, ref buEyeBaseVer5.Forms.F_Material.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MaterialList>", "</F_MaterialList>", StringList), clsVar.varRuntime.Language, ref F_MaterialList.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MaterialRectangle>", "</F_MaterialRectangle>", StringList), clsVar.varRuntime.Language, ref F_MaterialRectangle.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_KinematicBasic>", "</F_KinematicBasic>", StringList), clsVar.varRuntime.Language, ref F_KinematicBasic.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_KinematicDefine>", "</F_KinematicDefine>", StringList), clsVar.varRuntime.Language, ref F_KinematicDefine.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MachineSelect>", "</F_MachineSelect>", StringList), clsVar.varRuntime.Language, ref F_MachineSelect.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MachineTypeAdd>", "</F_MachineTypeAdd>", StringList), clsVar.varRuntime.Language, ref F_MachineTypeAdd.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_DrawPropertiesType>", "</F_DrawPropertiesType>", StringList), clsVar.varRuntime.Language, ref F_DrawPropertiesType.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_EntitiyResolution>", "</F_EntitiyResolution>", StringList), clsVar.varRuntime.Language, ref F_EntitiyResolution.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MouseKeyboardConfig>", "</F_MouseKeyboardConfig>", StringList), clsVar.varRuntime.Language, ref F_MouseKeyboardConfig.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Pnt3D>", "</F_Pnt3D>", StringList), clsVar.varRuntime.Language, ref F_Pnt3D.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SimAxisDefination>", "</F_SimAxisDefination>", StringList), clsVar.varRuntime.Language, ref F_SimAxisDefinition.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Size>", "</F_Size>", StringList), clsVar.varRuntime.Language, ref F_Size.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SolidItemDisplay>", "</F_SolidItemDisplay>", StringList), clsVar.varRuntime.Language, ref F_SolidItemDisplay.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_LinearArray>", "</F_LinearArray>", StringList), clsVar.varRuntime.Language, ref F_LinearArray.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MoveScaleRotate>", "</F_MoveScaleRotate>", StringList), clsVar.varRuntime.Language, ref F_MoveScaleRotate.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_StockDef>", "</F_StockDef>", StringList), clsVar.varRuntime.Language, ref F_StockDef.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RoughingAdvanced>", "</F_RoughingAdvanced>", StringList), clsVar.varRuntime.Language, ref F_RoughingAdvanced.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Roughing>", "</F_Roughing>", StringList), clsVar.varRuntime.Language, ref F_Roughing.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_DeptStepAdvanced>", "</F_DeptStepAdvanced>", StringList), clsVar.varRuntime.Language, ref F_DepthStepAdvanced.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Height>", "</F_Height>", StringList), clsVar.varRuntime.Language, ref F_Height.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_HeightAdvanced>", "</F_HeightAdvanced>", StringList), clsVar.varRuntime.Language, ref F_HeightAdvanced.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SurfaceQuality>", "</F_SurfaceQuality>", StringList), clsVar.varRuntime.Language, ref F_SurfaceQuality.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFContourLink>", "</F_WFContourLink>", StringList), clsVar.varRuntime.Language, ref F_ContourLink.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFRoughLink>", "</F_WFRoughLink>", StringList), clsVar.varRuntime.Language, ref F_RoughLink.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_DrillLine>", "</F_DrillLine>", StringList), clsVar.varRuntime.Language, ref F_DrillLine.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFRough>", "</F_WFRough>", StringList), clsVar.varRuntime.Language, ref F_WFRough.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFContour>", "</F_WFContour>", StringList), clsVar.varRuntime.Language, ref F_WFContour.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFContour>", "</F_WFContour>", StringList), clsVar.varRuntime.Language, ref F_WFContour4AX.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFSpin>", "</F_WFSpin>", StringList), clsVar.varRuntime.Language, ref F_WFSpin.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_WFLeadControl>", "</F_WFLeadControl>", StringList), clsVar.varRuntime.Language, ref F_LeadControl.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshRough>", "</F_TriMeshRough>", StringList), clsVar.varRuntime.Language, ref F_TriMeshRough.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshParallelCut>", "</F_TriMeshParallelCut>", StringList), clsVar.varRuntime.Language, ref F_TriMeshParallelCut.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshConstantZ>", "</F_TriMeshConstantZ>", StringList), clsVar.varRuntime.Language, ref F_TriMeshConstantZ.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_2DContainment>", "</F_2DContainment>", StringList), clsVar.varRuntime.Language, ref F_2DContainment.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AngleRange>", "</F_AngleRange>", StringList), clsVar.varRuntime.Language, ref F_AngleRange.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Filtering>", "</F_Filtering>", StringList), clsVar.varRuntime.Language, ref F_Filtering.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Fixtures>", "</F_Fixtures>", StringList), clsVar.varRuntime.Language, ref F_Fixtures.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_MultiPass>", "</F_MultiPass>", StringList), clsVar.varRuntime.Language, ref F_MultiPass.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ProfilePass>", "</F_ProfilePass>", StringList), clsVar.varRuntime.Language, ref F_ProfilePass.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RestFinish>", "</F_RestFinish>", StringList), clsVar.varRuntime.Language, ref F_RestFinish.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RestRough>", "</F_RestRough>", StringList), clsVar.varRuntime.Language, ref F_RestRough.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RoundCorner>", "</F_RoundCorner>", StringList), clsVar.varRuntime.Language, ref F_RoundCorner.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Silhouette>", "</F_Silhouette>", StringList), clsVar.varRuntime.Language, ref F_Silhouette.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TriMeshParallelCut>", "</F_TriMeshParallelCut>", StringList), clsVar.varRuntime.Language, ref F_TriMeshParallelCut.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolDataBase>", "</F_ToolDataBase>", StringList), clsVar.varRuntime.Language, ref F_ToolDBase.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolDetailed>", "</F_ToolDetailed>", StringList), clsVar.varRuntime.Language, ref F_ToolDetailed.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolDiemaker>", "</F_ToolDiemaker>", StringList), clsVar.varRuntime.Language, ref F_ToolDiemaker.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolTypeSaw>", "</F_ToolTypeSaw>", StringList), clsVar.varRuntime.Language, ref F_ToolTypeSaw.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolType1>", "</F_ToolType1>", StringList), clsVar.varRuntime.Language, ref F_ToolType1.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BendingItems>", "</F_BendingItems>", StringList), clsVar.varRuntime.Language, ref F_BendingItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BendMarkItems>", "</F_BendMarkItems>", StringList), clsVar.varRuntime.Language, ref F_BendMarkItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BridgeItems>", "</F_BridgeItems>", StringList), clsVar.varRuntime.Language, ref F_BridgeItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BridgeProps>", "</F_BridgeProps>", StringList), clsVar.varRuntime.Language, ref F_BridgeProps.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_BroachItems>", "</F_BroachItems>", StringList), clsVar.varRuntime.Language, ref F_BroachItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CreasingCornerItems>", "</F_CreasingCornerItems>", StringList), clsVar.varRuntime.Language, ref F_CreasingCornerItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_HalfBridgeItems>", "</F_HalfBridgeItems>", StringList), clsVar.varRuntime.Language, ref F_HalfBridgeItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NickItems>", "</F_NickItems>", StringList), clsVar.varRuntime.Language, ref F_NickItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Offsets>", "</F_Offsets>", StringList), clsVar.varRuntime.Language, ref F_Offsets.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_PerfoCombiItems>", "</F_PerfoCombiItems>", StringList), clsVar.varRuntime.Language, ref F_PerfoCombiItems.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_RuleSettings>", "</F_RuleSettings>", StringList), clsVar.varRuntime.Language, ref F_RuleSettings.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SelectAlParts>", "</F_SelectAlParts>", StringList), clsVar.varRuntime.Language, ref F_SelectAlParts.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Status>", "</F_Status>", StringList), clsVar.varRuntime.Language, ref F_Status.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_TestPage>", "</F_TestPage>", StringList), clsVar.varRuntime.Language, ref F_TestPage.Captions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_ToolTest>", "</F_ToolTest>", StringList), clsVar.varRuntime.Language, ref F_ToolTest.Captions);
        StringList.Clear();
        buLogVer5.addToLog("clsFile", "buForms.lng", "buForms Language Loaded", "Ok", -1.0, 0.0);
      }
      else
      {
        buLogVer5.addToLog("clsFile", "buForms.lng", "buForms Language Loaded", "Ok", -1.0, 0.0);
        buString.MessageBoxError("buForm Language Form File Missing");
      }
      if (clsVar.appModes_0.MarbleMode.Enable && clsInit.appMarble != null)
        clsInit.appMarble.LoadLanguage();
      if (clsVar.appModes_0.ProfileMode.Enable && clsInit.appProfile != null)
        clsInit.appProfile.LoadLanguage();
      if (clsVar.appModes_0.DrillMode.Enable && clsInit.appDrill != null)
        clsInit.appDrill.LoadLanguage();
      if (clsVar.appModes_0.NestingMode.Enable && fileInfo5.Exists && clsInit.appNesting != null)
        clsInit.appNesting.LoadLanguage();
      if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable && clsInit.appLaserRouter != null)
        clsInit.appLaserRouter.LoadLanguage();
      if (clsVar.appModes_0.TuftingMode.Enable && clsInit.appTufting != null)
        clsInit.appTufting.LoadLanguage();
      if (clsVar.appModes_0.QuiltingMode.Enable && clsInit.appQuilting != null)
        clsInit.appQuilting.LoadLanguage();
      if (clsVar.appModes_0.SewingMode.Enable && clsInit.appSewing != null)
        clsInit.appSewing.LoadLanguage();
      if (clsVar.appModes_0.RollerBendMode.Enable && clsInit.appRollerBend != null)
        clsInit.appRollerBend.LoadLanguage();
      buLogVer5.addToLog("clsFile", nameof (OpenLanguageFiles), "Language File Loaded", "Ok", -1.0, 0.0);
      GC.Collect();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog("clsFile", nameof (OpenLanguageFiles), "Language File Loaded", "Fail", -1.0, 0.0);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void OpenMaterials(string Path, ref List<Material> MaterialList)
  {
    List<string> Files = new List<string>();
    buFile5.GetFilesInDirectory(Path, ".bumat", ref Files);
    for (int index1 = 0; index1 <= Files.Count - 1; ++index1)
    {
      List<string> StringList = new List<string>();
      buFile5.OpenFromFile(Files[index1], ref StringList);
      string name = "Mats";
      Color ambient = Color.FromArgb(100, 100, 100);
      Color specular = Color.White;
      float num1 = 0.01f;
      float shininess = 1f;
      Image image = (Image) null;
      linearUnitsType linearUnitsType = linearUnitsType.Millimeters;
      massUnitsType massUnitsType = massUnitsType.Kilograms;
      double num2 = 6E-07;
      float num3 = 2000f;
      FileInfo fileInfo1 = new FileInfo($"{Path}\\{buFile5.getFileNameWithoutExtension(Files[index1])}.jpg");
      if (fileInfo1.Exists)
      {
        image = Image.FromFile(fileInfo1.FullName);
      }
      else
      {
        FileInfo fileInfo2 = new FileInfo($"{Path}\\{buFile5.getFileNameWithoutExtension(Files[index1])}.png");
        if (fileInfo2.Exists)
          image = Image.FromFile(fileInfo2.FullName);
      }
      for (int index2 = 0; index2 <= StringList.Count - 1; ++index2)
      {
        if (StringList[index2].ToLower().IndexOf("name") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            name = strArray[1].Trim();
        }
        if (StringList[index2].ToLower().IndexOf("ambiance") >= 0)
        {
          string[] strArray1 = StringList[index2].Split('=');
          if (strArray1 != null && strArray1.Length >= 2)
          {
            string[] strArray2 = strArray1[1].Split(',');
            if (strArray2 != null && strArray2.Length >= 3)
              ambient = Color.FromArgb(int.Parse(strArray2[0]), int.Parse(strArray2[1]), int.Parse(strArray2[2]));
          }
        }
        if (StringList[index2].ToLower().IndexOf("specularcolor") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            specular = Color.FromName(strArray[1]);
        }
        if (StringList[index2].ToLower().IndexOf("shininess") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            shininess = float.Parse(strArray[1]);
        }
        if (StringList[index2].ToLower().IndexOf("density") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            num2 = double.Parse(strArray[1]);
        }
        if (StringList[index2].ToLower().IndexOf("texturelength") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            num3 = float.Parse(strArray[1]);
        }
        if (StringList[index2].ToLower().IndexOf("environment") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            num1 = float.Parse(strArray[1]);
        }
        if (StringList[index2].ToLower().IndexOf("linearunits") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            linearUnitsType = (linearUnitsType) int.Parse(strArray[1]);
        }
        if (StringList[index2].ToLower().IndexOf("massunits") >= 0)
        {
          string[] strArray = StringList[index2].Split('=');
          if (strArray != null && strArray.Length >= 2)
            massUnitsType = (massUnitsType) int.Parse(strArray[1]);
        }
      }
      if (image != null)
      {
        Material material = new Material(name, ambient, specular, shininess, image.ToByteArray())
        {
          LinearUnits = linearUnitsType,
          MassUnits = massUnitsType,
          Density = num2,
          TextureLength = num3,
          Environment = num1
        };
        MaterialList.Add(material);
      }
    }
  }

  public static void OpenMachineConfig(
    string FileName,
    ref MachineDef Machine,
    MachineConfigSettings Settings)
  {
    if (!new FileInfo(FileName).Exists)
      return;
    Machine = new MachineDef();
    buFile5.OpenMachineConfigFile(FileName, ref Machine, Settings);
  }

  public static void OpenMachineConfig(string FileName, ref MachineDef Machine)
  {
    clsFiles.OpenMachineConfig(FileName, ref Machine, new MachineConfigSettings());
  }

  public static void OpenKinematic(string FileName, ref KinematicBase5 Kinematic)
  {
    if (!new FileInfo(FileName).Exists)
      return;
    Kinematic = new KinematicBase5();
    buFile5.OpenKinemticFile(FileName, ref Kinematic);
  }

  public static void OpenPassword(string FileName, double Key)
  {
    try
    {
      string str1 = "";
      if (new FileInfo(FileName).Exists)
      {
        BinaryReader binaryReader = new BinaryReader((Stream) new FileStream(FileName, FileMode.Open));
        int num1 = binaryReader.ReadInt32();
        for (int index = 0; index < num1; ++index)
        {
          byte num2 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str1 += Convert.ToChar(num2).ToString();
          AppSecurity.Pass1 = str1;
        }
        string str2 = "";
        int num3 = binaryReader.ReadInt32();
        for (int index = 0; index < num3; ++index)
        {
          byte num4 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str2 += Convert.ToChar(num4).ToString();
          AppSecurity.Pass2 = str2;
        }
        string str3 = "";
        int num5 = binaryReader.ReadInt32();
        for (int index = 0; index < num5; ++index)
        {
          byte num6 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str3 += Convert.ToChar(num6).ToString();
          AppSecurity.Pass3 = str3;
        }
        string str4 = "";
        int num7 = binaryReader.ReadInt32();
        for (int index = 0; index < num7; ++index)
        {
          byte num8 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str4 += Convert.ToChar(num8).ToString();
          AppSecurity.Pass4 = str4;
        }
        string str5 = "";
        int num9 = binaryReader.ReadInt32();
        for (int index = 0; index < num9; ++index)
        {
          byte num10 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str5 += Convert.ToChar(num10).ToString();
          AppSecurity.Pass5 = str5;
        }
        string str6 = "";
        int num11 = binaryReader.ReadInt32();
        for (int index = 0; index < num11; ++index)
        {
          byte num12 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str6 += Convert.ToChar(num12).ToString();
          AppSecurity.Pass6 = str6;
        }
        string str7 = "";
        int num13 = binaryReader.ReadInt32();
        for (int index = 0; index < num13; ++index)
        {
          byte num14 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str7 += Convert.ToChar(num14).ToString();
          AppSecurity.Pass7 = str7;
        }
        string str8 = "";
        int num15 = binaryReader.ReadInt32();
        for (int index = 0; index < num15; ++index)
        {
          byte num16 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str8 += Convert.ToChar(num16).ToString();
          AppSecurity.Pass8 = str8;
        }
        string str9 = "";
        int num17 = binaryReader.ReadInt32();
        for (int index = 0; index < num17; ++index)
        {
          byte num18 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str9 += Convert.ToChar(num18).ToString();
          AppSecurity.Pass9 = str9;
        }
        string str10 = "";
        int num19 = binaryReader.ReadInt32();
        for (int index = 0; index < num19; ++index)
        {
          byte num20 = Convert.ToByte(binaryReader.ReadDouble() / (67.928 * Key));
          str10 += Convert.ToChar(num20).ToString();
          AppSecurity.Pass10 = str10;
        }
        binaryReader.Close();
      }
      buLogVer5.addToList(clsFiles.sClass, nameof (OpenPassword), "Password", "Decoded");
    }
    catch (Exception ex)
    {
      string auxMessage = "";
      buLogVer5.addToList(clsFiles.sClass, nameof (OpenPassword), "Password", "Exception");
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, auxMessage);
    }
  }

  public bool OpenDefAndKFile()
  {
    BinaryReader binaryReader = (BinaryReader) null;
    bool flag1;
    try
    {
      buLogVer5.addToLog("DefK", "Mode 999", "Starts", "", 0.0, 0.0);
      FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
      buLogVer5.addToLog("DefK", "Mode 1000", "mnb", fileInfo.Exists.ToString(), 0.0, 0.0);
      if (!fileInfo.Exists)
      {
        buLogVer5.addToLog("DefK", "Mode 998", "mn", "Missing", 0.0, 0.0);
        buString.MessageBoxError("Configration File is Missing");
        Environment.Exit(0);
        flag1 = false;
      }
      else if (fileInfo.Exists)
      {
        List<double> doubleList = new List<double>();
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        try
        {
          buLogVer5.addToLog("DefK", "Mode 1001", "mnb", "1", 0.0, 0.0);
          binaryReader = new BinaryReader((Stream) new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None));
          string str1 = "";
          string str2 = "";
          string str3 = "";
          string str4 = "";
          string str5 = "";
          string str6 = "";
          string str7 = "";
          string str8 = "";
          string str9 = "";
          string str10 = "";
          string str11 = "";
          string str12 = "";
          string str13 = "";
          string str14 = "";
          for (int index = 0; index < 755; ++index)
          {
            double num = (double) binaryReader.ReadSingle();
          }
          for (int index = 0; index < 1274; ++index)
            binaryReader.ReadDouble();
          for (int index = 0; index < 1498; ++index)
            binaryReader.ReadDecimal();
          for (int index = 0; index < 5614; ++index)
            binaryReader.ReadInt32();
          for (int index = 0; index < 4243; ++index)
          {
            double num = (double) binaryReader.ReadSingle();
          }
          for (int index = 0; index < 9867; ++index)
            binaryReader.ReadDouble();
          for (int index = 0; index < 3886; ++index)
            binaryReader.ReadDecimal();
          for (int index = 0; index < 5765; ++index)
            binaryReader.ReadInt32();
          int num1 = binaryReader.ReadInt32();
          doubleList.Clear();
          stringList1.Clear();
          stringList2.Clear();
          for (int index1 = 0; index1 <= num1 - 1; ++index1)
          {
            double num2 = binaryReader.ReadDouble() / 65.87;
            doubleList.Add(num2);
            int num3 = binaryReader.ReadInt32();
            string str15 = "";
            for (int index2 = 0; index2 < num3; ++index2)
            {
              byte num4 = Convert.ToByte(binaryReader.ReadDouble() / 46.8613);
              str15 += Convert.ToChar(num4).ToString();
            }
            stringList1.Add(str15);
            int num5 = binaryReader.ReadInt32();
            string str16 = "";
            for (int index3 = 0; index3 < num5; ++index3)
            {
              byte num6 = Convert.ToByte(binaryReader.ReadDouble() / 86.3456);
              str16 += Convert.ToChar(num6).ToString();
            }
            stringList2.Add(str16);
          }
          int num7 = binaryReader.ReadInt32();
          for (int index = 0; index < num7; ++index)
          {
            byte num8 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str1 += Convert.ToChar(num8).ToString();
          }
          int num9 = binaryReader.ReadInt32();
          for (int index = 0; index < num9; ++index)
          {
            byte num10 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str2 += Convert.ToChar(num10).ToString();
          }
          int num11 = binaryReader.ReadInt32();
          for (int index = 0; index < num11; ++index)
          {
            byte num12 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str3 += Convert.ToChar(num12).ToString();
          }
          int num13 = binaryReader.ReadInt32();
          for (int index = 0; index < num13; ++index)
          {
            byte num14 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str4 += Convert.ToChar(num14).ToString();
          }
          int num15 = binaryReader.ReadInt32();
          for (int index = 0; index < num15; ++index)
          {
            byte num16 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str5 += Convert.ToChar(num16).ToString();
          }
          int num17 = binaryReader.ReadInt32();
          for (int index = 0; index < num17; ++index)
          {
            byte num18 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str6 += Convert.ToChar(num18).ToString();
          }
          int num19 = binaryReader.ReadInt32();
          for (int index = 0; index < num19; ++index)
          {
            byte num20 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str7 += Convert.ToChar(num20).ToString();
          }
          int num21 = binaryReader.ReadInt32();
          for (int index = 0; index < num21; ++index)
          {
            byte num22 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str8 += Convert.ToChar(num22).ToString();
          }
          int num23 = binaryReader.ReadInt32();
          for (int index = 0; index < num23; ++index)
          {
            byte num24 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
            str9 += Convert.ToChar(num24).ToString();
          }
          clsVar.appDefination.Name = str1;
          clsVar.appDefination.Type = str2;
          clsVar.appDefination.Description = str3;
          clsVar.appDefination.Vendor = str4;
          clsVar.appDefination.Mode = str5;
          clsVar.appDefination.Web = str6;
          clsVar.appDefination.Aux = str7;
          clsVar.appDefination.CustomerInfo = str8;
          clsVar.appDefination.Command = str9;
          clsVar.appDefination.CustomerID = (AppCustomerID) Convert.ToInt32(Math.Round(binaryReader.ReadDouble() / 164.542, 7));
          double num25 = binaryReader.ReadDouble() / 533.134;
          clsVar.appDefination.AppID = Convert.ToInt32(num25);
          clsVar.appDefination.AppType = (AppDefinationType) Convert.ToInt32(num25);
          clsVar.appModes_0.NumberOfDemoRun = Convert.ToInt32(binaryReader.ReadDouble() / -164.433);
          clsVar.appModes_0.NumberOfDemoOpenFile = Convert.ToInt32(binaryReader.ReadDouble() / 149.124);
          double num26 = binaryReader.ReadDouble() / 624.56;
          double num27 = binaryReader.ReadDouble() / 456.34;
          double num28 = binaryReader.ReadDouble() / 875.14;
          double num29 = binaryReader.ReadDouble() / 326.98;
          double num30 = binaryReader.ReadDouble() / 934.67;
          int num31 = binaryReader.ReadInt32();
          for (int index = 0; index < num31; ++index)
          {
            byte num32 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str10 += Convert.ToChar(num32).ToString();
          }
          int num33 = binaryReader.ReadInt32();
          for (int index = 0; index < num33; ++index)
          {
            byte num34 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str11 += Convert.ToChar(num34).ToString();
          }
          int num35 = binaryReader.ReadInt32();
          for (int index = 0; index < num35; ++index)
          {
            byte num36 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str12 += Convert.ToChar(num36).ToString();
          }
          int num37 = binaryReader.ReadInt32();
          for (int index = 0; index < num37; ++index)
          {
            byte num38 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str13 += Convert.ToChar(num38).ToString();
          }
          int num39 = binaryReader.ReadInt32();
          for (int index = 0; index < num39; ++index)
          {
            byte num40 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
            str14 += Convert.ToChar(num40).ToString();
          }
          int int32_1 = Convert.ToInt32(binaryReader.ReadDouble() / 624.65423);
          int int32_2 = Convert.ToInt32(binaryReader.ReadDouble() / -423.45738);
          int int32_3 = Convert.ToInt32(binaryReader.ReadDouble() / 382.19531);
          clsVar.appModes_0.ExpireDateTime = new DateTime(int32_3, int32_2, int32_1);
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
          double num41 = binaryReader.ReadDouble() / 167.678;
          double num42 = binaryReader.ReadDouble() / 84.573;
          double num43 = binaryReader.ReadDouble() / 205.678;
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
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
          string str17 = "";
          int num44 = binaryReader.ReadInt32();
          for (int index = 0; index < num44; ++index)
          {
            byte num45 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str17 += Convert.ToChar(num45).ToString();
          }
          clsVar.appModes_0.GrindingMode.Mode3 = str17;
          string str18 = "";
          int num46 = binaryReader.ReadInt32();
          for (int index = 0; index < num46; ++index)
          {
            byte num47 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str18 += Convert.ToChar(num47).ToString();
          }
          clsVar.appModes_0.GrindingMode.Mode4 = str18;
          string str19 = "";
          int num48 = binaryReader.ReadInt32();
          for (int index = 0; index < num48; ++index)
          {
            byte num49 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str19 += Convert.ToChar(num49).ToString();
          }
          clsVar.appModes_0.GrindingMode.Mode1Exp = str19;
          string str20 = "";
          int num50 = binaryReader.ReadInt32();
          for (int index = 0; index < num50; ++index)
          {
            byte num51 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str20 += Convert.ToChar(num51).ToString();
          }
          clsVar.appModes_0.GrindingMode.Mode2Exp = str20;
          string str21 = "";
          int num52 = binaryReader.ReadInt32();
          for (int index = 0; index < num52; ++index)
          {
            byte num53 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str21 += Convert.ToChar(num53).ToString();
          }
          clsVar.appModes_0.GrindingMode.Mode3Exp = str21;
          string str22 = "";
          int num54 = binaryReader.ReadInt32();
          for (int index = 0; index < num54; ++index)
          {
            byte num55 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str22 += Convert.ToChar(num55).ToString();
          }
          clsVar.appModes_0.GrindingMode.Mode4Exp = str22;
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
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
          string str23 = "";
          int num56 = binaryReader.ReadInt32();
          for (int index = 0; index < num56; ++index)
          {
            byte num57 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str23 += Convert.ToChar(num57).ToString();
          }
          clsVar.appModes_0.NestingMode.Mode3 = str23;
          string str24 = "";
          int num58 = binaryReader.ReadInt32();
          for (int index = 0; index < num58; ++index)
          {
            byte num59 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str24 += Convert.ToChar(num59).ToString();
          }
          clsVar.appModes_0.NestingMode.Mode4 = str24;
          string str25 = "";
          int num60 = binaryReader.ReadInt32();
          for (int index = 0; index < num60; ++index)
          {
            byte num61 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str25 += Convert.ToChar(num61).ToString();
          }
          clsVar.appModes_0.NestingMode.Mode1Exp = str25;
          string str26 = "";
          int num62 = binaryReader.ReadInt32();
          for (int index = 0; index < num62; ++index)
          {
            byte num63 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str26 += Convert.ToChar(num63).ToString();
          }
          clsVar.appModes_0.NestingMode.Mode2Exp = str26;
          string str27 = "";
          int num64 = binaryReader.ReadInt32();
          for (int index = 0; index < num64; ++index)
          {
            byte num65 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str27 += Convert.ToChar(num65).ToString();
          }
          clsVar.appModes_0.NestingMode.Mode3Exp = str27;
          string str28 = "";
          int num66 = binaryReader.ReadInt32();
          for (int index = 0; index < num66; ++index)
          {
            byte num67 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str28 += Convert.ToChar(num67).ToString();
          }
          clsVar.appModes_0.NestingMode.Mode4Exp = str28;
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
          string str29 = "";
          int num68 = binaryReader.ReadInt32();
          for (int index = 0; index < num68; ++index)
          {
            byte num69 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str29 += Convert.ToChar(num69).ToString();
          }
          clsVar.appModes_0.JewelMode.Mode3 = str29;
          string str30 = "";
          int num70 = binaryReader.ReadInt32();
          for (int index = 0; index < num70; ++index)
          {
            byte num71 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str30 += Convert.ToChar(num71).ToString();
          }
          clsVar.appModes_0.JewelMode.Mode4 = str30;
          string str31 = "";
          int num72 = binaryReader.ReadInt32();
          for (int index = 0; index < num72; ++index)
          {
            byte num73 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str31 += Convert.ToChar(num73).ToString();
          }
          clsVar.appModes_0.JewelMode.Mode1Exp = str31;
          string str32 = "";
          int num74 = binaryReader.ReadInt32();
          for (int index = 0; index < num74; ++index)
          {
            byte num75 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str32 += Convert.ToChar(num75).ToString();
          }
          clsVar.appModes_0.JewelMode.Mode2Exp = str32;
          string str33 = "";
          int num76 = binaryReader.ReadInt32();
          for (int index = 0; index < num76; ++index)
          {
            byte num77 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str33 += Convert.ToChar(num77).ToString();
          }
          clsVar.appModes_0.JewelMode.Mode3Exp = str33;
          string str34 = "";
          int num78 = binaryReader.ReadInt32();
          for (int index = 0; index < num78; ++index)
          {
            byte num79 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str34 += Convert.ToChar(num79).ToString();
          }
          clsVar.appModes_0.JewelMode.Mode4Exp = str34;
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
          string str35 = "";
          int num80 = binaryReader.ReadInt32();
          for (int index = 0; index < num80; ++index)
          {
            byte num81 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str35 += Convert.ToChar(num81).ToString();
          }
          clsVar.appModes_0.CompositeMode.Mode3 = str35;
          string str36 = "";
          int num82 = binaryReader.ReadInt32();
          for (int index = 0; index < num82; ++index)
          {
            byte num83 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str36 += Convert.ToChar(num83).ToString();
          }
          clsVar.appModes_0.CompositeMode.Mode4 = str36;
          string str37 = "";
          int num84 = binaryReader.ReadInt32();
          for (int index = 0; index < num84; ++index)
          {
            byte num85 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str37 += Convert.ToChar(num85).ToString();
          }
          clsVar.appModes_0.CompositeMode.Mode1Exp = str37;
          string str38 = "";
          int num86 = binaryReader.ReadInt32();
          for (int index = 0; index < num86; ++index)
          {
            byte num87 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str38 += Convert.ToChar(num87).ToString();
          }
          clsVar.appModes_0.CompositeMode.Mode2Exp = str38;
          string str39 = "";
          int num88 = binaryReader.ReadInt32();
          for (int index = 0; index < num88; ++index)
          {
            byte num89 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str39 += Convert.ToChar(num89).ToString();
          }
          clsVar.appModes_0.CompositeMode.Mode3Exp = str39;
          string str40 = "";
          int num90 = binaryReader.ReadInt32();
          for (int index = 0; index < num90; ++index)
          {
            byte num91 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str40 += Convert.ToChar(num91).ToString();
          }
          clsVar.appModes_0.CompositeMode.Mode4Exp = str40;
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
          string str41 = "";
          int num92 = binaryReader.ReadInt32();
          for (int index = 0; index < num92; ++index)
          {
            byte num93 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str41 += Convert.ToChar(num93).ToString();
          }
          clsVar.appModes_0.WoodMode.Mode3 = str41;
          string str42 = "";
          int num94 = binaryReader.ReadInt32();
          for (int index = 0; index < num94; ++index)
          {
            byte num95 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str42 += Convert.ToChar(num95).ToString();
          }
          clsVar.appModes_0.WoodMode.Mode4 = str42;
          string str43 = "";
          int num96 = binaryReader.ReadInt32();
          for (int index = 0; index < num96; ++index)
          {
            byte num97 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str43 += Convert.ToChar(num97).ToString();
          }
          clsVar.appModes_0.WoodMode.Mode1Exp = str43;
          string str44 = "";
          int num98 = binaryReader.ReadInt32();
          for (int index = 0; index < num98; ++index)
          {
            byte num99 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str44 += Convert.ToChar(num99).ToString();
          }
          clsVar.appModes_0.WoodMode.Mode2Exp = str44;
          string str45 = "";
          int num100 = binaryReader.ReadInt32();
          for (int index = 0; index < num100; ++index)
          {
            byte num101 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str45 += Convert.ToChar(num101).ToString();
          }
          clsVar.appModes_0.WoodMode.Mode3Exp = str45;
          string str46 = "";
          int num102 = binaryReader.ReadInt32();
          for (int index = 0; index < num102; ++index)
          {
            byte num103 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str46 += Convert.ToChar(num103).ToString();
          }
          clsVar.appModes_0.WoodMode.Mode4Exp = str46;
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
          string str47 = "";
          int num104 = binaryReader.ReadInt32();
          for (int index = 0; index < num104; ++index)
          {
            byte num105 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str47 += Convert.ToChar(num105).ToString();
          }
          clsVar.appModes_0.TuftingMode.Mode3 = str47;
          string str48 = "";
          int num106 = binaryReader.ReadInt32();
          for (int index = 0; index < num106; ++index)
          {
            byte num107 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str48 += Convert.ToChar(num107).ToString();
          }
          clsVar.appModes_0.TuftingMode.Mode4 = str48;
          string str49 = "";
          int num108 = binaryReader.ReadInt32();
          for (int index = 0; index < num108; ++index)
          {
            byte num109 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str49 += Convert.ToChar(num109).ToString();
          }
          clsVar.appModes_0.TuftingMode.Mode1Exp = str49;
          string str50 = "";
          int num110 = binaryReader.ReadInt32();
          for (int index = 0; index < num110; ++index)
          {
            byte num111 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str50 += Convert.ToChar(num111).ToString();
          }
          clsVar.appModes_0.TuftingMode.Mode2Exp = str50;
          string str51 = "";
          int num112 = binaryReader.ReadInt32();
          for (int index = 0; index < num112; ++index)
          {
            byte num113 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str51 += Convert.ToChar(num113).ToString();
          }
          clsVar.appModes_0.TuftingMode.Mode3Exp = str51;
          string str52 = "";
          int num114 = binaryReader.ReadInt32();
          for (int index = 0; index < num114; ++index)
          {
            byte num115 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str52 += Convert.ToChar(num115).ToString();
          }
          clsVar.appModes_0.TuftingMode.Mode4Exp = str52;
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
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
          string str53 = "";
          int num116 = binaryReader.ReadInt32();
          for (int index = 0; index < num116; ++index)
          {
            byte num117 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str53 += Convert.ToChar(num117).ToString();
          }
          clsVar.appModes_0.DiemakerMode.Mode3 = str53;
          string str54 = "";
          int num118 = binaryReader.ReadInt32();
          for (int index = 0; index < num118; ++index)
          {
            byte num119 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str54 += Convert.ToChar(num119).ToString();
          }
          clsVar.appModes_0.DiemakerMode.Mode4 = str54;
          string str55 = "";
          int num120 = binaryReader.ReadInt32();
          for (int index = 0; index < num120; ++index)
          {
            byte num121 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str55 += Convert.ToChar(num121).ToString();
          }
          clsVar.appModes_0.DiemakerMode.Mode1Exp = str55;
          string str56 = "";
          int num122 = binaryReader.ReadInt32();
          for (int index = 0; index < num122; ++index)
          {
            byte num123 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str56 += Convert.ToChar(num123).ToString();
          }
          clsVar.appModes_0.DiemakerMode.Mode2Exp = str56;
          string str57 = "";
          int num124 = binaryReader.ReadInt32();
          for (int index = 0; index < num124; ++index)
          {
            byte num125 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str57 += Convert.ToChar(num125).ToString();
          }
          clsVar.appModes_0.DiemakerMode.Mode3Exp = str57;
          string str58 = "";
          int num126 = binaryReader.ReadInt32();
          for (int index = 0; index < num126; ++index)
          {
            byte num127 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str58 += Convert.ToChar(num127).ToString();
          }
          clsVar.appModes_0.DiemakerMode.Mode4Exp = str58;
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
          string str59 = "";
          int num128 = binaryReader.ReadInt32();
          for (int index = 0; index < num128; ++index)
          {
            byte num129 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str59 += Convert.ToChar(num129).ToString();
          }
          clsVar.appModes_0.WireBendMode.Mode3 = str59;
          string str60 = "";
          int num130 = binaryReader.ReadInt32();
          for (int index = 0; index < num130; ++index)
          {
            byte num131 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str60 += Convert.ToChar(num131).ToString();
          }
          clsVar.appModes_0.WireBendMode.Mode4 = str60;
          string str61 = "";
          int num132 = binaryReader.ReadInt32();
          for (int index = 0; index < num132; ++index)
          {
            byte num133 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str61 += Convert.ToChar(num133).ToString();
          }
          clsVar.appModes_0.WireBendMode.Mode1Exp = str61;
          string str62 = "";
          int num134 = binaryReader.ReadInt32();
          for (int index = 0; index < num134; ++index)
          {
            byte num135 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str62 += Convert.ToChar(num135).ToString();
          }
          clsVar.appModes_0.WireBendMode.Mode2Exp = str62;
          string str63 = "";
          int num136 = binaryReader.ReadInt32();
          for (int index = 0; index < num136; ++index)
          {
            byte num137 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str63 += Convert.ToChar(num137).ToString();
          }
          clsVar.appModes_0.WireBendMode.Mode3Exp = str63;
          string str64 = "";
          int num138 = binaryReader.ReadInt32();
          for (int index = 0; index < num138; ++index)
          {
            byte num139 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str64 += Convert.ToChar(num139).ToString();
          }
          clsVar.appModes_0.WireBendMode.Mode4Exp = str64;
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
          string str65 = "";
          int num140 = binaryReader.ReadInt32();
          for (int index = 0; index < num140; ++index)
          {
            byte num141 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str65 += Convert.ToChar(num141).ToString();
          }
          clsVar.appModes_0.ProfileMode.Mode3 = str65;
          string str66 = "";
          int num142 = binaryReader.ReadInt32();
          for (int index = 0; index < num142; ++index)
          {
            byte num143 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str66 += Convert.ToChar(num143).ToString();
          }
          clsVar.appModes_0.ProfileMode.Mode4 = str66;
          string str67 = "";
          int num144 = binaryReader.ReadInt32();
          for (int index = 0; index < num144; ++index)
          {
            byte num145 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str67 += Convert.ToChar(num145).ToString();
          }
          clsVar.appModes_0.ProfileMode.Mode1Exp = str67;
          string str68 = "";
          int num146 = binaryReader.ReadInt32();
          for (int index = 0; index < num146; ++index)
          {
            byte num147 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str68 += Convert.ToChar(num147).ToString();
          }
          clsVar.appModes_0.ProfileMode.Mode2Exp = str68;
          string str69 = "";
          int num148 = binaryReader.ReadInt32();
          for (int index = 0; index < num148; ++index)
          {
            byte num149 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str69 += Convert.ToChar(num149).ToString();
          }
          clsVar.appModes_0.ProfileMode.Mode3Exp = str69;
          string str70 = "";
          int num150 = binaryReader.ReadInt32();
          for (int index = 0; index < num150; ++index)
          {
            byte num151 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str70 += Convert.ToChar(num151).ToString();
          }
          clsVar.appModes_0.ProfileMode.Mode4Exp = str70;
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
          if (clsVar.appModes_0.ModuleWork)
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
          else
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
          string str71 = "";
          int num152 = binaryReader.ReadInt32();
          for (int index = 0; index < num152; ++index)
          {
            byte num153 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str71 += Convert.ToChar(num153).ToString();
          }
          clsVar.appModes_0.PunchMode.Mode3 = str71;
          string str72 = "";
          int num154 = binaryReader.ReadInt32();
          for (int index = 0; index < num154; ++index)
          {
            byte num155 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str72 += Convert.ToChar(num155).ToString();
          }
          clsVar.appModes_0.PunchMode.Mode4 = str72;
          string str73 = "";
          int num156 = binaryReader.ReadInt32();
          for (int index = 0; index < num156; ++index)
          {
            byte num157 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str73 += Convert.ToChar(num157).ToString();
          }
          clsVar.appModes_0.PunchMode.Mode1Exp = str73;
          string str74 = "";
          int num158 = binaryReader.ReadInt32();
          for (int index = 0; index < num158; ++index)
          {
            byte num159 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str74 += Convert.ToChar(num159).ToString();
          }
          clsVar.appModes_0.PunchMode.Mode2Exp = str74;
          string str75 = "";
          int num160 = binaryReader.ReadInt32();
          for (int index = 0; index < num160; ++index)
          {
            byte num161 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str75 += Convert.ToChar(num161).ToString();
          }
          clsVar.appModes_0.PunchMode.Mode3Exp = str75;
          string str76 = "";
          int num162 = binaryReader.ReadInt32();
          for (int index = 0; index < num162; ++index)
          {
            byte num163 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str76 += Convert.ToChar(num163).ToString();
          }
          clsVar.appModes_0.PunchMode.Mode4Exp = str76;
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
          string str77 = "";
          int num164 = binaryReader.ReadInt32();
          for (int index = 0; index < num164; ++index)
          {
            byte num165 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str77 += Convert.ToChar(num165).ToString();
          }
          clsVar.appModes_0.RoboticMode.Mode3 = str77;
          string str78 = "";
          int num166 = binaryReader.ReadInt32();
          for (int index = 0; index < num166; ++index)
          {
            byte num167 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str78 += Convert.ToChar(num167).ToString();
          }
          clsVar.appModes_0.RoboticMode.Mode4 = str78;
          string str79 = "";
          int num168 = binaryReader.ReadInt32();
          for (int index = 0; index < num168; ++index)
          {
            byte num169 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str79 += Convert.ToChar(num169).ToString();
          }
          clsVar.appModes_0.RoboticMode.Mode1Exp = str79;
          string str80 = "";
          int num170 = binaryReader.ReadInt32();
          for (int index = 0; index < num170; ++index)
          {
            byte num171 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str80 += Convert.ToChar(num171).ToString();
          }
          clsVar.appModes_0.RoboticMode.Mode2Exp = str80;
          string str81 = "";
          int num172 = binaryReader.ReadInt32();
          for (int index = 0; index < num172; ++index)
          {
            byte num173 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str81 += Convert.ToChar(num173).ToString();
          }
          clsVar.appModes_0.RoboticMode.Mode3Exp = str81;
          string str82 = "";
          int num174 = binaryReader.ReadInt32();
          for (int index = 0; index < num174; ++index)
          {
            byte num175 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str82 += Convert.ToChar(num175).ToString();
          }
          clsVar.appModes_0.RoboticMode.Mode4Exp = str82;
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
          string str83 = "";
          int num176 = binaryReader.ReadInt32();
          for (int index = 0; index < num176; ++index)
          {
            byte num177 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str83 += Convert.ToChar(num177).ToString();
          }
          clsVar.appModes_0.FileOpenMode.Mode3 = str83;
          string str84 = "";
          int num178 = binaryReader.ReadInt32();
          for (int index = 0; index < num178; ++index)
          {
            byte num179 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str84 += Convert.ToChar(num179).ToString();
          }
          clsVar.appModes_0.FileOpenMode.Mode4 = str84;
          string str85 = "";
          int num180 = binaryReader.ReadInt32();
          for (int index = 0; index < num180; ++index)
          {
            byte num181 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str85 += Convert.ToChar(num181).ToString();
          }
          clsVar.appModes_0.FileOpenMode.Mode1Exp = str85;
          string str86 = "";
          int num182 = binaryReader.ReadInt32();
          for (int index = 0; index < num182; ++index)
          {
            byte num183 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str86 += Convert.ToChar(num183).ToString();
          }
          clsVar.appModes_0.FileOpenMode.Mode2Exp = str86;
          string str87 = "";
          int num184 = binaryReader.ReadInt32();
          for (int index = 0; index < num184; ++index)
          {
            byte num185 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str87 += Convert.ToChar(num185).ToString();
          }
          clsVar.appModes_0.FileOpenMode.Mode3Exp = str87;
          string str88 = "";
          int num186 = binaryReader.ReadInt32();
          for (int index = 0; index < num186; ++index)
          {
            byte num187 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str88 += Convert.ToChar(num187).ToString();
          }
          clsVar.appModes_0.FileOpenMode.Mode4Exp = str88;
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
          string str89 = "";
          int num188 = binaryReader.ReadInt32();
          for (int index = 0; index < num188; ++index)
          {
            byte num189 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str89 += Convert.ToChar(num189).ToString();
          }
          clsVar.appModes_0.FileSaveMode.Mode3 = str89;
          string str90 = "";
          int num190 = binaryReader.ReadInt32();
          for (int index = 0; index < num190; ++index)
          {
            byte num191 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str90 += Convert.ToChar(num191).ToString();
          }
          clsVar.appModes_0.FileSaveMode.Mode4 = str90;
          string str91 = "";
          int num192 = binaryReader.ReadInt32();
          for (int index = 0; index < num192; ++index)
          {
            byte num193 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str91 += Convert.ToChar(num193).ToString();
          }
          clsVar.appModes_0.FileSaveMode.Mode1Exp = str91;
          string str92 = "";
          int num194 = binaryReader.ReadInt32();
          for (int index = 0; index < num194; ++index)
          {
            byte num195 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str92 += Convert.ToChar(num195).ToString();
          }
          clsVar.appModes_0.FileSaveMode.Mode2Exp = str92;
          string str93 = "";
          int num196 = binaryReader.ReadInt32();
          for (int index = 0; index < num196; ++index)
          {
            byte num197 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str93 += Convert.ToChar(num197).ToString();
          }
          clsVar.appModes_0.FileSaveMode.Mode3Exp = str93;
          string str94 = "";
          int num198 = binaryReader.ReadInt32();
          for (int index = 0; index < num198; ++index)
          {
            byte num199 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str94 += Convert.ToChar(num199).ToString();
          }
          clsVar.appModes_0.FileSaveMode.Mode4Exp = str94;
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
          string str95 = "";
          int num200 = binaryReader.ReadInt32();
          for (int index = 0; index < num200; ++index)
          {
            byte num201 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str95 += Convert.ToChar(num201).ToString();
          }
          clsVar.appModes_0.ViewerMode.Mode3 = str95;
          string str96 = "";
          int num202 = binaryReader.ReadInt32();
          for (int index = 0; index < num202; ++index)
          {
            byte num203 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str96 += Convert.ToChar(num203).ToString();
          }
          clsVar.appModes_0.ViewerMode.Mode4 = str96;
          string str97 = "";
          int num204 = binaryReader.ReadInt32();
          for (int index = 0; index < num204; ++index)
          {
            byte num205 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str97 += Convert.ToChar(num205).ToString();
          }
          clsVar.appModes_0.ViewerMode.Mode1Exp = str97;
          string str98 = "";
          int num206 = binaryReader.ReadInt32();
          for (int index = 0; index < num206; ++index)
          {
            byte num207 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str98 += Convert.ToChar(num207).ToString();
          }
          clsVar.appModes_0.ViewerMode.Mode2Exp = str98;
          string str99 = "";
          int num208 = binaryReader.ReadInt32();
          for (int index = 0; index < num208; ++index)
          {
            byte num209 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str99 += Convert.ToChar(num209).ToString();
          }
          clsVar.appModes_0.ViewerMode.Mode3Exp = str99;
          string str100 = "";
          int num210 = binaryReader.ReadInt32();
          for (int index = 0; index < num210; ++index)
          {
            byte num211 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str100 += Convert.ToChar(num211).ToString();
          }
          clsVar.appModes_0.ViewerMode.Mode4Exp = str100;
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
          string str101 = "";
          int num212 = binaryReader.ReadInt32();
          for (int index = 0; index < num212; ++index)
          {
            byte num213 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            str101 += Convert.ToChar(num213).ToString();
          }
          clsVar.appModes_0.DrawMode.Mode3 = str101;
          string str102 = "";
          int num214 = binaryReader.ReadInt32();
          for (int index = 0; index < num214; ++index)
          {
            byte num215 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            str102 += Convert.ToChar(num215).ToString();
          }
          clsVar.appModes_0.DrawMode.Mode4 = str102;
          string str103 = "";
          int num216 = binaryReader.ReadInt32();
          for (int index = 0; index < num216; ++index)
          {
            byte num217 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str103 += Convert.ToChar(num217).ToString();
          }
          clsVar.appModes_0.DrawMode.Mode1Exp = str103;
          string str104 = "";
          int num218 = binaryReader.ReadInt32();
          for (int index = 0; index < num218; ++index)
          {
            byte num219 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str104 += Convert.ToChar(num219).ToString();
          }
          clsVar.appModes_0.DrawMode.Mode2Exp = str104;
          string str105 = "";
          int num220 = binaryReader.ReadInt32();
          for (int index = 0; index < num220; ++index)
          {
            byte num221 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            str105 += Convert.ToChar(num221).ToString();
          }
          clsVar.appModes_0.DrawMode.Mode3Exp = str105;
          string str106 = "";
          int num222 = binaryReader.ReadInt32();
          char ch;
          for (int index = 0; index < num222; ++index)
          {
            byte num223 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str107 = str106;
            ch = Convert.ToChar(num223);
            string str108 = ch.ToString();
            str106 = str107 + str108;
          }
          clsVar.appModes_0.DrawMode.Mode4Exp = str106;
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
          binaryReader.ReadBoolean();
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
          string str109 = "";
          int num224 = binaryReader.ReadInt32();
          for (int index = 0; index < num224; ++index)
          {
            byte num225 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str110 = str109;
            ch = Convert.ToChar(num225);
            string str111 = ch.ToString();
            str109 = str110 + str111;
          }
          clsVar.appModes_0.Temp2Mode.Mode3 = str109;
          string str112 = "";
          int num226 = binaryReader.ReadInt32();
          for (int index = 0; index < num226; ++index)
          {
            byte num227 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str113 = str112;
            ch = Convert.ToChar(num227);
            string str114 = ch.ToString();
            str112 = str113 + str114;
          }
          clsVar.appModes_0.Temp2Mode.Mode4 = str112;
          string str115 = "";
          int num228 = binaryReader.ReadInt32();
          for (int index = 0; index < num228; ++index)
          {
            byte num229 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str116 = str115;
            ch = Convert.ToChar(num229);
            string str117 = ch.ToString();
            str115 = str116 + str117;
          }
          clsVar.appModes_0.Temp2Mode.Mode1Exp = str115;
          string str118 = "";
          int num230 = binaryReader.ReadInt32();
          for (int index = 0; index < num230; ++index)
          {
            byte num231 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str119 = str118;
            ch = Convert.ToChar(num231);
            string str120 = ch.ToString();
            str118 = str119 + str120;
          }
          clsVar.appModes_0.Temp2Mode.Mode2Exp = str118;
          string str121 = "";
          int num232 = binaryReader.ReadInt32();
          for (int index = 0; index < num232; ++index)
          {
            byte num233 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str122 = str121;
            ch = Convert.ToChar(num233);
            string str123 = ch.ToString();
            str121 = str122 + str123;
          }
          clsVar.appModes_0.Temp2Mode.Mode3Exp = str121;
          string str124 = "";
          int num234 = binaryReader.ReadInt32();
          for (int index = 0; index < num234; ++index)
          {
            byte num235 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str125 = str124;
            ch = Convert.ToChar(num235);
            string str126 = ch.ToString();
            str124 = str125 + str126;
          }
          clsVar.appModes_0.Temp2Mode.Mode4Exp = str124;
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
          string str127 = "";
          int num236 = binaryReader.ReadInt32();
          for (int index = 0; index < num236; ++index)
          {
            byte num237 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str128 = str127;
            ch = Convert.ToChar(num237);
            string str129 = ch.ToString();
            str127 = str128 + str129;
          }
          clsVar.appModes_0.PipeBendMode.Mode3 = str127;
          string str130 = "";
          int num238 = binaryReader.ReadInt32();
          for (int index = 0; index < num238; ++index)
          {
            byte num239 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str131 = str130;
            ch = Convert.ToChar(num239);
            string str132 = ch.ToString();
            str130 = str131 + str132;
          }
          clsVar.appModes_0.PipeBendMode.Mode4 = str130;
          string str133 = "";
          int num240 = binaryReader.ReadInt32();
          for (int index = 0; index < num240; ++index)
          {
            byte num241 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str134 = str133;
            ch = Convert.ToChar(num241);
            string str135 = ch.ToString();
            str133 = str134 + str135;
          }
          clsVar.appModes_0.PipeBendMode.Mode1Exp = str133;
          string str136 = "";
          int num242 = binaryReader.ReadInt32();
          for (int index = 0; index < num242; ++index)
          {
            byte num243 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str137 = str136;
            ch = Convert.ToChar(num243);
            string str138 = ch.ToString();
            str136 = str137 + str138;
          }
          clsVar.appModes_0.PipeBendMode.Mode2Exp = str136;
          string str139 = "";
          int num244 = binaryReader.ReadInt32();
          for (int index = 0; index < num244; ++index)
          {
            byte num245 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str140 = str139;
            ch = Convert.ToChar(num245);
            string str141 = ch.ToString();
            str139 = str140 + str141;
          }
          clsVar.appModes_0.PipeBendMode.Mode3Exp = str139;
          string str142 = "";
          int num246 = binaryReader.ReadInt32();
          for (int index = 0; index < num246; ++index)
          {
            byte num247 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str143 = str142;
            ch = Convert.ToChar(num247);
            string str144 = ch.ToString();
            str142 = str143 + str144;
          }
          clsVar.appModes_0.PipeBendMode.Mode4Exp = str142;
          clsVar.appModes_0.WireBendMode.Mode1 = binaryReader.ReadDouble() / 376.558;
          clsVar.appModes_0.WireBendMode.Mode2 = binaryReader.ReadDouble() / 196.428;
          string str145 = "";
          int num248 = binaryReader.ReadInt32();
          for (int index = 0; index < num248; ++index)
          {
            byte num249 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str146 = str145;
            ch = Convert.ToChar(num249);
            string str147 = ch.ToString();
            str145 = str146 + str147;
          }
          clsVar.appModes_0.WireBendMode.Mode3 = str145;
          string str148 = "";
          int num250 = binaryReader.ReadInt32();
          for (int index = 0; index < num250; ++index)
          {
            byte num251 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str149 = str148;
            ch = Convert.ToChar(num251);
            string str150 = ch.ToString();
            str148 = str149 + str150;
          }
          clsVar.appModes_0.WireBendMode.Mode4 = str148;
          string str151 = "";
          int num252 = binaryReader.ReadInt32();
          for (int index = 0; index < num252; ++index)
          {
            byte num253 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str152 = str151;
            ch = Convert.ToChar(num253);
            string str153 = ch.ToString();
            str151 = str152 + str153;
          }
          clsVar.appModes_0.WireBendMode.Mode1Exp = str151;
          string str154 = "";
          int num254 = binaryReader.ReadInt32();
          for (int index = 0; index < num254; ++index)
          {
            byte num255 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str155 = str154;
            ch = Convert.ToChar(num255);
            string str156 = ch.ToString();
            str154 = str155 + str156;
          }
          clsVar.appModes_0.WireBendMode.Mode2Exp = str154;
          string str157 = "";
          int num256 = binaryReader.ReadInt32();
          for (int index = 0; index < num256; ++index)
          {
            byte num257 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str158 = str157;
            ch = Convert.ToChar(num257);
            string str159 = ch.ToString();
            str157 = str158 + str159;
          }
          clsVar.appModes_0.WireBendMode.Mode3Exp = str157;
          string str160 = "";
          int num258 = binaryReader.ReadInt32();
          for (int index = 0; index < num258; ++index)
          {
            byte num259 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str161 = str160;
            ch = Convert.ToChar(num259);
            string str162 = ch.ToString();
            str160 = str161 + str162;
          }
          clsVar.appModes_0.WireBendMode.Mode4Exp = str160;
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
          string str163 = "";
          int num260 = binaryReader.ReadInt32();
          for (int index = 0; index < num260; ++index)
          {
            byte num261 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str164 = str163;
            ch = Convert.ToChar(num261);
            string str165 = ch.ToString();
            str163 = str164 + str165;
          }
          clsVar.appModes_0.LaserRouterDiamekerMode.Mode3 = str163;
          string str166 = "";
          int num262 = binaryReader.ReadInt32();
          for (int index = 0; index < num262; ++index)
          {
            byte num263 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str167 = str166;
            ch = Convert.ToChar(num263);
            string str168 = ch.ToString();
            str166 = str167 + str168;
          }
          clsVar.appModes_0.LaserRouterDiamekerMode.Mode4 = str166;
          string str169 = "";
          int num264 = binaryReader.ReadInt32();
          for (int index = 0; index < num264; ++index)
          {
            byte num265 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str170 = str169;
            ch = Convert.ToChar(num265);
            string str171 = ch.ToString();
            str169 = str170 + str171;
          }
          clsVar.appModes_0.LaserRouterDiamekerMode.Mode1Exp = str169;
          string str172 = "";
          int num266 = binaryReader.ReadInt32();
          for (int index = 0; index < num266; ++index)
          {
            byte num267 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str173 = str172;
            ch = Convert.ToChar(num267);
            string str174 = ch.ToString();
            str172 = str173 + str174;
          }
          clsVar.appModes_0.LaserRouterDiamekerMode.Mode2Exp = str172;
          string str175 = "";
          int num268 = binaryReader.ReadInt32();
          for (int index = 0; index < num268; ++index)
          {
            byte num269 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str176 = str175;
            ch = Convert.ToChar(num269);
            string str177 = ch.ToString();
            str175 = str176 + str177;
          }
          clsVar.appModes_0.LaserRouterDiamekerMode.Mode3Exp = str175;
          string str178 = "";
          int num270 = binaryReader.ReadInt32();
          for (int index = 0; index < num270; ++index)
          {
            byte num271 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str179 = str178;
            ch = Convert.ToChar(num271);
            string str180 = ch.ToString();
            str178 = str179 + str180;
          }
          clsVar.appModes_0.LaserRouterDiamekerMode.Mode4Exp = str178;
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
          string str181 = "";
          int num272 = binaryReader.ReadInt32();
          for (int index = 0; index < num272; ++index)
          {
            byte num273 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str182 = str181;
            ch = Convert.ToChar(num273);
            string str183 = ch.ToString();
            str181 = str182 + str183;
          }
          clsVar.appModes_0.CutterMode.Mode3 = str181;
          string str184 = "";
          int num274 = binaryReader.ReadInt32();
          for (int index = 0; index < num274; ++index)
          {
            byte num275 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str185 = str184;
            ch = Convert.ToChar(num275);
            string str186 = ch.ToString();
            str184 = str185 + str186;
          }
          clsVar.appModes_0.CutterMode.Mode4 = str184;
          string str187 = "";
          int num276 = binaryReader.ReadInt32();
          for (int index = 0; index < num276; ++index)
          {
            byte num277 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str188 = str187;
            ch = Convert.ToChar(num277);
            string str189 = ch.ToString();
            str187 = str188 + str189;
          }
          clsVar.appModes_0.CutterMode.Mode1Exp = str187;
          string str190 = "";
          int num278 = binaryReader.ReadInt32();
          for (int index = 0; index < num278; ++index)
          {
            byte num279 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str191 = str190;
            ch = Convert.ToChar(num279);
            string str192 = ch.ToString();
            str190 = str191 + str192;
          }
          clsVar.appModes_0.CutterMode.Mode2Exp = str190;
          string str193 = "";
          int num280 = binaryReader.ReadInt32();
          for (int index = 0; index < num280; ++index)
          {
            byte num281 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str194 = str193;
            ch = Convert.ToChar(num281);
            string str195 = ch.ToString();
            str193 = str194 + str195;
          }
          clsVar.appModes_0.CutterMode.Mode3Exp = str193;
          string str196 = "";
          int num282 = binaryReader.ReadInt32();
          for (int index = 0; index < num282; ++index)
          {
            byte num283 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str197 = str196;
            ch = Convert.ToChar(num283);
            string str198 = ch.ToString();
            str196 = str197 + str198;
          }
          clsVar.appModes_0.CutterMode.Mode4Exp = str196;
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
          string str199 = "";
          int num284 = binaryReader.ReadInt32();
          for (int index = 0; index < num284; ++index)
          {
            byte num285 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str200 = str199;
            ch = Convert.ToChar(num285);
            string str201 = ch.ToString();
            str199 = str200 + str201;
          }
          clsVar.appModes_0.GlassCutMode.Mode3 = str199;
          string str202 = "";
          int num286 = binaryReader.ReadInt32();
          for (int index = 0; index < num286; ++index)
          {
            byte num287 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str203 = str202;
            ch = Convert.ToChar(num287);
            string str204 = ch.ToString();
            str202 = str203 + str204;
          }
          clsVar.appModes_0.GlassCutMode.Mode4 = str202;
          string str205 = "";
          int num288 = binaryReader.ReadInt32();
          for (int index = 0; index < num288; ++index)
          {
            byte num289 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str206 = str205;
            ch = Convert.ToChar(num289);
            string str207 = ch.ToString();
            str205 = str206 + str207;
          }
          clsVar.appModes_0.GlassCutMode.Mode1Exp = str205;
          string str208 = "";
          int num290 = binaryReader.ReadInt32();
          for (int index = 0; index < num290; ++index)
          {
            byte num291 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str209 = str208;
            ch = Convert.ToChar(num291);
            string str210 = ch.ToString();
            str208 = str209 + str210;
          }
          clsVar.appModes_0.GlassCutMode.Mode2Exp = str208;
          string str211 = "";
          int num292 = binaryReader.ReadInt32();
          for (int index = 0; index < num292; ++index)
          {
            byte num293 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str212 = str211;
            ch = Convert.ToChar(num293);
            string str213 = ch.ToString();
            str211 = str212 + str213;
          }
          clsVar.appModes_0.GlassCutMode.Mode3Exp = str211;
          string str214 = "";
          int num294 = binaryReader.ReadInt32();
          for (int index = 0; index < num294; ++index)
          {
            byte num295 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str215 = str214;
            ch = Convert.ToChar(num295);
            string str216 = ch.ToString();
            str214 = str215 + str216;
          }
          clsVar.appModes_0.GlassCutMode.Mode4Exp = str214;
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
          string str217 = "";
          int num296 = binaryReader.ReadInt32();
          for (int index = 0; index < num296; ++index)
          {
            byte num297 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str218 = str217;
            ch = Convert.ToChar(num297);
            string str219 = ch.ToString();
            str217 = str218 + str219;
          }
          clsVar.appModes_0.LeatherMode.Mode3 = str217;
          string str220 = "";
          int num298 = binaryReader.ReadInt32();
          for (int index = 0; index < num298; ++index)
          {
            byte num299 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str221 = str220;
            ch = Convert.ToChar(num299);
            string str222 = ch.ToString();
            str220 = str221 + str222;
          }
          clsVar.appModes_0.LeatherMode.Mode4 = str220;
          string str223 = "";
          int num300 = binaryReader.ReadInt32();
          for (int index = 0; index < num300; ++index)
          {
            byte num301 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str224 = str223;
            ch = Convert.ToChar(num301);
            string str225 = ch.ToString();
            str223 = str224 + str225;
          }
          clsVar.appModes_0.LeatherMode.Mode1Exp = str223;
          string str226 = "";
          int num302 = binaryReader.ReadInt32();
          for (int index = 0; index < num302; ++index)
          {
            byte num303 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str227 = str226;
            ch = Convert.ToChar(num303);
            string str228 = ch.ToString();
            str226 = str227 + str228;
          }
          clsVar.appModes_0.LeatherMode.Mode2Exp = str226;
          string str229 = "";
          int num304 = binaryReader.ReadInt32();
          for (int index = 0; index < num304; ++index)
          {
            byte num305 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str230 = str229;
            ch = Convert.ToChar(num305);
            string str231 = ch.ToString();
            str229 = str230 + str231;
          }
          clsVar.appModes_0.LeatherMode.Mode3Exp = str229;
          string str232 = "";
          int num306 = binaryReader.ReadInt32();
          for (int index = 0; index < num306; ++index)
          {
            byte num307 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str233 = str232;
            ch = Convert.ToChar(num307);
            string str234 = ch.ToString();
            str232 = str233 + str234;
          }
          clsVar.appModes_0.LeatherMode.Mode4Exp = str232;
          clsVar.appDefination.IntroAppNameLeft = (int) (binaryReader.ReadDouble() / 51.0);
          clsVar.appDefination.IntroAppNameTop = (int) (binaryReader.ReadDouble() / 52.0);
          clsVar.appDefination.IntroAppNameWidth = (int) (binaryReader.ReadDouble() / 53.0);
          clsVar.appDefination.IntroAppNameColor = (int) (binaryReader.ReadDouble() / 54.0);
          clsVar.appDefination.IntroAppNameFont = (int) (binaryReader.ReadDouble() / 55.0);
          clsVar.appDefination.IntroAppNameVisible = binaryReader.ReadBoolean();
          clsVar.appDefination.IntroVersionLeft = (int) (binaryReader.ReadDouble() / 61.0);
          clsVar.appDefination.IntroVersionTop = (int) (binaryReader.ReadDouble() / 62.0);
          clsVar.appDefination.IntroVerisonWidth = (int) (binaryReader.ReadDouble() / 63.0);
          clsVar.appDefination.IntroVersionColor = (int) (binaryReader.ReadDouble() / 64.0);
          clsVar.appDefination.IntroVersionFont = (int) (binaryReader.ReadDouble() / 65.0);
          clsVar.appDefination.IntroVersionVisible = binaryReader.ReadBoolean();
          clsVar.appDefination.IntroWebLeft = (int) (binaryReader.ReadDouble() / 71.0);
          clsVar.appDefination.IntroWebTop = (int) (binaryReader.ReadDouble() / 72.0);
          clsVar.appDefination.IntroWebWidth = (int) (binaryReader.ReadDouble() / 73.0);
          clsVar.appDefination.IntroWebColor = (int) (binaryReader.ReadDouble() / 74.0);
          clsVar.appDefination.IntroWebFont = (int) (binaryReader.ReadDouble() / 75.0);
          clsVar.appDefination.IntroWebVisible = binaryReader.ReadBoolean();
          clsVar.appDefination.IntroVendorLeft = (int) (binaryReader.ReadDouble() / 81.0);
          clsVar.appDefination.IntroVendorTop = (int) (binaryReader.ReadDouble() / 82.0);
          clsVar.appDefination.IntroVendorWidth = (int) (binaryReader.ReadDouble() / 83.0);
          clsVar.appDefination.IntroVendorColor = (int) (binaryReader.ReadDouble() / 84.0);
          clsVar.appDefination.IntroVendorFont = (int) (binaryReader.ReadDouble() / 85.0);
          clsVar.appDefination.IntroVendorVisible = binaryReader.ReadBoolean();
          clsVar.appDefination.IntroAuxLeft = (int) (binaryReader.ReadDouble() / 91.0);
          clsVar.appDefination.IntroAuxTop = (int) (binaryReader.ReadDouble() / 92.0);
          clsVar.appDefination.IntroAuxWidth = (int) (binaryReader.ReadDouble() / 93.0);
          clsVar.appDefination.IntroAuxColor = (int) (binaryReader.ReadDouble() / 94.0);
          clsVar.appDefination.IntroAuxFont = (int) (binaryReader.ReadDouble() / 95.0);
          clsVar.appDefination.IntroAuxVisible = binaryReader.ReadBoolean();
          clsVar.appDefination.IntroOther1Left = (int) (binaryReader.ReadDouble() / 101.0);
          clsVar.appDefination.IntroOther1Top = (int) (binaryReader.ReadDouble() / 102.0);
          clsVar.appDefination.IntroOther1Width = (int) (binaryReader.ReadDouble() / 103.0);
          clsVar.appDefination.IntroOther1Color = (int) (binaryReader.ReadDouble() / 104.0);
          clsVar.appDefination.IntroOther1Font = (int) (binaryReader.ReadDouble() / 105.0);
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
          string str235 = "";
          int num308 = binaryReader.ReadInt32();
          for (int index = 0; index < num308; ++index)
          {
            byte num309 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str236 = str235;
            ch = Convert.ToChar(num309);
            string str237 = ch.ToString();
            str235 = str236 + str237;
          }
          clsVar.appModes_0.QuiltingMode.Mode3 = str235;
          string str238 = "";
          int num310 = binaryReader.ReadInt32();
          for (int index = 0; index < num310; ++index)
          {
            byte num311 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str239 = str238;
            ch = Convert.ToChar(num311);
            string str240 = ch.ToString();
            str238 = str239 + str240;
          }
          clsVar.appModes_0.QuiltingMode.Mode4 = str238;
          string str241 = "";
          int num312 = binaryReader.ReadInt32();
          for (int index = 0; index < num312; ++index)
          {
            byte num313 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str242 = str241;
            ch = Convert.ToChar(num313);
            string str243 = ch.ToString();
            str241 = str242 + str243;
          }
          clsVar.appModes_0.QuiltingMode.Mode1Exp = str241;
          string str244 = "";
          int num314 = binaryReader.ReadInt32();
          for (int index = 0; index < num314; ++index)
          {
            byte num315 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str245 = str244;
            ch = Convert.ToChar(num315);
            string str246 = ch.ToString();
            str244 = str245 + str246;
          }
          clsVar.appModes_0.QuiltingMode.Mode2Exp = str244;
          string str247 = "";
          int num316 = binaryReader.ReadInt32();
          for (int index = 0; index < num316; ++index)
          {
            byte num317 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str248 = str247;
            ch = Convert.ToChar(num317);
            string str249 = ch.ToString();
            str247 = str248 + str249;
          }
          clsVar.appModes_0.QuiltingMode.Mode3Exp = str247;
          string str250 = "";
          int num318 = binaryReader.ReadInt32();
          for (int index = 0; index < num318; ++index)
          {
            byte num319 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str251 = str250;
            ch = Convert.ToChar(num319);
            string str252 = ch.ToString();
            str250 = str251 + str252;
          }
          clsVar.appModes_0.QuiltingMode.Mode4Exp = str250;
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
          string str253 = "";
          int num320 = binaryReader.ReadInt32();
          for (int index = 0; index < num320; ++index)
          {
            byte num321 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str254 = str253;
            ch = Convert.ToChar(num321);
            string str255 = ch.ToString();
            str253 = str254 + str255;
          }
          clsVar.appModes_0.MarbleMode.Mode3 = str253;
          string str256 = "";
          int num322 = binaryReader.ReadInt32();
          for (int index = 0; index < num322; ++index)
          {
            byte num323 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str257 = str256;
            ch = Convert.ToChar(num323);
            string str258 = ch.ToString();
            str256 = str257 + str258;
          }
          clsVar.appModes_0.MarbleMode.Mode4 = str256;
          string str259 = "";
          int num324 = binaryReader.ReadInt32();
          for (int index = 0; index < num324; ++index)
          {
            byte num325 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str260 = str259;
            ch = Convert.ToChar(num325);
            string str261 = ch.ToString();
            str259 = str260 + str261;
          }
          clsVar.appModes_0.MarbleMode.Mode1Exp = str259;
          string str262 = "";
          int num326 = binaryReader.ReadInt32();
          for (int index = 0; index < num326; ++index)
          {
            byte num327 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str263 = str262;
            ch = Convert.ToChar(num327);
            string str264 = ch.ToString();
            str262 = str263 + str264;
          }
          clsVar.appModes_0.MarbleMode.Mode2Exp = str262;
          string str265 = "";
          int num328 = binaryReader.ReadInt32();
          for (int index = 0; index < num328; ++index)
          {
            byte num329 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str266 = str265;
            ch = Convert.ToChar(num329);
            string str267 = ch.ToString();
            str265 = str266 + str267;
          }
          clsVar.appModes_0.MarbleMode.Mode3Exp = str265;
          string str268 = "";
          int num330 = binaryReader.ReadInt32();
          for (int index = 0; index < num330; ++index)
          {
            byte num331 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str269 = str268;
            ch = Convert.ToChar(num331);
            string str270 = ch.ToString();
            str268 = str269 + str270;
          }
          clsVar.appModes_0.MarbleMode.Mode4Exp = str268;
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
          string str271 = "";
          int num332 = binaryReader.ReadInt32();
          for (int index = 0; index < num332; ++index)
          {
            byte num333 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str272 = str271;
            ch = Convert.ToChar(num333);
            string str273 = ch.ToString();
            str271 = str272 + str273;
          }
          clsVar.appModes_0.DrillMode.Mode3 = str271;
          string str274 = "";
          int num334 = binaryReader.ReadInt32();
          for (int index = 0; index < num334; ++index)
          {
            byte num335 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str275 = str274;
            ch = Convert.ToChar(num335);
            string str276 = ch.ToString();
            str274 = str275 + str276;
          }
          clsVar.appModes_0.DrillMode.Mode4 = str274;
          string str277 = "";
          int num336 = binaryReader.ReadInt32();
          for (int index = 0; index < num336; ++index)
          {
            byte num337 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str278 = str277;
            ch = Convert.ToChar(num337);
            string str279 = ch.ToString();
            str277 = str278 + str279;
          }
          clsVar.appModes_0.DrillMode.Mode1Exp = str277;
          string str280 = "";
          int num338 = binaryReader.ReadInt32();
          for (int index = 0; index < num338; ++index)
          {
            byte num339 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str281 = str280;
            ch = Convert.ToChar(num339);
            string str282 = ch.ToString();
            str280 = str281 + str282;
          }
          clsVar.appModes_0.DrillMode.Mode2Exp = str280;
          string str283 = "";
          int num340 = binaryReader.ReadInt32();
          for (int index = 0; index < num340; ++index)
          {
            byte num341 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str284 = str283;
            ch = Convert.ToChar(num341);
            string str285 = ch.ToString();
            str283 = str284 + str285;
          }
          clsVar.appModes_0.DrillMode.Mode3Exp = str283;
          string str286 = "";
          int num342 = binaryReader.ReadInt32();
          for (int index = 0; index < num342; ++index)
          {
            byte num343 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str287 = str286;
            ch = Convert.ToChar(num343);
            string str288 = ch.ToString();
            str286 = str287 + str288;
          }
          clsVar.appModes_0.DrillMode.Mode4Exp = str286;
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
          string str289 = "";
          int num344 = binaryReader.ReadInt32();
          for (int index = 0; index < num344; ++index)
          {
            byte num345 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str290 = str289;
            ch = Convert.ToChar(num345);
            string str291 = ch.ToString();
            str289 = str290 + str291;
          }
          clsVar.appModes_0.FlexoMode.Mode3 = str289;
          string str292 = "";
          int num346 = binaryReader.ReadInt32();
          for (int index = 0; index < num346; ++index)
          {
            byte num347 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str293 = str292;
            ch = Convert.ToChar(num347);
            string str294 = ch.ToString();
            str292 = str293 + str294;
          }
          clsVar.appModes_0.FlexoMode.Mode4 = str292;
          string str295 = "";
          int num348 = binaryReader.ReadInt32();
          for (int index = 0; index < num348; ++index)
          {
            byte num349 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str296 = str295;
            ch = Convert.ToChar(num349);
            string str297 = ch.ToString();
            str295 = str296 + str297;
          }
          clsVar.appModes_0.FlexoMode.Mode1Exp = str295;
          string str298 = "";
          int num350 = binaryReader.ReadInt32();
          for (int index = 0; index < num350; ++index)
          {
            byte num351 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str299 = str298;
            ch = Convert.ToChar(num351);
            string str300 = ch.ToString();
            str298 = str299 + str300;
          }
          clsVar.appModes_0.FlexoMode.Mode2Exp = str298;
          string str301 = "";
          int num352 = binaryReader.ReadInt32();
          for (int index = 0; index < num352; ++index)
          {
            byte num353 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str302 = str301;
            ch = Convert.ToChar(num353);
            string str303 = ch.ToString();
            str301 = str302 + str303;
          }
          clsVar.appModes_0.FlexoMode.Mode3Exp = str301;
          string str304 = "";
          int num354 = binaryReader.ReadInt32();
          for (int index = 0; index < num354; ++index)
          {
            byte num355 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str305 = str304;
            ch = Convert.ToChar(num355);
            string str306 = ch.ToString();
            str304 = str305 + str306;
          }
          clsVar.appModes_0.FlexoMode.Mode4Exp = str304;
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
          string str307 = "";
          int num356 = binaryReader.ReadInt32();
          for (int index = 0; index < num356; ++index)
          {
            byte num357 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str308 = str307;
            ch = Convert.ToChar(num357);
            string str309 = ch.ToString();
            str307 = str308 + str309;
          }
          clsVar.appModes_0.SewingMode.Mode3 = str307;
          string str310 = "";
          int num358 = binaryReader.ReadInt32();
          for (int index = 0; index < num358; ++index)
          {
            byte num359 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str311 = str310;
            ch = Convert.ToChar(num359);
            string str312 = ch.ToString();
            str310 = str311 + str312;
          }
          clsVar.appModes_0.SewingMode.Mode4 = str310;
          string str313 = "";
          int num360 = binaryReader.ReadInt32();
          for (int index = 0; index < num360; ++index)
          {
            byte num361 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str314 = str313;
            ch = Convert.ToChar(num361);
            string str315 = ch.ToString();
            str313 = str314 + str315;
          }
          clsVar.appModes_0.SewingMode.Mode1Exp = str313;
          string str316 = "";
          int num362 = binaryReader.ReadInt32();
          for (int index = 0; index < num362; ++index)
          {
            byte num363 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str317 = str316;
            ch = Convert.ToChar(num363);
            string str318 = ch.ToString();
            str316 = str317 + str318;
          }
          clsVar.appModes_0.SewingMode.Mode2Exp = str316;
          string str319 = "";
          int num364 = binaryReader.ReadInt32();
          for (int index = 0; index < num364; ++index)
          {
            byte num365 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str320 = str319;
            ch = Convert.ToChar(num365);
            string str321 = ch.ToString();
            str319 = str320 + str321;
          }
          clsVar.appModes_0.SewingMode.Mode3Exp = str319;
          string str322 = "";
          int num366 = binaryReader.ReadInt32();
          for (int index = 0; index < num366; ++index)
          {
            byte num367 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str323 = str322;
            ch = Convert.ToChar(num367);
            string str324 = ch.ToString();
            str322 = str323 + str324;
          }
          clsVar.appModes_0.SewingMode.Mode4Exp = str322;
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
          string str325 = "";
          int num368 = binaryReader.ReadInt32();
          for (int index = 0; index < num368; ++index)
          {
            byte num369 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str326 = str325;
            ch = Convert.ToChar(num369);
            string str327 = ch.ToString();
            str325 = str326 + str327;
          }
          clsVar.appModes_0.FoamCuttingMode.Mode3 = str325;
          string str328 = "";
          int num370 = binaryReader.ReadInt32();
          for (int index = 0; index < num370; ++index)
          {
            byte num371 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str329 = str328;
            ch = Convert.ToChar(num371);
            string str330 = ch.ToString();
            str328 = str329 + str330;
          }
          clsVar.appModes_0.FoamCuttingMode.Mode4 = str328;
          string str331 = "";
          int num372 = binaryReader.ReadInt32();
          for (int index = 0; index < num372; ++index)
          {
            byte num373 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str332 = str331;
            ch = Convert.ToChar(num373);
            string str333 = ch.ToString();
            str331 = str332 + str333;
          }
          clsVar.appModes_0.FoamCuttingMode.Mode1Exp = str331;
          string str334 = "";
          int num374 = binaryReader.ReadInt32();
          for (int index = 0; index < num374; ++index)
          {
            byte num375 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str335 = str334;
            ch = Convert.ToChar(num375);
            string str336 = ch.ToString();
            str334 = str335 + str336;
          }
          clsVar.appModes_0.FoamCuttingMode.Mode2Exp = str334;
          string str337 = "";
          int num376 = binaryReader.ReadInt32();
          for (int index = 0; index < num376; ++index)
          {
            byte num377 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str338 = str337;
            ch = Convert.ToChar(num377);
            string str339 = ch.ToString();
            str337 = str338 + str339;
          }
          clsVar.appModes_0.FoamCuttingMode.Mode3Exp = str337;
          string str340 = "";
          int num378 = binaryReader.ReadInt32();
          for (int index = 0; index < num378; ++index)
          {
            byte num379 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str341 = str340;
            ch = Convert.ToChar(num379);
            string str342 = ch.ToString();
            str340 = str341 + str342;
          }
          clsVar.appModes_0.FoamCuttingMode.Mode4Exp = str340;
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
          string str343 = "";
          int num380 = binaryReader.ReadInt32();
          for (int index = 0; index < num380; ++index)
          {
            byte num381 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str344 = str343;
            ch = Convert.ToChar(num381);
            string str345 = ch.ToString();
            str343 = str344 + str345;
          }
          clsVar.appModes_0.Printer3DMode.Mode3 = str343;
          string str346 = "";
          int num382 = binaryReader.ReadInt32();
          for (int index = 0; index < num382; ++index)
          {
            byte num383 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str347 = str346;
            ch = Convert.ToChar(num383);
            string str348 = ch.ToString();
            str346 = str347 + str348;
          }
          clsVar.appModes_0.Printer3DMode.Mode4 = str346;
          string str349 = "";
          int num384 = binaryReader.ReadInt32();
          for (int index = 0; index < num384; ++index)
          {
            byte num385 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str350 = str349;
            ch = Convert.ToChar(num385);
            string str351 = ch.ToString();
            str349 = str350 + str351;
          }
          clsVar.appModes_0.Printer3DMode.Mode1Exp = str349;
          string str352 = "";
          int num386 = binaryReader.ReadInt32();
          for (int index = 0; index < num386; ++index)
          {
            byte num387 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str353 = str352;
            ch = Convert.ToChar(num387);
            string str354 = ch.ToString();
            str352 = str353 + str354;
          }
          clsVar.appModes_0.Printer3DMode.Mode2Exp = str352;
          string str355 = "";
          int num388 = binaryReader.ReadInt32();
          for (int index = 0; index < num388; ++index)
          {
            byte num389 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str356 = str355;
            ch = Convert.ToChar(num389);
            string str357 = ch.ToString();
            str355 = str356 + str357;
          }
          clsVar.appModes_0.Printer3DMode.Mode3Exp = str355;
          string str358 = "";
          int num390 = binaryReader.ReadInt32();
          for (int index = 0; index < num390; ++index)
          {
            byte num391 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str359 = str358;
            ch = Convert.ToChar(num391);
            string str360 = ch.ToString();
            str358 = str359 + str360;
          }
          clsVar.appModes_0.Printer3DMode.Mode4Exp = str358;
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
          string str361 = "";
          int num392 = binaryReader.ReadInt32();
          for (int index = 0; index < num392; ++index)
          {
            byte num393 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str362 = str361;
            ch = Convert.ToChar(num393);
            string str363 = ch.ToString();
            str361 = str362 + str363;
          }
          clsVar.appModes_0.DoorMode.Mode3 = str361;
          string str364 = "";
          int num394 = binaryReader.ReadInt32();
          for (int index = 0; index < num394; ++index)
          {
            byte num395 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str365 = str364;
            ch = Convert.ToChar(num395);
            string str366 = ch.ToString();
            str364 = str365 + str366;
          }
          clsVar.appModes_0.DoorMode.Mode4 = str364;
          string str367 = "";
          int num396 = binaryReader.ReadInt32();
          for (int index = 0; index < num396; ++index)
          {
            byte num397 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str368 = str367;
            ch = Convert.ToChar(num397);
            string str369 = ch.ToString();
            str367 = str368 + str369;
          }
          clsVar.appModes_0.DoorMode.Mode1Exp = str367;
          string str370 = "";
          int num398 = binaryReader.ReadInt32();
          for (int index = 0; index < num398; ++index)
          {
            byte num399 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str371 = str370;
            ch = Convert.ToChar(num399);
            string str372 = ch.ToString();
            str370 = str371 + str372;
          }
          clsVar.appModes_0.DoorMode.Mode2Exp = str370;
          string str373 = "";
          int num400 = binaryReader.ReadInt32();
          for (int index = 0; index < num400; ++index)
          {
            byte num401 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str374 = str373;
            ch = Convert.ToChar(num401);
            string str375 = ch.ToString();
            str373 = str374 + str375;
          }
          clsVar.appModes_0.DoorMode.Mode3Exp = str373;
          string str376 = "";
          int num402 = binaryReader.ReadInt32();
          for (int index = 0; index < num402; ++index)
          {
            byte num403 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str377 = str376;
            ch = Convert.ToChar(num403);
            string str378 = ch.ToString();
            str376 = str377 + str378;
          }
          clsVar.appModes_0.DoorMode.Mode4Exp = str376;
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
          string str379 = "";
          int num404 = binaryReader.ReadInt32();
          for (int index = 0; index < num404; ++index)
          {
            byte num405 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str380 = str379;
            ch = Convert.ToChar(num405);
            string str381 = ch.ToString();
            str379 = str380 + str381;
          }
          clsVar.appModes_0.RollerBendMode.Mode3 = str379;
          string str382 = "";
          int num406 = binaryReader.ReadInt32();
          for (int index = 0; index < num406; ++index)
          {
            byte num407 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str383 = str382;
            ch = Convert.ToChar(num407);
            string str384 = ch.ToString();
            str382 = str383 + str384;
          }
          clsVar.appModes_0.RollerBendMode.Mode4 = str382;
          string str385 = "";
          int num408 = binaryReader.ReadInt32();
          for (int index = 0; index < num408; ++index)
          {
            byte num409 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str386 = str385;
            ch = Convert.ToChar(num409);
            string str387 = ch.ToString();
            str385 = str386 + str387;
          }
          clsVar.appModes_0.RollerBendMode.Mode1Exp = str385;
          string str388 = "";
          int num410 = binaryReader.ReadInt32();
          for (int index = 0; index < num410; ++index)
          {
            byte num411 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str389 = str388;
            ch = Convert.ToChar(num411);
            string str390 = ch.ToString();
            str388 = str389 + str390;
          }
          clsVar.appModes_0.RollerBendMode.Mode2Exp = str388;
          string str391 = "";
          int num412 = binaryReader.ReadInt32();
          for (int index = 0; index < num412; ++index)
          {
            byte num413 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str392 = str391;
            ch = Convert.ToChar(num413);
            string str393 = ch.ToString();
            str391 = str392 + str393;
          }
          clsVar.appModes_0.RollerBendMode.Mode3Exp = str391;
          string str394 = "";
          int num414 = binaryReader.ReadInt32();
          for (int index = 0; index < num414; ++index)
          {
            byte num415 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str395 = str394;
            ch = Convert.ToChar(num415);
            string str396 = ch.ToString();
            str394 = str395 + str396;
          }
          clsVar.appModes_0.RollerBendMode.Mode4Exp = str394;
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
          string str397 = "";
          int num416 = binaryReader.ReadInt32();
          for (int index = 0; index < num416; ++index)
          {
            byte num417 = Convert.ToByte(binaryReader.ReadDouble() / 32.875);
            string str398 = str397;
            ch = Convert.ToChar(num417);
            string str399 = ch.ToString();
            str397 = str398 + str399;
          }
          clsVar.appModes_0.ToolGrindingMode.Mode3 = str397;
          string str400 = "";
          int num418 = binaryReader.ReadInt32();
          for (int index = 0; index < num418; ++index)
          {
            byte num419 = Convert.ToByte(binaryReader.ReadDouble() / 25.654);
            string str401 = str400;
            ch = Convert.ToChar(num419);
            string str402 = ch.ToString();
            str400 = str401 + str402;
          }
          clsVar.appModes_0.ToolGrindingMode.Mode4 = str400;
          string str403 = "";
          int num420 = binaryReader.ReadInt32();
          for (int index = 0; index < num420; ++index)
          {
            byte num421 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str404 = str403;
            ch = Convert.ToChar(num421);
            string str405 = ch.ToString();
            str403 = str404 + str405;
          }
          clsVar.appModes_0.ToolGrindingMode.Mode1Exp = str403;
          string str406 = "";
          int num422 = binaryReader.ReadInt32();
          for (int index = 0; index < num422; ++index)
          {
            byte num423 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str407 = str406;
            ch = Convert.ToChar(num423);
            string str408 = ch.ToString();
            str406 = str407 + str408;
          }
          clsVar.appModes_0.ToolGrindingMode.Mode2Exp = str406;
          string str409 = "";
          int num424 = binaryReader.ReadInt32();
          for (int index = 0; index < num424; ++index)
          {
            byte num425 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str410 = str409;
            ch = Convert.ToChar(num425);
            string str411 = ch.ToString();
            str409 = str410 + str411;
          }
          clsVar.appModes_0.ToolGrindingMode.Mode3Exp = str409;
          string str412 = "";
          int num426 = binaryReader.ReadInt32();
          for (int index = 0; index < num426; ++index)
          {
            byte num427 = Convert.ToByte(binaryReader.ReadDouble() / 12.456);
            string str413 = str412;
            ch = Convert.ToChar(num427);
            string str414 = ch.ToString();
            str412 = str413 + str414;
          }
          clsVar.appModes_0.ToolGrindingMode.Mode4Exp = str412;
          binaryReader.Close();
          buLogVer5.addToLog("DefK", "Mode 1002", "mnb", "100", 0.0, 0.0);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
          binaryReader.Close();
        }
        if (new FileInfo(AppPath.Base + "\\buhardkey.dll").Exists)
        {
          buLogVer5.addToLog("DefK", "Mode 1003", "HK", "True", 0.0, 0.0);
          clsVar.appModes_0.HardKeyCmdEnable = true;
        }
        bool bdevfile;
        if (bdevfile = clsFiles.ReadDevFile())
        {
          buLogVer5.addToLog("DefK", "Mode 1004", "Dev", "True", 0.0, 0.0);
          AppSecurity.PasswordLevel = 10;
          clsVar.appModes_0.DeveloperMode = true;
        }
        if (clsFiles.ReadDevFileFull())
        {
          bdevfile = true;
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
        bool flag2 = false;
        if (clsVar.appModes_0.HardKeyCmdEnable)
        {
          buLogVer5.addToLog("DefK", "Mode 1008", "HW", "Done", 0.0, 0.0);
          bool flag3 = clsInit.appSystem.ReadHK(bdevfile);
          buLogVer5.addToLog("DefK", "Mode 1009", "HK", "Done", 0.0, 0.0);
          clsVar.bool_0 = flag3;
          clsVar.appModes_0.isCMDDongleAvailable = flag3;
          if (clsVar.appModes_0.NestingMode.Enable)
          {
            clsInit.appNesting = new clsNesting();
            clsInit.appNesting.Init();
          }
          buLogVer5.addToLog("DefK", "Mode 1011", "HKCMD", "True", 0.0, 0.0);
          flag1 = true;
        }
        else
        {
          if (clsVar.appModes_0.NestingMode.Enable)
          {
            if (clsVar.appModes_0.HardKeyPowerNestEnable & !clsVar.appModes_0.isPowerNestDongleInited)
            {
              clsInit.appNesting = new clsNesting();
              buLogVer5.addToLog("DefK", "Mode 1012", "HKPwr", "Init", 0.0, 0.0);
              clsInit.appNesting.Init();
              buLogVer5.addToLog("DefK", "Mode 1013", "HKPwr", "Done", 0.0, 0.0);
              clsVar.bool_0 = true;
              clsVar.appModes_0.isPowerNestDongleAvailable = true;
              clsVar.appModes_0.isPowerNestDongleInited = true;
              buLogVer5.addToLog("DefK", "Mode 1015", "HKPwr", "True", 0.0, 0.0);
              return true;
            }
            if (clsVar.appModes_0.HardKeyPowerNestEnable & clsVar.appModes_0.isPowerNestDongleInited & clsVar.appModes_0.isPowerNestDongleAvailable)
              return true;
          }
          else
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
            if (MacAddress.Count > 0 & CpuAddress.Count > 0)
            {
              for (int index4 = 0; index4 <= MacAddress.Count - 1; ++index4)
              {
                double num428 = 0.0;
                double num429 = 0.0;
                double num430 = 0.0;
                for (int startIndex = 0; startIndex <= MacAddress[index4].Length - 1; ++startIndex)
                {
                  double num431 = (double) Convert.ToByte(Convert.ToChar(MacAddress[index4].Substring(startIndex, 1)));
                  num428 += num431 * 17.92;
                }
                for (int startIndex = 0; startIndex <= CpuAddress[0].Length - 1; ++startIndex)
                {
                  double num432 = (double) Convert.ToByte(Convert.ToChar(CpuAddress[0].Substring(startIndex, 1)));
                  num429 += num432 * 47.93;
                }
                for (int startIndex = 0; startIndex <= MBAddress.Length - 1; ++startIndex)
                {
                  double num433 = (double) Convert.ToByte(Convert.ToChar(MBAddress.Substring(startIndex, 1)));
                  num430 += num433 * 51.95;
                }
                double num434 = (num428 + num429 + num430) * 9.912;
                for (int index5 = 0; index5 <= doubleList.Count - 1; ++index5)
                {
                  if (Math.Abs(doubleList[index5] - num434) < 0.0001)
                  {
                    clsVar.appDefination.ProgramCode = num434.ToString();
                    flag2 = true;
                  }
                }
              }
              if (!flag2)
                flag2 = clsInit.appSystem.ReadHK(bdevfile);
              buLogVer5.addToLog("DefK", "Mode 1018", "SWK", "True", 0.0, 0.0);
              clsVar.bool_0 = true;
              if (flag2)
              {
                clsInit.appNesting = new clsNesting();
                clsInit.appNesting.Init();
              }
              return flag2;
            }
          }
          buLogVer5.addToLog("DefK", "Mode 1020", "L", "True", 0.0, 0.0);
          flag1 = false;
        }
      }
      else
      {
        buLogVer5.addToLog("DefK", "Mode 1019", "SWK", "Fail", 0.0, 0.0);
        buString.MessageBoxError("Configration File is Missing");
        Environment.Exit(0);
        flag1 = false;
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog("DefK", "Mode 1030", "L", "Exception", 0.0, 0.0);
      string name = MethodBase.GetCurrentMethod().Name;
      buException.throwException(ex, name, true, "Program Init Failure");
      int num = (int) MessageBox.Show("Program Init Failure ");
      flag1 = false;
    }
    return flag1;
  }

  public static string HC(List<string> M, List<string> C, string mb)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    if (M.Count > 0 & C.Count > 0)
    {
      for (int startIndex = 0; startIndex <= M[0].Length - 1; ++startIndex)
      {
        double num4 = (double) Convert.ToByte(Convert.ToChar(M[0].Substring(startIndex, 1)));
        num1 += num4 * 17.92;
      }
      for (int startIndex = 0; startIndex <= C[0].Length - 1; ++startIndex)
      {
        double num5 = (double) Convert.ToByte(Convert.ToChar(C[0].Substring(startIndex, 1)));
        num2 += num5 * 47.93;
      }
      for (int startIndex = 0; startIndex <= mb.Length - 1; ++startIndex)
      {
        double num6 = (double) Convert.ToByte(Convert.ToChar(mb.Substring(startIndex, 1)));
        num3 += num6 * 51.95;
      }
    }
    return ((num1 + num2 + num3) * 9.912).ToString();
  }

  public static void OpenMacroFile(string FileName)
  {
    try
    {
      FileInfo fileInfo = new FileInfo(FileName);
      if (!fileInfo.Exists)
        return;
      List<string> StringList = new List<string>();
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      List<string> CalcList1 = new List<string>();
      buFile.OpenFromFile(fileInfo.FullName, ref StringList);
      buString.ListToSpecificList("<NewPage>", "</NewPage>", false, StringList, ref CalcList1);
      if (CalcList1.Count > 0)
        clsVar.macroNewPage.Clear();
      for (int index = 0; index <= CalcList1.Count - 1; ++index)
      {
        MacroBase macroBase1 = new MacroBase();
        MacroBase macroBase2 = buGeneral.DecodeMacro(CalcList1[index].ToString());
        clsVar.macroNewPage.Add(macroBase2);
      }
      List<string> stringList3 = new List<string>();
      List<string> CalcList2 = new List<string>();
      buString.ListToSpecificList("<StartUp>", "</StartUp>", false, StringList, ref CalcList2);
      if (CalcList2.Count > 0)
        clsVar.macroStartUp.Clear();
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        MacroBase macroBase3 = new MacroBase();
        MacroBase macroBase4 = buGeneral.DecodeMacro(CalcList2[index].ToString());
        clsVar.macroStartUp.Add(macroBase4);
      }
      List<string> stringList4 = new List<string>();
      CalcList2 = new List<string>();
      buString.ListToSpecificList("<Init>", "</Init>", false, StringList, ref CalcList2);
      if (CalcList2.Count > 0)
        clsVar.macroInit.Clear();
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        MacroBase macroBase5 = new MacroBase();
        MacroBase macroBase6 = buGeneral.DecodeMacro(CalcList2[index].ToString());
        clsVar.macroInit.Add(macroBase6);
      }
      List<string> stringList5 = new List<string>();
      CalcList2 = new List<string>();
      buString.ListToSpecificList("<OpenFile>", "</OpenFile>", false, StringList, ref CalcList2);
      if (CalcList2.Count > 0)
        clsVar.macroOpen.Clear();
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        MacroBase macroBase7 = new MacroBase();
        MacroBase macroBase8 = buGeneral.DecodeMacro(CalcList2[index].ToString());
        clsVar.macroOpen.Add(macroBase8);
      }
      List<string> stringList6 = new List<string>();
      CalcList2 = new List<string>();
      buString.ListToSpecificList("<ImportFile>", "</ImportFile>", false, StringList, ref CalcList2);
      if (CalcList2.Count > 0)
        clsVar.macroImport.Clear();
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        MacroBase macroBase9 = new MacroBase();
        MacroBase macroBase10 = buGeneral.DecodeMacro(CalcList2[index].ToString());
        clsVar.macroImport.Add(macroBase10);
      }
      buLog.addLog("Macro File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      string str = FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenShortKeyFile(string FileName)
  {
    try
    {
      FileInfo fileInfo = new FileInfo(FileName);
      if (!fileInfo.Exists)
        return;
      List<string> StringList = new List<string>();
      buFile.OpenFromFile(fileInfo.FullName, ref StringList);
      for (int index = 0; index <= StringList.Count - 1; ++index)
      {
        ShortCutKey shortCutKey1 = new ShortCutKey();
        ShortCutKey shortCutKey2 = buGeneral.DecodeShortKey(StringList[index]);
        if (shortCutKey2.Command.Length > 0 & shortCutKey2.Key.ToString().Length > 0 & shortCutKey2.Key != ActionKeys.KeyNone)
          clsVar.ShortKeyList.Add(shortCutKey2);
      }
      buLog.addLog("ShortCut File Opened", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      string str = FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static Image OpenIntroImage(string Path)
  {
    Image image = (Image) null;
    FileInfo fileInfo1 = new FileInfo(Path + "\\Intro.jpg");
    if (fileInfo1.Exists)
    {
      image = Image.FromFile(fileInfo1.FullName);
    }
    else
    {
      FileInfo fileInfo2 = new FileInfo(Path + "\\Intro.png");
      if (fileInfo2.Exists)
      {
        image = Image.FromFile(fileInfo2.FullName);
      }
      else
      {
        FileInfo fileInfo3 = new FileInfo(Path + "\\Intro.gif");
        if (fileInfo3.Exists)
          image = Image.FromFile(fileInfo3.FullName);
      }
    }
    if (image == null)
    {
      buLogVer5.addToLog("clsFile", nameof (OpenIntroImage), "Intro Image Load", "Fail", -1.0, 0.0);
      buString.MessageBoxError("Intro Image File Missing");
    }
    return image;
  }

  public static Image OpenCompanyImage(string Path)
  {
    Image image = (Image) null;
    FileInfo fileInfo1 = new FileInfo(Path + "\\Company.jpg");
    if (fileInfo1.Exists)
    {
      image = Image.FromFile(fileInfo1.FullName);
    }
    else
    {
      FileInfo fileInfo2 = new FileInfo(Path + "\\Company.png");
      if (fileInfo2.Exists)
        image = Image.FromFile(fileInfo2.FullName);
    }
    if (image == null)
      buLogVer5.addToLog("clsFile", nameof (OpenCompanyImage), "Intro Image Load", "Fail", -1.0, 0.0);
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
    catch (Exception ex)
    {
      buLogVer5.addToLog("clsFile", "DefinationFile", "Defination File Load", "Fail", -1.0, 0.0);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static bool ReadDevFile()
  {
    AppBool.DeveloperMode = true;
    clsVar.appModes_0.DeveloperMode = true;
    return true;
  }

  public static bool ReadDevFileFull() => true;

  public static void SaveBackupFile(string FileName, BackupModes Modes, bool Compress)
  {
    try
    {
      if (!new DirectoryInfo(AppPath.Backup).Exists)
        Directory.CreateDirectory(AppPath.Backup);
      string[] strArray = new string[5]
      {
        AppPath.Backup,
        "\\",
        null,
        null,
        null
      };
      int num = DateTime.Now.Year;
      strArray[2] = num.ToString();
      num = DateTime.Now.Month;
      strArray[3] = num.ToString("00");
      num = DateTime.Now.Day;
      strArray[4] = num.ToString("00");
      string path1 = string.Concat(strArray);
      if (FileName.Trim().Length > 0)
      {
        string withoutExtension = buFile.getFileNameWithoutExtension(FileName);
        string path2 = $"{buFile.GetPath(FileName)}\\{withoutExtension}";
        if (!new DirectoryInfo(path2).Exists)
          Directory.CreateDirectory(path2);
        path1 = path2;
      }
      DirectoryInfo directoryInfo1 = new DirectoryInfo(path1);
      if (!directoryInfo1.Exists)
        Directory.CreateDirectory(directoryInfo1.FullName);
      DirectoryInfo directoryInfo2 = new DirectoryInfo(path1 + "\\Settings");
      if (!directoryInfo1.Exists)
      {
        Directory.CreateDirectory(directoryInfo2.FullName);
        buFile5.CopyFilesRecursively(AppPath.Settings, directoryInfo2.FullName);
      }
      if (Modes.Settings)
        clsFiles.SaveParameter(directoryInfo1.FullName, "");
      if (Modes.Macro)
      {
        FileInfo fileInfo = new FileInfo(AppPath.User + "\\Macro.bumacro");
        if (fileInfo.Exists)
          System.IO.File.Copy(fileInfo.FullName, directoryInfo1.FullName + "\\Macro.bumacro", true);
      }
      if (Modes.ShortKeys)
      {
        FileInfo fileInfo = new FileInfo(AppPath.User + "\\ShortKey.bukey");
        if (fileInfo.Exists)
          System.IO.File.Copy(fileInfo.FullName, directoryInfo1.FullName + "\\ShortKey.bukey", true);
      }
      if (Modes.mnbucf)
      {
        FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
        if (fileInfo.Exists)
          System.IO.File.Copy(fileInfo.FullName, directoryInfo1.FullName + "\\mnbucfd.dll", true);
      }
      if (Modes.Runtime)
      {
        FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\Runtime.prm");
        if (fileInfo.Exists)
          System.IO.File.Copy(fileInfo.FullName, directoryInfo1.FullName + "\\Runtime.prm", true);
      }
      if (Modes.Diemaker)
      {
        FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\Heff.bucf2set");
        if (fileInfo.Exists)
          System.IO.File.Copy(fileInfo.FullName, directoryInfo1.FullName + "\\Heff.bucf2set", true);
      }
      if (Modes.Nesting)
        ;
      if (Modes.Post && ccVars.PostActive.FileName.Length > 0)
      {
        FileInfo fileInfo = new FileInfo(ccVars.PostActive.FileName);
        if (fileInfo.Exists)
        {
          string fileName = buFile.getFileName(fileInfo.FullName);
          System.IO.File.Copy(fileInfo.FullName, $"{directoryInfo1.FullName}\\{fileName}", true);
        }
      }
      if (Modes.ActualOperation & ccVars.Pages.Count > 0)
        clsInit.appCommand.SavePage(directoryInfo1.FullName + "\\actualFile.bucadv5");
      if (Modes.LastCreatedCode)
        ;
      if (Modes.LastImportedFile && clsVar.varInterface.LastImportedFiles[0].ToString().Length > 1)
      {
        string fileName = buFile.getFileName(clsVar.varInterface.LastImportedFiles[0].ToString());
        if (new FileInfo(clsVar.varInterface.LastImportedFiles[0].ToString()).Exists)
          System.IO.File.Copy(clsVar.varInterface.LastImportedFiles[0].ToString(), $"{directoryInfo1.FullName}\\LastImport_{fileName}", true);
      }
      if (Modes.LastLoadedFile && clsVar.varInterface.LastLoadedFiles[0].ToString().Length > 1)
      {
        string fileName = buFile.getFileName(clsVar.varInterface.LastLoadedFiles[0].ToString());
        if (new FileInfo(clsVar.varInterface.LastLoadedFiles[0].ToString()).Exists)
          System.IO.File.Copy(clsVar.varInterface.LastLoadedFiles[0].ToString(), $"{directoryInfo1.FullName}\\LastLoad_{fileName}", true);
      }
      if (Modes.Marble)
        ;
      if (Modes.Profile)
        ;
      if (Modes.ScreenShot)
      {
        Bitmap SSBmp = (Bitmap) null;
        buImage5.GetScreenShot(clsItem.FrmMain, ref SSBmp);
        SSBmp?.Save(directoryInfo1.FullName + "\\ScreeenShot.bmp");
      }
      if (Compress)
      {
        FileInfo fileInfo = new FileInfo(FileName);
        if (fileInfo.Exists)
          fileInfo.Delete();
        buFile.ZipFolderToFile(directoryInfo1.FullName, FileName);
        DirectoryInfo directoryInfo3 = new DirectoryInfo($"{buFile.GetPath(FileName)}\\{buFile.getFileNameWithoutExtension(FileName)}");
        if (directoryInfo3.Exists)
          directoryInfo3.Delete(true);
      }
      buLog.addLog("Backup File Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      buLog.addLog("Backup File Not Saved", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenSystemFile(ref systemFileArg e)
  {
    try
    {
      if (new FileInfo(AppPath.Base + "\\busydmch.dll").Exists)
      {
        BinaryReader binaryReader = new BinaryReader((Stream) new FileStream(AppPath.Base + "\\busydmch.dll", FileMode.Open));
        Decimal num1 = 0M;
        for (int index = 0; index < 398; ++index)
        {
          double num2 = (double) binaryReader.ReadSingle();
        }
        for (int index = 0; index < 1278; ++index)
          binaryReader.ReadDouble();
        for (int index = 0; index < 6298; ++index)
          num1 = binaryReader.ReadDecimal();
        for (int index = 0; index < 4952; ++index)
        {
          double num3 = (double) binaryReader.ReadInt32();
        }
        for (int index = 0; index < 6543; ++index)
        {
          double num4 = (double) binaryReader.ReadSingle();
        }
        for (int index = 0; index < 8543; ++index)
          binaryReader.ReadDouble();
        for (int index = 0; index < 8643; ++index)
          num1 = binaryReader.ReadDecimal();
        for (int index = 0; index < 8524; ++index)
        {
          double num5 = (double) binaryReader.ReadInt32();
        }
        int num6 = binaryReader.ReadInt32();
        int num7 = binaryReader.ReadInt32();
        int num8 = binaryReader.ReadInt32();
        clsVar.OpenedFileCount = binaryReader.ReadInt32();
        clsVar.RunCount = binaryReader.ReadInt32();
        e.ReachDemoModeFileOpenLimit = false;
        e.ReachDemoModeRunLimit = false;
        if (!clsVar.appModes_0.DeveloperMode)
        {
          if (clsVar.OpenedFileCount >= clsVar.appModes_0.NumberOfDemoOpenFile & clsVar.appModes_0.NumberOfDemoOpenFile > 0)
          {
            if (num6 >= DateTime.Now.Year & num7 >= DateTime.Now.Month & num8 >= DateTime.Now.Day)
              e.ReachDemoModeFileOpenLimit = true;
          }
          else
            clsVar.OpenedFileCount = 0;
          if (clsVar.RunCount >= clsVar.appModes_0.NumberOfDemoRun & clsVar.appModes_0.NumberOfDemoRun > 0)
          {
            if (num6 >= DateTime.Now.Year & num7 >= DateTime.Now.Month & num8 >= DateTime.Now.Day)
              e.ReachDemoModeRunLimit = true;
          }
          else
            clsVar.RunCount = 0;
        }
        binaryReader.Close();
      }
      else
      {
        if (!clsVar.appModes_0.DemoMode)
          return;
        e.ReachDemoModeFileOpenLimit = true;
        e.ReachDemoModeRunLimit = true;
        int num = (int) MessageBox.Show(AppLanguage.CadCamMessages[73]);
      }
    }
    catch (Exception ex)
    {
      if (!clsVar.appModes_0.DemoMode)
        return;
      e.ReachDemoModeFileOpenLimit = true;
      e.ReachDemoModeRunLimit = true;
    }
  }

  public void SaveSystemFile()
  {
    BinaryWriter binaryWriter = new BinaryWriter((Stream) new FileStream(AppPath.Base + "\\busydmch.dll", FileMode.Create));
    Random random = new Random();
    for (int index = 0; index < 398; ++index)
    {
      float num = (float) random.Next(500) * 1.8764f;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 1278; ++index)
    {
      double num = (double) random.Next(800) * 23.567;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 6298; ++index)
    {
      Decimal num = (Decimal) ((double) random.Next(12000) * 4.123);
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 4952; ++index)
    {
      int num = random.Next(2015);
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 6543; ++index)
    {
      float num = (float) random.Next(500) * 1.9764f;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 8543; ++index)
    {
      double num = (double) random.Next(800) * 23.667;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 8643; ++index)
    {
      Decimal num = (Decimal) ((double) random.Next(12000) * 4.223);
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 8524; ++index)
    {
      int num = random.Next(2015);
      binaryWriter.Write(num);
    }
    binaryWriter.Write(DateTime.Now.Year);
    binaryWriter.Write(DateTime.Now.Month);
    binaryWriter.Write(DateTime.Now.Day);
    binaryWriter.Write(clsVar.OpenedFileCount);
    binaryWriter.Write(clsVar.RunCount);
    for (int index = 0; index < 7868; ++index)
    {
      float num = (float) random.Next(500) * 1.8764f;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 6688; ++index)
    {
      double num = (double) random.Next(800) * 23.567;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 9642; ++index)
    {
      Decimal num = (Decimal) ((double) random.Next(12000) * 4.123);
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 3456; ++index)
    {
      int num = random.Next(2015);
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 9743; ++index)
    {
      float num = (float) random.Next(500) * 1.9764f;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 12873; ++index)
    {
      double num = (double) random.Next(800) * 23.667;
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 7532; ++index)
    {
      Decimal num = (Decimal) ((double) random.Next(12000) * 4.223);
      binaryWriter.Write(num);
    }
    for (int index = 0; index < 3457; ++index)
    {
      int num = random.Next(2015);
      binaryWriter.Write(num);
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
      return;
    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
    clsVar.varInterface.pathData = fileInfo.DirectoryName;
    ArrayList StringList = new ArrayList();
    buFile.OpenFromFile(fileInfo.FullName, ref StringList);
    List<List<string>> CalcList1 = new List<List<string>>();
    List<List<string>> CalcList2 = new List<List<string>>();
    buString.ListToSpecificList("<ToolGroup5>", "</ToolGroup5>", true, StringList, ref CalcList2);
    if (CalcList2.Count > 0)
      Tools.Clear();
    for (int index1 = 0; index1 <= CalcList2.Count - 1; ++index1)
    {
      ToolGroup5 toolGroup5 = new ToolGroup5();
      buSerilization5.Decode(CalcList2[index1], "", SerilizationMode5.MultiLine, (object) toolGroup5);
      buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", true, CalcList2[index1], ref CalcList1);
      List<ToolBase5> toolBase5List = new List<ToolBase5>();
      for (int index2 = 0; index2 <= CalcList1.Count - 1; ++index2)
      {
        ArrayList AL = new ArrayList();
        AL.AddRange((ICollection) CalcList1[index2].ToArray());
        ToolBase5 toolBase5 = new ToolBase5();
        buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) toolBase5);
        toolGroup5.Tools.Add(toolBase5);
      }
      Tools.Add(toolGroup5);
    }
  }

  public void OpenToolFile(ref List<ToolBase5> Tools)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = clsVar.varInterface.pathData;
    openFileDialog.Multiselect = false;
    openFileDialog.Filter = "buCad/Cam Tools Group File (*.butoolgroup)|*.butoolgroup";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
    clsVar.varInterface.pathData = fileInfo.DirectoryName;
    ArrayList StringList = new ArrayList();
    buFile.OpenFromFile(fileInfo.FullName, ref StringList);
    List<List<string>> CalcList = new List<List<string>>();
    buString.ListToSpecificList("<ToolBase5>", "</ToolBase5>", true, StringList, ref CalcList);
    if (CalcList.Count > 0)
      Tools.Clear();
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      ToolBase5 toolBase5 = new ToolBase5();
      buSerilization5.Decode(CalcList[index], "", SerilizationMode5.MultiLine, (object) toolBase5);
      Tools.Add(toolBase5);
    }
  }

  public void SaveToolFile(List<ToolGroup5> Tools)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathData;
    saveFileDialog.Filter = "buCad/Cam Tools File (*.butools)|*.butools";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
    clsVar.varInterface.pathData = fileInfo.DirectoryName;
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "  buCadCam Tools ");
    StringList.Add((object) "------------------------------------------------------------------------");
    for (int index1 = 0; index1 <= Tools.Count - 1; ++index1)
    {
      StringList.Add((object) "<ToolGroup5>");
      ArrayList c = new ArrayList();
      c.AddRange((ICollection) Tools[index1].ToDefAll("", 2, SerilizationMode5.MultiLine));
      c.RemoveAt(0);
      c.RemoveAt(c.Count - 1);
      StringList.AddRange((ICollection) c);
      for (int index2 = 0; index2 <= Tools[index1].Tools.Count - 1; ++index2)
        StringList.AddRange((ICollection) Tools[index1].Tools[index2].ToDefAll("", 6, SerilizationMode5.MultiLine));
      StringList.Add((object) "</ToolGroup5>");
    }
    buFile.SaveToFile(StringList, saveFileDialog.FileName);
  }

  public void SaveToolFile(List<ToolBase5> Tools)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = clsVar.varInterface.pathData;
    saveFileDialog.Filter = "buCad/Cam Tools Group File (*.butoolgroup)|*.butoolgroup";
    saveFileDialog.FilterIndex = 1;
    if (saveFileDialog.ShowDialog() != DialogResult.OK)
      return;
    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
    clsVar.varInterface.pathData = fileInfo.DirectoryName;
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "  buCadCam Tools Groups ");
    StringList.Add((object) "------------------------------------------------------------------------");
    for (int index = 0; index <= Tools.Count - 1; ++index)
      StringList.AddRange((ICollection) Tools[index].ToDefAll("", 6, SerilizationMode5.MultiLine));
    buFile.SaveToFile(StringList, saveFileDialog.FileName);
  }

  public void cmdShowCF2Fileroperties()
  {
    try
    {
      if (clsItem.FrmCf2Properties == null)
        return;
      if (!clsItem.FrmCf2Properties.Visible)
      {
        clsItem.FrmCf2Properties.Cf2Properties.Clear();
        clsItem.FrmCf2Properties.Cf2Properties = new List<Cf2FileProperties>();
        for (int index = 0; index <= clsVar.Cf2Properties.Count - 1; ++index)
        {
          Cf2FileProperties cf2FileProperties = new Cf2FileProperties(clsVar.Cf2Properties[index]);
          clsItem.FrmCf2Properties.Cf2Properties.Add(cf2FileProperties);
        }
        clsItem.FrmCf2Properties.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
        clsItem.FrmCf2Properties.pathCf2File = clsVar.varInterface.pathCf2Settings;
        clsItem.FrmCf2Properties.fileCf2SettingsName = clsVar.varInterface.fileCf2SettingsName;
        clsItem.FrmCf2Properties.Init();
        int num = (int) clsItem.FrmCf2Properties.ShowDialog();
        if (clsItem.FrmCf2Properties.PropertiesForm.Result != DialogResult.OK)
          return;
        clsVar.Cf2Properties.Clear();
        clsVar.Cf2Properties = new List<Cf2FileProperties>();
        for (int index = 0; index <= clsItem.FrmCf2Properties.Cf2Properties.Count - 1; ++index)
        {
          Cf2FileProperties cf2FileProperties = new Cf2FileProperties(clsItem.FrmCf2Properties.Cf2Properties[index]);
          clsVar.Cf2Properties.Add(cf2FileProperties);
        }
        clsVar.varInterface.pathCf2Settings = clsItem.FrmCf2Properties.pathCf2File;
        clsVar.varInterface.fileCf2SettingsName = clsItem.FrmCf2Properties.fileCf2SettingsName;
        clsFiles.SaveParameter();
      }
      else
        clsItem.FrmCf2Properties.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdShowDxfileroperties()
  {
    try
    {
      if (clsItem.FrmDxfProperties == null || !clsItem.FrmDxfProperties.Visible)
        return;
      clsItem.FrmDxfProperties.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void OpenCadFiles(string FileName, ref List<Entity> OpenedEntities)
  {
    try
    {
      FileInfo fileInfo = new FileInfo(FileName);
      OpenedEntities.Clear();
      OpenedEntities = new List<Entity>();
      bool Clear = true;
      if (clsFiles.modelCommon == null)
        clsFiles.modelCommon = new Design();
      if (fileInfo.Extension.ToLower() == ".bucadv5")
      {
        clsFiles.modelCommon.Clear();
        this.OpenBuCadFileVer5(fileInfo.FullName, Clear, ref clsFiles.modelCommon);
        for (int index = 0; index <= clsFiles.modelCommon.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(clsFiles.modelCommon.Entities[index]));
      }
      if (fileInfo.Extension.ToLower() == ".bucad")
      {
        clsFiles.modelCommon.Clear();
        this.OpenBuCadFileVer4(fileInfo.FullName, Clear, ref clsFiles.modelCommon);
        for (int index = 0; index <= clsFiles.modelCommon.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(clsFiles.modelCommon.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".ply")
      {
        clsFiles.modelCommon.Clear();
        this.OpenPlyFile(fileInfo.FullName, Clear, ref clsFiles.modelCommon);
        for (int index = 0; index <= clsFiles.modelCommon.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(clsFiles.modelCommon.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".cf2")
      {
        clsFiles.modelCommon.Clear();
        this.OpenCf2File(fileInfo.FullName, Clear, ref clsFiles.modelCommon);
        for (int index = 0; index <= clsFiles.modelCommon.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(clsFiles.modelCommon.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".hpgl")
      {
        clsFiles.modelCommon.Clear();
        this.OpenHpglFile(fileInfo.FullName, Clear, ref clsFiles.modelCommon);
        for (int index = 0; index <= clsFiles.modelCommon.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(clsFiles.modelCommon.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".xyz" | fileInfo.Extension.ToLower() == ".txt")
      {
        clsFiles.modelCommon.Clear();
        this.OpenXYZFile(fileInfo.FullName, Clear, ref clsFiles.modelCommon);
        for (int index = 0; index <= clsFiles.modelCommon.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(clsFiles.modelCommon.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".cnc" | fileInfo.Extension.ToLower() == ".nc" | fileInfo.Extension.ToLower() == ".mpf")
      {
        clsFiles.modelCommon.Clear();
        this.OpenGCodeFile(fileInfo.FullName, Clear, ref clsFiles.modelCommon);
        for (int index = 0; index <= clsFiles.modelCommon.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(clsFiles.modelCommon.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".dxf")
      {
        ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(fileInfo.FullName);
        ((ReadAutodesk) readFileAsync).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
        clsFiles.modelCommon.Clear();
        clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
        for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".dwg")
      {
        ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(fileInfo.FullName);
        ((ReadAutodesk) readFileAsync).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
        clsFiles.modelCommon.Clear();
        clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
        for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".stl")
      {
        ReadFileAsync readFileAsync = (ReadFileAsync) new ReadSTL(fileInfo.FullName);
        clsFiles.modelCommon.Clear();
        clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
        for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
      }
      else if (fileInfo.Extension.ToLower() == ".obj")
      {
        ReadFileAsync readFileAsync = (ReadFileAsync) new ReadOBJ(fileInfo.FullName);
        clsFiles.modelCommon.Clear();
        clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
        for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
          OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
      }
      else
      {
        if (fileInfo.Extension.ToLower() == ".3ds")
          return;
        if (fileInfo.Extension.ToLower() == ".asc")
        {
          ReadFileAsync readFileAsync = (ReadFileAsync) new ReadASC(fileInfo.FullName);
          clsFiles.modelCommon.Clear();
          clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
          for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
            OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
        }
        else if (fileInfo.Extension.ToLower() == ".dwf")
        {
          ReadFileAsync readFileAsync = (ReadFileAsync) new ReadDWF(fileInfo.FullName);
          clsFiles.modelCommon.Clear();
          clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
          for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
            OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
        }
        else
        {
          if (fileInfo.Extension.ToLower() == ".ifc")
            return;
          if (fileInfo.Extension.ToLower() == ".jt")
          {
            ReadFileAsync readFileAsync = (ReadFileAsync) new ReadJT(fileInfo.FullName);
            clsFiles.modelCommon.Clear();
            clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
            for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
              OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
          }
          else if (fileInfo.Extension.ToLower() == ".las")
          {
            ReadFileAsync readFileAsync = (ReadFileAsync) new ReadLAS(fileInfo.FullName);
            clsFiles.modelCommon.Clear();
            clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
            for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
              OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
          }
          else if (fileInfo.Extension.ToLower() == ".pdf")
          {
            ReadFileAsync readFileAsync = (ReadFileAsync) new ReadPDF(fileInfo.FullName);
            clsFiles.modelCommon.Clear();
            clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
            for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
              OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
          }
          else if (fileInfo.Extension.ToLower() == ".step" | fileInfo.Extension.ToLower() == ".stp")
          {
            ReadFileAsync readFileAsync = (ReadFileAsync) new ReadSTEP(fileInfo.FullName);
            clsFiles.modelCommon.Clear();
            clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
            for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
              OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
          }
          else if (fileInfo.Extension.ToLower() == ".iges" | fileInfo.Extension.ToLower() == ".igs")
          {
            ReadFileAsync readFileAsync = (ReadFileAsync) new ReadIGES(fileInfo.FullName);
            clsFiles.modelCommon.Clear();
            clsFiles.modelCommon.DoWork((WorkUnit) readFileAsync);
            for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
              OpenedEntities.Add(buVector5.CopyEntities(readFileAsync.Entities[index]));
          }
          else if (fileInfo.Extension.ToLower() == ".medit" | fileInfo.Extension.ToLower() == ".mesh")
            ;
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine((object) ex);
      throw;
    }
  }

  public void OpenCadFiles(string FileName, bool ClearEntities, ref Design model)
  {
    try
    {
      FileInfo fileInfo1 = new FileInfo(FileName);
      bool Clear = ccVars.Action == actionTypeBU.fileOpenAsPage | ccVars.Action == actionTypeBU.fileImportAsPage;
      if (clsVar.OpenedFileCount >= clsVar.appModes_0.NumberOfDemoOpenFile & clsVar.appModes_0.NumberOfDemoOpenFile > 0 & clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show(AppLanguage.CadCamMessages[71]);
      }
      else
      {
        ++clsVar.OpenedFileCount;
        this.SaveSystemFile();
        if (fileInfo1.Extension.ToLower() == ".bucadv5")
        {
          this.OpenBuCadFileVer5(fileInfo1.FullName, Clear, ref model);
          if (ccVars.Action == actionTypeBU.fileInsert)
          {
            if (model.Entities != null)
            {
              for (int index = 0; index <= model.Entities.Count - 1; ++index)
              {
                Entity Ent = (Entity) model.Entities[index].Clone();
                Ent.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
                clsInit.appCommand.AddEntity(Ent);
              }
            }
            clsInit.appCommand.DrawingPropertiesUpdate();
          }
          if (ccVars.Action == actionTypeBU.fileImportAsPage | ccVars.Action == actionTypeBU.fileOpenAsPage)
            clsInit.appCommand.MaterialUpdate(true, clsVar.varInterface.MaterialIndex);
          clsInit.appCommand.OsnapCalculationByThread();
        }
        if (fileInfo1.Extension.ToLower() == ".bucad")
        {
          this.OpenBuCadFileVer4(fileInfo1.FullName, Clear, ref model);
          if (ccVars.Action == actionTypeBU.fileImportAsPage | ccVars.Action == actionTypeBU.fileOpenAsPage)
            clsInit.appCommand.MaterialUpdate(true, clsVar.varInterface.MaterialIndex);
          if (ccVars.Action != actionTypeBU.fileInsert)
            return;
          if (model.Entities != null)
          {
            for (int index = 0; index <= model.Entities.Count - 1; ++index)
            {
              Entity entity = (Entity) model.Entities[index].Clone();
              entity.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity);
            }
          }
          clsInit.appCommand.DrawingPropertiesUpdate();
        }
        else if (fileInfo1.Extension.ToLower() == ".ply")
        {
          this.OpenPlyFile(fileInfo1.FullName, Clear, ref model);
          if (ccVars.Action != actionTypeBU.fileInsert)
            return;
          if (model.Entities != null)
          {
            for (int index = 0; index <= model.Entities.Count - 1; ++index)
            {
              Entity entity = (Entity) model.Entities[index].Clone();
              entity.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entity);
            }
          }
          clsInit.appCommand.DrawingPropertiesUpdate();
        }
        else if (fileInfo1.Extension.ToLower() == ".cf2")
        {
          this.OpenCf2File(fileInfo1.FullName, Clear, ref model);
          if (ccVars.Action != actionTypeBU.fileInsert)
            return;
          if (model.Entities != null)
          {
            for (int index = 0; index <= model.Entities.Count - 1; ++index)
            {
              Entity refEnt = (Entity) model.Entities[index].Clone();
              refEnt.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
              clsInit.appCommand.OsnapCalculation(refEnt);
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(refEnt);
            }
          }
          clsInit.appCommand.DrawingPropertiesUpdate();
        }
        else if (fileInfo1.Extension.ToLower() == ".hpgl")
        {
          this.OpenHpglFile(fileInfo1.FullName, Clear, ref model);
          if (ccVars.Action != actionTypeBU.fileInsert)
            return;
          if (model.Entities != null)
          {
            for (int index = 0; index <= model.Entities.Count - 1; ++index)
            {
              Entity refEnt = (Entity) model.Entities[index].Clone();
              refEnt.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
              clsInit.appCommand.OsnapCalculation(refEnt);
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(refEnt);
            }
          }
          clsInit.appCommand.DrawingPropertiesUpdate();
        }
        else if (fileInfo1.Extension.ToLower() == ".xyz" | fileInfo1.Extension.ToLower() == ".txt")
        {
          this.OpenXYZFile(fileInfo1.FullName, Clear, ref model);
          if (ccVars.Action != actionTypeBU.fileInsert)
            return;
          if (model.Entities != null)
          {
            for (int index = 0; index <= model.Entities.Count - 1; ++index)
            {
              Entity refEnt = (Entity) model.Entities[index].Clone();
              refEnt.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
              clsInit.appCommand.OsnapCalculation(refEnt);
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(refEnt);
            }
          }
          clsInit.appCommand.DrawingPropertiesUpdate();
        }
        else if (fileInfo1.Extension.ToLower() == ".cnc" | fileInfo1.Extension.ToLower() == ".nc" | fileInfo1.Extension.ToLower() == ".mpf")
        {
          this.OpenGCodeFile(fileInfo1.FullName, Clear, ref model);
          if (ccVars.Action != actionTypeBU.fileInsert)
            return;
          if (model.Entities != null)
          {
            for (int index = 0; index <= model.Entities.Count - 1; ++index)
            {
              Entity refEnt = (Entity) model.Entities[index].Clone();
              refEnt.LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
              clsInit.appCommand.OsnapCalculation(refEnt);
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(refEnt);
            }
          }
          clsInit.appCommand.DrawingPropertiesUpdate();
        }
        else if (fileInfo1.Extension.ToLower() == ".dxf")
        {
          if (clsVar.appModes_0.CutterMode.Enable)
          {
            FileInfo fileInfo2 = new FileInfo($"{fileInfo1.Directory?.ToString()}\\{buFile.getFileNameWithoutExtension(fileInfo1.FullName)}.rul");
            if (fileInfo2.Exists)
              this.OpenRulFile(fileInfo2.FullName);
            else
              clsInit.appCutter.Properties = new RulProperties();
          }
          if (clsVar.appModes_0.NestingMode.Enable)
          {
            if (clsNesting.ParNest.PartSettings.DeletePartAfterImport)
            {
              if (clsNesting.ParNest.PartSettings.SavePartsBeforeDeleted)
                new buFile5.bunesting().SaveNesting($"{AppPath.Misc}\\PartDeleted_{buFile.FileNameFromDate(0)}.bunesting", clsNesting.Parts, new List<buNestingSheet>(), clsNesting.ParNest);
              clsNesting.Parts.Clear();
            }
            if (clsNesting.ParNest.MaterailSettings.DeleteSheetAfterImport)
            {
              if (clsNesting.ParNest.MaterailSettings.SaveSheetsBeforeDeleted)
                new buFile5.bunesting().SaveNesting($"{AppPath.Misc}\\SheetDeleted_{buFile.FileNameFromDate(0)}.bunesting", new List<buNestingPart>(), clsNesting.Sheets, clsNesting.ParNest);
              clsNesting.Sheets.Clear();
            }
          }
          ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(fileInfo1.FullName);
          ((ReadAutodesk) readFileAsync).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
          if (model != null)
          {
            model.Clear();
            model.StartWork((WorkUnit) readFileAsync);
          }
          else
          {
            if (ClearEntities)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
          }
        }
        else if (fileInfo1.Extension.ToLower() == ".dwg")
        {
          if (clsVar.appModes_0.CutterMode.Enable)
          {
            FileInfo fileInfo3 = new FileInfo($"{fileInfo1.Directory?.ToString()}\\{buFile.getFileNameWithoutExtension(fileInfo1.FullName)}.rul");
            if (fileInfo3.Exists)
              this.OpenRulFile(fileInfo3.FullName);
            else
              clsInit.appCutter.Properties = new RulProperties();
          }
          if (clsNesting.ParNest.PartSettings.DeletePartAfterImport)
          {
            if (clsNesting.ParNest.PartSettings.SavePartsBeforeDeleted)
              new buFile5.bunesting().SaveNesting($"{AppPath.Misc}\\PartDeleted_{buFile.FileNameFromDate(0)}", clsNesting.Parts, new List<buNestingSheet>(), clsNesting.ParNest);
            clsNesting.Parts.Clear();
          }
          if (clsNesting.ParNest.MaterailSettings.DeleteSheetAfterImport)
          {
            if (clsNesting.ParNest.MaterailSettings.SaveSheetsBeforeDeleted)
              new buFile5.bunesting().SaveNesting($"{AppPath.Misc}\\SheetDeleted_{buFile.FileNameFromDate(0)}", new List<buNestingPart>(), clsNesting.Sheets, clsNesting.ParNest);
            clsNesting.Sheets.Clear();
          }
          ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(fileInfo1.FullName);
          ((ReadAutodesk) readFileAsync).ExtrudeByThickness = clsVar.varFile.ExtrudeByThickness;
          if (model != null)
          {
            model.Clear();
            model.StartWork((WorkUnit) readFileAsync);
          }
          else
          {
            if (ClearEntities)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
          }
        }
        else if (fileInfo1.Extension.ToLower() == ".stl")
        {
          ReadFileAsync readFileAsync = (ReadFileAsync) new ReadSTL(fileInfo1.FullName);
          if (model != null)
          {
            model.Clear();
            model.StartWork((WorkUnit) readFileAsync);
          }
          else
          {
            if (ClearEntities)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
          }
        }
        else if (fileInfo1.Extension.ToLower() == ".obj")
        {
          ReadFileAsync readFileAsync = (ReadFileAsync) new ReadOBJ(fileInfo1.FullName);
          if (model != null)
          {
            model.Clear();
            model.StartWork((WorkUnit) readFileAsync);
          }
          else
          {
            if (ClearEntities)
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
          }
        }
        else
        {
          if (fileInfo1.Extension.ToLower() == ".3ds")
            return;
          if (fileInfo1.Extension.ToLower() == ".asc")
          {
            ReadFileAsync readFileAsync = (ReadFileAsync) new ReadASC(fileInfo1.FullName);
            if (model != null)
            {
              model.Clear();
              model.StartWork((WorkUnit) readFileAsync);
            }
            else
            {
              if (ClearEntities)
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
            }
          }
          else if (fileInfo1.Extension.ToLower() == ".dwf")
          {
            ReadFileAsync readFileAsync = (ReadFileAsync) new ReadDWF(fileInfo1.FullName);
            if (model != null)
            {
              model.Clear();
              model.StartWork((WorkUnit) readFileAsync);
            }
            else
            {
              if (ClearEntities)
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
            }
          }
          else
          {
            if (fileInfo1.Extension.ToLower() == ".ifc")
              return;
            if (fileInfo1.Extension.ToLower() == ".jt")
            {
              ReadFileAsync readFileAsync = (ReadFileAsync) new ReadJT(fileInfo1.FullName);
              if (model != null)
              {
                model.Clear();
                model.StartWork((WorkUnit) readFileAsync);
              }
              else
              {
                if (ClearEntities)
                  ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
              }
            }
            else if (fileInfo1.Extension.ToLower() == ".las")
            {
              ReadFileAsync readFileAsync = (ReadFileAsync) new ReadLAS(fileInfo1.FullName);
              if (model != null)
              {
                model.Clear();
                model.StartWork((WorkUnit) readFileAsync);
              }
              else
              {
                if (ClearEntities)
                  ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
              }
            }
            else if (fileInfo1.Extension.ToLower() == ".pdf")
            {
              ReadFileAsync readFileAsync = (ReadFileAsync) new ReadPDF(fileInfo1.FullName);
              if (model != null)
              {
                model.Clear();
                model.StartWork((WorkUnit) readFileAsync);
              }
              else
              {
                if (ClearEntities)
                  ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
              }
            }
            else if (fileInfo1.Extension.ToLower() == ".step" | fileInfo1.Extension.ToLower() == ".stp")
            {
              ReadFileAsync readFileAsync = (ReadFileAsync) new ReadSTEP(fileInfo1.FullName);
              if (model != null)
              {
                model.Clear();
                model.StartWork((WorkUnit) readFileAsync);
              }
              else
              {
                if (ClearEntities)
                  ;
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
              }
            }
            else if (fileInfo1.Extension.ToLower() == ".iges" | fileInfo1.Extension.ToLower() == ".igs")
            {
              ReadFileAsync readFileAsync = (ReadFileAsync) new ReadIGES(fileInfo1.FullName);
              if (model != null)
              {
                model.Clear();
                model.StartWork((WorkUnit) readFileAsync);
              }
              else
              {
                if (ClearEntities)
                  ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.StartWork((WorkUnit) readFileAsync);
              }
            }
            else if (fileInfo1.Extension.ToLower() == ".medit" | fileInfo1.Extension.ToLower() == ".mesh")
              ;
          }
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine((object) ex);
      throw;
    }
  }

  public void OpenBuCadFileVer5(string FileName, bool Clear, ref Design model)
  {
    DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\T");
    if (directoryInfo.Exists)
      directoryInfo.Delete(true);
    buFile.ExtractToFolder(AppPath.Base + "\\T", FileName);
    List<string> Files = new List<string>();
    buFile.getFiles(AppPath.Base + "\\T", ref Files);
    Files.Reverse();
    foreach (string str in Files)
    {
      FileInfo fileInfo = new FileInfo(str);
      if (fileInfo.Extension == ".bupage" & fileInfo.Exists)
      {
        ReadFile readFile = new ReadFile(fileInfo.FullName, (FileSerializer) new MyFileSerializer(contentType.GeometryAndTessellation));
        readFile.DoWork();
        RegenOptions ro = new RegenOptions();
        if (model != null)
        {
          if (model.Entities != null)
            model.Entities.Clear();
          readFile.OpenTo((IDesign) model, ro);
        }
        else
        {
          if (Clear)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Clear();
          readFile.OpenTo((IDesign) ccVars.Pages[ccVars.PageIndex].Form.viewportcad, ro);
          if (clsVar.appModes_0.TuftingMode.Enable)
          {
            List<Entity> BrokeEntities = new List<Entity>();
            if (clsVar.varFile.BreakCurveEntitiesByConnection)
              clsInit.cVector5.BreakEntitiesWithIntersectionPoints(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref BrokeEntities);
            if (BrokeEntities.Count > 0)
            {
              ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
              for (int index = 0; index <= BrokeEntities.Count - 1; ++index)
              {
                BrokeEntities[index].EntityData = (object) new CustomData((CustomData) BrokeEntities[index].EntityData);
                ccVars.UndoDont = true;
                clsInit.appCommand.AddEntity(BrokeEntities[index]);
              }
            }
          }
        }
      }
      if (fileInfo.Extension == ".busets" & fileInfo.Exists)
      {
        if (model == null)
        {
          ccVars.Pages[ccVars.PageIndex].Layers.Clear();
          ccVars.Pages[ccVars.PageIndex].Scene.Clear();
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(str, ref StringList);
          List<List<string>> CalcList1 = new List<List<string>>();
          buString.ListToSpecificList("<LayerBase5>", "</LayerBase5>", true, StringList, ref CalcList1);
          for (int index = 0; index <= CalcList1.Count - 1; ++index)
          {
            ArrayList AL = new ArrayList();
            AL.AddRange((ICollection) CalcList1[index].ToArray());
            LayerBase5 data = new LayerBase5();
            buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) data);
            LayerBase5 layerBase5 = new LayerBase5(data);
            ccVars.Pages[ccVars.PageIndex].Layers.Add(layerBase5);
          }
          List<List<string>> CalcList2 = new List<List<string>>();
          buString.ListToSpecificList("<PageScene>", "</PageScene>", true, StringList, ref CalcList2);
          for (int index = 0; index <= CalcList2.Count - 1; ++index)
          {
            new ArrayList().AddRange((ICollection) CalcList2[index].ToArray());
            PageScene scene = new PageScene();
            PageScene.DecodeLocal(CalcList2[index], "", ref scene);
            ccVars.Pages[ccVars.PageIndex].Scene.Add(scene);
          }
          List<List<string>> CalcList3 = new List<List<string>>();
          buString.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", true, StringList, ref CalcList3);
          if (CalcList3.Count > 0)
          {
            buCadCamFileInfo buCadCamFileInfo = new buCadCamFileInfo();
            buSerilization.Decode(CalcList3[0], "", SerilizationMode.MultiLine, (object) buCadCamFileInfo);
            string notes = buCadCamFileInfo.Notes;
            buCadCamFileInfo.Notes = notes.Replace("{[NewLine]}", "\r\n");
          }
        }
        else
        {
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(str, ref StringList);
          List<List<string>> CalcList = new List<List<string>>();
          buString.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buCadCamFileInfo buCadCamFileInfo = new buCadCamFileInfo();
            buSerilization.Decode(CalcList[0], "", SerilizationMode.MultiLine, (object) buCadCamFileInfo);
            string notes = buCadCamFileInfo.Notes;
            buCadCamFileInfo.Notes = notes.Replace("{[NewLine]}", "\r\n");
            MyFileSerializer.Version = int.Parse(buCadCamFileInfo.ProgramVersionNo.Replace(".", ""));
          }
        }
      }
    }
    if (model != null)
      return;
    if (ccVars.Pages[ccVars.PageIndex].Layers.Count > 0)
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(ccVars.Pages[ccVars.PageIndex].Layers);
    clsItem.timOpenAfter.Enabled = true;
  }

  public void OpenBuCadFileVer5(string FileName, bool Clear, ref List<Entity> refEntities)
  {
    DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\T");
    if (directoryInfo.Exists)
      directoryInfo.Delete(true);
    buFile.ExtractToFolder(AppPath.Base + "\\T", FileName);
    List<string> Files = new List<string>();
    buFile.getFiles(AppPath.Base + "\\T", ref Files);
    Files.Reverse();
    foreach (string fileName in Files)
    {
      FileInfo fileInfo = new FileInfo(fileName);
      if (fileInfo.Extension == ".bupage" & fileInfo.Exists)
      {
        ReadFile readFile = new ReadFile(fileInfo.FullName, (FileSerializer) new MyFileSerializer(contentType.GeometryAndTessellation));
        readFile.DoWork();
        RegenOptions ro = new RegenOptions();
        Design design = new Design();
        design.CreateControl();
        Viewport viewport = new Viewport();
        design.Viewports.Add(viewport);
        readFile.OpenTo((IDesign) design, ro);
        refEntities = new List<Entity>();
        for (int index = 0; index <= design.Entities.Count - 1; ++index)
        {
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(design.Entities[index], ref copiedEntity);
          if (copiedEntity != null)
          {
            copiedEntity.LayerName = "Default";
            copiedEntity.ColorMethod = colorMethodType.byEntity;
            refEntities.Add(copiedEntity);
          }
        }
      }
    }
  }

  public void OpenBuTeachFile(string FileName, ref List<EntitiesGroup> refGroups)
  {
    FileInfo fileInfo = new FileInfo(FileName);
    if (!fileInfo.Exists)
      return;
    ArrayList StringList = new ArrayList();
    buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
    List<List<string>> CalcList1 = new List<List<string>>();
    buString.ListToSpecificList("<Contour>", "</Contour>", false, StringList, ref CalcList1);
    for (int index1 = 0; index1 <= CalcList1.Count - 1; ++index1)
    {
      List<string> CalcList2 = new List<string>();
      buString.ListToSpecificList("<Outer>", "</Outer>", false, CalcList1[index1], ref CalcList2);
      List<List<string>> CalcList3 = new List<List<string>>();
      buString.ListToSpecificList("<Inside>", "</Inside>", false, CalcList1[index1], ref CalcList3);
      EntitiesGroup entitiesGroup = new EntitiesGroup();
      if (CalcList3.Count > 0)
      {
        entitiesGroup.Inside = new List<List<Entity>>();
        for (int index2 = 0; index2 <= CalcList3.Count - 1; ++index2)
        {
          List<Entity> refEntities = new List<Entity>();
          clsInit.cVector5.GetEntitiesFronEntityStrings(CalcList3[index2], ref refEntities);
          if (refEntities.Count > 0)
            entitiesGroup.Inside.Add(refEntities);
        }
      }
      if (CalcList2.Count > 0)
      {
        clsInit.cVector5.GetEntitiesFronEntityStrings(CalcList2, ref entitiesGroup.Outside);
        if (entitiesGroup.Outside.Count > 0)
          refGroups.Add(entitiesGroup);
      }
    }
  }

  public void OpenBuCadFileVer4(string FileName, bool Clear, ref Design model)
  {
    buCadFileOpenOptions Options = new buCadFileOpenOptions();
    buCadCamFileInfo FileInfo = new buCadCamFileInfo();
    List<eEntities> Entities = new List<eEntities>();
    List<LayerBase> Layers = new List<LayerBase>();
    List<LayerBase5> layerBase5List = new List<LayerBase5>();
    List<Entity> eyeEntity = new List<Entity>();
    buFile.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref Layers);
    for (int index = 0; index <= Layers.Count - 1; ++index)
      layerBase5List.Add(new LayerBase5()
      {
        Enable = Layers[index].Enable,
        LayerColor = Layers[index].LayerColor,
        LayerPurposes = Layers[index].LayerPurposes,
        LayerThickness = Layers[index].LayerThickness,
        Lock = Layers[index].Lock,
        MaterialName = Layers[index].MaterialName,
        Mode = Layers[index].Mode,
        Name = Layers[index].Name,
        Note = Layers[index].Note,
        Option = Layers[index].Option,
        Pattern = {
          Name = Layers[index].Pattern.Name,
          Type = Layers[index].Pattern.Type
        },
        RealDrawMode = Layers[index].RealDrawMode,
        ShownName = Layers[index].ShownName,
        Transparency = Layers[index].Transparency
      });
    buConversion5.buEntityToEyeEntity(Entities, true, ref eyeEntity, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
    if (model == null)
    {
      if (Clear)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(layerBase5List);
      for (int index = 0; index <= eyeEntity.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity[index]);
      clsItem.timOpenAfter.Enabled = true;
    }
    else
    {
      model.Entities.Clear();
      model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(layerBase5List);
      for (int index = 0; index <= eyeEntity.Count - 1; ++index)
        model.Entities.Add(eyeEntity[index]);
    }
  }

  public void OpenPlyFile(string FileName, bool Clear, ref Design model)
  {
    buCadFileOpenOptions cadFileOpenOptions = new buCadFileOpenOptions();
    buCadCamFileInfo buCadCamFileInfo = new buCadCamFileInfo();
    List<eEntities> Entities = new List<eEntities>();
    List<LayerBase5> layerBase5List1 = new List<LayerBase5>();
    List<Entity> eyeEntity = new List<Entity>();
    new buFile.Ply().ReadPly(FileName, ref Entities);
    List<LayerBase5> layerBase5List2 = new List<LayerBase5>();
    layerBase5List2.Add(new LayerBase5("Layer1")
    {
      LayerColor = Color.DimGray
    });
    buConversion5.buEntityToEyeEntity(Entities, true, ref eyeEntity, layerBase5List2, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
    if (model == null)
    {
      if (Clear)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(layerBase5List2);
      for (int index = 0; index <= eyeEntity.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity[index]);
      clsItem.timOpenAfter.Enabled = true;
    }
    else
    {
      model.Clear();
      model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(layerBase5List2);
      for (int index = 0; index <= eyeEntity.Count - 1; ++index)
        model.Entities.Add(eyeEntity[index]);
    }
  }

  public void OpenXYZFile(string FileName, bool Clear, ref Design model)
  {
    List<string> StringList = new List<string>();
    buFile5.OpenFromFile(FileName, ref StringList);
    List<Point3D> points = new List<Point3D>();
    for (int index = 0; index <= StringList.Count - 1; ++index)
    {
      string[] strArray = StringList[index].Split(';');
      if (strArray != null)
      {
        if (strArray.Length == 2)
        {
          Point3D point3D = new Point3D();
          double.TryParse(strArray[0].Trim(), out point3D.X);
          double.TryParse(strArray[1].Trim(), out point3D.Y);
          points.Add(point3D);
        }
        if (strArray.Length == 3)
        {
          Point3D point3D = new Point3D();
          double.TryParse(strArray[0].Trim(), out point3D.X);
          double.TryParse(strArray[1].Trim(), out point3D.Y);
          double.TryParse(strArray[2].Trim(), out point3D.Z);
          points.Add(point3D);
        }
      }
    }
    if (points.Count < 2)
      return;
    if (model == null)
    {
      if (Clear)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) linearPath);
      clsItem.timOpenAfter.Enabled = true;
    }
    else
    {
      model.Clear();
      LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) linearPath);
    }
  }

  public void OpenCf2File(string FileName, bool Clear, ref Design model)
  {
    buFile5.Cf2 cf2 = new buFile5.Cf2();
    List<Cf2FileProperties> Base = new List<Cf2FileProperties>();
    if (clsVar.Cf2Properties.Count > 0)
      Cf2FileProperties.Copy(clsVar.Cf2Properties, ref cf2.FileDefinations);
    else
      Cf2FileProperties.Copy(Base, ref cf2.FileDefinations);
    cf2.MinEntityLength = clsVar.varFile.MinAllowedEntityLength;
    List<eEntities> Entities = new List<eEntities>();
    List<eEntities> Bridges = new List<eEntities>();
    List<Entity> refEntities = new List<Entity>();
    List<Entity> entityList = new List<Entity>();
    cf2.ReadCf2(FileName, ref Entities, ref Bridges);
    List<LayerBase5> layerBase5List = new List<LayerBase5>();
    layerBase5List.Add(new LayerBase5("Layer1"));
    string SceneName = "";
    if (ccVars.Pages.Count > 0)
      SceneName = ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName;
    for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
    {
      Entity eyeEntity = (Entity) null;
      buConversion5.buEntityToEyeEntity(Entities[index1], true, index1, ref eyeEntity, layerBase5List, SceneName);
      if (eyeEntity != null)
      {
        if (model == null)
        {
          for (int index2 = 0; index2 <= cf2.FoundLayers.Count - 1; ++index2)
          {
            if (Entities[index1].Diemaker.Pt == cf2.FoundLayers[index2].Diemaker.Pt & Entities[index1].Diemaker.DiemakerType == cf2.FoundLayers[index2].Diemaker.Type)
            {
              eyeEntity.LayerName = cf2.FoundLayers[index2].Name;
              index2 = 2147483646;
            }
          }
        }
        eyeEntity.LineTypeMethod = colorMethodType.byEntity;
        eyeEntity.LineWeightMethod = colorMethodType.byEntity;
        eyeEntity.ColorMethod = colorMethodType.byEntity;
        refEntities.Add(eyeEntity);
      }
    }
    for (int index3 = 0; index3 <= Bridges.Count - 1; ++index3)
    {
      Entity eyeEntity = (Entity) null;
      buConversion5.buEntityToEyeEntity(Bridges[index3], true, index3, ref eyeEntity, layerBase5List, SceneName);
      if (eyeEntity != null)
      {
        if (model == null)
        {
          for (int index4 = 0; index4 <= cf2.FoundLayers.Count - 1; ++index4)
          {
            if (Bridges[index3].Diemaker.Pt == cf2.FoundLayers[index4].Diemaker.Pt & Bridges[index3].Diemaker.DiemakerType == cf2.FoundLayers[index4].Diemaker.Type)
            {
              eyeEntity.LayerName = cf2.FoundLayers[index4].Name;
              index4 = 2147483646;
            }
          }
        }
        eyeEntity.LineTypeMethod = colorMethodType.byEntity;
        eyeEntity.LineWeightMethod = colorMethodType.byEntity;
        eyeEntity.ColorMethod = colorMethodType.byEntity;
        ++eyeEntity.LineWeight;
        entityList.Add(eyeEntity);
      }
    }
    if (model == null)
    {
      if (Clear)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      if (cf2.FoundLayers.Count > 0)
      {
        ccVars.Pages[ccVars.PageIndex].Layers.Clear();
        for (int index = 0; index <= cf2.FoundLayers.Count - 1; ++index)
        {
          LayerBase5 layerBase5 = new LayerBase5(cf2.FoundLayers[index]);
          ccVars.Pages[ccVars.PageIndex].Layers.Add(layerBase5);
        }
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(ccVars.Pages[ccVars.PageIndex].Layers);
      clsInit.cVector5.ConnnectEntitiesGap(ref refEntities, 0.05);
      for (int index = 0; index <= refEntities.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(refEntities[index]);
      for (int index = 0; index <= entityList.Count - 1; ++index)
      {
        ((CustomData) entityList[index].EntityData).CamSelectable = false;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entityList[index]);
      }
      clsItem.timOpenAfter.Enabled = true;
    }
    else
    {
      model.Entities.Clear();
      model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(layerBase5List);
      for (int index = 0; index <= refEntities.Count - 1; ++index)
        model.Entities.Add(refEntities[index]);
      for (int index = 0; index <= entityList.Count - 1; ++index)
      {
        ((CustomData) entityList[index].EntityData).CamSelectable = false;
        model.Entities.Add(entityList[index]);
      }
    }
    if (ccVars.Pages.Count <= 0)
      return;
    clsInit.appCommand.OsnapCalculationByThread();
    Point3D MinPoint = new Point3D();
    Point3D MidPoint = new Point3D();
    Point3D MaxPoint = new Point3D();
    if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities != null)
    {
      clsInit.cVector5.BoxSizeCalculate(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref MinPoint, ref MidPoint, ref MaxPoint);
      ccVars.Pages[ccVars.PageIndex].Info.EntitiesBoxSize = new Point3D(Math.Round(MaxPoint.X - MinPoint.X, 5), Math.Round(MaxPoint.Y - MinPoint.Y, 5), Math.Round(MaxPoint.Z - MinPoint.Z, 5));
    }
    if (!clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      return;
    clsInit.appCommand.SetInformationAtStatus(clsInit.appLaserRouter.GetStatusInfo());
  }

  public void OpenGCodeFile(string FileName, bool Clear, ref Design model)
  {
    buCadFileOpenOptions cadFileOpenOptions = new buCadFileOpenOptions();
    buCadCamFileInfo buCadCamFileInfo = new buCadCamFileInfo();
    List<eEntities> eEntitiesList = new List<eEntities>();
    List<Entity> entityList = new List<Entity>();
    buFile.GCodeRead gcodeRead = new buFile.GCodeRead();
    List<GCodePoint> GCodeList = new List<GCodePoint>();
    gcodeRead.DecodeAxes.A = false;
    gcodeRead.DecodeAxes.B = false;
    gcodeRead.DecodeAxes.C = false;
    gcodeRead.OpenGCode(FileName, ref GCodeList);
    if (!(GCodeList.Count > 0 & (gcodeRead.EntitiesG1.Count > 0 | gcodeRead.EntitiesG0.Count > 0 | gcodeRead.EntitiesPlunge.Count > 0 | gcodeRead.EntitiesLeave.Count > 0)))
      return;
    List<LayerBase5> layerBase5List = new List<LayerBase5>();
    layerBase5List.Add(new LayerBase5("EntitiesG1")
    {
      LayerColor = Color.Black
    });
    layerBase5List.Add(new LayerBase5("EntitiesG0")
    {
      LayerColor = Color.Red
    });
    layerBase5List.Add(new LayerBase5("EntitiesPlunge")
    {
      LayerColor = Color.Green
    });
    layerBase5List.Add(new LayerBase5("EntitiesLeave")
    {
      LayerColor = Color.Blue
    });
    if (model == null)
    {
      if (Clear)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(layerBase5List);
      List<Entity> eyeEntity1 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesG1, true, ref eyeEntity1, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity1.Count - 1; ++index)
      {
        eyeEntity1[index].LayerName = "EntitiesG1";
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity1[index]);
      }
      List<Entity> eyeEntity2 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesG0, true, ref eyeEntity2, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity2.Count - 1; ++index)
      {
        eyeEntity2[index].LayerName = "EntitiesG0";
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity2[index]);
      }
      eyeEntity2 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesLeave, true, ref eyeEntity2, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity2.Count - 1; ++index)
      {
        eyeEntity2[index].LayerName = "EntitiesLeave";
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity2[index]);
      }
      eyeEntity2 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesPlunge, true, ref eyeEntity2, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity2.Count - 1; ++index)
      {
        eyeEntity2[index].LayerName = "EntitiesPlunge";
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(eyeEntity2[index]);
      }
    }
    else
    {
      model.Clear();
      model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(layerBase5List);
      List<Entity> eyeEntity3 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesG1, true, ref eyeEntity3, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity3.Count - 1; ++index)
      {
        eyeEntity3[index].LayerName = "EntitiesG1";
        model.Entities.Add(eyeEntity3[index]);
      }
      List<Entity> eyeEntity4 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesG0, true, ref eyeEntity4, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity4.Count - 1; ++index)
      {
        eyeEntity4[index].LayerName = "EntitiesG0";
        model.Entities.Add(eyeEntity4[index]);
      }
      eyeEntity4 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesLeave, true, ref eyeEntity4, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity4.Count - 1; ++index)
      {
        eyeEntity4[index].LayerName = "EntitiesLeave";
        model.Entities.Add(eyeEntity4[index]);
      }
      eyeEntity4 = new List<Entity>();
      buConversion5.buEntityToEyeEntity(gcodeRead.EntitiesPlunge, true, ref eyeEntity4, layerBase5List, ccVars.Pages[ccVars.PageIndex].Scene[0].SceneName);
      for (int index = 0; index <= eyeEntity4.Count - 1; ++index)
      {
        eyeEntity4[index].LayerName = "EntitiesPlunge";
        model.Entities.Add(eyeEntity4[index]);
      }
    }
    this.CommonOperationAfterFileLoading();
    clsItem.timOpenAfter.Enabled = true;
  }

  public void OpenHpglFile(string FileName, bool Clear, ref Design model)
  {
    buCadFileOpenOptions cadFileOpenOptions = new buCadFileOpenOptions();
    buCadCamFileInfo buCadCamFileInfo = new buCadCamFileInfo();
    List<eEntities> eEntitiesList = new List<eEntities>();
    List<LayerBase5> layerBase5List = new List<LayerBase5>();
    List<Entity> Entities = new List<Entity>();
    new buFile5.HPGLFile().ReadHPGL(FileName, ref Entities);
    List<LayerBase5> buLayers = new List<LayerBase5>();
    buLayers.Add(new LayerBase5("Layer1")
    {
      LayerColor = Color.DimGray
    });
    if (model == null)
    {
      if (Clear)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(buLayers);
      for (int index = 0; index <= Entities.Count - 1; ++index)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(Entities[index]);
      clsItem.timOpenAfter.Enabled = true;
      clsInit.appCommand.OsnapCalculationByThread();
    }
    else
    {
      model.Clear();
      model.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(buLayers);
      for (int index = 0; index <= Entities.Count - 1; ++index)
        model.Entities.Add(Entities[index]);
    }
  }

  public void OpenRulFile(string FileName)
  {
    new buFile.Rul().ReadRulFile(FileName, ref clsInit.appCutter.Properties);
  }

  public void OpenLibraryFile(
    string FileName,
    ref List<buEntity> Entities,
    ref setLibrary Settings)
  {
    ArrayList StringList = new ArrayList();
    List<string> CalcList1 = new List<string>();
    List<List<string>> CalcList2 = new List<List<string>>();
    buFile5.OpenFromFile(FileName, ref StringList);
    buString5.ListToSpecificList("<LibraryEntities>", "</LibraryEntities>", true, StringList, ref CalcList1);
    Entities.Clear();
    Entities = new List<buEntity>();
    buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList1, ref CalcList2);
    for (int index = 0; index <= CalcList2.Count - 1; ++index)
    {
      buEntity buEntity = buEntity.Decode(CalcList2[index]);
      if (buEntity != null)
        Entities.Add(buEntity);
    }
  }

  public void SaveLibraryFile(string FileName, List<buEntity> Entities, setLibrary Settings)
  {
    if (!(new FileInfo(FileName).Extension.ToLower() == ".bulib5"))
      return;
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "<LibraryEntities>");
    StringList.AddRange((ICollection) buEntity.ToDefEntity(Entities, 2));
    StringList.Add((object) "</LibraryEntities>");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "   Library Settings");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.AddRange((ICollection) Settings.ToDefAll("", 2, SerilizationMode.MultiLine));
    buFile5.SaveToFile(StringList, FileName);
  }

  public void CommonOperationAfterFileLoading()
  {
    clsInit.appCommand.PagesUpdate(true, "");
    clsInit.appCommand.LayerConvertFromEyeLayerToBuLayer(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, ref ccVars.Pages[ccVars.PageIndex].Layers);
    clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, true, 0);
    ccVars.Pages[ccVars.PageIndex].LayerName = ccVars.Pages[ccVars.PageIndex].Layers[0].Name;
    clsInit.appCommand.cmdViewTop(true, false);
    clsInit.appCommand.DrawingPropertiesUpdate();
    clsInit.appCommand.SetEntityCountForScene(ccVars.PageIndex);
    if (!clsVar.appModes_0.CutterMode.Enable)
      return;
    clsInit.appCutter.doOperationAfterFileLoad();
  }

  public void FunctionAfterOpenTick()
  {
    if (!clsVar.varFile.AnalyseEntitiesAfterImport)
      return;
    clsInit.appCommand.AnalyseEntities();
  }

  public void ModelOpenFileCommon_WorkCancelled(object sender, EventArgs e)
  {
  }

  public void ModelOpenFileCommon_WorkCompleted(object sender, WorkCompletedEventArgs e)
  {
    try
    {
      if (e.WorkUnit is ReadFileAsync)
      {
        ReadFileAsync workUnit1 = (ReadFileAsync) e.WorkUnit;
        RegenOptions ro = new RegenOptions();
        if (e.WorkUnit is ReadFile workUnit2)
        {
          int num = workUnit2.Camera != null ? 1 : 0;
        }
        workUnit1.OpenTo((IDesign) clsFiles.modelCommon, ro);
        List<List<Entity>> entityListList1 = new List<List<Entity>>();
        if (clsVar.varFile.ExplodeBlockReferanceWhenOpenFile)
        {
          for (int index1 = 0; index1 <= 10; ++index1)
          {
            List<int> intList = new List<int>();
            List<List<Entity>> entityListList2 = new List<List<Entity>>();
            for (int index2 = 0; index2 <= clsFiles.modelCommon.Entities.Count - 1; ++index2)
            {
              if (clsFiles.modelCommon.Entities[index2] is BlockReference)
              {
                Entity[] entityArray = ((BlockReference) clsFiles.modelCommon.Entities[index2]).Explode(clsFiles.modelCommon.Blocks);
                if (entityArray != null && entityArray.Length != 0)
                {
                  List<Entity> entityList = new List<Entity>();
                  for (int index3 = 0; index3 <= entityArray.Length - 1; ++index3)
                  {
                    if (entityArray[index3] is LinearPathEx)
                    {
                      LinearPath linearPath = new LinearPath(entityArray[index3].Vertices);
                      linearPath.LayerName = entityArray[index3].LayerName;
                      linearPath.Color = entityArray[index3].Color;
                      entityList.Add((Entity) linearPath);
                    }
                    else if (entityArray[index3].GetType() == typeof (devDept.Eyeshot.Entities.Point))
                    {
                      if (!clsVar.varFile.DontAddPointFromDxfFile)
                        entityList.Add(entityArray[index3]);
                    }
                    else if (entityArray[index3].GetType() == typeof (Text))
                    {
                      if (!clsVar.varFile.DontAddTextFromDxfFile)
                        entityList.Add(entityArray[index3]);
                    }
                    else
                      entityList.Add(entityArray[index3]);
                  }
                  entityListList2.Add(entityList);
                }
                intList.Add(index2);
              }
            }
            if (intList.Count > 0)
            {
              intList.Sort();
              intList.Reverse();
              for (int index4 = 0; index4 <= intList.Count - 1; ++index4)
                clsFiles.modelCommon.Entities.RemoveAt(intList[index4]);
            }
            else
              index1 = 11;
            for (int index5 = 0; index5 <= entityListList2.Count - 1; ++index5)
            {
              for (int index6 = 0; index6 <= entityListList2[index5].Count - 1; ++index6)
                clsFiles.modelCommon.Entities.Add((Entity) entityListList2[index5][index6].Clone());
            }
          }
        }
        if (!clsVar.varFile.RemoveBlockWhileImport)
          return;
        for (int index = clsFiles.modelCommon.Blocks.Count - 1; index >= 1; --index)
          clsFiles.modelCommon.Blocks.RemoveAt(index);
      }
      else if (e.WorkUnit is Regeneration)
        ;
    }
    catch (Exception ex)
    {
    }
  }

  public void ModelOpenFileCommon_WorkFailed(object sender, WorkFailedEventArgs e)
  {
  }
}
