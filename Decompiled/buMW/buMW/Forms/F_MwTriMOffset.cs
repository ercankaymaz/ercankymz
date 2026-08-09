using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMOffset : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	private IContainer m__0001 = null;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Panel _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal Label _0005;

	internal ImageList _0002;

	public F_MwTriMOffset()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		if (Properties.Width > 10)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_001C_0004(Par)));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_001D_0004(Par)));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0082_0003(Par)));
		if (_001A_0004._007E_0012_0015(Par) == MachiningParamsStockRemainType.SrtGlobal)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void _0001(object P_0, FormClosingEventArgs P_1)
	{
		while (true)
		{
			bool num = Properties.Result == DialogResult.OK;
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
				Properties.Result = DialogResult.Cancel;
				bool flag2;
				do
				{
					flag2 = Properties.FormCloseMode == FormCloseModeType.Dispose;
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
			num2 = Properties.FormCloseMode == FormCloseModeType.Invisible;
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
		Properties.Result = DialogResult.OK;
		bool num = Properties.FormCloseMode == FormCloseModeType.Dispose;
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
			bool flag = Properties.FormCloseMode == FormCloseModeType.Invisible;
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
			Properties.Result = DialogResult.Cancel;
		}
		bool num = Properties.FormCloseMode == FormCloseModeType.Dispose;
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
			num = Properties.FormCloseMode == FormCloseModeType.Invisible;
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

	public void UpdateControlFromType()
	{
		if (0 == 0)
		{
			goto IL_0007;
		}
		goto IL_00c4;
		IL_0007:
		bool flag = global::_0003._007E_001C(this._0002);
		goto IL_0146;
		IL_0146:
		if (!flag)
		{
			_0095._007E_0095_000F(this._0004, false);
			goto IL_00c4;
		}
		_0095._007E_0095_000F(this._0004, true);
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0002, false);
			goto IL_0072;
		}
		goto IL_00eb;
		IL_0072:
		_0095._007E_0095_000F(this._0001, false);
		_0095._007E_0095_000F(this._0003, false);
		_0095._007E_0095_000F(this._0002, false);
		if (false)
		{
			goto IL_0146;
		}
		return;
		IL_00c4:
		if (5u != 0)
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0002, true);
			goto IL_00eb;
		}
		return;
		IL_00eb:
		_0095._007E_0095_000F(this._0001, true);
		_0095._007E_0095_000F(this._0003, true);
		if (3 == 0)
		{
			goto IL_0007;
		}
		_0095._007E_0095_000F(this._0002, true);
		if (0 == 0)
		{
			return;
		}
		goto IL_0072;
	}

	public void Apply()
	{
		if (true)
		{
			_0094._007E_008D_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		}
		_0094._007E_008E_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0086_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		if (global::_0003._007E_001C(this._0002))
		{
			if (5u != 0)
			{
				_001B_0004._007E_0013_0015(Par, MachiningParamsStockRemainType.SrtGlobal);
			}
		}
		else
		{
			do
			{
				_001B_0004._007E_0013_0015(Par, MachiningParamsStockRemainType.SrtRadialAndAxial);
			}
			while (false);
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		UpdateControlFromType();
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control;
		bool flag;
		if (2u != 0)
		{
			control = new Control();
			if (8u != 0)
			{
				control = (Control)P_0;
				flag = _0003_0003._007E_001E_0013(control) != null;
			}
		}
		while (flag)
		{
			_008F_0003._007E_0082_0014(this._0001, _008E_0003._007E_0081_0014(_008D_0003._007E_0080_0014(this._0002), _001D._0095_0006(_0003_0003._007E_001E_0013(control))));
			if (5 == 0)
			{
				continue;
			}
			break;
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
			global::_0011._007E_0019_0006(this.m__0001);
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
