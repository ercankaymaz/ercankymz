using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Controls;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;

namespace buMarble.Forms;

public class F_MarbleCameraSettings : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer m__0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal PictureBox _0001;

	internal buLabel _0001;

	internal buLabel _0002;

	internal buLabel _0003;

	public buCheckBox chk_CameraPowerAvailable;

	public buTab buTab_tools;

	public TabPage tabPage_motion;

	public TabPage tabPage_progra;

	public buButton btn_Programsettings;

	public buButton btn_motionSetting;

	public buSpin spn_CameraPositionX;

	public buButton btn_camreraparkgetpos;

	public buCheckBox chk_CameraCoverAvailable;

	public buSpin spn_CameraPositionY;

	public buCheckBox chk_CameraCoverAutoCloseEnable;

	public buSpin spn_CameraPositionZ;

	public buCheckBox chk_CameraAutoCloseEnable;

	public buSpin spn_CameraPositionC;

	public buSpin spn_CameraAutoCloseTimeSec;

	public buSpin spn_CameraPositionA;

	public buSpin spn_CameraTableYOffsetPos;

	public buSpin spn_CameraPosTimeOutSec;

	public buSpin spn_CameraEnableTimeSec;

	public buSpin spn_CameraTableXOffsetPos;

	public buSpin spn_CameraCoverOpenTimeSec;

	public buSpin spn_cropx;

	public buSpin spn_cropy;

	public buSpin spn_cropWidth;

	public buSpin spn_cropHeight;

	public buSpin spn_cameraexposure;

	public buSpin spn_imageoffsetX;

	public buSpin spn_imageoffsety;

	public buCheckBox chk_sameimagetoArchive;

	public buCheckBox chk_autolenscalibrationfromslabthickness;

	public buSpin spn_imageheight;

	public buSpin spn_imagewidth;

	[NonSerialized]
	internal static GetString _0010;

	public F_MarbleCameraSettings()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D._008F_0007(this, PropertiesForm.Height);
		}
		bool flag = default(bool);
		do
		{
			bool num = PropertiesForm.Width > 10;
			if (0 == 0)
			{
				flag = num;
			}
			if (flag)
			{
				global::_008D._008E_0007(this, PropertiesForm.Width);
			}
			global::_0082._008D_0005(this, PropertiesForm.TopMost);
			global::_009C._001A_0008(this, PropertiesForm.FormPosition);
			global::_008C._007E_0002_0007(buTab_tools, new Size(1, 1));
			global::_008B._007E_0088_0006(tabPage_motion, _0010(107399548));
			global::_008B._007E_0088_0006(tabPage_progra, _0010(107399548));
			global::_0095._007E_0008_0008(spn_CameraPosTimeOutSec, clsAppMarbleVars.varApp.CameraPosTimeOutSec);
			global::_0095._007E_0008_0008(spn_CameraTableXOffsetPos, clsAppMarbleVars.varApp.CameraTableXOffsetPos);
			global::_0095._007E_0008_0008(spn_CameraTableYOffsetPos, clsAppMarbleVars.varApp.CameraTableYOffsetPos);
			global::_0095._007E_0008_0008(spn_CameraPositionA, clsAppMarbleVars.varApp.CameraPositionA);
			global::_0095._007E_0008_0008(spn_CameraPositionC, clsAppMarbleVars.varApp.CameraPositionC);
			global::_0095._007E_0008_0008(spn_CameraPositionX, clsAppMarbleVars.varApp.CameraPositionX);
			global::_0095._007E_0008_0008(spn_CameraPositionY, clsAppMarbleVars.varApp.CameraPositionY);
			global::_0095._007E_0008_0008(spn_CameraPositionZ, clsAppMarbleVars.varApp.CameraPositionZ);
			global::_0095._007E_0008_0008(spn_CameraAutoCloseTimeSec, clsAppMarbleVars.varApp.CameraAutoCloseTimeSec);
			global::_0095._007E_0008_0008(spn_CameraCoverOpenTimeSec, clsAppMarbleVars.varApp.CameraCoverOpenTimeSec);
			global::_0095._007E_0008_0008(spn_CameraEnableTimeSec, clsAppMarbleVars.varApp.CameraEnableTimeSec);
			global::_0082._007E_0089_0005(chk_CameraAutoCloseEnable, clsAppMarbleVars.varApp.CameraAutoCloseEnable);
			global::_0082._007E_0089_0005(chk_CameraCoverAutoCloseEnable, clsAppMarbleVars.varApp.CameraCoverAutoCloseEnable);
		}
		while (false);
		global::_0082._007E_0089_0005(chk_CameraCoverAvailable, clsAppMarbleVars.varApp.CameraCoverAvailable);
		global::_0082._007E_0089_0005(chk_CameraPowerAvailable, clsAppMarbleVars.varApp.CameraPowerAvailable);
		global::_0095._007E_0008_0008(spn_cropx, buMarbleCalc.varMarbleSettings.CameraCropX);
		global::_0095._007E_0008_0008(spn_cropy, buMarbleCalc.varMarbleSettings.CameraCropY);
		global::_0095._007E_0008_0008(spn_cropWidth, buMarbleCalc.varMarbleSettings.CameraCropWidth);
		global::_0095._007E_0008_0008(spn_cropHeight, buMarbleCalc.varMarbleSettings.CameraCropHeight);
		global::_0095._007E_0008_0008(spn_imagewidth, buMarbleCalc.varMarbleSettings.CameraImageWidth);
		global::_0095._007E_0008_0008(spn_imageheight, buMarbleCalc.varMarbleSettings.CameraImageHeight);
		global::_0095._007E_0008_0008(spn_imageoffsetX, buMarbleCalc.varMarbleSettings.CameraImageOffsetX);
		global::_0095._007E_0008_0008(spn_imageoffsety, buMarbleCalc.varMarbleSettings.CameraImageOffsetY);
		global::_0095._007E_0008_0008(spn_cameraexposure, buMarbleCalc.varMarbleSettings.CameraExposure);
		global::_0082._007E_0089_0005(chk_sameimagetoArchive, buMarbleCalc.varMarbleSettings.CopyImageToArchive);
		global::_0082._007E_0089_0005(chk_autolenscalibrationfromslabthickness, buMarbleCalc.varMarbleSettings.AutoLensCalibrationFromMaterialHeight);
		_0005._0003._0001(this);
		if (!PropertiesForm.VisualUpdated)
		{
			InitVisual();
		}
		MenuButtonColors(0);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void InitVisual()
	{
		FileInfo fileInfo2 = default(FileInfo);
		while (true)
		{
			FileInfo fileInfo = new FileInfo(global::_0002._0003(AppPath.MachineSettings, _0010(107374860)));
			if (0 == 0)
			{
				fileInfo2 = fileInfo;
			}
			if (!global::_0003._007E_0004(fileInfo2))
			{
				break;
			}
			Control.ControlCollection controlCollection = null;
			controlCollection = global::_0098._007E_0015_0008(buGround1);
			controlCollection = _0099_0006._001D_0013(controlCollection);
			if (6u != 0)
			{
				controlCollection = global::_0098._007E_0015_0008(tabPage_motion);
				controlCollection = _0099_0006._001D_0013(global::_0098._007E_0015_0008(tabPage_motion));
				controlCollection = global::_0098._007E_0015_0008(tabPage_progra);
				controlCollection = _0099_0006._001D_0013(controlCollection);
				break;
			}
		}
		PropertiesForm.VisualUpdated = true;
	}

	internal void _0001(object P_0, FormClosingEventArgs P_1)
	{
		while (true)
		{
			bool num = PropertiesForm.Result == DialogResult.OK;
			if (-1 == 0)
			{
				goto IL_0069;
			}
			bool num2 = !num;
			goto IL_00ab;
			IL_00ab:
			bool flag = num2;
			num = flag;
			if (0 == 0)
			{
				if (!num)
				{
					break;
				}
				if (false)
				{
					continue;
				}
				global::_0082._007E_009C_0005(P_1, true);
				PropertiesForm.Result = DialogResult.Cancel;
				bool flag2;
				do
				{
					flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
				}
				while (6 == 0);
				num = flag2;
			}
			goto IL_0069;
			IL_0069:
			if (num)
			{
				global::_0011._001D_0003(this);
				if (8 == 0)
				{
					break;
				}
			}
			num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			if (8 == 0)
			{
				goto IL_00ab;
			}
			if (num2)
			{
				global::_0082._0086_0005(this, false);
			}
			break;
		}
	}

	public void Apply()
	{
		if (0 == 0)
		{
			clsAppMarbleVars.varApp.CameraPosTimeOutSec = global::_0007._007E_0094(spn_CameraPosTimeOutSec);
			clsAppMarbleVars.varApp.CameraTableXOffsetPos = global::_0007._007E_0094(spn_CameraTableXOffsetPos);
			clsAppMarbleVars.varApp.CameraTableYOffsetPos = global::_0007._007E_0094(spn_CameraTableYOffsetPos);
			clsAppMarbleVars.varApp.CameraPositionA = global::_0007._007E_0094(spn_CameraPositionA);
			clsAppMarbleVars.varApp.CameraPositionC = global::_0007._007E_0094(spn_CameraPositionC);
			clsAppMarbleVars.varApp.CameraPositionX = global::_0007._007E_0094(spn_CameraPositionX);
			clsAppMarbleVars.varApp.CameraPositionY = global::_0007._007E_0094(spn_CameraPositionY);
			clsAppMarbleVars.varApp.CameraPositionZ = global::_0007._007E_0094(spn_CameraPositionZ);
			clsAppMarbleVars.varApp.CameraAutoCloseTimeSec = global::_0007._007E_0094(spn_CameraAutoCloseTimeSec);
			do
			{
				clsAppMarbleVars.varApp.CameraCoverOpenTimeSec = global::_0007._007E_0094(spn_CameraCoverOpenTimeSec);
			}
			while (6 == 0);
			clsAppMarbleVars.varApp.CameraEnableTimeSec = global::_0007._007E_0094(spn_CameraEnableTimeSec);
			clsAppMarbleVars.varApp.CameraAutoCloseEnable = global::_0003._007E_0010(chk_CameraAutoCloseEnable);
			clsAppMarbleVars.varApp.CameraCoverAutoCloseEnable = global::_0003._007E_0010(chk_CameraCoverAutoCloseEnable);
			clsAppMarbleVars.varApp.CameraCoverAvailable = global::_0003._007E_0010(chk_CameraCoverAvailable);
			clsAppMarbleVars.varApp.CameraPowerAvailable = global::_0003._007E_0010(chk_CameraPowerAvailable);
			buMarbleCalc.varMarbleSettings.CameraCropX = (int)global::_0007._007E_0094(spn_cropx);
			do
			{
				buMarbleCalc.varMarbleSettings.CameraCropY = (int)global::_0007._007E_0094(spn_cropy);
				buMarbleCalc.varMarbleSettings.CameraCropWidth = (int)global::_0007._007E_0094(spn_cropWidth);
				buMarbleCalc.varMarbleSettings.CameraCropHeight = (int)global::_0007._007E_0094(spn_cropHeight);
				buMarbleCalc.varMarbleSettings.CameraImageWidth = global::_0007._007E_0094(spn_imagewidth);
				buMarbleCalc.varMarbleSettings.CameraImageHeight = global::_0007._007E_0094(spn_imageheight);
				buMarbleCalc.varMarbleSettings.CameraImageOffsetX = global::_0007._007E_0094(spn_imageoffsetX);
				buMarbleCalc.varMarbleSettings.CameraImageOffsetY = global::_0007._007E_0094(spn_imageoffsety);
			}
			while (3 == 0);
			buMarbleCalc.varMarbleSettings.CameraExposure = (int)global::_0007._007E_0094(spn_cameraexposure);
			buMarbleCalc.varMarbleSettings.CopyImageToArchive = global::_0003._007E_0010(chk_sameimagetoArchive);
		}
		buMarbleCalc.varMarbleSettings.AutoLensCalibrationFromMaterialHeight = global::_0003._007E_0010(chk_autolenscalibrationfromslabthickness);
	}

	public void MenuButtonColors(int PageIndex)
	{
		while (true)
		{
			bool flag2;
			if (7u != 0)
			{
				Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
				bool flag;
				if (0 == 0)
				{
					controlCollection = _0099_0006._001D_0013(controlCollection);
					global::_008D._007E_000F_0007(buTab_tools, PageIndex);
					if (4 == 0)
					{
						continue;
					}
					flag = PageIndex == 0;
				}
				while (true)
				{
					if (0 == 0)
					{
						if (!flag)
						{
							break;
						}
						if (0 == 0)
						{
							btn_motionSetting = _009D_0006._0080_0013(btn_motionSetting, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
							break;
						}
						continue;
					}
					return;
				}
				flag2 = PageIndex == 1;
				goto IL_0098;
			}
			goto IL_009b;
			IL_009b:
			if (0 == 0)
			{
				btn_Programsettings = _009D_0006._0080_0013(btn_Programsettings, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				break;
			}
			goto IL_0098;
			IL_0098:
			if (!flag2)
			{
				break;
			}
			goto IL_009b;
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = new Control();
			control = (Control)P_0;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
			bool num;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel)))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
				if (4 == 0)
				{
					goto IL_020e;
				}
				if (num)
				{
					if (false)
					{
						goto IL_031d;
					}
					global::_0082._0086_0005(this, false);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_motionSetting)))
			{
				MenuButtonColors(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_Programsettings)))
			{
				MenuButtonColors(1);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_camreraparkgetpos)) && AppBool.Connected)
			{
				bool flag = clsAppMarbleVars.varRuntime.AxX >= 0;
				num = flag;
				goto IL_020e;
			}
			return;
			IL_031d:
			if (clsAppMarbleVars.varRuntime.AxC >= 0)
			{
				global::_0095._007E_0008_0008(spn_CameraPositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			if (clsAppMarbleVars.varRuntime.AxA >= 0)
			{
				global::_0095._007E_0008_0008(spn_CameraPositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			return;
			IL_020e:
			if (num)
			{
				global::_0095._007E_0008_0008(spn_CameraPositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			if (clsAppMarbleVars.varRuntime.AxY >= 0)
			{
				global::_0095._007E_0008_0008(spn_CameraPositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			if (clsAppMarbleVars.varRuntime.AxZ >= 0)
			{
				global::_0095._007E_0008_0008(spn_CameraPositionZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			goto IL_031d;
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	protected override void Dispose(bool disposing)
	{
		do
		{
			if (8 == 0)
			{
				goto IL_0025;
			}
			if (!disposing)
			{
				goto IL_0014;
			}
			int num = ((this.m__0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_001A_0002(this.m__0001);
			continue;
			IL_0014:
			num = 0;
			goto IL_004b;
			IL_004b:
			while (true)
			{
				bool flag = (byte)num != 0;
				while (true)
				{
					num = (flag ? 1 : 0);
					if (3 == 0)
					{
						break;
					}
					if (num == 0)
					{
						goto end_IL_004b;
					}
					if (false)
					{
						continue;
					}
					goto IL_0021;
				}
				continue;
				end_IL_004b:
				break;
			}
			continue;
			IL_0021:
			if (1 == 0)
			{
				goto IL_0014;
			}
			goto IL_0025;
		}
		while (false);
		global::_0082._009D_0005(this, disposing);
	}

	static F_MarbleCameraSettings()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleCameraSettings));
		Captions = new List<string>();
	}
}
