using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Counters;

public class F_Counters : Form
{
	[CompilerGenerated]
	private CounterFileEventHandler counterFileEventHandler_0;

	[CompilerGenerated]
	private CounterFileEventHandler counterFileEventHandler_1;

	[CompilerGenerated]
	private CounterResetEventHandler counterResetEventHandler_0;

	[CompilerGenerated]
	private CounterResetAllEventHandler counterResetAllEventHandler_0;

	[CompilerGenerated]
	private CounterResetEventHandler counterResetEventHandler_1;

	public bool ShowCommunicationAddress = true;

	public DialogResult Result = DialogResult.None;

	private int int_0 = -1;

	private int int_1 = -1;

	private double double_0 = 0.0;

	public List<CounterItem> Counters = new List<CounterItem>();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	public buButton btn_save;

	public buButton btn_load;

	public buButton btn_reset;

	public buButton btn_cancel;

	public buGrid grid_counter;

	public buButton btn_removeall;

	public buButton btn_remove;

	public buButton btn_add;

	public buButton btn_ok;

	internal buGroup buGroup_0;

	public buButton btn_itemclose;

	public buButton btn_itemadd;

	internal buTextBox buTextBox_0;

	public buSpin spn_limit;

	internal buTextBox buTextBox_1;

	public buButton btn_report;

	public buButton btn_resettotalall;

	public buButton btn_resettotal;

