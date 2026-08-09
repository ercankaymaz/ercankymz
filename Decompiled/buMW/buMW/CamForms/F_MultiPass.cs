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

public class F_MultiPass : Form
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

	internal NumericUpDown _0001;

	internal Label _0002;

	internal Label _0003;

	public ComboBox cmb_multipasssort;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal CheckBox _0002;

	public F_MultiPass()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		bool num;
		while (true)
		{
			bool flag = PropertiesForm.Height > 10;
			num = flag;
			if (false)
			{
				break;
			}
			if (num)
			{
				_0097 obj = _0097._008C_0011;
				int num2 = PropertiesForm.Height;
				if (2u != 0)
				{
					obj(this, num2);
				}
			}
			while (true)
			{
				if (PropertiesForm.Width > 10)
				{
					_0097._008D_0011(this, PropertiesForm.Width);
				}
				_0095._0092_000F(this, PropertiesForm.TopMost);
				_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
				while (7u != 0)
				{
					if (3 == 0)
					{
						continue;
					}
					goto IL_00c6;
				}
				break;
				IL_00c6:
				_0095._007E_0096_000F(this._0002, global::_0003._007E_009E_0002(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter)))));
				_0088_0003._007E_001A_0014(this._0002, _0089_0004._0082_0015(_0088_0004._007E_0081_0015(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))))));
				_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0088_0005(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))))));
				global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_multipasssort));
				_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_multipasssort), buMWCaptions.MultiCutsRoughParamsSortType[0]);
				if (1 == 0)
				{
					continue;
				}
				goto IL_01de;
			}
			continue;
			IL_01de:
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_multipasssort), buMWCaptions.MultiCutsRoughParamsSortType[1]);
			num = _0011_0006._007E_008B_001C(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter)))) == MultiCutsRoughParamsSortType.McSortBySlices;
			break;
		}
		if (num)
		{
			_0097._007E_008E_0011(cmb_multipasssort, 0);
		}
		else if (_0011_0006._007E_008B_001C(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter)))) == MultiCutsRoughParamsSortType.McSortByPasses)
		{
			_0097._007E_008E_0011(cmb_multipasssort, 1);
		}
		ControlUpdate();
		global::_0005._0002._0001(this);
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
		Apply();
		PropertiesForm.Result = DialogResult.OK;
		bool num = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
		if (4u != 0)
		{
			if (num)
			{
				global::_0011._001C_0006(this);
				if (false)
				{
					return;
				}
			}
			bool flag = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			num = flag;
		}
		if (num)
		{
			_0095._0094_000F(this, false);
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		if (0 == 0)
		{
			if (-1 == 0)
			{
				goto IL_006f;
			}
			PropertiesForm.Result = DialogResult.Cancel;
		}
		bool num = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
		if (false)
		{
			goto IL_002a;
		}
		bool flag = num;
		goto IL_006f;
		IL_002a:
		while (true)
		{
			if (num)
			{
				global::_0011._001C_0006(this);
			}
			num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
			if (false)
			{
				break;
			}
			if (4u != 0)
			{
				bool flag2 = num;
				num = flag2;
				break;
			}
		}
		if (num)
		{
			_0095._0094_000F(this, false);
		}
		return;
		IL_006f:
		num = flag;
		goto IL_002a;
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
		_0095._007E_008D_000F(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0002));
		_008E_0002._007E_0098_0012(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))), _008C_0004._0086_0015(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0008_0008(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		if (global::_000E._007E_000E_0006(cmb_multipasssort) == 0)
		{
			_008F_0002._007E_009B_0012(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))), MultiCutsRoughParamsSortType.McSortBySlices);
		}
		else if (global::_000E._007E_000E_0006(cmb_multipasssort) == 1 && 8u != 0)
		{
			_008F_0002._007E_009B_0012(_008D_0002._007E_0097_0012(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))), MultiCutsRoughParamsSortType.McSortByPasses);
		}
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

	internal void _0004(object P_0, EventArgs P_1)
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

	internal void _0005(object P_0, EventArgs P_1)
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
						_0007(P_0, null);
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

	internal void _0006(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		int num = (PropertiesForm.Inited ? 1 : 0);
		int num2 = 0;
		if (num2 != 0)
		{
			goto IL_00bf;
		}
		if (num == num2)
		{
			return;
		}
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_multipasssort));
		bool num3 = flag;
		if (-1 == 0)
		{
			goto IL_00c4;
		}
		if (num3)
		{
			num = global::_000E._007E_000E_0006(cmb_multipasssort);
			num2 = 0;
			goto IL_0086;
		}
		goto IL_00ee;
		IL_00ee:
		PropertiesForm.Inited = false;
		Apply();
		goto IL_0101;
		IL_00c4:
		if (num3)
		{
			if (false)
			{
				goto IL_00a7;
			}
			if (6 == 0)
			{
				goto IL_0108;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0001_0018());
		}
		goto IL_00ee;
		IL_0101:
		ControlUpdate();
		goto IL_0108;
		IL_00a7:
		if (0 == 0)
		{
			goto IL_00ee;
		}
		goto IL_0101;
		IL_0086:
		if (num == num2)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._009F_0017());
			goto IL_00a7;
		}
		num = global::_000E._007E_000E_0006(cmb_multipasssort);
		num2 = 1;
		goto IL_00bf;
		IL_0108:
		PropertiesForm.Inited = true;
		return;
		IL_00bf:
		if (num2 == 0)
		{
			goto IL_0086;
		}
		num3 = num == num2;
		goto IL_00c4;
	}

	internal void _0007(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		if (0 == 0)
		{
			Control control2 = control;
		}
		do
		{
			IL_0129:
			Control control2 = (Control)P_0;
			if (4 == 0)
			{
				continue;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0002)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0002_0018());
				if (false)
				{
					goto IL_00a1;
				}
				continue;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0001)))
			{
				goto IL_00a1;
			}
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control2), global::_0005._007E_0014_0003(this._0002));
			if (false || flag)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			}
			continue;
			IL_00a1:
			if (3u != 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0003_0018());
				if (3 == 0)
				{
					goto IL_0129;
				}
			}
		}
		while (5 == 0);
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
