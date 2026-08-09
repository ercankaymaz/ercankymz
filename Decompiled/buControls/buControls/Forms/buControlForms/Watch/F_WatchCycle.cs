using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Watch;

public class F_WatchCycle : Form
{
	public string AddString = "";

	public static List<string> Captions = new List<string>();

	public List<WatchItem> Items = new List<WatchItem>();

	private DataColumn dataColumn_0;

	private DataTable dataTable_0 = new DataTable();

	private int int_0 = -1;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private IContainer icontainer_0 = null;

	public DataGridView DGV;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buButton buButton_3;

	internal buButton buButton_4;

	internal buButton buButton_5;

	public event EventHandler ResetClick
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public F_WatchCycle()
	{
		Class76.smethod_132(this);
	}

	public void Init()
	{
		try
		{
			dataTable_0 = new DataTable();
			dataColumn_0 = new DataColumn("No", Type.GetType("System.Int32"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Program", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Task", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Value", Type.GetType("System.Double"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Min", Type.GetType("System.Double"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Max", Type.GetType("System.Double"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Counter", Type.GetType("System.Int32"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Explanation", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			DGV.DataSource = dataTable_0;
			DGV.RowHeadersVisible = false;
			DGV.AllowUserToAddRows = false;
			DGV.AllowUserToResizeColumns = true;
			DGV.Columns[0].Width = 40;
			DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[2].Width = 120;
			DGV.Columns[3].Width = 80;
			DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[4].Width = 80;
			DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[5].Width = 80;
			DGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[6].Width = 80;
			DGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[7].Width = 150;
			DGV.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
			int num = base.Width - DGV.Columns[0].Width - DGV.Columns[1].Width - DGV.Columns[3].Width - DGV.Columns[4].Width - DGV.Columns[5].Width - DGV.Columns[6].Width - DGV.Columns[7].Width - 25;
			if (num < 200)
			{
				num = 200;
			}
			DGV.Columns[1].Width = num;
			for (int i = 0; i <= Items.Count - 1; i++)
			{
				DataRowCollection rows = dataTable_0.Rows;
				ref DataTable reference = ref dataTable_0;
				WatchItem watchItem_ = Items[i];
				rows.Add(Class76.smethod_372(watchItem_, ref reference, i + 1, this));
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
				buButton_2.Text = Captions[0];
				buButton_1.Text = Captions[0];
				buButton_3.Text = Captions[0];
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
					DGV.Rows[i].Cells[1].Value = Items[i].Task;
					DGV.Rows[i].Cells[2].Value = Items[i].Program;
					DGV.Rows[i].Cells[3].Value = Items[i].Value;
					DGV.Rows[i].Cells[4].Value = Items[i].MinValue;
					DGV.Rows[i].Cells[5].Value = Items[i].MaxValue;
					DGV.Rows[i].Cells[6].Value = Items[i].Counter;
					DGV.Rows[i].Cells[7].Value = Items[i].Explanation;
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

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(buButton_2, new EventArgs());
			}
			SendKeys.Send("{ESC}");
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

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_5.Name) | (control.Name == buButton_3.Name))
			{
				base.Visible = false;
			}
			if (control.Name == buButton_4.Name)
			{
				base.WindowState = FormWindowState.Minimized;
			}
			if (control.Name == buButton_0.Name)
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
