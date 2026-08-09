using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Forms.WinControlForms.ClassForm;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_Roughing : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions;

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

	public ComboBox cmb_ramptype;

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

	internal CheckBox _0005;

	public Button btn_transformrotate;

	public CheckBox chk_transformrotate;

	public Button btn_mirror;

	public CheckBox chk_mirror;

	internal CheckBox _0006;

	internal Button _0004;

	internal Button _0005;

	internal ListBox _0001;

	[NonSerialized]
	internal static GetString _0083;

	public F_Roughing()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			_0097 obj = _0097._008C_0011;
			int num = PropertiesForm.Height;
			if (7u != 0)
			{
				obj(this, num);
			}
		}
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._0092_000F(this, PropertiesForm.TopMost);
		_0086_0003._0018_0014(this, PropertiesForm.FormPosition);
		global::_0011._007E_001D_0006(_0006_0004._007E_009A_0014(this._0001));
		for (int i = 0; i <= _0087._007E_009F_0006(mwCamParameter).Count() - 1; i++)
		{
			_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), _0081._009A_0006(new string[5]
			{
				_0087._007E_009F_0006(mwCamParameter).ElementAt(i).X.ToString(),
				_0083(107355949),
				_0087._007E_009F_0006(mwCamParameter).ElementAt(i).Y.ToString(),
				_0083(107355949),
				_0087._007E_009F_0006(mwCamParameter).ElementAt(i).Z.ToString()
			}));
		}
		_0095._007E_0096_000F(this._0002, global::_0003._007E_0090_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0004_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(this._0005, global::_0003._007E_0091_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0092_0002(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_008B_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_008A_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0088_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0089_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0089_0003(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0093(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter))));
		_0095._007E_0096_000F(chk_transformrotate, global::_0003._007E_0093_0002(_0087_0004._007E_007F_0015(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(chk_mirror, global::_0003._007E_0094_0002(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter)))));
		if (_000E_0002._007E_0016_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle)
		{
			_0095._007E_0093_000F(this._0002, true);
		}
		else
		{
			_0095._007E_0093_000F(this._0001, true);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_ramptype));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_ramptype), buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_ramptype), buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_ramptype), buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_ramptype), buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_ramptype), buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[4]);
		if (_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic)
		{
			_0097._007E_008E_0011(cmb_ramptype, 0);
		}
		else if (_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtLine)
		{
			_0097._007E_008E_0011(cmb_ramptype, 1);
		}
		else if (_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical)
		{
			_0097._007E_008E_0011(cmb_ramptype, 2);
		}
		else if (_0008_0002._007E_0015_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag)
		{
			_0097._007E_008E_0011(cmb_ramptype, 3);
		}
		else
		{
			_0097._007E_008E_0011(cmb_ramptype, 4);
		}
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
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected O, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Expected O, but got Unknown
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Expected O, but got Unknown
		F_StockDef f_StockDef = default(F_StockDef);
		while (true)
		{
			Control control = new Control();
			control = (Control)P_0;
			bool num;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
			{
				Apply();
				if (false)
				{
					goto IL_0107;
				}
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001C_0006(this);
				}
				num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
				if (8 == 0)
				{
					goto IL_00f7;
				}
				if (num)
				{
					_0095._0094_000F(this, false);
				}
			}
			bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel));
			bool num2 = flag;
			if (true)
			{
				if (!num2)
				{
					goto IL_0131;
				}
				PropertiesForm.Result = DialogResult.Cancel;
				num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
			}
			bool flag2 = num2;
			num = flag2;
			goto IL_00f7;
			IL_0131:
			bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
			bool num3 = flag3;
			if (0 == 0)
			{
				if (num3)
				{
					goto IL_0165;
				}
				goto IL_0242;
			}
			goto IL_03ad;
			IL_00f7:
			if (num)
			{
				global::_0011._001C_0006(this);
			}
			goto IL_0107;
			IL_0107:
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				if (6 == 0)
				{
					goto IL_039e;
				}
				_0095._0094_000F(this, false);
			}
			goto IL_0131;
			IL_0242:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0005)) && ((global::_000E._007E_000E_0006(this._0001) >= 0) & (global::_000E._007E_000E_0006(this._0001) <= global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1)))
			{
				_0097._007E_0090_0011(_0006_0004._007E_009A_0014(this._0001), global::_000E._007E_000E_0006(this._0001));
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				f_StockDef = new F_StockDef();
				f_StockDef.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
				_0086._007E_009E_0006(f_StockDef.mwCamParameter, new MachiningParams(_0084._007E_009D_0006(mwCamParameter)));
				f_StockDef.buCamParameter = new camParameters5(buCamParameter);
				_0095._007E_0094_000F(f_StockDef.pnl_area, false);
				f_StockDef.Init();
				_009D_0003._007E_0091_0014(f_StockDef);
				goto IL_039e;
			}
			goto IL_0402;
			IL_0402:
			bool flag4 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
			bool num4 = flag4;
			while (true)
			{
				if (num4)
				{
					F_RoughingAdvanced f_RoughingAdvanced = new F_RoughingAdvanced();
					f_RoughingAdvanced.mwCamParameter = new GeoLib(global::_0083._007E_009C_0006(mwCamParameter), 0);
					_0086._007E_009E_0006(f_RoughingAdvanced.mwCamParameter, new MachiningParams(_0084._007E_009D_0006(mwCamParameter)));
					f_RoughingAdvanced.buCamParameter = new camParameters5(buCamParameter);
					f_RoughingAdvanced.Init();
					_009D_0003._007E_0091_0014(f_RoughingAdvanced);
					num4 = f_RoughingAdvanced.PropertiesForm.Result == DialogResult.OK;
					if (false)
					{
						continue;
					}
					if (num4)
					{
						_0086._007E_009E_0006(mwCamParameter, new MachiningParams(_0084._007E_009D_0006(f_RoughingAdvanced.mwCamParameter)));
						buCamParameter = new camParameters5(f_RoughingAdvanced.buCamParameter);
						global::_0011._007E_001C_0006(f_RoughingAdvanced);
						if (6 == 0)
						{
							break;
						}
					}
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_transformrotate)))
				{
				}
				if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_mirror)))
				{
				}
				return;
			}
			continue;
			IL_0165:
			F_Pnt3D f_Pnt3D = new F_Pnt3D();
			_0086_0003._007E_0018_0014(f_Pnt3D, FormStartPosition.CenterParent);
			f_Pnt3D.Value = new Pnt3D();
			global::_0011._007E_0088_0006(f_Pnt3D);
			_009D_0003._007E_0091_0014(f_Pnt3D);
			if (f_Pnt3D.Result == DialogResult.OK)
			{
				_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), _0081._009A_0006(new string[5]
				{
					f_Pnt3D.Value.X.ToString(),
					_0083(107355944),
					f_Pnt3D.Value.Y.ToString(),
					_0083(107355944),
					f_Pnt3D.Value.Z.ToString()
				}));
			}
			goto IL_0242;
			IL_03ad:
			bool flag5 = num3;
			if (2 == 0)
			{
				goto IL_0165;
			}
			if (flag5)
			{
				_0086._007E_009E_0006(mwCamParameter, new MachiningParams(_0084._007E_009D_0006(f_StockDef.mwCamParameter)));
				buCamParameter = new camParameters5(f_StockDef.buCamParameter);
				global::_0011._007E_001C_0006(f_StockDef);
			}
			goto IL_0402;
			IL_039e:
			num3 = f_StockDef.PropertiesForm.Result == DialogResult.OK;
			goto IL_03ad;
		}
	}

	public void ControlUpdate()
	{
		if (global::_000E._007E_000E_0006(cmb_ramptype) == 0)
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
		if (global::_000E._007E_000E_0006(cmb_ramptype) == 1)
		{
			_0095 obj5 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown3 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj5(numericUpDown3, false);
			_0095 obj6 = _0095._007E_0095_000F;
			Label label = this._0003;
			global::_0003._007E_0083(this._0003);
			obj6(label, false);
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0003));
		}
		if (global::_000E._007E_000E_0006(cmb_ramptype) == 2)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095 obj7 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown4 = this._0006;
			global::_0003._007E_0083(this._0003);
			obj7(numericUpDown4, false);
			_0095 obj8 = _0095._007E_0095_000F;
			RadioButton radioButton3 = this._0002;
			global::_0003._007E_0083(this._0003);
			obj8(radioButton3, false);
			_0095 obj9 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown5 = this._0005;
			global::_0003._007E_0083(this._0003);
			obj9(numericUpDown5, false);
			_0095 obj10 = _0095._007E_0095_000F;
			RadioButton radioButton4 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj10(radioButton4, false);
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0003));
		}
		if (global::_000E._007E_000E_0006(cmb_ramptype) == 3)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0003));
			_0095 obj11 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown6 = this._0006;
			global::_0003._007E_0083(this._0003);
			obj11(numericUpDown6, false);
			_0095 obj12 = _0095._007E_0095_000F;
			RadioButton radioButton5 = this._0002;
			global::_0003._007E_0083(this._0003);
			obj12(radioButton5, false);
			_0095 obj13 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown7 = this._0005;
			global::_0003._007E_0083(this._0003);
			obj13(numericUpDown7, false);
			_0095 obj14 = _0095._007E_0095_000F;
			RadioButton radioButton6 = this._0001;
			global::_0003._007E_0083(this._0003);
			obj14(radioButton6, false);
			_0095 obj15 = _0095._007E_0095_000F;
			CheckBox checkBox = this._0004;
			global::_0003._007E_0083(this._0003);
			obj15(checkBox, false);
			_0095 obj16 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown8 = this._0003;
			global::_0003._007E_0083(this._0003);
			obj16(numericUpDown8, false);
			_0095 obj17 = _0095._007E_0095_000F;
			NumericUpDown numericUpDown9 = this._0004;
			global::_0003._007E_0083(this._0003);
			obj17(numericUpDown9, false);
			_0095 obj18 = _0095._007E_0095_000F;
			Label label2 = this._0006;
			global::_0003._007E_0083(this._0003);
			obj18(label2, false);
		}
		if (global::_000E._007E_000E_0006(cmb_ramptype) == 4)
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
		_0095._007E_0095_000F(btn_mirror, global::_0003._007E_0083(chk_mirror));
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
		_0095._007E_0095_000F(btn_transformrotate, global::_0003._007E_0083(chk_transformrotate));
		_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0004) & global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0003));
		_0095._007E_0095_000F(cmb_ramptype, global::_0003._007E_0083(this._0003));
	}

	public void Apply()
	{
		_0095._007E_0017_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0002));
		_0094._007E_0018_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		_0095._007E_0018_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0005));
		_0095._007E_0019_0011(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0003));
		_0094._007E_0096_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		_0094._007E_0095_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		_0094._007E_0093_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0094._007E_0094_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		_0094._007E_0094_0007(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		_0095._007E_0012_0010(_0015_0002._007E_001D_0012(_0084._007E_009D_0006(mwCamParameter)), global::_0003._007E_0083(this._0001));
		_0095._007E_001A_0011(_0087_0004._007E_007F_0015(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(chk_transformrotate));
		_0095._007E_001B_0011(_0017_0004._007E_0008_0015(_008C_0002._007E_0096_0012(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(chk_mirror));
		List<Point3d<double>> list = _0087._007E_009F_0006(mwCamParameter).ToList();
		list.Clear();
		for (int i = 0; i <= global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1; i++)
		{
			string[] array = _0005_0006._007E_0083_001C(global::_0005._007E_0013_0003(_0010_0004._007E_0001_0015(_0006_0004._007E_009A_0014(this._0001), i)), new char[1] { ';' });
			if (array != null && array.Length == 3)
			{
				double num = 0.0;
				double num2 = 0.0;
				double z = 0.0;
				_0006_0006._0084_001C(array[0], ref num);
				_0006_0006._0084_001C(array[1], ref num2);
				_0006_0006._0084_001C(array[2], ref z);
				list.Add(new Point3d<double>(num, num2, z));
			}
		}
		_0088._007E_0002_0007(mwCamParameter, list);
		if (global::_000E._007E_000E_0006(cmb_ramptype) == 0)
		{
			_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic);
		}
		else if (global::_000E._007E_000E_0006(cmb_ramptype) == 1)
		{
			_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsRampType.TmbRtLine);
		}
		else if (global::_000E._007E_000E_0006(cmb_ramptype) == 2)
		{
			_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical);
		}
		else if (global::_000E._007E_000E_0006(cmb_ramptype) == 3)
		{
			_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag);
		}
		else if (global::_000E._007E_000E_0006(cmb_ramptype) == 4)
		{
			_001E_0002._007E_0088_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsRampType.TmbRtProfile);
		}
		if (global::_0003._007E_001C(this._0002))
		{
			_001F_0002._007E_0089_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle);
		}
		else
		{
			_001F_0002._007E_0089_0012(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsRampMode.TmbRmPitch);
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (!PropertiesForm.Inited)
		{
			return;
		}
		ControlUpdate();
		bool flag = default(bool);
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			if (global::_0003._007E_0083(this._0002))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_001C());
			}
			else
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0007_001C());
			}
			if (5 == 0)
			{
				goto IL_0141;
			}
		}
		else
		{
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
				goto IL_0141;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0008_001C());
		}
		goto IL_0246;
		IL_0246:
		PropertiesForm.Inited = false;
		Apply();
		PropertiesForm.Inited = true;
		return;
		IL_0141:
		if (flag)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_001C());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_001C());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(chk_transformrotate)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_001C());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(chk_mirror)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_001C());
		}
		goto IL_0246;
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = !PropertiesForm.Inited;
		bool flag;
		if (3u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			return;
		}
		ControlUpdate();
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_ramptype)))
		{
			if (global::_000E._007E_000E_0006(cmb_ramptype) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_001C());
			}
			else if (global::_000E._007E_000E_0006(cmb_ramptype) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_001C());
			}
			else if (global::_000E._007E_000E_0006(cmb_ramptype) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_001C());
			}
			else if (global::_000E._007E_000E_0006(cmb_ramptype) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_001C());
			}
			else if (global::_000E._007E_000E_0006(cmb_ramptype) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0016_001C());
			}
		}
		PropertiesForm.Inited = false;
		Apply();
		PropertiesForm.Inited = true;
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

	static F_Roughing()
	{
		Strings.CreateGetStringDelegate(typeof(F_Roughing));
		Captions = new List<string>();
	}
}
