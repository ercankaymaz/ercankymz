using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Watch;

public class F_WatchByGrid : Form
{
	public string AddString = "";

	public static List<string> Captions = new List<string>();

	public List<WatchItem> Items = new List<WatchItem>();

	public bool HideNewValueColumb = false;

	public bool HideExplanationColumb = false;

	public bool HideStatusColumb = false;

	private int int_0 = -1;

	private DataColumn dataColumn_0;

	private DataTable dataTable_0 = new DataTable();

	[CompilerGenerated]
	private WatchItemResetClickEventHandler watchItemResetClickEventHandler_0;

	[CompilerGenerated]
	private WatchItemRemoveAllClickEventHandler watchItemRemoveAllClickEventHandler_0;

	[CompilerGenerated]
	private WatchItemRemoveClickEventHandler watchItemRemoveClickEventHandler_0;

	[CompilerGenerated]
	private WatchItemListChangedEventHandler watchItemListChangedEventHandler_0;

	[CompilerGenerated]
	private WatchItemWriteEventHandler watchItemWriteEventHandler_0;

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

	public event WatchItemWriteEventHandler WriteItems
	{
		[CompilerGenerated]
		add
		{
			WatchItemWriteEventHandler watchItemWriteEventHandler = watchItemWriteEventHandler_0;
			WatchItemWriteEventHandler watchItemWriteEventHandler2;
			do
			{
				watchItemWriteEventHandler2 = watchItemWriteEventHandler;
				WatchItemWriteEventHandler value2 = (WatchItemWriteEventHandler)Delegate.Combine(watchItemWriteEventHandler2, value);
				watchItemWriteEventHandler = Interlocked.CompareExchange(ref watchItemWriteEventHandler_0, value2, watchItemWriteEventHandler2);
			}
			while ((object)watchItemWriteEventHandler != watchItemWriteEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WatchItemWriteEventHandler watchItemWriteEventHandler = watchItemWriteEventHandler_0;
			WatchItemWriteEventHandler watchItemWriteEventHandler2;
			do
			{
				watchItemWriteEventHandler2 = watchItemWriteEventHandler;
				WatchItemWriteEventHandler value2 = (WatchItemWriteEventHandler)Delegate.Remove(watchItemWriteEventHandler2, value);
				watchItemWriteEventHandler = Interlocked.CompareExchange(ref watchItemWriteEventHandler_0, value2, watchItemWriteEventHandler2);
			}
			while ((object)watchItemWriteEventHandler != watchItemWriteEventHandler2);
		}
	}

	public F_WatchByGrid()
	{
		Class76.smethod_762(this);
	}

	public void Init()
	{
		try
		{
			dataTable_0 = new DataTable();
			dataColumn_0 = new DataColumn("No", Type.GetType("System.Int32"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Name", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Value", Type.GetType("System.Double"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("New Value", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Min", Type.GetType("System.Double"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Max", Type.GetType("System.Double"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Explanation", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Status", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			DGV.DataSource = dataTable_0;
			DGV.RowHeadersVisible = false;
			DGV.AllowUserToAddRows = false;
			DGV.AllowUserToResizeColumns = true;
			DGV.Columns[0].Width = 40;
			DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[2].Width = 100;
			DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[3].Width = 100;
			DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[4].Width = 100;
			DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[5].Width = 100;
			DGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[6].Width = 120;
			DGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[7].Width = 80;
			DGV.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
			if (HideNewValueColumb)
			{
				DGV.Columns[3].Visible = false;
				DGV.Columns[3].Width = 0;
			}
			if (HideExplanationColumb)
			{
				DGV.Columns[6].Visible = false;
				DGV.Columns[6].Width = 0;
			}
			if (HideStatusColumb)
			{
				DGV.Columns[7].Visible = false;
				DGV.Columns[7].Width = 0;
			}
			int num = base.Width - DGV.Columns[0].Width - DGV.Columns[2].Width - DGV.Columns[3].Width - DGV.Columns[4].Width - DGV.Columns[5].Width - DGV.Columns[6].Width - DGV.Columns[7].Width - btn_add.Width - 25;
			if (num < 200)
			{
				num = 200;
			}
			DGV.Columns[1].Width = num;
			DGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				DataRowCollection rows = dataTable_0.Rows;
				ref DataTable reference = ref dataTable_0;
				WatchItem watchItem_ = Items[i];
				rows.Add(Class76.smethod_300(i + 1, watchItem_, ref reference, this));
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
				if (i <= DGV.Rows.Count - 1)
				{
					if (Convert.ToDouble(DGV.Rows[i].Cells[2].Value) != Items[i].Value)
					{
						DGV.Rows[i].Cells[2].Value = Items[i].Value;
						DGV.Rows[i].Cells[4].Value = Items[i].MinValue;
						DGV.Rows[i].Cells[5].Value = Items[i].MaxValue;
						DGV.Rows[i].Cells[7].Value = Items[i].Status;
					}
					if (!Items[i].CommStatus & (DGV.Rows[i].Cells[2].Style.BackColor == Color.White))
					{
						DGV.Rows[i].Cells[2].Style.BackColor = Color.Red;
						DGV.Rows[i].Cells[7].Value = Items[i].Status;
					}
					if (Items[i].CommStatus & (DGV.Rows[i].Cells[2].Style.BackColor == Color.Red))
					{
						DGV.Rows[i].Cells[2].Style.BackColor = Color.White;
						DGV.Rows[i].Cells[7].Value = Items[i].Status;
					}
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
				Items[e.RowIndex].Name = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				if (watchItemListChangedEventHandler_0 != null)
				{
					watchItemListChangedEventHandler_0(Items);
				}
			}
			if (e.ColumnIndex == 3)
			{
				Items[e.RowIndex].NewValue = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
			DataRowCollection rows = dataTable_0.Rows;
			ref DataTable reference = ref dataTable_0;
			int count = Items.Count;
			WatchItem watchItem_ = Items[Items.Count - 1];
			rows.Add(Class76.smethod_300(count, watchItem_, ref reference, this));
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
				dataTable_0.Rows.RemoveAt(int_0);
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
				dataTable_0.Rows.Clear();
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
			if (watchItemWriteEventHandler_0 != null)
			{
				watchItemWriteEventHandler_0(Items);
				for (int i = 0; i <= Items.Count - 1; i++)
				{
					Items[i].NewValue = "";
					DGV.Rows[i].Cells[3].Value = "";
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

	internal void method_8(object sender, EventArgs e)
	{
		try
		{
			if ((int_0 >= 0) & (int_0 <= DGV.Rows.Count - 1))
			{
				DGV.Rows[int_0].Cells[1].Value = AddString;
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
