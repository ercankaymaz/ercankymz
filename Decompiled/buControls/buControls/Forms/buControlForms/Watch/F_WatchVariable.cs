using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Watch;

public class F_WatchVariable : Form
{
	public string AddString = "";

	public static List<string> Captions = new List<string>();

	public List<WatchItem> Items = new List<WatchItem>();

	public bool HideNewValueColumb = false;

	public bool HideExplanationColumb = false;

	public bool HideStatusColumb = false;

	public List<string> ConstantStringList = new List<string>();

	private int int_0 = -1;

	[CompilerGenerated]
	private WatchItemResetClickEventHandler watchItemResetClickEventHandler_0;

	[CompilerGenerated]
	private WatchItemRemoveAllClickEventHandler watchItemRemoveAllClickEventHandler_0;

	[CompilerGenerated]
	private WatchItemRemoveClickEventHandler watchItemRemoveClickEventHandler_0;

	[CompilerGenerated]
	private WatchItemListChangedEventHandler watchItemListChangedEventHandler_0;

	[CompilerGenerated]
	private WatchItemWriteSingleEventHandler watchItemWriteSingleEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	public DataGridView DGV;

	internal buButton buButton_2;

	public buButton btn_add;

	public buButton btn_cancel;

	public buButton btn_write;

	public buButton btn_save;

	public buButton btn_load;

	public buButton buButton4;

	public buButton btn_reset;

	public buButton btn_removeall;

	public buButton btn_remove;

	internal buTextBox buTextBox_0;

