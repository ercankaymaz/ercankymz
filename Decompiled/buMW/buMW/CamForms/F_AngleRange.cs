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

public class F_AngleRange : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal Label _0001;

	internal Panel _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal Panel _0002;

	internal Label _0004;

	internal NumericUpDown _0002;

	internal RadioButton _0001;

	internal Panel _0003;

	internal RadioButton _0002;

	internal ImageList _0001;

	internal Label _0005;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	public F_AngleRange()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		int num;
		if (true)
		{
			PropertiesForm.Inited = false;
			num = PropertiesForm.Height;
			goto IL_0023;
		}
		goto IL_0034;
		IL_01a1:
		ControlUpdate();
		global::_0005._0002._0001(this);
		_008F_0003._007E_0082_0014(this._0001, null);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		return;
		IL_0023:
		int num2 = 10;
		goto IL_0025;
		IL_0025:
		if (num > num2)
		{
			goto IL_0034;
		}
		goto IL_0208;
		IL_0034:
		_0097._008C_0011(this, PropertiesForm.Height);
		goto IL_0208;
		IL_0208:
		num = PropertiesForm.Width;
		num2 = 10;
		if (num2 == 0)
		{
			goto IL_0025;
		}
		if (num > num2)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._0092_000F(this, PropertiesForm.TopMost);
		_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0007_0004(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0008_0004(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(mwCamParameter)))));
		bool flag = _0003_0004._007E_0096_0014(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(mwCamParameter))) == ShallowAndSteepAreaParamsMachiningAreaType.MatSteepAreas;
		if (6u != 0)
		{
			num = (flag ? 1 : 0);
			if (5 == 0)
			{
				goto IL_0023;
			}
			if (num == 0)
			{
				goto IL_018e;
			}
			if (7u != 0)
			{
				if (false)
				{
					goto IL_0034;
				}
				_0095._007E_0093_000F(this._0002, true);
			}
		}
		if (false)
		{
			goto IL_018e;
		}
		goto IL_01a1;
		IL_018e:
		_0095._007E_0093_000F(this._0001, true);
		goto IL_01a1;
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
		_0094 obj = _0094._007E_0099_0007;
		ShallowAndSteepAreaParams obj2 = _0084_0002._007E_008F_0012(_0084._007E_009D_0006(mwCamParameter));
		double num = _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001));
		if (4u != 0)
		{
			obj(obj2, num);
		}
		_0094._007E_0098_0007(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(mwCamParameter)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		if (global::_0003._007E_001C(this._0002))
		{
			_0086_0002._007E_0090_0012(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(mwCamParameter)), ShallowAndSteepAreaParamsMachiningAreaType.MatSteepAreas);
		}
		else
		{
			_0086_0002._007E_0090_0012(_0084_0002._007E_008F_0012(_0084._007E_009D_0006(mwCamParameter)), ShallowAndSteepAreaParamsMachiningAreaType.MatShallowAreas);
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0001(object P_0, KeyEventArgs P_1)
	{
		Control control;
		do
		{
			control = new Control();
		}
		while (4 == 0);
		control = (Control)P_0;
		int num = (((_009C_0005._007E_0007_0017(P_1) == Keys.Return) | (_009C_0005._007E_0007_0017(P_1) == Keys.Tab)) ? 1 : 0);
		while (true)
		{
			bool flag = (byte)num != 0;
			bool num2;
			if (7u != 0)
			{
				num2 = flag;
				goto IL_004d;
			}
			goto IL_0050;
			IL_004d:
			if (!num2)
			{
				break;
			}
			goto IL_0050;
			IL_0050:
			num = 0;
			if (num != 0)
			{
				continue;
			}
			int num3 = num;
			num2 = _009D_0005._0008_0017(global::_0005._007E_0013_0003(_0003_0003._007E_001E_0013(control)), ref num3);
			if (8u != 0)
			{
				_009E_0005._000E_0017(_0013_0005._001A_0016(this), num3, global::_0003._007E_009B_0002(P_1));
				break;
			}
			goto IL_004d;
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		bool flag = default(bool);
		if (0 == 0 && uint.MaxValue != 0)
		{
			bool touchPad = PropertiesForm.TouchPad;
			bool num = global::_0003._007E_0083(this._0001);
			do
			{
				num = !num;
			}
			while (false);
			flag = touchPad && num;
		}
		if (!flag)
		{
			return;
		}
		NumericUpDown numericUpDown = new NumericUpDown();
		numericUpDown = (NumericUpDown)P_0;
		if (7u != 0)
		{
			bool flag2 = global::_0003._007E_008C(numericUpDown);
			if (false || flag2)
			{
				_0010_0006._008A_001C(this, numericUpDown);
			}
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
		while (true)
		{
			if (3u != 0)
			{
				if (num)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_0018());
					goto IL_0163;
				}
				bool num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
				if (4u != 0)
				{
					bool flag = num2;
					if (4 == 0)
					{
						goto IL_0163;
					}
					if (flag)
					{
						goto IL_00a5;
					}
					num2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
				}
				bool flag2 = num2;
				num = flag2;
			}
			if (4 == 0)
			{
				continue;
			}
			if (num)
			{
				do
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0008_0018());
				}
				while (false);
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)) ? true : false)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_0018());
			}
			goto IL_0163;
			IL_0163:
			_0095._007E_0096_000F(this._0001, false);
			if (0 == 0)
			{
				break;
			}
			goto IL_00a5;
			IL_00a5:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0007_0018());
			goto IL_0163;
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
