using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMUtility : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal Label _0001;

	internal Label _0002;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal NumericUpDown _0001;

	internal Panel _0002;

	internal NumericUpDown _0002;

	internal CheckBox _0003;

	internal NumericUpDown _0003;

	internal CheckBox _0004;

	internal CheckBox _0005;

	internal Label _0003;

	internal Panel _0003;

	internal Label _0004;

	internal Label _0005;

	internal CheckBox _0006;

	internal RadioButton _0003;

	internal NumericUpDown _0004;

	internal NumericUpDown _0005;

	internal Label _0006;

	internal NumericUpDown _0006;

	public F_MwTriMUtility()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		bool num = Properties.Height > 10;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		if (flag)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		if (Properties.Width > 10)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0088_0002(_008A_0005._007E_0094_0016(Par)));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0089_0002(_008A_0005._007E_0094_0016(Par)));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_008A_0002(_008A_0005._007E_0094_0016(Par)));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0001_0005(_008A_0005._007E_0094_0016(Par))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0002_0005(_008A_0005._007E_0094_0016(Par))));
		_0088_0003._007E_001A_0014(_0006, _0087_0003._0019_0014(global::_0007._007E_0003_0005(_008A_0005._007E_0094_0016(Par))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_008B_0002(_0089_0005._007E_0093_0016(Par)));
		_0095._007E_0096_000F(this._0006, global::_0003._007E_008C_0002(Par));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_001A_0003(Par)));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0006(Par));
		if (_008B_0005._007E_0095_0016(Par) == MachiningParamsAxialShiftType.AstConstForEachContour)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else if (_008B_0005._007E_0095_0016(Par) == MachiningParamsAxialShiftType.AstGradualForAllCuts)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		else if (_008B_0005._007E_0095_0016(Par) == MachiningParamsAxialShiftType.AstGradualForEachContour)
		{
			_0095._007E_0093_000F(this._0003, true);
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
		while (true)
		{
			bool flag = global::_0003._007E_001C(this._0002);
			while (uint.MaxValue != 0)
			{
				if (flag)
				{
					_0095._007E_0095_000F(this._0004, false);
					_0095 obj = _0095._007E_0095_000F;
					NumericUpDown numericUpDown = this._0004;
					if (0 == 0)
					{
						obj(numericUpDown, false);
					}
				}
				bool num = global::_0003._007E_001C(this._0001);
				while (true)
				{
					bool flag2 = num;
					num = flag2;
					while (true)
					{
						if (num)
						{
							_0095._007E_0095_000F(this._0004, true);
							goto IL_0080;
						}
						goto IL_0094;
						IL_0080:
						_0095._007E_0095_000F(this._0004, true);
						goto IL_0094;
						IL_0094:
						num = global::_0003._007E_001C(this._0003);
						if (2 == 0)
						{
							break;
						}
						bool flag3 = num;
						num = flag3;
						if (false)
						{
							break;
						}
						if (false)
						{
							continue;
						}
						if (num)
						{
							_0095._007E_0095_000F(this._0004, true);
							_0095._007E_0095_000F(this._0004, true);
							if (false)
							{
								goto IL_0080;
							}
							if (false)
							{
								goto end_IL_006a;
							}
						}
						_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
						do
						{
							_0095._007E_0095_000F(_0006, global::_0003._007E_0083(this._0005));
						}
						while (false);
						_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0003));
						_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0004));
						return;
					}
					continue;
					end_IL_006a:
					break;
				}
			}
		}
	}

	public void Apply()
	{
		_0095._007E_0012_0011(_008A_0005._007E_0094_0016(Par), global::_0003._007E_0083(this._0003));
		_0095._007E_0013_0011(_008A_0005._007E_0094_0016(Par), global::_0003._007E_0083(this._0004));
		_0095._007E_0014_0011(_008A_0005._007E_0094_0016(Par), global::_0003._007E_0083(this._0005));
		_0094._007E_0015_000E(_008A_0005._007E_0094_0016(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0016_000E(_008A_0005._007E_0094_0016(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_0017_000E(_008A_0005._007E_0094_0016(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0006)));
		_0095._007E_0010_0011(_0089_0005._007E_0093_0016(Par), global::_0003._007E_0083(this._0002));
		_0095._007E_0015_0011(Par, global::_0003._007E_0083(this._0006));
		_0094._007E_001B_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0095._007E_0006_000F(Par, global::_0003._007E_0083(this._0001));
		if (global::_0003._007E_001C(this._0002))
		{
			_008C_0005._007E_0096_0016(Par, MachiningParamsAxialShiftType.AstConstForEachContour);
		}
		if (global::_0003._007E_001C(this._0001))
		{
			_008C_0005._007E_0096_0016(Par, MachiningParamsAxialShiftType.AstGradualForAllCuts);
		}
		if (global::_0003._007E_001C(this._0003))
		{
			_008C_0005._007E_0096_0016(Par, MachiningParamsAxialShiftType.AstGradualForEachContour);
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		UpdateControlFromType();
	}

	internal void _0004(object P_0, EventArgs P_1)
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
