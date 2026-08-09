using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMRetract : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal CheckBox _0003;

	public ComboBox combo_type;

	internal Panel _0002;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal Label _0005;

	internal NumericUpDown _0004;

	internal Label _0006;

	internal Panel _0003;

	internal Label _0007;

	public ComboBox combo_heights;

	internal Label _0008;

	public ComboBox combo_dir;

	internal Label _000E;

	internal Label _000F;

	internal Panel _0004;

	internal Label _0010;

	internal NumericUpDown _0005;

	internal Label _0011;

	internal NumericUpDown _0006;

	internal NumericUpDown _0007;

	internal CheckBox _0004;

	internal CheckBox _0005;

	internal Label _0012;

	internal Panel _0005;

	internal Label _0013;

	internal NumericUpDown _0008;

	internal Label _0014;

	internal NumericUpDown _000E;

	public ComboBox combo_distances;

	internal Label _0015;

	internal Label _0016;

	internal NumericUpDown _000F;

	internal Label _0017;

	internal NumericUpDown _0010;

	internal Label _0018;

	internal Label _0019;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal NumericUpDown _0011;

	public F_MwTriMRetract()
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
			if (2 == 0)
			{
				goto IL_0593;
			}
			_0097._008C_0011(this, Properties.Height);
		}
		if (0 == 0)
		{
			if (Properties.Width > 10)
			{
				_0097._008D_0011(this, Properties.Width);
				if (1 == 0)
				{
					goto IL_00c1;
				}
			}
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
			goto IL_00c1;
		}
		goto IL_02d2;
		IL_02d2:
		_0088_0003._007E_001A_0014(_0010, _0087_0003._0019_0014(global::_0007._007E_001D_0003(_008B._007E_0008_0007(Par))));
		_0088_0003._007E_001A_0014(_000E, _0087_0003._0019_0014(global::_0007._007E_0087_0004(_008B._007E_0008_0007(Par))));
		_0088_0003._007E_001A_0014(_000F, _0087_0003._0019_0014(global::_0007._007E_001E_0003(_008B._007E_0008_0007(Par))));
		goto IL_0371;
		IL_0371:
		_0088_0003._007E_001A_0014(_0011, _0087_0003._0019_0014(global::_0007._007E_001C_0003(_008B._007E_0008_0007(Par))));
		if (_0080_0004._007E_001A_0015(_008B._007E_0008_0007(Par)) == LinkParamsClearanceAxis.AxisX)
		{
			_0097._007E_008E_0011(combo_dir, 0);
		}
		else if (_0080_0004._007E_001A_0015(_008B._007E_0008_0007(Par)) == LinkParamsClearanceAxis.AxisY)
		{
			_0097._007E_008E_0011(combo_dir, 1);
		}
		else
		{
			if (_0080_0004._007E_001A_0015(_008B._007E_0008_0007(Par)) != LinkParamsClearanceAxis.AxisZ)
			{
				goto IL_0454;
			}
			_0097._007E_008E_0011(combo_dir, 2);
		}
		goto IL_04c4;
		IL_0571:
		if (false)
		{
			goto IL_0371;
		}
		goto IL_0593;
		IL_04c4:
		while (true)
		{
			if (_0081_0004._007E_001B_0015(_008B._007E_0008_0007(Par)) == LinkParamsFeedDistanceMode.FdmPreviousZHeight)
			{
				_0097._007E_008E_0011(combo_distances, 0);
			}
			else if (_0081_0004._007E_001B_0015(_008B._007E_0008_0007(Par)) == LinkParamsFeedDistanceMode.FdmCurrentZHeight)
			{
				_0097._007E_008E_0011(combo_distances, 1);
			}
			if (_0082_0004._007E_001C_0015(_008B._007E_0008_0007(Par)) != LinkParamsClearancePlaneHeightDefinition.CphdAutomatic)
			{
				break;
			}
			_0097._007E_008E_0011(combo_heights, 0);
			if (false)
			{
				continue;
			}
			goto IL_0571;
		}
		if (8 == 0)
		{
			goto IL_0454;
		}
		_0097._007E_008E_0011(combo_heights, 1);
		goto IL_0593;
		IL_0454:
		if (_0080_0004._007E_001A_0015(_008B._007E_0008_0007(Par)) == LinkParamsClearanceAxis.AxisCustom)
		{
			_0097._007E_008E_0011(combo_dir, 3);
		}
		else if (_0080_0004._007E_001A_0015(_008B._007E_0008_0007(Par)) == LinkParamsClearanceAxis.MachiningDirection)
		{
			_0097._007E_008E_0011(combo_dir, 4);
		}
		goto IL_04c4;
		IL_0593:
		_0097._007E_008E_0011(combo_type, 0);
		do
		{
			UpdateControlFromType();
		}
		while (false);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_00c1:
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0082_0004(_008B._007E_0008_0007(Par))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0083_0004(_008B._007E_0008_0007(Par))));
		if (0 == 0)
		{
			_0088_0003._007E_001A_0014(_0007, _0087_0003._0019_0014(global::_0007._007E_0084_0004(_008B._007E_0008_0007(Par))));
			_0095._007E_0096_000F(this._0001, global::_0003._007E_0013_0002(_008B._007E_0008_0007(Par)));
			_0095._007E_0096_000F(this._0002, global::_0003._007E_0014_0002(_008B._007E_0008_0007(Par)));
			_0095._007E_0096_000F(this._0003, global::_0003._007E_0015_0002(_008B._007E_0008_0007(Par)));
			_0095._007E_0096_000F(this._0005, global::_0003._007E_0016_0002(_008B._007E_0008_0007(Par)));
			_0095._007E_0096_000F(this._0004, global::_0003._007E_0015_0002(_008B._007E_0008_0007(Par)));
			_0095._007E_0096_000F(this._0003, global::_0003._007E_0017_0002(_008B._007E_0008_0007(Par)));
			_0088_0003._007E_001A_0014(_0006, _0087_0003._0019_0014(global::_0007._007E_0086_0004(_008B._007E_0008_0007(Par))));
			_0088_0003._007E_001A_0014(_0008, _0087_0003._0019_0014(global::_0007._007E_001B_0003(_008B._007E_0008_0007(Par))));
			goto IL_02d2;
		}
		goto IL_04c4;
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
		if (true)
		{
			_0095._007E_0095_000F(_0007, global::_0003._007E_0083(this._0004));
			goto IL_0030;
		}
		goto IL_009d;
		IL_009d:
		_0095._007E_0095_000F(_0011, false);
		goto IL_00cc;
		IL_0030:
		while (1 == 0)
		{
		}
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003) | global::_0003._007E_0083(this._0002) | global::_0003._007E_0083(this._0001));
		goto IL_0081;
		IL_00cc:
		if (8u != 0)
		{
			if (4u != 0)
			{
				return;
			}
			goto IL_0081;
		}
		goto IL_009d;
		IL_0081:
		int num = global::_000E._007E_000E_0006(combo_heights);
		if (uint.MaxValue != 0)
		{
			num = ((num == 0) ? 1 : 0);
		}
		if (num != 0)
		{
			goto IL_009d;
		}
		_0095._007E_0095_000F(_0011, true);
		if (4 == 0)
		{
			goto IL_0030;
		}
		goto IL_00cc;
	}

	public void Apply()
	{
		_0094._007E_0093_0008(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_0094_0008(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_0095_0008(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0007)));
		_0095._007E_0088_0010(_008B._007E_0008_0007(Par), global::_0003._007E_0083(this._0001));
		_0095._007E_0089_0010(_008B._007E_0008_0007(Par), global::_0003._007E_0083(this._0002));
		_0095._007E_008A_0010(_008B._007E_0008_0007(Par), global::_0003._007E_0083(this._0003));
		_0095._007E_008B_0010(_008B._007E_0008_0007(Par), global::_0003._007E_0083(this._0005));
		if (false)
		{
			return;
		}
		bool num;
		while (true)
		{
			_0095._007E_008A_0010(_008B._007E_0008_0007(Par), global::_0003._007E_0083(this._0004));
			_0095._007E_008C_0010(_008B._007E_0008_0007(Par), global::_0003._007E_0083(this._0003));
			_0094._007E_0096_0008(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0006)));
			_0094._007E_001C_0007(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0008)));
			_0094._007E_001E_0007(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0010)));
			_0094._007E_0097_0008(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_000E)));
			if (uint.MaxValue != 0)
			{
				_0094._007E_001F_0007(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_000F)));
				_0094._007E_007F_0007(_008B._007E_0008_0007(Par), global::_0007._007E_001E_0003(_008B._007E_0008_0007(Par)));
				_0094._007E_001D_0007(_008B._007E_0008_0007(Par), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0011)));
				if (global::_000E._007E_000E_0006(combo_dir) != 0)
				{
					num = global::_000E._007E_000E_0006(combo_dir) == 1;
					goto IL_0387;
				}
				_0083_0004._007E_001D_0015(_008B._007E_0008_0007(Par), LinkParamsClearanceAxis.AxisX);
			}
			goto IL_045f;
			IL_0476:
			bool num2;
			if (num2 != 0)
			{
				_0084_0004._007E_001E_0015(_008B._007E_0008_0007(Par), LinkParamsFeedDistanceMode.FdmPreviousZHeight);
				if (6 == 0)
				{
					continue;
				}
			}
			else
			{
				_0084_0004._007E_001E_0015(_008B._007E_0008_0007(Par), LinkParamsFeedDistanceMode.FdmCurrentZHeight);
				if (false)
				{
					goto IL_045f;
				}
			}
			int num3 = global::_000E._007E_000E_0006(combo_heights);
			int num4 = 0;
			if (num4 == 0)
			{
				num = num3 == num4;
				if (6u != 0)
				{
					break;
				}
				goto IL_0387;
			}
			goto IL_0402;
			IL_0402:
			if (num3 == num4)
			{
				_0083_0004._007E_001D_0015(_008B._007E_0008_0007(Par), LinkParamsClearanceAxis.AxisCustom);
			}
			else if (global::_000E._007E_000E_0006(combo_dir) == 4)
			{
				_0083_0004._007E_001D_0015(_008B._007E_0008_0007(Par), LinkParamsClearanceAxis.MachiningDirection);
			}
			goto IL_045f;
			IL_0387:
			bool flag = num;
			num2 = flag;
			if (5u != 0 && 0 == 0)
			{
				if (num2)
				{
					_0083_0004._007E_001D_0015(_008B._007E_0008_0007(Par), LinkParamsClearanceAxis.AxisY);
				}
				else
				{
					if (global::_000E._007E_000E_0006(combo_dir) != 2)
					{
						num3 = global::_000E._007E_000E_0006(combo_dir);
						num4 = 3;
						goto IL_0402;
					}
					_0083_0004._007E_001D_0015(_008B._007E_0008_0007(Par), LinkParamsClearanceAxis.AxisZ);
				}
				goto IL_045f;
			}
			goto IL_0476;
			IL_045f:
			bool flag2 = global::_000E._007E_000E_0006(combo_distances) == 0;
			num2 = flag2;
			goto IL_0476;
		}
		if (num)
		{
			_0086_0004._007E_001F_0015(_008B._007E_0008_0007(Par), LinkParamsClearancePlaneHeightDefinition.CphdAutomatic);
		}
		else
		{
			_0086_0004._007E_001F_0015(_008B._007E_0008_0007(Par), LinkParamsClearancePlaneHeightDefinition.CphdUserDefined);
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
