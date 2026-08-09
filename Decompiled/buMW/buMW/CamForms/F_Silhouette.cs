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

public class F_Silhouette : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	public bool SilhouetteTopEnable = false;

	public bool SilhouetteBottomEnable = false;

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal CheckBox _0001;

	public F_Silhouette()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			_0097._008C_0011(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._0092_000F(this, PropertiesForm.TopMost);
		_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
		if (!Configration.isRough)
		{
			if ((_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop) | (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom))
			{
				_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd);
			}
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_0005, false);
		}
		if (!Configration.isTriangularMeshAdvanced)
		{
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd);
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_0005, false);
		}
		if (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop)
		{
			_0095._007E_0093_000F(_0005, true);
		}
		else if (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom)
		{
			_0095._007E_0093_000F(this._0004, true);
		}
		else if (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else if (_0006_0002._007E_0013_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact)
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0003, true);
		}
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0099_0004(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		ControlUpdate();
		global::_0005._0002._0001(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
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
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(this._0004, false);
			goto IL_002c;
		}
		_0095._007E_0095_000F(this._0004, true);
		_0095._007E_0095_000F(this._0003, true);
		_0095._007E_0095_000F(this._0001, true);
		if (0 == 0)
		{
			_0095._007E_0095_000F(_0005, true);
			goto IL_00c7;
		}
		goto IL_0253;
		IL_00c7:
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
		{
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_0005, false);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
		{
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(_0005, true);
		}
		if (_008A_0003._007E_001E_0014(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil)
		{
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(_0005, false);
		}
		goto IL_01d8;
		IL_01d8:
		_0095._007E_0095_000F(this._0004, SilhouetteBottomEnable);
		if (6 == 0)
		{
			goto IL_002c;
		}
		_0095._007E_0095_000F(_0005, SilhouetteTopEnable);
		if (!buMWCalcs.AdvancedTriMesh)
		{
			_0095._007E_0095_000F(this._0004, false);
			_0095._007E_0095_000F(this._0003, false);
			if (0 == 0)
			{
				_0095._007E_0095_000F(this._0001, false);
				goto IL_0253;
			}
			return;
		}
		return;
		IL_0253:
		_0095._007E_0095_000F(_0005, false);
		return;
		IL_002c:
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0001, false);
			_0095._007E_0095_000F(_0005, false);
			goto IL_00c7;
		}
		goto IL_01d8;
	}

	public void Apply()
	{
		_0094._007E_0097_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		if (global::_0003._007E_001C(this._0004))
		{
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom);
		}
		else if (global::_0003._007E_001C(this._0003))
		{
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartSilhouette);
		}
		else if (global::_0003._007E_001C(this._0002))
		{
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd);
		}
		else if (global::_0003._007E_001C(this._0001))
		{
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact);
		}
		else if (global::_0003._007E_001C(_0005))
		{
			_0081_0002._007E_008C_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop);
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0001(object P_0, KeyEventArgs P_1)
	{
		Control control;
		do
		{
			control = new Control();
		}
		while (4 == 0);
		control = (Control)P_0;
		int num = (((_009C_0005._007E_0007_0017(P_1) == Keys.Return) | (_009C_0005._007E_0007_0017(P_1) == Keys.Tab)) ? 1 : 0);
		while (true)
		{
			bool flag = (byte)num != 0;
			bool num2;
			if (7u != 0)
			{
				num2 = flag;
				goto IL_004d;
			}
			goto IL_0050;
			IL_004d:
			if (!num2)
			{
				break;
			}
			goto IL_0050;
			IL_0050:
			num = 0;
			if (num != 0)
			{
				continue;
			}
			int num3 = num;
			num2 = _009D_0005._0008_0017(global::_0005._007E_0013_0003(_0003_0003._007E_001E_0013(control)), ref num3);
			if (8u != 0)
			{
				_009E_0005._000E_0017(_0013_0005._001A_0016(this), num3, global::_0003._007E_009B_0002(P_1));
				break;
			}
			goto IL_004d;
		}
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_0017());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0017());
			if (global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView);
				_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView);
			}
			if (3 == 0)
			{
				goto IL_012b;
			}
		}
		else
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				goto IL_012b;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_0017());
				if (global::_0003._007E_0083(this._0001))
				{
					F_GifView f_GifView2 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView2);
					_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView2);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0005)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_0017());
				if (global::_0003._007E_0083(this._0001))
				{
					F_GifView f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView3);
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009D_0017());
				if (global::_0003._007E_0083(this._0001))
				{
					F_GifView f_GifView4 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView4);
					_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView4);
				}
			}
		}
		goto IL_034b;
		IL_012b:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_0017());
		if (global::_0003._007E_0083(this._0001))
		{
			F_GifView f_GifView5 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView5);
			_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView5);
		}
		goto IL_034b;
		IL_034b:
		_0095._007E_0096_000F(this._0001, false);
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
