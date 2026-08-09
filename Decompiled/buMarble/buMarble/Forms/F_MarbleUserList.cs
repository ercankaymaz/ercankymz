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

namespace buMarble.Forms;

public class F_MarbleUserList : Form
{
	public static List<string> Captions;

	public FormProperties PropertiesForm = new FormProperties();

	public List<UserLoginInfo> UserList = new List<UserLoginInfo>();

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

	[NonSerialized]
	internal static GetString _0086;

	public F_MarbleUserList()
	{
		_0005._0003._0001(this);
	}

	public void Init(List<UserLoginInfo> infoList)
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
				UserList.Add(new UserLoginInfo(infoList[i]));
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
		dataGridViewColumn.Name = _0086(107450757);
		if (5u != 0)
		{
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font(_0086(107372107), 10f, FontStyle.Bold);
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
		dataGridViewColumn2.Name = _0086(107386862);
		dataGridViewColumn2.ReadOnly = false;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font(_0086(107372107), 10f, FontStyle.Bold);
		dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		this._0001.Columns.Add(dataGridViewColumn2);
		DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
		dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewColumn3.Width = 150;
		dataGridViewColumn3.HeaderText = buLangTranslate.preChar.ID;
		dataGridViewColumn3.Name = _0086(107450208);
		dataGridViewColumn3.ReadOnly = false;
		dataGridViewColumn3.DefaultCellStyle.Font = new Font(_0086(107372107), 10f, FontStyle.Bold);
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
				dataGridViewColumn4.Name = _0086(107450203);
				dataGridViewColumn4.ReadOnly = false;
				dataGridViewColumn4.DefaultCellStyle.Font = new Font(_0086(107372107), 10f, FontStyle.Bold);
				dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
				dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				this._0001.Columns.Add(dataGridViewColumn4);
				dataGridViewColumn5 = new DataGridViewColumn();
				dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn5.Width = 60;
				dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Level;
				dataGridViewColumn5.Name = _0086(107450222);
				if (false)
				{
					break;
				}
				dataGridViewColumn5.ReadOnly = false;
				dataGridViewColumn5.DefaultCellStyle.Font = new Font(_0086(107372107), 10f, FontStyle.Bold);
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
		int num = default(int);
		do
		{
			try
			{
				List<UserLoginInfo> userList = UserList;
				if (uint.MaxValue != 0)
				{
					userList.Clear();
				}
				if (false)
				{
					goto IL_0187;
				}
				if (0 == 0)
				{
					num = 0;
				}
				if (0 == 0)
				{
					goto IL_0199;
				}
				goto IL_01de;
				IL_0199:
				bool flag = num <= global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1;
				int num2 = (flag ? 1 : 0);
				if (false)
				{
					goto IL_0198;
				}
				if (num2 != 0)
				{
					goto IL_01de;
				}
				goto end_IL_0001;
				IL_01de:
				UserLoginInfo userLoginInfo = new UserLoginInfo();
				userLoginInfo.UserName = global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 1)));
				userLoginInfo.UserID = _0015_0004._001E_0010(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 2))));
				userLoginInfo.UserPassword = _0015_0004._001E_0010(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 3))));
				userLoginInfo.UserLevel = _0015_0004._001E_0010(global::_0005._007E_001C(global::_0018._007E_0008_0004(_0004_0004._007E_0002_0010(_0003_0004._007E_0001_0010(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), num)), 4))));
				goto IL_0187;
				IL_0198:
				num = num2;
				goto IL_0199;
				IL_0187:
				UserList.Add(userLoginInfo);
				num2 = num + 1;
				goto IL_0198;
				end_IL_0001:;
			}
			catch (Exception)
			{
				if (false)
				{
				}
			}
		}
		while (false);
	}

	public void FillInfo()
	{
		global::_0011 obj = global::_0011._007E_001B_0003;
		DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(this._0001);
		if (3u != 0)
		{
			obj(dataGridViewRowCollection);
		}
		if (UserList != null)
		{
			for (int i = 0; i <= UserList.Count - 1; i++)
			{
				_0005_0005 obj2 = _0005_0005._007E_001B_0011;
				DataGridViewRowCollection dataGridViewRowCollection2 = _0001_0004._007E_009E_000F(this._0001);
				string userName = UserList[i].UserName;
				int userID = UserList[i].UserID;
				int userPassword = UserList[i].UserPassword;
				int userLevel = UserList[i].UserLevel;
				obj2(dataGridViewRowCollection2, _0005._0003._0001(userLevel, userName, userPassword, i + 1, this, userID));
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
			}
		}
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
		try
		{
			Control control = P_0 as Control;
			bool num = global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_add));
			bool flag;
			if (3u != 0)
			{
				flag = num;
			}
			if (flag)
			{
				_0005_0005 obj = _0005_0005._007E_001B_0011;
				DataGridViewRowCollection dataGridViewRowCollection = _0001_0004._007E_009E_000F(this._0001);
				int num2 = global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001));
				string text = _0086(107397800);
				obj(dataGridViewRowCollection, _0005._0003._0001(0, text, 0, num2, this, 0));
				global::_008D._007E_008C_0007(_0002_0004._007E_009F_000F(_0001_0004._007E_009E_000F(this._0001), global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1), 40);
			}
			if (global::_0001._0001(global::_0005._007E_0084(control), global::_0005._007E_0084(btn_remove)))
			{
				bool num3 = (global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) > 0) & (SelectedRow >= 0);
				bool num4 = SelectedRow > global::_000E._007E_0011_0002(_0001_0004._007E_009E_000F(this._0001)) - 1;
				do
				{
					num4 = !num4;
				}
				while (false);
				if (num3 && num4)
				{
					buDialogMessageBoxYesNo buDialogMessageBoxYesNo2 = new buDialogMessageBoxYesNo();
					global::_009C._007E_001A_0008(buDialogMessageBoxYesNo2, FormStartPosition.CenterScreen);
					_000E_0004._007E_000F_0010(buDialogMessageBoxYesNo2, buLangTranslate.preDef.Delete, buLangTranslate.preSentences.DoYouWantToDelete);
					_0008_0004._007E_0008_0010(buDialogMessageBoxYesNo2);
					if (buDialogMessageBoxYesNo2.Result != DialogResult.Yes)
					{
						return;
					}
					global::_008D._007E_008D_0007(_0001_0004._007E_009E_000F(this._0001), SelectedRow);
				}
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
			if (8 == 0)
			{
			}
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
	}

	internal void _0001(object P_0, DataGridViewCellEventArgs P_1)
	{
		SelectedRow = global::_000E._007E_0013_0002(P_1);
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

	static F_MarbleUserList()
	{
		Strings.CreateGetStringDelegate(typeof(F_MarbleUserList));
		Captions = new List<string>();
	}
}
