using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Errors;

public class F_ErrorList : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	public ListBox lst_alarm;

	public Button btn_close;

	public F_ErrorList()
	{
		Class76.smethod_219(this);
	}

	public void Init(List<CalculationError> AlarmList, bool UseJustText)
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
			for (int i = 0; i <= AlarmList.Count - 1; i++)
			{
				if (UseJustText)
				{
					lst_alarm.Items.Add(AlarmList[i].Explanation);
				}
				else
				{
					lst_alarm.Items.Add(AlarmList[i].Explanation + "ID: " + AlarmList[i].ID);
				}
			}
			LoadLanguage();
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void Init(List<CalculationError> AlarmList)
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
			for (int i = 0; i <= AlarmList.Count - 1; i++)
			{
				lst_alarm.Items.Add(AlarmList[i].Explanation);
			}
			LoadLanguage();
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
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
			for (int i = 0; i <= AlarmList.Count - 1; i++)
			{
				lst_alarm.Items.Add(AlarmList[i]);
			}
			LoadLanguage();
			PropertiesForm.Result = DialogResult.None;
			PropertiesForm.Inited = true;
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
		string callMethod = "Report F_Report_FormClosing";
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
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
