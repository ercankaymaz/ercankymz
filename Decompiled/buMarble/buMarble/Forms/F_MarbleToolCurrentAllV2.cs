using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;

namespace buMarble.Forms;

public class F_MarbleToolCurrentAllV2 : Form
{
	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public int SelectedTab = 0;

	internal IContainer _0001 = null;

	internal buGround _0001;

	public buButton btn_ok;

	public buButton btn_cancel;

	public buButton btn_opentools;

	public buButton btn_savetools;

	public buTab buTab_tools;

	public TabPage tabPage_saw;

	public TabPage tabPage_mlling;

	internal Panel _0001;

	public buButton btn_saw_activate;

	public buButton btn_saw_zeroposition;

	public buButton btn_sawgonyele;

	public buButton btn_sawlimitdisable;

	public buButton btn_saw_measure;

	public buSpin spn_sawspeed;

	public buSpin spn_sawthickness;

	public buSpin spn_sawdia;

	public buButton btn_milling_activate;

	public buButton btn_milling_zeroposition;

	public buButton btn_milling_limitdisable;

	public buButton btn_milling_measure;

	public buSpin spn_milling_speed;

	public buSpin spn_milling_length;

	public buSpin spn_milling_diameter;

	internal Panel _0002;

	internal PictureBox _0001;

	internal PictureBox _0002;

	internal TabPage _0001;

	internal Panel _0003;

	internal PictureBox _0003;

	public buButton btn_millinghead_activate;

	public buButton btn_millinghead_zeroposition;

	public buButton btn_millinghead_limitdisable;

	public buButton btn_millinghead_measure;

	public buSpin spn_millinghead_speed;

	public buSpin spn_millinghead_length;

	public buSpin spn_millinghead_diameter;

	public buButton btn_toolstop;

	public buButton btn_millingheadtool;

	public buButton btn_millingtool;

	public buButton btn_sawtool;

	public buButton btn_closecross;

	public buButton btn_toollist;

	public buButton btn_saw_settings;

	public buButton btn_milling_edit;

	public buButton btn_milling_settings;

	public buButton btn_millinghead_edit;

	public buButton btn_millinghead_settings;

	public buButton btn_magazine;

	internal TabPage _0002;

	public buSpin spn_toolmagapeed1;

	public buSpin spn_toolmaglen1;

	public buSpin spn_toolmagdia1;

	internal Panel _0004;

	public buButton btn_toolmagtake10;

	public buSpin spn_toolmagdia10;

	public buButton btn_toolmagset10;

	public buSpin spn_toolmaglen10;

	public buSpin spn_toolmagapeed10;

	internal Panel _0005;

	public buButton btn_toolmagtake9;

	public buSpin spn_toolmagdia9;

	public buButton btn_toolmagset9;

	public buSpin spn_toolmaglen9;

	public buSpin spn_toolmagapeed9;

	internal Panel _0006;

	public buButton btn_toolmagtake8;

	public buSpin spn_toolmagdia8;

	public buButton btn_toolmagset8;

	public buSpin spn_toolmaglen8;

	public buSpin spn_toolmagapeed8;

	internal Panel _0007;

	public buButton btn_toolmagtake7;

	public buSpin spn_toolmagdia7;

	public buButton btn_toolmagset7;

	public buSpin spn_toolmaglen7;

	public buSpin spn_toolmagapeed7;

	internal Panel _0008;

	public buButton btn_toolmagtake6;

	public buSpin spn_toolmagdia6;

	public buButton btn_toolmagset6;

	public buSpin spn_toolmaglen6;

	public buSpin spn_toolmagapeed6;

	internal Panel _000E;

	public buButton btn_toolmagtake5;

	public buSpin spn_toolmagdia5;

	public buButton btn_toolmagset5;

	public buSpin spn_toolmaglen5;

	public buSpin spn_toolmagapeed5;

	internal Panel _000F;

	public buButton btn_toolmagtake4;

	public buSpin spn_toolmagdia4;

	public buButton btn_toolmagset4;

	public buSpin spn_toolmaglen4;

	public buSpin spn_toolmagapeed4;

	internal Panel _0010;

	public buButton btn_toolmagtake3;

	public buSpin spn_toolmagdia3;

	public buButton btn_toolmagset3;

	public buSpin spn_toolmaglen3;

	public buSpin spn_toolmagapeed3;

	internal Panel _0011;

	public buButton btn_toolmagtake2;

	public buSpin spn_toolmagdia2;

	public buButton btn_toolmagset2;

	public buSpin spn_toolmaglen2;

	public buSpin spn_toolmagapeed2;

	internal Panel _0012;

	internal buLabel _0001;

	public buButton btn_toolmagtake1;

	public buButton btn_toolmagset1;

	internal buLabel _0002;

	internal buLabel _0003;

