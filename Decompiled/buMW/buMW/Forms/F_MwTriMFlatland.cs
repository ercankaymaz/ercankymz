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

public class F_MwTriMFlatland : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	[CompilerGenerated]
	private MWDataOrjOkHandler m__0001;

	[CompilerGenerated]
	private CancelCommandEventHandler m__0001;

	internal IContainer _0001 = null;

	internal Label _0001;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal Panel _0001;

	internal RadioButton _0001;

	internal Label _0003;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal Label _0004;

	internal Label _0005;

	internal Button _0001;

	internal Panel _0002;

	internal NumericUpDown _0002;

	internal Label _0006;

	internal NumericUpDown _0003;

	internal Panel _0003;

	internal Label _0007;

	internal NumericUpDown _0004;

	internal Label _0008;

	internal Label _000E;

	internal NumericUpDown _0005;

	internal NumericUpDown _0006;

	internal Label _000F;

	internal Button _0002;

	internal Label _0010;

	internal NumericUpDown _0007;

	internal Panel _0004;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal Label _0011;

	internal NumericUpDown _0008;

	internal Label _0012;

	internal NumericUpDown _000E;

	internal Label _0013;

	internal NumericUpDown _000F;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal PictureBox _0001;

	internal Label _0014;

	internal Button _0003;

	internal Button _0004;

	internal Button _0005;

	internal Panel _0005;

	internal CheckBox _0004;

	internal Button _0006;

	internal Label _0015;

	internal Label _0016;

	internal Button _0007;

	internal Button _0008;

	internal Panel _0006;

	internal Button _000E;

	internal TabPage _0001;

	internal Panel _0007;

	internal Panel _0008;

	internal Label _0017;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal Panel _000E;

	internal Label _0018;

	internal RadioButton _0006;

	internal RadioButton _0007;

	internal Label _0019;

	internal TabControl _0001;

	internal NumericUpDown _0010;

	internal CheckBox _0005;

	internal Label _001A;

	internal NumericUpDown _0011;

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

	public F_MwTriMFlatland()
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
		if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
		{
			_0095._007E_0093_000F(this._0003, true);
		}
		else if (_0007_0002._007E_0014_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par))) == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		if (_0015_0004._007E_0006_0015(Par) == MachiningParamsDirection.DirClimb)
		{
			_0095._007E_0093_000F(this._0005, true);
		}
		else if (_0015_0004._007E_0006_0015(Par) == MachiningParamsDirection.DirConventional)
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0005, true);
			_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirClimb);
		}
		if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeOneway)
		{
			_0095._007E_0093_000F(_0006, true);
		}
		else if (_0092._007E_0016_0007(Par) == MachiningParamsMachType.MachtypeZigzag)
		{
			_0095._007E_0093_000F(_0007, true);
		}
		else
		{
			_0095._007E_0093_000F(_0007, true);
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
		}
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0004(Par)));
		_0088_0003._007E_001A_0014(_0010, _0087_0003._0019_0014(global::_0007._007E_0012_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0088_0003._007E_001A_0014(_0011, _0087_0003._0019_0014(global::_0007._007E_0013_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0087_0003(Par)));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0083_0003(Par)));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0018_0004(Par)));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0019_0004(Par)));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_001A_0004(Par)));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0003_0002(_0016_0004._007E_0007_0015(Par)));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_001B_0004(Par)));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0004_0002(Par));
		do
		{
			_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_0019_0003(Par)));
		}
		while (6 == 0);
		_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(global::_0007._007E_0018_0003(Par)));
		_0088_0003._007E_001A_0014(_000F, _0087_0003._0019_0014(global::_0007._007E_0017_0003(Par)));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0007(Par));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_0005_0002(Par));
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
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
		_0095._007E_0095_000F(_0010, global::_0003._007E_0083(this._0005));
		_0095._007E_0095_000F(this._0010, global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0001));
		if (global::_0003._007E_001C(this._0003))
		{
			_0095._007E_0094_000F(this._0002, false);
			_0095._007E_0094_000F(this._0001, false);
			_0095._007E_0094_000F(this._0008, false);
			_0095._007E_0094_000F(this._0005, false);
			_0095._007E_0094_000F(this._0007, false);
			_0095._007E_0094_000F(this._0004, false);
			_0095._007E_0094_000F(this._0001, false);
			_0095._007E_0094_000F(this._0003, false);
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0094_000F(this._0002, true);
			_0095._007E_0094_000F(this._0001, true);
			_0095._007E_0094_000F(this._0008, false);
			_0095._007E_0094_000F(this._0005, false);
			_0095._007E_0094_000F(this._0007, false);
			_0095._007E_0094_000F(this._0004, false);
			_0095._007E_0094_000F(this._0001, false);
			_0095._007E_0094_000F(this._0003, false);
		}
		if (global::_0003._007E_001C(this._0001))
		{
			_0095._007E_0094_000F(this._0002, false);
			_0095._007E_0094_000F(this._0001, false);
			_0095._007E_0094_000F(this._0008, true);
			_0095._007E_0094_000F(this._0005, true);
			_0095._007E_0094_000F(this._0007, true);
			_0095._007E_0094_000F(this._0004, true);
			_0095._007E_0094_000F(this._0001, true);
			_0095._007E_0094_000F(this._0003, true);
		}
	}

	public void Apply()
	{
		_0094._007E_0091_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_008B_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0011)));
		_0094._007E_008C_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), _000F_0004._009F_0014(global::_0008._007E_0099_0005(_0010)));
		_0094._007E_0088_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		_0094._007E_0087_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0094._007E_0089_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_008A_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_008B_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0095._007E_001F_0010(_0016_0004._007E_0007_0015(Par), global::_0003._007E_0083(this._0004));
		_0094._007E_008C_0008(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0007)));
		_0095._007E_007F_0010(Par, global::_0003._007E_0083(this._0001));
		_0094._007E_001A_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0008)));
		_0094._007E_0019_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._000E)));
		_0094._007E_0018_0007(Par, _008B_0003._001F_0014(global::_0008._007E_0099_0005(_000F)));
		if (uint.MaxValue != 0)
		{
		}
		_0095._007E_0007_000F(Par, global::_0003._007E_0083(this._0003));
		_0095._007E_0080_0010(Par, global::_0003._007E_0083(this._0002));
		if (global::_0003._007E_001C(this._0003))
		{
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset);
		}
		else if (global::_0003._007E_001C(this._0002))
		{
			if (7 == 0)
			{
				goto IL_03a9;
			}
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel);
		}
		else if (global::_0003._007E_001C(this._0001))
		{
			_001B_0002._007E_0084_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(Par)), TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive);
		}
		if (global::_0003._007E_001C(this._0005))
		{
			goto IL_03a9;
		}
		if (global::_0003._007E_001C(this._0004))
		{
			_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirConventional);
		}
		goto IL_03e9;
		IL_03e9:
		if (global::_0003._007E_001C(_0006))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeOneway);
		}
		else if (global::_0003._007E_001C(_0007))
		{
			_009C._007E_0001_0012(Par, MachiningParamsMachType.MachtypeZigzag);
		}
		return;
		IL_03a9:
		_0017_0002._007E_001F_0012(Par, MachiningParamsDirection.DirClimb);
		goto IL_03e9;
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		if (0 == 0)
		{
			bool num = global::_0003._007E_001C(this._0003);
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
				bool flag2 = global::_0003._007E_001C(this._0002);
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Expected O, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			F_MWTriMDynamicalHolderColl f_MWTriMDynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
			f_MWTriMDynamicalHolderColl.Par = new MachiningParams(Par);
			f_MWTriMDynamicalHolderColl.Init();
			_009D_0003._007E_0091_0014(f_MWTriMDynamicalHolderColl);
			if (f_MWTriMDynamicalHolderColl.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MWTriMDynamicalHolderColl.Par);
				global::_0011._007E_001C_0006(f_MWTriMDynamicalHolderColl);
				if (false)
				{
					goto IL_01d0;
				}
			}
		}
		F_MwTriMHeights f_MwTriMHeights = default(F_MwTriMHeights);
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
		{
			f_MwTriMHeights = new F_MwTriMHeights();
			f_MwTriMHeights.Par = new MachiningParams(Par);
			f_MwTriMHeights.Init();
			if (0 == 0)
			{
				_009D_0003._007E_0091_0014(f_MwTriMHeights);
				if (f_MwTriMHeights.Properties.Result == DialogResult.OK)
				{
					goto IL_0121;
				}
			}
		}
		goto IL_0148;
		IL_01d0:
		F_MwTriMOffset f_MwTriMOffset;
		global::_0011._007E_001C_0006(f_MwTriMOffset);
		if (0 == 0)
		{
			goto IL_01e5;
		}
		goto IL_0334;
		IL_01e5:
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
		bool num = flag;
		F_MwTriMRoughLink f_MwTriMRoughLink;
		if (0 == 0)
		{
			if (num)
			{
				f_MwTriMRoughLink = new F_MwTriMRoughLink();
				f_MwTriMRoughLink.Par = new MachiningParams(Par);
				f_MwTriMRoughLink.Init();
				_009D_0003._007E_0091_0014(f_MwTriMRoughLink);
				if (f_MwTriMRoughLink.Properties.Result == DialogResult.OK)
				{
					Par = new MachiningParams(f_MwTriMRoughLink.Par);
					goto IL_026d;
				}
			}
			goto IL_027c;
		}
		goto IL_0539;
		IL_027c:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
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
		bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
		goto IL_0334;
		IL_0480:
		F_MwTriM2dContainment f_MwTriM2dContainment;
		f_MwTriM2dContainment.Init();
		_009D_0003._007E_0091_0014(f_MwTriM2dContainment);
		if (f_MwTriM2dContainment.Properties.Result == DialogResult.OK)
		{
			Par = new MachiningParams(f_MwTriM2dContainment.Par);
			global::_0011._007E_001C_0006(f_MwTriM2dContainment);
		}
		goto IL_04cc;
		IL_0539:
		F_MwTriMUtility f_MwTriMUtility;
		if (num)
		{
			Par = new MachiningParams(f_MwTriMUtility.Par);
			global::_0011._007E_001C_0006(f_MwTriMUtility);
		}
		return;
		IL_0121:
		Par = new MachiningParams(f_MwTriMHeights.Par);
		if (true)
		{
			global::_0011._007E_001C_0006(f_MwTriMHeights);
			goto IL_0148;
		}
		goto IL_026d;
		IL_04cc:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
		{
			f_MwTriMUtility = new F_MwTriMUtility();
			f_MwTriMUtility.Par = new MachiningParams(Par);
			f_MwTriMUtility.Init();
			_009D_0003._007E_0091_0014(f_MwTriMUtility);
			bool flag3 = f_MwTriMUtility.Properties.Result == DialogResult.OK;
			num = flag3;
			goto IL_0539;
		}
		return;
		IL_0148:
		bool flag4 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007));
		goto IL_016f;
		IL_016f:
		if (flag4)
		{
			f_MwTriMOffset = new F_MwTriMOffset();
			f_MwTriMOffset.Par = new MachiningParams(Par);
			f_MwTriMOffset.Init();
			_009D_0003._007E_0091_0014(f_MwTriMOffset);
			if (f_MwTriMOffset.Properties.Result == DialogResult.OK)
			{
				if (3u != 0)
				{
					Par = new MachiningParams(f_MwTriMOffset.Par);
					goto IL_01d0;
				}
				goto IL_0480;
			}
		}
		goto IL_01e5;
		IL_0334:
		if (flag2)
		{
			F_MwGaugeCheck f_MwGaugeCheck = new F_MwGaugeCheck();
			f_MwGaugeCheck.Par = new MachiningParams(Par);
			f_MwGaugeCheck.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeCheck);
			if (f_MwGaugeCheck.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeCheck.Par);
				global::_0011._007E_001C_0006(f_MwGaugeCheck);
				if (-1 == 0)
				{
					goto IL_016f;
				}
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_MwTriMSurfaceQuality f_MwTriMSurfaceQuality = new F_MwTriMSurfaceQuality();
			f_MwTriMSurfaceQuality.Par = new MachiningParams(Par);
			if (7 == 0)
			{
				goto IL_0121;
			}
			f_MwTriMSurfaceQuality.Init();
			_009D_0003._007E_0091_0014(f_MwTriMSurfaceQuality);
			if (f_MwTriMSurfaceQuality.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwTriMSurfaceQuality.Par);
				global::_0011._007E_001C_0006(f_MwTriMSurfaceQuality);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			f_MwTriM2dContainment = new F_MwTriM2dContainment();
			f_MwTriM2dContainment.Par = new MachiningParams(Par);
			goto IL_0480;
		}
		goto IL_04cc;
		IL_026d:
		global::_0011._007E_001C_0006(f_MwTriMRoughLink);
		goto IL_027c;
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
