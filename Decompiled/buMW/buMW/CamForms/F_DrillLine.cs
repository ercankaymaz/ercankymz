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
using buEyeBaseVer5.Forms;

namespace buMW.CamForms;

public class F_DrillLine : Form
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

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal Label _0001;

	internal NumericUpDown _0002;

	internal Label _0002;

	internal Panel _0001;

	internal Label _0003;

	internal Label _0004;

	internal NumericUpDown _0003;

	internal NumericUpDown _0004;

	internal Panel _0002;

	internal NumericUpDown _0005;

	internal Label _0005;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal NumericUpDown _0006;

	internal Label _0006;

	internal Panel _0003;

	internal Label _0007;

	internal Label _0008;

	internal Panel _0004;

	internal Label _000E;

	internal Label _000F;

	internal Label _0010;

	internal Panel _0005;

	internal Button _0001;

	internal Label _0011;

	internal NumericUpDown _0007;

	internal Label _0012;

	internal Label _0013;

	internal Label _0014;

	internal NumericUpDown _0008;

	internal NumericUpDown _000E;

	internal PictureBox _0001;

	internal ImageList _0002;

	internal CheckBox _0002;

	internal Button _0002;

	internal Panel _0006;

	internal CheckBox _0003;

	internal CheckBox _0004;

	internal Label _0015;

	internal Label _0016;

	internal Label _0017;

	internal NumericUpDown _000F;

	internal NumericUpDown _0010;

	internal Panel _0007;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal CheckBox _0005;

	internal PictureBox _0002;

	internal Label _0018;

	internal NumericUpDown _0011;

	internal NumericUpDown _0012;

	internal Label _0019;

	internal Label _001A;

	internal NumericUpDown _0013;

	internal Label _001B;

	internal NumericUpDown _0014;

	public Panel pnl_rotation;

	internal Label _001C;

	internal Label _001D;

	internal Label _001E;

	internal NumericUpDown _0015;

	internal NumericUpDown _0016;

	internal CheckBox _0006;

	internal Button _0003;

	public F_DrillLine()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		bool num = PropertiesForm.Height > 10;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		if (flag)
		{
			_0097._008C_0011(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			_0097._008D_0011(this, PropertiesForm.Width);
		}
		_0095._007E_0094_000F(this._0002, PropertiesForm.ShowHelp);
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0083_0003(_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0018_0003(_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0019_0003(_0084._007E_009D_0006(mwCamParameter))));
		_0088_0003._007E_001A_0014(_0008, _0087_0003._0019_0014(global::_0007._007E_001D_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(_000E, _0087_0003._0019_0014(global::_0007._007E_001C_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_001B_0003(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(buCamParameter.Drill.EndHeight));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(buCamParameter.Drill.StartHeight));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(buCamParameter.Speeds.SpindleSpeed));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0007(_0084._007E_009D_0006(mwCamParameter)));
		_0095._007E_0096_000F(this._0004, global::_0003._007E_0008(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_000E(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0088_0003._007E_001A_0014(_0010, _0087_0003._0019_0014(global::_0007._007E_0080_0003(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(_000F, _0087_0003._0019_0014(global::_0007._007E_0081_0003(_0090._007E_0014_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(_0012, _0087_0003._0019_0014(buCamParameter.Strategy.ContantTangent));
		_0088_0003._007E_001A_0014(_0013, _0087_0003._0019_0014(buCamParameter.Strategy.MaxTangentValue));
		_0088_0003._007E_001A_0014(_0014, _0087_0003._0019_0014(buCamParameter.Strategy.MinTangentValue));
		_0088_0003._007E_001A_0014(_0011, _0087_0003._0019_0014(buCamParameter.Strategy.TangentOffset));
		_0088_0003._007E_001A_0014(_0016, _0087_0003._0019_0014(buCamParameter.Drill.StartAngle));
		_0088_0003._007E_001A_0014(_0015, _0087_0003._0019_0014(buCamParameter.Drill.EndAngle));
		_0095._007E_0096_000F(this._0006, buCamParameter.Drill.IncremantalRotation);
		if (buCamParameter.Strategy.UseContantTangent)
		{
			_0095._007E_0093_000F(this._0004, true);
			_0095._007E_0093_000F(this._0003, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0004, false);
			_0095._007E_0093_000F(this._0003, true);
		}
		_0095._007E_0096_000F(this._0005, buCamParameter.Strategy.UseTangentLimit);
		if (buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
		{
			_0095._007E_0093_000F(this._0002, true);
			_0095._007E_0093_000F(this._0001, false);
		}
		else
		{
			_0095._007E_0093_000F(this._0002, false);
			_0095._007E_0093_000F(this._0001, true);
		}
		_0095._007E_0094_000F(pnl_rotation, false);
		_0095._007E_0094_000F(_0007, false);
		if (Configration.CamDrillMode == CamDrillMode.Rotation)
		{
			_0095._007E_0094_000F(pnl_rotation, true);
			_0095._007E_0094_000F(_0007, true);
		}
		else if (Configration.CamDrillMode == CamDrillMode.Tangent)
		{
			_0095._007E_0094_000F(_0007, true);
		}
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
	}

	public void ControlUpdate()
	{
		do
		{
			_0095._007E_0095_000F(this._0015, global::_0003._007E_0083(this._0004));
			_0095._007E_0095_000F(_0010, global::_0003._007E_0083(this._0004));
			_0095._007E_0095_000F(_0017, global::_0003._007E_0083(this._0004));
			while (3 == 0)
			{
			}
			_0095._007E_0095_000F(_000F, global::_0003._007E_0083(this._0004));
			_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0004));
		}
		while (5 == 0);
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			F_ContourLink f_ContourLink = new F_ContourLink();
			f_ContourLink.mwCamParameter = new GeoLib(_0083._007E_009C_0006(mwCamParameter), 0);
			_0086._007E_009E_0006(f_ContourLink.mwCamParameter, new MachiningParams(_0084._007E_009D_0006(mwCamParameter)));
			f_ContourLink.buCamParameter = new camParameters5(buCamParameter);
			f_ContourLink.Init();
			_009D_0003._007E_0091_0014(f_ContourLink);
			if (f_ContourLink.Properties.Result == DialogResult.OK)
			{
				_0086._007E_009E_0006(mwCamParameter, new MachiningParams(_0084._007E_009D_0006(f_ContourLink.mwCamParameter)));
				buCamParameter = new camParameters5(f_ContourLink.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_HeightAdvanced f_HeightAdvanced = new F_HeightAdvanced();
			f_HeightAdvanced.mwCamParameter = new GeoLib(_0083._007E_009C_0006(mwCamParameter), 0);
			_0086._007E_009E_0006(f_HeightAdvanced.mwCamParameter, new MachiningParams(_0084._007E_009D_0006(mwCamParameter)));
			f_HeightAdvanced.buCamParameter = new camParameters5(buCamParameter);
			f_HeightAdvanced.Init();
			_009D_0003._007E_0091_0014(f_HeightAdvanced);
			if (f_HeightAdvanced.PropertiesForm.Result == DialogResult.OK)
			{
				_0086._007E_009E_0006(mwCamParameter, new MachiningParams(_0084._007E_009D_0006(f_HeightAdvanced.mwCamParameter)));
				buCamParameter = new camParameters5(f_HeightAdvanced.buCamParameter);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			F_SortingSettings f_SortingSettings = new F_SortingSettings();
			f_SortingSettings.SortSetting = new SortSettings(buCamParameter.Sorting);
			global::_0011._007E_0087_0006(f_SortingSettings);
			_009D_0003._007E_0091_0014(f_SortingSettings);
			if (f_SortingSettings.PropertiesForm.Result == DialogResult.OK)
			{
				buCamParameter.Sorting = new SortSettings(f_SortingSettings.SortSetting);
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
			bool num = global::_0003._007E_0083(this._0002);
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
		ControlUpdate();
	}

	internal void _0005(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_0018());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_0018());
		}
		else
		{
			while (true)
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0018());
					if (uint.MaxValue != 0)
					{
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView);
							if (5 == 0)
							{
								continue;
							}
							_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
							if (4u != 0)
							{
								_009D_0003._007E_0091_0014(f_GifView);
								break;
							}
							goto IL_0359;
						}
						break;
					}
					goto IL_0409;
				}
				bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
				while (true)
				{
					IL_0183:
					if (flag)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_0018());
						if (global::_0003._007E_0083(this._0002))
						{
							F_GifView f_GifView2 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView2);
							_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView2);
						}
						if (8u != 0)
						{
							break;
						}
					}
					else
					{
						bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
						bool num = flag2;
						if (uint.MaxValue != 0)
						{
							if (num)
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_0018());
								bool flag3 = global::_0003._007E_0083(this._0002);
								F_GifView f_GifView3;
								if (0 == 0)
								{
									if (!flag3)
									{
										break;
									}
									f_GifView3 = new F_GifView();
									global::_0011._007E_0084_0006(f_GifView3);
									_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
								}
								_009D_0003._007E_0091_0014(f_GifView3);
								break;
							}
							if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
							{
								_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_0018());
								break;
							}
							num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000E));
						}
						if (!num)
						{
							while (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0008)))
							{
								if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
								{
									_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_0018());
									goto end_IL_0183;
								}
								if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
								{
									if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
									{
										if (false)
										{
											goto IL_0183;
										}
										_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
										if (true)
										{
											goto end_IL_0183;
										}
										continue;
									}
									if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
									{
										_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
									}
									goto end_IL_0183;
								}
								goto IL_03f2;
							}
							goto IL_0359;
						}
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_0018());
					break;
					continue;
					end_IL_0183:
					break;
				}
				break;
				IL_0359:
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_0018());
				break;
				IL_03f2:
				if (!global::_0003._007E_001C(this._0001))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0018());
					break;
				}
				goto IL_0409;
				IL_0409:
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0018());
				break;
			}
		}
		_0095._007E_0096_000F(this._0002, false);
	}

	internal void _0006(object P_0, EventArgs P_1)
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
