using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMRoughing : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Panel _0001;

	internal Label _0002;

	internal CheckBox _0001;

	internal Button _0001;

	internal Button _0002;

	internal Label _0003;

	internal NumericUpDown _0001;

	public ComboBox combo_ramptype;

	internal Label _0004;

	internal Button _0003;

	internal Label _0005;

	internal NumericUpDown _0002;

	internal CheckBox _0002;

	internal Label _0006;

	internal NumericUpDown _0003;

	internal CheckBox _0003;

	internal CheckBox _0004;

	internal NumericUpDown _0004;

	internal Panel _0002;

	internal NumericUpDown _0005;

	internal NumericUpDown _0006;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Button _0004;

	internal CheckBox _0005;

	internal Button _0005;

	internal CheckBox _0006;

	internal Button _0006;

	internal CheckBox _0007;

	public F_MwTriMRoughing()
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
		bool num = Properties.Width > 10;
		while (true)
		{
			if (num)
			{
				_0097._008D_0011(this, Properties.Width);
			}
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
			_0095._007E_0096_000F(this._0002, global::_0003._007E_0090_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0004_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0095._007E_0096_000F(this._0005, global::_0003._007E_0091_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
			_0095._007E_0096_000F(this._0003, global::_0003._007E_0092_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_008B_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_008A_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0088_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0089_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			while (true)
			{
				_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0089_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
				_0095._007E_0096_000F(this._0001, global::_0003._007E_0093(_0015_0002._007E_001D_0012(Par)));
				_0095._007E_0096_000F(this._0006, global::_0003._007E_0093_0002(_0087_0004._007E_007F_0015(_008C_0002._007E_0096_0012(Par))));
				_0095._007E_0096_000F(_0007, global::_0003._007E_0094_0002(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par))));
				if (_000E_0002._007E_0016_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle)
				{
					_0095._007E_0093_000F(this._0002, true);
				}
				else
				{
					_0095._007E_0093_000F(this._0001, true);
				}
				if (_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic)
				{
					_0097._007E_008E_0011(combo_ramptype, 0);
					if (7 == 0)
					{
						continue;
					}
				}
				else if (_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtLine)
				{
					_0097._007E_008E_0011(combo_ramptype, 1);
				}
				else if (_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical)
				{
					_0097._007E_008E_0011(combo_ramptype, 2);
				}
				else
				{
					bool flag = _0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag;
					num = flag;
					if (false)
					{
						break;
					}
					if (num)
					{
						_0097._007E_008E_0011(combo_ramptype, 3);
					}
					else
					{
						_0097._007E_008E_0011(combo_ramptype, 4);
					}
				}
				UpdateControlFromType();
				Properties.Result = DialogResult.None;
				Properties.Inited = true;
				return;
			}
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
		if (global::_000E._007E_000E_0006(combo_ramptype) == 0)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095 obj = _0095._007E_0095_000F;
			NumericUpDown numericUpDown = this._0006;
			global::_0003._007E_0083(this._0003);
			obj(numericUpDown, false);
			_0095 obj2 = _0095._007E_0095_000F;
			RadioButton radioButton = this._0002;
			global::_0003._007E_0083(this._0003);
			obj2(radioButton, false);
			_0095 obj3 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown2 = this._0005;
			global::_0003._007E_0083(this._0003);
			obj3(numericUpDown2, false);
			_0095 obj4 = _0095._007E_0095_000F;
			RadioButton radioButton2 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj4(radioButton2, false);
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0003));
		}
		if (global::_000E._007E_000E_0006(combo_ramptype) == 1)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095 obj5 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown3 = this._0006;
			global::_0003._007E_0083(this._0003);
			obj5(numericUpDown3, false);
			_0095 obj6 = _0095._007E_0095_000F;
			RadioButton radioButton3 = this._0002;
			global::_0003._007E_0083(this._0003);
			obj6(radioButton3, false);
			_0095 obj7 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown4 = this._0005;
			global::_0003._007E_0083(this._0003);
			obj7(numericUpDown4, false);
			_0095 obj8 = _0095._007E_0095_000F;
			RadioButton radioButton4 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj8(radioButton4, false);
			_0095 obj9 = _0095._007E_0095_000F;
			CheckBox checkBox = this._0004;
			global::_0003._007E_0083(this._0003);
			obj9(checkBox, false);
			if (3 == 0)
			{
				goto IL_0917;
			}
			_0095 obj10 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown5 = this._0003;
			global::_0003._007E_0083(this._0003);
			obj10(numericUpDown5, false);
			_0095 obj11 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown6 = this._0004;
			global::_0003._007E_0083(this._0003);
			obj11(numericUpDown6, false);
			_0095 obj12 = _0095._007E_0095_000F;
			Label label = this._0006;
			global::_0003._007E_0083(this._0003);
			obj12(label, false);
		}
		if (global::_000E._007E_000E_0006(combo_ramptype) == 2)
		{
			_0095 obj13 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown7 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj13(numericUpDown7, false);
			_0095 obj14 = _0095._007E_0095_000F;
			Label label2 = this._0003;
			global::_0003._007E_0083(this._0003);
			obj14(label2, false);
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0003));
		}
		if (global::_000E._007E_000E_0006(combo_ramptype) == 3)
		{
			if (false)
			{
				goto IL_0861;
			}
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095 obj15 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown8 = this._0006;
			global::_0003._007E_0083(this._0003);
			obj15(numericUpDown8, false);
			_0095 obj16 = _0095._007E_0095_000F;
			RadioButton radioButton5 = this._0002;
			global::_0003._007E_0083(this._0003);
			obj16(radioButton5, false);
			_0095 obj17 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown9 = this._0005;
			global::_0003._007E_0083(this._0003);
			obj17(numericUpDown9, false);
			_0095 obj18 = _0095._007E_0095_000F;
			RadioButton radioButton6 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj18(radioButton6, false);
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0003));
		}
		if (global::_000E._007E_000E_0006(combo_ramptype) == 4)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095 obj19 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown10 = this._0006;
			global::_0003._007E_0083(this._0003);
			obj19(numericUpDown10, false);
			_0095 obj20 = _0095._007E_0095_000F;
			RadioButton radioButton7 = this._0002;
			global::_0003._007E_0083(this._0003);
			obj20(radioButton7, false);
			_0095 obj21 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown11 = this._0005;
			global::_0003._007E_0083(this._0003);
			obj21(numericUpDown11, false);
			_0095 obj22 = _0095._007E_0095_000F;
			RadioButton radioButton8 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj22(radioButton8, false);
			_0095 obj23 = _0095._007E_0095_000F;
			CheckBox checkBox2 = this._0004;
			global::_0003._007E_0083(this._0003);
			obj23(checkBox2, false);
			_0095 obj24 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown12 = this._0003;
			global::_0003._007E_0083(this._0003);
			obj24(numericUpDown12, false);
			_0095 obj25 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown13 = this._0004;
			global::_0003._007E_0083(this._0003);
			obj25(numericUpDown13, false);
			_0095 obj26 = _0095._007E_0095_000F;
			Label label3 = this._0006;
			global::_0003._007E_0083(this._0003);
			obj26(label3, false);
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0095_000F(this._0006, global::_0003._007E_008C(this._0002) & global::_0003._007E_008C(this._0001));
			_0095 obj27 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown14 = this._0005;
			global::_0003._007E_008C(this._0002);
			obj27(numericUpDown14, (byte)(0u & (global::_0003._007E_008C(this._0001) ? 1u : 0u)) != 0);
		}
		else
		{
			_0095 obj28 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown15 = this._0006;
			global::_0003._007E_008C(this._0002);
			obj28(numericUpDown15, (byte)(0u & (global::_0003._007E_008C(this._0001) ? 1u : 0u)) != 0);
			_0095._007E_0095_000F(this._0005, global::_0003._007E_008C(this._0002) & global::_0003._007E_008C(this._0001));
		}
		_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(_0007));
		goto IL_0861;
		IL_0861:
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0005));
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0006));
		_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0004) & global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
		goto IL_0917;
		IL_0917:
		_0095._007E_0095_000F(combo_ramptype, global::_0003._007E_0083(this._0003));
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
		{
			_0095._007E_0095_000F(this._0001, true);
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(this._0002, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
		{
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0002, false);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil)
		{
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0002, false);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
		{
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0002, true);
		}
	}

	public void Apply()
	{
		_0095._007E_0017_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0002));
		if (3 == 0)
		{
			goto IL_0328;
		}
		_0094._007E_0018_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0095._007E_0018_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0005));
		_0095._007E_0019_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0003));
		if (0 == 0)
		{
			_0094._007E_0096_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0094._007E_0095_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			_0094._007E_0093_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
			_0094._007E_0094_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			_0094._007E_0094_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
			_0095._007E_0012_0010(_0015_0002._007E_001D_0012(Par), global::_0003._007E_0083(this._0001));
			_0095._007E_001A_0011(_0087_0004._007E_007F_0015(_008C_0002._007E_0096_0012(Par)), global::_0003._007E_0083(this._0006));
			_0095._007E_001B_0011(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(Par)), global::_0003._007E_0083(_0007));
		}
		if (global::_000E._007E_000E_0006(combo_ramptype) == 0)
		{
			_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic);
		}
		else
		{
			if (global::_000E._007E_000E_0006(combo_ramptype) == 1)
			{
				goto IL_0328;
			}
			if (global::_000E._007E_000E_0006(combo_ramptype) == 2)
			{
				_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical);
			}
			else if (global::_000E._007E_000E_0006(combo_ramptype) == 3)
			{
				_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag);
			}
			else if (global::_000E._007E_000E_0006(combo_ramptype) == 4)
			{
				goto IL_03f3;
			}
		}
		goto IL_041b;
		IL_041b:
		if (global::_0003._007E_001C(this._0002))
		{
			_001F_0002._007E_0089_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle);
			if (0 == 0)
			{
				return;
			}
			goto IL_03f3;
		}
		_001F_0002._007E_0089_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRampMode.TmbRmPitch);
		return;
		IL_03f3:
		_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRampType.TmbRtProfile);
		goto IL_041b;
		IL_0328:
		_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRampType.TmbRtLine);
		goto IL_041b;
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

	internal void _0005(object P_0, EventArgs P_1)
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

	internal void _0006(object P_0, EventArgs P_1)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		if (false || global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_MwTriMStockDef f_MwTriMStockDef = new F_MwTriMStockDef();
			f_MwTriMStockDef.Par = new MachiningParams(Par);
			f_MwTriMStockDef.Init();
			_009D_0003._007E_0091_0014(f_MwTriMStockDef);
			if (f_MwTriMStockDef.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMStockDef.Par);
				global::_0011._007E_001C_0006(f_MwTriMStockDef);
			}
		}
		F_MwTriMRotate f_MwTriMRotate = default(F_MwTriMRotate);
		while (true)
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				F_MwTriMRoughingAdvanced f_MwTriMRoughingAdvanced = new F_MwTriMRoughingAdvanced();
				f_MwTriMRoughingAdvanced.Par = new MachiningParams(Par);
				f_MwTriMRoughingAdvanced.Init();
				_009D_0003._007E_0091_0014(f_MwTriMRoughingAdvanced);
				if (f_MwTriMRoughingAdvanced.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMRoughingAdvanced.Par);
					global::_0011._007E_001C_0006(f_MwTriMRoughingAdvanced);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				f_MwTriMRotate = new F_MwTriMRotate();
				f_MwTriMRotate.Par = new MachiningParams(Par);
				f_MwTriMRotate.Init();
				_009D_0003._007E_0091_0014(f_MwTriMRotate);
				bool flag = f_MwTriMRotate.Properties.Result == DialogResult.OK;
				if (false)
				{
					goto IL_024f;
				}
				if (flag)
				{
					goto IL_01b2;
				}
			}
			goto IL_01d6;
			IL_01d6:
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006));
			bool num = flag2;
			F_MwTriMMirror f_MwTriMMirror;
			if (4u != 0)
			{
				if (!num)
				{
					break;
				}
				if (6 == 0)
				{
					goto IL_01c4;
				}
				f_MwTriMMirror = new F_MwTriMMirror();
				bool flag3;
				if (7u != 0)
				{
					f_MwTriMMirror.Par = new MachiningParams(Par);
					f_MwTriMMirror.Init();
					_009D_0003._007E_0091_0014(f_MwTriMMirror);
					flag3 = f_MwTriMMirror.Properties.Result == DialogResult.OK;
				}
				num = flag3;
			}
			if (!num)
			{
				break;
			}
			goto IL_024f;
			IL_01b2:
			Par = new MachiningParams(f_MwTriMRotate.Par);
			goto IL_01c4;
			IL_024f:
			Par = new MachiningParams(f_MwTriMMirror.Par);
			if (0 == 0)
			{
				global::_0011._007E_001C_0006(f_MwTriMMirror);
				break;
			}
			continue;
			IL_01c4:
			if (1 == 0)
			{
				goto IL_01b2;
			}
			global::_0011._007E_001C_0006(f_MwTriMRotate);
			goto IL_01d6;
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
