using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Controls;
using buEyeBaseVer5;

namespace buMarble.Forms;

public class F_MarbleMDIV2 : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	private string m__0001 = _000F(107376505);

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_stop;

	public buLabel lbl_positions;

	public buLabel lbl_tools;

	public buLabel lbl_camra;

	public buLabel lbl_commands;

	public buButton btn_spindleheadpark;

	public buButton btn_photopos;

	public buButton btn_sawpark;

	public buButton btn_wagonpark;

	public buButton btn_cameraclose;

	public buButton btn_cameraopen;

	public buButton btn_spindlepistondown;

	public buButton btn_spindlepistonup;

	public buButton btn_spindlepark;

	public buButton btn_slabthickness;

	public buButton btn_pensopenclose;

	public buButton btn_toolmagazineopen;

	public buButton btn_toolmagazineClose;

	public buButton btn_rtcp;

	public buButton btn_crousecontrol;

	public buButton btn_gozero;

	public buButton btn_homing;

	public buButton btn_park;

	public buButton btn_camera;

	public buButton btn_water;

	public buButton btn_laser;

	public buButton btn_vacuumclose;

	public buButton btn_vacuumopen;

	public buButton btn_vacuumup;

	public buButton btn_vacuumdown;

	public buLabel lblvacum;

	public Panel pnl_command;

	public Panel pnl_position;

	public Panel pnl_tools;

	public Panel pnl_photo;

	public Panel pnl_vacuum;

	public buButton btn_cameraenable;

	public buButton btn_cameradisable;

	[NonSerialized]
	internal static GetString _000F;

	public F_MarbleMDIV2()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		int num = PropertiesForm.Height;
		int num2 = 10;
		while (true)
		{
			bool flag = num > num2;
			while (true)
			{
				IL_0101:
				if (flag)
				{
					global::_008D._008F_0007(this, PropertiesForm.Height);
				}
				while (true)
				{
					num = PropertiesForm.Width;
					if (4u != 0)
					{
						num2 = 10;
						if (num2 == 0)
						{
							break;
						}
						bool flag2 = num > num2;
						num = (flag2 ? 1 : 0);
					}
					if (num != 0)
					{
						if (5 == 0)
						{
							goto IL_0101;
						}
						global::_008D._008E_0007(this, PropertiesForm.Width);
					}
					while (true)
					{
						global::_0082._008D_0005(this, PropertiesForm.TopMost);
						global::_009C._001A_0008(this, PropertiesForm.FormPosition);
						if (false)
						{
							break;
						}
						PropertiesForm.Result = DialogResult.None;
						if (0 == 0)
						{
							PropertiesForm.Inited = true;
							_0005._0003._0001(this);
							UpdateVisuals();
							if (3 == 0)
							{
								break;
							}
							return;
						}
					}
				}
				break;
			}
		}
	}

	public void UpdateVisuals()
	{
		string text = _000F(107450536);
		try
		{
			bool num;
			if (6u != 0)
			{
				bool flag = buEyeVars.parVisual == null;
				num = flag;
				goto IL_002b;
			}
			goto IL_007c;
			IL_00c5:
			while (-1 == 0)
			{
			}
			_0005._0003._0001(this);
			return;
			IL_002b:
			if (num)
			{
				return;
			}
			FileInfo fileInfo;
			if (!PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce)
			{
				fileInfo = new FileInfo(global::_0002._0003(AppPath.MachineSettings, _000F(107372902)));
				goto IL_007c;
			}
			goto IL_00c5;
			IL_007c:
			bool flag2 = global::_0003._007E_0004(fileInfo);
			num = flag2;
			if (-1 == 0)
			{
				goto IL_002b;
			}
			if (num)
			{
				Control.ControlCollection controlCollection;
				if (0 == 0)
				{
					controlCollection = null;
					controlCollection = global::_0098._007E_0015_0008(buGround1);
				}
				controlCollection = _0099_0006._001D_0013(controlCollection);
				PropertiesForm.VisualUpdated = true;
			}
			goto IL_00c5;
		}
		catch (Exception ex)
		{
			do
			{
				global::_0003_0003._0092_000E(this.m__0001, text, _000F(107372385), global::_0005._007E_001A(ex), global::_0005._007E_001C(_0096_0005._007E_0011_0012(ex)), 0.0, 0.0, true);
				if (uint.MaxValue != 0)
				{
					global::_0002_0002._001F_0008(ex, text, true, _000F(107397590));
				}
			}
			while (2 == 0);
		}
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
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		if (1 == 0)
		{
			return;
		}
		try
		{
			if (false)
			{
				goto IL_0065;
			}
			Control control = P_0 as Control;
			bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close));
			if (8 == 0)
			{
				goto IL_0098;
			}
			bool flag;
			if (2u != 0)
			{
				flag = num;
			}
			goto IL_00ec;
			IL_0098:
			if (num)
			{
				global::_0082._0086_0005(this, false);
			}
			if (2u != 0)
			{
				return;
			}
			goto IL_0097;
			IL_0065:
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				if (false)
				{
					goto IL_00ec;
				}
				global::_0011._001D_0003(this);
			}
			bool flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			goto IL_0097;
			IL_0097:
			num = flag2;
			goto IL_0098;
			IL_00ec:
			if (flag)
			{
				PropertiesForm.Result = DialogResult.Cancel;
				goto IL_0065;
			}
		}
		catch (Exception)
		{
			if (false)
			{
			}
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
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
			int num = ((this._0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_001A_0002(this._0001);
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

	static F_MarbleMDIV2()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleMDIV2));
		Captions = new List<string>();
	}
}
