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

public class F_ContourLink : Form
{
	public FormProperties Properties = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal Label _0003;

	internal Button _0001;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal Panel _0002;

	internal RadioButton _0001;

	internal Label _0004;

	internal Label _0005;

	internal Label _0006;

	internal RadioButton _0002;

	public ComboBox cmb_firstEntry;

	internal Button _0002;

	public ComboBox cmb_lastexitleadout;

	public ComboBox cmb_firstleadin;

	public ComboBox cmb_lastexit;

	internal Label _0007;

	internal NumericUpDown _0002;

	public ComboBox cmb_gapsalong_largeleadinout;

	public ComboBox cmb_gapsalong_langegap;

	internal Button _0003;

	public ComboBox cmb_gapsalong_smallleadinout;

	public ComboBox cmb_gapsalong_smallgap;

	internal Button _0004;

	internal Panel _0003;

	internal Label _0008;

	internal NumericUpDown _0003;

	public ComboBox cmb_slices_largeleadinout;

	internal RadioButton _0003;

	public ComboBox cmb_slices_largemoves;

	internal RadioButton _0004;

	internal Button _0005;

	internal NumericUpDown _0004;

	public ComboBox cmb_slices_smallleadinout;

	public ComboBox cmb_slices_smallmoves;

	internal Button _0006;

	internal Label _000E;

	internal Label _000F;

	internal Label _0010;

	internal Panel _0004;

	internal Label _0011;

	public ComboBox cmb_pass_largeleadinout;

	public ComboBox cmb_pass_largemoves;

	internal Button _0007;

	internal NumericUpDown _0005;

	public ComboBox cmb_pass_smallleadinout;

	public ComboBox cmb_pass_smallmoves;

	internal Button _0008;

	internal Label _0012;

	internal Label _0013;

	internal Label _0014;

	internal Label _0015;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Button _000E;

	internal Button _000F;

	internal Button _0010;

	internal Button _0011;

	internal Button _0012;

	internal Button _0013;

	internal CheckBox _0003;

