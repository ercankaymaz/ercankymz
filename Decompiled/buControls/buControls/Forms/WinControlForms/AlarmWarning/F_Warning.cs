using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.AlarmWarning;

public class F_Warning : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public bool ShowReset = true;

	public bool ShowOk = false;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	internal IContainer icontainer_0 = null;

	public ListBox lst_warnig;

	public Button btn_alarmreset;

	public Button btn_close;

	internal ImageList imageList_0;

	public Button btn_ok;

	public event EventHandler WarningResetClick
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

	public F_Warning()
	{
		Class76.smethod_332(this);
	}

	public void Init(List<AppWarning> WarningList)
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
			lst_warnig.Items.Clear();
			for (int i = 0; i <= WarningList.Count - 1; i++)
			{
				lst_warnig.Items.Add(WarningList[i].Text + "ID: " + WarningList[i].ID);
			}
			btn_alarmreset.Visible = ShowReset;
			btn_ok.Visible = ShowOk;
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void Init(List<string> WarningList)
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
			lst_warnig.Items.Clear();
			lst_warnig.Items.Clear();
			for (int i = 0; i <= WarningList.Count - 1; i++)
			{
				lst_warnig.Items.Add(WarningList[i]);
			}
			btn_alarmreset.Visible = ShowReset;
			btn_ok.Visible = ShowOk;
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
			LoadLanguage();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count >= 3)
			{
				Text = Captions[0];
				btn_alarmreset.Text = Captions[1];
				btn_close.Text = Captions[2];
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		try
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
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
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
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, e);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		PropertiesForm.Result = DialogResult.OK;
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
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
