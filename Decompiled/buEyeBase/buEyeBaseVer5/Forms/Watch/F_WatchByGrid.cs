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
using buCore;
using ns71;

namespace buEyeBaseVer5.Forms.Watch;

public class F_WatchByGrid : Form
{
	public string AddString = "";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public List<WatchItem> Items = new List<WatchItem>();

	public bool HideNewValueColumb = false;

	public bool HideExplanationColumb = true;

	public bool HideStatusColumb = true;

	public bool HideMinVal = false;

	public bool HideMaxVal = false;

	public bool Editing = false;

	private int int_0 = -1;

	private int int_1 = -1;

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

	public DataGridView DGV;

	public buButton btn_add;

	public buButton btn_cancel;

	public buButton btn_write;

	public buButton btn_save;

	public buButton btn_load;

	public buButton btn_addstring;

	public buButton btn_reset;

	public buButton btn_removeall;

	public buButton btn_remove;

	public buButton btn_minimize;

	public buButton btn_maximize;

	public buButton btn_closecross;

	internal buGround buGround_1;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal RadioButton radioButton_3;

	internal RadioButton radioButton_4;

	public buButton btn_varok;

	public buButton btn_varclose;

	internal buGround buGround_2;

	public buButton btnN_stringglobal;

	public buButton btn_cancelstring;

	public buButton btn_stringIO;

