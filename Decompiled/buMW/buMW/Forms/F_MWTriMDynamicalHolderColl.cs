using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MWTriMDynamicalHolderColl : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public F_MWTriMDynamicalHolderColl()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		do
		{
			if (Properties.Width > 10)
			{
				_0097._008D_0011(this, Properties.Width);
			}
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
		}
		while (4 == 0);
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0015_0004(_0012_0004._007E_0003_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0001_0002(_0012_0004._007E_0003_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_0002_0002(_0012_0004._007E_0003_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		UpdateControlFromType();
		_008F_0003._007E_0082_0014(this._0001, null);
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
		if (7u != 0)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0002) | global::_0003._007E_0083(this._0001));
			if (false)
			{
				goto IL_0066;
			}
			if (1 == 0)
			{
				goto IL_006a;
			}
		}
		goto IL_0036;
		IL_0066:
		if (3 == 0)
		{
			goto IL_0036;
		}
		goto IL_006a;
		IL_006a:
		if (0 == 0)
		{
			return;
		}
		goto IL_0036;
		IL_0036:
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0002) | global::_0003._007E_0083(this._0001));
		goto IL_0066;
	}

	public void Apply()
	{
		_0094._007E_0087_0008(_0012_0004._007E_0003_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0095._007E_001D_0010(_0012_0004._007E_0003_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0001));
		_0095._007E_001E_0010(_0012_0004._007E_0003_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0002));
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		if (3u != 0)
		{
		}
		Control control = new Control();
		control = (Control)P_0;
		bool num = !Properties.Inited;
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
					Properties.Inited = false;
					if (0 == 0)
					{
						Apply();
						UpdateControlFromType();
						Properties.Inited = true;
						_0004(P_0, null);
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
