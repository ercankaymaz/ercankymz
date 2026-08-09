using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Report;

public class F_Report : Form
{
	public static List<string> Captions = new List<string>();

	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public ReportProgram Report = new ReportProgram();

	public string strName = "You Must Enter Your Name";

	public string strMail = "You Must Enter Your Contact Mail";

	public string strMailError = "You Mail Address is not correct format";

	public string strCompany = "You Must Enter Your Company Name";

	public string strBuy = "You Must Enter Where did You Buy Information";

	public string strExplanation = "You Must Enter Your Explanation and Comments";

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_send;

	internal TextBox textBox_0;

	internal Label label_0;

	internal TextBox textBox_1;

	internal Label label_1;

	internal TextBox textBox_2;

	internal Label label_2;

	internal TextBox textBox_3;

	internal Label label_3;

	internal TextBox textBox_4;

	internal Label label_4;

	public F_Report()
	{
		Class76.smethod_622(this);
	}

	public void Init()
	{
		textBox_2.Text = Report.Buy;
		textBox_1.Text = Report.Company;
		textBox_3.Text = Report.email;
		textBox_0.Text = Report.Name;
		Result = DialogResult.None;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "Report LoadLanguage";
		try
		{
			if (Captions.Count >= 8)
			{
				Text = Captions[0];
				label_0.Text = Captions[1];
				label_1.Text = Captions[2];
				label_2.Text = Captions[3];
				label_3.Text = Captions[4];
				label_4.Text = Captions[5];
				btn_send.Text = Captions[6];
				btn_cancel.Text = Captions[7];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (textBox_0.Text.Trim().Length > 0)
		{
			if (textBox_3.Text.Trim().Length > 0)
			{
				if (textBox_1.Text.Trim().Length > 0)
				{
					if (textBox_2.Text.Trim().Length > 0)
					{
						if (textBox_4.Text.Trim().Length > 0)
						{
							if (buNet.IsValidEmail(textBox_3.Text.Trim()))
							{
								Report = new ReportProgram();
								Report.Name = textBox_0.Text.Trim();
								Report.Company = textBox_1.Text.Trim();
								Report.email = textBox_3.Text.Trim();
								Report.Buy = textBox_2.Text.Trim();
								Report.Explanation = textBox_4.Text.Trim();
								Result = DialogResult.OK;
								if (FormCloseMode == FormCloseModeType.Dispose)
								{
									Dispose();
								}
								if (FormCloseMode == FormCloseModeType.Invisible)
								{
									base.Visible = false;
								}
							}
							else
							{
								MessageBox.Show(strMailError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						else
						{
							MessageBox.Show(strExplanation, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					else
					{
						MessageBox.Show(strBuy, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					MessageBox.Show(strCompany, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				MessageBox.Show(strMail, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else
		{
			MessageBox.Show(strName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
