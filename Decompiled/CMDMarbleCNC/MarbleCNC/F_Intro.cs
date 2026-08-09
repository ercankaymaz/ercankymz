using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarbleCNC.Machines;
using buCadCamResVer5;
using buClass;
using buControls;
using buControls.DialogBox;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using buHandler;
using buMarble;
using buOpcUA;

namespace MarbleCNC;

public class F_Intro : Form
{
	public static clsMachine1_5Axis appMachine1 = new clsMachine1_5Axis();

	public static clsMachine2_Ozteknik appMachine2 = new clsMachine2_Ozteknik();

	public static clsMachine3_Milling appMachine3Milling = new clsMachine3_Milling();

	public static clsMachine3_10AxisDoubleHead appMachine3 = new clsMachine3_10AxisDoubleHead();

	public static buPLCHandler cHandler = null;

	private string sClass = "F_Intro";

	public static Image ProgramImage = null;

	public static Image CompanyImage = null;

	private System.Windows.Forms.Timer timInit = new System.Windows.Forms.Timer();

	private System.Windows.Forms.Timer timSystemReady = new System.Windows.Forms.Timer();

	private int InitCnt;

	private int CntLicense = 0;

	private IContainer components = null;

	private Label lbl_vendor;

	private Label lbl_web;

	private Label lbl_ver;

	private Label lbl_appname;

	private Label lbl_machineinfo;

	private PictureBox pic_intro;

	public F_Intro()
	{
		InitializeComponent();
	}

