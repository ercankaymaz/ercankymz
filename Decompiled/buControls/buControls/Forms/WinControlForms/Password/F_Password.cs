using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Password;

public class F_Password : Form
{
	public FormProperties Properties = new FormProperties();

	public List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal TextBox textBox_0;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public F_Password()
	{
		Class76.smethod_242(this);
	}

	public void Init()
	{
		try
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
			base.AutoScaleMode = Properties.ScaleFromMode;
			textBox_0.Text = "";
			LoadLanguage();
			Properties.Result = DialogResult.None;
			Properties.Inited = true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
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

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 4)
			{
				Text = Captions[0];
				btn_ok.Text = Captions[1];
				btn_cancel.Text = Captions[2];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	private void method_1(string string_0, string string_1)
	{
		try
		{
			if (!(string_1 == AppSecurity.Pass1))
			{
				if (!(string_1 == AppSecurity.Pass2))
				{
					if (!(string_1 == AppSecurity.Pass3))
					{
						if (!(string_1 == AppSecurity.Pass4))
						{
							if (!(string_1 == AppSecurity.Pass5))
							{
								if (!(string_1 == AppSecurity.Pass6))
								{
									if (!(string_1 == AppSecurity.Pass7))
									{
										if (!(string_1 == AppSecurity.Pass8))
										{
											if (!(string_1 == AppSecurity.Pass9))
											{
												if (!(string_1 == AppSecurity.Pass10))
												{
													if (!(string_1 == "2018"))
													{
														AppSecurity.PasswordLevel = 0;
														buLog.addLog("Wrong AppSecurity : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
														if (AppLanguage.SystemMessages.Count < 7)
														{
															buString.MessageBoxError("Password Error");
														}
														else
														{
															buString.MessageBoxError(AppLanguage.SystemMessages[6]);
														}
													}
													else
													{
														AppSecurity.PasswordLevel = 10;
														buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
													}
												}
												else
												{
													AppSecurity.PasswordLevel = 10;
													buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
												}
											}
											else
											{
												AppSecurity.PasswordLevel = 9;
												buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
											}
										}
										else
										{
											AppSecurity.PasswordLevel = 8;
											buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
										}
									}
									else
									{
										AppSecurity.PasswordLevel = 7;
										buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
									}
								}
								else
								{
									AppSecurity.PasswordLevel = 6;
									buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
								}
							}
							else
							{
								AppSecurity.PasswordLevel = 5;
								buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
							}
						}
						else
						{
							AppSecurity.PasswordLevel = 4;
							buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
						}
					}
					else
					{
						AppSecurity.PasswordLevel = 3;
						buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
					}
				}
				else
				{
					AppSecurity.PasswordLevel = 2;
					buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
				}
			}
			else
			{
				AppSecurity.PasswordLevel = 1;
				buLog.addLog("AppSecurity Activated at : " + AppSecurity.PasswordLevel, "PassCheck", MethodBase.GetCurrentMethod().Name);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			AppSecurity.PasswordLevel = 0;
			method_1("", textBox_0.Text);
			textBox_0.Text = "";
			if (AppSecurity.PasswordLevel > 0)
			{
				base.Visible = false;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_cancel.Name)
			{
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
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == textBox_0.Name && AppBool.TouchPad)
			{
				buControlCommands.ShowKeyPad(this, textBox_0);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
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
