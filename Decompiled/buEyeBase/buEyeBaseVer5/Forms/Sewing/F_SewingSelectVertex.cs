using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Sewing;

public class F_SewingSelectVertex : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler_0;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public new bool ShowDialog = false;

	public double RotateDegree = 10.0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_selectup;

	public Button btn_selectdown;

	public Button btn_ok;

	public event OkCommandWithThreeDataEventHandler SelectCommad
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Combine(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Remove(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler CancelCommad
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_SewingSelectVertex()
	{
		Class186.smethod_649(this);
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
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
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

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_selectdown.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("Minus", -1, null);
		}
		if (control.Name == btn_selectup.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("Plus", 1, null);
		}
		if (control.Name == btn_ok.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("Ok", 0, ShowDialog);
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
