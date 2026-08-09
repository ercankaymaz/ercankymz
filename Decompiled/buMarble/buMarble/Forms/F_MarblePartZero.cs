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

public class F_MarblePartZero : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	private string m__0001 = _0094(107381409);

	public MarblePartZeroType PartZero = MarblePartZeroType.Saw;

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buButton btn_spindle;

	public buButton btn_laser;

	public buButton btn_saw;

	[NonSerialized]
	internal static GetString _0094;

	public F_MarblePartZero()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		while (true)
		{
			PropertiesForm.Inited = false;
			if (PropertiesForm.Height > 10)
			{
				global::_008D._008F_0007(this, PropertiesForm.Height);
			}
			while (true)
			{
				int num = PropertiesForm.Width;
				while (true)
				{
					if (num > 10)
					{
						if (false)
						{
							break;
						}
						global::_008D._008E_0007(this, PropertiesForm.Width);
					}
					global::_0082._008D_0005(this, PropertiesForm.TopMost);
					if (0 == 0)
					{
						global::_009C._001A_0008(this, PropertiesForm.FormPosition);
						while (false)
						{
						}
						num = ((PartZero == MarblePartZeroType.Saw) ? 1 : 0);
						if (false)
						{
							continue;
						}
						if (num != 0 && false)
						{
							break;
						}
						PropertiesForm.Result = DialogResult.None;
						PropertiesForm.Inited = true;
						_0005._0003._0001(this);
						if (8 == 0)
						{
							goto end_IL_013c;
						}
						UpdateVisuals();
					}
					MenuButtonColors(PartZero);
					return;
				}
				continue;
				end_IL_013c:
				break;
			}
		}
	}

	public void MenuButtonColors(MarblePartZeroType partZero)
	{
		if (0 == 0)
		{
			Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
			controlCollection = _0099_0006._001D_0013(controlCollection);
			if (partZero != MarblePartZeroType.Saw)
			{
				if (partZero == MarblePartZeroType.Milling)
				{
					btn_spindle = _009D_0006._0080_0013(btn_spindle, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				}
				else if (partZero == MarblePartZeroType.Laser)
				{
					goto IL_00be;
				}
				goto IL_00ef;
			}
		}
		if (false)
		{
			goto IL_00be;
		}
		btn_saw = _009D_0006._0080_0013(btn_saw, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		goto IL_00ef;
		IL_00be:
		btn_laser = _009D_0006._0080_0013(btn_laser, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		goto IL_00ef;
		IL_00ef:
		PartZero = partZero;
	}

	public void UpdateVisuals()
	{
		string text = _0094(107450490);
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
				fileInfo = new FileInfo(global::_0002._0003(AppPath.MachineSettings, _0094(107372856)));
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
				global::_0003_0003._0092_000E(this.m__0001, text, _0094(107372339), global::_0005._007E_001A(ex), global::_0005._007E_001C(_0096_0005._007E_0011_0012(ex)), 0.0, 0.0, true);
				if (uint.MaxValue != 0)
				{
					global::_0002_0002._001F_0008(ex, text, true, _0094(107397544));
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
		try
		{
			Control control = P_0 as Control;
			bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close));
			while (true)
			{
				if (num)
				{
					PropertiesForm.Result = DialogResult.Cancel;
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
					{
						global::_0011._001D_0003(this);
					}
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
					{
						global::_0082._0086_0005(this, false);
					}
				}
				bool flag = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_saw));
				bool num2 = flag;
				while (true)
				{
					if (num2)
					{
						PartZero = MarblePartZeroType.Saw;
						MenuButtonColors(PartZero);
						PropertiesForm.Result = DialogResult.OK;
						if (false)
						{
							goto IL_01a2;
						}
						num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
						if (false)
						{
							continue;
						}
						if (num2)
						{
							global::_0011._001D_0003(this);
						}
						if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
						{
							global::_0082._0086_0005(this, false);
						}
					}
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_spindle)))
					{
						PartZero = MarblePartZeroType.Milling;
						MenuButtonColors(PartZero);
						PropertiesForm.Result = DialogResult.OK;
						if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
						{
							global::_0011._001D_0003(this);
						}
						goto IL_01a2;
					}
					goto IL_01c6;
					IL_01c6:
					if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_laser)))
					{
						PartZero = MarblePartZeroType.Laser;
						MenuButtonColors(PartZero);
						if (2u != 0)
						{
							break;
						}
						goto IL_01b7;
					}
					return;
					IL_01a2:
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
					{
						goto IL_01b7;
					}
					goto IL_01c6;
					IL_01b7:
					global::_0082._0086_0005(this, false);
					goto IL_01c6;
				}
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
				if (6 == 0)
				{
					continue;
				}
				if (num)
				{
					global::_0082._0086_0005(this, false);
				}
				break;
			}
		}
		catch (Exception)
		{
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

	static F_MarblePartZero()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarblePartZero));
		Captions = new List<string>();
	}
}
