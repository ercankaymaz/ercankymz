using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestOnlineCalc : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_1;

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_2;

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_0;

	[CompilerGenerated]
	private OkCommandEventHandler okCommandEventHandler_1;

	public buNestingVar SettingsPar = new buNestingVar();

	public int SelectedResultIndex = 0;

	public int SelectedSheetIndex = 0;

	public int SelectedPartIndex = 0;

	private string string_0 = "";

	internal IContainer icontainer_0 = null;

	public TreeView treeView1;

	internal ImageList imageList_0;

	internal Label label_0;

	public Button btn_preview;

	public Button btn_close;

	public TextBox txt_bestcount;

	public ProgressBar progress_execution;

	public Button btn_send;

	public Button btn_stop;

	public Label lbl_persentage;

	public TextBox txt_time;

	internal Label label_1;

	public Label lbl_status;

	internal Panel panel_0;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal CheckBox checkBox_0;

	public Button btn_settings;

	internal Panel panel_1;

	public Button btn_closesettings;

	internal Label label_2;

	internal RadioButton radioButton_2;

	public event OkCommandWithDataEventHandler PreviewPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public event OkCommandWithDataEventHandler SendPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_1;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_1, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_1;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_1, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public event OkCommandWithDataEventHandler Applied
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_2;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_2, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_2;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_2, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public event OkCommandEventHandler StopPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Combine(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_0;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Remove(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_0, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
	}

	public event OkCommandEventHandler ClosedPressed
	{
		[CompilerGenerated]
		add
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_1;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Combine(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_1, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandEventHandler okCommandEventHandler = okCommandEventHandler_1;
			OkCommandEventHandler okCommandEventHandler2;
			do
			{
				okCommandEventHandler2 = okCommandEventHandler;
				OkCommandEventHandler value2 = (OkCommandEventHandler)Delegate.Remove(okCommandEventHandler2, value);
				okCommandEventHandler = Interlocked.CompareExchange(ref okCommandEventHandler_1, value2, okCommandEventHandler2);
			}
			while ((object)okCommandEventHandler != okCommandEventHandler2);
		}
	}

	public F_NestOnlineCalc()
	{
		Class186.smethod_525(this);
	}

	public void Init(bool ClearTree = true)
	{
		PropertiesForm.Inited = false;
		txt_bestcount.Text = "0";
		if (ClearTree)
		{
			treeView1.Nodes.Clear();
		}
		if (SettingsPar.Runtime.NestExecutionTo != nestResultSendType.Draw)
		{
			if (SettingsPar.Runtime.NestExecutionTo != nestResultSendType.Job)
			{
				radioButton_0.Checked = false;
				radioButton_1.Checked = false;
				radioButton_2.Checked = true;
			}
			else
			{
				radioButton_0.Checked = true;
				radioButton_1.Checked = false;
				radioButton_2.Checked = false;
			}
		}
		else
		{
			radioButton_0.Checked = false;
			radioButton_1.Checked = true;
			radioButton_2.Checked = false;
		}
		checkBox_0.Checked = SettingsPar.Settings.ShowResultPreviewAfterFinish;
		LoadLanguage();
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "NestOnlineCalculation LoadLanguage";
		try
		{
			if (Captions.Count >= 6)
			{
				Text = Captions[0];
				label_0.Text = Captions[1];
				label_1.Text = Captions[2];
				lbl_status.Text = Captions[3];
				label_2.Text = Captions[4];
				btn_settings.Text = Captions[4];
				checkBox_0.Text = Captions[5];
				btn_send.Text = Captions[6];
				btn_preview.Text = Captions[7];
				btn_stop.Text = Captions[8];
				btn_close.Text = Captions[9];
				radioButton_1.Text = Captions[10];
				radioButton_0.Text = Captions[11];
				radioButton_2.Text = buLangTranslate.preDef.File;
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
		e.Cancel = true;
		base.Visible = false;
		if (okCommandEventHandler_1 != null)
		{
			okCommandEventHandler_1();
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (okCommandEventHandler_0 != null)
		{
			okCommandEventHandler_0();
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		base.Visible = false;
		if (okCommandEventHandler_1 != null)
		{
			okCommandEventHandler_1();
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (!radioButton_1.Checked)
		{
			if (!radioButton_0.Checked)
			{
				SettingsPar.Runtime.NestExecutionTo = nestResultSendType.File;
			}
			else
			{
				SettingsPar.Runtime.NestExecutionTo = nestResultSendType.Job;
			}
		}
		else
		{
			SettingsPar.Runtime.NestExecutionTo = nestResultSendType.Draw;
		}
		if (okCommandWithDataEventHandler_1 != null)
		{
			base.Visible = false;
			buNestedResultSentEventArg buNestedResultSentEventArg2 = new buNestedResultSentEventArg();
			string text = string_0;
			ref int indexResult = ref buNestedResultSentEventArg2.IndexResult;
			ref int indexSheet = ref buNestedResultSentEventArg2.IndexSheet;
			Class186.smethod_449(ref indexResult, text, ref buNestedResultSentEventArg2.IndexPart, ref indexSheet, this);
			buNestedResultSentEventArg2.SendToDraw = SettingsPar.Runtime.NestExecutionTo;
			SettingsPar.Settings.ShowResultPreviewAfterFinish = checkBox_0.Checked;
			okCommandWithDataEventHandler_1(buNestedResultSentEventArg2);
		}
	}

	internal void method_4(object sender, TreeViewEventArgs e)
	{
		if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag != null)
		{
			string_0 = treeView1.SelectedNode.Tag.ToString();
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0(string_0);
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		if (panel_1.Visible)
		{
			panel_1.Visible = false;
		}
		else
		{
			panel_1.Visible = true;
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		panel_1.Visible = false;
	}

	internal void method_8(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited && okCommandWithDataEventHandler_2 != null)
		{
			SettingsPar.Settings.ShowResultPreviewAfterFinish = checkBox_0.Checked;
			okCommandWithDataEventHandler_2(SettingsPar);
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
