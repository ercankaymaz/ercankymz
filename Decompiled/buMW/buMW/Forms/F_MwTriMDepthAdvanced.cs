using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.DialogBox;

namespace buMW.Forms;

public class F_MwTriMDepthAdvanced : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal ImageList _0001;

	public Button btn_cancel;

	public Button btn_ok;

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal Panel _0001;

	internal CheckBox _0002;

	internal Label _0001;

	internal NumericUpDown _0002;

	internal CheckBox _0003;

	internal CheckBox _0004;

	internal ListBox _0001;

	internal NumericUpDown _0003;

	internal NumericUpDown _0004;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0002;

	internal NumericUpDown _0005;

	internal Panel _0002;

	internal CheckBox _0005;

	internal Label _0003;

	internal NumericUpDown _0006;

	internal NumericUpDown _0007;

	internal CheckBox _0006;

	internal Label _0004;

	internal Label _0005;

	internal PictureBox _0001;

	internal Button _0001;

	internal Button _0002;

	internal Panel _0003;

	internal Panel _0004;

	internal CheckBox _0007;

	internal Label _0006;

	internal NumericUpDown _0008;

	internal Label _0007;

	internal NumericUpDown _000E;

	internal CheckBox _0008;

	internal CheckBox _000E;

	internal CheckBox _000F;

	internal Panel _0005;

	[NonSerialized]
	internal static GetString _0098;

	public F_MwTriMDepthAdvanced()
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
		int num = ((Properties.Width > 10) ? 1 : 0);
		if (6u != 0)
		{
			bool flag = (byte)num != 0;
			if (8u != 0)
			{
				if (flag)
				{
					_0097._008D_0011(this, Properties.Width);
				}
				_0095._0092_000F(this, Properties.TopMost);
				_0086_0003._0018_0014(this, Properties.FormPosition);
				if (_008F._007E_0013_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
				{
					_0095._007E_0093_000F(this._0002, true);
				}
				else if (_008F._007E_0013_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices)
				{
					_0095._007E_0093_000F(this._0001, true);
				}
				goto IL_0153;
			}
			goto IL_04aa;
		}
		goto IL_073e;
		IL_04aa:
		_0095._007E_0096_000F(_0008, global::_0003._007E_009D(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0007, global::_0003._007E_009E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_0014_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_0087_0003(Par)));
		if (4 == 0)
		{
			goto IL_0153;
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
		{
			_0095._007E_0096_000F(this._0006, global::_0003._007E_009F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
			_0095._007E_0094_000F(this._0004, false);
			_0095._007E_0094_000F(this._0003, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
		{
			_0095._007E_0096_000F(_000F, global::_0003._007E_009F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
			_0095._007E_0094_000F(this._0004, true);
			_0095._007E_0094_000F(this._0003, false);
			_0005_0004._007E_0098_0014(this._0004, new Point(5, 204));
		}
		global::_0011._007E_001D_0006(_0006_0004._007E_009A_0014(this._0001));
		int num2 = 0;
		goto IL_073c;
		IL_0153:
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_000E_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0003, _0004_0004._0097_0014(global::_000E._007E_000F_0006(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_000F_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		while (false)
		{
		}
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0010_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0011_0004(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0012_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_0013_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		do
		{
			_0095._007E_0096_000F(this._0005, global::_0003._007E_0097(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		}
		while (false);
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0098(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0099(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_009A(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_009B(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(_000E, global::_0003._007E_009C(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		goto IL_04aa;
		IL_073e:
		if (num <= global::_000E._007E_0010_0006(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))) - 1)
		{
			_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), _0008_0004._007E_009C_0014(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))), num2));
			num2++;
			goto IL_073c;
		}
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_073c:
		num = num2;
		goto IL_073e;
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
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005));
		_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0006));
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(this._0003, false);
		}
		if (global::_0003._007E_001C(this._0001))
		{
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0003, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
		{
			_0095._007E_0095_000F(_0008, !global::_0003._007E_0083(_000E));
			_0095._007E_0095_000F(_000F, !global::_0003._007E_0083(_0008));
			_0095._007E_0095_000F(_000E, !global::_0003._007E_0083(_0008));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(_0008) & global::_0003._007E_008C(_0008));
		}
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(_000F, false);
		}
	}

	public void Apply()
	{
		_0094._007E_0081_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0097._007E_008F_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_0082_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_0089_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0083_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_008C_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		_0094._007E_008B_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0007)));
		_0095._007E_001A_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0005));
		_0095._007E_0016_0010(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0003));
		_0095._007E_0017_0010(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0001));
		_0095._007E_0018_0010(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0002));
		_0095._007E_0019_0010(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0004));
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
		{
			_0095._007E_001A_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0006));
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
		{
			_0095._007E_001A_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(_000F));
		}
		_0095._007E_0019_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(_000E));
		_0095._007E_001B_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(_0008));
		_0095._007E_001C_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0007));
		_0094._007E_0084_0008(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._000E)));
		_0094._007E_0088_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0008)));
		global::_0011._007E_001E_0006(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		for (int i = 0; i <= global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1; i++)
		{
			_0094._007E_0086_0008(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))), _0011_0004._0002_0015(_0010_0004._007E_0001_0015(_0006_0004._007E_009A_0014(this._0001), i)));
		}
		if (global::_0003._007E_001C(this._0002))
		{
			global::_0098._007E_009B_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep);
		}
		else if (global::_0003._007E_001C(this._0001))
		{
			global::_0098._007E_009B_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices);
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		bool num = global::_0003._007E_001C(this._0002);
		bool flag;
		if (5u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset);
		}
		else if (global::_0003._007E_001C(this._0001))
		{
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel);
		}
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
		DialogBoxInput dialogBoxInput = new DialogBoxInput();
		while (true)
		{
			dialogBoxInput.ValueCaption = _0098(107396918);
			_0086_0003._007E_0018_0014(dialogBoxInput, FormStartPosition.CenterParent);
			while (true)
			{
				dialogBoxInput.FormCaption = _0098(107396918);
				if (1 == 0)
				{
					break;
				}
				global::_0011._007E_001F_0006(dialogBoxInput);
				_009D_0003._007E_0091_0014(dialogBoxInput);
				bool num = dialogBoxInput.Result == DialogResult.OK;
				bool flag;
				if (0 == 0)
				{
					flag = num;
					goto IL_007a;
				}
				goto IL_007b;
				IL_007b:
				if (num)
				{
					if (3 == 0)
					{
						continue;
					}
					_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), dialogBoxInput.Value);
					if (4u != 0)
					{
						return;
					}
					goto IL_007a;
				}
				return;
				IL_007a:
				num = flag;
				goto IL_007b;
			}
		}
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		while (true)
		{
			bool num = global::_000E._007E_000E_0006(this._0001) < 0;
			if (4u != 0)
			{
				if (false)
				{
					goto IL_0065;
				}
				num = !num;
			}
			int num2 = global::_000E._007E_000E_0006(this._0001);
			int num3 = global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001));
			do
			{
				num3--;
			}
			while (false || 5 == 0);
			bool flag = num && num2 <= num3;
			num = flag;
			goto IL_0065;
			IL_0065:
			if (num)
			{
				if (0 == 0)
				{
					_0097._007E_0090_0011(_0006_0004._007E_009A_0014(this._0001), global::_000E._007E_000E_0006(this._0001));
					break;
				}
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

	static F_MwTriMDepthAdvanced()
	{
		Strings.CreateGetStringDelegate(typeof(F_MwTriMDepthAdvanced));
	}
}
