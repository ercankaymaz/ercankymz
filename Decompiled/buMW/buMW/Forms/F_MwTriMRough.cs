using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMRough : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	[CompilerGenerated]
	private MWDataOrjOkHandler m__0001;

	[CompilerGenerated]
	private CancelCommandEventHandler m__0001;

	internal IContainer _0001 = null;

	internal TabControl _0001;

	internal TabPage _0001;

	internal Panel _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0001;

	internal Panel _0002;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal Label _0005;

	internal NumericUpDown _0003;

	internal NumericUpDown _0004;

	internal Label _0006;

	internal Panel _0003;

	internal Label _0007;

	internal Button _0001;

	internal NumericUpDown _0005;

	internal Label _0008;

	internal Panel _0004;

	internal Button _0002;

	internal NumericUpDown _0006;

	internal NumericUpDown _0007;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal Label _000E;

	internal Panel _0005;

	internal NumericUpDown _0008;

	internal RadioButton _0005;

	internal Label _000F;

	internal RadioButton _0006;

	internal RadioButton _0007;

	internal Panel _0006;

	internal Label _0010;

	internal RadioButton _0008;

	internal RadioButton _000E;

	internal Panel _0007;

	internal RadioButton _000F;

	internal Label _0011;

	internal Panel _0008;

	internal CheckBox _0001;

	internal Button _0003;

	internal CheckBox _0002;

	internal Button _0004;

	internal CheckBox _0003;

	internal Button _0005;

	internal CheckBox _0004;

	internal Button _0006;

	internal CheckBox _0005;

	internal Button _0007;

	internal CheckBox _0006;

	internal Label _0012;

	internal NumericUpDown _000E;

	internal Label _0013;

	internal CheckBox _0007;

	internal Panel _000E;

	internal Label _0014;

	internal RadioButton _0010;

	internal RadioButton _0011;

	internal PictureBox _0001;

	internal ImageList _0001;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label _0015;

	internal Label _0016;

	internal Panel _000F;

	internal CheckBox _0008;

	internal Label _0017;

	internal NumericUpDown _000F;

	internal Label _0018;

	internal NumericUpDown _0010;

	internal Label _0019;

	internal NumericUpDown _0011;

	internal Label _001A;

	internal Label _001B;

	internal NumericUpDown _0012;

	internal CheckBox _000E;

	internal CheckBox _000F;

	internal Button _0008;

	internal Button _000E;

	internal Button _000F;

	internal Button _0010;

	internal Panel _0010;

	internal Button _0011;

	internal Button _0012;

	internal Label _001C;

	internal Button _0013;

	public event MWDataOrjOkHandler OkClick
	{
		[CompilerGenerated]
		add
		{
			MWDataOrjOkHandler mWDataOrjOkHandler = this.m__0001;
			while (true)
			{
				MWDataOrjOkHandler mWDataOrjOkHandler2 = mWDataOrjOkHandler;
				while (true)
				{
					MWDataOrjOkHandler obj = (MWDataOrjOkHandler)global::_0016._008D_0006(mWDataOrjOkHandler2, value);
					MWDataOrjOkHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWDataOrjOkHandler = Interlocked.CompareExchange(ref this.m__0001, value2, mWDataOrjOkHandler2);
					if ((object)mWDataOrjOkHandler != mWDataOrjOkHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			MWDataOrjOkHandler mWDataOrjOkHandler = this.m__0001;
			while (true)
			{
				MWDataOrjOkHandler mWDataOrjOkHandler2 = mWDataOrjOkHandler;
				while (true)
				{
					MWDataOrjOkHandler obj = (MWDataOrjOkHandler)global::_0016._008E_0006(mWDataOrjOkHandler2, value);
					MWDataOrjOkHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					mWDataOrjOkHandler = Interlocked.CompareExchange(ref this.m__0001, value2, mWDataOrjOkHandler2);
					if ((object)mWDataOrjOkHandler != mWDataOrjOkHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event CancelCommandEventHandler CancelClick
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = this.m__0001;
			while (true)
			{
				CancelCommandEventHandler cancelCommandEventHandler2 = cancelCommandEventHandler;
				while (true)
				{
					CancelCommandEventHandler obj = (CancelCommandEventHandler)global::_0016._008D_0006(cancelCommandEventHandler2, value);
					CancelCommandEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					cancelCommandEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, cancelCommandEventHandler2);
					if ((object)cancelCommandEventHandler != cancelCommandEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = this.m__0001;
			while (true)
			{
				CancelCommandEventHandler cancelCommandEventHandler2 = cancelCommandEventHandler;
				while (true)
				{
					CancelCommandEventHandler obj = (CancelCommandEventHandler)global::_0016._008E_0006(cancelCommandEventHandler2, value);
					CancelCommandEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					cancelCommandEventHandler = Interlocked.CompareExchange(ref this.m__0001, value2, cancelCommandEventHandler2);
					if ((object)cancelCommandEventHandler != cancelCommandEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public F_MwTriMRough()
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
		if (!buMWCalcs.AdvancedTriMesh)
		{
			if (false)
			{
				goto IL_0790;
			}
			if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
			{
				if (false)
				{
					goto IL_022f;
				}
				_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel);
			}
			_0095._007E_0082_0010(Par, false);
			_0095._007E_0083_0010(_001C_0004._007E_0014_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), false);
			_0095._007E_0084_0010(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), false);
		}
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
		{
			_0095._007E_0093_000F(this._0007, true);
		}
		else if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
		{
			_0095._007E_0093_000F(this._0006, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0005, true);
		}
		goto IL_022f;
		IL_0790:
		_0095._007E_0096_000F(this._000E, global::_0003._007E_0004_0002(Par));
		_0088_0003._007E_001A_0014(this._000F, _0087_0003._0019_0014(global::_0007._007E_0019_0003(Par)));
		_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(global::_0007._007E_0018_0003(Par)));
		_0088_0003._007E_001A_0014(this._0011, _0087_0003._0019_0014(global::_0007._007E_0017_0003(Par)));
		_0095._007E_0096_000F(this._0008, global::_0003._007E_0007(Par));
		_0095._007E_0096_000F(this._000F, global::_0003._007E_0005_0002(Par));
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_022f:
		bool flag = _008F._007E_0012_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
		do
		{
			if (flag)
			{
				_0095._007E_0093_000F(this._0004, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0003, true);
			}
			if (_0091._007E_0015_0007(Par) == MachiningParamsMachiningAreaMode.MachByLanes)
			{
				_0095._007E_0093_000F(this._0011, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0010, true);
			}
			if (_0015_0004._007E_0006_0015(Par) == MachiningParamsDirection.DirClimb)
			{
				_0095._007E_0093_000F(this._000E, true);
			}
			else if (_0015_0004._007E_0006_0015(Par) == MachiningParamsDirection.DirConventional)
			{
				_0095._007E_0093_000F(this._0008, true);
			}
			else
			{
				_0095._007E_0093_000F(this._000E, true);
				_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirClimb);
			}
			if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeOneway)
			{
				_0095._007E_0093_000F(this._0001, true);
			}
			else if (6 == 0 || _0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeZigzag)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			else if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeSpiral)
			{
				_0095._007E_0093_000F(this._000F, true);
			}
			else
			{
				_0095._007E_0093_000F(this._0002, true);
				_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
			}
			_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_0017_0004(Par)));
			_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_007F_0003(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
			_0088_0003._007E_001A_0014(this._0006, _0004_0004._0097_0014(global::_000E._007E_009F_0005(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))))));
			_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_0097_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		}
		while (8 == 0);
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0087_0003(Par)));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0083_0003(Par)));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0018_0004(Par)));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0019_0004(Par)));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_001A_0004(Par)));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(Par)));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_001F_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0007_0002(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_007F_0002(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0095._007E_0096_000F(this._0006, global::_0003._007E_0080_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0095._007E_0096_000F(_0007, global::_0003._007E_0081_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))));
		_0088_0003._007E_001A_0014(this._0012, _0087_0003._0019_0014(global::_0007._007E_001B_0004(Par)));
		goto IL_0790;
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
		bool flag = this.m__0001 != null;
		bool num;
		if (true)
		{
			num = flag;
			if (-1 == 0 || !num)
			{
				return;
			}
		}
		Apply();
		Properties.Result = DialogResult.OK;
		bool num2 = Properties.FormCloseMode == FormCloseModeType.Dispose;
		if (7u != 0)
		{
			bool flag2 = num2;
			num2 = flag2;
		}
		if (num2)
		{
			global::_0011._001C_0006(this);
			if (false)
			{
				goto IL_0097;
			}
			if (4 == 0)
			{
				goto IL_009b;
			}
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
		{
			_0095._0094_000F(this, false);
			goto IL_0097;
		}
		goto IL_009b;
		IL_0097:
		if (8 == 0)
		{
		}
		goto IL_009b;
		IL_009b:
		num = this.m__0001(Par);
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		if (3 == 0)
		{
			goto IL_0067;
		}
		bool num;
		if (this.m__0001 != null)
		{
			Properties.Result = DialogResult.Cancel;
			num = Properties.FormCloseMode == FormCloseModeType.Dispose;
			goto IL_009c;
		}
		return;
		IL_0066:
		bool flag = num;
		goto IL_0067;
		IL_0067:
		num = flag;
		if (false)
		{
			goto IL_009c;
		}
		if (!num)
		{
			return;
		}
		goto IL_006d;
		IL_009c:
		while (true)
		{
			if (num)
			{
				if (7 == 0)
				{
					break;
				}
				global::_0011 obj = global::_0011._001C_0006;
				if (0 == 0)
				{
					obj(this);
				}
			}
			num = Properties.FormCloseMode == FormCloseModeType.Invisible;
			if (-1 == 0)
			{
				continue;
			}
			goto IL_0066;
		}
		goto IL_006d;
		IL_006d:
		_0095._0094_000F(this, false);
	}

	public void UpdateControlFromType()
	{
		_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0004));
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0002));
		_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0003));
		if (2u != 0)
		{
			_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0005));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0001));
			_0095._007E_0095_000F(_001B, global::_0003._007E_0083(this._000E));
			_0095._007E_0095_000F(this._0012, global::_0003._007E_0083(this._000E));
			if (1 == 0)
			{
				goto IL_0437;
			}
			if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
			{
				_0095._007E_0094_000F(this._0001, true);
				_0095._007E_0094_000F(this._0003, true);
				_0095._007E_0094_000F(_0007, true);
				_0095._007E_0094_000F(_0016, false);
				_0095._007E_0094_000F(this._0008, false);
				_0095._007E_0094_000F(this._0006, true);
				_0095._007E_0094_000F(this._0004, false);
				_0095._007E_0094_000F(this._0003, false);
				_0095._007E_0094_000F(this._0003, false);
				_0095._007E_0094_000F(this._0002, false);
				_0095._007E_0094_000F(this._0002, false);
				_0095._007E_0094_000F(this._0001, false);
				_0095._007E_0094_000F(this._000F, true);
			}
			if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) != TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
			{
				goto IL_033c;
			}
			_0095._007E_0094_000F(this._0001, false);
			_0095._007E_0094_000F(this._0003, false);
			_0095._007E_0094_000F(_0007, false);
			_0095._007E_0094_000F(_0016, true);
			_0095._007E_0094_000F(this._0008, true);
		}
		_0095._007E_0094_000F(this._0006, false);
		_0095._007E_0094_000F(this._0004, false);
		_0095._007E_0094_000F(this._0003, false);
		_0095._007E_0094_000F(this._0003, false);
		_0095._007E_0094_000F(this._0002, false);
		_0095._007E_0094_000F(this._0002, false);
		_0095._007E_0094_000F(this._0001, false);
		_0095._007E_0094_000F(this._000F, false);
		goto IL_033c;
		IL_0437:
		_0095._007E_0094_000F(this._0001, true);
		_0095._007E_0094_000F(this._000F, false);
		goto IL_045c;
		IL_033c:
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) != TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
		{
			goto IL_045c;
		}
		_0095._007E_0094_000F(this._0001, false);
		_0095._007E_0094_000F(this._0003, false);
		_0095._007E_0094_000F(_0007, false);
		_0095._007E_0094_000F(_0016, false);
		_0095._007E_0094_000F(this._0008, false);
		_0095._007E_0094_000F(this._0006, false);
		_0095._007E_0094_000F(this._0004, true);
		if (0 == 0)
		{
			_0095._007E_0094_000F(this._0003, true);
			_0095._007E_0094_000F(this._0003, true);
			_0095._007E_0094_000F(this._0002, true);
			_0095._007E_0094_000F(this._0002, true);
			goto IL_0437;
		}
		goto IL_049e;
		IL_049e:
		_0095._007E_0095_000F(_0013, false);
		return;
		IL_045c:
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(this._0005, false);
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0003, false);
			goto IL_049e;
		}
	}

	public void Apply()
	{
		_0094._007E_0091_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0008)));
		_0094._007E_0080_0007(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0007)));
		_0097._007E_0088_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0006)));
		_0094._007E_0008_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._000E)));
		_0094._007E_0088_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_0087_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_0089_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_008A_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_008B_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0095._007E_001F_0010(_0016_0004._007E_0007_0015(Par), global::_0003._007E_0083(this._0004));
		_0095._007E_0083_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0005));
		_0095._007E_0094_0010(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0002));
		_0095._007E_0084_0010(_001D_0004._007E_0016_0015(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0001));
		_0095._007E_0095_0010(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), global::_0003._007E_0083(this._0003));
		_0095._007E_0016_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(this._0006));
		_0095._007E_0015_000F(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), global::_0003._007E_0083(_0007));
		_0094._007E_008C_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0012)));
		_0095._007E_007F_0010(Par, global::_0003._007E_0083(this._000E));
		_0094._007E_001A_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._000F)));
		_0094._007E_0019_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0010)));
		_0094._007E_0018_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0011)));
		_0095._007E_0007_000F(Par, global::_0003._007E_0083(this._0008));
		_0095._007E_0080_0010(Par, global::_0003._007E_0083(this._000F));
		if (global::_0003._007E_001C(this._0007))
		{
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset);
		}
		else if (global::_0003._007E_001C(this._0006))
		{
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel);
		}
		else if (global::_0003._007E_001C(this._0005))
		{
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive);
		}
		if (global::_0003._007E_001C(this._0004))
		{
			_0098._007E_009A_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep);
		}
		else if (global::_0003._007E_001C(this._0003))
		{
			_0098._007E_009A_0011(_008E._007E_0011_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))), MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices);
		}
		if (global::_0003._007E_001C(this._0011))
		{
			_009D._007E_0002_0012(Par, MachiningParamsMachiningAreaMode.MachByLanes);
		}
		else if (global::_0003._007E_001C(this._0010))
		{
			_009D._007E_0002_0012(Par, MachiningParamsMachiningAreaMode.MachByRegions);
		}
		if (global::_0003._007E_001C(this._000E))
		{
			_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirClimb);
		}
		else if (global::_0003._007E_001C(this._0008))
		{
			_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirConventional);
		}
		if (global::_0003._007E_001C(this._0001))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeOneway);
		}
		else if (global::_0003._007E_001C(this._0002))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
		}
		else if (global::_0003._007E_001C(this._000F))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeSpiral);
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		if (0 == 0)
		{
			bool num = global::_0003._007E_001C(this._0007);
			bool flag;
			if (8u != 0)
			{
				flag = num;
			}
			bool num2 = flag;
			if (7u != 0)
			{
				if (num2)
				{
					goto IL_002a;
				}
				bool flag2 = global::_0003._007E_001C(this._0006);
				num2 = flag2;
			}
			if (num2)
			{
				if (6u != 0)
				{
					_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel);
				}
			}
			else
			{
				_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive);
			}
		}
		goto IL_00c7;
		IL_002a:
		_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset);
		goto IL_0054;
		IL_0054:
		if (false)
		{
			goto IL_002a;
		}
		goto IL_00c7;
		IL_00c7:
		while (false)
		{
		}
		if (0 == 0)
		{
			UpdateControlFromType();
			return;
		}
		goto IL_0054;
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control;
		bool num;
		bool flag;
		if (0 == 0)
		{
			control = new Control();
			control = (Control)P_0;
			num = !Properties.Inited;
			if (false)
			{
				goto IL_003c;
			}
			flag = num;
		}
		num = flag;
		goto IL_003c;
		IL_003c:
		if (num)
		{
			return;
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			while (true)
			{
				if (false)
				{
					return;
				}
				Properties.Inited = false;
				_0094._007E_0088_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
				_0094._007E_0089_0008(Par, _009A_0004._0094_0015(global::_0007._007E_0087_0003(Par) / 1.25, 3));
				if (8u != 0)
				{
					_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0018_0004(Par)));
					if (5u != 0)
					{
						break;
					}
				}
			}
		}
		Properties.Inited = true;
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Expected O, but got Unknown
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected O, but got Unknown
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_0731: Expected O, but got Unknown
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Expected O, but got Unknown
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0013)))
		{
			F_MWTriMDynamicalHolderColl f_MWTriMDynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
			f_MWTriMDynamicalHolderColl.Par = new MachiningParams(Par);
			f_MWTriMDynamicalHolderColl.Init();
			_009D_0003._007E_0091_0014(f_MWTriMDynamicalHolderColl);
			if (f_MWTriMDynamicalHolderColl.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MWTriMDynamicalHolderColl.Par);
				global::_0011._007E_001C_0006(f_MWTriMDynamicalHolderColl);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0012)))
		{
			F_MwTriMHeights f_MwTriMHeights = new F_MwTriMHeights();
			f_MwTriMHeights.Par = new MachiningParams(Par);
			f_MwTriMHeights.Init();
			_009D_0003._007E_0091_0014(f_MwTriMHeights);
			if (f_MwTriMHeights.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMHeights.Par);
				global::_0011._007E_001C_0006(f_MwTriMHeights);
			}
		}
		F_MwTriMOffset f_MwTriMOffset = default(F_MwTriMOffset);
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0011)))
		{
			f_MwTriMOffset = new F_MwTriMOffset();
			f_MwTriMOffset.Par = new MachiningParams(Par);
			f_MwTriMOffset.Init();
			_009D_0003._007E_0091_0014(f_MwTriMOffset);
			if (f_MwTriMOffset.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMOffset.Par);
				goto IL_01bb;
			}
		}
		goto IL_01ca;
		IL_0346:
		F_MwGaugeCheck f_MwGaugeCheck;
		if (f_MwGaugeCheck.Properties.Result == DialogResult.OK)
		{
			Par = new MachiningParams(f_MwGaugeCheck.Par);
			global::_0011._007E_001C_0006(f_MwGaugeCheck);
		}
		if (7 == 0)
		{
			goto IL_01bb;
		}
		goto IL_0383;
		IL_0383:
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
		if (0 == 0)
		{
			if (flag)
			{
				F_MwTriMDepthAdvanced f_MwTriMDepthAdvanced = new F_MwTriMDepthAdvanced();
				f_MwTriMDepthAdvanced.Par = new MachiningParams(Par);
				f_MwTriMDepthAdvanced.Init();
				_009D_0003._007E_0091_0014(f_MwTriMDepthAdvanced);
				if (f_MwTriMDepthAdvanced.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMDepthAdvanced.Par);
					global::_0011._007E_001C_0006(f_MwTriMDepthAdvanced);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				F_MwTriMSurfaceQuality f_MwTriMSurfaceQuality = new F_MwTriMSurfaceQuality();
				f_MwTriMSurfaceQuality.Par = new MachiningParams(Par);
				f_MwTriMSurfaceQuality.Init();
				_009D_0003._007E_0091_0014(f_MwTriMSurfaceQuality);
				if (f_MwTriMSurfaceQuality.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMSurfaceQuality.Par);
					global::_0011._007E_001C_0006(f_MwTriMSurfaceQuality);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
			{
				F_MwTriMSilhouette f_MwTriMSilhouette = new F_MwTriMSilhouette();
				f_MwTriMSilhouette.Par = new MachiningParams(Par);
				f_MwTriMSilhouette.Init();
				_009D_0003._007E_0091_0014(f_MwTriMSilhouette);
				if (f_MwTriMSilhouette.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMSilhouette.Par);
					global::_0011._007E_001C_0006(f_MwTriMSilhouette);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				F_MwTriMRestRough f_MwTriMRestRough = new F_MwTriMRestRough();
				f_MwTriMRestRough.Par = new MachiningParams(Par);
				f_MwTriMRestRough.Init();
				_009D_0003._007E_0091_0014(f_MwTriMRestRough);
				if (f_MwTriMRestRough.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMRestRough.Par);
					global::_0011._007E_001C_0006(f_MwTriMRestRough);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
			{
				F_MwTriM2dContainment f_MwTriM2dContainment = new F_MwTriM2dContainment();
				f_MwTriM2dContainment.Par = new MachiningParams(Par);
				f_MwTriM2dContainment.Init();
				_009D_0003._007E_0091_0014(f_MwTriM2dContainment);
				if (f_MwTriM2dContainment.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriM2dContainment.Par);
					global::_0011._007E_001C_0006(f_MwTriM2dContainment);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				F_MwTriMFixtureCurves f_MwTriMFixtureCurves = new F_MwTriMFixtureCurves();
				f_MwTriMFixtureCurves.Par = new MachiningParams(Par);
				f_MwTriMFixtureCurves.Init();
				_009D_0003._007E_0091_0014(f_MwTriMFixtureCurves);
				if (f_MwTriMFixtureCurves.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMFixtureCurves.Par);
					global::_0011._007E_001C_0006(f_MwTriMFixtureCurves);
				}
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
			{
				F_MwTriMUtility f_MwTriMUtility = new F_MwTriMUtility();
				f_MwTriMUtility.Par = new MachiningParams(Par);
				f_MwTriMUtility.Init();
				_009D_0003._007E_0091_0014(f_MwTriMUtility);
				if (f_MwTriMUtility.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMUtility.Par);
					global::_0011._007E_001C_0006(f_MwTriMUtility);
				}
			}
			return;
		}
		goto IL_0346;
		IL_01ca:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0008)))
		{
			F_MwTriMRoughLink f_MwTriMRoughLink = new F_MwTriMRoughLink();
			f_MwTriMRoughLink.Par = new MachiningParams(Par);
			f_MwTriMRoughLink.Init();
			_009D_0003._007E_0091_0014(f_MwTriMRoughLink);
			if (f_MwTriMRoughLink.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMRoughLink.Par);
				global::_0011._007E_001C_0006(f_MwTriMRoughLink);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
		{
			F_MwTriMRoughing f_MwTriMRoughing = new F_MwTriMRoughing();
			f_MwTriMRoughing.Par = new MachiningParams(Par);
			f_MwTriMRoughing.Init();
			_009D_0003._007E_0091_0014(f_MwTriMRoughing);
			if (f_MwTriMRoughing.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMRoughing.Par);
				global::_0011._007E_001C_0006(f_MwTriMRoughing);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000E)))
		{
			f_MwGaugeCheck = new F_MwGaugeCheck();
			f_MwGaugeCheck.Par = new MachiningParams(Par);
			f_MwGaugeCheck.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeCheck);
			goto IL_0346;
		}
		goto IL_0383;
		IL_01bb:
		global::_0011._007E_001C_0006(f_MwTriMOffset);
		goto IL_01ca;
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