	private void FIntro_Load(object sender, EventArgs e)
	{
		string text = "FIntro_Load";
		try
		{
			AppBool.MachineMode = true;
			buLogMarbleVer5.addToLog(sClass, text, "Started", "FIntro_Load");
			buControlCommands.CultureSettings();
			AppPath.Base = "D:\\PCProjects\\Generation5\\CMD\\CMDMarbleCNC\\CMDMarbleCNC\\bin\\Common";
			FileInfo fileInfo = new FileInfo(AppPath.Base + "\\_developer.dll");
			if (!fileInfo.Exists)
			{
				AppPath.Base = Application.StartupPath;
			}
			clsFiles.OpenRuntimeAndConfig(UsePathFromUserInfo: false, MW: true);
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenRuntimeAndConfig");
			Task.Run(delegate
			{
				buLogVer5.checkLogFileSize();
			});
			Task.Run(delegate
			{
				buLogMarbleVer5.checkLogFileSize();
			});
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "checkLogFileSize");
			AppPath.MachinePostProcessor = AppPath.MachineSettings;
			AppPath.MachineKinematic = AppPath.MachineSettings;
			ProgramImage = clsFiles.OpenIntroImage(AppPath.MachineImage);
			if (ProgramImage != null)
			{
				pic_intro.Image = ProgramImage;
			}
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenIntroImage");
			CompanyImage = clsFiles.OpenCompanyImage(AppPath.MachineImage);
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenCompanyImage");
			fileInfo = new FileInfo(AppPath.MachineImage + "\\AppIcon.ico");
			if (fileInfo.Exists)
			{
				base.Icon = new Icon(AppPath.MachineImage + "\\AppIcon.ico");
				Refresh();
				Invalidate();
			}
			fileInfo = new FileInfo(AppPath.MachineSettings + "\\_psw.cspass");
			if (fileInfo.Exists)
			{
				buFile5.OpenPasswordCS(fileInfo.FullName, 7.48);
			}
			else
			{
				fileInfo = new FileInfo(AppPath.Base + "\\_psw.cspass");
				if (fileInfo.Exists)
				{
					buFile5.OpenPassword(fileInfo.FullName, 6.98);
				}
				else
				{
					buLogMarbleVer5.addToLog(sClass, text, "Password", "Password File is Missing");
					buString5.MessageBoxWarning(buLangTranslate.preSentences.PasswordFileMissing);
				}
			}
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenPassword");
			string text2 = Path.Combine(Application.StartupPath, "MasterLanguageDB.dll");
			clsFiles.OpenLanguageFiles(clsVar.varRuntime.Language);
			if (File.Exists(text2))
			{
				buLangTranslate.InitializeDatabase(text2);
				if (clsVar.varRuntime.Language == 0)
				{
					buLangTranslate.ChangeLanguage("English");
				}
				else if (clsVar.varRuntime.Language == 1)
				{
					buLangTranslate.ChangeLanguage("Turkish");
				}
				else if (clsVar.varRuntime.Language == 2)
				{
					buLangTranslate.ChangeLanguage("Chinese");
				}
			}
			else
			{
				buLogMarbleVer5.addToLog(sClass, text, "MasterLanguageDB.dll", "Password File is Missing");
				buString5.MessageBoxWarning(buLangTranslate.preSentences.LanguageFileMissing);
			}
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "clsFiles.OpenLanguageFiles");
			fileInfo = new FileInfo(AppPath.Base + "\\_offline.dll");
			if (fileInfo.Exists)
			{
				AppBool.Offline = true;
			}
			clsFiles.OpenParameterLess(AppPath.MachineSettingsCam);
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "clsFiles.OpenParameter");
			clsFiles.OpenMacroFile(AppPath.User + "\\Macro.bumacro");
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "clsFiles.OpenMacroFile");
			clsFiles.OpenShortKeyFile(AppPath.User + "\\ShortKey.bukey");
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "clsFiles.OpenShortKeyFile");
			OpenLanguageFiles(clsVar.varRuntime.Language);
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenLanguageFiles");
			OpenDefinationFile();
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenDefinationFile");
			timInit.Interval = 1000;
			timInit.Tick += tick_InitTimer;
			timInit.Enabled = true;
			clsItem.FrmIntro = this;
			buLogMarbleVer5.addToLog(sClass, text, "Finished", "FIntro_Load");
		}
		catch (Exception ex)
		{
			timInit.Enabled = false;
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	private void tick_InitTimer(object sender, EventArgs e)
	{
		string text = "tick_InitTimer";
		try
		{
			buLogMarbleVer5.addToLog(sClass, text, "Started");
			timInit.Enabled = false;
			timSystemReady.Interval = 500;
			timSystemReady.Tick += tick_SystemReady;
			if ((clsVar.varRuntime.MachineID == 1) | (clsVar.varRuntime.MachineID == 2) | (clsVar.varRuntime.MachineID == 3) | (clsVar.varRuntime.MachineID == 4) | (clsVar.varRuntime.MachineID == 5) | (clsVar.varRuntime.MachineID == 6) | (clsVar.varRuntime.MachineID == 8) | (clsVar.varRuntime.MachineID == 10))
			{
				if (clsItem.FrmMach1 == null)
				{
					clsItem.FrmMach1 = new F_Machine1();
				}
				FileInfo fileInfo = new FileInfo(AppPath.MachineImage + "\\AppIcon.ico");
				if (fileInfo.Exists)
				{
					clsItem.FrmMach1.Icon = new Icon(AppPath.MachineImage + "\\AppIcon.ico");
					clsItem.FrmMach1.Refresh();
					clsItem.FrmMach1.Invalidate();
				}
				buLogMarbleVer5.addToLog(sClass, text, "Started", "OpenParameter");
				appMachine1.OpenParameter();
				appMachine1.AppMarbleClassInit();
				clsItem.FrmMach1.lbl_programname.Text = clsVar.appDefination.Name;
				buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenParameter");
				if (!AppBool.Offline)
				{
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
					{
						cHandler = new buPLCHandler();
						buLogMarbleVer5.addToLog(sClass, text, "Started", "PLCHanderInit");
						clsAppMarbleVars.cmdMarble.PLCHanderInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine1.ThreadLoop);
						clsItem.threadCommunication.Start();
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "PLCHanderInit");
					}
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
					{
						buLogMarbleVer5.addToLog(sClass, text, "Started", "OPCUAInit");
						clsAppMarbleVars.cmdMarble.OPCUAInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine1.ThreadLoop);
						clsItem.threadCommunication.Start();
						Task.Run(delegate
						{
							OpcVars.opcClient.ConnectAsync().Wait();
						});
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "OPCUAInit");
					}
				}
				if (CompanyImage != null)
				{
					clsItem.FrmMach1.pic_imagecompany.Image = CompanyImage;
				}
				buLogMarbleVer5.addToLog(sClass, text, "Finished");
				timSystemReady.Enabled = true;
			}
			else if (clsVar.varRuntime.MachineID == 7)
			{
				if (clsItem.FrmMach2 == null)
				{
					clsItem.FrmMach2 = new F_Machine2();
				}
				buLogMarbleVer5.addToLog(sClass, text, "Started", "OpenParameter");
				appMachine2.OpenParameter();
				appMachine2.AppMarbleClassInit();
				buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenParameter");
				if (!AppBool.Offline)
				{
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
					{
						cHandler = new buPLCHandler();
						buLogMarbleVer5.addToLog(sClass, text, "Started", "PLCHanderInit");
						clsAppMarbleVars.cmdMarble.PLCHanderInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine2.ThreadLoop);
						clsItem.threadCommunication.Start();
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "PLCHanderInit");
					}
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
					{
						buLogMarbleVer5.addToLog(sClass, text, "Started", "OPCUAInit");
						clsAppMarbleVars.cmdMarble.OPCUAInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine2.ThreadLoop);
						clsItem.threadCommunication.Start();
						Task.Run(delegate
						{
							OpcVars.opcClient.ConnectAsync().Wait();
						});
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "OPCUAInit");
					}
				}
				if (CompanyImage != null)
				{
				}
				buLogMarbleVer5.addToLog(sClass, text, "Finished");
				timSystemReady.Enabled = true;
			}
			else if (clsVar.varRuntime.MachineID == 9)
			{
				if (clsItem.FrmMach1 == null)
				{
					clsItem.FrmMach1 = new F_Machine1();
				}
				buLogMarbleVer5.addToLog(sClass, text, "Started", "OpenParameter");
				appMachine3.OpenParameter();
				buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenParameter");
				if (!AppBool.Offline)
				{
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
					{
						cHandler = new buPLCHandler();
						buLogMarbleVer5.addToLog(sClass, text, "Started", "PLCHanderInit");
						clsAppMarbleVars.cmdMarble.PLCHanderInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine3.ThreadLoop);
						clsItem.threadCommunication.Start();
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "PLCHanderInit");
					}
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
					{
						buLogMarbleVer5.addToLog(sClass, text, "Started", "OPCUAInit");
						clsAppMarbleVars.cmdMarble.OPCUAInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine3.ThreadLoop);
						clsItem.threadCommunication.Start();
						Task.Run(delegate
						{
							OpcVars.opcClient.ConnectAsync().Wait();
						});
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "OPCUAInit");
					}
				}
				if (CompanyImage != null)
				{
					clsItem.FrmMach1.pic_imagecompany.Image = CompanyImage;
				}
				buLogMarbleVer5.addToLog(sClass, text, "Finished");
				timSystemReady.Enabled = true;
			}
			else if (clsVar.varRuntime.MachineID == 31)
			{
				if (clsItem.FrmMach3Milling == null)
				{
					clsItem.FrmMach3Milling = new F_Machine3_Milling();
				}
				buLogMarbleVer5.addToLog(sClass, text, "Started", "OpenParameter");
				appMachine3Milling.OpenParameter();
				appMachine3Milling.AppMarbleClassInit();
				clsItem.FrmMach3Milling.lbl_programname.Text = clsVar.appDefination.Name;
				buLogMarbleVer5.addToLog(sClass, text, "Finished", "OpenParameter");
				if (!AppBool.Offline)
				{
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
					{
						cHandler = new buPLCHandler();
						buLogMarbleVer5.addToLog(sClass, text, "Started", "PLCHanderInit");
						clsAppMarbleVars.cmdMarble.PLCHanderInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine1.ThreadLoop);
						clsItem.threadCommunication.Start();
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "PLCHanderInit");
					}
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA)
					{
						buLogMarbleVer5.addToLog(sClass, text, "Started", "OPCUAInit");
						clsAppMarbleVars.cmdMarble.OPCUAInit(reconnect: false);
						clsItem.threadCommunication = new Thread(appMachine1.ThreadLoop);
						clsItem.threadCommunication.Start();
						Task.Run(delegate
						{
							OpcVars.opcClient.ConnectAsync().Wait();
						});
						buLogMarbleVer5.addToLog(sClass, text, "Finished", "OPCUAInit");
					}
				}
				if (CompanyImage != null)
				{
					clsItem.FrmMach3Milling.pic_imagecompany.Image = CompanyImage;
				}
				buLogMarbleVer5.addToLog(sClass, text, "Finished");
				timSystemReady.Enabled = true;
			}
			else
			{
				timInit.Enabled = false;
			}
		}
		catch (Exception ex)
		{
			timInit.Enabled = false;
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	private void tick_SystemReady(object sender, EventArgs e)
	{
		string text = "tick_SystemReady";
		try
		{
			if (InitCnt == 0)
			{
				buLogMarbleVer5.addToLog(sClass, text, "Started");
			}
			InitCnt++;
			int Value = 0;
			if (InitCnt >= 50)
			{
				AppBool.Offline = true;
				AppBool.Connected = false;
			}
			if (AppBool.Offline)
			{
				buLogMarbleVer5.addToLog(sClass, text, "Started", "Offline = true");
				base.Visible = false;
				timSystemReady.Enabled = false;
				base.TopMost = false;
				base.Visible = false;
				if ((clsVar.varRuntime.MachineID == 1) | (clsVar.varRuntime.MachineID == 2) | (clsVar.varRuntime.MachineID == 3) | (clsVar.varRuntime.MachineID == 4) | (clsVar.varRuntime.MachineID == 5) | (clsVar.varRuntime.MachineID == 6) | (clsVar.varRuntime.MachineID == 8) | (clsVar.varRuntime.MachineID == 10))
				{
					buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 1");
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine1.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach1.Show();
					clsItem.FrmMach1.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Offline");
				}
				else if (clsVar.varRuntime.MachineID == 7)
				{
					buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 7");
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine2.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach2.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach2.Show();
					clsItem.FrmMach2.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Offline");
				}
				else if (clsVar.varRuntime.MachineID == 9)
				{
					buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 7");
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine3.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach1.Show();
					clsItem.FrmMach1.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Offline");
				}
				else if (clsVar.varRuntime.MachineID == 31)
				{
					buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 1");
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine3Milling.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach3Milling.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach3Milling.Show();
					clsItem.FrmMach3Milling.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Offline");
				}
				return;
			}
			buLogMarbleVer5.addToLog(sClass, text, "Started", "Offline = false");
			if ((clsVar.varRuntime.MachineID == 1) | (clsVar.varRuntime.MachineID == 2) | (clsVar.varRuntime.MachineID == 3) | (clsVar.varRuntime.MachineID == 4) | (clsVar.varRuntime.MachineID == 5) | (clsVar.varRuntime.MachineID == 6) | (clsVar.varRuntime.MachineID == 8) | (clsVar.varRuntime.MachineID == 10))
			{
				buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 1");
				int num = 0;
				if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
				{
					num = buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref Value);
				}
				if (((clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA) & (OpcVars.opcClient != null)) && OpcVars.opcClient.IsConnected)
				{
					Value = 0;
					OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref Value);
					AppBool.Connected = true;
				}
				if (Value > 0)
				{
					string Value2 = "";
					if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
					{
						num = buPLCHandler.ReadVariableSTRING("Application.gvlGlobal.sysRun.DeviceData.InfoText", ref Value2);
					}
					if (((clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA) & (OpcVars.opcClient != null)) && OpcVars.opcClient.IsConnected)
					{
						OPCReadWrite.ReadSTRINGValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.DeviceData.InfoText", ref Value2);
					}
					if ((Value2.Trim().Length > 0) & (CntLicense == 0))
					{
						CntLicense++;
						buDialogMessageBoxOk buDialogMessageBoxOk2 = new buDialogMessageBoxOk();
						buDialogMessageBoxOk2.StartPosition = FormStartPosition.CenterScreen;
						buDialogMessageBoxOk2.Init(buLangTranslate.preDef.License + " " + buLangTranslate.preDef.Information, Value2);
						buDialogMessageBoxOk2.TopMost = true;
						buDialogMessageBoxOk2.Show();
					}
					base.Visible = false;
					timSystemReady.Enabled = false;
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine1.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					base.TopMost = false;
					base.Visible = false;
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach1.Show();
					clsItem.FrmMach1.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Online");
				}
			}
			else if (clsVar.varRuntime.MachineID == 7)
			{
				buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 7");
				if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
				{
					int num2 = buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref Value);
				}
				if (((clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA) & (OpcVars.opcClient != null)) && OpcVars.opcClient.IsConnected)
				{
					Value = 0;
					OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref Value);
					AppBool.Connected = true;
				}
				if (Value > 0)
				{
					base.Visible = false;
					timSystemReady.Enabled = false;
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine2.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					base.TopMost = false;
					base.Visible = false;
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach2.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach2.Show();
					clsItem.FrmMach2.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Online");
				}
			}
			else if (clsVar.varRuntime.MachineID == 9)
			{
				buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 9");
				int num3 = 0;
				if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
				{
					num3 = buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref Value);
				}
				if (((clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA) & (OpcVars.opcClient != null)) && OpcVars.opcClient.IsConnected)
				{
					Value = 0;
					OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref Value);
					AppBool.Connected = true;
				}
				if (Value > 0)
				{
					base.Visible = false;
					timSystemReady.Enabled = false;
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine3.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					base.TopMost = false;
					base.Visible = false;
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach1.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach1.Show();
					clsItem.FrmMach1.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Online");
				}
			}
			else
			{
				if (clsVar.varRuntime.MachineID != 31)
				{
					return;
				}
				buLogMarbleVer5.addToLog(sClass, text, "Started", "MAchineID = 1");
				int num4 = 0;
				if (clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.PlcHandler)
				{
					num4 = buPLCHandler.ReadVariableDINT("Application.gvlGlobal.sysRun.stpSteps.Init", ref Value);
				}
				if (((clsAppMarbleVars.cMachine.PLCSettings.CommType == CommunicationType.OPCUA) & (OpcVars.opcClient != null)) && OpcVars.opcClient.IsConnected)
				{
					Value = 0;
					OPCReadWrite.ReadDINTValue(OpcVars.opcClient.Session, OpcVars.pathCodesysGvl + "sysRun.stpSteps.Init", ref Value);
					AppBool.Connected = true;
				}
				if (Value > 0)
				{
					base.Visible = false;
					timSystemReady.Enabled = false;
					buLogMarbleVer5.addToLog(sClass, text, "Started", "SystemInit");
					appMachine3Milling.SystemInit();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "SystemInit");
					base.TopMost = false;
					base.Visible = false;
					if (clsAppMarbleVars.cMachine.ProgramSettings.WindowsMaximize)
					{
						clsItem.FrmMach3Milling.WindowState = FormWindowState.Maximized;
					}
					buLogMarbleVer5.addToLog(sClass, text, "Started", "FormShow");
					clsItem.FrmMach3Milling.Show();
					clsItem.FrmMach3Milling.Init();
					buLogMarbleVer5.addToLog(sClass, text, "Finished", "Online");
				}
			}
		}
		catch (Exception ex)
		{
			timSystemReady.Enabled = false;
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void OpenLanguageFiles(int LangSelect)
	{
		string text = "OpenLanguageFiles";
		try
		{
			buLogMarbleVer5.addToLog(sClass, text, "Started");
			GC.Collect();
			buLogMarbleVer5.addToLog(sClass, text, "Finished");
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void OpenDefinationFile()
	{
		string text = "OpenDefinationFile";
		try
		{
			buLogMarbleVer5.addToLog(sClass, text, "Started");
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
					string[] array = StringList[0].Split(':');
					if (array.Length >= 2)
					{
						clsVar.appDefination.Name = array[1].Trim();
					}
				}
				if (StringList.Count >= 2)
				{
					string[] array2 = StringList[1].Split(':');
					if (array2.Length >= 2)
					{
						clsVar.appDefination.Description = array2[1].Trim();
					}
				}
				if (StringList.Count >= 3)
				{
					string[] array3 = StringList[2].Split(':');
					if (array3.Length >= 2)
					{
						clsVar.appDefination.Vendor = array3[1].Trim();
					}
				}
				if (StringList.Count >= 4)
				{
					string[] array4 = StringList[3].Split(':');
					if (array4.Length >= 2)
					{
						clsVar.appDefination.Mode = array4[1].Trim();
					}
				}
				if (StringList.Count >= 5)
				{
					string[] array5 = StringList[4].Split(':');
					if (array5.Length >= 2)
					{
						clsVar.appDefination.Web = array5[1].Trim();
					}
				}
				if (StringList.Count >= 6)
				{
					string[] array6 = StringList[5].Split(':');
					if (array6.Length >= 2)
					{
						clsVar.appDefination.MachineNo = array6[1].Trim();
					}
				}
				if (StringList.Count >= 7)
				{
					string[] array7 = StringList[6].Split(':');
					if (array7.Length >= 2)
					{
						clsVar.appDefination.MachineSerial = array7[1].Trim();
					}
				}
				if (StringList.Count >= 8)
				{
					string[] array8 = StringList[7].Split(':');
					if (array8.Length >= 2)
					{
						clsVar.appDefination.MachineName = array8[1].Trim();
					}
				}
			}
			lbl_appname.Text = clsVar.appDefination.Name;
			lbl_ver.Text = "Version : " + Application.ProductVersion;
			lbl_vendor.Text = clsVar.appDefination.Vendor;
			lbl_web.Text = clsVar.appDefination.Web;
			lbl_machineinfo.Text = clsVar.appDefination.MachineNo.Trim();
			if (lbl_machineinfo.Text.Length > 0)
			{
				lbl_machineinfo.Text = lbl_machineinfo.Text + " - " + clsVar.appDefination.MachineSerial.Trim();
			}
			if (clsVar.appDefination.MachineSerial.Trim().Length > 0)
			{
				lbl_machineinfo.Text = lbl_machineinfo.Text + " - " + clsVar.appDefination.MachineName.Trim();
			}
			if (lbl_machineinfo.Text.Trim().Length > 0)
			{
				lbl_machineinfo.Visible = true;
			}
			buLogMarbleVer5.addToLog(sClass, text, "Finished");
			Application.DoEvents();
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void CloseProgram()
	{
		string text = "CloseProgram";
		try
		{
			buLogMarbleVer5.addToLog(sClass, text, "Started");
			Environment.Exit(0);
		}
		catch (Exception ex)
		{
			buLogMarbleVer5.addToLog(sClass, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarbleCNC.F_Intro));
		this.lbl_vendor = new System.Windows.Forms.Label();
		this.lbl_web = new System.Windows.Forms.Label();
		this.lbl_ver = new System.Windows.Forms.Label();
		this.lbl_appname = new System.Windows.Forms.Label();
		this.lbl_machineinfo = new System.Windows.Forms.Label();
		this.pic_intro = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.pic_intro).BeginInit();
		base.SuspendLayout();
		this.lbl_vendor.BackColor = System.Drawing.Color.Transparent;
		this.lbl_vendor.Font = new System.Drawing.Font("Times New Roman", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.lbl_vendor.ForeColor = System.Drawing.Color.WhiteSmoke;
		this.lbl_vendor.Location = new System.Drawing.Point(142, 443);
		this.lbl_vendor.Name = "lbl_vendor";
		this.lbl_vendor.Size = new System.Drawing.Size(248, 29);
		this.lbl_vendor.TabIndex = 15;
		this.lbl_vendor.Text = "CMD Software && Automation | ";
		this.lbl_vendor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lbl_vendor.Visible = false;
		this.lbl_web.BackColor = System.Drawing.Color.Transparent;
		this.lbl_web.Font = new System.Drawing.Font("Times New Roman", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.lbl_web.ForeColor = System.Drawing.Color.WhiteSmoke;
		this.lbl_web.Location = new System.Drawing.Point(388, 443);
		this.lbl_web.Name = "lbl_web";
		this.lbl_web.Size = new System.Drawing.Size(172, 29);
		this.lbl_web.TabIndex = 14;
		this.lbl_web.Text = "www.cmdsoft.com.tr";
		this.lbl_web.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lbl_web.Visible = false;
		this.lbl_ver.BackColor = System.Drawing.Color.Transparent;
		this.lbl_ver.Font = new System.Drawing.Font("Times New Roman", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.lbl_ver.Location = new System.Drawing.Point(214, 53);
		this.lbl_ver.Name = "lbl_ver";
		this.lbl_ver.Size = new System.Drawing.Size(166, 28);
		this.lbl_ver.TabIndex = 13;
		this.lbl_ver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lbl_appname.BackColor = System.Drawing.Color.Transparent;
		this.lbl_appname.Font = new System.Drawing.Font("Times New Roman", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.lbl_appname.Location = new System.Drawing.Point(140, 15);
		this.lbl_appname.Name = "lbl_appname";
		this.lbl_appname.Size = new System.Drawing.Size(315, 22);
		this.lbl_appname.TabIndex = 12;
		this.lbl_appname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lbl_machineinfo.BackColor = System.Drawing.Color.Transparent;
		this.lbl_machineinfo.Font = new System.Drawing.Font("Times New Roman", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 162);
		this.lbl_machineinfo.Location = new System.Drawing.Point(118, 97);
		this.lbl_machineinfo.Name = "lbl_machineinfo";
		this.lbl_machineinfo.Size = new System.Drawing.Size(358, 22);
		this.lbl_machineinfo.TabIndex = 16;
		this.lbl_machineinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.pic_intro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pic_intro.Location = new System.Drawing.Point(-1, -2);
		this.pic_intro.Name = "pic_intro";
		this.pic_intro.Size = new System.Drawing.Size(601, 492);
		this.pic_intro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic_intro.TabIndex = 17;
		this.pic_intro.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(600, 488);
		base.Controls.Add(this.pic_intro);
		base.Controls.Add(this.lbl_machineinfo);
		base.Controls.Add(this.lbl_vendor);
		base.Controls.Add(this.lbl_web);
		base.Controls.Add(this.lbl_ver);
		base.Controls.Add(this.lbl_appname);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "F_Intro";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Intro";
		base.Load += new System.EventHandler(FIntro_Load);
		((System.ComponentModel.ISupportInitialize)this.pic_intro).EndInit();
		base.ResumeLayout(false);
	}
}
