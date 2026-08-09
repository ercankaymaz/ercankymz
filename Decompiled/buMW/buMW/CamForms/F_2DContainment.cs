using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_2DContainment : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Panel _0001;

	internal Label _0003;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal Panel _0002;

	internal Label _0004;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal CheckBox _0001;

	public F_2DContainment()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		int num = PropertiesForm.Height;
		if (0 == 0)
		{
			bool flag = num > 10;
			while (true)
			{
				if (flag)
				{
					_0097._008C_0011(this, PropertiesForm.Height);
				}
				if (PropertiesForm.Width > 10)
				{
					_0097._008D_0011(this, PropertiesForm.Width);
				}
				_0095._0092_000F(this, PropertiesForm.TopMost);
				_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
				bool num2;
				if (!Configration.isTriangularMeshAdvanced)
				{
					bool isRough = Configration.isRough;
					if (false)
					{
						goto IL_032e;
					}
					if (false)
					{
						goto IL_0433;
					}
					num2 = isRough;
					if (-1 == 0)
					{
						goto IL_0478;
					}
					if (num2)
					{
						_009E_0003._007E_0092_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint);
					}
					_0095._007E_0095_000F(_0005, false);
				}
				if (Configration.Mode == CamMode.TriangularMesh)
				{
					break;
				}
				bool flag2 = Configration.Mode == CamMode.WireFrame;
				goto IL_032e;
				IL_0433:
				bool flag3 = _009F_0003._007E_0093_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside;
				if (3 == 0)
				{
					continue;
				}
				num2 = flag3;
				goto IL_0478;
				IL_0478:
				if (num2)
				{
					_0095._007E_0093_000F(this._0001, true);
				}
				goto IL_048e;
				IL_032e:
				if (flag2)
				{
					_009E_0003._007E_0092_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint);
					_0095._007E_0095_000F(_0005, false);
					if (_009F_0003._007E_0093_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone)
					{
						_0095._007E_0093_000F(this._0002, true);
					}
					else
					{
						if (_009F_0003._007E_0093_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) != SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside)
						{
							goto IL_0433;
						}
						_0095._007E_0093_000F(this._0003, true);
					}
					goto IL_048e;
				}
				goto IL_04f4;
				IL_048e:
				_0095._007E_0093_000F(this._0004, true);
				_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0006_0004(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
				goto IL_04f4;
			}
			if (_009F_0003._007E_0093_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			else if (_009F_0003._007E_0093_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside)
			{
				_0095._007E_0093_000F(this._0003, true);
			}
			else if (_009F_0003._007E_0093_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside)
			{
				_0095._007E_0093_000F(this._0001, true);
			}
			bool flag4 = _0001_0004._007E_0094_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
			num = (flag4 ? 1 : 0);
		}
		if (num != 0)
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		else
		{
			_0095._007E_0093_000F(_0005, true);
		}
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0006_0004(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		goto IL_04f4;
		IL_04f4:
		ControlUpdate();
		global::_0005._0002._0001(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void _0001(object P_0, FormClosingEventArgs P_1)
	{
		while (true)
		{
			bool num = PropertiesForm.Result == DialogResult.OK;
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
				PropertiesForm.Result = DialogResult.Cancel;
				bool flag2;
				do
				{
					flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
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
			num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
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
		Control control = new Control();
		control = (Control)P_0;
		if (0 == 0)
		{
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok));
			if (5 == 0)
			{
				goto IL_0098;
			}
			if (!flag)
			{
				goto IL_00a7;
			}
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
		}
		goto IL_0085;
		IL_0093:
		bool num;
		if (num != 0)
		{
			goto IL_0098;
		}
		goto IL_00a7;
		IL_0098:
		_0095._0094_000F(this, false);
		goto IL_00a7;
		IL_00a7:
		while (true)
		{
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel));
			if (3 == 0)
			{
				break;
			}
			if (!flag2)
			{
				return;
			}
			do
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					if (4 == 0)
					{
						return;
					}
					global::_0011._001C_0006(this);
				}
			}
			while (5 == 0);
			if (1 == 0)
			{
				continue;
			}
			goto IL_010d;
		}
		goto IL_0085;
		IL_010d:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		if (0 == 0)
		{
			if (num)
			{
				_0095._0094_000F(this, false);
			}
			return;
		}
		goto IL_0093;
		IL_0085:
		num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		goto IL_0093;
	}

	public void ControlUpdate()
	{
		if ((_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough) | (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil))
		{
			goto IL_0070;
		}
		goto IL_0084;
		IL_0070:
		_0095._007E_0095_000F(_0005, false);
		goto IL_0084;
		IL_0084:
		bool flag = (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ) | (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts);
		if (2u != 0)
		{
			if (flag)
			{
				_0095._007E_0095_000F(_0005, true);
			}
			_0095._007E_0095_000F(this._0001, !global::_0003._007E_001C(_0005));
		}
		if (global::_0003._007E_001C(this._0003) | global::_0003._007E_001C(this._0001))
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_008C(this._0001));
			_0095._007E_0095_000F(this._0001, global::_0003._007E_008C(this._0001));
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_0095._007E_0095_000F(this._0001, false);
			goto IL_01b5;
		}
		goto IL_01cc;
		IL_0213:
		bool flag2;
		if (flag2)
		{
			_0095._007E_0095_000F(this._0001, true);
			if (false)
			{
				goto IL_0070;
			}
			_0095._007E_0095_000F(this._0001, true);
		}
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(this._0002, false);
			if (1 == 0)
			{
				goto IL_01b5;
			}
			if (0 == 0)
			{
				return;
			}
			goto IL_01cc;
		}
		return;
		IL_01cc:
		_0095._007E_0095_000F(this._0001, false);
		_0095._007E_0095_000F(this._0001, false);
		flag2 = global::_0003._007E_001C(this._0003) | global::_0003._007E_001C(this._0001);
		goto IL_0213;
		IL_01b5:
		if (7u != 0)
		{
			_0095._007E_0095_000F(this._0001, false);
			goto IL_01cc;
		}
		goto IL_0213;
	}

	public void Apply()
	{
		bool num = Configration.Mode == CamMode.TriangularMesh;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		bool num2 = flag;
		bool flag4 = default(bool);
		while (true)
		{
			if (7 == 0)
			{
				goto IL_02f3;
			}
			bool num3;
			if (num2)
			{
				_0094._007E_0080_0008(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
				bool flag2 = global::_0003._007E_001C(this._0002);
				num3 = flag2;
				if (3u != 0)
				{
					if (num3)
					{
						_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone);
					}
					else
					{
						bool flag3 = global::_0003._007E_001C(this._0003);
						if (4 == 0)
						{
							goto IL_019c;
						}
						if (flag3)
						{
							_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside);
						}
						else if (global::_0003._007E_001C(this._0001))
						{
							_0002_0004._007E_0095_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside);
						}
					}
					flag4 = global::_0003._007E_001C(this._0004);
					goto IL_019c;
				}
				goto IL_0350;
			}
			if (Configration.Mode == CamMode.WireFrame)
			{
				_0094._007E_0080_0008(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
				num2 = global::_0003._007E_001C(this._0002);
				goto IL_029c;
			}
			break;
			IL_0350:
			if (num3)
			{
				_0002_0004._007E_0095_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside);
			}
			goto IL_0392;
			IL_0392:
			_009E_0003._007E_0092_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint);
			break;
			IL_02f3:
			bool flag5 = num2;
			num2 = flag5;
			if (6 == 0)
			{
				continue;
			}
			if (6 == 0)
			{
				goto IL_029c;
			}
			if (num2)
			{
				_0002_0004._007E_0095_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside);
				goto IL_0392;
			}
			num3 = global::_0003._007E_001C(this._0001);
			goto IL_0350;
			IL_019c:
			if (flag4)
			{
				_009E_0003._007E_0092_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint);
			}
			else
			{
				_009E_0003._007E_0092_0014(_001A_0002._007E_0082_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsContainmentTrimmingCriteria.CtcToolContactPoint);
			}
			break;
			IL_029c:
			if (num2)
			{
				_0002_0004._007E_0095_0014(_001A_0002._007E_0083_0012(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone);
				goto IL_0392;
			}
			num2 = global::_0003._007E_001C(this._0003);
			goto IL_02f3;
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			do
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_0018());
			}
			while (1 == 0);
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0005)))
		{
			if (8 == 0)
			{
				goto IL_019f;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)) && 8u != 0)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_0018());
			goto IL_019f;
		}
		goto IL_01a7;
		IL_019f:
		if (false)
		{
		}
		goto IL_01a7;
		IL_01a7:
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		bool flag = default(bool);
		if (0 == 0 && uint.MaxValue != 0)
		{
			bool touchPad = PropertiesForm.TouchPad;
			bool num = global::_0003._007E_0083(this._0001);
			do
			{
				num = !num;
			}
			while (false);
			flag = touchPad && num;
		}
		if (!flag)
		{
			return;
		}
		NumericUpDown numericUpDown = new NumericUpDown();
		numericUpDown = (NumericUpDown)P_0;
		if (7u != 0)
		{
			bool flag2 = global::_0003._007E_008C(numericUpDown);
			if (false || flag2)
			{
				_0010_0006._008A_001C(this, numericUpDown);
			}
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool flag = default(bool);
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			if (4 == 0)
			{
				goto IL_029c;
			}
			if (global::_0003._007E_001C(this._0003))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_0018());
			}
			else if (global::_0003._007E_001C(this._0001))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0018());
				if (2 == 0)
				{
					goto IL_025e;
				}
			}
			if (global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView);
				_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView);
			}
			if (-1 == 0)
			{
				goto IL_013a;
			}
		}
		else
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				goto IL_013a;
			}
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
				goto IL_025e;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_0018());
			if (global::_0003._007E_0083(this._0001))
			{
				goto IL_0200;
			}
		}
		goto IL_0406;
		IL_029c:
		F_GifView f_GifView2 = default(F_GifView);
		global::_0011._007E_0084_0006(f_GifView2);
		_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
		_009D_0003._007E_0091_0014(f_GifView2);
		goto IL_0406;
		IL_03f4:
		F_GifView f_GifView3;
		do
		{
			_009D_0003._007E_0091_0014(f_GifView3);
		}
		while (8 == 0);
		goto IL_0406;
		IL_0335:
		F_GifView f_GifView4 = new F_GifView();
		global::_0011._007E_0084_0006(f_GifView4);
		_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
		_009D_0003._007E_0091_0014(f_GifView4);
		goto IL_0365;
		IL_0200:
		F_GifView f_GifView5 = new F_GifView();
		global::_0011._007E_0084_0006(f_GifView5);
		_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
		_009D_0003._007E_0091_0014(f_GifView5);
		goto IL_0406;
		IL_025e:
		if (flag)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_0018());
			if (global::_0003._007E_0083(this._0001))
			{
				f_GifView2 = new F_GifView();
				goto IL_029c;
			}
		}
		else
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				if (false)
				{
					goto IL_0200;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_0018());
				bool flag2 = global::_0003._007E_0083(this._0001);
				if (0 == 0)
				{
					if (flag2)
					{
						goto IL_0335;
					}
					goto IL_0365;
				}
				goto IL_03f4;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0005)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_0018());
				if (uint.MaxValue != 0 && global::_0003._007E_0083(this._0001))
				{
					f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					goto IL_03f4;
				}
			}
		}
		goto IL_0406;
		IL_013a:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_0018());
		if (global::_0003._007E_0083(this._0001))
		{
			F_GifView f_GifView6 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView6);
			_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView6);
		}
		goto IL_0406;
		IL_0406:
		_0095._007E_0096_000F(this._0001, false);
		return;
		IL_0365:
		if (false)
		{
			goto IL_0335;
		}
		goto IL_0406;
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
