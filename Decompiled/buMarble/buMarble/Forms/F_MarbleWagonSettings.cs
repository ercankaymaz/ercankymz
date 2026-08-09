using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;

namespace buMarble.Forms;

public class F_MarbleWagonSettings : Form
{
	public static List<string> Captions = new List<string>();

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

	public buSpin spn_WagonHidroStopSec;

	public buSpin spn_WagonPosTimeOutSec;

	public buSpin spn_WagonUpPositionA;

	public buSpin spn_WagonUpPositionC;

	public buSpin spn_WagonUpPositionX;

	public buSpin spn_WagonUpPositionZ;

	public buSpin spn_WagonUpPositionY;

	public buButton btn_wagonparkgetpos;

	public F_MarbleWagonSettings()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D._008F_0007(this, PropertiesForm.Height);
			if (-1 == 0)
			{
				return;
			}
		}
		while (true)
		{
			bool num = PropertiesForm.Width > 10;
			while (true)
			{
				bool flag = num;
				while (true)
				{
					num = flag;
					if (7 == 0)
					{
						break;
					}
					if (num)
					{
						if (6 == 0)
						{
							goto IL_00c1;
						}
						global::_008D._008E_0007(this, PropertiesForm.Width);
					}
					global::_0082._008D_0005(this, PropertiesForm.TopMost);
					goto IL_00ab;
					IL_00ab:
					global::_009C._001A_0008(this, PropertiesForm.FormPosition);
					goto IL_00c1;
					IL_00c1:
					global::_0095._007E_0008_0008(spn_WagonHidroStopSec, clsAppMarbleVars.varApp.WagonHidroStopSec);
					global::_0095._007E_0008_0008(spn_WagonPosTimeOutSec, clsAppMarbleVars.varApp.WagonPosTimeOutSec);
					global::_0095._007E_0008_0008(spn_WagonUpPositionA, clsAppMarbleVars.varApp.WagonUpPositionA);
					global::_0095._007E_0008_0008(spn_WagonUpPositionC, clsAppMarbleVars.varApp.WagonUpPositionC);
					global::_0095._007E_0008_0008(spn_WagonUpPositionX, clsAppMarbleVars.varApp.WagonUpPositionX);
					if (7u != 0)
					{
						if (6 == 0)
						{
							goto end_IL_01e5;
						}
						global::_0095._007E_0008_0008(spn_WagonUpPositionY, clsAppMarbleVars.varApp.WagonUpPositionY);
						global::_0095._007E_0008_0008(spn_WagonUpPositionZ, clsAppMarbleVars.varApp.WagonUpPositionZ);
						if (0 == 0)
						{
							PropertiesForm.Result = DialogResult.None;
							PropertiesForm.Inited = true;
							_0005._0003._0001(this);
							return;
						}
						continue;
					}
					goto IL_00ab;
				}
				continue;
				end_IL_01e5:
				break;
			}
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
		if (3u != 0)
		{
			clsAppMarbleVars.varApp.WagonHidroStopSec = global::_0007._007E_0094(spn_WagonHidroStopSec);
			clsAppMarbleVars.varApp.WagonPosTimeOutSec = global::_0007._007E_0094(spn_WagonPosTimeOutSec);
			clsAppMarbleVars.varApp.WagonUpPositionA = global::_0007._007E_0094(spn_WagonUpPositionA);
			clsAppMarbleVars.varApp.WagonUpPositionC = global::_0007._007E_0094(spn_WagonUpPositionC);
		}
		do
		{
			clsAppMarbleVars.varApp.WagonUpPositionX = global::_0007._007E_0094(spn_WagonUpPositionX);
		}
		while (8 == 0);
		if (3u != 0)
		{
			clsAppMarbleVars.varApp.WagonUpPositionY = global::_0007._007E_0094(spn_WagonUpPositionY);
		}
		clsAppMarbleVars.varApp.WagonUpPositionZ = global::_0007._007E_0094(spn_WagonUpPositionZ);
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = new Control();
			control = (Control)P_0;
			bool num;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
			{
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				bool flag = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
				num = flag;
				if (false)
				{
					goto IL_02c0;
				}
				if (num)
				{
					global::_0011._001D_0003(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
			bool num2 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close));
			int num3 = (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel)) ? 1 : 0);
			bool num4;
			if (uint.MaxValue != 0)
			{
				if (((num2 ? 1u : 0u) | (uint)num3) != 0)
				{
					PropertiesForm.Result = DialogResult.Cancel;
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
					{
						global::_0011._001D_0003(this);
					}
					num4 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
					goto IL_013c;
				}
				goto IL_0152;
			}
			goto IL_019e;
			IL_0152:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_wagonparkgetpos)) && AppBool.Connected)
			{
				num2 = clsAppMarbleVars.varRuntime.AxX < 0;
				num3 = 0;
				goto IL_019e;
			}
			return;
			IL_013c:
			if (num4)
			{
				global::_0082._0086_0005(this, false);
			}
			goto IL_0152;
			IL_02c0:
			if (!num)
			{
				global::_0095._007E_0008_0008(spn_WagonUpPositionC, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			num4 = clsAppMarbleVars.varRuntime.AxA >= 0;
			if (7u != 0)
			{
				if (num4)
				{
					global::_0095._007E_0008_0008(spn_WagonUpPositionA, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				return;
			}
			goto IL_013c;
			IL_019e:
			if ((num2 ? 1 : 0) == num3)
			{
				global::_0095._007E_0008_0008(spn_WagonUpPositionX, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			if (clsAppMarbleVars.varRuntime.AxY >= 0)
			{
				global::_0095._007E_0008_0008(spn_WagonUpPositionY, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			if (clsAppMarbleVars.varRuntime.AxZ >= 0)
			{
				global::_0095._007E_0008_0008(spn_WagonUpPositionZ, global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
			}
			num = clsAppMarbleVars.varRuntime.AxC < 0;
			goto IL_02c0;
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
		buSpin buSpin2 = P_0 as buSpin;
		bool num = AppBool.TouchPad;
		while (true)
		{
			bool flag = num;
			if (uint.MaxValue != 0)
			{
				num = flag;
				goto IL_0025;
			}
			goto IL_00a7;
			IL_0025:
			if (!num)
			{
				break;
			}
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			F_KeyPadNumV1 f_KeyPadNumV2;
			if (7u != 0)
			{
				f_KeyPadNumV2 = f_KeyPadNumV;
			}
			goto IL_0037;
			IL_00a7:
			bool flag2;
			if (flag2 && 8u != 0)
			{
				global::_0095._007E_0008_0008(buSpin2, _0008_0005._007F_0011(f_KeyPadNumV2.Value));
				if (0 == 0)
				{
					break;
				}
				goto IL_0037;
			}
			break;
			IL_0037:
			global::_009C._007E_001A_0008(f_KeyPadNumV2, FormStartPosition.CenterParent);
			f_KeyPadNumV2.Caption = global::_0005._007E_008A(global::_0096._007E_0012_0008(buSpin2));
			if (0 == 0)
			{
				global::_008B._007E_009B_0006(f_KeyPadNumV2, global::_0007._007E_0094(buSpin2).ToString());
			}
			num = _0007_0005._001D_0011(f_KeyPadNumV2.Value);
			if (false)
			{
				continue;
			}
			if (1 == 0)
			{
				goto IL_0025;
			}
			flag2 = num;
			goto IL_00a7;
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
}
