// Decompiled with JetBrains decompiler
// Type: MarbleCNC.F_Intro
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using buCadCamResVer5;
using buClass;
using buControls;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buHandler;
using buMarble;
using buOpcUA;
using MarbleCNC.Machines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace MarbleCNC;

public class F_Intro : Form
{
  public static clsMachine1_5Axis appMachine1 = new clsMachine1_5Axis();
  public static clsMachine2_Ozteknik appMachine2 = new clsMachine2_Ozteknik();
  public static clsMachine3_Milling appMachine3Milling = new clsMachine3_Milling();
  public static clsMachine3_10AxisDoubleHead appMachine3 = new clsMachine3_10AxisDoubleHead();
  public static buPLCHandler cHandler = (buPLCHandler) null;
  private string sClass = nameof (F_Intro);
  public static Image ProgramImage = (Image) null;
  public static Image CompanyImage = (Image) null;
  private System.Windows.Forms.Timer timInit = new System.Windows.Forms.Timer();
  private System.Windows.Forms.Timer timSystemReady = new System.Windows.Forms.Timer();
  private int InitCnt;
  private int CntLicense = 0;
  private IContainer components = (IContainer) null;
  private Label lbl_vendor;
  private Label lbl_web;
  private Label lbl_ver;
  private Label lbl_appname;
  private Label lbl_machineinfo;
  private PictureBox pic_intro;

  public F_Intro() => this.InitializeComponent();

