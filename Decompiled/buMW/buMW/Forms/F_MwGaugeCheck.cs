using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwGaugeCheck : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal PictureBox _0001;

	internal PictureBox _0002;

	internal PictureBox _0003;

	internal PictureBox _0004;

	internal PictureBox _0005;

	internal PictureBox _0006;

	internal PictureBox _0007;

	internal PictureBox _0008;

	internal PictureBox _000E;

	internal PictureBox _000F;

	internal PictureBox _0010;

	internal PictureBox _0011;

	internal PictureBox _0012;

	internal PictureBox _0013;

	internal PictureBox _0014;

	internal PictureBox _0015;

	internal Panel _0001;

	internal PictureBox _0016;

	internal PictureBox _0017;

	internal Label _0001;

	internal CheckBox _0001;

	internal Label _0002;

	internal Label _0003;

	internal Label _0004;

	internal Label _0005;

	internal Label _0006;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal CheckBox _0004;

	internal CheckBox _0005;

	public ComboBox combo_move1;

	public ComboBox combo_action1;

	internal Panel _0002;

	internal CheckBox _0006;

	internal CheckBox _0007;

	internal PictureBox _0018;

	internal Panel _0003;

	internal Panel _0004;

	internal PictureBox _0019;

	internal Label _0007;

	internal Button _0001;

	internal Label _0008;

	internal NumericUpDown _0001;

	internal Label _000E;

	internal NumericUpDown _0002;

	internal Label _000F;

	internal Label _0010;

	internal Label _0011;

	internal Panel _0005;

	internal Panel _0006;

	internal Label _0012;

	internal NumericUpDown _0003;

	internal Label _0013;

	internal CheckBox _0008;

	internal NumericUpDown _0004;

	internal CheckBox _000E;

	internal PictureBox _001A;

	internal Panel _0007;

	internal CheckBox _000F;

	internal Label _0014;

	internal CheckBox _0010;

	internal Label _0015;

	internal CheckBox _0011;

	internal Label _0016;

	internal CheckBox _0012;

	internal Label _0017;

	internal Panel _0008;

	internal PictureBox _001B;

	internal Button _0002;

	public ComboBox combo_action2;

	public ComboBox combo_move2;

	internal PictureBox _001C;

	internal PictureBox _001D;

	internal Label _0018;

	internal CheckBox _0013;

	internal Label _0019;

	internal Panel _000E;

	internal Panel _000F;

	internal Label _001A;

	internal NumericUpDown _0005;

	internal Label _001B;

	internal CheckBox _0014;

	internal NumericUpDown _0006;

	internal CheckBox _0015;

	internal PictureBox _001E;

	internal Panel _0010;

	internal PictureBox _001F;

	internal CheckBox _0016;

	internal PictureBox _007F;

	internal Label _001C;

	internal PictureBox _0080;

	internal CheckBox _0017;

	internal PictureBox _0081;

	internal PictureBox _0082;

	internal Label _001D;

	internal PictureBox _0083;

	internal CheckBox _0018;

	internal PictureBox _0084;

	internal Label _001E;

	internal CheckBox _0019;

	internal PictureBox _0086;

	internal Label _001F;

	internal Panel _0011;

	internal PictureBox _0087;

	internal Button _0003;

	public ComboBox combo_action4;

	public ComboBox combo_move4;

	internal PictureBox _0088;

	internal PictureBox _0089;

	internal Label _007F;

	internal CheckBox _001A;

	internal Label _0080;

	internal Panel _0012;

	internal Panel _0013;

	internal Label _0081;

	internal NumericUpDown _0007;

	internal Label _0082;

	internal CheckBox _001B;

	internal NumericUpDown _0008;

	internal CheckBox _001C;

	internal PictureBox _008A;

	internal Panel _0014;

	internal CheckBox _001D;

	internal Label _0083;

	internal CheckBox _001E;

	internal Label _0084;

	internal CheckBox _001F;

	internal Label _0086;

	internal CheckBox _007F;

	internal Label _0087;

	internal PictureBox _008B;

	internal PictureBox _008C;

	internal PictureBox _008D;

	internal PictureBox _008E;

	internal PictureBox _008F;

	internal PictureBox _0090;

	internal PictureBox _0091;

	internal PictureBox _0092;

	internal Panel _0015;

	internal PictureBox _0093;

	internal Button _0004;

	public ComboBox combo_action3;

	public ComboBox combo_move3;

	internal PictureBox _0094;

	internal PictureBox _0095;

	internal Label _0088;

	internal CheckBox _0080;

	internal Label _0089;

	internal Button _0005;

	internal Button _0006;

	internal Button _0007;

	internal ImageList _0001;

	public Button btn_cancel;

	public Button btn_ok;

	public ComboBox combo_relink1;

	public ComboBox combo_relink2;

	public ComboBox combo_relink4;

	public ComboBox combo_relink3;

	internal Button _0008;

	internal Button _000E;

	internal Button _000F;

	internal Button _0010;

	public F_MwGaugeCheck()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		bool num = Properties.Height > 10;
		bool flag = default(bool);
		if (0 == 0)
		{
			flag = num;
		}
		if (flag)
		{
			_0097._008C_0011(this, Properties.Height);
		}
		bool num2 = Properties.Width > 10;
		bool flag2 = default(bool);
		if (0 == 0)
		{
			flag2 = num2;
		}
		if (flag2)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		global::_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		global::_0095._007E_0096_000F(this._0007, global::_0003._007E_008D(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)));
		global::_0095._007E_0096_000F(this._0006, global::_0003._007E_008E(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)));
		_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0004_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0))));
		_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0005_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0))));
		global::_0095._007E_0096_000F(this._0002, global::_0003._007E_008F(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)));
		global::_0095._007E_0096_000F(this._0003, global::_0003._007E_0090(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)));
		global::_0095._007E_0096_000F(this._0005, global::_0003._007E_0091(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)));
		global::_0095._007E_0096_000F(this._0004, global::_0003._007E_0092(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)));
		global::_0095._007E_0096_000F(this._0001, global::_0003._007E_0093(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)));
		bool flag3;
		if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
		{
			_0097._007E_008E_0011(combo_move1, 0);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
		{
			_0097._007E_008E_0011(combo_relink1, 1);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
		{
			_0097._007E_008E_0011(combo_relink1, 2);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
		{
			_0097._007E_008E_0011(combo_relink1, 3);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
		{
			_0097._007E_008E_0011(combo_relink1, 4);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
		{
			_0097._007E_008E_0011(combo_relink1, 5);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
		{
			_0097._007E_008E_0011(combo_relink1, 6);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
		{
			_0097._007E_008E_0011(combo_relink1, 7);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
		{
			_0097._007E_008E_0011(combo_relink1, 8);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
		{
			_0097._007E_008E_0011(combo_relink1, 9);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
		{
			_0097._007E_008E_0011(combo_relink1, 10);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
		{
			_0097._007E_008E_0011(combo_relink1, 11);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
		{
			_0097._007E_008E_0011(combo_relink1, 12);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
		{
			_0097._007E_008E_0011(combo_relink1, 13);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
		{
			_0097._007E_008E_0011(combo_relink1, 14);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
		{
			_0097._007E_008E_0011(combo_relink1, 15);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
		{
			_0097._007E_008E_0011(combo_relink1, 16);
		}
		else
		{
			if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) != CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
			{
				flag3 = _0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane;
				goto IL_08fd;
			}
			_0097._007E_008E_0011(combo_relink1, 17);
		}
		goto IL_092c;
		IL_08fd:
		if (flag3)
		{
			_0097._007E_008E_0011(combo_relink1, 18);
		}
		else
		{
			_0097._007E_008E_0011(combo_relink1, 0);
		}
		goto IL_092c;
		IL_2bc0:
		if (false)
		{
			goto IL_20b6;
		}
		goto IL_2c81;
		IL_092c:
		if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
		{
			_0097._007E_008E_0011(combo_relink1, 0);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
		{
			_0097._007E_008E_0011(combo_relink1, 1);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
		{
			_0097._007E_008E_0011(combo_relink1, 2);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
		{
			_0097._007E_008E_0011(combo_relink1, 3);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
		{
			_0097._007E_008E_0011(combo_relink1, 4);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
		{
			_0097._007E_008E_0011(combo_relink1, 5);
		}
		else
		{
			_0097._007E_008E_0011(combo_relink1, 0);
		}
		if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
		{
			_0097._007E_008E_0011(combo_action1, 0);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
		{
			_0097._007E_008E_0011(combo_action1, 1);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
		{
			_0097._007E_008E_0011(combo_action1, 2);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
		{
			_0097._007E_008E_0011(combo_action1, 3);
		}
		else
		{
			_0097._007E_008E_0011(combo_action1, 0);
		}
		global::_0095._007E_0096_000F(this._000E, global::_0003._007E_008D(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)));
		global::_0095._007E_0096_000F(this._0008, global::_0003._007E_008E(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)));
		_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0004_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1))));
		_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0005_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1))));
		global::_0095._007E_0096_000F(this._0012, global::_0003._007E_008F(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)));
		global::_0095._007E_0096_000F(this._0011, global::_0003._007E_0090(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)));
		global::_0095._007E_0096_000F(this._000F, global::_0003._007E_0091(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)));
		global::_0095._007E_0096_000F(this._0010, global::_0003._007E_0092(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)));
		global::_0095._007E_0096_000F(this._0013, global::_0003._007E_0093(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)));
		if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
		{
			_0097._007E_008E_0011(combo_move2, 0);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
		{
			_0097._007E_008E_0011(combo_relink2, 1);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
		{
			_0097._007E_008E_0011(combo_relink2, 2);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
		{
			_0097._007E_008E_0011(combo_relink2, 3);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
		{
			_0097._007E_008E_0011(combo_relink2, 4);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
		{
			_0097._007E_008E_0011(combo_relink2, 5);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
		{
			_0097._007E_008E_0011(combo_relink2, 6);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
		{
			_0097._007E_008E_0011(combo_relink2, 7);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
		{
			_0097._007E_008E_0011(combo_relink2, 8);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
		{
			_0097._007E_008E_0011(combo_relink2, 9);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
		{
			_0097._007E_008E_0011(combo_relink2, 10);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
		{
			_0097._007E_008E_0011(combo_relink2, 11);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
		{
			_0097._007E_008E_0011(combo_relink2, 12);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
		{
			_0097._007E_008E_0011(combo_relink2, 13);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
		{
			_0097._007E_008E_0011(combo_relink2, 14);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
		{
			_0097._007E_008E_0011(combo_relink2, 15);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
		{
			_0097._007E_008E_0011(combo_relink2, 16);
		}
		else
		{
			if (8 == 0)
			{
				goto IL_2bc0;
			}
			if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
			{
				_0097._007E_008E_0011(combo_relink2, 17);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane)
			{
				_0097._007E_008E_0011(combo_relink2, 18);
			}
			else
			{
				_0097._007E_008E_0011(combo_relink2, 0);
			}
		}
		if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
		{
			_0097._007E_008E_0011(combo_relink2, 0);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
		{
			_0097._007E_008E_0011(combo_relink2, 1);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
		{
			_0097._007E_008E_0011(combo_relink2, 2);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
		{
			_0097._007E_008E_0011(combo_relink2, 3);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
		{
			_0097._007E_008E_0011(combo_relink2, 4);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
		{
			_0097._007E_008E_0011(combo_relink2, 5);
		}
		else
		{
			_0097._007E_008E_0011(combo_relink2, 0);
		}
		if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
		{
			_0097._007E_008E_0011(combo_action2, 0);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
		{
			_0097._007E_008E_0011(combo_action2, 1);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
		{
			_0097._007E_008E_0011(combo_action2, 2);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
		{
			_0097._007E_008E_0011(combo_action2, 3);
		}
		else
		{
			_0097._007E_008E_0011(combo_action2, 0);
		}
		global::_0095._007E_0096_000F(_001C, global::_0003._007E_008D(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)));
		global::_0095._007E_0096_000F(_001B, global::_0003._007E_008E(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)));
		_0088_0003._007E_001A_0014(this._0007, _0087_0003._0019_0014(global::_0007._007E_0004_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2))));
		_0088_0003._007E_001A_0014(this._0008, _0087_0003._0019_0014(global::_0007._007E_0005_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2))));
		global::_0095._007E_0096_000F(_007F, global::_0003._007E_008F(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)));
		global::_0095._007E_0096_000F(_001F, global::_0003._007E_0090(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)));
		global::_0095._007E_0096_000F(_001D, global::_0003._007E_0091(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)));
		global::_0095._007E_0096_000F(_001E, global::_0003._007E_0092(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)));
		global::_0095._007E_0096_000F(_0080, global::_0003._007E_0093(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)));
		if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
		{
			_0097._007E_008E_0011(combo_move3, 0);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
		{
			_0097._007E_008E_0011(combo_relink3, 1);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
		{
			_0097._007E_008E_0011(combo_relink3, 2);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
		{
			_0097._007E_008E_0011(combo_relink3, 3);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
		{
			_0097._007E_008E_0011(combo_relink3, 4);
		}
		else
		{
			if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
			{
				goto IL_1c59;
			}
			if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
			{
				_0097._007E_008E_0011(combo_relink3, 6);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
			{
				_0097._007E_008E_0011(combo_relink3, 7);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
			{
				_0097._007E_008E_0011(combo_relink3, 8);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
			{
				_0097._007E_008E_0011(combo_relink3, 9);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
			{
				_0097._007E_008E_0011(combo_relink3, 10);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
			{
				_0097._007E_008E_0011(combo_relink3, 11);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
			{
				_0097._007E_008E_0011(combo_relink3, 12);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
			{
				_0097._007E_008E_0011(combo_relink3, 13);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
			{
				_0097._007E_008E_0011(combo_relink3, 14);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
			{
				_0097._007E_008E_0011(combo_relink3, 15);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
			{
				_0097._007E_008E_0011(combo_relink3, 16);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
			{
				_0097._007E_008E_0011(combo_relink3, 17);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane)
			{
				_0097._007E_008E_0011(combo_relink3, 18);
				if (false)
				{
					goto IL_08fd;
				}
			}
			else
			{
				_0097._007E_008E_0011(combo_relink3, 0);
			}
		}
		goto IL_20b6;
		IL_1c59:
		_0097._007E_008E_0011(combo_relink3, 5);
		goto IL_20b6;
		IL_2c81:
		if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
		{
			_0097._007E_008E_0011(combo_relink4, 0);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
		{
			_0097._007E_008E_0011(combo_relink4, 1);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
		{
			_0097._007E_008E_0011(combo_relink4, 2);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
		{
			_0097._007E_008E_0011(combo_relink4, 3);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
		{
			_0097._007E_008E_0011(combo_relink4, 4);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
		{
			_0097._007E_008E_0011(combo_relink4, 5);
		}
		else
		{
			_0097._007E_008E_0011(combo_relink4, 0);
		}
		if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
		{
			_0097._007E_008E_0011(combo_action4, 0);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
		{
			_0097._007E_008E_0011(combo_action4, 1);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
		{
			_0097._007E_008E_0011(combo_action4, 2);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
		{
			_0097._007E_008E_0011(combo_action4, 3);
		}
		else
		{
			_0097._007E_008E_0011(combo_action4, 0);
		}
		UpdateControlFromType();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		return;
		IL_20b6:
		if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp)
		{
			_0097._007E_008E_0011(combo_relink3, 0);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol)
		{
			_0097._007E_008E_0011(combo_relink3, 1);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol)
		{
			_0097._007E_008E_0011(combo_relink3, 2);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol)
		{
			_0097._007E_008E_0011(combo_relink3, 3);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol)
		{
			_0097._007E_008E_0011(combo_relink3, 4);
		}
		else if (_0098_0003._007E_008C_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol)
		{
			_0097._007E_008E_0011(combo_relink3, 5);
		}
		else
		{
			_0097._007E_008E_0011(combo_relink3, 0);
		}
		if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector)
		{
			_0097._007E_008E_0011(combo_action3, 0);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints)
		{
			_0097._007E_008E_0011(combo_action3, 1);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes)
		{
			_0097._007E_008E_0011(combo_action3, 2);
		}
		else if (_0099_0003._007E_008D_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2)) == CollCtrlOpBaseParamsCollStrategy.CsReportCollisions)
		{
			_0097._007E_008E_0011(combo_action3, 3);
		}
		else
		{
			_0097._007E_008E_0011(combo_action3, 0);
		}
		global::_0095._007E_0096_000F(this._0015, global::_0003._007E_008D(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)));
		global::_0095._007E_0096_000F(this._0014, global::_0003._007E_008E(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)));
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0004_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3))));
		_0088_0003._007E_001A_0014(this._0006, _0087_0003._0019_0014(global::_0007._007E_0005_0004(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3))));
		global::_0095._007E_0096_000F(_0019, global::_0003._007E_008F(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)));
		global::_0095._007E_0096_000F(_0018, global::_0003._007E_0090(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)));
		global::_0095._007E_0096_000F(_0016, global::_0003._007E_0091(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)));
		global::_0095._007E_0096_000F(_0017, global::_0003._007E_0092(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)));
		global::_0095._007E_0096_000F(_001A, global::_0003._007E_0093(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)));
		if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine)
		{
			_0097._007E_008E_0011(combo_move4, 0);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ)
		{
			_0097._007E_008E_0011(combo_relink4, 1);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy)
		{
			_0097._007E_008E_0011(combo_relink4, 2);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz)
		{
			_0097._007E_008E_0011(combo_relink4, 3);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz)
		{
			_0097._007E_008E_0011(combo_relink4, 4);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin)
		{
			_0097._007E_008E_0011(combo_relink4, 5);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX)
		{
			_0097._007E_008E_0011(combo_relink4, 6);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin)
		{
			_0097._007E_008E_0011(combo_relink4, 7);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY)
		{
			_0097._007E_008E_0011(combo_relink4, 8);
			if (1 == 0)
			{
				goto IL_1c59;
			}
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin)
		{
			_0097._007E_008E_0011(combo_relink4, 9);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm)
		{
			_0097._007E_008E_0011(combo_relink4, 10);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin)
		{
			_0097._007E_008E_0011(combo_relink4, 11);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont)
		{
			_0097._007E_008E_0011(combo_relink4, 12);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy)
		{
			_0097._007E_008E_0011(combo_relink4, 13);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz)
		{
			_0097._007E_008E_0011(combo_relink4, 14);
		}
		else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz)
		{
			_0097._007E_008E_0011(combo_relink4, 15);
		}
		else
		{
			if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir)
			{
				_0097._007E_008E_0011(combo_relink4, 16);
				goto IL_2bc0;
			}
			if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine)
			{
				_0097._007E_008E_0011(combo_relink4, 17);
			}
			else if (_0097_0003._007E_008B_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3)) == CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane)
			{
				_0097._007E_008E_0011(combo_relink4, 18);
			}
			else
			{
				_0097._007E_008E_0011(combo_relink4, 0);
			}
		}
		goto IL_2c81;
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
				global::_0095._007E_009E_000F(P_1, true);
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
				global::_0095._0094_000F(this, false);
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
			global::_0095._0094_000F(this, false);
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
			global::_0095._0094_000F(this, false);
		}
		return;
		IL_006f:
		num = flag;
		goto IL_002a;
	}

	public void UpdateControlFromType()
	{
		global::_0095._007E_0095_000F(this._0003, global::_0003._007E_0083(this._0001));
		global::_0095._007E_0095_000F(this._0002, global::_0003._007E_0083(this._0001));
		global::_0095._007E_0095_000F(this._0004, global::_0003._007E_0083(this._0001));
		global::_0095._007E_0094_000F(this._0001, !global::_0003._007E_0083(this._0005));
		global::_0095._007E_0094_000F(this._0002, global::_0003._007E_0083(this._0005));
		global::_0095._007E_0094_000F(this._0003, !global::_0003._007E_0083(this._0004));
		global::_0095._007E_0094_000F(this._0008, global::_0003._007E_0083(this._0004));
		global::_0095._007E_0094_000F(this._0005, !global::_0003._007E_0083(this._0003));
		global::_0095._007E_0094_000F(this._0007, global::_0003._007E_0083(this._0003));
		global::_0095._007E_0094_000F(this._0004, !global::_0003._007E_0083(this._0002));
		global::_0095._007E_0094_000F(this._0006, global::_0003._007E_0083(this._0002));
		if (global::_000E._007E_000E_0006(combo_action1) == 0)
		{
			global::_0095._007E_0095_000F(combo_move1, true);
			global::_0095._007E_0095_000F(combo_relink1, false);
			global::_0095._007E_0095_000F(this._0001, true);
		}
		else if (global::_000E._007E_000E_0006(combo_action1) == 1)
		{
			global::_0095._007E_0095_000F(combo_move1, false);
			global::_0095._007E_0095_000F(combo_relink1, true);
			global::_0095._007E_0095_000F(this._0001, false);
		}
		else if (global::_000E._007E_000E_0006(combo_action1) == 1)
		{
			global::_0095._007E_0095_000F(combo_move1, false);
			global::_0095._007E_0095_000F(combo_relink1, false);
			global::_0095._007E_0095_000F(this._0001, false);
		}
		else
		{
			global::_0095._007E_0095_000F(combo_move1, false);
			global::_0095._007E_0095_000F(combo_relink1, false);
			global::_0095._007E_0095_000F(this._0001, false);
		}
		global::_0095._007E_0095_000F(this._000E, !global::_0003._007E_0083(this._0007));
		global::_0095._007E_0095_000F(this._0002, !global::_0003._007E_0083(this._0007));
		global::_0095._007E_0095_000F(this._0008, !global::_0003._007E_0083(this._0007));
		do
		{
			global::_0095._007E_0095_000F(this._0001, !global::_0003._007E_0083(this._0007));
			global::_0095._007E_0095_000F(this._0007, global::_0003._007E_0083(this._0013));
			global::_0095._007E_0095_000F(this._0006, global::_0003._007E_0083(this._0013));
			global::_0095._007E_0095_000F(this._0008, global::_0003._007E_0083(this._0013));
			global::_0095._007E_0094_000F(this._0015, !global::_0003._007E_0083(this._000F));
			global::_0095._007E_0094_000F(this._0014, global::_0003._007E_0083(this._000F));
			global::_0095._007E_0094_000F(this._0013, !global::_0003._007E_0083(this._0010));
			global::_0095._007E_0094_000F(this._0010, global::_0003._007E_0083(this._0010));
			global::_0095._007E_0094_000F(this._0012, !global::_0003._007E_0083(this._0011));
			global::_0095._007E_0094_000F(this._000F, global::_0003._007E_0083(this._0011));
		}
		while (false);
		global::_0095._007E_0094_000F(this._0011, !global::_0003._007E_0083(this._0012));
		global::_0095._007E_0094_000F(this._000E, global::_0003._007E_0083(this._0012));
		if (global::_000E._007E_000E_0006(combo_action2) == 0)
		{
			global::_0095._007E_0095_000F(combo_move2, true);
			global::_0095._007E_0095_000F(combo_relink2, false);
			global::_0095._007E_0095_000F(this._0002, true);
		}
		else if (global::_000E._007E_000E_0006(combo_action2) == 1)
		{
			global::_0095._007E_0095_000F(combo_move2, false);
			global::_0095._007E_0095_000F(combo_relink2, true);
			global::_0095._007E_0095_000F(this._0002, false);
		}
		else if (global::_000E._007E_000E_0006(combo_action2) == 1)
		{
			global::_0095._007E_0095_000F(combo_move2, false);
			global::_0095._007E_0095_000F(combo_relink2, false);
			global::_0095._007E_0095_000F(this._0002, false);
		}
		else
		{
			global::_0095._007E_0095_000F(combo_move2, false);
			global::_0095._007E_0095_000F(combo_relink2, false);
			global::_0095._007E_0095_000F(this._0002, false);
		}
		global::_0095._007E_0095_000F(this._0013, !global::_0003._007E_0083(this._000E));
		global::_0095._007E_0095_000F(this._0004, !global::_0003._007E_0083(this._000E));
		global::_0095._007E_0095_000F(this._0012, !global::_0003._007E_0083(this._000E));
		global::_0095._007E_0095_000F(this._0003, !global::_0003._007E_0083(this._000E));
		global::_0095._007E_0095_000F(_0014, global::_0003._007E_0083(_0080));
		global::_0095._007E_0095_000F(_0013, global::_0003._007E_0083(_0080));
		global::_0095._007E_0095_000F(_0015, global::_0003._007E_0083(_0080));
		global::_0095._007E_0094_000F(_008C, !global::_0003._007E_0083(_001D));
		global::_0095._007E_0094_000F(_0091, global::_0003._007E_0083(_001D));
		global::_0095._007E_0094_000F(_008E, !global::_0003._007E_0083(_001E));
		global::_0095._007E_0094_000F(_008F, global::_0003._007E_0083(_001E));
		global::_0095._007E_0094_000F(_0090, !global::_0003._007E_0083(_001F));
		global::_0095._007E_0094_000F(_008D, global::_0003._007E_0083(_001F));
		global::_0095._007E_0094_000F(_0092, !global::_0003._007E_0083(_007F));
		global::_0095._007E_0094_000F(_008B, global::_0003._007E_0083(_007F));
		int num = global::_000E._007E_000E_0006(combo_action3);
		int num2 = 0;
		if (num2 == 0)
		{
			if (num == num2)
			{
				global::_0095._007E_0095_000F(combo_move3, true);
				global::_0095._007E_0095_000F(combo_relink3, false);
				global::_0095._007E_0095_000F(this._0004, true);
			}
			else if (global::_000E._007E_000E_0006(combo_action3) == 1)
			{
				global::_0095._007E_0095_000F(combo_move3, false);
				global::_0095._007E_0095_000F(combo_relink3, true);
				global::_0095._007E_0095_000F(this._0004, false);
			}
			else if (global::_000E._007E_000E_0006(combo_action3) == 1)
			{
				global::_0095._007E_0095_000F(combo_move3, false);
				global::_0095._007E_0095_000F(combo_relink3, false);
				global::_0095._007E_0095_000F(this._0004, false);
			}
			else
			{
				global::_0095._007E_0095_000F(combo_move3, false);
				global::_0095._007E_0095_000F(combo_relink3, false);
				if (false)
				{
					goto IL_0c61;
				}
				global::_0095._007E_0095_000F(this._0004, false);
			}
			global::_0095._007E_0095_000F(_0082, !global::_0003._007E_0083(_001C));
			global::_0095._007E_0095_000F(this._0008, !global::_0003._007E_0083(_001C));
			global::_0095._007E_0095_000F(_0081, !global::_0003._007E_0083(_001C));
			global::_0095._007E_0095_000F(this._0007, !global::_0003._007E_0083(_001C));
			global::_0095._007E_0095_000F(this._0010, global::_0003._007E_0083(_001A));
			global::_0095._007E_0095_000F(this._000F, global::_0003._007E_0083(_001A));
			global::_0095._007E_0095_000F(_0011, global::_0003._007E_0083(_001A));
			global::_0095._007E_0094_000F(this._0086, !global::_0003._007E_0083(_0016));
			global::_0095._007E_0094_000F(this._0081, global::_0003._007E_0083(_0016));
			global::_0095._007E_0094_000F(this._0084, !global::_0003._007E_0083(_0017));
			global::_0095._007E_0094_000F(this._0080, global::_0003._007E_0083(_0017));
			global::_0095._007E_0094_000F(this._0083, !global::_0003._007E_0083(_0018));
			global::_0095._007E_0094_000F(this._007F, global::_0003._007E_0083(_0018));
			global::_0095._007E_0094_000F(this._0082, !global::_0003._007E_0083(_0019));
			global::_0095._007E_0094_000F(this._001F, global::_0003._007E_0083(_0019));
			if (global::_000E._007E_000E_0006(combo_action4) == 0)
			{
				global::_0095._007E_0095_000F(combo_move4, true);
				global::_0095._007E_0095_000F(combo_relink4, false);
				global::_0095._007E_0095_000F(this._0003, true);
				goto IL_0c87;
			}
			num = global::_000E._007E_000E_0006(combo_action4);
			num2 = 1;
		}
		if (num == num2)
		{
			global::_0095._007E_0095_000F(combo_move4, false);
			global::_0095._007E_0095_000F(combo_relink4, true);
			global::_0095._007E_0095_000F(this._0003, false);
		}
		else
		{
			if (global::_000E._007E_000E_0006(combo_action4) != 1)
			{
				global::_0095._007E_0095_000F(combo_move4, false);
				goto IL_0c61;
			}
			global::_0095._007E_0095_000F(combo_move4, false);
			global::_0095._007E_0095_000F(combo_relink4, false);
			global::_0095._007E_0095_000F(this._0003, false);
		}
		goto IL_0c87;
		IL_0c87:
		global::_0095._007E_0095_000F(this._001B, !global::_0003._007E_0083(this._0015));
		global::_0095._007E_0095_000F(this._0006, !global::_0003._007E_0083(this._0015));
		global::_0095._007E_0095_000F(this._001A, !global::_0003._007E_0083(this._0015));
		global::_0095._007E_0095_000F(this._0005, !global::_0003._007E_0083(this._0015));
		global::_0095._007E_0095_000F(this._0005, global::_0003._007E_0083(this._0001) | global::_0003._007E_0083(this._0013) | global::_0003._007E_0083(_0080) | global::_0003._007E_0083(_001A));
		return;
		IL_0c61:
		global::_0095._007E_0095_000F(combo_relink4, false);
		global::_0095._007E_0095_000F(this._0003, false);
		goto IL_0c87;
	}

	public void Apply()
	{
		global::_0095._007E_0007_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), global::_0003._007E_0083(this._0006));
		global::_0095._007E_0008_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), global::_0003._007E_0083(this._0007));
		global::_0094._007E_001F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
		global::_0094._007E_007F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
		global::_0095._007E_000E_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), global::_0003._007E_0083(this._0002));
		global::_0095._007E_000F_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), global::_0003._007E_0083(this._0003));
		global::_0095._007E_0010_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), global::_0003._007E_0083(this._0005));
		global::_0095._007E_0011_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), global::_0003._007E_0083(this._0004));
		global::_0095._007E_0012_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), global::_0003._007E_0083(this._0001));
		int num;
		if (global::_000E._007E_000E_0006(combo_move1) == 0)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine);
		}
		else if (global::_000E._007E_000E_0006(combo_move1) == 1)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ);
		}
		else if (global::_000E._007E_000E_0006(combo_move1) == 2)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy);
		}
		else if (global::_000E._007E_000E_0006(combo_move1) == 3)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz);
		}
		else
		{
			num = global::_000E._007E_000E_0006(combo_move1);
			if (false)
			{
				goto IL_278f;
			}
			if (num == 4)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 5)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 6)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 7)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 8)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 9)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 10)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 11)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 12)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 13)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 14)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz);
			}
			else if (global::_000E._007E_000E_0006(combo_move1) == 15)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz);
			}
			else
			{
				if (global::_000E._007E_000E_0006(combo_move1) == 16)
				{
					goto IL_0799;
				}
				if (global::_000E._007E_000E_0006(combo_move1) == 17)
				{
					goto IL_07ec;
				}
				if (global::_000E._007E_000E_0006(combo_move1) == 18)
				{
					_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane);
				}
			}
		}
		goto IL_0870;
		IL_0799:
		_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir);
		goto IL_0870;
		IL_278f:
		if (num == 8)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 9)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 10)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 11)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 12)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 13)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 14)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 15)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 16)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 17)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 18)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane);
		}
		goto IL_2b05;
		IL_0870:
		if (global::_000E._007E_000E_0006(combo_relink1) == 0)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp);
		}
		else if (global::_000E._007E_000E_0006(combo_relink1) == 1)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink1) == 2)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink1) == 3)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink1) == 4)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink1) == 5)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol);
		}
		if (global::_000E._007E_000E_0006(combo_action1) == 0)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector);
		}
		else if (global::_000E._007E_000E_0006(combo_action1) == 1)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints);
		}
		else
		{
			if (4 == 0)
			{
				goto IL_1715;
			}
			if (global::_000E._007E_000E_0006(combo_action1) == 2)
			{
				_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes);
			}
			else if (global::_000E._007E_000E_0006(combo_action1) == 3)
			{
				_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpBaseParamsCollStrategy.CsReportCollisions);
			}
		}
		global::_0095._007E_0007_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), global::_0003._007E_0083(this._0008));
		global::_0095._007E_0008_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), global::_0003._007E_0083(this._000E));
		global::_0094._007E_001F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
		global::_0094._007E_007F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
		global::_0095._007E_000E_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), global::_0003._007E_0083(this._0012));
		global::_0095._007E_000F_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), global::_0003._007E_0083(this._0011));
		global::_0095._007E_0010_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), global::_0003._007E_0083(this._000F));
		global::_0095._007E_0011_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), global::_0003._007E_0083(this._0010));
		global::_0095._007E_0012_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), global::_0003._007E_0083(this._0013));
		bool flag = default(bool);
		if (global::_000E._007E_000E_0006(combo_move2) == 0)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 1)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 2)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 3)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 4)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz);
		}
		else
		{
			if (global::_000E._007E_000E_0006(combo_move2) != 5)
			{
				flag = global::_000E._007E_000E_0006(combo_move2) == 6;
				goto IL_0fe2;
			}
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin);
		}
		goto IL_13f5;
		IL_1715:
		global::_0095._007E_0007_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), global::_0003._007E_0083(_001B));
		global::_0095._007E_0008_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), global::_0003._007E_0083(_001C));
		global::_0094._007E_001F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0007)));
		global::_0094._007E_007F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0008)));
		global::_0095._007E_000E_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), global::_0003._007E_0083(_007F));
		global::_0095._007E_000F_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), global::_0003._007E_0083(_001F));
		global::_0095._007E_0010_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), global::_0003._007E_0083(_001D));
		global::_0095._007E_0011_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), global::_0003._007E_0083(_001E));
		global::_0095._007E_0012_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), global::_0003._007E_0083(_0080));
		if (global::_000E._007E_000E_0006(combo_move3) == 0)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 1)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 2)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 3)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 4)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 5)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 6)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 7)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 8)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 9)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin);
		}
		else if (global::_000E._007E_000E_0006(combo_move3) == 10)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm);
		}
		else
		{
			bool flag2 = global::_000E._007E_000E_0006(combo_move3) == 11;
			if (1 == 0)
			{
				goto IL_0fe2;
			}
			if (flag2)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin);
			}
			else if (global::_000E._007E_000E_0006(combo_move3) == 12)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont);
			}
			else if (global::_000E._007E_000E_0006(combo_move3) == 13)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy);
			}
			else if (global::_000E._007E_000E_0006(combo_move3) == 14)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz);
			}
			else if (global::_000E._007E_000E_0006(combo_move3) == 15)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz);
			}
			else if (global::_000E._007E_000E_0006(combo_move3) == 16)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir);
			}
			else if (global::_000E._007E_000E_0006(combo_move3) == 17)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine);
			}
			else if (global::_000E._007E_000E_0006(combo_move3) == 18)
			{
				_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane);
			}
		}
		if (global::_000E._007E_000E_0006(combo_relink3) == 0)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp);
		}
		else if (global::_000E._007E_000E_0006(combo_relink3) == 1)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink3) == 2)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink3) == 3)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink3) == 4)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink3) == 5)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol);
		}
		if (global::_000E._007E_000E_0006(combo_action3) == 0)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector);
		}
		else if (global::_000E._007E_000E_0006(combo_action3) == 1)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints);
		}
		else if (global::_000E._007E_000E_0006(combo_action3) == 2)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes);
		}
		else if (global::_000E._007E_000E_0006(combo_action3) == 3)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 2), CollCtrlOpBaseParamsCollStrategy.CsReportCollisions);
		}
		global::_0095._007E_0007_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), global::_0003._007E_0083(this._0014));
		global::_0095._007E_0008_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), global::_0003._007E_0083(this._0015));
		global::_0094._007E_001F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		global::_0094._007E_007F_0008(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0006)));
		global::_0095._007E_000E_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), global::_0003._007E_0083(_0019));
		global::_0095._007E_000F_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), global::_0003._007E_0083(_0018));
		global::_0095._007E_0010_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), global::_0003._007E_0083(_0016));
		global::_0095._007E_0011_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), global::_0003._007E_0083(_0017));
		global::_0095._007E_0012_0010(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), global::_0003._007E_0083(_001A));
		if (4 == 0)
		{
			goto IL_0799;
		}
		if (global::_000E._007E_000E_0006(combo_move4) == 0)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromContactLine);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 1)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZ);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 2)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXy);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 3)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXz);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 4)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYz);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 5)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInZMin);
		}
		else if (global::_000E._007E_000E_0006(combo_move4) == 6)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX);
		}
		else
		{
			if (global::_000E._007E_000E_0006(combo_move4) != 7)
			{
				num = global::_000E._007E_000E_0006(combo_move4);
				goto IL_278f;
			}
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin);
		}
		goto IL_2b05;
		IL_2b05:
		if (global::_000E._007E_000E_0006(combo_relink4) == 0)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp);
		}
		else if (global::_000E._007E_000E_0006(combo_relink4) == 1)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink4) == 2)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink4) == 3)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink4) == 4)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink4) == 5)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol);
		}
		if (global::_000E._007E_000E_0006(combo_action4) == 0)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector);
		}
		else if (global::_000E._007E_000E_0006(combo_action4) == 1)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints);
		}
		else if (global::_000E._007E_000E_0006(combo_action4) == 2)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes);
		}
		else if (global::_000E._007E_000E_0006(combo_action4) == 3)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 3), CollCtrlOpBaseParamsCollStrategy.CsReportCollisions);
		}
		return;
		IL_07ec:
		_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 0), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine);
		goto IL_0870;
		IL_13f5:
		if (global::_000E._007E_000E_0006(combo_relink2) == 0)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollLeaveOutPointsType.LopDontTrimTp);
		}
		else if (global::_000E._007E_000E_0006(combo_relink2) == 1)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink2) == 2)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink2) == 3)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBetwFirstAndLastCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink2) == 4)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpBeforeFirstCol);
		}
		else if (global::_000E._007E_000E_0006(combo_relink2) == 5)
		{
			_009B_0003._007E_008F_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollLeaveOutPointsType.LopTrimTpAfterLastCol);
		}
		if (global::_000E._007E_000E_0006(combo_action2) == 0)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpBaseParamsCollStrategy.CsMoveToolAlongVector);
		}
		else if (global::_000E._007E_000E_0006(combo_action2) == 1)
		{
			if (1 == 0)
			{
				goto IL_07ec;
			}
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPoints);
		}
		else if (global::_000E._007E_000E_0006(combo_action2) == 2)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpBaseParamsCollStrategy.CsLeaveOutPlanes);
		}
		else if (global::_000E._007E_000E_0006(combo_action2) == 3)
		{
			_009C_0003._007E_0090_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpBaseParamsCollStrategy.CsReportCollisions);
		}
		goto IL_1715;
		IL_0fe2:
		if (flag)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInX);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 7)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInXMin);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 8)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInY);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 9)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInYMin);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 10)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongSurfNorm);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 11)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAwayFromOrigin);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 12)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractMoveToCenterOfCont);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 13)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXy);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 14)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInXz);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 15)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractOptInYz);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 16)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractInCustomDir);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 17)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolContactLine);
		}
		else if (global::_000E._007E_000E_0006(combo_move2) == 18)
		{
			_009A_0003._007E_008E_0014(_0096_0003._007E_008A_0014(_0095_0003._007E_0089_0014(_0090_0003._007E_0083_0014(Par)), 1), CollCtrlOpParamsCollSideRetractDir.AvoidByRetractAlongToolBottomPlane);
		}
		goto IL_13f5;
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

	internal void _0005(object P_0, EventArgs P_1)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected O, but got Unknown
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			Apply();
			F_MwGaugeItemAdvanced f_MwGaugeItemAdvanced = new F_MwGaugeItemAdvanced();
			f_MwGaugeItemAdvanced.Par = new MachiningParams(Par);
			f_MwGaugeItemAdvanced.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeItemAdvanced);
			if (f_MwGaugeItemAdvanced.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeItemAdvanced.Par);
				global::_0011._007E_001C_0006(f_MwGaugeItemAdvanced);
			}
		}
		F_MwGaugeItemAdvanced f_MwGaugeItemAdvanced2;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			Apply();
			f_MwGaugeItemAdvanced2 = new F_MwGaugeItemAdvanced();
			goto IL_00e9;
		}
		goto IL_014f;
		IL_00e9:
		f_MwGaugeItemAdvanced2.Par = new MachiningParams(Par);
		f_MwGaugeItemAdvanced2.GaugeIndex = 1;
		f_MwGaugeItemAdvanced2.Init();
		_009D_0003._007E_0091_0014(f_MwGaugeItemAdvanced2);
		if (f_MwGaugeItemAdvanced2.Properties.Result == DialogResult.OK)
		{
			Par = new MachiningParams(f_MwGaugeItemAdvanced2.Par);
			global::_0011._007E_001C_0006(f_MwGaugeItemAdvanced2);
		}
		goto IL_014f;
		IL_03f8:
		F_MwGaugeClearanceForTool f_MwGaugeClearanceForTool = new F_MwGaugeClearanceForTool();
		f_MwGaugeClearanceForTool.Par = new MachiningParams(Par);
		f_MwGaugeClearanceForTool.Init();
		if (6u != 0)
		{
			_009D_0003._007E_0091_0014(f_MwGaugeClearanceForTool);
			if (f_MwGaugeClearanceForTool.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeClearanceForTool.Par);
				global::_0011._007E_001C_0006(f_MwGaugeClearanceForTool);
			}
			return;
		}
		goto IL_00e9;
		IL_014f:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			Apply();
			F_MwGaugeItemAdvanced f_MwGaugeItemAdvanced3 = new F_MwGaugeItemAdvanced();
			f_MwGaugeItemAdvanced3.Par = new MachiningParams(Par);
			f_MwGaugeItemAdvanced3.GaugeIndex = 2;
			f_MwGaugeItemAdvanced3.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeItemAdvanced3);
			bool flag = f_MwGaugeItemAdvanced3.Properties.Result == DialogResult.OK;
			if (false)
			{
				goto IL_03f8;
			}
			if (flag)
			{
				Par = new MachiningParams(f_MwGaugeItemAdvanced3.Par);
				global::_0011._007E_001C_0006(f_MwGaugeItemAdvanced3);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			Apply();
			F_MwGaugeItemAdvanced f_MwGaugeItemAdvanced4 = new F_MwGaugeItemAdvanced();
			f_MwGaugeItemAdvanced4.Par = new MachiningParams(Par);
			f_MwGaugeItemAdvanced4.GaugeIndex = 3;
			f_MwGaugeItemAdvanced4.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeItemAdvanced4);
			if (f_MwGaugeItemAdvanced4.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeItemAdvanced4.Par);
				global::_0011._007E_001C_0006(f_MwGaugeItemAdvanced4);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0007)))
		{
			Apply();
			F_MwGaugeAdvancedSettings f_MwGaugeAdvancedSettings = new F_MwGaugeAdvancedSettings();
			f_MwGaugeAdvancedSettings.Par = new MachiningParams(Par);
			f_MwGaugeAdvancedSettings.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeAdvancedSettings);
			if (f_MwGaugeAdvancedSettings.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeAdvancedSettings.Par);
				global::_0011._007E_001C_0006(f_MwGaugeAdvancedSettings);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0005)))
		{
			Apply();
			F_MwGaugeRemainCollsion f_MwGaugeRemainCollsion = new F_MwGaugeRemainCollsion();
			f_MwGaugeRemainCollsion.Par = new MachiningParams(Par);
			f_MwGaugeRemainCollsion.Init();
			_009D_0003._007E_0091_0014(f_MwGaugeRemainCollsion);
			if (f_MwGaugeRemainCollsion.Properties.Result == DialogResult.OK)
			{
				Par = new MachiningParams(f_MwGaugeRemainCollsion.Par);
				global::_0011._007E_001C_0006(f_MwGaugeRemainCollsion);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_0006)))
		{
			Apply();
			goto IL_03f8;
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
		global::_0095._0091_000F(this, disposing);
	}
}
