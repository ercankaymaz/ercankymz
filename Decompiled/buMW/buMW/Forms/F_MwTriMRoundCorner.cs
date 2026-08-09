using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMRoundCorner : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal PictureBox _0001;

	internal ImageList _0001;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList _0002;

	public F_MwTriMRoundCorner()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		_0005._0002._0001(this);
	}

	public void Init()
	{
		do
		{
			Properties.Inited = false;
			if (Properties.Height > 10)
			{
				_0097._008C_0011(this, Properties.Height);
			}
			bool num = Properties.Width > 10;
			if (uint.MaxValue != 0)
			{
				bool flag = num;
				num = flag;
			}
			if (num)
			{
				_0097._008D_0011(this, Properties.Width);
			}
		}
		while (false);
		_0095._0092_000F(this, Properties.TopMost);
		while (0 == 0)
		{
			_0086_0003._0018_0014(this, Properties.FormPosition);
			if (0 == 0)
			{
				_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0098_0004(Par)));
				UpdateControlFromType();
				_008F_0003._007E_0082_0014(this._0001, null);
				break;
			}
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
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
	}

	public void Apply()
	{
		if (4u != 0)
		{
			_0094._007E_009A_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
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
