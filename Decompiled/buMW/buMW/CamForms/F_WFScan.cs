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

public class F_WFScan : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal ImageList _0001;

	public Button btn_cancel;

	public Button btn_ok;

	internal TabControl _0001;

	internal TabPage _0001;

	internal TabPage _0002;

	internal NumericUpDown _0001;

	internal Label _0001;

	internal NumericUpDown _0002;

	internal Label _0002;

	internal Panel _0001;

	internal Label _0003;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal NumericUpDown _0004;

	internal NumericUpDown _0005;

	internal Label _0005;

	internal Panel _0002;

	internal Panel _0003;

	internal Button _0001;

	internal NumericUpDown _0006;

	internal NumericUpDown _0007;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0006;

	internal NumericUpDown _0008;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal RadioButton _0005;

	internal RadioButton _0006;

	internal NumericUpDown _000E;

	internal Label _0007;

	internal Panel _0004;

	internal Panel _0005;

	internal Label _0008;

	internal Label _000E;

	internal Panel _0006;

	internal Label _000F;

	internal Label _0010;

	internal Label _0011;

	internal Panel _0007;

	internal Label _0012;

	internal Label _0013;

	internal Label _0014;

	internal NumericUpDown _000F;

	internal NumericUpDown _0010;

	internal PictureBox _0001;

	internal ImageList _0002;

	internal CheckBox _0001;

	internal NumericUpDown _0011;

	internal Label _0015;

	internal NumericUpDown _0012;

	internal Label _0016;

	internal Panel _0008;

	internal Label _0017;

	internal RadioButton _0007;

	internal RadioButton _0008;

	internal Panel _000E;

	internal Label _0018;

	internal RadioButton _000E;

	internal RadioButton _000F;

	internal RadioButton _0010;

	internal NumericUpDown _0013;

	internal Label _0019;

	internal NumericUpDown _0014;

	public F_WFScan()
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
		_0095._007E_0094_000F(this._0001, PropertiesForm.ShowHelp);
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_007F_0003(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(this._0006, _0004_0004._0097_0014(global::_000E._007E_009F_0005(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0017_0003(_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0018_0003(_0084._007E_009D_0006(mwCamParameter))));
		do
		{
			_0088_0003._007E_001A_0014(this._000F, _0087_0003._0019_0014(global::_0007._007E_001D_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0010, _0087_0003._0019_0014(global::_0007._007E_001C_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(buCamParameter.Steps.EndValue));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(buCamParameter.Steps.StartValue));
			_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(buCamParameter.Operations.Height));
			_0088_0003._007E_001A_0014(this._000E, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(buCamParameter.Hatch.XDirectionLength));
			_0088_0003._007E_001A_0014(_0011, _0087_0003._0019_0014(buCamParameter.Hatch.YDirectionWidth));
			_0088_0003._007E_001A_0014(_0012, _0087_0003._0019_0014(buCamParameter.Hatch.CutStep));
			_0088_0003._007E_001A_0014(_0014, _0087_0003._0019_0014(buCamParameter.Hatch.CornerPoint.X));
			_0088_0003._007E_001A_0014(_0013, _0087_0003._0019_0014(buCamParameter.Hatch.CornerPoint.Y));
			if (_008F._007E_0012_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
			{
				_0095._007E_0093_000F(this._0002, true);
				_0095._007E_0093_000F(this._0001, false);
			}
			else
			{
				_0095._007E_0093_000F(this._0002, false);
				_0095._007E_0093_000F(this._0001, true);
			}
			if (!buCamParameter.Steps.Enable)
			{
				_0095._007E_0093_000F(this._0003, true);
				_0095._007E_0093_000F(this._0004, false);
			}
			else
			{
				_0095._007E_0093_000F(this._0003, false);
				_0095._007E_0093_000F(this._0004, true);
			}
		}
		while (1 == 0);
		if (buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
		{
			_0095._007E_0093_000F(this._0006, true);
			_0095._007E_0093_000F(this._0005, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0006, false);
			_0095._007E_0093_000F(this._0005, true);
		}
		if (buCamParameter.Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
		{
			_0095._007E_0093_000F(_000F, true);
			_0095._007E_0093_000F(_000E, false);
		}
		else
		{
			_0095._007E_0093_000F(_000F, false);
			_0095._007E_0093_000F(_000E, true);
		}
		if (buCamParameter.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
		{
			_0095._007E_0093_000F(_0008, true);
			_0095._007E_0093_000F(_0007, false);
			_0095._007E_0093_000F(_0010, false);
		}
		else if (buCamParameter.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
		{
			_0095._007E_0093_000F(_0008, false);
			_0095._007E_0093_000F(_0007, true);
			_0095._007E_0093_000F(_0010, false);
		}
		else
		{
			_0095._007E_0093_000F(_0008, false);
			_0095._007E_0093_000F(_0007, false);
			_0095._007E_0093_000F(_0010, true);
		}
		Configration.Mode = CamMode.WireFrame;
		Configration.CamWireframeType = CamWireFrameType.Contour;
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
	}

	public void ControlUpdate()
	{
		if (8 == 0)
		{
			goto IL_008a;
		}
		bool num = global::_0003._007E_001C(this._0003);
		goto IL_0109;
		IL_00a7:
		_0095._007E_0095_000F(this._0007, true);
		_0095._007E_0095_000F(this._0006, false);
		return;
		IL_0109:
		if (num)
		{
			if (8 == 0)
			{
				goto IL_00a7;
			}
			_0095._007E_0095_000F(this._0004, true);
			_0095._007E_0095_000F(this._0003, false);
		}
		else
		{
			do
			{
				_0095._007E_0095_000F(this._0004, false);
				_0095._007E_0095_000F(this._0003, true);
			}
			while (2 == 0);
		}
		goto IL_008a;
		IL_008a:
		if (2 == 0)
		{
			return;
		}
		num = global::_0003._007E_001C(this._0002);
		if (7 == 0)
		{
			goto IL_0109;
		}
		if (!num)
		{
			_0095._007E_0095_000F(this._0007, false);
			do
			{
				_0095._007E_0095_000F(this._0006, true);
			}
			while (8 == 0);
			return;
		}
		goto IL_00a7;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
		{
			if (!PropertiesForm.Inited)
			{
				return;
			}
			if (PropertiesForm.ReadOnly)
			{
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001C_0006(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					_0095._0094_000F(this, false);
				}
				return;
			}
			global::_0005._0002._0001(this);
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel)))
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_DepthStepAdvanced f_DepthStepAdvanced = new F_DepthStepAdvanced();
			f_DepthStepAdvanced.mwCamParameter = new GeoLib(_0083._007E_009C_0006(mwCamParameter), 0);
			_0086._007E_009E_0006(f_DepthStepAdvanced.mwCamParameter, new MachiningParams(_0084._007E_009D_0006(mwCamParameter)));
			f_DepthStepAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_DepthStepAdvanced.Init();
			_009D_0003._007E_0091_0014(f_DepthStepAdvanced);
			if (f_DepthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				_0086._007E_009E_0006(mwCamParameter, new MachiningParams(_0084._007E_009D_0006(f_DepthStepAdvanced.mwCamParameter)));
				buCamParameter = new camParameters5(f_DepthStepAdvanced.buCamParameter);
			}
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		if (!PropertiesForm.Inited)
		{
		}
	}

	internal void _0001(object P_0, KeyEventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if ((_009C_0005._007E_0007_0017(P_1) == Keys.Return) | (_009C_0005._007E_0007_0017(P_1) == Keys.Tab))
		{
			int num = 0;
			_009D_0005._0008_0017(global::_0005._007E_0013_0003(_0003_0003._007E_001E_0013(control)), ref num);
			_009E_0005._000E_0017(_0013_0005._007E_001A_0016(_0012_0006._007E_008C_001C(this._0001)), num, global::_0003._007E_009B_0002(P_1));
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
		bool num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005));
		if (false)
		{
			goto IL_01dc;
		}
		if (num)
		{
			if (0 == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_0018());
				if (global::_0003._007E_0083(this._0001))
				{
					F_GifView f_GifView = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView);
					_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView);
				}
			}
		}
		else
		{
			if (false)
			{
				goto IL_0626;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0004_001A());
				if (false)
				{
				}
			}
			else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_0018());
				if (6 == 0)
				{
					goto IL_05b4;
				}
			}
			else
			{
				if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
				{
					bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
					num = flag;
					goto IL_01dc;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_0018());
			}
		}
		goto IL_066e;
		IL_01dc:
		if (num)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_0018());
			if (6u != 0 && global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView2 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView2);
				_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView2);
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_0018());
			if (global::_0003._007E_0083(this._0001))
			{
				F_GifView f_GifView3 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView3);
				_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView3);
				if (5 == 0)
				{
					goto IL_05b4;
				}
			}
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0010)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0018());
		}
		else
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000F)))
			{
				goto IL_052d;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E)))
			{
				if (!global::_0003._007E_001C(this._0005))
				{
					goto IL_05b4;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
				if (false)
				{
				}
			}
			else
			{
				if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
				{
					goto IL_0626;
				}
				if (false)
				{
					goto IL_052d;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
			}
		}
		goto IL_066e;
		IL_0626:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
		}
		goto IL_066e;
		IL_052d:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0018());
		goto IL_066e;
		IL_066e:
		_0095._007E_0096_000F(this._0001, false);
		return;
		IL_05b4:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
		goto IL_066e;
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		ControlUpdate();
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
