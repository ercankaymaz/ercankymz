using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingTable : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<SewingJobItem> SewingTableList = new List<SewingJobItem>();

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal DataGridView dataGridView_0;

	public event OkCommandWithTwoDataEventHandler CellClicked
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public F_SewingTable()
	{
		Class186.smethod_423(this);
	}

	public void Init()
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
		dataGridView_0.Columns.Clear();
		dataGridView_0.Rows.Clear();
		DataGridViewColumn dataGridViewColumn = buControlCommands.DataGridViewColumbSet(50, "No", "No");
		dataGridView_0.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = buControlCommands.DataGridViewColumbSet(130, "X Pos", "X Pos");
		dataGridView_0.Columns.Add(dataGridViewColumn2);
		DataGridViewColumn dataGridViewColumn3 = buControlCommands.DataGridViewColumbSet(130, "Y Pos", "Y Pos");
		dataGridView_0.Columns.Add(dataGridViewColumn3);
		DataGridViewColumn dataGridViewColumn4 = buControlCommands.DataGridViewColumbSet(80, "Speed", "Speed");
		dataGridView_0.Columns.Add(dataGridViewColumn4);
		DataGridViewColumn dataGridViewColumn5 = buControlCommands.DataGridViewColumbSet(80, "FootHeight", "FootHeight");
		dataGridView_0.Columns.Add(dataGridViewColumn5);
		DataGridViewColumn dataGridViewColumn6 = buControlCommands.DataGridViewColumbSet(120, "Type", "Type");
		dataGridView_0.Columns.Add(dataGridViewColumn6);
		DataGridViewColumn dataGridViewColumn7 = buControlCommands.DataGridViewColumbSet(80, "Index", "Index");
		dataGridView_0.Columns.Add(dataGridViewColumn7);
		DataGridViewColumn dataGridViewColumn8 = buControlCommands.DataGridViewColumbSet(70, "Code1", "Code1");
		dataGridView_0.Columns.Add(dataGridViewColumn8);
		DataGridViewColumn dataGridViewColumn9 = buControlCommands.DataGridViewColumbSet(70, "Code2", "Code2");
		dataGridView_0.Columns.Add(dataGridViewColumn9);
		DataGridViewColumn dataGridViewColumn10 = buControlCommands.DataGridViewColumbSet(70, "Code3", "Code3");
		dataGridView_0.Columns.Add(dataGridViewColumn10);
		DataGridViewColumn dataGridViewColumn11 = buControlCommands.DataGridViewColumbSet(70, "Code4", "Code4");
		dataGridView_0.Columns.Add(dataGridViewColumn11);
		DataGridViewColumn dataGridViewColumn12 = buControlCommands.DataGridViewColumbSet(70, "Code5", "Code5");
		dataGridView_0.Columns.Add(dataGridViewColumn12);
		dataGridView_0.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
		dataGridView_0.EnableHeadersVisualStyles = true;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.ColumnHeadersVisible = true;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		int num = 0;
		string text = "";
		for (int i = 0; i <= SewingTableList.Count - 1; i++)
		{
			num++;
			Color white = Color.White;
			if (!SewingTableList[i].StitchedWay)
			{
				text = "Jump";
				num = 0;
				white = Color.DarkOrange;
			}
			else
			{
				text = "Stich";
				white = Color.LightPink;
			}
			DataGridViewRowCollection rows = dataGridView_0.Rows;
			double positionX = SewingTableList[i].PositionX;
			double positionY = SewingTableList[i].PositionY;
			double headSpeed = SewingTableList[i].HeadSpeed;
			double footHeight = SewingTableList[i].FootHeight;
			int code = SewingTableList[i].Code1;
			int code2 = SewingTableList[i].Code2;
			int code3 = SewingTableList[i].Code3;
			int code4 = SewingTableList[i].Code4;
			int code5 = SewingTableList[i].Code5;
			rows.Add(Class186.smethod_665(headSpeed, code5, code4, code3, code2, num, text, positionY, positionX, i + 1, footHeight, code, this));
			dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[5].Style.BackColor = white;
			if (SewingTableList[i].FootHeight != 0.0)
			{
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[4].Style.BackColor = Color.LightGreen;
			}
			if (SewingTableList[i].Code1 != 0)
			{
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[7].Style.BackColor = Color.LightGreen;
			}
			if (SewingTableList[i].Code2 != 0)
			{
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[8].Style.BackColor = Color.LightGreen;
			}
			if (SewingTableList[i].Code3 != 0)
			{
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[9].Style.BackColor = Color.LightGreen;
			}
			if (SewingTableList[i].Code4 != 0)
			{
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[10].Style.BackColor = Color.LightGreen;
			}
			if (SewingTableList[i].Code5 != 0)
			{
				dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[11].Style.BackColor = Color.LightGreen;
			}
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 1)
			{
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
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
		if (okCommandWithTwoDataEventHandler_0 != null && ((e.RowIndex >= 0) & (e.RowIndex <= SewingTableList.Count - 1)))
		{
			okCommandWithTwoDataEventHandler_0(SewingTableList[e.RowIndex], e.RowIndex);
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
