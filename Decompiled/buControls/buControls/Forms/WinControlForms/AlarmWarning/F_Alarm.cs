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

public class F_Alarm : Form
{
	public static List<string> Captions = new List<string>();

	public bool FormTopMost = false;

	public bool ScreenCenter = false;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private IContainer icontainer_0 = null;

	public ListBox lst_alarm;

	public Button btn_alarmreset;

	public Button btn_close;

	public event EventHandler AlarmResetClick
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

	public F_Alarm()
	{
		Class76.smethod_218(this);
	}

	public void Init(List<AppAlarm> AlarmList, bool UseJustText)
	{
		try
		{
			base.TopMost = FormTopMost;
			lst_alarm.Items.Clear();
			for (int i = 0; i <= AlarmList.Count - 1; i++)
			{
				if (UseJustText)
				{
					lst_alarm.Items.Add(AlarmList[i].Text);
				}
				else
				{
					lst_alarm.Items.Add(AlarmList[i].Text + "ID: " + AlarmList[i].ID);
				}
			}
			if (ScreenCenter)
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void Init(List<AppAlarm> AlarmList)
	{
		try
		{
			base.TopMost = FormTopMost;
			lst_alarm.Items.Clear();
			for (int i = 0; i <= AlarmList.Count - 1; i++)
			{
				lst_alarm.Items.Add(AlarmList[i].Text + "ID: " + AlarmList[i].ID);
			}
			if (ScreenCenter)
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void Init(List<string> AlarmList)
	{
		try
		{
			base.TopMost = FormTopMost;
			lst_alarm.Items.Clear();
			for (int i = 0; i <= AlarmList.Count - 1; i++)
			{
				lst_alarm.Items.Add(AlarmList[i]);
			}
			if (ScreenCenter)
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
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
			e.Cancel = true;
			base.Visible = false;
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
			base.Visible = false;
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
