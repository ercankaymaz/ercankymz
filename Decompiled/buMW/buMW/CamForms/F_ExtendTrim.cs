using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_ExtendTrim : Form
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

	internal Panel _0001;

	internal Label _0002;

	internal RadioButton _0001;

	internal NumericUpDown _0001;

	internal RadioButton _0002;

	internal NumericUpDown _0002;

	internal Panel _0002;

	internal Label _0003;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal NumericUpDown _0003;

	internal NumericUpDown _0004;

	internal CheckBox _0002;

	public F_ExtendTrim()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			_0097 obj = _0097._008C_0011;
			int num = PropertiesForm.Height;
			if (0 == 0)
			{
				obj(this, num);
			}
		}
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._0092_000F(this, PropertiesForm.TopMost);
		_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
		if (global::_0003._007E_009C_0002(_009F_0005._007E_000F_0017(_0084._007E_009D_0006(mwCamParameter))))
		{
			_0095._007E_0093_000F(this._0003, global::_0003._007E_009C_0002(_009F_0005._007E_000F_0017(_0084._007E_009D_0006(mwCamParameter))));
		}
		else
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		while (true)
		{
			if (global::_0003._007E_009C_0002(_009F_0005._007E_0010_0017(_0084._007E_009D_0006(mwCamParameter))))
			{
				if (3 == 0)
				{
					continue;
				}
				_0095._007E_0093_000F(this._0001, global::_0003._007E_009C_0002(_009F_0005._007E_0010_0017(_0084._007E_009D_0006(mwCamParameter))));
				break;
			}
			_0095._007E_0093_000F(this._0002, true);
			break;
		}
		if (global::_0003._007E_009C_0002(_009F_0005._007E_000F_0017(_0084._007E_009D_0006(mwCamParameter))))
		{
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_000F_0017(_0084._007E_009D_0006(mwCamParameter)))));
		}
		else
		{
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_000F_0017(_0084._007E_009D_0006(mwCamParameter)))));
		}
		if (global::_0003._007E_009C_0002(_009F_0005._007E_0010_0017(_0084._007E_009D_0006(mwCamParameter))))
		{
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_0010_0017(_0084._007E_009D_0006(mwCamParameter)))));
		}
		else
		{
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0010_0017(_0084._007E_009D_0006(mwCamParameter)))));
		}
		_0095._007E_0096_000F(this._0002, global::_0003._007E_009D_0002(_0084._007E_009D_0006(mwCamParameter)));
		ControlUpdate();
		_008F_0003._007E_0082_0014(this._0001, null);
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
		if (8 == 0)
		{
			goto IL_008a;
		}
		bool num = global::_0003._007E_001C(this._0003);
		goto IL_0109;
		IL_00a7:
		_0095._007E_0095_000F(this._0002, true);
		_0095._007E_0095_000F(this._0001, false);
		return;
		IL_0109:
		if (num)
		{
			if (8 == 0)
			{
				goto IL_00a7;
			}
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0004, false);
		}
		else
		{
			do
			{
				_0095._007E_0095_000F(this._0003, false);
				_0095._007E_0095_000F(this._0004, true);
			}
			while (2 == 0);
		}
		goto IL_008a;
		IL_008a:
		if (2 == 0)
		{
			return;
		}
		num = global::_0003._007E_001C(this._0001);
		if (7 == 0)
		{
			goto IL_0109;
		}
		if (!num)
		{
			_0095._007E_0095_000F(this._0002, false);
			do
			{
				_0095._007E_0095_000F(this._0001, true);
			}
			while (8 == 0);
			return;
		}
		goto IL_00a7;
	}

	public void Apply()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		if (global::_0003._007E_001C(this._0003))
		{
			goto IL_0021;
		}
		if (5 == 0)
		{
			goto IL_006b;
		}
		PercentOrValueParameter val = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), false);
		goto IL_00a9;
		IL_00a9:
		_0094._007E_0083_000E(val, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0001_0006._007E_0014_0017(_0084._007E_009D_0006(mwCamParameter), val);
		goto IL_00ed;
		IL_00ed:
		if (global::_0003._007E_001C(this._0001))
		{
			PercentOrValueParameter val2 = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), true);
			_0094._007E_0082_000E(val2, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0001_0006._007E_0015_0017(_0084._007E_009D_0006(mwCamParameter), val2);
		}
		else
		{
			PercentOrValueParameter val3 = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), false);
			if (false)
			{
				goto IL_0021;
			}
			_0094._007E_0083_000E(val3, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			_0001_0006._007E_0015_0017(_0084._007E_009D_0006(mwCamParameter), val3);
		}
		_0095._007E_0080_0011(_0084._007E_009D_0006(mwCamParameter), global::_0003._007E_0083(this._0002));
		return;
		IL_0021:
		PercentOrValueParameter val4 = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), true);
		_0094._007E_0082_000E(val4, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		goto IL_006b;
		IL_006b:
		if (7 == 0)
		{
			goto IL_00a9;
		}
		_0001_0006._007E_0014_0017(_0084._007E_009D_0006(mwCamParameter), val4);
		goto IL_00ed;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		bool flag;
		do
		{
			if (true)
			{
				Control control = new Control();
				Control obj = (Control)P_0;
				if (4u != 0)
				{
					control = obj;
				}
				flag = !PropertiesForm.Inited;
			}
		}
		while (7 == 0);
		if (flag)
		{
			if (0 == 0 && false)
			{
			}
		}
		else
		{
			PropertiesForm.Inited = true;
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		if (3u != 0)
		{
		}
		Control control = new Control();
		control = (Control)P_0;
		bool num = !PropertiesForm.Inited;
		while (true)
		{
			bool flag = num;
			while (true)
			{
				num = flag;
				if (false)
				{
					break;
				}
				if (!num)
				{
					PropertiesForm.Inited = false;
					if (0 == 0)
					{
						Apply();
						ControlUpdate();
						PropertiesForm.Inited = true;
						_0005(P_0, null);
					}
				}
				if (2 == 0)
				{
					continue;
				}
				return;
			}
		}
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0019_0017());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)) | global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)) | global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)) | global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_0017());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)) | global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)) | global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)) | global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_0017());
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