	internal buLabel _0004;

	internal buLabel _0005;

	internal buLabel _0006;

	internal buLabel _0007;

	internal buLabel _0008;

	internal buLabel _000E;

	internal buLabel _000F;

	internal ImageList _0001;

	public buButton btn_toolmag1;

	public buButton btn_toolmag10;

	public buButton btn_toolmag9;

	public buButton btn_toolmag8;

	public buButton btn_toolmag7;

	public buButton btn_toolmag6;

	public buButton btn_toolmag5;

	public buButton btn_toolmag4;

	public buButton btn_toolmag3;

	public buButton btn_toolmag2;

	public buSpin spn_sawsocket;

	public buButton btn_saw_gozeroposition;

	public buButton btn_milling_gozeroposition;

	public buButton btn_millinghead_gozeroposition;

	[NonSerialized]
	internal static GetString _0002;

	public F_MarbleToolCurrentAllV2()
	{
		global::_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D obj = global::_008D._008F_0007;
			int num = PropertiesForm.Height;
			if (0 == 0)
			{
				obj(this, num);
			}
		}
		if (PropertiesForm.Width > 10)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
			while (2 == 0)
			{
			}
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		global::_008C._007E_0002_0007(buTab_tools, new Size(1, 1));
		global::_0082._007E_0086_0005(btn_millingtool, buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingEnable);
		global::_0082._007E_0086_0005(btn_millingheadtool, buMarbleCalc.varMarbleMachineSettings.OptionSettings.MillingHeadEnable);
		global::_0082._007E_0086_0005(btn_magazine, buMarbleCalc.varMarbleMachineSettings.OptionSettings.AutoToolChanger);
		global::_0095._007E_0008_0008(spn_milling_diameter, buMarbleCalc.activeToolMilling.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_milling_length, buMarbleCalc.activeToolMilling.Geometry.Length);
		global::_0095._007E_0008_0008(spn_milling_speed, buMarbleCalc.activeToolMilling.CamData.SpindleSpeed);
		global::_0095._007E_0008_0008(spn_sawdia, buMarbleCalc.activeToolSaw.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_sawthickness, buMarbleCalc.activeToolSaw.Geometry.Thickness);
		global::_0095._007E_0008_0008(spn_sawspeed, buMarbleCalc.activeToolSaw.CamData.SpindleSpeed);
		global::_0095._007E_0008_0008(spn_sawsocket, buMarbleCalc.activeToolSaw.Geometry.SocketThickness);
		global::_0095._007E_0008_0008(spn_millinghead_diameter, buMarbleCalc.activeToolMillingHead.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_millinghead_length, buMarbleCalc.activeToolMillingHead.Geometry.Length);
		global::_0095._007E_0008_0008(spn_millinghead_speed, buMarbleCalc.activeToolMillingHead.CamData.SpindleSpeed);
		if ((clsAppMarbleVars.varApp.ToolChangeCount > 0) & (buMarbleCalc.ToolInMagazine != null))
		{
			global::_0095._007E_0008_0008(spn_toolmagdia1, buMarbleCalc.ToolInMagazine[1].Geometry.Diameter);
			if (0 == 0)
			{
				global::_0095._007E_0008_0008(spn_toolmaglen1, buMarbleCalc.ToolInMagazine[1].Geometry.Length);
				global::_0095._007E_0008_0008(spn_toolmagapeed1, buMarbleCalc.ToolInMagazine[1].CamData.SpindleSpeed);
				global::_0088._007E_001F_0006(btn_toolmag1, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[1].Geometry.GeometryType)));
				global::_008B._007E_0088_0006(this._0001, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107391362), buMarbleCalc.ToolInMagazine[1].Data.Name));
				global::_0095._007E_0008_0008(spn_toolmagdia2, buMarbleCalc.ToolInMagazine[2].Geometry.Diameter);
				global::_0095._007E_0008_0008(spn_toolmaglen2, buMarbleCalc.ToolInMagazine[2].Geometry.Length);
				global::_0095._007E_0008_0008(spn_toolmagapeed2, buMarbleCalc.ToolInMagazine[2].CamData.SpindleSpeed);
				global::_0088._007E_001F_0006(btn_toolmag2, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[2].Geometry.GeometryType)));
				global::_008B._007E_0088_0006(_000F, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107391089), buMarbleCalc.ToolInMagazine[2].Data.Name));
				global::_0095._007E_0008_0008(spn_toolmagdia3, buMarbleCalc.ToolInMagazine[3].Geometry.Diameter);
				global::_0095._007E_0008_0008(spn_toolmaglen3, buMarbleCalc.ToolInMagazine[3].Geometry.Length);
				global::_0095._007E_0008_0008(spn_toolmagapeed3, buMarbleCalc.ToolInMagazine[3].CamData.SpindleSpeed);
				global::_0088._007E_001F_0006(btn_toolmag3, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[3].Geometry.GeometryType)));
				global::_008B._007E_0088_0006(_000E, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107391264), buMarbleCalc.ToolInMagazine[3].Data.Name));
				global::_0095._007E_0008_0008(spn_toolmagdia4, buMarbleCalc.ToolInMagazine[4].Geometry.Diameter);
				global::_0095._007E_0008_0008(spn_toolmaglen4, buMarbleCalc.ToolInMagazine[4].Geometry.Length);
				global::_0095._007E_0008_0008(spn_toolmagapeed4, buMarbleCalc.ToolInMagazine[4].CamData.SpindleSpeed);
				global::_0088._007E_001F_0006(btn_toolmag4, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[4].Geometry.GeometryType)));
				global::_008B._007E_0088_0006(_0008, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107392015), buMarbleCalc.ToolInMagazine[4].Data.Name));
				global::_0095._007E_0008_0008(spn_toolmagdia5, buMarbleCalc.ToolInMagazine[5].Geometry.Diameter);
				global::_0095._007E_0008_0008(spn_toolmaglen5, buMarbleCalc.ToolInMagazine[5].Geometry.Length);
				global::_0095._007E_0008_0008(spn_toolmagapeed5, buMarbleCalc.ToolInMagazine[5].CamData.SpindleSpeed);
				goto IL_06e4;
			}
			goto IL_0b0a;
		}
		goto IL_0dcf;
		IL_0dcf:
		LoadLanguage();
		MenuButtonColors(SelectedTab);
		goto IL_0de2;
		IL_0de2:
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		return;
		IL_0b0a:
		global::_008B._007E_0088_0006(_0003, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107393050), buMarbleCalc.ToolInMagazine[9].Data.Name));
		global::_0095._007E_0008_0008(spn_toolmagdia10, buMarbleCalc.ToolInMagazine[10].Geometry.Diameter);
		if (0 == 0)
		{
			global::_0095._007E_0008_0008(spn_toolmaglen10, buMarbleCalc.ToolInMagazine[10].Geometry.Length);
			if (4 == 0)
			{
				goto IL_06e4;
			}
			global::_0095._007E_0008_0008(spn_toolmagapeed10, buMarbleCalc.ToolInMagazine[10].CamData.SpindleSpeed);
			global::_0088._007E_001F_0006(btn_toolmag10, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[10].Geometry.GeometryType)));
			global::_008B._007E_0088_0006(this._0002, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107392739), buMarbleCalc.ToolInMagazine[10].Data.Name));
			if (clsAppMarbleVars.varApp.ToolChangeCount == 5)
			{
				global::_0082._007E_0086_0005(this._0008, false);
				global::_0082._007E_0086_0005(this._0007, false);
				global::_0082._007E_0086_0005(this._0006, false);
				global::_0082._007E_0086_0005(this._0005, false);
				global::_0082._007E_0086_0005(this._0004, false);
			}
			if (clsAppMarbleVars.varApp.ToolChangeCount == 6)
			{
				global::_0082._007E_0086_0005(this._0007, false);
				global::_0082._007E_0086_0005(this._0006, false);
				global::_0082._007E_0086_0005(this._0005, false);
				global::_0082._007E_0086_0005(this._0004, false);
				if (3 == 0)
				{
					goto IL_0dcf;
				}
			}
			if (clsAppMarbleVars.varApp.ToolChangeCount == 7)
			{
				global::_0082._007E_0086_0005(this._0006, false);
				global::_0082._007E_0086_0005(this._0005, false);
				global::_0082._007E_0086_0005(this._0004, false);
			}
			if (clsAppMarbleVars.varApp.ToolChangeCount == 8)
			{
				global::_0082._007E_0086_0005(this._0005, false);
				global::_0082._007E_0086_0005(this._0004, false);
			}
			if (clsAppMarbleVars.varApp.ToolChangeCount == 9)
			{
				global::_0082._007E_0086_0005(this._0004, false);
			}
			goto IL_0dcf;
		}
		goto IL_0de2;
		IL_06e4:
		global::_0088._007E_001F_0006(btn_toolmag5, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[5].Geometry.GeometryType)));
		global::_008B._007E_0088_0006(_0007, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107391710), buMarbleCalc.ToolInMagazine[5].Data.Name));
		global::_0095._007E_0008_0008(spn_toolmagdia6, buMarbleCalc.ToolInMagazine[6].Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_toolmaglen6, buMarbleCalc.ToolInMagazine[6].Geometry.Length);
		global::_0095._007E_0008_0008(spn_toolmagapeed6, buMarbleCalc.ToolInMagazine[6].CamData.SpindleSpeed);
		global::_0088._007E_001F_0006(btn_toolmag6, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[6].Geometry.GeometryType)));
		global::_008B._007E_0088_0006(_0006, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107392397), buMarbleCalc.ToolInMagazine[6].Data.Name));
		global::_0095._007E_0008_0008(spn_toolmagdia7, buMarbleCalc.ToolInMagazine[7].Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_toolmaglen7, buMarbleCalc.ToolInMagazine[7].Geometry.Length);
		global::_0095._007E_0008_0008(spn_toolmagapeed7, buMarbleCalc.ToolInMagazine[7].CamData.SpindleSpeed);
		global::_0088._007E_001F_0006(btn_toolmag7, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[7].Geometry.GeometryType)));
		global::_008B._007E_0088_0006(_0005, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107392124), buMarbleCalc.ToolInMagazine[7].Data.Name));
		global::_0095._007E_0008_0008(spn_toolmagdia8, buMarbleCalc.ToolInMagazine[8].Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_toolmaglen8, buMarbleCalc.ToolInMagazine[8].Geometry.Length);
		global::_0095._007E_0008_0008(spn_toolmagapeed8, buMarbleCalc.ToolInMagazine[8].CamData.SpindleSpeed);
		global::_0088._007E_001F_0006(btn_toolmag8, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[8].Geometry.GeometryType)));
		global::_008B._007E_0088_0006(_0004, global::_0002._0003(F_MarbleToolCurrentAllV2._0002(107392299), buMarbleCalc.ToolInMagazine[8].Data.Name));
		global::_0095._007E_0008_0008(spn_toolmagdia9, buMarbleCalc.ToolInMagazine[9].Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_toolmaglen9, buMarbleCalc.ToolInMagazine[9].Geometry.Length);
		global::_0095._007E_0008_0008(spn_toolmagapeed9, buMarbleCalc.ToolInMagazine[9].CamData.SpindleSpeed);
		global::_0088._007E_001F_0006(btn_toolmag9, global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), ToolTypeToImageIndex(buMarbleCalc.ToolInMagazine[9].Geometry.GeometryType)));
		goto IL_0b0a;
	}

	public void LoadLanguage()
	{
		try
		{
			global::_008B._007E_0088_0006(this._0001, buLangTranslate.preDef.Tools);
			global::_008B._007E_0088_0006(btn_ok, buLangTranslate.preDef.Ok);
			global::_008B._007E_0088_0006(btn_cancel, buLangTranslate.preDef.Cancel);
			global::_008B._007E_0088_0006(btn_sawtool, global::_0014._009F_0003(buLangTranslate.preDef.Saw, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Tool));
			global::_008B._007E_0088_0006(btn_millingtool, global::_0014._009F_0003(buLangTranslate.preDef.Milling, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Tool));
			global::_008B._007E_0088_0006(btn_millingheadtool, global::_0014._009F_0003(buLangTranslate.preDef.MillingHead, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Tool));
			global::_008B._007E_0088_0006(btn_magazine, global::_0014._009F_0003(buLangTranslate.preDef.Tools, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Magazine));
			global::_008B._007E_0088_0006(btn_toolstop, buLangTranslate.preDef.Stop);
			global::_008B._007E_0088_0006(btn_toollist, global::_0014._009F_0003(buLangTranslate.preDef.Tool, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.List));
			global::_008B._007E_0088_0006(btn_saw_settings, buLangTranslate.preDef.Settings);
			global::_008B._007E_0088_0006(btn_milling_settings, buLangTranslate.preDef.Settings);
			global::_008B._007E_0088_0006(btn_milling_edit, buLangTranslate.preDef.Settings);
			global::_008B._007E_0088_0006(btn_millinghead_settings, buLangTranslate.preDef.Settings);
			global::_008B._007E_0088_0006(btn_millinghead_edit, buLangTranslate.preDef.Settings);
			global::_008B._007E_0088_0006(tabPage_saw, buLangTranslate.preDef.Saw);
			global::_008B._007E_0088_0006(tabPage_mlling, buLangTranslate.preDef.Milling);
			global::_008B._007E_0088_0006(this._0001, buLangTranslate.preDef.MillingHead);
			global::_008B._007E_0088_0006(btn_sawgonyele, buLangTranslate.preDef.Perpendicular);
			global::_008B._007E_0088_0006(btn_sawlimitdisable, global::_0014._009F_0003(buLangTranslate.preDef.Limit, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Disable));
			global::_008B._007E_0088_0006(btn_saw_activate, global::_0014._009F_0003(buLangTranslate.preDef.Saw, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Activate));
			global::_008B._007E_0088_0006(btn_saw_measure, global::_0014._009F_0003(buLangTranslate.preDef.Saw, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Measure));
			global::_008B._007E_0088_0006(btn_saw_zeroposition, global::_0014._009F_0003(buLangTranslate.preDef.Saw, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Zero));
			global::_008B._007E_0088_0006(btn_milling_limitdisable, global::_0014._009F_0003(buLangTranslate.preDef.Limit, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Disable));
			global::_008B._007E_0088_0006(btn_milling_activate, global::_0014._009F_0003(buLangTranslate.preDef.Milling, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Activate));
			global::_008B._007E_0088_0006(btn_milling_measure, global::_0014._009F_0003(buLangTranslate.preDef.Milling, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Measure));
			global::_008B._007E_0088_0006(btn_milling_zeroposition, global::_0014._009F_0003(buLangTranslate.preDef.Milling, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Zero));
			global::_008B._007E_0088_0006(btn_millinghead_limitdisable, global::_0014._009F_0003(buLangTranslate.preDef.Limit, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Disable));
			global::_008B._007E_0088_0006(btn_millinghead_activate, global::_0014._009F_0003(buLangTranslate.preDef.MillingHead, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Activate));
			global::_008B._007E_0088_0006(btn_millinghead_measure, global::_0014._009F_0003(buLangTranslate.preDef.MillingHead, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Measure));
			global::_008B._007E_0088_0006(btn_millinghead_zeroposition, global::_0014._009F_0003(buLangTranslate.preDef.MillingHead, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Zero));
			global::_008B._007E_0088_0006(btn_savetools, global::_0014._009F_0003(buLangTranslate.preDef.Tool, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Save));
			global::_008B._007E_0088_0006(btn_opentools, global::_0014._009F_0003(buLangTranslate.preDef.Tool, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Open));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawdia), global::_0014._009F_0003(buLangTranslate.preDef.Saw, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Diameter));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawthickness), global::_0014._009F_0003(buLangTranslate.preDef.Saw, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Thickness));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_sawspeed), global::_0014._009F_0003(buLangTranslate.preDef.Saw, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Speed));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_milling_diameter), global::_0014._009F_0003(buLangTranslate.preDef.Milling, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Diameter));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_milling_length), global::_0014._009F_0003(buLangTranslate.preDef.Milling, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Length));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_milling_speed), global::_0014._009F_0003(buLangTranslate.preDef.Milling, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Speed));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_millinghead_diameter), global::_0014._009F_0003(buLangTranslate.preDef.MillingHead, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Diameter));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_millinghead_length), global::_0014._009F_0003(buLangTranslate.preDef.MillingHead, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Length));
			global::_008B._007E_0089_0006(global::_0096._007E_0012_0008(spn_millinghead_speed), global::_0014._009F_0003(buLangTranslate.preDef.MillingHead, F_MarbleToolCurrentAllV2._0002(107396367), buLangTranslate.preDef.Speed));
		}
		catch (Exception)
		{
		}
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
				global::_0082._007E_009C_0005(P_1, true);
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
				global::_0011._001D_0003(this);
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
				global::_0082._0086_0005(this, false);
			}
			break;
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			buSpin buSpin2 = default(buSpin);
			bool touchPad;
			if (0 == 0)
			{
				buSpin obj = P_0 as buSpin;
				if (0 == 0)
				{
					buSpin2 = obj;
				}
				touchPad = AppBool.TouchPad;
			}
			if (6 == 0)
			{
				return;
			}
			bool num = touchPad;
			F_KeyPadNumV1 f_KeyPadNumV;
			if (0 == 0)
			{
				if (!num)
				{
					return;
				}
				f_KeyPadNumV = new F_KeyPadNumV1();
				global::_009C._007E_001A_0008(f_KeyPadNumV, FormStartPosition.CenterParent);
				f_KeyPadNumV.Caption = global::_0005._007E_008A(global::_0096._007E_0012_0008(buSpin2));
				if (0 == 0)
				{
					global::_008B._007E_009B_0006(f_KeyPadNumV, global::_0007._007E_0094(buSpin2).ToString());
					num = _0007_0005._001D_0011(f_KeyPadNumV.Value);
					goto IL_00a0;
				}
				goto IL_00a2;
			}
			goto IL_00a4;
			IL_00a4:
			if (0 == 0)
			{
				if (num)
				{
					global::_0095._007E_0008_0008(buSpin2, _0008_0005._007F_0011(f_KeyPadNumV.Value));
				}
				return;
			}
			goto IL_00a0;
			IL_00a2:
			bool flag;
			num = flag;
			goto IL_00a4;
			IL_00a0:
			flag = num;
			goto IL_00a2;
		}
		catch (Exception ee)
		{
			int id = -1;
			string message = F_MarbleToolCurrentAllV2._0002(107397750);
			do
			{
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, global::_0005._007E_0080(_0019_0003._000E_000F()), message, F_MarbleToolCurrentAllV2._0002(107372545), F_MarbleToolCurrentAllV2._0002(107397750), F_MarbleToolCurrentAllV2._0002(107397750), id, ee);
				_009E_0004._0014_0011(calculationErrorEventArg, true);
			}
			while (false);
		}
	}

	public void Apply()
	{
		buMarbleCalc.activeToolMilling.Geometry.Diameter = global::_0007._007E_0094(spn_milling_diameter);
		buMarbleCalc.activeToolMilling.Geometry.Length = global::_0007._007E_0094(spn_milling_length);
		buMarbleCalc.activeToolMilling.CamData.SpindleSpeed = global::_0007._007E_0094(spn_milling_speed);
		buMarbleCalc.activeToolSaw.Geometry.Diameter = global::_0007._007E_0094(spn_sawdia);
		buMarbleCalc.activeToolSaw.Geometry.Thickness = global::_0007._007E_0094(spn_sawthickness);
		buMarbleCalc.activeToolSaw.CamData.SpindleSpeed = global::_0007._007E_0094(spn_sawspeed);
		buMarbleCalc.activeToolSaw.Geometry.SocketThickness = global::_0007._007E_0094(spn_sawsocket);
		buMarbleCalc.activeToolMillingHead.Geometry.Diameter = global::_0007._007E_0094(spn_millinghead_diameter);
		buMarbleCalc.activeToolMillingHead.Geometry.Length = global::_0007._007E_0094(spn_millinghead_length);
		buMarbleCalc.activeToolMillingHead.CamData.SpindleSpeed = global::_0007._007E_0094(spn_millinghead_speed);
		if ((clsAppMarbleVars.varApp.ToolChangeCount > 0) & (buMarbleCalc.ToolInMagazine != null))
		{
			buMarbleCalc.ToolInMagazine[1].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia1);
			buMarbleCalc.ToolInMagazine[1].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen1);
			buMarbleCalc.ToolInMagazine[1].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed1);
			buMarbleCalc.ToolInMagazine[1].Data.No = 1;
			buMarbleCalc.ToolInMagazine[2].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia2);
			buMarbleCalc.ToolInMagazine[2].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen2);
			buMarbleCalc.ToolInMagazine[2].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed2);
			buMarbleCalc.ToolInMagazine[2].Data.No = 2;
			buMarbleCalc.ToolInMagazine[3].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia3);
			buMarbleCalc.ToolInMagazine[3].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen3);
			buMarbleCalc.ToolInMagazine[3].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed3);
			buMarbleCalc.ToolInMagazine[3].Data.No = 3;
			buMarbleCalc.ToolInMagazine[4].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia4);
			buMarbleCalc.ToolInMagazine[4].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen4);
			buMarbleCalc.ToolInMagazine[4].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed4);
			buMarbleCalc.ToolInMagazine[4].Data.No = 4;
			buMarbleCalc.ToolInMagazine[5].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia5);
			buMarbleCalc.ToolInMagazine[5].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen5);
			buMarbleCalc.ToolInMagazine[5].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed5);
			buMarbleCalc.ToolInMagazine[5].Data.No = 5;
			buMarbleCalc.ToolInMagazine[6].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia6);
			buMarbleCalc.ToolInMagazine[6].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen6);
			buMarbleCalc.ToolInMagazine[6].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed6);
			buMarbleCalc.ToolInMagazine[6].Data.No = 6;
			buMarbleCalc.ToolInMagazine[7].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia7);
			buMarbleCalc.ToolInMagazine[7].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen7);
			buMarbleCalc.ToolInMagazine[7].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed7);
			buMarbleCalc.ToolInMagazine[7].Data.No = 7;
			buMarbleCalc.ToolInMagazine[8].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia8);
			buMarbleCalc.ToolInMagazine[8].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen8);
			buMarbleCalc.ToolInMagazine[8].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed8);
			buMarbleCalc.ToolInMagazine[8].Data.No = 8;
			buMarbleCalc.ToolInMagazine[9].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia9);
			buMarbleCalc.ToolInMagazine[9].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen9);
			buMarbleCalc.ToolInMagazine[9].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed9);
			buMarbleCalc.ToolInMagazine[9].Data.No = 9;
			buMarbleCalc.ToolInMagazine[10].Geometry.Diameter = global::_0007._007E_0094(spn_toolmagdia10);
			buMarbleCalc.ToolInMagazine[10].Geometry.Length = global::_0007._007E_0094(spn_toolmaglen10);
			buMarbleCalc.ToolInMagazine[10].CamData.SpindleSpeed = global::_0007._007E_0094(spn_toolmagapeed10);
			buMarbleCalc.ToolInMagazine[10].Data.No = 10;
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(this._0001);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		if (PageIndex == 0)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawtool)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_sawtool)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			if (6 == 0)
			{
				goto IL_0157;
			}
		}
		if (PageIndex == 1)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingtool)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingtool)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		bool flag = default(bool);
		if (7u != 0)
		{
			flag = PageIndex == 2;
		}
		goto IL_0157;
		IL_0157:
		if (flag)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheadtool)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_millingheadtool)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 3)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_magazine)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_magazine)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		SelectedTab = PageIndex;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		Control control = P_0 as Control;
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_closecross)))
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001D_0003(this);
				if (false)
				{
					goto IL_0151;
				}
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				global::_0082._0086_0005(this, false);
			}
		}
		goto IL_00c0;
		IL_0562:
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millinghead_edit)))
		{
			DialogResult dialogResult = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: false, ref buMarbleCalc.activeToolMillingHead);
			if (dialogResult == DialogResult.OK)
			{
				goto IL_05af;
			}
		}
		goto IL_0611;
		IL_04d8:
		bool num;
		bool flag = (byte)num != 0;
		bool num2 = flag;
		goto IL_04dc;
		IL_05af:
		global::_0095._007E_0008_0008(spn_millinghead_diameter, buMarbleCalc.activeToolMillingHead.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_millinghead_length, buMarbleCalc.activeToolMillingHead.Geometry.Length);
		global::_0095._007E_0008_0008(spn_millinghead_speed, buMarbleCalc.activeToolMillingHead.CamData.SpindleSpeed);
		goto IL_0611;
		IL_04b3:
		num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_milling_edit));
		goto IL_04d8;
		IL_00c0:
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
		{
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				global::_0011._001D_0003(this);
				if (6 == 0)
				{
					goto IL_04ff;
				}
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				global::_0082._0086_0005(this, false);
				if (false)
				{
					goto IL_05af;
				}
			}
		}
		goto IL_0151;
		IL_04dc:
		if (num2)
		{
			DialogResult dialogResult2 = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: false, ref buMarbleCalc.activeToolMilling);
			if (dialogResult2 == DialogResult.OK)
			{
				goto IL_04ff;
			}
		}
		goto IL_0562;
		IL_04ff:
		global::_0095._007E_0008_0008(spn_milling_diameter, buMarbleCalc.activeToolMilling.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_milling_length, buMarbleCalc.activeToolMilling.Geometry.Length);
		global::_0095._007E_0008_0008(spn_milling_speed, buMarbleCalc.activeToolMilling.CamData.SpindleSpeed);
		goto IL_0562;
		IL_0611:
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_saw_settings)))
		{
			clsAppMarbleVars.cmdMarble.ShowMachineSettingsV1(0);
		}
		num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_milling_settings));
		if (1 == 0)
		{
			goto IL_04d8;
		}
		if (num)
		{
			clsAppMarbleVars.cmdMarble.ShowMachineSettingsV1(1);
		}
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millinghead_settings)))
		{
			clsAppMarbleVars.cmdMarble.ShowMachineSettingsV1(2);
		}
		bool flag2 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_sawtool));
		if (false)
		{
			goto IL_00c0;
		}
		if (flag2)
		{
			global::_008D._007E_000F_0007(buTab_tools, 0);
			MenuButtonColors(0);
		}
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingtool)))
		{
			global::_008D._007E_000F_0007(buTab_tools, 1);
			MenuButtonColors(1);
		}
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_millingheadtool)))
		{
			global::_008D._007E_000F_0007(buTab_tools, 2);
			MenuButtonColors(2);
		}
		goto IL_079d;
		IL_032a:
		ToolBase5 toolBase = default(ToolBase5);
		buMarbleCalc.activeToolMillingHead = new ToolBase5(toolBase);
		global::_0095._007E_0008_0008(spn_millinghead_diameter, buMarbleCalc.activeToolMillingHead.Geometry.Diameter);
		global::_0095._007E_0008_0008(spn_millinghead_length, buMarbleCalc.activeToolMillingHead.Geometry.Length);
		global::_0095._007E_0008_0008(spn_millinghead_speed, buMarbleCalc.activeToolMillingHead.CamData.SpindleSpeed);
		goto IL_04b3;
		IL_0151:
		bool flag3 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toollist));
		num2 = flag3;
		if (0 == 0)
		{
			if (num2)
			{
				MarbleToolType toolType = MarbleToolType.Milling;
				if (SelectedTab == 0)
				{
					toolType = MarbleToolType.Saw;
				}
				(int, int, int, MarbleToolType) tuple;
				if (0 == 0)
				{
					tuple = clsAppMarbleVars.cmdMarble.ShowToolsList(buMarbleCalc.varMarbleSettings.ToolListMode, toolType);
					if (SelectedTab == 1 && ((tuple.Item4 == MarbleToolType.Milling) & (tuple.Item2 >= 0)) && buMarbleCalc.ToolMillings != null && tuple.Item2 <= buMarbleCalc.ToolMillings.Count - 1)
					{
						ToolBase5 toolBase2 = buMarbleCalc.ToolMillings[tuple.Item2];
						if (toolBase2.Purpose == ToolPurpose.Milling)
						{
							buMarbleCalc.activeToolMilling = new ToolBase5(toolBase2);
							global::_0095._007E_0008_0008(spn_milling_diameter, buMarbleCalc.activeToolMilling.Geometry.Diameter);
							global::_0095._007E_0008_0008(spn_milling_length, buMarbleCalc.activeToolMilling.Geometry.Length);
							global::_0095._007E_0008_0008(spn_milling_speed, buMarbleCalc.activeToolMilling.CamData.SpindleSpeed);
						}
						if (3 == 0)
						{
							goto IL_079d;
						}
					}
					if (SelectedTab != 2)
					{
						if (1 == 0)
						{
							goto IL_032a;
						}
						if (SelectedTab == 0 && ((tuple.Item4 == MarbleToolType.Saw) & (tuple.Item1 >= 0)) && buMarbleCalc.ToolSaws != null && tuple.Item1 <= buMarbleCalc.ToolSaws.Count - 1)
						{
							ToolBase5 toolBase3 = buMarbleCalc.ToolSaws[tuple.Item1];
							if (toolBase3.Purpose == ToolPurpose.Saw)
							{
								buMarbleCalc.activeToolSaw = new ToolBase5(toolBase3);
								global::_0095._007E_0008_0008(spn_sawdia, buMarbleCalc.activeToolSaw.Geometry.Diameter);
								global::_0095._007E_0008_0008(spn_sawthickness, buMarbleCalc.activeToolSaw.Geometry.Thickness);
								global::_0095._007E_0008_0008(spn_sawsocket, buMarbleCalc.activeToolSaw.Geometry.SocketThickness);
								global::_0095._007E_0008_0008(spn_sawspeed, buMarbleCalc.activeToolSaw.CamData.SpindleSpeed);
							}
						}
						goto IL_04b3;
					}
				}
				if (((tuple.Item4 == MarbleToolType.MillingHead) & (tuple.Item3 >= 0)) && buMarbleCalc.ToolMillingHeads != null && tuple.Item3 <= buMarbleCalc.ToolMillings.Count - 1)
				{
					toolBase = buMarbleCalc.ToolMillingHeads[tuple.Item3];
					if (toolBase.Purpose == ToolPurpose.MillingHead)
					{
						goto IL_032a;
					}
				}
			}
			goto IL_04b3;
		}
		goto IL_04dc;
		IL_079d:
		if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_magazine)))
		{
			global::_008D._007E_000F_0007(buTab_tools, 3);
			MenuButtonColors(3);
		}
	}

	public int ToolTypeToImageIndex(ToolType T)
	{
		if (false)
		{
			goto IL_0064;
		}
		bool flag = T == ToolType.Flat;
		goto IL_00e2;
		IL_00a7:
		int result = 6;
		goto IL_00d4;
		IL_00e2:
		if (flag)
		{
			result = 0;
			goto IL_00d4;
		}
		goto IL_00ee;
		IL_00ee:
		bool flag2;
		if (T != ToolType.Sphere)
		{
			if (T == ToolType.Bullnose)
			{
				goto IL_0050;
			}
			flag2 = T == ToolType.Taper;
			goto IL_0064;
		}
		result = 1;
		goto IL_00d4;
		IL_00c9:
		result = 0;
		if (1 == 0)
		{
			goto IL_00e2;
		}
		goto IL_00d4;
		IL_0050:
		result = 2;
		if (5 == 0)
		{
			goto IL_00c9;
		}
		goto IL_00d4;
		IL_0064:
		if (flag2)
		{
			if (2 == 0)
			{
				goto IL_0050;
			}
			result = 3;
		}
		else if (T == ToolType.Barrel)
		{
			result = 4;
		}
		else
		{
			if (T != ToolType.Chamfer)
			{
				while (0 == 0)
				{
					if (T == ToolType.ConvexTip)
					{
						if (false)
						{
							continue;
						}
						goto IL_00a7;
					}
					goto IL_00ab;
				}
				goto IL_00ee;
			}
			result = 5;
		}
		goto IL_00d4;
		IL_00ab:
		if (T == ToolType.Dove)
		{
			result = 7;
		}
		else
		{
			if (T != ToolType.Lollipop)
			{
				goto IL_00c9;
			}
			result = 8;
		}
		goto IL_00d4;
		IL_00d4:
		return result;
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
			global::_0011._007E_001A_0002(this._0001);
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
		global::_0082._009D_0005(this, disposing);
	}

	static F_MarbleToolCurrentAllV2()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleToolCurrentAllV2));
		Captions = new List<string>();
	}
}
