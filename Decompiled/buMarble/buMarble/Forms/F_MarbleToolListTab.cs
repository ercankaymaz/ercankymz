using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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

public class F_MarbleToolListTab : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public List<ToolBase5> ToolsMilling = new List<ToolBase5>();

	public List<ToolBase5> ToolsMillingHead = new List<ToolBase5>();

	public List<ToolBase5> ToolsSaw = new List<ToolBase5>();

	public MarbleToolType SelectedToolType = MarbleToolType.Milling;

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buLabel _0001;

	internal buLabel _0002;

	internal buLabel _0003;

	public buButton btn_remove;

	public buButton btn_add;

	public buButton btn_edit;

	internal ImageList _0001;

	public Panel pnl_preview;

	public buButton btn_toolsave;

	public buButton btn_toolopen;

	public buButton btn_millingtool;

	public buButton btn_sawtool;

	public buTab buTab_tools;

	public TabPage tabPage_mlling;

	internal DataGridView _0001;

	internal TabPage _0001;

	internal DataGridView _0002;

	public buButton btn_millinghead;

	internal TabPage _0002;

	internal DataGridView _0003;

	[NonSerialized]
	internal static GetString _008D;

	public F_MarbleToolListTab()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D._008F_0007(this, PropertiesForm.Height);
		}
		if (PropertiesForm.Width > 10)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		global::_008C._007E_0002_0007(buTab_tools, new Size(1, 1));
		if (!PropertiesForm.VisualUpdated)
		{
			InitVisual();
		}
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(this._0001)) == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn, 40);
			global::_008B._007E_009C_0006(dataGridViewColumn, buLangTranslate.preDef.No);
			global::_008B._007E_009D_0006(dataGridViewColumn, _008D(107451276));
			global::_0082._007E_009F_0005(dataGridViewColumn, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn2, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn2, 60);
			global::_008B._007E_009C_0006(dataGridViewColumn2, buLangTranslate.preDef.Image);
			global::_008B._007E_009D_0006(dataGridViewColumn2, _008D(107450701));
			global::_0082._007E_009F_0005(dataGridViewColumn2, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn2), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn2), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn2, new DataGridViewImageCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn3, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn3, 120);
			global::_008B._007E_009C_0006(dataGridViewColumn3, buLangTranslate.preDef.Type);
			global::_008B._007E_009D_0006(dataGridViewColumn3, _008D(107450048));
			global::_0082._007E_009F_0005(dataGridViewColumn3, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn3), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn3), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn3, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn4, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn4, 220);
			global::_008B._007E_009C_0006(dataGridViewColumn4, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn4, _008D(107387381));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn4), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn4), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn4, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn5, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn5, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn5, buLangTranslate.preDef.Diameter);
			global::_008B._007E_009D_0006(dataGridViewColumn5, _008D(107395533));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn5), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn5), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn5, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn6, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn6, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn6, buLangTranslate.preDef.Length);
			global::_008B._007E_009D_0006(dataGridViewColumn6, _008D(107394318));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn6), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn6), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn6, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn7, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn7, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn7, buLangTranslate.preDef.Speed);
			global::_008B._007E_009D_0006(dataGridViewColumn7, _008D(107395597));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn7), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn7), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn7, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn7);
			global::_0087._007E_001E_0006(_0005_0004._007E_0005_0010(this._0001), new Font(_008D(107372626), 12f, FontStyle.Bold));
		}
		global::_0082._007E_0001_0006(this._0001, false);
		global::_0082._007E_0002_0006(this._0001, false);
		global::_0082._007E_0003_0006(this._0001, false);
		global::_0082._007E_0004_0006(this._0001, true);
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(this._0002)) == 0)
		{
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn8, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn8, 40);
			global::_008B._007E_009C_0006(dataGridViewColumn8, buLangTranslate.preDef.No);
			global::_008B._007E_009D_0006(dataGridViewColumn8, _008D(107451276));
			global::_0082._007E_009F_0005(dataGridViewColumn8, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn8), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn8), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn8, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn8);
			DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn9, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn9, 60);
			global::_008B._007E_009C_0006(dataGridViewColumn9, buLangTranslate.preDef.Image);
			global::_008B._007E_009D_0006(dataGridViewColumn9, _008D(107450701));
			global::_0082._007E_009F_0005(dataGridViewColumn9, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn9), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn9), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn9, new DataGridViewImageCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn9);
			DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn10, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn10, 220);
			global::_008B._007E_009C_0006(dataGridViewColumn10, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn10, _008D(107387381));
			global::_0082._007E_009F_0005(dataGridViewColumn10, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn10), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn10), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn10, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn10);
			DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn11, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn11, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn11, buLangTranslate.preDef.Diameter);
			global::_008B._007E_009D_0006(dataGridViewColumn11, _008D(107395533));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn11), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn11), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn11, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn11);
			DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn12, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn12, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn12, buLangTranslate.preDef.Thickness);
			global::_008B._007E_009D_0006(dataGridViewColumn12, _008D(107395571));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn12), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn12), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn12, new DataGridViewTextBoxCell());
			if (false)
			{
				goto IL_13d1;
			}
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn12);
			DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn13, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn13, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn13, buLangTranslate.preDef.Socket);
			global::_008B._007E_009D_0006(dataGridViewColumn13, _008D(107396117));
			global::_0082._007E_009F_0005(dataGridViewColumn13, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn13), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn13), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn13, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn13);
			DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn14, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn14, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn14, buLangTranslate.preDef.Speed);
			global::_008B._007E_009D_0006(dataGridViewColumn14, _008D(107395597));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn14), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn14), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn14, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn14);
			global::_0087._007E_001E_0006(_0005_0004._007E_0005_0010(this._0002), new Font(_008D(107372626), 12f, FontStyle.Bold));
		}
		global::_0082._007E_0001_0006(this._0002, false);
		global::_0082._007E_0002_0006(this._0002, false);
		global::_0082._007E_0004_0006(this._0002, true);
		global::_0082._007E_0003_0006(this._0002, false);
		DataGridViewColumn dataGridViewColumn21;
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(_0003)) == 0)
		{
			DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn15, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn15, 40);
			global::_008B._007E_009C_0006(dataGridViewColumn15, buLangTranslate.preDef.No);
			global::_008B._007E_009D_0006(dataGridViewColumn15, _008D(107451276));
			global::_0082._007E_009F_0005(dataGridViewColumn15, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn15), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn15), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn15, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(_0003), dataGridViewColumn15);
			DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn16, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn16, 60);
			global::_008B._007E_009C_0006(dataGridViewColumn16, buLangTranslate.preDef.Image);
			global::_008B._007E_009D_0006(dataGridViewColumn16, _008D(107450701));
			global::_0082._007E_009F_0005(dataGridViewColumn16, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn16), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn16), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn16, new DataGridViewImageCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(_0003), dataGridViewColumn16);
			DataGridViewColumn dataGridViewColumn17 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn17, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn17, 120);
			global::_008B._007E_009C_0006(dataGridViewColumn17, buLangTranslate.preDef.Type);
			global::_008B._007E_009D_0006(dataGridViewColumn17, _008D(107450048));
			global::_0082._007E_009F_0005(dataGridViewColumn17, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn17), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn17), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn17, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(_0003), dataGridViewColumn17);
			DataGridViewColumn dataGridViewColumn18 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn18, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn18, 220);
			global::_008B._007E_009C_0006(dataGridViewColumn18, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn18, _008D(107387381));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn18), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn18), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn18, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(_0003), dataGridViewColumn18);
			DataGridViewColumn dataGridViewColumn19 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn19, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn19, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn19, buLangTranslate.preDef.Diameter);
			global::_008B._007E_009D_0006(dataGridViewColumn19, _008D(107395533));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn19), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn19), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn19, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(_0003), dataGridViewColumn19);
			DataGridViewColumn dataGridViewColumn20 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn20, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn20, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn20, buLangTranslate.preDef.Length);
			global::_008B._007E_009D_0006(dataGridViewColumn20, _008D(107394318));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn20), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn20), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn20, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(_0003), dataGridViewColumn20);
			dataGridViewColumn21 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn21, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn21, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn21, buLangTranslate.preDef.Speed);
			global::_008B._007E_009D_0006(dataGridViewColumn21, _008D(107395597));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn21), new Font(_008D(107372626), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn21), DataGridViewContentAlignment.MiddleCenter);
			goto IL_13d1;
		}
		goto IL_1436;
		IL_1436:
		global::_0082._007E_0001_0006(_0003, false);
		global::_0082._007E_0002_0006(_0003, false);
		global::_0082._007E_0003_0006(_0003, false);
		global::_0082._007E_0004_0006(_0003, true);
		FillTools();
		MenuButtonColors(SelectedToolType);
		if ((clsAppMarbleVars.varInterface.IndexToolMilling >= 0) & (clsAppMarbleVars.varInterface.IndexToolMilling <= ToolsMilling.Count - 1) & (SelectedToolType == MarbleToolType.Milling))
		{
			clsAppMarbleVars.cmdMarble.DrawTool(ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling]);
			global::_008B._007E_0088_0006(this._0002, clsAppMarbleVars.cmdMarble.ToolInfo(ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling]));
		}
		if ((clsAppMarbleVars.varInterface.IndexToolSaw >= 0) & (clsAppMarbleVars.varInterface.IndexToolSaw <= ToolsSaw.Count - 1) & (SelectedToolType == MarbleToolType.Saw))
		{
			clsAppMarbleVars.cmdMarble.DrawTool(ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw]);
			global::_008B._007E_0088_0006(this._0002, clsAppMarbleVars.cmdMarble.ToolInfo(ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw]));
		}
		if ((clsAppMarbleVars.varInterface.IndexToolMillingHead >= 0) & (clsAppMarbleVars.varInterface.IndexToolMillingHead <= ToolsMillingHead.Count - 1) & (SelectedToolType == MarbleToolType.MillingHead))
		{
			clsAppMarbleVars.cmdMarble.DrawTool(ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead]);
			global::_008B._007E_0088_0006(this._0002, clsAppMarbleVars.cmdMarble.ToolInfo(ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead]));
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		_0005._0003._0001(this);
		return;
		IL_13d1:
		_0001_0007._007E_0083_0013(dataGridViewColumn21, new DataGridViewTextBoxCell());
		_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(_0003), dataGridViewColumn21);
		global::_0087._007E_001E_0006(_0005_0004._007E_0005_0010(_0003), new Font(_008D(107372626), 12f, FontStyle.Bold));
		goto IL_1436;
	}

	public void InitVisual()
	{
		FileInfo fileInfo2 = default(FileInfo);
		while (true)
		{
			FileInfo fileInfo = new FileInfo(global::_0002._0003(AppPath.MachineSettings, _008D(107373631)));
			if (0 == 0)
			{
				fileInfo2 = fileInfo;
			}
			if (!global::_0003._007E_0004(fileInfo2))
			{
				break;
			}
			Control.ControlCollection controlCollection = null;
			controlCollection = global::_0098._007E_0015_0008(buGround1);
			controlCollection = _0099_0006._001D_0013(controlCollection);
			if (6u != 0)
			{
				controlCollection = global::_0098._007E_0015_0008(this._0001);
				controlCollection = _0099_0006._001D_0013(global::_0098._007E_0015_0008(this._0001));
				controlCollection = global::_0098._007E_0015_0008(tabPage_mlling);
				controlCollection = _0099_0006._001D_0013(controlCollection);
				break;
			}
		}
		PropertiesForm.VisualUpdated = true;
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

	public void Apply()
	{
	}

	public void FillTools()
	{
		global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0002));
		int num = 0;
		double num8 = default(double);
		string text3 = default(string);
		string text4 = default(string);
		while (true)
		{
			string text2;
			double num2;
			double num4;
			Image image;
			int num5;
			int num6;
			if (num <= ToolsSaw.Count - 1)
			{
				image = null;
				string obj = _008D(107398319);
				if (6u != 0)
				{
					string text = obj;
				}
				text2 = _008D(107398319);
				num2 = 0.0;
				double num3 = 0.0;
				num4 = 0.0;
				if (ToolsSaw[num].Purpose == ToolPurpose.Saw)
				{
					image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 10);
					string text = buLangTranslate.preDef.Saw;
					num2 = ToolsSaw[num].Geometry.Diameter;
					num4 = ToolsSaw[num].Geometry.Thickness;
					text2 = ToolsSaw[num].Data.Name;
					goto IL_0117;
				}
				num5 = 32;
				num6 = 32;
				goto IL_0110;
			}
			global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0001));
			int num7 = 0;
			goto IL_0923;
			IL_091c:
			num7++;
			goto IL_0923;
			IL_06e2:
			num8 = ToolsMilling[num7].Geometry.Diameter;
			double num9 = ToolsMilling[num7].Geometry.Length;
			text3 = ToolsMilling[num7].Data.Name;
			goto IL_073d;
			IL_0f7d:
			int num11;
			int num10 = num11;
			goto IL_0f7f;
			IL_073d:
			Image image2;
			_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0001), _0005._0003._0001(num7 + 1, text3, num9, image2, num8, ToolsMilling[num7].CamData.SpindleSpeed, this, text4));
			global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
			global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)), global::_001E._001C_0004());
			if ((num7 >= 0) & (num7 == clsAppMarbleVars.varInterface.IndexToolMilling))
			{
				if (_0098_0004._000E_0011(ToolsMilling[num7].Geometry.Diameter, buMarbleCalc.activeToolMilling.Geometry.Diameter, 0.1) & _0098_0004._000E_0011(ToolsMilling[num7].Geometry.Length, buMarbleCalc.activeToolMilling.Geometry.Length, 0.1))
				{
					goto IL_08b6;
				}
				clsAppMarbleVars.varInterface.IndexToolMilling = -1;
			}
			goto IL_091c;
			IL_0f7f:
			if (num10 > ToolsMillingHead.Count - 1)
			{
				break;
			}
			Image image3 = null;
			string text5 = _008D(107398319);
			string text6 = _008D(107398319);
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			bool num15 = (ToolsMillingHead[num11].Purpose == ToolPurpose.Milling) | (ToolsMillingHead[num11].Purpose == ToolPurpose.MillingHead);
			double num16;
			if (0 == 0)
			{
				if (num15)
				{
					if (2 == 0)
					{
						goto IL_08b6;
					}
					image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
					text5 = buLangTranslate.preDef.Milling;
					if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Flat)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
						text5 = buLangTranslate.preDef.FlatMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Sphere)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 1);
						text5 = buLangTranslate.preDef.SphereMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Bullnose)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 3);
						text5 = buLangTranslate.preDef.BullnoseMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Taper)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 2);
						text5 = buLangTranslate.preDef.TaperMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Dove)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 5);
						text5 = buLangTranslate.preDef.DoveMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Barrel)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 6);
						text5 = buLangTranslate.preDef.BarrelMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Chamfer)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 7);
						text5 = buLangTranslate.preDef.ChamferMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Slot)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 8);
						text5 = buLangTranslate.preDef.SlotMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Grinding)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 9);
						text5 = buLangTranslate.preDef.GrindingMilling;
					}
					else if (ToolsMillingHead[num11].Geometry.GeometryType == ToolType.Lollipop)
					{
						image3 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 4);
						text5 = buLangTranslate.preDef.LollipopMilling;
					}
					num16 = ToolsMillingHead[num11].Geometry.Diameter;
					if (3 == 0)
					{
						goto IL_035b;
					}
					num12 = num16;
					num13 = ToolsMillingHead[num11].Geometry.Length;
					text6 = ToolsMillingHead[num11].Data.Name;
				}
				else
				{
					image3 = new Bitmap(32, 32);
					if (false)
					{
						goto IL_06e2;
					}
				}
				_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(_0003), _0005._0003._0001(text5, this, text6, num12, image3, num11 + 1, num13, ToolsMillingHead[num11].CamData.SpindleSpeed));
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(_0003), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(_0003)) - 1), 40);
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(_0003), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(_0003)) - 1)), global::_001E._001C_0004());
				bool flag = (num11 >= 0) & (num11 == clsAppMarbleVars.varInterface.IndexToolMillingHead);
				num15 = flag;
			}
			if (num15)
			{
				if (_0098_0004._000E_0011(ToolsMillingHead[num11].Geometry.Diameter, buMarbleCalc.activeToolMillingHead.Geometry.Diameter, 0.1) & _0098_0004._000E_0011(ToolsMillingHead[num11].Geometry.Length, buMarbleCalc.activeToolMillingHead.Geometry.Length, 0.1))
				{
					global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(_0003), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(_0003)) - 1)), global::_001E._0087_0004());
				}
				else
				{
					clsAppMarbleVars.varInterface.IndexToolMillingHead = -1;
				}
			}
			num11++;
			goto IL_0f7d;
			IL_08b6:
			global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)), global::_001E._0087_0004());
			goto IL_091c;
			IL_0110:
			image = new Bitmap(num5, num6);
			goto IL_0117;
			IL_0117:
			_0005_0005 obj2 = _0005_0005._007E_001B_0011;
			DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(this._0002);
			double socketThickness = ToolsSaw[num].Geometry.SocketThickness;
			double spindleSpeed = ToolsSaw[num].CamData.SpindleSpeed;
			obj2(dataGridViewRowCollection, _0005._0003._0001(num2, num4, image, this, text2, spindleSpeed, socketThickness, num + 1));
			global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1), 40);
			global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1)), global::_001E._001C_0004());
			num10 = num;
			if (0 == 0)
			{
				num5 = ((num10 < 0) ? 1 : 0);
				num6 = 0;
				if (num6 == 0)
				{
					if ((num5 == num6) & (num == clsAppMarbleVars.varInterface.IndexToolSaw))
					{
						if (_0098_0004._000E_0011(ToolsSaw[num].Geometry.Diameter, buMarbleCalc.activeToolSaw.Geometry.Diameter, 0.1))
						{
							global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1)), global::_001E._0087_0004());
						}
						else
						{
							clsAppMarbleVars.varInterface.IndexToolSaw = -1;
						}
					}
					num++;
					continue;
				}
				goto IL_0110;
			}
			goto IL_0f7f;
			IL_035b:
			num9 = num16;
			double num17 = 0.0;
			if ((ToolsMilling[num7].Purpose == ToolPurpose.Milling) | (ToolsMilling[num7].Purpose == ToolPurpose.MillingHead))
			{
				image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
				text4 = buLangTranslate.preDef.Milling;
				if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Flat)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
					text4 = buLangTranslate.preDef.FlatMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Sphere)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 1);
					text4 = buLangTranslate.preDef.SphereMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Bullnose)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 3);
					text4 = buLangTranslate.preDef.BullnoseMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Taper)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 2);
					text4 = buLangTranslate.preDef.TaperMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Dove)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 5);
					text4 = buLangTranslate.preDef.DoveMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Barrel)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 6);
					text4 = buLangTranslate.preDef.BarrelMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Chamfer)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 7);
					text4 = buLangTranslate.preDef.ChamferMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Slot)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 8);
					text4 = buLangTranslate.preDef.SlotMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Grinding)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 9);
					text4 = buLangTranslate.preDef.GrindingMilling;
				}
				else if (ToolsMilling[num7].Geometry.GeometryType == ToolType.Lollipop)
				{
					image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 4);
					text4 = buLangTranslate.preDef.LollipopMilling;
				}
				goto IL_06e2;
			}
			image2 = new Bitmap(32, 32);
			goto IL_073d;
			IL_0923:
			if (num7 <= ToolsMilling.Count - 1)
			{
				image2 = null;
				text4 = _008D(107398319);
				text3 = _008D(107398319);
				num8 = 0.0;
				num16 = 0.0;
				goto IL_035b;
			}
			global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(_0003));
			num11 = 0;
			goto IL_0f7d;
		}
	}

	public void MenuButtonColors(MarbleToolType PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		if (PageIndex == MarbleToolType.Saw)
		{
			btn_sawtool = _009D_0006._0080_0013(btn_sawtool, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_008D._007E_000F_0007(buTab_tools, 0);
		}
		if (PageIndex == MarbleToolType.Milling)
		{
			btn_millingtool = _009D_0006._0080_0013(btn_millingtool, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_008D._007E_000F_0007(buTab_tools, 1);
		}
		if (PageIndex == MarbleToolType.MillingHead)
		{
			btn_millinghead = _009D_0006._0080_0013(btn_millinghead, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_008D._007E_000F_0007(buTab_tools, 2);
		}
		SelectedToolType = PageIndex;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok));
			bool flag;
			if (8u != 0)
			{
				flag = num;
			}
			bool num2;
			if (flag)
			{
				Apply();
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				bool flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
				num2 = flag2;
				if (false)
				{
					goto IL_0170;
				}
				if (num2)
				{
					global::_0082._0086_0005(this, false);
				}
			}
			bool flag3 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel));
			goto IL_0110;
			IL_04c5:
			int num3;
			int num4;
			ArrayList arrayList = default(ArrayList);
			int num5 = default(int);
			if (num3 <= num4)
			{
				_0011_0005._007E_0083_0011(arrayList, _0090_0005._007E_0006_0012(ToolsMilling[num5], _008D(107398319), 4, SerilizationMode5.MultiLine));
				if (0 == 0)
				{
					num5++;
					goto IL_04b6;
				}
				goto IL_06ce;
			}
			SaveFileDialog saveFileDialog = default(SaveFileDialog);
			_0012_0005._0086_0011(arrayList, global::_0005._007E_0086(saveFileDialog));
			goto IL_04eb;
			IL_0182:
			OpenFileDialog openFileDialog;
			if (0 == 0)
			{
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolopen)))
				{
					openFileDialog = new OpenFileDialog();
					goto IL_01be;
				}
				goto IL_0354;
			}
			goto IL_07f9;
			IL_01be:
			global::_008B._007E_0096_0006(openFileDialog, buMarbleCalc.varMarbleRunSettings.pathTools);
			global::_0082._007E_0091_0005(openFileDialog, false);
			global::_008B._007E_0097_0006(openFileDialog, _008D(107450071));
			if (true)
			{
				global::_008D._007E_0089_0007(openFileDialog, 1);
				if (_0008_0004._007E_000E_0010(openFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(global::_0005._007E_0086(openFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathTools = global::_0005._007E_0090(fileInfo);
					ArrayList arrayList2 = new ArrayList();
					_0084_0005._009A_0011(global::_0005._007E_0019(fileInfo), ref arrayList2);
					List<List<string>> list = new List<List<string>>();
					_0089_0005._009E_0011(_008D(107449986), _008D(107450001), true, arrayList2, ref list);
					List<ToolBase5> list2 = new List<ToolBase5>();
					if (list.Count > 0)
					{
						ToolsMilling.Clear();
						for (int i = 0; i <= list.Count - 1; i++)
						{
							ArrayList arrayList3 = new ArrayList();
							_0011_0005._007E_0083_0011(arrayList3, list[i].ToArray());
							ToolBase5 toolBase = new ToolBase5();
							_008A_0005._009F_0011(arrayList3, _008D(107398319), SerilizationMode5.MultiLine, toolBase);
							ToolsMilling.Add(toolBase);
						}
						goto IL_034a;
					}
				}
				goto IL_0354;
			}
			goto IL_087f;
			IL_07f9:
			if (global::_0012._009B_0003(buLangTranslate.preSentences.DoYouWantToDeleteTool) == DialogResult.Yes)
			{
				ToolsMilling.RemoveAt(clsAppMarbleVars.varInterface.IndexToolMilling);
				clsAppMarbleVars.varInterface.IndexToolMilling--;
				if (clsAppMarbleVars.varInterface.IndexToolMilling < 0 && ToolsMilling.Count > 0)
				{
					clsAppMarbleVars.varInterface.IndexToolMilling = 0;
				}
				FillTools();
			}
			goto IL_087f;
			IL_04eb:
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_add)))
			{
				goto IL_07b0;
			}
			if (SelectedToolType == MarbleToolType.Saw)
			{
				if (clsAppMarbleVars.varInterface.IndexToolSaw >= 0)
				{
					ToolBase5 Tool = ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw];
					DialogResult dialogResult = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: true, ref Tool);
					global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
					global::_0099._007E_0016_0008(global::_0098._007E_0015_0008(pnl_preview), buEyeItems.viewportDialogs);
					if (dialogResult == DialogResult.OK)
					{
						ToolsSaw.Add(new ToolBase5(clsAppMarbleItems.frmToolType.Tool));
						FillTools();
					}
				}
				else
				{
					ToolsSaw.Add(new ToolBase5());
				}
			}
			int num6 = ((SelectedToolType == MarbleToolType.Milling) ? 1 : 0);
			if (0 == 0)
			{
				if (num6 != 0)
				{
					if (clsAppMarbleVars.varInterface.IndexToolMilling >= 0)
					{
						ToolBase5 Tool2 = ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling];
						DialogResult dialogResult2 = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: false, ref Tool2);
						global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
						global::_0099._007E_0016_0008(global::_0098._007E_0015_0008(pnl_preview), buEyeItems.viewportDialogs);
						if (dialogResult2 == DialogResult.OK)
						{
							ToolsMilling.Add(new ToolBase5(clsAppMarbleItems.frmToolType.Tool));
							FillTools();
						}
					}
					else
					{
						if (6 == 0)
						{
							goto IL_034a;
						}
						ToolsMilling.Add(new ToolBase5());
					}
				}
				goto IL_06ce;
			}
			goto IL_0980;
			IL_04b6:
			num3 = num5;
			num4 = ToolsMilling.Count - 1;
			goto IL_04c5;
			IL_06ce:
			if (SelectedToolType == MarbleToolType.MillingHead)
			{
				if (clsAppMarbleVars.varInterface.IndexToolMillingHead >= 0)
				{
					ToolBase5 Tool3 = ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead];
					DialogResult dialogResult3 = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: false, ref Tool3);
					global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
					global::_0099._007E_0016_0008(global::_0098._007E_0015_0008(pnl_preview), buEyeItems.viewportDialogs);
					if (dialogResult3 == DialogResult.OK)
					{
						ToolsMillingHead.Add(new ToolBase5(clsAppMarbleItems.frmToolType.Tool));
						FillTools();
					}
				}
				else
				{
					ToolsMillingHead.Add(new ToolBase5());
					if (false)
					{
						goto IL_01be;
					}
					FillTools();
				}
			}
			goto IL_07b0;
			IL_087f:
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_edit)))
			{
				return;
			}
			if (global::_000E._007E_0003_0002(buTab_tools) == 0 && clsAppMarbleVars.varInterface.IndexToolSaw >= 0)
			{
				ToolBase5 Tool4 = ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw];
				DialogResult dialogResult4 = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: true, ref Tool4);
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				global::_0099._007E_0016_0008(global::_0098._007E_0015_0008(pnl_preview), buEyeItems.viewportDialogs);
				if (dialogResult4 == DialogResult.OK)
				{
					ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw] = new ToolBase5(Tool4);
					FillTools();
				}
			}
			num6 = global::_000E._007E_0003_0002(buTab_tools);
			goto IL_0980;
			IL_0110:
			if (flag3)
			{
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				bool flag4 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
				num2 = flag4;
				goto IL_0170;
			}
			goto IL_0182;
			IL_0980:
			if (num6 == 1 && clsAppMarbleVars.varInterface.IndexToolMilling >= 0)
			{
				ToolBase5 Tool5 = ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling];
				DialogResult dialogResult5 = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: false, ref Tool5);
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				global::_0099._007E_0016_0008(global::_0098._007E_0015_0008(pnl_preview), buEyeItems.viewportDialogs);
				if (dialogResult5 == DialogResult.OK)
				{
					ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling] = new ToolBase5(clsAppMarbleItems.frmToolType.Tool);
					FillTools();
				}
			}
			if (global::_000E._007E_0003_0002(buTab_tools) != 2)
			{
				return;
			}
			num3 = ((clsAppMarbleVars.varInterface.IndexToolMillingHead < 0) ? 1 : 0);
			num4 = 0;
			if (num4 == 0)
			{
				if (num3 == num4)
				{
					ToolBase5 Tool6 = ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead];
					DialogResult dialogResult6 = clsAppMarbleVars.cmdMarble.ShowToolsEdit(isSaw: false, ref Tool6);
					global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
					global::_0099._007E_0016_0008(global::_0098._007E_0015_0008(pnl_preview), buEyeItems.viewportDialogs);
					if (dialogResult6 == DialogResult.OK)
					{
						ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead] = new ToolBase5(clsAppMarbleItems.frmToolType.Tool);
						ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead].Purpose = ToolPurpose.MillingHead;
						FillTools();
					}
				}
				return;
			}
			goto IL_04c5;
			IL_0354:
			bool flag5 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolsave));
			if (5 == 0)
			{
				goto IL_0110;
			}
			if (flag5)
			{
				saveFileDialog = new SaveFileDialog();
				global::_008B._007E_0096_0006(saveFileDialog, buMarbleCalc.varMarbleRunSettings.pathTools);
				global::_008B._007E_0097_0006(saveFileDialog, _008D(107450071));
				global::_008D._007E_0089_0007(saveFileDialog, 1);
				if (_0008_0004._007E_000E_0010(saveFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo2 = new FileInfo(global::_0005._007E_0086(saveFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathTools = global::_0005._007E_0090(fileInfo2);
					arrayList = new ArrayList();
					_0013_0004._007E_0019_0010(arrayList, _008D(107455955));
					_0013_0004._007E_0019_0010(arrayList, _008D(107450464));
					_0013_0004._007E_0019_0010(arrayList, _008D(107455955));
					num5 = 0;
					goto IL_04b6;
				}
			}
			goto IL_04eb;
			IL_034a:
			FillTools();
			goto IL_0354;
			IL_0170:
			if (num2)
			{
				global::_0082._0086_0005(this, false);
			}
			goto IL_0182;
			IL_07b0:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_remove)) && clsAppMarbleVars.varInterface.IndexToolMilling >= 0)
			{
				goto IL_07f9;
			}
			goto IL_087f;
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0001(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (SelectedToolType == MarbleToolType.Saw)
		{
			clsAppMarbleVars.varInterface.IndexToolSaw = global::_000E._007E_0013_0002(P_1);
			if (clsAppMarbleVars.varInterface.IndexToolSaw < 0)
			{
				return;
			}
			if (((global::_000E._007E_0015_0002(P_1) == 3) | (global::_000E._007E_0015_0002(P_1) == 4) | (global::_000E._007E_0015_0002(P_1) == 5) | (global::_000E._007E_0015_0002(P_1) == 6)) && AppBool.TouchPad)
			{
				F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
				global::_009C._007E_001A_0008(f_KeyPadNumV, FormStartPosition.CenterParent);
				f_KeyPadNumV.Caption = global::_0005._007E_0091(_000F_0007._007E_008D_0013(_009E_0006._007E_0081_0013(this._0002), global::_000E._007E_0015_0002(P_1)));
				global::_008B._007E_009B_0006(f_KeyPadNumV, global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)))));
				if (_0007_0005._001D_0011(f_KeyPadNumV.Value))
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)), _0008_0005._007F_0011(f_KeyPadNumV.Value));
					if (global::_000E._007E_0015_0002(P_1) == 3)
					{
						ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw].Geometry.Diameter = _0008_0005._007F_0011(f_KeyPadNumV.Value);
					}
					if (global::_000E._007E_0015_0002(P_1) == 4)
					{
						ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw].Geometry.Thickness = _0008_0005._007F_0011(f_KeyPadNumV.Value);
					}
					if (global::_000E._007E_0015_0002(P_1) == 5)
					{
						ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw].Geometry.SocketThickness = _0008_0005._007F_0011(f_KeyPadNumV.Value);
					}
					if (global::_000E._007E_0015_0002(P_1) == 6)
					{
						ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw].CamData.SpindleSpeed = _0008_0005._007F_0011(f_KeyPadNumV.Value);
					}
				}
			}
			if (global::_000E._007E_0015_0002(P_1) == 2 && AppBool.TouchPad)
			{
				F_KeyPadCharV1 f_KeyPadCharV = new F_KeyPadCharV1();
				global::_009C._007E_001A_0008(f_KeyPadCharV, FormStartPosition.CenterParent);
				f_KeyPadCharV.Caption = global::_0005._007E_0091(_000F_0007._007E_008D_0013(_009E_0006._007E_0081_0013(this._0002), global::_000E._007E_0015_0002(P_1)));
				global::_008B._007E_009E_0006(f_KeyPadCharV, global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)))));
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)), f_KeyPadCharV.Value);
				if (global::_000E._007E_0015_0002(P_1) == 2)
				{
					ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw].Data.Name = f_KeyPadCharV.Value;
				}
			}
			clsAppMarbleVars.cmdMarble.DrawTool(ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw]);
			global::_008B._007E_0088_0006(this._0002, clsAppMarbleVars.cmdMarble.ToolInfo(ToolsSaw[clsAppMarbleVars.varInterface.IndexToolSaw]));
		}
		else if (SelectedToolType == MarbleToolType.Milling)
		{
			clsAppMarbleVars.varInterface.IndexToolMilling = global::_000E._007E_0013_0002(P_1);
			if (clsAppMarbleVars.varInterface.IndexToolMilling < 0)
			{
				return;
			}
			if (((global::_000E._007E_0015_0002(P_1) == 4) | (global::_000E._007E_0015_0002(P_1) == 5) | (global::_000E._007E_0015_0002(P_1) == 6)) && AppBool.TouchPad)
			{
				F_KeyPadNumV1 f_KeyPadNumV2 = new F_KeyPadNumV1();
				global::_009C._007E_001A_0008(f_KeyPadNumV2, FormStartPosition.CenterParent);
				f_KeyPadNumV2.Caption = global::_0005._007E_0091(_000F_0007._007E_008D_0013(_009E_0006._007E_0081_0013(this._0001), global::_000E._007E_0015_0002(P_1)));
				global::_008B._007E_009B_0006(f_KeyPadNumV2, global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)))));
				if (_0007_0005._001D_0011(f_KeyPadNumV2.Value))
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)), _0008_0005._007F_0011(f_KeyPadNumV2.Value));
					if (global::_000E._007E_0015_0002(P_1) == 4)
					{
						ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling].Geometry.Diameter = _0008_0005._007F_0011(f_KeyPadNumV2.Value);
					}
					if (global::_000E._007E_0015_0002(P_1) == 5)
					{
						ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling].Geometry.Length = _0008_0005._007F_0011(f_KeyPadNumV2.Value);
					}
					if (global::_000E._007E_0015_0002(P_1) == 6)
					{
						ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling].CamData.SpindleSpeed = _0008_0005._007F_0011(f_KeyPadNumV2.Value);
					}
				}
			}
			if (global::_000E._007E_0015_0002(P_1) == 3 && AppBool.TouchPad)
			{
				F_KeyPadCharV1 f_KeyPadCharV2 = new F_KeyPadCharV1();
				global::_009C._007E_001A_0008(f_KeyPadCharV2, FormStartPosition.CenterParent);
				f_KeyPadCharV2.Caption = global::_0005._007E_0091(_000F_0007._007E_008D_0013(_009E_0006._007E_0081_0013(this._0001), global::_000E._007E_0015_0002(P_1)));
				global::_008B._007E_009E_0006(f_KeyPadCharV2, global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)))));
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)), f_KeyPadCharV2.Value);
				if (global::_000E._007E_0015_0002(P_1) == 3)
				{
					ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling].Data.Name = f_KeyPadCharV2.Value;
				}
			}
			clsAppMarbleVars.cmdMarble.DrawTool(ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling]);
			global::_008B._007E_0088_0006(this._0002, clsAppMarbleVars.cmdMarble.ToolInfo(ToolsMilling[clsAppMarbleVars.varInterface.IndexToolMilling]));
		}
		else
		{
			if (SelectedToolType != MarbleToolType.MillingHead)
			{
				return;
			}
			clsAppMarbleVars.varInterface.IndexToolMillingHead = global::_000E._007E_0013_0002(P_1);
			if (clsAppMarbleVars.varInterface.IndexToolMillingHead < 0)
			{
				return;
			}
			if (((global::_000E._007E_0015_0002(P_1) == 4) | (global::_000E._007E_0015_0002(P_1) == 5) | (global::_000E._007E_0015_0002(P_1) == 6)) && AppBool.TouchPad)
			{
				F_KeyPadNumV1 f_KeyPadNumV3 = new F_KeyPadNumV1();
				global::_009C._007E_001A_0008(f_KeyPadNumV3, FormStartPosition.CenterParent);
				f_KeyPadNumV3.Caption = global::_0005._007E_0091(_000F_0007._007E_008D_0013(_009E_0006._007E_0081_0013(_0003), global::_000E._007E_0015_0002(P_1)));
				global::_008B._007E_009B_0006(f_KeyPadNumV3, global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(_0003), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)))));
				if (_0007_0005._001D_0011(f_KeyPadNumV3.Value))
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(_0003), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)), _0008_0005._007F_0011(f_KeyPadNumV3.Value));
					if (global::_000E._007E_0015_0002(P_1) == 4)
					{
						ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead].Geometry.Diameter = _0008_0005._007F_0011(f_KeyPadNumV3.Value);
					}
					if (global::_000E._007E_0015_0002(P_1) == 5)
					{
						ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead].Geometry.Length = _0008_0005._007F_0011(f_KeyPadNumV3.Value);
					}
					if (global::_000E._007E_0015_0002(P_1) == 6)
					{
						ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead].CamData.SpindleSpeed = _0008_0005._007F_0011(f_KeyPadNumV3.Value);
					}
				}
			}
			if (global::_000E._007E_0015_0002(P_1) == 3 && AppBool.TouchPad)
			{
				F_KeyPadCharV1 f_KeyPadCharV3 = new F_KeyPadCharV1();
				global::_009C._007E_001A_0008(f_KeyPadCharV3, FormStartPosition.CenterParent);
				f_KeyPadCharV3.Caption = global::_0005._007E_0091(_000F_0007._007E_008D_0013(_009E_0006._007E_0081_0013(_0003), global::_000E._007E_0015_0002(P_1)));
				global::_008B._007E_009E_0006(f_KeyPadCharV3, global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(_0003), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)))));
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(_0003), global::_000E._007E_0013_0002(P_1))), global::_000E._007E_0015_0002(P_1)), f_KeyPadCharV3.Value);
				if (global::_000E._007E_0015_0002(P_1) == 3)
				{
					ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead].Data.Name = f_KeyPadCharV3.Value;
				}
			}
			clsAppMarbleVars.cmdMarble.DrawTool(ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead]);
			global::_008B._007E_0088_0006(this._0002, clsAppMarbleVars.cmdMarble.ToolInfo(ToolsMillingHead[clsAppMarbleVars.varInterface.IndexToolMillingHead]));
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

	static F_MarbleToolListTab()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleToolListTab));
		Captions = new List<string>();
	}
}
