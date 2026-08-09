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
using buControls.Forms.WinControlForms.Variable;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Watch;

public class F_WatchCodesysVars : Form
{
	public FormProperties Properties = new FormProperties();

	public bool HideExplanationColumb = false;

	public bool HideStatusColumb = false;

	public List<WatchItem> AllItems = new List<WatchItem>();

	public List<WatchItem> Items = new List<WatchItem>();

	public static List<string> Captions = new List<string>();

	public static string strRemove = "Do you want to remove variable?";

	[CompilerGenerated]
	private WatchItemWriteEventHandler watchItemWriteEventHandler_0;

	private int int_0 = -1;

	private DataColumn dataColumn_0;

	private DataTable dataTable_0 = new DataTable();

	internal IContainer icontainer_0 = null;

	public DataGridView DGV;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal ImageList imageList_0;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	public event WatchItemWriteEventHandler WriteVariable
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

	public F_WatchCodesysVars()
	{
		Class76.smethod_268(this);
	}

	public void Init()
	{
		try
		{
			Properties.Inited = false;
			if (Properties.Height > 10)
			{
				base.Height = Properties.Height;
			}
			if (Properties.Width > 10)
			{
				base.Width = Properties.Width;
			}
			base.TopMost = Properties.TopMost;
			base.StartPosition = Properties.FormPosition;
			base.AutoScaleMode = Properties.ScaleFromMode;
			dataTable_0 = new DataTable();
			dataColumn_0 = new DataColumn("No", Type.GetType("System.Int32"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Name", Type.GetType("System.String"));
			dataTable_0.Columns.Add(dataColumn_0);
			dataColumn_0 = new DataColumn("Value", Type.GetType("System.Double"));
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
			DGV.Columns[0].Width = 60;
			DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[2].Width = 100;
			DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[3].Width = 100;
			DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[4].Width = 100;
			DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[5].Width = 120;
			DGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
			DGV.Columns[6].Width = 80;
			DGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
			if (HideExplanationColumb)
			{
				DGV.Columns[5].Visible = false;
				DGV.Columns[5].Width = 0;
			}
			if (HideStatusColumb)
			{
				DGV.Columns[6].Visible = false;
				DGV.Columns[6].Width = 0;
			}
			int num = base.Width - DGV.Columns[0].Width - DGV.Columns[2].Width - DGV.Columns[3].Width - DGV.Columns[4].Width - DGV.Columns[5].Width - DGV.Columns[6].Width - 40;
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
				rows.Add(Class76.smethod_232(watchItem_, ref reference, this, i + 1));
			}
			Properties.Result = DialogResult.None;
			Properties.Inited = true;
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
					DGV.Rows[i].Cells[2].Value = Items[i].Value;
					DGV.Rows[i].Cells[3].Value = Items[i].MinValue;
					DGV.Rows[i].Cells[4].Value = Items[i].MaxValue;
					DGV.Rows[i].Cells[6].Value = Items[i].Status;
					if (!Items[i].CommStatus & (DGV.Rows[i].Cells[2].Style.BackColor == Color.White))
					{
						DGV.Rows[i].Cells[2].Style.BackColor = Color.Red;
					}
					if (Items[i].CommStatus & (DGV.Rows[i].Cells[2].Style.BackColor != Color.White))
					{
						DGV.Rows[i].Cells[2].Style.BackColor = Color.White;
					}
					DGV.Rows[i].Cells[6].Value = Items[i].Status;
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

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			F_VariableAdd f_VariableAdd = new F_VariableAdd();
			for (int i = 0; i <= AllItems.Count - 1; i++)
			{
				f_VariableAdd.Variables.Add(new WatchItem(AllItems[i]));
			}
			f_VariableAdd.Init();
			f_VariableAdd.StartPosition = FormStartPosition.CenterParent;
			f_VariableAdd.ShowDialog(this);
			if (f_VariableAdd.Properties.Result == DialogResult.OK)
			{
				WatchItem watchItem = new WatchItem(f_VariableAdd.SelectedVariables);
				watchItem.VarType = f_VariableAdd.VarType;
				Items.Add(watchItem);
				DataRowCollection rows = dataTable_0.Rows;
				ref DataTable reference = ref dataTable_0;
				int count = Items.Count;
				WatchItem watchItem_ = Items[Items.Count - 1];
				rows.Add(Class76.smethod_232(watchItem_, ref reference, this, count));
			}
		}
		if (control.Name == button_1.Name && ((int_0 >= 0) & (int_0 <= Items.Count - 1)) && buString.MessageBoxQuestion(strRemove) == DialogResult.Yes)
		{
			Items.RemoveAt(int_0);
			dataTable_0.Rows.RemoveAt(int_0);
		}
		if (control.Name == button_5.Name && ((int_0 >= 0) & (int_0 <= Items.Count - 1)))
		{
			F_VariableWrite f_VariableWrite = new F_VariableWrite();
			f_VariableWrite.Variable = new WatchItem(Items[int_0]);
			f_VariableWrite.Init();
			f_VariableWrite.StartPosition = FormStartPosition.CenterParent;
			f_VariableWrite.ShowDialog(this);
			if (f_VariableWrite.Properties.Result == DialogResult.OK && watchItemWriteEventHandler_0 != null)
			{
				List<WatchItem> list = new List<WatchItem>();
				list.Add(f_VariableWrite.Variable);
				watchItemWriteEventHandler_0(list);
			}
		}
		if (control.Name == button_4.Name)
		{
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		int_0 = e.RowIndex;
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
