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

namespace buMarble.Forms;

public class F_MarbleInfoList : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public List<InfoType> InfoList = new List<InfoType>();

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal DataGridView _0001;

	public ImageList IC32;

	[NonSerialized]
	internal static GetString _0097;

	public F_MarbleInfoList()
	{
		_0005._0003._0001(this);
	}

	public void Init(List<InfoType> infoList)
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		InfoList.Clear();
		if (infoList != null && infoList.Count > 0)
		{
			InfoType.Copy(infoList, ref InfoList);
		}
		if (this._0001.Columns.Count != 0)
		{
			goto IL_0323;
		}
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewColumn.Width = 35;
		dataGridViewColumn.HeaderText = buLangTranslate.preDef.Number;
		dataGridViewColumn.Name = _0097(107450845);
		dataGridViewColumn.ReadOnly = true;
		while (true)
		{
			dataGridViewColumn.DefaultCellStyle.Font = new Font(_0097(107372195), 10f, FontStyle.Bold);
			dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			if (false)
			{
				break;
			}
			dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this._0001.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridViewColumn2.Width = 60;
			dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Image;
			dataGridViewColumn2.Name = _0097(107450270);
			DataGridViewColumn dataGridViewColumn3;
			if (0 == 0)
			{
				dataGridViewColumn2.ReadOnly = true;
				dataGridViewColumn2.DefaultCellStyle.Font = new Font(_0097(107372195), 10f, FontStyle.Bold);
				do
				{
					dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				while (false);
				dataGridViewColumn2.CellTemplate = new DataGridViewImageCell();
				dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				this._0001.Columns.Add(dataGridViewColumn2);
				dataGridViewColumn3 = new DataGridViewColumn();
				dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
				if (6 == 0)
				{
					continue;
				}
				dataGridViewColumn3.Width = 680;
				dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Explanation;
				dataGridViewColumn3.Name = _0097(107386950);
			}
			dataGridViewColumn3.ReadOnly = false;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font(_0097(107372195), 10f, FontStyle.Bold);
			dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this._0001.Columns.Add(dataGridViewColumn3);
			goto IL_0323;
		}
		goto IL_0376;
		IL_0376:
		_0005._0003._0001(this);
		return;
		IL_0323:
		this._0001.RowHeadersVisible = false;
		this._0001.AllowUserToAddRows = false;
		this._0001.AllowUserToResizeColumns = false;
		this._0001.ColumnHeadersVisible = false;
		FillInfo();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		goto IL_0376;
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

	public void FillInfo()
	{
		global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0001));
		if (InfoList == null)
		{
			return;
		}
		for (int i = 0; i <= InfoList.Count - 1; i++)
		{
			Image image = null;
			if (InfoList[i].Mode == InfoTypeMode.Warning)
			{
				image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(IC32), 0);
			}
			else if (InfoList[i].Mode == InfoTypeMode.Alarm)
			{
				image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(IC32), 1);
			}
			else if (InfoList[i].Mode == InfoTypeMode.Message)
			{
				image = global::_0087_0002._007E_0007_000E(global::_007F._007E_0014_0005(IC32), 2);
			}
			_0005_0005._007E_001B_0011(_0001_0004._007E_009E_000F(this._0001), _0005._0003._0001(InfoList[i].Message, i, this, image));
			global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
			if (InfoList[i].Mode == InfoTypeMode.Warning)
			{
				global::_001F._007E_0007_0005(_0005_0004._007E_0003_0010(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 2)), global::_001E._001F_0004());
			}
			else if (InfoList[i].Mode == InfoTypeMode.Alarm)
			{
				global::_001F._007E_0007_0005(_0005_0004._007E_0003_0010(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 2)), global::_001E._0098_0004());
			}
			else if (InfoList[i].Mode == InfoTypeMode.Message)
			{
				global::_001F._007E_0007_0005(_0005_0004._007E_0003_0010(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), i)), 2)), global::_001E._009E_0004());
			}
		}
		if (global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) <= 0)
		{
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			bool num = (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_ok)) ? 1 : 0);
			while (true)
			{
				bool flag = (byte)num != 0;
				bool num2 = flag;
				bool num3;
				if (0 == 0)
				{
					if (num2)
					{
						Apply();
						PropertiesForm.Result = DialogResult.OK;
						if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
						{
							global::_0011._001D_0003(this);
						}
						num3 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
						if (false)
						{
							goto IL_00ce;
						}
						if (num3)
						{
							global::_0082._0086_0005(this, false);
						}
					}
					num3 = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_close));
					goto IL_00ce;
				}
				goto IL_011b;
				IL_0132:
				bool flag2 = PropertiesForm.FormCloseMode == FormCloseModeType.Invisible;
				num2 = flag2;
				goto IL_0144;
				IL_011b:
				if (8u != 0)
				{
					if (num2)
					{
						global::_0011._001D_0003(this);
					}
					goto IL_0132;
				}
				goto IL_0144;
				IL_0144:
				if (num2)
				{
					if (3u != 0)
					{
						global::_0082._0086_0005(this, false);
						break;
					}
					goto IL_0132;
				}
				break;
				IL_00ce:
				num = num3 | global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_cancel));
				if (false)
				{
					continue;
				}
				if (num)
				{
					PropertiesForm.Result = DialogResult.Cancel;
					num2 = PropertiesForm.FormCloseMode == FormCloseModeType.Dispose;
					goto IL_011b;
				}
				break;
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

	static F_MarbleInfoList()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleInfoList));
		Captions = new List<string>();
	}
}
