using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_ProfilePass : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public ToolBase5 Tool = null;

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal ImageList _0001;

	internal Label _0001;

	internal PictureBox _0001;

	public Button btn_ok;

	internal ImageList _0002;

	public Button btn_cancel;

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal NumericUpDown _0002;

	internal Label _0003;

	internal NumericUpDown _0003;

	internal Label _0004;

	internal NumericUpDown _0004;

	internal Label _0005;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal NumericUpDown _0005;

	internal Label _0006;

	internal Label _0007;

	public ComboBox cmb_profilepassofsettype;

	public F_ProfilePass()
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
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_0095._007E_0094_000F(this._0002, true);
			_0095._007E_0094_000F(this._0001, true);
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_000F_0005(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0082_0005(_000E_0006._007E_0088_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			if (8 == 0)
			{
				goto IL_0605;
			}
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0083_0005(_000E_0006._007E_0088_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0084_0005(_000E_0006._007E_0088_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0086_0005(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			if (_008F_0005._007E_0099_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			else if (_008F_0005._007E_0099_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice)
			{
				_0095._007E_0093_000F(this._0001, true);
			}
			global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_profilepassofsettype));
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[0]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[1]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[2]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[3]);
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[4]);
			if (_000F_0006._007E_0089_001C(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtInComputer)
			{
				_0097._007E_008E_0011(cmb_profilepassofsettype, 0);
			}
			else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtInControl)
			{
				_0097._007E_008E_0011(cmb_profilepassofsettype, 1);
			}
			else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtWear)
			{
				_0097._007E_008E_0011(cmb_profilepassofsettype, 2);
			}
			else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtInverseWear)
			{
				_0097._007E_008E_0011(cmb_profilepassofsettype, 3);
			}
			else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtOff)
			{
				_0097._007E_008E_0011(cmb_profilepassofsettype, 4);
			}
		}
		else if (Configration.Mode == CamMode.WireFrame)
		{
			_0095._007E_0094_000F(this._0002, false);
			_0095._007E_0094_000F(this._0001, false);
			_0095._007E_0094_000F(this._0003, false);
			goto IL_0605;
		}
		goto IL_098f;
		IL_0605:
		_0095._007E_0094_000F(this._0004, false);
		_0095._007E_0094_000F(this._0004, false);
		_0095._007E_0094_000F(this._0005, false);
		_0095._007E_0094_000F(this._0002, false);
		_0095._007E_0094_000F(this._0003, false);
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0087_0005(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0086_0005(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_profilepassofsettype));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_profilepassofsettype), buMWCaptions.CutterRadiusCompParamsCompensationType[4]);
		if (_000F_0006._007E_0089_001C(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtInComputer)
		{
			_0097._007E_008E_0011(cmb_profilepassofsettype, 0);
		}
		else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtInControl)
		{
			_0097._007E_008E_0011(cmb_profilepassofsettype, 1);
		}
		else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtWear)
		{
			_0097._007E_008E_0011(cmb_profilepassofsettype, 2);
		}
		else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtInverseWear)
		{
			_0097._007E_008E_0011(cmb_profilepassofsettype, 3);
		}
		else if (_000F_0006._007E_0089_001C(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == CutterRadiusCompParamsCompensationType.CtOff)
		{
			_0097._007E_008E_0011(cmb_profilepassofsettype, 4);
		}
		goto IL_098f;
		IL_098f:
		ControlUpdate();
		global::_0005._0002._0001(this);
		_008F_0003._007E_0082_0014(this._0001, null);
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
		_0095._007E_0095_000F(this._0001, false);
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0002, false);
			int num = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
			while (true)
			{
				int num2 = 1;
				if (num2 != 0)
				{
					num = ((num == num2) ? 1 : 0);
					goto IL_004d;
				}
				goto IL_0082;
				IL_004d:
				int num3 = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
				int num4;
				while (true)
				{
					num4 = 2;
					while (true)
					{
						num |= ((num3 == num4) ? 1 : 0);
						num3 = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
						if (7 == 0)
						{
							break;
						}
						num4 = 3;
						if (num4 != 0)
						{
							goto end_IL_0061;
						}
					}
					continue;
					end_IL_0061:
					break;
				}
				num2 = ((num3 == num4) ? 1 : 0);
				goto IL_0082;
				IL_0082:
				bool flag = (byte)(num | num2) != 0;
				num = (flag ? 1 : 0);
				if (7 == 0)
				{
					continue;
				}
				if (2u != 0)
				{
					break;
				}
				goto IL_004d;
			}
			if (num == 0)
			{
				return;
			}
			_0095._007E_0095_000F(this._0001, true);
		}
		_0095._007E_0095_000F(this._0002, true);
	}

	public void Apply()
	{
		while (true)
		{
			if (Configration.Mode == CamMode.TriangularMesh)
			{
				_0094._007E_001E_000E(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
				_0094._007E_0092_000E(_000E_0006._007E_0088_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
				_0094._007E_0093_000E(_000E_0006._007E_0088_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
				_0094._007E_0094_000E(_000E_0006._007E_0088_001C(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
				_0094._007E_0095_000E(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
				if (global::_0003._007E_001C(this._0002))
				{
					_0094_0005._007E_009E_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices);
				}
				else if (global::_0003._007E_001C(this._0001))
				{
					_0094_0005._007E_009E_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice);
				}
				goto IL_0253;
			}
			if (Configration.Mode != CamMode.WireFrame)
			{
				break;
			}
			_0094._007E_0096_000E(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
			_0094._007E_0095_000E(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			int num;
			bool num3;
			int num4;
			if (global::_000E._007E_000E_0006(cmb_profilepassofsettype) != 0)
			{
				num = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
				if (0 == 0)
				{
					bool num2 = num == 1;
					if (0 == 0)
					{
						bool flag = num2;
						num3 = flag;
						if (8 == 0)
						{
							goto IL_02c2;
						}
						if (num3)
						{
							_0083_0005._007E_008E_0016(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtInControl);
							break;
						}
						if (global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 2)
						{
							_0083_0005._007E_008E_0016(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtWear);
							break;
						}
						num4 = ((global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 3) ? 1 : 0);
						if (7 == 0)
						{
							goto IL_0263;
						}
						if (num4 != 0)
						{
							_0083_0005._007E_008E_0016(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtInverseWear);
							if (6u != 0)
							{
								break;
							}
							goto IL_04f0;
						}
						num2 = global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 4;
					}
					if (num2)
					{
						_0083_0005._007E_008E_0016(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtOff);
					}
					break;
				}
				goto IL_031c;
			}
			goto IL_04f0;
			IL_04f0:
			_0083_0005._007E_008E_0016(_0082_0005._007E_008D_0016(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtInComputer);
			break;
			IL_0263:
			if (num4 == 0)
			{
				_0083_0005._007E_008E_0016(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtInComputer);
				break;
			}
			bool flag2 = global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 1;
			num3 = flag2;
			goto IL_02c2;
			IL_031c:
			if (num != 0)
			{
				_0083_0005._007E_008E_0016(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtWear);
				break;
			}
			if (global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 3)
			{
				if (uint.MaxValue != 0)
				{
					_0083_0005._007E_008E_0016(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtInverseWear);
					if (false)
					{
						continue;
					}
					break;
				}
				goto IL_0253;
			}
			if (global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 4)
			{
				do
				{
					_0083_0005._007E_008E_0016(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtOff);
				}
				while (false);
			}
			break;
			IL_02c2:
			if (num3)
			{
				_0083_0005._007E_008E_0016(_0082_0005._007E_008C_0016(_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), CutterRadiusCompParamsCompensationType.CtInControl);
				break;
			}
			bool flag3 = global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 2;
			num = (flag3 ? 1 : 0);
			goto IL_031c;
			IL_0253:
			num4 = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
			goto IL_0263;
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		bool flag;
		do
		{
			if (true)
			{
				Control control = new Control();
				Control obj = (Control)P_0;
				if (4u != 0)
				{
					control = obj;
				}
				flag = !PropertiesForm.Inited;
			}
		}
		while (7 == 0);
		if (flag)
		{
			if (0 == 0 && false)
			{
			}
		}
		else
		{
			PropertiesForm.Inited = true;
		}
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

	internal void _0004(object P_0, EventArgs P_1)
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

	internal void _0005(object P_0, EventArgs P_1)
	{
		do
		{
			Control control = new Control();
			control = (Control)P_0;
			bool num = PropertiesForm.Inited;
			if (0 == 0)
			{
				if (!num)
				{
					return;
				}
				bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_profilepassofsettype));
				num = flag;
			}
			if (!num)
			{
				goto IL_01a2;
			}
			int num2 = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
			while (true)
			{
				int num3;
				if (num2 == 0)
				{
					if (false)
					{
						break;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0017());
					if (2 == 0)
					{
						goto IL_012a;
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0017());
				}
				else
				{
					num3 = ((global::_000E._007E_000E_0006(cmb_profilepassofsettype) == 2) ? 1 : 0);
					if (1 == 0)
					{
						goto IL_013a;
					}
					if (num3 == 0)
					{
						goto IL_012a;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0017());
				}
				goto IL_01a2;
				IL_0182:
				if (num2 != 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0017());
				}
				goto IL_01a2;
				IL_013a:
				if (num3 == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0017());
					goto IL_01a2;
				}
				num2 = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
				while (2u != 0)
				{
					bool flag2 = num2 == 4;
					num2 = (flag2 ? 1 : 0);
					if (false)
					{
						continue;
					}
					goto IL_0182;
				}
				continue;
				IL_012a:
				num3 = global::_000E._007E_000E_0006(cmb_profilepassofsettype);
				goto IL_013a;
			}
			continue;
			IL_01a2:
			PropertiesForm.Inited = false;
			Apply();
			ControlUpdate();
		}
		while (false);
		PropertiesForm.Inited = true;
	}

	internal void _0006(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			goto IL_004b;
		}
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
		bool num = flag;
		while (true)
		{
			IL_0094:
			if (num)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0017());
				break;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0017());
				break;
			}
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
			if (6u != 0)
			{
				bool num2 = flag2;
				if (0 == 0)
				{
					if (num2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0017());
						if (8 == 0)
						{
						}
						break;
					}
					bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005));
					num2 = flag3;
				}
				if (num2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0017());
					break;
				}
				bool flag4 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
				num = flag4;
				while (!num)
				{
					bool flag5 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
					num = flag5;
					if (2 == 0)
					{
						goto IL_0094;
					}
					if (6u != 0)
					{
						if (num)
						{
							goto IL_0230;
						}
						bool flag6 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
						num = flag6;
					}
					if (4 == 0)
					{
						continue;
					}
					goto IL_027e;
				}
				goto IL_01d4;
			}
			goto IL_0280;
			IL_027e:
			if (!num)
			{
				break;
			}
			goto IL_0280;
			IL_0280:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0017());
			break;
			IL_0230:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0017());
			break;
		}
		goto IL_029d;
		IL_029d:
		_0095._007E_0096_000F(this._0001, false);
		return;
		IL_01d4:
		if (1 == 0)
		{
			goto IL_004b;
		}
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0017());
		goto IL_029d;
		IL_004b:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0017());
		goto IL_029d;
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
