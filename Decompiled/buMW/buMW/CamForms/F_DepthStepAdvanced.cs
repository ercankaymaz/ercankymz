using System;
using System.Collections;
using System.Collections.Generic;
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
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;

namespace buMW.CamForms;

public class F_DepthStepAdvanced : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions;

	internal IContainer _0001 = null;

	internal Button _0001;

	internal Button _0002;

	internal ListBox _0001;

	internal CheckBox _0001;

	internal NumericUpDown _0001;

	internal CheckBox _0002;

	internal NumericUpDown _0002;

	internal CheckBox _0003;

	public Button btn_ok;

	internal ImageList _0001;

	public Button btn_cancel;

	internal ImageList _0002;

	internal CheckBox _0004;

	internal PictureBox _0001;

	internal Panel _0001;

	internal Panel _0002;

	internal Label _0001;

	internal CheckBox _0005;

	internal NumericUpDown _0003;

	internal Label _0002;

	internal NumericUpDown _0004;

	internal CheckBox _0006;

	internal CheckBox _0007;

	internal CheckBox _0008;

	internal Panel _0003;

	internal CheckBox _000E;

	internal Panel _0004;

	internal Label _0003;

	internal NumericUpDown _0005;

	internal NumericUpDown _0006;

	internal NumericUpDown _0007;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0004;

	internal Panel _0005;

	internal CheckBox _000F;

	internal Label _0005;

	internal NumericUpDown _0008;

	internal NumericUpDown _000E;

	internal CheckBox _0010;

	internal Label _0006;

	[NonSerialized]
	internal static GetString _009A;

	public F_DepthStepAdvanced()
	{
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		ArrayList arrayList = new ArrayList();
		if (6u != 0)
		{
			ArrayList arrayList2 = arrayList;
		}
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
			if (_008F._007E_0013_0007(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			else if (_008F._007E_0013_0007(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices)
			{
				_0095._007E_0093_000F(this._0001, true);
			}
			_0088_0003._007E_001A_0014(_0007, _0087_0003._0019_0014(global::_0007._007E_000E_0004(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0006, _0004_0004._0097_0014(global::_000E._007E_000F_0006(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_000F_0004(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0010_0004(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0011_0004(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(_0008, _0087_0003._0019_0014(global::_0007._007E_0012_0004(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0088_0003._007E_001A_0014(_000E, _0087_0003._0019_0014(global::_0007._007E_0013_0004(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(_000F, global::_0003._007E_0097(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
			_0095._007E_0096_000F(this._0002, global::_0003._007E_0098(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._0003, global::_0003._007E_0099(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._000E, global::_0003._007E_009A(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._0001, global::_0003._007E_009B(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._0007, global::_0003._007E_009C(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
			_0095._007E_0096_000F(this._0006, global::_0003._007E_009D(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
			_0095._007E_0096_000F(this._0005, global::_0003._007E_009E(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0014_0004(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0087_0003(_0084._007E_009D_0006(mwCamParameter))));
			if (Configration.CamTriMeshType == CamTriangularMeshType.Rough)
			{
				_0095._007E_0096_000F(_0010, global::_0003._007E_009F(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
				_0095._007E_0094_000F(this._0001, false);
				_0095._007E_0094_000F(this._0003, true);
				_0005_0004._007E_0098_0014(this._0003, new Point(5, 190));
			}
			if (Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
			{
				_0095._007E_0096_000F(this._0008, global::_0003._007E_009F(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))));
				_0095._007E_0094_000F(this._0001, true);
				_0095._007E_0094_000F(this._0003, false);
				_0005_0004._007E_0098_0014(this._0001, new Point(5, 190));
			}
			global::_0011._007E_001D_0006(_0006_0004._007E_009A_0014(this._0001));
			for (int i = 0; i <= global::_000E._007E_0010_0006(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))) - 1; i++)
			{
				_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), _0008_0004._007E_009C_0014(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))), i));
			}
		}
		else
		{
			_0095._007E_0094_000F(this._0003, false);
			_0095._007E_0094_000F(this._0001, false);
			if (_008F._007E_0013_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
			{
				_0095._007E_0093_000F(this._0002, true);
			}
			else if (_008F._007E_0013_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))) == MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices)
			{
				_0095._007E_0093_000F(this._0001, true);
			}
			_0088_0003._007E_001A_0014(_0007, _0087_0003._0019_0014(global::_0007._007E_000E_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0006, _0004_0004._0097_0014(global::_000E._007E_000F_0006(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_000F_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0010_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0011_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0095._007E_0096_000F(this._0002, global::_0003._007E_0098(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._0003, global::_0003._007E_0099(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._000E, global::_0003._007E_009A(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0095._007E_0096_000F(this._0001, global::_0003._007E_009B(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0014_0004(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))));
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0087_0003(_0084._007E_009D_0006(mwCamParameter))));
			global::_0011._007E_001D_0006(_0006_0004._007E_009A_0014(this._0001));
			for (int j = 0; j <= global::_000E._007E_0010_0006(_0007_0004._007E_009B_0014(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))))) - 1; j++)
			{
				_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), _0008_0004._007E_009C_0014(_0007_0004._007E_009B_0014(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))), j));
			}
		}
		global::_0011._007E_0086_0006(this);
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0002._0001(this);
		ControlUpdate();
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
		{
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				goto IL_0072;
			}
			goto IL_007f;
		}
		goto IL_00a1;
		IL_0101:
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			_0095._0094_000F(this, false);
		}
		goto IL_0125;
		IL_0072:
		global::_0011._001C_0006(this);
		goto IL_007f;
		IL_007f:
		bool num = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
		goto IL_008d;
		IL_008d:
		if (num)
		{
			_0095._0094_000F(this, false);
		}
		goto IL_00a1;
		IL_0185:
		DialogBoxInput dialogBoxInput;
		dialogBoxInput.FormCaption = _009A(107399701);
		global::_0011._007E_001F_0006(dialogBoxInput);
		_009D_0003._007E_0091_0014(dialogBoxInput);
		if (dialogBoxInput.Result == DialogResult.OK)
		{
			_000E_0004._007E_009D_0014(_0006_0004._007E_009A_0014(this._0001), dialogBoxInput.Value);
		}
		goto IL_01ef;
		IL_00a1:
		if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel)))
		{
			goto IL_0125;
		}
		if (6u != 0)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				goto IL_00f3;
			}
			goto IL_0101;
		}
		goto IL_0185;
		IL_01ef:
		if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			return;
		}
		num = global::_000E._007E_000E_0006(this._0001) < 0;
		int num2 = 0;
		if (num2 == 0)
		{
			num = (num ? 1 : 0) == num2;
			if (5 == 0)
			{
				goto IL_008d;
			}
			num2 = global::_000E._007E_000E_0006(this._0001);
		}
		do
		{
			num2 = ((num2 <= global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1) ? 1 : 0);
		}
		while (4 == 0);
		bool flag = (byte)((num ? 1u : 0u) & (uint)num2) != 0;
		if (0 == 0)
		{
			if (flag)
			{
				_0097._007E_0090_0011(_0006_0004._007E_009A_0014(this._0001), global::_000E._007E_000E_0006(this._0001));
			}
			return;
		}
		goto IL_00f3;
		IL_0125:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			dialogBoxInput = new DialogBoxInput();
			dialogBoxInput.ValueCaption = _009A(107399701);
			if (5 == 0)
			{
				goto IL_0072;
			}
			_0086_0003._007E_0018_0014(dialogBoxInput, FormStartPosition.CenterParent);
			goto IL_0185;
		}
		goto IL_01ef;
		IL_00f3:
		global::_0011._001C_0006(this);
		goto IL_0101;
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0001));
		_0095 obj = _0095._007E_0095_000F;
		NumericUpDown numericUpDown = _000E;
		bool num = global::_0003._007E_0083(_000F);
		if (0 == 0)
		{
			obj(numericUpDown, num);
		}
		if (0 == 0)
		{
			_0095._007E_0095_000F(this._0001, global::_0003._007E_0083(this._0002));
			_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0003));
			_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._000E));
			_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(_0010));
			if (5 == 0)
			{
				goto IL_0168;
			}
			bool num2 = global::_0003._007E_001C(this._0002);
			if (0 == 0)
			{
				bool flag = num2;
				num2 = flag;
			}
			if (!num2)
			{
				goto IL_0125;
			}
			_0095._007E_0095_000F(_0007, true);
		}
		_0095._007E_0095_000F(this._0006, false);
		goto IL_0125;
		IL_0155:
		_0095._007E_0095_000F(this._0006, true);
		goto IL_0168;
		IL_0231:
		bool num3;
		bool flag2 = (byte)num3 != 0;
		if (false || flag2)
		{
			_0095._007E_0095_000F(this._0003, false);
			_0095._007E_0095_000F(this._0008, false);
		}
		return;
		IL_0125:
		while (true)
		{
			bool flag3 = global::_0003._007E_001C(this._0001);
			num3 = flag3;
			if (false)
			{
				break;
			}
			if (num3)
			{
				if (false)
				{
					continue;
				}
				goto IL_0142;
			}
			goto IL_0168;
		}
		goto IL_0231;
		IL_0168:
		if (Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
		{
			_0095._007E_0095_000F(this._0006, !global::_0003._007E_0083(this._0007));
			_0095._007E_0095_000F(this._0008, !global::_0003._007E_0083(this._0006));
			_0095._007E_0095_000F(this._0007, !global::_0003._007E_0083(this._0006));
			_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0006) & global::_0003._007E_008C(this._0006));
		}
		if (5 == 0)
		{
			goto IL_0155;
		}
		num3 = !Configration.isTriangularMeshAdvanced;
		goto IL_0231;
		IL_0142:
		_0095._007E_0095_000F(_0007, false);
		goto IL_0155;
	}

	public void Apply()
	{
		bool num = Configration.Mode == CamMode.TriangularMesh;
		bool flag;
		if (uint.MaxValue != 0)
		{
			flag = num;
		}
		if (flag)
		{
			_0094._007E_0081_0008(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0007)));
			_0097._007E_008F_0011(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0006)));
			_0094._007E_0082_0008(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
			_0094._007E_0089_0007(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			_0094._007E_0083_0008(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0094._007E_008C_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0008)));
			_0094._007E_008B_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_000E)));
			_0095._007E_001A_000F(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(_000F));
			_0095._007E_0016_0010(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0002));
			_0095._007E_0017_0010(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0003));
			_0095._007E_0018_0010(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._000E));
			_0095._007E_0019_0010(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0001));
			if (_008A_0003._007E_001E_0014(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
			{
				_0095._007E_001A_0010(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(_0010));
			}
			if (_008A_0003._007E_001E_0014(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))) == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
			{
				_0095._007E_001A_0010(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0008));
			}
			_0095._007E_0019_000F(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0007));
			_0095._007E_001B_0010(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0006));
			_0095._007E_001C_0010(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0005));
			_0094._007E_0084_0008(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0094._007E_0088_0007(_0084._007E_009D_0006(mwCamParameter), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			global::_0011._007E_001E_0006(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			for (int i = 0; i <= global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1; i++)
			{
				_0094._007E_0086_0008(_0007_0004._007E_009B_0014(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))), _0011_0004._0002_0015(_0010_0004._007E_0001_0015(_0006_0004._007E_009A_0014(this._0001), i)));
			}
			if (global::_0003._007E_001C(this._0002))
			{
				_0098._007E_009B_0011(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep);
			}
			else if (global::_0003._007E_001C(this._0001))
			{
				_0098._007E_009B_0011(_008E._007E_0011_0007(global::_009A._007E_009E_0011(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices);
			}
		}
		else
		{
			_0094._007E_0081_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(_0007)));
			_0097._007E_008F_0011(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _000F_0004._009F_0014(global::_0008._007E_0099_0005(this._0006)));
			_0094._007E_0082_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
			_0094._007E_0089_0007(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			_0094._007E_0083_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0095._007E_0016_0010(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0002));
			_0095._007E_0017_0010(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0003));
			_0095._007E_0018_0010(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._000E));
			_0095._007E_0019_0010(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), global::_0003._007E_0083(this._0001));
			_0094._007E_0084_0008(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0094._007E_0088_0007(_0084._007E_009D_0006(mwCamParameter), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			global::_0011._007E_001E_0006(_0007_0004._007E_009B_0014(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))));
			for (int j = 0; j <= global::_000E._007E_0011_0006(_0006_0004._007E_009A_0014(this._0001)) - 1; j++)
			{
				_0094._007E_0086_0008(_0007_0004._007E_009B_0014(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter))))), _0011_0004._0002_0015(_0010_0004._007E_0001_0015(_0006_0004._007E_009A_0014(this._0001), j)));
			}
			if (global::_0003._007E_001C(this._0002))
			{
				_0098._007E_009B_0011(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep);
			}
			else if (global::_0003._007E_001C(this._0001))
			{
				_0098._007E_009B_0011(_008E._007E_0010_0007(_008D._007E_000F_0007(_008C._007E_000E_0007(_0084._007E_009D_0006(mwCamParameter)))), MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices);
			}
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = PropertiesForm.Inited;
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
				PropertiesForm.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			ControlUpdate();
			goto IL_005a;
			IL_005a:
			PropertiesForm.Inited = true;
			goto IL_0066;
			IL_0066:
			if (true)
			{
				break;
			}
			goto IL_0053;
		}
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = PropertiesForm.Inited;
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
				PropertiesForm.Inited = false;
				if (6u != 0)
				{
					Apply();
					goto IL_0053;
				}
			}
			goto IL_0066;
			IL_0053:
			ControlUpdate();
			goto IL_005a;
			IL_005a:
			PropertiesForm.Inited = true;
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
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			if (global::_0003._007E_0083(this._0004))
			{
				F_GifView f_GifView = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView);
				_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView);
			}
			return;
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			if (global::_0003._007E_0083(this._0004))
			{
				F_GifView f_GifView2 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView2);
				_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView2);
			}
			return;
		}
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
		bool num = flag;
		while (true)
		{
			if (num)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				return;
			}
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004));
			if (8 == 0)
			{
				return;
			}
			if (flag2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_001A());
				return;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0007)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_0019());
				return;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
				return;
			}
			F_GifView f_GifView3;
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (global::_0003._007E_0083(this._0004))
				{
					f_GifView3 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView3);
					_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
					goto IL_02fb;
				}
				return;
			}
			bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000E));
			bool num2 = flag3;
			if (2u != 0)
			{
				if (num2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_001A());
					if (2u != 0)
					{
						return;
					}
					goto IL_0997;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0008)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_001A());
					if (global::_0003._007E_0083(this._0004))
					{
						F_GifView f_GifView4 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView4);
						_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView4);
					}
					return;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					if (global::_0003._007E_0083(this._0004))
					{
						F_GifView f_GifView5 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView5);
						_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView5);
					}
					return;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					if (global::_0003._007E_0083(this._0004))
					{
						F_GifView f_GifView6 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView6);
						_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView6);
					}
					return;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					if (global::_0003._007E_0083(this._0004))
					{
						F_GifView f_GifView7 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView7);
						_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView7);
					}
					return;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0008)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_001A());
					if (6u != 0)
					{
						num = global::_0003._007E_0083(this._0008);
						if (3 == 0)
						{
							continue;
						}
						if (num)
						{
							if (global::_0003._007E_0083(this._0004))
							{
								F_GifView f_GifView8 = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView8);
								_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView8);
							}
						}
						else if (global::_0003._007E_0083(this._0004))
						{
							F_GifView f_GifView9 = new F_GifView();
							global::_0011._007E_0084_0006(f_GifView9);
							_0086_0003._007E_0018_0014(f_GifView9, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView9);
						}
						return;
					}
					goto IL_02fb;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0007)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_001A());
					return;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0006)))
				{
					goto IL_0737;
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					goto IL_07e6;
				}
				bool flag4 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._000E));
				num2 = flag4;
			}
			if (num2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_001A());
				if (global::_0003._007E_0083(this._0004))
				{
					F_GifView f_GifView10 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView10);
					_0086_0003._007E_0018_0014(f_GifView10, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView10);
				}
				if (0 == 0)
				{
					return;
				}
				goto IL_07e6;
			}
			if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0010)))
			{
				break;
			}
			goto IL_08fd;
			IL_02fb:
			_009D_0003._007E_0091_0014(f_GifView3);
			return;
			IL_07e6:
			if (global::_0003._007E_0083(this._0004))
			{
				F_GifView f_GifView11 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView11);
				_0086_0003._007E_0018_0014(f_GifView11, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView11);
			}
			return;
			IL_08fd:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_001A());
			while (true)
			{
				if (global::_0003._007E_0083(this._0008))
				{
					if (global::_0003._007E_0083(this._0004))
					{
						F_GifView f_GifView12 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView12);
						_0086_0003._007E_0018_0014(f_GifView12, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView12);
					}
					break;
				}
				if (!global::_0003._007E_0083(this._0004))
				{
					break;
				}
				if (false)
				{
					continue;
				}
				goto IL_0997;
			}
			goto IL_09ce;
			IL_0737:
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_001A());
			if (global::_0003._007E_0083(this._0004))
			{
				F_GifView f_GifView13 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView13);
				_0086_0003._007E_0018_0014(f_GifView13, FormStartPosition.CenterParent);
				_009D_0003._007E_0091_0014(f_GifView13);
			}
			return;
			IL_0997:
			F_GifView f_GifView14 = new F_GifView();
			global::_0011._007E_0084_0006(f_GifView14);
			if (false)
			{
				goto IL_0737;
			}
			_0086_0003._007E_0018_0014(f_GifView14, FormStartPosition.CenterParent);
			_009D_0003._007E_0091_0014(f_GifView14);
			goto IL_09ce;
			IL_09ce:
			if (8u != 0)
			{
				return;
			}
			goto IL_08fd;
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_001A());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_0019());
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

	static F_DepthStepAdvanced()
	{
		Strings.CreateGetStringDelegate(typeof(F_DepthStepAdvanced));
		Captions = new List<string>();
	}
}
