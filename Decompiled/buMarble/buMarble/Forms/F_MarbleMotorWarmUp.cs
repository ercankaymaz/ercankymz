using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;

namespace buMarble.Forms;

public class F_MarbleMotorWarmUp : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_cancel;

	public buButton btn_startsaw;

	internal ImageList _0001;

	public buSpin spn_timemilling3;

	public buSpin spn_timesaw3;

	public buSpin spn_timemilling2;

	public buSpin spn_timesaw2;

	public buSpin spn_timemilling1;

	public buSpin spn_timesaw1;

	public buSpin spn_speedmilling3;

	public buSpin spn_speedsaw3;

	public buSpin spn_speedmilling2;

	public buSpin spn_speedsaw2;

	internal buLabel _0001;

	internal buLabel _0002;

	public buSpin spn_speedmilling1;

	public buSpin spn_speedsaw1;

	public buButton btn_stopsaw;

	public buButton btn_stopmilling;

	public buButton btn_startmilling;

	public buButton btn_ok;

	public buLabel lnl_speed1;

	public buLabel lnl_time3;

	public buLabel lnl_time2;

	public buLabel lnl_time1;

	public buLabel lnl_speed3;

	public buLabel lnl_speed2;

	public F_MarbleMotorWarmUp()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		bool num = PropertiesForm.Height > 10;
		bool flag;
		if (6u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			global::_008D._008F_0007(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		global::_0095._007E_0008_0008(spn_speedmilling1, clsAppMarbleVars.varApp.WarmUpMillingSpeed1);
		global::_0095._007E_0008_0008(spn_speedmilling2, clsAppMarbleVars.varApp.WarmUpMillingSpeed2);
		global::_0095._007E_0008_0008(spn_speedmilling3, clsAppMarbleVars.varApp.WarmUpMillingSpeed3);
		global::_0095._007E_0008_0008(spn_speedsaw1, clsAppMarbleVars.varApp.WarmUpSawSpeed1);
		global::_0095._007E_0008_0008(spn_speedsaw2, clsAppMarbleVars.varApp.WarmUpSawSpeed2);
		global::_0095._007E_0008_0008(spn_speedsaw3, clsAppMarbleVars.varApp.WarmUpSawSpeed3);
		global::_0095._007E_0008_0008(spn_timemilling1, clsAppMarbleVars.varApp.WarmUpMillingTimeSec1);
		global::_0095._007E_0008_0008(spn_timemilling2, clsAppMarbleVars.varApp.WarmUpMillingTimeSec2);
		global::_0095._007E_0008_0008(spn_timemilling3, clsAppMarbleVars.varApp.WarmUpMillingTimeSec3);
		global::_0095._007E_0008_0008(spn_timesaw1, clsAppMarbleVars.varApp.WarmUpSawTimeSec1);
		global::_0095._007E_0008_0008(spn_timesaw2, clsAppMarbleVars.varApp.WarmUpSawTimeSec2);
		global::_0095._007E_0008_0008(spn_timesaw3, clsAppMarbleVars.varApp.WarmUpSawTimeSec3);
		global::_0082._007E_0005_0006(spn_speedmilling1, false);
		global::_0082._007E_0005_0006(spn_speedmilling2, false);
		global::_0082._007E_0005_0006(spn_speedmilling3, false);
		global::_0082._007E_0005_0006(spn_speedsaw1, false);
		global::_0082._007E_0005_0006(spn_speedsaw2, false);
		global::_0082._007E_0005_0006(spn_speedsaw3, false);
		global::_0082._007E_0005_0006(spn_timemilling1, false);
		global::_0082._007E_0005_0006(spn_timemilling2, false);
		global::_0082._007E_0005_0006(spn_timemilling3, false);
		global::_0082._007E_0005_0006(spn_timesaw1, false);
		global::_0082._007E_0005_0006(spn_timesaw2, false);
		global::_0082._007E_0005_0006(spn_timesaw3, false);
		if (AppSecurity.PasswordLevel <= 1)
		{
			global::_0082._007E_0005_0006(spn_speedmilling1, true);
			global::_0082._007E_0005_0006(spn_speedmilling2, true);
			global::_0082._007E_0005_0006(spn_speedmilling3, true);
			global::_0082._007E_0005_0006(spn_speedsaw1, true);
			global::_0082._007E_0005_0006(spn_speedsaw2, true);
			global::_0082._007E_0005_0006(spn_speedsaw3, true);
			global::_0082._007E_0005_0006(spn_timemilling1, true);
			global::_0082._007E_0005_0006(spn_timemilling2, true);
			global::_0082._007E_0005_0006(spn_timemilling3, true);
			global::_0082._007E_0005_0006(spn_timesaw1, true);
			global::_0082._007E_0005_0006(spn_timesaw2, true);
			global::_0082._007E_0005_0006(spn_timesaw3, true);
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		_0005._0003._0001(this);
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
		clsAppMarbleVars.varApp.WarmUpMillingSpeed1 = global::_0007._007E_0094(spn_speedmilling1);
		clsAppMarbleVars.varApp.WarmUpMillingSpeed2 = global::_0007._007E_0094(spn_speedmilling2);
		clsAppMarbleVars.varApp.WarmUpMillingSpeed3 = global::_0007._007E_0094(spn_speedmilling3);
		clsAppMarbleVars.varApp.WarmUpSawSpeed1 = global::_0007._007E_0094(spn_speedsaw1);
		clsAppMarbleVars.varApp.WarmUpSawSpeed2 = global::_0007._007E_0094(spn_speedsaw2);
		clsAppMarbleVars.varApp.WarmUpSawSpeed3 = global::_0007._007E_0094(spn_speedsaw3);
		clsAppMarbleVars.varApp.WarmUpMillingTimeSec1 = global::_0007._007E_0094(spn_timemilling1);
		clsAppMarbleVars.varApp.WarmUpMillingTimeSec2 = global::_0007._007E_0094(spn_timemilling2);
		clsAppMarbleVars.varApp.WarmUpMillingTimeSec3 = global::_0007._007E_0094(spn_timemilling3);
		clsAppMarbleVars.varApp.WarmUpSawTimeSec1 = global::_0007._007E_0094(spn_timesaw1);
		clsAppMarbleVars.varApp.WarmUpSawTimeSec2 = global::_0007._007E_0094(spn_timesaw2);
		clsAppMarbleVars.varApp.WarmUpSawTimeSec3 = global::_0007._007E_0094(spn_timesaw3);
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			while (true)
			{
				Control control = P_0 as Control;
				bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok));
				while (true)
				{
					bool flag = num;
					bool num2 = flag;
					bool num3;
					if (0 == 0)
					{
						if (num2)
						{
							PropertiesForm.Result = DialogResult.OK;
							if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
							{
								global::_0011._001D_0003(this);
							}
							num3 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
							if (8 == 0)
							{
								goto IL_014f;
							}
							bool flag2 = num3;
							num = flag2;
							if (false)
							{
								continue;
							}
							if (num && 0 == 0)
							{
								global::_0082._0086_0005(this, false);
								if (false)
								{
									return;
								}
							}
						}
						if (!(global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel))))
						{
							return;
						}
						if (false)
						{
							break;
						}
						Apply();
						PropertiesForm.Result = DialogResult.Cancel;
						num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
					}
					if (8u != 0)
					{
						if (num2)
						{
							global::_0011._001D_0003(this);
						}
						num3 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
						goto IL_014f;
					}
					goto IL_0153;
					IL_0153:
					if (num2)
					{
						global::_0082._0086_0005(this, false);
					}
					return;
					IL_014f:
					bool flag3 = num3;
					num2 = flag3;
					goto IL_0153;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		if (false)
		{
			return;
		}
		buSpin buSpin2 = P_0 as buSpin;
		if (false)
		{
			return;
		}
		bool touchPad = AppBool.TouchPad;
		bool num = global::_0003._007E_0016(buSpin2);
		if (0 == 0)
		{
			num = !num;
		}
		if (!(touchPad && num))
		{
			return;
		}
		while (0 == 0)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			global::_009C._007E_001A_0008(f_KeyPadNumV, FormStartPosition.CenterParent);
			if (4u != 0)
			{
				f_KeyPadNumV.Caption = global::_0005._007E_008A(global::_0096._007E_0012_0008(buSpin2));
				bool flag;
				if (2u != 0)
				{
					global::_008B._007E_009B_0006(f_KeyPadNumV, global::_0007._007E_0094(buSpin2).ToString());
					flag = _0007_0005._001D_0011(f_KeyPadNumV.Value);
				}
				if (flag)
				{
					global::_0095._007E_0008_0008(buSpin2, _0008_0005._007F_0011(f_KeyPadNumV.Value));
				}
				break;
			}
		}
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
}
