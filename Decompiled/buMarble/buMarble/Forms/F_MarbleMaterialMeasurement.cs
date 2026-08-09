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
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;

namespace buMarble.Forms;

public class F_MarbleMaterialMeasurement : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public int indexList = -1;

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal ImageList _0001;

	internal RadioButton _0001;

	public buButton btn_matgetpos;

	public buButton btn_matsave;

	public buButton btn_matopen;

	internal RadioButton _0002;

	public buButton btn_point1;

	public buButton btn_point9;

	public buButton btn_point5;

	public buButton btn_point4;

	public buButton btn_point3;

	public buButton btn_point2;

	public buSpin spn_matwidth;

	public buSpin spn_matheight;

	public buButton btn_materialmeasure;

	public DataGridView DGV_list;

	public buButton btn_point16;

	public buButton btn_matmeasuresettings;

	public buButton btn_stop;

	[NonSerialized]
	internal static GetString _0091;

	public F_MarbleMaterialMeasurement()
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
		global::_0095._007E_0008_0008(spn_matwidth, buMarbleCalc.varOperation.MaterialParameter.MaterialWidth);
		global::_0095._007E_0008_0008(spn_matheight, buMarbleCalc.varOperation.MaterialParameter.MaterialHeight);
		DataGridViewColumn dataGridViewColumn3 = default(DataGridViewColumn);
		while (true)
		{
			clsAppMarbleVars.varApp.MaterialWidth = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth;
			clsAppMarbleVars.varApp.MaterialHeight = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight;
			if (clsAppMarbleVars.varApp.MaterialMeasureMode == AutoManuel.Auto)
			{
				global::_0082._007E_009E_0005(this._0001, true);
				if (8 == 0)
				{
					goto IL_0479;
				}
			}
			else
			{
				global::_0082._007E_009E_0005(this._0002, true);
			}
			MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
			if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(DGV_list)) != 0)
			{
				break;
			}
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn, 70);
			global::_008B._007E_009C_0006(dataGridViewColumn, buLangTranslate.preDef.Number);
			global::_008B._007E_009D_0006(dataGridViewColumn, _0091(107450905));
			global::_0082._007E_009F_0005(dataGridViewColumn, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn), new Font(_0091(107372255), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_list), dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn2, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn2, 140);
			global::_008B._007E_009C_0006(dataGridViewColumn2, buLangTranslate.preChar.X);
			global::_008B._007E_009D_0006(dataGridViewColumn2, _0091(107412706));
			global::_0082._007E_009F_0005(dataGridViewColumn2, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn2), new Font(_0091(107372255), 10f, FontStyle.Bold));
			if (false)
			{
				continue;
			}
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn2), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn2, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn2)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_list), dataGridViewColumn2);
			dataGridViewColumn3 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn3, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn3, 140);
			global::_008B._007E_009C_0006(dataGridViewColumn3, buLangTranslate.preChar.Y);
			global::_008B._007E_009D_0006(dataGridViewColumn3, _0091(107412736));
			global::_0082._007E_009F_0005(dataGridViewColumn3, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn3), new Font(_0091(107372255), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn3), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn3, new DataGridViewTextBoxCell());
			goto IL_0479;
			IL_0479:
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn3)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_list), dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn4, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn4, 140);
			global::_008B._007E_009C_0006(dataGridViewColumn4, buLangTranslate.preDef.Thickness);
			global::_008B._007E_009D_0006(dataGridViewColumn4, _0091(107395200));
			global::_0082._007E_009F_0005(dataGridViewColumn4, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn4), new Font(_0091(107372255), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn4), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn4, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn4)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_list), dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn5, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn5, 140);
			global::_008B._007E_009C_0006(dataGridViewColumn5, global::_0002._0003(buLangTranslate.preDef.Old, buLangTranslate.preDef.Thickness));
			global::_008B._007E_009D_0006(dataGridViewColumn5, _0091(107450289));
			global::_0082._007E_009F_0005(dataGridViewColumn5, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn5), new Font(_0091(107372255), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn5), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn5, new DataGridViewTextBoxCell());
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0003_0010(_0003_0007._007E_0086_0013(dataGridViewColumn5)), DataGridViewContentAlignment.MiddleCenter);
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_list), dataGridViewColumn5);
			break;
		}
		global::_0082._007E_0001_0006(DGV_list, false);
		global::_0082._007E_0002_0006(DGV_list, false);
		global::_0082._007E_0003_0006(DGV_list, false);
		global::_0082._007E_0004_0006(DGV_list, true);
		UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
		FillList();
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
		buMarbleCalc.varOperation.MaterialParameter.MaterialWidth = global::_0007._007E_0094(spn_matwidth);
		buMarbleCalc.varOperation.MaterialParameter.MaterialHeight = global::_0007._007E_0094(spn_matheight);
		clsAppMarbleVars.varApp.MaterialWidth = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth;
		clsAppMarbleVars.varApp.MaterialHeight = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight;
		if (global::_0003._007E_0017(this._0002))
		{
			clsAppMarbleVars.varApp.MaterialMeasureMode = AutoManuel.Manuel;
		}
		else
		{
			clsAppMarbleVars.varApp.MaterialMeasureMode = AutoManuel.Auto;
		}
		for (int i = 0; i <= global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1; i++)
		{
			clsAppMarbleVars.cMachine.MaterialMeasureList[i].X = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), i)), 1))));
			clsAppMarbleVars.cMachine.MaterialMeasureList[i].Y = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), i)), 2))));
			clsAppMarbleVars.cMachine.MaterialMeasureList[i].Z = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), i)), 3))));
			clsAppMarbleVars.cMachine.MaterialMeasureList[i].W = _0008_0005._007F_0011(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), i)), 4))));
		}
	}

	public void UpdateList(MarbleMaterialMeasureType PointType)
	{
		int num = _0090_0003._008D_000F(PointType);
		int num4;
		if (num > clsAppMarbleVars.cMachine.MaterialMeasureList.Count)
		{
			int num2 = num - clsAppMarbleVars.cMachine.MaterialMeasureList.Count;
			int num3 = 1;
			while (true)
			{
				num4 = num3;
				if (false)
				{
					break;
				}
				if (num4 <= num2)
				{
					clsAppMarbleVars.cMachine.MaterialMeasureList.Add(new Pnt9DS());
					num3++;
					continue;
				}
				goto IL_00c5;
			}
		}
		else
		{
			if (num >= clsAppMarbleVars.cMachine.MaterialMeasureList.Count)
			{
				goto IL_00c5;
			}
			num4 = clsAppMarbleVars.cMachine.MaterialMeasureList.Count - num;
		}
		int count = num4;
		clsAppMarbleVars.cMachine.MaterialMeasureList.RemoveRange(num, count);
		goto IL_00c5;
		IL_00c5:
		if (clsAppMarbleVars.varApp.MaterialMeasureMode != AutoManuel.Auto)
		{
			return;
		}
		bool flag = PointType == MarbleMaterialMeasureType.Point1;
		bool num5 = flag;
		do
		{
			if (num5)
			{
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
			}
			if (PointType == MarbleMaterialMeasureType.Point2)
			{
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
			}
			if (PointType == MarbleMaterialMeasureType.Point3)
			{
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
			}
			num5 = PointType == MarbleMaterialMeasureType.Point4;
		}
		while (false);
		if (num5)
		{
			clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
			clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
			clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
			clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
			clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
			clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
			clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
			clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
		}
		while (true)
		{
			if (PointType == MarbleMaterialMeasureType.Point5)
			{
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[4].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[4].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
			}
			if (PointType == MarbleMaterialMeasureType.Point9)
			{
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[4].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[4].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[5].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[5].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[6].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[6].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[7].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
				clsAppMarbleVars.cMachine.MaterialMeasureList[7].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[8].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[8].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
			}
			if (PointType == MarbleMaterialMeasureType.Point16)
			{
				double materialMeasureXBorderOffset = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				double num6 = global::_001C_0002._009B_0008(buMarbleCalc.varOperation.MaterialParameter.MaterialWidth * 0.3333, 3);
				double num7 = global::_001C_0002._009B_0008(buMarbleCalc.varOperation.MaterialParameter.MaterialWidth * 0.6666, 3);
				double num8 = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
				double materialMeasureYBorderOffset = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				double num9 = global::_001C_0002._009B_0008(buMarbleCalc.varOperation.MaterialParameter.MaterialHeight * 0.3333, 3);
				double num10 = global::_001C_0002._009B_0008(buMarbleCalc.varOperation.MaterialParameter.MaterialHeight * 0.6666, 3);
				double num11 = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = materialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = materialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = num6;
				clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = materialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = num7;
				clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = materialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = num8;
				clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = materialMeasureYBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[4].X = num8;
				clsAppMarbleVars.cMachine.MaterialMeasureList[4].Y = num9;
				clsAppMarbleVars.cMachine.MaterialMeasureList[5].X = num7;
				clsAppMarbleVars.cMachine.MaterialMeasureList[5].Y = num9;
				clsAppMarbleVars.cMachine.MaterialMeasureList[6].X = num6;
				clsAppMarbleVars.cMachine.MaterialMeasureList[6].Y = num9;
				clsAppMarbleVars.cMachine.MaterialMeasureList[7].X = materialMeasureXBorderOffset;
				clsAppMarbleVars.cMachine.MaterialMeasureList[7].Y = num9;
				clsAppMarbleVars.cMachine.MaterialMeasureList[8].X = materialMeasureXBorderOffset;
				if (6u != 0)
				{
					clsAppMarbleVars.cMachine.MaterialMeasureList[8].Y = num10;
					clsAppMarbleVars.cMachine.MaterialMeasureList[9].X = num6;
					clsAppMarbleVars.cMachine.MaterialMeasureList[9].Y = num10;
					clsAppMarbleVars.cMachine.MaterialMeasureList[10].X = num7;
					clsAppMarbleVars.cMachine.MaterialMeasureList[10].Y = num10;
					clsAppMarbleVars.cMachine.MaterialMeasureList[11].X = num8;
					clsAppMarbleVars.cMachine.MaterialMeasureList[11].Y = num10;
					clsAppMarbleVars.cMachine.MaterialMeasureList[12].X = num8;
					clsAppMarbleVars.cMachine.MaterialMeasureList[12].Y = num11;
					clsAppMarbleVars.cMachine.MaterialMeasureList[13].X = num7;
					clsAppMarbleVars.cMachine.MaterialMeasureList[13].Y = num11;
					clsAppMarbleVars.cMachine.MaterialMeasureList[14].X = num6;
					clsAppMarbleVars.cMachine.MaterialMeasureList[14].Y = num11;
					clsAppMarbleVars.cMachine.MaterialMeasureList[15].X = materialMeasureXBorderOffset;
					clsAppMarbleVars.cMachine.MaterialMeasureList[15].Y = num11;
					break;
				}
				continue;
			}
			break;
		}
	}

	public void FillList()
	{
		global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(DGV_list));
		bool flag = global::_0003._007E_0017(this._0001);
		int num = (flag ? 1 : 0);
		if (6 == 0)
		{
			goto IL_01f1;
		}
		if (false)
		{
			goto IL_01f3;
		}
		int num2;
		if (num != 0)
		{
			num2 = 0;
			goto IL_01f4;
		}
		Pnt9DS pnt9DS = new Pnt9DS(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, clsAppMarbleVars.cMachine.MaterialMeasureList[0].Z, 0.0, 0.0, 0.0, 0.0, 0.0, clsAppMarbleVars.cMachine.MaterialMeasureList[0].W);
		_0005_0005 obj = _0005_0005._007E_001B_0011;
		DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(DGV_list);
		double num3 = pnt9DS.X;
		double num4 = pnt9DS.Y;
		double z = pnt9DS.Z;
		double w = pnt9DS.W;
		int num5 = obj(dataGridViewRowCollection, _0005._0003._0001(num4, this, w, num3, z, 1));
		goto IL_0326;
		IL_01f4:
		num5 = ((num2 <= clsAppMarbleVars.cMachine.MaterialMeasureList.Count - 1) ? 1 : 0);
		if (0 == 0)
		{
			if (num5 == 0)
			{
				return;
			}
			Pnt9DS pnt9DS2 = clsAppMarbleVars.cMachine.MaterialMeasureList[num2];
			if (num2 <= _0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType) - 1)
			{
				if (2u != 0)
				{
					_0005_0005 obj2 = _0005_0005._007E_001B_0011;
					DataGridViewRowCollection dataGridViewRowCollection2 = _0001_0004._007E_009E_000F(DGV_list);
					num3 = pnt9DS2.X;
					num4 = pnt9DS2.Y;
					z = pnt9DS2.Z;
					w = pnt9DS2.W;
					obj2(dataGridViewRowCollection2, _0005._0003._0001(num4, this, w, num3, z, num2 + 1));
					global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1), 35);
				}
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1)), global::_001E._001C_0004());
				global::_001F._007E_0008_0005(_0005_0004._007E_0003_0010(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1)), 4)), global::_001E._009C_0004());
			}
			num = num2;
			goto IL_01f1;
		}
		goto IL_0326;
		IL_0326:
		global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1), 35);
		global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1)), global::_001E._001C_0004());
		global::_001F._007E_0008_0005(_0005_0004._007E_0003_0010(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1)), 4)), global::_001E._009C_0004());
		return;
		IL_01f3:
		num2 = num;
		goto IL_01f4;
		IL_01f1:
		num++;
		goto IL_01f3;
	}

	public void MenuButtonColors(int PageIndex)
	{
		Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
		controlCollection = _0099_0006._001D_0013(controlCollection);
		bool num = PageIndex == 1;
		if (false)
		{
			goto IL_0308;
		}
		bool flag = num;
		if (false)
		{
			goto IL_0353;
		}
		if (false)
		{
			goto IL_0275;
		}
		if (flag)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point1)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point1)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		bool flag2 = PageIndex == 2;
		bool num2;
		if (0 == 0)
		{
			if (flag2)
			{
				global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point2)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
				global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point2)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			}
			num2 = PageIndex == 3;
			goto IL_0162;
		}
		goto IL_03a0;
		IL_0162:
		if (num2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point3)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point3)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		if (PageIndex == 4)
		{
			if (false)
			{
				goto IL_0303;
			}
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point4)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point4)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		goto IL_0275;
		IL_0303:
		num = PageIndex == 9;
		goto IL_0308;
		IL_0308:
		bool flag3 = num;
		num2 = flag3;
		if (2 == 0)
		{
			goto IL_0162;
		}
		if (num2)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point9)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			goto IL_0353;
		}
		goto IL_0392;
		IL_0392:
		if (PageIndex != 16)
		{
			return;
		}
		goto IL_03a0;
		IL_0353:
		global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point9)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		goto IL_0392;
		IL_0275:
		bool flag4 = PageIndex == 5;
		goto IL_027b;
		IL_03a0:
		if (0 == 0)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point16)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point16)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			return;
		}
		goto IL_027b;
		IL_027b:
		if (3u != 0 && flag4)
		{
			global::_001F._007E_0004_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point5)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
			global::_001F._007E_0005_0005(global::_0091._007E_009F_0007(global::_0083._007E_0008_0006(btn_point5)), _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
		}
		goto IL_0303;
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
				clsAppMarbleVars.varApp.SelectedParkPosition = indexList;
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
					if (7 == 0)
					{
						goto IL_0980;
					}
					global::_0082._0086_0005(this, false);
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(this._0001)))
			{
				FillList();
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(this._0002)))
			{
				FillList();
			}
			int num;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_materialmeasure)))
			{
				Apply();
				if (clsAppMarbleVars.varApp.MaterialMeasureMode != AutoManuel.Manuel)
				{
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 1, _0091(107372090));
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)), _0091(107450304));
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Persistent, (int)clsAppMarbleVars.varApp.MaterialMeasureMode, _0091(107371277));
					num = 0;
					goto IL_06d7;
				}
				indexList = 0;
				FillList();
				if ((indexList >= 0) & (indexList <= global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1))
				{
					global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), indexList)), 4), global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), indexList)), 3)));
					clsAppMarbleVars.cMachine.MaterialMeasureList[indexList].W = clsAppMarbleVars.cMachine.MaterialMeasureList[indexList].Z;
					clsAppMarbleVars.varRuntime.MaterialIndex = indexList + 1;
					double val = _0016_0004._001F_0010(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), indexList)), 1)));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val, _0091(107371383));
					val = _0016_0004._001F_0010(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), indexList)), 2)));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val, _0091(107371314));
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Persistent, (int)clsAppMarbleVars.varApp.MaterialMeasureMode, _0091(107371277));
					clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varRuntime.MaterialIndex, _0091(107372090));
					clsAppMarbleVars.cmdMarble.ClickCommand(MarbleMotionCommands.MaterialMeasure);
				}
			}
			goto IL_0721;
			IL_0721:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_point1)))
			{
				clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.Point1;
				MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
				Apply();
				UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
				FillList();
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_point2)))
			{
				if (false)
				{
					goto IL_088c;
				}
				clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.Point2;
				MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
				Apply();
				UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
				FillList();
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_point3)))
			{
				clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.Point3;
				MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
				Apply();
				UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
				FillList();
			}
			goto IL_088c;
			IL_06d7:
			int num2 = num;
			goto IL_06d9;
			IL_088c:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_point4)))
			{
				clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.Point4;
				MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
				Apply();
				UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
				FillList();
			}
			if (0 == 0)
			{
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_point5)))
				{
					clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.Point5;
					MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
					Apply();
					UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
					FillList();
				}
				goto IL_0980;
			}
			goto IL_09ac;
			IL_09ac:
			clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.Point9;
			Apply();
			MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
			UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
			FillList();
			goto IL_09f8;
			IL_0980:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_point9)))
			{
				goto IL_09ac;
			}
			goto IL_09f8;
			IL_0c01:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_matsave)))
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				global::_008B._007E_0096_0006(saveFileDialog, buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure);
				global::_008B._007E_0097_0006(saveFileDialog, _0091(107450536));
				global::_008D._007E_0089_0007(saveFileDialog, 1);
				if (_0008_0004._007E_000E_0010(saveFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(global::_0005._007E_0086(saveFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure = global::_0005._007E_0090(fileInfo);
					ArrayList arrayList = new ArrayList();
					_0013_0004._007E_0019_0010(arrayList, _0091(107455584));
					_0013_0004._007E_0019_0010(arrayList, _0091(107450491));
					_0013_0004._007E_0019_0010(arrayList, _0091(107455584));
					_0013_0004._007E_0019_0010(arrayList, _0091(107450566));
					for (int i = 0; i <= clsAppMarbleVars.cMachine.MaterialMeasureList.Count - 1; i++)
					{
						_0013_0004._007E_0019_0010(arrayList, _0004_0007._007E_0087_0013(clsAppMarbleVars.cMachine.MaterialMeasureList[i], 2));
					}
					_0013_0004._007E_0019_0010(arrayList, _0091(107450585));
					_0012_0005._0086_0011(arrayList, global::_0005._007E_0086(saveFileDialog));
				}
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_matmeasuresettings)))
			{
				clsAppMarbleVars.cmdMarble.ShowMachineSettingsV1(8);
			}
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_matgetpos)))
			{
				return;
			}
			num2 = ((AppBool.Connected & (indexList >= 0)) ? 1 : 0);
			if (8u != 0)
			{
				if (num2 != 0)
				{
					if (clsAppMarbleVars.varRuntime.AxX >= 0)
					{
						global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), indexList)), 1), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2));
					}
					if (clsAppMarbleVars.varRuntime.AxY >= 0)
					{
						global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), indexList)), 2), global::_001C_0002._009B_0008(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2));
					}
				}
				return;
			}
			goto IL_06d9;
			IL_09f8:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_point16)))
			{
				clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.Point16;
				Apply();
				MenuButtonColors(_0090_0003._008D_000F(clsAppMarbleVars.varApp.MaterialMeasureType));
				UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
				FillList();
			}
			List<string> list;
			int num3;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_matopen)))
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				global::_008B._007E_0096_0006(openFileDialog, buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure);
				global::_0082._007E_0091_0005(openFileDialog, false);
				global::_008B._007E_0097_0006(openFileDialog, _0091(107450167));
				global::_008D._007E_0089_0007(openFileDialog, 1);
				if (_0008_0004._007E_000E_0010(openFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo2 = new FileInfo(global::_0005._007E_0086(openFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure = global::_0005._007E_0090(fileInfo2);
					ArrayList arrayList2 = new ArrayList();
					_0084_0005._009A_0011(global::_0005._007E_0019(fileInfo2), ref arrayList2);
					list = new List<string>();
					_0087_0005._009C_0011(_0091(107450566), _0091(107450585), false, arrayList2, ref list);
					if (list.Count > 0)
					{
						clsAppMarbleVars.cMachine.MaterialMeasureList.Clear();
						num3 = 0;
						goto IL_0be1;
					}
				}
			}
			goto IL_0c01;
			IL_0bd9:
			num3++;
			goto IL_0be1;
			IL_06d9:
			if (num2 <= global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_list)) - 1)
			{
				global::_0010_0002._007E_008C_0008(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), num)), 4), global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), num)), 3)));
				clsAppMarbleVars.cMachine.MaterialMeasureList[num].W = clsAppMarbleVars.cMachine.MaterialMeasureList[num].Z;
				double val2 = _0016_0004._001F_0010(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), num)), 1)));
				if (0 == 0)
				{
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val2, global::_0014._009F_0003(_0091(107450227), num.ToString(), _0091(107450190)));
					val2 = _0016_0004._001F_0010(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_list), num)), 2)));
					clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, val2, global::_0014._009F_0003(_0091(107450227), num.ToString(), _0091(107450185)));
					num++;
					goto IL_06d7;
				}
				goto IL_0bd9;
			}
			clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0091(107450212));
			goto IL_0721;
			IL_0be1:
			if (num3 <= list.Count - 1)
			{
				Pnt9DS item = _0088_0005._009D_0011(list[num3]);
				clsAppMarbleVars.cMachine.MaterialMeasureList.Add(item);
				goto IL_0bd9;
			}
			FillList();
			goto IL_0c01;
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
	}

	internal void _0001(object P_0, DataGridViewCellEventArgs P_1)
	{
		indexList = global::_000E._007E_0013_0002(P_1);
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

	static F_MarbleMaterialMeasurement()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleMaterialMeasurement));
		Captions = new List<string>();
	}
}
