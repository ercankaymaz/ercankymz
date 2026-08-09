using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMRoughingAdvanced : Form
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

	public ComboBox combo_type;

	internal Label _0002;

	internal Label _0003;

	internal NumericUpDown _0001;

	internal Label _0004;

	public ComboBox combo_filterby;

	internal Label _0005;

	internal Panel _0002;

	internal Label _0006;

	internal NumericUpDown _0002;

	internal Panel _0003;

	internal Panel _0004;

	internal NumericUpDown _0003;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal CheckBox _0001;

	internal Label _0007;

	internal NumericUpDown _0004;

	internal CheckBox _0002;

	internal Label _0008;

	internal NumericUpDown _0005;

	internal CheckBox _0003;

	internal Label _000E;

	internal NumericUpDown _0006;

	internal CheckBox _0004;

	internal Label _000F;

	internal NumericUpDown _0007;

	internal CheckBox _0005;

	internal Label _0010;

	internal CheckBox _0006;

	internal Panel _0005;

	internal Label _0011;

	internal NumericUpDown _0008;

	internal Label _0012;

	internal CheckBox _0007;

	public F_MwTriMRoughingAdvanced()
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
		while (true)
		{
			_0095._0092_000F(this, Properties.TopMost);
			_0086_0003._0018_0014(this, Properties.FormPosition);
			if (!buMWCalcs.AdvancedTriMesh)
			{
				_0095._007E_001C_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), false);
				if (6 == 0)
				{
					goto IL_05a3;
				}
				_0095._007E_001D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), false);
				_0095._007E_001E_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), false);
				_0095._007E_001F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), false);
			}
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0005_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0006_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_0007_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0008_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_000E_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_000F_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
			if (6u != 0)
			{
				_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0010_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
				_0095._007E_0096_000F(_0007, global::_0003._007E_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
				_0095._007E_0096_000F(_0006, global::_0003._007E_0013(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
				_0095._007E_0096_000F(this._0002, global::_0003._007E_0095_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
				_0095._007E_0096_000F(this._0001, global::_0003._007E_0096_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
				_0095._007E_0096_000F(this._0003, global::_0003._007E_0097_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
				bool flag;
				if (0 == 0)
				{
					_0095._007E_0096_000F(this._0004, global::_0003._007E_0098_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
					_0095._007E_0096_000F(this._0005, global::_0003._007E_0099_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
					flag = _008F_0005._007E_0099_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices;
				}
				if (flag)
				{
					_0095._007E_0093_000F(this._0002, true);
				}
				else
				{
					if (8 == 0)
					{
						continue;
					}
					_0095._007E_0093_000F(this._0001, true);
				}
				if (_0090_0005._007E_009A_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions)
				{
					_0097._007E_008E_0011(combo_filterby, 0);
					goto IL_054c;
				}
			}
			_0097._007E_008E_0011(combo_filterby, 1);
			goto IL_054c;
			IL_058f:
			_0097._007E_008E_0011(combo_type, 1);
			goto IL_05a3;
			IL_05a3:
			if (0 == 0)
			{
				break;
			}
			goto IL_058f;
			IL_054c:
			if (_0091_0005._007E_009B_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) != TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle)
			{
				goto IL_058f;
			}
			_0097._007E_008E_0011(combo_type, 0);
			goto IL_05a3;
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
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
		{
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(_000E, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(_0007, true);
			_0095._007E_0095_000F(_0006, true);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0006, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(_0005, false);
			_0095._007E_0095_000F(combo_filterby, true);
			_0095._007E_0095_000F(this._0005, true);
			_0095._007E_0095_000F(combo_type, true);
			_0095._007E_0095_000F(this._0002, true);
			if (!buMWCalcs.AdvancedTriMesh)
			{
				_0095._007E_0095_000F(this._0002, false);
				_0095._007E_0095_000F(this._0005, false);
				_0095._007E_0095_000F(this._0003, false);
				_0095._007E_0095_000F(this._0004, false);
			}
			if (7 == 0)
			{
				goto IL_068a;
			}
		}
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
		{
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_000E, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(_0007, false);
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0006, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0003, true);
			_0095._007E_0095_000F(_0005, false);
			_0095._007E_0095_000F(combo_filterby, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(combo_type, true);
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0001));
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0001));
			if (!buMWCalcs.AdvancedTriMesh)
			{
				_0095._007E_0095_000F(this._0002, false);
				goto IL_068a;
			}
		}
		goto IL_06c2;
		IL_068a:
		_0095._007E_0095_000F(this._0005, false);
		_0095._007E_0095_000F(this._0003, false);
		_0095._007E_0095_000F(this._0004, false);
		goto IL_06c2;
		IL_06c2:
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
		{
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005));
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_000E, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0004) & global::_0003._007E_008C(this._0004));
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0005) & global::_0003._007E_008C(this._0005) & global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(_0007, false);
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(this._0007, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_008C(this._0002) & global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0006, true);
			_0095._007E_0095_000F(this._0002, true);
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(_0005, true);
			_0095._007E_0095_000F(combo_filterby, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(combo_type, true);
			_0095._007E_0095_000F(this._0002, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
		{
			_0095._007E_0095_000F(_0005, false);
			_0095._007E_0095_000F(this._0002, false);
			_0095._007E_0095_000F(_0006, false);
			_0095._007E_0095_000F(this._0001, true);
			_0095._007E_0095_000F(combo_filterby, false);
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(combo_type, false);
			_0095._007E_0095_000F(this._0002, false);
		}
	}

	public void Apply()
	{
		_0094._007E_0019_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_001A_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_001B_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0007)));
		_0094._007E_001C_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		_0094._007E_001D_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_001E_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_001F_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0095._007E_0013_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(_0007));
		_0095._007E_0014_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(_0006));
		_0095._007E_001C_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0002));
		if (4u != 0)
		{
			_0095._007E_0011_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0001));
			_0095._007E_001D_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0003));
			_0095._007E_001E_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0004));
			_0095._007E_001F_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0005));
			if (global::_000E._007E_000E_0006(combo_filterby) == 0)
			{
				_0092_0005._007E_009C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions);
			}
			else if (global::_000E._007E_000E_0006(combo_filterby) == 1)
			{
				_0092_0005._007E_009C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours);
			}
		}
		do
		{
			if (global::_000E._007E_000E_0006(combo_type) == 0)
			{
				_0093_0005._007E_009D_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle);
				continue;
			}
			if (global::_000E._007E_000E_0006(combo_type) == 1)
			{
				_0093_0005._007E_009D_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength);
			}
			break;
		}
		while (false);
		if (global::_0003._007E_001C(this._0002))
		{
			_0094_0005._007E_009E_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices);
		}
		else
		{
			_0094_0005._007E_009E_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice);
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
