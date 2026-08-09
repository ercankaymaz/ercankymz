using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.License;

public class F_AskLicense : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ReportProgram Report = new ReportProgram();

	public string strName = "You Must Enter Your Name";

	public string strMail = "You Must Enter Your Contact Mail";

	public string strMailError = "You Mail Address is not correct format";

	public string strCompany = "You Must Enter Your Company Name";

	public string strExplanation = "You Must Enter Your Explanation and Comments";

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal TextBox textBox_0;

	internal Label label_0;

	internal TextBox textBox_1;

	internal Label label_1;

	internal TextBox textBox_2;

	internal Label label_2;

	internal TextBox textBox_3;

	internal Label label_3;

	public Button btn_cancel;

	public Button btn_send;

	public F_AskLicense()
	{
		Class76.smethod_618(this);
	}

	public void Init()
	{
		textBox_2.Text = Report.Company;
		textBox_1.Text = Report.email;
		textBox_3.Text = Report.Name;
		Properties.Result = DialogResult.None;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "Report LoadLanguage";
		try
		{
			if (Captions.Count >= 7)
			{
				Text = Captions[0];
				label_3.Text = Captions[1];
				label_2.Text = Captions[2];
				label_1.Text = Captions[3];
				label_0.Text = Captions[4];
				btn_send.Text = Captions[5];
				btn_cancel.Text = Captions[6];
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
		string callMethod = "Report F_Report_FormClosing";
		try
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
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		string callMethod = "Report btn_cancel_Click";
		try
		{
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		string callMethod = "Report btn_send_Click";
		try
		{
			if (textBox_3.Text.Trim().Length <= 0)
			{
				MessageBox.Show(strName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (textBox_1.Text.Trim().Length <= 0)
			{
				MessageBox.Show(strMail, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (textBox_2.Text.Trim().Length <= 0)
			{
				MessageBox.Show(strCompany, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (!buNet.IsValidEmail(textBox_1.Text.Trim()))
			{
				MessageBox.Show(strMailError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
		Report = new ReportProgram();
		Report.Name = textBox_3.Text.Trim();
		Report.Company = textBox_2.Text.Trim();
		Report.email = textBox_1.Text.Trim();
		Report.Explanation = textBox_0.Text.Trim();
		Properties.Result = DialogResult.OK;
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
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
