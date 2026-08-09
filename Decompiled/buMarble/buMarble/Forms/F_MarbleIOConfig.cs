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
using buControls.DialogBox;
using buEyeBaseVer5;

namespace buMarble.Forms;

public class F_MarbleIOConfig : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal ImageList _0001;

	public buButton btn_input;

	public buButton btn_output;

	public buTab buTab_tools;

	public TabPage tabPage_input;

	internal TabPage _0001;

	public buButton btn_default;

	public buButton btn_readplc;

	public DataGridView DGV_Input;

	public DataGridView DGV_Output;

	public buButton btn_codesysdefault;

	[NonSerialized]
	internal static GetString _009E;

	public F_MarbleIOConfig()
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
		int num = 40;
		int num2 = 60;
		int num3 = 60;
		int num4 = 220;
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(DGV_Input)) == 0)
		{
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn, num);
			global::_008B._007E_009C_0006(dataGridViewColumn, buLangTranslate.preDef.No);
			global::_008B._007E_009D_0006(dataGridViewColumn, _009E(107450726));
			global::_0082._007E_009F_0005(dataGridViewColumn, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Input), dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn2, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn2, global::_000E._007E_0005_0002(DGV_Input) - num4 - num2 - num3 - num - 10);
			global::_008B._007E_009C_0006(dataGridViewColumn2, buLangTranslate.preDef.Name);
			global::_008B._007E_009D_0006(dataGridViewColumn2, _009E(107386831));
			global::_0082._007E_009F_0005(dataGridViewColumn2, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn2), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn2), DataGridViewContentAlignment.MiddleLeft);
			_0001_0007._007E_0083_0013(dataGridViewColumn2, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Input), dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn3, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn3, num2);
			global::_008B._007E_009C_0006(dataGridViewColumn3, buLangTranslate.preDef.Index);
			global::_008B._007E_009D_0006(dataGridViewColumn3, _009E(107450182));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn3), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn3), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn3, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Input), dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn4, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn4, num3);
			global::_008B._007E_009C_0006(dataGridViewColumn4, buLangTranslate.preDef.Invert);
			global::_008B._007E_009D_0006(dataGridViewColumn4, _009E(107450141));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn4), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn4), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn4, new DataGridViewCheckBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Input), dataGridViewColumn4);
			DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn5, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn5, num4);
			global::_008B._007E_009C_0006(dataGridViewColumn5, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn5, _009E(107450132));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn5), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn5), DataGridViewContentAlignment.MiddleLeft);
			_0001_0007._007E_0083_0013(dataGridViewColumn5, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Input), dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn6, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn6, num4);
			global::_008B._007E_009C_0006(dataGridViewColumn6, _009E(107360682));
			global::_008B._007E_009D_0006(dataGridViewColumn6, _009E(107360682));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn6), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn6), DataGridViewContentAlignment.MiddleLeft);
			_0001_0007._007E_0083_0013(dataGridViewColumn6, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Input), dataGridViewColumn6);
			global::_0087._007E_001E_0006(_0005_0004._007E_0005_0010(DGV_Input), new Font(_009E(107372076), 12f, FontStyle.Bold));
		}
		global::_0082._007E_0001_0006(DGV_Input, false);
		global::_0082._007E_0002_0006(DGV_Input, false);
		global::_0082._007E_0003_0006(DGV_Input, false);
		global::_0082._007E_0004_0006(DGV_Input, true);
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(DGV_Output)) == 0)
		{
			DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn7, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn7, num);
			global::_008B._007E_009C_0006(dataGridViewColumn7, buLangTranslate.preDef.No);
			global::_008B._007E_009D_0006(dataGridViewColumn7, _009E(107450726));
			global::_0082._007E_009F_0005(dataGridViewColumn7, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn7), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn7), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn7, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Output), dataGridViewColumn7);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn8, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn8, global::_000E._007E_0005_0002(DGV_Input) - num4 - num2 - num3 - num - 10);
			global::_008B._007E_009C_0006(dataGridViewColumn8, buLangTranslate.preDef.Name);
			global::_008B._007E_009D_0006(dataGridViewColumn8, _009E(107386831));
			global::_0082._007E_009F_0005(dataGridViewColumn8, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn8), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn8), DataGridViewContentAlignment.MiddleLeft);
			_0001_0007._007E_0083_0013(dataGridViewColumn8, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Output), dataGridViewColumn8);
			DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn9, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn9, num2);
			global::_008B._007E_009C_0006(dataGridViewColumn9, buLangTranslate.preDef.Index);
			global::_008B._007E_009D_0006(dataGridViewColumn9, _009E(107450182));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn9), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn9), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn9, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Output), dataGridViewColumn9);
			DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn10, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn10, num3);
			global::_008B._007E_009C_0006(dataGridViewColumn10, buLangTranslate.preDef.Invert);
			global::_008B._007E_009D_0006(dataGridViewColumn10, _009E(107450141));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn10), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn10), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn10, new DataGridViewCheckBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Output), dataGridViewColumn10);
			global::_0087._007E_001E_0006(_0005_0004._007E_0005_0010(DGV_Output), new Font(_009E(107372076), 12f, FontStyle.Bold));
			DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn11, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn11, num4);
			global::_008B._007E_009C_0006(dataGridViewColumn11, buLangTranslate.preDef.Explanation);
			global::_008B._007E_009D_0006(dataGridViewColumn11, _009E(107450132));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn11), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn11), DataGridViewContentAlignment.MiddleLeft);
			_0001_0007._007E_0083_0013(dataGridViewColumn11, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Output), dataGridViewColumn11);
			DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn12, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn12, num4);
			global::_008B._007E_009C_0006(dataGridViewColumn12, _009E(107360632));
			global::_008B._007E_009D_0006(dataGridViewColumn12, _009E(107360632));
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn12), new Font(_009E(107372076), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn12), DataGridViewContentAlignment.MiddleLeft);
			_0001_0007._007E_0083_0013(dataGridViewColumn12, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(DGV_Output), dataGridViewColumn12);
		}
		global::_0082._007E_0001_0006(DGV_Output, false);
		global::_0082._007E_0002_0006(DGV_Output, false);
		global::_0082._007E_0004_0006(DGV_Output, true);
		global::_0082._007E_0003_0006(DGV_Output, false);
		FillIO();
		MenuButtonColors(0);
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
	}

	public void FillIO()
	{
		global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(DGV_Input));
		int num = 0;
		int num6 = default(int);
		while (true)
		{
			int num2 = num;
			int num3 = clsAppMarbleVars.cMachine.Inputs.Count;
			if (3 == 0)
			{
				goto IL_01f5;
			}
			bool num4 = num2 > num3 - 1;
			do
			{
				bool flag = !num4;
				num4 = flag;
			}
			while (-1 == 0);
			bool num5;
			if (num4)
			{
				_0005_0005 obj = _0005_0005._007E_001B_0011;
				DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(DGV_Input);
				string name = clsAppMarbleVars.cMachine.Inputs[num].Name;
				string text;
				if (3u != 0)
				{
					text = name;
				}
				int sourceIndex = clsAppMarbleVars.cMachine.Inputs[num].SourceIndex;
				bool invert = clsAppMarbleVars.cMachine.Inputs[num].Invert;
				string caption = clsAppMarbleVars.cMachine.Inputs[num].Caption;
				string text2 = _009E(107371332);
				obj(dataGridViewRowCollection, _0005._0003._0001(sourceIndex, invert, text2, this, text, caption, num + 1));
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_Input), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_Input)) - 1), 40);
				if (uint.MaxValue != 0)
				{
					bool flag2 = clsAppMarbleVars.cMachine.Inputs[num].SourceIndex >= 0;
					num5 = flag2;
					goto IL_013a;
				}
			}
			else
			{
				global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(DGV_Output));
				num6 = 0;
			}
			goto IL_03fe;
			IL_01f2:
			num2 = num;
			goto IL_01f4;
			IL_013a:
			if (num5)
			{
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_Input), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_Input)) - 1)), global::_001E._001C_0004());
			}
			else
			{
				if (2 == 0)
				{
					goto IL_02df;
				}
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_Input), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_Input)) - 1)), global::_001E._008E_0004());
			}
			goto IL_01f2;
			IL_03fe:
			num2 = num6;
			if (-1 == 0)
			{
				goto IL_01f4;
			}
			if (num2 <= clsAppMarbleVars.cMachine.Outputs.Count - 1)
			{
				if (5 == 0)
				{
					goto IL_01f2;
				}
				_0005_0005 obj2 = _0005_0005._007E_001B_0011;
				DataGridViewRowCollection dataGridViewRowCollection2 = _0001_0004._007E_009E_000F(DGV_Output);
				string name2 = clsAppMarbleVars.cMachine.Outputs[num6].Name;
				int sourceIndex2 = clsAppMarbleVars.cMachine.Outputs[num6].SourceIndex;
				bool invert2 = clsAppMarbleVars.cMachine.Outputs[num6].Invert;
				string caption2 = clsAppMarbleVars.cMachine.Outputs[num6].Caption;
				string text3 = _009E(107371332);
				obj2(dataGridViewRowCollection2, _0005._0003._0001(name2, text3, num6 + 1, invert2, this, sourceIndex2, caption2));
				goto IL_02df;
			}
			break;
			IL_01f4:
			num3 = 1;
			goto IL_01f5;
			IL_01f5:
			num = num2 + num3;
			continue;
			IL_02df:
			global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_Output), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_Output)) - 1), 40);
			bool flag3 = clsAppMarbleVars.cMachine.Outputs[num6].SourceIndex >= 0;
			num5 = flag3;
			if (false)
			{
				goto IL_013a;
			}
			if (num5)
			{
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_Output), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_Output)) - 1)), global::_001E._001C_0004());
			}
			else
			{
				global::_001F._007E_0007_0005(_0005_0004._007E_0004_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(DGV_Output), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(DGV_Output)) - 1)), global::_001E._008E_0004());
			}
			num6++;
			goto IL_03fe;
		}
	}

	public void MenuButtonColors(int PageIndex)
	{
		while (true)
		{
			Control.ControlCollection controlCollection = global::_0098._007E_0015_0008(buGround1);
			while (true)
			{
				controlCollection = _0099_0006._001D_0013(controlCollection);
				bool flag = PageIndex == 0;
				if (6 == 0 || 1 == 0)
				{
					break;
				}
				if (flag)
				{
					btn_input = _009D_0006._0080_0013(btn_input, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
					global::_008D._007E_000F_0007(buTab_tools, 0);
				}
				int num = PageIndex;
				if (0 == 0)
				{
					num = ((num == 1) ? 1 : 0);
				}
				if (num != 0)
				{
					if (7u != 0)
					{
						btn_output = _009D_0006._0080_0013(btn_output, _0018_0003._007E_0008_000F(buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal));
						global::_008D._007E_000F_0007(buTab_tools, 1);
						return;
					}
					continue;
				}
				return;
			}
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)))
			{
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
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_readplc)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo2 = new buDialogMessageBoxYesNo();
				global::_009C._007E_001A_0008(buDialogMessageBoxYesNo2, FormStartPosition.CenterScreen);
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo2, buLangTranslate.preDef.Read, buLangTranslate.preSentences.DoYouWantToReadIOParameter);
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo2);
				if (buDialogMessageBoxYesNo2.Result != DialogResult.Yes)
				{
					return;
				}
				clsAppMarbleVars.cmdMarble.ReadIOData();
				FillIO();
				buDialogMessageBoxOk buDialogMessageBoxOk2 = new buDialogMessageBoxOk();
				global::_009C._007E_001A_0008(buDialogMessageBoxOk2, FormStartPosition.CenterScreen);
				_000E_0004._007E_0010_0010(buDialogMessageBoxOk2, buLangTranslate.preDef.Parameter, buLangTranslate.preSentences.ParameterReadDone);
				_0008_0004._007E_0008_0010(buDialogMessageBoxOk2);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_default)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo3 = new buDialogMessageBoxYesNo();
				global::_009C._007E_001A_0008(buDialogMessageBoxYesNo3, FormStartPosition.CenterScreen);
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo3, buLangTranslate.preDef.Read, buLangTranslate.preSentences.DoYouWanttoCallDefaultValues);
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo3);
				if (buDialogMessageBoxYesNo3.Result != DialogResult.Yes)
				{
					return;
				}
				clsAppMarbleVars.cmdMarble.DebugCreateDefaultIOFile();
				buDialogMessageBoxOk buDialogMessageBoxOk3 = new buDialogMessageBoxOk();
				global::_009C._007E_001A_0008(buDialogMessageBoxOk3, FormStartPosition.CenterScreen);
				_000E_0004._007E_0010_0010(buDialogMessageBoxOk3, buLangTranslate.preDef.File, global::_0014_0002._0091_0008(buLangTranslate.preSentences.FileCreated, global::_0013._009E_0003(), AppPath.Base, _009E(107460045)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxOk3);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_codesysdefault)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo4 = new buDialogMessageBoxYesNo();
				global::_009C._007E_001A_0008(buDialogMessageBoxYesNo4, FormStartPosition.CenterScreen);
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo4, buLangTranslate.preDef.Read, buLangTranslate.preSentences.DoYouWanttoCallDefaultValues);
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo4);
				if (buDialogMessageBoxYesNo4.Result != DialogResult.Yes)
				{
					return;
				}
				clsAppMarbleVars.cmdMarble.DebugCreateDefaultCodesysIO();
				buDialogMessageBoxOk buDialogMessageBoxOk4 = new buDialogMessageBoxOk();
				global::_009C._007E_001A_0008(buDialogMessageBoxOk4, FormStartPosition.CenterScreen);
				_000E_0004._007E_0010_0010(buDialogMessageBoxOk4, buLangTranslate.preDef.File, global::_0014_0002._0091_0008(buLangTranslate.preSentences.FileCreated, global::_0013._009E_0003(), AppPath.Base, _009E(107459925)));
				_0008_0004._007E_0008_0010(buDialogMessageBoxOk4);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_input)))
			{
				global::_008D._007E_000F_0007(buTab_tools, 0);
				MenuButtonColors(0);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_output)))
			{
				global::_008D._007E_000F_0007(buTab_tools, 1);
				MenuButtonColors(1);
			}
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
		if (0 == 0)
		{
			int num = global::_000E._007E_0015_0002(P_1);
			do
			{
				num = ((num == 5) ? 1 : 0);
			}
			while (false);
			if (num == 0)
			{
				return;
			}
		}
		int index;
		if (global::_000E._007E_0013_0002(P_1) >= 0)
		{
			int num2 = global::_000E._007E_0013_0002(P_1);
			int num3 = clsAppMarbleVars.cMachine.Outputs.Count;
			if (0 == 0)
			{
				num3--;
			}
			bool num4 = num2 <= num3;
			bool flag;
			do
			{
				if (num4)
				{
					index = global::_000E._007E_0013_0002(P_1);
					bool Val = false;
					clsAppMarbleVars.cmdMarble.readBOOLVar(CodesysVariableBaseType.None, clsAppMarbleVars.cMachine.Outputs[index].Name, ref Val);
					flag = !Val;
					continue;
				}
				return;
			}
			while (false);
			if (!flag)
			{
				goto IL_00d9;
			}
			clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.None, Val: true, clsAppMarbleVars.cMachine.Outputs[index].Name);
		}
		else if (uint.MaxValue != 0)
		{
			return;
		}
		goto IL_00fc;
		IL_00d9:
		clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.None, Val: false, clsAppMarbleVars.cMachine.Outputs[index].Name);
		goto IL_00fc;
		IL_00fc:
		if (6u != 0)
		{
			return;
		}
		goto IL_00d9;
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

	static F_MarbleIOConfig()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleIOConfig));
		Captions = new List<string>();
	}
}
