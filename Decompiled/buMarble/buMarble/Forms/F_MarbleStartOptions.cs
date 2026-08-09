using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using buClass;
using buControls.Controls;

namespace buMarble.Forms;

public class F_MarbleStartOptions : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer m__0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buCheckBox chk_washbeforevacuum;

	public buCheckBox chk_pointanglecorrection;

	public buCheckBox chk_startsafedistance;

	public buCheckBox chk_dryrun;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal buLabel _0001;

	internal buLabel _0002;

	internal buLabel _0003;

	internal buLabel _0004;

	internal buLabel _0005;

	public buButton btn_parklist;

	public buButton btn_canceloption;

	public buButton btn_startoption;

	public F_MarbleStartOptions()
	{
		global::_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D._008F_0007(this, PropertiesForm.Height);
		}
		bool flag = PropertiesForm.Width > 10;
		while (true)
		{
			if (flag)
			{
				if (2 == 0)
				{
					break;
				}
				global::_008D._008E_0007(this, PropertiesForm.Width);
			}
			global::_0082._008D_0005(this, PropertiesForm.TopMost);
			global::_009C._001A_0008(this, PropertiesForm.FormPosition);
			bool num = clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.ParkPosition;
			if (6 == 0)
			{
				goto IL_0123;
			}
			bool flag2 = num;
			if (8 == 0)
			{
				continue;
			}
			if (0 == 0)
			{
				if (flag2)
				{
					if (2 == 0)
					{
						goto IL_015b;
					}
					global::_0082._007E_009E_0005(this._0002, true);
				}
				else
				{
					if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType != MarbleParkModeAfterJob.UserParkPosition)
					{
						num = clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.SafeDistance;
						goto IL_0123;
					}
					global::_0082._007E_009E_0005(this._0001, true);
				}
			}
			goto IL_0140;
			IL_0123:
			if (num)
			{
				global::_0082._007E_009E_0005(this._0003, true);
				if (false)
				{
					goto IL_015b;
				}
			}
			goto IL_0140;
			IL_0140:
			global::_0082._007E_0089_0005(chk_dryrun, clsAppMarbleVars.varRuntime.isDryRunActivated);
			goto IL_015b;
			IL_015b:
			global::_0082._007E_0089_0005(chk_pointanglecorrection, clsAppMarbleVars.varApp.PointAngleCorrection);
			break;
		}
		global::_0082._007E_0089_0005(chk_startsafedistance, clsAppMarbleVars.varApp.GoZUpPositionWhenStart);
		if (3u != 0)
		{
			global::_0082._007E_0089_0005(chk_washbeforevacuum, clsAppMarbleVars.varApp.VacuumWashBeforeMaterialTake);
		}
		global::_0005._0003._0001(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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
		do
		{
			clsAppMarbleVars.varRuntime.isDryRunActivated = global::_0003._007E_0010(chk_dryrun);
			clsAppMarbleVars.varApp.PointAngleCorrection = global::_0003._007E_0010(chk_pointanglecorrection);
			clsAppMarbleVars.varApp.GoZUpPositionWhenStart = global::_0003._007E_0010(chk_startsafedistance);
			clsAppMarbleVars.varApp.VacuumWashBeforeMaterialTake = global::_0003._007E_0010(chk_washbeforevacuum);
		}
		while (false);
		bool flag = global::_0003._007E_0017(this._0002);
		while (true)
		{
			if (8u != 0)
			{
				if (flag)
				{
					clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.ParkPosition;
					return;
				}
				if (!global::_0003._007E_0017(this._0003))
				{
					break;
				}
			}
			if (0 == 0)
			{
				clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.SafeDistance;
				return;
			}
		}
		clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.UserParkPosition;
		if (false)
		{
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = new Control();
			bool num;
			while (true)
			{
				control = (Control)P_0;
				bool flag = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_startoption));
				num = flag;
				if (4 == 0)
				{
					break;
				}
				if (!num)
				{
					goto IL_00b4;
				}
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode != FormCloseModeType.Dispose)
				{
					goto IL_0092;
				}
				if (0 == 0)
				{
					global::_0011._001D_0003(this);
					goto IL_008a;
				}
				goto IL_0125;
				IL_0092:
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
				goto IL_00b4;
				IL_008a:
				if (0 == 0)
				{
					goto IL_0092;
				}
				goto IL_0125;
				IL_016d:
				num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_parklist));
				break;
				IL_0125:
				bool flag2;
				if (flag2)
				{
					if (false)
					{
						continue;
					}
					global::_0011._001D_0003(this);
					if (false)
					{
						goto IL_0092;
					}
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
				if (false)
				{
					goto IL_008a;
				}
				goto IL_016d;
				IL_00b4:
				int num2 = (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close)) ? 1 : 0);
				do
				{
					num2 |= (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_canceloption)) ? 1 : 0);
				}
				while (1 == 0);
				if (num2 != 0)
				{
					PropertiesForm.Result = DialogResult.Cancel;
					flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
					goto IL_0125;
				}
				goto IL_016d;
			}
			if (num)
			{
				clsAppMarbleVars.cmdMarble.ShowParkList();
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
