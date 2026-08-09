using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMMirror : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Label _0001;

	internal Panel _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal Label _0004;

	public ComboBox combo_direction;

	internal NumericUpDown _0002;

	internal Label _0005;

	internal Label _0006;

	internal NumericUpDown _0003;

	internal ImageList _0001;

	public Button btn_ok;

	internal Label _0007;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal CheckBox _0001;

	public F_MwTriMMirror()
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
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(_0018_0004._007E_000E_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).X));
		_0088_0003._007E_001A_0014(_0003, _0087_0003._0019_0014(_0018_0004._007E_000E_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Y));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(_0018_0004._007E_000E_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Z));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0006_0002(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))));
		if ((_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).X == 1.0) & (_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Y == 0.0) & (_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Z == 0.0))
		{
			_0097._007E_008E_0011(combo_direction, 0);
		}
		else if ((_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).X == 0.0) & (_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Y == 1.0) & (_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Z == 0.0))
		{
			_0097._007E_008E_0011(combo_direction, 1);
		}
		else if ((_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).X == 0.0) & (_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Y == 0.0) & (_0019_0004._007E_0010_0015(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))).Z == 1.0))
		{
			_0097._007E_008E_0011(combo_direction, 2);
		}
		else
		{
			_0097._007E_008E_0011(combo_direction, 3);
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

	public void UpdateControlFromType()
	{
	}

	public void Apply()
	{
		_0095._007E_0081_0010(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par)), global::_0003._007E_0083(this._0001));
		while (true)
		{
			_0091_0002._007E_009E_0012(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par)), new Point3d<double>(_008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0003)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002))));
			bool flag;
			do
			{
				flag = global::_000E._007E_000E_0006(combo_direction) == 0;
			}
			while (4 == 0);
			if (!flag)
			{
				break;
			}
			if (uint.MaxValue != 0)
			{
				_0010_0003._007E_0087_0013(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par)), new Vectord(1.0, 0.0, 0.0));
				break;
			}
		}
		bool flag2;
		if (5u != 0)
		{
			if (global::_000E._007E_000E_0006(combo_direction) == 1)
			{
				do
				{
					_0010_0003._007E_0087_0013(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par)), new Vectord(0.0, 1.0, 0.0));
				}
				while (7 == 0);
			}
			flag2 = global::_000E._007E_000E_0006(combo_direction) == 2;
		}
		if (flag2)
		{
			_0010_0003._007E_0087_0013(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par)), new Vectord(0.0, 0.0, 1.0));
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
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
