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
using buMotion;

namespace buMarble.Forms;

public class F_MarbleTechnicianList : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public List<TechnicianLoginInfo> UserList = new List<TechnicianLoginInfo>();

	public int SelectedRow = -1;

	internal IContainer _0001 = null;

	public buButton btn_close;

	public buGround buGround1;

	public buButton btn_ok;

	public buButton btn_cancel;

	internal DataGridView _0001;

	public ImageList IC32;

	public buButton btn_remove;

	public buButton btn_add;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal RadioButton _0003;

	internal RadioButton _0004;

	[NonSerialized]
	internal static GetString _0096;

	public F_MarbleTechnicianList()
	{
		_0005._0003._0001(this);
	}

	public void Init(List<TechnicianLoginInfo> infoList)
	{
		PropertiesForm.Inited = false;
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
			if (8 == 0)
			{
				goto IL_04f8;
			}
		}
		goto IL_0561;
		IL_00ff:
		bool flag = this._0001.Columns.Count == 0;
		goto IL_0114;
		IL_0561:
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		UserList.Clear();
		if (infoList == null)
		{
			goto IL_00bf;
		}
		if (infoList.Count > 0)
		{
			for (int i = 0; i <= infoList.Count - 1; i++)
			{
				UserList.Add(new TechnicianLoginInfo(infoList[i]));
			}
		}
		goto IL_00ff;
		IL_00bf:
		if (0 == 0)
		{
			goto IL_00ff;
		}
		goto IL_0561;
		IL_0114:
		if (!flag)
		{
			goto IL_04cc;
		}
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewColumn.Width = 35;
		dataGridViewColumn.HeaderText = buLangTranslate.preDef.Number;
		dataGridViewColumn.Name = _0096(107450565);
		if (5u != 0)
		{
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font(_0096(107371915), 10f, FontStyle.Bold);
			goto IL_0194;
		}
		goto IL_050c;
		IL_050c:
		if (0 == 0)
		{
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
			_0005._0003._0001(this);
			return;
		}
		goto IL_0194;
		IL_0194:
		if (false)
		{
			goto IL_0114;
		}
		dataGridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		dataGridViewColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		this._0001.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewColumn2.Width = 250;
		dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Name;
		dataGridViewColumn2.Name = _0096(107386670);
		dataGridViewColumn2.ReadOnly = false;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font(_0096(107371915), 10f, FontStyle.Bold);
		dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		this._0001.Columns.Add(dataGridViewColumn2);
		DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
		dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewColumn3.Width = 150;
		dataGridViewColumn3.HeaderText = buLangTranslate.preChar.ID;
		dataGridViewColumn3.Name = _0096(107450016);
		dataGridViewColumn3.ReadOnly = false;
		dataGridViewColumn3.DefaultCellStyle.Font = new Font(_0096(107371915), 10f, FontStyle.Bold);
		DataGridViewColumn dataGridViewColumn5;
		while (true)
		{
			dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this._0001.Columns.Add(dataGridViewColumn3);
			DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
			dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			while (true)
			{
				dataGridViewColumn4.Width = 150;
				dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Password;
				dataGridViewColumn4.Name = _0096(107450011);
				dataGridViewColumn4.ReadOnly = false;
				dataGridViewColumn4.DefaultCellStyle.Font = new Font(_0096(107371915), 10f, FontStyle.Bold);
				dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
				dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				this._0001.Columns.Add(dataGridViewColumn4);
				dataGridViewColumn5 = new DataGridViewColumn();
				dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn5.Width = 60;
				dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Level;
				dataGridViewColumn5.Name = _0096(107450030);
				if (false)
				{
					break;
				}
				dataGridViewColumn5.ReadOnly = false;
				dataGridViewColumn5.DefaultCellStyle.Font = new Font(_0096(107371915), 10f, FontStyle.Bold);
				if (0 == 0)
				{
					goto end_IL_030d;
				}
			}
			continue;
			end_IL_030d:
			break;
		}
		dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
		dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		this._0001.Columns.Add(dataGridViewColumn5);
		goto IL_04cc;
		IL_04cc:
		this._0001.RowHeadersVisible = false;
		this._0001.AllowUserToAddRows = false;
		if (3 == 0)
		{
			goto IL_00bf;
		}
		this._0001.AllowUserToResizeColumns = false;
		goto IL_04f8;
		IL_04f8:
		this._0001.ColumnHeadersVisible = true;
		FillInfo();
		goto IL_050c;
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
		try
		{
			bool flag = default(bool);
			while (true)
			{
				int num = 0;
				if (num != 0)
				{
					goto IL_01c9;
				}
				int num2;
				if (4u != 0)
				{
					num2 = num;
				}
				goto IL_01d0;
				IL_003b:
				bool num3;
				if (num3 != 0)
				{
					if (4 == 0)
					{
						goto IL_0230;
					}
					UserLoginInfo userLoginInfo = new UserLoginInfo();
					UserList[num2].TechName = global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num2)), 1)));
					UserList[num2].TechID = _0015_0004._001E_0010(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num2)), 2))));
					UserList[num2].TechPassword = _0015_0004._001E_0010(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num2)), 3))));
					UserList[num2].TechLevel = _0015_0004._001E_0010(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num2)), 4))));
				}
				num = num2 + 1;
				goto IL_01c9;
				IL_002e:
				flag = num == 0;
				goto IL_0230;
				IL_01c9:
				if (false)
				{
					goto IL_002e;
				}
				num2 = num;
				goto IL_01d0;
				IL_0230:
				num3 = flag;
				goto IL_003b;
				IL_01d0:
				int num4 = ((num2 > global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1) ? 1 : 0);
				int num5 = 0;
				if (num5 == 0)
				{
					num3 = num4 == num5;
					if (8 == 0)
					{
						goto IL_003b;
					}
					if (!num3)
					{
						if (0 == 0)
						{
							break;
						}
						continue;
					}
					num4 = num2;
					num5 = UserList.Count - 1;
				}
				num = ((num4 > num5) ? 1 : 0);
				goto IL_002e;
			}
		}
		catch (Exception)
		{
			while (2 == 0)
			{
			}
		}
	}

	public void FillInfo()
	{
		global::_0011._007E_001B_0003(_0001_0004._007E_009E_000F(this._0001));
		int num;
		if (UserList != null)
		{
			num = 0;
			goto IL_0113;
		}
		goto IL_0137;
		IL_014d:
		bool num2;
		if (num2 == 0)
		{
			return;
		}
		goto IL_0152;
		IL_0113:
		if (3 == 0)
		{
			return;
		}
		bool num3 = num > UserList.Count - 1;
		int num4;
		int num5;
		if (4u != 0)
		{
			if (!num3)
			{
				_0005_0005 obj = _0005_0005._007E_001B_0011;
				DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(this._0001);
				string techName = UserList[num].TechName;
				int techID = UserList[num].TechID;
				int techPassword = UserList[num].TechPassword;
				int techLevel = UserList[num].TechLevel;
				obj(dataGridViewRowCollection, _0005._0003._0001(techName, techID, techPassword, num + 1, techLevel, this));
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
				num4 = num;
				num5 = 1;
				goto IL_010b;
			}
			goto IL_0137;
		}
		goto IL_019e;
		IL_0152:
		if (UserList[0].TechType == TechnicianType.Electrician)
		{
			global::_0082._007E_009E_0005(_0004, true);
			return;
		}
		int num6 = ((UserList[0].TechType == TechnicianType.Mechanic) ? 1 : 0);
		goto IL_019a;
		IL_019e:
		if (num3)
		{
			global::_0082._007E_009E_0005(_0003, true);
			return;
		}
		bool flag = UserList[0].TechType == TechnicianType.TechnicalService;
		num2 = flag;
		if (8 == 0)
		{
			goto IL_014d;
		}
		if (num2)
		{
			global::_0082._007E_009E_0005(this._0002, true);
			return;
		}
		if (UserList[0].TechType == TechnicianType.Supervisor)
		{
			global::_0082._007E_009E_0005(this._0001, true);
			if (0 == 0)
			{
				return;
			}
			goto IL_0152;
		}
		return;
		IL_019a:
		bool flag2 = (byte)num6 != 0;
		num3 = flag2;
		goto IL_019e;
		IL_0137:
		num4 = UserList.Count;
		num5 = 0;
		if (num5 != 0)
		{
			goto IL_010b;
		}
		num6 = ((num4 > num5) ? 1 : 0);
		if (0 == 0)
		{
			bool flag3 = (byte)num6 != 0;
			num2 = flag3;
			goto IL_014d;
		}
		goto IL_019a;
		IL_010b:
		num6 = num4 + num5;
		if (0 == 0)
		{
			num = num6;
			goto IL_0113;
		}
		goto IL_019a;
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_add)))
			{
				TechnicianLoginInfo technicianLoginInfo = new TechnicianLoginInfo();
				_0005_0005 obj = _0005_0005._007E_001B_0011;
				DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(this._0001);
				int num = global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001));
				string techName = technicianLoginInfo.TechName;
				int techID = technicianLoginInfo.TechID;
				int techPassword = technicianLoginInfo.TechPassword;
				int techLevel = technicianLoginInfo.TechLevel;
				obj(dataGridViewRowCollection, _0005._0003._0001(techName, techID, techPassword, num, techLevel, this));
				UserList.Add(technicianLoginInfo);
				global::_0082._007E_009E_0005(this._0002, true);
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_remove)) && ((global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) > 0) & (SelectedRow >= 0) & (SelectedRow <= global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1)))
			{
				buDialogMessageBoxYesNo buDialogMessageBoxYesNo2 = new buDialogMessageBoxYesNo();
				global::_009C._007E_001A_0008(buDialogMessageBoxYesNo2, FormStartPosition.CenterScreen);
				_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo2, buLangTranslate.preDef.Delete, buLangTranslate.preSentences.DoYouWantToDelete);
				_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo2);
				if (buDialogMessageBoxYesNo2.Result != DialogResult.Yes)
				{
					return;
				}
				UserList.RemoveAt(SelectedRow);
				global::_008D._007E_008D_0007(_0001_0004._007E_009E_000F(this._0001), SelectedRow);
			}
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
		SelectedRow = global::_000E._007E_0013_0002(P_1);
		if (6 == 0 || !((SelectedRow >= 0) & (SelectedRow <= UserList.Count - 1)))
		{
			return;
		}
		while (true)
		{
			if (0 == 0)
			{
				if (8u != 0)
				{
					if (UserList[SelectedRow].TechType == TechnicianType.Electrician)
					{
						global::_0082._007E_009E_0005(_0004, true);
						break;
					}
					if (UserList[SelectedRow].TechType == TechnicianType.Mechanic)
					{
						global::_0082._007E_009E_0005(_0003, true);
						if (0 == 0)
						{
							break;
						}
						continue;
					}
					goto IL_00d9;
				}
				goto IL_00f9;
			}
			goto IL_0115;
			IL_0135:
			global::_0082._007E_009E_0005(this._0001, true);
			break;
			IL_00f9:
			global::_0082._007E_009E_0005(this._0002, true);
			if (5u != 0)
			{
				if (0 == 0)
				{
					break;
				}
				goto IL_00d9;
			}
			goto IL_0135;
			IL_0115:
			if (UserList[SelectedRow].TechType != TechnicianType.Supervisor)
			{
				break;
			}
			goto IL_0135;
			IL_00d9:
			if (false)
			{
				break;
			}
			if (UserList[SelectedRow].TechType == TechnicianType.TechnicalService)
			{
				goto IL_00f9;
			}
			goto IL_0115;
		}
	}

	internal void _0002(object P_0, EventArgs P_1)
	{
		while (true)
		{
			Control control = P_0 as Control;
			while (true)
			{
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(_0004)))
				{
					UserList[SelectedRow].TechType = TechnicianType.Electrician;
					if (false)
					{
						goto IL_00d6;
					}
				}
				if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(_0003)))
				{
					if (false)
					{
						goto IL_00ef;
					}
					UserList[SelectedRow].TechType = TechnicianType.Mechanic;
				}
				goto IL_00aa;
				IL_00aa:
				bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(this._0002));
				do
				{
					bool flag = num;
					num = flag;
				}
				while (false);
				if (num)
				{
					goto IL_00d6;
				}
				goto IL_00ef;
				IL_00ef:
				if (-1 == 0)
				{
					break;
				}
				if (!global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(this._0001)))
				{
					return;
				}
				UserList[SelectedRow].TechType = TechnicianType.Supervisor;
				if (0 == 0)
				{
					if (8u != 0)
					{
						return;
					}
					continue;
				}
				goto IL_00aa;
				IL_00d6:
				UserList[SelectedRow].TechType = TechnicianType.TechnicalService;
				goto IL_00ef;
			}
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

	static F_MarbleTechnicianList()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleTechnicianList));
		Captions = new List<string>();
	}
}
