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
using buEyeBaseVer5.Apps.Marble;

namespace buMarble.Forms;

public class F_MarbleParkList : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public List<Pnt9DS> Parks = new List<Pnt9DS>();

	public int indexPark = -1;

	public int indexMachine = -1;

	public bool ParkSelected = false;

	public bool MachineSelected = false;

	public bool ShowGeneralParks = true;

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal DataGridView _0001;

	internal ImageList _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	public buButton btn_parkgetpos;

	public buButton btn_g54save;

	public buButton btn_g54open;

	public buButton btn_goposition;

	internal buLabel _0001;

	internal DataGridView _0002;

	internal buLabel _0002;

	public buButton btn_stop;

	internal buLabel _0003;

	[NonSerialized]
	internal static GetString _0090;

	public F_MarbleParkList()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		bool num = PropertiesForm.Height > 10;
		bool flag;
		if (8u != 0)
		{
			flag = num;
		}
		if (flag)
		{
			global::_008D obj = global::_008D._008F_0007;
			int num2 = PropertiesForm.Height;
			if (0 == 0)
			{
				obj(this, num2);
			}
		}
		if (PropertiesForm.Width > 10)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.ParkPosition)
		{
			global::_0082._007E_009E_0005(this._0002, true);
		}
		else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.UserParkPosition)
		{
			global::_0082._007E_009E_0005(this._0001, true);
		}
		else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.SafeDistance)
		{
			global::_0082._007E_009E_0005(this._0003, true);
		}
		ParkSelected = false;
		MachineSelected = false;
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(this._0001)) == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn, 35);
			global::_008B._007E_009C_0006(dataGridViewColumn, buLangTranslate.preDef.No);
			global::_008B._007E_009D_0006(dataGridViewColumn, _0090(107450933));
			global::_0082._007E_009F_0005(dataGridViewColumn, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn2, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn2, 60);
			global::_008B._007E_009C_0006(dataGridViewColumn2, buLangTranslate.preDef.Image);
			global::_008B._007E_009D_0006(dataGridViewColumn2, _0090(107450358));
			global::_0082._007E_009F_0005(dataGridViewColumn2, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn2), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn2), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn2, new DataGridViewImageCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn2)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn3, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn3, 240);
			global::_008B._007E_009C_0006(dataGridViewColumn3, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn3, _0090(107387038));
			global::_0082._007E_009F_0005(dataGridViewColumn3, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn3), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn3), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn3, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn3)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn4, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn4, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn4, buLangTranslate.preChar.X);
			global::_008B._007E_009D_0006(dataGridViewColumn4, _0090(107412734));
			global::_0082._007E_009F_0005(dataGridViewColumn4, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn4), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn4), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn4, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn4)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn5, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn5, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn5, buLangTranslate.preChar.Y);
			global::_008B._007E_009D_0006(dataGridViewColumn5, _0090(107412764));
			global::_0082._007E_009F_0005(dataGridViewColumn5, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn5), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn5), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn5, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn5)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn6, DataGridViewColumnSortMode.NotSortable);
			if (6 == 0)
			{
				goto IL_09f2;
			}
			global::_008D._007E_0091_0007(dataGridViewColumn6, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn6, buLangTranslate.preChar.Z);
			global::_008B._007E_009D_0006(dataGridViewColumn6, _0090(107412282));
			global::_0082._007E_009F_0005(dataGridViewColumn6, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn6), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn6), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn6, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn6)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn7, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn7, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn7, buLangTranslate.preChar.C);
			global::_008B._007E_009D_0006(dataGridViewColumn7, _0090(107401863));
			global::_0082._007E_009F_0005(dataGridViewColumn7, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn7), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn7), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn7, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn7)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn8, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn8, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn8, buLangTranslate.preChar.A);
			global::_008B._007E_009D_0006(dataGridViewColumn8, _0090(107401877));
			global::_0082._007E_009F_0005(dataGridViewColumn8, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn8), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn8), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn8, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn8)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn8);
			global::_0087._007E_001E_0006(_0005_0004._007E_0005_0010(this._0001), new Font(_0090(107372283), 12f, FontStyle.Bold));
		}
		global::_0082._007E_0001_0006(this._0001, false);
		global::_0082._007E_0002_0006(this._0001, false);
		global::_0082._007E_0003_0006(this._0001, false);
		global::_0082._007E_0004_0006(this._0001, true);
		goto IL_09f2;
		IL_09f2:
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(this._0002)) == 0)
		{
			DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn9, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn9, 35);
			global::_008B._007E_009C_0006(dataGridViewColumn9, buLangTranslate.preDef.No);
			global::_008B._007E_009D_0006(dataGridViewColumn9, _0090(107450933));
			global::_0082._007E_009F_0005(dataGridViewColumn9, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn9), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn9), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn9, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn9)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn9);
			DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn10, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn10, 60);
			global::_008B._007E_009C_0006(dataGridViewColumn10, buLangTranslate.preDef.Image);
			global::_008B._007E_009D_0006(dataGridViewColumn10, _0090(107450358));
			global::_0082._007E_009F_0005(dataGridViewColumn10, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn10), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn10), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn10, new DataGridViewImageCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn10)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn10);
			DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn11, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn11, 240);
			global::_008B._007E_009C_0006(dataGridViewColumn11, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn11, _0090(107387038));
			global::_0082._007E_009F_0005(dataGridViewColumn11, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn11), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn11), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn11, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn11)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn11);
			DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn12, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn12, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn12, buLangTranslate.preChar.X);
			global::_008B._007E_009D_0006(dataGridViewColumn12, _0090(107412734));
			global::_0082._007E_009F_0005(dataGridViewColumn12, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn12), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn12), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn12, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn12)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn12);
			DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn13, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn13, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn13, buLangTranslate.preChar.Y);
			global::_008B._007E_009D_0006(dataGridViewColumn13, _0090(107412764));
			global::_0082._007E_009F_0005(dataGridViewColumn13, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn13), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn13), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn13, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn13)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn13);
			DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn14, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn14, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn14, buLangTranslate.preChar.Z);
			global::_008B._007E_009D_0006(dataGridViewColumn14, _0090(107412282));
			global::_0082._007E_009F_0005(dataGridViewColumn14, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn14), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn14), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn14, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn14)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn14);
			DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn15, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn15, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn15, buLangTranslate.preChar.C);
			global::_008B._007E_009D_0006(dataGridViewColumn15, _0090(107401863));
			global::_0082._007E_009F_0005(dataGridViewColumn15, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn15), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn15), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn15, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn15)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn15);
			DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn16, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn16, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn16, buLangTranslate.preChar.A);
			global::_008B._007E_009D_0006(dataGridViewColumn16, _0090(107401877));
			global::_0082._007E_009F_0005(dataGridViewColumn16, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn16), new Font(_0090(107372283), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn16), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn16, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn16)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0002), dataGridViewColumn16);
		}
		global::_0082._007E_0001_0006(this._0002, false);
		global::_0082._007E_0002_0006(this._0002, false);
		global::_0082._007E_0003_0006(this._0002, false);
		global::_0082._007E_0004_0006(this._0002, false);
		FillG54();
		indexPark = clsAppMarbleVars.varApp.SelectedParkPosition;
		if ((Parks.Count > 0) & (indexPark == -1))
		{
			indexPark = 0;
		}
		if (ShowGeneralParks)
		{
			global::_008D._008F_0007(this, 914);
			global::_0082._007E_0086_0005(_0002, true);
			global::_0082._007E_0086_0005(this._0002, true);
		}
		else
		{
			global::_008D._008F_0007(this, 655);
			global::_0082._007E_0086_0005(_0002, false);
			global::_0082._007E_0086_0005(this._0002, false);
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		_0005._0003._0001(this);
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
		if (global::_0003._007E_0017(this._0002))
		{
			clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.ParkPosition;
		}
		else if (global::_0003._007E_0017(this._0003))
		{
			clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.SafeDistance;
		}
		else if (0 == 0)
		{
			clsAppMarbleVars.varApp.ParkPositionAfterFinishType = MarbleParkModeAfterJob.UserParkPosition;
		}
		for (int i = 0; i <= Parks.Count - 1; i++)
		{
			Parks[i].X = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 3))));
			Parks[i].Y = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 4))));
			Parks[i].Z = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 5))));
			Parks[i].C = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 6))));
			Parks[i].A = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 7))));
			Parks[i].S = global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 2)));
		}
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 0)), 3))));
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 0)), 4))));
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 0)), 5))));
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 0)), 6))));
		clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 0)), 7))));
		clsAppMarbleVars.varApp.SawModePositionX = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 1)), 3))));
		clsAppMarbleVars.varApp.SawModePositionY = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 1)), 4))));
		clsAppMarbleVars.varApp.SawModePositionZ = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 1)), 5))));
		clsAppMarbleVars.varApp.SawModePositionC = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 1)), 6))));
		clsAppMarbleVars.varApp.SawModePositionA = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 1)), 7))));
		clsAppMarbleVars.varApp.MillingModePositionX = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 2)), 3))));
		clsAppMarbleVars.varApp.MillingModePositionY = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 2)), 4))));
		clsAppMarbleVars.varApp.MillingModePositionZ = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 2)), 5))));
		clsAppMarbleVars.varApp.MillingModePositionC = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 2)), 6))));
		clsAppMarbleVars.varApp.MillingModePositionA = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 2)), 7))));
		clsAppMarbleVars.varApp.MillingHeadModePositionX = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 3)), 3))));
		clsAppMarbleVars.varApp.MillingHeadModePositionY = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 3)), 4))));
		clsAppMarbleVars.varApp.MillingHeadModePositionZ = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 3)), 5))));
		clsAppMarbleVars.varApp.MillingHeadModePositionC = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 3)), 6))));
		clsAppMarbleVars.varApp.MillingHeadModePositionA = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 3)), 7))));
		clsAppMarbleVars.varApp.WagonUpPositionX = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 4)), 3))));
		clsAppMarbleVars.varApp.WagonUpPositionY = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 4)), 4))));
		clsAppMarbleVars.varApp.WagonUpPositionZ = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 4)), 5))));
		clsAppMarbleVars.varApp.WagonUpPositionC = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 4)), 6))));
		clsAppMarbleVars.varApp.WagonUpPositionA = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), 4)), 7))));
	}

	public void FillG54()
	{
		global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0001));
		int num = 0;
		Image image;
		while (true)
		{
			if (num > Parks.Count - 1)
			{
				global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0002));
				image = null;
				image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
				_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0002), _0005._0003._0001(this, 1, image, global::_0014._009F_0003(buLangTranslate.preDef.General, _0090(107396593), buLangTranslate.preDef.Park), clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition));
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1), 38);
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1)), global::_001E._001C_0004());
				break;
			}
			Image image2 = null;
			image2 = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
			_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0001), _0005._0003._0001(this, num + 1, image2, Parks[num].S, Parks[num].X, Parks[num].Y, Parks[num].Z, Parks[num].C, Parks[num].A));
			global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 38);
			if (5 == 0)
			{
				break;
			}
			global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)), global::_001E._001C_0004());
			if (num == clsAppMarbleVars.varApp.SelectedParkPosition)
			{
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)), global::_001E._0087_0004());
			}
			num++;
		}
		image = null;
		image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
		_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0002), _0005._0003._0001(this, 2, image, global::_0013_0002._0090_0008(new string[5]
		{
			buLangTranslate.preDef.Saw,
			_0090(107396593),
			buLangTranslate.preDef.Change,
			_0090(107396593),
			buLangTranslate.preDef.Park
		}), clsAppMarbleVars.varApp.SawModePositionX, clsAppMarbleVars.varApp.SawModePositionY, clsAppMarbleVars.varApp.SawModePositionZ, clsAppMarbleVars.varApp.SawModePositionC, clsAppMarbleVars.varApp.SawModePositionA));
		global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1), 38);
		global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1)), global::_001E._001C_0004());
		image = null;
		image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
		_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0002), _0005._0003._0001(this, 3, image, global::_0013_0002._0090_0008(new string[5]
		{
			buLangTranslate.preDef.Milling,
			_0090(107396593),
			buLangTranslate.preDef.Change,
			_0090(107396593),
			buLangTranslate.preDef.Park
		}), clsAppMarbleVars.varApp.MillingModePositionX, clsAppMarbleVars.varApp.MillingModePositionY, clsAppMarbleVars.varApp.MillingModePositionZ, clsAppMarbleVars.varApp.MillingModePositionC, clsAppMarbleVars.varApp.MillingModePositionA));
		global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1), 38);
		global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1)), global::_001E._001C_0004());
		image = null;
		image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
		_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0002), _0005._0003._0001(this, 4, image, global::_0013_0002._0090_0008(new string[5]
		{
			buLangTranslate.preDef.MillingHead,
			_0090(107396593),
			buLangTranslate.preDef.Change,
			_0090(107396593),
			buLangTranslate.preDef.Park
		}), clsAppMarbleVars.varApp.MillingHeadModePositionX, clsAppMarbleVars.varApp.MillingHeadModePositionY, clsAppMarbleVars.varApp.MillingHeadModePositionZ, clsAppMarbleVars.varApp.MillingHeadModePositionC, clsAppMarbleVars.varApp.MillingHeadModePositionA));
		global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1), 38);
		global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1)), global::_001E._001C_0004());
		image = null;
		image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
		_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0002), _0005._0003._0001(this, 5, image, global::_0014._009F_0003(buLangTranslate.preDef.Table, _0090(107396593), buLangTranslate.preDef.Park), clsAppMarbleVars.varApp.WagonUpPositionX, clsAppMarbleVars.varApp.WagonUpPositionY, clsAppMarbleVars.varApp.WagonUpPositionZ, clsAppMarbleVars.varApp.WagonUpPositionC, clsAppMarbleVars.varApp.WagonUpPositionA));
		global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1), 38);
		global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0002)) - 1)), global::_001E._001C_0004());
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_stop)) && clsAppMarbleVars.cmdMarble != null)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
			{
				clsAppMarbleVars.varApp.SelectedParkPosition = indexPark;
				Apply();
				PropertiesForm.Result = DialogResult.OK;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close)) | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel)))
			{
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_g54open)))
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				global::_008B._007E_0096_0006(openFileDialog, buMarbleCalc.varMarbleRunSettings.pathParks);
				global::_0082._007E_0091_0005(openFileDialog, false);
				global::_008B._007E_0097_0006(openFileDialog, _0090(107450482));
				global::_008D._007E_0089_0007(openFileDialog, 1);
				if (_0008_0004._007E_000E_0010(openFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(global::_0005._007E_0086(openFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathParks = global::_0005._007E_0090(fileInfo);
					ArrayList arrayList = new ArrayList();
					_0084_0005._009A_0011(global::_0005._007E_0019(fileInfo), ref arrayList);
					List<string> list = new List<string>();
					_0087_0005._009C_0011(_0090(107450401), _0090(107449868), false, arrayList, ref list);
					if (list.Count > 0)
					{
						Parks.Clear();
						for (int i = 0; i <= list.Count - 1; i++)
						{
							Pnt9DS item = _0088_0005._009D_0011(list[i]);
							Parks.Add(item);
						}
						FillG54();
					}
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_g54save)))
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				global::_008B._007E_0096_0006(saveFileDialog, buMarbleCalc.varMarbleRunSettings.pathParks);
				global::_008B._007E_0097_0006(saveFileDialog, _0090(107450482));
				global::_008D._007E_0089_0007(saveFileDialog, 1);
				if (_0008_0004._007E_000E_0010(saveFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo2 = new FileInfo(global::_0005._007E_0086(saveFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathParks = global::_0005._007E_0090(fileInfo2);
					ArrayList arrayList2 = new ArrayList();
					_0013_0004._007E_0019_0010(arrayList2, _0090(107455612));
					_0013_0004._007E_0019_0010(arrayList2, _0090(107449875));
					_0013_0004._007E_0019_0010(arrayList2, _0090(107455612));
					_0013_0004._007E_0019_0010(arrayList2, _0090(107450401));
					for (int j = 0; j <= Parks.Count - 1; j++)
					{
						_0013_0004._007E_0019_0010(arrayList2, _0004_0007._007E_0087_0013(Parks[j], 2));
					}
					_0013_0004._007E_0019_0010(arrayList2, _0090(107449868));
					_0012_0005._0086_0011(arrayList2, global::_0005._007E_0086(saveFileDialog));
				}
			}
			double num4;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_goposition)))
			{
				if (AppBool.Connected & (indexPark >= 0) & ParkSelected)
				{
					if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove)
					{
						double num = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 5))));
						_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, num, true);
					}
					_0083_0004._008F_0010(300);
					if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove)
					{
						double num2 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 6))));
						_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar, 0.0, num2, true);
					}
					if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
					{
						double num3 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 7))));
						_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar, 0.0, num3, true);
					}
					_0083_0004._008F_0010(300);
					if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove)
					{
						num4 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 4))));
						goto IL_083d;
					}
					goto IL_087f;
				}
				goto IL_094c;
			}
			goto IL_0d93;
			IL_087f:
			if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove)
			{
				double num5 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 3))));
				_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar, 0.0, num5, true);
			}
			goto IL_094c;
			IL_094c:
			if (AppBool.Connected & (indexMachine >= 0) & MachineSelected)
			{
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num6 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 5))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, num6, true);
				}
				_0083_0004._008F_0010(500);
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num7 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 6))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar, 0.0, num7, true);
				}
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
				{
					num4 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 7))));
					if (6 == 0)
					{
						goto IL_083d;
					}
					double num8 = num4;
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar, 0.0, num8, true);
				}
				_0083_0004._008F_0010(500);
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num9 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 4))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar, 0.0, num9, true);
				}
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num10 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 3))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar, 0.0, num10, true);
				}
			}
			goto IL_0d93;
			IL_0d93:
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_parkgetpos)))
			{
				return;
			}
			if (AppBool.Connected & (indexPark >= 0) & ParkSelected)
			{
				if (clsAppMarbleVars.varRuntime.AxX >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 3), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxY >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 4), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxZ >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 5), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxC >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 6), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxA >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexPark)), 7), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2));
				}
			}
			if (AppBool.Connected & (indexMachine >= 0) & MachineSelected)
			{
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 3), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2).ToString());
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 4), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2).ToString());
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 5), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Actual.actualPosition, 2).ToString());
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 6), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Actual.actualPosition, 2).ToString());
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0002), indexMachine)), 7), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Actual.actualPosition, 2).ToString());
			}
			return;
			IL_083d:
			double num11 = num4;
			_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar, 0.0, num11, true);
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
		do
		{
			if (7u != 0)
			{
				DataGridView dataGridView = P_0 as DataGridView;
				bool num = global::_0001._0001(global::_0005._007E_0084(dataGridView), global::_0005._007E_0084(this._0001));
				do
				{
					bool flag = num;
					num = flag;
				}
				while (false);
				if (num)
				{
					indexPark = global::_000E._007E_0013_0002(P_1);
					if (0 == 0)
					{
						ParkSelected = true;
						if (false)
						{
							continue;
						}
						MachineSelected = false;
					}
				}
				if (!global::_0001._0001(global::_0005._007E_0084(dataGridView), global::_0005._007E_0084(this._0002)))
				{
					continue;
				}
				while (false)
				{
				}
				indexMachine = global::_000E._007E_0013_0002(P_1);
			}
			ParkSelected = false;
			MachineSelected = true;
		}
		while (false);
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

	static F_MarbleParkList()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleParkList));
		Captions = new List<string>();
	}
}
