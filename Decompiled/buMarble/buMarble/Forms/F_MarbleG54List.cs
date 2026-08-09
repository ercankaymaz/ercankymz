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

public class F_MarbleG54List : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public List<Pnt9DS> G54s = new List<Pnt9DS>();

	public int indexG54 = -1;

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal DataGridView _0001;

	internal ImageList _0001;

	public buButton btn_g54save;

	public buButton btn_g54open;

	public buButton btn_G54getpos;

	public buButton btn_goposition;

	public buButton btn_stop;

	[NonSerialized]
	internal static GetString _0081;

	public F_MarbleG54List()
	{
		_0005._0003._0001(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			global::_008D obj = global::_008D._008F_0007;
			int num = PropertiesForm.Height;
			if (5u != 0)
			{
				obj(this, num);
			}
		}
		if (PropertiesForm.Width > 10)
		{
			global::_008D._008E_0007(this, PropertiesForm.Width);
		}
		global::_0082._008D_0005(this, PropertiesForm.TopMost);
		global::_009C._001A_0008(this, PropertiesForm.FormPosition);
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(this._0001)) == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn, 35);
			global::_008B._007E_009C_0006(dataGridViewColumn, buLangTranslate.preDef.Number);
			global::_008B._007E_009D_0006(dataGridViewColumn, _0081(107451244));
			global::_0082._007E_009F_0005(dataGridViewColumn, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn2, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn2, 60);
			global::_008B._007E_009C_0006(dataGridViewColumn2, buLangTranslate.preDef.Image);
			global::_008B._007E_009D_0006(dataGridViewColumn2, _0081(107450669));
			global::_0082._007E_009F_0005(dataGridViewColumn2, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn2), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn2), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn2, new DataGridViewImageCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn2)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn3, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn3, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn3, buLangTranslate.preChar.X);
			global::_008B._007E_009D_0006(dataGridViewColumn3, _0081(107413045));
			global::_0082._007E_009F_0005(dataGridViewColumn3, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn3), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn3), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn3, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn3)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn4, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn4, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn4, buLangTranslate.preChar.Y);
			global::_008B._007E_009D_0006(dataGridViewColumn4, _0081(107413075));
			global::_0082._007E_009F_0005(dataGridViewColumn4, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn4), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn4), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn4, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn4)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn5, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn5, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn5, buLangTranslate.preChar.Z);
			global::_008B._007E_009D_0006(dataGridViewColumn5, _0081(107412593));
			global::_0082._007E_009F_0005(dataGridViewColumn5, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn5), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn5), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn5, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn5)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn6, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn6, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn6, buLangTranslate.preChar.C);
			global::_008B._007E_009D_0006(dataGridViewColumn6, _0081(107402174));
			global::_0082._007E_009F_0005(dataGridViewColumn6, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn6), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn6), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn6, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn6)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn6);
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn7, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn7, 90);
			global::_008B._007E_009C_0006(dataGridViewColumn7, buLangTranslate.preChar.A);
			global::_008B._007E_009D_0006(dataGridViewColumn7, _0081(107402188));
			global::_0082._007E_009F_0005(dataGridViewColumn7, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn7), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn7), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn7, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn7)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn8, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn8, 240);
			global::_008B._007E_009C_0006(dataGridViewColumn8, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn8, _0081(107387349));
			global::_0082._007E_009F_0005(dataGridViewColumn8, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn8), new Font(_0081(107372594), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn8), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn8, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn8)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn8);
			global::_0087._007E_001E_0006(_0005_0004._007E_0005_0010(this._0001), new Font(_0081(107372594), 12f, FontStyle.Bold));
		}
		global::_0082._007E_0001_0006(this._0001, false);
		global::_0082._007E_0002_0006(this._0001, false);
		global::_0082._007E_0003_0006(this._0001, false);
		global::_0082._007E_0004_0006(this._0001, true);
		FillG54();
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
		int num = 0;
		while (true)
		{
			bool flag = num <= G54s.Count - 1;
			do
			{
				if (flag)
				{
					G54s[num].X = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 2))));
					G54s[num].Y = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 3))));
					G54s[num].Z = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 4))));
					continue;
				}
				return;
			}
			while (false);
			G54s[num].C = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 5))));
			G54s[num].A = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 6))));
			G54s[num].S = global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 7)));
			num++;
		}
	}

	public void FillG54()
	{
		global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0001));
		if (4 == 0)
		{
			goto IL_0072;
		}
		int num = default(int);
		if (2u != 0)
		{
			num = 0;
		}
		goto IL_0338;
		IL_01e2:
		int num2;
		bool flag = (byte)num2 != 0;
		if (2 == 0)
		{
			goto IL_01d0;
		}
		bool num3;
		if (flag)
		{
			bool flag2 = _000E_0007._008C_0013(G54s[num], G54s[0], 0.1);
			num3 = flag2;
			goto IL_021e;
		}
		goto IL_0287;
		IL_01d0:
		num2 = (((num > 0) & (num == clsAppMarbleVars.varInterface.IndexG54)) ? 1 : 0);
		goto IL_01e2;
		IL_0338:
		num3 = num <= G54s.Count - 1;
		Image image = default(Image);
		string text = default(string);
		bool flag3 = default(bool);
		if (0 == 0)
		{
			if (!num3)
			{
				return;
			}
			image = null;
			image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
			text = G54s[num].S;
			flag3 = num == 0;
			goto IL_0072;
		}
		goto IL_021e;
		IL_0287:
		num2 = num;
		if (false)
		{
			goto IL_01e2;
		}
		if (num2 == 0)
		{
			global::_0082._007E_009F_0005(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), true);
			global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)), global::_001E._001B_0004());
		}
		num++;
		goto IL_0338;
		IL_021e:
		if (num3)
		{
			global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)), global::_001E._0087_0004());
		}
		else
		{
			clsAppMarbleVars.varInterface.IndexG54 = -1;
		}
		goto IL_0287;
		IL_0072:
		if (flag3)
		{
			goto IL_0076;
		}
		goto IL_00a5;
		IL_0076:
		text = global::_0014._009F_0003(buLangTranslate.preDef.Activate, _0081(107450157), buLangTranslate.preDef.Offset);
		goto IL_00a5;
		IL_00a5:
		_0005_0005 obj = _0005_0005._007E_001B_0011;
		DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(this._0001);
		double num4 = G54s[num].X;
		double num5 = G54s[num].Y;
		double z = G54s[num].Z;
		double c = G54s[num].C;
		double a = G54s[num].A;
		obj(dataGridViewRowCollection, _0005._0003._0001(num, num4, image, num5, z, a, c, this, text));
		if (6 == 0)
		{
			goto IL_0076;
		}
		global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
		global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)), global::_001E._001C_0004());
		goto IL_01d0;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_stop)))
			{
				goto IL_004b;
			}
			goto IL_006a;
			IL_004b:
			if (clsAppMarbleVars.cmdMarble != null)
			{
				clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.Stop);
			}
			goto IL_006a;
			IL_0490:
			int num2;
			int num = num2;
			goto IL_0492;
			IL_006a:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
			{
				clsAppMarbleVars.varInterface.IndexG54 = indexG54;
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
			OpenFileDialog openFileDialog;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_g54open)))
			{
				openFileDialog = new OpenFileDialog();
				global::_008B._007E_0096_0006(openFileDialog, buMarbleCalc.varMarbleRunSettings.pathG54);
				global::_0082._007E_0091_0005(openFileDialog, false);
				global::_008B._007E_0097_0006(openFileDialog, _0081(107450116));
				global::_008D._007E_0089_0007(openFileDialog, 1);
				goto IL_0225;
			}
			goto IL_032a;
			IL_032a:
			SaveFileDialog saveFileDialog;
			ArrayList arrayList;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_g54save)))
			{
				saveFileDialog = new SaveFileDialog();
				global::_008B._007E_0096_0006(saveFileDialog, buMarbleCalc.varMarbleRunSettings.pathG54);
				global::_008B._007E_0097_0006(saveFileDialog, _0081(107450116));
				global::_008D._007E_0089_0007(saveFileDialog, 1);
				if (_0008_0004._007E_000E_0010(saveFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(global::_0005._007E_0086(saveFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathG54 = global::_0005._007E_0090(fileInfo);
					arrayList = new ArrayList();
					_0013_0004._007E_0019_0010(arrayList, _0081(107455923));
					_0013_0004._007E_0019_0010(arrayList, _0081(107450069));
					_0013_0004._007E_0019_0010(arrayList, _0081(107455923));
					if (7 == 0)
					{
						goto IL_004b;
					}
					_0013_0004._007E_0019_0010(arrayList, _0081(107450103));
					num = 0;
					goto IL_0492;
				}
			}
			goto IL_04e3;
			IL_0225:
			if (_0008_0004._007E_000E_0010(openFileDialog) == DialogResult.OK)
			{
				FileInfo fileInfo2 = new FileInfo(global::_0005._007E_0086(openFileDialog));
				buMarbleCalc.varMarbleRunSettings.pathG54 = global::_0005._007E_0090(fileInfo2);
				ArrayList arrayList2 = new ArrayList();
				_0084_0005._009A_0011(global::_0005._007E_0019(fileInfo2), ref arrayList2);
				List<string> list = new List<string>();
				_0087_0005._009C_0011(_0081(107450103), _0081(107450054), false, arrayList2, ref list);
				if (list.Count > 0)
				{
					G54s.Clear();
					for (int i = 0; i <= list.Count - 1; i++)
					{
						Pnt9DS item = _0088_0005._009D_0011(list[i]);
						G54s.Add(item);
					}
					FillG54();
				}
			}
			goto IL_032a;
			IL_04e3:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_goposition)) && (AppBool.Connected & (indexG54 >= 0)))
			{
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num3 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 5))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar, 0.0, num3, true);
				}
				_0083_0004._008F_0010(500);
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num4 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 6))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar, 0.0, num4, true);
				}
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num5 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 7))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar, 0.0, num5, true);
				}
				_0083_0004._008F_0010(500);
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num6 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 4))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar, 0.0, num6, true);
				}
				if (clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Bool.bAllowToMove)
				{
					double num7 = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 3))));
					_0011_0004._007E_0017_0010(clsAppMarbleVars.cMachine.Commands, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar, 0.0, num7, true);
				}
				if (false)
				{
					goto IL_0225;
				}
			}
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_G54getpos)) || !(AppBool.Connected & (indexG54 >= 1)))
			{
				return;
			}
			num2 = ((clsAppMarbleVars.varRuntime.AxX < 0) ? 1 : 0);
			if (0 == 0)
			{
				if (num2 == 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 2), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxY >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 3), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
				}
				if (clsAppMarbleVars.varRuntime.AxZ >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 4), global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), 0)), 4)));
				}
				if (clsAppMarbleVars.varRuntime.AxC >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 5), global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), 0)), 5)));
				}
				if (clsAppMarbleVars.varRuntime.AxA >= 0)
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), indexG54)), 6), global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), 0)), 6)));
				}
				return;
			}
			goto IL_0490;
			IL_0492:
			if (num <= G54s.Count - 1)
			{
				_0013_0004._007E_0019_0010(arrayList, _0004_0007._007E_0087_0013(G54s[num], 2));
				num2 = num + 1;
				goto IL_0490;
			}
			_0013_0004._007E_0019_0010(arrayList, _0081(107450054));
			_0012_0005._0086_0011(arrayList, global::_0005._007E_0086(saveFileDialog));
			goto IL_04e3;
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
		if (2 == 0)
		{
			goto IL_002f;
		}
		if (0 == 0)
		{
			indexG54 = global::_000E._007E_0013_0002(P_1);
			goto IL_0040;
		}
		goto IL_0046;
		IL_002f:
		if (false)
		{
			goto IL_0040;
		}
		return;
		IL_0046:
		bool flag;
		if (!flag)
		{
		}
		goto IL_002f;
		IL_0040:
		int num = indexG54;
		int num2 = 0;
		if (num2 == 0)
		{
			num = ((num < num2) ? 1 : 0);
			num2 = 0;
		}
		flag = num == num2;
		goto IL_0046;
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

	static F_MarbleG54List()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleG54List));
		Captions = new List<string>();
	}
}