  private void FIntro_Load(object sender, EventArgs e)
  {
    string str1 = nameof (FIntro_Load);
    try
    {
      AppBool.MachineMode = true;
      buLogMarbleVer5.addToLog(this.sClass, str1, "Started", nameof (FIntro_Load));
      buControlCommands.CultureSettings();
      AppPath.Base = "D:\\PCProjects\\Generation5\\CMD\\CMDMarbleCNC\\CMDMarbleCNC\\bin\\Common";
      if (!new FileInfo(AppPath.Base + "\\_developer.dll").Exists)
        AppPath.Base = Application.StartupPath;
      clsFiles.OpenRuntimeAndConfig(false, true);
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "OpenRuntimeAndConfig");
      Task.Run((Action) (() => buLogVer5.checkLogFileSize()));
      Task.Run((Action) (() => buLogMarbleVer5.checkLogFileSize()));
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "checkLogFileSize");
      AppPath.MachinePostProcessor = AppPath.MachineSettings;
      AppPath.MachineKinematic = AppPath.MachineSettings;
      F_Intro.ProgramImage = clsFiles.OpenIntroImage(AppPath.MachineImage);
      if (F_Intro.ProgramImage != null)
        this.pic_intro.Image = F_Intro.ProgramImage;
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "OpenIntroImage");
      F_Intro.CompanyImage = clsFiles.OpenCompanyImage(AppPath.MachineImage);
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "OpenCompanyImage");
      if (new FileInfo(AppPath.MachineImage + "\\AppIcon.ico").Exists)
      {
        this.Icon = new Icon(AppPath.MachineImage + "\\AppIcon.ico");
        this.Refresh();
        this.Invalidate();
      }
      FileInfo fileInfo1 = new FileInfo(AppPath.MachineSettings + "\\_psw.cspass");
      if (fileInfo1.Exists)
      {
        buFile5.OpenPasswordCS(fileInfo1.FullName, 7.48);
      }
      else
      {
        FileInfo fileInfo2 = new FileInfo(AppPath.Base + "\\_psw.cspass");
        if (fileInfo2.Exists)
        {
          buFile5.OpenPassword(fileInfo2.FullName, 6.98);
        }
        else
        {
          buLogMarbleVer5.addToLog(this.sClass, str1, "Password", "Password File is Missing");
          buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordFileMissing);
        }
      }
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "OpenPassword");
      string str2 = Path.Combine(Application.StartupPath, "MasterLanguageDB.dll");
      clsFiles.OpenLanguageFiles(clsVar.varRuntime.Language);
      if (File.Exists(str2))
      {
        buLangTranslate.InitializeDatabase(str2);
        if (clsVar.varRuntime.Language == 0)
          buLangTranslate.ChangeLanguage("English");
        else if (clsVar.varRuntime.Language == 1)
          buLangTranslate.ChangeLanguage("Turkish");
        else if (clsVar.varRuntime.Language == 2)
          buLangTranslate.ChangeLanguage("Chinese");
      }
      else
      {
        buLogMarbleVer5.addToLog(this.sClass, str1, "MasterLanguageDB.dll", "Password File is Missing");
        buString5.MessageBoxWarning(buLangTranslate.preSentences.LanguageFileMissing);
      }
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "clsFiles.OpenLanguageFiles");
      if (new FileInfo(AppPath.Base + "\\_offline.dll").Exists)
        AppBool.Offline = true;
      clsFiles.OpenParameterLess(AppPath.MachineSettingsCam);
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "clsFiles.OpenParameter");
      clsFiles.OpenMacroFile(AppPath.User + "\\Macro.bumacro");
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "clsFiles.OpenMacroFile");
      clsFiles.OpenShortKeyFile(AppPath.User + "\\ShortKey.bukey");
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "clsFiles.OpenShortKeyFile");
      this.OpenLanguageFiles(clsVar.varRuntime.Language);
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "OpenLanguageFiles");
      this.OpenDefinationFile();
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", "OpenDefinationFile");
      this.timInit.Interval = 1000;
      this.timInit.Tick += new EventHandler(this.tick_InitTimer);
      this.timInit.Enabled = true;
      clsItem.FrmIntro = this;
      buLogMarbleVer5.addToLog(this.sClass, str1, "Finished", nameof (FIntro_Load));
    }
    catch (Exception ex)
    {
      this.timInit.Enabled = false;
      buLogMarbleVer5.addToLog(this.sClass, str1, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str1, true, "");
    }
  }

  private void tick_InitTimer(object sender, EventArgs e)
  {
    string str = nameof (tick_InitTimer);
    try
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Started");
      this.timInit.Enabled = false;
      this.timSystemReady.Interval = 500;
      this.timSystemReady.Tick += new EventHandler(this.tick_SystemReady);
      if (clsVar.varRuntime.MachineID == 1 | clsVar.varRuntime.MachineID == 2 | clsVar.varRuntime.MachineID == 3 | clsVar.varRuntime.MachineID == 4 | clsVar.varRuntime.MachineID == 5 | clsVar.varRuntime.MachineID == 6 | clsVar.varRuntime.MachineID == 8 | clsVar.varRuntime.MachineID == 10)
      {
        if (clsItem.FrmMach1 == null)
          clsItem.FrmMach1 = new F_Machine1();
        if (new FileInfo(AppPath.MachineImage + "\\AppIcon.ico").Exists)
        {
          clsItem.FrmMach1.Icon = new Icon(AppPath.MachineImage + "\\AppIcon.ico");
          clsItem.FrmMach1.Refresh();
          clsItem.FrmMach1.Invalidate();
        }
        buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OpenParameter");
        F_Intro.appMachine1.OpenParameter();
        F_Intro.appMachine1.AppMarbleClassInit();
        clsItem.FrmMach1.lbl_programname.Text = clsVar.appDefination.Name;
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OpenParameter");
        if (!AppBool.Offline)
        {
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
          {
            F_Intro.cHandler = new buPLCHandler();
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "PLCHanderInit");
            clsAppMarbleVars.cmdMarble.PLCHanderInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine1.ThreadLoop));
            clsItem.threadCommunication.Start();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "PLCHanderInit");
          }
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
          {
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OPCUAInit");
            clsAppMarbleVars.cmdMarble.OPCUAInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine1.ThreadLoop));
            clsItem.threadCommunication.Start();
            Task.Run((Action) (() => OpcVars.opcClient.ConnectAsync().Wait()));
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OPCUAInit");
          }
        }
        if (F_Intro.CompanyImage != null)
          clsItem.FrmMach1.pic_imagecompany.Image = F_Intro.CompanyImage;
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished");
        this.timSystemReady.Enabled = true;
      }
      else if (clsVar.varRuntime.MachineID == 7)
      {
        if (clsItem.FrmMach2 == null)
          clsItem.FrmMach2 = new F_Machine2();
        buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OpenParameter");
        F_Intro.appMachine2.OpenParameter();
        F_Intro.appMachine2.AppMarbleClassInit();
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OpenParameter");
        if (!AppBool.Offline)
        {
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
          {
            F_Intro.cHandler = new buPLCHandler();
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "PLCHanderInit");
            clsAppMarbleVars.cmdMarble.PLCHanderInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine2.ThreadLoop));
            clsItem.threadCommunication.Start();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "PLCHanderInit");
          }
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
          {
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OPCUAInit");
            clsAppMarbleVars.cmdMarble.OPCUAInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine2.ThreadLoop));
            clsItem.threadCommunication.Start();
            Task.Run((Action) (() => OpcVars.opcClient.ConnectAsync().Wait()));
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OPCUAInit");
          }
        }
        if (F_Intro.CompanyImage == null)
          ;
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished");
        this.timSystemReady.Enabled = true;
      }
      else if (clsVar.varRuntime.MachineID == 9)
      {
        if (clsItem.FrmMach1 == null)
          clsItem.FrmMach1 = new F_Machine1();
        buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OpenParameter");
        F_Intro.appMachine3.OpenParameter();
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OpenParameter");
        if (!AppBool.Offline)
        {
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
          {
            F_Intro.cHandler = new buPLCHandler();
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "PLCHanderInit");
            clsAppMarbleVars.cmdMarble.PLCHanderInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine3.ThreadLoop));
            clsItem.threadCommunication.Start();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "PLCHanderInit");
          }
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
          {
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OPCUAInit");
            clsAppMarbleVars.cmdMarble.OPCUAInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine3.ThreadLoop));
            clsItem.threadCommunication.Start();
            Task.Run((Action) (() => OpcVars.opcClient.ConnectAsync().Wait()));
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OPCUAInit");
          }
        }
        if (F_Intro.CompanyImage != null)
          clsItem.FrmMach1.pic_imagecompany.Image = F_Intro.CompanyImage;
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished");
        this.timSystemReady.Enabled = true;
      }
      else if (clsVar.varRuntime.MachineID == 31 /*0x1F*/)
      {
        if (clsItem.FrmMach3Milling == null)
          clsItem.FrmMach3Milling = new F_Machine3_Milling();
        buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OpenParameter");
        F_Intro.appMachine3Milling.OpenParameter();
        F_Intro.appMachine3Milling.AppMarbleClassInit();
        clsItem.FrmMach3Milling.lbl_programname.Text = clsVar.appDefination.Name;
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OpenParameter");
        if (!AppBool.Offline)
        {
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
          {
            F_Intro.cHandler = new buPLCHandler();
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "PLCHanderInit");
            clsAppMarbleVars.cmdMarble.PLCHanderInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine1.ThreadLoop));
            clsItem.threadCommunication.Start();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "PLCHanderInit");
          }
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
          {
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "OPCUAInit");
            clsAppMarbleVars.cmdMarble.OPCUAInit(false);
            clsItem.threadCommunication = new Thread(new ThreadStart(F_Intro.appMachine1.ThreadLoop));
            clsItem.threadCommunication.Start();
            Task.Run((Action) (() => OpcVars.opcClient.ConnectAsync().Wait()));
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "OPCUAInit");
          }
        }
        if (F_Intro.CompanyImage != null)
          clsItem.FrmMach3Milling.pic_imagecompany.Image = F_Intro.CompanyImage;
        buLogMarbleVer5.addToLog(this.sClass, str, "Finished");
        this.timSystemReady.Enabled = true;
      }
      else
        this.timInit.Enabled = false;
    }
    catch (Exception ex)
    {
      this.timInit.Enabled = false;
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  private void tick_SystemReady(object sender, EventArgs e)
  {
    string str = nameof (tick_SystemReady);
    try
    {
      if (this.InitCnt == 0)
        buLogMarbleVer5.addToLog(this.sClass, str, "Started");
      ++this.InitCnt;
      int num1 = 0;
      if (this.InitCnt >= 50)
      {
        AppBool.Offline = true;
        AppBool.Connected = false;
      }
      if (AppBool.Offline)
      {
        buLogMarbleVer5.addToLog(this.sClass, str, "Started", "Offline = true");
        this.Visible = false;
        this.timSystemReady.Enabled = false;
        this.TopMost = false;
        this.Visible = false;
        if (clsVar.varRuntime.MachineID == 1 | clsVar.varRuntime.MachineID == 2 | clsVar.varRuntime.MachineID == 3 | clsVar.varRuntime.MachineID == 4 | clsVar.varRuntime.MachineID == 5 | clsVar.varRuntime.MachineID == 6 | clsVar.varRuntime.MachineID == 8 | clsVar.varRuntime.MachineID == 10)
        {
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 1");
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
          F_Intro.appMachine1.SystemInit();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
          if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
            clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
          clsItem.FrmMach1.Show();
          clsItem.FrmMach1.Init();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Offline");
        }
        else if (clsVar.varRuntime.MachineID == 7)
        {
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 7");
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
          F_Intro.appMachine2.SystemInit();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
          if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
            clsItem.FrmMach2.WindowState = FormWindowState.Maximized;
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
          clsItem.FrmMach2.Show();
          clsItem.FrmMach2.Init();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Offline");
        }
        else if (clsVar.varRuntime.MachineID == 9)
        {
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 7");
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
          F_Intro.appMachine3.SystemInit();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
          if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
            clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
          clsItem.FrmMach1.Show();
          clsItem.FrmMach1.Init();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Offline");
        }
        else
        {
          if (clsVar.varRuntime.MachineID != 31 /*0x1F*/)
            return;
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 1");
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
          F_Intro.appMachine3Milling.SystemInit();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
          if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
            clsItem.FrmMach3Milling.WindowState = FormWindowState.Maximized;
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
          clsItem.FrmMach3Milling.Show();
          clsItem.FrmMach3Milling.Init();
          buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Offline");
        }
      }
      else
      {
        buLogMarbleVer5.addToLog(this.sClass, str, "Started", "Offline = false");
        if (clsVar.varRuntime.MachineID == 1 | clsVar.varRuntime.MachineID == 2 | clsVar.varRuntime.MachineID == 3 | clsVar.varRuntime.MachineID == 4 | clsVar.varRuntime.MachineID == 5 | clsVar.varRuntime.MachineID == 6 | clsVar.varRuntime.MachineID == 8 | clsVar.varRuntime.MachineID == 10)
        {
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 1");
          int num2 = 0;
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
            num2 = buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref num1);
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA & OpcVars.opcClient != null && OpcVars.opcClient.IsConnected)
          {
            num1 = 0;
            OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref num1);
            AppBool.Connected = true;
          }
          if (num1 > 0)
          {
            string Message = "";
            if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
              num2 = buPLCHandler.ReadVariableSTRING("Application.gvlGlobal.sysRun.DeviceData.InfoText", ref Message);
            if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA & OpcVars.opcClient != null && OpcVars.opcClient.IsConnected)
              OPCReadWrite.ReadSTRINGValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.DeviceData.InfoText", ref Message);
            if (Message.Trim().Length > 0 & this.CntLicense == 0)
            {
              ++this.CntLicense;
              buDialogMessageBoxOk dialogMessageBoxOk = new buDialogMessageBoxOk();
              dialogMessageBoxOk.StartPosition = FormStartPosition.CenterScreen;
              dialogMessageBoxOk.Init($"{buLangTranslate.preDef.License} {buLangTranslate.preDef.Information}", Message);
              dialogMessageBoxOk.TopMost = true;
              dialogMessageBoxOk.Show();
            }
            this.Visible = false;
            this.timSystemReady.Enabled = false;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
            F_Intro.appMachine1.SystemInit();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
            this.TopMost = false;
            this.Visible = false;
            if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
              clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
            clsItem.FrmMach1.Show();
            clsItem.FrmMach1.Init();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Online");
          }
        }
        else if (clsVar.varRuntime.MachineID == 7)
        {
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 7");
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
            buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref num1);
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA & OpcVars.opcClient != null && OpcVars.opcClient.IsConnected)
          {
            num1 = 0;
            OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref num1);
            AppBool.Connected = true;
          }
          if (num1 > 0)
          {
            this.Visible = false;
            this.timSystemReady.Enabled = false;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
            F_Intro.appMachine2.SystemInit();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
            this.TopMost = false;
            this.Visible = false;
            if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
              clsItem.FrmMach2.WindowState = FormWindowState.Maximized;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
            clsItem.FrmMach2.Show();
            clsItem.FrmMach2.Init();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Online");
          }
        }
        else if (clsVar.varRuntime.MachineID == 9)
        {
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 9");
          int num3 = 0;
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
            num3 = buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref num1);
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA & OpcVars.opcClient != null && OpcVars.opcClient.IsConnected)
          {
            num1 = 0;
            OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref num1);
            AppBool.Connected = true;
          }
          if (num1 > 0)
          {
            this.Visible = false;
            this.timSystemReady.Enabled = false;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
            F_Intro.appMachine3.SystemInit();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
            this.TopMost = false;
            this.Visible = false;
            if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
              clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
            clsItem.FrmMach1.Show();
            clsItem.FrmMach1.Init();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Online");
          }
        }
        else if (clsVar.varRuntime.MachineID == 31 /*0x1F*/)
        {
          buLogMarbleVer5.addToLog(this.sClass, str, "Started", "MAchineID = 1");
          int num4 = 0;
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
            num4 = buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref num1);
          if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA & OpcVars.opcClient != null && OpcVars.opcClient.IsConnected)
          {
            num1 = 0;
            OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref num1);
            AppBool.Connected = true;
          }
          if (num1 > 0)
          {
            this.Visible = false;
            this.timSystemReady.Enabled = false;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "SystemInit");
            F_Intro.appMachine3Milling.SystemInit();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "SystemInit");
            this.TopMost = false;
            this.Visible = false;
            if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
              clsItem.FrmMach3Milling.WindowState = FormWindowState.Maximized;
            buLogMarbleVer5.addToLog(this.sClass, str, "Started", "FormShow");
            clsItem.FrmMach3Milling.Show();
            clsItem.FrmMach3Milling.Init();
            buLogMarbleVer5.addToLog(this.sClass, str, "Finished", "Online");
          }
        }
      }
    }
    catch (Exception ex)
    {
      this.timSystemReady.Enabled = false;
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void OpenLanguageFiles(int LangSelect)
  {
    string str = nameof (OpenLanguageFiles);
    try
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Started");
      GC.Collect();
      buLogMarbleVer5.addToLog(this.sClass, str, "Finished");
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void OpenDefinationFile()
  {
    string str = nameof (OpenDefinationFile);
    try
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Started");
      clsVar.appDefination.Name = "CMD Mermer CNC";
      clsVar.appDefination.Description = "";
      clsVar.appDefination.Vendor = "CMD Yazılım";
      clsVar.appDefination.Mode = "";
      clsVar.appDefination.Web = "www.cmdsoft.com.tr/";
      FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\UIDef.dll");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile5.OpenFromFile(fileInfo.FullName, ref StringList);
        if (StringList.Count >= 1)
        {
          string[] strArray = StringList[0].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.Name = strArray[1].Trim();
        }
        if (StringList.Count >= 2)
        {
          string[] strArray = StringList[1].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.Description = strArray[1].Trim();
        }
        if (StringList.Count >= 3)
        {
          string[] strArray = StringList[2].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.Vendor = strArray[1].Trim();
        }
        if (StringList.Count >= 4)
        {
          string[] strArray = StringList[3].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.Mode = strArray[1].Trim();
        }
        if (StringList.Count >= 5)
        {
          string[] strArray = StringList[4].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.Web = strArray[1].Trim();
        }
        if (StringList.Count >= 6)
        {
          string[] strArray = StringList[5].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.MachineNo = strArray[1].Trim();
        }
        if (StringList.Count >= 7)
        {
          string[] strArray = StringList[6].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.MachineSerial = strArray[1].Trim();
        }
        if (StringList.Count >= 8)
        {
          string[] strArray = StringList[7].Split(':');
          if (strArray.Length >= 2)
            clsVar.appDefination.MachineName = strArray[1].Trim();
        }
      }
      this.lbl_appname.Text = clsVar.appDefination.Name;
      this.lbl_ver.Text = "Version : " + Application.ProductVersion;
      this.lbl_vendor.Text = clsVar.appDefination.Vendor;
      this.lbl_web.Text = clsVar.appDefination.Web;
      this.lbl_machineinfo.Text = clsVar.appDefination.MachineNo.Trim();
      if (this.lbl_machineinfo.Text.Length > 0)
        this.lbl_machineinfo.Text = $"{this.lbl_machineinfo.Text} - {clsVar.appDefination.MachineSerial.Trim()}";
      if (clsVar.appDefination.MachineSerial.Trim().Length > 0)
        this.lbl_machineinfo.Text = $"{this.lbl_machineinfo.Text} - {clsVar.appDefination.MachineName.Trim()}";
      if (this.lbl_machineinfo.Text.Trim().Length > 0)
        this.lbl_machineinfo.Visible = true;
      buLogMarbleVer5.addToLog(this.sClass, str, "Finished");
      Application.DoEvents();
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void CloseProgram()
  {
    string str = nameof (CloseProgram);
    try
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Started");
      Environment.Exit(0);
    }
    catch (Exception ex)
    {
      buLogMarbleVer5.addToLog(this.sClass, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_Intro));
    this.lbl_vendor = new Label();
    this.lbl_web = new Label();
    this.lbl_ver = new Label();
    this.lbl_appname = new Label();
    this.lbl_machineinfo = new Label();
    this.pic_intro = new PictureBox();
    ((ISupportInitialize) this.pic_intro).BeginInit();
    this.SuspendLayout();
    this.lbl_vendor.BackColor = Color.Transparent;
    this.lbl_vendor.Font = new Font("Times New Roman", 13.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.lbl_vendor.ForeColor = Color.WhiteSmoke;
    this.lbl_vendor.Location = new Point(142, 443);
    this.lbl_vendor.Name = "lbl_vendor";
    this.lbl_vendor.Size = new Size(248, 29);
    this.lbl_vendor.TabIndex = 15;
    this.lbl_vendor.Text = "CMD Software && Automation | ";
    this.lbl_vendor.TextAlign = ContentAlignment.MiddleCenter;
    this.lbl_vendor.Visible = false;
    this.lbl_web.BackColor = Color.Transparent;
    this.lbl_web.Font = new Font("Times New Roman", 13.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.lbl_web.ForeColor = Color.WhiteSmoke;
    this.lbl_web.Location = new Point(388, 443);
    this.lbl_web.Name = "lbl_web";
    this.lbl_web.Size = new Size(172, 29);
    this.lbl_web.TabIndex = 14;
    this.lbl_web.Text = "www.cmdsoft.com.tr";
    this.lbl_web.TextAlign = ContentAlignment.MiddleCenter;
    this.lbl_web.Visible = false;
    this.lbl_ver.BackColor = Color.Transparent;
    this.lbl_ver.Font = new Font("Times New Roman", 13.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.lbl_ver.Location = new Point(214, 53);
    this.lbl_ver.Name = "lbl_ver";
    this.lbl_ver.Size = new Size(166, 28);
    this.lbl_ver.TabIndex = 13;
    this.lbl_ver.TextAlign = ContentAlignment.MiddleCenter;
    this.lbl_appname.BackColor = Color.Transparent;
    this.lbl_appname.Font = new Font("Times New Roman", 13.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.lbl_appname.Location = new Point(140, 15);
    this.lbl_appname.Name = "lbl_appname";
    this.lbl_appname.Size = new Size(315, 22);
    this.lbl_appname.TabIndex = 12;
    this.lbl_appname.TextAlign = ContentAlignment.MiddleCenter;
    this.lbl_machineinfo.BackColor = Color.Transparent;
    this.lbl_machineinfo.Font = new Font("Times New Roman", 13.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    this.lbl_machineinfo.Location = new Point(118, 97);
    this.lbl_machineinfo.Name = "lbl_machineinfo";
    this.lbl_machineinfo.Size = new Size(358, 22);
    this.lbl_machineinfo.TabIndex = 16 /*0x10*/;
    this.lbl_machineinfo.TextAlign = ContentAlignment.MiddleCenter;
    this.pic_intro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.pic_intro.Location = new Point(-1, -2);
    this.pic_intro.Name = "pic_intro";
    this.pic_intro.Size = new Size(601, 492);
    this.pic_intro.SizeMode = PictureBoxSizeMode.StretchImage;
    this.pic_intro.TabIndex = 17;
    this.pic_intro.TabStop = false;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.White;
    this.BackgroundImageLayout = ImageLayout.Stretch;
    this.ClientSize = new Size(600, 488);
    this.Controls.Add((Control) this.pic_intro);
    this.Controls.Add((Control) this.lbl_machineinfo);
    this.Controls.Add((Control) this.lbl_vendor);
    this.Controls.Add((Control) this.lbl_web);
    this.Controls.Add((Control) this.lbl_ver);
    this.Controls.Add((Control) this.lbl_appname);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.Margin = new Padding(2);
    this.Name = nameof (F_Intro);
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "Intro";
    this.Load += new EventHandler(this.FIntro_Load);
    ((ISupportInitialize) this.pic_intro).EndInit();
    this.ResumeLayout(false);
  }
}
