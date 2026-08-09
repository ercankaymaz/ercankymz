using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns27;

namespace buControls.Forms.buControlForms.AlarmWarning;

public class F_AlarmV2 : Form
{
	public List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	public bool FormTopMost = false;

	public bool ScreenCenter = false;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	public buListBox lst_alarm;

	public buButton btn_alarmreset;

	public event OkCommandWithDataEventHandler AlarmResetClick
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

	public F_AlarmV2()
	{
		Class76.smethod_445(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	public void Init(List<AppAlarm> AlarmList)
	{
		try
		{
			base.TopMost = FormTopMost;
			lst_alarm.Items.Clear();
			for (int i = 0; i <= AlarmList.Count - 1; i++)
			{
				lst_alarm.Items.Add(AlarmList[i].Text);
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
			if (Captions.Count >= 2)
			{
				Text = Captions[0];
				buButton_0.Text = Captions[1];
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_1(object sender, FormClosingEventArgs e)
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

	internal void method_2(object sender, EventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			if (okCommandWithDataEventHandler_0 != null)
			{
				okCommandWithDataEventHandler_0("AlarmReset");
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
