using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Password;

public class F_Password : Form
{
	public List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buTextBox buTextBox_0;

	internal buButton buButton_2;

	internal buButton buButton_3;

	public F_Password()
	{
		Class76.smethod_750(this);
	}

	public void Init()
	{
		try
		{
			buTextBox_0.Text = "";
			LoadLanguage();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 4)
			{
				Text = Captions[0];
				buButton_2.Text = Captions[1];
				buButton_3.Text = Captions[2];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void OpenPassword(string FileName, double Key)
	{
		try
		{
			int num = 0;
			string text = "";
			FileInfo fileInfo = new FileInfo(FileName);
			if (fileInfo.Exists)
			{
				FileStream input = new FileStream(FileName, FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(input);
				num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte value = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass1 = text + Convert.ToChar(value));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int j = 0; j < num; j++)
				{
					byte value2 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass2 = text + Convert.ToChar(value2));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int k = 0; k < num; k++)
				{
					byte value3 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass3 = text + Convert.ToChar(value3));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int l = 0; l < num; l++)
				{
					byte value4 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass4 = text + Convert.ToChar(value4));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int m = 0; m < num; m++)
				{
					byte value5 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass5 = text + Convert.ToChar(value5));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int n = 0; n < num; n++)
				{
					byte value6 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass6 = text + Convert.ToChar(value6));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num2 = 0; num2 < num; num2++)
				{
					byte value7 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass7 = text + Convert.ToChar(value7));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num3 = 0; num3 < num; num3++)
				{
					byte value8 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass8 = text + Convert.ToChar(value8));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num4 = 0; num4 < num; num4++)
				{
					byte value9 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass9 = text + Convert.ToChar(value9));
				}
				text = "";
				num = binaryReader.ReadInt32();
				for (int num5 = 0; num5 < num; num5++)
				{
					byte value10 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
					text = (AppSecurity.Pass10 = text + Convert.ToChar(value10));
				}
				binaryReader.Close();
			}
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text2);
		}
	}

	private void method_0(string string_0, string string_1)
	{
		try
		{
			if (string_1.Trim().Length != 0)
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
														if (!(string_1 == "2016"))
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
			else
			{
				AppSecurity.PasswordLevel = 0;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			AppSecurity.PasswordLevel = 0;
			method_0("", buTextBox_0.Text);
			buTextBox_0.Text = "";
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

	internal void method_2(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if ((control.Name == buButton_1.Name) | (control.Name == buButton_3.Name))
			{
				buTextBox_0.Text = "";
				base.Visible = false;
			}
			if (control.Name == buButton_0.Name)
			{
				buTextBox_0.Text = "";
				base.WindowState = FormWindowState.Minimized;
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
			if (control.Name == buTextBox_0.Name && AppBool.TouchPad)
			{
				buControlCommands.ShowKeyPad(this, buTextBox_0, "*");
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
