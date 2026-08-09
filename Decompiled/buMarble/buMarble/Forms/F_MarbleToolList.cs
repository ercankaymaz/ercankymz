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

public class F_MarbleToolList : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public List<ToolBase5> Tools = new List<ToolBase5>();

	public int indexTool = -1;

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal buLabel _0001;

	internal buLabel _0002;

	internal buLabel _0003;

	internal DataGridView _0001;

	public buButton btn_remove;

	public buButton btn_add;

	public buButton btn_edit;

	internal ImageList _0001;

	public Panel pnl_preview;

	public buButton btn_toolsave;

	public buButton btn_toolopen;

	[NonSerialized]
	internal static GetString _0005;

	public F_MarbleToolList()
	{
		global::_0005._0003._0001(this);
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
		if (global::_000E._007E_0014_0002(_009E_0006._007E_0081_0013(this._0001)) != 0)
		{
			goto IL_07e6;
		}
		if (6 == 0)
		{
			goto IL_0569;
		}
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		_009F_0006._007E_0082_0013(dataGridViewColumn, DataGridViewColumnSortMode.NotSortable);
		global::_008D._007E_0091_0007(dataGridViewColumn, 30);
		global::_008B._007E_009C_0006(dataGridViewColumn, buLangTranslate.preDef.No);
		DataGridViewColumn dataGridViewColumn4;
		while (true)
		{
			global::_008B._007E_009D_0006(dataGridViewColumn, _0005(107451297));
			global::_0082._007E_009F_0005(dataGridViewColumn, true);
			DataGridViewColumn dataGridViewColumn2;
			if (3u != 0)
			{
				global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn), new Font(_0005(107372647), 10f, FontStyle.Bold));
				global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn), DataGridViewContentAlignment.MiddleCenter);
				_0001_0007._007E_0083_0013(dataGridViewColumn, new DataGridViewTextBoxCell());
				_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn);
				dataGridViewColumn2 = new DataGridViewColumn();
				_009F_0006._007E_0082_0013(dataGridViewColumn2, DataGridViewColumnSortMode.NotSortable);
				if (false)
				{
					goto IL_02b7;
				}
				global::_008D._007E_0091_0007(dataGridViewColumn2, 60);
			}
			global::_008B._007E_009C_0006(dataGridViewColumn2, buLangTranslate.preDef.Image);
			if (4 == 0)
			{
				break;
			}
			global::_008B._007E_009D_0006(dataGridViewColumn2, _0005(107450722));
			global::_0082._007E_009F_0005(dataGridViewColumn2, true);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn2), new Font(_0005(107372647), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn2), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn2, new DataGridViewImageCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn3, DataGridViewColumnSortMode.NotSortable);
			goto IL_02b7;
			IL_02b7:
			global::_008D._007E_0091_0007(dataGridViewColumn3, 120);
			global::_008B._007E_009C_0006(dataGridViewColumn3, buLangTranslate.preDef.Type);
			global::_008B._007E_009D_0006(dataGridViewColumn3, _0005(107450069));
			global::_0082._007E_009F_0005(dataGridViewColumn3, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn3), new Font(_0005(107372647), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn2), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn3, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn3);
			dataGridViewColumn4 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn4, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn4, 240);
			global::_008B._007E_009C_0006(dataGridViewColumn4, buLangTranslate.preDef.Explanation);
			if (2 == 0)
			{
				continue;
			}
			goto IL_03c3;
		}
		goto IL_0855;
		IL_07e6:
		global::_0082._007E_0001_0006(this._0001, false);
		global::_0082._007E_0002_0006(this._0001, false);
		goto IL_0809;
		IL_08be:
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		global::_0005._0003._0001(this);
		return;
		IL_07c8:
		DataGridViewColumn dataGridViewColumn5 = default(DataGridViewColumn);
		_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn5);
		goto IL_07e6;
		IL_0809:
		global::_0082._007E_0003_0006(this._0001, false);
		bool flag = default(bool);
		if (7u != 0)
		{
			global::_0082._007E_0004_0006(this._0001, false);
			FillTools();
			if (8 == 0)
			{
				goto IL_07c8;
			}
			indexTool = -1;
			flag = Tools.Count > 0;
			goto IL_0855;
		}
		goto IL_08be;
		IL_0855:
		if (flag)
		{
			indexTool = 0;
		}
		if (indexTool >= 0)
		{
			clsAppMarbleVars.cmdMarble.DrawTool(Tools[indexTool]);
			global::_008B._007E_0088_0006(_0002, clsAppMarbleVars.cmdMarble.ToolInfo(Tools[indexTool]));
		}
		goto IL_08be;
		IL_03c3:
		global::_008B._007E_009D_0006(dataGridViewColumn4, _0005(107387402));
		global::_0082._007E_009F_0005(dataGridViewColumn4, false);
		global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn4), new Font(_0005(107372647), 10f, FontStyle.Bold));
		global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn4), DataGridViewContentAlignment.MiddleCenter);
		_0001_0007._007E_0083_0013(dataGridViewColumn4, new DataGridViewTextBoxCell());
		_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn4);
		DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
		_009F_0006._007E_0082_0013(dataGridViewColumn6, DataGridViewColumnSortMode.NotSortable);
		global::_008D._007E_0091_0007(dataGridViewColumn6, 80);
		global::_008B._007E_009C_0006(dataGridViewColumn6, buLangTranslate.preDef.Diameter);
		global::_008B._007E_009D_0006(dataGridViewColumn6, _0005(107395554));
		global::_0082._007E_009F_0005(dataGridViewColumn6, false);
		global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn6), new Font(_0005(107372647), 10f, FontStyle.Bold));
		global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn6), DataGridViewContentAlignment.MiddleCenter);
		_0001_0007._007E_0083_0013(dataGridViewColumn6, new DataGridViewTextBoxCell());
		_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn6);
		DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
		_009F_0006._007E_0082_0013(dataGridViewColumn7, DataGridViewColumnSortMode.NotSortable);
		global::_008D._007E_0091_0007(dataGridViewColumn7, 80);
		goto IL_0569;
		IL_0569:
		global::_008B._007E_009C_0006(dataGridViewColumn7, buLangTranslate.preDef.Length);
		global::_008B._007E_009D_0006(dataGridViewColumn7, _0005(107450496));
		global::_0082._007E_009F_0005(dataGridViewColumn7, false);
		global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn7), new Font(_0005(107372647), 10f, FontStyle.Bold));
		global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn7), DataGridViewContentAlignment.MiddleCenter);
		_0001_0007._007E_0083_0013(dataGridViewColumn7, new DataGridViewTextBoxCell());
		_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn7);
		dataGridViewColumn5 = new DataGridViewColumn();
		_009F_0006._007E_0082_0013(dataGridViewColumn5, DataGridViewColumnSortMode.NotSortable);
		global::_008D._007E_0091_0007(dataGridViewColumn5, 80);
		global::_008B._007E_009C_0006(dataGridViewColumn5, buLangTranslate.preDef.Thickness);
		global::_008B._007E_009D_0006(dataGridViewColumn5, _0005(107395592));
		if (7u != 0)
		{
			global::_0082._007E_009F_0005(dataGridViewColumn5, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn5), new Font(_0005(107372647), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn5), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn5, new DataGridViewTextBoxCell());
			_0002_0007._007E_0084_0013(_009E_0006._007E_0081_0013(this._0001), dataGridViewColumn5);
			DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
			_009F_0006._007E_0082_0013(dataGridViewColumn8, DataGridViewColumnSortMode.NotSortable);
			global::_008D._007E_0091_0007(dataGridViewColumn8, 80);
			global::_008B._007E_009C_0006(dataGridViewColumn8, buLangTranslate.preDef.Speed);
			global::_008B._007E_009D_0006(dataGridViewColumn8, _0005(107395618));
			global::_0082._007E_009F_0005(dataGridViewColumn8, false);
			global::_0087._007E_001E_0006(_0005_0004._007E_0004_0010(dataGridViewColumn8), new Font(_0005(107372647), 10f, FontStyle.Bold));
			global::_0003_0002._007E_007F_0008(_0005_0004._007E_0004_0010(dataGridViewColumn8), DataGridViewContentAlignment.MiddleCenter);
			_0001_0007._007E_0083_0013(dataGridViewColumn8, new DataGridViewTextBoxCell());
			goto IL_07c8;
		}
		goto IL_0809;
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
		string text = default(string);
		while (true)
		{
			global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0001));
			int num = 0;
			while (true)
			{
				if (num > Tools.Count - 1)
				{
					return;
				}
				Image image;
				string text2;
				double num2;
				if (5u != 0)
				{
					image = null;
					string obj = _0005(107398340);
					if (0 == 0)
					{
						text = obj;
					}
					text2 = _0005(107398340);
					num2 = 0.0;
					goto IL_006d;
				}
				goto IL_02d5;
				IL_01fb:
				if (false)
				{
					break;
				}
				text = buLangTranslate.preDef.BullnoseMilling;
				goto IL_0376;
				IL_0230:
				bool num3;
				if (num3 != 0)
				{
					if (0 == 0)
					{
						text = buLangTranslate.preDef.TaperMilling;
					}
				}
				else if (Tools[num].Geometry.GeometryType == ToolType.Dove)
				{
					text = buLangTranslate.preDef.DoveMilling;
				}
				else if (Tools[num].Geometry.GeometryType == ToolType.Barrel)
				{
					text = buLangTranslate.preDef.BarrelMilling;
				}
				else
				{
					if (Tools[num].Geometry.GeometryType == ToolType.Chamfer)
					{
						text = buLangTranslate.preDef.ChamferMilling;
						goto IL_02d5;
					}
					if (Tools[num].Geometry.GeometryType == ToolType.Slot)
					{
						text = buLangTranslate.preDef.SlotMilling;
					}
					else if (Tools[num].Geometry.GeometryType == ToolType.Grinding)
					{
						if (false)
						{
							goto IL_01fb;
						}
						text = buLangTranslate.preDef.GrindingMilling;
					}
					else if (Tools[num].Geometry.GeometryType == ToolType.Lollipop)
					{
						goto IL_0363;
					}
				}
				goto IL_0376;
				IL_03cc:
				double num4;
				double num5;
				_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0001), global::_0005._0003._0001(text2, num2, num + 1, num4, num5, this, image, Tools[num].CamData.SpindleSpeed, text));
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
				num++;
				continue;
				IL_0376:
				num2 = Tools[num].Geometry.Diameter;
				num5 = Tools[num].Geometry.Length;
				text2 = Tools[num].Data.Name;
				goto IL_03cc;
				IL_02d5:
				if (false)
				{
					goto IL_0363;
				}
				goto IL_0376;
				IL_0363:
				if (1 == 0)
				{
					goto IL_006d;
				}
				text = buLangTranslate.preDef.LollipopMilling;
				goto IL_0376;
				IL_01f9:
				bool num6;
				if (num6 != 0)
				{
					goto IL_01fb;
				}
				bool flag = Tools[num].Geometry.GeometryType == ToolType.Taper;
				num3 = flag;
				goto IL_0230;
				IL_006d:
				num5 = 0.0;
				num4 = 0.0;
				if (Tools[num].Purpose == ToolPurpose.Saw)
				{
					image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 1);
					text = buLangTranslate.preDef.Saw;
					num2 = Tools[num].Geometry.Diameter;
					num4 = Tools[num].Geometry.Thickness;
					text2 = Tools[num].Data.Name;
					goto IL_03cc;
				}
				bool flag2 = (Tools[num].Purpose == ToolPurpose.Milling) | (Tools[num].Purpose == ToolPurpose.MillingHead);
				num6 = flag2;
				if (2 == 0)
				{
					goto IL_01f9;
				}
				if (num6)
				{
					image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(this._0001), 0);
					text = buLangTranslate.preDef.Milling;
					num3 = Tools[num].Geometry.GeometryType == ToolType.Flat;
					if (false)
					{
						goto IL_0230;
					}
					if (num3)
					{
						text = buLangTranslate.preDef.FlatMilling;
					}
					else
					{
						if (Tools[num].Geometry.GeometryType != ToolType.Sphere)
						{
							bool flag3 = Tools[num].Geometry.GeometryType == ToolType.Bullnose;
							num6 = flag3;
							goto IL_01f9;
						}
						text = buLangTranslate.preDef.SphereMilling;
					}
					goto IL_0376;
				}
				image = new Bitmap(32, 32);
				goto IL_03cc;
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
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
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
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				PropertiesForm.Result = DialogResult.Cancel;
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
				{
					global::_0011._001D_0003(this);
					if (false)
					{
						goto IL_05be;
					}
				}
				if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
				{
					global::_0082._0086_0005(this, false);
				}
			}
			List<List<string>> list;
			bool num;
			int num2;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolopen)))
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				global::_008B._007E_0096_0006(openFileDialog, buMarbleCalc.varMarbleRunSettings.pathTools);
				global::_0082._007E_0091_0005(openFileDialog, false);
				global::_008B._007E_0097_0006(openFileDialog, _0005(107450092));
				global::_008D._007E_0089_0007(openFileDialog, 1);
				if (_0008_0004._007E_000E_0010(openFileDialog) == DialogResult.OK)
				{
					if (false)
					{
						goto IL_02fe;
					}
					FileInfo fileInfo = new FileInfo(global::_0005._007E_0086(openFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathTools = global::_0005._007E_0090(fileInfo);
					ArrayList arrayList = new ArrayList();
					_0084_0005._009A_0011(global::_0005._007E_0019(fileInfo), ref arrayList);
					list = new List<List<string>>();
					_0089_0005._009E_0011(_0005(107450007), _0005(107450022), true, arrayList, ref list);
					List<ToolBase5> list2 = new List<ToolBase5>();
					bool flag = list.Count > 0;
					num = flag;
					if (-1 == 0)
					{
						goto IL_05fb;
					}
					if (num)
					{
						Tools.Clear();
						num2 = 0;
						goto IL_0332;
					}
				}
			}
			goto IL_0352;
			IL_05fb:
			if (num && indexTool >= 0)
			{
				ToolBase5 toolBase = Tools[indexTool];
				global::_0011._007E_0080_0003(global::_0098._007E_0015_0008(pnl_preview));
				global::_0099._007E_0016_0008(global::_0098._007E_0015_0008(pnl_preview), buEyeItems.viewportDialogs);
			}
			return;
			IL_02fe:
			ArrayList arrayList2;
			ToolBase5 toolBase2;
			_008A_0005._009F_0011(arrayList2, _0005(107398340), SerilizationMode5.MultiLine, toolBase2);
			Tools.Add(toolBase2);
			num2++;
			goto IL_0332;
			IL_0352:
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_toolsave)))
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				global::_008B._007E_0096_0006(saveFileDialog, buMarbleCalc.varMarbleRunSettings.pathTools);
				global::_008B._007E_0097_0006(saveFileDialog, _0005(107450092));
				global::_008D._007E_0089_0007(saveFileDialog, 1);
				if (_0008_0004._007E_000E_0010(saveFileDialog) == DialogResult.OK)
				{
					FileInfo fileInfo2 = new FileInfo(global::_0005._007E_0086(saveFileDialog));
					buMarbleCalc.varMarbleRunSettings.pathTools = global::_0005._007E_0090(fileInfo2);
					ArrayList arrayList3 = new ArrayList();
					_0013_0004._007E_0019_0010(arrayList3, _0005(107455976));
					_0013_0004._007E_0019_0010(arrayList3, _0005(107450485));
					_0013_0004._007E_0019_0010(arrayList3, _0005(107455976));
					for (int i = 0; i <= Tools.Count - 1; i++)
					{
						_0011_0005._007E_0083_0011(arrayList3, _0090_0005._007E_0006_0012(Tools[i], _0005(107398340), 4, SerilizationMode5.MultiLine));
					}
					_0012_0005._0086_0011(arrayList3, global::_0005._007E_0086(saveFileDialog));
				}
			}
			if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_add)) || indexTool >= 0)
			{
			}
			bool flag2;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_remove)) && indexTool >= 0 && global::_0012._009B_0003(buLangTranslate.preSentences.DoYouWantToDeleteTool) == DialogResult.Yes)
			{
				Tools.RemoveAt(indexTool);
				indexTool--;
				if (indexTool < 0)
				{
					flag2 = Tools.Count > 0;
					goto IL_05be;
				}
				goto IL_05cc;
			}
			goto IL_05d6;
			IL_05be:
			if (flag2)
			{
				indexTool = 0;
			}
			goto IL_05cc;
			IL_05d6:
			num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_edit));
			goto IL_05fb;
			IL_05cc:
			FillTools();
			goto IL_05d6;
			IL_0332:
			if (num2 <= list.Count - 1)
			{
				arrayList2 = new ArrayList();
				_0011_0005._007E_0083_0011(arrayList2, list[num2].ToArray());
				toolBase2 = new ToolBase5();
				goto IL_02fe;
			}
			FillTools();
			goto IL_0352;
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
		indexTool = global::_000E._007E_0013_0002(P_1);
		int num = indexTool;
		do
		{
			num = ((num < 0) ? 1 : 0);
		}
		while (2 == 0);
		bool flag = num == 0;
		while (flag)
		{
			do
			{
				clsAppMarbleVars.cmdMarble.DrawTool(Tools[indexTool]);
				global::_008B._007E_0088_0006(_0002, clsAppMarbleVars.cmdMarble.ToolInfo(Tools[indexTool]));
			}
			while (2 == 0);
			if (3 == 0)
			{
				continue;
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

	static F_MarbleToolList()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleToolList));
		Captions = new List<string>();
	}
}
