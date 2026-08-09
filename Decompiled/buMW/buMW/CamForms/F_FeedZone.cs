using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using buClass;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_FeedZone : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal ImageList _0001;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	internal Label _0002;

	internal Label _0003;

	internal Label _0004;

	internal NumericUpDown _0001;

	internal NumericUpDown _0002;

	internal NumericUpDown _0003;

	public F_FeedZone()
	{
		_0005._0002._0001(this);
	}

	public void Init()
	{
		while (true)
		{
			PropertiesForm.Inited = false;
			int num = PropertiesForm.Height;
			int num2 = 10;
			while (true)
			{
				if (num > num2)
				{
					_0097._008C_0011(this, PropertiesForm.Height);
					if (8 == 0)
					{
						goto IL_00ad;
					}
				}
				num = PropertiesForm.Width;
				num2 = 10;
				if (num2 == 0)
				{
					continue;
				}
				if (num > num2)
				{
					_0097._008D_0011(this, PropertiesForm.Width);
					if (2 == 0)
					{
						goto IL_018f;
					}
					if (-1 == 0)
					{
						break;
					}
				}
				_0095._0092_000F(this, PropertiesForm.TopMost);
				goto IL_00ad;
				IL_018f:
				_008F_0003._007E_0082_0014(this._0001, null);
				goto IL_01a1;
				IL_01a1:
				PropertiesForm.Result = DialogResult.None;
				PropertiesForm.Inited = true;
				return;
				IL_00ad:
				_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
				_0088_0003._007E_001A_0014(_0003, _0087_0003._0019_0014(global::_0007._007E_001C_0005(_0089_0005._007E_0093_0016(_0084._007E_009D_0006(mwCamParameter)))));
				if (5u != 0)
				{
					_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_001D_0005(_0089_0005._007E_0093_0016(_0084._007E_009D_0006(mwCamParameter)))));
					_0088_0003._007E_001A_0014(_0002, _0087_0003._0019_0014(global::_0007._007E_001E_0005(_0089_0005._007E_0093_0016(_0084._007E_009D_0006(mwCamParameter)))));
					ControlUpdate();
					goto IL_018f;
				}
				goto IL_01a1;
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
				_0095._007E_009E_000F(P_1, true);
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
				global::_0011._001C_0006(this);
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
				_0095._0094_000F(this, false);
			}
			break;
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (0 == 0)
		{
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok));
			if (5 == 0)
			{
				goto IL_0098;
			}
			if (!flag)
			{
				goto IL_00a7;
			}
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
		}
		goto IL_0085;
		IL_0093:
		bool num;
		if (num != 0)
		{
			goto IL_0098;
		}
		goto IL_00a7;
		IL_0098:
		_0095._0094_000F(this, false);
		goto IL_00a7;
		IL_00a7:
		while (true)
		{
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel));
			if (3 == 0)
			{
				break;
			}
			if (!flag2)
			{
				return;
			}
			do
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					if (4 == 0)
					{
						return;
					}
					global::_0011._001C_0006(this);
				}
			}
			while (5 == 0);
			if (1 == 0)
			{
				continue;
			}
			goto IL_010d;
		}
		goto IL_0085;
		IL_010d:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		if (0 == 0)
		{
			if (num)
			{
				_0095._0094_000F(this, false);
			}
			return;
		}
		goto IL_0093;
		IL_0085:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		goto IL_0093;
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		_0094._007E_008B_000E(_0089_0005._007E_0093_0016(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0003)));
		_0094._007E_008C_000E(_0089_0005._007E_0093_0016(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_008D_000E(_0089_0005._007E_0093_0016(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0002)));
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
			global::_0011._007E_0019_0006(this._0001);
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
		_0095._0091_000F(this, disposing);
	}
}
