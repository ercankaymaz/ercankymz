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

public class F_RoughLink : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public GeoLib mwCamParameter = null;

	public camParameters5 buCamParameter = null;

	public ToolBase5 Tool = null;

	public MWCalculationOptions Configration = new MWCalculationOptions();

	public static List<string> Captions = new List<string>();

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal Label _0002;

	internal Label _0003;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal CheckBox _0004;

	internal Panel _0002;

	internal Label _0004;

	internal Label _0005;

	internal Label _0006;

	public ComboBox cmb_firstentry;

	public ComboBox cmb_lastexitramp;

	public ComboBox cmb_firstentryramp;

	public ComboBox cmb_lastexit;

	public ComboBox cmb_arealinkbetweengroupramp;

	public ComboBox cmb_arealinkbetweengroup;

	public ComboBox cmb_arealinkwithingroupramp;

	public ComboBox cmb_arealinkswithingroup;

	internal Panel _0003;

	public ComboBox cmb_linkbetweenslicesramp;

	public ComboBox cmb_linkbetweenslices;

	internal Label _0007;

	internal Label _0008;

	internal Panel _0004;

	public ComboBox cmb_linkbetweenregionrapm;

	public ComboBox cmb_linkbetweenregion;

	internal Label _000E;

	internal Label _000F;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	internal Label _0010;

	internal PictureBox _0001;

	internal CheckBox _0005;

	public F_RoughLink()
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
			_0095._007E_0094_000F(this._0001, true);
			_0095._007E_0094_000F(this._0002, true);
		}
		_0095._007E_0096_000F(this._0004, global::_0003._007E_001A_0002(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0003, global::_0003._007E_0018_0002(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0002, global::_0003._007E_001B_0002(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		_0095._007E_0096_000F(this._0001, global::_0003._007E_0019_0002(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))));
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_firstentry));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstentry), buMWCaptions.FirstEntryType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstentry), buMWCaptions.FirstEntryType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstentry), buMWCaptions.FirstEntryType[2]);
		if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.FromRapidPlane)
		{
			_0097._007E_008E_0011(cmb_firstentry, 0);
		}
		else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseRapidDistance)
		{
			_0097._007E_008E_0011(cmb_firstentry, 1);
		}
		else if (_008F_0004._007E_0089_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))) == FirstEntryType.UseFeedDistance)
		{
			_0097._007E_008E_0011(cmb_firstentry, 2);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_firstentryramp));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstentryramp), buMWCaptions.UseRamp[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_firstentryramp), buMWCaptions.UseRamp[1]);
		if (global::_0003._007E_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))
		{
			_0097._007E_008E_0011(cmb_firstentryramp, 0);
		}
		else
		{
			_0097._007E_008E_0011(cmb_firstentryramp, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_lastexit));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexit), buMWCaptions.LastExitType[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexit), buMWCaptions.LastExitType[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_lastexit), buMWCaptions.LastExitType[2]);
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
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroup));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroup), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroup), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroup), buMWCaptions.MoveHandlingAction[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroup), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroup), buMWCaptions.MoveHandlingAction[2]);
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_arealinkbetweengroup, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_arealinkbetweengroup, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_arealinkbetweengroup, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_arealinkbetweengroup, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_arealinkbetweengroup, 4);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroupramp));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroupramp), buMWCaptions.UseRamp[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkbetweengroupramp), buMWCaptions.UseRamp[1]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_arealinkbetweengroupramp, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_arealinkbetweengroupramp, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_arealinkswithingroup));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkswithingroup), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkswithingroup), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkswithingroup), buMWCaptions.MoveHandlingAction[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkswithingroup), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkswithingroup), buMWCaptions.MoveHandlingAction[2]);
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_arealinkswithingroup, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_arealinkswithingroup, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_arealinkswithingroup, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_arealinkswithingroup, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_arealinkswithingroup, 4);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_arealinkwithingroupramp));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkwithingroupramp), buMWCaptions.UseRamp[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_arealinkwithingroupramp), buMWCaptions.UseRamp[1]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_arealinkwithingroupramp, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_arealinkwithingroupramp, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_linkbetweenslices));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslices), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslices), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslices), buMWCaptions.MoveHandlingAction[7]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslices), buMWCaptions.MoveHandlingAction[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslices), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslices), buMWCaptions.MoveHandlingAction[2]);
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_linkbetweenslices, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_linkbetweenslices, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapStep)
		{
			_0097._007E_008E_0011(cmb_linkbetweenslices, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_linkbetweenslices, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_linkbetweenslices, 4);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_linkbetweenslices, 5);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_linkbetweenslicesramp));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslicesramp), buMWCaptions.UseRamp[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenslicesramp), buMWCaptions.UseRamp[1]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_linkbetweenslicesramp, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_linkbetweenslicesramp, 1);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_linkbetweenregion));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenregion), buMWCaptions.MoveHandlingAction[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenregion), buMWCaptions.MoveHandlingAction[4]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenregion), buMWCaptions.MoveHandlingAction[1]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenregion), buMWCaptions.MoveHandlingAction[5]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenregion), buMWCaptions.MoveHandlingAction[2]);
		if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapDirect)
		{
			_0097._007E_008E_0011(cmb_linkbetweenregion, 0);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBlendSpline)
		{
			_0097._007E_008E_0011(cmb_linkbetweenregion, 1);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeed)
		{
			_0097._007E_008E_0011(cmb_linkbetweenregion, 2);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapBrokenFeedRap)
		{
			_0097._007E_008E_0011(cmb_linkbetweenregion, 3);
		}
		else if (_0092_0004._007E_008C_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))) == MoveHandlingAction.ActionGapRapidPlane)
		{
			_0097._007E_008E_0011(cmb_linkbetweenregion, 4);
		}
		global::_0011._007E_0083_0006(_001C_0005._007E_0082_0016(cmb_linkbetweenregionrapm));
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenregionrapm), buMWCaptions.UseRamp[0]);
		_000E_0004._007E_009E_0014(_001C_0005._007E_0082_0016(cmb_linkbetweenregionrapm), buMWCaptions.UseRamp[1]);
		if (global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_linkbetweenregionrapm, 0);
		}
		else if (!global::_0003._007E_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))))))))
		{
			_0097._007E_008E_0011(cmb_linkbetweenregionrapm, 1);
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
	}

	public void Apply()
	{
		PercentOrValueParameter val = null;
		_0095 obj = _0095._007E_008F_0010;
		FirstEntry obj2 = _009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)));
		bool num = global::_0003._007E_0083(this._0004);
		if (0 == 0)
		{
			obj(obj2, num);
		}
		_0095._007E_0090_0010(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0002));
		_0095._007E_008D_0010(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0003));
		_0095._007E_008E_0010(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), global::_0003._007E_0083(this._0001));
		if (global::_000E._007E_000E_0006(cmb_firstentry) == 0)
		{
			_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), FirstEntryType.FromRapidPlane);
		}
		else if (global::_000E._007E_000E_0006(cmb_firstentry) == 1)
		{
			_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), FirstEntryType.UseRapidDistance);
		}
		else if (global::_000E._007E_000E_0006(cmb_firstentry) == 2)
		{
			_0094_0004._007E_008E_0015(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), FirstEntryType.UseFeedDistance);
		}
		if (global::_000E._007E_000E_0006(cmb_firstentryramp) == 0)
		{
			if (false)
			{
				goto IL_05d2;
			}
			_0095._007E_0081_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0005_0012(_009F._007E_0004_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), false);
		}
		goto IL_028e;
		IL_0c50:
		_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		goto IL_0df7;
		IL_028e:
		bool flag;
		do
		{
			flag = global::_000E._007E_000E_0006(cmb_lastexit) == 0;
		}
		while (2 == 0);
		if (flag)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), LastExitType.BackToRapidPlane);
			goto IL_0379;
		}
		if (global::_000E._007E_000E_0006(cmb_lastexit) == 1)
		{
			goto IL_02fa;
		}
		int num2 = global::_000E._007E_000E_0006(cmb_lastexit);
		int num3 = 2;
		goto IL_033f;
		IL_02fa:
		_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), LastExitType.UseRapidDistance);
		goto IL_0379;
		IL_0652:
		bool flag2;
		if (flag2)
		{
			if (false)
			{
				goto IL_0866;
			}
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		goto IL_06ac;
		IL_06ac:
		if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		else if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		}
		goto IL_0866;
		IL_0379:
		if (global::_000E._007E_000E_0006(cmb_lastexitramp) == 0)
		{
			if (false)
			{
				goto IL_057d;
			}
			_0095._007E_0081_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), true);
		}
		else
		{
			_0095._007E_0081_000F(_0001_0002._007E_0007_0012(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), false);
			if (false)
			{
				goto IL_0c50;
			}
		}
		if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 2)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
		}
		else
		{
			if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) != 3)
			{
				goto IL_057d;
			}
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
		}
		goto IL_05d2;
		IL_033f:
		if (num2 == num3)
		{
			_0095_0004._007E_008F_0015(_0090_0004._007E_008A_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter))), LastExitType.UseFeedDistance);
		}
		goto IL_0379;
		IL_057d:
		if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 4)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
		}
		goto IL_05d2;
		IL_0df7:
		if (global::_000E._007E_000E_0006(cmb_linkbetweenslicesramp) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_linkbetweenslicesramp) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		return;
		IL_05d2:
		if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroupramp) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_000F_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
			goto IL_06ac;
		}
		flag2 = global::_000E._007E_000E_0006(cmb_arealinkbetweengroupramp) == 1;
		goto IL_0652;
		IL_0866:
		if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroupramp) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroupramp) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0002_0002._007E_000E_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 0)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 1)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBlendSpline);
		}
		else
		{
			num2 = global::_000E._007E_000E_0006(cmb_linkbetweenregion);
			num3 = 2;
			if (num3 == 0)
			{
				goto IL_033f;
			}
			if (num2 == num3)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
				if (false)
				{
					goto IL_02fa;
				}
			}
			else if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 3)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
			}
			else if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 4)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
			}
		}
		if (global::_000E._007E_000E_0006(cmb_linkbetweenregionrapm) == 0)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), true);
		}
		else if (5u != 0 && global::_000E._007E_000E_0006(cmb_linkbetweenregionrapm) == 1)
		{
			_0095._007E_0081_000F(_0001_0002._007E_0006_0012(_0004_0002._007E_0011_0012(_0003_0002._007E_0010_0012(_0093_0004._007E_008D_0015(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))))), false);
		}
		bool flag3 = global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 0;
		if (7 == 0)
		{
			goto IL_028e;
		}
		if (flag3)
		{
			_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapDirect);
		}
		else
		{
			if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 1)
			{
				goto IL_0c50;
			}
			if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 2)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapStep);
			}
			else if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 3)
			{
				if (false)
				{
					goto IL_0652;
				}
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeed);
			}
			else if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 4)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapBrokenFeedRap);
			}
			else if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 5)
			{
				_0096_0004._007E_0090_0015(_0003_0002._007E_0010_0012(_007F_0002._007E_008A_0012(_008B._007E_0008_0007(_0084._007E_009D_0006(mwCamParameter)))), MoveHandlingAction.ActionGapRapidPlane);
			}
		}
		goto IL_0df7;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		ControlUpdate();
	}

	internal void _0003(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0004)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0082_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0003)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._0083_0019());
		}
		else if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0002)))
		{
			_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
		}
		else
		{
			bool num = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(this._0001));
			while (true)
			{
				if (num)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._001C_0017());
					break;
				}
				bool num2;
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_arealinkswithingroup)))
				{
					if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0019());
					}
					else
					{
						if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 1)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0019());
							if (global::_0003._007E_0083(_0005))
							{
								F_GifView f_GifView = new F_GifView();
								global::_0011._007E_0084_0006(f_GifView);
								_0086_0003._007E_0018_0014(f_GifView, FormStartPosition.CenterParent);
								_009D_0003._007E_0091_0014(f_GifView);
							}
							break;
						}
						if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 2)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0019());
							if (2u != 0)
							{
								num2 = global::_0003._007E_0083(_0005);
								goto IL_02ce;
							}
							goto IL_06c5;
						}
						if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) != 3)
						{
							bool flag = global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 4;
							if (7u != 0)
							{
								if (flag)
								{
									_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0019());
									if (global::_0003._007E_0083(_0005))
									{
										if (true)
										{
											F_GifView f_GifView2 = new F_GifView();
											global::_0011._007E_0084_0006(f_GifView2);
											_0086_0003._007E_0018_0014(f_GifView2, FormStartPosition.CenterParent);
											_009D_0003._007E_0091_0014(f_GifView2);
											break;
										}
										goto IL_05c8;
									}
									break;
								}
								break;
							}
						}
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0019());
						if (!global::_0003._007E_0083(_0005))
						{
							break;
						}
						F_GifView f_GifView3 = new F_GifView();
						if (0 == 0)
						{
							global::_0011._007E_0084_0006(f_GifView3);
							_0086_0003._007E_0018_0014(f_GifView3, FormStartPosition.CenterParent);
							_009D_0003._007E_0091_0014(f_GifView3);
							break;
						}
					}
					if (global::_0003._007E_0083(_0005))
					{
						F_GifView f_GifView4 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView4);
						_0086_0003._007E_0018_0014(f_GifView4, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView4);
					}
					break;
				}
				if (!global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_arealinkbetweengroup)))
				{
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0019());
					if (global::_0003._007E_0083(_0005))
					{
						F_GifView f_GifView5 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView5);
						_0086_0003._007E_0018_0014(f_GifView5, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView5);
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0019());
					if (global::_0003._007E_0083(_0005))
					{
						F_GifView f_GifView6 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView6);
						_0086_0003._007E_0018_0014(f_GifView6, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView6);
					}
					break;
				}
				F_GifView f_GifView7;
				if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 2)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0019());
					if (global::_0003._007E_0083(_0005))
					{
						f_GifView7 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView7);
						_0086_0003._007E_0018_0014(f_GifView7, FormStartPosition.CenterParent);
						goto IL_05c8;
					}
					break;
				}
				if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0019());
					if (global::_0003._007E_0083(_0005))
					{
						F_GifView f_GifView8 = new F_GifView();
						global::_0011._007E_0084_0006(f_GifView8);
						_0086_0003._007E_0018_0014(f_GifView8, FormStartPosition.CenterParent);
						_009D_0003._007E_0091_0014(f_GifView8);
					}
					break;
				}
				num2 = global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 4;
				if (false)
				{
					goto IL_02ce;
				}
				if (!num2)
				{
					break;
				}
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0019());
				if (!global::_0003._007E_0083(_0005))
				{
					break;
				}
				F_GifView f_GifView9 = new F_GifView();
				global::_0011._007E_0084_0006(f_GifView9);
				goto IL_06c5;
				IL_02fd:
				F_GifView f_GifView10;
				_009D_0003._007E_0091_0014(f_GifView10);
				break;
				IL_06c5:
				if (0 == 0)
				{
					_0086_0003._007E_0018_0014(f_GifView9, FormStartPosition.CenterParent);
					_009D_0003._007E_0091_0014(f_GifView9);
					break;
				}
				goto IL_02fd;
				IL_05c8:
				_009D_0003._007E_0091_0014(f_GifView7);
				break;
				IL_02ce:
				bool flag2 = num2;
				num = flag2;
				if (false)
				{
					continue;
				}
				if (num)
				{
					f_GifView10 = new F_GifView();
					global::_0011._007E_0084_0006(f_GifView10);
					_0086_0003._007E_0018_0014(f_GifView10, FormStartPosition.CenterParent);
					goto IL_02fd;
				}
				break;
			}
		}
		_0095._007E_0096_000F(_0005, false);
	}

	internal void _0004(object P_0, EventArgs P_1)
	{
		Control control = new Control();
		control = (Control)P_0;
		bool num = PropertiesForm.Inited;
		while (true)
		{
			bool flag = num;
			if (false)
			{
				goto IL_0952;
			}
			if (!flag)
			{
				break;
			}
			ControlUpdate();
			while (true)
			{
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_firstentry)))
				{
					if (global::_000E._007E_000E_0006(cmb_firstentry) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_0019());
						if (false)
						{
							goto IL_0806;
						}
					}
					else if (global::_000E._007E_000E_0006(cmb_firstentry) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0006_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_firstentry) == 2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0007_0019());
					}
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_firstentryramp)))
				{
					if (global::_000E._007E_000E_0006(cmb_firstentryramp) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008F_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_firstentryramp) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0005_0019());
					}
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_lastexit)))
				{
					if (global::_000E._007E_000E_0006(cmb_lastexit) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0008_0019());
						if (false)
						{
							break;
						}
					}
					else
					{
						if (7 == 0)
						{
							goto IL_035d;
						}
						if (global::_000E._007E_000E_0006(cmb_lastexit) == 1)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._000E_0019());
						}
						else if (global::_000E._007E_000E_0006(cmb_lastexit) == 2)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._000F_0019());
						}
					}
				}
				int num2;
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_arealinkswithingroup)))
				{
					if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0084_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0086_0019());
					}
					else
					{
						if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 2)
						{
							goto IL_035d;
						}
						bool flag2 = global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 3;
						num2 = (flag2 ? 1 : 0);
						if (2 == 0)
						{
							goto IL_0769;
						}
						if (num2 != 0)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0088_0019());
						}
						else if (global::_000E._007E_000E_0006(cmb_arealinkswithingroup) == 4)
						{
							_008F_0003._007E_0082_0014(this._0001, _0002_0006._0089_0019());
						}
					}
				}
				goto IL_03f1;
				IL_0769:
				if (num2 == 3)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0097_0019());
				}
				else if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 4)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0098_0019());
					if (false)
					{
						goto IL_06fc;
					}
				}
				else if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 5)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0099_0019());
				}
				goto IL_0806;
				IL_0806:
				if (false)
				{
					goto IL_05d8;
				}
				goto IL_080c;
				IL_05d8:
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_arealinkbetweengroupramp)))
				{
					if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroupramp) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0092_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroupramp) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0093_0019());
					}
					if (7 == 0)
					{
						continue;
					}
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_linkbetweenslices)))
				{
					if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0094_0019());
					}
					else
					{
						if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) == 1)
						{
							goto IL_06fc;
						}
						if (global::_000E._007E_000E_0006(cmb_linkbetweenslices) != 2)
						{
							num2 = global::_000E._007E_000E_0006(cmb_linkbetweenslices);
							goto IL_0769;
						}
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0096_0019());
					}
				}
				goto IL_0806;
				IL_06fc:
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0095_0019());
				goto IL_0806;
				IL_03f1:
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_arealinkwithingroupramp)))
				{
					if (global::_000E._007E_000E_0006(cmb_arealinkwithingroupramp) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0090_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_arealinkwithingroupramp) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._0091_0019());
					}
				}
				if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_arealinkbetweengroup)))
				{
					if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 0)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008A_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 1)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008B_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 2)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008C_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 3)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008D_0019());
					}
					else if (global::_000E._007E_000E_0006(cmb_arealinkbetweengroup) == 4)
					{
						_008F_0003._007E_0082_0014(this._0001, _0002_0006._008E_0019());
					}
				}
				goto IL_05d8;
				IL_035d:
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0087_0019());
				goto IL_03f1;
			}
			goto IL_09f9;
			IL_080c:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_linkbetweenslicesramp)))
			{
				if (global::_000E._007E_000E_0006(cmb_linkbetweenslicesramp) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009A_0019());
				}
				else if (global::_000E._007E_000E_0006(cmb_linkbetweenslicesramp) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009B_0019());
				}
			}
			bool flag3 = global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_linkbetweenregion));
			num = flag3;
			if (8 == 0)
			{
				continue;
			}
			if (num)
			{
				if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009C_0019());
				}
				else
				{
					if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) != 1)
					{
						goto IL_0952;
					}
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._009D_0019());
				}
			}
			goto IL_09f9;
			IL_0952:
			if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 2)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009E_0019());
			}
			else if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 3)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._009F_0019());
			}
			else if (global::_000E._007E_000E_0006(cmb_linkbetweenregion) == 4)
			{
				_008F_0003._007E_0082_0014(this._0001, _0002_0006._0001_001A());
			}
			goto IL_09f9;
			IL_09f9:
			if (global::_0001._0002(global::_0005._007E_0014_0003(control), global::_0005._007E_0014_0003(cmb_linkbetweenregionrapm)))
			{
				if (global::_000E._007E_000E_0006(cmb_linkbetweenregionrapm) == 0)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0002_001A());
				}
				else if (global::_000E._007E_000E_0006(cmb_linkbetweenregionrapm) == 1)
				{
					_008F_0003._007E_0082_0014(this._0001, _0002_0006._0003_001A());
				}
			}
			break;
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
}