	public buButton btn_stringpersist;

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
		Class186.smethod_307(this);
	}

	public void Init()
	{
		try
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
			DGV.Columns.Clear();
			if (DGV.Columns.Count == 0)
			{
				DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn.Width = 40;
				dataGridViewColumn.HeaderText = buLangTranslate.preDef.No;
				dataGridViewColumn.Name = "No";
				dataGridViewColumn.ReadOnly = true;
				dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn);
				DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
				dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn2.Width = 400;
				dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Name;
				dataGridViewColumn2.Name = buLangTranslate.preDef.Name;
				dataGridViewColumn2.ReadOnly = false;
				dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn2);
				DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
				dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn3.Width = 100;
				dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Value;
				dataGridViewColumn3.Name = buLangTranslate.preDef.Value;
				dataGridViewColumn3.ReadOnly = false;
				dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn3);
				DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
				dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn4.Width = 100;
				dataGridViewColumn4.HeaderText = buLangTranslate.preDef.New + " " + buLangTranslate.preDef.Value;
				dataGridViewColumn4.Name = buLangTranslate.preDef.New + " " + buLangTranslate.preDef.Value;
				dataGridViewColumn4.ReadOnly = false;
				dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn4);
				DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
				dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn5.Width = 80;
				dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Type;
				dataGridViewColumn5.Name = buLangTranslate.preDef.Type;
				dataGridViewColumn5.ReadOnly = false;
				dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn5);
				DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
				dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn6.Width = 80;
				dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Min;
				dataGridViewColumn6.Name = buLangTranslate.preDef.Min;
				dataGridViewColumn6.ReadOnly = false;
				dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn6.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn6);
				DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
				dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn7.Width = 80;
				dataGridViewColumn7.HeaderText = buLangTranslate.preDef.Max;
				dataGridViewColumn7.Name = buLangTranslate.preDef.Max;
				dataGridViewColumn7.ReadOnly = false;
				dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn7.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn7);
				DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
				dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn8.Width = 100;
				dataGridViewColumn8.HeaderText = buLangTranslate.preDef.Explanation;
				dataGridViewColumn8.Name = buLangTranslate.preDef.Explanation;
				dataGridViewColumn8.ReadOnly = false;
				dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn8.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn8);
				DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
				dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
				dataGridViewColumn9.Width = 100;
				dataGridViewColumn9.HeaderText = buLangTranslate.preDef.Status;
				dataGridViewColumn9.Name = buLangTranslate.preDef.Status;
				dataGridViewColumn9.ReadOnly = false;
				dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
				dataGridViewColumn9.CellTemplate = new DataGridViewTextBoxCell();
				DGV.Columns.Add(dataGridViewColumn9);
			}
			DGV.RowHeadersVisible = false;
			DGV.AllowUserToAddRows = false;
			DGV.AllowUserToResizeColumns = true;
			if (HideNewValueColumb)
			{
				DGV.Columns[3].Visible = false;
				DGV.Columns[3].Width = 0;
			}
			if (HideExplanationColumb)
			{
				DGV.Columns[7].Visible = false;
				DGV.Columns[7].Width = 0;
			}
			if (HideStatusColumb)
			{
				DGV.Columns[8].Visible = false;
				DGV.Columns[8].Width = 0;
			}
			if (HideMaxVal)
			{
				DGV.Columns[6].Visible = false;
				DGV.Columns[6].Width = 0;
			}
			if (HideMinVal)
			{
				DGV.Columns[5].Visible = false;
				DGV.Columns[5].Width = 0;
			}
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				DataGridViewRowCollection rows = DGV.Rows;
				string name = Items[i].Name;
				string string_ = Items[i].ValueString.ToString();
				string string_2 = "";
				string string_3 = Items[i].VarType.ToString();
				string string_4 = "";
				string string_5 = "";
				string explanation = Items[i].Explanation;
				string string_6 = "";
				rows.Add(Class186.smethod_262(string_4, explanation, this, i + 1, string_, string_5, string_3, string_6, name, string_2));
			}
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
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

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void UpdateWatchList(List<WatchItem> Items)
	{
		try
		{
			if (Editing)
			{
				return;
			}
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				if (i <= DGV.Rows.Count - 1)
				{
					if (DGV.Rows[i].Cells[2].Value.ToString() != Items[i].ValueString.ToString())
					{
						DGV.Rows[i].Cells[2].Value = Items[i].ValueString.ToString();
						DGV.Rows[i].Cells[5].Value = Items[i].MinValue.ToString();
						DGV.Rows[i].Cells[6].Value = Items[i].MaxValue.ToString();
						DGV.Rows[i].Cells[8].Value = Items[i].Status.ToString();
					}
					DGV.Rows[i].Cells[8].Value = Items[i].Status;
					if (Items[i].CommStatus)
					{
						DGV.Rows[i].Cells[2].Style.BackColor = Color.White;
					}
					else
					{
						DGV.Rows[i].Cells[2].Style.BackColor = Color.LightCoral;
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

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			int_0 = e.RowIndex;
			int_1 = e.ColumnIndex;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
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

	internal void method_3(object sender, EventArgs e)
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

	internal void method_4(object sender, EventArgs e)
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

	internal void method_5(object sender, EventArgs e)
	{
		try
		{
			Items.Add(new WatchItem());
			DataGridViewRowCollection rows = DGV.Rows;
			int count = Items.Count;
			string string_ = "";
			string string_2 = "";
			string string_3 = "";
			string string_4 = "Bool";
			string string_5 = "";
			string string_6 = "";
			string string_7 = "";
			string string_8 = "";
			rows.Add(Class186.smethod_262(string_5, string_7, this, count, string_2, string_6, string_4, string_8, string_, string_3));
			if (DGV.Rows.Count <= 0)
			{
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

	internal void method_6(object sender, EventArgs e)
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

	internal void method_7(object sender, EventArgs e)
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

	internal void method_8(object sender, EventArgs e)
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

	internal void method_9(object sender, EventArgs e)
	{
		try
		{
			buGround_2.Visible = true;
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

	internal void method_10(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == btn_closecross.Name) | (control.Name == btn_cancel.Name))
			{
				base.Visible = false;
			}
			if (control.Name == btn_minimize.Name)
			{
				base.WindowState = FormWindowState.Minimized;
			}
			if (control.Name == btn_maximize.Name)
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

	internal void method_11(object sender, DataGridViewCellEventArgs e)
	{
		if (int_1 == 4)
		{
			buGround_1.Visible = true;
			SetVarType(Items[int_0].VarType);
		}
	}

	internal void method_12(object sender, EventArgs e)
	{
		if ((int_0 >= 0) & (int_0 <= Items.Count - 1))
		{
			Items[int_0].VarType = GetVarType();
			Items[int_0].MinValue = 0.0;
			Items[int_0].MaxValue = 0.0;
			DGV.Rows[int_0].Cells[4].Value = Items[int_0].VarType.ToString();
			if (watchItemListChangedEventHandler_0 != null)
			{
				watchItemListChangedEventHandler_0(Items);
			}
			buGround_1.Visible = false;
		}
	}

	public void SetVarType(VariableType Var)
	{
		if (Var == VariableType.Bool)
		{
			radioButton_2.Checked = true;
		}
		if (Var == VariableType.DINT)
		{
			radioButton_3.Checked = true;
		}
		if (Var == VariableType.INT)
		{
			radioButton_4.Checked = true;
		}
		if (Var == VariableType.REAL)
		{
			radioButton_1.Checked = true;
		}
		if (Var == VariableType.LREAL)
		{
			radioButton_0.Checked = true;
		}
	}

	public VariableType GetVarType()
	{
		if (!radioButton_3.Checked)
		{
			if (!radioButton_4.Checked)
			{
				if (!radioButton_1.Checked)
				{
					if (!radioButton_0.Checked)
					{
						if (!radioButton_2.Checked)
						{
							return VariableType.Bool;
						}
						return VariableType.Bool;
					}
					return VariableType.LREAL;
				}
				return VariableType.REAL;
			}
			return VariableType.INT;
		}
		return VariableType.DINT;
	}

	internal void method_13(object sender, EventArgs e)
	{
		buGround_2.Visible = false;
	}

	internal void method_14(object sender, EventArgs e)
	{
		if ((int_0 >= 0) & (int_0 <= Items.Count - 1))
		{
			DGV.Rows[int_0].Cells[1].Value = btnN_stringglobal.Text.Trim();
			buGround_2.Visible = false;
		}
	}

	internal void method_15(object sender, EventArgs e)
	{
		if ((int_0 >= 0) & (int_0 <= Items.Count - 1))
		{
			DGV.Rows[int_0].Cells[1].Value = btn_stringpersist.Text.Trim();
			buGround_2.Visible = false;
		}
	}

	internal void method_16(object sender, EventArgs e)
	{
		if ((int_0 >= 0) & (int_0 <= Items.Count - 1))
		{
			DGV.Rows[int_0].Cells[1].Value = btn_stringIO.Text.Trim();
			buGround_2.Visible = false;
		}
	}

	internal void method_17(object sender, DataGridViewCellCancelEventArgs e)
	{
		Editing = true;
	}

	internal void method_18(object sender, DataGridViewCellEventArgs e)
	{
		Editing = false;
	}

	internal void method_19(object sender, DataGridViewCellEventArgs e)
	{
		Editing = false;
	}

	internal void method_20(object sender, EventArgs e)
	{
		buGround_1.Visible = false;
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