	public event WatchItemResetClickEventHandler ResetClick
	{
		[CompilerGenerated]
		add
		{
			WatchItemResetClickEventHandler watchItemResetClickEventHandler = watchItemResetClickEventHandler_0;
			WatchItemResetClickEventHandler watchItemResetClickEventHandler2;
			do
			{
				watchItemResetClickEventHandler2 = watchItemResetClickEventHandler;
				WatchItemResetClickEventHandler value2 = (WatchItemResetClickEventHandler)Delegate.Combine(watchItemResetClickEventHandler2, value);
				watchItemResetClickEventHandler = Interlocked.CompareExchange(ref watchItemResetClickEventHandler_0, value2, watchItemResetClickEventHandler2);
			}
			while ((object)watchItemResetClickEventHandler != watchItemResetClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WatchItemResetClickEventHandler watchItemResetClickEventHandler = watchItemResetClickEventHandler_0;
			WatchItemResetClickEventHandler watchItemResetClickEventHandler2;
			do
			{
				watchItemResetClickEventHandler2 = watchItemResetClickEventHandler;
				WatchItemResetClickEventHandler value2 = (WatchItemResetClickEventHandler)Delegate.Remove(watchItemResetClickEventHandler2, value);
				watchItemResetClickEventHandler = Interlocked.CompareExchange(ref watchItemResetClickEventHandler_0, value2, watchItemResetClickEventHandler2);
			}
			while ((object)watchItemResetClickEventHandler != watchItemResetClickEventHandler2);
		}
	}

	public event WatchItemRemoveAllClickEventHandler RemoveAllClick
	{
		[CompilerGenerated]
		add
		{
			WatchItemRemoveAllClickEventHandler watchItemRemoveAllClickEventHandler = watchItemRemoveAllClickEventHandler_0;
			WatchItemRemoveAllClickEventHandler watchItemRemoveAllClickEventHandler2;
			do
			{
				watchItemRemoveAllClickEventHandler2 = watchItemRemoveAllClickEventHandler;
				WatchItemRemoveAllClickEventHandler value2 = (WatchItemRemoveAllClickEventHandler)Delegate.Combine(watchItemRemoveAllClickEventHandler2, value);
				watchItemRemoveAllClickEventHandler = Interlocked.CompareExchange(ref watchItemRemoveAllClickEventHandler_0, value2, watchItemRemoveAllClickEventHandler2);
			}
			while ((object)watchItemRemoveAllClickEventHandler != watchItemRemoveAllClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WatchItemRemoveAllClickEventHandler watchItemRemoveAllClickEventHandler = watchItemRemoveAllClickEventHandler_0;
			WatchItemRemoveAllClickEventHandler watchItemRemoveAllClickEventHandler2;
			do
			{
				watchItemRemoveAllClickEventHandler2 = watchItemRemoveAllClickEventHandler;
				WatchItemRemoveAllClickEventHandler value2 = (WatchItemRemoveAllClickEventHandler)Delegate.Remove(watchItemRemoveAllClickEventHandler2, value);
				watchItemRemoveAllClickEventHandler = Interlocked.CompareExchange(ref watchItemRemoveAllClickEventHandler_0, value2, watchItemRemoveAllClickEventHandler2);
			}
			while ((object)watchItemRemoveAllClickEventHandler != watchItemRemoveAllClickEventHandler2);
		}
	}

	public event WatchItemRemoveClickEventHandler RemoveClick
	{
		[CompilerGenerated]
		add
		{
			WatchItemRemoveClickEventHandler watchItemRemoveClickEventHandler = watchItemRemoveClickEventHandler_0;
			WatchItemRemoveClickEventHandler watchItemRemoveClickEventHandler2;
			do
			{
				watchItemRemoveClickEventHandler2 = watchItemRemoveClickEventHandler;
				WatchItemRemoveClickEventHandler value2 = (WatchItemRemoveClickEventHandler)Delegate.Combine(watchItemRemoveClickEventHandler2, value);
				watchItemRemoveClickEventHandler = Interlocked.CompareExchange(ref watchItemRemoveClickEventHandler_0, value2, watchItemRemoveClickEventHandler2);
			}
			while ((object)watchItemRemoveClickEventHandler != watchItemRemoveClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WatchItemRemoveClickEventHandler watchItemRemoveClickEventHandler = watchItemRemoveClickEventHandler_0;
			WatchItemRemoveClickEventHandler watchItemRemoveClickEventHandler2;
			do
			{
				watchItemRemoveClickEventHandler2 = watchItemRemoveClickEventHandler;
				WatchItemRemoveClickEventHandler value2 = (WatchItemRemoveClickEventHandler)Delegate.Remove(watchItemRemoveClickEventHandler2, value);
				watchItemRemoveClickEventHandler = Interlocked.CompareExchange(ref watchItemRemoveClickEventHandler_0, value2, watchItemRemoveClickEventHandler2);
			}
			while ((object)watchItemRemoveClickEventHandler != watchItemRemoveClickEventHandler2);
		}
	}

	public event WatchItemListChangedEventHandler ListChanged
	{
		[CompilerGenerated]
		add
		{
			WatchItemListChangedEventHandler watchItemListChangedEventHandler = watchItemListChangedEventHandler_0;
			WatchItemListChangedEventHandler watchItemListChangedEventHandler2;
			do
			{
				watchItemListChangedEventHandler2 = watchItemListChangedEventHandler;
				WatchItemListChangedEventHandler value2 = (WatchItemListChangedEventHandler)Delegate.Combine(watchItemListChangedEventHandler2, value);
				watchItemListChangedEventHandler = Interlocked.CompareExchange(ref watchItemListChangedEventHandler_0, value2, watchItemListChangedEventHandler2);
			}
			while ((object)watchItemListChangedEventHandler != watchItemListChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WatchItemListChangedEventHandler watchItemListChangedEventHandler = watchItemListChangedEventHandler_0;
			WatchItemListChangedEventHandler watchItemListChangedEventHandler2;
			do
			{
				watchItemListChangedEventHandler2 = watchItemListChangedEventHandler;
				WatchItemListChangedEventHandler value2 = (WatchItemListChangedEventHandler)Delegate.Remove(watchItemListChangedEventHandler2, value);
				watchItemListChangedEventHandler = Interlocked.CompareExchange(ref watchItemListChangedEventHandler_0, value2, watchItemListChangedEventHandler2);
			}
			while ((object)watchItemListChangedEventHandler != watchItemListChangedEventHandler2);
		}
	}

	public event WatchItemWriteSingleEventHandler WriteItem
	{
		[CompilerGenerated]
		add
		{
			WatchItemWriteSingleEventHandler watchItemWriteSingleEventHandler = watchItemWriteSingleEventHandler_0;
			WatchItemWriteSingleEventHandler watchItemWriteSingleEventHandler2;
			do
			{
				watchItemWriteSingleEventHandler2 = watchItemWriteSingleEventHandler;
				WatchItemWriteSingleEventHandler value2 = (WatchItemWriteSingleEventHandler)Delegate.Combine(watchItemWriteSingleEventHandler2, value);
				watchItemWriteSingleEventHandler = Interlocked.CompareExchange(ref watchItemWriteSingleEventHandler_0, value2, watchItemWriteSingleEventHandler2);
			}
			while ((object)watchItemWriteSingleEventHandler != watchItemWriteSingleEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WatchItemWriteSingleEventHandler watchItemWriteSingleEventHandler = watchItemWriteSingleEventHandler_0;
			WatchItemWriteSingleEventHandler watchItemWriteSingleEventHandler2;
			do
			{
				watchItemWriteSingleEventHandler2 = watchItemWriteSingleEventHandler;
				WatchItemWriteSingleEventHandler value2 = (WatchItemWriteSingleEventHandler)Delegate.Remove(watchItemWriteSingleEventHandler2, value);
				watchItemWriteSingleEventHandler = Interlocked.CompareExchange(ref watchItemWriteSingleEventHandler_0, value2, watchItemWriteSingleEventHandler2);
			}
			while ((object)watchItemWriteSingleEventHandler != watchItemWriteSingleEventHandler2);
		}
	}

	public F_WatchVariable()
	{
		Class76.smethod_543(this);
	}

	public void Init()
	{
		try
		{
			DGV.RowHeadersVisible = false;
			DGV.ColumnHeadersVisible = false;
			DGV.AllowUserToAddRows = false;
			DGV.AllowUserToResizeColumns = false;
			DGV.AllowUserToResizeRows = false;
			DGV.Rows.Clear();
			DGV.Columns.Clear();
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.Width = 50;
			dataGridViewColumn.HeaderText = "No";
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			DGV.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.Width = 400;
			dataGridViewColumn2.HeaderText = "Name";
			dataGridViewColumn2.Name = "Name";
			dataGridViewColumn2.ReadOnly = false;
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			DGV.Columns.Add(dataGridViewColumn2);
			DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
			dataGridViewColumn3.Width = 200;
			dataGridViewColumn3.HeaderText = "Value";
			dataGridViewColumn3.Name = "Value";
			dataGridViewColumn3.ReadOnly = true;
			dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
			dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			DGV.Columns.Add(dataGridViewColumn3);
			DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
			dataGridViewComboBoxColumn.Width = 140;
			dataGridViewComboBoxColumn.HeaderText = "Type";
			dataGridViewComboBoxColumn.Name = "Type";
			dataGridViewComboBoxColumn.ReadOnly = true;
			dataGridViewComboBoxColumn.DataSource = Enum.GetValues(typeof(VariableType));
			dataGridViewComboBoxColumn.ValueType = typeof(VariableType);
			dataGridViewComboBoxColumn.DefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
			dataGridViewComboBoxColumn.ReadOnly = false;
			DGV.Columns.Add(dataGridViewComboBoxColumn);
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				DGV.Rows.Add((i + 1).ToString(), Items[i].Name, Items[i].Value.ToString(), Items[i].VarType);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 0)
			{
				Text = Captions[0];
				btn_reset.Text = Captions[0];
				btn_write.Text = Captions[0];
				btn_add.Text = Captions[0];
				btn_remove.Text = Captions[0];
				btn_removeall.Text = Captions[0];
				btn_save.Text = Captions[0];
				btn_cancel.Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void UpdateWatchList(List<WatchItem> Items)
	{
		try
		{
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				if (i > DGV.Rows.Count - 1)
				{
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			int_0 = e.RowIndex;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (!((e.RowIndex >= 0) & (e.RowIndex <= Items.Count - 1)))
			{
				return;
			}
			if (e.ColumnIndex == 1)
			{
				Items[e.RowIndex].Name = DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
				Items[e.RowIndex].VarType = (VariableType)DGV.Rows[e.RowIndex].Cells[3].Value;
				if (watchItemListChangedEventHandler_0 != null)
				{
					watchItemListChangedEventHandler_0(Items);
				}
			}
			if (e.ColumnIndex == 3)
			{
				Items[e.RowIndex].Name = DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
				Items[e.RowIndex].VarType = (VariableType)DGV.Rows[e.RowIndex].Cells[3].Value;
				if (watchItemListChangedEventHandler_0 != null)
				{
					watchItemListChangedEventHandler_0(Items);
				}
			}
			btn_write.Focus();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			if (watchItemResetClickEventHandler_0 != null)
			{
				watchItemResetClickEventHandler_0();
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Application.StartupPath;
			saveFileDialog.Filter = "Watch Item Files (*.watch)|*.watch";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.FileName = "";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				List<string> list = new List<string>();
				string text = "";
				text = "Name ; Value ; MinValue ; MaxValue ; AvarageValue ; Explanation";
				list.Add(text);
				for (int i = 0; i <= Items.Count - 1; i++)
				{
					text = Items[i].Name + " ; " + Items[i].Value + " ; " + Items[i].MinValue + " ; " + Items[i].MaxValue + " ; " + Items[i].AvarageValue + " ; " + Items[i].Explanation;
					list.Add(text);
				}
				buFile.SaveToFile(list, saveFileDialog.FileName);
			}
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			Items.Add(new WatchItem());
			DGV.Rows.Add(Items.Count, "", "", Items[Items.Count - 1].VarType);
			if (DGV.Rows.Count > 0)
			{
				DGV.Rows[DGV.Rows.Count - 1].Cells[2].Style.BackColor = Color.White;
			}
			if (watchItemListChangedEventHandler_0 != null)
			{
				watchItemListChangedEventHandler_0(Items);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			string text = "Do You Want to Remove";
			if (AppLanguage.SystemMessages.Count >= 8)
			{
				text = AppLanguage.SystemMessages[7];
			}
			if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.No && ((int_0 >= 0) & (int_0 <= Items.Count - 1)))
			{
				DGV.Rows.RemoveAt(int_0);
				Items.RemoveAt(int_0);
				if (watchItemListChangedEventHandler_0 != null)
				{
					watchItemListChangedEventHandler_0(Items);
				}
				if (watchItemRemoveClickEventHandler_0 != null)
				{
					watchItemRemoveClickEventHandler_0(int_0);
				}
			}
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		try
		{
			string text = "Do You Want to Remove All";
			if (AppLanguage.SystemMessages.Count >= 9)
			{
				text = AppLanguage.SystemMessages[8];
			}
			if (MessageBox.Show(text, Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.No)
			{
				DGV.Rows.Clear();
				Items.Clear();
				if (watchItemListChangedEventHandler_0 != null)
				{
					watchItemListChangedEventHandler_0(Items);
				}
				if (watchItemRemoveAllClickEventHandler_0 != null)
				{
					watchItemRemoveAllClickEventHandler_0();
				}
			}
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		try
		{
			if (watchItemWriteSingleEventHandler_0 != null)
			{
				WatchItem watchItem = new WatchItem(Items[int_0]);
				watchItem.NewValue = buTextBox_0.Text;
				watchItemWriteSingleEventHandler_0(watchItem);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		try
		{
			if (ConstantStringList.Count > 0)
			{
				DialogBoxList dialogBoxList = new DialogBoxList();
				for (int i = 0; i <= ConstantStringList.Count - 1; i++)
				{
					dialogBoxList.Items.Add(ConstantStringList[i]);
				}
				dialogBoxList.Init();
				dialogBoxList.ShowDialog();
				if (dialogBoxList.Result == DialogResult.OK && ((int_0 >= 0) & (int_0 <= DGV.Rows.Count - 1)))
				{
					DGV.Rows[int_0].Cells[1].Value = dialogBoxList.SelectedItemText;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_1.Name) | (control.Name == btn_cancel.Name))
			{
				base.Visible = false;
			}
			if (control.Name == buButton_0.Name)
			{
				base.WindowState = FormWindowState.Minimized;
			}
			if (control.Name == buButton_2.Name)
			{
				if (base.WindowState != FormWindowState.Maximized)
				{
					base.WindowState = FormWindowState.Maximized;
				}
				else
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