	public F_ContourLink()
	{
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
		_0095._007E_0096_000F(this._0002, global::_0003._007E_001A_0002(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0018_0002(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_firstEntry));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstEntry), buMWCaptions.FirstEntryType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstEntry), buMWCaptions.FirstEntryType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstEntry), buMWCaptions.FirstEntryType[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstEntry), buMWCaptions.FirstEntryType[3]);
		if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.FromRapidPlane)
		{
			_0097._007E_008E_0011(cmb_firstEntry, 0);
		}
		else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseRapidDistance)
		{
			_0097._007E_008E_0011(cmb_firstEntry, 1);
		}
		else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseFeedDistance)
		{
			_0097._007E_008E_0011(cmb_firstEntry, 2);
		}
		else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.Direct)
		{
			_0097._007E_008E_0011(cmb_firstEntry, 3);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_firstleadin));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstleadin), buMWCaptions.LeadInUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstleadin), buMWCaptions.LeadInUsage[1]);
		if (global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))
		{
			_0097._007E_008E_0011(cmb_firstleadin, 0);
		}
		else
		{
			_0097._007E_008E_0011(cmb_firstleadin, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_lastexit));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexit), buMWCaptions.LastExitType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexit), buMWCaptions.LastExitType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexit), buMWCaptions.LastExitType[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexit), buMWCaptions.LastExitType[4]);
		if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.BackToRapidPlane)
		{
			_0097._007E_008E_0011(cmb_lastexit, 0);
		}
		else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseRapidDistance)
		{
			_0097._007E_008E_0011(cmb_lastexit, 1);
		}
		else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.UseFeedDistance)
		{
			_0097._007E_008E_0011(cmb_lastexit, 2);
		}
		else if (_0091_0004._007E_008B_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == LastExitType.Direct)
		{
			_0097._007E_008E_0011(cmb_lastexit, 3);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_lastexitleadout));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexitleadout), buMWCaptions.LeadOutUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexitleadout), buMWCaptions.LeadOutUsage[1]);
		if (global::_0003._007E_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))
		{
			_0097._007E_008E_0011(cmb_lastexitleadout, 0);
		}
		else
		{
			_0097._007E_008E_0011(cmb_lastexitleadout, 1);
		}
		if (global::_0003._007E_009C_0002(_009F_0005._007E_0013_0017(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))
		{
			_0095._007E_0093_000F(this._0001, true);
			_0088_0003._007E_001A_0014(this._0001, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_0013_0017(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		}
		else
		{
			_0095._007E_0093_000F(this._0002, false);
			_0088_0003._007E_001A_0014(this._0002, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0013_0017(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[1]);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_langegap), buMWCaptions.MoveHandlingAction[9]);
		}
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapFollowSurfs)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapStep)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 4);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 5);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 6);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapShortestPath)
		{
			_0097._007E_008E_0011(cmb_gapsalong_langegap, 7);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_gapsalong_largeleadinout));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_largeleadinout), buMWCaptions.LeadInOutUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_largeleadinout), buMWCaptions.LeadInOutUsage[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_largeleadinout), buMWCaptions.LeadInOutUsage[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_largeleadinout), buMWCaptions.LeadInOutUsage[3]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & !global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_gapsalong_largeleadinout, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_gapsalong_largeleadinout, 1);
		}
		else if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_gapsalong_largeleadinout, 2);
		}
		else
		{
			_0097._007E_008E_0011(cmb_gapsalong_largeleadinout, 3);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[1]);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallgap), buMWCaptions.MoveHandlingAction[9]);
		}
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapFollowSurfs)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapStep)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 4);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 5);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 6);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapShortestPath)
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallgap, 7);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_gapsalong_smallleadinout));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallleadinout), buMWCaptions.LeadInOutUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallleadinout), buMWCaptions.LeadInOutUsage[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallleadinout), buMWCaptions.LeadInOutUsage[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_gapsalong_smallleadinout), buMWCaptions.LeadInOutUsage[3]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & !global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallleadinout, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallleadinout, 1);
		}
		else if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallleadinout, 2);
		}
		else
		{
			_0097._007E_008E_0011(cmb_gapsalong_smallleadinout, 3);
		}
		_0088_0003._007E_001A_0014(this._0005, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0013_0017(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_pass_largemoves));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[1]);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largemoves), buMWCaptions.MoveHandlingAction[9]);
		}
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapFollowSurfs)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapStep)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 4);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 5);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 6);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapShortestPath)
		{
			_0097._007E_008E_0011(cmb_pass_largemoves, 7);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_pass_largeleadinout));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largeleadinout), buMWCaptions.LeadInOutUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largeleadinout), buMWCaptions.LeadInOutUsage[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largeleadinout), buMWCaptions.LeadInOutUsage[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_largeleadinout), buMWCaptions.LeadInOutUsage[3]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & !global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_pass_largeleadinout, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_pass_largeleadinout, 1);
		}
		else if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_pass_largeleadinout, 2);
		}
		else
		{
			_0097._007E_008E_0011(cmb_pass_largeleadinout, 3);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_pass_smallmoves));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[1]);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallmoves), buMWCaptions.MoveHandlingAction[9]);
		}
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapFollowSurfs)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapStep)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 4);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 5);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 6);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapShortestPath)
		{
			_0097._007E_008E_0011(cmb_pass_smallmoves, 7);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_pass_smallleadinout));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallleadinout), buMWCaptions.LeadInOutUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallleadinout), buMWCaptions.LeadInOutUsage[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallleadinout), buMWCaptions.LeadInOutUsage[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_pass_smallleadinout), buMWCaptions.LeadInOutUsage[3]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & !global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_pass_smallleadinout, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_pass_smallleadinout, 1);
		}
		else if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_pass_smallleadinout, 2);
		}
		else
		{
			_0097._007E_008E_0011(cmb_pass_smallleadinout, 3);
		}
		if (global::_0003._007E_009C_0002(_009F_0005._007E_0013_0017(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))
		{
			_0095._007E_0093_000F(this._0004, true);
			_0088_0003._007E_001A_0014(this._0004, _0087_0003._0019_0014(global::_0007._007E_0014_0005(_009F_0005._007E_0013_0017(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		}
		else
		{
			_0095._007E_0093_000F(this._0003, false);
			_0088_0003._007E_001A_0014(this._0003, _0087_0003._0019_0014(global::_0007._007E_0015_0005(_009F_0005._007E_0013_0017(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))));
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_slices_largemoves));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[1]);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largemoves), buMWCaptions.MoveHandlingAction[9]);
		}
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapFollowSurfs)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapStep)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 4);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 5);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 6);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapShortestPath)
		{
			_0097._007E_008E_0011(cmb_slices_largemoves, 7);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_slices_largeleadinout));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largeleadinout), buMWCaptions.LeadInOutUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largeleadinout), buMWCaptions.LeadInOutUsage[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largeleadinout), buMWCaptions.LeadInOutUsage[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_largeleadinout), buMWCaptions.LeadInOutUsage[3]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & !global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_slices_largeleadinout, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_slices_largeleadinout, 1);
		}
		else if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_slices_largeleadinout, 2);
		}
		else
		{
			_0097._007E_008E_0011(cmb_slices_largeleadinout, 3);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_slices_smallmoves));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[3]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[1]);
		if (Configration.Mode == CamMode.TriangularMesh)
		{
			_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallmoves), buMWCaptions.MoveHandlingAction[9]);
		}
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapFollowSurfs)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapStep)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 4);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 5);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 6);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapShortestPath)
		{
			_0097._007E_008E_0011(cmb_slices_smallmoves, 7);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_slices_smallleadinout));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallleadinout), buMWCaptions.LeadInOutUsage[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallleadinout), buMWCaptions.LeadInOutUsage[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallleadinout), buMWCaptions.LeadInOutUsage[2]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_slices_smallleadinout), buMWCaptions.LeadInOutUsage[3]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & !global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_slices_smallleadinout, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_slices_smallleadinout, 1);
		}
		else if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))) & global::_0003._007E_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_slices_smallleadinout, 2);
		}
		else
		{
			_0097._007E_008E_0011(cmb_slices_smallleadinout, 3);
		}
		ControlUpdate();
		global::_0005._0002._0001(this);
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
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
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_ok)))
		{
			Apply();
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				if (false)
				{
					goto IL_0229;
				}
				global::_0011._001C_0006(this);
				if (false)
				{
					goto IL_04df;
				}
			}
			bool flag = Properties.FormCloseMode == FormCloseModeType.Invisible;
			if (5 == 0)
			{
				goto IL_0307;
			}
			if (flag)
			{
				if (false)
				{
					goto IL_0258;
				}
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(btn_cancel)))
		{
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001C_0006(this);
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				_0095._0094_000F(this, false);
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
		{
			F_LeadControl f_LeadControl = new F_LeadControl();
			f_LeadControl.mwCamLeadController = _0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))));
			f_LeadControl.buCamParameter = new camParameters5(buCamParameter);
			f_LeadControl.Init();
			_009D_0003._007E_0091_0014(f_LeadControl);
			if (f_LeadControl.Properties.Result == DialogResult.OK)
			{
				_0014_0006._007E_008E_001C(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), f_LeadControl.mwCamLeadController);
				buCamParameter = new camParameters5(f_LeadControl.buCamParameter);
			}
		}
		goto IL_0229;
		IL_031b:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			goto IL_0349;
		}
		goto IL_043b;
		IL_02d1:
		F_LeadControl f_LeadControl2 = default(F_LeadControl);
		_0014_0006._007E_008F_001C(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), f_LeadControl2.mwCamLeadController);
		goto IL_0307;
		IL_043b:
		F_LeadControl f_LeadControl3;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(_000F)))
		{
			if (false)
			{
				goto IL_03c1;
			}
			f_LeadControl3 = new F_LeadControl();
			if (false)
			{
				goto IL_02d1;
			}
			f_LeadControl3.mwCamLeadController = _0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))));
			f_LeadControl3.buCamParameter = new camParameters5(buCamParameter);
			f_LeadControl3.Init();
			goto IL_04df;
		}
		return;
		IL_03c1:
		F_LeadControl f_LeadControl4;
		if (f_LeadControl4.Properties.Result == DialogResult.OK)
		{
			if (false)
			{
				goto IL_0229;
			}
			_0014_0006._007E_0090_001C(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))), f_LeadControl4.mwCamLeadController);
			buCamParameter = new camParameters5(f_LeadControl4.buCamParameter);
		}
		goto IL_043b;
		IL_04df:
		if (7u != 0)
		{
			_009D_0003._007E_0091_0014(f_LeadControl3);
			if (f_LeadControl3.Properties.Result == DialogResult.OK)
			{
				_0014_0006._007E_0091_001C(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))), f_LeadControl3.mwCamLeadController);
				buCamParameter = new camParameters5(f_LeadControl3.buCamParameter);
			}
			return;
		}
		goto IL_0349;
		IL_0229:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			goto IL_0258;
		}
		goto IL_031b;
		IL_0258:
		f_LeadControl2 = new F_LeadControl();
		f_LeadControl2.mwCamLeadController = _0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))));
		f_LeadControl2.buCamParameter = new camParameters5(buCamParameter);
		f_LeadControl2.Init();
		_009D_0003._007E_0091_0014(f_LeadControl2);
		if (f_LeadControl2.Properties.Result == DialogResult.OK)
		{
			goto IL_02d1;
		}
		goto IL_031b;
		IL_0349:
		f_LeadControl4 = new F_LeadControl();
		f_LeadControl4.mwCamLeadController = _0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))));
		f_LeadControl4.buCamParameter = new camParameters5(buCamParameter);
		f_LeadControl4.Init();
		_009D_0003._007E_0091_0014(f_LeadControl4);
		goto IL_03c1;
		IL_0307:
		buCamParameter = new camParameters5(f_LeadControl2.buCamParameter);
		goto IL_031b;
	}

	public void ControlUpdate()
	{
		_0095._007E_0095_000F(this._0001, true);
		_0095._007E_0095_000F(this._0002, true);
		if (global::_0003._007E_001C(this._0001))
		{
			_0095._007E_0095_000F(this._0002, false);
			if (false)
			{
				goto IL_008f;
			}
		}
		else
		{
			_0095._007E_0095_000F(this._0001, false);
		}
		_0095._007E_0095_000F(this._0004, true);
		goto IL_008f;
		IL_008f:
		_0095._007E_0095_000F(this._0003, true);
		if (global::_0003._007E_001C(this._0004))
		{
			_0095._007E_0095_000F(this._0003, false);
		}
		else
		{
			_0095._007E_0095_000F(this._0004, false);
		}
	}

	public void Apply()
	{
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_1cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbd: Expected O, but got Unknown
		//IL_1c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4b: Expected O, but got Unknown
		//IL_1078: Unknown result type (might be due to invalid IL or missing references)
		//IL_107e: Expected O, but got Unknown
		PercentOrValueParameter val = null;
		_0095._007E_008F_0010(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0002));
		_0095._007E_008D_0010(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0001));
		if (global::_000E._007E_000E_0006(cmb_firstEntry) == 0)
		{
			_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), FirstEntryType.FromRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_firstEntry) == 1)
		{
			_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), FirstEntryType.UseRapidDistance);
		}
		else if (global::_000E._007E_000E_0006(cmb_firstEntry) == 2)
		{
			_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), FirstEntryType.UseFeedDistance);
		}
		else if (global::_000E._007E_000E_0006(cmb_firstEntry) == 3)
		{
			_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), FirstEntryType.Direct);
		}
		if (global::_000E._007E_000E_0006(cmb_firstleadin) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), false);
		}
		if (global::_000E._007E_000E_0006(cmb_lastexit) == 0)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), LastExitType.BackToRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_lastexit) == 1)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), LastExitType.UseRapidDistance);
		}
		else if (global::_000E._007E_000E_0006(cmb_lastexit) == 2)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), LastExitType.UseFeedDistance);
		}
		else if (global::_000E._007E_000E_0006(cmb_lastexit) == 3)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), LastExitType.Direct);
		}
		if (global::_000E._007E_000E_0006(cmb_lastexitleadout) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), false);
		}
		if (global::_0003._007E_001C(this._0001))
		{
			val = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), true);
			_0094._007E_0082_000E(val, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0001)));
			if (4 == 0)
			{
				goto IL_17fb;
			}
			_0001_0006._007E_0018_0017(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), val);
		}
		else
		{
			val = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), false);
			_0094._007E_0083_000E(val, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0002)));
			_0001_0006._007E_0018_0017(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), val);
		}
		if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapFollowSurfs);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapStep);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 5)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 6)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 7)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapShortestPath);
		}
		if (global::_000E._007E_000E_0006(cmb_gapsalong_largeleadinout) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_largeleadinout) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_largeleadinout) == 2)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapFollowSurfs);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapStep);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 5)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 6)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 7)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapShortestPath);
		}
		if (global::_000E._007E_000E_0006(cmb_gapsalong_smallleadinout) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallleadinout) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallleadinout) == 2)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		val = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), false);
		_0094._007E_0083_000E(val, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0005)));
		_0001_0006._007E_0018_0017(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), val);
		if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapFollowSurfs);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapStep);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 5)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 6)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largemoves) == 7)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapShortestPath);
		}
		if (global::_000E._007E_000E_0006(cmb_pass_largeleadinout) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largeleadinout) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_largeleadinout) == 2)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapFollowSurfs);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapStep);
		}
		else
		{
			if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 4)
			{
				goto IL_17fb;
			}
			if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 5)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
			}
			else if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 6)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
			}
			else if (global::_000E._007E_000E_0006(cmb_pass_smallmoves) == 7)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapShortestPath);
			}
		}
		goto IL_1942;
		IL_1942:
		if (global::_000E._007E_000E_0006(cmb_pass_smallleadinout) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_smallleadinout) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_pass_smallleadinout) == 2)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		if (global::_0003._007E_001C(this._0004))
		{
			val = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), true);
			_0094._007E_0082_000E(val, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0004)));
			_0001_0006._007E_0018_0017(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), val);
		}
		else
		{
			val = new PercentOrValueParameter(_0083._007E_009C_0006(mwCamParameter), false);
			_0094._007E_0083_000E(val, _008B_0003._001F_0014(global::_0008._007E_0099_0005(this._0003)));
			_0001_0006._007E_0018_0017(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), val);
		}
		if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapFollowSurfs);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapStep);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 5)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 6)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 7)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapShortestPath);
		}
		if (global::_000E._007E_000E_0006(cmb_slices_largeleadinout) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largeleadinout) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_largeleadinout) == 2)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapFollowSurfs);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapStep);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 5)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 6)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 7)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapShortestPath);
		}
		if (global::_000E._007E_000E_0006(cmb_slices_smallleadinout) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallleadinout) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallleadinout) == 2)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
			_0095._007E_0081_000F(_0001_0002._007E_0008_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		return;
		IL_17fb:
		_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		goto IL_1942;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
			return;
		}
		bool flag = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
		bool num = flag;
		if (0 == 0)
		{
			if (num)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				return;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_001B());
				return;
			}
			bool flag2 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002));
			if (false)
			{
				return;
			}
			if (flag2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0010_001B());
				return;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				return;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
				if (false)
				{
				}
				return;
			}
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_001B());
				return;
			}
			bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003));
			num = flag3;
		}
		if (num)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0011_001B());
		}
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (0 == 0)
		{
			ControlUpdate();
		}
		if (Properties.Inited)
		{
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_firstEntry)))
			{
				goto IL_0073;
			}
			goto IL_0159;
		}
		return;
		IL_0742:
		int num;
		bool num2;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_gapsalong_smallleadinout)))
		{
			num = global::_000E._007E_000E_0006(cmb_gapsalong_smallleadinout);
			if (false)
			{
				goto IL_012c;
			}
			if (num == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallleadinout) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_001B());
			}
			else
			{
				bool flag = global::_000E._007E_000E_0006(cmb_gapsalong_smallleadinout) == 2;
				num2 = flag;
				if (2 == 0)
				{
					goto IL_0086;
				}
				if (num2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_001B());
				}
				else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallleadinout) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_001B());
				}
			}
		}
		goto IL_085f;
		IL_0317:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_lastexitleadout)))
		{
			if (global::_000E._007E_000E_0006(cmb_lastexitleadout) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_lastexitleadout) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001D_001B());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_gapsalong_smallgap)))
		{
			if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 5)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_smallgap) == 6)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_001B());
			}
		}
		bool num3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_gapsalong_langegap));
		goto IL_0599;
		IL_06e3:
		int num4;
		if (num4 == 5)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_001B());
		}
		else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 6)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_001B());
		}
		goto IL_0742;
		IL_0073:
		num2 = global::_000E._007E_000E_0006(cmb_firstEntry) == 0;
		goto IL_0086;
		IL_0086:
		if (num2)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0012_001B());
		}
		else if (global::_000E._007E_000E_0006(cmb_firstEntry) == 1)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0013_001B());
		}
		else
		{
			if (global::_000E._007E_000E_0006(cmb_firstEntry) != 2)
			{
				num = global::_000E._007E_000E_0006(cmb_firstEntry);
				goto IL_012c;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0014_001B());
		}
		goto IL_0159;
		IL_012c:
		bool flag2 = num == 3;
		num3 = flag2;
		if (8u != 0)
		{
			if (num3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0015_001B());
			}
			goto IL_0159;
		}
		goto IL_0599;
		IL_085f:
		if (false)
		{
			goto IL_02ef;
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_gapsalong_largeleadinout)))
		{
			if (global::_000E._007E_000E_0006(cmb_gapsalong_largeleadinout) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_largeleadinout) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_largeleadinout) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_gapsalong_largeleadinout) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_001B());
			}
		}
		bool flag3;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_slices_smallmoves)))
		{
			if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_001B());
			}
			else
			{
				if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) != 2)
				{
					flag3 = global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 3;
					goto IL_0a6b;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_001B());
			}
		}
		goto IL_0b38;
		IL_0efe:
		if (num3)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_001B());
		}
		return;
		IL_02ef:
		bool flag4;
		if (flag4)
		{
			if (false)
			{
				goto IL_0a6b;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001B_001B());
		}
		goto IL_0317;
		IL_0a6b:
		if (flag3)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_001B());
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 4)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_001B());
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 5)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_001B());
		}
		else if (global::_000E._007E_000E_0006(cmb_slices_smallmoves) == 6)
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_001B());
		}
		goto IL_0b38;
		IL_0b38:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_slices_smallleadinout)))
		{
			if (global::_000E._007E_000E_0006(cmb_slices_smallleadinout) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_001B());
				if (false)
				{
					goto IL_085f;
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_smallleadinout) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_smallleadinout) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_smallleadinout) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_001B());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_slices_largemoves)))
		{
			if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 5)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_slices_largemoves) == 6)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_001B());
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_slices_largeleadinout)))
		{
			if (global::_000E._007E_000E_0006(cmb_slices_largeleadinout) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_001B());
				return;
			}
			if (global::_000E._007E_000E_0006(cmb_slices_largeleadinout) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_001B());
				return;
			}
			if (global::_000E._007E_000E_0006(cmb_slices_largeleadinout) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_001B());
				return;
			}
			num3 = global::_000E._007E_000E_0006(cmb_slices_largeleadinout) == 3;
			goto IL_0efe;
		}
		return;
		IL_0159:
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_lastexit)))
		{
			if (global::_000E._007E_000E_0006(cmb_lastexit) == 0)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0016_001B());
			}
			else if (global::_000E._007E_000E_0006(cmb_lastexit) == 1)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0017_001B());
			}
			else
			{
				if (3 == 0)
				{
					goto IL_0073;
				}
				if (global::_000E._007E_000E_0006(cmb_lastexit) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0018_001B());
				}
				else
				{
					num4 = global::_000E._007E_000E_0006(cmb_lastexit);
					if (4 == 0)
					{
						goto IL_06e3;
					}
					if (num4 == 3)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0019_001B());
					}
				}
			}
		}
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_firstleadin)))
		{
			if (global::_000E._007E_000E_0006(cmb_firstleadin) != 0)
			{
				flag4 = global::_000E._007E_000E_0006(cmb_firstleadin) == 1;
				goto IL_02ef;
			}
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001A_001B());
		}
		goto IL_0317;
		IL_0599:
		if (4u != 0)
		{
			if (num3)
			{
				if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 0)
				{
					goto IL_05c2;
				}
				if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001F_001B());
				}
				else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._007F_001B());
				}
				else if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0080_001B());
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_gapsalong_langegap) != 4)
					{
						num4 = global::_000E._007E_000E_0006(cmb_gapsalong_langegap);
						goto IL_06e3;
					}
					if (-1 == 0)
					{
						goto IL_05c2;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0081_001B());
				}
			}
			goto IL_0742;
		}
		goto IL_0efe;
		IL_05c2:
		_008F_0003._007E_0082_0014(this._0001, _0002_0006._001E_001B());
		goto IL_0742;
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
