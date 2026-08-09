using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMRestFinish : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal PictureBox _0001;

	internal ImageList _0002;

	internal Panel _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Panel _0002;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal Label _0005;

	internal Label _0006;

	internal NumericUpDown _0003;

	internal Panel _0003;

	internal Button _0001;

	internal Label _0007;

	internal Label _0008;

	internal NumericUpDown _0004;

	public F_MwTriMRestFinish()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		bool num = Properties.Height > 10;
		bool num2;
		if (0 == 0)
		{
			bool flag;
			if (3u != 0)
			{
				flag = num;
			}
			if (flag)
			{
				_0097._008C_0011(this, Properties.Height);
			}
			if (0 == 0)
			{
				bool flag2 = Properties.Width > 10;
				num2 = flag2;
				goto IL_0075;
			}
			goto IL_00ac;
		}
		goto IL_022d;
		IL_00ac:
		_0086_0003._0018_0014(this, Properties.FormPosition);
		if (7u != 0)
		{
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_001F_0004(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
			goto IL_0112;
		}
		goto IL_01aa;
		IL_01aa:
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0081_0004(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		num2 = _001F_0004._007E_0018_0015(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaRestFinishingParamsType.RfBasedOnTool;
		if (false)
		{
			goto IL_0075;
		}
		bool flag3 = num2;
		num = flag3;
		goto IL_022d;
		IL_0075:
		if (num2)
		{
			if (7 == 0)
			{
				goto IL_0112;
			}
			_0097._008D_0011(this, Properties.Width);
		}
		_0095._0092_000F(this, Properties.TopMost);
		goto IL_00ac;
		IL_022d:
		if (num)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else
		{
			do
			{
				_0095._007E_0093_000F(this._0001, true);
			}
			while (false);
		}
		UpdateControlFromType();
		_008F_0003._007E_0082_0014(this._0001, null);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_0112:
		if (2u != 0)
		{
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_007F_0004(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0080_0004(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
			goto IL_01aa;
		}
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
		bool num = global::_0003._007E_001C(this._0002);
		if (0 == 0)
		{
			bool flag = num;
			if (false)
			{
				goto IL_0047;
			}
			num = flag;
		}
		if (num)
		{
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0003, false);
			goto IL_0047;
		}
		_0095._007E_0095_000F(this._0002, false);
		goto IL_0064;
		IL_0064:
		if (6u != 0)
		{
			_0095._007E_0095_000F(this._0003, true);
		}
		return;
		IL_0047:
		if (false || 0 == 0)
		{
			return;
		}
		goto IL_0064;
	}

	public void Apply()
	{
		do
		{
			_0094._007E_008F_0008(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0094._007E_0090_0008(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			_0094._007E_0091_0008(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0094._007E_0092_0008(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		}
		while (6 == 0);
		if (global::_0003._007E_001C(this._0002))
		{
			_007F_0004._007E_0019_0015(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRestFinishingParamsType.RfBasedOnTool);
		}
		else
		{
			_007F_0004._007E_0019_0015(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRestFinishingParamsType.RfBasedOnStock);
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = Properties.Inited;
		while (true)
		{
			if (0 == 0)
			{
				bool flag = !num;
				if (false)
				{
					goto IL_005a;
				}
				num = flag;
			}
			if (false)
			{
				continue;
			}
			if (!num)
			{
				Properties.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			UpdateControlFromType();
			goto IL_005a;
			IL_005a:
			Properties.Inited = true;
			goto IL_0066;
			IL_0066:
			if (true)
			{
				break;
			}
			goto IL_0053;
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control;
		if (4u != 0)
		{
			control = new Control();
			control = (Control)P_0;
			bool flag = (_0003_0003._007E_001E_0013(control) != null) & Properties.Inited;
			if (4 == 0 || !flag)
			{
				return;
			}
		}
		_008F_0003._007E_0082_0014(this._0001, _008E_0003._007E_0081_0014(_008D_0003._007E_0080_0014(this._0002), _001D._0095_0006(_0003_0003._007E_001E_0013(control))));
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