	public event CounterFileEventHandler LoadCounter
	{
		[CompilerGenerated]
		add
		{
			CounterFileEventHandler counterFileEventHandler = counterFileEventHandler_0;
			CounterFileEventHandler counterFileEventHandler2;
			do
			{
				counterFileEventHandler2 = counterFileEventHandler;
				CounterFileEventHandler value2 = (CounterFileEventHandler)Delegate.Combine(counterFileEventHandler2, value);
				counterFileEventHandler = Interlocked.CompareExchange(ref counterFileEventHandler_0, value2, counterFileEventHandler2);
			}
			while ((object)counterFileEventHandler != counterFileEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CounterFileEventHandler counterFileEventHandler = counterFileEventHandler_0;
			CounterFileEventHandler counterFileEventHandler2;
			do
			{
				counterFileEventHandler2 = counterFileEventHandler;
				CounterFileEventHandler value2 = (CounterFileEventHandler)Delegate.Remove(counterFileEventHandler2, value);
				counterFileEventHandler = Interlocked.CompareExchange(ref counterFileEventHandler_0, value2, counterFileEventHandler2);
			}
			while ((object)counterFileEventHandler != counterFileEventHandler2);
		}
	}

	public event CounterFileEventHandler SaveCounter
	{
		[CompilerGenerated]
		add
		{
			CounterFileEventHandler counterFileEventHandler = counterFileEventHandler_1;
			CounterFileEventHandler counterFileEventHandler2;
			do
			{
				counterFileEventHandler2 = counterFileEventHandler;
				CounterFileEventHandler value2 = (CounterFileEventHandler)Delegate.Combine(counterFileEventHandler2, value);
				counterFileEventHandler = Interlocked.CompareExchange(ref counterFileEventHandler_1, value2, counterFileEventHandler2);
			}
			while ((object)counterFileEventHandler != counterFileEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CounterFileEventHandler counterFileEventHandler = counterFileEventHandler_1;
			CounterFileEventHandler counterFileEventHandler2;
			do
			{
				counterFileEventHandler2 = counterFileEventHandler;
				CounterFileEventHandler value2 = (CounterFileEventHandler)Delegate.Remove(counterFileEventHandler2, value);
				counterFileEventHandler = Interlocked.CompareExchange(ref counterFileEventHandler_1, value2, counterFileEventHandler2);
			}
			while ((object)counterFileEventHandler != counterFileEventHandler2);
		}
	}

	public event CounterResetEventHandler ResetCounter
	{
		[CompilerGenerated]
		add
		{
			CounterResetEventHandler counterResetEventHandler = counterResetEventHandler_0;
			CounterResetEventHandler counterResetEventHandler2;
			do
			{
				counterResetEventHandler2 = counterResetEventHandler;
				CounterResetEventHandler value2 = (CounterResetEventHandler)Delegate.Combine(counterResetEventHandler2, value);
				counterResetEventHandler = Interlocked.CompareExchange(ref counterResetEventHandler_0, value2, counterResetEventHandler2);
			}
			while ((object)counterResetEventHandler != counterResetEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CounterResetEventHandler counterResetEventHandler = counterResetEventHandler_0;
			CounterResetEventHandler counterResetEventHandler2;
			do
			{
				counterResetEventHandler2 = counterResetEventHandler;
				CounterResetEventHandler value2 = (CounterResetEventHandler)Delegate.Remove(counterResetEventHandler2, value);
				counterResetEventHandler = Interlocked.CompareExchange(ref counterResetEventHandler_0, value2, counterResetEventHandler2);
			}
			while ((object)counterResetEventHandler != counterResetEventHandler2);
		}
	}

	public event CounterResetAllEventHandler ResetTotalAllCounter
	{
		[CompilerGenerated]
		add
		{
			CounterResetAllEventHandler counterResetAllEventHandler = counterResetAllEventHandler_0;
			CounterResetAllEventHandler counterResetAllEventHandler2;
			do
			{
				counterResetAllEventHandler2 = counterResetAllEventHandler;
				CounterResetAllEventHandler value2 = (CounterResetAllEventHandler)Delegate.Combine(counterResetAllEventHandler2, value);
				counterResetAllEventHandler = Interlocked.CompareExchange(ref counterResetAllEventHandler_0, value2, counterResetAllEventHandler2);
			}
			while ((object)counterResetAllEventHandler != counterResetAllEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CounterResetAllEventHandler counterResetAllEventHandler = counterResetAllEventHandler_0;
			CounterResetAllEventHandler counterResetAllEventHandler2;
			do
			{
				counterResetAllEventHandler2 = counterResetAllEventHandler;
				CounterResetAllEventHandler value2 = (CounterResetAllEventHandler)Delegate.Remove(counterResetAllEventHandler2, value);
				counterResetAllEventHandler = Interlocked.CompareExchange(ref counterResetAllEventHandler_0, value2, counterResetAllEventHandler2);
			}
			while ((object)counterResetAllEventHandler != counterResetAllEventHandler2);
		}
	}

	public event CounterResetEventHandler ResetTotalCounter
	{
		[CompilerGenerated]
		add
		{
			CounterResetEventHandler counterResetEventHandler = counterResetEventHandler_1;
			CounterResetEventHandler counterResetEventHandler2;
			do
			{
				counterResetEventHandler2 = counterResetEventHandler;
				CounterResetEventHandler value2 = (CounterResetEventHandler)Delegate.Combine(counterResetEventHandler2, value);
				counterResetEventHandler = Interlocked.CompareExchange(ref counterResetEventHandler_1, value2, counterResetEventHandler2);
			}
			while ((object)counterResetEventHandler != counterResetEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CounterResetEventHandler counterResetEventHandler = counterResetEventHandler_1;
			CounterResetEventHandler counterResetEventHandler2;
			do
			{
				counterResetEventHandler2 = counterResetEventHandler;
				CounterResetEventHandler value2 = (CounterResetEventHandler)Delegate.Remove(counterResetEventHandler2, value);
				counterResetEventHandler = Interlocked.CompareExchange(ref counterResetEventHandler_1, value2, counterResetEventHandler2);
			}
			while ((object)counterResetEventHandler != counterResetEventHandler2);
		}
	}

	public F_Counters()
	{
		Class76.smethod_137(this);
	}

	public void Init(List<CounterItem> counters)
	{
		grid_counter.customColumbs.Clear();
		ColumbProperties columbProperties = new ColumbProperties();
		columbProperties = new ColumbProperties("Name", 320, readOnly: false, Type.GetType("System.String"));
		grid_counter.customColumbs.Add(columbProperties);
		columbProperties = new ColumbProperties("Count", 150, readOnly: true, Type.GetType("System.Double"));
		grid_counter.customColumbs.Add(columbProperties);
		columbProperties = new ColumbProperties("Limit", 150, readOnly: false, Type.GetType("System.Double"));
		grid_counter.customColumbs.Add(columbProperties);
		columbProperties = new ColumbProperties("Previous Count", 150, readOnly: true, Type.GetType("System.Double"));
		grid_counter.customColumbs.Add(columbProperties);
		columbProperties = new ColumbProperties("Total Count", 150, readOnly: true, Type.GetType("System.Double"));
		grid_counter.customColumbs.Add(columbProperties);
		int num = grid_counter.Width - grid_counter.customColumbs[0].Width - grid_counter.customColumbs[1].Width - grid_counter.customColumbs[2].Width - grid_counter.customColumbs[3].Width - grid_counter.customColumbs[4].Width - 20;
		if (num < 40)
		{
			num = 40;
		}
		columbProperties = new ColumbProperties("Reset Date", num, readOnly: true, Type.GetType("System.String"));
		grid_counter.customColumbs.Add(columbProperties);
		grid_counter.Creat();
		grid_counter.Dt.Rows.Clear();
		for (int i = 0; i <= counters.Count - 1; i++)
		{
			grid_counter.AddNewRow(counters[i].Name, counters[i].ActualCount, counters[i].Limit, counters[i].PreviousCount, counters[i].TotalCount, buConversion.DateToString(counters[i].ResetDate));
		}
		Counters.Clear();
		for (int j = 0; j <= counters.Count - 1; j++)
		{
			Counters.Add(new CounterItem(counters[j]));
		}
		Result = DialogResult.Cancel;
		buTextBox_1.Visible = ShowCommunicationAddress;
	}

	public void FieldsToParameter()
	{
		for (int i = 0; i <= grid_counter.Rows.Count - 1; i++)
		{
			if (i <= Counters.Count - 1)
			{
				double result = 0.0;
				Counters[i].Name = grid_counter.Rows[i].Cells[0].Value.ToString();
				if (double.TryParse(grid_counter.Rows[i].Cells[2].Value.ToString(), out result))
				{
					Counters[i].Limit = result;
				}
			}
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_2.Name) | (control.Name == btn_cancel.Name))
			{
				base.Visible = false;
				Result = DialogResult.Cancel;
			}
			if (control.Name == buButton_1.Name)
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_itemadd.Name)
		{
			CounterItem counterItem = new CounterItem(buTextBox_0.Text);
			counterItem.Limit = spn_limit.Value;
			counterItem.Address = buTextBox_1.Text;
			counterItem.ResetDate = DateTime.Now;
			Counters.Add(counterItem);
			grid_counter.AddNewRow(buTextBox_0.Text, 0, spn_limit.Value, 0, 0, buConversion.DateToString(DateTime.Now));
		}
		if (control.Name == btn_itemclose.Name)
		{
			buGroup_0.Visible = false;
		}
		if (control.Name == btn_add.Name && AppSecurity.PasswordLevel >= 1)
		{
			buGroup_0.Visible = true;
		}
		if (control.Name == btn_remove.Name && AppSecurity.PasswordLevel >= 1 && ((int_1 >= 0) & (int_1 <= Counters.Count - 1)) && buString.MessageBoxQuestion(AppLanguage.SystemMessages[7]) == DialogResult.Yes)
		{
			Counters.RemoveAt(int_1);
			grid_counter.Dt.Rows.RemoveAt(int_1);
		}
		if (control.Name == btn_removeall.Name && AppSecurity.PasswordLevel >= 1 && Counters.Count > 0 && buString.MessageBoxQuestion(AppLanguage.SystemMessages[8]) == DialogResult.Yes)
		{
			Counters.Clear();
			grid_counter.Dt.Rows.Clear();
		}
		if (control.Name == btn_ok.Name)
		{
			Result = DialogResult.OK;
			FieldsToParameter();
			base.Visible = false;
		}
		if (control.Name == btn_save.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = AppPath.Counter;
			saveFileDialog.Filter = "Counter Files (*.bucnt)|*.bucnt";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.FileName = "";
			if (Counters.Count > 0 && saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				AppPath.Counter = buFile.GetPath(saveFileDialog.FileName);
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i <= Counters.Count - 1; i++)
				{
					arrayList.AddRange(Counters[i].ToDefAll("", 0, SerilizationMode.MultiLine));
				}
				buFile.SaveToFile(arrayList, saveFileDialog.FileName);
				if (counterFileEventHandler_1 != null)
				{
					FileEventArg e2 = new FileEventArg(saveFileDialog.FileName);
					counterFileEventHandler_1(e2, Counters);
				}
			}
		}
		if (control.Name == btn_load.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = AppPath.Counter;
			openFileDialog.Filter = "Counter Files (*.bucnt)|*.bucnt";
			openFileDialog.FilterIndex = 1;
			openFileDialog.Multiselect = false;
			openFileDialog.FileName = "";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				AppPath.Counter = buFile.GetPath(openFileDialog.FileName);
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
				List<List<string>> CalcList = new List<List<string>>();
				buString.ListToSpecificList("<CounterItem>", "</CounterItem>", AddStartEndKey: true, StringList, ref CalcList);
				if (CalcList.Count > 0)
				{
					Counters.Clear();
				}
				for (int j = 0; j <= CalcList.Count - 1; j++)
				{
					ArrayList arrayList2 = new ArrayList();
					arrayList2.AddRange(CalcList[j].ToArray());
					CounterItem counterItem2 = new CounterItem();
					buSerilization.Decode(arrayList2, "", SerilizationMode.MultiLine, counterItem2);
					Counters.Add(counterItem2);
				}
				grid_counter.Dt.Rows.Clear();
				for (int k = 0; k <= Counters.Count - 1; k++)
				{
					grid_counter.AddNewRow(Counters[k].Name, Counters[k].ActualCount, Counters[k].Limit, Counters[k].PreviousCount, Counters[k].TotalCount, buConversion.DateToString(Counters[k].ResetDate));
				}
				if (counterFileEventHandler_0 != null)
				{
					FileEventArg e3 = new FileEventArg(openFileDialog.FileName);
					counterFileEventHandler_0(e3, Counters);
				}
			}
		}
		if (control.Name == btn_reset.Name)
		{
			if ((int_1 >= 0) & (int_1 <= grid_counter.Rows.Count - 1))
			{
				Counters[int_1].ActualCount = double.Parse(grid_counter.Rows[int_1].Cells[1].Value.ToString());
				Counters[int_1].PreviousCount = Counters[int_1].ActualCount;
				Counters[int_1].TotalCount = Counters[int_1].TotalCount + Counters[int_1].ActualCount;
				Counters[int_1].ActualCount = 0.0;
				Counters[int_1].ResetDate = DateTime.Now;
				grid_counter.Rows[int_1].Cells[3].Value = Counters[int_1].PreviousCount;
				grid_counter.Rows[int_1].Cells[4].Value = Counters[int_1].TotalCount;
				grid_counter.Rows[int_1].Cells[1].Value = Counters[int_1].ActualCount;
				grid_counter.Rows[int_1].Cells[5].Value = buConversion.DateToString(Counters[int_1].ResetDate);
			}
			if (counterResetEventHandler_0 != null)
			{
				counterResetEventHandler_0(int_1, DateTime.Now, Counters[int_1]);
			}
		}
		if (control.Name == btn_resettotal.Name)
		{
			if ((int_1 >= 0) & (int_1 <= grid_counter.Rows.Count - 1))
			{
				Counters[int_1].PreviousCount = 0.0;
				Counters[int_1].TotalCount = 0.0;
				Counters[int_1].ActualCount = 0.0;
				Counters[int_1].ResetDate = DateTime.Now;
				grid_counter.Rows[int_1].Cells[3].Value = Counters[int_1].PreviousCount;
				grid_counter.Rows[int_1].Cells[4].Value = Counters[int_1].TotalCount;
				grid_counter.Rows[int_1].Cells[1].Value = Counters[int_1].ActualCount;
				grid_counter.Rows[int_1].Cells[5].Value = buConversion.DateToString(Counters[int_1].ResetDate);
			}
			if (counterResetEventHandler_1 != null)
			{
				counterResetEventHandler_1(int_1, DateTime.Now, Counters[int_1]);
			}
		}
		if (control.Name == btn_resettotalall.Name)
		{
			for (int l = 0; l <= Counters.Count - 1; l++)
			{
				Counters[l].PreviousCount = 0.0;
				Counters[l].TotalCount = 0.0;
				Counters[l].ActualCount = 0.0;
				Counters[l].ResetDate = DateTime.Now;
				grid_counter.Rows[l].Cells[3].Value = Counters[l].PreviousCount;
				grid_counter.Rows[l].Cells[4].Value = Counters[l].TotalCount;
				grid_counter.Rows[l].Cells[1].Value = Counters[l].ActualCount;
				grid_counter.Rows[l].Cells[5].Value = buConversion.DateToString(Counters[l].ResetDate);
			}
			if (counterResetEventHandler_1 != null)
			{
				counterResetAllEventHandler_0(DateTime.Now, Counters);
			}
		}
	}

	internal void method_2(object sender, DataGridViewCellValidatingEventArgs e)
	{
		try
		{
			buGrid buGrid2 = new buGrid();
			buGrid2 = (buGrid)sender;
			if (buGrid2.Name == grid_counter.Name && e.ColumnIndex == 2)
			{
				if (!buNumeric.IsNumeric(e.FormattedValue.ToString()))
				{
					buString.MessageBoxError(AppLanguage.SystemMessages[11] + " - [ " + e.RowIndex + " , " + e.ColumnIndex + " ]");
					e.Cancel = true;
				}
				else if (e.FormattedValue.ToString().IndexOf(",") < 0)
				{
					double_0 = double.Parse(e.FormattedValue.ToString());
				}
				else
				{
					string s = e.FormattedValue.ToString().Replace(",", ".");
					double_0 = double.Parse(s);
				}
			}
		}
		catch (Exception)
		{
			buString.MessageBoxError(AppLanguage.Messages[11]);
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			buGrid buGrid2 = new buGrid();
			buGrid2 = (buGrid)sender;
			if (buGrid2.Name == grid_counter.Name && e.ColumnIndex == 2)
			{
				grid_counter.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = double_0;
			}
		}
		catch (Exception)
		{
			buString.MessageBoxError(AppLanguage.Messages[3]);
		}
	}

	internal void method_4(object sender, DataGridViewCellEventArgs e)
	{
		buGrid buGrid2 = new buGrid();
		buGrid2 = (buGrid)sender;
		if (buGrid2.Name == grid_counter.Name)
		{
			int_1 = e.RowIndex;
			int_0 = e.ColumnIndex;
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
